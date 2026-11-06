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
        Me.Rows.Add(New Object() {20, "2.1", DBNull.Value, True})
        Me.Rows.Add(New Object() {30, "2.2", DBNull.Value, True})
        Me.Rows.Add(New Object() {40, "2.3", DBNull.Value, True})
        Me.Rows.Add(New Object() {50, "2.4", DBNull.Value, True})
        Me.Rows.Add(New Object() {60, "2.4.1", DBNull.Value, True})
        Me.Rows.Add(New Object() {70, "2.4.2", DBNull.Value, True})
        Me.Rows.Add(New Object() {80, "3", DBNull.Value, True})
        Me.Rows.Add(New Object() {90, "4", DBNull.Value, True})
        Me.Rows.Add(New Object() {100, "4.1", DBNull.Value, True})
        Me.Rows.Add(New Object() {110, "4.2", DBNull.Value, True})
        Me.Rows.Add(New Object() {120, "5", DBNull.Value, True})
        Me.Rows.Add(New Object() {130, "5.1", DBNull.Value, True})
        Me.Rows.Add(New Object() {140, "5.1.а", DBNull.Value, True})
        Me.Rows.Add(New Object() {150, "5.1.б", DBNull.Value, True})
        Me.Rows.Add(New Object() {160, "5.1.в", DBNull.Value, True})
        Me.Rows.Add(New Object() {170, "5.2", DBNull.Value, True})
        Me.Rows.Add(New Object() {180, "6", DBNull.Value, True})
        Me.Rows.Add(New Object() {190, "7", DBNull.Value, True})
        'doc2
        Me.Rows.Add(New Object() {210, "2", DBNull.Value, False})
        Me.Rows.Add(New Object() {220, "2.1", DBNull.Value, False})
        Me.Rows.Add(New Object() {230, "2.2", DBNull.Value, False})
        Me.Rows.Add(New Object() {240, "2.3", DBNull.Value, False})
        Me.Rows.Add(New Object() {250, "2.4", DBNull.Value, False})
        Me.Rows.Add(New Object() {260, "2.4.1", DBNull.Value, False})
        Me.Rows.Add(New Object() {270, "2.4.2", DBNull.Value, False})
        Me.Rows.Add(New Object() {280, "3", DBNull.Value, False})
        Me.Rows.Add(New Object() {290, "4", DBNull.Value, False})
        Me.Rows.Add(New Object() {300, "4.1", DBNull.Value, False})
        Me.Rows.Add(New Object() {310, "4.2", DBNull.Value, False})
        Me.Rows.Add(New Object() {320, "5", DBNull.Value, False})
        Me.Rows.Add(New Object() {330, "5.1", DBNull.Value, False})
        Me.Rows.Add(New Object() {340, "5.1.а", DBNull.Value, False})
        Me.Rows.Add(New Object() {350, "5.1.б", DBNull.Value, False})
        Me.Rows.Add(New Object() {360, "5.1.в", DBNull.Value, False})
        Me.Rows.Add(New Object() {370, "5.2", DBNull.Value, False})
        Me.Rows.Add(New Object() {380, "6", DBNull.Value, False})
        Me.Rows.Add(New Object() {390, "7", DBNull.Value, False})
    End Sub

End Class
