using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class SensorDisplayControl : UserControl
	{
		private string m_Name;
		private string m_Value;
		private string m_EnglishDisplay;
		private string m_MetricDisplay;
		private int m_iDisplayMode;

		public SensorDisplayControl()
		{
			InitializeComponent();

			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			UpdateStyles();
		}

		[DefaultValue("Metric Display")]
		[Category("SensorDisplay")]
		[Description("Sets/returns the metric display of the sensor.")]
		public string MetricDisplay
		{
			get { return m_MetricDisplay; }
			set
			{
				m_MetricDisplay = value;
				m_Value = m_iDisplayMode != 1
					? (m_iDisplayMode != 2
						? m_EnglishDisplay + " (" + m_MetricDisplay + ")"
						: m_MetricDisplay)
					: m_EnglishDisplay;
				Invalidate();
			}
		}

		[Category("SensorDisplay")]
		[DefaultValue("English Display")]
		[Description("Sets/returns the english display of the sensor.")]
		public string EnglishDisplay
		{
			get { return m_EnglishDisplay; }
			set
			{
				m_EnglishDisplay = value;
				m_Value = m_iDisplayMode != 1
					? (m_iDisplayMode != 2
						? m_EnglishDisplay + " (" + m_MetricDisplay + ")"
						: m_MetricDisplay)
					: m_EnglishDisplay;
				Invalidate();
			}
		}

		[Description("Sets/returns the name of the sensor.")]
		[Category("SensorDisplay")]
		[DefaultValue("Sensor Name")]
		public string Title
		{
			get { return m_Name; }
			set
			{
				m_Name = value;
				Invalidate();
			}
		}

		public void SetDisplayMode(int iMode)
		{
			m_iDisplayMode = iMode;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// SensorDisplayControl
			// 
			this.Name = "SensorDisplayControl";
			this.Size = new System.Drawing.Size(260, 65);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SensorDisplayControl_Paint);
			this.Resize += new System.EventHandler(this.SensorDisplayControl_Resize);
			this.ResumeLayout(false);

		}

		private void PaintControl(Graphics g)
		{
			Rectangle rectangle = ClientRectangle;

			LinearGradientBrush gradient;
			gradient = new LinearGradientBrush(rectangle, Color.SlateGray, Color.White, 225f, true);
			g.FillRectangle(gradient, ClientRectangle);

			gradient = new LinearGradientBrush(rectangle, Color.SlateGray, Color.White, 45f, true);
			rectangle.Inflate(-5, -5);
			g.FillRectangle(gradient, rectangle);

			rectangle.Inflate(-5, -5);
			gradient = new LinearGradientBrush(rectangle, Color.White, Color.AntiqueWhite, 90f, true);
			g.FillRectangle(gradient, rectangle);

			rectangle = ClientRectangle;
			rectangle.Inflate(-10, -10);

			float emSize = (float)rectangle.Width * 0.04f;
			Font font = new Font("Arial", emSize, FontStyle.Bold);
			SizeF sizeF;
			for (sizeF = g.MeasureString(m_Name, font);
				sizeF.Width > (float)rectangle.Width || sizeF.Height > (float)(rectangle.Height / 2);
				sizeF = g.MeasureString(m_Name, font)
				)
			{
				font.Dispose();
				emSize -= 0.1f;
				font = new Font("Arial", emSize, FontStyle.Bold);
			}
			Point point1 = new Point(
				(int)((double)((rectangle.Right + rectangle.Left) / 2) - (double)sizeF.Width * 0.5),
				(int)(((double)(rectangle.Height / 2) - (double)sizeF.Height) * 0.5 + (double)rectangle.Top)
				);
			g.DrawString(m_Name, font, new SolidBrush(Color.Black), point1.X, point1.Y);

			emSize = (float)rectangle.Width * 0.04f;
			Font font2 = new Font("Arial", emSize, FontStyle.Bold);
			for (sizeF = g.MeasureString(m_Value, font);
				sizeF.Width > (float)rectangle.Width || sizeF.Height > (float)(rectangle.Height / 2);
				sizeF = g.MeasureString(m_Value, font)
				)
			{
				font.Dispose();
				emSize -= 0.1f;
				font = new Font("Arial", emSize, FontStyle.Bold);
			}
			PointF point2 = (PointF)new Point(
				((int)((double)((rectangle.Right + rectangle.Left) / 2) - (double)sizeF.Width * 0.5)),
				((int)(((double)(rectangle.Height / 2) - (double)sizeF.Height) * 0.5 + (double)((rectangle.Bottom + rectangle.Top) / 2)))
				);
			g.DrawString(m_Value, font, new SolidBrush(Color.DarkGreen), point2);
		}

		private void SensorDisplayControl_Paint(object sender, PaintEventArgs e)
		{
			PaintControl(e.Graphics);
		}

		private void SensorDisplayControl_Resize(object sender, EventArgs e)
		{
			Refresh();
		}
	}
}
