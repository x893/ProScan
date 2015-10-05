using System;

namespace ProScan
{
	public class OBDResponse
	{
		private bool m_IsValid;
		private string m_Header;
		private string m_Data;
		private DateTime m_Time;

		public OBDResponse()
		{
			m_Data = "";
		}

		public DateTime Timestamp
		{
			get { return m_Time; }
			set { m_Time = value; }
		}

		public string Data
		{
			get { return m_Data; }
			set { m_Data = value; }
		}

		public string Header
		{
			get { return m_Header; }
			set { m_Header = value; }
		}

		public bool IsValid
		{
			get { return m_IsValid; }
			set { m_IsValid = value; }
		}

		public string getDataByte(int index)
		{
			index *= 2;
			if (index + 2 > m_Data.Length)
				return "";
			return m_Data.Substring(index, 2);
		}

		public int getDataByteCount()
		{
			return m_Data.Length / 2;
		}
	}
}
