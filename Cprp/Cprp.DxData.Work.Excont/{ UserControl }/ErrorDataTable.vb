Imports C2 = Cprp.DxData.Common
Imports MK = Cprp.DxData.Member.MemberKind
''' <summary>
''' Сообщения об ошибках
''' </summary>
Friend Class ErrorDataTable : Inherits DataTable

    ''' <summary>
    ''' Работа
    ''' </summary>
    Private Work As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Текущий заголовок сообщения об ошибке
    ''' </summary>
    Private erPlace As String = Nothing

    ''' <summary>
    ''' Текущий идентификатор раздела работы
    ''' </summary>
    Private erType As ContentEnum = ContentEnum.Content

    ''' <summary>
    ''' Текущий результат проверки
    ''' </summary>
    Private erBool As Boolean = False


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.ErrorDataTable
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <remarks></remarks>
    Public Sub New(Work As WorkConnectionRow)
        '
        ' Me
        '
        MyBase.New("ErrorTable")
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID строки
            .Add("contentId", GetType(ContentEnum))     ' Идентификатор раздела
            .Add("objectId", GetType(Integer))          ' Идентификатор объекта в списке объектов раздела
            .Add("place", GetType(String))              ' Место ошибки
            .Add("description", GetType(String))        ' Описание ошибки
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.Columns("contentId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' Work
        '
        MyClass.Work = Work
    End Sub

    ''' <summary>
    ''' Добавить новую строку с сообщением об ошибке
    ''' </summary>
    ''' <param name="objectId">ID строки таблицы данных, содержащую ошибку</param>
    ''' <param name="content">Идентификатор раздела работы</param>
    ''' <param name="place">Описание места ошибки</param>
    ''' <param name="description">Описание ошибки</param>
    ''' <remarks></remarks>
    Private Sub AddNew(objectId As Integer, content As ContentEnum, place As String, description As String)
        Dim Row As DataRow = MyBase.NewRow
        Row("objectId") = objectId
        Row("contentId") = CInt(content)
        Row("place") = place
        Row("description") = description
        Me.Rows.Add(Row)
    End Sub

    ''' <summary>
    ''' Добавить новую строку с сообщением об ошибке
    ''' </summary>
    ''' <param name="objectId">ID строки таблицы данных, содержащую ошибку</param>
    ''' <param name="description">Описание ошибки</param>
    ''' <remarks></remarks>
    Private Sub AddNew(objectId As Integer, description As String)
        Dim Row As DataRow = MyBase.NewRow
        Row("objectId") = objectId
        Row("contentId") = CInt(erType)
        Row("place") = erPlace
        Row("description") = description
        Me.Rows.Add(Row)
    End Sub

#Region "Вся работа"

    ''' <summary>
    ''' Проверить работу на наличие ошибок
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckWork() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        Me.Rows.Clear()
        Dim bTmp As Boolean = True
        If Not CheckWorkDescription() Then bTmp = False
        If Work.Condition = WorkCondition.IsPlaneWork OrElse Work.Condition = WorkCondition.IsPlaneAgree Then
            If Not CheckPlane() Then Return False
        Else
            If Not CheckExtraDoc() Then bTmp = False
            If Not CheckContract() Then bTmp = False
            If Not CheckSupply() Then bTmp = False
            If Not CheckGood() Then bTmp = False
            If Not CheckSummary() Then bTmp = False
            If Not CheckExtraInfo() Then bTmp = False
        End If
        Return bTmp
    End Function

    ''' <summary>
    ''' Проверить обобщенное наименование объектов экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckWorkDescription() As Boolean
        If Not C2.IsText(Work("description")) Then
            AddNew(C2.EMPTY_ID, ContentEnum.Content, "Сведения о работе > Продукция", "Не указано обобщенное наименование объектов экспертизы")
            Return False
        End If
        Return True
    End Function

#End Region
#Region "План работы"

    Friend Function CheckPlane() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "План работы"
        erType = ContentEnum.Plane
        erBool = True
        If CInt(Work.ARow("goodCount")) = 0 Then
            AddNew(C2.EMPTY_ID, "Не указано количество товаров")
            erBool = False
        End If
        If CInt(Work.ARow("matCount")) + CInt(Work.ARow("infCount")) = 0 Then
            AddNew(C2.EMPTY_ID, "Не указано количество объектов исследования")
            erBool = False
        End If
        If IsDBNull(Work.ARow("totalWork")) OrElse CInt(Work.ARow("totalWork")) = 0 Then
            AddNew(C2.EMPTY_ID, "Не указана трудоемкость")
            erBool = False
        End If
        If IsDBNull(Work.ARow("expertTerm")) Then
            AddNew(C2.EMPTY_ID, "Не указан срок исполнения")
            erBool = False
        End If
        If CBool(Work.ARow("isSendQuery")) AndAlso Not (CBool(Work("isAsk")) OrElse CBool(Work("isAskSign")) OrElse CBool(Work("isAskSend"))) Then
            AddNew(C2.EMPTY_ID, "Необходимо подготовить и направить на утверждение запрос")
            erBool = False
        End If

        Return erBool
    End Function

#End Region
#Region "Сделка и участники сделки"

    ''' <summary>
    ''' Проверить данные сделки и участников сделки
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckContract() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If CBool(Work.ARow("isNotContract")) OrElse CBool(Work.ARow("isDefContract")) Then Return True
        Dim bTmp As Boolean = True
        Dim bProfile As Boolean = False
        '
        ' Определение необходимости заполнения профиля иностранных фирм
        '
        Using V As New DataView(Work.GoodTable)
            V.RowFilter = String.Format("studySummaryId > {0}", CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing))
            If V.Count > 0 Then bProfile = True
        End Using
        Dim Row As DataRow = Work.CountryHandbookTable.Rows.Find(C2.ToInt(Work.ARow("countryId")))
        If Not Row Is Nothing AndAlso C2.IsText(Row("riskDescription")) Then bProfile = True
        '
        ' Проверка данных
        '
        If Not CheckContractData() Then bTmp = False
        If Not CheckContractRisk() Then bTmp = False
        If Not CheckMemberList(MK.IsContractRus) Then bTmp = False
        For Each VRow As DataRowView In Work.MemberTable.ConRusView
            If Not CheckMemberData(VRow.Row, MK.IsContractRus) Then bTmp = False
            If Not CheckMemberRisk(VRow.Row, MK.IsContractRus) Then bTmp = False
        Next
        If Not CheckMemberList(MK.IsContractNus) Then bTmp = False
        For Each VRow As DataRowView In Work.MemberTable.ConNusView
            If Not CheckMemberData(VRow.Row, MK.IsContractNus) Then bTmp = False
            If Not CheckMemberEmbargo(VRow.Row, MK.IsContractNus) Then bTmp = False
            If Not CheckMemberControl(VRow.Row, MK.IsContractNus) Then bTmp = False
            If bProfile AndAlso Not CheckMemberProfile(VRow.Row, MK.IsContractNus) Then bTmp = False
            If Not CheckMemberRisk(VRow.Row, MK.IsContractNus) Then bTmp = False
        Next
        Return bTmp
    End Function

#End Region
#Region "Операция и участники операции"

    ''' <summary>
    ''' Проверить данные операции и участников операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckSupply() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        Dim bTmp As Boolean = True
        Dim bProfile As Boolean = False
        '
        ' Определение необходимости заполнения профиля иностранных фирм
        '
        Using V As New DataView(Work.GoodTable)
            V.RowFilter = String.Format("studySummaryId > {0}", CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing))
            If V.Count > 0 Then bProfile = True
        End Using
        Dim Row As DataRow = Work.CountryHandbookTable.Rows.Find(C2.ToInt(Work.ARow("countryId")))
        If Not Row Is Nothing AndAlso C2.IsText(Row("riskDescription")) Then bProfile = True
        '
        ' Проверка данных
        '
        If Not CheckSupplyData() Then bTmp = False
        If Not CheckSupplyRisk() Then bTmp = False
        If Not CheckMemberList(MK.IsSupplyRus) Then bTmp = False
        For Each VRow As DataRowView In Work.MemberTable.SupRusView
            If Not CheckMemberData(VRow.Row, MK.IsSupplyRus) Then bTmp = False
            If Not CheckMemberRisk(VRow.Row, MK.IsSupplyRus) Then bTmp = False
        Next
        For Each VRow As DataRowView In Work.MemberTable.SupNusView
            If Not CheckMemberData(VRow.Row, MK.IsSupplyNus) Then bTmp = False
            If Not CheckMemberEmbargo(VRow.Row, MK.IsSupplyNus) Then bTmp = False
            If Not CheckMemberControl(VRow.Row, MK.IsSupplyNus) Then bTmp = False
            If bProfile AndAlso Not CheckMemberProfile(VRow.Row, MK.IsSupplyNus) Then bTmp = False
            If Not CheckMemberRisk(VRow.Row, MK.IsSupplyNus) Then bTmp = False
        Next
        For Each VRow As DataRowView In Work.MemberTable.SupEndView
            If Not CheckMemberData(VRow.Row, MK.IsSupplyEnd) Then bTmp = False
            If Not CheckMemberEmbargo(VRow.Row, MK.IsSupplyEnd) Then bTmp = False
            If Not CheckMemberControl(VRow.Row, MK.IsSupplyEnd) Then bTmp = False
            If bProfile AndAlso Not CheckMemberProfile(VRow.Row, MK.IsSupplyEnd) Then bTmp = False
            If Not CheckMemberRisk(VRow.Row, MK.IsSupplyEnd) Then bTmp = False
        Next
        Return bTmp
    End Function

#End Region
#Region "Продукция (объекты экспертизы)"

    ''' <summary>
    ''' Проверить данные объектов экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckGood() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        Dim bTmp As Boolean = True
        '
        ' Проверка данных
        '
        If Not CheckGoodList() Then bTmp = False
        For Each Row As DataRow In Work.GoodTable.Rows
            If Not CheckGoodData(Row) Then bTmp = False
            If Not CheckGoodEmbargo(Row) Then bTmp = False
            If Not CheckGoodControl(Row) Then bTmp = False
            If Not CheckGoodLaw(Row) Then bTmp = False
            If Not CheckGoodSummary(Row) Then bTmp = False
            If Not CheckGoodRisk(Row) Then bTmp = False
        Next
        Return bTmp
    End Function

#End Region

    ''' <summary>
    ''' Проверить регистрационные данные сделки
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckContractData() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Внешнеэкономическая сделка > Регистрационные данные"
        erType = ContentEnum.ContractData
        erBool = True
        With Work.ARow
            If Not C2.IsText(.Item("contractName")) Then
                AddNew(C2.EMPTY_ID, "Не указано наименование документа-основания сделки")
                erBool = False
            End If
            If IsDBNull(.Item("contractTerm")) AndAlso Not CBool(.Item("isNotContractTerm")) Then
                AddNew(C2.EMPTY_ID, "Не указан срок действия документа-основания сделки")
                erBool = False
            End If
            If Not IsDBNull(.Item("contractTerm")) AndAlso CDate(.Item("contractTerm")) < Date.Today Then
                AddNew(C2.EMPTY_ID, "Срок действия документа-основания сделки меньше текущей даты")
                erBool = False
            End If
            If Not C2.IsText(.Item("contractDescription")) Then
                AddNew(C2.EMPTY_ID, "Отсутствует описание предмета сделки")
                erBool = False
            End If
        End With
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить риски по сделке
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckContractRisk() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Внешнеэкономическая сделка > Риски"
        erType = ContentEnum.ContractRisk
        erBool = True
        If CBool(Work.ARow("isNotContractRisk")) OrElse C2.IsText(Work.ARow("otherContractRisk")) Then Return True
        If Work.ContractRiskTable.Rows.Count = 0 Then
            AddNew(C2.EMPTY_ID, "Не указано наличие или отсутствие рисков")
            erBool = False
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить регистрационные данные операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckSupplyData() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Внешнеэкономическая операция > Регистрационные данные"
        erType = ContentEnum.SupplyData
        erBool = True
        '
        ' Характер внешнеэкономической операции
        '
        If IsDBNull(Work.ARow("supplyTypeId")) Then
            AddNew(C2.EMPTY_ID, "Не указан характер внешнеэкономической операции")
            erBool = False
        End If
        '
        ' Страна назначения (отправления)
        '
        If IsDBNull(Work.ARow("countryIdString")) Then
            If CType(Work.ARow("supplyTypeId"), Cprp.DxData.Work.SupplyType) <> SupplyType.IsTransit Then
                AddNew(C2.EMPTY_ID, "Не указана страна назначения (отправления)")
                erBool = False
            End If
        End If
        '
        ' Страна банка
        '
        If IsDBNull(Work.ARow("bankCountryId")) Then
            AddNew(C2.EMPTY_ID, "Не указана страна банка")
            erBool = False
        End If
        '
        ' Предмет операции
        '
        If Not C2.IsText(Work.ARow("supplyDescription")) Then
            AddNew(C2.EMPTY_ID, "Отсутствует описание предмета операции")
            erBool = False
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить риски по операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckSupplyRisk() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Внешнеэкономическая операция > Риски"
        erType = ContentEnum.SupplyRisk
        erBool = True
        If CBool(Work.ARow("isNotSupplyRisk")) OrElse C2.IsText(Work.ARow("otherSupplyRisk")) Then Return True
        If Work.SupplyRiskTable.Rows.Count = 0 Then
            AddNew(C2.EMPTY_ID, "Не указано наличие или отсутствие рисков")
            erBool = False
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить наличие списка лиц
    ''' </summary>
    ''' <param name="kind">Вид лица</param> 
    ''' <remarks></remarks>
    Friend Function CheckMemberList(kind As MK) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        Dim V As DataView = Nothing
        Dim sTmp As String = Nothing
        Select Case kind
            Case MK.IsContractRus
                erPlace = "Внешнеэкономическая сделка > Российские участники"
                erType = ContentEnum.ContractRusList
                V = Work.MemberTable.ConRusView
                sTmp = "Отсутствуют российские участники сделки"
            Case MK.IsContractNus
                erPlace = "Внешнеэкономическая сделка > Иностранные участники"
                erType = ContentEnum.ContractNusList
                V = Work.MemberTable.ConNusView
                sTmp = "Отсутствуют иностранные участники сделки"
            Case MK.IsSupplyRus
                erPlace = "Внешнеэкономическая операция > Российские участники"
                erType = ContentEnum.SupplyRusList
                V = Work.MemberTable.SupRusView
                sTmp = "Отсутствуют российские участники операции"
            Case MK.IsSupplyNus
                erPlace = "Внешнеэкономическая операция > Иностранные покупатели (продавцы)"
                erType = ContentEnum.SupplyNusList
                V = Work.MemberTable.SupNusView
                sTmp = "Отсутствуют иностранные покупатели (продлавцы)"
            Case MK.IsSupplyEnd
                erPlace = "Внешнеэкономическая операция > Потребители (конечные пользователи)"
                erType = ContentEnum.SupplyEndList
                V = Work.MemberTable.SupEndView
                sTmp = "Отсутствуют потребители (конечные пользователи)"
            Case Else
                Return False
        End Select
        erBool = (V.Count > 0)
        If Not erBool Then AddNew(C2.EMPTY_ID, sTmp)
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить регистрационные данные лица
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="kind">Вид лица</param> 
    ''' <remarks></remarks>
    Friend Function CheckMemberData(Row As DataRow, kind As MK) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.MemberTable Then Return False
        Select Case kind
            Case MK.IsContractRus
                erPlace = String.Format("Внешнеэкономическая сделка > Российские участники > Объект № {0} > Регистрационные данные", C2.ToInt(Row("conRusNum")))
                erType = ContentEnum.ContractRusData
            Case MK.IsContractNus
                erPlace = String.Format("Внешнеэкономическая сделка > Иностранные участники > Объект № {0} > Регистрационные данные", C2.ToInt(Row("conNusNum")))
                erType = ContentEnum.ContractNusData
            Case MK.IsSupplyRus
                erPlace = String.Format("Внешнеэкономическая операция > Российские участники > Объект № {0} > Регистрационные данные", C2.ToInt(Row("supRusNum")))
                erType = ContentEnum.SupplyRusData
            Case MK.IsSupplyNus
                erPlace = String.Format("Внешнеэкономическая операция > Иностранные покупатели (продавцы) > Объект № {0} > Регистрационные данные", C2.ToInt(Row("supNusNum")))
                erType = ContentEnum.SupplyNusData
            Case MK.IsSupplyEnd
                erPlace = String.Format("Внешнеэкономическая операция > Потребители (конечные пользователи) > Объект № {0} > Регистрационные данные", C2.ToInt(Row("supEndNum")))
                erType = ContentEnum.SupplyEndData
            Case Else
                Return False
        End Select
        erBool = True
        '
        ' Полное наименование
        '
        If Not C2.IsText(Row("nameLong")) Then
            AddNew(Row("id"), "Не указано полное наименование")
            erBool = False
        End If
        '
        ' Краткое наименование
        '
        If Not C2.IsText(Row("nameShort")) Then
            AddNew(Row("id"), "Не указано краткое наименование")
            erBool = False
        End If
        '
        ' ИНН
        '
        If kind = MK.IsContractRus OrElse kind = MK.IsSupplyRus Then
            Dim inn As String = C2.ToText(Row("inn"))
            If Not C2.IsText(inn) Then
                AddNew(Row("id"), "Не указан ИНН")
                erBool = False
            ElseIf (inn.Length <> 10 AndAlso inn.Length <> 12) OrElse Not IsNumeric(inn) Then
                AddNew(Row("id"), "Указан неверный ИНН")
                erBool = False
            End If
        End If
        '
        ' Юридический адрес
        '
        If Not C2.IsText(Row("addressLegalFull")) Then
            AddNew(Row("id"), "Не указан юридический адрес")
            erBool = False
        End If
        '
        ' Страна юридического адреса
        '
        If IsDBNull(Row("addressLegalCountryId")) Then
            AddNew(Row("id"), "Не указана страна юридического адреса")
            erBool = False
        End If
        '
        ' Город юридического адреса
        '
        If Not C2.IsText(Row("addressLegalTown")) AndAlso Not (kind = Member.MemberKind.IsClient OrElse kind = Member.MemberKind.IsContractRus AndAlso Not kind = Member.MemberKind.IsSupplyRus) Then
            AddNew(Row("id"), "Не указан город юридического адреса")
            erBool = False
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить запреты и ограничения лица
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="kind">Вид лица</param> 
    ''' <remarks></remarks>
    Friend Function CheckMemberEmbargo(Row As DataRow, kind As MK) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.MemberTable Then Return False
        If IsDBNull(Row("addressLegalCountryId")) Then Return False
        If CBool(Row("isNotEmbargo")) Then Return True
        Select Case kind
            Case MK.IsContractNus
                erPlace = String.Format("Внешнеэкономическая сделка > Иностранные участники > Объект № {0} > Запреты и ограничения", C2.ToInt(Row("conNusNum")))
                erType = ContentEnum.ContractNusEmbargo
            Case MK.IsSupplyNus
                erPlace = String.Format("Внешнеэкономическая операция > Иностранные покупатели (продавцы) > Объект № {0} > Запреты и ограничения", C2.ToInt(Row("supNusNum")))
                erType = ContentEnum.SupplyNusEmbargo
            Case MK.IsSupplyEnd
                erPlace = String.Format("Внешнеэкономическая операция > Потребители (конечные пользователи) > Объект № {0} > Запреты и ограничения", C2.ToInt(Row("supEndNum")))
                erType = ContentEnum.SupplyEndEmbargo
            Case Else
                Return False
        End Select
        '
        ' Проверка наличия запретов по стране юридического адреса объекта
        '
        Using V As DataView = Work.EmbargoMemberHandbookTable.CountryView(Row("addressLegalCountryId"), CType(Work.ARow("modeId"), Cprp.DxData.ModeEnum))
            If V.Count = 0 Then Return True
        End Using
        '
        ' Поиск объекта в справочнике запретов
        '
        Dim countryId As Integer = C2.ToInt(Row("addressLegalCountryId"))
        Using V As DataView = Work.MemberEmbargoTable.MemberView(Row("id"))
            For Each VRow As DataRowView In V
                If Not Work.EmbargoMemberHandbookTable.Rows.Find(New Object() {VRow("embargoMemberId"), countryId}) Is Nothing Then Return True
            Next
        End Using
        '
        ' Запреты не указаны
        '
        AddNew(Row("id"), "Не указано наличие или отсутствие запретов и ограничений")
        Return False
    End Function

    ''' <summary>
    ''' Проверить связи лица с фирмами на контроле
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="kind">Вид лица</param> 
    ''' <remarks></remarks>
    Friend Function CheckMemberControl(Row As DataRow, kind As MK) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.MemberTable Then Return False
        If IsDBNull(Row("addressLegalCountryId")) Then Return False
        If CBool(Row("isNotControl")) Then Return True
        Select Case kind
            Case MK.IsContractNus
                erPlace = String.Format("Внешнеэкономическая сделка > Иностранные участники > Объект № {0} > На контроле", C2.ToInt(Row("conNusNum")))
                erType = ContentEnum.ContractNusControl
            Case MK.IsSupplyNus
                erPlace = String.Format("Внешнеэкономическая операция > Иностранные покупатели (продавцы) > Объект № {0} > На контроле", C2.ToInt(Row("supNusNum")))
                erType = ContentEnum.SupplyNusControl
            Case MK.IsSupplyEnd
                erPlace = String.Format("Внешнеэкономическая операция > Потребители (конечные пользователи) > Объект № {0} > На контроле", C2.ToInt(Row("supEndNum")))
                erType = ContentEnum.SupplyEndControl
            Case Else
                Return False
        End Select
        '
        ' Проверка наличия фирм на контроле в стране юридического адреса объекта
        '
        Using V As DataView = Work.ControlMemberHandbookTable.CountryView(Row("addressLegalCountryId"))
            If V.Count = 0 Then Return True
        End Using
        '
        ' Поиск объекта в справочнике фирм на контроле
        '
        Using V As DataView = Work.MemberControlTable.MemberView(Row("id"))
            For Each VRow As DataRowView In V
                If Not Work.ControlMemberHandbookTable.Rows.Find(VRow("controlMemberId")) Is Nothing Then Return True
            Next
        End Using
        '
        ' Фирмы на контроле не указаны
        '
        AddNew(Row("id"), "Не указано наличие или отсутствие связей с фирмами на контроле")
        Return False
    End Function

    ''' <summary>
    ''' Проверить профиль лица
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="kind">Вид лица</param> 
    ''' <remarks></remarks>
    Friend Function CheckMemberProfile(Row As DataRow, kind As MK) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.MemberTable Then Return False
        If kind = Member.MemberKind.IsClient OrElse kind = Member.MemberKind.IsContractRus OrElse kind = Member.MemberKind.IsSupplyRus Then Return True
        Select Case kind
            Case MK.IsContractRus
                erPlace = String.Format("Внешнеэкономическая сделка > Российские участники > Объект № {0} > Профиль", C2.ToInt(Row("conRusNum")))
                erType = ContentEnum.ContractRusProfile
            Case MK.IsContractNus
                erPlace = String.Format("Внешнеэкономическая сделка > Иностранные участники > Объект № {0} > Профиль", C2.ToInt(Row("conNusNum")))
                erType = ContentEnum.ContractNusProfile
            Case MK.IsSupplyRus
                erPlace = String.Format("Внешнеэкономическая операция > Российские участники > Объект № {0} > Профиль", C2.ToInt(Row("supRusNum")))
                erType = ContentEnum.SupplyRusProfile
            Case MK.IsSupplyNus
                erPlace = String.Format("Внешнеэкономическая операция > Иностранные покупатели (продавцы) > Объект № {0} > Профиль", C2.ToInt(Row("supNusNum")))
                erType = ContentEnum.SupplyNusProfile
            Case MK.IsSupplyEnd
                erPlace = String.Format("Внешнеэкономическая операция > Потребители (конечные пользователи) > Объект № {0} > Профиль", C2.ToInt(Row("supEndNum")))
                erType = ContentEnum.SupplyEndProfile
            Case Else
                Return False
        End Select
        erBool = True
        If Not C2.IsText(Row("proSource")) Then
            AddNew(Row("id"), "Не заполнен профиль фирмы")
            erBool = False
        End If
        If Not C2.IsText(Row("proDescription")) Then
            AddNew(Row("id"), "Не указан источник данных для заполнения профиля")
            erBool = False
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить риски лица
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="kind">Вид лица</param> 
    ''' <remarks></remarks>
    Friend Function CheckMemberRisk(Row As DataRow, kind As MK) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.MemberTable Then Return False
        Dim riskType As Cprp.DxData.Risk.TypeEnum = Risk.TypeEnum.IsEmpty
        Select Case kind
            Case MK.IsContractRus
                If CBool(Row("isNotConRusRisk")) Then Return True
                erPlace = String.Format("Внешнеэкономическая сделка > Российские участники > Объект № {0} > Риски", C2.ToInt(Row("conRusNum")))
                erType = ContentEnum.ContractRusRisk
                riskType = Cprp.DxData.Risk.TypeEnum.IsContractRus
            Case MK.IsContractNus
                If CBool(Row("isNotConNusRisk")) Then Return True
                erPlace = String.Format("Внешнеэкономическая сделка > Иностранные участники > Объект № {0} > Риски", C2.ToInt(Row("conNusNum")))
                erType = ContentEnum.ContractNusRisk
                riskType = Cprp.DxData.Risk.TypeEnum.IsContractNus
            Case MK.IsSupplyRus
                If CBool(Row("isNotSupRusRisk")) Then Return True
                erPlace = String.Format("Внешнеэкономическая операция > Российские участники > Объект № {0} > Риски", C2.ToInt(Row("supRusNum")))
                erType = ContentEnum.SupplyRusRisk
                riskType = Cprp.DxData.Risk.TypeEnum.IsSupplyRus
            Case MK.IsSupplyNus
                If CBool(Row("isNotSupNusRisk")) Then Return True
                erPlace = String.Format("Внешнеэкономическая операция > Иностранные покупатели (продавцы) > Объект № {0} > Риски", C2.ToInt(Row("supNusNum")))
                erType = ContentEnum.SupplyNusRisk
                riskType = Cprp.DxData.Risk.TypeEnum.IsSupplyNus
            Case MK.IsSupplyEnd
                If CBool(Row("isNotSupEndRisk")) Then Return True
                erPlace = String.Format("Внешнеэкономическая операция > Потребители (конечные пользователи) > Объект № {0} > Риски", C2.ToInt(Row("supEndNum")))
                erType = ContentEnum.SupplyEndRisk
                riskType = Cprp.DxData.Risk.TypeEnum.IsSupplyEnd
            Case Else
                Return False
        End Select
        '
        ' Проверка наличия рисков текущего объекта текущего вида в справочнике рисков
        '
        Using V As DataView = Work.MemberRiskTable.MemberView(Row("id"), Work.RiskHandbookTable.StrTypeId(riskType))
            For Each VRow As DataRowView In V
                If Not Work.RiskHandbookTable.Rows.Find(VRow("riskId")) Is Nothing Then Return True
            Next
        End Using
        '
        ' Риски не указаны
        '
        AddNew(Row("id"), "Не указано наличие или отсутствие рисков")
        Return False
    End Function

    ''' <summary>
    ''' Проверить наличие списка продукции
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckGoodList() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Продукция"
        erType = ContentEnum.GoodList
        erBool = (Work.GoodTable.Rows.Count > 0)
        If Not erBool Then AddNew(C2.EMPTY_ID, "Отсутствуют объекты экспертизы")
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить регистрационные данные объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodData(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        erPlace = String.Format("Продукция > Объект № {0} > Регистрационные данные", CInt(Row("rowNum")))
        erType = ContentEnum.GoodData
        erBool = True
        '
        ' Коммерческое наименование
        '
        If Not C2.IsText(Row("nameCon")) Then
            AddNew(Row("id"), "Не указано коммерческое наименование")
            erBool = False
        End If
        '
        ' Обозначение
        '
        If Not (C2.IsText(Row("nameDec")) OrElse CBool(Row("isNotDec"))) Then
            AddNew(Row("id"), "Не указано обозначение")
            erBool = False
        End If
        '
        ' Код ТН ВЭД
        '
        Dim tnved As String = C2.ToText(Row("tnved"))
        If C2.IsText(tnved) Then tnved = tnved.Replace("'", Nothing)
        If Not C2.IsText(tnved) Then
            AddNew(Row("id"), "Не указан код ТН ВЭД")
            erBool = False
        ElseIf tnved <> "-" Then
            If CInt(Work.ExecuteScalar(String.Format( _
                "SELECT COUNT(*) FROM tTnved WHERE code = '{0}' AND dateB <= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", tnved, Date.Today))) = 0 Then
                AddNew(Row("id"), "Код ТН ВЭД отсутствует в актуальной редакции товарной номенклатуры")
                erBool = False
            End If
        End If
        '
        ' Вид объекта
        '
        If IsDBNull(Row("typeId")) Then
            AddNew(Row("id"), "Не указан вид объекта")
            erBool = False
        Else
            If IsDBNull(Row("parentId")) Then
                Dim TRow As DataRow = Work.GoodTypeHandbookTable.Rows.Find(Row("typeId"))
                If Not TRow Is Nothing AndAlso CBool(TRow("isChild")) Then
                    AddNew(Row("id"), "Не указан объект, к которому применяется объект экспертизы")
                    erBool = False
                End If
            End If
        End If
        '
        ' Область применения
        '
        If Not (C2.IsText(Row("area")) OrElse C2.IsText(Work.ARow("goodArea"))) Then
            AddNew(Row("id"), "Не указана область применения")
            erBool = False
        End If
        '
        ' Назначение
        '
        If Not (C2.IsText(Row("used")) OrElse C2.IsText(Work.ARow("goodUsed"))) Then
            AddNew(Row("id"), "Не указано назначение")
            erBool = False
        End If
        '
        ' Техническое описание
        '
        If Not C2.IsText(Row("description")) Then
            AddNew(Row("id"), "Отсутствует техническое описание")
            erBool = False
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить запреты и ограничения объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodEmbargo(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        If IsDBNull(Work.ARow("countryId")) Then Return True ' Транзит в Калининград
        If CBool(Row("isNotEmbargo")) Then Return True
        erPlace = String.Format("Продукция > Объект № {0} > Запреты и ограничения", CInt(Row("rowNum")))
        erType = ContentEnum.GoodEmbargo
        '
        ' Проверка наличия запретов по стране назначения поставки
        '
        Using V As DataView = Work.EmbargoGoodHandbookTable.CountryView(Work.ARow("countryId"), CType(Work.ARow("modeId"), Cprp.DxData.ModeEnum), C2.ToText(Row("tnved")))
            If V.Count = 0 Then Return True
        End Using
        '
        ' Поиск объекта в справочнике запретов
        '
        Dim countryId As Integer = C2.ToInt(Work.ARow("countryId"))
        ' не учтена страна банка
        'Using V As DataView = Work.GoodEmbargoTable.GoodView(Row("id"))
        '    For Each VRow As DataRowView In V
        '        If Not Work.EmbargoGoodHandbookTable.Rows.Find(New Object() {VRow("embargoGoodId"), countryId}) Is Nothing Then Return True
        '    Next
        'End Using
        If Work.GoodEmbargoTable.GoodView(Row("id")).Count > 0 Then Return True
        '
        ' Запреты не указаны
        '
        AddNew(Row("id"), "Не указано наличие или отсутствие запретов и ограничений")
        Return False
    End Function

    ''' <summary>
    ''' Проверить запреты и ограничения объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodControl(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        If Not C2.IsText(Row("tnved")) Then Return False
        If CBool(Row("isNotControl")) Then Return True
        erPlace = String.Format("Продукция > Объект № {0} > На контроле", CInt(Row("rowNum")))
        erType = ContentEnum.GoodControl
        '
        ' Проверка наличия продукции на контроле с кодом ТН ВЭД объекта
        '
        Using V As New DataView(Work.ControlGoodHandbookTable)
            V.RowFilter = String.Format("(goodTnved LIKE '{0}%') OR ('{0}' LIKE (goodTnved + '%'))", C2.ToText(Row("tnved")))
            If V.Count = 0 Then Return True
        End Using
        '
        ' Поиск объекта в справочнике продукции на контроле
        '
        Using V As DataView = Work.GoodControlTable.GoodView(Row("id"))
            For Each VRow As DataRowView In V
                If Not Work.ControlGoodHandbookTable.Rows.Find(VRow("controlGoodId")) Is Nothing Then Return True
            Next
        End Using
        '
        ' Продукция на контроле не указана
        '
        AddNew(Row("id"), "Не указано наличие или отсутствие соответствия продукции контроле")
        Return False
    End Function

    ''' <summary>
    ''' Проверить исследование по контрольным спискам объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodLaw(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        erPlace = String.Format("Продукция > Объект № {0} > Контрольные списки", CInt(Row("rowNum")))
        erType = ContentEnum.GoodLaw
        erBool = Not IsDBNull(Row("studyDate"))
        If Not erBool Then AddNew(Row("id"), "Отсутствует исследование по контрольным спискам")
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить сравнительный анализ объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodSummary(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        If IsDBNull(Row("studyDate")) Then Return False
        erPlace = String.Format("Продукция > Объект № {0} > Сравнительный анализ", CInt(Row("rowNum")))
        erType = ContentEnum.GoodSummary
        erBool = True
        '
        ' Проверка наличия ПУНКТОВ КОНТРОЛЬНЫХ СПИСКОВ, выявленных по текущему объекту и не имеющих сравнительного анализа с ним
        '
        Dim Row1 As DataRow = Nothing
        Using V As DataView = Work.GoodLawTable.GoodView(Row("id"))
            '
            ' Если есть обобщенные анализ выявленных пунктов, надо проверить только пункты, выбранные для сравнения
            '
            If C2.IsText(Row("studySummary")) Then
                V.RowFilter = String.Format("{0} AND summaryId > {1}", V.RowFilter, CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing))
            End If
            '
            ' Поиск ПУНКТОВ КОНТРОЛЬНЫХ СПИСКОВ без сравнительного анализа
            '
            For Each VRow As DataRowView In V
                If C2.IsText(VRow("goodDescription")) Then Continue For
                Row1 = Work.LawDataSet.LawTable.Rows.Find(VRow("lawId"))
                If Row1 Is Nothing Then Continue For
                If CType(Row1("areaId"), Cprp.DxData.AreaEnum) <> Cprp.DxData.AreaEnum.isExcont Then Continue For
                If CType(Row1("typeId"), Cprp.DxData.Law.TypeEnum) <> Cprp.DxData.Law.TypeEnum.IsParagraph Then Continue For
                erBool = False
                Exit For
            Next
        End Using
        '
        ' Есть пункты контрольных списков без сравнительного анализа с текущим объектом
        '
        If Not erBool Then AddNew(Row("id"), "Сравнительный анализ с пунктами контрольных списков не завершен")
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить риски объекта экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodRisk(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        If CBool(Row("isNotRisk")) OrElse C2.IsText(Row("otherRisk")) Then Return True
        erPlace = String.Format("Продукция > Объект № {0} > Риски", CInt(Row("rowNum")))
        erType = ContentEnum.GoodRisk
        '
        ' Проверка наличия рисков текущего объекта в справочнике рисков
        '
        Using V As DataView = Work.GoodRiskTable.GoodView(Row("id"))
            For Each VRow As DataRowView In V
                If Not Work.RiskHandbookTable.Rows.Find(VRow("riskId")) Is Nothing Then Return True
            Next
        End Using
        '
        ' Риски не указаны
        '
        AddNew(Row("id"), "Не указано наличие или отсутствие рисков")
        Return False
    End Function

    ''' <summary>
    ''' Проверить сведения о результатах анализа
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckSummary() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Решение по анализу"
        erType = ContentEnum.Summary
        erBool = True
        '
        ' Проверка наличия выводов экспертизы
        '
        If Not C2.IsText(Work.ARow("summaryText")) Then
            AddNew(C2.EMPTY_ID, "Отсутствуют выводы экспертизы")
            Return False
        End If
        '
        ' Наличие в поставке контролируемых товаров
        '
        Dim bEqual As Boolean = False
        Using V As New DataView(Work.GoodTable)
            V.RowFilter = String.Format("isUnreal = False AND studySummaryId = {0}", CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
            bEqual = (V.Count > 0)
        End Using
        '
        ' Наличие запретов в отношении участников или товаров
        '
        Dim bEmbargo As Boolean = (Work.MemberEmbargoTable.Rows.Count > 0 OrElse Work.GoodEmbargoTable.Rows.Count > 0)
        '
        ' Проверка результатов анализа
        '
        Select Case CType(Work.ARow("summaryId"), Cprp.DxData.Work.WorkSummary)
            Case Cprp.DxData.Work.WorkSummary.IsFreedom
                If bEqual OrElse bEmbargo Then
                    AddNew(C2.EMPTY_ID, "Выводы экспертизы не соответствуют контрольному статусу объектов экспертизы")
                    erBool = False
                End If
            Case Cprp.DxData.Work.WorkSummary.IsLicense
                If Not bEqual OrElse bEmbargo Then
                    AddNew(C2.EMPTY_ID, "Выводы экспертизы не соответствуют контрольному статусу объектов экспертизы")
                    erBool = False
                End If
            Case Cprp.DxData.Work.WorkSummary.IsPermit
                If Not C2.IsText(Work.ARow("summaryRisk")) Then
                    AddNew(C2.EMPTY_ID, "Отсутствует анализ выявленных рисков")
                    erBool = False
                End If
            Case Cprp.DxData.Work.WorkSummary.IsEmbargo
                If Not bEmbargo Then
                    AddNew(C2.EMPTY_ID, "Выводы экспертизы не соответствуют контрольному статусу объектов экспертизы")
                    erBool = False
                ElseIf Not C2.IsText(Work.ARow("summaryText")) Then
                    AddNew(C2.EMPTY_ID, "Отсутствуют выводы экспертизы")
                    erBool = False
                End If
            Case Cprp.DxData.Work.WorkSummary.IsOutput
                If Not bEqual OrElse bEmbargo Then
                    AddNew(C2.EMPTY_ID, "Выводы экспертизы не соответствуют контрольному статусу объектов экспертизы")
                    erBool = False
                End If
                If Not C2.IsText(Work.ARow("summaryText")) Then
                    AddNew(C2.EMPTY_ID, "Отсутствуют выводы экспертизы")
                    erBool = False
                End If
            Case Cprp.DxData.Work.WorkSummary.IsDecree
                If Not C2.IsText(Work.ARow("summaryText")) Then
                    AddNew(C2.EMPTY_ID, "Отсутствуют выводы экспертизы")
                    erBool = False
                End If
        End Select
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить сведения о дополнительной информации
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckExtraInfo() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Дополнительная информация"
        erType = ContentEnum.ExtraInfo
        erBool = True
        If CType(Work("kindId"), Cprp.DxData.Work.WorkKind) <> WorkKind.IsPrimary AndAlso Not C2.IsText(Work.ARow("kindComment")) Then
            AddNew(C2.EMPTY_ID, "Отсутствует комментарий к характеристике экспертизы")
            erBool = False
        End If
        If Not IsDBNull(Work.ARow("docTerm")) Then
            If CDate(Work.ARow("docTerm")) < Date.Today.AddDays(1) Then
                AddNew(C2.EMPTY_ID, "Некорректный срок действия заключения экспертизы")
                erBool = False
            End If
        Else
            Using V As New DataView(Work.GoodTable)
                V.RowFilter = String.Format("studySummaryId <> {0}", CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
                If V.Count > 0 Then
                    AddNew(C2.EMPTY_ID, "Необходимо указать срок действия заключения экспертизы")
                    erBool = False
                End If
            End Using
        End If
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить сведения о представленных документах
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckExtraDoc() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Сведения о работе > Перечень документов"
        erType = ContentEnum.ExtraDoc
        erBool = True
        Using V As DataView = Work.InDocTable.UsedView
            V.Sort = "rowNum"
            If V.Count = 0 Then
                AddNew(C2.EMPTY_ID, "Отсутствуют документы, использованные при проведении экспертизы")
                Return False
            End If
            For i As Integer = 0 To V.Count - 1
                If Not C2.IsText(V(i)("caption")) Then
                    erPlace = String.Format("Сведения о работе > Перечень документов > Объект № {0}", CInt(V(i)("rowNum")))
                    AddNew(C2.EMPTY_ID, "Не указано наименование или краткое содержание документа")
                    erBool = False
                End If
            Next
            If Not CBool(Work.ARow("isDocRule")) Then
                erPlace = "Сведения о работе > Перечень документов"
                AddNew(C2.EMPTY_ID, "Не подтверждена правоспособность представленных документов")
                erBool = False
            End If
        End Using
        Return erBool
    End Function

End Class
