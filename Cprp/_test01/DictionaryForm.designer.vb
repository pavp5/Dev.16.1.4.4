<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DictionaryForm
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
        Dim OptionsSpelling1 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
        Me.DictionaryMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.DictionaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpellChecker1
        '
        Me.SpellChecker1.CheckAsYouTypeOptions.CheckControlsInParentContainer = True
        Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("ru-RU")
        Me.SpellChecker1.ParentContainer = Me
        Me.SpellChecker1.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType
        Me.SpellChecker1.SpellingFormType = DevExpress.XtraSpellChecker.SpellingFormType.Word
        '
        'DictionaryMemoEdit
        '
        Me.DictionaryMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DictionaryMemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.DictionaryMemoEdit.Name = "DictionaryMemoEdit"
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.DictionaryMemoEdit, True)
        Me.DictionaryMemoEdit.Size = New System.Drawing.Size(292, 273)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.DictionaryMemoEdit, OptionsSpelling1)
        Me.DictionaryMemoEdit.TabIndex = 0
        '
        'DictionaryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.DictionaryMemoEdit)
        Me.Name = "DictionaryForm"
        Me.Text = "DictionaryForm"
        CType(Me.DictionaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
    Friend WithEvents DictionaryMemoEdit As DevExpress.XtraEditors.MemoEdit
End Class
