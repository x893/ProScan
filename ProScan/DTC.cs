public class DTC
{
	private string m_strCategory;
	private string m_strDTC;
	private string m_strDescription;

	public DTC()
	{
	}

	public string Description
	{
		get { return m_strDescription; }
		set { m_strDescription = value; }
	}

	public string Name
	{
		get { return m_strDTC; }
		set { m_strDTC = value; }
	}

	public string Category
	{
		get { return m_strCategory; }
		set { m_strCategory = value; }
	}

	public DTC(string strDTC, string strCategory, string strDesc)
	{
		m_strDTC = strDTC;
		m_strCategory = strCategory;
		m_strDescription = strDesc;
	}

	public override string ToString()
	{
		return m_strDTC;
	}
}