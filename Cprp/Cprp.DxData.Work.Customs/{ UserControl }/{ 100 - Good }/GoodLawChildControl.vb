Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > Контрольные списки"
''' </summary>
Friend Class GoodLawChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelectCountBarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents FindCountBarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents LinkBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SelectBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrevBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NextBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WordRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents WordBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents TnvedRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TnvedBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenSummaryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenLawBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl3 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LawTreeList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents PosDescriptionTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents PosDescriptionRepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents TypeIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsFindTnvedTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsFindWordTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents SummaryIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents AreaIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents SortIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodLawChildControl))
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
        Dim TreeListFormatRule1 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule2 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule3 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule4 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule5 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue5 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule6 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue6 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule7 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue7 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.TypeIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsFindTnvedTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsFindWordTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.SummaryIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.AreaIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenLawBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenSummaryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.TnvedBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.TnvedRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.WordBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.WordRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.FindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.NextBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.PrevBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SelectBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LinkBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.FindCountBarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.SelectCountBarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.StandaloneBarDockControl3 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LawTreeList = New DevExpress.XtraTreeList.TreeList()
        Me.PosDescriptionTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.PosDescriptionRepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.SortIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.DocTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TnvedRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WordRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LawTreeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PosDescriptionRepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TypeIdTreeListColumn
        '
        Me.TypeIdTreeListColumn.Caption = "TypeId"
        Me.TypeIdTreeListColumn.FieldName = "typeId"
        Me.TypeIdTreeListColumn.Name = "TypeIdTreeListColumn"
        '
        'IsFindTnvedTreeListColumn
        '
        Me.IsFindTnvedTreeListColumn.Caption = "isFind"
        Me.IsFindTnvedTreeListColumn.FieldName = "isFindTnved"
        Me.IsFindTnvedTreeListColumn.Name = "IsFindTnvedTreeListColumn"
        '
        'IsFindWordTreeListColumn
        '
        Me.IsFindWordTreeListColumn.Caption = "isWord"
        Me.IsFindWordTreeListColumn.FieldName = "isFindWord"
        Me.IsFindWordTreeListColumn.Name = "IsFindWordTreeListColumn"
        '
        'SummaryIdTreeListColumn
        '
        Me.SummaryIdTreeListColumn.Caption = "summaryId"
        Me.SummaryIdTreeListColumn.FieldName = "summaryId"
        Me.SummaryIdTreeListColumn.Name = "SummaryIdTreeListColumn"
        '
        'AreaIdTreeListColumn
        '
        Me.AreaIdTreeListColumn.Caption = "areaId"
        Me.AreaIdTreeListColumn.FieldName = "areaId"
        Me.AreaIdTreeListColumn.Name = "AreaIdTreeListColumn"
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl3)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.TnvedBarEditItem, Me.WordBarEditItem, Me.FindBarButtonItem, Me.NextBarButtonItem, Me.PrevBarButtonItem, Me.SelectBarButtonItem, Me.LinkBarButtonItem, Me.FindCountBarStaticItem, Me.SelectCountBarStaticItem, Me.OpenDataBarButtonItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarButtonItem, Me.OpenLawBarCheckItem, Me.OpenSummaryBarButtonItem, Me.OpenRiskBarButtonItem})
        Me.BarManager1.MaxItemId = 24
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.TnvedRepositoryItemTextEdit, Me.WordRepositoryItemComboBox})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(74, 163)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenSummaryBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        Me.OpenDataBarButtonItem.Id = 18
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
        Me.OpenEmbargoBarButtonItem.Id = 19
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
        Me.OpenControlBarButtonItem.Id = 20
        Me.OpenControlBarButtonItem.Name = "OpenControlBarButtonItem"
        ToolTipTitleItem4.Text = "На контроле"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к продукции на контроле"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenLawBarCheckItem
        '
        Me.OpenLawBarCheckItem.BindableChecked = True
        Me.OpenLawBarCheckItem.Caption = "ЕДИНЫЙ ПЕРЕЧЕНЬ"
        Me.OpenLawBarCheckItem.Checked = True
        Me.OpenLawBarCheckItem.Glyph = CType(resources.GetObject("OpenLawBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarCheckItem.GroupIndex = 1
        Me.OpenLawBarCheckItem.Id = 21
        Me.OpenLawBarCheckItem.Name = "OpenLawBarCheckItem"
        '
        'OpenSummaryBarButtonItem
        '
        Me.OpenSummaryBarButtonItem.Caption = "СРАВНИТЕЛЬНЫЙ АНАЛИЗ"
        Me.OpenSummaryBarButtonItem.Glyph = CType(resources.GetObject("OpenSummaryBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenSummaryBarButtonItem.Id = 22
        Me.OpenSummaryBarButtonItem.Name = "OpenSummaryBarButtonItem"
        ToolTipTitleItem5.Text = "Сравнительный анализ"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Перейти к сравнительному анализу"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.OpenSummaryBarButtonItem.SuperTip = SuperToolTip5
        '
        'OpenRiskBarButtonItem
        '
        Me.OpenRiskBarButtonItem.Caption = "РИСКИ"
        Me.OpenRiskBarButtonItem.Glyph = CType(resources.GetObject("OpenRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarButtonItem.Id = 23
        Me.OpenRiskBarButtonItem.Name = "OpenRiskBarButtonItem"
        ToolTipTitleItem6.Text = "Риски"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Перейти к рискам"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.OpenRiskBarButtonItem.SuperTip = SuperToolTip6
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
        Me.Bar2.BarName = "Контрольные списки"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(59, 219)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.TnvedBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.WordBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NextBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.PrevBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelectBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.LinkBarButtonItem, True)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Контрольные списки"
        '
        'TnvedBarEditItem
        '
        Me.TnvedBarEditItem.AutoFillWidth = True
        Me.TnvedBarEditItem.Caption = "Код(ы) ТН ВЭД"
        Me.TnvedBarEditItem.Edit = Me.TnvedRepositoryItemTextEdit
        Me.TnvedBarEditItem.Id = 6
        Me.TnvedBarEditItem.Name = "TnvedBarEditItem"
        '
        'TnvedRepositoryItemTextEdit
        '
        Me.TnvedRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.TnvedRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.TnvedRepositoryItemTextEdit.AutoHeight = False
        Me.TnvedRepositoryItemTextEdit.Name = "TnvedRepositoryItemTextEdit"
        '
        'WordBarEditItem
        '
        Me.WordBarEditItem.AutoFillWidth = True
        Me.WordBarEditItem.Caption = "Ключевые слова"
        Me.WordBarEditItem.Edit = Me.WordRepositoryItemComboBox
        Me.WordBarEditItem.Id = 7
        Me.WordBarEditItem.Name = "WordBarEditItem"
        '
        'WordRepositoryItemComboBox
        '
        Me.WordRepositoryItemComboBox.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.WordRepositoryItemComboBox.Appearance.Options.UseFont = True
        Me.WordRepositoryItemComboBox.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.WordRepositoryItemComboBox.AppearanceDropDown.Options.UseFont = True
        Me.WordRepositoryItemComboBox.AutoHeight = False
        Me.WordRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WordRepositoryItemComboBox.Name = "WordRepositoryItemComboBox"
        '
        'FindBarButtonItem
        '
        Me.FindBarButtonItem.Caption = "ПОИСК"
        Me.FindBarButtonItem.Glyph = CType(resources.GetObject("FindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FindBarButtonItem.Id = 8
        Me.FindBarButtonItem.Name = "FindBarButtonItem"
        ToolTipTitleItem7.Text = "Поиск"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Начать поиск в контрольных списках"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.FindBarButtonItem.SuperTip = SuperToolTip7
        '
        'NextBarButtonItem
        '
        Me.NextBarButtonItem.Caption = "Далее"
        Me.NextBarButtonItem.Glyph = CType(resources.GetObject("NextBarButtonItem.Glyph"), System.Drawing.Image)
        Me.NextBarButtonItem.Id = 9
        Me.NextBarButtonItem.Name = "NextBarButtonItem"
        ToolTipTitleItem8.Text = "Далее"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Перейти к следующему отмеченному пункту"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.NextBarButtonItem.SuperTip = SuperToolTip8
        '
        'PrevBarButtonItem
        '
        Me.PrevBarButtonItem.Caption = "Назад"
        Me.PrevBarButtonItem.Glyph = CType(resources.GetObject("PrevBarButtonItem.Glyph"), System.Drawing.Image)
        Me.PrevBarButtonItem.Id = 10
        Me.PrevBarButtonItem.Name = "PrevBarButtonItem"
        ToolTipTitleItem9.Text = "Назад"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Перейти к предыдущему отмеченному пункту"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.PrevBarButtonItem.SuperTip = SuperToolTip9
        '
        'SelectBarButtonItem
        '
        Me.SelectBarButtonItem.Caption = "ВЫБРАТЬ"
        Me.SelectBarButtonItem.Glyph = CType(resources.GetObject("SelectBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelectBarButtonItem.Id = 11
        Me.SelectBarButtonItem.Name = "SelectBarButtonItem"
        ToolTipTitleItem10.Text = "Выбрать"
        ToolTipItem10.LeftIndent = 6
        ToolTipItem10.Text = "Выбрать пункт для сравнительного анализа / Убрать из выборки"
        SuperToolTip10.Items.Add(ToolTipTitleItem10)
        SuperToolTip10.Items.Add(ToolTipItem10)
        Me.SelectBarButtonItem.SuperTip = SuperToolTip10
        '
        'LinkBarButtonItem
        '
        Me.LinkBarButtonItem.Caption = "Связать"
        Me.LinkBarButtonItem.Glyph = CType(resources.GetObject("LinkBarButtonItem.Glyph"), System.Drawing.Image)
        Me.LinkBarButtonItem.Id = 12
        Me.LinkBarButtonItem.Name = "LinkBarButtonItem"
        ToolTipTitleItem11.Text = "Связать"
        ToolTipItem11.LeftIndent = 6
        ToolTipItem11.Text = "Связать текущий пункт с пунктом, выбранным для сравнительного анализа"
        SuperToolTip11.Items.Add(ToolTipTitleItem11)
        SuperToolTip11.Items.Add(ToolTipItem11)
        Me.LinkBarButtonItem.SuperTip = SuperToolTip11
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 94)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(1126, 37)
        Me.StandaloneBarDockControl2.Text = "StandaloneBarDockControl2"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Результаты поиска"
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar3.FloatLocation = New System.Drawing.Point(62, 731)
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FindCountBarStaticItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SelectCountBarStaticItem)})
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.MultiLine = True
        Me.Bar3.StandaloneBarDockControl = Me.StandaloneBarDockControl3
        Me.Bar3.Text = "Результаты поиска"
        '
        'FindCountBarStaticItem
        '
        Me.FindCountBarStaticItem.Caption = "Найдено: 0"
        Me.FindCountBarStaticItem.Id = 13
        Me.FindCountBarStaticItem.Name = "FindCountBarStaticItem"
        Me.FindCountBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'SelectCountBarStaticItem
        '
        Me.SelectCountBarStaticItem.Caption = "Выбрано: 0"
        Me.SelectCountBarStaticItem.Id = 14
        Me.SelectCountBarStaticItem.Name = "SelectCountBarStaticItem"
        Me.SelectCountBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'StandaloneBarDockControl3
        '
        Me.StandaloneBarDockControl3.CausesValidation = False
        Me.StandaloneBarDockControl3.Location = New System.Drawing.Point(12, 624)
        Me.StandaloneBarDockControl3.Name = "StandaloneBarDockControl3"
        Me.StandaloneBarDockControl3.Size = New System.Drawing.Size(184, 24)
        Me.StandaloneBarDockControl3.Text = "StandaloneBarDockControl3"
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
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl3)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.LawTreeList)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1150, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LawTreeList
        '
        Me.LawTreeList.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LawTreeList.Appearance.Row.Options.UseFont = True
        Me.LawTreeList.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.PosDescriptionTreeListColumn, Me.SortIdTreeListColumn, Me.TypeIdTreeListColumn, Me.IsFindTnvedTreeListColumn, Me.IsFindWordTreeListColumn, Me.SummaryIdTreeListColumn, Me.AreaIdTreeListColumn, Me.DocTreeListColumn})
        TreeListFormatRule1.ApplyToRow = True
        TreeListFormatRule1.Column = Me.TypeIdTreeListColumn
        TreeListFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = CType(2, Short)
        TreeListFormatRule1.Rule = FormatConditionRuleValue1
        TreeListFormatRule2.ApplyToRow = True
        TreeListFormatRule2.Column = Me.TypeIdTreeListColumn
        TreeListFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = CType(4, Short)
        TreeListFormatRule2.Rule = FormatConditionRuleValue2
        TreeListFormatRule3.ApplyToRow = True
        TreeListFormatRule3.Column = Me.IsFindTnvedTreeListColumn
        TreeListFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.Azure
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue3.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = True
        TreeListFormatRule3.Rule = FormatConditionRuleValue3
        TreeListFormatRule4.ApplyToRow = True
        TreeListFormatRule4.Column = Me.IsFindWordTreeListColumn
        TreeListFormatRule4.Name = "Format3"
        FormatConditionRuleValue4.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue4.Appearance.Options.UseFont = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = True
        TreeListFormatRule4.Rule = FormatConditionRuleValue4
        TreeListFormatRule5.ApplyToRow = True
        TreeListFormatRule5.Column = Me.SummaryIdTreeListColumn
        TreeListFormatRule5.Name = "Format4"
        FormatConditionRuleValue5.Appearance.BackColor = System.Drawing.SystemColors.Info
        FormatConditionRuleValue5.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue5.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue5.Appearance.Options.UseFont = True
        FormatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue5.Value1 = CType(0, Short)
        TreeListFormatRule5.Rule = FormatConditionRuleValue5
        TreeListFormatRule6.ApplyToRow = True
        TreeListFormatRule6.Column = Me.SummaryIdTreeListColumn
        TreeListFormatRule6.Name = "Format5"
        FormatConditionRuleValue6.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue6.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue6.Appearance.Options.UseFont = True
        FormatConditionRuleValue6.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue6.Value1 = CType(2, Short)
        TreeListFormatRule6.Rule = FormatConditionRuleValue6
        TreeListFormatRule7.ApplyToRow = True
        TreeListFormatRule7.Column = Me.AreaIdTreeListColumn
        TreeListFormatRule7.Name = "Format6"
        FormatConditionRuleValue7.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue7.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue7.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue7.Value1 = CType(3, Short)
        TreeListFormatRule7.Rule = FormatConditionRuleValue7
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule1)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule2)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule3)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule4)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule5)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule6)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule7)
        Me.LawTreeList.KeyFieldName = "id"
        Me.LawTreeList.Location = New System.Drawing.Point(12, 135)
        Me.LawTreeList.Name = "LawTreeList"
        Me.LawTreeList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.LawTreeList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[True]
        Me.LawTreeList.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.[True]
        Me.LawTreeList.OptionsMenu.EnableColumnMenu = False
        Me.LawTreeList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.LawTreeList.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.LawTreeList.OptionsView.ShowColumns = False
        Me.LawTreeList.OptionsView.ShowIndicator = False
        Me.LawTreeList.ParentFieldName = "parentId"
        Me.LawTreeList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PosDescriptionRepositoryItemMemoEdit})
        Me.LawTreeList.Size = New System.Drawing.Size(1126, 485)
        Me.LawTreeList.TabIndex = 31
        '
        'PosDescriptionTreeListColumn
        '
        Me.PosDescriptionTreeListColumn.Caption = "Описание"
        Me.PosDescriptionTreeListColumn.ColumnEdit = Me.PosDescriptionRepositoryItemMemoEdit
        Me.PosDescriptionTreeListColumn.FieldName = "posDescription"
        Me.PosDescriptionTreeListColumn.Name = "PosDescriptionTreeListColumn"
        Me.PosDescriptionTreeListColumn.OptionsColumn.AllowEdit = False
        Me.PosDescriptionTreeListColumn.OptionsColumn.AllowSort = False
        Me.PosDescriptionTreeListColumn.OptionsFilter.AllowFilter = False
        Me.PosDescriptionTreeListColumn.Visible = True
        Me.PosDescriptionTreeListColumn.VisibleIndex = 0
        '
        'PosDescriptionRepositoryItemMemoEdit
        '
        Me.PosDescriptionRepositoryItemMemoEdit.Name = "PosDescriptionRepositoryItemMemoEdit"
        '
        'SortIdTreeListColumn
        '
        Me.SortIdTreeListColumn.Caption = "sortId"
        Me.SortIdTreeListColumn.FieldName = "sortId"
        Me.SortIdTreeListColumn.Name = "SortIdTreeListColumn"
        '
        'DocTreeListColumn
        '
        Me.DocTreeListColumn.Caption = "doc"
        Me.DocTreeListColumn.FieldName = "doc"
        Me.DocTreeListColumn.Name = "DocTreeListColumn"
        Me.DocTreeListColumn.SortOrder = System.Windows.Forms.SortOrder.Ascending
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.SimpleSeparator1, Me.LayoutControlItem3, Me.LayoutControlItem4})
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
        Me.CaptionSimpleLabelItem.Text = "Единый перечень"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LawTreeList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1130, 489)
        Me.LayoutControlItem1.Text = "Контрольные списки"
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
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(1130, 1)
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
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.StandaloneBarDockControl3
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 612)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1130, 28)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'GoodLawChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodLawChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TnvedRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WordRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LawTreeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PosDescriptionRepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
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
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Единый перечень", C2.ToInt(Row("rowNum")))
        '
        ' Критерии поиска в контрольных списках
        '
        Dim sTmp As String = C2.ToText(Row("studyTnved"))
        If Not C2.IsText(sTmp) Then sTmp = C2.ToText(Row("tnved"))
        TnvedBarEditItem.EditValue = sTmp
        WordBarEditItem.EditValue = C2.ToText(Row("studyWord"))
        '
        ' Список ключевых слов
        '
        If C2.IsText(sTmp) Then
            Using Dr As SqlDataReader = P.Work.ExecuteReader(String.Format( _
                "SELECT DISTINCT word FROM tGoodStudy WHERE tnved LIKE '{0}%' ORDER BY 1", sTmp.Replace("'", "''")))
                While Dr.Read
                    WordRepositoryItemComboBox.Items.Add(Dr(0).ToString)
                End While
                Dr.Close()
            End Using
        End If
        '
        ' Исследование по контрольным спискам
        '
        LawTreeList.LockReloadNodes()
        P.Work.LawDataSet.FindClear()
        P.Work.LawDataSet.SelectionClear()
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            V.RowFilter = "summaryId > 0"
            While V.Count > 0
                V(0)("lawDescription") = DBNull.Value
                V(0)("goodDescription") = DBNull.Value
                V(0)("summaryId") = 0
            End While
        End Using
        Using V As DataView = P.Work.GoodLawTable.GoodView(MyClass.GoodId)
            For Each VRow As DataRowView In V
                Row = P.Work.LawDataSet.LawTable.Rows.Find(VRow("lawId"))
                If Row Is Nothing Then Continue For
                Row("isFindTnved") = VRow("isFindTnved")
                Row("isFindCas") = VRow("isFindCas")
                Row("isFindWord") = VRow("isFindWord")
                Row("summaryId") = VRow("summaryId")
                Row("lawDescription") = VRow("lawDescription")
                Row("goodDescription") = VRow("goodDescription")
            Next
        End Using
        LawTreeList.UnlockReloadNodes()
        '
        ' Обновить результаты поиска в контрольных списках
        '
        UpdateStudyResult()
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
        ' Исследование
        '
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            P.Work.GoodLawTable.DeleteGood(MyClass.GoodId)
            V.RowFilter = "isFindTnved = True OR isFindCas = True OR isFindWord = True OR summaryId > 0"
            For Each VRow As DataRowView In V
                Row = P.Work.GoodLawTable.NewRow
                Row("goodId") = MyClass.GoodId
                Row("lawId") = VRow("id")
                Row("isFindTnved") = VRow("isFindTnved")
                Row("isFindCas") = VRow("isFindCas")
                Row("isFindWord") = VRow("isFindWord")
                Row("summaryId") = VRow("summaryId")
                Row("lawDescription") = VRow("lawDescription")
                Row("goodDescription") = VRow("goodDescription")
                P.Work.GoodLawTable.Rows.Add(Row)
            Next
            P.Work.GoodLawTable.AcceptChanges()
        End Using
        '
        ' Проверка заполненности данных
        '
        Row = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
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
        TnvedBarEditItem.Edit.ReadOnly = bLock
        WordBarEditItem.Edit.ReadOnly = bLock
        FindBarButtonItem.Enabled = Not bLock
        SelectBarButtonItem.Enabled = Not bLock
        LinkBarButtonItem.Enabled = Not bLock
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property GoodId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Таблица ошибок для проверки данных
    ''' </summary>
    Private ErrorTable As ErrorDataTable = Nothing


    ''' <summary>
    ''' Обновить результаты поиска в контрольных списках
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateStudyResult()
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            '
            ' Открыть все найденные и выбранные пункты и спозиционироваться на первом
            '
            LawTreeList.CollapseAll()
            LawTreeList.ExpandToLevel(0)
            Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            V.RowFilter = "isFindTnved = True OR isFindCas = True OR isFindWord = True OR summaryId > 0"
            V.Sort = "doc, id"
            For i As Integer = V.Count - 1 To 0 Step -1
                Node = LawTreeList.FindNodeByKeyID(V(i)("id"))
                If Node Is Nothing Then Continue For
                LawTreeList.SetFocusedNode(Node)
                Node.ExpandAll()
            Next
            '
            ' Количество найденных и выбранных пунктов
            '
            V.RowFilter = String.Format( _
                    "areaId = {0} AND (isFindTnved = True OR isFindCas = True OR isFindWord = True)", _
                    CInt(Cprp.DxData.AreaEnum.isCustom))
            FindCountBarStaticItem.Caption = String.Format("Найдено: {0} ({1})", V.Count, P.Work.LawDataSet.FindCount)
            V.RowFilter = "summaryId > 0"
            SelectCountBarStaticItem.Caption = String.Format("Выбрано: {0}", V.Count)
        End Using
    End Sub


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.GoodLaw
        LawTreeList.DataSource = P.Work.LawDataSet.LawTable
        SortIdTreeListColumn.SortIndex = 0
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
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

    ' Перейти к сравнительному анализу
    Private Sub OpenSummaryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenSummaryBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodSummary, MyClass.GoodId)
    End Sub

    ' Перейти к рискам
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodRisk, MyClass.GoodId)
    End Sub

    ' Поиск в контрольных списках
    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        '
        ' Код(ы) ТН ВЭД для поиска
        '
        Dim tnved As String = Nothing
        If Not TnvedBarEditItem.EditValue Is Nothing Then tnved = TnvedBarEditItem.EditValue.ToString
        If String.IsNullOrWhiteSpace(tnved) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажате код(ы) ТН ВЭД для поиска!", "Поиск")
            Exit Sub
        End If
        '
        ' Массив кодов ТН ВЭД для поиска
        '
        Dim tnved1 As String = tnved
        For i As Integer = 0 To tnved1.Length - 1
            If tnved1(i) = C2.FIELD_SEPARATOR Then Continue For
            If Not tnved1(i) Like "[0123456789]" Then tnved1 = tnved1.Replace(tnved(i), C2.FIELD_SEPARATOR)
        Next
        Dim arrTnved() As String = tnved1.Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
        '
        ' Ограничение длины кодов ТН ВЭД до 9-ти знаков
        '
        For i As Integer = arrTnved.GetLowerBound(0) To arrTnved.GetUpperBound(0)
            If C2.IsText(arrTnved(i)) AndAlso arrTnved(i).Length > 9 Then arrTnved(i) = arrTnved(i).Substring(0, 9)
        Next
        '
        ' Ключевые слова для поиска
        '
        Dim wordLine As String = Nothing
        If Not WordBarEditItem.EditValue Is Nothing Then wordLine = WordBarEditItem.EditValue.ToString
        If String.IsNullOrWhiteSpace(wordLine) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажате ключевые слова для поиска!", "Поиск")
            Exit Sub
        End If
        '
        ' Поиск
        '
        LawTreeList.LockReloadNodes()
        With P.Work.LawDataSet
            .FindClear()
            For i As Integer = arrTnved.GetLowerBound(0) To arrTnved.GetUpperBound(0)
                .FindByTnved(arrTnved(i), Nothing)
            Next
            .FindByWord(wordLine, Nothing)
            '
            ' Копирование описаний найденых пунктов в поле сравнительного анализа
            '
            Using V As New DataView(.LawTable)
                V.RowFilter = String.Format("typeId = {0} AND (isFindTnved = True OR isFindCas = True OR isFindWord = True)", CInt(Cprp.DxData.Law.TypeEnum.IsParagraph))
                For i As Integer = 0 To V.Count - 1
                    V(i)("lawDescription") = V(i)("posDescription")
                Next
            End Using
            .AcceptChanges()
        End With
        LawTreeList.UnlockReloadNodes()
        '
        ' Результаты поиска
        '
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Not Row Is Nothing Then
            Row("studyTnved") = tnved
            Row("studyWord") = wordLine
            Row("studyDate") = Date.Now
        End If
        UpdateStudyResult()
        MyBase.SetChangeDateNow()
        Cprp.DxCommon.Messages.ShowInformation(FindCountBarStaticItem.Caption, "Результаты поиска")
    End Sub

    ' Перейти к следующему отмеченному пункту
    Private Sub NextBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NextBarButtonItem.ItemClick
        With LawTreeList
            If .FocusedNode Is Nothing Then Exit Sub
            Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim iTmp As Integer = P.Work.LawDataSet.SelectionNextId(CInt(.GetDataRecordByNode(.FocusedNode)("id")))
            If iTmp > 0 Then Node = .FindNodeByKeyID(iTmp)
            If Node Is Nothing Then
                Cprp.DxCommon.Messages.ShowInformation("Дальше нет отмеченных пунктов.", "Результаты поиска")
            Else
                Node.ExpandAll()
                .SetFocusedNode(Node)
            End If
        End With
    End Sub

    ' Перейти к предыдущему отмеченному пункту
    Private Sub PrevBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrevBarButtonItem.ItemClick
        With LawTreeList
            If .FocusedNode Is Nothing Then Exit Sub
            Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim iTmp As Integer = P.Work.LawDataSet.SelectionPrevId(CInt(.GetDataRecordByNode(.FocusedNode)("id")))
            If iTmp > 0 Then Node = .FindNodeByKeyID(iTmp)
            If Node Is Nothing Then
                Cprp.DxCommon.Messages.ShowInformation("Дальше нет отмеченных пунктов.", "Результаты поиска")
            Else
                Node.ExpandAll()
                .SetFocusedNode(Node)
            End If
        End With
    End Sub

    ' Выбрать пункт для сравнительного анализа / Убрать из выборки
    Private Sub SelectBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelectBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        With CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView).Row
            If CType(.Item("areaId"), Cprp.DxData.AreaEnum) <> AreaEnum.isCustom Then Exit Sub
            If CType(.Item("typeId"), Cprp.DxData.Law.TypeEnum) <> DxData.Law.TypeEnum.IsParagraph Then Exit Sub
            If C2.ToInt(.Item("summaryId")) > 0 Then
                .Item("summaryId") = Cprp.DxData.Law.StudyIndexEnum.IsNothing
            Else
                .Item("summaryId") = Cprp.DxData.Law.StudyIndexEnum.IsOther
                .Item("lawDescription") = .Item("posDescription")
            End If
        End With
        LawTreeList.RefreshDataSource()
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            V.RowFilter = "summaryId > 0"
            SelectCountBarStaticItem.Caption = String.Format("Выбрано: {0}", V.Count)
        End Using
        MyBase.SetChangeDateNow()
    End Sub

    ' Связать пункт с пунктом, выбранным для сравнительного анализа
    Private Sub LinkBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LinkBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            V.RowFilter = "summaryId > 0"
            If V.Count = 0 Then
                Cprp.DxCommon.Messages.ShowWarning("Сначала выберите пункты для сравнительного анализа.")
                Exit Sub
            End If
        End Using
        With New GoodLawLinkForm(P, LawTreeList.FocusedNode.GetValue("id"))
            If .ShowDialog() = DialogResult.OK Then MyBase.SetChangeDateNow()
        End With
    End Sub

End Class
