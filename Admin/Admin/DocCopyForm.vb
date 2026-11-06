Imports Cprp.DxData.Common
''' <summary>
''' Форма ввода данных для копии документа
''' </summary>
Friend Class DocCopyForm

    Friend Sub New()
        InitializeComponent()
        DateEDateEdit.EditValue = CDate("31.12.9999")
        Me.Text = "Копия документа"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not IsText(DocTextEdit.Text) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите doc!")
            Exit Sub
        End If
        If Not IsText(DateBDateEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите dateB!")
            Exit Sub
        End If
        If Not IsText(DateEDateEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowWarning ("Укажите dateE!") 
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class