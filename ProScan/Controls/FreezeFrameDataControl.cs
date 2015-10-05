using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class FreezeFrameDataControl : UserControl
	{
		private Label lblPIDHeader;
		private Label lblDescriptionHeader;
		private Label lblEnglishValueHeader;
		private Label lblEnglishUnitsHeader;
		private Label lblMetricValueHeader;
		private Label lblMetricUnitsHeader;
		private Label lblMetricUnits02;
		private Label lblMetricValue02;
		private Label lblEnglishUnits02;
		private Label lblEnglishValue02;
		private Label lblDescription02;
		private Label lblPID02;
		private Label lblMetricUnits05;
		private Label lblMetricValue05;
		private Label lblEnglishUnits05;
		private Label lblEnglishValue05;
		private Label lblDescription05;
		private Label lblPID05;
		private Label lblMetricUnits04;
		private Label lblMetricValue04;
		private Label lblEnglishUnits04;
		private Label lblEnglishValue04;
		private Label lblDescription04;
		private Label lblPID04;
		private Label lblMetricUnits0E;
		private Label lblMetricValue0E;
		private Label lblEnglishUnits0E;
		private Label lblEnglishValue0E;
		private Label lblDescription0E;
		private Label lblPID0E;
		private Label lblMetricUnits0D;
		private Label lblMetricValue0D;
		private Label lblEnglishUnits0D;
		private Label lblEnglishValue0D;
		private Label lblDescription0D;
		private Label lblPID0D;
		private Label lblMetricUnits0C;
		private Label lblMetricValue0C;
		private Label lblEnglishUnits0C;
		private Label lblEnglishValue0C;
		private Label lblDescription0C;
		private Label lblPID0C;
		private Label lblMetricUnits0B;
		private Label lblMetricValue0B;
		private Label lblEnglishUnits0B;
		private Label lblEnglishValue0B;
		private Label lblDescription0B;
		private Label lblPID0B;
		private Label lblMetricUnits03a;
		private Label lblMetricValue03a;
		private Label lblEnglishUnits03a;
		private Label lblEnglishValue03a;
		private Label lblDescription03a;
		private Label lblPID03a;
		private Label lblMetricUnits09a;
		private Label lblMetricValue09a;
		private Label lblEnglishUnits09a;
		private Label lblEnglishValue09a;
		private Label lblDescription09a;
		private Label lblPID09a;
		private Label lblMetricUnits08a;
		private Label lblMetricValue08a;
		private Label lblEnglishUnits08a;
		private Label lblEnglishValue08a;
		private Label lblDescription08a;
		private Label lblPID08a;
		private Label lblMetricUnits07a;
		private Label lblMetricValue07a;
		private Label lblEnglishUnits07a;
		private Label lblEnglishValue07a;
		private Label lblDescription07a;
		private Label lblPID07a;
		private Label lblMetricUnits06a;
		private Label lblMetricValue06a;
		private Label lblEnglishUnits06a;
		private Label lblEnglishValue06a;
		private Label lblDescription06a;
		private Label lblPID06a;
		private Label lblMetricUnits03b;
		private Label lblMetricValue03b;
		private Label lblEnglishUnits03b;
		private Label lblEnglishValue03b;
		private Label lblDescription03b;
		private Label lblPID03b;
		private Label lblMetricUnits09b;
		private Label lblMetricValue09b;
		private Label lblEnglishUnits09b;
		private Label lblEnglishValue09b;
		private Label lblDescription09b;
		private Label lblPID09b;
		private Label lblMetricUnits08b;
		private Label lblMetricValue08b;
		private Label lblEnglishUnits08b;
		private Label lblEnglishValue08b;
		private Label lblDescription08b;
		private Label lblPID08b;
		private Label lblMetricUnits07b;
		private Label lblMetricValue07b;
		private Label lblEnglishUnits07b;
		private Label lblEnglishValue07b;
		private Label lblDescription07b;
		private Label lblPID07b;
		private Label lblMetricUnits06b;
		private Label lblMetricValue06b;
		private Label lblEnglishUnits06b;
		private Label lblEnglishValue06b;
		private Label lblDescription06b;
		private Label lblPID06b;

		[Description("Ignition Timing Advance (deg)")]
		[Category("FreezeFrame")]
		public double SparkAdvance
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue0E.Text);
			}
			set
			{
				lblEnglishValue0E.Text = value.ToString("##0.##");
				lblMetricValue0E.Text = value.ToString("##0.##");
			}
		}

		[Description("Vehicle Speed (mph)")]
		[Category("FreezeFrame")]
		public double VehicleSpeed
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue0D.Text);
			}
			set
			{
				lblEnglishValue0D.Text = value.ToString("##0.##");
				lblMetricValue0D.Text = (VehicleSpeed * 1.609344).ToString("##0.##");
			}
		}

		[Description("Engine RPM (rev/min)")]
		[Category("FreezeFrame")]
		public double EngineRPM
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue0C.Text);
			}
			set
			{
				lblEnglishValue0C.Text = value.ToString("##0.##");
				lblMetricValue0C.Text = value.ToString("##0.##");
			}
		}

		[Description("Intake Manifold Pressure (inHg)")]
		[Category("FreezeFrame")]
		public double IntakePressure
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue0B.Text);
			}
			set
			{
				lblEnglishValue0B.Text = value.ToString("##0.##");
				lblMetricValue0B.Text = (IntakePressure * 3.38639).ToString("##0.##");
			}
		}

		[Description("Long Term Fuel Trim - Bank 4 (%)")]
		[Category("FreezeFrame")]
		public double LTFT4
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue09b.Text);
			}
			set
			{
				lblEnglishValue09b.Text = value.ToString("##0.##");
				lblMetricValue09b.Text = value.ToString("##0.##");
			}
		}

		[Category("FreezeFrame")]
		[Description("Long Term Fuel Trim - Bank 3 (%)")]
		public double LTFT3
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue07b.Text);
			}
			set
			{
				lblEnglishValue07b.Text = value.ToString("##0.##");
				lblMetricValue07b.Text = value.ToString("##0.##");
			}
		}

		[Category("FreezeFrame")]
		[Description("Long Term Fuel Trim - Bank 2 (%)")]
		public double LTFT2
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue09a.Text);
			}
			set
			{
				lblEnglishValue09a.Text = value.ToString("##0.##");
				lblMetricValue09a.Text = value.ToString("##0.##");
			}
		}

		[Category("FreezeFrame")]
		[Description("Long Term Fuel Trim - Bank 1 (%)")]
		public double LTFT1
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue07a.Text);
			}
			set
			{
				lblEnglishValue07a.Text = value.ToString("##0.##");
				lblMetricValue07a.Text = value.ToString("##0.##");
			}
		}

		[Description("Short Term Fuel Trim - Bank 4 (%)")]
		[Category("FreezeFrame")]
		public double STFT4
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue08b.Text);
			}
			set
			{
				lblEnglishValue08b.Text = value.ToString("##0.##");
				lblMetricValue08b.Text = value.ToString("##0.##");
			}
		}

		[Category("FreezeFrame")]
		[Description("Short Term Fuel Trim - Bank 3 (%)")]
		public double STFT3
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue06b.Text);
			}
			set
			{
				lblEnglishValue06b.Text = value.ToString("##0.##");
				lblMetricValue06b.Text = value.ToString("##0.##");
			}
		}

		[Category("FreezeFrame")]
		[Description("Short Term Fuel Trim - Bank 2 (%)")]
		public double STFT2
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue08a.Text);
			}
			set
			{
				lblEnglishValue08a.Text = value.ToString("##0.##");
				lblMetricValue08a.Text = value.ToString("##0.##");
			}
		}

		[Description("Short Term Fuel Trim - Bank 1 (%)")]
		[Category("FreezeFrame")]
		public double STFT1
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue06a.Text);
			}
			set
			{
				lblEnglishValue06a.Text = value.ToString("##0.##");
				lblMetricValue06a.Text = value.ToString("##0.##");
			}
		}

		[Description("Engine Coolant Temperature (Fahrenheit)")]
		[Category("FreezeFrame")]
		public double EngineCoolantTemp
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue05.Text);
			}
			set
			{
				lblEnglishValue05.Text = value.ToString("##0.##");
				lblMetricValue05.Text = ((EngineCoolantTemp - 32.0) * 0.55555555555555558).ToString("##0.##");
			}
		}

		[Description("Calculated Load Value (%)")]
		[Category("FreezeFrame")]
		public double CalculatedLoad
		{
			get
			{
				return Utility.Text2Double(lblEnglishValue04.Text);
			}
			set
			{
				lblEnglishValue04.Text = value.ToString("##0.##");
				lblMetricValue04.Text = value.ToString("##0.##");
			}
		}

		[Category("FreezeFrame")]
		[Description("Fuel System 2 Status")]
		public string FuelSystem2Status
		{
			get
			{
				return lblEnglishValue03b.Text;
			}
			set
			{
				lblEnglishValue03b.Text = value;
				lblMetricValue03b.Text = value;
			}
		}

		[Category("FreezeFrame")]
		[Description("Fuel System 1 Status")]
		public string FuelSystem1Status
		{
			get
			{
				return lblEnglishValue03a.Text;
			}
			set
			{
				lblEnglishValue03a.Text = value;
				lblMetricValue03a.Text = value;
			}
		}

		[Description("DTC that triggered Freeze Frame data storage")]
		[Category("FreezeFrame")]
		public string DTC
		{
			get
			{
				return lblEnglishValue02.Text;
			}
			set
			{
				lblEnglishValue02.Text = value;
				lblMetricValue02.Text = value;
			}
		}

		public FreezeFrameDataControl()
		{
			InitializeComponent();
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblPIDHeader = new System.Windows.Forms.Label();
			this.lblDescriptionHeader = new System.Windows.Forms.Label();
			this.lblEnglishValueHeader = new System.Windows.Forms.Label();
			this.lblEnglishUnitsHeader = new System.Windows.Forms.Label();
			this.lblMetricValueHeader = new System.Windows.Forms.Label();
			this.lblMetricUnitsHeader = new System.Windows.Forms.Label();
			this.lblMetricUnits02 = new System.Windows.Forms.Label();
			this.lblMetricValue02 = new System.Windows.Forms.Label();
			this.lblEnglishUnits02 = new System.Windows.Forms.Label();
			this.lblEnglishValue02 = new System.Windows.Forms.Label();
			this.lblDescription02 = new System.Windows.Forms.Label();
			this.lblPID02 = new System.Windows.Forms.Label();
			this.lblMetricUnits03a = new System.Windows.Forms.Label();
			this.lblMetricValue03a = new System.Windows.Forms.Label();
			this.lblEnglishUnits03a = new System.Windows.Forms.Label();
			this.lblEnglishValue03a = new System.Windows.Forms.Label();
			this.lblDescription03a = new System.Windows.Forms.Label();
			this.lblPID03a = new System.Windows.Forms.Label();
			this.lblMetricUnits05 = new System.Windows.Forms.Label();
			this.lblMetricValue05 = new System.Windows.Forms.Label();
			this.lblEnglishUnits05 = new System.Windows.Forms.Label();
			this.lblEnglishValue05 = new System.Windows.Forms.Label();
			this.lblDescription05 = new System.Windows.Forms.Label();
			this.lblPID05 = new System.Windows.Forms.Label();
			this.lblMetricUnits04 = new System.Windows.Forms.Label();
			this.lblMetricValue04 = new System.Windows.Forms.Label();
			this.lblEnglishUnits04 = new System.Windows.Forms.Label();
			this.lblEnglishValue04 = new System.Windows.Forms.Label();
			this.lblDescription04 = new System.Windows.Forms.Label();
			this.lblPID04 = new System.Windows.Forms.Label();
			this.lblMetricUnits09a = new System.Windows.Forms.Label();
			this.lblMetricValue09a = new System.Windows.Forms.Label();
			this.lblEnglishUnits09a = new System.Windows.Forms.Label();
			this.lblEnglishValue09a = new System.Windows.Forms.Label();
			this.lblDescription09a = new System.Windows.Forms.Label();
			this.lblPID09a = new System.Windows.Forms.Label();
			this.lblMetricUnits08a = new System.Windows.Forms.Label();
			this.lblMetricValue08a = new System.Windows.Forms.Label();
			this.lblEnglishUnits08a = new System.Windows.Forms.Label();
			this.lblEnglishValue08a = new System.Windows.Forms.Label();
			this.lblDescription08a = new System.Windows.Forms.Label();
			this.lblPID08a = new System.Windows.Forms.Label();
			this.lblMetricUnits07a = new System.Windows.Forms.Label();
			this.lblMetricValue07a = new System.Windows.Forms.Label();
			this.lblEnglishUnits07a = new System.Windows.Forms.Label();
			this.lblEnglishValue07a = new System.Windows.Forms.Label();
			this.lblDescription07a = new System.Windows.Forms.Label();
			this.lblPID07a = new System.Windows.Forms.Label();
			this.lblMetricUnits06a = new System.Windows.Forms.Label();
			this.lblMetricValue06a = new System.Windows.Forms.Label();
			this.lblEnglishUnits06a = new System.Windows.Forms.Label();
			this.lblEnglishValue06a = new System.Windows.Forms.Label();
			this.lblDescription06a = new System.Windows.Forms.Label();
			this.lblPID06a = new System.Windows.Forms.Label();
			this.lblMetricUnits0E = new System.Windows.Forms.Label();
			this.lblMetricValue0E = new System.Windows.Forms.Label();
			this.lblEnglishUnits0E = new System.Windows.Forms.Label();
			this.lblEnglishValue0E = new System.Windows.Forms.Label();
			this.lblDescription0E = new System.Windows.Forms.Label();
			this.lblPID0E = new System.Windows.Forms.Label();
			this.lblMetricUnits0D = new System.Windows.Forms.Label();
			this.lblMetricValue0D = new System.Windows.Forms.Label();
			this.lblEnglishUnits0D = new System.Windows.Forms.Label();
			this.lblEnglishValue0D = new System.Windows.Forms.Label();
			this.lblDescription0D = new System.Windows.Forms.Label();
			this.lblPID0D = new System.Windows.Forms.Label();
			this.lblMetricUnits0C = new System.Windows.Forms.Label();
			this.lblMetricValue0C = new System.Windows.Forms.Label();
			this.lblEnglishUnits0C = new System.Windows.Forms.Label();
			this.lblEnglishValue0C = new System.Windows.Forms.Label();
			this.lblDescription0C = new System.Windows.Forms.Label();
			this.lblPID0C = new System.Windows.Forms.Label();
			this.lblMetricUnits0B = new System.Windows.Forms.Label();
			this.lblMetricValue0B = new System.Windows.Forms.Label();
			this.lblEnglishUnits0B = new System.Windows.Forms.Label();
			this.lblEnglishValue0B = new System.Windows.Forms.Label();
			this.lblDescription0B = new System.Windows.Forms.Label();
			this.lblPID0B = new System.Windows.Forms.Label();
			this.lblMetricUnits03b = new System.Windows.Forms.Label();
			this.lblMetricValue03b = new System.Windows.Forms.Label();
			this.lblEnglishUnits03b = new System.Windows.Forms.Label();
			this.lblEnglishValue03b = new System.Windows.Forms.Label();
			this.lblDescription03b = new System.Windows.Forms.Label();
			this.lblPID03b = new System.Windows.Forms.Label();
			this.lblMetricUnits09b = new System.Windows.Forms.Label();
			this.lblMetricValue09b = new System.Windows.Forms.Label();
			this.lblEnglishUnits09b = new System.Windows.Forms.Label();
			this.lblEnglishValue09b = new System.Windows.Forms.Label();
			this.lblDescription09b = new System.Windows.Forms.Label();
			this.lblPID09b = new System.Windows.Forms.Label();
			this.lblMetricUnits08b = new System.Windows.Forms.Label();
			this.lblMetricValue08b = new System.Windows.Forms.Label();
			this.lblEnglishUnits08b = new System.Windows.Forms.Label();
			this.lblEnglishValue08b = new System.Windows.Forms.Label();
			this.lblDescription08b = new System.Windows.Forms.Label();
			this.lblPID08b = new System.Windows.Forms.Label();
			this.lblMetricUnits07b = new System.Windows.Forms.Label();
			this.lblMetricValue07b = new System.Windows.Forms.Label();
			this.lblEnglishUnits07b = new System.Windows.Forms.Label();
			this.lblEnglishValue07b = new System.Windows.Forms.Label();
			this.lblDescription07b = new System.Windows.Forms.Label();
			this.lblPID07b = new System.Windows.Forms.Label();
			this.lblMetricUnits06b = new System.Windows.Forms.Label();
			this.lblMetricValue06b = new System.Windows.Forms.Label();
			this.lblEnglishUnits06b = new System.Windows.Forms.Label();
			this.lblEnglishValue06b = new System.Windows.Forms.Label();
			this.lblDescription06b = new System.Windows.Forms.Label();
			this.lblPID06b = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblPIDHeader
			// 
			this.lblPIDHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPIDHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPIDHeader.Location = new System.Drawing.Point(0, 0);
			this.lblPIDHeader.Name = "lblPIDHeader";
			this.lblPIDHeader.Size = new System.Drawing.Size(40, 20);
			this.lblPIDHeader.TabIndex = 0;
			this.lblPIDHeader.Text = "PID";
			this.lblPIDHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescriptionHeader
			// 
			this.lblDescriptionHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescriptionHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescriptionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescriptionHeader.Location = new System.Drawing.Point(39, 0);
			this.lblDescriptionHeader.Name = "lblDescriptionHeader";
			this.lblDescriptionHeader.Size = new System.Drawing.Size(200, 20);
			this.lblDescriptionHeader.TabIndex = 1;
			this.lblDescriptionHeader.Text = "Description";
			this.lblDescriptionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValueHeader
			// 
			this.lblEnglishValueHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValueHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValueHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValueHeader.Location = new System.Drawing.Point(238, 0);
			this.lblEnglishValueHeader.Name = "lblEnglishValueHeader";
			this.lblEnglishValueHeader.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValueHeader.TabIndex = 2;
			this.lblEnglishValueHeader.Text = "English Value";
			this.lblEnglishValueHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnitsHeader
			// 
			this.lblEnglishUnitsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnitsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnitsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnitsHeader.Location = new System.Drawing.Point(317, 0);
			this.lblEnglishUnitsHeader.Name = "lblEnglishUnitsHeader";
			this.lblEnglishUnitsHeader.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnitsHeader.TabIndex = 3;
			this.lblEnglishUnitsHeader.Text = "Units";
			this.lblEnglishUnitsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValueHeader
			// 
			this.lblMetricValueHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValueHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValueHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValueHeader.Location = new System.Drawing.Point(356, 0);
			this.lblMetricValueHeader.Name = "lblMetricValueHeader";
			this.lblMetricValueHeader.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValueHeader.TabIndex = 4;
			this.lblMetricValueHeader.Text = "Metric Value";
			this.lblMetricValueHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnitsHeader
			// 
			this.lblMetricUnitsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnitsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnitsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnitsHeader.Location = new System.Drawing.Point(435, 0);
			this.lblMetricUnitsHeader.Name = "lblMetricUnitsHeader";
			this.lblMetricUnitsHeader.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnitsHeader.TabIndex = 5;
			this.lblMetricUnitsHeader.Text = "Units";
			this.lblMetricUnitsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits02
			// 
			this.lblMetricUnits02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits02.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits02.Location = new System.Drawing.Point(435, 19);
			this.lblMetricUnits02.Name = "lblMetricUnits02";
			this.lblMetricUnits02.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits02.TabIndex = 11;
			this.lblMetricUnits02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue02
			// 
			this.lblMetricValue02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue02.BackColor = System.Drawing.Color.White;
			this.lblMetricValue02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue02.Location = new System.Drawing.Point(356, 19);
			this.lblMetricValue02.Name = "lblMetricValue02";
			this.lblMetricValue02.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue02.TabIndex = 10;
			this.lblMetricValue02.Text = "-";
			this.lblMetricValue02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits02
			// 
			this.lblEnglishUnits02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits02.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits02.Location = new System.Drawing.Point(317, 19);
			this.lblEnglishUnits02.Name = "lblEnglishUnits02";
			this.lblEnglishUnits02.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits02.TabIndex = 9;
			this.lblEnglishUnits02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue02
			// 
			this.lblEnglishValue02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue02.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue02.Location = new System.Drawing.Point(238, 19);
			this.lblEnglishValue02.Name = "lblEnglishValue02";
			this.lblEnglishValue02.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue02.TabIndex = 8;
			this.lblEnglishValue02.Text = "-";
			this.lblEnglishValue02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription02
			// 
			this.lblDescription02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription02.BackColor = System.Drawing.Color.White;
			this.lblDescription02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription02.Location = new System.Drawing.Point(39, 19);
			this.lblDescription02.Name = "lblDescription02";
			this.lblDescription02.Size = new System.Drawing.Size(200, 20);
			this.lblDescription02.TabIndex = 7;
			this.lblDescription02.Text = "DTC that caused Freeze Frame";
			this.lblDescription02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID02
			// 
			this.lblPID02.BackColor = System.Drawing.Color.White;
			this.lblPID02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID02.Location = new System.Drawing.Point(0, 19);
			this.lblPID02.Name = "lblPID02";
			this.lblPID02.Size = new System.Drawing.Size(40, 21);
			this.lblPID02.TabIndex = 6;
			this.lblPID02.Text = "02";
			this.lblPID02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits03a
			// 
			this.lblMetricUnits03a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits03a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits03a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits03a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits03a.Location = new System.Drawing.Point(435, 38);
			this.lblMetricUnits03a.Name = "lblMetricUnits03a";
			this.lblMetricUnits03a.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits03a.TabIndex = 17;
			this.lblMetricUnits03a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue03a
			// 
			this.lblMetricValue03a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue03a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue03a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue03a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue03a.Location = new System.Drawing.Point(356, 38);
			this.lblMetricValue03a.Name = "lblMetricValue03a";
			this.lblMetricValue03a.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue03a.TabIndex = 16;
			this.lblMetricValue03a.Text = "-";
			this.lblMetricValue03a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits03a
			// 
			this.lblEnglishUnits03a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits03a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits03a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits03a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits03a.Location = new System.Drawing.Point(317, 38);
			this.lblEnglishUnits03a.Name = "lblEnglishUnits03a";
			this.lblEnglishUnits03a.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits03a.TabIndex = 15;
			this.lblEnglishUnits03a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue03a
			// 
			this.lblEnglishValue03a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue03a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue03a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue03a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue03a.Location = new System.Drawing.Point(238, 38);
			this.lblEnglishValue03a.Name = "lblEnglishValue03a";
			this.lblEnglishValue03a.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue03a.TabIndex = 14;
			this.lblEnglishValue03a.Text = "-";
			this.lblEnglishValue03a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription03a
			// 
			this.lblDescription03a.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription03a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription03a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription03a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription03a.Location = new System.Drawing.Point(39, 38);
			this.lblDescription03a.Name = "lblDescription03a";
			this.lblDescription03a.Size = new System.Drawing.Size(200, 20);
			this.lblDescription03a.TabIndex = 13;
			this.lblDescription03a.Text = "Fuel System 1 Status";
			this.lblDescription03a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID03a
			// 
			this.lblPID03a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID03a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID03a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID03a.Location = new System.Drawing.Point(0, 38);
			this.lblPID03a.Name = "lblPID03a";
			this.lblPID03a.Size = new System.Drawing.Size(40, 20);
			this.lblPID03a.TabIndex = 12;
			this.lblPID03a.Text = "03a";
			this.lblPID03a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits05
			// 
			this.lblMetricUnits05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits05.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits05.Location = new System.Drawing.Point(435, 95);
			this.lblMetricUnits05.Name = "lblMetricUnits05";
			this.lblMetricUnits05.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits05.TabIndex = 29;
			this.lblMetricUnits05.Text = "°C";
			this.lblMetricUnits05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue05
			// 
			this.lblMetricValue05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue05.BackColor = System.Drawing.Color.White;
			this.lblMetricValue05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue05.Location = new System.Drawing.Point(356, 95);
			this.lblMetricValue05.Name = "lblMetricValue05";
			this.lblMetricValue05.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue05.TabIndex = 28;
			this.lblMetricValue05.Text = "-";
			this.lblMetricValue05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits05
			// 
			this.lblEnglishUnits05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits05.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits05.Location = new System.Drawing.Point(317, 95);
			this.lblEnglishUnits05.Name = "lblEnglishUnits05";
			this.lblEnglishUnits05.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits05.TabIndex = 27;
			this.lblEnglishUnits05.Text = "°F";
			this.lblEnglishUnits05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue05
			// 
			this.lblEnglishValue05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue05.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue05.Location = new System.Drawing.Point(238, 95);
			this.lblEnglishValue05.Name = "lblEnglishValue05";
			this.lblEnglishValue05.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue05.TabIndex = 26;
			this.lblEnglishValue05.Text = "-";
			this.lblEnglishValue05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription05
			// 
			this.lblDescription05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription05.BackColor = System.Drawing.Color.White;
			this.lblDescription05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription05.Location = new System.Drawing.Point(39, 95);
			this.lblDescription05.Name = "lblDescription05";
			this.lblDescription05.Size = new System.Drawing.Size(200, 20);
			this.lblDescription05.TabIndex = 25;
			this.lblDescription05.Text = "Engine Coolant Temperature";
			this.lblDescription05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID05
			// 
			this.lblPID05.BackColor = System.Drawing.Color.White;
			this.lblPID05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID05.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID05.Location = new System.Drawing.Point(0, 95);
			this.lblPID05.Name = "lblPID05";
			this.lblPID05.Size = new System.Drawing.Size(40, 20);
			this.lblPID05.TabIndex = 24;
			this.lblPID05.Text = "05";
			this.lblPID05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits04
			// 
			this.lblMetricUnits04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits04.Location = new System.Drawing.Point(435, 76);
			this.lblMetricUnits04.Name = "lblMetricUnits04";
			this.lblMetricUnits04.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits04.TabIndex = 23;
			this.lblMetricUnits04.Text = "%";
			this.lblMetricUnits04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue04
			// 
			this.lblMetricValue04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue04.Location = new System.Drawing.Point(356, 76);
			this.lblMetricValue04.Name = "lblMetricValue04";
			this.lblMetricValue04.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue04.TabIndex = 22;
			this.lblMetricValue04.Text = "-";
			this.lblMetricValue04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits04
			// 
			this.lblEnglishUnits04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits04.Location = new System.Drawing.Point(317, 76);
			this.lblEnglishUnits04.Name = "lblEnglishUnits04";
			this.lblEnglishUnits04.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits04.TabIndex = 21;
			this.lblEnglishUnits04.Text = "%";
			this.lblEnglishUnits04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue04
			// 
			this.lblEnglishValue04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue04.Location = new System.Drawing.Point(238, 76);
			this.lblEnglishValue04.Name = "lblEnglishValue04";
			this.lblEnglishValue04.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue04.TabIndex = 20;
			this.lblEnglishValue04.Text = "-";
			this.lblEnglishValue04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription04
			// 
			this.lblDescription04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription04.Location = new System.Drawing.Point(39, 76);
			this.lblDescription04.Name = "lblDescription04";
			this.lblDescription04.Size = new System.Drawing.Size(200, 20);
			this.lblDescription04.TabIndex = 19;
			this.lblDescription04.Text = "Calculated Load Value";
			this.lblDescription04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID04
			// 
			this.lblPID04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID04.Location = new System.Drawing.Point(0, 76);
			this.lblPID04.Name = "lblPID04";
			this.lblPID04.Size = new System.Drawing.Size(40, 20);
			this.lblPID04.TabIndex = 18;
			this.lblPID04.Text = "04";
			this.lblPID04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits09a
			// 
			this.lblMetricUnits09a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits09a.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits09a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits09a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits09a.Location = new System.Drawing.Point(435, 171);
			this.lblMetricUnits09a.Name = "lblMetricUnits09a";
			this.lblMetricUnits09a.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits09a.TabIndex = 53;
			this.lblMetricUnits09a.Text = "%";
			this.lblMetricUnits09a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue09a
			// 
			this.lblMetricValue09a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue09a.BackColor = System.Drawing.Color.White;
			this.lblMetricValue09a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue09a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue09a.Location = new System.Drawing.Point(356, 171);
			this.lblMetricValue09a.Name = "lblMetricValue09a";
			this.lblMetricValue09a.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue09a.TabIndex = 52;
			this.lblMetricValue09a.Text = "-";
			this.lblMetricValue09a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits09a
			// 
			this.lblEnglishUnits09a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits09a.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits09a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits09a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits09a.Location = new System.Drawing.Point(317, 171);
			this.lblEnglishUnits09a.Name = "lblEnglishUnits09a";
			this.lblEnglishUnits09a.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits09a.TabIndex = 51;
			this.lblEnglishUnits09a.Text = "%";
			this.lblEnglishUnits09a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue09a
			// 
			this.lblEnglishValue09a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue09a.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue09a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue09a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue09a.Location = new System.Drawing.Point(238, 171);
			this.lblEnglishValue09a.Name = "lblEnglishValue09a";
			this.lblEnglishValue09a.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue09a.TabIndex = 50;
			this.lblEnglishValue09a.Text = "-";
			this.lblEnglishValue09a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription09a
			// 
			this.lblDescription09a.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription09a.BackColor = System.Drawing.Color.White;
			this.lblDescription09a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription09a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription09a.Location = new System.Drawing.Point(39, 171);
			this.lblDescription09a.Name = "lblDescription09a";
			this.lblDescription09a.Size = new System.Drawing.Size(200, 20);
			this.lblDescription09a.TabIndex = 49;
			this.lblDescription09a.Text = "Long Term Fuel Trim - Bank 2";
			this.lblDescription09a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID09a
			// 
			this.lblPID09a.BackColor = System.Drawing.Color.White;
			this.lblPID09a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID09a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID09a.Location = new System.Drawing.Point(0, 171);
			this.lblPID09a.Name = "lblPID09a";
			this.lblPID09a.Size = new System.Drawing.Size(40, 20);
			this.lblPID09a.TabIndex = 48;
			this.lblPID09a.Text = "09a";
			this.lblPID09a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits08a
			// 
			this.lblMetricUnits08a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits08a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits08a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits08a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits08a.Location = new System.Drawing.Point(435, 152);
			this.lblMetricUnits08a.Name = "lblMetricUnits08a";
			this.lblMetricUnits08a.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits08a.TabIndex = 47;
			this.lblMetricUnits08a.Text = "%";
			this.lblMetricUnits08a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue08a
			// 
			this.lblMetricValue08a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue08a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue08a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue08a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue08a.Location = new System.Drawing.Point(356, 152);
			this.lblMetricValue08a.Name = "lblMetricValue08a";
			this.lblMetricValue08a.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue08a.TabIndex = 46;
			this.lblMetricValue08a.Text = "-";
			this.lblMetricValue08a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits08a
			// 
			this.lblEnglishUnits08a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits08a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits08a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits08a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits08a.Location = new System.Drawing.Point(317, 152);
			this.lblEnglishUnits08a.Name = "lblEnglishUnits08a";
			this.lblEnglishUnits08a.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits08a.TabIndex = 45;
			this.lblEnglishUnits08a.Text = "%";
			this.lblEnglishUnits08a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue08a
			// 
			this.lblEnglishValue08a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue08a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue08a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue08a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue08a.Location = new System.Drawing.Point(238, 152);
			this.lblEnglishValue08a.Name = "lblEnglishValue08a";
			this.lblEnglishValue08a.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue08a.TabIndex = 44;
			this.lblEnglishValue08a.Text = "-";
			this.lblEnglishValue08a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription08a
			// 
			this.lblDescription08a.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription08a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription08a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription08a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription08a.Location = new System.Drawing.Point(39, 152);
			this.lblDescription08a.Name = "lblDescription08a";
			this.lblDescription08a.Size = new System.Drawing.Size(200, 20);
			this.lblDescription08a.TabIndex = 43;
			this.lblDescription08a.Text = "Short Term Fuel Trim - Bank 2";
			this.lblDescription08a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID08a
			// 
			this.lblPID08a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID08a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID08a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID08a.Location = new System.Drawing.Point(0, 152);
			this.lblPID08a.Name = "lblPID08a";
			this.lblPID08a.Size = new System.Drawing.Size(40, 20);
			this.lblPID08a.TabIndex = 42;
			this.lblPID08a.Text = "08a";
			this.lblPID08a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits07a
			// 
			this.lblMetricUnits07a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits07a.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits07a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits07a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits07a.Location = new System.Drawing.Point(435, 133);
			this.lblMetricUnits07a.Name = "lblMetricUnits07a";
			this.lblMetricUnits07a.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits07a.TabIndex = 41;
			this.lblMetricUnits07a.Text = "%";
			this.lblMetricUnits07a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue07a
			// 
			this.lblMetricValue07a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue07a.BackColor = System.Drawing.Color.White;
			this.lblMetricValue07a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue07a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue07a.Location = new System.Drawing.Point(356, 133);
			this.lblMetricValue07a.Name = "lblMetricValue07a";
			this.lblMetricValue07a.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue07a.TabIndex = 40;
			this.lblMetricValue07a.Text = "-";
			this.lblMetricValue07a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits07a
			// 
			this.lblEnglishUnits07a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits07a.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits07a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits07a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits07a.Location = new System.Drawing.Point(317, 133);
			this.lblEnglishUnits07a.Name = "lblEnglishUnits07a";
			this.lblEnglishUnits07a.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits07a.TabIndex = 39;
			this.lblEnglishUnits07a.Text = "%";
			this.lblEnglishUnits07a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue07a
			// 
			this.lblEnglishValue07a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue07a.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue07a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue07a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue07a.Location = new System.Drawing.Point(238, 133);
			this.lblEnglishValue07a.Name = "lblEnglishValue07a";
			this.lblEnglishValue07a.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue07a.TabIndex = 38;
			this.lblEnglishValue07a.Text = "-";
			this.lblEnglishValue07a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription07a
			// 
			this.lblDescription07a.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription07a.BackColor = System.Drawing.Color.White;
			this.lblDescription07a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription07a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription07a.Location = new System.Drawing.Point(39, 133);
			this.lblDescription07a.Name = "lblDescription07a";
			this.lblDescription07a.Size = new System.Drawing.Size(200, 20);
			this.lblDescription07a.TabIndex = 37;
			this.lblDescription07a.Text = "Long Term Fuel Trim - Bank 1";
			this.lblDescription07a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID07a
			// 
			this.lblPID07a.BackColor = System.Drawing.Color.White;
			this.lblPID07a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID07a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID07a.Location = new System.Drawing.Point(0, 133);
			this.lblPID07a.Name = "lblPID07a";
			this.lblPID07a.Size = new System.Drawing.Size(40, 20);
			this.lblPID07a.TabIndex = 36;
			this.lblPID07a.Text = "07a";
			this.lblPID07a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits06a
			// 
			this.lblMetricUnits06a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits06a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits06a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits06a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits06a.Location = new System.Drawing.Point(435, 114);
			this.lblMetricUnits06a.Name = "lblMetricUnits06a";
			this.lblMetricUnits06a.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits06a.TabIndex = 35;
			this.lblMetricUnits06a.Text = "%";
			this.lblMetricUnits06a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue06a
			// 
			this.lblMetricValue06a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue06a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue06a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue06a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue06a.Location = new System.Drawing.Point(356, 114);
			this.lblMetricValue06a.Name = "lblMetricValue06a";
			this.lblMetricValue06a.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue06a.TabIndex = 34;
			this.lblMetricValue06a.Text = "-";
			this.lblMetricValue06a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits06a
			// 
			this.lblEnglishUnits06a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits06a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits06a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits06a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits06a.Location = new System.Drawing.Point(317, 114);
			this.lblEnglishUnits06a.Name = "lblEnglishUnits06a";
			this.lblEnglishUnits06a.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits06a.TabIndex = 33;
			this.lblEnglishUnits06a.Text = "%";
			this.lblEnglishUnits06a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue06a
			// 
			this.lblEnglishValue06a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue06a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue06a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue06a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue06a.Location = new System.Drawing.Point(238, 114);
			this.lblEnglishValue06a.Name = "lblEnglishValue06a";
			this.lblEnglishValue06a.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue06a.TabIndex = 32;
			this.lblEnglishValue06a.Text = "-";
			this.lblEnglishValue06a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription06a
			// 
			this.lblDescription06a.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription06a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription06a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription06a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription06a.Location = new System.Drawing.Point(39, 114);
			this.lblDescription06a.Name = "lblDescription06a";
			this.lblDescription06a.Size = new System.Drawing.Size(200, 20);
			this.lblDescription06a.TabIndex = 31;
			this.lblDescription06a.Text = "Short Term Fuel Trim - Bank 1";
			this.lblDescription06a.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID06a
			// 
			this.lblPID06a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID06a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID06a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID06a.Location = new System.Drawing.Point(0, 114);
			this.lblPID06a.Name = "lblPID06a";
			this.lblPID06a.Size = new System.Drawing.Size(40, 20);
			this.lblPID06a.TabIndex = 30;
			this.lblPID06a.Text = "06a";
			this.lblPID06a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits0E
			// 
			this.lblMetricUnits0E.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits0E.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits0E.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits0E.Location = new System.Drawing.Point(435, 323);
			this.lblMetricUnits0E.Name = "lblMetricUnits0E";
			this.lblMetricUnits0E.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits0E.TabIndex = 77;
			this.lblMetricUnits0E.Text = "°";
			this.lblMetricUnits0E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue0E
			// 
			this.lblMetricValue0E.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue0E.BackColor = System.Drawing.Color.White;
			this.lblMetricValue0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue0E.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue0E.Location = new System.Drawing.Point(356, 323);
			this.lblMetricValue0E.Name = "lblMetricValue0E";
			this.lblMetricValue0E.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue0E.TabIndex = 76;
			this.lblMetricValue0E.Text = "-";
			this.lblMetricValue0E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits0E
			// 
			this.lblEnglishUnits0E.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits0E.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits0E.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits0E.Location = new System.Drawing.Point(317, 323);
			this.lblEnglishUnits0E.Name = "lblEnglishUnits0E";
			this.lblEnglishUnits0E.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits0E.TabIndex = 75;
			this.lblEnglishUnits0E.Text = "°";
			this.lblEnglishUnits0E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue0E
			// 
			this.lblEnglishValue0E.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue0E.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue0E.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue0E.Location = new System.Drawing.Point(238, 323);
			this.lblEnglishValue0E.Name = "lblEnglishValue0E";
			this.lblEnglishValue0E.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue0E.TabIndex = 74;
			this.lblEnglishValue0E.Text = "-";
			this.lblEnglishValue0E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription0E
			// 
			this.lblDescription0E.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription0E.BackColor = System.Drawing.Color.White;
			this.lblDescription0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription0E.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription0E.Location = new System.Drawing.Point(39, 323);
			this.lblDescription0E.Name = "lblDescription0E";
			this.lblDescription0E.Size = new System.Drawing.Size(200, 20);
			this.lblDescription0E.TabIndex = 73;
			this.lblDescription0E.Text = "Ignition Timing Advance";
			this.lblDescription0E.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID0E
			// 
			this.lblPID0E.BackColor = System.Drawing.Color.White;
			this.lblPID0E.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID0E.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID0E.Location = new System.Drawing.Point(0, 323);
			this.lblPID0E.Name = "lblPID0E";
			this.lblPID0E.Size = new System.Drawing.Size(40, 20);
			this.lblPID0E.TabIndex = 72;
			this.lblPID0E.Text = "0E";
			this.lblPID0E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits0D
			// 
			this.lblMetricUnits0D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits0D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits0D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits0D.Location = new System.Drawing.Point(435, 304);
			this.lblMetricUnits0D.Name = "lblMetricUnits0D";
			this.lblMetricUnits0D.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits0D.TabIndex = 71;
			this.lblMetricUnits0D.Text = "kph";
			this.lblMetricUnits0D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue0D
			// 
			this.lblMetricValue0D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue0D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue0D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue0D.Location = new System.Drawing.Point(356, 304);
			this.lblMetricValue0D.Name = "lblMetricValue0D";
			this.lblMetricValue0D.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue0D.TabIndex = 70;
			this.lblMetricValue0D.Text = "-";
			this.lblMetricValue0D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits0D
			// 
			this.lblEnglishUnits0D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits0D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits0D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits0D.Location = new System.Drawing.Point(317, 304);
			this.lblEnglishUnits0D.Name = "lblEnglishUnits0D";
			this.lblEnglishUnits0D.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits0D.TabIndex = 69;
			this.lblEnglishUnits0D.Text = "mph";
			this.lblEnglishUnits0D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue0D
			// 
			this.lblEnglishValue0D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue0D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue0D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue0D.Location = new System.Drawing.Point(238, 304);
			this.lblEnglishValue0D.Name = "lblEnglishValue0D";
			this.lblEnglishValue0D.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue0D.TabIndex = 68;
			this.lblEnglishValue0D.Text = "-";
			this.lblEnglishValue0D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription0D
			// 
			this.lblDescription0D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription0D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription0D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription0D.Location = new System.Drawing.Point(39, 304);
			this.lblDescription0D.Name = "lblDescription0D";
			this.lblDescription0D.Size = new System.Drawing.Size(200, 20);
			this.lblDescription0D.TabIndex = 67;
			this.lblDescription0D.Text = "Vehicle Speed";
			this.lblDescription0D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID0D
			// 
			this.lblPID0D.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID0D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID0D.Location = new System.Drawing.Point(0, 304);
			this.lblPID0D.Name = "lblPID0D";
			this.lblPID0D.Size = new System.Drawing.Size(40, 20);
			this.lblPID0D.TabIndex = 66;
			this.lblPID0D.Text = "0D";
			this.lblPID0D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits0C
			// 
			this.lblMetricUnits0C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits0C.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits0C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits0C.Location = new System.Drawing.Point(435, 285);
			this.lblMetricUnits0C.Name = "lblMetricUnits0C";
			this.lblMetricUnits0C.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits0C.TabIndex = 65;
			this.lblMetricUnits0C.Text = "rpm";
			this.lblMetricUnits0C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue0C
			// 
			this.lblMetricValue0C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue0C.BackColor = System.Drawing.Color.White;
			this.lblMetricValue0C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue0C.Location = new System.Drawing.Point(356, 285);
			this.lblMetricValue0C.Name = "lblMetricValue0C";
			this.lblMetricValue0C.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue0C.TabIndex = 64;
			this.lblMetricValue0C.Text = "-";
			this.lblMetricValue0C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits0C
			// 
			this.lblEnglishUnits0C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits0C.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits0C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits0C.Location = new System.Drawing.Point(317, 285);
			this.lblEnglishUnits0C.Name = "lblEnglishUnits0C";
			this.lblEnglishUnits0C.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits0C.TabIndex = 63;
			this.lblEnglishUnits0C.Text = "rpm";
			this.lblEnglishUnits0C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue0C
			// 
			this.lblEnglishValue0C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue0C.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue0C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue0C.Location = new System.Drawing.Point(238, 285);
			this.lblEnglishValue0C.Name = "lblEnglishValue0C";
			this.lblEnglishValue0C.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue0C.TabIndex = 62;
			this.lblEnglishValue0C.Text = "-";
			this.lblEnglishValue0C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription0C
			// 
			this.lblDescription0C.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription0C.BackColor = System.Drawing.Color.White;
			this.lblDescription0C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription0C.Location = new System.Drawing.Point(39, 285);
			this.lblDescription0C.Name = "lblDescription0C";
			this.lblDescription0C.Size = new System.Drawing.Size(200, 20);
			this.lblDescription0C.TabIndex = 61;
			this.lblDescription0C.Text = "Engine RPM";
			this.lblDescription0C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID0C
			// 
			this.lblPID0C.BackColor = System.Drawing.Color.White;
			this.lblPID0C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID0C.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID0C.Location = new System.Drawing.Point(0, 285);
			this.lblPID0C.Name = "lblPID0C";
			this.lblPID0C.Size = new System.Drawing.Size(40, 20);
			this.lblPID0C.TabIndex = 60;
			this.lblPID0C.Text = "0C";
			this.lblPID0C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits0B
			// 
			this.lblMetricUnits0B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits0B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits0B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits0B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits0B.Location = new System.Drawing.Point(435, 266);
			this.lblMetricUnits0B.Name = "lblMetricUnits0B";
			this.lblMetricUnits0B.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits0B.TabIndex = 59;
			this.lblMetricUnits0B.Text = "kPa";
			this.lblMetricUnits0B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue0B
			// 
			this.lblMetricValue0B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue0B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue0B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue0B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue0B.Location = new System.Drawing.Point(356, 266);
			this.lblMetricValue0B.Name = "lblMetricValue0B";
			this.lblMetricValue0B.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue0B.TabIndex = 58;
			this.lblMetricValue0B.Text = "-";
			this.lblMetricValue0B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits0B
			// 
			this.lblEnglishUnits0B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits0B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits0B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits0B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits0B.Location = new System.Drawing.Point(317, 266);
			this.lblEnglishUnits0B.Name = "lblEnglishUnits0B";
			this.lblEnglishUnits0B.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits0B.TabIndex = 57;
			this.lblEnglishUnits0B.Text = "inHg";
			this.lblEnglishUnits0B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue0B
			// 
			this.lblEnglishValue0B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue0B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue0B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue0B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue0B.Location = new System.Drawing.Point(238, 266);
			this.lblEnglishValue0B.Name = "lblEnglishValue0B";
			this.lblEnglishValue0B.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue0B.TabIndex = 56;
			this.lblEnglishValue0B.Text = "-";
			this.lblEnglishValue0B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription0B
			// 
			this.lblDescription0B.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription0B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription0B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription0B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription0B.Location = new System.Drawing.Point(39, 266);
			this.lblDescription0B.Name = "lblDescription0B";
			this.lblDescription0B.Size = new System.Drawing.Size(200, 20);
			this.lblDescription0B.TabIndex = 55;
			this.lblDescription0B.Text = "Intake Manifold Absolute Pressure";
			this.lblDescription0B.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID0B
			// 
			this.lblPID0B.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID0B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID0B.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID0B.Location = new System.Drawing.Point(0, 266);
			this.lblPID0B.Name = "lblPID0B";
			this.lblPID0B.Size = new System.Drawing.Size(40, 20);
			this.lblPID0B.TabIndex = 54;
			this.lblPID0B.Text = "0B";
			this.lblPID0B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits03b
			// 
			this.lblMetricUnits03b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits03b.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits03b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits03b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits03b.Location = new System.Drawing.Point(435, 57);
			this.lblMetricUnits03b.Name = "lblMetricUnits03b";
			this.lblMetricUnits03b.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits03b.TabIndex = 83;
			this.lblMetricUnits03b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue03b
			// 
			this.lblMetricValue03b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue03b.BackColor = System.Drawing.Color.White;
			this.lblMetricValue03b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue03b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue03b.Location = new System.Drawing.Point(356, 57);
			this.lblMetricValue03b.Name = "lblMetricValue03b";
			this.lblMetricValue03b.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue03b.TabIndex = 82;
			this.lblMetricValue03b.Text = "-";
			this.lblMetricValue03b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits03b
			// 
			this.lblEnglishUnits03b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits03b.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits03b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits03b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits03b.Location = new System.Drawing.Point(317, 57);
			this.lblEnglishUnits03b.Name = "lblEnglishUnits03b";
			this.lblEnglishUnits03b.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits03b.TabIndex = 81;
			this.lblEnglishUnits03b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue03b
			// 
			this.lblEnglishValue03b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue03b.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue03b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue03b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue03b.Location = new System.Drawing.Point(238, 57);
			this.lblEnglishValue03b.Name = "lblEnglishValue03b";
			this.lblEnglishValue03b.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue03b.TabIndex = 80;
			this.lblEnglishValue03b.Text = "-";
			this.lblEnglishValue03b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription03b
			// 
			this.lblDescription03b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription03b.BackColor = System.Drawing.Color.White;
			this.lblDescription03b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription03b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription03b.Location = new System.Drawing.Point(39, 57);
			this.lblDescription03b.Name = "lblDescription03b";
			this.lblDescription03b.Size = new System.Drawing.Size(200, 20);
			this.lblDescription03b.TabIndex = 79;
			this.lblDescription03b.Text = "Fuel System 2 Status";
			this.lblDescription03b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID03b
			// 
			this.lblPID03b.BackColor = System.Drawing.Color.White;
			this.lblPID03b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID03b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID03b.Location = new System.Drawing.Point(0, 57);
			this.lblPID03b.Name = "lblPID03b";
			this.lblPID03b.Size = new System.Drawing.Size(40, 20);
			this.lblPID03b.TabIndex = 78;
			this.lblPID03b.Text = "03b";
			this.lblPID03b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits09b
			// 
			this.lblMetricUnits09b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits09b.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits09b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits09b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits09b.Location = new System.Drawing.Point(435, 247);
			this.lblMetricUnits09b.Name = "lblMetricUnits09b";
			this.lblMetricUnits09b.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits09b.TabIndex = 107;
			this.lblMetricUnits09b.Text = "%";
			this.lblMetricUnits09b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue09b
			// 
			this.lblMetricValue09b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue09b.BackColor = System.Drawing.Color.White;
			this.lblMetricValue09b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue09b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue09b.Location = new System.Drawing.Point(356, 247);
			this.lblMetricValue09b.Name = "lblMetricValue09b";
			this.lblMetricValue09b.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue09b.TabIndex = 106;
			this.lblMetricValue09b.Text = "-";
			this.lblMetricValue09b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits09b
			// 
			this.lblEnglishUnits09b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits09b.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits09b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits09b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits09b.Location = new System.Drawing.Point(317, 247);
			this.lblEnglishUnits09b.Name = "lblEnglishUnits09b";
			this.lblEnglishUnits09b.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits09b.TabIndex = 105;
			this.lblEnglishUnits09b.Text = "%";
			this.lblEnglishUnits09b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue09b
			// 
			this.lblEnglishValue09b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue09b.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue09b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue09b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue09b.Location = new System.Drawing.Point(238, 247);
			this.lblEnglishValue09b.Name = "lblEnglishValue09b";
			this.lblEnglishValue09b.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue09b.TabIndex = 104;
			this.lblEnglishValue09b.Text = "-";
			this.lblEnglishValue09b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription09b
			// 
			this.lblDescription09b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription09b.BackColor = System.Drawing.Color.White;
			this.lblDescription09b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription09b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription09b.Location = new System.Drawing.Point(39, 247);
			this.lblDescription09b.Name = "lblDescription09b";
			this.lblDescription09b.Size = new System.Drawing.Size(200, 20);
			this.lblDescription09b.TabIndex = 103;
			this.lblDescription09b.Text = "Long Term Fuel Trim - Bank 4";
			this.lblDescription09b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID09b
			// 
			this.lblPID09b.BackColor = System.Drawing.Color.White;
			this.lblPID09b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID09b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID09b.Location = new System.Drawing.Point(0, 247);
			this.lblPID09b.Name = "lblPID09b";
			this.lblPID09b.Size = new System.Drawing.Size(40, 20);
			this.lblPID09b.TabIndex = 102;
			this.lblPID09b.Text = "09b";
			this.lblPID09b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits08b
			// 
			this.lblMetricUnits08b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits08b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits08b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits08b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits08b.Location = new System.Drawing.Point(435, 228);
			this.lblMetricUnits08b.Name = "lblMetricUnits08b";
			this.lblMetricUnits08b.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits08b.TabIndex = 101;
			this.lblMetricUnits08b.Text = "%";
			this.lblMetricUnits08b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue08b
			// 
			this.lblMetricValue08b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue08b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue08b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue08b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue08b.Location = new System.Drawing.Point(356, 228);
			this.lblMetricValue08b.Name = "lblMetricValue08b";
			this.lblMetricValue08b.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue08b.TabIndex = 100;
			this.lblMetricValue08b.Text = "-";
			this.lblMetricValue08b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits08b
			// 
			this.lblEnglishUnits08b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits08b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits08b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits08b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits08b.Location = new System.Drawing.Point(317, 228);
			this.lblEnglishUnits08b.Name = "lblEnglishUnits08b";
			this.lblEnglishUnits08b.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits08b.TabIndex = 99;
			this.lblEnglishUnits08b.Text = "%";
			this.lblEnglishUnits08b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue08b
			// 
			this.lblEnglishValue08b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue08b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue08b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue08b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue08b.Location = new System.Drawing.Point(238, 228);
			this.lblEnglishValue08b.Name = "lblEnglishValue08b";
			this.lblEnglishValue08b.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue08b.TabIndex = 98;
			this.lblEnglishValue08b.Text = "-";
			this.lblEnglishValue08b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription08b
			// 
			this.lblDescription08b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription08b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription08b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription08b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription08b.Location = new System.Drawing.Point(39, 228);
			this.lblDescription08b.Name = "lblDescription08b";
			this.lblDescription08b.Size = new System.Drawing.Size(200, 20);
			this.lblDescription08b.TabIndex = 97;
			this.lblDescription08b.Text = "Short Term Fuel Trim - Bank 4";
			this.lblDescription08b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID08b
			// 
			this.lblPID08b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID08b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID08b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID08b.Location = new System.Drawing.Point(0, 228);
			this.lblPID08b.Name = "lblPID08b";
			this.lblPID08b.Size = new System.Drawing.Size(40, 20);
			this.lblPID08b.TabIndex = 96;
			this.lblPID08b.Text = "08b";
			this.lblPID08b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits07b
			// 
			this.lblMetricUnits07b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits07b.BackColor = System.Drawing.Color.White;
			this.lblMetricUnits07b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits07b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits07b.Location = new System.Drawing.Point(435, 209);
			this.lblMetricUnits07b.Name = "lblMetricUnits07b";
			this.lblMetricUnits07b.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits07b.TabIndex = 95;
			this.lblMetricUnits07b.Text = "%";
			this.lblMetricUnits07b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue07b
			// 
			this.lblMetricValue07b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue07b.BackColor = System.Drawing.Color.White;
			this.lblMetricValue07b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue07b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue07b.Location = new System.Drawing.Point(356, 209);
			this.lblMetricValue07b.Name = "lblMetricValue07b";
			this.lblMetricValue07b.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue07b.TabIndex = 94;
			this.lblMetricValue07b.Text = "-";
			this.lblMetricValue07b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits07b
			// 
			this.lblEnglishUnits07b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits07b.BackColor = System.Drawing.Color.White;
			this.lblEnglishUnits07b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits07b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits07b.Location = new System.Drawing.Point(317, 209);
			this.lblEnglishUnits07b.Name = "lblEnglishUnits07b";
			this.lblEnglishUnits07b.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits07b.TabIndex = 93;
			this.lblEnglishUnits07b.Text = "%";
			this.lblEnglishUnits07b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue07b
			// 
			this.lblEnglishValue07b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue07b.BackColor = System.Drawing.Color.White;
			this.lblEnglishValue07b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue07b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue07b.Location = new System.Drawing.Point(238, 209);
			this.lblEnglishValue07b.Name = "lblEnglishValue07b";
			this.lblEnglishValue07b.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue07b.TabIndex = 92;
			this.lblEnglishValue07b.Text = "-";
			this.lblEnglishValue07b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription07b
			// 
			this.lblDescription07b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription07b.BackColor = System.Drawing.Color.White;
			this.lblDescription07b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription07b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription07b.Location = new System.Drawing.Point(39, 209);
			this.lblDescription07b.Name = "lblDescription07b";
			this.lblDescription07b.Size = new System.Drawing.Size(200, 20);
			this.lblDescription07b.TabIndex = 91;
			this.lblDescription07b.Text = "Long Term Fuel Trim - Bank 3";
			this.lblDescription07b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID07b
			// 
			this.lblPID07b.BackColor = System.Drawing.Color.White;
			this.lblPID07b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID07b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID07b.Location = new System.Drawing.Point(0, 209);
			this.lblPID07b.Name = "lblPID07b";
			this.lblPID07b.Size = new System.Drawing.Size(40, 20);
			this.lblPID07b.TabIndex = 90;
			this.lblPID07b.Text = "07b";
			this.lblPID07b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricUnits06b
			// 
			this.lblMetricUnits06b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricUnits06b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricUnits06b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricUnits06b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricUnits06b.Location = new System.Drawing.Point(435, 190);
			this.lblMetricUnits06b.Name = "lblMetricUnits06b";
			this.lblMetricUnits06b.Size = new System.Drawing.Size(40, 20);
			this.lblMetricUnits06b.TabIndex = 89;
			this.lblMetricUnits06b.Text = "%";
			this.lblMetricUnits06b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMetricValue06b
			// 
			this.lblMetricValue06b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMetricValue06b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMetricValue06b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMetricValue06b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMetricValue06b.Location = new System.Drawing.Point(356, 190);
			this.lblMetricValue06b.Name = "lblMetricValue06b";
			this.lblMetricValue06b.Size = new System.Drawing.Size(80, 20);
			this.lblMetricValue06b.TabIndex = 88;
			this.lblMetricValue06b.Text = "-";
			this.lblMetricValue06b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishUnits06b
			// 
			this.lblEnglishUnits06b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishUnits06b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishUnits06b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishUnits06b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishUnits06b.Location = new System.Drawing.Point(317, 190);
			this.lblEnglishUnits06b.Name = "lblEnglishUnits06b";
			this.lblEnglishUnits06b.Size = new System.Drawing.Size(40, 20);
			this.lblEnglishUnits06b.TabIndex = 87;
			this.lblEnglishUnits06b.Text = "%";
			this.lblEnglishUnits06b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblEnglishValue06b
			// 
			this.lblEnglishValue06b.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnglishValue06b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblEnglishValue06b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEnglishValue06b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnglishValue06b.Location = new System.Drawing.Point(238, 190);
			this.lblEnglishValue06b.Name = "lblEnglishValue06b";
			this.lblEnglishValue06b.Size = new System.Drawing.Size(80, 20);
			this.lblEnglishValue06b.TabIndex = 86;
			this.lblEnglishValue06b.Text = "-";
			this.lblEnglishValue06b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription06b
			// 
			this.lblDescription06b.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription06b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription06b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription06b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescription06b.Location = new System.Drawing.Point(39, 190);
			this.lblDescription06b.Name = "lblDescription06b";
			this.lblDescription06b.Size = new System.Drawing.Size(200, 20);
			this.lblDescription06b.TabIndex = 85;
			this.lblDescription06b.Text = "Short Term Fuel Trim - Bank 3";
			this.lblDescription06b.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPID06b
			// 
			this.lblPID06b.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblPID06b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPID06b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPID06b.Location = new System.Drawing.Point(0, 190);
			this.lblPID06b.Name = "lblPID06b";
			this.lblPID06b.Size = new System.Drawing.Size(40, 20);
			this.lblPID06b.TabIndex = 84;
			this.lblPID06b.Text = "06b";
			this.lblPID06b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FreezeFrameDataControl
			// 
			this.Controls.Add(this.lblMetricUnits09b);
			this.Controls.Add(this.lblMetricValue09b);
			this.Controls.Add(this.lblEnglishUnits09b);
			this.Controls.Add(this.lblEnglishValue09b);
			this.Controls.Add(this.lblDescription09b);
			this.Controls.Add(this.lblPID09b);
			this.Controls.Add(this.lblMetricUnits08b);
			this.Controls.Add(this.lblMetricValue08b);
			this.Controls.Add(this.lblEnglishUnits08b);
			this.Controls.Add(this.lblEnglishValue08b);
			this.Controls.Add(this.lblDescription08b);
			this.Controls.Add(this.lblPID08b);
			this.Controls.Add(this.lblMetricUnits07b);
			this.Controls.Add(this.lblMetricValue07b);
			this.Controls.Add(this.lblEnglishUnits07b);
			this.Controls.Add(this.lblEnglishValue07b);
			this.Controls.Add(this.lblDescription07b);
			this.Controls.Add(this.lblPID07b);
			this.Controls.Add(this.lblMetricUnits06b);
			this.Controls.Add(this.lblMetricValue06b);
			this.Controls.Add(this.lblEnglishUnits06b);
			this.Controls.Add(this.lblEnglishValue06b);
			this.Controls.Add(this.lblDescription06b);
			this.Controls.Add(this.lblPID06b);
			this.Controls.Add(this.lblMetricUnits03b);
			this.Controls.Add(this.lblMetricValue03b);
			this.Controls.Add(this.lblEnglishUnits03b);
			this.Controls.Add(this.lblEnglishValue03b);
			this.Controls.Add(this.lblDescription03b);
			this.Controls.Add(this.lblPID03b);
			this.Controls.Add(this.lblMetricUnits0E);
			this.Controls.Add(this.lblMetricValue0E);
			this.Controls.Add(this.lblEnglishUnits0E);
			this.Controls.Add(this.lblEnglishValue0E);
			this.Controls.Add(this.lblDescription0E);
			this.Controls.Add(this.lblPID0E);
			this.Controls.Add(this.lblMetricUnits0D);
			this.Controls.Add(this.lblMetricValue0D);
			this.Controls.Add(this.lblEnglishUnits0D);
			this.Controls.Add(this.lblEnglishValue0D);
			this.Controls.Add(this.lblDescription0D);
			this.Controls.Add(this.lblPID0D);
			this.Controls.Add(this.lblMetricUnits0C);
			this.Controls.Add(this.lblMetricValue0C);
			this.Controls.Add(this.lblEnglishUnits0C);
			this.Controls.Add(this.lblEnglishValue0C);
			this.Controls.Add(this.lblDescription0C);
			this.Controls.Add(this.lblPID0C);
			this.Controls.Add(this.lblMetricUnits0B);
			this.Controls.Add(this.lblMetricValue0B);
			this.Controls.Add(this.lblEnglishUnits0B);
			this.Controls.Add(this.lblEnglishValue0B);
			this.Controls.Add(this.lblDescription0B);
			this.Controls.Add(this.lblPID0B);
			this.Controls.Add(this.lblMetricUnits09a);
			this.Controls.Add(this.lblMetricValue09a);
			this.Controls.Add(this.lblEnglishUnits09a);
			this.Controls.Add(this.lblEnglishValue09a);
			this.Controls.Add(this.lblDescription09a);
			this.Controls.Add(this.lblPID09a);
			this.Controls.Add(this.lblMetricUnits08a);
			this.Controls.Add(this.lblMetricValue08a);
			this.Controls.Add(this.lblEnglishUnits08a);
			this.Controls.Add(this.lblEnglishValue08a);
			this.Controls.Add(this.lblDescription08a);
			this.Controls.Add(this.lblPID08a);
			this.Controls.Add(this.lblMetricUnits07a);
			this.Controls.Add(this.lblMetricValue07a);
			this.Controls.Add(this.lblEnglishUnits07a);
			this.Controls.Add(this.lblEnglishValue07a);
			this.Controls.Add(this.lblDescription07a);
			this.Controls.Add(this.lblPID07a);
			this.Controls.Add(this.lblMetricUnits06a);
			this.Controls.Add(this.lblMetricValue06a);
			this.Controls.Add(this.lblEnglishUnits06a);
			this.Controls.Add(this.lblEnglishValue06a);
			this.Controls.Add(this.lblDescription06a);
			this.Controls.Add(this.lblPID06a);
			this.Controls.Add(this.lblMetricUnits05);
			this.Controls.Add(this.lblMetricValue05);
			this.Controls.Add(this.lblEnglishUnits05);
			this.Controls.Add(this.lblEnglishValue05);
			this.Controls.Add(this.lblDescription05);
			this.Controls.Add(this.lblPID05);
			this.Controls.Add(this.lblMetricUnits04);
			this.Controls.Add(this.lblMetricValue04);
			this.Controls.Add(this.lblEnglishUnits04);
			this.Controls.Add(this.lblEnglishValue04);
			this.Controls.Add(this.lblDescription04);
			this.Controls.Add(this.lblPID04);
			this.Controls.Add(this.lblMetricUnits03a);
			this.Controls.Add(this.lblMetricValue03a);
			this.Controls.Add(this.lblEnglishUnits03a);
			this.Controls.Add(this.lblEnglishValue03a);
			this.Controls.Add(this.lblDescription03a);
			this.Controls.Add(this.lblPID03a);
			this.Controls.Add(this.lblMetricUnits02);
			this.Controls.Add(this.lblMetricValue02);
			this.Controls.Add(this.lblEnglishUnits02);
			this.Controls.Add(this.lblEnglishValue02);
			this.Controls.Add(this.lblDescription02);
			this.Controls.Add(this.lblPID02);
			this.Controls.Add(this.lblMetricUnitsHeader);
			this.Controls.Add(this.lblMetricValueHeader);
			this.Controls.Add(this.lblEnglishUnitsHeader);
			this.Controls.Add(this.lblEnglishValueHeader);
			this.Controls.Add(this.lblDescriptionHeader);
			this.Controls.Add(this.lblPIDHeader);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "FreezeFrameDataControl";
			this.Size = new System.Drawing.Size(475, 343);
			this.ResumeLayout(false);

		}

		public void Reset()
		{
			lblEnglishValue02.Text = "-";
			lblMetricValue02.Text = "-";
			lblEnglishValue03a.Text = "-";
			lblMetricValue03a.Text = "-";
			lblEnglishValue03b.Text = "-";
			lblMetricValue03b.Text = "-";
			lblEnglishValue04.Text = "-";
			lblMetricValue04.Text = "-";
			lblEnglishValue05.Text = "-";
			lblMetricValue05.Text = "-";
			lblEnglishValue06a.Text = "-";
			lblMetricValue06a.Text = "-";
			lblEnglishValue07a.Text = "-";
			lblMetricValue07a.Text = "-";
			lblEnglishValue08a.Text = "-";
			lblMetricValue08a.Text = "-";
			lblEnglishValue09a.Text = "-";
			lblMetricValue09a.Text = "-";
			lblEnglishValue06b.Text = "-";
			lblMetricValue06b.Text = "-";
			lblEnglishValue07b.Text = "-";
			lblMetricValue07b.Text = "-";
			lblEnglishValue08b.Text = "-";
			lblMetricValue08b.Text = "-";
			lblEnglishValue09b.Text = "-";
			lblMetricValue09b.Text = "-";
			lblEnglishValue0B.Text = "-";
			lblMetricValue0B.Text = "-";
			lblEnglishValue0C.Text = "-";
			lblMetricValue0C.Text = "-";
			lblEnglishValue0D.Text = "-";
			lblMetricValue0D.Text = "-";
			lblEnglishValue0E.Text = "-";
			lblMetricValue0E.Text = "-";
		}
	}
}