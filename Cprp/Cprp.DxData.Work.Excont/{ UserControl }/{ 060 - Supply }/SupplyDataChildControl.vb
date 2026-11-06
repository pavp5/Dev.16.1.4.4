Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Внешнеэкономическая операция > Регистрационные данные"
''' </summary>
Friend Class SupplyDataChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents InvoiceTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TypeLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CountryLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents IncotermsPlaceTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents IncotermsLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents IncotermsLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CountryButtonEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BankCountryLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SupplyDataChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.BankCountryLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.CountryButtonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.IncotermsPlaceTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.IncotermsLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.DescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.InvoiceTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.TypeLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DescriptionLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CountryLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.IncotermsLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.BankCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryButtonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncotermsPlaceTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncotermsLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncotermsLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenDataBarButtonItem, Me.OpenRiskBarButtonItem})
        Me.BarManager1.MaxItemId = 5
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(93, 378)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'OpenDataBarButtonItem
        '
        Me.OpenDataBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.OpenDataBarButtonItem.Caption = "РЕГИСТРАЦИОННЫК ДАННЫЕ"
        Me.OpenDataBarButtonItem.Down = True
        Me.OpenDataBarButtonItem.Glyph = CType(resources.GetObject("OpenDataBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarButtonItem.GroupIndex = 1
        Me.OpenDataBarButtonItem.Id = 3
        Me.OpenDataBarButtonItem.Name = "OpenDataBarButtonItem"
        '
        'OpenRiskBarButtonItem
        '
        Me.OpenRiskBarButtonItem.Caption = "РИСКИ"
        Me.OpenRiskBarButtonItem.Glyph = CType(resources.GetObject("OpenRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarButtonItem.Id = 4
        Me.OpenRiskBarButtonItem.Name = "OpenRiskBarButtonItem"
        ToolTipTitleItem1.Text = "Риски"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к рискам"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.OpenRiskBarButtonItem.SuperTip = SuperToolTip1
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(13, 53)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(903, 47)
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
        Me.LayoutControl1.Controls.Add(Me.BankCountryLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.CountryButtonEdit)
        Me.LayoutControl1.Controls.Add(Me.IncotermsPlaceTextEdit)
        Me.LayoutControl1.Controls.Add(Me.IncotermsLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.DescriptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.InvoiceTextEdit)
        Me.LayoutControl1.Controls.Add(Me.TypeLookUpEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 419, 500, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BankCountryLookUpEdit
        '
        Me.BankCountryLookUpEdit.Location = New System.Drawing.Point(28, 330)
        Me.BankCountryLookUpEdit.Name = "BankCountryLookUpEdit"
        Me.BankCountryLookUpEdit.Properties.AllowMouseWheel = False
        Me.BankCountryLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BankCountryLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.BankCountryLookUpEdit.Properties.DisplayMember = "nameShort"
        Me.BankCountryLookUpEdit.Properties.DropDownRows = 10
        Me.BankCountryLookUpEdit.Properties.NullText = ""
        Me.BankCountryLookUpEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.BankCountryLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.BankCountryLookUpEdit.Properties.ShowFooter = False
        Me.BankCountryLookUpEdit.Properties.ShowHeader = False
        Me.BankCountryLookUpEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.BankCountryLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.BankCountryLookUpEdit.Properties.ValueMember = "id"
        Me.BankCountryLookUpEdit.Size = New System.Drawing.Size(873, 32)
        Me.BankCountryLookUpEdit.StyleController = Me.LayoutControl1
        Me.BankCountryLookUpEdit.TabIndex = 32
        '
        'CountryButtonEdit
        '
        Me.CountryButtonEdit.Location = New System.Drawing.Point(28, 238)
        Me.CountryButtonEdit.MenuManager = Me.BarManager1
        Me.CountryButtonEdit.Name = "CountryButtonEdit"
        Me.CountryButtonEdit.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CountryButtonEdit.Properties.Appearance.Options.UseBackColor = True
        Me.CountryButtonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Выбрать", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.CountryButtonEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.CountryButtonEdit.Size = New System.Drawing.Size(873, 32)
        Me.CountryButtonEdit.StyleController = Me.LayoutControl1
        Me.CountryButtonEdit.TabIndex = 30
        '
        'IncotermsPlaceTextEdit
        '
        Me.IncotermsPlaceTextEdit.Location = New System.Drawing.Point(601, 422)
        Me.IncotermsPlaceTextEdit.Name = "IncotermsPlaceTextEdit"
        Me.IncotermsPlaceTextEdit.Size = New System.Drawing.Size(300, 32)
        Me.IncotermsPlaceTextEdit.StyleController = Me.LayoutControl1
        Me.IncotermsPlaceTextEdit.TabIndex = 26
        '
        'IncotermsLookUpEdit
        '
        Me.IncotermsLookUpEdit.Location = New System.Drawing.Point(161, 422)
        Me.IncotermsLookUpEdit.Name = "IncotermsLookUpEdit"
        Me.IncotermsLookUpEdit.Properties.AllowMouseWheel = False
        ToolTipTitleItem2.Text = "Очистить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Очистить поле"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.IncotermsLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, SuperToolTip2, True)})
        Me.IncotermsLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameDescription", "nameDescription")})
        Me.IncotermsLookUpEdit.Properties.DisplayMember = "nameDescription"
        Me.IncotermsLookUpEdit.Properties.NullText = ""
        Me.IncotermsLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.IncotermsLookUpEdit.Properties.ShowFooter = False
        Me.IncotermsLookUpEdit.Properties.ShowHeader = False
        Me.IncotermsLookUpEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.IncotermsLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.IncotermsLookUpEdit.Properties.ValueMember = "id"
        Me.IncotermsLookUpEdit.Size = New System.Drawing.Size(301, 32)
        Me.IncotermsLookUpEdit.StyleController = Me.LayoutControl1
        Me.IncotermsLookUpEdit.TabIndex = 25
        '
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(28, 606)
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(873, 45)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 18
        '
        'InvoiceTextEdit
        '
        Me.InvoiceTextEdit.Location = New System.Drawing.Point(28, 514)
        Me.InvoiceTextEdit.Name = "InvoiceTextEdit"
        Me.InvoiceTextEdit.Properties.NullValuePrompt = "Приложение к контракту, инвойс и т.п."
        Me.InvoiceTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.InvoiceTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.InvoiceTextEdit.Size = New System.Drawing.Size(873, 32)
        Me.InvoiceTextEdit.StyleController = Me.LayoutControl1
        Me.InvoiceTextEdit.TabIndex = 17
        '
        'TypeLookUpEdit
        '
        Me.TypeLookUpEdit.Location = New System.Drawing.Point(28, 146)
        Me.TypeLookUpEdit.Name = "TypeLookUpEdit"
        Me.TypeLookUpEdit.Properties.AllowMouseWheel = False
        Me.TypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.TypeLookUpEdit.Properties.DisplayMember = "nameShort"
        Me.TypeLookUpEdit.Properties.DropDownRows = 10
        Me.TypeLookUpEdit.Properties.NullText = ""
        Me.TypeLookUpEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.TypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.TypeLookUpEdit.Properties.ShowFooter = False
        Me.TypeLookUpEdit.Properties.ShowHeader = False
        Me.TypeLookUpEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.TypeLookUpEdit.Properties.ValueMember = "id"
        Me.TypeLookUpEdit.Size = New System.Drawing.Size(873, 32)
        Me.TypeLookUpEdit.StyleController = Me.LayoutControl1
        Me.TypeLookUpEdit.TabIndex = 15
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.DescriptionLayoutControlGroup, Me.CountryLayoutControlGroup, Me.LayoutControlItem6, Me.SimpleSeparator1, Me.IncotermsLayoutControlGroup, Me.LayoutControlGroup3})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(929, 669)
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
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(909, 40)
        Me.CaptionSimpleLabelItem.Text = "Внешнеэкономическая операция > Регистрационные данные"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AllowHtmlStringInCaption = True
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(909, 92)
        Me.LayoutControlGroup1.Text = "Характер внешнеэкономической операции<color='red'>*</color>"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TypeLookUpEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(879, 38)
        Me.LayoutControlItem1.Text = "Характер внешнеэкономической операции"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 462)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(909, 92)
        Me.LayoutControlGroup2.Text = "Документ - основание операции"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.InvoiceTextEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(879, 38)
        Me.LayoutControlItem2.Text = "Документ - основание операции"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'DescriptionLayoutControlGroup
        '
        Me.DescriptionLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.DescriptionLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 554)
        Me.DescriptionLayoutControlGroup.Name = "DescriptionLayoutControlGroup"
        Me.DescriptionLayoutControlGroup.Size = New System.Drawing.Size(909, 105)
        Me.DescriptionLayoutControlGroup.Text = "Описание предмета операции<color='red'>*</color>"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DescriptionMemoEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(879, 51)
        Me.LayoutControlItem3.Text = "Описание предмета операции"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'CountryLayoutControlGroup
        '
        Me.CountryLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.CountryLayoutControlGroup.Location = New System.Drawing.Point(0, 186)
        Me.CountryLayoutControlGroup.Name = "CountryLayoutControlGroup"
        Me.CountryLayoutControlGroup.Size = New System.Drawing.Size(909, 92)
        Me.CountryLayoutControlGroup.Text = "Страна назначения (отправления)"
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CountryButtonEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(879, 38)
        Me.LayoutControlItem8.Text = "Страна назначения (отправления)"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(909, 53)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 93)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(909, 1)
        '
        'IncotermsLayoutControlGroup
        '
        Me.IncotermsLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.IncotermsLayoutControlGroup.Location = New System.Drawing.Point(0, 370)
        Me.IncotermsLayoutControlGroup.Name = "IncotermsLayoutControlGroup"
        Me.IncotermsLayoutControlGroup.Size = New System.Drawing.Size(909, 92)
        Me.IncotermsLayoutControlGroup.Text = "Условие поставки по Инкотермс"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.IncotermsLookUpEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(440, 38)
        Me.LayoutControlItem4.Text = "Условие поставки"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(130, 18)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem5.Control = Me.IncotermsPlaceTextEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(440, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(439, 38)
        Me.LayoutControlItem5.Text = " Место доставки"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(130, 18)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AllowHtmlStringInCaption = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 278)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(909, 92)
        Me.LayoutControlGroup3.Text = "Страна банка<color=red>*</color>"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.BankCountryLookUpEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(879, 38)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'SupplyDataChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "SupplyDataChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.BankCountryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryButtonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncotermsPlaceTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncotermsLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncotermsLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
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
            TypeLookUpEdit.EditValue = .Item("supplyTypeId")
            CountryButtonEdit.Text = C2.ToText(.Item("countryNameString"))
            BankCountryLookUpEdit.EditValue = .Item("bankCountryId")
            IncotermsLookUpEdit.EditValue = .Item("incotermsId")
            IncotermsPlaceTextEdit.EditValue = .Item("incotermsPlace")
            InvoiceTextEdit.EditValue = .Item("invoiceCaption")
            DescriptionMemoEdit.EditValue = .Item("supplyDescription")
        End With
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        TypeLookUpEdit.Properties.ReadOnly = bLock
        CountryButtonEdit.Properties.Buttons(0).Enabled = Not bLock
        InvoiceTextEdit.Properties.ReadOnly = bLock
        DescriptionMemoEdit.Properties.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Данные объекта
        '
        With P.Work.ARow
            .Item("supplyTypeId") = C2.DbInt(TypeLookUpEdit.EditValue)
            .Item("bankCountryId") = C2.DbInt(BankCountryLookUpEdit.EditValue)
            .Item("incotermsId") = C2.DbInt(IncotermsLookUpEdit.EditValue)
            .Item("incotermsPlace") = C2.DbText(IncotermsPlaceTextEdit.EditValue)
            .Item("invoiceCaption") = C2.DbText(InvoiceTextEdit.EditValue)
            .Item("supplyDescription") = C2.DbText(DescriptionMemoEdit.EditValue)
            '
            ' Направление перемещения
            '
            Dim Row As DataRow = P.Work.SupplyTypeHandbookTable.Rows.Find(C2.ToInt(.Item("supplyTypeId")))
            If Not Row Is Nothing Then .Item("modeId") = Row("modeId")
            .AcceptChanges()
        End With
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
        MyBase.Content = ContentEnum.SupplyData
        TypeLookUpEdit.Properties.DataSource = P.Work.SupplyTypeHandbookTable
        BankCountryLookUpEdit.Properties.DataSource = P.Work.CountryHandbookTable
        IncotermsLookUpEdit.Properties.DataSource = P.Work.IncotermsHandbookTable
    End Sub

    ' Перейти к рискам
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.SupplyRisk, C2.EMPTY_ID)
    End Sub

    ' Выбрать страну назначения (отправления)
    Private Sub CountryButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles CountryButtonEdit.ButtonClick
        '
        ' Старая страна назначения (отправления)
        '
        Dim oldCountryIdString As String = C2.ToText(P.Work.ARow("countryIdString"))
        '
        ' Открытие формы выбора
        '
        With New CountrySelectForm(P.Work)
            If .ShowDialog <> DialogResult.OK Then Exit Sub
        End With
        CountryButtonEdit.Text = C2.ToText(P.Work.ARow("countryNameString"))
        MyBase.SetChangeDateNow()
        '
        ' Проверка изменения страны назначения (отправления)
        '
        If oldCountryIdString <> C2.ToText(P.Work.ARow("countryIdString")) Then
            With P.Work.GoodEmbargoTable
                .Rows.Clear()
                .AcceptChanges()
            End With
            With P.Work.GoodTable
                For Each Row As DataRow In .Rows
                    Row("isNotEmbargo") = False
                    Row("isCheckEmbargo") = False
                Next
                .AcceptChanges()
            End With
        End If
    End Sub

    ' Удалить условие поставки
    Private Sub IncotermsLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles IncotermsLookUpEdit.ButtonClick
        If e.Button.Index = 1 Then IncotermsLookUpEdit.EditValue = DBNull.Value
    End Sub

    Private Sub TypeLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TypeLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub IncotermsLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles IncotermsLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub InvoiceTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles InvoiceTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DescriptionMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DescriptionMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
