Imports C2 = Cprp.DxData.Common
' =====================================
' Перенос данных работы в архивную базу
' =====================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Загрузить данные работы в архивную базу данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataArchive()
        '
        ' Переменные
        '
        Dim Cn As SqlConnection = Nothing           ' соединение с архивной базой данных
        Dim Cmd As SqlCommand = Nothing             ' объект Command для работы с архивной базой
        Dim workId As Integer = C2.EMPTY_ID         ' id работы в архивной базе данных
        Dim T As DataTable = Nothing
        Dim Row As DataRow = Nothing
        Dim R As DevExpress.XtraRichEdit.RichEditControl = Nothing
        Dim sTmp As String = Nothing
        Try
            R = New DevExpress.XtraRichEdit.RichEditControl
            sTmp = My.Computer.FileSystem.GetTempFileName
            '
            ' Соединение с архивной базой данных
            '
            Cn = New SqlConnection
            Cn.ConnectionString = Cprp.DxData.Resource.Resource.GetStrData("EXDBACONNECTION", Me.Connection)
            Cn.Open()
            '
            ' Объект Command для работы с архивной базой
            '
            Cmd = New SqlCommand With {.Connection = Cn}
            '
            ' Удаление старых данных о работе
            ' ВСТАВИТЬ В ЗАПРОС ОГРАНИЧЕНИЕ ПО ID, ЧТО БЫ НЕ ГРОХНУТЬ СТАРЫЕ РАБОТЫ С ТЕМ ЖЕ WORKID
            '
            Cmd.CommandText = String.Format("DELETE FROM tWork WHERE workId = {0} AND id > 83010", CInt(Me.Id))    ' (AND id >...)
            Cmd.ExecuteNonQuery()
            '
            ' Загрузка данных в таблицу работ (tWork), определение ID работы в архивной базе (workId)
            '
            T = New DataTable
            Cmd.CommandText = "SELECT * FROM tWork WHERE id IS NULL"
            T.Load(Cmd.ExecuteReader)
            Row = T.NewRow
            Row("workId") = Me.Id
            Row("workParentId") = Me("parentId")
            Row("typeId") = 1               ' Идентификационная экспертиза по экспортному контролю
            Row("kindId") = Me("kindId")
            Row("description") = Me("description")
            Row("expertId") = GetArchUserId(Me("expertId"), Cmd)
            Row("managerId") = GetArchUserId(Me("managerId"), Cmd)
            Row("leaderId") = GetArchUserId(Me("leaderId"), Cmd)
            Row("orderNum") = Me("orderNum")
            Row("orderDate") = Me("orderDate")
            Row("orderUrl") = Me("orderUrl")
            Row("clientName") = Me("clientName")
            Row("clientAddress") = Me("clientAddress")
            Row("clientInn") = Me("clientInn")
            Row("clientKpp") = Me("clientKpp")
            Row("clientPhone") = Me("clientPhone")
            Row("clientFax") = Me("clientFax")
            Row("isExport") = CType(Me.ARow("modeId"), Cprp.DxData.ModeEnum) <> Cprp.DxData.ModeEnum.isImport
            Row("countryId") = GetArchCountryId(Me.ARow("countryId"), Cmd)
            If Not CBool(Me.ARow("isNotContract")) Then
                Row("contractName") = Me.ARow("contractName")
                Row("contractNum") = Me.ARow("contractNum")
                Row("contractDate") = Me.ARow("contractDate")
            End If
            Row("summaryId") = Me.ARow("summaryId")
            Using V As New DataView(Me.RequestTable)
                V.RowFilter = String.Format("conditionId = {0}", CInt(WorkCondition.IsClose))
                Row("isAsk") = If(V.Count > 0, True, False)
            End Using
            Row("refDataS") = MyClass.GetHtmlContent
            T.Rows.Add(Row)
            Using A As New SqlDataAdapter("SELECT * FROM tWork WHERE id IS NULL", Cn)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
            Cmd.CommandText = "SELECT @@IDENTITY"
            workId = C2.ToInt(Cmd.ExecuteScalar)
            '
            ' Обновление статусов участников работы в таблице пользователей
            '
            Cmd.CommandText = String.Format("UPDATE tUser SET isExpert = 1 WHERE id = {0}", C2.ToInt(Row("expertId")))
            Cmd.ExecuteNonQuery()
            Cmd.CommandText = String.Format("UPDATE tUser SET isManager = 1 WHERE id = {0}", C2.ToInt(Row("managerId")))
            Cmd.ExecuteNonQuery()
            Cmd.CommandText = String.Format("UPDATE tUser SET isLeader = 1 WHERE id = {0}", C2.ToInt(Row("leaderId")))
            Cmd.ExecuteNonQuery()
            T.Dispose()
            '
            ' Загрузка сведений об участниках сделки и операции в таблицу участников (tMember)
            '
            T = New DataTable
            Cmd.CommandText = "SELECT * FROM tMember WHERE id IS NULL"
            T.Load(Cmd.ExecuteReader)
            With Me.MemberTable
                For i As Integer = 0 To .Rows.Count - 1
                    If C2.ToInt(.Rows(i)("conRusNum")) > 0 Then
                        Row = T.NewRow
                        Row("workId") = workId
                        Row("typeId") = 1 ' 1 - рос. уч., 2 - ин. уч. сделки
                        Row("nameLong") = .Rows(i)("nameLong")
                        Row("nameShort") = .Rows(i)("nameShort")
                        Row("inn") = .Rows(i)("inn")
                        Row("kpp") = .Rows(i)("kpp")
                        Row("passportSer") = .Rows(i)("passportSer")
                        Row("passportNum") = .Rows(i)("passportNum")
                        Row("passportGive") = .Rows(i)("passportGive")
                        Row("phone") = .Rows(i)("phone")
                        Row("fax") = .Rows(i)("fax")
                        Row("email") = .Rows(i)("email")
                        Row("web") = .Rows(i)("web")
                        Row("addressCountryId") = GetArchCountryId(.Rows(i)("addressLegalCountryId"), Cmd)
                        Row("addressFull") = .Rows(i)("addressLegalFull")
                        Row("addressTown") = .Rows(i)("addressLegalTown")
                        T.Rows.Add(Row)
                    End If
                    If C2.ToInt(.Rows(i)("conNusNum")) > 0 Then
                        Row = T.NewRow
                        Row("workId") = workId
                        Row("typeId") = 2 ' 2 - ин. уч. сделки
                        Row("nameLong") = .Rows(i)("nameLong")
                        Row("nameShort") = .Rows(i)("nameShort")
                        Row("inn") = .Rows(i)("inn")
                        Row("kpp") = .Rows(i)("kpp")
                        Row("passportSer") = .Rows(i)("passportSer")
                        Row("passportNum") = .Rows(i)("passportNum")
                        Row("passportGive") = .Rows(i)("passportGive")
                        Row("phone") = .Rows(i)("phone")
                        Row("fax") = .Rows(i)("fax")
                        Row("email") = .Rows(i)("email")
                        Row("web") = .Rows(i)("web")
                        Row("addressCountryId") = GetArchCountryId(.Rows(i)("addressLegalCountryId"), Cmd)
                        Row("addressFull") = .Rows(i)("addressLegalFull")
                        Row("addressTown") = .Rows(i)("addressLegalTown")
                        T.Rows.Add(Row)
                    End If
                    If C2.ToInt(.Rows(i)("supRusNum")) > 0 Then
                        Row = T.NewRow
                        Row("workId") = workId
                        Row("typeId") = 3 ' 3 - рос. уч. операции
                        Row("nameLong") = .Rows(i)("nameLong")
                        Row("nameShort") = .Rows(i)("nameShort")
                        Row("inn") = .Rows(i)("inn")
                        Row("kpp") = .Rows(i)("kpp")
                        Row("passportSer") = .Rows(i)("passportSer")
                        Row("passportNum") = .Rows(i)("passportNum")
                        Row("passportGive") = .Rows(i)("passportGive")
                        Row("phone") = .Rows(i)("phone")
                        Row("fax") = .Rows(i)("fax")
                        Row("email") = .Rows(i)("email")
                        Row("web") = .Rows(i)("web")
                        Row("addressCountryId") = GetArchCountryId(.Rows(i)("addressLegalCountryId"), Cmd)
                        Row("addressFull") = .Rows(i)("addressLegalFull")
                        Row("addressTown") = .Rows(i)("addressLegalTown")
                        T.Rows.Add(Row)
                    End If
                    If C2.ToInt(.Rows(i)("supNusNum")) > 0 Then
                        Row = T.NewRow
                        Row("workId") = workId
                        Row("typeId") = 4 ' 4 - ин. уч. операции
                        Row("nameLong") = .Rows(i)("nameLong")
                        Row("nameShort") = .Rows(i)("nameShort")
                        Row("inn") = .Rows(i)("inn")
                        Row("kpp") = .Rows(i)("kpp")
                        Row("passportSer") = .Rows(i)("passportSer")
                        Row("passportNum") = .Rows(i)("passportNum")
                        Row("passportGive") = .Rows(i)("passportGive")
                        Row("phone") = .Rows(i)("phone")
                        Row("fax") = .Rows(i)("fax")
                        Row("email") = .Rows(i)("email")
                        Row("web") = .Rows(i)("web")
                        Row("addressCountryId") = GetArchCountryId(.Rows(i)("addressLegalCountryId"), Cmd)
                        Row("addressFull") = .Rows(i)("addressLegalFull")
                        Row("addressTown") = .Rows(i)("addressLegalTown")
                        T.Rows.Add(Row)
                    End If
                    If C2.ToInt(.Rows(i)("supEndNum")) > 0 Then
                        Row = T.NewRow
                        Row("workId") = workId
                        Row("typeId") = 5 ' 5 - кон. польз. операции
                        Row("nameLong") = .Rows(i)("nameLong")
                        Row("nameShort") = .Rows(i)("nameShort")
                        Row("inn") = .Rows(i)("inn")
                        Row("kpp") = .Rows(i)("kpp")
                        Row("passportSer") = .Rows(i)("passportSer")
                        Row("passportNum") = .Rows(i)("passportNum")
                        Row("passportGive") = .Rows(i)("passportGive")
                        Row("phone") = .Rows(i)("phone")
                        Row("fax") = .Rows(i)("fax")
                        Row("email") = .Rows(i)("email")
                        Row("web") = .Rows(i)("web")
                        Row("addressCountryId") = GetArchCountryId(.Rows(i)("addressLegalCountryId"), Cmd)
                        Row("addressFull") = .Rows(i)("addressLegalFull")
                        Row("addressTown") = .Rows(i)("addressLegalTown")
                        T.Rows.Add(Row)
                    End If
                Next
            End With
            ' Сохранение данных
            Using A As New SqlDataAdapter("SELECT * FROM tMember WHERE id IS NULL", Cn)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
            T.Dispose()
            '
            ' Загрузка сведений о товарах в таблицу товаров (tGood)
            '
            T = New DataTable
            Cmd.CommandText = "SELECT * FROM tGood WHERE id IS NULL"
            T.Load(Cmd.ExecuteReader)            
            For i As Integer = 0 To Me.GoodTable.Rows.Count - 1
                Row = T.NewRow
                Row("workId") = workId                
                Row("nameCon") = C2.DbText(C2.ToText(Me.GoodTable(i)("nameCon"), 2500))
                Row("nameDec") = Me.GoodTable(i)("nameDec")
                Row("tnved") = Me.GoodTable(i)("tnved")
                Row("cas") = Me.GoodTable(i)("cas")
                Row("categoryId") = Me.GoodTable(i)("categoryId")
                Row("typeId") = Me.GoodTable(i)("typeId")
                Row("area") = Me.GoodTable(i)("area")
                Row("used") = Me.GoodTable(i)("used")
                Row("description") = Me.GoodTable(i)("description")
                Row("studyDate") = Me.GoodTable(i)("studyDate")
                Row("studyPos") = DBNull.Value
                Row("studyIndex") = Me.GoodTable(i)("studySummaryId")
                Row("studyTnved") = Me.GoodTable(i)("studyTnved")
                Row("studyWord") = Me.GoodTable(i)("studyWord")
                T.Rows.Add(Row)
            Next
            Using A As New SqlDataAdapter("SELECT * FROM tGood WHERE id IS NULL", Cn)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
            T.Dispose()
            '
            ' Загрузка сведений о представленных документах в таблицу документов (tIndDoc)
            '
            T = New DataTable
            Cmd.CommandText = "SELECT * FROM tInDoc WHERE id IS NULL"
            T.Load(Cmd.ExecuteReader)
            For i As Integer = 0 To Me.InDocTable.Rows.Count - 1
                If IsDBNull(Me.InDocTable(i)("isUsed")) OrElse Not CBool(Me.InDocTable(i)("isUsed")) Then Continue For
                Row = T.NewRow
                Row("workId") = workId
                Row("caption") = Me.InDocTable(i)("caption")
                Row("regNum") = Me.InDocTable(i)("regNum")
                Row("regDate") = Me.InDocTable(i)("regDate")
                Row("docUrl") = Me.InDocTable(i)("docUrl")
                T.Rows.Add(Row)
            Next
            Using A As New SqlDataAdapter("SELECT * FROM tInDoc WHERE id IS NULL", Cn)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
            T.Dispose()
            '
            ' Загрузка заключений экспертизы в таблицу заключений (tOutDoc)
            '
            T = New DataTable
            Cmd.CommandText = "SELECT * FROM tOutDoc WHERE id IS NULL"
            T.Load(Cmd.ExecuteReader)
            With Me.ARow
                If Not IsDBNull(.Item("doc1Data")) Then
                    Row = T.NewRow
                    Row("workId") = workId
                    Row("regNum") = .Item("doc1RegNum")
                    Row("regDate") = .Item("doc1RegDate")
                    Row("proData") = .Item("doc1Data")
                    Row("docData") = .Item("doc1Data")
                    Row("summaryId") = .Item("doc1SummaryId")
                    T.Rows.Add(Row)
                End If
                If Not IsDBNull(.Item("doc2Data")) Then
                    Row = T.NewRow
                    Row("workId") = workId
                    Row("regNum") = .Item("doc2RegNum")
                    Row("regDate") = .Item("doc2RegDate")
                    Row("proData") = .Item("doc2Data")
                    Row("docData") = .Item("doc2Data")
                    Row("summaryId") = .Item("doc2SummaryId")
                    T.Rows.Add(Row)
                End If
            End With
            If T.Rows.Count > 0 Then
                Using A As New SqlDataAdapter("SELECT * FROM tOutDoc WHERE id IS NULL", Cn)
                    Dim B As New SqlCommandBuilder(A)
                    A.Update(T)
                End Using
            End If
            T.Dispose()
        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
            If Not T Is Nothing Then T.Dispose()
            If Not Cmd Is Nothing Then Cmd.Dispose()
            If Not Cn Is Nothing Then
                If Cn.State = ConnectionState.Open Then Cn.Close()
                Cn.Dispose()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Возвращает ID пользователя в архивной базе данных по его ID в рабочей базе данных
    ''' </summary>
    ''' <param name="userId">ID пользователя в рабочей базе данных</param>
    ''' <param name="Command">Объект SqlCommand для работы с архивной базой данных</param>
    ''' <remarks>
    ''' Если соответствующего пользователя нет в архивной базе, то создается новая запись и возвращается ее ID
    ''' </remarks>
    Private Function GetArchUserId(userId As Object, Command As SqlCommand) As Object
        ' ФИО пользователя в рабочей базе
        Dim sTmp As String = C2.ToText(Me.ExecuteScalar(String.Format("SELECT nameShort FROM tUser WHERE id = {0}", C2.ToInt(userId))))
        If Not C2.IsText(sTmp) Then Return DBNull.Value
        ' Д'Артаньян -> Д''АРТАНЬЯН
        sTmp = sTmp.Replace("'", "''").ToUpper
        ' Если пользователь есть в архивной базе, вернуть его ID
        Command.CommandText = String.Format("SELECT COUNT(*) FROM tUser WHERE name LIKE '{0}'", sTmp)
        If CInt(Command.ExecuteScalar) > 0 Then
            Command.CommandText = String.Format("SELECT id FROM tUser WHERE name LIKE '{0}'", sTmp)
            Return Command.ExecuteScalar
        End If
        ' Если пользователя нет в архивной базе, создать новую запись и вернуть ее ID
        Command.CommandText = String.Format("INSERT tUser (name) VALUES ('{0}')", sTmp)
        Command.ExecuteNonQuery()
        Command.CommandText = "SELECT @@IDENTITY"
        Return Command.ExecuteScalar
    End Function

    ''' <summary>
    ''' Возвращает ID страны в архивной базе данных по ее ID в рабочей базе данных
    ''' </summary>
    ''' <param name="countryId">ID страны в рабочей базе данных</param>
    ''' <param name="Command">Объект SqlCommand для работы с архивной базой данных</param>
    ''' <remarks>
    ''' Если соответствующей страны нет в архивной базе, то создается новая запись и возвращается ее ID
    ''' </remarks>
    Private Function GetArchCountryId(countryId As Object, Command As SqlCommand) As Object
        ' Краткое наименование страны в рабочей базе
        Dim sTmp As String = C2.ToText(Me.ExecuteScalar(String.Format("SELECT nameShort FROM tCountry WHERE id = {0}", C2.ToInt(countryId))))
        If Not C2.IsText(sTmp) Then Return DBNull.Value
        ' Кот Д'Ивуар -> КОТ Д''ИВУАР
        sTmp = sTmp.Replace("'", "''").ToUpper
        ' Если страна есть в архивной базе, вернуть ее ID
        Command.CommandText = String.Format("SELECT COUNT(*) FROM tCountry WHERE name LIKE '{0}'", sTmp)
        If CInt(Command.ExecuteScalar) > 0 Then
            Command.CommandText = String.Format("SELECT id FROM tCountry WHERE name LIKE '{0}'", sTmp)
            Return Command.ExecuteScalar
        End If
        ' Если страны нет в архивной базе, создать новую запись и вернуть ее ID
        Command.CommandText = String.Format("INSERT tCountry (name) VALUES ('{0}')", sTmp)
        Command.ExecuteNonQuery()
        Command.CommandText = "SELECT @@IDENTITY"
        Return Command.ExecuteScalar
    End Function

End Class
