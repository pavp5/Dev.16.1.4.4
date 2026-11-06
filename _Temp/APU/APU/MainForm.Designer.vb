<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.DataSaveBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataLoadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataCreateBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataToBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LawBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.SynonBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.TnvedBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.ApuBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.TestBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
        Me.TnvedReloadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.LawBarCheckItem, Me.ApuBarCheckItem, Me.DataSaveBarButtonItem, Me.DataLoadBarButtonItem, Me.DataCreateBarButtonItem, Me.TnvedBarCheckItem, Me.TestBarButtonItem, Me.SynonBarCheckItem, Me.DataToBaseBarButtonItem, Me.TnvedReloadBarButtonItem})
        Me.BarManager1.MainMenu = Me.Bar1
        Me.BarManager1.MaxItemId = 11
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.LawBarCheckItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.SynonBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.TnvedBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ApuBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.TestBarButtonItem, True)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.MultiLine = True
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.AllowDrawArrow = DevExpress.Utils.DefaultBoolean.[False]
        Me.BarSubItem1.Caption = "Данные"
        Me.BarSubItem1.Glyph = CType(resources.GetObject("BarSubItem1.Glyph"), System.Drawing.Image)
        Me.BarSubItem1.Id = 0
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DataSaveBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DataLoadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DataCreateBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.DataToBaseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.TnvedReloadBarButtonItem, True)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        Me.BarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        '
        'DataSaveBarButtonItem
        '
        Me.DataSaveBarButtonItem.Caption = "Сохранить"
        Me.DataSaveBarButtonItem.Description = "Сохранить данные в файл"
        Me.DataSaveBarButtonItem.Id = 3
        Me.DataSaveBarButtonItem.LargeGlyph = CType(resources.GetObject("DataSaveBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataSaveBarButtonItem.Name = "DataSaveBarButtonItem"
        '
        'DataLoadBarButtonItem
        '
        Me.DataLoadBarButtonItem.Caption = "Загрузить"
        Me.DataLoadBarButtonItem.Description = "Загрузить данные из файла"
        Me.DataLoadBarButtonItem.Id = 4
        Me.DataLoadBarButtonItem.LargeGlyph = CType(resources.GetObject("DataLoadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataLoadBarButtonItem.Name = "DataLoadBarButtonItem"
        '
        'DataCreateBarButtonItem
        '
        Me.DataCreateBarButtonItem.Caption = "Создать"
        Me.DataCreateBarButtonItem.Description = "Создать новый источник данных"
        Me.DataCreateBarButtonItem.Id = 5
        Me.DataCreateBarButtonItem.LargeGlyph = CType(resources.GetObject("DataCreateBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataCreateBarButtonItem.Name = "DataCreateBarButtonItem"
        '
        'DataToBaseBarButtonItem
        '
        Me.DataToBaseBarButtonItem.Caption = "Сохранить в базу"
        Me.DataToBaseBarButtonItem.Description = "Сохранить текущий АПУ в базу данных"
        Me.DataToBaseBarButtonItem.Id = 9
        Me.DataToBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("DataToBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataToBaseBarButtonItem.Name = "DataToBaseBarButtonItem"
        '
        'LawBarCheckItem
        '
        Me.LawBarCheckItem.Caption = "Списки"
        Me.LawBarCheckItem.GroupIndex = 1
        Me.LawBarCheckItem.Id = 1
        Me.LawBarCheckItem.Name = "LawBarCheckItem"
        '
        'SynonBarCheckItem
        '
        Me.SynonBarCheckItem.Caption = "Синонимы"
        Me.SynonBarCheckItem.GroupIndex = 1
        Me.SynonBarCheckItem.Id = 8
        Me.SynonBarCheckItem.Name = "SynonBarCheckItem"
        '
        'TnvedBarCheckItem
        '
        Me.TnvedBarCheckItem.Caption = "ТНВЭД"
        Me.TnvedBarCheckItem.GroupIndex = 1
        Me.TnvedBarCheckItem.Id = 6
        Me.TnvedBarCheckItem.Name = "TnvedBarCheckItem"
        '
        'ApuBarCheckItem
        '
        Me.ApuBarCheckItem.Caption = "АПУ"
        Me.ApuBarCheckItem.GroupIndex = 1
        Me.ApuBarCheckItem.Id = 2
        Me.ApuBarCheckItem.Name = "ApuBarCheckItem"
        '
        'TestBarButtonItem
        '
        Me.TestBarButtonItem.Caption = "Тест"
        Me.TestBarButtonItem.Id = 7
        Me.TestBarButtonItem.Name = "TestBarButtonItem"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(392, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 271)
        Me.barDockControlBottom.Size = New System.Drawing.Size(392, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 245)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(392, 26)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 245)
        '
        'MainPanelControl
        '
        Me.MainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanelControl.Location = New System.Drawing.Point(0, 26)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(392, 245)
        Me.MainPanelControl.TabIndex = 4
        '
        'SpellChecker1
        '
        Me.SpellChecker1.CheckAsYouTypeOptions.CheckControlsInParentContainer = True
        Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("ru-RU")
        Me.SpellChecker1.ParentContainer = Me.MainPanelControl
        Me.SpellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
        Me.SpellChecker1.SpellingFormType = DevExpress.XtraSpellChecker.SpellingFormType.Word
        '
        'TnvedReloadBarButtonItem
        '
        Me.TnvedReloadBarButtonItem.Caption = "Переписать коды ТНВЭД"
        Me.TnvedReloadBarButtonItem.Description = "Переписать коды ТН ВЭД в таблице АПУ"
        Me.TnvedReloadBarButtonItem.Id = 10
        Me.TnvedReloadBarButtonItem.LargeGlyph = CType(resources.GetObject("TnvedReloadBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.TnvedReloadBarButtonItem.Name = "TnvedReloadBarButtonItem"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 271)
        Me.Controls.Add(Me.MainPanelControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents LawBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents ApuBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents DataSaveBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataLoadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataCreateBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TnvedBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
    Friend WithEvents TestBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SynonBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents DataToBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TnvedReloadBarButtonItem As DevExpress.XtraBars.BarButtonItem
End Class
