''' <summary>
''' Идентификаторы разделов работы
''' </summary>
Friend Enum ContentEnum As Integer
    ''' <summary>Содержание работы</summary>
    Content = 10
    ''' <summary>План работы</summary>
    Plane = 20
    ''' <summary>Список объектов</summary>
    QueryList = 100
    ''' <summary>Регистрационные данные объекта</summary>
    QueryData = 101
    ''' <summary>Дополнительная информация</summary>
    ExtraInfo = 120
    ''' <summary>Перечень документов</summary>
    ExtraDoc = 130
    ''' <summary>Проект заключения</summary>
    Project = 140
    ''' <summary>Запросы</summary>
    Request = 150
End Enum