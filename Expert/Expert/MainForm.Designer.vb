<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits DevExpress.XtraBars.TabForm

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
        Me.TabFormControl1 = New DevExpress.XtraBars.TabFormControl()
        Me.MenuBarSubItem = New DevExpress.XtraBars.BarSubItem()
        Me.FindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.LawBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FInfoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.TabFormDefaultManager1 = New DevExpress.XtraBars.TabFormDefaultManager()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DefaultBarAndDockingController1 = New DevExpress.XtraBars.DefaultBarAndDockingController(Me.components)
        Me.AlertControl1 = New DevExpress.XtraBars.Alerter.AlertControl(Me.components)
        Me.ManualBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.TabFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabFormDefaultManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabFormControl1
        '
        Me.TabFormControl1.AllowMoveTabsToOuterForm = False
        Me.TabFormControl1.Appearance.Page.Disabled.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Disabled.Options.UseFont = True
        Me.TabFormControl1.Appearance.Page.Hovered.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Hovered.Options.UseFont = True
        Me.TabFormControl1.Appearance.Page.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Normal.Options.UseFont = True
        Me.TabFormControl1.Appearance.Page.Pressed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Pressed.Options.UseFont = True
        Me.TabFormControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.MenuBarSubItem, Me.FindBarButtonItem, Me.LawBarButtonItem, Me.FInfoBarButtonItem, Me.ManualBarButtonItem})
        Me.TabFormControl1.LinkProvider.TabLeftItemLinks.Add(Me.MenuBarSubItem)
        Me.TabFormControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabFormControl1.Manager = Me.TabFormDefaultManager1
        Me.TabFormControl1.Name = "TabFormControl1"
        Me.TabFormControl1.ShowAddPageButton = False
        Me.TabFormControl1.Size = New System.Drawing.Size(298, 62)
        Me.TabFormControl1.TabForm = Me
        Me.TabFormControl1.TabIndex = 0
        Me.TabFormControl1.TabStop = False
        '
        'MenuBarSubItem
        '
        Me.MenuBarSubItem.Caption = "Дополнительно"
        Me.MenuBarSubItem.Glyph = CType(resources.GetObject("MenuBarSubItem.Glyph"), System.Drawing.Image)
        Me.MenuBarSubItem.Id = 0
        Me.MenuBarSubItem.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FindBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.LawBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FInfoBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ManualBarButtonItem, True)})
        Me.MenuBarSubItem.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.MenuBarSubItem.Name = "MenuBarSubItem"
        Me.MenuBarSubItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        '
        'FindBarButtonItem
        '
        Me.FindBarButtonItem.Caption = "ПОИСК РАБОТ"
        Me.FindBarButtonItem.Description = "Поиск работ в базе данных ""Экспертной системы"""
        Me.FindBarButtonItem.Id = 1
        Me.FindBarButtonItem.LargeGlyph = CType(resources.GetObject("FindBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FindBarButtonItem.Name = "FindBarButtonItem"
        '
        'LawBarButtonItem
        '
        Me.LawBarButtonItem.Caption = "НОРМАТИВНЫЕ ДОКУМЕНТЫ"
        Me.LawBarButtonItem.Description = "Сборник нормативно-правовых документов"
        Me.LawBarButtonItem.Id = 2
        Me.LawBarButtonItem.LargeGlyph = CType(resources.GetObject("LawBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.LawBarButtonItem.Name = "LawBarButtonItem"
        '
        'FInfoBarButtonItem
        '
        Me.FInfoBarButtonItem.Caption = "КОНТРОЛИРУЕМЫЕ ЗАКЛЮЧЕНИЯ"
        Me.FInfoBarButtonItem.Description = "Перечень заключений с выводами ""Требуется лицензия"", ""Требуется разрешение"""
        Me.FInfoBarButtonItem.Id = 3
        Me.FInfoBarButtonItem.LargeGlyph = CType(resources.GetObject("FInfoBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FInfoBarButtonItem.Name = "FInfoBarButtonItem"
        '
        'TabFormDefaultManager1
        '
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlTop)
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlBottom)
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlLeft)
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlRight)
        Me.TabFormDefaultManager1.Form = Me
        Me.TabFormDefaultManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.MenuBarSubItem, Me.FindBarButtonItem, Me.LawBarButtonItem, Me.FInfoBarButtonItem, Me.ManualBarButtonItem})
        Me.TabFormDefaultManager1.MaxItemId = 5
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(298, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 299)
        Me.barDockControlBottom.Size = New System.Drawing.Size(298, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 299)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(298, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 299)
        '
        'DefaultBarAndDockingController1
        '
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Item.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Item.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDisabled.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDisabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemHovered.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemHovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemPressed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemPressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultGlyphSize = New System.Drawing.Size(16, 16)
        Me.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultLargeGlyphSize = New System.Drawing.Size(32, 32)
        '
        'AlertControl1
        '
        '
        'ManualBarButtonItem
        '
        Me.ManualBarButtonItem.Caption = "РУКОВОДСТВО ПОЛЬЗОВАТЕЛЯ"
        Me.ManualBarButtonItem.Description = "Руководство пользователя к программе"
        Me.ManualBarButtonItem.Id = 4
        Me.ManualBarButtonItem.LargeGlyph = CType(resources.GetObject("ManualBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ManualBarButtonItem.Name = "ManualBarButtonItem"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 299)
        Me.Controls.Add(Me.TabFormControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MainForm"
        Me.TabFormControl = Me.TabFormControl1
        Me.Text = "MainForm"
        CType(Me.TabFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabFormDefaultManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabFormControl1 As DevExpress.XtraBars.TabFormControl
    Friend WithEvents TabFormDefaultManager1 As DevExpress.XtraBars.TabFormDefaultManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents MenuBarSubItem As DevExpress.XtraBars.BarSubItem
    Friend WithEvents FindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LawBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DefaultBarAndDockingController1 As DevExpress.XtraBars.DefaultBarAndDockingController
    Friend WithEvents AlertControl1 As DevExpress.XtraBars.Alerter.AlertControl
    Friend WithEvents FInfoBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ManualBarButtonItem As DevExpress.XtraBars.BarButtonItem
End Class
