''' <summary>
''' Таблица товаров из спецификации
''' </summary>
Friend Class GoodDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("GoodTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
            .Add("hs_code", GetType(String))
            .Add("tnved_code", GetType(String))
            .Add("s_count", GetType(Integer))       ' количество совпадающих символов кода HS и кода ТН ВЭД
            .Add("unit", GetType(String))           '
        End With
        Me.Columns("id").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}

    End Sub

End Class
