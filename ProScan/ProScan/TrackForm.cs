using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProScan
{
	public class TrackForm : Form
	{
		private static MethodInvoker CallStartTimer = new MethodInvoker(TrackForm.StartTimer);
		private static MethodInvoker CallStopTimer = new MethodInvoker(TrackForm.StopTimer);
		private PictureBox picTrack;
		private static long m_iClockStartTicks;
		private OBDInterface m_obdInterface;
		private static double m_dClock;
		private Timeslip timeslip;
		private ArrayList m_arrKphValues;
		private bool m_bCapture;
		private Button btnStage;
		private Button btnReset;
		private GroupBox groupControls;
		private GroupBox groupTimeslip;
		private Button btnSave;
		private Button btnOpen;
		private PrintDialog printDialog1;
		private PrintPreviewDialog printPreviewDialog1;
		private PageSetupDialog pageSetupDialog1;
		private PrintDocument printDocument1;
		private Button btnPrint;
		private GroupBox groupTimeslipControls;
		private static TrackForm thisForm;
		private GroupBox groupExport;
		private Button btnExportJPEG;
		private RichTextBox richTextSlip;
		private System.Windows.Forms.Timer timerClock1;
		private IContainer components;

		static TrackForm()
		{
		}

		public TrackForm(OBDInterface obd2)
		{
			TrackForm.thisForm = this;
			m_obdInterface = obd2;
			timeslip = new Timeslip();
			timeslip.Vehicle = m_obdInterface.GetActiveProfile().Name;
			InitializeComponent();
			CheckConnection();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackForm));
			picTrack = new System.Windows.Forms.PictureBox();
			timerClock1 = new System.Windows.Forms.Timer(components);
			btnStage = new System.Windows.Forms.Button();
			btnReset = new System.Windows.Forms.Button();
			groupControls = new System.Windows.Forms.GroupBox();
			btnPrint = new System.Windows.Forms.Button();
			groupTimeslip = new System.Windows.Forms.GroupBox();
			richTextSlip = new System.Windows.Forms.RichTextBox();
			btnOpen = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			printDialog1 = new System.Windows.Forms.PrintDialog();
			printDocument1 = new System.Drawing.Printing.PrintDocument();
			printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			groupTimeslipControls = new System.Windows.Forms.GroupBox();
			groupExport = new System.Windows.Forms.GroupBox();
			btnExportJPEG = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(picTrack)).BeginInit();
			groupControls.SuspendLayout();
			groupTimeslip.SuspendLayout();
			groupTimeslipControls.SuspendLayout();
			groupExport.SuspendLayout();
			SuspendLayout();
			// 
			// picTrack
			// 
			picTrack.Image = ((System.Drawing.Image)(resources.GetObject("picTrack.Image")));
			picTrack.Location = new System.Drawing.Point(0, 0);
			picTrack.Name = "picTrack";
			picTrack.Size = new System.Drawing.Size(490, 100);
			picTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			picTrack.TabIndex = 0;
			picTrack.TabStop = false;
			picTrack.Visible = false;
			// 
			// timerClock1
			// 
			timerClock1.Interval = 51;
			timerClock1.Tick += new System.EventHandler(timerClock_Tick);
			// 
			// btnStage
			// 
			btnStage.Location = new System.Drawing.Point(10, 20);
			btnStage.Name = "btnStage";
			btnStage.Size = new System.Drawing.Size(130, 25);
			btnStage.TabIndex = 1;
			btnStage.Text = "&Stage";
			btnStage.Click += new System.EventHandler(btnStage_Click);
			// 
			// btnReset
			// 
			btnReset.Enabled = false;
			btnReset.Location = new System.Drawing.Point(10, 55);
			btnReset.Name = "btnReset";
			btnReset.Size = new System.Drawing.Size(130, 25);
			btnReset.TabIndex = 2;
			btnReset.Text = "&Reset";
			btnReset.Click += new System.EventHandler(btnReset_Click);
			// 
			// groupControls
			// 
			groupControls.Controls.Add(btnReset);
			groupControls.Controls.Add(btnStage);
			groupControls.Location = new System.Drawing.Point(10, 110);
			groupControls.Name = "groupControls";
			groupControls.Size = new System.Drawing.Size(150, 90);
			groupControls.TabIndex = 3;
			groupControls.TabStop = false;
			groupControls.Text = "Control";
			// 
			// btnPrint
			// 
			btnPrint.Location = new System.Drawing.Point(10, 90);
			btnPrint.Name = "btnPrint";
			btnPrint.Size = new System.Drawing.Size(130, 25);
			btnPrint.TabIndex = 4;
			btnPrint.Text = "&Print";
			btnPrint.Click += new System.EventHandler(btnPrint_Click);
			// 
			// groupTimeslip
			// 
			groupTimeslip.Controls.Add(richTextSlip);
			groupTimeslip.Location = new System.Drawing.Point(170, 110);
			groupTimeslip.Name = "groupTimeslip";
			groupTimeslip.Size = new System.Drawing.Size(315, 290);
			groupTimeslip.TabIndex = 4;
			groupTimeslip.TabStop = false;
			// 
			// richTextSlip
			// 
			richTextSlip.BackColor = System.Drawing.SystemColors.Control;
			richTextSlip.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextSlip.Location = new System.Drawing.Point(8, 16);
			richTextSlip.Name = "richTextSlip";
			richTextSlip.ReadOnly = true;
			richTextSlip.Size = new System.Drawing.Size(296, 264);
			richTextSlip.TabIndex = 0;
			richTextSlip.Text = "";
			// 
			// btnOpen
			// 
			btnOpen.Location = new System.Drawing.Point(10, 55);
			btnOpen.Name = "btnOpen";
			btnOpen.Size = new System.Drawing.Size(130, 25);
			btnOpen.TabIndex = 2;
			btnOpen.Text = "&Open";
			btnOpen.Click += new System.EventHandler(btnOpen_Click);
			// 
			// btnSave
			// 
			btnSave.Location = new System.Drawing.Point(10, 20);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(130, 25);
			btnSave.TabIndex = 1;
			btnSave.Text = "&Save";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			// 
			// printDialog1
			// 
			printDialog1.Document = printDocument1;
			// 
			// printDocument1
			// 
			printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_BeginPrint);
			printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.Enabled = true;
			printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			printPreviewDialog1.Name = "printPreviewDialog1";
			printPreviewDialog1.Visible = false;
			// 
			// pageSetupDialog1
			// 
			pageSetupDialog1.Document = printDocument1;
			// 
			// groupTimeslipControls
			// 
			groupTimeslipControls.Controls.Add(btnSave);
			groupTimeslipControls.Controls.Add(btnOpen);
			groupTimeslipControls.Controls.Add(btnPrint);
			groupTimeslipControls.Location = new System.Drawing.Point(10, 210);
			groupTimeslipControls.Name = "groupTimeslipControls";
			groupTimeslipControls.Size = new System.Drawing.Size(150, 125);
			groupTimeslipControls.TabIndex = 5;
			groupTimeslipControls.TabStop = false;
			groupTimeslipControls.Text = "Timeslip";
			// 
			// groupExport
			// 
			groupExport.Controls.Add(btnExportJPEG);
			groupExport.Location = new System.Drawing.Point(10, 345);
			groupExport.Name = "groupExport";
			groupExport.Size = new System.Drawing.Size(150, 55);
			groupExport.TabIndex = 6;
			groupExport.TabStop = false;
			groupExport.Text = "Export";
			// 
			// btnExportJPEG
			// 
			btnExportJPEG.Location = new System.Drawing.Point(10, 20);
			btnExportJPEG.Name = "btnExportJPEG";
			btnExportJPEG.Size = new System.Drawing.Size(130, 25);
			btnExportJPEG.TabIndex = 6;
			btnExportJPEG.Text = "&JPEG";
			btnExportJPEG.Click += new System.EventHandler(btnExportJPEG_Click);
			// 
			// TrackForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(494, 408);
			ControlBox = false;
			Controls.Add(groupExport);
			Controls.Add(groupTimeslipControls);
			Controls.Add(groupTimeslip);
			Controls.Add(groupControls);
			Controls.Add(picTrack);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TrackForm";
			Text = "Race Track Analysis";
			Activated += new System.EventHandler(TrackForm_Activated);
			Paint += new System.Windows.Forms.PaintEventHandler(TrackForm_Paint);
			Resize += new System.EventHandler(TrackForm_Resize);
			((System.ComponentModel.ISupportInitialize)(picTrack)).EndInit();
			groupControls.ResumeLayout(false);
			groupTimeslip.ResumeLayout(false);
			groupTimeslipControls.ResumeLayout(false);
			groupExport.ResumeLayout(false);
			ResumeLayout(false);

		}

		private void TrackForm_Resize(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Maximized;
			picTrack.Width = Width - 10;
			groupTimeslip.Width = Width - 185;
			groupTimeslip.Height = Height - 150;
			richTextSlip.Width = groupTimeslip.Width - 25;
			richTextSlip.Height = groupTimeslip.Height - 35;
			UpdateTimeslip();
			Refresh();
		}

		private void UpdateTimeslip()
		{
			float emSize = richTextSlip.Width * 0.02f;
			if (emSize < 8f)
			{
				emSize = 8f;
			}
			richTextSlip.Text = "";
			richTextSlip.SelectionAlignment = HorizontalAlignment.Center;
			richTextSlip.SelectionFont = new Font("Courier New", emSize + 2f, FontStyle.Bold);
			Color blue = Color.Blue;
			richTextSlip.SelectionColor = blue;
			richTextSlip.AppendText("\r\nProScan Drag Strip\r\n\r\n");
			richTextSlip.SelectionFont = new Font("Courier New", emSize, FontStyle.Bold);
			Color black = Color.Black;
			richTextSlip.SelectionColor = black;
			richTextSlip.AppendText(timeslip.Vehicle + "\r\n");
			string text = timeslip.Date.ToLongDateString() + "\r\n";
			text = text + timeslip.Date.ToLongTimeString() + "\r\n\r\n";
			richTextSlip.SelectionFont = new Font("Courier New", emSize, FontStyle.Regular);
			Color color3 = Color.Black;
			richTextSlip.SelectionColor = color3;
			richTextSlip.AppendText(text);
			richTextSlip.SelectionFont = new Font("Courier New", emSize, FontStyle.Regular);
			Color color = Color.Black;
			richTextSlip.SelectionColor = color;
			richTextSlip.AppendText(timeslip.getStats());

		}

		private void TrackForm_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(picTrack.Image, 0, 0, picTrack.Width, picTrack.Height);
			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
			RectangleF layoutRectangle = new RectangleF();
			layoutRectangle = new RectangleF(2.5f, 2.5f, Convert.ToSingle(base.Width), 100f);
			Color black = Color.Black;
			e.Graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(black), layoutRectangle, format);
			RectangleF ef = new RectangleF();
			ef = new RectangleF(0f, 0f, Convert.ToSingle(base.Width), 100f);
			Color white = Color.White;
			e.Graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(white), ef, format);
		}


		private void timerClock_Tick(object sender, EventArgs e)
		{
			m_dClock = Convert.ToDouble((long)(DateTime.Now.Ticks - m_iClockStartTicks)) * 1E-07;
			Graphics graphics = base.CreateGraphics();
			graphics.DrawImage(picTrack.Image, 0, 0, picTrack.Width, picTrack.Height);
			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
			RectangleF layoutRectangle = new RectangleF();
			layoutRectangle = new RectangleF(2.5f, 2.5f, Convert.ToSingle(base.Width), 100f);
			Color black = Color.Black;
			graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(black), layoutRectangle, format);
			RectangleF ef = new RectangleF();
			ef = new RectangleF(0f, 0f, Convert.ToSingle(base.Width), 100f);
			Color white = Color.White;
			graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(white), ef, format);
		}

		private static void StartTimer()
		{
			TrackForm.m_iClockStartTicks = DateTime.Now.Ticks;
			TrackForm.thisForm.timerClock1.Enabled = true;
		}

		private static void StopTimer()
		{
			TrackForm.thisForm.timerClock1.Enabled = false;
			TrackForm.m_dClock = 0.0;
			TrackForm.thisForm.Invalidate();
		}

		public void ReceiveResponse(OBD2Response obd2Response)
		{
		}

		public void CheckConnection()
		{
			if (m_obdInterface.getConnectedStatus())
			{
				btnStage.Enabled = true;
				btnReset.Enabled = true;
			}
			else
			{
				btnStage.Enabled = false;
				btnReset.Enabled = false;
			}
		}

		private void btnStage_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show(string.Concat((object)"A vehicle connection must first be established."), "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				btnStage.Enabled = false;
				btnReset.Enabled = true;
				btnOpen.Enabled = false;
				m_bCapture = true;
				ThreadPool.QueueUserWorkItem(new WaitCallback(Capture));
			}
		}

		private new void Capture(object state)
		{
			m_arrKphValues = new ArrayList();
			if (m_bCapture)
			{
				do
				{
					OBDParameterValue obdParameterValue = m_obdInterface.getValue("SAE.VSS", false);

					if (!obdParameterValue.ErrorDetected && obdParameterValue.DoubleValue > 0.0)
					{
						if (m_arrKphValues.Count == 0)
							TrackForm.thisForm.BeginInvoke((Delegate)TrackForm.CallStartTimer);
						float num = m_obdInterface.GetActiveProfile().SpeedCalibrationFactor;
						m_arrKphValues.Add((object)new DatedValue(obdParameterValue.DoubleValue * (double)num));
						TrackForm.thisForm.CalculateTimeslip();
					}
				}
				while (m_bCapture);
			}
			TrackForm.thisForm.BeginInvoke((Delegate)TrackForm.CallStopTimer);
			btnOpen.Enabled = true;
		}

		private void CalculateTimeslip()
		{
			double num1 = 0.0;
			double num2 = 0.0;
			bool flag = false;
			timeslip = new Timeslip();
			timeslip.Vehicle = m_obdInterface.GetActiveProfile().Name;
			if (m_arrKphValues == null || m_arrKphValues.Count == 0)
				return;
			timeslip.Vehicle = m_obdInterface.GetActiveProfile().Name;
			timeslip.Date = (m_arrKphValues[0] as DatedValue).Date;
			int index = 1;
			if (1 >= m_arrKphValues.Count)
				return;
			do
			{
				DatedValue datedValue1 = m_arrKphValues[index - 1] as DatedValue;
				DatedValue datedValue2 = m_arrKphValues[index] as DatedValue;
				double num3 = (datedValue2.Value + datedValue1.Value) * 0.5 * (5.0 / 18.0);
				DateTime dateTime = datedValue1.Date;
				double totalSeconds = datedValue2.Date.Subtract(dateTime).TotalSeconds;
				num1 += totalSeconds;
				double num4 = totalSeconds * num3;
				num2 += num4;
				if (num2 >= 18.288 && timeslip.SixtyFootTime == 0.0)
				{
					timeslip.SixtyFootTime = num1 - (num2 - 18.288) / num3;
					flag = true;
				}
				if (datedValue2.Value >= 96.56064 && timeslip.SixtyMphTime == 0.0)
				{
					timeslip.SixtyMphTime = num1 - (datedValue2.Value - 96.56064) / ((datedValue2.Value - datedValue1.Value) / totalSeconds);
					flag = true;
				}
				if (num2 >= 201.168 && timeslip.EighthMileTime == 0.0)
				{
					double num5 = num2 - 201.168;
					timeslip.EighthMileTime = num1 - num5 / num3;
					timeslip.EighthMileSpeed = ((datedValue2.Value - datedValue1.Value) * ((num4 - num5) / num4) + datedValue1.Value) * 0.621371192;
					flag = true;
				}
				if (num2 >= 304.8 && timeslip.ThousandFootTime == 0.0)
				{
					timeslip.ThousandFootTime = num1 - (num2 - 304.8) / num3;
					flag = true;
				}
				if (num2 >= 402.336 && timeslip.QuarterMileTime == 0.0)
				{
					double num5 = num2 - 402.336;
					timeslip.QuarterMileTime = num1 - num5 / num3;
					timeslip.QuarterMileSpeed = ((datedValue2.Value - datedValue1.Value) * ((num4 - num5) / num4) + datedValue1.Value) * 0.621371192;
					flag = true;
					m_bCapture = false;
				}
				++index;
			}
			while (index < m_arrKphValues.Count);
			if (!flag)
				return;
			UpdateTimeslip();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			m_bCapture = false;
			btnStage.Enabled = true;
			TrackForm.StopTimer();
			timeslip = new Timeslip();
			timeslip.Vehicle = m_obdInterface.GetActiveProfile().Name;
			UpdateTimeslip();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Title = "Save Timeslip";
			dialog.Filter = "Timeslip files (*.slp)|*.slp";
			dialog.FilterIndex = 0;
			dialog.RestoreDirectory = true;
			dialog.ShowDialog();
			if (dialog.FileName != "")
			{
				TextWriter writer = new StreamWriter(dialog.FileName);
				new XmlSerializer(timeslip.GetType()).Serialize(writer, timeslip);
				writer.Close();
			}
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Timeslip files (*.slp)|*.slp";
			openFileDialog.FilterIndex = 0;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;
			XmlSerializer xmlSerializer = new XmlSerializer(timeslip.GetType());
			FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
			timeslip = (Timeslip)xmlSerializer.Deserialize((Stream)fileStream);
			fileStream.Close();
			UpdateTimeslip();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (printDialog1.ShowDialog() != DialogResult.OK)
				return;
			printDocument1.Print();
		}

		private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
		{
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			float x = (float)e.MarginBounds.Left;
			float num = (float)e.MarginBounds.Right;
			float y = (float)e.MarginBounds.Top;
			int bottom = e.MarginBounds.Bottom;
			Font font1 = new Font("Courier New", 14f, FontStyle.Bold);
			Font font2 = new Font("Courier New", 12f, FontStyle.Bold);
			Font font3 = new Font("Courier New", 12f, FontStyle.Regular);
			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			RectangleF layoutRectangle1 = new RectangleF();
			float width = num - x;
			layoutRectangle1 = new RectangleF(x, y, width, 20f);
			RectangleF layoutRectangle2 = new RectangleF();
			layoutRectangle2 = new RectangleF(x, y + 40f, width, 17.5f);
			RectangleF layoutRectangle3 = new RectangleF();
			layoutRectangle3 = new RectangleF(x, y + 55f, width, 40f);
			RectangleF layoutRectangle4 = new RectangleF();
			layoutRectangle4 = new RectangleF(x, y + 110f, width, 140f);
			e.Graphics.DrawString("ProScan Drag Strip", font1, Brushes.Blue, layoutRectangle1, format);
			e.Graphics.DrawString("2000 Camaro SS", font2, Brushes.Black, layoutRectangle2, format);
			string s = DateTime.Now.ToLongDateString() + "\r\n" + DateTime.Now.ToLongTimeString() + "\r\n\r\n";
			e.Graphics.DrawString(s, font3, Brushes.Black, layoutRectangle3, format);
			e.Graphics.DrawString(timeslip.getStats(), font3, Brushes.Black, layoutRectangle4, format);
		}

		public void Menu_PrintPreview()
		{
			PrintPreview();
		}

		public void Menu_PageSetup()
		{
			PageSetup();
		}

		public void Menu_Print()
		{
			Print();
		}

		private void PrintPreview()
		{
			int num = (int)printPreviewDialog1.ShowDialog();
		}

		private void PageSetup()
		{
			int num = (int)pageSetupDialog1.ShowDialog();
		}

		private void Print()
		{
			if (printDialog1.ShowDialog() != DialogResult.OK)
				return;
			printDocument1.Print();
		}

		private void btnExportJPEG_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Export as JPEG";
			saveFileDialog.Filter = "JPEG files (*.jpg)|*.jpg";
			saveFileDialog.FilterIndex = 0;
			saveFileDialog.RestoreDirectory = true;
			int num = (int)saveFileDialog.ShowDialog();
			if (saveFileDialog.FileName != "")
			{
				Bitmap bitmap = new Bitmap(500, 300);
				Graphics graphics = Graphics.FromImage((Image)bitmap);
				Font font1 = new Font("Courier New", 14f, FontStyle.Bold);
				Font font2 = new Font("Courier New", 12f, FontStyle.Bold);
				Font font3 = new Font("Courier New", 12f, FontStyle.Regular);
				StringFormat format = new StringFormat();
				format.Alignment = StringAlignment.Center;
				RectangleF layoutRectangle1 = new RectangleF();
				layoutRectangle1 = new RectangleF(10f, 25f, 480f, 20f);
				RectangleF layoutRectangle2 = new RectangleF();
				layoutRectangle2 = new RectangleF(10f, 65f, 480f, 17.5f);
				RectangleF layoutRectangle3 = new RectangleF();
				layoutRectangle3 = new RectangleF(10f, 80f, 480f, 40f);
				RectangleF layoutRectangle4 = new RectangleF();
				layoutRectangle4 = new RectangleF(10f, 135f, 480f, 140f);
				Color white = Color.White;
				graphics.FillRectangle((Brush)new SolidBrush(white), 0, 0, 500, 600);
				graphics.DrawString("ProScan Drag Strip", font1, Brushes.Blue, layoutRectangle1, format);
				graphics.DrawString(timeslip.Vehicle, font2, Brushes.Black, layoutRectangle2, format);
				string s = timeslip.Date.ToLongDateString() + "\r\n" + timeslip.Date.ToLongTimeString() + "\r\n\r\n";
				graphics.DrawString(s, font3, Brushes.Black, layoutRectangle3, format);
				graphics.DrawString(timeslip.getStats(), font3, Brushes.Black, layoutRectangle4, format);
				(bitmap as Image).Save(saveFileDialog.FileName, ImageFormat.Jpeg);
			}
		}

		private void TrackForm_Activated(object sender, EventArgs e)
		{
			CheckConnection();
		}
	}
}