using System;
using System.Collections;
using System.IO;

[Serializable]
public class CommLog
{
	private ArrayList m_arrList;
	private StreamWriter m_streamWriter;
	private bool m_bCommLogging;

	public CommLog()
	{
		m_arrList = new ArrayList();
		if (File.Exists("commlog.txt"))
			File.Delete("commlog.txt");
		m_bCommLogging = false;
	}

	public bool CommLogging
	{
		get { return m_bCommLogging; }
		set { m_bCommLogging = value; }
	}

	public int EventCount
	{
		get { return m_arrList.Count; }
	}

	public void Add(EventType eventType, string strData)
	{
		CommLogEvent commLogEvent = new CommLogEvent(DateTime.Now, eventType, strData);
		m_arrList.Add((object)commLogEvent);
		if (m_arrList.Count > 100)
			m_arrList.RemoveAt(0);
		if (!m_bCommLogging)
			return;
		m_streamWriter = File.AppendText("commlog.txt");
		m_streamWriter.WriteLine(commLogEvent.ToString());
		m_streamWriter.Close();
	}

	public CommLogEvent get_Event(int index)
	{
		return (CommLogEvent)m_arrList[index];
	}

	public string Text
	{
		get
		{
			string str = "";
			int index = 0;
			if (m_arrList.Count > 0)
				do
				{
					str = str + (m_arrList[index] as CommLogEvent).ToString() + "\r\n";
					++index;
				}
				while (index < m_arrList.Count);
			return str;
		}
	}
}