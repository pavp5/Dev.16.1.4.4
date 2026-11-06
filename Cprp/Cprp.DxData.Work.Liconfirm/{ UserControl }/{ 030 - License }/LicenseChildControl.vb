Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "План работы"
''' </summary>
Friend Class LicenseChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelLicBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LicGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents LicGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckLicGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RegNumCaptionLicGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents IdLicGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EndNameLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents NusNameLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RusNameLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CountryNameLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ContractNameLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DescriptionLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents ListLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents InfoLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicenseChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckLicGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.SelLicBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LicGridControl = New DevExpress.XtraGrid.GridControl()
        Me.LicGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RegNumCaptionLicGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.IdLicGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EndNameLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.NusNameLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.RusNameLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.CountryNameLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.ContractNameLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.DescriptionLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.ListLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.InfoLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LicGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LicGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckLicGridColumn
        '
        Me.IsCheckLicGridColumn.Caption = "Выбрано"
        Me.IsCheckLicGridColumn.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IsCheckLicGridColumn.FieldName = "isCheck"
        Me.IsCheckLicGridColumn.Name = "IsCheckLicGridColumn"
        Me.IsCheckLicGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckLicGridColumn.Visible = True
        Me.IsCheckLicGridColumn.VisibleIndex = 0
        Me.IsCheckLicGridColumn.Width = 60
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.DisplayValueChecked = "Выбрано"
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "Не выбрано"
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.SelLicBarButtonItem})
        Me.BarManager1.MaxItemId = 1
        '
        'Bar1
        '
        Me.Bar1.BarName = "Лицензия"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(94, 221)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelLicBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Лицензия"
        '
        'SelLicBarButtonItem
        '
        Me.SelLicBarButtonItem.Caption = "Выбрать"
        Me.SelLicBarButtonItem.Glyph = CType(resources.GetObject("SelLicBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelLicBarButtonItem.Id = 0
        Me.SelLicBarButtonItem.Name = "SelLicBarButtonItem"
        ToolTipTitleItem1.Text = "Выбрать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Выбрать лицензию / Убрать из выборки"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.SelLicBarButtonItem.SuperTip = SuperToolTip1
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(24, 83)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(902, 37)
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
        Me.LayoutControl1.Controls.Add(Me.LicGridControl)
        Me.LayoutControl1.Controls.Add(Me.EndNameLabelControl)
        Me.LayoutControl1.Controls.Add(Me.NusNameLabelControl)
        Me.LayoutControl1.Controls.Add(Me.RusNameLabelControl)
        Me.LayoutControl1.Controls.Add(Me.CountryNameLabelControl)
        Me.LayoutControl1.Controls.Add(Me.ContractNameLabelControl)
        Me.LayoutControl1.Controls.Add(Me.DescriptionLabelControl)
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
        'LicGridControl
        '
        Me.LicGridControl.Location = New System.Drawing.Point(24, 124)
        Me.LicGridControl.MainView = Me.LicGridView
        Me.LicGridControl.Name = "LicGridControl"
        Me.LicGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit3, Me.RepositoryItemCheckEdit1})
        Me.LicGridControl.Size = New System.Drawing.Size(902, 104)
        Me.LicGridControl.TabIndex = 31
        Me.LicGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LicGridView})
        '
        'LicGridView
        '
        Me.LicGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.LicGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LicGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicGridView.Appearance.Row.Options.UseFont = True
        Me.LicGridView.Appearance.Row.Options.UseTextOptions = True
        Me.LicGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LicGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LicGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.LicGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.LicGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckLicGridColumn, Me.RegNumCaptionLicGridColumn, Me.IdLicGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckLicGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.LicGridView.FormatRules.Add(GridFormatRule1)
        Me.LicGridView.GridControl = Me.LicGridControl
        Me.LicGridView.GroupFormat = "{1}"
        Me.LicGridView.Name = "LicGridView"
        Me.LicGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.LicGridView.OptionsBehavior.Editable = False
        Me.LicGridView.OptionsCustomization.AllowColumnMoving = False
        Me.LicGridView.OptionsCustomization.AllowFilter = False
        Me.LicGridView.OptionsCustomization.AllowGroup = False
        Me.LicGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.LicGridView.OptionsCustomization.AllowSort = False
        Me.LicGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.LicGridView.OptionsView.RowAutoHeight = True
        Me.LicGridView.OptionsView.ShowGroupPanel = False
        Me.LicGridView.RowHeight = 25
        '
        'RegNumCaptionLicGridColumn
        '
        Me.RegNumCaptionLicGridColumn.Caption = "Лицензия"
        Me.RegNumCaptionLicGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.RegNumCaptionLicGridColumn.FieldName = "regNumCaption"
        Me.RegNumCaptionLicGridColumn.Name = "RegNumCaptionLicGridColumn"
        Me.RegNumCaptionLicGridColumn.Visible = True
        Me.RegNumCaptionLicGridColumn.VisibleIndex = 1
        Me.RegNumCaptionLicGridColumn.Width = 174
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'IdLicGridColumn
        '
        Me.IdLicGridColumn.Caption = "id"
        Me.IdLicGridColumn.FieldName = "id"
        Me.IdLicGridColumn.Name = "IdLicGridColumn"
        '
        'EndNameLabelControl
        '
        Me.EndNameLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.EndNameLabelControl.Location = New System.Drawing.Point(280, 442)
        Me.EndNameLabelControl.Name = "EndNameLabelControl"
        Me.EndNameLabelControl.Size = New System.Drawing.Size(646, 21)
        Me.EndNameLabelControl.StyleController = Me.LayoutControl1
        Me.EndNameLabelControl.TabIndex = 30
        Me.EndNameLabelControl.Text = "[нет данных]"
        '
        'NusNameLabelControl
        '
        Me.NusNameLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.NusNameLabelControl.Location = New System.Drawing.Point(280, 411)
        Me.NusNameLabelControl.Name = "NusNameLabelControl"
        Me.NusNameLabelControl.Size = New System.Drawing.Size(646, 21)
        Me.NusNameLabelControl.StyleController = Me.LayoutControl1
        Me.NusNameLabelControl.TabIndex = 29
        Me.NusNameLabelControl.Text = "[нет данных]"
        '
        'RusNameLabelControl
        '
        Me.RusNameLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.RusNameLabelControl.Location = New System.Drawing.Point(280, 380)
        Me.RusNameLabelControl.Name = "RusNameLabelControl"
        Me.RusNameLabelControl.Size = New System.Drawing.Size(646, 21)
        Me.RusNameLabelControl.StyleController = Me.LayoutControl1
        Me.RusNameLabelControl.TabIndex = 28
        Me.RusNameLabelControl.Text = "[нет данных]"
        '
        'CountryNameLabelControl
        '
        Me.CountryNameLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.CountryNameLabelControl.Location = New System.Drawing.Point(280, 349)
        Me.CountryNameLabelControl.Name = "CountryNameLabelControl"
        Me.CountryNameLabelControl.Size = New System.Drawing.Size(646, 21)
        Me.CountryNameLabelControl.StyleController = Me.LayoutControl1
        Me.CountryNameLabelControl.TabIndex = 27
        Me.CountryNameLabelControl.Text = "[нет данных]"
        '
        'ContractNameLabelControl
        '
        Me.ContractNameLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.ContractNameLabelControl.Location = New System.Drawing.Point(280, 318)
        Me.ContractNameLabelControl.Name = "ContractNameLabelControl"
        Me.ContractNameLabelControl.Size = New System.Drawing.Size(646, 21)
        Me.ContractNameLabelControl.StyleController = Me.LayoutControl1
        Me.ContractNameLabelControl.TabIndex = 26
        Me.ContractNameLabelControl.Text = "[нет данных]"
        '
        'DescriptionLabelControl
        '
        Me.DescriptionLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.DescriptionLabelControl.Location = New System.Drawing.Point(280, 287)
        Me.DescriptionLabelControl.Name = "DescriptionLabelControl"
        Me.DescriptionLabelControl.Size = New System.Drawing.Size(646, 21)
        Me.DescriptionLabelControl.StyleController = Me.LayoutControl1
        Me.DescriptionLabelControl.TabIndex = 25
        Me.DescriptionLabelControl.Text = "[нет данных]"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.ListLayoutControlGroup, Me.InfoLayoutControlGroup, Me.SplitterItem1})
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
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 40)
        Me.CaptionSimpleLabelItem.Text = "Сведения о лицензии"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'ListLayoutControlGroup
        '
        Me.ListLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem1})
        Me.ListLayoutControlGroup.Location = New System.Drawing.Point(0, 40)
        Me.ListLayoutControlGroup.Name = "ListLayoutControlGroup"
        Me.ListLayoutControlGroup.Size = New System.Drawing.Size(930, 192)
        Me.ListLayoutControlGroup.Text = "Лицензия"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.LicGridControl
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 41)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(906, 108)
        Me.LayoutControlItem8.Text = "Лицензия"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(906, 41)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'InfoLayoutControlGroup
        '
        Me.InfoLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1})
        Me.InfoLayoutControlGroup.Location = New System.Drawing.Point(0, 244)
        Me.InfoLayoutControlGroup.Name = "InfoLayoutControlGroup"
        Me.InfoLayoutControlGroup.Size = New System.Drawing.Size(930, 396)
        Me.InfoLayoutControlGroup.Text = "Сведения о лицензии"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DescriptionLabelControl
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(906, 31)
        Me.LayoutControlItem2.Text = "Предмет внешнеэкономической операции"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(253, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ContractNameLabelControl
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(906, 31)
        Me.LayoutControlItem3.Text = "Документ-основание операции"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(253, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.CountryNameLabelControl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 62)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(906, 31)
        Me.LayoutControlItem4.Text = "Страна назначения"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(253, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.RusNameLabelControl
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(906, 31)
        Me.LayoutControlItem5.Text = "Российский участник операции"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(253, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.NusNameLabelControl
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 124)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(906, 31)
        Me.LayoutControlItem6.Text = "Иностранный покупатель"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(253, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.EndNameLabelControl
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 155)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(906, 31)
        Me.LayoutControlItem7.Text = "Потребитель (конечный пользователь)"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(253, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 186)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(906, 167)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 232)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(930, 12)
        '
        'LicenseChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "LicenseChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LicGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LicGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
       '
        ' Выбранная лицензия
        '
        Dim Row As DataRow = P.Work.LicenseTable.Rows.Find(C2.ToInt(P.Work.ARow("licId")))
        LicGridView.BeginDataUpdate()
        P.Work.LicenseTable.CheckClear()
        If Not Row Is Nothing Then Row("isCheck") = True
        P.Work.LicenseTable.AcceptChanges()
        LicGridView.EndDataUpdate()
        LicGridView.MoveFirst()
        '
        ' Доступность элементов управления на редактирование 
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert
        SelLicBarButtonItem.Enabled = Not bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not (P.PlaneEditableForExpert OrElse P.PlaneEditableForLeader) Then Exit Sub
        '
        ' Выбранная лицензия
        '
        LicGridView.CloseEditor()
        LicGridView.UpdateCurrentRow()
        Using V As New DataView(P.Work.LicenseTable)
            V.RowFilter = "isCheck = True"
            If V.Count = 0 Then
                P.Work.ARow("licId") = DBNull.Value
            Else
                P.Work.ARow("licId") = V(0)("id")
            End If
        End Using
    End Sub

#End Region

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.PlaneUserControl
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Friend Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.License
        LicGridControl.DataSource = P.Work.LicenseTable
        LicGridView.SortInfo.Insert(0, RegNumCaptionLicGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckLicGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckLicGridColumn.Group()
        DescriptionLabelControl.DataBindings.Add("Text", P.Work.LicenseTable, "description")
        ContractNameLabelControl.DataBindings.Add("Text", P.Work.LicenseTable, "contractName")
        CountryNameLabelControl.DataBindings.Add("Text", P.Work.LicenseTable, "countryName")
        RusNameLabelControl.DataBindings.Add("Text", P.Work.LicenseTable, "rusName")
        NusNameLabelControl.DataBindings.Add("Text", P.Work.LicenseTable, "nusName")
        EndNameLabelControl.DataBindings.Add("Text", P.Work.LicenseTable, "endName")
        InfoLayoutControlGroup.Height = (ListLayoutControlGroup.Height + InfoLayoutControlGroup.Height) / 2
    End Sub

    ' Выбрать лицензию / Убрать из выборки
    Private Sub SelLicBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelLicBarButtonItem.ItemClick
        Dim Row As DataRow = LicGridView.GetFocusedDataRow
        If Row Is Nothing Then Exit Sub
        Dim bTmp As Boolean = CBool(Row("isCheck"))
        If bTmp Then
            P.Work.ARow("licId") = DBNull.Value
        Else
            P.Work.ARow("licId") = Row("id")
        End If
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub LicGridControl_DoubleClick(sender As Object, e As EventArgs) Handles LicGridControl.DoubleClick
        If SelLicBarButtonItem.Enabled Then SelLicBarButtonItem.PerformClick()
    End Sub

    Private Sub LicGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles LicGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

End Class
