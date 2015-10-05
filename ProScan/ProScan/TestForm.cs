using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProScan
{
	public class TestForm : Form
	{
		private static List<TestStatus> m_ListConTests;
		private static List<TestStatus> m_ListNonConTests;

		public TestForm(OBDInterface obd)
		{
			InitializeComponent();
			m_obd2Interface = obd;
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
			m_ListConTests = getContinuousTestList();
			m_ListNonConTests = getNonContinuousTestList();
			gridConTests.DataSource = m_ListConTests;
			gridNonConTests.DataSource = m_ListNonConTests;
			gridConTests.TableStyles.Clear();
			gridConTests.TableStyles.Add(GetTableStyle());
			gridNonConTests.TableStyles.Clear();
			gridNonConTests.TableStyles.Add(GetTableStyle());
		}

		private List<TestStatus> getContinuousTestList()
		{
			List<TestStatus> list = new List<TestStatus>();
			list.Add(new TestStatus("Misfire", "", 2, 5));
			list.Add(new TestStatus("Fuel System", "", 3, 6));
			list.Add(new TestStatus("Comprehensive Component", "", 4, 7));
			return list;
		}

		private List<TestStatus> getNonContinuousTestList()
		{
			List<TestStatus> list = new List<TestStatus>();
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
			if (!m_obd2Interface.ConnectedStatus)
				return;
			UpdateTests();
		}

		#region GetTableStyle 
		public DataGridTableStyle GetTableStyle()
		{
			DataGridTableStyle style = new DataGridTableStyle();
			style.MappingName = "List";

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
		#endregion

		public void UpdateTests()
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 25;
			gridConTests.Visible = false;
			gridNonConTests.Visible = false;
			OBDParameterValue value;
			value = m_obd2Interface.getValue("SAE.MISFIRE_SUPPORT", true);
			progressBar.Value = 1;
			TestStatus status = m_ListConTests[0];
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
			status = m_ListConTests[1];
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
			status = m_ListConTests[2];
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
			status = m_ListNonConTests[0];
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
			status = m_ListNonConTests[1];
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
			status = m_ListNonConTests[2];
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
			status = m_ListNonConTests[3];
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
			status = m_ListNonConTests[4];
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
			status = m_ListNonConTests[5];
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
			status = m_ListNonConTests[6];
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
			status = m_ListNonConTests[7];
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
			if (m_obd2Interface.getDevice() == HardwareType.ELM327)
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
			if (!m_obd2Interface.ConnectedStatus)
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

		#region InitializeComponent
		private DataGrid gridConTests;
		private DataGrid gridNonConTests;
		private OBDInterface m_obd2Interface;
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

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupConTests = new System.Windows.Forms.GroupBox();
			this.gridConTests = new System.Windows.Forms.DataGrid();
			this.groupNonConTests = new System.Windows.Forms.GroupBox();
			this.gridNonConTests = new System.Windows.Forms.DataGrid();
			this.groupFuel1 = new System.Windows.Forms.GroupBox();
			this.lblFuel1 = new System.Windows.Forms.Label();
			this.groupFuel2 = new System.Windows.Forms.GroupBox();
			this.lblFuel2 = new System.Windows.Forms.Label();
			this.groupPTO = new System.Windows.Forms.GroupBox();
			this.lblPTO = new System.Windows.Forms.Label();
			this.groupAir = new System.Windows.Forms.GroupBox();
			this.lblAir = new System.Windows.Forms.Label();
			this.groupOBD = new System.Windows.Forms.GroupBox();
			this.lblOBD = new System.Windows.Forms.Label();
			this.groupOxygen = new System.Windows.Forms.GroupBox();
			this.lblOxygen = new System.Windows.Forms.Label();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.groupBattery = new System.Windows.Forms.GroupBox();
			this.lblBattery = new System.Windows.Forms.Label();
			this.groupConTests.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridConTests)).BeginInit();
			this.groupNonConTests.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridNonConTests)).BeginInit();
			this.groupFuel1.SuspendLayout();
			this.groupFuel2.SuspendLayout();
			this.groupPTO.SuspendLayout();
			this.groupAir.SuspendLayout();
			this.groupOBD.SuspendLayout();
			this.groupOxygen.SuspendLayout();
			this.groupBattery.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupConTests
			// 
			this.groupConTests.Controls.Add(this.gridConTests);
			this.groupConTests.Location = new System.Drawing.Point(12, 52);
			this.groupConTests.Name = "groupConTests";
			this.groupConTests.Size = new System.Drawing.Size(300, 161);
			this.groupConTests.TabIndex = 0;
			this.groupConTests.TabStop = false;
			this.groupConTests.Text = "Continuous Tests";
			// 
			// gridConTests
			// 
			this.gridConTests.CaptionVisible = false;
			this.gridConTests.DataMember = "";
			this.gridConTests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridConTests.Location = new System.Drawing.Point(12, 23);
			this.gridConTests.Name = "gridConTests";
			this.gridConTests.RowHeadersVisible = false;
			this.gridConTests.Size = new System.Drawing.Size(276, 127);
			this.gridConTests.TabIndex = 0;
			// 
			// groupNonConTests
			// 
			this.groupNonConTests.Controls.Add(this.gridNonConTests);
			this.groupNonConTests.Location = new System.Drawing.Point(324, 52);
			this.groupNonConTests.Name = "groupNonConTests";
			this.groupNonConTests.Size = new System.Drawing.Size(300, 234);
			this.groupNonConTests.TabIndex = 1;
			this.groupNonConTests.TabStop = false;
			this.groupNonConTests.Text = "Non-Continuous Tests";
			// 
			// gridNonConTests
			// 
			this.gridNonConTests.CaptionVisible = false;
			this.gridNonConTests.DataMember = "";
			this.gridNonConTests.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridNonConTests.Location = new System.Drawing.Point(12, 23);
			this.gridNonConTests.Name = "gridNonConTests";
			this.gridNonConTests.RowHeadersVisible = false;
			this.gridNonConTests.Size = new System.Drawing.Size(276, 201);
			this.gridNonConTests.TabIndex = 1;
			// 
			// groupFuel1
			// 
			this.groupFuel1.Controls.Add(this.lblFuel1);
			this.groupFuel1.Location = new System.Drawing.Point(12, 222);
			this.groupFuel1.Name = "groupFuel1";
			this.groupFuel1.Size = new System.Drawing.Size(300, 64);
			this.groupFuel1.TabIndex = 2;
			this.groupFuel1.TabStop = false;
			this.groupFuel1.Text = "Fuel System #1";
			// 
			// lblFuel1
			// 
			this.lblFuel1.Location = new System.Drawing.Point(12, 23);
			this.lblFuel1.Name = "lblFuel1";
			this.lblFuel1.Size = new System.Drawing.Size(276, 32);
			this.lblFuel1.TabIndex = 0;
			this.lblFuel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupFuel2
			// 
			this.groupFuel2.Controls.Add(this.lblFuel2);
			this.groupFuel2.Location = new System.Drawing.Point(12, 295);
			this.groupFuel2.Name = "groupFuel2";
			this.groupFuel2.Size = new System.Drawing.Size(300, 70);
			this.groupFuel2.TabIndex = 3;
			this.groupFuel2.TabStop = false;
			this.groupFuel2.Text = "Fuel System #2";
			// 
			// lblFuel2
			// 
			this.lblFuel2.Location = new System.Drawing.Point(12, 23);
			this.lblFuel2.Name = "lblFuel2";
			this.lblFuel2.Size = new System.Drawing.Size(276, 32);
			this.lblFuel2.TabIndex = 0;
			this.lblFuel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupPTO
			// 
			this.groupPTO.Controls.Add(this.lblPTO);
			this.groupPTO.Location = new System.Drawing.Point(12, 373);
			this.groupPTO.Name = "groupPTO";
			this.groupPTO.Size = new System.Drawing.Size(300, 64);
			this.groupPTO.TabIndex = 4;
			this.groupPTO.TabStop = false;
			this.groupPTO.Text = "Power Take Off";
			// 
			// lblPTO
			// 
			this.lblPTO.Location = new System.Drawing.Point(12, 23);
			this.lblPTO.Name = "lblPTO";
			this.lblPTO.Size = new System.Drawing.Size(276, 32);
			this.lblPTO.TabIndex = 0;
			this.lblPTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupAir
			// 
			this.groupAir.Controls.Add(this.lblAir);
			this.groupAir.Location = new System.Drawing.Point(12, 447);
			this.groupAir.Name = "groupAir";
			this.groupAir.Size = new System.Drawing.Size(300, 72);
			this.groupAir.TabIndex = 5;
			this.groupAir.TabStop = false;
			this.groupAir.Text = "Commanded Secondary Air";
			// 
			// lblAir
			// 
			this.lblAir.Location = new System.Drawing.Point(12, 23);
			this.lblAir.Name = "lblAir";
			this.lblAir.Size = new System.Drawing.Size(276, 32);
			this.lblAir.TabIndex = 0;
			this.lblAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupOBD
			// 
			this.groupOBD.Controls.Add(this.lblOBD);
			this.groupOBD.Location = new System.Drawing.Point(324, 295);
			this.groupOBD.Name = "groupOBD";
			this.groupOBD.Size = new System.Drawing.Size(300, 70);
			this.groupOBD.TabIndex = 6;
			this.groupOBD.TabStop = false;
			this.groupOBD.Text = "Vehicle OBD Requirements";
			// 
			// lblOBD
			// 
			this.lblOBD.Location = new System.Drawing.Point(12, 23);
			this.lblOBD.Name = "lblOBD";
			this.lblOBD.Size = new System.Drawing.Size(276, 32);
			this.lblOBD.TabIndex = 0;
			this.lblOBD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupOxygen
			// 
			this.groupOxygen.Controls.Add(this.lblOxygen);
			this.groupOxygen.Location = new System.Drawing.Point(326, 373);
			this.groupOxygen.Name = "groupOxygen";
			this.groupOxygen.Size = new System.Drawing.Size(300, 146);
			this.groupOxygen.TabIndex = 7;
			this.groupOxygen.TabStop = false;
			this.groupOxygen.Text = "Oxygen Sensor Locations";
			// 
			// lblOxygen
			// 
			this.lblOxygen.Location = new System.Drawing.Point(12, 23);
			this.lblOxygen.Name = "lblOxygen";
			this.lblOxygen.Size = new System.Drawing.Size(276, 115);
			this.lblOxygen.TabIndex = 0;
			this.lblOxygen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(12, 12);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(90, 26);
			this.btnUpdate.TabIndex = 9;
			this.btnUpdate.Text = "&Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(114, 12);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(511, 26);
			this.progressBar.TabIndex = 10;
			// 
			// groupBattery
			// 
			this.groupBattery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBattery.Controls.Add(this.lblBattery);
			this.groupBattery.Location = new System.Drawing.Point(12, 528);
			this.groupBattery.Name = "groupBattery";
			this.groupBattery.Size = new System.Drawing.Size(615, 55);
			this.groupBattery.TabIndex = 11;
			this.groupBattery.TabStop = false;
			this.groupBattery.Text = "Battery Voltage";
			// 
			// lblBattery
			// 
			this.lblBattery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lblBattery.Location = new System.Drawing.Point(11, 20);
			this.lblBattery.Name = "lblBattery";
			this.lblBattery.Size = new System.Drawing.Size(588, 26);
			this.lblBattery.TabIndex = 0;
			this.lblBattery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TestForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(633, 585);
			this.ControlBox = false;
			this.Controls.Add(this.groupBattery);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.groupOxygen);
			this.Controls.Add(this.groupOBD);
			this.Controls.Add(this.groupAir);
			this.Controls.Add(this.groupPTO);
			this.Controls.Add(this.groupFuel2);
			this.Controls.Add(this.groupFuel1);
			this.Controls.Add(this.groupNonConTests);
			this.Controls.Add(this.groupConTests);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TestForm";
			this.Text = "Vehicle Status Monitor";
			this.Load += new System.EventHandler(this.TestForm_Load);
			this.Resize += new System.EventHandler(this.TestForm_Resize);
			this.groupConTests.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridConTests)).EndInit();
			this.groupNonConTests.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridNonConTests)).EndInit();
			this.groupFuel1.ResumeLayout(false);
			this.groupFuel2.ResumeLayout(false);
			this.groupPTO.ResumeLayout(false);
			this.groupAir.ResumeLayout(false);
			this.groupOBD.ResumeLayout(false);
			this.groupOxygen.ResumeLayout(false);
			this.groupBattery.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}