Imports C2 = Cprp.DxData.Common
''' <summary>
''' Состояния работы
''' </summary>
Public Enum WorkCondition
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Новая</summary>
    IsNew = 1
    ''' <summary>В работе</summary>
    IsWork = 2
    ''' <summary>Запрос</summary>
    IsQuery = 3
    ''' <summary>Проверка</summary>
    IsCheck = 4
    ''' <summary>Утверждение</summary>
    IsAgree = 5
    ''' <summary>Утверждена</summary>
    IsAccept = 6
    ''' <summary>Закрыта</summary>
    IsClose = 7
    ''' <summary>Аннулирована</summary>
    IsCancel = 8
    ''' <summary>Проект</summary>
    IsProject = 9
    ''' <summary>Подписание экспертом</summary>
    IsSignature = 10
    ''' <summary>Подготовка плана</summary>
    IsPlaneWork = 11
    ''' <summary>Утверждение плана</summary>
    IsPlaneAgree = 12
    ''' <summary>Запрос (планирование)</summary>
    IsPlaneQuery = 13
    ''' <summary>Запрос (новая)</summary>
    IsNewQuery = 14
    ''' <summary>Запрос (заявка)</summary>
    IsOrderQuery = 15
    ''' <summary>Отклонена (заявка)</summary>
    IsReturned = 16
End Enum

''' <summary>
''' События работы
''' </summary>
Public Enum WorkEvent
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Создание работы</summary>
    WorkCreate = 1
    ''' <summary>Открытие карточки работы</summary>
    OpenCard = 2
    ''' <summary>Сохранение данных</summary>
    DataSave = 3
    ''' <summary>Создание проектов итоговых документов</summary>
    ProjectCreate = 4
    ''' <summary>Отправка работы на проверку (утверждение)</summary>
    WorkSend = 5
    ''' <summary>Работа проверена</summary>
    WorkCheck = 6
    ''' <summary>Работа утверждена</summary>
    WorkAccept = 7
    ''' <summary>Возврат на доработку после проверки</summary>
    BackCheck = 8
    ''' <summary>Возврат на доработку после утверждения</summary>
    BackAccept = 9
    ''' <summary>Отправлен (утвержден) запрос</summary>
    QuerySend = 10
    ''' <summary>Возврат в работу после ответа на запрос</summary>
    BackQuery = 11
    ''' <summary>Разблокированы проекты итоговых документов</summary>
    ProjectUnlock = 12
    ''' <summary>Делегирование работы руководителю</summary>
    ChangeLeader = 13
    ''' <summary>Назначение исполнителя в работе</summary>
    ChangeExpert = 14
    ''' <summary>Аннулирование работы</summary>
    WorkCancel = 15
    ''' <summary>Закрытие работы</summary>
    WorkClose = 16
    ''' <summary>Подписание работы исполнителем</summary>
    ExpertSignature = 17
    ''' <summary>Копирование данных из другой работы</summary>
    DataCopy = 18
    ''' <summary>Поиск товаров в базе</summary>
    GoodFind = 19
    ''' <summary>Превышен срок распределения работы</summary>
    TermOver = 20
    ''' <summary>Отправка плана на утверждение</summary>
    PlaneSend = 22
    ''' <summary>План утвержден</summary>
    PlaneAccept = 23
    ''' <summary>План возвращен на доработку</summary>
    PlaneBack = 24
    ''' <summary>Изменение срока выполнения работы экспертом</summary>
    ChangeExpertTerm = 25
    ''' <summary>Изменение состояния работы</summary>
    ChangeCondition = 26
    ''' <summary>Назначение менеджера в работе</summary>
    ChangeManager = 27
    ''' <summary>Отправка запроса на утверждение</summary>
    QueryAgree = 28
    ''' <summary>Возврат запроса на доработку</summary>
    QueryBack = 29
    ''' <summary>Изменение вида услуги</summary>
    ChangeType = 31
    ''' <summary>Приостановка выполнения</summary>
    WorkStop = 32
    ''' <summary>Запуск в работу</summary>
    WorkStart = 34
    ''' <summary>Отправка внутреннего документа на утверждение</summary>
    InternalAgree = 35
    ''' <summary>Возврат внутреннего документа на доработку</summary>
    InternalBack = 36
    ''' <summary>Утверждение внутреннего документа</summary>
    InternalAccept = 37
    ''' <summary>Редактирование проекта итогового документа</summary>
    ProjectEdit = 38
    ''' <summary>Отправка в ФСТЭК</summary>
    FstekReport = 39

    ''' <summary>Предупреждение системы</summary>
    SystemWarning = 99
End Enum

''' <summary>
''' Виды работ
''' </summary>
Public Enum WorkType
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Идентификационная экспертиза по экспортному контролю</summary>
    IsExCont = 1
    ''' <summary>Военно-техническое сотрудничество</summary>
    IsMilitary = 2
    ''' <summary>Экспертиза по запретам и ограничениям ЕАЭС</summary>
    IsCustomUnion = 3
    ''' <summary>Подтверждение лицензии</summary>
    IsLiconfirm = 4
    ''' <summary>Определение кода ТН ВЭД</summary>
    IsTnved = 5
    ''' <summary>Консультация</summary>
    IsConsultation = 6
    ''' <summary>Расмотрение заявки на оказание услуг</summary>
    IsOrder = 99
    ''' <summary>Расмотрение заявки на внесение изменений</summary>
    IsAlteration = 117
    ''' <summary>Оформление лицензии ФСТЭК / разрешения КЭК</summary>
    IsLicense = 7

