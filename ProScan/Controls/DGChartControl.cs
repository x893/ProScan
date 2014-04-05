using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DGChart
{
	public class DGChartControl : UserControl
	{
		private string strName;
		private Color colorGrid = new Color();
		private Color colorBg = new Color();
		private Color colorAxis = new Color();
		private string xLabel;
		private string yLabel;
		private Font fontAxis;
		private int penWidth;
		private DGChartControl.DrawModeType drawMode;
		private int borderTop;
		private int borderLeft;
		private int borderBottom;
		private int borderRight;
		private double xRangeStart;
		private double xRangeEnd;
		private double yRangeStart;
		private double yRangeEnd;
		private double xGrid;
		private double yGrid;
		private int xLogBase;
		private int yLogBase;
		private bool showData1;
		private bool showData2;
		private bool showData3;
		private bool showData4;
		private bool showData5;
		private Color colorSet1 = new Color();
		private Color colorSet2 = new Color();
		private Color colorSet3 = new Color();
		private Color colorSet4 = new Color();
		private Color colorSet5 = new Color();
		private double[] xData1;
		private double[] yData1;
		private double[] xData2;
		private double[] yData2;
		private double[] xData3;
		private double[] yData3;
		private double[] xData4;
		private double[] yData4;
		private double[] xData5;
		private double[] yData5;
		private Container components;

		public DGChartControl()
		{
			InitializeComponent();

			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			UpdateStyles();
		}

		[Description("The y values for the fifth data set.")]
		[Category("Chart")]
		public double[] YData5
		{
			get { return yData5; }
			set
			{
				yData5 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The x values for the fifth data set.")]
		public double[] XData5
		{
			get { return xData5; }
			set
			{
				xData5 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The y values for the fourth data set.")]
		public double[] YData4
		{
			get { return yData4; }
			set
			{
				yData4 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The x values for the fourth data set.")]
		public double[] XData4
		{
			get { return xData4; }
			set
			{
				xData4 = value;
				Invalidate();
			}
		}

		[Description("The y values for the third data set.")]
		[Category("Chart")]
		public double[] YData3
		{
			get { return yData3; }
			set
			{
				yData3 = value;
				Invalidate();
			}
		}

		[Description("The x values for the third data set.")]
		[Category("Chart")]
		public double[] XData3
		{
			get { return xData3; }
			set
			{
				xData3 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The y values for the second data set.")]
		public double[] YData2
		{
			get { return yData2; }
			set
			{
				yData2 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The x values for the second data set.")]
		public double[] XData2
		{
			get { return xData2; }
			set
			{
				xData2 = value;
				Invalidate();
			}
		}

		[Description("The y values for the first data set.")]
		[Category("Chart")]
		public double[] YData1
		{
			get { return yData1; }
			set
			{
				yData1 = value;
				Invalidate();
			}
		}

		[Description("The x values for the first data set.")]
		[Category("Chart")]
		public double[] XData1
		{
			get { return xData1; }
			set
			{
				xData1 = value;
				Invalidate();
			}
		}

		[DefaultValue("Magenta")]
		[Category("Chart")]
		[Description("The color to represent the fifth data set.")]
		public Color ColorSet5
		{
			get { return colorSet5; }
			set
			{
				colorSet5 = value;
				Invalidate();
			}
		}

		[Description("The color to represent the fourth data set.")]
		[Category("Chart")]
		[DefaultValue("Gold")]
		public Color ColorSet4
		{
			get { return colorSet4; }
			set
			{
				colorSet4 = value;
				Invalidate();
			}
		}

		[DefaultValue("Lime")]
		[Category("Chart")]
		[Description("The color to represent the third data set.")]
		public Color ColorSet3
		{
			get { return colorSet3; }
			set
			{
				colorSet3 = value;
				Invalidate();
			}
		}

		[DefaultValue("Red")]
		[Description("The color to represent the second data set.")]
		[Category("Chart")]
		public Color ColorSet2
		{
			get { return colorSet2; }
			set
			{
				colorSet2 = value;
				Invalidate();
			}
		}

		[Description("The color to represent the first data set.")]
		[DefaultValue("DarkBlue")]
		[Category("Chart")]
		public Color ColorSet1
		{
			get { return colorSet1; }
			set
			{
				colorSet1 = value;
				Invalidate();
			}
		}

		[DefaultValue(0)]
		[Description("Display the fifth data set?")]
		[Category("Chart")]
		public bool ShowData5
		{
			get { return showData5; }
			set
			{
				showData5 = value;
				Invalidate();
			}
		}

		[DefaultValue(0)]
		[Description("Display the fourth data set?")]
		[Category("Chart")]
		public bool ShowData4
		{
			get { return showData4; }
			set
			{
				showData4 = value;
				Invalidate();
			}
		}

		[Description("Display the third data set?")]
		[Category("Chart")]
		[DefaultValue(0)]
		public bool ShowData3
		{
			get { return showData3; }
			set
			{
				showData3 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("Display the second data set?")]
		[DefaultValue(0)]
		public bool ShowData2
		{
			get { return showData2; }
			set
			{
				showData2 = value;
				Invalidate();
			}
		}

		[Description("Display the first data set?")]
		[Category("Chart")]
		[DefaultValue(1)]
		public bool ShowData1
		{
			get { return showData1; }
			set
			{
				showData1 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(0)]
		[Description("The base for log. views in y direction. If < 2 then a linear view is displayed")]
		public int YLogBase
		{
			get { return yLogBase; }
			set
			{
				yLogBase = value;
				Invalidate();
			}
		}

		[Description("The base for log. views in x direction. If < 2 then a linear view is displayed")]
		[DefaultValue(0)]
		[Category("Chart")]
		public int XLogBase
		{
			get { return xLogBase; }
			set
			{
				xLogBase = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The spacing for the linear grid in y direction. Ingnored for log. views")]
		[DefaultValue(10)]
		public double YGrid
		{
			get { return yGrid; }
			set
			{
				yGrid = value;
				Invalidate();
			}
		}

		[DefaultValue(10)]
		[Category("Chart")]
		[Description("The spacing for the linear grid in x direction. Ingnored for log. views")]
		public double XGrid
		{
			get { return xGrid; }
			set
			{
				xGrid = value;
				Invalidate();
			}
		}

		[Description("The end of the data range on the y axis")]
		[DefaultValue(100)]
		[Category("Chart")]
		public double YRangeEnd
		{
			get { return yRangeEnd; }
			set
			{
				yRangeEnd = value;
				Invalidate();
			}
		}

		[Description("The start of the data range on the y axis")]
		[Category("Chart")]
		[DefaultValue(0)]
		public double YRangeStart
		{
			get { return yRangeStart; }
			set
			{
				yRangeStart = value;
				Invalidate();
			}
		}

		[DefaultValue(100)]
		[Description("The end of the data range on the x axis")]
		[Category("Chart")]
		public double XRangeEnd
		{
			get { return xRangeEnd; }
			set
			{
				xRangeEnd = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(0)]
		[Description("The start of the data range on the x axis")]
		public double XRangeStart
		{
			get { return xRangeStart; }
			set
			{
				xRangeStart = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(30)]
		[Description("The internal border at the right")]
		public int BorderRight
		{
			get { return borderRight; }
			set
			{
				borderRight = value;
				Invalidate();
			}
		}

		[Description("The internal border at the bottom")]
		[DefaultValue(50)]
		[Category("Chart")]
		public int BorderBottom
		{
			get { return borderBottom; }
			set
			{
				borderBottom = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(50)]
		[Description("The internal border at the left")]
		public int BorderLeft
		{
			get { return borderLeft; }
			set
			{
				borderLeft = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(30)]
		[Description("The internal border at the top")]
		public int BorderTop
		{
			get { return borderTop; }
			set
			{
				borderTop = value;
				Invalidate();
			}
		}

		[Description("Draw mode for the data points")]
		[Category("Chart")]
		[DefaultValue("DrawModeType::Line")]
		public DGChartControl.DrawModeType DrawMode
		{
			get { return drawMode; }
			set
			{
				drawMode = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(2)]
		[Description("The width of the data lines.")]
		public int PenWidth
		{
			get { return penWidth; }
			set
			{
				penWidth = value;
				Invalidate();
			}
		}

		[DefaultValue("Arial, 8pt")]
		[Description("The font for the text")]
		[Category("Chart")]
		public Font FontAxis
		{
			get { return fontAxis; }
			set
			{
				fontAxis = value;
				Invalidate();
			}
		}

		[Description("The y axis label.")]
		[DefaultValue("")]
		[Category("Chart")]
		public string YLabel
		{
			get { return yLabel; }
			set
			{
				yLabel = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue("")]
		[Description("The x axis label.")]
		public string XLabel
		{
			get { return xLabel; }
			set
			{
				xLabel = value;
				Invalidate();
			}
		}

		[DefaultValue("Black")]
		[Category("Chart")]
		[Description("The color of the axes and text.")]
		public Color ColorAxis
		{
			get { return colorAxis; }
			set
			{
				colorAxis = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The background color.")]
		[DefaultValue("White")]
		public Color ColorBg
		{
			get { return colorBg; }
			set
			{
				colorBg = value;
				Invalidate();
			}
		}

		[DefaultValue("LightGray")]
		[Category("Chart")]
		[Description("The color of the grid lines.")]
		public Color ColorGrid
		{
			get { return colorGrid; }
			set
			{
				colorGrid = value;
				Invalidate();
			}
		}

		[Description("The name to display above the chart.")]
		[DefaultValue("")]
		[Category("Chart")]
		public override string Text
		{
			get { return strName; }
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
			colorGrid = Color.LightGray;
			colorBg = Color.White;
			colorAxis = Color.Black;
			fontAxis = new Font("Arial", 8f);
			penWidth = 2;
			drawMode = DGChartControl.DrawModeType.Line;
			borderTop = 30;
			borderLeft = 50;
			borderBottom = 50;
			borderRight = 30;
			xRangeStart = 0.0;
			xRangeEnd = 100.0;
			yRangeStart = 0.0;
			yRangeEnd = 100.0;
			xGrid = 10.0;
			yGrid = 10.0;
			xLogBase = 0;
			yLogBase = 0;
			showData1 = true;
			showData2 = false;
			showData3 = false;
			showData4 = false;
			showData5 = false;
			colorSet1 = Color.DarkBlue;
			colorSet2 = Color.Red;
			colorSet3 = Color.Lime;
			colorSet4 = Color.Gold;
			colorSet5 = Color.Magenta;
			Resize += new EventHandler(Chart_Resize);
			Paint += new PaintEventHandler(Chart_Paint);
		}

		private void Chart_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				if (xRangeEnd <= xRangeStart || yRangeEnd <= yRangeStart)
					return;
				if (xLogBase < 2)
				{
					if (xGrid <= 0.0)
						return;
				}
				else if (xRangeStart <= 0.0)
					return;
				if (yLogBase < 2)
				{
					if (yGrid <= 0.0)
						return;
				}
				else if (yRangeStart <= 0.0)
					return;
				Graphics graphics = e.Graphics;
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				PaintControl(graphics);
			}
			catch (Exception)
			{
			}
		}

		private void PaintControl(Graphics g)
		{
			double[] numArray1 = (double[])null;
			double[] numArray2 = (double[])null;
			try
			{
				Rectangle clientRectangle = ClientRectangle;
				Color color1 = colorBg;
				g.FillRectangle((Brush)new SolidBrush(color1), clientRectangle);
				Pen pen1 = new Pen(colorGrid, 1f);
				Pen pen2 = new Pen(colorAxis, 1f);
				SolidBrush solidBrush = new SolidBrush(colorAxis);
				int num1 = clientRectangle.Left + borderLeft;
				int num2 = clientRectangle.Top + borderTop;
				int width = clientRectangle.Width - borderLeft - borderRight;
				int height = clientRectangle.Height - borderTop - borderBottom;
				int x2 = clientRectangle.Right - borderRight;
				int num3 = clientRectangle.Bottom - borderBottom;
				int num4;
				int num5;
				if (xLogBase < 2)
				{
					num4 = Convert.ToInt32((xRangeEnd - xRangeStart) / xGrid);
					if (num4 == 0)
						num4 = 1;
					num5 = width / num4;
					for (int index = 0; index <= num4; ++index)
					{
						int num6 = index * num5 + num1;
						g.DrawLine(pen1, num6, num2, num6, num3);
						string str = Convert.ToString((xRangeEnd - xRangeStart) * (double)index / (double)num4 + xRangeStart);
						SizeF sizeF = g.MeasureString(str, fontAxis);
						g.DrawString(str, fontAxis, (Brush)solidBrush, (float)num6 - sizeF.Width * 0.5f, sizeF.Height * 0.5f + (float)num3);
					}
				}
				else
				{
					num4 = Convert.ToInt32(Math.Log(xRangeEnd, (double)xLogBase) - Math.Log(xRangeStart, (double)xLogBase));
					if (num4 == 0)
						num4 = 1;
					num5 = width / num4;
					for (int index1 = 0; index1 <= num4; ++index1)
					{
						int num6 = index1 * num5 + num1;
						if (index1 < num4)
						{
							for (int index2 = 1; index2 < xLogBase; ++index2)
							{
								int num7 = Convert.ToInt32(Math.Log((double)index2, (double)xLogBase) * (double)num5);
								int num8 = num6 + num7;
								g.DrawLine(pen1, num8, num2, num8, num3);
							}
						}
						string str = Convert.ToString(Math.Pow((double)xLogBase, Math.Log(xRangeStart, (double)xLogBase) + (double)index1));
						SizeF sizeF = g.MeasureString(str, fontAxis);
						g.DrawString(str, fontAxis, (Brush)solidBrush, (float)num6 - sizeF.Width * 0.5f, sizeF.Height * 0.5f + (float)num3);
					}
				}
				int num9 = num5 * num4;
				int num10;
				int num11;
				if (yLogBase < 2)
				{
					num10 = Convert.ToInt32((yRangeEnd - yRangeStart) / yGrid);
					if (num10 == 0)
						num10 = 1;
					num11 = height / num10;
					for (int index = 0; index <= num10; ++index)
					{
						int num6 = num3 - index * num11;
						g.DrawLine(pen1, num1, num6, x2, num6);
						string str = Convert.ToString((yRangeEnd - yRangeStart) * (double)index / (double)num10 + yRangeStart);
						SizeF sizeF = g.MeasureString(str, fontAxis);
						g.DrawString(str, fontAxis, (Brush)solidBrush, (float)((double)num1 - (double)sizeF.Width - (double)sizeF.Height * 0.25), (float)num6 - sizeF.Height * 0.5f);
					}
				}
				else
				{
					num10 = Convert.ToInt32(Math.Log(yRangeEnd, (double)yLogBase) - Math.Log(yRangeStart, (double)yLogBase));
					if (num10 == 0)
						num10 = 1;
					num11 = height / num10;
					for (int index1 = 0; index1 <= num10; ++index1)
					{
						int num6 = num3 - index1 * num11;
						if (index1 < num10)
						{
							for (int index2 = 1; index2 < yLogBase; ++index2)
							{
								int num7 = Convert.ToInt32(Math.Log((double)index2, (double)yLogBase) * (double)num11);
								int num8 = num6 - num7;
								g.DrawLine(pen1, num1, num8, x2, num8);
							}
						}
						string str = Convert.ToString(Math.Pow((double)yLogBase, Math.Log(yRangeStart, (double)yLogBase) + (double)index1));
						SizeF sizeF = g.MeasureString(str, fontAxis);
						g.DrawString(str, fontAxis, (Brush)solidBrush, (float)((double)num1 - (double)sizeF.Width - (double)sizeF.Height * 0.25), (float)num6 - sizeF.Height * 0.5f);
					}
				}
				int num12 = num11 * num10;
				g.DrawRectangle(pen2, num1, num2, width, height);
				SizeF sizeF1 = g.MeasureString(xLabel, fontAxis);
				g.DrawString(xLabel, fontAxis, (Brush)solidBrush, (float)((x2 - num1) / 2 + num1) - sizeF1.Width * 0.5f, sizeF1.Height * 2f + (float)num3);
				int num13 = num12;
				int num14 = num9;
				StringFormat format = new StringFormat();
				format.Alignment = StringAlignment.Center;
				RectangleF layoutRectangle = new RectangleF();
				layoutRectangle = new RectangleF(0.0f, 5f, (float)Width, 20f);
				g.DrawString(strName, fontAxis, (Brush)solidBrush, layoutRectangle, format);
				for (int index1 = 0; index1 < 5; ++index1)
				{
					Color color2 = new Color();
					bool flag = false;
					switch (index1)
					{
						case 0:
							numArray1 = xData1;
							numArray2 = yData1;
							flag = showData1;
							color2 = colorSet1;
							break;
						case 1:
							numArray1 = xData2;
							numArray2 = yData2;
							flag = showData2;
							color2 = colorSet2;
							break;
						case 2:
							numArray1 = xData3;
							numArray2 = yData3;
							flag = showData3;
							color2 = colorSet3;
							break;
						case 3:
							numArray1 = xData4;
							numArray2 = yData4;
							flag = showData4;
							color2 = colorSet4;
							break;
						case 4:
							numArray1 = xData5;
							numArray2 = yData5;
							flag = showData5;
							color2 = colorSet5;
							break;
					}
					if (flag && numArray1 != null && (numArray2 != null && numArray1.Length == numArray2.Length))
					{
						Point[] pointArray = new Point[numArray1.Length];
						Point point1 = new Point();
						point1 = new Point(num1, num3);
						Point point2 = point1;
						for (int index2 = 0; index2 < pointArray.Length; ++index2)
						{
							try
							{
								pointArray[index2].X = xLogBase >= 2 ? Convert.ToInt32((Math.Log(numArray1[index2], (double)xLogBase) - Math.Log(xRangeStart, (double)xLogBase)) / (Math.Log(xRangeEnd, (double)xLogBase) - Math.Log(xRangeStart, (double)xLogBase)) * (double)num14 + (double)num1) : Convert.ToInt32((numArray1[index2] - xRangeStart) / (xRangeEnd - xRangeStart) * (double)num14 + (double)num1);
								pointArray[index2].Y = yLogBase >= 2 ? Convert.ToInt32((double)num3 - (Math.Log(numArray2[index2], (double)yLogBase) - Math.Log(yRangeStart, (double)yLogBase)) / (Math.Log(yRangeEnd, (double)yLogBase) - Math.Log(yRangeStart, (double)yLogBase)) * (double)num13) : Convert.ToInt32((double)num3 - (numArray2[index2] - yRangeStart) / (yRangeEnd - yRangeStart) * (double)num13);
								point2 = pointArray[index2];
							}
							catch (Exception)
							{
								pointArray[index2] = point2;
							}
						}
						Pen pen3 = new Pen(color2, (float)penWidth);
						for (int index2 = 0; index2 < pointArray.Length; ++index2)
						{
							switch (drawMode)
							{
								case DGChartControl.DrawModeType.Dot:
									g.DrawEllipse(pen3, pointArray[index2].X - penWidth / 2, pointArray[index2].Y - penWidth / 2, penWidth, penWidth);
									break;
								case DGChartControl.DrawModeType.Bar:
									Point pt1 = new Point();
									pt1 = new Point(pointArray[index2].X, num3);
									g.DrawLine(pen3, pt1, pointArray[index2]);
									break;
								default:
									if (index2 > 0)
									{
										g.DrawLine(pen3, pointArray[index2 - 1], pointArray[index2]);
										break;
									}
									else
										break;
							}
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public Image getImage()
		{
			Bitmap bitmap = new Bitmap(Width, Height);
			PaintControl(Graphics.FromImage((Image)bitmap));
			return bitmap as Image;
		}

		public void Chart_Resize(object sender, EventArgs e)
		{
			Refresh();
		}

		public enum DrawModeType
		{
			Line = 1,
			Dot = 2,
			Bar = 3,
		}
	}
}
