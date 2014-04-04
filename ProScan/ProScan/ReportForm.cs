using DiagnosticReport;
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
		private Container components;

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
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
    {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
			printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			printDocument1 = new System.Drawing.Printing.PrintDocument();
			printDialog1 = new System.Windows.Forms.PrintDialog();
			btnPrint = new System.Windows.Forms.Button();
			btnPreview = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			printDialog2 = new System.Windows.Forms.PrintDialog();
			panel = new System.Windows.Forms.Panel();
			ReportPage1 = new DiagnosticReport.DiagnosticReportControl();
			panel.SuspendLayout();
			SuspendLayout();
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
			// printDocument1
			// 
			printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_BeginPrint);
			printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
			// 
			// printDialog1
			// 
			printDialog1.Document = printDocument1;
			// 
			// btnPrint
			// 
			btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnPrint.Location = new System.Drawing.Point(347, 5);
			btnPrint.Name = "btnPrint";
			btnPrint.Size = new System.Drawing.Size(75, 23);
			btnPrint.TabIndex = 1;
			btnPrint.Text = "&Print";
			btnPrint.Click += new System.EventHandler(btnPrint_Click);
			// 
			// btnPreview
			// 
			btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnPreview.Location = new System.Drawing.Point(263, 5);
			btnPreview.Name = "btnPreview";
			btnPreview.Size = new System.Drawing.Size(75, 23);
			btnPreview.TabIndex = 2;
			btnPreview.Text = "P&review";
			btnPreview.Click += new System.EventHandler(btnPreview_Click);
			// 
			// btnSave
			// 
			btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
			btnSave.Location = new System.Drawing.Point(431, 5);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(75, 23);
			btnSave.TabIndex = 3;
			btnSave.Text = "&Save";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			// 
			// panel
			// 
			panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			panel.AutoScroll = true;
			panel.BackColor = System.Drawing.Color.White;
			panel.Controls.Add(ReportPage1);
			panel.Location = new System.Drawing.Point(0, 32);
			panel.Name = "panel";
			panel.Size = new System.Drawing.Size(768, 474);
			panel.TabIndex = 5;
			// 
			// ReportPage1
			// 
			ReportPage1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			ReportPage1.BackColor = System.Drawing.Color.White;
			ReportPage1.BorderColor = System.Drawing.Color.Blue;
			ReportPage1.CalculatedLoad = 0D;
			ReportPage1.CatalystMonitorCompleted = false;
			ReportPage1.CatalystMonitorSupported = false;
			ReportPage1.ClientAddress1 = " ";
			ReportPage1.ClientAddress2 = " ";
			ReportPage1.ClientName = " ";
			ReportPage1.ClientTelephone = " ";
			ReportPage1.ComprehensiveMonitorCompleted = false;
			ReportPage1.ComprehensiveMonitorSupported = false;
			ReportPage1.DTCDefinitionList = null;
			ReportPage1.DTCList = null;
			ReportPage1.EGRSystemMonitorCompleted = false;
			ReportPage1.EGRSystemMonitorSupported = false;
			ReportPage1.EngineCoolantTemp = 0D;
			ReportPage1.EngineRPM = 0D;
			ReportPage1.EvapSystemMonitorCompleted = false;
			ReportPage1.EvapSystemMonitorSupported = false;
			ReportPage1.FreezeFrameDTC = "P0000";
			ReportPage1.FuelSystem1Status = "0";
			ReportPage1.FuelSystem2Status = "0";
			ReportPage1.FuelSystemMonitorCompleted = false;
			ReportPage1.FuelSystemMonitorSupported = false;
			ReportPage1.GenerationDate = " ";
			ReportPage1.HeatedCatalystMonitorCompleted = false;
			ReportPage1.HeatedCatalystMonitorSupported = false;
			ReportPage1.IntakePressure = 0D;
			ReportPage1.Location = new System.Drawing.Point(-13, 5);
			ReportPage1.LTFT1 = 0D;
			ReportPage1.LTFT2 = 0D;
			ReportPage1.LTFT3 = 0D;
			ReportPage1.LTFT4 = 0D;
			ReportPage1.MilOffImage = ((System.Drawing.Image)(resources.GetObject("ReportPage1.MilOffImage")));
			ReportPage1.MilOnImage = ((System.Drawing.Image)(resources.GetObject("ReportPage1.MilOnImage")));
			ReportPage1.MilStatus = false;
			ReportPage1.MisfireMonitorCompleted = false;
			ReportPage1.MisfireMonitorSupported = false;
			ReportPage1.Name = "ReportPage1";
			ReportPage1.OxygenSensorHeaterMonitorCompleted = false;
			ReportPage1.OxygenSensorHeaterMonitorSupported = false;
			ReportPage1.OxygenSensorMonitorCompleted = false;
			ReportPage1.OxygenSensorMonitorSupported = false;
			ReportPage1.PendingDefinitionList = null;
			ReportPage1.PendingList = null;
			ReportPage1.RefrigerantMonitorCompleted = false;
			ReportPage1.RefrigerantMonitorSupported = false;
			ReportPage1.SecondaryAirMonitorCompleted = false;
			ReportPage1.SecondaryAirMonitorSupported = false;
			ReportPage1.ShopAddress1 = " ";
			ReportPage1.ShopAddress2 = " ";
			ReportPage1.ShopName = " ";
			ReportPage1.ShopTelephone = " ";
			ReportPage1.ShowCalculatedLoad = false;
			ReportPage1.ShowEngineCoolantTemp = false;
			ReportPage1.ShowEngineRPM = false;
			ReportPage1.ShowFuelSystemStatus = false;
			ReportPage1.ShowIntakePressure = false;
			ReportPage1.ShowLTFT13 = false;
			ReportPage1.ShowLTFT24 = false;
			ReportPage1.ShowSparkAdvance = false;
			ReportPage1.ShowSTFT13 = false;
			ReportPage1.ShowSTFT24 = false;
			ReportPage1.ShowVehicleSpeed = false;
			ReportPage1.Size = new System.Drawing.Size(750, 1000);
			ReportPage1.SparkAdvance = 0D;
			ReportPage1.STFT1 = 0D;
			ReportPage1.STFT2 = 0D;
			ReportPage1.STFT3 = 0D;
			ReportPage1.STFT4 = 0D;
			ReportPage1.TabIndex = 0;
			ReportPage1.TotalCodes = 0;
			ReportPage1.Vehicle = " ";
			ReportPage1.VehicleSpeed = 0D;
			// 
			// ReportForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(768, 510);
			Controls.Add(panel);
			Controls.Add(btnSave);
			Controls.Add(btnPreview);
			Controls.Add(btnPrint);
			Name = "ReportForm";
			Text = "OBD-II Diagnostic Report";
			panel.ResumeLayout(false);
			ResumeLayout(false);

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