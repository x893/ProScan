using System;

[Serializable]
public class UserPreferences
{
	private string m_strName;
	private string m_strAddress1;
	private string m_strAddress2;
	private string m_strTelephone;

	public string Telephone
	{
		get { return m_strTelephone; }
		set { m_strTelephone = value; }
	}

	public string Address2
	{
		get { return m_strAddress2; }
		set { m_strAddress2 = value; }
	}

	public string Address1
	{
		get { return m_strAddress1; }
		set { m_strAddress1 = value; }
	}

	public string Name
	{
		get { return m_strName; }
		set { m_strName = value; }
	}
}