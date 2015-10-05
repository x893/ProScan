using System;
namespace ProScan
{
	public class OBDDeviceELM322 : OBDDevice
	{
		public OBDDeviceELM322(OBDCommLog log)
			: base(log)
		{
			try
			{
				m_Parser = new OBDParser_J1850_VPW();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool Initialize(int iPort, int iBaud, ProtocolType iProtocol)
		{
			return Initialize(iPort, iBaud);
		}

		public override bool Initialize(int iPort, int iBaud)
		{
			try
			{
				if (m_CommELM.Online)
					return true;
				m_CommELM.setPort(iPort);
				m_CommELM.setBaudRate(iBaud);
				if (m_CommELM.Open())
				{
					if (confirmAT("ATZ")
					&& confirmAT("ATE0")
					&& confirmAT("ATL0")
					&& confirmAT("ATH1")
						)
					{
						m_DeviceID = getDeviceID();
						return true;
					}
					m_CommELM.Close();
				}
			}
			catch { }
			return false;
		}


		public override bool Initialize()
		{
			try
			{
				if (m_CommELM.Online)
					return true;
				for (int iPort = 0; iPort < 100; ++iPort)
					if (CommBase.IsPortAvailable(iPort) == CommBase.PortStatus.Available
					&& (Initialize(iPort, 38400) || Initialize(iPort, 115200) || Initialize(iPort, 9600))
						)
						return true;
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public override OBDResponseList Query(OBDParameter param)
		{
			return m_Parser.Parse(param, getOBDResponse(param.OBDRequest));
		}

		public override string Query(string command)
		{
			if (m_CommELM.Online)
				return m_CommELM.getResponse(command);
			return "";
		}

		public override void Disconnect()
		{
			if (m_CommELM.Online)
				m_CommELM.Close();
		}

		public override bool Connected()
		{
			return m_CommELM.Online;
		}

		public bool confirmAT(string command)
		{
			return confirmAT(command, 3);
		}
		public bool confirmAT(string command, int attempts)
		{
			if (!m_CommELM.Online)
				return false;
			while (attempts > 0)
			{
				string response = m_CommELM.getResponse(command);
				if (response.IndexOf("OK") >= 0 || response.IndexOf("ELM") >= 0)
					return true;
				--attempts;
			}
			return false;
		}

		public string getOBDResponse(string command)
		{
			if (m_CommELM.Online)
				return m_CommELM.getResponse(command);
			return "";
		}

		public string getDeviceID()
		{
			if (m_CommELM.Online)
				return m_CommELM.getResponse("ATI");
			return "";
		}
	}
}
