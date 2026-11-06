Imports Cprp.DxData.Common
''' <summary>
''' Форма ввода данных для замены текста в АПУ
''' </summary>
Friend Class FindReplaceForm

    ''' <summary>
    ''' Текст для поиска в АПУ
    ''' </summary>
    Friend Property FindText As String = Nothing

    ''' <summary>
    ''' Текст для замены в АПУ
    ''' </summary>
    Friend Property ReplaceText As String = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="findText">Текст для поиска</param>
    Friend Sub New(Optional ByVal findText As String = Nothing)
        InitializeComponent()
        FindMemoEdit.EditValue = findText
        ReplaceMemoEdit.EditValue = ReplaceText
        Me.Text = "Найти и заменить текст в АПУ"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not IsText(FindMemoEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowWarning("Введите текст для поиска!")
            Exit Sub
        End If
        If Not IsText(ReplaceMemoEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowWarning("Введите текст для замены!")
            Exit Sub
        End If
        FindText = ToText(FindMemoEdit.EditValue)
        ReplaceText = ToText(ReplaceMemoEdit.EditValue)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class