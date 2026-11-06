''' <summary>
''' Форма редактирования срока выполнения работы экспертом
''' </summary>
Friend Class WorkTermForm

    Friend Sub New()
        InitializeComponent()
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        DxErrorProvider1.ClearErrors()
        If TermDateEdit.EditValue Is Nothing Then
            DxErrorProvider1.SetError(TermDateEdit, "Укажите срок выполнения работы")
            Exit Sub
        End If
        If CDate(TermDateEdit.EditValue) < Date.Now Then
            DxErrorProvider1.SetError(TermDateEdit, "Некорректный срок выполнения работы")
            Exit Sub
        End If
        With CDate(TermDateEdit.EditValue)
            If .Hour < 9 OrElse .Hour > 18 OrElse (.Hour = 18 AndAlso .Minute > 0) Then
                DxErrorProvider1.SetError(TermDateEdit, "Некорректное время выполнения работы")
                Exit Sub
            End If
        End With
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class