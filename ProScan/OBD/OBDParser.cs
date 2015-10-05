using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProScan
{
	public abstract class OBDParser
	{
		public abstract OBDResponseList Parse(OBDParameter param, string response);

		protected string Strip(string input)
		{
			if (input == null)
				return "";
			else
				return input
					.Replace("BUS", "")
					.Replace("INIT", "")
					.Replace("DONE", "")
					.Replace("SEARCHING", "")
					.Replace(":", "")
					.Replace(".", "")
					.Replace(" ", "")
					.Trim();
		}

		private static char[] CHAR_CR = new char[] { '\r' };
		protected List<string> SplitByCR(string input)
		{
			string[] lines = (input ?? string.Empty).Split(CHAR_CR);
			List<string> list = new List<string>(lines.Length);
			list.AddRange(lines);
			return list;
		}


		protected bool ErrorCheck(string input)
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
	}
}