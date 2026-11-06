Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Список лиц"
''' </summary>
Friend Class MemberListChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents FromSupplyBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FromContractBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ListClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MemberDelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MemberAddBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MemberOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ListGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ListGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RowNumListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameLongListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsCheckDataListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsCheckEmbargoListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsCheckControlListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsCheckProfileListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsCheckRiskListGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemberListChildControl))
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.MemberOpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MemberAddBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MemberDelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ListClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FromContractBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FromSupplyBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RowNumListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NameLongListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsCheckDataListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsCheckEmbargoListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsCheckControlListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsCheckProfileListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsCheckRiskListGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.MemberOpenBarButtonItem, Me.MemberAddBarButtonItem, Me.MemberDelBarButtonItem, Me.ListClearBarButtonItem, Me.FromContractBarButtonItem, Me.FromSupplyBarButtonItem})
        Me.BarManager1.MaxItemId = 7
        '
        'Bar1
        '
        Me.Bar1.BarName = "Список участников"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(70, 160)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.MemberOpenBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.MemberAddBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.MemberDelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ListClearBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FromContractBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FromSupplyBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Список участников"
        '
        'MemberOpenBarButtonItem
        '
        Me.MemberOpenBarButtonItem.Caption = "Объект"
        Me.MemberOpenBarButtonItem.Glyph = CType(resources.GetObject("MemberOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.MemberOpenBarButtonItem.Id = 0
        Me.MemberOpenBarButtonItem.Name = "MemberOpenBarButtonItem"
        ToolTipTitleItem1.Text = "Объект"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к регистрационным данным объекта"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.MemberOpenBarButtonItem.SuperTip = SuperToolTip1
        '
        'MemberAddBarButtonItem
        '
        Me.MemberAddBarButtonItem.Caption = "Добавить"
        Me.MemberAddBarButtonItem.Glyph = CType(resources.GetObject("MemberAddBarButtonItem.Glyph"), System.Drawing.Image)
        Me.MemberAddBarButtonItem.Id = 1
        Me.MemberAddBarButtonItem.Name = "MemberAddBarButtonItem"
        ToolTipTitleItem2.Text = "Добавить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Добавить новый объект"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.MemberAddBarButtonItem.SuperTip = SuperToolTip2
        '
        'MemberDelBarButtonItem
        '
        Me.MemberDelBarButtonItem.Caption = "Удалить"
        Me.MemberDelBarButtonItem.Glyph = CType(resources.GetObject("MemberDelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.MemberDelBarButtonItem.Id = 2
        Me.MemberDelBarButtonItem.Name = "MemberDelBarButtonItem"
        ToolTipTitleItem3.Text = "Удалить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Удалить объект"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.MemberDelBarButtonItem.SuperTip = SuperToolTip3
        '
        'ListClearBarButtonItem
        '
        Me.ListClearBarButtonItem.Caption = "Удалить все"
        Me.ListClearBarButtonItem.Glyph = CType(resources.GetObject("ListClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ListClearBarButtonItem.Id = 3
        Me.ListClearBarButtonItem.Name = "ListClearBarButtonItem"
        ToolTipTitleItem4.Text = "Удалить все"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Удалить все объекты"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.ListClearBarButtonItem.SuperTip = SuperToolTip4
        '
        'FromContractBarButtonItem
        '
        Me.FromContractBarButtonItem.Caption = "Из сделки"
        Me.FromContractBarButtonItem.Glyph = CType(resources.GetObject("FromContractBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FromContractBarButtonItem.Id = 4
        Me.FromContractBarButtonItem.Name = "FromContractBarButtonItem"
        ToolTipTitleItem5.Text = "Из сделки"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Загрузить объекты из  внешнеэкономической сделки"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.FromContractBarButtonItem.SuperTip = SuperToolTip5
        '
        'FromSupplyBarButtonItem
        '
        Me.FromSupplyBarButtonItem.Caption = "Из операции"
        Me.FromSupplyBarButtonItem.Glyph = CType(resources.GetObject("FromSupplyBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FromSupplyBarButtonItem.Id = 5
        Me.FromSupplyBarButtonItem.Name = "FromSupplyBarButtonItem"
        ToolTipTitleItem6.Text = "Из операции"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Загрузить объекты из внешнеэкономической операции"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.FromSupplyBarButtonItem.SuperTip = SuperToolTip6
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 650)
        Me.barDockControlBottom.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 650)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 650)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.ListGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ListGridControl
        '
        Me.ListGridControl.Location = New System.Drawing.Point(12, 93)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.Size = New System.Drawing.Size(926, 555)
        Me.ListGridControl.TabIndex = 4
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.GroupRow.Options.UseFont = True
        Me.ListGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ListGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RowNumListGridColumn, Me.NameLongListGridColumn, Me.IsCheckDataListGridColumn, Me.IsCheckEmbargoListGridColumn, Me.IsCheckControlListGridColumn, Me.IsCheckProfileListGridColumn, Me.IsCheckRiskListGridColumn})
        Me.ListGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.ListGridView.GridControl = Me.ListGridControl
        Me.ListGridView.GroupRowHeight = 25
        Me.ListGridView.Name = "ListGridView"
        Me.ListGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ListGridView.OptionsCustomization.AllowFilter = False
        Me.ListGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ListGridView.OptionsDetail.EnableMasterViewMode = False
        Me.ListGridView.OptionsMenu.EnableColumnMenu = False
        Me.ListGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ListGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsView.ShowGroupPanel = False
        Me.ListGridView.RowHeight = 30
        '
        'RowNumListGridColumn
        '
        Me.RowNumListGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowNumListGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowNumListGridColumn.Caption = "№№"
        Me.RowNumListGridColumn.Name = "RowNumListGridColumn"
        Me.RowNumListGridColumn.OptionsColumn.FixedWidth = True
        Me.RowNumListGridColumn.Visible = True
        Me.RowNumListGridColumn.VisibleIndex = 0
        Me.RowNumListGridColumn.Width = 60
        '
        'NameLongListGridColumn
        '
        Me.NameLongListGridColumn.Caption = "Полное наименование"
        Me.NameLongListGridColumn.FieldName = "nameLong"
        Me.NameLongListGridColumn.Name = "NameLongListGridColumn"
        Me.NameLongListGridColumn.OptionsColumn.AllowEdit = False
        Me.NameLongListGridColumn.Visible = True
        Me.NameLongListGridColumn.VisibleIndex = 1
        Me.NameLongListGridColumn.Width = 450
        '
        'IsCheckDataListGridColumn
        '
        Me.IsCheckDataListGridColumn.Caption = "Данные"
        Me.IsCheckDataListGridColumn.FieldName = "isCheckData"
        Me.IsCheckDataListGridColumn.Name = "IsCheckDataListGridColumn"
        Me.IsCheckDataListGridColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckDataListGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckDataListGridColumn.Visible = True
        Me.IsCheckDataListGridColumn.VisibleIndex = 2
        Me.IsCheckDataListGridColumn.Width = 80
        '
        'IsCheckEmbargoListGridColumn
        '
        Me.IsCheckEmbargoListGridColumn.Caption = "Запреты"
        Me.IsCheckEmbargoListGridColumn.FieldName = "isCheckEmbargo"
        Me.IsCheckEmbargoListGridColumn.Name = "IsCheckEmbargoListGridColumn"
        Me.IsCheckEmbargoListGridColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckEmbargoListGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckEmbargoListGridColumn.Visible = True
        Me.IsCheckEmbargoListGridColumn.VisibleIndex = 3
        Me.IsCheckEmbargoListGridColumn.Width = 80
        '
        'IsCheckControlListGridColumn
        '
        Me.IsCheckControlListGridColumn.Caption = "На контроле"
        Me.IsCheckControlListGridColumn.FieldName = "isCheckControl"
        Me.IsCheckControlListGridColumn.Name = "IsCheckControlListGridColumn"
        Me.IsCheckControlListGridColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckControlListGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckControlListGridColumn.Visible = True
        Me.IsCheckControlListGridColumn.VisibleIndex = 4
        Me.IsCheckControlListGridColumn.Width = 80
        '
        'IsCheckProfileListGridColumn
        '
        Me.IsCheckProfileListGridColumn.Caption = "Профиль"
        Me.IsCheckProfileListGridColumn.FieldName = "isCheckProfile"
        Me.IsCheckProfileListGridColumn.Name = "IsCheckProfileListGridColumn"
        Me.IsCheckProfileListGridColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckProfileListGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckProfileListGridColumn.Visible = True
        Me.IsCheckProfileListGridColumn.VisibleIndex = 5
        Me.IsCheckProfileListGridColumn.Width = 80
        '
        'IsCheckRiskListGridColumn
        '
        Me.IsCheckRiskListGridColumn.Caption = "Риски"
        Me.IsCheckRiskListGridColumn.Name = "IsCheckRiskListGridColumn"
        Me.IsCheckRiskListGridColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckRiskListGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckRiskListGridColumn.Visible = True
        Me.IsCheckRiskListGridColumn.VisibleIndex = 6
        Me.IsCheckRiskListGridColumn.Width = 80
        '
        'RootLayoutControlGroup
        '
        Me.RootLayoutControlGroup.AppearanceGroup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RootLayoutControlGroup.AppearanceGroup.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceItemCaption.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceItemCaption.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = True
        Me.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.RootLayoutControlGroup.GroupBordersVisible = False
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseTextOptions = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 40)
        Me.CaptionSimpleLabelItem.Text = "Список"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ListGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 559)
        Me.LayoutControlItem1.Text = "Список участников"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'MemberListChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MemberListChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Элементы управления
        '
        Select Case MyBase.Content
            Case ContentEnum.ContractRusList
                CaptionSimpleLabelItem.Text = "Внешнеэкономическая сделка > Российские участники"
            Case ContentEnum.ContractNusList
                CaptionSimpleLabelItem.Text = "Внешнеэкономическая сделка > Иностранные участники"
            Case ContentEnum.SupplyRusList
                CaptionSimpleLabelItem.Text = "Внешнеэкономическая операция > Российские участники"
            Case ContentEnum.SupplyNusList
                CaptionSimpleLabelItem.Text = "Внешнеэкономическая операция > Иностранные покупатели (продавцы)"
            Case ContentEnum.SupplyEndList
                CaptionSimpleLabelItem.Text = "Внешнеэкономическая операция > Потребители (конечные пользователи)"
        End Select
        '
        ' Установка фокуса в списке на активном объекте
        '
        Dim iTmp = 0
        ListGridView.MoveFirst()
        While ListGridView.IsValidRowHandle(iTmp)
            If CInt(ListGridView.GetDataRow(iTmp)("id")) = MyClass.MemberId Then
                ListGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования        
        MemberAddBarButtonItem.Enabled = Not bLock
        MemberDelBarButtonItem.Enabled = Not bLock
        ListClearBarButtonItem.Enabled = Not bLock
        FromContractBarButtonItem.Enabled = Not bLock
        FromSupplyBarButtonItem.Enabled = Not bLock
        ListGridView.OptionsBehavior.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        P.Work.MemberTable.AcceptChanges()
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property MemberId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    ''' <param name="memberKind">Вид лица</param> 
    Public Sub New(ParentControl As WorkUserControl, memberKind As Cprp.DxData.Member.MemberKind)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        Select Case memberKind
            Case Cprp.DxData.Member.MemberKind.IsContractRus
                MyBase.Content = ContentEnum.ContractRusList
                RowNumListGridColumn.FieldName = "conRusNum"
                IsCheckRiskListGridColumn.FieldName = "isCheckConRusRisk"
                ListGridControl.DataSource = P.Work.MemberTable.ConRusView
                IsCheckEmbargoListGridColumn.Visible = False
                IsCheckControlListGridColumn.Visible = False
                FromContractBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case Cprp.DxData.Member.MemberKind.IsContractNus
                MyBase.Content = ContentEnum.ContractNusList
                RowNumListGridColumn.FieldName = "conNusNum"
                IsCheckRiskListGridColumn.FieldName = "isCheckConNusRisk"
                ListGridControl.DataSource = P.Work.MemberTable.ConNusView
                FromContractBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case Cprp.DxData.Member.MemberKind.IsSupplyRus
                MyBase.Content = ContentEnum.SupplyRusList
                RowNumListGridColumn.FieldName = "supRusNum"
                IsCheckRiskListGridColumn.FieldName = "isCheckSupRusRisk"
                ListGridControl.DataSource = P.Work.MemberTable.SupRusView
                IsCheckEmbargoListGridColumn.Visible = False
                IsCheckControlListGridColumn.Visible = False
                FromSupplyBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case Cprp.DxData.Member.MemberKind.IsSupplyNus
                MyBase.Content = ContentEnum.SupplyNusList
                RowNumListGridColumn.FieldName = "supNusNum"
                IsCheckRiskListGridColumn.FieldName = "isCheckSupNusRisk"
                ListGridControl.DataSource = P.Work.MemberTable.SupNusView
                FromSupplyBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Case Cprp.DxData.Member.MemberKind.IsSupplyEnd
                MyBase.Content = ContentEnum.SupplyEndList
                RowNumListGridColumn.FieldName = "supEndNum"
                IsCheckRiskListGridColumn.FieldName = "isCheckSupEndRisk"
                ListGridControl.DataSource = P.Work.MemberTable.SupEndView
        End Select
        ListGridView.SortInfo.Insert(0, RowNumListGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        ListGridControl.Focus()
    End Sub

    Private Sub ListGridView_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles ListGridView.CustomDrawCell
        If C2.IsText(e.CellValue) Then Exit Sub
        Select Case e.Column.FieldName
            Case RowNumListGridColumn.FieldName, "nameLong"
                e.DisplayText = "[обязательное поле]"
                e.Appearance.ForeColor = Drawing.SystemColors.InactiveCaptionText
        End Select
    End Sub

    Private Sub ListGridView_RowCountChanged(sender As Object, e As EventArgs) Handles ListGridView.RowCountChanged
        MemberOpenBarButtonItem.Enabled = (ListGridView.RowCount > 0)
    End Sub

    ' Перейти к регистрационным данным объекта
    Private Sub MemberOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        MyClass.MemberId = CInt(ListGridView.GetFocusedDataRow("id"))
        Select Case MyBase.Content
            Case ContentEnum.ContractRusList : P.ContentOpen(ContentEnum.ContractRusData, MyClass.MemberId)
            Case ContentEnum.ContractNusList : P.ContentOpen(ContentEnum.ContractNusData, MyClass.MemberId)
            Case ContentEnum.SupplyRusList : P.ContentOpen(ContentEnum.SupplyRusData, MyClass.MemberId)
            Case ContentEnum.SupplyNusList : P.ContentOpen(ContentEnum.SupplyNusData, MyClass.MemberId)
            Case ContentEnum.SupplyEndList : P.ContentOpen(ContentEnum.SupplyEndData, MyClass.MemberId)
        End Select
    End Sub

    Private Sub ListGridView_DoubleClick(sender As Object, e As EventArgs) Handles ListGridView.DoubleClick
        MemberOpenBarButtonItem.PerformClick()
    End Sub

    ' Добавить новый объект
    Private Sub MemberAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberAddBarButtonItem.ItemClick
        '
        ' Определение вида лица
        '
        Dim memberKind As Cprp.DxData.Member.MemberKind = Cprp.DxData.Member.MemberKind.IsEmpty
        Select Case MyBase.Content
            Case ContentEnum.ContractRusList : memberKind = Member.MemberKind.IsContractRus
            Case ContentEnum.ContractNusList : memberKind = Member.MemberKind.IsContractNus
            Case ContentEnum.SupplyRusList : memberKind = Member.MemberKind.IsSupplyRus
            Case ContentEnum.SupplyNusList : memberKind = Member.MemberKind.IsSupplyNus
            Case ContentEnum.SupplyEndList : memberKind = Member.MemberKind.IsSupplyEnd
        End Select
        '
        ' Добавление нового объекта в таблицу лиц работы
        '
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        ListGridView.BeginDataUpdate()
        Dim Row As DataRow = P.Work.MemberTable.AddNew(memberKind)
        ListGridView.EndDataUpdate()
        '
        ' Установка фокуса в списке на новом объекте
        '
        Dim iTmp = 0
        ListGridView.MoveFirst()
        While ListGridView.IsValidRowHandle(iTmp)
            If CInt(ListGridView.GetDataRow(iTmp)("id")) = CInt(Row("id")) Then
                ListGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
        MyBase.SetChangeDateNow()
        '
        ' Переход к регистрационным данным нового объекта
        '
        MemberOpenBarButtonItem.PerformClick()
    End Sub

    ' Удалить объект
    Private Sub MemberDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberDelBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Удалить объект № {0}?", C2.ToInt(ListGridView.GetFocusedDataRow(RowNumListGridColumn.FieldName)))) <> DialogResult.Yes Then Exit Sub
        ListGridView.GetFocusedDataRow(RowNumListGridColumn.FieldName) = 0
        ListGridView.RefreshData()
        ListGridControl.Focus()
        MyBase.SetChangeDateNow()
    End Sub

    ' Удалить все объекты
    Private Sub ListClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListClearBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить все объекты?") <> DialogResult.Yes Then Exit Sub
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        For Each Row As DataRow In P.Work.MemberTable.Rows
            Row(RowNumListGridColumn.FieldName) = 0
        Next
        ListGridView.RefreshData()
        ListGridControl.Focus()
        MyBase.SetChangeDateNow()
    End Sub

    ' Загрузить объекты из сделки
    Private Sub FromContractBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FromContractBarButtonItem.ItemClick
        Dim V As DataView = Nothing
        '
        ' Определение вида лица и обновляемого представления
        '
        Dim memberKind As Cprp.DxData.Member.MemberKind = Cprp.DxData.Member.MemberKind.IsEmpty
        Select Case MyBase.Content
            Case ContentEnum.SupplyRusList
                memberKind = Member.MemberKind.IsSupplyRus
                V = P.Work.MemberTable.ConRusView
            Case ContentEnum.SupplyNusList
                memberKind = Member.MemberKind.IsSupplyNus
                V = P.Work.MemberTable.ConNusView
            Case ContentEnum.SupplyEndList
                memberKind = Member.MemberKind.IsSupplyEnd
                If CType(P.Work.ARow("modeId"), Cprp.DxData.ModeEnum) = ModeEnum.isExport Then
                    V = P.Work.MemberTable.ConNusView
                Else
                    V = P.Work.MemberTable.ConRusView
                End If
        End Select
        If V Is Nothing Then Exit Sub
        '
        ' Обновление данных
        '
        ListGridView.BeginDataUpdate()
        For Each VRow As DataRowView In V
            P.Work.MemberTable.SetNum(VRow.Row, memberKind)
        Next
        ListGridView.EndDataUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    ' Загрузить объекты из операции
    Private Sub FromSupplyBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FromSupplyBarButtonItem.ItemClick
        Dim V As DataView = Nothing
        '
        ' Определение вида лица и обновляемого представления
        '
        Dim memberKind As Cprp.DxData.Member.MemberKind = Cprp.DxData.Member.MemberKind.IsEmpty
        Select Case MyBase.Content
            Case ContentEnum.ContractRusList
                memberKind = Member.MemberKind.IsContractRus
                V = P.Work.MemberTable.SupRusView
            Case ContentEnum.ContractNusList
                memberKind = Member.MemberKind.IsContractNus
                V = P.Work.MemberTable.SupNusView
            Case ContentEnum.SupplyEndList
                memberKind = Member.MemberKind.IsSupplyEnd
                If CType(P.Work.ARow("modeId"), Cprp.DxData.ModeEnum) = ModeEnum.isExport Then
                    V = P.Work.MemberTable.SupNusView
                Else
                    V = P.Work.MemberTable.SupRusView
                End If
        End Select
        If V Is Nothing Then Exit Sub
        '
        ' Обновление данных
        '
        ListGridView.BeginDataUpdate()
        For Each VRow As DataRowView In V
            P.Work.MemberTable.SetNum(VRow.Row, memberKind)
        Next
        ListGridView.EndDataUpdate()
        MyBase.SetChangeDateNow()
    End Sub

End Class
