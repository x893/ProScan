using System;
using System.Collections;
using System.Diagnostics;

public class OBD2Response
{
	public enum ResponseTypes
	{
		Error,
		OK,
		NoData,
		ChipInfo,
		HexData,
	}

	private ArrayList listECUResponses;
	private ArrayList listData;
	private ArrayList listDTC;
	private string strResponse;
	private string strData;
	private int m_iService;
	private int m_iPID;
	private DateTime dtTime;

	public string DTC3
	{
		get
		{
			return getCode(2);
		}
	}

	public string DTC2
	{
		get
		{
			return getCode(1);
		}
	}

	public string DTC1
	{
		get
		{
			return getCode(0);
		}
	}

	public int DataD
	{
		get
		{
			return getDataByte(3);
		}
	}

	public int DataC
	{
		get
		{
			return getDataByte(2);
		}
	}

	public int DataB
	{
		get
		{
			return getDataByte(1);
		}
	}

	public int DataA
	{
		get
		{
			return getDataByte(0);
		}
	}

	public string Data
	{
		get
		{
			if (listData.Count > 0)
				strData = (string)listData[0];
			return strData;
		}
	}

	public int TotalCodesReturned
	{
		get
		{
			if (listData.Count > 0)
			{
				strData = (string)listData[0];
				int index = 1;
				if (1 < listData.Count)
				{
					do
					{
						strData = strData + listData[index];
						++index;
					}
					while (index < listData.Count);
				}
			}
			return strData.Length / 4;
		}
	}

	public string Request
	{
		get
		{
			if (m_iService == 3)
				return "03";
			if (m_iService == 4)
				return "04";
			if (m_iService == 7)
				return "07";
			else
				return OBD2.Int2HexString(m_iService) + OBD2.Int2HexString(m_iPID);
		}
	}

	public string PID
	{
		get
		{
			if (ResponseType == OBD2Response.ResponseTypes.HexData && m_iPID >= 0)
				return OBD2.Int2HexString(m_iPID);
			else
				return "";
		}
	}

	public string Service
	{
		get
		{
			if (ResponseType == OBD2Response.ResponseTypes.HexData)
				return OBD2.Int2HexString(m_iService);
			else
				return "";
		}
	}

	public DateTime Date
	{
		get
		{
			return dtTime;
		}
	}

	public string Response
	{
		get
		{
			return strResponse;
		}
	}

