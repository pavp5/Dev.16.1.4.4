''' <summary>
''' Таблица ключевых слов в нормативных документах
''' </summary>
Public Class WordDataTable : Inherits DataTable

    Public Sub New()
        MyBase.New("WordTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("word", GetType(String))
            .Add("excontListCount", GetType(Integer))
            .Add("customsListCount", GetType(Integer))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("word").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
