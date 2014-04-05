using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProScan
{
	public class MainForm : Form
	{
		private CommForm m_formStart;
		private TestForm m_formMonitorTests;
		private DTCForm m_formDTC;
		private FreezeFramesForm m_formFreezeFrames;
		private OxygenSensorsForm m_formOxygenSensors;
		private SensorMonitorForm m_formSensorGrid;
		private ScopeForm m_formSensorChart;
		private TrackForm m_formTrack;
		private DynoForm m_formDyno;
		private TerminalForm m_formTerminal;
		private ReportGeneratorForm m_formReport;
		private CommLogForm m_formCommLog;
		private FuelEconomyForm m_formFuelEconomy;
		private Form m_formActive;

		public MainForm()
		{
			InitializeComponent();
			m_obdInterface = new OBDInterface();
			m_obdInterface.OnConnect += new OBDInterface.__Delegate_OnConnect(On_OBD2_Connect);
			m_obdInterface.OnDisconnect += new OBDInterface.__Delegate_OnDisconnect(On_OBD2_Disconnect);
			if (m_obdInterface.GetActiveProfile() != null)
				panelVehicle.Text = m_obdInterface.GetActiveProfile().ToString();

			if (m_obdInterface.GetCommSettings() != null)
			{
				if (m_obdInterface.GetCommSettings().AutoDetect)
					panelComPort.Text = "Auto-Detect";
				else
					panelComPort.Text = "COM" + m_obdInterface.GetCommSettings().ComPort.ToString();
			}
			SetDescriptiveToolTips();
			m_formStart = new CommForm(m_obdInterface);
			m_formMonitorTests = new TestForm(m_obdInterface);
			m_formDTC = new DTCForm(m_obdInterface);
			m_formFreezeFrames = new FreezeFramesForm(m_obdInterface);
			m_formOxygenSensors = new OxygenSensorsForm(m_obdInterface);
			m_formSensorGrid = new SensorMonitorForm(m_obdInterface);
			m_formSensorChart = new ScopeForm(m_obdInterface);
			m_formTrack = new TrackForm(m_obdInterface);
			m_formDyno = new DynoForm(m_obdInterface);
			m_formFuelEconomy = new FuelEconomyForm(m_obdInterface);
			m_formTerminal = new TerminalForm(m_obdInterface);
			m_formReport = new ReportGeneratorForm(m_obdInterface);
			m_formCommLog = new CommLogForm();
			toolBarButtonStart.Pushed = true;
			SetActiveForm(m_formStart);
		}

		#region InitializeComponent()

		private IContainer components;
		private MainMenu mainMenu;
		private MenuItem menuItemFile;
		private MenuItem menuItemTools;
		private MenuItem menuItemToolbar;
		private MenuItem menuItemView;
		private MenuItem menuItemHideToolBar;
		private MenuItem menuItem4;
		private MenuItem menuItemDTC;
		private MenuItem menuItemTrack;
		private MenuItem menuItemDyno;
		private ToolBar toolBar;
		private ImageList imageList;
		private ContextMenu contextMenuToolBar;
		private StatusBar statusBar;
		private StatusBarPanel panelStatus;
		private StatusBarPanel panelVehicle;
		private StatusBarPanel panelComPort;
		private StatusBarPanel panelChipInfo;
		private StatusBarPanel panelTx;
		private StatusBarPanel panelRx;
		private StatusBarPanel panelConnectedIcon;
		private StatusBarPanel panelDisconnectedIcon;
		private OBDInterface m_obdInterface;
		private MenuItem menuItemCommLog;
		private ToolBarButton toolBarButtonFF;
		private ToolBarButton toolBarButtonDTC;
		private ToolBarButton toolBarButtonStart;
		private ToolBarButton toolBarButtonO2;
		private ToolBarButton toolBarButtonVehicles;
		private ToolBarButton toolBarButtonSep1;
		private ToolBarButton toolBarButtonSep2;
		private ToolBarButton toolBarButtonReport;
		private ToolBarButton toolBarButtonUserPrefs;
		private ToolBarButton toolBarButtonSettings;
		private ToolBarButton toolBarButtonSep3;
		private ToolBarButton toolBarButtonTests;
		private ToolBarButton toolBarButtonSensorGrid;
		private ToolBarButton toolBarButtonSensorGraph;
		private ToolBarButton toolBarButtonDyno;
		private ToolBarButton toolBarButtonTrack;
		private ToolBarButton toolBarButtonSep7;
		private ToolBarButton toolBarButtonSep8;
		private ToolBarButton toolBarButtonSep9;
		private MenuItem menuItemUserPrefs;
		private MenuItem menuItemVehicleProfiles;
		private MenuItem menuItemCommSettings;
		private MenuItem menuItemConnectionManager;
		private MenuItem menuItemSensorGrid;
		private MenuItem menuItemSensorGraphs;
		private MenuItem menuItem8;
		private MenuItem menuItemReport;
		private MenuItem menuItem9;
		private MenuItem menuItem10;
		private MenuItem menuItem11;
		private MenuItem menuItemStatusMonitor;
		private MenuItem menuItemFreezeFrame;
		private MenuItem menuItemOxygenSensors;
		private MenuItem menuItemTerminal;
		private ToolBarButton toolBarButtonTerminal;
		private ToolBarButton toolBarButtonSep10;
		private ToolBarButton toolBarButtonSep11;
		private ToolBarButton toolBarButtonSep12;
		private ToolBarButton toolBarButtonCommLog;
		private ToolBarButton toolBarButtonFuel;
		private ToolBarButton toolBarButtonDash;
		private MenuItem menuItemComLogging;
		private MenuItem menuItem3;
		private MenuItem menuItemCommLoggingOn;
		private MenuItem menuItemCommLoggingOff;
		private MenuItem menuItemExit;

		protected override void Dispose(bool disposing)
		{
			Monitor.Enter(m_obdInterface);
			if (m_obdInterface.getConnectedStatus())
				m_obdInterface.disconnect();
			Monitor.Exit(m_obdInterface);
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemUserPrefs = new System.Windows.Forms.MenuItem();
			this.menuItemVehicleProfiles = new System.Windows.Forms.MenuItem();
			this.menuItemCommSettings = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItemComLogging = new System.Windows.Forms.MenuItem();
			this.menuItemCommLoggingOn = new System.Windows.Forms.MenuItem();
			this.menuItemCommLoggingOff = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemView = new System.Windows.Forms.MenuItem();
			this.menuItemToolbar = new System.Windows.Forms.MenuItem();
			this.menuItemTools = new System.Windows.Forms.MenuItem();
			this.menuItemConnectionManager = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItemStatusMonitor = new System.Windows.Forms.MenuItem();
			this.menuItemDTC = new System.Windows.Forms.MenuItem();
			this.menuItemFreezeFrame = new System.Windows.Forms.MenuItem();
			this.menuItemOxygenSensors = new System.Windows.Forms.MenuItem();
			this.menuItemSensorGrid = new System.Windows.Forms.MenuItem();
			this.menuItemSensorGraphs = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItemTrack = new System.Windows.Forms.MenuItem();
			this.menuItemDyno = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItemReport = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItemTerminal = new System.Windows.Forms.MenuItem();
			this.menuItemCommLog = new System.Windows.Forms.MenuItem();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.toolBarButtonStart = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonTests = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonDTC = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonFF = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonO2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSensorGrid = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSensorGraph = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonDash = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonTrack = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonDyno = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonFuel = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep7 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep8 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep9 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonReport = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep10 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep11 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep12 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonTerminal = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonCommLog = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonUserPrefs = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonVehicles = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSettings = new System.Windows.Forms.ToolBarButton();
			this.contextMenuToolBar = new System.Windows.Forms.ContextMenu();
			this.menuItemHideToolBar = new System.Windows.Forms.MenuItem();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.panelStatus = new System.Windows.Forms.StatusBarPanel();
			this.panelVehicle = new System.Windows.Forms.StatusBarPanel();
			this.panelComPort = new System.Windows.Forms.StatusBarPanel();
			this.panelChipInfo = new System.Windows.Forms.StatusBarPanel();
			this.panelTx = new System.Windows.Forms.StatusBarPanel();
			this.panelRx = new System.Windows.Forms.StatusBarPanel();
			this.panelConnectedIcon = new System.Windows.Forms.StatusBarPanel();
			this.panelDisconnectedIcon = new System.Windows.Forms.StatusBarPanel();
			((System.ComponentModel.ISupportInitialize)(this.panelStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelVehicle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelComPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelChipInfo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelTx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelRx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelConnectedIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelDisconnectedIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemTools});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUserPrefs,
            this.menuItemVehicleProfiles,
            this.menuItemCommSettings,
            this.menuItem4,
            this.menuItemComLogging,
            this.menuItem3,
            this.menuItemExit});
			this.menuItemFile.Text = "&File";
			// 
			// menuItemUserPrefs
			// 
			this.menuItemUserPrefs.Index = 0;
			this.menuItemUserPrefs.Text = "&User Preferences";
			this.menuItemUserPrefs.Click += new System.EventHandler(this.menuItemUserPrefs_Click);
			// 
			// menuItemVehicleProfiles
			// 
			this.menuItemVehicleProfiles.Index = 1;
			this.menuItemVehicleProfiles.Text = "&Vehicle Profile Manager";
			this.menuItemVehicleProfiles.Click += new System.EventHandler(this.menuItemVehicleProfiles_Click);
			// 
			// menuItemCommSettings
			// 
			this.menuItemCommSettings.Index = 2;
			this.menuItemCommSettings.Text = "&Communication Settings";
			this.menuItemCommSettings.Click += new System.EventHandler(this.menuItemCommSettings_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "-";
			// 
			// menuItemComLogging
			// 
			this.menuItemComLogging.Index = 4;
			this.menuItemComLogging.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCommLoggingOn,
            this.menuItemCommLoggingOff});
			this.menuItemComLogging.Text = "Comm Logging";
			// 
			// menuItemCommLoggingOn
			// 
			this.menuItemCommLoggingOn.Index = 0;
			this.menuItemCommLoggingOn.Text = "On";
			this.menuItemCommLoggingOn.Click += new System.EventHandler(this.menuItemCommLoggingOn_Click);
			// 
			// menuItemCommLoggingOff
			// 
			this.menuItemCommLoggingOff.Checked = true;
			this.menuItemCommLoggingOff.Index = 1;
			this.menuItemCommLoggingOff.Text = "Off";
			this.menuItemCommLoggingOff.Click += new System.EventHandler(this.menuItemCommLoggingOff_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 5;
			this.menuItem3.Text = "-";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Index = 6;
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// menuItemView
			// 
			this.menuItemView.Index = 1;
			this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemToolbar});
			this.menuItemView.Text = "&View";
			this.menuItemView.Select += new System.EventHandler(this.menuItemView_Select);
			// 
			// menuItemToolbar
			// 
			this.menuItemToolbar.Checked = true;
			this.menuItemToolbar.Index = 0;
			this.menuItemToolbar.Text = "&Toolbar";
			this.menuItemToolbar.Click += new System.EventHandler(this.menuItemToolbar_Click);
			// 
			// menuItemTools
			// 
			this.menuItemTools.Index = 2;
			this.menuItemTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemConnectionManager,
            this.menuItem8,
            this.menuItemStatusMonitor,
            this.menuItemDTC,
            this.menuItemFreezeFrame,
            this.menuItemOxygenSensors,
            this.menuItemSensorGrid,
            this.menuItemSensorGraphs,
            this.menuItem9,
            this.menuItemTrack,
            this.menuItemDyno,
            this.menuItem10,
            this.menuItemReport,
            this.menuItem11,
            this.menuItemTerminal,
            this.menuItemCommLog});
			this.menuItemTools.Text = "&Tools";
			// 
			// menuItemConnectionManager
			// 
			this.menuItemConnectionManager.Index = 0;
			this.menuItemConnectionManager.Text = "Vehicle &Connection Manager";
			this.menuItemConnectionManager.Click += new System.EventHandler(this.menuItemConnectionManager_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.Text = "-";
			// 
			// menuItemStatusMonitor
			// 
			this.menuItemStatusMonitor.Index = 2;
			this.menuItemStatusMonitor.Text = "Vehicle Status &Monitor";
			this.menuItemStatusMonitor.Click += new System.EventHandler(this.menuItemTests_Click);
			// 
			// menuItemDTC
			// 
			this.menuItemDTC.Index = 3;
			this.menuItemDTC.Text = "Diagnostic &Trouble Codes";
			this.menuItemDTC.Click += new System.EventHandler(this.menuItemDTC_Click);
			// 
			// menuItemFreezeFrame
			// 
			this.menuItemFreezeFrame.Index = 4;
			this.menuItemFreezeFrame.Text = "&Freeze Frame Data";
			this.menuItemFreezeFrame.Click += new System.EventHandler(this.menuItemFreezeFrame_Click);
			// 
			// menuItemOxygenSensors
			// 
			this.menuItemOxygenSensors.Index = 5;
			this.menuItemOxygenSensors.Text = "&Oxygen Sensor Tests";
			this.menuItemOxygenSensors.Click += new System.EventHandler(this.menuItemOxygenSensors_Click);
			// 
			// menuItemSensorGrid
			// 
			this.menuItemSensorGrid.Index = 6;
			this.menuItemSensorGrid.Text = "Live &Sensor Grid";
			this.menuItemSensorGrid.Click += new System.EventHandler(this.menuItemSensorMonitor_Click);
			// 
			// menuItemSensorGraphs
			// 
			this.menuItemSensorGraphs.Index = 7;
			this.menuItemSensorGraphs.Text = "Live Sensor &Graphs";
			this.menuItemSensorGraphs.Click += new System.EventHandler(this.menuItemScope_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 8;
			this.menuItem9.Text = "-";
			// 
			// menuItemTrack
			// 
			this.menuItemTrack.Index = 9;
			this.menuItemTrack.Text = "&Race Track Analysis";
			this.menuItemTrack.Click += new System.EventHandler(this.menuItemTrack_Click);
			// 
			// menuItemDyno
			// 
			this.menuItemDyno.Index = 10;
			this.menuItemDyno.Text = "&Dynamometer";
			this.menuItemDyno.Click += new System.EventHandler(this.menuItemDyno_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 11;
			this.menuItem10.Text = "-";
			// 
			// menuItemReport
			// 
			this.menuItemReport.Index = 12;
			this.menuItemReport.Text = "&Diagnostic Report Generator";
			this.menuItemReport.Click += new System.EventHandler(this.menuItemReport_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 13;
			this.menuItem11.Text = "-";
			// 
			// menuItemTerminal
			// 
			this.menuItemTerminal.Index = 14;
			this.menuItemTerminal.Text = "T&erminal";
			this.menuItemTerminal.Click += new System.EventHandler(this.menuItemTerminal_Click);
			// 
			// menuItemCommLog
			// 
			this.menuItemCommLog.Index = 15;
			this.menuItemCommLog.Text = "&Communication Log";
			this.menuItemCommLog.Click += new System.EventHandler(this.menuItemCommLog_Click);
			// 
			// toolBar
			// 
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonStart,
            this.toolBarButtonTests,
            this.toolBarButtonDTC,
            this.toolBarButtonFF,
            this.toolBarButtonO2,
            this.toolBarButtonSensorGrid,
            this.toolBarButtonSensorGraph,
            this.toolBarButtonDash,
            this.toolBarButtonTrack,
            this.toolBarButtonDyno,
            this.toolBarButtonFuel,
            this.toolBarButtonSep7,
            this.toolBarButtonSep8,
            this.toolBarButtonSep9,
            this.toolBarButtonReport,
            this.toolBarButtonSep10,
            this.toolBarButtonSep11,
            this.toolBarButtonSep12,
            this.toolBarButtonTerminal,
            this.toolBarButtonCommLog,
            this.toolBarButtonSep1,
            this.toolBarButtonSep2,
            this.toolBarButtonSep3,
            this.toolBarButtonUserPrefs,
            this.toolBarButtonVehicles,
            this.toolBarButtonSettings});
			this.toolBar.ButtonSize = new System.Drawing.Size(24, 24);
			this.toolBar.ContextMenu = this.contextMenuToolBar;
			this.toolBar.Divider = false;
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList;
			this.toolBar.Location = new System.Drawing.Point(0, 0);
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(784, 34);
			this.toolBar.TabIndex = 1;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// toolBarButtonStart
			// 
			this.toolBarButtonStart.ImageIndex = 4;
			this.toolBarButtonStart.Name = "toolBarButtonStart";
			this.toolBarButtonStart.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.toolBarButtonStart.ToolTipText = "Connection Manager\\r\\nClick here to establish a connection.";
			// 
			// toolBarButtonTests
			// 
			this.toolBarButtonTests.ImageIndex = 9;
			this.toolBarButtonTests.Name = "toolBarButtonTests";
			this.toolBarButtonTests.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.toolBarButtonTests.ToolTipText = "Monitoring Test Results";
			// 
			// toolBarButtonDTC
			// 
			this.toolBarButtonDTC.ImageIndex = 1;
			this.toolBarButtonDTC.Name = "toolBarButtonDTC";
			this.toolBarButtonDTC.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonFF
			// 
			this.toolBarButtonFF.ImageIndex = 0;
			this.toolBarButtonFF.Name = "toolBarButtonFF";
			this.toolBarButtonFF.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonO2
			// 
			this.toolBarButtonO2.ImageIndex = 3;
			this.toolBarButtonO2.Name = "toolBarButtonO2";
			this.toolBarButtonO2.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonSensorGrid
			// 
			this.toolBarButtonSensorGrid.ImageIndex = 10;
			this.toolBarButtonSensorGrid.Name = "toolBarButtonSensorGrid";
			this.toolBarButtonSensorGrid.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonSensorGraph
			// 
			this.toolBarButtonSensorGraph.ImageIndex = 11;
			this.toolBarButtonSensorGraph.Name = "toolBarButtonSensorGraph";
			this.toolBarButtonSensorGraph.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonDash
			// 
			this.toolBarButtonDash.Name = "toolBarButtonDash";
			this.toolBarButtonDash.Visible = false;
			// 
			// toolBarButtonTrack
			// 
			this.toolBarButtonTrack.ImageIndex = 12;
			this.toolBarButtonTrack.Name = "toolBarButtonTrack";
			this.toolBarButtonTrack.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonDyno
			// 
			this.toolBarButtonDyno.ImageIndex = 13;
			this.toolBarButtonDyno.Name = "toolBarButtonDyno";
			this.toolBarButtonDyno.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonFuel
			// 
			this.toolBarButtonFuel.ImageIndex = 16;
			this.toolBarButtonFuel.Name = "toolBarButtonFuel";
			// 
			// toolBarButtonSep7
			// 
			this.toolBarButtonSep7.Name = "toolBarButtonSep7";
			this.toolBarButtonSep7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonSep8
			// 
			this.toolBarButtonSep8.Name = "toolBarButtonSep8";
			this.toolBarButtonSep8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonSep9
			// 
			this.toolBarButtonSep9.Name = "toolBarButtonSep9";
			this.toolBarButtonSep9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonReport
			// 
			this.toolBarButtonReport.ImageIndex = 6;
			this.toolBarButtonReport.Name = "toolBarButtonReport";
			this.toolBarButtonReport.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			// 
			// toolBarButtonSep10
			// 
			this.toolBarButtonSep10.Name = "toolBarButtonSep10";
			this.toolBarButtonSep10.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonSep11
			// 
			this.toolBarButtonSep11.Name = "toolBarButtonSep11";
			this.toolBarButtonSep11.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonSep12
			// 
			this.toolBarButtonSep12.Name = "toolBarButtonSep12";
			this.toolBarButtonSep12.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonTerminal
			// 
			this.toolBarButtonTerminal.ImageIndex = 14;
			this.toolBarButtonTerminal.Name = "toolBarButtonTerminal";
			// 
			// toolBarButtonCommLog
			// 
			this.toolBarButtonCommLog.ImageIndex = 15;
			this.toolBarButtonCommLog.Name = "toolBarButtonCommLog";
			// 
			// toolBarButtonSep1
			// 
			this.toolBarButtonSep1.Name = "toolBarButtonSep1";
			this.toolBarButtonSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonSep2
			// 
			this.toolBarButtonSep2.Name = "toolBarButtonSep2";
			this.toolBarButtonSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonSep3
			// 
			this.toolBarButtonSep3.Name = "toolBarButtonSep3";
			this.toolBarButtonSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonUserPrefs
			// 
			this.toolBarButtonUserPrefs.ImageIndex = 8;
			this.toolBarButtonUserPrefs.Name = "toolBarButtonUserPrefs";
			// 
			// toolBarButtonVehicles
			// 
			this.toolBarButtonVehicles.ImageIndex = 2;
			this.toolBarButtonVehicles.Name = "toolBarButtonVehicles";
			// 
			// toolBarButtonSettings
			// 
			this.toolBarButtonSettings.ImageIndex = 7;
			this.toolBarButtonSettings.Name = "toolBarButtonSettings";
			// 
			// contextMenuToolBar
			// 
			this.contextMenuToolBar.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemHideToolBar});
			// 
			// menuItemHideToolBar
			// 
			this.menuItemHideToolBar.Index = 0;
			this.menuItemHideToolBar.Text = "&Hide Toolbar";
			this.menuItemHideToolBar.Click += new System.EventHandler(this.menuItemHideToolBar_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "");
			this.imageList.Images.SetKeyName(1, "");
			this.imageList.Images.SetKeyName(2, "");
			this.imageList.Images.SetKeyName(3, "");
			this.imageList.Images.SetKeyName(4, "");
			this.imageList.Images.SetKeyName(5, "");
			this.imageList.Images.SetKeyName(6, "");
			this.imageList.Images.SetKeyName(7, "");
			this.imageList.Images.SetKeyName(8, "");
			this.imageList.Images.SetKeyName(9, "");
			this.imageList.Images.SetKeyName(10, "");
			this.imageList.Images.SetKeyName(11, "");
			this.imageList.Images.SetKeyName(12, "");
			this.imageList.Images.SetKeyName(13, "");
			this.imageList.Images.SetKeyName(14, "");
			this.imageList.Images.SetKeyName(15, "");
			this.imageList.Images.SetKeyName(16, "");
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 568);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.panelStatus,
            this.panelVehicle,
            this.panelComPort,
            this.panelChipInfo,
            this.panelTx,
            this.panelRx,
            this.panelConnectedIcon,
            this.panelDisconnectedIcon});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(784, 22);
			this.statusBar.TabIndex = 2;
			// 
			// panelStatus
			// 
			this.panelStatus.Icon = ((System.Drawing.Icon)(resources.GetObject("panelStatus.Icon")));
			this.panelStatus.MinWidth = 100;
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Text = "Disconnected";
			this.panelStatus.Width = 175;
			// 
			// panelVehicle
			// 
			this.panelVehicle.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.panelVehicle.Icon = ((System.Drawing.Icon)(resources.GetObject("panelVehicle.Icon")));
			this.panelVehicle.Name = "panelVehicle";
			this.panelVehicle.Width = 217;
			// 
			// panelComPort
			// 
			this.panelComPort.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.panelComPort.Name = "panelComPort";
			this.panelComPort.Text = "COM1";
			this.panelComPort.Width = 75;
			// 
			// panelChipInfo
			// 
			this.panelChipInfo.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.panelChipInfo.Name = "panelChipInfo";
			// 
			// panelTx
			// 
			this.panelTx.Name = "panelTx";
			this.panelTx.Text = "Tx: ";
			// 
			// panelRx
			// 
			this.panelRx.Name = "panelRx";
			this.panelRx.Text = "Rx: ";
			// 
			// panelConnectedIcon
			// 
			this.panelConnectedIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("panelConnectedIcon.Icon")));
			this.panelConnectedIcon.MinWidth = 0;
			this.panelConnectedIcon.Name = "panelConnectedIcon";
			this.panelConnectedIcon.Width = 0;
			// 
			// panelDisconnectedIcon
			// 
			this.panelDisconnectedIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("panelDisconnectedIcon.Icon")));
			this.panelDisconnectedIcon.MinWidth = 0;
			this.panelDisconnectedIcon.Name = "panelDisconnectedIcon";
			this.panelDisconnectedIcon.Width = 0;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 590);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu;
			this.MinimumSize = new System.Drawing.Size(800, 650);
			this.Name = "MainForm";
			this.Text = "ProScan";
			this.Closed += new System.EventHandler(this.MainForm_Closed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.panelStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelVehicle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelComPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelChipInfo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelTx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelRx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelConnectedIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelDisconnectedIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void menuItemExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void SetActiveForm(Form form)
		{
			if (form == null)
				return;
			if (m_formActive != null)
				m_formActive.Hide();
			form.MdiParent = this;
			form.WindowState = FormWindowState.Maximized;
			form.Show();
			Focus();
			m_formActive = form;
		}

		private void SetDescriptiveToolTips()
		{
			toolBarButtonStart.ToolTipText = "Vehicle Connection Manager.\r\nStart and finish every ProScan session here.";
			toolBarButtonTests.ToolTipText = "Vehicle Status Monitor.\r\nView support status and results of monitors.";
			toolBarButtonDTC.ToolTipText = "Diagnostic Trouble Codes.\r\nView DTCs and turn off your check engine light.";
			toolBarButtonFF.ToolTipText = "Freeze Frame Data.\r\nView critical sensor values at the time a DTC was thrown.";
			toolBarButtonO2.ToolTipText = "Oxygen Sensor Tests.\r\nView test results for your vehicle's oxygen sensors.";
			toolBarButtonSensorGrid.ToolTipText = "Live Sensor Grid.\r\nMonitor, record, and playback sensor data in real-time.";
			toolBarButtonSensorGraph.ToolTipText = "Live Sensor Graphs.\r\nPlot sensor data in real-time with customizable graphs.";
			toolBarButtonTrack.ToolTipText = "Race Track Analysis.\r\nGenerate accurate 1/4 mile timeslips.";
			toolBarButtonDyno.ToolTipText = "Dynamometer.\r\nGenerate horsepower and torque curve estimations.";
			toolBarButtonFuel.ToolTipText = "Fuel Economy Analysis.\r\nAnalyze your vehicle's fuel economy in real-time.";
			toolBarButtonReport.ToolTipText = "Diagnostic Report Generator.\r\nPrint a detailed diagnostic report for a client.";
			toolBarButtonTerminal.ToolTipText = "Terminal.\r\nSend custom-formatted requests to the OBD-II system.";
			toolBarButtonCommLog.ToolTipText = "Communication Log.\r\nView a complete history of the current ProScan session.";
			toolBarButtonUserPrefs.ToolTipText = "User Preferences.\r\nEdit your personal preferences and company information.";
			toolBarButtonVehicles.ToolTipText = "Vehicle Profile Manager.\r\nManage all of your vehicle profiles.";
			toolBarButtonSettings.ToolTipText = "Communication Settings.\r\nConfigure your serial port and interface hardware.";
		}

		private void On_OBD2_Connect()
		{
			panelChipInfo.Text = m_obdInterface.getDeviceIDString();
			panelStatus.Icon = panelConnectedIcon.Icon;
			panelStatus.Text = "Connected";
			panelVehicle.Text = m_obdInterface.GetActiveProfile().Name;
			menuItemCommSettings.Enabled = false;
			toolBarButtonSettings.Enabled = false;
			menuItemVehicleProfiles.Enabled = false;
			toolBarButtonVehicles.Enabled = false;
			menuItemUserPrefs.Enabled = false;
			toolBarButtonUserPrefs.Enabled = false;
			BroadcastConnectionUpdate();
		}

		private void On_OBD2_Disconnect()
		{
			panelStatus.Text = "Disconnected";
			panelStatus.Icon = panelDisconnectedIcon.Icon;
			menuItemCommSettings.Enabled = true;
			toolBarButtonSettings.Enabled = true;
			menuItemVehicleProfiles.Enabled = true;
			toolBarButtonVehicles.Enabled = true;
			menuItemUserPrefs.Enabled = true;
			toolBarButtonUserPrefs.Enabled = true;
			BroadcastConnectionUpdate();
			MessageBox.Show(m_formActive, "Vehicle connection has been disconnected.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		private void On_OBD2_Sent(OBD2Request obd2Request)
		{
			panelTx.Text = "Tx: " + obd2Request.Request;
		}

		private void On_OBD2_Received(OBD2Response obd2Response)
		{
			panelRx.Text = "Rx: " + obd2Response.Response;
		}

		private void BroadcastResponse(OBD2Response obd2Response)
		{
		}

		private void BroadcastConnectionUpdate()
		{
			int index = 0;
			if (0 >= MdiChildren.Length)
				return;
			do
			{
				if (string.Compare("DTCForm", MdiChildren[index].GetType().Name) == 0)
					(MdiChildren[index] as DTCForm).CheckConnection();
				else if (string.Compare("SensorMonitorForm", MdiChildren[index].GetType().Name) == 0)
					(MdiChildren[index] as SensorMonitorForm).CheckConnection();
				else if (string.Compare("ScopeForm", MdiChildren[index].GetType().Name) == 0)
					(MdiChildren[index] as ScopeForm).CheckConnection();
				else if (string.Compare("TrackForm", MdiChildren[index].GetType().Name) == 0)
					(MdiChildren[index] as TrackForm).CheckConnection();
				else if (string.Compare("DynoForm", MdiChildren[index].GetType().Name) == 0)
					(MdiChildren[index] as DynoForm).CheckConnection();
				++index;
			}
			while (index < MdiChildren.Length);
		}

		private void menuItemHideToolBar_Click(object sender, EventArgs e)
		{
			toolBar.Visible = false;
		}

		private void menuItemToolbar_Click(object sender, EventArgs e)
		{
			menuItemToolbar.Checked = !menuItemToolbar.Checked;
			if (menuItemToolbar.Checked)
				toolBar.Visible = true;
			else
				toolBar.Visible = false;
		}

		private void menuItemView_Select(object sender, EventArgs e)
		{
			menuItemToolbar.Checked = toolBar.Visible;
		}

		private void menuSettings_Click(object sender, EventArgs e)
		{
			EditSettings();
		}

		private void EditUserPreferences()
		{
			UserPreferences userPreferences = m_obdInterface.GetUserPreferences();
			int num = (int)new UserPreferencesForm(userPreferences).ShowDialog();
			m_obdInterface.SaveUserPreferences(userPreferences);
		}

		private void EditSettings()
		{
			Preferences commSettings = m_obdInterface.GetCommSettings();
			new SettingsForm(commSettings).ShowDialog();
			m_obdInterface.SaveCommSettings(commSettings);
			if (commSettings.AutoDetect)
			{
				panelComPort.Text = "Auto-Detect";
			}
			else
			{
				panelComPort.Text = commSettings.ComPortName;
			}
		}

		private void EditVehicles()
		{
			int num = (int)new VehicleForm(m_obdInterface).ShowDialog();
			m_formStart.UpdateForm();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (!m_obdInterface.loadParameters("generic.dat"))
				MessageBox.Show("Failed to load generic parameter definitions!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			if (m_obdInterface.loadDTCDefinitions("dtc.dat") == 0)
				MessageBox.Show("Failed to load DTC definitions!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
		}

		private void MainForm_Closed(object sender, EventArgs e)
		{
		}

		private void btnSettings_Click(object sender, EventArgs e)
		{
			EditSettings();
		}

		private void menuItemConnectionManager_Click(object sender, EventArgs e)
		{
			ShowConnectionManager();
		}

		private void menuItemTests_Click(object sender, EventArgs e)
		{
			ShowVehicleStatusMonitor();
		}

		private void menuItemDTC_Click(object sender, EventArgs e)
		{
			ShowDiagnosticTroubleCodes();
		}

		private void menuItemFreezeFrame_Click(object sender, EventArgs e)
		{
			ShowFreezeFrameData();
		}

		private void menuItemOxygenSensors_Click(object sender, EventArgs e)
		{
			ShowOxygenSensorTests();
		}

		private void menuItemSensorMonitor_Click(object sender, EventArgs e)
		{
			ShowLiveSensorGrid();
		}

		private void menuItemScope_Click(object sender, EventArgs e)
		{
			ShowLiveSensorGraphs();
		}

		private void menuItemTrack_Click(object sender, EventArgs e)
		{
			ShowRaceTrackAnalysis();
		}

		private void menuItemDyno_Click(object sender, EventArgs e)
		{
			ShowDynamometer();
		}

		private void menuItemReport_Click(object sender, EventArgs e)
		{
			ShowDiagnosticReport();
		}

		private void menuItemTerminal_Click(object sender, EventArgs e)
		{
			ShowTerminal();
		}

		private void menuItemCommLog_Click(object sender, EventArgs e)
		{
			ShowCommunicationLog();
		}

		private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Style == ToolBarButtonStyle.ToggleButton && !e.Button.Pushed)
				e.Button.Pushed = true;
			else
			{
				if (m_formActive == m_formSensorGrid && m_formSensorGrid.bLogging)
				{
					if (DialogResult.Yes == MessageBox.Show("This action will pause the current recording session.\r\n\r\nContinue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						m_formSensorGrid.PauseLogging();
					else
					{
						e.Button.Pushed = false;
						return;
					}
				}
				if (m_formActive == m_formSensorChart && m_formSensorChart.m_isPlotting)
				{
					if (DialogResult.Yes == MessageBox.Show("This action will stop the current oscilloscope session.\r\n\r\nContinue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						m_formSensorChart.StopLogging();
					else
					{
						e.Button.Pushed = false;
						return;
					}
				}
				if ((m_formActive == m_formFuelEconomy) && m_formFuelEconomy.m_isWorking)
				{
					if (DialogResult.Yes == MessageBox.Show("This action will stop the current fuel economy analysis session.\r\n\r\nContinue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
						m_formFuelEconomy.StopWorking();
					else
					{
						e.Button.Pushed = false;
						return;
					}
				}
				if (e.Button == toolBarButtonStart)
					ShowConnectionManager();
				else if (e.Button == toolBarButtonTests)
					ShowVehicleStatusMonitor();
				else if (e.Button == toolBarButtonDTC)
					ShowDiagnosticTroubleCodes();
				else if (e.Button == toolBarButtonFF)
					ShowFreezeFrameData();
				else if (e.Button == toolBarButtonO2)
					ShowOxygenSensorTests();
				else if (e.Button == toolBarButtonSensorGrid)
					ShowLiveSensorGrid();
				else if (e.Button == toolBarButtonSensorGraph)
					ShowLiveSensorGraphs();
				else if (e.Button == toolBarButtonTrack)
					ShowRaceTrackAnalysis();
				else if (e.Button == toolBarButtonDyno)
					ShowDynamometer();
				else if (e.Button == toolBarButtonFuel)
					ShowFuelEconomyAnalysis();
				else if (e.Button == toolBarButtonReport)
					ShowDiagnosticReport();
				else if (e.Button == toolBarButtonTerminal)
					ShowTerminal();
				else if (e.Button == toolBarButtonCommLog)
					ShowCommunicationLog();
				else if (e.Button == toolBarButtonUserPrefs)
					EditUserPreferences();
				else if (e.Button == toolBarButtonSettings)
					EditSettings();
				else if (e.Button == toolBarButtonVehicles)
					EditVehicles();
			}
		}

		private void menuItemCommSettings_Click(object sender, EventArgs e)
		{
			EditSettings();
		}

		private void menuItemVehicleProfiles_Click(object sender, EventArgs e)
		{
			EditVehicles();
		}

		private void PushedOne(ToolBarButton btn)
		{
			foreach(ToolBarButton button in toolBar.Buttons)
				button.Pushed = false;
			btn.Pushed = true;
		}

		private void ShowConnectionManager()
		{
			if (m_formActive != m_formStart)
			{
				m_obdInterface.logItem("Switched Active Tool: Vehicle Connection Manager");
				SetActiveForm(m_formStart);
				PushedOne(toolBarButtonStart);
			}
		}

		private void ShowVehicleStatusMonitor()
		{
			if (m_formActive != m_formMonitorTests)
			{
				m_obdInterface.logItem("Switched Active Tool: Vehicle Status Monitor");
				SetActiveForm(m_formMonitorTests);
				PushedOne(toolBarButtonTests);
			}
		}

		private void ShowDiagnosticTroubleCodes()
		{
			if (m_formActive != m_formDTC)
			{
				m_obdInterface.logItem("Switched Active Tool: Diagnostic Trouble Codes");
				SetActiveForm(m_formDTC);
				PushedOne(toolBarButtonDTC);
			}
		}

		private void ShowFreezeFrameData()
		{
			if (m_formActive != m_formFreezeFrames)
			{
				m_obdInterface.logItem("Switched Active Tool: Freeze Frame Data");
				SetActiveForm(m_formFreezeFrames);
				PushedOne(toolBarButtonFF);
			}
		}

		private void ShowOxygenSensorTests()
		{
			if (m_formActive != m_formOxygenSensors)
			{
				m_obdInterface.logItem("Switched Active Tool: Oxygen Sensor Tests");
				m_formOxygenSensors.Update();
				SetActiveForm(m_formOxygenSensors);
				PushedOne(toolBarButtonO2);
			}
		}

		private void ShowLiveSensorGrid()
		{
			if (m_formActive != m_formSensorGrid)
			{
				m_obdInterface.logItem("Switched Active Tool: Live Sensor Grid");
				SetActiveForm(m_formSensorGrid);
				PushedOne(toolBarButtonSensorGrid);
			}
		}

		private void ShowLiveSensorGraphs()
		{
			if (m_formActive != m_formSensorChart)
			{
				m_obdInterface.logItem("Switched Active Tool: Live Sensor Graphs");
				SetActiveForm(m_formSensorChart);
				PushedOne(toolBarButtonSensorGraph);
			}
		}

		private void ShowRaceTrackAnalysis()
		{
			if (m_formActive != m_formTrack)
			{
				m_obdInterface.logItem("Switched Active Tool: Race Track Analysis");
				SetActiveForm(m_formTrack);
				PushedOne(toolBarButtonTrack);
			}
		}

		private void ShowDynamometer()
		{
			if (m_formActive != m_formDyno)
			{
				m_obdInterface.logItem("Switched Active Tool: Dynamometer");
				SetActiveForm(m_formDyno);
				PushedOne(toolBarButtonDyno);
			}
		}


		private void ShowFuelEconomyAnalysis()
		{
			if (m_formActive != m_formFuelEconomy)
			{
				m_obdInterface.logItem("Switched Active Tool: Fuel Economy Analysis");
				SetActiveForm(m_formFuelEconomy);
				PushedOne(toolBarButtonFuel);
			}
		}

		private void ShowDiagnosticReport()
		{
			if (m_formActive != m_formReport)
			{
				m_obdInterface.logItem("Switched Active Tool: Diagnostic Report Generator");
				SetActiveForm(m_formReport);
				PushedOne(toolBarButtonReport);
			}
		}


		private void ShowTerminal()
		{
			if (m_formActive != m_formTerminal)
			{
				m_obdInterface.logItem("Switched Active Tool: Terminal");
				m_formTerminal.Update();
				SetActiveForm(m_formTerminal);
				PushedOne(toolBarButtonTerminal);
			}
		}

		private void ShowCommunicationLog()
		{
			if (m_formActive != m_formCommLog)
			{
				m_obdInterface.logItem("Switched Active Tool: Communication Log");
				SetActiveForm(m_formCommLog);
				m_formCommLog.Update();
				PushedOne(toolBarButtonCommLog);
			}
		}


		private void menuItemUserPrefs_Click(object sender, EventArgs e)
		{
			EditUserPreferences();
		}

		private void menuItemCommLoggingOn_Click(object sender, EventArgs e)
		{
			m_obdInterface.enableLogFile(true);
			menuItemCommLoggingOn.Checked = true;
			menuItemCommLoggingOff.Checked = false;
		}

		private void menuItemCommLoggingOff_Click(object sender, EventArgs e)
		{
			m_obdInterface.enableLogFile(false);
			menuItemCommLoggingOn.Checked = false;
			menuItemCommLoggingOff.Checked = true;
		}
	}
}