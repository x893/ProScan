using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

public class OBDParameterValue
{
	private bool m_bErrorDetected;
	private string m_strValue = "";
	private string m_strShortValue = "";
	private double m_dValue;
	private bool m_bValue;
	private StringCollection m_colStrings;
	private ArrayList m_listValues = new ArrayList();
	private bool[] m_bBitFlags = new bool[32];

	public OBDParameterValue(bool bValue, double dValue, string strValue, string shortValue)
	{
		m_bValue = bValue;
		m_dValue = dValue;
		m_strValue = strValue;
		m_strShortValue = shortValue;
		m_listValues = new ArrayList();
	}

	public OBDParameterValue()
	{
	}

	public bool ErrorDetected
	{
		get { return m_bErrorDetected; }
		set { m_bErrorDetected = value; }
	}

	public ArrayList ArrayListValue
	{
		get { return m_listValues; }
		set { m_listValues = value; }
	}

	public StringCollection StringCollectionValue
	{
		get { return m_colStrings; }
		set { m_colStrings = value; }
	}

	public bool BoolValue
	{
		get { return m_bValue; }
		set { m_bValue = value; }
	}

	public double DoubleValue
	{
		get { return m_dValue; }
		set { m_dValue = value; }
	}

	public string ShortStringValue
	{
		get { return m_strShortValue; }
		set { m_strShortValue = value; }
	}

	public string StringValue
	{
		get { return m_strValue; }
		set { m_strValue = value; }
	}

	public bool getBitFlag(int index)
	{
		return m_bBitFlags[index];
	}

	public void setBitFlag(int index, bool status)
	{
		m_bBitFlags[index] = status;
	}
}