End Enum

''' <summary>
''' Типы работ
''' </summary>
Public Enum WorkSort
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Идентификационная экспертиза / консультация</summary>
    IsWork = 1
    ''' <summary>Внесение изменений в ранее выполненную работу</summary>
    IsChange = 2
    ''' <summary>Дополнителная (техническая) работа к другой работе</summary>
    IsAdditional = 3
    ''' <summary>Экспертиза для таможенных / следственных органов</summary>
    IsControl = 4
End Enum

''' <summary>
''' Характеристики экспертизы
''' </summary>
Public Enum WorkKind
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Первичная</summary>
    IsPrimary = 1
    ''' <summary>Повторная</summary>
    IsRepeat = 2
    ''' <summary>Дополнителная</summary>
    IsAdditional = 3
End Enum

''' <summary>
''' Выводы идентификационной экспертизы
''' </summary>
Public Enum WorkSummary
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Не требуется оформление разрешительных документов</summary>
    IsFreedom = 1
    ''' <summary>Необходимо получение лицензии ФСТЭК России</summary>
    IsLicense = 2
    ''' <summary>Необходимо получение разрешения КЭК</summary>
    IsPermit = 3
    ''' <summary>Распространяется действие специальных экономических мер</summary>
    IsEmbargo = 4
    ''' <summary>Объекты экспертизы соответствуют контрольным спискам, но получение лицензии не требуется</summary>
    IsOutput = 5
    ''' <summary>Необходимо обратиться в ФСТЭК</summary>
    IsDecree = 6
End Enum

''' <summary>
''' Характеры внешнеэкономической операции
''' </summary>
Public Enum SupplyType
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Экспорт товаров из Российской Федерации</summary>
    IsExport = 1
    ''' <summary>Импорт товаров в Российскую Федерацию</summary>
    IsImport = 2
    ''' <summary>Временный вывоз товаров из Российской Федерации</summary>
    IsExportTemp = 3
    ''' <summary>Ввоз товаров в Российскую Федерацию, ранее поставлявшихся в режиме временного вывоза</summary>
    IsImportAfterExportTemp = 4
    ''' <summary>Временный ввоз товаров в Российскую Федерацию</summary>
    IsImportTemp = 5
    ''' <summary>Вывоз товаров из Российской Федерации, ранее поставлявшихся в режиме временного ввоза</summary>
    IsExportAfterImportTemp = 6
    ''' <summary>Вывоз товаров из Российской Федерации с целью ремонта или замены на аналогичные</summary>
    IsExportRepair = 7
    ''' <summary>Ввоз товаров в Российскую Федерацию с целью ремонта или замены на аналогичные</summary>
    IsImportRepair = 8
    ''' <summary>Вывоз товаров из Российской Федерации на борт российского морского или воздушного судна</summary>
    IsExportShip = 9
    ''' <summary>Транзит в Калининградскую область</summary>
    IsTransit = 10
    ''' <summary>Вывоз товара из Российской Федерации</summary>
    IsExportNew = 13
    ''' <summary>Ввоз товара из Российской Федерации</summary>
    IsImportNew = 14
    ''' <summary>Передача иностранному лицу на территории Российской Федерации</summary>
    IsDelivery = 15
    ''' <summary>Внешнеэкономическая операция отсутствует</summary>
    IsAbsent = 16

End Enum

''' <summary>
''' Причины внесения изменений
''' </summary>
Public Enum ChangeSource

    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID

    ''' <summary>Дополнительная экспертиза</summary>
    IsClient = 1

    ''' <summary>Ошибка эксперта</summary>
    IsExpert = 2

    ''' <summary>Продление срока действия заключения</summary>
    IsLess = 3

    ''' <summary>Бесплатная техническая работа</summary>
    IsFreeWork = 4

End Enum

''' <summary>
''' Решения по внесению изменений
''' </summary>
Public Enum ChangeSummary

    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID

    ''' <summary>Разблокировать старую работу</summary>
    IsUnlock = 1

    ''' <summary>Создать новую работу по цене внесения изменений</summary>
    IsNew = 2

    ''' <summary>Подготовить письмо</summary>
    IsLetter = 3

    ''' <summary>Дать устные пояснения</summary>
    IsTalk = 4

    ''' <summary>Создать новую работу по цене новой работы</summary>
    IsNewWork = 5

End Enum

''' <summary>
''' Признаки срочности
''' </summary>
Public Enum UrgencyType
    ' ''' <summary>Пустое значение</summary>
    'IsEmpty = C2.EMPTY_ID
    ''' <summary>Без срочности (16 рабочих часов)</summary>
    IsNone = 1
    ''' <summary>Повышенная (8 рабочих часов)</summary>
    IsElevated = 2
    ''' <summary>Срочная (4 рабочих часа)</summary>
    IsHigh = 3
End Enum