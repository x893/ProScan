public class SerialNumber
{
	private string m_strSerial;

	public SerialNumber() { }

	public string Serial
	{
		get { return m_strSerial; }
		set { m_strSerial = value; }
	}

	public SerialNumber(string strSerial)
	{
		m_strSerial = strSerial;
	}
}