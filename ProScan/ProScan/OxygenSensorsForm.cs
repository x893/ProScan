using O2Waveform;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class OxygenSensorsForm : Form
	{
		public OxygenSensorsForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
		}

		public new void Update()
		{
			if (!m_obdInterface.ConnectedStatus)
				return;
			PopulateO2Locations();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region InitializeComponent()
		private O2TestResultsControl o2TestResultsControl1;
		private O2WaveformControl o2WaveformControl1;
		private Label lblOxygenSensor;
		private ComboBox comboOxygenSensor;
		private Button btnRead;
		private OBDInterface m_obdInterface;
		private ProgressBar progressBar;

		private void InitializeComponent()
		{
			this.o2TestResultsControl1 = new ProScan.O2TestResultsControl();
			this.o2WaveformControl1 = new O2Waveform.O2WaveformControl();
			this.lblOxygenSensor = new System.Windows.Forms.Label();
			this.comboOxygenSensor = new System.Windows.Forms.ComboBox();
			this.btnRead = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// o2TestResultsControl1
			// 
			this.o2TestResultsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.o2TestResultsControl1.Location = new System.Drawing.Point(10, 46);
			this.o2TestResultsControl1.Name = "o2TestResultsControl1";
			this.o2TestResultsControl1.Size = new System.Drawing.Size(615, 242);
			this.o2TestResultsControl1.TabIndex = 0;
			// 
			// o2WaveformControl1
			// 
			this.o2WaveformControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.o2WaveformControl1.LabelColor = System.Drawing.Color.Yellow;
			this.o2WaveformControl1.LabelFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.o2WaveformControl1.LeanBGColor = System.Drawing.Color.Black;
			this.o2WaveformControl1.LineColor = System.Drawing.Color.White;
			this.o2WaveformControl1.Location = new System.Drawing.Point(10, 295);
			this.o2WaveformControl1.MidBGColor = System.Drawing.Color.Gray;
			this.o2WaveformControl1.Name = "o2WaveformControl1";
			this.o2WaveformControl1.RichBGColor = System.Drawing.Color.Black;
			this.o2WaveformControl1.Size = new System.Drawing.Size(615, 116);
			this.o2WaveformControl1.TabIndex = 1;
			this.o2WaveformControl1.TitleColor = System.Drawing.Color.DodgerBlue;
			this.o2WaveformControl1.TitleFont = new System.Drawing.Font("Arial", 10F);
			this.o2WaveformControl1.WaveColor = System.Drawing.Color.White;
			// 
			// lblOxygenSensor
			// 
			this.lblOxygenSensor.Location = new System.Drawing.Point(6, 12);
			this.lblOxygenSensor.Name = "lblOxygenSensor";
			this.lblOxygenSensor.Size = new System.Drawing.Size(108, 23);
			this.lblOxygenSensor.TabIndex = 2;
			this.lblOxygenSensor.Text = "&Oxygen Sensor:";
			this.lblOxygenSensor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboOxygenSensor
			// 
			this.comboOxygenSensor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboOxygenSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboOxygenSensor.Location = new System.Drawing.Point(120, 10);
			this.comboOxygenSensor.Name = "comboOxygenSensor";
			this.comboOxygenSensor.Size = new System.Drawing.Size(406, 24);
			this.comboOxygenSensor.TabIndex = 3;
			// 
			// btnRead
			// 
			this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRead.Location = new System.Drawing.Point(535, 9);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(90, 24);
			this.btnRead.TabIndex = 4;
			this.btnRead.Text = "&Read";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(10, 416);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(615, 26);
			this.progressBar.TabIndex = 5;
			// 
			// OxygenSensorsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(634, 448);
			this.ControlBox = false;
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.comboOxygenSensor);
			this.Controls.Add(this.lblOxygenSensor);
			this.Controls.Add(this.o2WaveformControl1);
			this.Controls.Add(this.o2TestResultsControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "OxygenSensorsForm";
			this.Text = "Oxygen Sensor Tests";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnRead_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.ConnectedStatus)
				MessageBox.Show(string.Concat((object)"A vehicle connection must first be established."), "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			else
			{
				btnRead.Enabled = false;
				ReadTestResults();
				btnRead.Enabled = true;
			}
		}

		private void ReadTestResults()
		{
			o2TestResultsControl1.Reset();
			progressBar.Maximum = 12;
			progressBar.Value = 0;
			if (!m_obdInterface.getValue("SAE.O2_SUPPORT", true).ErrorDetected)
			{
				OBDParameterValue value;
				value = m_obdInterface.getValue("SAE.O2_STATUS", true);
				if (!value.ErrorDetected && value.BoolValue)
				{
					progressBar.Increment(1);
					int selectedSensorId = getSelectedSensorID();
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 1, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue01 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 1, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum01 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 1, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum01 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 2, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue02 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 2, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum02 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 2, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum02 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 3, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue03 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 3, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum03 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 3, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum03 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 4, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue04 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 4, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum04 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 4, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum04 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 5, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue05 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 5, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum05 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 5, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum05 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 6, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue06 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 6, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum06 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 6, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum06 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 7, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue07 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 7, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum07 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 7, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum07 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 8, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue08 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 8, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum08 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 8, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum08 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 9, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue09 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 9, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum09 = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 9, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum09 = value.DoubleValue;
					progressBar.Increment(1);

					value = m_obdInterface.getValue(new OBDParameter(5, 10, 0, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestValue0A = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 10, 1, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMinimum0A = value.DoubleValue;
					value = m_obdInterface.getValue(new OBDParameter(5, 10, 2, selectedSensorId), true);
					if (!value.ErrorDetected)
						o2TestResultsControl1.TestMaximum0A = value.DoubleValue;
					progressBar.Value = progressBar.Maximum;

					return;
				}
			}
			MessageBox.Show(
				"This vehicle either does not support oxygen sensor monitoring, or the monitoring test has not yet been completed.",
				"Unsupported",
				MessageBoxButtons.OK,
				MessageBoxIcon.Asterisk
				);
		}

		private int getSelectedSensorID()
		{
			string item = comboOxygenSensor.SelectedItem as string;
			if (string.Compare(item, "Bank 1, Sensor 1 (O2B1S1)") == 0)
				return 1;
			if (string.Compare(item, "Bank 1, Sensor 2 (O2B1S2)") == 0)
				return 2;
			if (string.Compare(item, "Bank 1, Sensor 3 (O2B1S3)") == 0)
				return 3;
			if (string.Compare(item, "Bank 1, Sensor 4 (O2B1S4)") == 0)
				return 4;
			if (string.Compare(item, "Bank 2, Sensor 1 (O2B2S1)") == 0)
				return 16;
			if (string.Compare(item, "Bank 2, Sensor 2 (O2B2S2)") == 0)
				return 32;
			if (string.Compare(item, "Bank 2, Sensor 3 (O2B2S3)") == 0)
				return 7;
			if (string.Compare(item, "Bank 2, Sensor 4 (O2B2S4)") == 0)
				return 0;
			return -1;
		}

		private void PopulateO2Locations()
		{
			comboOxygenSensor.Items.Clear();
			OBDParameterValue value;

			value = m_obdInterface.getValue("SAE.O2B1S1A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 1, Sensor 1 (O2B1S1)");

			value = m_obdInterface.getValue("SAE.O2B1S2A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 1, Sensor 2 (O2B1S2)");

			value = m_obdInterface.getValue("SAE.O2B1S3A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 1, Sensor 3 (O2B1S3)");

			value = m_obdInterface.getValue("SAE.O2B1S4A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 1, Sensor 4 (O2B1S4)");

			value = m_obdInterface.getValue("SAE.O2B2S1A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 2, Sensor 1 (O2B2S1)");

			value = m_obdInterface.getValue("SAE.O2B2S2A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 2, Sensor 2 (O2B2S2)");

			value = m_obdInterface.getValue("SAE.O2B2S3A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 2, Sensor 3 (O2B2S3)");

			value = m_obdInterface.getValue("SAE.O2B2S4A_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 2, Sensor 4 (O2B2S4)");

			if (comboOxygenSensor.Items.Count > 0)
				comboOxygenSensor.SelectedIndex = 0;

			value = m_obdInterface.getValue("SAE.O2B1S1B_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 1, Sensor 1 (O2B1S1)");

			value = m_obdInterface.getValue("SAE.O2B1S2B_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 1, Sensor 2 (O2B1S2)");

			value = m_obdInterface.getValue("SAE.O2B2S1B_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 2, Sensor 1 (O2B2S1)");

			value = m_obdInterface.getValue("SAE.O2B2S2B_PRESENT", true);
			if (!value.ErrorDetected && value.BoolValue)
				comboOxygenSensor.Items.Add("Bank 2, Sensor 2 (O2B2S2)");

			if (comboOxygenSensor.Items.Count > 0)
				comboOxygenSensor.SelectedIndex = 0;
		}
	}
}
