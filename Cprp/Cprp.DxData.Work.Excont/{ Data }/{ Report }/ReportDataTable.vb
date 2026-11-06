Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица отчета в ФСТЭК
''' </summary>
Public Class ReportDataTable : Inherits DataTable

    ' Текущая работа, включаемая в отчет
    Private W As WorkConnectionRow = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        '
        ' Me
        '
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID строки в таблице, первичный ключ, автоинкремент
            .Add("isBad", GetType(Boolean))             ' Строка содержит неполные данные
            ' Работа
            .Add("workId", GetType(Integer))            ' ID работы
            .Add("clientCaption", GetType(String))      ' Наименование и реквизиты заказчика экспертизы
            .Add("contractNum", GetType(String))        ' Номер контракта
            .Add("contractDate", GetType(Date))         ' Дата контракта
            .Add("contractTerm", GetType(Date))         ' Срок действия контракта
            .Add("rusCaption", GetType(String))         ' Наименование и реквизиты российского участника
            .Add("rusInn", GetType(String))             ' ИНН российского участника
            .Add("nusCaption", GetType(String))         ' Наименование и реквизиты иностранного участника
            .Add("endCaption", GetType(String))         ' Наименование и реквизиты конечного пользователя
            .Add("memberEmbargoId", GetType(Integer))   ' Идентификатор специальных экономических мер в отношении иностранных участников
            .Add("countryCaption", GetType(String))     ' Наименования страны назначения поставки (краткое и полное)
            .Add("countryCaption2", GetType(String))    ' Наименования страны отправления поставки (краткое и полное)
            .Add("countryEmbargoId", GetType(Integer))  ' Идентификатор специальных экономических мер в отношении страны назначения
            .Add("isExport", GetType(Boolean))          ' Направление перемещения (0 - ввоз, 1 - вывоз)
            ' Заключение экспертизы
            .Add("docNum", GetType(String))             ' Номер заключения
            .Add("docDate", GetType(Date))              ' Дата заключения
            .Add("docSummaryId", GetType(Integer))      ' Идентификатор выводов экспертизы
            .Add("docSummary", GetType(String))         ' Выводы экспертизы
            .Add("docTermId", GetType(Integer))         ' Идентификатор срока действия заключения
            .Add("docTerm", GetType(Date))              ' Срок действия заключения
            ' Объект экспертизы
            .Add("goodId", GetType(String))             ' ID объекта экспертизы
            .Add("goodName", GetType(String))           ' Коммерческое наименование
            .Add("goodTnved", GetType(String))          ' Код ТН ВЭД
            .Add("goodCategory", GetType(Integer))      ' Категория объекта экспертизы (номер)
            .Add("goodDescription", GetType(String))    ' Техническое описание
            .Add("goodUsed", GetType(String))           ' Назначение и область применения
            .Add("goodSummaryId", GetType(Integer))     ' Идентификатор сравнительного анализа
            .Add("goodLawList", GetType(String))        ' Перечень обозначений контрольных списков, в отношени которых проводился сравнительный анализ
            .Add("goodLawPos", GetType(String))         ' Перечень номеров пунктов контрольных списков, в отношени которых проводился сравнительный анализ
            .Add("goodLawDescription", GetType(String)) ' Описания пунктов контрольных списков, в отношении которых проводился сравнительный анализ
            .Add("goodLawCharaster", GetType(String))   ' Характеристики объекта, указанные при сравнительном анализе
            .Add("goodEmbargoId", GetType(Integer))     ' Идентификатор специальных экономических мер в отношении объекта экспертизы
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' W
        '
        If Not (Connection Is Nothing AndAlso Connection.State = ConnectionState.Open) Then
            W = New WorkConnectionRow(C2.EMPTY_ID, Connection)
        End If
    End Sub

    ''' <summary>
    ''' Создать отчет
    ''' </summary>
    ''' <param name="dateBegin">Дата начала отчета</param>
    ''' <param name="dateEnd">Дата конца отчета</param>
    ''' <remarks>Отчет создается по датам закрытия работ</remarks>
    Public Sub CreateReport(dateBegin As Date, dateEnd As Date)
        If W Is Nothing Then Exit Sub
        '
        ' Переменные
        '
        Dim WorkIdTable As New DataTable            ' Таблица ID работ, попадающих в отчетный период
        Dim ReportRow As DataRow = Nothing          ' Текущая строка таблицы отчета
        Dim Row As DataRow = Nothing
        ' Текущая работа
        Dim clientCaption As String = Nothing       ' Наименование и реквизиты заказчика экспертизы
        Dim contractNum As String = Nothing         ' Номер контракта
        Dim contractDate As Date = Nothing          ' Дата контракта
        Dim contractTerm As Date = Nothing          ' Срок действия контракта
        Dim rusCaption As String = Nothing          ' Наименование и реквизиты российского участника
        Dim rusInn As String = Nothing              ' ИНН российского участника
        Dim nusCaption As String = Nothing          ' Наименование и реквизиты иностранного участника
        Dim endCaption As String = Nothing          ' Наименование и реквизиты конечного пользователя
        Dim memberEmbargoId As Integer = Nothing    ' Идентификатор специальных экономических мер в отношении иностранных участников
        Dim countryCaption As String = Nothing      ' Наименования страны назначения поставки (краткое и полное)
        Dim countryCaption2 As String = Nothing     ' Наименования страны отправления поставки (краткое и полное)
        Dim countryEmbargoId As Integer = Nothing   ' Идентификатор специальных экономических мер в отношении страны назначения
        '
        ' Создание отчета
        '
        'Try
        Me.Rows.Clear()
        '
        ' Выборка ID работ, попадающих в отчетный период
        '
        WorkIdTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = W.Connection}
            Cmd.CommandText = String.Format( _
                "SELECT id FROM tWork WHERE typeId = {0} AND closeDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND closeDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}} AND conditionId = {3}", _
                CInt(Cprp.DxData.Work.WorkType.IsExCont), dateBegin, dateEnd, CInt(Cprp.DxData.Work.WorkCondition.IsClose))
            WorkIdTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' Цикл по работам
        '
        For i As Integer = 0 To WorkIdTable.Rows.Count - 1
            '
            ' Текущая работа
            '
            W.Id = WorkIdTable(i)("id")
            If W.IsEmpty Then Continue For
            clientCaption = GetClientCaption()
            contractNum = Nothing
            contractDate = Nothing
            contractTerm = Nothing
            If Not CBool(W.ARow("isNotContract")) Then
                contractNum = C2.ToText(W.ARow("contractNum"))
                If Not IsDBNull(W.ARow("contractDate")) Then
                    contractDate = CDate(W.ARow("contractDate"))
                    If contractDate < Date.Today.AddYears(-100) Then contractDate = Nothing
                End If
                If Not IsDBNull(W.ARow("contractTerm")) Then
                    contractTerm = CDate(W.ARow("contractTerm"))
                    If contractTerm < Date.Today.AddYears(-100) Then contractTerm = Nothing
                End If
            End If
            rusCaption = Nothing
            rusInn = Nothing
            nusCaption = Nothing
            endCaption = Nothing
            Using V As New DataView(W.MemberTable)
                V.RowFilter = "supRusNum > 0"
                V.Sort = "supRusNum"
                If V.Count > 0 Then
                    rusCaption = GetMemberCaption(V(0).Row)
                    rusInn = C2.ToText(V(0)("inn"))
                End If
                V.RowFilter = "supNusNum > 0"
                V.Sort = "supNusNum"
                If V.Count > 0 Then nusCaption = GetMemberCaption(V(0).Row)
                V.RowFilter = "supEndNum > 0"
                V.Sort = "supEndNum"
                If V.Count > 0 Then endCaption = GetMemberCaption(V(0).Row)
            End Using
            memberEmbargoId = If(W.MemberEmbargoTable.Rows.Count > 0, 1, 0)
            countryCaption = GetCountryCaption()
            countryCaption2 = GetCountryCaption2()
            W.EmbargoCountryHandbookTable.DefaultView.RowFilter = String.Format("countryId = {0}", C2.ToInt(W.ARow("countryId")))
            countryEmbargoId = If(W.EmbargoCountryHandbookTable.DefaultView.Count > 0, 1, 0)
            '
            ' Цикл по объекта экспертизы из работы
            '
            For Each GoodRow As DataRow In W.GoodTable.Rows
                '
                ' Реквизиты работы
                '
                ReportRow = Me.NewRow
                ReportRow("workId") = W.Id
                ReportRow("clientCaption") = clientCaption
                ReportRow("contractNum") = contractNum
                ReportRow("contractDate") = contractDate
                ReportRow("rusCaption") = rusCaption
                ReportRow("rusInn") = rusInn
                ReportRow("nusCaption") = nusCaption
                ReportRow("endCaption") = endCaption
                ReportRow("memberEmbargoId") = memberEmbargoId
                ReportRow("countryEmbargoId") = countryEmbargoId
                ReportRow("countryCaption") = countryCaption
                ReportRow("countryCaption2") = countryCaption2
                ReportRow("isExport") = (CType(W.ARow("modeId"), Cprp.DxData.ModeEnum) <> ModeEnum.isImport)
                '
                ' Реквизиты заключения
                '
                If CBool(GoodRow("isDoc1")) Then
                    ReportRow("docNum") = W.ARow("doc1RegNum")
                    ReportRow("docDate") = W.ARow("doc1RegDate")
                    ReportRow("docSummaryId") = W.ARow("doc1SummaryId")
                Else
                    ReportRow("docNum") = W.ARow("doc2RegNum")
                    ReportRow("docDate") = W.ARow("doc2RegDate")
                    ReportRow("docSummaryId") = W.ARow("doc2SummaryId")
                End If
                If CType(ReportRow("docSummaryId"), Cprp.DxData.Work.WorkSummary) <> WorkSummary.IsFreedom Then
                    ReportRow("docSummary") = C2.ToText(W.ARow("summaryText"))
                End If
                If CType(ReportRow("docSummaryId"), Cprp.DxData.Work.WorkSummary) = WorkSummary.IsLicense Then
                    ReportRow("docTermId") = 0
                Else
                    ReportRow("docTermId") = 1
                    ReportRow("docTerm") = W.ARow("docTerm")
                End If
                '
                ' Реквизиты объекта экспертизы
                '
                ReportRow("goodId") = GoodRow("id")
                ReportRow("goodName") = GoodRow("nameCon")
                ReportRow("goodTnved") = GoodRow("tnved")
                ReportRow("goodCategory") = GoodRow("categoryId")
                If C2.ToInt(ReportRow("goodCategory")) = 10 Then ReportRow("goodCategory") = 0
                ReportRow("goodDescription") = GoodRow("description")
                ReportRow("goodUsed") = GetGoodUsed(GoodRow)
                ReportRow("goodSummaryId") = GoodRow("studySummaryId")
                If CType(ReportRow("goodSummaryId"), Cprp.DxData.Law.StudyIndexEnum) <> Law.StudyIndexEnum.IsNothing Then
                    ReportRow("goodLawPos") = GetGoodLawPos(GoodRow)
                    ReportRow("goodLawList") = GetGoodLawList(ReportRow)
                    SetGoodLaw(ReportRow)
                End If
                W.GoodEmbargoTable.DefaultView.RowFilter = String.Format("goodId = {0}", CInt(GoodRow("id")))
                ReportRow("goodEmbargoId") = If(W.GoodEmbargoTable.DefaultView.Count > 0, 1, 0)
                '
                ' Добавление строки в таблицу отчета
                '
                Me.Rows.Add(ReportRow)
            Next
        Next
        Me.AcceptChanges()
        '
        ' Проверка отчета на формальные ошибки
        '
        For Each Row In Me.Rows
            For Each Col As DataColumn In Me.Columns
                Select Case Col.ColumnName
                    Case "clientCaption", "rusCaption", "rusInn", "memberEmbargoId", "countryCaption", "countryEmbargoId", _
                        "docNum", "docDate", "docSummaryId", "docTermId", "goodName", "goodTnved", "goodCategory", _
                        "goodDescription", "goodSummaryId", "goodEmbargoId"
                        Row("isBad") = Not C2.IsText(Row(Col))
                        If CBool(Row("isBad")) Then Exit For
                End Select
            Next
        Next
        Me.AcceptChanges()
        'Catch ex As Exception
        '    Throw ex
        'Finally
        If Not WorkIdTable Is Nothing Then WorkIdTable.Dispose()
        'End Try
    End Sub

    ''' <summary>
    ''' Возвращает наименование и реквизиты заказчика экспертизы в текущей работе
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetClientCaption() As String
        If W Is Nothing OrElse W.IsEmpty Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        sTmp = C2.ToText(W("clientName"))
        If Not C2.IsText(sTmp) Then Return Nothing
        sTmp1 = C2.ToText(W("clientAddress"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(W("clientInn"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, ИНН: {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(W("clientPhone"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, тел: {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(W("clientFax"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, факс: {1}", sTmp, sTmp1)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает наименование и реквизиты лица
    ''' </summary>
    ''' <param name="MemberRow">Строка таблицы лиц</param>
    ''' <remarks></remarks>
    Private Function GetMemberCaption(MemberRow As DataRow) As String
        If W Is Nothing OrElse W.IsEmpty Then Return Nothing
        If MemberRow Is Nothing OrElse Not MemberRow.Table Is W.MemberTable Then Return Nothing
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        sTmp = C2.ToText(MemberRow("nameLong"))
        If Not C2.IsText(sTmp) Then Return Nothing
        Row = W.CountryHandbookTable.Rows.Find(C2.ToInt(MemberRow("addressLegalCountryId")))
        If Not Row Is Nothing Then sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(Row("nameShort")))
        sTmp1 = C2.ToText(MemberRow("addressLegalFull"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(MemberRow("inn"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, ИНН: {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(MemberRow("kpp"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, КПП: {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(MemberRow("phone"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, тел: {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(MemberRow("fax"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, факс: {1}", sTmp, sTmp1)
        Return sTmp

    End Function

    ''' <summary>
    ''' Возвращает наименование страны НАЗНАЧЕНИЯ
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetCountryCaption() As String
        If W Is Nothing OrElse W.IsEmpty Then Return Nothing
        If CType(W.ARow("modeId"), Cprp.DxData.ModeEnum) = ModeEnum.isImport Then
            Return "РОССИЯ (Российская Федерация)"
        End If
        Dim Row As DataRow = W.CountryHandbookTable.Rows.Find(C2.ToInt(W.ARow("countryId")))
        If Row Is Nothing Then Return Nothing
        Dim sTmp As String = C2.ToText(Row("nameShort"))
        Dim sTmp1 As String = C2.ToText(Row("nameLong"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0} ({1})", sTmp, sTmp1)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает наименование страны ОТПРАВЛЕНИЯ
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetCountryCaption2() As String
        If W Is Nothing OrElse W.IsEmpty Then Return Nothing
        If CType(W.ARow("modeId"), Cprp.DxData.ModeEnum) <> ModeEnum.isImport Then
            Return "РОССИЯ (Российская Федерация)"
        End If
        Dim Row As DataRow = W.CountryHandbookTable.Rows.Find(C2.ToInt(W.ARow("countryId")))
        If Row Is Nothing Then Return Nothing
        Dim sTmp As String = C2.ToText(Row("nameShort"))
        Dim sTmp1 As String = C2.ToText(Row("nameLong"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0} ({1})", sTmp, sTmp1)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает назначение и область применения объекта экспертизы
    ''' </summary>
    ''' <param name="GoodRow">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Private Function GetGoodUsed(GoodRow As DataRow) As String
        If W Is Nothing OrElse W.IsEmpty Then Return Nothing
        If GoodRow Is Nothing OrElse Not GoodRow.Table Is W.GoodTable Then Return Nothing
        Dim sTmp As String = C2.DelPoint(GoodRow("used"))
        If Not C2.IsText(sTmp) Then sTmp = C2.DelPoint(W.ARow("goodUsed"))
        If Not C2.IsText(sTmp) Then Return Nothing
        sTmp = String.Format("Назначение: {0}", sTmp)
        Dim sTmp1 As String = C2.DelPoint(GoodRow("area"))
        If Not C2.IsText(sTmp1) Then sTmp1 = C2.DelPoint(W.ARow("goodArea"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}. Область применения: {1}", sTmp, sTmp1)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень пунктов контрольных списков, в отношении которых прводился сравнительный анализ объекта экспертизы
    ''' </summary>
    ''' <param name="GoodRow">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Private Function GetGoodLawPos(GoodRow As DataRow) As String
        If W Is Nothing OrElse W.IsEmpty Then Return Nothing
        If GoodRow Is Nothing OrElse Not GoodRow.Table Is W.GoodTable Then Return Nothing
        Dim sTmp As String = "0"
        Using V As New DataView(W.GoodLawTable)
            V.RowFilter = String.Format("goodId = {0} AND summaryId = {1} ", CInt(GoodRow("id")), CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
            If V.Count = 0 Then
                V.RowFilter = String.Format("goodId = {0} AND summaryId = {1} ", CInt(GoodRow("id")), CInt(Cprp.DxData.Law.StudyIndexEnum.IsOther))
            End If
            If V.Count = 0 Then Return Nothing
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}", sTmp, CInt(VRow("lawId")))
            Next
        End Using
        Dim sTmp1 As String = Nothing
        Using V As New DataView(W.LawDataSet.LawTable)
            V.RowFilter = String.Format("id IN ({0})", sTmp)
            V.Sort = "doc, id"
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                sTmp1 = C2.ToText(V(i)("doc")).Substring(0, 4)
                If i = 0 OrElse sTmp1 <> C2.ToText(V(i - 1)("doc")).Substring(4) Then
                    Select Case sTmp1
                        Case "1030" : sTmp &= "ДН: "
                        Case "1050" : sTmp &= "ЯО: "
                        Case "1070" : sTmp &= "ХО: "
                        Case "1090" : sTmp &= "РО: "
                        Case "1100" : sTmp &= "БО: "
                        Case "1130" : sTmp &= "ИС: "
                    End Select
                End If
                sTmp = String.Format("{0}{1}, ", sTmp, C2.ToText(V(i)("pos")))
            Next
        End Using
        If sTmp.Length > 0 Then sTmp = sTmp.Substring(0, sTmp.Length - 2)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень обозначений контрольных списков, в отношении которых прводился сравнительный анализ объекта экспертизы
    ''' </summary>
    ''' <param name="ReportRow">Строка таблицы отчета</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetGoodLawList(ReportRow As DataRow) As String
        If ReportRow Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = C2.ToText(ReportRow("goodLawPos"))
        If Not C2.IsText(sTmp1) Then Return Nothing
        If sTmp1 Like "*ДН*" Then sTmp &= ", ДН"
        If sTmp1 Like "*ЯО*" Then sTmp &= ", ЯО"
        If sTmp1 Like "*ХО*" Then sTmp &= ", ХО"
        If sTmp1 Like "*РО*" Then sTmp &= ", РО"
        If sTmp1 Like "*БО*" Then sTmp &= ", БО"
        If sTmp1 Like "*ИС*" Then sTmp &= ", ИС"
        If C2.IsText(sTmp) Then Return sTmp.Substring(2)
        Return Nothing
    End Function

    ''' <summary>
    ''' Занести в стороку отчета данные о сравнительном анализе объекта экспертизы с пунктами списков
    ''' </summary>
    ''' <param name="ReportRow">Строка отчета</param>
    ''' <remarks></remarks>
    Private Sub SetGoodLaw(ReportRow As DataRow)
        If W Is Nothing OrElse W.IsEmpty Then Exit Sub
        If ReportRow Is Nothing Then Exit Sub
        Dim lawDescription As String = Nothing
        Dim goodDescription As String = Nothing
        Using V As New DataView(W.GoodLawTable)
            V.RowFilter = String.Format("goodId = {0} AND summaryId = {1} ", CInt(ReportRow("goodId")), CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
            If V.Count = 0 Then
                V.RowFilter = String.Format("goodId = {0} AND summaryId = {1} ", CInt(ReportRow("goodId")), CInt(Cprp.DxData.Law.StudyIndexEnum.IsOther))
            End If
            If V.Count = 0 Then Exit Sub
            V.Sort = "lawId"
            For i As Integer = 0 To V.Count - 1
                lawDescription = String.Format("{0}{1}{2}", lawDescription, C2.FIELD_SEPARATOR, C2.ToText(V(i)("lawDescription")))
                goodDescription = String.Format("{0}{1}{2}", goodDescription, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodDescription")))
            Next
        End Using
        If C2.IsText(lawDescription) Then ReportRow("goodLawDescription") = lawDescription.Substring(1)
        If C2.IsText(goodDescription) Then ReportRow("goodLawCharaster") = goodDescription.Substring(1)
    End Sub

End Class
