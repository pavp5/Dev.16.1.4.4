<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraForm1
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
        Me.RichEditControl1 = New DevExpress.XtraRichEdit.RichEditControl()
        Me.SuspendLayout()
        '
        'RichEditControl1
        '
        Me.RichEditControl1.Location = New System.Drawing.Point(72, 53)
        Me.RichEditControl1.Name = "RichEditControl1"
        Me.RichEditControl1.Size = New System.Drawing.Size(400, 200)
        Me.RichEditControl1.TabIndex = 0
        Me.RichEditControl1.Text = "RichEditControl1"
        '
        'XtraForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 690)
        Me.Controls.Add(Me.RichEditControl1)
        Me.Name = "XtraForm1"
        Me.Text = "XtraForm1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichEditControl1 As DevExpress.XtraRichEdit.RichEditControl
End Class
