Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица расчетов стоимости заказов
''' </summary>
Friend Class CalcDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("CalcTable")
        With Me.Columns
            ' Поля таблицы tCalc
            .Add("id", GetType(Integer))                ' ID расчета
            .Add("orderNum", GetType(String))           ' Номер заказа
            .Add("deptId", GetType(Integer))            ' ID представительства
            .Add("typeId", GetType(Integer))            ' ID вида расчета
            .Add("isAdd", GetType(Boolean))             ' Дополнительный счет
            .Add("isAgreement", GetType(Boolean))       ' Доп. соглашение
            .Add("isUrgency", GetType(Boolean))         ' Срочность
            .Add("objectDifCount", GetType(Integer))    ' Количество объектов исследования
            .Add("objectAllCount", GetType(Integer))    ' Общее количество товаров
            .Add("workCount", GetType(Integer))         ' Количество работ по заказу
            .Add("dopMinCount", GetType(Integer))       ' Объем дополнительных работ (мин.)
            .Add("priceCalc", GetType(Single))          ' Расчетная стоимость без НДС
            .Add("priceEnd", GetType(Single))           ' Окончательная стоимость без НДС
            .Add("userId", GetType(Integer))            ' ID автора расчета
            .Add("actDate", GetType(Date))              ' Дата создания / изменения расчета
            .Add("comment", GetType(String))            ' Примечание
            ' Поля представления vCalc
            .Add("deptName", GetType(String))           ' Представительство
            .Add("typeName", GetType(String))           ' Вид расчета
            .Add("userName", GetType(String))           ' Автор расчета
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.Columns("isAdd").AllowDBNull = False
        Me.Columns("isAdd").DefaultValue = False
        Me.Columns("isAgreement").AllowDBNull = False
        Me.Columns("isAgreement").DefaultValue = False
        Me.Columns("isUrgency").AllowDBNull = False
        Me.Columns("isUrgency").DefaultValue = False
        Me.Columns("objectDifCount").AllowDBNull = False
        Me.Columns("objectDifCount").DefaultValue = 1
        Me.Columns("objectAllCount").AllowDBNull = False
        Me.Columns("objectAllCount").DefaultValue = 1
        Me.Columns("workCount").AllowDBNull = False
        Me.Columns("workCount").DefaultValue = 1
        Me.Columns("dopMinCount").AllowDBNull = False
        Me.Columns("dopMinCount").DefaultValue = 0
        Me.Columns("priceCalc").AllowDBNull = False
        Me.Columns("priceCalc").DefaultValue = 0
        Me.Columns("priceEnd").AllowDBNull = False
        Me.Columns("priceEnd").DefaultValue = 0
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Перечитать все данные из источника данных
    ''' </summary>
    ''' <param name="startDate">Начало периода</param> 
    ''' <param name="isAll">Все расчеты</param> 
    Friend Sub DataReload(startDate As Date, isAll As Boolean)
        Dim sTmp As String = String.Format( _
            "SELECT id, orderNum, deptId, typeId, isAdd, isAgreement, isUrgency, objectDifCount, objectAllCount, " & _
            "workCount, dopMinCount, priceCalc, priceEnd, userId, actDate, comment, deptName, typeName, userName " & _
            "FROM vCalc WHERE actDate > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", startDate)
        If Not isAll Then sTmp = String.Format("{0} AND userId = {1}", sTmp, Program.DbClient.Id)
        Me.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection, .CommandText = sTmp}
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

