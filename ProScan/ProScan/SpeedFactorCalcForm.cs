using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class SpeedFactorCalcForm : Form
	{
		private GroupBox groupWheels;
		private Label lblRimDiameterUnits;
		private Label lblTireAspectUnits;
		private Label lblTireWidthUnits;
		private Label lblRimDiameter;
		private Label lblTireAspectRatio;
		private Label lblTireWidth;
		private GroupBox groupBox1;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label lblFactor;
		private TextBox txtStockRimDiameter;
		private TextBox txtStockAspectRatio;
		private TextBox txtStockTireWidth;
		private TextBox txtCurrentRimDiameter;
		private TextBox txtCurrentAspectRatio;
		private TextBox txtCurrentTireWidth;
		private Button btnSave;
		private Button btnCancel;
		private float m_fFactor;
		private TextBox txtFactor;
		private Container components;

		public SpeedFactorCalcForm()
		{
			InitializeComponent();
			CalculateFactor();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			groupWheels = new System.Windows.Forms.GroupBox();
			lblRimDiameterUnits = new System.Windows.Forms.Label();
			lblTireAspectUnits = new System.Windows.Forms.Label();
			lblTireWidthUnits = new System.Windows.Forms.Label();
			txtStockRimDiameter = new System.Windows.Forms.TextBox();
			lblRimDiameter = new System.Windows.Forms.Label();
			txtStockAspectRatio = new System.Windows.Forms.TextBox();
			lblTireAspectRatio = new System.Windows.Forms.Label();
			txtStockTireWidth = new System.Windows.Forms.TextBox();
			lblTireWidth = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			txtCurrentRimDiameter = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			txtCurrentAspectRatio = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			txtCurrentTireWidth = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			lblFactor = new System.Windows.Forms.Label();
			txtFactor = new System.Windows.Forms.TextBox();
			btnSave = new System.Windows.Forms.Button();
			btnCancel = new System.Windows.Forms.Button();
			groupWheels.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupWheels
			// 
			groupWheels.Controls.Add(lblRimDiameterUnits);
			groupWheels.Controls.Add(lblTireAspectUnits);
			groupWheels.Controls.Add(lblTireWidthUnits);
			groupWheels.Controls.Add(txtStockRimDiameter);
			groupWheels.Controls.Add(lblRimDiameter);
			groupWheels.Controls.Add(txtStockAspectRatio);
			groupWheels.Controls.Add(lblTireAspectRatio);
			groupWheels.Controls.Add(txtStockTireWidth);
			groupWheels.Controls.Add(lblTireWidth);
			groupWheels.Location = new System.Drawing.Point(8, 8);
			groupWheels.Name = "groupWheels";
			groupWheels.Size = new System.Drawing.Size(185, 104);
			groupWheels.TabIndex = 5;
			groupWheels.TabStop = false;
			groupWheels.Text = "Stock Tire Size";
			// 
			// lblRimDiameterUnits
			// 
			lblRimDiameterUnits.Location = new System.Drawing.Point(145, 72);
			lblRimDiameterUnits.Name = "lblRimDiameterUnits";
			lblRimDiameterUnits.Size = new System.Drawing.Size(30, 20);
			lblRimDiameterUnits.TabIndex = 15;
			lblRimDiameterUnits.Text = "in";
			lblRimDiameterUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireAspectUnits
			// 
			lblTireAspectUnits.Location = new System.Drawing.Point(145, 48);
			lblTireAspectUnits.Name = "lblTireAspectUnits";
			lblTireAspectUnits.Size = new System.Drawing.Size(30, 20);
			lblTireAspectUnits.TabIndex = 12;
			lblTireAspectUnits.Text = "%";
			lblTireAspectUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireWidthUnits
			// 
			lblTireWidthUnits.Location = new System.Drawing.Point(145, 24);
			lblTireWidthUnits.Name = "lblTireWidthUnits";
			lblTireWidthUnits.Size = new System.Drawing.Size(30, 20);
			lblTireWidthUnits.TabIndex = 9;
			lblTireWidthUnits.Text = "mm";
			lblTireWidthUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtStockRimDiameter
			// 
			txtStockRimDiameter.Location = new System.Drawing.Point(90, 72);
			txtStockRimDiameter.Name = "txtStockRimDiameter";
			txtStockRimDiameter.Size = new System.Drawing.Size(50, 20);
			txtStockRimDiameter.TabIndex = 14;
			txtStockRimDiameter.TextChanged += new System.EventHandler(TextChanged);
			// 
			// lblRimDiameter
			// 
			lblRimDiameter.Location = new System.Drawing.Point(10, 72);
			lblRimDiameter.Name = "lblRimDiameter";
			lblRimDiameter.Size = new System.Drawing.Size(75, 20);
			lblRimDiameter.TabIndex = 13;
			lblRimDiameter.Text = "Rim &diameter:";
			lblRimDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStockAspectRatio
			// 
			txtStockAspectRatio.Location = new System.Drawing.Point(90, 48);
			txtStockAspectRatio.Name = "txtStockAspectRatio";
			txtStockAspectRatio.Size = new System.Drawing.Size(50, 20);
			txtStockAspectRatio.TabIndex = 11;
			txtStockAspectRatio.TextChanged += new System.EventHandler(TextChanged);
			// 
			// lblTireAspectRatio
			// 
			lblTireAspectRatio.Location = new System.Drawing.Point(10, 48);
			lblTireAspectRatio.Name = "lblTireAspectRatio";
			lblTireAspectRatio.Size = new System.Drawing.Size(75, 20);
			lblTireAspectRatio.TabIndex = 10;
			lblTireAspectRatio.Text = "Tire &aspect:";
			lblTireAspectRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStockTireWidth
			// 
			txtStockTireWidth.Location = new System.Drawing.Point(90, 24);
			txtStockTireWidth.Name = "txtStockTireWidth";
			txtStockTireWidth.Size = new System.Drawing.Size(50, 20);
			txtStockTireWidth.TabIndex = 8;
			txtStockTireWidth.TextChanged += new System.EventHandler(TextChanged);
			// 
			// lblTireWidth
			// 
			lblTireWidth.Location = new System.Drawing.Point(10, 24);
			lblTireWidth.Name = "lblTireWidth";
			lblTireWidth.Size = new System.Drawing.Size(75, 20);
			lblTireWidth.TabIndex = 7;
			lblTireWidth.Text = "Tire &width:";
			lblTireWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(txtCurrentRimDiameter);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(txtCurrentAspectRatio);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(txtCurrentTireWidth);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new System.Drawing.Point(200, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(185, 104);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Current Tire Size";
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(145, 72);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(30, 20);
			label1.TabIndex = 15;
			label1.Text = "in";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(145, 48);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(30, 20);
			label2.TabIndex = 12;
			label2.Text = "%";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			label3.Location = new System.Drawing.Point(145, 24);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(30, 20);
			label3.TabIndex = 9;
			label3.Text = "mm";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCurrentRimDiameter
			// 
			txtCurrentRimDiameter.Location = new System.Drawing.Point(90, 72);
			txtCurrentRimDiameter.Name = "txtCurrentRimDiameter";
			txtCurrentRimDiameter.Size = new System.Drawing.Size(50, 20);
			txtCurrentRimDiameter.TabIndex = 14;
			txtCurrentRimDiameter.TextChanged += new System.EventHandler(TextChanged);
			// 
			// label4
			// 
			label4.Location = new System.Drawing.Point(10, 72);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(75, 20);
			label4.TabIndex = 13;
			label4.Text = "Rim &diameter:";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCurrentAspectRatio
			// 
			txtCurrentAspectRatio.Location = new System.Drawing.Point(90, 48);
			txtCurrentAspectRatio.Name = "txtCurrentAspectRatio";
			txtCurrentAspectRatio.Size = new System.Drawing.Size(50, 20);
			txtCurrentAspectRatio.TabIndex = 11;
			txtCurrentAspectRatio.TextChanged += new System.EventHandler(TextChanged);
			// 
			// label5
			// 
			label5.Location = new System.Drawing.Point(10, 48);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(75, 20);
			label5.TabIndex = 10;
			label5.Text = "Tire &aspect:";
			label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCurrentTireWidth
			// 
			txtCurrentTireWidth.Location = new System.Drawing.Point(90, 24);
			txtCurrentTireWidth.Name = "txtCurrentTireWidth";
			txtCurrentTireWidth.Size = new System.Drawing.Size(50, 20);
			txtCurrentTireWidth.TabIndex = 8;
			txtCurrentTireWidth.TextChanged += new System.EventHandler(TextChanged);
			// 
			// label6
			// 
			label6.Location = new System.Drawing.Point(10, 24);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(75, 20);
			label6.TabIndex = 7;
			label6.Text = "Tire &width:";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblFactor
			// 
			lblFactor.Location = new System.Drawing.Point(15, 122);
			lblFactor.Name = "lblFactor";
			lblFactor.Size = new System.Drawing.Size(233, 16);
			lblFactor.TabIndex = 7;
			lblFactor.Text = "Calculated Speedometer Calibration Factor:";
			lblFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFactor
			// 
			txtFactor.Location = new System.Drawing.Point(257, 120);
			txtFactor.Name = "txtFactor";
			txtFactor.ReadOnly = true;
			txtFactor.Size = new System.Drawing.Size(100, 20);
			txtFactor.TabIndex = 8;
			txtFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnSave
			// 
			btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			btnSave.Enabled = false;
			btnSave.Location = new System.Drawing.Point(112, 152);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 23);
			btnSave.TabIndex = 9;
			btnSave.Text = "&Save";
			// 
			// btnCancel
			// 
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(208, 152);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 10;
			btnCancel.Text = "&Cancel";
			// 
			// SpeedFactorCalcForm
			// 
			AcceptButton = btnSave;
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			CancelButton = btnCancel;
			ClientSize = new System.Drawing.Size(392, 182);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(txtFactor);
			Controls.Add(lblFactor);
			Controls.Add(groupBox1);
			Controls.Add(groupWheels);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SpeedFactorCalcForm";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Calculate Speedometer Calibration Factor";
			groupWheels.ResumeLayout(false);
			groupWheels.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();

		}

		private new void TextChanged(object sender, EventArgs e)
		{
			CalculateFactor();
		}

		private void CalculateFactor()
		{
			try
			{
				float num7 = (float)(
					(double)Convert.ToSingle(txtStockAspectRatio.Text) * 0.00999999977648258 * (double)Convert.ToSingle(txtStockTireWidth.Text) * 0.508000016212463
					) + Convert.ToSingle(txtStockRimDiameter.Text);
				m_fFactor = ((float)(
					(double)Convert.ToSingle(txtCurrentAspectRatio.Text) * 0.00999999977648258 * (double)Convert.ToSingle(txtCurrentTireWidth.Text) * 0.508000016212463
					) + Convert.ToSingle(txtCurrentRimDiameter.Text)) / num7;
				txtFactor.Text = m_fFactor.ToString("0.000");
				btnSave.Enabled = true;
			}
			catch (FormatException)
			{
				txtFactor.Text = "ERROR";
				btnSave.Enabled = false;
			}
		}

		public float getSpeedFactor()
		{
			return m_fFactor;
		}
	}
}
