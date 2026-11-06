Imports Cprp.DxData
Imports Cprp.DxData.Common
Imports Cprp.DxData.Work
Imports Cprp.DxData.Law
''' <summary>
''' Источник данных отчета
''' </summary>
Public Class ReportDataSet : Inherits DataSet

    ''' <summary>
    ''' Таблица заключений
    ''' </summary>
    Public DocTable As DocDataTable = Nothing

    ''' <summary>
    ''' Таблица объектов экспертизы
    ''' </summary>
    Public GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Таблица исследований объектов экспертизы
    ''' </summary>
    Public GoodLawTable As GoodLawDataTable = Nothing

    ''' <summary>
    ''' Таблица конечных пользователей
    ''' </summary>
    Public EndTable As EndDataTable = Nothing

    ''' <summary>
    ''' Таблица подписантов заключений
    ''' </summary>
    Public UserTable As DataTable = Nothing


    ''' <summary>
    ''' Справочник стран мира
    ''' </summary>
    Public CountryHandbookTable As CountryHandbookDataTable = Nothing

    ''' <summary>
    ''' Спраовчник категорий объектов экспертизы
    ''' </summary>
    Public GoodCategoryHandbookTable As GoodCategoryHandbookDataTable = Nothing

    ''' <summary>
    ''' Справочник заголовков контрольных списков
    ''' </summary>
    Public LawCaptionHandbookTable As LawCaptionHandbookDataTable = Nothing

    ''' <summary>
    ''' Справочник выводов экспертизы
    ''' </summary>
    Public WorkSummaryHandbookTable As WorkSummaryHandbookDataTable = Nothing


    ''' <summary>
    ''' Текущая работа с данными для загрузки
    ''' </summary>
    Private Work As Excont.WorkConnectionRow = Nothing

    ''' <summary>
    ''' Первичная работы текущей работы
    ''' </summary>
    Private PWork As Excont.WorkConnectionRow = Nothing

    ''' <summary>
    ''' Представление справочника натегорий объектов экспертизы
    ''' </summary>
    Private GoodCategoryHandbookView As DataView = Nothing

    ''' <summary>
    ''' Представление заголовков контрольных списков
    ''' </summary>
    Private LawCaptionHandbookView As DataView = Nothing

    ''' <summary>
    ''' Представление выводов экспертизы
    ''' </summary>
    Private WorkSummaryHandbookView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        MyBase.New("ReportData")
        DocTable = New DocDataTable
        GoodTable = New GoodDataTable
        GoodLawTable = New GoodLawDataTable
        EndTable = New EndDataTable
        UserTable = New UserDataTable
        Me.Tables.AddRange(New DataTable() {DocTable, GoodTable, GoodLawTable, EndTable, UserTable})
        Dim Relation As New DataRelation("DocGoodRelation", DocTable.Columns("guid"), GoodTable.Columns("docGuid"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("GoodLawRelation", GoodTable.Columns("guid"), GoodLawTable.Columns("goodGuid"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("DocEndRelation", DocTable.Columns("guid"), EndTable.Columns("docGuid"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("DocUserRelation", DocTable.Columns("guid"), UserTable.Columns("docGuid"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        CountryHandbookTable = New CountryHandbookDataTable
        CountryHandbookTable.DataLoad(Connection)
        GoodCategoryHandbookTable = New GoodCategoryHandbookDataTable
        GoodCategoryHandbookTable.DataLoad(Connection)
        LawCaptionHandbookTable = New LawCaptionHandbookDataTable
        LawCaptionHandbookTable.DataLoad(Connection)
        'LawCaptionHandbookTable.WriteXml("d:\112.xml")
        WorkSummaryHandbookTable = New WorkSummaryHandbookDataTable
        WorkSummaryHandbookTable.DataLoad(Connection)
        Work = New Excont.WorkConnectionRow(EMPTY_ID, Connection)
        PWork = New Excont.WorkConnectionRow(EMPTY_ID, Connection)
        GoodCategoryHandbookView = New DataView(GoodCategoryHandbookTable)
        LawCaptionHandbookView = New DataView(LawCaptionHandbookTable)
        WorkSummaryHandbookView = New DataView(WorkSummaryHandbookTable)
    End Sub


    ''' <summary>
    ''' Загрузить данные для отчета
    ''' </summary>
    ''' <param name="dateBegin">Дата начала отчета</param>
    ''' <param name="dateEnd">Дата конца отчета</param>
    ''' <remarks>Отчет создается по датам закрытия работ</remarks>
    Public Sub LoadData(dateBegin As Date, dateEnd As Date)
        Dim T As DataTable = Nothing
        'Try
        If dateEnd < dateBegin Then Throw New Exception("Дата конца отчета меньше даты начала.")
        T = New DataTable
        T.Load(Work.ExecuteReader(String.Format( _
            "SELECT id FROM tWork WHERE typeId = {0} AND conditionId = {1} AND " & _
            "closeDate >= {{ts '{2:yyyy-MM-dd HH:mm:ss}'}} AND closeDate < {{ts '{3:yyyy-MM-dd HH:mm:ss}'}} ", _
            CInt(WorkType.IsExCont), CInt(WorkCondition.IsClose), dateBegin, dateEnd)))
        For Each Row As DataRow In T.Rows
            Work.Id = Row("id")
            'If CInt(Work.Id) = 86418 Then Continue For
            WorkDataLoad(True)
            WorkDataLoad(False)
        Next
        'Work.Id = 102301
        'WorkDataLoad(True)
        'WorkDataLoad(False)
        'Dim arr_id As Integer() = {93101, 93353}
        'For Each id In arr_id
        '    Work.Id = id
        '    WorkDataLoad(True)
        '    WorkDataLoad(False)
        'Next

        '
        ' Поиск аннулированных заключений
        '
        Dim sTmp As String = Nothing
        Dim PRow As DataRow = Nothing
        For Each Row As DataRow In Me.DocTable.Rows
            sTmp = ToText(Row("pGuid"))
            If String.IsNullOrWhiteSpace(sTmp) Then Continue For
            PRow = Me.DocTable.Rows.Find(sTmp)
            If PRow Is Nothing Then Continue For
            PRow("dopInfo") = String.Format("заключение аннулировано, выдано новое заключение № {0} от {1:dd.MM.yyyy}", Row("docNum").ToString, CDate(Row("docDate")))
        Next

        'Catch ex As Exception
        '    Cprp.DxCommon.Messages.ShowError(ex.Message)
        'End Try
    End Sub

    ''' <summary>
    ''' Загрузить данные по заключению из работы
    ''' </summary>
    ''' <param name="isDoc1">Загрузить данные по первому заключению</param>
    Private Sub WorkDataLoad(isDoc1 As Boolean)
        If Work Is Nothing OrElse Work.IsEmpty Then Exit Sub
        'If CInt(Work.Id) = 81130 AndAlso Not isDoc1 Then Exit Sub
        'Clipboard.Clear()
        'Clipboard.SetText(Work.Id.ToString)
        With Work.GoodTable.DefaultView
            .RowFilter = String.Format("isDoc1 = {0} AND isUnreal = False", If(isDoc1, "True", "False"))
            If .Count = 0 Then Exit Sub
        End With
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        '
        ' Заключение экспертизы
        '
        Dim DocRow As DataRow = Me.DocTable.NewRow
        DocRow("workId") = CInt(Work.Id)
        ' guid
        sTmp = If(isDoc1, ToText(Work.ARow("doc1Guid")), ToText(Work.ARow("doc2Guid")))
        If Not IsText(sTmp) Then
            ' формирование и запись нового guid в работу и таблицу заключений базы данных
            sTmp = Guid.NewGuid.ToString.Replace("-", Nothing)
            If isDoc1 Then
                iTmp = ToInt(Work.ARow("doc1Id"))
                Work.ARow("doc1Guid") = sTmp
            Else
                iTmp = ToInt(Work.ARow("doc2Id"))
                Work.ARow("doc2Guid") = sTmp
            End If
            Work.DataSave()
            Work.ExecuteScalar(String.Format("UPDATE tWorkDoc SET guid = '{0}' WHERE workId = {1} AND docId = {2}", sTmp, ToInt(Work.Id), iTmp))
        End If
        DocRow("guid") = sTmp
        ' guid и номер первичного заключения
        iTmp = ToInt(Work("parentId"))
        If iTmp > 0 Then
            PWork.Id = iTmp
            DocRow("pGuid") = PWork.ARow("doc1Guid")
            DocRow("pDocNum") = PWork.ARow("doc1RegNum")
        End If
        ' номер заключения, дата заключения, выводы экспертизы, порядковый номер
        If isDoc1 Then
            DocRow("docNum") = DbText(Work.ARow("doc1RegNum"))
            DocRow("docDate") = DbDate(Work.ARow("doc1RegDate"))
            DocRow("sumId") = DbInt(Work.ARow("doc1SummaryId"))
        Else
            DocRow("docNum") = DbText(Work.ARow("doc2RegNum"))
            DocRow("docDate") = DbDate(Work.ARow("doc2RegDate"))
            DocRow("sumId") = DbInt(Work.ARow("doc2SummaryId"))
        End If
        ' если вывод № 6 то пусть будет вывод № 3
        If CType(DocRow("sumId"), WorkSummary) = WorkSummary.IsDecree Then DocRow("sumId") = CInt(WorkSummary.IsPermit)
        DocRow("sumGuid") = DbText(GetDocSummaryGuid(CType(DocRow("sumId"), WorkSummary)))
        DocRow("sum") = DbText(Work.ARow("summaryText"))
        DocRow("num") = CInt(DocRow("docNum").ToString.Substring(0, 4))
        ' реквизиты заказчика экспертизы
        If Not IsText(Work("clientName")) Then MsgBox(Work.Id.ToString)
        DocRow("clientName") = DbText(Work("clientName"), DocTable.Columns("clientName").MaxLength)
        DocRow("clientInn") = DbText(Work("clientInn"))
        DocRow("clientAddress") = DbText(Work("clientAddress"), DocTable.Columns("clientAddress").MaxLength)
        If CInt(Work.Id) = 92511 Then DocRow("clientAddress") = "194223, г. Санкт-Петербург, ул. Курчатова, д. 9 ЛИТЕР АБ, офис 260"
        DocRow("clientPhone") = DbText(Work("clientPhone"))
        DocRow("clientFax") = DbText(Work("clientFax"))
        ' направление перемещения
        DocRow("isExport") = (CType(Work.ARow("modeId"), ModeEnum) <> ModeEnum.isImport)
        ' страна назначения / отправления
        Row = Nothing
        If IsText(Work.ARow("countryIdString")) Then
            ' новый формат данных
            sTmp = ToStrNum(Work.ARow("countryIdString"), False)
            If IsText(sTmp) Then
                Using V As New DataView(Work.CountryHandbookTable)
                    V.Sort = "nameShort"
                    V.RowFilter = String.Format("id IN ({0})", sTmp)
                    If V.Count > 0 Then Row = V(0).Row
                End Using
            End If
        ElseIf IsText(Work.ARow("countryId")) Then
            ' старый формат данных
            Row = Work.CountryHandbookTable.Rows.Find(ToInt(Work.ARow("countryId")))
        End If
        If Not Row Is Nothing Then
            sTmp = Row("nameLong").ToString
            If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = String.Format(" ({0})", sTmp)
            DocRow("countryName") = ToText(Row("nameShort")) & sTmp
            DocRow("countryGuid") = DbText(Row("guid"))
            If Not IsDBNull(DocRow("countryGuid")) Then
                DocRow("countryExistId") = 2
            ElseIf CInt(Row("id")) = 999 Then   ' не определена
                DocRow("countryExistId") = 0    ' все страны
            End If
            ' признак применения спец. экономических мер к стране назначения / отправления
            With Work.EmbargoCountryHandbookTable.DefaultView
                .RowFilter = String.Format("countryId = {0} AND (modeId = {1} OR modeId = 3)", CInt(Row("id")), If(CBool(DocRow("isExport")), 1, 2))
                DocRow("isCountryEmbargo") = If(.Count > 0, True, False)
            End With
        End If
        ' реквизиты документа-основания сделки
        If Not (CBool(Work.ARow("isNotContract")) OrElse CBool(Work.ARow("isDefContract"))) Then
            DocRow("conName") = DbText(Work.ARow("contractName"), DocTable.Columns("conName").MaxLength)
            DocRow("conNum") = DbText(Work.ARow("contractNum"), DocTable.Columns("conNum").MaxLength)
            DocRow("conDate") = DbDate(Work.ARow("contractDate"))
            DocRow("conTerm") = DbDate(Work.ARow("contractTerm"))
            ' если нет срока действия, то в течении исполнения обязательств по сделке
            If IsDBNull(DocRow("conTerm")) Then DocRow("conTermId") = 1
        End If
        If CInt(Work.Id) = 102301 Then
            DocRow("conName") = "Некоммерческий инвойс"
            DocRow("conNum") = "18062026"
            DocRow("conDate") = CDate("18.06.2026")
            DocRow("conTermId") = 1
        End If
        ' реквизиты участников операции
        Using V As New DataView(Work.MemberTable)
            ' реквизиты российского участника
            V.RowFilter = "supRusNum > 0"
            V.Sort = "supRusNum"
            If V.Count > 0 Then
                DocRow("rusName") = DbText(V(0)("nameLong"))
                DocRow("rusInn") = DbText(V(0)("inn"))
                DocRow("rusAddress") = DbText(V(0)("addressLegalFull"))
            End If
            ' реквизиты иностранного участника
            V.RowFilter = "supNusNum > 0"
            V.Sort = "supNusNum"
            If V.Count > 0 Then
                DocRow("nusName") = DbText(V(0)("nameLong"), DocTable.Columns("nusName").MaxLength)
                Row = Work.CountryHandbookTable.Rows.Find(ToInt(V(0)("addressLegalCountryId")))
                sTmp = Nothing
                If Not Row Is Nothing Then sTmp = String.Format("{0}, ", ToText(Row("nameLong")))
                DocRow("nusAddress") = DbText(sTmp & ToText(V(0)("addressLegalFull")), DocTable.Columns("nusAddress").MaxLength)
                DocRow("isNusEmbargo") = If(Work.MemberEmbargoTable.Rows.Count > 0, True, False)
            End If
        End Using
        ' срок действия заключения экспертизы
        DocRow("docTerm") = DbDate(Work.ARow("docTerm"))
        '' Отчет по заключения с закончившимся сроком действия
        'If Not IsDBNull(DocRow("docTerm")) AndAlso CDate(DocRow("docTerm")) > Date.Now Then
        '    Exit Sub
        'End If

        ' если заключение не аннулируется, сформировать идентификатор срока действия
        If IsDBNull(DocRow("docTerm")) OrElse CDate(DocRow("docTerm")) > Date.Now Then
            If CType(DocRow("sumId"), WorkSummary) = WorkSummary.IsLicense OrElse CType(DocRow("sumId"), WorkSummary) = WorkSummary.IsPermit Then
                DocRow("docTerm") = DBNull.Value
                DocRow("docTermId") = DBNull.Value
            ElseIf IsDBNull(DocRow("docTerm")) Then
                If IsDBNull(DocRow("conTerm")) Then
                    DocRow("docTermId") = 0
                Else
                    DocRow("docTermId") = 1
                End If
            End If
        End If
        ' идентификатор наличия признаков продукции военного назначения
        If CBool(DocRow("isExport")) Then
            Select Case CType(DocRow("sumId"), WorkSummary)
                Case WorkSummary.IsPermit : DocRow("pvnId") = 1
                Case WorkSummary.IsLicense : DocRow("pvnId") = 2
                Case Else : DocRow("pvnId") = 0
            End Select
        Else
            DocRow("pvnId") = 2
        End If
        ' дополнительная информация
        DocRow("dopInfo") = DbText(Work.ARow("comment"), DocTable.Columns("dopInfo").MaxLength)
        DocTable.Rows.Add(DocRow)
        '
        ' Объекты экспертизы, исследование объекта экспертизы
        '
        Dim GoodRow As DataRow = Nothing
        Dim GoodLawRow As DataRow = Nothing
        With Work.GoodTable.DefaultView
            .RowFilter = String.Format("isDoc1 = {0} AND isUnreal = False", If(isDoc1, "True", "False"))
            .Sort = "parentId DESC, id ASC"
            For i As Integer = 0 To .Count - 1
                GoodRow = GoodTable.NewRow
                GoodRow("guid") = Guid.NewGuid.ToString.Replace("-", Nothing)
                GoodRow("docGuid") = DocRow("guid")
                GoodRow("num") = i + 1
                GoodRow("name") = DbText(.Item(i)("nameCon"), GoodTable.Columns("name").MaxLength)
                GoodRow("catNum") = DbInt(.Item(i)("categoryId"))
                If Not IsDBNull(GoodRow("catNum")) AndAlso CInt(GoodRow("catNum")) = 10 Then GoodRow("catNum") = 0
                GoodRow("catGuid") = GetGoodCategoryGuid(ToInt(GoodRow("catNum")))
                GoodRow("used") = DbText(GetGoodUsed(.Item(i).Row))
                GoodRow("description") = DbText(.Item(i)("description"), GoodTable.Columns("description").MaxLength)
                GoodRow("tnved") = DbText(.Item(i)("tnved"), 10)
                If Not IsDBNull(GoodRow("tnved")) AndAlso GoodRow("tnved").ToString.Length < 4 Then GoodRow("tnved") = DBNull.Value
                Work.GoodEmbargoTable.DefaultView.RowFilter = String.Format("goodId = {0}", CInt(.Item(i)("id")))
                GoodRow("isEmbargo") = If(Work.GoodEmbargoTable.DefaultView.Count > 0, True, False)
                sTmp = GetGoodLawPos(CInt(.Item(i)("id")))
                GoodRow("lawPos") = DbText(sTmp)
                GoodRow("lawList") = DbText(GetGoodLawList(sTmp))
                GoodRow("lawSumId") = .Item(i)("studySummaryId")
                GoodTable.Rows.Add(GoodRow)
                '
                ' Исследование объекта экспертизы
                '
                With Work.GoodLawTable.DefaultView
                    ' Только пункты, которые "соответствуют"
                    .RowFilter = String.Format("goodId = {0} AND summaryId = {1}", CInt(Work.GoodTable.DefaultView(i)("id")), CInt(StudyIndexEnum.IsEqual))
                    ' Если пунктов "соответствует" нет, то все пункты, с которыми производился сравнительный анализ
                    If .Count = 0 Then
                        .RowFilter = String.Format("goodId = {0} AND summaryId > {1}", CInt(Work.GoodTable.DefaultView(i)("id")), CInt(StudyIndexEnum.IsNothing))
                    End If
                    .Sort = "lawId"
                    For j As Integer = 0 To .Count - 1
                        Row = Work.LawDataSet.LawTable.Rows.Find(CInt(.Item(j)("lawId")))
                        If Row Is Nothing Then Continue For
                        sTmp = ToText(Row("doc"))
                        GoodLawRow = GoodLawTable.NewRow
                        GoodLawRow("guid") = Guid.NewGuid.ToString.Replace("-", Nothing)
                        GoodLawRow("goodGuid") = GoodRow("guid")
                        GoodLawRow("num") = j + 1
                        GoodLawRow("lawGuid") = GetLawListGuid(sTmp)
                        GoodLawRow("lawDoc") = sTmp
                        GoodLawRow("lawId") = CInt(Row("id"))
                        GoodLawRow("section") = DbText(Work.LawDataSet.GetLawSectionByDoc(sTmp))
                        GoodLawRow("pos") = DbText(Row("pos"))
                        GoodLawRow("lawDescription") = DbText(Row("posDescription"))
                        GoodLawRow("goodDescription") = DbText(.Item(j)("goodDescription"))
                        GoodLawRow("sumId") = CInt(.Item(j)("summaryId")) - 1
                        GoodLawTable.Rows.Add(GoodLawRow)
                    Next
                End With
            Next
        End With
        '
        ' Конечные пользователи
        '
        Using V As New DataView(Work.MemberTable)
            V.RowFilter = "supEndNum > 0"
            V.Sort = "supEndNum"
            For i As Integer = 0 To V.Count - 1
                Row = Work.CountryHandbookTable.Rows.Find(ToInt(V(i)("addressLegalCountryId")))
                If Row Is Nothing Then Continue For
                EndTable.Rows.Add(New Object() { _
                                  Guid.NewGuid.ToString.Replace("-", Nothing), _
                                  DocRow("guid"), _
                                  i + 1, _
                                  Row("guid"), _
                                  DbText(V(i)("nameLong")), _
                                  DbText(V(i)("addressLegalFull"))})
            Next
        End Using
        '
        ' Лицо, подписавшее заключение
        '
        If CBool(Work.ARow("isExpertSign")) Then
            sTmp = String.Format("SELECT nameLong, guid, expertDescription FROM vUser WHERE id = {0}", CInt(Work("expertId")))
        Else
            sTmp = String.Format("SELECT nameLong, guid, leaderDescription FROM vUser WHERE id = {0}", CInt(Work("leaderId")))
        End If
        Using Dr As SqlDataReader = Work.ExecuteReader(sTmp)
            If Dr.Read Then
                Dim arr() As String = ToText(Dr(0)).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                Row = UserTable.NewRow
                Row("guid") = DbText(Dr(1))
                Row("docGuid") = DocRow("guid")
                If arr.Length > 0 Then Row("nameLast") = DbText(arr(0))
                If arr.Length > 1 Then Row("nameFirst") = DbText(arr(1))
                If arr.Length > 2 Then Row("nameMiddle") = DbText(arr(2))
                Row("job") = DbText(Dr(2))
                UserTable.Rows.Add(Row)
            End If
        End Using


    End Sub


    ''' <summary>
    ''' Возвращает Guid идентификатора выводов экспертизы
    ''' </summary>
    ''' <param name="summary">Идентификатор выводов экспертизы</param>
    Private Function GetDocSummaryGuid(summary As WorkSummary) As String
        WorkSummaryHandbookView.RowFilter = String.Format("id = {0}", CInt(summary))
        If WorkSummaryHandbookView.Count > 0 Then Return WorkSummaryHandbookView(0)("guid").ToString
        Return String.Empty
        'Select Case summary
        '    Case WorkSummary.IsFreedom : Return "FDCB782F51134C519E4E758922C2BD9A"
        '    Case WorkSummary.IsLicense : Return "2A15EB0CED674EAB85F35490507341F6"
        '    Case WorkSummary.IsPermit : Return "4D82C015A29A4D39A0E7C46E2027DA33"
        '    Case WorkSummary.IsEmbargo : Return "8485A218F1714558A86C6D4D119394BE"
        '    Case WorkSummary.IsOutput : Return "5A425964438642AF87E3DA2486EC4CD4"
        '    Case Else : Return String.Empty
        'End Select
    End Function

    ''' <summary>
    ''' Возвращает Guid категории объекта экспертизы
    ''' </summary>
    ''' <param name="categoryId">ID категории объекта экспертизы</param>
    Private Function GetGoodCategoryGuid(categoryId As Integer) As String
        GoodCategoryHandbookView.RowFilter = String.Format("code = {0}", categoryId)
        If GoodCategoryHandbookView.Count > 0 Then Return GoodCategoryHandbookView(0)("guid").ToString
        Return String.Empty
        'Select Case categoryId
        '    Case 1 : Return "513A56A071B4457D9C1495DB75E434F0"
        '    Case 2 : Return "11FD18FE5C23497EACE9ED42C0690E87"
        '    Case 3 : Return "8C939D69CE0E4A86967F92AD579A0AE1"
        '    Case 4 : Return "47AD3F1A85714F29A17779B4ED585511"
        '    Case 5 : Return "A5A8A467B0EB4D7E84393349F71ED9FD"
        '    Case 6 : Return "CC4C4273240A45DC98553ED423B8BCAF"
        '    Case 7 : Return "3FA4C4C878294C6E9FF50CF9E40CA6CB"
        '    Case 8 : Return "9FDAE54C4D104ECA9BD03DB9D285A37B"
        '    Case 9 : Return "4FBE4A98F99B40A6BDCC276EEF381C32"
        '    Case 0 : Return "66E92C49113B44A391D240B9E9B10581"
        '    Case Else : Return String.Empty
        'End Select
    End Function

    ''' <summary>
    ''' Возвращает назначение и область применения объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Private Function GetGoodUsed(Row As DataRow) As String
        If Work Is Nothing OrElse Work.IsEmpty Then Return Nothing
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return Nothing
        Dim sTmp As String = DelPoint(Row("used"))
        If Not IsText(sTmp) Then sTmp = DelPoint(Work.ARow("goodUsed"))
        If Not IsText(sTmp) Then Return Nothing
        sTmp = String.Format("Назначение: {0}", sTmp)
        Dim sTmp1 As String = DelPoint(Row("area"))
        If Not IsText(sTmp1) Then sTmp1 = DelPoint(Work.ARow("goodArea"))
        If IsText(sTmp1) Then sTmp = String.Format("{0}. Область применения: {1}", sTmp, sTmp1)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает Guid контрольного списка
    ''' </summary>
    ''' <param name="doc">Шифр пункта контрольного списка</param>
    Private Function GetLawListGuid(doc As String) As String
        doc = ToText(doc)        
        If String.IsNullOrWhiteSpace(doc) Then Return String.Empty
        If doc.Length < 4 Then Return String.Empty
        doc = doc.Substring(0, 4)
        LawCaptionHandbookView.RowFilter = String.Format("doc LIKE '{0}'", doc)
        If LawCaptionHandbookView.Count > 0 Then Return LawCaptionHandbookView(0)("guid").ToString
        Return String.Empty
        'Select Case doc.Substring(0, 4)
        '    Case "1030" : Return "933C93D1B1924C4D87CE6B823F0D8D74"
        '    Case "1050" : Return "44BE22B7365744179AD68F611F4FC59F"
        '    Case "1070" : Return "FA9F6DA16BF347B9A4E4931344A96FB2"
        '    Case "1090" : Return "24CCC57BBE584AFB8904909A52233436"
        '    Case "1110" : Return "BAB4A9076E884A9C9195EB371DB78B29"
        '    Case "1130" : Return "756FDA0B32094E75A22FF155E3790A27"
        '    Case Else : Return String.Empty
        'End Select
    End Function

    ''' <summary>
    ''' Возвращает перечень пунктов контрольных списков, в отношении которых проводился сравнительный анализ объекта экспертизы
    ''' </summary>
    ''' <param name="goodId">ID объекта экспертизы из таблицы объектов экспертизы работы</param>
    Private Function GetGoodLawPos(goodId As Integer) As String
        If Work Is Nothing OrElse Work.IsEmpty Then Return Nothing
        Dim sTmp As String = "0"
        Using V As New DataView(Work.GoodLawTable)
            V.RowFilter = String.Format("goodId = {0} AND summaryId = {1} ", goodId, CInt(StudyIndexEnum.IsEqual))
            If V.Count = 0 Then
                V.RowFilter = String.Format("goodId = {0} AND summaryId = {1} ", goodId, CInt(StudyIndexEnum.IsOther))
            End If
            If V.Count = 0 Then Return String.Empty
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}", sTmp, CInt(VRow("lawId")))
            Next
        End Using
        Dim sTmp1 As String = Nothing
        Using V As New DataView(Work.LawDataSet.LawTable)
            V.RowFilter = String.Format("id IN ({0})", sTmp)
            V.Sort = "doc, id"
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                sTmp1 = ToText(V(i)("doc")).Substring(0, 4)
                If i = 0 OrElse sTmp1 <> ToText(V(i - 1)("doc")).Substring(0, 4) Then
                    Select Case sTmp1
                        Case "1030" : sTmp &= "ДН: "
                        Case "1050" : sTmp &= "ЯО: "
                        Case "1070" : sTmp &= "ХО: "
                        Case "1090" : sTmp &= "РО: "
                        Case "1110" : sTmp &= "БО: "
                        Case "1130" : sTmp &= "ИС: "
                    End Select
                End If
                sTmp = String.Format("{0}{1}, ", sTmp, ToText(V(i)("pos")))
            Next
        End Using
        If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 0 Then
            sTmp = sTmp.Substring(0, sTmp.Length - 2)
            sTmp = sTmp.Replace(", ДН", "; ДН")
            sTmp = sTmp.Replace(", ЯО", "; ЯО")
            sTmp = sTmp.Replace(", ХО", "; ХО")
            sTmp = sTmp.Replace(", РО", "; РО")
            sTmp = sTmp.Replace(", БО", "; БО")
            sTmp = sTmp.Replace(", ИС", "; ИС")
        End If
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает строку неповторяющихся обозначений контрольных списков, разделенных запятыми
    ''' </summary>
    ''' <param name="lawPos">Строка с обозначениями контрольных списков</param>
    Private Function GetGoodLawList(lawPos As String) As String
        lawPos = ToText(lawPos)
        If String.IsNullOrWhiteSpace(lawPos) Then Return String.Empty
        Dim sTmp As String = Nothing
        If lawPos Like "*ДН*" Then sTmp &= ", ДН"
        If lawPos Like "*ЯО*" Then sTmp &= ", ЯО"
        If lawPos Like "*ХО*" Then sTmp &= ", ХО"
        If lawPos Like "*РО*" Then sTmp &= ", РО"
        If lawPos Like "*БО*" Then sTmp &= ", БО"
        If lawPos Like "*ИС*" Then sTmp &= ", ИС"
        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = sTmp.Substring(2)
        Return sTmp
    End Function


End Class
