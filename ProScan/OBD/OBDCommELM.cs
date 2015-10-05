using System;

namespace ProScan
{
	public class OBDCommELM : CommLine
	{
		protected string m_Port = "COM1:";
		protected int m_BaudRate = 38400;
		protected int m_Timeout = 300;
		protected CommBase.ASCII m_asciiRxTerm = (CommBase.ASCII)62;

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
			m_Port = "COM" + iPort.ToString() + ":";
			m_commLog.AddItem(string.Format("Port set to {0}", m_Port));
		}

		public void setBaudRate(int iBaudRate)
		{
			m_BaudRate = iBaudRate;
			m_commLog.AddItem(string.Format("Baud rate set to {0}", m_BaudRate.ToString()));
		}


		public int getBaudRate()
		{
			return m_BaudRate;
		}

		public void setTimeout(int iTimeout)
		{
			m_Timeout = iTimeout;
			m_commLog.AddItem(string.Format("Timeout set to {0} ms", m_Timeout.ToString()));
		}

		public void setRxTerminator(CommBase.ASCII ch)
		{
			m_asciiRxTerm = ch;
		}

		public string getResponse(string command)
		{
			string response;
			try
			{
				m_commLog.AddItem(string.Format("TX: {0}", command));
				response = Transact(command);
				m_commLog.AddItem(string.Format("RX: {0}", response.Replace("\r", @"\r")));
			}
			catch (Exception ex)
			{
				m_commLog.AddItem(ex.Message);
				if (string.Compare(ex.Message, "Timeout") == 0)
					Open();
				m_commLog.AddItem("RX: COMM TIMED OUT!");
				response = "TIMEOUT";
			}
			return response;
		}

		protected override CommBaseSettings CommSettings()
		{
			CommLine.CommLineSettings settings = new CommLine.CommLineSettings();
			settings.SetStandard(m_Port, m_BaudRate, Handshake.None);
			settings.RxTerminator = m_asciiRxTerm;
			settings.RxFilter = new ASCII[] { ASCII.LF, ASCII.SP, ASCII.GT, ASCII.NULL };
			settings.TxTerminator = new ASCII[] { ASCII.CR };
			settings.TransactTimeout = m_Timeout;
			base.Setup(settings);
			return settings;
		}
	}
}