''' <summary>
''' Таблица кодов ТН ВЭД товаров
''' </summary>
Friend Class GoodTnvedDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("GoodTnvedTable")
        With Me.Columns
            .Add("goodId", GetType(Integer))
            .Add("tnved", GetType(String))
        End With
        Me.Columns("goodId").AllowDBNull = False
        Me.Columns("tnved").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("tnved")}
    End Sub

End Class
