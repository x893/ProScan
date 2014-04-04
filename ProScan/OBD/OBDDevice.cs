using System;
using System.Runtime.InteropServices;

public abstract class OBDDevice
{
	protected string m_strDeviceID;
	protected OBDCommLog m_commLog;

	public OBDDevice(OBDCommLog log)
	{
		m_commLog = log;
	}

	public string getDeviceIDString()
	{
		return m_strDeviceID;
	}

	public abstract bool initialize(int iPort, int iBaud, int iProtocol);
	public abstract bool initialize(int iPort, int iBaud);
	public abstract bool initialize();
	public abstract void disconnect();
	public abstract bool connected();
	public abstract OBDResponseList query(OBDParameter param);
	public abstract string query(string cmd);
}