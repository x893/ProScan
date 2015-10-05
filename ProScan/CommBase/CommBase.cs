using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace ProScan
{
	public abstract class CommBase : IDisposable
	{
		public enum PortStatus
		{
			Absent = -1,
			Unavailable = 0,
			Available = 1,
		}

		private IntPtr m_ptrUWO = IntPtr.Zero;
		private Thread m_RxThread = (Thread)null;
		private bool m_online = false;
		private bool m_auto = false;
		private bool m_checkSends = true;
		private Exception m_RxException = (Exception)null;
		private bool m_RxExceptionReported = false;
		private int m_writeCount = 0;
		private ManualResetEvent m_writeEvent = new ManualResetEvent(false);
		private ManualResetEvent m_startEvent = new ManualResetEvent(false);
		private bool[] m_empty = new bool[1];
		private IntPtr m_hPort;

		public bool Online
		{
			get
			{
				if (!m_online)
					return false;
				else
					return CheckOnline();
			}
		}

		~CommBase()
		{
			Close();
		}

		public static string AltName(string s)
		{
			s.Trim();
			if (s.EndsWith(":"))
				s = s.Substring(0, s.Length - 1);
			if (s.StartsWith("\\"))
				return s;
			else
				return "\\\\.\\" + s;
		}

		public static bool isPortAvailable(int iComPort)
		{
			return (IsPortAvailable(iComPort) > CommBase.PortStatus.Unavailable);
		}

		public static PortStatus IsPortAvailable(int iComPort)
		{
			string comPort = "COM" + iComPort.ToString();
			IntPtr file = Win32Com.CreateFile(comPort, 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
			if (file == (IntPtr)(-1))
			{
				if ((long)Marshal.GetLastWin32Error() == 5L)
					return PortStatus.Unavailable;
				file = Win32Com.CreateFile(AltName(comPort), 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
				if (file == (IntPtr)(-1))
					return (long)Marshal.GetLastWin32Error() == 5L ? PortStatus.Unavailable : PortStatus.Absent;
			}
			Win32Com.CloseHandle(file);
			return PortStatus.Available;
		}

		public bool Open()
		{
			Win32Com.DCB lpDCB = new Win32Com.DCB();
			Win32Com.COMMTIMEOUTS lpCommTimeouts = new Win32Com.COMMTIMEOUTS();
			Win32Com.OVERLAPPED overlapped = new Win32Com.OVERLAPPED();
			if (m_online)
				return false;
			CommBase.CommBaseSettings commBaseSettings = CommSettings();
			m_hPort = Win32Com.CreateFile(commBaseSettings.Port, 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
			if (m_hPort == (IntPtr)(-1))
			{
				if ((long)Marshal.GetLastWin32Error() == 5L)
					return false;
				m_hPort = Win32Com.CreateFile(AltName(commBaseSettings.Port), 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
				if (m_hPort == (IntPtr)(-1))
				{
					if ((long)Marshal.GetLastWin32Error() == 5L)
						return false;
					else
						throw new CommPortException("Port Open Failure");
				}
			}
			m_online = true;

			lpCommTimeouts.ReadIntervalTimeout = uint.MaxValue;
			lpCommTimeouts.ReadTotalTimeoutConstant = 0U;
			lpCommTimeouts.ReadTotalTimeoutMultiplier = 0U;
			lpCommTimeouts.WriteTotalTimeoutMultiplier =
				commBaseSettings.SendTimeoutMultiplier != 0
				? (uint)commBaseSettings.SendTimeoutMultiplier
				: (Environment.OSVersion.Platform != PlatformID.Win32NT ? 10000U : 0U);
			lpCommTimeouts.WriteTotalTimeoutConstant = (uint)commBaseSettings.SendTimeoutConstant;

			lpDCB.init(commBaseSettings.Parity == CommBase.Parity.Odd || commBaseSettings.Parity == CommBase.Parity.Even, commBaseSettings.TxFlowCTS, commBaseSettings.TxFlowDSR, (int)commBaseSettings.UseDTR, commBaseSettings.RxGateDSR, !commBaseSettings.TxWhenRxXoff, commBaseSettings.TxFlowX, commBaseSettings.RxFlowX, (int)commBaseSettings.UseRTS);
			lpDCB.BaudRate = commBaseSettings.BaudRate;
			lpDCB.ByteSize = (byte)commBaseSettings.DataBits;
			lpDCB.Parity = (byte)commBaseSettings.Parity;
			lpDCB.StopBits = (byte)commBaseSettings.StopBits;
			lpDCB.XoffChar = (byte)commBaseSettings.XoffChar;
			lpDCB.XonChar = (byte)commBaseSettings.XonChar;

			if ((commBaseSettings.RxQueue != 0 || commBaseSettings.TxQueue != 0)
			&& !Win32Com.SetupComm(m_hPort, (uint)commBaseSettings.RxQueue, (uint)commBaseSettings.TxQueue)
				)
				ThrowException("Bad queue settings");

			if (commBaseSettings.RxLowWater == 0 || commBaseSettings.RxHighWater == 0)
			{
				Win32Com.COMMPROP cp;
				if (!Win32Com.GetCommProperties(m_hPort, out cp))
					cp.dwCurrentRxQueue = 0;
				lpDCB.XoffLim =
					(cp.dwCurrentRxQueue <= 0U)
					? (lpDCB.XonLim = 8)
					: (lpDCB.XonLim = (short)((int)cp.dwCurrentRxQueue / 10)
					);
			}
			else
			{
				lpDCB.XoffLim = (short)commBaseSettings.RxHighWater;
				lpDCB.XonLim = (short)commBaseSettings.RxLowWater;
			}

			if (!Win32Com.SetCommState(m_hPort, ref lpDCB))
				ThrowException("Bad com settings");

			if (!Win32Com.SetCommTimeouts(m_hPort, ref lpCommTimeouts))
				ThrowException("Bad timeout settings");

			m_checkSends = commBaseSettings.CheckAllSends;
			overlapped.Offset = 0U;
			overlapped.OffsetHigh = 0U;
			overlapped.hEvent = !m_checkSends ? IntPtr.Zero : m_writeEvent.SafeWaitHandle.DangerousGetHandle();
			m_ptrUWO = Marshal.AllocHGlobal(Marshal.SizeOf((object)overlapped));
			Marshal.StructureToPtr((object)overlapped, m_ptrUWO, true);
			m_writeCount = 0;
			m_empty[0] = true;
			m_RxException = (Exception)null;
			m_RxExceptionReported = false;
			m_RxThread = new Thread(new ThreadStart(ReceiveThread));
			m_RxThread.Name = "CommBaseRx";
			m_RxThread.Priority = ThreadPriority.AboveNormal;
			m_RxThread.Start();
			m_startEvent.WaitOne(500, false);
			m_auto = false;
			if (AfterOpen())
			{
				m_auto = commBaseSettings.AutoReopen;
				return true;
			}
			else
			{
				Close();
				return false;
			}
		}

		public void Close()
		{
			if (!m_online)
				return;
			m_auto = false;
			BeforeClose(false);
			InternalClose();
			m_RxException = (Exception)null;
		}

		private void InternalClose()
		{
			Win32Com.CancelIo(m_hPort);
			if (m_RxThread != null)
			{
				m_RxThread.Abort();
				m_RxThread.Join(100);
				m_RxThread = (Thread)null;
			}
			Win32Com.CloseHandle(m_hPort);
			if (m_ptrUWO != IntPtr.Zero)
				Marshal.FreeHGlobal(m_ptrUWO);
		}

		public void Dispose()
		{
			Close();
		}

		protected void ThrowException(string reason)
		{
			if (Thread.CurrentThread == m_RxThread)
				throw new CommPortException(reason);
			if (m_online)
			{
				BeforeClose(true);
				InternalClose();
			}
			if (m_RxException == null)
				throw new CommPortException(reason);
			else
				throw new CommPortException(m_RxException);
		}

		protected void Send(byte[] tosend)
		{
			uint lpNumberOfBytesWritten = 0U;
			CheckOnline();
			CheckResult();
			m_writeCount = tosend.GetLength(0);
			if (Win32Com.WriteFile(m_hPort, tosend, (uint)m_writeCount, out lpNumberOfBytesWritten, m_ptrUWO))
			{
				m_writeCount -= (int)lpNumberOfBytesWritten;
			}
			else
			{
				if ((long)Marshal.GetLastWin32Error() != 997L)
					ThrowException("Send failed");
			}
		}

		private void CheckResult()
		{
			uint nNumberOfBytesTransferred = 0U;
			if (m_writeCount <= 0)
				return;
			if (Win32Com.GetOverlappedResult(m_hPort, m_ptrUWO, out nNumberOfBytesTransferred, m_checkSends))
			{
				if (!m_checkSends)
					return;
				m_writeCount -= (int)nNumberOfBytesTransferred;
				if (m_writeCount != 0)
					ThrowException("Send Timeout");
				m_writeCount = 0;
			}
			else
			{
				if ((long)Marshal.GetLastWin32Error() == 996L)
					return;
				ThrowException("Write Error");
			}
		}

		protected virtual CommBase.CommBaseSettings CommSettings()
		{
			return new CommBase.CommBaseSettings();
		}

		protected virtual bool AfterOpen()
		{
			return true;
		}

		protected virtual void BeforeClose(bool error)
		{
		}

		protected virtual void OnRxChar(byte ch)
		{
		}

		protected virtual void OnTxDone()
		{
		}

		protected virtual void OnBreak()
		{
		}

		protected virtual void OnRxException(Exception e)
		{
		}

		private void ReceiveThread()
		{
			byte[] lpBuffer = new byte[1];
			bool flag = true;
			AutoResetEvent autoResetEvent = new AutoResetEvent(false);
			Win32Com.OVERLAPPED overlapped = new Win32Com.OVERLAPPED();
			uint num1 = 0;
			IntPtr num2 = Marshal.AllocHGlobal(Marshal.SizeOf(overlapped));
			IntPtr num3 = Marshal.AllocHGlobal(Marshal.SizeOf(num1));
			overlapped.Offset = 0U;
			overlapped.OffsetHigh = 0U;
			overlapped.hEvent = autoResetEvent.SafeWaitHandle.DangerousGetHandle();
			Marshal.StructureToPtr(overlapped, num2, true);
			try
			{
				while (Win32Com.SetCommMask(m_hPort, 509U))
				{
					Marshal.WriteInt32(num3, 0);
					if (flag)
					{
						m_startEvent.Set();
						flag = false;
					}
					if (!Win32Com.WaitCommEvent(m_hPort, num3, num2))
					{
						if (Marshal.GetLastWin32Error() != 997)
							throw new CommPortException("IO Error [002]");
						autoResetEvent.WaitOne();
					}

					int num4 = Marshal.ReadInt32(num3);
					if ((num4 & 128) != 0)
					{
						uint lpErrors;
						if (!Win32Com.ClearCommError(m_hPort, out lpErrors, IntPtr.Zero))
							throw new CommPortException("IO Error [003]");
						int num5 = 0;
						StringBuilder stringBuilder = new StringBuilder("UART Error: ", 40);
						if ((lpErrors & 8) != 0)
						{
							stringBuilder = stringBuilder.Append("Framing,");
							++num5;
						}
						if ((lpErrors & 1024) != 0)
						{
							stringBuilder = stringBuilder.Append("IO,");
							++num5;
						}
						if ((lpErrors & 2) != 0)
						{
							stringBuilder = stringBuilder.Append("Overrun,");
							++num5;
						}
						if ((lpErrors & 1) != 0)
						{
							stringBuilder = stringBuilder.Append("Receive Cverflow,");
							++num5;
						}
						if ((lpErrors & 4) != 0)
						{
							stringBuilder = stringBuilder.Append("Parity,");
							++num5;
						}
						if ((lpErrors & 256) != 0)
						{
							stringBuilder = stringBuilder.Append("Transmit Overflow,");
							++num5;
						}
						if (num5 > 0)
						{
							stringBuilder.Length = stringBuilder.Length - 1;
							throw new CommPortException(stringBuilder.ToString());
						}
						else
						{
							if (lpErrors != 16)
								throw new CommPortException("IO Error [003]");
							num4 |= 64;
						}
					}
					if ((num4 & 1) != 0)
					{
						uint nNumberOfBytesRead;
						do
						{
							nNumberOfBytesRead = 0U;
							if (!Win32Com.ReadFile(m_hPort, lpBuffer, 1U, out nNumberOfBytesRead, num2))
							{
								Marshal.GetLastWin32Error();
								throw new CommPortException("IO Error [004]");
							}
							else if (nNumberOfBytesRead == 1)
								OnRxChar(lpBuffer[0]);
						}
						while (nNumberOfBytesRead > 0U);
					}
					if ((num4 & 4) != 0)
					{
						lock (m_empty)
							m_empty[0] = true;
						OnTxDone();
					}
					if ((num4 & 64) != 0)
						OnBreak();
					uint val = 0U;
					if ((num4 & 8) != 0)
						val |= 16U;
					if ((num4 & 16) != 0)
						val |= 32U;
					if ((num4 & 32) != 0)
						val |= 128U;
					if ((num4 & 256) != 0)
						val |= 64U;
					if (val != 0)
					{
						uint lpModemStat;
						if (!Win32Com.GetCommModemStatus(m_hPort, out lpModemStat))
							throw new CommPortException("IO Error [005]");
					}
				}
				throw new CommPortException("IO Error [001]");
			}
			catch (Exception ex)
			{
				Win32Com.CancelIo(m_hPort);
				if (num3 != IntPtr.Zero)
					Marshal.FreeHGlobal(num3);
				if (num2 != IntPtr.Zero)
					Marshal.FreeHGlobal(num2);
				if (ex is ThreadAbortException)
					return;
				m_RxException = ex;
				OnRxException(ex);
			}
		}

		private bool CheckOnline()
		{
			if (m_RxException != null && !m_RxExceptionReported)
			{
				m_RxExceptionReported = true;
				ThrowException("rx");
			}
			if (m_online)
			{
				if (m_hPort != (IntPtr)(-1))
					return true;
				ThrowException("Offline");
				return false;
			}
			else
			{
				if (m_auto && Open())
					return true;
				ThrowException("Offline");
				return false;
			}
		}

		public enum Parity
		{
			None,
			Odd,
			Even,
			Mark,
			Space
		}

		public enum StopBits
		{
			One,
			OnePointFive,
			Two
		}

		public enum HSOutput
		{
			None,
			Online,
			Handshake
		}

		public enum Handshake
		{
			None,
			XonXoff,
			CtsRts,
			DsrDtr,
		}

		public class CommBaseSettings
		{
			public string Port = "COM1:";
			public int BaudRate = 2400;
			public CommBase.Parity Parity = CommBase.Parity.None;
			public int DataBits = 8;
			public CommBase.StopBits StopBits = CommBase.StopBits.One;
			public bool TxFlowCTS = false;
			public bool TxFlowDSR = false;
			public bool TxFlowX = false;
			public bool TxWhenRxXoff = true;
			public bool RxGateDSR = false;
			public bool RxFlowX = false;
			public CommBase.HSOutput UseRTS = CommBase.HSOutput.None;
			public CommBase.HSOutput UseDTR = CommBase.HSOutput.None;
			public CommBase.ASCII XonChar = CommBase.ASCII.DC1;
			public CommBase.ASCII XoffChar = CommBase.ASCII.DC3;
			public int RxHighWater = 0;
			public int RxLowWater = 0;
			public int SendTimeoutMultiplier = 0;
			public int SendTimeoutConstant = 0;
			public int RxQueue = 0;
			public int TxQueue = 0;
			public bool AutoReopen = false;
			public bool CheckAllSends = true;

			public void SetStandard(string port, int baudrate, CommBase.Handshake handshake)
			{
				DataBits = 8;
				StopBits = CommBase.StopBits.One;
				Parity = CommBase.Parity.None;
				Port = port;
				BaudRate = baudrate;
				switch (handshake)
				{
					case CommBase.Handshake.None:
						TxFlowCTS = false;
						TxFlowDSR = false;
						TxFlowX = false;
						RxFlowX = false;
						UseRTS = CommBase.HSOutput.Online;
						UseDTR = CommBase.HSOutput.Online;
						TxWhenRxXoff = true;
						RxGateDSR = false;
						break;
					case CommBase.Handshake.XonXoff:
						TxFlowCTS = false;
						TxFlowDSR = false;
						TxFlowX = true;
						RxFlowX = true;
						UseRTS = CommBase.HSOutput.Online;
						UseDTR = CommBase.HSOutput.Online;
						TxWhenRxXoff = true;
						RxGateDSR = false;
						XonChar = CommBase.ASCII.DC1;
						XoffChar = CommBase.ASCII.DC3;
						break;
					case CommBase.Handshake.CtsRts:
						TxFlowCTS = true;
						TxFlowDSR = false;
						TxFlowX = false;
						RxFlowX = false;
						UseRTS = CommBase.HSOutput.Handshake;
						UseDTR = CommBase.HSOutput.Online;
						TxWhenRxXoff = true;
						RxGateDSR = false;
						break;
					case CommBase.Handshake.DsrDtr:
						TxFlowCTS = false;
						TxFlowDSR = true;
						TxFlowX = false;
						RxFlowX = false;
						UseRTS = CommBase.HSOutput.Online;
						UseDTR = CommBase.HSOutput.Handshake;
						TxWhenRxXoff = true;
						RxGateDSR = false;
						break;
				}
			}
		}

		public enum ASCII : byte
		{
			NULL = (byte)0,
			SOH = (byte)1,
			STX = (byte)2,
			ETX = (byte)3,
			EOT = (byte)4,
			ENQ = (byte)5,
			ACK = (byte)6,
			BELL = (byte)7,
			BS = (byte)8,
			HT = (byte)9,
			LF = (byte)10,
			VT = (byte)11,
			FF = (byte)12,
			CR = (byte)13,
			SO = (byte)14,
			SI = (byte)15,
			DC1 = (byte)17,
			DC2 = (byte)18,
			DC3 = (byte)19,
			DC4 = (byte)20,
			NAK = (byte)21,
			SYN = (byte)22,
			ETB = (byte)23,
			CAN = (byte)24,
			EM = (byte)25,
			SUB = (byte)26,
			ESC = (byte)27,
			FS = (byte)28,
			GS = (byte)29,
			RS = (byte)30,
			US = (byte)31,
			SP = (byte)32,
			GT = (byte)62,
			DEL = (byte)127,
		}
	}
}
