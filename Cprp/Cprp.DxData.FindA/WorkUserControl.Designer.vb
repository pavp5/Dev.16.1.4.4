<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.MainNavigationFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.RefNavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.W = New System.Windows.Forms.WebBrowser()
        Me.Doc1NavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.R1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.RefBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.Doc1BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.Doc2BarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.PrintBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SaveBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.UploadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Doc2NavigationPage = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.R2 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MainNavigationFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainNavigationFrame.SuspendLayout()
        Me.RefNavigationPage.SuspendLayout()
        Me.Doc1NavigationPage.SuspendLayout()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Doc2NavigationPage.SuspendLayout()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.MainNavigationFrame)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 469, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 700)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'MainNavigationFrame
        '
        Me.MainNavigationFrame.Controls.Add(Me.RefNavigationPage)
        Me.MainNavigationFrame.Controls.Add(Me.Doc1NavigationPage)
        Me.MainNavigationFrame.Controls.Add(Me.Doc2NavigationPage)
        Me.MainNavigationFrame.Location = New System.Drawing.Point(12, 93)
        Me.MainNavigationFrame.Name = "MainNavigationFrame"
        Me.MainNavigationFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.RefNavigationPage, Me.Doc1NavigationPage, Me.Doc2NavigationPage})
        Me.MainNavigationFrame.SelectedPage = Me.RefNavigationPage
        Me.MainNavigationFrame.Size = New System.Drawing.Size(926, 595)
        Me.MainNavigationFrame.TabIndex = 13
        Me.MainNavigationFrame.Text = "NavigationFrame1"
        '
        'RefNavigationPage
        '
        Me.RefNavigationPage.Controls.Add(Me.W)
        Me.RefNavigationPage.Name = "RefNavigationPage"
        Me.RefNavigationPage.Size = New System.Drawing.Size(926, 595)
        '
        'W
        '
        Me.W.Dock = System.Windows.Forms.DockStyle.Fill
        Me.W.Location = New System.Drawing.Point(0, 0)
        Me.W.MinimumSize = New System.Drawing.Size(20, 20)
        Me.W.Name = "W"
        Me.W.Size = New System.Drawing.Size(926, 595)
        Me.W.TabIndex = 1
        '
        'Doc1NavigationPage
        '
        Me.Doc1NavigationPage.Controls.Add(Me.R1)
        Me.Doc1NavigationPage.Name = "Doc1NavigationPage"
        Me.Doc1NavigationPage.Size = New System.Drawing.Size(926, 595)
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
        Me.R1.Size = New System.Drawing.Size(926, 595)
        Me.R1.TabIndex = 24
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RefBarCheckItem, Me.Doc1BarCheckItem, Me.Doc2BarCheckItem, Me.PrintBarButtonItem, Me.SaveBarButtonItem, Me.UploadBarButtonItem})
        Me.BarManager1.MaxItemId = 6
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(72, 167)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.RefBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.Doc1BarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.Doc2BarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.PrintBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.SaveBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.UploadBarButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'RefBarCheckItem
        '
        Me.RefBarCheckItem.Caption = "СОДЕРЖАНИЕ"
        Me.RefBarCheckItem.Glyph = CType(resources.GetObject("RefBarCheckItem.Glyph"), System.Drawing.Image)
        Me.RefBarCheckItem.GroupIndex = 1
        Me.RefBarCheckItem.Id = 0
        Me.RefBarCheckItem.Name = "RefBarCheckItem"
        '
        'Doc1BarCheckItem
        '
        Me.Doc1BarCheckItem.Caption = "ЗАКЛЮЧЕНИЕ #1"
        Me.Doc1BarCheckItem.Glyph = CType(resources.GetObject("Doc1BarCheckItem.Glyph"), System.Drawing.Image)
        Me.Doc1BarCheckItem.GroupIndex = 1
        Me.Doc1BarCheckItem.Id = 1
        Me.Doc1BarCheckItem.Name = "Doc1BarCheckItem"
        '
        'Doc2BarCheckItem
        '
        Me.Doc2BarCheckItem.Caption = "ЗАКЛЮЧЕНИЕ #2"
        Me.Doc2BarCheckItem.Glyph = CType(resources.GetObject("Doc2BarCheckItem.Glyph"), System.Drawing.Image)
        Me.Doc2BarCheckItem.GroupIndex = 1
        Me.Doc2BarCheckItem.Id = 2
        Me.Doc2BarCheckItem.Name = "Doc2BarCheckItem"
        '
        'PrintBarButtonItem
        '
        Me.PrintBarButtonItem.Caption = "Печать"
        Me.PrintBarButtonItem.Glyph = CType(resources.GetObject("PrintBarButtonItem.Glyph"), System.Drawing.Image)
        Me.PrintBarButtonItem.Id = 3
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
        Me.SaveBarButtonItem.Id = 4
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
        Me.UploadBarButtonItem.Id = 5
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
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 51)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
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
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 700)
        Me.barDockControlBottom.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 700)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 700)
        '
        'Doc2NavigationPage
        '
        Me.Doc2NavigationPage.Controls.Add(Me.R2)
        Me.Doc2NavigationPage.Name = "Doc2NavigationPage"
        Me.Doc2NavigationPage.Size = New System.Drawing.Size(926, 595)
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
        Me.R2.Size = New System.Drawing.Size(926, 595)
        Me.R2.TabIndex = 25
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem1, Me.CaptionSimpleLabelItem, Me.SimpleSeparator1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 700)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.MainNavigationFrame
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 81)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(930, 599)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 39)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 39)
        Me.CaptionSimpleLabelItem.Text = "Поиск работ > Сведения о работе"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(343, 29)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 80)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
        '
        'WorkUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "WorkUserControl"
        Me.Size = New System.Drawing.Size(950, 700)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MainNavigationFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainNavigationFrame.ResumeLayout(False)
        Me.RefNavigationPage.ResumeLayout(False)
        Me.Doc1NavigationPage.ResumeLayout(False)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Doc2NavigationPage.ResumeLayout(False)
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents MainNavigationFrame As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents RefNavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents W As System.Windows.Forms.WebBrowser
    Friend WithEvents Doc1NavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents R1 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents Doc2NavigationPage As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents R2 As DevExpress.XtraRichEdit.RichEditControl
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RefBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents Doc1BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents Doc2BarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents PrintBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SaveBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UploadBarButtonItem As DevExpress.XtraBars.BarButtonItem

End Class
