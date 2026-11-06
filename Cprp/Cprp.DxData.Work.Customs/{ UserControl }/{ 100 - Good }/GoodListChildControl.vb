Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Список продукции в виде таблицы"
''' </summary>
Friend Class GoodListChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents EditorBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents FindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodDownloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodUploadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodBarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents FileDownloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileUploadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileBarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ListClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodDelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodAddBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ListGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ListGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RowNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameConGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MemoRepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents NameDecGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AreaGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UsedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TnvedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CategoryGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CategoryRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents IsCheckStudyGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodListChildControl))
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
        Me.IsCheckStudyGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RowNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.GoodOpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodAddBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodDelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ListClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileBarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.FileUploadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileDownloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodBarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.GoodUploadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodDownloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditorBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameConGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MemoRepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.NameDecGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AreaGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UsedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TnvedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CategoryGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CategoryRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoRepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CategoryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckStudyGridColumn
        '
        Me.IsCheckStudyGridColumn.Caption = "Исследование"
        Me.IsCheckStudyGridColumn.FieldName = "isCheckStudy"
        Me.IsCheckStudyGridColumn.Name = "IsCheckStudyGridColumn"
        Me.IsCheckStudyGridColumn.OptionsColumn.ShowInCustomizationForm = False
        '
        'RowNumGridColumn
        '
        Me.RowNumGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowNumGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowNumGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.RowNumGridColumn.Caption = "№№<color='red'>*</color>"
        Me.RowNumGridColumn.FieldName = "rowNum"
        Me.RowNumGridColumn.Name = "RowNumGridColumn"
        Me.RowNumGridColumn.OptionsColumn.FixedWidth = True
        Me.RowNumGridColumn.Visible = True
        Me.RowNumGridColumn.VisibleIndex = 0
        Me.RowNumGridColumn.Width = 60
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.GoodOpenBarButtonItem, Me.GoodAddBarButtonItem, Me.GoodDelBarButtonItem, Me.ListClearBarButtonItem, Me.FileBarSubItem, Me.GoodBarSubItem, Me.FileUploadBarButtonItem, Me.FileDownloadBarButtonItem, Me.GoodUploadBarButtonItem, Me.GoodDownloadBarButtonItem, Me.FindBarButtonItem, Me.EditorBarCheckItem})
        Me.BarManager1.MaxItemId = 20
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(82, 171)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodOpenBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodAddBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.GoodDelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ListClearBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FileBarSubItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodBarSubItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditorBarCheckItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'GoodOpenBarButtonItem
        '
        Me.GoodOpenBarButtonItem.Caption = "Объект"
        Me.GoodOpenBarButtonItem.Glyph = CType(resources.GetObject("GoodOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.GoodOpenBarButtonItem.Id = 0
        Me.GoodOpenBarButtonItem.Name = "GoodOpenBarButtonItem"
        ToolTipTitleItem1.Text = "Объект"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к регистрационным данным объекта"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.GoodOpenBarButtonItem.SuperTip = SuperToolTip1
        '
        'GoodAddBarButtonItem
        '
        Me.GoodAddBarButtonItem.Caption = "Добавить"
        Me.GoodAddBarButtonItem.Glyph = CType(resources.GetObject("GoodAddBarButtonItem.Glyph"), System.Drawing.Image)
        Me.GoodAddBarButtonItem.Id = 1
        Me.GoodAddBarButtonItem.Name = "GoodAddBarButtonItem"
        ToolTipTitleItem2.Text = "Добавить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Добавить новый объект"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.GoodAddBarButtonItem.SuperTip = SuperToolTip2
        '
        'GoodDelBarButtonItem
        '
        Me.GoodDelBarButtonItem.Caption = "Удалить"
        Me.GoodDelBarButtonItem.Glyph = CType(resources.GetObject("GoodDelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.GoodDelBarButtonItem.Id = 2
        Me.GoodDelBarButtonItem.Name = "GoodDelBarButtonItem"
        ToolTipTitleItem3.Text = "Удалить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Удалить объект"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.GoodDelBarButtonItem.SuperTip = SuperToolTip3
        '
        'ListClearBarButtonItem
        '
        Me.ListClearBarButtonItem.Caption = "Удалить все"
        Me.ListClearBarButtonItem.Glyph = CType(resources.GetObject("ListClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ListClearBarButtonItem.Id = 3
        Me.ListClearBarButtonItem.Name = "ListClearBarButtonItem"
        ToolTipTitleItem4.Text = "Удалить все"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Удалить все объекты"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.ListClearBarButtonItem.SuperTip = SuperToolTip4
        '
        'FileBarSubItem
        '
        Me.FileBarSubItem.Caption = "Файлы"
        Me.FileBarSubItem.Glyph = CType(resources.GetObject("FileBarSubItem.Glyph"), System.Drawing.Image)
        Me.FileBarSubItem.Id = 5
        Me.FileBarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FileUploadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FileDownloadBarButtonItem)})
        Me.FileBarSubItem.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.FileBarSubItem.Name = "FileBarSubItem"
        Me.FileBarSubItem.PopupMinWidth = 290
        '
        'FileUploadBarButtonItem
        '
        Me.FileUploadBarButtonItem.Caption = "Выгрузить"
        Me.FileUploadBarButtonItem.Description = "Выгрузить объекты экспертизы в файл с загрузочной таблицей"
        Me.FileUploadBarButtonItem.Id = 7
        Me.FileUploadBarButtonItem.LargeGlyph = CType(resources.GetObject("FileUploadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FileUploadBarButtonItem.Name = "FileUploadBarButtonItem"
        '
        'FileDownloadBarButtonItem
        '
        Me.FileDownloadBarButtonItem.Caption = "Загрузить"
        Me.FileDownloadBarButtonItem.Description = "Загрузить объекты экспертизы из файла с загрузочной таблицей"
        Me.FileDownloadBarButtonItem.Id = 8
        Me.FileDownloadBarButtonItem.LargeGlyph = CType(resources.GetObject("FileDownloadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FileDownloadBarButtonItem.Name = "FileDownloadBarButtonItem"
        '
        'GoodBarSubItem
        '
        Me.GoodBarSubItem.Caption = "Объекты"
        Me.GoodBarSubItem.Glyph = CType(resources.GetObject("GoodBarSubItem.Glyph"), System.Drawing.Image)
        Me.GoodBarSubItem.Id = 6
        Me.GoodBarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.GoodUploadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.GoodDownloadBarButtonItem)})
        Me.GoodBarSubItem.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.GoodBarSubItem.Name = "GoodBarSubItem"
        Me.GoodBarSubItem.PopupMinWidth = 290
        '
        'GoodUploadBarButtonItem
        '
        Me.GoodUploadBarButtonItem.Caption = "Выгрузить"
        Me.GoodUploadBarButtonItem.Description = "Выгрузить данные объекта экспертизы в другие объекты экспертизы"
        Me.GoodUploadBarButtonItem.Id = 9
        Me.GoodUploadBarButtonItem.LargeGlyph = CType(resources.GetObject("GoodUploadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.GoodUploadBarButtonItem.Name = "GoodUploadBarButtonItem"
        '
        'GoodDownloadBarButtonItem
        '
        Me.GoodDownloadBarButtonItem.Caption = "Загрузить"
        Me.GoodDownloadBarButtonItem.Description = "Загрузить в объект экспертизы данные из другого объекта экспертизы"
        Me.GoodDownloadBarButtonItem.Id = 10
        Me.GoodDownloadBarButtonItem.LargeGlyph = CType(resources.GetObject("GoodDownloadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.GoodDownloadBarButtonItem.Name = "GoodDownloadBarButtonItem"
        '
        'FindBarButtonItem
        '
        Me.FindBarButtonItem.Caption = "Поиск"
        Me.FindBarButtonItem.Glyph = CType(resources.GetObject("FindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FindBarButtonItem.Id = 11
        Me.FindBarButtonItem.Name = "FindBarButtonItem"
        ToolTipTitleItem5.Text = "Поиск"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Поиск объектов экспертизы в базе данных по их обозначениям"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.FindBarButtonItem.SuperTip = SuperToolTip5
        '
        'EditorBarCheckItem
        '
        Me.EditorBarCheckItem.BindableChecked = True
        Me.EditorBarCheckItem.Caption = "Редактор"
        Me.EditorBarCheckItem.Checked = True
        Me.EditorBarCheckItem.Glyph = CType(resources.GetObject("EditorBarCheckItem.Glyph"), System.Drawing.Image)
        Me.EditorBarCheckItem.GroupIndex = 3
        Me.EditorBarCheckItem.Id = 19
        Me.EditorBarCheckItem.Name = "EditorBarCheckItem"
        ToolTipTitleItem6.Text = "Редактор"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Выйти из режима редактирования списка"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.EditorBarCheckItem.SuperTip = SuperToolTip6
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
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
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.ListGridControl)
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
        'ListGridControl
        '
        Me.ListGridControl.Location = New System.Drawing.Point(12, 93)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.MemoRepositoryItemMemoEdit, Me.CategoryRepositoryItemLookUpEdit})
        Me.ListGridControl.Size = New System.Drawing.Size(926, 555)
        Me.ListGridControl.TabIndex = 8
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ListGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RowNumGridColumn, Me.NameConGridColumn, Me.NameDecGridColumn, Me.AreaGridColumn, Me.UsedGridColumn, Me.DescriptionGridColumn, Me.TnvedGridColumn, Me.CategoryGridColumn, Me.IsCheckStudyGridColumn})
        GridFormatRule1.Column = Me.IsCheckStudyGridColumn
        GridFormatRule1.ColumnApplyTo = Me.RowNumGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.ListGridView.FormatRules.Add(GridFormatRule1)
        Me.ListGridView.GridControl = Me.ListGridControl
        Me.ListGridView.GroupRowHeight = 25
        Me.ListGridView.Name = "ListGridView"
        Me.ListGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ListGridView.OptionsCustomization.AllowFilter = False
        Me.ListGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ListGridView.OptionsDetail.EnableMasterViewMode = False
        Me.ListGridView.OptionsMenu.EnableColumnMenu = False
        Me.ListGridView.OptionsNavigation.AutoFocusNewRow = True
        Me.ListGridView.OptionsView.AllowHtmlDrawHeaders = True
        Me.ListGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsView.RowAutoHeight = True
        Me.ListGridView.OptionsView.ShowGroupPanel = False
        Me.ListGridView.RowHeight = 30
        '
        'NameConGridColumn
        '
        Me.NameConGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.NameConGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.NameConGridColumn.Caption = "Коммерческое наименование<color='red'>*</color>"
        Me.NameConGridColumn.ColumnEdit = Me.MemoRepositoryItemMemoEdit
        Me.NameConGridColumn.FieldName = "nameCon"
        Me.NameConGridColumn.Name = "NameConGridColumn"
        Me.NameConGridColumn.Visible = True
        Me.NameConGridColumn.VisibleIndex = 1
        Me.NameConGridColumn.Width = 129
        '
        'MemoRepositoryItemMemoEdit
        '
        Me.MemoRepositoryItemMemoEdit.Name = "MemoRepositoryItemMemoEdit"
        '
        'NameDecGridColumn
        '
        Me.NameDecGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.NameDecGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.NameDecGridColumn.Caption = "Обозначение"
        Me.NameDecGridColumn.FieldName = "nameDec"
        Me.NameDecGridColumn.Name = "NameDecGridColumn"
        Me.NameDecGridColumn.Visible = True
        Me.NameDecGridColumn.VisibleIndex = 2
        Me.NameDecGridColumn.Width = 133
        '
        'AreaGridColumn
        '
        Me.AreaGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.AreaGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.AreaGridColumn.Caption = "Область применения"
        Me.AreaGridColumn.ColumnEdit = Me.MemoRepositoryItemMemoEdit
        Me.AreaGridColumn.FieldName = "area"
        Me.AreaGridColumn.Name = "AreaGridColumn"
        Me.AreaGridColumn.Visible = True
        Me.AreaGridColumn.VisibleIndex = 3
        Me.AreaGridColumn.Width = 129
        '
        'UsedGridColumn
        '
        Me.UsedGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.UsedGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.UsedGridColumn.Caption = "Назначение"
        Me.UsedGridColumn.ColumnEdit = Me.MemoRepositoryItemMemoEdit
        Me.UsedGridColumn.FieldName = "used"
        Me.UsedGridColumn.Name = "UsedGridColumn"
        Me.UsedGridColumn.Visible = True
        Me.UsedGridColumn.VisibleIndex = 4
        Me.UsedGridColumn.Width = 129
        '
        'DescriptionGridColumn
        '
        Me.DescriptionGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.DescriptionGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.DescriptionGridColumn.Caption = "Техническое описание<color='red'>*</color>"
        Me.DescriptionGridColumn.ColumnEdit = Me.MemoRepositoryItemMemoEdit
        Me.DescriptionGridColumn.FieldName = "description"
        Me.DescriptionGridColumn.Name = "DescriptionGridColumn"
        Me.DescriptionGridColumn.Visible = True
        Me.DescriptionGridColumn.VisibleIndex = 5
        Me.DescriptionGridColumn.Width = 129
        '
        'TnvedGridColumn
        '
        Me.TnvedGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.TnvedGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TnvedGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.TnvedGridColumn.Caption = "Код ТН ВЭД<color='red'>*</color>"
        Me.TnvedGridColumn.FieldName = "tnved"
        Me.TnvedGridColumn.Name = "TnvedGridColumn"
        Me.TnvedGridColumn.OptionsColumn.FixedWidth = True
        Me.TnvedGridColumn.Visible = True
        Me.TnvedGridColumn.VisibleIndex = 6
        Me.TnvedGridColumn.Width = 130
        '
        'CategoryGridColumn
        '
        Me.CategoryGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.CategoryGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CategoryGridColumn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.CategoryGridColumn.Caption = "Вид<color='red'>*</color>"
        Me.CategoryGridColumn.ColumnEdit = Me.CategoryRepositoryItemLookUpEdit
        Me.CategoryGridColumn.FieldName = "typeId"
        Me.CategoryGridColumn.Name = "CategoryGridColumn"
        Me.CategoryGridColumn.OptionsColumn.FixedWidth = True
        Me.CategoryGridColumn.Visible = True
        Me.CategoryGridColumn.VisibleIndex = 7
        Me.CategoryGridColumn.Width = 80
        '
        'CategoryRepositoryItemLookUpEdit
        '
        Me.CategoryRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CategoryRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.CategoryRepositoryItemLookUpEdit.AutoHeight = False
        Me.CategoryRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CategoryRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("codeName", "codeName")})
        Me.CategoryRepositoryItemLookUpEdit.DisplayMember = "code"
        Me.CategoryRepositoryItemLookUpEdit.DropDownRows = 10
        Me.CategoryRepositoryItemLookUpEdit.Name = "CategoryRepositoryItemLookUpEdit"
        Me.CategoryRepositoryItemLookUpEdit.NullText = ""
        Me.CategoryRepositoryItemLookUpEdit.PopupWidth = 600
        Me.CategoryRepositoryItemLookUpEdit.ShowFooter = False
        Me.CategoryRepositoryItemLookUpEdit.ShowHeader = False
        Me.CategoryRepositoryItemLookUpEdit.ValueMember = "id"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1, Me.LayoutControlItem2})
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
        Me.CaptionSimpleLabelItem.Text = "Продукция"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ListGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 559)
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
        'GoodListChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodListChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoRepositoryItemMemoEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CategoryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Восстановление настроек
        '
        Dim sTmp As String = String.Format("{0}\goodgridlayout.xml", Application.StartupPath)
        If My.Computer.FileSystem.FileExists(sTmp) Then ListGridView.RestoreLayoutFromXml(sTmp)
        ListGridView.OptionsView.AllowHtmlDrawHeaders = True
        '
        ' Перемещение фокуса к активному объекту
        '
        Dim iTmp = 0
        ListGridView.MoveFirst()
        While ListGridView.IsValidRowHandle(iTmp)
            If CInt(ListGridView.GetDataRow(iTmp)("id")) = MyClass.GoodId Then
                ListGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        GoodAddBarButtonItem.Enabled = Not bLock
        GoodDelBarButtonItem.Enabled = Not bLock
        ListClearBarButtonItem.Enabled = Not bLock
        FileDownloadBarButtonItem.Enabled = Not bLock
        GoodUploadBarButtonItem.Enabled = Not bLock
        GoodDownloadBarButtonItem.Enabled = Not bLock
        FindBarButtonItem.Enabled = Not bLock
        ListGridView.OptionsBehavior.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Список продукции
        '
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        P.Work.GoodTable.AcceptChanges()
        '
        ' Сохранение настроек
        '
        ListGridView.SaveLayoutToXml(String.Format("{0}\goodgridlayout.xml", Application.StartupPath))
    End Sub

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
        MyBase.Content = ContentEnum.GoodList
        CategoryRepositoryItemLookUpEdit.DataSource = P.Work.GoodTypeHandbookTable
        ListGridControl.DataSource = P.Work.GoodTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        ListGridControl.Focus()
    End Sub

    Private Sub ListGridView_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles ListGridView.CustomDrawCell
        Dim sTmp As String = Nothing
        If Not (e.CellValue Is Nothing OrElse IsDBNull(e.CellValue)) Then sTmp = e.CellValue.ToString
        If Not String.IsNullOrEmpty(sTmp) Then Exit Sub
        Select Case e.Column.FieldName
            Case "rowNum", "nameCon", "description", "tnved", "categoryId"
                e.DisplayText = "[обязательное поле]"
                e.Appearance.ForeColor = Drawing.SystemColors.InactiveCaptionText
        End Select
    End Sub

    ' Перейти к регистрационным данным объекта
    Private Sub GoodOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        P.ContentOpen(ContentEnum.GoodData, ListGridView.GetFocusedDataRow("id"))
    End Sub

    Private Sub ListGridView_DoubleClick(sender As Object, e As EventArgs) Handles ListGridView.DoubleClick
        GoodOpenBarButtonItem.PerformClick()
    End Sub

    ' Добавить новый объект
    Private Sub GoodAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodAddBarButtonItem.ItemClick
        '
        ' Добавление нового объекта в таблицу продукции
        '
        Dim Row As DataRow = P.Work.GoodTable.AddNew
        '
        ' Переход к регистрационным данным нового объекта
        '
        P.ContentOpen(ContentEnum.GoodData, Row("id"))
    End Sub

    ' Удалить объект
    Private Sub GoodDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodDelBarButtonItem.ItemClick
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Удалить объект № {0}?", C2.ToInt(ListGridView.GetFocusedDataRow("rowNum")))) <> DialogResult.Yes Then Exit Sub
        Dim goodId As Integer = CInt(ListGridView.GetFocusedDataRow("id"))
        P.Work.GoodEmbargoTable.DeleteGood(goodId)
        P.Work.GoodControlTable.DeleteGood(goodId)
        P.Work.GoodLawTable.DeleteGood(goodId)
        P.Work.GoodRiskTable.DeleteGood(goodId)
        ListGridView.GetFocusedDataRow.Delete()
        ListGridView.RefreshData()
        ListGridControl.Focus()
        MyBase.SetChangeDateNow()
    End Sub

    ' Удалить все объекты
    Private Sub ListClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListClearBarButtonItem.ItemClick
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить все объекты?") <> DialogResult.Yes Then Exit Sub
        P.Work.GoodEmbargoTable.Rows.Clear()
        P.Work.GoodLawTable.Rows.Clear()
        P.Work.GoodRiskTable.Rows.Clear()
        P.Work.GoodTable.Rows.Clear()
        ListGridView.RefreshData()
        ListGridControl.Focus()
        MyBase.SetChangeDateNow()
    End Sub

    ' Выгрузить объекты экспертизы в файл с загрузочной таблицей
    Private Sub FileUploadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileUploadBarButtonItem.ItemClick
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Сохранение данных в файл"
            Dlg.FileName = String.Format("Работа № {0} (Объекты экспертизы + документы)", CInt(P.Work.Id))
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            DataWrite()
            '
            ' Создание загрузочного файла
            '
            P.Work.DataToRtf(filePath)
            Cprp.DxCommon.WaitForm.Close()
            '
            ' Открытие файла с загрузочной таблицей внешней программой
            '
            If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?") = DialogResult.Yes Then
                Using P As New Process
                    P.StartInfo.FileName = Trim(filePath)
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Загрузить объекты экспертизы из файла с загрузочной таблицей
    Private Sub FileDownloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileDownloadBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        '
        ' Выбор загрузочного файла
        '
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        '
        ' Загрузка данных
        '
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            P.Work.GoodFromRtf(filePath)
            DataRead()
            MyBase.SetChangeDateNow()
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Выгрузить данные объекта экспертизы в другие объекты экспертизы
    Private Sub GoodUploadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodUploadBarButtonItem.ItemClick
        If P.Work.GoodTable.Rows.Count < 2 Then Exit Sub
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        ListGridView.BeginDataUpdate()
        With New GoodExportForm(P, ListGridView.GetFocusedDataRow)
            If .ShowDialog() = DialogResult.OK Then
                MyBase.SetChangeDateNow()
                Cprp.DxCommon.Messages.ShowInformation("Данные выгружены в указанные объекты.", "Выгрузка данных")
            End If
        End With
        ListGridView.EndDataUpdate()
    End Sub

    ' Загрузить в объект экспертизы данные из другого объекта экспертизы
    Private Sub GoodDownloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodDownloadBarButtonItem.ItemClick
        If P.Work.GoodTable.Rows.Count < 2 Then Exit Sub
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        ListGridView.BeginDataUpdate()
        With New GoodImportForm(P, ListGridView.GetFocusedDataRow)
            If .ShowDialog() = DialogResult.OK Then
                MyBase.SetChangeDateNow()
                Cprp.DxCommon.Messages.ShowInformation("Данные загружены из указанного объекта.", "Загрузка данных")
            End If
        End With
        ListGridView.EndDataUpdate()
    End Sub

    ' Поиск в базе данных объектов экспертизы по их обозначениям
    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        If P.Work.GoodTable.Rows.Count = 0 Then Exit Sub
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Try
            With New GoodLoadForm
                If .ShowDialog <> DialogResult.OK Then Exit Sub
                DataWrite()
                For Each Row As DataRow In P.Work.GoodTable.Rows
                    sTmp = C2.ToText(Row("nameDec"))
                    If Not C2.IsText(sTmp) Then Continue For
                    Using Dr As SqlDataReader = P.Work.ExecuteReader(String.Format("SELECT * FROM tGood WHERE nameDec LIKE '{0}' ORDER BY id DESC", sTmp))
                        If Dr.Read Then
                            If .NameConCheckEdit.Checked Then Row("nameCon") = Dr("nameCon")
                            If .TnvedCheckEdit.Checked Then
                                Row("tnved") = Dr("tnved")
                                Row("tnvedComment") = Dr("tnvedComment")
                            End If
                            If .CasCheckEdit.Checked Then Row("cas") = Dr("cas")
                            If .CategoryCheckEdit.Checked Then Row("categoryId") = Dr("categoryId")
                            If .DescriptionCheckEdit.Checked Then Row("description") = Dr("description")
                            If .UsedCheckEdit.Checked Then Row("used") = Dr("used")
                            If .AreaCheckEdit.Checked Then Row("area") = Dr("area")
                            iTmp += 1
                        End If
                    End Using
                Next
            End With
            If iTmp > 0 Then MyBase.SetChangeDateNow()
            '
            ' Запись в историю работы
            '
            P.Work.WriteHistory(WorkEvent.GoodFind, String.Format("Найдено {0} из {1}", iTmp, P.Work.GoodTable.Rows.Count))

            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            ListGridControl.RefreshDataSource()
        End Try
    End Sub

    ' Выйти из режима редактирования списка объектов экспертизы
    Private Sub EditorBarCheckItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditorBarCheckItem.ItemClick
        P.GoodAsTree = True
        Dim goodId As Integer = C2.EMPTY_ID
        If ListGridView.FocusedRowHandle > 0 Then goodId = CInt(ListGridView.GetFocusedDataRow("id"))
        P.ContentOpen(ContentEnum.GoodList, goodId)
    End Sub

    Private Sub ListGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ListGridView.CellValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ListGridView_RowCountChanged(sender As Object, e As EventArgs) Handles ListGridView.RowCountChanged
        GoodOpenBarButtonItem.Enabled = (ListGridView.RowCount > 0)
    End Sub

End Class
