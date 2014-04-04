using System;
using System.Globalization;

public class OBDCommLogItem
{
	private DateTime m_dtTime;
	private string m_strMsg;

	public string Message
	{
		get { return m_strMsg; }
		set { m_strMsg = value; }
	}

	public DateTime Timestamp
	{
		get { return m_dtTime; }
		set { m_dtTime = value; }
	}

	public OBDCommLogItem(DateTime dt, string strMsg)
	{
		m_dtTime = dt;
		m_strMsg = strMsg;
	}

	public OBDCommLogItem(string strMsg)
	{
		m_dtTime = DateTime.Now;
		m_strMsg = strMsg;
	}

	public OBDCommLogItem()
	{
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}", m_dtTime.ToString("MM-dd-yyyy hh:mm:ss.fff", DateTimeFormatInfo.InvariantInfo), m_strMsg);
	}
}