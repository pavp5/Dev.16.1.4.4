''' <summary>
''' Таблица результатов обработки сообщения
''' </summary>
Public Class ResultDataTable : Inherits DataTable

    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("code", GetType(Integer))
            .Add("message", GetType(String))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Добавляет и возвращает новую строку
    ''' </summary>
    ''' <param name="code">Код сообщения</param>
    ''' <param name="message">Текст сообщения</param>
    Public Function AddRow(code As Integer, message As String) As DataRow
        Dim Row As DataRow = Me.NewRow
        Row("code") = code
        Row("message") = message
        Me.Rows.Add(Row)
        Return Row
    End Function

End Class
