Imports C2 = Cprp.DxData.Common
''' <summary>
''' Базовый класс - Работа
''' </summary>
Public MustInherit Class WorkConnectionRow : Inherits Cprp.DxData.Base.ConnectionDataRow

    ''' <summary>
    ''' Дополнительные данные работы
    ''' </summary>
    Public ARow As AdditionalDataRow = Nothing

    ''' <summary>
    ''' План работы
    ''' </summary>
    Public PlaneTable As PlaneDataTable = Nothing

    ''' <summary>
    ''' Представленные документы
    ''' </summary>
    Public InDocTable As InDocDataTable = Nothing

    ''' <summary>
    ''' Запросы
    ''' </summary>
    Public RequestTable As RequestDataTable = Nothing

    ''' <summary>
    ''' Внутренние документы
    ''' </summary>
    Public InternalTable As InternalDataTable = Nothing

    ''' <summary>
    ''' Комментарии к работе
    ''' </summary>
    Public WorkCommentTable As WorkCommentDataTable = Nothing


    ''' <summary>
    ''' Источник данных работы
    ''' </summary>
    Public DS As DataSet = Nothing

    ''' <summary>
    ''' Временная папка с файлами входящих документов работы
    ''' </summary>
    Public TmpFolderPath As String = Nothing

    ''' <summary>
    ''' Калькулятор стоимости работы
    ''' </summary>
    Protected Calc As Cprp.DxData.Calc.Calc = Nothing

    ''' <summary>
    ''' Таблица расчета стоимости работы
    ''' </summary>
    Public ReadOnly Property CalcTable As Cprp.DxData.Calc.CalcDataTable
        Get
            Return Calc.CalcTable
        End Get
    End Property


    ''' <summary>
    ''' Шаблон строки запроса на выборку данных работы
    ''' </summary>
    Protected Const SELECT_QUERY_STRING As String = _
        "SELECT id, pId, parentId, guid, typeId, kindId, conditionId, expertId, managerId, leaderId, expertTerm, " & _
        "orderId, siteOrderId, CrmOrderId, orderNum, orderDate, orderUrl, orderTerm, taskId, taskUrl, " & _
        "clientName, clientAddress, clientInn, clientKpp, clientPhone, clientFax, " & _
        "description, countryName, isPayment, isPrice, isActExist, goodCount, goodAllCount, percentCount,  " & _
        "createDate, acceptDate, closeDate, totalWork, extraWork, price, ballCalc, ballFact, comment, " & _
        "isAsk, isAskSign, isAskSend, isPostal, isManualDocument, isStop, isInt, licConditionId, urgencyId, paymentDate, agreementNum  " & _
        "FROM tWork WHERE id IS NULL"


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.WorkConnectionRow
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        '
        ' Me
        '
        MyBase.New(Connection.ConnectionString)
        With Me.Columns
            ' Поля таблицы tWork
            .Add("id", GetType(Integer))                ' ID
            .Add("pId", GetType(Integer))               ' ID заявки
            .Add("parentId", GetType(Integer))          ' ID первичной работы при внесении изменений
            .Add("guid", GetType(String))               ' GUID
            .Add("typeId", GetType(Integer))            ' ID вида работы
            .Add("kindId", GetType(Integer))            ' ID характеристики экспертизы
            .Add("conditionId", GetType(Integer))       ' ID состояния работы
            .Add("expertId", GetType(Integer))          ' ID эксперта
            .Add("managerId", GetType(Integer))         ' ID менеджера
            .Add("leaderId", GetType(Integer))          ' ID руководителя
            .Add("expertTerm", GetType(Date))           ' Срок сдачи работы экспертом
            .Add("orderId", GetType(Integer))           ' ID заказа в ЭО
            .Add("siteOrderId", GetType(Integer))       ' ID заказа на сайте
            .Add("CrmOrderId", GetType(String))         ' ID заказа в CRM
            .Add("orderNum", GetType(String))           ' Номер заказа
            .Add("orderDate", GetType(Date))            ' Дата заказа
            .Add("orderUrl", GetType(String))           ' URL карточки заказа в ЭО
            .Add("orderTerm", GetType(Date))            ' Срок выдачи заказа
            .Add("taskId", GetType(Integer))            ' ID поручения эксперту в ЭО
            .Add("taskUrl", GetType(String))            ' URL карточки поручения в ЭО
            .Add("clientName", GetType(String))         ' Наименование заказчика
            .Add("clientAddress", GetType(String))      ' Адрес заказчика
            .Add("clientInn", GetType(String))          ' ИНН заказчика
            .Add("clientKpp", GetType(String))          ' КПП заказчика
            .Add("clientPhone", GetType(String))        ' Телефон заказчика
            .Add("clientFax", GetType(String))          ' Факс заказчика
            .Add("description", GetType(String))        ' Сведения о работе
            .Add("countryName", GetType(String))        ' Страна назначения
            .Add("isPayment", GetType(Boolean))         ' Работа оплачена (да/нет)
            .Add("isPrice", GetType(Boolean))           ' Счет подписан (да/нет)
            .Add("isActExist", GetType(Boolean))        ' Акт выписан (да/нет)
            .Add("goodCount", GetType(Integer))         ' Количество однородных товаров
            .Add("goodAllCount", GetType(Integer))      ' Количество товаров
            .Add("percentCount", GetType(Integer))      ' Процент выполнения работы
            .Add("createDate", GetType(Date))           ' Дата создания работы
            .Add("acceptDate", GetType(Date))           ' Дата утверждения работы
            .Add("closeDate", GetType(Date))            ' Дата закрытия работы
            .Add("totalWork", GetType(Integer))         ' Общая трудоемкость (мин.)
            .Add("extraWork", GetType(Integer))         ' Дополнительные работы (мин.)
            .Add("price", GetType(Single))              ' Стоимость работы
            .Add("ballCalc", GetType(Single))           ' Расчетное количество баллов за работу
            .Add("ballFact", GetType(Single))           ' Фактическое количество баллов за работу
            .Add("comment", GetType(String))            ' Комментарий к заказу
            .Add("isAsk", GetType(Boolean))             ' Есть запрос на утверждении
            .Add("isAskSign", GetType(Boolean))         ' Есть запрос на подписании
            .Add("isAskSend", GetType(Boolean))         ' Есть отправленный запрос, по которому ожидается ответ
            .Add("isPostal", GetType(Boolean))          ' Почтовая доставка итоговых документов
            .Add("isManualDocument", GetType(Boolean))  ' Ручная обработка документов по заявке
            .Add("isStop", GetType(Boolean))            ' Работа приостановлена
            .Add("licConditionId", GetType(Integer))    ' Состояние работы по подготовке лицензии
            .Add("isInt", GetType(Boolean))             ' Есть внутренний на утверждении
            .Add("isComplex", GetType(Boolean))         ' Признак применения нового механизма обмена ЭО-ЭС
            .Add("urgencyId", GetType(UrgencyType))     ' Признак срочности
            .Add("paymentDate", GetType(Date))          ' Дата оплаты работы
            .Add("agreementNum", GetType(String))       ' Номер договора
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("typeId")
            .AllowDBNull = False
            .DefaultValue = WorkType.IsExCont           ' Идентификационная экспертиза по экспортному контролю
        End With
        With Me.Columns("kindId")
            .AllowDBNull = False
            .DefaultValue = WorkKind.IsPrimary          ' Первичная
        End With
        With Me.Columns("conditionId")
            .AllowDBNull = False
            .DefaultValue = WorkCondition.IsNew         ' Новая
        End With
        With Me.Columns("isPayment")
            .AllowDBNull = False
            .DefaultValue = False                       ' Не оплачена
        End With
        With Me.Columns("isPrice")
            .AllowDBNull = False
            .DefaultValue = False                       ' Счет не подписан
        End With
        With Me.Columns("ballCalc")
            .AllowDBNull = False
            .DefaultValue = 0                           ' 0 баллов
        End With
        With Me.Columns("ballFact")
            .AllowDBNull = False
            .DefaultValue = 0                           ' 0 баллов
        End With
        With Me.Columns("isAsk")
            .AllowDBNull = False
            .DefaultValue = False                       ' Нет запросов на утверждении
        End With
        With Me.Columns("isAskSign")
            .AllowDBNull = False
            .DefaultValue = False                       ' Нет запросов на подписании
        End With
        With Me.Columns("isAskSend")
            .AllowDBNull = False
            .DefaultValue = False                       ' Нет запросов с ожиданием ответа
        End With
        With Me.Columns("isPostal")
            .AllowDBNull = False
            .DefaultValue = False                       ' Доставка итоговых документов по электронным каналам связи
        End With
        With Me.Columns("isManualDocument")
            .AllowDBNull = False
            .DefaultValue = False                       ' Автоматическая обработка документов по заявке
        End With
        With Me.Columns("isInt")
            .AllowDBNull = False
            .DefaultValue = False                       ' Нет внутренних документов на утверждении
        End With
        With Me.Columns("urgencyId")
            .AllowDBNull = False
            .DefaultValue = UrgencyType.IsNone          ' Без срочности
        End With
        Me.Columns("guid").MaxLength = 50
        Me.Columns("orderNum").MaxLength = 50
        Me.Columns("orderUrl").MaxLength = 1000
        Me.Columns("taskUrl").MaxLength = 1000
        Me.Columns("clientName").MaxLength = 500
        Me.Columns("clientAddress").MaxLength = 500
        Me.Columns("clientInn").MaxLength = 20
        Me.Columns("clientKpp").MaxLength = 20
        Me.Columns("clientPhone").MaxLength = 250
        Me.Columns("clientFax").MaxLength = 250
        Me.Columns("description").MaxLength = 250
        Me.Columns("countryName").MaxLength = 150
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' Arow, PlaneTable, InDocTable, RequestTable, InternalTable, WorkCommentTable
        '
        ARow = New AdditionalDataRow
        PlaneTable = New PlaneDataTable
        InDocTable = New InDocDataTable(Me)
        RequestTable = New RequestDataTable
        InternalTable = New InternalDataTable
        WorkCommentTable = New WorkCommentDataTable(Me)
        '
        ' Calc
        '
        Calc = New Cprp.DxData.Calc.Calc(Me.Connection)
        '
        ' DS
        '
        DS = New DataSet("WorkData")
        DS.Tables.AddRange(New DataTable() {ARow, PlaneTable, InDocTable, RequestTable, InternalTable, WorkCommentTable, Calc.CalcTable})

    End Sub


    ''' <summary>
    ''' Путь к папке с файлами работ
    ''' </summary>
    Private Shared workFolderPath As String = Nothing

    ''' <summary>
    ''' Возвращает путь к файлу работы
    ''' </summary>
    ''' <param name="workId">ID работы</param> 
    Public Function GetWorkFilePath(workId As Object) As String
        Dim id As Integer = C2.ToInt(workId)
        If id < 0 Then Return Nothing
        If workFolderPath Is Nothing Then
            workFolderPath = C2.ToText(Cprp.DxData.Resource.Resource.GetStrData("WORKFOLDERPATH", MyBase.Connection))
        End If
        If String.IsNullOrWhiteSpace(workFolderPath) OrElse Not My.Computer.FileSystem.DirectoryExists(workFolderPath) Then
            Return Nothing
        End If
        Dim fPath As String = String.Format("{0}\{1}.work", workFolderPath, id)
        ' Поиск файла в оперативном хранилище
        If My.Computer.FileSystem.FileExists(fPath) Then Return fPath
        ' Поиск файла в архивном хранилище
        Dim i As Integer = 1000
        Do
            If i >= id Then Exit Do
            i += 1000
        Loop
        fPath = String.Format("{0}\{1}\{2}.work", workFolderPath, i, id)
        If My.Computer.FileSystem.FileExists(fPath) Then Return fPath
        ' Путь в оперативное хранилище для первого сохранения нового файла
        Return String.Format("{0}\{1}.work", workFolderPath, id)
    End Function

    ''' <summary>
    ''' ID работы
    ''' </summary>
    Public Overridable Property Id As Object
        Get
            If MyBase.IsEmpty OrElse MyBase.IsNew Then Return Nothing
            Return MyBase.Item("id")
        End Get
        Set(ByVal value As Object)
            '
            ' Загрузка данных из базы данных
            '
            MyBase.Load(String.Format(SELECT_QUERY_STRING.Replace("id IS NULL", "id = {0}"), C2.ToInt(value)))
            If Not MyClass.IsEmpty AndAlso IsDBNull(Me("guid")) Then Me("guid") = System.Guid.NewGuid.ToString           
            '
            ' Загрузка данных из файла работы
            '
            DS.Clear()
            If MyClass.IsEmpty Then
                DS.AcceptChanges()
                Exit Property
            End If
            Dim sTmp As String = GetWorkFilePath(MyClass.Id)
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso My.Computer.FileSystem.FileExists(sTmp) Then
                For Each T As DataTable In DS.Tables
                    T.BeginLoadData()
                Next
                DS.ReadXml(sTmp, XmlReadMode.IgnoreSchema)
                For Each T As DataTable In DS.Tables
                    T.EndLoadData()
                Next
            End If
            If ARow.IsEmpty Then
                ARow.Rows.Add(ARow.NewRow)
                ARow("typeId") = Me("typeId")
                ARow("totalWork") = 120
            End If
            If PlaneTable.IsEmpty Then PlaneTable.DataInit()
            '
            ' Загрузка комментариев
            '            
            If Not MyBase.IsEmpty Then
                With WorkCommentTable
                    .DataLoad()
                    ' Добавление начального комментария
                    If .Rows.Count = 0 Then
                        Dim comment As String = C2.ToText(Me("comment"))
                        If Not String.IsNullOrWhiteSpace(comment) Then .AddComment(CDate(Me("createDate")), 1, comment)
                    End If
                End With
            End If            
            '
            ' Загрузка данных из файла взаимодействия с ЭО
            '
            InDocTable.LoadFromEO()
            '
            ' Заполнение пустых полей InDocTable
            '
            For Each Row As DataRow In Me.InDocTable.Rows
                If IsDBNull(Row("typeId")) Then Row("typeId") = 0 ' неизвестный тип
                If IsDBNull(Row("kindId")) Then Row("kindId") = 1 ' входящий документ
            Next
            '
            ' Сохранение изменений в DS
            '
            DS.AcceptChanges()
            '
            ' Временная папка с файлами документов работы
            '
            With My.Computer.FileSystem
                TmpFolderPath = String.Format("{0}\{1}", .SpecialDirectories.Temp, C2.ToInt(value))
                If Not .DirectoryExists(TmpFolderPath) Then .CreateDirectory(TmpFolderPath)
            End With

        End Set
    End Property

    ''' <summary>
    ''' Сохранить данные в базу и файл данных
    ''' </summary>
    Public Overridable Sub DataSave()
        If MyBase.IsEmpty Then Exit Sub
        ' признак добавленной строки
        Dim bNew As Boolean = (Me.Rows(0).RowState = DataRowState.Added)
        If IsDBNull(Me("guid")) Then Me("guid") = System.Guid.NewGuid.ToString
        '
        ' Сохранение работы в базу данных
        '
        Using A As New SqlDataAdapter(SELECT_QUERY_STRING, MyBase.Connection)
            ' Перезаписывать конкурирующие изменения
            Dim B As New SqlCommandBuilder(A) With {.ConflictOption = ConflictOption.OverwriteChanges}
            Try
1:              A.Update(Me)
            Catch ex As DBConcurrencyException When ex.Row.RowState = DataRowState.Deleted
                ex.Row.AcceptChanges()
                GoTo 1
            Catch ex1 As Exception
                Throw ex1
            End Try
        End Using
        '
        ' Обновление id для добавленной строки
        '
        If bNew Then
            Dim newId As Integer = CInt(Me.ExecuteScalar("SELECT @@IDENTITY"))
            MyBase.Load(String.Format(SELECT_QUERY_STRING.Replace("id IS NULL", "id = {0}"), newId))
        End If
        '
        ' Сохранение источника данных в файл работы
        '
        Dim sTmp As String = GetWorkFilePath(MyClass.Id)
        If Not String.IsNullOrWhiteSpace(sTmp) Then
            Me.ARow("saveDate") = Date.Now
            DS.AcceptChanges()
            DS.WriteXml(sTmp, XmlWriteMode.WriteSchema)
        End If
        '
        ' Обновление данных по документам в таблице взаимодействия с ЭО
        '
        InDocTable.SaveToEO()
    End Sub

    ''' <summary>
    ''' Удалить временную папку с документами работы
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteTmpFolder()
        If String.IsNullOrWhiteSpace(TmpFolderPath) Then Exit Sub
        Try
            With My.Computer.FileSystem
                If .DirectoryExists(TmpFolderPath) Then .DeleteDirectory(TmpFolderPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End With
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    ''' <summary>
    ''' Состояние работы
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Property Condition As WorkCondition
        Get
            If MyBase.IsEmpty Then Return WorkCondition.IsEmpty
            Return CType(Me("conditionId"), WorkCondition)
        End Get
        Set(ByVal value As WorkCondition)
            If value = WorkCondition.IsEmpty Then Exit Property
            If Me.IsEmpty Then Exit Property
            Me("conditionId") = CInt(value)
        End Set
    End Property

    ''' <summary>
    ''' Вид работы
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Type As WorkType
        Get
            If MyBase.IsEmpty Then Return WorkType.IsEmpty
            Return CType(Me("typeId"), WorkType)
        End Get
    End Property

    ''' <summary>
    ''' Запись в историю работы без плановой даты события
    ''' </summary>
    ''' <param name="eventId">Идентификатор события</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <remarks></remarks>
    Public Sub WriteHistory(eventId As WorkEvent, comment As String)
        Common.WriteHistory(Me.Id, eventId, comment, Me.Connection)
    End Sub

    ''' <summary>
    ''' Запись в историю работы с плановой датой события
    ''' </summary>
    ''' <param name="eventId">Идентификатор события</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <param name="planeDate">Плановая дата события</param>
    ''' <remarks></remarks>
    Public Sub WriteHistory(eventId As WorkEvent, comment As String, planeDate As Date)
        Common.WriteHistory(Me.Id, eventId, comment, planeDate, Me.Connection)
    End Sub

    ''' <summary>
    ''' Данные изменились после последнего сохранения
    ''' </summary>
    Public ReadOnly Property IsChangedAfterSave As Boolean
        Get
            If IsDBNull(ARow("changeDate")) Then Return False
            If IsDBNull(ARow("saveDate")) Then Return True
            Return (CDate(ARow("changeDate")) > CDate(ARow("saveDate")))
        End Get
    End Property

    ''' <summary>
    ''' Данные изменились после последнего создания проектов итоговых документов
    ''' </summary>
    Public ReadOnly Property isChangedAfterProject As Boolean
        Get
            If IsDBNull(ARow("changeDate")) Then Return False
            If IsDBNull(ARow("projectDate")) Then Return False
            Return (CDate(ARow("changeDate")) > CDate(ARow("projectDate")))
        End Get
    End Property

    ''' <summary>
    ''' Остановить выполнение работы
    ''' </summary>
    Public Function WorkStop() As Boolean
        Return Common.WorkStop(Me.Id, Me.Connection)
    End Function

    ''' <summary>
    ''' Возобновить выполнение работы
    ''' </summary>
    Public Function WorkStart() As Boolean
        Return Common.WorkStart(Me.Id, Me.Connection)
    End Function

    ''' <summary>
    ''' Пересчитать стоимость работы
    ''' </summary>
    Public Overridable Sub ReCalc()
        Dim serviceId As Integer = 0
        Dim orderNum As String = C2.ToText(Me("orderNum"))
        Dim materialCount As Integer = C2.ToInt(Me.ARow("matCount"))
        Dim informationCount As Integer = C2.ToInt(Me.ARow("infCount"))
        Dim goodCount As Integer = C2.ToInt(Me.ARow("goodCount"))
        Dim addCountryCount As Integer = C2.ToInt(Me.ARow("addWorkCount"))
        Dim languageCount As Integer = C2.ToInt(Me.ARow("langCount"))
        Dim hourCount As Integer = Math.Ceiling(C2.ToInt(Me.ARow("totalWork")) / 60)
        Dim oldPrice As Single = 0
        Dim isUrgency As Boolean = CBool(Me("isUrgency"))
        Dim urgencyId As Integer = CInt(Me("urgencyId"))
        If Me.Condition = WorkCondition.IsPlaneWork OrElse Me.Condition = WorkCondition.IsPlaneAgree Then
            isUrgency = CBool(Me.ARow("isUrgency"))
            urgencyId = CInt(Me.ARow("urgencyId"))
        End If
        Dim complexity As Single = CSng(Me.ARow("complexity"))
        Dim price As Single = 0
        CalcTable.Rows.Clear()
        '
        ' Основная услуга
        '
        Dim Row As DataRow = CalcTable.NewRow
        Dim changeSourceId As Integer = C2.ToInt(Me.ARow("changeSourceId"))
        Select Case changeSourceId
            Case 1, 3
                '
                ' Внесение изменений по инициативе заказчика
                ' Продление срока действия заключения
                '
                serviceId = If(changeSourceId = 1, _
                               CInt(Cprp.DxData.Calc.ServiceType.ExtraDocReissue),
                               CInt(Cprp.DxData.Calc.ServiceType.ExtraDocLess))
                '
                ' Определение стоимости первичной работы
                '
                oldPrice = 0
                Dim iTmp As Integer = C2.ToInt(Me("parentId"))  ' номер певичной работы
                If iTmp > 0 Then
                    oldPrice = C2.ToSng(Me.ExecuteScalar(String.Format("SELECT ISNULL(price, 0) FROM tWork WHERE id = {0}", iTmp)))
                    '
                    ' Проверка, что для внесения изменений первичное заключение выполнялось не ранее одного месяца назад
                    '
                    If serviceId = CInt(Cprp.DxData.Calc.ServiceType.ExtraDocReissue) Then
                        If C2.ToInt(Me.ExecuteScalar(String.Format( _
                            "SELECT COUNT(*) FROM tWorkDoc WHERE workId = {0} AND regDate > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", iTmp, Date.Today.AddMonths(-1)))) = 0 Then
                            ' отрицательная стоимость - признак, что не надо делить стоимость первичного заключения / 2
                            oldPrice *= -1
                        End If
                    End If
                End If
                If oldPrice = 0 Then serviceId = CInt(Cprp.DxData.Calc.ServiceType.IsEmpty)
            Case 2
                '
                ' Исправление ошибки в ранее выпущенном заключении
                '
                serviceId = CInt(Cprp.DxData.Calc.ServiceType.ExtraDocCorrection)
            Case Else
                '
                ' Первичные работы
                '
                Select Case CType(Me.ARow("typeId"), WorkType)
                    Case WorkType.IsConsultation : serviceId = CInt(Cprp.DxData.Calc.ServiceType.ConsVed)
                    Case WorkType.IsCustomUnion : serviceId = CInt(Cprp.DxData.Calc.ServiceType.ExpertCustoms)
                    Case WorkType.IsExCont : serviceId = CInt(Cprp.DxData.Calc.ServiceType.ExpertExcont)
                    Case WorkType.IsLicense : serviceId = CInt(Cprp.DxData.Calc.ServiceType.FstekLicense)
                    Case WorkType.IsLiconfirm : serviceId = CInt(Cprp.DxData.Calc.ServiceType.ExpertLicConfirm)
                    Case WorkType.IsMilitary : serviceId = CInt(Cprp.DxData.Calc.ServiceType.ExpertMilitary)
                    Case WorkType.IsTnved : serviceId = CInt(Cprp.DxData.Calc.ServiceType.ConsTnved)
                    Case Else
                        serviceId = CInt(Cprp.DxData.Calc.ServiceType.IsEmpty)
                End Select
        End Select
        Row("serviceId") = serviceId
        Row("orderNum") = C2.DbText(orderNum)
        Row("materialCount") = materialCount
        Row("informationCount") = informationCount
        Row("goodCount") = goodCount
        Row("addCountryCount") = addCountryCount
        Row("languageCount") = languageCount
        Row("hourCount") = hourCount
        Row("oldPrice") = oldPrice
        Row("isUrgency") = isUrgency
        Row("urgencyId") = urgencyId
        Row("complexity") = complexity
        CalcTable.Rows.Add(Row)
        '
        ' Дополнительные услуги
        '
        If serviceId <> CInt(Cprp.DxData.Calc.ServiceType.ExtraDocCorrection) AndAlso _
            serviceId <> CInt(Cprp.DxData.Calc.ServiceType.ExtraDocAdditional) AndAlso _
            serviceId <> CInt(Cprp.DxData.Calc.ServiceType.ExtraDocReissue) AndAlso _
            serviceId <> CInt(Cprp.DxData.Calc.ServiceType.ExtraDocLess) Then
            If addCountryCount > 0 Then
                Row = CalcTable.NewRow
                Row("serviceId") = CInt(Cprp.DxData.Calc.ServiceType.ExtraFewDoc)
                Row("orderNum") = C2.DbText(orderNum)
                Row("materialCount") = materialCount
                Row("informationCount") = informationCount
                Row("goodCount") = goodCount
                Row("addCountryCount") = addCountryCount
                Row("languageCount") = languageCount
                Row("hourCount") = hourCount
                Row("oldPrice") = oldPrice
                Row("isUrgency") = isUrgency
                CalcTable.Rows.Add(Row)
            End If
            If languageCount > 0 Then
                Row = CalcTable.NewRow
                Row("serviceId") = CInt(Cprp.DxData.Calc.ServiceType.ExtraLanguage)
                Row("orderNum") = C2.DbText(orderNum)
                Row("materialCount") = materialCount
                Row("informationCount") = informationCount
                Row("goodCount") = goodCount
                Row("addCountryCount") = addCountryCount
                Row("languageCount") = languageCount
                Row("hourCount") = hourCount
                Row("oldPrice") = oldPrice
                Row("isUrgency") = isUrgency
                CalcTable.Rows.Add(Row)
            End If
            If Not IsDBNull(Me("isManualDocument")) AndAlso CBool(Me("isManualDocument")) Then
                Row = CalcTable.NewRow
                Row("serviceId") = CInt(Cprp.DxData.Calc.ServiceType.ExtraManual)
                Row("orderNum") = C2.DbText(orderNum)
                Row("materialCount") = materialCount
                Row("informationCount") = informationCount
                Row("goodCount") = goodCount
                Row("addCountryCount") = addCountryCount
                Row("languageCount") = languageCount
                Row("hourCount") = hourCount
                Row("oldPrice") = oldPrice
                Row("isUrgency") = isUrgency
                CalcTable.Rows.Add(Row)
            End If
            If Not IsDBNull(Me("isPostal")) AndAlso CBool(Me("isPostal")) Then
                Row = CalcTable.NewRow
                Row("serviceId") = CInt(Cprp.DxData.Calc.ServiceType.ExtraPostal)
                Row("orderNum") = C2.DbText(orderNum)
                Row("materialCount") = materialCount
                Row("informationCount") = informationCount
                Row("goodCount") = goodCount
                Row("addCountryCount") = addCountryCount
                Row("languageCount") = languageCount
                Row("hourCount") = hourCount
                Row("oldPrice") = oldPrice
                Row("isUrgency") = isUrgency
                CalcTable.Rows.Add(Row)
            End If
        End If
        '
        ' Стоимость работы
        '
        Me.Calc.ReCalc(CInt(Me.ARow("changeSourceId")) = 4)
        Dim priceG As Single = 0    ' стоимость по товарам
        For Each Row In CalcTable.Rows
            Row("expertTerm") = Me("expertTerm")
            If IsDBNull(Row("price")) Then Continue For
            price += CSng(Row("price"))
            If IsDBNull(Row("priceG")) Then
                priceG += CSng(Row("price"))
            Else
                priceG += CSng(Row("priceG"))
            End If
        Next
        Me("price") = price
        Me.ARow("priceG") = priceG
    End Sub

    ''' <summary>
    ''' Срочность работы
    ''' </summary>
    Public Property Urgency As UrgencyType
        Get
            Return CType(Me("urgencyId"), UrgencyType)
        End Get
        Set(value As UrgencyType)
            Me("urgencyId") = value            
            Me("isUrgency") = (Me.Urgency <> UrgencyType.IsNone)
        End Set
    End Property

    ''' <summary>
    ''' Обновить срок выдачи работы
    ''' </summary>
    Public Sub UpdateOrderTerm()
        ' Внесение изменений по нашей вине
        If CInt(Me.ARow("changeSourceId")) = 2 Then
            Me("orderTerm") = Me("expertTerm")
            Me("paymentDate") = Me("createDate")
            Me("price") = 0
            Me("isPayment") = True
            Exit Sub
        End If

        ' Бесплатная работа
        If CInt(Me.ARow("changeSourceId")) = 4 OrElse (Not IsDBNull(Me("price")) AndAlso CInt(Me("price")) = 0) Then
            Me("paymentDate") = Me("createDate")
            Me("price") = 0
            Me("isPayment") = True
        End If

        ' Работа по договору
        If Not IsDBNull(Me("agreementNum")) Then
            Me("paymentDate") = Me("createDate")
            Me("isPayment") = True
        End If

        ' Расчет срока выдачи
        If IsDBNull(Me("paymentDate")) OrElse CDate(Me("paymentDate")) = Nothing Then
            Me("orderTerm") = DBNull.Value
        Else
            Dim term As Integer = 0
            Select Case Me.Urgency
                Case UrgencyType.IsHigh
                    term = 4
                    Exit Select
                Case UrgencyType.IsElevated
                    term = 4
                    Exit Select
                Case Else
                    term = 16
            End Select
            Dim orderTerm As Date = Common.GetPlaneDate(CDate(Me("paymentDate")), term * 60, True)
            If Not IsDBNull(Me("expertTerm")) AndAlso orderTerm < CDate(Me("expertTerm")) Then
                orderTerm = Common.GetPlaneDate(CDate(Me("expertTerm")), 2 * 60, False)
            End If
            Me("orderTerm") = orderTerm
        End If
    End Sub

End Class
