using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace ProScan
{
	public class OBDInterface
	{
		public delegate void __Delegate_OnConnect();
		public delegate void __Delegate_OnDisconnect();

		private int m_iDevice;
		private OBDDevice m_obdDevice;
		private ArrayList m_listDTC;
		private ArrayList m_listAllParameters;
		private ArrayList m_listSupportedParameters;
		private OBDCommLog m_commLog;
		private UserPreferences m_userpreferences;
		private Preferences m_settings;
		private ArrayList m_listVehicleProfiles;

		public event OBDInterface.__Delegate_OnDisconnect OnDisconnect;
		public event OBDInterface.__Delegate_OnConnect OnConnect;

		public OBDInterface()
		{
			m_commLog = new OBDCommLog();
			m_commLog.Delete();
			setDevice(1);
			m_listAllParameters = new ArrayList();
			m_listSupportedParameters = new ArrayList();
			m_userpreferences = LoadUserPreferences();
			m_settings = LoadCommSettings();
			m_listVehicleProfiles = LoadVehicleProfiles();
		}

		public int getDevice()
		{
			return m_iDevice;
		}

		public string getDeviceIDString()
		{
			return m_obdDevice.getDeviceIDString();
		}


		public bool initDevice(int device, int port, int baud, int protocol)
		{
			m_commLog.AddItem(string.Format("Attempting initialization on port {0}", port.ToString()));
			bool flag = false;
			setDevice(device);
			if (m_obdDevice.initialize(port, baud, protocol) && initOBD())
			{
				flag = true;
				OnConnect();
			}
			return flag;
		}


		public bool initDeviceAuto()
		{
			m_commLog.AddItem("Beginning AUTO initialization...");
			bool flag = false;
			setDevice(1);
			if (m_obdDevice.initialize() && initOBD())
			{
				flag = true;
				OnConnect();
			}
			return flag;
		}


		public bool initOBD()
		{
			OBDParameter obdParameter1 = new OBDParameter(1, 0, 0);
			obdParameter1.ValueTypes = 32;
			OBDParameterValue obdParameterValue1 = getValue(obdParameter1, true);
			if (obdParameterValue1.ErrorDetected)
				return false;
			IEnumerator enumerator1 = m_listAllParameters.GetEnumerator();
			if (enumerator1.MoveNext())
			{
				do
				{
					OBDParameter obdParameter2 = (OBDParameter)enumerator1.Current;
					if (obdParameter2.Parameter > 0 && obdParameter2.Parameter <= 32 && obdParameterValue1.getBitFlag(obdParameter2.Parameter - 1))
						m_listSupportedParameters.Add((object)obdParameter2);
				}
				while (enumerator1.MoveNext());
			}
			if (!obdParameterValue1.getBitFlag(31))
				return true;
			obdParameter1.Parameter = 32;
			OBDParameterValue obdParameterValue2 = getValue(obdParameter1, true);
			if (obdParameterValue2.ErrorDetected)
				return false;
			IEnumerator enumerator2 = m_listAllParameters.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					OBDParameter obdParameter2 = (OBDParameter)enumerator2.Current;
					if (obdParameter2.Parameter > 32 && obdParameter2.Parameter <= 64 && obdParameterValue2.getBitFlag(obdParameter2.Parameter - 33))
						m_listSupportedParameters.Add((object)obdParameter2);
				}
				while (enumerator2.MoveNext());
			}
			return true;
		}


		public bool isParameterSupported(string strPID)
		{
			IEnumerator enumerator = m_listSupportedParameters.GetEnumerator();
			if (enumerator.MoveNext())
			{
				while (((OBDParameter)enumerator.Current).PID.CompareTo(strPID) != 0)
				{
					if (!enumerator.MoveNext())
						return false;
				}
				return true;
			}
			return false;
		}


		public bool isParameterSupported(OBDParameter param)
		{
			IEnumerator enumerator = m_listSupportedParameters.GetEnumerator();
			if (enumerator.MoveNext())
			{
				while ((OBDParameter)enumerator.Current != param)
				{
					if (!enumerator.MoveNext())
						return false;
				}
				return true;
			}
			return false;
		}

		public OBDParameterValue getValue(string strPID, bool bEnglishUnits)
		{
			OBDParameter obdParameter = lookupParameter(strPID);
			if (obdParameter != null)
				return getValue(obdParameter, bEnglishUnits);

			OBDParameterValue value = new OBDParameterValue();
			value.ErrorDetected = true;
			return value;
		}

		public OBDParameterValue getValue(OBDParameter param, bool bEnglishUnits)
		{
			if (param.PID.Length > 0)
				m_commLog.AddItem("Requesting " + param.PID);
			else
				m_commLog.AddItem("Requesting " + param.OBDRequest);

			if (param.Service == 0)
				return getSpecialValue(param, bEnglishUnits);

			OBDResponseList responses = m_obdDevice.query(param);
			string strItem1 = "Responses: ";
			int index1 = 0;
			if (0 < responses.ResponseCount)
			{
				do
				{
					strItem1 = strItem1 + string.Format("[{0}] ", responses.GetOBDResponse(index1).Data);
					++index1;
				}
				while (index1 < responses.ResponseCount);
			}
			m_commLog.AddItem(strItem1);
			OBDParameterValue obdParameterValue = OBDInterpretter.getValue(param, responses, bEnglishUnits);
			if (obdParameterValue.ErrorDetected)
			{
				m_commLog.AddItem("Error Detected!");
				return obdParameterValue;
			}
			else
			{
				string strItem2 = "Values: ";
				if ((param.ValueTypes & 2) == 2)
				{
					bool num = obdParameterValue.BoolValue;
					strItem2 = strItem2 + string.Format("[Bool: {0}] ", num.ToString());
				}
				if ((param.ValueTypes & 1) == 1)
				{
					double num = obdParameterValue.DoubleValue;
					strItem2 = strItem2 + string.Format("[Double: {0}] ", num.ToString());
				}
				if ((param.ValueTypes & 4) == 4)
					strItem2 += string.Format("[String: {0} / {1}] ", obdParameterValue.StringValue, obdParameterValue.ShortStringValue);
				if ((param.ValueTypes & 8) == 8)
				{
					string str = strItem2 + "[StringCollection: ";
					StringEnumerator enumerator = obdParameterValue.StringCollectionValue.GetEnumerator();
					if (enumerator.MoveNext())
					{
						do
						{
							str = str + enumerator.Current + ", ";
						}
						while (enumerator.MoveNext());
					}
					strItem2 = str + "]";
				}
				if ((param.ValueTypes & 32) == 32)
				{
					string str = strItem2 + "[BitFlags: ";
					int index2 = 0;
					do
					{
						str += obdParameterValue.getBitFlag(index2) ? "T" : "F";
						++index2;
					}
					while (index2 < 32);
					strItem2 = str + " ]";
				}
				m_commLog.AddItem(strItem2);
				return obdParameterValue;
			}
		}

		public OBDParameterValue getSpecialValue(OBDParameter param, bool bEnglishUnits)
		{
			OBDParameterValue value = new OBDParameterValue();
			if (param.Parameter != 0)
				return null;

			string s = getRawResponse("ATRV");
			m_commLog.AddItem("Response: " + s);
			if (s != null)
			{
				s = s.Replace("V", "");
				value.DoubleValue = double.Parse(s);
			}
			return value;
		}

		public string getRawResponse(string strCmd)
		{
			return m_obdDevice.query(strCmd);
		}


		public bool clearCodes()
		{
			return (m_obdDevice.query("04").IndexOf("44") >= 0);

		}

		public void disconnect()
		{
			OnDisconnect();
			m_obdDevice.disconnect();
		}

		public void enableLogFile(bool status)
		{
			m_commLog.SetLogFileStatus(status);
		}

		public void logItem(string strMsg)
		{
			m_commLog.AddItem(strMsg);
		}


		public bool loadParameters(string fileName)
		{
			try
			{
				int lineNo = 0;
				string line;
				char[] chArray = new char[] { ',' };

				using (StreamReader streamReader = new StreamReader(fileName))
					while ((line = streamReader.ReadLine()) != null)
					{
						try
						{
							string[] strArray = line.Split(chArray);

							OBDParameter obdParameter = new OBDParameter();
							obdParameter.PID = strArray[0];
							obdParameter.Name = strArray[1];
							obdParameter.OBDRequest = strArray[2];
							obdParameter.Service = int.Parse(strArray[3]);
							obdParameter.Parameter = int.Parse(strArray[4]);
							obdParameter.SubParameter = int.Parse(strArray[5]);

							if (strArray[6].CompareTo("Airflow") == 0)
								obdParameter.Category = 0;
							else if (strArray[6].CompareTo("DTC") == 0)
								obdParameter.Category = 1;
							else if (strArray[6].CompareTo("Emissions") == 0)
								obdParameter.Category = 2;
							else if (strArray[6].CompareTo("Fuel") == 0)
								obdParameter.Category = 3;
							else if (strArray[6].CompareTo("General") == 0)
								obdParameter.Category = 4;
							else if (strArray[6].CompareTo("O2") == 0)
								obdParameter.Category = 5;
							else if (strArray[6].CompareTo("Powertrain") == 0)
								obdParameter.Category = 6;
							else if (strArray[6].CompareTo("Speed") == 0)
								obdParameter.Category = 7;
							else if (strArray[6].CompareTo("Temperature") == 0)
								obdParameter.Category = 8;

							if (strArray[7].CompareTo("Generic") == 0)
								obdParameter.Type = 0;
							else if (strArray[7].CompareTo("Manufacturer") == 0)
								obdParameter.Type = 1;
							else if (strArray[7].CompareTo("Scripted") == 0)
								obdParameter.Type = 2;

							if (strArray[8].CompareTo("SAE") == 0)
								obdParameter.Manufacturer = 0;
							else if (strArray[8].CompareTo("GM") == 0)
								obdParameter.Manufacturer = 1;
							else if (strArray[8].CompareTo("Ford") == 0)
								obdParameter.Manufacturer = 2;
							else if (strArray[8].CompareTo("ProScan") == 0)
								obdParameter.Manufacturer = 3;

							obdParameter.Priority = int.Parse(strArray[9]);
							obdParameter.EnglishUnitLabel = strArray[10];
							obdParameter.MetricUnitLabel = strArray[11];

							try
							{
								obdParameter.EnglishMinValue = double.Parse(strArray[12]);
								obdParameter.EnglishMaxValue = double.Parse(strArray[13]);
								obdParameter.MetricMinValue = double.Parse(strArray[14]);
								obdParameter.MetricMaxValue = double.Parse(strArray[15]);
							}
							catch { }

							int valueType = 0;
							if (int.Parse(strArray[16]) > 0)
								valueType = 1;
							if (int.Parse(strArray[17]) > 0)
								valueType |= 2;
							if (int.Parse(strArray[18]) > 0)
								valueType |= 4;
							if (int.Parse(strArray[19]) > 0)
								valueType |= 8;

							obdParameter.ValueTypes = valueType;
							m_listAllParameters.Add(obdParameter);
							++lineNo;
						}
						catch (Exception)
						{
							m_commLog.AddItem(string.Format("Failed to load parameters from {0}", fileName));
							return false;
						}
					}
				m_commLog.AddItem(string.Format("Loaded {0} parameters from {1}", lineNo.ToString(), fileName));
				return true;
			}
			catch (Exception)
			{
				m_commLog.AddItem(string.Format("Failed to locate parameter file: {0}", fileName));
				return false;
			}
		}


		public bool loadTroubleCodes(string strFile)
		{
			if (!File.Exists(strFile))
				return false;
			Type[] extraTypes = new Type[1]
    {
      typeof (DTC)
    };
			try
			{
				m_listDTC = new XmlSerializer(typeof(ArrayList), extraTypes).Deserialize((Stream)new FileStream(strFile, FileMode.Open)) as ArrayList;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public DTC getDTC(string code)
		{
			IEnumerator enumerator = m_listDTC.GetEnumerator();
			if (enumerator.MoveNext())
			{
				DTC dtc;
				do
				{
					dtc = (DTC)enumerator.Current;
					if (dtc.Name.CompareTo(code) == 0)
						return dtc;
				}
				while (enumerator.MoveNext());
			}
			return new DTC(code, "", "");
		}

		public OBDParameter lookupParameter(string pid)
		{
			IEnumerator enumerator = m_listAllParameters.GetEnumerator();
			if (enumerator.MoveNext())
			{
				OBDParameter obdParameter;
				do
				{
					obdParameter = (OBDParameter)enumerator.Current;
					if (obdParameter.PID.CompareTo(pid) == 0)
						return obdParameter;
				}
				while (enumerator.MoveNext());
			}
			return (OBDParameter)null;
		}

		public ArrayList getSupportedParameterList(int valueTypes)
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = m_listSupportedParameters.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					OBDParameter obdParameter = (OBDParameter)enumerator.Current;
					if ((obdParameter.ValueTypes & valueTypes) == valueTypes)
						arrayList.Add((object)obdParameter);
				}
				while (enumerator.MoveNext());
			}
			return arrayList;
		}

		private void setDevice(int device)
		{
			m_iDevice = device;
			switch (device)
			{
				case 1:
					m_commLog.AddItem("Set device to ELM327");
					m_obdDevice = (OBDDevice)new OBDDeviceELM327(m_commLog);
					break;
				case 2:
					m_commLog.AddItem("Set device to ELM320");
					m_obdDevice = (OBDDevice)new OBDDeviceELM320(m_commLog);
					break;
				case 3:
					m_commLog.AddItem("Set device to ELM322");
					m_obdDevice = (OBDDevice)new OBDDeviceELM322(m_commLog);
					break;
				case 4:
					m_commLog.AddItem("Set device to ELM323");
					m_obdDevice = (OBDDevice)new OBDDeviceELM323(m_commLog);
					break;
				default:
					m_commLog.AddItem("Set device to ELM327");
					m_obdDevice = (OBDDevice)new OBDDeviceELM327(m_commLog);
					break;
			}
		}

		public bool getConnectedStatus()
		{
			return m_obdDevice.connected();
		}

		public int loadDTCDefinitions(string fileName)
		{
			if (!File.Exists(fileName))
				return 0;
			Type[] extraTypes = new Type[] { typeof(DTC) };
			try
			{
				m_listDTC = new XmlSerializer(typeof(ArrayList), extraTypes).Deserialize((Stream)new FileStream(fileName, FileMode.Open)) as ArrayList;
				return m_listDTC.Count;
			}
			catch
			{
				return 0;
			}
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

		public UserPreferences GetUserPreferences()
		{
			return m_userpreferences;
		}

		public Preferences GetCommSettings()
		{
			return m_settings;
		}

		public Preferences LoadCommSettings()
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
				FileStream file = new FileStream("settings.dat", FileMode.Open);
				m_settings = (Preferences)serializer.Deserialize((Stream)file);
				file.Close();
			}
			catch
			{
				m_settings = new Preferences();
			}
			return m_settings;
		}

		public UserPreferences LoadUserPreferences()
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(UserPreferences));
				FileStream file = new FileStream("preferences.dat", FileMode.Open);
				m_userpreferences = (UserPreferences)serializer.Deserialize((Stream)file);
				file.Close();
			}
			catch
			{
				m_userpreferences = new UserPreferences();
			}
			return m_userpreferences;
		}

		public ArrayList LoadVehicleProfiles()
		{
			FileStream file = null;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			ArrayList profiles = new ArrayList();
			try
			{
				if (File.Exists("vehicles.dat"))
					file = new FileStream("vehicles.dat", FileMode.Open, FileAccess.Read);
				else
				{
					VehicleProfile profile = new VehicleProfile();
					file = new FileStream("vehicles.dat", FileMode.Create, FileAccess.ReadWrite);
					binaryFormatter.Serialize((Stream)file, profile);
				}
				file.Position = 0L;
				while (true)
				{
					VehicleProfile vehicleProfile = binaryFormatter.Deserialize(file) as VehicleProfile;
					profiles.Add((object)vehicleProfile);
				}
			}
			catch (SerializationException) { }
			catch (Exception) { }
			finally
			{
				if (file != null)
					file.Close();
			}
			return profiles;
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
			Preferences settings = GetCommSettings();
			settings.ActiveProfileIndex = GetVehicleProfiles().IndexOf((object)profile);
			SaveCommSettings(settings);
		}

		public ArrayList GetVehicleProfiles()
		{
			return m_listVehicleProfiles;
		}

		public void SaveVehicleProfiles(ArrayList profiles)
		{
			FileStream file = null;
			m_listVehicleProfiles = profiles;
			try
			{
				IEnumerator enumerator = profiles.GetEnumerator();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				if (File.Exists("vehicles.dat"))
					File.Delete("vehicles.dat");
				file = new FileStream("vehicles.dat", FileMode.Create, FileAccess.ReadWrite);
				while (enumerator.MoveNext())
					binaryFormatter.Serialize((Stream)file, enumerator.Current);
			}
			catch (Exception)
			{
			}
			finally
			{
				if (file != null)
					file.Close();
			}
		}
	}
}