''' <summary>
''' Типы лиц (юридическое, физическое...)
''' </summary>
''' <remarks></remarks>
Public Class MemberTypeDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.MemberTypeDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using cmd As New SqlCommand With {.Connection = Connection}
            cmd.CommandText = "SELECT id, name FROM tMemberType WHERE isACT = 1 ORDER BY id"
            Me.Load(cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class