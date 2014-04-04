using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

public class OBDInterpretter
{
	private const string HexDigits = "0123456789abcdef";

	public static int HexByteToInt(string strHex)
	{
		if (strHex.Length >= 2)
		{
			int num2 = HexDigits.IndexOf(Char.ToLower(strHex[0])) & 0xF;
			int num = HexDigits.IndexOf(Char.ToLower(strHex[1])) & 0xF;
			return ((num2 * 0x10) + num);
		}
		return -1;
	}

	public static string HexStringToASCIIString(string strHex)
	{
		string str = "";
		int startIndex = 0;
		if (strHex.Length > 0)
		{
			do
			{
				int num2 = HexByteToInt(strHex.Substring(startIndex, 2));
				if (num2 != 0)
				{
					str = str + new string((char)num2, 1);
				}
				startIndex += 2;
			}
			while (startIndex < strHex.Length);
		}
		return str;
	}

	public static OBDParameterValue getValue(OBDParameter param, OBDResponse response, bool bEnglishUnits)
	{
		StringCollection strings;
		OBDParameterValue value2 = new OBDParameterValue();
		if (response == null)
		{
			value2.ErrorDetected = true;
			return value2;
		}
		switch (param.Service)
		{
			case 0:
			case 1:
			case 2:
				switch (param.Parameter)
				{
					case 0:
					case 0x20:
					case 0x40:
					case 0x60:
					case 0x80:
						{
							if (response.getDataByteCount() < 4)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num8 = HexByteToInt(response.getDataByte(0));
							int num7 = HexByteToInt(response.getDataByte(1));
							int num6 = HexByteToInt(response.getDataByte(2));
							int num5 = HexByteToInt(response.getDataByte(3));
							value2.setBitFlag(0, ((num8 >> 7) & 1) == 1 ? false : true);
							value2.setBitFlag(1, ((num8 >> 6) & 1) == 1 ? false : true);
							value2.setBitFlag(2, ((num8 >> 5) & 1) == 1 ? false : true);
							value2.setBitFlag(3, ((num8 >> 4) & 1) == 1 ? false : true);
							value2.setBitFlag(4, ((num8 >> 3) & 1) == 1 ? false : true);
							value2.setBitFlag(5, ((num8 >> 2) & 1) == 1 ? false : true);
							value2.setBitFlag(6, ((num8 >> 1) & 1) == 1 ? false : true);
							value2.setBitFlag(7, (num8 & 1) == 1 ? false : true);
							value2.setBitFlag(8, ((num7 >> 7) & 1) == 1 ? false : true);
							value2.setBitFlag(9, ((num7 >> 6) & 1) == 1 ? false : true);
							value2.setBitFlag(10, ((num7 >> 5) & 1) == 1 ? false : true);
							value2.setBitFlag(11, ((num7 >> 4) & 1) == 1 ? false : true);
							value2.setBitFlag(12, ((num7 >> 3) & 1) == 1 ? false : true);
							value2.setBitFlag(13, ((num7 >> 2) & 1) == 1 ? false : true);
							value2.setBitFlag(14, ((num7 >> 1) & 1) == 1 ? false : true);
							value2.setBitFlag(15, (num7 & 1) == 1 ? false : true);
							value2.setBitFlag(16, ((num6 >> 7) & 1) == 1 ? false : true);
							value2.setBitFlag(17, ((num6 >> 6) & 1) == 1 ? false : true);
							value2.setBitFlag(18, ((num6 >> 5) & 1) == 1 ? false : true);
							value2.setBitFlag(19, ((num6 >> 4) & 1) == 1 ? false : true);
							value2.setBitFlag(20, ((num6 >> 3) & 1) == 1 ? false : true);
							value2.setBitFlag(21, ((num6 >> 2) & 1) == 1 ? false : true);
							value2.setBitFlag(22, ((num6 >> 1) & 1) == 1 ? false : true);
							value2.setBitFlag(23, (num6 & 1) == 1 ? false : true);
							value2.setBitFlag(24, ((num5 >> 7) & 1) == 1 ? false : true);
							value2.setBitFlag(25, ((num5 >> 6) & 1) == 1 ? false : true);
							value2.setBitFlag(26, ((num5 >> 5) & 1) == 1 ? false : true);
							value2.setBitFlag(27, ((num5 >> 4) & 1) == 1 ? false : true);
							value2.setBitFlag(28, ((num5 >> 3) & 1) == 1 ? false : true);
							value2.setBitFlag(29, ((num5 >> 2) & 1) == 1 ? false : true);
							value2.setBitFlag(30, ((num5 >> 1) & 1) == 1 ? false : true);
							value2.setBitFlag(31, (num5 & 1) == 1 ? false : true);
							return value2;
						}
					case 1:
						if (response.getDataByteCount() < 4)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						switch (param.SubParameter)
						{
							case 0:
								if ((HexByteToInt(response.getDataByte(0)) & 0x80) == 0)
									return new OBDParameterValue(false, 0.0, "OFF", "OFF");
								return new OBDParameterValue(true, 1.0, "ON", "ON");

							case 1:
								{
									int num12 = HexByteToInt(response.getDataByte(0));
									if ((num12 & 0x80) != 0)
									{
										num12 -= 0x80;
									}
									value2.DoubleValue = num12;
									return value2;
								}
							case 2:
								if ((HexByteToInt(response.getDataByte(1)) & 1) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 3:
								if ((HexByteToInt(response.getDataByte(1)) & 2) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 4:
								if ((HexByteToInt(response.getDataByte(1)) & 4) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 5:
								if ((HexByteToInt(response.getDataByte(1)) & 0x10) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 6:
								if ((HexByteToInt(response.getDataByte(1)) & 0x20) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 7:
								if ((HexByteToInt(response.getDataByte(1)) & 0x40) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 8:
								if ((HexByteToInt(response.getDataByte(2)) & 1) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 9:
								if ((HexByteToInt(response.getDataByte(2)) & 2) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 10:
								if ((HexByteToInt(response.getDataByte(2)) & 4) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 11:
								if ((HexByteToInt(response.getDataByte(2)) & 8) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 12:
								if ((HexByteToInt(response.getDataByte(2)) & 0x10) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 13:
								if ((HexByteToInt(response.getDataByte(2)) & 0x20) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 14:
								if ((HexByteToInt(response.getDataByte(2)) & 0x40) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 15:
								if ((HexByteToInt(response.getDataByte(2)) & 0x80) == 0)
									return new OBDParameterValue(false, 0.0, "NO", "NO");
								return new OBDParameterValue(true, 1.0, "YES", "YES");

							case 0x10:
								if ((HexByteToInt(response.getDataByte(3)) & 1) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 0x11:
								if ((HexByteToInt(response.getDataByte(3)) & 2) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 0x12:
								if ((HexByteToInt(response.getDataByte(3)) & 4) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 0x13:
								if ((HexByteToInt(response.getDataByte(3)) & 8) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 20:
								if ((HexByteToInt(response.getDataByte(3)) & 0x10) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 0x15:
								if ((HexByteToInt(response.getDataByte(3)) & 0x20) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 0x16:
								if ((HexByteToInt(response.getDataByte(3)) & 0x40) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");

							case 0x17:
								if ((HexByteToInt(response.getDataByte(3)) & 0x80) == 0)
									return new OBDParameterValue(true, 1.0, "YES", "YES");
								return new OBDParameterValue(false, 0.0, "NO", "NO");
						}
						goto Label_10DD;

					case 2:
						goto Label_10DD;

					case 3:
						int num9;
						if (response.getDataByteCount() < 2)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						if (param.SubParameter == 0)
						{
							num9 = HexByteToInt(response.getDataByte(0));
						}
						else
						{
							num9 = HexByteToInt(response.getDataByte(1));
						}
						if ((num9 & 1) != 0)
						{
							value2.StringValue = "Open Loop: Has not yet satisfied conditions to go closed loop.";
							value2.ShortStringValue = "OL";
							return value2;
						}
						if ((num9 & 2) != 0)
						{
							value2.StringValue = "Closed Loop: Using oxygen sensor(s) as feedback for fuel control.";
							value2.ShortStringValue = "CL";
							return value2;
						}
						if ((num9 & 4) != 0)
						{
							value2.StringValue = "OL-Drive: Open loop due to driving conditions. (e.g., power enrichment, deceleration enleanment)";
							value2.ShortStringValue = "OL-Drive";
							return value2;
						}
						if ((num9 & 8) != 0)
						{
							value2.StringValue = "OL-Fault: Open loop due to detected system fault.";
							value2.ShortStringValue = "OL-Fault";
							return value2;
						}
						if ((num9 & 0x10) != 0)
						{
							value2.StringValue = "CL-Fault: Closed loop, but fault with at least one oxygen sensor. May be using single oxygen sensor for fuel control.";
							value2.ShortStringValue = "CL-Fault";
							return value2;
						}
						value2.StringValue = "Not Supported";
						value2.ShortStringValue = value2.StringValue;
						return value2;

					case 4:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						value2.DoubleValue = HexByteToInt(response.getDataByte(0)) * 0.39215686274509803;
						return value2;

					case 5:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						value2.DoubleValue = HexByteToInt(response.getDataByte(0)) - 40.0;
						if (bEnglishUnits)
						{
							value2.DoubleValue = (value2.DoubleValue * 1.8) + 32.0;
						}
						return value2;

					case 6:
					case 7:
					case 8:
					case 9:
						int num16;
						if (response.getDataByteCount() < 2)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						if (param.SubParameter == 0)
						{
							num16 = HexByteToInt(response.getDataByte(0));
						}
						else
						{
							num16 = HexByteToInt(response.getDataByte(1));
						}
						value2.DoubleValue = (num16 * 0.78125) - 100.0;
						return value2;

					case 10:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						value2.DoubleValue = HexByteToInt(response.getDataByte(0)) * 3.0;
						if (bEnglishUnits)
						{
							value2.DoubleValue *= 0.145037738;
						}
						return value2;

					case 11:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						value2.DoubleValue = HexByteToInt(response.getDataByte(0));
						if (bEnglishUnits)
						{
							value2.DoubleValue *= 0.145037738;
						}
						return value2;

					case 12:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num66 = HexByteToInt(response.getDataByte(0));
							int num65 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = ((num66 * 0x100) + num65) * 0.25;
							return value2;
						}
					case 13:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num64 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = num64;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.621371192;
							}
							return value2;
						}
					case 14:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num63 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num63 * 0.5) - 64.0;
							return value2;
						}
					case 15:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						value2.DoubleValue = HexByteToInt(response.getDataByte(0)) - 40.0;
						if (bEnglishUnits)
						{
							value2.DoubleValue = (value2.DoubleValue * 1.8) + 32.0;
						}
						return value2;

					case 0x10:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num62 = HexByteToInt(response.getDataByte(0));
							double num61 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = ((num62 * 256.0) + num61) * 0.01;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.13227735731092655;
							}
							return value2;
						}
					case 0x11:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num60 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = num60 * 0.39215686274509803;
							return value2;
						}
					case 0x12:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num13 = HexByteToInt(response.getDataByte(0));
							if ((num13 & 1) != 0)
							{
								value2.StringValue = "Upstream of first catalytic converter.";
								value2.ShortStringValue = "UPS";
								return value2;
							}
							if ((num13 & 2) != 0)
							{
								value2.StringValue = "Downstream of first catalytic converter inlet.";
								value2.ShortStringValue = "DNS";
								return value2;
							}
							if ((num13 & 4) != 0)
							{
								value2.StringValue = "Atmosphere / Off";
								value2.ShortStringValue = "OFF";
							}
							return value2;
						}
					case 0x13:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num4 = HexByteToInt(response.getDataByte(0));
							switch (param.SubParameter)
							{
								case 0:
									if ((num4 & 1) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 1:
									if ((num4 & 2) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 2:
									if ((num4 & 4) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 3:
									if ((num4 & 8) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 4:
									if ((num4 & 0x10) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 5:
									if ((num4 & 0x20) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 6:
									if ((num4 & 0x40) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 7:
									if ((num4 & 0x80) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
							}
							goto Label_1A00;
						}
					case 20:
					case 0x15:
					case 0x16:
					case 0x17:
					case 0x18:
					case 0x19:
					case 0x1a:
					case 0x1b:
						goto Label_1A00;

					case 0x1c:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						switch (HexByteToInt(response.getDataByte(0)))
						{
							case 1:
								value2.StringValue = "OBD II (California ARB)";
								value2.ShortStringValue = "OBDII CARB";
								return value2;

							case 2:
								value2.StringValue = "OBD (Federal EPA)";
								value2.ShortStringValue = "OBD (Fed)";
								return value2;

							case 3:
								value2.StringValue = "OBD and OBD II";
								value2.ShortStringValue = "OBD/OBDII";
								return value2;

							case 4:
								value2.StringValue = "OBD I";
								value2.ShortStringValue = "OBDI";
								return value2;

							case 5:
								value2.StringValue = "Not OBD Compliant";
								value2.ShortStringValue = "NO OBD";
								return value2;

							case 6:
								value2.StringValue = "EOBD";
								value2.ShortStringValue = "EOBD";
								return value2;

							case 7:
								value2.StringValue = "EOBD and OBD II";
								value2.ShortStringValue = "EOBD/OBDII";
								return value2;

							case 8:
								value2.StringValue = "EOBD and OBD";
								value2.ShortStringValue = "EOBD/OBD";
								return value2;

							case 9:
								value2.StringValue = "EOBD, OBD and OBD II";
								value2.ShortStringValue = "EOBD/OBD/OBDII";
								return value2;

							case 10:
								value2.StringValue = "JOBD";
								value2.ShortStringValue = "JOBD";
								return value2;

							case 11:
								value2.StringValue = "JOBD and OBD II";
								value2.ShortStringValue = "JOBD/OBDII";
								return value2;

							case 12:
								value2.StringValue = "JOBD and EOBD";
								value2.ShortStringValue = "JOBD/EOBD";
								return value2;

							case 13:
								value2.StringValue = "JOBD, EOBD, and OBD II";
								value2.ShortStringValue = "JOBD/EOBD/OBDII";
								return value2;
						}
						return value2;

					case 0x1d:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num3 = HexByteToInt(response.getDataByte(0));
							switch (param.SubParameter)
							{
								case 0:
									if ((num3 & 1) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 1:
									if ((num3 & 2) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 2:
									if ((num3 & 4) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 3:
									if ((num3 & 8) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 4:
									if ((num3 & 0x10) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 5:
									if ((num3 & 0x20) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 6:
									if ((num3 & 0x40) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;

								case 7:
									if ((num3 & 0x80) == 0)
									{
										value2.BoolValue = false;
										value2.DoubleValue = 0.0;
										value2.StringValue = "NO";
										value2.ShortStringValue = "NO";
										return value2;
									}
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
							}
							goto Label_20B7;
						}
					case 30:
						goto Label_20B7;

					case 0x1f:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num58 = HexByteToInt(response.getDataByte(0));
							double num57 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (num58 * 256.0) + num57;
							return value2;
						}
					case 0x21:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num56 = HexByteToInt(response.getDataByte(0));
							double num55 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (num56 * 256.0) + num55;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.621371192;
							}
							return value2;
						}
					case 0x22:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num54 = HexByteToInt(response.getDataByte(0));
							double num53 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (((num54 * 256.0) + num53) * 10.0) * 0.0078125;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.145037738;
							}
							return value2;
						}
					case 0x23:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num52 = HexByteToInt(response.getDataByte(0));
							double num51 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (((num52 * 256.0) + num51) * 10.0) * 0.0078125;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.145037738;
							}
							return value2;
						}
					case 0x24:
					case 0x25:
					case 0x26:
					case 0x27:
					case 40:
					case 0x29:
					case 0x2a:
					case 0x2b:
						{
							if (response.getDataByteCount() < 4)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							if (param.SubParameter == 0)
							{
								double num50 = HexByteToInt(response.getDataByte(0));
								double num49 = HexByteToInt(response.getDataByte(1));
								value2.DoubleValue = ((num50 * 256.0) + num49) * 3.0517578125E-05;
								return value2;
							}
							double num48 = HexByteToInt(response.getDataByte(2));
							double num47 = HexByteToInt(response.getDataByte(3));
							value2.DoubleValue = ((num48 * 256.0) + num47) * 0.0001220703125;
							return value2;
						}
					case 0x2c:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num46 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num46 * 100.0) * 0.00392156862745098;
							return value2;
						}
					case 0x2d:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num45 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num45 - 128.0) * 0.78125;
							return value2;
						}
					case 0x2e:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num44 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num44 * 100.0) * 0.00392156862745098;
							return value2;
						}
					case 0x2f:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num43 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num43 * 100.0) * 0.00392156862745098;
							return value2;
						}
					case 0x30:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num42 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = num42;
							return value2;
						}
					case 0x31:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num41 = HexByteToInt(response.getDataByte(0));
							double num40 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (num41 * 256.0) + num40;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.621371192;
							}
							return value2;
						}
					case 50:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num11 = HexByteToInt(response.getDataByte(0));
							double num39 = HexByteToInt(response.getDataByte(1));
							if (num11 > 127.0)
							{
								num11 = (num11 - 128.0) * -1.0;
							}
							value2.DoubleValue = ((num11 * 256.0) + num39) * 0.25;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.000145037738;
							}
							return value2;
						}
					case 0x33:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num38 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = num38;
							if (bEnglishUnits)
							{
								value2.DoubleValue *= 0.145037738;
							}
							return value2;
						}
					case 0x34:
					case 0x35:
					case 0x36:
					case 0x37:
					case 0x38:
					case 0x39:
					case 0x3a:
					case 0x3b:
						{
							if (response.getDataByteCount() < 4)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							if (param.SubParameter == 0)
							{
								double num37 = HexByteToInt(response.getDataByte(0));
								double num36 = HexByteToInt(response.getDataByte(1));
								value2.DoubleValue = ((num37 * 256.0) + num36) * 3.0517578125E-05;
								return value2;
							}
							double num35 = HexByteToInt(response.getDataByte(2));
							double num34 = HexByteToInt(response.getDataByte(3));
							value2.DoubleValue = (((num35 * 256.0) + num34) * 0.00390625) - 128.0;
							return value2;
						}
					case 60:
					case 0x3d:
					case 0x3e:
					case 0x3f:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num33 = HexByteToInt(response.getDataByte(0));
							double num32 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (((num33 * 256.0) + num32) * 0.1) - 40.0;
							if (bEnglishUnits)
							{
								value2.DoubleValue = (value2.DoubleValue * 1.8) + 32.0;
							}
							return value2;
						}
					case 0x41:
						if (response.getDataByteCount() < 4)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						switch (param.SubParameter)
						{
							case 0:
								if ((HexByteToInt(response.getDataByte(1)) & 1) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 1:
								if ((HexByteToInt(response.getDataByte(1)) & 2) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 2:
								if ((HexByteToInt(response.getDataByte(1)) & 4) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 3:
								if ((HexByteToInt(response.getDataByte(1)) & 0x10) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 4:
								if ((HexByteToInt(response.getDataByte(1)) & 0x20) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 5:
								if ((HexByteToInt(response.getDataByte(1)) & 0x40) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 6:
								if ((HexByteToInt(response.getDataByte(2)) & 1) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 7:
								if ((HexByteToInt(response.getDataByte(2)) & 2) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 8:
								if ((HexByteToInt(response.getDataByte(2)) & 4) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 9:
								if ((HexByteToInt(response.getDataByte(2)) & 8) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 10:
								if ((HexByteToInt(response.getDataByte(2)) & 0x10) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 11:
								if ((HexByteToInt(response.getDataByte(2)) & 0x20) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 12:
								if ((HexByteToInt(response.getDataByte(2)) & 0x40) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 13:
								if ((HexByteToInt(response.getDataByte(2)) & 0x80) == 0)
								{
									value2.BoolValue = false;
									value2.DoubleValue = 0.0;
									value2.StringValue = "NO";
									value2.ShortStringValue = "NO";
									return value2;
								}
								value2.BoolValue = true;
								value2.DoubleValue = 1.0;
								value2.StringValue = "YES";
								value2.ShortStringValue = "YES";
								return value2;

							case 14:
								if ((HexByteToInt(response.getDataByte(3)) & 1) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 15:
								if ((HexByteToInt(response.getDataByte(3)) & 2) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 0x10:
								if ((HexByteToInt(response.getDataByte(3)) & 4) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 0x11:
								if ((HexByteToInt(response.getDataByte(3)) & 8) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 0x12:
								if ((HexByteToInt(response.getDataByte(3)) & 0x10) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 0x13:
								if ((HexByteToInt(response.getDataByte(3)) & 0x20) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 20:
								if ((HexByteToInt(response.getDataByte(3)) & 0x40) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;

							case 0x15:
								if ((HexByteToInt(response.getDataByte(3)) & 0x80) == 0)
								{
									value2.BoolValue = true;
									value2.DoubleValue = 1.0;
									value2.StringValue = "YES";
									value2.ShortStringValue = "YES";
									return value2;
								}
								value2.BoolValue = false;
								value2.DoubleValue = 0.0;
								value2.StringValue = "NO";
								value2.ShortStringValue = "NO";
								return value2;
						}
						goto Label_32A8;

					case 0x42:
						goto Label_32A8;

					case 0x43:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num29 = HexByteToInt(response.getDataByte(0));
							double num28 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = ((num29 * 256.0) + num28) * 0.39215686274509803;
							return value2;
						}
					case 0x44:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num27 = HexByteToInt(response.getDataByte(0));
							double num26 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = ((num27 * 256.0) + num26) * 3.0517578125E-05;
							return value2;
						}
					case 0x45:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num25 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num25 * 100.0) * 0.00392156862745098;
							return value2;
						}
					case 70:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num24 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = num24 - 40.0;
							if (bEnglishUnits)
							{
								value2.DoubleValue = (value2.DoubleValue * 1.8) + 32.0;
							}
							return value2;
						}
					case 0x47:
					case 0x48:
					case 0x49:
					case 0x4a:
					case 0x4b:
					case 0x4c:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num23 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num23 * 100.0) * 0.00392156862745098;
							return value2;
						}
					case 0x4d:
					case 0x4e:
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num22 = HexByteToInt(response.getDataByte(0));
							double num21 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = (num22 * 256.0) + num21;
							return value2;
						}
					case 0x51:
						if (response.getDataByteCount() < 1)
						{
							value2.ErrorDetected = true;
							return value2;
						}
						switch (HexByteToInt(response.getDataByte(0)))
						{
							case 1:
								value2.StringValue = "Gasoline";
								break;

							case 2:
								value2.StringValue = "Methanol";
								break;

							case 3:
								value2.StringValue = "Ethanol";
								break;

							case 4:
								value2.StringValue = "Diesel";
								break;

							case 5:
								value2.StringValue = "LPG";
								break;

							case 6:
								value2.StringValue = "CNG";
								break;

							case 7:
								value2.StringValue = "Propane";
								break;

							case 8:
								value2.StringValue = "Electric";
								break;

							case 9:
								value2.StringValue = "Bifuel running Gasoline";
								break;

							case 10:
								value2.StringValue = "Bifuel running Methanol";
								break;

							case 11:
								value2.StringValue = "Bifuel running Ethanol";
								break;

							case 12:
								value2.StringValue = "Bifuel running LPG";
								break;

							case 13:
								value2.StringValue = "Bifuel running CNG";
								break;

							case 14:
								value2.StringValue = "Bifuel running Propane";
								break;

							case 15:
								value2.StringValue = "Bifuel running Electric";
								break;

							case 16:
								value2.StringValue = "Bifuel mixed Gas/Electric";
								break;

							case 17:
								value2.StringValue = "Hybrid Gasoline";
								break;

							case 18:
								value2.StringValue = "Hybrid Ethanol";
								break;

							case 19:
								value2.StringValue = "Hybrid Diesel";
								break;

							case 20:
								value2.StringValue = "Hybrid Electric";
								break;

							case 21:
								value2.StringValue = "Hybrid Mixed Fuel";
								break;

							case 22:
								value2.StringValue = "Hybrid Regenerative";
								break;
						}
						value2.ShortStringValue = value2.StringValue;
						return value2;

					case 0x52:
						{
							if (response.getDataByteCount() < 1)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							double num20 = HexByteToInt(response.getDataByte(0));
							value2.DoubleValue = (num20 * 100.0) * 0.00392156862745098;
							return value2;
						}
				}
				goto Label_379A;

			case 3:
			case 7:
			case 10:
				goto Label_379A;

			case 5:
				{
					int parameter = param.Parameter;
					if ((parameter <= 0) || (parameter > 10))
					{
						goto Label_38E3;
					}
					if (param.SubParameter != 0)
					{
						if (param.SubParameter == 1)
						{
							if (response.getDataByteCount() < 2)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num18 = HexByteToInt(response.getDataByte(1));
							value2.DoubleValue = num18 * 0.005;
							return value2;
						}
						if (param.SubParameter == 2)
						{
							if (response.getDataByteCount() < 3)
							{
								value2.ErrorDetected = true;
								return value2;
							}
							int num17 = HexByteToInt(response.getDataByte(2));
							value2.DoubleValue = num17 * 0.005;
							return value2;
						}
						value2.ErrorDetected = true;
						return value2;
					}
					if (response.getDataByteCount() >= 1)
					{
						int num19 = HexByteToInt(response.getDataByte(0));
						value2.DoubleValue = num19 * 0.005;
						return value2;
					}
					value2.ErrorDetected = true;
					return value2;
				}
			case 9:
				goto Label_38E3;
		}
		goto Label_390C;

	Label_10DD:
		if (response.getDataByteCount() < 2)
		{
			value2.ErrorDetected = true;
			return value2;
		}
		value2.StringValue = OBD2.getDTCName(response.Data);
		return value2;

	Label_1A00:
		if (response.getDataByteCount() < 2)
		{
			value2.ErrorDetected = true;
			return value2;
		}
		if (param.SubParameter == 0)
		{
			double num59 = HexByteToInt(response.getDataByte(0));
			value2.DoubleValue = num59 * 0.005;
			return value2;
		}
		double num15 = HexByteToInt(response.getDataByte(1));
		if (num15 == 255.0)
		{
			value2.DoubleValue = 0.0;
			return value2;
		}
		value2.DoubleValue = (num15 - 128.0) * 0.78125;
		return value2;
	Label_20B7:
		if (response.getDataByteCount() < 1)
		{
			value2.ErrorDetected = true;
			return value2;
		}
		if ((HexByteToInt(response.getDataByte(0)) & 1) != 0)
		{
			value2.DoubleValue = 1.0;
			value2.BoolValue = true;
			value2.StringValue = "ON";
			value2.ShortStringValue = "ON";
			return value2;
		}
		value2.DoubleValue = 0.0;
		value2.BoolValue = false;
		value2.StringValue = "OFF";
		value2.ShortStringValue = "OFF";
		return value2;
	Label_32A8:
		if (response.getDataByteCount() < 2)
		{
			value2.ErrorDetected = true;
			return value2;
		}
		double num31 = HexByteToInt(response.getDataByte(0));
		double num30 = HexByteToInt(response.getDataByte(1));
		value2.DoubleValue = ((num31 * 256.0) + num30) * 0.001;
		return value2;
	Label_379A:
		strings = new StringCollection();
		int startIndex = 0;
		if (4 <= response.Data.Length)
		{
			do
			{
				string str = OBD2.getDTCName(response.Data.Substring(startIndex, 4));
				if (str.CompareTo("P0000") != 0)
				{
					strings.Add(str);
				}
				startIndex += 4;
			}
			while ((startIndex + 4) <= response.Data.Length);
		}
		value2.StringCollectionValue = strings;
		return value2;
	Label_38E3:
		if (param.Parameter == 2)
		{
			value2.StringValue = HexStringToASCIIString(response.Data);
			value2.ShortStringValue = value2.StringValue;
			return value2;
		}
	Label_390C:
		value2.ErrorDetected = true;
		return value2;
	}


	public static OBDParameterValue getValue(OBDParameter param, OBDResponseList responses, bool bEnglishUnits)
	{
		if (responses.ResponseCount == 1)
		{
			return getValue(param, responses.GetOBDResponse(0), bEnglishUnits);
		}
		if ((param.Service == 1) || (param.Service == 2))
		{
			if (((param.Parameter == 0) || (param.Parameter == 0x20)) || ((param.Parameter == 0x40) || (param.Parameter == 0x60)))
			{
				OBDParameterValue value7 = new OBDParameterValue();
				int num2 = 0;
				if (0 < responses.ResponseCount)
				{
					do
					{
						OBDParameterValue value4 = getValue(param, responses.GetOBDResponse(num2), bEnglishUnits);
						if (value4.ErrorDetected)
						{
							return value4;
						}
						int num = 0;
						do
						{
							if (value4.getBitFlag(num))
							{
								value7.setBitFlag(num, true);
							}
							num++;
						}
						while (num < 0x20);
						num2++;
					}
					while (num2 < responses.ResponseCount);
				}
				return value7;
			}
			if ((param.Parameter == 1) && (param.SubParameter == 0))
			{
				OBDParameterValue value2 = new OBDParameterValue();
				value2.BoolValue = false;
				int num5 = 0;
				if (0 < responses.ResponseCount)
				{
					do
					{
						OBDParameterValue value6 = getValue(param, responses.GetOBDResponse(num5), bEnglishUnits);
						if (value6.ErrorDetected)
						{
							return value6;
						}
						if (value6.BoolValue)
						{
							value2.BoolValue = true;
						}
						num5++;
					}
					while (num5 < responses.ResponseCount);
				}
				if (value2.BoolValue)
				{
					value2.DoubleValue = 1.0;
					value2.StringValue = "ON";
					value2.ShortStringValue = "ON";
					return value2;
				}
				value2.DoubleValue = 0.0;
				value2.StringValue = "OFF";
				value2.ShortStringValue = "OFF";
				return value2;
			}
			if ((param.Parameter == 1) && (param.SubParameter == 1))
			{
				OBDParameterValue value3 = new OBDParameterValue();
				value3.DoubleValue = 0.0;
				int num4 = 0;
				if (0 < responses.ResponseCount)
				{
					do
					{
						OBDParameterValue value5 = getValue(param, responses.GetOBDResponse(num4), bEnglishUnits);
						if (value5.ErrorDetected)
						{
							return value5;
						}
						value3.DoubleValue = value5.DoubleValue + value3.DoubleValue;
						num4++;
					}
					while (num4 < responses.ResponseCount);
				}
				return value3;
			}
		}
		if ((param.Service != 3) && (param.Service != 7))
		{
			return getValue(param, responses.GetOBDResponse(0), bEnglishUnits);
		}
		OBDParameterValue value8 = new OBDParameterValue();
		StringCollection strings = new StringCollection();
		int index = 0;
		if (0 < responses.ResponseCount)
		{
			do
			{
				StringEnumerator enumerator = getValue(param, responses.GetOBDResponse(index), bEnglishUnits).StringCollectionValue.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						strings.Add(enumerator.Current);
					}
					while (enumerator.MoveNext());
				}
				index++;
			}
			while (index < responses.ResponseCount);
		}
		value8.StringCollectionValue = strings;
		return value8;
	}

}