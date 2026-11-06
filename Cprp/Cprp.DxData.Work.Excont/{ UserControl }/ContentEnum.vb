''' <summary>
''' Идентификаторы разделов работы
''' </summary>
Friend Enum ContentEnum As Integer
    ''' <summary>Содержание работы</summary>
    Content = 10
    ''' <summary>План работы</summary>
    Plane = 20
    ''' <summary>Регистрационные данные сделки</summary>
    ContractData = 31
    ''' <summary>Риски по сделке</summary>
    ContractRisk = 35
    ''' <summary>Список российских участников сделки</summary>
    ContractRusList = 40
    ''' <summary>Регистрационные данные российского участника сделки</summary>
    ContractRusData = 41
    ''' <summary>Профиль российского участника сделки</summary>
    ContractRusProfile = 42
    ''' <summary>Риски российского участника сделки</summary>
    ContractRusRisk = 45
    ''' <summary>Список иностранных участников сделки</summary>
    ContractNusList = 50
    ''' <summary>Регистрационные данные иностранного участника сделки</summary>
    ContractNusData = 51
    ''' <summary>Запреты и ограничения иностранного участника сделки</summary>
    ContractNusEmbargo = 52
    ''' <summary>Фирмы на контроле иностранного участника сделки</summary>
    ContractNusControl = 53
    ''' <summary>Профиль иностранного участника сделки</summary>
    ContractNusProfile = 54
    ''' <summary>Риски иностранного участника сделки</summary>
    ContractNusRisk = 55
    ''' <summary>Регистрационные данные операции</summary>
    SupplyData = 61
    ''' <summary>Риски по операции</summary>
    SupplyRisk = 65
    ''' <summary>Список российских участников операции</summary>
    SupplyRusList = 70
    ''' <summary>Регистрационные данные российского участника операции</summary>
    SupplyRusData = 71
    ''' <summary>Профиль российского участника операции</summary>
    SupplyRusProfile = 72
    ''' <summary>Риски российского участника операции</summary>
    SupplyRusRisk = 75
    ''' <summary>Список иностранных покупателей (продавцов)</summary>
    SupplyNusList = 80
    ''' <summary>Регистрационные данные иностранного покупателя (продавца)</summary>
    SupplyNusData = 81
    ''' <summary>Запреты и ограничения иностранного покупателя (продавца)</summary>
    SupplyNusEmbargo = 82
    ''' <summary>Фирмы на контроле иностранного покупателя (продавца)</summary>
    SupplyNusControl = 83
    ''' <summary>Профиль иностранного покупателя (продавца)</summary>
    SupplyNusProfile = 84
    ''' <summary>Риски иностранного покупателя (продавца)</summary>
    SupplyNusRisk = 85
    ''' <summary>Список потребителей (конечных пользователей)</summary>
    SupplyEndList = 90
    ''' <summary>Регистрационные данные потребителя (конечного пользователя)</summary>
    SupplyEndData = 91
    ''' <summary>Запреты и ограничения потребителя (конечного пользователя)</summary>
    SupplyEndEmbargo = 92
    ''' <summary>Фирмы на контроле потребителя (конечного пользователя)</summary>
    SupplyEndControl = 93
    ''' <summary>Профиль потребителя (конечного пользователя)</summary>
    SupplyEndProfile = 94
    ''' <summary>Риски потребителя (конечного пользователя)</summary>
    SupplyEndRisk = 95
    ''' <summary>Список продукции (объектов экспертизы)</summary>
    GoodList = 100
    ''' <summary>Регистрационные данные объекта экспертизы</summary>
    GoodData = 101
    ''' <summary>Запреты и ограничения объекта экспертизы</summary>
    GoodEmbargo = 102
    ''' <summary>Объекты на контроле объекта экспертизы</summary>
    GoodControl = 103
    ''' <summary>Исследование по контрольным спискам объекта экспертизы</summary>
    GoodLaw = 104
    ''' <summary>Сравнительный анализ объекта экспертизы</summary>
    GoodSummary = 105
    ''' <summary>Риски объекта экспертизы</summary>
    GoodRisk = 106
    ''' <summary>Решение по анализу</summary>
    Summary = 110
    ''' <summary>Дополнительная информация</summary>
    ExtraInfo = 120
    ''' <summary>Перечень документов</summary>
    ExtraDoc = 130
    ''' <summary>Проект заключения</summary>
    Project = 140
    ''' <summary>Запросы</summary>
    Request = 150
    ''' <summary>Внутренние документы</summary>
    Internal = 160


End Enum