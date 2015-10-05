using System;

namespace ProScan
{
	public class CommPortException : ApplicationException
	{
		public CommPortException(string desc)
			: base(desc)
		{
		}

		public CommPortException(Exception e)
			: base("Receive Thread Exception", e)
		{
		}
	}
}
