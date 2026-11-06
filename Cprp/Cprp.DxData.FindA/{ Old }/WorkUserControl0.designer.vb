<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkUserControl0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkUserControl0))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.RefBarLargeButtonItem = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.Doc1BarLargeButtonItem = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.Doc2BarLargeButtonItem = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.PrintBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SaveBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.UploadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.MainNavigationFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.RefNavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.W = New System.Windows.Forms.WebBrowser()
        Me.Doc1NavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.R1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.Doc2NavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.R2 = New DevExpress.XtraRichEdit.RichEditControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainNavigationFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainNavigationFrame.SuspendLayout()
        Me.RefNavigationPage.SuspendLayout()
        Me.Doc1NavigationPage.SuspendLayout()
        Me.Doc2NavigationPage.SuspendLayout()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RefBarLargeButtonItem, Me.Doc1BarLargeButtonItem, Me.Doc2BarLargeButtonItem, Me.PrintBarButtonItem, Me.SaveBarButtonItem, Me.UploadBarButtonItem})
        Me.BarManager1.MaxItemId = 8
        '
        'Bar1
        '
        Me.Bar1.BarItemVertIndent = 10
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Left
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.RefBarLargeButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.Doc1BarLargeButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.Doc2BarLargeButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.RotateWhenVertical = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'RefBarLargeButtonItem
        '
        Me.RefBarLargeButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.RefBarLargeButtonItem.Caption = "СОДЕРЖАНИЕ"
        Me.RefBarLargeButtonItem.GroupIndex = 2
        Me.RefBarLargeButtonItem.Id = 0
        Me.RefBarLargeButtonItem.LargeGlyph = CType(resources.GetObject("RefBarLargeButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.RefBarLargeButtonItem.Name = "RefBarLargeButtonItem"
        '
        'Doc1BarLargeButtonItem
        '
        Me.Doc1BarLargeButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Doc1BarLargeButtonItem.Caption = "ЗАКЛЮЧЕНИЕ #1"
        Me.Doc1BarLargeButtonItem.GroupIndex = 2
        Me.Doc1BarLargeButtonItem.Id = 3
        Me.Doc1BarLargeButtonItem.LargeGlyph = CType(resources.GetObject("Doc1BarLargeButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.Doc1BarLargeButtonItem.Name = "Doc1BarLargeButtonItem"
        '
        'Doc2BarLargeButtonItem
        '
        Me.Doc2BarLargeButtonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        Me.Doc2BarLargeButtonItem.Caption = "ЗАКЛЮЧЕНИЕ #2"
        Me.Doc2BarLargeButtonItem.GroupIndex = 2
        Me.Doc2BarLargeButtonItem.Id = 4
        Me.Doc2BarLargeButtonItem.LargeGlyph = CType(resources.GetObject("Doc2BarLargeButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.Doc2BarLargeButtonItem.Name = "Doc2BarLargeButtonItem"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Сервис"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(186, 167)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.PrintBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.SaveBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.UploadBarButtonItem, True)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar2.Text = "Сервис"
        '
        'PrintBarButtonItem
        '
        Me.PrintBarButtonItem.Caption = "Печать"
        Me.PrintBarButtonItem.Glyph = CType(resources.GetObject("PrintBarButtonItem.Glyph"), System.Drawing.Image)
        Me.PrintBarButtonItem.Id = 5
        Me.PrintBarButtonItem.Name = "PrintBarButtonItem"
        ToolTipTitleItem1.Text = "Печать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Печать документа"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.PrintBarButtonItem.SuperTip = SuperToolTip1
        '
        'SaveBarButtonItem
        '
        Me.SaveBarButtonItem.Caption = "Сохранить"
        Me.SaveBarButtonItem.Glyph = CType(resources.GetObject("SaveBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SaveBarButtonItem.Id = 6
        Me.SaveBarButtonItem.Name = "SaveBarButtonItem"
        ToolTipTitleItem2.Text = "Сохранить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Сохранить документ"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.SaveBarButtonItem.SuperTip = SuperToolTip2
        '
        'UploadBarButtonItem
        '
        Me.UploadBarButtonItem.Caption = "Выгрузить"
        Me.UploadBarButtonItem.Glyph = CType(resources.GetObject("UploadBarButtonItem.Glyph"), System.Drawing.Image)
        Me.UploadBarButtonItem.Id = 7
        Me.UploadBarButtonItem.Name = "UploadBarButtonItem"
        ToolTipTitleItem3.Text = "Выгрузить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Создать загрузочную таблицу с данными работы"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.UploadBarButtonItem.SuperTip = SuperToolTip3
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.AutoSize = True
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(101, 0)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(849, 37)
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
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 450)
        Me.barDockControlBottom.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(100, 450)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 450)
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl1.Location = New System.Drawing.Point(100, 0)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(1, 450)
        Me.SeparatorControl1.TabIndex = 4
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl2.Location = New System.Drawing.Point(101, 37)
        Me.SeparatorControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl2.Size = New System.Drawing.Size(849, 1)
        Me.SeparatorControl2.TabIndex = 10
        '
        'MainNavigationFrame
        '
        Me.MainNavigationFrame.Controls.Add(Me.RefNavigationPage)
        Me.MainNavigationFrame.Controls.Add(Me.Doc1NavigationPage)
        Me.MainNavigationFrame.Controls.Add(Me.Doc2NavigationPage)
        Me.MainNavigationFrame.Location = New System.Drawing.Point(101, 38)
        Me.MainNavigationFrame.Name = "MainNavigationFrame"
        Me.MainNavigationFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.RefNavigationPage, Me.Doc1NavigationPage, Me.Doc2NavigationPage})
        Me.MainNavigationFrame.SelectedPage = Me.RefNavigationPage
        Me.MainNavigationFrame.Size = New System.Drawing.Size(849, 338)
        Me.MainNavigationFrame.TabIndex = 12
        Me.MainNavigationFrame.Text = "NavigationFrame1"
        '
        'RefNavigationPage
        '
        Me.RefNavigationPage.Controls.Add(Me.W)
        Me.RefNavigationPage.Name = "RefNavigationPage"
        Me.RefNavigationPage.Size = New System.Drawing.Size(849, 338)
        '
        'W
        '
        Me.W.Dock = System.Windows.Forms.DockStyle.Fill
        Me.W.Location = New System.Drawing.Point(0, 0)
        Me.W.MinimumSize = New System.Drawing.Size(20, 20)
        Me.W.Name = "W"
        Me.W.Size = New System.Drawing.Size(849, 338)
        Me.W.TabIndex = 1
        '
        'Doc1NavigationPage
        '
        Me.Doc1NavigationPage.Controls.Add(Me.R1)
        Me.Doc1NavigationPage.Name = "Doc1NavigationPage"
        Me.Doc1NavigationPage.Size = New System.Drawing.Size(849, 338)
        '
        'R1
        '
        Me.R1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.R1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.R1.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        Me.R1.Location = New System.Drawing.Point(0, 0)
        Me.R1.MenuManager = Me.BarManager1
        Me.R1.Name = "R1"
        Me.R1.ReadOnly = True
        Me.R1.Size = New System.Drawing.Size(849, 338)
        Me.R1.TabIndex = 24
        '
        'Doc2NavigationPage
        '
        Me.Doc2NavigationPage.Controls.Add(Me.R2)
        Me.Doc2NavigationPage.Name = "Doc2NavigationPage"
        Me.Doc2NavigationPage.Size = New System.Drawing.Size(849, 338)
        '
        'R2
        '
        Me.R2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.R2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.R2.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        Me.R2.Location = New System.Drawing.Point(0, 0)
        Me.R2.MenuManager = Me.BarManager1
        Me.R2.Name = "R2"
        Me.R2.ReadOnly = True
        Me.R2.Size = New System.Drawing.Size(849, 338)
        Me.R2.TabIndex = 25
        '
        'WorkUserControl0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MainNavigationFrame)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Controls.Add(Me.StandaloneBarDockControl1)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "WorkUserControl0"
        Me.Size = New System.Drawing.Size(950, 450)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainNavigationFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainNavigationFrame.ResumeLayout(False)
        Me.RefNavigationPage.ResumeLayout(False)
        Me.Doc1NavigationPage.ResumeLayout(False)
        Me.Doc2NavigationPage.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents RefBarLargeButtonItem As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Doc1BarLargeButtonItem As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents Doc2BarLargeButtonItem As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents PrintBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UploadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents MainNavigationFrame As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents RefNavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents W As System.Windows.Forms.WebBrowser
    Friend WithEvents Doc1NavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents R1 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents Doc2NavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents R2 As DevExpress.XtraRichEdit.RichEditControl

End Class
