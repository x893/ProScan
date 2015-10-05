using DGChart;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProScan
{
	public class ScopeForm : Form
	{
		protected OBDInterface m_obdInterface;
		private DGChartControl chart1;
		private DGChartControl chart2;
		private DGChartControl chart3;
		private DGChartControl chart4;
		private GroupBox groupSetup;
		private CheckBox chkSensor1;
		private CheckBox chkSensor2;
		private CheckBox chkSensor3;
		private CheckBox chkSensor4;
		private ComboBox comboSensor1;
		private ComboBox comboSensor2;
		private ComboBox comboSensor3;
		private ComboBox comboSensor4;
		private ComboBox comboUnits1;
		private ComboBox comboUnits2;
		private ComboBox comboStyle1;
		private ComboBox comboStyle2;
		private ComboBox comboStyle3;
		private ComboBox comboStyle4;
		private GroupBox groupControl;
		private Label lblHistory;
		private Button btnStart;
		private NumericUpDown numHistory;
		private Button btnStop;
		private ComboBox comboUnits4;
		private ComboBox comboUnits3;
		private ScopeForm MyScopeForm;

		private List<DatedValue> m_arraySensor1Values;
		private List<DatedValue> m_arraySensor2Values;
		private List<DatedValue> m_arraySensor3Values;
		private List<DatedValue> m_arraySensor4Values;

		private double m_dSensor1Max;
		private double m_dSensor2Max;
		private double m_dSensor3Max;
		private double m_dSensor4Max;
		private double m_dSensor1Min;
		private double m_dSensor2Min;
		private double m_dSensor3Min;
		private double m_dSensor4Min;
		private double[] dSensor1Values;
		private double[] dSensor1Times;
		private double[] dSensor2Values;
		private double[] dSensor2Times;
		private double[] dSensor3Values;
		private double[] dSensor3Times;
		private double[] dSensor4Values;
		private double[] dSensor4Times;
		public bool IsPlotting;

		public ScopeForm(OBDInterface obd2)
		{
			MyScopeForm = this;
			m_obdInterface = obd2;
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.chart1 = new DGChart.DGChartControl();
			this.comboSensor1 = new System.Windows.Forms.ComboBox();
			this.chart2 = new DGChart.DGChartControl();
			this.chart3 = new DGChart.DGChartControl();
			this.chart4 = new DGChart.DGChartControl();
			this.groupSetup = new System.Windows.Forms.GroupBox();
			this.comboStyle4 = new System.Windows.Forms.ComboBox();
			this.comboStyle3 = new System.Windows.Forms.ComboBox();
			this.comboStyle2 = new System.Windows.Forms.ComboBox();
			this.comboStyle1 = new System.Windows.Forms.ComboBox();
			this.comboUnits4 = new System.Windows.Forms.ComboBox();
			this.comboUnits3 = new System.Windows.Forms.ComboBox();
			this.comboUnits2 = new System.Windows.Forms.ComboBox();
			this.comboUnits1 = new System.Windows.Forms.ComboBox();
			this.chkSensor4 = new System.Windows.Forms.CheckBox();
			this.chkSensor3 = new System.Windows.Forms.CheckBox();
			this.chkSensor2 = new System.Windows.Forms.CheckBox();
			this.chkSensor1 = new System.Windows.Forms.CheckBox();
			this.comboSensor4 = new System.Windows.Forms.ComboBox();
			this.comboSensor3 = new System.Windows.Forms.ComboBox();
			this.comboSensor2 = new System.Windows.Forms.ComboBox();
			this.groupControl = new System.Windows.Forms.GroupBox();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.numHistory = new System.Windows.Forms.NumericUpDown();
			this.lblHistory = new System.Windows.Forms.Label();
			this.groupSetup.SuspendLayout();
			this.groupControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHistory)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.SystemColors.Control;
			this.chart1.BorderBottom = 25;
			this.chart1.BorderTop = 20;
			this.chart1.ColorAxis = System.Drawing.Color.Black;
			this.chart1.ColorBg = System.Drawing.SystemColors.Control;
			this.chart1.ColorGrid = System.Drawing.Color.Gray;
			this.chart1.ColorSet1 = System.Drawing.Color.DarkBlue;
			this.chart1.ColorSet2 = System.Drawing.Color.Red;
			this.chart1.ColorSet3 = System.Drawing.Color.Lime;
			this.chart1.ColorSet4 = System.Drawing.Color.Gold;
			this.chart1.ColorSet5 = System.Drawing.Color.Magenta;
			this.chart1.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			this.chart1.FontAxis = new System.Drawing.Font("Arial", 8F);
			this.chart1.Location = new System.Drawing.Point(0, 148);
			this.chart1.Name = "chart1";
			this.chart1.ShowData1 = true;
			this.chart1.ShowData2 = false;
			this.chart1.ShowData3 = false;
			this.chart1.ShowData4 = false;
			this.chart1.ShowData5 = false;
			this.chart1.Size = new System.Drawing.Size(379, 184);
			this.chart1.TabIndex = 0;
			this.chart1.XData1 = null;
			this.chart1.XData2 = null;
			this.chart1.XData3 = null;
			this.chart1.XData4 = null;
			this.chart1.XData5 = null;
			this.chart1.XGrid = 10D;
			this.chart1.XLabel = "0";
			this.chart1.XRangeEnd = 30D;
			this.chart1.XRangeStart = 0D;
			this.chart1.YData1 = null;
			this.chart1.YData2 = null;
			this.chart1.YData3 = null;
			this.chart1.YData4 = null;
			this.chart1.YData5 = null;
			this.chart1.YGrid = 20D;
			this.chart1.YLabel = "0";
			this.chart1.YRangeEnd = 100D;
			this.chart1.YRangeStart = 0D;
			// 
			// comboSensor1
			// 
			this.comboSensor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSensor1.Enabled = false;
			this.comboSensor1.Location = new System.Drawing.Point(108, 23);
			this.comboSensor1.Name = "comboSensor1";
			this.comboSensor1.Size = new System.Drawing.Size(240, 24);
			this.comboSensor1.TabIndex = 1;
			this.comboSensor1.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits1_SelectedIndexChanged);
			// 
			// chart2
			// 
			this.chart2.BackColor = System.Drawing.SystemColors.Control;
			this.chart2.BorderBottom = 25;
			this.chart2.BorderTop = 20;
			this.chart2.ColorAxis = System.Drawing.Color.Black;
			this.chart2.ColorBg = System.Drawing.SystemColors.Control;
			this.chart2.ColorGrid = System.Drawing.Color.Gray;
			this.chart2.ColorSet1 = System.Drawing.Color.Red;
			this.chart2.ColorSet2 = System.Drawing.Color.DarkBlue;
			this.chart2.ColorSet3 = System.Drawing.Color.Lime;
			this.chart2.ColorSet4 = System.Drawing.Color.Gold;
			this.chart2.ColorSet5 = System.Drawing.Color.Magenta;
			this.chart2.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			this.chart2.FontAxis = new System.Drawing.Font("Arial", 8F);
			this.chart2.Location = new System.Drawing.Point(379, 148);
			this.chart2.Name = "chart2";
			this.chart2.ShowData1 = true;
			this.chart2.ShowData2 = false;
			this.chart2.ShowData3 = false;
			this.chart2.ShowData4 = false;
			this.chart2.ShowData5 = false;
			this.chart2.Size = new System.Drawing.Size(379, 184);
			this.chart2.TabIndex = 3;
			this.chart2.XData1 = null;
			this.chart2.XData2 = null;
			this.chart2.XData3 = null;
			this.chart2.XData4 = null;
			this.chart2.XData5 = null;
			this.chart2.XGrid = 10D;
			this.chart2.XLabel = "0";
			this.chart2.XRangeEnd = 30D;
			this.chart2.XRangeStart = 0D;
			this.chart2.YData1 = null;
			this.chart2.YData2 = null;
			this.chart2.YData3 = null;
			this.chart2.YData4 = null;
			this.chart2.YData5 = null;
			this.chart2.YGrid = 20D;
			this.chart2.YLabel = "0";
			this.chart2.YRangeEnd = 100D;
			this.chart2.YRangeStart = 0D;
			// 
			// chart3
			// 
			this.chart3.BackColor = System.Drawing.SystemColors.Control;
			this.chart3.BorderBottom = 25;
			this.chart3.BorderTop = 20;
			this.chart3.ColorAxis = System.Drawing.Color.Black;
			this.chart3.ColorBg = System.Drawing.SystemColors.Control;
			this.chart3.ColorGrid = System.Drawing.Color.Gray;
			this.chart3.ColorSet1 = System.Drawing.Color.Lime;
			this.chart3.ColorSet2 = System.Drawing.Color.Red;
			this.chart3.ColorSet3 = System.Drawing.Color.DarkBlue;
			this.chart3.ColorSet4 = System.Drawing.Color.Gold;
			this.chart3.ColorSet5 = System.Drawing.Color.Magenta;
			this.chart3.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			this.chart3.FontAxis = new System.Drawing.Font("Arial", 8F);
			this.chart3.Location = new System.Drawing.Point(0, 332);
			this.chart3.Name = "chart3";
			this.chart3.ShowData1 = true;
			this.chart3.ShowData2 = false;
			this.chart3.ShowData3 = false;
			this.chart3.ShowData4 = false;
			this.chart3.ShowData5 = false;
			this.chart3.Size = new System.Drawing.Size(379, 185);
			this.chart3.TabIndex = 4;
			this.chart3.XData1 = null;
			this.chart3.XData2 = null;
			this.chart3.XData3 = null;
			this.chart3.XData4 = null;
			this.chart3.XData5 = null;
			this.chart3.XGrid = 10D;
			this.chart3.XLabel = "0";
			this.chart3.XRangeEnd = 30D;
			this.chart3.XRangeStart = 0D;
			this.chart3.YData1 = null;
			this.chart3.YData2 = null;
			this.chart3.YData3 = null;
			this.chart3.YData4 = null;
			this.chart3.YData5 = null;
			this.chart3.YGrid = 20D;
			this.chart3.YLabel = "0";
			this.chart3.YRangeEnd = 100D;
			this.chart3.YRangeStart = 0D;
			// 
			// chart4
			// 
			this.chart4.BackColor = System.Drawing.SystemColors.Control;
			this.chart4.BorderBottom = 25;
			this.chart4.BorderTop = 20;
			this.chart4.ColorAxis = System.Drawing.Color.Black;
			this.chart4.ColorBg = System.Drawing.SystemColors.Control;
			this.chart4.ColorGrid = System.Drawing.Color.Gray;
			this.chart4.ColorSet1 = System.Drawing.Color.Magenta;
			this.chart4.ColorSet2 = System.Drawing.Color.Red;
			this.chart4.ColorSet3 = System.Drawing.Color.Lime;
			this.chart4.ColorSet4 = System.Drawing.Color.Gold;
			this.chart4.ColorSet5 = System.Drawing.Color.DarkBlue;
			this.chart4.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			this.chart4.FontAxis = new System.Drawing.Font("Arial", 8F);
			this.chart4.Location = new System.Drawing.Point(379, 332);
			this.chart4.Name = "chart4";
			this.chart4.ShowData1 = true;
			this.chart4.ShowData2 = false;
			this.chart4.ShowData3 = false;
			this.chart4.ShowData4 = false;
			this.chart4.ShowData5 = false;
			this.chart4.Size = new System.Drawing.Size(379, 185);
			this.chart4.TabIndex = 5;
			this.chart4.XData1 = null;
			this.chart4.XData2 = null;
			this.chart4.XData3 = null;
			this.chart4.XData4 = null;
			this.chart4.XData5 = null;
			this.chart4.XGrid = 10D;
			this.chart4.XLabel = "0";
			this.chart4.XRangeEnd = 30D;
			this.chart4.XRangeStart = 0D;
			this.chart4.YData1 = null;
			this.chart4.YData2 = null;
			this.chart4.YData3 = null;
			this.chart4.YData4 = null;
			this.chart4.YData5 = null;
			this.chart4.YGrid = 20D;
			this.chart4.YLabel = "0";
			this.chart4.YRangeEnd = 100D;
			this.chart4.YRangeStart = 0D;
			// 
			// groupSetup
			// 
			this.groupSetup.Controls.Add(this.comboStyle4);
			this.groupSetup.Controls.Add(this.comboStyle3);
			this.groupSetup.Controls.Add(this.comboStyle2);
			this.groupSetup.Controls.Add(this.comboStyle1);
			this.groupSetup.Controls.Add(this.comboUnits4);
			this.groupSetup.Controls.Add(this.comboUnits3);
			this.groupSetup.Controls.Add(this.comboUnits2);
			this.groupSetup.Controls.Add(this.comboUnits1);
			this.groupSetup.Controls.Add(this.chkSensor4);
			this.groupSetup.Controls.Add(this.chkSensor3);
			this.groupSetup.Controls.Add(this.chkSensor2);
			this.groupSetup.Controls.Add(this.chkSensor1);
			this.groupSetup.Controls.Add(this.comboSensor4);
			this.groupSetup.Controls.Add(this.comboSensor3);
			this.groupSetup.Controls.Add(this.comboSensor2);
			this.groupSetup.Controls.Add(this.comboSensor1);
			this.groupSetup.Location = new System.Drawing.Point(10, 9);
			this.groupSetup.Name = "groupSetup";
			this.groupSetup.Size = new System.Drawing.Size(595, 139);
			this.groupSetup.TabIndex = 6;
			this.groupSetup.TabStop = false;
			this.groupSetup.Text = "Setup";
			// 
			// comboStyle4
			// 
			this.comboStyle4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStyle4.Enabled = false;
			this.comboStyle4.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			this.comboStyle4.Location = new System.Drawing.Point(492, 99);
			this.comboStyle4.Name = "comboStyle4";
			this.comboStyle4.Size = new System.Drawing.Size(90, 24);
			this.comboStyle4.TabIndex = 20;
			this.comboStyle4.SelectedIndexChanged += new System.EventHandler(this.comboStyle4_SelectedIndexChanged);
			// 
			// comboStyle3
			// 
			this.comboStyle3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStyle3.Enabled = false;
			this.comboStyle3.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			this.comboStyle3.Location = new System.Drawing.Point(492, 74);
			this.comboStyle3.Name = "comboStyle3";
			this.comboStyle3.Size = new System.Drawing.Size(90, 24);
			this.comboStyle3.TabIndex = 19;
			this.comboStyle3.SelectedIndexChanged += new System.EventHandler(this.comboStyle3_SelectedIndexChanged);
			// 
			// comboStyle2
			// 
			this.comboStyle2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStyle2.Enabled = false;
			this.comboStyle2.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			this.comboStyle2.Location = new System.Drawing.Point(492, 48);
			this.comboStyle2.Name = "comboStyle2";
			this.comboStyle2.Size = new System.Drawing.Size(90, 24);
			this.comboStyle2.TabIndex = 18;
			this.comboStyle2.SelectedIndexChanged += new System.EventHandler(this.comboStyle2_SelectedIndexChanged);
			// 
			// comboStyle1
			// 
			this.comboStyle1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStyle1.Enabled = false;
			this.comboStyle1.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			this.comboStyle1.Location = new System.Drawing.Point(492, 23);
			this.comboStyle1.Name = "comboStyle1";
			this.comboStyle1.Size = new System.Drawing.Size(90, 24);
			this.comboStyle1.TabIndex = 17;
			this.comboStyle1.SelectedIndexChanged += new System.EventHandler(this.comboStyle1_SelectedIndexChanged);
			// 
			// comboUnits4
			// 
			this.comboUnits4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUnits4.Enabled = false;
			this.comboUnits4.Items.AddRange(new object[] {
            "English",
            "Metric"});
			this.comboUnits4.Location = new System.Drawing.Point(360, 99);
			this.comboUnits4.Name = "comboUnits4";
			this.comboUnits4.Size = new System.Drawing.Size(120, 24);
			this.comboUnits4.TabIndex = 16;
			this.comboUnits4.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits4_SelectedIndexChanged);
			// 
			// comboUnits3
			// 
			this.comboUnits3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUnits3.Enabled = false;
			this.comboUnits3.Items.AddRange(new object[] {
            "English",
            "Metric"});
			this.comboUnits3.Location = new System.Drawing.Point(360, 74);
			this.comboUnits3.Name = "comboUnits3";
			this.comboUnits3.Size = new System.Drawing.Size(120, 24);
			this.comboUnits3.TabIndex = 15;
			this.comboUnits3.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits3_SelectedIndexChanged);
			// 
			// comboUnits2
			// 
			this.comboUnits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUnits2.Enabled = false;
			this.comboUnits2.Items.AddRange(new object[] {
            "English",
            "Metric"});
			this.comboUnits2.Location = new System.Drawing.Point(360, 48);
			this.comboUnits2.Name = "comboUnits2";
			this.comboUnits2.Size = new System.Drawing.Size(120, 24);
			this.comboUnits2.TabIndex = 14;
			this.comboUnits2.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits2_SelectedIndexChanged);
			// 
			// comboUnits1
			// 
			this.comboUnits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboUnits1.Enabled = false;
			this.comboUnits1.Items.AddRange(new object[] {
            "English",
            "Metric"});
			this.comboUnits1.Location = new System.Drawing.Point(360, 23);
			this.comboUnits1.Name = "comboUnits1";
			this.comboUnits1.Size = new System.Drawing.Size(120, 24);
			this.comboUnits1.TabIndex = 13;
			this.comboUnits1.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits1_SelectedIndexChanged);
			// 
			// chkSensor4
			// 
			this.chkSensor4.Enabled = false;
			this.chkSensor4.Location = new System.Drawing.Point(12, 99);
			this.chkSensor4.Name = "chkSensor4";
			this.chkSensor4.Size = new System.Drawing.Size(96, 23);
			this.chkSensor4.TabIndex = 12;
			this.chkSensor4.Text = "Sensor &4:";
			this.chkSensor4.CheckStateChanged += new System.EventHandler(this.chkSensor4_CheckedChanged);
			this.chkSensor4.EnabledChanged += new System.EventHandler(this.chkSensor4_EnabledChanged);
			// 
			// chkSensor3
			// 
			this.chkSensor3.Enabled = false;
			this.chkSensor3.Location = new System.Drawing.Point(12, 74);
			this.chkSensor3.Name = "chkSensor3";
			this.chkSensor3.Size = new System.Drawing.Size(96, 23);
			this.chkSensor3.TabIndex = 11;
			this.chkSensor3.Text = "Sensor &3:";
			this.chkSensor3.CheckStateChanged += new System.EventHandler(this.chkSensor3_CheckedChanged);
			this.chkSensor3.EnabledChanged += new System.EventHandler(this.chkSensor3_EnabledChanged);
			// 
			// chkSensor2
			// 
			this.chkSensor2.Enabled = false;
			this.chkSensor2.Location = new System.Drawing.Point(12, 48);
			this.chkSensor2.Name = "chkSensor2";
			this.chkSensor2.Size = new System.Drawing.Size(96, 24);
			this.chkSensor2.TabIndex = 10;
			this.chkSensor2.Text = "Sensor &2:";
			this.chkSensor2.CheckStateChanged += new System.EventHandler(this.chkSensor2_CheckedChanged);
			this.chkSensor2.EnabledChanged += new System.EventHandler(this.chkSensor2_EnabledChanged);
			// 
			// chkSensor1
			// 
			this.chkSensor1.Location = new System.Drawing.Point(12, 23);
			this.chkSensor1.Name = "chkSensor1";
			this.chkSensor1.Size = new System.Drawing.Size(96, 23);
			this.chkSensor1.TabIndex = 9;
			this.chkSensor1.Text = "Sensor &1:";
			this.chkSensor1.CheckedChanged += new System.EventHandler(this.chkSensor1_CheckedChanged);
			this.chkSensor1.EnabledChanged += new System.EventHandler(this.chkSensor1_EnabledChanged);
			// 
			// comboSensor4
			// 
			this.comboSensor4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSensor4.Enabled = false;
			this.comboSensor4.Location = new System.Drawing.Point(108, 99);
			this.comboSensor4.Name = "comboSensor4";
			this.comboSensor4.Size = new System.Drawing.Size(240, 24);
			this.comboSensor4.TabIndex = 7;
			this.comboSensor4.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits4_SelectedIndexChanged);
			// 
			// comboSensor3
			// 
			this.comboSensor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSensor3.Enabled = false;
			this.comboSensor3.Location = new System.Drawing.Point(108, 74);
			this.comboSensor3.Name = "comboSensor3";
			this.comboSensor3.Size = new System.Drawing.Size(240, 24);
			this.comboSensor3.TabIndex = 5;
			this.comboSensor3.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits3_SelectedIndexChanged);
			// 
			// comboSensor2
			// 
			this.comboSensor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSensor2.Enabled = false;
			this.comboSensor2.Location = new System.Drawing.Point(108, 48);
			this.comboSensor2.Name = "comboSensor2";
			this.comboSensor2.Size = new System.Drawing.Size(240, 24);
			this.comboSensor2.TabIndex = 3;
			this.comboSensor2.SelectedIndexChanged += new System.EventHandler(this.comboSensorOrUnits2_SelectedIndexChanged);
			// 
			// groupControl
			// 
			this.groupControl.Controls.Add(this.btnStop);
			this.groupControl.Controls.Add(this.btnStart);
			this.groupControl.Controls.Add(this.numHistory);
			this.groupControl.Controls.Add(this.lblHistory);
			this.groupControl.Location = new System.Drawing.Point(614, 9);
			this.groupControl.Name = "groupControl";
			this.groupControl.Size = new System.Drawing.Size(135, 139);
			this.groupControl.TabIndex = 7;
			this.groupControl.TabStop = false;
			this.groupControl.Text = "Control";
			// 
			// btnStop
			// 
			this.btnStop.Enabled = false;
			this.btnStop.Location = new System.Drawing.Point(12, 99);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(110, 23);
			this.btnStop.TabIndex = 4;
			this.btnStop.Text = "S&top";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 74);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(110, 23);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "&Start";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// numHistory
			// 
			this.numHistory.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numHistory.Location = new System.Drawing.Point(12, 48);
			this.numHistory.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.numHistory.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numHistory.Name = "numHistory";
			this.numHistory.ReadOnly = true;
			this.numHistory.Size = new System.Drawing.Size(110, 22);
			this.numHistory.TabIndex = 1;
			this.numHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numHistory.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numHistory.ValueChanged += new System.EventHandler(this.numHistory_ValueChanged);
			// 
			// lblHistory
			// 
			this.lblHistory.Location = new System.Drawing.Point(7, 23);
			this.lblHistory.Name = "lblHistory";
			this.lblHistory.Size = new System.Drawing.Size(120, 23);
			this.lblHistory.TabIndex = 0;
			this.lblHistory.Text = "&History (secs):";
			this.lblHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ScopeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(760, 538);
			this.ControlBox = false;
			this.Controls.Add(this.groupControl);
			this.Controls.Add(this.groupSetup);
			this.Controls.Add(this.chart4);
			this.Controls.Add(this.chart3);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.chart1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ScopeForm";
			this.ShowInTaskbar = false;
			this.Text = "Live Sensor Graphs";
			this.Activated += new System.EventHandler(this.ScopeForm_Activated);
			this.Load += new System.EventHandler(this.ScopeForm_Load);
			this.Resize += new System.EventHandler(this.ScopeForm_Resize);
			this.groupSetup.ResumeLayout(false);
			this.groupControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numHistory)).EndInit();
			this.ResumeLayout(false);

		}

		private void ScopeForm_Resize(object sender, EventArgs e)
		{
			int num1 = Width;
			int height = Height;
			if (num1 < 640)
				num1 = 640;
			WindowState = FormWindowState.Maximized;
			groupSetup.Width = num1 - 144;
			Point location1 = groupControl.Location;
			groupControl.Location = new Point(num1 - 128, location1.Y);
			int num2 = groupSetup.Width - 296;
			comboSensor1.Width = num2;
			comboSensor2.Width = num2;
			comboSensor3.Width = num2;
			comboSensor4.Width = num2;
			int x1 = groupSetup.Width - 196;
			comboUnits1.Location = new Point(x1, comboUnits1.Location.Y);
			comboUnits2.Location = new Point(x1, comboUnits2.Location.Y);
			comboUnits3.Location = new Point(x1, comboUnits3.Location.Y);
			comboUnits4.Location = new Point(x1, comboUnits4.Location.Y);
			int x2 = groupSetup.Width - 86;
			comboStyle1.Location = new Point(x2, comboStyle1.Location.Y);
			comboStyle2.Location = new Point(x2, comboStyle2.Location.Y);
			comboStyle3.Location = new Point(x2, comboStyle3.Location.Y);
			comboStyle4.Location = new Point(x2, comboStyle4.Location.Y);
			DrawCharts();
		}

		private void DrawCharts()
    {
      int width = Width;
      int height = Height;
      int num1 = 0;
      if (chkSensor1.Checked)
        num1 = 1;
      if (chkSensor2.Checked)
        ++num1;
      if (chkSensor3.Checked)
        ++num1;
      if (chkSensor4.Checked)
        ++num1;
      if (num1 == 0)
      {
        chart1.Visible = false;
        chart2.Visible = false;
        chart3.Visible = false;
        chart4.Visible = false;
      }
      else if (num1 == 1)
      {
        chart1.Visible = true;
        chart2.Visible = false;
        chart3.Visible = false;
        chart4.Visible = false;
        chart1.Location = new Point(0, 128);
        chart1.Width = width;
        chart1.Height = height - 160;
      }
      else if (num1 == 2)
      {
        chart1.Visible = true;
        chart2.Visible = true;
        chart3.Visible = false;
        chart4.Visible = false;
        chart1.Location = new Point(0, 128);
        chart1.Width = width;
        int num2 = (height - 160) / 2;
        chart1.Height = num2;
        chart2.Location = new Point(0, height - chart1.Height - 32);
        chart2.Width = width;
        chart2.Height = num2;
      }
      else if (num1 == 3)
      {
        chart1.Visible = true;
        chart2.Visible = true;
        chart3.Visible = true;
        chart4.Visible = false;
        chart1.Location = new Point(0, 128);
        int x = width / 2;
        chart1.Width = x;
        int num2 = (height - 160) / 2;
        chart1.Height = num2;
        chart2.Location = new Point(x, chart1.Location.Y);
        chart2.Width = x;
        chart2.Height = num2;
        chart3.Location = new Point(0, height - chart1.Height - 32);
        chart3.Width = width;
        chart3.Height = num2;
      }
      else
      {
        if (num1 != 4)
          return;
        chart1.Visible = true;
        chart2.Visible = true;
        chart3.Visible = true;
        chart4.Visible = true;
        chart1.Location = new Point(0, 128);
        int x = width / 2;
        chart1.Width = x;
        int num2 = (height - 160) / 2;
        chart1.Height = num2;
        Point location1 = chart1.Location;
        chart2.Location = new Point(x, location1.Y);
        chart2.Width = x;
        chart2.Height = num2;
        chart3.Location = new Point(0, chart1.Height + chart1.Location.Y);
        chart3.Width = x;
        chart3.Height = num2;
        Point location2 = chart1.Location;
        chart4.Location = new Point(x, chart1.Height + location2.Y);
        chart4.Width = x;
        chart4.Height = num2;
      }
    }

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (!chkSensor1.Checked)
			{
				MessageBox.Show("You must configure at least one sensor to monitor.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				chkSensor1.Enabled = false;
				chkSensor2.Enabled = false;
				chkSensor3.Enabled = false;
				chkSensor4.Enabled = false;
				comboSensor1.Enabled = false;
				comboSensor2.Enabled = false;
				comboSensor3.Enabled = false;
				comboSensor4.Enabled = false;
				comboUnits1.Enabled = false;
				comboUnits2.Enabled = false;
				comboUnits3.Enabled = false;
				comboUnits4.Enabled = false;
				comboStyle1.Enabled = false;
				comboStyle2.Enabled = false;
				comboStyle3.Enabled = false;
				comboStyle4.Enabled = false;
				numHistory.Enabled = false;
				btnStart.Enabled = false;
				btnStop.Enabled = true;
				IsPlotting = true;
				ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateThread));
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			StopLogging();
		}

		public void StopLogging()
		{
			numHistory.Enabled = true;
			chkSensor1.Enabled = true;
			if (chkSensor1.Checked)
			{
				chkSensor1.Enabled = true;
				chkSensor2.Enabled = true;
			}
			if (chkSensor2.Checked)
			{
				chkSensor2.Enabled = true;
				chkSensor3.Enabled = true;
			}
			if (chkSensor3.Checked)
			{
				chkSensor3.Enabled = true;
				chkSensor4.Enabled = true;
			}
			IsPlotting = false;
			btnStart.Enabled = true;
			btnStop.Enabled = false;
		}

		private void ScopeForm_Load(object sender, EventArgs e)
		{
			IsPlotting = false;
			CheckConnection();
			chart1.XRangeStart = -30.0;
			chart1.XRangeEnd = 0.0;
			chart2.XRangeStart = -30.0;
			chart2.XRangeEnd = 0.0;
			chart3.XRangeStart = -30.0;
			chart3.XRangeEnd = 0.0;
			chart4.XRangeStart = -30.0;
			chart4.XRangeEnd = 0.0;
			chkSensor1.Enabled = true;
			comboSensor1.Enabled = true;
			comboStyle1.Enabled = true;
			comboUnits1.Enabled = true;
			m_arraySensor1Values = new List<DatedValue>();
			m_arraySensor2Values = new List<DatedValue>();
			m_arraySensor3Values = new List<DatedValue>();
			m_arraySensor4Values = new List<DatedValue>();
			comboUnits1.SelectedIndex = 0;
			comboUnits2.SelectedIndex = 0;
			comboUnits3.SelectedIndex = 0;
			comboUnits4.SelectedIndex = 0;
			comboStyle1.SelectedIndex = 0;
			comboStyle2.SelectedIndex = 0;
			comboStyle3.SelectedIndex = 0;
			comboStyle4.SelectedIndex = 0;
		}

		static bool isConnected;
		public bool CheckConnection()
		{
			if (m_obdInterface.ConnectedStatus)
			{
				if (!isConnected)
				{
					isConnected = true;
					if (!IsPlotting)
						btnStart.Enabled = true;
					comboSensor1.Items.Clear();
					comboSensor2.Items.Clear();
					comboSensor3.Items.Clear();
					comboSensor4.Items.Clear();
					foreach (OBDParameter obdParameter in m_obdInterface.SupportedParameterList(1))
					{
						comboSensor1.Items.Add((object)obdParameter);
						comboSensor2.Items.Add((object)obdParameter);
						comboSensor3.Items.Add((object)obdParameter);
						comboSensor4.Items.Add((object)obdParameter);
					}
				}
				return true;
			}
			else
			{
				isConnected = false;
				IsPlotting = false;
				btnStart.Enabled = false;
				comboSensor1.Items.Clear();
				comboSensor2.Items.Clear();
				comboSensor3.Items.Clear();
				comboSensor4.Items.Clear();
				return false;
			}
		}

		public void UpdateThread(object state)
		{
			if (!IsPlotting)
				return;
			do
			{
				if (CheckConnection())
				{
					bool bEnglishUnits = true;
					if (comboUnits1.SelectedIndex > 0)
						bEnglishUnits = false;
					if (chkSensor1.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor1.Items[comboSensor1.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor1Values.Add(new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart1();
						}
					}
					if (chkSensor2.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor2.Items[comboSensor2.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor2Values.Add(new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart2();
						}
					}
					if (chkSensor3.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor3.Items[comboSensor3.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor3Values.Add(new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart3();
						}
					}
					if (chkSensor4.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor4.Items[comboSensor4.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor4Values.Add(new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart4();
						}
					}
				}
			}
			while (IsPlotting);
		}

		public void UpdateChart1()
		{
			int index1 = 0;
			if (0 < m_arraySensor1Values.Count)
			{
				do
				{
					if (DateTime.Now.Subtract(m_arraySensor1Values[index1].Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
					{
						m_arraySensor1Values.RemoveAt(index1);
						--index1;
					}
					++index1;
				}
				while (index1 < m_arraySensor1Values.Count);
			}
			if (m_arraySensor1Values.Count == 0)
				return;
			double[] numArray1 = new double[m_arraySensor1Values.Count];
			numArray1.Initialize();
			dSensor1Values = numArray1;
			double[] numArray2 = new double[m_arraySensor1Values.Count];
			numArray2.Initialize();
			dSensor1Times = numArray2;
			m_dSensor1Max = m_arraySensor1Values[0].Value;
			m_dSensor1Min = m_arraySensor1Values[0].Value;
			int index2 = 0;
			if (0 < m_arraySensor1Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor1Values[index2];
					if (datedValue.Value > m_dSensor1Max)
						m_dSensor1Max = datedValue.Value;
					if (datedValue.Value < m_dSensor1Min)
						m_dSensor1Min = datedValue.Value;
					dSensor1Values[index2] = datedValue.Value;
					TimeSpan timeSpan = DateTime.Now.Subtract(datedValue.Date);
					dSensor1Times[index2] = timeSpan.TotalSeconds * -1.0;
					++index2;
				}
				while (index2 < m_arraySensor1Values.Count);
			}
			if (chart1.YRangeEnd < m_dSensor1Max)
			{
				chart1.YRangeEnd = Math.Ceiling(m_dSensor1Max);
				chart1.YGrid = (chart1.YRangeEnd - chart1.YRangeStart) * 0.1;
			}
			if (chart1.YRangeStart > m_dSensor1Min)
			{
				chart1.YRangeStart = Math.Floor(m_dSensor1Min);
				chart1.YGrid = (chart1.YRangeEnd - chart1.YRangeStart) * 0.1;
			}
			chart1.XData1 = dSensor1Times;
			chart1.YData1 = dSensor1Values;
		}

		public void UpdateChart2()
		{
			int index1 = 0;
			if (0 < m_arraySensor2Values.Count)
			{
				do
				{
					if (DateTime.Now.Subtract(m_arraySensor2Values[index1].Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
					{
						m_arraySensor2Values.RemoveAt(index1);
						--index1;
					}
					++index1;
				}
				while (index1 < m_arraySensor2Values.Count);
			}
			if (m_arraySensor2Values.Count == 0)
				return;
			double[] numArray1 = new double[m_arraySensor2Values.Count];
			numArray1.Initialize();
			dSensor2Values = numArray1;
			double[] numArray2 = new double[m_arraySensor2Values.Count];
			numArray2.Initialize();
			dSensor2Times = numArray2;
			m_dSensor2Max = m_arraySensor2Values[0].Value;
			m_dSensor2Min = m_arraySensor2Values[0].Value;
			int index2 = 0;
			if (0 < m_arraySensor2Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor2Values[index2];
					if (datedValue.Value > m_dSensor2Max)
						m_dSensor2Max = datedValue.Value;
					if (datedValue.Value < m_dSensor2Min)
						m_dSensor2Min = datedValue.Value;
					dSensor2Values[index2] = datedValue.Value;
					TimeSpan timeSpan = DateTime.Now.Subtract(datedValue.Date);
					dSensor2Times[index2] = timeSpan.TotalSeconds * -1.0;
					++index2;
				}
				while (index2 < m_arraySensor2Values.Count);
			}
			if (chart2.YRangeEnd < m_dSensor2Max)
			{
				chart2.YRangeEnd = Math.Ceiling(m_dSensor2Max);
				chart2.YGrid = (chart2.YRangeEnd - chart2.YRangeStart) * 0.1;
			}
			if (chart2.YRangeStart > m_dSensor2Min)
			{
				chart2.YRangeStart = Math.Floor(m_dSensor2Min);
				chart2.YGrid = (chart2.YRangeEnd - chart2.YRangeStart) * 0.1;
			}
			chart2.XData1 = dSensor2Times;
			chart2.YData1 = dSensor2Values;
		}

		public void UpdateChart3()
		{
			int index1 = 0;
			if (0 < m_arraySensor3Values.Count)
			{
				do
				{
					if (DateTime.Now.Subtract(m_arraySensor3Values[index1].Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
					{
						m_arraySensor3Values.RemoveAt(index1);
						--index1;
					}
					++index1;
				}
				while (index1 < m_arraySensor3Values.Count);
			}
			if (m_arraySensor3Values.Count == 0)
				return;
			double[] numArray1 = new double[m_arraySensor3Values.Count];
			numArray1.Initialize();
			dSensor3Values = numArray1;
			double[] numArray2 = new double[m_arraySensor3Values.Count];
			numArray2.Initialize();
			dSensor3Times = numArray2;
			m_dSensor3Max = m_arraySensor3Values[0].Value;
			m_dSensor3Min = m_arraySensor3Values[0].Value;
			int index2 = 0;
			if (0 < m_arraySensor3Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor3Values[index2];
					if (datedValue.Value > m_dSensor3Max)
						m_dSensor3Max = datedValue.Value;
					if (datedValue.Value < m_dSensor3Min)
						m_dSensor3Min = datedValue.Value;
					dSensor3Values[index2] = datedValue.Value;
					TimeSpan timeSpan = DateTime.Now.Subtract(datedValue.Date);
					dSensor3Times[index2] = timeSpan.TotalSeconds * -1.0;
					++index2;
				}
				while (index2 < m_arraySensor3Values.Count);
			}
			if (chart3.YRangeEnd < m_dSensor3Max)
			{
				chart3.YRangeEnd = Math.Ceiling(m_dSensor3Max);
				chart3.YGrid = (chart3.YRangeEnd - chart3.YRangeStart) * 0.1;
			}
			if (chart3.YRangeStart > m_dSensor3Min)
			{
				chart3.YRangeStart = Math.Floor(m_dSensor3Min);
				chart3.YGrid = (chart3.YRangeEnd - chart3.YRangeStart) * 0.1;
			}
			chart3.XData1 = dSensor3Times;
			chart3.YData1 = dSensor3Values;
		}

		public void UpdateChart4()
		{
			int index1 = 0;
			if (0 < m_arraySensor4Values.Count)
			{
				do
				{
					if (DateTime.Now.Subtract(m_arraySensor4Values[index1].Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
					{
						m_arraySensor4Values.RemoveAt(index1);
						--index1;
					}
					++index1;
				}
				while (index1 < m_arraySensor4Values.Count);
			}
			if (m_arraySensor4Values.Count == 0)
				return;
			double[] numArray1 = new double[m_arraySensor4Values.Count];
			numArray1.Initialize();
			dSensor4Values = numArray1;
			double[] numArray2 = new double[m_arraySensor4Values.Count];
			numArray2.Initialize();
			dSensor4Times = numArray2;
			m_dSensor4Max = m_arraySensor4Values[0].Value;
			m_dSensor4Min = m_arraySensor4Values[0].Value;
			int index2 = 0;
			if (0 < m_arraySensor4Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor4Values[index2];
					if (datedValue.Value > m_dSensor4Max)
						m_dSensor4Max = datedValue.Value;
					if (datedValue.Value < m_dSensor4Min)
						m_dSensor4Min = datedValue.Value;
					dSensor4Values[index2] = datedValue.Value;
					TimeSpan timeSpan = DateTime.Now.Subtract(datedValue.Date);
					dSensor4Times[index2] = timeSpan.TotalSeconds * -1.0;
					++index2;
				}
				while (index2 < m_arraySensor4Values.Count);
			}
			if (chart4.YRangeEnd < m_dSensor4Max)
			{
				chart4.YRangeEnd = Math.Ceiling(m_dSensor4Max);
				chart4.YGrid = (chart4.YRangeEnd - chart4.YRangeStart) * 0.1;
			}
			if (chart4.YRangeStart > m_dSensor4Min)
			{
				chart4.YRangeStart = Math.Floor(m_dSensor4Min);
				chart4.YGrid = (chart4.YRangeEnd - chart4.YRangeStart) * 0.1;
			}
			chart4.XData1 = dSensor4Times;
			chart4.YData1 = dSensor4Values;
		}

		private void numHistory_ValueChanged(object sender, EventArgs e)
		{
			chart1.XRangeStart = (double)Convert.ToSingle(numHistory.Value) * -1.0;
			chart2.XRangeStart = (double)Convert.ToSingle(numHistory.Value) * -1.0;
			chart3.XRangeStart = (double)Convert.ToSingle(numHistory.Value) * -1.0;
			chart4.XRangeStart = (double)Convert.ToSingle(numHistory.Value) * -1.0;
		}

		private void comboStyle1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboStyle1.SelectedIndex == 0)
				chart1.DrawMode = DGChartControl.DrawModeType.Line;
			else if (comboStyle1.SelectedIndex == 1)
				chart1.DrawMode = DGChartControl.DrawModeType.Dot;
			else
				chart1.DrawMode = DGChartControl.DrawModeType.Bar;
		}

		private void comboStyle2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboStyle2.SelectedIndex == 0)
				chart2.DrawMode = DGChartControl.DrawModeType.Line;
			else if (comboStyle2.SelectedIndex == 1)
				chart2.DrawMode = DGChartControl.DrawModeType.Dot;
			else
				chart2.DrawMode = DGChartControl.DrawModeType.Bar;
		}

		private void comboStyle3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboStyle3.SelectedIndex == 0)
				chart3.DrawMode = DGChartControl.DrawModeType.Line;
			else if (comboStyle3.SelectedIndex == 1)
				chart3.DrawMode = DGChartControl.DrawModeType.Dot;
			else
				chart3.DrawMode = DGChartControl.DrawModeType.Bar;
		}

		private void comboStyle4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboStyle4.SelectedIndex == 0)
				chart4.DrawMode = DGChartControl.DrawModeType.Line;
			else if (comboStyle4.SelectedIndex == 1)
				chart4.DrawMode = DGChartControl.DrawModeType.Dot;
			else
				chart4.DrawMode = DGChartControl.DrawModeType.Bar;
		}

		private void chkSensor1_CheckedChanged(object sender, EventArgs e)
		{
			DrawCharts();
			if (chkSensor1.Checked)
			{
				chkSensor2.Enabled = true;
			}
			else
			{
				chkSensor2.Checked = false;
				chkSensor3.Checked = false;
				chkSensor4.Checked = false;
				chkSensor2.Enabled = false;
				chkSensor3.Enabled = false;
				chkSensor4.Enabled = false;
			}
		}

		private void chkSensor2_CheckedChanged(object sender, EventArgs e)
		{
			DrawCharts();
			if (chkSensor2.Checked)
			{
				chkSensor3.Enabled = true;
			}
			else
			{
				chkSensor3.Checked = false;
				chkSensor4.Checked = false;
				chkSensor3.Enabled = false;
				chkSensor4.Enabled = false;
			}
		}

		private void chkSensor3_CheckedChanged(object sender, EventArgs e)
		{
			DrawCharts();
			if (chkSensor3.Checked)
			{
				chkSensor4.Enabled = true;
			}
			else
			{
				chkSensor4.Checked = false;
				chkSensor4.Enabled = false;
			}
		}

		private void chkSensor4_CheckedChanged(object sender, EventArgs e)
		{
			DrawCharts();
		}

		private void chkSensor1_EnabledChanged(object sender, EventArgs e)
		{
			if (chkSensor1.Enabled)
			{
				comboSensor1.Enabled = true;
				comboUnits1.Enabled = true;
				comboStyle1.Enabled = true;
			}
			else
			{
				comboSensor1.Enabled = false;
				comboUnits1.Enabled = false;
				comboStyle1.Enabled = false;
			}
		}

		private void chkSensor2_EnabledChanged(object sender, EventArgs e)
		{
			if (chkSensor2.Enabled)
			{
				comboSensor2.Enabled = true;
				comboUnits2.Enabled = true;
				comboStyle2.Enabled = true;
			}
			else
			{
				comboSensor2.Enabled = false;
				comboUnits2.Enabled = false;
				comboStyle2.Enabled = false;
			}
		}

		private void chkSensor3_EnabledChanged(object sender, EventArgs e)
		{
			if (chkSensor3.Enabled)
			{
				comboSensor3.Enabled = true;
				comboUnits3.Enabled = true;
				comboStyle3.Enabled = true;
			}
			else
			{
				comboSensor3.Enabled = false;
				comboUnits3.Enabled = false;
				comboStyle3.Enabled = false;
			}
		}

		private void chkSensor4_EnabledChanged(object sender, EventArgs e)
		{
			if (chkSensor4.Enabled)
			{
				comboSensor4.Enabled = true;
				comboUnits4.Enabled = true;
				comboStyle4.Enabled = true;
			}
			else
			{
				comboSensor4.Enabled = false;
				comboUnits4.Enabled = false;
				comboStyle4.Enabled = false;
			}
		}

		private void comboSensorOrUnits1_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_arraySensor1Values.Clear();
			chart1.XData1 = (double[])null;
			chart1.YData1 = (double[])null;
			if (comboSensor1.Items.Count == 0)
				return;
			int selectedIndex = comboSensor1.SelectedIndex;
			if (selectedIndex < 0)
				return;
			OBDParameter obdParameter = (OBDParameter)comboSensor1.Items[selectedIndex];
			if (comboUnits1.SelectedIndex == 0)
			{
				chart1.Text = obdParameter.Name + " (" + obdParameter.EnglishUnitLabel + ")";
				chart1.YRangeStart = Math.Floor(obdParameter.EnglishMinValue);
				chart1.YRangeEnd = obdParameter.EnglishMinValue + 1.0;
			}
			else
			{
				chart1.Text = obdParameter.Name + " (" + obdParameter.MetricUnitLabel + ")";
				chart1.YRangeStart = Math.Floor(obdParameter.MetricMinValue);
				chart1.YRangeEnd = obdParameter.MetricMinValue + 1.0;
			}
		}

		private void comboSensorOrUnits2_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_arraySensor2Values.Clear();
			chart2.XData1 = (double[])null;
			chart2.YData1 = (double[])null;
			if (comboSensor2.Items.Count == 0)
				return;
			int selectedIndex = comboSensor2.SelectedIndex;
			if (selectedIndex < 0)
				return;
			OBDParameter obdParameter = comboSensor2.Items[selectedIndex] as OBDParameter;
			if (comboUnits2.SelectedIndex == 0)
			{
				chart2.Text = obdParameter.Name + " (" + obdParameter.EnglishUnitLabel + ")";
				chart2.YRangeStart = Math.Floor(obdParameter.EnglishMinValue);
				chart2.YRangeEnd = obdParameter.EnglishMinValue + 1.0;
			}
			else
			{
				chart2.Text = obdParameter.Name + " (" + obdParameter.MetricUnitLabel + ")";
				chart2.YRangeStart = Math.Floor(obdParameter.MetricMinValue);
				chart2.YRangeEnd = obdParameter.MetricMinValue + 1.0;
			}
		}

		private void comboSensorOrUnits3_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_arraySensor3Values.Clear();
			chart3.XData1 = (double[])null;
			chart3.YData1 = (double[])null;
			if (comboSensor3.Items.Count == 0)
				return;
			int selectedIndex = comboSensor3.SelectedIndex;
			if (selectedIndex < 0)
				return;
			OBDParameter obdParameter = comboSensor3.Items[selectedIndex] as OBDParameter;
			if (comboUnits3.SelectedIndex == 0)
			{
				chart3.Text = obdParameter.Name + " (" + obdParameter.EnglishUnitLabel + ")";
				chart3.YRangeStart = Math.Floor(obdParameter.EnglishMinValue);
				chart3.YRangeEnd = obdParameter.EnglishMinValue + 1.0;
			}
			else
			{
				chart3.Text = obdParameter.Name + " (" + obdParameter.MetricUnitLabel + ")";
				chart3.YRangeStart = Math.Floor(obdParameter.MetricMinValue);
				chart3.YRangeEnd = obdParameter.MetricMinValue + 1.0;
			}
		}

		private void comboSensorOrUnits4_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_arraySensor4Values.Clear();
			chart4.XData1 = (double[])null;
			chart4.YData1 = (double[])null;
			if (comboSensor4.Items.Count == 0)
				return;
			int selectedIndex = comboSensor4.SelectedIndex;
			if (selectedIndex < 0)
				return;
			OBDParameter obdParameter = comboSensor4.Items[selectedIndex] as OBDParameter;
			if (comboUnits4.SelectedIndex == 0)
			{
				chart4.Text = obdParameter.Name + " (" + obdParameter.EnglishUnitLabel + ")";
				chart4.YRangeStart = Math.Floor(obdParameter.EnglishMinValue);
				chart4.YRangeEnd = obdParameter.EnglishMinValue + 1.0;
			}
			else
			{
				chart4.Text = obdParameter.Name + " (" + obdParameter.MetricUnitLabel + ")";
				chart4.YRangeStart = Math.Floor(obdParameter.MetricMinValue);
				chart4.YRangeEnd = obdParameter.MetricMinValue + 1.0;
			}
		}

		private void ScopeForm_Activated(object sender, EventArgs e)
		{
			CheckConnection();
		}
	}
}
