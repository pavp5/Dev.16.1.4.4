''' <summary>
''' Приложения к лицензиям
''' </summary>
''' <remarks></remarks>
Public Class LicenseAppendDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Liconfirm.LicAppDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("LicenseAppendTable")
        With Me.Columns
            .Add("id", GetType(Integer))            ' ID приложения
            .Add("licId", GetType(Integer))         ' ID лицензии
            .Add("pos", GetType(Integer))           ' Номер пункта приложения
            .Add("stage", GetType(String))          ' Номера этапов
            .Add("description", GetType(String))    ' Описание пункта
            .Add("amount", GetType(String))         ' Количество
            .Add("isCheck", GetType(Boolean))       ' Пункт выбран (да/нет)
        End With
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Liconfirm.LicenseAppendDataTable
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
            Cmd.CommandText = "SELECT id, licId, pos, stage, description, amount FROM tLicenseAppend WHERE isACT = 1"
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
