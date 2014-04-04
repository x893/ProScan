using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DGChart
{
	public class DynoControl : UserControl
	{
		private string strName;
		private Color colorGrid;
		private Color colorBg;
		private Color colorAxis;
		private string xLabel;
		private string yLabel;
		private Font fontAxis;
		private int penWidth;
		private DynoControl.DrawModeType drawMode;
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
		private Color colorSet1;
		private Color colorSet2;
		private Color colorSet3;
		private Color colorSet4;
		private Color colorSet5;
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
		private Image m_imgLogo;
		private double m_dMaxHpValue;
		private double m_dMaxHpRpm;
		private double m_dMaxTqValue;
		private double m_dMaxTqRpm;
		private Container components;

		[Description("The logo to display in the top left corner.")]
		[Category("Chart")]
		public Image Logo
		{
			get
			{
				return m_imgLogo;
			}
			set
			{
				m_imgLogo = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The y values for the fifth data set.")]
		public double[] YData5
		{
			get
			{
				return yData5;
			}
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
			get
			{
				return xData5;
			}
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
			get
			{
				return yData4;
			}
			set
			{
				yData4 = value;
				Invalidate();
			}
		}

		[Description("The x values for the fourth data set.")]
		[Category("Chart")]
		public double[] XData4
		{
			get
			{
				return xData4;
			}
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
			get
			{
				return yData3;
			}
			set
			{
				yData3 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The x values for the third data set.")]
		public double[] XData3
		{
			get
			{
				return xData3;
			}
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
			get
			{
				return yData2;
			}
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
			get
			{
				return xData2;
			}
			set
			{
				xData2 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The y values for the first data set.")]
		public double[] YData1
		{
			get
			{
				return yData1;
			}
			set
			{
				yData1 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The x values for the first data set.")]
		public double[] XData1
		{
			get
			{
				return xData1;
			}
			set
			{
				xData1 = value;
				Invalidate();
			}
		}

		[Description("The color to represent the fifth data set.")]
		[DefaultValue("Magenta")]
		[Category("Chart")]
		public Color ColorSet5
		{
			get
			{
				return colorSet5;
			}
			set
			{
				colorSet5 = value;
				Invalidate();
			}
		}

		[DefaultValue("Gold")]
		[Category("Chart")]
		[Description("The color to represent the fourth data set.")]
		public Color ColorSet4
		{
			get
			{
				return colorSet4;
			}
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
			get
			{
				return colorSet3;
			}
			set
			{
				colorSet3 = value;
				Invalidate();
			}
		}

		[Description("The color to represent the second data set.")]
		[DefaultValue("Red")]
		[Category("Chart")]
		public Color ColorSet2
		{
			get
			{
				return colorSet2;
			}
			set
			{
				colorSet2 = value;
				Invalidate();
			}
		}

		[DefaultValue("DarkBlue")]
		[Description("The color to represent the first data set.")]
		[Category("Chart")]
		public Color ColorSet1
		{
			get
			{
				return colorSet1;
			}
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
			get
			{
				return showData5;
			}
			set
			{
				showData5 = value;
				Invalidate();
			}
		}

		[Description("Display the fourth data set?")]
		[Category("Chart")]
		[DefaultValue(0)]
		public bool ShowData4
		{
			get
			{
				return showData4;
			}
			set
			{
				showData4 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("Display the third data set?")]
		[DefaultValue(0)]
		public bool ShowData3
		{
			get
			{
				return showData3;
			}
			set
			{
				showData3 = value;
				Invalidate();
			}
		}

		[Description("Display the second data set?")]
		[Category("Chart")]
		[DefaultValue(0)]
		public bool ShowData2
		{
			get
			{
				return showData2;
			}
			set
			{
				showData2 = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(1)]
		[Description("Display the first data set?")]
		public bool ShowData1
		{
			get
			{
				return showData1;
			}
			set
			{
				showData1 = value;
				Invalidate();
			}
		}

		[DefaultValue(0)]
		[Description("The base for log. views in y direction. If < 2 then a linear view is displayed")]
		[Category("Chart")]
		public int YLogBase
		{
			get
			{
				return yLogBase;
			}
			set
			{
				yLogBase = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[Description("The base for log. views in x direction. If < 2 then a linear view is displayed")]
		[DefaultValue(0)]
		public int XLogBase
		{
			get
			{
				return xLogBase;
			}
			set
			{
				xLogBase = value;
				Invalidate();
			}
		}

		[DefaultValue(10)]
		[Description("The spacing for the linear grid in y direction. Ingnored for log. views")]
		[Category("Chart")]
		public double YGrid
		{
			get
			{
				return yGrid;
			}
			set
			{
				yGrid = value;
				Invalidate();
			}
		}

		[Description("The spacing for the linear grid in x direction. Ingnored for log. views")]
		[DefaultValue(10)]
		[Category("Chart")]
		public double XGrid
		{
			get
			{
				return xGrid;
			}
			set
			{
				xGrid = value;
				Invalidate();
			}
		}

		[Description("The end of the data range on the y axis")]
		[Category("Chart")]
		[DefaultValue(100)]
		public double YRangeEnd
		{
			get
			{
				return yRangeEnd;
			}
			set
			{
				yRangeEnd = value;
				Invalidate();
			}
		}

		[DefaultValue(0)]
		[Description("The start of the data range on the y axis")]
		[Category("Chart")]
		public double YRangeStart
		{
			get
			{
				return yRangeStart;
			}
			set
			{
				yRangeStart = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue(100)]
		[Description("The end of the data range on the x axis")]
		public double XRangeEnd
		{
			get
			{
				return xRangeEnd;
			}
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
			get
			{
				return xRangeStart;
			}
			set
			{
				xRangeStart = value;
				Invalidate();
			}
		}

		[Description("The internal border at the right")]
		[DefaultValue(30)]
		[Category("Chart")]
		public int BorderRight
		{
			get
			{
				return borderRight;
			}
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
			get
			{
				return borderBottom;
			}
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
			get
			{
				return borderLeft;
			}
			set
			{
				borderLeft = value;
				Invalidate();
			}
		}

		[Description("The internal border at the top")]
		[DefaultValue(30)]
		[Category("Chart")]
		public int BorderTop
		{
			get
			{
				return borderTop;
			}
			set
			{
				borderTop = value;
				Invalidate();
			}
		}

		[DefaultValue("DrawModeType::Line")]
		[Description("Draw mode for the data points")]
		[Category("Chart")]
		public DynoControl.DrawModeType DrawMode
		{
			get
			{
				return drawMode;
			}
			set
			{
				drawMode = value;
				Invalidate();
			}
		}

		[DefaultValue(2)]
		[Description("The width of the data lines.")]
		[Category("Chart")]
		public int PenWidth
		{
			get
			{
				return penWidth;
			}
			set
			{
				penWidth = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue("Arial, 8pt")]
		[Description("The font for the text")]
		public Font FontAxis
		{
			get
			{
				return fontAxis;
			}
			set
			{
				fontAxis = value;
				Invalidate();
			}
		}

		[Description("The color of the axes and text.")]
		[Category("Chart")]
		[DefaultValue("Black")]
		public Color ColorAxis
		{
			get
			{
				return colorAxis;
			}
			set
			{
				colorAxis = value;
				Invalidate();
			}
		}

		[DefaultValue("White")]
		[Category("Chart")]
		[Description("The background color.")]
		public Color ColorBg
		{
			get
			{
				return colorBg;
			}
			set
			{
				colorBg = value;
				Invalidate();
			}
		}

		[Description("The color of the grid lines.")]
		[DefaultValue("LightGray")]
		[Category("Chart")]
		public Color ColorGrid
		{
			get
			{
				return colorGrid;
			}
			set
			{
				colorGrid = value;
				Invalidate();
			}
		}

		[Category("Chart")]
		[DefaultValue("")]
		[Description("The information to display above the chart.")]
		public string Label
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

		public DynoControl()
		{
			colorGrid = new Color();
			colorBg = new Color();
			colorAxis = new Color();
			colorSet1 = new Color();
			colorSet2 = new Color();
			colorSet3 = new Color();
			colorSet4 = new Color();
			colorSet5 = new Color();
			InitializeComponent();
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private unsafe void InitializeComponent()
		{
			colorGrid = Color.LightGray;
			colorBg = Color.White;
			colorAxis = Color.Black;
			fontAxis = new Font("Arial", 8f);
			penWidth = 2;
			drawMode = DynoControl.DrawModeType.Line;
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
				SizeF sizeF1 = g.MeasureString("RPM (x 1000)", fontAxis);
				g.DrawString("RPM (x 1000)", fontAxis, (Brush)solidBrush, (float)((x2 - num1) / 2 + num1) - sizeF1.Width * 0.5f, sizeF1.Height * 2f + (float)num3);
				int num13 = num12;
				int num14 = num9;
				StringFormat format = new StringFormat();
				format.Alignment = StringAlignment.Far;
				format.LineAlignment = StringAlignment.Far;
				RectangleF layoutRectangle1 = new RectangleF();
				layoutRectangle1 = new RectangleF(235f, 10f, (float)(Width - (int)byte.MaxValue), 75f);
				g.DrawString(strName, fontAxis, (Brush)solidBrush, layoutRectangle1, format);
				g.DrawImage(Logo, 35, 10, 200, 75);
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
							m_dMaxHpValue = 0.0;
							m_dMaxHpRpm = 0.0;
							break;
						case 1:
							numArray1 = xData2;
							numArray2 = yData2;
							flag = showData2;
							color2 = colorSet2;
							m_dMaxTqValue = 0.0;
							m_dMaxTqRpm = 0.0;
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
					if (flag && numArray1 != null && numArray2 != null && numArray1.Length == numArray2.Length)
					{
						Point[] pointArray = new Point[numArray1.Length];
						Point point1 = new Point();
						point1 = new Point(num1, num3);
						Point point2 = point1;
						for (int index2 = 0; index2 < pointArray.Length; ++index2)
						{
							try
							{
								if (index1 == 0)
								{
									if (numArray2[index2] > m_dMaxHpValue)
									{
										m_dMaxHpValue = numArray2[index2];
										m_dMaxHpRpm = numArray1[index2];
									}
								}
								else if (numArray2[index2] > m_dMaxTqValue)
								{
									m_dMaxTqValue = numArray2[index2];
									m_dMaxTqRpm = numArray1[index2];
								}
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
								case DynoControl.DrawModeType.Dot:
									g.DrawEllipse(pen3, pointArray[index2].X - penWidth / 2, pointArray[index2].Y - penWidth / 2, penWidth, penWidth);
									break;
								case DynoControl.DrawModeType.Bar:
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
				string str1 = "Horsepower (HP)";
				string str2 = "Torque (LB*FT)";
				SizeF sizeF2 = g.MeasureString(str1, fontAxis);
				SizeF sizeF3 = g.MeasureString(str2, fontAxis);
				Rectangle rect1 = new Rectangle();
				rect1 = new Rectangle(borderLeft + 5, -25 - (int)sizeF2.Height - borderBottom + Height, (int)((double)sizeF3.Width + (double)sizeF2.Width) + 80, (int)sizeF2.Height + 20);
				g.FillRectangle(Brushes.White, rect1);
				g.DrawRectangle(new Pen(Brushes.Black), rect1);
				Pen pen4 = new Pen(colorSet1);
				Pen pen5 = new Pen(colorSet2);
				g.DrawString(str1, fontAxis, pen4.Brush, (float)(rect1.Left + 35), (float)(rect1.Top + 10));
				g.DrawString(str2, fontAxis, pen5.Brush, (float)(rect1.Left + 70) + sizeF2.Width, (float)(rect1.Top + 10));
				Rectangle rect2 = new Rectangle();
				rect2 = new Rectangle(rect1.Left + 10, rect1.Top + 10, 20, (int)sizeF2.Height);
				Rectangle rect3 = new Rectangle();
				rect3 = new Rectangle(rect1.Left + (int)sizeF2.Width + 45, rect1.Top + 10, 20, (int)sizeF3.Height);
				g.FillRectangle(pen4.Brush, rect2);
				g.FillRectangle(pen5.Brush, rect3);
				string str3 = m_dMaxHpValue.ToString("####.##") + " RWHP @ " + (m_dMaxHpRpm * 1000.0).ToString("#####") + " RPM" + "\r\n\r\n" + m_dMaxTqValue.ToString("####.##")
					+ " LB*FT @ " + (m_dMaxTqRpm * 1000.0).ToString("#####") + " RPM";
				SizeF sizeF4 = g.MeasureString(str3, fontAxis);
				Rectangle rect4 = new Rectangle();
				rect4 = new Rectangle(-25 - (int)sizeF4.Width - borderRight + Width, -25 - (int)sizeF4.Height - borderBottom + Height, (int)sizeF4.Width + 20, (int)sizeF4.Height + 20);
				g.FillRectangle(Brushes.White, rect4);
				g.DrawRectangle(new Pen(Brushes.Black), rect4);
				RectangleF layoutRectangle2 = new RectangleF();
				layoutRectangle2 = new RectangleF((float)((double)(Width - borderRight) - (double)sizeF4.Width - 25.0), (float)((double)(Height - borderBottom) - (double)sizeF4.Height - 25.0), sizeF4.Width + 20f, sizeF4.Height + 20f);
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Center;
				g.DrawString(str3, fontAxis, (Brush)solidBrush, layoutRectangle2, format);
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