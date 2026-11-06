Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма разблокировки проекта итогового документа
''' </summary>
Friend Class ProjectEditForm

    Friend Sub New()
        InitializeComponent()
        Me.Text = "Редактирование проекта заключения"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not C2.IsText(CommentMemoEdit.Text) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите причину редактирования.")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class