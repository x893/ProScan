using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProScan
{
	public class OBD2Interface
	{
		public delegate void __Delegate_OnConnect();
		public delegate void __Delegate_OnDisconnect();
		public delegate void __Delegate_OnReceived(OBD2Response response);
		public delegate void __Delegate_OnSent(OBD2Request request);

		// Events
		public event __Delegate_OnConnect OnConnect;
		public event __Delegate_OnDisconnect OnDisconnect;
		public event __Delegate_OnReceived OnReceived;
		public event __Delegate_OnSent OnSent;


		private OBD2Comm m_obd2Comm;
		private CommLog m_commLog;
		private ArrayList m_arrayListPID;
		private ArrayList m_arrayListDTC;
		private bool[] m_bService01PIDSupport;
		private bool[] m_bService02PIDSupport;
		private bool[] m_bO2Locations;
		private UserPreferences m_userpreferences;
		private Preferences m_settings;
		private ArrayList m_listVehicleProfiles;
		private bool m_bConnected;
		private string m_strChipInfo;
		private string m_strElmTimeout;
		private int m_iProtocol;

		public bool Connected
		{
			get { return m_bConnected; }
			set
			{
				m_bConnected = value;
				if (m_bConnected)
					OnConnect();
				else
					OnDisconnect();
			}
		}

		public string ChipInfo
		{
			get
			{
				if (m_strChipInfo != null)
					return m_strChipInfo;
				else
					return "";
			}
			set { m_strChipInfo = value; }
		}

		public bool CommLogging
		{
			get
			{
				return m_commLog.CommLogging;
			}
			set
			{
				m_commLog.CommLogging = value;
			}
		}

		public bool ComPortOpen
		{
			get
			{
				return m_obd2Comm.Online;
			}
		}

		public OBD2Interface()
		{
			m_obd2Comm = new OBD2Comm();
			m_commLog = new CommLog();
			m_obd2Comm.OnReceived += new OBD2Comm.__Delegate_OnReceived(On_OBD2_Received);
			m_userpreferences = LoadUserPreferences();
			m_settings = LoadCommSettings();
			m_listVehicleProfiles = LoadVehicleProfiles();
			m_strElmTimeout = OBD2.Int2HexString(GetActiveProfile().ElmTimeout / 4);
			m_arrayListPID = new ArrayList();
			m_arrayListDTC = new ArrayList();
			bool[] flagArray1 = new bool[256];
			flagArray1.Initialize();
			m_bService01PIDSupport = flagArray1;
			int index1 = 0;
			do
			{
				m_bService01PIDSupport[index1] = false;
				++index1;
			}
			while (index1 < 256);
			bool[] flagArray2 = new bool[256];
			flagArray2.Initialize();
			m_bService02PIDSupport = flagArray2;
			int index2 = 0;
			do
			{
				m_bService02PIDSupport[index2] = false;
				++index2;
			}
			while (index2 < 256);
			bool[] flagArray3 = new bool[8];
			flagArray3.Initialize();
			m_bO2Locations = flagArray3;
			int index3 = 0;
			do
			{
				m_bO2Locations[index3] = false;
				++index3;
			}
			while (index3 < 8);
		}

		public UserPreferences GetUserPreferences()
		{
			return m_userpreferences;
		}

		public Preferences GetCommSettings()
		{
			return m_settings;
		}

		public void SaveCommSettings(Preferences settings)
		{
			m_settings = settings;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Preferences));
			TextWriter textWriter1 = (TextWriter)new StreamWriter("settings.dat");
			TextWriter textWriter2 = textWriter1;
			Preferences preferences = m_settings;
			xmlSerializer.Serialize(textWriter2, (object)preferences);
			textWriter1.Close();
		}

		public void SaveUserPreferences(UserPreferences prefs)
		{
			m_userpreferences = prefs;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserPreferences));
			TextWriter textWriter1 = (TextWriter)new StreamWriter("preferences.dat");
			TextWriter textWriter2 = textWriter1;
			UserPreferences userPreferences = m_userpreferences;
			xmlSerializer.Serialize(textWriter2, (object)userPreferences);
			textWriter1.Close();
		}

		public VehicleProfile GetActiveProfile()
		{
			try
			{
				if (m_settings.ActiveProfileIndex >= 0 && m_settings.ActiveProfileIndex < m_listVehicleProfiles.Count)
					return (VehicleProfile)m_listVehicleProfiles[m_settings.ActiveProfileIndex];
				if (m_listVehicleProfiles.Count == 0)
					m_listVehicleProfiles.Add((object)new VehicleProfile());
				m_settings.ActiveProfileIndex = 0;
				return (VehicleProfile)m_listVehicleProfiles[0];
			}
			catch (Exception)
			{
				return (VehicleProfile)null;
			}
		}

		public void SaveActiveProfile(VehicleProfile profile)
		{
			Preferences commSettings = GetCommSettings();
			commSettings.ActiveProfileIndex = GetVehicleProfiles().IndexOf((object)profile);
			SaveCommSettings(commSettings);
		}

		public ArrayList GetVehicleProfiles()
		{
			return m_listVehicleProfiles;
		}

		public void SaveVehicleProfiles(ArrayList listProfiles)
		{
			FileStream fileStream = (FileStream)null;
			m_listVehicleProfiles = listProfiles;
			try
			{
				IEnumerator enumerator = listProfiles.GetEnumerator();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				if (File.Exists("vehicles.dat"))
					File.Delete("vehicles.dat");
				fileStream = new FileStream("vehicles.dat", FileMode.Create, FileAccess.ReadWrite);
				while (enumerator.MoveNext())
					binaryFormatter.Serialize((Stream)fileStream, enumerator.Current);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}
		}

		private Preferences LoadCommSettings()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Preferences));
				FileStream fileStream = new FileStream("settings.dat", FileMode.Open);
				m_settings = (Preferences)xmlSerializer.Deserialize((Stream)fileStream);
				fileStream.Close();
			}
			catch (Exception)
			{
				m_settings = new Preferences();
			}
			return m_settings;
		}

		private UserPreferences LoadUserPreferences()
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserPreferences));
				FileStream fileStream = new FileStream("preferences.dat", FileMode.Open);
				m_userpreferences = (UserPreferences)xmlSerializer.Deserialize((Stream)fileStream);
				fileStream.Close();
			}
			catch (Exception)
			{
				m_userpreferences = new UserPreferences();
			}
			return m_userpreferences;
		}

		private ArrayList LoadVehicleProfiles()
		{
			FileStream fileStream = (FileStream)null;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			ArrayList arrayList = new ArrayList();
			try
			{
				if (File.Exists("vehicles.dat"))
				{
					fileStream = new FileStream("vehicles.dat", FileMode.Open, FileAccess.Read);
				}
				else
				{
					VehicleProfile vehicleProfile = new VehicleProfile();
					fileStream = new FileStream("vehicles.dat", FileMode.Create, FileAccess.ReadWrite);
					binaryFormatter.Serialize((Stream)fileStream, (object)vehicleProfile);
				}
				fileStream.Position = 0L;
				while (true)
				{
					VehicleProfile vehicleProfile = binaryFormatter.Deserialize((Stream)fileStream) as VehicleProfile;
					arrayList.Add((object)vehicleProfile);
				}
			}
			catch (SerializationException)
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				if (fileStream != null)
					fileStream.Close();
			}
			return arrayList;
		}

		public void InsertLogMessage(string strMsg)
		{
			m_commLog.Add(EventType.Message, strMsg);
		}

		public CommLog get_CommLog()
		{
			return m_commLog;
		}

		public void On_OBD2_Received(string strResponse)
		{
			OnReceived(new OBD2Response(strResponse, false, true, m_iProtocol));
		}

		public ArrayList getSensorList()
		{
			return m_arrayListPID;
		}


		public bool DetectAndOpenComPort()
		{
			m_commLog.Add(EventType.Message, "Using Automatic Hardware Detection");
			int iComPort = 0;
			do
			{
				if (isPortAvailable(iComPort))
				{
					m_obd2Comm.setPort(iComPort);
					m_commLog.Add(EventType.Message, "Trying 38400 baud...");
					m_obd2Comm.setBaudRate(0x9600);
					if (m_obd2Comm.Open())
					{
						string strData = string.Format("Comm Port {0} successfully opened.", iComPort);
						m_commLog.Add(EventType.PortOpened, strData);
						if (((getResponse(new OBD2Request("ATZ")) != null) && (getResponse(new OBD2Request("ATE0")) != null)) && ((getResponse(new OBD2Request("ATL0")) != null) && (getResponse(new OBD2Request("ATH1")) != null)))
						{
							OBD2Response response2 = getResponse(new OBD2Request("ATI"));
							if ((response2.Response.Length >= 3) && (response2.Response.IndexOf("ELM") >= 0))
							{
								int index = response2.Response.IndexOf("ELM");
								ChipInfo = response2.Response.Substring(index);
								return true;
							}
						}
						m_obd2Comm.Close();
					}
					else
					{
						string str3 = string.Format("Comm Port {0} failed to open.", iComPort);
						m_commLog.Add(EventType.PortFailed, str3);
					}
					m_commLog.Add(EventType.Message, "Trying 9600 baud...");
					m_obd2Comm.setBaudRate(0x2580);
					if (m_obd2Comm.Open())
					{
						string str2 = string.Format("Comm Port {0} successfully opened.", iComPort);
						m_commLog.Add(EventType.PortOpened, str2);
						if (((getResponse(new OBD2Request("ATZ")) != null) && (getResponse(new OBD2Request("ATE0")) != null)) && ((getResponse(new OBD2Request("ATL0")) != null) && (getResponse(new OBD2Request("ATH1")) != null)))
						{
							OBD2Response response = getResponse(new OBD2Request("ATI"));
							if ((response.Response.Length >= 3) && (response.Response.IndexOf("ELM") >= 0))
							{
								int startIndex = response.Response.IndexOf("ELM");
								ChipInfo = response.Response.Substring(startIndex);
								return true;
							}
						}
						m_obd2Comm.Close();
					}
					else
					{
						string str = string.Format("Comm Port {0} failed to open.", iComPort);
						m_commLog.Add(EventType.PortFailed, str);
					}
				}
				iComPort++;
			}
			while (iComPort < 50);
			m_commLog.Add(EventType.Message, "Could not detect compatible OBD-II interface on any port.");
			return false;
		}

		public bool OpenComPort()
		{
			bool num;
			try
			{
				if (!m_obd2Comm.Online)
				{
					if (m_settings.AutoDetect)
					{
						num = DetectAndOpenComPort();
					}
					else
					{
						m_obd2Comm.setPort(m_settings.ComPort);
						if (m_settings.HardwareIndex == 1)
						{
							m_obd2Comm.setBaudRate(m_settings.BaudRate);
						}
						int baudRate = m_settings.BaudRate;
						int comPort = m_settings.ComPort;
						string strData = string.Format("Opening Port {0} ({1} baud) with ELM Timeout = {2} ms.", comPort, baudRate, GetActiveProfile().ElmTimeout);
						m_commLog.Add(EventType.Enabled, strData);
						if (m_obd2Comm.Open())
						{
							int num3 = m_settings.ComPort;
							strData = string.Format("Comm Port {0} successfully opened.", num3);
							m_commLog.Add(EventType.PortOpened, strData);
							num = true;
						}
						else
						{
							int num2 = m_settings.ComPort;
							strData = string.Format("Comm Port {0} failed to open.", num2);
							m_commLog.Add(EventType.PortFailed, strData);
							num = false;
						}
					}
				}
				else
				{
					num = true;
				}
			}
			catch (Exception)
			{
				num = false;
			}
			return num;
		}

		public void CloseComPort()
		{
			if (!m_obd2Comm.Online)
				return;
			m_obd2Comm.Close();
		}

		public OBD2Response getResponse(OBD2Request obd2Request)
		{
			try
			{
				OnSent(obd2Request);
				m_commLog.Add(EventType.Transmit, "Tx: " + obd2Request.Request);
				string message = m_obd2Comm.getResponse(obd2Request.Request);
				Debug.WriteLine(obd2Request.Request);
				Debug.WriteLine(message);
				if (message.Length > 0)
				{
					string strData = "Rx: " + message;
					bool bATCommand = false;
					if (obd2Request.Request.IndexOf("AT") >= 0)
					{
						bATCommand = true;
					}
					m_commLog.Add(EventType.Receive, strData);
					OBD2Response response = new OBD2Response(message, bATCommand, true, m_iProtocol);
					strData = string.Concat(strData, response.Data, "]", "  (", obd2Request.Request, ")");
					m_commLog.Add(EventType.Receive, strData);
					OnReceived(response);
					return response;
				}
				m_commLog.Add(EventType.Timeout, "Rx: Request Timed Out.  (" + obd2Request.Request + ")");
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
				m_commLog.Add(EventType.Message, "OBD2Interface Error. (" + exception.ToString() + ")");
			}
			return null;
		}


		public bool isPortAvailable(int iComPort)
		{
			return m_obd2Comm.IsPortAvailable("COM" + iComPort.ToString()) > CommBase.PortStatus.unavailable;
		}

		public int loadPIDDefinitions(string strFilePID)
		{
			if (File.Exists(strFilePID))
			{
				System.Type[] extraTypes = new System.Type[1]
      {
        typeof (Sensor)
      };
				try
				{
					m_arrayListPID = new XmlSerializer(typeof(ArrayList), extraTypes).Deserialize((Stream)new FileStream(strFilePID, FileMode.Open)) as ArrayList;
					return m_arrayListPID.Count;
				}
				catch (Exception)
				{
					MessageBox.Show("The file which contains sensor definitions is corrupt. Please reinstall ProScan.", "Corrupt Data File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return 0;
				}
			}
			else
			{
				MessageBox.Show("The file which contains sensor definitions is missing. Please reinstall ProScan.", "Missing Data File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return 0;
			}
		}

		public int loadDTCDefinitions(string strFileDTC)
		{
			if (File.Exists(strFileDTC))
			{
				System.Type[] extraTypes = new System.Type[1]
      {
        typeof (DTC)
      };
				try
				{
					m_arrayListDTC = new XmlSerializer(typeof(ArrayList), extraTypes).Deserialize((Stream)new FileStream(strFileDTC, FileMode.Open)) as ArrayList;
					return m_arrayListDTC.Count;
				}
				catch (Exception)
				{
					MessageBox.Show("The file which contains DTC definitions is corrupt. Please reinstall ProScan.", "Corrupt Data File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return 0;
				}
			}
			else
			{
				MessageBox.Show("The file which contains DTC definitions is missing. Please reinstall ProScan.", "Missing Data File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return 0;
			}
		}

		public DTC getDTC(string strDTC)
		{
			int idx = 0;
			if (m_arrayListDTC.Count > 0)
				do
				{
					DTC dtc = m_arrayListDTC[idx] as DTC;
					if (dtc.Name.Equals(strDTC))
						return dtc;
					idx++;
				}
				while (idx < m_arrayListDTC.Count);
			return new DTC(strDTC, "", "");
		}

		public ArrayList getSupportedPIDList(int iService)
		{
			ArrayList arrayList = new ArrayList();
			int index = 0;
			if (0 < m_arrayListPID.Count)
			{
				do
				{
					Sensor sensor = (Sensor)m_arrayListPID[index];
					sensor.Service = iService;
					if (isPIDSupported(iService, sensor.PID))
					{
						if (sensor.isO2Dependant)
						{
							if (sensor.isFor1D && isPIDSupported(1, 29) || !sensor.isFor1D && isPIDSupported(1, 19))
								arrayList.Add((object)sensor);
						}
						else if (sensor.PID > 5 && sensor.PID < 10)
						{
							if (isFuelTrimSupported(sensor.PID, sensor.SubPID))
								arrayList.Add((object)sensor);
						}
						else
							arrayList.Add((object)sensor);
					}
					++index;
				}
				while (index < m_arrayListPID.Count);
			}
			return arrayList;
		}

		public ArrayList getSupportedSensorList(int iService)
		{
			ArrayList supportedPidList = getSupportedPIDList(iService);
			ArrayList arrayList = new ArrayList();
			if (supportedPidList != null)
			{
				int index = 0;
				if (0 < supportedPidList.Count)
				{
					do
					{
						if (((Sensor)supportedPidList[index]).isSensor)
							arrayList.Add(supportedPidList[index]);
						++index;
					}
					while (index < supportedPidList.Count);
				}
			}
			return arrayList;
		}

		public ArrayList getSupportedPlottableSensorList(int iService)
		{
			ArrayList supportedPidList = getSupportedPIDList(iService);
			ArrayList arrayList = new ArrayList();
			if (supportedPidList != null)
			{
				int index = 0;
				if (0 < supportedPidList.Count)
				{
					do
					{
						if (((Sensor)supportedPidList[index]).isPlottable)
							arrayList.Add(supportedPidList[index]);
						++index;
					}
					while (index < supportedPidList.Count);
				}
			}
			return arrayList;
		}


		public bool isPIDSupported(int iService, int iPID)
		{
			if (iPID < 0 && iPID > (int)byte.MaxValue)
				return false;
			if (iService == 1)
				return m_bService01PIDSupport[iPID];
			if (iService != 2)
				return false;
			else
				return m_bService02PIDSupport[iPID];
		}


		public bool buildPIDSupportStatusList(int iService)
		{
			bool[] flagArray;
			if (iService != 1)
			{
				if (iService != 2)
				{
					return false;
				}
				flagArray = m_bService02PIDSupport;
			}
			else
			{
				flagArray = m_bService01PIDSupport;
			}
			int index = 0;
			do
			{
				flagArray[index] = false;
				index++;
			}
			while (index < 256);

			int iPID = 0;

			do
			{
				Debug.WriteLine("BuildPIDSupportStatusList");
				OBD2Response response = getResponse(new OBD2Request(iService, iPID));
				Debug.Write(response.Response);
				if (response == null)
				{
					return false;
				}
				if (response.ResponseType != OBD2Response.ResponseTypes.HexData)
				{
					return false;
				}
				Debug.WriteLine("Hex Data");
				Debug.WriteLine(response.PID);
				Debug.WriteLine(OBD2.Int2HexString(iPID));
				if (string.Compare(response.PID, OBD2.Int2HexString(iPID)) != 0)
				{
					return false;
				}
				Debug.WriteLine("Correct PID");
				int iECU = 0;
				if (0 < response.getECUResponseCount())
				{
					do
					{
						int iByte = 0;
						int num4 = 0;
						do
						{
							int num2 = 7;
							do
							{
								if ((response.getDataByte(iECU, iByte) & ((int)Math.Pow(2.0, (double)num2))) != 0)
								{
									flagArray[(iPID + (num4 - num2)) + 8] = true;
								}
								num2--;
							}
							while (num2 >= 0);
							iByte++;
							num4 += 8;
						}
						while (num4 <= 0x18);
						iECU++;
					}
					while (iECU < response.getECUResponseCount());
				}
				Debug.Write("PID SUPPORT FLAGS: ");

				int num3 = 0;
				do
				{
					if (flagArray[num3])
						Debug.Write("T");
					else
						Debug.Write("F");
					num3++;
				}
				while (num3 < 33);

				iPID = iPID + 32;
				if (!flagArray[iPID])
					break;
			}
			while (iPID < 0x100);
			return true;
		}


		public bool buildO2Locations()
		{
			int iPID;
			if (isPIDSupported(1, 19))
				iPID = 19;
			else
			{
				if (!isPIDSupported(1, 29))
					return false;
				iPID = 29;
			}
			OBD2Response response = getResponse(new OBD2Request(1, iPID));
			if (response == null || (string.Compare(response.Request, "0113") != 0 && string.Compare(response.Request, "011D") != 0))
				return false;

			int index = 7;
			do
			{
				m_bO2Locations[index] = ((int)Math.Pow(2.0, (double)index) & response.DataA) != 0;
				--index;
			}
			while (index >= 0);
			return true;
		}


		public bool isBankSupported(int iBank)
		{
			if (iBank == 1)
			{
				if (isPIDSupported(1, 19))
					return m_bO2Locations[0] || m_bO2Locations[1] || (m_bO2Locations[2] || m_bO2Locations[3]);
				else
					return m_bO2Locations[0] || m_bO2Locations[1];
			}
			else if (iBank == 2)
			{
				if (isPIDSupported(1, 19))
					return m_bO2Locations[4] || m_bO2Locations[5] || (m_bO2Locations[6] || m_bO2Locations[7]);
				else
					return m_bO2Locations[2] || m_bO2Locations[3];
			}
			else if (iBank == 3)
			{
				if (isPIDSupported(1, 19))
					return false;
				else
					return m_bO2Locations[4] || m_bO2Locations[5];
			}
			else if (iBank == 4 && !isPIDSupported(1, 19))
				return m_bO2Locations[6] || m_bO2Locations[7];
			else
				return false;
		}


		public bool isFuelTrimSupported(int iPID, int iSubPID)
		{
			if (iPID == 6)
			{
				if (iSubPID == 0)
					return isBankSupported(1);
				if (iSubPID == 1)
					return isBankSupported(3);
			}
			else if (iPID == 7)
			{
				if (iSubPID == 0)
					return isBankSupported(1);
				if (iSubPID == 1)
					return isBankSupported(3);
			}
			else if (iPID == 8)
			{
				if (iSubPID == 0)
					return isBankSupported(2);
				if (iSubPID == 1)
					return isBankSupported(4);
			}
			else if (iPID == 9)
			{
				if (iSubPID == 0)
					return isBankSupported(2);
				if (iSubPID == 1)
					return isBankSupported(4);
			}
			return false;
		}


		public bool InitializeInterface()
		{
			if (m_settings.AutoDetect)
			{
				string str2 = OBD2.Int2HexString(50);
				if (getResponse(new OBD2Request("ATST" + str2)) != null)
				{
					if (ChipInfo.IndexOf("ELM327") >= 0)
					{
						getResponse(new OBD2Request("ATSP0"));
						if (getResponse(new OBD2Request("0101")).Response.IndexOf("4101") >= 0)
							return true;
						int num = 1;
						do
						{
							getResponse(new OBD2Request("ATSP" + num.ToString()));
							if (getResponse(new OBD2Request("0101")).Response.IndexOf("4101") >= 0)
							{
								return true;
							}
							num++;
						}
						while (num < 10);
					}
					else if (getResponse(new OBD2Request("0101")).Response.IndexOf("4101") >= 0)
						return true;
				}
				return false;
			}
			string strRequest = "ATST" + m_strElmTimeout;
			if (getResponse(new OBD2Request(strRequest)) == null)
			{
				return false;
			}
			if (m_settings.HardwareIndex == 1)
			{
				if (!m_settings.DoInitialization && (getResponse(new OBD2Request("ATBI")) == null))
					return false;

				int protocolIndex = m_settings.ProtocolIndex;
				if (getResponse(new OBD2Request("ATSP" + protocolIndex.ToString())) == null)
					return false;

				if (m_settings.ProtocolIndex == 0)
					getResponse(new OBD2Request("0100"));
			}
			return true;
		}


		public bool InitializeOBD2()
		{
			OBD2Response response = getResponse(new OBD2Request("ATDPN"));
			if (response == null)
				return false;
			m_iProtocol = OBD2.Hex2Int(response.Response.Replace("A", ""));
			if (!buildPIDSupportStatusList(1))
				return false;
			buildO2Locations();
			return true;
		}

		public enum Protocol
		{
			Automatic,
			J1850_PWM,
			J1850_VPW,
			ISO9141_2,
			ISO_14230_4_KWP_5BAUDINIT,
			ISO_14230_4_KWP_FASTINIT,
			ISO_15765_4_CAN_11BIT_500KBAUD,
			ISO_15765_4_CAN_29BIT_500KBAUD,
			ISO_15765_4_CAN_11BIT_250KBAUD,
			ISO_15765_4_CAN_29BIT_250KBAUD,
		}
	}
}