#Region "Тарифные опции"

    ''' <summary>
    ''' Стоимость 1 у.е.
    ''' </summary>
    Private UEPrice As Single = 1

    ''' <summary>
    ''' Коэффициент умножения за срочность
    ''' </summary>
    Private UrgencyKoef As Single = 1.5

    ''' <summary>
    ''' Стоимость одной дополнительной однотипной работы
    ''' </summary>
    Private DopWorkPrice As Single = 3000

    ''' <summary>
    ''' Стоимость одного часа дополнительных работ
    ''' </summary>
    Private DopHourPrice As Single = 2200

    ''' <summary>
    ''' Стоимость одной дополнительной лицензии для услуги "Лицензирование"
    ''' </summary>
    Private DopLicensePrice As Single = 12500


    ''' <summary>
    ''' Перечитывание тарифных опций из базы данных 
    ''' </summary>
    Private Sub GetTarif()
        'Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
        '    Cmd.CommandText = "SELECT name, price FROM tCalcTarif"
        '    Using Dr As SqlDataReader = Cmd.ExecuteReader
        '        While Dr.Read
        '            Select Case Dr("name").ToString.ToUpper.Replace(" ", Nothing)
        '                Case "УЕСТОИМОСТЬ"
        '                    UEPrice = CSng(Dr("price"))
        '                    Exit Select
        '                Case "СРОЧНОСТЬ"
        '                    UrgencyKoef = CSng(Dr("price"))
        '                    Exit Select
        '                Case "ДОПРАБОТА"
        '                    DopWorkPrice = CSng(Dr("price"))
        '                    Exit Select
        '                Case "ЧАСДОПРАБОТ"
        '                    DopHourPrice = CSng(Dr("price"))
        '                    Exit Select
        '                Case "ДОПЛИЦЕНЗИЯ"
        '                    DopLicensePrice = CSng(Dr("price"))
        '                    Exit Select
        '            End Select
        '        End While
        '        Dr.Close()
        '    End Using
        'End Using
    End Sub

