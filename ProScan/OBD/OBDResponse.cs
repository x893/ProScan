using System;

public class OBDResponse
{
	private bool m_bIsValid;
	private string m_strHeader;
	private string m_strData;
	private DateTime m_dtTime;

	public DateTime Timestamp
	{
		get
		{
			return m_dtTime;
		}
		set
		{
			m_dtTime = value;
		}
	}

	public string Data
	{
		get
		{
			return m_strData;
		}
		set
		{
			m_strData = value;
		}
	}

	public string Header
	{
		get
		{
			return m_strHeader;
		}
		set
		{
			m_strHeader = value;
		}
	}

	public bool IsValid
	{
		get
		{
			return m_bIsValid;
		}
		set
		{
			m_bIsValid = value;
		}
	}

	public OBDResponse()
	{
		m_strData = "";
	}

	~OBDResponse()
	{
	}

	public string getDataByte(int index)
	{
		int startIndex = index * 2;
		if (startIndex + 2 > m_strData.Length)
			return "";
		else
			return m_strData.Substring(startIndex, 2);
	}

	public int getDataByteCount()
	{
		return m_strData.Length / 2;
	}

	public void __dtor()
	{
		GC.SuppressFinalize((object)this);
	}
}
