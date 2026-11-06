Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Внешнеэкономическая сделка > Регистрационные данные"
''' </summary>
Friend Class ContractDataChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents ContractClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ContractFindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NotContractBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents NotTermCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DocTermDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DocDateDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DocNumTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DocNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents DocLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents DescriptionLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager


    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContractDataChildControl))
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.NotContractBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.ContractFindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ContractClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.DescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.NotTermCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.DocTermDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.DocDateDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.DocNumTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.DocNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.DocLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.DescriptionLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotTermCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNumTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.NotContractBarCheckItem, Me.ContractFindBarButtonItem, Me.ContractClearBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenRiskBarButtonItem})
        Me.BarManager1.MaxItemId = 9
        '
        'Bar1
        '
        Me.Bar1.BarName = "Документ - основание сделки"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(79, 162)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.NotContractBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ContractFindBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.ContractClearBarButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Документ - основание сделки"
        '
        'NotContractBarCheckItem
        '
        Me.NotContractBarCheckItem.Caption = "БЕЗ ДОГОВОРА"
        Me.NotContractBarCheckItem.Id = 0
        Me.NotContractBarCheckItem.Name = "NotContractBarCheckItem"
        ToolTipTitleItem1.Text = "Без договора"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Документ - основание сделки отсутствует"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.NotContractBarCheckItem.SuperTip = SuperToolTip1
        '
        'ContractFindBarButtonItem
        '
        Me.ContractFindBarButtonItem.Caption = "Поиск"
        Me.ContractFindBarButtonItem.Glyph = CType(resources.GetObject("ContractFindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ContractFindBarButtonItem.Id = 1
        Me.ContractFindBarButtonItem.Name = "ContractFindBarButtonItem"
        ToolTipTitleItem2.Text = "Поиск"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Поиск сделки в базе данных по указанным реквизитам"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ContractFindBarButtonItem.SuperTip = SuperToolTip2
        '
        'ContractClearBarButtonItem
        '
        Me.ContractClearBarButtonItem.Caption = "Очистить"
        Me.ContractClearBarButtonItem.Glyph = CType(resources.GetObject("ContractClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ContractClearBarButtonItem.Id = 2
        Me.ContractClearBarButtonItem.Name = "ContractClearBarButtonItem"
        ToolTipTitleItem3.Text = "Очистить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Очистить реквизиты документа - основания сделки"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.ContractClearBarButtonItem.SuperTip = SuperToolTip3
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 94)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Главное меню"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(76, 154)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Главное меню"
        '
        'OpenDataBarButtonItem
        '
        Me.OpenDataBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.OpenDataBarButtonItem.Caption = "РЕГИСТРАЦИОННЫЕ ДАННЫЕ"
        Me.OpenDataBarButtonItem.Down = True
        Me.OpenDataBarButtonItem.Glyph = CType(resources.GetObject("OpenDataBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarButtonItem.GroupIndex = 1
        Me.OpenDataBarButtonItem.Id = 6
        Me.OpenDataBarButtonItem.Name = "OpenDataBarButtonItem"
        '
        'OpenRiskBarButtonItem
        '
        Me.OpenRiskBarButtonItem.Caption = "РИСКИ"
        Me.OpenRiskBarButtonItem.Glyph = CType(resources.GetObject("OpenRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarButtonItem.Id = 7
        Me.OpenRiskBarButtonItem.Name = "OpenRiskBarButtonItem"
        ToolTipTitleItem4.Text = "Риски"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к рискам"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenRiskBarButtonItem.SuperTip = SuperToolTip4
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(926, 37)
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
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.DescriptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.NotTermCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.DocTermDateEdit)
        Me.LayoutControl1.Controls.Add(Me.DocDateDateEdit)
        Me.LayoutControl1.Controls.Add(Me.DocNumTextEdit)
        Me.LayoutControl1.Controls.Add(Me.DocNameTextEdit)
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
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(24, 337)
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(902, 299)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 16
        '
        'NotTermCheckEdit
        '
        Me.NotTermCheckEdit.Location = New System.Drawing.Point(401, 266)
        Me.NotTermCheckEdit.Name = "NotTermCheckEdit"
        Me.NotTermCheckEdit.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotTermCheckEdit.Properties.Appearance.Options.UseFont = True
        Me.NotTermCheckEdit.Properties.Caption = "Сделка без срока действия (до исполнения обязательств)"
        Me.NotTermCheckEdit.Size = New System.Drawing.Size(525, 20)
        Me.NotTermCheckEdit.StyleController = Me.LayoutControl1
        Me.NotTermCheckEdit.TabIndex = 15
        '
        'DocTermDateEdit
        '
        Me.DocTermDateEdit.EditValue = Nothing
        Me.DocTermDateEdit.Location = New System.Drawing.Point(187, 262)
        Me.DocTermDateEdit.Name = "DocTermDateEdit"
        Me.DocTermDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocTermDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocTermDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.DocTermDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.DocTermDateEdit.Size = New System.Drawing.Size(210, 28)
        Me.DocTermDateEdit.StyleController = Me.LayoutControl1
        Me.DocTermDateEdit.TabIndex = 8
        '
        'DocDateDateEdit
        '
        Me.DocDateDateEdit.EditValue = Nothing
        Me.DocDateDateEdit.Location = New System.Drawing.Point(187, 230)
        Me.DocDateDateEdit.Name = "DocDateDateEdit"
        Me.DocDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDateDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.DocDateDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.DocDateDateEdit.Size = New System.Drawing.Size(210, 28)
        Me.DocDateDateEdit.StyleController = Me.LayoutControl1
        Me.DocDateDateEdit.TabIndex = 7
        '
        'DocNumTextEdit
        '
        Me.DocNumTextEdit.Location = New System.Drawing.Point(187, 198)
        Me.DocNumTextEdit.Name = "DocNumTextEdit"
        Me.DocNumTextEdit.Size = New System.Drawing.Size(739, 28)
        Me.DocNumTextEdit.StyleController = Me.LayoutControl1
        Me.DocNumTextEdit.TabIndex = 6
        '
        'DocNameTextEdit
        '
        Me.DocNameTextEdit.Location = New System.Drawing.Point(187, 166)
        Me.DocNameTextEdit.Name = "DocNameTextEdit"
        Me.DocNameTextEdit.Properties.NullValuePrompt = "Контракт, договор и т.п."
        Me.DocNameTextEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.DocNameTextEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.DocNameTextEdit.Size = New System.Drawing.Size(739, 28)
        Me.DocNameTextEdit.StyleController = Me.LayoutControl1
        Me.DocNameTextEdit.TabIndex = 5
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.DocLayoutControlGroup, Me.DescriptionLayoutControlGroup, Me.LayoutControlItem9, Me.LayoutControlItem7, Me.SimpleSeparator1})
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
        Me.CaptionSimpleLabelItem.Text = " Внешнеэкономическая сделка > Регистрационные данные"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'DocLayoutControlGroup
        '
        Me.DocLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.DocLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.EmptySpaceItem1})
        Me.DocLayoutControlGroup.Location = New System.Drawing.Point(0, 123)
        Me.DocLayoutControlGroup.Name = "DocLayoutControlGroup"
        Me.DocLayoutControlGroup.Size = New System.Drawing.Size(930, 171)
        Me.DocLayoutControlGroup.Text = "Документ - основание сделки"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AllowHtmlStringInCaption = True
        Me.LayoutControlItem1.Control = Me.DocNameTextEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(906, 32)
        Me.LayoutControlItem1.Text = "Наименование документа<color='red'>*</color>"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(160, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DocNumTextEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(906, 32)
        Me.LayoutControlItem2.Text = "Номер документа"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(160, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DocDateDateEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(377, 32)
        Me.LayoutControlItem3.Text = "Дата документа"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(160, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.NotTermCheckEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(377, 96)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 6, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(529, 32)
        Me.LayoutControlItem5.Text = "Сделка без срока действия"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DocTermDateEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(377, 32)
        Me.LayoutControlItem4.Text = "Срок действия"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(160, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(377, 64)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(529, 32)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'DescriptionLayoutControlGroup
        '
        Me.DescriptionLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.DescriptionLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 294)
        Me.DescriptionLayoutControlGroup.Name = "DescriptionLayoutControlGroup"
        Me.DescriptionLayoutControlGroup.Size = New System.Drawing.Size(930, 346)
        Me.DescriptionLayoutControlGroup.Text = "Описание предмета сделки<color='red'>*</color>"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.DescriptionMemoEdit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(906, 303)
        Me.LayoutControlItem6.Text = "Предмет сделки"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
        '
        'ContractDataChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ContractDataChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotTermCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNumTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
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
            NotContractBarCheckItem.Checked = .Item("isNotContract")
            DocNameTextEdit.EditValue = .Item("contractName")
            DocNumTextEdit.EditValue = .Item("contractNum")
            DocDateDateEdit.EditValue = .Item("contractDate")
            DocTermDateEdit.EditValue = .Item("contractTerm")
            NotTermCheckEdit.EditValue = .Item("isNotContractTerm")
            DescriptionMemoEdit.EditValue = .Item("contractDescription")
        End With
        '
        ' Доступность элементов на редактирование
        '
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Данные объектов
        '
        With P.Work.ARow
            .Item("isNotContract") = NotContractBarCheckItem.Checked
            '
            ' "Без договора"
            '
            If NotContractBarCheckItem.Checked Then
                .Item("contractName") = DBNull.Value
                .Item("contractNum") = DBNull.Value
                .Item("contractDate") = DBNull.Value
                .Item("contractTerm") = DBNull.Value
                .Item("isNotContractTerm") = False
                .Item("contractDescription") = DBNull.Value
                .Item("isNotContractRisk") = False
                P.Work.ContractRiskTable.Rows.Clear()
                For Each Row As DataRow In P.Work.MemberTable.Rows
                    Row("conRusNum") = 0
                    Row("conNusNum") = 0
                Next
            Else
                .Item("contractName") = C2.DbText(DocNameTextEdit.EditValue)
                .Item("contractNum") = C2.DbText(DocNumTextEdit.EditValue)
                .Item("contractDate") = C2.DbDate(DocDateDateEdit.EditValue)
                If NotTermCheckEdit.Checked Then
                    .Item("isNotContractTerm") = True
                    .Item("contractTerm") = DBNull.Value
                Else
                    .Item("isNotContractTerm") = False
                    .Item("contractTerm") = C2.DbDate(DocTermDateEdit.EditValue)
                End If
                .Item("contractDescription") = C2.DbText(DescriptionMemoEdit.EditValue)
            End If
            .AcceptChanges()
        End With
    End Sub

    ' Доступность элементов на редактирование
    Private Sub LockUpdate()
        Dim bLock As Boolean = Not P.WorkEditableForExpert                      ' Работа не доступна эксперту для редактирования
        Dim bNotContract As Boolean = NotContractBarCheckItem.Checked           ' "Без договора"
        Dim bNotContractTerm As Boolean = NotTermCheckEdit.Checked              ' Срок действия документа - основания сделки отсутствует
        '
        ' Элементы управления
        '
        NotContractBarCheckItem.Enabled = Not bLock
        ContractFindBarButtonItem.Enabled = Not (bLock OrElse bNotContract)
        ContractClearBarButtonItem.Enabled = Not (bLock OrElse bNotContract)
        DocNameTextEdit.Enabled = Not bNotContract
        DocNameTextEdit.Properties.ReadOnly = bLock
        DocNumTextEdit.Enabled = Not bNotContract
        DocNumTextEdit.Properties.ReadOnly = bLock
        DocDateDateEdit.Enabled = Not bNotContract
        DocDateDateEdit.Properties.ReadOnly = bLock
        DocTermDateEdit.Enabled = Not (bNotContract OrElse bNotContractTerm)
        DocTermDateEdit.Properties.ReadOnly = bLock
        NotTermCheckEdit.Enabled = Not bNotContract
        NotTermCheckEdit.Properties.ReadOnly = bLock
        DescriptionMemoEdit.Properties.ReadOnly = (bLock OrElse bNotContract)
        OpenRiskBarButtonItem.Enabled = Not bNotContract
    End Sub

#End Region


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        MyBase.Content = ContentEnum.ContractData
    End Sub

    ' Перейти к рискам
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.ContractRisk, C2.EMPTY_ID)
    End Sub

    ' Без договора
    Private Sub NotContractBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotContractBarCheckItem.CheckedChanged
        LockUpdate()
        If MyBase.IsDataLoaded Then P.Work.ARow("changeDate") = Date.Now
    End Sub

    ' Поиск сделки в базе данных
    Private Sub ContractFindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ContractFindBarButtonItem.ItemClick
        DataWrite()
        Using C As New Cprp.DxData.Contract.ContractDataTable
            C.Rows.Add(C.NewRow)
            With P.Work.ARow
                C(0)("docName") = .Item("contractName")
                C(0)("docNum") = .Item("contractNum")
                C(0)("docDate") = .Item("contractDate")
            End With
            Using C1 As Cprp.DxData.Contract.ContractDataTable = Cprp.DxData.Contract.Common.Find(P.Work.Connection, C.Rows(0))
                If C1 Is Nothing Then Exit Sub
                '
                ' Реквизиты выбранной сделки
                '
                With P.Work.ARow
                    .Item("contractName") = C1(0)("docName")
                    .Item("contractNum") = C1(0)("docNum")
                    .Item("contractDate") = C1(0)("docDate")
                    .Item("contractTerm") = C1(0)("docTerm")
                    .Item("isNotContractTerm") = C1(0)("isNotTerm")
                    .Item("contractDescription") = C1(0)("description")
                End With
                '
                ' Участники выбранной сделки
                '
                Dim Row As DataRow = Nothing
                Using T As New DataTable
                    T.Load(P.Work.ExecuteReader(String.Format("SELECT * FROM vContractMember WHERE contractId = {0}", CInt(C1(0)("id")))))
                    For i As Integer = 0 To T.Rows.Count - 1
                        If CType(T(i)("kindId"), Cprp.DxData.Member.MemberKind) = DxData.Member.MemberKind.IsContractRus Then
                            Row = P.Work.MemberTable.AddNew(Cprp.DxData.Member.MemberKind.IsContractRus)
                        Else
                            Row = P.Work.MemberTable.AddNew(Cprp.DxData.Member.MemberKind.IsContractNus)
                        End If
                        Row("nameLong") = T(i)("nameLong")
                        Row("nameShort") = T(i)("nameShort")
                        Row("typeId") = T(i)("typeId")
                        Row("inn") = T(i)("inn")
                        Row("kpp") = T(i)("kpp")
                        Row("passportSer") = T(i)("passportSer")
                        Row("passportNum") = T(i)("passportNum")
                        Row("passportGive") = T(i)("passportGive")
                        Row("phone") = T(i)("phone")
                        Row("fax") = T(i)("fax")
                        Row("email") = T(i)("email")
                        Row("web") = T(i)("web")
                        Row("addressLegalFull") = T(i)("addressLegalFull")
                        Row("addressLegalCountryId") = T(i)("addressLegalCountryId")
                        Row("addressLegalTown") = T(i)("addressLegalTown")
                        Row("addressFactFull") = T(i)("addressFactFull")
                        Row("addressFactCountryId") = T(i)("addressFactCountryId")
                        Row("addressFactTown") = T(i)("addressFactTown")
                        Row("addressFactTown") = T(i)("addressFactTown")
                        Row("addressPostCountryId") = T(i)("addressPostCountryId")
                        Row("addressPostTown") = T(i)("addressPostTown")
                        Row("proDescription") = T(i)("proDescription")
                        Row("proSource") = T(i)("proSource")
                        Row("isControl") = T(i)("isControl")
                        '
                        ' Запреты и ограничения текущего участника
                        '
                        Using Dr As SqlDataReader = P.Work.ExecuteReader(String.Format("SELECT * FROM tMemberEmbargo WHERE memberId = {0}", CInt(T(i)("memberId"))))
                            While Dr.Read
                                P.Work.MemberEmbargoTable.Rows.Add(New Object() {Row("id"), Dr("embargoMemberId")})
                            End While
                        End Using
                        '
                        ' Фирмы на контроле текущего участника
                        '
                        Using Dr As SqlDataReader = P.Work.ExecuteReader(String.Format("SELECT * FROM tMemberControl WHERE memberId = {0}", CInt(T(i)("memberId"))))
                            While Dr.Read
                                P.Work.MemberControlTable.Rows.Add(New Object() {Row("id"), Dr("controlMemberId")})
                            End While
                        End Using
                        '
                        ' Признаки риска текущего участника
                        '
                        Using Dr As SqlDataReader = P.Work.ExecuteReader(String.Format("SELECT * FROM tMemberRisk WHERE memberId = {0}", CInt(T(i)("memberId"))))
                            While Dr.Read
                                P.Work.MemberRiskTable.Rows.Add(New Object() {Row("id"), Dr("riskId")})
                            End While
                        End Using
                    Next
                End Using
            End Using
        End Using

        DataRead()
        LockUpdate()
    End Sub

    ' Очистить реквизиты сделки
    Private Sub ContractClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ContractClearBarButtonItem.ItemClick
        With P.Work.ARow
            .Item("contractName") = DBNull.Value
            .Item("contractNum") = DBNull.Value
            .Item("contractDate") = DBNull.Value
            .Item("contractTerm") = DBNull.Value
            .Item("isNotContractTerm") = False
            .Item("contractDescription") = DBNull.Value
        End With
        DataRead()
        LockUpdate()
    End Sub

    ' Сделка без срока действия
    Private Sub NotTermCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles NotTermCheckEdit.CheckedChanged
        LockUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DocNameTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DocNameTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DocNumTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DocNumTextEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DocDateDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DocDateDateEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DocTermDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DocTermDateEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub DescriptionMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DescriptionMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
