Imports Cprp.DxData.Common
''' <summary>
''' Дополнительные данные работы
''' </summary>
Public Class AdditionalDataRow : Inherits Cprp.DxData.Base.BaseDataRow

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("ARow")
        With Me.Columns
            .Add("id", GetType(Integer))                    ' ID
            .Add("typeId", GetType(WorkType))               ' ID вида работы
            .Add("goodCount", GetType(Integer))             ' Планирование - Количество товаров по спецификации
            .Add("matCount", GetType(Integer))              ' Планирование - Количество материальных объектов исследования
            .Add("infCount", GetType(Integer))              ' Планирование - Количество информационных объектов исследования
            .Add("addWorkCount", GetType(Integer))          ' Планирование - Количество дополнительных работ (несколько стран, ввоз/вывоз)
            .Add("totalWork", GetType(Integer))             ' Планирование - Общая трудоемкость (мин)
            .Add("expertTerm", GetType(Date))               ' Планирование - Срок исполнения работы экспертом
            .Add("isUrgency", GetType(Boolean))             ' Планирование - Срочная работа
            .Add("urgencyId", GetType(UrgencyType))         ' Планирование - Признак срочности
            .Add("complexity", GetType(Single))             ' Планирование - Коэффициент сложности
            .Add("isSendQuery", GetType(Boolean))           ' Планирование - Необходимо отправить факс-запрос
            .Add("isMakeProfile", GetType(Boolean))         ' Планирование - Необходимо заполнить профили иностранных участников сделки/операции
            .Add("findCount", GetType(Integer))             ' Планорование - Время на поиск дополнительной информации (мин)
            .Add("langCount", GetType(Integer))             ' Планирование - Время на работу с текстом на иностранном языке (мин)
            .Add("changeSourceId", GetType(Integer))        ' Планирование - Причина внесения изменений (1 - заказчик / 2 - эксперт / 3 - продление срока действия заключения / 4 - Бесплатная (техническая) работа)
            .Add("changeDescription", GetType(String))      ' Планирование - Описание изменений
            .Add("planeComment", GetType(String))           ' Планирование - Комментарий эксперта к плану работы
            .Add("isDocRule", GetType(Boolean))             ' Легитимность представленных документов подтверждаю
            .Add("saveDate", GetType(Date))                 ' Дата последнего сохранения данных работы
            .Add("changeDate", GetType(Date))               ' Дата последнего изменения данных работы
            .Add("projectDate", GetType(Date))              ' Дата последнего создания проектов итоговых документов
            .Add("planeData", GetType(String))              ' Документ плана работы (html)
            .Add("isExpertSign", GetType(Boolean))          ' Заключения экспертизы подписываются экспертом
            .Add("contentData", GetType(String))            ' Содержание работы (html)
            .Add("priceG", GetType(Single))                 ' Стоимость работы при расчете по товарам
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("goodCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("matCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("infCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("addWorkCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("isUrgency")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("urgencyId")
            .AllowDBNull = False
            .DefaultValue = UrgencyType.IsNone
        End With
        With Me.Columns("complexity")
            .AllowDBNull = False
            .DefaultValue = 1
        End With
        With Me.Columns("isSendQuery")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isMakeProfile")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("findCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("langCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("changeSourceId")
            .AllowDBNull = False
            .DefaultValue = EMPTY_ID
        End With
        With Me.Columns("isDocRule")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isExpertSign")
            .AllowDBNull = False
            .DefaultValue = True
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
