using DGChart;
using System;
using System.Collections;
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
		private ArrayList m_arraySensor1Values;
		private ArrayList m_arraySensor2Values;
		private ArrayList m_arraySensor3Values;
		private ArrayList m_arraySensor4Values;
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
		public bool m_isPlotting;
		private Container components;

		public ScopeForm(OBDInterface obd2)
		{
			MyScopeForm = this;
			m_obdInterface = obd2;
			InitializeComponent();
		}

		public void ReceiveResponse(OBD2Response obd2Response)
		{
		}

		public void On_OBD2_Disconnect()
		{
			StopLogging();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			chart1 = new DGChart.DGChartControl();
			comboSensor1 = new System.Windows.Forms.ComboBox();
			chart2 = new DGChart.DGChartControl();
			chart3 = new DGChart.DGChartControl();
			chart4 = new DGChart.DGChartControl();
			groupSetup = new System.Windows.Forms.GroupBox();
			comboStyle4 = new System.Windows.Forms.ComboBox();
			comboStyle3 = new System.Windows.Forms.ComboBox();
			comboStyle2 = new System.Windows.Forms.ComboBox();
			comboStyle1 = new System.Windows.Forms.ComboBox();
			comboUnits4 = new System.Windows.Forms.ComboBox();
			comboUnits3 = new System.Windows.Forms.ComboBox();
			comboUnits2 = new System.Windows.Forms.ComboBox();
			comboUnits1 = new System.Windows.Forms.ComboBox();
			chkSensor4 = new System.Windows.Forms.CheckBox();
			chkSensor3 = new System.Windows.Forms.CheckBox();
			chkSensor2 = new System.Windows.Forms.CheckBox();
			chkSensor1 = new System.Windows.Forms.CheckBox();
			comboSensor4 = new System.Windows.Forms.ComboBox();
			comboSensor3 = new System.Windows.Forms.ComboBox();
			comboSensor2 = new System.Windows.Forms.ComboBox();
			groupControl = new System.Windows.Forms.GroupBox();
			btnStop = new System.Windows.Forms.Button();
			btnStart = new System.Windows.Forms.Button();
			numHistory = new System.Windows.Forms.NumericUpDown();
			lblHistory = new System.Windows.Forms.Label();
			groupSetup.SuspendLayout();
			groupControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(numHistory)).BeginInit();
			SuspendLayout();
			// 
			// chart1
			// 
			chart1.BackColor = System.Drawing.SystemColors.Control;
			chart1.BorderBottom = 25;
			chart1.BorderTop = 20;
			chart1.ColorAxis = System.Drawing.Color.Black;
			chart1.ColorBg = System.Drawing.SystemColors.Control;
			chart1.ColorGrid = System.Drawing.Color.Gray;
			chart1.ColorSet1 = System.Drawing.Color.DarkBlue;
			chart1.ColorSet2 = System.Drawing.Color.Red;
			chart1.ColorSet3 = System.Drawing.Color.Lime;
			chart1.ColorSet4 = System.Drawing.Color.Gold;
			chart1.ColorSet5 = System.Drawing.Color.Magenta;
			chart1.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			chart1.FontAxis = new System.Drawing.Font("Arial", 8F);
			chart1.Location = new System.Drawing.Point(0, 128);
			chart1.Name = "chart1";
			chart1.ShowData1 = true;
			chart1.ShowData2 = false;
			chart1.ShowData3 = false;
			chart1.ShowData4 = false;
			chart1.ShowData5 = false;
			chart1.Size = new System.Drawing.Size(316, 160);
			chart1.TabIndex = 0;
			chart1.XData1 = null;
			chart1.XData2 = null;
			chart1.XData3 = null;
			chart1.XData4 = null;
			chart1.XData5 = null;
			chart1.XGrid = 10D;
			chart1.XLabel = "0";
			chart1.XRangeEnd = 30D;
			chart1.XRangeStart = 0D;
			chart1.YData1 = null;
			chart1.YData2 = null;
			chart1.YData3 = null;
			chart1.YData4 = null;
			chart1.YData5 = null;
			chart1.YGrid = 20D;
			chart1.YLabel = "0";
			chart1.YRangeEnd = 100D;
			chart1.YRangeStart = 0D;
			// 
			// comboSensor1
			// 
			comboSensor1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboSensor1.Enabled = false;
			comboSensor1.Location = new System.Drawing.Point(90, 20);
			comboSensor1.Name = "comboSensor1";
			comboSensor1.Size = new System.Drawing.Size(200, 21);
			comboSensor1.TabIndex = 1;
			comboSensor1.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits1_SelectedIndexChanged);
			// 
			// chart2
			// 
			chart2.BackColor = System.Drawing.SystemColors.Control;
			chart2.BorderBottom = 25;
			chart2.BorderTop = 20;
			chart2.ColorAxis = System.Drawing.Color.Black;
			chart2.ColorBg = System.Drawing.SystemColors.Control;
			chart2.ColorGrid = System.Drawing.Color.Gray;
			chart2.ColorSet1 = System.Drawing.Color.Red;
			chart2.ColorSet2 = System.Drawing.Color.DarkBlue;
			chart2.ColorSet3 = System.Drawing.Color.Lime;
			chart2.ColorSet4 = System.Drawing.Color.Gold;
			chart2.ColorSet5 = System.Drawing.Color.Magenta;
			chart2.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			chart2.FontAxis = new System.Drawing.Font("Arial", 8F);
			chart2.Location = new System.Drawing.Point(316, 128);
			chart2.Name = "chart2";
			chart2.ShowData1 = true;
			chart2.ShowData2 = false;
			chart2.ShowData3 = false;
			chart2.ShowData4 = false;
			chart2.ShowData5 = false;
			chart2.Size = new System.Drawing.Size(316, 160);
			chart2.TabIndex = 3;
			chart2.XData1 = null;
			chart2.XData2 = null;
			chart2.XData3 = null;
			chart2.XData4 = null;
			chart2.XData5 = null;
			chart2.XGrid = 10D;
			chart2.XLabel = "0";
			chart2.XRangeEnd = 30D;
			chart2.XRangeStart = 0D;
			chart2.YData1 = null;
			chart2.YData2 = null;
			chart2.YData3 = null;
			chart2.YData4 = null;
			chart2.YData5 = null;
			chart2.YGrid = 20D;
			chart2.YLabel = "0";
			chart2.YRangeEnd = 100D;
			chart2.YRangeStart = 0D;
			// 
			// chart3
			// 
			chart3.BackColor = System.Drawing.SystemColors.Control;
			chart3.BorderBottom = 25;
			chart3.BorderTop = 20;
			chart3.ColorAxis = System.Drawing.Color.Black;
			chart3.ColorBg = System.Drawing.SystemColors.Control;
			chart3.ColorGrid = System.Drawing.Color.Gray;
			chart3.ColorSet1 = System.Drawing.Color.Lime;
			chart3.ColorSet2 = System.Drawing.Color.Red;
			chart3.ColorSet3 = System.Drawing.Color.DarkBlue;
			chart3.ColorSet4 = System.Drawing.Color.Gold;
			chart3.ColorSet5 = System.Drawing.Color.Magenta;
			chart3.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			chart3.FontAxis = new System.Drawing.Font("Arial", 8F);
			chart3.Location = new System.Drawing.Point(0, 288);
			chart3.Name = "chart3";
			chart3.ShowData1 = true;
			chart3.ShowData2 = false;
			chart3.ShowData3 = false;
			chart3.ShowData4 = false;
			chart3.ShowData5 = false;
			chart3.Size = new System.Drawing.Size(316, 160);
			chart3.TabIndex = 4;
			chart3.XData1 = null;
			chart3.XData2 = null;
			chart3.XData3 = null;
			chart3.XData4 = null;
			chart3.XData5 = null;
			chart3.XGrid = 10D;
			chart3.XLabel = "0";
			chart3.XRangeEnd = 30D;
			chart3.XRangeStart = 0D;
			chart3.YData1 = null;
			chart3.YData2 = null;
			chart3.YData3 = null;
			chart3.YData4 = null;
			chart3.YData5 = null;
			chart3.YGrid = 20D;
			chart3.YLabel = "0";
			chart3.YRangeEnd = 100D;
			chart3.YRangeStart = 0D;
			// 
			// chart4
			// 
			chart4.BackColor = System.Drawing.SystemColors.Control;
			chart4.BorderBottom = 25;
			chart4.BorderTop = 20;
			chart4.ColorAxis = System.Drawing.Color.Black;
			chart4.ColorBg = System.Drawing.SystemColors.Control;
			chart4.ColorGrid = System.Drawing.Color.Gray;
			chart4.ColorSet1 = System.Drawing.Color.Magenta;
			chart4.ColorSet2 = System.Drawing.Color.Red;
			chart4.ColorSet3 = System.Drawing.Color.Lime;
			chart4.ColorSet4 = System.Drawing.Color.Gold;
			chart4.ColorSet5 = System.Drawing.Color.DarkBlue;
			chart4.DrawMode = DGChart.DGChartControl.DrawModeType.Line;
			chart4.FontAxis = new System.Drawing.Font("Arial", 8F);
			chart4.Location = new System.Drawing.Point(316, 288);
			chart4.Name = "chart4";
			chart4.ShowData1 = true;
			chart4.ShowData2 = false;
			chart4.ShowData3 = false;
			chart4.ShowData4 = false;
			chart4.ShowData5 = false;
			chart4.Size = new System.Drawing.Size(316, 160);
			chart4.TabIndex = 5;
			chart4.XData1 = null;
			chart4.XData2 = null;
			chart4.XData3 = null;
			chart4.XData4 = null;
			chart4.XData5 = null;
			chart4.XGrid = 10D;
			chart4.XLabel = "0";
			chart4.XRangeEnd = 30D;
			chart4.XRangeStart = 0D;
			chart4.YData1 = null;
			chart4.YData2 = null;
			chart4.YData3 = null;
			chart4.YData4 = null;
			chart4.YData5 = null;
			chart4.YGrid = 20D;
			chart4.YLabel = "0";
			chart4.YRangeEnd = 100D;
			chart4.YRangeStart = 0D;
			// 
			// groupSetup
			// 
			groupSetup.Controls.Add(comboStyle4);
			groupSetup.Controls.Add(comboStyle3);
			groupSetup.Controls.Add(comboStyle2);
			groupSetup.Controls.Add(comboStyle1);
			groupSetup.Controls.Add(comboUnits4);
			groupSetup.Controls.Add(comboUnits3);
			groupSetup.Controls.Add(comboUnits2);
			groupSetup.Controls.Add(comboUnits1);
			groupSetup.Controls.Add(chkSensor4);
			groupSetup.Controls.Add(chkSensor3);
			groupSetup.Controls.Add(chkSensor2);
			groupSetup.Controls.Add(chkSensor1);
			groupSetup.Controls.Add(comboSensor4);
			groupSetup.Controls.Add(comboSensor3);
			groupSetup.Controls.Add(comboSensor2);
			groupSetup.Controls.Add(comboSensor1);
			groupSetup.Location = new System.Drawing.Point(8, 8);
			groupSetup.Name = "groupSetup";
			groupSetup.Size = new System.Drawing.Size(496, 120);
			groupSetup.TabIndex = 6;
			groupSetup.TabStop = false;
			groupSetup.Text = "Setup";
			// 
			// comboStyle4
			// 
			comboStyle4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboStyle4.Enabled = false;
			comboStyle4.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			comboStyle4.Location = new System.Drawing.Point(410, 86);
			comboStyle4.Name = "comboStyle4";
			comboStyle4.Size = new System.Drawing.Size(75, 21);
			comboStyle4.TabIndex = 20;
			comboStyle4.SelectedIndexChanged += new System.EventHandler(comboStyle4_SelectedIndexChanged);
			// 
			// comboStyle3
			// 
			comboStyle3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboStyle3.Enabled = false;
			comboStyle3.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			comboStyle3.Location = new System.Drawing.Point(410, 64);
			comboStyle3.Name = "comboStyle3";
			comboStyle3.Size = new System.Drawing.Size(75, 21);
			comboStyle3.TabIndex = 19;
			comboStyle3.SelectedIndexChanged += new System.EventHandler(comboStyle3_SelectedIndexChanged);
			// 
			// comboStyle2
			// 
			comboStyle2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboStyle2.Enabled = false;
			comboStyle2.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			comboStyle2.Location = new System.Drawing.Point(410, 42);
			comboStyle2.Name = "comboStyle2";
			comboStyle2.Size = new System.Drawing.Size(75, 21);
			comboStyle2.TabIndex = 18;
			comboStyle2.SelectedIndexChanged += new System.EventHandler(comboStyle2_SelectedIndexChanged);
			// 
			// comboStyle1
			// 
			comboStyle1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboStyle1.Enabled = false;
			comboStyle1.Items.AddRange(new object[] {
            "Line",
            "Dot",
            "Bar"});
			comboStyle1.Location = new System.Drawing.Point(410, 20);
			comboStyle1.Name = "comboStyle1";
			comboStyle1.Size = new System.Drawing.Size(75, 21);
			comboStyle1.TabIndex = 17;
			comboStyle1.SelectedIndexChanged += new System.EventHandler(comboStyle1_SelectedIndexChanged);
			// 
			// comboUnits4
			// 
			comboUnits4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboUnits4.Enabled = false;
			comboUnits4.Items.AddRange(new object[] {
            "English",
            "Metric"});
			comboUnits4.Location = new System.Drawing.Point(300, 86);
			comboUnits4.Name = "comboUnits4";
			comboUnits4.Size = new System.Drawing.Size(100, 21);
			comboUnits4.TabIndex = 16;
			comboUnits4.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits4_SelectedIndexChanged);
			// 
			// comboUnits3
			// 
			comboUnits3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboUnits3.Enabled = false;
			comboUnits3.Items.AddRange(new object[] {
            "English",
            "Metric"});
			comboUnits3.Location = new System.Drawing.Point(300, 64);
			comboUnits3.Name = "comboUnits3";
			comboUnits3.Size = new System.Drawing.Size(100, 21);
			comboUnits3.TabIndex = 15;
			comboUnits3.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits3_SelectedIndexChanged);
			// 
			// comboUnits2
			// 
			comboUnits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboUnits2.Enabled = false;
			comboUnits2.Items.AddRange(new object[] {
            "English",
            "Metric"});
			comboUnits2.Location = new System.Drawing.Point(300, 42);
			comboUnits2.Name = "comboUnits2";
			comboUnits2.Size = new System.Drawing.Size(100, 21);
			comboUnits2.TabIndex = 14;
			comboUnits2.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits2_SelectedIndexChanged);
			// 
			// comboUnits1
			// 
			comboUnits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboUnits1.Enabled = false;
			comboUnits1.Items.AddRange(new object[] {
            "English",
            "Metric"});
			comboUnits1.Location = new System.Drawing.Point(300, 20);
			comboUnits1.Name = "comboUnits1";
			comboUnits1.Size = new System.Drawing.Size(100, 21);
			comboUnits1.TabIndex = 13;
			comboUnits1.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits1_SelectedIndexChanged);
			// 
			// chkSensor4
			// 
			chkSensor4.Enabled = false;
			chkSensor4.Location = new System.Drawing.Point(10, 86);
			chkSensor4.Name = "chkSensor4";
			chkSensor4.Size = new System.Drawing.Size(80, 20);
			chkSensor4.TabIndex = 12;
			chkSensor4.Text = "Sensor &4:";
			chkSensor4.CheckStateChanged += new System.EventHandler(chkSensor4_CheckedChanged);
			chkSensor4.EnabledChanged += new System.EventHandler(chkSensor4_EnabledChanged);
			// 
			// chkSensor3
			// 
			chkSensor3.Enabled = false;
			chkSensor3.Location = new System.Drawing.Point(10, 64);
			chkSensor3.Name = "chkSensor3";
			chkSensor3.Size = new System.Drawing.Size(80, 20);
			chkSensor3.TabIndex = 11;
			chkSensor3.Text = "Sensor &3:";
			chkSensor3.CheckStateChanged += new System.EventHandler(chkSensor3_CheckedChanged);
			chkSensor3.EnabledChanged += new System.EventHandler(chkSensor3_EnabledChanged);
			// 
			// chkSensor2
			// 
			chkSensor2.Enabled = false;
			chkSensor2.Location = new System.Drawing.Point(10, 42);
			chkSensor2.Name = "chkSensor2";
			chkSensor2.Size = new System.Drawing.Size(80, 20);
			chkSensor2.TabIndex = 10;
			chkSensor2.Text = "Sensor &2:";
			chkSensor2.CheckStateChanged += new System.EventHandler(chkSensor2_CheckedChanged);
			chkSensor2.EnabledChanged += new System.EventHandler(chkSensor2_EnabledChanged);
			// 
			// chkSensor1
			// 
			chkSensor1.Location = new System.Drawing.Point(10, 20);
			chkSensor1.Name = "chkSensor1";
			chkSensor1.Size = new System.Drawing.Size(80, 20);
			chkSensor1.TabIndex = 9;
			chkSensor1.Text = "Sensor &1:";
			chkSensor1.CheckedChanged += new System.EventHandler(chkSensor1_CheckedChanged);
			chkSensor1.EnabledChanged += new System.EventHandler(chkSensor1_EnabledChanged);
			// 
			// comboSensor4
			// 
			comboSensor4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboSensor4.Enabled = false;
			comboSensor4.Location = new System.Drawing.Point(90, 86);
			comboSensor4.Name = "comboSensor4";
			comboSensor4.Size = new System.Drawing.Size(200, 21);
			comboSensor4.TabIndex = 7;
			comboSensor4.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits4_SelectedIndexChanged);
			// 
			// comboSensor3
			// 
			comboSensor3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboSensor3.Enabled = false;
			comboSensor3.Location = new System.Drawing.Point(90, 64);
			comboSensor3.Name = "comboSensor3";
			comboSensor3.Size = new System.Drawing.Size(200, 21);
			comboSensor3.TabIndex = 5;
			comboSensor3.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits3_SelectedIndexChanged);
			// 
			// comboSensor2
			// 
			comboSensor2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboSensor2.Enabled = false;
			comboSensor2.Location = new System.Drawing.Point(90, 42);
			comboSensor2.Name = "comboSensor2";
			comboSensor2.Size = new System.Drawing.Size(200, 21);
			comboSensor2.TabIndex = 3;
			comboSensor2.SelectedIndexChanged += new System.EventHandler(comboSensorOrUnits2_SelectedIndexChanged);
			// 
			// groupControl
			// 
			groupControl.Controls.Add(btnStop);
			groupControl.Controls.Add(btnStart);
			groupControl.Controls.Add(numHistory);
			groupControl.Controls.Add(lblHistory);
			groupControl.Location = new System.Drawing.Point(512, 8);
			groupControl.Name = "groupControl";
			groupControl.Size = new System.Drawing.Size(112, 120);
			groupControl.TabIndex = 7;
			groupControl.TabStop = false;
			groupControl.Text = "Control";
			// 
			// btnStop
			// 
			btnStop.Enabled = false;
			btnStop.Location = new System.Drawing.Point(10, 86);
			btnStop.Name = "btnStop";
			btnStop.Size = new System.Drawing.Size(92, 20);
			btnStop.TabIndex = 4;
			btnStop.Text = "S&top";
			btnStop.Click += new System.EventHandler(btnStop_Click);
			// 
			// btnStart
			// 
			btnStart.Location = new System.Drawing.Point(10, 64);
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(92, 20);
			btnStart.TabIndex = 3;
			btnStart.Text = "&Start";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			// 
			// numHistory
			// 
			numHistory.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			numHistory.Location = new System.Drawing.Point(10, 42);
			numHistory.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			numHistory.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			numHistory.Name = "numHistory";
			numHistory.ReadOnly = true;
			numHistory.Size = new System.Drawing.Size(92, 20);
			numHistory.TabIndex = 1;
			numHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			numHistory.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			numHistory.ValueChanged += new System.EventHandler(numHistory_ValueChanged);
			// 
			// lblHistory
			// 
			lblHistory.Location = new System.Drawing.Point(6, 20);
			lblHistory.Name = "lblHistory";
			lblHistory.Size = new System.Drawing.Size(100, 20);
			lblHistory.TabIndex = 0;
			lblHistory.Text = "&History (secs):";
			lblHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ScopeForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(634, 448);
			ControlBox = false;
			Controls.Add(groupControl);
			Controls.Add(groupSetup);
			Controls.Add(chart4);
			Controls.Add(chart3);
			Controls.Add(chart2);
			Controls.Add(chart1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ScopeForm";
			ShowInTaskbar = false;
			Text = "Live Sensor Graphs";
			Activated += new System.EventHandler(ScopeForm_Activated);
			Load += new System.EventHandler(ScopeForm_Load);
			Resize += new System.EventHandler(ScopeForm_Resize);
			groupSetup.ResumeLayout(false);
			groupControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(numHistory)).EndInit();
			ResumeLayout(false);

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
				m_isPlotting = true;
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
			m_isPlotting = false;
			btnStart.Enabled = true;
			btnStop.Enabled = false;
		}

		private void ScopeForm_Load(object sender, EventArgs e)
		{
			m_isPlotting = false;
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
			m_arraySensor1Values = new ArrayList();
			m_arraySensor2Values = new ArrayList();
			m_arraySensor3Values = new ArrayList();
			m_arraySensor4Values = new ArrayList();
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
			if (m_obdInterface.getConnectedStatus())
			{
				if (!isConnected)
				{
					isConnected = true;
					if (!m_isPlotting)
						btnStart.Enabled = true;
					comboSensor1.Items.Clear();
					comboSensor2.Items.Clear();
					comboSensor3.Items.Clear();
					comboSensor4.Items.Clear();
					IEnumerator enumerator = m_obdInterface.getSupportedParameterList(1).GetEnumerator();
					if (enumerator.MoveNext())
					{
						do
						{
							OBDParameter obdParameter = (OBDParameter)enumerator.Current;
							comboSensor1.Items.Add((object)obdParameter);
							comboSensor2.Items.Add((object)obdParameter);
							comboSensor3.Items.Add((object)obdParameter);
							comboSensor4.Items.Add((object)obdParameter);
						}
						while (enumerator.MoveNext());
					}
				}
				return true;
			}
			else
			{
				isConnected = false;
				m_isPlotting = false;
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
			if (!m_isPlotting)
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
							MyScopeForm.m_arraySensor1Values.Add((object)new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart1();
						}
					}
					if (chkSensor2.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor2.Items[comboSensor2.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor2Values.Add((object)new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart2();
						}
					}
					if (chkSensor3.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor3.Items[comboSensor3.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor3Values.Add((object)new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart3();
						}
					}
					if (chkSensor4.Checked)
					{
						OBDParameterValue obdParameterValue = m_obdInterface.getValue(comboSensor4.Items[comboSensor4.SelectedIndex] as OBDParameter, bEnglishUnits);
						if (!obdParameterValue.ErrorDetected)
						{
							MyScopeForm.m_arraySensor4Values.Add((object)new DatedValue(obdParameterValue.DoubleValue));
							UpdateChart4();
						}
					}
				}
			}
			while (m_isPlotting);
		}

		public void UpdateChart1()
		{
			int index1 = 0;
			if (0 < m_arraySensor1Values.Count)
			{
				do
				{
					if (DateTime.Now.Subtract((m_arraySensor1Values[index1] as DatedValue).Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
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
			m_dSensor1Max = (m_arraySensor1Values[0] as DatedValue).Value;
			m_dSensor1Min = (m_arraySensor1Values[0] as DatedValue).Value;
			int index2 = 0;
			if (0 < m_arraySensor1Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor1Values[index2] as DatedValue;
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
					if (DateTime.Now.Subtract((m_arraySensor2Values[index1] as DatedValue).Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
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
			m_dSensor2Max = (m_arraySensor2Values[0] as DatedValue).Value;
			m_dSensor2Min = (m_arraySensor2Values[0] as DatedValue).Value;
			int index2 = 0;
			if (0 < m_arraySensor2Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor2Values[index2] as DatedValue;
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
					if (DateTime.Now.Subtract((m_arraySensor3Values[index1] as DatedValue).Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
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
			m_dSensor3Max = (m_arraySensor3Values[0] as DatedValue).Value;
			m_dSensor3Min = (m_arraySensor3Values[0] as DatedValue).Value;
			int index2 = 0;
			if (0 < m_arraySensor3Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor3Values[index2] as DatedValue;
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
					if (DateTime.Now.Subtract((m_arraySensor4Values[index1] as DatedValue).Date).TotalSeconds > (double)Convert.ToInt32(numHistory.Value))
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
			m_dSensor4Max = (m_arraySensor4Values[0] as DatedValue).Value;
			m_dSensor4Min = (m_arraySensor4Values[0] as DatedValue).Value;
			int index2 = 0;
			if (0 < m_arraySensor4Values.Count)
			{
				do
				{
					DatedValue datedValue = m_arraySensor4Values[index2] as DatedValue;
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
