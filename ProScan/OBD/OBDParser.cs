using System;
using System.Collections;
using System.Runtime.InteropServices;

public abstract class OBDParser
{
	~OBDParser()
	{
	}

	public abstract OBDResponseList parse(OBDParameter param, string response);

	protected string strip(string input)
	{
		if (input == null)
			return "";
		else
			return input.Replace("BUS", "").Replace("INIT", "").Replace("DONE", "").Replace("SEARCHING", "").Replace(":", "").Replace(".", "").Replace(" ", "").Trim();
	}

	protected ArrayList split(string input)
	{
		ArrayList arrayList = new ArrayList();
		string str = "";
		int startIndex = 0;
		if (0 < input.Length)
		{
			do
			{
				if (input.Substring(startIndex, 1).CompareTo("\r") == 0)
				{
					arrayList.Add((object)str);
					str = "";
				}
				else
					str = str + input.Substring(startIndex, 1);
				++startIndex;
			}
			while (startIndex < input.Length);
		}
		arrayList.Add((object)str);
		return arrayList;
	}


	protected bool errorCheck(string input)
  {
      return (
		  input.IndexOf("TIMEOUT") >= 0 ||
		  input.IndexOf("?") >= 0 ||
		  input.IndexOf("NODATA") >= 0 ||
		  input.IndexOf("BUFFERFULL") >= 0 ||
		  input.IndexOf("BUSBUSY") >= 0 ||
		  input.IndexOf("BUSERROR") >= 0 ||
		  input.IndexOf("CANERROR") >= 0 ||
		  input.IndexOf("DATAERROR") >= 0 ||
		  input.IndexOf("<DATAERROR") >= 0 ||
		  input.IndexOf("<RXERROR") >= 0 ||
		  input.IndexOf("FBERROR") >= 0 ||
		  input.IndexOf("ERR") >= 0 ||
		  input.IndexOf("LVRESET") >= 0 ||
		  input.IndexOf("STOPPED") >= 0 ||
		  input.IndexOf("UNABLETOCONNECT") >= 0
		  );
  }

	public void __dtor()
	{
		GC.SuppressFinalize((object)this);
	}
}

