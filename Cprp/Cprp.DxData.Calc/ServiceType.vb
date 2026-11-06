Imports Cprp.DxData.Common
''' <summary>
''' Виды услуг
''' </summary>
Public Enum ServiceType

    ''' <summary>Идентификатор пустого значения</summary>
    IsEmpty = EMPTY_ID
    ''
    ' ''' <summary>Бесплатная (техническая) работа</summary>
    'FreeWork = 1
    '
    ' Экспертиза
    '
    ''' <summary>Идентификационная экспертиза по экспортному контролю</summary>
    ExpertExcont = 101
    ''' <summary>Экспертиза по запретам и ограничениям ЕАЭС</summary>
    ExpertCustoms = 102
    ''' <summary>Экспертиза продукции гражданского назначения</summary>
    ExpertMilitary = 103
    ''' <summary>Подтверждение лицензии ФСТЭК</summary>
    ExpertLicConfirm = 104
    '
    ' Консультация
    '
    ''' <summary>Определение кода ТН ВЭД</summary>
    ConsTnved = 201
    ''' <summary>Консультация по ВЭД</summary>
    ConsVed = 202
    '
    ' Оформление разрешительных документов ФСТЭК России
    '
    ''' <summary>Подготовка пакета документов, отправка, получение и передача результата</summary>
    FstekLicense = 301
    ''' <summary>Подготовка пакета документов</summary>
    FstekPrepare = 302
    ''' <summary>Отправка пакета документов, получение и передача результата</summary>
    FstekSend = 303
    ''' <summary>Продление срока действия лицензии</summary>
    FstekLess = 304
    ''' <summary>Переоформление лицензий</summary>
    FstekRereg = 305
    ''' <summary>Подготовка и отправка отчета об исполнении лицензии</summary>
    FstekReport = 306
    '
    ' Электронное таможенное декларирование
    '
    ''' <summary>Создание и сопровождение ДТ на экспорт</summary>
    DeclareExport = 401
    ''' <summary>Создание и сопровождение ДТ на импорт</summary>
    DeclareImport = 402
    ''' <summary>Создание статистической формы ФТС РФ</summary>
    DeclareForm = 403
    ''' <summary>Создание транзитной таможенной декларации</summary>
    DeclareTransit = 404
    '
    ' Нотификация
    '
    ''' <summary>Оформление нотификации в ЦЛСЗ ФСБ России</summary>
    Notification = 501
    '
    ' Получение сертификата о происхождения товара
    '
    ''' <summary>Помощь в подготовке и формировании необходимого комплекта документов</summary>
    OriginalHelp = 601
    '
    ' Дополнительные услуги
    '
    ''' <summary>Исправление ошибки в ранее выпущенном заключении</summary>
    ExtraDocCorrection = 1000
    ''' <summary>Перевыпуск ранее выпущенного заключения по инициативе заказчика</summary>
    ExtraDocReissue = 1001
    ''' <summary>Проведение дополнительной экспертизы по раее выпущенному заключению</summary>
    ExtraDocAdditional = 1002
    ''' <summary>Продление срока действия ранее выпущенного заключения</summary>
    ExtraDocLess = 1003
    ''' <summary>Оформление копии электронного заключения на бумажном носителе</summary>
    ExtraDocPaper = 1004
    ''' <summary>Отправка финансовых документов по запросу Заказчика Почтой России</summary>
    ExtraPostal = 1005
    ''' <summary>Обработка документов по заявке</summary>
    ExtraManual = 1006
    ''' <summary>Оформление отдельных заключений на отдельные контракты / отдельные страны назначения</summary>
    ExtraFewDoc = 1007
    ''' <summary>Работа с документами на иностранном языке</summary>
    ExtraLanguage = 1008

End Enum

