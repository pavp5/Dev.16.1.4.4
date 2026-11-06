Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица объектов экспертизы
''' </summary>
''' <remarks></remarks>
Public Class GoodDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Good.GoodDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            ' Поля таблицы tGood
            .Add("id", GetType(Integer))                        ' ID
            .Add("parentId", GetType(Integer))                  ' ID родительской строки
            .Add("nameCon", GetType(String))                    ' Коммерческое наименование
            .Add("nameDec", GetType(String))                    ' Обозначение, марка модель
            .Add("isNotDec", GetType(Boolean))                  ' Обозначение отсутствует
            .Add("categoryId", GetType(Integer))                ' ID категории по ФСТЭК
            .Add("typeId", GetType(Integer))                    ' ID вида объекта
            .Add("tnved", GetType(String))                      ' Код ТН ВЭД
            .Add("tnvedComment", GetType(String))               ' Обоснование кода ТН ВЭД
            .Add("cas", GetType(String))                        ' Номер CAS
            .Add("isUnreal", GetType(Boolean))                  ' Виртуальный объект (да/нет)
            .Add("area", GetType(String))                       ' Область применения
            .Add("used", GetType(String))                       ' Назначение
            .Add("description", GetType(String))                ' Техническое описание
            .Add("riskDescription", GetType(String))            ' Описание выявленных рисков
            .Add("actDate", GetType(Date))                      ' Дата последней актуализации данных
            .Add("isACT", GetType(Boolean))                     ' Данные актуальны (да/нет)
            ' Дополнительные поля
            .Add("dbId", GetType(Integer))                      ' ID строки в таблице базе данных
            .Add("parentDbId", GetType(Integer))                ' ID родительской строки в таблице базы данных
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("isNotDec")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isUnreal")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isACT")
            .AllowDBNull = False
            .DefaultValue = True
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Good.GoodDataTable
    ''' </summary>
    ''' <param name="tableName">Имя таблицы</param>
    ''' <remarks></remarks>
    Public Sub New(tableName As String)
        MyClass.New()
        Me.TableName = tableName
    End Sub


    ''' <summary>
    ''' Вставить новые и измененные записи в таблицу базы данных как новые строки
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>
    ''' В процессе сохранения данных в базу в поле dbId каждой строки
    ''' записывается id соответствующей строки в таблице базы данных
    ''' </remarks>
    Public Overridable Sub DataInsert(Connection As SqlConnection)
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = C2.EMPTY_ID
        '
        ' Временная таблица для сохранения необрезанных наименований
        '
        Dim TmpTable As New DataTable
        With TmpTable
            '
            ' Структура
            '
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("nameCon", GetType(String))
            .PrimaryKey = New DataColumn() {.Columns("id")}
            '
            ' Данные
            '
            For Each Row In Me.Rows
                .Rows.Add(New Object() {Row("id"), Row("nameCon")})
            Next
            .AcceptChanges()
        End With
        '
        ' Обрезание полей до допустимой длины
        '
        MyClass.FiledLenUpdate()
        '
        ' Установка даты актуализации всех записей
        '
        For Each Row In Me.Rows
            Row("actDate") = Date.Now
        Next
        Me.AcceptChanges()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            '
            ' Запись в таблицу базы данных новых строк
            '
            Using A As New SqlDataAdapter( _
                   "SELECT id, parentId, nameCon, nameDec, categoryId, typeId, tnved, tnvedComment, " & _
                   "isUnreal, cas, area, used, description, actDate, isACT " & _
                   "FROM tGood WHERE id IS NULL", Connection)
                Dim B As New SqlCommandBuilder(A)
                For Each Row In Me.Rows
                    '
                    ' Поиск идентичной строки в таблице базы данных
                    '
                    iTmp = C2.EMPTY_ID
                    sTmp = MyClass.GetQueryByRow(Row, True)
                    If C2.IsText(sTmp) Then
                        Cmd.CommandText = String.Format("SELECT ISNULL(MAX(id), -1) FROM tGood WHERE {0}", sTmp)
                        iTmp = CInt(Cmd.ExecuteScalar)
                    End If
                    If iTmp > 0 Then
                        Row("dbId") = iTmp
                    Else
                        '
                        ' Добавление новой строки в таблицу базы данных
                        '
                        Row.SetAdded()
                        A.Update(New DataRow() {Row})
                        Cmd.CommandText = "SELECT @@IDENTITY"
                        Row("dbId") = Cmd.ExecuteScalar
                    End If
                Next
            End Using
        End Using
        '
        ' Обновление dbId родительских строк (parentDbId)
        '
        Using V As New DataView(Me)
            For Each Row In Me.Rows
                V.RowFilter = String.Format("parentId = {0}", C2.ToInt(Row("id")))
                For i As Integer = 0 To V.Count - 1
                    V(i)("parentDbId") = Row("dbId")
                Next
            Next
        End Using
        '
        ' Обновление перезаписываемых данных
        '
        sTmp = "0"
        For Each Row In Me.Rows
            sTmp = String.Format("{0}, {1}", sTmp, C2.ToInt(Row("dbId")))
        Next
        Using A As New SqlDataAdapter(String.Format( _
           "SELECT id, riskDescription, actDate " & _
            "FROM tGood WHERE id IN ({0})", C2.ToStrNum(sTmp, False)), Connection)
            Dim B As New SqlCommandBuilder(A)
            Using T As New DataTable
                T.Load(A.SelectCommand.ExecuteReader)
                T.PrimaryKey = New DataColumn() {T.Columns("id")}
                Using V As New DataView(Me)
                    For i As Integer = 0 To T.Rows.Count - 1
                        V.RowFilter = String.Format("dbId = {0}", CInt(T(i)("id")))
                        If V.Count = 0 Then Continue For
                        T(i)("riskDescription") = V(0)("riskDescription")
                        T(i)("actDate") = Date.Now
                    Next
                End Using
                A.Update(T)
            End Using
        End Using
        '
        ' Восстановление обрезанных наименований
        '
        For i As Integer = 0 To Me.Rows.Count - 1
            Row = TmpTable.Rows.Find(Me(i)("id"))
            If Not Row Is Nothing Then Me(i)("nameCon") = Row("nameCon")
        Next
        TmpTable.Dispose()

    End Sub

    ''' <summary>
    ''' Обрезать содержимое полей по максимально допустимым значениям в таблице базы данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub FiledLenUpdate()
        Dim maxLen As Integer = 0
        Dim sTmp As String = Nothing
        For Each Col As DataColumn In Me.Columns
            Select Case Col.ColumnName.ToUpper
                Case "NAMECON" : maxLen = 500 : Exit Select
                Case "NAMEDEC" : maxLen = 150 : Exit Select
                Case "TNVED" : maxLen = 20 : Exit Select
                Case "CAS" : maxLen = 20 : Exit Select
                Case Else : Continue For
            End Select
            For Each Row As DataRow In Me.Rows
                sTmp = C2.ToText(Row(Col))
                If C2.IsText(sTmp) Then
                    If sTmp.Length > maxLen Then sTmp = sTmp.Substring(0, maxLen)
                    Row(Col) = sTmp
                Else
                    Row(Col) = DBNull.Value
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' Возвращает условия запроса на выборку данных по содержимому строки таблицы объектов экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <param name="useEmptyValue">Использовать пустые значения для построения запроса</param>
    ''' <remarks></remarks>
    Protected Friend Overridable Function GetQueryByRow(Row As DataRow, useEmptyValue As Boolean) As String
        If Row Is Nothing OrElse Row.Table Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        For Each Col As DataColumn In Row.Table.Columns
            sTmp1 = C2.ToText(Row(Col))
            If C2.IsText(sTmp1) Then
                sTmp1 = sTmp1.Replace("'", "''")
                Select Case Col.ColumnName.ToUpper
                    Case "NAMECON" : sTmp = String.Format("nameCon LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "NAMEDEC" : sTmp = String.Format("nameDec LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "CATEGORIYD" : sTmp = String.Format("categoryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                    Case "TYPEYD" : sTmp = String.Format("typeId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                    Case "TNVED" : sTmp = String.Format("tnved LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "TNVEDCOMMENT" : sTmp = String.Format("tnvedComment LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ISUNREAL" : sTmp = String.Format("isUnreal = {0} AND {1}", If(CBool(sTmp1), 1, 0), sTmp) : Exit Select
                    Case "CAS" : sTmp = String.Format("cas LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "AREA" : sTmp = String.Format("area LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "USED" : sTmp = String.Format("used LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "DESCRIPTION" : sTmp = String.Format("description LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                End Select
            ElseIf useEmptyValue Then
                Select Case Col.ColumnName.ToUpper
                    Case "NAMEDEC" : sTmp = String.Format("nameDec IS NULL AND {0}", sTmp) : Exit Select
                    Case "AREA" : sTmp = String.Format("area IS NULL AND {0}", sTmp) : Exit Select
                    Case "USED" : sTmp = String.Format("used IS NULL AND {0}", sTmp) : Exit Select
                    Case "CAS" : sTmp = String.Format("CAS IS NULL AND {0}", sTmp) : Exit Select
                End Select
            End If
        Next
        If C2.IsText(sTmp) Then Return String.Format("{0} id > 0", sTmp)
        Return Nothing
    End Function

    ''' <summary>
    ''' Обновить категории объектов по их видам
    ''' </summary>
    ''' <param name="TypeTable">Справочник видов объектов</param>
    Public Sub UpdateCategoryByType(ByRef TypeTable As Cprp.DxData.Handbook.GoodTypeDataTable)
        Dim TRow As DataRow = Nothing
        For Each Row As DataRow In Me.Rows
            If IsDBNull(Row("typeId")) Then
                TRow = Nothing
            Else
                TRow = TypeTable.Rows.Find(Row("typeId"))
            End If
            If TRow Is Nothing Then
                Row("categoryId") = DBNull.Value
            Else
                Row("categoryId") = TRow("categoryId")
            End If
        Next
    End Sub

End Class
