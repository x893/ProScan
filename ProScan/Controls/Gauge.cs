using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class Gauge : UserControl
	{
		private string strName;
		private string strUnits;
		private Color colorBezel;
		private Color colorFace;
		private double dRangeStart;
		private double dRangeEnd;
		private int iTickCount;
		private Color colorTick;
		private Font fontLabel;
		private Color colorLabel;
		private Font fontTickLabels;
		private Color colorTickLabels;
		private Color colorNeedle;
		private double dNeedleSweepAngle;
		private double dValue;
		private Container components;

		public Gauge()
		{
			InitializeComponent();

			colorBezel = Color.SlateGray;
			colorFace = Color.AntiqueWhite;
			dRangeStart = 0.0;
			dRangeEnd = 7000.0;
			iTickCount = 8;
			colorTick = Color.Black;
			fontLabel = new Font("Arial", 18f);
			colorLabel = Color.Black;
			fontTickLabels = new Font("Arial", 8f);
			colorTickLabels = Color.Black;
			colorNeedle = Color.Red;
			dNeedleSweepAngle = 225.0;
			dValue = 0.0;

			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			UpdateStyles();
		}

		[DefaultValue("0")]
		[Category("Gauge")]
		[Description("The value for the needle to reflect.")]
		public double Value
		{
			get { return dValue; }
			set
			{
				dValue = value;
				Invalidate();
			}
		}

		[Description("The color of the needle.")]
		[Category("Gauge")]
		[DefaultValue("Red")]
		public Color NeedleColor
		{
			get { return colorNeedle; }
			set
			{
				colorNeedle = value;
				Invalidate();
			}
		}

		[Description("The color of the tick labels.")]
		[DefaultValue("Black")]
		[Category("Gauge")]
		public Color TickLabelColor
		{
			get { return colorTickLabels; }
			set
			{
				colorTickLabels = value;
				Invalidate();
			}
		}

		[Description("The color of the label.")]
		[Category("Gauge")]
		[DefaultValue("Black")]
		public Color LabelColor
		{
			get { return colorLabel; }
			set
			{
				colorLabel = value;
				Invalidate();
			}
		}

		[Category("Gauge")]
		[Description("The font for the gauge's label.")]
		[DefaultValue("Arial, 18pt")]
		public Font LabelFont
		{
			get { return fontLabel; }
			set
			{
				fontLabel = value;
				Invalidate();
			}
		}

		[Category("Gauge")]
		[Description("The font for the tick mark labels.")]
		[DefaultValue("Arial, 8pt")]
		public Font TickLabelFont
		{
			get { return fontTickLabels; }
			set
			{
				fontTickLabels = value;
				Invalidate();
			}
		}

		[DefaultValue("Black")]
		[Category("Gauge")]
		[Description("The color of the tick marks.")]
		public Color TickColor
		{
			get
			{
				return colorTick;
			}
			set
			{
				colorTick = value;
				Invalidate();
			}
		}

		[Category("Gauge")]
		[Description("The number of tick marks on the gauge.")]
		[DefaultValue("8")]
		public int TickCount
		{
			get
			{
				return iTickCount;
			}
			set
			{
				iTickCount = value;
				Invalidate();
			}
		}

		[DefaultValue("7000")]
		[Category("Gauge")]
		[Description("The ending value of the gauge's range.")]
		public double RangeEnd
		{
			get
			{
				return dRangeEnd;
			}
			set
			{
				dRangeEnd = value;
				Invalidate();
			}
		}

		[Description("The starting value of the gauge's range.")]
		[Category("Gauge")]
		[DefaultValue("0")]
		public double RangeStart
		{
			get
			{
				return dRangeStart;
			}
			set
			{
				dRangeStart = value;
				Invalidate();
			}
		}

		[Category("Gauge")]
		[DefaultValue("225")]
		[Description("The sweeping range of the needle.")]
		public double NeedleSweepAngle
		{
			get
			{
				return dNeedleSweepAngle;
			}
			set
			{
				dNeedleSweepAngle = value;
				Invalidate();
			}
		}

		[Category("Gauge")]
		[Description("The color of the gauge's face.")]
		[DefaultValue("AntiqueWhite")]
		public Color FaceColor
		{
			get
			{
				return colorFace;
			}
			set
			{
				colorFace = value;
				Invalidate();
			}
		}

		[Category("Gauge")]
		[DefaultValue("SlateGray")]
		[Description("The color of the bezel.")]
		public Color BezelColor
		{
			get
			{
				return colorBezel;
			}
			set
			{
				colorBezel = value;
				Invalidate();
			}
		}

		[Description("The units to display on the gauge.")]
		[DefaultValue("")]
		[Category("Gauge")]
		public string Units
		{
			get
			{
				return strUnits;
			}
			set
			{
				strUnits = value;
				Invalidate();
			}
		}

		[Description("The name to display on the gauge.")]
		[DefaultValue("Gauge")]
		[Category("Gauge")]
		public override string Text
		{
			get
			{
				return strName;
			}
			set
			{
				strName = value;
				Invalidate();
			}
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Gauge
			// 
			this.Name = "Gauge";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Gauge_Paint);
			this.Resize += new System.EventHandler(this.Gauge_Resize);
			this.ResumeLayout(false);

		}

		private void Gauge_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				Graphics graphics = e.Graphics;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				PaintControl(graphics);
			}
			catch (Exception ex)
			{
				int num = (int)MessageBox.Show(ex.Message);
			}
		}

		private Rectangle getGaugeRectangle()
		{
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Width = clientRectangle.Width - 2;
			clientRectangle.Height = clientRectangle.Height - 2;
			if (clientRectangle.Width > clientRectangle.Height)
				clientRectangle.Width = clientRectangle.Height;
			else
				clientRectangle.Height = clientRectangle.Width;
			return clientRectangle;
		}

		private void PaintControl(Graphics g)
		{
			Rectangle gaugeRectangle = getGaugeRectangle();
			Color white1 = Color.White;
			Color color1_1 = BezelColor;
			LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(gaugeRectangle, color1_1, white1, 225f, true);
			g.FillEllipse((Brush)linearGradientBrush1, gaugeRectangle);
			int num1 = (int)((double)gaugeRectangle.Width * 0.05);
			Rectangle rect1 = gaugeRectangle;
			rect1.X = rect1.X + num1;
			rect1.Y = rect1.Y + num1;
			int num2 = num1 * 2;
			rect1.Width = rect1.Width - num2;
			rect1.Height = rect1.Height - num2;
			Color white2 = Color.White;
			Color color1_2 = BezelColor;
			LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect1, color1_2, white2, 45f, true);
			g.FillEllipse((Brush)linearGradientBrush2, rect1);
			int num3 = (int)((double)gaugeRectangle.Width * 0.1);
			Rectangle rect2 = gaugeRectangle;
			rect2.X = rect2.X + num3;
			rect2.Y = rect2.Y + num3;
			int num4 = num3 * 2;
			rect2.Width = rect2.Width - num4;
			rect2.Height = rect2.Height - num4;
			Color white3 = Color.White;
			Color color1_3 = FaceColor;
			LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(rect2, color1_3, white3, 225f, true);
			g.FillEllipse((Brush)linearGradientBrush3, rect2);
			Point point1 = new Point();
			point1.X = gaugeRectangle.Width / 2 + gaugeRectangle.X;
			point1.Y = gaugeRectangle.Height / 2 + gaugeRectangle.Y;
			if (iTickCount < 2)
				iTickCount = 2;
			double num5 = NeedleSweepAngle / (double)(iTickCount - 1);
			double num6 = (double)gaugeRectangle.Width * 0.4;
			int num7 = 0;
			if (0 < iTickCount)
			{
				do
				{
					double num8 = (double)num7;
					double num9 = NeedleSweepAngle * 0.5 + 90.0 - num8 * num5;
					Point pt2 = new Point();
					double num10 = num9 * (Math.PI / 180.0);
					pt2.X = (int)(Math.Cos(num10) * num6) + point1.X;
					pt2.Y = point1.Y - (int)(Math.Sin(num10) * num6);
					g.DrawLine(new Pen(TickColor)
					{
						Width = (float)gaugeRectangle.Width * 0.015f
					}, new Point()
					{
						X = point1.X - (int)(Math.Cos(num10) * num6 * -0.8),
						Y = point1.Y - (int)(Math.Sin(num10) * num6 * 0.8)
					}, pt2);
					Point point2 = new Point();
					point2.X = point1.X - (int)(Math.Cos(num10) * num6 * -0.6);
					point2.Y = point1.Y - (int)(Math.Sin(num10) * num6 * 0.6);
					string str = ((int)((RangeEnd - RangeStart) / (double)(TickCount - 1) * num8)).ToString();
					fontTickLabels = new Font(fontTickLabels.FontFamily.Name, (float)gaugeRectangle.Width * 0.04f);
					SizeF sizeF = g.MeasureString(str, TickLabelFont);
					Color color = TickLabelColor;
					g.DrawString(str, TickLabelFont, (Brush)new SolidBrush(color), (float)point2.X - sizeF.Width * 0.5f, (float)point2.Y - sizeF.Height * 0.5f);
					++num7;
				}
				while (num7 < iTickCount);
			}
			Point point3 = new Point();
			point3.X = point1.X;
			point3.Y = point1.Y - (int)((double)gaugeRectangle.Height * 0.1);
			fontLabel = new Font(fontLabel.FontFamily.Name, (float)gaugeRectangle.Width * 0.03f);
			SizeF sizeF1 = g.MeasureString(Text, LabelFont);
			Color color1 = LabelColor;
			g.DrawString(Text, LabelFont, (Brush)new SolidBrush(color1), (float)point3.X - sizeF1.Width * 0.5f, (float)point3.Y - sizeF1.Height * 0.5f);
			Point point4 = new Point();
			point4.X = point1.X;
			point4.Y = point1.Y - (int)((double)gaugeRectangle.Height * -0.1);
			fontLabel = new Font(fontLabel.FontFamily.Name, (float)gaugeRectangle.Width * 0.03f);
			sizeF1 = g.MeasureString(Units, LabelFont);
			Color color2 = LabelColor;
			g.DrawString(Units, LabelFont, (Brush)new SolidBrush(color2), (float)point4.X - sizeF1.Width * 0.5f, (float)point4.Y - sizeF1.Height * 0.5f);
			Rectangle rect3 = new Rectangle();
			rect3.X = point1.X - (int)((double)gaugeRectangle.Width * 0.02);
			rect3.Y = point1.Y - (int)((double)gaugeRectangle.Width * 0.02);
			rect3.Width = (int)((double)gaugeRectangle.Width * 0.04);
			rect3.Height = (int)((double)gaugeRectangle.Width * 0.04);
			SolidBrush solidBrush = new SolidBrush(NeedleColor);
			g.FillEllipse((Brush)solidBrush, rect3);
			g.FillPolygon((Brush)solidBrush, getNeedlePolygon(Value, gaugeRectangle));
		}

		private Point[] getNeedlePolygon(double dGaugeValue, Rectangle rcGauge)
		{
			Point point = new Point();
			point.X = rcGauge.Width / 2 + rcGauge.X;
			point.Y = rcGauge.Height / 2 + rcGauge.Y;
			double num1 = NeedleSweepAngle * 0.5 + 90.0 - (dGaugeValue - RangeStart) / (RangeEnd + RangeStart) * NeedleSweepAngle;
			double num2 = (double)rcGauge.Width * 0.32;
			Point[] pointArray = new Point[3];
			double num3 = num1 * (Math.PI / 180.0);
			pointArray[0].X = (int)(Math.Cos(num3) * num2) + point.X;
			pointArray[0].Y = point.Y - (int)(Math.Sin(num3) * num2);
			double num4 = (num1 + 90.0) * (Math.PI / 180.0);
			pointArray[2].X = point.X - (int)((double)rcGauge.Width * Math.Cos(num4) * -0.015);
			pointArray[2].Y = point.Y - (int)((double)rcGauge.Width * Math.Sin(num4) * 0.015);
			double num5 = (num1 - 90.0) * (Math.PI / 180.0);
			pointArray[1].X = point.X - (int)((double)rcGauge.Width * Math.Cos(num5) * -0.015);
			pointArray[1].Y = point.Y - (int)((double)rcGauge.Width * Math.Sin(num5) * 0.015);
			return pointArray;
		}

		public Image getImage()
		{
			Bitmap bitmap = new Bitmap(Width, Height);
			PaintControl(Graphics.FromImage((Image)bitmap));
			return bitmap as Image;
		}

		public void Gauge_Resize(object sender, EventArgs e)
		{
			Refresh();
		}
	}
}