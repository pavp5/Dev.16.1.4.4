''' <summary>
''' Валюты
''' </summary>
Public Class CurrencyDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.CurrencyDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name, codeLetter, codeDec, country, isACT, nameCode FROM vCurrency WHERE isACT = 1 ORDER BY name"
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
