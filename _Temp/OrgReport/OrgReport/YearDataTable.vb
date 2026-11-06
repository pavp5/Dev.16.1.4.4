''' <summary>
''' Таблица-справочник лет
''' </summary>
Friend Class YearDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("YearTable")
        Me.Columns.Add("year", GetType(Integer)).AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("year")}
        Dim iTmp As Integer = 2021
        Do
            If iTmp > Date.Today.Year Then Exit Do
            Me.Rows.Add(New Object() {iTmp})
            iTmp += 1
        Loop
    End Sub

End Class
