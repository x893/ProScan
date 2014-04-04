using System;
using System.Runtime.InteropServices;

namespace ProScan
{
	internal class Win32Com
	{
		internal const uint ERROR_FILE_NOT_FOUND = 2U;
		internal const uint ERROR_INVALID_NAME = 123U;
		internal const uint ERROR_ACCESS_DENIED = 5U;
		internal const uint ERROR_IO_PENDING = 997U;
		internal const uint ERROR_IO_INCOMPLETE = 996U;
		internal const int INVALID_HANDLE_VALUE = -1;
		internal const uint FILE_FLAG_OVERLAPPED = 1073741824U;
		internal const uint OPEN_EXISTING = 3U;
		internal const uint GENERIC_READ = 2147483648U;
		internal const uint GENERIC_WRITE = 1073741824U;
		internal const uint MAXDWORD = 4294967295U;
		internal const uint EV_RXCHAR = 1U;
		internal const uint EV_RXFLAG = 2U;
		internal const uint EV_TXEMPTY = 4U;
		internal const uint EV_CTS = 8U;
		internal const uint EV_DSR = 16U;
		internal const uint EV_RLSD = 32U;
		internal const uint EV_BREAK = 64U;
		internal const uint EV_ERR = 128U;
		internal const uint EV_RING = 256U;
		internal const uint EV_PERR = 512U;
		internal const uint EV_RX80FULL = 1024U;
		internal const uint EV_EVENT1 = 2048U;
		internal const uint EV_EVENT2 = 4096U;
		internal const uint SETXOFF = 1U;
		internal const uint SETXON = 2U;
		internal const uint SETRTS = 3U;
		internal const uint CLRRTS = 4U;
		internal const uint SETDTR = 5U;
		internal const uint CLRDTR = 6U;
		internal const uint RESETDEV = 7U;
		internal const uint SETBREAK = 8U;
		internal const uint CLRBREAK = 9U;
		internal const uint MS_CTS_ON = 16U;
		internal const uint MS_DSR_ON = 32U;
		internal const uint MS_RING_ON = 64U;
		internal const uint MS_RLSD_ON = 128U;
		internal const uint CE_RXOVER = 1U;
		internal const uint CE_OVERRUN = 2U;
		internal const uint CE_RXPARITY = 4U;
		internal const uint CE_FRAME = 8U;
		internal const uint CE_BREAK = 16U;
		internal const uint CE_TXFULL = 256U;
		internal const uint CE_PTO = 512U;
		internal const uint CE_IOE = 1024U;
		internal const uint CE_DNS = 2048U;
		internal const uint CE_OOP = 4096U;
		internal const uint CE_MODE = 32768U;

		[DllImport("kernel32.dll", SetLastError = true)]
		extern internal static IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("kernel32.dll")]
		extern internal static bool CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll")]
		extern internal static bool GetCommState(IntPtr hFile, ref Win32Com.DCB lpDCB);

		[DllImport("kernel32.dll")]
		extern internal static bool GetCommTimeouts(IntPtr hFile, out Win32Com.COMMTIMEOUTS lpCommTimeouts);

		[DllImport("kernel32.dll")]
		extern internal static bool BuildCommDCBAndTimeouts(string lpDef, ref Win32Com.DCB lpDCB, ref Win32Com.COMMTIMEOUTS lpCommTimeouts);

		[DllImport("kernel32.dll")]
		extern internal static bool SetCommState(IntPtr hFile, [In] ref Win32Com.DCB lpDCB);

		[DllImport("kernel32.dll")]
		extern internal static bool SetCommTimeouts(IntPtr hFile, [In] ref Win32Com.COMMTIMEOUTS lpCommTimeouts);

		[DllImport("kernel32.dll")]
		extern internal static bool SetupComm(IntPtr hFile, uint dwInQueue, uint dwOutQueue);

