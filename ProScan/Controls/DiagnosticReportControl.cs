using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DiagnosticReport
{
	public class DiagnosticReportControl : UserControl
	{
		public Color m_colorBorder;
		public Image m_imgLogo;
		public Image m_imgMilOn;
		public Image m_imgMilOff;
		public string m_strShopName;
		public string m_strShopAddress1;
		public string m_strShopAddress2;
		public string m_strShopTelephone;
		public string m_strClientName;
		public string m_strClientAddress1;
		public string m_strClientAddress2;
		public string m_strClientTelephone;
		public string m_strVehicle;
		public string m_strDate;
		public bool m_bMilStatus;
		public int m_iTotalCodes;
		public string m_strFreezeFrameDTC;
		public StringCollection m_listCodes;
		public StringCollection m_listDefinitions;
		public StringCollection m_listPending;
		public StringCollection m_listPendingDefinitions;
		public string m_strFuelSystem1Status;
		public string m_strFuelSystem2Status;
		public double m_dCalculatedLoad;
		public double m_dEngineCoolantTemp;
		public double m_dSTFT1;
		public double m_dSTFT2;
		public double m_dSTFT3;
		public double m_dSTFT4;
		public double m_dLTFT1;
		public double m_dLTFT2;
		public double m_dLTFT3;
		public double m_dLTFT4;
		public double m_dIntakePressure;
		public double m_dEngineRPM;
		public double m_dVehicleSpeed;
		public double m_dSparkAdvance;
		public bool m_bShowFuelSystemStatus;
		public bool m_bShowCalculatedLoad;
		public bool m_bShowEngineCoolantTemp;
		public bool m_bShowSTFT13;
		public bool m_bShowSTFT24;
		public bool m_bShowLTFT13;
		public bool m_bShowLTFT24;
		public bool m_bShowIntakePressure;
		public bool m_bShowEngineRPM;
		public bool m_bShowVehicleSpeed;
		public bool m_bShowSparkAdvance;
		public bool m_bMisfireMonitorSupported;
		public bool m_bMisfireMonitorCompleted;
		public bool m_bFuelSystemMonitorSupported;
		public bool m_bFuelSystemMonitorCompleted;
		public bool m_bComprehensiveMonitorSupported;
		public bool m_bComprehensiveMonitorCompleted;
		public bool m_bCatalystMonitorSupported;
		public bool m_bCatalystMonitorCompleted;
		public bool m_bHeatedCatalystMonitorSupported;
		public bool m_bHeatedCatalystMonitorCompleted;
		public bool m_bEvapSystemMonitorSupported;
		public bool m_bEvapSystemMonitorCompleted;
		public bool m_bSecondaryAirMonitorSupported;
		public bool m_bSecondaryAirMonitorCompleted;
		public bool m_bRefrigerantMonitorSupported;
		public bool m_bRefrigerantMonitorCompleted;
		public bool m_bOxygenSensorMonitorSupported;
		public bool m_bOxygenSensorMonitorCompleted;
		public bool m_bOxygenSensorHeaterMonitorSupported;
		public bool m_bOxygenSensorHeaterMonitorCompleted;
		public bool m_bEGRSystemMonitorSupported;
		public bool m_bEGRSystemMonitorCompleted;
		public Container components;

		[Category("Report")]
		[Description("Show Spark Advance")]
		public bool ShowSparkAdvance
		{
			get { return m_bShowSparkAdvance; }
			set { m_bShowSparkAdvance = value; }
		}

		[Category("Report")]
		[Description("Show Vehicle Speed")]
		public bool ShowVehicleSpeed
		{
			get { return m_bShowVehicleSpeed; }
			set { m_bShowVehicleSpeed = value; }
		}

		[Description("Show Engine RPM")]
		[Category("Report")]
		public bool ShowEngineRPM
		{
			get { return m_bShowEngineRPM; }
			set { m_bShowEngineRPM = value; }
		}

		[Description("Show Intake Manifold Pressure")]
		[Category("Report")]
		public bool ShowIntakePressure
		{
			get { return m_bShowIntakePressure; }
			set { m_bShowIntakePressure = value; }
		}

		[Description("Show LTFT Banks 2 and 4")]
		[Category("Report")]
		public bool ShowLTFT24
		{
			get { return m_bShowLTFT24; }
			set { m_bShowLTFT24 = value; }
		}

		[Category("Report")]
		[Description("Show LTFT Banks 1 and 3")]
		public bool ShowLTFT13
		{
			get { return m_bShowLTFT13; }
			set { m_bShowLTFT13 = value; }
		}

		[Category("Report")]
		[Description("Show STFT Banks 2 and 4")]
		public bool ShowSTFT24
		{
			get { return m_bShowSTFT24; }
			set { m_bShowSTFT24 = value; }
		}

		[Description("Show STFT Banks 1 and 3")]
		[Category("Report")]
		public bool ShowSTFT13
		{
			get { return m_bShowSTFT13; }
			set { m_bShowSTFT13 = value; }
		}

		[Description("Show Engine Coolant Temp")]
		[Category("Report")]
		public bool ShowEngineCoolantTemp
		{
			get
			{
				return m_bShowEngineCoolantTemp;
			}
			set
			{
				m_bShowEngineCoolantTemp = value;
			}
		}

		[Description("Show Calculated Load")]
		[Category("Report")]
		public bool ShowCalculatedLoad
		{
			get
			{
				return m_bShowCalculatedLoad;
			}
			set
			{
				m_bShowCalculatedLoad = value;
			}
		}

		[Category("Report")]
		[Description("Show Fuel System Status")]
		public bool ShowFuelSystemStatus
		{
			get { return m_bShowFuelSystemStatus; }
			set { m_bShowFuelSystemStatus = value; }
		}

		[Description("Is EGR System Monitor Completed?")]
		[Category("Report")]
		public bool EGRSystemMonitorCompleted
		{
			get { return m_bEGRSystemMonitorCompleted; }
			set { m_bEGRSystemMonitorCompleted = value; }
		}

		[Category("Report")]
		[Description("Is EGR System Monitor Supported?")]
		public bool EGRSystemMonitorSupported
		{
			get { return m_bEGRSystemMonitorSupported; }
			set { m_bEGRSystemMonitorSupported = value; }
		}

		[Description("Is Oxygen Sensor Heater Monitor Completed?")]
		[Category("Report")]
		public bool OxygenSensorHeaterMonitorCompleted
		{
			get { return m_bOxygenSensorHeaterMonitorCompleted; }
			set { m_bOxygenSensorHeaterMonitorCompleted = value; }
		}

		[Category("Report")]
		[Description("Is Oxygen Sensor Heater Monitor Supported?")]
		public bool OxygenSensorHeaterMonitorSupported
		{
			get { return m_bOxygenSensorHeaterMonitorSupported; }
			set { m_bOxygenSensorHeaterMonitorSupported = value; }
		}

		[Category("Report")]
		[Description("Is Oxygen Sensor Monitor Completed?")]
		public bool OxygenSensorMonitorCompleted
		{
			get { return m_bOxygenSensorMonitorCompleted; }
			set { m_bOxygenSensorMonitorCompleted = value; }
		}

		[Description("Is Oxygen Sensor Monitor Supported?")]
		[Category("Report")]
		public bool OxygenSensorMonitorSupported
		{
			get { return m_bOxygenSensorMonitorSupported; }
			set { m_bOxygenSensorMonitorSupported = value; }
		}

		[Description("Is A/C System Refrigerant Monitor Completed?")]
		[Category("Report")]
		public bool RefrigerantMonitorCompleted
		{
			get { return m_bRefrigerantMonitorCompleted; }
			set { m_bRefrigerantMonitorCompleted = value; }
		}

		[Category("Report")]
		[Description("Is A/C System Refrigerant Monitor Supported?")]
		public bool RefrigerantMonitorSupported
		{
			get { return m_bRefrigerantMonitorSupported; }
			set { m_bRefrigerantMonitorSupported = value; }
		}

		[Description("Is Secondary Air System Monitor Completed?")]
		[Category("Report")]
		public bool SecondaryAirMonitorCompleted
		{
			get { return m_bSecondaryAirMonitorCompleted; }
			set { m_bSecondaryAirMonitorCompleted = value; }
		}

		[Category("Report")]
		[Description("Is Secondary Air System Monitor Supported?")]
		public bool SecondaryAirMonitorSupported
		{
			get { return m_bSecondaryAirMonitorSupported; }
			set { m_bSecondaryAirMonitorSupported = value; }
		}

		[Category("Report")]
		[Description("Is Evaporative System Monitor Completed?")]
		public bool EvapSystemMonitorCompleted
		{
			get { return m_bEvapSystemMonitorCompleted; }
			set { m_bEvapSystemMonitorCompleted = value; }
		}

		[Description("Is Evaporative System Monitor Supported?")]
		[Category("Report")]
		public bool EvapSystemMonitorSupported
		{
			get { return m_bEvapSystemMonitorSupported; }
			set { m_bEvapSystemMonitorSupported = value; }
		}

		[Category("Report")]
		[Description("Is Heated Catalyst Monitor Completed?")]
		public bool HeatedCatalystMonitorCompleted
		{
			get { return m_bHeatedCatalystMonitorCompleted; }
			set { m_bHeatedCatalystMonitorCompleted = value; }
		}

		[Category("Report")]
		[Description("Is Heated Catalyst Monitor Supported?")]
		public bool HeatedCatalystMonitorSupported
		{
			get { return m_bHeatedCatalystMonitorSupported; }
			set { m_bHeatedCatalystMonitorSupported = value; }
		}

		[Description("Is Catalyst Monitor Completed?")]
		[Category("Report")]
		public bool CatalystMonitorCompleted
		{
			get { return m_bCatalystMonitorCompleted; }
			set { m_bCatalystMonitorCompleted = value; }
		}

		[Category("Report")]
		[Description("Is Catalyst Monitor Supported?")]
		public bool CatalystMonitorSupported
		{
			get
			{
				return m_bCatalystMonitorSupported;
			}
			set
			{
				m_bCatalystMonitorSupported = value;
			}
		}

		[Category("Report")]
		[Description("Is Comprehensive Component Monitor Completed?")]
		public bool ComprehensiveMonitorCompleted
		{
			get
			{
				return m_bComprehensiveMonitorCompleted;
			}
			set
			{
				m_bComprehensiveMonitorCompleted = value;
			}
		}

		[Description("Is Comprehensive Component Monitor Supported?")]
		[Category("Report")]
		public bool ComprehensiveMonitorSupported
		{
			get { return m_bComprehensiveMonitorSupported; }
			set { m_bComprehensiveMonitorSupported = value; }
		}

		[Category("Report")]
		[Description("Is Fuel System Monitor Completed?")]
		public bool FuelSystemMonitorCompleted
		{
			get
			{
				return m_bFuelSystemMonitorCompleted;
			}
			set
			{
				m_bFuelSystemMonitorCompleted = value;
			}
		}

		[Description("Is Fuel System Monitor Supported?")]
		[Category("Report")]
		public bool FuelSystemMonitorSupported
		{
			get
			{
				return m_bFuelSystemMonitorSupported;
			}
			set
			{
				m_bFuelSystemMonitorSupported = value;
			}
		}

		[Description("Is Misfire Monitor Completed?")]
		[Category("Report")]
		public bool MisfireMonitorCompleted
		{
			get
			{
				return m_bMisfireMonitorCompleted;
			}
			set
			{
				m_bMisfireMonitorCompleted = value;
			}
		}

		[Description("Is Misfire Monitor Supported?")]
		[Category("Report")]
		public bool MisfireMonitorSupported
		{
			get
			{
				return m_bMisfireMonitorSupported;
			}
			set
			{
				m_bMisfireMonitorSupported = value;
			}
		}

		[Description("Ignition Timing Advance (deg)")]
		[Category("Report")]
		public double SparkAdvance
		{
			get
			{
				return m_dSparkAdvance;
			}
			set
			{
				m_dSparkAdvance = value;
			}
		}

		[Category("Report")]
		[Description("Vehicle Speed (mph)")]
		public double VehicleSpeed
		{
			get
			{
				return m_dVehicleSpeed;
			}
			set
			{
				m_dVehicleSpeed = value;
			}
		}

		[Category("Report")]
		[Description("Engine RPM (rev/min)")]
		public double EngineRPM
		{
			get
			{
				return m_dEngineRPM;
			}
			set
			{
				m_dEngineRPM = value;
			}
		}

		[Category("Report")]
		[Description("Intake Manifold Pressure (inHg)")]
		public double IntakePressure
		{
			get
			{
				return m_dIntakePressure;
			}
			set
			{
				m_dIntakePressure = value;
			}
		}

		[Category("Report")]
		[Description("Long Term Fuel Trim - Bank 4 (%)")]
		public double LTFT4
		{
			get
			{
				return m_dLTFT4;
			}
			set
			{
				m_dLTFT4 = value;
			}
		}

		[Category("Report")]
		[Description("Long Term Fuel Trim - Bank 3 (%)")]
		public double LTFT3
		{
			get
			{
				return m_dLTFT3;
			}
			set
			{
				m_dLTFT3 = value;
			}
		}

		[Category("Report")]
		[Description("Long Term Fuel Trim - Bank 2 (%)")]
		public double LTFT2
		{
			get
			{
				return m_dLTFT2;
			}
			set
			{
				m_dLTFT2 = value;
			}
		}

		[Description("Long Term Fuel Trim - Bank 1 (%)")]
		[Category("Report")]
		public double LTFT1
		{
			get
			{
				return m_dLTFT1;
			}
			set
			{
				m_dLTFT1 = value;
			}
		}

		[Category("Report")]
		[Description("Short Term Fuel Trim - Bank 4 (%)")]
		public double STFT4
		{
			get
			{
				return m_dSTFT4;
			}
			set
			{
				m_dSTFT4 = value;
			}
		}

		[Description("Short Term Fuel Trim - Bank 3 (%)")]
		[Category("Report")]
		public double STFT3
		{
			get
			{
				return m_dSTFT3;
			}
			set
			{
				m_dSTFT3 = value;
			}
		}

		[Description("Short Term Fuel Trim - Bank 2 (%)")]
		[Category("Report")]
		public double STFT2
		{
			get
			{
				return m_dSTFT2;
			}
			set
			{
				m_dSTFT2 = value;
			}
		}

		[Category("Report")]
		[Description("Short Term Fuel Trim - Bank 1 (%)")]
		public double STFT1
		{
			get
			{
				return m_dSTFT1;
			}
			set
			{
				m_dSTFT1 = value;
			}
		}

		[Description("Engine Coolant Temperature (Fahrenheit)")]
		[Category("Report")]
		public double EngineCoolantTemp
		{
			get
			{
				return m_dEngineCoolantTemp;
			}
			set
			{
				m_dEngineCoolantTemp = value;
			}
		}

		[Description("Calculated Load Value (%)")]
		[Category("Report")]
		public double CalculatedLoad
		{
			get
			{
				return m_dCalculatedLoad;
			}
			set
			{
				m_dCalculatedLoad = value;
			}
		}

		[Category("Report")]
		[Description("Fuel System 2 Status")]
		public string FuelSystem2Status
		{
			get
			{
				return m_strFuelSystem2Status;
			}
			set
			{
				m_strFuelSystem2Status = value;
			}
		}

		[Description("Fuel System 1 Status")]
		[Category("Report")]
		public string FuelSystem1Status
		{
			get
			{
				return m_strFuelSystem1Status;
			}
			set
			{
				m_strFuelSystem1Status = value;
			}
		}

		[Category("Report")]
		[Description("List of pending trouble code definitions.")]
		public StringCollection PendingDefinitionList
		{
			get
			{
				return m_listPendingDefinitions;
			}
			set
			{
				m_listPendingDefinitions = value;
			}
		}

		[Category("Report")]
		[Description("List of pending trouble codes.")]
		public StringCollection PendingList
		{
			get
			{
				return m_listPending;
			}
			set
			{
				m_listPending = value;
			}
		}

		[Description("List of trouble code definitions.")]
		[Category("Report")]
		public StringCollection DTCDefinitionList
		{
			get
			{
				return m_listDefinitions;
			}
			set
			{
				m_listDefinitions = value;
			}
		}

		[Description("List of trouble codes stored.")]
		[Category("Report")]
		public StringCollection DTCList
		{
			get
			{
				return m_listCodes;
			}
			set
			{
				m_listCodes = value;
			}
		}

		[Category("Report")]
		[Description("Number of trouble codes stored.")]
		public int TotalCodes
		{
			get
			{
				return m_iTotalCodes;
			}
			set
			{
				m_iTotalCodes = value;
			}
		}

		[Description("Status of the vehicle's MIL.")]
		[Category("Report")]
		public bool MilStatus
		{
			get
			{
				return m_bMilStatus;
			}
			set
			{
				m_bMilStatus = value;
			}
		}

		[Category("Report")]
		[Description("The DTC that triggered Freeze Frame storage.")]
		public string FreezeFrameDTC
		{
			get
			{
				return m_strFreezeFrameDTC;
			}
			set
			{
				m_strFreezeFrameDTC = value;
			}
		}

		[Description("The year, make, and model of vehicle.")]
		[Category("Report")]
		public string Vehicle
		{
			get
			{
				return m_strVehicle;
			}
			set
			{
				m_strVehicle = value;
			}
		}

		[Category("Report")]
		[Description("The date the report was generated.")]
		public string GenerationDate
		{
			get
			{
				return m_strDate;
			}
			set
			{
				m_strDate = value;
			}
		}

		[Description("The telephone number of the client receiving the service.")]
		[Category("Report")]
		public string ClientTelephone
		{
			get
			{
				return m_strClientTelephone;
			}
			set
			{
				m_strClientTelephone = value;
			}
		}

		[Category("Report")]
		[Description("The second address line of the client receiving the service.")]
		public string ClientAddress2
		{
			get
			{
				return m_strClientAddress2;
			}
			set
			{
				m_strClientAddress2 = value;
			}
		}

		[Description("The first address line of the client receiving the service.")]
		[Category("Report")]
		public string ClientAddress1
		{
			get
			{
				return m_strClientAddress1;
			}
			set
			{
				m_strClientAddress1 = value;
			}
		}

		[Description("The name of the client receiving the service.")]
		[Category("Report")]
		public string ClientName
		{
			get
			{
				return m_strClientName;
			}
			set
			{
				m_strClientName = value;
			}
		}

		[Category("Report")]
		[Description("The telephone number of the company providing the service.")]
		public string ShopTelephone
		{
			get
			{
				return m_strShopTelephone;
			}
			set
			{
				m_strShopTelephone = value;
			}
		}

		[Category("Report")]
		[Description("The second address line of the company providing the service.")]
		public string ShopAddress2
		{
			get
			{
				return m_strShopAddress2;
			}
			set
			{
				m_strShopAddress2 = value;
			}
		}

		[Category("Report")]
		[Description("The first address line of the company providing the service.")]
		public string ShopAddress1
		{
			get
			{
				return m_strShopAddress1;
			}
			set
			{
				m_strShopAddress1 = value;
			}
		}

		[Category("Report")]
		[Description("The name of the company providing the service.")]
		public string ShopName
		{
			get
			{
				return m_strShopName;
			}
			set
			{
				m_strShopName = value;
			}
		}

		[Category("Report")]
		[Description("The MIL On indicator graphic.")]
		public Image MilOnImage
		{
			get
			{
				return m_imgMilOn;
			}
			set
			{
				m_imgMilOn = value;
			}
		}

		[Description("The MIL Off indicator graphic.")]
		[Category("Report")]
		public Image MilOffImage
		{
			get
			{
				return m_imgMilOff;
			}
			set
			{
				m_imgMilOff = value;
			}
		}

		[Category("Report")]
		[Description("The logo to display in the header of the report.")]
		public Image Logo
		{
			get
			{
				return m_imgLogo;
			}
			set
			{
				m_imgLogo = value;
			}
		}

		[Description("The border color for the report.")]
		[Category("Report")]
		public Color BorderColor
		{
			get
			{
				return m_colorBorder;
			}
			set
			{
				m_colorBorder = value;
			}
		}

		public DiagnosticReportControl()
		{
			m_colorBorder = new Color();
			InitializeComponent();
			BorderColor = Color.Black;
			FreezeFrameDTC = "P0000";
			ShopName = " ";
			ShopAddress1 = " ";
			ShopAddress2 = " ";
			ShopTelephone = " ";
			ClientName = " ";
			ClientAddress1 = " ";
			ClientAddress2 = " ";
			ClientTelephone = " ";
			Vehicle = " ";
			GenerationDate = " ";
			DTCList = new StringCollection();
			DTCDefinitionList = new StringCollection();
			PendingList = new StringCollection();
			PendingDefinitionList = new StringCollection();
			m_bShowFuelSystemStatus = false;
			m_bShowCalculatedLoad = false;
			m_bShowEngineCoolantTemp = false;
			m_bShowSTFT13 = false;
			m_bShowSTFT24 = false;
			m_bShowLTFT13 = false;
			m_bShowLTFT24 = false;
			m_bShowIntakePressure = false;
			m_bShowEngineRPM = false;
			m_bShowVehicleSpeed = false;
			m_bShowSparkAdvance = false;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		public void InitializeComponent()
		{
			BackColor = Color.White;
			Name = "DiagnosticReportControl";
			Paint += new PaintEventHandler(DiagnosticReportControl_Paint);
		}

		public void setJunk()
		{
		}

		private void DiagnosticReportControl_Paint(object sender, PaintEventArgs e)
		{
			PaintControl(e.Graphics);
		}

		private void PaintControl(Graphics g)
		{
			Brush brush1 = (Brush)new SolidBrush(Color.Blue);
			Brush brush2 = (Brush)new SolidBrush(Color.Green);
			Brush brush3 = (Brush)new SolidBrush(Color.Red);
			Brush brush4 = (Brush)new SolidBrush(Color.Black);
			Brush brush5 = (Brush)new SolidBrush(Color.FromArgb(235, 235, (int)byte.MaxValue));
			Pen pen1 = new Pen(Color.Black);
			Pen pen2 = new Pen(Color.Blue);
			Pen pen3 = new Pen(BorderColor, 1f);
			Font font1 = new Font("Times New Roman", 12f, FontStyle.Bold);
			Font font2 = new Font("Times New Roman", 14f, FontStyle.Bold);
			Font font3 = new Font("Times New Roman", 10f);
			Font font4 = new Font("Times New Roman", 10f, FontStyle.Underline);
			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
			if (m_imgLogo != null)
			{
				int width = (int)((double)m_imgLogo.Width / (double)m_imgLogo.Height * 75.0);
				if (width > 240)
					width = 240;
				g.DrawImage(m_imgLogo, 5, 5, width, 75);
			}
			Font font6 = new Font("Arial", 18f);
			RectangleF layoutRectangle1 = new RectangleF();
			layoutRectangle1 = new RectangleF(250f, 5f, 500f, (float)font6.Height);
			g.DrawString("OBD-II Diagnostic Report", font6, brush4, layoutRectangle1, format);
			layoutRectangle1.X = layoutRectangle1.X - 1f;
			layoutRectangle1.Y = layoutRectangle1.Y - 1f;
			g.DrawString("OBD-II Diagnostic Report", font6, brush1, layoutRectangle1, format);
			Font font7 = new Font("Arial", 10f, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
			Font font8 = new Font("Arial", 8f);
			RectangleF layoutRectangle2 = new RectangleF();
			layoutRectangle2 = new RectangleF(250f, layoutRectangle1.Height + 5f, 250f, (float)font7.Height);
			g.DrawString("Prepared by:", font7, brush4, layoutRectangle2, format);
			layoutRectangle2.Height = (float)font8.Height;
			layoutRectangle2.Y = (float)((double)layoutRectangle2.Height + (double)layoutRectangle2.Y + 5.0);
			g.DrawString(ShopName, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.Y = layoutRectangle2.Height + layoutRectangle2.Y;
			g.DrawString(ShopAddress1, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.Y = layoutRectangle2.Height + layoutRectangle2.Y;
			g.DrawString(ShopAddress2, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.Y = layoutRectangle2.Height + layoutRectangle2.Y;
			g.DrawString(ShopTelephone, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.X = 500f;
			layoutRectangle2.Y = layoutRectangle1.Height + 5f;
			layoutRectangle2.Height = (float)font7.Height;
			g.DrawString("Prepared for:", font7, brush4, layoutRectangle2, format);
			layoutRectangle2.Height = (float)font8.Height;
			layoutRectangle2.Y = (float)((double)layoutRectangle2.Height + (double)layoutRectangle2.Y + 5.0);
			g.DrawString(ClientName, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.Y = layoutRectangle2.Height + layoutRectangle2.Y;
			g.DrawString(ClientAddress1, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.Y = layoutRectangle2.Height + layoutRectangle2.Y;
			g.DrawString(ClientAddress2, font8, brush4, layoutRectangle2, format);
			layoutRectangle2.Y = layoutRectangle2.Height + layoutRectangle2.Y;
			g.DrawString(ClientTelephone, font8, brush4, layoutRectangle2, format);
			g.DrawLine(pen2, 5, 110, 745, 110);
			g.DrawLine(pen2, 5, 112, 745, 112);
			string s1 = "We analyzed your " + Vehicle + " on " + GenerationDate + ".";
			RectangleF layoutRectangle3 = new RectangleF();
			layoutRectangle3 = new RectangleF(0.0f, 112f, 750f, 20f);
			Font font9 = new Font("Arial", 10f);
			g.DrawString(s1, font9, brush4, layoutRectangle3, format);
			g.DrawLine(pen2, 5, (int)layoutRectangle3.Bottom, 745, (int)layoutRectangle3.Bottom);
			g.DrawLine(pen2, 5, (int)layoutRectangle3.Bottom + 2, 745, (int)layoutRectangle3.Bottom + 2);
			int num1 = (int)layoutRectangle3.Bottom + 2;
			int num2 = num1 + 10;
			RectangleF layoutRectangle4 = new RectangleF();
			layoutRectangle4 = new RectangleF(5f, (float)num2, 100f, 20f);
			g.DrawRectangle(pen2, (int)layoutRectangle4.X, (int)layoutRectangle4.Y, (int)layoutRectangle4.Width, (int)layoutRectangle4.Height);
			g.DrawString("MIL Status", font1, brush1, layoutRectangle4, format);
			int num3 = font1.Height + num2 + 10;
			if (MilStatus && MilOnImage != null)
			{
				int x = 55 - MilOnImage.Width / 2;
				g.DrawImage(MilOnImage, x, num3 + 7, MilOnImage.Width, MilOnImage.Height);
				int num4 = MilOnImage.Height + num3 + 5;
				layoutRectangle4.Y = (float)num4 + 7f;
				g.DrawString("ON", font2, brush3, layoutRectangle4, format);
				layoutRectangle4.Y = (float)((double)layoutRectangle4.Height + (double)layoutRectangle4.Y + 17.0);
				g.DrawRectangle(pen2, (int)layoutRectangle4.X, (int)layoutRectangle4.Y, (int)layoutRectangle4.Width, (int)layoutRectangle4.Height);
				g.DrawString("Stored DTCs", font1, brush1, layoutRectangle4, format);
				layoutRectangle4.Y = (float)((double)layoutRectangle4.Height + (double)layoutRectangle4.Y + 10.0);
				int num5 = TotalCodes;
				g.DrawString(num5.ToString("d"), font2, brush3, layoutRectangle4, format);
			}
			else if (MilOffImage != null)
			{
				int x = 55 - MilOffImage.Width / 2;
				g.DrawImage(MilOffImage, x, num3 + 7, MilOffImage.Width, MilOffImage.Height);
				int num4 = MilOffImage.Height + num3 + 5;
				layoutRectangle4.Y = (float)num4 + 7f;
				g.DrawString("OFF", font2, brush2, layoutRectangle4, format);
				layoutRectangle4.Y = (float)((double)layoutRectangle4.Height + (double)layoutRectangle4.Y + 17.0);
				g.DrawRectangle(pen2, (int)layoutRectangle4.X, (int)layoutRectangle4.Y, (int)layoutRectangle4.Width, (int)layoutRectangle4.Height);
				g.DrawString("Stored DTCs", font1, brush1, layoutRectangle4, format);
				layoutRectangle4.Y = (float)((double)layoutRectangle4.Height + (double)layoutRectangle4.Y + 10.0);
				int num5 = TotalCodes;
				g.DrawString(num5.ToString("d"), font2, brush2, layoutRectangle4, format);
			}
			int y1 = num1 + 10;
			RectangleF layoutRectangle5 = new RectangleF();
			layoutRectangle5 = new RectangleF(115f, (float)y1, 630f, 20f);
			g.DrawRectangle(pen2, (int)layoutRectangle5.X, (int)layoutRectangle5.Y, (int)layoutRectangle5.Width, (int)layoutRectangle5.Height);
			g.DrawString("Stored Diagnostic Trouble Codes", font1, brush1, layoutRectangle5, format);
			int num6 = y1 + font1.Height + 10;
			layoutRectangle5.Height = (float)font3.Height;
			if (DTCList != null)
			{
				int count1 = DTCList.Count;
			}
			int index1 = 0;
			do
			{
				layoutRectangle5.X = 115f;
				layoutRectangle5.Y = (float)num6;
				if (index1 % 2 == 0)
					g.FillRectangle(brush5, (int)layoutRectangle5.X, (int)layoutRectangle5.Y, (int)layoutRectangle5.Width, (int)layoutRectangle5.Height);
				layoutRectangle5.X = layoutRectangle5.X + 5f;
				if (DTCList != null && DTCDefinitionList != null && (index1 < DTCList.Count && index1 < DTCDefinitionList.Count))
				{
					string s2 = DTCList[index1] + " = " + DTCDefinitionList[index1];
					g.DrawString(s2, font3, brush4, layoutRectangle5);
				}
				num6 = font3.Height + num6;
				++index1;
			}
			while (index1 < 5);
			int num7 = num6 + 5;
			layoutRectangle5.Height = 20f;
			layoutRectangle5.Y = (float)num7;
			layoutRectangle5.X = 115f;
			g.DrawRectangle(pen2, (int)layoutRectangle5.X, (int)layoutRectangle5.Y, (int)layoutRectangle5.Width, (int)layoutRectangle5.Height);
			g.DrawString("Pending Diagnostic Trouble Codes", font1, brush1, layoutRectangle5, format);
			int y2 = font1.Height + num7 + 10;
			layoutRectangle5.Height = (float)font3.Height;
			if (PendingList != null)
			{
				int count2 = PendingList.Count;
			}
			int index2 = 0;
			do
			{
				layoutRectangle5.X = 115f;
				layoutRectangle5.Y = (float)y2;
				if (index2 % 2 == 0)
					g.FillRectangle(brush5, (int)layoutRectangle5.X, (int)layoutRectangle5.Y, (int)layoutRectangle5.Width, (int)layoutRectangle5.Height);
				layoutRectangle5.X = layoutRectangle5.X + 5f;
				if (PendingList != null && PendingDefinitionList != null && (index2 < PendingList.Count && index2 < PendingDefinitionList.Count))
				{
					string s2 = PendingList[index2] + " = " + PendingDefinitionList[index2];
					g.DrawString(s2, font3, brush4, layoutRectangle5);
				}
				y2 = font3.Height + y2;
				++index2;
			}
			while (index2 < 5);
			g.DrawLine(pen2, 110, y1, 110, y2);
			int num8 = y2 + 5;
			g.DrawLine(pen2, 5, num8, 745, num8);
			g.DrawLine(pen2, 5, num8 + 2, 745, num8 + 2);
			int num9 = num8 + 12;
			bool flag = string.Compare(FreezeFrameDTC, "P0000") != 0;
			// new string((sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_05OIJEMFOP\u0040P0000\u003F\u0024AA\u0040)
			RectangleF layoutRectangle6 = new RectangleF();
			layoutRectangle6 = new RectangleF(5f, (float)num9, 740f, 20f);
			g.DrawRectangle(pen2, (int)layoutRectangle6.X, (int)layoutRectangle6.Y, (int)layoutRectangle6.Width, (int)layoutRectangle6.Height);
			string s3 = !flag ? "Freeze Frame Data (Not Available)" : "Freeze Frame Data (Triggered by: " + FreezeFrameDTC + ")";
			g.DrawString(s3, font1, brush1, layoutRectangle6, format);
			int num10 = font1.Height + num9 + 10;
			format.LineAlignment = StringAlignment.Near;
			RectangleF layoutRectangle7 = new RectangleF();
			float y3 = (float)num10;
			layoutRectangle7 = new RectangleF(5f, y3, 161f, (float)font3.Height);
			RectangleF layoutRectangle8 = new RectangleF();
			layoutRectangle8 = new RectangleF(layoutRectangle7.Right, y3, 66f, (float)font3.Height);
			RectangleF layoutRectangle9 = new RectangleF();
			layoutRectangle9 = new RectangleF(layoutRectangle8.Right, y3, 36f, (float)font3.Height);
			RectangleF layoutRectangle10 = new RectangleF();
			layoutRectangle10 = new RectangleF(layoutRectangle9.Right, y3, 66f, (float)font3.Height);
			RectangleF layoutRectangle11 = new RectangleF();
			layoutRectangle11 = new RectangleF(layoutRectangle10.Right, y3, 36f, (float)font3.Height);
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("Description", font4, brush4, layoutRectangle7, format);
			g.DrawString("English", font4, brush4, layoutRectangle8, format);
			g.DrawString("Units", font4, brush4, layoutRectangle9, format);
			g.DrawString("Metric", font4, brush4, layoutRectangle10, format);
			g.DrawString("Units", font4, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("Fuel System 1 Status", font3, brush4, layoutRectangle7);
			if (flag && m_bShowFuelSystemStatus)
			{
				g.DrawString(FuelSystem1Status, font3, brush4, layoutRectangle8, format);
				g.DrawString(FuelSystem1Status, font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("Calculated Load", font3, brush4, layoutRectangle7);
			if (flag && m_bShowCalculatedLoad)
			{
				double num4 = CalculatedLoad;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				// new string((sbyte*) &\u003CModule\u003E.\u003F\u003F_C\u0040_06HIJAJLEL\u0040\u003F\u0024CD\u003F\u0024CD0\u003F4\u003F\u0024CD\u003F\u0024CD\u003F\u0024AA\u0040)
				double num5 = CalculatedLoad;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("STFT - Bank 1", font3, brush4, layoutRectangle7);
			if (flag && m_bShowSTFT13)
			{
				double num4 = STFT1;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = STFT1;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("STFT - Bank 2", font3, brush4, layoutRectangle7);
			if (flag && m_bShowSTFT24)
			{
				double num4 = STFT2;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = STFT2;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("STFT - Bank 3", font3, brush4, layoutRectangle7);
			if (flag && m_bShowSTFT13)
			{
				double num4 = STFT3;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = STFT3;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("STFT - Bank 4", font3, brush4, layoutRectangle7);
			if (flag && m_bShowSTFT24)
			{
				double num4 = STFT4;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = STFT4;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("Intake Manifold Pressure", font3, brush4, layoutRectangle7);
			if (flag && m_bShowIntakePressure)
			{
				double num4 = IntakePressure * 3.38639;
				double num5 = IntakePressure;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle8, format);
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("inHg", font3, brush4, layoutRectangle9, format);
			g.DrawString("kPa", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("Vehicle Speed", font3, brush4, layoutRectangle7);
			if (flag && m_bShowVehicleSpeed)
			{
				double num4 = VehicleSpeed * 1.609344;
				double num5 = VehicleSpeed;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle8, format);
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("mph", font3, brush4, layoutRectangle9, format);
			g.DrawString("kph", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.X = layoutRectangle11.Right + 10f;
			layoutRectangle7.Y = y3;
			layoutRectangle8.X = layoutRectangle7.Right;
			layoutRectangle8.Y = y3;
			layoutRectangle9.X = layoutRectangle8.Right;
			layoutRectangle9.Y = y3;
			layoutRectangle10.X = layoutRectangle9.Right;
			layoutRectangle10.Y = y3;
			layoutRectangle11.X = layoutRectangle10.Right;
			layoutRectangle11.Y = y3;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("Description", font4, brush4, layoutRectangle7, format);
			g.DrawString("English", font4, brush4, layoutRectangle8, format);
			g.DrawString("Units", font4, brush4, layoutRectangle9, format);
			g.DrawString("Metric", font4, brush4, layoutRectangle10, format);
			g.DrawString("Units", font4, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("Fuel System 2 Status", font3, brush4, layoutRectangle7);
			if (flag && m_bShowFuelSystemStatus)
			{
				g.DrawString(FuelSystem2Status, font3, brush4, layoutRectangle8, format);
				g.DrawString(FuelSystem2Status, font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("", font3, brush4, layoutRectangle9, format);
			g.DrawString("", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("Engine Coolant Temp", font3, brush4, layoutRectangle7);
			if (flag && m_bShowEngineCoolantTemp)
			{
				double num4 = (EngineCoolantTemp - 32.0) * (5.0 / 9.0);
				double num5 = EngineCoolantTemp;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle8, format);
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("°F", font3, brush4, layoutRectangle9, format);
			g.DrawString("°C", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("LTFT - Bank 1", font3, brush4, layoutRectangle7);
			if (flag && m_bShowLTFT13)
			{
				double num4 = LTFT1;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = LTFT1;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("LTFT - Bank 2", font3, brush4, layoutRectangle7);
			if (flag && m_bShowLTFT24)
			{
				double num4 = LTFT2;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = LTFT2;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("LTFT - Bank 3", font3, brush4, layoutRectangle7);
			if (flag && m_bShowLTFT13)
			{
				double num4 = LTFT3;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = LTFT3;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("LTFT - Bank 4", font3, brush4, layoutRectangle7);
			if (flag && m_bShowLTFT24)
			{
				double num4 = LTFT4;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = LTFT4;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("%", font3, brush4, layoutRectangle9, format);
			g.DrawString("%", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.DrawString("Engine RPM", font3, brush4, layoutRectangle7);
			if (flag && m_bShowEngineRPM)
			{
				double num4 = EngineRPM;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = EngineRPM;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("rpm", font3, brush4, layoutRectangle9, format);
			g.DrawString("rpm", font3, brush4, layoutRectangle11, format);
			layoutRectangle7.Y = (float)font3.Height + layoutRectangle7.Y;
			layoutRectangle8.Y = (float)font3.Height + layoutRectangle8.Y;
			layoutRectangle9.Y = (float)font3.Height + layoutRectangle9.Y;
			layoutRectangle10.Y = (float)font3.Height + layoutRectangle10.Y;
			layoutRectangle11.Y = (float)font3.Height + layoutRectangle11.Y;
			g.FillRectangle(brush5, (int)layoutRectangle7.X, (int)layoutRectangle7.Y, (int)layoutRectangle7.Width, (int)layoutRectangle7.Height);
			g.FillRectangle(brush5, (int)layoutRectangle8.X, (int)layoutRectangle8.Y, (int)layoutRectangle8.Width, (int)layoutRectangle8.Height);
			g.FillRectangle(brush5, (int)layoutRectangle9.X, (int)layoutRectangle9.Y, (int)layoutRectangle9.Width, (int)layoutRectangle9.Height);
			g.FillRectangle(brush5, (int)layoutRectangle10.X, (int)layoutRectangle10.Y, (int)layoutRectangle10.Width, (int)layoutRectangle10.Height);
			g.FillRectangle(brush5, (int)layoutRectangle11.X, (int)layoutRectangle11.Y, (int)layoutRectangle11.Width, (int)layoutRectangle11.Height);
			g.DrawString("Spark Advance", font3, brush4, layoutRectangle7);
			if (flag && m_bShowSparkAdvance)
			{
				double num4 = SparkAdvance;
				g.DrawString(num4.ToString("f4"), font3, brush4, layoutRectangle8, format);
				double num5 = SparkAdvance;
				g.DrawString(num5.ToString("f4"), font3, brush4, layoutRectangle10, format);
			}
			else
			{
				g.DrawString("-", font3, brush4, layoutRectangle8, format);
				g.DrawString("-", font3, brush4, layoutRectangle10, format);
			}
			g.DrawString("°", font3, brush4, layoutRectangle9, format);
			g.DrawString("°", font3, brush4, layoutRectangle11, format);
			int num11 = (int)((double)layoutRectangle11.Bottom + 5.0);
			g.DrawLine(pen2, 5, num11, 745, num11);
			g.DrawLine(pen2, 5, num11 + 2, 745, num11 + 2);
			format.LineAlignment = StringAlignment.Center;
			int num12 = num11 + 12;
			RectangleF layoutRectangle12 = new RectangleF();
			layoutRectangle12 = new RectangleF(5f, (float)num12, 740f, 20f);
			g.DrawRectangle(pen2, (int)layoutRectangle12.X, (int)layoutRectangle12.Y, (int)layoutRectangle12.Width, (int)layoutRectangle12.Height);
			g.DrawString("Continuous & Non-Continuous Monitoring Tests", font1, brush1, layoutRectangle12, format);
			int num13 = font1.Height + num12 + 10;
			RectangleF layoutRectangle13 = new RectangleF();
			float y4 = (float)num13;
			layoutRectangle13 = new RectangleF(5f, y4, 183f, (float)font3.Height);
			RectangleF layoutRectangle14 = new RectangleF();
			layoutRectangle14 = new RectangleF(layoutRectangle13.Right, y4, 91f, (float)font3.Height);
			RectangleF layoutRectangle15 = new RectangleF();
			layoutRectangle15 = new RectangleF(layoutRectangle14.Right, y4, 91f, (float)font3.Height);
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("Continuous Monitors", font4, brush4, layoutRectangle13, format);
			g.DrawString("Supported?", font4, brush4, layoutRectangle14, format);
			g.DrawString("Completed?", font4, brush4, layoutRectangle15, format);
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.DrawString("Misfire", font3, brush4, layoutRectangle13);
			if (MisfireMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (MisfireMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("Fuel System", font3, brush4, layoutRectangle13);
			if (FuelSystemMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (FuelSystemMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.DrawString("Comprehensive Component", font3, brush4, layoutRectangle13);
			if (ComprehensiveMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (ComprehensiveMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.X = layoutRectangle15.Right + 7f;
			layoutRectangle13.Y = y4;
			layoutRectangle14.X = layoutRectangle13.Right;
			layoutRectangle14.Y = y4;
			layoutRectangle15.X = layoutRectangle14.Right;
			layoutRectangle15.Y = y4;
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("Non-Continuous Monitors", font4, brush4, layoutRectangle13, format);
			g.DrawString("Supported?", font4, brush4, layoutRectangle14, format);
			g.DrawString("Completed?", font4, brush4, layoutRectangle15, format);
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.DrawString("Catalyst", font3, brush4, layoutRectangle13);
			if (CatalystMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (CatalystMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("Heated Catalyst", font3, brush4, layoutRectangle13);
			if (HeatedCatalystMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (HeatedCatalystMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.DrawString("Evaporative System", font3, brush4, layoutRectangle13);
			if (EvapSystemMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (EvapSystemMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("Secondary Air System", font3, brush4, layoutRectangle13);
			if (SecondaryAirMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (SecondaryAirMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.DrawString("A/C System Refrigerant", font3, brush4, layoutRectangle13);
			if (RefrigerantMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (RefrigerantMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("Oxygen Sensor", font3, brush4, layoutRectangle13);
			if (OxygenSensorMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (OxygenSensorMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.DrawString("Oxygen Sensor Heater", font3, brush4, layoutRectangle13);
			if (OxygenSensorHeaterMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (OxygenSensorHeaterMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			layoutRectangle13.Y = (float)font3.Height + layoutRectangle13.Y;
			layoutRectangle14.Y = (float)font3.Height + layoutRectangle14.Y;
			layoutRectangle15.Y = (float)font3.Height + layoutRectangle15.Y;
			g.FillRectangle(brush5, (int)layoutRectangle13.X, (int)layoutRectangle13.Y, (int)layoutRectangle13.Width, (int)layoutRectangle13.Height);
			g.FillRectangle(brush5, (int)layoutRectangle14.X, (int)layoutRectangle14.Y, (int)layoutRectangle14.Width, (int)layoutRectangle14.Height);
			g.FillRectangle(brush5, (int)layoutRectangle15.X, (int)layoutRectangle15.Y, (int)layoutRectangle15.Width, (int)layoutRectangle15.Height);
			g.DrawString("EGR System", font3, brush4, layoutRectangle13);
			if (EGRSystemMonitorSupported)
			{
				g.DrawString("Supported", font3, brush2, layoutRectangle14, format);
				if (EGRSystemMonitorCompleted)
					g.DrawString("Complete", font3, brush2, layoutRectangle15, format);
				else
					g.DrawString("Incomplete", font3, brush3, layoutRectangle15, format);
			}
			else
			{
				g.DrawString("Unsupported", font3, brush4, layoutRectangle14, format);
				g.DrawString("-", font3, brush4, layoutRectangle15, format);
			}
			int num14 = (int)((double)layoutRectangle13.Bottom + 5.0);
			g.DrawLine(pen2, 5, num14, 745, num14);
			g.DrawLine(pen2, 5, num14 + 2, 745, num14 + 2);
			if (num14 < 900)
			{
				RectangleF rectangleF = new RectangleF();
				rectangleF = new RectangleF(5f, (float)(num14 + 12), 740f, 20f);
				g.DrawRectangle(pen2, (int)rectangleF.X, (int)rectangleF.Y, (int)rectangleF.Width, (int)rectangleF.Height);
				g.DrawString("Notes", font1, brush1, rectangleF, format);
				rectangleF.Y = rectangleF.Bottom;
				rectangleF.Height = (float)(1000.0 - (double)rectangleF.Y - 5.0);
				g.FillRectangle(brush5, rectangleF);
				g.DrawRectangle(pen2, (int)rectangleF.X, (int)rectangleF.Y, (int)rectangleF.Width, (int)rectangleF.Height);
			}
			g.DrawRectangle(pen3, 0, 0, 749, 999);
		}

		public Image getImage()
		{
			Bitmap bitmap = new Bitmap(Width, Height);
			PaintControl(Graphics.FromImage((Image)bitmap));
			return bitmap as Image;
		}
	}
}