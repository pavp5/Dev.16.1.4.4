''' <summary>
''' Таблица результатов расчета стоимостей услуг
''' </summary>
Public Class CalcDataTable : Inherits DataTable


    Public Sub New()
        MyBase.New("CalcTable")
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID
            ' исходные данные
            .Add("serviceId", GetType(ServiceType))     ' ID вида услуги
            .Add("materialCount", GetType(Integer))     ' Количество материальных объектов исследования
            .Add("informationCount", GetType(Integer))  ' Количество информационных объектов исследования
            .Add("orderNum", GetType(String))           ' Номер заказа
            .Add("goodCount", GetType(Integer))         ' Количество товаров / вопросов при консультировании
            .Add("addCountryCount", GetType(Integer))   ' Количество дополнительных контрактов / стран назначения
            .Add("languageCount", GetType(Integer))     ' Количество документов на иностранном языке
            .Add("hourCount", GetType(Integer))         ' Количество часов на выполнение работы
            .Add("oldPrice", GetType(Single))           ' Стоимость ранее выпущенного заключения
            .Add("isPrice50", GetType(Boolean))         ' Признак 50 % скидки по второй услуге по заказу
            .Add("isUrgency", GetType(Boolean))         ' Срочное выполнение услуги
            .Add("complexity", GetType(Single))         ' Коэффициент за срочность (1,0-2,0)
            ' результаты расчета
            .Add("price", GetType(Single))              ' Полная стоимость услуги
            .Add("sprice", GetType(Single))             ' Надбавка за срочность
            .Add("description", GetType(String))        ' Информация по расчету
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.Columns("serviceId").AllowDBNull = False
        With Me.Columns("materialCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("informationCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("goodCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("addCountryCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("languageCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("hourCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("oldPrice")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("isPrice50")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isUrgency")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("complexity")
            .AllowDBNull = False
            .DefaultValue = 1
        End With
        'With Me.Columns("sprice")
        '    .AllowDBNull = False
        '    .DefaultValue = 0
        'End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


End Class