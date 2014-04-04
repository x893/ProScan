using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class DTCForm : Form
	{
		private GroupBox groupMIL;
		private PictureBox picMilOn;
		private PictureBox picMilOff;
		private Button btnRefresh;
		private Button btnErase;
		private GroupBox groupTotal;
		private Label lblTotalCodes;
		private Label lblMilStatus;
		private PictureBox picMIL;
		private OBDInterface m_obdInterface;
		private bool m_bMilStatus;
		private int m_iTotalDTC;
		private ArrayList arrayListDTC;
		private GroupBox groupPermanent;
		private RichTextBox richTextPermanent;
		private GroupBox groupCodes;
		private RichTextBox richTextDTC;
		private GroupBox groupPending;
		private RichTextBox richTextPending;
		private ArrayList arrayListPending;
		private ArrayList arrayListPermanent;
		private Container components;

		public DTCForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
			CheckConnection();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTCForm));
			picMilOn = new System.Windows.Forms.PictureBox();
			groupMIL = new System.Windows.Forms.GroupBox();
			lblMilStatus = new System.Windows.Forms.Label();
			picMIL = new System.Windows.Forms.PictureBox();
			picMilOff = new System.Windows.Forms.PictureBox();
			groupPermanent = new System.Windows.Forms.GroupBox();
			richTextPermanent = new System.Windows.Forms.RichTextBox();
			btnRefresh = new System.Windows.Forms.Button();
			btnErase = new System.Windows.Forms.Button();
			groupTotal = new System.Windows.Forms.GroupBox();
			lblTotalCodes = new System.Windows.Forms.Label();
			groupCodes = new System.Windows.Forms.GroupBox();
			richTextDTC = new System.Windows.Forms.RichTextBox();
			groupPending = new System.Windows.Forms.GroupBox();
			richTextPending = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(picMilOn)).BeginInit();
			groupMIL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(picMIL)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(picMilOff)).BeginInit();
			groupPermanent.SuspendLayout();
			groupTotal.SuspendLayout();
			groupCodes.SuspendLayout();
			groupPending.SuspendLayout();
			SuspendLayout();
			// 
			// picMilOn
			// 
			picMilOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			picMilOn.Image = ((System.Drawing.Image)(resources.GetObject("picMilOn.Image")));
			picMilOn.Location = new System.Drawing.Point(15, 25);
			picMilOn.Name = "picMilOn";
			picMilOn.Size = new System.Drawing.Size(100, 50);
			picMilOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			picMilOn.TabIndex = 0;
			picMilOn.TabStop = false;
			picMilOn.Visible = false;
			// 
			// groupMIL
			// 
			groupMIL.Controls.Add(lblMilStatus);
			groupMIL.Controls.Add(picMIL);
			groupMIL.Controls.Add(picMilOff);
			groupMIL.Controls.Add(picMilOn);
			groupMIL.Location = new System.Drawing.Point(15, 15);
			groupMIL.Name = "groupMIL";
			groupMIL.Size = new System.Drawing.Size(130, 155);
			groupMIL.TabIndex = 1;
			groupMIL.TabStop = false;
			groupMIL.Text = "Check Engine Lamp";
			// 
			// lblMilStatus
			// 
			lblMilStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			lblMilStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblMilStatus.Location = new System.Drawing.Point(15, 90);
			lblMilStatus.Name = "lblMilStatus";
			lblMilStatus.Size = new System.Drawing.Size(100, 50);
			lblMilStatus.TabIndex = 1;
			lblMilStatus.Text = "ON";
			lblMilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// picMIL
			// 
			picMIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			picMIL.Location = new System.Drawing.Point(15, 25);
			picMIL.Name = "picMIL";
			picMIL.Size = new System.Drawing.Size(100, 50);
			picMIL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			picMIL.TabIndex = 3;
			picMIL.TabStop = false;
			// 
			// picMilOff
			// 
			picMilOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			picMilOff.Image = ((System.Drawing.Image)(resources.GetObject("picMilOff.Image")));
			picMilOff.Location = new System.Drawing.Point(15, 25);
			picMilOff.Name = "picMilOff";
			picMilOff.Size = new System.Drawing.Size(100, 50);
			picMilOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			picMilOff.TabIndex = 2;
			picMilOff.TabStop = false;
			picMilOff.Visible = false;
			// 
			// groupPermanent
			// 
			groupPermanent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupPermanent.Controls.Add(richTextPermanent);
			groupPermanent.Location = new System.Drawing.Point(160, 15);
			groupPermanent.Name = "groupPermanent";
			groupPermanent.Size = new System.Drawing.Size(399, 161);
			groupPermanent.TabIndex = 2;
			groupPermanent.TabStop = false;
			groupPermanent.Text = "Permanent Trouble Codes";
			// 
			// richTextPermanent
			// 
			richTextPermanent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			richTextPermanent.Location = new System.Drawing.Point(16, 24);
			richTextPermanent.Name = "richTextPermanent";
			richTextPermanent.ReadOnly = true;
			richTextPermanent.Size = new System.Drawing.Size(364, 120);
			richTextPermanent.TabIndex = 0;
			richTextPermanent.Text = "";
			// 
			// btnRefresh
			// 
			btnRefresh.Location = new System.Drawing.Point(15, 283);
			btnRefresh.Name = "btnRefresh";
			btnRefresh.Size = new System.Drawing.Size(130, 25);
			btnRefresh.TabIndex = 3;
			btnRefresh.Text = "&Refresh";
			btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
			// 
			// btnErase
			// 
			btnErase.Location = new System.Drawing.Point(15, 320);
			btnErase.Name = "btnErase";
			btnErase.Size = new System.Drawing.Size(130, 25);
			btnErase.TabIndex = 4;
			btnErase.Text = "&Erase Codes";
			btnErase.Click += new System.EventHandler(btnErase_Click);
			// 
			// groupTotal
			// 
			groupTotal.Controls.Add(lblTotalCodes);
			groupTotal.Location = new System.Drawing.Point(15, 185);
			groupTotal.Name = "groupTotal";
			groupTotal.Size = new System.Drawing.Size(130, 90);
			groupTotal.TabIndex = 5;
			groupTotal.TabStop = false;
			groupTotal.Visible = false;
			// 
			// lblTotalCodes
			// 
			lblTotalCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblTotalCodes.Location = new System.Drawing.Point(15, 25);
			lblTotalCodes.Name = "lblTotalCodes";
			lblTotalCodes.Size = new System.Drawing.Size(100, 50);
			lblTotalCodes.TabIndex = 2;
			lblTotalCodes.Text = "0";
			lblTotalCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			lblTotalCodes.Visible = false;
			// 
			// groupCodes
			// 
			groupCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			groupCodes.Controls.Add(richTextDTC);
			groupCodes.Location = new System.Drawing.Point(159, 183);
			groupCodes.Name = "groupCodes";
			groupCodes.Size = new System.Drawing.Size(399, 161);
			groupCodes.TabIndex = 6;
			groupCodes.TabStop = false;
			groupCodes.Text = "Stored Trouble Codes";
			// 
			// richTextDTC
			// 
			richTextDTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			richTextDTC.Location = new System.Drawing.Point(17, 21);
			richTextDTC.Name = "richTextDTC";
			richTextDTC.ReadOnly = true;
			richTextDTC.Size = new System.Drawing.Size(364, 124);
			richTextDTC.TabIndex = 1;
			richTextDTC.Text = "";
			// 
			// groupPending
			// 
			groupPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			groupPending.Controls.Add(richTextPending);
			groupPending.Location = new System.Drawing.Point(159, 352);
			groupPending.Name = "groupPending";
			groupPending.Size = new System.Drawing.Size(399, 161);
			groupPending.TabIndex = 7;
			groupPending.TabStop = false;
			groupPending.Text = "Pending Trouble Codes";
			// 
			// richTextPending
			// 
			richTextPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			richTextPending.Location = new System.Drawing.Point(17, 21);
			richTextPending.Name = "richTextPending";
			richTextPending.ReadOnly = true;
			richTextPending.Size = new System.Drawing.Size(364, 124);
			richTextPending.TabIndex = 1;
			richTextPending.Text = "";
			// 
			// DTCForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(574, 580);
			ControlBox = false;
			Controls.Add(groupPending);
			Controls.Add(groupCodes);
			Controls.Add(groupTotal);
			Controls.Add(btnErase);
			Controls.Add(btnRefresh);
			Controls.Add(groupPermanent);
			Controls.Add(groupMIL);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(300, 405);
			Name = "DTCForm";
			ShowInTaskbar = false;
			Text = "Diagnostic Trouble Codes";
			Activated += new System.EventHandler(DTCForm_Activated);
			Load += new System.EventHandler(DTCForm_Load);
			Resize += new System.EventHandler(DTCForm_Resize);
			((System.ComponentModel.ISupportInitialize)(picMilOn)).EndInit();
			groupMIL.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(picMIL)).EndInit();
			((System.ComponentModel.ISupportInitialize)(picMilOff)).EndInit();
			groupPermanent.ResumeLayout(false);
			groupTotal.ResumeLayout(false);
			groupCodes.ResumeLayout(false);
			groupPending.ResumeLayout(false);
			ResumeLayout(false);

		}

		public void CheckConnection()
		{
			if (m_obdInterface.getConnectedStatus())
			{
				btnRefresh.Enabled = true;
				btnErase.Enabled = true;
			}
			else
			{
				btnRefresh.Enabled = false;
				btnErase.Enabled = false;
			}
		}

		public void RefreshDiagnosticData()
		{
			lblMilStatus.Text = "OFF";
			picMIL.Image = picMilOff.Image;
			lblTotalCodes.Text = "0";
			richTextDTC.Text = "";
			richTextPending.Text = "";
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				m_obdInterface.logItem("Error. DTC Form. Attempted refresh without vehicle connection.");
			}
			else
			{
				ReadCodes();
				RefreshDisplay();
			}
		}

		public void ReadCodes()
		{
			arrayListDTC.Clear();
			arrayListPending.Clear();
			arrayListPermanent.Clear();
			OBDParameterValue value6 = m_obdInterface.getValue("SAE.MIL", true);
			if (!value6.ErrorDetected)
			{
				SetMilStatus(value6.BoolValue);
			}
			OBDParameterValue value5 = m_obdInterface.getValue("SAE.DTC_COUNT", true);
			if (!value5.ErrorDetected)
			{
				SetDTCTotal((int)value5.DoubleValue);
			}
			OBDParameterValue value4 = m_obdInterface.getValue("SAE.STORED_DTCS", true);
			if (!value4.ErrorDetected)
			{
				StringEnumerator enumerator3 = value4.StringCollectionValue.GetEnumerator();
				if (enumerator3.MoveNext())
				{
					do
					{
						string current = enumerator3.Current;
						DTC dtc3 = m_obdInterface.getDTC(current);
						arrayListDTC.Add(dtc3);
					}
					while (enumerator3.MoveNext());
				}
			}
			OBDParameterValue value3 = m_obdInterface.getValue("SAE.PENDING_DTCS", true);
			if (!value3.ErrorDetected)
			{
				StringEnumerator enumerator2 = value3.StringCollectionValue.GetEnumerator();
				if (enumerator2.MoveNext())
				{
					do
					{
						string strDTC = enumerator2.Current;
						DTC dtc2 = m_obdInterface.getDTC(strDTC);
						arrayListPending.Add(dtc2);
					}
					while (enumerator2.MoveNext());
				}
			}
			OBDParameterValue value2 = m_obdInterface.getValue("SAE.PERMANENT_DTCS", true);
			if (!value2.ErrorDetected)
			{
				StringEnumerator enumerator = value2.StringCollectionValue.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						string str = enumerator.Current;
						DTC dtc = m_obdInterface.getDTC(str);
						arrayListPermanent.Add(dtc);
					}
					while (enumerator.MoveNext());
				}
			}
		}

		private void DTCForm_Load(object sender, EventArgs e)
		{
			arrayListDTC = new ArrayList();
			arrayListPending = new ArrayList();
			arrayListPermanent = new ArrayList();
			SetMilStatus(false);
		}

		private void SetMilStatus(bool bStatus)
		{
			m_bMilStatus = bStatus;
			if (bStatus)
			{
				lblMilStatus.Text = "ON";
				picMIL.Image = picMilOn.Image;
			}
			else
			{
				lblMilStatus.Text = "OFF";
				picMIL.Image = picMilOff.Image;
			}
		}

		private void SetDTCTotal(int iTotal)
		{
			m_iTotalDTC = iTotal;
			lblTotalCodes.Text = Convert.ToString(iTotal);
		}

		private bool isDTCAlreadyRecorded(string strDTC)
		{
			int num = 0;
			if (0 < arrayListDTC.Count)
			{
				do
				{
					if (string.Compare(((DTC)arrayListDTC[num]).Name, strDTC) == 0)
					{
						return true;
					}
					num++;
				}
				while (num < arrayListDTC.Count);
			}
			return false;
		}

		private bool isPendingAlreadyRecorded(string strDTC)
		{
			int num = 0;
			if (0 < arrayListPending.Count)
			{
				do
				{
					if (string.Compare(((DTC)arrayListPending[num]).Name, strDTC) == 0)
					{
						return true;
					}
					num++;
				}
				while (num < arrayListPending.Count);
			}
			return false;
		}

		private void RefreshDisplay()
		{
			richTextDTC.Text = "";
			richTextPending.Text = "";
			richTextPermanent.Text = "";
			if (arrayListDTC.Count > 0)
			{
				int num3 = 1;
				if (1 <= arrayListDTC.Count)
				{
					do
					{
						DTC dtc3 = (DTC)arrayListDTC[num3 - 1];
						string text = string.Format("{0}. {1}\r\n", num3, dtc3.Name);
						richTextDTC.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
						Color red = Color.Red;
						richTextDTC.SelectionColor = red;
						richTextDTC.AppendText(text);
						if (string.Compare(dtc3.Description, "") == 0)
						{
							richTextDTC.SelectionFont = new Font("Courier New", 10f, FontStyle.Italic | FontStyle.Bold);
							Color black = Color.Black;
							richTextDTC.SelectionColor = black;
							richTextDTC.AppendText("    No definition found.\r\n\r\n");
						}
						else
						{
							string str5 = string.Format("    {0}: {1}\r\n\r\n", dtc3.Category, dtc3.Description);
							richTextDTC.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
							Color color19 = Color.Black;
							richTextDTC.SelectionColor = color19;
							richTextDTC.AppendText(str5);
						}
						num3++;
					}
					while (num3 <= arrayListDTC.Count);
				}
			}
			else
			{
				richTextDTC.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
				Color green = Color.Green;
				richTextDTC.SelectionColor = green;
				richTextDTC.AppendText("No stored trouble codes found.");
			}
			if (arrayListPending.Count > 0)
			{
				int num2 = 1;
				if (1 <= arrayListPending.Count)
				{
					do
					{
						DTC dtc2 = (DTC)arrayListPending[num2 - 1];
						string str4 = string.Format("{0}. {1}\r\n", num2, dtc2.Name);
						richTextPending.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
						Color color15 = Color.Red;
						richTextPending.SelectionColor = color15;
						richTextPending.AppendText(str4);
						if (string.Compare(dtc2.Description, "") == 0)
						{
							richTextPending.SelectionFont = new Font("Courier New", 10f, FontStyle.Italic | FontStyle.Bold);
							Color color13 = Color.Black;
							richTextPending.SelectionColor = color13;
							richTextPending.AppendText("    No definition found.\r\n\r\n");
						}
						else
						{
							string str3 = string.Format("    {0}: {1}\r\n\r\n", dtc2.Category, dtc2.Description);
							richTextPending.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
							Color color11 = Color.Black;
							richTextPending.SelectionColor = color11;
							richTextPending.AppendText(str3);
						}
						num2++;
					}
					while (num2 <= arrayListPending.Count);
				}
			}
			else
			{
				richTextPending.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
				Color color9 = Color.Green;
				richTextPending.SelectionColor = color9;
				richTextPending.AppendText("No pending trouble codes found.");
			}
			if (arrayListPermanent.Count > 0)
			{
				int num = 1;
				if (1 <= arrayListPermanent.Count)
				{
					do
					{
						DTC dtc = (DTC)arrayListPermanent[num - 1];
						string str2 = string.Format("{0}. {1}\r\n", num, dtc.Name);
						richTextPermanent.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
						Color color7 = Color.Red;
						richTextPermanent.SelectionColor = color7;
						richTextPermanent.AppendText(str2);
						if (string.Compare(dtc.Description, "") == 0)
						{
							richTextPermanent.SelectionFont = new Font("Courier New", 10f, FontStyle.Italic | FontStyle.Bold);
							Color color5 = Color.Black;
							richTextPermanent.SelectionColor = color5;
							richTextPermanent.AppendText("    No definition found.\r\n\r\n");
						}
						else
						{
							string str = string.Format("    {0}: {1}\r\n\r\n", dtc.Category, dtc.Description);
							richTextPermanent.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
							Color color3 = Color.Black;
							richTextPermanent.SelectionColor = color3;
							richTextPermanent.AppendText(str);
						}
						num++;
					}
					while (num <= arrayListPermanent.Count);
				}
			}
			else
			{
				richTextPermanent.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
				Color color = Color.Green;
				richTextPermanent.SelectionColor = color;
				richTextPermanent.AppendText("No permanent trouble codes found.");
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshDiagnosticData();
		}

		private void btnErase_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				m_obdInterface.logItem("Error. DTC Form. Attempted to erase codes without vehicle connection.");
			}
			else if (MessageBox.Show("This will clear all trouble codes from your vehicle.\n\n" + "You should have repaired any problems indicated by these codes.\n\n" + "Also, your vehicle may run poorly for a short time while the system " + "recalibrates itself.\n\nAre you sure you want to reset your codes?", "Clear Trouble Codes?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				m_obdInterface.clearCodes();
				RefreshDiagnosticData();
			}
		}

		private void DTCForm_Resize(object sender, EventArgs e)
		{
			groupPermanent.Size = new Size(groupPermanent.Width, (Height - 70) / 3);
			groupCodes.Size = new Size(groupCodes.Width, (Height - 70) / 3);
			groupCodes.Location = new Point(groupCodes.Location.X, (Height - 60) / 3 + 20);
			groupPending.Size = new Size(groupPending.Width, (Height - 70) / 3);
			groupPending.Location = new Point(groupPending.Location.X, (Height * 2 - 120) / 3 + 20);
		}

		private void DTCForm_Activated(object sender, EventArgs e)
		{
			CheckConnection();
		}
	}
}