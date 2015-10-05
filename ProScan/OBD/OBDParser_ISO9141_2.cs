using System;
using System.Collections;
using System.Collections.Generic;

namespace ProScan
{
	public class OBDParser_ISO9141_2 : OBDParser
	{
		protected static int HEADER_LENGTH = 6;

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

			List<string> lines = SplitByCR(response);
			lines.Sort();
			List<List<string>> groups = new List<List<string>>();
			List<string> group = new List<string>();
			string line0 = lines[0];
			group.Add(line0);
			groups.Add(group);
			if (line0.Length < OBDParser_ISO9141_2.HEADER_LENGTH)
			{
				responseList.ErrorDetected = true;
				return responseList;
			}

			string header = line0.Substring(0, OBDParser_ISO9141_2.HEADER_LENGTH);
			int idx = 1;
			while (idx < lines.Count)
			{
				string str2 = (string)lines[idx];
				if (str2.Length >= OBDParser_ISO9141_2.HEADER_LENGTH)
				{
					if (str2.Substring(0, OBDParser_ISO9141_2.HEADER_LENGTH).CompareTo(header) == 0)
						group.Add(str2);
					else
					{
						group = new List<string>();
						group.Add(lines[idx]);
						groups.Add(group);
						header = str2.Substring(0, OBDParser_ISO9141_2.HEADER_LENGTH);
					}
					++idx;
				}
				else
				{
					responseList.ErrorDetected = true;
					return responseList;
				}
			}

			idx = 0;
			while (idx < groups.Count)
			{
				OBDResponse obd_response = new OBDResponse();
				group = groups[idx];
				int dataStartIndex = getDataStartIndex(param);
				string str2 = group[0];
				int num1 = -2 - dataStartIndex;
				int length1 = str2.Length + num1;
				obd_response.Header = str2.Substring(0, OBDParser_ISO9141_2.HEADER_LENGTH);
				obd_response.Data = length1 > 0 ? str2.Substring(dataStartIndex, length1) : "";
				int sub_idx = 1;
				while (sub_idx < group.Count)
				{
					string str3 = group[sub_idx];
					int length2 = str3.Length + num1;
					obd_response.Data = obd_response.Data + (length2 > 0 ? str3.Substring(dataStartIndex, length2) : "");
					++sub_idx;
				}
				responseList.AddOBDResponse(obd_response);
				++idx;
			}
			return responseList;
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
