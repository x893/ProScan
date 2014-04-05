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
		private O2TestResultsControl o2TestResultsControl1;
		private O2WaveformControl o2WaveformControl1;
		private Label lblOxygenSensor;
		private ComboBox comboOxygenSensor;
		private Button btnRead;
		private OBDInterface m_obdInterface;
		private ProgressBar progressBar;
		private Container components;

		public OxygenSensorsForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
		}

		public new void Update()
		{
			if (!m_obdInterface.getConnectedStatus())
				return;
			PopulateO2Locations();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			o2TestResultsControl1 = new O2TestResultsControl();
			o2WaveformControl1 = new O2Waveform.O2WaveformControl();
			lblOxygenSensor = new System.Windows.Forms.Label();
			comboOxygenSensor = new System.Windows.Forms.ComboBox();
			btnRead = new System.Windows.Forms.Button();
			progressBar = new System.Windows.Forms.ProgressBar();
			SuspendLayout();
			// 
			// o2TestResultsControl1
			// 
			o2TestResultsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			o2TestResultsControl1.Location = new System.Drawing.Point(8, 40);
			o2TestResultsControl1.Name = "o2TestResultsControl1";
			o2TestResultsControl1.Size = new System.Drawing.Size(619, 210);
			o2TestResultsControl1.TabIndex = 0;
			// 
			// o2WaveformControl1
			// 
			o2WaveformControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			o2WaveformControl1.LabelColor = System.Drawing.Color.Yellow;
			o2WaveformControl1.LabelFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			o2WaveformControl1.LeanBGColor = System.Drawing.Color.Black;
			o2WaveformControl1.LineColor = System.Drawing.Color.White;
			o2WaveformControl1.Location = new System.Drawing.Point(8, 256);
			o2WaveformControl1.MidBGColor = System.Drawing.Color.Gray;
			o2WaveformControl1.Name = "o2WaveformControl1";
			o2WaveformControl1.RichBGColor = System.Drawing.Color.Black;
			o2WaveformControl1.Size = new System.Drawing.Size(619, 160);
			o2WaveformControl1.TabIndex = 1;
			o2WaveformControl1.TitleColor = System.Drawing.Color.DodgerBlue;
			o2WaveformControl1.TitleFont = new System.Drawing.Font("Arial", 10F);
			o2WaveformControl1.WaveColor = System.Drawing.Color.White;
			// 
			// lblOxygenSensor
			// 
			lblOxygenSensor.Location = new System.Drawing.Point(5, 10);
			lblOxygenSensor.Name = "lblOxygenSensor";
			lblOxygenSensor.Size = new System.Drawing.Size(90, 20);
			lblOxygenSensor.TabIndex = 2;
			lblOxygenSensor.Text = "&Oxygen Sensor:";
			lblOxygenSensor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboOxygenSensor
			// 
			comboOxygenSensor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			comboOxygenSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboOxygenSensor.Location = new System.Drawing.Point(100, 9);
			comboOxygenSensor.Name = "comboOxygenSensor";
			comboOxygenSensor.Size = new System.Drawing.Size(444, 21);
			comboOxygenSensor.TabIndex = 3;
			// 
			// btnRead
			// 
			btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			btnRead.Location = new System.Drawing.Point(552, 8);
			btnRead.Name = "btnRead";
			btnRead.Size = new System.Drawing.Size(75, 21);
			btnRead.TabIndex = 4;
			btnRead.Text = "&Read";
			btnRead.Click += new System.EventHandler(btnRead_Click);
			// 
			// progressBar
			// 
			progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			progressBar.Location = new System.Drawing.Point(8, 420);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(619, 23);
			progressBar.TabIndex = 5;
			// 
			// OxygenSensorsForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(634, 448);
			ControlBox = false;
			Controls.Add(progressBar);
			Controls.Add(btnRead);
			Controls.Add(comboOxygenSensor);
			Controls.Add(lblOxygenSensor);
			Controls.Add(o2WaveformControl1);
			Controls.Add(o2TestResultsControl1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Name = "OxygenSensorsForm";
			Text = "Oxygen Sensor Tests";
			ResumeLayout(false);

		}

		private void btnRead_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show(string.Concat((object)"A vehicle connection must first be established."), "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
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
				OBDParameterValue obdParameterValue1 = m_obdInterface.getValue("SAE.O2_STATUS", true);
				if (!obdParameterValue1.ErrorDetected && obdParameterValue1.BoolValue)
				{
					progressBar.Increment(1);
					int selectedSensorId = getSelectedSensorID();
					int num = 0;
					sbyte[] arrayType0x529830f3 = new sbyte[10];
					do
					{
						arrayType0x529830f3[num] = 1;
						++num;
					}
					while (num < 10);

					progressBar.Increment(1);
					if (arrayType0x529830f3[0] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 1, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue01 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 1, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum01 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 1, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum01 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[1] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 2, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue02 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 2, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum02 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 2, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum02 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[2] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 3, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue03 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 3, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum03 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 3, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum03 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[3] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 4, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue04 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 4, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum04 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 4, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum04 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[4] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 5, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue05 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 5, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum05 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 5, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum05 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);
					if (arrayType0x529830f3[5] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 6, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue06 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 6, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum06 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 6, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum06 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[6] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 7, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue07 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 7, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum07 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 7, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum07 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[7] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 8, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue08 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 8, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum08 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 8, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum08 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[8] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 9, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue09 = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 9, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum09 = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 9, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum09 = obdParameterValue4.DoubleValue;
					}
					progressBar.Increment(1);

					if (arrayType0x529830f3[9] != 0)
					{
						OBDParameterValue obdParameterValue2 = m_obdInterface.getValue(new OBDParameter(5, 10, 0, selectedSensorId), true);
						if (!obdParameterValue2.ErrorDetected)
							o2TestResultsControl1.TestValue0A = obdParameterValue2.DoubleValue;
						OBDParameterValue obdParameterValue3 = m_obdInterface.getValue(new OBDParameter(5, 10, 1, selectedSensorId), true);
						if (!obdParameterValue3.ErrorDetected)
							o2TestResultsControl1.TestMinimum0A = obdParameterValue3.DoubleValue;
						OBDParameterValue obdParameterValue4 = m_obdInterface.getValue(new OBDParameter(5, 10, 2, selectedSensorId), true);
						if (!obdParameterValue4.ErrorDetected)
							o2TestResultsControl1.TestMaximum0A = obdParameterValue4.DoubleValue;
					}
					progressBar.Value = progressBar.Maximum;
					return;
				}
			}
			MessageBox.Show("This vehicle either does not support oxygen sensor monitoring, or the monitoring test has not yet been completed.", "Unsupported", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private int getSelectedSensorID()
		{
			string strA = comboOxygenSensor.SelectedItem as string;
			if (string.Compare(strA, "Bank 1, Sensor 1 (O2B1S1)") == 0)
				return 1;
			if (string.Compare(strA, "Bank 1, Sensor 2 (O2B1S2)") == 0)
				return 2;
			if (string.Compare(strA, "Bank 1, Sensor 3 (O2B1S3)") == 0)
				return 3;
			if (string.Compare(strA, "Bank 1, Sensor 4 (O2B1S4)") == 0)
				return 4;
			if (string.Compare(strA, "Bank 2, Sensor 1 (O2B2S1)") == 0)
				return 16;
			if (string.Compare(strA, "Bank 2, Sensor 2 (O2B2S2)") == 0)
				return 32;
			if (string.Compare(strA, "Bank 2, Sensor 3 (O2B2S3)") == 0)
				return 7;
			return string.Compare(strA, "Bank 2, Sensor 4 (O2B2S4)") != 0 ? -1 : 8;
		}

		private void PopulateO2Locations()
		{
			comboOxygenSensor.Items.Clear();
			OBDParameterValue value13 = m_obdInterface.getValue("SAE.O2B1S1A_PRESENT", true);
			if (!value13.ErrorDetected && value13.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 1, Sensor 1 (O2B1S1)");
			}
			OBDParameterValue value12 = m_obdInterface.getValue("SAE.O2B1S2A_PRESENT", true);
			if (!value12.ErrorDetected && value12.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 1, Sensor 2 (O2B1S2)");
			}
			OBDParameterValue value11 = m_obdInterface.getValue("SAE.O2B1S3A_PRESENT", true);
			if (!value11.ErrorDetected && value11.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 1, Sensor 3 (O2B1S3)");
			}
			OBDParameterValue value10 = m_obdInterface.getValue("SAE.O2B1S4A_PRESENT", true);
			if (!value10.ErrorDetected && value10.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 1, Sensor 4 (O2B1S4)");
			}
			OBDParameterValue value9 = m_obdInterface.getValue("SAE.O2B2S1A_PRESENT", true);
			if (!value9.ErrorDetected && value9.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 2, Sensor 1 (O2B2S1)");
			}
			OBDParameterValue value8 = m_obdInterface.getValue("SAE.O2B2S2A_PRESENT", true);
			if (!value8.ErrorDetected && value8.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 2, Sensor 2 (O2B2S2)");
			}
			OBDParameterValue value7 = m_obdInterface.getValue("SAE.O2B2S3A_PRESENT", true);
			if (!value7.ErrorDetected && value7.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 2, Sensor 3 (O2B2S3)");
			}
			OBDParameterValue value6 = m_obdInterface.getValue("SAE.O2B2S4A_PRESENT", true);
			if (!value6.ErrorDetected && value6.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 2, Sensor 4 (O2B2S4)");
			}
			if (comboOxygenSensor.Items.Count > 0)
			{
				comboOxygenSensor.SelectedIndex = 0;
			}
			OBDParameterValue value5 = m_obdInterface.getValue("SAE.O2B1S1B_PRESENT", true);
			if (!value5.ErrorDetected && value5.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 1, Sensor 1 (O2B1S1)");
			}
			OBDParameterValue value4 = m_obdInterface.getValue("SAE.O2B1S2B_PRESENT", true);
			if (!value4.ErrorDetected && value4.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 1, Sensor 2 (O2B1S2)");
			}
			OBDParameterValue value3 = m_obdInterface.getValue("SAE.O2B2S1B_PRESENT", true);
			if (!value3.ErrorDetected && value3.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 2, Sensor 1 (O2B2S1)");
			}
			OBDParameterValue value2 = m_obdInterface.getValue("SAE.O2B2S2B_PRESENT", true);
			if (!value2.ErrorDetected && value2.BoolValue)
			{
				comboOxygenSensor.Items.Add("Bank 2, Sensor 2 (O2B2S2)");
			}
			if (comboOxygenSensor.Items.Count > 0)
			{
				comboOxygenSensor.SelectedIndex = 0;
			}
		}
	}
}