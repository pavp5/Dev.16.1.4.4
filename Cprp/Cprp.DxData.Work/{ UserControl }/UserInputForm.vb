''' <summary>
''' Форма пользовательского ввода
''' </summary>
Public Class UserInputForm

    ''' <summary>
    ''' Заголовок окна для ввода текста
    ''' </summary>
    Public WriteOnly Property Caption As String
        Set(value As String)
            CaptionLabelControl.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Текст введенный пользователем
    ''' </summary>
    Public ReadOnly Property UserInput As String
        Get
            Return Cprp.DxData.Common.ToText(InputMemoEdit.Text)
        End Get
    End Property


    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Cprp.DxData.Common.IsText(InputMemoEdit.Text) Then
            Me.DialogResult = Forms.DialogResult.OK
        Else
            Cprp.DxCommon.Messages.ShowWarning(CaptionLabelControl.Text)
            Exit Sub
        End If
    End Sub

End Class