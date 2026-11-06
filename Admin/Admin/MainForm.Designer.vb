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
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.MainMenuBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ResourceBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.TnvedBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.CountryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ControlBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EmbargoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FInfoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.UsersBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EndDocumentBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.MainMenuBarButtonItem, Me.ResourceBarButtonItem, Me.UsersBarButtonItem, Me.EndDocumentBarButtonItem, Me.TnvedBarButtonItem, Me.ControlBarButtonItem, Me.EmbargoBarButtonItem, Me.FInfoBarButtonItem, Me.CountryBarButtonItem})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 10
        '
        'Bar2
        '
        Me.Bar2.BarName = "Главное меню"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.MainMenuBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ResourceBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.TnvedBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.CountryBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ControlBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.EmbargoBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FInfoBarButtonItem)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Главное меню"
        '
        'MainMenuBarButtonItem
        '
        Me.MainMenuBarButtonItem.ActAsDropDown = True
        Me.MainMenuBarButtonItem.AllowDrawArrow = False
        Me.MainMenuBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown
        Me.MainMenuBarButtonItem.Caption = "Главное меню"
        Me.MainMenuBarButtonItem.Glyph = CType(resources.GetObject("MainMenuBarButtonItem.Glyph"), System.Drawing.Image)
        Me.MainMenuBarButtonItem.Id = 0
        Me.MainMenuBarButtonItem.Name = "MainMenuBarButtonItem"
        '
        'ResourceBarButtonItem
        '
        Me.ResourceBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ResourceBarButtonItem.Caption = "Ресурсы"
        Me.ResourceBarButtonItem.GroupIndex = 1
        Me.ResourceBarButtonItem.Id = 2
        Me.ResourceBarButtonItem.Name = "ResourceBarButtonItem"
        '
        'TnvedBarButtonItem
        '
        Me.TnvedBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.TnvedBarButtonItem.Caption = "Товарная номенклатура"
        Me.TnvedBarButtonItem.GroupIndex = 1
        Me.TnvedBarButtonItem.Id = 5
        Me.TnvedBarButtonItem.Name = "TnvedBarButtonItem"
        '
        'CountryBarButtonItem
        '
        Me.CountryBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.CountryBarButtonItem.Caption = "Страны мира"
        Me.CountryBarButtonItem.GroupIndex = 1
        Me.CountryBarButtonItem.Id = 9
        Me.CountryBarButtonItem.Name = "CountryBarButtonItem"
        '
        'ControlBarButtonItem
        '
        Me.ControlBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ControlBarButtonItem.Caption = "Нормативные документы"
        Me.ControlBarButtonItem.GroupIndex = 1
        Me.ControlBarButtonItem.Id = 6
        Me.ControlBarButtonItem.Name = "ControlBarButtonItem"
        '
        'EmbargoBarButtonItem
        '
        Me.EmbargoBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.EmbargoBarButtonItem.Caption = "Запреты и ограничения"
        Me.EmbargoBarButtonItem.GroupIndex = 1
        Me.EmbargoBarButtonItem.Id = 7
        Me.EmbargoBarButtonItem.Name = "EmbargoBarButtonItem"
        '
        'FInfoBarButtonItem
        '
        Me.FInfoBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.FInfoBarButtonItem.Caption = "Заключения ФСТЭК"
        Me.FInfoBarButtonItem.GroupIndex = 1
        Me.FInfoBarButtonItem.Id = 8
        Me.FInfoBarButtonItem.Name = "FInfoBarButtonItem"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(866, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 336)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(866, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 276)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(866, 60)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 276)
        '
        'UsersBarButtonItem
        '
        Me.UsersBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.UsersBarButtonItem.Caption = "Пользователи"
        Me.UsersBarButtonItem.GroupIndex = 1
        Me.UsersBarButtonItem.Id = 3
        Me.UsersBarButtonItem.Name = "UsersBarButtonItem"
        '
        'EndDocumentBarButtonItem
        '
        Me.EndDocumentBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.EndDocumentBarButtonItem.Caption = "Заключения"
        Me.EndDocumentBarButtonItem.GroupIndex = 1
        Me.EndDocumentBarButtonItem.Id = 4
        Me.EndDocumentBarButtonItem.Name = "EndDocumentBarButtonItem"
        '
        'MainPanelControl
        '
        Me.MainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanelControl.Location = New System.Drawing.Point(0, 60)
        Me.MainPanelControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(866, 276)
        Me.MainPanelControl.TabIndex = 4
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 336)
        Me.Controls.Add(Me.MainPanelControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents MainMenuBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ResourceBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UsersBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EndDocumentBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TnvedBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ControlBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents EmbargoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FInfoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CountryBarButtonItem As DevExpress.XtraBars.BarButtonItem
End Class
