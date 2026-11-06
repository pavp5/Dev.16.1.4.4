''' <summary>
''' Таблица связей АПУ с контрольными списками
''' </summary>
Friend Class ApuLawDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("ApuLawTable")
        With Me.Columns
            .Add("apuId", GetType(Integer))
            .Add("lawId", GetType(Integer))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("apuId"), Me.Columns("lawId")}
    End Sub

End Class
