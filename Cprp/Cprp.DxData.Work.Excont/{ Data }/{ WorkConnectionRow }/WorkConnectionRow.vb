Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
Imports Cprp.DxData.Law
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Признаки риска по внешнеэкономической сделке
    ''' </summary>
    ''' <remarks></remarks>
    Public ContractRiskTable As ContractRiskDataTable = Nothing

    ''' <summary>
    ''' Признаки риска по внешнеэкономической операции
    ''' </summary>
    ''' <remarks></remarks>
    Public SupplyRiskTable As SupplyRiskDataTable = Nothing

    ''' <summary>
    ''' Участники сделки и операции
    ''' </summary>
    ''' <remarks></remarks>
    Public MemberTable As MemberDataTable = Nothing

    ''' <summary>
    ''' Запреты и ограничения участников сделки и операции
    ''' </summary>
    ''' <remarks></remarks>
    Public MemberEmbargoTable As MemberEmbargoDataTable = Nothing

    ''' <summary>
    ''' Связи участников сделки и операции с лицами на контроле
    ''' </summary>
    ''' <remarks></remarks>
    Public MemberControlTable As MemberControlDataTable = Nothing

    ''' <summary>
    ''' Признаки риска участников сделки и операции
    ''' </summary>
    ''' <remarks></remarks>
    Public MemberRiskTable As MemberRiskDataTable = Nothing

    ''' <summary>
    ''' Продукция
    ''' </summary>
    ''' <remarks></remarks>
    Public GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Запреты и ограничения в отношении продукции
    ''' </summary>
    ''' <remarks></remarks>
    Public GoodEmbargoTable As GoodEmbargoDataTable = Nothing

    ''' <summary>
    ''' Связи продукции с продукцией на контроле
    ''' </summary>
    ''' <remarks></remarks>
    Public GoodControlTable As GoodControlDataTable = Nothing

    ''' <summary>
    ''' Исследования продукции по контрольным спискам
    ''' </summary>
    ''' <remarks></remarks>
    Public GoodLawTable As GoodLawDataTable = Nothing

    ''' <summary>
    ''' Признаки риска по продукции
    ''' </summary>
    ''' <remarks></remarks>
    Public GoodRiskTable As GoodRiskDataTable = Nothing

    ''' <summary>
    ''' Пояснения эксперта к разделам заключения
    ''' </summary>
    ''' <remarks></remarks>
    Friend CommentTable As CommentDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.WorkConnectionRow
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(id As Object, Connection As SqlConnection)
        MyBase.New(Connection)
        '
        ' Arow
        '
        With MyBase.ARow.Columns
            ' Объекты экспертизы
            .Add("goodArea", GetType(String))               ' Общая область применения объектов экспертизы
            .Add("goodUsed", GetType(String))               ' Общее назначение объектов экспертизы
            ' Сделка
            .Add("isNotContract", GetType(Boolean))         ' Без договора
            .Add("isDefContract", GetType(Boolean))         ' Любой договор
            .Add("contractName", GetType(String))           ' Наименование документа-основания сделки
            .Add("contractNum", GetType(String))            ' Номер документа-основания сделки
            .Add("contractDate", GetType(Date))             ' Дата документа-основания сделки
            .Add("contractTerm", GetType(Date))             ' Срок действия документа-основания сделки
            .Add("isNotContractTerm", GetType(Boolean))     ' Срок действия документа-основания сделки отсутствует
            .Add("contractDescription", GetType(String))    ' Описание предмета сделки
            .Add("isNotContractRisk", GetType(Boolean))     ' Риски по сделке отсутствуют
            .Add("otherContractRisk", GetType(String))      ' Иные признаки риска по сделке
            ' Операция
            .Add("countryIdString", GetType(String))        ' ID стран назначения (отправления)
            .Add("countryNameString", GetType(String))      ' Наименования стран назначения (отправления)
            .Add("countryId", GetType(Integer))             ' ID страны назначения (отправления) (старый формат)
            .Add("bankCountryId", GetType(Integer))         ' ID страны банка
            .Add("supplyTypeId", GetType(Integer))          ' ID характера внешнеэкономической операции
            .Add("modeId", GetType(Integer))                ' ID направления перемещения
            .Add("incotermsId", GetType(Integer))           ' ID условия поставки по Инкотермс
            .Add("incotermsPlace", GetType(String))         ' Место доставки
            .Add("invoiceCaption", GetType(String))         ' Документ-основание внешнеэкономической операции
            .Add("supplyDescription", GetType(String))      ' Предмет внешнеэкономической операции
            .Add("isNotSupplyRisk", GetType(Boolean))       ' Риски по внешнеэкономической операции отсутствуют
            .Add("otherSupplyRisk", GetType(String))        ' Иные признаки риска по внешнеэкономической операции
            .Add("isDefNusMember", GetType(Boolean))        ' Иностранные покупатели (продавцы) без ограничений
            ' Решение по анализу
            .Add("summaryRisk", GetType(String))            ' результаты анализа выявленных рисков
            .Add("summaryId", GetType(Integer))             ' идентификатор выводов экспертизы
            .Add("summaryText", GetType(String))            ' выводы экспертизы
            ' Дополнительная информация
            .Add("kindComment", GetType(String))            ' комментарий к характеристике экспертизы
            .Add("docTerm", GetType(Date))                  ' срок действия заключений
            .Add("comment", GetType(String))                ' дополнительная информация
            ' Документ #1
            .Add("doc1Data", GetType(Byte()))               ' содержимое проекта документа (openXml)
            .Add("doc1Id", GetType(Integer))                ' порядковый номер документа в таблице базы данных
            .Add("doc1Guid", GetType(String))               ' GUID документа
            .Add("doc1RegNum", GetType(String))             ' номер документа
            .Add("doc1RegDate", GetType(Date))              ' дата документа
            .Add("doc1SummaryId", GetType(Integer))         ' ID идентификатора выводов экспертизы по документу
            .Add("ref1Data", GetType(String))               ' содержимое справки по документу (xml)
            ' Документ #2
            .Add("doc2Data", GetType(Byte()))               ' содержимое проекта документа (openXml)
            .Add("doc2Id", GetType(Integer))                ' порядковый номер документа в таблице базы данных
            .Add("doc2Guid", GetType(String))               ' GUID документа
            .Add("doc2RegNum", GetType(String))             ' номер документа
            .Add("doc2RegDate", GetType(Date))              ' дата документа
            .Add("doc2SummaryId", GetType(Integer))         ' ID идентификатора выводов экспертизы по документу
            .Add("ref2Data", GetType(String))               ' содержимое справки по документу (xml)
        End With
        With MyBase.ARow.Columns("modeId")
            .AllowDBNull = False
            .DefaultValue = Cprp.DxData.ModeEnum.isExport               ' Вывоз
        End With
        With MyBase.ARow.Columns("isNotContract")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With MyBase.ARow.Columns("isDefContract")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With MyBase.ARow.Columns("isNotContractTerm")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With MyBase.ARow.Columns("isNotContractRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With MyBase.ARow.Columns("supplyTypeId")
            .AllowDBNull = False
            .DefaultValue = 1                                           ' Экспорт товаров из России
        End With
        With MyBase.ARow.Columns("isNotSupplyRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With MyBase.ARow.Columns("isDefNusMember")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        '
        ' Другие таблицы
        '
        MemberTable = New MemberDataTable
        MemberEmbargoTable = New MemberEmbargoDataTable
        MemberControlTable = New MemberControlDataTable
        MemberRiskTable = New MemberRiskDataTable
        GoodTable = New GoodDataTable
        GoodEmbargoTable = New GoodEmbargoDataTable
        GoodControlTable = New GoodControlDataTable
        GoodLawTable = New GoodLawDataTable
        GoodRiskTable = New GoodRiskDataTable
        ContractRiskTable = New ContractRiskDataTable
        SupplyRiskTable = New SupplyRiskDataTable
        CommentTable = New CommentDataTable
        '
        ' Источник данных работы
        '
        MyBase.DS.Tables.AddRange(New DataTable() { _
                                  ContractRiskTable, SupplyRiskTable, _
                                  MemberTable, MemberEmbargoTable, MemberControlTable, MemberRiskTable, _
                                  GoodTable, GoodLawTable, GoodEmbargoTable, GoodControlTable, GoodRiskTable,
                                  CommentTable})
        '
        ' Отношения таблиц
        '
        Dim Relation As New DataRelation("MemberEmbargoRelation", MemberTable.Columns("id"), MemberEmbargoTable.Columns("memberId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("MemberControlRelation", MemberTable.Columns("id"), MemberControlTable.Columns("memberId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("MemberRiskRelation", MemberTable.Columns("id"), MemberRiskTable.Columns("memberId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("GoodEmbargoRelation", GoodTable.Columns("id"), GoodEmbargoTable.Columns("goodId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("GoodControlRelation", GoodTable.Columns("id"), GoodControlTable.Columns("goodId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("GoodLawRelation", GoodTable.Columns("id"), GoodLawTable.Columns("goodId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("GoodRiskRelation", GoodTable.Columns("id"), GoodRiskTable.Columns("goodId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        '
        ' ID
        '
        MyClass.Id = id
        '
        ' Источник данных нормативных документов
        '
        MyBase.LawDataSet.DataLoad(Me.Connection, Date.Now, True, False, False, True, True, True)

    End Sub

    ''' <summary>
    ''' ID работы
    ''' </summary>
    Public Overrides Property Id As Object
        Get
            Return MyBase.Id
        End Get
        Set(value As Object)
            MyBase.Id = value
            If MyBase.IsEmpty Then Exit Property
            'MyBase.ARow("typeId") = Cprp.DxData.Work.WorkType.IsExCont
            If CommentTable.IsEmpty Then
                CommentTable.DataInit()
            End If
            'With MyBase.WorkCommentTable
            '    .DataLoad()
            '    ' Добавление начального комментария
            '    If .Rows.Count = 0 Then
            '        Dim comment As String = C2.ToText(Me("comment"))
            '        If Not String.IsNullOrWhiteSpace(comment) Then .AddComment(CDate(Me("createDate")), 1, comment)
            '    End If
            'End With
            MyBase.DS.AcceptChanges()
        End Set
    End Property

    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    Public Overrides Sub DataSave()
        Me("countryName") = GetToCountryName()
        Me("percentCount") = GetPercentCount()
        '
        ' Актуализация запросов по сохраненным данным работы
        '
        Dim Row As DataRow = Nothing
        Using W As New WorkConnectionRow(Me.Id, Me.Connection)
            For Each BRow As DataRow In W.RequestTable.Rows
                Row = Me.RequestTable.Rows.Find(BRow("id"))
                If Row Is Nothing Then Continue For
                If CDate(BRow("changeDate")) > CDate(Row("changeDate")) Then
                    Row("conditionId") = BRow("conditionId")
                    Row("docId") = BRow("docId")
                    Row("typeId") = BRow("typeId")
                    Row("regNum") = BRow("regNum")
                    Row("regDate") = BRow("regDate")
                    Row("docData") = BRow("docData")
                    Row("term") = BRow("term")
                    Row("changeDate") = BRow("changeDate")
                End If
            Next
            Me.RequestTable.AcceptChanges()
            Me.RequestFieldsUpdate()
            Me("isAskSend") = W("isAskSend")
        End Using
        '
        ' Вызов базового метода
        '
        MyBase.DataSave()
    End Sub

    ''' <summary>
    ''' Возвращает наименования стран назначения (при ввозе - РОССИЯ)
    ''' </summary>
    Private Function GetToCountryName() As String
        If CType(Me.ARow("modeId"), Cprp.DxData.ModeEnum) = ModeEnum.isImport Then Return "РОССИЯ"
        Dim sTmp As String = C2.ToText(Me.ARow("countryIdString"))
        If Not C2.IsText(sTmp) Then Return Nothing
        Using V As New DataView(Me.CountryHandbookTable)
            V.RowFilter = String.Format("id IN ({0})", C2.ToStrNum(sTmp, False))
            V.Sort = "nameShort"
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}, {1}", sTmp, V(i)("nameShort").ToString)
            Next
        End Using
        If C2.IsText(sTmp) Then sTmp = sTmp.Substring(2)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает процент выполнения работы
    ''' </summary>
    Private Function GetPercentCount() As Integer
        Dim percentCount As Integer = 0
        ' Если есть хоть 1 товар -> +10%
        If Me.GoodTable.Rows.Count > 0 Then percentCount += 10
        ' Учет товаров, по которым составлены техописания и завершены исследования
        If Me.GoodTable.Rows.Count > 0 Then
            Using V As New DataView(Me.GoodTable)
                V.RowFilter = "isCheckData = True AND isCheckStudy = True"
                ' Процент за завершенные товары (если все товары завершены, то 90 %)
                percentCount += CInt(90 * V.Count / Me.GoodTable.Rows.Count)
            End Using
        End If
        Return percentCount
    End Function

    ''' <summary>
    ''' Загрузить данные из файла работы
    ''' </summary>
    ''' <param name="filePath">Путь к файлу с данными работы</param> 
    ''' <param name="loadSupply">Загрузить данные внешнеэкономической операции</param> 
    ''' <param name="loadGood">Загрузить данные продукции</param> 
    ''' <param name="loadInDoc">Загрузить данные использованных документов</param> 
    ''' <param name="loadDocument">Загрузить содержимое документов по работе</param> 
    ''' <remarks></remarks>
    Public Overloads Sub ReadXml(filePath As String, loadSupply As Boolean, loadGood As Boolean, loadInDoc As Boolean, loadDocument As Boolean)
        If Not (loadSupply OrElse loadGood OrElse loadInDoc OrElse loadDocument) Then Exit Sub
        filePath = C2.ToText(filePath)
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim isType As Boolean = False   ' Вид услуги из загружаемой работы соответствует виду услуги текущей работы
        Try
            If String.IsNullOrWhiteSpace(filePath) OrElse Not My.Computer.FileSystem.FileExists(filePath) Then
                Throw New Exception("Файл с данными работы не найден.")
            End If
            Using Ds As New DataSet("WorkData")
                Ds.Tables.AddRange(New DataTable() _
                                   {Me.ARow.Clone, _
                                    Me.MemberTable.Clone, Me.MemberEmbargoTable.Clone, Me.MemberControlTable.Clone, Me.MemberRiskTable.Clone, _
                                    Me.ContractRiskTable.Clone, Me.SupplyRiskTable.Clone, _
                                    Me.GoodTable.Clone, Me.GoodLawTable.Clone, Me.GoodEmbargoTable.Clone, Me.GoodControlTable.Clone, Me.GoodRiskTable.Clone, _
                                    New Cprp.DxData.Work.InDocDataTable(Me)})
                Ds.ReadXml(filePath, XmlReadMode.IgnoreSchema)
                '
                ' Данные внешнеэкономической операции
                ' -----------------------------------
                '
                If Not loadSupply Then GoTo EndSupply
                '
                ' Arow
                '
                With Me.ARow
                    .Item("isNotContract") = False
                    .Item("contractName") = DBNull.Value
                    .Item("contractNum") = DBNull.Value
                    .Item("contractDate") = DBNull.Value
                    .Item("contractTerm") = DBNull.Value
                    .Item("isNotContractTerm") = False
                    .Item("contractDescription") = DBNull.Value
                    .Item("isNotContractRisk") = False
                    .Item("otherContractRisk") = DBNull.Value
                    .Item("modeId") = Cprp.DxData.ModeEnum.isExport
                    .Item("supplyTypeId") = 1
                    .Item("invoiceCaption") = DBNull.Value
                    .Item("supplyDescription") = DBNull.Value
                    .Item("isNotSupplyRisk") = False
                    .Item("otherSupplyRisk") = DBNull.Value
                    .Item("countryId") = DBNull.Value
                    .Item("countryIdString") = DBNull.Value
                    .Item("countryNameString") = DBNull.Value
                    .Item("bankCountryId") = DBNull.Value
                    .Item("isNotCountryRisk") = False
                    .Item("otherCountryRisk") = DBNull.Value
                    .Item("summaryRisk") = DBNull.Value
                    .Item("summaryId") = Cprp.DxData.Work.WorkSummary.IsFreedom
                    .Item("summaryText") = DBNull.Value
                    .Item("comment") = DBNull.Value
                End With
                If Ds.Tables("Arow") Is Nothing OrElse Ds.Tables("Arow").Rows.Count = 0 Then GoTo EndArow
                For Each Col As DataColumn In Ds.Tables("Arow").Columns
                    If Me.ARow.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                    sTmp = C2.ToText(Ds.Tables("Arow")(0)(Col))
                    If Not C2.IsText(sTmp) Then Continue For
                    Select Case Col.ColumnName.ToUpper
                        Case "TYPEID"
                            If IsNumeric(sTmp) Then isType = CInt(Me.ARow("typeId")) = CInt(sTmp)
                        Case "MODEID", "SUPPLYTYPEID", "COUNTRYID", "BANKCOUNTRYID"
                            If IsNumeric(sTmp) Then Me.ARow(Col.ColumnName) = CInt(sTmp)
                        Case "ISNOTCONTRACT", "ISNOTCONTRACTTERM", "ISNOTCONTRACTRISK", "ISNOTSUPPLYRISK", "ISNOTCOUNTRYRISK"
                            Me.ARow(Col.ColumnName) = CBool(sTmp)
                        Case "CONTRACTDATE", "CONTRACTTERM"
                            If IsDate(sTmp) Then Me.ARow(Col.ColumnName) = CDate(sTmp)
                        Case "CONTRACTNAME", "CONTRACTNUM", "CONTRACTDESCRIPTION", "OTHERCONTRACTRISK", _
                            "COUNTRYIDSTRING", "COUNTRYNAMESTRING", _
                            "INVOICECAPTION", "SUPPLYDESCRIPTION", "OTHERSUPPLYRISK", "OTHERCOUNTRYRISK", "COMMENT"
                            Me.ARow(Col.ColumnName) = sTmp
                    End Select
                Next
EndArow:
                '
                ' MemberTable
                '
                MemberEmbargoTable.Rows.Clear()
                MemberControlTable.Rows.Clear()
                MemberRiskTable.Rows.Clear()
                MemberTable.Rows.Clear()
                If Ds.Tables("MemberTable") Is Nothing OrElse Ds.Tables("MemberTable").Rows.Count = 0 Then GoTo EndMember
                With Ds.Tables("MemberTable")
                    For i As Integer = 0 To .Rows.Count - 1
                        Row = Me.MemberTable.NewRow
                        For Each Col As DataColumn In .Columns
                            If MemberTable.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                            sTmp = C2.ToText(.Rows(i)(Col))
                            If Not C2.IsText(sTmp) Then Continue For
                            Select Case Col.ColumnName.ToUpper
                                Case "ID", "DBID", "TYPEID", _
                                    "ADDRESSLEGALCOUNTRYID", "ADDRESSFACTCOUNTRYID", "ADDRESSPOSTCOUNTRYID", _
                                    "CONRUSNUM", "CONNUSNUM", "SUPRUSNUM", "SUPNUSNUM", "SUPENDNUM"
                                    If IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                                Case "ISCONTROL", "ISACT"
                                    Row(Col.ColumnName) = CBool(sTmp)
                                Case "ACTDATE"
                                    If IsDate(sTmp) Then Row(Col.ColumnName) = CDate(sTmp)
                                Case Else
                                    Row(Col.ColumnName) = sTmp
                            End Select
                        Next
                        If IsDBNull(Row("id")) Then Continue For
                        If IsDBNull(Row("typeId")) Then Continue For
                        If IsDBNull(Row("conRusNum")) AndAlso IsDBNull(Row("conNusNum")) _
                            AndAlso IsDBNull(Row("supRusNum")) AndAlso IsDBNull(Row("supNusNum")) _
                            AndAlso IsDBNull(Row("supEndNum")) Then Continue For
                        MemberTable.Rows.Add(Row)
                    Next
                End With
                If MemberTable.Rows.Count = 0 Then GoTo EndMember
                '
                ' MemberEmbargoTable
                '
                If Ds.Tables("MemberEmbargoTable") Is Nothing Then GoTo EndMemberEmbargo
                With Ds.Tables("MemberEmbargoTable")
                    If .Columns.IndexOf("memberId") < 0 Then GoTo EndMemberEmbargo
                    If .Columns.IndexOf("embargoMemberId") < 0 Then GoTo EndMemberEmbargo
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.MemberEmbargoTable.Rows.Add(New Object() {.Rows(i)("memberId"), .Rows(i)("embargoMemberId")})
                    Next
                End With
EndMemberEmbargo:
                '
                ' MemberControlTable
                '
                If Ds.Tables("MemberControlTable") Is Nothing Then GoTo EndMemberControl
                With Ds.Tables("MemberControlTable")
                    If .Columns.IndexOf("memberId") < 0 Then GoTo EndMemberControl
                    If .Columns.IndexOf("controlMemberId") < 0 Then GoTo EndMemberControl
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.MemberControlTable.Rows.Add(New Object() {.Rows(i)("memberId"), .Rows(i)("controlMemberId")})
                    Next
                End With
EndMemberControl:
                '
                ' MemberRiskTable
                '
                If Ds.Tables("MemberRiskTable") Is Nothing Then GoTo EndMemberRisk
                With Ds.Tables("MemberRiskTable")
                    If .Columns.IndexOf("memberId") < 0 Then GoTo EndMemberRisk
                    If .Columns.IndexOf("riskId") < 0 Then GoTo EndMemberRisk
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.MemberRiskTable.Rows.Add(New Object() {.Rows(i)("memberId"), .Rows(i)("riskId")})
                    Next
                End With
EndMemberRisk:
EndMember:
                '
                ' ContractRiskTable
                '
                Me.ContractRiskTable.Rows.Clear()
                If Ds.Tables("ContractRiskTable") Is Nothing Then GoTo EndContractRisk
                With Ds.Tables("ContractRiskTable")
                    If .Columns.IndexOf("riskId") < 0 Then GoTo EndContractRisk
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.ContractRiskTable.Rows.Add(New Object() {.Rows(i)("riskId")})
                    Next
                End With
EndContractRisk:
                '
                ' SupplyRiskTable
                '
                Me.SupplyRiskTable.Rows.Clear()
                If Ds.Tables("SupplyRiskTable") Is Nothing Then GoTo EndSupplyRisk
                With Ds.Tables("SupplyRiskTable")
                    If .Columns.IndexOf("riskId") < 0 Then GoTo EndSupplyRisk
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.SupplyRiskTable.Rows.Add(New Object() {.Rows(i)("riskId")})
                    Next
                End With
EndSupplyRisk:
EndSupply:
                '
                ' Данные продукции
                ' ----------------
                '
                If Not loadGood Then GoTo EndGood
                '
                ' ARow.goodArea, ARow.goodUsed
                '
                If Not Ds.Tables("ARow") Is Nothing AndAlso Ds.Tables("ARow").Rows.Count > 0 Then
                    With Ds.Tables("ARow")
                        If .Columns.IndexOf("goodArea") >= 0 Then Me.ARow("goodArea") = C2.ToText(.Rows(0)("goodArea"))
                        If .Columns.IndexOf("goodUsed") >= 0 Then Me.ARow("goodUsed") = C2.ToText(.Rows(0)("goodUsed"))
                    End With
                End If
                '
                ' GoodTable
                '
                GoodLawTable.Rows.Clear()
                GoodEmbargoTable.Rows.Clear()
                GoodControlTable.Rows.Clear()
                GoodRiskTable.Rows.Clear()
                GoodTable.Rows.Clear()
                If Ds.Tables("GoodTable") Is Nothing OrElse Ds.Tables("GoodTable").Rows.Count = 0 Then GoTo EndGood
                With Ds.Tables("GoodTable")
                    For i As Integer = 0 To .Rows.Count - 1
                        Row = Me.GoodTable.NewRow
                        Row("rowNum") = GoodTable.Rows.Count + 1
                        For Each Col As DataColumn In .Columns
                            If GoodTable.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                            sTmp = C2.ToText(.Rows(i)(Col))
                            If Not C2.IsText(sTmp) Then Continue For
                            Select Case Col.ColumnName.ToUpper
                                Case "ID", "PARENTID", "DBID", "PARENTDBID", "TYPEID", "ROWNUM"
                                    If IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                                Case "ISNOTDEC", "ISUNREAL", "ISNOTEMBARGO", "ISNOTCONTROL", "ISNOTRISK", _
                                    "ISCHECKDATA", "ISCHECKEMBARGO", "ISCHECKCONTROL", "ISCHECKRISK"
                                    Row(Col.ColumnName) = CBool(sTmp)
                                Case "ACTDATE"
                                    If IsDate(sTmp) Then Row(Col.ColumnName) = CDate(sTmp)
                                Case "NAMECON", "NAMEDEC", "TNVED", "TNVEDCOMMENT", "CAS", "AREA", "USED", "DESCRIPTION", _
                                    "RISKDESCRIPTION", "OTHERRISK", "STUDYTNVED", "STUDYWORD"
                                    Row(Col.ColumnName) = sTmp
                                Case "STUDYDATE"
                                    If isType AndAlso IsDate(sTmp) Then Row(Col.ColumnName) = CDate(sTmp)
                                Case "STUDYSUMMARYID"
                                    If isType AndAlso IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                                Case "STUDYSUMMARY"
                                    If isType Then Row(Col.ColumnName) = sTmp
                                Case "ISCHECKSTUDY"
                                    If isType Then Row(Col.ColumnName) = CBool(sTmp)
                            End Select
                        Next
                        If IsDBNull(Row("id")) Then Continue For
                        GoodTable.Rows.Add(Row)
                    Next
                End With
                If GoodTable.Rows.Count = 0 Then GoTo EndGood
                '
                ' GoodLawTable
                '
                If Not isType Then GoTo EndGoodLaw
                If Ds.Tables("GoodLawTable") Is Nothing Then GoTo EndGoodLaw
                With Ds.Tables("GoodLawTable")
                    If .Columns.IndexOf("goodId") < 0 Then GoTo EndGoodLaw
                    If .Columns.IndexOf("lawId") < 0 Then GoTo EndGoodLaw
                    For i As Integer = 0 To .Rows.Count - 1
                        Row = GoodLawTable.NewRow
                        'Row("workId") = Me.Id
                        Row("summaryId") = Cprp.DxData.Law.StudyIndexEnum.IsNothing
                        For Each Col As DataColumn In .Columns
                            If GoodLawTable.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                            sTmp = C2.ToText(.Rows(i)(Col))
                            If Not C2.IsText(sTmp) Then Continue For
                            Select Case Col.ColumnName.ToUpper
                                Case "GOODID", "LAWID", "AREAID", "SUMMARYID"
                                    If IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                                Case "ISFINDTNVED", "ISFINDCAS", "ISFINDWORD"
                                    Row(Col.ColumnName) = CBool(sTmp)
                                Case "LAWDESCRIPTION", "GOODDESCRIPTION"
                                    Row(Col.ColumnName) = sTmp
                            End Select
                        Next
                        If IsDBNull(Row("goodId")) Then Continue For
                        If IsDBNull(Row("lawId")) Then Continue For
                        GoodLawTable.Rows.Add(Row)
                    Next
                End With
EndGoodLaw:
                '
                ' GoodEmbargoTable
                '
                If Ds.Tables("GoodEmbargoTable") Is Nothing Then GoTo EndGoodEmbargo
                With Ds.Tables("GoodEmbargoTable")
                    If .Columns.IndexOf("goodId") < 0 Then GoTo EndGoodEmbargo
                    If .Columns.IndexOf("embargoGoodId") < 0 Then GoTo EndGoodEmbargo
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.GoodEmbargoTable.Rows.Add(New Object() {.Rows(i)("goodId"), .Rows(i)("embargoGoodId")})
                    Next
                End With
EndGoodEmbargo:
                '
                ' GoodControlTable
                '
                If Ds.Tables("GoodControlTable") Is Nothing Then GoTo EndGoodControl
                With Ds.Tables("GoodControlTable")
                    If .Columns.IndexOf("goodId") < 0 Then GoTo EndGoodControl
                    If .Columns.IndexOf("controlGoodId") < 0 Then GoTo EndGoodControl
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.GoodControlTable.Rows.Add(New Object() {.Rows(i)("goodId"), .Rows(i)("controlGoodId")})
                    Next
                End With
EndGoodControl:
                '
                ' GoodRiskTable
                '
                If Ds.Tables("GoodRiskTable") Is Nothing Then GoTo EndGoodRisk
                With Ds.Tables("GoodRiskTable")
                    If .Columns.IndexOf("goodId") < 0 Then GoTo EndGoodRisk
                    If .Columns.IndexOf("riskId") < 0 Then GoTo EndGoodRisk
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.GoodRiskTable.Rows.Add(New Object() {.Rows(i)("goodId"), .Rows(i)("riskId")})
                    Next
                End With
EndGoodRisk:
EndGood:
                '
                ' Данные представленных документов
                ' --------------------------------
                '
                If Not loadInDoc Then GoTo EndInDoc
                Using V As New DataView(InDocTable)
                    V.RowFilter = "eoId IS NULL"
                    While V.Count > 0
                        V(0).Delete()
                    End While
                End Using
                InDocTable.AcceptChanges()
                If Ds.Tables("InDocTable") Is Nothing OrElse Ds.Tables("InDocTable").Rows.Count = 0 Then GoTo EndInDoc
                '
                ' InDocTable
                '
                With Ds.Tables("InDocTable")
                    If .Columns.IndexOf("rowNum") < 0 Then GoTo EndInDoc
                    For i As Integer = 0 To .Rows.Count - 1
                        Row = InDocTable.AddNew
                        For Each Col As DataColumn In .Columns
                            If InDocTable.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                            sTmp = C2.ToText(.Rows(i)(Col))
                            If Not C2.IsText(sTmp) Then Continue For
                            Select Case Col.ColumnName.ToUpper
                                Case "DBID", "EOID", "ORDERID"
                                    If IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                                Case "CAPTION", "REGNUM", "DOCURL"
                                    Row(Col.ColumnName) = sTmp
                                Case "REGDATE", "ACTDATE"
                                    If IsDate(sTmp) Then Row(Col.ColumnName) = CDate(sTmp)
                            End Select
                        Next
                    Next
                End With
EndInDoc:
                '
                ' Документы по работе
                ' -------------------
                '
                If Not loadDocument Then GoTo EndDocument
                Me.ARow("doc1Data") = DBNull.Value
                Me.ARow("doc1RegNum") = DBNull.Value
                Me.ARow("doc1RegDate") = DBNull.Value
                Me.ARow("doc1SummaryId") = DBNull.Value
                Me.ARow("ref1Data") = DBNull.Value
                Me.ARow("doc1Data") = DBNull.Value
                Me.ARow("doc2RegNum") = DBNull.Value
                Me.ARow("doc2RegDate") = DBNull.Value
                Me.ARow("doc2SummaryId") = DBNull.Value
                Me.ARow("ref2Data") = DBNull.Value
                If Ds.Tables("Arow") Is Nothing OrElse Ds.Tables("Arow").Rows.Count = 0 Then GoTo EndDocument
                Row = Ds.Tables("Arow").Rows(0)
                For Each Col As DataColumn In Ds.Tables("Arow").Columns
                    If Me.ARow.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                    If IsDBNull(Row(Col)) Then Continue For
                    Me.ARow(Col.ColumnName) = Row(Col)
                Next
EndDocument:
            End Using
            MyBase.DS.AcceptChanges()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Сохранить новые и измененные данные в таблицу базы данных как новые записи
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataInsert()
        '
        ' tMember
        '
        Me.MemberTable.DataInsert(Me.Connection)
        '
        ' tWorkMember
        '
        Me.ExecuteNonQuery(String.Format("DELETE FROM tWorkMember WHERE workId = {0}", CInt(Me.Id)))
        For Each Row As DataRow In Me.MemberTable.Rows
            If CInt(Row("conRusNum")) > 0 Then
                If CInt(Me.ExecuteScalar(String.Format( _
                                         "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                                         CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsContractRus)))) = 0 Then
                    Me.ExecuteNonQuery(String.Format( _
                                       "INSERT tWorkMember(workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                                       CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsContractRus)))
                End If
            End If
            If CInt(Row("conNusNum")) > 0 Then
                If CInt(Me.ExecuteScalar(String.Format( _
                                         "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                                         CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsContractNus)))) = 0 Then
                    Me.ExecuteNonQuery(String.Format( _
                                       "INSERT tWorkMember(workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                                       CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsContractNus)))
                End If
            End If
            If CInt(Row("supRusNum")) > 0 Then
                If CInt(Me.ExecuteScalar(String.Format( _
                                         "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                                         CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsSupplyRus)))) = 0 Then
                    Me.ExecuteNonQuery(String.Format( _
                                       "INSERT tWorkMember(workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                                       CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsSupplyRus)))
                End If
            End If
            If CInt(Row("supNusNum")) > 0 Then
                If CInt(Me.ExecuteScalar(String.Format( _
                                         "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                                         CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsSupplyNus)))) = 0 Then
                    Me.ExecuteNonQuery(String.Format( _
                                       "INSERT tWorkMember(workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                                       CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsSupplyNus)))
                End If
            End If
            If CInt(Row("supEndNum")) > 0 Then
                If CInt(Me.ExecuteScalar(String.Format( _
                                         "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                                         CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsSupplyEnd)))) = 0 Then
                    Me.ExecuteNonQuery(String.Format( _
                                       "INSERT tWorkMember(workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                                       CInt(Me.Id), CInt(Row("dbId")), CInt(Member.MemberKind.IsSupplyEnd)))
                End If
            End If
        Next
        '
        ' tMemberEmbargo
        '
        Using V As New DataView(Me.MemberEmbargoTable)
            For Each Row As DataRow In Me.MemberTable.Rows
                V.RowFilter = String.Format("memberId = {0}", CInt(Row("id")))
                For Each VRow As DataRowView In V
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tMemberEmbargo WHERE memberId = {0} AND embargoMemberId = {1}", _
                                             CInt(Row("dbId")), CInt(VRow("embargoMemberId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tMemberEmbargo(memberId, embargoMemberId) VALUES({0}, {1})", _
                                     CInt(Row("dbId")), CInt(VRow("embargoMemberId"))))
                Next
            Next
        End Using
        '
        ' tMemberControl
        '
        Using V As New DataView(Me.MemberControlTable)
            For Each Row As DataRow In Me.MemberTable.Rows
                V.RowFilter = String.Format("memberId = {0}", CInt(Row("id")))
                For Each VRow As DataRowView In V
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tMemberControl WHERE memberId = {0} AND controlMemberId = {1}", _
                                             CInt(Row("dbId")), CInt(VRow("controlMemberId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tMemberControl(memberId, controlMemberId) VALUES({0}, {1})", _
                                     CInt(Row("dbId")), CInt(VRow("controlMemberId"))))
                Next
            Next
        End Using
        '
        ' tMemberRisk
        '
        Using V As New DataView(Me.MemberRiskTable)
            For Each Row As DataRow In Me.MemberTable.Rows
                V.RowFilter = String.Format("memberId = {0}", CInt(Row("id")))
                For Each VRow As DataRowView In V
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tMemberRisk WHERE memberId = {0} AND riskId = {1}", _
                                             CInt(Row("dbId")), CInt(VRow("riskId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tMemberRisk(memberId, riskId) VALUES({0}, {1})", _
                                     CInt(Row("dbId")), CInt(VRow("riskId"))))
                Next
            Next
        End Using
        '
        ' tContract, tContractMember, tContractRisk
        '
        If Not (IsDBNull(Me.ARow("isNotContract")) OrElse CBool(Me.ARow("isNotContract"))) Then
            Using Con As New Cprp.DxData.Contract.ContractDataTable
                '
                ' tContract, tContractMember
                '
                Con.Rows.Add(New Object() _
                             {1, _
                              Me.ARow("contractName"), _
                              Me.ARow("contractNum"), _
                              Me.ARow("contractDate"), _
                              Me.ARow("contractTerm"), _
                              Me.ARow("isNotContractTerm"), _
                              Me.ARow("contractDescription"), _
                              Date.Now, _
                              DBNull.Value})
                For Each VRow As DataRowView In Me.MemberTable.ConRusView
                    Con.MemberTable.Rows.Add(New Object() { _
                                             Con(0)("id"), VRow("id"), CInt(MK.IsContractRus), VRow("dbId")})
                Next
                For Each VRow As DataRowView In Me.MemberTable.ConNusView
                    Con.MemberTable.Rows.Add(New Object() { _
                                             Con(0)("id"), VRow("id"), CInt(MK.IsContractNus), VRow("dbId")})
                Next
                Con.DataInsert(Me.Connection)
                Con.MemberTable.Dispose()
                '
                ' tContractRisk
                '
                For Each Row As DataRow In Me.ContractRiskTable.Rows
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tContractRisk WHERE contractId = {0} AND riskId = {1}", _
                                             CInt(Con(0)("dbId")), CInt(Row("riskId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tContractRisk(contractId, riskId) VALUES({0}, {1})", _
                                     CInt(Con(0)("dbId")), CInt(Row("riskId"))))
                Next
                Con.Dispose()
            End Using
        End If
        '
        ' tGood
        '
        Me.GoodTable.UpdateCategoryByType(MyBase.GoodTypeHandbookTable)
        Me.GoodTable.DataInsert(Me.Connection)
        '
        ' tGoodStudy
        '
        Dim StudyRow As DataRow = Nothing
        Using T As New DataTable
            T.Load(Me.ExecuteReader("SELECT * FROM tGoodStudy WHERE goodId IS NULL"))
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            For Each Row As DataRow In Me.GoodTable.Rows
                If Not CBool(Row("isCheckStudy")) OrElse IsDBNull(Row("dbId")) Then Continue For
                '
                ' Объявление старых результатов исследований неактуальными
                '
                Me.ExecuteScalar(String.Format( _
                                 "UPDATE tGoodStudy SET isACT = 0 WHERE goodId = {0} AND typeId = {1}", _
                                 CInt(Row("dbId")), CInt(Cprp.DxData.Work.WorkType.IsExCont)))
                '
                ' Запись результатов нового исследования
                '
                StudyRow = T.NewRow
                StudyRow("goodId") = Row("dbId")
                StudyRow("typeId") = CInt(Cprp.DxData.Work.WorkType.IsExCont)
                StudyRow("summaryId") = Row("studySummaryId")
                StudyRow("tnved") = Row("studyTnved")
                StudyRow("word1Id") = Row("studyWord1Id")
                StudyRow("word2Id") = Row("studyWord2Id")
                StudyRow("word") = C2.DbText(Row("studyWord"), 250)
                StudyRow("actDate") = Row("studyDate")
                StudyRow("isACT") = True
                T.Rows.Add(StudyRow)
            Next
            Using A As New SqlDataAdapter("SELECT * FROM tGoodStudy", Me.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
        End Using
        '
        ' tGoodStudyLaw, tLawTnved
        '
        Using T As New DataTable
            T.Load(Me.ExecuteReader("SELECT * FROM tGoodStudyLaw WHERE studyId IS NULL"))
            T.PrimaryKey = New DataColumn() {T.Columns("studyId"), T.Columns("lawId")}
            Dim studyId As Integer = C2.EMPTY_ID
            Dim lawId As Integer = C2.EMPTY_ID
            Dim tnved As String = Nothing
            Using V As New DataView(Me.GoodLawTable)
                For Each Row As DataRow In Me.GoodTable.Rows
                    If Not CBool(Row("isCheckStudy")) OrElse IsDBNull(Row("dbId")) Then Continue For
                    '
                    ' studyId
                    '
                    studyId = CInt(Me.ExecuteScalar(String.Format( _
                        "SELECT ISNULL(MAX(id), 0) FROM tGoodStudy WHERE goodId = {0} AND typeId = {1} AND isACT = 1", _
                        CInt(Row("dbId")), CInt(Cprp.DxData.Work.WorkType.IsExCont))))
                    If studyId < 1 Then Continue For
                    '
                    ' Запись нового исследования (записываются только результаты сравнительного анализа)
                    '
                    V.RowFilter = String.Format("goodId = {0}", CInt(Row("id")))
                    For Each VRow As DataRowView In V
                        If Not (C2.IsText(VRow("goodDescription")) AndAlso C2.IsText(VRow("lawDescription"))) Then Continue For
                        '
                        ' Проверка наличия текущей строки исследования в таблице (для случая с идентичными товарами в работе)
                        '
                        If Not T.Rows.Find(New Object() {studyId, CInt(VRow("lawId"))}) Is Nothing Then Continue For
                        '
                        ' Добавление текущей строки исследования в таблицу
                        '
                        StudyRow = T.NewRow
                        StudyRow("studyId") = studyId
                        StudyRow("lawId") = VRow("lawId")
                        StudyRow("goodDescription") = VRow("goodDescription")
                        StudyRow("lawDescription") = VRow("lawDescription")
                        StudyRow("isFindTnved") = VRow("isFindTnved")
                        StudyRow("isFindCAS") = VRow("isFindCAS")
                        StudyRow("isFindWord") = VRow("isFindWord")
                        StudyRow("summaryId") = VRow("summaryId")
                        T.Rows.Add(StudyRow)
                        '
                        ' Запись кода ТН ВЭД в таблицу tLawTnved
                        '
                        lawId = CInt(VRow("lawId"))
                        tnved = C2.ToText(Row("tnved"))
                        If CInt(VRow("summaryId")) > 0 AndAlso C2.IsText(tnved) AndAlso tnved.Length > 3 AndAlso Not tnved Like "49*" AndAlso Not tnved Like "8523*" Then
                            If CInt(Me.ExecuteScalar(String.Format("SELECT COUNT(*) FROM tLawTnved WHERE lawId = {0} AND tnved = '{1}'", lawId, tnved))) = 0 Then
                                Me.ExecuteNonQuery(String.Format("INSERT tLawTnved (lawId, tnved, is2) VALUES ({0}, '{1}', 1)", lawId, tnved))
                            End If
                        End If
                    Next
                Next
            End Using
            Using A As New SqlDataAdapter("SELECT * FROM tGoodStudyLaw", Me.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
        End Using
        '
        ' tGoodEmbargo
        '
        Using V As New DataView(Me.GoodEmbargoTable)
            For Each Row As DataRow In Me.GoodTable.Rows
                V.RowFilter = String.Format("goodId = {0}", CInt(Row("id")))
                For Each VRow As DataRowView In V
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tGoodEmbargo WHERE goodId = {0} AND embargoGoodId = {1}", _
                                             CInt(Row("dbId")), CInt(VRow("embargoGoodId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tGoodEmbargo(goodId, embargoGoodId) VALUES({0}, {1})", _
                                     CInt(Row("dbId")), CInt(VRow("embargoGoodId"))))
                Next
            Next
        End Using
        '
        ' tGoodControl
        '
        Using V As New DataView(Me.GoodControlTable)
            For Each Row As DataRow In Me.GoodTable.Rows
                V.RowFilter = String.Format("goodId = {0}", CInt(Row("id")))
                For Each VRow As DataRowView In V
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tGoodControl WHERE goodId = {0} AND controlGoodId = {1}", _
                                             CInt(Row("dbId")), CInt(VRow("controlGoodId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tGoodControl(goodId, controlGoodId) VALUES({0}, {1})", _
                                     CInt(Row("dbId")), CInt(VRow("controlGoodId"))))
                Next
            Next
        End Using
        '
        ' tGoodRisk
        '
        Using V As New DataView(Me.GoodRiskTable)
            For Each Row As DataRow In Me.GoodTable.Rows
                V.RowFilter = String.Format("goodId = {0}", CInt(Row("id")))
                For Each VRow As DataRowView In V
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tGoodRisk WHERE goodId = {0} AND riskId = {1}", _
                                             CInt(Row("dbId")), CInt(VRow("riskId"))))) > 0 Then Continue For
                    Me.ExecuteScalar(String.Format( _
                                     "INSERT tGoodRisk(goodId, riskId) VALUES({0}, {1})", _
                                     CInt(Row("dbId")), CInt(VRow("riskId"))))
                Next
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Обновить контрольные статусы объектов экспертизы по контрольным статусам дочерних объектов
    ''' </summary>
    Public Sub StudySummaryUpdateByChild()
        '
        ' Обновление контрольных статусов объектов по результатам их исследований
        '
        Using V As New DataView(Me.GoodLawTable) With {.Sort = "summaryId DESC"}
            For Each Row As DataRow In Me.GoodTable.Rows
                If Row.RowState = DataRowState.Deleted Then Continue For
                V.RowFilter = String.Format("goodId = {0}", CInt(Row("id")))
                If V.Count > 0 Then
                    Row("studySummaryId") = V(0)("summaryId")
                Else
                    Row("studySummaryId") = CInt(StudyIndexEnum.IsNothing)
                End If
            Next
        End Using
        '
        ' Обновление контрольных статусов объектов по результатам исследований их дочерних объектов
        '
        For Each Row As DataRow In Me.GoodTable.Rows
            If Row.RowState = DataRowState.Deleted Then Continue For
            RowStudySummaryUpdateByChild(Row)
        Next
    End Sub

    ''' <summary>
    ''' Обновить контрольный статус объекта экспертизы по контрольным статусам дочерних объектов
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks>Рекурсивная процедура</remarks>
    Private Sub RowStudySummaryUpdateByChild(ByRef Row As DataRow)
        Dim iMax As Integer = CInt(Row("studySummaryId"))
        Dim iTmp As Integer = C2.EMPTY_ID
        Using V As New DataView(Me.GoodTable) With {.RowFilter = String.Format("parentId = {0}", CInt(Row("id")))}
            For Each VRow As DataRowView In V
                RowStudySummaryUpdateByChild(VRow.Row)
                iTmp = CInt(VRow("studySummaryId"))
                If iMax < iTmp Then iMax = iTmp
            Next
        End Using
        Row("studySummaryId") = iMax
    End Sub

    ''' <summary>
    ''' Возвращает признак отсутствия рисков по всей работе
    ''' </summary>
    Private Function NotGlobalRisk() As Boolean
        '
        ' Отсутствие рисков по сделке
        '
        If Not CBool(Me.ARow("isNotContractRisk")) Then Return False
        '
        ' Отсутствие рисков по операции
        '
        If Not CBool(Me.ARow("isNotSupplyRisk")) Then Return False
        '
        ' Отсутствие рисков и запретов по участникам сделки и операции
        '
        If Me.MemberRiskTable.Rows.Count > 0 Then Return False
        If Me.MemberEmbargoTable.Rows.Count > 0 Then Return False
        If Me.MemberControlTable.Rows.Count > 0 Then Return False
        Using V As New DataView(Me.MemberTable) With {.RowFilter = "isControl = True"}
            If V.Count > 0 Then Return False
        End Using
        '
        ' Отсутствие рисков и запретов по товарам
        '
        If Me.GoodRiskTable.Rows.Count > 0 Then Return False
        If Me.GoodEmbargoTable.Rows.Count > 0 Then Return False
        If Me.GoodControlTable.Rows.Count > 0 Then Return False
        '
        ' Отсутствие результатов поиска по коду ТН ВЭД и сравнительных анализов товаров с пунктами контрольных списков
        ' Контролируемые товары не учитываются (они в отдельном заключении)
        Using V As New DataView(Me.GoodLawTable) With {.RowFilter = "isFindTnved = True OR summaryId = 1"}
            If V.Count > 0 Then Return False
        End Using
        '
        ' Отсутствие запретов и ограничений по стране назначения / отправления
        '
        Using V As New DataView(Me.EmbargoCountryHandbookTable)
            Dim sTmp As String = C2.ToStrNum(Me.ARow("countryIdString"), False)
            If Not C2.IsText(sTmp) Then sTmp = "0"
            V.RowFilter = String.Format("countryId IN ({0}) AND (modeId = {1} OR modeId = {2})", _
                                        sTmp, C2.ToInt(Me.ARow("modeId")), CInt(Cprp.DxData.ModeEnum.isBoth))
            If V.Count > 0 Then Return False
        End Using
        '
        ' Рисков нет
        '
        Return True

    End Function


    ''' <summary>
    ''' Возвращает таблицу контролируемых товаров из таблицы tFInfo базы ЭС, соответствующих по обозначениям товарам из работы
    ''' </summary>
    ''' <remarks>
    ''' Таблица представляет собой двухуровневое дерево. 
    ''' На первом уровне товары из работы, на втором уровне товары из tFInfo
    ''' </remarks>
    Public Function GoodFInfoTable() As DataTable
        GoodFInfoTable = New DataTable("GoodFInfoTable")
        With GoodFInfoTable.Columns
            .Add("id", GetType(Integer))
            .Add("parentId", GetType(Integer))
            .Add("sortId", GetType(Integer))
            .Add("name", GetType(String))
            With .Add("lev", GetType(Integer))
                .AllowDBNull = False
                .DefaultValue = -1
            End With
        End With
        GoodFInfoTable.PrimaryKey = New DataColumn() {GoodFInfoTable.Columns("id")}
        Dim maxId As Integer = 0
        '
        ' Добавление товаров из работы
        '
        For Each Row As DataRow In Me.GoodTable.Rows
            GoodFInfoTable.Rows.Add(New Object() {Row("id"), DBNull.Value, Row("rowNum"), String.Format("Товар № {0}. {1} / Обозначение: {2}", Row("rowNum").ToString, Row("nameCon").ToString, Row("nameDec").ToString), -1})
            If CInt(Row("id")) > maxId Then maxId = CInt(Row("id"))
        Next
        '
        ' Поиск товаров в tFInfo
        '
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        For Each Row As DataRow In Me.GoodTable.Rows
            sTmp = C2.ToABC(Row("tnved").ToString)
            If String.IsNullOrWhiteSpace(sTmp) Then Continue For
            If sTmp.Length > 4 Then sTmp = sTmp.Substring(0, 4)
            sTmp1 = C2.ToABC(Row("nameDec").ToString)
            If String.IsNullOrWhiteSpace(sTmp1) OrElse sTmp1.Length < 3 Then Continue For
            Using Dr As SqlDataReader = Me.ExecuteReader(String.Format( _
                "SELECT goodName, docNum, docDate, orgNameShort FROM vFInfo " & _
                "WHERE goodTnved LIKE '{0}%' AND " & _
                "(goodNameFind LIKE '%{1}%' OR '{1}' LIKE ('%' + goodNameFind + '%')) ORDER BY goodName", sTmp, sTmp1))
                While Dr.Read
                    maxId += 1
                    GoodFInfoTable.Rows.Add(New Object() {maxId, Row("id"), maxId, C2.ToText(Dr("goodName")), 2})
                    sTmp = C2.ToText(Dr("docNum"))
                    If C2.IsText(sTmp) Then
                        maxId += 1
                        sTmp = String.Format("Заключение № {0}", sTmp)
                        sTmp1 = C2.ToText(Dr("docDate"))
                        If C2.IsText(sTmp1) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(sTmp1))
                        sTmp1 = C2.ToText(Dr("orgNameShort"))
                        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}{1}Организация: {2}", sTmp, vbCrLf, sTmp1)
                        GoodFInfoTable.Rows.Add(New Object() {maxId, maxId - 1, maxId, sTmp, 3})
                    End If
                    'sTmp = C2.ToText(Dr("goodName"))
                    'sTmp1 = C2.ToText(Dr("docNum"))
                    'If C2.IsText(sTmp1) Then
                    '    sTmp = String.Format("{0}{1}Заключение № {2}", sTmp, vbCrLf, sTmp1)
                    '    sTmp1 = C2.ToText(Dr("docDate"))
                    '    If C2.IsText(sTmp1) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(sTmp1))
                    'End If
                    'sTmp1 = C2.ToText(Dr("orgNameShort"))
                    'If C2.IsText(sTmp1) Then sTmp = String.Format("{0}{1}Организация: {2}", sTmp, vbCrLf, sTmp1)
                    'maxId += 1
                    'GoodFInfoTable.Rows.Add(New Object() {maxId, Row("id"), maxId, sTmp, 2})
                End While
            End Using
        Next
        '
        ' Удаление неактуальных строк
        '
        Using V As New DataView(GoodFInfoTable) With {.RowFilter = "parentId IS NULL"}
            Using V1 As New DataView(GoodFInfoTable)
                For Each VRow As DataRowView In V
                    V1.RowFilter = String.Format("parentId = {0}", VRow("id").ToString)
                    If V1.Count > 0 Then VRow("lev") = 1
                Next
            End Using
            V.RowFilter = "lev < 1"
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        GoodFInfoTable.AcceptChanges()
    End Function

End Class
