using System;

namespace ProScan
{
	public class OBDCommELM : CommLine
	{
		protected static string m_strPort = "COM1:";
		protected static int m_iBaudRate = 38400;
		protected static int m_iTimeout = 300;
		protected static CommBase.ASCII m_asciiRxTerm = (CommBase.ASCII)62;
		protected OBDCommLog m_commLog;

		static OBDCommELM()
		{
		}

		public OBDCommELM(OBDCommLog log)
		{
			m_commLog = log;
		}

		public OBDCommELM()
		{
		}

		public void setPort(int iPort)
		{
			m_strPort = "COM" + iPort.ToString() + ":";
			m_commLog.AddItem(string.Format("Port set to {0}", m_strPort));
		}

		public void setBaudRate(int iBaudRate)
		{
			OBDCommELM.m_iBaudRate = iBaudRate;
			m_commLog.AddItem(string.Format("Baud rate set to {0}", m_iBaudRate.ToString()));
		}


		public int getBaudRate()
		{
			return OBDCommELM.m_iBaudRate;
		}

		public void setTimeout(int iTimeout)
		{
			m_iTimeout = iTimeout;
			m_commLog.AddItem(string.Format("Timeout set to {0} ms", m_iTimeout.ToString()));
		}

		public void setRxTerminator(CommBase.ASCII chr)
		{
			OBDCommELM.m_asciiRxTerm = chr;
		}

		public string getResponse(string strCmd)
		{
			string str;
			try
			{
				m_commLog.AddItem(string.Format("TX: {0}", strCmd));
				str = Transact(strCmd);
				m_commLog.AddItem(string.Format("RX: {0}", str.Replace("\r", @"\r")));
			}
			catch (Exception ex)
			{
				m_commLog.AddItem(ex.Message);
				if (string.Compare(ex.Message, "Timeout") == 0)
					Open();
				m_commLog.AddItem("RX: COMM TIMED OUT!");
				str = "TIMEOUT";
			}
			return str;
		}

		protected override CommBaseSettings CommSettings()
		{
			CommLine.CommLineSettings s = new CommLine.CommLineSettings();
			s.SetStandard(m_strPort, m_iBaudRate, Handshake.none);
			s.rxTerminator = m_asciiRxTerm;
			s.rxFilter = new ASCII[] { ASCII.LF, ASCII.SP, (ASCII)0x3e, ASCII.NULL };
			s.txTerminator = new ASCII[] { ASCII.CR };
			s.transactTimeout = m_iTimeout;
			base.Setup(s);
			return s;
		}
	}
}