using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ProScan
{
	public class ReportGeneratorForm : Form
	{
		private GroupBox groupPreparedBy;
		private Label lblByName;
		private TextBox txtByName;
		private TextBox txtByAddress1;
		private Label lblByAddress1;
		private TextBox txtByTelephone;
		private Label lblByTelephone;
		private TextBox txtByAddress2;
		private Label lblByAddress2;
		private GroupBox groupPreparedFor;
		private TextBox txtForTelephone;
		private Label lblForTelephone;
		private TextBox txtForAddress2;
		private Label lblForAddress2;
		private TextBox txtForAddress1;
		private Label lblForAddress1;
		private TextBox txtForName;
		private Label lblForName;
		private GroupBox groupStatus;
		private RichTextBox richTextStatus;
		private GroupBox groupVehicle;
		private TextBox txtVehicleModel;
		private Label lblVehicleModel;
		private TextBox txtVehicleMake;
		private Label lblVehicleMake;
		private TextBox txtVehicleYear;
		private Label lblVehicleYear;
		private ProgressBar progressBar;
		private OBDInterface m_obdInterface;
		private ReportForm m_bReportForm;
		private int m_iRequestCount;
		private Button btnOpen;
		private Button btnGenerate;
		private Panel panel;
		private Container components;

		public ReportGeneratorForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			groupPreparedBy = new System.Windows.Forms.GroupBox();
			txtByTelephone = new System.Windows.Forms.TextBox();
			lblByTelephone = new System.Windows.Forms.Label();
			txtByAddress2 = new System.Windows.Forms.TextBox();
			lblByAddress2 = new System.Windows.Forms.Label();
			txtByAddress1 = new System.Windows.Forms.TextBox();
			lblByAddress1 = new System.Windows.Forms.Label();
			txtByName = new System.Windows.Forms.TextBox();
			lblByName = new System.Windows.Forms.Label();
			groupPreparedFor = new System.Windows.Forms.GroupBox();
			txtForTelephone = new System.Windows.Forms.TextBox();
			lblForTelephone = new System.Windows.Forms.Label();
			txtForAddress2 = new System.Windows.Forms.TextBox();
			lblForAddress2 = new System.Windows.Forms.Label();
			txtForAddress1 = new System.Windows.Forms.TextBox();
			lblForAddress1 = new System.Windows.Forms.Label();
			txtForName = new System.Windows.Forms.TextBox();
			lblForName = new System.Windows.Forms.Label();
			groupStatus = new System.Windows.Forms.GroupBox();
			progressBar = new System.Windows.Forms.ProgressBar();
			richTextStatus = new System.Windows.Forms.RichTextBox();
			groupVehicle = new System.Windows.Forms.GroupBox();
			txtVehicleModel = new System.Windows.Forms.TextBox();
			lblVehicleModel = new System.Windows.Forms.Label();
			txtVehicleMake = new System.Windows.Forms.TextBox();
			lblVehicleMake = new System.Windows.Forms.Label();
			txtVehicleYear = new System.Windows.Forms.TextBox();
			lblVehicleYear = new System.Windows.Forms.Label();
			btnOpen = new System.Windows.Forms.Button();
			btnGenerate = new System.Windows.Forms.Button();
			panel = new System.Windows.Forms.Panel();
			groupPreparedBy.SuspendLayout();
			groupPreparedFor.SuspendLayout();
			groupStatus.SuspendLayout();
			groupVehicle.SuspendLayout();
			panel.SuspendLayout();
			SuspendLayout();
			// 
			// groupPreparedBy
			// 
			groupPreparedBy.Controls.Add(txtByTelephone);
			groupPreparedBy.Controls.Add(lblByTelephone);
			groupPreparedBy.Controls.Add(txtByAddress2);
			groupPreparedBy.Controls.Add(lblByAddress2);
			groupPreparedBy.Controls.Add(txtByAddress1);
			groupPreparedBy.Controls.Add(lblByAddress1);
			groupPreparedBy.Controls.Add(txtByName);
			groupPreparedBy.Controls.Add(lblByName);
			groupPreparedBy.Location = new System.Drawing.Point(10, 75);
			groupPreparedBy.Name = "groupPreparedBy";
			groupPreparedBy.Size = new System.Drawing.Size(265, 125);
			groupPreparedBy.TabIndex = 0;
			groupPreparedBy.TabStop = false;
			groupPreparedBy.Text = "Prepared By";
			// 
			// txtByTelephone
			// 
			txtByTelephone.Location = new System.Drawing.Point(105, 95);
			txtByTelephone.MaxLength = 35;
			txtByTelephone.Name = "txtByTelephone";
			txtByTelephone.Size = new System.Drawing.Size(150, 20);
			txtByTelephone.TabIndex = 7;
			// 
			// lblByTelephone
			// 
			lblByTelephone.Location = new System.Drawing.Point(10, 95);
			lblByTelephone.Name = "lblByTelephone";
			lblByTelephone.Size = new System.Drawing.Size(90, 20);
			lblByTelephone.TabIndex = 6;
			lblByTelephone.Text = "Telephone:";
			lblByTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtByAddress2
			// 
			txtByAddress2.Location = new System.Drawing.Point(105, 70);
			txtByAddress2.MaxLength = 35;
			txtByAddress2.Name = "txtByAddress2";
			txtByAddress2.Size = new System.Drawing.Size(150, 20);
			txtByAddress2.TabIndex = 5;
			// 
			// lblByAddress2
			// 
			lblByAddress2.Location = new System.Drawing.Point(10, 70);
			lblByAddress2.Name = "lblByAddress2";
			lblByAddress2.Size = new System.Drawing.Size(90, 20);
			lblByAddress2.TabIndex = 4;
			lblByAddress2.Text = "Address Line 2:";
			lblByAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtByAddress1
			// 
			txtByAddress1.Location = new System.Drawing.Point(105, 45);
			txtByAddress1.MaxLength = 35;
			txtByAddress1.Name = "txtByAddress1";
			txtByAddress1.Size = new System.Drawing.Size(150, 20);
			txtByAddress1.TabIndex = 3;
			// 
			// lblByAddress1
			// 
			lblByAddress1.Location = new System.Drawing.Point(10, 45);
			lblByAddress1.Name = "lblByAddress1";
			lblByAddress1.Size = new System.Drawing.Size(90, 20);
			lblByAddress1.TabIndex = 2;
			lblByAddress1.Text = "Address Line 1:";
			lblByAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtByName
			// 
			txtByName.Location = new System.Drawing.Point(105, 20);
			txtByName.MaxLength = 35;
			txtByName.Name = "txtByName";
			txtByName.Size = new System.Drawing.Size(150, 20);
			txtByName.TabIndex = 1;
			// 
			// lblByName
			// 
			lblByName.Location = new System.Drawing.Point(10, 20);
			lblByName.Name = "lblByName";
			lblByName.Size = new System.Drawing.Size(90, 20);
			lblByName.TabIndex = 0;
			lblByName.Text = "Name:";
			lblByName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupPreparedFor
			// 
			groupPreparedFor.Controls.Add(txtForTelephone);
			groupPreparedFor.Controls.Add(lblForTelephone);
			groupPreparedFor.Controls.Add(txtForAddress2);
			groupPreparedFor.Controls.Add(lblForAddress2);
			groupPreparedFor.Controls.Add(txtForAddress1);
			groupPreparedFor.Controls.Add(lblForAddress1);
			groupPreparedFor.Controls.Add(txtForName);
			groupPreparedFor.Controls.Add(lblForName);
			groupPreparedFor.Location = new System.Drawing.Point(10, 210);
			groupPreparedFor.Name = "groupPreparedFor";
			groupPreparedFor.Size = new System.Drawing.Size(265, 125);
			groupPreparedFor.TabIndex = 1;
			groupPreparedFor.TabStop = false;
			groupPreparedFor.Text = "Prepared For";
			// 
			// txtForTelephone
			// 
			txtForTelephone.Location = new System.Drawing.Point(105, 95);
			txtForTelephone.MaxLength = 35;
			txtForTelephone.Name = "txtForTelephone";
			txtForTelephone.Size = new System.Drawing.Size(150, 20);
			txtForTelephone.TabIndex = 7;
			// 
			// lblForTelephone
			// 
			lblForTelephone.Location = new System.Drawing.Point(10, 95);
			lblForTelephone.Name = "lblForTelephone";
			lblForTelephone.Size = new System.Drawing.Size(90, 20);
			lblForTelephone.TabIndex = 6;
			lblForTelephone.Text = "Telephone:";
			lblForTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtForAddress2
			// 
			txtForAddress2.Location = new System.Drawing.Point(105, 70);
			txtForAddress2.MaxLength = 35;
			txtForAddress2.Name = "txtForAddress2";
			txtForAddress2.Size = new System.Drawing.Size(150, 20);
			txtForAddress2.TabIndex = 5;
			// 
			// lblForAddress2
			// 
			lblForAddress2.Location = new System.Drawing.Point(10, 70);
			lblForAddress2.Name = "lblForAddress2";
			lblForAddress2.Size = new System.Drawing.Size(90, 20);
			lblForAddress2.TabIndex = 4;
			lblForAddress2.Text = "Address Line 2:";
			lblForAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtForAddress1
			// 
			txtForAddress1.Location = new System.Drawing.Point(105, 45);
			txtForAddress1.MaxLength = 35;
			txtForAddress1.Name = "txtForAddress1";
			txtForAddress1.Size = new System.Drawing.Size(150, 20);
			txtForAddress1.TabIndex = 3;
			// 
			// lblForAddress1
			// 
			lblForAddress1.Location = new System.Drawing.Point(10, 45);
			lblForAddress1.Name = "lblForAddress1";
			lblForAddress1.Size = new System.Drawing.Size(90, 20);
			lblForAddress1.TabIndex = 2;
			lblForAddress1.Text = "Address Line 1:";
			lblForAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtForName
			// 
			txtForName.Location = new System.Drawing.Point(105, 20);
			txtForName.MaxLength = 35;
			txtForName.Name = "txtForName";
			txtForName.Size = new System.Drawing.Size(150, 20);
			txtForName.TabIndex = 1;
			// 
			// lblForName
			// 
			lblForName.Location = new System.Drawing.Point(10, 20);
			lblForName.Name = "lblForName";
			lblForName.Size = new System.Drawing.Size(90, 20);
			lblForName.TabIndex = 0;
			lblForName.Text = "Name:";
			lblForName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupStatus
			// 
			groupStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupStatus.Controls.Add(progressBar);
			groupStatus.Controls.Add(richTextStatus);
			groupStatus.Location = new System.Drawing.Point(284, 10);
			groupStatus.Name = "groupStatus";
			groupStatus.Size = new System.Drawing.Size(465, 438);
			groupStatus.TabIndex = 4;
			groupStatus.TabStop = false;
			groupStatus.Text = "Status";
			// 
			// progressBar
			// 
			progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			progressBar.Location = new System.Drawing.Point(10, 20);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(444, 23);
			progressBar.TabIndex = 0;
			// 
			// richTextStatus
			// 
			richTextStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			richTextStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			richTextStatus.Location = new System.Drawing.Point(10, 48);
			richTextStatus.Name = "richTextStatus";
			richTextStatus.ReadOnly = true;
			richTextStatus.Size = new System.Drawing.Size(444, 381);
			richTextStatus.TabIndex = 1;
			richTextStatus.Text = "";
			// 
			// groupVehicle
			// 
			groupVehicle.Controls.Add(txtVehicleModel);
			groupVehicle.Controls.Add(lblVehicleModel);
			groupVehicle.Controls.Add(txtVehicleMake);
			groupVehicle.Controls.Add(lblVehicleMake);
			groupVehicle.Controls.Add(txtVehicleYear);
			groupVehicle.Controls.Add(lblVehicleYear);
			groupVehicle.Location = new System.Drawing.Point(10, 345);
			groupVehicle.Name = "groupVehicle";
			groupVehicle.Size = new System.Drawing.Size(265, 103);
			groupVehicle.TabIndex = 2;
			groupVehicle.TabStop = false;
			groupVehicle.Text = "Vehicle";
			// 
			// txtVehicleModel
			// 
			txtVehicleModel.Location = new System.Drawing.Point(105, 70);
			txtVehicleModel.MaxLength = 35;
			txtVehicleModel.Name = "txtVehicleModel";
			txtVehicleModel.Size = new System.Drawing.Size(150, 20);
			txtVehicleModel.TabIndex = 5;
			// 
			// lblVehicleModel
			// 
			lblVehicleModel.Location = new System.Drawing.Point(10, 70);
			lblVehicleModel.Name = "lblVehicleModel";
			lblVehicleModel.Size = new System.Drawing.Size(90, 20);
			lblVehicleModel.TabIndex = 4;
			lblVehicleModel.Text = "Model:";
			lblVehicleModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVehicleMake
			// 
			txtVehicleMake.Location = new System.Drawing.Point(105, 45);
			txtVehicleMake.MaxLength = 35;
			txtVehicleMake.Name = "txtVehicleMake";
			txtVehicleMake.Size = new System.Drawing.Size(150, 20);
			txtVehicleMake.TabIndex = 3;
			// 
			// lblVehicleMake
			// 
			lblVehicleMake.Location = new System.Drawing.Point(10, 45);
			lblVehicleMake.Name = "lblVehicleMake";
			lblVehicleMake.Size = new System.Drawing.Size(90, 20);
			lblVehicleMake.TabIndex = 2;
			lblVehicleMake.Text = "Make:";
			lblVehicleMake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVehicleYear
			// 
			txtVehicleYear.Location = new System.Drawing.Point(105, 20);
			txtVehicleYear.MaxLength = 4;
			txtVehicleYear.Name = "txtVehicleYear";
			txtVehicleYear.Size = new System.Drawing.Size(150, 20);
			txtVehicleYear.TabIndex = 1;
			// 
			// lblVehicleYear
			// 
			lblVehicleYear.Location = new System.Drawing.Point(10, 20);
			lblVehicleYear.Name = "lblVehicleYear";
			lblVehicleYear.Size = new System.Drawing.Size(90, 20);
			lblVehicleYear.TabIndex = 0;
			lblVehicleYear.Text = "Year:";
			lblVehicleYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOpen
			// 
			btnOpen.Location = new System.Drawing.Point(10, 45);
			btnOpen.Name = "btnOpen";
			btnOpen.Size = new System.Drawing.Size(265, 23);
			btnOpen.TabIndex = 3;
			btnOpen.Text = "&Open a Saved Report";
			btnOpen.Click += new System.EventHandler(btnOpen_Click);
			// 
			// btnGenerate
			// 
			btnGenerate.Location = new System.Drawing.Point(10, 15);
			btnGenerate.Name = "btnGenerate";
			btnGenerate.Size = new System.Drawing.Size(265, 23);
			btnGenerate.TabIndex = 5;
			btnGenerate.Text = "&Generate a New Report";
			btnGenerate.Click += new System.EventHandler(btnGenerate_Click);
			// 
			// panel
			// 
			panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			panel.AutoScroll = true;
			panel.Controls.Add(btnGenerate);
			panel.Controls.Add(btnOpen);
			panel.Controls.Add(groupVehicle);
			panel.Controls.Add(groupPreparedFor);
			panel.Controls.Add(groupPreparedBy);
			panel.Controls.Add(groupStatus);
			panel.Location = new System.Drawing.Point(0, 0);
			panel.Name = "panel";
			panel.Size = new System.Drawing.Size(755, 450);
			panel.TabIndex = 6;
			// 
			// ReportGeneratorForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(756, 453);
			ControlBox = false;
			Controls.Add(panel);
			Name = "ReportGeneratorForm";
			Text = "Diagnostic Report Generator";
			Activated += new System.EventHandler(ReportGeneratorForm_Activated);
			Load += new System.EventHandler(ReportGeneratorForm_Load);
			groupPreparedBy.ResumeLayout(false);
			groupPreparedBy.PerformLayout();
			groupPreparedFor.ResumeLayout(false);
			groupPreparedFor.PerformLayout();
			groupStatus.ResumeLayout(false);
			groupVehicle.ResumeLayout(false);
			groupVehicle.PerformLayout();
			panel.ResumeLayout(false);
			ResumeLayout(false);

		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			}
			else
			{
				m_bReportForm = new ReportForm();
				btnGenerate.Enabled = false;
				m_bReportForm.ReportPage1.ShopName = txtByName.Text;
				m_bReportForm.ReportPage1.ShopAddress1 = txtByAddress1.Text;
				m_bReportForm.ReportPage1.ShopAddress2 = txtByAddress2.Text;
				m_bReportForm.ReportPage1.ShopTelephone = txtByTelephone.Text;
				m_bReportForm.ReportPage1.ClientName = txtForName.Text;
				m_bReportForm.ReportPage1.ClientAddress1 = txtForAddress1.Text;
				m_bReportForm.ReportPage1.ClientAddress2 = txtForAddress2.Text;
				m_bReportForm.ReportPage1.ClientTelephone = txtForTelephone.Text;
				m_bReportForm.ReportPage1.Vehicle = txtVehicleYear.Text + " " + txtVehicleMake.Text + " " + txtVehicleModel.Text;
				if (m_bReportForm.ReportPage1.Vehicle.Trim().Length == 0)
					m_bReportForm.ReportPage1.Vehicle = "vehicle";
				DateTime now1 = DateTime.Now;
				DateTime now2 = DateTime.Now;
				m_bReportForm.ReportPage1.GenerationDate = string.Format("{0} at {1}", DateTime.Now.ToString("MMMM dd, yyyy"), DateTime.Now.ToString("h:mm:ss tt"));
				richTextStatus.Text = "";
				progressBar.Value = 0;
				progressBar.Maximum = 22;
				ThreadPool.QueueUserWorkItem(new WaitCallback(CollectData));
			}
		}

		private void CollectData(object state)
		{
			m_iRequestCount = 0;
			DisplayStatusMessage("Requesting MIL Status & DTC Count");
			DisplayRequest("0101");
			OBDParameterValue value5 = m_obdInterface.getValue("SAE.MIL", true);
			int num5 = progressBar.Value;
			progressBar.Value = num5 + 1;
			if (!value5.ErrorDetected)
			{
				if (value5.BoolValue)
				{
					DisplayDetailMessage("MIL: On");
					m_bReportForm.ReportPage1.MilStatus = true;
				}
				else
				{
					DisplayDetailMessage("MIL: Off");
					m_bReportForm.ReportPage1.MilStatus = false;
				}
			}
			OBDParameterValue value3 = m_obdInterface.getValue("SAE.DTC_COUNT", true);
			int num4 = progressBar.Value;
			progressBar.Value = num4 + 1;
			if (!value3.ErrorDetected)
			{
				m_bReportForm.ReportPage1.TotalCodes = (int)value3.DoubleValue;
				DisplayDetailMessage("Stored DTCs: " + value3.DoubleValue.ToString());
			}
			DisplayStatusMessage("Requesting List of Stored DTCs");
			OBDParameterValue value4 = m_obdInterface.getValue("SAE.STORED_DTCS", true);
			int num3 = progressBar.Value;
			progressBar.Value = num3 + 1;
			if (!value4.ErrorDetected)
			{
				m_bReportForm.ReportPage1.DTCList.Clear();
				StringEnumerator enumerator2 = value4.StringCollectionValue.GetEnumerator();
				if (enumerator2.MoveNext())
				{
					do
					{
						m_bReportForm.ReportPage1.DTCList.Add(enumerator2.Current);
						DisplayDetailMessage("Stored DTC: " + enumerator2.Current);
						DTC dtc2 = m_obdInterface.getDTC(enumerator2.Current);
						if (dtc2 != null)
						{
							m_bReportForm.ReportPage1.DTCDefinitionList.Add(dtc2.Description);
						}
					}
					while (enumerator2.MoveNext());
				}
			}
			DisplayStatusMessage("Requesting List of Pending DTCs");
			OBDParameterValue value2 = m_obdInterface.getValue("SAE.PENDING_DTCS", true);
			int num2 = progressBar.Value;
			progressBar.Value = num2 + 1;
			if (!value2.ErrorDetected)
			{
				m_bReportForm.ReportPage1.PendingList.Clear();
				StringEnumerator enumerator = value2.StringCollectionValue.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						m_bReportForm.ReportPage1.PendingList.Add(enumerator.Current);
						DisplayDetailMessage("Pending DTC: " + enumerator.Current);
						DTC dtc = m_obdInterface.getDTC(enumerator.Current);
						if (dtc != null)
						{
							m_bReportForm.ReportPage1.PendingDefinitionList.Add(dtc.Description);
						}
					}
					while (enumerator.MoveNext());
				}
			}

			DisplayStatusMessage("Checking for Freeze Frame Data");
			OBDParameter parameter = m_obdInterface.lookupParameter("SAE.FF_DTC");
			if (parameter != null)
			{
				OBDParameter freezeFrameCopy = parameter.GetFreezeFrameCopy(0);
				value2 = m_obdInterface.getValue(freezeFrameCopy, true);
				int num = progressBar.Value;
				progressBar.Value = num + 1;
				if (!value2.ErrorDetected)
				{
					m_bReportForm.ReportPage1.FreezeFrameDTC = value2.StringValue;
					DisplayDetailMessage("Freeze freeze data found for " + value2.StringValue);
					CollectFreezeFrameData();
				}
				else
				{
					m_bReportForm.ReportPage1.FreezeFrameDTC = "P0000";
					DisplayDetailMessage("No freeze frame data found.");
					m_iRequestCount += 11;
				}
				CollectMonitoringTestData();
				progressBar.Value = progressBar.Maximum;
				btnGenerate.Enabled = true;
				m_bReportForm.ShowDialog();
			}
		}

		private void CollectFreezeFrameData()
		{
			OBDParameter param = m_obdInterface.lookupParameter("SAE.FUEL1_STATUS");
			int num16 = progressBar.Value;
			progressBar.Value = num16 + 1;
			m_bReportForm.ReportPage1.ShowFuelSystemStatus = false;
			if (param != null)
			{
				param = param.GetFreezeFrameCopy(0);
				OBDParameterValue value17 = m_obdInterface.getValue(param, true);
				if (!value17.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowFuelSystemStatus = true;
					DisplayDetailMessage("Fuel System 1: " + value17.StringValue);
					m_bReportForm.ReportPage1.FuelSystem1Status = value17.StringValue;
				}
			}
			OBDParameter freezeFrameCopy = m_obdInterface.lookupParameter("SAE.FUEL2_STATUS");
			int num2 = progressBar.Value;
			progressBar.Value = num2 + 1;
			m_bReportForm.ReportPage1.ShowFuelSystemStatus = false;
			if (freezeFrameCopy != null)
			{
				freezeFrameCopy = freezeFrameCopy.GetFreezeFrameCopy(0);
				OBDParameterValue value3 = m_obdInterface.getValue(freezeFrameCopy, true);
				if (!value3.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowFuelSystemStatus = true;
					DisplayDetailMessage("Fuel System 2: " + value3.StringValue);
					m_bReportForm.ReportPage1.FuelSystem2Status = value3.StringValue;
				}
			}
			OBDParameter parameter16 = m_obdInterface.lookupParameter("SAE.LOAD_CALC");
			int num = progressBar.Value;
			progressBar.Value = num + 1;
			m_bReportForm.ReportPage1.ShowCalculatedLoad = false;
			if (parameter16 != null)
			{
				OBDParameter parameter17 = parameter16.GetFreezeFrameCopy(0);
				OBDParameterValue value2 = m_obdInterface.getValue(parameter17, true);
				if (!value2.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowCalculatedLoad = true;
					DisplayDetailMessage("Calculated Load: " + value2.DoubleValue.ToString());
					m_bReportForm.ReportPage1.CalculatedLoad = value2.DoubleValue;
				}
			}
			OBDParameter parameter14 = m_obdInterface.lookupParameter("SAE.ECT");
			int num15 = progressBar.Value;
			progressBar.Value = num15 + 1;
			m_bReportForm.ReportPage1.ShowEngineCoolantTemp = false;
			if (parameter14 != null)
			{
				parameter14 = parameter14.GetFreezeFrameCopy(0);
				OBDParameterValue value16 = m_obdInterface.getValue(parameter14, true);
				if (!value16.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowEngineCoolantTemp = true;
					DisplayDetailMessage("Engine Coolant Temp: " + value16.DoubleValue.ToString());
					m_bReportForm.ReportPage1.EngineCoolantTemp = value16.DoubleValue;
				}
			}
			OBDParameter parameter13 = m_obdInterface.lookupParameter("SAE.STFT1");
			int num14 = progressBar.Value;
			progressBar.Value = num14 + 1;
			m_bReportForm.ReportPage1.ShowSTFT13 = false;
			if (parameter13 != null)
			{
				parameter13 = parameter13.GetFreezeFrameCopy(0);
				OBDParameterValue value15 = m_obdInterface.getValue(parameter13, true);
				if (!value15.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowSTFT13 = true;
					DisplayDetailMessage("STFT Bank 1: " + value15.DoubleValue.ToString());
					m_bReportForm.ReportPage1.STFT1 = value15.DoubleValue;
				}
			}
			OBDParameter parameter12 = m_obdInterface.lookupParameter("SAE.STFT3");
			int num13 = progressBar.Value;
			progressBar.Value = num13 + 1;
			m_bReportForm.ReportPage1.ShowSTFT13 = false;
			if (parameter12 != null)
			{
				parameter12 = parameter12.GetFreezeFrameCopy(0);
				OBDParameterValue value14 = m_obdInterface.getValue(parameter12, true);
				if (!value14.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowSTFT13 = true;
					DisplayDetailMessage("STFT Bank 3: " + value14.DoubleValue.ToString());
					m_bReportForm.ReportPage1.STFT3 = value14.DoubleValue;
				}
			}
			OBDParameter parameter11 = m_obdInterface.lookupParameter("SAE.LTFT1");
			int num12 = progressBar.Value;
			progressBar.Value = num12 + 1;
			m_bReportForm.ReportPage1.ShowLTFT13 = false;
			if (parameter11 != null)
			{
				parameter11 = parameter11.GetFreezeFrameCopy(0);
				OBDParameterValue value13 = m_obdInterface.getValue(parameter11, true);
				if (!value13.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowLTFT13 = true;
					DisplayDetailMessage("LTFT Bank 1: " + value13.DoubleValue.ToString());
					m_bReportForm.ReportPage1.LTFT1 = value13.DoubleValue;
				}
			}
			OBDParameter parameter10 = m_obdInterface.lookupParameter("SAE.LTFT3");
			int num11 = progressBar.Value;
			progressBar.Value = num11 + 1;
			m_bReportForm.ReportPage1.ShowLTFT13 = false;
			if (parameter10 != null)
			{
				parameter10 = parameter10.GetFreezeFrameCopy(0);
				OBDParameterValue value12 = m_obdInterface.getValue(parameter10, true);
				if (!value12.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowLTFT13 = true;
					DisplayDetailMessage("LTFT Bank 3: " + value12.DoubleValue.ToString());
					m_bReportForm.ReportPage1.LTFT3 = value12.DoubleValue;
				}
			}
			OBDParameter parameter9 = m_obdInterface.lookupParameter("SAE.STFT2");
			int num10 = progressBar.Value;
			progressBar.Value = num10 + 1;
			m_bReportForm.ReportPage1.ShowSTFT24 = false;
			if (parameter9 != null)
			{
				parameter9 = parameter9.GetFreezeFrameCopy(0);
				OBDParameterValue value11 = m_obdInterface.getValue(parameter9, true);
				if (!value11.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowSTFT24 = true;
					DisplayDetailMessage("STFT Bank 2: " + value11.DoubleValue.ToString());
					m_bReportForm.ReportPage1.STFT2 = value11.DoubleValue;
				}
			}
			OBDParameter parameter8 = m_obdInterface.lookupParameter("SAE.STFT4");
			int num9 = progressBar.Value;
			progressBar.Value = num9 + 1;
			m_bReportForm.ReportPage1.ShowSTFT24 = false;
			if (parameter8 != null)
			{
				parameter8 = parameter8.GetFreezeFrameCopy(0);
				OBDParameterValue value10 = m_obdInterface.getValue(parameter8, true);
				if (!value10.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowSTFT24 = true;
					DisplayDetailMessage("STFT Bank 4: " + value10.DoubleValue.ToString());
					m_bReportForm.ReportPage1.STFT4 = value10.DoubleValue;
				}
			}
			OBDParameter parameter7 = m_obdInterface.lookupParameter("SAE.LTFT2");
			int num8 = progressBar.Value;
			progressBar.Value = num8 + 1;
			m_bReportForm.ReportPage1.ShowLTFT24 = false;
			if (parameter7 != null)
			{
				parameter7 = parameter7.GetFreezeFrameCopy(0);
				OBDParameterValue value9 = m_obdInterface.getValue(parameter7, true);
				if (!value9.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowLTFT24 = true;
					DisplayDetailMessage("LTFT Bank 2: " + value9.DoubleValue.ToString());
					m_bReportForm.ReportPage1.LTFT2 = value9.DoubleValue;
				}
			}
			OBDParameter parameter6 = m_obdInterface.lookupParameter("SAE.LTFT4");
			int num7 = progressBar.Value;
			progressBar.Value = num7 + 1;
			m_bReportForm.ReportPage1.ShowLTFT24 = false;
			if (parameter6 != null)
			{
				parameter6 = parameter6.GetFreezeFrameCopy(0);
				OBDParameterValue value8 = m_obdInterface.getValue(parameter6, true);
				if (!value8.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowLTFT24 = true;
					DisplayDetailMessage("LTFT Bank 4: " + value8.DoubleValue.ToString());
					m_bReportForm.ReportPage1.LTFT4 = value8.DoubleValue;
				}
			}
			OBDParameter parameter5 = m_obdInterface.lookupParameter("SAE.MAP");
			int num6 = progressBar.Value;
			progressBar.Value = num6 + 1;
			m_bReportForm.ReportPage1.ShowIntakePressure = false;
			if (parameter5 != null)
			{
				parameter5 = parameter5.GetFreezeFrameCopy(0);
				OBDParameterValue value7 = m_obdInterface.getValue(parameter5, true);
				if (!value7.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowIntakePressure = true;
					DisplayDetailMessage("Intake Pressure: " + value7.DoubleValue.ToString());
					m_bReportForm.ReportPage1.IntakePressure = value7.DoubleValue;
				}
			}
			OBDParameter parameter4 = m_obdInterface.lookupParameter("SAE.RPM");
			int num5 = progressBar.Value;
			progressBar.Value = num5 + 1;
			m_bReportForm.ReportPage1.ShowEngineRPM = false;
			if (parameter4 != null)
			{
				parameter4 = parameter4.GetFreezeFrameCopy(0);
				OBDParameterValue value6 = m_obdInterface.getValue(parameter4, true);
				if (!value6.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowEngineRPM = true;
					DisplayDetailMessage("Engine RPM: " + value6.DoubleValue.ToString());
					m_bReportForm.ReportPage1.EngineRPM = value6.DoubleValue;
				}
			}
			OBDParameter parameter3 = m_obdInterface.lookupParameter("SAE.VSS");
			int num4 = progressBar.Value;
			progressBar.Value = num4 + 1;
			m_bReportForm.ReportPage1.ShowVehicleSpeed = false;
			if (parameter3 != null)
			{
				parameter3 = parameter3.GetFreezeFrameCopy(0);
				OBDParameterValue value5 = m_obdInterface.getValue(parameter3, true);
				if (!value5.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowVehicleSpeed = true;
					DisplayDetailMessage("Vehicle Speed: " + value5.DoubleValue.ToString());
					m_bReportForm.ReportPage1.VehicleSpeed = value5.DoubleValue;
				}
			}
			OBDParameter parameter2 = m_obdInterface.lookupParameter("SAE.SPARKADV");
			int num3 = progressBar.Value;
			progressBar.Value = num3 + 1;
			m_bReportForm.ReportPage1.ShowSparkAdvance = false;
			if (parameter2 != null)
			{
				parameter2 = parameter2.GetFreezeFrameCopy(0);
				OBDParameterValue value4 = m_obdInterface.getValue(parameter2, true);
				if (!value4.ErrorDetected)
				{
					m_bReportForm.ReportPage1.ShowSparkAdvance = true;
					DisplayDetailMessage("Spark Advance: " + value4.DoubleValue.ToString());
					m_bReportForm.ReportPage1.SparkAdvance = value4.DoubleValue;
				}
			}
		}

		private void CollectMonitoringTestData()
		{
			DisplayStatusMessage("Reading Monitor Test Results");
			int num = progressBar.Value;
			progressBar.Value = num + 1;
			OBDParameterValue value23 = m_obdInterface.getValue("SAE.MISFIRE_SUPPORT", true);
			if (!value23.ErrorDetected)
			{
				if (value23.BoolValue)
				{
					DisplayDetailMessage("Misfire Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.MisfireMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Misfire Monitoring Supported?: No");
					m_bReportForm.ReportPage1.MisfireMonitorSupported = false;
				}
			}
			OBDParameterValue value22 = m_obdInterface.getValue("SAE.MISFIRE_STATUS", true);
			if (!value22.ErrorDetected)
			{
				if (value22.BoolValue)
				{
					DisplayDetailMessage("Misfire Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.MisfireMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Misfire Monitoring Completed?: No");
					m_bReportForm.ReportPage1.MisfireMonitorCompleted = false;
				}
			}
			OBDParameterValue value21 = m_obdInterface.getValue("SAE.FUEL_SUPPORT", true);
			if (!value21.ErrorDetected)
			{
				if (value21.BoolValue)
				{
					DisplayDetailMessage("Fuel System Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.FuelSystemMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Fuel System Monitoring Supported?: No");
					m_bReportForm.ReportPage1.FuelSystemMonitorSupported = false;
				}
			}
			OBDParameterValue value20 = m_obdInterface.getValue("SAE.FUEL_STATUS", true);
			if (!value20.ErrorDetected)
			{
				if (value20.BoolValue)
				{
					DisplayDetailMessage("Fuel System Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.FuelSystemMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Fuel System Monitoring Completed?: No");
					m_bReportForm.ReportPage1.FuelSystemMonitorCompleted = false;
				}
			}
			OBDParameterValue value19 = m_obdInterface.getValue("SAE.CCM_SUPPORT", true);
			if (!value19.ErrorDetected)
			{
				if (value19.BoolValue)
				{
					DisplayDetailMessage("Comprehensive Component Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.ComprehensiveMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Comprehensive Component Monitoring Supported?: No");
					m_bReportForm.ReportPage1.ComprehensiveMonitorSupported = false;
				}
			}
			OBDParameterValue value18 = m_obdInterface.getValue("SAE.CCM_STATUS", true);
			if (!value18.ErrorDetected)
			{
				if (value18.BoolValue)
				{
					DisplayDetailMessage("Comprehensive Component Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.ComprehensiveMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Comprehensive Component Monitoring Completed?: No");
					m_bReportForm.ReportPage1.ComprehensiveMonitorCompleted = false;
				}
			}
			OBDParameterValue value17 = m_obdInterface.getValue("SAE.CAT_SUPPORT", true);
			if (!value17.ErrorDetected)
			{
				if (value17.BoolValue)
				{
					DisplayDetailMessage("Catalyst Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.CatalystMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Catalyst Monitoring Supported?: No");
					m_bReportForm.ReportPage1.CatalystMonitorSupported = false;
				}
			}
			OBDParameterValue value16 = m_obdInterface.getValue("SAE.CAT_STATUS", true);
			if (!value16.ErrorDetected)
			{
				if (value16.BoolValue)
				{
					DisplayDetailMessage("Catalyst Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.CatalystMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Catalyst Monitoring Completed?: No");
					m_bReportForm.ReportPage1.CatalystMonitorCompleted = false;
				}
			}
			OBDParameterValue value15 = m_obdInterface.getValue("SAE.HCAT_SUPPORT", true);
			if (!value15.ErrorDetected)
			{
				if (value15.BoolValue)
				{
					DisplayDetailMessage("Heated Catalyst Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.HeatedCatalystMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Heated Catalyst Monitoring Supported?: No");
					m_bReportForm.ReportPage1.HeatedCatalystMonitorSupported = false;
				}
			}
			OBDParameterValue value14 = m_obdInterface.getValue("SAE.HCAT_STATUS", true);
			if (!value14.ErrorDetected)
			{
				if (value14.BoolValue)
				{
					DisplayDetailMessage("Heated Catalyst Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.HeatedCatalystMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Heated Catalyst Monitoring Completed?: No");
					m_bReportForm.ReportPage1.HeatedCatalystMonitorCompleted = false;
				}
			}
			OBDParameterValue value13 = m_obdInterface.getValue("SAE.EVAP_SUPPORT", true);
			if (!value13.ErrorDetected)
			{
				if (value13.BoolValue)
				{
					DisplayDetailMessage("Evaporative System Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.EvapSystemMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Evaporative System Monitoring Supported?: No");
					m_bReportForm.ReportPage1.EvapSystemMonitorSupported = false;
				}
			}
			OBDParameterValue value12 = m_obdInterface.getValue("SAE.EVAP_STATUS", true);
			if (!value12.ErrorDetected)
			{
				if (value12.BoolValue)
				{
					DisplayDetailMessage("Evaporative System Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.EvapSystemMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Evaporative System Monitoring Completed?: No");
					m_bReportForm.ReportPage1.EvapSystemMonitorCompleted = false;
				}
			}
			OBDParameterValue value11 = m_obdInterface.getValue("SAE.AIR_SUPPORT", true);
			if (!value11.ErrorDetected)
			{
				if (value11.BoolValue)
				{
					DisplayDetailMessage("Secondary Air System Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.SecondaryAirMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Secondary Air System Monitoring Supported?: No");
					m_bReportForm.ReportPage1.SecondaryAirMonitorSupported = false;
				}
			}
			OBDParameterValue value10 = m_obdInterface.getValue("SAE.AIR_STATUS", true);
			if (!value10.ErrorDetected)
			{
				if (value10.BoolValue)
				{
					DisplayDetailMessage("Secondary Air System Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.SecondaryAirMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Secondary Air System Monitoring Completed?: No");
					m_bReportForm.ReportPage1.SecondaryAirMonitorCompleted = false;
				}
			}
			OBDParameterValue value9 = m_obdInterface.getValue("SAE.AC_SUPPORT", true);
			if (!value9.ErrorDetected)
			{
				if (value9.BoolValue)
				{
					DisplayDetailMessage("A/C System Refrigerant Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.RefrigerantMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("A/C System Refrigerant Monitoring Supported?: No");
					m_bReportForm.ReportPage1.RefrigerantMonitorSupported = false;
				}
			}
			OBDParameterValue value8 = m_obdInterface.getValue("SAE.AC_STATUS", true);
			if (!value8.ErrorDetected)
			{
				if (value8.BoolValue)
				{
					DisplayDetailMessage("A/C System Refrigerant Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.RefrigerantMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("A/C System Refrigerant Monitoring Completed?: No");
					m_bReportForm.ReportPage1.RefrigerantMonitorCompleted = false;
				}
			}
			OBDParameterValue value7 = m_obdInterface.getValue("SAE.O2_SUPPORT", true);
			if (!value7.ErrorDetected)
			{
				if (value7.BoolValue)
				{
					DisplayDetailMessage("Oxygen Sensor Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.OxygenSensorMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Oxygen Sensor Monitoring Supported?: No");
					m_bReportForm.ReportPage1.OxygenSensorMonitorSupported = false;
				}
			}
			OBDParameterValue value6 = m_obdInterface.getValue("SAE.O2_STATUS", true);
			if (!value6.ErrorDetected)
			{
				if (value6.BoolValue)
				{
					DisplayDetailMessage("Oxygen Sensor Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.OxygenSensorMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Oxygen Sensor Monitoring Completed?: No");
					m_bReportForm.ReportPage1.OxygenSensorMonitorCompleted = false;
				}
			}
			OBDParameterValue value5 = m_obdInterface.getValue("SAE.O2HTR_SUPPORT", true);
			if (!value5.ErrorDetected)
			{
				if (value5.BoolValue)
				{
					DisplayDetailMessage("Oxygen Sensor Heater Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.OxygenSensorHeaterMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("Oxygen Sensor Heater Monitoring Supported?: No");
					m_bReportForm.ReportPage1.OxygenSensorHeaterMonitorSupported = false;
				}
			}
			OBDParameterValue value4 = m_obdInterface.getValue("SAE.O2HTR_STATUS", true);
			if (!value4.ErrorDetected)
			{
				if (value4.BoolValue)
				{
					DisplayDetailMessage("Oxygen Sensor Heater Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.OxygenSensorHeaterMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("Oxygen Sensor Heater Monitoring Completed?: No");
					m_bReportForm.ReportPage1.OxygenSensorHeaterMonitorCompleted = false;
				}
			}
			OBDParameterValue value3 = m_obdInterface.getValue("SAE.EGR_SUPPORT", true);
			if (!value3.ErrorDetected)
			{
				if (value3.BoolValue)
				{
					DisplayDetailMessage("EGR System Monitoring Supported?: Yes");
					m_bReportForm.ReportPage1.EGRSystemMonitorSupported = true;
				}
				else
				{
					DisplayDetailMessage("EGR System Monitoring Supported?: No");
					m_bReportForm.ReportPage1.EGRSystemMonitorSupported = false;
				}
			}
			OBDParameterValue value2 = m_obdInterface.getValue("SAE.EGR_STATUS", true);
			if (!value2.ErrorDetected)
			{
				if (value2.BoolValue)
				{
					DisplayDetailMessage("EGR System Monitoring Completed?: Yes");
					m_bReportForm.ReportPage1.EGRSystemMonitorCompleted = true;
				}
				else
				{
					DisplayDetailMessage("EGR System Monitoring Completed?: No");
					m_bReportForm.ReportPage1.EGRSystemMonitorCompleted = false;
				}
			}
		}

		private void DisplayStatusMessage(string str)
		{
			richTextStatus.SelectionFont = new Font("Times New Roman", 12f, FontStyle.Bold);
			richTextStatus.SelectionColor = Color.Blue;
			richTextStatus.AppendText(str + "\r\n");
		}

		private void DisplayRequest(string str)
		{
			richTextStatus.SelectionFont = new Font("Times New Roman", 10f, FontStyle.Bold);
			richTextStatus.SelectionColor = Color.Black;
			richTextStatus.AppendText("   TX: ");
			richTextStatus.SelectionColor = Color.Green;
			richTextStatus.AppendText(str);
			richTextStatus.AppendText("\r\n");
		}

		private void DisplayValidResponse(string str)
		{
			richTextStatus.SelectionFont = new Font("Times New Roman", 10f, FontStyle.Bold);
			Color black = Color.Black;
			richTextStatus.SelectionColor = black;
			richTextStatus.AppendText("   RX: ");
			Color green = Color.Green;
			richTextStatus.SelectionColor = green;
			richTextStatus.AppendText(str);
			richTextStatus.AppendText("\r\n");
		}

		private void DisplayInvalidResponse(string str)
		{
			richTextStatus.SelectionFont = new Font("Times New Roman", 10f, FontStyle.Bold);
			Color black = Color.Black;
			richTextStatus.SelectionColor = black;
			richTextStatus.AppendText("   RX: ");
			Color red = Color.Red;
			richTextStatus.SelectionColor = red;
			richTextStatus.AppendText(str);
			richTextStatus.AppendText("\r\n");
		}

		private void DisplayDetailMessage(string str)
		{
			richTextStatus.SelectionFont = new Font("Times New Roman", 10f, FontStyle.Regular);
			Color black = Color.Black;
			richTextStatus.SelectionColor = black;
			richTextStatus.AppendText("      " + str + "\r\n");
		}

		private void DisplayBlankLine()
		{
			richTextStatus.SelectionFont = new Font("Times New Roman", 10f, FontStyle.Regular);
			richTextStatus.AppendText("\r\n");
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Open OBD-II Diagnostic Report";
			openFileDialog.Filter = "ProScan Report Files (*.obd)|*.obd";
			openFileDialog.FilterIndex = 0;
			openFileDialog.RestoreDirectory = true;
			int num1 = (int)openFileDialog.ShowDialog();
			if (openFileDialog.FileName.Length <= 0)
				return;
			FileStream fileStream = File.OpenRead(openFileDialog.FileName);
			BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
			m_bReportForm = new ReportForm();
			m_bReportForm.ReportPage1.ShopName = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ShopAddress1 = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ShopAddress2 = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ShopTelephone = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ClientName = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ClientAddress1 = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ClientAddress2 = binaryReader.ReadString();
			m_bReportForm.ReportPage1.ClientTelephone = binaryReader.ReadString();
			m_bReportForm.ReportPage1.Vehicle = binaryReader.ReadString();
			m_bReportForm.ReportPage1.GenerationDate = binaryReader.ReadString();
			m_bReportForm.ReportPage1.MilStatus = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.TotalCodes = binaryReader.ReadInt32();
			m_bReportForm.ReportPage1.FreezeFrameDTC = binaryReader.ReadString();
			StringCollection stringCollection1 = new StringCollection();
			uint num2 = 25U;
			do
			{
				string str = binaryReader.ReadString();
				if (str.Length > 0)
					stringCollection1.Add(str);
				--num2;
			}
			while (num2 > 0U);
			m_bReportForm.ReportPage1.DTCList = stringCollection1;
			StringCollection stringCollection2 = new StringCollection();
			uint num3 = 25U;
			do
			{
				string str = binaryReader.ReadString();
				if (str.Length > 0)
					stringCollection2.Add(str);
				--num3;
			}
			while (num3 > 0U);
			m_bReportForm.ReportPage1.DTCDefinitionList = stringCollection2;
			StringCollection stringCollection3 = new StringCollection();
			uint num4 = 25U;
			do
			{
				string str = binaryReader.ReadString();
				if (str.Length > 0)
					stringCollection3.Add(str);
				--num4;
			}
			while (num4 > 0U);
			m_bReportForm.ReportPage1.PendingList = stringCollection3;
			StringCollection stringCollection4 = new StringCollection();
			uint num5 = 25U;
			do
			{
				string str = binaryReader.ReadString();
				if (str.Length > 0)
					stringCollection4.Add(str);
				--num5;
			}
			while (num5 > 0U);
			m_bReportForm.ReportPage1.PendingDefinitionList = stringCollection4;
			m_bReportForm.ReportPage1.FuelSystem1Status = binaryReader.ReadString();
			m_bReportForm.ReportPage1.FuelSystem2Status = binaryReader.ReadString();
			m_bReportForm.ReportPage1.CalculatedLoad = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.EngineCoolantTemp = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.STFT1 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.STFT2 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.STFT3 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.STFT4 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.LTFT1 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.LTFT2 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.LTFT3 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.LTFT4 = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.IntakePressure = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.EngineRPM = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.VehicleSpeed = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.SparkAdvance = binaryReader.ReadDouble();
			m_bReportForm.ReportPage1.ShowFuelSystemStatus = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowCalculatedLoad = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowEngineCoolantTemp = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowSTFT13 = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowSTFT24 = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowLTFT13 = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowLTFT24 = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowIntakePressure = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowEngineRPM = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowVehicleSpeed = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ShowSparkAdvance = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.MisfireMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.MisfireMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.FuelSystemMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.FuelSystemMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ComprehensiveMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.ComprehensiveMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.CatalystMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.CatalystMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.HeatedCatalystMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.HeatedCatalystMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.EvapSystemMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.EvapSystemMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.SecondaryAirMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.SecondaryAirMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.RefrigerantMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.RefrigerantMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.OxygenSensorMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.OxygenSensorMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.OxygenSensorHeaterMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.OxygenSensorHeaterMonitorCompleted = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.EGRSystemMonitorSupported = binaryReader.ReadBoolean();
			m_bReportForm.ReportPage1.EGRSystemMonitorCompleted = binaryReader.ReadBoolean();
			binaryReader.Close();
			fileStream.Close();
			int num6 = (int)m_bReportForm.ShowDialog();
		}

		private void ReportGeneratorForm_Load(object sender, EventArgs e)
		{
			txtByName.Text = m_obdInterface.GetUserPreferences().Name;
			txtByAddress1.Text = m_obdInterface.GetUserPreferences().Address1;
			txtByAddress2.Text = m_obdInterface.GetUserPreferences().Address2;
			txtByTelephone.Text = m_obdInterface.GetUserPreferences().Telephone;
		}

		private void ReportGeneratorForm_Activated(object sender, EventArgs e)
		{
			txtByName.Text = m_obdInterface.GetUserPreferences().Name;
			txtByAddress1.Text = m_obdInterface.GetUserPreferences().Address1;
			txtByAddress2.Text = m_obdInterface.GetUserPreferences().Address2;
			txtByTelephone.Text = m_obdInterface.GetUserPreferences().Telephone;
		}
	}
}