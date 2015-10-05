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
		private int m_FrameNumber;
		private bool m_KeepReading;

		public FreezeFramesForm(OBDInterface obd)
		{
			InitializeComponent();
			m_obdInterface = obd;
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

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.numFrame = new System.Windows.Forms.NumericUpDown();
			this.lblFrameNumber = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.panel = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.freezeFrame = new ProScan.FreezeFrameDataControl();
			((System.ComponentModel.ISupportInitialize)(this.numFrame)).BeginInit();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// numFrame
			// 
			this.numFrame.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.numFrame.Location = new System.Drawing.Point(301, 12);
			this.numFrame.Name = "numFrame";
			this.numFrame.Size = new System.Drawing.Size(96, 22);
			this.numFrame.TabIndex = 0;
			this.numFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblFrameNumber
			// 
			this.lblFrameNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblFrameNumber.Location = new System.Drawing.Point(187, 12);
			this.lblFrameNumber.Name = "lblFrameNumber";
			this.lblFrameNumber.Size = new System.Drawing.Size(102, 23);
			this.lblFrameNumber.TabIndex = 1;
			this.lblFrameNumber.Text = "Frame Number:";
			this.lblFrameNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRefresh.Location = new System.Drawing.Point(409, 12);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(102, 23);
			this.btnRefresh.TabIndex = 2;
			this.btnRefresh.Text = "&Read";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(6, 46);
			this.progressBar.Maximum = 12;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(801, 27);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 5;
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.freezeFrame);
			this.panel.Location = new System.Drawing.Point(6, 79);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(801, 417);
			this.panel.TabIndex = 6;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnCancel.Enabled = false;
			this.btnCancel.Location = new System.Drawing.Point(523, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(102, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// freezeFrame
			// 
			this.freezeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.freezeFrame.DTC = "-";
			this.freezeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.freezeFrame.FuelSystem1Status = "-";
			this.freezeFrame.FuelSystem2Status = "-";
			this.freezeFrame.Location = new System.Drawing.Point(0, 0);
			this.freezeFrame.Name = "freezeFrame";
			this.freezeFrame.Size = new System.Drawing.Size(801, 414);
			this.freezeFrame.TabIndex = 4;
			// 
			// FreezeFramesForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(812, 508);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.lblFrameNumber);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.numFrame);
			this.Controls.Add(this.panel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FreezeFramesForm";
			this.Text = "Freeze Frame Data";
			((System.ComponentModel.ISupportInitialize)(this.numFrame)).EndInit();
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			if (m_obdInterface.ConnectedStatus)
			{
				btnRefresh.Enabled = false;
				btnCancel.Enabled = true;
				m_KeepReading = true;
				m_FrameNumber = Convert.ToInt32(numFrame.Value);
				ThreadPool.QueueUserWorkItem(new WaitCallback(ReadFreezeFrameData));
			}
			else
			{
				MessageBox.Show(
					"A vehicle connection must first be established.",
					"Connection Required",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation
					);
				m_obdInterface.logItem("Error. Freeze Frame Form. Attempted to refresh without vehicle connection.");
			}
		}

		private void ReadFreezeFrameData(object state)
		{
			for (; ; )
			{
				freezeFrame.Reset();
				OBDParameter parameter = m_obdInterface.LookupParameter("SAE.FF_DTC");
				if (parameter == null)
				{
					MessageBox.Show(
						"An error was encountered while requesting SAE.FF_DTC",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Hand
						);
					break;
				}

				OBDParameterValue value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (value.ErrorDetected)
				{
					MessageBox.Show(
						"An error was encountered while requesting SAE.FF_DTC",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Hand
						);
					m_obdInterface.logItem("Error while requesting SAE.FF_DTC");
					break;
				}

				if (string.Compare(value.StringValue, "P0000") == 0)
				{
					MessageBox.Show(
						string.Format("No freeze frame information found at frame #{0}.", m_FrameNumber),
						"Information",
						MessageBoxButtons.OK,
						MessageBoxIcon.Asterisk
						);
					break;
				}

				progressBar.Value = 0;
				freezeFrame.DTC = value.StringValue;

				parameter = m_obdInterface.LookupParameter("SAE.FUEL1_STATUS");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.FuelSystem1Status = value.StringValue;

				parameter = m_obdInterface.LookupParameter("SAE.FUEL2_STATUS");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.FuelSystem2Status = value.StringValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.LOAD_CALC");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.CalculatedLoad = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.ECT");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.EngineCoolantTemp = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.STFT1");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.STFT1 = value.DoubleValue;

				parameter = m_obdInterface.LookupParameter("SAE.STFT3");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.STFT3 = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.LTFT1");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.LTFT1 = value.DoubleValue;

				parameter = m_obdInterface.LookupParameter("SAE.LTFT3");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.LTFT3 = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.STFT2");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.STFT2 = value.DoubleValue;

				parameter = m_obdInterface.LookupParameter("SAE.STFT4");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.STFT4 = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.LTFT2");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.LTFT2 = value.DoubleValue;

				parameter = m_obdInterface.LookupParameter("SAE.LTFT4");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.LTFT4 = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.MAP");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.IntakePressure = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.RPM");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.EngineRPM = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.VSS");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.VehicleSpeed = value.DoubleValue;

				progressBar.Increment(progressBar.Step);
				if (!m_KeepReading)
					break;

				parameter = m_obdInterface.LookupParameter("SAE.SPARKADV");
				if (parameter == null)
					break;

				value = m_obdInterface.getValue(parameter.GetFreezeFrameCopy(m_FrameNumber), true);
				if (!value.ErrorDetected)
					freezeFrame.SparkAdvance = value.DoubleValue;

				break;
			}
			progressBar.Value = progressBar.Maximum;
			btnRefresh.Enabled = true;
			btnCancel.Enabled = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			m_KeepReading = false;
			btnRefresh.Enabled = true;
			btnCancel.Enabled = false;
		}
	}
}