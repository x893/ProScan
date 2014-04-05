using System;

public class OBD2
{
  public static int HexString2Int(string strHex)
  {
    int num1 = 0;
    int num2 = strHex.Length - 1;
    int startIndex = num2;
    if (num2 >= 0)
    {
      int num3 = 0;
      do
      {
        string strDigit = strHex.Substring(startIndex, 1).ToUpper();
        num1 = (int) Math.Pow(16.0, (double) num3) * OBD2.Hex2Int(strDigit) + num1;
        --startIndex;
        ++num3;
      }
      while (startIndex >= 0);
    }
    return num1;
  }

  public static int Hex2Int(string strDigit)
  {
    if (string.Compare(strDigit, "F") == 0)
      return 15;
    if (string.Compare(strDigit, "E") == 0)
      return 14;
    if (string.Compare(strDigit, "D") == 0)
      return 13;
    if (string.Compare(strDigit, "C") == 0)
      return 12;
    if (string.Compare(strDigit, "B") == 0)
      return 11;
    if (string.Compare(strDigit, "A") == 0)
      return 10;
    if (string.Compare(strDigit, "9") == 0)
      return 9;
    if (string.Compare(strDigit, "8") == 0)
      return 8;
    if (string.Compare(strDigit, "7") == 0)
      return 7;
    if (string.Compare(strDigit, "6") == 0)
      return 6;
    if (string.Compare(strDigit, "5") == 0)
      return 5;
    if (string.Compare(strDigit, "4") == 0)
      return 4;
    if (string.Compare(strDigit, "3") == 0)
      return 3;
    if (string.Compare(strDigit, "2") == 0)
      return 2;
    if (string.Compare(strDigit, "1") == 0)
      return 1;
    int num = 0;
    if (string.Compare(strDigit, "0") == 0)
      return num;
    else
      return ~num;
  }

  public static string Int2HexString(int iValue)
  {
    if (iValue < 0 || iValue > (int) byte.MaxValue)
      return "";
    if (iValue < 16)
      return "0" + OBD2.Int2Hex(iValue);
    else
      return OBD2.Int2Hex(iValue / 16) + OBD2.Int2Hex(iValue % 16);
  }

  public static string Int2Hex(int iValue)
  {
    switch (iValue)
    {
      case 0:
        return "0";
      case 1:
        return "1";
      case 2:
        return "2";
      case 3:
        return "3";
      case 4:
        return "4";
      case 5:
        return "5";
      case 6:
        return "6";
      case 7:
        return "7";
      case 8:
        return "8";
      case 9:
        return "9";
      case 10:
        return "A";
      case 11:
        return "B";
      case 12:
        return "C";
      case 13:
        return "D";
      case 14:
        return "E";
      case 15:
        return "F";
      default:
        return "X";
    }
  }

  public static string getRequest(int iService, int iPID)
  {
    return OBD2.Int2HexString(iService) + OBD2.Int2HexString(iPID);
  }

  public static string getDTCName(string strHexDTC)
  {
    if (strHexDTC.Length != 4)
      return "P0000";
    else
      return OBD2.getDTCSystem(strHexDTC.Substring(0, 1)) + strHexDTC.Substring(1, 3);
  }

  private static string getDTCSystem(string strSysId)
  {
    if (string.Compare(strSysId, "0") == 0)
      return "P0";
    if (string.Compare(strSysId, "1") == 0)
      return "P1";
    if (string.Compare(strSysId, "2") == 0)
      return "P2";
    if (string.Compare(strSysId, "3") == 0)
      return "P3";
    if (string.Compare(strSysId, "4") == 0)
      return "C0";
    if (string.Compare(strSysId, "5") == 0)
      return "C1";
    if (string.Compare(strSysId, "6") == 0)
      return "C2";
    if (string.Compare(strSysId, "7") == 0)
      return "C3";
    if (string.Compare(strSysId, "8") == 0)
      return "B0";
    if (string.Compare(strSysId, "9") == 0)
      return "B1";
    if (string.Compare(strSysId, "A") == 0)
      return "B2";
    if (string.Compare(strSysId, "B") == 0)
      return "B3";
    if (string.Compare(strSysId, "C") == 0)
      return "U0";
    if (string.Compare(strSysId, "D") == 0)
      return "U1";
    if (string.Compare(strSysId, "E") == 0)
      return "U2";
    return string.Compare(strSysId, "F") == 0 ? "U3" : "ER";
  }
}
