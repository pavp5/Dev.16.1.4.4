Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Решение по анализу"
''' </summary>
Friend Class SummaryChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelLawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents CaptionGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CaptionGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PosCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescriptionCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LawIdCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SummaryMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SummaryLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SummaryChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.SelLawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CaptionGridControl = New DevExpress.XtraGrid.GridControl()
        Me.CaptionGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PosCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescriptionCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LawIdCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SummaryMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SummaryLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CaptionGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckRiskGridColumn
        '
        Me.IsCheckRiskGridColumn.Caption = "Выбрано"
        Me.IsCheckRiskGridColumn.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IsCheckRiskGridColumn.FieldName = "isCheck"
        Me.IsCheckRiskGridColumn.Name = "IsCheckRiskGridColumn"
        Me.IsCheckRiskGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckRiskGridColumn.Visible = True
        Me.IsCheckRiskGridColumn.VisibleIndex = 0
        Me.IsCheckRiskGridColumn.Width = 60
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.SelLawBarButtonItem})
        Me.BarManager1.MaxItemId = 1
        '
        'Bar1
        '
        Me.Bar1.BarName = "Единый перечень"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(120, 191)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelLawBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Единый перечень"
        '
        'SelLawBarButtonItem
        '
        Me.SelLawBarButtonItem.Caption = "Выбрать"
        Me.SelLawBarButtonItem.Glyph = CType(resources.GetObject("SelLawBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelLawBarButtonItem.Id = 0
        Me.SelLawBarButtonItem.Name = "SelLawBarButtonItem"
        ToolTipTitleItem1.Text = "Выбрать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Выбрать раздел / Убрать из выборки"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.SelLawBarButtonItem.SuperTip = SuperToolTip1
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(25, 86)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(900, 39)
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
        Me.LayoutControl1.Controls.Add(Me.CaptionGridControl)
        Me.LayoutControl1.Controls.Add(Me.SummaryMemoEdit)
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
        'CaptionGridControl
        '
        Me.CaptionGridControl.Location = New System.Drawing.Point(25, 129)
        Me.CaptionGridControl.MainView = Me.CaptionGridView
        Me.CaptionGridControl.Name = "CaptionGridControl"
        Me.CaptionGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit3, Me.RepositoryItemCheckEdit1})
        Me.CaptionGridControl.Size = New System.Drawing.Size(900, 375)
        Me.CaptionGridControl.TabIndex = 23
        Me.CaptionGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CaptionGridView})
        '
        'CaptionGridView
        '
        Me.CaptionGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.CaptionGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CaptionGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionGridView.Appearance.Row.Options.UseFont = True
        Me.CaptionGridView.Appearance.Row.Options.UseTextOptions = True
        Me.CaptionGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CaptionGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CaptionGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.CaptionGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.CaptionGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckRiskGridColumn, Me.PosCaptionGridColumn, Me.DescriptionCaptionGridColumn, Me.LawIdCaptionGridColumn, Me.DocCaptionGridColumn})
        Me.CaptionGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckRiskGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.CaptionGridView.FormatRules.Add(GridFormatRule1)
        Me.CaptionGridView.GridControl = Me.CaptionGridControl
        Me.CaptionGridView.GroupFormat = "{1}"
        Me.CaptionGridView.Name = "CaptionGridView"
        Me.CaptionGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CaptionGridView.OptionsBehavior.Editable = False
        Me.CaptionGridView.OptionsCustomization.AllowColumnMoving = False
        Me.CaptionGridView.OptionsCustomization.AllowFilter = False
        Me.CaptionGridView.OptionsCustomization.AllowGroup = False
        Me.CaptionGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CaptionGridView.OptionsCustomization.AllowSort = False
        Me.CaptionGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CaptionGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CaptionGridView.OptionsView.RowAutoHeight = True
        Me.CaptionGridView.OptionsView.ShowGroupPanel = False
        Me.CaptionGridView.RowHeight = 25
        '
        'PosCaptionGridColumn
        '
        Me.PosCaptionGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.PosCaptionGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PosCaptionGridColumn.Caption = "Номер"
        Me.PosCaptionGridColumn.FieldName = "pos"
        Me.PosCaptionGridColumn.Name = "PosCaptionGridColumn"
        Me.PosCaptionGridColumn.OptionsColumn.FixedWidth = True
        Me.PosCaptionGridColumn.Visible = True
        Me.PosCaptionGridColumn.VisibleIndex = 1
        Me.PosCaptionGridColumn.Width = 80
        '
        'DescriptionCaptionGridColumn
        '
        Me.DescriptionCaptionGridColumn.Caption = "Наименование"
        Me.DescriptionCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.DescriptionCaptionGridColumn.FieldName = "description"
        Me.DescriptionCaptionGridColumn.Name = "DescriptionCaptionGridColumn"
        Me.DescriptionCaptionGridColumn.Visible = True
        Me.DescriptionCaptionGridColumn.VisibleIndex = 2
        Me.DescriptionCaptionGridColumn.Width = 741
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'LawIdCaptionGridColumn
        '
        Me.LawIdCaptionGridColumn.Caption = "lawId"
        Me.LawIdCaptionGridColumn.FieldName = "lawId"
        Me.LawIdCaptionGridColumn.Name = "LawIdCaptionGridColumn"
        '
        'DocCaptionGridColumn
        '
        Me.DocCaptionGridColumn.Caption = "doc"
        Me.DocCaptionGridColumn.FieldName = "doc"
        Me.DocCaptionGridColumn.Name = "DocCaptionGridColumn"
        '
        'SummaryMemoEdit
        '
        Me.SummaryMemoEdit.Location = New System.Drawing.Point(25, 568)
        Me.SummaryMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.SummaryMemoEdit.Name = "SummaryMemoEdit"
        Me.SummaryMemoEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.SummaryMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.SummaryMemoEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.SummaryMemoEdit.Size = New System.Drawing.Size(900, 67)
        Me.SummaryMemoEdit.StyleController = Me.LayoutControl1
        Me.SummaryMemoEdit.TabIndex = 22
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.SummaryLayoutControlGroup, Me.SplitterItem1, Me.LayoutControlGroup1})
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
        Me.CaptionSimpleLabelItem.Text = "РЕШЕНИЕ ПО АНАЛИЗУ"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'SummaryLayoutControlGroup
        '
        Me.SummaryLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.SummaryLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.SummaryLayoutControlGroup.Location = New System.Drawing.Point(0, 522)
        Me.SummaryLayoutControlGroup.Name = "SummaryLayoutControlGroup"
        Me.SummaryLayoutControlGroup.Size = New System.Drawing.Size(930, 118)
        Me.SummaryLayoutControlGroup.Text = "Выводы идентификационной экспертизы<color='red'>*</color>"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SummaryMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(904, 71)
        Me.LayoutControlItem5.Text = "Выводы"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 509)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(930, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AllowHtmlStringInCaption = True
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(930, 469)
        Me.LayoutControlGroup1.Text = "Разделы Единого перечня, в отношении которых проводилась идентификационная экспер" & _
    "тиза<color='red'>*</color>"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CaptionGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 43)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(904, 379)
        Me.LayoutControlItem1.Text = "Разделы Единого перечня"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(904, 43)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'SummaryChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "SummaryChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CaptionGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
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
        ' Разделы Единого перечня выбранные для сравнительного анализа
        '
        CaptionGridView.BeginDataUpdate()
        CaptionTable.CheckClear()
        Dim Row As DataRow = Nothing
        With P.Work.LawCaptionTable
            For i As Integer = 0 To .Rows.Count - 1
                Row = CaptionTable.Rows.Find(.Rows(i)("lawId"))
                If Not Row Is Nothing Then Row("isCheck") = True
            Next
        End With
        CaptionGridView.EndDataUpdate()
        '
        ' Выводы экспертизы
        '
        SummaryMemoEdit.EditValue = C2.ToText(P.Work.ARow("summaryText"))
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        SelLawBarButtonItem.Enabled = Not bLock
        SummaryMemoEdit.Properties.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Разделы Единого перечня выбранные для сравнительного анализа
        '
        CaptionGridView.CloseEditor()
        CaptionGridView.UpdateCurrentRow()
        With P.Work.LawCaptionTable
            .Rows.Clear()
            For Each Row As DataRow In CaptionTable.Rows
                If CBool(Row("isCheck")) Then
                    .Rows.Add(New Object() {Row("lawId")})
                End If
            Next
        End With
        '
        ' Выводы экспертизы
        '
        P.Work.ARow("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsFreedom)
        P.Work.ARow("summaryText") = C2.DbText(SummaryMemoEdit.EditValue)
    End Sub

#End Region
#Region "CaptionTable"

    ''' <summary>
    ''' Таблица заголовок разделов Единого перечня (класс)
    ''' </summary>
    ''' <remarks></remarks>
    Private Class CaptionDataTable : Inherits DataTable

        ''' <summary>
        ''' New
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("lawId", GetType(Integer))         ' ID строки из tLaw
                .Add("doc", GetType(String))            ' Шифр раздела из tLaw (для сортировки)
                .Add("pos", GetType(String))            ' Номер раздела
                .Add("description", GetType(String))    ' Заголовок раздела
                .Add("isCheck", GetType(Boolean))       ' Выбран (да / нет)
            End With
            With Me.Columns("isCheck")
                .AllowDBNull = False
                .DefaultValue = False
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("lawId")}
        End Sub

        ''' <summary>
        ''' Снять все отметки
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CheckClear()
            Using V As New DataView(Me)
                V.RowFilter = "isCheck = True"
                While V.Count > 0
                    V(0)("isCheck") = False
                End While
            End Using
        End Sub

    End Class

    ''' <summary>
    ''' Таблица заголовок разделов Единого перечня (объект)
    ''' </summary>
    ''' <remarks></remarks>
    Private CaptionTable As CaptionDataTable = Nothing

#End Region


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.Summary
        CaptionTable = New CaptionDataTable
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            V.RowFilter = String.Format( _
                "areaId = {0} AND typeId = {1} AND isList = True", _
                CInt(Cprp.DxData.AreaEnum.isCustom), _
                CInt(Cprp.DxData.Law.TypeEnum.IsLevel2))
            For Each VRow As DataRowView In V
                CaptionTable.Rows.Add(New Object() {VRow("id"), VRow("doc"), VRow("pos"), VRow("description"), False})
            Next
        End Using
        CaptionGridControl.DataSource = CaptionTable
        CaptionGridView.SortInfo.Insert(0, DocCaptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckRiskGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckRiskGridColumn.Group()
    End Sub

    ' Выбрать раздел / Убрать из выборки
    Private Sub SelLawBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelLawBarButtonItem.ItemClick
        If CaptionGridView.FocusedRowHandle < 0 Then Exit Sub
        With CaptionGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        CaptionGridView.RefreshData()
    End Sub

    Private Sub CaptionGridControl_DoubleClick(sender As Object, e As EventArgs) Handles CaptionGridControl.DoubleClick
        If SelLawBarButtonItem.Enabled Then SelLawBarButtonItem.PerformClick()
    End Sub

End Class
