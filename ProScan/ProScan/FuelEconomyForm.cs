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
		private double m_TotalFuelConsumption;
		private double m_TotalDistance;
		public bool m_RunThread;
		public bool IsWorking;
		private DateTime m_StartTime;
		private DateTime m_PrevTime;

		public FuelEconomyForm(OBDInterface obd)
		{
			m_FuelEconomyForm = this;
			InitializeComponent();
			m_obdInterface = obd;
			m_RunThread = true;
			IsWorking = false;

			sensorInstantFuelConsumption.SetDisplayMode(1);
			sensorAvgFuelConsumption.SetDisplayMode(1);
			sensorAvgFuelEconomy.SetDisplayMode(1);
			sensorInstantFuelEconomy.SetDisplayMode(1);
			sensorTotalConsumed.SetDisplayMode(1);
			sensorDistance.SetDisplayMode(1);
			sensorTotalCost.SetDisplayMode(1);
			sensorCostPerMile.SetDisplayMode(1);
		}

		public void CheckConnection()
		{
			if (m_obdInterface.ConnectedStatus)
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
			m_TotalDistance = 0.0;
			m_TotalFuelConsumption = 0.0;
			m_StartTime = DateTime.Now;
			m_PrevTime = DateTime.Now;
			IsWorking = true;
			btnStart.Enabled = false;
			btnStop.Enabled = true;
			groupSetup.Enabled = false;
		}

		public void StopWorking()
		{
			IsWorking = false;
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
			if (!m_RunThread)
				return;

			do
			{
				if (m_obdInterface.ConnectedStatus && IsWorking)
				{
					OBDParameterValue sae_maf = m_obdInterface.getValue("SAE.MAF", false);
					OBDParameterValue sae_vss = m_obdInterface.getValue("SAE.VSS", false);
					if (!sae_maf.ErrorDetected && !sae_vss.ErrorDetected)
					{
						double sae_vss_double = sae_vss.DoubleValue;
						double speed_miles = sae_vss_double * 0.621371192;
						double fuel_liters_hour = ((sae_maf.DoubleValue * 0.068027210884353748) * 3600.0) * 0.0013020833333333333;
						double fuel_gallons_hour = fuel_liters_hour * 0.264172052;

						DateTime now = DateTime.Now;
						double hours_start = now.Subtract(m_FuelEconomyForm.m_StartTime).TotalSeconds * 0.00027777777777777778;
						double hours_prev = now.Subtract(m_FuelEconomyForm.m_PrevTime).TotalSeconds * 0.00027777777777777778;
						m_FuelEconomyForm.m_PrevTime = now;

						if (m_FuelEconomyForm.radioEnglishUnits.Checked)
						{
							m_FuelEconomyForm.sensorInstantFuelConsumption.EnglishDisplay = fuel_gallons_hour.ToString("0.000") + " gallons/hour";
							m_FuelEconomyForm.m_TotalFuelConsumption += hours_prev * fuel_gallons_hour;
							double total = m_FuelEconomyForm.m_TotalFuelConsumption;
							sensorTotalConsumed.EnglishDisplay = total.ToString("0.00") + " gallons";
							m_FuelEconomyForm.sensorAvgFuelConsumption.EnglishDisplay = ((m_FuelEconomyForm.m_TotalFuelConsumption / hours_start)).ToString("0.00") + " gallons/hour";
							m_FuelEconomyForm.m_TotalDistance += hours_prev * speed_miles;
							m_FuelEconomyForm.sensorDistance.EnglishDisplay = m_TotalDistance.ToString("0.00") + " miles";
							m_FuelEconomyForm.sensorInstantFuelEconomy.EnglishDisplay = (((1.0 / fuel_gallons_hour) * speed_miles)).ToString("0.00") + " miles/gallon";
							double miles_gallon = 0.0;
							if (m_FuelEconomyForm.m_TotalDistance > 0.0)
								miles_gallon = m_FuelEconomyForm.m_TotalDistance / m_FuelEconomyForm.m_TotalFuelConsumption;

							m_FuelEconomyForm.sensorAvgFuelEconomy.EnglishDisplay = miles_gallon.ToString("0.00") + " miles/gallon";
							double cost_per_mile = 0.0;
							if (miles_gallon > 0.0)
								cost_per_mile = ((double)numericFuelCost.Value) * (1.0 / miles_gallon);

							m_FuelEconomyForm.sensorCostPerMile.Title = "Average Cost Per Mile";
							m_FuelEconomyForm.sensorCostPerMile.EnglishDisplay = "$" + cost_per_mile.ToString("0.00");
							m_FuelEconomyForm.sensorTotalCost.EnglishDisplay = "$" + ((((double)numericFuelCost.Value) * m_TotalFuelConsumption)).ToString("0.00");
						}
						else
						{
							m_FuelEconomyForm.sensorInstantFuelConsumption.EnglishDisplay = fuel_liters_hour.ToString("0.000") + " liters/hour";
							m_FuelEconomyForm.m_TotalFuelConsumption += hours_prev * fuel_liters_hour;
							double total = m_FuelEconomyForm.m_TotalFuelConsumption;
							sensorTotalConsumed.EnglishDisplay = total.ToString("0.00") + " liters";
							m_FuelEconomyForm.sensorAvgFuelConsumption.EnglishDisplay = ((m_FuelEconomyForm.m_TotalFuelConsumption / hours_start)).ToString("0.00") + " liters/hour";
							m_FuelEconomyForm.m_TotalDistance += hours_prev * sae_vss_double;
							m_FuelEconomyForm.sensorDistance.EnglishDisplay = m_TotalDistance.ToString("0.00") + " kilometers";
							m_FuelEconomyForm.sensorInstantFuelEconomy.EnglishDisplay = (((1.0 / fuel_liters_hour) * sae_vss_double)).ToString("0.00") + " kilometers/liter";
							double kilometers_liter = 0.0;
							if (m_FuelEconomyForm.m_TotalDistance > 0.0)
								kilometers_liter = m_FuelEconomyForm.m_TotalDistance / m_FuelEconomyForm.m_TotalFuelConsumption;

							m_FuelEconomyForm.sensorAvgFuelEconomy.EnglishDisplay = kilometers_liter.ToString("0.00") + " kilometers/liter";
							double cost_per_kilometer = 0.0;
							if (kilometers_liter > 0.0)
								cost_per_kilometer = ((double)numericFuelCost.Value) * (1.0 / kilometers_liter);

							m_FuelEconomyForm.sensorCostPerMile.Title = "Average Cost Per Kilometer";
							m_FuelEconomyForm.sensorCostPerMile.EnglishDisplay = cost_per_kilometer.ToString("0.00");
							m_FuelEconomyForm.sensorTotalCost.EnglishDisplay = (((double)numericFuelCost.Value) * m_TotalFuelConsumption).ToString("0.00");
						}
					}
				}
				else
					Thread.Sleep(300);
			}
			while (m_RunThread);
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

		#region InitializeComponent
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

		protected override void Dispose(bool disposing)
		{
			m_RunThread = false;
			IsWorking = false;
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupSetup = new System.Windows.Forms.GroupBox();
			this.labelFuelUnit = new System.Windows.Forms.Label();
			this.numericFuelCost = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.radioMetricUnits = new System.Windows.Forms.RadioButton();
			this.radioEnglishUnits = new System.Windows.Forms.RadioButton();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.groupControl = new System.Windows.Forms.GroupBox();
			this.sensorInstantFuelConsumption = new ProScan.SensorDisplayControl();
			this.sensorAvgFuelConsumption = new ProScan.SensorDisplayControl();
			this.sensorAvgFuelEconomy = new ProScan.SensorDisplayControl();
			this.sensorInstantFuelEconomy = new ProScan.SensorDisplayControl();
			this.sensorTotalConsumed = new ProScan.SensorDisplayControl();
			this.sensorDistance = new ProScan.SensorDisplayControl();
			this.sensorTotalCost = new ProScan.SensorDisplayControl();
			this.sensorCostPerMile = new ProScan.SensorDisplayControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupSetup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericFuelCost)).BeginInit();
			this.groupControl.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupSetup
			// 
			this.groupSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupSetup.Controls.Add(this.labelFuelUnit);
			this.groupSetup.Controls.Add(this.numericFuelCost);
			this.groupSetup.Controls.Add(this.label1);
			this.groupSetup.Controls.Add(this.radioMetricUnits);
			this.groupSetup.Controls.Add(this.radioEnglishUnits);
			this.groupSetup.Location = new System.Drawing.Point(10, 9);
			this.groupSetup.Name = "groupSetup";
			this.groupSetup.Size = new System.Drawing.Size(545, 95);
			this.groupSetup.TabIndex = 0;
			this.groupSetup.TabStop = false;
			this.groupSetup.Text = "Setup";
			// 
			// labelFuelUnit
			// 
			this.labelFuelUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelFuelUnit.Location = new System.Drawing.Point(362, 55);
			this.labelFuelUnit.Name = "labelFuelUnit";
			this.labelFuelUnit.Size = new System.Drawing.Size(58, 28);
			this.labelFuelUnit.TabIndex = 5;
			this.labelFuelUnit.Text = "/ Gallon";
			this.labelFuelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericFuelCost
			// 
			this.numericFuelCost.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numericFuelCost.DecimalPlaces = 2;
			this.numericFuelCost.Location = new System.Drawing.Point(285, 55);
			this.numericFuelCost.Name = "numericFuelCost";
			this.numericFuelCost.Size = new System.Drawing.Size(77, 22);
			this.numericFuelCost.TabIndex = 4;
			this.numericFuelCost.Value = new decimal(new int[] {
            350,
            0,
            0,
            131072});
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.Location = new System.Drawing.Point(285, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 28);
			this.label1.TabIndex = 3;
			this.label1.Text = "Fuel &Cost:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioMetricUnits
			// 
			this.radioMetricUnits.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioMetricUnits.Location = new System.Drawing.Point(132, 55);
			this.radioMetricUnits.Name = "radioMetricUnits";
			this.radioMetricUnits.Size = new System.Drawing.Size(124, 28);
			this.radioMetricUnits.TabIndex = 2;
			this.radioMetricUnits.Text = "&Metric Units";
			this.radioMetricUnits.CheckedChanged += new System.EventHandler(this.radioEnglishUnits_CheckedChanged);
			// 
			// radioEnglishUnits
			// 
			this.radioEnglishUnits.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioEnglishUnits.Checked = true;
			this.radioEnglishUnits.Location = new System.Drawing.Point(132, 18);
			this.radioEnglishUnits.Name = "radioEnglishUnits";
			this.radioEnglishUnits.Size = new System.Drawing.Size(124, 28);
			this.radioEnglishUnits.TabIndex = 1;
			this.radioEnglishUnits.TabStop = true;
			this.radioEnglishUnits.Text = "&English Units";
			this.radioEnglishUnits.CheckedChanged += new System.EventHandler(this.radioEnglishUnits_CheckedChanged);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(58, 18);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(96, 27);
			this.btnStart.TabIndex = 6;
			this.btnStart.Text = "&Start Trip";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(58, 55);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(96, 27);
			this.btnStop.TabIndex = 7;
			this.btnStop.Text = "S&top Trip";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// groupControl
			// 
			this.groupControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupControl.Controls.Add(this.btnStop);
			this.groupControl.Controls.Add(this.btnStart);
			this.groupControl.Location = new System.Drawing.Point(563, 9);
			this.groupControl.Name = "groupControl";
			this.groupControl.Size = new System.Drawing.Size(211, 95);
			this.groupControl.TabIndex = 8;
			this.groupControl.TabStop = false;
			this.groupControl.Text = "Control";
			// 
			// sensorInstantFuelConsumption
			// 
			this.sensorInstantFuelConsumption.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorInstantFuelConsumption.EnglishDisplay = "";
			this.sensorInstantFuelConsumption.Location = new System.Drawing.Point(8, 8);
			this.sensorInstantFuelConsumption.MetricDisplay = "";
			this.sensorInstantFuelConsumption.Name = "sensorInstantFuelConsumption";
			this.sensorInstantFuelConsumption.Size = new System.Drawing.Size(371, 82);
			this.sensorInstantFuelConsumption.TabIndex = 10;
			this.sensorInstantFuelConsumption.Title = "Instantaneous Fuel Consumption";
			// 
			// sensorAvgFuelConsumption
			// 
			this.sensorAvgFuelConsumption.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorAvgFuelConsumption.EnglishDisplay = "";
			this.sensorAvgFuelConsumption.Location = new System.Drawing.Point(8, 96);
			this.sensorAvgFuelConsumption.MetricDisplay = "";
			this.sensorAvgFuelConsumption.Name = "sensorAvgFuelConsumption";
			this.sensorAvgFuelConsumption.Size = new System.Drawing.Size(371, 82);
			this.sensorAvgFuelConsumption.TabIndex = 11;
			this.sensorAvgFuelConsumption.Title = "Average Fuel Consumption";
			// 
			// sensorAvgFuelEconomy
			// 
			this.sensorAvgFuelEconomy.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorAvgFuelEconomy.EnglishDisplay = "";
			this.sensorAvgFuelEconomy.Location = new System.Drawing.Point(385, 96);
			this.sensorAvgFuelEconomy.MetricDisplay = "";
			this.sensorAvgFuelEconomy.Name = "sensorAvgFuelEconomy";
			this.sensorAvgFuelEconomy.Size = new System.Drawing.Size(371, 82);
			this.sensorAvgFuelEconomy.TabIndex = 13;
			this.sensorAvgFuelEconomy.Title = "Average Fuel Economy";
			// 
			// sensorInstantFuelEconomy
			// 
			this.sensorInstantFuelEconomy.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorInstantFuelEconomy.EnglishDisplay = "";
			this.sensorInstantFuelEconomy.Location = new System.Drawing.Point(385, 8);
			this.sensorInstantFuelEconomy.MetricDisplay = "";
			this.sensorInstantFuelEconomy.Name = "sensorInstantFuelEconomy";
			this.sensorInstantFuelEconomy.Size = new System.Drawing.Size(371, 82);
			this.sensorInstantFuelEconomy.TabIndex = 12;
			this.sensorInstantFuelEconomy.Title = "Instantaneous Fuel Economy";
			// 
			// sensorTotalConsumed
			// 
			this.sensorTotalConsumed.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorTotalConsumed.EnglishDisplay = "";
			this.sensorTotalConsumed.Location = new System.Drawing.Point(8, 272);
			this.sensorTotalConsumed.MetricDisplay = "";
			this.sensorTotalConsumed.Name = "sensorTotalConsumed";
			this.sensorTotalConsumed.Size = new System.Drawing.Size(371, 82);
			this.sensorTotalConsumed.TabIndex = 15;
			this.sensorTotalConsumed.Title = "Total Fuel Consumed";
			// 
			// sensorDistance
			// 
			this.sensorDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorDistance.EnglishDisplay = "";
			this.sensorDistance.Location = new System.Drawing.Point(8, 184);
			this.sensorDistance.MetricDisplay = "";
			this.sensorDistance.Name = "sensorDistance";
			this.sensorDistance.Size = new System.Drawing.Size(371, 82);
			this.sensorDistance.TabIndex = 14;
			this.sensorDistance.Title = "Distance Traveled";
			// 
			// sensorTotalCost
			// 
			this.sensorTotalCost.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorTotalCost.EnglishDisplay = "";
			this.sensorTotalCost.Location = new System.Drawing.Point(385, 272);
			this.sensorTotalCost.MetricDisplay = "";
			this.sensorTotalCost.Name = "sensorTotalCost";
			this.sensorTotalCost.Size = new System.Drawing.Size(371, 82);
			this.sensorTotalCost.TabIndex = 17;
			this.sensorTotalCost.Title = "Total Trip Cost";
			// 
			// sensorCostPerMile
			// 
			this.sensorCostPerMile.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.sensorCostPerMile.EnglishDisplay = "";
			this.sensorCostPerMile.Location = new System.Drawing.Point(385, 184);
			this.sensorCostPerMile.MetricDisplay = "";
			this.sensorCostPerMile.Name = "sensorCostPerMile";
			this.sensorCostPerMile.Size = new System.Drawing.Size(371, 82);
			this.sensorCostPerMile.TabIndex = 16;
			this.sensorCostPerMile.Title = "Average Cost Per Mile";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.sensorInstantFuelEconomy);
			this.panel1.Controls.Add(this.sensorTotalConsumed);
			this.panel1.Controls.Add(this.sensorAvgFuelEconomy);
			this.panel1.Controls.Add(this.sensorAvgFuelConsumption);
			this.panel1.Controls.Add(this.sensorInstantFuelConsumption);
			this.panel1.Controls.Add(this.sensorCostPerMile);
			this.panel1.Controls.Add(this.sensorTotalCost);
			this.panel1.Controls.Add(this.sensorDistance);
			this.panel1.Location = new System.Drawing.Point(12, 113);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(762, 367);
			this.panel1.TabIndex = 18;
			// 
			// FuelEconomyForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(786, 492);
			this.ControlBox = false;
			this.Controls.Add(this.groupControl);
			this.Controls.Add(this.groupSetup);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FuelEconomyForm";
			this.ShowInTaskbar = false;
			this.Text = "Fuel Economy Analysis";
			this.Load += new System.EventHandler(this.FuelEconomyForm_Load);
			this.groupSetup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericFuelCost)).EndInit();
			this.groupControl.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}