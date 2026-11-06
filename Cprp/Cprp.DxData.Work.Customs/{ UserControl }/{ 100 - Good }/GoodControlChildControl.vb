Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > На контроле"
''' </summary>
Friend Class GoodControlChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents NotGoodBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SelGoodBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenSummaryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenLawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents InfoLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents InfoLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ControlGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ControlGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents DocNumDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents OrgNameLongGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ConNumDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RusCaptionInnGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NusCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EndCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodTnvedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodListPosGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SummaryGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodControlChildControl))
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenLawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenSummaryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.SelGoodBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.NotGoodBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ControlGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ControlGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GoodNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GoodTnvedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodListPosGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocNumDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrgNameLongGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ConNumDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RusCaptionInnGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NusCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EndCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SummaryGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InfoLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.InfoLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ControlGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ControlGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarCheckItem, Me.OpenRiskBarButtonItem, Me.SelGoodBarButtonItem, Me.NotGoodBarCheckItem, Me.OpenLawBarButtonItem, Me.OpenSummaryBarButtonItem})
        Me.BarManager1.MaxItemId = 12
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(115, 207)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenSummaryBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'OpenListBarButtonItem
        '
        Me.OpenListBarButtonItem.Caption = "Список"
        Me.OpenListBarButtonItem.Glyph = CType(resources.GetObject("OpenListBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenListBarButtonItem.Id = 2
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
        Me.OpenDataBarButtonItem.Id = 3
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
        Me.OpenEmbargoBarButtonItem.Id = 4
        Me.OpenEmbargoBarButtonItem.Name = "OpenEmbargoBarButtonItem"
        ToolTipTitleItem3.Text = "Запреты и ограничения"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Перейти к запретам и ограничениям"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.OpenEmbargoBarButtonItem.SuperTip = SuperToolTip3
        '
        'OpenControlBarCheckItem
        '
        Me.OpenControlBarCheckItem.BindableChecked = True
        Me.OpenControlBarCheckItem.Caption = "КОНТРОЛИРУЕМЫЕ"
        Me.OpenControlBarCheckItem.Checked = True
        Me.OpenControlBarCheckItem.Glyph = CType(resources.GetObject("OpenControlBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenControlBarCheckItem.GroupIndex = 1
        Me.OpenControlBarCheckItem.Id = 5
        Me.OpenControlBarCheckItem.Name = "OpenControlBarCheckItem"
        '
        'OpenLawBarButtonItem
        '
        Me.OpenLawBarButtonItem.Caption = "ЕДИНЫЙ ПЕРЕЧЕНЬ"
        Me.OpenLawBarButtonItem.Glyph = CType(resources.GetObject("OpenLawBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarButtonItem.Id = 10
        Me.OpenLawBarButtonItem.Name = "OpenLawBarButtonItem"
        ToolTipTitleItem4.Text = "Контрольные списки"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к контрольным спискам"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenLawBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenSummaryBarButtonItem
        '
        Me.OpenSummaryBarButtonItem.Caption = "СРАВНИТЕЛЬНЫЙ АНАЛИЗ"
        Me.OpenSummaryBarButtonItem.Glyph = CType(resources.GetObject("OpenSummaryBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenSummaryBarButtonItem.Id = 11
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
        Me.OpenRiskBarButtonItem.Id = 7
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
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 51)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(1126, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "На контроле"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(83, 220)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelGoodBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NotGoodBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "На контроле"
        '
        'SelGoodBarButtonItem
        '
        Me.SelGoodBarButtonItem.Caption = "Выбрать"
        Me.SelGoodBarButtonItem.Glyph = CType(resources.GetObject("SelGoodBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelGoodBarButtonItem.Id = 8
        Me.SelGoodBarButtonItem.Name = "SelGoodBarButtonItem"
        ToolTipTitleItem7.Text = "Выбрать"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Выбрать объект / Убрать из выборки"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.SelGoodBarButtonItem.SuperTip = SuperToolTip7
        '
        'NotGoodBarCheckItem
        '
        Me.NotGoodBarCheckItem.Caption = "Объект отсутствует в списке"
        Me.NotGoodBarCheckItem.Glyph = CType(resources.GetObject("NotGoodBarCheckItem.Glyph"), System.Drawing.Image)
        Me.NotGoodBarCheckItem.Id = 9
        Me.NotGoodBarCheckItem.Name = "NotGoodBarCheckItem"
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 93)
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
        Me.LayoutControl1.Controls.Add(Me.ControlGridControl)
        Me.LayoutControl1.Controls.Add(Me.InfoLabelControl)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
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
        'ControlGridControl
        '
        Me.ControlGridControl.Location = New System.Drawing.Point(12, 134)
        Me.ControlGridControl.MainView = Me.ControlGridView
        Me.ControlGridControl.Name = "ControlGridControl"
        Me.ControlGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit2, Me.RepositoryItemCheckEdit1})
        Me.ControlGridControl.Size = New System.Drawing.Size(1126, 447)
        Me.ControlGridControl.TabIndex = 34
        Me.ControlGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ControlGridView})
        '
        'ControlGridView
        '
        Me.ControlGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ControlGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ControlGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ControlGridView.Appearance.Row.Options.UseFont = True
        Me.ControlGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckGridColumn, Me.GoodNameGridColumn, Me.GoodTnvedGridColumn, Me.GoodListPosGridColumn, Me.DocNumDateGridColumn, Me.OrgNameLongGridColumn, Me.ConNumDateGridColumn, Me.RusCaptionInnGridColumn, Me.NusCaptionGridColumn, Me.EndCaptionGridColumn, Me.SummaryGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.ControlGridView.FormatRules.Add(GridFormatRule1)
        Me.ControlGridView.GridControl = Me.ControlGridControl
        Me.ControlGridView.GroupFormat = "{1}"
        Me.ControlGridView.Name = "ControlGridView"
        Me.ControlGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.ControlGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.ControlGridView.OptionsBehavior.Editable = False
        Me.ControlGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ControlGridView.OptionsCustomization.AllowFilter = False
        Me.ControlGridView.OptionsCustomization.AllowGroup = False
        Me.ControlGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ControlGridView.OptionsFind.AlwaysVisible = True
        Me.ControlGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ControlGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ControlGridView.OptionsView.ColumnAutoWidth = False
        Me.ControlGridView.OptionsView.RowAutoHeight = True
        Me.ControlGridView.OptionsView.ShowGroupPanel = False
        Me.ControlGridView.RowHeight = 25
        '
        'GoodNameGridColumn
        '
        Me.GoodNameGridColumn.Caption = "Товар"
        Me.GoodNameGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.GoodNameGridColumn.FieldName = "goodName"
        Me.GoodNameGridColumn.Name = "GoodNameGridColumn"
        Me.GoodNameGridColumn.Visible = True
        Me.GoodNameGridColumn.VisibleIndex = 1
        Me.GoodNameGridColumn.Width = 300
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'GoodTnvedGridColumn
        '
        Me.GoodTnvedGridColumn.Caption = "Код ТНВЭД"
        Me.GoodTnvedGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.GoodTnvedGridColumn.FieldName = "goodTnved"
        Me.GoodTnvedGridColumn.Name = "GoodTnvedGridColumn"
        Me.GoodTnvedGridColumn.Visible = True
        Me.GoodTnvedGridColumn.VisibleIndex = 2
        Me.GoodTnvedGridColumn.Width = 110
        '
        'GoodListPosGridColumn
        '
        Me.GoodListPosGridColumn.Caption = "Пункты списков"
        Me.GoodListPosGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.GoodListPosGridColumn.FieldName = "goodListPos"
        Me.GoodListPosGridColumn.Name = "GoodListPosGridColumn"
        Me.GoodListPosGridColumn.Visible = True
        Me.GoodListPosGridColumn.VisibleIndex = 3
        Me.GoodListPosGridColumn.Width = 300
        '
        'DocNumDateGridColumn
        '
        Me.DocNumDateGridColumn.Caption = "Заключение"
        Me.DocNumDateGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.DocNumDateGridColumn.FieldName = "docNumDate"
        Me.DocNumDateGridColumn.Name = "DocNumDateGridColumn"
        Me.DocNumDateGridColumn.Visible = True
        Me.DocNumDateGridColumn.VisibleIndex = 4
        Me.DocNumDateGridColumn.Width = 160
        '
        'OrgNameLongGridColumn
        '
        Me.OrgNameLongGridColumn.Caption = "Экспертная организация"
        Me.OrgNameLongGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.OrgNameLongGridColumn.FieldName = "orgNameLong"
        Me.OrgNameLongGridColumn.Name = "OrgNameLongGridColumn"
        Me.OrgNameLongGridColumn.Visible = True
        Me.OrgNameLongGridColumn.VisibleIndex = 5
        Me.OrgNameLongGridColumn.Width = 300
        '
        'ConNumDateGridColumn
        '
        Me.ConNumDateGridColumn.Caption = "Документ - основание"
        Me.ConNumDateGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.ConNumDateGridColumn.FieldName = "conNumDate"
        Me.ConNumDateGridColumn.Name = "ConNumDateGridColumn"
        Me.ConNumDateGridColumn.Visible = True
        Me.ConNumDateGridColumn.VisibleIndex = 6
        Me.ConNumDateGridColumn.Width = 300
        '
        'RusCaptionInnGridColumn
        '
        Me.RusCaptionInnGridColumn.Caption = "Российский участник"
        Me.RusCaptionInnGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.RusCaptionInnGridColumn.FieldName = "rusCaptionInn"
        Me.RusCaptionInnGridColumn.Name = "RusCaptionInnGridColumn"
        Me.RusCaptionInnGridColumn.Visible = True
        Me.RusCaptionInnGridColumn.VisibleIndex = 7
        Me.RusCaptionInnGridColumn.Width = 300
        '
        'NusCaptionGridColumn
        '
        Me.NusCaptionGridColumn.Caption = "Иностранный участник"
        Me.NusCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.NusCaptionGridColumn.FieldName = "nusCaption"
        Me.NusCaptionGridColumn.Name = "NusCaptionGridColumn"
        Me.NusCaptionGridColumn.Visible = True
        Me.NusCaptionGridColumn.VisibleIndex = 8
        Me.NusCaptionGridColumn.Width = 300
        '
        'EndCaptionGridColumn
        '
        Me.EndCaptionGridColumn.Caption = "Конечный пользователь"
        Me.EndCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.EndCaptionGridColumn.FieldName = "endCaption"
        Me.EndCaptionGridColumn.Name = "EndCaptionGridColumn"
        Me.EndCaptionGridColumn.Visible = True
        Me.EndCaptionGridColumn.VisibleIndex = 9
        Me.EndCaptionGridColumn.Width = 300
        '
        'SummaryGridColumn
        '
        Me.SummaryGridColumn.Caption = "Выводы экспертизы"
        Me.SummaryGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.SummaryGridColumn.FieldName = "summary"
        Me.SummaryGridColumn.Name = "SummaryGridColumn"
        Me.SummaryGridColumn.Visible = True
        Me.SummaryGridColumn.VisibleIndex = 10
        Me.SummaryGridColumn.Width = 300
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
        Me.InfoLabelControl.TabIndex = 31
        Me.InfoLabelControl.Text = "Конттролируемая продукция отсутствует"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.LayoutControlItem1, Me.SimpleSeparator1, Me.InfoLayoutControlGroup, Me.LayoutControlItem5})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1150, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 18.0!)
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseTextOptions = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(1130, 39)
        Me.CaptionSimpleLabelItem.Text = "Продукция > Объект № _"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(724, 29)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1130, 41)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 39)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1130, 41)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 80)
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
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ControlGridControl
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 122)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1130, 451)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'GoodControlChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodControlChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ControlGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ControlGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
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
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > На контроле", C2.ToInt(Row("rowNum")))
        NotGoodBarCheckItem.Checked = CBool(Row("isNotControl"))
        '
        ' Продукция на контроле
        '
        ControlGridView.BeginDataUpdate()
        Dim sTmp As String = C2.ToText(Row("tnved"))
        If Not C2.IsText(sTmp) Then sTmp = "NULL"
        MyView.RowFilter = String.Format("(goodTnved LIKE '{0}%') OR ('{0}' LIKE (goodTnved + '%'))", sTmp)
        P.Work.ControlGoodHandbookTable.CheckClear()
        If Not CBool(Row("isNotControl")) Then
            Using V As DataView = P.Work.GoodControlTable.GoodView(MyClass.GoodId)
                For Each VRow As DataRowView In V
                    Row = P.Work.ControlGoodHandbookTable.Rows.Find(VRow("controlGoodId"))
                    If Not Row Is Nothing Then Row("isCheck") = True
                Next
            End Using
        End If
        ControlGridView.EndDataUpdate()
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
        Row("isNotControl") = NotGoodBarCheckItem.Checked
        '
        ' Продукция на контроле
        '
        ControlGridView.CloseEditor()
        ControlGridView.UpdateCurrentRow()
        With P.Work.GoodControlTable
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
        Row("isCheckControl") = ErrorTable.CheckGoodControl(Row)
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
        If bNotList Then
            InfoLabelControl.Text = "Продукция на контроле отсутствует"
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
        MyBase.Content = ContentEnum.GoodControl
        MyView = New DataView(P.Work.ControlGoodHandbookTable)
        MyView.RowFilter = "goodTnved LIKE 'NULL'"
        ControlGridControl.DataSource = MyView
        ControlGridView.SortInfo.Insert(0, GoodNameGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
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

    ' Перейти к запретам и ограничениям
    Private Sub OpenEmbargoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenEmbargoBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodEmbargo, MyClass.GoodId)
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

    ' Выбрать объект / Убрать из выборки
    Private Sub SelGoodBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelGoodBarButtonItem.ItemClick
        If ControlGridView.FocusedRowHandle < 0 Then Exit Sub
        With ControlGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        ControlGridView.RefreshData()
        MyBase.SetChangeDateNow()
    End Sub

    ' Объект отсутствует в списке
    Private Sub NotGoodBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotGoodBarCheckItem.CheckedChanged
        LockUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ControlGridControl_DoubleClick(sender As Object, e As EventArgs)
        If SelGoodBarButtonItem.Enabled Then SelGoodBarButtonItem.PerformClick()
    End Sub

    Private Sub ControlGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles ControlGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

End Class
