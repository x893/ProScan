using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class TerminalForm : Form
	{
		private RichTextBox richText;
		private Container components;
		private TextBox txtCommand;
		private Label lblPrompt;
		private Button btnSend;
		private string m_strID;
		private OBDInterface m_obdInterface;

		public TerminalForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			InitializeComponent();
			m_strID = m_obdInterface.getDeviceIDString();
			Update();
			richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
			richText.SelectionColor = Color.Black;
			if (string.Compare(m_strID, "") == 0)
				richText.AppendText("ELM > ");
			else
				richText.AppendText(m_strID + " > ");
		}

		public new void Update()
		{
			if (string.Compare(m_strID, "") == 0)
				lblPrompt.Text = "ELM >";
			else
				lblPrompt.Text = m_strID + " > ";
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			richText = new System.Windows.Forms.RichTextBox();
			lblPrompt = new System.Windows.Forms.Label();
			txtCommand = new System.Windows.Forms.TextBox();
			btnSend = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// richText
			// 
			richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			richText.Location = new System.Drawing.Point(8, 40);
			richText.Name = "richText";
			richText.ReadOnly = true;
			richText.Size = new System.Drawing.Size(376, 320);
			richText.TabIndex = 0;
			richText.Text = "";
			// 
			// lblPrompt
			// 
			lblPrompt.Location = new System.Drawing.Point(8, 10);
			lblPrompt.Name = "lblPrompt";
			lblPrompt.Size = new System.Drawing.Size(90, 20);
			lblPrompt.TabIndex = 1;
			lblPrompt.Text = "ELM >";
			lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCommand
			// 
			txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			txtCommand.Location = new System.Drawing.Point(110, 10);
			txtCommand.Name = "txtCommand";
			txtCommand.Size = new System.Drawing.Size(200, 20);
			txtCommand.TabIndex = 2;
			txtCommand.Text = "01 01";
			// 
			// btnSend
			// 
			btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			btnSend.Location = new System.Drawing.Point(325, 10);
			btnSend.Name = "btnSend";
			btnSend.Size = new System.Drawing.Size(60, 20);
			btnSend.TabIndex = 3;
			btnSend.Text = "&Send";
			btnSend.Click += new System.EventHandler(btnSend_Click);
			// 
			// TerminalForm
			// 
			AcceptButton = btnSend;
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(392, 366);
			ControlBox = false;
			Controls.Add(btnSend);
			Controls.Add(txtCommand);
			Controls.Add(lblPrompt);
			Controls.Add(richText);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TerminalForm";
			Text = "Terminal";
			ResumeLayout(false);
			PerformLayout();

		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			richText.SelectionStart = richText.Text.Length;
			richText.Focus();
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
				richText.SelectionColor = Color.Blue;
				richText.AppendText(txtCommand.Text);
				richText.AppendText("\r\n\r\n");
				string text = m_obdInterface.getRawResponse(txtCommand.Text);
				richText.SelectionColor = Color.DarkMagenta;
				richText.SelectionFont = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);
				richText.AppendText(text);
				richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
				richText.AppendText("\r\n\r\n");
				richText.SelectionFont = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular);
				richText.SelectionColor = Color.Black;
				if (string.Compare(m_strID, "") == 0)
					richText.AppendText("ELM > ");
				else
					richText.AppendText(m_strID + " > ");
			}
		}
	}
}
