using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class TerminalForm : Form
	{
		private string m_strID;
		private OBDInterface m_obdInterface;

		public TerminalForm(OBDInterface obd)
		{
			m_obdInterface = obd;
			InitializeComponent();

			m_strID = m_obdInterface.getDeviceIDString();
			Update();
			richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
			richText.SelectionColor = Color.Black;
			addPrompt();
		}

		private void addPrompt()
		{
			if (string.IsNullOrEmpty(m_strID))
				richText.AppendText("ELM > ");
			else
				richText.AppendText(m_strID + " > ");
		}

		public new void Update()
		{
			if (string.IsNullOrEmpty(m_strID))
				lblPrompt.Text = "ELM >";
			else
				lblPrompt.Text = m_strID + " > ";
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			richText.SelectionStart = richText.Text.Length;
			richText.Focus();

			if (!m_obdInterface.ConnectedStatus)
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
			richText.SelectionColor = Color.Blue;
			richText.AppendText(txtCommand.Text);
			richText.AppendText("\r\n\r\n");

			richText.SelectionColor = Color.DarkMagenta;
			richText.SelectionFont = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
			richText.AppendText(m_obdInterface.getRawResponse(txtCommand.Text));

			richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
			richText.AppendText("\r\n\r\n");
			richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
			richText.SelectionColor = Color.Black;
			addPrompt();
		}

		#region InitializeComponent
		private RichTextBox richText;
		private TextBox txtCommand;
		private Label lblPrompt;
		private Button btnSend;

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.richText = new System.Windows.Forms.RichTextBox();
			this.lblPrompt = new System.Windows.Forms.Label();
			this.txtCommand = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richText
			// 
			this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.richText.Location = new System.Drawing.Point(10, 46);
			this.richText.Name = "richText";
			this.richText.ReadOnly = true;
			this.richText.Size = new System.Drawing.Size(406, 392);
			this.richText.TabIndex = 0;
			this.richText.Text = "";
			// 
			// lblPrompt
			// 
			this.lblPrompt.Location = new System.Drawing.Point(10, 12);
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.Size = new System.Drawing.Size(68, 23);
			this.lblPrompt.TabIndex = 1;
			this.lblPrompt.Text = "Data";
			this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCommand
			// 
			this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCommand.Location = new System.Drawing.Point(84, 12);
			this.txtCommand.Name = "txtCommand";
			this.txtCommand.Size = new System.Drawing.Size(243, 22);
			this.txtCommand.TabIndex = 2;
			this.txtCommand.Text = "01 01";
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.AutoSize = true;
			this.btnSend.Location = new System.Drawing.Point(345, 10);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(72, 27);
			this.btnSend.TabIndex = 3;
			this.btnSend.Text = "&Send";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// TerminalForm
			// 
			this.AcceptButton = this.btnSend;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(425, 445);
			this.ControlBox = false;
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtCommand);
			this.Controls.Add(this.lblPrompt);
			this.Controls.Add(this.richText);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TerminalForm";
			this.Text = "Terminal";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
