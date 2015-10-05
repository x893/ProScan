using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ProScan
{
	public class OBDCommLog
	{
		private string m_strLogFile;
		private bool m_bLogToFile;
		private List<OBDCommLogItem> m_arrItems = new List<OBDCommLogItem>();

		public OBDCommLog()
		{
			SetLogFile("commlog.txt");
			SetLogFileStatus(false);
		}

		public void AddItem(DateTime dt, string strItem)
		{
			OBDCommLogItem item = new OBDCommLogItem(dt, strItem);
			m_arrItems.Add(item);
			if (!m_bLogToFile)
				return;
			StreamWriter streamWriter = File.AppendText(m_strLogFile);
			streamWriter.WriteLine(item.ToString());
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
}
