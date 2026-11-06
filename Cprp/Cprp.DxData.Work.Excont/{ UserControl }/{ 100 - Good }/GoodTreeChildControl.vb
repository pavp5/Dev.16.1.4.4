Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Список продукции в виде дерева"
''' </summary>
Friend Class GoodTreeChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents EditorBarButtonItem As DevExpress.XtraBars.BarButtonItem
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
    Friend WithEvents GoodTreeList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents RowNumTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents NameConTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsCheckDataTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsCheckEmbargoTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsCheckControlTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsCheckStudyTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsCheckRiskTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents StudySummaryIdTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IsUnrealTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents CommonUsedMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents CommonAreaMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CommonLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents TreeLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodTreeChildControl))
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
        Dim TreeListFormatRule1 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule2 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim TreeListFormatRule3 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.StudySummaryIdTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsCheckStudyTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsUnrealTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
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
        Me.EditorBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GoodTreeList = New DevExpress.XtraTreeList.TreeList()
        Me.RowNumTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.NameConTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsCheckDataTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsCheckEmbargoTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsCheckControlTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.IsCheckRiskTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.CommonUsedMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.CommonAreaMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CommonLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.TreeLayoutControlItem = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GoodTreeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommonUsedMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommonAreaMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommonLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeLayoutControlItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StudySummaryIdTreeListColumn
        '
        Me.StudySummaryIdTreeListColumn.Caption = "studyIndex"
        Me.StudySummaryIdTreeListColumn.FieldName = "studySummaryId"
        Me.StudySummaryIdTreeListColumn.Name = "StudySummaryIdTreeListColumn"
        '
        'IsCheckStudyTreeListColumn
        '
        Me.IsCheckStudyTreeListColumn.Caption = "Исследование"
        Me.IsCheckStudyTreeListColumn.FieldName = "isCheckStudy"
        Me.IsCheckStudyTreeListColumn.Name = "IsCheckStudyTreeListColumn"
        Me.IsCheckStudyTreeListColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckStudyTreeListColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckStudyTreeListColumn.ToolTip = "Исследование по контрольным спискам"
        Me.IsCheckStudyTreeListColumn.Visible = True
        Me.IsCheckStudyTreeListColumn.VisibleIndex = 5
        Me.IsCheckStudyTreeListColumn.Width = 80
        '
        'IsUnrealTreeListColumn
        '
        Me.IsUnrealTreeListColumn.Caption = "isUnreal"
        Me.IsUnrealTreeListColumn.FieldName = "isUnreal"
        Me.IsUnrealTreeListColumn.Name = "IsUnrealTreeListColumn"
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.GoodOpenBarButtonItem, Me.GoodAddBarButtonItem, Me.GoodDelBarButtonItem, Me.ListClearBarButtonItem, Me.FileBarSubItem, Me.GoodBarSubItem, Me.FileUploadBarButtonItem, Me.FileDownloadBarButtonItem, Me.GoodUploadBarButtonItem, Me.GoodDownloadBarButtonItem, Me.FindBarButtonItem, Me.EditorBarButtonItem})
        Me.BarManager1.MaxItemId = 22
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(82, 171)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodOpenBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodAddBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.GoodDelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ListClearBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FileBarSubItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodBarSubItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditorBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
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
        'EditorBarButtonItem
        '
        Me.EditorBarButtonItem.Caption = "Редактор"
        Me.EditorBarButtonItem.Glyph = CType(resources.GetObject("EditorBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditorBarButtonItem.Id = 21
        Me.EditorBarButtonItem.Name = "EditorBarButtonItem"
        ToolTipTitleItem6.Text = "Редактор"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Перейти в режим редактирования списка"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.EditorBarButtonItem.SuperTip = SuperToolTip6
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(13, 53)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(924, 47)
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
        Me.LayoutControl1.Controls.Add(Me.GoodTreeList)
        Me.LayoutControl1.Controls.Add(Me.CommonUsedMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.CommonAreaMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
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
        'GoodTreeList
        '
        Me.GoodTreeList.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GoodTreeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GoodTreeList.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GoodTreeList.Appearance.Row.Options.UseFont = True
        Me.GoodTreeList.Appearance.Row.Options.UseTextOptions = True
        Me.GoodTreeList.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GoodTreeList.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.RowNumTreeListColumn, Me.NameConTreeListColumn, Me.IsCheckDataTreeListColumn, Me.IsCheckEmbargoTreeListColumn, Me.IsCheckControlTreeListColumn, Me.IsCheckStudyTreeListColumn, Me.IsCheckRiskTreeListColumn, Me.StudySummaryIdTreeListColumn, Me.IsUnrealTreeListColumn})
        Me.GoodTreeList.Cursor = System.Windows.Forms.Cursors.Default
        TreeListFormatRule1.Column = Me.StudySummaryIdTreeListColumn
        TreeListFormatRule1.ColumnApplyTo = Me.IsCheckStudyTreeListColumn
        TreeListFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.SystemColors.Info
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = CType(1, Short)
        TreeListFormatRule1.Rule = FormatConditionRuleValue1
        TreeListFormatRule2.Column = Me.StudySummaryIdTreeListColumn
        TreeListFormatRule2.ColumnApplyTo = Me.IsCheckStudyTreeListColumn
        TreeListFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Red
        FormatConditionRuleValue2.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = CType(1, Short)
        TreeListFormatRule2.Rule = FormatConditionRuleValue2
        TreeListFormatRule3.ApplyToRow = True
        TreeListFormatRule3.Column = Me.IsUnrealTreeListColumn
        TreeListFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue3.Appearance.Options.UseFont = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = True
        TreeListFormatRule3.Rule = FormatConditionRuleValue3
        Me.GoodTreeList.FormatRules.Add(TreeListFormatRule1)
        Me.GoodTreeList.FormatRules.Add(TreeListFormatRule2)
        Me.GoodTreeList.FormatRules.Add(TreeListFormatRule3)
        Me.GoodTreeList.KeyFieldName = "id"
        Me.GoodTreeList.Location = New System.Drawing.Point(13, 106)
        Me.GoodTreeList.Name = "GoodTreeList"
        Me.GoodTreeList.OptionsBehavior.AllowExpandOnDblClick = False
        Me.GoodTreeList.OptionsCustomization.AllowColumnMoving = False
        Me.GoodTreeList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GoodTreeList.OptionsMenu.EnableColumnMenu = False
        Me.GoodTreeList.OptionsNavigation.AutoFocusNewNode = True
        Me.GoodTreeList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GoodTreeList.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.GoodTreeList.OptionsView.ShowRoot = False
        Me.GoodTreeList.ParentFieldName = "parentId"
        Me.GoodTreeList.RowHeight = 30
        Me.GoodTreeList.Size = New System.Drawing.Size(924, 491)
        Me.GoodTreeList.TabIndex = 0
        '
        'RowNumTreeListColumn
        '
        Me.RowNumTreeListColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowNumTreeListColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowNumTreeListColumn.Caption = "№№"
        Me.RowNumTreeListColumn.FieldName = "rowNum"
        Me.RowNumTreeListColumn.Name = "RowNumTreeListColumn"
        Me.RowNumTreeListColumn.OptionsColumn.FixedWidth = True
        Me.RowNumTreeListColumn.Visible = True
        Me.RowNumTreeListColumn.VisibleIndex = 0
        Me.RowNumTreeListColumn.Width = 80
        '
        'NameConTreeListColumn
        '
        Me.NameConTreeListColumn.Caption = "Коммерческое наименование"
        Me.NameConTreeListColumn.FieldName = "nameCon"
        Me.NameConTreeListColumn.Name = "NameConTreeListColumn"
        Me.NameConTreeListColumn.OptionsColumn.AllowEdit = False
        Me.NameConTreeListColumn.Visible = True
        Me.NameConTreeListColumn.VisibleIndex = 1
        '
        'IsCheckDataTreeListColumn
        '
        Me.IsCheckDataTreeListColumn.Caption = "Данные"
        Me.IsCheckDataTreeListColumn.FieldName = "isCheckData"
        Me.IsCheckDataTreeListColumn.Name = "IsCheckDataTreeListColumn"
        Me.IsCheckDataTreeListColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckDataTreeListColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckDataTreeListColumn.ToolTip = "Регистрационные данные"
        Me.IsCheckDataTreeListColumn.Visible = True
        Me.IsCheckDataTreeListColumn.VisibleIndex = 2
        Me.IsCheckDataTreeListColumn.Width = 80
        '
        'IsCheckEmbargoTreeListColumn
        '
        Me.IsCheckEmbargoTreeListColumn.Caption = "Запреты"
        Me.IsCheckEmbargoTreeListColumn.FieldName = "isCheckEmbargo"
        Me.IsCheckEmbargoTreeListColumn.Name = "IsCheckEmbargoTreeListColumn"
        Me.IsCheckEmbargoTreeListColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckEmbargoTreeListColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckEmbargoTreeListColumn.ToolTip = "Запреты и ограничения"
        Me.IsCheckEmbargoTreeListColumn.Visible = True
        Me.IsCheckEmbargoTreeListColumn.VisibleIndex = 3
        Me.IsCheckEmbargoTreeListColumn.Width = 80
        '
        'IsCheckControlTreeListColumn
        '
        Me.IsCheckControlTreeListColumn.Caption = "На контроле"
        Me.IsCheckControlTreeListColumn.FieldName = "isCheckControl"
        Me.IsCheckControlTreeListColumn.Name = "IsCheckControlTreeListColumn"
        Me.IsCheckControlTreeListColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckControlTreeListColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckControlTreeListColumn.ToolTip = "Продукция на контроле"
        Me.IsCheckControlTreeListColumn.Visible = True
        Me.IsCheckControlTreeListColumn.VisibleIndex = 4
        Me.IsCheckControlTreeListColumn.Width = 80
        '
        'IsCheckRiskTreeListColumn
        '
        Me.IsCheckRiskTreeListColumn.Caption = "Риски"
        Me.IsCheckRiskTreeListColumn.FieldName = "isCheckRisk"
        Me.IsCheckRiskTreeListColumn.Name = "IsCheckRiskTreeListColumn"
        Me.IsCheckRiskTreeListColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckRiskTreeListColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckRiskTreeListColumn.ToolTip = "Риски"
        Me.IsCheckRiskTreeListColumn.Visible = True
        Me.IsCheckRiskTreeListColumn.VisibleIndex = 6
        Me.IsCheckRiskTreeListColumn.Width = 80
        '
        'CommonUsedMemoEdit
        '
        Me.CommonUsedMemoEdit.Location = New System.Drawing.Point(329, 667)
        Me.CommonUsedMemoEdit.MenuManager = Me.BarManager1
        Me.CommonUsedMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.CommonUsedMemoEdit.Name = "CommonUsedMemoEdit"
        Me.CommonUsedMemoEdit.Size = New System.Drawing.Size(584, 45)
        Me.CommonUsedMemoEdit.StyleController = Me.LayoutControl1
        Me.CommonUsedMemoEdit.TabIndex = 1
        '
        'CommonAreaMemoEdit
        '
        Me.CommonAreaMemoEdit.Location = New System.Drawing.Point(329, 618)
        Me.CommonAreaMemoEdit.MenuManager = Me.BarManager1
        Me.CommonAreaMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.CommonAreaMemoEdit.Name = "CommonAreaMemoEdit"
        Me.CommonAreaMemoEdit.Size = New System.Drawing.Size(584, 45)
        Me.CommonAreaMemoEdit.StyleController = Me.LayoutControl1
        Me.CommonAreaMemoEdit.TabIndex = 1
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.CommonLayoutControlGroup, Me.SplitterItem1, Me.TreeLayoutControlItem})
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
        Me.CaptionSimpleLabelItem.CustomizationFormText = "Продукция"
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 40)
        Me.CaptionSimpleLabelItem.Text = "Продукция"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(930, 53)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'CommonLayoutControlGroup
        '
        Me.CommonLayoutControlGroup.ExpandButtonVisible = True
        Me.CommonLayoutControlGroup.Expanded = False
        Me.CommonLayoutControlGroup.ExpandOnDoubleClick = True
        Me.CommonLayoutControlGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.CommonLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.CommonLayoutControlGroup.Location = New System.Drawing.Point(0, 605)
        Me.CommonLayoutControlGroup.Name = "CommonLayoutControlGroup"
        Me.CommonLayoutControlGroup.Size = New System.Drawing.Size(930, 35)
        Me.CommonLayoutControlGroup.Text = "Общие сведения об объектах экспертизы"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.CommonAreaMemoEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(906, 49)
        Me.LayoutControlItem4.Text = "Область применения объектов экспертизы"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(313, 18)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CommonUsedMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 49)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(906, 49)
        Me.LayoutControlItem5.Text = "Назначение объектов экспертизы"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(313, 18)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 590)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(930, 15)
        '
        'TreeLayoutControlItem
        '
        Me.TreeLayoutControlItem.Control = Me.GoodTreeList
        Me.TreeLayoutControlItem.Location = New System.Drawing.Point(0, 93)
        Me.TreeLayoutControlItem.Name = "TreeLayoutControlItem"
        Me.TreeLayoutControlItem.Size = New System.Drawing.Size(930, 497)
        Me.TreeLayoutControlItem.Text = "Дерево"
        Me.TreeLayoutControlItem.TextSize = New System.Drawing.Size(0, 0)
        Me.TreeLayoutControlItem.TextVisible = False
        '
        'GoodTreeChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodTreeChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GoodTreeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommonUsedMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommonAreaMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommonLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeLayoutControlItem, System.ComponentModel.ISupportInitialize).EndInit()
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
            CommonAreaMemoEdit.EditValue = .Item("goodArea")
            CommonUsedMemoEdit.EditValue = .Item("goodUsed")
        End With
        '
        ' Перемещение фокуса к активному объекту
        '
        Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = GoodTreeList.FindNodeByKeyID(MyClass.GoodId)
        If Not Node Is Nothing Then GoodTreeList.FocusedNode = Node
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
        GoodTreeList.OptionsBehavior.ReadOnly = bLock
        CommonAreaMemoEdit.Properties.ReadOnly = bLock
        CommonUsedMemoEdit.Properties.ReadOnly = bLock
        GoodOpenBarButtonItem.Enabled = (P.Work.GoodTable.Rows.Count > 0)
        MyBase.IsDataLoaded = True
        GoodTreeList.ExpandAll()
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Список продукции
        '
        GoodTreeList.CloseEditor()
        P.Work.GoodTable.AcceptChanges()
        '
        ' Данные объектов
        '
        With P.Work.ARow
            .Item("goodArea") = C2.DbText(CommonAreaMemoEdit.EditValue)
            .Item("goodUsed") = C2.DbText(CommonUsedMemoEdit.EditValue)
        End With
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
        MyBase.Content = ContentEnum.GoodList
        GoodTreeList.DataSource = P.Work.GoodTable
        RowNumTreeListColumn.SortIndex = 0
        RowNumTreeListColumn.SortOrder = Windows.Forms.SortOrder.Ascending
        CommonLayoutControlGroup.Expanded = True
    End Sub


    Private Sub GoodTreeList_BeforeCollapse(sender As Object, e As DevExpress.XtraTreeList.BeforeCollapseEventArgs) Handles GoodTreeList.BeforeCollapse
        e.CanCollapse = False
    End Sub

    Private Sub GoodTreeList_CustomDrawNodeCell(sender As Object, e As DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs) Handles GoodTreeList.CustomDrawNodeCell
        Dim sTmp As String = Nothing
        If Not (e.CellValue Is Nothing OrElse IsDBNull(e.CellValue)) Then sTmp = e.CellValue.ToString
        If Not String.IsNullOrEmpty(sTmp) Then Exit Sub
        Select Case e.Column.FieldName
            Case "rowNum", "nameCon"
                e.CellText = "[обязательное поле]"
                e.Appearance.ForeColor = Drawing.SystemColors.InactiveCaptionText
        End Select
    End Sub

    ' Перейти к регистрационным данным объекта
    Private Sub GoodOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodOpenBarButtonItem.ItemClick
        If GoodTreeList.FocusedNode Is Nothing Then Exit Sub
        P.ContentOpen(ContentEnum.GoodData, GoodTreeList.FocusedNode.GetValue("id"))
    End Sub

    Private Sub GoodTreeList_DoubleClick(sender As Object, e As EventArgs) Handles GoodTreeList.DoubleClick
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
        GoodTreeList.CloseEditor()
        If GoodTreeList.FocusedNode Is Nothing Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Удалить объект № {0}?", C2.ToInt(GoodTreeList.FocusedNode.GetValue("rowNum")))) <> DialogResult.Yes Then Exit Sub
        Dim goodId As Integer = CInt(GoodTreeList.FocusedNode.GetValue("id"))
        P.Work.GoodEmbargoTable.DeleteGood(goodId)
        P.Work.GoodControlTable.DeleteGood(goodId)
        P.Work.GoodLawTable.DeleteGood(goodId)
        P.Work.GoodRiskTable.DeleteGood(goodId)
        GoodTreeList.LockReloadNodes()
        Using V As New DataView(P.Work.GoodTable)
            V.RowFilter = String.Format("parentId = {0}", goodId)
            While V.Count > 0
                V(0)("parentId") = DBNull.Value
            End While
        End Using
        GoodTreeList.UnlockReloadNodes()
        GoodTreeList.DeleteNode(GoodTreeList.FocusedNode)
        GoodTreeList.Focus()
        GoodOpenBarButtonItem.Enabled = (GoodTreeList.Nodes.Count > 0)
        MyBase.SetChangeDateNow()
    End Sub

    ' Удалить все объекты
    Private Sub ListClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListClearBarButtonItem.ItemClick
        GoodTreeList.CloseEditor()
        If GoodTreeList.FocusedNode Is Nothing Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить все объекты?") <> DialogResult.Yes Then Exit Sub
        GoodTreeList.LockReloadNodes()
        P.Work.GoodEmbargoTable.Rows.Clear()
        P.Work.GoodControlTable.Rows.Clear()
        P.Work.GoodLawTable.Rows.Clear()
        P.Work.GoodRiskTable.Rows.Clear()
        P.Work.GoodTable.Rows.Clear()
        GoodTreeList.UnlockReloadNodes()
        GoodTreeList.Focus()
        GoodOpenBarButtonItem.Enabled = (GoodTreeList.Nodes.Count > 0)
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
            GoodTreeList.LockReloadNodes()
            P.Work.GoodFromRtf(filePath)
            GoodTreeList.UnlockReloadNodes()
            MyBase.SetChangeDateNow()
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            GoodOpenBarButtonItem.Enabled = (GoodTreeList.Nodes.Count > 0)
        End Try
    End Sub

    ' Выгрузить данные объекта экспертизы в другие объекты экспертизы
    Private Sub GoodUploadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodUploadBarButtonItem.ItemClick
        If P.Work.GoodTable.Rows.Count < 2 Then Exit Sub
        If GoodTreeList.FocusedNode Is Nothing Then Exit Sub
        GoodTreeList.LockReloadNodes()
        With New GoodExportForm(P, CType(GoodTreeList.GetDataRecordByNode(GoodTreeList.FocusedNode), DataRowView).Row)
            If .ShowDialog() = DialogResult.OK Then
                MyBase.SetChangeDateNow()
                Cprp.DxCommon.Messages.ShowInformation("Данные выгружены в указанные объекты.", "Выгрузка данных")
            End If
        End With
        GoodTreeList.UnlockReloadNodes()
    End Sub

    ' Загрузить в объект экспертизы данные из другого объекта экспертизы
    Private Sub GoodDownloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodDownloadBarButtonItem.ItemClick
        If P.Work.GoodTable.Rows.Count < 2 Then Exit Sub
        If GoodTreeList.FocusedNode Is Nothing Then Exit Sub
        GoodTreeList.LockReloadNodes()
        With New GoodImportForm(P, CType(GoodTreeList.GetDataRecordByNode(GoodTreeList.FocusedNode), DataRowView).Row)
            If .ShowDialog() = DialogResult.OK Then
                MyBase.SetChangeDateNow()
                Cprp.DxCommon.Messages.ShowInformation("Данные загружены из указанного объекта.", "Загрузка данных")
            End If
        End With
        GoodTreeList.UnlockReloadNodes()
    End Sub

    ' Поиск в базе данных объектов экспертизы по их обозначениям
    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        If P.Work.GoodTable.Rows.Count = 0 Then Exit Sub
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        GoodTreeList.LockReloadNodes()
        Try
            With New GoodLoadForm
                If .ShowDialog <> DialogResult.OK Then
                    GoodTreeList.UnlockReloadNodes()
                    Exit Sub
                End If
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
            GoodTreeList.UnlockReloadNodes()
            If iTmp > 0 Then MyBase.SetChangeDateNow()
            '
            ' Запись в историю работы
            '
            P.Work.WriteHistory(WorkEvent.GoodFind, String.Format("Найдено {0} из {1}", iTmp, P.Work.GoodTable.Rows.Count))

            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            GoodTreeList.RefreshDataSource()
        End Try
    End Sub

    ' Перейти в режим редактирования списка объектов экспертизы
    Private Sub EditorBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditorBarButtonItem.ItemClick
        P.GoodAsTree = False
        Dim goodId As Integer = C2.EMPTY_ID
        If Not GoodTreeList.FocusedNode Is Nothing Then goodId = CInt(GoodTreeList.FocusedNode.GetValue("id"))
        P.ContentOpen(ContentEnum.GoodList, goodId)
    End Sub

    Private Sub CommonAreaMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CommonAreaMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub CommonUsedMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CommonUsedMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