#End Region

    ''' <summary>
    ''' Расчет стоимости заказа
    ''' </summary>
    ''' <param name="Row">Строка таблицы стоимостей заказов</param> 
    Friend Sub Calc(ByRef Row As DataRow)
        If Row Is Nothing OrElse Not TypeOf Row.Table Is CalcDataTable Then Exit Sub

        Row("priceCalc") = 0
        Row("priceEnd") = 0
        '
        ' Стоимость расчитывается по допсоглашению
        '
        If CBool(Row("isAgreement")) Then
            SetPriceAgreement(Row)
            If CInt(Row("priceCalc")) > 1 Then Exit Sub
        End If
        '
        ' Определение тарифных опций на текущий момент времени
        '
        GetTarif()
        '
        ' Расчет стоимости в зависимости от вида услуги
        '
        Dim Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
        Dim pCalc As Single = 0         ' Расчетная стоимость без НДС
        Dim iTmp As Integer = 0

        Select Case CInt(Row("typeId"))
            Case 14, 15, 16, 18
                '
                ' 14 - Экспертиза: Экспортный контроль 
                ' 15 - Экспертиза: Запреты и ограничения ЕАЭС
                ' 16 - Экспертиза: Гражданское назначение
                ' 18 - Консультация
                '
                ' Стоимость количества объектов исследования
                '
                iTmp = CInt(Row("objectDifCount"))
                pCalc = 14000
                If iTmp > 0 Then
                    For i As Integer = 1 To iTmp
                        pCalc += If(i > 10, 850, 900)
                    Next
                End If
                '
                ' Стоимость количества часов дополнительных работ по заказу
                '
                iTmp = CInt(Row("dopMinCount"))
                If iTmp > 0 AndAlso iTmp < 60 Then iTmp = 60
                pCalc += (DopHourPrice * iTmp / 60)
                '
                ' Стоимость дополнительных стран назначения
                '
                iTmp = CInt(Row("workCount")) - 1
                If iTmp > 0 Then pCalc += DopWorkPrice * iTmp
                '
                ' Если это основной расчет
                '
                'If Not CBool(Row("isAdd")) Then
                '    '
                '    ' Базовая стоимости услуги
                '    '
                '    Cmd.CommandText = String.Format("SELECT price FROM tCalcType WHERE id = {0}", CInt(Row("typeId")))
                '    pCalc += CSng(Cmd.ExecuteScalar)
                '
                ' Скидка 50 % если по этому заказу была уже заказана другая экспертиза
                '
                Cmd.CommandText = String.Format( _
                    "SELECT COUNT(*) FROM tCalc WHERE orderNum = '{0}' AND isAdd = 0 AND id <> {1} AND " & _
                    "typeId IN (SELECT id FROM tCalcType WHERE isPrice50 = 1)", _
                    Row("orderNum").ToString, CInt(Row("id")))
                If CInt(Cmd.ExecuteScalar) > 0 Then pCalc /= 2
                '
                ' 04/21/796 (ИРЭ-ПОЛЮС) - стоимость работы равна 50% стандартной стоимости
                '
                'If CBool(Row("isAgreement")) AndAlso C2.ToText(Row("orderNum")) Like "04/21/796*" Then pCalc /= 2
                'End If
                '
                ' Учет срочности
                '
                If CBool(Row("IsUrgency")) Then pCalc = UrgencyKoef * pCalc

            Case 17
                '
                ' 17 - Экспертиза: Код ТНВЭД / Номер CAS
                '
                ' Стоимость количества объектов исследования
                '
                'iTmp = CInt(Row("objectDifCount"))
                'pCalc = 7000
                'If iTmp > 0 Then
                '    For i As Integer = 1 To iTmp
                '        pCalc += If(i > 10, 400, 450)
                '    Next
                'End If
                ''
                '' Стоимость количества часов дополнительных работ по заказу
                ''
                'iTmp = CInt(Row("dopMinCount"))
                'If iTmp > 0 AndAlso iTmp < 60 Then iTmp = 60
                'pCalc += (DopHourPrice * iTmp / 60)
                ''
                '' Если это основной расчет
                ''
                'If Not CBool(Row("isAdd")) Then
                '    '
                '    ' Базовая стоимости услуги
                '    '
                '    Cmd.CommandText = String.Format("SELECT price FROM tCalcType WHERE id = {0}", CInt(Row("typeId")))
                '    pCalc += CSng(Cmd.ExecuteScalar)
                'End If
                iTmp = CInt(Row("objectAllCount"))
                pCalc = iTmp * 1900
                '
                ' Учет срочности
                '
                If CBool(Row("IsUrgency")) Then pCalc = UrgencyKoef * pCalc

            Case 19, 20, 21
                '
                ' 19 - Лицензирование: Подготовка пакета, отправка, контроль прохождения
                ' 20 - Лицензирование: Подготовка пакета
                ' 21 - Лицензирование: Отправка пакета, контроль прохождения
                '
                ' Стоимость количества лицензий
                '
                pCalc += (DopLicensePrice * (CInt(Row("objectDifCount")) - 1))
                '
                ' Если это основной расчет
                '
                If Not CBool(Row("isAdd")) Then
                    '
                    ' Базовая стоимости услуги
                    '
                    Cmd.CommandText = String.Format("SELECT price FROM tCalcType WHERE id = {0}", CInt(Row("typeId")))
                    pCalc += CSng(Cmd.ExecuteScalar)
                End If

            Case 26
                '
                ' 26 - внесение изменений в ранее выданное заключение
                '
                ' Стоимость количества часов дополнительных работ по заказу
                '
                iTmp = CInt(Row("dopMinCount"))
                If iTmp > 0 AndAlso iTmp < 60 Then iTmp = 60
                pCalc += (DopHourPrice * iTmp / 60)

            Case Else
                '
                ' Прочие виды услуг
                '
                ' Если это основной расчет
                '
                If Not CBool(Row("isAdd")) Then
                    '
                    ' Базовая стоимости услуги
                    '
                    Cmd.CommandText = String.Format("SELECT price FROM tCalcType WHERE id = {0}", CInt(Row("typeId")))
                    pCalc += CSng(Cmd.ExecuteScalar)
                End If

        End Select
        '
        ' Перевод в рубли из у.е.
        '
        pCalc = UEPrice * pCalc
        '
        ' Расчетная стоимость, предварительная окончательная стоимость
        '
        Row("priceCalc") = pCalc
        Row("priceEnd") = pCalc

    End Sub

    ''' <summary>
    ''' Определить стоимость заказа по допсоглашению
    ''' </summary>
    ''' <param name="Row">Строка таблицы стоимостей заказов</param>
    Private Sub SetPriceAgreement(Row As DataRow)

        If Row Is Nothing OrElse Not TypeOf Row.Table Is CalcDataTable Then Exit Sub

        Row("priceCalc") = 0
        Row("priceEnd") = 0

        If IsDBNull(Row("isAgreement")) OrElse Not CBool(Row("isAgreement")) Then Exit Sub

        Dim orderNum As String = C2.ToText(Row("orderNum"))         ' Номер заказа
        Dim typeId As String = C2.ToInt(Row("typeId"))              ' Вид услуги

        If String.IsNullOrWhiteSpace(orderNum) OrElse typeId < 1 Then Exit Sub

        Dim pCalc As Integer = 0                                    ' Расчетная стоимость без НДС
        Dim iTmp As Integer

        If orderNum Like "01/17/73*" Then
            '
            ' 01/17/73 - РУСАТОМ СЕРВИС, АО
            ' =============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 2300
                    '
                    ' Стоимость = Базовая стоимость плюс пропорциональное увеличение стоимости в зависимости от количества разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    For i As Integer = 2 To iTmp
                        If i < 6 Then : pCalc += 781
                        ElseIf i < 26 Then : pCalc += 649
                        ElseIf i < 71 Then : pCalc += 506
                        ElseIf i < 101 Then : pCalc += 473
                        ElseIf i < 201 Then : pCalc += 440
                        ElseIf i < 301 Then : pCalc += 407
                        Else : pCalc += 374
                        End If
                    Next
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/18/77*" Then
            '
            ' 01/18/77 - Инжиниринговая компания АСЭ (АСЭ ИК), АО
            ' ===================================================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 2300
                    '
                    ' Расчеты стоимости материальных объектов и документации разные
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    If Cprp.DxCommon.Messages.ShowQuestion("Это документация?") = DialogResult.Yes Then
                        '
                        ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов
                        '
                        pCalc = pCalc * iTmp
                    Else
                        '
                        ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов плюс пропорциональное увеличение стоимости в зависимости от количества однородных объектов
                        '
                        pCalc = pCalc * C2.ToInt(Row("objectDifCount"))
                        iTmp = C2.ToInt(Row("objectAllCount")) - C2.ToInt(Row("objectDifCount"))
                        For i As Integer = 2 To iTmp
                            If i < 6 Then : pCalc += 781
                            ElseIf i < 26 Then : pCalc += 649
                            ElseIf i < 71 Then : pCalc += 506
                            ElseIf i < 101 Then : pCalc += 473
                            Else : pCalc += 440
                            End If
                        Next
                    End If
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/17/273*" Then
            '
            ' 01/17/273 - АТОМПРОЕКТ, АО
            ' ==========================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов 
                    '
                    pCalc = 2000 * CInt(Row("objectDifCount"))
                Case 19
                    '
                    ' 19 - Лицензирование: Подготовка пакета, отправка, контроль прохождения
                    ' ----------------------------------------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество лицензий
                    '
                    pCalc = 29474.27 * CInt(Row("objectDifCount"))
                Case 22
                    '
                    ' 22 - Лицензирование: Проделение срока действия лицензии
                    ' -------------------------------------------------------
                    ' 
                    ' Стоимость = Базовая стоимость
                    '
                    pCalc = 7750
                Case 28
                    '
                    ' 28 - Подтверждение соответствия продукции лицензии ФСТЭК
                    ' --------------------------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов
                    '
                    pCalc = 876 * CInt(Row("objectDifCount"))
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/18/93*" Then
            '
            ' 01/18/93 - АТОМПРОЕКТ, АО
            ' =========================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов 
                    '
                    pCalc = 2000 * CInt(Row("objectDifCount"))
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "05/1134*" Then
            '
            ' 05/1134 - АТОМСТРОЙЭКСПОРТ, АО
            ' ==============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Базовая стоимость экспертизы одного товара или документа
                    '
                    pCalc = 15100
                    '
                    ' Расчет стоимости материальных и информационных объектов разный
                    '
                    If Cprp.DxCommon.Messages.ShowQuestion("Это документация?") = DialogResult.Yes Then
                        '
                        ' Количество информационных объектов
                        '
                        iTmp = CInt(Row("objectAllCount"))
                        '
                        ' Пропорциональное увеличение стоимости в зависимости от количества
                        '
                        For i As Integer = 2 To iTmp
                            If i < 26 Then : pCalc += 600
                            Else : pCalc += 250
                            End If
                        Next
                    Else
                        '
                        ' Количество разнородных объектов (кодов ТН ВЭД)
                        '
                        iTmp = C2.ToInt(Row("objectDifCount"))
                        '
                        ' Стоимость = Базовая стоимость плюс 900 умноженное на количество разнородных объектов больше 1
                        '
                        pCalc = pCalc + 900 * (iTmp - 1)
                    End If

                    '
                    ' Скидка 50 % если по этому заказу была уже заказана другая экспертиза
                    '
                    Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                        Cmd.CommandText = String.Format( _
                            "SELECT COUNT(*) FROM tCalc WHERE orderNum = '{0}' AND isAdd = 0 AND id <> {1} AND " & _
                            "typeId IN (SELECT id FROM tCalcType WHERE isPrice50 = 1)", _
                            Row("orderNum").ToString, CInt(Row("id")))
                        If CInt(Cmd.ExecuteScalar) > 0 Then pCalc /= 2
                    End Using

                    '
                    ' Учет срочности
                    '
                    If CBool(Row("IsUrgency")) Then pCalc *= 2

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 6000

                Case 27
                    '
                    ' 27 - Копия заключения на бумажном носителе
                    ' ------------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 200

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "02/17/37*" Then
            '
            ' 02/17/37 - УНИВАР, ООО
            ' ======================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 9500

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "02/18/2834*" Then
            '
            ' 02/18/2834 - ТАГинн Северо-Запад, ООО
            ' =====================================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 7500

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/19/68*" Then
            '
            ' 01/19/68 - АТОМПРОЕКТ, АО
            ' =========================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимиость услуги = 2250 умножить на количество разнородных объектов
                    '
                    pCalc = 2250 * C2.ToInt(Row("objectDifCount"))

                Case Else
                    Exit Sub
            End Select

        ElseIf (orderNum Like "02/18/1300*" OrElse orderNum Like "02/19/1936*") Then
            '
            ' 02/18/1300, 02/19/1936 - ГСПИ, АО
            ' =================================
            '
            Select Case typeId
                Case 18
                    '
                    ' 18 - Консультация
                    ' -----------------
                    '
                    ' Стоимиость услуги = 14500 умножить на количество разнородных объектов
                    '
                    pCalc = 14500 * C2.ToInt(Row("objectDifCount"))

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/19/225*" Then
            '
            ' 01/19/225 - ГСПИ, АО
            ' ====================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов 
                    '
                    pCalc = 2350 * CInt(Row("objectDifCount"))
                Case 18
                    '
                    ' 18 - Консультация
                    ' -----------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов 
                    '
                    pCalc = 14500 * C2.ToInt(Row("objectDifCount"))
                Case 19
                    '
                    ' 19 - Лицензирование: Подготовка пакета, отправка, контроль прохождения
                    ' ----------------------------------------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество лицензий
                    '
                    pCalc = 29500 * CInt(Row("objectDifCount"))
                Case 22
                    '
                    ' 22 - Лицензирование: Проделение срока действия лицензии
                    ' -------------------------------------------------------
                    ' 
                    ' Стоимость = Базовая стоимость умноженная на количество лицензий
                    '
                    pCalc = 12520 * CInt(Row("objectDifCount"))

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/15/65*" Then
            '
            ' 01/15/65 - ПЛАНЕТА-ЭЛЕКС, ЗАО
            ' =============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимиость услуги = 7700
                    '
                    pCalc = 7700

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/18/164*" Then
            '
            ' 01/18/164 - РУСАТОМ СЕРВИС, АО
            ' ==============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 2350
                    '
                    ' Стоимость = Базовая стоимость * количество разнородных объектов плюс пропорциональное увеличение стоимости в зависимости от количества однородных объектов
                    '
                    pCalc = pCalc * CInt(Row("objectDiFCount"))
                    iTmp = CInt(Row("objectAllCount")) - CInt(Row("objectDifCount"))
                    For i As Integer = 1 To iTmp
                        If i < 6 Then : pCalc += 800
                        ElseIf i < 26 Then : pCalc += 670
                        ElseIf i < 71 Then : pCalc += 530
                        ElseIf i < 101 Then : pCalc += 495
                        ElseIf i < 201 Then : pCalc += 450
                        ElseIf i < 301 Then : pCalc += 407
                        Else : pCalc += 374
                        End If
                    Next
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/19/135*" Then
            '
            ' 01/19/135 - Техснабэкспорт, АО
            ' ==============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 2350
                    '
                    ' Расчеты стоимости материальных объектов и документации разные
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    If Cprp.DxCommon.Messages.ShowQuestion("Это документация?") = DialogResult.Yes Then
                        '
                        ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов
                        '
                        pCalc = pCalc * iTmp
                    Else
                        '
                        ' Стоимость = Базовая стоимость плюс пропорциональное увеличение стоимости в зависимости от количества разнородных объектов
                        '
                        For i As Integer = 2 To iTmp
                            If i < 6 Then : pCalc += 800
                            ElseIf i < 26 Then : pCalc += 670
                            ElseIf i < 71 Then : pCalc += 530
                            ElseIf i < 101 Then : pCalc += 495
                            Else : pCalc += 450
                            End If
                        Next
                    End If
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "02/19/1768*" Then
            '
            ' 02/19/1768 - РУСАТОМ СЕРВИС, АО
            ' ===============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов 
                    '
                    pCalc = 2400 * CInt(Row("objectDifCount"))
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/20/9*" Then
            '
            ' 01/20/9 ЦНИИТМАШ, НПО, АО
            ' =========================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов 
                    '
                    pCalc = 2530 * CInt(Row("objectDifCount"))
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "02/15/838*" Then
            '
            ' 02/15/838 НЕВСКАЯ ПАЛИТРА, АО
            ' =============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Стоимость первой работы по заказу 13210, стоимость следующих работ 1600
                    '
                    pCalc = 13210 + 1600 * (CInt(Row("workCount")) - 1)
                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/20/309*" Then
            '
            ' 01/20/309 - АТОМПРОЕКТ, АО
            ' ==========================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость документации на русском и английском языке разная
                    '
                    If Cprp.DxCommon.Messages.ShowQuestion("Документация на русском языке?") = DialogResult.Yes Then
                        '
                        ' Стоимость = Базовая стоимость умноженная на кодичество разнородных объектов
                        '
                        pCalc = 4100 * iTmp
                    Else
                        pCalc = 5900 * iTmp
                    End If

                Case 19
                    '
                    ' 19 - Лицензирование
                    ' -------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 35790

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 3600

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/21/222*" Then
            '
            ' 01/21/222 - ДЦ ЯТЦ, АО
            ' ======================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Расчеты стоимости материальных объектов и документации разные
                    '
                    If Cprp.DxCommon.Messages.ShowQuestion("Это документация?") = DialogResult.No Then
                        '
                        ' Базовая стоимость экспертизы одного товара
                        '
                        pCalc = 14790
                        '
                        ' Стоимость = Базовая стоимость плюс 790 умноженное на количество разнородных объектов больше 1
                        '
                        pCalc = pCalc + 790 * (iTmp - 1)
                    Else
                        '
                        ' Базовая стоимость экспертизы документации на русском и англицском языке разная
                        '
                        If Cprp.DxCommon.Messages.ShowQuestion("Документация на русском языке?") = DialogResult.No Then
                            pCalc = 5900
                        Else
                            pCalc = 4100
                        End If
                        '
                        ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов
                        '
                        pCalc = pCalc * iTmp
                    End If
                    '
                    ' Срочное выполнение работы (+ 100 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 2

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 3600

                Case 27
                    '
                    ' 27 - Копия заключения на бумажном носителе
                    ' ------------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 300

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "04/21/1475*" Then
            '
            ' 04/21/1475 - Невская палитра, АО
            ' ================================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 14790
                    '
                    ' Стоимость = Базовая стоимость плюс 790 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 790 * (iTmp - 1)
                    '
                    ' Учет дополнительных стран назначения, 2500 р. за страну
                    '
                    iTmp = C2.ToInt(Row("workCount"))
                    If iTmp > 1 Then pCalc += 2500 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 100 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 2

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 3600

                Case 27
                    '
                    ' 27 - Копия заключения на бумажном носителе
                    ' ------------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 200

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "02/15/9*" Then
            '
            ' 02/15/9 - ГеоЛогистикс, АО
            ' ==========================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 15200
                    '
                    ' Стоимость = Базовая стоимость плюс 950 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 950 * (iTmp - 1)
                    '
                    ' Учет дополнительных стран назначения, 2600 р. за страну
                    '
                    iTmp = C2.ToInt(Row("workCount"))
                    If iTmp > 1 Then pCalc += 2600 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 50 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.5

                Case 17
                    '
                    ' 17 - Классификация товара по ТН ВЭД / CAS
                    ' -----------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость классификации одного товара
                    '
                    pCalc = 7600
                    '
                    ' Стоимость = Базовая стоимость плюс 400 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 400 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 100 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 2

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' 2200 * кол-во часов
                    '
                    iTmp = CInt(Row("dopMinCount"))
                    If iTmp > 0 AndAlso iTmp < 60 Then iTmp = 60
                    pCalc = 2200 * iTmp / 60

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "02/15/523*" Then
            '
            ' 02/15/523 - Кюне + Нагель, 00О
            ' ==============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 15200
                    '
                    ' Стоимость = Базовая стоимость плюс 950 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 950 * (iTmp - 1)

                Case 17
                    '
                    ' 17 - Классификация товара по ТН ВЭД / CAS
                    ' -----------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость классификации одного товара
                    '
                    pCalc = 7600
                    '
                    ' Стоимость = Базовая стоимость плюс 475 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 475 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 100 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 2

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' 3100 - фиксированная стоимость
                    '
                    pCalc = 3100

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/22/89*" Then
            '
            ' 01/22/89 - ТЕХСНАБЭКСПОРТ, АО
            ' =================================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Расчеты стоимости материальных объектов и документации разные
                    '
                    If Cprp.DxCommon.Messages.ShowQuestion("Это документация?") = DialogResult.No Then
                        '
                        ' Базовая стоимость экспертизы одного товара
                        '
                        pCalc = 2500
                        '
                        ' Стоимость = Базовая стоимость плюс 900 умноженное на количество разнородных объектов больше 1
                        '
                        pCalc = pCalc + 900 * (iTmp - 1)
                    Else
                        '
                        ' Базовая стоимость экспертизы одного документа
                        '
                        pCalc = 2500
                        '
                        ' Стоимость = Базовая стоимость умноженная на количество разнородных объектов
                        '
                        pCalc = pCalc * iTmp
                    End If
                    '
                    ' Срочное выполнение работы (+ 50 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.5

                Case 26
                    '
                    ' 26 - внесение изменений в ранее выданное заключение
                    ' ---------------------------------------------------
                    ' 
                    ' Стоимость = 2000 умноженное на количество часов
                    '
                    iTmp = Math.Ceiling(C2.ToInt(Me("dopMinCount")) / 60)
                    pCalc = 2000 * iTmp

                Case 27
                    '
                    ' 27 - Копия заключения на бумажном носителе
                    ' ------------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 200

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "04/22/1715*" Then
            '
            ' 04/22/1715 - ТЕХПРОМЭКСПОРТ, ООО
            ' ================================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 14900
                    '
                    ' Стоимость = Базовая стоимость плюс 900 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 900 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 50 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.5

                Case 17
                    '
                    ' 17 - Классификация товара по ТН ВЭД / CAS
                    ' -----------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость классификации одного товара
                    '
                    pCalc = 7450
                    '
                    ' Стоимость = Базовая стоимость плюс 450 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 450 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 50 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.5

                Case 27
                    '
                    ' 27 - Копия заключения на бумажном носителе
                    ' ------------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 200

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/22/721*" Then
            '
            ' 01/22/721 - РУСАТОМ СЕРВИС, АО
            ' ==============================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Базовая стоимость зависит от срочности
                    pCalc = If(CBool(Row("isUrgency")), 3243.73, 2329.4)
                    ' Стоимость = Базовая стоимость * количество разнородных объектов + пропорциональное увеличение стоимости в зависимости от количества однородных объектов
                    ' Разнородные объекты
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    pCalc = pCalc * iTmp
                    ' Однородные объекты
                    iTmp = C2.ToInt(Row("objectAllCount")) - iTmp
                    For i As Integer = 1 To iTmp
                        If i < 6 Then : pCalc += 800
                        ElseIf i < 26 Then : pCalc += 670
                        ElseIf i < 71 Then : pCalc += 530
                        ElseIf i < 101 Then : pCalc += 495
                        ElseIf i < 201 Then : pCalc += 450
                        ElseIf i < 301 Then : pCalc += 407
                        Else : pCalc += 374
                        End If
                    Next

                Case 17
                    '
                    ' 17 - Классификация товара по ТН ВЭД / CAS
                    ' -----------------------------------------
                    '
                    ' Базовая стоимость
                    pCalc = 2000
                    ' Стоимость = Базовая стоимость * количество разнородных объектов + пропорциональное увеличение стоимости в зависимости от количества однородных объектов
                    ' Разнородные объекты
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    pCalc = pCalc * iTmp
                    ' Однородные объекты
                    iTmp = C2.ToInt(Row("objectAllCount")) - iTmp
                    For i As Integer = 1 To iTmp
                        If i < 6 Then : pCalc += 800
                        ElseIf i < 26 Then : pCalc += 670
                        ElseIf i < 71 Then : pCalc += 530
                        ElseIf i < 101 Then : pCalc += 495
                        ElseIf i < 201 Then : pCalc += 450
                        ElseIf i < 301 Then : pCalc += 407
                        Else : pCalc += 374
                        End If
                    Next

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "01/23/70*" Then
            '
            ' 01/23/70 - СИЛОВЫЕ МАШИНЫ, ОАО
            ' ==============================
            '
            Select Case typeId
                Case 14, 15, 17, 18
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' 15 - Экспертиза: Запреты и ограничения
                    ' 17 - Определение кода ТН ВЭД
                    ' 18 - Консультация
                    ' --------------------------------------
                    '
                    ' Стоимость = Базовая стоимость (6650) + (665 * количество объектов > 10)
                    pCalc = 6650
                    ' Разнородные объекты
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    If iTmp > 10 Then pCalc = pCalc + 665 * (iTmp - 10)
                    '
                    ' Срочное выполнение работы (+ 25 % стоимости)                    
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.25

                Case Else
                    Exit Sub
            End Select

        ElseIf orderNum Like "04/23/1047*" Then
            '
            ' 04/23/1047 - КОНЦЕРН ТИТАН-2, АО
            ' ================================
            '
            Select Case typeId
                Case 14
                    '
                    ' 14 - Экспертиза: Экспортный контроль 
                    ' ------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Базовая стоимость экспертизы одного товара
                    '
                    pCalc = 14155
                    '
                    ' Стоимость = Базовая стоимость плюс 855 умноженное на количество разнородных объектов больше 1
                    '
                    pCalc = pCalc + 855 * (iTmp - 1)
                    '
                    ' Срочное выполнение работы (+ 50 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.5

                Case 17
                    '
                    ' 17 - Классификация товара по ТН ВЭД / CAS
                    ' -----------------------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Стоимость = 1805 за каждый код
                    '
                    pCalc = 1805 * iTmp
                    '
                    ' Срочное выполнение работы (+ 50 % стоимости)
                    '
                    If CBool(Row("isUrgency")) Then pCalc = pCalc * 1.5

                Case 18
                    '
                    ' 18 - Консультация по ВЭД
                    ' ------------------------
                    '
                    ' Количество разнородных объектов
                    '
                    iTmp = C2.ToInt(Row("objectDifCount"))
                    '
                    ' Стоимость = Базовая стоимость (9025) + (1425 * количество вопросов > 1)
                    '
                    pCalc = 9025 + 1425 * (iTmp - 1)

                Case 27
                    '
                    ' 27 - Копия заключения на бумажном носителе
                    ' ------------------------------------------
                    '
                    ' Фиксированная стоимость услуги
                    '
                    pCalc = 475

                Case Else
                    Exit Sub
            End Select

        End If
        '
        ' Расчетная стоимость, предварительная окончательная стоимость
        '
        Row("priceCalc") = pCalc
        Row("priceEnd") = pCalc

    End Sub

End Class
