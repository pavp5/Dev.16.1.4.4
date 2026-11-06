''' <summary>
''' Идентификаторы разделов работы
''' </summary>
Friend Enum ContentEnum As Integer
    ''' <summary>Содержание работы</summary>
    Content = 10
    ''' <summary>План работы</summary>
    Plane = 20
    ''' <summary>Сведения о лицензии</summary>
    License = 30
    ''' <summary>Список продукции (объектов экспертизы)</summary>
    GoodList = 100
    ''' <summary>Регистрационные данные объекта экспертизы</summary>
    GoodData = 101
    ''' <summary>Проверка соответствия объекта экспертизы приложению к лицензии</summary>
    GoodLaw = 104
    ''' <summary>Дополнительная информация</summary>
    ExtraInfo = 120
    ''' <summary>Перечень документов</summary>
    ExtraDoc = 130
    ''' <summary>Проект заключения</summary>
    Project = 140
    ''' <summary>Запросы</summary>
    Request = 150
End Enum