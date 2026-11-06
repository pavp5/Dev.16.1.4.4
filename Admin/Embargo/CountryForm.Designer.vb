<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CountryForm
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
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsActGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CountryGridControl = New DevExpress.XtraGrid.GridControl()
        Me.CountryGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameShortGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ModeIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.CountryGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsActGridColumn
        '
        Me.IsActGridColumn.Caption = "isACT"
        Me.IsActGridColumn.FieldName = "isACT"
        Me.IsActGridColumn.Name = "IsActGridColumn"
        '
        'IsCheckGridColumn
        '
        Me.IsCheckGridColumn.Caption = "isCheck"
        Me.IsCheckGridColumn.FieldName = "isCheck"
        Me.IsCheckGridColumn.Name = "IsCheckGridColumn"
        Me.IsCheckGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckGridColumn.Visible = True
        Me.IsCheckGridColumn.VisibleIndex = 0
        Me.IsCheckGridColumn.Width = 60
        '
        'CountryGridControl
        '
        Me.CountryGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CountryGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CountryGridControl.Location = New System.Drawing.Point(0, 0)
        Me.CountryGridControl.MainView = Me.CountryGridView
        Me.CountryGridControl.Name = "CountryGridControl"
        Me.CountryGridControl.Size = New System.Drawing.Size(513, 499)
        Me.CountryGridControl.TabIndex = 5
        Me.CountryGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CountryGridView})
        '
        'CountryGridView
        '
        Me.CountryGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.CountryGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CountryGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryGridView.Appearance.Row.Options.UseFont = True
        Me.CountryGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckGridColumn, Me.NameShortGridColumn, Me.ModeIdGridColumn, Me.IsActGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsActGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = False
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.IsCheckGridColumn
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = True
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.CountryGridView.FormatRules.Add(GridFormatRule1)
        Me.CountryGridView.FormatRules.Add(GridFormatRule2)
        Me.CountryGridView.GridControl = Me.CountryGridControl
        Me.CountryGridView.Name = "CountryGridView"
        Me.CountryGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.CountryGridView.OptionsDetail.EnableMasterViewMode = False
        Me.CountryGridView.OptionsFind.AlwaysVisible = True
        Me.CountryGridView.OptionsView.ShowGroupPanel = False
        Me.CountryGridView.RowHeight = 25
        '
        'NameShortGridColumn
        '
        Me.NameShortGridColumn.Caption = "nameShort"
        Me.NameShortGridColumn.FieldName = "nameShort"
        Me.NameShortGridColumn.Name = "NameShortGridColumn"
        Me.NameShortGridColumn.OptionsColumn.AllowEdit = False
        Me.NameShortGridColumn.OptionsColumn.ReadOnly = True
        Me.NameShortGridColumn.Visible = True
        Me.NameShortGridColumn.VisibleIndex = 1
        Me.NameShortGridColumn.Width = 357
        '
        'ModeIdGridColumn
        '
        Me.ModeIdGridColumn.Caption = "modeId"
        Me.ModeIdGridColumn.FieldName = "modeId"
        Me.ModeIdGridColumn.Name = "ModeIdGridColumn"
        Me.ModeIdGridColumn.OptionsColumn.FixedWidth = True
        Me.ModeIdGridColumn.Visible = True
        Me.ModeIdGridColumn.VisibleIndex = 2
        Me.ModeIdGridColumn.Width = 60
        '
        'CountryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 499)
        Me.Controls.Add(Me.CountryGridControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CountryForm"
        Me.ShowInTaskbar = False
        Me.Text = "CountryForm"
        CType(Me.CountryGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CountryGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CountryGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameShortGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsActGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ModeIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
