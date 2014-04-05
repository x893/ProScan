using System;

[Serializable]
public class Timeslip
{
	private DateTime m_dtDate;
	private string m_strVehicle;
	private double m_dSixtyFootTime;
	private double m_dSixtyMphTime;
	private double m_dEighthMileTime;
	private double m_dEighthMileSpeed;
	private double m_dThousandFootTime;
	private double m_dQuarterMileTime;
	private double m_dQuarterMileSpeed;

	public double QuarterMileSpeed
	{
		get { return m_dQuarterMileSpeed; }
		set { m_dQuarterMileSpeed = value; }
	}

	public double QuarterMileTime
	{
		get { return m_dQuarterMileTime; }
		set { m_dQuarterMileTime = value; }
	}

	public double ThousandFootTime
	{
		get { return m_dThousandFootTime; }
		set { m_dThousandFootTime = value; }
	}

	public double EighthMileSpeed
	{
		get { return m_dEighthMileSpeed; }
		set { m_dEighthMileSpeed = value; }
	}

	public double EighthMileTime
	{
		get { return m_dEighthMileTime; }
		set { m_dEighthMileTime = value; }
	}

	public double SixtyMphTime
	{
		get { return m_dSixtyMphTime; }
		set { m_dSixtyMphTime = value; }
	}

	public double SixtyFootTime
	{
		get { return m_dSixtyFootTime; }
		set { m_dSixtyFootTime = value; }
	}

	public string Vehicle
	{
		get { return m_strVehicle; }
		set { m_strVehicle = value; }
	}

	public DateTime Date
	{
		get { return m_dtDate; }
		set { m_dtDate = value; }
	}

	public Timeslip(DateTime dtDate, string strVehicle, double dSixtyFootTime, double dSixtyMphTime, double dEighthMileTime, double dEighthMileSpeed, double dThousandFootTime, double dQuarterMileTime, double dQuarterMileSpeed)
	{
		m_dtDate = dtDate;
		m_strVehicle = strVehicle;
		m_dSixtyFootTime = dSixtyFootTime;
		m_dSixtyMphTime = dSixtyMphTime;
		m_dEighthMileTime = dEighthMileTime;
		m_dEighthMileSpeed = dEighthMileSpeed;
		m_dThousandFootTime = dThousandFootTime;
		m_dQuarterMileTime = dQuarterMileTime;
		m_dQuarterMileSpeed = dQuarterMileSpeed;
	}

	public Timeslip()
	{
		m_dtDate = DateTime.Now;
	}

	public string getStats()
	{
		return "60' Time ......." + (" " + m_dSixtyFootTime.ToString("000.000")).PadLeft(25, '.') + " sec\r\n" + "0 to 60 MPH ...." + (" " + m_dSixtyMphTime.ToString("000.000")).PadLeft(25, '.') + " sec\r\n" + "1/8 Mile ET ...." + (" " + m_dEighthMileTime.ToString("000.000")).PadLeft(25, '.') + " sec\r\n" + "1/8 Mile Speed ." + (" " + m_dEighthMileSpeed.ToString("000.000")).PadLeft(25, '.') + " mph\r\n" + "1000' Time ....." + (" " + m_dThousandFootTime.ToString("000.000")).PadLeft(25, '.') + " sec\r\n" + "1/4 Mile ET ...." + (" " + m_dQuarterMileTime.ToString("000.000")).PadLeft(25, '.') + " sec\r\n" + "1/4 Mile Speed ." + (" " + m_dQuarterMileSpeed.ToString("000.000")).PadLeft(25, '.') + " mph";
	}
}