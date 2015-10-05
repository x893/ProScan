using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProScan
{
	public class OBDParser_ISO15765_4_CAN11 : OBDParser
	{
		protected static int HEADER_LENGTH = 3;

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
			if (line0.Length < OBDParser_ISO15765_4_CAN11.HEADER_LENGTH)
			{
				responseList.ErrorDetected = true;
				return responseList;
			}

			string header = line0.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH);
			int idx = 1;
			while (idx < lines.Count)
			{
				string line = lines[idx];
				if (line.Length >= OBDParser_ISO15765_4_CAN11.HEADER_LENGTH)
				{
					if (line.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH).CompareTo(header) == 0)
						group.Add(line);
					else
					{
						group = new List<string>();
						group.Add(lines[idx]);
						groups.Add(group);
						header = line.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH);
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
				bool bIsMultiline = false;
				group = groups[idx];
				if (group.Count > 1)
					bIsMultiline = true;
				int dataStartIndex1 = getDataStartIndex(param, bIsMultiline, false);
				string str2 = group[0];
				int length1 = str2.Length - dataStartIndex1;
				obd_response.Header = str2.Substring(0, OBDParser_ISO15765_4_CAN11.HEADER_LENGTH);
				obd_response.Data = length1 > 0 ? str2.Substring(dataStartIndex1, length1) : "";
				int dataStartIndex2 = getDataStartIndex(param, bIsMultiline, true);
				int sub_idx = 1;
				while (sub_idx < group.Count)
				{
					string str3 = group[sub_idx];
					int length2 = str3.Length - dataStartIndex2;
					obd_response.Data = obd_response.Data + (length2 > 0 ? str3.Substring(dataStartIndex2, length2) : "");
					++sub_idx;
				}
				responseList.AddOBDResponse(obd_response);
				++idx;
			}
			return responseList;
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
	}
}
