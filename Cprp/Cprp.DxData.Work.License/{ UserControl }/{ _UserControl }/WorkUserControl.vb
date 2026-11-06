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
    Friend WithEvents ExpertProjectCreateBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents ExpertDataRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents ExpertProjectRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents WorkHistoryRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents WorkHistoryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
    Friend WithEvents MainWindowsUIButtonPanel As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Me.MainWindowsUIButtonPanel = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
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
        Me.ExpertProjectCreateBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkHistoryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.ExpertDataRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ExpertProjectRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.WorkHistoryRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
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
        Me.MainWindowsUIButtonPanel.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("СОДЕРЖАНИЕ", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip1, True, True, True, Nothing, Nothing, 1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUISeparator(), New DevExpress.XtraBars.Docking2010.WindowsUIButton("ЗАЯВЛЕНИЕ", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons1"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip2, True, False, True, Nothing, Nothing, 1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("ПРОЕКТ #2", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons2"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip3, True, False, False, Nothing, Nothing, 1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUISeparator(), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Запросы", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons3"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, -1)})
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
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 41)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(1142, 205)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'ErrorGridControl
        '
        Me.ErrorGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErrorGridControl.Location = New System.Drawing.Point(0, 1)
        Me.ErrorGridControl.MainView = Me.ErrorGridView
        Me.ErrorGridControl.Name = "ErrorGridControl"
        Me.ErrorGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1})
        Me.ErrorGridControl.Size = New System.Drawing.Size(1142, 204)
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
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.ExpertDataSaveBarButtonItem, Me.ExpertDataReloadBarButtonItem, Me.ExpertProjectCreateBarButtonItem, Me.WorkHistoryBarButtonItem})
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
        'ExpertProjectCreateBarButtonItem
        '
        Me.ExpertProjectCreateBarButtonItem.Caption = "СОЗДАТЬ"
        Me.ExpertProjectCreateBarButtonItem.Id = 6
        Me.ExpertProjectCreateBarButtonItem.LargeGlyph = CType(resources.GetObject("ExpertProjectCreateBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExpertProjectCreateBarButtonItem.Name = "ExpertProjectCreateBarButtonItem"
        ToolTipTitleItem6.Text = "Создать"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Создать проект заявления на оформление лицензии"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.ExpertProjectCreateBarButtonItem.SuperTip = SuperToolTip6
        '
        'WorkHistoryBarButtonItem
        '
        Me.WorkHistoryBarButtonItem.Caption = "ИСТОРИЯ"
        Me.WorkHistoryBarButtonItem.Id = 17
        Me.WorkHistoryBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkHistoryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkHistoryBarButtonItem.Name = "WorkHistoryBarButtonItem"
        ToolTipTitleItem7.Text = "История"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Показать историю работы"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.WorkHistoryBarButtonItem.SuperTip = SuperToolTip7
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ExpertDataRibbonPageGroup, Me.ExpertProjectRibbonPageGroup, Me.WorkHistoryRibbonPageGroup})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Главное меню"
        '
        'ExpertDataRibbonPageGroup
        '
        Me.ExpertDataRibbonPageGroup.ItemLinks.Add(Me.ExpertDataSaveBarButtonItem)
        Me.ExpertDataRibbonPageGroup.ItemLinks.Add(Me.ExpertDataReloadBarButtonItem)
        Me.ExpertDataRibbonPageGroup.Name = "ExpertDataRibbonPageGroup"
        Me.ExpertDataRibbonPageGroup.ShowCaptionButton = False
        Me.ExpertDataRibbonPageGroup.Text = "Данные"
        '
        'ExpertProjectRibbonPageGroup
        '
        Me.ExpertProjectRibbonPageGroup.ItemLinks.Add(Me.ExpertProjectCreateBarButtonItem)
        Me.ExpertProjectRibbonPageGroup.Name = "ExpertProjectRibbonPageGroup"
        Me.ExpertProjectRibbonPageGroup.ShowCaptionButton = False
        Me.ExpertProjectRibbonPageGroup.Text = "Заявление"
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
        Me.SpellChecker1.ParentContainer = Me.MainPanelControl
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

    Private _LicenseDataControl As LicenseDataChildControl = Nothing
    ''' <summary>
    ''' Данные работы
    ''' </summary>
    Private ReadOnly Property LicenseDataControl As LicenseDataChildControl
        Get
            If _LicenseDataControl Is Nothing Then
                _LicenseDataControl = New LicenseDataChildControl(Me) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            End If
            Return _LicenseDataControl
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
    ''' Проект заявления
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
            ' Изменение состояния работы
            '
            Dim iTmp As Integer = C2.ToInt(Me.Work("licConditionId"))
            Select Case iTmp
                Case -1, 1, 2, 3, 4
                    Me.Work("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsWork)
                Case 5
                    Cprp.DxCommon.WaitForm.Close()
                    If Cprp.DxCommon.Messages.ShowQuestion("Работа переведена в состояние ""Исполнена"" и будет закрыта. Продолжить?") <> DialogResult.Yes Then Exit Sub
                    Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
                    Me.Work("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsClose)
            End Select
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
            '
            ' Закрыть элемент управления если работа закрыта
            '
            If Me.Work.Condition = WorkCondition.IsClose AndAlso Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
                Me.Work.MessageWorkChangeEo()
                CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(Me.Work.Id)
            End If
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
    ''' Эксперт - Создать проекты итоговых документов
    ''' </summary>
    Private Sub ExpertProjectCreateBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertProjectCreateBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Создать новый проект заявления?") <> DialogResult.Yes Then Exit Sub
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
            ' Переход к проекту заявления
            '
            ContentOpen(ContentEnum.Project, Nothing)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' Эксперт - Проверить работу на наличие ошибок
    ' ''' </summary>
    'Private Sub ExpertWorkCheckBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
    '    If Not ExpertWorkCheckBarButtonItem.Down Then
    '        Me.ErrorTable.Rows.Clear()
    '        Exit Sub
    '    End If
    '    Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
    '    Try
    '        '
    '        ' Сохранение данных текущего элемента управления
    '        '
    '        MyClass.CloseEditor()
    '        '
    '        ' Проверка работы
    '        '
    '        Dim bTmp As Boolean = Me.ErrorTable.CheckWork()
    '        Cprp.DxCommon.WaitForm.Close()
    '        If bTmp Then
    '            Cprp.DxCommon.Messages.ShowInformation("Ошибок нет.", "Проверка")
    '        Else
    '            Cprp.DxCommon.Messages.ShowError("В работе обнаружены ошибки.", "Проверка")
    '            ErrorDockPanel.Show()
    '        End If
    '    Catch ex As Exception
    '        Cprp.DxCommon.WaitForm.Close()
    '        Cprp.DxCommon.Messages.ShowError(ex.Message)
    '    End Try
    'End Sub


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
        ''
        '' Переменные
        ''
        'Dim bExpertWork As Boolean = MyBase.WorkEditableForExpert       ' Работа доступна текущему эксперту для редактирования
        'Dim bExpertPlane As Boolean = MyBase.PlaneEditableForExpert     ' План работы доступен текущему эксперту для редактирования
        'Dim bLeaderWork As Boolean = MyBase.WorkEditableForLeader       ' Работа доступна текущему руководителю для редактирования
        'Dim bLeaderPlane As Boolean = MyBase.PlaneEditableForLeader     ' План работы доступен текущему руководителю для редактирования
        ''
        '' Эксперт - Сохранить данные в базу
        ''
        'ExpertDataSaveBarButtonItem.Visibility = If((bExpertWork OrElse bExpertPlane), _
        '                                            DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Перечитать данные из базы
        ''
        'ExpertDataReloadBarButtonItem.Visibility = If(MyBase.CurrentUser.IsExpert, _
        '                                              DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Загрузить данные из другой работы 
        ''
        'ExpertDataImportBarButtonItem.Visibility = If(bExpertWork, _
        '                                              DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Проверить план работы на наличие ошибок 
        ''
        'ExpertPlaneCheckBarButtonItem.Visibility = If(bExpertPlane, _
        '                                              DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Отправить план работы на утверждение руководителю экспертизы
        ''
        'ExpertPlaneSendBarButtonItem.Visibility = If(bExpertPlane, _
        '                                             DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Создать проекты итоговых документов
        ''
        'ExpertProjectCreateBarButtonItem.Visibility = If(bExpertWork, _
        '                                                 DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Включить работу в мой план работ
        ''
        'ExpertWorkToPlaneBarButtonItem.Visibility = If((MyBase.WorkDataExist AndAlso MyBase.Work.Condition = WorkCondition.IsNew), _
        '                                               DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Проверить работу на наличие ошибок 
        ''
        'ExpertWorkCheckBarButtonItem.Visibility = If(bExpertWork, _
        '                                             DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - Отправить работу на утверждение руководителю экспертизы
        ''
        'ExpertWorkSendBarButtonItem.Visibility = If(bExpertWork, _
        '                                            DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - вернуть работу на доработку
        ''
        'ExpertWorkBackBarButtonItem.Visibility = If((MyBase.CurrentUserIsWorkExpert AndAlso (MyBase.Work.Condition = WorkCondition.IsCheck OrElse MyBase.Work.Condition = WorkCondition.IsAgree)), _
        '                                            DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Эксперт - подписать итоговые документы по работе
        ''
        'ExpertWorkSignBarButtonItem.Visibility = If((MyBase.CurrentUserIsWorkExpert AndAlso MyBase.Work.Condition = WorkCondition.IsSignature), _
        '                                            DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Руководитель - Перечитать данные из базы
        ''
        'LeaderDataReloadBarButtonItem.Visibility = If(MyBase.CurrentUser.IsLeader, _
        '                                              DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Руководитель - Утвердить план работы
        ''
        'LeaderPlaneAcceptBarButtonItem.Visibility = If(bLeaderPlane, _
        '                                               DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Руководитель - Вернуть план работы на доработку
        ''
        'LeaderPlaneBackBarButtonItem.Visibility = If(bLeaderPlane, _
        '                                             DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Руководитель - Рассчитать стоимость работы
        ''
        'LeaderPlaneCalcBarButtonItem.Visibility = If(bLeaderPlane, _
        '                                              DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Руководитель - Утвердить работу
        ''
        'LeaderWorkAcceptBarButtonItem.Visibility = If(bLeaderWork, _
        '                                               DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Руководитель - Вернуть работу на доработку
        ''
        'LeaderWorkBackBarButtonItem.Visibility = If(bLeaderWork, _
        '                                             DevExpress.XtraBars.BarItemVisibility.Always, DevExpress.XtraBars.BarItemVisibility.Never)
        ''
        '' Группы кнопок
        ''
        'ExpertDataRibbonPageGroup.Visible = ( _
        '    ExpertDataSaveBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '    ExpertDataReloadBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '    ExpertDataImportBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        'ExpertPlaneRibbonPageGroup.Visible = ( _
        '    ExpertPlaneCheckBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '    ExpertPlaneSendBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        'ExpertProjectRibbonPageGroup.Visible = ( _
        '    ExpertProjectCreateBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        'ExpertWorkRibbonPageGroup.Visible = ( _
        '   ExpertWorkToPlaneBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '   ExpertWorkCheckBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '   ExpertWorkSendBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '   ExpertWorkBackBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '   ExpertWorkSignBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        'LeaderDataRibbonPageGroup.Visible = ( _
        '    LeaderDataReloadBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        'LeaderPlaneRibbonPageGroup.Visible = ( _
        '    LeaderPlaneAcceptBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '    LeaderPlaneBackBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '    LeaderPlaneCalcBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)
        'LeaderWorkRibbonPageGroup.Visible = ( _
        '    LeaderWorkAcceptBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always OrElse _
        '    LeaderWorkBackBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always)

    End Sub

#End Region


    ''' <summary>
    ''' Таблица содержания работы
    ''' </summary>
    Private ContentTable As ContentDataTable = Nothing

    ' ''' <summary>
    ' ''' Таблица сообщений об ошибках
    ' ''' </summary>
    'Private ErrorTable As ErrorDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.License.WorkUserControl
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
        ''
        '' ErrorTable, ErrorGridControl, ErrorGridView
        ''
        'ErrorTable = New ErrorDataTable(Work)
        'ErrorGridControl.DataSource = ErrorTable
        'ErrorGridView.SortInfo.Insert(0, IdCheckGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
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
        ' Определение нового элемента управления
        '
        Dim NewControl As ChildUserControl = Nothing
        Select Case contentId
            Case ContentEnum.LicenseData                    ' Данные работы
                NewControl = LicenseDataControl
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
        ''
        '' Проверка работы на наличие ошибок
        ''
        'If ExpertPlaneCheckBarButtonItem.Down OrElse ExpertWorkCheckBarButtonItem.Down Then ErrorTable.CheckWork()
        '
        ' Кнопки главного меню
        '
        MainWindowsUIButtonPanel.Buttons("СОДЕРЖАНИЕ").Properties.Checked = (contentId = ContentEnum.Content)
        MainWindowsUIButtonPanel.Buttons("ЗАЯВЛЕНИЕ").Properties.Checked = (contentId = ContentEnum.Project)
        MainWindowsUIButtonPanel.Buttons("Запросы").Properties.Checked = (contentId = ContentEnum.Request)
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Открыть раздел работы из Главного меню
    Private Sub MainWindowsUIButtonPanel_ButtonChecked(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles MainWindowsUIButtonPanel.ButtonChecked
        Select Case e.Button.Properties.Caption
            Case "ЗАЯВЛЕНИЕ"
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

    'Private Sub ErrorGridView_RowCountChanged(sender As Object, e As EventArgs) Handles ErrorGridView.RowCountChanged
    '    ErrorDockPanel.Text = String.Format("Результаты проверки ({0})", ErrorTable.Rows.Count)
    'End Sub

End Class
