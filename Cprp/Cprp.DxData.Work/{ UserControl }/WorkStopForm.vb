Imports Cprp.DxData.Common
''' <summary>
''' Форма приостановки выполнения работы
''' </summary>
Friend Class WorkStopForm

    ''' <summary>
    ''' Комментарий (причины остановки)
    ''' </summary>
    Friend Property Comment As String = Nothing


    Friend Sub New()
        InitializeComponent()
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Dim sTmp As String = Nothing
        If QueryCheckEdit.Checked Then sTmp = vbCrLf & "Направлен письменный запрос"
        If ManagerCheckEdit.Checked Then sTmp &= vbCrLf & "Запрошены данные через менеджера"
        If IsText(CommentMemoEdit.Text) Then sTmp &= vbCrLf & ToText(CommentMemoEdit.Text)
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите причины приостановки работы.")
            Exit Sub
        End If
        Comment = sTmp.Substring(2)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class