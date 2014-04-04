using System;
using System.Windows.Forms;

namespace ProScan
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			Application.Run((Form)new MainForm());
		}
	}
}