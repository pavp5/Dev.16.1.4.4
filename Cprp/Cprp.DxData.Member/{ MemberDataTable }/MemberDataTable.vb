Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица лиц
''' </summary>
''' <remarks></remarks>
Public Class MemberDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Member.MemberDataTable
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
            .Add("nameLong", GetType(String))                   ' Полное наименование
            .Add("nameShort", GetType(String))                  ' Краткое наименование
            .Add("typeId", GetType(Integer))                    ' Вид лица 
            .Add("inn", GetType(String))                        ' ИНН
            .Add("kpp", GetType(String))                        ' КПП
            .Add("ogrn", GetType(String))                       ' ОГРН
            .Add("ogrnDate", GetType(Date))                     ' Дата регистрации ОГРН
            .Add("passportSer", GetType(String))                ' Серия паспорта
            .Add("passportNum", GetType(String))                ' Номер паспорта
            .Add("passportGive", GetType(String))               ' Паспорт выдан
            .Add("phone", GetType(String))                      ' Телефон
            .Add("fax", GetType(String))                        ' Факс
            .Add("email", GetType(String))                      ' Е-mail
            .Add("web", GetType(String))                        ' web
            .Add("addressLegalFull", GetType(String))           ' Полный юридический адрес
            .Add("addressLegalCountryId", GetType(Integer))     ' Страна юридического адреса
            .Add("addressLegalTown", GetType(String))           ' Город юридического адреса
            .Add("addressLegalDate", GetType(Date))             ' Дата регистрации юридического адреса
            .Add("addressFactFull", GetType(String))            ' Полный фактический адрес
            .Add("addressFactCountryId", GetType(Integer))      ' Страна фактического адреса
            .Add("addressFactTown", GetType(String))            ' Город фактического адреса
            .Add("addressPostFull", GetType(String))            ' Полный почтовый адрес
            .Add("addressPostCountryId", GetType(Integer))      ' Страна почтового адреса
            .Add("addressPostTown", GetType(String))            ' Город почтового адреса
            .Add("proDescription", GetType(String))             ' Профиль - Описание деятельности фирмы
            .Add("proSource", GetType(String))                  ' Профиль - Источник данных для заполнения профиля
            .Add("isControl", GetType(Boolean))                 ' Имеются риски по экспортному контролю (да/нет)
            .Add("actDate", GetType(Date))                      ' Дата последней актуализации записи
            .Add("xmlActDate", GetType(Date))                   ' Дата актуализации xml-данных
            .Add("xmlCard", GetType(String))                    ' Карточка компании (xml)
            .Add("xmlCourt", GetType(String))                   ' Судебные дела компании (xml)
            .Add("leaderPost", GetType(String))                 ' Должность руководителя
            .Add("leaderName", GetType(String))                 ' ФИО руководителя

            .Add("isACT", GetType(Boolean))                     ' Данные актуальны (да/нет)
            ' Дополнительные поля
            .Add("dbId", GetType(Integer))                      ' ID строки в таблице базы данных
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("typeId")
            .AllowDBNull = False
            .DefaultValue = MemberType.IsLegal                  ' Юридическое лицо
        End With
        With Me.Columns("isControl")                            ' На контроле = Нет
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
    ''' Инициализация нового экземпляра класса Cprp.DxData.Member.MemberDataTable
    ''' </summary>
    ''' <param name="tableName">Имя таблицы</param>
    ''' <remarks></remarks>
    Public Sub New(tableName As String)
        MyClass.New()
        Me.TableName = tableName
    End Sub


    ''' <summary>
    ''' Сохранить новые и измененные данные в таблицу базы данных как новые записи
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>
    ''' В процессе сохранения в поле dbId каждой строки записывается id соответствующей строки в таблице базы данных
    ''' </remarks>
    Public Sub DataInsert(Connection As SqlConnection)
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = "0"
        Dim iTmp As Integer = C2.EMPTY_ID
        MyClass.FiledLenUpdate()
        MyClass.CheckXmlData()
        Me.AcceptChanges()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Using A As New SqlDataAdapter( _
                   "SELECT id, nameLong, nameShort, typeId, inn, kpp, ogrn, ogrnDate, " & _
                   "passportSer, passportNum, passportGive, " & _
                   "phone, fax, email, web, " & _
                   "addressLegalFull, addressLegalCountryId, addressLegalTown, addressLegalDate, " & _
                   "addressFactFull, addressFactCountryId, addressFactTown, " & _
                   "addressPostFull, addressPostCountryId, addressPostTown, " & _
                   "proDescription, proSource, isControl, actDate, xmlActDate, xmlCard, xmlCourt, leaderPost, leaderName, isACT " & _
                   "FROM tMember", Connection)
                Dim B As New SqlCommandBuilder(A)
                For Each Row In Me.Rows
                    '
                    ' Поиск идентичной строки в tMember
                    '
                    iTmp = C2.EMPTY_ID
                    sTmp = MyClass.GetQueryByRow(Row, True)
                    If C2.IsText(sTmp) Then
                        Cmd.CommandText = String.Format("SELECT ISNULL(MAX(id), -1) FROM tMember WHERE {0}", sTmp)
                        iTmp = CInt(Cmd.ExecuteScalar)
                    End If
                    If iTmp > 0 Then
                        Row("dbId") = iTmp
                        sTmp1 = String.Format("{0}, {1}", sTmp1, iTmp)  ' формирование строки id идентичных строк
                    Else
                        '
                        ' Запись новой строки в tMember
                        '
                        Row.SetAdded()
                        A.Update(New DataRow() {Row})
                        Cmd.CommandText = "SELECT @@IDENTITY"
                        Row("dbId") = Cmd.ExecuteScalar
                    End If
                Next
                '
                ' Обновление идентичных строк
                '
                Cmd.CommandText = String.Format("{0} WHERE id IN ({1})", A.SelectCommand.CommandText, sTmp1)
                Using T As New DataTable
                    T.Load(Cmd.ExecuteReader)
                    T.PrimaryKey = New DataColumn() {T.Columns("id")}
                    Using V As New DataView(Me)
                        For i As Integer = 0 To T.Rows.Count - 1
                            V.RowFilter = String.Format("dbId = {0}", CInt(T(i)("id")))
                            If V.Count = 0 Then Continue For
                            For Each Col As DataColumn In T.Columns
                                Select Case Col.ColumnName.ToUpper
                                    Case "ID", "ACTDATE", "ISACT"
                                        Continue For
                                    Case Else
                                        T(i)(Col) = V(0)(Col.ColumnName)
                                End Select
                            Next
                            T(i)("actDate") = Date.Now
                        Next
                    End Using
                    A.Update(T)
                End Using
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
        For Each Col As DataColumn In Me.Columns
            Select Case Col.ColumnName.ToUpper
                Case "NAMELONG" : maxLen = 500 : Exit Select
                Case "NAMESHORT" : maxLen = 500 : Exit Select
                Case "INN" : maxLen = 20 : Exit Select
                Case "KPP" : maxLen = 20 : Exit Select
                Case "OGRN" : maxLen = 20 : Exit Select
                Case "PASSPORTSER" : maxLen = 50 : Exit Select
                Case "PASSPORTNUM" : maxLen = 50 : Exit Select
                Case "PASSPORTGIVE" : maxLen = 500 : Exit Select
                Case "PHONE" : maxLen = 50 : Exit Select
                Case "FAX" : maxLen = 50 : Exit Select
                Case "EMAIL" : maxLen = 100 : Exit Select
                Case "WEB" : maxLen = 100 : Exit Select
                Case "ADDRESSLEGALFULL" : maxLen = 500 : Exit Select
                Case "ADDRESSLEGALTOWN" : maxLen = 50 : Exit Select
                Case "ADDRESSFACTFULL" : maxLen = 500 : Exit Select
                Case "ADDRESSFACTTOWN" : maxLen = 50 : Exit Select
                Case "ADDRESSPOSTFULL" : maxLen = 500 : Exit Select
                Case "ADDRESSPOSTTOWN" : maxLen = 50 : Exit Select
                Case "LEADERPOST" : maxLen = 250 : Exit For
                Case "LEADERNAME" : maxLen = 250 : Exit For
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
    ''' Проверить данные, загруженные из xml-объектов
    ''' </summary>
    Private Sub CheckXmlData()
        For Each Row As DataRow In Me.Rows
            If Not IsDBNull(Row("addressLegalDate")) AndAlso CDate(Row("addressLegalDate")) < Date.Now.AddYears(-100) Then
                Row("addressLegalDate") = DBNull.Value
            End If
            If Not IsDBNull(Row("ogrnDate")) AndAlso CDate(Row("ogrnDate")) < Date.Now.AddYears(-100) Then
                Row("ogrnDate") = DBNull.Value
                Row("xmlActDate") = DBNull.Value
                Row("xmlCard") = DBNull.Value
                Row("xmlCourt") = DBNull.Value
            End If
        Next
    End Sub


    ''' <summary>
    ''' Возвращает условия запроса на выборку данных по содержимому строки таблицы лиц
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="useEmptyValue">Использовать пустые значения для построения запроса</param>
    ''' <remarks></remarks>
    Protected Friend Overridable Function GetQueryByRow(Row As DataRow, useEmptyValue As Boolean) As String
        If Row Is Nothing OrElse Row.Table Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        '
        ' Поиск российского лица по ИНН
        '
        sTmp = C2.ToText(Row("inn"))
        If C2.IsText(sTmp) Then Return String.Format("inn LIKE '{0}' AND isACT = 1", sTmp)
        '
        ' Поиск других лиц по совокупности параметров
        '
        For Each Col As DataColumn In Row.Table.Columns
            sTmp1 = C2.ToText(Row(Col))
            If C2.IsText(sTmp1) Then
                sTmp1 = sTmp1.Replace("'", "''")
                Select Case Col.ColumnName.ToUpper
                    Case "NAMELONG" : sTmp = String.Format("nameLong LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "NAMESHORT" : sTmp = String.Format("nameShort LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "TYPEID" : sTmp = String.Format("typeId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                    Case "INN" : sTmp = String.Format("inn LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "KPP" : sTmp = String.Format("kpp LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "PASSPORTSER" : sTmp = String.Format("passportSer LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "PASSPORTNUM" : sTmp = String.Format("passportNum LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "PASSPORTGIVE" : sTmp = String.Format("passportGive LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "PHONE" : sTmp = String.Format("phone LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "FAX" : sTmp = String.Format("fax LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "EMAIL" : sTmp = String.Format("email LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "WEB" : sTmp = String.Format("web LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSLEGALFULL" : sTmp = String.Format("addressLegalFull LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSLEGALCOUNTRYID" : sTmp = String.Format("addressLegalCountryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSLEGALTOWN" : sTmp = String.Format("addressLegalTown LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSFACTFULL" : sTmp = String.Format("addressFactFull LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSFACTCOUNTRYID" : sTmp = String.Format("addressFactCountryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSFACTTOWN" : sTmp = String.Format("addressFactTown LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSPOSTFULL" : sTmp = String.Format("addressPostFull LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSPOSTCOUNTRYID" : sTmp = String.Format("addressPostCountryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                    Case "ADDRESSPOSTTOWN" : sTmp = String.Format("addressPostTown LIKE '{0}' AND {1}", sTmp1, sTmp) : Exit Select
                End Select
            ElseIf useEmptyValue Then
                Select Case Col.ColumnName.ToUpper
                    Case "INN" : sTmp = String.Format("inn IS NULL AND {0}", sTmp) : Exit Select
                    Case "KPP" : sTmp = String.Format("kpp IS NULL AND {0}", sTmp) : Exit Select
                    Case "PASSPORTSER" : sTmp = String.Format("passportSer IS NULL AND {0}", sTmp) : Exit Select
                    Case "PASSPORTNUM" : sTmp = String.Format("passportNum IS NULL AND {0}", sTmp) : Exit Select
                    Case "PASSPORTGIVE" : sTmp = String.Format("passportGive IS NULL AND {0}", sTmp) : Exit Select
                    Case "PHONE" : sTmp = String.Format("phone IS NULL AND {0}", sTmp) : Exit Select
                    Case "FAX" : sTmp = String.Format("fax IS NULL AND {0}", sTmp) : Exit Select
                    Case "EMAIL" : sTmp = String.Format("email IS NULL AND {0}", sTmp) : Exit Select
                    Case "WEB" : sTmp = String.Format("web IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSLEGALFULL" : sTmp = String.Format("addressLegalFull IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSLEGALCOUNTRYID" : sTmp = String.Format("addressLegalCountryId IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSLEGALTOWN" : sTmp = String.Format("addressLegalTown IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSFACTFULL" : sTmp = String.Format("addressFactFull IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSFACTCOUNTRYID" : sTmp = String.Format("addressFactCountryId IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSFACTTOWN" : sTmp = String.Format("addressFactTown IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSPOSTFULL" : sTmp = String.Format("addressPostFull IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSPOSTCOUNTRYID" : sTmp = String.Format("addressPostCountryId IS NULL AND {0}", sTmp) : Exit Select
                    Case "ADDRESSPOSTTOWN" : sTmp = String.Format("addressPostTown IS NULL AND {0}", sTmp) : Exit Select
                End Select
            End If
        Next
        If C2.IsText(sTmp) Then Return String.Format("{0} isACT = 1", sTmp)
        Return Nothing
    End Function


End Class
