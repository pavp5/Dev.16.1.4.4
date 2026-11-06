''' <summary>
''' Таблица исследований объектов экспертизы по контрольным спискам
''' </summary>
Public Class GoodLawDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("GoodLawTable")
        With Me.Columns
            .Add("guid", GetType(String))                   ' Guid записи, первичный ключ
            .Add("goodGuid", GetType(String))               ' Guid объекта экспертизы
            .Add("num", GetType(Integer))                   ' Порядковый номер исследования в заключении
            .Add("lawGuid", GetType(String))                ' Guid контрольного списка
            .Add("lawDoc", GetType(String))                 ' Шифр пункта контрольного списка
            .Add("lawId", GetType(Integer))                 ' ID пункта контрольного списка
            .Add("section", GetType(Integer))               ' Номер раздела контрольного списка
            .Add("pos", GetType(String))                    ' Номер пункта контрольного списка
            .Add("lawDescription", GetType(String))         ' Описание пункта контрольного списка
            .Add("goodDescription", GetType(String))        ' Технические характеристики объекта экспертизы
            .Add("sumId", GetType(Integer))                 ' Идентификатор сравнительного анализа (0 - не соответствует, 1 - соответствует)
        End With
        Me.Columns("guid").AllowDBNull = False
        Me.Columns("goodGuid").AllowDBNull = False
        Me.Columns("num").AllowDBNull = False
        Me.Columns("lawGuid").AllowDBNull = False
        Me.Columns("lawDoc").AllowDBNull = False
        Me.Columns("lawId").AllowDBNull = False
        Me.Columns("section").AllowDBNull = False
        Me.Columns("pos").AllowDBNull = False
        Me.Columns("lawDescription").AllowDBNull = False
        Me.Columns("goodDescription").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("guid")}
    End Sub

End Class
