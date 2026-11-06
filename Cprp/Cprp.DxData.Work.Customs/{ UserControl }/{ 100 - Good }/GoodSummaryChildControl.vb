Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > Сравнительный анализ"
''' </summary>
Friend Class GoodSummaryChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelectBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenSummaryBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenLawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SummaryMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents DescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SummaryGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents SummaryGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LawDescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents GoodDescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SummaryIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsFindTnvedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents BottomTabbedControlGroup As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents SummaryLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodSummaryChildControl))
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsFindTnvedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SummaryIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenLawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenSummaryBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.SelectBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SummaryMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.DescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.SummaryGridControl = New DevExpress.XtraGrid.GridControl()
        Me.SummaryGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LawDescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GoodDescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.BottomTabbedControlGroup = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.SummaryLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DescriptionLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SummaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomTabbedControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsFindTnvedGridColumn
        '
        Me.IsFindTnvedGridColumn.Caption = "isFindTnved"
        Me.IsFindTnvedGridColumn.FieldName = "isFindTnved"
        Me.IsFindTnvedGridColumn.Name = "IsFindTnvedGridColumn"
        '
        'SummaryIdGridColumn
        '
        Me.SummaryIdGridColumn.Caption = "summaryId"
        Me.SummaryIdGridColumn.FieldName = "summaryId"
        Me.SummaryIdGridColumn.Name = "SummaryIdGridColumn"
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.SelectBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarButtonItem, Me.OpenLawBarButtonItem, Me.OpenSummaryBarCheckItem, Me.OpenRiskBarButtonItem})
        Me.BarManager1.MaxItemId = 14
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(65, 155)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenSummaryBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'OpenListBarButtonItem
        '
        Me.OpenListBarButtonItem.Caption = "Список"
        Me.OpenListBarButtonItem.Glyph = CType(resources.GetObject("OpenListBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenListBarButtonItem.Id = 0
        Me.OpenListBarButtonItem.Name = "OpenListBarButtonItem"
        ToolTipTitleItem1.Text = "Список"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к списку объектов"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.OpenListBarButtonItem.SuperTip = SuperToolTip1
        '
        'OpenDataBarButtonItem
        '
        Me.OpenDataBarButtonItem.Caption = "РЕГИСТРАЦИОННЫЕ ДАННЫЕ"
        Me.OpenDataBarButtonItem.Glyph = CType(resources.GetObject("OpenDataBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarButtonItem.Id = 8
        Me.OpenDataBarButtonItem.Name = "OpenDataBarButtonItem"
        ToolTipTitleItem2.Text = "Регистрационные данные"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Перейти к регистрационным данным"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.OpenDataBarButtonItem.SuperTip = SuperToolTip2
        '
        'OpenEmbargoBarButtonItem
        '
        Me.OpenEmbargoBarButtonItem.Caption = "ЗАПРЕТЫ И ОГРАНИЧЕНИЯ"
        Me.OpenEmbargoBarButtonItem.Glyph = CType(resources.GetObject("OpenEmbargoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenEmbargoBarButtonItem.Id = 9
        Me.OpenEmbargoBarButtonItem.Name = "OpenEmbargoBarButtonItem"
        ToolTipTitleItem3.Text = "Запреты и ограничения"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Перейти к запретам и ограничениям"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.OpenEmbargoBarButtonItem.SuperTip = SuperToolTip3
        '
        'OpenControlBarButtonItem
        '
        Me.OpenControlBarButtonItem.Caption = "НА КОНТРОЛЕ"
        Me.OpenControlBarButtonItem.Glyph = CType(resources.GetObject("OpenControlBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenControlBarButtonItem.Id = 10
        Me.OpenControlBarButtonItem.Name = "OpenControlBarButtonItem"
        ToolTipTitleItem4.Text = "На контроле"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к продукции на контроле"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenLawBarButtonItem
        '
        Me.OpenLawBarButtonItem.Caption = "ЕДИНЫЙ ПЕРЕЧЕНЬ"
        Me.OpenLawBarButtonItem.Glyph = CType(resources.GetObject("OpenLawBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarButtonItem.Id = 11
        Me.OpenLawBarButtonItem.Name = "OpenLawBarButtonItem"
        ToolTipTitleItem5.Text = "Единый перечень"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Перейти к Единому перечню"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.OpenLawBarButtonItem.SuperTip = SuperToolTip5
        '
        'OpenSummaryBarCheckItem
        '
        Me.OpenSummaryBarCheckItem.BindableChecked = True
        Me.OpenSummaryBarCheckItem.Caption = "СРАВНИТЕЛЬНЫЙ АНАЛИЗ"
        Me.OpenSummaryBarCheckItem.Checked = True
        Me.OpenSummaryBarCheckItem.Glyph = CType(resources.GetObject("OpenSummaryBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenSummaryBarCheckItem.GroupIndex = 1
        Me.OpenSummaryBarCheckItem.Id = 12
        Me.OpenSummaryBarCheckItem.Name = "OpenSummaryBarCheckItem"
        ToolTipTitleItem6.Text = "Сравнительный анализ"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Перейти к сравнительному анализу"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.OpenSummaryBarCheckItem.SuperTip = SuperToolTip6
        '
        'OpenRiskBarButtonItem
        '
        Me.OpenRiskBarButtonItem.Caption = "РИСКИ"
        Me.OpenRiskBarButtonItem.Glyph = CType(resources.GetObject("OpenRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarButtonItem.Id = 13
        Me.OpenRiskBarButtonItem.Name = "OpenRiskBarButtonItem"
        ToolTipTitleItem7.Text = "Риски"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Перейти к рискам"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.OpenRiskBarButtonItem.SuperTip = SuperToolTip7
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(1126, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Сравнительный анализ"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(57, 215)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelectBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Сравнительный анализ"
        '
        'SelectBarButtonItem
        '
        Me.SelectBarButtonItem.Caption = "СООТВЕТСТВУЕТ"
        Me.SelectBarButtonItem.Glyph = CType(resources.GetObject("SelectBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelectBarButtonItem.Id = 4
        Me.SelectBarButtonItem.Name = "SelectBarButtonItem"
        ToolTipTitleItem8.Text = "Соответствует"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Отметить пункт как соответствующий объекту экспертизы / Снять отметку"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.SelectBarButtonItem.SuperTip = SuperToolTip8
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 94)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(1126, 37)
        Me.StandaloneBarDockControl2.Text = "StandaloneBarDockControl2"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1150, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 650)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1150, 0)
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
        Me.barDockControlRight.Location = New System.Drawing.Point(1150, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 650)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.SummaryMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.DescriptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.SummaryGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(530, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1150, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SummaryMemoEdit
        '
        Me.SummaryMemoEdit.Location = New System.Drawing.Point(24, 525)
        Me.SummaryMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.SummaryMemoEdit.Name = "SummaryMemoEdit"
        Me.SummaryMemoEdit.Size = New System.Drawing.Size(1102, 111)
        Me.SummaryMemoEdit.StyleController = Me.LayoutControl1
        Me.SummaryMemoEdit.TabIndex = 2
        '
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(24, 525)
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.DescriptionMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.DescriptionMemoEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(1102, 111)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 1
        '
        'SummaryGridControl
        '
        Me.SummaryGridControl.Location = New System.Drawing.Point(12, 135)
        Me.SummaryGridControl.MainView = Me.SummaryGridView
        Me.SummaryGridControl.Name = "SummaryGridControl"
        Me.SummaryGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.SummaryGridControl.Size = New System.Drawing.Size(1126, 336)
        Me.SummaryGridControl.TabIndex = 0
        Me.SummaryGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SummaryGridView})
        '
        'SummaryGridView
        '
        Me.SummaryGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.SummaryGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SummaryGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SummaryGridView.Appearance.Row.Options.UseFont = True
        Me.SummaryGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.LawDescriptionGridColumn, Me.GoodDescriptionGridColumn, Me.SummaryIdGridColumn, Me.IsFindTnvedGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsFindTnvedGridColumn
        GridFormatRule1.Name = "Format1"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Azure
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.SummaryIdGridColumn
        GridFormatRule2.Name = "Format2"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.SystemColors.Info
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = CType(0, Short)
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.ApplyToRow = True
        GridFormatRule3.Column = Me.SummaryIdGridColumn
        GridFormatRule3.Name = "Format3"
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = CType(2, Short)
        GridFormatRule3.Rule = FormatConditionRuleValue3
        Me.SummaryGridView.FormatRules.Add(GridFormatRule1)
        Me.SummaryGridView.FormatRules.Add(GridFormatRule2)
        Me.SummaryGridView.FormatRules.Add(GridFormatRule3)
        Me.SummaryGridView.GridControl = Me.SummaryGridControl
        Me.SummaryGridView.Name = "SummaryGridView"
        Me.SummaryGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.SummaryGridView.OptionsCustomization.AllowColumnMoving = False
        Me.SummaryGridView.OptionsCustomization.AllowFilter = False
        Me.SummaryGridView.OptionsCustomization.AllowGroup = False
        Me.SummaryGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.SummaryGridView.OptionsCustomization.AllowSort = False
        Me.SummaryGridView.OptionsDetail.EnableMasterViewMode = False
        Me.SummaryGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SummaryGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.SummaryGridView.OptionsView.RowAutoHeight = True
        Me.SummaryGridView.OptionsView.ShowDetailButtons = False
        Me.SummaryGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.SummaryGridView.OptionsView.ShowGroupPanel = False
        Me.SummaryGridView.RowHeight = 25
        '
        'LawDescriptionGridColumn
        '
        Me.LawDescriptionGridColumn.Caption = "Описание позиции (пункта)"
        Me.LawDescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.LawDescriptionGridColumn.FieldName = "lawDescription"
        Me.LawDescriptionGridColumn.Name = "LawDescriptionGridColumn"
        Me.LawDescriptionGridColumn.OptionsColumn.AllowEdit = False
        Me.LawDescriptionGridColumn.Visible = True
        Me.LawDescriptionGridColumn.VisibleIndex = 0
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'GoodDescriptionGridColumn
        '
        Me.GoodDescriptionGridColumn.Caption = "Характеристики объекта"
        Me.GoodDescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GoodDescriptionGridColumn.FieldName = "goodDescription"
        Me.GoodDescriptionGridColumn.Name = "GoodDescriptionGridColumn"
        Me.GoodDescriptionGridColumn.Visible = True
        Me.GoodDescriptionGridColumn.VisibleIndex = 1
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.SplitterItem1, Me.BottomTabbedControlGroup})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1150, 650)
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
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(1130, 40)
        Me.CaptionSimpleLabelItem.Text = "Сравнительный анализ"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SummaryGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1130, 340)
        Me.LayoutControlItem1.Text = "Сравнительный анализ"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1130, 41)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1130, 41)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(1130, 1)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 463)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(1130, 12)
        '
        'BottomTabbedControlGroup
        '
        Me.BottomTabbedControlGroup.Location = New System.Drawing.Point(0, 475)
        Me.BottomTabbedControlGroup.Name = "BottomTabbedControlGroup"
        Me.BottomTabbedControlGroup.SelectedTabPage = Me.SummaryLayoutControlGroup
        Me.BottomTabbedControlGroup.SelectedTabPageIndex = 0
        Me.BottomTabbedControlGroup.Size = New System.Drawing.Size(1130, 165)
        Me.BottomTabbedControlGroup.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.SummaryLayoutControlGroup, Me.DescriptionLayoutControlGroup})
        '
        'SummaryLayoutControlGroup
        '
        Me.SummaryLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.SummaryLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.SummaryLayoutControlGroup.Name = "SummaryLayoutControlGroup"
        Me.SummaryLayoutControlGroup.Size = New System.Drawing.Size(1106, 115)
        Me.SummaryLayoutControlGroup.Text = "Общий анализ выявленных пунктов контрольных списков"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SummaryMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1106, 115)
        Me.LayoutControlItem5.Text = "Общий анализ выявленных пунктов"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'DescriptionLayoutControlGroup
        '
        Me.DescriptionLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.DescriptionLayoutControlGroup.Name = "DescriptionLayoutControlGroup"
        Me.DescriptionLayoutControlGroup.Size = New System.Drawing.Size(1106, 115)
        Me.DescriptionLayoutControlGroup.Text = "Техническое описание объекта экспертизы"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DescriptionMemoEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1106, 115)
        Me.LayoutControlItem4.Text = "Описание объекта экспертизы"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'GoodSummaryChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodSummaryChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SummaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomTabbedControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Строка таблицы объектов экспертизы
        '
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        '
        ' Заголовок элемента управления
        '
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Сравнительный анализ", C2.ToInt(Row("rowNum")))
        '
        ' Элементы управления
        '
        SummaryMemoEdit.EditValue = Row("studySummary")
        DescriptionMemoEdit.EditValue = Row("description")
        '
        ' Строка id ПУНКТОВ КОНТРОЛЬНЫХ СПИСКОВ, выявленных по объекту экспертизы
        '
        Dim sTmp As String = "0"
        Using V As DataView = P.Work.GoodLawTable.GoodView(MyClass.GoodId)
            For Each VRow As DataRowView In V
                Row = P.Work.LawDataSet.LawTable.Rows.Find(VRow("lawId"))
                If Row Is Nothing Then Continue For
                If CType(Row("areaId"), Cprp.DxData.AreaEnum) <> AreaEnum.isCustom Then Continue For
                If CType(Row("typeId"), Cprp.DxData.Law.TypeEnum) <> Law.TypeEnum.IsParagraph Then Continue For
                sTmp = String.Format("{0}, {1}", sTmp, CInt(Row("id")))
            Next
        End Using
        '
        ' Представление со сравнительным анализом активного объекта
        '
        MyView.RowFilter = String.Format("goodId = {0} AND lawId IN ({1})", MyClass.GoodId, sTmp)
        '
        ' Доступность элементов управления на редактирование
        '
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Строка таблицы объектов экспертизы
        '
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        '
        ' Сравнительный анализ
        '
        SummaryGridView.CloseEditor()
        SummaryGridView.UpdateCurrentRow()
        '
        ' Данные объекта 
        '
        Row("studySummary") = C2.DbText(SummaryMemoEdit.EditValue)
        Row("description") = C2.DbText(DescriptionMemoEdit.EditValue)
        '
        ' Идентификатор результатов исследования, удаление описаний невыбранных пунктов КС из источника данных
        '
        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        For Each VRow As DataRowView In MyView
            iTmp1 = CInt(VRow("summaryId"))
            If iTmp1 > iTmp Then iTmp = iTmp1
        Next
        Row("studySummaryId") = iTmp
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckStudy") = ErrorTable.CheckGoodSummary(Row)
        P.Work.GoodTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        '
        ' Элементы управления
        '
        SelectBarButtonItem.Enabled = Not bLock
        SummaryGridView.OptionsBehavior.ReadOnly = bLock
        SummaryMemoEdit.ReadOnly = bLock
        DescriptionMemoEdit.ReadOnly = bLock
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property GoodId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Представление со сравнительным анализом объекта
    ''' </summary>
    ''' <remarks></remarks>
    Private MyView As DataView = Nothing

    ''' <summary>
    ''' Таблица ошибок для проверки данных
    ''' </summary>
    Private ErrorTable As ErrorDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.GoodSummary
        MyView = New DataView(P.Work.GoodLawTable)
        MyView.RowFilter = "goodId IS NULL"
        SummaryGridControl.DataSource = MyView
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
    End Sub

    Private Sub SummaryGridView_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles SummaryGridView.CustomDrawCell
        Dim sTmp As String = Nothing
        If Not (e.CellValue Is Nothing OrElse IsDBNull(e.CellValue)) Then sTmp = e.CellValue.ToString
        If Not String.IsNullOrEmpty(sTmp) Then Exit Sub
        Select Case e.Column.FieldName
            Case "lawDescription", "goodDescription"
                e.DisplayText = "[обязательное поле]"
                e.Appearance.ForeColor = Drawing.SystemColors.InactiveCaptionText
        End Select
    End Sub

    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodList, MyClass.GoodId)
    End Sub

    ' Перейти к регистрационным данным
    Private Sub OpenDataBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenDataBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodData, MyClass.GoodId)
    End Sub

    ' Перейти к запретам и ограничениям
    Private Sub OpenEmbargoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenEmbargoBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodEmbargo, MyClass.GoodId)
    End Sub

    ' Перейти к продукции на контроле
    Private Sub OpenControlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenControlBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodControl, MyClass.GoodId)
    End Sub

    ' Перейти к контрольным спискам
    Private Sub OpenLawBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenLawBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodLaw, MyClass.GoodId)
    End Sub

    ' Перейти к рискам
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodRisk, MyClass.GoodId)
    End Sub

    ' Отметить пункт как соответствующий объекту экспертизы / Снять отметку
    Private Sub SelectBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelectBarButtonItem.ItemClick
        If SummaryGridView.FocusedRowHandle < 0 Then Exit Sub
        With SummaryGridView.GetFocusedDataRow
            .Item("summaryId") = If(CInt(.Item("summaryId")) > 1, 1, 2)
        End With
        SummaryGridControl.RefreshDataSource()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub SummaryGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles SummaryGridView.CellValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub SummaryMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SummaryMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DescriptionMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DescriptionMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
