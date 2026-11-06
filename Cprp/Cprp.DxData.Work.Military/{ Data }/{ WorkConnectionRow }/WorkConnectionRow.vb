Imports C2 = Cprp.DxData.Common
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Объекты экспертизы
    ''' </summary>
    Friend GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Связи объектов экспертизы с документами, подтверждающими гражданское назначение
    ''' </summary>
    Friend GoodInDocTable As GoodInDocDataTable = Nothing

    ''' <summary>
    ''' Таблица-строка с данными российского участника внешнеэкономической операции
    ''' </summary>
    Friend MemberTable As MemberDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Military.WorkConnectionRow
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(id As Object, Connection As SqlConnection)
        MyBase.New(Connection)
        '
        ' Arow
        '
        With MyBase.ARow.Columns
            ' Объекты экспертизы
            .Add("goodArea", GetType(String))               ' Общая область применения объектов экспертизы
            .Add("goodUsed", GetType(String))               ' Общее назначение объектов экспертизы
            ' Внешнеэкономическая операция
            .Add("contractCaption", GetType(String))        ' Реквизиты документа-основания операции
            ' Выводы экспертизы
            .Add("summary", GetType(String))                ' Общие выводы экспертизы
            .Add("comment", GetType(String))                ' Пояснения эксперта
            ' Документ #1
            .Add("doc1Data", GetType(Byte()))               ' содержимое проекта документа (openXml)
            .Add("doc1Id", GetType(Integer))                ' порядковый номер документа в таблице базы данных
            .Add("doc1RegNum", GetType(String))             ' номер документа
            .Add("doc1RegDate", GetType(Date))              ' дата документа
            .Add("doc1SummaryId", GetType(Integer))         ' ID идентификатора выводов экспертизы по документу
            .Add("ref1Data", GetType(String))               ' содержимое справки по документу (xml)
        End With
        '
        ' Другие таблицы
        '
        GoodTable = New GoodDataTable
        GoodInDocTable = New GoodInDocDataTable
        MemberTable = New MemberDataTable
        '
        ' Источник данных работы
        '
        MyBase.DS.Tables.AddRange(New DataTable() {GoodTable, GoodInDocTable, MemberTable})
        Dim Relation As New DataRelation("GoodInDocRelation", GoodTable.Columns("id"), GoodInDocTable.Columns("goodId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation = New DataRelation("InDocGoodRelation", MyBase.InDocTable.Columns("id"), GoodInDocTable.Columns("docId"))
        MyBase.DS.Relations.Add(Relation)
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        '
        ' ID
        '
        MyClass.Id = id
        '
        ' Источник данных нормативных документов
        '
        MyBase.LawDataSet.DataLoad(Me.Connection, Date.Now, False, True, False, True, True, True)

    End Sub

    ''' <summary>
    ''' ID работы
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Property Id As Object
        Get
            Return MyBase.Id
        End Get
        Set(value As Object)
            MyBase.Id = value
            If MyBase.IsEmpty Then Exit Property
            'MyBase.ARow("typeId") = Cprp.DxData.Work.WorkType.IsMilitary
            MyBase.DS.AcceptChanges()
        End Set
    End Property

    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub DataSave()
        Me("percentCount") = GetPercentCount()
        MyBase.DataSave()
    End Sub

    ''' <summary>
    ''' Возвращает процент выполнения работы
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetPercentCount() As Integer
        Dim percentCount As Integer = 0
        ' Если есть хоть 1 товар -> +10%
        If Me.GoodTable.Rows.Count > 0 Then percentCount += 10
        ' Учет товаров, по которым составлены техописания
        If Me.GoodTable.Rows.Count > 0 Then
            Using V As New DataView(Me.GoodTable)
                V.RowFilter = "isCheckData = True"
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
    ''' <param name="loadMember">Загрузить данные российского участника внешнеэкономической операции</param> 
    ''' <param name="loadGood">Загрузить данные продукции</param> 
    ''' <param name="loadInDoc">Загрузить данные использованных документов</param> 
    ''' <remarks></remarks>
    Public Overloads Sub ReadXml(filePath As String, loadMember As Boolean, loadGood As Boolean, loadInDoc As Boolean)
        If Not (loadGood OrElse loadInDoc) Then Exit Sub
        filePath = C2.ToText(filePath)
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Try
            If String.IsNullOrWhiteSpace(filePath) OrElse Not My.Computer.FileSystem.FileExists(filePath) Then
                Throw New Exception("Файл с данными работы не найден.")
            End If
            Using Ds As New DataSet("WorkData")
                Ds.Tables.AddRange(New DataTable() _
                                   {Me.ARow.Clone, Me.GoodTable.Clone, Me.GoodInDocTable.Clone, Me.MemberTable.Clone, _
                                   New Cprp.DxData.Work.InDocDataTable(Me)})
                Ds.ReadXml(filePath, XmlReadMode.IgnoreSchema)
                'Using Ds As New DataSet
                'Ds.ReadXml(filePath, XmlReadMode.ReadSchema)
                '
                ' Данные продукции
                ' ----------------
                '
                If Not loadGood Then GoTo EndGood
                '
                ' Arow
                '
                Me.ARow("goodArea") = DBNull.Value
                Me.ARow("goodUsed") = DBNull.Value
                If Not Ds.Tables("ARow") Is Nothing AndAlso Ds.Tables("ARow").Rows.Count > 0 Then
                    With Ds.Tables("ARow")
                        If .Columns.IndexOf("goodArea") >= 0 Then Me.ARow("goodArea") = C2.ToText(.Rows(0)("goodArea"))
                        If .Columns.IndexOf("goodUsed") >= 0 Then Me.ARow("goodUsed") = C2.ToText(.Rows(0)("goodUsed"))
                    End With
                End If
                '
                ' GoodTable
                '
                GoodInDocTable.Rows.Clear()
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
                                Case "ID", "PARENTID", "DBID", "PARENTDBID", "TYPEID", "ROWNUM", "LAWID"
                                    If IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                                Case "ISNOTDEC", "ISACT"
                                    Row(Col.ColumnName) = CBool(sTmp)
                                Case "ACTDATE"
                                    If IsDate(sTmp) Then Row(Col.ColumnName) = CDate(sTmp)
                                Case Else
                                    Row(Col.ColumnName) = sTmp
                            End Select
                        Next
                        If IsDBNull(Row("id")) Then Continue For
                        GoodTable.Rows.Add(Row)
                    Next
                End With
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
                ' MemberTable
                '
                If Not loadMember Then GoTo EndMember
                MemberTable.Rows.Clear()
                If Ds.Tables("MemberTable") Is Nothing OrElse Ds.Tables("MemberTable").Rows.Count = 0 Then GoTo EndMember
                If Ds.Tables("MemberTable").Columns.IndexOf("supRusNum") < 0 Then GoTo EndMember
                Using V As New DataView(Ds.Tables("MemberTable")) With {.RowFilter = "supRusNum > 0", .Sort = "supRusNum"}
                    If V.Count = 0 Then GoTo EndMember
                    Row = Me.MemberTable.NewRow
                    For Each Col As DataColumn In Ds.Tables("MemberTable").Columns
                        If MemberTable.Columns.IndexOf(Col.ColumnName) < 0 Then Continue For
                        sTmp = C2.ToText(V(0).Row(Col))
                        If Not C2.IsText(sTmp) Then Continue For
                        Select Case Col.ColumnName.ToUpper
                            Case "ID", "DBID", "TYPEID", _
                                "ADDRESSLEGALCOUNTRYID", "ADDRESSFACTCOUNTRYID", "ADDRESSPOSTCOUNTRYID"
                                If IsNumeric(sTmp) Then Row(Col.ColumnName) = CInt(sTmp)
                            Case "ISCONTROL", "ISACT"
                                Row(Col.ColumnName) = CBool(sTmp)
                            Case "ACTDATE"
                                If IsDate(sTmp) Then Row(Col.ColumnName) = CDate(sTmp)
                            Case Else
                                Row(Col.ColumnName) = sTmp
                        End Select
                    Next
                    If Not (IsDBNull(Row("id")) OrElse IsDBNull(Row("typeId"))) Then
                        Me.MemberTable.Rows.Add(Row)
                    End If
                End Using
EndMember:
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
        ' tGood
        '
        Me.GoodTable.UpdateCategoryByType(MyBase.GoodTypeHandbookTable)
        Me.GoodTable.DataInsert(Me.Connection)

    End Sub

End Class
