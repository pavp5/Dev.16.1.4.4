Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Перечень документов"
''' </summary>
Friend Class ExtraDocChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents DocOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DocClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DocDelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DocAddBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ListGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ListGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RowNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RegNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RegDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsUsedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EoIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PreviwLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents EmptyLabel As System.Windows.Forms.Label
    Friend WithEvents PreviewBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents KindIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KindRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExtraDocChildControl))
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.EoIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsUsedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.DocAddBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocDelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocOpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.PreviewBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DocClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.EmptyLabel = New System.Windows.Forms.Label()
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RowNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RegNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RegDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PreviwLayoutControlItem = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.KindIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KindRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanelControl.SuspendLayout()
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreviwLayoutControlItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KindRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EoIdGridColumn
        '
        Me.EoIdGridColumn.Caption = "eoId"
        Me.EoIdGridColumn.FieldName = "eoId"
        Me.EoIdGridColumn.Name = "EoIdGridColumn"
        '
        'IsUsedGridColumn
        '
        Me.IsUsedGridColumn.Caption = "Использован"
        Me.IsUsedGridColumn.FieldName = "isUsed"
        Me.IsUsedGridColumn.Name = "IsUsedGridColumn"
        Me.IsUsedGridColumn.OptionsColumn.FixedWidth = True
        Me.IsUsedGridColumn.ToolTip = "Документ использован в текущей работе"
        Me.IsUsedGridColumn.Visible = True
        Me.IsUsedGridColumn.VisibleIndex = 5
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.DocAddBarButtonItem, Me.DocDelBarButtonItem, Me.DocClearBarButtonItem, Me.DocOpenBarButtonItem, Me.PreviewBarCheckItem})
        Me.BarManager1.MaxItemId = 9
        '
        'Bar1
        '
        Me.Bar1.BarName = "Перечень документов"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(67, 191)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DocAddBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.DocDelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DocOpenBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.PreviewBarCheckItem, True)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Перечень документов"
        '
        'DocAddBarButtonItem
        '
        Me.DocAddBarButtonItem.Caption = "Добавить"
        Me.DocAddBarButtonItem.Glyph = CType(resources.GetObject("DocAddBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocAddBarButtonItem.Id = 0
        Me.DocAddBarButtonItem.Name = "DocAddBarButtonItem"
        ToolTipTitleItem1.Text = "Добавить"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Добавить новый документ"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.DocAddBarButtonItem.SuperTip = SuperToolTip1
        '
        'DocDelBarButtonItem
        '
        Me.DocDelBarButtonItem.Caption = "Удалить"
        Me.DocDelBarButtonItem.Glyph = CType(resources.GetObject("DocDelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocDelBarButtonItem.Id = 1
        Me.DocDelBarButtonItem.Name = "DocDelBarButtonItem"
        ToolTipTitleItem2.Text = "Удалить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Удалить документ"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.DocDelBarButtonItem.SuperTip = SuperToolTip2
        '
        'DocOpenBarButtonItem
        '
        Me.DocOpenBarButtonItem.Caption = "Открыть"
        Me.DocOpenBarButtonItem.Glyph = CType(resources.GetObject("DocOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocOpenBarButtonItem.Id = 6
        Me.DocOpenBarButtonItem.Name = "DocOpenBarButtonItem"
        ToolTipTitleItem3.Text = "Открыть"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Открыть карточку документа"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.DocOpenBarButtonItem.SuperTip = SuperToolTip3
        '
        'PreviewBarCheckItem
        '
        Me.PreviewBarCheckItem.Caption = "Предпросмотр"
        Me.PreviewBarCheckItem.Glyph = CType(resources.GetObject("PreviewBarCheckItem.Glyph"), System.Drawing.Image)
        Me.PreviewBarCheckItem.Id = 8
        Me.PreviewBarCheckItem.Name = "PreviewBarCheckItem"
        ToolTipTitleItem4.Text = "Предпросмотр"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Включить / отключить режим предпросмотра документов"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.PreviewBarCheckItem.SuperTip = SuperToolTip4
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 39)
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
        'DocClearBarButtonItem
        '
        Me.DocClearBarButtonItem.Caption = "Удалить все"
        Me.DocClearBarButtonItem.Glyph = CType(resources.GetObject("DocClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocClearBarButtonItem.Id = 2
        Me.DocClearBarButtonItem.Name = "DocClearBarButtonItem"
        ToolTipTitleItem5.Text = "Удалить все"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Удалить все документы"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.DocClearBarButtonItem.SuperTip = SuperToolTip5
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.MainPanelControl)
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
        'MainPanelControl
        '
        Me.MainPanelControl.Controls.Add(Me.EmptyLabel)
        Me.MainPanelControl.Location = New System.Drawing.Point(12, 429)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(926, 219)
        Me.MainPanelControl.TabIndex = 8
        '
        'EmptyLabel
        '
        Me.EmptyLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EmptyLabel.Font = New System.Drawing.Font("Tahoma", 8.150944!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.EmptyLabel.Location = New System.Drawing.Point(2, 2)
        Me.EmptyLabel.Name = "EmptyLabel"
        Me.EmptyLabel.Size = New System.Drawing.Size(922, 215)
        Me.EmptyLabel.TabIndex = 0
        Me.EmptyLabel.Text = "Нет данных для просмотра"
        Me.EmptyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ListGridControl
        '
        Me.ListGridControl.Location = New System.Drawing.Point(12, 95)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.KindRepositoryItemLookUpEdit})
        Me.ListGridControl.Size = New System.Drawing.Size(926, 317)
        Me.ListGridControl.TabIndex = 7
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ListGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RowNumGridColumn, Me.KindIdGridColumn, Me.CaptionGridColumn, Me.RegNumGridColumn, Me.RegDateGridColumn, Me.IsUsedGridColumn, Me.EoIdGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.EoIdGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue1.Value1 = CType(0, Short)
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.IsUsedGridColumn
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.DarkGray
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = False
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.ListGridView.FormatRules.Add(GridFormatRule1)
        Me.ListGridView.FormatRules.Add(GridFormatRule2)
        Me.ListGridView.GridControl = Me.ListGridControl
        Me.ListGridView.Name = "ListGridView"
        Me.ListGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsCustomization.AllowFilter = False
        Me.ListGridView.OptionsCustomization.AllowGroup = False
        Me.ListGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ListGridView.OptionsDetail.EnableMasterViewMode = False
        Me.ListGridView.OptionsNavigation.AutoFocusNewRow = True
        Me.ListGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ListGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ListGridView.OptionsView.AllowHtmlDrawHeaders = True
        Me.ListGridView.OptionsView.RowAutoHeight = True
        Me.ListGridView.OptionsView.ShowGroupPanel = False
        Me.ListGridView.RowHeight = 30
        '
        'RowNumGridColumn
        '
        Me.RowNumGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowNumGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowNumGridColumn.Caption = "№№<color='red'>*</color>"
        Me.RowNumGridColumn.FieldName = "rowNum"
        Me.RowNumGridColumn.Name = "RowNumGridColumn"
        Me.RowNumGridColumn.OptionsColumn.FixedWidth = True
        Me.RowNumGridColumn.Visible = True
        Me.RowNumGridColumn.VisibleIndex = 0
        Me.RowNumGridColumn.Width = 60
        '
        'CaptionGridColumn
        '
        Me.CaptionGridColumn.Caption = "Наименование или краткое содержание<color='red'>*</color>"
        Me.CaptionGridColumn.FieldName = "caption"
        Me.CaptionGridColumn.Name = "CaptionGridColumn"
        Me.CaptionGridColumn.Visible = True
        Me.CaptionGridColumn.VisibleIndex = 2
        Me.CaptionGridColumn.Width = 438
        '
        'RegNumGridColumn
        '
        Me.RegNumGridColumn.Caption = "Номер"
        Me.RegNumGridColumn.FieldName = "regNum"
        Me.RegNumGridColumn.Name = "RegNumGridColumn"
        Me.RegNumGridColumn.Visible = True
        Me.RegNumGridColumn.VisibleIndex = 3
        Me.RegNumGridColumn.Width = 135
        '
        'RegDateGridColumn
        '
        Me.RegDateGridColumn.Caption = "Дата"
        Me.RegDateGridColumn.FieldName = "regDate"
        Me.RegDateGridColumn.Name = "RegDateGridColumn"
        Me.RegDateGridColumn.OptionsColumn.FixedWidth = True
        Me.RegDateGridColumn.Visible = True
        Me.RegDateGridColumn.VisibleIndex = 4
        Me.RegDateGridColumn.Width = 100
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.PreviwLayoutControlItem, Me.SplitterItem1})
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
        Me.CaptionSimpleLabelItem.Text = "Перечень документов"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ListGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 83)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 321)
        Me.LayoutControlItem1.Text = "Перечень документов"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(930, 43)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'PreviwLayoutControlItem
        '
        Me.PreviwLayoutControlItem.Control = Me.MainPanelControl
        Me.PreviwLayoutControlItem.Location = New System.Drawing.Point(0, 417)
        Me.PreviwLayoutControlItem.Name = "PreviwLayoutControlItem"
        Me.PreviwLayoutControlItem.Size = New System.Drawing.Size(930, 223)
        Me.PreviwLayoutControlItem.TextSize = New System.Drawing.Size(0, 0)
        Me.PreviwLayoutControlItem.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 404)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(930, 13)
        '
        'KindIdGridColumn
        '
        Me.KindIdGridColumn.Caption = "Вид"
        Me.KindIdGridColumn.ColumnEdit = Me.KindRepositoryItemLookUpEdit
        Me.KindIdGridColumn.FieldName = "kindId"
        Me.KindIdGridColumn.Name = "KindIdGridColumn"
        Me.KindIdGridColumn.OptionsColumn.FixedWidth = True
        Me.KindIdGridColumn.Visible = True
        Me.KindIdGridColumn.VisibleIndex = 1
        Me.KindIdGridColumn.Width = 95
        '
        'KindRepositoryItemLookUpEdit
        '
        Me.KindRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.KindRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.KindRepositoryItemLookUpEdit.AutoHeight = False
        Me.KindRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.KindRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.KindRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.KindRepositoryItemLookUpEdit.DropDownRows = 3
        Me.KindRepositoryItemLookUpEdit.Name = "KindRepositoryItemLookUpEdit"
        Me.KindRepositoryItemLookUpEdit.ShowFooter = False
        Me.KindRepositoryItemLookUpEdit.ShowHeader = False
        Me.KindRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'ExtraDocChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ExtraDocChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanelControl.ResumeLayout(False)
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreviwLayoutControlItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KindRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
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
        CaptionSimpleLabelItem.Text = "Сведения о работе > Перечень документов"
        ''
        '' Доступность элементов на редактирование
        ''
        'Dim bLock As Boolean = Not (P.PlaneEditableForExpert OrElse P.WorkEditableForExpert)    ' Работа не доступна эксперту для редактирования
        'DocAddBarButtonItem.Enabled = Not bLock
        'DocDelBarButtonItem.Enabled = Not bLock
        'DocClearBarButtonItem.Enabled = Not bLock
        'ListGridView.OptionsBehavior.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        'If Not (P.PlaneEditableForExpert OrElse P.WorkEditableForExpert) Then Exit Sub
        '
        ' Перечень документов
        '
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        P.Work.InDocTable.AcceptChanges()
    End Sub

#End Region

    Dim WebClient As System.Net.WebClient = Nothing

    Dim PdfControl As DevExpress.XtraPdfViewer.PdfViewer = Nothing
    Dim WordControl As DevExpress.XtraRichEdit.RichEditControl = Nothing
    Dim ExcelControl As DevExpress.XtraSpreadsheet.SpreadsheetControl = Nothing
    Dim PictControl As DevExpress.XtraEditors.PictureEdit = Nothing

    ''' <summary>
    ''' Путь к корневой папке файлов документов
    ''' </summary>
    Dim RootFolderPath As String = Nothing

    ' Временный файл с текущим документом
    Dim filePath As String = Nothing

    ''' <summary>
    ''' Справочник видов документов
    ''' </summary>
    Dim KindTable As DataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.ExtraDoc
        '
        ' KindTable
        '
        KindTable = New DataTable
        With KindTable.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        KindTable.PrimaryKey = New DataColumn() {KindTable.Columns("id")}
        With KindTable.Rows
            .Add(New Object() {1, "входящий"})
            .Add(New Object() {2, "исходящий"})
            .Add(New Object() {3, "внутренний"})
        End With
        '
        ' RootFolderPath
        '
        RootFolderPath = String.Format("{0}\_лицензии\{1}", Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", P.Work.Connection), CInt(P.Work.Id))
        '
        ' ListGridControl, ListGridView
        '
        KindRepositoryItemLookUpEdit.DataSource = KindTable
        ListGridControl.DataSource = P.Work.InDocTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' WebClient
        '
        WebClient = New System.Net.WebClient
        WebClient.UseDefaultCredentials = True
        '
        ' PdfControl
        '
        PdfControl = New DevExpress.XtraPdfViewer.PdfViewer With { _
            .Dock = DockStyle.Fill, _
            .NavigationPaneInitialVisibility = DevExpress.XtraPdfViewer.PdfNavigationPaneVisibility.Hidden}
        '
        ' WordControl
        '
        WordControl = New DevExpress.XtraRichEdit.RichEditControl With { _
            .Dock = DockStyle.Fill, _
            .ReadOnly = True, _
            .ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.PrintLayout}
        '
        ' ExcelControl
        '
        ExcelControl = New DevExpress.XtraSpreadsheet.SpreadsheetControl With { _
            .Dock = DockStyle.Fill, _
            .ReadOnly = True}
        '
        ' PictControl
        '
        PictControl = New DevExpress.XtraEditors.PictureEdit With { _
            .Dock = DockStyle.Fill, _
            .ReadOnly = True}
        PictControl.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        PictControl.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True
        '
        ' MainPanelControl
        '
        MainPanelControl.Controls.AddRange(New Control() {PdfControl, WordControl, ExcelControl, PictControl})
        MainPanelControl.Controls.SetChildIndex(EmptyLabel, 0)

        PreviewBarCheckItem.Checked = True

    End Sub

    Private Sub ListGridView_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles ListGridView.CustomDrawCell
        Dim sTmp As String = Nothing
        If Not (e.CellValue Is Nothing OrElse IsDBNull(e.CellValue)) Then sTmp = e.CellValue.ToString
        If Not String.IsNullOrEmpty(sTmp) Then Exit Sub
        Select Case e.Column.FieldName
            Case "rowNum", "caption"
                e.DisplayText = "[обязательное поле]"
                e.Appearance.ForeColor = Drawing.SystemColors.InactiveCaptionText
        End Select
    End Sub

    ' Добавить новый документ
    Private Sub DocAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocAddBarButtonItem.ItemClick
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        Dim oldPath As String = Nothing
        Dim newPath As String = Nothing
        Dim fName As String = Nothing
        Dim fExt As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выберите файл документа"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            oldPath = Dlg.FileName
        End Using
        With My.Computer.FileSystem.GetFileInfo(oldPath)
            fName = .Name
            fExt = .Extension.Replace(".", Nothing)
        End With
        newPath = String.Format("{0}\{1}", RootFolderPath, fName)
        My.Computer.FileSystem.CopyFile(oldPath, newPath, True)
        Dim Row As DataRow = P.Work.InDocTable.AddNew()
        Row("docUrl") = newPath
        Row("ext") = fExt
        Row("caption") = fName
        P.Work.DataSave()
        P.Work.MessageOutputDocumentNewEo(Nothing, Nothing, "EXCONT\" & P.CurrentUser.Login, newPath, 0, Nothing, Nothing, -1, 1)
        MyBase.SetChangeDateNow()
    End Sub

    ' Удалить документ
    Private Sub DocDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocDelBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Not IsDBNull(ListGridView.GetFocusedDataRow("eoId")) Then Exit Sub
        Dim fPath As String = C2.ToText(ListGridView.GetFocusedDataRow("docUrl"))
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Удалить документ № {0}?", C2.ToInt(ListGridView.GetFocusedDataRow("rowNum")))) <> DialogResult.Yes Then Exit Sub
        With My.Computer.FileSystem
            If C2.IsText(fPath) AndAlso .FileExists(fPath) Then .DeleteFile(fPath)
        End With
        ListGridView.GetFocusedDataRow.Delete()
        ListGridView.RefreshData()
        ListGridControl.Focus()
        P.Work.DataSave()
        MyBase.SetChangeDateNow()
    End Sub

    ' Удалить все документы
    Private Sub DocClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocClearBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить все документы?") <> DialogResult.Yes Then Exit Sub
        Using V As New DataView(P.Work.InDocTable)
            V.RowFilter = "eoId IS NULL"
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        ListGridView.RefreshData()
        ListGridControl.Focus()
        MyBase.SetChangeDateNow()
    End Sub

    ' Открыть карточку документа
    Private Sub DocOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = C2.ToText(ListGridView.GetFocusedDataRow("docUrl"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Ссылка на файл документа отсутствует.", String.Format("Документ № {0}", C2.ToInt(ListGridView.GetFocusedDataRow("rowNum"))))
            Exit Sub
        End If
        Try
            Using P As New Process
                P.StartInfo.FileName = sTmp
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub ListGridView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ListGridView.FocusedRowChanged
        If PreviewBarCheckItem.Checked Then FileOpen()
    End Sub

    Private Sub PreviewBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PreviewBarCheckItem.CheckedChanged
        If PreviewBarCheckItem.Checked Then
            PreviwLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            SplitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            FileOpen()
        Else
            PreviwLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            SplitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub ListGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ListGridView.CellValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    ' Предпросмотр файла
    Private Sub FileOpen()
        If PdfControl.IsDocumentOpened Then PdfControl.CloseDocument()
        If PictControl.LoadInProgress Then PictControl.CancelLoadAsync()
        If Not String.IsNullOrWhiteSpace(filePath) AndAlso My.Computer.FileSystem.FileExists(filePath) Then
            My.Computer.FileSystem.DeleteFile(filePath)
        End If
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim ext As String = Nothing
        Dim docUrl As String = Nothing
        With ListGridView.GetFocusedDataRow
            ext = C2.ToText(.Item("ext"))
            docUrl = C2.ToText(.Item("docUrl"))
        End With
        If String.IsNullOrWhiteSpace(ext) OrElse String.IsNullOrWhiteSpace(docUrl) Then
            MainPanelControl.Controls.SetChildIndex(EmptyLabel, 0)
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            filePath = My.Computer.FileSystem.GetTempFileName
            WebClient.DownloadFile(docUrl, filePath)
            ext = ext.ToUpper
            Select Case ext
                Case "PDF"
                    PdfControl.LoadDocument(filePath)
                    MainPanelControl.Controls.SetChildIndex(PdfControl, 0)
                Case "DOC"
                    WordControl.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
                    MainPanelControl.Controls.SetChildIndex(WordControl, 0)
                Case "DOCX"
                    WordControl.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
                    MainPanelControl.Controls.SetChildIndex(WordControl, 0)
                Case "XLS", "XLSX"
                    ExcelControl.LoadDocument(filePath)
                    MainPanelControl.Controls.SetChildIndex(ExcelControl, 0)
                Case "JPG", "JPEG", "PNG", "TIF", "TIFF", "BMP", "GIF"
                    PictControl.LoadAsync(filePath)
                    MainPanelControl.Controls.SetChildIndex(PictControl, 0)

                Case Else
                    MainPanelControl.Controls.SetChildIndex(EmptyLabel, 0)
                    My.Computer.FileSystem.DeleteFile(filePath)
            End Select
        Catch ex As Exception
            MainPanelControl.Controls.SetChildIndex(EmptyLabel, 0)
        Finally
            Cprp.DxCommon.WaitForm.Close()
        End Try
    End Sub

End Class
