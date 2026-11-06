Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > Запреты и ограничения"
''' </summary>
Friend Class GoodEmbargoChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents DocOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NotGoodBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SelGoodBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenSummaryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenLawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents InfoLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EmbargoGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents EmbargoGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GoodCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents EmbargoCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents InfoLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodEmbargoChildControl))
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
        Me.IsCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenEmbargoBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenLawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenSummaryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.SelGoodBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.NotGoodBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.DocOpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.InfoLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.EmbargoGridControl = New DevExpress.XtraGrid.GridControl()
        Me.EmbargoGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GoodCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.EmbargoCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.InfoLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.EmbargoGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmbargoGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckGridColumn
        '
        Me.IsCheckGridColumn.Caption = "Выбрано"
        Me.IsCheckGridColumn.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IsCheckGridColumn.FieldName = "isCheck"
        Me.IsCheckGridColumn.Name = "IsCheckGridColumn"
        Me.IsCheckGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckGridColumn.Visible = True
        Me.IsCheckGridColumn.VisibleIndex = 0
        Me.IsCheckGridColumn.Width = 60
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
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenEmbargoBarCheckItem, Me.NotGoodBarCheckItem, Me.SelGoodBarButtonItem, Me.DocOpenBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenControlBarButtonItem, Me.OpenRiskBarButtonItem, Me.OpenLawBarButtonItem, Me.OpenSummaryBarButtonItem})
        Me.BarManager1.MaxItemId = 16
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(58, 183)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenSummaryBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        Me.OpenDataBarButtonItem.Id = 10
        Me.OpenDataBarButtonItem.Name = "OpenDataBarButtonItem"
        ToolTipTitleItem2.Text = "Регистрационные данные"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Перейти к регистрационным данным"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.OpenDataBarButtonItem.SuperTip = SuperToolTip2
        '
        'OpenEmbargoBarCheckItem
        '
        Me.OpenEmbargoBarCheckItem.BindableChecked = True
        Me.OpenEmbargoBarCheckItem.Caption = "ЗАПРЕТЫ И ОГРАНИЧЕНИЯ"
        Me.OpenEmbargoBarCheckItem.Checked = True
        Me.OpenEmbargoBarCheckItem.Glyph = CType(resources.GetObject("OpenEmbargoBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenEmbargoBarCheckItem.GroupIndex = 1
        Me.OpenEmbargoBarCheckItem.Id = 3
        Me.OpenEmbargoBarCheckItem.Name = "OpenEmbargoBarCheckItem"
        '
        'OpenControlBarButtonItem
        '
        Me.OpenControlBarButtonItem.Caption = "НА КОНТРОЛЕ"
        Me.OpenControlBarButtonItem.Glyph = CType(resources.GetObject("OpenControlBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenControlBarButtonItem.Id = 11
        Me.OpenControlBarButtonItem.Name = "OpenControlBarButtonItem"
        ToolTipTitleItem3.Text = "На контроле"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Перейти к продукции на контроле"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip3
        '
        'OpenLawBarButtonItem
        '
        Me.OpenLawBarButtonItem.Caption = "ЕДИНЫЙ ПЕРЕЧЕНЬ"
        Me.OpenLawBarButtonItem.Glyph = CType(resources.GetObject("OpenLawBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarButtonItem.Id = 14
        Me.OpenLawBarButtonItem.Name = "OpenLawBarButtonItem"
        ToolTipTitleItem4.Text = "Единый перечень"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к Единому перечню"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenLawBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenSummaryBarButtonItem
        '
        Me.OpenSummaryBarButtonItem.Caption = "СРАВНИТЕЛЬНЫЙ АНАЛИЗ"
        Me.OpenSummaryBarButtonItem.Glyph = CType(resources.GetObject("OpenSummaryBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenSummaryBarButtonItem.Id = 15
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
        Me.OpenRiskBarButtonItem.Id = 13
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
        Me.Bar2.BarName = "Запреты и ограничения"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(64, 213)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelGoodBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NotGoodBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DocOpenBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Запреты и ограничения"
        '
        'SelGoodBarButtonItem
        '
        Me.SelGoodBarButtonItem.Caption = "Выбрать"
        Me.SelGoodBarButtonItem.Glyph = CType(resources.GetObject("SelGoodBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelGoodBarButtonItem.Id = 7
        Me.SelGoodBarButtonItem.Name = "SelGoodBarButtonItem"
        ToolTipTitleItem7.Text = "Выбрать"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Выбрать лицо / Убрать из выборки"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.SelGoodBarButtonItem.SuperTip = SuperToolTip7
        '
        'NotGoodBarCheckItem
        '
        Me.NotGoodBarCheckItem.Caption = "Объект отстутствует в списке"
        Me.NotGoodBarCheckItem.Glyph = CType(resources.GetObject("NotGoodBarCheckItem.Glyph"), System.Drawing.Image)
        Me.NotGoodBarCheckItem.Id = 6
        Me.NotGoodBarCheckItem.Name = "NotGoodBarCheckItem"
        '
        'DocOpenBarButtonItem
        '
        Me.DocOpenBarButtonItem.Caption = "Документ"
        Me.DocOpenBarButtonItem.Glyph = CType(resources.GetObject("DocOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocOpenBarButtonItem.Id = 8
        Me.DocOpenBarButtonItem.Name = "DocOpenBarButtonItem"
        ToolTipTitleItem8.Text = "Документ"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Открыть документ"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.DocOpenBarButtonItem.SuperTip = SuperToolTip8
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
        Me.LayoutControl1.Controls.Add(Me.InfoLabelControl)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.EmbargoGridControl)
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
        'InfoLabelControl
        '
        Me.InfoLabelControl.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InfoLabelControl.Appearance.Image = CType(resources.GetObject("InfoLabelControl.Appearance.Image"), System.Drawing.Image)
        Me.InfoLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.InfoLabelControl.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.InfoLabelControl.Location = New System.Drawing.Point(24, 597)
        Me.InfoLabelControl.Name = "InfoLabelControl"
        Me.InfoLabelControl.Size = New System.Drawing.Size(1102, 29)
        Me.InfoLabelControl.StyleController = Me.LayoutControl1
        Me.InfoLabelControl.TabIndex = 27
        Me.InfoLabelControl.Text = "Запреты и ограничения отсутствуют"
        '
        'EmbargoGridControl
        '
        Me.EmbargoGridControl.Location = New System.Drawing.Point(12, 135)
        Me.EmbargoGridControl.MainView = Me.EmbargoGridView
        Me.EmbargoGridControl.Name = "EmbargoGridControl"
        Me.EmbargoGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryItemCheckEdit1})
        Me.EmbargoGridControl.Size = New System.Drawing.Size(1126, 446)
        Me.EmbargoGridControl.TabIndex = 24
        Me.EmbargoGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.EmbargoGridView})
        '
        'EmbargoGridView
        '
        Me.EmbargoGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.EmbargoGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.EmbargoGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.EmbargoGridView.Appearance.Row.Options.UseFont = True
        Me.EmbargoGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.EmbargoGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.EmbargoGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.EmbargoGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.EmbargoGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckGridColumn, Me.GoodCaptionGridColumn, Me.EmbargoCaptionGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.EmbargoGridView.FormatRules.Add(GridFormatRule1)
        Me.EmbargoGridView.GridControl = Me.EmbargoGridControl
        Me.EmbargoGridView.GroupFormat = "{1}"
        Me.EmbargoGridView.Name = "EmbargoGridView"
        Me.EmbargoGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.EmbargoGridView.OptionsBehavior.Editable = False
        Me.EmbargoGridView.OptionsCustomization.AllowColumnMoving = False
        Me.EmbargoGridView.OptionsCustomization.AllowFilter = False
        Me.EmbargoGridView.OptionsCustomization.AllowGroup = False
        Me.EmbargoGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.EmbargoGridView.OptionsFind.AlwaysVisible = True
        Me.EmbargoGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.EmbargoGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.EmbargoGridView.OptionsView.RowAutoHeight = True
        Me.EmbargoGridView.OptionsView.ShowGroupPanel = False
        Me.EmbargoGridView.RowHeight = 25
        '
        'GoodCaptionGridColumn
        '
        Me.GoodCaptionGridColumn.Caption = "Наименование"
        Me.GoodCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GoodCaptionGridColumn.FieldName = "goodCaption"
        Me.GoodCaptionGridColumn.Name = "GoodCaptionGridColumn"
        Me.GoodCaptionGridColumn.Visible = True
        Me.GoodCaptionGridColumn.VisibleIndex = 1
        Me.GoodCaptionGridColumn.Width = 174
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'EmbargoCaptionGridColumn
        '
        Me.EmbargoCaptionGridColumn.Caption = "Основание"
        Me.EmbargoCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.EmbargoCaptionGridColumn.FieldName = "embargoCaption"
        Me.EmbargoCaptionGridColumn.Name = "EmbargoCaptionGridColumn"
        Me.EmbargoCaptionGridColumn.Visible = True
        Me.EmbargoCaptionGridColumn.VisibleIndex = 2
        Me.EmbargoCaptionGridColumn.Width = 174
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.InfoLayoutControlGroup})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
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
        Me.CaptionSimpleLabelItem.Text = "Запреты и ограничения"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.EmbargoGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1130, 450)
        Me.LayoutControlItem1.Text = "Список лиц"
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
        'InfoLayoutControlGroup
        '
        Me.InfoLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.InfoLayoutControlGroup.Location = New System.Drawing.Point(0, 573)
        Me.InfoLayoutControlGroup.Name = "InfoLayoutControlGroup"
        Me.InfoLayoutControlGroup.Size = New System.Drawing.Size(1130, 57)
        Me.InfoLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.InfoLabelControl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1106, 33)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'GoodEmbargoChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodEmbargoChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.EmbargoGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmbargoGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
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
        ' Элементы управления
        '
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Запреты и ограничения", C2.ToInt(Row("rowNum")))
        NotGoodBarCheckItem.Checked = CBool(Row("isNotEmbargo"))
        '
        ' Запреты и ограничения
        '
        EmbargoGridView.BeginDataUpdate()
        MyView.RowFilter = String.Format("countryId = {0}", C2.ToInt(P.Work.ARow("countryId")))
        P.Work.EmbargoGoodHandbookTable.CheckClear()
        If Not CBool(Row("isNotEmbargo")) Then
            Using V As DataView = P.Work.GoodEmbargoTable.GoodView(MyClass.GoodId)
                For Each VRow As DataRowView In V
                    Row = P.Work.EmbargoGoodHandbookTable.Rows.Find(VRow("embargoGoodId"))
                    If Not Row Is Nothing Then Row("isCheck") = True
                Next
            End Using
        End If
        EmbargoGridView.EndDataUpdate()
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
        ' Данные объекта
        '
        Row("isNotEmbargo") = NotGoodBarCheckItem.Checked
        '
        ' Запреты и ограничения
        '
        EmbargoGridView.CloseEditor()
        EmbargoGridView.UpdateCurrentRow()
        With P.Work.GoodEmbargoTable
            .DeleteGood(MyClass.GoodId)
            If Not NotGoodBarCheckItem.Checked Then
                For Each VRow As DataRowView In MyView
                    If CBool(VRow("isCheck")) Then
                        .Rows.Add(New Object() {MyClass.GoodId, VRow("id")})
                    End If
                Next
            End If
            .AcceptChanges()
        End With
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckEmbargo") = ErrorTable.CheckGoodEmbargo(Row)
        P.Work.GoodTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        Dim bNotGood As Boolean = NotGoodBarCheckItem.Checked               ' Объект отсутствует в списке
        Dim bNotList As Boolean = (MyView.Count = 0)                        ' Список пуст
        '
        ' Элементы управления
        '
        SelGoodBarButtonItem.Enabled = Not (bLock OrElse bNotGood OrElse bNotList)
        NotGoodBarCheckItem.Enabled = Not (bLock OrElse bNotList)
        DocOpenBarButtonItem.Enabled = Not bNotList
        If bNotList Then
            InfoLabelControl.Text = "Запреты и ограничения отсутствуют"
        Else
            InfoLabelControl.Text = "Выделите в списке продукцию, которой соответствует объект экспертизы. Если соответствующая продукция отсутствует, нажмите кнопку ""Объект отсутствует в списке"""
        End If
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property GoodId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Представление запретов и ограничений отфильтрованных по стране объекта
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
        MyBase.Content = ContentEnum.GoodEmbargo
        MyView = New DataView(P.Work.EmbargoGoodHandbookTable)
        MyView.RowFilter = "countryId IS NULL"
        EmbargoGridControl.DataSource = MyView
        EmbargoGridView.SortInfo.Insert(0, GoodCaptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckGridColumn.Group()
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

    ' Перейти к продукции на контроле
    Private Sub OpenControlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenControlBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodControl, MyClass.GoodId)
    End Sub

    ' Перейти к контрольным спискам
    Private Sub OpenLawBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenLawBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodLaw, MyClass.GoodId)
    End Sub

    ' Перейти к сравнительному анализу
    Private Sub OpenSummaryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenSummaryBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodSummary, MyClass.GoodId)
    End Sub

    ' Перейти к признакам риска
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodRisk, MyClass.GoodId)
    End Sub

    ' Выбрать запрет / Убрать из выборки
    Private Sub SelGoodBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelGoodBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        With EmbargoGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        EmbargoGridView.RefreshData()
        MyBase.SetChangeDateNow()
    End Sub

    ' Объект отсутствует в списке
    Private Sub NotGoodBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotGoodBarCheckItem.CheckedChanged
        LockUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub EmbargoGridControl_DoubleClick(sender As Object, e As EventArgs) Handles EmbargoGridControl.DoubleClick
        If SelGoodBarButtonItem.Enabled Then SelGoodBarButtonItem.PerformClick()
    End Sub

    Private Sub EmbargoGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles EmbargoGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

End Class
