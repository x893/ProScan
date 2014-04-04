using System.Runtime.CompilerServices;

public class OBD2Request
{
	public enum RequestTypes
	{
		Setting = 1,
		ChipInfo = 2,
		HexData = 3,
		Other = 4,
	}

	public OBD2Request.RequestTypes RequestType;
	private string strRequest;

	public string PID
	{
		get
		{
			if (get_RequestType() == OBD2Request.RequestTypes.HexData && strRequest.Length >= 4)
				return strRequest.Substring(2, 2);
			else
				return "";
		}
	}

	public string Service
	{
		get
		{
			if (get_RequestType() == OBD2Request.RequestTypes.HexData)
				return "0" + strRequest.Substring(1, 1);
			else
				return "";
		}
	}

	public string Request
	{
		get
		{
			return strRequest;
		}
	}

	public OBD2Request(int iService, int iPID, int iFrame)
	{
		strRequest = OBD2.Int2HexString(iService) + OBD2.Int2HexString(iPID) + OBD2.Int2HexString(iFrame);
	}

	public OBD2Request(int iService, int iPID)
	{
		strRequest = OBD2.Int2HexString(iService) + OBD2.Int2HexString(iPID);
	}

	public OBD2Request(string request)
	{
		strRequest = request;
	}

	[SpecialName]
	public OBD2Request.RequestTypes get_RequestType()
	{
		if (string.Compare(strRequest.Substring(0, 3), "ATI") == 0)
			return OBD2Request.RequestTypes.ChipInfo;
		if (string.Compare(strRequest.Substring(0, 2), "AT") == 0)
			return OBD2Request.RequestTypes.Setting;
		return strRequest.Length < 2 ? OBD2Request.RequestTypes.Other : OBD2Request.RequestTypes.HexData;
	}
}