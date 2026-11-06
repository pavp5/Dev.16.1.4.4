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
        Me.FileLoadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FileSaveBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.TnvedBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.InfoBarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GoodGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GoodGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.HsCodeGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TnvedCodeGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SCountGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodGridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.FileLoadBarButtonItem, Me.FileSaveBarButtonItem, Me.TnvedBarButtonItem, Me.InfoBarStaticItem})
        Me.BarManager1.MaxItemId = 7
        Me.BarManager1.StatusBar = Me.Bar2
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главная"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FileLoadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FileSaveBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.TnvedBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.MultiLine = True
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главная"
        '
        'FileLoadBarButtonItem
        '
        Me.FileLoadBarButtonItem.Caption = "Загрузить"
        Me.FileLoadBarButtonItem.Glyph = CType(resources.GetObject("FileLoadBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FileLoadBarButtonItem.Id = 0
        Me.FileLoadBarButtonItem.Name = "FileLoadBarButtonItem"
        ToolTipTitleItem1.Text = "Загрузить"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Загрузить данные из файла спецификации"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.FileLoadBarButtonItem.SuperTip = SuperToolTip1
        '
        'FileSaveBarButtonItem
        '
        Me.FileSaveBarButtonItem.Caption = "Сохранить"
        Me.FileSaveBarButtonItem.Glyph = CType(resources.GetObject("FileSaveBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FileSaveBarButtonItem.Id = 1
        Me.FileSaveBarButtonItem.Name = "FileSaveBarButtonItem"
        ToolTipTitleItem2.Text = "Сохранить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Сохранить данные в файл спецификации"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.FileSaveBarButtonItem.SuperTip = SuperToolTip2
        '
        'TnvedBarButtonItem
        '
        Me.TnvedBarButtonItem.Caption = "Определить"
        Me.TnvedBarButtonItem.Glyph = CType(resources.GetObject("TnvedBarButtonItem.Glyph"), System.Drawing.Image)
        Me.TnvedBarButtonItem.Id = 2
        Me.TnvedBarButtonItem.Name = "TnvedBarButtonItem"
        ToolTipTitleItem3.Text = "Определить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Определить коды ТН ВЭД по кодам HS"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.TnvedBarButtonItem.SuperTip = SuperToolTip3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Инфо"
        Me.Bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.InfoBarStaticItem)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Инфо"
        '
        'InfoBarStaticItem
        '
        Me.InfoBarStaticItem.Caption = "Всего: 0"
        Me.InfoBarStaticItem.Id = 6
        Me.InfoBarStaticItem.Name = "InfoBarStaticItem"
        Me.InfoBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(942, 47)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 592)
        Me.barDockControlBottom.Size = New System.Drawing.Size(942, 26)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 47)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 545)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(942, 47)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 545)
        '
        'GoodGridControl
        '
        Me.GoodGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GoodGridControl.Location = New System.Drawing.Point(0, 47)
        Me.GoodGridControl.MainView = Me.GoodGridView
        Me.GoodGridControl.MenuManager = Me.BarManager1
        Me.GoodGridControl.Name = "GoodGridControl"
        Me.GoodGridControl.Size = New System.Drawing.Size(942, 545)
        Me.GoodGridControl.TabIndex = 19
        Me.GoodGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GoodGridView})
        '
        'GoodGridView
        '
        Me.GoodGridView.Appearance.Row.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GoodGridView.Appearance.Row.Options.UseFont = True
        Me.GoodGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdGridColumn, Me.HsCodeGridColumn, Me.TnvedCodeGridColumn, Me.SCountGridColumn, Me.NameGridColumn})
        Me.GoodGridView.GridControl = Me.GoodGridControl
        Me.GoodGridView.Name = "GoodGridView"
        Me.GoodGridView.OptionsView.ShowGroupPanel = False
        '
        'IdGridColumn
        '
        Me.IdGridColumn.Caption = "id"
        Me.IdGridColumn.FieldName = "id"
        Me.IdGridColumn.Name = "IdGridColumn"
        Me.IdGridColumn.OptionsColumn.AllowEdit = False
        Me.IdGridColumn.OptionsColumn.FixedWidth = True
        Me.IdGridColumn.Visible = True
        Me.IdGridColumn.VisibleIndex = 0
        '
        'HsCodeGridColumn
        '
        Me.HsCodeGridColumn.Caption = "hs_code"
        Me.HsCodeGridColumn.FieldName = "hs_code"
        Me.HsCodeGridColumn.Name = "HsCodeGridColumn"
        Me.HsCodeGridColumn.OptionsColumn.FixedWidth = True
        Me.HsCodeGridColumn.Visible = True
        Me.HsCodeGridColumn.VisibleIndex = 1
        Me.HsCodeGridColumn.Width = 150
        '
        'TnvedCodeGridColumn
        '
        Me.TnvedCodeGridColumn.Caption = "tnved_code"
        Me.TnvedCodeGridColumn.FieldName = "tnved_code"
        Me.TnvedCodeGridColumn.Name = "TnvedCodeGridColumn"
        Me.TnvedCodeGridColumn.OptionsColumn.FixedWidth = True
        Me.TnvedCodeGridColumn.Visible = True
        Me.TnvedCodeGridColumn.VisibleIndex = 2
        Me.TnvedCodeGridColumn.Width = 150
        '
        'SCountGridColumn
        '
        Me.SCountGridColumn.Caption = "s_count"
        Me.SCountGridColumn.FieldName = "s_count"
        Me.SCountGridColumn.Name = "SCountGridColumn"
        Me.SCountGridColumn.OptionsColumn.FixedWidth = True
        Me.SCountGridColumn.Visible = True
        Me.SCountGridColumn.VisibleIndex = 3
        '
        'NameGridColumn
        '
        Me.NameGridColumn.Caption = "name"
        Me.NameGridColumn.FieldName = "name"
        Me.NameGridColumn.Name = "NameGridColumn"
        Me.NameGridColumn.Visible = True
        Me.NameGridColumn.VisibleIndex = 4
        Me.NameGridColumn.Width = 20
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 618)
        Me.Controls.Add(Me.GoodGridControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents FileLoadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FileSaveBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TnvedBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GoodGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GoodGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents HsCodeGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TnvedCodeGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SCountGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents InfoBarStaticItem As DevExpress.XtraBars.BarStaticItem
End Class
