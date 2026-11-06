Imports Cprp.DxData.Common
''' <summary>
''' Калькулятор стоимостей услуг
''' </summary>
Public Class Calc


    ''' <summary>
    ''' Таблица результатов расчета стоимостей услуг
    ''' </summary>
    Public CalcTable As CalcDataTable = Nothing

    ''' <summary>
    ''' Справочник видов услуг
    ''' </summary>
    Public ServiceTable As ServiceDataTable = Nothing

    ''' <summary>
    ''' Открытое подключение к базе данных
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Базовый коэффициент срочности
    ''' </summary>
    Private Const URGENCY_KOEF As Single = 1.5

    ''' <summary>
    ''' Базовая стоимость дополнительного листа ДТ
    ''' </summary>
    Private Const DECLARE_DOP_LIST As Single = 1500


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="CalcTable">Таблица результатов расчета</param>
    Public Sub New(Connection As SqlConnection, CalcTable As CalcDataTable)
        Me.Connection = Connection
        Me.CalcTable = CalcTable
        ServiceTable = New ServiceDataTable
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = "SELECT id, parentId, name, serviceId, price, isPrice50 FROM tServiceType WHERE isACT = 1"
            ServiceTable.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        MyClass.New(Connection, New CalcDataTable)
    End Sub


    '    ''' <summary>
    '    ''' Выполняет расчет стоимости работы и возвращает таблицу результатов расчета
    '    ''' </summary>
    '    ''' <param name="services">Массив видов услуг</param>
    '    ''' <param name="materialCount">Количество материальных объектов исследования</param>
    '    ''' <param name="informationCount">Количество информационных объектов исследования</param>
    '    ''' <param name="orderNum">Номер заказа или номер договора</param>
    '    ''' <param name="goodCount">Количество товаров</param>
    '    ''' <param name="addCountryCount">Количество дополнительных контрактов / стран назначения</param>
    '    ''' <param name="languageCount">Количество документов на иностранном языке</param>
    '    ''' <param name="hourCount">Количество часов на выполнение работы</param>
    '    ''' <param name="oldPrice">Стоимость первичного заключения</param>
    '    ''' <param name="isUrgency">Признак срочности</param>
    '    Public Sub SetCalc(services() As ServiceType, materialCount As Integer, informationCount As Integer, _
    '                       Optional orderNum As String = Nothing, _
    '                       Optional goodCount As Integer = 0, _
    '                       Optional addCountryCount As Integer = 0, _
    '                       Optional languageCount As Integer = 0, _
    '                       Optional hourCount As Integer = 0, _
    '                       Optional oldPrice As Single = 0, _
    '                       Optional isUrgency As Boolean = False)

    '        Dim description As String = Nothing ' информация по услуге
    '        Dim price As Single = 0             ' расчетная стоимость текущей услуги
    '        Dim SRow As DataRow = Nothing       ' строка справочника видов услуг
    '        Dim CalcRow As DataRow = Nothing    ' строка таблицы результатов расчета
    '        Dim isPrice50 As Boolean = False    ' признак скидки 50 % за услугу по идентификации, запретам ЕАЭС, гражданскому назначению
    '        Dim iTmp As Integer = 0
    '        '
    '        ' Исходные данные
    '        '
    '        If materialCount < 0 Then materialCount = 0
    '        If informationCount < 0 Then informationCount = 0
    '        iTmp = materialCount + informationCount
    '        If goodCount < iTmp Then goodCount = iTmp
    '        If addCountryCount < 0 Then addCountryCount = 0
    '        If languageCount < 0 Then languageCount = 0
    '        If hourCount < 0 Then hourCount = 0
    '        If oldPrice < 0 Then oldPrice = 0
    '        '
    '        ' Цикл по видам услуг, заполнение таблицы результатов расчетов
    '        '
    '        CalcTable.Rows.Clear()
    '        For Each service As ServiceType In services
    '            '
    '            ' SRow
    '            '
    '            SRow = ServiceTable.FindRowByServiceId(CInt(service))
    '            If SRow Is Nothing Then Continue For
    '            '
    '            ' CalcRow
    '            '
    '            CalcRow = CalcTable.NewRow
    '            CalcRow("serviceId") = service
    '            CalcRow("materialCount") = materialCount
    '            CalcRow("informationCount") = informationCount
    '            CalcRow("orderNum") = DbText(orderNum)
    '            CalcRow("goodCount") = goodCount
    '            CalcRow("addCountryCount") = addCountryCount
    '            CalcRow("languageCount") = languageCount
    '            CalcRow("hourCount") = hourCount
    '            CalcRow("oldPrice") = oldPrice
    '            CalcRow("isUrgency") = isUrgency
    '            CalcRow("price") = DBNull.Value
    '            CalcRow("description") = DbText(ServiceTable.FullName(CInt(service)))
    '            '
    '            ' Расчет стоимости услуги по допсоглашению
    '            '
    '            If Not IsDBNull(CalcRow("orderNum")) Then
    '                SetPriceAgrement(CalcRow)
    '                If Not IsDBNull(CalcRow("price")) Then GoTo AddNewRow
    '            End If
    '            '
    '            ' Расчет стоимости услуги по тарифному плану
    '            '
    '            Select Case service
    '                Case ServiceType.ExpertExcont, ServiceType.ExpertMilitary, ServiceType.ExpertCustoms
    '                    '
    '                    ' Идентификационная экспертиза по экспортному контролю
    '                    ' Гражданское назначение
    '                    ' Экспертиза по запретам и ограничениям ЕАЭС
    '                    '
    '                    price = CSng(SRow("price"))
    '                    iTmp = materialCount + informationCount
    '                    For i As Integer = 2 To iTmp
    '                        price += If(i > 10, 850, 900)
    '                    Next
    '                    If isPrice50 Then
    '                        CalcRow("isPrice50") = True
    '                        price /= 2
    '                    End If
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (объектов: {1} срочность: {2}, скидка за 2-ю работу по заказу: {3})", _
    '                            description, iTmp, If(isUrgency, "Да", "Нет"), If(CBool(CalcRow("isPrice50")), "Да", "Нет"))
    '                    isPrice50 = True    ' признак наличия скидки 50 % за следующие услуги
    '                    Exit Select
    '                Case ServiceType.ExpertLicConfirm
    '                    '
    '                    ' Подтверждение лицензии
    '                    '
    '                    price = CSng(SRow("price"))
    '                    iTmp = materialCount + informationCount
    '                    For i As Integer = 2 To iTmp
    '                        price += If(i > 10, 850, 900)
    '                    Next
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (объектов: {1} срочность: {2})", _
    '                            description, iTmp, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case ServiceType.ConsTnved
    '                    '
    '                    ' Определение кода ТН ВЭД
    '                    '
    '                    price = CSng(SRow("price"))
    '                    iTmp = materialCount + informationCount
    '                    For i As Integer = 2 To iTmp
    '                        price += If(i > 10, 400, 450)
    '                    Next
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (объектов: {1} срочность: {2})", _
    '                            description, iTmp, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case ServiceType.ConsVed
    '                    '
    '                    ' Консультация по ВЭД
    '                    '
    '                    iTmp = materialCount + informationCount
    '                    If goodCount > iTmp Then iTmp = goodCount
    '                    price = CSng(SRow("price")) + 1500 * (iTmp - 1)
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (вопросов: {1} срочность: {2})", _
    '                            description, iTmp, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
    '                    '
    '                    ' Перевыпуск ранее выпущенного заключения по инициативе заказчика
    '                    ' Проведение дополнительной экспертизы по раее выпущенному заключению
    '                    '
    '                    price = oldPrice / 2
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (стоимость певичного заключения: {1}, срочность: {2})", _
    '                            description, oldPrice, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case ServiceType.ExtraDocLess
    '                    '
    '                    ' Продление срока действия ранее выданного заключения
    '                    '
    '                    price = oldPrice / 2
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (стоимость певичного заключения: {1}, срочность: {2})", _
    '                            description, oldPrice, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case ServiceType.ExtraFewDoc
    '                    '
    '                    ' Оформление отдельных заключений на отдельные контракты / отдельные страны назначения
    '                    '
    '                    price = CSng(SRow("price")) * addCountryCount
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (заключений: {1} срочность: {2})", _
    '                            description, addCountryCount, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case ServiceType.ExtraLanguage
    '                    '
    '                    ' Работа с документами на иностранном языке
    '                    '
    '                    price = CSng(SRow("price")) * languageCount
    '                    If isUrgency Then price *= URGENCY_KOEF
    '                    CalcRow("price") = price
    '                    CalcRow("description") = String.Format("{0} (документов: {1} срочность: {2})", _
    '                            description, languageCount, If(isUrgency, "Да", "Нет"))
    '                    Exit Select
    '                Case Else
    '                    '
    '                    ' Прочие услуги
    '                    '
    '                    price = CSng(SRow("price"))
    '                    CalcRow("price") = price
    '                    CalcRow("description") = description
    '                    Exit Select

    '            End Select
    'AddNewRow:
    '            '
    '            ' Добавление новой строки в таблицу расчетов
    '            '
    '            CalcTable.Rows.Add(CalcRow)
    '        Next
    '    End Sub


    ''' <summary>
    ''' Выполняет перерасчет стоимости услуг по исходным данным таблицы расчетов
    ''' </summary>
    Public Sub ReCalc()
        If CalcTable.Rows.Count = 0 Then Exit Sub
        '
        ' Переменные
        '
        Dim service As ServiceType = ServiceType.IsEmpty    ' вид услуги
        Dim materialCount As Integer = 0                    ' количество материальных объектов исследования
        Dim informationCount As Integer = 0                 ' количество информационных объектов исследования
        Dim goodCount As Integer = 0                        ' количество товаров
        Dim addCountryCount As Integer = 0                  ' количество дополнительных стран назначения
        Dim languageCount As Integer = 0                    ' количество документов на иностранном языке
        Dim hourCount As Integer = 0                        ' количество часов на выполнение работы
        Dim oldPrice As Single = 0                          ' стоимость первичного заключения
        Dim isPrice50 As Boolean = False                    ' признак скидки 50 % за 2-ю услугу по идентификации, запретам ЕАЭС, гражданскому назначению
        Dim isUrgency As Boolean = False                    ' признак срочности
        Dim complexity As Single = 1                        ' коэффициент за срочность
        Dim description As String = Nothing                 ' информация по услуге
        Dim price As Single = 0                             ' расчетная стоимость текущей услуги без срочности
        Dim sprice As Single = 0                            ' расчетная надбавка за срочность текущей услуги
        Dim SRow As DataRow = Nothing                       ' строка справочника видов услуг
        Dim CalcRow As DataRow = Nothing                    ' строка таблицы результатов расчета
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        '
        ' Признак скидки 50 % за 2-ю услугу
        '
        For Each CalcRow In CalcTable.Rows
            CalcRow("isPrice50") = False
        Next
        Using V As New DataView(CalcTable)
            V.RowFilter = String.Format("serviceId IN ({0}, {1}, {2})", CInt(ServiceType.ExpertExcont), CInt(ServiceType.ExpertCustoms), CInt(ServiceType.ExpertMilitary))
            V.Sort = "id"
            For i As Integer = 0 To V.Count - 1
                V(i)("isPrice50") = (i > 0)
            Next
        End Using

        If materialCount < 0 Then materialCount = 0
        If informationCount < 0 Then informationCount = 0
        iTmp = materialCount + informationCount
        If goodCount < iTmp Then goodCount = iTmp
        If addCountryCount < 0 Then addCountryCount = 0
        If languageCount < 0 Then languageCount = 0
        If hourCount < 0 Then hourCount = 0
        If oldPrice < 0 Then oldPrice = 0
        '
        ' Цикл по таблице расчетов
        '
        For Each CalcRow In CalcTable.Rows
            CalcRow("price") = DBNull.Value
            CalcRow("description") = ServiceTable.FullName(CInt(CalcRow("serviceId")))
            SRow = ServiceTable.FindRowByServiceId(CInt(CalcRow("serviceId")))
            If SRow Is Nothing Then Continue For
            '
            ' Расчет стоимости услуги по допсоглашению
            '
            SetPriceAgrement(CalcRow)
            If Not IsDBNull(CalcRow("price")) Then Continue For
            '
            ' Расчет стоимости услуги по тарифному плану
            '
            service = CType(CalcRow("serviceId"), ServiceType)
            materialCount = CInt(CalcRow("materialCount"))
            informationCount = CInt(CalcRow("informationCount"))
            goodCount = CInt(CalcRow("goodCount"))
            addCountryCount = CInt(CalcRow("addCountryCount"))
            languageCount = CInt(CalcRow("languageCount"))
            hourCount = CInt(CalcRow("hourCount"))
            oldPrice = CSng(CalcRow("oldPrice"))
            isPrice50 = CBool(CalcRow("isPrice50"))
            isUrgency = CBool(CalcRow("isUrgency"))
            complexity = CSng(CalcRow("complexity"))
            description = ToText(CalcRow("description"))
            iTmp = materialCount + informationCount
            If goodCount < iTmp Then goodCount = iTmp
            '
            ' Расчет стоимости услуги по тарифному плану
            '
            price = 0
            sprice = 0
            Select Case service
                Case ServiceType.ExpertExcont, ServiceType.ExpertMilitary, ServiceType.ExpertCustoms
                    '
                    ' Идентификационная экспертиза по экспортному контролю
                    ' Гражданское назначение
                    ' Экспертиза по запретам и ограничениям ЕАЭС
                    '
                    price = CSng(SRow("price"))
                    iTmp = materialCount + informationCount
                    For i As Integer = 1 To iTmp
                        price += If(i > 10, 850, 900)
                    Next
                    price = complexity * price
                    ' скидка 50 % за вторую работу в заказе для ООО "Армтел"
                    If isPrice50 Then
                        sTmp = "NOTNAME"
                        Using Cmd As SqlCommand = Connection.CreateCommand
                            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWork WHERE orderNum = '{0}'", ToText(CalcRow("orderNum")))
                            If CInt(Cmd.ExecuteScalar) > 0 Then
                                Cmd.CommandText = String.Format("SELECT clientName FROM tWork WHERE orderNum = '{0}'", ToText(CalcRow("orderNum")))
                                sTmp = ToText(Cmd.ExecuteScalar)
                            End If
                        End Using
                        If IsText(sTmp) AndAlso sTmp.ToUpper Like "*АРМТЕЛ*" Then
                            CalcRow("isPrice50") = True
                            price /= 2
                        End If
                    End If
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, объектов: {1}, коэффициент за сложность: {4:n1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, iTmp, price, sprice, complexity)
                    Else
                        CalcRow("description") = String.Format("{0}, объектов: {1}, коэффициент за сложность: {2:n1}, срочность: Нет", _
                                description, iTmp, complexity)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ExpertLicConfirm
                    '
                    ' Подтверждение лицензии
                    '
                    price = CSng(SRow("price"))
                    iTmp = materialCount + informationCount
                    For i As Integer = 1 To iTmp
                        price += If(i > 10, 850, 900)
                    Next
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, объектов: {1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, iTmp, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, объектов: {1}, срочность: Нет", _
                                description, iTmp)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ConsTnved
                    '
                    ' Определение кода ТН ВЭД
                    '
                    iTmp = materialCount + informationCount                    
                    If goodCount > iTmp Then iTmp = goodCount
                    price = iTmp * 1900
                    price = complexity * price
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, товаров: {1}, коэффициент за сложность: {4:n1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, iTmp, price, sprice, complexity)
                    Else
                        CalcRow("description") = String.Format("{0}, товаров: {1}, коэффициент за сложность: {2:n1}, срочность: Нет", _
                                description, iTmp, complexity)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ConsVed
                    '
                    ' Консультация по ВЭД
                    '
                    iTmp = materialCount + informationCount
                    If goodCount > iTmp Then iTmp = goodCount
                    price = CSng(SRow("price")) + 1500 * (iTmp - 1)
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, вопросов: {1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, iTmp, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, вопросов: {1}, срочность: Нет", _
                                description, iTmp)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.DeclareExport, ServiceType.DeclareImport
                    '
                    ' Декларация экспорт
                    ' Декларация импорт
                    '
                    iTmp = materialCount + informationCount
                    If goodCount > iTmp Then iTmp = goodCount
                    price = CSng(SRow("price"))
                    If iTmp > 1 Then price += DECLARE_DOP_LIST * (iTmp - 1)
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, листов ДТ: {1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, iTmp, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, листов ДТ: {1}, срочность: Нет", _
                                description, iTmp)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ExtraDocCorrection
                    '
                    ' Исправление ошибки в ранее выпущенном заключении
                    '
                    CalcRow("price") = 0
                    CalcRow("description") = description
                    Exit Select
                Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                    '
                    ' Перевыпуск ранее выпущенного заключения по инициативе заказчика
                    ' Проведение дополнительной экспертизы по раее выпущенному заключению
                    '
                    price = oldPrice / 2
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, стоимость первичного заключения: {1:c2}, срочность: Да ({2:c2} + {3:c2})", _
                                description, oldPrice, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, стоимость первичного заключения: {1:c2}, срочность: Нет", _
                                description, oldPrice)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ExtraDocLess
                    '
                    ' Продление срока действия ранее выданного заключения
                    '
                    price = oldPrice / 2
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, стоимость первичного заключения: {1:c2}, срочность: Да ({2:c2} + {3:c2})", _
                                description, oldPrice, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, стоимость первичного заключения: {1:c2}, срочность: Нет", _
                                description, oldPrice)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ExtraFewDoc
                    '
                    ' Оформление отдельных заключений на отдельные контракты / отдельные страны назначения
                    '
                    price = CSng(SRow("price")) * addCountryCount
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, доп. заключений: {1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, addCountryCount, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, доп. заключений: {1}, срочность: Нет", _
                                description, addCountryCount)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case ServiceType.ExtraLanguage
                    '
                    ' Работа с документами на иностранном языке
                    '
                    price = CSng(SRow("price")) * languageCount
                    If isUrgency Then
                        sprice = price * (URGENCY_KOEF - 1)
                        CalcRow("description") = String.Format("{0}, документов: {1}, срочность: Да ({2:c2} + {3:c2})", _
                                description, languageCount, price, sprice)
                    Else
                        CalcRow("description") = String.Format("{0}, документов: {1}, срочность: Нет", _
                                description, languageCount)
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select
                Case Else
                    '
                    ' Прочие услуги
                    '
                    price = CSng(SRow("price"))
                    If service <> ServiceType.ExtraPostal AndAlso service <> ServiceType.ExtraManual Then
                        '
                        ' Учет срочности
                        '
                        If isUrgency Then
                            sprice = price * (URGENCY_KOEF - 1)
                            CalcRow("description") = String.Format("{0}, срочность: Да ({1:c2} + {2:c2})", _
                                    description, price, sprice)
                        Else
                            CalcRow("description") = String.Format("{0}, срочность: Нет", _
                                    description)
                        End If
                    Else
                        CalcRow("description") = description
                    End If
                    CalcRow("price") = price + sprice
                    CalcRow("sprice") = sprice
                    Exit Select

            End Select
        Next
    End Sub

    ''' <summary>
    ''' Выполняет расчет стоимости одной услуги c учетом наличия допсоглашения и записывает результат в строку таблицы расчетов
    ''' </summary>
    ''' <param name="CalcRow">Строка таблицы расчетов с исходными данными для расчета</param>
    Private Sub SetPriceAgrement(ByRef CalcRow As DataRow)
        If CalcRow Is Nothing OrElse Not TypeOf CalcRow.Table Is CalcDataTable Then Exit Sub
        ' исходные данные
        Dim orderNum As String = Nothing                    ' номер договора
        Dim service As ServiceType = ServiceType.IsEmpty    ' вид услуги
        Dim materialCount As Integer = 0                    ' количество материальных объектов исследования
        Dim informationCount As Integer = 0                 ' количество информационных объектов исследования
        Dim goodCount As Integer = 0                        ' количество товаров
        Dim addCountryCount As Integer = 0                  ' количество дополнительных контрактов / стран назначения
        Dim languageCount As Integer = 0                    ' количество документов на иностранном языке
        Dim hourCount As Integer = 0                        ' количество часов на выполнение работы
        Dim oldPrice As Single = 0                          ' стоимость ранее выпущенного заключения
        Dim isPrice50 As Boolean = False                    ' признак скидки 50 % за работу
        Dim isUrgency As Boolean = False                    ' признак срочности
        ' результаты расчета
        Dim price As Single = 0                                     ' расчетная стоимость услуги = 0
        Dim description As String = ToText(CalcRow("description"))  ' информация о расчете = наименование услуги

        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        '
        ' Преобразование номера заказа в номер договора
        '
        orderNum = ToText(CalcRow("orderNum"))
        If String.IsNullOrWhiteSpace(orderNum) Then Exit Sub
        iTmp = orderNum.IndexOf("-")
        If iTmp > 0 Then orderNum = Trim(orderNum.Substring(0, iTmp))
        '
        ' Прочие исходные данные
        '
        service = CType(CalcRow("serviceId"), ServiceType)
        If service = ServiceType.ExtraDocCorrection Then Exit Sub ' исправление ошибки в ранее выпущенном заключении
        materialCount = ToInt(CalcRow("materialCount"))
        informationCount = ToInt(CalcRow("informationCount"))
        goodCount = ToInt(CalcRow("goodCount"))
        addCountryCount = ToInt(CalcRow("addCountryCount"))
        languageCount = ToInt(CalcRow("languageCount"))
        hourCount = ToInt(CalcRow("hourCount"))
        oldPrice = ToSng(CalcRow("oldPrice"))
        isPrice50 = CBool(CalcRow("isPrice50"))
        isUrgency = CBool(CalcRow("isUrgency"))
        '
        ' Расчет стоимости услуги в зависимости от номера договора и вида услуги
        '
        Select Case orderNum

            Case "01/17/73"                     ' РУСАТОМ СЕРВИС, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Базовая стоимость экспертизы одного объекта
                        price = 2300
                        '
                        ' Стоимость = Базовая стоимость + пропорциональное увеличение стоимости в зависимости от количества объектов
                        iTmp = materialCount + informationCount
                        For i As Integer = 2 To iTmp                            ' от 2, т.к. первый объект входит в базовую стоимость
                            If i < 6 Then : price += 781
                            ElseIf i < 26 Then : price += 649
                            ElseIf i < 71 Then : price += 506
                            ElseIf i < 101 Then : price += 473
                            ElseIf i < 201 Then : price += 440
                            ElseIf i < 301 Then : price += 407
                            Else : price += 374
                            End If
                        Next

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}", _
                            description, orderNum, iTmp)
                    Case Else
                        Exit Sub
                End Select

            Case "01/18/77"                     ' Инжиниринговая компания АСЭ (АСЭ ИК), АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость (2300) * количество материальных объектов + пропорциональное увеличение стоимости в зависимости от количества товаров
                        If materialCount > 0 Then
                            price = 2300 * materialCount
                            iTmp = goodCount - materialCount - informationCount
                            For i As Integer = 1 To iTmp                        ' от 1, т.к. первый товар является доп. товаром
                                If i < 6 Then : price += 781
                                ElseIf i < 26 Then : price += 649
                                ElseIf i < 71 Then : price += 506
                                ElseIf i < 101 Then : price += 473
                                Else : price += 440
                                End If
                            Next
                        End If
                        '
                        ' Расчет стоимости информационных объектов
                        ' Стоимость = Базовая стоимость (2300) * количество разнородных объектов
                        If informationCount > 0 Then price += 2300 * informationCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, мат. объектов: {2}, инф. объектов: {3}", _
                           description, orderNum, materialCount, informationCount)

                    Case Else
                        Exit Sub
                End Select

            Case "01/17/273"                    ' АТОМПРОЕКТ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2000) * количество разнородных объектов 
                        iTmp = materialCount + informationCount
                        price = 2000 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.ExpertLicConfirm
                        '
                        ' Подтверждение лицензии
                        ' ----------------------
                        '
                        ' Стоимость = Базовая стоимость (876) * количество разнородных объектов 
                        iTmp = materialCount + informationCount
                        price = 876 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case Else
                        Exit Sub
                End Select

            Case "01/18/93"             ' АТОМПРОЕКТ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2000) * количество разнородных объектов 
                        iTmp = iTmp = materialCount + informationCount
                        price = 2000 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case Else
                        Exit Sub
                End Select

            Case "05/1134"                      ' АТОМСТРОЙЭКСПОРТ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Базовая стоимость экспертизы одного товара или документа
                        price = 15100
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость + (900 * количество разнородных объектов > 1)
                        If materialCount > 0 Then price += 900 * (materialCount - 1)
                        '
                        ' Расчет стоимости информационных объектов
                        ' Пропорциональное увеличение стоимости в зависимости от количества информационных объектов
                        If informationCount > 0 Then
                            For i As Integer = 2 To informationCount        ' от 2, т.к. первый объект входит в базовую стоимость
                                If i < 26 Then : price += 600
                                Else : price += 250
                                End If
                            Next
                        End If
                        '
                        ' Скидка 50 % за вторую работу по заказу
                        If isPrice50 Then price /= 2
                        '
                        ' Срочное выполнение работы (+ 100 %)
                        If isUrgency Then
                            CalcRow("sprice") = price
                            price *= 2
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, мат. объектов: {2}, инф. объектов: {3}, скидка за 2 работу по заказу: {4}, срочность: {5}", _
                            description, orderNum, materialCount, informationCount, If(isPrice50, "Да", "Нет"), If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                        '
                        ' Внесение изменений в идентификационное заключение
                        ' -------------------------------------------------
                        '
                        ' Фиксированная стоимость внесение изменений (6000)
                        price = 6000

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocLess
                        '
                        ' Продление срока действия ранее выданного заключения
                        ' ---------------------------------------------------
                        '
                        ' Фиксированная стоимость внесение изменений (6000)
                        price = 6000

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "02/17/37"                     ' УНИВАР, ООО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Фиксированная стоимость услуги (9500)
                        price = 9500

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "02/18/2834"                   ' ТАГинн Северо-Запад, ООО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Фиксированная стоимость услуги (7500)
                        price = 7500

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/19/68"                     ' АТОМПРОЕКТ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2250) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 2250 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case Else
                        Exit Sub
                End Select

            Case "02/18/1300", "02/19/1936"     ' ГСПИ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2350) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 2350 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.ConsVed
                        '
                        ' Консультация по ВЭД
                        ' -------------------
                        '
                        ' Стоимость = Базовая стоимость (14500) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 14500 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/19/225"                    ' ГСПИ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2350) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 2350 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.ConsVed
                        '
                        ' Консультация по ВЭД
                        ' -------------------
                        '
                        ' Стоимость = Базовая стоимость (14500) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 14500 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.FstekLicense
                        '
                        ' Получение лицензии
                        ' ------------------
                        '
                        price = 29500
                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.FstekLess
                        '
                        ' Продление срока действия лицензии
                        ' ---------------------------------
                        '
                        price = 12520
                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/22/128"                        ' ГСПИ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2800) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 2800 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.ConsVed
                        '
                        ' Консультация по ВЭД
                        ' -------------------
                        '
                        ' Стоимость = Базовая стоимость (20000) * количество объектов 
                        iTmp = materialCount + informationCount
                        price = 20000 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case ServiceType.FstekLicense
                        '
                        ' Получение лицензии
                        ' ------------------
                        '
                        price = 29500
                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.FstekLess
                        '
                        ' Продление срока действия лицензии
                        ' ---------------------------------
                        '
                        price = 12520
                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/15/65"                     ' ПЛАНЕТА-ЭЛЕКС, ЗАО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Фиксированная стоимость услуги (7700)
                        price = 7700

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/18/164"                    ' РУСАТОМ СЕРВИС, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2350) * количество объектов + пропорциональное увеличение стоимости в зависимости от количества товаров
                        iTmp = materialCount + informationCount
                        price = 2350 * iTmp
                        iTmp = goodCount - iTmp
                        For i As Integer = 1 To iTmp                            ' от 1, т.к. первый товар является доп. товаром
                            If i < 6 Then : price += 800
                            ElseIf i < 26 Then : price += 670
                            ElseIf i < 71 Then : price += 530
                            ElseIf i < 101 Then : price += 495
                            ElseIf i < 201 Then : price += 450
                            ElseIf i < 301 Then : price += 407
                            Else : price += 374
                            End If
                        Next

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}, товаров: {3}", _
                            description, orderNum, iTmp, goodCount)

                    Case Else
                        Exit Sub
                End Select

            Case "01/19/135"                     ' Техснабэкспорт, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость (2350) + пропорциональное увеличение стоимости в зависимости от количества объектов
                        If materialCount > 0 Then
                            price = 2350
                            For i As Integer = 2 To materialCount               ' от 2, т.к. первый объект входит в базовую стоимость
                                If i < 6 Then : price += 800
                                ElseIf i < 26 Then : price += 670
                                ElseIf i < 71 Then : price += 530
                                ElseIf i < 101 Then : price += 495
                                Else : price += 450
                                End If
                            Next
                        End If
                        '
                        ' Расчет стоимости информационных объектов
                        ' Стоимость = Базовая стоимость (2350) * количество объектов
                        If informationCount > 0 Then price += 2350 * informationCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, мат. объектов: {2}, инф. объектов: {3}", _
                            description, orderNum, materialCount, informationCount)

                    Case Else
                        Exit Sub
                End Select

            Case "02/19/1768"                   ' РУСАТОМ СЕРВИС, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость (2400) * количество объектов
                        iTmp = materialCount + informationCount
                        price = 2400 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case Else
                        Exit Sub
                End Select

            Case "01/20/9"                      ' ЦНИИТМАШ, НПО, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость (2350) * количество объектов
                        iTmp = materialCount + informationCount
                        price = 2350 * iTmp

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, объектов: {2}", _
                           description, orderNum, iTmp)

                    Case Else
                        Exit Sub
                End Select

            Case "02/15/838"                    ' НЕВСКАЯ ПАЛИТРА, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Фиксированная стоимость услуги (13210)
                        price = 13210

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraFewDoc
                        '
                        ' Оформление отдельных заключений на отдельные страны назначения
                        ' --------------------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (1600) * количество дополнительных заключений
                        price = 1600 * addCountryCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, заключений: {2}", _
                           description, orderNum, addCountryCount)

                    Case Else
                        Exit Sub
                End Select

            Case "01/20/309"                    ' АТОМПРОЕКТ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' 
                        ' Экспертиза материальных объектов рассчитывается по стандартному алгоритму
                        If informationCount = 0 Then Exit Sub
                        '
                        ' Базовая стоимость документации на русском (4100) и английском (5900) языке разная
                        ' Стоимость = Базовая стоимость * количество объектов
                        iTmp = informationCount - languageCount ' количество документов на русском языке
                        If iTmp < 0 Then iTmp = 0
                        price = 4100 * iTmp + 5900 * languageCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, инф. объектов: {2}, на ин. языке: {3}", _
                           description, orderNum, informationCount, languageCount)

                    Case Else
                        Exit Sub
                End Select

            Case "01/21/222"                    ' ДЦ ЯТЦ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        price = 0
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость (14790) + 790 * количество объектов больше 1
                        If materialCount > 0 Then price += 14790 + (790 * (materialCount - 1))
                        '
                        ' Расчет стоимости информационных объектов
                        ' Базовая стоимость документации на русском (4100) и английском (5900) языке разная
                        ' Стоимость = Базовая стоимость * количество объектов
                        iTmp = informationCount - languageCount ' количество документов на русском языке
                        If iTmp < 0 Then iTmp = 0
                        price = 4100 * iTmp + 5900 * languageCount
                        '
                        ' Срочное выполнение работы (+ 100 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price
                            price *= 2
                        End If                       
                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, мат. объектов: {2}, инф. объектов: {3}, на ин. языке: {4}, срочность: {5}", _
                            description, orderNum, materialCount, informationCount, languageCount, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraLanguage
                        '
                        ' Работа с документами на иностранном языке (учитывается при расчете основной услуги)
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0} (входит в стоимость основной услуги), допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraPostal
                        '
                        ' Почтовая доставка документов
                        ' ----------------------------
                        '
                        price = 200

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 950

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                        '
                        ' Внесение изменений в идентификационное заключение
                        '
                        ' Фиксированная стоимость услуги (3600)
                        price = 3600

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocLess
                        '
                        ' Продление срока действия ранее выданного заключения
                        '
                        ' Фиксированная стоимость услуги (3600)
                        price = 3600

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "04/21/1475"                   ' НЕВСКАЯ ПАЛИТРА, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (14790) + (790 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 14790 + 790 * (iTmp - 1)

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}", _
                            description, orderNum, iTmp)

                    Case ServiceType.ExtraFewDoc
                        '
                        ' Оформление отдельных заключений на отдельные страны назначения
                        ' --------------------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2500) * количество дополнительных заключений
                        price = 2500 * addCountryCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, заключений: {2}", _
                           description, orderNum, addCountryCount)

                    Case ServiceType.ExtraPostal
                        '
                        ' Почтовая доставка документов
                        ' ----------------------------
                        '
                        price = 200

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 910

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                        '
                        ' Внесение изменений в идентификационное заключение
                        '
                        ' Фиксированная стоимость внесение изменений (3600)
                        price = 3600

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocLess
                        '
                        ' Продление срока действия ранее выданного заключения
                        '
                        ' Фиксированная стоимость внесение изменений (3600)
                        price = 3600

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "02/15/9"                      ' ГеоЛогистикс, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (15200) + (950 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 15200 + 950 * (iTmp - 1)
                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}, срочность: {3}", _
                            description, orderNum, iTmp, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraFewDoc
                        '
                        ' Оформление отдельных заключений на отдельные страны назначения
                        ' --------------------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2600) * количество дополнительных заключений
                        price = 2600 * addCountryCount
                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                           "{0}, допсоглашение: {1}, заключений: {2}, срочность: {3}", _
                           description, orderNum, addCountryCount, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ConsTnved
                        '
                        ' Определение кода ТН ВЭД
                        ' -----------------------
                        '
                        ' Стоимость = Базовая стоимость (7600) + (400 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 7600 + 400 * (iTmp - 1)
                        '
                        ' Срочное выполнение работы (+ 100 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price
                            price *= 2
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}, срочность: {3}", _
                            description, orderNum, iTmp, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraPostal
                        '
                        ' Почтовая доставка документов
                        ' ----------------------------
                        '
                        price = 200

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 910

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                        '
                        ' Внесение изменений в идентификационное заключение
                        '
                        ' Стоимость = Базовая стоимость (2200) * количество часов
                        If hourCount < 1 Then hourCount = 1
                        price = 2200 * hourCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, часов: {2}", _
                            description, orderNum, hourCount)


                    Case ServiceType.ExtraDocLess
                        '
                        ' Продление срока действия ранее выданного заключения
                        '
                        ' Стоимость = Базовая стоимость (2200) * количество часов
                        If hourCount < 1 Then hourCount = 1
                        price = 2200 * hourCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, часов: {2}", _
                            description, orderNum, hourCount)

                    Case Else
                        Exit Sub
                End Select

            Case "02/15/523"                    ' Кюне + Нагель, ООО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (15200) + (950 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 15200 + 950 * (iTmp - 1)

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}", _
                            description, orderNum, iTmp)

                    Case ServiceType.ConsTnved
                        '
                        ' Определение кода ТН ВЭД
                        ' -----------------------
                        '
                        ' Стоимость = Базовая стоимость (7600) + (475 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 7600 + 475 * (iTmp - 1)

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}", _
                            description, orderNum, iTmp)

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                        '
                        ' Внесение изменений в идентификационное заключение
                        '
                        ' Фиксированная стоимость внесение изменений (3100)
                        price = 3100

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocLess
                        '
                        ' Продление срока действия ранее выданного заключения
                        '
                        ' Фиксированная стоимость внесение изменений (3100)
                        price = 3100

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/22/89"                      ' ТЕХСНАБЭКСПОРТ, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Расчет стоимости материальных объектов
                        ' Стоимость = Базовая стоимость (2500) + (900 * количество объектов > 1)
                        price = 0
                        If materialCount > 0 Then price = 2500 + 900 * (materialCount - 1)
                        '
                        ' Расчет стоимости информационных объектов
                        ' Стоимость = 2500 * количество объектов
                        If informationCount > 0 Then price += 2500 * informationCount
                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, мат. объектов: {2}, инф. объектов: {3}, срочность: {4}", _
                            description, orderNum, materialCount, informationCount, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraLanguage
                        '
                        ' Работа с документами на иностранном языке
                        ' -----------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (2000) * количество документов
                        price = 2000 * languageCount
                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, документов: {2}, срочность: {3}", _
                            description, orderNum, languageCount, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional
                        '
                        ' Внесение изменений в идентификационное заключение
                        '
                        ' Стоимость = Базовая стоимость (2000) * количество часов
                        If hourCount < 1 Then hourCount = 1
                        price = 2000 * hourCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, часов: {2}", _
                            description, orderNum, hourCount)

                    Case ServiceType.ExtraDocLess
                        '
                        ' Продление срока действия ранее выданного заключения
                        '
                        ' Стоимость = Базовая стоимость (2000) * количество часов
                        If hourCount < 1 Then hourCount = 1
                        price = 2000 * hourCount

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, часов: {2}", _
                            description, orderNum, hourCount)

                    Case Else
                        Exit Sub
                End Select

            Case "04/22/1715"                      ' ТЕХНОПРОМЭКСПОРТ, ООО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (14900) + (900 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 14900 + 900 * (iTmp - 1)

                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, срочность: {2}", _
                            description, orderNum, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ConsTnved
                        '
                        ' Определение кода ТН ВЭД
                        ' -----------------------
                        '
                        ' Стоимость = Базовая стоимость (7450) + (450 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 7450 + 450 * (iTmp - 1)

                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, срочность: {2}", _
                            description, orderNum, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional, ServiceType.ExtraDocLess
                        '
                        ' Внесение изменений в идентификационное заключение, продление срока действия заключения
                        '
                        ' 50 % стоимости ранее выданного заключения
                        price = oldPrice / 2

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraPostal
                        '
                        ' Почтовая доставка документов
                        ' ----------------------------
                        '
                        price = 500

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 1000

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocPaper
                        '
                        ' Оформление копии электронного заключения на бумажном носителе
                        ' -------------------------------------------------------------
                        '
                        price = 200

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)


                    Case Else
                        Exit Sub
                End Select

            Case "01/22/721"                    ' РУСАТОМ СЕРВИС, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Базовая стоимость зависит от срочности
                        price = If(isUrgency, 3243.73, 2329.4)
                        ' Стоимость = Базовая стоимость * количество разнородных объектов + пропорциональное увеличение стоимости в зависимости от количества однородных объектов
                        ' Разнородные объекты
                        iTmp = materialCount + informationCount
                        price = price * iTmp
                        ' Однородные объекты
                        iTmp = goodCount - iTmp
                        For i As Integer = 1 To iTmp
                            If i < 6 Then : price += 800
                            ElseIf i < 26 Then : price += 670
                            ElseIf i < 71 Then : price += 530
                            ElseIf i < 101 Then : price += 495
                            ElseIf i < 201 Then : price += 450
                            ElseIf i < 301 Then : price += 407
                            Else : price += 374
                            End If
                        Next

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}, срочность: {3}", _
                            description, orderNum, iTmp, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ConsTnved
                        '
                        ' Определение кода ТН ВЭД
                        ' -----------------------
                        '
                        ' Базовая стоимость
                        price = 2000
                        ' Стоимость = Базовая стоимость * количество разнородных объектов + пропорциональное увеличение стоимости в зависимости от количества однородных объектов
                        ' Разнородные объекты
                        iTmp = materialCount + informationCount
                        price = price * iTmp
                        ' Однородные объекты
                        iTmp = goodCount - iTmp
                        For i As Integer = 1 To iTmp
                            If i < 6 Then : price += 800
                            ElseIf i < 26 Then : price += 670
                            ElseIf i < 71 Then : price += 530
                            ElseIf i < 101 Then : price += 495
                            ElseIf i < 201 Then : price += 450
                            ElseIf i < 301 Then : price += 407
                            Else : price += 374
                            End If
                        Next

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, объектов: {2}", _
                            description, orderNum, iTmp)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "01/23/70"                         ' СИЛОВЫЕ МАШИНЫ, ОАО
                Select Case service
                    Case ServiceType.ExpertExcont, ServiceType.ExpertCustoms, ServiceType.ConsTnved, ServiceType.ConsVed
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' Экспертиза по запретам и ограничениям ЕАЭС
                        ' Консультация по определению кода ТН ВЭД
                        ' Консультация по ВЭД
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (6650) + (665 * количество объектов > 10)
                        price = 6650
                        iTmp = materialCount + informationCount
                        If iTmp > 10 Then price += 665 * (iTmp - 10)                       
                        '
                        ' Срочное выполнение работы (+ 25 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 4
                            price *= 1.25
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, срочность: {2}", _
                            description, orderNum, If(isUrgency, String.Format("Да ({0} р.)", CalcRow("sprice").ToString), "Нет"))

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional, ServiceType.ExtraDocLess
                        '
                        ' Внесение изменений в идентификационное заключение, продление срока действия заключения
                        '
                        ' Фиксированная стоимость услуги (2850)
                        price = 2850

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.FstekLicense, ServiceType.FstekPrepare, ServiceType.Notification
                        '
                        ' Лицензия ФСТЭК / Разрешение КЭК, Нотификация
                        ' --------------------------------------------
                        '
                        ' Фиксированная стоимость (13775)
                        price = 13775

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 0

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case Else
                        Exit Sub
                End Select

            Case "04/23/1047"                      ' КОНЦЕРН ТИТАН-2, АО
                Select Case service
                    Case ServiceType.ExpertExcont
                        '
                        ' Идентификационная экспертиза по экспортному контролю
                        ' ----------------------------------------------------
                        '
                        ' Стоимость = Базовая стоимость (14155) + (855 * количество объектов > 1)
                        iTmp = materialCount + informationCount
                        price = 14155 + 855 * (iTmp - 1)

                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, срочность: {2}", _
                            description, orderNum, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ConsTnved
                        '
                        ' Определение кода ТН ВЭД
                        ' -----------------------
                        '
                        ' Стоимость = 1805 за каждый код
                        iTmp = materialCount + informationCount
                        price = 1805 * iTmp

                        '
                        ' Срочное выполнение работы (+ 50 % стоимости)
                        If isUrgency Then
                            CalcRow("sprice") = price / 2
                            price *= 1.5
                        End If

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}, срочность: {2}", _
                            description, orderNum, If(isUrgency, "Да", "Нет"))

                    Case ServiceType.ConsVed
                        '
                        ' Консультация по ВЭД
                        ' -----------------------
                        '
                        ' Стоимость = Базовая стоимость (9025) + (1425 * количество вопросов > 1)
                        iTmp = materialCount + informationCount
                        price = 9025 + 1425 * (iTmp - 1)

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocReissue, ServiceType.ExtraDocAdditional, ServiceType.ExtraDocLess
                        '
                        ' Внесение изменений в идентификационное заключение, продление срока действия заключения
                        '
                        ' 50 % стоимости ранее выданного заключения
                        price = oldPrice / 2

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraPostal
                        '
                        ' Почтовая доставка документов
                        ' ----------------------------
                        '
                        price = 475

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraManual
                        '
                        ' Обработка документов по заявке
                        ' ------------------------------
                        '
                        price = 1000

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)

                    Case ServiceType.ExtraDocPaper
                        '
                        ' Оформление копии электронного заключения на бумажном носителе
                        ' -------------------------------------------------------------
                        '
                        price = 475

                        CalcRow("price") = price
                        CalcRow("description") = String.Format( _
                            "{0}, допсоглашение: {1}", _
                            description, orderNum)


                    Case Else
                        Exit Sub
                End Select

        End Select

    End Sub


End Class
