using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class O2TestResultsControl : UserControl
	{
		public O2TestResultsControl()
		{
			InitializeComponent();
		}

		public void Reset()
		{
			lblValue01.Text = "-";
			lblValue02.Text = "-";
			lblValue03.Text = "-";
			lblValue04.Text = "-";
			lblValue05.Text = "-";
			lblValue06.Text = "-";
			lblValue07.Text = "-";
			lblValue08.Text = "-";
			lblValue09.Text = "-";
			lblValue0A.Text = "-";
			lblMinimum01.Text = "-";
			lblMinimum02.Text = "-";
			lblMinimum03.Text = "-";
			lblMinimum04.Text = "-";
			lblMinimum05.Text = "-";
			lblMinimum06.Text = "-";
			lblMinimum07.Text = "-";
			lblMinimum08.Text = "-";
			lblMinimum09.Text = "-";
			lblMinimum0A.Text = "-";
			lblMaximum01.Text = "-";
			lblMaximum02.Text = "-";
			lblMaximum03.Text = "-";
			lblMaximum04.Text = "-";
			lblMaximum05.Text = "-";
			lblMaximum06.Text = "-";
			lblMaximum07.Text = "-";
			lblMaximum08.Text = "-";
			lblMaximum09.Text = "-";
			lblMaximum0A.Text = "-";
		}

		public double TestMaximum0A
		{
			set { lblMaximum0A.Text = value.ToString("0.000"); }
		}

		public double TestMinimum0A
		{
			set { lblMinimum0A.Text = value.ToString("0.000"); }
		}

		public double TestValue0A
		{
			set { lblValue0A.Text = value.ToString("0.000"); }
		}

		public double TestMaximum09
		{
			set { lblMaximum09.Text = value.ToString("0.000"); }
		}

		public double TestMinimum09
		{
			set { lblMinimum09.Text = value.ToString("0.000"); }
		}

		public double TestValue09
		{
			set { lblValue09.Text = value.ToString("0.000"); }
		}

		public double TestMaximum08
		{
			set { lblMaximum08.Text = value.ToString("0.000"); }
		}

		public double TestMinimum08
		{
			set { lblMinimum08.Text = value.ToString("0.000"); }
		}

		public double TestValue08
		{
			set { lblValue08.Text = value.ToString("0.000"); }
		}

		public double TestMaximum07
		{
			set { lblMaximum07.Text = value.ToString("0.000"); }
		}

		public double TestMinimum07
		{
			set { lblMinimum07.Text = value.ToString("0.000"); }
		}

		public double TestValue07
		{
			set { lblValue07.Text = value.ToString("0.000"); }
		}

		public double TestMaximum06
		{
			set { lblMaximum06.Text = value.ToString("0.000"); }
		}

		public double TestMinimum06
		{
			set { lblMinimum06.Text = value.ToString("0.000"); }
		}

		public double TestValue06
		{
			set { lblValue06.Text = value.ToString("0.000"); }
		}

		public double TestMaximum05
		{
			set { lblMaximum05.Text = value.ToString("0.000"); }
		}

		public double TestMinimum05
		{
			set { lblMinimum05.Text = value.ToString("0.000"); }
		}

		public double TestValue05
		{
			set { lblValue05.Text = value.ToString("0.000"); }
		}

		public double TestMaximum04
		{
			set { lblMaximum04.Text = value.ToString("0.000"); }
		}

		public double TestMinimum04
		{
			set { lblMinimum04.Text = value.ToString("0.000"); }
		}

		public double TestValue04
		{
			set { lblValue04.Text = value.ToString("0.000"); }
		}

		public double TestMaximum03
		{
			set { lblMaximum03.Text = value.ToString("0.000"); }
		}

		public double TestMinimum03
		{
			set { lblMinimum03.Text = value.ToString("0.000"); }
		}

		public double TestValue03
		{
			set { lblValue03.Text = value.ToString("0.000"); }
		}

		public double TestMaximum02
		{
			set { lblMaximum02.Text = value.ToString("0.000"); }
		}

		public double TestMinimum02
		{
			set { lblMinimum02.Text = value.ToString("0.000"); }
		}

		public double TestValue02
		{
			set { lblValue02.Text = value.ToString("0.000"); }
		}

		public double TestMaximum01
		{
			set { lblMaximum01.Text = value.ToString("0.000"); }
		}

		public double TestMinimum01
		{
			set { lblMinimum01.Text = value.ToString("0.000"); }
		}

		public double TestValue01
		{
			set { lblValue01.Text = value.ToString("0.000"); }
		}

		#region

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			base.Dispose(disposing);
		}

		private Label lblTestIDHeader;
		private Label lblDescriptionHeader;
		private Label lblValueHeader;
		private Label lblMinimumHeader;
		private Label lblMaximumHeader;
		private Label lblUnitsHeader;
		private Label lblTestID01;
		private Label lblDescription01;
		private Label lblTestID02;
		private Label lblUnits01;
		private Label lblMaximum01;
		private Label lblMinimum01;
		private Label lblValue01;
		private Label lblUnits02;
		private Label lblMaximum02;
		private Label lblMinimum02;
		private Label lblValue02;
		private Label lblDescription02;
		private Label lblUnits04;
		private Label lblMaximum04;
		private Label lblMinimum04;
		private Label lblValue04;
		private Label lblDescription04;
		private Label lblTestID04;
		private Label lblUnits03;
		private Label lblMaximum03;
		private Label lblMinimum03;
		private Label lblValue03;
		private Label lblDescription03;
		private Label lblTestID03;
		private Label lblUnits08;
		private Label lblMaximum08;
		private Label lblMinimum08;
		private Label lblValue08;
		private Label lblDescription08;
		private Label lblTestID08;
		private Label lblUnits07;
		private Label lblMaximum07;
		private Label lblMinimum07;
		private Label lblValue07;
		private Label lblDescription07;
		private Label lblTestID07;
		private Label lblUnits06;
		private Label lblMaximum06;
		private Label lblMinimum06;
		private Label lblValue06;
		private Label lblDescription06;
		private Label lblTestID06;
		private Label lblUnits05;
		private Label lblMaximum05;
		private Label lblMinimum05;
		private Label lblValue05;
		private Label lblDescription05;
		private Label lblTestID05;
		private Label lblUnits0A;
		private Label lblMaximum0A;
		private Label lblMinimum0A;
		private Label lblValue0A;
		private Label lblDescription0A;
		private Label lblTestID0A;
		private Label lblUnits09;
		private Label lblMaximum09;
		private Label lblMinimum09;
		private Label lblValue09;
		private Label lblDescription09;
		private Label lblTestID09;

		private void InitializeComponent()
		{
			this.lblTestIDHeader = new System.Windows.Forms.Label();
			this.lblDescriptionHeader = new System.Windows.Forms.Label();
			this.lblValueHeader = new System.Windows.Forms.Label();
			this.lblMinimumHeader = new System.Windows.Forms.Label();
			this.lblMaximumHeader = new System.Windows.Forms.Label();
			this.lblUnitsHeader = new System.Windows.Forms.Label();
			this.lblTestID01 = new System.Windows.Forms.Label();
			this.lblUnits01 = new System.Windows.Forms.Label();
			this.lblMaximum01 = new System.Windows.Forms.Label();
			this.lblMinimum01 = new System.Windows.Forms.Label();
			this.lblValue01 = new System.Windows.Forms.Label();
			this.lblDescription01 = new System.Windows.Forms.Label();
			this.lblUnits02 = new System.Windows.Forms.Label();
			this.lblMaximum02 = new System.Windows.Forms.Label();
			this.lblMinimum02 = new System.Windows.Forms.Label();
			this.lblValue02 = new System.Windows.Forms.Label();
			this.lblDescription02 = new System.Windows.Forms.Label();
			this.lblTestID02 = new System.Windows.Forms.Label();
			this.lblUnits04 = new System.Windows.Forms.Label();
			this.lblMaximum04 = new System.Windows.Forms.Label();
			this.lblMinimum04 = new System.Windows.Forms.Label();
			this.lblValue04 = new System.Windows.Forms.Label();
			this.lblDescription04 = new System.Windows.Forms.Label();
			this.lblTestID04 = new System.Windows.Forms.Label();
			this.lblUnits03 = new System.Windows.Forms.Label();
			this.lblMaximum03 = new System.Windows.Forms.Label();
			this.lblMinimum03 = new System.Windows.Forms.Label();
			this.lblValue03 = new System.Windows.Forms.Label();
			this.lblDescription03 = new System.Windows.Forms.Label();
			this.lblTestID03 = new System.Windows.Forms.Label();
			this.lblUnits08 = new System.Windows.Forms.Label();
			this.lblMaximum08 = new System.Windows.Forms.Label();
			this.lblMinimum08 = new System.Windows.Forms.Label();
			this.lblValue08 = new System.Windows.Forms.Label();
			this.lblDescription08 = new System.Windows.Forms.Label();
			this.lblTestID08 = new System.Windows.Forms.Label();
			this.lblUnits07 = new System.Windows.Forms.Label();
			this.lblMaximum07 = new System.Windows.Forms.Label();
			this.lblMinimum07 = new System.Windows.Forms.Label();
			this.lblValue07 = new System.Windows.Forms.Label();
			this.lblDescription07 = new System.Windows.Forms.Label();
			this.lblTestID07 = new System.Windows.Forms.Label();
			this.lblUnits06 = new System.Windows.Forms.Label();
			this.lblMaximum06 = new System.Windows.Forms.Label();
			this.lblMinimum06 = new System.Windows.Forms.Label();
			this.lblValue06 = new System.Windows.Forms.Label();
			this.lblDescription06 = new System.Windows.Forms.Label();
			this.lblTestID06 = new System.Windows.Forms.Label();
			this.lblUnits05 = new System.Windows.Forms.Label();
			this.lblMaximum05 = new System.Windows.Forms.Label();
			this.lblMinimum05 = new System.Windows.Forms.Label();
			this.lblValue05 = new System.Windows.Forms.Label();
			this.lblDescription05 = new System.Windows.Forms.Label();
			this.lblTestID05 = new System.Windows.Forms.Label();
			this.lblUnits0A = new System.Windows.Forms.Label();
			this.lblMaximum0A = new System.Windows.Forms.Label();
			this.lblMinimum0A = new System.Windows.Forms.Label();
			this.lblValue0A = new System.Windows.Forms.Label();
			this.lblDescription0A = new System.Windows.Forms.Label();
			this.lblTestID0A = new System.Windows.Forms.Label();
			this.lblUnits09 = new System.Windows.Forms.Label();
			this.lblMaximum09 = new System.Windows.Forms.Label();
			this.lblMinimum09 = new System.Windows.Forms.Label();
			this.lblValue09 = new System.Windows.Forms.Label();
			this.lblDescription09 = new System.Windows.Forms.Label();
			this.lblTestID09 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTestIDHeader
			// 
			this.lblTestIDHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestIDHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestIDHeader.Location = new System.Drawing.Point(0, 0);
			this.lblTestIDHeader.Name = "lblTestIDHeader";
			this.lblTestIDHeader.Size = new System.Drawing.Size(50, 20);
			this.lblTestIDHeader.TabIndex = 0;
			this.lblTestIDHeader.Text = "Test ID";
			this.lblTestIDHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescriptionHeader
			// 
			this.lblDescriptionHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescriptionHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescriptionHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDescriptionHeader.Location = new System.Drawing.Point(49, 0);
			this.lblDescriptionHeader.Name = "lblDescriptionHeader";
			this.lblDescriptionHeader.Size = new System.Drawing.Size(305, 20);
			this.lblDescriptionHeader.TabIndex = 1;
			this.lblDescriptionHeader.Text = "Description";
			this.lblDescriptionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValueHeader
			// 
			this.lblValueHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValueHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValueHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblValueHeader.Location = new System.Drawing.Point(353, 0);
			this.lblValueHeader.Name = "lblValueHeader";
			this.lblValueHeader.Size = new System.Drawing.Size(60, 20);
			this.lblValueHeader.TabIndex = 2;
			this.lblValueHeader.Text = "Value";
			this.lblValueHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimumHeader
			// 
			this.lblMinimumHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimumHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimumHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMinimumHeader.Location = new System.Drawing.Point(412, 0);
			this.lblMinimumHeader.Name = "lblMinimumHeader";
			this.lblMinimumHeader.Size = new System.Drawing.Size(60, 20);
			this.lblMinimumHeader.TabIndex = 3;
			this.lblMinimumHeader.Text = "Minimum";
			this.lblMinimumHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximumHeader
			// 
			this.lblMaximumHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximumHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximumHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaximumHeader.Location = new System.Drawing.Point(471, 0);
			this.lblMaximumHeader.Name = "lblMaximumHeader";
			this.lblMaximumHeader.Size = new System.Drawing.Size(60, 20);
			this.lblMaximumHeader.TabIndex = 4;
			this.lblMaximumHeader.Text = "Maximum";
			this.lblMaximumHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnitsHeader
			// 
			this.lblUnitsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnitsHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnitsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUnitsHeader.Location = new System.Drawing.Point(530, 0);
			this.lblUnitsHeader.Name = "lblUnitsHeader";
			this.lblUnitsHeader.Size = new System.Drawing.Size(60, 20);
			this.lblUnitsHeader.TabIndex = 5;
			this.lblUnitsHeader.Text = "Units";
			this.lblUnitsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTestID01
			// 
			this.lblTestID01.BackColor = System.Drawing.Color.White;
			this.lblTestID01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID01.Location = new System.Drawing.Point(0, 19);
			this.lblTestID01.Name = "lblTestID01";
			this.lblTestID01.Size = new System.Drawing.Size(50, 20);
			this.lblTestID01.TabIndex = 6;
			this.lblTestID01.Text = "$01";
			this.lblTestID01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits01
			// 
			this.lblUnits01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits01.BackColor = System.Drawing.Color.White;
			this.lblUnits01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits01.Location = new System.Drawing.Point(530, 19);
			this.lblUnits01.Name = "lblUnits01";
			this.lblUnits01.Size = new System.Drawing.Size(60, 20);
			this.lblUnits01.TabIndex = 11;
			this.lblUnits01.Text = "V";
			this.lblUnits01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum01
			// 
			this.lblMaximum01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum01.BackColor = System.Drawing.Color.White;
			this.lblMaximum01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum01.Location = new System.Drawing.Point(471, 19);
			this.lblMaximum01.Name = "lblMaximum01";
			this.lblMaximum01.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum01.TabIndex = 10;
			this.lblMaximum01.Text = "-";
			this.lblMaximum01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum01
			// 
			this.lblMinimum01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum01.BackColor = System.Drawing.Color.White;
			this.lblMinimum01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum01.Location = new System.Drawing.Point(412, 19);
			this.lblMinimum01.Name = "lblMinimum01";
			this.lblMinimum01.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum01.TabIndex = 9;
			this.lblMinimum01.Text = "-";
			this.lblMinimum01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue01
			// 
			this.lblValue01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue01.BackColor = System.Drawing.Color.White;
			this.lblValue01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue01.Location = new System.Drawing.Point(353, 19);
			this.lblValue01.Name = "lblValue01";
			this.lblValue01.Size = new System.Drawing.Size(60, 20);
			this.lblValue01.TabIndex = 8;
			this.lblValue01.Text = "-";
			this.lblValue01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription01
			// 
			this.lblDescription01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription01.BackColor = System.Drawing.Color.White;
			this.lblDescription01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription01.Location = new System.Drawing.Point(49, 19);
			this.lblDescription01.Name = "lblDescription01";
			this.lblDescription01.Size = new System.Drawing.Size(305, 20);
			this.lblDescription01.TabIndex = 7;
			this.lblDescription01.Text = "Rich to lean sensor threshold voltage (constant)";
			this.lblDescription01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUnits02
			// 
			this.lblUnits02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblUnits02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits02.Location = new System.Drawing.Point(530, 38);
			this.lblUnits02.Name = "lblUnits02";
			this.lblUnits02.Size = new System.Drawing.Size(60, 20);
			this.lblUnits02.TabIndex = 17;
			this.lblUnits02.Text = "V";
			this.lblUnits02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum02
			// 
			this.lblMaximum02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMaximum02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum02.Location = new System.Drawing.Point(471, 38);
			this.lblMaximum02.Name = "lblMaximum02";
			this.lblMaximum02.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum02.TabIndex = 16;
			this.lblMaximum02.Text = "-";
			this.lblMaximum02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum02
			// 
			this.lblMinimum02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMinimum02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum02.Location = new System.Drawing.Point(412, 38);
			this.lblMinimum02.Name = "lblMinimum02";
			this.lblMinimum02.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum02.TabIndex = 15;
			this.lblMinimum02.Text = "-";
			this.lblMinimum02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue02
			// 
			this.lblValue02.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblValue02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue02.Location = new System.Drawing.Point(353, 38);
			this.lblValue02.Name = "lblValue02";
			this.lblValue02.Size = new System.Drawing.Size(60, 20);
			this.lblValue02.TabIndex = 14;
			this.lblValue02.Text = "-";
			this.lblValue02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription02
			// 
			this.lblDescription02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription02.Location = new System.Drawing.Point(49, 38);
			this.lblDescription02.Name = "lblDescription02";
			this.lblDescription02.Size = new System.Drawing.Size(305, 20);
			this.lblDescription02.TabIndex = 13;
			this.lblDescription02.Text = "Lean to rich sensor threshold voltage (constant)";
			this.lblDescription02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID02
			// 
			this.lblTestID02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblTestID02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID02.Location = new System.Drawing.Point(0, 38);
			this.lblTestID02.Name = "lblTestID02";
			this.lblTestID02.Size = new System.Drawing.Size(50, 20);
			this.lblTestID02.TabIndex = 12;
			this.lblTestID02.Text = "$02";
			this.lblTestID02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits04
			// 
			this.lblUnits04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblUnits04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits04.Location = new System.Drawing.Point(530, 76);
			this.lblUnits04.Name = "lblUnits04";
			this.lblUnits04.Size = new System.Drawing.Size(60, 20);
			this.lblUnits04.TabIndex = 29;
			this.lblUnits04.Text = "V";
			this.lblUnits04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum04
			// 
			this.lblMaximum04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMaximum04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum04.Location = new System.Drawing.Point(471, 76);
			this.lblMaximum04.Name = "lblMaximum04";
			this.lblMaximum04.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum04.TabIndex = 28;
			this.lblMaximum04.Text = "-";
			this.lblMaximum04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum04
			// 
			this.lblMinimum04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMinimum04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum04.Location = new System.Drawing.Point(412, 76);
			this.lblMinimum04.Name = "lblMinimum04";
			this.lblMinimum04.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum04.TabIndex = 27;
			this.lblMinimum04.Text = "-";
			this.lblMinimum04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue04
			// 
			this.lblValue04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblValue04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue04.Location = new System.Drawing.Point(353, 76);
			this.lblValue04.Name = "lblValue04";
			this.lblValue04.Size = new System.Drawing.Size(60, 20);
			this.lblValue04.TabIndex = 26;
			this.lblValue04.Text = "-";
			this.lblValue04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription04
			// 
			this.lblDescription04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription04.Location = new System.Drawing.Point(49, 76);
			this.lblDescription04.Name = "lblDescription04";
			this.lblDescription04.Size = new System.Drawing.Size(305, 20);
			this.lblDescription04.TabIndex = 25;
			this.lblDescription04.Text = "High sensor voltage for switch time calculation (constant)";
			this.lblDescription04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID04
			// 
			this.lblTestID04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblTestID04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID04.Location = new System.Drawing.Point(0, 76);
			this.lblTestID04.Name = "lblTestID04";
			this.lblTestID04.Size = new System.Drawing.Size(50, 20);
			this.lblTestID04.TabIndex = 24;
			this.lblTestID04.Text = "$04";
			this.lblTestID04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits03
			// 
			this.lblUnits03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits03.BackColor = System.Drawing.Color.White;
			this.lblUnits03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits03.Location = new System.Drawing.Point(530, 57);
			this.lblUnits03.Name = "lblUnits03";
			this.lblUnits03.Size = new System.Drawing.Size(60, 20);
			this.lblUnits03.TabIndex = 23;
			this.lblUnits03.Text = "V";
			this.lblUnits03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum03
			// 
			this.lblMaximum03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum03.BackColor = System.Drawing.Color.White;
			this.lblMaximum03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum03.Location = new System.Drawing.Point(471, 57);
			this.lblMaximum03.Name = "lblMaximum03";
			this.lblMaximum03.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum03.TabIndex = 22;
			this.lblMaximum03.Text = "-";
			this.lblMaximum03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum03
			// 
			this.lblMinimum03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum03.BackColor = System.Drawing.Color.White;
			this.lblMinimum03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum03.Location = new System.Drawing.Point(412, 57);
			this.lblMinimum03.Name = "lblMinimum03";
			this.lblMinimum03.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum03.TabIndex = 21;
			this.lblMinimum03.Text = "-";
			this.lblMinimum03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue03
			// 
			this.lblValue03.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue03.BackColor = System.Drawing.Color.White;
			this.lblValue03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue03.Location = new System.Drawing.Point(353, 57);
			this.lblValue03.Name = "lblValue03";
			this.lblValue03.Size = new System.Drawing.Size(60, 20);
			this.lblValue03.TabIndex = 20;
			this.lblValue03.Text = "-";
			this.lblValue03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription03
			// 
			this.lblDescription03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription03.BackColor = System.Drawing.Color.White;
			this.lblDescription03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription03.Location = new System.Drawing.Point(49, 57);
			this.lblDescription03.Name = "lblDescription03";
			this.lblDescription03.Size = new System.Drawing.Size(305, 20);
			this.lblDescription03.TabIndex = 19;
			this.lblDescription03.Text = "Low sensor voltage for switch time calculation (constant)";
			this.lblDescription03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID03
			// 
			this.lblTestID03.BackColor = System.Drawing.Color.White;
			this.lblTestID03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID03.Location = new System.Drawing.Point(0, 57);
			this.lblTestID03.Name = "lblTestID03";
			this.lblTestID03.Size = new System.Drawing.Size(50, 20);
			this.lblTestID03.TabIndex = 18;
			this.lblTestID03.Text = "$03";
			this.lblTestID03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits08
			// 
			this.lblUnits08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblUnits08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits08.Location = new System.Drawing.Point(530, 152);
			this.lblUnits08.Name = "lblUnits08";
			this.lblUnits08.Size = new System.Drawing.Size(60, 20);
			this.lblUnits08.TabIndex = 53;
			this.lblUnits08.Text = "V";
			this.lblUnits08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum08
			// 
			this.lblMaximum08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMaximum08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum08.Location = new System.Drawing.Point(471, 152);
			this.lblMaximum08.Name = "lblMaximum08";
			this.lblMaximum08.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum08.TabIndex = 52;
			this.lblMaximum08.Text = "-";
			this.lblMaximum08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum08
			// 
			this.lblMinimum08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMinimum08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum08.Location = new System.Drawing.Point(412, 152);
			this.lblMinimum08.Name = "lblMinimum08";
			this.lblMinimum08.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum08.TabIndex = 51;
			this.lblMinimum08.Text = "-";
			this.lblMinimum08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue08
			// 
			this.lblValue08.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblValue08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue08.Location = new System.Drawing.Point(353, 152);
			this.lblValue08.Name = "lblValue08";
			this.lblValue08.Size = new System.Drawing.Size(60, 20);
			this.lblValue08.TabIndex = 50;
			this.lblValue08.Text = "-";
			this.lblValue08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription08
			// 
			this.lblDescription08.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription08.Location = new System.Drawing.Point(49, 152);
			this.lblDescription08.Name = "lblDescription08";
			this.lblDescription08.Size = new System.Drawing.Size(305, 20);
			this.lblDescription08.TabIndex = 49;
			this.lblDescription08.Text = "Maximum sensor voltage for test cycle (calculated)";
			this.lblDescription08.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID08
			// 
			this.lblTestID08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblTestID08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID08.Location = new System.Drawing.Point(0, 152);
			this.lblTestID08.Name = "lblTestID08";
			this.lblTestID08.Size = new System.Drawing.Size(50, 20);
			this.lblTestID08.TabIndex = 48;
			this.lblTestID08.Text = "$08";
			this.lblTestID08.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits07
			// 
			this.lblUnits07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits07.BackColor = System.Drawing.Color.White;
			this.lblUnits07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits07.Location = new System.Drawing.Point(530, 133);
			this.lblUnits07.Name = "lblUnits07";
			this.lblUnits07.Size = new System.Drawing.Size(60, 20);
			this.lblUnits07.TabIndex = 47;
			this.lblUnits07.Text = "V";
			this.lblUnits07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum07
			// 
			this.lblMaximum07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum07.BackColor = System.Drawing.Color.White;
			this.lblMaximum07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum07.Location = new System.Drawing.Point(471, 133);
			this.lblMaximum07.Name = "lblMaximum07";
			this.lblMaximum07.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum07.TabIndex = 46;
			this.lblMaximum07.Text = "-";
			this.lblMaximum07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum07
			// 
			this.lblMinimum07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum07.BackColor = System.Drawing.Color.White;
			this.lblMinimum07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum07.Location = new System.Drawing.Point(412, 133);
			this.lblMinimum07.Name = "lblMinimum07";
			this.lblMinimum07.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum07.TabIndex = 45;
			this.lblMinimum07.Text = "-";
			this.lblMinimum07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue07
			// 
			this.lblValue07.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue07.BackColor = System.Drawing.Color.White;
			this.lblValue07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue07.Location = new System.Drawing.Point(353, 133);
			this.lblValue07.Name = "lblValue07";
			this.lblValue07.Size = new System.Drawing.Size(60, 20);
			this.lblValue07.TabIndex = 44;
			this.lblValue07.Text = "-";
			this.lblValue07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription07
			// 
			this.lblDescription07.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription07.BackColor = System.Drawing.Color.White;
			this.lblDescription07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription07.Location = new System.Drawing.Point(49, 133);
			this.lblDescription07.Name = "lblDescription07";
			this.lblDescription07.Size = new System.Drawing.Size(305, 20);
			this.lblDescription07.TabIndex = 43;
			this.lblDescription07.Text = "Minimum sensor voltage for test cycle (calculated)";
			this.lblDescription07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID07
			// 
			this.lblTestID07.BackColor = System.Drawing.Color.White;
			this.lblTestID07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID07.Location = new System.Drawing.Point(0, 133);
			this.lblTestID07.Name = "lblTestID07";
			this.lblTestID07.Size = new System.Drawing.Size(50, 20);
			this.lblTestID07.TabIndex = 42;
			this.lblTestID07.Text = "$07";
			this.lblTestID07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits06
			// 
			this.lblUnits06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblUnits06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits06.Location = new System.Drawing.Point(530, 114);
			this.lblUnits06.Name = "lblUnits06";
			this.lblUnits06.Size = new System.Drawing.Size(60, 20);
			this.lblUnits06.TabIndex = 41;
			this.lblUnits06.Text = "s";
			this.lblUnits06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum06
			// 
			this.lblMaximum06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMaximum06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum06.Location = new System.Drawing.Point(471, 114);
			this.lblMaximum06.Name = "lblMaximum06";
			this.lblMaximum06.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum06.TabIndex = 40;
			this.lblMaximum06.Text = "-";
			this.lblMaximum06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum06
			// 
			this.lblMinimum06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMinimum06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum06.Location = new System.Drawing.Point(412, 114);
			this.lblMinimum06.Name = "lblMinimum06";
			this.lblMinimum06.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum06.TabIndex = 39;
			this.lblMinimum06.Text = "-";
			this.lblMinimum06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue06
			// 
			this.lblValue06.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblValue06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue06.Location = new System.Drawing.Point(353, 114);
			this.lblValue06.Name = "lblValue06";
			this.lblValue06.Size = new System.Drawing.Size(60, 20);
			this.lblValue06.TabIndex = 38;
			this.lblValue06.Text = "-";
			this.lblValue06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription06
			// 
			this.lblDescription06.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription06.Location = new System.Drawing.Point(49, 114);
			this.lblDescription06.Name = "lblDescription06";
			this.lblDescription06.Size = new System.Drawing.Size(305, 20);
			this.lblDescription06.TabIndex = 37;
			this.lblDescription06.Text = "Lean to rich sensor switch time (calculated)";
			this.lblDescription06.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID06
			// 
			this.lblTestID06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblTestID06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID06.Location = new System.Drawing.Point(0, 114);
			this.lblTestID06.Name = "lblTestID06";
			this.lblTestID06.Size = new System.Drawing.Size(50, 20);
			this.lblTestID06.TabIndex = 36;
			this.lblTestID06.Text = "$06";
			this.lblTestID06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits05
			// 
			this.lblUnits05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits05.BackColor = System.Drawing.Color.White;
			this.lblUnits05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits05.Location = new System.Drawing.Point(530, 95);
			this.lblUnits05.Name = "lblUnits05";
			this.lblUnits05.Size = new System.Drawing.Size(60, 20);
			this.lblUnits05.TabIndex = 35;
			this.lblUnits05.Text = "s";
			this.lblUnits05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum05
			// 
			this.lblMaximum05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum05.BackColor = System.Drawing.Color.White;
			this.lblMaximum05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum05.Location = new System.Drawing.Point(471, 95);
			this.lblMaximum05.Name = "lblMaximum05";
			this.lblMaximum05.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum05.TabIndex = 34;
			this.lblMaximum05.Text = "-";
			this.lblMaximum05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum05
			// 
			this.lblMinimum05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum05.BackColor = System.Drawing.Color.White;
			this.lblMinimum05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum05.Location = new System.Drawing.Point(412, 95);
			this.lblMinimum05.Name = "lblMinimum05";
			this.lblMinimum05.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum05.TabIndex = 33;
			this.lblMinimum05.Text = "-";
			this.lblMinimum05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue05
			// 
			this.lblValue05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue05.BackColor = System.Drawing.Color.White;
			this.lblValue05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue05.Location = new System.Drawing.Point(353, 95);
			this.lblValue05.Name = "lblValue05";
			this.lblValue05.Size = new System.Drawing.Size(60, 20);
			this.lblValue05.TabIndex = 32;
			this.lblValue05.Text = "-";
			this.lblValue05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription05
			// 
			this.lblDescription05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription05.BackColor = System.Drawing.Color.White;
			this.lblDescription05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription05.Location = new System.Drawing.Point(49, 95);
			this.lblDescription05.Name = "lblDescription05";
			this.lblDescription05.Size = new System.Drawing.Size(305, 20);
			this.lblDescription05.TabIndex = 31;
			this.lblDescription05.Text = "Rich to lean sensor switch time (calculated)";
			this.lblDescription05.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID05
			// 
			this.lblTestID05.BackColor = System.Drawing.Color.White;
			this.lblTestID05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID05.Location = new System.Drawing.Point(0, 95);
			this.lblTestID05.Name = "lblTestID05";
			this.lblTestID05.Size = new System.Drawing.Size(50, 20);
			this.lblTestID05.TabIndex = 30;
			this.lblTestID05.Text = "$05";
			this.lblTestID05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits0A
			// 
			this.lblUnits0A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits0A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblUnits0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits0A.Location = new System.Drawing.Point(530, 190);
			this.lblUnits0A.Name = "lblUnits0A";
			this.lblUnits0A.Size = new System.Drawing.Size(60, 20);
			this.lblUnits0A.TabIndex = 65;
			this.lblUnits0A.Text = "s";
			this.lblUnits0A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum0A
			// 
			this.lblMaximum0A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum0A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMaximum0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum0A.Location = new System.Drawing.Point(471, 190);
			this.lblMaximum0A.Name = "lblMaximum0A";
			this.lblMaximum0A.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum0A.TabIndex = 64;
			this.lblMaximum0A.Text = "-";
			this.lblMaximum0A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum0A
			// 
			this.lblMinimum0A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum0A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblMinimum0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum0A.Location = new System.Drawing.Point(412, 190);
			this.lblMinimum0A.Name = "lblMinimum0A";
			this.lblMinimum0A.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum0A.TabIndex = 63;
			this.lblMinimum0A.Text = "-";
			this.lblMinimum0A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue0A
			// 
			this.lblValue0A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue0A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblValue0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue0A.Location = new System.Drawing.Point(353, 190);
			this.lblValue0A.Name = "lblValue0A";
			this.lblValue0A.Size = new System.Drawing.Size(60, 20);
			this.lblValue0A.TabIndex = 62;
			this.lblValue0A.Text = "-";
			this.lblValue0A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription0A
			// 
			this.lblDescription0A.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription0A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblDescription0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription0A.Location = new System.Drawing.Point(49, 190);
			this.lblDescription0A.Name = "lblDescription0A";
			this.lblDescription0A.Size = new System.Drawing.Size(305, 20);
			this.lblDescription0A.TabIndex = 61;
			this.lblDescription0A.Text = "Sensor period (calculated)";
			this.lblDescription0A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID0A
			// 
			this.lblTestID0A.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
			this.lblTestID0A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID0A.Location = new System.Drawing.Point(0, 190);
			this.lblTestID0A.Name = "lblTestID0A";
			this.lblTestID0A.Size = new System.Drawing.Size(50, 20);
			this.lblTestID0A.TabIndex = 60;
			this.lblTestID0A.Text = "$0A";
			this.lblTestID0A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblUnits09
			// 
			this.lblUnits09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUnits09.BackColor = System.Drawing.Color.White;
			this.lblUnits09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUnits09.Location = new System.Drawing.Point(530, 171);
			this.lblUnits09.Name = "lblUnits09";
			this.lblUnits09.Size = new System.Drawing.Size(60, 20);
			this.lblUnits09.TabIndex = 59;
			this.lblUnits09.Text = "s";
			this.lblUnits09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMaximum09
			// 
			this.lblMaximum09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaximum09.BackColor = System.Drawing.Color.White;
			this.lblMaximum09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMaximum09.Location = new System.Drawing.Point(471, 171);
			this.lblMaximum09.Name = "lblMaximum09";
			this.lblMaximum09.Size = new System.Drawing.Size(60, 20);
			this.lblMaximum09.TabIndex = 58;
			this.lblMaximum09.Text = "-";
			this.lblMaximum09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMinimum09
			// 
			this.lblMinimum09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMinimum09.BackColor = System.Drawing.Color.White;
			this.lblMinimum09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMinimum09.Location = new System.Drawing.Point(412, 171);
			this.lblMinimum09.Name = "lblMinimum09";
			this.lblMinimum09.Size = new System.Drawing.Size(60, 20);
			this.lblMinimum09.TabIndex = 57;
			this.lblMinimum09.Text = "-";
			this.lblMinimum09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblValue09
			// 
			this.lblValue09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblValue09.BackColor = System.Drawing.Color.White;
			this.lblValue09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblValue09.Location = new System.Drawing.Point(353, 171);
			this.lblValue09.Name = "lblValue09";
			this.lblValue09.Size = new System.Drawing.Size(60, 20);
			this.lblValue09.TabIndex = 56;
			this.lblValue09.Text = "-";
			this.lblValue09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescription09
			// 
			this.lblDescription09.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDescription09.BackColor = System.Drawing.Color.White;
			this.lblDescription09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescription09.Location = new System.Drawing.Point(49, 171);
			this.lblDescription09.Name = "lblDescription09";
			this.lblDescription09.Size = new System.Drawing.Size(305, 20);
			this.lblDescription09.TabIndex = 55;
			this.lblDescription09.Text = "Time between sensor transitions (calculated)";
			this.lblDescription09.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTestID09
			// 
			this.lblTestID09.BackColor = System.Drawing.Color.White;
			this.lblTestID09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTestID09.Location = new System.Drawing.Point(0, 171);
			this.lblTestID09.Name = "lblTestID09";
			this.lblTestID09.Size = new System.Drawing.Size(50, 20);
			this.lblTestID09.TabIndex = 54;
			this.lblTestID09.Text = "$09";
			this.lblTestID09.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// O2TestResultsControl
			// 
			this.Controls.Add(this.lblUnits0A);
			this.Controls.Add(this.lblMaximum0A);
			this.Controls.Add(this.lblMinimum0A);
			this.Controls.Add(this.lblValue0A);
			this.Controls.Add(this.lblDescription0A);
			this.Controls.Add(this.lblTestID0A);
			this.Controls.Add(this.lblUnits09);
			this.Controls.Add(this.lblMaximum09);
			this.Controls.Add(this.lblMinimum09);
			this.Controls.Add(this.lblValue09);
			this.Controls.Add(this.lblDescription09);
			this.Controls.Add(this.lblTestID09);
			this.Controls.Add(this.lblUnits08);
			this.Controls.Add(this.lblMaximum08);
			this.Controls.Add(this.lblMinimum08);
			this.Controls.Add(this.lblValue08);
			this.Controls.Add(this.lblDescription08);
			this.Controls.Add(this.lblTestID08);
			this.Controls.Add(this.lblUnits07);
			this.Controls.Add(this.lblMaximum07);
			this.Controls.Add(this.lblMinimum07);
			this.Controls.Add(this.lblValue07);
			this.Controls.Add(this.lblDescription07);
			this.Controls.Add(this.lblTestID07);
			this.Controls.Add(this.lblUnits06);
			this.Controls.Add(this.lblMaximum06);
			this.Controls.Add(this.lblMinimum06);
			this.Controls.Add(this.lblValue06);
			this.Controls.Add(this.lblDescription06);
			this.Controls.Add(this.lblTestID06);
			this.Controls.Add(this.lblUnits05);
			this.Controls.Add(this.lblMaximum05);
			this.Controls.Add(this.lblMinimum05);
			this.Controls.Add(this.lblValue05);
			this.Controls.Add(this.lblDescription05);
			this.Controls.Add(this.lblTestID05);
			this.Controls.Add(this.lblUnits04);
			this.Controls.Add(this.lblMaximum04);
			this.Controls.Add(this.lblMinimum04);
			this.Controls.Add(this.lblValue04);
			this.Controls.Add(this.lblDescription04);
			this.Controls.Add(this.lblTestID04);
			this.Controls.Add(this.lblUnits03);
			this.Controls.Add(this.lblMaximum03);
			this.Controls.Add(this.lblMinimum03);
			this.Controls.Add(this.lblValue03);
			this.Controls.Add(this.lblDescription03);
			this.Controls.Add(this.lblTestID03);
			this.Controls.Add(this.lblUnits02);
			this.Controls.Add(this.lblMaximum02);
			this.Controls.Add(this.lblMinimum02);
			this.Controls.Add(this.lblValue02);
			this.Controls.Add(this.lblDescription02);
			this.Controls.Add(this.lblTestID02);
			this.Controls.Add(this.lblUnits01);
			this.Controls.Add(this.lblMaximum01);
			this.Controls.Add(this.lblMinimum01);
			this.Controls.Add(this.lblValue01);
			this.Controls.Add(this.lblDescription01);
			this.Controls.Add(this.lblTestID01);
			this.Controls.Add(this.lblUnitsHeader);
			this.Controls.Add(this.lblMaximumHeader);
			this.Controls.Add(this.lblMinimumHeader);
			this.Controls.Add(this.lblValueHeader);
			this.Controls.Add(this.lblDescriptionHeader);
			this.Controls.Add(this.lblTestIDHeader);
			this.Name = "O2TestResultsControl";
			this.Size = new System.Drawing.Size(590, 210);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
