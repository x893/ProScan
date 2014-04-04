using System;

namespace ProScan
{
	public class OBDDeviceELM320 : OBDDevice
	{
		private OBDCommELM m_CommELM;
		private OBDParser m_Parser;

		public OBDDeviceELM320(OBDCommLog log)
			: base(log)
		{
			try
			{
				m_CommELM = new OBDCommELM(log);
				m_Parser = (OBDParser)new OBDParser_J1850_PWM();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool initialize(int iPort, int iBaud, int iProtocol)
		{
			return initialize(iPort, iBaud);
		}


		public override bool initialize(int iPort, int iBaud)
		{
			try
			{
				if (m_CommELM.Online)
					return true;
				m_CommELM.setPort(iPort);
				m_CommELM.setBaudRate(iBaud);
				if (!m_CommELM.Open())
					return false;
				if (!confirmAT("ATZ", 3))
				{
					m_CommELM.Close();
					return false;
				}
				else if (!confirmAT("ATE0", 3))
				{
					m_CommELM.Close();
					return false;
				}
				else if (!confirmAT("ATL0", 3))
				{
					m_CommELM.Close();
					return false;
				}
				else if (!confirmAT("ATH1", 3))
				{
					m_CommELM.Close();
					return false;
				}
				else
				{
					m_strDeviceID = getDeviceID();
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}


		public override bool initialize()
		{
			try
			{
				if (m_CommELM.Online)
					return true;
				for (int iPort = 0; iPort < 100; ++iPort)
				{
					if (m_CommELM.IsPortAvailable("COM" + iPort.ToString()) == CommBase.PortStatus.available
						&& (initialize(iPort, 38400) || initialize(iPort, 115200) || initialize(iPort, 9600))
						)
						return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public override OBDResponseList query(OBDParameter param)
		{
			string obdResponse = getOBDResponse(param.OBDRequest);
			return m_Parser.parse(param, obdResponse);
		}

		public override string query(string cmd)
		{
			if (!m_CommELM.Online)
				return "";
			else
				return m_CommELM.getResponse(cmd);
		}

		public override void disconnect()
		{
			if (!m_CommELM.Online)
				return;
			m_CommELM.Close();
		}


		public override bool connected()
		{
			return m_CommELM.Online;
		}


		public bool confirmAT(string strCmd, int attempts)
		{
			if (!m_CommELM.Online)
				return false;
			int num = 0;
			if (0 < attempts)
			{
				do
				{
					string response = m_CommELM.getResponse(strCmd);
					if (response.IndexOf("OK") < 0 && response.IndexOf("ELM") < 0)
						++num;
					else
						return true;
				}
				while (num < attempts);
			}
			return false;
		}

		public string getOBDResponse(string strCmd)
		{
			if (!m_CommELM.Online)
				return "";
			else
				return m_CommELM.getResponse(strCmd);
		}

		public string getDeviceID()
		{
			if (!m_CommELM.Online)
				return "";
			return m_CommELM.getResponse("ATI");
		}
	}
}