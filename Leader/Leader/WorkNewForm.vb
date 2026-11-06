Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма создания новой работы
''' </summary>
Friend Class WorkNewForm

    ''' <summary>
    ''' ID новой работы
    ''' </summary>
    Friend workId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' ID заказа
    ''' </summary>
    Private orderId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Справочник видов работа
    ''' </summary>
    Private Class TypeDataTable : Inherits DataTable
        Public Sub New()
            MyBase.New("TypeTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("name", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            With Me.Rows
                .Add(New Object() {1, "ИДЕНТИФИКАЦИЯ ПО ЭКСПОРТНОМУ КОНТРОЛЮ"})
                .Add(New Object() {3, "ЗАПРЕТЫ И ОГРАНИЧЕНИЯ ЕАЭС"})
                .Add(New Object() {2, "ГРАЖДАНСКОЕ НАЗНАЧЕНИЕ"})
                .Add(New Object() {5, "КОНСУЛЬТАЦИЯ ПО КОДУ ТН ВЭД"})
                .Add(New Object() {6, "КОНСУЛЬТАЦИЯ ПО ВЭД"})
                .Add(New Object() {4, "ПОДТВЕРЖДЕНИЕ ЛИЦЕНЗИИ"})
            End With
        End Sub
    End Class

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Row">Строка плана работ для создания новой работы</param>
    Friend Sub New(Row As DataRow)
        InitializeComponent()
        If Row Is Nothing Then Exit Sub
        '
        ' orderId
        '
        orderId = CInt(Row("orderId"))
        '
        ' OrderLabelControl
        '
        OrderLabelControl.Text = String.Format("Заказ № {0} от {1:dd.MM.yyyy}, {2}", C2.ToText(Row("orderNum")), If(IsDBNull(Row("orderDate")), Date.Today, CDate(Row("orderDate"))), C2.ToText(Row("clientName")))
        '
        ' TypeLookUpEdit
        '
        TypeLookUpEdit.Properties.DataSource = New TypeDataTable
        '
        ' ExpertLookUpEdit
        '
        ExpertLookUpEdit.Properties.DataSource = Program.ExpertTable
        ExpertLookUpEdit.EditValue = Row("expertId")
        '
        ' ManagerLookUpEdit
        '
        ManagerLookUpEdit.Properties.DataSource = Program.ManagerTable
        ManagerLookUpEdit.EditValue = Row("managerId")
        '
        ' Me 
        '
        Me.Text = "Новая работа"
        Me.CenterToScreen()
    End Sub


    Private Sub WorkNewForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If orderId < 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If TypeLookUpEdit.EditValue Is Nothing OrElse IsDBNull(TypeLookUpEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowError("Укажите вид работы!")
            Exit Sub
        End If
        If ExpertLookUpEdit.EditValue Is Nothing OrElse IsDBNull(ExpertLookUpEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowError("Укажите эксперта!")
            Exit Sub
        End If
        If ManagerLookUpEdit.EditValue Is Nothing OrElse IsDBNull(ManagerLookUpEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowError("Укажите менеджера!")
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            '
            ' Создание новой работы
            '
            Dim Row As DataRow = Nothing
            Using T As New WorkDataTable(Program.DbClient.Connection)
                Row = T.NewRow
                Row("guid") = System.Guid.NewGuid.ToString
                Row("typeId") = TypeLookUpEdit.EditValue
                Row("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsPlaneWork)
                Row("expertId") = ExpertLookUpEdit.EditValue
                Row("managerId") = ManagerLookUpEdit.EditValue
                Row("leaderId") = Program.DbClient.Id
                Row("comment") = C2.DbText(CommentMemoEdit.EditValue)
                Row("orderId") = orderId
                Row("dbId") = Row("id")
                Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
                    Cmd.CommandText = String.Format("SELECT orderNum, orderDate, orderUrl, orderTerm, taskId, taskUrl, clientName, clientAddress, clientInn, clientKpp, clientPhone, clientFax FROM tWork where orderId = {0}", orderId)
                    Using Dr As SqlDataReader = Cmd.ExecuteReader
                        If Dr.Read Then
                            Row("orderNum") = Dr("orderNum")
                            Row("orderDate") = Dr("orderDate")
                            Row("orderUrl") = Dr("orderUrl")
                            Row("orderTerm") = Dr("orderTerm")
                            Row("taskId") = Dr("taskId")
                            Row("taskUrl") = Dr("taskUrl")
                            Row("clientName") = Dr("clientName")
                            Row("clientAddress") = Dr("clientAddress")
                            Row("clientInn") = Dr("clientInn")
                            Row("clientKpp") = Dr("clientKpp")
                            Row("clientPhone") = Dr("clientPhone")
                            Row("clientFax") = Dr("clientFax")
                        End If
                    End Using
                    Row("createDate") = Date.Now
                    Row("expertTerm") = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 120)
                    T.Rows.Add(Row)
                    T.SaveToBase()
                    Cmd.CommandText = "SELECT @@IDENTITY"
                    Row("dbId") = CInt(Cmd.ExecuteScalar)
                End Using
            End Using
            '
            ' Отправка в ЭО сообщения о новой работе
            '
            Dim Work As Cprp.DxData.Work.WorkConnectionRow = Nothing
            Select Case CType(Row("typeId"), Cprp.DxData.Work.WorkType)
                Case Cprp.DxData.Work.WorkType.IsExCont
                    Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(Row("dbId"), Program.DbClient.Connection)
                    Exit Select
                Case Cprp.DxData.Work.WorkType.IsCustomUnion
                    Work = New Cprp.DxData.Work.Customs.WorkConnectionRow(Row("dbId"), Program.DbClient.Connection)
                    Exit Select
                Case Cprp.DxData.Work.WorkType.IsMilitary
                    Work = New Cprp.DxData.Work.Military.WorkConnectionRow(Row("dbId"), Program.DbClient.Connection)
                    Exit Select
                Case Cprp.DxData.Work.WorkType.IsTnved
                    Work = New Cprp.DxData.Work.Tnved.WorkConnectionRow(Row("dbId"), Program.DbClient.Connection)
                    Exit Select
                Case Cprp.DxData.Work.WorkType.IsConsultation
                    Work = New Cprp.DxData.Work.Consultation.WorkConnectionRow(Row("dbId"), Program.DbClient.Connection)
                    Exit Select
                Case Cprp.DxData.Work.WorkType.IsLiconfirm
                    Work = New Cprp.DxData.Work.Liconfirm.WorkConnectionRow(Row("dbId"), Program.DbClient.Connection)
            End Select
            If Not Work Is Nothing Then
                Work.MessageWorkNewEo()
                Work.Dispose()
            End If
            '
            ' Отправка email-сообщений исполнителям
            '
            Dim Mail As New Cprp.DxData.Mail(Work.Connection)
            Dim caption As String = Nothing
            Dim body As String = Nothing
            If Not IsDBNull(Row("managerId")) Then
                caption = String.Format("{0} назначил Вас менеджером в работе № {1} ({2}).", Program.DbClient.NameShort, CInt(Row("dbId")), OrderLabelControl.Text)
                body = caption
                If Not IsDBNull(Row("comment")) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, C2.AddPoint(Row("comment")))
                Mail.Send(Program.DbClient.Id, Row("managerId"), caption, body)
            End If
            If Not IsDBNull(Row("expertId")) Then
                caption = String.Format("{0} назначил Вас экспертом в работе № {1}.", Program.DbClient.NameShort, CInt(Row("dbId")))
                body = caption
                If Not IsDBNull(Row("comment")) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, C2.AddPoint(Row("comment")))
                Mail.Send(Program.DbClient.Id, Row("expertId"), caption, body)
            End If
            Cprp.DxCommon.WaitForm.Close()
            workId = CInt(Row("dbId"))
            Cprp.DxCommon.Messages.ShowInformation(String.Format("Создана работа № {0}.", workId))
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try

    End Sub

End Class