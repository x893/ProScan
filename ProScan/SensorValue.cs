using System;

[Serializable]
public class SensorValue
{
	private double m_dEnglishValue;
	private string m_strEnglishDisplay;
	private double m_dMetricValue;
	private string m_strMetricDisplay;

	public SensorValue() { }

	public string MetricDisplay
	{
		get { return m_strMetricDisplay; }
		set { m_strMetricDisplay = value; }
	}

	public double MetricValue
	{
		get { return m_dMetricValue; }
		set { m_dMetricValue = value; }
	}

	public string EnglishDisplay
	{
		get { return m_strEnglishDisplay; }
		set { m_strEnglishDisplay = value; }
	}

	public double EnglishValue
	{
		get { return m_dEnglishValue; }
		set { m_dEnglishValue = value; }
	}

	public SensorValue(double dEnglishValue, string strEnglishDisplay, double dMetricValue, string strMetricDisplay)
	{
		m_dEnglishValue = dEnglishValue;
		m_strEnglishDisplay = strEnglishDisplay;
		m_dMetricValue = dMetricValue;
		m_strMetricDisplay = strMetricDisplay;
	}
}
