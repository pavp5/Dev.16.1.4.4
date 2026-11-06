<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemberForm
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
        Me.MemberGridControl = New DevExpress.XtraGrid.GridControl()
        Me.MemberGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EmbargoIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CaptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.DescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CoountryIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CountryRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ModeIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.MemberGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemberGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsActGridColumn
        '
        Me.IsActGridColumn.Caption = "isACT"
        Me.IsActGridColumn.FieldName = "isACT"
        Me.IsActGridColumn.Name = "IsActGridColumn"
        Me.IsActGridColumn.OptionsColumn.FixedWidth = True
        Me.IsActGridColumn.Visible = True
        Me.IsActGridColumn.VisibleIndex = 6
        Me.IsActGridColumn.Width = 60
        '
        'MemberGridControl
        '
        Me.MemberGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemberGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MemberGridControl.Location = New System.Drawing.Point(0, 0)
        Me.MemberGridControl.MainView = Me.MemberGridView
        Me.MemberGridControl.Name = "MemberGridControl"
        Me.MemberGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.CountryRepositoryItemLookUpEdit})
        Me.MemberGridControl.Size = New System.Drawing.Size(813, 499)
        Me.MemberGridControl.TabIndex = 4
        Me.MemberGridControl.UseEmbeddedNavigator = True
        Me.MemberGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MemberGridView})
        '
        'MemberGridView
        '
        Me.MemberGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.MemberGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.MemberGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MemberGridView.Appearance.Row.Options.UseFont = True
        Me.MemberGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdGridColumn, Me.EmbargoIdGridColumn, Me.CaptionGridColumn, Me.DescriptionGridColumn, Me.CoountryIdGridColumn, Me.ModeIdGridColumn, Me.IsActGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsActGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = False
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.MemberGridView.FormatRules.Add(GridFormatRule1)
        Me.MemberGridView.GridControl = Me.MemberGridControl
        Me.MemberGridView.Name = "MemberGridView"
        Me.MemberGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.MemberGridView.OptionsDetail.EnableMasterViewMode = False
        Me.MemberGridView.OptionsView.RowAutoHeight = True
        Me.MemberGridView.OptionsView.ShowGroupPanel = False
        Me.MemberGridView.RowHeight = 25
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
        Me.CaptionGridColumn.Width = 124
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'DescriptionGridColumn
        '
        Me.DescriptionGridColumn.Caption = "description"
        Me.DescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.DescriptionGridColumn.FieldName = "description"
        Me.DescriptionGridColumn.Name = "DescriptionGridColumn"
        Me.DescriptionGridColumn.Visible = True
        Me.DescriptionGridColumn.VisibleIndex = 3
        Me.DescriptionGridColumn.Width = 124
        '
        'CoountryIdGridColumn
        '
        Me.CoountryIdGridColumn.Caption = "countryId"
        Me.CoountryIdGridColumn.ColumnEdit = Me.CountryRepositoryItemLookUpEdit
        Me.CoountryIdGridColumn.FieldName = "countryId"
        Me.CoountryIdGridColumn.Name = "CoountryIdGridColumn"
        Me.CoountryIdGridColumn.OptionsColumn.FixedWidth = True
        Me.CoountryIdGridColumn.Visible = True
        Me.CoountryIdGridColumn.VisibleIndex = 4
        Me.CoountryIdGridColumn.Width = 240
        '
        'CountryRepositoryItemLookUpEdit
        '
        Me.CountryRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.CountryRepositoryItemLookUpEdit.AutoHeight = False
        Me.CountryRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CountryRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.CountryRepositoryItemLookUpEdit.DisplayMember = "nameShort"
        Me.CountryRepositoryItemLookUpEdit.Name = "CountryRepositoryItemLookUpEdit"
        Me.CountryRepositoryItemLookUpEdit.NullText = ""
        Me.CountryRepositoryItemLookUpEdit.ShowFooter = False
        Me.CountryRepositoryItemLookUpEdit.ShowHeader = False
        Me.CountryRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CountryRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'ModeIdGridColumn
        '
        Me.ModeIdGridColumn.Caption = "modeId"
        Me.ModeIdGridColumn.FieldName = "modeId"
        Me.ModeIdGridColumn.Name = "ModeIdGridColumn"
        Me.ModeIdGridColumn.OptionsColumn.FixedWidth = True
        Me.ModeIdGridColumn.Visible = True
        Me.ModeIdGridColumn.VisibleIndex = 5
        Me.ModeIdGridColumn.Width = 60
        '
        'MemberForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 499)
        Me.Controls.Add(Me.MemberGridControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "MemberForm"
        Me.ShowInTaskbar = False
        Me.Text = "MemberForm"
        CType(Me.MemberGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemberGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MemberGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents MemberGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CaptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents DescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsActGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmbargoIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CoountryIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CountryRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ModeIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
