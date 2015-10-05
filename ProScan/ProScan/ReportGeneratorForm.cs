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

		public ReportGeneratorForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupPreparedBy = new System.Windows.Forms.GroupBox();
			this.txtByTelephone = new System.Windows.Forms.TextBox();
			this.lblByTelephone = new System.Windows.Forms.Label();
			this.txtByAddress2 = new System.Windows.Forms.TextBox();
			this.lblByAddress2 = new System.Windows.Forms.Label();
			this.txtByAddress1 = new System.Windows.Forms.TextBox();
			this.lblByAddress1 = new System.Windows.Forms.Label();
			this.txtByName = new System.Windows.Forms.TextBox();
			this.lblByName = new System.Windows.Forms.Label();
			this.groupPreparedFor = new System.Windows.Forms.GroupBox();
			this.txtForTelephone = new System.Windows.Forms.TextBox();
			this.lblForTelephone = new System.Windows.Forms.Label();
			this.txtForAddress2 = new System.Windows.Forms.TextBox();
			this.lblForAddress2 = new System.Windows.Forms.Label();
			this.txtForAddress1 = new System.Windows.Forms.TextBox();
			this.lblForAddress1 = new System.Windows.Forms.Label();
			this.txtForName = new System.Windows.Forms.TextBox();
			this.lblForName = new System.Windows.Forms.Label();
			this.groupStatus = new System.Windows.Forms.GroupBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.richTextStatus = new System.Windows.Forms.RichTextBox();
			this.groupVehicle = new System.Windows.Forms.GroupBox();
			this.txtVehicleModel = new System.Windows.Forms.TextBox();
			this.lblVehicleModel = new System.Windows.Forms.Label();
			this.txtVehicleMake = new System.Windows.Forms.TextBox();
			this.lblVehicleMake = new System.Windows.Forms.Label();
			this.txtVehicleYear = new System.Windows.Forms.TextBox();
			this.lblVehicleYear = new System.Windows.Forms.Label();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.panel = new System.Windows.Forms.Panel();
			this.groupPreparedBy.SuspendLayout();
			this.groupPreparedFor.SuspendLayout();
			this.groupStatus.SuspendLayout();
			this.groupVehicle.SuspendLayout();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupPreparedBy
			// 
			this.groupPreparedBy.Controls.Add(this.txtByTelephone);
			this.groupPreparedBy.Controls.Add(this.lblByTelephone);
			this.groupPreparedBy.Controls.Add(this.txtByAddress2);
			this.groupPreparedBy.Controls.Add(this.lblByAddress2);
			this.groupPreparedBy.Controls.Add(this.txtByAddress1);
			this.groupPreparedBy.Controls.Add(this.lblByAddress1);
			this.groupPreparedBy.Controls.Add(this.txtByName);
			this.groupPreparedBy.Controls.Add(this.lblByName);
			this.groupPreparedBy.Location = new System.Drawing.Point(12, 87);
			this.groupPreparedBy.Name = "groupPreparedBy";
			this.groupPreparedBy.Size = new System.Drawing.Size(318, 144);
			this.groupPreparedBy.TabIndex = 0;
			this.groupPreparedBy.TabStop = false;
			this.groupPreparedBy.Text = "Prepared By";
			// 
			// txtByTelephone
			// 
			this.txtByTelephone.Location = new System.Drawing.Point(126, 110);
			this.txtByTelephone.MaxLength = 35;
			this.txtByTelephone.Name = "txtByTelephone";
			this.txtByTelephone.Size = new System.Drawing.Size(180, 22);
			this.txtByTelephone.TabIndex = 7;
			// 
			// lblByTelephone
			// 
			this.lblByTelephone.Location = new System.Drawing.Point(12, 110);
			this.lblByTelephone.Name = "lblByTelephone";
			this.lblByTelephone.Size = new System.Drawing.Size(108, 23);
			this.lblByTelephone.TabIndex = 6;
			this.lblByTelephone.Text = "Telephone:";
			this.lblByTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtByAddress2
			// 
			this.txtByAddress2.Location = new System.Drawing.Point(126, 81);
			this.txtByAddress2.MaxLength = 35;
			this.txtByAddress2.Name = "txtByAddress2";
			this.txtByAddress2.Size = new System.Drawing.Size(180, 22);
			this.txtByAddress2.TabIndex = 5;
			// 
			// lblByAddress2
			// 
			this.lblByAddress2.Location = new System.Drawing.Point(12, 81);
			this.lblByAddress2.Name = "lblByAddress2";
			this.lblByAddress2.Size = new System.Drawing.Size(108, 23);
			this.lblByAddress2.TabIndex = 4;
			this.lblByAddress2.Text = "Address Line 2:";
			this.lblByAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtByAddress1
			// 
			this.txtByAddress1.Location = new System.Drawing.Point(126, 52);
			this.txtByAddress1.MaxLength = 35;
			this.txtByAddress1.Name = "txtByAddress1";
			this.txtByAddress1.Size = new System.Drawing.Size(180, 22);
			this.txtByAddress1.TabIndex = 3;
			// 
			// lblByAddress1
			// 
			this.lblByAddress1.Location = new System.Drawing.Point(12, 52);
			this.lblByAddress1.Name = "lblByAddress1";
			this.lblByAddress1.Size = new System.Drawing.Size(108, 23);
			this.lblByAddress1.TabIndex = 2;
			this.lblByAddress1.Text = "Address Line 1:";
			this.lblByAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtByName
			// 
			this.txtByName.Location = new System.Drawing.Point(126, 23);
			this.txtByName.MaxLength = 35;
			this.txtByName.Name = "txtByName";
			this.txtByName.Size = new System.Drawing.Size(180, 22);
			this.txtByName.TabIndex = 1;
			// 
			// lblByName
			// 
			this.lblByName.Location = new System.Drawing.Point(12, 23);
			this.lblByName.Name = "lblByName";
			this.lblByName.Size = new System.Drawing.Size(108, 23);
			this.lblByName.TabIndex = 0;
			this.lblByName.Text = "Name:";
			this.lblByName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupPreparedFor
			// 
			this.groupPreparedFor.Controls.Add(this.txtForTelephone);
			this.groupPreparedFor.Controls.Add(this.lblForTelephone);
			this.groupPreparedFor.Controls.Add(this.txtForAddress2);
			this.groupPreparedFor.Controls.Add(this.lblForAddress2);
			this.groupPreparedFor.Controls.Add(this.txtForAddress1);
			this.groupPreparedFor.Controls.Add(this.lblForAddress1);
			this.groupPreparedFor.Controls.Add(this.txtForName);
			this.groupPreparedFor.Controls.Add(this.lblForName);
			this.groupPreparedFor.Location = new System.Drawing.Point(12, 242);
			this.groupPreparedFor.Name = "groupPreparedFor";
			this.groupPreparedFor.Size = new System.Drawing.Size(318, 145);
			this.groupPreparedFor.TabIndex = 1;
			this.groupPreparedFor.TabStop = false;
			this.groupPreparedFor.Text = "Prepared For";
			// 
			// txtForTelephone
			// 
			this.txtForTelephone.Location = new System.Drawing.Point(126, 110);
			this.txtForTelephone.MaxLength = 35;
			this.txtForTelephone.Name = "txtForTelephone";
			this.txtForTelephone.Size = new System.Drawing.Size(180, 22);
			this.txtForTelephone.TabIndex = 7;
			// 
			// lblForTelephone
			// 
			this.lblForTelephone.Location = new System.Drawing.Point(12, 110);
			this.lblForTelephone.Name = "lblForTelephone";
			this.lblForTelephone.Size = new System.Drawing.Size(108, 23);
			this.lblForTelephone.TabIndex = 6;
			this.lblForTelephone.Text = "Telephone:";
			this.lblForTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtForAddress2
			// 
			this.txtForAddress2.Location = new System.Drawing.Point(126, 81);
			this.txtForAddress2.MaxLength = 35;
			this.txtForAddress2.Name = "txtForAddress2";
			this.txtForAddress2.Size = new System.Drawing.Size(180, 22);
			this.txtForAddress2.TabIndex = 5;
			// 
			// lblForAddress2
			// 
			this.lblForAddress2.Location = new System.Drawing.Point(12, 81);
			this.lblForAddress2.Name = "lblForAddress2";
			this.lblForAddress2.Size = new System.Drawing.Size(108, 23);
			this.lblForAddress2.TabIndex = 4;
			this.lblForAddress2.Text = "Address Line 2:";
			this.lblForAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtForAddress1
			// 
			this.txtForAddress1.Location = new System.Drawing.Point(126, 52);
			this.txtForAddress1.MaxLength = 35;
			this.txtForAddress1.Name = "txtForAddress1";
			this.txtForAddress1.Size = new System.Drawing.Size(180, 22);
			this.txtForAddress1.TabIndex = 3;
			// 
			// lblForAddress1
			// 
			this.lblForAddress1.Location = new System.Drawing.Point(12, 52);
			this.lblForAddress1.Name = "lblForAddress1";
			this.lblForAddress1.Size = new System.Drawing.Size(108, 23);
			this.lblForAddress1.TabIndex = 2;
			this.lblForAddress1.Text = "Address Line 1:";
			this.lblForAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtForName
			// 
			this.txtForName.Location = new System.Drawing.Point(126, 23);
			this.txtForName.MaxLength = 35;
			this.txtForName.Name = "txtForName";
			this.txtForName.Size = new System.Drawing.Size(180, 22);
			this.txtForName.TabIndex = 1;
			// 
			// lblForName
			// 
			this.lblForName.Location = new System.Drawing.Point(12, 23);
			this.lblForName.Name = "lblForName";
			this.lblForName.Size = new System.Drawing.Size(108, 23);
			this.lblForName.TabIndex = 0;
			this.lblForName.Text = "Name:";
			this.lblForName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupStatus
			// 
			this.groupStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupStatus.Controls.Add(this.progressBar);
			this.groupStatus.Controls.Add(this.richTextStatus);
			this.groupStatus.Location = new System.Drawing.Point(341, 12);
			this.groupStatus.Name = "groupStatus";
			this.groupStatus.Size = new System.Drawing.Size(557, 515);
			this.groupStatus.TabIndex = 4;
			this.groupStatus.TabStop = false;
			this.groupStatus.Text = "Status";
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(12, 23);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(532, 27);
			this.progressBar.TabIndex = 0;
			// 
			// richTextStatus
			// 
			this.richTextStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextStatus.Location = new System.Drawing.Point(12, 55);
			this.richTextStatus.Name = "richTextStatus";
			this.richTextStatus.ReadOnly = true;
			this.richTextStatus.Size = new System.Drawing.Size(532, 450);
			this.richTextStatus.TabIndex = 1;
			this.richTextStatus.Text = "";
			// 
			// groupVehicle
			// 
			this.groupVehicle.Controls.Add(this.txtVehicleModel);
			this.groupVehicle.Controls.Add(this.lblVehicleModel);
			this.groupVehicle.Controls.Add(this.txtVehicleMake);
			this.groupVehicle.Controls.Add(this.lblVehicleMake);
			this.groupVehicle.Controls.Add(this.txtVehicleYear);
			this.groupVehicle.Controls.Add(this.lblVehicleYear);
			this.groupVehicle.Location = new System.Drawing.Point(12, 398);
			this.groupVehicle.Name = "groupVehicle";
			this.groupVehicle.Size = new System.Drawing.Size(318, 119);
			this.groupVehicle.TabIndex = 2;
			this.groupVehicle.TabStop = false;
			this.groupVehicle.Text = "Vehicle";
			// 
			// txtVehicleModel
			// 
			this.txtVehicleModel.Location = new System.Drawing.Point(126, 81);
			this.txtVehicleModel.MaxLength = 35;
			this.txtVehicleModel.Name = "txtVehicleModel";
			this.txtVehicleModel.Size = new System.Drawing.Size(180, 22);
			this.txtVehicleModel.TabIndex = 5;
			// 
			// lblVehicleModel
			// 
			this.lblVehicleModel.Location = new System.Drawing.Point(12, 81);
			this.lblVehicleModel.Name = "lblVehicleModel";
			this.lblVehicleModel.Size = new System.Drawing.Size(108, 23);
			this.lblVehicleModel.TabIndex = 4;
			this.lblVehicleModel.Text = "Model:";
			this.lblVehicleModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVehicleMake
			// 
			this.txtVehicleMake.Location = new System.Drawing.Point(126, 52);
			this.txtVehicleMake.MaxLength = 35;
			this.txtVehicleMake.Name = "txtVehicleMake";
			this.txtVehicleMake.Size = new System.Drawing.Size(180, 22);
			this.txtVehicleMake.TabIndex = 3;
			// 
			// lblVehicleMake
			// 
			this.lblVehicleMake.Location = new System.Drawing.Point(12, 52);
			this.lblVehicleMake.Name = "lblVehicleMake";
			this.lblVehicleMake.Size = new System.Drawing.Size(108, 23);
			this.lblVehicleMake.TabIndex = 2;
			this.lblVehicleMake.Text = "Make:";
			this.lblVehicleMake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtVehicleYear
			// 
			this.txtVehicleYear.Location = new System.Drawing.Point(126, 23);
			this.txtVehicleYear.MaxLength = 4;
			this.txtVehicleYear.Name = "txtVehicleYear";
			this.txtVehicleYear.Size = new System.Drawing.Size(180, 22);
			this.txtVehicleYear.TabIndex = 1;
			// 
			// lblVehicleYear
			// 
			this.lblVehicleYear.Location = new System.Drawing.Point(12, 23);
			this.lblVehicleYear.Name = "lblVehicleYear";
			this.lblVehicleYear.Size = new System.Drawing.Size(108, 23);
			this.lblVehicleYear.TabIndex = 0;
			this.lblVehicleYear.Text = "Year:";
			this.lblVehicleYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(12, 52);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(318, 26);
			this.btnOpen.TabIndex = 3;
			this.btnOpen.Text = "&Open a Saved Report";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(12, 17);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(318, 27);
			this.btnGenerate.TabIndex = 5;
			this.btnGenerate.Text = "&Generate a New Report";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.AutoScroll = true;
			this.panel.Controls.Add(this.btnGenerate);
			this.panel.Controls.Add(this.btnOpen);
			this.panel.Controls.Add(this.groupVehicle);
			this.panel.Controls.Add(this.groupPreparedFor);
			this.panel.Controls.Add(this.groupPreparedBy);
			this.panel.Controls.Add(this.groupStatus);
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(905, 529);
			this.panel.TabIndex = 6;
			// 
			// ReportGeneratorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(906, 533);
			this.ControlBox = false;
			this.Controls.Add(this.panel);
			this.Name = "ReportGeneratorForm";
			this.Text = "Diagnostic Report Generator";
			this.Activated += new System.EventHandler(this.ReportGeneratorForm_Activated);
			this.Load += new System.EventHandler(this.ReportGeneratorForm_Load);
			this.groupPreparedBy.ResumeLayout(false);
			this.groupPreparedBy.PerformLayout();
			this.groupPreparedFor.ResumeLayout(false);
			this.groupPreparedFor.PerformLayout();
			this.groupStatus.ResumeLayout(false);
			this.groupVehicle.ResumeLayout(false);
			this.groupVehicle.PerformLayout();
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.ConnectedStatus)
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
						DTC dtc2 = m_obdInterface.GetDTC(enumerator2.Current);
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
						DTC dtc = m_obdInterface.GetDTC(enumerator.Current);
						if (dtc != null)
						{
							m_bReportForm.ReportPage1.PendingDefinitionList.Add(dtc.Description);
						}
					}
					while (enumerator.MoveNext());
				}
			}

			DisplayStatusMessage("Checking for Freeze Frame Data");
			OBDParameter parameter = m_obdInterface.LookupParameter("SAE.FF_DTC");
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
			OBDParameter param = m_obdInterface.LookupParameter("SAE.FUEL1_STATUS");
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
			OBDParameter freezeFrameCopy = m_obdInterface.LookupParameter("SAE.FUEL2_STATUS");
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
			OBDParameter parameter16 = m_obdInterface.LookupParameter("SAE.LOAD_CALC");
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
			OBDParameter parameter14 = m_obdInterface.LookupParameter("SAE.ECT");
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
			OBDParameter parameter13 = m_obdInterface.LookupParameter("SAE.STFT1");
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
			OBDParameter parameter12 = m_obdInterface.LookupParameter("SAE.STFT3");
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
			OBDParameter parameter11 = m_obdInterface.LookupParameter("SAE.LTFT1");
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
			OBDParameter parameter10 = m_obdInterface.LookupParameter("SAE.LTFT3");
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
			OBDParameter parameter9 = m_obdInterface.LookupParameter("SAE.STFT2");
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
			OBDParameter parameter8 = m_obdInterface.LookupParameter("SAE.STFT4");
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
			OBDParameter parameter7 = m_obdInterface.LookupParameter("SAE.LTFT2");
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
			OBDParameter parameter6 = m_obdInterface.LookupParameter("SAE.LTFT4");
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
			OBDParameter parameter5 = m_obdInterface.LookupParameter("SAE.MAP");
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
			OBDParameter parameter4 = m_obdInterface.LookupParameter("SAE.RPM");
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
			OBDParameter parameter3 = m_obdInterface.LookupParameter("SAE.VSS");
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
			OBDParameter parameter2 = m_obdInterface.LookupParameter("SAE.SPARKADV");
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
			txtByName.Text = m_obdInterface.UserPreferences.Name;
			txtByAddress1.Text = m_obdInterface.UserPreferences.Address1;
			txtByAddress2.Text = m_obdInterface.UserPreferences.Address2;
			txtByTelephone.Text = m_obdInterface.UserPreferences.Telephone;
		}

		private void ReportGeneratorForm_Activated(object sender, EventArgs e)
		{
			txtByName.Text = m_obdInterface.UserPreferences.Name;
			txtByAddress1.Text = m_obdInterface.UserPreferences.Address1;
			txtByAddress2.Text = m_obdInterface.UserPreferences.Address2;
			txtByTelephone.Text = m_obdInterface.UserPreferences.Telephone;
		}
	}
}