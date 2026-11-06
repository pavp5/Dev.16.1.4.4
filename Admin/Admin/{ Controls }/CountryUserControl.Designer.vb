<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CountryUserControl
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CountryUserControl))
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CountryGridControl = New DevExpress.XtraGrid.GridControl()
        Me.CountryGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NameShortGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.NameLongGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CodAlpha2GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CodAlpha3GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CodDecGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsControlGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RiskDescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsActGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GuidGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.QueryComboBoxEdit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.ViewHeightBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem()
        Me.DataLoadXmlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem4 = New DevExpress.XtraBars.BarSubItem()
        Me.DataSaveBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataSaveXmlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MainPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.FidGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CountryGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QueryComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.CountryGridControl)
        Me.LayoutControl1.Controls.Add(Me.QueryComboBoxEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1108, 800)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CountryGridControl
        '
        Me.CountryGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.CountryGridControl.Location = New System.Drawing.Point(16, 47)
        Me.CountryGridControl.MainView = Me.CountryGridView
        Me.CountryGridControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CountryGridControl.Name = "CountryGridControl"
        Me.CountryGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.CountryGridControl.Size = New System.Drawing.Size(1076, 737)
        Me.CountryGridControl.TabIndex = 2
        Me.CountryGridControl.UseEmbeddedNavigator = True
        Me.CountryGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CountryGridView})
        '
        'CountryGridView
        '
        Me.CountryGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.CountryGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CountryGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryGridView.Appearance.Row.Options.UseFont = True
        Me.CountryGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdGridColumn, Me.NameShortGridColumn, Me.NameLongGridColumn, Me.CodAlpha2GridColumn, Me.CodAlpha3GridColumn, Me.CodDecGridColumn, Me.FidGridColumn, Me.IsControlGridColumn, Me.RiskDescriptionGridColumn, Me.IsActGridColumn, Me.GuidGridColumn})
        Me.CountryGridView.GridControl = Me.CountryGridControl
        Me.CountryGridView.Name = "CountryGridView"
        Me.CountryGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.CountryGridView.RowHeight = 25
        '
        'IdGridColumn
        '
        Me.IdGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.IdGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.IdGridColumn.Caption = "id"
        Me.IdGridColumn.FieldName = "id"
        Me.IdGridColumn.Name = "IdGridColumn"
        Me.IdGridColumn.OptionsColumn.FixedWidth = True
        Me.IdGridColumn.OptionsColumn.ReadOnly = True
        Me.IdGridColumn.Visible = True
        Me.IdGridColumn.VisibleIndex = 0
        '
        'NameShortGridColumn
        '
        Me.NameShortGridColumn.Caption = "nameShort"
        Me.NameShortGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.NameShortGridColumn.FieldName = "nameShort"
        Me.NameShortGridColumn.Name = "NameShortGridColumn"
        Me.NameShortGridColumn.Visible = True
        Me.NameShortGridColumn.VisibleIndex = 1
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'NameLongGridColumn
        '
        Me.NameLongGridColumn.Caption = "nameLong"
        Me.NameLongGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.NameLongGridColumn.FieldName = "nameLong"
        Me.NameLongGridColumn.Name = "NameLongGridColumn"
        Me.NameLongGridColumn.Visible = True
        Me.NameLongGridColumn.VisibleIndex = 2
        '
        'CodAlpha2GridColumn
        '
        Me.CodAlpha2GridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.CodAlpha2GridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CodAlpha2GridColumn.Caption = "codAlpha2"
        Me.CodAlpha2GridColumn.FieldName = "codAlpha2"
        Me.CodAlpha2GridColumn.Name = "CodAlpha2GridColumn"
        Me.CodAlpha2GridColumn.OptionsColumn.FixedWidth = True
        Me.CodAlpha2GridColumn.Visible = True
        Me.CodAlpha2GridColumn.VisibleIndex = 3
        '
        'CodAlpha3GridColumn
        '
        Me.CodAlpha3GridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.CodAlpha3GridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CodAlpha3GridColumn.Caption = "codAlpha3"
        Me.CodAlpha3GridColumn.FieldName = "codAlpha3"
        Me.CodAlpha3GridColumn.Name = "CodAlpha3GridColumn"
        Me.CodAlpha3GridColumn.OptionsColumn.FixedWidth = True
        Me.CodAlpha3GridColumn.Visible = True
        Me.CodAlpha3GridColumn.VisibleIndex = 4
        '
        'CodDecGridColumn
        '
        Me.CodDecGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.CodDecGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CodDecGridColumn.Caption = "codDec"
        Me.CodDecGridColumn.FieldName = "codDec"
        Me.CodDecGridColumn.Name = "CodDecGridColumn"
        Me.CodDecGridColumn.OptionsColumn.FixedWidth = True
        Me.CodDecGridColumn.Visible = True
        Me.CodDecGridColumn.VisibleIndex = 5
        '
        'IsControlGridColumn
        '
        Me.IsControlGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.IsControlGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.IsControlGridColumn.Caption = "isControl"
        Me.IsControlGridColumn.FieldName = "isControl"
        Me.IsControlGridColumn.Name = "IsControlGridColumn"
        Me.IsControlGridColumn.OptionsColumn.FixedWidth = True
        Me.IsControlGridColumn.Visible = True
        Me.IsControlGridColumn.VisibleIndex = 7
        '
        'RiskDescriptionGridColumn
        '
        Me.RiskDescriptionGridColumn.Caption = "riskDescription"
        Me.RiskDescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.RiskDescriptionGridColumn.FieldName = "riskDescription"
        Me.RiskDescriptionGridColumn.Name = "RiskDescriptionGridColumn"
        Me.RiskDescriptionGridColumn.Visible = True
        Me.RiskDescriptionGridColumn.VisibleIndex = 8
        '
        'IsActGridColumn
        '
        Me.IsActGridColumn.Caption = "isACT"
        Me.IsActGridColumn.FieldName = "isACT"
        Me.IsActGridColumn.Name = "IsActGridColumn"
        Me.IsActGridColumn.OptionsColumn.FixedWidth = True
        Me.IsActGridColumn.Visible = True
        Me.IsActGridColumn.VisibleIndex = 9
        '
        'GuidGridColumn
        '
        Me.GuidGridColumn.Caption = "guid"
        Me.GuidGridColumn.FieldName = "guid"
        Me.GuidGridColumn.Name = "GuidGridColumn"
        Me.GuidGridColumn.Visible = True
        Me.GuidGridColumn.VisibleIndex = 10
        '
        'QueryComboBoxEdit
        '
        Me.QueryComboBoxEdit.Location = New System.Drawing.Point(16, 16)
        Me.QueryComboBoxEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.QueryComboBoxEdit.Name = "QueryComboBoxEdit"
        ToolTipTitleItem1.Text = "Выполнить"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Выполнить запрос"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.QueryComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Выполнить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, SuperToolTip1, True)})
        Me.QueryComboBoxEdit.Size = New System.Drawing.Size(1076, 25)
        Me.QueryComboBoxEdit.StyleController = Me.LayoutControl1
        Me.QueryComboBoxEdit.TabIndex = 0
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "RootLayoutControlGroup"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1108, 800)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.QueryComboBoxEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1082, 31)
        Me.LayoutControlItem1.Text = "Запрос"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CountryGridControl
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1082, 743)
        Me.LayoutControlItem2.Text = "ТН ВЭД"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.ViewHeightBarButtonItem, Me.BarSubItem2, Me.BarSubItem3, Me.DataLoadXmlBarButtonItem, Me.BarSubItem4, Me.DataSaveBaseBarButtonItem, Me.DataSaveXmlBarButtonItem, Me.DataClearBarButtonItem})
        Me.BarManager1.MaxItemId = 9
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(1108, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 800)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1108, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 800)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1108, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 800)
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Вид"
        Me.BarSubItem1.Description = "Внешний вид списка стран мира"
        Me.BarSubItem1.Id = 0
        Me.BarSubItem1.LargeGlyph = CType(resources.GetObject("BarSubItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ViewHeightBarButtonItem)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'ViewHeightBarButtonItem
        '
        Me.ViewHeightBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ViewHeightBarButtonItem.Caption = "Выровнять высоту ячеек"
        Me.ViewHeightBarButtonItem.Description = "Выровнять высоту ячеек по содержимому"
        Me.ViewHeightBarButtonItem.Id = 1
        Me.ViewHeightBarButtonItem.LargeGlyph = CType(resources.GetObject("ViewHeightBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ViewHeightBarButtonItem.Name = "ViewHeightBarButtonItem"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "Данные"
        Me.BarSubItem2.Description = "Загрузить, сохранить перечитать"
        Me.BarSubItem2.Id = 2
        Me.BarSubItem2.LargeGlyph = CType(resources.GetObject("BarSubItem2.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.DataClearBarButtonItem, True)})
        Me.BarSubItem2.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'BarSubItem3
        '
        Me.BarSubItem3.Caption = "Загрузить"
        Me.BarSubItem3.Description = "Загрузить данные"
        Me.BarSubItem3.Id = 3
        Me.BarSubItem3.LargeGlyph = CType(resources.GetObject("BarSubItem3.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DataLoadXmlBarButtonItem)})
        Me.BarSubItem3.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem3.Name = "BarSubItem3"
        '
        'DataLoadXmlBarButtonItem
        '
        Me.DataLoadXmlBarButtonItem.Caption = "Файл XML"
        Me.DataLoadXmlBarButtonItem.Description = "Загрузить данные из файла XML"
        Me.DataLoadXmlBarButtonItem.Id = 4
        Me.DataLoadXmlBarButtonItem.LargeGlyph = CType(resources.GetObject("DataLoadXmlBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataLoadXmlBarButtonItem.Name = "DataLoadXmlBarButtonItem"
        '
        'BarSubItem4
        '
        Me.BarSubItem4.Caption = "Сохранить"
        Me.BarSubItem4.Description = "Сохранить данные"
        Me.BarSubItem4.Id = 5
        Me.BarSubItem4.LargeGlyph = CType(resources.GetObject("BarSubItem4.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DataSaveBaseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DataSaveXmlBarButtonItem)})
        Me.BarSubItem4.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem4.Name = "BarSubItem4"
        '
        'DataSaveBaseBarButtonItem
        '
        Me.DataSaveBaseBarButtonItem.Caption = "База данных"
        Me.DataSaveBaseBarButtonItem.Description = "Сохранить данные в базу даных"
        Me.DataSaveBaseBarButtonItem.Id = 6
        Me.DataSaveBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("DataSaveBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataSaveBaseBarButtonItem.Name = "DataSaveBaseBarButtonItem"
        '
        'DataSaveXmlBarButtonItem
        '
        Me.DataSaveXmlBarButtonItem.Caption = "Файл XML"
        Me.DataSaveXmlBarButtonItem.Description = "Сохранить данные в файл XML"
        Me.DataSaveXmlBarButtonItem.Id = 7
        Me.DataSaveXmlBarButtonItem.LargeGlyph = CType(resources.GetObject("DataSaveXmlBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataSaveXmlBarButtonItem.Name = "DataSaveXmlBarButtonItem"
        '
        'DataClearBarButtonItem
        '
        Me.DataClearBarButtonItem.Caption = "Очистить"
        Me.DataClearBarButtonItem.Description = "Очистить таблицу от всех данных"
        Me.DataClearBarButtonItem.Id = 8
        Me.DataClearBarButtonItem.LargeGlyph = CType(resources.GetObject("DataClearBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataClearBarButtonItem.Name = "DataClearBarButtonItem"
        '
        'MainPopupMenu
        '
        Me.MainPopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem2)})
        Me.MainPopupMenu.Manager = Me.BarManager1
        Me.MainPopupMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.MainPopupMenu.Name = "MainPopupMenu"
        '
        'FidGridColumn
        '
        Me.FidGridColumn.Caption = "fid"
        Me.FidGridColumn.FieldName = "fid"
        Me.FidGridColumn.Name = "FidGridColumn"
        Me.FidGridColumn.OptionsColumn.FixedWidth = True
        Me.FidGridColumn.Visible = True
        Me.FidGridColumn.VisibleIndex = 6
        '
        'CountryUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CountryUserControl"
        Me.Size = New System.Drawing.Size(1108, 800)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CountryGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QueryComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents CountryGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CountryGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents QueryComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents IdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameShortGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameLongGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CodAlpha2GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CodAlpha3GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CodDecGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsControlGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RiskDescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsActGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents MainPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ViewHeightBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DataLoadXmlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem4 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DataSaveBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataSaveXmlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GuidGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FidGridColumn As DevExpress.XtraGrid.Columns.GridColumn

End Class
