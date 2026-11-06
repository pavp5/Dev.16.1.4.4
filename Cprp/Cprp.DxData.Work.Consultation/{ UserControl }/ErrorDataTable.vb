Imports C2 = Cprp.DxData.Common
''' <summary>
''' Сообщения об ошибках
''' </summary>
''' <remarks></remarks>
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
    Friend Sub New(Work As WorkConnectionRow)
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
            If Not CheckQuery() Then bTmp = False
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
            AddNew(C2.EMPTY_ID, "Не указано количество поставленных вопросов")
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
#Region "Вопросы и ответы"

    ''' <summary>
    ''' Проверить данные вопросов и ответов
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckQuery() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        Dim bTmp As Boolean = True
        '
        ' Проверка данных
        '
        If Not CheckQueryList() Then bTmp = False
        For Each Row As DataRow In Work.QueryTable.Rows
            If Not CheckQueryData(Row) Then bTmp = False
        Next
        Return bTmp
    End Function

#End Region


    ''' <summary>
    ''' Проверить наличие списка вопросов
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckQueryList() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Вопросы и ответы"
        erType = ContentEnum.QueryList
        erBool = (Work.QueryTable.Rows.Count > 0)
        If Not erBool Then AddNew(C2.EMPTY_ID, "Отсутствуют вопросы")
        Return erBool
    End Function

    ''' <summary>
    ''' Проверить регистрационные данные вопроса
    ''' </summary>
    ''' <param name="Row">Строка таблицы вопросов</param>
    ''' <remarks></remarks>
    Friend Function CheckQueryData(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.QueryTable Then Return False
        erPlace = String.Format("Вопросы и ответы > Объект № {0}", CInt(Row("rowNum")))
        erType = ContentEnum.QueryData
        erBool = True
        '
        ' Вопрос
        '
        If Not C2.IsText(Row("ask")) Then
            AddNew(Row("id"), "Не указан вопрос")
            erBool = False
        End If
        '
        ' Ответ
        '
        If Not C2.IsText(Row("ans")) Then
            AddNew(Row("id"), "Не указан ответ")
            erBool = False
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
