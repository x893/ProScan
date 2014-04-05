using System;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class RichTextBoxPrintCtrl : RichTextBox
	{
		private const double anInch = 14.4;
		private const int WM_USER = 1024;
		private const int EM_FORMATRANGE = 1081;

		[DllImport("user32.dll")]
		extern static IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

		public int Print(int charFrom, int charTo, PrintPageEventArgs e)
		{
			RichTextBoxPrintCtrl.RECT rect1;
			rect1.Top = (int)((double)e.MarginBounds.Top * 14.4);
			rect1.Bottom = (int)((double)e.MarginBounds.Bottom * 14.4);
			rect1.Left = (int)((double)e.MarginBounds.Left * 14.4);
			rect1.Right = (int)((double)e.MarginBounds.Right * 14.4);
			RichTextBoxPrintCtrl.RECT rect2;
			rect2.Top = (int)((double)e.PageBounds.Top * 14.4);
			rect2.Bottom = (int)((double)e.PageBounds.Bottom * 14.4);
			rect2.Left = (int)((double)e.PageBounds.Left * 14.4);
			rect2.Right = (int)((double)e.PageBounds.Right * 14.4);
			IntPtr hdc = e.Graphics.GetHdc();
			RichTextBoxPrintCtrl.FORMATRANGE formatrange;
			formatrange.chrg.cpMax = charTo;
			formatrange.chrg.cpMin = charFrom;
			formatrange.hdc = hdc;
			formatrange.hdcTarget = hdc;
			formatrange.rc = rect1;
			formatrange.rcPage = rect2;
			IntPtr num1 = IntPtr.Zero;
			IntPtr wp = IntPtr.Zero;
			wp = new IntPtr(1);
			IntPtr num2 = IntPtr.Zero;
			IntPtr num3 = Marshal.AllocCoTaskMem(Marshal.SizeOf((object)formatrange));
			Marshal.StructureToPtr((object)formatrange, num3, false);
			IntPtr num4 = RichTextBoxPrintCtrl.SendMessage(this.Handle, 1081, wp, num3);
			Marshal.FreeCoTaskMem(num3);
			e.Graphics.ReleaseHdc(hdc);
			return num4.ToInt32();
		}

		private struct RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

		private struct CHARRANGE
		{
			public int cpMin;
			public int cpMax;
		}

		private struct FORMATRANGE
		{
			public IntPtr hdc;
			public IntPtr hdcTarget;
			public RichTextBoxPrintCtrl.RECT rc;
			public RichTextBoxPrintCtrl.RECT rcPage;
			public RichTextBoxPrintCtrl.CHARRANGE chrg;
		}
	}
}