	public OBD2Response(string strResp, bool bATCommand, bool bUsingHeaders, int iProtocol)
	{
		Debug.WriteLine("OBD2Response()");
		Debug.WriteLine(iProtocol.ToString());
		listECUResponses = new ArrayList();
		listData = new ArrayList();
		listDTC = new ArrayList();
		m_iService = -1;
		m_iPID = -1;
		strData = "";
		strResponse = strResp;
		dtTime = DateTime.Now;
		if (strResponse != null)
		{
			if (strResponse.Length < 1)
				strResponse = "";
		}
		else
			strResponse = "";
		strResponse = strResponse.Trim();
		if (bATCommand)
			return;
		strResponse = strResponse.Replace("BUS", "");
		strResponse = strResponse.Replace("INIT", "");
		strResponse = strResponse.Replace("SEARCHING", "");
		strResponse = strResponse.Replace(":", "");
		strResponse = strResponse.Replace(".", "");
		strResponse = strResponse.Trim();
		if (ResponseType != OBD2Response.ResponseTypes.HexData)
			return;
		if (!bUsingHeaders)
		{
			m_iService = OBD2.HexString2Int(strResponse.Substring(0, 2)) - 64;
			if (m_iService != 3 && m_iService != 4 && m_iService != 7)
				m_iPID = OBD2.HexString2Int(strResponse.Substring(2, 2));
			int startIndex = 4;
			if (m_iService == 3 || m_iService == 4 || m_iService == 7)
				startIndex = 2;
			if (m_iService == 5 || m_iService == 2)
				startIndex = 6;
			strData = strResponse.Substring(startIndex, strResponse.Length - startIndex);
		}
		else
		{
			ArrayList arrayList1 = new ArrayList();
			string str1 = "";
			int startIndex1 = 0;
			if (0 < strResponse.Length)
			{
				do
				{
					if (strResponse.Substring(startIndex1, 1).CompareTo("\r") == 0)
					{
						arrayList1.Add((object)str1);
						str1 = "";
					}
					else
						str1 = str1 + strResponse.Substring(startIndex1, 1);
					++startIndex1;
				}
				while (startIndex1 < strResponse.Length);
			}
			arrayList1.Add((object)str1);
			arrayList1.Sort();
			listECUResponses.Clear();
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(arrayList1[0]);
			listECUResponses.Add((object)arrayList2);
			int addressStartIndex = getECUAddressStartIndex(iProtocol);
			int ecuAddressLength = getECUAddressLength(iProtocol);
			string strB = ((string)arrayList1[0]).Substring(addressStartIndex, ecuAddressLength);
			int index1 = 1;
			if (1 < arrayList1.Count)
			{
				do
				{
					if (((string)arrayList1[index1]).Substring(addressStartIndex, ecuAddressLength).CompareTo(strB) == 0)
					{
						arrayList2.Add(arrayList1[index1]);
					}
					else
					{
						arrayList2 = new ArrayList();
						arrayList2.Add(arrayList1[index1]);
						listECUResponses.Add((object)arrayList2);
						strB = ((string)arrayList1[index1]).Substring(addressStartIndex, ecuAddressLength);
					}
					++index1;
				}
				while (index1 < arrayList1.Count);
			}
			if (iProtocol <= 5)
			{
				if (strResponse.Length >= 8)
					m_iService = OBD2.HexString2Int(strResponse.Substring(6, 2)) - 64;
				if (strResponse.Length >= 10 && m_iService != 3 && (m_iService != 4 && m_iService != 7))
					m_iPID = OBD2.HexString2Int(strResponse.Substring(8, 2));
				listData.Clear();
				int index2 = 0;
				if (0 < listECUResponses.Count)
				{
					do
					{
						ArrayList arrayList3 = (ArrayList)listECUResponses[index2];
						int num1 = 0;
						if (arrayList3.Count > 1)
							num1 = 2;
						string str2 = "";
						int index3 = 0;
						if (0 < arrayList3.Count)
						{
							int num2 = num1 + 10;
							do
							{
								string str3 = (string)arrayList3[index3];
								int startIndex2 = num2;
								if (m_iService == 3 || m_iService == 4 || m_iService == 7)
									startIndex2 = 8;
								if (m_iService == 5 || m_iService == 2)
									startIndex2 = num1 + 12;
								if (str3.Length >= startIndex2 + 4)
									str2 = str2 + str3.Substring(startIndex2, str3.Length + (-2 - startIndex2));
								++index3;
							}
							while (index3 < arrayList3.Count);
						}
						listData.Add((object)str2);
						if ((m_iService == 3 || m_iService == 7) && 4 <= str2.Length)
						{
							int startIndex2 = 0;
							do
							{
								if (str2.Substring(startIndex2, 4).CompareTo("0000") != 0)
									listDTC.Add((object)OBD2.getDTCName(str2.Substring(startIndex2, 4)));
								startIndex2 += 16;
							}
							while (startIndex2 + 4 <= str2.Length);
						}
						++index2;
					}
					while (index2 < listECUResponses.Count);
				}
			}

			Debug.WriteLine("Data:");

			Debug.WriteLine(strData);
			if (iProtocol == 6 || iProtocol == 8)
			{
				listData.Clear();
				int index2 = 0;
				if (0 < listECUResponses.Count)
				{
					do
					{
						ArrayList arrayList3 = (ArrayList)listECUResponses[index2];
						int num = 0;
						if (arrayList3.Count > 1)
							num = 2;
						string message = "";
						int index3 = 0;
						if (0 < arrayList3.Count)
						{
							do
							{
								string str2 = (string)arrayList3[index3];
								int startIndex2;
								if (index3 == 0)
								{
									int startIndex3 = num + 5;
									int startIndex4 = startIndex3 + 2;
									startIndex2 = startIndex4 + 2;
									m_iService = OBD2.HexString2Int(str2.Substring(startIndex3, 2)) - 64;
									if (m_iService != 3 && m_iService != 4 && m_iService != 7)
										m_iPID = OBD2.HexString2Int(str2.Substring(startIndex4, 2));
									else
										startIndex2 -= 2;
									if (m_iService == 3 || m_iService == 7)
										startIndex2 += 2;
									if (m_iService == 5 || m_iService == 2)
										startIndex2 += 2;
								}
								else
									startIndex2 = 5;
								message = message + str2.Substring(startIndex2, str2.Length - startIndex2);
								++index3;
							}
							while (index3 < arrayList3.Count);
						}
						listData.Add((object)message);
						Debug.WriteLine("strData: ");
						Debug.WriteLine(message);
						if ((m_iService == 3 || m_iService == 7) && 4 <= message.Length)
						{
							int startIndex2 = 0;
							do
							{
								if (message.Substring(startIndex2, 4).CompareTo("0000") != 0)
									listDTC.Add((object)OBD2.getDTCName(message.Substring(startIndex2, 4)));
								startIndex2 += 4;
							}
							while (startIndex2 + 4 <= message.Length);
						}
						++index2;
					}
					while (index2 < listECUResponses.Count);
				}
			}
			if (iProtocol == 7 || iProtocol == 9)
			{
				listData.Clear();
				int index2 = 0;
				if (0 < listECUResponses.Count)
				{
					do
					{
						ArrayList arrayList3 = (ArrayList)listECUResponses[index2];
						int num = 0;
						if (arrayList3.Count > 1)
							num = 2;
						string str2 = "";
						int index3 = 0;
						if (0 < arrayList3.Count)
						{
							do
							{
								string str3 = (string)arrayList3[index3];
								int startIndex2;
								if (index3 == 0)
								{
									int startIndex3 = num + 10;
									int startIndex4 = startIndex3 + 2;
									startIndex2 = startIndex4 + 2;
									m_iService = OBD2.HexString2Int(str3.Substring(startIndex3, 2)) - 64;
									if (m_iService != 3 && m_iService != 4 && m_iService != 7)
										m_iPID = OBD2.HexString2Int(str3.Substring(startIndex4, 2));
									if (m_iService == 5 || m_iService == 2)
										startIndex2 = 16;
								}
								else
									startIndex2 = 10;
								str2 = str2 + str3.Substring(startIndex2, str3.Length - startIndex2);
								++index3;
							}
							while (index3 < arrayList3.Count);
						}
						listData.Add((object)str2);
						if ((m_iService == 3 || m_iService == 7) && 4 <= str2.Length)
						{
							int startIndex2 = 0;
							do
							{
								if (str2.Substring(startIndex2, 4).CompareTo("0000") != 0)
									listDTC.Add((object)OBD2.getDTCName(str2.Substring(startIndex2, 4)));
								startIndex2 += 4;
							}
							while (startIndex2 + 4 <= str2.Length);
						}
						++index2;
					}
					while (index2 < listECUResponses.Count);
				}
			}
			Debug.WriteLine(strResponse);
			Debug.WriteLine("listData:");

			int index4 = 0;
			if (0 < listData.Count)
			{
				do
				{
					Debug.WriteLine((string)listData[index4]);
					++index4;
				}
				while (index4 < listData.Count);
			}
			if (m_iService != 3 && m_iService != 7)
				return;
			Debug.WriteLine("DTCS:");
			int index5 = 0;
			if (0 >= listDTC.Count)
				return;
			do
			{
				Debug.WriteLine((string)listDTC[index5]);
				++index5;
			}
			while (index5 < listDTC.Count);
		}
	}

