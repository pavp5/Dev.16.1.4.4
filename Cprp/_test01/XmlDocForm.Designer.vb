<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XmlDocForm
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.LoadBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.DocGridControl = New DevExpress.XtraGrid.GridControl()
        Me.DocGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocNameDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocNumDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocDateDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.LoadBarButtonItem, Me.OpenBarButtonItem})
        Me.BarManager1.MaxItemId = 5
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemSpinEdit2})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главная"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.LoadBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.OpenBarButtonItem)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главная"
        '
        'LoadBarButtonItem
        '
        Me.LoadBarButtonItem.Caption = "Загрузить"
        Me.LoadBarButtonItem.Id = 2
        Me.LoadBarButtonItem.Name = "LoadBarButtonItem"
        ToolTipTitleItem1.Text = "Загрузить"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Загрузить данные из базы"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.LoadBarButtonItem.SuperTip = SuperToolTip1
        '
        'OpenBarButtonItem
        '
        Me.OpenBarButtonItem.Caption = "Открыть"
        Me.OpenBarButtonItem.Id = 4
        Me.OpenBarButtonItem.Name = "OpenBarButtonItem"
        ToolTipTitleItem2.Text = "Открыть"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Открыть файл с данными"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.OpenBarButtonItem.SuperTip = SuperToolTip2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(942, 32)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 618)
        Me.barDockControlBottom.Size = New System.Drawing.Size(942, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 32)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 586)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(942, 32)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 586)
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'DocGridControl
        '
        Me.DocGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocGridControl.Location = New System.Drawing.Point(0, 32)
        Me.DocGridControl.MainView = Me.DocGridView
        Me.DocGridControl.MenuManager = Me.BarManager1
        Me.DocGridControl.Name = "DocGridControl"
        Me.DocGridControl.Size = New System.Drawing.Size(942, 586)
        Me.DocGridControl.TabIndex = 4
        Me.DocGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DocGridView})
        '
        'DocGridView
        '
        Me.DocGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdDocGridColumn, Me.DocNameDocGridColumn, Me.DocNumDocGridColumn, Me.DocDateDocGridColumn})
        Me.DocGridView.GridControl = Me.DocGridControl
        Me.DocGridView.Name = "DocGridView"
        Me.DocGridView.OptionsBehavior.ReadOnly = True
        '
        'IdDocGridColumn
        '
        Me.IdDocGridColumn.Caption = "id"
        Me.IdDocGridColumn.FieldName = "id"
        Me.IdDocGridColumn.Name = "IdDocGridColumn"
        Me.IdDocGridColumn.OptionsColumn.FixedWidth = True
        Me.IdDocGridColumn.Visible = True
        Me.IdDocGridColumn.VisibleIndex = 0
        Me.IdDocGridColumn.Width = 90
        '
        'DocNameDocGridColumn
        '
        Me.DocNameDocGridColumn.Caption = "doc_name"
        Me.DocNameDocGridColumn.FieldName = "doc_name"
        Me.DocNameDocGridColumn.Name = "DocNameDocGridColumn"
        Me.DocNameDocGridColumn.Visible = True
        Me.DocNameDocGridColumn.VisibleIndex = 1
        Me.DocNameDocGridColumn.Width = 275
        '
        'DocNumDocGridColumn
        '
        Me.DocNumDocGridColumn.Caption = "doc_num"
        Me.DocNumDocGridColumn.FieldName = "doc_num"
        Me.DocNumDocGridColumn.Name = "DocNumDocGridColumn"
        Me.DocNumDocGridColumn.Visible = True
        Me.DocNumDocGridColumn.VisibleIndex = 2
        Me.DocNumDocGridColumn.Width = 275
        '
        'DocDateDocGridColumn
        '
        Me.DocDateDocGridColumn.Caption = "doc_date"
        Me.DocDateDocGridColumn.FieldName = "doc_date"
        Me.DocDateDocGridColumn.Name = "DocDateDocGridColumn"
        Me.DocDateDocGridColumn.Visible = True
        Me.DocDateDocGridColumn.VisibleIndex = 3
        Me.DocDateDocGridColumn.Width = 277
        '
        'XmlDocForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 618)
        Me.Controls.Add(Me.DocGridControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "XmlDocForm"
        Me.Text = "XmlDocForm"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents LoadBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OpenBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents DocGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents DocGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IdDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocNameDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocNumDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocDateDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
