<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindUserControl0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindUserControl0))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.FindConditionBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.FindResultBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.WorkBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.BarAndDockingController1 = New DevExpress.XtraBars.BarAndDockingController(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarAndDockingController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.Controller = Me.BarAndDockingController1
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.FindConditionBarCheckItem, Me.FindResultBarCheckItem, Me.WorkBarCheckItem})
        Me.BarManager1.MainMenu = Me.Bar1
        Me.BarManager1.MaxItemId = 3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindConditionBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindResultBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.WorkBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'FindConditionBarCheckItem
        '
        Me.FindConditionBarCheckItem.Caption = "КРИТЕРИИ ПОИСКА"
        Me.FindConditionBarCheckItem.Glyph = CType(resources.GetObject("FindConditionBarCheckItem.Glyph"), System.Drawing.Image)
        Me.FindConditionBarCheckItem.GroupIndex = 1
        Me.FindConditionBarCheckItem.Id = 0
        Me.FindConditionBarCheckItem.Name = "FindConditionBarCheckItem"
        '
        'FindResultBarCheckItem
        '
        Me.FindResultBarCheckItem.Caption = "РЕЗУЛЬТАТЫ ПОИСКА"
        Me.FindResultBarCheckItem.Glyph = CType(resources.GetObject("FindResultBarCheckItem.Glyph"), System.Drawing.Image)
        Me.FindResultBarCheckItem.GroupIndex = 1
        Me.FindResultBarCheckItem.Id = 1
        Me.FindResultBarCheckItem.Name = "FindResultBarCheckItem"
        '
        'WorkBarCheckItem
        '
        Me.WorkBarCheckItem.Caption = "СВЕДЕНИЯ О РАБОТЕ"
        Me.WorkBarCheckItem.Glyph = CType(resources.GetObject("WorkBarCheckItem.Glyph"), System.Drawing.Image)
        Me.WorkBarCheckItem.GroupIndex = 1
        Me.WorkBarCheckItem.Id = 2
        Me.WorkBarCheckItem.Name = "WorkBarCheckItem"
        '
        'BarAndDockingController1
        '
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Disabled.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Hovered.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Normal.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.BarAppearance.Pressed.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Disabled.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Hovered.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Normal.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.BarAndDockingController1.AppearancesBar.MainMenuAppearance.Pressed.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Normal.Options.UseFont = True
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.BarAndDockingController1.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Options.UseFont = True
        Me.BarAndDockingController1.PropertiesBar.DefaultGlyphSize = New System.Drawing.Size(16, 16)
        Me.BarAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = New System.Drawing.Size(32, 32)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(600, 35)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 150)
        Me.barDockControlBottom.Size = New System.Drawing.Size(600, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 35)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 115)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(600, 35)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 115)
        '
        'FindUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FindUserControl"
        Me.Size = New System.Drawing.Size(600, 150)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarAndDockingController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents FindConditionBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents FindResultBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarAndDockingController1 As DevExpress.XtraBars.BarAndDockingController
    Friend WithEvents WorkBarCheckItem As DevExpress.XtraBars.BarCheckItem

End Class
