<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindUserControl))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.ConditionBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ResultBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ReferenceBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.ReportOrgBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ReportCountryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.ReportSummaryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ConditionBarButtonItem, Me.ResultBarButtonItem, Me.ReferenceBarButtonItem, Me.BarSubItem1, Me.ReportOrgBarButtonItem, Me.ReportCountryBarButtonItem, Me.ReportSummaryBarButtonItem})
        Me.BarManager1.MaxItemId = 12
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ConditionBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ResultBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ReferenceBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1, True)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'ConditionBarButtonItem
        '
        Me.ConditionBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ConditionBarButtonItem.Caption = "КРИТЕРИИ ПОИСКА"
        Me.ConditionBarButtonItem.Glyph = CType(resources.GetObject("ConditionBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ConditionBarButtonItem.GroupIndex = 2
        Me.ConditionBarButtonItem.Id = 1
        Me.ConditionBarButtonItem.Name = "ConditionBarButtonItem"
        '
        'ResultBarButtonItem
        '
        Me.ResultBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ResultBarButtonItem.Caption = "РЕЗУЛЬТАТЫ ПОИСКА"
        Me.ResultBarButtonItem.Glyph = CType(resources.GetObject("ResultBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ResultBarButtonItem.GroupIndex = 2
        Me.ResultBarButtonItem.Id = 2
        Me.ResultBarButtonItem.Name = "ResultBarButtonItem"
        '
        'ReferenceBarButtonItem
        '
        Me.ReferenceBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReferenceBarButtonItem.Caption = "СПРАВКА О ЗАКЛЮЧЕНИИ"
        Me.ReferenceBarButtonItem.Glyph = CType(resources.GetObject("ReferenceBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ReferenceBarButtonItem.GroupIndex = 2
        Me.ReferenceBarButtonItem.Id = 3
        Me.ReferenceBarButtonItem.Name = "ReferenceBarButtonItem"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "ОТЧЕТЫ"
        Me.BarSubItem1.Id = 4
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ReportOrgBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ReportSummaryBarButtonItem)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'ReportOrgBarButtonItem
        '
        Me.ReportOrgBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportOrgBarButtonItem.Caption = "ОРГАНИЗАЦИИ"
        Me.ReportOrgBarButtonItem.Description = "Отчет по экспертным организациям"
        Me.ReportOrgBarButtonItem.GroupIndex = 2
        Me.ReportOrgBarButtonItem.Id = 5
        Me.ReportOrgBarButtonItem.LargeGlyph = CType(resources.GetObject("ReportOrgBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportOrgBarButtonItem.Name = "ReportOrgBarButtonItem"
        '
        'ReportCountryBarButtonItem
        '
        Me.ReportCountryBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportCountryBarButtonItem.Caption = "СТРАНЫ"
        Me.ReportCountryBarButtonItem.Description = "Отчет по странам"
        Me.ReportCountryBarButtonItem.GroupIndex = 2
        Me.ReportCountryBarButtonItem.Id = 10
        Me.ReportCountryBarButtonItem.LargeGlyph = CType(resources.GetObject("ReportCountryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportCountryBarButtonItem.Name = "ReportCountryBarButtonItem"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(800, 37)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 400)
        Me.barDockControlBottom.Size = New System.Drawing.Size(800, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 37)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 363)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(800, 37)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 363)
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 37)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(800, 1)
        Me.SeparatorControl1.TabIndex = 4
        '
        'MainPanelControl
        '
        Me.MainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanelControl.Location = New System.Drawing.Point(0, 38)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(800, 362)
        Me.MainPanelControl.TabIndex = 5
        '
        'ReportSummaryBarButtonItem
        '
        Me.ReportSummaryBarButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.ReportSummaryBarButtonItem.Caption = "ОРГАНИЗАЦИИ, СТРАНЫ, ТОВАРЫ"
        Me.ReportSummaryBarButtonItem.Description = "Сводный отчет по экспертным организациям, странам и товарам"
        Me.ReportSummaryBarButtonItem.GroupIndex = 2
        Me.ReportSummaryBarButtonItem.Id = 11
        Me.ReportSummaryBarButtonItem.LargeGlyph = CType(resources.GetObject("ReportSummaryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportSummaryBarButtonItem.Name = "ReportSummaryBarButtonItem"
        '
        'FindUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MainPanelControl)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FindUserControl"
        Me.Size = New System.Drawing.Size(800, 400)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents ConditionBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ResultBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReferenceBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ReportOrgBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportCountryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportSummaryBarButtonItem As DevExpress.XtraBars.BarButtonItem

End Class
