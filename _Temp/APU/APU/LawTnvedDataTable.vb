''' <summary>
''' Таблица контрольных списков с кодами ТН ВЭД 
''' </summary>
Friend Class LawTnvedDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("LawTnvedTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))
            .Add("code", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId"), Me.Columns("code")}
    End Sub

End Class
