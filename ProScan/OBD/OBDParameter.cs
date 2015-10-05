using System;
namespace ProScan
{
	public class OBDParameter
	{
		private string m_PID = "";
		private string m_Name = "";
		private string m_EnglishUnit = "";
		private string m_MetricUnit = "";
		private int m_Service;
		private int m_Parameter;
		private int m_SubParameter;
		private string m_OBDRequest;
		private int m_ValueType;
		private int m_Category;
		private int m_Type;
		private int m_Manufacturer;
		private int m_Priority;
		private double m_MinValueEnglish;
		private double m_MaxValueEnglish;
		private double m_MinValueMetric;
		private double m_MaxValueMetric;

		public OBDParameter(int service, int parameter, int subParameter, int frame)
		{
			OBDRequest = Utility.Int2Hex2(service) + Utility.Int2Hex2(parameter) + Utility.Int2Hex2(frame);
			Service = service;
			Parameter = parameter;
			SubParameter = subParameter;
		}

		public OBDParameter(int service, int parameter, int subParameter)
		{
			OBDRequest = Utility.Int2Hex2(service) + Utility.Int2Hex2(parameter);
			Service = service;
			Parameter = parameter;
			SubParameter = subParameter;
		}

		public OBDParameter()
		{
			m_OBDRequest = "";
		}

		public int SubParameter
		{
			get { return m_SubParameter; }
			set { m_SubParameter = value; }
		}

		public int Parameter
		{
			get { return m_Parameter; }
			set { m_Parameter = value; }
		}

		public int Service
		{
			get { return m_Service; }
			set { m_Service = value; }
		}

		public double MetricMaxValue
		{
			get { return m_MaxValueMetric; }
			set { m_MaxValueMetric = value; }
		}

		public double MetricMinValue
		{
			get { return m_MinValueMetric; }
			set { m_MinValueMetric = value; }
		}

		public double EnglishMaxValue
		{
			get { return m_MaxValueEnglish; }
			set { m_MaxValueEnglish = value; }
		}

		public double EnglishMinValue
		{
			get { return m_MinValueEnglish; }
			set { m_MinValueEnglish = value; }
		}

		public int ValueTypes
		{
			get { return m_ValueType; }
			set { m_ValueType = value; }
		}

		public int Priority
		{
			get { return m_Priority; }
			set { m_Priority = value; }
		}

		public int Manufacturer
		{
			get { return m_Manufacturer; }
			set { m_Manufacturer = value; }
		}

		public int Type
		{
			get { return m_Type; }
			set { m_Type = value; }
		}

		public int Category
		{
			get { return m_Category; }
			set { m_Category = value; }
		}

		public string MetricUnitLabel
		{
			get { return m_MetricUnit; }
			set { m_MetricUnit = value; }
		}

		public string EnglishUnitLabel
		{
			get { return m_EnglishUnit; }
			set { m_EnglishUnit = value; }
		}

		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		public string PID
		{
			get { return m_PID; }
			set { m_PID = value; }
		}

		public string OBDRequest
		{
			get { return m_OBDRequest; }
			set { m_OBDRequest = value; }
		}

		public OBDParameter GetCopy()
		{
			OBDParameter p = new OBDParameter();
			p.Category = Category;
			p.ValueTypes = ValueTypes;
			p.EnglishMaxValue = EnglishMaxValue;
			p.EnglishMinValue = EnglishMinValue;
			p.EnglishUnitLabel = EnglishUnitLabel;
			p.Manufacturer = Manufacturer;
			p.MetricMaxValue = MetricMaxValue;
			p.MetricMinValue = MetricMinValue;
			p.MetricUnitLabel = MetricUnitLabel;
			p.Name = Name;
			p.OBDRequest = OBDRequest;
			p.Parameter = Parameter;
			p.PID = PID;
			p.Priority = Priority;
			p.Service = Service;
			p.SubParameter = SubParameter;
			p.Type = Type;
			return p;
		}

		public OBDParameter GetFreezeFrameCopy(int iFrame)
		{
			OBDParameter copy = GetCopy();
			copy.Service = 2;
			copy.OBDRequest = "02" + copy.OBDRequest.Substring(2, 2) + iFrame.ToString("D2");
			return copy;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
