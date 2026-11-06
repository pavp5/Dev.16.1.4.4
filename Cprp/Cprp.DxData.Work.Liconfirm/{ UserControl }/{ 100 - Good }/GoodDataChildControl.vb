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
    Friend WithEvents OpenLawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TnvedCommentMemoEdit As DevExpress.XtraEditors.MemoEdit
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
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
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
    Friend WithEvents TnvedLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodDataChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenLawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TnvedCommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
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
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
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
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem3 = New DevExpress.XtraLayout.SplitterItem()
        Me.TnvedLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TnvedCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TnvedLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenDataBarCheckItem, Me.OpenLawBarButtonItem})
        Me.BarManager1.MaxItemId = 20
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(63, 154)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarCheckItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        'OpenLawBarButtonItem
        '
        Me.OpenLawBarButtonItem.Caption = "ПРОВЕРКА СООТВЕТСТВИЯ"
        Me.OpenLawBarButtonItem.Glyph = CType(resources.GetObject("OpenLawBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarButtonItem.Id = 15
        Me.OpenLawBarButtonItem.Name = "OpenLawBarButtonItem"
        ToolTipTitleItem2.Text = "Проверка соответствия"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Перейти к проверке соответствия"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.OpenLawBarButtonItem.SuperTip = SuperToolTip2
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(1110, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
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
        Me.LayoutControl1.Controls.Add(Me.TnvedCommentMemoEdit)
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
        'TnvedCommentMemoEdit
        '
        Me.TnvedCommentMemoEdit.Location = New System.Drawing.Point(210, 314)
        Me.TnvedCommentMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.TnvedCommentMemoEdit.Name = "TnvedCommentMemoEdit"
        Me.TnvedCommentMemoEdit.Size = New System.Drawing.Size(900, 45)
        Me.TnvedCommentMemoEdit.StyleController = Me.LayoutControl1
        Me.TnvedCommentMemoEdit.TabIndex = 31
        '
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(24, 626)
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(1086, 45)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 29
        '
        'UsedMemoEdit
        '
        Me.UsedMemoEdit.Location = New System.Drawing.Point(24, 522)
        Me.UsedMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.UsedMemoEdit.Name = "UsedMemoEdit"
        Me.UsedMemoEdit.Size = New System.Drawing.Size(1086, 45)
        Me.UsedMemoEdit.StyleController = Me.LayoutControl1
        Me.UsedMemoEdit.TabIndex = 28
        '
        'AreaMemoEdit
        '
        Me.AreaMemoEdit.Location = New System.Drawing.Point(24, 418)
        Me.AreaMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.AreaMemoEdit.Name = "AreaMemoEdit"
        Me.AreaMemoEdit.Size = New System.Drawing.Size(1086, 45)
        Me.AreaMemoEdit.StyleController = Me.LayoutControl1
        Me.AreaMemoEdit.TabIndex = 27
        '
        'CasTextEdit
        '
        Me.CasTextEdit.Location = New System.Drawing.Point(756, 282)
        Me.CasTextEdit.Name = "CasTextEdit"
        Me.CasTextEdit.Size = New System.Drawing.Size(354, 28)
        Me.CasTextEdit.StyleController = Me.LayoutControl1
        Me.CasTextEdit.TabIndex = 26
        '
        'TnvedTextEdit
        '
        Me.TnvedTextEdit.Location = New System.Drawing.Point(210, 282)
        Me.TnvedTextEdit.Name = "TnvedTextEdit"
        Me.TnvedTextEdit.Size = New System.Drawing.Size(356, 28)
        Me.TnvedTextEdit.StyleController = Me.LayoutControl1
        Me.TnvedTextEdit.TabIndex = 25
        '
        'NotNameDecCheckEdit
        '
        Me.NotNameDecCheckEdit.Location = New System.Drawing.Point(932, 169)
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
        Me.TypeLookUpEdit.Location = New System.Drawing.Point(210, 197)
        Me.TypeLookUpEdit.Name = "TypeLookUpEdit"
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.TypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("codeName", "codeName")})
        Me.TypeLookUpEdit.Properties.DisplayMember = "codeName"
        Me.TypeLookUpEdit.Properties.DropDownRows = 10
        Me.TypeLookUpEdit.Properties.NullText = ""
        Me.TypeLookUpEdit.Properties.ShowFooter = False
        Me.TypeLookUpEdit.Properties.ShowHeader = False
        Me.TypeLookUpEdit.Properties.ValueMember = "id"
        Me.TypeLookUpEdit.Size = New System.Drawing.Size(900, 28)
        Me.TypeLookUpEdit.StyleController = Me.LayoutControl1
        Me.TypeLookUpEdit.TabIndex = 23
        '
        'NameDecTextEdit
        '
        Me.NameDecTextEdit.Location = New System.Drawing.Point(210, 165)
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
        Me.NameConTextEdit.Location = New System.Drawing.Point(210, 133)
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.SimpleSeparator1, Me.AreaLayoutControlGroup, Me.UsedLayoutControlGroup, Me.DescriptionLayoutControlGroup, Me.SplitterItem1, Me.SplitterItem2, Me.RegDataLayoutControlGroup, Me.SplitterItem3, Me.TnvedLayoutControlGroup})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1134, 685)
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
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(1114, 1)
        '
        'AreaLayoutControlGroup
        '
        Me.AreaLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.AreaLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.AreaLayoutControlGroup.Location = New System.Drawing.Point(0, 375)
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
        Me.UsedLayoutControlGroup.Location = New System.Drawing.Point(0, 479)
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
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 583)
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
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 467)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(1114, 12)
        '
        'SplitterItem2
        '
        Me.SplitterItem2.AllowHotTrack = True
        Me.SplitterItem2.Location = New System.Drawing.Point(0, 571)
        Me.SplitterItem2.Name = "SplitterItem2"
        Me.SplitterItem2.Size = New System.Drawing.Size(1114, 12)
        '
        'RegDataLayoutControlGroup
        '
        Me.RegDataLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem4})
        Me.RegDataLayoutControlGroup.Location = New System.Drawing.Point(0, 82)
        Me.RegDataLayoutControlGroup.Name = "RegDataLayoutControlGroup"
        Me.RegDataLayoutControlGroup.Size = New System.Drawing.Size(1114, 147)
        Me.RegDataLayoutControlGroup.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2)
        Me.RegDataLayoutControlGroup.Text = "Регистрационные данные"
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
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.AllowHtmlStringInCaption = True
        Me.LayoutControlItem4.Control = Me.TypeLookUpEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1090, 32)
        Me.LayoutControlItem4.Text = "Категория<color='red'>*</color>"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(183, 16)
        '
        'SplitterItem3
        '
        Me.SplitterItem3.AllowHotTrack = True
        Me.SplitterItem3.Location = New System.Drawing.Point(0, 363)
        Me.SplitterItem3.Name = "SplitterItem3"
        Me.SplitterItem3.Size = New System.Drawing.Size(1114, 12)
        '
        'TnvedLayoutControlGroup
        '
        Me.TnvedLayoutControlGroup.ExpandButtonVisible = True
        Me.TnvedLayoutControlGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.TnvedLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem12})
        Me.TnvedLayoutControlGroup.Location = New System.Drawing.Point(0, 229)
        Me.TnvedLayoutControlGroup.Name = "TnvedLayoutControlGroup"
        Me.TnvedLayoutControlGroup.Size = New System.Drawing.Size(1114, 134)
        Me.TnvedLayoutControlGroup.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 12, 2)
        Me.TnvedLayoutControlGroup.Text = "Код ТН ВЭД, номер CAS"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AllowHtmlStringInCaption = True
        Me.LayoutControlItem6.Control = Me.TnvedTextEdit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(546, 32)
        Me.LayoutControlItem6.Text = "Код ТН ВЭД<color='red'>*</color>"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = True
        Me.LayoutControlItem7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LayoutControlItem7.Control = Me.CasTextEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(546, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(544, 32)
        Me.LayoutControlItem7.Text = "Номер CAS"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(183, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.AllowHtmlStringInCaption = True
        Me.LayoutControlItem12.Control = Me.TnvedCommentMemoEdit
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1090, 49)
        Me.LayoutControlItem12.Text = "Обоснование кода ТН ВЭД"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(183, 16)
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
        CType(Me.TnvedCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TnvedLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
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
        ' Строка таблицы объектов экспертизы
        '
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        '
        ' Элементы управления
        '
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Регистрационные данные", C2.ToInt(Row("rowNum")))
        NameConTextEdit.EditValue = Row("nameCon")
        NameDecTextEdit.EditValue = Row("nameDec")
        NotNameDecCheckEdit.EditValue = Row("isNotDec")
        TypeLookUpEdit.EditValue = Row("typeId")
        TnvedTextEdit.EditValue = Row("tnved")
        TnvedCommentMemoEdit.EditValue = Row("tnvedComment")
        CasTextEdit.EditValue = Row("cas")
        AreaMemoEdit.EditValue = Row("area")
        UsedMemoEdit.EditValue = Row("used")
        DescriptionMemoEdit.EditValue = Row("description")
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
        Row("nameCon") = C2.DbText(NameConTextEdit.EditValue)
        Row("nameDec") = C2.DbText(NameDecTextEdit.EditValue)
        Row("isNotDec") = NotNameDecCheckEdit.Checked
        If CBool(Row("isNotDec")) Then Row("nameDec") = DBNull.Value
        Row("typeId") = C2.DbInt(TypeLookUpEdit.EditValue)
        Row("tnved") = C2.DbText(TnvedTextEdit.EditValue)
        Row("tnvedComment") = C2.DbText(TnvedCommentMemoEdit.EditValue)
        Row("cas") = C2.DbText(CasTextEdit.EditValue)
        Row("area") = C2.DbText(AreaMemoEdit.EditValue)
        Row("used") = C2.DbText(UsedMemoEdit.EditValue)
        Row("description") = C2.DbText(DescriptionMemoEdit.EditValue)
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
        TnvedCommentMemoEdit.Properties.ReadOnly = bLock
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
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.GoodData
        TypeLookUpEdit.Properties.DataSource = P.Work.GoodCategoryHandbookTable
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
    End Sub

    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodList, MyClass.GoodId)
    End Sub

    ' Перейти к проверке соответствия
    Private Sub OpenLawBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenLawBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodLaw, MyClass.GoodId)
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

    Private Sub TnvedCommentMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TnvedCommentMemoEdit.EditValueChanged
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

End Class
