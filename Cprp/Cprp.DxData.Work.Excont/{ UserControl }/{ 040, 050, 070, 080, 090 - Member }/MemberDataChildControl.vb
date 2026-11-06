Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
''' <summary>
''' Элемент управления "Лицо > Регистрационные данные"
''' </summary>
Friend Class MemberDataChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents MemberClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MemberFindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenProfileBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents AddressPostTownTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AddressPostCountryLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AddressPostFullButtonEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents AddressFactTownTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AddressFactCountryLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AddressFactFullButtonEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents AddressLegalTownTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AddressLegalCountryLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AddressLegalFullTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents WebTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmailTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents FaxTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PhoneTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PassportGiveTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PassportSerTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PassportNumTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents KppTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TypeLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents NameShortTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NameLongTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents InnKppLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents AddressTabbedControlGroup As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents AddressLegalLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AddressFactLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AddressPostLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents IsControlSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents InnButtonEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemberDataChildControl))
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip8 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem8 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem8 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip9 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem9 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem9 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenProfileBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.MemberFindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MemberClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.InnButtonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.AddressPostTownTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.AddressPostCountryLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.AddressPostFullButtonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.AddressFactTownTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.AddressFactCountryLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.AddressFactFullButtonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.AddressLegalTownTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.AddressLegalCountryLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.AddressLegalFullTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.WebTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.EmailTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.FaxTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.PhoneTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.PassportGiveTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.PassportSerTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.PassportNumTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.KppTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.TypeLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.NameShortTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.NameLongTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.InnKppLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.AddressTabbedControlGroup = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.AddressLegalLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.AddressFactLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.AddressPostLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.IsControlSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.InnButtonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressPostTownTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressPostCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressPostFullButtonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressFactTownTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressFactCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressFactFullButtonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressLegalTownTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressLegalCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressLegalFullTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmailTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FaxTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhoneTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassportGiveTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassportSerTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassportNumTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KppTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NameShortTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NameLongTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InnKppLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressTabbedControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressLegalLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressFactLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddressPostLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsControlSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenDataBarCheckItem, Me.MemberFindBarButtonItem, Me.MemberClearBarButtonItem, Me.OpenProfileBarButtonItem, Me.OpenRiskBarButtonItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarButtonItem})
        Me.BarManager1.MaxItemId = 10
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(59, 212)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarCheckItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenProfileBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        'OpenDataBarCheckItem
        '
        Me.OpenDataBarCheckItem.BindableChecked = True
        Me.OpenDataBarCheckItem.Caption = "РЕГИСТРАЦИОННЫЕ ДАННЫЕ"
        Me.OpenDataBarCheckItem.Checked = True
        Me.OpenDataBarCheckItem.Glyph = CType(resources.GetObject("OpenDataBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarCheckItem.GroupIndex = 1
        Me.OpenDataBarCheckItem.Id = 1
        Me.OpenDataBarCheckItem.Name = "OpenDataBarCheckItem"
        '
        'OpenEmbargoBarButtonItem
        '
        Me.OpenEmbargoBarButtonItem.Caption = "ЗАПРЕТЫ И ОГРАНИЧЕНИЯ"
        Me.OpenEmbargoBarButtonItem.Glyph = CType(resources.GetObject("OpenEmbargoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenEmbargoBarButtonItem.Id = 8
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
        Me.OpenControlBarButtonItem.Caption = "ВСЕОБЪЕМЛЮЩИЙ КОНТРОЛЬ"
        Me.OpenControlBarButtonItem.Glyph = CType(resources.GetObject("OpenControlBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenControlBarButtonItem.Id = 9
        Me.OpenControlBarButtonItem.Name = "OpenControlBarButtonItem"
        ToolTipTitleItem3.Text = "На контроле"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Перейти к фирмам на контроле"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip3
        '
        'OpenProfileBarButtonItem
        '
        Me.OpenProfileBarButtonItem.Caption = "ПРОФИЛЬ"
        Me.OpenProfileBarButtonItem.Glyph = CType(resources.GetObject("OpenProfileBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenProfileBarButtonItem.Id = 6
        Me.OpenProfileBarButtonItem.Name = "OpenProfileBarButtonItem"
        ToolTipTitleItem4.Text = "Профиль"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к профилю"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenProfileBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenRiskBarButtonItem
        '
        Me.OpenRiskBarButtonItem.Caption = "РИСКИ"
        Me.OpenRiskBarButtonItem.Glyph = CType(resources.GetObject("OpenRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarButtonItem.Id = 7
        Me.OpenRiskBarButtonItem.Name = "OpenRiskBarButtonItem"
        ToolTipTitleItem5.Text = "Риски"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Перейти к рискам"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.OpenRiskBarButtonItem.SuperTip = SuperToolTip5
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(908, 39)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Регистрационные данные"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(61, 217)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.MemberFindBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.MemberClearBarButtonItem)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Регистрационные данные"
        '
        'MemberFindBarButtonItem
        '
        Me.MemberFindBarButtonItem.Caption = "Поиск"
        Me.MemberFindBarButtonItem.Glyph = CType(resources.GetObject("MemberFindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.MemberFindBarButtonItem.Id = 4
        Me.MemberFindBarButtonItem.Name = "MemberFindBarButtonItem"
        ToolTipTitleItem6.Text = "Поиск"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Поиск объекта в базе данных"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.MemberFindBarButtonItem.SuperTip = SuperToolTip6
        '
        'MemberClearBarButtonItem
        '
        Me.MemberClearBarButtonItem.Caption = "Очистить"
        Me.MemberClearBarButtonItem.Glyph = CType(resources.GetObject("MemberClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.MemberClearBarButtonItem.Id = 5
        Me.MemberClearBarButtonItem.Name = "MemberClearBarButtonItem"
        ToolTipTitleItem7.Text = "Очистить"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Очистить реквизиты объекта"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.MemberClearBarButtonItem.SuperTip = SuperToolTip7
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 96)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(908, 39)
        Me.StandaloneBarDockControl2.Text = "StandaloneBarDockControl2"
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
        Me.LayoutControl1.Controls.Add(Me.InnButtonEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressPostTownTextEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressPostCountryLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressPostFullButtonEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressFactTownTextEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressFactCountryLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressFactFullButtonEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressLegalTownTextEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressLegalCountryLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.AddressLegalFullTextEdit)
        Me.LayoutControl1.Controls.Add(Me.WebTextEdit)
        Me.LayoutControl1.Controls.Add(Me.EmailTextEdit)
        Me.LayoutControl1.Controls.Add(Me.FaxTextEdit)
        Me.LayoutControl1.Controls.Add(Me.PhoneTextEdit)
        Me.LayoutControl1.Controls.Add(Me.PassportGiveTextEdit)
        Me.LayoutControl1.Controls.Add(Me.PassportSerTextEdit)
        Me.LayoutControl1.Controls.Add(Me.PassportNumTextEdit)
        Me.LayoutControl1.Controls.Add(Me.KppTextEdit)
        Me.LayoutControl1.Controls.Add(Me.TypeLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.NameShortTextEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.NameLongTextEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 6
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'InnButtonEdit
        '
        Me.InnButtonEdit.Location = New System.Drawing.Point(212, 342)
        Me.InnButtonEdit.MenuManager = Me.BarManager1
        Me.InnButtonEdit.Name = "InnButtonEdit"
        Me.InnButtonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Поиск", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Поиск сведений о компании по ИНН", Nothing, Nothing, True)})
        Me.InnButtonEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.InnButtonEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.InnButtonEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.InnButtonEdit.Size = New System.Drawing.Size(252, 30)
        Me.InnButtonEdit.StyleController = Me.LayoutControl1
        Me.InnButtonEdit.TabIndex = 18
        '
        'AddressPostTownTextEdit
        '
        Me.AddressPostTownTextEdit.Location = New System.Drawing.Point(654, 692)
        Me.AddressPostTownTextEdit.Name = "AddressPostTownTextEdit"
        Me.AddressPostTownTextEdit.Size = New System.Drawing.Size(253, 30)
        Me.AddressPostTownTextEdit.StyleController = Me.LayoutControl1
        Me.AddressPostTownTextEdit.TabIndex = 15
        '
        'AddressPostCountryLookUpEdit
        '
        Me.AddressPostCountryLookUpEdit.Location = New System.Drawing.Point(212, 692)
        Me.AddressPostCountryLookUpEdit.Name = "AddressPostCountryLookUpEdit"
        Me.AddressPostCountryLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AddressPostCountryLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.AddressPostCountryLookUpEdit.Properties.DisplayMember = "nameShort"
        Me.AddressPostCountryLookUpEdit.Properties.NullText = ""
        Me.AddressPostCountryLookUpEdit.Properties.ShowFooter = False
        Me.AddressPostCountryLookUpEdit.Properties.ShowHeader = False
        Me.AddressPostCountryLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.AddressPostCountryLookUpEdit.Properties.ValueMember = "id"
        Me.AddressPostCountryLookUpEdit.Size = New System.Drawing.Size(251, 30)
        Me.AddressPostCountryLookUpEdit.StyleController = Me.LayoutControl1
        Me.AddressPostCountryLookUpEdit.TabIndex = 1
        '
        'AddressPostFullButtonEdit
        '
        Me.AddressPostFullButtonEdit.Location = New System.Drawing.Point(212, 658)
        Me.AddressPostFullButtonEdit.Name = "AddressPostFullButtonEdit"
        ToolTipTitleItem8.Text = "Вставить"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Вставить данные юридического адреса"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.AddressPostFullButtonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Вставить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("AddressPostFullButtonEdit.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, SuperToolTip8, True)})
        Me.AddressPostFullButtonEdit.Size = New System.Drawing.Size(695, 30)
        Me.AddressPostFullButtonEdit.StyleController = Me.LayoutControl1
        Me.AddressPostFullButtonEdit.TabIndex = 1
        '
        'AddressFactTownTextEdit
        '
        Me.AddressFactTownTextEdit.Location = New System.Drawing.Point(654, 692)
        Me.AddressFactTownTextEdit.Name = "AddressFactTownTextEdit"
        Me.AddressFactTownTextEdit.Size = New System.Drawing.Size(253, 30)
        Me.AddressFactTownTextEdit.StyleController = Me.LayoutControl1
        Me.AddressFactTownTextEdit.TabIndex = 1
        '
        'AddressFactCountryLookUpEdit
        '
        Me.AddressFactCountryLookUpEdit.Location = New System.Drawing.Point(212, 692)
        Me.AddressFactCountryLookUpEdit.Name = "AddressFactCountryLookUpEdit"
        Me.AddressFactCountryLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AddressFactCountryLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.AddressFactCountryLookUpEdit.Properties.DisplayMember = "nameShort"
        Me.AddressFactCountryLookUpEdit.Properties.NullText = ""
        Me.AddressFactCountryLookUpEdit.Properties.ShowFooter = False
        Me.AddressFactCountryLookUpEdit.Properties.ShowHeader = False
        Me.AddressFactCountryLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.AddressFactCountryLookUpEdit.Properties.ValueMember = "id"
        Me.AddressFactCountryLookUpEdit.Size = New System.Drawing.Size(251, 30)
        Me.AddressFactCountryLookUpEdit.StyleController = Me.LayoutControl1
        Me.AddressFactCountryLookUpEdit.TabIndex = 1
        '
        'AddressFactFullButtonEdit
        '
        Me.AddressFactFullButtonEdit.Location = New System.Drawing.Point(212, 658)
        Me.AddressFactFullButtonEdit.Name = "AddressFactFullButtonEdit"
        ToolTipTitleItem9.Text = "Вставить"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Вставить данные юридического адреса"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.AddressFactFullButtonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Вставить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("AddressFactFullButtonEdit.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, SuperToolTip9, True)})
        Me.AddressFactFullButtonEdit.Size = New System.Drawing.Size(695, 30)
        Me.AddressFactFullButtonEdit.StyleController = Me.LayoutControl1
        Me.AddressFactFullButtonEdit.TabIndex = 1
        '
        'AddressLegalTownTextEdit
        '
        Me.AddressLegalTownTextEdit.Location = New System.Drawing.Point(654, 692)
        Me.AddressLegalTownTextEdit.Name = "AddressLegalTownTextEdit"
        Me.AddressLegalTownTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.AddressLegalTownTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.AddressLegalTownTextEdit.Size = New System.Drawing.Size(253, 30)
        Me.AddressLegalTownTextEdit.StyleController = Me.LayoutControl1
        Me.AddressLegalTownTextEdit.TabIndex = 15
        '
        'AddressLegalCountryLookUpEdit
        '
        Me.AddressLegalCountryLookUpEdit.Location = New System.Drawing.Point(212, 692)
        Me.AddressLegalCountryLookUpEdit.Name = "AddressLegalCountryLookUpEdit"
        Me.AddressLegalCountryLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AddressLegalCountryLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.AddressLegalCountryLookUpEdit.Properties.DisplayMember = "nameShort"
        Me.AddressLegalCountryLookUpEdit.Properties.NullText = ""
        Me.AddressLegalCountryLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.AddressLegalCountryLookUpEdit.Properties.ShowFooter = False
        Me.AddressLegalCountryLookUpEdit.Properties.ShowHeader = False
        Me.AddressLegalCountryLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.AddressLegalCountryLookUpEdit.Properties.ValueMember = "id"
        Me.AddressLegalCountryLookUpEdit.Size = New System.Drawing.Size(251, 30)
        Me.AddressLegalCountryLookUpEdit.StyleController = Me.LayoutControl1
        Me.AddressLegalCountryLookUpEdit.TabIndex = 14
        '
        'AddressLegalFullTextEdit
        '
        Me.AddressLegalFullTextEdit.Location = New System.Drawing.Point(212, 658)
        Me.AddressLegalFullTextEdit.Name = "AddressLegalFullTextEdit"
        Me.AddressLegalFullTextEdit.Properties.NullValuePrompt = "Полный юридический адрес, как в официальных документах"
        Me.AddressLegalFullTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.AddressLegalFullTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.AddressLegalFullTextEdit.Size = New System.Drawing.Size(695, 30)
        Me.AddressLegalFullTextEdit.StyleController = Me.LayoutControl1
        Me.AddressLegalFullTextEdit.TabIndex = 13
        '
        'WebTextEdit
        '
        Me.WebTextEdit.Location = New System.Drawing.Point(654, 572)
        Me.WebTextEdit.Name = "WebTextEdit"
        Me.WebTextEdit.Size = New System.Drawing.Size(253, 30)
        Me.WebTextEdit.StyleController = Me.LayoutControl1
        Me.WebTextEdit.TabIndex = 12
        '
        'EmailTextEdit
        '
        Me.EmailTextEdit.Location = New System.Drawing.Point(212, 572)
        Me.EmailTextEdit.Name = "EmailTextEdit"
        Me.EmailTextEdit.Size = New System.Drawing.Size(251, 30)
        Me.EmailTextEdit.StyleController = Me.LayoutControl1
        Me.EmailTextEdit.TabIndex = 11
        '
        'FaxTextEdit
        '
        Me.FaxTextEdit.Location = New System.Drawing.Point(654, 538)
        Me.FaxTextEdit.Name = "FaxTextEdit"
        Me.FaxTextEdit.Size = New System.Drawing.Size(253, 30)
        Me.FaxTextEdit.StyleController = Me.LayoutControl1
        Me.FaxTextEdit.TabIndex = 10
        '
        'PhoneTextEdit
        '
        Me.PhoneTextEdit.Location = New System.Drawing.Point(212, 538)
        Me.PhoneTextEdit.Name = "PhoneTextEdit"
        Me.PhoneTextEdit.Size = New System.Drawing.Size(251, 30)
        Me.PhoneTextEdit.StyleController = Me.LayoutControl1
        Me.PhoneTextEdit.TabIndex = 9
        '
        'PassportGiveTextEdit
        '
        Me.PassportGiveTextEdit.Location = New System.Drawing.Point(212, 457)
        Me.PassportGiveTextEdit.Name = "PassportGiveTextEdit"
        Me.PassportGiveTextEdit.Size = New System.Drawing.Size(695, 30)
        Me.PassportGiveTextEdit.StyleController = Me.LayoutControl1
        Me.PassportGiveTextEdit.TabIndex = 8
        '
        'PassportSerTextEdit
        '
        Me.PassportSerTextEdit.Location = New System.Drawing.Point(654, 423)
        Me.PassportSerTextEdit.Name = "PassportSerTextEdit"
        Me.PassportSerTextEdit.Size = New System.Drawing.Size(253, 30)
        Me.PassportSerTextEdit.StyleController = Me.LayoutControl1
        Me.PassportSerTextEdit.TabIndex = 7
        '
        'PassportNumTextEdit
        '
        Me.PassportNumTextEdit.Location = New System.Drawing.Point(212, 423)
        Me.PassportNumTextEdit.Name = "PassportNumTextEdit"
        Me.PassportNumTextEdit.Size = New System.Drawing.Size(251, 30)
        Me.PassportNumTextEdit.StyleController = Me.LayoutControl1
        Me.PassportNumTextEdit.TabIndex = 6
        '
        'KppTextEdit
        '
        Me.KppTextEdit.Location = New System.Drawing.Point(655, 342)
        Me.KppTextEdit.Name = "KppTextEdit"
        Me.KppTextEdit.Size = New System.Drawing.Size(252, 30)
        Me.KppTextEdit.StyleController = Me.LayoutControl1
        Me.KppTextEdit.TabIndex = 5
        '
        'TypeLookUpEdit
        '
        Me.TypeLookUpEdit.Location = New System.Drawing.Point(212, 261)
        Me.TypeLookUpEdit.Name = "TypeLookUpEdit"
        Me.TypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.TypeLookUpEdit.Properties.DisplayMember = "name"
        Me.TypeLookUpEdit.Properties.DropDownRows = 3
        Me.TypeLookUpEdit.Properties.NullText = ""
        Me.TypeLookUpEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.TypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.TypeLookUpEdit.Properties.ShowFooter = False
        Me.TypeLookUpEdit.Properties.ShowHeader = False
        Me.TypeLookUpEdit.Properties.ValueMember = "id"
        Me.TypeLookUpEdit.Size = New System.Drawing.Size(253, 30)
        Me.TypeLookUpEdit.StyleController = Me.LayoutControl1
        Me.TypeLookUpEdit.TabIndex = 3
        '
        'NameShortTextEdit
        '
        Me.NameShortTextEdit.Location = New System.Drawing.Point(212, 227)
        Me.NameShortTextEdit.Name = "NameShortTextEdit"
        Me.NameShortTextEdit.Properties.NullValuePrompt = "Краткое наименование, как в официальных документах"
        Me.NameShortTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.NameShortTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.NameShortTextEdit.Size = New System.Drawing.Size(695, 30)
        Me.NameShortTextEdit.StyleController = Me.LayoutControl1
        Me.NameShortTextEdit.TabIndex = 2
        '
        'NameLongTextEdit
        '
        Me.NameLongTextEdit.Location = New System.Drawing.Point(212, 193)
        Me.NameLongTextEdit.Name = "NameLongTextEdit"
        Me.NameLongTextEdit.Properties.NullValuePrompt = "Полное наименование, как в официальных документах"
        Me.NameLongTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.NameLongTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.NameLongTextEdit.Size = New System.Drawing.Size(695, 30)
        Me.NameLongTextEdit.StyleController = Me.LayoutControl1
        Me.NameLongTextEdit.TabIndex = 0
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlGroup1, Me.InnKppLayoutControlGroup, Me.LayoutControlGroup3, Me.LayoutControlGroup4, Me.EmptySpaceItem1, Me.AddressTabbedControlGroup, Me.IsControlSimpleLabelItem})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(932, 747)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseTextOptions = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(912, 40)
        Me.CaptionSimpleLabelItem.Text = "Регистрационные данные"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(912, 43)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(912, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 83)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(912, 1)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.EmptySpaceItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 147)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(912, 149)
        Me.LayoutControlGroup1.Text = "Наименование, вид"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AllowHtmlStringInCaption = True
        Me.LayoutControlItem1.Control = Me.NameLongTextEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(886, 34)
        Me.LayoutControlItem1.Text = "Полное наименование<color='red'>*</color>"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.AllowHtmlStringInCaption = True
        Me.LayoutControlItem4.Control = Me.NameShortTextEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(886, 34)
        Me.LayoutControlItem4.Text = "Краткое наименование<color='red'>*</color>"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AllowHtmlStringInCaption = True
        Me.LayoutControlItem5.Control = Me.TypeLookUpEdit
        Me.LayoutControlItem5.CustomizationFormText = "Вид<color='red'>*</color>"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem5.Text = "Вид<color='red'>*</color>"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(184, 16)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(444, 68)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(442, 34)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'InnKppLayoutControlGroup
        '
        Me.InnKppLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem6})
        Me.InnKppLayoutControlGroup.Location = New System.Drawing.Point(0, 296)
        Me.InnKppLayoutControlGroup.Name = "InnKppLayoutControlGroup"
        Me.InnKppLayoutControlGroup.Size = New System.Drawing.Size(912, 81)
        Me.InnKppLayoutControlGroup.Text = "ИНН, КПП"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem7.Control = Me.KppTextEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(443, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(443, 34)
        Me.LayoutControlItem7.Text = "КПП"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AllowHtmlStringInCaption = True
        Me.LayoutControlItem6.Control = Me.InnButtonEdit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(443, 34)
        Me.LayoutControlItem6.Text = "ИНН<color='red'>*</color>"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 377)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(912, 115)
        Me.LayoutControlGroup3.Text = "Паспортные данные (для физических лиц)"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.PassportNumTextEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(442, 34)
        Me.LayoutControlItem8.Text = "Серия паспорта"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem9.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem9.Control = Me.PassportSerTextEdit
        Me.LayoutControlItem9.Location = New System.Drawing.Point(442, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem9.Text = "Номер паспорта"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.PassportGiveTextEdit
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(886, 34)
        Me.LayoutControlItem10.Text = "Паспорт выдан"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 492)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(912, 115)
        Me.LayoutControlGroup4.Text = "Телефон, факс, e-mail, сайт"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.PhoneTextEdit
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(442, 34)
        Me.LayoutControlItem11.Text = "Телефон"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem12.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem12.Control = Me.FaxTextEdit
        Me.LayoutControlItem12.Location = New System.Drawing.Point(442, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem12.Text = "Факс"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.EmailTextEdit
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(442, 34)
        Me.LayoutControlItem13.Text = "E-mail"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem14.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem14.Control = Me.WebTextEdit
        Me.LayoutControlItem14.Location = New System.Drawing.Point(442, 34)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem14.Text = "Сайт"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(184, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 727)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(912, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'AddressTabbedControlGroup
        '
        Me.AddressTabbedControlGroup.Location = New System.Drawing.Point(0, 607)
        Me.AddressTabbedControlGroup.Name = "AddressTabbedControlGroup"
        Me.AddressTabbedControlGroup.SelectedTabPage = Me.AddressLegalLayoutControlGroup
        Me.AddressTabbedControlGroup.SelectedTabPageIndex = 0
        Me.AddressTabbedControlGroup.Size = New System.Drawing.Size(912, 120)
        Me.AddressTabbedControlGroup.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.AddressLegalLayoutControlGroup, Me.AddressFactLayoutControlGroup, Me.AddressPostLayoutControlGroup})
        '
        'AddressLegalLayoutControlGroup
        '
        Me.AddressLegalLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem17})
        Me.AddressLegalLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.AddressLegalLayoutControlGroup.Name = "AddressLegalLayoutControlGroup"
        Me.AddressLegalLayoutControlGroup.Size = New System.Drawing.Size(886, 68)
        Me.AddressLegalLayoutControlGroup.Text = "Юридический адрес"
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.AllowHtmlStringInCaption = True
        Me.LayoutControlItem15.Control = Me.AddressLegalFullTextEdit
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(886, 34)
        Me.LayoutControlItem15.Text = "Юридический адрес<color='red'>*</color>"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.AllowHtmlStringInCaption = True
        Me.LayoutControlItem16.Control = Me.AddressLegalCountryLookUpEdit
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(442, 34)
        Me.LayoutControlItem16.Text = "Страна<color='red'>*</color>"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.AllowHtmlStringInCaption = True
        Me.LayoutControlItem17.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem17.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem17.Control = Me.AddressLegalTownTextEdit
        Me.LayoutControlItem17.Location = New System.Drawing.Point(442, 34)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem17.Text = " Город (населенный пункт)<color='red'>*</color>"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(184, 16)
        '
        'AddressFactLayoutControlGroup
        '
        Me.AddressFactLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem18, Me.LayoutControlItem19, Me.LayoutControlItem20})
        Me.AddressFactLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.AddressFactLayoutControlGroup.Name = "AddressFactLayoutControlGroup"
        Me.AddressFactLayoutControlGroup.Size = New System.Drawing.Size(886, 68)
        Me.AddressFactLayoutControlGroup.Text = "Фактический адрес"
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.AddressFactFullButtonEdit
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(886, 34)
        Me.LayoutControlItem18.Text = "Фактический адрес"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.AddressFactCountryLookUpEdit
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(442, 34)
        Me.LayoutControlItem19.Text = "Страна"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem20.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem20.Control = Me.AddressFactTownTextEdit
        Me.LayoutControlItem20.Location = New System.Drawing.Point(442, 34)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem20.Text = " Город (населенный пункт)"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(184, 16)
        '
        'AddressPostLayoutControlGroup
        '
        Me.AddressPostLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem23})
        Me.AddressPostLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.AddressPostLayoutControlGroup.Name = "AddressPostLayoutControlGroup"
        Me.AddressPostLayoutControlGroup.Size = New System.Drawing.Size(886, 68)
        Me.AddressPostLayoutControlGroup.Text = "Почтовый адрес"
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.AddressPostFullButtonEdit
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(886, 34)
        Me.LayoutControlItem21.Text = "Почтовый адрес"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.AddressPostCountryLookUpEdit
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(442, 34)
        Me.LayoutControlItem22.Text = "Страна"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(184, 16)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem23.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem23.Control = Me.AddressPostTownTextEdit
        Me.LayoutControlItem23.Location = New System.Drawing.Point(442, 34)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(444, 34)
        Me.LayoutControlItem23.Text = " Город (населенный пункт)"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(184, 16)
        '
        'IsControlSimpleLabelItem
        '
        Me.IsControlSimpleLabelItem.AllowHotTrack = False
        Me.IsControlSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red
        Me.IsControlSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.IsControlSimpleLabelItem.Location = New System.Drawing.Point(0, 127)
        Me.IsControlSimpleLabelItem.Name = "IsControlSimpleLabelItem"
        Me.IsControlSimpleLabelItem.Size = New System.Drawing.Size(912, 20)
        Me.IsControlSimpleLabelItem.Text = "  ФИРМА НА КОНТРОЛЕ"
        Me.IsControlSimpleLabelItem.TextSize = New System.Drawing.Size(184, 16)
        '
        'MemberDataChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MemberDataChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.InnButtonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressPostTownTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressPostCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressPostFullButtonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressFactTownTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressFactCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressFactFullButtonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressLegalTownTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressLegalCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressLegalFullTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmailTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FaxTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhoneTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassportGiveTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassportSerTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassportNumTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KppTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NameShortTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NameLongTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InnKppLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressTabbedControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressLegalLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressFactLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddressPostLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsControlSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Строка таблицы лиц
        '
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        '
        ' Порядковый номер объекта, Заголовок элемента управления
        '
        Dim sTmp As String = "Регистрационные данные"
        Select Case MyKind
            Case MK.IsContractRus
                MyRowNum = C2.ToInt(Row("conRusNum"))
                sTmp = "Внешнеэкономическая сделка > Российские участники"
            Case MK.IsContractNus
                MyRowNum = C2.ToInt(Row("conNusNum"))
                sTmp = "Внешнеэкономическая сделка > Иностранные участники"
            Case MK.IsSupplyRus
                MyRowNum = C2.ToInt(Row("supRusNum"))
                sTmp = "Внешнеэкономическая операция > Российские участники"
            Case MK.IsSupplyNus
                MyRowNum = C2.ToInt(Row("supNusNum"))
                sTmp = "Внешнеэкономическая операция > Иностранные покупатели (продавцы)"
            Case MK.IsSupplyEnd
                MyRowNum = C2.ToInt(Row("supEndNum"))
                sTmp = "Внешнеэкономическая операция > Потребители (конечные пользователи)"
        End Select
        CaptionSimpleLabelItem.Text = String.Format("{0} > Объект № {1} > Регистрационные данные", sTmp, MyRowNum)
        '
        ' Фирма на контроле
        '
        If IsDBNull(Row("isControl")) OrElse Not CBool(Row("isControl")) Then
            IsControlSimpleLabelItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            IsControlSimpleLabelItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
        '
        ' Элементы управления
        '
        NameLongTextEdit.EditValue = Row("nameLong")
        NameShortTextEdit.EditValue = Row("nameShort")
        TypeLookUpEdit.EditValue = Row("typeId")
        InnButtonEdit.EditValue = Row("inn")
        KppTextEdit.EditValue = Row("kpp")
        PassportSerTextEdit.EditValue = Row("passportSer")
        PassportNumTextEdit.EditValue = Row("passportNum")
        PassportGiveTextEdit.EditValue = Row("passportGive")
        PhoneTextEdit.EditValue = Row("phone")
        FaxTextEdit.EditValue = Row("fax")
        EmailTextEdit.EditValue = Row("email")
        WebTextEdit.EditValue = Row("web")
        AddressLegalFullTextEdit.EditValue = Row("addressLegalFull")
        If Not IsDBNull(Row("addressLegalCountryId")) Then
            AddressLegalCountryLookUpEdit.EditValue = Row("addressLegalCountryId")
        End If
        AddressLegalTownTextEdit.EditValue = Row("addressLegalTown")
        AddressFactFullButtonEdit.EditValue = Row("addressFactFull")
        AddressFactCountryLookUpEdit.EditValue = Row("addressFactCountryId")
        AddressFactTownTextEdit.EditValue = Row("addressFactTown")
        AddressPostFullButtonEdit.EditValue = Row("addressPostFull")
        AddressPostCountryLookUpEdit.EditValue = Row("addressPostCountryId")
        AddressPostTownTextEdit.EditValue = Row("addressPostTown")
        '
        ' Доступность элементов управления на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        MemberFindBarButtonItem.Enabled = Not bLock
        MemberClearBarButtonItem.Enabled = Not bLock
        NameLongTextEdit.ReadOnly = bLock
        NameShortTextEdit.ReadOnly = bLock
        TypeLookUpEdit.ReadOnly = bLock
        InnButtonEdit.ReadOnly = bLock
        KppTextEdit.ReadOnly = bLock
        PassportSerTextEdit.ReadOnly = bLock
        PassportNumTextEdit.ReadOnly = bLock
        PassportGiveTextEdit.ReadOnly = bLock
        PhoneTextEdit.ReadOnly = bLock
        FaxTextEdit.ReadOnly = bLock
        EmailTextEdit.ReadOnly = bLock
        WebTextEdit.ReadOnly = bLock
        AddressLegalFullTextEdit.ReadOnly = bLock
        AddressLegalCountryLookUpEdit.ReadOnly = bLock
        AddressLegalTownTextEdit.ReadOnly = bLock
        AddressFactFullButtonEdit.ReadOnly = bLock
        AddressFactCountryLookUpEdit.ReadOnly = bLock
        AddressFactTownTextEdit.ReadOnly = bLock
        AddressPostFullButtonEdit.ReadOnly = bLock
        AddressPostCountryLookUpEdit.ReadOnly = bLock
        AddressPostTownTextEdit.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Строка таблицы лиц
        '
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        '
        ' Старая страна юридического адреса активного объекта
        '
        Dim oldCountryId As Integer = C2.ToInt(Row("addressLegalCountryId"))
        '
        ' Данные объекта
        '
        Row("nameLong") = C2.DbText(NameLongTextEdit.EditValue)
        Row("nameShort") = C2.DbText(NameShortTextEdit.EditValue)
        Row("typeId") = C2.DbInt(TypeLookUpEdit.EditValue)
        Row("inn") = C2.DbText(InnButtonEdit.EditValue)
        Row("kpp") = C2.DbText(KppTextEdit.EditValue)
        Row("passportSer") = C2.DbText(PassportSerTextEdit.EditValue)
        Row("passportNum") = C2.DbText(PassportNumTextEdit.EditValue)
        Row("passportGive") = C2.DbText(PassportGiveTextEdit.EditValue)
        Row("phone") = C2.DbText(PhoneTextEdit.EditValue)
        Row("fax") = C2.DbText(FaxTextEdit.EditValue)
        Row("email") = C2.DbText(EmailTextEdit.EditValue)
        Row("web") = C2.DbText(WebTextEdit.EditValue)
        Row("addressLegalFull") = C2.DbText(AddressLegalFullTextEdit.EditValue)
        Row("addressLegalCountryId") = C2.DbInt(AddressLegalCountryLookUpEdit.EditValue)
        Row("addressLegalTown") = C2.DbText(AddressLegalTownTextEdit.EditValue)
        Row("addressFactFull") = C2.DbText(AddressFactFullButtonEdit.EditValue)
        Row("addressFactCountryId") = C2.DbInt(AddressFactCountryLookUpEdit.EditValue)
        Row("addressFactTown") = C2.DbText(AddressFactTownTextEdit.EditValue)
        Row("addressPostFull") = C2.DbText(AddressPostFullButtonEdit.EditValue)
        Row("addressPostCountryId") = C2.DbInt(AddressPostCountryLookUpEdit.EditValue)
        Row("addressPostTown") = C2.DbText(AddressPostTownTextEdit.EditValue)
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckData") = ErrorTable.CheckMemberData(Row, MyKind)
        '
        ' Проверка изменения страны юридического адреса
        '
        If oldCountryId <> C2.ToInt(Row("addressLegalCountryId")) Then
            '
            ' Очистить запреты и ограничения
            '
            With P.Work.MemberEmbargoTable
                .DeleteMember(Row("id"))
                .AcceptChanges()
            End With
            Row("isNotEmbargo") = False
            Row("isCheckEmbargo") = False
            '
            ' Очистить фирмы на контроле
            '
            With P.Work.MemberControlTable
                .DeleteMember(Row("id"))
                .AcceptChanges()
            End With
            Row("isNotControl") = False
            Row("isCheckControl") = False
            '
            ' Очистить риски
            '
            With P.Work.MemberRiskTable
                .DeleteMember(Row("id"))
                .AcceptChanges()
            End With
            Row("isNotConNusRisk") = False
            Row("isCheckConNusRisk") = False
            Row("isNotSupNusRisk") = False
            Row("isCheckSupNusRisk") = False
            Row("isNotSupEndRisk") = False
            Row("isCheckSupEndRisk") = False
        End If
        P.Work.MemberTable.AcceptChanges()
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property MemberId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Вид объекта
    ''' </summary>
    Private MyKind As MK = MK.IsEmpty

    ''' <summary>
    ''' Порядковый номер объекта в списке объектов
    ''' </summary>
    Private MyRowNum As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Таблица ошибок для проверки данных
    ''' </summary>
    Private ErrorTable As ErrorDataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    ''' <param name="memberKind">Вид лица</param> 
    Public Sub New(ParentControl As WorkUserControl, memberKind As Cprp.DxData.Member.MemberKind)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyKind = memberKind
        Select Case MyKind
            Case Cprp.DxData.Member.MemberKind.IsContractRus : MyBase.Content = ContentEnum.ContractRusData
            Case Cprp.DxData.Member.MemberKind.IsContractNus : MyBase.Content = ContentEnum.ContractNusData
            Case Cprp.DxData.Member.MemberKind.IsSupplyRus : MyBase.Content = ContentEnum.SupplyRusData
            Case Cprp.DxData.Member.MemberKind.IsSupplyNus : MyBase.Content = ContentEnum.SupplyNusData
            Case Cprp.DxData.Member.MemberKind.IsSupplyEnd : MyBase.Content = ContentEnum.SupplyEndData
        End Select
        Select Case MyBase.Content
            Case ContentEnum.ContractRusData, ContentEnum.SupplyRusData
                AddressLegalCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable
                AddressFactCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable
                AddressPostCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable
                AddressLegalCountryLookUpEdit.EditValue = P.Work.CountryHandbookTable.RussiaID
                OpenEmbargoBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                OpenControlBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                AddressLegalCountryLookUpEdit.Enabled = False
            Case Else
                AddressLegalCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable.NotRusView
                AddressFactCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable.NotRusView
                AddressPostCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable.NotRusView
                InnKppLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
        TypeLookUpEdit.Properties.DataSource = P.Work.MemberTypeHandbookTable
        AddressTabbedControlGroup.SelectedTabPage = AddressLegalLayoutControlGroup
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
    End Sub

    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        Select Case MyBase.Content
            Case ContentEnum.ContractRusData : P.ContentOpen(ContentEnum.ContractRusList, MyClass.MemberId)
            Case ContentEnum.ContractNusData : P.ContentOpen(ContentEnum.ContractNusList, MyClass.MemberId)
            Case ContentEnum.SupplyRusData : P.ContentOpen(ContentEnum.SupplyRusList, MyClass.MemberId)
            Case ContentEnum.SupplyNusData : P.ContentOpen(ContentEnum.SupplyNusList, MyClass.MemberId)
            Case ContentEnum.SupplyEndData : P.ContentOpen(ContentEnum.SupplyEndList, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к запретам и ограничениям
    Private Sub OpenEmbargoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenEmbargoBarButtonItem.ItemClick
        Select Case MyBase.Content
            Case ContentEnum.ContractNusData : P.ContentOpen(ContentEnum.ContractNusEmbargo, MyClass.MemberId)
            Case ContentEnum.SupplyNusData : P.ContentOpen(ContentEnum.SupplyNusEmbargo, MyClass.MemberId)
            Case ContentEnum.SupplyEndData : P.ContentOpen(ContentEnum.SupplyEndEmbargo, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к фирмам на контроле
    Private Sub OpenControlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenControlBarButtonItem.ItemClick
        Select Case MyBase.Content
            Case ContentEnum.ContractNusData : P.ContentOpen(ContentEnum.ContractNusControl, MyClass.MemberId)
            Case ContentEnum.SupplyNusData : P.ContentOpen(ContentEnum.SupplyNusControl, MyClass.MemberId)
            Case ContentEnum.SupplyEndData : P.ContentOpen(ContentEnum.SupplyEndControl, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к профилю
    Private Sub OpenProfileBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenProfileBarButtonItem.ItemClick
        Select Case MyBase.Content
            Case ContentEnum.ContractRusData : P.ContentOpen(ContentEnum.ContractRusProfile, MyClass.MemberId)
            Case ContentEnum.ContractNusData : P.ContentOpen(ContentEnum.ContractNusProfile, MyClass.MemberId)
            Case ContentEnum.SupplyRusData : P.ContentOpen(ContentEnum.SupplyRusProfile, MyClass.MemberId)
            Case ContentEnum.SupplyNusData : P.ContentOpen(ContentEnum.SupplyNusProfile, MyClass.MemberId)
            Case ContentEnum.SupplyEndData : P.ContentOpen(ContentEnum.SupplyEndProfile, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к рискам
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        Select Case MyBase.Content
            Case ContentEnum.ContractRusData : P.ContentOpen(ContentEnum.ContractRusRisk, MyClass.MemberId)
            Case ContentEnum.ContractNusData : P.ContentOpen(ContentEnum.ContractNusRisk, MyClass.MemberId)
            Case ContentEnum.SupplyRusData : P.ContentOpen(ContentEnum.SupplyRusRisk, MyClass.MemberId)
            Case ContentEnum.SupplyNusData : P.ContentOpen(ContentEnum.SupplyNusRisk, MyClass.MemberId)
            Case ContentEnum.SupplyEndData : P.ContentOpen(ContentEnum.SupplyEndRisk, MyClass.MemberId)
        End Select
    End Sub

    ' Поиск объекта в базе данных
    Private Sub MemberFindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberFindBarButtonItem.ItemClick
        DataWrite()
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        Using M As Cprp.DxData.Member.MemberDataTable = Cprp.DxData.Member.Common.Find(MyKind, P.Work.Connection, Row)
            If M Is Nothing Then Exit Sub
            '
            ' Реквизиты (включая профиль)
            '
            Row("nameLong") = M(0)("nameLong")
            Row("nameShort") = M(0)("nameShort")
            Row("typeId") = M(0)("typeId")
            Row("inn") = M(0)("inn")
            Row("kpp") = M(0)("kpp")
            Row("passportSer") = M(0)("passportSer")
            Row("passportNum") = M(0)("passportNum")
            Row("passportGive") = M(0)("passportGive")
            Row("phone") = M(0)("phone")
            Row("fax") = M(0)("fax")
            Row("email") = M(0)("email")
            Row("web") = M(0)("web")
            Row("addressLegalFull") = M(0)("addressLegalFull")
            Row("addressLegalCountryId") = M(0)("addressLegalCountryId")
            Row("addressLegalTown") = M(0)("addressLegalTown")
            Row("addressFactFull") = M(0)("addressFactFull")
            Row("addressFactCountryId") = M(0)("addressFactCountryId")
            Row("addressFactTown") = M(0)("addressFactTown")
            Row("addressFactTown") = M(0)("addressFactTown")
            Row("addressPostCountryId") = M(0)("addressPostCountryId")
            Row("addressPostTown") = M(0)("addressPostTown")
            Row("proDescription") = M(0)("proDescription")
            Row("proSource") = M(0)("proSource")
            Row("isControl") = M(0)("isControl")
            '
            ' ID объекта в базе данных
            '
            Dim dbId As Integer = C2.ToInt(M(0)("id"))
            '
            ' Запреты и ограничения
            '
            P.Work.MemberEmbargoTable.DeleteMember(MyClass.MemberId)
            Using Dr As SqlDataReader = P.Work.ExecuteReader( _
                String.Format("SELECT embargoMemberId FROM tMemberEmbargo WHERE memberId = {0}", dbId))
                While Dr.Read
                    P.Work.MemberEmbargoTable.Rows.Add(New Object() {MyClass.MemberId, Dr(0)})
                End While
            End Using
            '
            ' Фирмы на контроле
            '
            P.Work.MemberControlTable.DeleteMember(MyClass.MemberId)
            Using Dr As SqlDataReader = P.Work.ExecuteReader( _
                String.Format("SELECT controlMemberId FROM tMemberControl WHERE memberId = {0}", dbId))
                While Dr.Read
                    P.Work.MemberControlTable.Rows.Add(New Object() {MyClass.MemberId, Dr(0)})
                End While
            End Using
            '
            ' Риски
            '
            P.Work.MemberRiskTable.DeleteMember(MyClass.MemberId)
            Using Dr As SqlDataReader = P.Work.ExecuteReader( _
                String.Format("SELECT riskId FROM tMemberRisk WHERE memberId = {0}", dbId))
                While Dr.Read
                    P.Work.MemberRiskTable.Rows.Add(New Object() {MyClass.MemberId, Dr(0)})
                End While
            End Using
        End Using
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    ' Очистить реквизиты объекта
    Private Sub MemberClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberClearBarButtonItem.ItemClick
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Очистить реквизиты объекта от всех данных?") <> DialogResult.Yes Then Exit Sub
        Row("nameLong") = DBNull.Value
        Row("nameShort") = DBNull.Value
        Row("typeId") = Cprp.DxData.Member.MemberType.IsLegal
        Row("inn") = DBNull.Value
        Row("kpp") = DBNull.Value
        Row("passportSer") = DBNull.Value
        Row("passportNum") = DBNull.Value
        Row("passportGive") = DBNull.Value
        Row("phone") = DBNull.Value
        Row("fax") = DBNull.Value
        Row("email") = DBNull.Value
        Row("web") = DBNull.Value
        Row("addressLegalFull") = DBNull.Value
        If MyKind <> Member.MemberKind.IsContractRus AndAlso MyKind <> Member.MemberKind.IsSupplyRus Then
            Row("addressLegalCountryId") = DBNull.Value
        End If
        Row("addressLegalTown") = DBNull.Value
        Row("addressFactFull") = DBNull.Value
        Row("addressFactCountryId") = DBNull.Value
        Row("addressFactTown") = DBNull.Value
        Row("addressPostFull") = DBNull.Value
        Row("addressPostCountryId") = DBNull.Value
        Row("addressPostTown") = DBNull.Value
        Row("proDescription") = DBNull.Value
        Row("proSource") = DBNull.Value
        Row("isControl") = False
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    ' Скопировать данные юридического адреса в фактический
    Private Sub AddressFactFullButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles AddressFactFullButtonEdit.ButtonClick
        DataWrite()
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        Row("addressFactFull") = Row("addressLegalFull")
        Row("addressFactCountryId") = Row("addressLegalCountryId")
        Row("addressFactTown") = Row("addressLegalTown")
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    ' Скопировать данные юридического адреса в почтовый
    Private Sub AddressPostFullButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles AddressPostFullButtonEdit.ButtonClick
        DataWrite()
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        Row("addressPostFull") = Row("addressLegalFull")
        Row("addressPostCountryId") = Row("addressLegalCountryId")
        Row("addressPostTown") = Row("addressLegalTown")
        DataRead()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub NameLongTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NameLongTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub NameShortTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles NameShortTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub TypeLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TypeLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub InnTextEdit_EditValueChanged(sender As Object, e As EventArgs)
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub KppTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles KppTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub PassportNumTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PassportNumTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub PassportSerTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PassportSerTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub PassportGiveTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PassportGiveTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub PhoneTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles PhoneTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub FaxTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles FaxTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub EmailTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles EmailTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub WebTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles WebTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub AddressLegalFullTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AddressLegalFullTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub AddressLegalCountryLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AddressLegalCountryLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub AddressLegalTownTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AddressLegalTownTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    ' Заполнить профиль российского лица
    Private Sub InnButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles InnButtonEdit.ButtonClick
        Dim inn = C2.ToText(InnButtonEdit.EditValue)
        If String.IsNullOrWhiteSpace(inn) Then
            Cprp.DxCommon.Messages.ShowError("Укажите ИНН!")
            Exit Sub
        End If
        If inn.Length <> 10 Then
            Cprp.DxCommon.Messages.ShowError("Некорректный ИНН!")
            Exit Sub
        End If
        For Each c As Char In inn
            If Not c Like "[0123456789]" Then
                Cprp.DxCommon.Messages.ShowError("Некорректный ИНН!")
                Exit Sub
            End If
        Next
        DataWrite()
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        Row("inn") = inn
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        P.Work.MemberTable.GetRusProfileHtml(Row, P.Work.Connection, True)
        DataRead()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

End Class
