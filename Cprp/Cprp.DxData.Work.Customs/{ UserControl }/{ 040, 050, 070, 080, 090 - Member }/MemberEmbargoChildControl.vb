Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
''' <summary>
''' Элемент управления "Лицо > Запреты и ограничения"
''' </summary>
Friend Class MemberEmbargoChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents DocOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents NotMemberBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SelMemberBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenProfileBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents InfoLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EmbargoGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents EmbargoGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents MemberCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents MemberDescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemberEmbargoChildControl))
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
        Me.OpenEmbargoBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenProfileBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.SelMemberBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.NotMemberBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
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
        Me.MemberCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.MemberDescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenEmbargoBarCheckItem, Me.NotMemberBarCheckItem, Me.SelMemberBarButtonItem, Me.DocOpenBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenControlBarButtonItem, Me.OpenProfileBarButtonItem, Me.OpenRiskBarButtonItem})
        Me.BarManager1.MaxItemId = 14
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(58, 183)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenProfileBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        ToolTipItem3.Text = "Перейти к фирмам на контроле"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip3
        '
        'OpenProfileBarButtonItem
        '
        Me.OpenProfileBarButtonItem.Caption = "ПРОФИЛЬ"
        Me.OpenProfileBarButtonItem.Glyph = CType(resources.GetObject("OpenProfileBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenProfileBarButtonItem.Id = 12
        Me.OpenProfileBarButtonItem.Name = "OpenProfileBarButtonItem"
        ToolTipTitleItem4.Text = "Прпофиль"
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
        Me.OpenRiskBarButtonItem.Id = 13
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
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Запреты и ограничения"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(64, 213)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelMemberBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NotMemberBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DocOpenBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Запреты и ограничения"
        '
        'SelMemberBarButtonItem
        '
        Me.SelMemberBarButtonItem.Caption = "Выбрать"
        Me.SelMemberBarButtonItem.Glyph = CType(resources.GetObject("SelMemberBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelMemberBarButtonItem.Id = 7
        Me.SelMemberBarButtonItem.Name = "SelMemberBarButtonItem"
        ToolTipTitleItem6.Text = "Выбрать"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Выбрать лицо / Убрать из выборки"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.SelMemberBarButtonItem.SuperTip = SuperToolTip6
        '
        'NotMemberBarCheckItem
        '
        Me.NotMemberBarCheckItem.Caption = "Связи отсутствуют"
        Me.NotMemberBarCheckItem.Glyph = CType(resources.GetObject("NotMemberBarCheckItem.Glyph"), System.Drawing.Image)
        Me.NotMemberBarCheckItem.Id = 6
        Me.NotMemberBarCheckItem.Name = "NotMemberBarCheckItem"
        '
        'DocOpenBarButtonItem
        '
        Me.DocOpenBarButtonItem.Caption = "Документ"
        Me.DocOpenBarButtonItem.Glyph = CType(resources.GetObject("DocOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocOpenBarButtonItem.Id = 8
        Me.DocOpenBarButtonItem.Name = "DocOpenBarButtonItem"
        ToolTipTitleItem7.Text = "Документ"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Открыть документ"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.DocOpenBarButtonItem.SuperTip = SuperToolTip7
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 94)
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
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
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
        Me.InfoLabelControl.Size = New System.Drawing.Size(902, 29)
        Me.InfoLabelControl.StyleController = Me.LayoutControl1
        Me.InfoLabelControl.TabIndex = 25
        Me.InfoLabelControl.Text = "Запреты и ограничения отсутствуют"
        '
        'EmbargoGridControl
        '
        Me.EmbargoGridControl.Location = New System.Drawing.Point(12, 135)
        Me.EmbargoGridControl.MainView = Me.EmbargoGridView
        Me.EmbargoGridControl.Name = "EmbargoGridControl"
        Me.EmbargoGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryItemCheckEdit1})
        Me.EmbargoGridControl.Size = New System.Drawing.Size(926, 446)
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
        Me.EmbargoGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckGridColumn, Me.MemberCaptionGridColumn, Me.MemberDescriptionGridColumn, Me.EmbargoCaptionGridColumn})
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
        'MemberCaptionGridColumn
        '
        Me.MemberCaptionGridColumn.Caption = "Наименование"
        Me.MemberCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.MemberCaptionGridColumn.FieldName = "memberCaption"
        Me.MemberCaptionGridColumn.Name = "MemberCaptionGridColumn"
        Me.MemberCaptionGridColumn.Visible = True
        Me.MemberCaptionGridColumn.VisibleIndex = 1
        Me.MemberCaptionGridColumn.Width = 174
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'MemberDescriptionGridColumn
        '
        Me.MemberDescriptionGridColumn.Caption = "Дополнительные сведения"
        Me.MemberDescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.MemberDescriptionGridColumn.FieldName = "memberDescription"
        Me.MemberDescriptionGridColumn.Name = "MemberDescriptionGridColumn"
        Me.MemberDescriptionGridColumn.Visible = True
        Me.MemberDescriptionGridColumn.VisibleIndex = 2
        Me.MemberDescriptionGridColumn.Width = 174
        '
        'EmbargoCaptionGridColumn
        '
        Me.EmbargoCaptionGridColumn.Caption = "Основание"
        Me.EmbargoCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.EmbargoCaptionGridColumn.FieldName = "embargoCaption"
        Me.EmbargoCaptionGridColumn.Name = "EmbargoCaptionGridColumn"
        Me.EmbargoCaptionGridColumn.Visible = True
        Me.EmbargoCaptionGridColumn.VisibleIndex = 3
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
        Me.CaptionSimpleLabelItem.Text = "Запреты и ограничения"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.EmbargoGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 450)
        Me.LayoutControlItem1.Text = "Список лиц"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
        '
        'InfoLayoutControlGroup
        '
        Me.InfoLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.InfoLayoutControlGroup.Location = New System.Drawing.Point(0, 573)
        Me.InfoLayoutControlGroup.Name = "InfoLayoutControlGroup"
        Me.InfoLayoutControlGroup.Size = New System.Drawing.Size(930, 57)
        Me.InfoLayoutControlGroup.Text = "Информация"
        Me.InfoLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.InfoLabelControl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(906, 33)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'MemberEmbargoChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MemberEmbargoChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
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
#Region "ChildControl"

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
        Dim sTmp As String = "Запреты и ограничения"
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
        CaptionSimpleLabelItem.Text = String.Format("{0} > Объект № {1} > Запреты и ограничения", sTmp, MyRowNum)
        '
        ' Запреты и ограничения отсутствуют
        '
        NotMemberBarCheckItem.Checked = CBool(Row("isNotEmbargo"))
        '
        ' Запреты и ограничения
        '
        EmbargoGridView.BeginDataUpdate()
        MyView.RowFilter = String.Format("countryId = {0}", C2.ToInt(Row("addressLegalCountryId")))
        P.Work.EmbargoMemberHandbookTable.CheckClear()
        If Not CBool(Row("isNotEmbargo")) Then
            Using V As DataView = P.Work.MemberEmbargoTable.MemberView(MyClass.MemberId)
                For Each VRow As DataRowView In V
                    Row = P.Work.EmbargoMemberHandbookTable.Rows.Find(VRow("embargoMemberId"))
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
        ' Строка таблицы лиц
        '
        Dim Row As DataRow = P.Work.MemberTable.Rows.Find(MyClass.MemberId)
        If Row Is Nothing Then Exit Sub
        '
        ' Запреты и ограничения отсутствуют
        '
        Row("isNotEmbargo") = NotMemberBarCheckItem.Checked
        '
        ' Запреты и ограничения
        '
        EmbargoGridView.CloseEditor()
        EmbargoGridView.UpdateCurrentRow()
        With P.Work.MemberEmbargoTable
            .DeleteMember(MyClass.MemberId)
            If Not NotMemberBarCheckItem.Checked Then
                For Each VRow As DataRowView In MyView
                    If CBool(VRow("isCheck")) Then
                        .Rows.Add(New Object() {MyClass.MemberId, VRow("id")})
                    End If
                Next
            End If
            .AcceptChanges()
        End With
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckEmbargo") = ErrorTable.CheckMemberEmbargo(Row, MyKind)
        P.Work.MemberTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        Dim bNotMember As Boolean = NotMemberBarCheckItem.Checked           ' Объект отсутствует в списке
        Dim bNotList As Boolean = (MyView.Count = 0)                        ' Список пуст
        '
        ' Элементы управления
        '
        SelMemberBarButtonItem.Enabled = Not (bLock OrElse bNotMember OrElse bNotList)
        NotMemberBarCheckItem.Enabled = Not (bLock OrElse bNotList)
        DocOpenBarButtonItem.Enabled = Not bNotList
        If bNotList Then
            InfoLabelControl.Text = "Запреты и ограничения отсутствуют"
        Else
            Dim sTmp As String = "объекта"
            Select Case MyKind
                Case MK.IsContractRus : sTmp = "российского участника сделки"
                Case MK.IsContractNus : sTmp = "иностранного участника сделки"
                Case MK.IsSupplyRus : sTmp = "российского участника операции"
                Case MK.IsSupplyNus : sTmp = "иностранного покупателя (продавца)"
                Case MK.IsSupplyEnd : sTmp = "потребителя (конечного пользователя)"
            End Select
            InfoLabelControl.Text = String.Format( _
                "Установите связи {0} с фирмами, перечисленными в списке. " & _
                "При наличии связи выделите соответствующую фирму в списке. " & _
                "Если связи отсутствуют, нажмите кнопку ""Связи отсутствуют""", _
                sTmp)
        End If
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
    ''' Представление справочника запретов и ограничений отфильтрованных по стране объекта
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
    ''' <param name="memberKind">Вид лица</param> 
    Public Sub New(ParentControl As WorkUserControl, memberKind As Cprp.DxData.Member.MemberKind)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyKind = memberKind
        Select Case MyKind
            Case MK.IsContractNus : MyBase.Content = ContentEnum.ContractNusEmbargo
            Case MK.IsSupplyNus : MyBase.Content = ContentEnum.SupplyNusEmbargo
            Case MK.IsSupplyEnd : MyBase.Content = ContentEnum.SupplyEndEmbargo
        End Select
        MyView = New DataView(P.Work.EmbargoMemberHandbookTable)
        MyView.RowFilter = "countryId IS NULL"
        EmbargoGridControl.DataSource = MyView
        EmbargoGridView.SortInfo.Insert(0, MemberCaptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckGridColumn.Group()
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

    ' Перейти к фирмам на контроле
    Private Sub OpenControlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenControlBarButtonItem.ItemClick
        Select Case myKind
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusControl, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusControl, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndControl, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к профилю
    Private Sub OpenProfileBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenProfileBarButtonItem.ItemClick
        Select Case myKind
            Case MK.IsContractRus : P.ContentOpen(ContentEnum.ContractRusProfile, MyClass.MemberId)
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusProfile, MyClass.MemberId)
            Case MK.IsSupplyRus : P.ContentOpen(ContentEnum.SupplyRusProfile, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusProfile, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndProfile, MyClass.MemberId)
        End Select
    End Sub

    ' Перейти к рискам
    Private Sub OpenRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenRiskBarButtonItem.ItemClick
        Select Case myKind
            Case MK.IsContractRus : P.ContentOpen(ContentEnum.ContractRusRisk, MyClass.MemberId)
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusRisk, MyClass.MemberId)
            Case MK.IsSupplyRus : P.ContentOpen(ContentEnum.SupplyRusRisk, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusRisk, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndRisk, MyClass.MemberId)
        End Select
    End Sub

    ' Выбрать запрет / Убрать из выборки
    Private Sub SelMemberBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelMemberBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        With EmbargoGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        EmbargoGridView.RefreshData()
        MyBase.SetChangeDateNow()
    End Sub

    ' Объект отсутствует в списке
    Private Sub NotMemberBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotMemberBarCheckItem.CheckedChanged
        LockUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub EmbargoGridControl_DoubleClick(sender As Object, e As EventArgs) Handles EmbargoGridControl.DoubleClick
        If SelMemberBarButtonItem.Enabled Then SelMemberBarButtonItem.PerformClick()
    End Sub

    Private Sub EmbargoGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles EmbargoGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

End Class
