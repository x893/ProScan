using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class VehicleForm : Form
	{
		private GroupBox groupVehicles;
		private ListBox listVehicles;
		private GroupBox groupProfile;
		private Button btnNewVehicle;
		private Label lblName;
		private TextBox txtName;
		private RadioButton radioAutomatic;
		private RadioButton radioManual;
		private GroupBox groupWheels;
		private TextBox txtTireWidth;
		private Label lblTireWidth;
		private TextBox txtAspectRatio;
		private Label lblTireAspectRatio;
		private Label lblRimDiameter;
		private TextBox txtRimDiameter;
		private Label lblExample;
		private Label lblExampleWidth;
		private Label lblExampleDash;
		private Label lblExampleSlash;
		private Label lblExampleAspect;
		private Label lblExampleDiameter;
		private Label lblExampleEnd;
		private GroupBox groupDrivetrain;
		private GroupBox groupMisc;
		private Label lblWeight;
		private TextBox txtWeight;
		private Label lblPounds;
		private Label label1;
		private Label lblTireWidthUnits;
		private Label lblTireAspectUnits;
		private Label lblRimDiameterUnits;
		private GroupBox groupNotes;
		private TextBox txtNotes;
		private Button btnSave;
		private Button btnExit;
		private Button btnDiscard;
		private Button btnDeleteVehicle;
		private TextBox txtDragCoeff;
		private GroupBox groupTimeout;
		private Label lblTimeoutUnits;
		private NumericUpDown numTimeout;
		private Label lblTimeout;
		private GroupBox groupBox1;
		private TextBox txtSpeedoFactor;
		private Button btnCalcSpeedo;
		private ArrayList m_arrayVehicleList;
		private bool bDirtyProfile;
		private OBDInterface m_obdInterface;
		private Container components;

		public VehicleForm(OBDInterface obd2)
		{
			InitializeComponent();
			m_obdInterface = obd2;
			m_arrayVehicleList = m_obdInterface.GetVehicleProfiles();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			groupVehicles = new System.Windows.Forms.GroupBox();
			btnDeleteVehicle = new System.Windows.Forms.Button();
			btnNewVehicle = new System.Windows.Forms.Button();
			listVehicles = new System.Windows.Forms.ListBox();
			groupProfile = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			btnCalcSpeedo = new System.Windows.Forms.Button();
			txtSpeedoFactor = new System.Windows.Forms.TextBox();
			groupTimeout = new System.Windows.Forms.GroupBox();
			lblTimeoutUnits = new System.Windows.Forms.Label();
			numTimeout = new System.Windows.Forms.NumericUpDown();
			lblTimeout = new System.Windows.Forms.Label();
			btnSave = new System.Windows.Forms.Button();
			btnDiscard = new System.Windows.Forms.Button();
			groupNotes = new System.Windows.Forms.GroupBox();
			txtNotes = new System.Windows.Forms.TextBox();
			groupMisc = new System.Windows.Forms.GroupBox();
			txtDragCoeff = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			lblPounds = new System.Windows.Forms.Label();
			txtWeight = new System.Windows.Forms.TextBox();
			lblWeight = new System.Windows.Forms.Label();
			groupWheels = new System.Windows.Forms.GroupBox();
			lblRimDiameterUnits = new System.Windows.Forms.Label();
			lblTireAspectUnits = new System.Windows.Forms.Label();
			lblTireWidthUnits = new System.Windows.Forms.Label();
			lblExampleEnd = new System.Windows.Forms.Label();
			lblExampleDiameter = new System.Windows.Forms.Label();
			lblExampleAspect = new System.Windows.Forms.Label();
			lblExampleSlash = new System.Windows.Forms.Label();
			lblExampleDash = new System.Windows.Forms.Label();
			lblExampleWidth = new System.Windows.Forms.Label();
			lblExample = new System.Windows.Forms.Label();
			txtRimDiameter = new System.Windows.Forms.TextBox();
			lblRimDiameter = new System.Windows.Forms.Label();
			txtAspectRatio = new System.Windows.Forms.TextBox();
			lblTireAspectRatio = new System.Windows.Forms.Label();
			txtTireWidth = new System.Windows.Forms.TextBox();
			lblTireWidth = new System.Windows.Forms.Label();
			groupDrivetrain = new System.Windows.Forms.GroupBox();
			radioManual = new System.Windows.Forms.RadioButton();
			radioAutomatic = new System.Windows.Forms.RadioButton();
			txtName = new System.Windows.Forms.TextBox();
			lblName = new System.Windows.Forms.Label();
			btnExit = new System.Windows.Forms.Button();
			groupVehicles.SuspendLayout();
			groupProfile.SuspendLayout();
			groupBox1.SuspendLayout();
			groupTimeout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(numTimeout)).BeginInit();
			groupNotes.SuspendLayout();
			groupMisc.SuspendLayout();
			groupWheels.SuspendLayout();
			groupDrivetrain.SuspendLayout();
			SuspendLayout();
			// 
			// groupVehicles
			// 
			groupVehicles.Controls.Add(btnDeleteVehicle);
			groupVehicles.Controls.Add(btnNewVehicle);
			groupVehicles.Controls.Add(listVehicles);
			groupVehicles.Location = new System.Drawing.Point(5, 9);
			groupVehicles.Name = "groupVehicles";
			groupVehicles.Size = new System.Drawing.Size(150, 364);
			groupVehicles.TabIndex = 0;
			groupVehicles.TabStop = false;
			groupVehicles.Text = "Vehicles";
			// 
			// btnDeleteVehicle
			// 
			btnDeleteVehicle.Location = new System.Drawing.Point(77, 330);
			btnDeleteVehicle.Name = "btnDeleteVehicle";
			btnDeleteVehicle.Size = new System.Drawing.Size(63, 25);
			btnDeleteVehicle.TabIndex = 2;
			btnDeleteVehicle.Text = "&Delete";
			btnDeleteVehicle.Click += new System.EventHandler(btnDeleteVehicle_Click);
			// 
			// btnNewVehicle
			// 
			btnNewVehicle.Location = new System.Drawing.Point(10, 330);
			btnNewVehicle.Name = "btnNewVehicle";
			btnNewVehicle.Size = new System.Drawing.Size(62, 25);
			btnNewVehicle.TabIndex = 1;
			btnNewVehicle.Text = "&New";
			btnNewVehicle.Click += new System.EventHandler(btnNewVehicle_Click);
			// 
			// listVehicles
			// 
			listVehicles.Location = new System.Drawing.Point(10, 20);
			listVehicles.Name = "listVehicles";
			listVehicles.Size = new System.Drawing.Size(130, 303);
			listVehicles.TabIndex = 0;
			listVehicles.SelectedIndexChanged += new System.EventHandler(listVehicles_SelectedIndexChanged);
			// 
			// groupProfile
			// 
			groupProfile.Controls.Add(groupBox1);
			groupProfile.Controls.Add(groupTimeout);
			groupProfile.Controls.Add(btnSave);
			groupProfile.Controls.Add(btnDiscard);
			groupProfile.Controls.Add(groupNotes);
			groupProfile.Controls.Add(groupMisc);
			groupProfile.Controls.Add(groupWheels);
			groupProfile.Controls.Add(groupDrivetrain);
			groupProfile.Controls.Add(txtName);
			groupProfile.Controls.Add(lblName);
			groupProfile.Location = new System.Drawing.Point(160, 9);
			groupProfile.Name = "groupProfile";
			groupProfile.Size = new System.Drawing.Size(424, 364);
			groupProfile.TabIndex = 1;
			groupProfile.TabStop = false;
			groupProfile.Text = "Selected vehicle profile";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(btnCalcSpeedo);
			groupBox1.Controls.Add(txtSpeedoFactor);
			groupBox1.Location = new System.Drawing.Point(11, 177);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(205, 65);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Speedometer Calibration Factor";
			// 
			// btnCalcSpeedo
			// 
			btnCalcSpeedo.Location = new System.Drawing.Point(105, 27);
			btnCalcSpeedo.Name = "btnCalcSpeedo";
			btnCalcSpeedo.Size = new System.Drawing.Size(82, 23);
			btnCalcSpeedo.TabIndex = 1;
			btnCalcSpeedo.Text = "&Calculate";
			btnCalcSpeedo.Click += new System.EventHandler(btnCalcSpeedo_Click);
			// 
			// txtSpeedoFactor
			// 
			txtSpeedoFactor.Location = new System.Drawing.Point(18, 28);
			txtSpeedoFactor.Name = "txtSpeedoFactor";
			txtSpeedoFactor.Size = new System.Drawing.Size(72, 20);
			txtSpeedoFactor.TabIndex = 0;
			txtSpeedoFactor.Text = "1.000";
			txtSpeedoFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupTimeout
			// 
			groupTimeout.Controls.Add(lblTimeoutUnits);
			groupTimeout.Controls.Add(numTimeout);
			groupTimeout.Controls.Add(lblTimeout);
			groupTimeout.Location = new System.Drawing.Point(10, 48);
			groupTimeout.Name = "groupTimeout";
			groupTimeout.Size = new System.Drawing.Size(205, 58);
			groupTimeout.TabIndex = 2;
			groupTimeout.TabStop = false;
			groupTimeout.Text = "OBD-II Timing";
			// 
			// lblTimeoutUnits
			// 
			lblTimeoutUnits.Location = new System.Drawing.Point(165, 20);
			lblTimeoutUnits.Name = "lblTimeoutUnits";
			lblTimeoutUnits.Size = new System.Drawing.Size(22, 20);
			lblTimeoutUnits.TabIndex = 2;
			lblTimeoutUnits.Text = "ms";
			lblTimeoutUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTimeout
			// 
			numTimeout.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
			numTimeout.Location = new System.Drawing.Point(93, 20);
			numTimeout.Maximum = new decimal(new int[] {
            1020,
            0,
            0,
            0});
			numTimeout.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			numTimeout.Name = "numTimeout";
			numTimeout.Size = new System.Drawing.Size(61, 20);
			numTimeout.TabIndex = 1;
			numTimeout.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			numTimeout.ValueChanged += new System.EventHandler(numTimeout_ValueChanged);
			// 
			// lblTimeout
			// 
			lblTimeout.Location = new System.Drawing.Point(13, 20);
			lblTimeout.Name = "lblTimeout";
			lblTimeout.Size = new System.Drawing.Size(75, 20);
			lblTimeout.TabIndex = 0;
			lblTimeout.Text = "ELM &Timeout:";
			lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSave
			// 
			btnSave.Location = new System.Drawing.Point(255, 330);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 25);
			btnSave.TabIndex = 8;
			btnSave.Text = "&Save";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			// 
			// btnDiscard
			// 
			btnDiscard.Location = new System.Drawing.Point(335, 330);
			btnDiscard.Name = "btnDiscard";
			btnDiscard.Size = new System.Drawing.Size(75, 25);
			btnDiscard.TabIndex = 9;
			btnDiscard.Text = "D&iscard";
			btnDiscard.Click += new System.EventHandler(btnDiscard_Click);
			// 
			// groupNotes
			// 
			groupNotes.Controls.Add(txtNotes);
			groupNotes.Location = new System.Drawing.Point(225, 177);
			groupNotes.Name = "groupNotes";
			groupNotes.Size = new System.Drawing.Size(185, 148);
			groupNotes.TabIndex = 7;
			groupNotes.TabStop = false;
			groupNotes.Text = "Notes";
			// 
			// txtNotes
			// 
			txtNotes.Location = new System.Drawing.Point(10, 20);
			txtNotes.Multiline = true;
			txtNotes.Name = "txtNotes";
			txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			txtNotes.Size = new System.Drawing.Size(165, 119);
			txtNotes.TabIndex = 0;
			txtNotes.TextChanged += new System.EventHandler(ValueChanged);
			// 
			// groupMisc
			// 
			groupMisc.Controls.Add(txtDragCoeff);
			groupMisc.Controls.Add(label1);
			groupMisc.Controls.Add(lblPounds);
			groupMisc.Controls.Add(txtWeight);
			groupMisc.Controls.Add(lblWeight);
			groupMisc.Location = new System.Drawing.Point(10, 250);
			groupMisc.Name = "groupMisc";
			groupMisc.Size = new System.Drawing.Size(205, 75);
			groupMisc.TabIndex = 5;
			groupMisc.TabStop = false;
			groupMisc.Text = "Miscellaneous";
			// 
			// txtDragCoeff
			// 
			txtDragCoeff.Location = new System.Drawing.Point(90, 45);
			txtDragCoeff.Name = "txtDragCoeff";
			txtDragCoeff.Size = new System.Drawing.Size(50, 20);
			txtDragCoeff.TabIndex = 4;
			txtDragCoeff.TextChanged += new System.EventHandler(ValueChanged);
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(15, 45);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(70, 20);
			label1.TabIndex = 3;
			label1.Text = "&Drag coeff.:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPounds
			// 
			lblPounds.Location = new System.Drawing.Point(145, 20);
			lblPounds.Name = "lblPounds";
			lblPounds.Size = new System.Drawing.Size(50, 20);
			lblPounds.TabIndex = 2;
			lblPounds.Text = "lbs";
			lblPounds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtWeight
			// 
			txtWeight.Location = new System.Drawing.Point(90, 20);
			txtWeight.Name = "txtWeight";
			txtWeight.Size = new System.Drawing.Size(50, 20);
			txtWeight.TabIndex = 1;
			txtWeight.TextChanged += new System.EventHandler(ValueChanged);
			// 
			// lblWeight
			// 
			lblWeight.Location = new System.Drawing.Point(15, 20);
			lblWeight.Name = "lblWeight";
			lblWeight.Size = new System.Drawing.Size(70, 20);
			lblWeight.TabIndex = 0;
			lblWeight.Text = "W&eight:";
			lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupWheels
			// 
			groupWheels.Controls.Add(lblRimDiameterUnits);
			groupWheels.Controls.Add(lblTireAspectUnits);
			groupWheels.Controls.Add(lblTireWidthUnits);
			groupWheels.Controls.Add(lblExampleEnd);
			groupWheels.Controls.Add(lblExampleDiameter);
			groupWheels.Controls.Add(lblExampleAspect);
			groupWheels.Controls.Add(lblExampleSlash);
			groupWheels.Controls.Add(lblExampleDash);
			groupWheels.Controls.Add(lblExampleWidth);
			groupWheels.Controls.Add(lblExample);
			groupWheels.Controls.Add(txtRimDiameter);
			groupWheels.Controls.Add(lblRimDiameter);
			groupWheels.Controls.Add(txtAspectRatio);
			groupWheels.Controls.Add(lblTireAspectRatio);
			groupWheels.Controls.Add(txtTireWidth);
			groupWheels.Controls.Add(lblTireWidth);
			groupWheels.Location = new System.Drawing.Point(225, 48);
			groupWheels.Name = "groupWheels";
			groupWheels.Size = new System.Drawing.Size(185, 122);
			groupWheels.TabIndex = 6;
			groupWheels.TabStop = false;
			groupWheels.Text = "Wheels";
			// 
			// lblRimDiameterUnits
			// 
			lblRimDiameterUnits.Location = new System.Drawing.Point(145, 92);
			lblRimDiameterUnits.Name = "lblRimDiameterUnits";
			lblRimDiameterUnits.Size = new System.Drawing.Size(30, 20);
			lblRimDiameterUnits.TabIndex = 15;
			lblRimDiameterUnits.Text = "in";
			lblRimDiameterUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireAspectUnits
			// 
			lblTireAspectUnits.Location = new System.Drawing.Point(145, 67);
			lblTireAspectUnits.Name = "lblTireAspectUnits";
			lblTireAspectUnits.Size = new System.Drawing.Size(30, 20);
			lblTireAspectUnits.TabIndex = 12;
			lblTireAspectUnits.Text = "%";
			lblTireAspectUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireWidthUnits
			// 
			lblTireWidthUnits.Location = new System.Drawing.Point(145, 42);
			lblTireWidthUnits.Name = "lblTireWidthUnits";
			lblTireWidthUnits.Size = new System.Drawing.Size(30, 20);
			lblTireWidthUnits.TabIndex = 9;
			lblTireWidthUnits.Text = "mm";
			lblTireWidthUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblExampleEnd
			// 
			lblExampleEnd.Location = new System.Drawing.Point(170, 20);
			lblExampleEnd.Name = "lblExampleEnd";
			lblExampleEnd.Size = new System.Drawing.Size(5, 20);
			lblExampleEnd.TabIndex = 6;
			lblExampleEnd.Text = ")";
			lblExampleEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleDiameter
			// 
			lblExampleDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblExampleDiameter.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExampleDiameter.Location = new System.Drawing.Point(145, 20);
			lblExampleDiameter.Name = "lblExampleDiameter";
			lblExampleDiameter.Size = new System.Drawing.Size(25, 20);
			lblExampleDiameter.TabIndex = 5;
			lblExampleDiameter.Text = "17";
			lblExampleDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleAspect
			// 
			lblExampleAspect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblExampleAspect.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExampleAspect.Location = new System.Drawing.Point(105, 20);
			lblExampleAspect.Name = "lblExampleAspect";
			lblExampleAspect.Size = new System.Drawing.Size(30, 20);
			lblExampleAspect.TabIndex = 3;
			lblExampleAspect.Text = "40";
			lblExampleAspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleSlash
			// 
			lblExampleSlash.Location = new System.Drawing.Point(95, 20);
			lblExampleSlash.Name = "lblExampleSlash";
			lblExampleSlash.Size = new System.Drawing.Size(10, 20);
			lblExampleSlash.TabIndex = 2;
			lblExampleSlash.Text = "/";
			lblExampleSlash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleDash
			// 
			lblExampleDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblExampleDash.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExampleDash.Location = new System.Drawing.Point(135, 20);
			lblExampleDash.Name = "lblExampleDash";
			lblExampleDash.Size = new System.Drawing.Size(10, 20);
			lblExampleDash.TabIndex = 4;
			lblExampleDash.Text = "-";
			lblExampleDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleWidth
			// 
			lblExampleWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			lblExampleWidth.ForeColor = System.Drawing.SystemColors.ControlText;
			lblExampleWidth.Location = new System.Drawing.Point(65, 20);
			lblExampleWidth.Name = "lblExampleWidth";
			lblExampleWidth.Size = new System.Drawing.Size(30, 20);
			lblExampleWidth.TabIndex = 1;
			lblExampleWidth.Text = "275";
			lblExampleWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExample
			// 
			lblExample.Location = new System.Drawing.Point(5, 20);
			lblExample.Name = "lblExample";
			lblExample.Size = new System.Drawing.Size(55, 20);
			lblExample.TabIndex = 0;
			lblExample.Text = "(Example:";
			lblExample.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRimDiameter
			// 
			txtRimDiameter.Location = new System.Drawing.Point(90, 92);
			txtRimDiameter.Name = "txtRimDiameter";
			txtRimDiameter.Size = new System.Drawing.Size(50, 20);
			txtRimDiameter.TabIndex = 14;
			txtRimDiameter.TextChanged += new System.EventHandler(ValueChanged);
			txtRimDiameter.Enter += new System.EventHandler(txtRimDiameter_Enter);
			txtRimDiameter.Leave += new System.EventHandler(txtRimDiameter_Leave);
			// 
			// lblRimDiameter
			// 
			lblRimDiameter.Location = new System.Drawing.Point(10, 92);
			lblRimDiameter.Name = "lblRimDiameter";
			lblRimDiameter.Size = new System.Drawing.Size(75, 20);
			lblRimDiameter.TabIndex = 13;
			lblRimDiameter.Text = "Rim &diameter:";
			lblRimDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAspectRatio
			// 
			txtAspectRatio.Location = new System.Drawing.Point(90, 67);
			txtAspectRatio.Name = "txtAspectRatio";
			txtAspectRatio.Size = new System.Drawing.Size(50, 20);
			txtAspectRatio.TabIndex = 11;
			txtAspectRatio.TextChanged += new System.EventHandler(ValueChanged);
			txtAspectRatio.Enter += new System.EventHandler(txtAspectRatio_Enter);
			txtAspectRatio.Leave += new System.EventHandler(txtAspectRatio_Leave);
			// 
			// lblTireAspectRatio
			// 
			lblTireAspectRatio.Location = new System.Drawing.Point(10, 67);
			lblTireAspectRatio.Name = "lblTireAspectRatio";
			lblTireAspectRatio.Size = new System.Drawing.Size(75, 20);
			lblTireAspectRatio.TabIndex = 10;
			lblTireAspectRatio.Text = "Tire &aspect:";
			lblTireAspectRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTireWidth
			// 
			txtTireWidth.Location = new System.Drawing.Point(90, 42);
			txtTireWidth.Name = "txtTireWidth";
			txtTireWidth.Size = new System.Drawing.Size(50, 20);
			txtTireWidth.TabIndex = 8;
			txtTireWidth.TextChanged += new System.EventHandler(ValueChanged);
			txtTireWidth.Enter += new System.EventHandler(txtTireWidth_Enter);
			txtTireWidth.Leave += new System.EventHandler(txtTireWidth_Leave);
			// 
			// lblTireWidth
			// 
			lblTireWidth.Location = new System.Drawing.Point(10, 42);
			lblTireWidth.Name = "lblTireWidth";
			lblTireWidth.Size = new System.Drawing.Size(75, 20);
			lblTireWidth.TabIndex = 7;
			lblTireWidth.Text = "Tire &width:";
			lblTireWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupDrivetrain
			// 
			groupDrivetrain.Controls.Add(radioManual);
			groupDrivetrain.Controls.Add(radioAutomatic);
			groupDrivetrain.Location = new System.Drawing.Point(10, 114);
			groupDrivetrain.Name = "groupDrivetrain";
			groupDrivetrain.Size = new System.Drawing.Size(205, 56);
			groupDrivetrain.TabIndex = 3;
			groupDrivetrain.TabStop = false;
			groupDrivetrain.Text = "Transmission";
			// 
			// radioManual
			// 
			radioManual.Checked = true;
			radioManual.Location = new System.Drawing.Point(116, 20);
			radioManual.Name = "radioManual";
			radioManual.Size = new System.Drawing.Size(75, 20);
			radioManual.TabIndex = 1;
			radioManual.TabStop = true;
			radioManual.Text = "&Manual";
			radioManual.CheckedChanged += new System.EventHandler(ValueChanged);
			// 
			// radioAutomatic
			// 
			radioAutomatic.Location = new System.Drawing.Point(15, 20);
			radioAutomatic.Name = "radioAutomatic";
			radioAutomatic.Size = new System.Drawing.Size(75, 20);
			radioAutomatic.TabIndex = 0;
			radioAutomatic.Text = "&Automatic";
			radioAutomatic.CheckedChanged += new System.EventHandler(ValueChanged);
			// 
			// txtName
			// 
			txtName.Location = new System.Drawing.Point(60, 20);
			txtName.MaxLength = 20;
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(350, 20);
			txtName.TabIndex = 1;
			txtName.TextChanged += new System.EventHandler(ValueChanged);
			// 
			// lblName
			// 
			lblName.Location = new System.Drawing.Point(5, 20);
			lblName.Name = "lblName";
			lblName.Size = new System.Drawing.Size(50, 20);
			lblName.TabIndex = 0;
			lblName.Text = "Name:";
			lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnExit
			// 
			btnExit.Location = new System.Drawing.Point(496, 384);
			btnExit.Name = "btnExit";
			btnExit.Size = new System.Drawing.Size(75, 25);
			btnExit.TabIndex = 2;
			btnExit.Text = "D&one";
			btnExit.Click += new System.EventHandler(btnExit_Click);
			// 
			// VehicleForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(586, 416);
			Controls.Add(groupProfile);
			Controls.Add(groupVehicles);
			Controls.Add(btnExit);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "VehicleForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Vehicle Profile Manager";
			Closing += new System.ComponentModel.CancelEventHandler(VehicleForm_Closing);
			Load += new System.EventHandler(VehicleForm_Load);
			groupVehicles.ResumeLayout(false);
			groupProfile.ResumeLayout(false);
			groupProfile.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupTimeout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(numTimeout)).EndInit();
			groupNotes.ResumeLayout(false);
			groupNotes.PerformLayout();
			groupMisc.ResumeLayout(false);
			groupMisc.PerformLayout();
			groupWheels.ResumeLayout(false);
			groupWheels.PerformLayout();
			groupDrivetrain.ResumeLayout(false);
			ResumeLayout(false);

		}

		private void btnNewVehicle_Click(object sender, EventArgs e)
		{
			VehicleProfile vehicleProfile = new VehicleProfile();
			listVehicles.Items.Add((object)vehicleProfile);
			m_arrayVehicleList.Add((object)vehicleProfile);
			listVehicles.SetSelected(listVehicles.Items.Count - 1, true);
		}

		private void btnDeleteVehicle_Click(object sender, EventArgs e)
		{
			if (m_arrayVehicleList.Count > 1)
			{
				if (MessageBox.Show("This will permanently delete " + listVehicles.SelectedItem.ToString() + ".\n\n Are you sure?", "Delete " + listVehicles.SelectedItem.ToString() + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					int selectedIndex = listVehicles.SelectedIndex;
					m_arrayVehicleList.RemoveAt(selectedIndex);
					UpdateProfileList(m_arrayVehicleList);
					if (selectedIndex > 0)
					{
						listVehicles.SetSelected(selectedIndex - 1, true);
					}
					else if (m_arrayVehicleList.Count > 0)
					{
						listVehicles.SetSelected(0, true);
					}
				}
			}
			else
			{
				MessageBox.Show("You must keep at least one vehicle profile.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void EditProfile(VehicleProfile profile)
		{
			txtName.Text = profile.Name;
			decimal num = new decimal();
			num = new decimal(profile.ElmTimeout);
			numTimeout.Value = num;
			if (profile.AutoTransmission)
			{
				radioAutomatic.Checked = true;
			}
			else
			{
				radioManual.Checked = true;
			}
			txtSpeedoFactor.Text = profile.SpeedCalibrationFactor.ToString("0.000");
			txtWeight.Text = profile.Weight.ToString();
			txtDragCoeff.Text = profile.DragCoefficient.ToString("0.000");
			txtTireWidth.Text = profile.Wheel.Width.ToString();
			txtAspectRatio.Text = profile.Wheel.AspectRatio.ToString();
			txtRimDiameter.Text = profile.Wheel.RimDiameter.ToString();
			txtNotes.Text = profile.Notes;
			MarkProfileDirty(false);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			if (bDirtyProfile)
			{
				if (MessageBox.Show("This profile has been modified since it was last saved.\n\nDo you wish to exit anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					base.Close();
				}
			}
			else
			{
				base.Close();
			}
		}

		private void VehicleForm_Load(object sender, EventArgs e)
		{
			UpdateProfileList(m_arrayVehicleList);
			listVehicles.SetSelected(0, true);
		}

		private void UpdateProfileList(ArrayList vehicles)
		{
			listVehicles.Items.Clear();
			IEnumerator enumerator = vehicles.GetEnumerator();
			if (!enumerator.MoveNext())
				return;
			do
			{
				listVehicles.Items.Add((object)(enumerator.Current as VehicleProfile));
			}
			while (enumerator.MoveNext());
		}

		public static int lastSelectedIndex;

		private void listVehicles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listVehicles.SelectedIndex < 0)
				return;
			if (bDirtyProfile)
			{
				if (listVehicles.SelectedIndex == lastSelectedIndex)
					return;
				listVehicles.SetSelected(lastSelectedIndex, true);
				MessageBox.Show("Please save or discard your changes before switching profiles.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				EditProfile(m_arrayVehicleList[listVehicles.SelectedIndex] as VehicleProfile);
				lastSelectedIndex = listVehicles.SelectedIndex;
			}
		}

		private void MarkProfileDirty(bool bStatus)
		{
			bDirtyProfile = bStatus;
			if (bDirtyProfile)
			{
				btnDiscard.Enabled = true;
				btnSave.Enabled = true;
			}
			else
			{
				btnDiscard.Enabled = false;
				btnSave.Enabled = false;
			}
		}

		private void numTimeout_ValueChanged(object sender, EventArgs e)
		{
			MarkProfileDirty(true);
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			MarkProfileDirty(true);
		}

		private void btnDiscard_Click(object sender, EventArgs e)
		{
			EditProfile(m_arrayVehicleList[listVehicles.SelectedIndex] as VehicleProfile);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			VehicleProfile vehicleProfile = new VehicleProfile();
			if (txtName.Text.Length > 0)
			{
				vehicleProfile.Name = txtName.Text;
				Decimal num1 = numTimeout.Value;
				vehicleProfile.ElmTimeout = Convert.ToInt32(num1);
				vehicleProfile.AutoTransmission = radioAutomatic.Checked;
				try
				{
					vehicleProfile.SpeedCalibrationFactor = Convert.ToSingle(txtSpeedoFactor.Text);
					vehicleProfile.Weight = Convert.ToSingle(txtWeight.Text);
					vehicleProfile.DragCoefficient = Convert.ToSingle(txtDragCoeff.Text);
					vehicleProfile.Wheel.Width = Convert.ToInt32(txtTireWidth.Text);
					vehicleProfile.Wheel.AspectRatio = Convert.ToInt32(txtAspectRatio.Text);
					vehicleProfile.Wheel.RimDiameter = Convert.ToInt32(txtRimDiameter.Text);
					vehicleProfile.Notes = txtNotes.Text;
				}
				catch (FormatException)
				{
					MessageBox.Show("Make sure that numeric fields contain only numeric data, and make sure that you are not forgetting a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				m_arrayVehicleList[listVehicles.SelectedIndex] = (object)vehicleProfile;
				MarkProfileDirty(false);
				int selectedIndex = listVehicles.SelectedIndex;
				UpdateProfileList(m_arrayVehicleList);
				listVehicles.SetSelected(selectedIndex, true);
			}
			else
			{
				MessageBox.Show("You must enter a name for your profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void VehicleForm_Closing(object sender, CancelEventArgs e)
		{
			m_obdInterface.SaveVehicleProfiles(m_arrayVehicleList);
		}

		private void txtTireWidth_Enter(object sender, EventArgs e)
		{
			lblExampleWidth.Font = new Font(lblExampleWidth.Font.FontFamily, 10f, FontStyle.Bold);
			lblExampleWidth.ForeColor = Color.Red;
		}

		private void txtTireWidth_Leave(object sender, EventArgs e)
		{
			lblExampleWidth.Font = lblExample.Font;
			lblExampleWidth.ForeColor = lblExample.ForeColor;
		}

		private void txtAspectRatio_Enter(object sender, EventArgs e)
		{
			lblExampleAspect.Font = new Font(lblExampleWidth.Font.FontFamily, 10f, FontStyle.Bold);
			lblExampleAspect.ForeColor = Color.Red;
		}

		private void txtAspectRatio_Leave(object sender, EventArgs e)
		{
			lblExampleAspect.Font = lblExample.Font;
			lblExampleAspect.ForeColor = lblExample.ForeColor;
		}

		private void txtRimDiameter_Enter(object sender, EventArgs e)
		{
			lblExampleDiameter.Font = new Font(lblExampleWidth.Font.FontFamily, 10f, FontStyle.Bold);
			lblExampleDiameter.ForeColor = Color.Red;
		}

		private void txtRimDiameter_Leave(object sender, EventArgs e)
		{
			lblExampleDiameter.Font = lblExample.Font;
			lblExampleDiameter.ForeColor = lblExample.ForeColor;
		}

		private void btnCalcSpeedo_Click(object sender, EventArgs e)
		{
			SpeedFactorCalcForm speedFactorCalcForm = new SpeedFactorCalcForm();
			if (speedFactorCalcForm.ShowDialog() != DialogResult.OK)
				return;
			txtSpeedoFactor.Text = speedFactorCalcForm.getSpeedFactor().ToString("0.000");
			MarkProfileDirty(true);
		}
	}
}