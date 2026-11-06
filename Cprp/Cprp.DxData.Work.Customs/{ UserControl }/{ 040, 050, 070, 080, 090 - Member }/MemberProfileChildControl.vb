Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
''' <summary>
''' Элемент управления "Лицо > Профиль"
''' </summary>
Friend Class MemberProfileChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenProfileBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ProSourceMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ProDescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SourceLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SplitterItem2 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents ProfileWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents ProfileLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemberProfileChildControl))
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenProfileBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ProfileWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.ProSourceMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.ProDescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DescriptionLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SourceLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SplitterItem2 = New DevExpress.XtraLayout.SplitterItem()
        Me.ProfileLayoutControlItem = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ProSourceMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProDescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SourceLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProfileLayoutControlItem, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenProfileBarCheckItem, Me.OpenDataBarButtonItem, Me.OpenRiskBarButtonItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarButtonItem})
        Me.BarManager1.MaxItemId = 8
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(60, 153)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenProfileBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        Me.OpenDataBarButtonItem.Id = 4
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
        Me.OpenEmbargoBarButtonItem.Id = 6
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
        Me.OpenControlBarButtonItem.Id = 7
        Me.OpenControlBarButtonItem.Name = "OpenControlBarButtonItem"
        ToolTipTitleItem4.Text = "На контроле"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к фирмам на контроле"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenProfileBarCheckItem
        '
        Me.OpenProfileBarCheckItem.BindableChecked = True
        Me.OpenProfileBarCheckItem.Caption = "ПРОФИЛЬ"
        Me.OpenProfileBarCheckItem.Checked = True
        Me.OpenProfileBarCheckItem.Glyph = CType(resources.GetObject("OpenProfileBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenProfileBarCheckItem.GroupIndex = 1
        Me.OpenProfileBarCheckItem.Id = 2
        Me.OpenProfileBarCheckItem.Name = "OpenProfileBarCheckItem"
        '
        'OpenRiskBarButtonItem
        '
        Me.OpenRiskBarButtonItem.Caption = "РИСКИ"
        Me.OpenRiskBarButtonItem.Glyph = CType(resources.GetObject("OpenRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarButtonItem.Id = 5
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
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.ProfileWebBrowser)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.ProSourceMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.ProDescriptionMemoEdit)
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
        'ProfileWebBrowser
        '
        Me.ProfileWebBrowser.Location = New System.Drawing.Point(12, 96)
        Me.ProfileWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ProfileWebBrowser.Name = "ProfileWebBrowser"
        Me.ProfileWebBrowser.Size = New System.Drawing.Size(926, 106)
        Me.ProfileWebBrowser.TabIndex = 20
        '
        'ProSourceMemoEdit
        '
        Me.ProSourceMemoEdit.Location = New System.Drawing.Point(12, 622)
        Me.ProSourceMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.ProSourceMemoEdit.Name = "ProSourceMemoEdit"
        Me.ProSourceMemoEdit.Size = New System.Drawing.Size(900, 45)
        Me.ProSourceMemoEdit.StyleController = Me.LayoutControl1
        Me.ProSourceMemoEdit.TabIndex = 19
        '
        'ProDescriptionMemoEdit
        '
        Me.ProDescriptionMemoEdit.Location = New System.Drawing.Point(25, 246)
        Me.ProDescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.ProDescriptionMemoEdit.Name = "ProDescriptionMemoEdit"
        Me.ProDescriptionMemoEdit.Size = New System.Drawing.Size(900, 346)
        Me.ProDescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.ProDescriptionMemoEdit.TabIndex = 18
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem3, Me.DescriptionLayoutControlGroup, Me.SourceLayoutControlGroup, Me.SimpleSeparator1, Me.SplitterItem2, Me.ProfileLayoutControlItem})
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
        Me.CaptionSimpleLabelItem.Text = "Профиль"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(930, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'DescriptionLayoutControlGroup
        '
        Me.DescriptionLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 194)
        Me.DescriptionLayoutControlGroup.Name = "DescriptionLayoutControlGroup"
        Me.DescriptionLayoutControlGroup.Size = New System.Drawing.Size(930, 403)
        Me.DescriptionLayoutControlGroup.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 8, 2)
        Me.DescriptionLayoutControlGroup.Text = "Профиль фирмы"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ProDescriptionMemoEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(904, 350)
        Me.LayoutControlItem1.Text = "Сведения"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'SourceLayoutControlGroup
        '
        Me.SourceLayoutControlGroup.Expanded = False
        Me.SourceLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.SourceLayoutControlGroup.Location = New System.Drawing.Point(0, 610)
        Me.SourceLayoutControlGroup.Name = "SourceLayoutControlGroup"
        Me.SourceLayoutControlGroup.Size = New System.Drawing.Size(930, 30)
        Me.SourceLayoutControlGroup.Text = "Источник данных для заполнения профиля"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ProSourceMemoEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(904, 49)
        Me.LayoutControlItem2.Text = "Источник"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 83)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 597)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(930, 13)
        '
        'ProfileLayoutControlItem
        '
        Me.ProfileLayoutControlItem.Control = Me.ProfileWebBrowser
        Me.ProfileLayoutControlItem.Location = New System.Drawing.Point(0, 84)
        Me.ProfileLayoutControlItem.Name = "ProfileLayoutControlItem"
        Me.ProfileLayoutControlItem.Size = New System.Drawing.Size(930, 110)
        Me.ProfileLayoutControlItem.Text = "Профиль"
        Me.ProfileLayoutControlItem.TextSize = New System.Drawing.Size(0, 0)
        Me.ProfileLayoutControlItem.TextVisible = False
        '
        'MemberProfileChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MemberProfileChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ProSourceMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProDescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SourceLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProfileLayoutControlItem, System.ComponentModel.ISupportInitialize).EndInit()
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
        Dim sTmp As String = "Профиль"
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
        CaptionSimpleLabelItem.Text = String.Format("{0} > Объект № {1} > Профиль", sTmp, MyRowNum)
        '
        ' Профиль, Источник данных для заполнения профиля
        '
        ProDescriptionMemoEdit.EditValue = Row("proDescription")
        ProSourceMemoEdit.EditValue = Row("proSource")
        ProfileWebBrowser.DocumentText = C2.ToText(Row("proDescription"))
        '
        ' Доступность элементов управления на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        ProDescriptionMemoEdit.Properties.ReadOnly = bLock
        ProSourceMemoEdit.Properties.ReadOnly = bLock
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
        ' Данные объекта
        '
        Row("proDescription") = C2.DbText(ProDescriptionMemoEdit.EditValue)
        Row("proSource") = C2.DbText(ProSourceMemoEdit.EditValue)
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckProfile") = ErrorTable.CheckMemberProfile(Row, MyKind)
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
            Case MK.IsContractRus
                MyBase.Content = ContentEnum.ContractRusProfile
                OpenEmbargoBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                OpenControlBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                DescriptionLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SourceLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SplitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ProfileLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case MK.IsContractNus
                MyBase.Content = ContentEnum.ContractNusProfile
                DescriptionLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                SourceLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                SplitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ProfileLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SourceLayoutControlGroup.Expanded = True
            Case MK.IsSupplyRus
                MyBase.Content = ContentEnum.SupplyRusProfile
                OpenEmbargoBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                OpenControlBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                DescriptionLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SourceLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SplitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ProfileLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case MK.IsSupplyNus
                MyBase.Content = ContentEnum.SupplyNusProfile
                DescriptionLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                SourceLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                SplitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ProfileLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SourceLayoutControlGroup.Expanded = True
            Case MK.IsSupplyEnd
                MyBase.Content = ContentEnum.SupplyEndProfile
                DescriptionLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                SourceLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                SplitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ProfileLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                SourceLayoutControlGroup.Expanded = True
        End Select
        ProDescriptionMemoEdit.Properties.NullValuePrompt = ChildUserControl.PROFILE_DESCRIPTION
        ProSourceMemoEdit.Properties.NullValuePrompt = ChildUserControl.PROFILE_SOURCE
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
    End Sub

    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        Select Case MyKind
            Case MK.IsContractRus : P.ContentOpen(ContentEnum.ContractRusList, MyClass.MemberId)
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusList, MyClass.MemberId)
            Case MK.IsSupplyRus : P.ContentOpen(ContentEnum.SupplyRusList, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusList, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndList, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к регистрационным данным
    Private Sub OpenDataBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenDataBarButtonItem.ItemClick
        Select Case MyKind
            Case MK.IsContractRus : P.ContentOpen(ContentEnum.ContractRusData, MyClass.MemberId)
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusData, MyClass.MemberId)
            Case MK.IsSupplyRus : P.ContentOpen(ContentEnum.SupplyRusData, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusData, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndData, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к запретам и ограничениям
    Private Sub OpenEmbargoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenEmbargoBarButtonItem.ItemClick
        Select Case MyKind
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusEmbargo, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusEmbargo, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndEmbargo, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к фирмам на контроле
    Private Sub OpenControlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenControlBarButtonItem.ItemClick
        Select Case MyKind
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusControl, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusControl, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndControl, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к рискам
    Private Sub OpenBarRiskButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        Select Case MyKind
            Case MK.IsContractRus : P.ContentOpen(ContentEnum.ContractRusRisk, MyClass.MemberId)
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusRisk, MyClass.MemberId)
            Case MK.IsSupplyRus : P.ContentOpen(ContentEnum.SupplyRusRisk, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusRisk, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndRisk, MyClass.MemberId)
        End Select
    End Sub

    Private Sub ProDescriptionMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ProDescriptionMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ProSourceMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ProSourceMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ProfileWebBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles ProfileWebBrowser.Navigating
        '
        ' Адрес ресурса
        '
        Dim strUrl As String = e.Url.ToString.ToUpper
        '
        ' Открыть работу
        '
        If strUrl Like "*OPEN_WORK_*" Then
            e.Cancel = True
            If Me.ParentForm Is Nothing OrElse Not TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then Exit Sub
            Dim Arr() As String = e.Url.ToString.Split(New Char() {"_"}, StringSplitOptions.RemoveEmptyEntries)
            If Arr.Length < 3 OrElse Not IsNumeric(Arr(2)) Then Exit Sub
            CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildOpen(CInt(Arr(2)))
        End If
    End Sub

End Class
