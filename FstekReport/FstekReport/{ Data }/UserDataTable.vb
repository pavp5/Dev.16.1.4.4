''' <summary>
''' Таблица подписантов заключений
''' </summary>
Public Class UserDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("UserTable")
        With Me.Columns
            .Add("guid", GetType(String))                   ' Guid записи, первичный ключ
            .Add("docGuid", GetType(String))                ' Guid заключения
            .Add("nameLast", GetType(String))               ' Фамилия
            .Add("nameMiddle", GetType(String))             ' Имя
            .Add("nameFirst", GetType(String))              ' Отчество
            .Add("job", GetType(String))                    ' Должность
        End With
        Me.Columns("guid").AllowDBNull = False
        Me.Columns("docGuid").AllowDBNull = False
        Me.Columns("nameLast").AllowDBNull = False
        Me.Columns("nameFirst").AllowDBNull = False
        Me.Columns("job").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("guid"), Me.Columns("docGuid")}
    End Sub

End Class
