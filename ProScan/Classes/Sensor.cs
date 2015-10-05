using System.Runtime.InteropServices;

namespace ProScan
{
	public class Sensor
	{
		private string m_Name;
		private int m_Service;
		private int m_PID;
		private int m_SubPID;
		private bool m_IsSensor;
		private bool m_IsPlottable;
		private bool m_IsO2Dependant;
		private bool m_IsFor1D;
		private double m_EnglishValue;
		private double m_EnglishMinValue;
		private double m_EnglishMaxValue;
		private double m_MetricValue;
		private double m_MetricMinValue;
		private double m_MetricMaxValue;

		private string m_EnglishDisplay = "";
		private string m_EnglishUnits = "";
		private string m_MetricDisplay = "";
		private string m_MetricUnits = "";

		public Sensor()
		{
		}

		public Sensor(int iService, int iPID, int iSubPID, string strName, double dEnglishMinValue, double dEnglishMaxValue, string strEnglishUnits, double dMetricMinValue, double dMetricMaxValue, string strMetricUnits, bool bIsSensor, bool bIsPlottable, bool bIsO2Dependant, bool bIsFor1D)
		{
			m_Service = iService;
			m_PID = iPID;
			m_SubPID = iSubPID;
			m_Name = strName;
			m_EnglishMinValue = dEnglishMinValue;
			m_EnglishMaxValue = dEnglishMaxValue;
			m_EnglishUnits = strEnglishUnits;
			m_MetricMinValue = dMetricMinValue;
			m_MetricMaxValue = dMetricMaxValue;
			m_MetricUnits = strMetricUnits;
			m_IsSensor = bIsSensor;
			m_IsPlottable = bIsPlottable;
			m_IsO2Dependant = bIsO2Dependant;
			m_IsFor1D = bIsFor1D;
		}

		public double MetricMaxValue
		{
			get { return m_MetricMaxValue; }
			set { m_MetricMaxValue = value; }
		}

		public double MetricMinValue
		{
			get { return m_MetricMinValue; }
			set { m_MetricMinValue = value; }
		}

		public string MetricUnits
		{
			get { return m_MetricUnits; }
			set { m_MetricUnits = value; }
		}

		public double MetricValue
		{
			get { return m_MetricValue; }
			set { m_MetricValue = value; }
		}

		public string MetricDisplay
		{
			get { return m_MetricDisplay; }
			set { m_MetricDisplay = value; }
		}

		public double EnglishMaxValue
		{
			get { return m_EnglishMaxValue; }
			set { m_EnglishMaxValue = value; }
		}

		public double EnglishMinValue
		{
			get { return m_EnglishMinValue; }
			set { m_EnglishMinValue = value; }
		}

		public string EnglishUnits
		{
			get { return m_EnglishUnits; }
			set { m_EnglishUnits = value; }
		}

		public double EnglishValue
		{
			get { return m_EnglishValue; }
			set { m_EnglishValue = value; }
		}

		public string EnglishDisplay
		{
			get { return m_EnglishDisplay; }
			set { m_EnglishDisplay = value; }
		}

		public bool isFor1D
		{
			get { return m_IsFor1D; }
			set { m_IsFor1D = value; }
		}

		public bool isO2Dependant
		{
			get { return m_IsO2Dependant; }
			set { m_IsO2Dependant = value; }
		}

		public bool isPlottable
		{
			get { return m_IsPlottable; }
			set { m_IsPlottable = value; }
		}

		public bool isSensor
		{
			get { return m_IsSensor; }
			set { m_IsSensor = value; }
		}

		public int SubPID
		{
			get { return m_SubPID; }
			set { m_SubPID = value; }
		}

		public int PID
		{
			get { return m_PID; }
			set { m_PID = value; }
		}

		public int Service
		{
			get { return m_Service; }
			set { m_Service = value; }
		}

		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public override string ToString()
		{
			return m_Name;
		}
	}
}