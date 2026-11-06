Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > Регистрационные данные"
''' </summary>
Friend Class GoodDataChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenSummaryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenLawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents UsedMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents AreaMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents CasTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TnvedTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NotNameDecCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TypeLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents NameDecTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NameConTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AreaLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UsedLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents RegDataLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem3 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ParentButtonEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents GoodFindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GoodClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents ChildLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UnrealCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodDataChildControl))
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenLawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenSummaryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.GoodFindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.UnrealCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.ChildLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.ParentButtonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.DescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.UsedMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.AreaMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.CasTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.TnvedTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.NotNameDecCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.TypeLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.NameDecTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.NameConTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.AreaLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.UsedLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DescriptionLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.RegDataLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem3 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.UnrealCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChildLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParentButtonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsedMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreaMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CasTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TnvedTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotNameDecCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NameDecTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NameConTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreaLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsedLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RegDataLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenDataBarCheckItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarButtonItem, Me.OpenLawBarButtonItem, Me.OpenSummaryBarButtonItem, Me.OpenRiskBarButtonItem, Me.GoodFindBarButtonItem, Me.GoodClearBarButtonItem})
        Me.BarManager1.MaxItemId = 22
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(63, 154)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarCheckItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenSummaryBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'OpenListBarButtonItem
        '
        Me.OpenListBarButtonItem.Caption = "Список"
        Me.OpenListBarButtonItem.Glyph = CType(resources.GetObject("OpenListBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenListBarButtonItem.Id = 10
        Me.OpenListBarButtonItem.Name = "OpenListBarButtonItem"
        ToolTipTitleItem1.Text = "Список"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к списку объектов"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.OpenListBarButtonItem.SuperTip = SuperToolTip1
        '
        'OpenDataBarCheckItem
        '
        Me.OpenDataBarCheckItem.BindableChecked = True
        Me.OpenDataBarCheckItem.Caption = "РЕГИСТРАЦИОННЫЕ ДАННЫЕ"
        Me.OpenDataBarCheckItem.Checked = True
        Me.OpenDataBarCheckItem.Glyph = CType(resources.GetObject("OpenDataBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarCheckItem.GroupIndex = 1
        Me.OpenDataBarCheckItem.Id = 12
        Me.OpenDataBarCheckItem.Name = "OpenDataBarCheckItem"
        '
        'OpenEmbargoBarButtonItem
        '
        Me.OpenEmbargoBarButtonItem.Caption = "ЗАПРЕТЫ И ОГРАНИЧЕНИЯ"
        Me.OpenEmbargoBarButtonItem.Glyph = CType(resources.GetObject("OpenEmbargoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenEmbargoBarButtonItem.Id = 13
        Me.OpenEmbargoBarButtonItem.Name = "OpenEmbargoBarButtonItem"
        ToolTipTitleItem2.Text = "Запреты и ограничения"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Перейти к запретам и ограничениям"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.OpenEmbargoBarButtonItem.SuperTip = SuperToolTip2
        '
        'OpenControlBarButtonItem
        '
        Me.OpenControlBarButtonItem.Caption = "КОНТРОЛИРУЕМЫЕ"
        Me.OpenControlBarButtonItem.Glyph = CType(resources.GetObject("OpenControlBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenControlBarButtonItem.Id = 14
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
        Me.OpenLawBarButtonItem.Caption = "КОНТРОЛЬНЫЕ СПИСКИ"
        Me.OpenLawBarButtonItem.Glyph = CType(resources.GetObject("OpenLawBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarButtonItem.Id = 15
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
        Me.OpenSummaryBarButtonItem.Id = 16
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
        Me.OpenRiskBarButtonItem.Id = 17
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
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(1110, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Регистрационные данные"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(70, 235)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodFindBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.GoodClearBarButtonItem)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Регистрационные данные"
        '
        'GoodFindBarButtonItem
        '
        Me.GoodFindBarButtonItem.Caption = "Поиск"
        Me.GoodFindBarButtonItem.Glyph = CType(resources.GetObject("GoodFindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.GoodFindBarButtonItem.Id = 20
        Me.GoodFindBarButtonItem.Name = "GoodFindBarButtonItem"
        ToolTipTitleItem7.Text = "Поиск"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Поиск объекта в базе данных"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.GoodFindBarButtonItem.SuperTip = SuperToolTip7
        '
        'GoodClearBarButtonItem
        '
        Me.GoodClearBarButtonItem.Caption = "Очистить"
        Me.GoodClearBarButtonItem.Glyph = CType(resources.GetObject("GoodClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.GoodClearBarButtonItem.Id = 21
        Me.GoodClearBarButtonItem.Name = "GoodClearBarButtonItem"
        ToolTipTitleItem8.Text = "Очистить"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Очистить реквизиты объекта от всех данных"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.GoodClearBarButtonItem.SuperTip = SuperToolTip8
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 94)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(1110, 37)
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
        Me.LayoutControl1.Controls.Add(Me.UnrealCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.ChildLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.ParentButtonEdit)
        Me.LayoutControl1.Controls.Add(Me.DescriptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.UsedMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.AreaMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.CasTextEdit)
        Me.LayoutControl1.Controls.Add(Me.TnvedTextEdit)
        Me.LayoutControl1.Controls.Add(Me.NotNameDecCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.TypeLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.NameDecTextEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.NameConTextEdit)
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
        'UnrealCheckEdit
        '
        Me.UnrealCheckEdit.Location = New System.Drawing.Point(12, 135)
        Me.UnrealCheckEdit.MenuManager = Me.BarManager1
        Me.UnrealCheckEdit.Name = "UnrealCheckEdit"
        Me.UnrealCheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UnrealCheckEdit.Properties.Appearance.Options.UseFont = True
        Me.UnrealCheckEdit.Properties.Caption = "Оборудование, подлежащее проверке (отсутствует в перечне поставки)"
        Me.UnrealCheckEdit.Size = New System.Drawing.Size(1110, 20)
        Me.UnrealCheckEdit.StyleController = Me.LayoutControl1
        Me.UnrealCheckEdit.TabIndex = 42
        '
        'ChildLookUpEdit
        '
        Me.ChildLookUpEdit.Location = New System.Drawing.Point(210, 363)
        Me.ChildLookUpEdit.Name = "ChildLookUpEdit"
        Me.ChildLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ChildLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ChildLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Выбрать", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Выбрать объекты, входящие в состав объекта экспертизы", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Добавить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "Добавить новый объект, входящий в состав объекта экспертизы", Nothing, Nothing, True)})
        Me.ChildLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameCon", "nameCon")})
        Me.ChildLookUpEdit.Properties.DisplayMember = "nameCon"
        Me.ChildLookUpEdit.Properties.NullText = ""
        Me.ChildLookUpEdit.Properties.NullValuePrompt = "[нет данных]"
        Me.ChildLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.ChildLookUpEdit.Properties.ShowFooter = False
        Me.ChildLookUpEdit.Properties.ShowHeader = False
        Me.ChildLookUpEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.ChildLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ChildLookUpEdit.Properties.ValueMember = "id"
        Me.ChildLookUpEdit.Size = New System.Drawing.Size(900, 28)
        Me.ChildLookUpEdit.StyleController = Me.LayoutControl1
        Me.ChildLookUpEdit.TabIndex = 39
        '
        'ParentButtonEdit
        '
        Me.ParentButtonEdit.Location = New System.Drawing.Point(210, 331)
        Me.ParentButtonEdit.MenuManager = Me.BarManager1
        Me.ParentButtonEdit.Name = "ParentButtonEdit"
        Me.ParentButtonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Выбрать", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "Выбрать объект экспертизы", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Добавить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "Добавить новый объект экспертизы", Nothing, Nothing, True)})
        Me.ParentButtonEdit.Properties.NullValuePrompt = "[нет данных]"
        Me.ParentButtonEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.ParentButtonEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.ParentButtonEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.ParentButtonEdit.Size = New System.Drawing.Size(900, 28)
        Me.ParentButtonEdit.StyleController = Me.LayoutControl1
        Me.ParentButtonEdit.TabIndex = 35
        '
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(24, 733)
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(1086, 45)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 29
        '
        'UsedMemoEdit
        '
        Me.UsedMemoEdit.Location = New System.Drawing.Point(24, 629)
        Me.UsedMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.UsedMemoEdit.Name = "UsedMemoEdit"
        Me.UsedMemoEdit.Size = New System.Drawing.Size(1086, 45)
        Me.UsedMemoEdit.StyleController = Me.LayoutControl1
        Me.UsedMemoEdit.TabIndex = 28
        '
        'AreaMemoEdit
        '
        Me.AreaMemoEdit.Location = New System.Drawing.Point(24, 525)
        Me.AreaMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.AreaMemoEdit.Name = "AreaMemoEdit"
        Me.AreaMemoEdit.Size = New System.Drawing.Size(1086, 45)
        Me.AreaMemoEdit.StyleController = Me.LayoutControl1
        Me.AreaMemoEdit.TabIndex = 27
        '
        'CasTextEdit
        '
        Me.CasTextEdit.Location = New System.Drawing.Point(755, 438)
        Me.CasTextEdit.Name = "CasTextEdit"
        Me.CasTextEdit.Size = New System.Drawing.Size(355, 28)
        Me.CasTextEdit.StyleController = Me.LayoutControl1
        Me.CasTextEdit.TabIndex = 26
        '
        'TnvedTextEdit
        '
        Me.TnvedTextEdit.Location = New System.Drawing.Point(210, 438)
        Me.TnvedTextEdit.Name = "TnvedTextEdit"
        Me.TnvedTextEdit.Size = New System.Drawing.Size(355, 28)
        Me.TnvedTextEdit.StyleController = Me.LayoutControl1
        Me.TnvedTextEdit.TabIndex = 25
        '
        'NotNameDecCheckEdit
        '
        Me.NotNameDecCheckEdit.Location = New System.Drawing.Point(932, 228)
        Me.NotNameDecCheckEdit.MenuManager = Me.BarManager1
        Me.NotNameDecCheckEdit.Name = "NotNameDecCheckEdit"
        Me.NotNameDecCheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.NotNameDecCheckEdit.Properties.Appearance.Options.UseFont = True
        Me.NotNameDecCheckEdit.Properties.Caption = "Обозначение отсутствует"
        Me.NotNameDecCheckEdit.Size = New System.Drawing.Size(178, 20)
        Me.NotNameDecCheckEdit.StyleController = Me.LayoutControl1
        Me.NotNameDecCheckEdit.TabIndex = 24
        '
        'TypeLookUpEdit
        '
        Me.TypeLookUpEdit.Location = New System.Drawing.Point(210, 299)
        Me.TypeLookUpEdit.Name = "TypeLookUpEdit"
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.TypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("codeName", "codeName")})
        Me.TypeLookUpEdit.Properties.DisplayMember = "codeName"
        Me.TypeLookUpEdit.Properties.DropDownRows = 9
        Me.TypeLookUpEdit.Properties.NullText = ""
        Me.TypeLookUpEdit.Properties.NullValuePrompt = "[нет данных]"
        Me.TypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.TypeLookUpEdit.Properties.ShowFooter = False
        Me.TypeLookUpEdit.Properties.ShowHeader = False
        Me.TypeLookUpEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.TypeLookUpEdit.Properties.ValueMember = "id"
        Me.TypeLookUpEdit.Size = New System.Drawing.Size(900, 28)
        Me.TypeLookUpEdit.StyleController = Me.LayoutControl1
        Me.TypeLookUpEdit.TabIndex = 23
        '
        'NameDecTextEdit
        '
        Me.NameDecTextEdit.Location = New System.Drawing.Point(210, 224)
        Me.NameDecTextEdit.Name = "NameDecTextEdit"
        Me.NameDecTextEdit.Properties.NullValuePrompt = "Обозначение, присвоенное изготовителем"
        Me.NameDecTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.NameDecTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.NameDecTextEdit.Size = New System.Drawing.Size(718, 28)
        Me.NameDecTextEdit.StyleController = Me.LayoutControl1
        Me.NameDecTextEdit.TabIndex = 20
        '
        'NameConTextEdit
        '
        Me.NameConTextEdit.Location = New System.Drawing.Point(210, 192)
        Me.NameConTextEdit.Name = "NameConTextEdit"
        Me.NameConTextEdit.Properties.NullValuePrompt = "Наименование как в коммерческом (контрактном) документе"
        Me.NameConTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.NameConTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.NameConTextEdit.Size = New System.Drawing.Size(900, 28)
        Me.NameConTextEdit.StyleController = Me.LayoutControl1
        Me.NameConTextEdit.TabIndex = 18
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.AreaLayoutControlGroup, Me.UsedLayoutControlGroup, Me.DescriptionLayoutControlGroup, Me.SplitterItem1, Me.SplitterItem2, Me.RegDataLayoutControlGroup, Me.SplitterItem3, Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlItem11, Me.SimpleSeparator1, Me.LayoutControlItem14})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1134, 792)
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
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(1114, 40)
        Me.CaptionSimpleLabelItem.Text = "Продукция > Объект № _"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1114, 41)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'AreaLayoutControlGroup
        '
        Me.AreaLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.AreaLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.AreaLayoutControlGroup.Location = New System.Drawing.Point(0, 482)
        Me.AreaLayoutControlGroup.Name = "AreaLayoutControlGroup"
        Me.AreaLayoutControlGroup.Size = New System.Drawing.Size(1114, 92)
        Me.AreaLayoutControlGroup.Text = "Область применения"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.AreaMemoEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(1090, 49)
        Me.LayoutControlItem8.Text = "Область применения"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'UsedLayoutControlGroup
        '
        Me.UsedLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.UsedLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.UsedLayoutControlGroup.Location = New System.Drawing.Point(0, 586)
        Me.UsedLayoutControlGroup.Name = "UsedLayoutControlGroup"
        Me.UsedLayoutControlGroup.Size = New System.Drawing.Size(1114, 92)
        Me.UsedLayoutControlGroup.Text = "Назначение"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.UsedMemoEdit
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1090, 49)
        Me.LayoutControlItem9.Text = "Назначение"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'DescriptionLayoutControlGroup
        '
        Me.DescriptionLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.DescriptionLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10})
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 690)
        Me.DescriptionLayoutControlGroup.Name = "DescriptionLayoutControlGroup"
        Me.DescriptionLayoutControlGroup.Size = New System.Drawing.Size(1114, 92)
        Me.DescriptionLayoutControlGroup.Text = "Техническое описание<color='red'>*</color>"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.DescriptionMemoEdit
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(1090, 49)
        Me.LayoutControlItem10.Text = "Техническое описание"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 574)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(1114, 12)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 678)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(1114, 12)
        '
        'RegDataLayoutControlGroup
        '
        Me.RegDataLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem5})
        Me.RegDataLayoutControlGroup.Location = New System.Drawing.Point(0, 149)
        Me.RegDataLayoutControlGroup.Name = "RegDataLayoutControlGroup"
        Me.RegDataLayoutControlGroup.Size = New System.Drawing.Size(1114, 107)
        Me.RegDataLayoutControlGroup.Text = "Коммерческое наименование, обозначение"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AllowHtmlStringInCaption = True
        Me.LayoutControlItem1.Control = Me.NameConTextEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1090, 32)
        Me.LayoutControlItem1.Text = "Коммерческое наименование<color='red'>*</color>"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.NameDecTextEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(908, 32)
        Me.LayoutControlItem3.Text = "Обозначение"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.NotNameDecCheckEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(908, 32)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(182, 28)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(182, 28)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 6, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(182, 32)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Обозначение отсутствует"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SplitterItem3
        '
        Me.SplitterItem3.AllowHotTrack = True
        Me.SplitterItem3.Location = New System.Drawing.Point(0, 470)
        Me.SplitterItem3.Name = "SplitterItem3"
        Me.SplitterItem3.Size = New System.Drawing.Size(1114, 12)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 395)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1114, 75)
        Me.LayoutControlGroup1.Text = "Код ТН ВЭД, номер CAS"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AllowHtmlStringInCaption = True
        Me.LayoutControlItem6.Control = Me.TnvedTextEdit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(545, 32)
        Me.LayoutControlItem6.Text = "Код ТН ВЭД<color='red'>*</color>"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem7.Control = Me.CasTextEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(545, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(545, 32)
        Me.LayoutControlItem7.Text = "Номер CAS"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem12, Me.LayoutControlItem13})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 256)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1114, 139)
        Me.LayoutControlGroup2.Text = "Вид объекта, связь с другими объектами"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.AllowHtmlStringInCaption = True
        Me.LayoutControlItem4.Control = Me.TypeLookUpEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1090, 32)
        Me.LayoutControlItem4.Text = "Вид объекта<color='red'>*</color>"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.ParentButtonEdit
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1090, 32)
        Me.LayoutControlItem12.Text = "Интегрируется в объект"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.ChildLookUpEdit
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(1090, 32)
        Me.LayoutControlItem13.Text = "Содержит объекты"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(1114, 41)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(1114, 1)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.UnrealCheckEdit
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 4)
        Me.LayoutControlItem14.Size = New System.Drawing.Size(1114, 26)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'GoodDataChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodDataChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.UnrealCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChildLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParentButtonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsedMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreaMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CasTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TnvedTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotNameDecCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NameDecTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NameConTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreaLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsedLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RegDataLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
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
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Регистрационные данные", C2.ToInt(Row("rowNum")))
        UnrealCheckEdit.Checked = CBool(Row("isUnreal"))
        NameConTextEdit.EditValue = Row("nameCon")
        NameDecTextEdit.EditValue = Row("nameDec")
        NotNameDecCheckEdit.EditValue = Row("isNotDec")
        TypeLookUpEdit.EditValue = Row("typeId")
        TnvedTextEdit.EditValue = Row("tnved")
        CasTextEdit.EditValue = Row("cas")
        AreaMemoEdit.EditValue = Row("area")
        UsedMemoEdit.EditValue = Row("used")
        DescriptionMemoEdit.EditValue = Row("description")
        Dim PRow As DataRow = P.Work.GoodTable.Rows.Find(C2.ToInt(Row("parentId")))
        If PRow Is Nothing Then
            ParentButtonEdit.Text = Nothing
        Else
            ParentButtonEdit.Text = C2.ToText(PRow("nameCon"))
        End If
        ChildView.RowFilter = String.Format("parentId = {0}", MyClass.GoodId)
        If ChildView.Count > 0 Then ChildLookUpEdit.EditValue = ChildView(0)("id")
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
        ' Старый код ТН ВЭД
        '
        Dim oldTnved As String = C2.ToText(Row("tnved"))
        '
        ' Данные объекта
        '
        Row("isUnreal") = UnrealCheckEdit.Checked
        Row("nameCon") = C2.DbText(NameConTextEdit.EditValue)
        Row("nameDec") = C2.DbText(NameDecTextEdit.EditValue)
        Row("isNotDec") = NotNameDecCheckEdit.Checked
        If CBool(Row("isNotDec")) Then Row("nameDec") = DBNull.Value
        Row("typeId") = C2.DbInt(TypeLookUpEdit.EditValue)
        'Row("tnved") = C2.DbText(Cprp.DxData.Good.Common.ToTnved(TnvedTextEdit.EditValue))
        Row("tnved") = C2.DbText(TnvedTextEdit.EditValue)
        Row("cas") = C2.DbText(CasTextEdit.EditValue)
        Row("area") = C2.DbText(AreaMemoEdit.EditValue)
        Row("used") = C2.DbText(UsedMemoEdit.EditValue)
        Row("description") = C2.DbText(DescriptionMemoEdit.EditValue)
        Dim PRow As DataRow = P.Work.GoodTable.Rows.Find(C2.ToInt(Row("parentId")))
        If PRow Is Nothing Then Row("parentId") = DBNull.Value
        '
        ' Проверка изменения кода ТН ВЭД
        '
        If oldTnved <> C2.ToText(Row("tnved")) Then
            With P.Work.GoodControlTable
                .DeleteGood(Row("id"))
                .AcceptChanges()
            End With
            Row("isNotControl") = False
            Row("isCheckControl") = False
        End If
        '
        ' Обновление связей объектов в зависимости от вида объекта
        '
        Dim id As Integer = CInt(Row("id"))
        Dim bParent As Boolean = False  ' объект является системой
        Dim bChild As Boolean = False   ' объект является частью
        Dim TRow As DataRow = P.Work.GoodTypeHandbookTable.Rows.Find(C2.ToInt(Row("typeId")))
        If Not TRow Is Nothing Then
            bParent = CBool(TRow("isParent"))
            bChild = CBool(TRow("isChild"))
        End If
        If bParent Then
            ' система не может входить в другие системы
            Row("parentId") = DBNull.Value
        ElseIf bChild Then
            ' части не могут содержать другие объекты
            Using V As New DataView(P.Work.GoodTable)
                V.RowFilter = String.Format("parentId = {0}", id)
                While V.Count > 0
                    V(0)("parentId") = DBNull.Value
                End While
            End Using
        Else
            ' оборудование может входить в состав только систем
            If Not IsDBNull(Row("parentId")) Then
                Dim GRow As DataRow = P.Work.GoodTable.Rows.Find(Row("parentId"))
                TRow = P.Work.GoodTypeHandbookTable.Rows.Find(C2.ToInt(GRow("typeId")))
                If Not (TRow Is Nothing OrElse CBool(TRow("isParent"))) Then Row("parentId") = DBNull.Value
            End If
            ' оборудование может содержать только части
            Using V As New DataView(P.Work.GoodTable)
                V.RowFilter = String.Format("parentId = {0} AND NOT typeId IN ({1})", id, P.Work.GoodTypeHandbookTable.ChildIdString)
                While V.Count > 0
                    V(0)("parentId") = DBNull.Value
                End While
            End Using
        End If
        '
        ' Обновление контрольных статусов объектов экспертизы по контрольным статусам дочерних объектов
        '
        P.Work.StudySummaryUpdateByChild()
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckData") = ErrorTable.CheckGoodData(Row)
        P.Work.GoodTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        Dim bNotNameDec As Boolean = NotNameDecCheckEdit.Checked            ' Нет обозначения
        '
        ' Элементы управления
        '
        NameConTextEdit.Properties.ReadOnly = bLock
        NameDecTextEdit.Enabled = Not bNotNameDec
        NameDecTextEdit.Properties.ReadOnly = bLock
        NotNameDecCheckEdit.Properties.ReadOnly = bLock
        TypeLookUpEdit.Properties.ReadOnly = bLock
        TnvedTextEdit.Properties.ReadOnly = bLock
        CasTextEdit.Properties.ReadOnly = bLock
        AreaMemoEdit.Properties.ReadOnly = bLock
        UsedMemoEdit.Properties.ReadOnly = bLock
        DescriptionMemoEdit.Properties.ReadOnly = bLock
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
    ''' Предстваление дочерних объектов
    ''' </summary>
    Private ChildView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.GoodData
        TypeLookUpEdit.Properties.DataSource = P.Work.GoodTypeHandbookTable
        ChildView = New DataView(P.Work.GoodTable) With {.Sort = "nameCon"}
        ChildLookUpEdit.Properties.DataSource = ChildView
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
    End Sub

    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodList, MyClass.GoodId)
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

    ' Перейти к сравнительному анализу
    Private Sub OpenSummaryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenSummaryBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodSummary, MyClass.GoodId)
    End Sub

    ' Перейти к признакам риска
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodRisk, MyClass.GoodId)
    End Sub

    ' Поиск объекта в базе данных
    Private Sub GoodFindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodFindBarButtonItem.ItemClick
        DataWrite()
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        Using M As Cprp.DxData.Good.GoodDataTable = Cprp.DxData.Good.Common.Find(P.Work.Connection, Row)
            If M Is Nothing Then Exit Sub
            '
            ' Реквизиты
            '
            Row("nameCon") = M(0)("nameCon")
            Row("nameDec") = M(0)("nameDec")
            Row("isNotDec") = M(0)("isNotDec")
            Row("typeId") = M(0)("typeId")
            Row("tnved") = M(0)("tnved")
            Row("cas") = M(0)("cas")
            Row("area") = M(0)("area")
            Row("used") = M(0)("used")
            Row("description") = M(0)("description")
        End Using
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    ' Очистить реквизиты объекта от всех данных
    Private Sub GoodClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodClearBarButtonItem.ItemClick
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Очистить реквизиты объекта от всех данных?") <> DialogResult.Yes Then Exit Sub
        Row("nameCon") = DBNull.Value
        Row("nameDec") = DBNull.Value
        Row("isNotDec") = False
        Row("typeId") = DBNull.Value
        Row("tnved") = DBNull.Value
        Row("cas") = DBNull.Value
        Row("area") = DBNull.Value
        Row("used") = DBNull.Value
        Row("description") = DBNull.Value
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    ' Выбор и добавление родительского виртуального объекта
    Private Sub ParentButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ParentButtonEdit.ButtonClick
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        Dim PRow As DataRow = Nothing
        DataWrite()
        Select Case e.Button.Index
            Case 0
                'If P.Work.GoodTable.Rows.Count < 2 Then Exit Sub
                Using F As New GoodSelectParentForm(P, Row)
                    If F.ShowDialog <> DialogResult.OK Then Exit Sub
                End Using
                PRow = P.Work.GoodTable.Rows.Find(C2.ToInt(Row("parentId")))
                If PRow Is Nothing Then
                    ParentButtonEdit.Text = Nothing
                Else
                    ParentButtonEdit.Text = C2.ToText(PRow("nameCon"))
                End If
            Case 1
                PRow = P.Work.GoodTable.AddNew()
                PRow("isUnreal") = True
                Row("parentId") = PRow("id")
                P.ContentOpen(ContentEnum.GoodData, CInt(PRow("id")))
        End Select
    End Sub

    ' Выбор, добавление и удаление дочерних объектов
    Private Sub ChildLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ChildLookUpEdit.ButtonClick
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        Dim PRow As DataRow = Nothing
        DataWrite()
        Select Case e.Button.Index
            Case 1
                'If P.Work.GoodTable.Rows.Count < 2 Then Exit Sub
                With New GoodSelectChildForm(P, Row)
                    .ShowDialog()
                End With
                If ChildView.Count > 0 Then ChildLookUpEdit.EditValue = ChildView(0)("id")
            Case 2
                PRow = P.Work.GoodTable.AddNew()
                PRow("parentId") = Row("id")
                P.ContentOpen(ContentEnum.GoodData, CInt(PRow("id")))
        End Select
    End Sub

    Private Sub UnrealCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles UnrealCheckEdit.CheckedChanged
        Dim style1 As Drawing.FontStyle = Drawing.FontStyle.Regular
        Dim style2 As Drawing.FontStyle = Drawing.FontStyle.Regular
        If UnrealCheckEdit.Checked Then
            style1 = Drawing.FontStyle.Bold + Drawing.FontStyle.Underline
            style2 = Drawing.FontStyle.Italic
        End If
        With UnrealCheckEdit.Font
            UnrealCheckEdit.Font = New Drawing.Font(.Name, .Size, style1)
        End With
        With LayoutControl1.Appearance.Control.Font
            NameConTextEdit.Font = New Drawing.Font(.Name, .Size, style2)
        End With
    End Sub

    Private Sub TypeLookUpEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles TypeLookUpEdit.EditValueChanging
        Dim Row As DataRow = P.Work.GoodTypeHandbookTable.Rows.Find(C2.ToInt(e.NewValue))
        ParentButtonEdit.Enabled = Not (Row Is Nothing OrElse CBool(Row("isParent")))
        ChildLookUpEdit.Enabled = Not (Row Is Nothing OrElse CBool(Row("isChild")))
    End Sub

    Private Sub NameConTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NameConTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub NameDecTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NameDecTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub NotNameDecCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles NotNameDecCheckEdit.CheckedChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub CategoryLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TypeLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub TnvedTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TnvedTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub CasTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CasTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub TnvedCommentMemoEdit_EditValueChanged(sender As Object, e As EventArgs)
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub AreaMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AreaMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub UsedMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles UsedMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DescriptionMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DescriptionMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub TypeLookUpEdit_EnabledChanged(sender As Object, e As EventArgs) Handles TypeLookUpEdit.EnabledChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
