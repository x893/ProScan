using System;
using System.Collections;
using System.Collections.Generic;

namespace ProScan
{
	[Serializable]
	public class DynoRecord
	{
		private string m_strLabel;
		private double m_dWeight;
		private double m_dDriveRatio;
		private List<DatedValue> m_RpmValues;

		public double Weight
		{
			get { return m_dWeight; }
			set { m_dWeight = value; }
		}

		public string Label
		{
			get { return m_strLabel; }
			set { m_strLabel = value; }
		}

		public double DriveRatio
		{
			get { return m_dDriveRatio; }
			set { m_dDriveRatio = value; }
		}

		public List<DatedValue> RpmList
		{
			get { return m_RpmValues; }
			set { m_RpmValues = value; }
		}
	}
}