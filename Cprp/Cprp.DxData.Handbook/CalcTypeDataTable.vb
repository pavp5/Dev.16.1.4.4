''' <summary>
''' Виды расчетов стоимости заказа
''' </summary>
''' <remarks></remarks>
Public Class CalcTypeDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.CalcTypeDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using cmd As New SqlCommand With {.Connection = Connection}
            cmd.CommandText = "SELECT * FROM tCalcType WHERE isACT = 1 ORDER BY rowNum"
            Me.Load(cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class

