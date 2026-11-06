Imports C2 = Cprp.DxData.Common
''' <summary>
''' Сделки
''' </summary>
''' <remarks></remarks>
Public Class ContractDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Участники сделки
    ''' </summary>
    Public MemberTable As DataTable = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Contract.ContractDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        '
        ' Me
        '
        MyBase.New()
        With Me.Columns
            ' Поля таблицы tMember
            .Add("id", GetType(Integer))                        ' ID
            .Add("docName", GetType(String))                    ' Наименование документа-основания сделки
            .Add("docNum", GetType(String))                     ' Номер документа-основания сделки
            .Add("docDate", GetType(Date))                      ' Дата документа-основания сделки
            .Add("docTerm", GetType(Date))                      ' Срок действия сделки
            .Add("isNotTerm", GetType(Boolean))                 ' Сделка без срока действия (до исполнения обязательств)
            .Add("description", GetType(String))                ' Описание предмета сделки
            .Add("riskDescription", GetType(String))            ' Описание выявленных рисков
            .Add("actDate", GetType(Date))                      ' Дата последней актуализации записи
            .Add("isACT", GetType(Boolean))                     ' Данные актуальны (да/нет)
            ' Дополнительные поля
            .Add("dbId", GetType(Integer))                      ' ID строки в таблице tContract базы данных
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("isNotTerm")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isACT")
            .AllowDBNull = False
            .DefaultValue = True
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' MemberTable
        '
        MemberTable = New DataTable
        With MemberTable.Columns
            ' Поля таблицы tContractMember
            .Add("contractId", GetType(Integer))                ' ID сделки
            .Add("memberId", GetType(Integer))                  ' ID участника
            .Add("kindId", GetType(Integer))                    ' Вид участника
            ' Дополнительные поля
            .Add("memberDbId", GetType(Integer))                ' ID строки в таблице tMember базы данных
        End With
        MemberTable.PrimaryKey = New DataColumn() {MemberTable.Columns("memberId"), MemberTable.Columns("kindId")}

    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Contract.ContractDataTable
    ''' </summary>
    ''' <param name="tableName">Имя таблицы</param>
    ''' <remarks></remarks>
    Public Sub New(tableName As String)
        MyClass.New()
        Me.TableName = tableName
    End Sub


    ''' <summary>
    ''' Сохранить новые и измененные данные в таблицы базы данных как новые записи
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>
    ''' В процессе сохранения в поле dbId каждой строки записывается id соответствующей строки в таблице базы данных
    ''' </remarks>
    Public Sub DataInsert(Connection As SqlConnection)
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        MyClass.FiledLenUpdate()
        Me.AcceptChanges()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Using V As New DataView(Me.MemberTable)
                '
                ' Выявление новых строк в текущей таблице сделок
                '
                Using T As New DataTable    ' Таблица для хранения id строк, найденных в tContract 
                    T.Columns.Add("id", GetType(Integer))
                    T.PrimaryKey = New DataColumn() {T.Columns("id")}
                    '
                    ' Цикл по текущей таблице сделок
                    '
                    For Each Row In Me.Rows
                        Row("dbId") = C2.EMPTY_ID   ' dbId < 1 - признак новой строки
                        sTmp = MyClass.GetQueryByRow(Row, True)
                        If Not C2.IsText(sTmp) Then Continue For
                        V.RowFilter = String.Format("contractId = {0}", CInt(Row("id")))    ' участники текущей сделки
                        T.Rows.Clear()
                        Cmd.CommandText = String.Format("SELECT id FROM tContract WHERE {0}", sTmp)
                        T.Load(Cmd.ExecuteReader)
                        '
                        ' Цикл по id строк, найденных в tContract по текущей сделке
                        '
                        For i As Integer = 0 To T.Rows.Count - 1
                            '
                            ' Проверка совпадения количества участников в tContractMember и в текущей сделке
                            '
                            Cmd.CommandText = String.Format( _
                                "SELECT COUNT(*) FROM tContractMember WHERE contractId = {0}", CInt(T(i)("id")))
                            If CInt(Cmd.ExecuteScalar) <> V.Count Then Continue For
                            '
                            ' Проверка совпадения всех участников в tContractMember и в текущей сделке
                            '
                            Row("dbId") = T(i)("id")    ' предварительно
                            For j As Integer = 0 To V.Count - 1
                                Cmd.CommandText = String.Format( _
                                    "SELECT COUNT(*) FROM tContractMember WHERE contractId = {0} AND memberId = {1} AND kindId = {2}", _
                                    CInt(Row("dbId")), CInt(V(j)("memberDbId")), CInt(V(j)("kindId")))
                                If CInt(Cmd.ExecuteScalar) < 1 Then
                                    Row("dbId") = C2.EMPTY_ID
                                    Exit For
                                End If
                            Next
                            If CInt(Row("dbId")) > 0 Then Exit For
                        Next
                    Next
                End Using
                '
                ' Запись в tContract и tContractMember новых строк
                '
                Me.AcceptChanges()
                Using A As New SqlDataAdapter( _
                    "SELECT id, docName, docNum, docDate, docTerm, isNotTerm, description, actDate, isACT " & _
                    "FROM tContract WHERE id IS NULL", Connection)
                    Dim B As New SqlCommandBuilder(A)
                    For Each Row In Me.Rows
                        If C2.ToInt(Row("dbId")) > 0 Then Continue For
                        Row.SetAdded()
                        A.Update(New DataRow() {Row})
                        Cmd.CommandText = "SELECT @@IDENTITY"
                        Row("dbId") = Cmd.ExecuteScalar
                        V.RowFilter = String.Format("contractId = {0}", CInt(Row("id")))
                        For i As Integer = 0 To V.Count - 1
                            Cmd.CommandText = String.Format( _
                                "INSERT tContractMember(contractId, memberId, kindId) VALUES ({0}, {1}, {2})", _
                                CInt(Row("dbId")), CInt(V(i)("memberDbId")), CInt(V(i)("kindId")))
                            Cmd.ExecuteNonQuery()
                        Next
                    Next
                End Using
            End Using
        End Using
        '
        ' Обновление перезаписываемых данных
        '
        sTmp = "0"
        For Each Row In Me.Rows
            sTmp = String.Format("{0}, {1}", sTmp, C2.ToInt(Row("dbId")))
        Next
        Using A As New SqlDataAdapter(String.Format( _
            "SELECT id, docTerm, isNotTerm, description, riskDescription, actDate FROM tContract WHERE id IN ({0})", _
            C2.ToStrNum(sTmp, False)), Connection)
            Dim B As New SqlCommandBuilder(A)
            Using T As New DataTable
                T.Load(A.SelectCommand.ExecuteReader)
                T.PrimaryKey = New DataColumn() {T.Columns("id")}
                Using V As New DataView(Me)
                    For i As Integer = 0 To T.Rows.Count - 1
                        V.RowFilter = String.Format("dbId = {0}", CInt(T(i)("id")))
                        If V.Count = 0 Then Continue For
                        T(i)("docTerm") = V(0)("docTerm")
                        T(i)("isNotTerm") = V(0)("isNotTerm")
                        T(i)("description") = V(0)("description")
                        T(i)("riskDescription") = V(0)("riskDescription")
                        T(i)("actDate") = Date.Now
                    Next
                End Using
                A.Update(T)
            End Using
        End Using


    End Sub


    ''' <summary>
    ''' Обрезать содержимое полей по максимально допустимым значениям в таблице базы данных
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub FiledLenUpdate()
        Dim maxLen As Integer = 0
        Dim sTmp As String = Nothing
        'C2.UpdateEmptyStringFields(Me)
        For Each Col As DataColumn In Me.Columns
            Select Case Col.ColumnName.ToUpper
                Case "DOCNAME" : maxLen = 250 : Exit Select
                Case "DOCNUM" : maxLen = 100 : Exit Select
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
    ''' Возвращает условия запроса на выборку данных по содержимому строки таблицы сделок
    ''' </summary>
    ''' <param name="Row">Строка таблицы сделок</param>
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
                    Case "DOCNAME" : sTmp = String.Format("docName LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "DOCNUM" : sTmp = String.Format("docNum LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "DOCDATE" : sTmp = String.Format("docDate >= {{ts '{0:yyyy-MM-dd 00:00:00}'}} AND docDate < {{ts '{1:yyyy-MM-dd 00:00:00}'}} AND {2}", CDate(sTmp1), CDate(sTmp1).AddDays(1), sTmp) : Exit Select
                    Case "DOCTERM" : sTmp = String.Format("docTerm >= {{ts '{0:yyyy-MM-dd 00:00:00}'}} AND docTerm < {{ts '{1:yyyy-MM-dd 00:00:00}'}} AND {2}", CDate(sTmp1), CDate(sTmp1).AddDays(1), sTmp) : Exit Select
                End Select
            ElseIf useEmptyValue Then
                Select Case Col.ColumnName.ToUpper
                    Case "DOCNUM" : sTmp = String.Format("docNum IS NULL AND {0}", sTmp) : Exit Select
                    Case "DOCDATE" : sTmp = String.Format("docDate IS NULL AND {0}", sTmp) : Exit Select
                End Select
            End If
        Next
        If C2.IsText(sTmp) Then Return String.Format("{0} isACT = 1", sTmp)
        Return Nothing
    End Function

End Class
