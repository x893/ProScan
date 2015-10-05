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
		private Preferences m_preferences;
		private CheckBox checkBoxAutoDetect;

		public SettingsForm(Preferences prefs)
		{
			InitializeComponent();
			m_preferences = prefs;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.comboPorts = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupELM = new System.Windows.Forms.GroupBox();
			this.comboInitialize = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.comboProtocol = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBaud = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupComm = new System.Windows.Forms.GroupBox();
			this.groupHardware = new System.Windows.Forms.GroupBox();
			this.comboHardware = new System.Windows.Forms.ComboBox();
			this.checkBoxAutoDetect = new System.Windows.Forms.CheckBox();
			this.groupELM.SuspendLayout();
			this.groupComm.SuspendLayout();
			this.groupHardware.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboPorts
			// 
			this.comboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPorts.Location = new System.Drawing.Point(20, 23);
			this.comboPorts.Name = "comboPorts";
			this.comboPorts.Size = new System.Drawing.Size(124, 24);
			this.comboPorts.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOK.Location = new System.Drawing.Point(171, 287);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(90, 27);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&Save";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(267, 287);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 27);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			// 
			// groupELM
			// 
			this.groupELM.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.groupELM.Controls.Add(this.comboInitialize);
			this.groupELM.Controls.Add(this.label3);
			this.groupELM.Controls.Add(this.comboProtocol);
			this.groupELM.Controls.Add(this.label2);
			this.groupELM.Controls.Add(this.comboBaud);
			this.groupELM.Controls.Add(this.label1);
			this.groupELM.Location = new System.Drawing.Point(25, 144);
			this.groupELM.Name = "groupELM";
			this.groupELM.Size = new System.Drawing.Size(476, 132);
			this.groupELM.TabIndex = 3;
			this.groupELM.TabStop = false;
			this.groupELM.Text = "ELM327 &Configuration";
			// 
			// comboInitialize
			// 
			this.comboInitialize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboInitialize.Items.AddRange(new object[] {
            "Initialize",
            "Bypass Initialization"});
			this.comboInitialize.Location = new System.Drawing.Point(112, 92);
			this.comboInitialize.Name = "comboInitialize";
			this.comboInitialize.Size = new System.Drawing.Size(200, 24);
			this.comboInitialize.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "&Initialization:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboProtocol
			// 
			this.comboProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProtocol.Location = new System.Drawing.Point(112, 58);
			this.comboProtocol.Name = "comboProtocol";
			this.comboProtocol.Size = new System.Drawing.Size(348, 24);
			this.comboProtocol.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "P&rotocol:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBaud
			// 
			this.comboBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBaud.Items.AddRange(new object[] {
            "9600",
            "38400"});
			this.comboBaud.Location = new System.Drawing.Point(112, 27);
			this.comboBaud.Name = "comboBaud";
			this.comboBaud.Size = new System.Drawing.Size(129, 24);
			this.comboBaud.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Baud Rate:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupComm
			// 
			this.groupComm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.groupComm.Controls.Add(this.comboPorts);
			this.groupComm.Location = new System.Drawing.Point(25, 69);
			this.groupComm.Name = "groupComm";
			this.groupComm.Size = new System.Drawing.Size(163, 64);
			this.groupComm.TabIndex = 1;
			this.groupComm.TabStop = false;
			this.groupComm.Text = "Serial &Port";
			// 
			// groupHardware
			// 
			this.groupHardware.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.groupHardware.Controls.Add(this.comboHardware);
			this.groupHardware.Location = new System.Drawing.Point(206, 69);
			this.groupHardware.Name = "groupHardware";
			this.groupHardware.Size = new System.Drawing.Size(295, 64);
			this.groupHardware.TabIndex = 2;
			this.groupHardware.TabStop = false;
			this.groupHardware.Text = "&Hardware";
			// 
			// comboHardware
			// 
			this.comboHardware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboHardware.Items.AddRange(new object[] {
            "Automatic Detection",
            "ELM327 (Universal)",
            "ELM320 (PWM)",
            "ELM322 (VPW)",
            "ELM323 (ISO)",
            "CANtact"});
			this.comboHardware.Location = new System.Drawing.Point(20, 23);
			this.comboHardware.Name = "comboHardware";
			this.comboHardware.Size = new System.Drawing.Size(257, 24);
			this.comboHardware.TabIndex = 0;
			this.comboHardware.SelectedIndexChanged += new System.EventHandler(this.comboHardware_SelectedIndexChanged);
			// 
			// checkBoxAutoDetect
			// 
			this.checkBoxAutoDetect.Location = new System.Drawing.Point(25, 36);
			this.checkBoxAutoDetect.Name = "checkBoxAutoDetect";
			this.checkBoxAutoDetect.Size = new System.Drawing.Size(476, 27);
			this.checkBoxAutoDetect.TabIndex = 6;
			this.checkBoxAutoDetect.Text = "Automatic Detection";
			this.checkBoxAutoDetect.CheckedChanged += new System.EventHandler(this.checkBoxAutoDetect_CheckedChanged);
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(528, 323);
			this.Controls.Add(this.checkBoxAutoDetect);
			this.Controls.Add(this.groupHardware);
			this.Controls.Add(this.groupELM);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupComm);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Communication Settings";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.groupELM.ResumeLayout(false);
			this.groupComm.ResumeLayout(false);
			this.groupHardware.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			try
			{
				for (int iComPort = 0; iComPort < 50; ++iComPort)
					if (CommBase.isPortAvailable(iComPort))
						comboPorts.Items.Add("COM" + iComPort.ToString());

				if (CommBase.isPortAvailable(m_preferences.ComPort))
					comboPorts.SelectedItem = m_preferences.ComPortName;
				else if (comboPorts.Items.Count > 0)
					comboPorts.SelectedIndex = 0;

				comboHardware.SelectedIndex = m_preferences.HardwareIndexInt;
				comboBaud.SelectedIndex = m_preferences.BaudRateIndex;

				foreach(string item in Preferences.ProtocolNames)
					comboProtocol.Items.Add(item);

				comboProtocol.SelectedIndex = m_preferences.ProtocolIndexInt;
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

			m_preferences.BaudRateIndex = comboBaud.SelectedIndex;
			m_preferences.HardwareIndexInt = comboHardware.SelectedIndex;
			m_preferences.ProtocolIndexInt = comboProtocol.SelectedIndex;
			m_preferences.DoInitialization = (comboInitialize.SelectedIndex == 0);
			Close();
		}

		private void comboHardware_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboHardware.SelectedIndex == (int)HardwareType.ELM327)
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