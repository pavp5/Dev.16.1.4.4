<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KksForm
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
        Me.SP = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.SuspendLayout()
        '
        'SP
        '
        Me.SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SP.Location = New System.Drawing.Point(0, 0)
        Me.SP.Name = "SP"
        Me.SP.Size = New System.Drawing.Size(282, 253)
        Me.SP.TabIndex = 0
        Me.SP.Text = "SpreadsheetControl1"
        '
        'KksForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Controls.Add(Me.SP)
        Me.Name = "KksForm"
        Me.Text = "KksForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SP As DevExpress.XtraSpreadsheet.SpreadsheetControl
End Class
