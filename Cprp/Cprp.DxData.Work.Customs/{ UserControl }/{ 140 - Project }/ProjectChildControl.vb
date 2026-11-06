Imports C2 = Cprp.DxData.Common
Imports DevExpress.XtraRichEdit.API.Native
''' <summary>
''' Элемент управления "Итоговые документы > Проект заключения"
''' </summary>
Friend Class ProjectChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents P6BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents P5BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents P4BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents P3BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents P2BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents EditColumnCollapseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditColumnExpandBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditTableBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditFontBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditParagraphBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditRedoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditUndoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DocSaveBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DocPrintBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents CommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents R As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CommentLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectChildControl))
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
        Dim SuperToolTip8 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem8 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem8 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip9 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem9 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem9 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.DocPrintBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DocSaveBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditUndoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditRedoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditParagraphBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditFontBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditTableBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditColumnExpandBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditColumnCollapseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.P2BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.P3BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.P4BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.P5BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.P6BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.R = New DevExpress.XtraRichEdit.RichEditControl()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CommentLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.DocPrintBarButtonItem, Me.DocSaveBarButtonItem, Me.EditUndoBarButtonItem, Me.EditRedoBarButtonItem, Me.EditParagraphBarButtonItem, Me.EditFontBarButtonItem, Me.EditTableBarButtonItem, Me.EditColumnExpandBarButtonItem, Me.EditColumnCollapseBarButtonItem, Me.P2BarCheckItem, Me.P3BarCheckItem, Me.P4BarCheckItem, Me.P5BarCheckItem, Me.P6BarCheckItem})
        Me.BarManager1.MaxItemId = 27
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DocPrintBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DocSaveBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditUndoBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.EditRedoBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditParagraphBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditFontBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditTableBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.EditColumnExpandBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditColumnCollapseBarButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'DocPrintBarButtonItem
        '
        Me.DocPrintBarButtonItem.Caption = "Печать"
        Me.DocPrintBarButtonItem.Glyph = CType(resources.GetObject("DocPrintBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocPrintBarButtonItem.Id = 0
        Me.DocPrintBarButtonItem.Name = "DocPrintBarButtonItem"
        ToolTipTitleItem1.Text = "Печать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Печать документа"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.DocPrintBarButtonItem.SuperTip = SuperToolTip1
        '
        'DocSaveBarButtonItem
        '
        Me.DocSaveBarButtonItem.Caption = "Сохранить"
        Me.DocSaveBarButtonItem.Glyph = CType(resources.GetObject("DocSaveBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DocSaveBarButtonItem.Id = 1
        Me.DocSaveBarButtonItem.Name = "DocSaveBarButtonItem"
        ToolTipTitleItem2.Text = "Сохранить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Сохранить документ в файл"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.DocSaveBarButtonItem.SuperTip = SuperToolTip2
        '
        'EditUndoBarButtonItem
        '
        Me.EditUndoBarButtonItem.Caption = "Отменить"
        Me.EditUndoBarButtonItem.Glyph = CType(resources.GetObject("EditUndoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditUndoBarButtonItem.Id = 2
        Me.EditUndoBarButtonItem.Name = "EditUndoBarButtonItem"
        ToolTipTitleItem3.Text = "Отменить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Отменить последнее действие"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.EditUndoBarButtonItem.SuperTip = SuperToolTip3
        '
        'EditRedoBarButtonItem
        '
        Me.EditRedoBarButtonItem.Caption = "Вернуть"
        Me.EditRedoBarButtonItem.Glyph = CType(resources.GetObject("EditRedoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditRedoBarButtonItem.Id = 3
        Me.EditRedoBarButtonItem.Name = "EditRedoBarButtonItem"
        ToolTipTitleItem4.Text = "Вернуть"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Вернуть последнее действие"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.EditRedoBarButtonItem.SuperTip = SuperToolTip4
        '
        'EditParagraphBarButtonItem
        '
        Me.EditParagraphBarButtonItem.Caption = "Абзац"
        Me.EditParagraphBarButtonItem.Glyph = CType(resources.GetObject("EditParagraphBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditParagraphBarButtonItem.Id = 4
        Me.EditParagraphBarButtonItem.Name = "EditParagraphBarButtonItem"
        ToolTipTitleItem5.Text = "Абзац"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Изменить выделенный абзац"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.EditParagraphBarButtonItem.SuperTip = SuperToolTip5
        '
        'EditFontBarButtonItem
        '
        Me.EditFontBarButtonItem.Caption = "Шрифт"
        Me.EditFontBarButtonItem.Glyph = CType(resources.GetObject("EditFontBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditFontBarButtonItem.Id = 5
        Me.EditFontBarButtonItem.Name = "EditFontBarButtonItem"
        ToolTipTitleItem6.Text = "Шрифт"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Изменить выделенный шрифт"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.EditFontBarButtonItem.SuperTip = SuperToolTip6
        '
        'EditTableBarButtonItem
        '
        Me.EditTableBarButtonItem.Caption = "Разделить"
        Me.EditTableBarButtonItem.Glyph = CType(resources.GetObject("EditTableBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditTableBarButtonItem.Id = 6
        Me.EditTableBarButtonItem.Name = "EditTableBarButtonItem"
        ToolTipTitleItem7.Text = "Разделить"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Разделить таблицу"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.EditTableBarButtonItem.SuperTip = SuperToolTip7
        '
        'EditColumnExpandBarButtonItem
        '
        Me.EditColumnExpandBarButtonItem.Caption = "Увеличить"
        Me.EditColumnExpandBarButtonItem.Glyph = CType(resources.GetObject("EditColumnExpandBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditColumnExpandBarButtonItem.Id = 7
        Me.EditColumnExpandBarButtonItem.Name = "EditColumnExpandBarButtonItem"
        ToolTipTitleItem8.Text = "Увеличить"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Увеличить ширину столбца"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.EditColumnExpandBarButtonItem.SuperTip = SuperToolTip8
        '
        'EditColumnCollapseBarButtonItem
        '
        Me.EditColumnCollapseBarButtonItem.Caption = "Уменьшить"
        Me.EditColumnCollapseBarButtonItem.Glyph = CType(resources.GetObject("EditColumnCollapseBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditColumnCollapseBarButtonItem.Id = 8
        Me.EditColumnCollapseBarButtonItem.Name = "EditColumnCollapseBarButtonItem"
        ToolTipTitleItem9.Text = "Уменьшить"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Уменьшить ширину столбца"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.EditColumnCollapseBarButtonItem.SuperTip = SuperToolTip9
        '
        'Bar2
        '
        Me.Bar2.BarName = "Пояснения"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(89, 716)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.P2BarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.P3BarCheckItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.P4BarCheckItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.P5BarCheckItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.P6BarCheckItem, True)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar2.Text = "Пояснения"
        '
        'P2BarCheckItem
        '
        Me.P2BarCheckItem.Caption = "П.2"
        Me.P2BarCheckItem.GroupIndex = 1
        Me.P2BarCheckItem.Id = 9
        Me.P2BarCheckItem.Name = "P2BarCheckItem"
        '
        'P3BarCheckItem
        '
        Me.P3BarCheckItem.Caption = "П.3"
        Me.P3BarCheckItem.GroupIndex = 1
        Me.P3BarCheckItem.Id = 14
        Me.P3BarCheckItem.Name = "P3BarCheckItem"
        '
        'P4BarCheckItem
        '
        Me.P4BarCheckItem.Caption = "П.4"
        Me.P4BarCheckItem.GroupIndex = 1
        Me.P4BarCheckItem.Id = 15
        Me.P4BarCheckItem.Name = "P4BarCheckItem"
        '
        'P5BarCheckItem
        '
        Me.P5BarCheckItem.Caption = "П.5"
        Me.P5BarCheckItem.GroupIndex = 1
        Me.P5BarCheckItem.Id = 18
        Me.P5BarCheckItem.Name = "P5BarCheckItem"
        '
        'P6BarCheckItem
        '
        Me.P6BarCheckItem.Caption = "П.6"
        Me.P6BarCheckItem.GroupIndex = 1
        Me.P6BarCheckItem.Id = 24
        Me.P6BarCheckItem.Name = "P6BarCheckItem"
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(2, 587)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(922, 24)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
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
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.CommentMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.R)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 37)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(447, 219, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 613)
        Me.LayoutControl1.TabIndex = 30
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CommentMemoEdit
        '
        Me.CommentMemoEdit.Location = New System.Drawing.Point(2, 615)
        Me.CommentMemoEdit.MenuManager = Me.BarManager1
        Me.CommentMemoEdit.MinimumSize = New System.Drawing.Size(0, 90)
        Me.CommentMemoEdit.Name = "CommentMemoEdit"
        Me.CommentMemoEdit.Properties.NullValuePrompt = "При необходимости, введите пояснение к соответствующему пункту и заново создайте " & _
    "проект документа"
        Me.CommentMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.CommentMemoEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.CommentMemoEdit.Size = New System.Drawing.Size(922, 90)
        Me.CommentMemoEdit.StyleController = Me.LayoutControl1
        Me.CommentMemoEdit.TabIndex = 27
        '
        'R
        '
        Me.R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        Me.R.Location = New System.Drawing.Point(2, 2)
        Me.R.MenuManager = Me.BarManager1
        Me.R.Name = "R"
        Me.R.ReadOnly = True
        Me.R.Size = New System.Drawing.Size(946, 569)
        Me.R.TabIndex = 25
        Me.R.Views.PrintLayoutView.MaxHorizontalPageCount = 1
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
        Me.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[False]
        Me.RootLayoutControlGroup.GroupBordersVisible = False
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.CommentLayoutControlGroup, Me.SplitterItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 613)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.R
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(950, 573)
        Me.LayoutControlItem1.Text = "Проект"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'CommentLayoutControlGroup
        '
        Me.CommentLayoutControlGroup.ExpandButtonVisible = True
        Me.CommentLayoutControlGroup.Expanded = False
        Me.CommentLayoutControlGroup.ExpandOnDoubleClick = True
        Me.CommentLayoutControlGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.CommentLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.CommentLayoutControlGroup.Location = New System.Drawing.Point(0, 585)
        Me.CommentLayoutControlGroup.Name = "CommentLayoutControlGroup"
        Me.CommentLayoutControlGroup.Size = New System.Drawing.Size(950, 28)
        Me.CommentLayoutControlGroup.Text = "Пояснения эксперта к пунктам документа"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(926, 28)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CommentMemoEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(926, 94)
        Me.LayoutControlItem3.Text = "Пояснение"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 573)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(950, 12)
        '
        'ProjectChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ProjectChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
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
        fldName = If(P.Project1Show, "doc1Data", "doc2Data")
        ' Проект заключения
        If IsDBNull(P.Work.ARow(fldName)) Then
            R.OpenXmlBytes = Nothing
            R.Text = "[нет данных]"
        Else
            R.OpenXmlBytes = P.Work.ARow(fldName)
        End If
        ' Выделенное пояснение эксперта
        CommentRow = Nothing
        CommentMemoEdit.Text = Nothing
        For Each Item As DevExpress.XtraBars.BarCheckItemLink In Bar2.ItemLinks
            If Not TypeOf Item.Item Is DevExpress.XtraBars.BarCheckItem Then Continue For
            With CType(Item.Item, DevExpress.XtraBars.BarCheckItem)
                If Not .Checked Then Continue For
                .PerformClick()
                Exit For
            End With
        Next
        '
        ' Доступность элементов на редактирование
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        EditUndoBarButtonItem.Enabled = Not bLock
        EditRedoBarButtonItem.Enabled = Not bLock
        EditParagraphBarButtonItem.Enabled = Not bLock
        EditFontBarButtonItem.Enabled = Not bLock
        EditTableBarButtonItem.Enabled = Not bLock
        EditColumnExpandBarButtonItem.Enabled = Not bLock
        EditColumnCollapseBarButtonItem.Enabled = Not bLock
        CommentMemoEdit.Properties.ReadOnly = bLock
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        If R.Text = "[нет данных]" Then Exit Sub
        '
        ' Данные объекта
        '
        P.Work.ARow(fldName) = R.OpenXmlBytes
        If Not CommentRow Is Nothing AndAlso CommentRow.Table Is P.Work.CommentTable Then
            CommentRow("comment") = C2.ToText(CommentMemoEdit.Text)
            CommentRow.AcceptChanges()
        End If
    End Sub

#End Region

    ''' <summary>
    ''' Номер активного проекта документа
    ''' </summary>
    Public ProjectId As Integer = 1

    ''' <summary>
    ''' Имя поля с проектом заключения
    ''' </summary>
    Private fldName As String = Nothing

    ''' <summary>
    ''' Строка таблицы пояснений эксперта
    ''' </summary>
    Private CommentRow As DataRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.Project
        If P.SpellChecker1.Dictionaries.Count > 0 Then R.SpellChecker = P.SpellChecker1
        CommentMemoEdit.Properties.NullValuePrompt = _
            "Для ввода пояснения в пункт документа выполните следующие действия:" & vbCrLf & _
            "1. Выберите (выделите) пункт" & vbCrLf & _
            "2. Введите текст пояснения" & vbCrLf & _
            "3. Создайте проект документа"
    End Sub

    ' Печать документа
    Private Sub DocPrintBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocPrintBarButtonItem.ItemClick
        R.ShowPrintDialog()
    End Sub

    ' Сохранить документ в файл
    Private Sub DocSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DocSaveBarButtonItem.ItemClick
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Сохранение данных в файл"
            Dlg.FileName = String.Format("Проект № {0}", If(P.Project1Show, 1, 2))
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        '
        ' Сохранение данных в файл
        '
        Try
            If filePath Like "*docx" Then
                R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
        '
        ' Открытие файла с внешней программой
        '
        If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?") = DialogResult.Yes Then
            Using P As New Process
                P.StartInfo.FileName = Trim(filePath)
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        End If
    End Sub

    ' Изменить выделенный абзац
    Private Sub EditParagraphBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditParagraphBarButtonItem.ItemClick
        R.ReadOnly = False
        Try
            R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ShowParagraphForm).Execute()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            R.ReadOnly = True
        End Try
    End Sub

    ' Изменить шрифт выделенного текста
    Private Sub EditFontBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditFontBarButtonItem.ItemClick
        R.ReadOnly = False
        Try
            R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ShowFontForm).Execute()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            R.ReadOnly = True
        End Try
    End Sub

    ' Разделить таблицу
    Private Sub EditTableBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditTableBarButtonItem.ItemClick
        Dim currentCell As TableCell = R.Document.Tables.GetTableCell(R.Document.CaretPosition)
        If currentCell Is Nothing Then Exit Sub
        If currentCell.Row.Index < 2 Then Exit Sub
        Dim charProp As CharacterProperties = Nothing
        Dim parProp As ParagraphProperties = Nothing
        R.ReadOnly = False
        R.Document.BeginUpdate()
        Try
            ' Вставка новой строки
            Dim Row As TableRow = currentCell.Table.Rows.InsertBefore(currentCell.Row.Index)
            ' Вставка данных и форматиривание ячеек новой строки
            For i As Integer = 0 To Row.Cells.Count - 1
                ' Вставка данных из первой строки
                R.Document.InsertText(Row.Cells(i).ContentRange.Start, R.Document.GetText(currentCell.Table.FirstRow.Cells(i).ContentRange))
                ' Форматирование текста
                charProp = R.Document.BeginUpdateCharacters(Row.Cells(i).ContentRange)
                charProp.FontName = "Calibri"
                charProp.FontSize = 9
                charProp.Italic = True
                R.Document.EndUpdateCharacters(charProp)
                ' Форматирование абзаца
                parProp = R.Document.BeginUpdateParagraphs(Row.Cells(i).ContentRange)
                parProp.Alignment = ParagraphAlignment.Center
                R.Document.EndUpdateParagraphs(parProp)
                ' Форматирование ячейки
                Row.Cells(i).VerticalAlignment = TableCellVerticalAlignment.Center
                Row.Cells(i).BackgroundColor = Row.Table.FirstRow.Cells(i).BackgroundColor
            Next
            ' Разделение таблицы
            R.Document.CaretPosition = Row.FirstCell.Range.Start
            R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.SplitTable).Execute()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Экспертиза")
        Finally
            R.Document.EndUpdate()
            R.ReadOnly = True
        End Try
    End Sub

    ' Отменить последнее действие
    Private Sub EditUndoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditUndoBarButtonItem.ItemClick
        R.ReadOnly = False
        Try
            R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.Undo).Execute()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Экспертиза")
        Finally
            R.ReadOnly = True
        End Try
    End Sub

    ' Вернуть последнее действие
    Private Sub EditRedoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditRedoBarButtonItem.ItemClick
        R.ReadOnly = False
        Try
            R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.Redo).Execute()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Экспертиза")
        Finally
            R.ReadOnly = True
        End Try
    End Sub

    ' Увеличить ширину столбца таблицы
    Private Sub EditColumnExpandBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditColumnExpandBarButtonItem.ItemClick
        If R.Document.Tables.GetTableCell(R.Document.CaretPosition) Is Nothing Then Exit Sub
        R.ReadOnly = False
        Try
            With R.Document.Tables.GetTableCell(R.Document.CaretPosition)
                .PreferredWidth += 0.1 * .PreferredWidth
            End With
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Экспертиза")
        Finally
            R.ReadOnly = True
        End Try
    End Sub

    ' Уменьшить ширину столбца таблицы
    Private Sub EditColumnCollapseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditColumnCollapseBarButtonItem.ItemClick
        If R.Document.Tables.GetTableCell(R.Document.CaretPosition) Is Nothing Then Exit Sub
        R.ReadOnly = False
        Try
            With R.Document.Tables.GetTableCell(R.Document.CaretPosition)
                .PreferredWidth -= 0.1 * .PreferredWidth
            End With
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Экспертиза")
        Finally
            R.ReadOnly = True
        End Try
    End Sub

