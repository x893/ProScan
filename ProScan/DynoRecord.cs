using System;
using System.Collections;

[Serializable]
public class DynoRecord
{
	private string m_strLabel;
	private double m_dWeight;
	private double m_dDriveRatio;
	private ArrayList m_arrRpmValues;

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

	public ArrayList RpmList
	{
		get { return m_arrRpmValues; }
		set { m_arrRpmValues = value; }
	}
}
