using System;

namespace ProScan
{
	[Serializable]
	public class SensorLogItem
	{
		private string m_Name;
		private string m_EnglishDisplay;
		private string m_EnglishUnits;
		private string m_MetricDisplay;
		private string m_MetricUnits;
		private DateTime m_dtTime = DateTime.Now;

		public DateTime Time
		{
			get { return m_dtTime; }
		}

		public string MetricUnits
		{
			get { return m_MetricUnits; }
		}

		public string MetricDisplay
		{
			get { return m_MetricDisplay; }
		}

		public string EnglishUnits
		{
			get { return m_EnglishUnits; }
		}

		public string EnglishDisplay
		{
			get { return m_EnglishDisplay; }
		}

		public string Name
		{
			get { return m_Name; }
		}

		public SensorLogItem(string strName, string strEnglishDisplay, string strEnglishUnits, string strMetricDisplay, string strMetricUnits)
		{
			m_Name = strName;
			m_EnglishDisplay = strEnglishDisplay;
			m_EnglishUnits = strEnglishUnits;
			m_MetricDisplay = strMetricDisplay;
			m_MetricUnits = strMetricUnits;
		}
	}
}
