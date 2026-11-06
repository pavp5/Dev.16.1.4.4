Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма возврата плана работы на доработку
''' </summary>
Friend Class PlaneBackForm

    Friend Sub New()
        InitializeComponent()
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not C2.IsText(CommentMemoEdit.Text) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите причину возврата.")
            Exit Sub
        End If
        Dim expertTerm As Date = CDate(TermDateEdit.EditValue)
        If expertTerm < Date.Now Then
            Cprp.DxCommon.Messages.ShowError("Срок исполнения меньше текущей даты/времени, укажите корректный срок!")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class