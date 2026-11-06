''' <summary>
''' Таблица связей ключевых слов с контрольными списками
''' </summary>
Public Class WordLawDataTable : Inherits DataTable

    Public Sub New()
        MyBase.New("WordLawTable")
        With Me.Columns
            .Add("wordId", GetType(Integer))
            .Add("lawId", GetType(Integer))
        End With
        Me.Columns("wordId").AllowDBNull = False
        Me.Columns("lawId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("wordId"), Me.Columns("lawId")}
    End Sub

End Class
