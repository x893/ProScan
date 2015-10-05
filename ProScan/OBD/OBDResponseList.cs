using System;
using System.Collections;
using System.Collections.Generic;

namespace ProScan
{
	public class OBDResponseList
	{
		private bool m_ErrorDetected;
		private List<OBDResponse> m_Responses;
		private string m_ResponseRaw;

		public bool ErrorDetected
		{
			get { return m_ErrorDetected; }
			set { m_ErrorDetected = value; }
		}

		public string RawResponse
		{
			get { return m_ResponseRaw; }
			set { m_ResponseRaw = value; }
		}

		public int ResponseCount
		{
			get { return m_Responses.Count; }
		}

		public OBDResponseList(string response)
		{
			m_ResponseRaw = response;
			m_ErrorDetected = false;
			m_Responses = new List<OBDResponse>();
		}

		public void AddOBDResponse(OBDResponse response)
		{
			m_Responses.Add(response);
		}

		public OBDResponse GetOBDResponse(int index)
		{
			if (index < m_Responses.Count)
				return m_Responses[index];
			return null;
		}
	}
}