	public int getECUAddressStartIndex(int iProtocol)
	{
		if (iProtocol <= 5)
			return 4;
		return iProtocol != 6 && iProtocol != 8 && (iProtocol == 7 || iProtocol == 9) ? 6 : 0;
	}

	public int getECUAddressLength(int iProtocol)
	{
		if (iProtocol <= 5)
			return 2;
		if (iProtocol == 6 || iProtocol == 8)
			return 3;
		return iProtocol == 7 || iProtocol == 9 ? 2 : 0;
	}

	public OBD2Response.ResponseTypes ResponseType
	{
		get
		{
			if (strResponse.Length >= 1 && string.Compare(strResponse.Substring(0, 1), "?") == 0)
				return OBD2Response.ResponseTypes.Error;
			if (strResponse.Length >= 2 && string.Compare(strResponse.Substring(0, 2), "NO") == 0)
				return OBD2Response.ResponseTypes.NoData;
			if (strResponse.Length >= 2 && string.Compare(strResponse.Substring(0, 2), "OK") == 0)
				return OBD2Response.ResponseTypes.OK;
			if (strResponse.Length >= 3 && string.Compare(strResponse.Substring(0, 3), "ELM") == 0)
				return OBD2Response.ResponseTypes.ChipInfo;
			return strResponse.Length < 2 ? OBD2Response.ResponseTypes.Error : OBD2Response.ResponseTypes.HexData;
		}
	}

