Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Список вопросов"
''' </summary>
Friend Class QueryListChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ListGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ListGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RowNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AskGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AskLayoutControlItem As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GoodAddBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodDelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ListClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileBarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents FileUploadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileDownloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Private components As System.ComponentModel.IContainer
    Friend WithEvents QueryOpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem

    Private Sub InitializeComponent()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryListChildControl))
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
        Me.IsCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RowNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AskGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.AskLayoutControlItem = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.QueryOpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodAddBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.GoodDelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ListClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileBarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.FileUploadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileDownloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AskLayoutControlItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckGridColumn
        '
        Me.IsCheckGridColumn.Caption = "Ответ"
        Me.IsCheckGridColumn.FieldName = "isCheck"
        Me.IsCheckGridColumn.Name = "IsCheckGridColumn"
        Me.IsCheckGridColumn.OptionsColumn.AllowEdit = False
        Me.IsCheckGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckGridColumn.OptionsColumn.ShowInCustomizationForm = False
        Me.IsCheckGridColumn.Visible = True
        Me.IsCheckGridColumn.VisibleIndex = 2
        Me.IsCheckGridColumn.Width = 80
        '
        'RowNumGridColumn
        '
        Me.RowNumGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowNumGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowNumGridColumn.Caption = "№№"
        Me.RowNumGridColumn.FieldName = "rowNum"
        Me.RowNumGridColumn.Name = "RowNumGridColumn"
        Me.RowNumGridColumn.OptionsColumn.FixedWidth = True
        Me.RowNumGridColumn.Visible = True
        Me.RowNumGridColumn.VisibleIndex = 0
        Me.RowNumGridColumn.Width = 80
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
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'ListGridControl
        '
        Me.ListGridControl.Location = New System.Drawing.Point(12, 93)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.Size = New System.Drawing.Size(926, 545)
        Me.ListGridControl.TabIndex = 9
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ListGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Appearance.Row.Options.UseTextOptions = True
        Me.ListGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RowNumGridColumn, Me.AskGridColumn, Me.IsCheckGridColumn})
        Me.ListGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.Name = "Format0"
        GridFormatRule1.Rule = Nothing
        GridFormatRule2.Column = Me.IsCheckGridColumn
        GridFormatRule2.ColumnApplyTo = Me.RowNumGridColumn
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue1.Value1 = "0"
        GridFormatRule2.Rule = FormatConditionRuleValue1
        Me.ListGridView.FormatRules.Add(GridFormatRule1)
        Me.ListGridView.FormatRules.Add(GridFormatRule2)
        Me.ListGridView.GridControl = Me.ListGridControl
        Me.ListGridView.GroupRowHeight = 25
        Me.ListGridView.Name = "ListGridView"
        Me.ListGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ListGridView.OptionsCustomization.AllowFilter = False
        Me.ListGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ListGridView.OptionsDetail.EnableMasterViewMode = False
        Me.ListGridView.OptionsMenu.EnableColumnMenu = False
        Me.ListGridView.OptionsNavigation.AutoFocusNewRow = True
        Me.ListGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsView.ShowGroupPanel = False
        Me.ListGridView.RowHeight = 30
        '
        'AskGridColumn
        '
        Me.AskGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.AskGridColumn.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.AskGridColumn.Caption = "Вопрос"
        Me.AskGridColumn.FieldName = "ask"
        Me.AskGridColumn.Name = "AskGridColumn"
        Me.AskGridColumn.OptionsColumn.AllowEdit = False
        Me.AskGridColumn.Visible = True
        Me.AskGridColumn.VisibleIndex = 1
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.AskLayoutControlItem, Me.LayoutControlItem2})
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
        Me.CaptionSimpleLabelItem.CustomizationFormText = "Вопросы и ответы"
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 40)
        Me.CaptionSimpleLabelItem.Text = "Вопросы, поставленные на разрешение эксперта"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'AskLayoutControlItem
        '
        Me.AskLayoutControlItem.Control = Me.ListGridControl
        Me.AskLayoutControlItem.Location = New System.Drawing.Point(0, 81)
        Me.AskLayoutControlItem.Name = "AskLayoutControlItem"
        Me.AskLayoutControlItem.Size = New System.Drawing.Size(930, 549)
        Me.AskLayoutControlItem.Text = "Вопросы"
        Me.AskLayoutControlItem.TextSize = New System.Drawing.Size(0, 0)
        Me.AskLayoutControlItem.TextVisible = False
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.GoodAddBarButtonItem, Me.GoodDelBarButtonItem, Me.ListClearBarButtonItem, Me.FileBarSubItem, Me.FileUploadBarButtonItem, Me.FileDownloadBarButtonItem, Me.QueryOpenBarButtonItem})
        Me.BarManager1.MaxItemId = 7
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(73, 156)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.QueryOpenBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.GoodAddBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.GoodDelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ListClearBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FileBarSubItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'QueryOpenBarButtonItem
        '
        Me.QueryOpenBarButtonItem.Caption = "Объект"
        Me.QueryOpenBarButtonItem.Glyph = CType(resources.GetObject("QueryOpenBarButtonItem.Glyph"), System.Drawing.Image)
        Me.QueryOpenBarButtonItem.Id = 6
        Me.QueryOpenBarButtonItem.Name = "QueryOpenBarButtonItem"
        ToolTipTitleItem1.Text = "Объект"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к редактированию данных объекта"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.QueryOpenBarButtonItem.SuperTip = SuperToolTip1
        '
        'GoodAddBarButtonItem
        '
        Me.GoodAddBarButtonItem.Caption = "Добавить"
        Me.GoodAddBarButtonItem.Glyph = CType(resources.GetObject("GoodAddBarButtonItem.Glyph"), System.Drawing.Image)
        Me.GoodAddBarButtonItem.Id = 0
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
        Me.GoodDelBarButtonItem.Id = 1
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
        Me.ListClearBarButtonItem.Id = 2
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
        Me.FileBarSubItem.Id = 3
        Me.FileBarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FileUploadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FileDownloadBarButtonItem)})
        Me.FileBarSubItem.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.FileBarSubItem.Name = "FileBarSubItem"
        '
        'FileUploadBarButtonItem
        '
        Me.FileUploadBarButtonItem.Caption = "Выгрузить"
        Me.FileUploadBarButtonItem.Description = "Выгрузить объекты экспертизы в файл с загрузочной таблицей"
        Me.FileUploadBarButtonItem.Id = 4
        Me.FileUploadBarButtonItem.LargeGlyph = CType(resources.GetObject("FileUploadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FileUploadBarButtonItem.Name = "FileUploadBarButtonItem"
        '
        'FileDownloadBarButtonItem
        '
        Me.FileDownloadBarButtonItem.Caption = "Загрузить"
        Me.FileDownloadBarButtonItem.Description = "Загрузить объекты экспертизы из файла с загрузочной таблицей"
        Me.FileDownloadBarButtonItem.Glyph = CType(resources.GetObject("FileDownloadBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FileDownloadBarButtonItem.Id = 5
        Me.FileDownloadBarButtonItem.Name = "FileDownloadBarButtonItem"
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
        'QueryListChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "QueryListChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AskLayoutControlItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CaptionSimpleLabelItem.Text = "Вопросы, поставленные на разрешение эксперта"
        '
        ' Перемещение фокуса к активному объекту
        '
        Dim iTmp = 0
        ListGridView.MoveFirst()
        While ListGridView.IsValidRowHandle(iTmp)
            If CInt(ListGridView.GetDataRow(iTmp)("id")) = MyClass.ObjectId Then
                ListGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not (P.PlaneEditableForExpert OrElse P.WorkEditableForExpert)    ' Работа не доступна эксперту для редактирования
        GoodAddBarButtonItem.Enabled = Not bLock
        GoodDelBarButtonItem.Enabled = Not bLock
        ListClearBarButtonItem.Enabled = Not bLock
        FileDownloadBarButtonItem.Enabled = Not bLock
        ListGridView.OptionsBehavior.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Перечень вопросов
        '
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        P.Work.QueryTable.AcceptChanges()
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property ObjectId As Integer = C2.EMPTY_ID


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.QueryList
        ListGridControl.DataSource = P.Work.QueryTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        ListGridControl.Focus()
    End Sub


    Private Sub ListGridView_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles ListGridView.CustomDrawCell
        Dim sTmp As String = Nothing
        If Not (e.CellValue Is Nothing OrElse IsDBNull(e.CellValue)) Then sTmp = e.CellValue.ToString
        If Not String.IsNullOrEmpty(sTmp) Then Exit Sub
        Select Case e.Column.FieldName
            Case "rowNum", "ask"
                e.DisplayText = "[обязательное поле]"
                e.Appearance.ForeColor = Drawing.SystemColors.InactiveCaptionText
        End Select
    End Sub

    Private Sub ListGridView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ListGridView.CellValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    ' Перейти к редактированию данных объекта
    Private Sub QueryOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles QueryOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        P.ContentOpen(ContentEnum.QueryData, CInt(ListGridView.GetFocusedDataRow("id")))
    End Sub

    Private Sub ListGridView_DoubleClick(sender As Object, e As EventArgs) Handles ListGridView.DoubleClick
        QueryOpenBarButtonItem.PerformClick()
    End Sub

    ' Добавить новый объект
    Private Sub GoodAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodAddBarButtonItem.ItemClick
      '
        ' Добавление нового объекта в таблицу вопросов
        '
        Dim Row As DataRow = P.Work.QueryTable.AddNew
        '
        ' Переход к регистрационным данным нового объекта
        '
        P.ContentOpen(ContentEnum.QueryData, CInt(Row("id")))
    End Sub

    ' Удалить объект
    Private Sub GoodDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodDelBarButtonItem.ItemClick
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Удалить объект № {0}?", C2.ToInt(ListGridView.GetFocusedDataRow("rowNum")))) <> DialogResult.Yes Then Exit Sub
        ListGridView.GetFocusedDataRow.Delete()
        ListGridView.RefreshData()
        ListGridControl.Focus()
    End Sub

    ' Удалить все объекты
    Private Sub ListClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListClearBarButtonItem.ItemClick
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить все объекты?") <> DialogResult.Yes Then Exit Sub
        P.Work.QueryTable.Rows.Clear()
        ListGridView.RefreshData()
        ListGridControl.Focus()
    End Sub

    ' Выгрузить объекты экспертизы в файл с загрузочной таблицей
    Private Sub FileUploadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileUploadBarButtonItem.ItemClick
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Сохранение данных в файл"
            Dlg.FileName = String.Format("Работа № {0} (Объекты + документы)", CInt(P.Work.Id))
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
            P.Work.QueryFromRtf(filePath)
            DataRead()
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

End Class
