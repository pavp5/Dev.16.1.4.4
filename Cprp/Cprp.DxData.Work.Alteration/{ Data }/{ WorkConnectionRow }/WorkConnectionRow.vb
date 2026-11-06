Imports Cprp.DxData.Common
Imports Cprp.DxData.Work.Common
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Alteration.WorkConnectionRow
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(id As Object, Connection As SqlConnection)
        MyBase.New(Connection)
        '
        ' ARow
        '
        With MyBase.ARow.Columns
            .Add("expertComment", GetType(String))          ' комментарий эксперта
            .Add("leaderComment", GetType(String))          ' комментарий руководителя
            .Add("changeSummaryId", GetType(Integer))       ' ID решения по результатам рассмотрения
            ' Письмо
            .Add("doc1Data", GetType(Byte()))               ' содержимое проекта документа (openXml)
            .Add("doc1Id", GetType(Integer))                ' порядковый номер документа в таблице исходящих документов базы данных
            .Add("doc1RegNum", GetType(String))             ' номер документа
            .Add("doc1RegDate", GetType(Date))              ' дата документа
        End With
        '
        ' ID
        '
        MyClass.Id = id
        Me("typeId") = CInt(WorkType.IsAlteration)

    End Sub


    ''' <summary>
    ''' ID работы
    ''' </summary>
    Public Overrides Property Id As Object
        Get
            Return MyBase.Id
        End Get
        Set(value As Object)
            MyBase.Id = value
            If MyBase.IsEmpty Then Exit Property            
            MyBase.DS.AcceptChanges()
        End Set
    End Property


    ' ''' <summary>
    ' ''' Разблокировать первичную работу
    ' ''' </summary>
    'Friend Sub UnlockParentWork()
    '    '
    '    ' ID первичной работы
    '    '
    '    Dim workId As Integer = ToInt(Me("parentId"))
    '    If Not WorkExist(workId, Me.Connection) Then Exit Sub
    '    '
    '    ' Формирование запроса на разблокировку первичной работы
    '    '
    '    Dim updateString As String = String.Format( _
    '        "UPDATE tWork SET conditionId = {0}, expertId = {1}, expertTerm = {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}, totalWork = {3}", _
    '        CInt(WorkCondition.IsWork), CInt(Me("expertId")), CDate(Me.ARow("expertTerm")), CInt(Me.ARow("totalWork")))
    '    ' Указание номера договора для старых работ
    '    If Not IsDBNull(Me("agreementNum")) Then
    '        updateString &= String.Format(", agreementNum = '{0}'", ToText(Me("agreementNum")))
    '    End If
    '    ' Указание нулевой стоимости первичной работы в случае внесения в нее изменений по нашей вине
    '    If CType(Me.ARow("changeSourceId"), ChangeSource) = ChangeSource.IsExpert Then
    '        updateString &= ", price = 0"
    '    End If
    '    ' Строка запроса
    '    updateString &= String.Format(" WHERE id = {0}", workId)
    '    '
    '    ' Разблокировка первичной работы
    '    '
    '    Me.ExecuteNonQuery(updateString)
    'End Sub


    ' ''' <summary>
    ' ''' Создать новую работу из первичной работы
    ' ''' </summary>
    ' ''' <returns>ID новой работы</returns>
    'Friend Function CreateNewWork() As Integer
    '    '
    '    ' ID первичной работы
    '    '
    '    Dim workId As Integer = ToInt(Me("parentId"))
    '    If Not Work.Common.WorkExist(workId, Me.Connection) Then Return EMPTY_ID
    '    '
    '    ' Тип новой работы (соответствует типу первичной работы)
    '    '
    '    Dim typeId As Integer = CInt(Me.ExecuteScalar(String.Format("SELECT typeId FROM tWork WHERE id = {0}", workId)))
    '    '
    '    ' Создание новой записи в таблице работ базы данных
    '    '
    '    Using T As New NewWorkDataTable(Me.Connection)
    '        Dim Row As DataRow = T.NewRow
    '        Row("pId") = Me.Id
    '        Row("parentId") = Me("parentId")
    '        Row("guid") = System.Guid.NewGuid.ToString
    '        Row("typeId") = typeId
    '        Row("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsWork)
    '        Row("expertId") = Me("expertId")
    '        Row("expertTerm") = Me.ARow("expertTerm")
    '        Row("managerId") = Me("managerId")
    '        Row("leaderId") = Me("leaderId")
    '        Row("comment") = String.Format("Внесение изменений в работу № {0}.", workId)
    '        Row("orderId") = Me("orderId")
    '        Row("orderNum") = Me("orderNum")
    '        Row("orderDate") = Me("orderDate")
    '        Row("orderUrl") = Me("orderUrl")
    '        Row("taskId") = Me("taskId")
    '        Row("taskUrl") = Me("taskUrl")
    '        Row("clientName") = Me("clientName")
    '        Row("clientAddress") = Me("clientAddress")
    '        Row("clientInn") = Me("clientInn")
    '        Row("clientKpp") = Me("clientKpp")
    '        Row("clientPhone") = Me("clientPhone")
    '        Row("clientFax") = Me("clientFax")
    '        Row("totalWork") = Me.ARow("totalWork")
    '        Row("createDate") = Date.Now
    '        T.Rows.Add(Row)
    '        T.SaveToBase()
    '    End Using
    '    '
    '    ' ID новой работы
    '    '
    '    workId = CInt(Me.ExecuteScalar("SELECT @@IDENTITY FROM tWork"))
    '    '
    '    ' Дополнительные данные новой работы
    '    ' (для сохранения данных используется работа вида "Идентификация по экспортному контролю")
    '    '
    '    Using NWork As New Cprp.DxData.Work.Excont.WorkConnectionRow(workId, Me.Connection)
    '        NWork.ARow("changeSourceId") = Me.ARow("changeSourceId")
    '        NWork.ARow("expertTerm") = Me.ARow("expertTerm")
    '        NWork.ARow("totalWork") = Me.ARow("totalWork")
    '        '
    '        ' Копирование данных плана исходной работы в новую работу
    '        '
    '        Using PWork As New Cprp.DxData.Work.Excont.WorkConnectionRow(ToInt(Me("parentId")), Me.Connection)
    '            NWork.ARow("typeId") = PWork.ARow("typeId")
    '            NWork.ARow("goodCount") = PWork.ARow("goodCount")
    '            NWork.ARow("matCount") = PWork.ARow("matCount")
    '            NWork.ARow("infCount") = PWork.ARow("infCount")
    '            NWork.ARow("addWorkCount") = PWork.ARow("addWorkCount")
    '            NWork.ARow("langCount") = PWork.ARow("langCount")
    '            NWork.ARow("findCount") = PWork.ARow("findCount")
    '            'NWork.ARow("planeComment") = PWork.ARow("planeComment")
    '        End Using
    '        '
    '        ' Расчет стоимости работы
    '        '
    '        NWork.ReCalc()
    '        '
    '        ' Сохранение новой работы в базу данных
    '        '
    '        NWork.DataSave()
    '        '
    '        ' Отправка в ЭО сообщения о новой работе
    '        '
    '        NWork.MessageWorkNewEo()
    '        '
    '        ' Создание плана работы, отправка плана в ЭО
    '        '
    '        NWork.PlaneDocumentCreate()
    '        NWork.PlaneDocumentToEO()


    '    End Using
    '    '
    '    ' Обновление типа новой работы
    '    '
    '    Me.ExecuteNonQuery(String.Format("UPDATE tWork SET typeId = {0} WHERE id = {1}", typeId, workId))
    '    '
    '    ' ID новой работы
    '    '
    '    Return workId

    'End Function

    ' ''' <summary>
    ' ''' Создать новую работу по результатам рассмотрения заявки на внесение изменений
    ' ''' </summary>
    ' ''' <param name="condition">Состояние новой работы</param> 
    ' ''' <returns>ID новой работы</returns> 
    'Friend Function CreateNewWork(condition As WorkCondition) As Integer
    '    '
    '    ' ID первичной работы
    '    '
    '    Dim parentId As Integer = ToInt(Me("parentId"))
    '    If Not Work.Common.WorkExist(parentId, Me.Connection) Then Return EMPTY_ID
    '    '
    '    ' Тип первичной работы
    '    '
    '    Dim typeId = CInt(Me.ExecuteScalar(String.Format("SELECT typeId FROM tWork WHERE id = {0}", parentId)))
    '    '
    '    ' Новая работа
    '    '
    '    Using NewWork As New NewWorkDataRow(Me.Connection)
    '        NewWork.Rows.Add(NewWork.NewRow)
    '        NewWork("createDate") = Date.Now
    '        NewWork("pId") = Me.Id
    '        'NewWork("guid") = System.Guid.NewGuid.ToString
    '        NewWork("conditionId") = CInt(condition)
    '        NewWork("expertId") = Me("expertId")
    '        NewWork("expertTerm") = Me.ARow("expertTerm")
    '        NewWork("managerId") = Me("managerId")
    '        NewWork("leaderId") = Me("leaderId")
    '        NewWork("orderId") = Me("orderId")
    '        NewWork("orderNum") = Me("orderNum")
    '        NewWork("orderDate") = Me("orderDate")
    '        NewWork("orderUrl") = Me("orderUrl")
    '        NewWork("taskId") = Me("taskId")
    '        NewWork("taskUrl") = Me("taskUrl")
    '        NewWork("clientName") = Me("clientName")
    '        NewWork("clientAddress") = Me("clientAddress")
    '        NewWork("clientInn") = Me("clientInn")
    '        NewWork("clientKpp") = Me("clientKpp")
    '        NewWork("clientPhone") = Me("clientPhone")
    '        NewWork("clientFax") = Me("clientFax")
    '        NewWork("totalWork") = Me.ARow("totalWork")
    '        NewWork("agreementNum") = Me("agreementNum")
    '        NewWork("typeId") = typeId
    '        NewWork.SaveToBase()
    '    End Using
    '    '
    '    ' ID новой работы
    '    '
    '    Dim newWorkId As Integer = ToInt(Me.ExecuteScalar("SELECT @@IDENTITY"))
    '    '
    '    ' Копирование данных первичной работы, отправка сообщения в ЭО
    '    '
    '    Using NewWork As New Cprp.DxData.Work.Excont.WorkConnectionRow(newWorkId, Me.Connection)
    '        '
    '        ' Копирование данных первичной работы, если новая работа оформляется как внесение изменений в первичную работу
    '        '
    '        If condition = WorkCondition.IsWork Then
    '            Using ParentWork As New Cprp.DxData.Work.Excont.WorkConnectionRow(parentId, Me.Connection)
    '                NewWork("parentId") = Me("parentId")
    '                NewWork.ARow("changeSourceId") = Me.ARow("changeSourceId")
    '                NewWork.ARow("expertTerm") = Me.ARow("expertTerm")
    '                NewWork.ARow("totalWork") = Me.ARow("totalWork")
    '                NewWork("comment") = String.Format("Внесение изменений в работу № {0}.", parentId)
    '                NewWork.ARow("goodCount") = ParentWork.ARow("goodCount")
    '                NewWork.ARow("matCount") = ParentWork.ARow("matCount")
    '                NewWork.ARow("infCount") = ParentWork.ARow("infCount")
    '                NewWork.ARow("addWorkCount") = ParentWork.ARow("addWorkCount")
    '                NewWork.ARow("langCount") = ParentWork.ARow("langCount")
    '                NewWork.ARow("findCount") = ParentWork.ARow("findCount")
    '                NewWork.DataSave()
    '            End Using
    '        End If
    '        '
    '        ' Отправка в ЭО сообщения о новой работе
    '        '
    '        NewWork.MessageWorkNewEo()
    '    End Using
    '    '
    '    ' Обновление в базе типа работы
    '    '
    '    Me.ExecuteNonQuery(String.Format("UPDATE tWork SET typeId = {0} WHERE id = {1}", typeId.ToString, newWorkId.ToString))
    '    '
    '    ' ID новой работы
    '    '
    '    Return newWorkId

    'End Function


End Class
