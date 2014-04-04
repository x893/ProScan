using System;

public class OBDParameter
{
	private string m_strPID = "";
	private string m_strName = "";
	private string m_strEnglishUnit = "";
	private string m_strMetricUnit = "";

	private int m_iService;
	private int m_iParameter;
	private int m_iSubParameter;
	private string m_strOBDRequest;
	private int m_iValueType;
	private int m_iCategory;
	private int m_iType;
	private int m_iManufacturer;
	private int m_iPriority;
	private double m_dMinValueEnglish;
	private double m_dMaxValueEnglish;
	private double m_dMinValueMetric;
	private double m_dMaxValueMetric;

	public OBDParameter(int iService, int iParameter, int iSubParameter, int iFrame)
	{
		OBDRequest = OBD2.Int2HexString(iService) + OBD2.Int2HexString(iParameter) + OBD2.Int2HexString(iFrame);
		Service = iService;
		Parameter = iParameter;
		SubParameter = iSubParameter;
	}

	public OBDParameter(int iService, int iParameter, int iSubParameter)
	{
		OBDRequest = OBD2.Int2HexString(iService) + OBD2.Int2HexString(iParameter);
		Service = iService;
		Parameter = iParameter;
		SubParameter = iSubParameter;
	}

	public OBDParameter()
	{
		m_strOBDRequest = "";
	}

	public int SubParameter
	{
		get { return m_iSubParameter; }
		set { m_iSubParameter = value; }
	}

	public int Parameter
	{
		get { return m_iParameter; }
		set { m_iParameter = value; }
	}

	public int Service
	{
		get { return m_iService; }
		set { m_iService = value; }
	}

	public double MetricMaxValue
	{
		get { return m_dMaxValueMetric; }
		set { m_dMaxValueMetric = value; }
	}

	public double MetricMinValue
	{
		get { return m_dMinValueMetric; }
		set { m_dMinValueMetric = value; }
	}

	public double EnglishMaxValue
	{
		get { return m_dMaxValueEnglish; }
		set { m_dMaxValueEnglish = value; }
	}

	public double EnglishMinValue
	{
		get { return m_dMinValueEnglish; }
		set { m_dMinValueEnglish = value; }
	}

	public int ValueTypes
	{
		get { return m_iValueType; }
		set { m_iValueType = value; }
	}

	public int Priority
	{
		get { return m_iPriority; }
		set { m_iPriority = value; }
	}

	public int Manufacturer
	{
		get { return m_iManufacturer; }
		set { m_iManufacturer = value; }
	}

	public int Type
	{
		get { return m_iType; }
		set { m_iType = value; }
	}

	public int Category
	{
		get { return m_iCategory; }
		set { m_iCategory = value; }
	}

	public string MetricUnitLabel
	{
		get { return m_strMetricUnit; }
		set { m_strMetricUnit = value; }
	}

	public string EnglishUnitLabel
	{
		get { return m_strEnglishUnit; }
		set { m_strEnglishUnit = value; }
	}

	public string Name
	{
		get { return m_strName; }
		set { m_strName = value; }
	}

	public string PID
	{
		get { return m_strPID; }
		set { m_strPID = value; }
	}

	public string OBDRequest
	{
		get { return m_strOBDRequest; }
		set { m_strOBDRequest = value; }
	}

	public OBDParameter GetCopy()
	{
		return new OBDParameter()
		{
			Category = Category,
			ValueTypes = ValueTypes,
			EnglishMaxValue = EnglishMaxValue,
			EnglishMinValue = EnglishMinValue,
			EnglishUnitLabel = EnglishUnitLabel,
			Manufacturer = Manufacturer,
			MetricMaxValue = MetricMaxValue,
			MetricMinValue = MetricMinValue,
			MetricUnitLabel = MetricUnitLabel,
			Name = Name,
			OBDRequest = OBDRequest,
			Parameter = Parameter,
			PID = PID,
			Priority = Priority,
			Service = Service,
			SubParameter = SubParameter,
			Type = Type
		};
	}

	public OBDParameter GetFreezeFrameCopy(int iFrame)
	{
		OBDParameter copy = GetCopy();
		copy.Service = 2;
		copy.OBDRequest = "02" + copy.OBDRequest.Substring(2, 2) + iFrame.ToString("D2");
		return copy;
	}

	public override string ToString()
	{
		return Name;
	}
}
