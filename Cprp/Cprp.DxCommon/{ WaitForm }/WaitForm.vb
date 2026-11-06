''' <summary>
''' Окно-заставка
''' </summary>
''' <remarks></remarks>
Public Class WaitForm

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Показать заставку
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Show()
        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(Nothing, GetType(FormWait), True, True, False)
    End Sub

    ''' <summary>
    ''' Показать заставку
    ''' </summary>
    ''' <param name="ParentForm">Форма-владелец окна-заставки</param> 
    ''' <remarks></remarks>
    Public Shared Sub Show(ByVal ParentForm As Windows.Forms.Form)
        If ParentForm Is Nothing Then
            Show()
        Else
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(ParentForm, GetType(FormWait), True, True, False)
        End If
    End Sub

    ''' <summary>
    ''' Скрыть заставку
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Close()
        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(False)
    End Sub

End Class