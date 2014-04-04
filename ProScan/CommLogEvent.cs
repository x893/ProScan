using System;
using System.Globalization;

[Serializable]
public class CommLogEvent
{
	private DateTime m_dtDate;
	private EventType m_eventType;
	private string m_strData;

	public CommLogEvent(DateTime dtDate, EventType eventType, string strData)
	{
		m_dtDate = dtDate;
		m_eventType = eventType;
		m_strData = strData;
	}

	public string Data
	{
		get { return m_strData; }
	}

	public EventType Type
	{
		get { return m_eventType; }
	}

	public DateTime Date
	{
		get { return m_dtDate; }
	}

	public override string ToString()
	{
		string str = m_strData.Replace("\r", " ");
		return string.Format("{0}\t{1}", m_dtDate.ToString("MM-dd-yyyy hh:mm:ss.fff", DateTimeFormatInfo.InvariantInfo), str);
	}
}
