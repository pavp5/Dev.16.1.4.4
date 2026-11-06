''' <summary>
''' Таблица синонимов терминов АПУ
''' </summary>
Friend Class SynonDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("SynonTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("word1", GetType(String))  ' основное слова (фраза)
            .Add("word2", GetType(String))  ' слова (фразы) - синонимы, разделенные символом "="
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.Columns("word1").AllowDBNull = False
        Me.Columns("word2").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
