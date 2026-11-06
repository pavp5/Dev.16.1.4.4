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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.PlaneBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.ClosedBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.CalcBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.DeptBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.ReportExpertKtuBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.ReportFinfoBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        Me.DefaultBarAndDockingController1 = New DevExpress.XtraBars.DefaultBarAndDockingController(Me.components)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.PlaneBarCheckItem, Me.ClosedBarCheckItem, Me.CalcBarCheckItem, Me.DeptBarCheckItem, Me.BarSubItem1, Me.ReportExpertKtuBarCheckItem, Me.ReportFinfoBarButtonItem})
        Me.BarManager1.MaxItemId = 7
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PlaneBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ClosedBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.CalcBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DeptBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1, True)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.MultiLine = True
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'PlaneBarCheckItem
        '
        Me.PlaneBarCheckItem.Caption = "ПЛАН РАБОТ"
        Me.PlaneBarCheckItem.GroupIndex = 1
        Me.PlaneBarCheckItem.Id = 0
        Me.PlaneBarCheckItem.Name = "PlaneBarCheckItem"
        ToolTipTitleItem1.Text = "План работ"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Открыть план работ"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.PlaneBarCheckItem.SuperTip = SuperToolTip1
        '
        'ClosedBarCheckItem
        '
        Me.ClosedBarCheckItem.Caption = "ЗАКРЫТЫЕ РАБОТЫ"
        Me.ClosedBarCheckItem.GroupIndex = 1
        Me.ClosedBarCheckItem.Id = 1
        Me.ClosedBarCheckItem.Name = "ClosedBarCheckItem"
        ToolTipTitleItem2.Text = "Закрытые работы"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Открыть список закрытых работ"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ClosedBarCheckItem.SuperTip = SuperToolTip2
        '
        'CalcBarCheckItem
        '
        Me.CalcBarCheckItem.Caption = "РАСЧЕТЫ"
        Me.CalcBarCheckItem.GroupIndex = 1
        Me.CalcBarCheckItem.Id = 2
        Me.CalcBarCheckItem.Name = "CalcBarCheckItem"
        ToolTipTitleItem3.Text = "Расчеты"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Открыть список расчетов стоимостей заказов"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.CalcBarCheckItem.SuperTip = SuperToolTip3
        '
        'DeptBarCheckItem
        '
        Me.DeptBarCheckItem.Caption = "СОГЛАСОВАНИЯ"
        Me.DeptBarCheckItem.GroupIndex = 1
        Me.DeptBarCheckItem.Id = 3
        Me.DeptBarCheckItem.Name = "DeptBarCheckItem"
        ToolTipTitleItem4.Text = "Согласования"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Открыть список согласований стоимостей заказов"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.DeptBarCheckItem.SuperTip = SuperToolTip4
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Отчеты"
        Me.BarSubItem1.Id = 4
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ReportExpertKtuBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ReportFinfoBarButtonItem)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'ReportExpertKtuBarCheckItem
        '
        Me.ReportExpertKtuBarCheckItem.Caption = "КТУ экспертов"
        Me.ReportExpertKtuBarCheckItem.Description = "КТУ экспертов за период"
        Me.ReportExpertKtuBarCheckItem.GroupIndex = 1
        Me.ReportExpertKtuBarCheckItem.Id = 5
        Me.ReportExpertKtuBarCheckItem.LargeGlyph = CType(resources.GetObject("ReportExpertKtuBarCheckItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportExpertKtuBarCheckItem.Name = "ReportExpertKtuBarCheckItem"
        '
        'ReportFinfoBarButtonItem
        '
        Me.ReportFinfoBarButtonItem.Caption = "Экспертные организации"
        Me.ReportFinfoBarButtonItem.Description = "Заключения разных экспертных организаций"
        Me.ReportFinfoBarButtonItem.Id = 6
        Me.ReportFinfoBarButtonItem.LargeGlyph = Global.Manager.My.Resources.Resources.department_32
        Me.ReportFinfoBarButtonItem.Name = "ReportFinfoBarButtonItem"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(691, 34)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 336)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(691, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 34)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 302)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(691, 34)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 302)
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 34)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(691, 1)
        Me.SeparatorControl1.TabIndex = 4
        '
        'MainPanelControl
        '
        Me.MainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanelControl.Location = New System.Drawing.Point(0, 35)
        Me.MainPanelControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(691, 301)
        Me.MainPanelControl.TabIndex = 5
        '
        'DefaultBarAndDockingController1
        '
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultGlyphSize = New System.Drawing.Size(16, 16)
        Me.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultLargeGlyphSize = New System.Drawing.Size(32, 32)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 336)
        Me.Controls.Add(Me.MainPanelControl)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents PlaneBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents ClosedBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents CalcBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents DeptBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents DefaultBarAndDockingController1 As DevExpress.XtraBars.DefaultBarAndDockingController
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents ReportExpertKtuBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents ReportFinfoBarButtonItem As DevExpress.XtraBars.BarButtonItem
End Class
