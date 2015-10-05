using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ProScan
{
	public class CommForm : Form
	{
		private List<VehicleProfile> m_profiles;
		private OBDInterface m_OBDInterface;
		private System.Windows.Forms.Timer m_timer;

		public CommForm(OBDInterface obd)
		{
			InitializeComponent();

			m_OBDInterface = obd;
			m_profiles = m_OBDInterface.VehicleProfiles;
			PopulateProfileCombobox();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			comboProfile.Enabled = false;
			btnManageProfiles.Enabled = false;
			btnConnect.Enabled = false;
			btnDisconnect.Enabled = true;
			picCheck1.Image = picBlankBox.Image;
			picCheck2.Image = picBlankBox.Image;
			picCheck3.Image = picBlankBox.Image;
			picCheck4.Image = picBlankBox.Image;

			m_OBDInterface.SaveActiveProfile((VehicleProfile)comboProfile.SelectedItem);

			m_OBDInterface.logItem("ProScan");
			m_OBDInterface.logItem("Connection Procedure Initiated");

			if (m_OBDInterface.CommSettings.AutoDetect)
				m_OBDInterface.logItem("   Automatic Hardware Detection: ON");
			else
				m_OBDInterface.logItem("   Automatic Hardware Detection: OFF");

			m_OBDInterface.logItem(string.Format("   Baud Rate: {0}", m_OBDInterface.CommSettings.BaudRate));
			m_OBDInterface.logItem(string.Format("   Default Port: {0}", m_OBDInterface.CommSettings.ComPortName));

			switch (m_OBDInterface.CommSettings.HardwareIndex)
			{
				case HardwareType.Automatic:
					m_OBDInterface.logItem("   Interface: Auto-Detect");
					break;

				case HardwareType.ELM327:
					m_OBDInterface.logItem("   Interface: ELM327");
					break;

				case HardwareType.ELM320:
					m_OBDInterface.logItem("   Interface: ELM320");
					break;

				case HardwareType.ELM322:
					m_OBDInterface.logItem("   Interface: ELM322");
					break;

				case HardwareType.ELM323:
					m_OBDInterface.logItem("   Interface: ELM323");
					break;
				case HardwareType.CANtact:
					m_OBDInterface.logItem("   Interface: CANtact");
					break;
				default:
					throw new Exception("Bad hardware type.");
			}


			m_OBDInterface.logItem(string.Format("   Protocol: {0}", m_OBDInterface.CommSettings.ProtocolName));

			if (m_OBDInterface.CommSettings.DoInitialization)
				m_OBDInterface.logItem("   Initialize: YES");
			else
				m_OBDInterface.logItem("   Initialize: NO");

			ThreadPool.QueueUserWorkItem(new WaitCallback(ConnectThreadNew));
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			ShowDisconnectedLabel();
			picCheck1.Image = picBlankBox.Image;
			picCheck2.Image = picBlankBox.Image;
			picCheck3.Image = picBlankBox.Image;
			picCheck4.Image = picBlankBox.Image;
			m_OBDInterface.Disconnect();
		}

		private void btnManageProfiles_Click(object sender, EventArgs e)
		{
			new VehicleForm(m_OBDInterface).ShowDialog();
			PopulateProfileCombobox();
		}

		private void comboProfile_SelectedValueChanged(object sender, EventArgs e)
		{
		}

		private void ConnectThreadNew(object state)
		{
			ShowConnectingLabel();
			if (m_OBDInterface.CommSettings.AutoDetect)
			{
				if (m_OBDInterface.initDeviceAuto())
				{
					m_OBDInterface.logItem("Connection Established!");
					ShowConnectedLabel();
					OBDParameter param = new OBDParameter();
					param.OBDRequest = "0902";
					param.Service = 9;
					param.Parameter = 2;
					param.ValueTypes = 4;
					m_OBDInterface.getValue(param, true);
				}
				else
				{
					MessageBox.Show("ProScan failed to find a compatible OBD-II interface attached to this computer.\r\n\r\nPlease verify that no other application is currently using the required port.", "Auto Detection Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					m_OBDInterface.logItem("Failed to find a compatible OBD-II interface.");
					ShowDisconnectedLabel();
				}
			}
			else
			{
				int baudRate = m_OBDInterface.CommSettings.BaudRate;
				int comPort = m_OBDInterface.CommSettings.ComPort;
				if (m_OBDInterface.initDevice(
						m_OBDInterface.CommSettings.HardwareIndex,
						comPort,
						baudRate,
						m_OBDInterface.CommSettings.ProtocolIndex
						))
				{
					m_OBDInterface.logItem("Connection Established!");
					ShowConnectedLabel();
				}
				else
				{
					MessageBox.Show(
						string.Format(@"ProScan failed to find a compatible OBD-II interface attached to {0} at baud rate {1} bps.

Please verify that no other application is currently using the required port and that the baud rate is correct.",
							m_OBDInterface.CommSettings.ComPortName,
							m_OBDInterface.CommSettings.BaudRate
							),
						"Connection Failure",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation
						);
					m_OBDInterface.logItem("Failed to find a compatible OBD-II interface.");
					ShowDisconnectedLabel();
				}
			}
		}

		private void Disconnect()
		{
			m_OBDInterface.Disconnect();
			ShowDisconnectedLabel();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
				components.Dispose();
			base.Dispose(disposing);
		}

		private void PopulateProfileCombobox()
		{
			comboProfile.Items.Clear();
			foreach(VehicleProfile vehicle in m_profiles)
				comboProfile.Items.Add(vehicle);
			
			if (comboProfile.Items.Count > 0)
			{
				if (m_OBDInterface.CommSettings.ActiveProfileIndex < comboProfile.Items.Count)
					comboProfile.SelectedIndex = m_OBDInterface.CommSettings.ActiveProfileIndex;
				else
					comboProfile.SelectedIndex = 0;
			}
		}

		private void ShowConnectedLabel()
		{
			lblStatus.ForeColor = Color.Green;
			lblStatus.Text = "Connected";
		}

		private void ShowConnectingLabel()
		{
			if (InvokeRequired)
				BeginInvoke((MethodInvoker) delegate { ShowConnectingLabel(); });
			else
			{
				lblStatus.ForeColor = Color.Black;
				lblStatus.Text = "Connecting...";
			}
		}

		private void ShowDisconnectedLabel()
		{
			if (InvokeRequired)
				BeginInvoke((MethodInvoker)delegate { ShowDisconnectedLabel(); });
			else
			{
				lblStatus.ForeColor = Color.Red;
				lblStatus.Text = "Disconnected";
				btnConnect.Enabled = true;
				comboProfile.Enabled = true;
				btnManageProfiles.Enabled = true;
				btnDisconnect.Enabled = false;
			}
		}

		private void ShowOBD2InitFailedError()
		{
			MessageBox.Show("The interface hardware was detected and initialized, but communication with the vehicle could not be established. Make sure that the vehicle's ignition key is turned to the ON position or that the engine is running.\r\n\r\nIf using ELM320 (PWM), ELM322 (VPW), or ELM323 (ISO):\r\n\tVerify that the vehicle's protocol matches the interface.\r\n\r\nIf using ELM327 (VPW, PWM, ISO, and CAN):\r\n\tVerify the interface configuration under Communication Settings.\r\n\tTry manually setting the protocol.\r\n\tTry bypassing initialization.", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public void UpdateForm()
		{
			PopulateProfileCombobox();
		}

		#region InitializeComponent()

		private Button btnConnect;
		private Button btnDisconnect;
		private Button btnManageProfiles;
		private ComboBox comboProfile;
		private IContainer components;
		private Label lblActiveProfile;
		private Label lblBuildList;
		private Label lblBullet1;
		private Label lblBullet2;
		private Label lblBullet3;
		private Label lblBullet4;
		private Label lblBullet5;
		private Label lblCheckComPort;
		private Label lblDetectInterface;
		private Label lblInitInterface;
		private Label lblInstruction1;
		private Label lblInstruction2;
		private Label lblInstruction3;
		private Label lblInstruction4;
		private Label lblInstruction5;
		private Label lblStatus;
		private Panel panelStatus;
		private Panel panelVersion;
		private PictureBox picBlankBox;
		private PictureBox picCheck1;
		private PictureBox picCheck2;
		private PictureBox picCheck3;
		private PictureBox picCheck4;
		private PictureBox picCheckMark;
		private PictureBox picDiagram;
		private PictureBox picX;

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommForm));
			this.panelStatus = new System.Windows.Forms.Panel();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblBuildList = new System.Windows.Forms.Label();
			this.picCheck4 = new System.Windows.Forms.PictureBox();
			this.lblInitInterface = new System.Windows.Forms.Label();
			this.picCheck3 = new System.Windows.Forms.PictureBox();
			this.lblDetectInterface = new System.Windows.Forms.Label();
			this.picCheck2 = new System.Windows.Forms.PictureBox();
			this.lblCheckComPort = new System.Windows.Forms.Label();
			this.picCheck1 = new System.Windows.Forms.PictureBox();
			this.lblInstruction4 = new System.Windows.Forms.Label();
			this.picDiagram = new System.Windows.Forms.PictureBox();
			this.lblInstruction5 = new System.Windows.Forms.Label();
			this.lblInstruction3 = new System.Windows.Forms.Label();
			this.lblInstruction2 = new System.Windows.Forms.Label();
			this.lblInstruction1 = new System.Windows.Forms.Label();
			this.lblBullet5 = new System.Windows.Forms.Label();
			this.lblBullet4 = new System.Windows.Forms.Label();
			this.lblBullet3 = new System.Windows.Forms.Label();
			this.lblBullet2 = new System.Windows.Forms.Label();
			this.lblBullet1 = new System.Windows.Forms.Label();
			this.btnManageProfiles = new System.Windows.Forms.Button();
			this.comboProfile = new System.Windows.Forms.ComboBox();
			this.lblActiveProfile = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.panelVersion = new System.Windows.Forms.Panel();
			this.picBlankBox = new System.Windows.Forms.PictureBox();
			this.picX = new System.Windows.Forms.PictureBox();
			this.picCheckMark = new System.Windows.Forms.PictureBox();
			this.m_timer = new System.Windows.Forms.Timer(this.components);
			this.panelStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCheck4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheck3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheck2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheck1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picDiagram)).BeginInit();
			this.panelVersion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBlankBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheckMark)).BeginInit();
			this.SuspendLayout();
			// 
			// panelStatus
			// 
			this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelStatus.AutoScroll = true;
			this.panelStatus.BackColor = System.Drawing.Color.White;
			this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelStatus.Controls.Add(this.lblStatus);
			this.panelStatus.Controls.Add(this.lblBuildList);
			this.panelStatus.Controls.Add(this.picCheck4);
			this.panelStatus.Controls.Add(this.lblInitInterface);
			this.panelStatus.Controls.Add(this.picCheck3);
			this.panelStatus.Controls.Add(this.lblDetectInterface);
			this.panelStatus.Controls.Add(this.picCheck2);
			this.panelStatus.Controls.Add(this.lblCheckComPort);
			this.panelStatus.Controls.Add(this.picCheck1);
			this.panelStatus.Controls.Add(this.lblInstruction4);
			this.panelStatus.Controls.Add(this.picDiagram);
			this.panelStatus.Controls.Add(this.lblInstruction5);
			this.panelStatus.Controls.Add(this.lblInstruction3);
			this.panelStatus.Controls.Add(this.lblInstruction2);
			this.panelStatus.Controls.Add(this.lblInstruction1);
			this.panelStatus.Controls.Add(this.lblBullet5);
			this.panelStatus.Controls.Add(this.lblBullet4);
			this.panelStatus.Controls.Add(this.lblBullet3);
			this.panelStatus.Controls.Add(this.lblBullet2);
			this.panelStatus.Controls.Add(this.lblBullet1);
			this.panelStatus.Location = new System.Drawing.Point(10, 138);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(777, 466);
			this.panelStatus.TabIndex = 4;
			// 
			// lblStatus
			// 
			this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.ForeColor = System.Drawing.Color.Red;
			this.lblStatus.Location = new System.Drawing.Point(422, 89);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(291, 48);
			this.lblStatus.TabIndex = 19;
			this.lblStatus.Text = "Disconnected";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblBuildList
			// 
			this.lblBuildList.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBuildList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBuildList.ForeColor = System.Drawing.Color.Blue;
			this.lblBuildList.Location = new System.Drawing.Point(491, 219);
			this.lblBuildList.Name = "lblBuildList";
			this.lblBuildList.Size = new System.Drawing.Size(228, 46);
			this.lblBuildList.TabIndex = 18;
			this.lblBuildList.Text = "Initialize OBD-II";
			this.lblBuildList.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lblBuildList.Visible = false;
			// 
			// picCheck4
			// 
			this.picCheck4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picCheck4.Image = ((System.Drawing.Image)(resources.GetObject("picCheck4.Image")));
			this.picCheck4.Location = new System.Drawing.Point(431, 219);
			this.picCheck4.Name = "picCheck4";
			this.picCheck4.Size = new System.Drawing.Size(56, 46);
			this.picCheck4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCheck4.TabIndex = 17;
			this.picCheck4.TabStop = false;
			this.picCheck4.Visible = false;
			// 
			// lblInitInterface
			// 
			this.lblInitInterface.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblInitInterface.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInitInterface.ForeColor = System.Drawing.Color.Blue;
			this.lblInitInterface.Location = new System.Drawing.Point(491, 173);
			this.lblInitInterface.Name = "lblInitInterface";
			this.lblInitInterface.Size = new System.Drawing.Size(228, 46);
			this.lblInitInterface.TabIndex = 16;
			this.lblInitInterface.Text = "Initialize Interface";
			this.lblInitInterface.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lblInitInterface.Visible = false;
			// 
			// picCheck3
			// 
			this.picCheck3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picCheck3.Image = ((System.Drawing.Image)(resources.GetObject("picCheck3.Image")));
			this.picCheck3.Location = new System.Drawing.Point(431, 173);
			this.picCheck3.Name = "picCheck3";
			this.picCheck3.Size = new System.Drawing.Size(56, 46);
			this.picCheck3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCheck3.TabIndex = 15;
			this.picCheck3.TabStop = false;
			this.picCheck3.Visible = false;
			// 
			// lblDetectInterface
			// 
			this.lblDetectInterface.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblDetectInterface.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDetectInterface.ForeColor = System.Drawing.Color.Blue;
			this.lblDetectInterface.Location = new System.Drawing.Point(491, 127);
			this.lblDetectInterface.Name = "lblDetectInterface";
			this.lblDetectInterface.Size = new System.Drawing.Size(228, 46);
			this.lblDetectInterface.TabIndex = 14;
			this.lblDetectInterface.Text = "Detect Interface";
			this.lblDetectInterface.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lblDetectInterface.Visible = false;
			// 
			// picCheck2
			// 
			this.picCheck2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picCheck2.Image = ((System.Drawing.Image)(resources.GetObject("picCheck2.Image")));
			this.picCheck2.Location = new System.Drawing.Point(431, 127);
			this.picCheck2.Name = "picCheck2";
			this.picCheck2.Size = new System.Drawing.Size(56, 46);
			this.picCheck2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCheck2.TabIndex = 13;
			this.picCheck2.TabStop = false;
			this.picCheck2.Visible = false;
			// 
			// lblCheckComPort
			// 
			this.lblCheckComPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblCheckComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCheckComPort.ForeColor = System.Drawing.Color.Blue;
			this.lblCheckComPort.Location = new System.Drawing.Point(491, 81);
			this.lblCheckComPort.Name = "lblCheckComPort";
			this.lblCheckComPort.Size = new System.Drawing.Size(228, 46);
			this.lblCheckComPort.TabIndex = 12;
			this.lblCheckComPort.Text = "Open Serial Port";
			this.lblCheckComPort.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lblCheckComPort.Visible = false;
			// 
			// picCheck1
			// 
			this.picCheck1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picCheck1.Image = ((System.Drawing.Image)(resources.GetObject("picCheck1.Image")));
			this.picCheck1.Location = new System.Drawing.Point(431, 81);
			this.picCheck1.Name = "picCheck1";
			this.picCheck1.Size = new System.Drawing.Size(56, 46);
			this.picCheck1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCheck1.TabIndex = 11;
			this.picCheck1.TabStop = false;
			this.picCheck1.Visible = false;
			// 
			// lblInstruction4
			// 
			this.lblInstruction4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblInstruction4.Location = new System.Drawing.Point(77, 248);
			this.lblInstruction4.Name = "lblInstruction4";
			this.lblInstruction4.Size = new System.Drawing.Size(318, 35);
			this.lblInstruction4.TabIndex = 10;
			this.lblInstruction4.Text = "Turn the vehicle\'s ignition key to the ON position or start the engine.";
			// 
			// picDiagram
			// 
			this.picDiagram.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picDiagram.Image = ((System.Drawing.Image)(resources.GetObject("picDiagram.Image")));
			this.picDiagram.Location = new System.Drawing.Point(113, 3);
			this.picDiagram.Name = "picDiagram";
			this.picDiagram.Size = new System.Drawing.Size(528, 77);
			this.picDiagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picDiagram.TabIndex = 9;
			this.picDiagram.TabStop = false;
			// 
			// lblInstruction5
			// 
			this.lblInstruction5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblInstruction5.Location = new System.Drawing.Point(77, 294);
			this.lblInstruction5.Name = "lblInstruction5";
			this.lblInstruction5.Size = new System.Drawing.Size(318, 23);
			this.lblInstruction5.TabIndex = 8;
			this.lblInstruction5.Text = "Click the \"Connect\" button.";
			// 
			// lblInstruction3
			// 
			this.lblInstruction3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblInstruction3.Location = new System.Drawing.Point(77, 202);
			this.lblInstruction3.Name = "lblInstruction3";
			this.lblInstruction3.Size = new System.Drawing.Size(318, 35);
			this.lblInstruction3.TabIndex = 7;
			this.lblInstruction3.Text = "Connect the interface hardware between this computer and the vehicle\'s OBD-II con" +
    "nector.";
			// 
			// lblInstruction2
			// 
			this.lblInstruction2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblInstruction2.Location = new System.Drawing.Point(77, 133);
			this.lblInstruction2.Name = "lblInstruction2";
			this.lblInstruction2.Size = new System.Drawing.Size(318, 57);
			this.lblInstruction2.TabIndex = 6;
			this.lblInstruction2.Text = "Verify that the Active Vehicle Profile selected above applies to this vehicle. If" +
    " this is the first time you have used ProScan on this vehicle, click \"Manage Pro" +
    "files\" to create a new profile.";
			// 
			// lblInstruction1
			// 
			this.lblInstruction1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblInstruction1.Location = new System.Drawing.Point(77, 87);
			this.lblInstruction1.Name = "lblInstruction1";
			this.lblInstruction1.Size = new System.Drawing.Size(318, 34);
			this.lblInstruction1.TabIndex = 5;
			this.lblInstruction1.Text = "Verify that you have the correct hardware and communication settings defined unde" +
    "r preferences.";
			// 
			// lblBullet5
			// 
			this.lblBullet5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBullet5.Image = ((System.Drawing.Image)(resources.GetObject("lblBullet5.Image")));
			this.lblBullet5.Location = new System.Drawing.Point(41, 294);
			this.lblBullet5.Name = "lblBullet5";
			this.lblBullet5.Size = new System.Drawing.Size(22, 21);
			this.lblBullet5.TabIndex = 4;
			// 
			// lblBullet4
			// 
			this.lblBullet4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBullet4.Image = ((System.Drawing.Image)(resources.GetObject("lblBullet4.Image")));
			this.lblBullet4.Location = new System.Drawing.Point(41, 248);
			this.lblBullet4.Name = "lblBullet4";
			this.lblBullet4.Size = new System.Drawing.Size(22, 21);
			this.lblBullet4.TabIndex = 3;
			// 
			// lblBullet3
			// 
			this.lblBullet3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBullet3.Image = ((System.Drawing.Image)(resources.GetObject("lblBullet3.Image")));
			this.lblBullet3.Location = new System.Drawing.Point(41, 202);
			this.lblBullet3.Name = "lblBullet3";
			this.lblBullet3.Size = new System.Drawing.Size(22, 21);
			this.lblBullet3.TabIndex = 2;
			// 
			// lblBullet2
			// 
			this.lblBullet2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBullet2.Image = ((System.Drawing.Image)(resources.GetObject("lblBullet2.Image")));
			this.lblBullet2.Location = new System.Drawing.Point(41, 133);
			this.lblBullet2.Name = "lblBullet2";
			this.lblBullet2.Size = new System.Drawing.Size(22, 20);
			this.lblBullet2.TabIndex = 1;
			// 
			// lblBullet1
			// 
			this.lblBullet1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblBullet1.Image = ((System.Drawing.Image)(resources.GetObject("lblBullet1.Image")));
			this.lblBullet1.Location = new System.Drawing.Point(41, 87);
			this.lblBullet1.Name = "lblBullet1";
			this.lblBullet1.Size = new System.Drawing.Size(22, 20);
			this.lblBullet1.TabIndex = 0;
			// 
			// btnManageProfiles
			// 
			this.btnManageProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnManageProfiles.Location = new System.Drawing.Point(563, 105);
			this.btnManageProfiles.Name = "btnManageProfiles";
			this.btnManageProfiles.Size = new System.Drawing.Size(122, 27);
			this.btnManageProfiles.TabIndex = 6;
			this.btnManageProfiles.Text = "&Manage Profiles";
			this.btnManageProfiles.Click += new System.EventHandler(this.btnManageProfiles_Click);
			// 
			// comboProfile
			// 
			this.comboProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.comboProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboProfile.Location = new System.Drawing.Point(288, 106);
			this.comboProfile.Name = "comboProfile";
			this.comboProfile.Size = new System.Drawing.Size(259, 24);
			this.comboProfile.TabIndex = 5;
			this.comboProfile.SelectedValueChanged += new System.EventHandler(this.comboProfile_SelectedValueChanged);
			// 
			// lblActiveProfile
			// 
			this.lblActiveProfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblActiveProfile.Location = new System.Drawing.Point(133, 105);
			this.lblActiveProfile.Name = "lblActiveProfile";
			this.lblActiveProfile.Size = new System.Drawing.Size(139, 27);
			this.lblActiveProfile.TabIndex = 7;
			this.lblActiveProfile.Text = "Active Vehicle &Profile:";
			this.lblActiveProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnConnect.Location = new System.Drawing.Point(311, 611);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(90, 27);
			this.btnConnect.TabIndex = 8;
			this.btnConnect.Text = "&Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnDisconnect.Enabled = false;
			this.btnDisconnect.Location = new System.Drawing.Point(417, 611);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(90, 27);
			this.btnDisconnect.TabIndex = 9;
			this.btnDisconnect.Text = "&Disconnect";
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// panelVersion
			// 
			this.panelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelVersion.BackColor = System.Drawing.Color.White;
			this.panelVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelVersion.Controls.Add(this.picBlankBox);
			this.panelVersion.Controls.Add(this.picX);
			this.panelVersion.Controls.Add(this.picCheckMark);
			this.panelVersion.Location = new System.Drawing.Point(10, 9);
			this.panelVersion.Name = "panelVersion";
			this.panelVersion.Size = new System.Drawing.Size(777, 87);
			this.panelVersion.TabIndex = 10;
			// 
			// picBlankBox
			// 
			this.picBlankBox.Image = ((System.Drawing.Image)(resources.GetObject("picBlankBox.Image")));
			this.picBlankBox.Location = new System.Drawing.Point(344, 25);
			this.picBlankBox.Name = "picBlankBox";
			this.picBlankBox.Size = new System.Drawing.Size(56, 47);
			this.picBlankBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBlankBox.TabIndex = 17;
			this.picBlankBox.TabStop = false;
			this.picBlankBox.Visible = false;
			// 
			// picX
			// 
			this.picX.Image = ((System.Drawing.Image)(resources.GetObject("picX.Image")));
			this.picX.Location = new System.Drawing.Point(272, 23);
			this.picX.Name = "picX";
			this.picX.Size = new System.Drawing.Size(56, 46);
			this.picX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picX.TabIndex = 16;
			this.picX.TabStop = false;
			this.picX.Visible = false;
			// 
			// picCheckMark
			// 
			this.picCheckMark.Image = ((System.Drawing.Image)(resources.GetObject("picCheckMark.Image")));
			this.picCheckMark.Location = new System.Drawing.Point(205, 21);
			this.picCheckMark.Name = "picCheckMark";
			this.picCheckMark.Size = new System.Drawing.Size(55, 46);
			this.picCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picCheckMark.TabIndex = 15;
			this.picCheckMark.TabStop = false;
			this.picCheckMark.Visible = false;
			// 
			// CommForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(796, 645);
			this.ControlBox = false;
			this.Controls.Add(this.panelVersion);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.lblActiveProfile);
			this.Controls.Add(this.btnManageProfiles);
			this.Controls.Add(this.comboProfile);
			this.Controls.Add(this.panelStatus);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CommForm";
			this.Text = "Vehicle Connection Manager";
			this.panelStatus.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picCheck4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheck3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheck2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheck1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picDiagram)).EndInit();
			this.panelVersion.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picBlankBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCheckMark)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}