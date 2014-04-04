using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

public class OBDCommLog
{
	private string m_strLogFile;
	private bool m_bLogToFile;
	private ArrayList m_arrItems = new ArrayList();

	public OBDCommLog()
	{
		SetLogFile("commlog.txt");
		SetLogFileStatus(false);
	}

	public void AddItem(DateTime dt, string strItem)
	{
		OBDCommLogItem obdCommLogItem = new OBDCommLogItem(dt, strItem);
		m_arrItems.Add((object)obdCommLogItem);
		if (!m_bLogToFile)
			return;
		StreamWriter streamWriter = File.AppendText(m_strLogFile);
		streamWriter.WriteLine(obdCommLogItem.ToString());
		streamWriter.Close();
	}

	public void AddItem(string strItem)
	{
		AddItem(DateTime.Now, strItem);
	}

	public void SetLogFile(string strFile)
	{
		m_strLogFile = strFile;
	}

	public void SetLogFileStatus(bool status)
	{
		m_bLogToFile = status;
	}

	public void Delete()
	{
		File.Delete(m_strLogFile);
	}
}
