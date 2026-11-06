Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Признаки риска по внешнеэкономической сделке
    ''' </summary>
    ''' <remarks></remarks>
    Friend ContractRiskTable As ContractRiskDataTable = Nothing

    ''' <summary>
    ''' Признаки риска по внешнеэкономической операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend SupplyRiskTable As SupplyRiskDataTable = Nothing

    ''' <summary>
    ''' Участники сделки и операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend MemberTable As MemberDataTable = Nothing

    ''' <summary>
    ''' Запреты и ограничения участников сделки и операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend MemberEmbargoTable As MemberEmbargoDataTable = Nothing

    ''' <summary>
    ''' Связи участников сделки и операции с лицами на контроле
    ''' </summary>
    ''' <remarks></remarks>
    Friend MemberControlTable As MemberControlDataTable = Nothing

    ''' <summary>
    ''' Признаки риска участников сделки и операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend MemberRiskTable As MemberRiskDataTable = Nothing

    ''' <summary>
    ''' Продукция
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Запреты и ограничения в отношении продукции
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodEmbargoTable As GoodEmbargoDataTable = Nothing

    ''' <summary>
    ''' Связи продукции с продукцией на контроле
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodControlTable As GoodControlDataTable = Nothing

    ''' <summary>
    ''' Исследования продукции по контрольным спискам
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodLawTable As GoodLawDataTable = Nothing

    ''' <summary>
    ''' Признаки риска по продукции
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodRiskTable As GoodRiskDataTable = Nothing

    ''' <summary>
    ''' Пояснения эксперта к разделам заключения
    ''' </summary>
    ''' <remarks></remarks>
    Friend CommentTable As CommentDataTable = Nothing

    ''' <summary>
    ''' Разделы Единого перечня в отношении которых проводилась экспертиза
    ''' </summary>
    ''' <remarks></remarks>
    Friend LawCaptionTable As LawCaptionDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Customs.WorkConnectionRow
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
            .Add("contractName", GetType(String))           ' Наименование документа-основания сделки
            .Add("contractNum", GetType(String))            ' Номер документа-основания сделки
            .Add("contractDate", GetType(Date))             ' Дата документа-основания сделки
            .Add("contractTerm", GetType(Date))             ' Срок действия документа-основания сделки
            .Add("isNotContractTerm", GetType(Boolean))     ' Срок действия документа-основания сделки отсутствует
            .Add("contractDescription", GetType(String))    ' Описание предмета сделки
            .Add("isNotContractRisk", GetType(Boolean))     ' Риски по сделке отсутствуют
            .Add("otherContractRisk", GetType(String))      ' Иные признаки риска по сделке
            ' Операция
            .Add("countryId", GetType(Integer))             ' ID страны назначения (отправления)
            .Add("supplyTypeId", GetType(Integer))          ' ID характера внешнеэкономической операции
            .Add("modeId", GetType(Integer))                ' ID направления перемещения
            .Add("incotermsId", GetType(Integer))           ' ID условия поставки по Инкотермс
            .Add("incotermsPlace", GetType(String))         ' Место доставки
            .Add("invoiceCaption", GetType(String))         ' Документ-основание внешнеэкономической операции
            .Add("supplyDescription", GetType(String))      ' Предмет внешнеэкономической операции
            .Add("isNotSupplyRisk", GetType(Boolean))       ' Риски по внешнеэкономической операции отсутствуют
            .Add("otherSupplyRisk", GetType(String))        ' Иные признаки риска по внешнеэкономической операции
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
            .Add("doc1RegNum", GetType(String))             ' номер документа
            .Add("doc1RegDate", GetType(Date))              ' дата документа
            .Add("doc1SummaryId", GetType(Integer))         ' ID идентификатора выводов экспертизы по документу
            .Add("ref1Data", GetType(String))               ' содержимое справки по документу (xml)
        End With
        With MyBase.ARow.Columns("modeId")
            .AllowDBNull = False
            .DefaultValue = Cprp.DxData.ModeEnum.isExport               ' Вывоз
        End With
        With MyBase.ARow.Columns("isNotContract")
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
        LawCaptionTable = New LawCaptionDataTable
        '
        ' Источник данных работы
        '
        MyBase.DS.Tables.AddRange(New DataTable() { _
                                  ContractRiskTable, SupplyRiskTable, _
                                  MemberTable, MemberEmbargoTable, MemberControlTable, MemberRiskTable, _
                                  GoodTable, GoodLawTable, GoodEmbargoTable, GoodControlTable, GoodRiskTable,
                                  CommentTable, LawCaptionTable})
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
        MyBase.LawDataSet.DataLoad(Me.Connection, Date.Now, False, False, True, True, True, True)

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
            'MyBase.ARow("typeId") = Cprp.DxData.Work.WorkType.IsCustomUnion
            If CommentTable.IsEmpty Then
                CommentTable.DataInit()
                MyBase.DS.AcceptChanges()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    Public Overrides Sub DataSave()
        Me("countryName") = GetToCountryName()
        Me("percentCount") = GetPercentCount()
        MyBase.DataSave()
    End Sub

    ''' <summary>
    ''' Возвращает наименование страны назначения (при ввозе - РОССИЯ)
    ''' </summary>
    Private Function GetToCountryName() As String
        If CType(Me.ARow("modeId"), Cprp.DxData.ModeEnum) = ModeEnum.isImport Then Return "РОССИЯ"
        Dim Row As DataRow = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Me.ARow("countryId")))
        If Row Is Nothing Then Return Nothing
        Return Row("nameShort").ToString
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
                    Me.LawCaptionTable.Clone, New Cprp.DxData.Work.InDocDataTable(Me)})
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
                    .Item("isNotCountryRisk") = False
                    .Item("otherCountryRisk") = DBNull.Value
                    .Item("summaryRisk") = DBNull.Value
                    .Item("summaryId") = Cprp.DxData.Work.WorkSummary.IsFreedom
                    .Item("summaryText") = DBNull.Value
                End With
                If Ds.Tables("Arow") Is Nothing OrElse Ds.Tables("Arow").Rows.Count = 0 Then GoTo EndArow
                For Each Col As DataColumn In Ds.Tables("Arow").Columns
                    If Me.ARow.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                    sTmp = C2.ToText(Ds.Tables("Arow")(0)(Col))
                    If Not C2.IsText(sTmp) Then Continue For
                    Select Case Col.ColumnName.ToUpper
                        Case "TYPEID"
                            If IsNumeric(sTmp) Then isType = CInt(Me.ARow("typeId")) = CInt(sTmp)
                        Case "MODEID", "SUPPLYTYPEID", "COUNTRYID"
                            If IsNumeric(sTmp) Then Me.ARow(Col.ColumnName) = CInt(sTmp)
                        Case "ISNOTCONTRACT", "ISNOTCONTRACTTERM", "ISNOTCONTRACTRISK", "ISNOTSUPPLYRISK", "ISNOTCOUNTRYRISK"
                            Me.ARow(Col.ColumnName) = CBool(sTmp)
                        Case "CONTRACTDATE", "CONTRACTTERM"
                            If IsDate(sTmp) Then Me.ARow(Col.ColumnName) = CDate(sTmp)
                        Case "CONTRACTNAME", "CONTRACTNUM", "CONTRACTDESCRIPTION", "OTHERCONTRACTRISK", _
                            "INVOICECAPTION", "SUPPLYDESCRIPTION", "OTHERSUPPLYRISK", "OTHERCOUNTRYRISK", "SUMMARYTEXT"
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
                                 CInt(Row("dbId")), CInt(Cprp.DxData.Work.WorkType.IsCustomUnion)))
                '
                ' Запись результатов нового исследования
                '
                StudyRow = T.NewRow
                StudyRow("goodId") = Row("dbId")
                StudyRow("typeId") = CInt(Cprp.DxData.Work.WorkType.IsCustomUnion)
                StudyRow("summaryId") = Row("studySummaryId")
                StudyRow("tnved") = Row("studyTnved")
                StudyRow("word") = Row("studyWord")
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
        ' tGoodStudyLaw
        '
        Using T As New DataTable
            T.Load(Me.ExecuteReader("SELECT * FROM tGoodStudyLaw WHERE studyId IS NULL"))
            T.PrimaryKey = New DataColumn() {T.Columns("studyId"), T.Columns("lawId")}
            Dim studyId As Integer = C2.EMPTY_ID
            Using V As New DataView(Me.GoodLawTable)
                For Each Row As DataRow In Me.GoodTable.Rows
                    If Not CBool(Row("isCheckStudy")) OrElse IsDBNull(Row("dbId")) Then Continue For
                    '
                    ' studyId
                    '
                    studyId = CInt(Me.ExecuteScalar(String.Format( _
                        "SELECT ISNULL(MAX(id), 0) FROM tGoodStudy WHERE goodId = {0} AND typeId = {1} AND isACT = 1", _
                        CInt(Row("dbId")), CInt(Cprp.DxData.Work.WorkType.IsCustomUnion))))
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

End Class
