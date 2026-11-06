Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Внешнеэкономическая сделка > Сведения о сделке"
''' </summary>
Friend Class ContractRiskChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents NotRiskBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SelRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl3 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OtherRiskMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents RiskGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents RiskGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CaptionRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents IdRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents OtherRiskLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents InfoLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContractRiskChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.SelRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.NotRiskBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl3 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.OtherRiskMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RiskGridControl = New DevExpress.XtraGrid.GridControl()
        Me.RiskGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CaptionRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.IdRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.OtherRiskLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.InfoLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.OtherRiskMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OtherRiskLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckRiskGridColumn
        '
        Me.IsCheckRiskGridColumn.Caption = "Выбран"
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
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "Не выбранно"
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl3)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenRiskBarCheckItem, Me.NotRiskBarCheckItem, Me.SelRiskBarButtonItem, Me.OpenDataBarButtonItem})
        Me.BarManager1.MaxItemId = 7
        '
        'Bar2
        '
        Me.Bar2.BarName = "Главное меню"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(63, 445)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Главное меню"
        '
        'OpenDataBarButtonItem
        '
        Me.OpenDataBarButtonItem.Caption = "РЕГИСТРАЦИОННЫЕ ДАННЫЕ"
        Me.OpenDataBarButtonItem.Glyph = CType(resources.GetObject("OpenDataBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarButtonItem.Id = 6
        Me.OpenDataBarButtonItem.Name = "OpenDataBarButtonItem"
        ToolTipTitleItem1.Text = "Регистрационные данные"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к регистрационным данным"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.OpenDataBarButtonItem.SuperTip = SuperToolTip1
        '
        'OpenRiskBarCheckItem
        '
        Me.OpenRiskBarCheckItem.BindableChecked = True
        Me.OpenRiskBarCheckItem.Caption = "РИСКИ"
        Me.OpenRiskBarCheckItem.Checked = True
        Me.OpenRiskBarCheckItem.Glyph = CType(resources.GetObject("OpenRiskBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarCheckItem.GroupIndex = 1
        Me.OpenRiskBarCheckItem.Id = 3
        Me.OpenRiskBarCheckItem.Name = "OpenRiskBarCheckItem"
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl2.Text = "StandaloneBarDockControl2"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Признаки риска"
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar3.FloatLocation = New System.Drawing.Point(76, 518)
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NotRiskBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.StandaloneBarDockControl = Me.StandaloneBarDockControl3
        Me.Bar3.Text = "Признаки риска"
        '
        'SelRiskBarButtonItem
        '
        Me.SelRiskBarButtonItem.Caption = "Выбрать"
        Me.SelRiskBarButtonItem.Glyph = CType(resources.GetObject("SelRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelRiskBarButtonItem.Id = 5
        Me.SelRiskBarButtonItem.Name = "SelRiskBarButtonItem"
        ToolTipTitleItem2.Text = "Выбрать"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Выбрать риск / Убрать из выборки"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.SelRiskBarButtonItem.SuperTip = SuperToolTip2
        '
        'NotRiskBarCheckItem
        '
        Me.NotRiskBarCheckItem.Caption = "Риски отсутствуют"
        Me.NotRiskBarCheckItem.Glyph = CType(resources.GetObject("NotRiskBarCheckItem.Glyph"), System.Drawing.Image)
        Me.NotRiskBarCheckItem.Id = 4
        Me.NotRiskBarCheckItem.Name = "NotRiskBarCheckItem"
        '
        'StandaloneBarDockControl3
        '
        Me.StandaloneBarDockControl3.CausesValidation = False
        Me.StandaloneBarDockControl3.Location = New System.Drawing.Point(12, 94)
        Me.StandaloneBarDockControl3.Name = "StandaloneBarDockControl3"
        Me.StandaloneBarDockControl3.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl3.Text = "StandaloneBarDockControl3"
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
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl3)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.OtherRiskMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.RiskGridControl)
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
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelControl1.Appearance.Image = CType(resources.GetObject("LabelControl1.Appearance.Image"), System.Drawing.Image)
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.LabelControl1.Location = New System.Drawing.Point(24, 604)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(902, 32)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 19
        Me.LabelControl1.Text = "Выберите в списке риски, выявленные по сделке. Если выявленный риск отсутствует в" & _
    " списке, опишите его в поле ""Иные риски"". Если риски отсутствуют, нажмите кнопку" & _
    " ""Риски отсутствуют"""
        '
        'OtherRiskMemoEdit
        '
        Me.OtherRiskMemoEdit.Location = New System.Drawing.Point(12, 564)
        Me.OtherRiskMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.OtherRiskMemoEdit.Name = "OtherRiskMemoEdit"
        Me.OtherRiskMemoEdit.Size = New System.Drawing.Size(902, 45)
        Me.OtherRiskMemoEdit.StyleController = Me.LayoutControl1
        Me.OtherRiskMemoEdit.TabIndex = 18
        '
        'RiskGridControl
        '
        Me.RiskGridControl.Location = New System.Drawing.Point(12, 135)
        Me.RiskGridControl.MainView = Me.RiskGridView
        Me.RiskGridControl.Name = "RiskGridControl"
        Me.RiskGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit3, Me.RepositoryItemCheckEdit1})
        Me.RiskGridControl.Size = New System.Drawing.Size(926, 413)
        Me.RiskGridControl.TabIndex = 17
        Me.RiskGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.RiskGridView})
        '
        'RiskGridView
        '
        Me.RiskGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.RiskGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RiskGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RiskGridView.Appearance.Row.Options.UseFont = True
        Me.RiskGridView.Appearance.Row.Options.UseTextOptions = True
        Me.RiskGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RiskGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RiskGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RiskGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.RiskGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.RiskGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckRiskGridColumn, Me.CaptionRiskGridColumn, Me.IdRiskGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckRiskGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.RiskGridView.FormatRules.Add(GridFormatRule1)
        Me.RiskGridView.GridControl = Me.RiskGridControl
        Me.RiskGridView.GroupFormat = "{1}"
        Me.RiskGridView.Name = "RiskGridView"
        Me.RiskGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.RiskGridView.OptionsBehavior.Editable = False
        Me.RiskGridView.OptionsCustomization.AllowColumnMoving = False
        Me.RiskGridView.OptionsCustomization.AllowFilter = False
        Me.RiskGridView.OptionsCustomization.AllowGroup = False
        Me.RiskGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.RiskGridView.OptionsCustomization.AllowSort = False
        Me.RiskGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RiskGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.RiskGridView.OptionsView.RowAutoHeight = True
        Me.RiskGridView.OptionsView.ShowGroupPanel = False
        Me.RiskGridView.RowHeight = 30
        '
        'CaptionRiskGridColumn
        '
        Me.CaptionRiskGridColumn.Caption = "Наименование риска"
        Me.CaptionRiskGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.CaptionRiskGridColumn.FieldName = "caption"
        Me.CaptionRiskGridColumn.Name = "CaptionRiskGridColumn"
        Me.CaptionRiskGridColumn.Visible = True
        Me.CaptionRiskGridColumn.VisibleIndex = 1
        Me.CaptionRiskGridColumn.Width = 174
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'IdRiskGridColumn
        '
        Me.IdRiskGridColumn.Caption = "id"
        Me.IdRiskGridColumn.FieldName = "id"
        Me.IdRiskGridColumn.Name = "IdRiskGridColumn"
        '
        'RootLayoutControlGroup
        '
        Me.RootLayoutControlGroup.AllowHtmlStringInCaption = True
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem7, Me.OtherRiskLayoutControlGroup, Me.SplitterItem2, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.SimpleSeparator1, Me.InfoLayoutControlGroup})
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
        Me.CaptionSimpleLabelItem.Text = " Внешнеэкономическая сделка > Риски"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.RiskGridControl
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(930, 417)
        Me.LayoutControlItem7.Text = "Признаки риска"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'OtherRiskLayoutControlGroup
        '
        Me.OtherRiskLayoutControlGroup.ExpandButtonVisible = True
        Me.OtherRiskLayoutControlGroup.Expanded = False
        Me.OtherRiskLayoutControlGroup.ExpandOnDoubleClick = True
        Me.OtherRiskLayoutControlGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.OtherRiskLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.OtherRiskLayoutControlGroup.Location = New System.Drawing.Point(0, 552)
        Me.OtherRiskLayoutControlGroup.Name = "OtherRiskLayoutControlGroup"
        Me.OtherRiskLayoutControlGroup.Size = New System.Drawing.Size(930, 28)
        Me.OtherRiskLayoutControlGroup.Text = "Иные риски"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.OtherRiskMemoEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(906, 49)
        Me.LayoutControlItem8.Text = "Иные признаки риска"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 540)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(930, 12)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.StandaloneBarDockControl3
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
        '
        'InfoLayoutControlGroup
        '
        Me.InfoLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.InfoLayoutControlGroup.Location = New System.Drawing.Point(0, 580)
        Me.InfoLayoutControlGroup.Name = "InfoLayoutControlGroup"
        Me.InfoLayoutControlGroup.Size = New System.Drawing.Size(930, 60)
        Me.InfoLayoutControlGroup.Text = "Информация"
        Me.InfoLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.LabelControl1
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(906, 36)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'ContractRiskUserControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ContractRiskUserControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.OtherRiskMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OtherRiskLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
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
        With P.Work.ARow
            NotRiskBarCheckItem.Checked = CBool(.Item("isNotContractRisk"))
            OtherRiskMemoEdit.EditValue = .Item("otherContractRisk")
        End With
        '
        ' Риски
        '
        RiskGridView.BeginDataUpdate()
        P.Work.RiskHandbookTable.CheckClear()
        Dim Row As DataRow = Nothing
        With P.Work.ContractRiskTable
            For i As Integer = 0 To .Rows.Count - 1
                Row = P.Work.RiskHandbookTable.Rows.Find(.Rows(i)("riskId"))
                If Not Row Is Nothing Then Row("isCheck") = True
            Next
        End With
        RiskGridView.EndDataUpdate()
        '
        ' Доступность элементов на редактирование
        '
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Данные объекта
        '
        With P.Work.ARow
            If NotRiskBarCheckItem.Checked Then
                .Item("isNotContractRisk") = True
                .Item("otherContractRisk") = DBNull.Value
            Else
                .Item("isNotContractRisk") = False
                .Item("otherContractRisk") = C2.DbText(OtherRiskMemoEdit.EditValue)
            End If
            .AcceptChanges()
        End With
        '
        ' Риски
        '
        RiskGridView.CloseEditor()
        RiskGridView.UpdateCurrentRow()
        With P.Work.ContractRiskTable
            .Rows.Clear()
            If Not NotRiskBarCheckItem.Checked Then
                For Each VRow As DataRowView In P.Work.RiskHandbookTable.ContractView
                    If CBool(VRow("isCheck")) Then
                        .Rows.Add(New Object() {VRow("id")})
                    End If
                Next
            End If
            .AcceptChanges()
        End With
    End Sub

    Private Sub LockUpdate()
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        Dim bNotRisk As Boolean = NotRiskBarCheckItem.Checked               ' Признаки риска отсутствуют
        '
        ' Элементы управления
        '
        NotRiskBarCheckItem.Enabled = Not bLock
        SelRiskBarButtonItem.Enabled = Not (bLock OrElse bNotRisk)
        OtherRiskMemoEdit.Properties.ReadOnly = bLock OrElse bNotRisk
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
        MyBase.Content = ContentEnum.ContractRisk
        RiskGridControl.DataSource = P.Work.RiskHandbookTable.ContractView
        RiskGridView.SortInfo.Insert(0, IdRiskGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckRiskGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckRiskGridColumn.Group()
        OtherRiskLayoutControlGroup.Expanded = True
    End Sub

    ' Перейти к регистрационным данным
    Private Sub OpenDataBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenDataBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.ContractData, C2.EMPTY_ID)
    End Sub

    ' Выбрать признак риска / Убрать из выборки
    Private Sub SelRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelRiskBarButtonItem.ItemClick
        If RiskGridView.FocusedRowHandle < 0 Then Exit Sub
        With RiskGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        RiskGridView.RefreshData()
        MyBase.SetChangeDateNow()
    End Sub

    ' Признаки риска отсутствуют
    Private Sub NotRiskBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotRiskBarCheckItem.CheckedChanged
        LockUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub RiskGridControl_DoubleClick(sender As Object, e As EventArgs) Handles RiskGridControl.DoubleClick
        If SelRiskBarButtonItem.Enabled Then SelRiskBarButtonItem.PerformClick()
    End Sub

    Private Sub RiskGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles RiskGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

End Class
