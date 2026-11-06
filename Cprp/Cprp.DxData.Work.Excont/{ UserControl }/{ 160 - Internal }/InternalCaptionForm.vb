Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма ввода заголовка нового внутреннего документа
''' </summary>
Friend Class InternalCaptionForm

    Friend Sub New()
        InitializeComponent()
        Me.Text = "Новый документ"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not C2.IsText(CaptionMemoEdit.Text) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите заголовок или краткое содержание документа.")
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class