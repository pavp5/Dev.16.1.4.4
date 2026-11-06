''' <summary>
''' Таблица-справочник месяцев
''' </summary>
Friend Class MonthDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("MonthTable")
        With Me.Columns
            .Add("id", GetType(Integer)).AllowDBNull = False
            .Add("name", GetType(String)).AllowDBNull = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.DefaultView.Sort = "id"
        Me.Rows.Add(New Object() {1, "Январь"})
        Me.Rows.Add(New Object() {2, "Февраль"})
        Me.Rows.Add(New Object() {3, "Март"})
        Me.Rows.Add(New Object() {4, "Апрель"})
        Me.Rows.Add(New Object() {5, "Май"})
        Me.Rows.Add(New Object() {6, "Июнь"})
        Me.Rows.Add(New Object() {7, "Июль"})
        Me.Rows.Add(New Object() {8, "Август"})
        Me.Rows.Add(New Object() {9, "Сентябрь"})
        Me.Rows.Add(New Object() {10, "Октябрь"})
        Me.Rows.Add(New Object() {11, "Ноябрь"})
        Me.Rows.Add(New Object() {12, "Декабрь"})
    End Sub

End Class
