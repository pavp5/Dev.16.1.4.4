''' <summary>
''' Форма регистрации в системе
''' </summary>
''' <remarks></remarks>
Friend Class ConnectForm

    Private Client As DatabaseUser

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="DbClient">Пользователь системы</param>
    Friend Sub New(ByVal DbClient As DatabaseUser)
        InitializeComponent()
        Me.Client = DbClient
        With My.Settings
            ServerTextEdit.Text = .ServerName
            DatabaseTextEdit.Text = .DatabaseName
            TrustedCheckEdit.Checked = Not .IsTrustedConnection
            LoginTextEdit.Text = .UserLogin
            PasswordTextEdit.Text = .UserPassword
        End With
        TrustedCheckEdit_CheckedChanged(Nothing, Nothing)
        Me.Icon = My.Resources.key_ico
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin
        Me.LookAndFeel.SkinName = Cprp.DxCommon.Application.AppSkinName
        Me.LookAndFeel.SkinMaskColor = Cprp.DxCommon.Application.AppSkinColor
        Me.Text = Cprp.DxCommon.Application.AppName
        Me.ShowInTaskbar = (Windows.Forms.Application.OpenForms.Count = 0)
        Me.CenterToScreen()
    End Sub

    Private Sub ConnectForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ServerTextEdit.SelectionLength = 0
    End Sub

    Private Sub TrustedCheckEdit_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrustedCheckEdit.CheckedChanged
        LoginTextEdit.Enabled = TrustedCheckEdit.Checked
        PasswordTextEdit.Enabled = LoginTextEdit.Enabled
    End Sub

    Private Function CheckUserInput() As Boolean
        DxErrorProvider1.ClearErrors()
        ServerTextEdit.Text = ServerTextEdit.Text.Trim
        If ServerTextEdit.Text = vbNullString Then
            DxErrorProvider1.SetError(ServerTextEdit, "Укажите имя сервера")
            Return False
        End If
        DatabaseTextEdit.Text = DatabaseTextEdit.Text.Trim
        If DatabaseTextEdit.Text = vbNullString Then
            DxErrorProvider1.SetError(DatabaseTextEdit, "Укажите базу данных")
            Return False
        End If
        If TrustedCheckEdit.Checked Then
            LoginTextEdit.Text = LoginTextEdit.Text.Trim
            If LoginTextEdit.Text = vbNullString Then
                DxErrorProvider1.SetError(LoginTextEdit, "Укажите имя пользователя")
                Return False
            End If
        End If
        With My.Settings
            .ServerName = ServerTextEdit.Text
            .DatabaseName = DatabaseTextEdit.Text
            .IsTrustedConnection = Not TrustedCheckEdit.Checked
            .UserLogin = If(.IsTrustedConnection, vbNullString, LoginTextEdit.Text)
            .UserPassword = If(.IsTrustedConnection, vbNullString, PasswordTextEdit.Text)
        End With
        Return True
    End Function

    Private Sub AcceptSimpleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AcceptSimpleButton.Click
        If Not CheckUserInput() Then Exit Sub
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If Not Client.OpenConnection(True) Then
            Me.Cursor = Windows.Forms.Cursors.Default
            Exit Sub
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class