Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма возврата работы на доработку
''' </summary>
''' <remarks></remarks>
Friend Class WorkBackForm

    Friend Sub New()
        InitializeComponent()
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not (LiteralCheckEdit.Checked OrElse ClientCheckEdit.Checked OrElse C2.IsText(CommentMemoEdit.Text)) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите комментарий к возврату.", "Укажите комментарий")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class