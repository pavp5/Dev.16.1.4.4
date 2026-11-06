''' <summary>
''' Таблица конечных пользователей
''' </summary>
Public Class EndDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("EndTable")
        With Me.Columns
            .Add("guid", GetType(String))                   ' Guid записи, первичный ключ
            .Add("docGuid", GetType(String))                ' Guid заключения
            .Add("num", GetType(Integer))                   ' Порядковый номер
            .Add("countryGuid", GetType(String))            ' Guid страны юридического адреса
            .Add("name", GetType(String))                   ' Наименование иностранного участника
            .Add("address", GetType(String))                ' Адрес иностранного участника
        End With
        Me.Columns("guid").AllowDBNull = False
        Me.Columns("docGuid").AllowDBNull = False
        Me.Columns("num").AllowDBNull = False
        Me.Columns("countryGuid").AllowDBNull = False
        Me.Columns("name").AllowDBNull = False
        Me.Columns("address").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("guid")}
    End Sub

End Class
