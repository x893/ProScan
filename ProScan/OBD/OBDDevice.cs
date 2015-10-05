using System;
using System.Runtime.InteropServices;

namespace ProScan
{
	public abstract class OBDDevice
	{
		protected string m_DeviceID;
		protected OBDCommLog m_commLog;
		protected OBDParser m_Parser;
		protected OBDCommELM m_CommELM;

		public OBDDevice(OBDCommLog log)
		{
			m_commLog = log;
			m_CommELM = new OBDCommELM(log);
		}

		public string DeviceIDString()
		{
			return m_DeviceID;
		}

		public abstract bool Initialize(int iPort, int iBaud, ProtocolType iProtocol);
		public abstract bool Initialize(int iPort, int iBaud);
		public abstract bool Initialize();
		public abstract void Disconnect();
		public abstract bool Connected();
		public abstract OBDResponseList Query(OBDParameter param);
		public abstract string Query(string cmd);
	}
}