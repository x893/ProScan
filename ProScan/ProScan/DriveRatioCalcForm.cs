using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class DriveRatioCalcForm : Form
	{
		private GroupBox groupInstructions;
		private Label label1;
		private Label label2;
		private Label label3;
		private Button btnStart;
		private GroupBox groupDriveRatio;
		private Label lblRatio;
		private OBD2Interface m_obd2Interface;
		private ProgressBar progressBar;
		private Container components;

		public DriveRatioCalcForm(OBD2Interface obd2)
		{
			m_obd2Interface = obd2;
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
			groupInstructions = new System.Windows.Forms.GroupBox();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnStart = new System.Windows.Forms.Button();
			groupDriveRatio = new System.Windows.Forms.GroupBox();
			lblRatio = new System.Windows.Forms.Label();
			progressBar = new System.Windows.Forms.ProgressBar();
			groupInstructions.SuspendLayout();
			groupDriveRatio.SuspendLayout();
			SuspendLayout();
			// 
			// groupInstructions
			// 
			groupInstructions.Controls.Add(label3);
			groupInstructions.Controls.Add(label2);
			groupInstructions.Controls.Add(label1);
			groupInstructions.Location = new System.Drawing.Point(10, 10);
			groupInstructions.Name = "groupInstructions";
			groupInstructions.Size = new System.Drawing.Size(275, 160);
			groupInstructions.TabIndex = 0;
			groupInstructions.TabStop = false;
			groupInstructions.Text = "Instructions";
			// 
			// label3
			// 
			label3.Location = new System.Drawing.Point(10, 110);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(250, 42);
			label3.TabIndex = 2;
			label3.Text = "The calculated drive ratio will display once it has been calculated. ";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(10, 60);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(250, 50);
			label2.TabIndex = 1;
			label2.Text = "While driving in the desired gear, hit the Start button to begin. Make certain th" +
    "at you keep the vehicle in the same gear while calculating.";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(10, 20);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(250, 40);
			label1.TabIndex = 0;
			label1.Text = "This will calculate your vehicle\'s drive ratio for a specific transmission gear.";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnStart
			// 
			btnStart.Location = new System.Drawing.Point(300, 20);
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(150, 23);
			btnStart.TabIndex = 1;
			btnStart.Text = "&Start";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			// 
			// groupDriveRatio
			// 
			groupDriveRatio.Controls.Add(lblRatio);
			groupDriveRatio.Location = new System.Drawing.Point(300, 88);
			groupDriveRatio.Name = "groupDriveRatio";
			groupDriveRatio.Size = new System.Drawing.Size(150, 80);
			groupDriveRatio.TabIndex = 2;
			groupDriveRatio.TabStop = false;
			groupDriveRatio.Text = "Calculated Drive Ratio";
			// 
			// lblRatio
			// 
			lblRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblRatio.ForeColor = System.Drawing.Color.Blue;
			lblRatio.Location = new System.Drawing.Point(8, 17);
			lblRatio.Name = "lblRatio";
			lblRatio.Size = new System.Drawing.Size(136, 56);
			lblRatio.TabIndex = 0;
			lblRatio.Text = "0.000000";
			lblRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBar
			// 
			progressBar.Location = new System.Drawing.Point(300, 55);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(150, 20);
			progressBar.TabIndex = 3;
			// 
			// DriveRatioCalcForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(464, 182);
			Controls.Add(progressBar);
			Controls.Add(groupDriveRatio);
			Controls.Add(btnStart);
			Controls.Add(groupInstructions);
			Name = "DriveRatioCalcForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Drive Ratio Calculator";
			groupInstructions.ResumeLayout(false);
			groupDriveRatio.ResumeLayout(false);
			ResumeLayout(false);

		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			double value = 0.0;
			int valid = 0;
			if (!m_obd2Interface.Connected)
			{
				MessageBox.Show("A vehicle connection must first be established. \n\n" + "Please enable communications and check all wiring connections.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				int count = 0;
				do
				{
					OBD2Response response1 = m_obd2Interface.getResponse(new OBD2Request("010D"));
					OBD2Response response2 = m_obd2Interface.getResponse(new OBD2Request("010C"));
					OBD2Response response3 = m_obd2Interface.getResponse(new OBD2Request("010D"));
					if (response1 != null && response2 != null && response3 != null)
					{
						double value1 = response1.getValue(0).MetricValue;
						double value2 = response3.getValue(0).MetricValue;
						double value3 = response2.getValue(0).MetricValue;
						double totalSeconds = response2.Date.Subtract(response1.Date).TotalSeconds;
						TimeSpan timeSpan = response3.Date.Subtract(response1.Date);
						value = (totalSeconds / timeSpan.TotalSeconds * (value2 - value1) + value1) / value3 + value;
						++valid;
					}
					progressBar.Value = count;
					count += 5;
				}
				while (count < 100);
				lblRatio.Text = (value / (double)valid).ToString("0.000000");
			}
		}
	}
}