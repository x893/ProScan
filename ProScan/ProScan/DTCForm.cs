using System;
using System.Collections;
using System.Collections.Generic;
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
		private OBDInterface m_obdInterface;
		private bool m_bMilStatus;
		private int m_iTotalDTC;
		private List<DTC> m_ListDTC;
		private List<DTC> m_ListPending;
		private List<DTC> m_ListPermanent;

		private GroupBox groupMIL;
		private PictureBox picMilOn;
		private PictureBox picMilOff;
		private Button btnRefresh;
		private Button btnErase;
		private GroupBox groupTotal;
		private Label lblTotalCodes;
		private Label lblMilStatus;
		private PictureBox picMIL;
		private GroupBox groupPermanent;
		private RichTextBox richTextPermanent;
		private GroupBox groupCodes;
		private RichTextBox richTextDTC;
		private GroupBox groupPending;
		private RichTextBox richTextPending;

		public DTCForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
			CheckConnection();
		}

		#region InitializeComponent
		protected override void Dispose(bool disposing)
		{
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
		#endregion

		public void CheckConnection()
		{
			if (m_obdInterface.ConnectedStatus)
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
			if (!m_obdInterface.ConnectedStatus)
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
			m_ListDTC.Clear();
			m_ListPending.Clear();
			m_ListPermanent.Clear();
			OBDParameterValue value;

			value = m_obdInterface.getValue("SAE.MIL", true);
			if (!value.ErrorDetected)
				SetMilStatus(value.BoolValue);

			value = m_obdInterface.getValue("SAE.DTC_COUNT", true);
			if (!value.ErrorDetected)
				SetDTCTotal((int)value.DoubleValue);

			value = m_obdInterface.getValue("SAE.STORED_DTCS", true);
			if (!value.ErrorDetected)
				foreach (string dtc in value.StringCollectionValue)
					m_ListDTC.Add(m_obdInterface.GetDTC(dtc));
			
			value = m_obdInterface.getValue("SAE.PENDING_DTCS", true);
			if (!value.ErrorDetected)
				foreach (string dtc in value.StringCollectionValue)
					m_ListPending.Add(m_obdInterface.GetDTC(dtc));

			value = m_obdInterface.getValue("SAE.PERMANENT_DTCS", true);
			if (!value.ErrorDetected)
				foreach (string dtc in value.StringCollectionValue)
					m_ListPermanent.Add(m_obdInterface.GetDTC(dtc));
		}

		private void DTCForm_Load(object sender, EventArgs e)
		{
			m_ListDTC = new List<DTC>();
			m_ListPending = new List<DTC>();
			m_ListPermanent = new List<DTC>();
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

		private void RefreshDisplay()
		{
			richTextDTC.Text = "";
			richTextPending.Text = "";
			richTextPermanent.Text = "";
			int idx;
			string text;

			if (m_ListDTC.Count > 0)
			{
				for (idx = 1; idx <= m_ListDTC.Count; idx++)
				{
					DTC dtc = m_ListDTC[idx - 1];
					richTextDTC.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
					richTextDTC.SelectionColor = Color.Red;
					richTextDTC.AppendText(string.Format("{0}. {1}\r\n", idx, dtc.Name));

					if (string.IsNullOrEmpty(dtc.Description))
					{
						richTextDTC.SelectionFont = new Font("Courier New", 10f, FontStyle.Italic | FontStyle.Bold);
						richTextDTC.SelectionColor = Color.Black;
						text = "    No definition found.\r\n\r\n";
					}
					else
					{
						richTextDTC.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
						richTextDTC.SelectionColor = Color.Black;
						text = string.Format("    {0}: {1}\r\n\r\n", dtc.Category, dtc.Description);
					}
					richTextDTC.AppendText(text);
				}
			}
			else
			{
				richTextDTC.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
				richTextDTC.SelectionColor = Color.Green;
				richTextDTC.AppendText("No stored trouble codes found.");
			}

			if (m_ListPending.Count > 0)
			{
				for (idx = 1; idx <= m_ListPending.Count; idx++)
				{
					DTC dtc = m_ListPending[idx - 1];
					richTextPending.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
					richTextPending.SelectionColor = Color.Red;
					richTextPending.AppendText(string.Format("{0}. {1}\r\n", idx, dtc.Name));

					if (string.IsNullOrEmpty(dtc.Description))
					{
						richTextPending.SelectionFont = new Font("Courier New", 10f, FontStyle.Italic | FontStyle.Bold);
						richTextPending.SelectionColor = Color.Black;
						text = "    No definition found.\r\n\r\n";
					}
					else
					{
						richTextPending.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
						richTextPending.SelectionColor = Color.Black;
						text = string.Format("    {0}: {1}\r\n\r\n", dtc.Category, dtc.Description);
					}
					richTextPending.AppendText(text);
				}
			}
			else
			{
				richTextPending.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
				richTextPending.SelectionColor = Color.Green;
				richTextPending.AppendText("No pending trouble codes found.");
			}

			if (m_ListPermanent.Count > 0)
			{
				for (idx = 1; idx <= m_ListPermanent.Count; idx++)
				{
					DTC dtc = (DTC)m_ListPermanent[idx - 1];
					richTextPermanent.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
					richTextPermanent.SelectionColor = Color.Red;
					richTextPermanent.AppendText(string.Format("{0}. {1}\r\n", idx, dtc.Name));

					if (string.IsNullOrEmpty(dtc.Description))
					{
						richTextPermanent.SelectionFont = new Font("Courier New", 10f, FontStyle.Italic | FontStyle.Bold);
						richTextPermanent.SelectionColor = Color.Black;
						text = "    No definition found.\r\n\r\n";
					}
					else
					{
						richTextPermanent.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
						richTextPermanent.SelectionColor = Color.Black;
						text = string.Format("    {0}: {1}\r\n\r\n", dtc.Category, dtc.Description);
					}
					richTextPermanent.AppendText(text);
				}
			}
			else
			{
				richTextPermanent.SelectionFont = new Font("Courier New", 12f, FontStyle.Bold);
				richTextPermanent.SelectionColor = Color.Green;
				richTextPermanent.AppendText("No permanent trouble codes found.");
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshDiagnosticData();
		}

		private void btnErase_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.ConnectedStatus)
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
