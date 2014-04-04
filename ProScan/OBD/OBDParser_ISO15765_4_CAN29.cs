using System;

public class OBDParser_ISO15765_4_CAN29 : OBDParser
{
	protected static int HEADER_LENGTH = 6;

	static OBDParser_ISO15765_4_CAN29()
	{
	}

	~OBDParser_ISO15765_4_CAN29()
	{
	}

	public override OBDResponseList parse(OBDParameter param, string response)
	{
		return new OBDResponseList(response);
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