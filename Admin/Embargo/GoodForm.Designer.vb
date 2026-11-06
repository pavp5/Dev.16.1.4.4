<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoodForm
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsActGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GoodGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EmbargoIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ModeIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GoodGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsActGridColumn
        '
        Me.IsActGridColumn.Caption = "isACT"
        Me.IsActGridColumn.FieldName = "isACT"
        Me.IsActGridColumn.Name = "IsActGridColumn"
        Me.IsActGridColumn.OptionsColumn.FixedWidth = True
        Me.IsActGridColumn.Visible = True
        Me.IsActGridColumn.VisibleIndex = 4
        Me.IsActGridColumn.Width = 60
        '
        'GoodGridControl
        '
        Me.GoodGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GoodGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GoodGridControl.Location = New System.Drawing.Point(0, 0)
        Me.GoodGridControl.MainView = Me.GoodGridView
        Me.GoodGridControl.Name = "GoodGridControl"
        Me.GoodGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.GoodGridControl.Size = New System.Drawing.Size(813, 499)
        Me.GoodGridControl.TabIndex = 5
        Me.GoodGridControl.UseEmbeddedNavigator = True
        Me.GoodGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GoodGridView})
        '
        'GoodGridView
        '
        Me.GoodGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GoodGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GoodGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GoodGridView.Appearance.Row.Options.UseFont = True
        Me.GoodGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdGridColumn, Me.EmbargoIdGridColumn, Me.CaptionGridColumn, Me.ModeIdGridColumn, Me.IsActGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsActGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = False
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GoodGridView.FormatRules.Add(GridFormatRule1)
        Me.GoodGridView.GridControl = Me.GoodGridControl
        Me.GoodGridView.Name = "GoodGridView"
        Me.GoodGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.GoodGridView.OptionsDetail.EnableMasterViewMode = False
        Me.GoodGridView.OptionsView.RowAutoHeight = True
        Me.GoodGridView.OptionsView.ShowGroupPanel = False
        Me.GoodGridView.RowHeight = 25
        '
        'IdGridColumn
        '
        Me.IdGridColumn.Caption = "id"
        Me.IdGridColumn.FieldName = "id"
        Me.IdGridColumn.Name = "IdGridColumn"
        Me.IdGridColumn.OptionsColumn.FixedWidth = True
        Me.IdGridColumn.Visible = True
        Me.IdGridColumn.VisibleIndex = 0
        Me.IdGridColumn.Width = 60
        '
        'EmbargoIdGridColumn
        '
        Me.EmbargoIdGridColumn.Caption = "embargoId"
        Me.EmbargoIdGridColumn.FieldName = "embargoId"
        Me.EmbargoIdGridColumn.Name = "EmbargoIdGridColumn"
        Me.EmbargoIdGridColumn.OptionsColumn.FixedWidth = True
        Me.EmbargoIdGridColumn.Visible = True
        Me.EmbargoIdGridColumn.VisibleIndex = 1
        Me.EmbargoIdGridColumn.Width = 60
        '
        'CaptionGridColumn
        '
        Me.CaptionGridColumn.Caption = "caption"
        Me.CaptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.CaptionGridColumn.FieldName = "caption"
        Me.CaptionGridColumn.Name = "CaptionGridColumn"
        Me.CaptionGridColumn.Visible = True
        Me.CaptionGridColumn.VisibleIndex = 2
        Me.CaptionGridColumn.Width = 509
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'ModeIdGridColumn
        '
        Me.ModeIdGridColumn.Caption = "modeId"
        Me.ModeIdGridColumn.FieldName = "modeId"
        Me.ModeIdGridColumn.Name = "ModeIdGridColumn"
        Me.ModeIdGridColumn.OptionsColumn.FixedWidth = True
        Me.ModeIdGridColumn.Visible = True
        Me.ModeIdGridColumn.VisibleIndex = 3
        Me.ModeIdGridColumn.Width = 60
        '
        'GoodForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 499)
        Me.Controls.Add(Me.GoodGridControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "GoodForm"
        Me.Text = "GoodForm"
        CType(Me.GoodGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GoodGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GoodGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmbargoIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents IsActGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ModeIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
