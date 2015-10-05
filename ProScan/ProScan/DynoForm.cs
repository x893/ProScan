using DGChart;
using System;
using System.Collections;
using System.Collections.Generic;
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
		private Button btnStart;
		private GroupBox groupControl;
		private Button btnReset;
		private GroupBox groupChart;
		private Button btnSave;
		private Button btnOpen;
		private Button btnPrint;
		private GroupBox groupGraph;
		private PrintDialog printDialog;
		private PrintPreviewDialog printPreviewDialog;
		private PageSetupDialog pageSetupDialog;
		private PrintDocument printDocument;
		private GroupBox groupExport;
		private Button btnExportJPEG;
		private DynoControl dyno;
		private GroupBox groupSetup;
		private Label lblFromRPM;
		private Label lblToRPM;
		private NumericUpDown numFromRPM;
		private NumericUpDown numToRPM;

		private OBDInterface m_obdInterface;
		private VehicleProfile m_profile;
		private double m_HPMax;
		private double m_TQMax;
		private bool m_Capture;
		private List<DatedValue> m_RpmValues;
		private List<DatedValue> m_KphValues;
		private double[] m_HPValue;
		private double[] m_TQValue;
		private double[] m_SampleRPM;
		private double m_dVehicleWeight;
		private DateTime m_dtDynoTime;

		public DynoForm(OBDInterface obd)
		{
			m_obdInterface = obd;
			m_profile = obd.ActiveProfile;

			InitializeComponent();

			m_Capture = false;
			m_dtDynoTime = DateTime.Now;
			btnStart.Enabled = false;
			btnReset.Enabled = false;
			printDocument.DefaultPageSettings = new PageSettings();
			printDocument.DefaultPageSettings.Margins = new Margins(100, 100, 100, 100);
			printDocument.DefaultPageSettings.Landscape = true;
			pageSetupDialog.Document = printDocument;
		}

		#region InitializeComponent
		protected override void Dispose(bool disposing)
		{
			m_Capture = false;
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
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
			this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
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
			this.groupControl.Location = new System.Drawing.Point(12, 121);
			this.groupControl.Name = "groupControl";
			this.groupControl.Size = new System.Drawing.Size(180, 104);
			this.groupControl.TabIndex = 0;
			this.groupControl.TabStop = false;
			this.groupControl.Text = "Control";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(12, 63);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(156, 29);
			this.btnReset.TabIndex = 8;
			this.btnReset.Text = "&Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 23);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(156, 29);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "&Begin Dyno Pull";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// groupChart
			// 
			this.groupChart.Controls.Add(this.btnSave);
			this.groupChart.Controls.Add(this.btnOpen);
			this.groupChart.Controls.Add(this.btnPrint);
			this.groupChart.Location = new System.Drawing.Point(12, 237);
			this.groupChart.Name = "groupChart";
			this.groupChart.Size = new System.Drawing.Size(180, 144);
			this.groupChart.TabIndex = 2;
			this.groupChart.TabStop = false;
			this.groupChart.Text = "Chart";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(12, 23);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(156, 29);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(12, 63);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(156, 29);
			this.btnOpen.TabIndex = 6;
			this.btnOpen.Text = "&Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Location = new System.Drawing.Point(12, 104);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(156, 29);
			this.btnPrint.TabIndex = 7;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// groupGraph
			// 
			this.groupGraph.Controls.Add(this.dyno);
			this.groupGraph.Location = new System.Drawing.Point(204, 12);
			this.groupGraph.Name = "groupGraph";
			this.groupGraph.Size = new System.Drawing.Size(535, 486);
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
			this.dyno.Location = new System.Drawing.Point(2, 7);
			this.dyno.Logo = null;
			this.dyno.Name = "dyno";
			this.dyno.ShowData1 = true;
			this.dyno.ShowData2 = false;
			this.dyno.ShowData3 = false;
			this.dyno.ShowData4 = false;
			this.dyno.ShowData5 = false;
			this.dyno.Size = new System.Drawing.Size(531, 481);
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
			this.printDialog.Document = this.printDocument;
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
			// groupExport
			// 
			this.groupExport.Controls.Add(this.btnExportJPEG);
			this.groupExport.Location = new System.Drawing.Point(12, 392);
			this.groupExport.Name = "groupExport";
			this.groupExport.Size = new System.Drawing.Size(180, 64);
			this.groupExport.TabIndex = 5;
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
			// groupSetup
			// 
			this.groupSetup.Controls.Add(this.numToRPM);
			this.groupSetup.Controls.Add(this.numFromRPM);
			this.groupSetup.Controls.Add(this.lblToRPM);
			this.groupSetup.Controls.Add(this.lblFromRPM);
			this.groupSetup.Location = new System.Drawing.Point(12, 17);
			this.groupSetup.Name = "groupSetup";
			this.groupSetup.Size = new System.Drawing.Size(180, 93);
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
			this.numToRPM.Location = new System.Drawing.Point(96, 51);
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
			this.numToRPM.Size = new System.Drawing.Size(72, 22);
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
			this.numFromRPM.Location = new System.Drawing.Point(96, 23);
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
			this.numFromRPM.Size = new System.Drawing.Size(72, 22);
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
			this.lblToRPM.Location = new System.Drawing.Point(12, 51);
			this.lblToRPM.Name = "lblToRPM";
			this.lblToRPM.Size = new System.Drawing.Size(84, 23);
			this.lblToRPM.TabIndex = 4;
			this.lblToRPM.Text = "&To RPM:";
			this.lblToRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblFromRPM
			// 
			this.lblFromRPM.Location = new System.Drawing.Point(12, 23);
			this.lblFromRPM.Name = "lblFromRPM";
			this.lblFromRPM.Size = new System.Drawing.Size(84, 23);
			this.lblFromRPM.TabIndex = 2;
			this.lblFromRPM.Text = "&From RPM:";
			this.lblFromRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DynoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(749, 511);
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
		#endregion

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

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (!m_obdInterface.ConnectedStatus)
			{
				MessageBox.Show("A vehicle connection must first be established.", "Connection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				m_dtDynoTime = DateTime.Now;
				m_dVehicleWeight = m_profile.Weight;
				dyno.Label = m_profile.Name + "\r\n" + m_dtDynoTime.ToString("g");
				btnStart.Enabled = false;
				btnReset.Enabled = true;
				btnOpen.Enabled = false;
				m_Capture = true;
				ThreadPool.QueueUserWorkItem(new WaitCallback(Capture));
			}
		}

		private void DynoForm_Closing(object sender, CancelEventArgs e)
		{
			m_Capture = false;
		}

		private new void Capture(object state)
		{
			m_RpmValues = new List<DatedValue>();
			m_KphValues = new List<DatedValue>();
			OBDParameterValue value;
			DatedValue d_value;
			while (m_Capture)
			{
				value = m_obdInterface.getValue("SAE.RPM", true);
				if (!value.ErrorDetected)
				{
					d_value = new DatedValue(value.DoubleValue);
					d_value.Date = DateTime.Now;
					if (Convert.ToDecimal(d_value.Value) >= numFromRPM.Value
					&& Convert.ToDecimal(d_value.Value) <= numToRPM.Value)
					{
						m_RpmValues.Add(d_value);
						value = m_obdInterface.getValue("SAE.VSS", false);
						if (!value.ErrorDetected)
						{
							d_value = new DatedValue(value.DoubleValue * (double)m_obdInterface.ActiveProfile.SpeedCalibrationFactor);
							d_value.Date = DateTime.Now;
							m_KphValues.Add(d_value);
						}
						m_Capture = false;
					}
				}
			}
			Calculate();
			btnOpen.Enabled = true;
		}

		private void Calculate()
		{
			m_TQMax = 0.0;
			m_HPMax = 0.0;

			m_HPValue = new double[m_RpmValues.Count - 1];
			m_TQValue = new double[m_RpmValues.Count - 1];
			m_SampleRPM = new double[m_RpmValues.Count - 1];
			int idx = 0;
			if ((m_RpmValues.Count - 1) > 0)
			{
				do
				{
					double rpm_value_0 = m_RpmValues[idx].Value;
					int next = idx + 1;
					double rpm_value_1 = m_RpmValues[next].Value;
					DateTime rpm_date_0 = m_RpmValues[idx].Date;
					TimeSpan delta_time = m_RpmValues[next].Date.Subtract(rpm_date_0);
					rpm_date_0.AddSeconds(delta_time.TotalSeconds * 0.5);

					double kph_value_0 = m_KphValues[idx].Value;
					double kph_value_1 = m_KphValues[next].Value;
					DateTime kph_date_0 = m_KphValues[idx].Date;
					DateTime kph_date_1 = m_KphValues[next].Date;

					m_SampleRPM[idx] = (rpm_value_1 + rpm_value_0) * 0.5 * 0.001;
					double num5 = (kph_value_1 + kph_value_0) * 0.5 * 0.621371192 * 0.44704;
					double kw_value = m_dVehicleWeight * 0.45359237 * num5 * num5 * 0.5 / kph_date_1.Subtract(kph_date_0).TotalSeconds;

					m_HPValue[idx] = kw_value * 0.00134102209;
					if (m_HPValue[idx] > m_HPMax)
						m_HPMax = m_HPValue[idx];

					m_TQValue[idx] = m_HPValue[idx] * 5252.0 / (m_SampleRPM[idx] * 1000.0);

					if (m_TQValue[idx] > m_TQMax)
						m_TQMax = m_TQValue[idx];
					idx = next;
				}
				while (idx < m_RpmValues.Count - 1);
			}
			dyno.XData1 = m_SampleRPM;
			dyno.YData1 = m_HPValue;
			dyno.XData2 = m_SampleRPM;
			dyno.YData2 = m_TQValue;
			dyno.YRangeEnd = m_HPMax < m_TQMax ? m_TQMax : m_HPMax;
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
			if (printDialog.ShowDialog() != DialogResult.OK)
				return;
			printDocument.Print();
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

		private void Print()
		{
			if (printDialog.ShowDialog() != DialogResult.OK)
				return;
			printDocument.Print();
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
			m_Capture = false;
			m_HPValue = (double[])null;
			m_TQValue = (double[])null;
			m_SampleRPM = (double[])null;
			dyno.XData1 = m_SampleRPM;
			dyno.YData1 = m_HPValue;
			dyno.XData2 = m_SampleRPM;
			dyno.YData2 = m_TQValue;
			btnStart.Enabled = true;
			btnReset.Enabled = false;
			btnOpen.Enabled = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (m_RpmValues == null)
				MessageBox.Show("You must first perform a dyno pull or open a previous session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
					record.RpmList = m_RpmValues;
					record.Weight = m_dVehicleWeight;
					record.Label = dyno.Label;
					Type[] typeArray = new Type[] { typeof(List<DatedValue>), typeof(DatedValue) };
					using (TextWriter writer = new StreamWriter(dialog.FileName))
					{
						new XmlSerializer(typeof(DynoRecord), typeArray).Serialize(writer, record);
						writer.Close();
					}
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
				new System.Type[] { typeof(List<DatedValue>), typeof(DatedValue) }
				);
			DynoRecord dynoRecord;
			using (FileStream reader = new FileStream(openFileDialog.FileName, FileMode.Open))
			{
				dynoRecord = (DynoRecord)xmlSerializer.Deserialize(reader);
				reader.Close();
			}
			m_dVehicleWeight = dynoRecord.Weight;
			dyno.Label = dynoRecord.Label;
			m_RpmValues = dynoRecord.RpmList;
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
			if (m_obdInterface.ConnectedStatus)
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