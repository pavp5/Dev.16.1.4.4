Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
''' <summary>
''' Элемент управления "Лицо > Риски"
''' </summary>
Friend Class MemberRiskChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents NotRiskBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SelRiskBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenRiskBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenProfileBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenEmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents InfoLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RiskGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents RiskGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents CaptionRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents IdRiskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents InfoLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemberRiskChildControl))
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenEmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenProfileBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenRiskBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.SelRiskBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.NotRiskBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.InfoLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.RiskGridControl = New DevExpress.XtraGrid.GridControl()
        Me.RiskGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CaptionRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.IdRiskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.InfoLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.RiskGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckRiskGridColumn
        '
        Me.IsCheckRiskGridColumn.Caption = "Выбрано"
        Me.IsCheckRiskGridColumn.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IsCheckRiskGridColumn.FieldName = "isCheck"
        Me.IsCheckRiskGridColumn.Name = "IsCheckRiskGridColumn"
        Me.IsCheckRiskGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckRiskGridColumn.Visible = True
        Me.IsCheckRiskGridColumn.VisibleIndex = 0
        Me.IsCheckRiskGridColumn.Width = 60
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenRiskBarCheckItem, Me.NotRiskBarCheckItem, Me.SelRiskBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenProfileBarButtonItem, Me.OpenEmbargoBarButtonItem, Me.OpenControlBarButtonItem})
        Me.BarManager1.MaxItemId = 10
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(64, 177)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenEmbargoBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenControlBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenProfileBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenRiskBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        Me.OpenDataBarButtonItem.Id = 6
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
        Me.OpenEmbargoBarButtonItem.Id = 8
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
        Me.OpenControlBarButtonItem.Caption = "ВСЕОБЪЕМЛЮЩИЙ КОНТРОЛЬ"
        Me.OpenControlBarButtonItem.Glyph = CType(resources.GetObject("OpenControlBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenControlBarButtonItem.Id = 9
        Me.OpenControlBarButtonItem.Name = "OpenControlBarButtonItem"
        ToolTipTitleItem4.Text = "На контроле"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Перейти к фирмам на контроле"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.OpenControlBarButtonItem.SuperTip = SuperToolTip4
        '
        'OpenProfileBarButtonItem
        '
        Me.OpenProfileBarButtonItem.Caption = "ПРОФИЛЬ"
        Me.OpenProfileBarButtonItem.Glyph = CType(resources.GetObject("OpenProfileBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenProfileBarButtonItem.Id = 7
        Me.OpenProfileBarButtonItem.Name = "OpenProfileBarButtonItem"
        ToolTipTitleItem5.Text = "Профиль"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Перейти к профилю"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.OpenProfileBarButtonItem.SuperTip = SuperToolTip5
        '
        'OpenRiskBarCheckItem
        '
        Me.OpenRiskBarCheckItem.BindableChecked = True
        Me.OpenRiskBarCheckItem.Caption = "РИСКИ"
        Me.OpenRiskBarCheckItem.Checked = True
        Me.OpenRiskBarCheckItem.Glyph = CType(resources.GetObject("OpenRiskBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenRiskBarCheckItem.GroupIndex = 1
        Me.OpenRiskBarCheckItem.Id = 3
        Me.OpenRiskBarCheckItem.Name = "OpenRiskBarCheckItem"
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(13, 53)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(924, 39)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Признаки риска"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(65, 173)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelRiskBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NotRiskBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Признаки риска"
        '
        'SelRiskBarButtonItem
        '
        Me.SelRiskBarButtonItem.Caption = "Выбрать"
        Me.SelRiskBarButtonItem.Glyph = CType(resources.GetObject("SelRiskBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelRiskBarButtonItem.Id = 5
        Me.SelRiskBarButtonItem.Name = "SelRiskBarButtonItem"
        ToolTipTitleItem6.Text = "Выбрать"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Выбрать риск / Убрать из выборки"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.SelRiskBarButtonItem.SuperTip = SuperToolTip6
        '
        'NotRiskBarCheckItem
        '
        Me.NotRiskBarCheckItem.Caption = "Риски отсутствуют"
        Me.NotRiskBarCheckItem.Glyph = CType(resources.GetObject("NotRiskBarCheckItem.Glyph"), System.Drawing.Image)
        Me.NotRiskBarCheckItem.Id = 4
        Me.NotRiskBarCheckItem.Name = "NotRiskBarCheckItem"
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(13, 97)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(924, 39)
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
        Me.LayoutControl1.Controls.Add(Me.RiskGridControl)
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
        Me.InfoLabelControl.Location = New System.Drawing.Point(26, 595)
        Me.InfoLabelControl.Name = "InfoLabelControl"
        Me.InfoLabelControl.Size = New System.Drawing.Size(898, 29)
        Me.InfoLabelControl.StyleController = Me.LayoutControl1
        Me.InfoLabelControl.TabIndex = 23
        Me.InfoLabelControl.Text = "Риски отсутствуют"
        '
        'RiskGridControl
        '
        Me.RiskGridControl.Location = New System.Drawing.Point(13, 140)
        Me.RiskGridControl.MainView = Me.RiskGridView
        Me.RiskGridControl.Name = "RiskGridControl"
        Me.RiskGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit3, Me.RepositoryItemCheckEdit1})
        Me.RiskGridControl.Size = New System.Drawing.Size(924, 438)
        Me.RiskGridControl.TabIndex = 21
        Me.RiskGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.RiskGridView})
        '
        'RiskGridView
        '
        Me.RiskGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.RiskGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RiskGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RiskGridView.Appearance.Row.Options.UseFont = True
        Me.RiskGridView.Appearance.Row.Options.UseTextOptions = True
        Me.RiskGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RiskGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RiskGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RiskGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.RiskGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.RiskGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckRiskGridColumn, Me.CaptionRiskGridColumn, Me.IdRiskGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckRiskGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.RiskGridView.FormatRules.Add(GridFormatRule1)
        Me.RiskGridView.GridControl = Me.RiskGridControl
        Me.RiskGridView.GroupFormat = "{1}"
        Me.RiskGridView.Name = "RiskGridView"
        Me.RiskGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.RiskGridView.OptionsBehavior.Editable = False
        Me.RiskGridView.OptionsCustomization.AllowColumnMoving = False
        Me.RiskGridView.OptionsCustomization.AllowFilter = False
        Me.RiskGridView.OptionsCustomization.AllowGroup = False
        Me.RiskGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.RiskGridView.OptionsCustomization.AllowSort = False
        Me.RiskGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RiskGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.RiskGridView.OptionsView.RowAutoHeight = True
        Me.RiskGridView.OptionsView.ShowGroupPanel = False
        Me.RiskGridView.RowHeight = 25
        '
        'CaptionRiskGridColumn
        '
        Me.CaptionRiskGridColumn.Caption = "Наименование риска"
        Me.CaptionRiskGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.CaptionRiskGridColumn.FieldName = "caption"
        Me.CaptionRiskGridColumn.Name = "CaptionRiskGridColumn"
        Me.CaptionRiskGridColumn.Visible = True
        Me.CaptionRiskGridColumn.VisibleIndex = 1
        Me.CaptionRiskGridColumn.Width = 174
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'IdRiskGridColumn
        '
        Me.IdRiskGridColumn.Caption = "id"
        Me.IdRiskGridColumn.FieldName = "id"
        Me.IdRiskGridColumn.Name = "IdRiskGridColumn"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.SimpleSeparator1, Me.InfoLayoutControlGroup})
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
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(928, 40)
        Me.CaptionSimpleLabelItem.Text = "Риски"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.RiskGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 127)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(928, 442)
        Me.LayoutControlItem1.Text = "Признаки риска"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(928, 43)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(928, 43)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 83)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(928, 1)
        '
        'InfoLayoutControlGroup
        '
        Me.InfoLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.InfoLayoutControlGroup.Location = New System.Drawing.Point(0, 569)
        Me.InfoLayoutControlGroup.Name = "InfoLayoutControlGroup"
        Me.InfoLayoutControlGroup.Size = New System.Drawing.Size(928, 59)
        Me.InfoLayoutControlGroup.Text = "Информация"
        Me.InfoLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.InfoLabelControl
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(902, 33)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'MemberRiskChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MemberRiskChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.RiskGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
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
        Dim sTmp As String = "Риски"
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
        CaptionSimpleLabelItem.Text = String.Format("{0} > Объект № {1} > Риски", sTmp, MyRowNum)
        '
        ' Риски отсутствуют
        '        
        NotRiskBarCheckItem.Checked = Row(NotRiskFieldName)
        '
        ' Риски
        '
        RiskGridView.BeginDataUpdate()
        P.Work.RiskHandbookTable.CheckClear()
        Using V As DataView = P.Work.MemberRiskTable.MemberView(MyClass.MemberId)
            For Each VRow As DataRowView In V
                Row = P.Work.RiskHandbookTable.Rows.Find(VRow("riskId"))
                If Not Row Is Nothing Then Row("isCheck") = True
            Next
        End Using
        RiskGridView.EndDataUpdate()
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
        ' Риски отсутствуют
        '
        Row(NotRiskFieldName) = NotRiskBarCheckItem.Checked
        '
        ' Риски
        '
        RiskGridView.CloseEditor()
        RiskGridView.UpdateCurrentRow()
        With P.Work.MemberRiskTable
            .DeleteMember(MyClass.MemberId, StrRiskId)
            If Not NotRiskBarCheckItem.Checked Then
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
        Row(CheckRiskFieldName) = ErrorTable.CheckMemberRisk(Row, MyKind)
        P.Work.MemberTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        Dim bNotRisk As Boolean = NotRiskBarCheckItem.Checked               ' Риски отсутствуют
        Dim bNotList As Boolean = (MyView.Count = 0)                        ' Список пуст
        '
        ' Элементы управления
        '
        SelRiskBarButtonItem.Enabled = Not (bLock OrElse bNotRisk OrElse bNotList)
        NotRiskBarCheckItem.Enabled = Not (bLock OrElse bNotList)
        If bNotList Then
            InfoLabelControl.Text = "Риски отсутствуют"
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
                "Выберите в списке риски, выявленные в отношении {0}. " & _
                "Если риски отсутствуют, нажмите кнопку ""Риски отсутствуют""", _
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
    ''' Представление справочника рисков отфильтрованное по виду объекта
    ''' </summary>
    Private MyView As DataView = Nothing

    ''' <summary>
    ''' Имя поля отсутствия рисков
    ''' </summary>
    Private NotRiskFieldName As String = Nothing

    ''' <summary>
    ''' Имя поля проверки рисков
    ''' </summary>
    Private CheckRiskFieldName As String = Nothing

    ''' <summary>
    ''' Строка ID рисков текущего вида объекта
    ''' </summary>
    Private StrRiskId As String = Nothing

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
                MyBase.Content = ContentEnum.ContractRusRisk
                MyView = P.Work.RiskHandbookTable.ContractRusView
                NotRiskFieldName = "isNotConRusRisk"
                CheckRiskFieldName = "isCheckConRusRisk"
                StrRiskId = P.Work.RiskHandbookTable.StrTypeId(Cprp.DxData.Risk.TypeEnum.IsContractRus)
            Case Cprp.DxData.Member.MemberKind.IsContractNus
                MyBase.Content = ContentEnum.ContractNusRisk
                MyView = P.Work.RiskHandbookTable.ContractNusView
                NotRiskFieldName = "isNotConNusRisk"
                CheckRiskFieldName = "isCheckConNusRisk"
                StrRiskId = P.Work.RiskHandbookTable.StrTypeId(Cprp.DxData.Risk.TypeEnum.IsContractNus)
            Case Cprp.DxData.Member.MemberKind.IsSupplyRus
                MyBase.Content = ContentEnum.SupplyRusRisk
                MyView = P.Work.RiskHandbookTable.SupplyRusView
                NotRiskFieldName = "isNotSupRusRisk"
                CheckRiskFieldName = "isCheckSupRusRisk"
                StrRiskId = P.Work.RiskHandbookTable.StrTypeId(Cprp.DxData.Risk.TypeEnum.IsSupplyRus)
            Case Cprp.DxData.Member.MemberKind.IsSupplyNus
                MyBase.Content = ContentEnum.SupplyNusRisk
                MyView = P.Work.RiskHandbookTable.SupplyNusView
                NotRiskFieldName = "isNotSupNusRisk"
                CheckRiskFieldName = "isCheckSupNusRisk"
                StrRiskId = P.Work.RiskHandbookTable.StrTypeId(Cprp.DxData.Risk.TypeEnum.IsSupplyNus)
            Case Cprp.DxData.Member.MemberKind.IsSupplyEnd
                MyBase.Content = ContentEnum.SupplyEndRisk
                MyView = P.Work.RiskHandbookTable.SupplyEndView
                NotRiskFieldName = "isNotSupEndRisk"
                CheckRiskFieldName = "isCheckSupEndRisk"
                StrRiskId = P.Work.RiskHandbookTable.StrTypeId(Cprp.DxData.Risk.TypeEnum.IsSupplyEnd)
        End Select
        RiskGridControl.DataSource = MyView
        RiskGridView.SortInfo.Insert(0, IdRiskGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckRiskGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckRiskGridColumn.Group()
        If (MyBase.Content = ContentEnum.ContractRusRisk OrElse MyBase.Content = ContentEnum.SupplyRusRisk) Then
            OpenEmbargoBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            OpenControlBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
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

    ' Перейти к профилю
    Private Sub OpenProfileBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenProfileBarButtonItem.ItemClick
        Select Case MyKind
            Case MK.IsContractRus : P.ContentOpen(ContentEnum.ContractRusProfile, MyClass.MemberId)
            Case MK.IsContractNus : P.ContentOpen(ContentEnum.ContractNusProfile, MyClass.MemberId)
            Case MK.IsSupplyRus : P.ContentOpen(ContentEnum.SupplyRusProfile, MyClass.MemberId)
            Case MK.IsSupplyNus : P.ContentOpen(ContentEnum.SupplyNusProfile, MyClass.MemberId)
            Case MK.IsSupplyEnd : P.ContentOpen(ContentEnum.SupplyEndProfile, MyClass.MemberId)
        End Select
    End Sub

    ' Выбрать риск / Убрать из выборки
    Private Sub SelRiskBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelRiskBarButtonItem.ItemClick
        If RiskGridView.FocusedRowHandle < 0 Then Exit Sub
        With RiskGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        RiskGridView.RefreshData()
        MyBase.SetChangeDateNow()
    End Sub

    ' Риски отсутствуют
    Private Sub NotRiskBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotRiskBarCheckItem.CheckedChanged
        LockUpdate()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub RiskGridControl_DoubleClick(sender As Object, e As EventArgs) Handles RiskGridControl.DoubleClick
        If SelRiskBarButtonItem.Enabled Then SelRiskBarButtonItem.PerformClick()
    End Sub

    Private Sub RiskGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles RiskGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

End Class
