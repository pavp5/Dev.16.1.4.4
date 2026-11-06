''' <summary>
''' Классификатор стран мира
''' </summary>
''' <remarks></remarks>
Public Class CountryDataTable : Inherits DataTable

    Private _RussiaID As Object = DBNull.Value
    ''' <summary>
    ''' ID России
    ''' </summary>
    Public ReadOnly Property RussiaID As Object
        Get
            Return _RussiaID
        End Get
    End Property

    ''' <summary>
    ''' Представление списка стран без России
    ''' </summary>
    Public NotRusView As DataView = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.CountryDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using cmd As New SqlCommand With {.Connection = Connection}
            cmd.CommandText = "SELECT id, guid, nameShort, nameLong, codAlpha2, codAlpha3, codDec, riskDescription, isControl, isACT FROM tCountry WHERE isACT = 1 ORDER BY nameShort"
            Me.Load(cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' _RussiaID
        '
        For Each R As DataRow In Me.Rows
            If R("nameShort").ToString.ToUpper Like "*РОССИЯ*" Then
                _RussiaID = R("id")
                Exit For
            End If
        Next
        '
        ' NotRusView
        '
        NotRusView = New DataView(Me)
        If Not IsDBNull(_RussiaID) Then
            NotRusView.RowFilter = String.Format("id <> {0}", CInt(_RussiaID))
        End If
    End Sub


    ''' <summary>
    ''' Возвращает ID по краткому наименованию страны 
    ''' </summary>
    ''' <param name="nameShort">Краткое наименование страны</param>
    Public Function GetIdByNameShort(ByVal nameShort As Object) As Object
        Dim sTmp As String = Trim(nameShort.ToString)
        If String.IsNullOrEmpty(sTmp) Then Return DBNull.Value
        Using V As New DataView(Me)
            V.RowFilter = String.Format("nameShort = '{0}'", sTmp)
            If V.Count = 0 Then Return DBNull.Value
            Return V(0)("id")
        End Using
    End Function

    ''' <summary>
    ''' Возвращает ID по коду альфа-2 страны 
    ''' </summary>
    ''' <param name="codAplha2">Код альфа-2 страны</param>
    Public Function GetIdByCodAlpha2(ByVal codAplha2 As Object) As Object
        Dim sTmp As String = Trim(codAplha2.ToString)
        If String.IsNullOrEmpty(sTmp) Then Return DBNull.Value
        Using V As New DataView(Me)
            V.RowFilter = String.Format("codAlpha2 = '{0}'", sTmp)
            If V.Count = 0 Then Return DBNull.Value
            Return V(0)("id")
        End Using
    End Function

    ''' <summary>
    ''' Возвращает ID России
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>Если ничего не найдено возвращает DBNull.Value</remarks>
    Public Shared Function GetRussiaID(Connection As SqlConnection) As Object
        Dim id As Integer = 0
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = "SELECT ISNULL(id, 0) FROM tCountry WHERE nameShort LIKE '%РОССИЯ%' AND isACT = 1"
            id = CInt(Cmd.ExecuteScalar)
        End Using
        If id < 1 Then Return DBNull.Value
        Return id
    End Function

End Class
