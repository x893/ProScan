using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ProScan
{
	public class OBD2Comm : CommLine
	{
		public delegate void __Delegate_OnReceived(string msg);
		public event OBD2Comm.__Delegate_OnReceived OnReceived;

		private static string m_strPort;
		private static int m_iBaudRate;

		static OBD2Comm()
		{
			m_strPort = "COM1:";
			m_iBaudRate = 38400;
		}

		public OBD2Comm()
		{
		}

		public void setPort(int iPort)
		{
			m_strPort = "COM" + iPort.ToString();
		}

		public void setBaudRate(int iBaudRate)
		{
			m_iBaudRate = iBaudRate;
		}

		public string getResponse(string strCmd)
		{
			try
			{
				return Transact(strCmd);
			}
			catch (Exception ex)
			{
				if (string.Compare(ex.Message, "Timeout") == 0)
					Open();
				return "";
			}
		}

		public void sendRequest(string strCmd)
		{
			Send(strCmd);
		}

		protected override void OnRxLine(string strMsg)
		{
			Debug.Write("RECEIVED: ");
			Debug.WriteLine(strMsg);
			OnReceived(strMsg);
		}

		protected override CommBase.CommBaseSettings CommSettings()
		{
			CommLine.CommLineSettings s = new CommLine.CommLineSettings();
			s.SetStandard(m_strPort, m_iBaudRate, CommBase.Handshake.none);
			s.rxTerminator = (CommBase.ASCII)0x3e;
			s.rxFilter = new ASCII[] { ASCII.LF, ASCII.SP, (ASCII)0x3e };
			s.txTerminator = new ASCII[] { ASCII.CR };
			s.transactTimeout = 15000;
			base.Setup(s);
			return s;
		}
	}
}