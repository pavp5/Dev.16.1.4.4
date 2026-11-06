<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmbargoUserControl
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmbargoUserControl))
        Me.IsActGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.EmbargoGridControl = New DevExpress.XtraGrid.GridControl()
        Me.EmbargoGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Caption2GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ModeIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsLimitedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.CountryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MemberBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.ViewHeightBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem()
        Me.DataSaveBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataReloadBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem4 = New DevExpress.XtraBars.BarSubItem()
        Me.FileToBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileFromBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileDelBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.TnvedBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MainPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.EmbargoGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmbargoGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsActGridColumn
        '
        Me.IsActGridColumn.Caption = "isACT"
        Me.IsActGridColumn.FieldName = "isACT"
        Me.IsActGridColumn.Name = "IsActGridColumn"
        Me.IsActGridColumn.OptionsColumn.FixedWidth = True
        Me.IsActGridColumn.Visible = True
        Me.IsActGridColumn.VisibleIndex = 5
        Me.IsActGridColumn.Width = 60
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.EmbargoGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(770, 367, 312, 437)
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(986, 528)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(13, 13)
        Me.StandaloneBarDockControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(960, 25)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'EmbargoGridControl
        '
        Me.EmbargoGridControl.Location = New System.Drawing.Point(13, 42)
        Me.EmbargoGridControl.MainView = Me.EmbargoGridView
        Me.EmbargoGridControl.Name = "EmbargoGridControl"
        Me.EmbargoGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.EmbargoGridControl.Size = New System.Drawing.Size(960, 473)
        Me.EmbargoGridControl.TabIndex = 3
        Me.EmbargoGridControl.UseEmbeddedNavigator = True
        Me.EmbargoGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.EmbargoGridView})
        '
        'EmbargoGridView
        '
        Me.EmbargoGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.EmbargoGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.EmbargoGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.EmbargoGridView.Appearance.Row.Options.UseFont = True
        Me.EmbargoGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdGridColumn, Me.CaptionGridColumn, Me.Caption2GridColumn, Me.ModeIdGridColumn, Me.IsLimitedGridColumn, Me.IsActGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsActGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = False
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.EmbargoGridView.FormatRules.Add(GridFormatRule1)
        Me.EmbargoGridView.GridControl = Me.EmbargoGridControl
        Me.EmbargoGridView.Name = "EmbargoGridView"
        Me.EmbargoGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.EmbargoGridView.OptionsDetail.EnableMasterViewMode = False
        Me.EmbargoGridView.OptionsView.ShowGroupPanel = False
        Me.EmbargoGridView.RowHeight = 25
        '
        'IdGridColumn
        '
        Me.IdGridColumn.Caption = "id"
        Me.IdGridColumn.FieldName = "id"
        Me.IdGridColumn.Name = "IdGridColumn"
        Me.IdGridColumn.OptionsColumn.FixedWidth = True
        Me.IdGridColumn.Visible = True
        Me.IdGridColumn.VisibleIndex = 0
        Me.IdGridColumn.Width = 60
        '
        'CaptionGridColumn
        '
        Me.CaptionGridColumn.Caption = "caption"
        Me.CaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.CaptionGridColumn.FieldName = "caption"
        Me.CaptionGridColumn.Name = "CaptionGridColumn"
        Me.CaptionGridColumn.Visible = True
        Me.CaptionGridColumn.VisibleIndex = 1
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'Caption2GridColumn
        '
        Me.Caption2GridColumn.Caption = "caption2"
        Me.Caption2GridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.Caption2GridColumn.FieldName = "caption2"
        Me.Caption2GridColumn.Name = "Caption2GridColumn"
        Me.Caption2GridColumn.Visible = True
        Me.Caption2GridColumn.VisibleIndex = 2
        '
        'ModeIdGridColumn
        '
        Me.ModeIdGridColumn.Caption = "modeId"
        Me.ModeIdGridColumn.FieldName = "modeId"
        Me.ModeIdGridColumn.Name = "ModeIdGridColumn"
        Me.ModeIdGridColumn.OptionsColumn.FixedWidth = True
        Me.ModeIdGridColumn.Visible = True
        Me.ModeIdGridColumn.VisibleIndex = 3
        Me.ModeIdGridColumn.Width = 60
        '
        'IsLimitedGridColumn
        '
        Me.IsLimitedGridColumn.Caption = "isLimited"
        Me.IsLimitedGridColumn.FieldName = "isLimited"
        Me.IsLimitedGridColumn.Name = "IsLimitedGridColumn"
        Me.IsLimitedGridColumn.OptionsColumn.FixedWidth = True
        Me.IsLimitedGridColumn.Visible = True
        Me.IsLimitedGridColumn.VisibleIndex = 4
        Me.IsLimitedGridColumn.Width = 60
        '
        'RootLayoutControlGroup
        '
        Me.RootLayoutControlGroup.AppearanceGroup.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceGroup.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceItemCaption.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceItemCaption.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = True
        Me.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.RootLayoutControlGroup.GroupBordersVisible = False
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(986, 528)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.EmbargoGridControl
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 29)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(964, 477)
        Me.LayoutControlItem2.Text = "Запреты и ограничения"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(964, 29)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.CountryBarButtonItem, Me.MemberBarButtonItem, Me.GoodBarButtonItem, Me.BarSubItem1, Me.BarSubItem2, Me.ViewHeightBarButtonItem, Me.BarSubItem3, Me.DataSaveBaseBarButtonItem, Me.DataReloadBaseBarButtonItem, Me.BarSubItem4, Me.FileToBaseBarButtonItem, Me.FileFromBaseBarButtonItem, Me.FileDelBaseBarButtonItem, Me.TnvedBarButtonItem})
        Me.BarManager1.MaxItemId = 14
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(82, 188)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.CountryBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.MemberBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.GoodBarButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'CountryBarButtonItem
        '
        Me.CountryBarButtonItem.Caption = "Страны"
        Me.CountryBarButtonItem.Id = 0
        Me.CountryBarButtonItem.Name = "CountryBarButtonItem"
        '
        'MemberBarButtonItem
        '
        Me.MemberBarButtonItem.Caption = "Фирмы"
        Me.MemberBarButtonItem.Id = 1
        Me.MemberBarButtonItem.Name = "MemberBarButtonItem"
        '
        'GoodBarButtonItem
        '
        Me.GoodBarButtonItem.Caption = "Товары"
        Me.GoodBarButtonItem.Id = 2
        Me.GoodBarButtonItem.Name = "GoodBarButtonItem"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlTop.Size = New System.Drawing.Size(986, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 528)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(986, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 528)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(986, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 528)
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "BarSubItem1"
        Me.BarSubItem1.Id = 3
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "Вид"
        Me.BarSubItem2.Description = "Внешний вид списка запретов и ограничений"
        Me.BarSubItem2.Id = 4
        Me.BarSubItem2.LargeGlyph = CType(resources.GetObject("BarSubItem2.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ViewHeightBarButtonItem)})
        Me.BarSubItem2.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'ViewHeightBarButtonItem
        '
        Me.ViewHeightBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ViewHeightBarButtonItem.Caption = "Выровнять высоту строк"
        Me.ViewHeightBarButtonItem.Description = "Выровнять высоту строк по содержимому"
        Me.ViewHeightBarButtonItem.Id = 5
        Me.ViewHeightBarButtonItem.LargeGlyph = CType(resources.GetObject("ViewHeightBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ViewHeightBarButtonItem.Name = "ViewHeightBarButtonItem"
        '
        'BarSubItem3
        '
        Me.BarSubItem3.Caption = "Данные"
        Me.BarSubItem3.Description = "Загрузить, сохранить, перечитать ..."
        Me.BarSubItem3.Id = 6
        Me.BarSubItem3.LargeGlyph = CType(resources.GetObject("BarSubItem3.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DataSaveBaseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DataReloadBaseBarButtonItem)})
        Me.BarSubItem3.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem3.Name = "BarSubItem3"
        '
        'DataSaveBaseBarButtonItem
        '
        Me.DataSaveBaseBarButtonItem.Caption = "Сохранить"
        Me.DataSaveBaseBarButtonItem.Description = "Сохранить данные в базу"
        Me.DataSaveBaseBarButtonItem.Id = 7
        Me.DataSaveBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("DataSaveBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataSaveBaseBarButtonItem.Name = "DataSaveBaseBarButtonItem"
        '
        'DataReloadBaseBarButtonItem
        '
        Me.DataReloadBaseBarButtonItem.Caption = "Перечитать"
        Me.DataReloadBaseBarButtonItem.Description = "Перечитать данные из базы"
        Me.DataReloadBaseBarButtonItem.Id = 8
        Me.DataReloadBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("DataReloadBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataReloadBaseBarButtonItem.Name = "DataReloadBaseBarButtonItem"
        '
        'BarSubItem4
        '
        Me.BarSubItem4.Caption = "Документ"
        Me.BarSubItem4.Description = "Загрузить, выгрузить, удалить файл документа"
        Me.BarSubItem4.Id = 9
        Me.BarSubItem4.LargeGlyph = CType(resources.GetObject("BarSubItem4.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FileToBaseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FileFromBaseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FileDelBaseBarButtonItem)})
        Me.BarSubItem4.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem4.Name = "BarSubItem4"
        '
        'FileToBaseBarButtonItem
        '
        Me.FileToBaseBarButtonItem.Caption = "Загрузить"
        Me.FileToBaseBarButtonItem.Description = "Загрузить в базу данных файл документа"
        Me.FileToBaseBarButtonItem.Id = 10
        Me.FileToBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("FileToBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FileToBaseBarButtonItem.Name = "FileToBaseBarButtonItem"
        '
        'FileFromBaseBarButtonItem
        '
        Me.FileFromBaseBarButtonItem.Caption = "Выгрузить"
        Me.FileFromBaseBarButtonItem.Description = "Выгрузить из базы данных файл документа"
        Me.FileFromBaseBarButtonItem.Id = 11
        Me.FileFromBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("FileFromBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FileFromBaseBarButtonItem.Name = "FileFromBaseBarButtonItem"
        '
        'FileDelBaseBarButtonItem
        '
        Me.FileDelBaseBarButtonItem.Caption = "Удалить"
        Me.FileDelBaseBarButtonItem.Description = "Удалить в базе данных файл документа"
        Me.FileDelBaseBarButtonItem.Id = 12
        Me.FileDelBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("FileDelBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FileDelBaseBarButtonItem.Name = "FileDelBaseBarButtonItem"
        '
        'TnvedBarButtonItem
        '
        Me.TnvedBarButtonItem.Caption = "Переписать коды ТН ВЭД товаров"
        Me.TnvedBarButtonItem.Description = "Переписать в базе данных таблицу кодов ТН ВЭД"
        Me.TnvedBarButtonItem.Id = 13
        Me.TnvedBarButtonItem.LargeGlyph = CType(resources.GetObject("TnvedBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.TnvedBarButtonItem.Name = "TnvedBarButtonItem"
        '
        'MainPopupMenu
        '
        Me.MainPopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem4, True), New DevExpress.XtraBars.LinkPersistInfo(Me.TnvedBarButtonItem, True)})
        Me.MainPopupMenu.Manager = Me.BarManager1
        Me.MainPopupMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.MainPopupMenu.Name = "MainPopupMenu"
        '
        'EmbargoUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "EmbargoUserControl"
        Me.Size = New System.Drawing.Size(986, 528)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.EmbargoGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmbargoGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmbargoGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents EmbargoGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents CountryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MemberBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Public WithEvents MainPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents IdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Caption2GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ModeIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsLimitedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsActGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ViewHeightBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DataSaveBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataReloadBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem4 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents FileToBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileFromBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileDelBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TnvedBarButtonItem As DevExpress.XtraBars.BarButtonItem

End Class
