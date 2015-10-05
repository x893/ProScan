using System;

namespace ProScan
{
	[Serializable]
	public class TestStatus
	{
		private string m_strName;
		private string m_strStatus;
		private int m_iSupportID;
		private int m_iStatusID;

		public TestStatus()
		{
		}
		public TestStatus(string strName, string strStatus, int iSupportID, int iStatusID)
		{
			m_strName = strName;
			m_strStatus = strStatus;
			m_iSupportID = iSupportID;
			m_iStatusID = iStatusID;
		}

		public int StatusID
		{
			get { return m_iStatusID; }
			set { m_iStatusID = value; }
		}

		public int SupportID
		{
			get { return m_iSupportID; }
			set { m_iSupportID = value; }
		}

		public string Status
		{
			get { return m_strStatus; }
			set { m_strStatus = value; }
		}

		public string Name
		{
			get { return m_strName; }
			set { m_strName = value; }
		}
	}
}
