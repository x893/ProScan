using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class DiagnosticReportHeader : Form
	{
		private Container components;

		public DiagnosticReportHeader()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			// 
			// DiagnosticReportHeader
			// 
			ClientSize = new System.Drawing.Size(284, 261);
			Name = "DiagnosticReportHeader";
			Tag = "";
			Text = "DiagnosticReportHeader";
			ResumeLayout(false);

		}
	}
}