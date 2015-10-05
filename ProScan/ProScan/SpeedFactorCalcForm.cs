using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class SpeedFactorCalcForm : Form
	{
		private float m_fFactor;

		public SpeedFactorCalcForm()
		{
			InitializeComponent();
			CalculateFactor();
		}

		private new void TextChanged(object sender, EventArgs e)
		{
			CalculateFactor();
		}

		private void CalculateFactor()
		{
			try
			{
				float factor = (float)(
					Convert.ToDouble(txtStockAspectRatio.Text, CultureInfo.InvariantCulture)
					* 0.00999999977648258
					* Convert.ToDouble(txtStockTireWidth.Text, CultureInfo.InvariantCulture)
					* 0.508000016212463
					) + Convert.ToSingle(txtStockRimDiameter.Text);
				m_fFactor = (	(float)(
						Convert.ToDouble(txtCurrentAspectRatio.Text, CultureInfo.InvariantCulture)
						* 0.00999999977648258
						* Convert.ToDouble(txtCurrentTireWidth.Text, CultureInfo.InvariantCulture)
						* 0.508000016212463
						)
						+ Convert.ToSingle(txtCurrentRimDiameter.Text, CultureInfo.InvariantCulture)
					)
					/ factor;
				txtFactor.Text = m_fFactor.ToString("0.000");
				btnSave.Enabled = true;
			}
			catch (FormatException)
			{
				txtFactor.Text = "ERROR";
				btnSave.Enabled = false;
			}
		}

		public float SpeedFactor
		{
			get { return m_fFactor; }
		}

		#region InitializeComponent
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.groupWheels = new System.Windows.Forms.GroupBox();
			this.lblRimDiameterUnits = new System.Windows.Forms.Label();
			this.lblTireAspectUnits = new System.Windows.Forms.Label();
			this.lblTireWidthUnits = new System.Windows.Forms.Label();
			this.txtStockRimDiameter = new System.Windows.Forms.TextBox();
			this.lblRimDiameter = new System.Windows.Forms.Label();
			this.txtStockAspectRatio = new System.Windows.Forms.TextBox();
			this.lblTireAspectRatio = new System.Windows.Forms.Label();
			this.txtStockTireWidth = new System.Windows.Forms.TextBox();
			this.lblTireWidth = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCurrentRimDiameter = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCurrentAspectRatio = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCurrentTireWidth = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lblFactor = new System.Windows.Forms.Label();
			this.txtFactor = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupWheels.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupWheels
			// 
			this.groupWheels.Controls.Add(this.lblRimDiameterUnits);
			this.groupWheels.Controls.Add(this.lblTireAspectUnits);
			this.groupWheels.Controls.Add(this.lblTireWidthUnits);
			this.groupWheels.Controls.Add(this.txtStockRimDiameter);
			this.groupWheels.Controls.Add(this.lblRimDiameter);
			this.groupWheels.Controls.Add(this.txtStockAspectRatio);
			this.groupWheels.Controls.Add(this.lblTireAspectRatio);
			this.groupWheels.Controls.Add(this.txtStockTireWidth);
			this.groupWheels.Controls.Add(this.lblTireWidth);
			this.groupWheels.Location = new System.Drawing.Point(10, 9);
			this.groupWheels.Name = "groupWheels";
			this.groupWheels.Size = new System.Drawing.Size(222, 120);
			this.groupWheels.TabIndex = 5;
			this.groupWheels.TabStop = false;
			this.groupWheels.Text = "Stock Tire Size";
			// 
			// lblRimDiameterUnits
			// 
			this.lblRimDiameterUnits.Location = new System.Drawing.Point(174, 83);
			this.lblRimDiameterUnits.Name = "lblRimDiameterUnits";
			this.lblRimDiameterUnits.Size = new System.Drawing.Size(36, 23);
			this.lblRimDiameterUnits.TabIndex = 15;
			this.lblRimDiameterUnits.Text = "in";
			this.lblRimDiameterUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireAspectUnits
			// 
			this.lblTireAspectUnits.Location = new System.Drawing.Point(174, 55);
			this.lblTireAspectUnits.Name = "lblTireAspectUnits";
			this.lblTireAspectUnits.Size = new System.Drawing.Size(36, 23);
			this.lblTireAspectUnits.TabIndex = 12;
			this.lblTireAspectUnits.Text = "%";
			this.lblTireAspectUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTireWidthUnits
			// 
			this.lblTireWidthUnits.Location = new System.Drawing.Point(174, 28);
			this.lblTireWidthUnits.Name = "lblTireWidthUnits";
			this.lblTireWidthUnits.Size = new System.Drawing.Size(36, 23);
			this.lblTireWidthUnits.TabIndex = 9;
			this.lblTireWidthUnits.Text = "mm";
			this.lblTireWidthUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtStockRimDiameter
			// 
			this.txtStockRimDiameter.Location = new System.Drawing.Point(108, 83);
			this.txtStockRimDiameter.Name = "txtStockRimDiameter";
			this.txtStockRimDiameter.Size = new System.Drawing.Size(60, 22);
			this.txtStockRimDiameter.TabIndex = 14;
			this.txtStockRimDiameter.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// lblRimDiameter
			// 
			this.lblRimDiameter.Location = new System.Drawing.Point(12, 83);
			this.lblRimDiameter.Name = "lblRimDiameter";
			this.lblRimDiameter.Size = new System.Drawing.Size(90, 23);
			this.lblRimDiameter.TabIndex = 13;
			this.lblRimDiameter.Text = "Rim &diameter:";
			this.lblRimDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStockAspectRatio
			// 
			this.txtStockAspectRatio.Location = new System.Drawing.Point(108, 55);
			this.txtStockAspectRatio.Name = "txtStockAspectRatio";
			this.txtStockAspectRatio.Size = new System.Drawing.Size(60, 22);
			this.txtStockAspectRatio.TabIndex = 11;
			this.txtStockAspectRatio.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// lblTireAspectRatio
			// 
			this.lblTireAspectRatio.Location = new System.Drawing.Point(12, 55);
			this.lblTireAspectRatio.Name = "lblTireAspectRatio";
			this.lblTireAspectRatio.Size = new System.Drawing.Size(90, 23);
			this.lblTireAspectRatio.TabIndex = 10;
			this.lblTireAspectRatio.Text = "Tire &aspect:";
			this.lblTireAspectRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtStockTireWidth
			// 
			this.txtStockTireWidth.Location = new System.Drawing.Point(108, 28);
			this.txtStockTireWidth.Name = "txtStockTireWidth";
			this.txtStockTireWidth.Size = new System.Drawing.Size(60, 22);
			this.txtStockTireWidth.TabIndex = 8;
			this.txtStockTireWidth.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// lblTireWidth
			// 
			this.lblTireWidth.Location = new System.Drawing.Point(12, 28);
			this.lblTireWidth.Name = "lblTireWidth";
			this.lblTireWidth.Size = new System.Drawing.Size(90, 23);
			this.lblTireWidth.TabIndex = 7;
			this.lblTireWidth.Text = "Tire &width:";
			this.lblTireWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtCurrentRimDiameter);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtCurrentAspectRatio);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtCurrentTireWidth);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(240, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(222, 120);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current Tire Size";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(174, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 23);
			this.label1.TabIndex = 15;
			this.label1.Text = "in";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(174, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "%";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(174, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "mm";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCurrentRimDiameter
			// 
			this.txtCurrentRimDiameter.Location = new System.Drawing.Point(108, 83);
			this.txtCurrentRimDiameter.Name = "txtCurrentRimDiameter";
			this.txtCurrentRimDiameter.Size = new System.Drawing.Size(60, 22);
			this.txtCurrentRimDiameter.TabIndex = 14;
			this.txtCurrentRimDiameter.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 23);
			this.label4.TabIndex = 13;
			this.label4.Text = "Rim &diameter:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCurrentAspectRatio
			// 
			this.txtCurrentAspectRatio.Location = new System.Drawing.Point(108, 55);
			this.txtCurrentAspectRatio.Name = "txtCurrentAspectRatio";
			this.txtCurrentAspectRatio.Size = new System.Drawing.Size(60, 22);
			this.txtCurrentAspectRatio.TabIndex = 11;
			this.txtCurrentAspectRatio.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "Tire &aspect:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCurrentTireWidth
			// 
			this.txtCurrentTireWidth.Location = new System.Drawing.Point(108, 28);
			this.txtCurrentTireWidth.Name = "txtCurrentTireWidth";
			this.txtCurrentTireWidth.Size = new System.Drawing.Size(60, 22);
			this.txtCurrentTireWidth.TabIndex = 8;
			this.txtCurrentTireWidth.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 23);
			this.label6.TabIndex = 7;
			this.label6.Text = "Tire &width:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblFactor
			// 
			this.lblFactor.Location = new System.Drawing.Point(18, 141);
			this.lblFactor.Name = "lblFactor";
			this.lblFactor.Size = new System.Drawing.Size(280, 18);
			this.lblFactor.TabIndex = 7;
			this.lblFactor.Text = "Calculated Speedometer Calibration Factor:";
			this.lblFactor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFactor
			// 
			this.txtFactor.Location = new System.Drawing.Point(308, 138);
			this.txtFactor.Name = "txtFactor";
			this.txtFactor.ReadOnly = true;
			this.txtFactor.Size = new System.Drawing.Size(120, 22);
			this.txtFactor.TabIndex = 8;
			this.txtFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(134, 175);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 27);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "&Save";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(250, 175);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 27);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "&Cancel";
			// 
			// SpeedFactorCalcForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(472, 213);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtFactor);
			this.Controls.Add(this.lblFactor);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupWheels);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SpeedFactorCalcForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Calculate Speedometer Calibration Factor";
			this.groupWheels.ResumeLayout(false);
			this.groupWheels.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

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
		private TextBox txtFactor;

		#endregion
	}
}
