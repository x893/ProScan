using System;

[Serializable]
public class Preferences
{
	private bool m_bAutoDetect;
	private int m_iComPort;
	private int m_iHardwareIndex;
	private int m_iBaudRateIndex;
	private int m_iProtocolIndex;
	private int m_iActiveProfileIndex;
	private bool m_bInitialize;

	public Preferences()
	{
		m_bAutoDetect = true;
		m_iComPort = 1;
		m_iActiveProfileIndex = 0;
		m_iBaudRateIndex = 0;
		m_iHardwareIndex = 0;
		m_iProtocolIndex = 0;
		m_bInitialize = true;
	}

	public int BaudRate
	{
		get
		{
			switch (m_iBaudRateIndex)
			{
				case 0: return 9600;
				case 1: return 38400;
				case 2: return 115200;
				default: return 9600;
			}
		}
	}

	public string ComPortName
	{
		get
		{
			return "COM" + Convert.ToString(m_iComPort);
		}
	}

	public bool DoInitialization
	{
		get { return m_bInitialize; }
		set { m_bInitialize = value; }
	}

	public int ActiveProfileIndex
	{
		get { return m_iActiveProfileIndex; }
		set { m_iActiveProfileIndex = value; }
	}

	public int BaudRateIndex
	{
		get { return m_iBaudRateIndex; }
		set { m_iBaudRateIndex = value; }
	}

	public int ProtocolIndex
	{
		get { return m_iProtocolIndex; }
		set { m_iProtocolIndex = value; }
	}

	public int HardwareIndex
	{
		get { return m_iHardwareIndex; }
		set { m_iHardwareIndex = value; }
	}

	public int ComPort
	{
		get { return m_iComPort; }
		set { m_iComPort = value; }
	}

	public bool AutoDetect
	{
		get { return m_bAutoDetect; }
		set { m_bAutoDetect = value; }
	}
}
