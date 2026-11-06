''' <summary>
''' Справочник причин внесения изменений
''' </summary>
Friend Class ChangeSourceDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("ChangeSourceTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("name").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.Rows.Add(New Object() {1, "Дополнительная экспертиза"})
        Me.Rows.Add(New Object() {2, "Ошибка эксперта"})
        Me.Rows.Add(New Object() {3, "Продление срока действия заключения экспертизы"})

    End Sub
End Class
