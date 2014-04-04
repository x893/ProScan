using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ProScan
{
	public class OxygenSensorDisplay : Component
	{
		private Container components;

		public OxygenSensorDisplay(IContainer container)
		{
			components = (Container)null;
			container.Add((IComponent)this);
			InitializeComponent();
		}

		public OxygenSensorDisplay()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new Container();
		}
	}
}