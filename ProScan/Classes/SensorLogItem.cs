using System;

[Serializable]
public class SensorLogItem
{
	private string m_strName;
	private string m_strEnglishDisplay;
	private string m_strEnglishUnits;
	private string m_strMetricDisplay;
	private string m_strMetricUnits;
	private DateTime m_dtTime = DateTime.Now;

	public DateTime Time
	{
		get { return m_dtTime; }
	}

	public string MetricUnits
	{
		get { return m_strMetricUnits; }
	}

	public string MetricDisplay
	{
		get { return m_strMetricDisplay; }
	}

	public string EnglishUnits
	{
		get { return m_strEnglishUnits; }
	}

	public string EnglishDisplay
	{
		get { return m_strEnglishDisplay; }
	}

	public string Name
	{
		get { return m_strName; }
	}

	public SensorLogItem(string strName, string strEnglishDisplay, string strEnglishUnits, string strMetricDisplay, string strMetricUnits)
	{
		m_strName = strName;
		m_strEnglishDisplay = strEnglishDisplay;
		m_strEnglishUnits = strEnglishUnits;
		m_strMetricDisplay = strMetricDisplay;
		m_strMetricUnits = strMetricUnits;
	}
}