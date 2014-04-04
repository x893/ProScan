using Gauge;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class DashForm : Form
	{
		private Gauge.Gauge gauge1;
		private Gauge.Gauge gauge2;
		private Container components;

		public DashForm()
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
			gauge1 = new Gauge.Gauge();
			gauge2 = new Gauge.Gauge();
			SuspendLayout();
			// 
			// gauge1
			// 
			gauge1.BezelColor = System.Drawing.Color.SlateGray;
			gauge1.FaceColor = System.Drawing.Color.AntiqueWhite;
			gauge1.LabelColor = System.Drawing.Color.Black;
			gauge1.LabelFont = new System.Drawing.Font("Arial", 5.46F);
			gauge1.Location = new System.Drawing.Point(0, 192);
			gauge1.Name = "gauge1";
			gauge1.NeedleColor = System.Drawing.Color.Red;
			gauge1.NeedleSweepAngle = 225D;
			gauge1.RangeEnd = 7000D;
			gauge1.RangeStart = 0D;
			gauge1.Size = new System.Drawing.Size(200, 184);
			gauge1.TabIndex = 0;
			gauge1.TickColor = System.Drawing.Color.Black;
			gauge1.TickCount = 8;
			gauge1.TickLabelColor = System.Drawing.Color.Black;
			gauge1.TickLabelFont = new System.Drawing.Font("Arial", 7.28F);
			gauge1.Units = null;
			gauge1.Value = 0D;
			// 
			// gauge2
			// 
			gauge2.BezelColor = System.Drawing.Color.SlateGray;
			gauge2.FaceColor = System.Drawing.Color.AntiqueWhite;
			gauge2.LabelColor = System.Drawing.Color.Black;
			gauge2.LabelFont = new System.Drawing.Font("Arial", 5.22F);
			gauge2.Location = new System.Drawing.Point(8, 16);
			gauge2.Name = "gauge2";
			gauge2.NeedleColor = System.Drawing.Color.Red;
			gauge2.NeedleSweepAngle = 225D;
			gauge2.RangeEnd = 7000D;
			gauge2.RangeStart = 0D;
			gauge2.Size = new System.Drawing.Size(192, 176);
			gauge2.TabIndex = 1;
			gauge2.TickColor = System.Drawing.Color.Black;
			gauge2.TickCount = 8;
			gauge2.TickLabelColor = System.Drawing.Color.Black;
			gauge2.TickLabelFont = new System.Drawing.Font("Arial", 6.96F);
			gauge2.Units = null;
			gauge2.Value = 0D;
			// 
			// DashForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(672, 413);
			ControlBox = false;
			Controls.Add(gauge2);
			Controls.Add(gauge1);
			Name = "DashForm";
			Text = "Dashboard";
			ResumeLayout(false);

		}
	}
}