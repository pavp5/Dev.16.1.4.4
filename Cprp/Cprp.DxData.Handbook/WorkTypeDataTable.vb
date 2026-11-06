''' <summary>
''' Виды услуг
''' </summary>
''' <remarks></remarks>
Public Class WorkTypeDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.WorkTypeDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="showAll">Загрузить все виды услуг</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection, Optional showAll As Boolean = False)
        MyBase.New()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tWorkType WHERE isACT = 1 ORDER BY id"
            If Not showAll Then Cmd.CommandText = Cmd.CommandText.Replace("isACT = 1", "id < 10 AND isACT = 1")
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class