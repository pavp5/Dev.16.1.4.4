Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица-строка критериев поиска
''' </summary>
''' <remarks></remarks>
Friend Class FindConditionDataRow : Inherits Cprp.DxData.Base.BaseDataRow

    Friend Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))                    ' Первичный ключ
            .Add("unionId", GetType(Integer))               ' Идентификатор условия объединения критериев поиска
            .Add("workId", GetType(Integer))                ' Работа - Номер работы
            .Add("workTypeId", GetType(Integer))            ' Работа - Идентификатор вида услуги
            .Add("workKindId", GetType(Integer))            ' Работа - Идентификатор характеристики экспертизы
            .Add("workExpertId", GetType(Integer))          ' Работа - Идентификатор исполнителя (эксперта)
            .Add("workManagerId", GetType(Integer))         ' Работа - Идентификатор менеджера
            .Add("workLeaderId", GetType(Integer))          ' Работа - Идентификатор руководителя
            .Add("workDescription", GetType(String))        ' Работа - Краткие сведения о работе
            .Add("workSummaryId", GetType(Integer))         ' Работа - Идентификатор выводов экспертизы
            .Add("isAsk", GetType(Boolean))                 ' Работа - Отправлялся запрос
            .Add("orderNum", GetType(String))               ' Заказ - Номер заказа
            .Add("orderDateB", GetType(Date))               ' Заказ - Дата заказа (от)
            .Add("orderDateE", GetType(Date))               ' Заказ - Дата заказа (до)
            .Add("clientName", GetType(String))             ' Заказчик - Наименование
            .Add("clientAddress", GetType(String))          ' Заказчик - Адрес
            .Add("clientInn", GetType(String))              ' Заказчик - ИНН
            .Add("outDocNum", GetType(String))              ' Заключение - Номер заключения
            .Add("outDocDateB", GetType(Date))              ' Заключение - Дата заключения (от)
            .Add("outDocDateE", GetType(Date))              ' Заключение - Дата заключения (до)
            .Add("modeId", GetType(Integer))                ' Внешнеэкономическая операция - Идентификатор направления перемещения
            .Add("countryId", GetType(Integer))             ' Внешнеэкономическая операция - Идентификатор страны назначения (отправления)
            .Add("contractName", GetType(String))           ' Документ-основание операции - Наименование документа
            .Add("contractNum", GetType(String))            ' Документ-основание операции - Номер документа
            .Add("contractDateB", GetType(Date))            ' Документ-основание операции - Дата документа (от)
            .Add("contractDateE", GetType(Date))            ' Документ-основание операции - Дата документа (до)
            .Add("rusName", GetType(String))                ' Российский участник операции (сделки) - Наименование
            .Add("rusAddress", GetType(String))             ' Российский участник операции (сделки) - Адрес
            .Add("rusInn", GetType(String))                 ' Российский участник операции (сделки) - ИНН
            .Add("nusName", GetType(String))                ' Иностранный участник операции (сделки) - Наименование
            .Add("nusCountryId", GetType(Integer))          ' Иностранный участник операции (сделки) - Идентификатор страны юридического адреса
            .Add("nusAddress", GetType(String))             ' Иностранный участник операции (сделки) - Юридический адрес
            .Add("goodNameCon", GetType(String))            ' Объект экспертизы - Коммерческое наименование
            .Add("goodNameDec", GetType(String))            ' Объект экспертизы - Обозначение
            .Add("goodTnved", GetType(String))              ' Объект экспертизы - Код ТН ВЭД
            .Add("goodCas", GetType(String))                ' Объект экспертизы - Номер CAS
            .Add("goodCategoryId", GetType(Integer))        ' Объект экспертизы - Идентификатор вида объекта
            .Add("goodArea", GetType(String))               ' Объект экспертизы - Область применения
            .Add("goodUsed", GetType(String))               ' Объект экспертизы - Назначение
            .Add("goodDescription", GetType(String))        ' Объект экспертизы - Техническое описание
            .Add("goodSummaryId", GetType(Integer))         ' Объект экспертизы - Идентификатор результатов исследования
            .Add("inDocCaption", GetType(String))           ' Представленный документ - Заголовок или краткое содержание
            .Add("inDocNum", GetType(String))               ' Представленный документ - Номер
            .Add("inDocDateB", GetType(Date))               ' Представленный документ - Дата (от)
            .Add("inDocDateE", GetType(Date))               ' Представленный документ - Дата (до)
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("unionId")
            .AllowDBNull = False
            .DefaultValue = 1                               ' <И>
        End With
        With Me.Columns("isAsk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        DataClear()
    End Sub

    ''' <summary>
    ''' Очистить критерии поиска от всех данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataClear()
        Me.Rows.Clear()
        Me.Rows.Add(Me.NewRow)
    End Sub

    ''' <summary>
    ''' Строка запроса на выборку данных
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetQuery As String
        Get
            If Me.IsEmpty Then Return Nothing
            'C2.UpdateEmptyStringFields(Me)
            Dim sTmp As String, dTmp As Date, dTmp1 As Date
            '
            ' Возвращаемое значение
            '
            Dim GetStr As String = Nothing
            '
            ' Условие объединения критериев поиска
            '
            Dim UN As String = Chr(1)
            '
            ' Подзапрос на выборку данных из tWork
            '
            sTmp = Nothing
            If Not IsDBNull(Me("workId")) Then sTmp = String.Format("{0} workId = {1} {2}", sTmp, CInt(Me("workId")), UN)
            If Not IsDBNull(Me("workTypeId")) Then sTmp = String.Format("{0} typeId = {1} {2}", sTmp, CInt(Me("workTypeId")), UN)
            If Not IsDBNull(Me("workKindId")) Then sTmp = String.Format("{0} kindId = {1} {2}", sTmp, CInt(Me("workKindId")), UN)
            If Not IsDBNull(Me("workExpertId")) Then sTmp = String.Format("{0} expertId = {1} {2}", sTmp, CInt(Me("workExpertId")), UN)
            If Not IsDBNull(Me("workManagerId")) Then sTmp = String.Format("{0} managerId = {1} {2}", sTmp, CInt(Me("workManagerId")), UN)
            If Not IsDBNull(Me("workLeaderId")) Then sTmp = String.Format("{0} leaderId = {1} {2}", sTmp, CInt(Me("workLeaderId")), UN)
            If Not IsDBNull(Me("workDescription")) Then sTmp = String.Format("{0} description LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("workDescription")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("workSummaryId")) Then sTmp = String.Format("{0} summaryId = {1} {2}", sTmp, CInt(Me("workSummaryId")), UN)
            If Not IsDBNull(Me("isAsk")) AndAlso CBool(Me("isAsk")) Then sTmp = String.Format("{0} isAsk = 1 {1}", sTmp, UN)
            If Not IsDBNull(Me("orderNum")) Then sTmp = String.Format("{0} orderNum LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("orderNum")).ToUpper.Replace("'", "''"), UN)
            If Not (IsDBNull(Me("orderDateB")) AndAlso IsDBNull(Me("orderDateE"))) Then
                dTmp = CDate("01.01.2013")
                dTmp1 = CDate("01.01.9999")
                If Not IsDBNull(Me("orderDateB")) Then dTmp = CDate(Me("orderDateB"))
                If Not IsDBNull(Me("orderDateE")) Then dTmp1 = CDate(Me("orderDateE")).AddDays(1)
                sTmp = String.Format("{0} (orderDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND orderDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}) {3}", sTmp, dTmp, dTmp1, UN)
            End If
            If Not IsDBNull(Me("clientName")) Then sTmp = String.Format("{0} clientName LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("clientName")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("clientAddress")) Then sTmp = String.Format("{0} clientAddress LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("clientAddress")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("clientInn")) Then sTmp = String.Format("{0} clientInn LIKE '{1}%' {2}", sTmp, C2.ToText(Me("clientInn")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("modeId")) Then sTmp = String.Format("{0} isExport = {1} {2}", sTmp, If(CInt(Me("modeId")) = 1, 1, 0), UN)
            If Not IsDBNull(Me("countryId")) Then sTmp = String.Format("{0} countryId = {1} {2}", sTmp, CInt(Me("countryId")), UN)
            If Not IsDBNull(Me("contractName")) Then sTmp = String.Format("{0} contractName LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("contractName")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("contractNum")) Then sTmp = String.Format("{0} contractNum LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("contractNum")).ToUpper.Replace("'", "''"), UN)
            If Not (IsDBNull(Me("contractDateB")) AndAlso IsDBNull(Me("contractDateE"))) Then
                dTmp = CDate("01.01.2013")
                dTmp1 = CDate("01.01.9999")
                If Not IsDBNull(Me("contractDateB")) Then dTmp = CDate(Me("contractDateB"))
                If Not IsDBNull(Me("contractDateE")) Then dTmp1 = CDate(Me("contractDateE")).AddDays(1)
                sTmp = String.Format("{0} (contractDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND contractDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}) {3}", sTmp, dTmp, dTmp1, UN)
            End If
            ' Подзапрос на выборку данных из tWork
            If C2.IsText(sTmp) Then
                GetStr = String.Format("({0}) {1}", Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
            End If
            '
            ' Подзапрос на выборку id работ из tOutDoc
            '
            sTmp = Nothing
            If Not IsDBNull(Me("outDocNum")) Then sTmp = String.Format("{0} regNum LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("outDocNum")).ToUpper.Replace("'", "''"), UN)
            If Not (IsDBNull(Me("outDocDateB")) AndAlso IsDBNull(Me("outDocDateE"))) Then
                dTmp = CDate("01.01.2013")
                dTmp1 = CDate("01.01.9999")
                If Not IsDBNull(Me("outDocDateB")) Then dTmp = CDate(Me("outDocDateB"))
                If Not IsDBNull(Me("outDocDateE")) Then dTmp1 = CDate(Me("outDocDateE")).AddDays(1)
                sTmp = String.Format("{0} (regDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND regDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}) {3}", sTmp, dTmp, dTmp1, UN)
            End If
            ' Подзапрос на выборку id работ из tOutDoc
            If C2.IsText(sTmp) Then
                GetStr = String.Format("{0} id IN (SELECT workId FROM tOutDoc WHERE {1}) {2}", GetStr, Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
            End If
            '
            ' Подзапрос на выборку id работ из tMember (российские лица)
            '
            sTmp = Nothing
            If Not IsDBNull(Me("rusName")) Then sTmp = String.Format("{0} (nameLong LIKE '%{1}%' OR nameShort LIKE '%{1}%') {2}", sTmp, C2.ToText(Me("rusName")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("rusAddress")) Then sTmp = String.Format("{0} addressFull LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("rusAddress")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("rusInn")) Then sTmp = String.Format("{0} inn LIKE '{1}%' {2}", sTmp, C2.ToText(Me("rusInn")).ToUpper.Replace("'", "''"), UN)
            ' Подзапрос на выборку id работ из tMember (российские лица)
            If C2.IsText(sTmp) Then
                GetStr = String.Format("{0} id IN (SELECT workId FROM tMember WHERE {1}) {2}", GetStr, Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
            End If
            '
            ' Подзапрос на выборку id работ из tMember (иностранные лица)
            '
            sTmp = Nothing
            If Not IsDBNull(Me("nusName")) Then sTmp = String.Format("{0} (nameLong LIKE '%{1}%' OR nameShort LIKE '%{1}%') {2}", sTmp, C2.ToText(Me("nusName")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("nusAddress")) Then sTmp = String.Format("{0} addressFull LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("nusAddress")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("nusCountryId")) Then sTmp = String.Format("{0} addressCountryId = {1} {2}", sTmp, CInt(Me("nusCountryId")), UN)
            ' Подзапрос на выборку id работ из tMember (иностранные лица)
            If C2.IsText(sTmp) Then
                GetStr = String.Format("{0} id IN (SELECT workId FROM tMember WHERE {1}) {2}", GetStr, Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
            End If
            '
            ' Подзапрос на выборку id работ из tGood
            '
            sTmp = Nothing
            If Not IsDBNull(Me("goodNameCon")) Then sTmp = String.Format("{0} nameCon LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodNameCon")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodNameDec")) Then sTmp = String.Format("{0} nameDec LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodNameDec")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodTnved")) Then sTmp = String.Format("{0} tnved LIKE '{1}%' {2}", sTmp, C2.ToText(Me("goodTnved")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodCas")) Then sTmp = String.Format("{0} cas LIKE '{1}%' {2}", sTmp, C2.ToText(Me("goodCas")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodCategoryId")) Then sTmp = String.Format("{0} typeId = {1} {2}", sTmp, CInt(Me("goodCategoryId")), UN)
            If Not IsDBNull(Me("goodArea")) Then sTmp = String.Format("{0} area LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodArea")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodUsed")) Then sTmp = String.Format("{0} used LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodUsed")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodDescription")) Then sTmp = String.Format("{0} description LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodDescription")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("goodSummaryId")) Then sTmp = String.Format("{0} studyIndex = {1} {2}", sTmp, CInt(Me("goodSummaryId")), UN)
            ' Подзапрос на выборку id работ из tGood
            If C2.IsText(sTmp) Then
                GetStr = String.Format("{0} id IN (SELECT workId FROM tGood WHERE {1}) {2}", GetStr, Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
            End If
            '
            ' Подзапрос на выборку id работ из tInDoc
            '
            sTmp = Nothing
            If Not IsDBNull(Me("inDocCaption")) Then sTmp = String.Format("{0} caption LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("inDocCaption")).ToUpper.Replace("'", "''"), UN)
            If Not IsDBNull(Me("inDocNum")) Then sTmp = String.Format("{0} regNum LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("inDocNum")).ToUpper.Replace("'", "''"), UN)
            If Not (IsDBNull(Me("inDocDateB")) AndAlso IsDBNull(Me("inDocDateE"))) Then
                dTmp = CDate("01.01.2013")
                dTmp1 = CDate("01.01.9999")
                If Not IsDBNull(Me("inDocDateB")) Then dTmp = CDate(Me("inDocDateB"))
                If Not IsDBNull(Me("inDocDateE")) Then dTmp1 = CDate(Me("inDocDateE")).AddDays(1)
                sTmp = String.Format("{0} (regDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND regDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}) {3}", sTmp, dTmp, dTmp1, UN)
            End If
            ' Подзапрос на выборку id работ из tInDoc
            If C2.IsText(sTmp) Then
                GetStr = String.Format("{0} id IN (SELECT workId FROM tInDoc WHERE {1}) {2}", GetStr, Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
            End If
            '
            ' Возвращаемое значение
            '
            If Not C2.IsText(GetStr) Then Return Nothing
            GetStr = GetStr.Substring(0, GetStr.Length - 2).Replace(UN, If(CInt(Me("unionId")) = 1, "AND", "OR"))
            Return String.Format("SELECT * FROM vWorkData WHERE {0}", GetStr)

        End Get
    End Property


End Class
