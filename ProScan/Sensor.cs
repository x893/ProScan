using System.Runtime.InteropServices;

public class Sensor
{
	private string m_strName;
	private int m_iService;
	private int m_iPID;
	private int m_iSubPID;
	private bool m_bIsSensor;
	private bool m_bIsPlottable;
	private bool m_bIsO2Dependant;
	private bool m_bIsFor1D;
	private double m_dEnglishValue;
	private double m_dEnglishMinValue;
	private double m_dEnglishMaxValue;
	private double m_dMetricValue;
	private double m_dMetricMinValue;
	private double m_dMetricMaxValue;

	private string m_strEnglishDisplay = "";
	private string m_strEnglishUnits = "";
	private string m_strMetricDisplay = "";
	private string m_strMetricUnits = "";

	public Sensor()
	{
	}

	public Sensor(int iService, int iPID, int iSubPID, string strName, double dEnglishMinValue, double dEnglishMaxValue, string strEnglishUnits, double dMetricMinValue, double dMetricMaxValue, string strMetricUnits, bool bIsSensor, bool bIsPlottable, bool bIsO2Dependant, bool bIsFor1D)
	{
		m_iService = iService;
		m_iPID = iPID;
		m_iSubPID = iSubPID;
		m_strName = strName;
		m_dEnglishMinValue = dEnglishMinValue;
		m_dEnglishMaxValue = dEnglishMaxValue;
		m_strEnglishUnits = strEnglishUnits;
		m_dMetricMinValue = dMetricMinValue;
		m_dMetricMaxValue = dMetricMaxValue;
		m_strMetricUnits = strMetricUnits;
		m_bIsSensor = bIsSensor;
		m_bIsPlottable = bIsPlottable;
		m_bIsO2Dependant = bIsO2Dependant;
		m_bIsFor1D = bIsFor1D;
	}

	public double MetricMaxValue
	{
		get { return m_dMetricMaxValue; }
		set { m_dMetricMaxValue = value; }
	}

	public double MetricMinValue
	{
		get { return m_dMetricMinValue; }
		set { m_dMetricMinValue = value; }
	}

	public string MetricUnits
	{
		get { return m_strMetricUnits; }
		set { m_strMetricUnits = value; }
	}

	public double MetricValue
	{
		get { return m_dMetricValue; }
		set { m_dMetricValue = value; }
	}

	public string MetricDisplay
	{
		get { return m_strMetricDisplay; }
		set { m_strMetricDisplay = value; }
	}

	public double EnglishMaxValue
	{
		get { return m_dEnglishMaxValue; }
		set { m_dEnglishMaxValue = value; }
	}

	public double EnglishMinValue
	{
		get { return m_dEnglishMinValue; }
		set { m_dEnglishMinValue = value; }
	}

	public string EnglishUnits
	{
		get { return m_strEnglishUnits; }
		set { m_strEnglishUnits = value; }
	}

	public double EnglishValue
	{
		get { return m_dEnglishValue; }
		set { m_dEnglishValue = value; }
	}

	public string EnglishDisplay
	{
		get { return m_strEnglishDisplay; }
		set { m_strEnglishDisplay = value; }
	}

	public bool isFor1D
	{
		get { return m_bIsFor1D; }
		set { m_bIsFor1D = value; }
	}

	public bool isO2Dependant
	{
		get { return m_bIsO2Dependant; }
		set { m_bIsO2Dependant = value; }
	}

	public bool isPlottable
	{
		get { return m_bIsPlottable; }
		set { m_bIsPlottable = value; }
	}

	public bool isSensor
	{
		get { return m_bIsSensor; }
		set { m_bIsSensor = value; }
	}

	public int SubPID
	{
		get { return m_iSubPID; }
		set { m_iSubPID = value; }
	}

	public int PID
	{
		get { return m_iPID; }
		set { m_iPID = value; }
	}

	public int Service
	{
		get { return m_iService; }
		set { m_iService = value; }
	}

	public string Name
	{
		get { return m_strName; }
		set { m_strName = value; }
	}

	public override string ToString()
	{
		return m_strName;
	}
}