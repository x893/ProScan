using System;
using System.Collections;

public class OBDResponseList
{
	private bool m_bErrorDetected;
	private ArrayList m_listResponses;
	private string m_strResponseRaw;

	public bool ErrorDetected
	{
		get
		{
			return m_bErrorDetected;
		}
		set
		{
			m_bErrorDetected = value;
		}
	}

	public string RawResponse
	{
		get
		{
			return m_strResponseRaw;
		}
		set
		{
			m_strResponseRaw = value;
		}
	}

	public int ResponseCount
	{
		get
		{
			return m_listResponses.Count;
		}
	}

	public OBDResponseList(string response)
	{
		m_strResponseRaw = response;
		m_bErrorDetected = false;
		m_listResponses = new ArrayList();
	}

	~OBDResponseList()
	{
	}

	public void AddOBDResponse(OBDResponse response)
	{
		m_listResponses.Add((object)response);
	}

	public OBDResponse GetOBDResponse(int index)
	{
		if (index < m_listResponses.Count)
			return (OBDResponse)m_listResponses[index];
		else
			return (OBDResponse)null;
	}

	public void __dtor()
	{
		GC.SuppressFinalize((object)this);
	}
}
