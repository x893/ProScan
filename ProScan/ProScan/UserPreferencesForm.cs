using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class UserPreferencesForm : Form
	{
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
		private UserPreferences m_userpreferences;
		private Container components;

		public UserPreferencesForm(UserPreferences prefs)
		{
			InitializeComponent();
			m_userpreferences = prefs;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			groupCompany = new System.Windows.Forms.GroupBox();
			txtTelephone = new System.Windows.Forms.TextBox();
			txtAddress2 = new System.Windows.Forms.TextBox();
			txtAddress1 = new System.Windows.Forms.TextBox();
			txtName = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			btnSave = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupCompany.SuspendLayout();
			SuspendLayout();
			// 
			// groupCompany
			// 
			groupCompany.Controls.Add(txtTelephone);
			groupCompany.Controls.Add(txtAddress2);
			groupCompany.Controls.Add(txtAddress1);
			groupCompany.Controls.Add(txtName);
			groupCompany.Controls.Add(label3);
			groupCompany.Controls.Add(label2);
			groupCompany.Controls.Add(label1);
			groupCompany.Location = new System.Drawing.Point(10, 10);
			groupCompany.Name = "groupCompany";
			groupCompany.Size = new System.Drawing.Size(270, 134);
			groupCompany.TabIndex = 0;
			groupCompany.TabStop = false;
			groupCompany.Text = "Company Details";
			// 
			// txtTelephone
			// 
			txtTelephone.Location = new System.Drawing.Point(100, 96);
			txtTelephone.Name = "txtTelephone";
			txtTelephone.Size = new System.Drawing.Size(150, 20);
			txtTelephone.TabIndex = 6;
			// 
			// txtAddress2
			// 
			txtAddress2.Location = new System.Drawing.Point(100, 72);
			txtAddress2.Name = "txtAddress2";
			txtAddress2.Size = new System.Drawing.Size(150, 20);
			txtAddress2.TabIndex = 4;
			// 
			// txtAddress1
			// 
			txtAddress1.Location = new System.Drawing.Point(100, 48);
			txtAddress1.Name = "txtAddress1";
			txtAddress1.Size = new System.Drawing.Size(150, 20);
			txtAddress1.TabIndex = 3;
			// 
			// txtName
			// 
			txtName.Location = new System.Drawing.Point(100, 24);
			txtName.Name = "txtName";
			txtName.Size = new System.Drawing.Size(150, 20);
			txtName.TabIndex = 1;
			// 
			// label3
			// 
			label3.Location = new System.Drawing.Point(15, 96);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(75, 20);
			label3.TabIndex = 5;
			label3.Text = "&Telephone:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(15, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(75, 20);
			label2.TabIndex = 2;
			label2.Text = "&Address:";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(15, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 20);
			label1.TabIndex = 0;
			label1.Text = "&Name:";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSave
			// 
			btnSave.Location = new System.Drawing.Point(65, 152);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 23);
			btnSave.TabIndex = 1;
			btnSave.Text = "&Save";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(153, 152);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "&Cancel";
			// 
			// UserPreferencesForm
			// 
			AcceptButton = btnSave;
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(292, 182);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(groupCompany);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "UserPreferencesForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "User Preferences";
			Load += new System.EventHandler(UserPreferencesForm_Load);
			groupCompany.ResumeLayout(false);
			groupCompany.PerformLayout();
			ResumeLayout(false);

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
	}
}