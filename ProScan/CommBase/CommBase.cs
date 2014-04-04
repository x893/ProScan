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
		private IntPtr ptrUWO = IntPtr.Zero;
		private Thread rxThread = (Thread)null;
		private bool online = false;
		private bool auto = false;
		private bool checkSends = true;
		private Exception rxException = (Exception)null;
		private bool rxExceptionReported = false;
		private int writeCount = 0;
		private ManualResetEvent writeEvent = new ManualResetEvent(false);
		private ManualResetEvent startEvent = new ManualResetEvent(false);
		private int stateRTS = 2;
		private int stateDTR = 2;
		private int stateBRK = 2;
		private bool[] empty = new bool[1];
		private bool dataQueued = false;
		private IntPtr hPort;

		public bool Online
		{
			get
			{
				if (!online)
					return false;
				else
					return CheckOnline();
			}
		}

		protected bool RTSavailable
		{
			get { return stateRTS < 2; }
		}

		protected bool RTS
		{
			get { return stateRTS == 1; }
			set
			{
				if (stateRTS > 1)
					return;
				CheckOnline();
				if (value)
				{
					if (Win32Com.EscapeCommFunction(hPort, 3U))
						stateRTS = 1;
					else
						ThrowException("Unexpected Failure");
				}
				else if (Win32Com.EscapeCommFunction(hPort, 4U))
					stateRTS = 0;
				else
					ThrowException("Unexpected Failure");
			}
		}

		protected bool DTRavailable
		{
			get { return stateDTR < 2; }
		}

		protected bool DTR
		{
			get
			{
				return stateDTR == 1;
			}
			set
			{
				if (stateDTR > 1)
					return;
				CheckOnline();
				if (value)
				{
					if (Win32Com.EscapeCommFunction(hPort, 5U))
						stateDTR = 1;
					else
						ThrowException("Unexpected Failure");
				}
				else if (Win32Com.EscapeCommFunction(hPort, 6U))
					stateDTR = 0;
				else
					ThrowException("Unexpected Failure");
			}
		}

		protected bool Break
		{
			get
			{
				return stateBRK == 1;
			}
			set
			{
				if (stateBRK > 1)
					return;
				CheckOnline();
				if (value)
				{
					if (Win32Com.EscapeCommFunction(hPort, 8U))
						stateBRK = 0;
					else
						ThrowException("Unexpected Failure");
				}
				else if (Win32Com.EscapeCommFunction(hPort, 9U))
					stateBRK = 0;
				else
					ThrowException("Unexpected Failure");
			}
		}

		~CommBase()
		{
			Close();
		}

		private string AltName(string s)
		{
			s.Trim();
			if (s.EndsWith(":"))
				s = s.Substring(0, s.Length - 1);
			if (s.StartsWith("\\"))
				return s;
			else
				return "\\\\.\\" + s;
		}

		public CommBase.PortStatus IsPortAvailable(string s)
		{
			IntPtr file = Win32Com.CreateFile(s, 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
			if (file == (IntPtr)(-1))
			{
				if ((long)Marshal.GetLastWin32Error() == 5L)
					return CommBase.PortStatus.unavailable;
				file = Win32Com.CreateFile(AltName(s), 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
				if (file == (IntPtr)(-1))
					return (long)Marshal.GetLastWin32Error() == 5L ? CommBase.PortStatus.unavailable : CommBase.PortStatus.absent;
			}
			Win32Com.CloseHandle(file);
			return CommBase.PortStatus.available;
		}

		public bool Open()
		{
			Win32Com.DCB lpDCB = new Win32Com.DCB();
			Win32Com.COMMTIMEOUTS lpCommTimeouts = new Win32Com.COMMTIMEOUTS();
			Win32Com.OVERLAPPED overlapped = new Win32Com.OVERLAPPED();
			if (online)
				return false;
			CommBase.CommBaseSettings commBaseSettings = CommSettings();
			hPort = Win32Com.CreateFile(commBaseSettings.port, 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
			if (hPort == (IntPtr)(-1))
			{
				if ((long)Marshal.GetLastWin32Error() == 5L)
					return false;
				hPort = Win32Com.CreateFile(AltName(commBaseSettings.port), 3221225472U, 0U, IntPtr.Zero, 3U, 1073741824U, IntPtr.Zero);
				if (hPort == (IntPtr)(-1))
				{
					if ((long)Marshal.GetLastWin32Error() == 5L)
						return false;
					else
						throw new CommPortException("Port Open Failure");
				}
			}
			online = true;
			lpCommTimeouts.ReadIntervalTimeout = uint.MaxValue;
			lpCommTimeouts.ReadTotalTimeoutConstant = 0U;
			lpCommTimeouts.ReadTotalTimeoutMultiplier = 0U;
			lpCommTimeouts.WriteTotalTimeoutMultiplier = (int)commBaseSettings.sendTimeoutMultiplier != 0 ? commBaseSettings.sendTimeoutMultiplier : (Environment.OSVersion.Platform != PlatformID.Win32NT ? 10000U : 0U);
			lpCommTimeouts.WriteTotalTimeoutConstant = commBaseSettings.sendTimeoutConstant;
			lpDCB.init(commBaseSettings.parity == CommBase.Parity.odd || commBaseSettings.parity == CommBase.Parity.even, commBaseSettings.txFlowCTS, commBaseSettings.txFlowDSR, (int)commBaseSettings.useDTR, commBaseSettings.rxGateDSR, !commBaseSettings.txWhenRxXoff, commBaseSettings.txFlowX, commBaseSettings.rxFlowX, (int)commBaseSettings.useRTS);
			lpDCB.BaudRate = commBaseSettings.baudRate;
			lpDCB.ByteSize = (byte)commBaseSettings.dataBits;
			lpDCB.Parity = (byte)commBaseSettings.parity;
			lpDCB.StopBits = (byte)commBaseSettings.stopBits;
			lpDCB.XoffChar = (byte)commBaseSettings.XoffChar;
			lpDCB.XonChar = (byte)commBaseSettings.XonChar;
			if ((commBaseSettings.rxQueue != 0 || commBaseSettings.txQueue != 0) && !Win32Com.SetupComm(hPort, (uint)commBaseSettings.rxQueue, (uint)commBaseSettings.txQueue))
				ThrowException("Bad queue settings");
			if (commBaseSettings.rxLowWater == 0 || commBaseSettings.rxHighWater == 0)
			{
				Win32Com.COMMPROP cp;
				if (!Win32Com.GetCommProperties(hPort, out cp))
					cp.dwCurrentRxQueue = 0U;
				lpDCB.XoffLim = cp.dwCurrentRxQueue <= 0U ? (lpDCB.XonLim = (short)8) : (lpDCB.XonLim = (short)((int)cp.dwCurrentRxQueue / 10));
			}
			else
			{
				lpDCB.XoffLim = (short)commBaseSettings.rxHighWater;
				lpDCB.XonLim = (short)commBaseSettings.rxLowWater;
			}
			if (!Win32Com.SetCommState(hPort, ref lpDCB))
				ThrowException("Bad com settings");
			if (!Win32Com.SetCommTimeouts(hPort, ref lpCommTimeouts))
				ThrowException("Bad timeout settings");
			stateBRK = 0;
			if (commBaseSettings.useDTR == CommBase.HSOutput.none)
				stateDTR = 0;
			if (commBaseSettings.useDTR == CommBase.HSOutput.online)
				stateDTR = 1;
			if (commBaseSettings.useRTS == CommBase.HSOutput.none)
				stateRTS = 0;
			if (commBaseSettings.useRTS == CommBase.HSOutput.online)
				stateRTS = 1;
			checkSends = commBaseSettings.checkAllSends;
			overlapped.Offset = 0U;
			overlapped.OffsetHigh = 0U;
			overlapped.hEvent = !checkSends ? IntPtr.Zero : writeEvent.Handle;
			ptrUWO = Marshal.AllocHGlobal(Marshal.SizeOf((object)overlapped));
			Marshal.StructureToPtr((object)overlapped, ptrUWO, true);
			writeCount = 0;
			empty[0] = true;
			dataQueued = false;
			rxException = (Exception)null;
			rxExceptionReported = false;
			rxThread = new Thread(new ThreadStart(ReceiveThread));
			rxThread.Name = "CommBaseRx";
			rxThread.Priority = ThreadPriority.AboveNormal;
			rxThread.Start();
			startEvent.WaitOne(500, false);
			auto = false;
			if (AfterOpen())
			{
				auto = commBaseSettings.autoReopen;
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
			if (!online)
				return;
			auto = false;
			BeforeClose(false);
			InternalClose();
			rxException = (Exception)null;
		}

		private void InternalClose()
		{
			Win32Com.CancelIo(hPort);
			if (rxThread != null)
			{
				rxThread.Abort();
				rxThread.Join(100);
				rxThread = (Thread)null;
			}
			Win32Com.CloseHandle(hPort);
			if (ptrUWO != IntPtr.Zero)
				Marshal.FreeHGlobal(ptrUWO);
			stateRTS = 2;
			stateDTR = 2;
			stateBRK = 2;
			online = false;
		}

		public void Dispose()
		{
			Close();
		}

		public void Flush()
		{
			CheckOnline();
			CheckResult();
		}

		protected void ThrowException(string reason)
		{
			if (Thread.CurrentThread == rxThread)
				throw new CommPortException(reason);
			if (online)
			{
				BeforeClose(true);
				InternalClose();
			}
			if (rxException == null)
				throw new CommPortException(reason);
			else
				throw new CommPortException(rxException);
		}

		protected void Send(byte[] tosend)
		{
			uint lpNumberOfBytesWritten = 0U;
			CheckOnline();
			CheckResult();
			writeCount = tosend.GetLength(0);
			if (Win32Com.WriteFile(hPort, tosend, (uint)writeCount, out lpNumberOfBytesWritten, ptrUWO))
			{
				writeCount -= (int)lpNumberOfBytesWritten;
			}
			else
			{
				if ((long)Marshal.GetLastWin32Error() != 997L)
					ThrowException("Send failed");
				dataQueued = true;
			}
		}

		protected void Send(byte tosend)
		{
			Send(new byte[1]
      {
        tosend
      });
		}

		private void CheckResult()
		{
			uint nNumberOfBytesTransferred = 0U;
			if (writeCount <= 0)
				return;
			if (Win32Com.GetOverlappedResult(hPort, ptrUWO, out nNumberOfBytesTransferred, checkSends))
			{
				if (!checkSends)
					return;
				writeCount -= (int)nNumberOfBytesTransferred;
				if (writeCount != 0)
					ThrowException("Send Timeout");
				writeCount = 0;
			}
			else
			{
				if ((long)Marshal.GetLastWin32Error() == 996L)
					return;
				ThrowException("Write Error");
			}
		}

		protected void SendImmediate(byte tosend)
		{
			CheckOnline();
			if (Win32Com.TransmitCommChar(hPort, tosend))
				return;
			ThrowException("Transmission failure");
		}

		protected void Sleep(int milliseconds)
		{
			Thread.Sleep(milliseconds);
		}

		protected CommBase.ModemStatus GetModemStatus()
		{
			CheckOnline();
			uint lpModemStat;
			if (!Win32Com.GetCommModemStatus(hPort, out lpModemStat))
				ThrowException("Unexpected failure");
			return new CommBase.ModemStatus(lpModemStat);
		}

		protected CommBase.QueueStatus GetQueueStatus()
		{
			CheckOnline();
			uint lpErrors;
			Win32Com.COMSTAT cs;
			if (!Win32Com.ClearCommError(hPort, out lpErrors, out cs))
				ThrowException("Unexpected failure");
			Win32Com.COMMPROP cp;
			if (!Win32Com.GetCommProperties(hPort, out cp))
				ThrowException("Unexpected failure");
			return new CommBase.QueueStatus(cs.Flags, cs.cbInQue, cs.cbOutQue, cp.dwCurrentRxQueue, cp.dwCurrentTxQueue);
		}

		protected bool IsCongested()
		{
			if (!dataQueued)
				return false;
			bool flag;
			lock (empty)
			{
				flag = empty[0];
				empty[0] = false;
			}
			dataQueued = false;
			return !flag;
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

		protected virtual void OnStatusChange(CommBase.ModemStatus mask, CommBase.ModemStatus state)
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
			uint num1 = 0U;
			IntPtr num2 = Marshal.AllocHGlobal(Marshal.SizeOf((object)overlapped));
			IntPtr num3 = Marshal.AllocHGlobal(Marshal.SizeOf((object)num1));
			overlapped.Offset = 0U;
			overlapped.OffsetHigh = 0U;
			overlapped.hEvent = autoResetEvent.Handle;
			Marshal.StructureToPtr((object)overlapped, num2, true);
			try
			{
				while (Win32Com.SetCommMask(hPort, 509U))
				{
					Marshal.WriteInt32(num3, 0);
					if (flag)
					{
						startEvent.Set();
						flag = false;
					}
					if (!Win32Com.WaitCommEvent(hPort, num3, num2))
					{
						if ((long)Marshal.GetLastWin32Error() != 997L)
							throw new CommPortException("IO Error [002]");
						autoResetEvent.WaitOne();
					}
					uint num4 = (uint)Marshal.ReadInt32(num3);
					if (((int)num4 & 128) != 0)
					{
						uint lpErrors;
						if (!Win32Com.ClearCommError(hPort, out lpErrors, IntPtr.Zero))
							throw new CommPortException("IO Error [003]");
						int num5 = 0;
						StringBuilder stringBuilder = new StringBuilder("UART Error: ", 40);
						if (((int)lpErrors & 8) != 0)
						{
							stringBuilder = stringBuilder.Append("Framing,");
							++num5;
						}
						if (((int)lpErrors & 1024) != 0)
						{
							stringBuilder = stringBuilder.Append("IO,");
							++num5;
						}
						if (((int)lpErrors & 2) != 0)
						{
							stringBuilder = stringBuilder.Append("Overrun,");
							++num5;
						}
						if (((int)lpErrors & 1) != 0)
						{
							stringBuilder = stringBuilder.Append("Receive Cverflow,");
							++num5;
						}
						if (((int)lpErrors & 4) != 0)
						{
							stringBuilder = stringBuilder.Append("Parity,");
							++num5;
						}
						if (((int)lpErrors & 256) != 0)
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
							if ((int)lpErrors != 16)
								throw new CommPortException("IO Error [003]");
							num4 |= 64U;
						}
					}
					if (((int)num4 & 1) != 0)
					{
						uint nNumberOfBytesRead;
						do
						{
							nNumberOfBytesRead = 0U;
							if (!Win32Com.ReadFile(hPort, lpBuffer, 1U, out nNumberOfBytesRead, num2))
							{
								Marshal.GetLastWin32Error();
								throw new CommPortException("IO Error [004]");
							}
							else if ((int)nNumberOfBytesRead == 1)
								OnRxChar(lpBuffer[0]);
						}
						while (nNumberOfBytesRead > 0U);
					}
					if (((int)num4 & 4) != 0)
					{
						lock (empty)
							empty[0] = true;
						OnTxDone();
					}
					if (((int)num4 & 64) != 0)
						OnBreak();
					uint val = 0U;
					if (((int)num4 & 8) != 0)
						val |= 16U;
					if (((int)num4 & 16) != 0)
						val |= 32U;
					if (((int)num4 & 32) != 0)
						val |= 128U;
					if (((int)num4 & 256) != 0)
						val |= 64U;
					if ((int)val != 0)
					{
						uint lpModemStat;
						if (!Win32Com.GetCommModemStatus(hPort, out lpModemStat))
							throw new CommPortException("IO Error [005]");
						OnStatusChange(new CommBase.ModemStatus(val), new CommBase.ModemStatus(lpModemStat));
					}
				}
				throw new CommPortException("IO Error [001]");
			}
			catch (Exception ex)
			{
				Win32Com.CancelIo(hPort);
				if (num3 != IntPtr.Zero)
					Marshal.FreeHGlobal(num3);
				if (num2 != IntPtr.Zero)
					Marshal.FreeHGlobal(num2);
				if (ex is ThreadAbortException)
					return;
				rxException = ex;
				OnRxException(ex);
			}
		}

		private bool CheckOnline()
		{
			if (rxException != null && !rxExceptionReported)
			{
				rxExceptionReported = true;
				ThrowException("rx");
			}
			if (online)
			{
				if (hPort != (IntPtr)(-1))
					return true;
				ThrowException("Offline");
				return false;
			}
			else
			{
				if (auto && Open())
					return true;
				ThrowException("Offline");
				return false;
			}
		}

		public enum Parity
		{
			none,
			odd,
			even,
			mark,
			space,
		}

		public enum StopBits
		{
			one,
			onePointFive,
			two,
		}

		public enum HSOutput
		{
			none,
			online,
			handshake,
			gate,
		}

		public enum Handshake
		{
			none,
			XonXoff,
			CtsRts,
			DsrDtr,
		}

		public class CommBaseSettings
		{
			public string port = "COM1:";
			public int baudRate = 2400;
			public CommBase.Parity parity = CommBase.Parity.none;
			public int dataBits = 8;
			public CommBase.StopBits stopBits = CommBase.StopBits.one;
			public bool txFlowCTS = false;
			public bool txFlowDSR = false;
			public bool txFlowX = false;
			public bool txWhenRxXoff = true;
			public bool rxGateDSR = false;
			public bool rxFlowX = false;
			public CommBase.HSOutput useRTS = CommBase.HSOutput.none;
			public CommBase.HSOutput useDTR = CommBase.HSOutput.none;
			public CommBase.ASCII XonChar = CommBase.ASCII.DC1;
			public CommBase.ASCII XoffChar = CommBase.ASCII.DC3;
			public int rxHighWater = 0;
			public int rxLowWater = 0;
			public uint sendTimeoutMultiplier = 0U;
			public uint sendTimeoutConstant = 0U;
			public int rxQueue = 0;
			public int txQueue = 0;
			public bool autoReopen = false;
			public bool checkAllSends = true;

			public void SetStandard(string Port, int Baud, CommBase.Handshake Hs)
			{
				dataBits = 8;
				stopBits = CommBase.StopBits.one;
				parity = CommBase.Parity.none;
				port = Port;
				baudRate = Baud;
				switch (Hs)
				{
					case CommBase.Handshake.none:
						txFlowCTS = false;
						txFlowDSR = false;
						txFlowX = false;
						rxFlowX = false;
						useRTS = CommBase.HSOutput.online;
						useDTR = CommBase.HSOutput.online;
						txWhenRxXoff = true;
						rxGateDSR = false;
						break;
					case CommBase.Handshake.XonXoff:
						txFlowCTS = false;
						txFlowDSR = false;
						txFlowX = true;
						rxFlowX = true;
						useRTS = CommBase.HSOutput.online;
						useDTR = CommBase.HSOutput.online;
						txWhenRxXoff = true;
						rxGateDSR = false;
						XonChar = CommBase.ASCII.DC1;
						XoffChar = CommBase.ASCII.DC3;
						break;
					case CommBase.Handshake.CtsRts:
						txFlowCTS = true;
						txFlowDSR = false;
						txFlowX = false;
						rxFlowX = false;
						useRTS = CommBase.HSOutput.handshake;
						useDTR = CommBase.HSOutput.online;
						txWhenRxXoff = true;
						rxGateDSR = false;
						break;
					case CommBase.Handshake.DsrDtr:
						txFlowCTS = false;
						txFlowDSR = true;
						txFlowX = false;
						rxFlowX = false;
						useRTS = CommBase.HSOutput.online;
						useDTR = CommBase.HSOutput.handshake;
						txWhenRxXoff = true;
						rxGateDSR = false;
						break;
				}
			}

			public void SaveAsXML(Stream s)
			{
				new XmlSerializer(GetType()).Serialize(s, (object)this);
			}

			public static CommBase.CommBaseSettings LoadFromXML(Stream s)
			{
				return CommBase.CommBaseSettings.LoadFromXML(s, typeof(CommBase.CommBaseSettings));
			}

			protected static CommBase.CommBaseSettings LoadFromXML(Stream s, Type t)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(t);
				try
				{
					return (CommBase.CommBaseSettings)xmlSerializer.Deserialize(s);
				}
				catch
				{
					return (CommBase.CommBaseSettings)null;
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
			DEL = (byte)127,
		}

		public enum PortStatus
		{
			absent = -1,
			unavailable = 0,
			available = 1,
		}

		public struct ModemStatus
		{
			private uint status;

			public bool cts
			{
				get
				{
					return ((int)status & 16) != 0;
				}
			}

			public bool dsr
			{
				get
				{
					return ((int)status & 32) != 0;
				}
			}

			public bool rlsd
			{
				get
				{
					return ((int)status & 128) != 0;
				}
			}

			public bool ring
			{
				get
				{
					return ((int)status & 64) != 0;
				}
			}

			internal ModemStatus(uint val)
			{
				status = val;
			}
		}

		public struct QueueStatus
		{
			private uint status;
			private uint inQueue;
			private uint outQueue;
			private uint inQueueSize;
			private uint outQueueSize;

			public bool ctsHold
			{
				get
				{
					return ((int)status & 1) != 0;
				}
			}

			public bool dsrHold
			{
				get
				{
					return ((int)status & 2) != 0;
				}
			}

			public bool rlsdHold
			{
				get
				{
					return ((int)status & 4) != 0;
				}
			}

			public bool xoffHold
			{
				get
				{
					return ((int)status & 8) != 0;
				}
			}

			public bool xoffSent
			{
				get
				{
					return ((int)status & 16) != 0;
				}
			}

			public bool immediateWaiting
			{
				get
				{
					return ((int)status & 64) != 0;
				}
			}

			public long InQueue
			{
				get
				{
					return (long)inQueue;
				}
			}

			public long OutQueue
			{
				get
				{
					return (long)outQueue;
				}
			}

			public long InQueueSize
			{
				get
				{
					return (long)inQueueSize;
				}
			}

			public long OutQueueSize
			{
				get
				{
					return (long)outQueueSize;
				}
			}

			internal QueueStatus(uint stat, uint inQ, uint outQ, uint inQs, uint outQs)
			{
				status = stat;
				inQueue = inQ;
				outQueue = outQ;
				inQueueSize = inQs;
				outQueueSize = outQs;
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder("The reception queue is ", 60);
				if ((int)inQueueSize == 0)
					stringBuilder.Append("of unknown size and ");
				else
					stringBuilder.Append(inQueueSize.ToString() + " bytes long and ");
				if ((int)inQueue == 0)
					stringBuilder.Append("is empty.");
				else if ((int)inQueue == 1)
				{
					stringBuilder.Append("contains 1 byte.");
				}
				else
				{
					stringBuilder.Append("contains ");
					stringBuilder.Append(inQueue.ToString());
					stringBuilder.Append(" bytes.");
				}
				stringBuilder.Append(" The transmission queue is ");
				if ((int)outQueueSize == 0)
					stringBuilder.Append("of unknown size and ");
				else
					stringBuilder.Append(outQueueSize.ToString() + " bytes long and ");
				if ((int)outQueue == 0)
					stringBuilder.Append("is empty");
				else if ((int)outQueue == 1)
				{
					stringBuilder.Append("contains 1 byte. It is ");
				}
				else
				{
					stringBuilder.Append("contains ");
					stringBuilder.Append(outQueue.ToString());
					stringBuilder.Append(" bytes. It is ");
				}
				if (outQueue > 0U)
				{
					if (ctsHold || dsrHold || (rlsdHold || xoffHold) || xoffSent)
					{
						stringBuilder.Append("holding on");
						if (ctsHold)
							stringBuilder.Append(" CTS");
						if (dsrHold)
							stringBuilder.Append(" DSR");
						if (rlsdHold)
							stringBuilder.Append(" RLSD");
						if (xoffHold)
							stringBuilder.Append(" Rx XOff");
						if (xoffSent)
							stringBuilder.Append(" Tx XOff");
					}
					else
						stringBuilder.Append("pumping data");
				}
				stringBuilder.Append(". The immediate buffer is ");
				if (immediateWaiting)
					stringBuilder.Append("full.");
				else
					stringBuilder.Append("empty.");
				return stringBuilder.ToString();
			}
		}
	}
}
