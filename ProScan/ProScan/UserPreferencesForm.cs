using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class UserPreferencesForm : Form
	{
		private UserPreferences m_userpreferences;

		public UserPreferencesForm(UserPreferences prefs)
		{
			InitializeComponent();
			m_userpreferences = prefs;
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			m_userpreferences.Name = txtName.Text;
			m_userpreferences.Address1 = txtAddress1.Text;
			m_userpreferences.Address2 = txtAddress2.Text;
			m_userpreferences.Telephone = txtTelephone.Text;
			Close();
		}

		private void UserPreferencesForm_Load(object sender, EventArgs e)
		{
			txtName.Text = m_userpreferences.Name;
			txtAddress1.Text = m_userpreferences.Address1;
			txtAddress2.Text = m_userpreferences.Address2;
			txtTelephone.Text = m_userpreferences.Telephone;
		}

		#region InitializeComponent
		private GroupBox groupCompany;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox txtName;
		private TextBox txtAddress1;
		private TextBox txtAddress2;
		private TextBox txtTelephone;
		private Button btnSave;
		private Button btnCancel;

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupCompany = new System.Windows.Forms.GroupBox();
			this.txtTelephone = new System.Windows.Forms.TextBox();
			this.txtAddress2 = new System.Windows.Forms.TextBox();
			this.txtAddress1 = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupCompany.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupCompany
			// 
			this.groupCompany.Controls.Add(this.txtTelephone);
			this.groupCompany.Controls.Add(this.txtAddress2);
			this.groupCompany.Controls.Add(this.txtAddress1);
			this.groupCompany.Controls.Add(this.txtName);
			this.groupCompany.Controls.Add(this.label3);
			this.groupCompany.Controls.Add(this.label2);
			this.groupCompany.Controls.Add(this.label1);
			this.groupCompany.Location = new System.Drawing.Point(12, 12);
			this.groupCompany.Name = "groupCompany";
			this.groupCompany.Size = new System.Drawing.Size(324, 154);
			this.groupCompany.TabIndex = 0;
			this.groupCompany.TabStop = false;
			this.groupCompany.Text = "Company Details";
			// 
			// txtTelephone
			// 
			this.txtTelephone.Location = new System.Drawing.Point(120, 111);
			this.txtTelephone.Name = "txtTelephone";
			this.txtTelephone.Size = new System.Drawing.Size(180, 22);
			this.txtTelephone.TabIndex = 6;
			// 
			// txtAddress2
			// 
			this.txtAddress2.Location = new System.Drawing.Point(120, 83);
			this.txtAddress2.Name = "txtAddress2";
			this.txtAddress2.Size = new System.Drawing.Size(180, 22);
			this.txtAddress2.TabIndex = 4;
			// 
			// txtAddress1
			// 
			this.txtAddress1.Location = new System.Drawing.Point(120, 55);
			this.txtAddress1.Name = "txtAddress1";
			this.txtAddress1.Size = new System.Drawing.Size(180, 22);
			this.txtAddress1.TabIndex = 3;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(120, 28);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(180, 22);
			this.txtName.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "&Telephone:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Address:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(78, 175);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 27);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(184, 175);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 27);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Cancel";
			// 
			// UserPreferencesForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(350, 214);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.groupCompany);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UserPreferencesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "User Preferences";
			this.Load += new System.EventHandler(this.UserPreferencesForm_Load);
			this.groupCompany.ResumeLayout(false);
			this.groupCompany.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
	}
}