''' <summary>
''' Справочник вариантов решений по внесению изменений
''' </summary>
Friend Class ChangeSummaryDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("ChangeSummaryTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("name").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.Rows.Add(New Object() {1, "Разблокировать старую работу"})
        Me.Rows.Add(New Object() {2, "Создать новую работу"})
        Me.Rows.Add(New Object() {3, "Подготовить письмо в адрес заказчика"})
        Me.Rows.Add(New Object() {3, "Дать устные пояснения заказчику"})

    End Sub
End Class