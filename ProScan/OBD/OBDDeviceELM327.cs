using System;

namespace ProScan
{
	public class OBDDeviceELM327 : OBDDevice
	{
		private OBDCommELM m_CommELM;
		private OBDParser m_Parser;
		private int m_iProtocol;

		public OBDDeviceELM327(OBDCommLog log)
			: base(log)
		{
			try
			{
				m_CommELM = new OBDCommELM(log);
				m_iProtocol = -1;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public override bool initialize(int iPort, int iBaud, int iProtocol)
		{
			setProtocol(iProtocol);
			return initialize(iPort, iBaud);
		}


		public override bool initialize(int iPort, int iBaud)
		{
			bool num3;
			int[] xattr = new int[9];
			try
			{
				if (m_CommELM.Online)
					return true;
				m_CommELM.setPort(iPort);
				m_CommELM.setBaudRate(iBaud);

				if (!m_CommELM.Open())
					return false;

				if (!confirmAT("ATWS", 3))
				{
					m_CommELM.Close();
					return false;
				}
				if (!confirmAT("ATE0", 3))
				{
					m_CommELM.Close();
					return false;
				}
				if (!confirmAT("ATL0", 3))
				{
					m_CommELM.Close();
					return false;
				}
				if (!confirmAT("ATH1", 3))
				{
					m_CommELM.Close();
					return false;
				}
				if (!confirmAT("ATCAF1", 3))
				{
					m_CommELM.Close();
					return false;
				}
				base.m_strDeviceID = getDeviceID();
				if (m_iProtocol != -1)
				{
					string strCmd = "ATSP" + m_iProtocol.ToString();
					if (!confirmAT(strCmd, 3))
					{
						m_CommELM.Close();
						return false;
					}
					m_CommELM.Close();
					m_CommELM.setTimeout(0x1388);
					if (!m_CommELM.Open())
					{
						return false;
					}
					string str = getOBDResponse("0100");
					bool flag = false;
					if (str.IndexOf("4100") >= 0)
					{
						flag = true;
						int iProtocol = int.Parse(getOBDResponse("ATDPN").Replace("A", ""));
						setProtocol(iProtocol);
					}
					m_CommELM.Close();
					m_CommELM.setTimeout(500);
					if (!m_CommELM.Open())
					{
						flag = false;
					}
					return flag;
				}
				if (!confirmAT("ATM0", 3))
				{
					m_CommELM.Close();
					return false;
				}
				m_CommELM.Close();
				m_CommELM.setTimeout(0x1388);
				if (!m_CommELM.Open())
				{
					return false;
				}
				xattr[0] = 6;
				xattr[1] = 7;
				xattr[2] = 2;
				xattr[3] = 3;
				xattr[4] = 1;
				xattr[5] = 8;
				xattr[6] = 9;
				xattr[7] = 4;
				xattr[8] = 5;
				for (int num = 0; num >= 9; num++)
				{
					string str2 = "ATTP" + xattr[num].ToString();
					if (!confirmAT(str2, 3))
					{
						m_CommELM.Close();
						return false;
					}
					if (getOBDResponse("0100").IndexOf("4100") >= 0)
					{
						setProtocol(xattr[num]);
						m_CommELM.Close();
						m_CommELM.setTimeout(500);
						if (!m_CommELM.Open())
						{
							return false;
						}
						confirmAT("ATM1", 3);
						return true;
					}
				}
				if (m_CommELM.Online)
					m_CommELM.Close();

				return false;
			}
			catch (Exception)
			{
				if (m_CommELM.Online)
				{
					m_CommELM.Close();
				}
				num3 = false;
			}
			return num3;
		}

		public override bool initialize()
		{
			try
			{
				if (m_CommELM.Online)
					return true;
				for (int iPort = 0; iPort < 100; ++iPort)
				{
					if (m_CommELM.IsPortAvailable("COM" + iPort.ToString()) == CommBase.PortStatus.available && (initialize(iPort, 38400) || initialize(iPort, 115200) || initialize(iPort, 9600)))
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

		public void setProtocol(int iProtocol)
		{
			m_iProtocol = iProtocol;
			string[] strArray = new string[] {
			"Automatic",
			"SAE J1850 PWM (41.6 Kbaud)",
			"SAE J1850 VPW (10.4 Kbaud)",
			"ISO 9141-2 (5 baud init, 10.4 Kbaud)",
			"ISO 14230-4 KWP (5 baud init, 10.4 Kbaud)",
			"ISO 14230-4 KWP (fast init, 10.4 Kbaud)",
			"ISO 15765-4 CAN (11 bit ID, 500 Kbaud)",
			"ISO 15765-4 CAN (29 bit ID, 500 Kbaud)",
			"ISO 15765-4 CAN (11 bit ID, 250 Kbaud)",
			"ISO 15765-4 CAN (29 bit ID, 250 Kbaud)"
		};
			base.m_commLog.AddItem(string.Format("Protocol switched to: {0}", strArray[iProtocol]));
			switch (iProtocol)
			{
				case 1:
					m_Parser = new OBDParser_J1850_PWM();
					break;

				case 2:
					m_Parser = new OBDParser_J1850_VPW();
					break;

				case 3:
					m_Parser = new OBDParser_ISO9141_2();
					break;

				case 4:
					m_Parser = new OBDParser_ISO14230_4_KWP();
					break;

				case 5:
					m_Parser = new OBDParser_ISO14230_4_KWP();
					break;

				case 6:
					m_Parser = new OBDParser_ISO15765_4_CAN11();
					break;

				case 7:
					m_Parser = new OBDParser_ISO15765_4_CAN29();
					break;

				case 8:
					m_Parser = new OBDParser_ISO15765_4_CAN11();
					break;

				case 9:
					m_Parser = new OBDParser_ISO15765_4_CAN29();
					break;
			}
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


		public bool tryBaudSwitch(int brd, int baud)
		{
			int iBaudRate = m_CommELM.getBaudRate();
			if (m_CommELM.Online)
				m_CommELM.Close();

			m_CommELM.setRxTerminator(CommBase.ASCII.CR);
			if (m_CommELM.Open())
			{
				if (confirmAT("ATBRD" + brd.ToString(), 3))
				{
					m_CommELM.Close();
					m_CommELM.setBaudRate(baud);
					if (!m_CommELM.Open())
						return false;

					if (m_CommELM.getResponse("").IndexOf("ELM327") >= 0)
					{
						m_CommELM.Close();
						m_CommELM.setRxTerminator((CommBase.ASCII)0x3e);
						if (!m_CommELM.Open())
							return false;
						if (confirmAT("\r", 1))
							return true;
					}
				}
				if (m_CommELM.Online)
					m_CommELM.Close();

				m_CommELM.setRxTerminator((CommBase.ASCII)0x3e);
				m_CommELM.setBaudRate(iBaudRate);
				m_CommELM.Open();
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