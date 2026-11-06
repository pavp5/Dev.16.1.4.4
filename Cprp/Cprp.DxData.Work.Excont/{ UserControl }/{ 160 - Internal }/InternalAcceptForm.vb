Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма возврата запроса на доработку
''' </summary>
Friend Class InternalAcceptForm

    Friend Sub New()
        InitializeComponent()
        Me.Text = "Утверждение документа"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not C2.IsText(CommentMemoEdit.Text) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите резолюцию руководителя.")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class