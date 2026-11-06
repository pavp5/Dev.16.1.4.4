''' <summary>
''' Таблица заключений
''' </summary>
Public Class DocDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("DocTable")
        With Me.Columns
            .Add("guid", GetType(String))                   ' Guid записи, первичный ключ
            .Add("pGuid", GetType(String))                  ' Guid первичного заключения
            .Add("workId", GetType(Integer))                ' ID работы
            .Add("num", GetType(Integer))                   ' Порядковый номер заключения в году
            .Add("docNum", GetType(String))                 ' Регистрационный номер заключения
            .Add("pDocNum", GetType(String))                ' Регистрационный номер первичного заключения
            .Add("docDate", GetType(Date))                  ' Дата регистрации заключения
            .Add("docTerm", GetType(Date))                  ' Срок действия заключения
            .Add("docTermId", GetType(Integer))             ' Идентификатор иного срока действия заключения (0 - бессрочное, 1 - в течении исполнения обязательств по сделке)
            .Add("clientName", GetType(String))             ' Наименование заказчика экспертизы
            .Add("clientInn", GetType(String))              ' ИНН заказчика экспертизы
            .Add("clientAddress", GetType(String))          ' Адрес заказчика экспертизы
            .Add("clientPhone", GetType(String))            ' Телефон заказчика экспертизы
            .Add("clientFax", GetType(String))              ' Факс заказчика экспертизы
            .Add("isExport", GetType(Boolean))              ' Направление перемещения (0 - В Россию, 1 - Из России)
            .Add("countryName", GetType(String))            ' Наименование страны назначения / отправления
            .Add("countryGuid", GetType(String))            ' Guid страны назначения / отправления
            .Add("countryExistId", GetType(Integer))        ' Идентификатор признака наличия страны назначения / отправления (2 - страна имеется, если нет, то пустое значение)
            .Add("isCountryEmbargo", GetType(Boolean))      ' Признак применения спец. экономических мер к стране назначения / отправления (0 - не применяются, 1 - применяются)
            .Add("conName", GetType(String))                ' Наименование документа-основания сделки
            .Add("conNum", GetType(String))                 ' Номер документа-основание сделки
            .Add("conDate", GetType(Date))                  ' Дата документа-основания сделки
            .Add("conTerm", GetType(Date))                  ' Срок действия документа-основания сделки
            .Add("conTermId", GetType(Integer))             ' Идентификатор иного срока действия документа-основания сделки (1 - в течении исполнения обязательств, если нет срока действия)
            .Add("rusName", GetType(String))                ' Наименование российского участника
            .Add("rusInn", GetType(String))                 ' ИНН российского участника
            .Add("rusAddress", GetType(String))             ' Адрес российского участника
            .Add("nusName", GetType(String))                ' Наименование иностранного участника
            .Add("nusAddress", GetType(String))             ' Адрес иностранного участника
            .Add("isNusEmbargo", GetType(Boolean))          ' Признак применения спец. экономических мер к иностранному участнику (0 - не применяются, 1 - применяются)
            .Add("sum", GetType(String))                    ' Выводы экспертизы
            .Add("sumId", GetType(Integer))                 ' ID идентификатора выводов экспертизы
            .Add("sumGuid", GetType(String))                ' Guid идентификатора выводов экспертизы
            .Add("pvnId", GetType(Integer))                 ' Идентификатор наличия признаков продукции военного назначения (0 - не выявлены, 1 - имеются, 2 - проведения анализа не требуется)
            .Add("dopInfo", GetType(String))                ' Дополнительная информация
        End With
        Me.Columns("guid").AllowDBNull = False
        Me.Columns("workId").AllowDBNull = False
        Me.Columns("num").AllowDBNull = False
        Me.Columns("docNum").AllowDBNull = False
        Me.Columns("docDate").AllowDBNull = False
        Me.Columns("clientName").AllowDBNull = False
        Me.Columns("clientInn").AllowDBNull = False
        Me.Columns("clientAddress").AllowDBNull = False
        Me.Columns("countryExistId").AllowDBNull = False
        Me.Columns("isCountryEmbargo").AllowDBNull = False
        Me.Columns("isNusEmbargo").AllowDBNull = False
        Me.Columns("sum").AllowDBNull = False
        Me.Columns("sumId").AllowDBNull = False
        Me.Columns("sumGuid").AllowDBNull = False
        Me.Columns("countryExistId").DefaultValue = 0
        Me.Columns("isCountryEmbargo").DefaultValue = False
        Me.Columns("isNusEmbargo").DefaultValue = False
        Me.Columns("clientName").MaxLength = 255
        Me.Columns("clientAddress").MaxLength = 255
        Me.Columns("conName").MaxLength = 255
        Me.Columns("conNum").MaxLength = 255
        Me.Columns("rusName").MaxLength = 255
        Me.Columns("rusAddress").MaxLength = 255
        Me.Columns("nusName").MaxLength = 255
        Me.Columns("nusAddress").MaxLength = 255
        Me.Columns("dopInfo").MaxLength = 500
        Me.PrimaryKey = New DataColumn() {Me.Columns("guid")}
    End Sub

End Class
