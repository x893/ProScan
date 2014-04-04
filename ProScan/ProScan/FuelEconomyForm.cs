using SensorDisplay;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ProScan
{
	public class FuelEconomyForm : Form
	{
		private FuelEconomyForm m_FuelEconomyForm;
		private OBDInterface m_obdInterface;
		private DateTime dtStartTime;
		private DateTime dtPrevTime;
		private double dTotalFuelConsumption;
		private double dTotalDistance;
		public bool bRunThread;
		public bool m_isWorking;
		private RadioButton radioMetricUnits;
		private Label label1;
		private NumericUpDown numericFuelCost;
		private Label labelFuelUnit;
		private Button btnStart;
		private Button btnStop;
		private Panel panel1;
		private RadioButton radioEnglishUnits;
		private GroupBox groupSetup;
		private GroupBox groupControl;
		private SensorDisplayControl sensorInstantFuelConsumption;
		private SensorDisplayControl sensorAvgFuelConsumption;
		private SensorDisplayControl sensorAvgFuelEconomy;
		private SensorDisplayControl sensorInstantFuelEconomy;
		private SensorDisplayControl sensorTotalConsumed;
		private SensorDisplayControl sensorDistance;
		private SensorDisplayControl sensorTotalCost;
		private SensorDisplayControl sensorCostPerMile;
		private Container components;

		public FuelEconomyForm(OBDInterface obd2)
		{
			m_FuelEconomyForm = this;
			InitializeComponent();
			m_obdInterface = obd2;
			bRunThread = true;
			m_isWorking = false;
			sensorInstantFuelConsumption.SetDisplayMode(1);
			sensorAvgFuelConsumption.SetDisplayMode(1);
			sensorAvgFuelEconomy.SetDisplayMode(1);
			sensorInstantFuelEconomy.SetDisplayMode(1);
			sensorTotalConsumed.SetDisplayMode(1);
			sensorDistance.SetDisplayMode(1);
			sensorTotalCost.SetDisplayMode(1);
			sensorCostPerMile.SetDisplayMode(1);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			bRunThread = false;
			m_isWorking = false;
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			groupSetup = new System.Windows.Forms.GroupBox();
			labelFuelUnit = new System.Windows.Forms.Label();
			numericFuelCost = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			radioMetricUnits = new System.Windows.Forms.RadioButton();
			radioEnglishUnits = new System.Windows.Forms.RadioButton();
			btnStart = new System.Windows.Forms.Button();
			btnStop = new System.Windows.Forms.Button();
			groupControl = new System.Windows.Forms.GroupBox();
			sensorInstantFuelConsumption = new SensorDisplay.SensorDisplayControl();
			sensorAvgFuelConsumption = new SensorDisplay.SensorDisplayControl();
			sensorAvgFuelEconomy = new SensorDisplay.SensorDisplayControl();
			sensorInstantFuelEconomy = new SensorDisplay.SensorDisplayControl();
			sensorTotalConsumed = new SensorDisplay.SensorDisplayControl();
			sensorDistance = new SensorDisplay.SensorDisplayControl();
			sensorTotalCost = new SensorDisplay.SensorDisplayControl();
			sensorCostPerMile = new SensorDisplay.SensorDisplayControl();
			panel1 = new System.Windows.Forms.Panel();
			groupSetup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(numericFuelCost)).BeginInit();
			groupControl.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// groupSetup
			// 
			groupSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupSetup.Controls.Add(labelFuelUnit);
			groupSetup.Controls.Add(numericFuelCost);
			groupSetup.Controls.Add(label1);
			groupSetup.Controls.Add(radioMetricUnits);
			groupSetup.Controls.Add(radioEnglishUnits);
			groupSetup.Location = new System.Drawing.Point(8, 8);
			groupSetup.Name = "groupSetup";
			groupSetup.Size = new System.Drawing.Size(531, 82);
			groupSetup.TabIndex = 0;
			groupSetup.TabStop = false;
			groupSetup.Text = "Setup";
			// 
			// labelFuelUnit
			// 
			labelFuelUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
			labelFuelUnit.Location = new System.Drawing.Point(340, 48);
			labelFuelUnit.Name = "labelFuelUnit";
			labelFuelUnit.Size = new System.Drawing.Size(48, 24);
			labelFuelUnit.TabIndex = 5;
			labelFuelUnit.Text = "/ Gallon";
			labelFuelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericFuelCost
			// 
			numericFuelCost.Anchor = System.Windows.Forms.AnchorStyles.None;
			numericFuelCost.DecimalPlaces = 2;
			numericFuelCost.Location = new System.Drawing.Point(276, 48);
			numericFuelCost.Name = "numericFuelCost";
			numericFuelCost.Size = new System.Drawing.Size(64, 20);
			numericFuelCost.TabIndex = 4;
			numericFuelCost.Value = new decimal(new int[] {
            350,
            0,
            0,
            131072});
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			label1.Location = new System.Drawing.Point(276, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 24);
			label1.TabIndex = 3;
			label1.Text = "Fuel &Cost:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioMetricUnits
			// 
			radioMetricUnits.Anchor = System.Windows.Forms.AnchorStyles.None;
			radioMetricUnits.Location = new System.Drawing.Point(148, 48);
			radioMetricUnits.Name = "radioMetricUnits";
			radioMetricUnits.Size = new System.Drawing.Size(104, 24);
			radioMetricUnits.TabIndex = 2;
			radioMetricUnits.Text = "&Metric Units";
			radioMetricUnits.CheckedChanged += new System.EventHandler(radioEnglishUnits_CheckedChanged);
			// 
			// radioEnglishUnits
			// 
			radioEnglishUnits.Anchor = System.Windows.Forms.AnchorStyles.None;
			radioEnglishUnits.Checked = true;
			radioEnglishUnits.Location = new System.Drawing.Point(148, 16);
			radioEnglishUnits.Name = "radioEnglishUnits";
			radioEnglishUnits.Size = new System.Drawing.Size(104, 24);
			radioEnglishUnits.TabIndex = 1;
			radioEnglishUnits.TabStop = true;
			radioEnglishUnits.Text = "&English Units";
			radioEnglishUnits.CheckedChanged += new System.EventHandler(radioEnglishUnits_CheckedChanged);
			// 
			// btnStart
			// 
			btnStart.Location = new System.Drawing.Point(48, 16);
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(80, 23);
			btnStart.TabIndex = 6;
			btnStart.Text = "&Start Trip";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			// 
			// btnStop
			// 
			btnStop.Location = new System.Drawing.Point(48, 48);
			btnStop.Name = "btnStop";
			btnStop.Size = new System.Drawing.Size(80, 23);
			btnStop.TabIndex = 7;
			btnStop.Text = "S&top Trip";
			btnStop.Click += new System.EventHandler(btnStop_Click);
			// 
			// groupControl
			// 
			groupControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			groupControl.Controls.Add(btnStop);
			groupControl.Controls.Add(btnStart);
			groupControl.Location = new System.Drawing.Point(546, 8);
			groupControl.Name = "groupControl";
			groupControl.Size = new System.Drawing.Size(176, 82);
			groupControl.TabIndex = 8;
			groupControl.TabStop = false;
			groupControl.Text = "Control";
			// 
			// sensorInstantFuelConsumption
			// 
			sensorInstantFuelConsumption.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorInstantFuelConsumption.EnglishDisplay = "";
			sensorInstantFuelConsumption.Location = new System.Drawing.Point(49, 20);
			sensorInstantFuelConsumption.MetricDisplay = "";
			sensorInstantFuelConsumption.Name = "sensorInstantFuelConsumption";
			sensorInstantFuelConsumption.Size = new System.Drawing.Size(309, 71);
			sensorInstantFuelConsumption.TabIndex = 10;
			sensorInstantFuelConsumption.Title = "Instantaneous Fuel Consumption";
			// 
			// sensorAvgFuelConsumption
			// 
			sensorAvgFuelConsumption.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorAvgFuelConsumption.EnglishDisplay = "";
			sensorAvgFuelConsumption.Location = new System.Drawing.Point(49, 96);
			sensorAvgFuelConsumption.MetricDisplay = "";
			sensorAvgFuelConsumption.Name = "sensorAvgFuelConsumption";
			sensorAvgFuelConsumption.Size = new System.Drawing.Size(309, 71);
			sensorAvgFuelConsumption.TabIndex = 11;
			sensorAvgFuelConsumption.Title = "Average Fuel Consumption";
			// 
			// sensorAvgFuelEconomy
			// 
			sensorAvgFuelEconomy.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorAvgFuelEconomy.EnglishDisplay = "";
			sensorAvgFuelEconomy.Location = new System.Drawing.Point(364, 96);
			sensorAvgFuelEconomy.MetricDisplay = "";
			sensorAvgFuelEconomy.Name = "sensorAvgFuelEconomy";
			sensorAvgFuelEconomy.Size = new System.Drawing.Size(309, 71);
			sensorAvgFuelEconomy.TabIndex = 13;
			sensorAvgFuelEconomy.Title = "Average Fuel Economy";
			// 
			// sensorInstantFuelEconomy
			// 
			sensorInstantFuelEconomy.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorInstantFuelEconomy.EnglishDisplay = "";
			sensorInstantFuelEconomy.Location = new System.Drawing.Point(364, 20);
			sensorInstantFuelEconomy.MetricDisplay = "";
			sensorInstantFuelEconomy.Name = "sensorInstantFuelEconomy";
			sensorInstantFuelEconomy.Size = new System.Drawing.Size(309, 71);
			sensorInstantFuelEconomy.TabIndex = 12;
			sensorInstantFuelEconomy.Title = "Instantaneous Fuel Economy";
			// 
			// sensorTotalConsumed
			// 
			sensorTotalConsumed.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorTotalConsumed.EnglishDisplay = "";
			sensorTotalConsumed.Location = new System.Drawing.Point(49, 248);
			sensorTotalConsumed.MetricDisplay = "";
			sensorTotalConsumed.Name = "sensorTotalConsumed";
			sensorTotalConsumed.Size = new System.Drawing.Size(309, 71);
			sensorTotalConsumed.TabIndex = 15;
			sensorTotalConsumed.Title = "Total Fuel Consumed";
			// 
			// sensorDistance
			// 
			sensorDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorDistance.EnglishDisplay = "";
			sensorDistance.Location = new System.Drawing.Point(49, 172);
			sensorDistance.MetricDisplay = "";
			sensorDistance.Name = "sensorDistance";
			sensorDistance.Size = new System.Drawing.Size(309, 71);
			sensorDistance.TabIndex = 14;
			sensorDistance.Title = "Distance Traveled";
			// 
			// sensorTotalCost
			// 
			sensorTotalCost.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorTotalCost.EnglishDisplay = "";
			sensorTotalCost.Location = new System.Drawing.Point(364, 248);
			sensorTotalCost.MetricDisplay = "";
			sensorTotalCost.Name = "sensorTotalCost";
			sensorTotalCost.Size = new System.Drawing.Size(309, 71);
			sensorTotalCost.TabIndex = 17;
			sensorTotalCost.Title = "Total Trip Cost";
			// 
			// sensorCostPerMile
			// 
			sensorCostPerMile.Anchor = System.Windows.Forms.AnchorStyles.None;
			sensorCostPerMile.EnglishDisplay = "";
			sensorCostPerMile.Location = new System.Drawing.Point(364, 172);
			sensorCostPerMile.MetricDisplay = "";
			sensorCostPerMile.Name = "sensorCostPerMile";
			sensorCostPerMile.Size = new System.Drawing.Size(309, 71);
			sensorCostPerMile.TabIndex = 16;
			sensorCostPerMile.Title = "Average Cost Per Mile";
			// 
			// panel1
			// 
			panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			panel1.AutoScroll = true;
			panel1.BackColor = System.Drawing.Color.Black;
			panel1.Controls.Add(sensorInstantFuelEconomy);
			panel1.Controls.Add(sensorTotalConsumed);
			panel1.Controls.Add(sensorAvgFuelEconomy);
			panel1.Controls.Add(sensorAvgFuelConsumption);
			panel1.Controls.Add(sensorInstantFuelConsumption);
			panel1.Controls.Add(sensorCostPerMile);
			panel1.Controls.Add(sensorTotalCost);
			panel1.Controls.Add(sensorDistance);
			panel1.Location = new System.Drawing.Point(10, 98);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(712, 338);
			panel1.TabIndex = 18;
			// 
			// FuelEconomyForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(732, 445);
			ControlBox = false;
			Controls.Add(groupControl);
			Controls.Add(groupSetup);
			Controls.Add(panel1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FuelEconomyForm";
			ShowInTaskbar = false;
			Text = "Fuel Economy Analysis";
			Load += new System.EventHandler(FuelEconomyForm_Load);
			groupSetup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(numericFuelCost)).EndInit();
			groupControl.ResumeLayout(false);
			panel1.ResumeLayout(false);
			ResumeLayout(false);

		}

		public void ReceiveResponse(OBD2Response obd2Response)
		{
		}

		public void CheckConnection()
		{
			if (m_obdInterface.getConnectedStatus())
			{
				groupSetup.Enabled = true;
				groupControl.Enabled = true;
			}
			else
			{
				groupSetup.Enabled = false;
				groupControl.Enabled = false;
			}
		}

		public void StartWorking()
		{
			dTotalDistance = 0.0;
			dTotalFuelConsumption = 0.0;
			dtStartTime = DateTime.Now;
			dtPrevTime = DateTime.Now;
			m_isWorking = true;
			btnStart.Enabled = false;
			btnStop.Enabled = true;
			groupSetup.Enabled = false;
		}

		public void StopWorking()
		{
			m_isWorking = false;
			btnStart.Enabled = true;
			btnStop.Enabled = false;
			groupSetup.Enabled = true;
		}

		private void radioEnglishUnits_CheckedChanged(object sender, EventArgs e)
		{
			if (radioEnglishUnits.Checked)
				labelFuelUnit.Text = "/ Gallon";
			else
				labelFuelUnit.Text = "/ Liter";
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			StartWorking();
		}

		private void UpdateThread(object sender)
		{
			if (bRunThread)
			{
				do
				{
					if (m_obdInterface.getConnectedStatus() && m_isWorking)
					{
						OBDParameterValue value3 = m_obdInterface.getValue("SAE.MAF", false);
						OBDParameterValue value2 = m_obdInterface.getValue("SAE.VSS", false);
						if (!value3.ErrorDetected && !value2.ErrorDetected)
						{
							double doubleValue = value2.DoubleValue;
							double num8 = doubleValue * 0.621371192;
							double num4 = ((value3.DoubleValue * 0.068027210884353748) * 3600.0) * 0.0013020833333333333;
							double num7 = num4 * 0.264172052;
							DateTime now = DateTime.Now;
							double num6 = now.Subtract(m_FuelEconomyForm.dtStartTime).TotalSeconds * 0.00027777777777777778;
							double num = now.Subtract(m_FuelEconomyForm.dtPrevTime).TotalSeconds * 0.00027777777777777778;
							m_FuelEconomyForm.dtPrevTime = now;
							if (m_FuelEconomyForm.radioEnglishUnits.Checked)
							{
								m_FuelEconomyForm.sensorInstantFuelConsumption.EnglishDisplay = num7.ToString("0.000") + " gallons/hour";
								m_FuelEconomyForm.dTotalFuelConsumption += num * num7;
								sensorTotalConsumed.EnglishDisplay = m_FuelEconomyForm.dTotalFuelConsumption.ToString("0.00") + " gallons";
								m_FuelEconomyForm.sensorAvgFuelConsumption.EnglishDisplay = ((m_FuelEconomyForm.dTotalFuelConsumption / num6)).ToString("0.00") + " gallons/hour";
								m_FuelEconomyForm.dTotalDistance += num * num8;
								m_FuelEconomyForm.sensorDistance.EnglishDisplay = dTotalDistance.ToString("0.00") + " miles";
								m_FuelEconomyForm.sensorInstantFuelEconomy.EnglishDisplay = (((1.0 / num7) * num8)).ToString("0.00") + " miles/gallon";
								double num3 = 0.0;
								if (m_FuelEconomyForm.dTotalDistance > 0.0)
								{
									num3 = m_FuelEconomyForm.dTotalDistance / m_FuelEconomyForm.dTotalFuelConsumption;
								}
								m_FuelEconomyForm.sensorAvgFuelEconomy.EnglishDisplay = num3.ToString("0.00") + " miles/gallon";
								double num14 = 0.0;
								if (num3 > 0.0)
								{
									num14 = ((double)numericFuelCost.Value) * (1.0 / num3);
								}
								m_FuelEconomyForm.sensorCostPerMile.Title = "Average Cost Per Mile";
								m_FuelEconomyForm.sensorCostPerMile.EnglishDisplay = "$" + num14.ToString("0.00");
								m_FuelEconomyForm.sensorTotalCost.EnglishDisplay = "$" + ((((double)numericFuelCost.Value) * dTotalFuelConsumption)).ToString("0.00");
							}
							else
							{
								m_FuelEconomyForm.sensorInstantFuelConsumption.EnglishDisplay = num4.ToString("0.000") + " liters/hour";
								m_FuelEconomyForm.dTotalFuelConsumption += num * num4;
								sensorTotalConsumed.EnglishDisplay = m_FuelEconomyForm.dTotalFuelConsumption.ToString("0.00") + " liters";
								m_FuelEconomyForm.sensorAvgFuelConsumption.EnglishDisplay = ((m_FuelEconomyForm.dTotalFuelConsumption / num6)).ToString("0.00") + " liters/hour";
								m_FuelEconomyForm.dTotalDistance += num * doubleValue;
								m_FuelEconomyForm.sensorDistance.EnglishDisplay = dTotalDistance.ToString("0.00") + " kilometers";
								m_FuelEconomyForm.sensorInstantFuelEconomy.EnglishDisplay = (((1.0 / num4) * doubleValue)).ToString("0.00") + " kilometers/liter";
								double num2 = 0.0;
								if (m_FuelEconomyForm.dTotalDistance > 0.0)
								{
									num2 = m_FuelEconomyForm.dTotalDistance / m_FuelEconomyForm.dTotalFuelConsumption;
								}
								m_FuelEconomyForm.sensorAvgFuelEconomy.EnglishDisplay = num2.ToString("0.00") + " kilometers/liter";
								double num11 = 0.0;
								if (num2 > 0.0)
								{
									num11 = ((double)numericFuelCost.Value) * (1.0 / num2);
								}
								m_FuelEconomyForm.sensorCostPerMile.Title = "Average Cost Per Kilometer";
								m_FuelEconomyForm.sensorCostPerMile.EnglishDisplay = num11.ToString("0.00");
								m_FuelEconomyForm.sensorTotalCost.EnglishDisplay = (((double)numericFuelCost.Value) * dTotalFuelConsumption).ToString("0.00");
							}
						}
					}
					else
					{
						Thread.Sleep(300);
					}
				}
				while (bRunThread);
			}
		}

		private void FuelEconomyForm_Load(object sender, EventArgs e)
		{
			CheckConnection();
			ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateThread));
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			StopWorking();
		}
	}
}