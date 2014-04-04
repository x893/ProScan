using System;
using System.Collections;

public class OBDParser_ISO14230_4_KWP : OBDParser
{
	protected static int HEADER_LENGTH = 6;

	static OBDParser_ISO14230_4_KWP()
	{
	}

	~OBDParser_ISO14230_4_KWP()
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
			if (str1.Length < OBDParser_ISO14230_4_KWP.HEADER_LENGTH)
			{
				obdResponseList.ErrorDetected = true;
				return obdResponseList;
			}
			else
			{
				string strB = str1.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH);
				int index1 = 1;
				if (1 < arrayList1.Count)
				{
					do
					{
						string str2 = (string)arrayList1[index1];
						if (str2.Length >= OBDParser_ISO14230_4_KWP.HEADER_LENGTH)
						{
							if (str2.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH).CompareTo(strB) == 0)
							{
								arrayList3.Add((object)str2);
							}
							else
							{
								arrayList3 = new ArrayList();
								arrayList3.Add(arrayList1[index1]);
								arrayList2.Add((object)arrayList3);
								strB = str2.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH);
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
						ArrayList arrayList4 = (ArrayList)arrayList2[index2];
						int dataStartIndex = getDataStartIndex(param);
						string str2 = (string)arrayList4[0];
						int num1 = -2 - dataStartIndex;
						int length1 = str2.Length + num1;
						response1.Header = str2.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH);
						response1.Data = length1 > 0 ? str2.Substring(dataStartIndex, length1) : "";
						int index3 = 1;
						if (1 < arrayList4.Count)
						{
							int num2 = num1;
							do
							{
								string str3 = (string)arrayList4[index3];
								int length2 = str3.Length + num2;
								string str4 = length2 > 0 ? str3.Substring(dataStartIndex, length2) : "";
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

	protected int getDataStartIndex(OBDParameter param)
	{
		switch (param.Service)
		{
			case 1:
				return 10;
			case 2:
				return 12;
			case 3:
			case 4:
				return 8;
			case 5:
				return 12;
			case 7:
				return 8;
			case 9:
				if (param.Parameter == 2)
					return 12;
				else
					break;
		}
		return 10;
	}

	public new void __dtor()
	{
		GC.SuppressFinalize((object)this);
	}
}