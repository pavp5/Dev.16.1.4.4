<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlaneDateForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.StartDateDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.MinuteCountSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CalcSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.CalcResultLabelControl = New DevExpress.XtraEditors.LabelControl()
        CType(Me.StartDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StartDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinuteCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartDateDateEdit
        '
        Me.StartDateDateEdit.EditValue = Nothing
        Me.StartDateDateEdit.Location = New System.Drawing.Point(136, 9)
        Me.StartDateDateEdit.Name = "StartDateDateEdit"
        Me.StartDateDateEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.StartDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartDateDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.StartDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.StartDateDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.StartDateDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
        Me.StartDateDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.StartDateDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm:ss"
        Me.StartDateDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.StartDateDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.StartDateDateEdit.Size = New System.Drawing.Size(244, 22)
        Me.StartDateDateEdit.TabIndex = 0
        '
        'MinuteCountSpinEdit
        '
        Me.MinuteCountSpinEdit.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinuteCountSpinEdit.Location = New System.Drawing.Point(136, 50)
        Me.MinuteCountSpinEdit.Name = "MinuteCountSpinEdit"
        Me.MinuteCountSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MinuteCountSpinEdit.Properties.Increment = New Decimal(New Integer() {480, 0, 0, 0})
        Me.MinuteCountSpinEdit.Properties.IsFloatValue = False
        Me.MinuteCountSpinEdit.Properties.Mask.EditMask = "N00"
        Me.MinuteCountSpinEdit.Size = New System.Drawing.Size(244, 22)
        Me.MinuteCountSpinEdit.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(75, 16)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Дата начала"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 53)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(118, 16)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Трудоемкость (мин)"
        '
        'CalcSimpleButton
        '
        Me.CalcSimpleButton.Location = New System.Drawing.Point(136, 95)
        Me.CalcSimpleButton.Name = "CalcSimpleButton"
        Me.CalcSimpleButton.Size = New System.Drawing.Size(97, 23)
        Me.CalcSimpleButton.TabIndex = 5
        Me.CalcSimpleButton.Text = "Рассчитать"
        '
        'CalcResultLabelControl
        '
        Me.CalcResultLabelControl.Location = New System.Drawing.Point(12, 152)
        Me.CalcResultLabelControl.Name = "CalcResultLabelControl"
        Me.CalcResultLabelControl.Size = New System.Drawing.Size(94, 16)
        Me.CalcResultLabelControl.TabIndex = 6
        Me.CalcResultLabelControl.Text = "Плановый срок:"
        '
        'PlaneDateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 253)
        Me.Controls.Add(Me.CalcResultLabelControl)
        Me.Controls.Add(Me.CalcSimpleButton)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.MinuteCountSpinEdit)
        Me.Controls.Add(Me.StartDateDateEdit)
        Me.Name = "PlaneDateForm"
        Me.Text = "PlaneDateForm"
        CType(Me.StartDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StartDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinuteCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartDateDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents MinuteCountSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CalcSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CalcResultLabelControl As DevExpress.XtraEditors.LabelControl
End Class
