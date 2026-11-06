''' <summary>
''' Справочник выводов экспертизы
''' </summary>
Friend Class SummaryDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("SummaryTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        With Me.Rows
            .Add(New Object() {2, "ТРЕБУЕТСЯ ПОЛУЧЕНИЕ ЛИЦЕНЗИИ ФСТЭК"})
            .Add(New Object() {3, "ТРЕБУЕТСЯ ПОЛУЧЕНИЕ РАЗРЕШЕНИЯ КЭК"})
        End With
    End Sub

End Class
