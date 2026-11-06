Imports Cprp.DxData.Common
''' <summary>
''' Таблица отчета в ФСТЭК
''' </summary>
Public Class ReportDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("ReportTable")
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID строки в таблице, первичный ключ, автоинкремент
            .Add("isBad", GetType(Boolean))             ' Строка содержит неполные данные
            ' Работа
            .Add("workId", GetType(Integer))            ' ID работы
            .Add("clientCaption", GetType(String))      ' Наименование и реквизиты заказчика экспертизы
            .Add("contractNum", GetType(String))        ' Номер контракта
            .Add("contractDate", GetType(Date))         ' Дата контракта
            .Add("contractTerm", GetType(Date))         ' Срок действия контракта
            .Add("contractTermId", GetType(Integer))    ' Идентификатор срока действия контракта
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
            .Add("goodId", GetType(Integer))            ' ID объекта экспертизы
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
    End Sub

    ''' <summary>
    ''' Загрузить данные из источника данных отчета
    ''' </summary>
    ''' <param name="Ds">Источник данных отчета</param>
    Public Sub LoadData(Ds As ReportDataSet)
        Me.Rows.Clear()
        If Ds Is Nothing OrElse Ds.DocTable.Rows.Count = 0 Then Exit Sub
        Dim Row As DataRow = Nothing
        Dim clientCaption As String = Nothing
        Dim rusCaption As String = Nothing
        Dim nusCaption As String = Nothing
        Dim endCaption As String = Nothing
        Dim DocView As DataView = Nothing
        Dim GoodView As DataView = Nothing
        Dim LawView As DataView = Nothing
        Dim EndView As DataView = Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Try
            DocView = New DataView(Ds.DocTable) With {.Sort = "num"}
            GoodView = New DataView(Ds.GoodTable) With {.Sort = "num"}
            LawView = New DataView(Ds.GoodLawTable) With {.Sort = "lawDoc, lawId"}
            EndView = New DataView(Ds.EndTable) With {.Sort = "num"}
            For i As Integer = 0 To DocView.Count - 1
                clientCaption = String.Format("{0}, {1}, ИНН: {2}", ToText(DocView(i)("clientName")), ToText(DocView(i)("clientAddress")), ToText(DocView(i)("clientInn")))
                If Not IsDBNull(DocView(i)("clientPhone")) Then clientCaption = String.Format("{0}, тел: {1}", clientCaption, ToText(DocView(i)("clientPhone")))
                If Not IsDBNull(DocView(i)("clientFax")) Then clientCaption = String.Format("{0}, факс: {1}", clientCaption, ToText(DocView(i)("clientFax")))
                rusCaption = Nothing
                If Not IsDBNull(DocView(i)("rusName")) Then
                    rusCaption = ToText(DocView(i)("rusName"))
                    If Not IsDBNull(DocView(i)("rusAddress")) Then rusCaption = String.Format("{0}, {1}", rusCaption, ToText(DocView(i)("rusAddress")))
                    If Not IsDBNull(DocView(i)("rusInn")) Then rusCaption = String.Format("{0}, ИНН: {1}", rusCaption, ToText(DocView(i)("rusInn")))
                End If
                nusCaption = Nothing
                If Not IsDBNull(DocView(i)("nusName")) Then
                    nusCaption = ToText(DocView(i)("nusName"))
                    If Not IsDBNull(DocView(i)("nusAddress")) Then nusCaption = String.Format("{0}, {1}", nusCaption, ToText(DocView(i)("nusAddress")))
                End If
                endCaption = Nothing
                EndView.RowFilter = String.Format("docGuid = '{0}'", ToText(DocView(i)("guid")))
                If EndView.Count > 0 Then endCaption = String.Format("{0}, {1}", ToText(EndView(0)("name")), ToText(EndView(0)("address")))
                GoodView.RowFilter = String.Format("docGuid = '{0}'", ToText(DocView(i)("guid")))
                For j As Integer = 0 To GoodView.Count - 1
                    Row = Me.NewRow
                    Row("isBad") = False
                    Row("workId") = DocView(i)("workId")
                    Row("clientCaption") = clientCaption
                    Row("contractNum") = DocView(i)("conNum")
                    Row("contractDate") = DocView(i)("conDate")
                    Row("contractTerm") = DocView(i)("conTerm")
                    Row("contractTermId") = DocView(i)("conTermId")
                    Row("rusCaption") = rusCaption
                    Row("rusInn") = DocView(i)("rusInn")
                    Row("nusCaption") = nusCaption
                    Row("endCaption") = endCaption
                    Row("memberEmbargoId") = If(CBool(DocView(i)("isNusEmbargo")), "1", "0")
                    Row("isExport") = DocView(i)("isExport")
                    If CBool(Row("isExport")) Then
                        Row("countryCaption") = DocView(i)("countryName")
                        Row("countryCaption2") = "РОССИЯ (Российская Федерация)"
                    Else
                        Row("countryCaption") = "РОССИЯ (Российская Федерация)"
                        Row("countryCaption2") = DocView(i)("countryName")
                    End If
                    Row("countryEmbargoId") = If(CBool(DocView(i)("isCountryEmbargo")), "1", "0")
                    Row("docNum") = DocView(i)("docNum")
                    Row("docDate") = DocView(i)("docDate")
                    Row("docTerm") = DocView(i)("docTerm")
                    Row("docTermId") = DocView(i)("docTermId")
                    Row("docSummaryId") = DocView(i)("sumId")
                    If CType(Row("docSummaryId"), Cprp.DxData.Work.WorkSummary) <> Cprp.DxData.Work.WorkSummary.IsFreedom Then
                        Row("docSummary") = DocView(i)("sum")
                    End If
                    ' сведения об аннулировании заключения
                    If ToText(DocView(i)("dopInfo")).ToLower Like "заключение аннулировано*" Then
                        Row("docSummary") = DocView(i)("dopInfo")
                    End If
                    Row("goodId") = GoodView(j)("num")
                    Row("goodName") = GoodView(j)("name")
                    Row("goodTnved") = GoodView(j)("tnved")
                    Row("goodCategory") = GoodView(j)("catNum")
                    Row("goodDescription") = GoodView(j)("description")
                    Row("goodUsed") = GoodView(j)("used")
                    Row("goodSummaryId") = GoodView(j)("lawSumId")
                    Row("goodLawList") = GoodView(j)("lawList")
                    Row("goodLawPos") = GoodView(j)("lawPos")
                    sTmp = Nothing
                    sTmp1 = Nothing
                    LawView.RowFilter = String.Format("goodGuid = '{0}'", ToText(GoodView(j)("guid")))
                    For k As Integer = 0 To LawView.Count - 1
                        sTmp = String.Format("{0}{1}{2}", sTmp, FIELD_SEPARATOR, ToText(LawView(k)("lawDescription")))
                        sTmp1 = String.Format("{0}{1}{2}", sTmp1, FIELD_SEPARATOR, ToText(LawView(k)("goodDescription")))
                    Next
                    If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = sTmp.Substring(1)
                    If Not String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = sTmp1.Substring(1)
                    Row("goodLawDescription") = sTmp
                    Row("goodLawCharaster") = sTmp1
                    Row("goodEmbargoId") = If(CBool(GoodView(j)("isEmbargo")), "1", "0")
                    Me.Rows.Add(Row)
                Next
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not DocView Is Nothing Then DocView.Dispose()
            If Not GoodView Is Nothing Then GoodView.Dispose()
            If Not LawView Is Nothing Then LawView.Dispose()
            If Not EndView Is Nothing Then EndView.Dispose()
        End Try
    End Sub


End Class
