using System;
using System.Collections;
using System.Runtime.InteropServices;

public class OBDParser_ISO15765_4_CAN11 : OBDParser
{
	protected static int HEADER_LENGTH = 3;

	static OBDParser_ISO15765_4_CAN11()
	{
	}

	~OBDParser_ISO15765_4_CAN11()
	{
	}

	public override OBDResponseList parse(OBDParameter param, string response)
	{
		if (response != null)
		{
			if (response.Length < 1)
				response = "";
		}
		else
			response = "";
		OBDResponseList obdResponseList = new OBDResponseList(response);
		response = strip(response);
		if (errorCheck(response))
		{
			obdResponseList.ErrorDetected = true;
			return obdResponseList;
		}
		else
		{
			ArrayList arrayList1 = split(response);
			arrayList1.Sort();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			arrayList3.Add(arrayList1[0]);
			arrayList2.Add((object)arrayList3);
			string str1 = (string)arrayList1[0];
			if (str1.Length < OBDParser_ISO15765_4_CAN11.HEADER_LENGTH)
			{
				obdResponseList.ErrorDetected = true;
				return obdResponseList;
			}
			else
			{
				string strB = str1.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH);
				int index1 = 1;
				if (1 < arrayList1.Count)
				{
					do
					{
						string str2 = (string)arrayList1[index1];
						if (str2.Length >= OBDParser_ISO15765_4_CAN11.HEADER_LENGTH)
						{
							if (str2.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH).CompareTo(strB) == 0)
							{
								arrayList3.Add((object)str2);
							}
							else
							{
								arrayList3 = new ArrayList();
								arrayList3.Add(arrayList1[index1]);
								arrayList2.Add((object)arrayList3);
								strB = str2.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH);
							}
							++index1;
						}
						else
							goto label_14;
					}
					while (index1 < arrayList1.Count);
					goto label_15;
				label_14:
					obdResponseList.ErrorDetected = true;
					return obdResponseList;
				}
			label_15:
				int index2 = 0;
				if (0 < arrayList2.Count)
				{
					do
					{
						OBDResponse response1 = new OBDResponse();
						bool bIsMultiline = false;
						ArrayList arrayList4 = (ArrayList)arrayList2[index2];
						if (arrayList4.Count > 1)
							bIsMultiline = true;
						int dataStartIndex1 = getDataStartIndex(param, bIsMultiline, false);
						string str2 = (string)arrayList4[0];
						int length1 = str2.Length - dataStartIndex1;
						response1.Header = str2.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH);
						response1.Data = length1 > 0 ? str2.Substring(dataStartIndex1, length1) : "";
						int dataStartIndex2 = getDataStartIndex(param, bIsMultiline, true);
						int index3 = 1;
						if (1 < arrayList4.Count)
						{
							do
							{
								string str3 = (string)arrayList4[index3];
								int length2 = str3.Length - dataStartIndex2;
								string str4 = length2 > 0 ? str3.Substring(dataStartIndex2, length2) : "";
								response1.Data = response1.Data + str4;
								++index3;
							}
							while (index3 < arrayList4.Count);
						}
						obdResponseList.AddOBDResponse(response1);
						++index2;
					}
					while (index2 < arrayList2.Count);
				}
				return obdResponseList;
			}
		}
	}

	protected int getDataStartIndex(OBDParameter param, bool bIsMultiline, bool bConsecutiveLine)
	{
		if (bConsecutiveLine)
			return 5;
		switch (param.Service)
		{
			case 1:
				return 9;
			case 2:
				return 11;
			case 3:
			case 7:
				return !bIsMultiline ? 9 : 11;
			case 4:
				return 7;
			case 5:
				return 11;
			case 9:
				return 13;
			default:
				return 9;
		}
	}

	public new void __dtor()
	{
		GC.SuppressFinalize((object)this);
	}
}
