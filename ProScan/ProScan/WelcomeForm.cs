using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class WelcomeForm : Form
	{
		private PictureBox picProscanLogo;
		private PictureBox picDiagram;
		private OBD2Interface m_obd2Interface;
		private Container components;

		public WelcomeForm(OBD2Interface obd2)
		{
			InitializeComponent();
			m_obd2Interface = obd2;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			picProscanLogo = new System.Windows.Forms.PictureBox();
			picDiagram = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(picProscanLogo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(picDiagram)).BeginInit();
			SuspendLayout();
			// 
			// picProscanLogo
			// 
			picProscanLogo.Location = new System.Drawing.Point(0, 488);
			picProscanLogo.Name = "picProscanLogo";
			picProscanLogo.Size = new System.Drawing.Size(300, 72);
			picProscanLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			picProscanLogo.TabIndex = 1;
			picProscanLogo.TabStop = false;
			// 
			// picDiagram
			// 
			picDiagram.Location = new System.Drawing.Point(160, 50);
			picDiagram.Name = "picDiagram";
			picDiagram.Size = new System.Drawing.Size(430, 328);
			picDiagram.TabIndex = 2;
			picDiagram.TabStop = false;
			// 
			// WelcomeForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(792, 566);
			ControlBox = false;
			Controls.Add(picDiagram);
			Controls.Add(picProscanLogo);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "WelcomeForm";
			Text = "Welcome";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			Resize += new System.EventHandler(WelcomeForm_Resize);
			((System.ComponentModel.ISupportInitialize)(picProscanLogo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(picDiagram)).EndInit();
			ResumeLayout(false);

		}

		private void WelcomeForm_Resize(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Maximized;
			picProscanLogo.Location = new Point(5, Height - 110);
			picDiagram.Location = new Point((Width - picDiagram.Width) / 2, 50);
		}

		public void CheckConnection()
		{
		}
	}
}