#Region "Пояснения эксперта к пунктам документа"

    ' П.2
    Private Sub P2BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles P2BarCheckItem.ItemClick
        If Not CommentRow Is Nothing Then
            CommentRow("comment") = C2.ToText(CommentMemoEdit.EditValue)
            CommentRow.AcceptChanges()
        End If
        CommentRow = P.Work.CommentTable.Rows.Find(10)
        If Not CommentRow Is Nothing Then CommentMemoEdit.Text = C2.ToText(CommentRow("comment"))
    End Sub

    ' П.3
    Private Sub P3BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles P3BarCheckItem.ItemClick
        If Not CommentRow Is Nothing Then
            CommentRow("comment") = C2.ToText(CommentMemoEdit.EditValue)
            CommentRow.AcceptChanges()
        End If
        CommentRow = P.Work.CommentTable.Rows.Find(20)
        If Not CommentRow Is Nothing Then CommentMemoEdit.Text = C2.ToText(CommentRow("comment"))
    End Sub

    ' П.4
    Private Sub P4BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles P4BarCheckItem.ItemClick
        If Not CommentRow Is Nothing Then
            CommentRow("comment") = C2.ToText(CommentMemoEdit.EditValue)
            CommentRow.AcceptChanges()
        End If
        CommentRow = P.Work.CommentTable.Rows.Find(30)
        If Not CommentRow Is Nothing Then CommentMemoEdit.Text = C2.ToText(CommentRow("comment"))
    End Sub

    ' П.5
    Private Sub P5BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles P5BarCheckItem.ItemClick
        If Not CommentRow Is Nothing Then
            CommentRow("comment") = C2.ToText(CommentMemoEdit.EditValue)
            CommentRow.AcceptChanges()
        End If
        CommentRow = P.Work.CommentTable.Rows.Find(40)
        If Not CommentRow Is Nothing Then CommentMemoEdit.Text = C2.ToText(CommentRow("comment"))
    End Sub

    ' П.6
    Private Sub P6BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles P6BarCheckItem.ItemClick
        If Not CommentRow Is Nothing Then
            CommentRow("comment") = C2.ToText(CommentMemoEdit.EditValue)
            CommentRow.AcceptChanges()
        End If
        CommentRow = P.Work.CommentTable.Rows.Find(50)
        If Not CommentRow Is Nothing Then CommentMemoEdit.Text = C2.ToText(CommentRow("comment"))
    End Sub

#End Region

End Class
