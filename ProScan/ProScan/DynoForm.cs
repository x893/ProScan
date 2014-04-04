using DGChart;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProScan
{
	public class DynoForm : Form
	{
		private IContainer components;
		private Button btnStart;
		private GroupBox groupControl;
		private Button btnReset;
		private GroupBox groupChart;
		private Button btnSave;
		private Button btnOpen;
		private Button btnPrint;
		private GroupBox groupGraph;
		private PrintDialog printDialog1;
		private PrintPreviewDialog printPreviewDialog1;
		private PageSetupDialog pageSetupDialog1;
		private PrintDocument printDocument1;
		private DataList Data;
		private OBDInterface m_obdInterface;
		private VehicleProfile m_profile;
		private double m_dHPMax;
		private double m_dTQMax;
		private bool m_bCapture;
		private ArrayList m_arrRpmValues;
		private ArrayList m_arrKphValues;
		private double[] HPValue;
		private double[] TQValue;
		private double[] SampleRPM;
		private double m_dVehicleWeight;
		private GroupBox groupExport;
		private Button btnExportJPEG;
		private DynoControl dyno;
		private GroupBox groupSetup;
		private Label lblFromRPM;
		private Label lblToRPM;
		private NumericUpDown numFromRPM;
		private NumericUpDown numToRPM;
		private DateTime m_dtDynoTime;

		public DynoForm(OBDInterface obd2)
		{
			m_obdInterface = obd2;
			m_profile = obd2.GetActiveProfile();
			InitializeComponent();
			Data = new DataList();
			m_bCapture = false;
			m_dtDynoTime = DateTime.Now;
			btnStart.Enabled = false;
			btnReset.Enabled = false;
			printDocument1.DefaultPageSettings = new PageSettings()
			{
				Margins = new Margins(100, 100, 100, 100),
				Landscape = true
			};
			pageSetupDialog1.Document = printDocument1;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			m_bCapture = false;
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DynoForm));
			this.groupControl = new System.Windows.Forms.GroupBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.groupChart = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.groupGraph = new System.Windows.Forms.GroupBox();
			this.dyno = new DGChart.DynoControl();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
			this.groupExport = new System.Windows.Forms.GroupBox();
			this.btnExportJPEG = new System.Windows.Forms.Button();
			this.groupSetup = new System.Windows.Forms.GroupBox();
			this.numToRPM = new System.Windows.Forms.NumericUpDown();
			this.numFromRPM = new System.Windows.Forms.NumericUpDown();
			this.lblToRPM = new System.Windows.Forms.Label();
			this.lblFromRPM = new System.Windows.Forms.Label();
			this.groupControl.SuspendLayout();
			this.groupChart.SuspendLayout();
			this.groupGraph.SuspendLayout();
			this.groupExport.SuspendLayout();
			this.groupSetup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numToRPM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFromRPM)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl
			// 
			this.groupControl.Controls.Add(this.btnReset);
			this.groupControl.Controls.Add(this.btnStart);
			this.groupControl.Location = new System.Drawing.Point(10, 105);
			this.groupControl.Name = "groupControl";
			this.groupControl.Size = new System.Drawing.Size(150, 90);
			this.groupControl.TabIndex = 0;
			this.groupControl.TabStop = false;
			this.groupControl.Text = "Control";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(10, 55);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(130, 25);
			this.btnReset.TabIndex = 8;
			this.btnReset.Text = "&Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(10, 20);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(130, 25);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "&Begin Dyno Pull";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// groupChart
			// 
			this.groupChart.Controls.Add(this.btnSave);
			this.groupChart.Controls.Add(this.btnOpen);
			this.groupChart.Controls.Add(this.btnPrint);
			this.groupChart.Location = new System.Drawing.Point(10, 205);
			this.groupChart.Name = "groupChart";
			this.groupChart.Size = new System.Drawing.Size(150, 125);
			this.groupChart.TabIndex = 2;
			this.groupChart.TabStop = false;
			this.groupChart.Text = "Chart";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(10, 20);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(130, 25);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(10, 55);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(130, 25);
			this.btnOpen.TabIndex = 6;
			this.btnOpen.Text = "&Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(10, 90);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(130, 25);
			this.btnPrint.TabIndex = 7;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// groupGraph
			// 
			this.groupGraph.Controls.Add(this.dyno);
			this.groupGraph.Location = new System.Drawing.Point(170, 10);
			this.groupGraph.Name = "groupGraph";
			this.groupGraph.Size = new System.Drawing.Size(446, 422);
			this.groupGraph.TabIndex = 4;
			this.groupGraph.TabStop = false;
			// 
			// dyno
			// 
			this.dyno.BorderLeft = 35;
			this.dyno.BorderRight = 20;
			this.dyno.BorderTop = 20;
			this.dyno.ColorAxis = System.Drawing.Color.Black;
			this.dyno.ColorBg = System.Drawing.Color.White;
			this.dyno.ColorGrid = System.Drawing.Color.LightGray;
			this.dyno.ColorSet1 = System.Drawing.Color.DarkBlue;
			this.dyno.ColorSet2 = System.Drawing.Color.Red;
			this.dyno.ColorSet3 = System.Drawing.Color.Lime;
			this.dyno.ColorSet4 = System.Drawing.Color.Gold;
			this.dyno.ColorSet5 = System.Drawing.Color.Magenta;
			this.dyno.DrawMode = DGChart.DynoControl.DrawModeType.Line;
			this.dyno.FontAxis = new System.Drawing.Font("Arial", 8F);
			this.dyno.Label = "0";
			this.dyno.Location = new System.Drawing.Point(2, 6);
			this.dyno.Logo = null;
			this.dyno.Name = "dyno";
			this.dyno.ShowData1 = true;
			this.dyno.ShowData2 = false;
			this.dyno.ShowData3 = false;
			this.dyno.ShowData4 = false;
			this.dyno.ShowData5 = false;
			this.dyno.Size = new System.Drawing.Size(442, 417);
			this.dyno.TabIndex = 0;
			this.dyno.XData1 = null;
			this.dyno.XData2 = null;
			this.dyno.XData3 = null;
			this.dyno.XData4 = null;
			this.dyno.XData5 = null;
			this.dyno.XGrid = 0.5D;
			this.dyno.XRangeEnd = 6.5D;
			this.dyno.XRangeStart = 2D;
			this.dyno.YData1 = null;
			this.dyno.YData2 = null;
			this.dyno.YData3 = null;
			this.dyno.YData4 = null;
			this.dyno.YData5 = null;
			this.dyno.YGrid = 50D;
			this.dyno.YRangeEnd = 200D;
			this.dyno.YRangeStart = 0D;
			// 
			// printDialog1
			// 
			this.printDialog1.Document = this.printDocument1;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.printDocument1;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// pageSetupDialog1
			// 
			this.pageSetupDialog1.Document = this.printDocument1;
			// 
			// groupExport
			// 
			this.groupExport.Controls.Add(this.btnExportJPEG);
			this.groupExport.Location = new System.Drawing.Point(10, 340);
			this.groupExport.Name = "groupExport";
			this.groupExport.Size = new System.Drawing.Size(150, 55);
			this.groupExport.TabIndex = 5;
			this.groupExport.TabStop = false;
			this.groupExport.Text = "Export";
			// 
			// btnExportJPEG
			// 
			this.btnExportJPEG.Location = new System.Drawing.Point(10, 20);
			this.btnExportJPEG.Name = "btnExportJPEG";
			this.btnExportJPEG.Size = new System.Drawing.Size(130, 25);
			this.btnExportJPEG.TabIndex = 6;
			this.btnExportJPEG.Text = "&JPEG";
			this.btnExportJPEG.Click += new System.EventHandler(this.btnExportJPEG_Click);
			// 
			// groupSetup
			// 
			this.groupSetup.Controls.Add(this.numToRPM);
			this.groupSetup.Controls.Add(this.numFromRPM);
			this.groupSetup.Controls.Add(this.lblToRPM);
			this.groupSetup.Controls.Add(this.lblFromRPM);
			this.groupSetup.Location = new System.Drawing.Point(10, 15);
			this.groupSetup.Name = "groupSetup";
			this.groupSetup.Size = new System.Drawing.Size(150, 80);
			this.groupSetup.TabIndex = 6;
			this.groupSetup.TabStop = false;
			this.groupSetup.Text = "Setup";
			// 
			// numToRPM
			// 
			this.numToRPM.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numToRPM.Location = new System.Drawing.Point(80, 44);
			this.numToRPM.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
			this.numToRPM.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.numToRPM.Name = "numToRPM";
			this.numToRPM.ReadOnly = true;
			this.numToRPM.Size = new System.Drawing.Size(60, 20);
			this.numToRPM.TabIndex = 7;
			this.numToRPM.Value = new decimal(new int[] {
            6500,
            0,
            0,
            0});
			this.numToRPM.ValueChanged += new System.EventHandler(this.numToRPM_ValueChanged);
			// 
			// numFromRPM
			// 
			this.numFromRPM.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.numFromRPM.Location = new System.Drawing.Point(80, 20);
			this.numFromRPM.Maximum = new decimal(new int[] {
            5500,
            0,
            0,
            0});
			this.numFromRPM.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numFromRPM.Name = "numFromRPM";
			this.numFromRPM.ReadOnly = true;
			this.numFromRPM.Size = new System.Drawing.Size(60, 20);
			this.numFromRPM.TabIndex = 6;
			this.numFromRPM.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numFromRPM.ValueChanged += new System.EventHandler(this.numFromRPM_ValueChanged);
			// 
			// lblToRPM
			// 
			this.lblToRPM.Location = new System.Drawing.Point(10, 44);
			this.lblToRPM.Name = "lblToRPM";
			this.lblToRPM.Size = new System.Drawing.Size(70, 20);
			this.lblToRPM.TabIndex = 4;
			this.lblToRPM.Text = "&To RPM:";
			this.lblToRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFromRPM
			// 
			this.lblFromRPM.Location = new System.Drawing.Point(10, 20);
			this.lblFromRPM.Name = "lblFromRPM";
			this.lblFromRPM.Size = new System.Drawing.Size(70, 20);
			this.lblFromRPM.TabIndex = 2;
			this.lblFromRPM.Text = "&From RPM:";
			this.lblFromRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DynoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.ControlBox = false;
			this.Controls.Add(this.groupSetup);
			this.Controls.Add(this.groupExport);
			this.Controls.Add(this.groupGraph);
			this.Controls.Add(this.groupChart);
			this.Controls.Add(this.groupControl);
			this.Name = "DynoForm";
			this.Text = "Dynamometer";
			this.Activated += new System.EventHandler(this.DynoForm_Activated);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DynoForm_Closing);
			this.Resize += new System.EventHandler(this.DynoForm_Resize);
			this.groupControl.ResumeLayout(false);
			this.groupChart.ResumeLayout(false);
			this.groupGraph.ResumeLayout(false);
			this.groupExport.ResumeLayout(false);
			this.groupSetup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numToRPM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFromRPM)).EndInit();
			this.ResumeLayout(false);

		}

		private void DynoForm_Resize(object sender, EventArgs e)
		{
			int num1 = Width;
			int num2 = Height;
			if (num1 < 640)
				num1 = 640;
			if (num2 < 480)
				num2 = 480;
			groupGraph.Width = num1 - 185;
			groupGraph.Height = num2 - 50;
			dyno.Width = groupGraph.Width - 4;
			dyno.Height = groupGraph.Height - 9;
		}

		public void setProfile(VehicleProfile profile)
		{
			m_profile = profile;
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.getConnectedStatus())
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				DateTime now = DateTime.Now;
				m_dtDynoTime = now;
				m_dVehicleWeight = m_profile.Weight;
				dyno.Label = m_profile.Name + "\r\n" + m_dtDynoTime.ToString("g");
				btnStart.Enabled = false;
				btnReset.Enabled = true;
				btnOpen.Enabled = false;
				m_bCapture = true;
				ThreadPool.QueueUserWorkItem(new WaitCallback(Capture));
			}
		}

		private void DynoForm_Closing(object sender, CancelEventArgs e)
		{
			m_bCapture = false;
		}

		private new void Capture(object state)
		{
			m_arrRpmValues = new ArrayList();
			m_arrKphValues = new ArrayList();
			bool flag = false;
			if (m_bCapture)
			{
				do
				{
					OBDParameterValue obdParameterValue1 = m_obdInterface.getValue("SAE.RPM", true);
					if (!obdParameterValue1.ErrorDetected)
					{
						DatedValue datedValue1 = new DatedValue(obdParameterValue1.DoubleValue);
						DateTime now1 = DateTime.Now;
						datedValue1.Date = now1;
						Decimal num1 = numFromRPM.Value;
						Decimal num2 = new Decimal();
						num2 = new Decimal(datedValue1.Value);
						if (num2 >= num1)
						{
							Decimal num3 = numToRPM.Value;
							Decimal num4 = new Decimal();
							num4 = new Decimal(datedValue1.Value);
							if (num4 <= num3)
							{
								m_arrRpmValues.Add((object)datedValue1);
								OBDParameterValue obdParameterValue2 = m_obdInterface.getValue("SAE.VSS", false);

								if (!obdParameterValue2.ErrorDetected)
								{
									float num5 = m_obdInterface.GetActiveProfile().SpeedCalibrationFactor;
									DatedValue datedValue2 = new DatedValue(obdParameterValue2.DoubleValue * (double)num5);
									DateTime now2 = DateTime.Now;
									datedValue2.Date = now2;
									m_arrKphValues.Add((object)datedValue2);
								}
								flag = true;
								goto label_9;
							}
						}
						if (flag)
							m_bCapture = false;
					}
				label_9: ;
				}
				while (m_bCapture);
			}
			Calculate();
			btnOpen.Enabled = true;
		}

		private double getSpeedAtTime(DateTime dt)
		{
			if (m_arrKphValues == null
			|| m_arrKphValues.Count < 2
			|| (m_arrKphValues[0] as DatedValue).Date > dt
			|| (m_arrKphValues[m_arrKphValues.Count - 1] as DatedValue).Date < dt
				)
				return -1.0;
			DateTime dateTime3 = (m_arrKphValues[0] as DatedValue).Date;
			int index1 = 1;
			if (1 < m_arrKphValues.Count)
			{
				double num1;
				double num2;
				DateTime dateTime4;
				DateTime dateTime5;
				do
				{
					int index2 = index1 - 1;
					num1 = (m_arrKphValues[index2] as DatedValue).Value;
					num2 = (m_arrKphValues[index1] as DatedValue).Value;
					dateTime4 = (m_arrKphValues[index2] as DatedValue).Date;
					dateTime5 = (m_arrKphValues[index1] as DatedValue).Date;
					if (!(dateTime5 >= dt))
						++index1;
					else
						return dt.Subtract(dateTime4).TotalSeconds / dateTime5.Subtract(dateTime4).TotalSeconds * (num2 - num1) + num1;
				}
				while (index1 < m_arrKphValues.Count);
			}
			return -1.0;
		}

		private void Calculate()
		{
			m_dTQMax = 0.0;
			m_dHPMax = 0.0;
			double[] numArray1 = new double[m_arrRpmValues.Count - 1];
			numArray1.Initialize();
			HPValue = numArray1;
			double[] numArray2 = new double[m_arrRpmValues.Count - 1];
			numArray2.Initialize();
			TQValue = numArray2;
			double[] numArray3 = new double[m_arrRpmValues.Count - 1];
			numArray3.Initialize();
			SampleRPM = numArray3;
			int index1 = 0;
			if (0 < m_arrRpmValues.Count - 1)
			{
				do
				{
					double num1 = (m_arrRpmValues[index1] as DatedValue).Value;
					int index2 = index1 + 1;
					double num2 = (m_arrRpmValues[index2] as DatedValue).Value;
					DateTime dateTime1 = (m_arrRpmValues[index1] as DatedValue).Date;
					TimeSpan timeSpan = (m_arrRpmValues[index2] as DatedValue).Date.Subtract(dateTime1);
					dateTime1.AddSeconds(timeSpan.TotalSeconds * 0.5);
					double num3 = (m_arrKphValues[index1] as DatedValue).Value;
					double num4 = (m_arrKphValues[index2] as DatedValue).Value;
					DateTime dateTime2 = (m_arrKphValues[index1] as DatedValue).Date;
					DateTime dateTime3 = (m_arrKphValues[index2] as DatedValue).Date;
					SampleRPM[index1] = (num2 + num1) * 0.5 * 0.001;
					double num5 = (num4 + num3) * 0.5 * 0.621371192 * 0.44704;
					double num6 = m_dVehicleWeight * 0.45359237 * num5 * num5 * 0.5 / dateTime3.Subtract(dateTime2).TotalSeconds;
					HPValue[index1] = num6 * 0.00134102209;
					if (HPValue[index1] > m_dHPMax)
						m_dHPMax = HPValue[index1];
					TQValue[index1] = HPValue[index1] * 5252.0 / (SampleRPM[index1] * 1000.0);
					if (TQValue[index1] > m_dTQMax)
						m_dTQMax = TQValue[index1];
					index1 = index2;
				}
				while (index1 < m_arrRpmValues.Count - 1);
			}
			dyno.XData1 = SampleRPM;
			dyno.YData1 = HPValue;
			dyno.XData2 = SampleRPM;
			dyno.YData2 = TQValue;
			dyno.YRangeEnd = m_dHPMax < m_dTQMax ? m_dTQMax : m_dHPMax;
			dyno.YRangeEnd = (double)Convert.ToInt32(dyno.YRangeEnd + 0.5);
			if (Convert.ToInt32(dyno.YRangeEnd) % Convert.ToInt32(dyno.YGrid) != 0)
			{
				do
				{
					dyno.YRangeEnd = dyno.YRangeEnd + 1.0;
				}
				while (Convert.ToInt32(dyno.YRangeEnd) % Convert.ToInt32(dyno.YGrid) != 0);
			}
			dyno.ShowData1 = true;
			dyno.ShowData2 = true;
			dyno.Refresh();
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
			float num1 = (float)e.MarginBounds.Left;
			float num2 = (float)e.MarginBounds.Right;
			float num3 = (float)e.MarginBounds.Top;
			int bottom = e.MarginBounds.Bottom;
			float num4 = num2 - num1;
			e.Graphics.DrawImage(dyno.getImage(), Convert.ToInt32(num1), Convert.ToInt32(num3), Convert.ToInt32(num4), Convert.ToInt32(num4 * 0.6666667f));
		}

		private Image getDynoImage()
		{
			Bitmap bitmap = new Bitmap(dyno.Width, dyno.Height);
			Graphics.FromImage((Image)bitmap).DrawImage(dyno.getImage(), 0, 0, dyno.Width, dyno.Height);
			return (Image)bitmap;
		}

		public void ReceiveResponse(OBD2Response obd2Response)
		{
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
			printPreviewDialog1.ShowDialog();
		}

		private void PageSetup()
		{
			pageSetupDialog1.ShowDialog();
		}

		private void Print()
		{
			if (printDialog1.ShowDialog() != DialogResult.OK)
				return;
			printDocument1.Print();
		}

		private void btnExportJPEG_Click(object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Title = "Export as JPEG";
			dialog.Filter = "JPEG files (*.jpg)|*.jpg";
			dialog.FilterIndex = 0;
			dialog.RestoreDirectory = true;
			dialog.ShowDialog();
			if (dialog.FileName != "")
				getDynoImage().Save(dialog.FileName, ImageFormat.Jpeg);
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			m_bCapture = false;
			HPValue = (double[])null;
			TQValue = (double[])null;
			SampleRPM = (double[])null;
			dyno.XData1 = SampleRPM;
			dyno.YData1 = HPValue;
			dyno.XData2 = SampleRPM;
			dyno.YData2 = TQValue;
			btnStart.Enabled = true;
			btnReset.Enabled = false;
			btnOpen.Enabled = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (m_arrRpmValues == null)
			{
				MessageBox.Show("You must first perform a dyno pull or open a previous session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.Title = "Save Dyno Session";
				dialog.Filter = "Dyno files (*.dyn)|*.dyn";
				dialog.FilterIndex = 0;
				dialog.RestoreDirectory = true;
				dialog.ShowDialog();
				if (dialog.FileName != "")
				{
					DynoRecord record = new DynoRecord();
					record.RpmList = m_arrRpmValues;
					record.Weight = m_dVehicleWeight;
					record.Label = dyno.Label;
					Type[] typeArray = new Type[] { typeof(ArrayList), typeof(DatedValue) };
					TextWriter writer = new StreamWriter(dialog.FileName);
					new XmlSerializer(typeof(DynoRecord), typeArray).Serialize(writer, record);
					writer.Close();
				}
			}
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Dyno files (*.dyn)|*.dyn";
			openFileDialog.FilterIndex = 0;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;
			XmlSerializer xmlSerializer = new XmlSerializer(
				typeof(DynoRecord),
				new System.Type[] { typeof(ArrayList), typeof(DatedValue) }
				);
			FileStream fileStream1 = new FileStream(openFileDialog.FileName, FileMode.Open);
			FileStream fileStream2 = fileStream1;
			DynoRecord dynoRecord = (DynoRecord)xmlSerializer.Deserialize((Stream)fileStream2);
			fileStream1.Close();
			m_dVehicleWeight = dynoRecord.Weight;
			dyno.Label = dynoRecord.Label;
			m_arrRpmValues = dynoRecord.RpmList;
			Calculate();
		}

		private void numFromRPM_ValueChanged(object sender, EventArgs e)
		{
			dyno.XRangeStart = Convert.ToDouble(numFromRPM.Value / 1000M);
			numToRPM.Minimum = numFromRPM.Value + 1000M;
		}

		private void numToRPM_ValueChanged(object sender, EventArgs e)
		{
			dyno.XRangeEnd = Convert.ToDouble(numToRPM.Value / 1000M);
			numFromRPM.Maximum = numToRPM.Value - 1000M;
		}

		public void CheckConnection()
		{
			if (m_obdInterface.getConnectedStatus())
			{
				btnStart.Enabled = true;
				btnReset.Enabled = true;
			}
			else
			{
				btnStart.Enabled = false;
				btnReset.Enabled = false;
			}
		}

		private void DynoForm_Activated(object sender, EventArgs e)
		{
			CheckConnection();
		}
	}
}