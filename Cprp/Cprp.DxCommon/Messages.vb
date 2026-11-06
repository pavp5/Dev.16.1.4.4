Imports DevExpress.XtraEditors
''' <summary>
''' Сообщения
''' </summary>
Public Class Messages

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Сообщение - вопрос    
    ''' </summary>
    ''' <param name="text">Текст сообщения</param>
    ''' <param name="title">Заголовок окна сообщения</param>
    ''' <returns></returns>
    ''' <remarks>Возвращает DialogResult.Yes или DialogResult.No</remarks>
    Public Shared Function ShowQuestion(ByVal text As String, Optional ByVal title As String = "Вопрос") As DialogResult
        XtraMessageBox.SmartTextWrap = True
        Return XtraMessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    ''' <summary>
    ''' Сообщение - вопрос с кнопкой "Отмена"
    ''' </summary>
    ''' <param name="text">Текст сообщения</param>
    ''' <param name="title">Заголовок окна сообщения</param>
    ''' <returns></returns>
    ''' <remarks>Возвращает DialogResult.Yes или DialogResult.No или DialogResult.Cancel</remarks>
    Public Shared Function ShowQuestionCancel(ByVal text As String, Optional ByVal title As String = "Вопрос") As DialogResult
        XtraMessageBox.SmartTextWrap = True
        Return XtraMessageBox.Show(text, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
    End Function

    ''' <summary>
    ''' Сообщение об ошибке
    ''' </summary>
    ''' <param name="text">Текст сообщения</param>
    ''' <param name="title">Заголовок окна сообщения</param>
    ''' <remarks></remarks>
    Public Shared Sub ShowError(ByVal text As String, Optional ByVal title As String = "Ошибка")
        XtraMessageBox.SmartTextWrap = True
        XtraMessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' Сообщение - предупреждение
    ''' </summary>
    ''' <param name="text">Текст сообщения</param>
    ''' <param name="title">Заголовок окна сообщения</param>
    ''' <remarks></remarks>
    Public Shared Sub ShowWarning(ByVal text As String, Optional ByVal title As String = "Внимание")
        XtraMessageBox.SmartTextWrap = True
        XtraMessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ''' <summary>
    ''' Информационное сообщение
    ''' </summary>
    ''' <param name="text">Текст сообщения</param>
    ''' <param name="title">Заголовок окна сообщения</param>
    ''' <remarks></remarks>
    Public Shared Sub ShowInformation(ByVal text As String, Optional ByVal title As String = "Сообщение")
        XtraMessageBox.SmartTextWrap = True
        XtraMessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


End Class
