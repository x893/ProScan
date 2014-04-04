using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class SettingsForm : Form
	{
		private Button btnOK;
		private Button btnCancel;
		private ComboBox comboPorts;
		private GroupBox groupELM;
		private GroupBox groupComm;
		private Label label1;
		private Label label2;
		private ComboBox comboHardware;
		private ComboBox comboBaud;
		private ComboBox comboProtocol;
		private ComboBox comboInitialize;
		private Label label3;
		private GroupBox groupHardware;
		private OBD2Interface m_obd2Interface;
		private Preferences m_preferences;
		private CheckBox checkBoxAutoDetect;
		private Container components;

		public SettingsForm(Preferences prefs)
		{
			InitializeComponent();
			m_preferences = prefs;
			m_obd2Interface = new OBD2Interface();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			comboPorts = new System.Windows.Forms.ComboBox();
			btnOK = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupELM = new System.Windows.Forms.GroupBox();
			comboInitialize = new System.Windows.Forms.ComboBox();
			label3 = new System.Windows.Forms.Label();
			comboProtocol = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			comboBaud = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			groupComm = new System.Windows.Forms.GroupBox();
			groupHardware = new System.Windows.Forms.GroupBox();
			comboHardware = new System.Windows.Forms.ComboBox();
			checkBoxAutoDetect = new System.Windows.Forms.CheckBox();
			groupELM.SuspendLayout();
			groupComm.SuspendLayout();
			groupHardware.SuspendLayout();
			SuspendLayout();
			// 
			// comboPorts
			// 
			comboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboPorts.Location = new System.Drawing.Point(17, 20);
			comboPorts.Name = "comboPorts";
			comboPorts.Size = new System.Drawing.Size(103, 21);
			comboPorts.TabIndex = 0;
			// 
			// btnOK
			// 
			btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnOK.Location = new System.Drawing.Point(132, 229);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 4;
			btnOK.Text = "&Save";
			btnOK.Click += new System.EventHandler(btnOK_Click);
			// 
			// btnCancel
			// 
			btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(212, 229);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 5;
			btnCancel.Text = "&Cancel";
			// 
			// groupELM
			// 
			groupELM.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			groupELM.Controls.Add(comboInitialize);
			groupELM.Controls.Add(label3);
			groupELM.Controls.Add(comboProtocol);
			groupELM.Controls.Add(label2);
			groupELM.Controls.Add(comboBaud);
			groupELM.Controls.Add(label1);
			groupELM.Location = new System.Drawing.Point(10, 105);
			groupELM.Name = "groupELM";
			groupELM.Size = new System.Drawing.Size(397, 114);
			groupELM.TabIndex = 3;
			groupELM.TabStop = false;
			groupELM.Text = "ELM327 &Configuration";
			// 
			// comboInitialize
			// 
			comboInitialize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboInitialize.Items.AddRange(new object[] {
            "Initialize",
            "Bypass Initialization"});
			comboInitialize.Location = new System.Drawing.Point(93, 80);
			comboInitialize.Name = "comboInitialize";
			comboInitialize.Size = new System.Drawing.Size(167, 21);
			comboInitialize.TabIndex = 5;
			// 
			// label3
			// 
			label3.Location = new System.Drawing.Point(6, 80);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(80, 20);
			label3.TabIndex = 4;
			label3.Text = "&Initialization:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboProtocol
			// 
			comboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboProtocol.Items.AddRange(new object[] {
            "Automatic",
            "SAE J1850 PWM (41.6 Kbaud)",
            "SAE J1850 VPW (10.4 Kbaud)",
            "ISO 9141-2 (5 baud init, 10.4 Kbaud)",
            "ISO 14230-4 KWP (5 baud init, 10.4 Kbaud)",
            "ISO 14230-4 KWP (fast init, 10.4 Kbaud)",
            "ISO 15765-4 CAN (11 bit ID, 500 Kbaud)",
            "ISO 15765-4 CAN (29 bit ID, 500 Kbaud)",
            "ISO 15765-4 CAN (11 bit ID, 250 Kbaud)",
            "ISO 15765-4 CAN (29 bit ID, 250 Kbaud)"});
			comboProtocol.Location = new System.Drawing.Point(93, 50);
			comboProtocol.Name = "comboProtocol";
			comboProtocol.Size = new System.Drawing.Size(290, 21);
			comboProtocol.TabIndex = 3;
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(6, 50);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(80, 20);
			label2.TabIndex = 2;
			label2.Text = "P&rotocol:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBaud
			// 
			comboBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBaud.Items.AddRange(new object[] {
            "9600",
            "38400"});
			comboBaud.Location = new System.Drawing.Point(93, 23);
			comboBaud.Name = "comboBaud";
			comboBaud.Size = new System.Drawing.Size(108, 21);
			comboBaud.TabIndex = 1;
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(6, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 20);
			label1.TabIndex = 0;
			label1.Text = "&Baud Rate:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupComm
			// 
			groupComm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			groupComm.Controls.Add(comboPorts);
			groupComm.Location = new System.Drawing.Point(10, 40);
			groupComm.Name = "groupComm";
			groupComm.Size = new System.Drawing.Size(136, 55);
			groupComm.TabIndex = 1;
			groupComm.TabStop = false;
			groupComm.Text = "Serial &Port";
			// 
			// groupHardware
			// 
			groupHardware.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			groupHardware.Controls.Add(comboHardware);
			groupHardware.Location = new System.Drawing.Point(161, 40);
			groupHardware.Name = "groupHardware";
			groupHardware.Size = new System.Drawing.Size(246, 55);
			groupHardware.TabIndex = 2;
			groupHardware.TabStop = false;
			groupHardware.Text = "&Hardware";
			// 
			// comboHardware
			// 
			comboHardware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboHardware.Items.AddRange(new object[] {
            "Automatic Detection",
            "ELM327 (Universal)",
            "ELM320 (PWM)",
            "ELM322 (VPW)",
            "ELM323 (ISO)"});
			comboHardware.Location = new System.Drawing.Point(17, 20);
			comboHardware.Name = "comboHardware";
			comboHardware.Size = new System.Drawing.Size(214, 21);
			comboHardware.TabIndex = 0;
			comboHardware.SelectedIndexChanged += new System.EventHandler(comboHardware_SelectedIndexChanged);
			// 
			// checkBoxAutoDetect
			// 
			checkBoxAutoDetect.Location = new System.Drawing.Point(10, 10);
			checkBoxAutoDetect.Name = "checkBoxAutoDetect";
			checkBoxAutoDetect.Size = new System.Drawing.Size(394, 24);
			checkBoxAutoDetect.TabIndex = 6;
			checkBoxAutoDetect.Text = "Automatic Detection";
			checkBoxAutoDetect.CheckedChanged += new System.EventHandler(checkBoxAutoDetect_CheckedChanged);
			// 
			// SettingsForm
			// 
			AcceptButton = btnOK;
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(418, 260);
			Controls.Add(checkBoxAutoDetect);
			Controls.Add(groupHardware);
			Controls.Add(groupELM);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(groupComm);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SettingsForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Communication Settings";
			Load += new System.EventHandler(SettingsForm_Load);
			groupELM.ResumeLayout(false);
			groupComm.ResumeLayout(false);
			groupHardware.ResumeLayout(false);
			ResumeLayout(false);

		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			try
			{
				for (int iComPort = 0; iComPort < 50; ++iComPort)
				{
					if (m_obd2Interface.isPortAvailable(iComPort))
						comboPorts.Items.Add("COM" + iComPort.ToString());
				}
				if (m_obd2Interface.isPortAvailable(m_preferences.ComPort))
				{
					int num = m_preferences.ComPort;
					comboPorts.SelectedItem = "COM" + m_preferences.ComPort.ToString();
				}
				else if (comboPorts.Items.Count > 0)
					comboPorts.SelectedIndex = 0;
				comboHardware.SelectedIndex = m_preferences.HardwareIndex;
				comboBaud.SelectedIndex = m_preferences.BaudRateIndex;
				comboProtocol.SelectedIndex = m_preferences.ProtocolIndex;
				comboInitialize.SelectedIndex = !m_preferences.DoInitialization ? 1 : 0;
				if (m_preferences.AutoDetect)
					checkBoxAutoDetect.Checked = true;
				else
					checkBoxAutoDetect.Checked = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			m_preferences.AutoDetect = checkBoxAutoDetect.Checked;
			if (comboPorts.SelectedItem != null && comboPorts.SelectedItem.ToString().Length > 3)
				m_preferences.ComPort = Convert.ToInt32(comboPorts.SelectedItem.ToString().Remove(0, 3));
			m_preferences.HardwareIndex = comboHardware.SelectedIndex;
			m_preferences.BaudRateIndex = comboBaud.SelectedIndex;
			m_preferences.ProtocolIndex = comboProtocol.SelectedIndex;
			m_preferences.DoInitialization = comboInitialize.SelectedIndex == 0;
			Close();
		}

		private void comboHardware_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboHardware.SelectedIndex == 1)
				groupELM.Enabled = true;
			else
				groupELM.Enabled = false;
		}

		private void checkBoxAutoDetect_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxAutoDetect.Checked)
			{
				groupComm.Enabled = false;
				groupHardware.Enabled = false;
				groupELM.Enabled = false;
			}
			else
			{
				groupComm.Enabled = true;
				groupHardware.Enabled = true;
				groupELM.Enabled = true;
			}
		}
	}
}