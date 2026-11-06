Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout
Imports DevExpress.XtraBars
Imports Cprp.DxData.Work
Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Внутренние документы"
''' </summary>
Friend Class InternalChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents InternalBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents InternalRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents NewBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SendBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AcceptBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BackBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents R As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Private components As System.ComponentModel.IContainer
    Friend WithEvents SignBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents EditBoldBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditItalicBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditUnderlineBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditLeftBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditCenterBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditRightBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditJustifyBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditParagraphBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditFontBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditUndoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EditRedoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager


    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalChildControl))
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
        Dim SuperToolTip10 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem10 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem10 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip11 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem11 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem11 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip12 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem12 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem12 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip13 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem13 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem13 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip14 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem14 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem14 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip15 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem15 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem15 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip16 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem16 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem16 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip17 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem17 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem17 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.InternalBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.InternalRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.NewBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SendBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.AcceptBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BackBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.EditUndoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditRedoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditBoldBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditItalicBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditUnderlineBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditLeftBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditCenterBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditRightBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditJustifyBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditParagraphBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EditFontBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SignBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.R = New DevExpress.XtraRichEdit.RichEditControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InternalRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.InternalBarEditItem, Me.NewBarButtonItem, Me.DelBarButtonItem, Me.SendBarButtonItem, Me.AcceptBarButtonItem, Me.BackBarButtonItem, Me.SignBarButtonItem, Me.EditBoldBarButtonItem, Me.EditItalicBarButtonItem, Me.EditUnderlineBarButtonItem, Me.EditLeftBarButtonItem, Me.EditCenterBarButtonItem, Me.EditRightBarButtonItem, Me.EditJustifyBarButtonItem, Me.EditParagraphBarButtonItem, Me.EditFontBarButtonItem, Me.EditUndoBarButtonItem, Me.EditRedoBarButtonItem})
        Me.BarManager1.MaxItemId = 21
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.InternalRepositoryItemLookUpEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.InternalBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.NewBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.DelBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SendBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.AcceptBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BackBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'InternalBarEditItem
        '
        Me.InternalBarEditItem.Caption = "ВЫбрать  документ:"
        Me.InternalBarEditItem.Edit = Me.InternalRepositoryItemLookUpEdit
        Me.InternalBarEditItem.EditValue = ""
        Me.InternalBarEditItem.EditWidth = 300
        Me.InternalBarEditItem.Id = 0
        Me.InternalBarEditItem.Name = "InternalBarEditItem"
        '
        'InternalRepositoryItemLookUpEdit
        '
        Me.InternalRepositoryItemLookUpEdit.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.InternalRepositoryItemLookUpEdit.Appearance.Options.UseFont = True
        Me.InternalRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.InternalRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.InternalRepositoryItemLookUpEdit.AutoHeight = False
        Me.InternalRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InternalRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("regNum", "regNum")})
        Me.InternalRepositoryItemLookUpEdit.DisplayMember = "regNum"
        Me.InternalRepositoryItemLookUpEdit.KeyMember = "id"
        Me.InternalRepositoryItemLookUpEdit.Name = "InternalRepositoryItemLookUpEdit"
        Me.InternalRepositoryItemLookUpEdit.NullText = ""
        Me.InternalRepositoryItemLookUpEdit.NullValuePrompt = "[нет данных]"
        Me.InternalRepositoryItemLookUpEdit.ShowFooter = False
        Me.InternalRepositoryItemLookUpEdit.ShowHeader = False
        Me.InternalRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'NewBarButtonItem
        '
        Me.NewBarButtonItem.Caption = "Создать"
        Me.NewBarButtonItem.Glyph = CType(resources.GetObject("NewBarButtonItem.Glyph"), System.Drawing.Image)
        Me.NewBarButtonItem.Id = 1
        Me.NewBarButtonItem.Name = "NewBarButtonItem"
        ToolTipTitleItem1.Text = "Создать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Создать новый документ"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.NewBarButtonItem.SuperTip = SuperToolTip1
        '
        'DelBarButtonItem
        '
        Me.DelBarButtonItem.Caption = "Удалить"
        Me.DelBarButtonItem.Glyph = CType(resources.GetObject("DelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.DelBarButtonItem.Id = 2
        Me.DelBarButtonItem.Name = "DelBarButtonItem"
        ToolTipTitleItem2.Text = "Удалить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Удалить документ"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.DelBarButtonItem.SuperTip = SuperToolTip2
        '
        'SendBarButtonItem
        '
        Me.SendBarButtonItem.Caption = "Отправить"
        Me.SendBarButtonItem.Glyph = CType(resources.GetObject("SendBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SendBarButtonItem.Id = 3
        Me.SendBarButtonItem.Name = "SendBarButtonItem"
        ToolTipTitleItem3.Text = "Отправить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Отправить документ на утверждение"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.SendBarButtonItem.SuperTip = SuperToolTip3
        '
        'AcceptBarButtonItem
        '
        Me.AcceptBarButtonItem.Caption = "Утвердить документ"
        Me.AcceptBarButtonItem.Glyph = CType(resources.GetObject("AcceptBarButtonItem.Glyph"), System.Drawing.Image)
        Me.AcceptBarButtonItem.Id = 4
        Me.AcceptBarButtonItem.Name = "AcceptBarButtonItem"
        ToolTipTitleItem4.Text = "Утвердить"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Утвердить документ"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.AcceptBarButtonItem.SuperTip = SuperToolTip4
        '
        'BackBarButtonItem
        '
        Me.BackBarButtonItem.Caption = "Возврат документа"
        Me.BackBarButtonItem.Glyph = CType(resources.GetObject("BackBarButtonItem.Glyph"), System.Drawing.Image)
        Me.BackBarButtonItem.Id = 5
        Me.BackBarButtonItem.Name = "BackBarButtonItem"
        ToolTipTitleItem5.Text = "Возврат"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Возврат документа на доработку"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.BackBarButtonItem.SuperTip = SuperToolTip5
        '
        'Bar2
        '
        Me.Bar2.BarName = "Редактирование"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 1
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.EditUndoBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditRedoBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditBoldBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.EditItalicBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditUnderlineBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditLeftBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.EditCenterBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditRightBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EditJustifyBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditParagraphBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.EditFontBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Редактирование"
        '
        'EditUndoBarButtonItem
        '
        Me.EditUndoBarButtonItem.Caption = "Отменить"
        Me.EditUndoBarButtonItem.Glyph = CType(resources.GetObject("EditUndoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditUndoBarButtonItem.Id = 19
        Me.EditUndoBarButtonItem.Name = "EditUndoBarButtonItem"
        ToolTipTitleItem6.Text = "Отменить"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Отменить последнее действие"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.EditUndoBarButtonItem.SuperTip = SuperToolTip6
        '
        'EditRedoBarButtonItem
        '
        Me.EditRedoBarButtonItem.Caption = "Вернуть"
        Me.EditRedoBarButtonItem.Glyph = CType(resources.GetObject("EditRedoBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditRedoBarButtonItem.Id = 20
        Me.EditRedoBarButtonItem.Name = "EditRedoBarButtonItem"
        ToolTipTitleItem7.Text = "Вернуть"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Вернуть последнее действие"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.EditRedoBarButtonItem.SuperTip = SuperToolTip7
        '
        'EditBoldBarButtonItem
        '
        Me.EditBoldBarButtonItem.Caption = "Полужирный"
        Me.EditBoldBarButtonItem.Glyph = CType(resources.GetObject("EditBoldBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditBoldBarButtonItem.Id = 10
        Me.EditBoldBarButtonItem.Name = "EditBoldBarButtonItem"
        ToolTipTitleItem8.Text = "Полужирный"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Применение полужирного начертания к выделенному тексту"
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.EditBoldBarButtonItem.SuperTip = SuperToolTip8
        '
        'EditItalicBarButtonItem
        '
        Me.EditItalicBarButtonItem.Caption = "Курсив"
        Me.EditItalicBarButtonItem.Glyph = CType(resources.GetObject("EditItalicBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditItalicBarButtonItem.Id = 11
        Me.EditItalicBarButtonItem.Name = "EditItalicBarButtonItem"
        ToolTipTitleItem9.Text = "Курсив"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Применение курсивного начертания к выделенному тексту"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.EditItalicBarButtonItem.SuperTip = SuperToolTip9
        '
        'EditUnderlineBarButtonItem
        '
        Me.EditUnderlineBarButtonItem.Caption = "Подчеркнутый"
        Me.EditUnderlineBarButtonItem.Glyph = CType(resources.GetObject("EditUnderlineBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditUnderlineBarButtonItem.Id = 12
        Me.EditUnderlineBarButtonItem.Name = "EditUnderlineBarButtonItem"
        ToolTipTitleItem10.Text = "Подчеркнутый"
        ToolTipItem10.LeftIndent = 6
        ToolTipItem10.Text = "Подчеркивание выделенного текста"
        SuperToolTip10.Items.Add(ToolTipTitleItem10)
        SuperToolTip10.Items.Add(ToolTipItem10)
        Me.EditUnderlineBarButtonItem.SuperTip = SuperToolTip10
        '
        'EditLeftBarButtonItem
        '
        Me.EditLeftBarButtonItem.Caption = "По левому краю"
        Me.EditLeftBarButtonItem.Glyph = CType(resources.GetObject("EditLeftBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditLeftBarButtonItem.Id = 13
        Me.EditLeftBarButtonItem.Name = "EditLeftBarButtonItem"
        ToolTipTitleItem11.Text = "Выровнять текст по левому краю"
        ToolTipItem11.LeftIndent = 6
        ToolTipItem11.Text = "Выравнивание текста по левому краю"
        SuperToolTip11.Items.Add(ToolTipTitleItem11)
        SuperToolTip11.Items.Add(ToolTipItem11)
        Me.EditLeftBarButtonItem.SuperTip = SuperToolTip11
        '
        'EditCenterBarButtonItem
        '
        Me.EditCenterBarButtonItem.Caption = "По центру"
        Me.EditCenterBarButtonItem.Glyph = CType(resources.GetObject("EditCenterBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditCenterBarButtonItem.Id = 14
        Me.EditCenterBarButtonItem.Name = "EditCenterBarButtonItem"
        ToolTipTitleItem12.Text = "Выровнять текст по центру"
        ToolTipItem12.LeftIndent = 6
        ToolTipItem12.Text = "Выравнивание текста по центру"
        SuperToolTip12.Items.Add(ToolTipTitleItem12)
        SuperToolTip12.Items.Add(ToolTipItem12)
        Me.EditCenterBarButtonItem.SuperTip = SuperToolTip12
        '
        'EditRightBarButtonItem
        '
        Me.EditRightBarButtonItem.Caption = "По правому краю"
        Me.EditRightBarButtonItem.Glyph = CType(resources.GetObject("EditRightBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditRightBarButtonItem.Id = 15
        Me.EditRightBarButtonItem.Name = "EditRightBarButtonItem"
        ToolTipTitleItem13.Text = "Выровнять текст по правому краю"
        ToolTipItem13.LeftIndent = 6
        ToolTipItem13.Text = "Выравнивание текста по правому краю"
        SuperToolTip13.Items.Add(ToolTipTitleItem13)
        SuperToolTip13.Items.Add(ToolTipItem13)
        Me.EditRightBarButtonItem.SuperTip = SuperToolTip13
        '
        'EditJustifyBarButtonItem
        '
        Me.EditJustifyBarButtonItem.Caption = "По ширине"
        Me.EditJustifyBarButtonItem.Glyph = CType(resources.GetObject("EditJustifyBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditJustifyBarButtonItem.Id = 16
        Me.EditJustifyBarButtonItem.Name = "EditJustifyBarButtonItem"
        ToolTipTitleItem14.Text = "Выровнять по ширине"
        ToolTipItem14.LeftIndent = 6
        ToolTipItem14.Text = "Выравнивание текста по ширине страницы"
        SuperToolTip14.Items.Add(ToolTipTitleItem14)
        SuperToolTip14.Items.Add(ToolTipItem14)
        Me.EditJustifyBarButtonItem.SuperTip = SuperToolTip14
        '
        'EditParagraphBarButtonItem
        '
        Me.EditParagraphBarButtonItem.Caption = "Абзац"
        Me.EditParagraphBarButtonItem.Glyph = CType(resources.GetObject("EditParagraphBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditParagraphBarButtonItem.Id = 17
        Me.EditParagraphBarButtonItem.Name = "EditParagraphBarButtonItem"
        ToolTipTitleItem15.Text = "Абзац"
        ToolTipItem15.LeftIndent = 6
        ToolTipItem15.Text = "Открытите диалогового окна ""Абзац"""
        SuperToolTip15.Items.Add(ToolTipTitleItem15)
        SuperToolTip15.Items.Add(ToolTipItem15)
        Me.EditParagraphBarButtonItem.SuperTip = SuperToolTip15
        '
        'EditFontBarButtonItem
        '
        Me.EditFontBarButtonItem.Caption = "Шрифт"
        Me.EditFontBarButtonItem.Glyph = CType(resources.GetObject("EditFontBarButtonItem.Glyph"), System.Drawing.Image)
        Me.EditFontBarButtonItem.Id = 18
        Me.EditFontBarButtonItem.Name = "EditFontBarButtonItem"
        ToolTipTitleItem16.Text = "Шрифт"
        ToolTipItem16.LeftIndent = 6
        ToolTipItem16.Text = "Открытие диалогового окна ""Шрифт"""
        SuperToolTip16.Items.Add(ToolTipTitleItem16)
        SuperToolTip16.Items.Add(ToolTipItem16)
        Me.EditFontBarButtonItem.SuperTip = SuperToolTip16
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1150, 94)
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
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 94)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 556)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1150, 94)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 556)
        '
        'SignBarButtonItem
        '
        Me.SignBarButtonItem.Caption = "Подписать"
        Me.SignBarButtonItem.Glyph = CType(resources.GetObject("SignBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SignBarButtonItem.Id = 9
        Me.SignBarButtonItem.Name = "SignBarButtonItem"
        ToolTipTitleItem17.Text = "Подписать"
        ToolTipItem17.LeftIndent = 6
        ToolTipItem17.Text = "Подписать документ"
        SuperToolTip17.Items.Add(ToolTipTitleItem17)
        SuperToolTip17.Items.Add(ToolTipItem17)
        Me.SignBarButtonItem.SuperTip = SuperToolTip17
        '
        'R
        '
        Me.R.Dock = System.Windows.Forms.DockStyle.Fill
        Me.R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        Me.R.Location = New System.Drawing.Point(0, 94)
        Me.R.MenuManager = Me.BarManager1
        Me.R.Name = "R"
        Me.R.ReadOnly = True
        Me.R.Size = New System.Drawing.Size(1150, 556)
        Me.R.TabIndex = 26
        Me.R.Views.PrintLayoutView.MaxHorizontalPageCount = 1
        '
        'InternalChildControl
        '
        Me.Controls.Add(Me.R)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "InternalChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InternalRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        Using V As New DataView(P.Work.InternalTable) With {.Sort = "id"}
            If V.Count > 0 Then
                InternalBarEditItem.EditValue = V(V.Count - 1)("id")
                R.OpenXmlBytes = V(V.Count - 1)("docData")
            Else
                R.Text = "[нет данных]"
            End If
        End Using
        isDocLoaded = False
        isDocChanged = False
        LockUpdate()
    End Sub

    Friend Overrides Sub DataWrite()
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Not Row Is Nothing Then
            Row("docData") = R.OpenXmlBytes
            P.Work.InternalTable.AcceptChanges()
        End If
        'P.Work.InternalFieldsUpdate()
    End Sub

    Private Sub LockUpdate()
        Dim bExpert As Boolean = P.CurrentUserIsWorkExpert AndAlso _
            P.Work.Condition <> WorkCondition.IsAccept AndAlso P.Work.Condition <> WorkCondition.IsAgree AndAlso _
            P.Work.Condition <> WorkCondition.IsCancel AndAlso P.Work.Condition <> WorkCondition.IsClose
        Dim bLeader As Boolean = P.CurrentUserIsWorkLeader AndAlso _
            (P.CurrentUser.IsChief OrElse P.CurrentUser.IsLeader OrElse P.CurrentUser.IsSubleader)
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        Dim condition As WorkCondition = WorkCondition.IsEmpty
        If Not Row Is Nothing Then condition = CType(Row("conditionId"), WorkCondition)
        '
        ' R
        '
        R.ReadOnly = (Row Is Nothing)
        If Not R.ReadOnly Then R.ReadOnly = Not (bExpert AndAlso condition = WorkCondition.IsWork)
        '
        ' NewBarButtonItem
        '
        NewBarButtonItem.Enabled = bExpert
        NewBarButtonItem.Visibility = If(P.CurrentUser.IsExpert, BarItemVisibility.Always, BarItemVisibility.Never)
        '
        ' DelBarButtonItem
        '
        DelBarButtonItem.Enabled = (bExpert AndAlso condition = WorkCondition.IsWork)
        DelBarButtonItem.Visibility = If(P.CurrentUser.IsExpert, BarItemVisibility.Always, BarItemVisibility.Never)
        '
        ' SendBarButtonItem
        '
        SendBarButtonItem.Enabled = (bExpert AndAlso condition = WorkCondition.IsWork)
        SendBarButtonItem.Visibility = If(P.CurrentUser.IsExpert, BarItemVisibility.Always, BarItemVisibility.Never)
        ''
        '' SignBarButtonItem
        ''
        'SignBarButtonItem.Enabled = (bExpert AndAlso condition = WorkCondition.IsSignature)
        'SignBarButtonItem.Visibility = If(P.CurrentUser.IsExpert, BarItemVisibility.Always, BarItemVisibility.Never)
        '
        ' AcceptBarButtonItem
        '
        AcceptBarButtonItem.Enabled = (bLeader AndAlso condition = WorkCondition.IsAgree)
        AcceptBarButtonItem.Visibility = If(P.CurrentUser.IsLeader, BarItemVisibility.Always, BarItemVisibility.Never)
        '
        ' BackBarButtonItem
        '
        BackBarButtonItem.Enabled = (bLeader AndAlso (condition = WorkCondition.IsAgree OrElse condition = WorkCondition.IsSignature))
        BackBarButtonItem.Visibility = If(P.CurrentUser.IsLeader, BarItemVisibility.Always, BarItemVisibility.Never)
        '
        ' InternalBarEditItem
        '
        If P.Work.InternalTable.Rows.Count = 0 Then
            InternalBarEditItem.Caption = "Документов нет"
            InternalBarEditItem.Enabled = False
        Else
            InternalBarEditItem.Caption = String.Format("Выбрать документ ({0}):", P.Work.InternalTable.Rows.Count)
            InternalBarEditItem.Enabled = True
        End If

    End Sub

#End Region

    ''' <summary>
    ''' Документ загружен
    ''' </summary>
    Private isDocLoaded As Boolean = False

    ''' <summary>
    ''' Документ изменен пользователем
    ''' </summary>
    Private isDocChanged As Boolean = False


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.Internal
        If P.SpellChecker1.Dictionaries.Count > 0 Then R.SpellChecker = P.SpellChecker1
        InternalRepositoryItemLookUpEdit.DataSource = P.Work.InternalTable
    End Sub


    ' Сохранить текущий документ перед переходом к другому 
    Private Sub InternalRepositoryItemLookUpEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles InternalRepositoryItemLookUpEdit.EditValueChanging
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(e.OldValue))
        If Not Row Is Nothing Then
            Row("docData") = R.OpenXmlBytes
            P.Work.InternalTable.AcceptChanges()
        End If
    End Sub

    ' Загрузить новый документ после перехода к нему от другого документа
    Private Sub InternalBarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles InternalBarEditItem.EditValueChanged
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Row Is Nothing OrElse IsDBNull(Row("docData")) Then
            R.OpenXmlBytes = Nothing
            R.Text = "[нет данных]"
        Else
            R.OpenXmlBytes = Row("docData")
        End If
        LockUpdate()
    End Sub

    ' Создать документ
    Private Sub NewBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewBarButtonItem.ItemClick
        Dim caption As String = Nothing
        Using F As New InternalCaptionForm
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
            caption = C2.ToText(F.CaptionMemoEdit.Text).Replace(vbCrLf, " ")
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ' сохранить текущий документ
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Not Row Is Nothing Then
            Row("docData") = R.OpenXmlBytes
            P.Work.InternalTable.AcceptChanges()
        End If
        ' создание нового документа
        Row = P.Work.InternalTable.NewRow
        Row("regNum") = String.Format("Проект {0}", P.Work.InternalTable.Rows.Count + 1)
        Row("caption") = caption
        P.Work.InternalTable.Rows.Add(Row)
        P.Work.InternalCreateProject(Row)
        InternalBarEditItem.EditValue = Row("id")
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Удалить документ
    Private Sub DelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DelBarButtonItem.ItemClick
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Row Is Nothing OrElse CType(Row("conditionId"), WorkCondition) <> WorkCondition.IsWork Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить текущий документ?") <> DialogResult.Yes Then Exit Sub

        Row.Delete()
        P.Work.InternalTable.AcceptChanges()

        P.Work.DataSave()
        DataRead()
    End Sub

    ' Отправить документ на утверждение
    Private Sub SendBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SendBarButtonItem.ItemClick
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Row Is Nothing OrElse CType(Row("conditionId"), WorkCondition) <> WorkCondition.IsWork Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Отправить документ на утверждение?") <> DialogResult.Yes Then Exit Sub
        '
        ' Сохранение данных
        '
        Row("docData") = R.OpenXmlBytes
        Row("regNum") = "утверждение"
        Row("conditionId") = CInt(WorkCondition.IsAgree)
        Row("changeDate") = Date.Now
        P.Work.InternalTable.AcceptChanges()
        P.Work("isInt") = True

        P.Work.DataSave()
        LockUpdate()
        '
        ' Отправка email-сообщения руководителю
        '
        If Not IsDBNull(P.Work("leaderId")) AndAlso P.Work.Condition = WorkCondition.IsWork Then
            Dim Mail As New Cprp.DxData.Mail(P.Work.Connection)
            Dim caption As String = Nothing
            Dim body As String = Nothing
            caption = String.Format("{0} отправил на утверждение внутренний документ по работе № {1}", P.CurrentUser.NameShort, CInt(P.Work.Id))
            body = caption
            Mail.Send(P.CurrentUser.Id, P.Work("leaderId"), caption, body)
        End If

        P.Work.WriteHistory(WorkEvent.InternalAgree, Nothing)
        Cprp.DxCommon.Messages.ShowInformation("Документ отправлен на утверждение.")
    End Sub

    ' Утвердить документ
    Private Sub AcceptBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AcceptBarButtonItem.ItemClick
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Row Is Nothing OrElse CType(Row("conditionId"), WorkCondition) <> WorkCondition.IsAgree Then Exit Sub
        '
        ' Утверждение документа
        '
        Dim comment As String = Nothing
        Using F As New InternalAcceptForm
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
            comment = C2.ToText(F.CommentMemoEdit.Text).Replace(vbCrLf, " ")
        End Using

        P.Work.InternalSetRegNum(Row)
        P.Work.InternalCreateDocument(Row)
        Row("conditionId") = CInt(WorkCondition.IsClose)
        P.Work.InternalTable.AcceptChanges()
        '
        ' Проверка наличия неутвержденных документов по работе
        '
        P.Work.InternalFieldsUpdate()

        P.Work.DataSave()

        DataRead()
        P.Work.WriteHistory(WorkEvent.InternalAccept, String.Format("Резолюция руководителя:{0}{1}", vbCrLf, comment))

        Cprp.DxCommon.Messages.ShowInformation("Документ утвержден.")
        '
        ' Отправка email-сообщений исполнителю
        '
        Dim Mail As New Cprp.DxData.Mail(P.Work.Connection)
        Dim caption As String = Nothing
        Dim body As String = Nothing
        If Not IsDBNull(P.Work("expertId")) Then
            caption = String.Format("{0} утвердил внутренний документ по Вашей работе № {1}.", P.CurrentUser.NameShort, CInt(P.Work.Id))
            body = String.Format("{0}{1}Резолюция руководителя:{1}{2}", caption, vbCrLf, C2.AddPoint(comment))
            Mail.Send(P.CurrentUser.Id, P.Work("expertId"), caption, body)
        End If
        '
        ' Закрыть текущий элемент управления
        '
        If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm AndAlso P.Work.Condition <> WorkCondition.IsPlaneAgree Then
            CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(P.Work.Id)
        End If
    End Sub

    ' Возврат документа на доработку
    Private Sub BackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BackBarButtonItem.ItemClick
        Dim Row As DataRow = P.Work.InternalTable.Rows.Find(C2.ToInt(InternalBarEditItem.EditValue))
        If Row Is Nothing Then Exit Sub
        '
        ' Открытие формы возврата
        '
        Dim comment As String = Nothing
        Using F As New InternalBackForm
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
            comment = C2.ToText(F.CommentMemoEdit.Text)
        End Using
        '
        ' Изменение данных документа
        '
        Row("regNum") = "проект"
        Row("conditionId") = CInt(WorkCondition.IsWork)
        Row("changeDate") = Date.Now
        '
        ' Проверка наличия неутвержденных запросов в работе
        '
        P.Work.InternalFieldsUpdate()

        P.Work.DataSave()
        LockUpdate()
        '
        ' Отправка email-сообщения эксперту
        '
        Dim Mail As New Cprp.DxData.Mail(P.Work.Connection)
        Dim caption As String = Nothing
        Dim body As String = Nothing
        If Not IsDBNull(P.Work("expertId")) Then
            caption = String.Format("{0} вернул Ваш внутренний документ по работе № {1} на доработку.", P.CurrentUser.NameShort, CInt(P.Work.Id))
            body = String.Format("{0}{1}Указания руководителя:{1}{2}", caption, vbCrLf, C2.AddPoint(comment))
            Mail.Send(P.CurrentUser.Id, P.Work("expertId"), caption, body)
        End If
        P.Work.WriteHistory(WorkEvent.InternalBack, comment)
        '
        ' Закрыть текущий элемент управления
        '
        If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm AndAlso P.Work.Condition <> WorkCondition.IsPlaneAgree Then
            CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(P.Work.Id)
        End If
    End Sub

    Private Sub R_ContentChanged(sender As Object, e As EventArgs) Handles R.ContentChanged
        isDocChanged = isDocLoaded
        isDocLoaded = True
    End Sub

    Private Sub R_DocumentLoaded(sender As Object, e As EventArgs) Handles R.DocumentLoaded
        isDocLoaded = False
    End Sub


    Private Sub EditUndoBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditUndoBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.Undo).Execute()
    End Sub

    Private Sub EditRedoBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditRedoBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.Redo).Execute()
    End Sub

    Private Sub EditBoldBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditBoldBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleFontBold).Execute()
    End Sub

    Private Sub EditItalicBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditItalicBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleFontItalic).Execute()
    End Sub

    Private Sub EditUnderlineBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditUnderlineBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleFontUnderline).Execute()
    End Sub

    Private Sub EditLeftBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditLeftBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleParagraphAlignmentLeft).Execute()
    End Sub

    Private Sub EditCenterBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditCenterBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleParagraphAlignmentCenter).Execute()
    End Sub

    Private Sub EditRightBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditRightBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleParagraphAlignmentRight).Execute()
    End Sub

    Private Sub EditJustifyBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditJustifyBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ToggleParagraphAlignmentJustify).Execute()
    End Sub

    Private Sub EditParagraphBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditParagraphBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ShowParagraphForm).Execute()
    End Sub

    Private Sub EditFontBarButtonItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles EditFontBarButtonItem.ItemClick
        R.CreateCommand(DevExpress.XtraRichEdit.Commands.RichEditCommandId.ShowFontForm).Execute()
    End Sub

End Class
