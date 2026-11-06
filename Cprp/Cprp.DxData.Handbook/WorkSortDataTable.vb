''' <summary>
''' Типы работ
''' </summary>
''' <remarks></remarks>
Public Class WorkSortDataTable : Inherits DataTable
    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.MemberTypeDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name, sortId FROM tWorkSort WHERE isACT = 1 ORDER BY sortId"
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.DefaultView.Sort = "sortId"
    End Sub
End Class
