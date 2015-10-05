public class DTC
{
	private string m_DTC;
	private string m_Description;
	private string m_Category;

	public DTC()
	{
	}

	public DTC(string strDTC, string strCategory, string strDesc)
	{
		m_DTC = strDTC;
		m_Category = strCategory;
		m_Description = strDesc;
	}

	public string Description
	{
		get { return m_Description; }
		set { m_Description = value; }
	}

	public string Name
	{
		get { return m_DTC; }
		set { m_DTC = value; }
	}

	public string Category
	{
		get { return m_Category; }
		set { m_Category = value; }
	}

	public override string ToString()
	{
		return m_DTC;
	}
}