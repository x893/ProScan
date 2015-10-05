using System;
using System.Collections;
using System.Collections.Generic;
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
		private static List<OBDParameter> m_ListSensors;
		private static List<SensorLogItem> m_ListLog;

		public bool IsLogging;
		public bool IsRunThread;

		public SensorMonitorForm(OBDInterface obd2)
		{
			try
			{
				InitializeComponent();
				m_obdInterface = obd2;
				IsLogging = false;
				btnStart.Enabled = false;
				btnReset.Enabled = false;
				btnSave.Enabled = false;
				IsRunThread = true;
				m_ListSensors = new List<OBDParameter>();
				m_ListLog = new List<SensorLogItem>();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public new void Close()
		{
			IsLogging = false;
			IsRunThread = false;
			base.Close();
		}

		#region InitializeComponent
		private CheckedListBox listSensors;
		private GroupBox groupSelections;
		private OBDInterface m_obdInterface;
		private DateTime m_dtStartTime;
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

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.listSensors = new System.Windows.Forms.CheckedListBox();
			this.groupSelections = new System.Windows.Forms.GroupBox();
			this.groupDisplay = new System.Windows.Forms.GroupBox();
			this.radioDisplayBoth = new System.Windows.Forms.RadioButton();
			this.radioDisplayMetric = new System.Windows.Forms.RadioButton();
			this.radioDisplayEnglish = new System.Windows.Forms.RadioButton();
			this.groupLogging = new System.Windows.Forms.GroupBox();
			this.lblTimeElapsed = new System.Windows.Forms.Label();
			this.scrollTime = new System.Windows.Forms.HScrollBar();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.panelDisplay = new System.Windows.Forms.Panel();
			this.groupSelections.SuspendLayout();
			this.groupDisplay.SuspendLayout();
			this.groupLogging.SuspendLayout();
			this.SuspendLayout();
			// 
			// listSensors
			// 
			this.listSensors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listSensors.CheckOnClick = true;
			this.listSensors.Location = new System.Drawing.Point(14, 29);
			this.listSensors.Name = "listSensors";
			this.listSensors.Size = new System.Drawing.Size(299, 55);
			this.listSensors.TabIndex = 0;
			this.listSensors.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listSensors_ItemCheck);
			// 
			// groupSelections
			// 
			this.groupSelections.Controls.Add(this.listSensors);
			this.groupSelections.Location = new System.Drawing.Point(18, 17);
			this.groupSelections.Name = "groupSelections";
			this.groupSelections.Size = new System.Drawing.Size(328, 121);
			this.groupSelections.TabIndex = 0;
			this.groupSelections.TabStop = false;
			this.groupSelections.Text = "&Sensors";
			// 
			// groupDisplay
			// 
			this.groupDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupDisplay.Controls.Add(this.radioDisplayBoth);
			this.groupDisplay.Controls.Add(this.radioDisplayMetric);
			this.groupDisplay.Controls.Add(this.radioDisplayEnglish);
			this.groupDisplay.Location = new System.Drawing.Point(232, 17);
			this.groupDisplay.Name = "groupDisplay";
			this.groupDisplay.Size = new System.Drawing.Size(99, 121);
			this.groupDisplay.TabIndex = 1;
			this.groupDisplay.TabStop = false;
			this.groupDisplay.Text = "&Units";
			// 
			// radioDisplayBoth
			// 
			this.radioDisplayBoth.Enabled = false;
			this.radioDisplayBoth.Location = new System.Drawing.Point(19, 83);
			this.radioDisplayBoth.Name = "radioDisplayBoth";
			this.radioDisplayBoth.Size = new System.Drawing.Size(60, 23);
			this.radioDisplayBoth.TabIndex = 2;
			this.radioDisplayBoth.Text = "&Both";
			this.radioDisplayBoth.Visible = false;
			this.radioDisplayBoth.Click += new System.EventHandler(this.radioDisplayBoth_Click);
			// 
			// radioDisplayMetric
			// 
			this.radioDisplayMetric.Location = new System.Drawing.Point(19, 55);
			this.radioDisplayMetric.Name = "radioDisplayMetric";
			this.radioDisplayMetric.Size = new System.Drawing.Size(67, 23);
			this.radioDisplayMetric.TabIndex = 1;
			this.radioDisplayMetric.Text = "&Metric";
			this.radioDisplayMetric.Click += new System.EventHandler(this.radioDisplayMetric_Click);
			// 
			// radioDisplayEnglish
			// 
			this.radioDisplayEnglish.Checked = true;
			this.radioDisplayEnglish.Location = new System.Drawing.Point(19, 28);
			this.radioDisplayEnglish.Name = "radioDisplayEnglish";
			this.radioDisplayEnglish.Size = new System.Drawing.Size(77, 23);
			this.radioDisplayEnglish.TabIndex = 0;
			this.radioDisplayEnglish.TabStop = true;
			this.radioDisplayEnglish.Text = "E&nglish";
			this.radioDisplayEnglish.Click += new System.EventHandler(this.radioDisplayEnglish_Click);
			// 
			// groupLogging
			// 
			this.groupLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupLogging.Controls.Add(this.lblTimeElapsed);
			this.groupLogging.Controls.Add(this.scrollTime);
			this.groupLogging.Controls.Add(this.btnReset);
			this.groupLogging.Controls.Add(this.btnStart);
			this.groupLogging.Controls.Add(this.btnSave);
			this.groupLogging.Location = new System.Drawing.Point(340, 17);
			this.groupLogging.Name = "groupLogging";
			this.groupLogging.Size = new System.Drawing.Size(259, 121);
			this.groupLogging.TabIndex = 2;
			this.groupLogging.TabStop = false;
			this.groupLogging.Text = "&Control";
			// 
			// lblTimeElapsed
			// 
			this.lblTimeElapsed.Location = new System.Drawing.Point(20, 23);
			this.lblTimeElapsed.Name = "lblTimeElapsed";
			this.lblTimeElapsed.Size = new System.Drawing.Size(222, 22);
			this.lblTimeElapsed.TabIndex = 0;
			this.lblTimeElapsed.Text = "00:00:00.00";
			this.lblTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scrollTime
			// 
			this.scrollTime.Location = new System.Drawing.Point(20, 50);
			this.scrollTime.Name = "scrollTime";
			this.scrollTime.Size = new System.Drawing.Size(225, 19);
			this.scrollTime.TabIndex = 4;
			this.scrollTime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollTime_Scroll);
			// 
			// btnReset
			// 
			this.btnReset.Enabled = false;
			this.btnReset.Location = new System.Drawing.Point(96, 77);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(72, 27);
			this.btnReset.TabIndex = 2;
			this.btnReset.Text = "&Reset";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(19, 77);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(72, 27);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "S&tart";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnSave
			// 
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(173, 77);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 27);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panelDisplay
			// 
			this.panelDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelDisplay.AutoScroll = true;
			this.panelDisplay.BackColor = System.Drawing.Color.Black;
			this.panelDisplay.Location = new System.Drawing.Point(18, 149);
			this.panelDisplay.Name = "panelDisplay";
			this.panelDisplay.Size = new System.Drawing.Size(581, 221);
			this.panelDisplay.TabIndex = 3;
			// 
			// SensorMonitorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(616, 388);
			this.ControlBox = false;
			this.Controls.Add(this.panelDisplay);
			this.Controls.Add(this.groupDisplay);
			this.Controls.Add(this.groupSelections);
			this.Controls.Add(this.groupLogging);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SensorMonitorForm";
			this.Text = "Live Sensor Grid";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Activated += new System.EventHandler(this.SensorMonitorForm_Activated);
			this.Load += new System.EventHandler(this.SensorMonitorForm_Load);
			this.Resize += new System.EventHandler(this.SensorMonitorForm_Resize);
			this.groupSelections.ResumeLayout(false);
			this.groupDisplay.ResumeLayout(false);
			this.groupLogging.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void CheckConnection()
		{
			if (m_obdInterface.ConnectedStatus)
			{
				groupDisplay.Enabled = true;
				groupSelections.Enabled = true;
				groupLogging.Enabled = true;
				if (IsLogging)
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
				foreach(OBDParameter obdParameter in m_obdInterface.SupportedParameterList(1))
					listSensors.Items.Add(obdParameter);
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
			while (index < panelDisplay.Controls.Count)
			{
				Control control = panelDisplay.Controls[index];
				control.Width = panelDisplay.Width / 2 - 8;
				if (index % 2 != 0)
					control.Location = new Point(panelDisplay.Width / 2 + 3, (control.Height + 5) * (index / 2) + 5);
				else
					control.Location = new Point(0, (control.Height + 5) * (index / 2) + 5);
				++index;
			}
			groupSelections.Width = Width - 350;
			panelDisplay.Refresh();
		}

		private void SensorMonitorForm_Load(object sender, EventArgs e)
		{
			CheckConnection();
			ThreadPool.QueueUserWorkItem(new WaitCallback(UpdateThread));
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
			SensorMonitorForm.m_ListSensors.Clear();
			int index1 = 0;
			if (0 < listSensors.CheckedIndices.Count)
			{
				do
				{
					int index2 = listSensors.CheckedIndices[index1];
					if (index2 != e.Index)
						m_ListSensors.Add((OBDParameter)listSensors.Items[index2]);
					++index1;
				}
				while (index1 < listSensors.CheckedIndices.Count);
			}
			if (e.CurrentValue == CheckState.Unchecked)
				m_ListSensors.Add((OBDParameter)listSensors.Items[e.Index]);
			RebuildSensorGrid();
		}

		private void UpdateThread(object state)
		{
			while (IsRunThread)
			{
				if (m_obdInterface.ConnectedStatus && IsLogging)
				{
					foreach (SensorDisplayControl control in panelDisplay.Controls)
					{
						OBDParameter param = (OBDParameter)control.Tag;
						OBDParameterValue value = m_obdInterface.getValue(param, radioDisplayEnglish.Checked);
						if (!value.ErrorDetected)
						{
							string text = param.EnglishUnitLabel;
							if (!radioDisplayEnglish.Checked)
								text = param.MetricUnitLabel;

							SensorLogItem sensorLogItem = new SensorLogItem(
								param.Name,
								value.DoubleValue.ToString(),
								text,
								value.DoubleValue.ToString(),
								text);
							m_ListLog.Add(sensorLogItem);
							scrollTime.Maximum = m_ListLog.Count - 1;
							scrollTime.Value = scrollTime.Maximum;

							DateTime dateTime = new DateTime(0L);
							lblTimeElapsed.Text = dateTime.Add(sensorLogItem.Time.Subtract(m_dtStartTime)).ToString("mm:ss.fff", DateTimeFormatInfo.InvariantInfo);

							text = value.DoubleValue.ToString();
							if (radioDisplayEnglish.Checked)
								control.EnglishDisplay = text + " " + param.EnglishUnitLabel;
							else
								control.MetricDisplay = text + " " + param.MetricUnitLabel;
						}
					}
				}
				else
					Thread.Sleep(300);
			}
		}

		private void RebuildSensorGrid()
		{
			panelDisplay.Controls.Clear();
			int index = 0;
			foreach (OBDParameter param in SensorMonitorForm.m_ListSensors)
			{
				SensorDisplayControl control = new SensorDisplayControl();
				control.Title = param.Name;
				control.Size = new Size(panelDisplay.Width / 2 - 8, 65);
				control.Tag = param;
				if (radioDisplayEnglish.Checked)
					control.SetDisplayMode(1);
				else
					control.SetDisplayMode(2);

				control.Refresh();

				if (index % 2 != 0)
					control.Location = new Point(panelDisplay.Width / 2 + 3, (control.Height + 5) * (index / 2) + 5);
				else
					control.Location = new Point(5, (control.Height + 5) * (index / 2) + 5);

				panelDisplay.Controls.Add((Control)control);
				++index;
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			IsLogging = !IsLogging;
			if (string.Compare(btnStart.Text, "S&tart") == 0)
			{
				m_dtStartTime = DateTime.Now;
				listSensors.Enabled = false;
				groupDisplay.Enabled = false;
			}
			if (IsLogging)
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
			if (m_ListLog.Count != 0)
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
						using (TextWriter writer = new StreamWriter(dialog.FileName))
						{
							new XmlSerializer(typeof(List<SensorLogItem>), typeArray).Serialize(writer, m_ListLog);
							writer.Close();
						}
					}
					else
					{
						List<string> list = new List<string>();
						int num2 = 0;
						while (num2 < m_ListLog.Count)
						{
							SensorLogItem item = m_ListLog[num2];
							string str =
								item.Time.ToString("MM-dd-yyyy hh:mm:ss.fff", DateTimeFormatInfo.InvariantInfo) + ", "
								+ item.Name + ", "
								+ item.EnglishDisplay + ", "
								+ item.EnglishUnits + ", "
								+ item.MetricDisplay + ", "
								+ item.MetricUnits;
							list.Add(str);
							num2++;
						}
						FileStream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
						StreamWriter writer = new StreamWriter(stream);
						int num = 0;
						while (num < list.Count)
						{
							writer.WriteLine(list[num]);
							num++;
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
			m_ListLog.Clear();
			lblTimeElapsed.Text = "00:00.000";
			scrollTime.Enabled = false;

			int index = 0;
			while (index < panelDisplay.Controls.Count)
			{
				SensorDisplayControl control = (SensorDisplayControl)panelDisplay.Controls[index];
				control.EnglishDisplay = "";
				control.MetricDisplay = "";
				++index;
			}
		}

		private void scrollTime_Scroll(object sender, ScrollEventArgs e)
		{
			int index1 = scrollTime.Value;
			if (index1 < 0 || scrollTime.Value >= m_ListLog.Count)
				return;

			SensorLogItem log_item = m_ListLog[index1];
			DateTime dateTime = new DateTime(0L);
			TimeSpan timeSpan = log_item.Time.Subtract(m_dtStartTime);
			lblTimeElapsed.Text = dateTime.Add(timeSpan).ToString("mm:ss.fff", DateTimeFormatInfo.InvariantInfo);
			int num = 0;
			if (0 >= SensorMonitorForm.m_ListSensors.Count)
				return;
			int index2 = index1;
			do
			{
				if (index2 >= 0)
				{
					SensorLogItem sensorLogItem2 = m_ListLog[index2];
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
			while (num < SensorMonitorForm.m_ListSensors.Count);
		}

		private void SensorMonitorForm_Activated(object sender, EventArgs e)
		{
			CheckConnection();
		}

		public void PauseLogging()
		{
			IsLogging = false;
			btnStart.Text = "R&esume";
			scrollTime.Enabled = true;
			btnReset.Enabled = true;
			btnSave.Enabled = true;
		}
	}
}