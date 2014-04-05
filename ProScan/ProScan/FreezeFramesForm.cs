using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ProScan
{
	public class FreezeFramesForm : Form
	{
		private int m_iFrameNumber;
		private bool m_bKeepReading;

		public FreezeFramesForm(OBDInterface obd2)
		{
			InitializeComponent();
			m_obdInterface = obd2;
		}

		#region InitializeComponent()

		private NumericUpDown numFrame;
		private Button btnRefresh;
		private Label lblFrameNumber;
		private FreezeFrameDataControl freezeFrame;
		private OBDInterface m_obdInterface;
		private ProgressBar progressBar;
		private Panel panel;
		private Button btnCancel;
		private Container components;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			numFrame = new System.Windows.Forms.NumericUpDown();
			lblFrameNumber = new System.Windows.Forms.Label();
			btnRefresh = new System.Windows.Forms.Button();
			freezeFrame = new FreezeFrameDataControl();
			progressBar = new System.Windows.Forms.ProgressBar();
			panel = new System.Windows.Forms.Panel();
			btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(numFrame)).BeginInit();
			panel.SuspendLayout();
			SuspendLayout();
			// 
			// numFrame
			// 
			numFrame.Anchor = System.Windows.Forms.AnchorStyles.Top;
			numFrame.Location = new System.Drawing.Point(167, 10);
			numFrame.Name = "numFrame";
			numFrame.Size = new System.Drawing.Size(80, 20);
			numFrame.TabIndex = 0;
			numFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblFrameNumber
			// 
			lblFrameNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
			lblFrameNumber.Location = new System.Drawing.Point(72, 10);
			lblFrameNumber.Name = "lblFrameNumber";
			lblFrameNumber.Size = new System.Drawing.Size(85, 20);
			lblFrameNumber.TabIndex = 1;
			lblFrameNumber.Text = "Frame Number:";
			lblFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRefresh
			// 
			btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnRefresh.Location = new System.Drawing.Point(257, 10);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new System.Drawing.Size(85, 20);
			btnRefresh.TabIndex = 2;
			btnRefresh.Text = "&Read";
			btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
			// 
			// freezeFrame
			// 
			freezeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			freezeFrame.DTC = "-";
			freezeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			freezeFrame.FuelSystem1Status = "-";
			freezeFrame.FuelSystem2Status = "-";
			freezeFrame.Location = new System.Drawing.Point(0, 0);
			freezeFrame.Name = "freezeFrame";
			freezeFrame.Size = new System.Drawing.Size(500, 343);
			freezeFrame.TabIndex = 4;
			// 
			// progressBar
			// 
			progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			progressBar.Location = new System.Drawing.Point(5, 40);
			progressBar.Maximum = 12;
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(500, 23);
			progressBar.Step = 1;
			progressBar.TabIndex = 5;
			// 
			// panel
			// 
			panel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			panel.AutoScroll = true;
			panel.Controls.Add(freezeFrame);
			panel.Location = new System.Drawing.Point(5, 74);
			panel.Name = "panel";
			panel.Size = new System.Drawing.Size(500, 343);
			panel.TabIndex = 6;
			// 
			// btnCancel
			// 
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnCancel.Enabled = false;
			btnCancel.Location = new System.Drawing.Point(352, 10);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(85, 20);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "&Cancel";
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			// 
			// FreezeFramesForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(509, 422);
			ControlBox = false;
			Controls.Add(btnCancel);
			Controls.Add(progressBar);
			Controls.Add(lblFrameNumber);
			Controls.Add(btnRefresh);
			Controls.Add(numFrame);
			Controls.Add(panel);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Name = "FreezeFramesForm";
			Text = "Freeze Frame Data";
			((System.ComponentModel.ISupportInitialize)(numFrame)).EndInit();
			panel.ResumeLayout(false);
			ResumeLayout(false);

		}
		#endregion

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				m_obdInterface.logItem("Error. Freeze Frame Form. Attempted to refresh without vehicle connection.");
			}
			else
			{
				btnRefresh.Enabled = false;
				btnCancel.Enabled = true;
				m_bKeepReading = true;
				m_iFrameNumber = int.Parse(numFrame.Value.ToString());
				ThreadPool.QueueUserWorkItem(new WaitCallback(ReadFreezeFrameData));
			}
		}

		private void ReadFreezeFrameData(object state)
		{
			freezeFrame.Reset();
			progressBar.Value = 0;
			OBDParameter parameter = m_obdInterface.lookupParameter("SAE.FF_DTC");
			if (parameter != null)
			{
				OBDParameter freezeFrameCopy = parameter.GetFreezeFrameCopy(m_iFrameNumber);
				OBDParameterValue value2 = m_obdInterface.getValue(freezeFrameCopy, true);
				if (value2.ErrorDetected)
				{
					MessageBox.Show("An error was encountered while requesting SAE.FF_DTC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					m_obdInterface.logItem("Error while requesting SAE.FF_DTC");
					progressBar.Value = progressBar.Maximum;
				}
				else
				{
					bool flag = false;
					if (string.Compare(value2.StringValue, "P0000") != 0)
					{
						freezeFrame.DTC = value2.StringValue;
						flag = true;
					}
					progressBar.Increment(progressBar.Step);
					if (m_bKeepReading)
					{
						if (flag)
						{
							parameter = m_obdInterface.lookupParameter("SAE.FUEL1_STATUS");
							if (parameter == null)
							{
								return;
							}
							OBDParameter param = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value17 = m_obdInterface.getValue(param, true);
							if (!value17.ErrorDetected)
							{
								freezeFrame.FuelSystem1Status = value17.StringValue;
							}
							parameter = m_obdInterface.lookupParameter("SAE.FUEL2_STATUS");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter16 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value16 = m_obdInterface.getValue(parameter16, true);
							if (!value16.ErrorDetected)
							{
								freezeFrame.FuelSystem2Status = value16.StringValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.LOAD_CALC");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter15 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value15 = m_obdInterface.getValue(parameter15, true);
							if (!value15.ErrorDetected)
							{
								freezeFrame.CalculatedLoad = value15.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.ECT");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter14 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value14 = m_obdInterface.getValue(parameter14, true);
							if (!value14.ErrorDetected)
							{
								freezeFrame.EngineCoolantTemp = value14.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.STFT1");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter13 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value13 = m_obdInterface.getValue(parameter13, true);
							if (!value13.ErrorDetected)
							{
								freezeFrame.STFT1 = value13.DoubleValue;
							}
							parameter = m_obdInterface.lookupParameter("SAE.STFT3");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter12 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value12 = m_obdInterface.getValue(parameter12, true);
							if (!value12.ErrorDetected)
							{
								freezeFrame.STFT3 = value12.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.LTFT1");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter11 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value11 = m_obdInterface.getValue(parameter11, true);
							if (!value11.ErrorDetected)
							{
								freezeFrame.LTFT1 = value11.DoubleValue;
							}
							parameter = m_obdInterface.lookupParameter("SAE.LTFT3");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter10 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value10 = m_obdInterface.getValue(parameter10, true);
							if (!value10.ErrorDetected)
							{
								freezeFrame.LTFT3 = value10.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.STFT2");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter9 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value9 = m_obdInterface.getValue(parameter9, true);
							if (!value9.ErrorDetected)
							{
								freezeFrame.STFT2 = value9.DoubleValue;
							}
							parameter = m_obdInterface.lookupParameter("SAE.STFT4");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter8 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value8 = m_obdInterface.getValue(parameter8, true);
							if (!value8.ErrorDetected)
							{
								freezeFrame.STFT4 = value8.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.LTFT2");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter7 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value7 = m_obdInterface.getValue(parameter7, true);
							if (!value7.ErrorDetected)
							{
								freezeFrame.LTFT2 = value7.DoubleValue;
							}
							parameter = m_obdInterface.lookupParameter("SAE.LTFT4");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter6 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value6 = m_obdInterface.getValue(parameter6, true);
							if (!value6.ErrorDetected)
							{
								freezeFrame.LTFT4 = value6.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.MAP");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter5 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value5 = m_obdInterface.getValue(parameter5, true);
							if (!value5.ErrorDetected)
							{
								freezeFrame.IntakePressure = value5.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.RPM");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter4 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value4 = m_obdInterface.getValue(parameter4, true);
							if (!value4.ErrorDetected)
							{
								freezeFrame.EngineRPM = value4.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.VSS");
							if (parameter == null)
							{
								return;
							}
							OBDParameter parameter3 = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							OBDParameterValue value3 = m_obdInterface.getValue(parameter3, true);
							if (!value3.ErrorDetected)
							{
								freezeFrame.VehicleSpeed = value3.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
							if (!m_bKeepReading)
							{
								return;
							}
							parameter = m_obdInterface.lookupParameter("SAE.SPARKADV");
							if (parameter == null)
							{
								return;
							}
							freezeFrameCopy = parameter.GetFreezeFrameCopy(m_iFrameNumber);
							value2 = m_obdInterface.getValue(freezeFrameCopy, true);
							if (!value2.ErrorDetected)
							{
								freezeFrame.SparkAdvance = value2.DoubleValue;
							}
							progressBar.Increment(progressBar.Step);
						}
						else
						{
							MessageBox.Show(string.Format("No freeze frame information found at frame #{0}.", m_iFrameNumber), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						progressBar.Value = progressBar.Maximum;
						btnRefresh.Enabled = true;
						btnCancel.Enabled = false;
					}
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			m_bKeepReading = false;
			btnRefresh.Enabled = true;
			btnCancel.Enabled = false;
		}
	}
}