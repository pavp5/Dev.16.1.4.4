''' <summary>
''' Cвойства и методы приложения
''' </summary>
''' <remarks></remarks>
Public Class Application

    Private Sub New()
    End Sub

    Private Shared _AppName As String = "Программа"
    ''' <summary>
    ''' Имя приложения
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property AppName As String
        Get
            Return _AppName
        End Get
        Set(ByVal value As String)
            _AppName = value
        End Set
    End Property

    Private Shared _AppSkinName As String = "DevExpress Style"
    ''' <summary>
    ''' Имя скина приложения
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property AppSkinName As String
        Get
            Return _AppSkinName
        End Get
        Set(ByVal value As String)
            _AppSkinName = value
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(_AppSkinName)
        End Set
    End Property

    Private Shared _AppSkinColor As Drawing.Color = Nothing
    ''' <summary>
    ''' Цвет скина приложения
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Property AppSkinColor As Drawing.Color
        Get
            Return _AppSkinColor
        End Get
        Set(ByVal value As Drawing.Color)
            _AppSkinColor = value
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinMaskColor = value
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinMaskColor2 = value
        End Set
    End Property

    ''' <summary>
    ''' Скин приложения в стиле "Metro"
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property IsMetroStyle As Boolean
        Get
            If String.IsNullOrEmpty(_AppSkinName) Then Return False
            Return (_AppSkinName.ToUpper Like "*METRO*")
        End Get
    End Property

    ''' <summary>
    ''' Подключение скинов к приложению
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub EnableAppSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.Skins.SkinManager.Default.RegisterAssembly(GetType(DevExpress.UserSkins.CprpSkin).Assembly)
        DevExpress.XtraSplashScreen.SplashScreenManager.RegisterUserSkins(GetType(DevExpress.UserSkins.CprpSkin).Assembly)
    End Sub

    ''' <summary>
    ''' Установка скина приложения в стиле MS Office
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SetOfficeSkin()
        Dim skinName As String = "Office 2010 Silver"
        Using key As Microsoft.Win32.RegistryKey = _
            My.Computer.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Office\14.0\Common")
            If Not key Is Nothing Then
                Select Case CInt(key.GetValue("Theme"))
                    Case 1 : skinName = "Office 2010 Blue"
                    Case 2 : skinName = "Office 2010 Silver"
                    Case 3 : skinName = "Office 2010 Black"
                End Select
            End If
        End Using
        Application.AppSkinName = skinName
    End Sub

End Class
