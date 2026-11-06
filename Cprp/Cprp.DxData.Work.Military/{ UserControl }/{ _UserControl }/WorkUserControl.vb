Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления для редактирования данных работы
''' </summary>
Public Class WorkUserControl : Inherits Cprp.DxData.Work.WorkUserControl

#Region "InitializeComponent"

    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Private components As System.ComponentModel.IContainer
    Friend WithEvents hideContainerBottom As DevExpress.XtraBars.Docking.AutoHideContainer
    Friend WithEvents ErrorDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents ContentDockPanel As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents ControlContainer1 As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents ContentTreeList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents CaptionTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RepositoryItemHyperLinkEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents ContentIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ObjectIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents ErrorGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ErrorGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PlaceCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents DescriptionCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IdCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SeparatorControl3 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents ExpertDataSaveBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertDataReloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertDataImportBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertPlaneCheckBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertPlaneSendBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertProjectCreateBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertWorkToPlaneBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertWorkCheckBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertWorkSendBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpertWorkBackBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LeaderPlaneAcceptBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LeaderPlaneBackBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LeaderWorkAcceptBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LeaderWorkBackBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents ExpertDataRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ExpertPlaneRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ExpertProjectRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ExpertWorkRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LeaderPlaneRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LeaderWorkRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LeaderDataReloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LeaderDataRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ExpertWorkSignBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkHistoryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkHistoryRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LeaderPlaneCalcBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
    Friend WithEvents MainWindowsUIButtonPanel As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip7 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem7 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem7 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip8 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem8 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem8 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip9 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem9 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem9 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip10 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem10 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem10 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip11 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem11 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem11 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip12 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem12 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem12 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip13 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem13 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem13 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip14 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem14 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem14 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip15 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem15 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip16 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem16 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem15 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip17 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem17 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem16 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip18 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem18 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem17 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip19 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem19 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem18 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip20 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem20 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem19 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip21 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem21 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem20 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.MainWindowsUIButtonPanel = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager()
        Me.hideContainerBottom = New DevExpress.XtraBars.Docking.AutoHideContainer()
        Me.ErrorDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.ErrorGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ErrorGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PlaceCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.DescriptionCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IdCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SeparatorControl3 = New DevExpress.XtraEditors.SeparatorControl()
        Me.ContentDockPanel = New DevExpress.XtraBars.Docking.DockPanel()
        Me.ControlContainer1 = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.ContentTreeList = New DevExpress.XtraTreeList.TreeList()
        Me.CaptionTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RepositoryItemHyperLinkEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ContentIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ObjectIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.ExpertDataSaveBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertDataReloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertDataImportBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertPlaneCheckBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertPlaneSendBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertProjectCreateBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertWorkToPlaneBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertWorkCheckBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertWorkSendBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertWorkBackBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LeaderPlaneAcceptBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LeaderPlaneBackBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LeaderWorkAcceptBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LeaderWorkBackBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LeaderDataReloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpertWorkSignBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkHistoryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LeaderPlaneCalcBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.ExpertDataRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ExpertPlaneRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ExpertProjectRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ExpertWorkRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LeaderDataRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LeaderPlaneRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LeaderWorkRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.WorkHistoryRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hideContainerBottom.SuspendLayout()
        Me.ErrorDockPanel.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.ErrorGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContentDockPanel.SuspendLayout()
        Me.ControlContainer1.SuspendLayout()
        CType(Me.ContentTreeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainWindowsUIButtonPanel
        '
        Me.MainWindowsUIButtonPanel.ButtonInterval = 12
        ToolTipTitleItem1.Text = "Содержание"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к содержанию работы"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        ToolTipTitleItem2.Text = "Проект #1"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Перейти к проекту заключения #1"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        ToolTipTitleItem3.Text = "Проект #2"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Перейти к проекту заключения #2"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.MainWindowsUIButtonPanel.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("СОДЕРЖАНИЕ", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip1, True, True, True, Nothing, Nothing, 1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUISeparator(), New DevExpress.XtraBars.Docking2010.WindowsUIButton("ПРОЕКТ #1", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons1"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip2, True, False, True, Nothing, Nothing, 1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("ПРОЕКТ #2", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons2"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip3, True, False, False, Nothing, Nothing, 1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUISeparator(), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Запросы", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons3"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1)})
        Me.MainWindowsUIButtonPanel.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.MainWindowsUIButtonPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.MainWindowsUIButtonPanel.Location = New System.Drawing.Point(0, 83)
        Me.MainWindowsUIButtonPanel.Name = "MainWindowsUIButtonPanel"
        Me.MainWindowsUIButtonPanel.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.MainWindowsUIButtonPanel.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.MainWindowsUIButtonPanel.Size = New System.Drawing.Size(95, 344)
        Me.MainWindowsUIButtonPanel.TabIndex = 0
        Me.MainWindowsUIButtonPanel.Text = "MainWindowsUIButtonPanel"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl1.Location = New System.Drawing.Point(95, 83)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(1, 344)
        Me.SeparatorControl1.TabIndex = 1
        '
        'MainPanelControl
        '
        Me.MainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanelControl.Location = New System.Drawing.Point(96, 83)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(654, 344)
        Me.MainPanelControl.TabIndex = 2
        '
        'DockManager1
        '
        Me.DockManager1.AutoHideContainers.AddRange(New DevExpress.XtraBars.Docking.AutoHideContainer() {Me.hideContainerBottom})
        Me.DockManager1.DockingOptions.ShowCloseButton = False
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.ContentDockPanel})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'hideContainerBottom
        '
        Me.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.hideContainerBottom.Controls.Add(Me.ErrorDockPanel)
        Me.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.hideContainerBottom.Location = New System.Drawing.Point(0, 427)
        Me.hideContainerBottom.Name = "hideContainerBottom"
        Me.hideContainerBottom.Size = New System.Drawing.Size(1150, 23)
        '
        'ErrorDockPanel
        '
        Me.ErrorDockPanel.Controls.Add(Me.DockPanel1_Container)
        Me.ErrorDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.ErrorDockPanel.ID = New System.Guid("d507870e-0e57-44eb-b82d-1e5d0e1b5f14")
        Me.ErrorDockPanel.Location = New System.Drawing.Point(0, 0)
        Me.ErrorDockPanel.Name = "ErrorDockPanel"
        Me.ErrorDockPanel.OriginalSize = New System.Drawing.Size(200, 250)
        Me.ErrorDockPanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.ErrorDockPanel.SavedIndex = 0
        Me.ErrorDockPanel.Size = New System.Drawing.Size(1150, 250)
        Me.ErrorDockPanel.Text = "Результаты проверки (0)"
        Me.ErrorDockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.ErrorGridControl)
        Me.DockPanel1_Container.Controls.Add(Me.SeparatorControl3)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 39)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1142, 207)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'ErrorGridControl
        '
        Me.ErrorGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErrorGridControl.Location = New System.Drawing.Point(0, 1)
        Me.ErrorGridControl.MainView = Me.ErrorGridView
        Me.ErrorGridControl.Name = "ErrorGridControl"
        Me.ErrorGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1})
        Me.ErrorGridControl.Size = New System.Drawing.Size(1142, 206)
        Me.ErrorGridControl.TabIndex = 14
        Me.ErrorGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ErrorGridView})
        '
        'ErrorGridView
        '
        Me.ErrorGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ErrorGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ErrorGridView.Appearance.Row.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ErrorGridView.Appearance.Row.Options.UseFont = True
        Me.ErrorGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ErrorGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PlaceCheckGridColumn, Me.DescriptionCheckGridColumn, Me.IdCheckGridColumn})
        Me.ErrorGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.ErrorGridView.GridControl = Me.ErrorGridControl
        Me.ErrorGridView.Name = "ErrorGridView"
        Me.ErrorGridView.OptionsBehavior.ReadOnly = True
        Me.ErrorGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ErrorGridView.OptionsCustomization.AllowFilter = False
        Me.ErrorGridView.OptionsCustomization.AllowGroup = False
        Me.ErrorGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ErrorGridView.OptionsCustomization.AllowSort = False
        Me.ErrorGridView.OptionsMenu.EnableColumnMenu = False
        Me.ErrorGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ErrorGridView.OptionsView.ShowGroupPanel = False
        Me.ErrorGridView.RowHeight = 23
        '
        'PlaceCheckGridColumn
        '
        Me.PlaceCheckGridColumn.Caption = "Место ошибки"
        Me.PlaceCheckGridColumn.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.PlaceCheckGridColumn.FieldName = "place"
        Me.PlaceCheckGridColumn.Name = "PlaceCheckGridColumn"
        Me.PlaceCheckGridColumn.Visible = True
        Me.PlaceCheckGridColumn.VisibleIndex = 0
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        '
        'DescriptionCheckGridColumn
        '
        Me.DescriptionCheckGridColumn.Caption = "Описание ошибки"
        Me.DescriptionCheckGridColumn.FieldName = "description"
        Me.DescriptionCheckGridColumn.Name = "DescriptionCheckGridColumn"
        Me.DescriptionCheckGridColumn.Visible = True
        Me.DescriptionCheckGridColumn.VisibleIndex = 1
        '
        'IdCheckGridColumn
        '
        Me.IdCheckGridColumn.Caption = "id"
        Me.IdCheckGridColumn.FieldName = "id"
        Me.IdCheckGridColumn.Name = "IdCheckGridColumn"
        '
        'SeparatorControl3
        '
        Me.SeparatorControl3.AutoSizeMode = True
        Me.SeparatorControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl3.Location = New System.Drawing.Point(0, 0)
        Me.SeparatorControl3.Name = "SeparatorControl3"
        Me.SeparatorControl3.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl3.Size = New System.Drawing.Size(1142, 1)
        Me.SeparatorControl3.TabIndex = 0
        '
        'ContentDockPanel
        '
        Me.ContentDockPanel.Controls.Add(Me.ControlContainer1)
        Me.ContentDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Me.ContentDockPanel.ID = New System.Guid("25d49ff7-83d1-4010-8cae-4df00960453d")
        Me.ContentDockPanel.Location = New System.Drawing.Point(750, 83)
        Me.ContentDockPanel.Name = "ContentDockPanel"
        Me.ContentDockPanel.OriginalSize = New System.Drawing.Size(400, 200)
        Me.ContentDockPanel.Size = New System.Drawing.Size(400, 344)
        Me.ContentDockPanel.Text = "Переход к разделу работы"
        '
        'ControlContainer1
        '
        Me.ControlContainer1.Controls.Add(Me.ContentTreeList)
        Me.ControlContainer1.Controls.Add(Me.SeparatorControl2)
        Me.ControlContainer1.Location = New System.Drawing.Point(5, 40)
        Me.ControlContainer1.Name = "ControlContainer1"
        Me.ControlContainer1.Size = New System.Drawing.Size(391, 300)
        Me.ControlContainer1.TabIndex = 0
        '
        'ContentTreeList
        '
        Me.ContentTreeList.Appearance.Row.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ContentTreeList.Appearance.Row.Options.UseFont = True
        Me.ContentTreeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ContentTreeList.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.CaptionTreeListColumn, Me.ContentIdTreeListColumn, Me.ObjectIdTreeListColumn})
        Me.ContentTreeList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTreeList.Location = New System.Drawing.Point(0, 1)
        Me.ContentTreeList.Name = "ContentTreeList"
        Me.ContentTreeList.OptionsBehavior.AllowExpandOnDblClick = False
        Me.ContentTreeList.OptionsBehavior.ReadOnly = True
        Me.ContentTreeList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ContentTreeList.OptionsView.ShowColumns = False
        Me.ContentTreeList.OptionsView.ShowHorzLines = False
        Me.ContentTreeList.OptionsView.ShowIndicator = False
        Me.ContentTreeList.OptionsView.ShowVertLines = False
        Me.ContentTreeList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit2})
        Me.ContentTreeList.RowHeight = 25
        Me.ContentTreeList.Size = New System.Drawing.Size(391, 299)
        Me.ContentTreeList.TabIndex = 1
        '
        'CaptionTreeListColumn
        '
        Me.CaptionTreeListColumn.Caption = "Раздел / объект"
        Me.CaptionTreeListColumn.ColumnEdit = Me.RepositoryItemHyperLinkEdit2
        Me.CaptionTreeListColumn.FieldName = "caption"
        Me.CaptionTreeListColumn.Name = "CaptionTreeListColumn"
        Me.CaptionTreeListColumn.Visible = True
        Me.CaptionTreeListColumn.VisibleIndex = 0
        '
        'RepositoryItemHyperLinkEdit2
        '
        Me.RepositoryItemHyperLinkEdit2.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit2.Name = "RepositoryItemHyperLinkEdit2"
        '
        'ContentIdTreeListColumn
        '
        Me.ContentIdTreeListColumn.Caption = "Идентификатор раздела"
        Me.ContentIdTreeListColumn.FieldName = "contentId"
        Me.ContentIdTreeListColumn.Name = "ContentIdTreeListColumn"
        '
        'ObjectIdTreeListColumn
        '
        Me.ObjectIdTreeListColumn.Caption = "Идентификатор объекта"
        Me.ObjectIdTreeListColumn.FieldName = "objectId"
        Me.ObjectIdTreeListColumn.Name = "ObjectIdTreeListColumn"
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.AutoSizeMode = True
        Me.SeparatorControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl2.Location = New System.Drawing.Point(0, 0)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl2.Size = New System.Drawing.Size(391, 1)
        Me.SeparatorControl2.TabIndex = 0
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.ExpertDataSaveBarButtonItem, Me.ExpertDataReloadBarButtonItem, Me.ExpertDataImportBarButtonItem, Me.ExpertPlaneCheckBarButtonItem, Me.ExpertPlaneSendBarButtonItem, Me.ExpertProjectCreateBarButtonItem, Me.ExpertWorkToPlaneBarButtonItem, Me.ExpertWorkCheckBarButtonItem, Me.ExpertWorkSendBarButtonItem, Me.ExpertWorkBackBarButtonItem, Me.LeaderPlaneAcceptBarButtonItem, Me.LeaderPlaneBackBarButtonItem, Me.LeaderWorkAcceptBarButtonItem, Me.LeaderWorkBackBarButtonItem, Me.LeaderDataReloadBarButtonItem, Me.ExpertWorkSignBarButtonItem, Me.WorkHistoryBarButtonItem, Me.LeaderPlaneCalcBarButtonItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 19
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(1150, 83)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'ExpertDataSaveBarButtonItem
        '
        Me.ExpertDataSaveBarButtonItem.Caption = "СОХРАНИТЬ"
        Me.ExpertDataSaveBarButtonItem.Id = 1
        Me.ExpertDataSaveBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertDataSaveBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertDataSaveBarButtonItem.Name = "ExpertDataSaveBarButtonItem"
        ToolTipTitleItem4.Text = "Сохранить"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Сохранить работу в базу данных"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.ExpertDataSaveBarButtonItem.SuperTip = SuperToolTip4
        '
        'ExpertDataReloadBarButtonItem
        '
        Me.ExpertDataReloadBarButtonItem.Caption = "ПЕРЕЧИТАТЬ"
        Me.ExpertDataReloadBarButtonItem.Id = 2
        Me.ExpertDataReloadBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertDataReloadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertDataReloadBarButtonItem.Name = "ExpertDataReloadBarButtonItem"
        ToolTipTitleItem5.Text = "Перечитать"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Перечитать работу из базы данных"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.ExpertDataReloadBarButtonItem.SuperTip = SuperToolTip5
        '
        'ExpertDataImportBarButtonItem
        '
        Me.ExpertDataImportBarButtonItem.Caption = "ЗАГРУЗИТЬ"
        Me.ExpertDataImportBarButtonItem.Id = 3
        Me.ExpertDataImportBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertDataImportBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertDataImportBarButtonItem.Name = "ExpertDataImportBarButtonItem"
        ToolTipTitleItem6.Text = "Загрузить"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Загрузить данные из другой работы"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.ExpertDataImportBarButtonItem.SuperTip = SuperToolTip6
        '
        'ExpertPlaneCheckBarButtonItem
        '
        Me.ExpertPlaneCheckBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ExpertPlaneCheckBarButtonItem.Caption = "ПРОВЕРИТЬ"
        Me.ExpertPlaneCheckBarButtonItem.Id = 4
        Me.ExpertPlaneCheckBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertPlaneCheckBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertPlaneCheckBarButtonItem.Name = "ExpertPlaneCheckBarButtonItem"
        ToolTipTitleItem7.Text = "Проверить"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Проверить план работы на наличие ошибок"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.ExpertPlaneCheckBarButtonItem.SuperTip = SuperToolTip7
        '
        'ExpertPlaneSendBarButtonItem
        '
        Me.ExpertPlaneSendBarButtonItem.Caption = "НА УТВЕРЖДЕНИЕ"
        Me.ExpertPlaneSendBarButtonItem.Id = 5
        Me.ExpertPlaneSendBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertPlaneSendBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertPlaneSendBarButtonItem.Name = "ExpertPlaneSendBarButtonItem"
        ToolTipTitleItem8.Text = "На утверждение"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Отправить план работы на утверждение"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.ExpertPlaneSendBarButtonItem.SuperTip = SuperToolTip8
        '
        'ExpertProjectCreateBarButtonItem
        '
        Me.ExpertProjectCreateBarButtonItem.Caption = "СОЗДАТЬ"
        Me.ExpertProjectCreateBarButtonItem.Id = 6
        Me.ExpertProjectCreateBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertProjectCreateBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertProjectCreateBarButtonItem.Name = "ExpertProjectCreateBarButtonItem"
        ToolTipTitleItem9.Text = "Создать"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Создать проекты итоговых документов"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.ExpertProjectCreateBarButtonItem.SuperTip = SuperToolTip9
        '
        'ExpertWorkToPlaneBarButtonItem
        '
        Me.ExpertWorkToPlaneBarButtonItem.Caption = "В ПЛАН"
        Me.ExpertWorkToPlaneBarButtonItem.Id = 7
        Me.ExpertWorkToPlaneBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertWorkToPlaneBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertWorkToPlaneBarButtonItem.Name = "ExpertWorkToPlaneBarButtonItem"
        ToolTipTitleItem10.Text = "В план"
        ToolTipItem10.LeftIndent = 6
        ToolTipItem10.Text = "Включить работу в мой план работ"
        SuperToolTip10.Items.Add(ToolTipTitleItem10)
        SuperToolTip10.Items.Add(ToolTipItem10)
        Me.ExpertWorkToPlaneBarButtonItem.SuperTip = SuperToolTip10
        '
        'ExpertWorkCheckBarButtonItem
        '
        Me.ExpertWorkCheckBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ExpertWorkCheckBarButtonItem.Caption = "ПРОВЕРИТЬ"
        Me.ExpertWorkCheckBarButtonItem.Id = 8
        Me.ExpertWorkCheckBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertWorkCheckBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertWorkCheckBarButtonItem.Name = "ExpertWorkCheckBarButtonItem"
        ToolTipTitleItem11.Text = "Проверить"
        ToolTipItem11.LeftIndent = 6
        ToolTipItem11.Text = "Проверить работу на наличие ошибок"
        SuperToolTip11.Items.Add(ToolTipTitleItem11)
        SuperToolTip11.Items.Add(ToolTipItem11)
        Me.ExpertWorkCheckBarButtonItem.SuperTip = SuperToolTip11
        '
        'ExpertWorkSendBarButtonItem
        '
        Me.ExpertWorkSendBarButtonItem.Caption = "НА УТВЕРЖДЕНИЕ"
        Me.ExpertWorkSendBarButtonItem.Id = 9
        Me.ExpertWorkSendBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertWorkSendBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertWorkSendBarButtonItem.Name = "ExpertWorkSendBarButtonItem"
        ToolTipTitleItem12.Text = "На утверждение"
        ToolTipItem12.LeftIndent = 6
        ToolTipItem12.Text = "Отправить работу на утверждение руководителю экспертизы"
        SuperToolTip12.Items.Add(ToolTipTitleItem12)
        SuperToolTip12.Items.Add(ToolTipItem12)
        Me.ExpertWorkSendBarButtonItem.SuperTip = SuperToolTip12
        '
        'ExpertWorkBackBarButtonItem
        '
        Me.ExpertWorkBackBarButtonItem.Caption = "ВОЗВРАТ"
        Me.ExpertWorkBackBarButtonItem.Id = 10
        Me.ExpertWorkBackBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertWorkBackBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertWorkBackBarButtonItem.Name = "ExpertWorkBackBarButtonItem"
        ToolTipTitleItem13.Text = "Возврат"
        ToolTipItem13.LeftIndent = 6
        ToolTipItem13.Text = "Вернуть работу на доработку"
        SuperToolTip13.Items.Add(ToolTipTitleItem13)
        SuperToolTip13.Items.Add(ToolTipItem13)
        Me.ExpertWorkBackBarButtonItem.SuperTip = SuperToolTip13
        '
        'LeaderPlaneAcceptBarButtonItem
        '
        Me.LeaderPlaneAcceptBarButtonItem.Caption = "УТВЕРДИТЬ"
        Me.LeaderPlaneAcceptBarButtonItem.Id = 11
        Me.LeaderPlaneAcceptBarButtonItem.LargeGlyph = CType(resources.GetObject("LeaderPlaneAcceptBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LeaderPlaneAcceptBarButtonItem.Name = "LeaderPlaneAcceptBarButtonItem"
        ToolTipTitleItem14.Text = "Утвердить"
        ToolTipItem14.LeftIndent = 6
        ToolTipItem14.Text = "Утвердить план работы"
        SuperToolTip14.Items.Add(ToolTipTitleItem14)
        SuperToolTip14.Items.Add(ToolTipItem14)
        Me.LeaderPlaneAcceptBarButtonItem.SuperTip = SuperToolTip14
        '
        'LeaderPlaneBackBarButtonItem
        '
        Me.LeaderPlaneBackBarButtonItem.Caption = "ВОЗВРАТ"
        Me.LeaderPlaneBackBarButtonItem.Id = 12
        Me.LeaderPlaneBackBarButtonItem.LargeGlyph = CType(resources.GetObject("LeaderPlaneBackBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LeaderPlaneBackBarButtonItem.Name = "LeaderPlaneBackBarButtonItem"
        ToolTipTitleItem15.Text = "Возврат плана работы на доработку"
        SuperToolTip15.Items.Add(ToolTipTitleItem15)
        Me.LeaderPlaneBackBarButtonItem.SuperTip = SuperToolTip15
        '
        'LeaderWorkAcceptBarButtonItem
        '
        Me.LeaderWorkAcceptBarButtonItem.Caption = "УТВЕРДИТЬ"
        Me.LeaderWorkAcceptBarButtonItem.Id = 13
        Me.LeaderWorkAcceptBarButtonItem.LargeGlyph = CType(resources.GetObject("LeaderWorkAcceptBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LeaderWorkAcceptBarButtonItem.Name = "LeaderWorkAcceptBarButtonItem"
        ToolTipTitleItem16.Text = "Утвердить"
        ToolTipItem15.LeftIndent = 6
        ToolTipItem15.Text = "Утвердить работу"
        SuperToolTip16.Items.Add(ToolTipTitleItem16)
        SuperToolTip16.Items.Add(ToolTipItem15)
        Me.LeaderWorkAcceptBarButtonItem.SuperTip = SuperToolTip16
        '
        'LeaderWorkBackBarButtonItem
        '
        Me.LeaderWorkBackBarButtonItem.Caption = "ВОЗВРАТ"
        Me.LeaderWorkBackBarButtonItem.Id = 14
        Me.LeaderWorkBackBarButtonItem.LargeGlyph = CType(resources.GetObject("LeaderWorkBackBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LeaderWorkBackBarButtonItem.Name = "LeaderWorkBackBarButtonItem"
        ToolTipTitleItem17.Text = "Возврат"
        ToolTipItem16.LeftIndent = 6
        ToolTipItem16.Text = "Возврат работы на доработку"
        SuperToolTip17.Items.Add(ToolTipTitleItem17)
        SuperToolTip17.Items.Add(ToolTipItem16)
        Me.LeaderWorkBackBarButtonItem.SuperTip = SuperToolTip17
        '
        'LeaderDataReloadBarButtonItem
        '
        Me.LeaderDataReloadBarButtonItem.Caption = "ПЕРЕЧИТАТЬ"
        Me.LeaderDataReloadBarButtonItem.Id = 15
        Me.LeaderDataReloadBarButtonItem.LargeGlyph = CType(resources.GetObject("LeaderDataReloadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LeaderDataReloadBarButtonItem.Name = "LeaderDataReloadBarButtonItem"
        ToolTipTitleItem18.Text = "Перечитать"
        ToolTipItem17.LeftIndent = 6
        ToolTipItem17.Text = "Перечитать работу из базы данных"
        SuperToolTip18.Items.Add(ToolTipTitleItem18)
        SuperToolTip18.Items.Add(ToolTipItem17)
        Me.LeaderDataReloadBarButtonItem.SuperTip = SuperToolTip18
        '
        'ExpertWorkSignBarButtonItem
        '
        Me.ExpertWorkSignBarButtonItem.Caption = "ПОДПИСАТЬ"
        Me.ExpertWorkSignBarButtonItem.Id = 16
        Me.ExpertWorkSignBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertWorkSignBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertWorkSignBarButtonItem.Name = "ExpertWorkSignBarButtonItem"
        ToolTipTitleItem19.Text = "Подписать"
        ToolTipItem18.LeftIndent = 6
        ToolTipItem18.Text = "Подписать итоговые документы по работе"
        SuperToolTip19.Items.Add(ToolTipTitleItem19)
        SuperToolTip19.Items.Add(ToolTipItem18)
        Me.ExpertWorkSignBarButtonItem.SuperTip = SuperToolTip19
        '
        'WorkHistoryBarButtonItem
        '
        Me.WorkHistoryBarButtonItem.Caption = "ИСТОРИЯ"
        Me.WorkHistoryBarButtonItem.Id = 17
        Me.WorkHistoryBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkHistoryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkHistoryBarButtonItem.Name = "WorkHistoryBarButtonItem"
        ToolTipTitleItem20.Text = "История"
        ToolTipItem19.LeftIndent = 6
        ToolTipItem19.Text = "Показать историю работы"
        SuperToolTip20.Items.Add(ToolTipTitleItem20)
        SuperToolTip20.Items.Add(ToolTipItem19)
        Me.WorkHistoryBarButtonItem.SuperTip = SuperToolTip20
        '
        'LeaderPlaneCalcBarButtonItem
        '
        Me.LeaderPlaneCalcBarButtonItem.Caption = "СТОИМОСТЬ"
        Me.LeaderPlaneCalcBarButtonItem.Id = 18
        Me.LeaderPlaneCalcBarButtonItem.LargeGlyph = CType(resources.GetObject("LeaderPlaneCalcBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LeaderPlaneCalcBarButtonItem.Name = "LeaderPlaneCalcBarButtonItem"
        ToolTipTitleItem21.Text = "Стоимость"
        ToolTipItem20.LeftIndent = 6
        ToolTipItem20.Text = "Рассчитать стоимость работы"
        SuperToolTip21.Items.Add(ToolTipTitleItem21)
        SuperToolTip21.Items.Add(ToolTipItem20)
        Me.LeaderPlaneCalcBarButtonItem.SuperTip = SuperToolTip21
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ExpertDataRibbonPageGroup, Me.ExpertPlaneRibbonPageGroup, Me.ExpertProjectRibbonPageGroup, Me.ExpertWorkRibbonPageGroup, Me.LeaderDataRibbonPageGroup, Me.LeaderPlaneRibbonPageGroup, Me.LeaderWorkRibbonPageGroup, Me.WorkHistoryRibbonPageGroup})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Главное меню"
        '
        'ExpertDataRibbonPageGroup
        '
        Me.ExpertDataRibbonPageGroup.ItemLinks.Add(Me.ExpertDataSaveBarButtonItem)
        Me.ExpertDataRibbonPageGroup.ItemLinks.Add(Me.ExpertDataReloadBarButtonItem)
        Me.ExpertDataRibbonPageGroup.ItemLinks.Add(Me.ExpertDataImportBarButtonItem, True)
        Me.ExpertDataRibbonPageGroup.Name = "ExpertDataRibbonPageGroup"
        Me.ExpertDataRibbonPageGroup.ShowCaptionButton = False
        Me.ExpertDataRibbonPageGroup.Text = "Данные"
        '
        'ExpertPlaneRibbonPageGroup
        '
        Me.ExpertPlaneRibbonPageGroup.ItemLinks.Add(Me.ExpertPlaneCheckBarButtonItem)
        Me.ExpertPlaneRibbonPageGroup.ItemLinks.Add(Me.ExpertPlaneSendBarButtonItem)
        Me.ExpertPlaneRibbonPageGroup.Name = "ExpertPlaneRibbonPageGroup"
        Me.ExpertPlaneRibbonPageGroup.ShowCaptionButton = False
        Me.ExpertPlaneRibbonPageGroup.Text = "План работы"
        '
        'ExpertProjectRibbonPageGroup
        '
        Me.ExpertProjectRibbonPageGroup.ItemLinks.Add(Me.ExpertProjectCreateBarButtonItem)
        Me.ExpertProjectRibbonPageGroup.Name = "ExpertProjectRibbonPageGroup"
        Me.ExpertProjectRibbonPageGroup.ShowCaptionButton = False
        Me.ExpertProjectRibbonPageGroup.Text = "Проект"
        '
        'ExpertWorkRibbonPageGroup
        '
        Me.ExpertWorkRibbonPageGroup.ItemLinks.Add(Me.ExpertWorkToPlaneBarButtonItem)
        Me.ExpertWorkRibbonPageGroup.ItemLinks.Add(Me.ExpertWorkCheckBarButtonItem)
        Me.ExpertWorkRibbonPageGroup.ItemLinks.Add(Me.ExpertWorkSendBarButtonItem)
        Me.ExpertWorkRibbonPageGroup.ItemLinks.Add(Me.ExpertWorkBackBarButtonItem)
        Me.ExpertWorkRibbonPageGroup.ItemLinks.Add(Me.ExpertWorkSignBarButtonItem)
        Me.ExpertWorkRibbonPageGroup.Name = "ExpertWorkRibbonPageGroup"
        Me.ExpertWorkRibbonPageGroup.ShowCaptionButton = False
        Me.ExpertWorkRibbonPageGroup.Text = "Работа"
        '
        'LeaderDataRibbonPageGroup
        '
        Me.LeaderDataRibbonPageGroup.ItemLinks.Add(Me.LeaderDataReloadBarButtonItem)
        Me.LeaderDataRibbonPageGroup.Name = "LeaderDataRibbonPageGroup"
        Me.LeaderDataRibbonPageGroup.ShowCaptionButton = False
        Me.LeaderDataRibbonPageGroup.Text = "Данные"
        '
        'LeaderPlaneRibbonPageGroup
        '
        Me.LeaderPlaneRibbonPageGroup.ItemLinks.Add(Me.LeaderPlaneAcceptBarButtonItem)
        Me.LeaderPlaneRibbonPageGroup.ItemLinks.Add(Me.LeaderPlaneBackBarButtonItem)
        Me.LeaderPlaneRibbonPageGroup.ItemLinks.Add(Me.LeaderPlaneCalcBarButtonItem, True)
        Me.LeaderPlaneRibbonPageGroup.Name = "LeaderPlaneRibbonPageGroup"
        Me.LeaderPlaneRibbonPageGroup.ShowCaptionButton = False
        Me.LeaderPlaneRibbonPageGroup.Text = "План работы"
        '
        'LeaderWorkRibbonPageGroup
        '
        Me.LeaderWorkRibbonPageGroup.ItemLinks.Add(Me.LeaderWorkAcceptBarButtonItem)
        Me.LeaderWorkRibbonPageGroup.ItemLinks.Add(Me.LeaderWorkBackBarButtonItem)
        Me.LeaderWorkRibbonPageGroup.Name = "LeaderWorkRibbonPageGroup"
        Me.LeaderWorkRibbonPageGroup.ShowCaptionButton = False
        Me.LeaderWorkRibbonPageGroup.Text = "Работа"
        '
        'WorkHistoryRibbonPageGroup
        '
        Me.WorkHistoryRibbonPageGroup.ItemLinks.Add(Me.WorkHistoryBarButtonItem)
        Me.WorkHistoryRibbonPageGroup.Name = "WorkHistoryRibbonPageGroup"
        Me.WorkHistoryRibbonPageGroup.ShowCaptionButton = False
        Me.WorkHistoryRibbonPageGroup.Text = "История"
        '
        'SpellChecker1
        '
        Me.SpellChecker1.CheckAsYouTypeOptions.CheckControlsInParentContainer = True
        Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("ru-RU")
        Me.SpellChecker1.ParentContainer = Nothing
        Me.SpellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
        Me.SpellChecker1.SpellingFormType = DevExpress.XtraSpellChecker.SpellingFormType.Word
        '
        'WorkUserControl
        '
        Me.Controls.Add(Me.MainPanelControl)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.MainWindowsUIButtonPanel)
        Me.Controls.Add(Me.ContentDockPanel)
        Me.Controls.Add(Me.hideContainerBottom)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "WorkUserControl"
        Me.Size = New System.Drawing.Size(1150, 450)
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hideContainerBottom.ResumeLayout(False)
        Me.ErrorDockPanel.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.ErrorGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContentDockPanel.ResumeLayout(False)
        Me.ControlContainer1.ResumeLayout(False)
        CType(Me.ContentTreeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ''' <summary>
    ''' Работа
    ''' </summary>
    Public Shadows Property Work As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Данные проверены на сохранение после изменения
    ''' </summary>
    Public Overrides ReadOnly Property IsCheckDataSaved As Boolean
        Get
            If Not WorkDataExist Then Return True
            If Not ( _
                WorkEditableForExpert OrElse _
                WorkEditableForLeader OrElse _
                PlaneEditableForExpert OrElse _
                PlaneEditableForLeader) Then Return True
            If Not Work.IsChangedAfterSave Then Return True
            Select Case Cprp.DxCommon.Messages.ShowQuestionCancel("Данные работы были изменены. Сохранить?", String.Format("Работа № {0}", CInt(Work.Id)))
                Case DialogResult.Yes
                    '
                    ' Сохранение данных текущего элемента управления
                    '
                    MyClass.CloseEditor()
                    '
                    ' Дата сохранения данных
                    '
                    MyClass.Work.ARow("saveDate") = Date.Now
                    '
                    ' Сохранение работы
                    '
                    Work.DataSave()
                    '
                    ' Запись в историю работы события сохранения данных
                    '
                    MyClass.Work.WriteHistory(Cprp.DxData.Work.WorkEvent.DataSave, Nothing)
                Case DialogResult.Cancel
                    Return False
            End Select
            Return True
        End Get
    End Property


#Region "Элементы управления"

    Private _ContentControl As ContentChildControl = Nothing
    ''' <summary>
    ''' Содержание работы
    ''' </summary>
    Private ReadOnly Property ContentControl As ContentChildControl
        Get
            If _ContentControl Is Nothing Then
                _ContentControl = New ContentChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _ContentControl
        End Get
    End Property

    Private _PlaneControl As PlaneChildControl = Nothing
    ''' <summary>
    ''' План работы
    ''' </summary>
    Private ReadOnly Property PlaneControl As PlaneChildControl
        Get
            If _PlaneControl Is Nothing Then
                _PlaneControl = New PlaneChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _PlaneControl
        End Get
    End Property

    Private _MemberDataControl As MemberDataChildControl = Nothing
    ''' <summary>
    ''' Регистрационные данные российского участника внешнеэкономической операции
    ''' </summary>
    Private ReadOnly Property MemberDataControl As MemberDataChildControl
        Get
            If _MemberDataControl Is Nothing Then
                _MemberDataControl = New MemberDataChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _MemberDataControl
        End Get
    End Property

    Private _GoodTreeControl As GoodTreeChildControl = Nothing
    ''' <summary>
    ''' Список продукции в виде дерева
    ''' </summary>
    Private ReadOnly Property GoodTreeControl As GoodTreeChildControl
        Get
            If _GoodTreeControl Is Nothing Then
                _GoodTreeControl = New GoodTreeChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _GoodTreeControl
        End Get
    End Property

    Private _GoodListControl As GoodListChildControl = Nothing
    ''' <summary>
    ''' Список продукции в виде таблицы
    ''' </summary>
    Private ReadOnly Property GoodListControl As GoodListChildControl
        Get
            If _GoodListControl Is Nothing Then
                _GoodListControl = New GoodListChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _GoodListControl
        End Get
    End Property

    Private _GoodDataControl As GoodDataChildControl = Nothing
    ''' <summary>
    ''' Регистрационные данные объекта экспертизы
    ''' </summary>
    Private ReadOnly Property GoodDataControl As GoodDataChildControl
        Get
            If _GoodDataControl Is Nothing Then
                _GoodDataControl = New GoodDataChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _GoodDataControl
        End Get
    End Property

    Private _GoodLawControl As GoodLawChildControl = Nothing
    ''' <summary>
    ''' Классификатор ПВН объекта экспертизы
    ''' </summary>
    Private ReadOnly Property GoodLawControl As GoodLawChildControl
        Get
            If _GoodLawControl Is Nothing Then
                _GoodLawControl = New GoodLawChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _GoodLawControl
        End Get
    End Property

    Private _GoodSummaryControl As GoodSummaryChildControl = Nothing
    ''' <summary>
    ''' Сравнительный анализ объекта экспертизы
    ''' </summary>
    Private ReadOnly Property GoodSummaryControl As GoodSummaryChildControl
        Get
            If _GoodSummaryControl Is Nothing Then
                _GoodSummaryControl = New GoodSummaryChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _GoodSummaryControl
        End Get
    End Property

    Private _SummaryControl As SummaryChildControl = Nothing
    ''' <summary>
    ''' Решение по анализу
    ''' </summary>
    Private ReadOnly Property SummaryControl As SummaryChildControl
        Get
            If _SummaryControl Is Nothing Then
                _SummaryControl = New SummaryChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _SummaryControl
        End Get
    End Property

    Private _ExtraDocControl As ExtraDocChildControl = Nothing
    ''' <summary>
    ''' Перечень документов
    ''' </summary>
    Private ReadOnly Property ExtraDocControl As ExtraDocChildControl
        Get
            If _ExtraDocControl Is Nothing Then
                _ExtraDocControl = New ExtraDocChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _ExtraDocControl
        End Get
    End Property

    Private _ProjectControl As ProjectChildControl = Nothing
    ''' <summary>
    ''' Проект заключения
    ''' </summary>
    Private ReadOnly Property ProjectControl As ProjectChildControl
        Get
            If _ProjectControl Is Nothing Then
                _ProjectControl = New ProjectChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _ProjectControl
        End Get
    End Property

    Private _RequestControl As RequestChildControl = Nothing
    ''' <summary>
    ''' Запросы
    ''' </summary>
    Private ReadOnly Property RequestControl As RequestChildControl
        Get
            If _RequestControl Is Nothing Then
                _RequestControl = New RequestChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _RequestControl
        End Get
    End Property

#End Region
#Region "Главное меню"

    ''' <summary>
    ''' Закрыть активный редактор
    ''' </summary>
    Private Sub CloseEditor()
        If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
            CType(MainPanelControl.Controls(0), ChildUserControl).DataWrite()
        End If
    End Sub

    ''' <summary>
    ''' Эксперт - Сохранить данные в базу
    ''' </summary>
    Private Sub ExpertDataSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertDataSaveBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Сохранение данных текущего элемента управления
            '
            MyClass.CloseEditor()
            '
            ' Создание резервной копии данных работы
            '
            Dim filePath As String = String.Format("{0}\{1}.work", My.Computer.FileSystem.SpecialDirectories.Temp, CInt(Work.Id))
            Work.DS.WriteXml(filePath, XmlWriteMode.IgnoreSchema)
            '
            ' Дата сохранения данных
            '
            MyClass.Work.ARow("saveDate") = Date.Now
            '
            ' Сохранение работы
            '
            Work.DataSave()
            '
            ' Запись в историю работы события сохранения данных
            '
            MyClass.Work.WriteHistory(Cprp.DxData.Work.WorkEvent.DataSave, Nothing)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Перечитать данные из базы
    ''' </summary>
    Private Sub ExpertDataReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertDataReloadBarButtonItem.ItemClick
        If MyClass.Work.IsChangedAfterSave Then
            If Cprp.DxCommon.Messages.ShowQuestion("Все несохраненные данные будут удалены. Продолжить?") <> DialogResult.Yes Then Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Перечитывание данных из базы и файла данных
            '
            MyClass.Work.Id = MyClass.Work.Id
            '
            ' Перечитывание данных текущего элемента управления
            '
            If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
            End If
            '
            ' Перечитывание состояния кнопок главного меню
            '
            RibbonUpdate()
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Загрузить данные из другой работы
    ''' </summary>
    Private Sub ExpertDataImportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertDataImportBarButtonItem.ItemClick
        Try
            Using F As New WorkCopyForm(Work)
                If F.ShowDialog(Me.ParentForm) <> DialogResult.OK Then Exit Sub
            End Using
            ContentOpen(ContentEnum.Content, C2.EMPTY_ID)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Проверить план работы на наличие ошибок
    ''' </summary>
    Private Sub ExpertPlaneCheckBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertPlaneCheckBarButtonItem.ItemClick
        If Not ExpertPlaneCheckBarButtonItem.Down Then
            Me.ErrorTable.Rows.Clear()
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Сохранение данных текущего элемента управления
            '
            MyClass.CloseEditor()
            '
            ' Проверка работы
            '
            Dim bTmp As Boolean = Me.ErrorTable.CheckWork()
            Cprp.DxCommon.WaitForm.Close()
            If bTmp Then
                Cprp.DxCommon.Messages.ShowInformation("Ошибок нет.", "Проверка")
            Else
                Cprp.DxCommon.Messages.ShowError("В плане работы обнаружены ошибки.", "Проверка")
                ErrorDockPanel.Show()
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Отправить план работы на утверждение руководителю экспертизы
    ''' </summary>
    Private Sub ExpertPlaneSendBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertPlaneSendBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Отправить план работы на утверждение руководителю экспертизы?") <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Сохранение данных текущего элемента управления
            '
            MyClass.CloseEditor()
            '
            ' Проверка работы на наличие формальных ошибок
            '
            If Not Me.ErrorTable.CheckWork Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError("В работе обнаружены ошибки.")
                ErrorDockPanel.Show()
                Exit Sub
            End If
            Cprp.DxCommon.WaitForm.Close()
            '
            ' Проверка корректности срока и времени исполнения работы
            '
            Dim dTmp As Date = Nothing
            Dim sTmp As String = Nothing
            If Not IsDBNull(MyClass.Work.ARow("expertTerm")) Then
                dTmp = CDate(MyClass.Work.ARow("expertTerm"))
                '
                ' Срок исполнения
                '
                If dTmp < Date.Now.AddHours(1) Then
                    sTmp = String.Format("Срок исполнения работы: {0:dd.MM.yyyy HH:mm}.{1}Вы действительно хотите отправить план работы на утверждение?", dTmp, vbCrLf)
                    If Cprp.DxCommon.Messages.ShowQuestion(sTmp) <> DialogResult.Yes Then Exit Sub
                    MyClass.Work.WriteHistory(WorkEvent.SystemWarning, sTmp.Replace(vbCrLf, " "))
                End If
                '
                ' Время исполнения
                '
                If dTmp.Hour < 9 OrElse dTmp.Hour > 18 Then
                    sTmp = String.Format("Время исполнения работы: {0:HH:mm}.{1}Вы действительно хотите отправить план работы на утверждение?", dTmp, vbCrLf)
                    If Cprp.DxCommon.Messages.ShowQuestion(sTmp) <> DialogResult.Yes Then Exit Sub
                    MyClass.Work.WriteHistory(WorkEvent.SystemWarning, sTmp.Replace(vbCrLf, " "))
                End If
            End If
            '
            ' Создание документа плана работы
            '
            MyClass.Work.PlaneDocumentCreate()
            '
            ' Отправка плана работы на утверждение, запись в историю работы
            '
            MyClass.Work("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsPlaneAgree)
            MyClass.Work.DataSave()
            MyClass.Work.WriteHistory(DxData.Work.WorkEvent.PlaneSend, Nothing)
            '
            ' Перечитывание состояния и данных текущего элемента управления
            '
            If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
            End If
            '
            ' Перечитывание состояния кнопок главного меню
            '
            RibbonUpdate()
            Cprp.DxCommon.Messages.ShowInformation("План работы отправлен на утверждение руководителю экспертизы.")
            '
            ' Закрыть текущий элемент управления
            '
            If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Создать проекты итоговых документов
    ''' </summary>
    Private Sub ExpertProjectCreateBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertProjectCreateBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Создать новые проекты заключений?") <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Сохранение данных текущего элемента управления
            '
            MyClass.CloseEditor()
            '
            ' Создание проектов
            '
            MyClass.Work.ProjectCreate()
            '
            ' Дата создания проектов
            '
            MyClass.Work.ARow("projectDate") = Date.Now
            '
            ' Запись в историю работы события создания проектов
            '
            MyClass.Work.WriteHistory(DxData.Work.WorkEvent.ProjectCreate, Nothing)
            Cprp.DxCommon.WaitForm.Close()
            '
            ' Переход к проекту заключения #1
            '
            Me.Project1Show = True
            ContentOpen(ContentEnum.Project, False)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Включить работу в мой план работ
    ''' </summary>
    Private Sub ExpertWorkToPlaneBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertWorkToPlaneBarButtonItem.ItemClick
        Try
            '
            ' Проверка, что работу уже не включил в свой план другой эксперт
            '
            MyClass.Work.Id = MyClass.Work.Id
            If Not IsDBNull(MyClass.Work("expertId")) Then
                Cprp.DxCommon.Messages.ShowWarning("Работа уже включена в план эксперта.")
            Else
                If Cprp.DxCommon.Messages.ShowQuestion("Включить работу в Ваш план работ?") <> DialogResult.Yes Then Exit Sub
                '
                ' Проверка превышения срока распределения работы
                '
                Dim dTmp As New TimeSpan(0)
                If Not IsDBNull(MyClass.Work("expertTerm")) Then dTmp = Date.Now - CDate(MyClass.Work("expertTerm"))
                '
                ' Включение работы в план эксперта, запись в историю работы
                '
                Cprp.DxData.Work.Common.WorkTake( _
                    MyClass.Work.Id, _
                    Cprp.DxData.User.Common.CurrentUserId(MyClass.Work.Connection), _
                    MyClass.Work.Connection, _
                    False, _
                    False)
                MyClass.Work.Id = MyClass.Work.Id
                '
                ' Перечитывание состояния и данных текущего элемента управления
                '
                If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                    CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
                End If
                '
                ' Перечитывание состояния кнопок главного меню
                '
                RibbonUpdate()
                Cprp.DxCommon.Messages.ShowInformation("Работа включена в Ваш план работ.")
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Проверить работу на наличие ошибок
    ''' </summary>
    Private Sub ExpertWorkCheckBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertWorkCheckBarButtonItem.ItemClick
        If Not ExpertWorkCheckBarButtonItem.Down Then
            Me.ErrorTable.Rows.Clear()
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Сохранение данных текущего элемента управления
            '
            MyClass.CloseEditor()
            '
            ' Проверка работы
            '
            Dim bTmp As Boolean = Me.ErrorTable.CheckWork()
            Cprp.DxCommon.WaitForm.Close()
            If bTmp Then
                Cprp.DxCommon.Messages.ShowInformation("Ошибок нет.", "Проверка")
            Else
                Cprp.DxCommon.Messages.ShowError("В работе обнаружены ошибки.", "Проверка")
                ErrorDockPanel.Show()
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Отправить работу на утверждение руководителю экспертизы
    ''' </summary>
    Private Sub ExpertWorkSendBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertWorkSendBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Отправить работу на утверждение руководителю экспертизы?") <> DialogResult.Yes Then Exit Sub
        '
        ' Работы в состоянии "Запрос" на утверждение не отправляются
        '
        If Me.Work.Condition = Cprp.DxData.Work.WorkCondition.IsQuery Then
            Cprp.DxCommon.Messages.ShowWarning("Работы в состоянии ""Запрос"" на утверждение не отправляются.")
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Сохранение данных текущего элемента управления
            '
            MyClass.CloseEditor()
            '
            ' Проверка работы на наличие формальных ошибок
            '
            If Not Me.ErrorTable.CheckWork Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError("В работе обнаружены ошибки.")
                ErrorDockPanel.Show()
                Exit Sub
            End If
            Cprp.DxCommon.WaitForm.Close()
            '
            ' Проверка наличия проектов заключений
            '
            If IsDBNull(MyClass.Work.ARow("doc1Data")) Then
                Cprp.DxCommon.Messages.ShowError( _
                        "В работе отсутствует проект заключения. Создайте проект заключения.")
                Exit Sub
            End If
            '
            ' Проверка соответствия текущих данных работы данным, по которым создавались проекты итоговых документов
            '
            If MyClass.Work.isChangedAfterProject Then
                Cprp.DxCommon.Messages.ShowError(String.Format( _
                    "Данные работы были изменены после создания проектов заключений.{0}Создайте новые проекты заключений.", vbCrLf))
                Exit Sub
            End If
            '
            ' Перечитывание содержания работы
            '
            ContentControl.DataRead()
            ContentControl.DataWrite()
            '
            ' Отправка работы на утверждение, запись в историю работы
            '
            MyClass.Work("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsAgree)
            MyClass.Work.DataSave()
            MyClass.Work.WriteHistory(DxData.Work.WorkEvent.WorkSend, Nothing)
            '
            ' Перечитывание состояния и данных текущего элемента управления
            '
            If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
            End If
            '
            ' Перечитывание состояния кнопок главного меню
            '
            RibbonUpdate()
            Cprp.DxCommon.Messages.ShowInformation("Работа отправлена на утверждение руководителю экспертизы.")
            '
            ' Закрыть текущий элемент управления
            '
            If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - Вернуть работу на доработку
    ''' </summary>
    Private Sub ExpertWorkBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertWorkBackBarButtonItem.ItemClick
        Try
            '
            ' Проверка, что работа уже утверждена
            '
            MyClass.Work.Id = MyClass.Work.Id
            If MyClass.Work.Condition <> WorkCondition.IsCheck AndAlso MyClass.Work.Condition <> WorkCondition.IsAgree Then
                Cprp.DxCommon.Messages.ShowWarning("Работа уже утверждена.")
            Else
                If Cprp.DxCommon.Messages.ShowQuestion("Вернуть работу на доработку?") <> DialogResult.Yes Then Exit Sub
                '
                ' Изменение состояния работы
                '
                MyClass.Work.Condition = WorkCondition.IsWork
                MyClass.Work.DataSave()
                '
                ' Перечитывание состояния и данных текущего элемента управления
                '
                If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                    CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
                End If
                '
                ' Перечитывание состояния кнопок главного меню
                '
                RibbonUpdate()
                Cprp.DxCommon.Messages.ShowInformation("Работа возвращена на доработку.")
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Эксперт - подписать итоговые документы по работе
    ''' </summary>
    Private Sub ExpertWorkSignBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertWorkSignBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show()
        Try
            '
            ' Создание подписанных файлов документов и передача их в ЕО
            '
            MyClass.Work.DocumentCreate()
            '
            ' Перенос данных в архивную базу
            '
            MyClass.Work.DataArchive()
            '
            ' Перевод работы в состояние "Утверждена" 
            '
            MyClass.Work("conditionId") = CInt(WorkCondition.IsAccept)
            MyClass.Work.DataSave()
            '
            ' Отправка в ЭО сообщения об изменении работы
            '
            Work.MessageWorkChangeEo()
            '
            ' Запись в историю работы события подписания итоговых документов
            '
            MyClass.Work.WriteHistory(Cprp.DxData.Work.WorkEvent.ExpertSignature, Nothing)
            '
            ' Перечитывание состояния кнопок главного меню
            '
            RibbonUpdate()
            Cprp.DxCommon.Messages.ShowInformation("Итоговые документы подписаны.")
            '
            ' Закрыть текущий элемент управления
            '
            If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
            End If
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Руководитель - Перечитать данные из базы
    ''' </summary>
    Private Sub LeaderDataReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LeaderDataReloadBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Перечитывание данных из базы и файла данных
            '
            MyClass.Work.Id = MyClass.Work.Id
            '
            ' Перечитывание данных текущего элемента управления
            '
            If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
            End If
            '
            ' Перечитывание состояния кнопок главного меню
            '
            RibbonUpdate()
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Руководитель - Утвердить план работы
    ''' </summary>
    Private Sub LeaderPlaneAcceptBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LeaderPlaneAcceptBarButtonItem.ItemClick
        Try
            MyBase.WorkFieldUpdate()
            '
            ' Проверка остановки работы
            '
            If Not IsDBNull(Work("isStop")) AndAlso CBool(Work("isStop")) Then
                If Cprp.DxCommon.Messages.ShowQuestion("Работа остановлена. Снять отметку об остановке?") <> DialogResult.Yes Then Exit Sub
                Work("isStop") = False
                Work.WriteHistory(WorkEvent.WorkStart, Nothing)
            End If
            '
            ' Проверка наличия неутвержденных запросов по работе
            '
            If CBool(Work("isAsk")) Then
                Cprp.DxCommon.Messages.ShowWarning("В работе есть неутвержденный запрос.")
                ContentOpen(ContentEnum.Request, Nothing)
                Exit Sub
            End If
            '
            ' Проверка работы на наличие формальных ошибок
            '
            MyClass.CloseEditor()
            If Not Me.ErrorTable.CheckWork Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError("В плане работы обнаружены ошибки.")
                ErrorDockPanel.Show()
                Exit Sub
            End If
            '
            ' Если работа числится за другим руководителем, делегировать ее себе
            '
            If Not MyBase.WorkDelegate() Then Exit Sub
            '
            ' Расчет стоимости работы
            '
            MyClass.CloseEditor()
            Me.Work.ReCalc()
            If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Стоимость работы: {0:n2} / {1:n2} р. Утвердить план работы?", CSng(Me.Work("price")), CSng(Me.Work.ARow("priceG")))) <> DialogResult.Yes Then Exit Sub
            '
            ' Перевод работы в состояние "В работе", запись данных из плана в работу
            '
            MyClass.Work("conditionId") = CInt(WorkCondition.IsWork)
            With MyClass.Work.ARow
                MyClass.Work("typeId") = .Item("typeId")
                MyClass.Work("goodCount") = CInt(.Item("matCount")) + CInt(.Item("infCount"))
                MyClass.Work("goodAllCount") = .Item("goodCount")
                MyClass.Work("totalWork") = .Item("totalWork")
                MyClass.Work("extraWork") = CInt(.Item("findCount")) + CInt(.Item("langCount"))
                MyClass.Work("expertTerm") = .Item("expertTerm")
                MyClass.Work("urgencyId") = .Item("urgencyId")
                MyClass.Work("isUrgency") = .Item("isUrgency")
            End With
            '
            ' Срок выдачи работы
            '
            MyClass.Work.UpdateOrderTerm()
            '
            ' Сохранение данных работы
            '
            MyClass.Work.DataSave()
            '
            ' Отправка в ЭО сообщения об изменении работы
            '
            Work.MessageWorkChangeEo()
            '
            ' Создание файла документа плана и передача его в ЭО
            '
            MyClass.Work.PlaneDocumentCreate()
            MyClass.Work.PlaneDocumentToEO()
            '
            ' Создание дубликатов работы
            '
            'If CInt(Work.ARow("addWorkCount")) > 0 Then
            '    Using T As New DataTable
            '        T.Columns.Add("id", GetType(Integer))
            '        T.Columns.Add("dbId", GetType(Integer))
            '        With T.Columns("id")
            '            .AllowDBNull = False
            '            .AutoIncrement = True
            '            .AutoIncrementSeed = 1
            '            .AutoIncrementStep = 1
            '        End With
            '        T.PrimaryKey = New DataColumn() {T.Columns("id")}
            '        T.Load(Work.ExecuteReader("SELECT * FROM tWork WHERE id IS NULL"))
            '        Using A As New SqlDataAdapter("SELECT * FROM tWork", Work.Connection)
            '            Dim B As New SqlCommandBuilder(A)
            '            Dim Row As DataRow = Nothing
            '            For i As Integer = 0 To CInt(Work.ARow("addWorkCount")) - 1
            '                Row = T.NewRow
            '                For Each C As DataColumn In Work.Columns
            '                    If C.ColumnName.ToUpper Like "ID" Then
            '                        Continue For
            '                    ElseIf C.ColumnName.ToUpper Like "GUID" Then
            '                        Row(C.ColumnName) = System.Guid.NewGuid.ToString
            '                    Else
            '                        Row(C.ColumnName) = Work(C.ColumnName)
            '                    End If
            '                Next
            '                Row("createDate") = Date.Now
            '                T.Rows.Add(Row)
            '                A.Update(T)
            '                Row("dbId") = Work.ExecuteScalar("SELECT @@IDENTITY FROM tWork")
            '            Next
            '        End Using
            '        '
            '        ' Отправка в ЭО сообщений о новых работах
            '        '
            '        Using W As New WorkConnectionRow(-1, Work.Connection)
            '            For Each Row In T.Rows
            '                W.Id = Row("dbId")
            '                W.MessageWorkNewEo()
            '            Next
            '        End Using
            '    End Using
            'End If
            '
            ' Запись в историю работы события утверждения работы
            '
            MyClass.Work.WriteHistory(WorkEvent.PlaneAccept, Nothing)
            '
            ' Отправка эксперту email-уведомления об утверждении плана работы
            '
            Dim fromId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(MyClass.Work.Connection))
            Dim fromName As String = Nothing
            Dim fromEmail As String = Nothing
            Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", fromId))
                If Dr.Read Then
                    fromName = C2.ToText(Dr("nameShort"))
                    fromEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If Not C2.IsText(fromEmail) Then fromEmail = "system@excont.ru"
            Dim toId As Integer = C2.ToInt(MyClass.Work("expertId"))
            Dim toName As String = Nothing
            Dim toEmail As String = Nothing
            Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", toId))
                If Dr.Read Then
                    toName = C2.ToText(Dr("nameShort"))
                    toEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If C2.IsText(toEmail) Then
                Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", MyClass.Work.Connection)
                Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", MyClass.Work.Connection)
                Dim sCaption As String = String.Format("УТВЕРЖДЕНИЕ ПЛАНА РАБОТЫ (Работа № {0})", CInt(MyClass.Work.Id))
                Dim sBody As String = String.Format("{0} утвердил план Вашей работы № {1}", fromName, CInt(MyClass.Work.Id))
                Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                    S.Send(fromEmail, toEmail, sCaption, sBody)
                End Using
            End If
            '
            ' Закрыть текущий элемент управления
            '
            If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Руководитель - Вернуть план работы на доработку
    ''' </summary>
    Private Sub LeaderPlaneBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LeaderPlaneBackBarButtonItem.ItemClick
        Try
            '
            ' Если работа числится за другим руководителем, делегировать ее себе
            '
            If Not MyBase.WorkDelegate() Then Exit Sub
            '
            ' Комментарий руководителя экспертизы к возврату плана работы
            '
            Dim comment As String = Nothing
            Using F As New PlaneBackForm()
                F.Text = String.Format("Работа № {0} - Возврат плана на доработку", CInt(MyClass.Work.Id))
                If F.ShowDialog <> DialogResult.OK Then Exit Sub
                comment = C2.ToText(F.CommentMemoEdit.Text)
            End Using
            '
            ' Перевод работы в состояние "Подготовка плана"
            '
            MyClass.Work("conditionId") = CInt(WorkCondition.IsPlaneWork)
            MyClass.Work("acceptDate") = DBNull.Value
            MyClass.Work.DataSave()
            '
            ' Запись в историю работы события возврата работы
            '
            MyClass.Work.WriteHistory(WorkEvent.BackCheck, comment)
            '
            ' Отправка эксперту email-уведомления о возврате плана на доработку
            '
            Dim fromId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(MyClass.Work.Connection))
            Dim fromName As String = Nothing
            Dim fromEmail As String = Nothing
            Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", fromId))
                If Dr.Read Then
                    fromName = C2.ToText(Dr("nameShort"))
                    fromEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If Not C2.IsText(fromEmail) Then fromEmail = "system@excont.ru"
            Dim toId As Integer = C2.ToInt(MyClass.Work("expertId"))
            Dim toName As String = Nothing
            Dim toEmail As String = Nothing
            Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", toId))
                If Dr.Read Then
                    toName = C2.ToText(Dr("nameShort"))
                    toEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If C2.IsText(toEmail) Then
                Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", MyClass.Work.Connection)
                Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", MyClass.Work.Connection)
                Dim sCaption As String = String.Format("ВОЗВРАТ ПЛАНА НА ДОРАБОТКУ (Работа № {0})", CInt(MyClass.Work.Id))
                Dim sBody As String = String.Format("{0} вернул план Вашей работы № {1} на доработку с комментарием:{2}{3}", fromName, CInt(MyClass.Work.Id), vbCr, comment)
                Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                    S.Send(fromEmail, toEmail, sCaption, sBody)
                End Using
            End If
            '
            ' Закрыть текущий элемент управления
            '
            If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Руководитель - Рассчитать стоимость работы
    ''' </summary>
    Private Sub LeaderPlaneCalcBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LeaderPlaneCalcBarButtonItem.ItemClick
        MyClass.CloseEditor()
        Me.Work.ReCalc()
        MyBase.WorkCalcShow()
    End Sub

    ''' <summary>
    ''' Руководитель - Утвердить работу
    ''' </summary>
    Private Sub LeaderWorkAcceptBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LeaderWorkAcceptBarButtonItem.ItemClick
        Try
            '
            ' Проверка, что эксперт не вернул работу
            '
            MyClass.Work.Id = MyClass.Work.Id
            If Not (MyClass.Work.Condition = WorkCondition.IsCheck OrElse MyClass.Work.Condition = WorkCondition.IsAgree) Then
                Cprp.DxCommon.Messages.ShowWarning("Эксперт вернул работу на доработку.")
                '
                ' Перечитывание состояния и данных текущего элемента управления
                '
                If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                    CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
                End If
                '
                ' Перечитывание состояния кнопок главного меню
                '
                RibbonUpdate()
            Else
                '
                ' Если работа числится за другим руководителем, делегировать ее себе
                '
                If Not MyBase.WorkDelegate() Then Exit Sub
                '
                ' Определение суммы баллов за работу
                '
                Dim comment As String = Nothing
                Using F As New WorkAcceptForm(MyClass.Work)
                    If F.ShowDialog <> DialogResult.OK Then Exit Sub
                    MyClass.Work("ballCalc") = F.ballStart
                    MyClass.Work("ballFact") = F.ballFact
                    MyClass.Work.ARow("isExpertSign") = F.ExpertSignCheckEdit.Checked
                    comment = C2.ToText(F.CommentMemoEdit.Text)
                End Using

                Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
                '
                ' Сохранение данных в рабочую базу
                '
                MyClass.Work.DataInsert()
                '
                ' Если заключение подписывается руководителем - создать и подписать документы и передать их в ЭО и архив
                '
                If Not CBool(MyClass.Work.ARow("isExpertSign")) Then
                    MyClass.Work.DocumentCreate()
                    MyClass.Work.DataArchive()
                    MyClass.Work("conditionId") = CInt(WorkCondition.IsAccept)
                Else
                    '
                    ' определение срока эксперта для подписания работы
                    '
                    Dim expertTerm As Date = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 30)
                    If Not IsDBNull(MyClass.Work("expertTerm")) AndAlso CDate(MyClass.Work("expertTerm")) > expertTerm Then
                        expertTerm = CDate(MyClass.Work("expertTerm"))
                    End If
                    MyClass.Work("expertTern") = expertTerm
                    MyClass.Work("conditionId") = CInt(WorkCondition.IsSignature)
                End If
                '
                ' Дата утверждения работы, сохранение данных работы
                '
                MyClass.Work("acceptDate") = Date.Now
                MyClass.Work.DataSave()
                '
                ' Отправка в ЭО сообщения об изменении работы
                '
                Work.MessageWorkChangeEo()
                '
                ' Запись в историю работы события утверждения работы
                '
                MyClass.Work.WriteHistory(WorkEvent.WorkAccept, comment)
                '
                ' Отправка эксперту email-уведомления об утверждении работы
                '
                Dim fromId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(MyClass.Work.Connection))
                Dim fromName As String = Nothing
                Dim fromEmail As String = Nothing
                Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", fromId))
                    If Dr.Read Then
                        fromName = C2.ToText(Dr("nameShort"))
                        fromEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If Not C2.IsText(fromEmail) Then fromEmail = "system@excont.ru"
                Dim toId As Integer = C2.ToInt(MyClass.Work("expertId"))
                Dim toName As String = Nothing
                Dim toEmail As String = Nothing
                Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", toId))
                    If Dr.Read Then
                        toName = C2.ToText(Dr("nameShort"))
                        toEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If C2.IsText(toEmail) Then
                    Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", MyClass.Work.Connection)
                    Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", MyClass.Work.Connection)
                    Dim sCaption As String = String.Format("УТВЕРЖДЕНИЕ РАБОТЫ (Работа № {0})", CInt(MyClass.Work.Id))
                    Dim sBody As String = String.Format("{0} утвердил Вашу работу № {1}", fromName, CInt(MyClass.Work.Id))
                    Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                        S.Send(fromEmail, toEmail, sCaption, sBody)
                    End Using
                End If
                Cprp.DxCommon.WaitForm.Close()
                '
                ' Закрыть текущий элемент управления
                '
                If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                    CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
                End If
            End If                      
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Руководитель - Вернуть работу на доработку
    ''' </summary>
    Private Sub LeaderWorkBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LeaderWorkBackBarButtonItem.ItemClick
        Try
            '
            ' Проверка, что эксперт не вернул работу
            '
            MyClass.Work.Id = MyClass.Work.Id
            If Not (MyClass.Work.Condition = WorkCondition.IsCheck OrElse MyClass.Work.Condition = WorkCondition.IsAgree) Then
                Cprp.DxCommon.Messages.ShowWarning("Эксперт вернул работу на доработку.")
                '
                ' Перечитывание состояния и данных текущего элемента управления
                '
                If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
                    CType(MainPanelControl.Controls(0), ChildUserControl).DataRead()
                End If
                '
                ' Перечитывание состояния кнопок главного меню
                '
                RibbonUpdate()
            Else
                '
                ' Если работа числится за другим руководителем, делегировать ее себе
                '
                If Not MyBase.WorkDelegate() Then Exit Sub
                '
                ' Комментарий руководителя экспертизы к возврату работы
                '
                Dim comment As String = Nothing
                Using F As New WorkBackForm()
                    F.Text = String.Format("Работа № {0} - Возврат на доработку", CInt(MyClass.Work.Id))
                    If F.ShowDialog <> DialogResult.OK Then Exit Sub
                    comment = C2.ToText(F.CommentMemoEdit.Text)
                    If C2.IsText(comment) Then comment = "; " & comment
                    If F.InDocCheckEdit.Checked Then comment = "; " & F.InDocCheckEdit.Text & comment
                    If F.LiteralCheckEdit.Checked Then comment = "; " & F.LiteralCheckEdit.Text & comment
                End Using
                If C2.IsText(comment) Then comment = comment.Substring(2)
                '
                ' Перевод работы в состояние "В работе"
                '
                MyClass.Work("conditionId") = CInt(WorkCondition.IsWork)
                MyClass.Work("acceptDate") = DBNull.Value
                MyClass.Work.DataSave()
                '
                ' Запись в историю работы события возврата работы
                '
                MyClass.Work.WriteHistory(WorkEvent.BackCheck, comment)
                '
                ' Отправка эксперту email-уведомления о возврате на доработку
                '
                Dim fromId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(MyClass.Work.Connection))
                Dim fromName As String = Nothing
                Dim fromEmail As String = Nothing
                Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", fromId))
                    If Dr.Read Then
                        fromName = C2.ToText(Dr("nameShort"))
                        fromEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If Not C2.IsText(fromEmail) Then fromEmail = "system@excont.ru"
                Dim toId As Integer = C2.ToInt(MyClass.Work("expertId"))
                Dim toName As String = Nothing
                Dim toEmail As String = Nothing
                Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", toId))
                    If Dr.Read Then
                        toName = C2.ToText(Dr("nameShort"))
                        toEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If C2.IsText(toEmail) Then
                    Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", MyClass.Work.Connection)
                    Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", MyClass.Work.Connection)
                    Dim sCaption As String = String.Format("ВОЗВРАТ НА ДОРАБОТКУ (Работа № {0})", CInt(MyClass.Work.Id))
                    Dim sBody As String = String.Format("{0} вернул Вашу работу № {1} на доработку с комментарием:{2}{3}", fromName, CInt(MyClass.Work.Id), vbCr, comment)
                    Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                        S.Send(fromEmail, toEmail, sCaption, sBody)
                    End Using
                End If
                '
                ' Закрыть текущий элемент управления
                '
                If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                    CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
                End If
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Показать историю работы
    ''' </summary>
    Private Sub WorkHistoryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkHistoryBarButtonItem.ItemClick
        MyBase.WorkHistoryShow()
    End Sub


    ''' <summary>
    ''' Перечитать состояние кнопок главного меню
    ''' </summary>
    Private Sub RibbonUpdate()
        '
        ' Переменные
        '
        Dim bExpertWork As Boolean = MyBase.WorkEditableForExpert       ' Работа доступна текущему эксперту для редактирования
        Dim bExpertPlane As Boolean = MyBase.PlaneEditableForExpert     ' План работы доступен текущему эксперту для редактирования
        Dim bLeaderWork As Boolean = MyBase.WorkEditableForLeader       ' Работа доступна текущему руководителю для редактирования
        Dim bLeaderPlane As Boolean = MyBase.PlaneEditableForLeader     ' План работы доступен текущему руководителю для редактирования
        '
        ' Эксперт - Сохранить данные в базу
        '
        ExpertDataSaveBarButtonItem.Visibility = If((bExpertWork OrElse bExpertPlane), _
                                                    DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Перечитать данные из базы
        '
        ExpertDataReloadBarButtonItem.Visibility = If(MyBase.CurrentUser.IsExpert, _
                                                      DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Загрузить данные из другой работы 
        '
        ExpertDataImportBarButtonItem.Visibility = If(bExpertWork, _
                                                      DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Проверить план работы на наличие ошибок 
        '
        ExpertPlaneCheckBarButtonItem.Visibility = If(bExpertPlane, _
                                                      DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Отправить план работы на утверждение руководителю экспертизы
        '
        ExpertPlaneSendBarButtonItem.Visibility = If(bExpertPlane, _
                                                     DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Создать проекты итоговых документов
        '
        ExpertProjectCreateBarButtonItem.Visibility = If(bExpertWork, _
                                                         DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Включить работу в мой план работ
        '
        ExpertWorkToPlaneBarButtonItem.Visibility = If((MyBase.WorkDataExist AndAlso MyBase.Work.Condition = WorkCondition.IsNew), _
                                                       DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Проверить работу на наличие ошибок 
        '
        ExpertWorkCheckBarButtonItem.Visibility = If(bExpertWork, _
                                                     DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - Отправить работу на утверждение руководителю экспертизы
        '
        ExpertWorkSendBarButtonItem.Visibility = If(bExpertWork, _
                                                    DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - вернуть работу на доработку
        '
        ExpertWorkBackBarButtonItem.Visibility = If((MyBase.CurrentUserIsWorkExpert AndAlso (MyBase.Work.Condition = WorkCondition.IsCheck OrElse MyBase.Work.Condition = WorkCondition.IsAgree)), _
                                                    DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Эксперт - подписать итоговые документы по работе
        '
        ExpertWorkSignBarButtonItem.Visibility = If((MyBase.CurrentUserIsWorkExpert AndAlso MyBase.Work.Condition = WorkCondition.IsSignature), _
                                                    DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        '
        ' Руководитель - Перечитать данные из базы
        '
        LeaderDataReloadBarButtonItem.Visibility = If(MyBase.CurrentUser.IsLeader, _
                                                      DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Руководитель - Утвердить план работы
        '
        LeaderPlaneAcceptBarButtonItem.Visibility = If(bLeaderPlane, _
                                                       DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Руководитель - Вернуть план работы на доработку
        '
        LeaderPlaneBackBarButtonItem.Visibility = If(bLeaderPlane, _
                                                     DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Руководитель - Рассчитать стоимость работы
        '
        LeaderPlaneCalcBarButtonItem.Visibility = If(bLeaderPlane, _
                                                      DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Руководитель - Утвердить работу
        '
        Dim bTmp As Boolean = bLeaderWork
        If bTmp Then bTmp = Not IsDBNull(Work("orderTerm"))
        LeaderWorkAcceptBarButtonItem.Visibility = If(bTmp, _
                                                       DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Руководитель - Вернуть работу на доработку
        '
        LeaderWorkBackBarButtonItem.Visibility = If(bLeaderWork, _
                                                     DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        '
        ' Группы кнопок
        '
        ExpertDataRibbonPageGroup.Visible = ( _
            ExpertDataSaveBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertDataReloadBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertDataImportBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        ExpertPlaneRibbonPageGroup.Visible = ( _
            ExpertPlaneCheckBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertPlaneSendBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        ExpertProjectRibbonPageGroup.Visible = ( _
            ExpertProjectCreateBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        ExpertWorkRibbonPageGroup.Visible = ( _
            ExpertWorkToPlaneBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertWorkCheckBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertWorkSendBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertWorkBackBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            ExpertWorkSignBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        LeaderDataRibbonPageGroup.Visible = ( _
            LeaderDataReloadBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        LeaderPlaneRibbonPageGroup.Visible = ( _
            LeaderPlaneAcceptBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            LeaderPlaneBackBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            LeaderPlaneCalcBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        LeaderWorkRibbonPageGroup.Visible = ( _
            LeaderWorkAcceptBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
            LeaderWorkBackBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)

    End Sub

#End Region

    ''' <summary>
    ''' Отображать список объектов экспертизы в виде дерева
    ''' </summary>
    Friend GoodAsTree As Boolean = True

    ''' <summary>
    ''' Отображать проект заключения № 1
    ''' </summary>
    Friend Project1Show As Boolean = True


    ''' <summary>
    ''' Таблица содержания работы
    ''' </summary>
    Private ContentTable As ContentDataTable = Nothing

    ''' <summary>
    ''' Таблица сообщений об ошибках
    ''' </summary>
    Private ErrorTable As ErrorDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.WorkUserControl
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <param name="CurrentUser">Текущий пользователь системы</param> 
    Public Sub New(Work As WorkConnectionRow, CurrentUser As Cprp.DxData.User.DatabaseUser)
        '
        ' Me
        '
        MyBase.New(Work, CurrentUser)
        InitializeComponent()
        If Not MyBase.WorkDataExist Then
            Me.Enabled = False
            Exit Sub
        End If
        '
        ' Work
        '
        MyClass.Work = Work
        '
        ' ContentTable, ContentTreeList
        '
        ContentTable = New ContentDataTable(Work)
        ContentTreeList.DataSource = ContentTable
        '
        ' ErrorTable, ErrorGridControl, ErrorGridView
        '
        ErrorTable = New ErrorDataTable(Work)
        ErrorGridControl.DataSource = ErrorTable
        ErrorGridView.SortInfo.Insert(0, IdCheckGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Dictionary
        '
        If Cprp.DxDictionary.Common.OpenOfficeDictionary Is Nothing OrElse Cprp.DxDictionary.Common.CustomDictionary Is Nothing Then
            SpellChecker1.Dispose()
        Else
            SpellChecker1.Dictionaries.Add(Cprp.DxDictionary.Common.OpenOfficeDictionary)
            SpellChecker1.Dictionaries.Add(Cprp.DxDictionary.Common.CustomDictionary)
        End If
        '
        ' Перечитать состояния кнопок главного меню
        '
        RibbonUpdate()
        '
        ' Открыть содержание работы
        '
        ContentOpen(ContentEnum.Content, C2.EMPTY_ID)
        '
        ' Запись в историю работы события открытия карточки работы
        '
        Work.WriteHistory(Cprp.DxData.Work.WorkEvent.OpenCard, Nothing)
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.WorkUserControl
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="CurrentUser">Текущий пользователь системы</param> 
    Public Sub New(id As Object, Connection As SqlConnection, CurrentUser As Cprp.DxData.User.DatabaseUser)
        MyClass.New(New WorkConnectionRow(id, Connection), CurrentUser)
    End Sub

    ''' <summary>
    ''' Открыть раздел содержания работы
    ''' </summary>
    ''' <param name="contentId">Идентификатор раздела</param>
    ''' <param name="objectId">Идентификатор объекта в списке объектов раздела</param> 
    Friend Sub ContentOpen(contentId As ContentEnum, objectId As Integer)
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        '
        ' Сохранение данных текущего элемента управления
        '
        If MainPanelControl.Controls.Count > 0 AndAlso TypeOf MainPanelControl.Controls(0) Is ChildUserControl Then
            CType(MainPanelControl.Controls(0), ChildUserControl).DataWrite()
        End If
        '
        ' Уточнение раздела содержания работы
        '
        Select Case contentId

            Case ContentEnum.GoodData, ContentEnum.GoodLaw, ContentEnum.GoodSummary
                ' Если нет активного объекта экспертизы -> Список объектов экспертизы
                If Work.GoodTable.Rows.Find(objectId) Is Nothing Then contentId = ContentEnum.GoodList

        End Select
        '
        ' Определение нового элемента управления
        '
        Dim NewControl As ChildUserControl = Nothing
        Select Case contentId
            Case ContentEnum.Plane                          ' План работы
                NewControl = PlaneControl
            Case ContentEnum.SupplyRusData                  ' Регистрационные данные российского участника операции
                NewControl = MemberDataControl
            Case ContentEnum.GoodList                       ' Список продукции (объектов экспертизы)
                If Me.GoodAsTree Then
                    NewControl = GoodTreeControl
                    GoodTreeControl.GoodId = objectId
                Else
                    NewControl = GoodListControl
                    GoodListControl.GoodId = objectId
                End If
            Case ContentEnum.GoodData                       ' Регистрационные данные объекта экспертизы
                NewControl = GoodDataControl
                GoodDataControl.GoodId = objectId
            Case ContentEnum.GoodLaw                        ' Классификатор ПВН объекта экспертизы
                NewControl = GoodLawControl
                GoodLawControl.GoodId = objectId
            Case ContentEnum.GoodSummary                    ' Анализ объекта экспертизы
                NewControl = GoodSummaryControl
                GoodSummaryControl.GoodId = objectId
            Case ContentEnum.Summary                        ' Решение по анализу
                NewControl = summaryControl
            Case ContentEnum.ExtraDoc                       ' Перечень документов
                NewControl = ExtraDocControl
            Case ContentEnum.Project                        ' Проект заключения
                NewControl = ProjectControl
            Case ContentEnum.Request
                NewControl = RequestControl                 ' Запросы
            Case Else
                NewControl = ContentControl                 ' Содержание работы
                contentId = ContentEnum.Content
        End Select
        '
        ' Активация нового элемента управления
        '
        NewControl.DataRead()
        MainPanelControl.Controls.SetChildIndex(NewControl, 0)
        '
        ' Перечитать меню содержания работы
        '
        ContentTreeList.LockReloadNodes()
        ContentTable.DataReload()
        ContentTreeList.UnlockReloadNodes()
        ContentTreeList.ExpandAll()
        '
        ' Проверка работы на наличие ошибок
        '
        If ExpertPlaneCheckBarButtonItem.Down OrElse ExpertWorkCheckBarButtonItem.Down Then ErrorTable.CheckWork()
        '
        ' Кнопки главного меню
        '
        MainWindowsUIButtonPanel.Buttons("СОДЕРЖАНИЕ").Properties.Checked = (contentId = ContentEnum.Content)
        MainWindowsUIButtonPanel.Buttons("ПРОЕКТ #1").Properties.Checked = (contentId = ContentEnum.Project AndAlso MyClass.Project1Show)
        MainWindowsUIButtonPanel.Buttons("ПРОЕКТ #2").Properties.Checked = (contentId = ContentEnum.Project AndAlso Not MyClass.Project1Show)
        MainWindowsUIButtonPanel.Buttons("Запросы").Properties.Checked = (contentId = ContentEnum.Request)
        Dim bTmp As Boolean = _
            Work.Condition <> WorkCondition.IsNew AndAlso _
            Work.Condition <> WorkCondition.IsPlaneWork AndAlso _
            Work.Condition <> WorkCondition.IsPlaneAgree
        MainWindowsUIButtonPanel.Buttons("ПРОЕКТ #1").Properties.Visible = bTmp
        'MainWindowsUIButtonPanel.Buttons("ПРОЕКТ #2").Properties.Visible = bTmp
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Открыть раздел работы из Главного меню
    Private Sub MainWindowsUIButtonPanel_ButtonChecked(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles MainWindowsUIButtonPanel.ButtonChecked
        Select Case e.Button.Properties.Caption
            Case "ПРОЕКТ #1"
                MyClass.Project1Show = True
                ContentOpen(ContentEnum.Project, C2.EMPTY_ID)
            Case "ПРОЕКТ #2"
                MyClass.Project1Show = False
                ContentOpen(ContentEnum.Project, C2.EMPTY_ID)
            Case "Запросы"
                ContentOpen(ContentEnum.Request, C2.EMPTY_ID)
            Case Else
                ContentOpen(ContentEnum.Content, C2.EMPTY_ID)
        End Select
    End Sub

    ' Открыть раздел работы из дерева Содержания
    Private Sub RepositoryItemHyperLinkEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit2.Click
        Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = ContentTreeList.FocusedNode
        If Not Node Is Nothing Then ContentOpen(Node.GetValue("contentId"), Node.GetValue("objectId"))
    End Sub

    ' Открыть раздел работы из списка Результатов проверки
    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        Dim Row As DataRow = ErrorGridView.GetFocusedDataRow
        If Not Row Is Nothing Then ContentOpen(Row("contentId"), Row("objectId"))
    End Sub

    Private Sub ErrorGridView_RowCountChanged(sender As Object, e As EventArgs) Handles ErrorGridView.RowCountChanged
        ErrorDockPanel.Text = String.Format("Результаты проверки ({0})", ErrorTable.Rows.Count)
    End Sub

End Class
