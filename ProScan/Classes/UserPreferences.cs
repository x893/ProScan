using System;

[Serializable]
public class UserPreferences
{
	private string m_Name;
	private string m_Address1;
	private string m_Address2;
	private string m_Telephone;

	public string Telephone
	{
		get { return m_Telephone; }
		set { m_Telephone = value; }
	}

	public string Address2
	{
		get { return m_Address2; }
		set { m_Address2 = value; }
	}

	public string Address1
	{
		get { return m_Address1; }
		set { m_Address1 = value; }
	}

	public string Name
	{
		get { return m_Name; }
		set { m_Name = value; }
	}
}