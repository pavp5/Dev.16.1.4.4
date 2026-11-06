''' <summary>
''' Пояснения эксперта к разделам (пунктам) заключения
''' </summary>
''' <remarks></remarks>
Friend Class CommentDataTable : Inherits Cprp.DxData.Base.BaseDataTable

     Friend Sub New()
        MyBase.New("CommentTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
            .Add("comment", GetType(String))
            .Add("isDoc1", GetType(Boolean))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Инициализация таблицы начальными значениями
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub DataInit()
        Me.Rows.Clear()
        ' doc1
        Me.Rows.Add(New Object() {10, "2", DBNull.Value, True})
        Me.Rows.Add(New Object() {20, "3", DBNull.Value, True})
        Me.Rows.Add(New Object() {30, "4", DBNull.Value, True})
        Me.Rows.Add(New Object() {40, "5", DBNull.Value, True})
        Me.Rows.Add(New Object() {50, "6", DBNull.Value, True})
    End Sub

End Class
