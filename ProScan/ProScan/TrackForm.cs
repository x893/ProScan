using System;
using System.Collections;
using System.Collections.Generic;
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
		private static TrackForm thisForm;
		private static long m_iClockStartTicks;
		private static double m_dClock;

		private OBDInterface m_obdInterface;
		private Timeslip timeslip;
		private List<DatedValue> m_KphValues;
		private bool m_bCapture;

		static TrackForm()
		{
		}

		public TrackForm(OBDInterface obd)
		{
			thisForm = this;
			m_obdInterface = obd;
			timeslip = new Timeslip();
			timeslip.Vehicle = m_obdInterface.ActiveProfile.Name;
			InitializeComponent();
			CheckConnection();
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
				emSize = 8f;

			richTextSlip.Text = "";
			richTextSlip.SelectionAlignment = HorizontalAlignment.Center;

			richTextSlip.SelectionFont = new Font("Courier New", emSize + 2f, FontStyle.Bold);
			richTextSlip.SelectionColor = Color.Blue;
			richTextSlip.AppendText("\r\nProScan Drag Strip\r\n\r\n");

			richTextSlip.SelectionFont = new Font("Courier New", emSize, FontStyle.Bold);
			richTextSlip.SelectionColor = Color.Black;
			richTextSlip.AppendText(timeslip.Vehicle + "\r\n");

			richTextSlip.SelectionFont = new Font("Courier New", emSize, FontStyle.Regular);
			richTextSlip.SelectionColor = Color.Black;
			richTextSlip.AppendText(timeslip.Date.ToLongDateString() + "\r\n" + timeslip.Date.ToLongTimeString() + "\r\n\r\n");

			richTextSlip.SelectionFont = new Font("Courier New", emSize, FontStyle.Regular);
			richTextSlip.SelectionColor = Color.Black;
			richTextSlip.AppendText(timeslip.getStats());

		}

		private void TrackForm_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(picTrack.Image, 0, 0, picTrack.Width, picTrack.Height);

			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;

			RectangleF rect = new RectangleF(2.5f, 2.5f, Convert.ToSingle(base.Width), 100f);
			e.Graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(Color.Black), rect, format);
			rect = new RectangleF(0f, 0f, Convert.ToSingle(base.Width), 100f);
			e.Graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(Color.White), rect, format);
		}


		private void timerClock_Tick(object sender, EventArgs e)
		{
			m_dClock = Convert.ToDouble((long)(DateTime.Now.Ticks - m_iClockStartTicks)) * 1E-07;
			Graphics graphics = base.CreateGraphics();
			graphics.DrawImage(picTrack.Image, 0, 0, picTrack.Width, picTrack.Height);

			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;

			RectangleF rect = new RectangleF(2.5f, 2.5f, Convert.ToSingle(base.Width), 100f);
			graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(Color.Black), rect, format);
			rect = new RectangleF(0f, 0f, Convert.ToSingle(base.Width), 100f);
			graphics.DrawString(m_dClock.ToString("00.000"), new Font("Verdana", 40f), new SolidBrush(Color.White), rect, format);
		}

		private static void StartTimer()
		{
			m_iClockStartTicks = DateTime.Now.Ticks;
			thisForm.timerClock1.Enabled = true;
		}

		private static void StopTimer()
		{
			thisForm.timerClock1.Enabled = false;
			m_dClock = 0.0;
			thisForm.Invalidate();
		}

		public void CheckConnection()
		{
			if (m_obdInterface.ConnectedStatus)
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
			if (!m_obdInterface.ConnectedStatus)
				MessageBox.Show(string.Concat((object)"A vehicle connection must first be established."), "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			m_KphValues = new List<DatedValue>();
			if (m_bCapture)
			{
				do
				{
					OBDParameterValue obdParameterValue = m_obdInterface.getValue("SAE.VSS", false);

					if (!obdParameterValue.ErrorDetected && obdParameterValue.DoubleValue > 0.0)
					{
						if (m_KphValues.Count == 0)
							TrackForm.thisForm.BeginInvoke((Delegate)TrackForm.CallStartTimer);
						m_KphValues.Add(new DatedValue(obdParameterValue.DoubleValue * (double)m_obdInterface.ActiveProfile.SpeedCalibrationFactor));
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
			timeslip.Vehicle = m_obdInterface.ActiveProfile.Name;
			if (m_KphValues == null || m_KphValues.Count == 0)
				return;
			timeslip.Vehicle = m_obdInterface.ActiveProfile.Name;
			timeslip.Date = m_KphValues[0].Date;
			if (m_KphValues.Count <= 1)
				return;

			int index = 1;
			do
			{
				DatedValue datedValue1 = m_KphValues[index - 1];
				DatedValue datedValue2 = m_KphValues[index];
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
			while (index < m_KphValues.Count);
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
			timeslip.Vehicle = m_obdInterface.ActiveProfile.Name;
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
				using (TextWriter writer = new StreamWriter(dialog.FileName))
				{
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
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{

				XmlSerializer xmlSerializer = new XmlSerializer(timeslip.GetType());
				using (FileStream reader = new FileStream(openFileDialog.FileName, FileMode.Open))
				{
					timeslip = (Timeslip)xmlSerializer.Deserialize(reader);
					reader.Close();
				}
				UpdateTimeslip();
			}
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			if (printDialog1.ShowDialog() != DialogResult.OK)
				return;
			printDocument.Print();
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			float left = (float)e.MarginBounds.Left;
			float right = (float)e.MarginBounds.Right;
			float top = (float)e.MarginBounds.Top;

			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;

			RectangleF layoutRectangle1 = new RectangleF();
			float width = right - left;
			layoutRectangle1 = new RectangleF(left, top, width, 20f);
			RectangleF layoutRectangle2 = new RectangleF();
			layoutRectangle2 = new RectangleF(left, top + 40f, width, 17.5f);
			RectangleF layoutRectangle3 = new RectangleF();
			layoutRectangle3 = new RectangleF(left, top + 55f, width, 40f);
			RectangleF layoutRectangle4 = new RectangleF();
			layoutRectangle4 = new RectangleF(left, top + 110f, width, 140f);
			e.Graphics.DrawString("ProScan Drag Strip", new Font("Courier New", 14f, FontStyle.Bold), Brushes.Blue, layoutRectangle1, format);
			e.Graphics.DrawString("2000 Camaro SS", new Font("Courier New", 12f, FontStyle.Bold), Brushes.Black, layoutRectangle2, format);

			string s = DateTime.Now.ToLongDateString() + "\r\n" + DateTime.Now.ToLongTimeString() + "\r\n\r\n";
			Font font = new Font("Courier New", 12f, FontStyle.Regular);
			e.Graphics.DrawString(s, font, Brushes.Black, layoutRectangle3, format);
			e.Graphics.DrawString(timeslip.getStats(), font, Brushes.Black, layoutRectangle4, format);
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

				graphics.FillRectangle((Brush)new SolidBrush(Color.White), 0, 0, 500, 600);
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

		#region InitializeComponent
		private PictureBox picTrack;
		private Button btnStage;
		private Button btnReset;
		private GroupBox groupControls;
		private GroupBox groupTimeslip;
		private Button btnSave;
		private Button btnOpen;
		private PrintDialog printDialog1;
		private PrintPreviewDialog printPreviewDialog;
		private PageSetupDialog pageSetupDialog;
		private PrintDocument printDocument;
		private Button btnPrint;
		private GroupBox groupTimeslipControls;
		private GroupBox groupExport;
		private Button btnExportJPEG;
		private RichTextBox richTextSlip;
		private System.Windows.Forms.Timer timerClock1;
		private IContainer components;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackForm));
			this.picTrack = new System.Windows.Forms.PictureBox();
			this.timerClock1 = new System.Windows.Forms.Timer(this.components);
			this.btnStage = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.groupControls = new System.Windows.Forms.GroupBox();
			this.btnPrint = new System.Windows.Forms.Button();
			this.groupTimeslip = new System.Windows.Forms.GroupBox();
			this.richTextSlip = new System.Windows.Forms.RichTextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
			this.groupTimeslipControls = new System.Windows.Forms.GroupBox();
			this.groupExport = new System.Windows.Forms.GroupBox();
			this.btnExportJPEG = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.picTrack)).BeginInit();
			this.groupControls.SuspendLayout();
			this.groupTimeslip.SuspendLayout();
			this.groupTimeslipControls.SuspendLayout();
			this.groupExport.SuspendLayout();
			this.SuspendLayout();
			// 
			// picTrack
			// 
			this.picTrack.Image = ((System.Drawing.Image)(resources.GetObject("picTrack.Image")));
			this.picTrack.Location = new System.Drawing.Point(0, 0);
			this.picTrack.Name = "picTrack";
			this.picTrack.Size = new System.Drawing.Size(588, 115);
			this.picTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picTrack.TabIndex = 0;
			this.picTrack.TabStop = false;
			this.picTrack.Visible = false;
			// 
			// timerClock1
			// 
			this.timerClock1.Interval = 51;
			this.timerClock1.Tick += new System.EventHandler(this.timerClock_Tick);
			// 
			// btnStage
			// 
			this.btnStage.Location = new System.Drawing.Point(12, 23);
			this.btnStage.Name = "btnStage";
			this.btnStage.Size = new System.Drawing.Size(156, 29);
			this.btnStage.TabIndex = 1;
			this.btnStage.Text = "&Stage";
			this.btnStage.Click += new System.EventHandler(this.btnStage_Click);
			// 
			// btnReset
			// 
			this.btnReset.Enabled = false;
			this.btnReset.Location = new System.Drawing.Point(12, 63);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(156, 29);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "&Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// groupControls
			// 
			this.groupControls.Controls.Add(this.btnReset);
			this.groupControls.Controls.Add(this.btnStage);
			this.groupControls.Location = new System.Drawing.Point(12, 127);
			this.groupControls.Name = "groupControls";
			this.groupControls.Size = new System.Drawing.Size(180, 104);
			this.groupControls.TabIndex = 3;
			this.groupControls.TabStop = false;
			this.groupControls.Text = "Control";
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(12, 104);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(156, 29);
			this.btnPrint.TabIndex = 4;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// groupTimeslip
			// 
			this.groupTimeslip.Controls.Add(this.richTextSlip);
			this.groupTimeslip.Location = new System.Drawing.Point(204, 127);
			this.groupTimeslip.Name = "groupTimeslip";
			this.groupTimeslip.Size = new System.Drawing.Size(378, 335);
			this.groupTimeslip.TabIndex = 4;
			this.groupTimeslip.TabStop = false;
			// 
			// richTextSlip
			// 
			this.richTextSlip.BackColor = System.Drawing.SystemColors.Control;
			this.richTextSlip.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextSlip.Location = new System.Drawing.Point(10, 18);
			this.richTextSlip.Name = "richTextSlip";
			this.richTextSlip.ReadOnly = true;
			this.richTextSlip.Size = new System.Drawing.Size(355, 305);
			this.richTextSlip.TabIndex = 0;
			this.richTextSlip.Text = "";
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(12, 63);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(156, 29);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "&Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(12, 23);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(156, 29);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// printDialog1
			// 
			this.printDialog1.Document = this.printDocument;
			// 
			// printDocument1
			// 
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog.Document = this.printDocument;
			this.printPreviewDialog.Enabled = true;
			this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog.Name = "printPreviewDialog1";
			this.printPreviewDialog.Visible = false;
			// 
			// pageSetupDialog1
			// 
			this.pageSetupDialog.Document = this.printDocument;
			// 
			// groupTimeslipControls
			// 
			this.groupTimeslipControls.Controls.Add(this.btnSave);
			this.groupTimeslipControls.Controls.Add(this.btnOpen);
			this.groupTimeslipControls.Controls.Add(this.btnPrint);
			this.groupTimeslipControls.Location = new System.Drawing.Point(12, 242);
			this.groupTimeslipControls.Name = "groupTimeslipControls";
			this.groupTimeslipControls.Size = new System.Drawing.Size(180, 145);
			this.groupTimeslipControls.TabIndex = 5;
			this.groupTimeslipControls.TabStop = false;
			this.groupTimeslipControls.Text = "Timeslip";
			// 
			// groupExport
			// 
			this.groupExport.Controls.Add(this.btnExportJPEG);
			this.groupExport.Location = new System.Drawing.Point(12, 398);
			this.groupExport.Name = "groupExport";
			this.groupExport.Size = new System.Drawing.Size(180, 64);
			this.groupExport.TabIndex = 6;
			this.groupExport.TabStop = false;
			this.groupExport.Text = "Export";
			// 
			// btnExportJPEG
			// 
			this.btnExportJPEG.Location = new System.Drawing.Point(12, 23);
			this.btnExportJPEG.Name = "btnExportJPEG";
			this.btnExportJPEG.Size = new System.Drawing.Size(156, 29);
			this.btnExportJPEG.TabIndex = 6;
			this.btnExportJPEG.Text = "&JPEG";
			this.btnExportJPEG.Click += new System.EventHandler(this.btnExportJPEG_Click);
			// 
			// TrackForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(588, 471);
			this.ControlBox = false;
			this.Controls.Add(this.groupExport);
			this.Controls.Add(this.groupTimeslipControls);
			this.Controls.Add(this.groupTimeslip);
			this.Controls.Add(this.groupControls);
			this.Controls.Add(this.picTrack);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrackForm";
			this.Text = "Race Track Analysis";
			this.Activated += new System.EventHandler(this.TrackForm_Activated);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrackForm_Paint);
			this.Resize += new System.EventHandler(this.TrackForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.picTrack)).EndInit();
			this.groupControls.ResumeLayout(false);
			this.groupTimeslip.ResumeLayout(false);
			this.groupTimeslipControls.ResumeLayout(false);
			this.groupExport.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}