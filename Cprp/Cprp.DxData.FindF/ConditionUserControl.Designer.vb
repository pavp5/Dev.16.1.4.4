<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConditionUserControl
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConditionUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.FindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ConditionGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.UnionRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.OrgRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GoodEqualRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.category = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.row = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category1 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.row1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row3 = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRow()
        Me.MultiEditorRowProperties3 = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.MultiEditorRowProperties4 = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.category2 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.row4 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row5 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row6 = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRow()
        Me.MultiEditorRowProperties1 = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.MultiEditorRowProperties2 = New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties()
        Me.row7 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row8 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row9 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row10 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category3 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.row11 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row12 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row13 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row16 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row17 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row14 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row15 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.GoodListRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConditionGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnionRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrgRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodEqualRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodListRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.FindBarButtonItem, Me.ClearBarButtonItem})
        Me.BarManager1.MaxItemId = 2
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.ClearBarButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'FindBarButtonItem
        '
        Me.FindBarButtonItem.Caption = "ПОИСК"
        Me.FindBarButtonItem.Glyph = CType(resources.GetObject("FindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FindBarButtonItem.Id = 0
        Me.FindBarButtonItem.Name = "FindBarButtonItem"
        ToolTipTitleItem1.Text = "Поиск"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Начать поиск"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.FindBarButtonItem.SuperTip = SuperToolTip1
        '
        'ClearBarButtonItem
        '
        Me.ClearBarButtonItem.Caption = "Очистить"
        Me.ClearBarButtonItem.Glyph = CType(resources.GetObject("ClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ClearBarButtonItem.Id = 1
        Me.ClearBarButtonItem.Name = "ClearBarButtonItem"
        ToolTipTitleItem2.Text = "Очистить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Очистить критерии поиска"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ClearBarButtonItem.SuperTip = SuperToolTip2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(950, 37)
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
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 37)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 613)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 37)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 613)
        '
        'ConditionGridControl
        '
        Me.ConditionGridControl.Appearance.Category.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ConditionGridControl.Appearance.Category.Options.UseFont = True
        Me.ConditionGridControl.Appearance.RecordValue.Font = New System.Drawing.Font("Calibri", 12.75!)
        Me.ConditionGridControl.Appearance.RecordValue.Options.UseFont = True
        Me.ConditionGridControl.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ConditionGridControl.Appearance.RowHeaderPanel.Options.UseFont = True
        Me.ConditionGridControl.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.ConditionGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConditionGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.ConditionGridControl.Location = New System.Drawing.Point(0, 37)
        Me.ConditionGridControl.Name = "ConditionGridControl"
        Me.ConditionGridControl.OptionsBehavior.ResizeRowHeaders = False
        Me.ConditionGridControl.RecordWidth = 150
        Me.ConditionGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.UnionRepositoryItemLookUpEdit, Me.OrgRepositoryItemLookUpEdit, Me.GoodEqualRepositoryItemLookUpEdit, Me.GoodListRepositoryItemLookUpEdit})
        Me.ConditionGridControl.RowHeaderWidth = 50
        Me.ConditionGridControl.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category, Me.category1, Me.category2, Me.category3})
        Me.ConditionGridControl.Size = New System.Drawing.Size(950, 613)
        Me.ConditionGridControl.TabIndex = 5
        Me.ConditionGridControl.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
        '
        'UnionRepositoryItemLookUpEdit
        '
        Me.UnionRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UnionRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.UnionRepositoryItemLookUpEdit.AutoHeight = False
        Me.UnionRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UnionRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.UnionRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.UnionRepositoryItemLookUpEdit.DropDownRows = 2
        Me.UnionRepositoryItemLookUpEdit.Name = "UnionRepositoryItemLookUpEdit"
        Me.UnionRepositoryItemLookUpEdit.NullText = ""
        Me.UnionRepositoryItemLookUpEdit.ShowFooter = False
        Me.UnionRepositoryItemLookUpEdit.ShowHeader = False
        Me.UnionRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'OrgRepositoryItemLookUpEdit
        '
        Me.OrgRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.OrgRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.OrgRepositoryItemLookUpEdit.AutoHeight = False
        Me.OrgRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OrgRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.OrgRepositoryItemLookUpEdit.DisplayMember = "nameShort"
        Me.OrgRepositoryItemLookUpEdit.DropDownRows = 15
        Me.OrgRepositoryItemLookUpEdit.Name = "OrgRepositoryItemLookUpEdit"
        Me.OrgRepositoryItemLookUpEdit.NullText = ""
        Me.OrgRepositoryItemLookUpEdit.ShowFooter = False
        Me.OrgRepositoryItemLookUpEdit.ShowHeader = False
        Me.OrgRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'GoodEqualRepositoryItemLookUpEdit
        '
        Me.GoodEqualRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GoodEqualRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.GoodEqualRepositoryItemLookUpEdit.AutoHeight = False
        Me.GoodEqualRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GoodEqualRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.GoodEqualRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.GoodEqualRepositoryItemLookUpEdit.DropDownRows = 2
        Me.GoodEqualRepositoryItemLookUpEdit.Name = "GoodEqualRepositoryItemLookUpEdit"
        Me.GoodEqualRepositoryItemLookUpEdit.NullText = ""
        Me.GoodEqualRepositoryItemLookUpEdit.ShowFooter = False
        Me.GoodEqualRepositoryItemLookUpEdit.ShowHeader = False
        Me.GoodEqualRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'category
        '
        Me.category.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.row})
        Me.category.Height = 22
        Me.category.Name = "category"
        Me.category.Properties.Caption = "Условие объединение критериев поиска"
        Me.category.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row
        '
        Me.row.Height = 25
        Me.row.Name = "row"
        Me.row.Properties.Caption = "Условие объединения"
        Me.row.Properties.FieldName = "unionId"
        Me.row.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.row.Properties.RowEdit = Me.UnionRepositoryItemLookUpEdit
        '
        'category1
        '
        Me.category1.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.row1, Me.row2, Me.row3})
        Me.category1.Height = 22
        Me.category1.Name = "category1"
        Me.category1.Properties.Caption = "Заключение экспертизы"
        Me.category1.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row1
        '
        Me.row1.Height = 25
        Me.row1.Name = "row1"
        Me.row1.Properties.Caption = "Экспертная организация"
        Me.row1.Properties.FieldName = "orgId"
        Me.row1.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.row1.Properties.RowEdit = Me.OrgRepositoryItemLookUpEdit
        '
        'row2
        '
        Me.row2.Appearance.Options.UseTextOptions = True
        Me.row2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.row2.Height = 25
        Me.row2.Name = "row2"
        Me.row2.Properties.Caption = "Номер заключения"
        Me.row2.Properties.FieldName = "docNum"
        Me.row2.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row3
        '
        Me.row3.Height = 25
        Me.row3.Name = "row3"
        Me.row3.PropertiesCollection.AddRange(New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties() {Me.MultiEditorRowProperties3, Me.MultiEditorRowProperties4})
        '
        'MultiEditorRowProperties3
        '
        Me.MultiEditorRowProperties3.Caption = "Дата заключения (от... до...)"
        Me.MultiEditorRowProperties3.FieldName = "docDateB"
        Me.MultiEditorRowProperties3.Padding = New System.Windows.Forms.Padding(0)
        '
        'MultiEditorRowProperties4
        '
        Me.MultiEditorRowProperties4.FieldName = "docDateE"
        Me.MultiEditorRowProperties4.Padding = New System.Windows.Forms.Padding(0)
        '
        'category2
        '
        Me.category2.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.row4, Me.row5, Me.row6, Me.row7, Me.row8, Me.row9, Me.row10})
        Me.category2.Height = 22
        Me.category2.Name = "category2"
        Me.category2.Properties.Caption = "Внешнеэкономическая операция"
        Me.category2.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row4
        '
        Me.row4.Height = 25
        Me.row4.Name = "row4"
        Me.row4.Properties.Caption = "Страна назначения"
        Me.row4.Properties.FieldName = "countryName"
        Me.row4.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row5
        '
        Me.row5.Height = 25
        Me.row5.Name = "row5"
        Me.row5.Properties.Caption = "Номер контракта"
        Me.row5.Properties.FieldName = "conNum"
        Me.row5.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row6
        '
        Me.row6.Height = 25
        Me.row6.Name = "row6"
        Me.row6.PropertiesCollection.AddRange(New DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties() {Me.MultiEditorRowProperties1, Me.MultiEditorRowProperties2})
        '
        'MultiEditorRowProperties1
        '
        Me.MultiEditorRowProperties1.Caption = "Дата контракта (от... до...)"
        Me.MultiEditorRowProperties1.FieldName = "conDateB"
        Me.MultiEditorRowProperties1.Padding = New System.Windows.Forms.Padding(0)
        '
        'MultiEditorRowProperties2
        '
        Me.MultiEditorRowProperties2.FieldName = "conDateE"
        Me.MultiEditorRowProperties2.Padding = New System.Windows.Forms.Padding(0)
        '
        'row7
        '
        Me.row7.Height = 25
        Me.row7.Name = "row7"
        Me.row7.Properties.Caption = "Российский участник операции"
        Me.row7.Properties.FieldName = "rusCaption"
        Me.row7.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row8
        '
        Me.row8.Height = 25
        Me.row8.Name = "row8"
        Me.row8.Properties.Caption = "ИНН российского участника"
        Me.row8.Properties.FieldName = "rusInn"
        Me.row8.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row9
        '
        Me.row9.Name = "row9"
        Me.row9.Properties.Caption = "Иностранный покупатель (продавец)"
        Me.row9.Properties.FieldName = "nusCaption"
        Me.row9.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row10
        '
        Me.row10.Height = 25
        Me.row10.Name = "row10"
        Me.row10.Properties.Caption = "Потребитель (конечный пользователь)"
        Me.row10.Properties.FieldName = "endCaption"
        Me.row10.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'category3
        '
        Me.category3.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.row11, Me.row12, Me.row13, Me.row16, Me.row17, Me.row14, Me.row15})
        Me.category3.Height = 22
        Me.category3.Name = "category3"
        Me.category3.Properties.Caption = "Объект экспертизы"
        Me.category3.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row11
        '
        Me.row11.Height = 25
        Me.row11.Name = "row11"
        Me.row11.Properties.Caption = "Коммерческое наименование"
        Me.row11.Properties.FieldName = "goodName"
        Me.row11.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row12
        '
        Me.row12.Height = 25
        Me.row12.Name = "row12"
        Me.row12.Properties.Caption = "Код ТН ВЭД"
        Me.row12.Properties.FieldName = "goodTnved"
        Me.row12.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row13
        '
        Me.row13.Height = 25
        Me.row13.Name = "row13"
        Me.row13.Properties.Caption = "Соответствие контрольным спискам"
        Me.row13.Properties.FieldName = "goodEqualId"
        Me.row13.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.row13.Properties.RowEdit = Me.GoodEqualRepositoryItemLookUpEdit
        '
        'row16
        '
        Me.row16.Height = 25
        Me.row16.Name = "row16"
        Me.row16.Properties.Caption = "Обозначение контрольного списка"
        Me.row16.Properties.FieldName = "goodList"
        Me.row16.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.row16.Properties.RowEdit = Me.GoodListRepositoryItemLookUpEdit
        '
        'row17
        '
        Me.row17.Height = 25
        Me.row17.Name = "row17"
        Me.row17.Properties.Caption = "Номер пункта контрольного списка"
        Me.row17.Properties.FieldName = "goodPos"
        Me.row17.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row14
        '
        Me.row14.Height = 25
        Me.row14.Name = "row14"
        Me.row14.Properties.Caption = "Техническое описание"
        Me.row14.Properties.FieldName = "goodDescription"
        Me.row14.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row15
        '
        Me.row15.Height = 25
        Me.row15.Name = "row15"
        Me.row15.Properties.Caption = "Дополнительная информация"
        Me.row15.Properties.FieldName = "goodSummary"
        Me.row15.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'GoodListRepositoryItemLookUpEdit
        '
        Me.GoodListRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!)
        Me.GoodListRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.GoodListRepositoryItemLookUpEdit.AutoHeight = False
        Me.GoodListRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GoodListRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.GoodListRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.GoodListRepositoryItemLookUpEdit.DropDownRows = 6
        Me.GoodListRepositoryItemLookUpEdit.Name = "GoodListRepositoryItemLookUpEdit"
        Me.GoodListRepositoryItemLookUpEdit.NullText = ""
        Me.GoodListRepositoryItemLookUpEdit.ShowFooter = False
        Me.GoodListRepositoryItemLookUpEdit.ShowHeader = False
        Me.GoodListRepositoryItemLookUpEdit.ValueMember = "name"
        '
        'ConditionUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ConditionGridControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ConditionUserControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConditionGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnionRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrgRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodEqualRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodListRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents FindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ConditionGridControl As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents UnionRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents OrgRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GoodEqualRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents category As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents row As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents category1 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents row1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row3 As DevExpress.XtraVerticalGrid.Rows.MultiEditorRow
    Friend WithEvents MultiEditorRowProperties3 As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents MultiEditorRowProperties4 As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents category2 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents row4 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row5 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row6 As DevExpress.XtraVerticalGrid.Rows.MultiEditorRow
    Friend WithEvents MultiEditorRowProperties1 As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents MultiEditorRowProperties2 As DevExpress.XtraVerticalGrid.Rows.MultiEditorRowProperties
    Friend WithEvents row7 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row8 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row9 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row10 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents category3 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents row11 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row12 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row13 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row14 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row15 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row16 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row17 As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents GoodListRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

End Class
