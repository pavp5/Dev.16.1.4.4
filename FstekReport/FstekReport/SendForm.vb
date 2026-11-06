Imports System.Net.Mail
Imports Cprp.DxData.Common
''' <summary>
''' Форма отправки отчета в ФСТЭК
''' </summary>
Friend Class SendForm

#Region "Таблица файлов вложения"

    Private Class FileDataTable : Inherits DataTable
        Public Sub New()
            MyBase.New("FileTable")
            With Me.Columns
                .Add("name", GetType(String))
                .Add("path", GetType(String))
                .Add("isCheck", GetType(Boolean))
            End With
            Me.Columns("name").AllowDBNull = False
            Me.Columns("path").AllowDBNull = False
            Me.Columns("isCheck").AllowDBNull = False
            Me.Columns("isCheck").DefaultValue = True
            Me.PrimaryKey = New DataColumn() {Me.Columns("name")}
        End Sub
    End Class

#End Region

    ''' <summary>
    ''' Таблица файлов вложения
    ''' </summary>
    Private FileTable As FileDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="reportFolder">Путь к папке файлов отчета</param>
    ''' <param name="reportDate">Дата отчета</param>
    Friend Sub New(reportFolder As String, reportDate As Date)
        InitializeComponent()
        '
        ' FileTable
        '
        FileTable = New FileDataTable
        With My.Computer.FileSystem
            For Each fn As String In .GetFiles(reportFolder)
                FileTable.Rows.Add(New Object() {.GetName(fn), fn, True})
            Next
        End With
        '
        ' ToEmailTextEdit, ToCopyEmailTextEdit
        '
        With My.Settings
            ToEmailTextEdit.EditValue = .ToEmail
            ToCopyEmailTextEdit.EditValue = .ToCopyEmail
        End With
        '
        ' SubjectTextEdit
        '
        SubjectTextEdit.EditValue = String.Format("Отчет ЦПРП за {0:dd.MM.yyyy}", reportDate)
        '
        ' BodyMemoEdit
        '
        'BodyMemoEdit.EditValue = String.Format( _
        '    "Здравствуйте,{0}{0}Отправляю отчет за {1:dd.MM.yyyy}.{0}{0}С уважением,{0}{2}", _
        '    vbCrLf, reportDate, MirrorName(Program.DbClient.NameShort))
        BodyMemoEdit.EditValue = String.Format( _
            "ФСТЭК России{0}Управление экспортного контроля{0}Отдел контрольно-методического обеспечения{0}{0}" &
            "Направляются сведения о проведённых независимых идентификационных экспертизах товаров и технологий в целях экспортного контроля и выданных идентификационных заключениях.{0}{0}" & _
            "ЗАО «Центр проектов развития промышленности»{0}Пуганов П.В.{0}8 (800) 550-40-34", vbCrLf)
        '
        ' FileTreeList
        '
        FileTreeList.DataSource = FileTable
        '
        ' Me
        '
        Me.Text = "Отправка отчета"
        Me.CenterToScreen()

    End Sub


    ''' <summary>
    ''' Преобразует ФИО пользователя
    ''' </summary>
    ''' <param name="name">ФИО пользователя</param>
    ''' <remarks>
    ''' Процедура преобразует выражение вида 'Фамилия И.О.' в выражение вида 'И.О. Фамилия'
    ''' </remarks>
    Private Function MirrorName(name As String) As String
        name = ToText(name)
        If String.IsNullOrWhiteSpace(name) Then Return name
        Dim arr() As String = name.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
        If arr.Length <> 2 Then Return name
        Return String.Format("{0} {1}", ToText(arr(1)), ToText(arr(0)))
    End Function

    ''' <summary>
    ''' Проверяет отправляемое сообщение на наличие ошибок
    ''' </summary>
    Private Function CheckSend() As Boolean
        DxErrorProvider1.ClearErrors()
        If Not IsText(ToEmailTextEdit.EditValue) Then
            DxErrorProvider1.SetError(ToEmailTextEdit, "Не указан адрес получателя")
            Return False
        End If
        If Not IsText(SubjectTextEdit.EditValue) Then
            DxErrorProvider1.SetError(SubjectTextEdit, "Не указана тема сообщения")
            Return False
        End If
        If Not IsText(BodyMemoEdit.EditValue) Then
            DxErrorProvider1.SetError(BodyMemoEdit, "Не указано сообщение")
            Return False
        End If
        Using V As New DataView(FileTable) With {.RowFilter = "isCheck = True"}
            If V.Count = 0 Then
                DxErrorProvider1.SetError(FileTreeList, "Не выбраны файлы для вложения")
                Return False
            End If
        End Using
        Return True
    End Function

    Private Sub SendForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FileTreeList.CheckAll()
        FileLayoutControlGroup.Text = String.Format("Вложения ({0})", FileTreeList.GetAllCheckedNodes.Count)
    End Sub

    Private Sub FileTreeList_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles FileTreeList.AfterCheckNode
        FileLayoutControlGroup.Text = String.Format("Вложения ({0})", FileTreeList.GetAllCheckedNodes.Count)
    End Sub

    Private Sub FileTreeList_DoubleClick(sender As Object, e As EventArgs) Handles FileTreeList.DoubleClick
        If FileTreeList.FocusedNode Is Nothing Then Exit Sub
        Using P As New Process
            P.StartInfo.FileName = ToText(FileTreeList.FocusedNode.GetValue("path"))
            P.StartInfo.Verb = "Open"
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            P.Start()
        End Using
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not CheckSend() Then Exit Sub
        Dim M As MailMessage = Nothing
        Dim S As SmtpClient = Nothing
        Dim sTmp As String = Nothing
        Cprp.DxCommon.WaitForm.Show()
        Try
            ' Адрес отправителя
            sTmp = ToText(Program.DbClient.Email)
            If Not IsText(sTmp) Then sTmp = "system@excont.ru"
            ' Сообщение
            M = New MailMessage(sTmp, ToText(ToEmailTextEdit.EditValue), ToText(SubjectTextEdit.EditValue), ToText(BodyMemoEdit.EditValue))
            ' Скрытые копии
            sTmp = ToText(ToCopyEmailTextEdit.EditValue)
            If IsText(sTmp) Then
                Dim arr() As String = sTmp.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                For Each sTmp In arr
                    M.Bcc.Add(sTmp)
                Next
            End If
            'Скрытая копия отправителю
            sTmp = ToText(Program.DbClient.Email)
            If IsText(sTmp) Then M.Bcc.Add(sTmp)
            ' Вложения
            Using V As New DataView(FileTable) With {.RowFilter = "isCheck = True"}
                For Each VRow As DataRowView In V
                    M.Attachments.Add(New Attachment(ToText(VRow("path"))))
                Next
            End Using
            ' Отправка
            S = New SmtpClient()
            S.Host = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", Program.DbClient.Connection)
            S.Port = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", Program.DbClient.Connection)
            S.Send(M)
            ' Сохранение адресов отправки
            With My.Settings
                .ToEmail = ToText(ToEmailTextEdit.EditValue)
                .ToCopyEmail = ToText(ToCopyEmailTextEdit.EditValue)
                .Save()
            End With
            Cprp.DxCommon.WaitForm.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            If Not M Is Nothing Then M.Dispose()
            If Not S Is Nothing Then S.Dispose()
        End Try

    End Sub


End Class