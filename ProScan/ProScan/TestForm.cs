using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class TestForm : Form
	{
		private DataGrid gridConTests;
		private DataGrid gridNonConTests;
		private OBDInterface m_obd2Interface;
		private static ArrayList m_arrayListConTests;
		private static ArrayList m_arrayListNonConTests;
		private GroupBox groupConTests;
		private GroupBox groupNonConTests;
		private GroupBox groupFuel1;
		private Label lblFuel1;
		private GroupBox groupFuel2;
		private Label lblFuel2;
		private GroupBox groupPTO;
		private Label lblPTO;
		private GroupBox groupAir;
		private Label lblAir;
		private GroupBox groupOBD;
		private Label lblOBD;
		private GroupBox groupOxygen;
		private Label lblOxygen;
		private Button btnUpdate;
		private ProgressBar progressBar;
		private Label lblBattery;
		private GroupBox groupBattery;
		private Container components;

		static TestForm()
		{
		}

		public TestForm(OBDInterface obd2)
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
			groupConTests = new System.Windows.Forms.GroupBox();
			gridConTests = new System.Windows.Forms.DataGrid();
			groupNonConTests = new System.Windows.Forms.GroupBox();
			gridNonConTests = new System.Windows.Forms.DataGrid();
			groupFuel1 = new System.Windows.Forms.GroupBox();
			lblFuel1 = new System.Windows.Forms.Label();
			groupFuel2 = new System.Windows.Forms.GroupBox();
			lblFuel2 = new System.Windows.Forms.Label();
			groupPTO = new System.Windows.Forms.GroupBox();
			lblPTO = new System.Windows.Forms.Label();
			groupAir = new System.Windows.Forms.GroupBox();
			lblAir = new System.Windows.Forms.Label();
			groupOBD = new System.Windows.Forms.GroupBox();
			lblOBD = new System.Windows.Forms.Label();
			groupOxygen = new System.Windows.Forms.GroupBox();
			lblOxygen = new System.Windows.Forms.Label();
			btnUpdate = new System.Windows.Forms.Button();
			progressBar = new System.Windows.Forms.ProgressBar();
			groupBattery = new System.Windows.Forms.GroupBox();
			lblBattery = new System.Windows.Forms.Label();
			groupConTests.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(gridConTests)).BeginInit();
			groupNonConTests.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(gridNonConTests)).BeginInit();
			groupFuel1.SuspendLayout();
			groupFuel2.SuspendLayout();
			groupPTO.SuspendLayout();
			groupAir.SuspendLayout();
			groupOBD.SuspendLayout();
			groupOxygen.SuspendLayout();
			groupBattery.SuspendLayout();
			SuspendLayout();
			// 
			// groupConTests
			// 
			groupConTests.Controls.Add(gridConTests);
			groupConTests.Location = new System.Drawing.Point(10, 45);
			groupConTests.Name = "groupConTests";
			groupConTests.Size = new System.Drawing.Size(250, 140);
			groupConTests.TabIndex = 0;
			groupConTests.TabStop = false;
			groupConTests.Text = "Continuous Tests";
			// 
			// gridConTests
			// 
			gridConTests.CaptionVisible = false;
			gridConTests.DataMember = "";
			gridConTests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			gridConTests.Location = new System.Drawing.Point(10, 20);
			gridConTests.Name = "gridConTests";
			gridConTests.RowHeadersVisible = false;
			gridConTests.Size = new System.Drawing.Size(230, 110);
			gridConTests.TabIndex = 0;
			// 
			// groupNonConTests
			// 
			groupNonConTests.Controls.Add(gridNonConTests);
			groupNonConTests.Location = new System.Drawing.Point(270, 45);
			groupNonConTests.Name = "groupNonConTests";
			groupNonConTests.Size = new System.Drawing.Size(250, 203);
			groupNonConTests.TabIndex = 1;
			groupNonConTests.TabStop = false;
			groupNonConTests.Text = "Non-Continuous Tests";
			// 
			// gridNonConTests
			// 
			gridNonConTests.CaptionVisible = false;
			gridNonConTests.DataMember = "";
			gridNonConTests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			gridNonConTests.Location = new System.Drawing.Point(10, 20);
			gridNonConTests.Name = "gridNonConTests";
			gridNonConTests.RowHeadersVisible = false;
			gridNonConTests.Size = new System.Drawing.Size(230, 174);
			gridNonConTests.TabIndex = 1;
			// 
			// groupFuel1
			// 
			groupFuel1.Controls.Add(lblFuel1);
			groupFuel1.Location = new System.Drawing.Point(10, 192);
			groupFuel1.Name = "groupFuel1";
			groupFuel1.Size = new System.Drawing.Size(250, 56);
			groupFuel1.TabIndex = 2;
			groupFuel1.TabStop = false;
			groupFuel1.Text = "Fuel System #1";
			// 
			// lblFuel1
			// 
			lblFuel1.Location = new System.Drawing.Point(10, 20);
			lblFuel1.Name = "lblFuel1";
			lblFuel1.Size = new System.Drawing.Size(230, 28);
			lblFuel1.TabIndex = 0;
			lblFuel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupFuel2
			// 
			groupFuel2.Controls.Add(lblFuel2);
			groupFuel2.Location = new System.Drawing.Point(10, 256);
			groupFuel2.Name = "groupFuel2";
			groupFuel2.Size = new System.Drawing.Size(250, 60);
			groupFuel2.TabIndex = 3;
			groupFuel2.TabStop = false;
			groupFuel2.Text = "Fuel System #2";
			// 
			// lblFuel2
			// 
			lblFuel2.Location = new System.Drawing.Point(10, 20);
			lblFuel2.Name = "lblFuel2";
			lblFuel2.Size = new System.Drawing.Size(230, 28);
			lblFuel2.TabIndex = 0;
			lblFuel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupPTO
			// 
			groupPTO.Controls.Add(lblPTO);
			groupPTO.Location = new System.Drawing.Point(10, 323);
			groupPTO.Name = "groupPTO";
			groupPTO.Size = new System.Drawing.Size(250, 56);
			groupPTO.TabIndex = 4;
			groupPTO.TabStop = false;
			groupPTO.Text = "Power Take Off";
			// 
			// lblPTO
			// 
			lblPTO.Location = new System.Drawing.Point(10, 20);
			lblPTO.Name = "lblPTO";
			lblPTO.Size = new System.Drawing.Size(230, 28);
			lblPTO.TabIndex = 0;
			lblPTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupAir
			// 
			groupAir.Controls.Add(lblAir);
			groupAir.Location = new System.Drawing.Point(10, 387);
			groupAir.Name = "groupAir";
			groupAir.Size = new System.Drawing.Size(250, 63);
			groupAir.TabIndex = 5;
			groupAir.TabStop = false;
			groupAir.Text = "Commanded Secondary Air";
			// 
			// lblAir
			// 
			lblAir.Location = new System.Drawing.Point(10, 20);
			lblAir.Name = "lblAir";
			lblAir.Size = new System.Drawing.Size(230, 28);
			lblAir.TabIndex = 0;
			lblAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupOBD
			// 
			groupOBD.Controls.Add(lblOBD);
			groupOBD.Location = new System.Drawing.Point(270, 256);
			groupOBD.Name = "groupOBD";
			groupOBD.Size = new System.Drawing.Size(250, 60);
			groupOBD.TabIndex = 6;
			groupOBD.TabStop = false;
			groupOBD.Text = "Vehicle OBD Requirements";
			// 
			// lblOBD
			// 
			lblOBD.Location = new System.Drawing.Point(10, 20);
			lblOBD.Name = "lblOBD";
			lblOBD.Size = new System.Drawing.Size(230, 28);
			lblOBD.TabIndex = 0;
			lblOBD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupOxygen
			// 
			groupOxygen.Controls.Add(lblOxygen);
			groupOxygen.Location = new System.Drawing.Point(272, 323);
			groupOxygen.Name = "groupOxygen";
			groupOxygen.Size = new System.Drawing.Size(250, 127);
			groupOxygen.TabIndex = 7;
			groupOxygen.TabStop = false;
			groupOxygen.Text = "Oxygen Sensor Locations";
			// 
			// lblOxygen
			// 
			lblOxygen.Location = new System.Drawing.Point(10, 20);
			lblOxygen.Name = "lblOxygen";
			lblOxygen.Size = new System.Drawing.Size(230, 100);
			lblOxygen.TabIndex = 0;
			lblOxygen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnUpdate
			// 
			btnUpdate.Location = new System.Drawing.Point(10, 10);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new System.Drawing.Size(75, 23);
			btnUpdate.TabIndex = 9;
			btnUpdate.Text = "&Update";
			btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
			// 
			// progressBar
			// 
			progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			progressBar.Location = new System.Drawing.Point(95, 10);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(425, 23);
			progressBar.TabIndex = 10;
			// 
			// groupBattery
			// 
			groupBattery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			groupBattery.Controls.Add(lblBattery);
			groupBattery.Location = new System.Drawing.Point(10, 458);
			groupBattery.Name = "groupBattery";
			groupBattery.Size = new System.Drawing.Size(512, 47);
			groupBattery.TabIndex = 11;
			groupBattery.TabStop = false;
			groupBattery.Text = "Battery Voltage";
			// 
			// lblBattery
			// 
			lblBattery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			lblBattery.Location = new System.Drawing.Point(9, 17);
			lblBattery.Name = "lblBattery";
			lblBattery.Size = new System.Drawing.Size(489, 23);
			lblBattery.TabIndex = 0;
			lblBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TestForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(527, 511);
			ControlBox = false;
			Controls.Add(groupBattery);
			Controls.Add(progressBar);
			Controls.Add(btnUpdate);
			Controls.Add(groupOxygen);
			Controls.Add(groupOBD);
			Controls.Add(groupAir);
			Controls.Add(groupPTO);
			Controls.Add(groupFuel2);
			Controls.Add(groupFuel1);
			Controls.Add(groupNonConTests);
			Controls.Add(groupConTests);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TestForm";
			Text = "Vehicle Status Monitor";
			Load += new System.EventHandler(TestForm_Load);
			Resize += new System.EventHandler(TestForm_Resize);
			groupConTests.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(gridConTests)).EndInit();
			groupNonConTests.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(gridNonConTests)).EndInit();
			groupFuel1.ResumeLayout(false);
			groupFuel2.ResumeLayout(false);
			groupPTO.ResumeLayout(false);
			groupAir.ResumeLayout(false);
			groupOBD.ResumeLayout(false);
			groupOxygen.ResumeLayout(false);
			groupBattery.ResumeLayout(false);
			ResumeLayout(false);

		}

		private void TestForm_Resize(object sender, EventArgs e)
		{
			groupConTests.Width = Width / 2 - 17;
			groupConTests.Height = Height - 410;
			gridConTests.Width = groupConTests.Width - 20;
			gridConTests.Height = groupConTests.Height - 30;
			groupNonConTests.Location = new Point(groupConTests.Width + 20, 45);
			groupNonConTests.Width = groupConTests.Width;
			groupNonConTests.Height = Height - 340;
			gridNonConTests.Width = groupNonConTests.Width - 20;
			gridNonConTests.Height = groupNonConTests.Height - 30;
			groupFuel1.Location = new Point(10, groupConTests.Location.Y + groupConTests.Height + 7);
			groupFuel1.Width = groupConTests.Width;
			lblFuel1.Width = groupFuel1.Width - 20;
			groupFuel2.Location = new Point(10, groupFuel1.Location.Y + groupFuel1.Height + 10);
			groupFuel2.Width = groupConTests.Width;
			lblFuel2.Width = groupFuel2.Width - 20;
			groupPTO.Location = new Point(10, groupFuel2.Location.Y + groupFuel2.Height + 10);
			groupPTO.Width = groupConTests.Width;
			lblPTO.Width = groupPTO.Width - 20;
			groupAir.Location = new Point(10, groupPTO.Location.Y + groupPTO.Height + 10);
			groupAir.Width = groupConTests.Width;
			lblAir.Width = groupAir.Width - 20;
			groupOBD.Location = new Point(groupNonConTests.Location.X, groupNonConTests.Location.Y + groupNonConTests.Height + 7);
			groupOBD.Width = groupNonConTests.Width;
			lblOBD.Width = groupOBD.Width - 20;
			groupOxygen.Location = new Point(groupNonConTests.Location.X, groupOBD.Location.Y + groupOBD.Height + 10);
			groupOxygen.Width = groupNonConTests.Width;
			lblOxygen.Width = groupOxygen.Width - 20;
			groupBattery.Location = new Point(10, groupOxygen.Location.Y + groupOxygen.Height + 7);
			groupBattery.Width = Width - 23;
		}

		private void TestForm_Load(object sender, EventArgs e)
		{
			TestForm.m_arrayListConTests = getContinuousTestList();
			TestForm.m_arrayListNonConTests = getNonContinuousTestList();
			gridConTests.DataSource = TestForm.m_arrayListConTests;
			gridNonConTests.DataSource = TestForm.m_arrayListNonConTests;
			gridConTests.TableStyles.Clear();
			gridConTests.TableStyles.Add(getTableStyle());
			gridNonConTests.TableStyles.Clear();
			gridNonConTests.TableStyles.Add(getTableStyle());
		}

		private ArrayList getContinuousTestList()
		{
			ArrayList list = new ArrayList();
			list.Add(new TestStatus("Misfire", "", 2, 5));
			list.Add(new TestStatus("Fuel System", "", 3, 6));
			list.Add(new TestStatus("Comprehensive Component", "", 4, 7));
			return list;
		}

		private ArrayList getNonContinuousTestList()
		{
			ArrayList list = new ArrayList();
			list.Add(new TestStatus("Catalyst", "", 8, 0x10));
			list.Add(new TestStatus("Heated Catalyst", "", 9, 0x11));
			list.Add(new TestStatus("Evaporative System", "", 10, 0x12));
			list.Add(new TestStatus("Secondary Air System", "", 11, 0x13));
			list.Add(new TestStatus("A/C System Refrigerant", "", 12, 20));
			list.Add(new TestStatus("Oxygen Sensor", "", 13, 0x15));
			list.Add(new TestStatus("Oxygen Sensor Heater", "", 14, 0x16));
			list.Add(new TestStatus("EGR System", "", 15, 0x17));
			return list;
		}

		public void CheckConnection()
		{
			if (!m_obd2Interface.getConnectedStatus())
				return;
			UpdateTests();
		}

		public DataGridTableStyle getTableStyle()
		{
			DataGridTableStyle style = new DataGridTableStyle();
			style.MappingName = "ArrayList";

			DataGridTextBoxColumn column = new DataGridTextBoxColumn();
			column.MappingName = "Name";
			column.HeaderText = "Name";
			column.Format = "f4";
			column.Width = 150;
			style.GridColumnStyles.Add(column);

			column = new DataGridTextBoxColumn();
			column.MappingName = "Status";
			column.HeaderText = "Completed";
			column.Format = "f4";
			column.Width = 85;
			style.GridColumnStyles.Add(column);

			column = new DataGridTextBoxColumn();
			column.MappingName = "SupportID";
			column.HeaderText = "SupportID";
			column.Format = "d";
			column.Width = 25;
			style.GridColumnStyles.Add(column);

			column = new DataGridTextBoxColumn();
			column.MappingName = "StatusID";
			column.HeaderText = "StatusID";
			column.Format = "d";
			column.Width = 25;
			style.GridColumnStyles.Add(column);

			return style;
		}

		public void UpdateTests()
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 25;
			gridConTests.Visible = false;
			gridNonConTests.Visible = false;
			OBDParameterValue value;
			value = m_obd2Interface.getValue("SAE.MISFIRE_SUPPORT", true);
			progressBar.Value = 1;
			TestStatus status = m_arrayListConTests[0] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.MISFIRE_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.FUEL_SUPPORT", true);
			progressBar.Value = 2;
			status = m_arrayListConTests[1] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.FUEL_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.CCM_SUPPORT", true);
			progressBar.Value = 3;
			status = m_arrayListConTests[2] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.CCM_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.CAT_SUPPORT", true);
			progressBar.Value = 4;
			status = m_arrayListNonConTests[0] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.CAT_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.HCAT_SUPPORT", true);
			progressBar.Value = 5;
			status = m_arrayListNonConTests[1] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.HCAT_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.EVAP_SUPPORT", true);
			progressBar.Value = 6;
			status = m_arrayListNonConTests[2] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.EVAP_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.AIR_SUPPORT", true);
			progressBar.Value = 7;
			status = m_arrayListNonConTests[3] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.AIR_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.AC_SUPPORT", true);
			progressBar.Value = 8;
			status = m_arrayListNonConTests[4] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.AC_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.O2_SUPPORT", true);
			progressBar.Value = 9;
			status = m_arrayListNonConTests[5] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.O2_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.O2HTR_SUPPORT", true);
			progressBar.Value = 10;
			status = m_arrayListNonConTests[6] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.O2HTR_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			value = m_obd2Interface.getValue("SAE.EGR_SUPPORT", true);
			progressBar.Value = 11;
			status = m_arrayListNonConTests[7] as TestStatus;
			if (!value.ErrorDetected)
			{
				if (!value.BoolValue)
					status.Status = "Not Supported";
				else
				{
					value = m_obd2Interface.getValue("SAE.EGR_STATUS", true);
					if (!value.ErrorDetected)
						status.Status = value.BoolValue ? "Complete" : "Incomplete";
					else
						status.Status = "ERROR";
				}
			}
			else
				status.Status = "ERROR";

			gridConTests.Visible = true;
			gridNonConTests.Visible = true;
			if (m_obd2Interface.isParameterSupported("SAE.FUEL1_STATUS"))
			{
				value = m_obd2Interface.getValue("SAE.FUEL1_STATUS", true);
				progressBar.Value++;
				lblFuel1.Text = value.ErrorDetected ? "ERROR" : value.StringValue;
			}
			else
				lblFuel1.Text = "Not Supported";

			if (m_obd2Interface.isParameterSupported("SAE.FUEL2_STATUS"))
			{
				value = m_obd2Interface.getValue("SAE.FUEL2_STATUS", true);
				progressBar.Value++;
				lblFuel2.Text = value.ErrorDetected ? "ERROR" : value.StringValue;
			}
			else
				lblFuel2.Text = "Not Supported";

			if (m_obd2Interface.isParameterSupported("SAE.PTO_STATUS"))
			{
				value = m_obd2Interface.getValue("SAE.PTO_STATUS", true);
				progressBar.Value++;
				lblPTO.Text = value.ErrorDetected ? "ERROR" : value.StringValue;
			}
			else
				lblPTO.Text = "Not Supported";

			if (m_obd2Interface.isParameterSupported("SAE.SECAIR_STATUS"))
			{
				value = m_obd2Interface.getValue("SAE.SECAIR_STATUS", true);
				progressBar.Value++;
				lblAir.Text = value.ErrorDetected ? "ERROR" : value.StringValue;
			}
			else
				lblAir.Text = "Not Supported";

			if (m_obd2Interface.isParameterSupported("SAE.OBD_TYPE"))
			{
				value = m_obd2Interface.getValue("SAE.OBD_TYPE", true);
				progressBar.Value++;
				lblOBD.Text = value.ErrorDetected ? "ERROR" : value.StringValue;
			}
			else
				lblOBD.Text = "Not Supported";

			string str = "";
			if (m_obd2Interface.isParameterSupported("SAE.O2B1S1A_PRESENT"))
			{
				value = m_obd2Interface.getValue("SAE.O2B1S1A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 1 Sensor 1\n";

				value = m_obd2Interface.getValue("SAE.O2B1S2A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 1 Sensor 2\n";

				value = m_obd2Interface.getValue("SAE.O2B1S3A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 1 Sensor 3\n";

				value = m_obd2Interface.getValue("SAE.O2B1S4A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 1 Sensor 4\n";

				value = m_obd2Interface.getValue("SAE.O2B2S1A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 2 Sensor 1\n";

				value = m_obd2Interface.getValue("SAE.O2B2S2A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 2 Sensor 2\n";

				value = m_obd2Interface.getValue("SAE.O2B2S3A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 2 Sensor 3\n";

				value = m_obd2Interface.getValue("SAE.O2B2S4A_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 2 Sensor 4\n";
			}

			if (m_obd2Interface.isParameterSupported("SAE.O2B1S1B_PRESENT"))
			{
				value = m_obd2Interface.getValue("SAE.O2B1S1B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 1 Sensor 1\n";

				value = m_obd2Interface.getValue("SAE.O2B1S2B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 1 Sensor 2\n";

				value = m_obd2Interface.getValue("SAE.O2B2S1B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 2 Sensor 1\n";

				value = m_obd2Interface.getValue("SAE.O2B2S2B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 2 Sensor 2\n";

				value = m_obd2Interface.getValue("SAE.O2B3S1B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 3 Sensor 1\n";

				value = m_obd2Interface.getValue("SAE.O2B3S2B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 3 Sensor 2\n";

				value = m_obd2Interface.getValue("SAE.O2B4S1B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 4 Sensor 1\n";

				value = m_obd2Interface.getValue("SAE.O2B4S2B_PRESENT", true);
				progressBar.Value++;
				if (!value.ErrorDetected && value.BoolValue)
					str = str + "Bank 4 Sensor 2\n";
			}
			lblOxygen.Text = str;
			progressBar.Value++;
			if (m_obd2Interface.getDevice() == 1)
			{
				value = m_obd2Interface.getValue("ELM.BATTERY_VOLTAGE", true);
				if (!value.ErrorDetected)
					lblBattery.Text = value.DoubleValue.ToString() + " V";
			}
			else
				lblBattery.Text = "Not Supported";
			progressBar.Value = progressBar.Maximum;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (!m_obd2Interface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				m_obd2Interface.logItem("Error. Test Form. Attempted refresh without vehicle connection.");
			}
			else
			{
				btnUpdate.Enabled = false;
				UpdateTests();
				btnUpdate.Enabled = true;
			}
		}
	}
}