''' <summary>
''' Таблица объектов экспертизы
''' </summary>
Public Class GoodDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("GoodTable")
        With Me.Columns
            .Add("guid", GetType(String))                   ' Guid записи, первичный ключ
            .Add("docGuid", GetType(String))                ' Guid заключения
            .Add("num", GetType(Integer))                   ' Порядковый номер в заключении
            .Add("name", GetType(String))                   ' Коммерческое наименование
            .Add("catNum", GetType(Integer))                ' Идентификатор категории объекта экспертизы (1, 2, 3 ... 9, 0)
            .Add("catGuid", GetType(String))                ' Guid категории объекта экспертизы
            .Add("used", GetType(String))                   ' Назначение и область применения
            .Add("description", GetType(String))            ' Техническое описание
            .Add("tnved", GetType(String))                  ' Код ТН ВЭД
            .Add("isEmbargo", GetType(Boolean))             ' Признак применения спец. экономических мер (0 - не применяются, 1 - применяются)
            .Add("lawSumId", GetType(Integer))              ' Идентификатор результатов сравнения с контрольными списками (0 - отсутствует, 1 - не соответствует, 2 - соответствует)
            .Add("lawPos", GetType(String))                 ' Перечень пунктов контрольных списков, рассмотренных в исследовании
            .Add("lawList", GetType(String))                ' Перечень обозначений контрольных списков, рассмотренных в исследовании
        End With
        Me.Columns("guid").AllowDBNull = False
        Me.Columns("docGuid").AllowDBNull = False
        Me.Columns("num").AllowDBNull = False
        Me.Columns("name").AllowDBNull = False
        Me.Columns("description").AllowDBNull = False
        Me.Columns("isEmbargo").AllowDBNull = False
        Me.Columns("isEmbargo").DefaultValue = False
        Me.Columns("name").MaxLength = 2100
        Me.Columns("description").MaxLength = 2100
        Me.PrimaryKey = New DataColumn() {Me.Columns("guid")}
    End Sub

End Class
