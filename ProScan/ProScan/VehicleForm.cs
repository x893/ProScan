using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class VehicleForm : Form
	{
		private List<VehicleProfile> m_VehicleList;
		private bool bDirtyProfile;
		private OBDInterface m_obdInterface;

		public VehicleForm(OBDInterface obd)
		{
			InitializeComponent();
			m_obdInterface = obd;
			m_VehicleList = m_obdInterface.VehicleProfiles;
		}

		private void btnNewVehicle_Click(object sender, EventArgs e)
		{
			VehicleProfile vehicleProfile = new VehicleProfile();
			listVehicles.Items.Add(vehicleProfile);
			m_VehicleList.Add(vehicleProfile);
			listVehicles.SetSelected(listVehicles.Items.Count - 1, true);
		}

		private void btnDeleteVehicle_Click(object sender, EventArgs e)
		{
			if (m_VehicleList.Count > 1)
			{
				if (MessageBox.Show("This will permanently delete " + listVehicles.SelectedItem.ToString() + ".\n\n Are you sure?", "Delete " + listVehicles.SelectedItem.ToString() + "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					int selectedIndex = listVehicles.SelectedIndex;
					m_VehicleList.RemoveAt(selectedIndex);
					UpdateProfileList(m_VehicleList);
					if (selectedIndex > 0)
						listVehicles.SetSelected(selectedIndex - 1, true);
					else if (m_VehicleList.Count > 0)
						listVehicles.SetSelected(0, true);
				}
			}
			else
				MessageBox.Show("You must keep at least one vehicle profile.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void EditProfile(VehicleProfile profile)
		{
			txtName.Text = profile.Name;
			numTimeout.Value = new decimal(profile.ElmTimeout);
			if (profile.AutoTransmission)
				radioAutomatic.Checked = true;
			else
				radioManual.Checked = true;
		
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
					base.Close();
			}
			else
				base.Close();
		}

		private void VehicleForm_Load(object sender, EventArgs e)
		{
			UpdateProfileList(m_VehicleList);
			listVehicles.SetSelected(0, true);
		}

		private void UpdateProfileList(List<VehicleProfile> vehicles)
		{
			listVehicles.Items.Clear();
			foreach (VehicleProfile vehicle in vehicles)
				listVehicles.Items.Add(vehicle);
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
				EditProfile(m_VehicleList[listVehicles.SelectedIndex] as VehicleProfile);
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
			EditProfile(m_VehicleList[listVehicles.SelectedIndex] as VehicleProfile);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (txtName.Text.Length > 0)
			{
				VehicleProfile vehicle = new VehicleProfile();
				vehicle.Name = txtName.Text;
				vehicle.ElmTimeout = Convert.ToInt32(numTimeout.Value, CultureInfo.InvariantCulture);
				vehicle.AutoTransmission = radioAutomatic.Checked;

				try
				{
					vehicle.SpeedCalibrationFactor = Convert.ToSingle(txtSpeedoFactor.Text, CultureInfo.InvariantCulture);
					vehicle.Weight = Convert.ToSingle(txtWeight.Text, CultureInfo.InvariantCulture);
					vehicle.DragCoefficient = Convert.ToSingle(txtDragCoeff.Text, CultureInfo.InvariantCulture);
					vehicle.Wheel.Width = Convert.ToInt32(txtTireWidth.Text, CultureInfo.InvariantCulture);
					vehicle.Wheel.AspectRatio = Convert.ToInt32(txtAspectRatio.Text, CultureInfo.InvariantCulture);
					vehicle.Wheel.RimDiameter = Convert.ToInt32(txtRimDiameter.Text, CultureInfo.InvariantCulture);
					vehicle.Notes = txtNotes.Text;
				}
				catch (FormatException)
				{
					MessageBox.Show("Make sure that numeric fields contain only numeric data, and make sure that you are not forgetting a required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}

				m_VehicleList[listVehicles.SelectedIndex] = vehicle;
				MarkProfileDirty(false);

				int selectedIndex = listVehicles.SelectedIndex;
				UpdateProfileList(m_VehicleList);
				listVehicles.SetSelected(selectedIndex, true);
			}
			else
				MessageBox.Show("You must enter a name for your profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		private void VehicleForm_Closing(object sender, CancelEventArgs e)
		{
			m_obdInterface.SaveVehicleProfiles(m_VehicleList);
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
			if (speedFactorCalcForm.ShowDialog() == DialogResult.OK)
			{
				txtSpeedoFactor.Text = speedFactorCalcForm.SpeedFactor.ToString("0.000");
				MarkProfileDirty(true);
			}
		}

		#region InitializeComponent
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

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupVehicles = new System.Windows.Forms.GroupBox();
			this.btnDeleteVehicle = new System.Windows.Forms.Button();
			this.btnNewVehicle = new System.Windows.Forms.Button();
			this.listVehicles = new System.Windows.Forms.ListBox();
			this.groupProfile = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCalcSpeedo = new System.Windows.Forms.Button();
			this.txtSpeedoFactor = new System.Windows.Forms.TextBox();
			this.groupTimeout = new System.Windows.Forms.GroupBox();
			this.lblTimeoutUnits = new System.Windows.Forms.Label();
			this.numTimeout = new System.Windows.Forms.NumericUpDown();
			this.lblTimeout = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDiscard = new System.Windows.Forms.Button();
			this.groupNotes = new System.Windows.Forms.GroupBox();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.groupMisc = new System.Windows.Forms.GroupBox();
			this.txtDragCoeff = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblPounds = new System.Windows.Forms.Label();
			this.txtWeight = new System.Windows.Forms.TextBox();
			this.lblWeight = new System.Windows.Forms.Label();
			this.groupWheels = new System.Windows.Forms.GroupBox();
			this.lblRimDiameterUnits = new System.Windows.Forms.Label();
			this.lblTireAspectUnits = new System.Windows.Forms.Label();
			this.lblTireWidthUnits = new System.Windows.Forms.Label();
			this.lblExampleEnd = new System.Windows.Forms.Label();
			this.lblExampleDiameter = new System.Windows.Forms.Label();
			this.lblExampleAspect = new System.Windows.Forms.Label();
			this.lblExampleSlash = new System.Windows.Forms.Label();
			this.lblExampleDash = new System.Windows.Forms.Label();
			this.lblExampleWidth = new System.Windows.Forms.Label();
			this.lblExample = new System.Windows.Forms.Label();
			this.txtRimDiameter = new System.Windows.Forms.TextBox();
			this.lblRimDiameter = new System.Windows.Forms.Label();
			this.txtAspectRatio = new System.Windows.Forms.TextBox();
			this.lblTireAspectRatio = new System.Windows.Forms.Label();
			this.txtTireWidth = new System.Windows.Forms.TextBox();
			this.lblTireWidth = new System.Windows.Forms.Label();
			this.groupDrivetrain = new System.Windows.Forms.GroupBox();
			this.radioManual = new System.Windows.Forms.RadioButton();
			this.radioAutomatic = new System.Windows.Forms.RadioButton();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.groupVehicles.SuspendLayout();
			this.groupProfile.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupTimeout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
			this.groupNotes.SuspendLayout();
			this.groupMisc.SuspendLayout();
			this.groupWheels.SuspendLayout();
			this.groupDrivetrain.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupVehicles
			// 
			this.groupVehicles.Controls.Add(this.btnDeleteVehicle);
			this.groupVehicles.Controls.Add(this.btnNewVehicle);
			this.groupVehicles.Controls.Add(this.listVehicles);
			this.groupVehicles.Location = new System.Drawing.Point(6, 10);
			this.groupVehicles.Name = "groupVehicles";
			this.groupVehicles.Size = new System.Drawing.Size(180, 420);
			this.groupVehicles.TabIndex = 0;
			this.groupVehicles.TabStop = false;
			this.groupVehicles.Text = "Vehicles";
			// 
			// btnDeleteVehicle
			// 
			this.btnDeleteVehicle.Location = new System.Drawing.Point(92, 381);
			this.btnDeleteVehicle.Name = "btnDeleteVehicle";
			this.btnDeleteVehicle.Size = new System.Drawing.Size(76, 29);
			this.btnDeleteVehicle.TabIndex = 2;
			this.btnDeleteVehicle.Text = "&Delete";
			this.btnDeleteVehicle.Click += new System.EventHandler(this.btnDeleteVehicle_Click);
			// 
			// btnNewVehicle
			// 
			this.btnNewVehicle.Location = new System.Drawing.Point(12, 381);
			this.btnNewVehicle.Name = "btnNewVehicle";
			this.btnNewVehicle.Size = new System.Drawing.Size(74, 29);
			this.btnNewVehicle.TabIndex = 1;
			this.btnNewVehicle.Text = "&New";
			this.btnNewVehicle.Click += new System.EventHandler(this.btnNewVehicle_Click);
			// 
			// listVehicles
			// 
			this.listVehicles.ItemHeight = 16;
			this.listVehicles.Location = new System.Drawing.Point(12, 23);
			this.listVehicles.Name = "listVehicles";
			this.listVehicles.Size = new System.Drawing.Size(156, 324);
			this.listVehicles.TabIndex = 0;
			this.listVehicles.SelectedIndexChanged += new System.EventHandler(this.listVehicles_SelectedIndexChanged);
			// 
			// groupProfile
			// 
			this.groupProfile.Controls.Add(this.groupBox1);
			this.groupProfile.Controls.Add(this.groupTimeout);
			this.groupProfile.Controls.Add(this.btnSave);
			this.groupProfile.Controls.Add(this.btnDiscard);
			this.groupProfile.Controls.Add(this.groupNotes);
			this.groupProfile.Controls.Add(this.groupMisc);
			this.groupProfile.Controls.Add(this.groupWheels);
			this.groupProfile.Controls.Add(this.groupDrivetrain);
			this.groupProfile.Controls.Add(this.txtName);
			this.groupProfile.Controls.Add(this.lblName);
			this.groupProfile.Location = new System.Drawing.Point(192, 10);
			this.groupProfile.Name = "groupProfile";
			this.groupProfile.Size = new System.Drawing.Size(509, 420);
			this.groupProfile.TabIndex = 1;
			this.groupProfile.TabStop = false;
			this.groupProfile.Text = "Selected vehicle profile";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnCalcSpeedo);
			this.groupBox1.Controls.Add(this.txtSpeedoFactor);
			this.groupBox1.Location = new System.Drawing.Point(13, 204);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(246, 75);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Speedometer Calibration Factor";
			// 
			// btnCalcSpeedo
			// 
			this.btnCalcSpeedo.Location = new System.Drawing.Point(126, 31);
			this.btnCalcSpeedo.Name = "btnCalcSpeedo";
			this.btnCalcSpeedo.Size = new System.Drawing.Size(98, 27);
			this.btnCalcSpeedo.TabIndex = 1;
			this.btnCalcSpeedo.Text = "&Calculate";
			this.btnCalcSpeedo.Click += new System.EventHandler(this.btnCalcSpeedo_Click);
			// 
			// txtSpeedoFactor
			// 
			this.txtSpeedoFactor.Location = new System.Drawing.Point(22, 32);
			this.txtSpeedoFactor.Name = "txtSpeedoFactor";
			this.txtSpeedoFactor.Size = new System.Drawing.Size(86, 22);
			this.txtSpeedoFactor.TabIndex = 0;
			this.txtSpeedoFactor.Text = "1.000";
			this.txtSpeedoFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupTimeout
			// 
			this.groupTimeout.Controls.Add(this.lblTimeoutUnits);
			this.groupTimeout.Controls.Add(this.numTimeout);
			this.groupTimeout.Controls.Add(this.lblTimeout);
			this.groupTimeout.Location = new System.Drawing.Point(12, 55);
			this.groupTimeout.Name = "groupTimeout";
			this.groupTimeout.Size = new System.Drawing.Size(246, 67);
			this.groupTimeout.TabIndex = 2;
			this.groupTimeout.TabStop = false;
			this.groupTimeout.Text = "OBD-II Timing";
			// 
			// lblTimeoutUnits
			// 
			this.lblTimeoutUnits.Location = new System.Drawing.Point(198, 23);
			this.lblTimeoutUnits.Name = "lblTimeoutUnits";
			this.lblTimeoutUnits.Size = new System.Drawing.Size(26, 23);
			this.lblTimeoutUnits.TabIndex = 2;
			this.lblTimeoutUnits.Text = "ms";
			this.lblTimeoutUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numTimeout
			// 
			this.numTimeout.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numTimeout.Location = new System.Drawing.Point(112, 23);
			this.numTimeout.Maximum = new decimal(new int[] {
            1020,
            0,
            0,
            0});
			this.numTimeout.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.numTimeout.Name = "numTimeout";
			this.numTimeout.Size = new System.Drawing.Size(73, 22);
			this.numTimeout.TabIndex = 1;
			this.numTimeout.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.numTimeout.ValueChanged += new System.EventHandler(this.numTimeout_ValueChanged);
			// 
			// lblTimeout
			// 
			this.lblTimeout.Location = new System.Drawing.Point(16, 23);
			this.lblTimeout.Name = "lblTimeout";
			this.lblTimeout.Size = new System.Drawing.Size(90, 23);
			this.lblTimeout.TabIndex = 0;
			this.lblTimeout.Text = "ELM &Timeout:";
			this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(306, 381);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 29);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDiscard
			// 
			this.btnDiscard.Location = new System.Drawing.Point(402, 381);
			this.btnDiscard.Name = "btnDiscard";
			this.btnDiscard.Size = new System.Drawing.Size(90, 29);
			this.btnDiscard.TabIndex = 9;
			this.btnDiscard.Text = "D&iscard";
			this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
			// 
			// groupNotes
			// 
			this.groupNotes.Controls.Add(this.txtNotes);
			this.groupNotes.Location = new System.Drawing.Point(270, 204);
			this.groupNotes.Name = "groupNotes";
			this.groupNotes.Size = new System.Drawing.Size(222, 171);
			this.groupNotes.TabIndex = 7;
			this.groupNotes.TabStop = false;
			this.groupNotes.Text = "Notes";
			// 
			// txtNotes
			// 
			this.txtNotes.Location = new System.Drawing.Point(12, 23);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(198, 137);
			this.txtNotes.TabIndex = 0;
			this.txtNotes.TextChanged += new System.EventHandler(this.ValueChanged);
			// 
			// groupMisc
			// 
			this.groupMisc.Controls.Add(this.txtDragCoeff);
			this.groupMisc.Controls.Add(this.label1);
			this.groupMisc.Controls.Add(this.lblPounds);
			this.groupMisc.Controls.Add(this.txtWeight);
			this.groupMisc.Controls.Add(this.lblWeight);
			this.groupMisc.Location = new System.Drawing.Point(12, 288);
			this.groupMisc.Name = "groupMisc";
			this.groupMisc.Size = new System.Drawing.Size(246, 87);
			this.groupMisc.TabIndex = 5;
			this.groupMisc.TabStop = false;
			this.groupMisc.Text = "Miscellaneous";
			// 
			// txtDragCoeff
			// 
			this.txtDragCoeff.Location = new System.Drawing.Point(108, 52);
			this.txtDragCoeff.Name = "txtDragCoeff";
			this.txtDragCoeff.Size = new System.Drawing.Size(60, 22);
			this.txtDragCoeff.TabIndex = 4;
			this.txtDragCoeff.TextChanged += new System.EventHandler(this.ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "&Drag coeff.:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPounds
			// 
			this.lblPounds.Location = new System.Drawing.Point(174, 23);
			this.lblPounds.Name = "lblPounds";
			this.lblPounds.Size = new System.Drawing.Size(60, 23);
			this.lblPounds.TabIndex = 2;
			this.lblPounds.Text = "lbs";
			this.lblPounds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtWeight
			// 
			this.txtWeight.Location = new System.Drawing.Point(108, 23);
			this.txtWeight.Name = "txtWeight";
			this.txtWeight.Size = new System.Drawing.Size(60, 22);
			this.txtWeight.TabIndex = 1;
			this.txtWeight.TextChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblWeight
			// 
			this.lblWeight.Location = new System.Drawing.Point(18, 23);
			this.lblWeight.Name = "lblWeight";
			this.lblWeight.Size = new System.Drawing.Size(84, 23);
			this.lblWeight.TabIndex = 0;
			this.lblWeight.Text = "W&eight:";
			this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupWheels
			// 
			this.groupWheels.Controls.Add(this.lblRimDiameterUnits);
			this.groupWheels.Controls.Add(this.lblTireAspectUnits);
			this.groupWheels.Controls.Add(this.lblTireWidthUnits);
			this.groupWheels.Controls.Add(this.lblExampleEnd);
			this.groupWheels.Controls.Add(this.lblExampleDiameter);
			this.groupWheels.Controls.Add(this.lblExampleAspect);
			this.groupWheels.Controls.Add(this.lblExampleSlash);
			this.groupWheels.Controls.Add(this.lblExampleDash);
			this.groupWheels.Controls.Add(this.lblExampleWidth);
			this.groupWheels.Controls.Add(this.lblExample);
			this.groupWheels.Controls.Add(this.txtRimDiameter);
			this.groupWheels.Controls.Add(this.lblRimDiameter);
			this.groupWheels.Controls.Add(this.txtAspectRatio);
			this.groupWheels.Controls.Add(this.lblTireAspectRatio);
			this.groupWheels.Controls.Add(this.txtTireWidth);
			this.groupWheels.Controls.Add(this.lblTireWidth);
			this.groupWheels.Location = new System.Drawing.Point(270, 55);
			this.groupWheels.Name = "groupWheels";
			this.groupWheels.Size = new System.Drawing.Size(222, 141);
			this.groupWheels.TabIndex = 6;
			this.groupWheels.TabStop = false;
			this.groupWheels.Text = "Wheels";
			// 
			// lblRimDiameterUnits
			// 
			this.lblRimDiameterUnits.Location = new System.Drawing.Point(174, 106);
			this.lblRimDiameterUnits.Name = "lblRimDiameterUnits";
			this.lblRimDiameterUnits.Size = new System.Drawing.Size(36, 23);
			this.lblRimDiameterUnits.TabIndex = 15;
			this.lblRimDiameterUnits.Text = "in";
			this.lblRimDiameterUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireAspectUnits
			// 
			this.lblTireAspectUnits.Location = new System.Drawing.Point(174, 77);
			this.lblTireAspectUnits.Name = "lblTireAspectUnits";
			this.lblTireAspectUnits.Size = new System.Drawing.Size(36, 23);
			this.lblTireAspectUnits.TabIndex = 12;
			this.lblTireAspectUnits.Text = "%";
			this.lblTireAspectUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireWidthUnits
			// 
			this.lblTireWidthUnits.Location = new System.Drawing.Point(174, 48);
			this.lblTireWidthUnits.Name = "lblTireWidthUnits";
			this.lblTireWidthUnits.Size = new System.Drawing.Size(36, 24);
			this.lblTireWidthUnits.TabIndex = 9;
			this.lblTireWidthUnits.Text = "mm";
			this.lblTireWidthUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblExampleEnd
			// 
			this.lblExampleEnd.Location = new System.Drawing.Point(204, 23);
			this.lblExampleEnd.Name = "lblExampleEnd";
			this.lblExampleEnd.Size = new System.Drawing.Size(6, 23);
			this.lblExampleEnd.TabIndex = 6;
			this.lblExampleEnd.Text = ")";
			this.lblExampleEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleDiameter
			// 
			this.lblExampleDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExampleDiameter.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExampleDiameter.Location = new System.Drawing.Point(174, 23);
			this.lblExampleDiameter.Name = "lblExampleDiameter";
			this.lblExampleDiameter.Size = new System.Drawing.Size(30, 23);
			this.lblExampleDiameter.TabIndex = 5;
			this.lblExampleDiameter.Text = "17";
			this.lblExampleDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleAspect
			// 
			this.lblExampleAspect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExampleAspect.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExampleAspect.Location = new System.Drawing.Point(126, 23);
			this.lblExampleAspect.Name = "lblExampleAspect";
			this.lblExampleAspect.Size = new System.Drawing.Size(36, 23);
			this.lblExampleAspect.TabIndex = 3;
			this.lblExampleAspect.Text = "40";
			this.lblExampleAspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleSlash
			// 
			this.lblExampleSlash.Location = new System.Drawing.Point(114, 23);
			this.lblExampleSlash.Name = "lblExampleSlash";
			this.lblExampleSlash.Size = new System.Drawing.Size(12, 23);
			this.lblExampleSlash.TabIndex = 2;
			this.lblExampleSlash.Text = "/";
			this.lblExampleSlash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleDash
			// 
			this.lblExampleDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExampleDash.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExampleDash.Location = new System.Drawing.Point(162, 23);
			this.lblExampleDash.Name = "lblExampleDash";
			this.lblExampleDash.Size = new System.Drawing.Size(12, 23);
			this.lblExampleDash.TabIndex = 4;
			this.lblExampleDash.Text = "-";
			this.lblExampleDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExampleWidth
			// 
			this.lblExampleWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExampleWidth.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblExampleWidth.Location = new System.Drawing.Point(78, 23);
			this.lblExampleWidth.Name = "lblExampleWidth";
			this.lblExampleWidth.Size = new System.Drawing.Size(36, 23);
			this.lblExampleWidth.TabIndex = 1;
			this.lblExampleWidth.Text = "275";
			this.lblExampleWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblExample
			// 
			this.lblExample.Location = new System.Drawing.Point(6, 23);
			this.lblExample.Name = "lblExample";
			this.lblExample.Size = new System.Drawing.Size(66, 23);
			this.lblExample.TabIndex = 0;
			this.lblExample.Text = "(Example:";
			this.lblExample.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRimDiameter
			// 
			this.txtRimDiameter.Location = new System.Drawing.Point(108, 106);
			this.txtRimDiameter.Name = "txtRimDiameter";
			this.txtRimDiameter.Size = new System.Drawing.Size(60, 22);
			this.txtRimDiameter.TabIndex = 14;
			this.txtRimDiameter.TextChanged += new System.EventHandler(this.ValueChanged);
			this.txtRimDiameter.Enter += new System.EventHandler(this.txtRimDiameter_Enter);
			this.txtRimDiameter.Leave += new System.EventHandler(this.txtRimDiameter_Leave);
			// 
			// lblRimDiameter
			// 
			this.lblRimDiameter.Location = new System.Drawing.Point(12, 106);
			this.lblRimDiameter.Name = "lblRimDiameter";
			this.lblRimDiameter.Size = new System.Drawing.Size(90, 23);
			this.lblRimDiameter.TabIndex = 13;
			this.lblRimDiameter.Text = "Rim &diameter:";
			this.lblRimDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAspectRatio
			// 
			this.txtAspectRatio.Location = new System.Drawing.Point(108, 77);
			this.txtAspectRatio.Name = "txtAspectRatio";
			this.txtAspectRatio.Size = new System.Drawing.Size(60, 22);
			this.txtAspectRatio.TabIndex = 11;
			this.txtAspectRatio.TextChanged += new System.EventHandler(this.ValueChanged);
			this.txtAspectRatio.Enter += new System.EventHandler(this.txtAspectRatio_Enter);
			this.txtAspectRatio.Leave += new System.EventHandler(this.txtAspectRatio_Leave);
			// 
			// lblTireAspectRatio
			// 
			this.lblTireAspectRatio.Location = new System.Drawing.Point(12, 77);
			this.lblTireAspectRatio.Name = "lblTireAspectRatio";
			this.lblTireAspectRatio.Size = new System.Drawing.Size(90, 23);
			this.lblTireAspectRatio.TabIndex = 10;
			this.lblTireAspectRatio.Text = "Tire &aspect:";
			this.lblTireAspectRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTireWidth
			// 
			this.txtTireWidth.Location = new System.Drawing.Point(108, 48);
			this.txtTireWidth.Name = "txtTireWidth";
			this.txtTireWidth.Size = new System.Drawing.Size(60, 22);
			this.txtTireWidth.TabIndex = 8;
			this.txtTireWidth.TextChanged += new System.EventHandler(this.ValueChanged);
			this.txtTireWidth.Enter += new System.EventHandler(this.txtTireWidth_Enter);
			this.txtTireWidth.Leave += new System.EventHandler(this.txtTireWidth_Leave);
			// 
			// lblTireWidth
			// 
			this.lblTireWidth.Location = new System.Drawing.Point(12, 48);
			this.lblTireWidth.Name = "lblTireWidth";
			this.lblTireWidth.Size = new System.Drawing.Size(90, 24);
			this.lblTireWidth.TabIndex = 7;
			this.lblTireWidth.Text = "Tire &width:";
			this.lblTireWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupDrivetrain
			// 
			this.groupDrivetrain.Controls.Add(this.radioManual);
			this.groupDrivetrain.Controls.Add(this.radioAutomatic);
			this.groupDrivetrain.Location = new System.Drawing.Point(12, 132);
			this.groupDrivetrain.Name = "groupDrivetrain";
			this.groupDrivetrain.Size = new System.Drawing.Size(246, 64);
			this.groupDrivetrain.TabIndex = 3;
			this.groupDrivetrain.TabStop = false;
			this.groupDrivetrain.Text = "Transmission";
			// 
			// radioManual
			// 
			this.radioManual.Checked = true;
			this.radioManual.Location = new System.Drawing.Point(139, 23);
			this.radioManual.Name = "radioManual";
			this.radioManual.Size = new System.Drawing.Size(90, 23);
			this.radioManual.TabIndex = 1;
			this.radioManual.TabStop = true;
			this.radioManual.Text = "&Manual";
			this.radioManual.CheckedChanged += new System.EventHandler(this.ValueChanged);
			// 
			// radioAutomatic
			// 
			this.radioAutomatic.Location = new System.Drawing.Point(18, 23);
			this.radioAutomatic.Name = "radioAutomatic";
			this.radioAutomatic.Size = new System.Drawing.Size(90, 23);
			this.radioAutomatic.TabIndex = 0;
			this.radioAutomatic.Text = "&Automatic";
			this.radioAutomatic.CheckedChanged += new System.EventHandler(this.ValueChanged);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(72, 23);
			this.txtName.MaxLength = 20;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(420, 22);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.ValueChanged);
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(6, 23);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(60, 23);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name:";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(595, 443);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(90, 29);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = "D&one";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// VehicleForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(713, 482);
			this.Controls.Add(this.groupProfile);
			this.Controls.Add(this.groupVehicles);
			this.Controls.Add(this.btnExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VehicleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Vehicle Profile Manager";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.VehicleForm_Closing);
			this.Load += new System.EventHandler(this.VehicleForm_Load);
			this.groupVehicles.ResumeLayout(false);
			this.groupProfile.ResumeLayout(false);
			this.groupProfile.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupTimeout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
			this.groupNotes.ResumeLayout(false);
			this.groupNotes.PerformLayout();
			this.groupMisc.ResumeLayout(false);
			this.groupMisc.PerformLayout();
			this.groupWheels.ResumeLayout(false);
			this.groupWheels.PerformLayout();
			this.groupDrivetrain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
