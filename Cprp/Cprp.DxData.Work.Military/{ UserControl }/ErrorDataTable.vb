Imports C2 = Cprp.DxData.Common
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
            If Not CheckMemberData() Then bTmp = False
            If Not CheckExtraDoc() Then bTmp = False
            If Not CheckGood() Then bTmp = False
            If Not CheckSummary() Then bTmp = False
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
#Region "Российский участник внешнеэкономической операции"

    ''' <summary>
    ''' Проверить регистрационные российского участника внешнеэкономической операции
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckMemberData() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Российский участник внешнеэкономической операции"
        erType = ContentEnum.SupplyRusData
        erBool = True
        If Work.MemberTable.Rows.Count = 0 Then
            AddNew(C2.EMPTY_ID, "Отсутствует российский участник внешнеэкономической операции")
            Return False
        End If
        Dim Row As DataRow = Work.MemberTable.Rows(0)
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
        Dim inn As String = C2.ToText(Row("inn"))
        If Not C2.IsText(inn) Then
            AddNew(Row("id"), "Не указан ИНН")
            erBool = False
        ElseIf (inn.Length <> 10 AndAlso inn.Length <> 12) OrElse Not IsNumeric(inn) Then
            AddNew(Row("id"), "Указан неверный ИНН")
            erBool = False
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
        If Not C2.IsText(Row("addressLegalTown")) Then
            AddNew(Row("id"), "Не указан город юридического адреса")
            erBool = False
        End If
        '
        ' Документ-основание внешнеэкономической операции
        '
        If Not C2.IsText(Work.ARow("contractCaption")) Then
            AddNew(Row("id"), "Не указан документ-основание внешнеэкономической операции")
            erBool = False
        End If
        Return erBool
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
            If Not CheckGoodSummary(Row) Then bTmp = False
        Next
        Return bTmp
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
                "SELECT COUNT(*) FROM tTnved WHERE code LIKE '{0}%' AND dateB <= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", tnved, Date.Today))) = 0 Then
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
    ''' Проверить выводы по принадлежности к продукции гражданского назначения
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Function CheckGoodSummary(Row As DataRow) As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        If Row Is Nothing OrElse Not Row.Table Is Work.GoodTable Then Return False
        erPlace = String.Format("Продукция > Объект № {0} > Анализ", CInt(Row("rowNum")))
        erType = ContentEnum.GoodSummary
        erBool = True
        Using V As DataView = Work.GoodInDocTable.GoodView(Row("id"))
            If V.Count = 0 Then
                AddNew(Row("id"), "Отсутствуют документы, подтверждающие гражданское назначение")
                erBool = False
            End If
        End Using
        If Not C2.IsText(Row("summary")) Then
            AddNew(Row("id"), "Отсутствуют выводы по принадлежности к продукции гражданского назначения")
            erBool = False
        End If
        Return erBool
    End Function

#End Region

    ''' <summary>
    ''' Проверить выводы экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CheckSummary() As Boolean
        If Work Is Nothing OrElse Work.IsEmpty Then Return False
        erPlace = "Решение по анализу"
        erType = ContentEnum.Summary
        If Not C2.IsText(Work.ARow("summary")) Then
            AddNew(C2.EMPTY_ID, "Отсутствуют выводы экспертизы")
            erBool = False
        End If
        If Not C2.IsText(Work.ARow("comment")) Then
            AddNew(C2.EMPTY_ID, "Отсутствуют пояснения эксперта")
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
                If Not C2.IsText(V(i)("docType")) Then
                    erPlace = String.Format("Сведения о работе > Перечень документов > Объект № {0}", CInt(V(i)("rowNum")))
                    AddNew(C2.EMPTY_ID, "Не указан вид документа")
                    erBool = False
                End If
            Next
            For i As Integer = 0 To V.Count - 1
                If Not C2.IsText(V(i)("caption")) Then
                    erPlace = String.Format("Сведения о работе > Перечень документов > Объект № {0}", CInt(V(i)("rowNum")))
                    AddNew(C2.EMPTY_ID, "Не указано наименование документа")
                    erBool = False
                End If
            Next
            For i As Integer = 0 To V.Count - 1
                If Not C2.IsText(V(i)("author")) Then
                    erPlace = String.Format("Сведения о работе > Перечень документов > Объект № {0}", CInt(V(i)("rowNum")))
                    AddNew(C2.EMPTY_ID, "Не указана организация, утвердившая документ")
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
