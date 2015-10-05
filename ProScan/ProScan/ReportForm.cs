using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProScan
{
	public class ReportForm : Form
	{
		private PrintPreviewDialog printPreviewDialog1;
		private PrintDialog printDialog1;
		private PrintDocument printDocument1;
		private Button btnPrint;
		private Button btnPreview;
		private PrintDialog printDialog2;
		private Panel panel;
		public DiagnosticReportControl ReportPage1;
		private Button btnSave;

		public ReportForm()
		{
			InitializeComponent();
			ReportPage1.DTCList = new System.Collections.Specialized.StringCollection();
			ReportPage1.DTCDefinitionList = new System.Collections.Specialized.StringCollection();
			ReportPage1.PendingList = new System.Collections.Specialized.StringCollection();
			ReportPage1.PendingDefinitionList = new System.Collections.Specialized.StringCollection();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
    {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnPreview = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.printDialog2 = new System.Windows.Forms.PrintDialog();
			this.panel = new System.Windows.Forms.Panel();
			this.ReportPage1 = new ProScan.DiagnosticReportControl();
			this.panel.SuspendLayout();
			this.SuspendLayout();
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
			// printDocument1
			// 
			this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printDialog1
			// 
			this.printDialog1.Document = this.printDocument1;
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnPrint.Location = new System.Drawing.Point(552, 6);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(90, 26);
			this.btnPrint.TabIndex = 1;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnPreview
			// 
			this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnPreview.Location = new System.Drawing.Point(452, 6);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(90, 26);
			this.btnPreview.TabIndex = 2;
			this.btnPreview.Text = "P&review";
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnSave.Location = new System.Drawing.Point(653, 6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 26);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.AutoScroll = true;
			this.panel.BackColor = System.Drawing.Color.White;
			this.panel.Controls.Add(this.ReportPage1);
			this.panel.Location = new System.Drawing.Point(0, 37);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(1194, 670);
			this.panel.TabIndex = 5;
			// 
			// ReportPage1
			// 
			this.ReportPage1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.ReportPage1.BackColor = System.Drawing.Color.White;
			this.ReportPage1.BorderColor = System.Drawing.Color.Blue;
			this.ReportPage1.CalculatedLoad = 0D;
			this.ReportPage1.CatalystMonitorCompleted = false;
			this.ReportPage1.CatalystMonitorSupported = false;
			this.ReportPage1.ClientAddress1 = " ";
			this.ReportPage1.ClientAddress2 = " ";
			this.ReportPage1.ClientName = " ";
			this.ReportPage1.ClientTelephone = " ";
			this.ReportPage1.ComprehensiveMonitorCompleted = false;
			this.ReportPage1.ComprehensiveMonitorSupported = false;
			this.ReportPage1.DTCDefinitionList = null;
			this.ReportPage1.DTCList = null;
			this.ReportPage1.EGRSystemMonitorCompleted = false;
			this.ReportPage1.EGRSystemMonitorSupported = false;
			this.ReportPage1.EngineCoolantTemp = 0D;
			this.ReportPage1.EngineRPM = 0D;
			this.ReportPage1.EvapSystemMonitorCompleted = false;
			this.ReportPage1.EvapSystemMonitorSupported = false;
			this.ReportPage1.FreezeFrameDTC = "P0000";
			this.ReportPage1.FuelSystem1Status = "0";
			this.ReportPage1.FuelSystem2Status = "0";
			this.ReportPage1.FuelSystemMonitorCompleted = false;
			this.ReportPage1.FuelSystemMonitorSupported = false;
			this.ReportPage1.GenerationDate = " ";
			this.ReportPage1.HeatedCatalystMonitorCompleted = false;
			this.ReportPage1.HeatedCatalystMonitorSupported = false;
			this.ReportPage1.IntakePressure = 0D;
			this.ReportPage1.Location = new System.Drawing.Point(96, 6);
			this.ReportPage1.Logo = null;
			this.ReportPage1.LTFT1 = 0D;
			this.ReportPage1.LTFT2 = 0D;
			this.ReportPage1.LTFT3 = 0D;
			this.ReportPage1.LTFT4 = 0D;
			this.ReportPage1.MilOffImage = ((System.Drawing.Image)(resources.GetObject("ReportPage1.MilOffImage")));
			this.ReportPage1.MilOnImage = ((System.Drawing.Image)(resources.GetObject("ReportPage1.MilOnImage")));
			this.ReportPage1.MilStatus = false;
			this.ReportPage1.MisfireMonitorCompleted = false;
			this.ReportPage1.MisfireMonitorSupported = false;
			this.ReportPage1.Name = "ReportPage1";
			this.ReportPage1.OxygenSensorHeaterMonitorCompleted = false;
			this.ReportPage1.OxygenSensorHeaterMonitorSupported = false;
			this.ReportPage1.OxygenSensorMonitorCompleted = false;
			this.ReportPage1.OxygenSensorMonitorSupported = false;
			this.ReportPage1.PendingDefinitionList = null;
			this.ReportPage1.PendingList = null;
			this.ReportPage1.RefrigerantMonitorCompleted = false;
			this.ReportPage1.RefrigerantMonitorSupported = false;
			this.ReportPage1.SecondaryAirMonitorCompleted = false;
			this.ReportPage1.SecondaryAirMonitorSupported = false;
			this.ReportPage1.ShopAddress1 = " ";
			this.ReportPage1.ShopAddress2 = " ";
			this.ReportPage1.ShopName = " ";
			this.ReportPage1.ShopTelephone = " ";
			this.ReportPage1.ShowCalculatedLoad = false;
			this.ReportPage1.ShowEngineCoolantTemp = false;
			this.ReportPage1.ShowEngineRPM = false;
			this.ReportPage1.ShowFuelSystemStatus = false;
			this.ReportPage1.ShowIntakePressure = false;
			this.ReportPage1.ShowLTFT13 = false;
			this.ReportPage1.ShowLTFT24 = false;
			this.ReportPage1.ShowSparkAdvance = false;
			this.ReportPage1.ShowSTFT13 = false;
			this.ReportPage1.ShowSTFT24 = false;
			this.ReportPage1.ShowVehicleSpeed = false;
			this.ReportPage1.Size = new System.Drawing.Size(900, 1154);
			this.ReportPage1.SparkAdvance = 0D;
			this.ReportPage1.STFT1 = 0D;
			this.ReportPage1.STFT2 = 0D;
			this.ReportPage1.STFT3 = 0D;
			this.ReportPage1.STFT4 = 0D;
			this.ReportPage1.TabIndex = 0;
			this.ReportPage1.TotalCodes = 0;
			this.ReportPage1.Vehicle = " ";
			this.ReportPage1.VehicleSpeed = 0D;
			// 
			// ReportForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(1194, 711);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.btnPrint);
			this.Name = "ReportForm";
			this.Text = "OBD-II Diagnostic Report";
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

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
			Image image = ReportPage1.getImage();
			e.Graphics.DrawImage(image, 50, 50, 750, 1000);
			e.HasMorePages = false;
		}

		private void PrintPreview()
		{
			int num = (int)printPreviewDialog1.ShowDialog();
		}

		private void Print()
		{
			if (printDialog1.ShowDialog() != DialogResult.OK)
				return;
			printDocument1.Print();
		}

		private void btnPreview_Click(object sender, EventArgs e)
		{
			PrintPreview();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save OBD-II Diagnostic Report";
			saveFileDialog.Filter = "ProScan Report Files (*.obd)|*.obd";
			saveFileDialog.FilterIndex = 0;
			saveFileDialog.RestoreDirectory = true;
			int num = (int)saveFileDialog.ShowDialog();
			if (saveFileDialog.FileName.Length <= 0)
				return;
			FileStream fileStream = File.Create(saveFileDialog.FileName);
			BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream);
			binaryWriter.Write(ReportPage1.ShopName);
			binaryWriter.Write(ReportPage1.ShopAddress1);
			binaryWriter.Write(ReportPage1.ShopAddress2);
			binaryWriter.Write(ReportPage1.ShopTelephone);
			binaryWriter.Write(ReportPage1.ClientName);
			binaryWriter.Write(ReportPage1.ClientAddress1);
			binaryWriter.Write(ReportPage1.ClientAddress2);
			binaryWriter.Write(ReportPage1.ClientTelephone);
			binaryWriter.Write(ReportPage1.Vehicle);
			binaryWriter.Write(ReportPage1.GenerationDate);
			binaryWriter.Write(ReportPage1.MilStatus);
			binaryWriter.Write(ReportPage1.TotalCodes);
			binaryWriter.Write(ReportPage1.FreezeFrameDTC);
			int index1 = 0;
			do
			{
				if (ReportPage1.DTCList != null)
				{
					if (index1 < ReportPage1.DTCList.Count)
						binaryWriter.Write(ReportPage1.DTCList[index1]);
					else
						binaryWriter.Write("");
				}
				else
					binaryWriter.Write("");
				++index1;
			}
			while (index1 < 25);
			int index2 = 0;
			do
			{
				if (ReportPage1.DTCDefinitionList != null)
				{
					if (index2 < ReportPage1.DTCDefinitionList.Count)
						binaryWriter.Write(ReportPage1.DTCDefinitionList[index2]);
					else
						binaryWriter.Write("");
				}
				else
					binaryWriter.Write("");
				++index2;
			}
			while (index2 < 25);
			int index3 = 0;
			do
			{
				if (ReportPage1.PendingList != null)
				{
					if (index3 < ReportPage1.PendingList.Count)
						binaryWriter.Write(ReportPage1.PendingList[index3]);
					else
						binaryWriter.Write("");
				}
				else
					binaryWriter.Write("");
				++index3;
			}
			while (index3 < 25);
			int index4 = 0;
			do
			{
				if (ReportPage1.PendingDefinitionList != null)
				{
					if (index4 < ReportPage1.PendingDefinitionList.Count)
						binaryWriter.Write(ReportPage1.PendingDefinitionList[index4]);
					else
						binaryWriter.Write("");
				}
				else
					binaryWriter.Write("");
				++index4;
			}
			while (index4 < 25);
			binaryWriter.Write(ReportPage1.FuelSystem1Status);
			binaryWriter.Write(ReportPage1.FuelSystem2Status);
			binaryWriter.Write(ReportPage1.CalculatedLoad);
			binaryWriter.Write(ReportPage1.EngineCoolantTemp);
			binaryWriter.Write(ReportPage1.STFT1);
			binaryWriter.Write(ReportPage1.STFT2);
			binaryWriter.Write(ReportPage1.STFT3);
			binaryWriter.Write(ReportPage1.STFT4);
			binaryWriter.Write(ReportPage1.LTFT1);
			binaryWriter.Write(ReportPage1.LTFT2);
			binaryWriter.Write(ReportPage1.LTFT3);
			binaryWriter.Write(ReportPage1.LTFT4);
			binaryWriter.Write(ReportPage1.IntakePressure);
			binaryWriter.Write(ReportPage1.EngineRPM);
			binaryWriter.Write(ReportPage1.VehicleSpeed);
			binaryWriter.Write(ReportPage1.SparkAdvance);
			binaryWriter.Write(ReportPage1.ShowFuelSystemStatus);
			binaryWriter.Write(ReportPage1.ShowCalculatedLoad);
			binaryWriter.Write(ReportPage1.ShowEngineCoolantTemp);
			binaryWriter.Write(ReportPage1.ShowSTFT13);
			binaryWriter.Write(ReportPage1.ShowSTFT24);
			binaryWriter.Write(ReportPage1.ShowLTFT13);
			binaryWriter.Write(ReportPage1.ShowLTFT24);
			binaryWriter.Write(ReportPage1.ShowIntakePressure);
			binaryWriter.Write(ReportPage1.ShowEngineRPM);
			binaryWriter.Write(ReportPage1.ShowVehicleSpeed);
			binaryWriter.Write(ReportPage1.ShowSparkAdvance);
			binaryWriter.Write(ReportPage1.MisfireMonitorSupported);
			binaryWriter.Write(ReportPage1.MisfireMonitorCompleted);
			binaryWriter.Write(ReportPage1.FuelSystemMonitorSupported);
			binaryWriter.Write(ReportPage1.FuelSystemMonitorCompleted);
			binaryWriter.Write(ReportPage1.ComprehensiveMonitorSupported);
			binaryWriter.Write(ReportPage1.ComprehensiveMonitorCompleted);
			binaryWriter.Write(ReportPage1.CatalystMonitorSupported);
			binaryWriter.Write(ReportPage1.CatalystMonitorCompleted);
			binaryWriter.Write(ReportPage1.HeatedCatalystMonitorSupported);
			binaryWriter.Write(ReportPage1.HeatedCatalystMonitorCompleted);
			binaryWriter.Write(ReportPage1.EvapSystemMonitorSupported);
			binaryWriter.Write(ReportPage1.EvapSystemMonitorCompleted);
			binaryWriter.Write(ReportPage1.SecondaryAirMonitorSupported);
			binaryWriter.Write(ReportPage1.SecondaryAirMonitorCompleted);
			binaryWriter.Write(ReportPage1.RefrigerantMonitorSupported);
			binaryWriter.Write(ReportPage1.RefrigerantMonitorCompleted);
			binaryWriter.Write(ReportPage1.OxygenSensorMonitorSupported);
			binaryWriter.Write(ReportPage1.OxygenSensorMonitorCompleted);
			binaryWriter.Write(ReportPage1.OxygenSensorHeaterMonitorSupported);
			binaryWriter.Write(ReportPage1.OxygenSensorHeaterMonitorCompleted);
			binaryWriter.Write(ReportPage1.EGRSystemMonitorSupported);
			binaryWriter.Write(ReportPage1.EGRSystemMonitorCompleted);
			binaryWriter.Close();
			fileStream.Close();
		}
	}
}