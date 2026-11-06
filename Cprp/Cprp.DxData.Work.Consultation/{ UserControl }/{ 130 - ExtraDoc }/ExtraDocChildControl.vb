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
    Friend WithEvents DocRuleBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents DocOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileDownloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileUploadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
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
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExtraDocChildControl))
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.DocAddBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocDelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.FileUploadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileDownloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocOpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocRuleBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RowNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RegNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RegDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsUsedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EoIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.DocAddBarButtonItem, Me.DocDelBarButtonItem, Me.DocClearBarButtonItem, Me.BarSubItem1, Me.FileUploadBarButtonItem, Me.FileDownloadBarButtonItem, Me.DocOpenBarButtonItem, Me.DocRuleBarCheckItem})
        Me.BarManager1.MaxItemId = 8
        '
        'Bar1
        '
        Me.Bar1.BarName = "Перечень документов"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(67, 191)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DocAddBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.DocDelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DocClearBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarSubItem1, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.DocOpenBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DocRuleBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        ToolTipTitleItem6.Text = "Добавить"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Добавить новый документ"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.DocAddBarButtonItem.SuperTip = SuperToolTip6
        '
        'DocDelBarButtonItem
        '
        Me.DocDelBarButtonItem.Caption = "Удалить"
        Me.DocDelBarButtonItem.Glyph = CType(resources.GetObject("DocDelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocDelBarButtonItem.Id = 1
        Me.DocDelBarButtonItem.Name = "DocDelBarButtonItem"
        ToolTipTitleItem7.Text = "Удалить"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Удалить документ"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.DocDelBarButtonItem.SuperTip = SuperToolTip7
        '
        'DocClearBarButtonItem
        '
        Me.DocClearBarButtonItem.Caption = "Удалить все"
        Me.DocClearBarButtonItem.Glyph = CType(resources.GetObject("DocClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocClearBarButtonItem.Id = 2
        Me.DocClearBarButtonItem.Name = "DocClearBarButtonItem"
        ToolTipTitleItem8.Text = "Удалить все"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Удалить все документы"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.DocClearBarButtonItem.SuperTip = SuperToolTip8
        '
        'BarSubItem1
        '
        Me.BarSubItem1.AllowDrawArrow = DevExpress.Utils.DefaultBoolean.[False]
        Me.BarSubItem1.Caption = "Файлы"
        Me.BarSubItem1.Glyph = CType(resources.GetObject("BarSubItem1.Glyph"), System.Drawing.Image)
        Me.BarSubItem1.Id = 3
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FileUploadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FileDownloadBarButtonItem)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'FileUploadBarButtonItem
        '
        Me.FileUploadBarButtonItem.Caption = "Выгрузить"
        Me.FileUploadBarButtonItem.Description = "Выгрузить перечень документов в файл с загрузочной таблицей"
        Me.FileUploadBarButtonItem.Glyph = CType(resources.GetObject("FileUploadBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FileUploadBarButtonItem.Id = 4
        Me.FileUploadBarButtonItem.Name = "FileUploadBarButtonItem"
        '
        'FileDownloadBarButtonItem
        '
        Me.FileDownloadBarButtonItem.Caption = "Загрузить"
        Me.FileDownloadBarButtonItem.Description = "Загрузить перечень документов из файла с загрузочной таблицей"
        Me.FileDownloadBarButtonItem.Glyph = CType(resources.GetObject("FileDownloadBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FileDownloadBarButtonItem.Id = 5
        Me.FileDownloadBarButtonItem.Name = "FileDownloadBarButtonItem"
        '
        'DocOpenBarButtonItem
        '
        Me.DocOpenBarButtonItem.Caption = "Открыть"
        Me.DocOpenBarButtonItem.Glyph = CType(resources.GetObject("DocOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocOpenBarButtonItem.Id = 6
        Me.DocOpenBarButtonItem.Name = "DocOpenBarButtonItem"
        ToolTipTitleItem9.Text = "Открыть"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Открыть карточку документа"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.DocOpenBarButtonItem.SuperTip = SuperToolTip9
        '
        'DocRuleBarCheckItem
        '
        Me.DocRuleBarCheckItem.Caption = "Провоспособность удостоверяю"
        Me.DocRuleBarCheckItem.Glyph = CType(resources.GetObject("DocRuleBarCheckItem.Glyph"), System.Drawing.Image)
        Me.DocRuleBarCheckItem.Id = 7
        Me.DocRuleBarCheckItem.Name = "DocRuleBarCheckItem"
        ToolTipTitleItem10.Text = "Правоспособность удостоверяю"
        ToolTipItem10.LeftIndent = 6
        ToolTipItem10.Text = "Правоспособность и достаточность сведений, представленных для проведения идентифи" & _
    "кационной экспертизы, удостоверяю"
        SuperToolTip10.Items.Add(ToolTipTitleItem10)
        SuperToolTip10.Items.Add(ToolTipItem10)
        Me.DocRuleBarCheckItem.SuperTip = SuperToolTip10
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
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'ListGridControl
        '
        Me.ListGridControl.Location = New System.Drawing.Point(12, 93)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.Size = New System.Drawing.Size(926, 555)
        Me.ListGridControl.TabIndex = 7
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ListGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RowNumGridColumn, Me.CaptionGridColumn, Me.RegNumGridColumn, Me.RegDateGridColumn, Me.IsUsedGridColumn, Me.EoIdGridColumn})
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
        Me.CaptionGridColumn.VisibleIndex = 1
        Me.CaptionGridColumn.Width = 549
        '
        'RegNumGridColumn
        '
        Me.RegNumGridColumn.Caption = "Номер"
        Me.RegNumGridColumn.FieldName = "regNum"
        Me.RegNumGridColumn.Name = "RegNumGridColumn"
        Me.RegNumGridColumn.Visible = True
        Me.RegNumGridColumn.VisibleIndex = 2
        Me.RegNumGridColumn.Width = 167
        '
        'RegDateGridColumn
        '
        Me.RegDateGridColumn.Caption = "Дата"
        Me.RegDateGridColumn.FieldName = "regDate"
        Me.RegDateGridColumn.Name = "RegDateGridColumn"
        Me.RegDateGridColumn.OptionsColumn.FixedWidth = True
        Me.RegDateGridColumn.Visible = True
        Me.RegDateGridColumn.VisibleIndex = 3
        Me.RegDateGridColumn.Width = 100
        '
        'IsUsedGridColumn
        '
        Me.IsUsedGridColumn.Caption = "Использован"
        Me.IsUsedGridColumn.FieldName = "isUsed"
        Me.IsUsedGridColumn.Name = "IsUsedGridColumn"
        Me.IsUsedGridColumn.OptionsColumn.FixedWidth = True
        Me.IsUsedGridColumn.ToolTip = "Документ использован в текущей работе"
        Me.IsUsedGridColumn.Visible = True
        Me.IsUsedGridColumn.VisibleIndex = 4
        '
        'EoIdGridColumn
        '
        Me.EoIdGridColumn.Caption = "eoId"
        Me.EoIdGridColumn.FieldName = "eoId"
        Me.EoIdGridColumn.Name = "EoIdGridColumn"
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
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 559)
        Me.LayoutControlItem1.Text = "Перечень документов"
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
        CaptionSimpleLabelItem.Text = "Сведения о работе > Перечень документов"
        DocRuleBarCheckItem.Checked = CBool(P.Work.ARow("isDocRule"))
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not (P.PlaneEditableForExpert OrElse P.WorkEditableForExpert)    ' Работа не доступна эксперту для редактирования
        DocAddBarButtonItem.Enabled = Not bLock
        DocDelBarButtonItem.Enabled = Not bLock
        DocClearBarButtonItem.Enabled = Not bLock
        FileDownloadBarButtonItem.Enabled = Not bLock
        DocRuleBarCheckItem.Enabled = Not bLock
        ListGridView.OptionsBehavior.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Данные объекта
        '
        P.Work.ARow("isDocRule") = DocRuleBarCheckItem.Checked
        P.Work.ARow.AcceptChanges()
        '
        ' Перечень документов
        '
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        P.Work.InDocTable.AcceptChanges()
    End Sub

#End Region


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.ExtraDoc
        ListGridControl.DataSource = P.Work.InDocTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
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
        P.Work.InDocTable.AddNew()
        MyBase.SetChangeDateNow()
    End Sub

    ' Удалить документ
    Private Sub DocDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocDelBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Not IsDBNull(ListGridView.GetFocusedDataRow("eoId")) Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Удалить документ № {0}?", C2.ToInt(ListGridView.GetFocusedDataRow("rowNum")))) <> DialogResult.Yes Then Exit Sub
        ListGridView.GetFocusedDataRow.Delete()
        ListGridView.RefreshData()
        ListGridControl.Focus()
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

    ' Выгрузить документы в файл
    Private Sub FileUploadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileUploadBarButtonItem.ItemClick
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Сохранение данных в файл"
            Dlg.FileName = String.Format("Работа № {0} (Объекты экспертизы + документы)", CInt(P.Work.Id))
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            DataWrite()
            '
            ' Создание загрузочного файла
            '
            P.Work.DataToRtf(filePath)
            Cprp.DxCommon.WaitForm.Close()
            '
            ' Открытие файла с загрузочной таблицей внешней программой
            '
            If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?") = DialogResult.Yes Then
                Using P As New Process
                    P.StartInfo.FileName = Trim(filePath)
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Загрузить документы из файла
    Private Sub FileDownloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileDownloadBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        '
        ' Выбор загрузочного файла
        '
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        '
        ' Загрузка данных
        '
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            P.Work.InDocFromRtf(filePath)
            MyBase.SetChangeDateNow()
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
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

    Private Sub ListGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ListGridView.CellValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
