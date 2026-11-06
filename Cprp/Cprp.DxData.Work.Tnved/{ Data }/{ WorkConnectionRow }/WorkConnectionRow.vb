Imports C2 = Cprp.DxData.Common
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Объекты экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodTable As GoodDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Tnved.WorkConnectionRow
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
        '
        ' Источник данных работы
        '
        MyBase.DS.Tables.AddRange(New DataTable() {GoodTable})
        '
        ' ID
        '
        MyClass.Id = id

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
            'MyBase.ARow("typeId") = Cprp.DxData.Work.WorkType.IsTnved
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
        Try
            If String.IsNullOrWhiteSpace(filePath) OrElse Not My.Computer.FileSystem.FileExists(filePath) Then
                Throw New Exception("Файл с данными работы не найден.")
            End If
            Using Ds As New DataSet
                Ds.ReadXml(filePath, XmlReadMode.ReadSchema)
                '
                ' Данные продукции + проверка соответствия
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
                                Case "ID", "PARENTID", "DBID", "PARENTDBID", "TYPEID", "ROWNUM", "LICAPPID"
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
                ' Документы по работе
                ' -------------------
                '
                If Not loadDocument Then GoTo EndDocument
                Me.ARow("doc1Data") = DBNull.Value
                Me.ARow("doc1RegNum") = DBNull.Value
                Me.ARow("doc1RegDate") = DBNull.Value
                Me.ARow("doc1SummaryId") = DBNull.Value
                Me.ARow("ref1Data") = DBNull.Value
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
        ' tGood
        '
        Me.GoodTable.UpdateCategoryByType(MyBase.GoodTypeHandbookTable)
        Me.GoodTable.DataInsert(Me.Connection)

    End Sub

End Class
