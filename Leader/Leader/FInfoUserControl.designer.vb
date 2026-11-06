<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FInfoUserControl
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
        Me.ListGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ListGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DocNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrgNameLongGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ConNumDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RusCaptionInnGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NusCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EndCaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodTnvedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodListPosGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SummaryGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListGridControl
        '
        Me.ListGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListGridControl.Location = New System.Drawing.Point(0, 0)
        Me.ListGridControl.MainView = Me.ListGridView
        Me.ListGridControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListGridControl.Name = "ListGridControl"
        Me.ListGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.ListGridControl.Size = New System.Drawing.Size(1108, 800)
        Me.ListGridControl.TabIndex = 6
        Me.ListGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ListGridView})
        '
        'ListGridView
        '
        Me.ListGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ListGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ListGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ListGridView.Appearance.Row.Options.UseFont = True
        Me.ListGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.DocNumGridColumn, Me.DocDateGridColumn, Me.OrgNameLongGridColumn, Me.ConNumDateGridColumn, Me.RusCaptionInnGridColumn, Me.NusCaptionGridColumn, Me.EndCaptionGridColumn, Me.GoodNameGridColumn, Me.GoodTnvedGridColumn, Me.GoodListPosGridColumn, Me.SummaryGridColumn})
        Me.ListGridView.GridControl = Me.ListGridControl
        Me.ListGridView.Name = "ListGridView"
        Me.ListGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsBehavior.ReadOnly = True
        Me.ListGridView.OptionsFind.AlwaysVisible = True
        Me.ListGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ListGridView.OptionsView.ColumnAutoWidth = False
        Me.ListGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ListGridView.OptionsView.RowAutoHeight = True
        '
        'DocNumGridColumn
        '
        Me.DocNumGridColumn.Caption = "Номер заключения"
        Me.DocNumGridColumn.FieldName = "docNum"
        Me.DocNumGridColumn.Name = "DocNumGridColumn"
        Me.DocNumGridColumn.OptionsColumn.FixedWidth = True
        Me.DocNumGridColumn.Visible = True
        Me.DocNumGridColumn.VisibleIndex = 0
        Me.DocNumGridColumn.Width = 220
        '
        'DocDateGridColumn
        '
        Me.DocDateGridColumn.Caption = "Дата заключения"
        Me.DocDateGridColumn.FieldName = "docDate"
        Me.DocDateGridColumn.Name = "DocDateGridColumn"
        Me.DocDateGridColumn.OptionsColumn.FixedWidth = True
        Me.DocDateGridColumn.Visible = True
        Me.DocDateGridColumn.VisibleIndex = 1
        Me.DocDateGridColumn.Width = 120
        '
        'OrgNameLongGridColumn
        '
        Me.OrgNameLongGridColumn.Caption = "Экспертная организация"
        Me.OrgNameLongGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.OrgNameLongGridColumn.FieldName = "orgNameLong"
        Me.OrgNameLongGridColumn.Name = "OrgNameLongGridColumn"
        Me.OrgNameLongGridColumn.Visible = True
        Me.OrgNameLongGridColumn.VisibleIndex = 2
        Me.OrgNameLongGridColumn.Width = 300
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'ConNumDateGridColumn
        '
        Me.ConNumDateGridColumn.Caption = "Документ - основание"
        Me.ConNumDateGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.ConNumDateGridColumn.FieldName = "conNumDate"
        Me.ConNumDateGridColumn.Name = "ConNumDateGridColumn"
        Me.ConNumDateGridColumn.Visible = True
        Me.ConNumDateGridColumn.VisibleIndex = 3
        Me.ConNumDateGridColumn.Width = 300
        '
        'RusCaptionInnGridColumn
        '
        Me.RusCaptionInnGridColumn.Caption = "Российский участник"
        Me.RusCaptionInnGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.RusCaptionInnGridColumn.FieldName = "rusCaptionInn"
        Me.RusCaptionInnGridColumn.Name = "RusCaptionInnGridColumn"
        Me.RusCaptionInnGridColumn.Visible = True
        Me.RusCaptionInnGridColumn.VisibleIndex = 4
        Me.RusCaptionInnGridColumn.Width = 300
        '
        'NusCaptionGridColumn
        '
        Me.NusCaptionGridColumn.Caption = "Иностранный участник"
        Me.NusCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.NusCaptionGridColumn.FieldName = "nusCaption"
        Me.NusCaptionGridColumn.Name = "NusCaptionGridColumn"
        Me.NusCaptionGridColumn.Visible = True
        Me.NusCaptionGridColumn.VisibleIndex = 5
        Me.NusCaptionGridColumn.Width = 300
        '
        'EndCaptionGridColumn
        '
        Me.EndCaptionGridColumn.Caption = "Конечный пользователь"
        Me.EndCaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.EndCaptionGridColumn.FieldName = "endCaption"
        Me.EndCaptionGridColumn.Name = "EndCaptionGridColumn"
        Me.EndCaptionGridColumn.Visible = True
        Me.EndCaptionGridColumn.VisibleIndex = 6
        Me.EndCaptionGridColumn.Width = 300
        '
        'GoodNameGridColumn
        '
        Me.GoodNameGridColumn.Caption = "Товар"
        Me.GoodNameGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GoodNameGridColumn.FieldName = "goodName"
        Me.GoodNameGridColumn.Name = "GoodNameGridColumn"
        Me.GoodNameGridColumn.Visible = True
        Me.GoodNameGridColumn.VisibleIndex = 7
        Me.GoodNameGridColumn.Width = 300
        '
        'GoodTnvedGridColumn
        '
        Me.GoodTnvedGridColumn.Caption = "Код ТНВЭД"
        Me.GoodTnvedGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GoodTnvedGridColumn.FieldName = "goodTnved"
        Me.GoodTnvedGridColumn.Name = "GoodTnvedGridColumn"
        Me.GoodTnvedGridColumn.Visible = True
        Me.GoodTnvedGridColumn.VisibleIndex = 8
        Me.GoodTnvedGridColumn.Width = 110
        '
        'GoodListPosGridColumn
        '
        Me.GoodListPosGridColumn.Caption = "Пункты списков"
        Me.GoodListPosGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.GoodListPosGridColumn.FieldName = "goodListPos"
        Me.GoodListPosGridColumn.Name = "GoodListPosGridColumn"
        Me.GoodListPosGridColumn.Visible = True
        Me.GoodListPosGridColumn.VisibleIndex = 9
        Me.GoodListPosGridColumn.Width = 300
        '
        'SummaryGridColumn
        '
        Me.SummaryGridColumn.Caption = "Выводы экспертизы"
        Me.SummaryGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.SummaryGridColumn.FieldName = "summary"
        Me.SummaryGridColumn.Name = "SummaryGridColumn"
        Me.SummaryGridColumn.Visible = True
        Me.SummaryGridColumn.VisibleIndex = 10
        Me.SummaryGridColumn.Width = 300
        '
        'FInfoUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListGridControl)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FInfoUserControl"
        Me.Size = New System.Drawing.Size(1108, 800)
        CType(Me.ListGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ListGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DocNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents OrgNameLongGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ConNumDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RusCaptionInnGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NusCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EndCaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodTnvedGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodListPosGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SummaryGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn

End Class
