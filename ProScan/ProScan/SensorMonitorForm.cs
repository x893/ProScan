using SensorDisplay;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ProScan
{
	public class SensorMonitorForm : Form
	{
		private CheckedListBox listSensors;
		private GroupBox groupSelections;
		private OBDInterface m_obdInterface;
		private DateTime m_dtStartTime;
		private static ArrayList m_arrayListSensors;
		private static ArrayList m_arrayListRequests;
		private static ArrayList m_arrayListLog;
		public bool bLogging;
		public bool bRunThread;
		private GroupBox groupDisplay;
		private GroupBox groupLogging;
		private RadioButton radioDisplayEnglish;
		private RadioButton radioDisplayMetric;
		private RadioButton radioDisplayBoth;
		private Button btnReset;
		private Button btnSave;
		private HScrollBar scrollTime;
		private Button btnStart;
		private Panel panelDisplay;
		private Label lblTimeElapsed;
		private IContainer components;

		static SensorMonitorForm()
		{
		}

		public SensorMonitorForm(OBDInterface obd2)
		{
			try
			{
				InitializeComponent();
				m_obdInterface = obd2;
				bLogging = false;
				btnStart.Enabled = false;
				btnReset.Enabled = false;
				btnSave.Enabled = false;
				bRunThread = true;
				SensorMonitorForm.m_arrayListSensors = new ArrayList();
				SensorMonitorForm.m_arrayListRequests = new ArrayList();
				SensorMonitorForm.m_arrayListLog = new ArrayList();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public new void Close()
		{
			bLogging = false;
			bRunThread = false;
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			listSensors = new System.Windows.Forms.CheckedListBox();
			groupSelections = new System.Windows.Forms.GroupBox();
			groupDisplay = new System.Windows.Forms.GroupBox();
			radioDisplayBoth = new System.Windows.Forms.RadioButton();
			radioDisplayMetric = new System.Windows.Forms.RadioButton();
			radioDisplayEnglish = new System.Windows.Forms.RadioButton();
			groupLogging = new System.Windows.Forms.GroupBox();
			lblTimeElapsed = new System.Windows.Forms.Label();
			scrollTime = new System.Windows.Forms.HScrollBar();
			btnReset = new System.Windows.Forms.Button();
			btnStart = new System.Windows.Forms.Button();
			btnSave = new System.Windows.Forms.Button();
			panelDisplay = new System.Windows.Forms.Panel();
			groupSelections.SuspendLayout();
			groupDisplay.SuspendLayout();
			groupLogging.SuspendLayout();
			SuspendLayout();
			// 
			// listSensors
			// 
			listSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			listSensors.CheckOnClick = true;
			listSensors.Location = new System.Drawing.Point(12, 25);
			listSensors.Name = "listSensors";
			listSensors.Size = new System.Drawing.Size(249, 64);
			listSensors.TabIndex = 0;
			listSensors.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(listSensors_ItemCheck);
			// 
			// groupSelections
			// 
			groupSelections.Controls.Add(listSensors);
			groupSelections.Location = new System.Drawing.Point(15, 15);
			groupSelections.Name = "groupSelections";
			groupSelections.Size = new System.Drawing.Size(273, 105);
			groupSelections.TabIndex = 0;
			groupSelections.TabStop = false;
			groupSelections.Text = "&Sensors";
			// 
			// groupDisplay
			// 
			groupDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			groupDisplay.Controls.Add(radioDisplayBoth);
			groupDisplay.Controls.Add(radioDisplayMetric);
			groupDisplay.Controls.Add(radioDisplayEnglish);
			groupDisplay.Location = new System.Drawing.Point(296, 15);
			groupDisplay.Name = "groupDisplay";
			groupDisplay.Size = new System.Drawing.Size(82, 105);
			groupDisplay.TabIndex = 1;
			groupDisplay.TabStop = false;
			groupDisplay.Text = "&Units";
			// 
			// radioDisplayBoth
			// 
			radioDisplayBoth.Enabled = false;
			radioDisplayBoth.Location = new System.Drawing.Point(16, 72);
			radioDisplayBoth.Name = "radioDisplayBoth";
			radioDisplayBoth.Size = new System.Drawing.Size(50, 20);
			radioDisplayBoth.TabIndex = 2;
			radioDisplayBoth.Text = "&Both";
			radioDisplayBoth.Visible = false;
			radioDisplayBoth.Click += new System.EventHandler(radioDisplayBoth_Click);
			// 
			// radioDisplayMetric
			// 
			radioDisplayMetric.Location = new System.Drawing.Point(16, 48);
			radioDisplayMetric.Name = "radioDisplayMetric";
			radioDisplayMetric.Size = new System.Drawing.Size(56, 20);
			radioDisplayMetric.TabIndex = 1;
			radioDisplayMetric.Text = "&Metric";
			radioDisplayMetric.Click += new System.EventHandler(radioDisplayMetric_Click);
			// 
			// radioDisplayEnglish
			// 
			radioDisplayEnglish.Checked = true;
			radioDisplayEnglish.Location = new System.Drawing.Point(16, 24);
			radioDisplayEnglish.Name = "radioDisplayEnglish";
			radioDisplayEnglish.Size = new System.Drawing.Size(64, 20);
			radioDisplayEnglish.TabIndex = 0;
			radioDisplayEnglish.TabStop = true;
			radioDisplayEnglish.Text = "E&nglish";
			radioDisplayEnglish.Click += new System.EventHandler(radioDisplayEnglish_Click);
			// 
			// groupLogging
			// 
			groupLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			groupLogging.Controls.Add(lblTimeElapsed);
			groupLogging.Controls.Add(scrollTime);
			groupLogging.Controls.Add(btnReset);
			groupLogging.Controls.Add(btnStart);
			groupLogging.Controls.Add(btnSave);
			groupLogging.Location = new System.Drawing.Point(386, 15);
			groupLogging.Name = "groupLogging";
			groupLogging.Size = new System.Drawing.Size(216, 105);
			groupLogging.TabIndex = 2;
			groupLogging.TabStop = false;
			groupLogging.Text = "&Control";
			// 
			// lblTimeElapsed
			// 
			lblTimeElapsed.Location = new System.Drawing.Point(17, 20);
			lblTimeElapsed.Name = "lblTimeElapsed";
			lblTimeElapsed.Size = new System.Drawing.Size(185, 19);
			lblTimeElapsed.TabIndex = 0;
			lblTimeElapsed.Text = "00:00:00.00";
			lblTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scrollTime
			// 
			scrollTime.Location = new System.Drawing.Point(17, 43);
			scrollTime.Name = "scrollTime";
			scrollTime.Size = new System.Drawing.Size(187, 17);
			scrollTime.TabIndex = 4;
			scrollTime.Scroll += new System.Windows.Forms.ScrollEventHandler(scrollTime_Scroll);
			// 
			// btnReset
			// 
			btnReset.Enabled = false;
			btnReset.Location = new System.Drawing.Point(80, 67);
			btnReset.Name = "btnReset";
			btnReset.Size = new System.Drawing.Size(60, 23);
			btnReset.TabIndex = 2;
			btnReset.Text = "&Reset";
			btnReset.Click += new System.EventHandler(btnReset_Click);
			// 
			// btnStart
			// 
			btnStart.Location = new System.Drawing.Point(16, 67);
			btnStart.Name = "btnStart";
			btnStart.Size = new System.Drawing.Size(60, 23);
			btnStart.TabIndex = 1;
			btnStart.Text = "S&tart";
			btnStart.Click += new System.EventHandler(btnStart_Click);
			// 
			// btnSave
			// 
			btnSave.Enabled = false;
			btnSave.Location = new System.Drawing.Point(144, 67);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(60, 23);
			btnSave.TabIndex = 3;
			btnSave.Text = "&Save";
			btnSave.Click += new System.EventHandler(btnSave_Click);
			// 
			// panelDisplay
			// 
			panelDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			panelDisplay.AutoScroll = true;
			panelDisplay.BackColor = System.Drawing.Color.Black;
			panelDisplay.Location = new System.Drawing.Point(15, 129);
			panelDisplay.Name = "panelDisplay";
			panelDisplay.Size = new System.Drawing.Size(587, 244);
			panelDisplay.TabIndex = 3;
			// 
			// SensorMonitorForm
			// 
			AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			ClientSize = new System.Drawing.Size(616, 388);
			ControlBox = false;
			Controls.Add(panelDisplay);
			Controls.Add(groupDisplay);
			Controls.Add(groupSelections);
			Controls.Add(groupLogging);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Name = "SensorMonitorForm";
			Text = "Live Sensor Grid";
			WindowState = System.Windows.Forms.FormWindowState.Maximized;
			Activated += new System.EventHandler(SensorMonitorForm_Activated);
			Load += new System.EventHandler(SensorMonitorForm_Load);
			Resize += new System.EventHandler(SensorMonitorForm_Resize);
			groupSelections.ResumeLayout(false);
			groupDisplay.ResumeLayout(false);
			groupLogging.ResumeLayout(false);
			ResumeLayout(false);

		}

		public void ReceiveResponse(OBD2Response obd2Response)
		{
		}

		public void CheckConnection()
		{
			if (m_obdInterface.getConnectedStatus())
			{
				groupDisplay.Enabled = true;
				groupSelections.Enabled = true;
				groupLogging.Enabled = true;
				if (bLogging)
				{
					btnStart.Enabled = false;
					btnStart.Text = "R&esume";
					btnReset.Enabled = true;
					btnSave.Enabled = true;
				}
				else
				{
					btnStart.Enabled = true;
					btnStart.Text = "S&tart";
					listSensors.Enabled = true;
					btnReset.Enabled = false;
					btnSave.Enabled = false;
				}
				listSensors.Items.Clear();
				IEnumerator enumerator = m_obdInterface.getSupportedParameterList(1).GetEnumerator();
				if (!enumerator.MoveNext())
					return;
				do
				{
					((ListBox.ObjectCollection)listSensors.Items).Add(enumerator.Current);
				}
				while (enumerator.MoveNext());
			}
			else
			{
				listSensors.Items.Clear();
				groupDisplay.Enabled = false;
				groupSelections.Enabled = false;
				groupLogging.Enabled = false;
			}
		}

		private void SensorMonitorForm_Resize(object sender, EventArgs e)
		{
			int index = 0;
			if (0 < panelDisplay.Controls.Count)
			{
				do
				{
					Control control = panelDisplay.Controls[index];
					control.Width = panelDisplay.Width / 2 - 8;
					if (index % 2 != 0)
					{
						control.Location = new Point(panelDisplay.Width / 2 + 3, (control.Height + 5) * (index / 2) + 5);
					}
					else
					{
						control.Location = new Point(0, (control.Height + 5) * (index / 2) + 5);
					}
					++index;
				}
				while (index < panelDisplay.Controls.Count);
			}
			groupSelections.Width = Width - 350;
			panelDisplay.Refresh();
		}

		private void SensorMonitorForm_Load(object sender, EventArgs e)
		{
			CheckConnection();
			ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateThread));
		}

		private static int getLongestField(DataGrid grid, int iCol)
		{
			int num2 = 60;
			int count = ((ArrayList)grid.DataSource).Count;

			Graphics graphics = grid.CreateGraphics();
			int num5 = Convert.ToInt32(Math.Ceiling((double)graphics.MeasureString(" ", grid.Font).Width));
			int num = 0;
			if (0 < count)
			{
				do
				{
					string text = grid[num, iCol].ToString();
					int num3 = Convert.ToInt32(Math.Ceiling((double)graphics.MeasureString(text, grid.Font).Width));
					if (num3 > num2)
					{
						num2 = num3;
					}
					num++;
				}
				while (num < count);
			}
			return (num5 + num2);
		}

		private void radioDisplayEnglish_Click(object sender, EventArgs e)
		{
			RebuildSensorGrid();
		}

		private void radioDisplayMetric_Click(object sender, EventArgs e)
		{
			RebuildSensorGrid();
		}

		private void radioDisplayBoth_Click(object sender, EventArgs e)
		{
			RebuildSensorGrid();
		}

		private void listSensors_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			SensorMonitorForm.m_arrayListSensors.Clear();
			int index1 = 0;
			if (0 < listSensors.CheckedIndices.Count)
			{
				do
				{
					int index2 = listSensors.CheckedIndices[index1];
					if (index2 != e.Index)
						SensorMonitorForm.m_arrayListSensors.Add(listSensors.Items[index2]);
					++index1;
				}
				while (index1 < listSensors.CheckedIndices.Count);
			}
			if (e.CurrentValue == CheckState.Unchecked)
				SensorMonitorForm.m_arrayListSensors.Add(listSensors.Items[e.Index]);
			RebuildSensorGrid();
		}

		private void UpdateThread(object state)
		{
			if (!bRunThread)
				return;
			do
			{
				if (m_obdInterface.getConnectedStatus() && bLogging)
				{
					IEnumerator enumerator = panelDisplay.Controls.GetEnumerator();
					if (enumerator.MoveNext())
					{
						do
						{
							SensorDisplayControl sensorDisplayControl = (SensorDisplayControl)enumerator.Current;
							OBDParameter obdParameter = (OBDParameter)sensorDisplayControl.Tag;
							OBDParameterValue obdParameterValue = m_obdInterface.getValue(obdParameter, radioDisplayEnglish.Checked);
							if (!obdParameterValue.ErrorDetected)
							{
								string str = obdParameter.EnglishUnitLabel;
								if (!radioDisplayEnglish.Checked)
									str = obdParameter.MetricUnitLabel;
								double num1 = obdParameterValue.DoubleValue;
								double num2 = obdParameterValue.DoubleValue;
								SensorLogItem sensorLogItem = new SensorLogItem(obdParameter.Name, num2.ToString(), str, num1.ToString(), str);
								SensorMonitorForm.m_arrayListLog.Add((object)sensorLogItem);
								scrollTime.Maximum = SensorMonitorForm.m_arrayListLog.Count - 1;
								scrollTime.Value = scrollTime.Maximum;
								DateTime dateTime = new DateTime();
								dateTime = new DateTime(0L);
								TimeSpan timeSpan = sensorLogItem.Time.Subtract(m_dtStartTime);
								lblTimeElapsed.Text = dateTime.Add(timeSpan).ToString("mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
								if (radioDisplayEnglish.Checked)
								{
									double num3 = obdParameterValue.DoubleValue;
									sensorDisplayControl.EnglishDisplay = num3.ToString() + " " + obdParameter.EnglishUnitLabel;
								}
								else
								{
									double num3 = obdParameterValue.DoubleValue;
									sensorDisplayControl.MetricDisplay = num3.ToString() + " " + obdParameter.MetricUnitLabel;
								}
							}
						}
						while (enumerator.MoveNext());
					}
				}
				else
					Thread.Sleep(300);
			}
			while (bRunThread);
		}

		private void RebuildSensorGrid()
		{
			panelDisplay.Controls.Clear();
			IEnumerator enumerator = SensorMonitorForm.m_arrayListSensors.GetEnumerator();
			int num = 0;
			if (!enumerator.MoveNext())
				return;
			do
			{
				OBDParameter obdParameter = (OBDParameter)enumerator.Current;
				SensorDisplayControl sensorDisplayControl = new SensorDisplayControl();
				sensorDisplayControl.Title = obdParameter.Name;
				sensorDisplayControl.Size = new Size(panelDisplay.Width / 2 - 8, 65);
				sensorDisplayControl.Tag = (object)obdParameter;
				if (radioDisplayEnglish.Checked)
					sensorDisplayControl.SetDisplayMode(1);
				else
					sensorDisplayControl.SetDisplayMode(2);
				sensorDisplayControl.Refresh();
				if (num % 2 != 0)
				{
					sensorDisplayControl.Location = new Point(panelDisplay.Width / 2 + 3, (sensorDisplayControl.Height + 5) * (num / 2) + 5);
				}
				else
				{
					sensorDisplayControl.Location = new Point(5, (sensorDisplayControl.Height + 5) * (num / 2) + 5);
				}
				panelDisplay.Controls.Add((Control)sensorDisplayControl);
				++num;
			}
			while (enumerator.MoveNext());
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			bLogging = !bLogging;
			if (string.Compare(btnStart.Text, "S&tart") == 0)
			{
				m_dtStartTime = DateTime.Now;
				listSensors.Enabled = false;
				groupDisplay.Enabled = false;
			}
			if (bLogging)
			{
				scrollTime.Enabled = false;
				btnStart.Text = "&Pause";
				btnSave.Enabled = false;
				btnReset.Enabled = false;
			}
			else
			{
				btnStart.Text = "R&esume";
				scrollTime.Enabled = true;
				btnReset.Enabled = true;
				btnSave.Enabled = true;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (m_arrayListLog.Count != 0)
			{
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.Title = "Save Logged Data As";
				dialog.Filter = "Comma-separated values (*.csv)|*.csv|XML (*.xml)|*.xml";
				dialog.FilterIndex = 0;
				dialog.RestoreDirectory = true;
				dialog.ShowDialog();
				if (dialog.FileName != "")
				{
					if (dialog.FileName.EndsWith(".xml"))
					{
						Type[] typeArray = new Type[] { typeof(SensorLogItem), typeof(Sensor) };
						TextWriter writer2 = new StreamWriter(dialog.FileName);
						new XmlSerializer(typeof(ArrayList), typeArray).Serialize(writer2, m_arrayListLog);
						writer2.Close();
					}
					else
					{
						ArrayList list = new ArrayList();
						int num2 = 0;
						if (0 < m_arrayListLog.Count)
						{
							do
							{
								string str = "";
								SensorLogItem item = m_arrayListLog[num2] as SensorLogItem;
								str = (((((str + item.Time.ToString("MM-dd-yyyy hh:mm:ss.fff", DateTimeFormatInfo.InvariantInfo) + ", ") + item.Name + ", ") + item.EnglishDisplay + ", ") + item.EnglishUnits + ", ") + item.MetricDisplay + ", ") + item.MetricUnits;
								list.Add(str);
								num2++;
							}
							while (num2 < m_arrayListLog.Count);
						}
						FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
						StreamWriter writer = new StreamWriter(stream);
						int num = 0;
						if (0 < list.Count)
						{
							do
							{
								writer.WriteLine(list[num] as string);
								num++;
							}
							while (num < list.Count);
						}
						writer.Close();
						stream.Close();
					}
				}
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			btnReset.Enabled = false;
			btnSave.Enabled = false;
			btnStart.Enabled = true;
			btnStart.Text = "S&tart";
			listSensors.Enabled = true;
			groupDisplay.Enabled = true;
			SensorMonitorForm.m_arrayListLog.Clear();
			lblTimeElapsed.Text = "00:00.000";
			scrollTime.Enabled = false;
			int index = 0;
			if (0 >= panelDisplay.Controls.Count)
				return;
			do
			{
				SensorDisplayControl sensorDisplayControl = (SensorDisplayControl)panelDisplay.Controls[index];
				sensorDisplayControl.EnglishDisplay = "";
				sensorDisplayControl.MetricDisplay = "";
				++index;
			}
			while (index < panelDisplay.Controls.Count);
		}

		private void scrollTime_Scroll(object sender, ScrollEventArgs e)
		{
			int index1 = scrollTime.Value;
			if (index1 < 0 || scrollTime.Value >= SensorMonitorForm.m_arrayListLog.Count)
				return;
			SensorLogItem sensorLogItem1 = (SensorLogItem)SensorMonitorForm.m_arrayListLog[index1];
			DateTime dateTime = new DateTime(0L);
			TimeSpan timeSpan = sensorLogItem1.Time.Subtract(m_dtStartTime);
			lblTimeElapsed.Text = dateTime.Add(timeSpan).ToString("mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
			int num = 0;
			if (0 >= SensorMonitorForm.m_arrayListSensors.Count)
				return;
			int index2 = index1;
			do
			{
				if (index2 >= 0)
				{
					SensorLogItem sensorLogItem2 = (SensorLogItem)SensorMonitorForm.m_arrayListLog[index2];
					int index3 = 0;
					if (0 < panelDisplay.Controls.Count)
					{
						do
						{
							SensorDisplayControl sensorDisplayControl = (SensorDisplayControl)panelDisplay.Controls[index3];
							if (string.Compare(sensorDisplayControl.Title, sensorLogItem2.Name) == 0)
							{
								sensorDisplayControl.EnglishDisplay = sensorLogItem2.EnglishDisplay + " " + sensorLogItem2.EnglishUnits;
								sensorDisplayControl.MetricDisplay = sensorLogItem2.MetricDisplay + " " + sensorLogItem2.MetricUnits;
							}
							++index3;
						}
						while (index3 < panelDisplay.Controls.Count);
					}
				}
				++num;
				--index2;
			}
			while (num < SensorMonitorForm.m_arrayListSensors.Count);
		}

		private void SensorMonitorForm_Activated(object sender, EventArgs e)
		{
			CheckConnection();
		}

		public void PauseLogging()
		{
			bLogging = false;
			btnStart.Text = "R&esume";
			scrollTime.Enabled = true;
			btnReset.Enabled = true;
			btnSave.Enabled = true;
		}
	}
}