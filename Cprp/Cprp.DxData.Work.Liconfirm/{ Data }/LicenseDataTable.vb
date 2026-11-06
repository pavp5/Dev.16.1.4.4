''' <summary>
''' Лицензии
''' </summary>
''' <remarks></remarks>
Public Class LicenseDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Liconfirm.LicAppDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("LicenseTable")
        With Me.Columns
            .Add("id", GetType(Integer))            ' ID
            .Add("regNum", GetType(String))         ' Номер лицензии
            .Add("regDate", GetType(Date))          ' Дата лицензии
            .Add("caption", GetType(String))        ' Сведения о лицензии
            .Add("description", GetType(String))    ' Сведения об операции
            .Add("countryId", GetType(Integer))     ' ID страны назначения
            .Add("contractName", GetType(String))   ' Документ-основание сделки
            .Add("rusName", GetType(String))        ' Российский участник
            .Add("nusName", GetType(String))        ' Иностранный покупатель
            .Add("endName", GetType(String))        ' Потребитель (конечный пользователь)
            .Add("regNumCaption", GetType(String))  ' [Номер лицензии] от [Дата лицензии] ([Сведения о лицензии])
            .Add("countryName", GetType(String))    ' Краткое наименование страны назначения
            .Add("isCheck", GetType(Boolean))       ' Пункт выбран (да/нет)
        End With
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Liconfirm.LicenceDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        MyClass.New()
        DataLoad(Connection)
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub DataLoad(Connection As SqlConnection)
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        Me.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT id, regNum, regDate, caption, description, countryId, contractName, rusName, nusName, endName, regNumCaption, countryName FROM vLicense WHERE term > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", Date.Now)
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Очистить выделенные пункты
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckClear()
        Using V As New DataView(Me)
            V.RowFilter = "isCheck = True"
            While V.Count > 0
                V(0)("isCheck") = False
            End While
        End Using
    End Sub

End Class