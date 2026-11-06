Imports Cprp.DxData.Common
''' <summary>
''' Форма возобновления выполнения работы
''' </summary>
Friend Class WorkStartForm

    ''' <summary>
    ''' Комментарий (причины возобновления работы)
    ''' </summary>
    Friend Property Comment As String = Nothing

    ''' <summary>
    ''' Новый срок исполнения
    ''' </summary>
    Friend Property ExpertTerm As Date = Nothing


    Friend Sub New()
        InitializeComponent()
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        ExpertTerm = CDate(TermDateEdit.EditValue)
        If ExpertTerm < Date.Now Then
            Cprp.DxCommon.Messages.ShowError("Срок исполнения меньше текущей даты/времени, укажите корректный срок!")
            Exit Sub
        End If
        Comment = Nothing
        If QueryCheckEdit.Checked Then Comment = vbCrLf & "Получен ответ"
        If IsText(CommentMemoEdit.Text) Then Comment &= vbCrLf & ToText(CommentMemoEdit.Text)
        If Not String.IsNullOrWhiteSpace(Comment) Then Comment = Comment.Substring(2)

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class