	public int getDataByte(int iECU, int iByte)
	{
		if (ResponseType == OBD2Response.ResponseTypes.HexData && listData.Count > iECU)
		{
			strData = (string)listData[iECU];
			int startIndex = iByte * 2;
			if (startIndex + 2 <= strData.Length)
				return OBD2.HexString2Int(strData.Substring(startIndex, 2));
		}
		return -1;
	}

	public int getDataByte(int iByte)
	{
		if (ResponseType == OBD2Response.ResponseTypes.HexData && listData.Count > 0)
		{
			strData = (string)listData[0];
			int startIndex = iByte * 2;
			if (startIndex + 2 <= strData.Length)
				return OBD2.HexString2Int(strData.Substring(startIndex, 2));
		}
		return -1;
	}

	public int getECUResponseCount()
	{
		return listData.Count;
	}

	public string getCode(int iCode)
	{
		if (iCode < listDTC.Count)
			return (string)listDTC[iCode];
		else
			return "P0000";
	}

	public SensorValue getValue(int iSubPID)
	{
		SensorValue sensorValue = new SensorValue();
		switch (m_iPID)
		{
			case 1:
				switch (iSubPID)
				{
					case 0:
						sensorValue.EnglishValue = DataA < 128 ? (double)DataA : (double)(DataA - 128);
						double num1 = sensorValue.EnglishValue;
						sensorValue.EnglishDisplay = num1.ToString();
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 1:
						sensorValue.EnglishValue = (double)(DataA & 128);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "OFF" : "ON";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 2:
						sensorValue.EnglishValue = (double)(DataB & 1);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 3:
						sensorValue.EnglishValue = (double)(DataB & 2);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 4:
						sensorValue.EnglishValue = (double)(DataB & 4);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 5:
						sensorValue.EnglishValue = (double)(DataB & 16);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 6:
						sensorValue.EnglishValue = (double)(DataB & 32);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 7:
						sensorValue.EnglishValue = (double)(DataB & 64);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 8:
						sensorValue.EnglishValue = (double)(DataC & 1);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 9:
						sensorValue.EnglishValue = (double)(DataC & 2);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 10:
						sensorValue.EnglishValue = (double)(DataC & 4);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 11:
						sensorValue.EnglishValue = (double)(DataC & 8);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 12:
						sensorValue.EnglishValue = (double)(DataC & 16);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 13:
						sensorValue.EnglishValue = (double)(DataC & 32);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 14:
						sensorValue.EnglishValue = (double)(DataC & 64);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 15:
						sensorValue.EnglishValue = (double)(DataC & 128);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue == 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 16:
						sensorValue.EnglishValue = (double)(DataD & 1);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 17:
						sensorValue.EnglishValue = (double)(DataD & 2);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 18:
						sensorValue.EnglishValue = (double)(DataD & 4);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 19:
						sensorValue.EnglishValue = (double)(DataD & 8);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 20:
						sensorValue.EnglishValue = (double)(DataD & 16);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 21:
						sensorValue.EnglishValue = (double)(DataD & 32);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 22:
						sensorValue.EnglishValue = (double)(DataD & 64);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
					case 23:
						sensorValue.EnglishValue = (double)(DataD & 128);
						sensorValue.EnglishDisplay = sensorValue.EnglishValue != 0.0 ? "NO" : "YES";
						sensorValue.MetricValue = sensorValue.EnglishValue;
						sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
						break;
				}
				break;
			case 2:
				sensorValue.EnglishValue = (double)(DataA * 256 + DataB);
				sensorValue.EnglishDisplay = OBD2.getDTCName(Response.Substring(4, 4));
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 3:
				int num2 = iSubPID != 0 ? DataB : DataA;
				sensorValue.EnglishValue = (double)num2;
				sensorValue.MetricValue = sensorValue.EnglishValue;
				if ((num2 & 1) != 0)
				{
					sensorValue.EnglishDisplay = "Open Loop: Has not yet satisfied conditions to go closed loop.";
					sensorValue.MetricDisplay = "OL";
				}
				else if ((num2 & 2) != 0)
				{
					sensorValue.EnglishDisplay = "Closed Loop: Using oxygen sensor(s) as feedback for fuel control.";
					sensorValue.MetricDisplay = "CL";
				}
				else if ((num2 & 4) != 0)
				{
					sensorValue.EnglishDisplay = "OL-Drive: Open loop due to driving conditions. (e.g., power enrichment, deceleration enleanment)";
					sensorValue.MetricDisplay = "OL-Drive";
				}
				else if ((num2 & 8) != 0)
				{
					sensorValue.EnglishDisplay = "OL-Fault: Open loop due to detected system fault.";
					sensorValue.MetricDisplay = "OL-Fault";
				}
				else if ((num2 & 16) != 0)
				{
					sensorValue.EnglishDisplay = "CL-Fault: Closed loop, but fault with at least one oxygen sensor. May be using single oxygen sensor for fuel control.";
					sensorValue.MetricDisplay = "CL-Fault";
				}
				else
				{
					sensorValue.EnglishDisplay = "";
					sensorValue.MetricDisplay = "";
				}
				break;
			case 4:
				sensorValue.EnglishValue = (double)DataA * (20.0 / 51.0);
				sensorValue.EnglishDisplay = sensorValue.EnglishValue.ToString("##0.##");
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 5:
				sensorValue.EnglishValue = ((double)DataA - 40.0) * 1.8 + 32.0;
				double num4 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num4.ToString();
				sensorValue.MetricValue = (double)DataA - 40.0;
				double num5 = sensorValue.MetricValue;
				sensorValue.MetricDisplay = num5.ToString();
				break;
			case 6:
			case 7:
			case 8:
			case 9:
				double num6 = iSubPID != 0 ? (double)DataB : (double)DataA;
				sensorValue.EnglishValue = num6 * (25.0 / 32.0) - 100.0;
				double num7 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num7.ToString();
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 10:
				double num8 = (double)DataA;
				sensorValue.EnglishValue = num8 * 30.0 * (1.0 / 69.0);
				double num9 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num9.ToString();
				sensorValue.MetricValue = num8 * 3.0;
				double num10 = sensorValue.MetricValue;
				sensorValue.MetricDisplay = num10.ToString();
				break;
			case 11:
				double num11 = (double)DataA;
				sensorValue.EnglishValue = num11 * 10.0 * (1.0 / 69.0);
				double num12 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num12.ToString();
				sensorValue.MetricValue = num11;
				double num13 = sensorValue.MetricValue;
				sensorValue.MetricDisplay = num13.ToString();
				break;
			case 12:
				double num14 = (double)(DataA * 256 + DataB);
				sensorValue.EnglishValue = num14 * 0.25;
				double num15 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num15.ToString();
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 13:
				double num16 = (double)DataA;
				sensorValue.EnglishValue = num16 * 0.625;
				double num17 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num17.ToString();
				sensorValue.MetricValue = num16;
				double num18 = sensorValue.MetricValue;
				sensorValue.MetricDisplay = num18.ToString();
				break;
			case 14:
				double num19 = (double)DataA;
				sensorValue.EnglishValue = num19 * 0.5 - 64.0;
				double num20 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num20.ToString();
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 15:
				double num21 = (double)DataA - 40.0;
				sensorValue.EnglishValue = num21 * 1.8 + 32.0;
				double num22 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num22.ToString();
				sensorValue.MetricValue = num21;
				double num23 = sensorValue.MetricValue;
				sensorValue.MetricDisplay = num23.ToString();
				break;
			case 16:
				double num24 = (double)(DataA * 256 + DataB);
				sensorValue.EnglishValue = num24 * 0.00132278048457858;
				double num25 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num25.ToString();
				sensorValue.MetricValue = num24 * 0.01;
				double num26 = sensorValue.MetricValue;
				sensorValue.MetricDisplay = num26.ToString();
				break;
			case 17:
				double num27 = (double)DataA;
				sensorValue.EnglishValue = num27 * (20.0 / 51.0);
				double num28 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num28.ToString();
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 18:
				sensorValue.EnglishValue = (double)DataA;
				if ((DataA & 1) != 0)
					sensorValue.EnglishDisplay = "UPS: Upstream of first catalytic converter.";
				else if ((DataA & 2) != 0)
					sensorValue.EnglishDisplay = "DNS: Downstream of first catalytic converter inlet.";
				else if ((DataA & 4) != 0)
					sensorValue.EnglishDisplay = "OFF: Atmosphere / Off";
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 19:
				double num29 = (double)DataA;
				sensorValue.EnglishValue = num29;
				if ((DataA & 1) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S11) Bank 1 Sensor 1\r\n";
				if ((DataA & 2) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S12) Bank 1 Sensor 2\r\n";
				if ((DataA & 4) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S13) Bank 1 Sensor 3\r\n";
				if ((DataA & 8) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S14) Bank 1 Sensor 4\r\n";
				if ((DataA & 16) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S21) Bank 2 Sensor 1\r\n";
				if ((DataA & 32) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S22) Bank 2 Sensor 2\r\n";
				if ((DataA & 64) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S23) Bank 2 Sensor 3\r\n";
				if ((DataA & 128) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S24) Bank 2 Sensor 4\r\n";
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
				double num30 = (double)DataA;
				double num31 = (double)DataB;
				if (iSubPID == 0)
				{
					sensorValue.EnglishValue = num30 * 0.005;
					double num32 = sensorValue.EnglishValue;
					sensorValue.EnglishDisplay = num32.ToString();
				}
				else if (num31 == (double)byte.MaxValue)
				{
					sensorValue.EnglishValue = -1.0;
					sensorValue.EnglishDisplay = "NOT USED";
				}
				else
				{
					sensorValue.EnglishValue = num31 * (25.0 / 32.0) - 100.0;
					double num32 = sensorValue.EnglishValue;
					sensorValue.EnglishDisplay = num32.ToString();
				}
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 28:
				double num33 = (double)DataA;
				sensorValue.EnglishValue = num33;
				if (num33 == 1.0)
					sensorValue.EnglishDisplay = "OBD II (California ARB)";
				else if (num33 == 2.0)
					sensorValue.EnglishDisplay = "OBD (Federal EPA)";
				else if (num33 == 3.0)
					sensorValue.EnglishDisplay = "OBD and OBD II";
				else if (num33 == 4.0)
					sensorValue.EnglishDisplay = "OBD I";
				else if (num33 == 5.0)
					sensorValue.EnglishDisplay = "Not OBD Compliant";
				else if (num33 == 6.0)
					sensorValue.EnglishDisplay = "EOBD";
				else if (num33 == 7.0)
					sensorValue.EnglishDisplay = "EOBD and OBD II";
				else if (num33 == 8.0)
					sensorValue.EnglishDisplay = "EOBD and OBD";
				else if (num33 == 9.0)
					sensorValue.EnglishDisplay = "EOBD, OBD and OBD II";
				else if (num33 == 10.0)
					sensorValue.EnglishDisplay = "JOBD";
				else if (num33 == 11.0)
					sensorValue.EnglishDisplay = "JOBD and OBD II";
				else if (num33 == 12.0)
					sensorValue.EnglishDisplay = "JOBD and EOBD";
				else if (num33 == 13.0)
					sensorValue.EnglishDisplay = "JOBD, EOBD, and OBD II";
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 29:
				double num34 = (double)DataA;
				sensorValue.EnglishValue = num34;
				if ((DataA & 1) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S11) Bank 1 Sensor 1\r\n";
				if ((DataA & 2) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S12) Bank 1 Sensor 2\r\n";
				if ((DataA & 4) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S21) Bank 2 Sensor 1\r\n";
				if ((DataA & 8) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S22) Bank 2 Sensor 2\r\n";
				if ((DataA & 16) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S31) Bank 3 Sensor 1\r\n";
				if ((DataA & 32) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S32) Bank 3 Sensor 2\r\n";
				if ((DataA & 64) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S41) Bank 4 Sensor 1\r\n";
				if ((DataA & 128) != 0)
					sensorValue.EnglishDisplay = sensorValue.EnglishDisplay + "(O2S42) Bank 4 Sensor 2\r\n";
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 30:
				double num35 = (double)DataA;
				sensorValue.EnglishValue = num35;
				sensorValue.EnglishDisplay = num35 != 0.0 ? "ON" : "OFF";
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
			case 31:
				double num36 = (double)(DataA * 256 + DataB);
				sensorValue.EnglishValue = num36;
				double num37 = sensorValue.EnglishValue;
				sensorValue.EnglishDisplay = num37.ToString();
				sensorValue.MetricValue = sensorValue.EnglishValue;
				sensorValue.MetricDisplay = sensorValue.EnglishDisplay;
				break;
		}
		return sensorValue;
	}
}