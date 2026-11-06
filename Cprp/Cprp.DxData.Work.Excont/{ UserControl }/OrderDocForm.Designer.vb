<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderDocForm
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
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.FileNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DockManager1
        '
        Me.DockManager1.DockingOptions.FloatOnDblClick = False
        Me.DockManager1.DockingOptions.ShowCloseButton = False
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("070e8d3c-a564-4341-89c2-cb21bd5b1190")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.AllowFloating = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(300, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(300, 614)
        Me.DockPanel1.Text = "Документы"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.ListGridControl)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(5, 27)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(288, 582)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'ListGridControl
        '
        Me.ListGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListGridControl.Location = New System.Drawing.Point(0, 0)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.Size = New System.Drawing.Size(288, 582)
        Me.ListGridControl.TabIndex = 1
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FileNameGridColumn})
        Me.ListGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ListGridView.GridControl = Me.ListGridControl
        Me.ListGridView.Name = "ListGridView"
        Me.ListGridView.OptionsBehavior.Editable = False
        Me.ListGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ListGridView.OptionsView.ShowColumnHeaders = False
        Me.ListGridView.OptionsView.ShowGroupPanel = False
        Me.ListGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ListGridView.OptionsView.ShowIndicator = False
        Me.ListGridView.OptionsView.ShowPreview = True
        Me.ListGridView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ListGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.ListGridView.PreviewFieldName = "Title"
        Me.ListGridView.RowSeparatorHeight = 5
        '
        'FileNameGridColumn
        '
        Me.FileNameGridColumn.Caption = "FileName"
        Me.FileNameGridColumn.FieldName = "FileName"
        Me.FileNameGridColumn.Name = "FileNameGridColumn"
        Me.FileNameGridColumn.Visible = True
        Me.FileNameGridColumn.VisibleIndex = 0
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(300, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(648, 614)
        Me.WebBrowser1.TabIndex = 3
        '
        'OrderDocForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 614)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "OrderDocForm"
        Me.Text = "OrderDocForm"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents ListGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ListGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents FileNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
