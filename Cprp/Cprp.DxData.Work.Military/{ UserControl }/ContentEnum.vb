''' <summary>
''' Идентификаторы разделов работы
''' </summary>
Friend Enum ContentEnum As Integer
    ''' <summary>Содержание работы</summary>
    Content = 10
    ''' <summary>План работы</summary>
    Plane = 20
    ''' <summary>Российский участник внешнеэкономической операции (регистрационные данные)</summary>
    SupplyRusData = 41
    ''' <summary>Список продукции (объектов экспертизы)</summary>
    GoodList = 100
    ''' <summary>Регистрационные данные объекта экспертизы</summary>
    GoodData = 101
    ''' <summary>Классификатор ПВН объекта экспертизы</summary>
    GoodLaw = 104
    ''' <summary>Сравнительный анализ объекта экспертизы</summary>
    GoodSummary = 105
    ''' <summary>Решение по анализу</summary>
    Summary = 110
    ''' <summary>Перечень документов</summary>
    ExtraDoc = 130
    ''' <summary>Проект заключения</summary>
    Project = 140
    ''' <summary>Запросы</summary>
    Request = 150
End Enum