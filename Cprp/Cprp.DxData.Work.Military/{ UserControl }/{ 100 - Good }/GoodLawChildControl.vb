Imports DevExpress.XtraTreeList.Nodes
Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > Запреты и ограничения"
''' </summary>
Friend Class GoodLawChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelectBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenSummaryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenLawBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenDataBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LawTreeList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents PosDescriptionTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents PosDescriptionRepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents TypeIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsFindWordTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FindWordBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents FindRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IsSelTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodLawChildControl))
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
        Dim TreeListFormatRule1 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule2 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule3 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule4 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.TypeIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsFindWordTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenLawBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenSummaryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.FindWordBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FindRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.FindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SelectBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LawTreeList = New DevExpress.XtraTreeList.TreeList()
        Me.PosDescriptionTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.PosDescriptionRepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.IsSelTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LawTreeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PosDescriptionRepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TypeIdTreeListColumn
        '
        Me.TypeIdTreeListColumn.Caption = "TypeId"
        Me.TypeIdTreeListColumn.FieldName = "typeId"
        Me.TypeIdTreeListColumn.Name = "TypeIdTreeListColumn"
        '
        'IsFindWordTreeListColumn
        '
        Me.IsFindWordTreeListColumn.Caption = "isWord"
        Me.IsFindWordTreeListColumn.FieldName = "isFindWord"
        Me.IsFindWordTreeListColumn.Name = "IsFindWordTreeListColumn"
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenLawBarCheckItem, Me.SelectBarButtonItem, Me.OpenDataBarButtonItem, Me.OpenSummaryBarButtonItem, Me.FindWordBarEditItem, Me.FindBarButtonItem})
        Me.BarManager1.MaxItemId = 19
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.FindRepositoryItemTextEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(58, 183)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLawBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenSummaryBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        'OpenLawBarCheckItem
        '
        Me.OpenLawBarCheckItem.BindableChecked = True
        Me.OpenLawBarCheckItem.Caption = "КЛАССИФИКАТОР ПВН"
        Me.OpenLawBarCheckItem.Checked = True
        Me.OpenLawBarCheckItem.Glyph = CType(resources.GetObject("OpenLawBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenLawBarCheckItem.GroupIndex = 1
        Me.OpenLawBarCheckItem.Id = 3
        Me.OpenLawBarCheckItem.Name = "OpenLawBarCheckItem"
        '
        'OpenSummaryBarButtonItem
        '
        Me.OpenSummaryBarButtonItem.Caption = "АНАЛИЗ"
        Me.OpenSummaryBarButtonItem.Glyph = CType(resources.GetObject("OpenSummaryBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenSummaryBarButtonItem.Id = 15
        Me.OpenSummaryBarButtonItem.Name = "OpenSummaryBarButtonItem"
        ToolTipTitleItem3.Text = "Анализ"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Перейти к анализу продукции гражданского назначения"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.OpenSummaryBarButtonItem.SuperTip = SuperToolTip3
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
        Me.Bar2.BarName = "Классификатор"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(64, 213)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FindWordBarEditItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelectBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Классификатор"
        '
        'FindWordBarEditItem
        '
        Me.FindWordBarEditItem.Caption = "Поиск"
        Me.FindWordBarEditItem.Edit = Me.FindRepositoryItemTextEdit
        Me.FindWordBarEditItem.EditWidth = 250
        Me.FindWordBarEditItem.Id = 17
        Me.FindWordBarEditItem.Name = "FindWordBarEditItem"
        '
        'FindRepositoryItemTextEdit
        '
        Me.FindRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.FindRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.FindRepositoryItemTextEdit.AutoHeight = False
        Me.FindRepositoryItemTextEdit.Name = "FindRepositoryItemTextEdit"
        '
        'FindBarButtonItem
        '
        Me.FindBarButtonItem.Caption = "Поиск"
        Me.FindBarButtonItem.Glyph = CType(resources.GetObject("FindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FindBarButtonItem.Id = 18
        Me.FindBarButtonItem.Name = "FindBarButtonItem"
        ToolTipTitleItem4.Text = "Поиск"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Начать поиск в Классификаторе"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.FindBarButtonItem.SuperTip = SuperToolTip4
        '
        'SelectBarButtonItem
        '
        Me.SelectBarButtonItem.Caption = "Выбрать"
        Me.SelectBarButtonItem.Glyph = CType(resources.GetObject("SelectBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelectBarButtonItem.Id = 7
        Me.SelectBarButtonItem.Name = "SelectBarButtonItem"
        ToolTipTitleItem5.Text = "Выбрать"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Выбрать пункт / Убрать из выборки"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.SelectBarButtonItem.SuperTip = SuperToolTip5
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
        Me.LayoutControl1.Controls.Add(Me.LawTreeList)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
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
        'LawTreeList
        '
        Me.LawTreeList.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LawTreeList.Appearance.Row.Options.UseFont = True
        Me.LawTreeList.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.PosDescriptionTreeListColumn, Me.TypeIdTreeListColumn, Me.IsFindWordTreeListColumn, Me.IsSelTreeListColumn})
        TreeListFormatRule1.ApplyToRow = True
        TreeListFormatRule1.Column = Me.TypeIdTreeListColumn
        TreeListFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = CType(2, Short)
        TreeListFormatRule1.Rule = FormatConditionRuleValue1
        TreeListFormatRule2.ApplyToRow = True
        TreeListFormatRule2.Column = Me.TypeIdTreeListColumn
        TreeListFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = CType(4, Short)
        TreeListFormatRule2.Rule = FormatConditionRuleValue2
        TreeListFormatRule3.ApplyToRow = True
        TreeListFormatRule3.Column = Me.IsFindWordTreeListColumn
        TreeListFormatRule3.Name = "Format3"
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = True
        TreeListFormatRule3.Rule = FormatConditionRuleValue3
        TreeListFormatRule4.ApplyToRow = True
        TreeListFormatRule4.Column = Me.IsSelTreeListColumn
        TreeListFormatRule4.Name = "Format4"
        FormatConditionRuleValue4.Appearance.BackColor = System.Drawing.SystemColors.Info
        FormatConditionRuleValue4.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue4.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue4.Appearance.Options.UseFont = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = True
        TreeListFormatRule4.Rule = FormatConditionRuleValue4
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule1)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule2)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule3)
        Me.LawTreeList.FormatRules.Add(TreeListFormatRule4)
        Me.LawTreeList.KeyFieldName = "id"
        Me.LawTreeList.Location = New System.Drawing.Point(12, 135)
        Me.LawTreeList.Name = "LawTreeList"
        Me.LawTreeList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.LawTreeList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[True]
        Me.LawTreeList.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.[True]
        Me.LawTreeList.OptionsMenu.EnableColumnMenu = False
        Me.LawTreeList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.LawTreeList.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.LawTreeList.OptionsView.ShowColumns = False
        Me.LawTreeList.OptionsView.ShowIndicator = False
        Me.LawTreeList.ParentFieldName = "parentId"
        Me.LawTreeList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PosDescriptionRepositoryItemMemoEdit})
        Me.LawTreeList.Size = New System.Drawing.Size(1126, 503)
        Me.LawTreeList.TabIndex = 32
        '
        'PosDescriptionTreeListColumn
        '
        Me.PosDescriptionTreeListColumn.Caption = "Описание"
        Me.PosDescriptionTreeListColumn.ColumnEdit = Me.PosDescriptionRepositoryItemMemoEdit
        Me.PosDescriptionTreeListColumn.FieldName = "posDescription"
        Me.PosDescriptionTreeListColumn.Name = "PosDescriptionTreeListColumn"
        Me.PosDescriptionTreeListColumn.OptionsColumn.AllowEdit = False
        Me.PosDescriptionTreeListColumn.OptionsColumn.AllowSort = False
        Me.PosDescriptionTreeListColumn.OptionsFilter.AllowFilter = False
        Me.PosDescriptionTreeListColumn.Visible = True
        Me.PosDescriptionTreeListColumn.VisibleIndex = 0
        '
        'PosDescriptionRepositoryItemMemoEdit
        '
        Me.PosDescriptionRepositoryItemMemoEdit.Name = "PosDescriptionRepositoryItemMemoEdit"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.SimpleSeparator1, Me.LayoutControlItem1})
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
        Me.CaptionSimpleLabelItem.Text = "Продукция > Объект № _ > Классификатор ПВН"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
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
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LawTreeList
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1130, 507)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'IsSelTreeListColumn
        '
        Me.IsSelTreeListColumn.Caption = "isSel"
        Me.IsSelTreeListColumn.FieldName = "isSel"
        Me.IsSelTreeListColumn.Name = "IsSelTreeListColumn"
        '
        'GoodLawChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodLawChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LawTreeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PosDescriptionRepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
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
        ' Заголовок элемента управления
        '
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Классификатор ПВН", C2.ToInt(Row("rowNum")))
        '
        ' Выбранный пункт Классификатора
        '
        Dim LRow As DataRow = P.Work.LawDataSet.LawTable.Rows.Find(C2.ToInt(Row("lawId")))
        LawTreeList.LockReloadNodes()
        P.Work.LawDataSet.SelectionClear()
        If Not LRow Is Nothing Then LRow("isSel") = True
        LawTreeList.UnlockReloadNodes()
        LawTreeList.CollapseAll()
        LawTreeList.ExpandToLevel(0)
        If Not LRow Is Nothing Then
            Dim Node As TreeListNode = LawTreeList.FindNodeByKeyID(LRow("id"))
            If Not Node Is Nothing Then
                Node.ExpandAll()
                LawTreeList.SetFocusedNode(Node)
            End If
        End If
        '
        ' Доступность элементов управления на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        FindWordBarEditItem.Edit.ReadOnly = bLock
        FindBarButtonItem.Enabled = Not bLock
        SelectBarButtonItem.Enabled = Not bLock

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
        ' Выбранный пункт Классификатора
        '
        Using V As New DataView(P.Work.LawDataSet.LawTable)
            V.RowFilter = "isSel = True"
            If V.Count = 0 Then
                Row("lawId") = DBNull.Value
            Else
                Row("lawId") = V(0)("id")
            End If
        End Using
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property GoodId As Integer = C2.EMPTY_ID


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.GoodLaw
        LawTreeList.DataSource = P.Work.LawDataSet.LawTable
    End Sub


    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodList, MyClass.GoodId)
    End Sub

    ' Перейти к регистрационным данным
    Private Sub OpenDataBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenDataBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodData, MyClass.GoodId)
    End Sub

    ' Перейти к сравнительному анализу
    Private Sub OpenSummaryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenSummaryBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodSummary, MyClass.GoodId)
    End Sub

    ' Поиск по ключевым словам
    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        Dim wordLine As String = Nothing
        If Not FindWordBarEditItem.EditValue Is Nothing Then wordLine = FindWordBarEditItem.EditValue.ToString
        If String.IsNullOrWhiteSpace(wordLine) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажате ключевые слова для поиска!")
            Exit Sub
        End If
        LawTreeList.LockReloadNodes()
        With P.Work.LawDataSet
            '
            ' Поиск по ключевым словам
            '
            .FindClear()
            .FindByWord(wordLine, Nothing)
            .AcceptChanges()
            '
            ' Открыть все найденные и выбранные пункты и спозиционироваться на первом
            '
            Using V As New DataView(.LawTable)
                LawTreeList.CollapseAll()
                LawTreeList.ExpandToLevel(0)
                Dim Node As TreeListNode = Nothing
                V.RowFilter = "isFindWord = True OR isSel = True"
                V.Sort = "doc, id"
                For i As Integer = V.Count - 1 To 0 Step -1
                    Node = LawTreeList.FindNodeByKeyID(V(i)("id"))
                    If Node Is Nothing Then Continue For
                    Node.ExpandAll()
                    LawTreeList.SetFocusedNode(Node)
                Next
            End Using
        End With
        LawTreeList.UnlockReloadNodes()
    End Sub

    ' Выбрать пункт / Убрать из выборки
    Private Sub SelectBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelectBarButtonItem.ItemClick
        Dim Node As TreeListNode = LawTreeList.FocusedNode
        If Node Is Nothing Then Exit Sub
        If CType(Node.GetValue("typeId"), Cprp.DxData.Law.TypeEnum) <> Law.TypeEnum.IsParagraph Then Exit Sub
        Dim Row As DataRow = P.Work.LawDataSet.LawTable.Rows.Find(Node.GetValue("id"))
        Dim bTmp As Boolean = CBool(Row("isSel"))
        LawTreeList.LockReloadNodes()
        P.Work.LawDataSet.SelectionClear()
        Row("isSel") = Not bTmp
        LawTreeList.UnlockReloadNodes()
    End Sub
 
End Class