		[DllImport("kernel32.dll", SetLastError = true)]
		extern internal static bool WriteFile(IntPtr fFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

		[DllImport("kernel32.dll")]
		extern internal static bool SetCommMask(IntPtr hFile, uint dwEvtMask);

		[DllImport("kernel32.dll", SetLastError = true)]
		extern internal static bool WaitCommEvent(IntPtr hFile, IntPtr lpEvtMask, IntPtr lpOverlapped);

		[DllImport("kernel32.dll")]
		extern internal static bool CancelIo(IntPtr hFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		extern internal static bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, out uint nNumberOfBytesRead, IntPtr lpOverlapped);

		[DllImport("kernel32.dll")]
		extern internal static bool TransmitCommChar(IntPtr hFile, byte cChar);

		[DllImport("kernel32.dll")]
		extern internal static bool EscapeCommFunction(IntPtr hFile, uint dwFunc);

		[DllImport("kernel32.dll")]
		extern internal static bool GetCommModemStatus(IntPtr hFile, out uint lpModemStat);

		[DllImport("kernel32.dll", SetLastError = true)]
		extern internal static bool GetOverlappedResult(IntPtr hFile, IntPtr lpOverlapped, out uint nNumberOfBytesTransferred, bool bWait);

		[DllImport("kernel32.dll")]
		extern internal static bool ClearCommError(IntPtr hFile, out uint lpErrors, IntPtr lpStat);

		[DllImport("kernel32.dll")]
		extern internal static bool ClearCommError(IntPtr hFile, out uint lpErrors, out Win32Com.COMSTAT cs);

		[DllImport("kernel32.dll")]
		extern internal static bool GetCommProperties(IntPtr hFile, out Win32Com.COMMPROP cp);

		internal struct COMMTIMEOUTS
		{
			internal uint ReadIntervalTimeout;
			internal uint ReadTotalTimeoutMultiplier;
			internal uint ReadTotalTimeoutConstant;
			internal uint WriteTotalTimeoutMultiplier;
			internal uint WriteTotalTimeoutConstant;
		}

		internal struct DCB
		{
			internal int DCBlength;
			internal int BaudRate;
			internal int PackedValues;
			internal short wReserved;
			internal short XonLim;
			internal short XoffLim;
			internal byte ByteSize;
			internal byte Parity;
			internal byte StopBits;
			internal byte XonChar;
			internal byte XoffChar;
			internal byte ErrorChar;
			internal byte EofChar;
			internal byte EvtChar;
			internal short wReserved1;

			internal void init(bool parity, bool outCTS, bool outDSR, int dtr, bool inDSR, bool txc, bool xOut, bool xIn, int rts)
			{
				this.DCBlength = 28;
				this.PackedValues = 16385;
				if (parity)
					this.PackedValues |= 2;
				if (outCTS)
					this.PackedValues |= 4;
				if (outDSR)
					this.PackedValues |= 8;
				this.PackedValues |= (dtr & 3) << 4;
				if (inDSR)
					this.PackedValues |= 64;
				if (txc)
					this.PackedValues |= 128;
				if (xOut)
					this.PackedValues |= 256;
				if (xIn)
					this.PackedValues |= 512;
				this.PackedValues |= (rts & 3) << 12;
			}
		}

		internal struct OVERLAPPED
		{
			internal UIntPtr Internal;
			internal UIntPtr InternalHigh;
			internal uint Offset;
			internal uint OffsetHigh;
			internal IntPtr hEvent;
		}

		internal struct COMSTAT
		{
			internal const uint fCtsHold = 1U;
			internal const uint fDsrHold = 2U;
			internal const uint fRlsdHold = 4U;
			internal const uint fXoffHold = 8U;
			internal const uint fXoffSent = 16U;
			internal const uint fEof = 32U;
			internal const uint fTxim = 64U;
			internal uint Flags;
			internal uint cbInQue;
			internal uint cbOutQue;
		}

		internal struct COMMPROP
		{
			internal ushort wPacketLength;
			internal ushort wPacketVersion;
			internal uint dwServiceMask;
			internal uint dwReserved1;
			internal uint dwMaxTxQueue;
			internal uint dwMaxRxQueue;
			internal uint dwMaxBaud;
			internal uint dwProvSubType;
			internal uint dwProvCapabilities;
			internal uint dwSettableParams;
			internal uint dwSettableBaud;
			internal ushort wSettableData;
			internal ushort wSettableStopParity;
			internal uint dwCurrentTxQueue;
			internal uint dwCurrentRxQueue;
			internal uint dwProvSpec1;
			internal uint dwProvSpec2;
			internal byte wcProvChar;
		}
	}
}
