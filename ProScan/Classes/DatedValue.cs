using System;

namespace ProScan
{
	[Serializable]
	public class DatedValue
	{
		private double m_dValue;
		private DateTime m_dtDate;

		public DatedValue()
		{
		}

		public DateTime Date
		{
			get { return m_dtDate; }
			set { m_dtDate = value; }
		}

		public double Value
		{
			get { return m_dValue; }
			set { m_dValue = value; }
		}

		public DatedValue(double dValue)
		{
			m_dValue = dValue;
			m_dtDate = DateTime.Now;
		}
	}
}
