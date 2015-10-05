using System;
using System.Collections;
using System.Collections.Generic;

namespace ProScan
{
	public class OBDParser_ISO14230_4_KWP : OBDParser
	{
		protected static int HEADER_LENGTH = 6;

		static OBDParser_ISO14230_4_KWP()
		{
		}

		public override OBDResponseList Parse(OBDParameter param, string response)
		{
			if (string.IsNullOrEmpty(response))
				response = "";

			OBDResponseList responseList = new OBDResponseList(response);
			response = Strip(response);
			if (ErrorCheck(response))
			{
				responseList.ErrorDetected = true;
				return responseList;
			}
			else
			{
				List<string> list1 = SplitByCR(response);
				list1.Sort();
				List<List<string>> list2 = new List<List<string>>();
				List<string> list3 = new List<string>();
				string str1 = list1[0];
				list3.Add(str1);
				list2.Add(list3);
				if (str1.Length < OBDParser_ISO14230_4_KWP.HEADER_LENGTH)
				{
					responseList.ErrorDetected = true;
					return responseList;
				}
				else
				{
					string strB = str1.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH);
					int index1 = 1;
					if (1 < list1.Count)
					{
						do
						{
							string str2 = list1[index1];
							if (str2.Length >= OBDParser_ISO14230_4_KWP.HEADER_LENGTH)
							{
								if (str2.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH).CompareTo(strB) == 0)
									list3.Add(str2);
								else
								{
									list3 = new List<string>();
									list3.Add(list1[index1]);
									list2.Add(list3);
									strB = str2.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH);
								}
								++index1;
							}
							else
								goto label_14;
						}
						while (index1 < list1.Count);
						goto label_15;
					label_14:
						responseList.ErrorDetected = true;
						return responseList;
					}
				label_15:
					int index2 = 0;
					if (0 < list2.Count)
					{
						do
						{
							OBDResponse response1 = new OBDResponse();
							List<string> list4 = list2[index2];
							int dataStartIndex = getDataStartIndex(param);
							string str2 = list4[0];
							int num1 = -2 - dataStartIndex;
							int length1 = str2.Length + num1;
							response1.Header = str2.Substring(0, OBDParser_ISO14230_4_KWP.HEADER_LENGTH);
							response1.Data = length1 > 0 ? str2.Substring(dataStartIndex, length1) : "";
							int index3 = 1;
							if (1 < list4.Count)
							{
								int num2 = num1;
								do
								{
									string str3 = list4[index3];
									int length2 = str3.Length + num2;
									string str4 = length2 > 0 ? str3.Substring(dataStartIndex, length2) : "";
									response1.Data = response1.Data + str4;
									++index3;
								}
								while (index3 < list4.Count);
							}
							responseList.AddOBDResponse(response1);
							++index2;
						}
						while (index2 < list2.Count);
					}
					return responseList;
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
	}
}
