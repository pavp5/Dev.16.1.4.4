''' <summary>
''' Перечень менеджеров
''' </summary>
''' <remarks></remarks>
Public Class ManagerDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.ManagerDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using cmd As New SqlCommand With {.Connection = Connection}
            cmd.CommandText = "SELECT id, nameShort, nameLong, managerDescription FROM vUser WHERE isManager = 1 AND isACT = 1 ORDER BY nameShort"
            Me.Load(cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class