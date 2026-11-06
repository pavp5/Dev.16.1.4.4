Imports Cprp.DxData.Common
''' <summary>
''' Источник данных АПУ
''' </summary>
Friend Class ApuDataSet : Inherits DataSet

    ''' <summary>
    ''' Таблица АПУ
    ''' </summary>
    Friend ApuTable As ApuDataTable = Nothing

    ''' <summary>
    ''' Таблица контрольных списков
    ''' </summary>
    Friend LawTable As LawDataTable = Nothing

    ''' <summary>
    ''' Таблица связей АПУ с контрольными списками
    ''' </summary>
    Friend ApuLawTable As ApuLawDataTable = Nothing

    ''' <summary>
    ''' Таблица кодов ТН ВЭД
    ''' </summary>
    Friend TnvedTable As TnvedDataTable = Nothing

    ''' <summary>
    ''' Таблица связей контрольных списков с кодами ТН ВЭД
    ''' </summary>
    Friend LawTnvedTable As LawTnvedDataTable = Nothing

    ''' <summary>
    ''' Таблица синонимов терминов АПУ
    ''' </summary>
    Friend SynonTable As SynonDataTable = Nothing


    ''' <summary>
    ''' Таблица для хранения временных данных при создании АПУ
    ''' </summary>
    Private TmpTable As DataTable = Nothing


    Friend Sub New()
        '
        ' Me
        '
        MyBase.New("ApuData")
        ApuTable = New ApuDataTable
        LawTable = New LawDataTable
        ApuLawTable = New ApuLawDataTable
        TnvedTable = New TnvedDataTable
        LawTnvedTable = New LawTnvedDataTable
        SynonTable = New SynonDataTable
        Me.Tables.AddRange(New DataTable() {ApuTable, LawTable, ApuLawTable, TnvedTable, LawTnvedTable, SynonTable})
        Dim Relation As New DataRelation("ApuLawRelation", ApuTable.Columns("id"), ApuLawTable.Columns("apuId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("LawApuRelation", LawTable.Columns("id"), ApuLawTable.Columns("lawId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("LawTnvedRelation", LawTable.Columns("id"), LawTnvedTable.Columns("lawId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("TnvedLawRelation", TnvedTable.Columns("code"), LawTnvedTable.Columns("code"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        '
        ' TmpTable
        '
        TmpTable = New DataTable("TmpTable")
        With TmpTable.Columns
            .Add("id", GetType(Integer))        ' ID
            .Add("lawId", GetType(Integer))     ' ID пункта контрольного списка
            .Add("i1", GetType(Integer))        ' ID пункта АПУ 1-го уровня
            .Add("c1", GetType(String))         ' Наименование пункта АПУ 1-го уровня
            .Add("i2", GetType(Integer))        ' ID пункта АПУ 2-го уровня
            .Add("c2", GetType(String))         ' Наименование пункта АПУ 2-го уровня
            .Add("i3", GetType(Integer))        ' ID пункта АПУ 3-го уровня
            .Add("c3", GetType(String))         ' Наименование пункта АПУ 3-го уровня
            .Add("i4", GetType(Integer))        ' ID пункта АПУ 4-го уровня
            .Add("c4", GetType(String))         ' Наименование пункта АПУ 3-го уровня
            .Add("i5", GetType(Integer))        ' ID пункта АПУ 5-го уровня
            .Add("c5", GetType(String))         ' Наименование пункта АПУ 5-го уровня
            .Add("i6", GetType(Integer))        ' ID пункта АПУ 6-го уровня
            .Add("c6", GetType(String))         ' Наименование пункта АПУ 6-го уровня
            .Add("i7", GetType(Integer))        ' ID пункта АПУ 7-го уровня
            .Add("c7", GetType(String))         ' Наименование пункта АПУ 7-го уровня
            .Add("i8", GetType(Integer))        ' ID пункта АПУ 8-го уровня
            .Add("c8", GetType(String))         ' Наименование пункта АПУ 8-го уровня
            .Add("i9", GetType(Integer))        ' ID пункта АПУ 9-го уровня
            .Add("c9", GetType(String))         ' Наименование пункта АПУ 9-го уровня
            .Add("i10", GetType(Integer))       ' ID пункта АПУ 10-го уровня
            .Add("c10", GetType(String))        ' Наименование пункта АПУ 10-го уровня
        End With
        With TmpTable.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        TmpTable.PrimaryKey = New DataColumn() {TmpTable.Columns("id")}
    End Sub

    ''' <summary>
    ''' Очистить все таблицы от всех данных
    ''' </summary>
    Public Shadows Sub Clear()
        ApuLawTable.Rows.Clear()
        LawTnvedTable.Rows.Clear()
        ApuTable.Rows.Clear()
        LawTable.Rows.Clear()
        TnvedTable.Rows.Clear()
    End Sub

    ''' <summary>
    ''' Создать новый АПУ на основе контрольных списков
    ''' </summary>
    ''' <param name="AppForm">Форма приложения для вывода промежуточной информации в заголовке формы</param>
    Friend Sub ApuCreate(ByRef AppForm As Form)
        Dim oldFormText As String = Nothing
        If Not AppForm Is Nothing Then oldFormText = AppForm.Text
        '
        ' TmpTable: Добавление строк
        '
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim iTmp As Integer = 0
        Dim arr() As String = Nothing   ' массив пунктов АПУ текущего пункта списка
        Dim arr1() As String = Nothing  ' массив строк текущего пункта АПУ
        TmpTable.Rows.Clear()
        For i As Integer = 0 To LawTable.Rows.Count - 1
            If Not AppForm Is Nothing Then
                AppForm.Text = String.Format("TmpTable: Добавление строк ({0} из {1})", i + 1, LawTable.Rows.Count)
                Application.DoEvents()
            End If
            sTmp = ToText(LawTable(i)("apu"))
            If Not IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace(vbCrLf, FIELD_SEPARATOR)
            arr = sTmp.Split(New Char() {"="}, StringSplitOptions.RemoveEmptyEntries)
            For n = arr.GetLowerBound(0) To arr.GetUpperBound(0)
                Row = TmpTable.NewRow
                Row("lawId") = LawTable(i)("id")
                arr1 = ToText(arr(n)).Split(New Char() {FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                For j As Integer = arr1.GetLowerBound(0) To arr1.GetUpperBound(0)
                    If Not IsText(arr1(j)) Then Exit For
                    Select Case j
                        Case 0 : Row("c1") = ToText(arr1(j))
                        Case 1 : Row("c2") = ToText(arr1(j))
                        Case 2 : Row("c3") = ToText(arr1(j))
                        Case 3 : Row("c4") = ToText(arr1(j))
                        Case 4 : Row("c5") = ToText(arr1(j))
                        Case 5 : Row("c6") = ToText(arr1(j))
                        Case 6 : Row("c7") = ToText(arr1(j))
                        Case 7 : Row("c8") = ToText(arr1(j))
                        Case 8 : Row("c9") = ToText(arr1(j))
                        Case 9 : Row("c10") = ToText(arr1(j))
                    End Select
                Next
                If IsDBNull(Row("c1")) Then Continue For
                '
                ' Добавление нового пункта АПУ
                '
                TmpTable.Rows.Add(Row)
                '
                ' Добавление пунктов-синонимов текущего пункта АПУ
                '
                For l As Integer = 0 To SynonTable.Rows.Count - 1
                    If Not IsText(SynonTable(l)("word2")) Then Continue For
                    sTmp1 = ToText(SynonTable(l)("word1"))
                    If String.IsNullOrWhiteSpace(sTmp1) Then Continue For
                    sTmp1 = sTmp1.Replace(vbCrLf, FIELD_SEPARATOR)
                    sTmp = ToText(arr(n))
                    If InStr(sTmp, sTmp1) <> 1 Then Continue For
                    Row = TmpTable.NewRow
                    Row("lawId") = LawTable(i)("id")
                    sTmp = ToText(SynonTable(l)("word2")).Replace(vbCrLf, FIELD_SEPARATOR) & sTmp.Substring(sTmp1.Length)
                    arr1 = sTmp.Split(New Char() {FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                    For j As Integer = arr1.GetLowerBound(0) To arr1.GetUpperBound(0)
                        If Not IsText(arr1(j)) Then Exit For
                        Select Case j
                            Case 0 : Row("c1") = ToText(arr1(j))
                            Case 1 : Row("c2") = ToText(arr1(j))
                            Case 2 : Row("c3") = ToText(arr1(j))
                            Case 3 : Row("c4") = ToText(arr1(j))
                            Case 4 : Row("c5") = ToText(arr1(j))
                            Case 5 : Row("c6") = ToText(arr1(j))
                            Case 6 : Row("c7") = ToText(arr1(j))
                            Case 7 : Row("c8") = ToText(arr1(j))
                            Case 8 : Row("c9") = ToText(arr1(j))
                            Case 9 : Row("c10") = ToText(arr1(j))
                        End Select
                    Next
                    If Not IsDBNull(Row("c1")) Then TmpTable.Rows.Add(Row)
                Next
            Next
            '
            ' Добавление номеров CAS из текущего пункта контрольного списка
            '
            sTmp = ToText(LawTable(i)("posDescription"))
            Do
                iTmp = InStr(sTmp, "CAS ")
                If iTmp = 0 Then Exit Do
                sTmp = sTmp.Substring(iTmp + 3)
                sTmp1 = Nothing
                For j As Integer = 0 To sTmp.Length - 1
                    If Not sTmp(j) Like "[0123456789-]" Then Exit For
                    sTmp1 &= sTmp(j)
                Next
                If Not String.IsNullOrWhiteSpace(sTmp1) AndAlso sTmp1.Length > 3 Then
                    Row = TmpTable.NewRow
                    Row("lawId") = LawTable(i)("id")
                    Row("c1") = "CAS (номера)"
                    Row("c2") = sTmp1
                    TmpTable.Rows.Add(Row)
                End If
            Loop
        Next
        '
        ' TmpTable: Вычисление ID
        '
        iTmp = 99   ' с 1 по 99 зарезервировано за алфавитом
        Using V As New DataView(TmpTable) With {.Sort = "c1, c2, c3, c4, c5, c6, c7, c8, c9, c10"}
            '
            ' ID 1-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 1-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If i = 0 Then
                    iTmp += 1
                    V(i)("i1") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i1") = V(i - 1)("i1")
                    Else
                        iTmp += 1
                        V(i)("i1") = iTmp
                    End If
                End If
            Next
            '
            ' ID 2-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 2-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c2")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i2")) Then
                    iTmp += 1
                    V(i)("i2") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i2") = V(i - 1)("i2")
                    Else
                        iTmp += 1
                        V(i)("i2") = iTmp
                    End If
                End If
            Next
            '
            ' ID 3-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 3-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c3")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i3")) Then
                    iTmp += 1
                    V(i)("i3") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i3") = V(i - 1)("i3")
                    Else
                        iTmp += 1
                        V(i)("i3") = iTmp
                    End If
                End If
            Next
            '
            ' ID 4-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 4-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c4")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i4")) Then
                    iTmp += 1
                    V(i)("i4") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i4") = V(i - 1)("i4")
                    Else
                        iTmp += 1
                        V(i)("i4") = iTmp
                    End If
                End If
            Next
            '
            ' ID 5-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 5-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c5")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i5")) Then
                    iTmp += 1
                    V(i)("i5") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper & _
                        V(i)("c5").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper & _
                        V(i - 1)("c5").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i5") = V(i - 1)("i5")
                    Else
                        iTmp += 1
                        V(i)("i5") = iTmp
                    End If
                End If
            Next
            '
            ' ID 6-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 6-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c6")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i6")) Then
                    iTmp += 1
                    V(i)("i6") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper & _
                        V(i)("c5").ToString.ToUpper & V(i)("c6").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper & _
                        V(i - 1)("c5").ToString.ToUpper & V(i - 1)("c6").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i6") = V(i - 1)("i6")
                    Else
                        iTmp += 1
                        V(i)("i6") = iTmp
                    End If
                End If
            Next
            '
            ' ID 7-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 7-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c7")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i7")) Then
                    iTmp += 1
                    V(i)("i7") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper & _
                        V(i)("c5").ToString.ToUpper & V(i)("c6").ToString.ToUpper & V(i)("c7").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper & _
                        V(i - 1)("c5").ToString.ToUpper & V(i - 1)("c6").ToString.ToUpper & V(i - 1)("c7").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i7") = V(i - 1)("i7")
                    Else
                        iTmp += 1
                        V(i)("i7") = iTmp
                    End If
                End If
            Next
            '
            ' ID 8-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 8-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c8")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i8")) Then
                    iTmp += 1
                    V(i)("i8") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper & _
                        V(i)("c5").ToString.ToUpper & V(i)("c6").ToString.ToUpper & V(i)("c7").ToString.ToUpper & V(i)("c8").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper & _
                        V(i - 1)("c5").ToString.ToUpper & V(i - 1)("c6").ToString.ToUpper & V(i - 1)("c7").ToString.ToUpper & V(i - 1)("c8").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i8") = V(i - 1)("i8")
                    Else
                        iTmp += 1
                        V(i)("i8") = iTmp
                    End If
                End If
            Next
            '
            ' ID 9-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 9-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c9")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i9")) Then
                    iTmp += 1
                    V(i)("i9") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper & _
                        V(i)("c5").ToString.ToUpper & V(i)("c6").ToString.ToUpper & V(i)("c7").ToString.ToUpper & V(i)("c8").ToString.ToUpper & V(i)("c9").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper & _
                        V(i - 1)("c5").ToString.ToUpper & V(i - 1)("c6").ToString.ToUpper & V(i - 1)("c7").ToString.ToUpper & V(i - 1)("c8").ToString.ToUpper & V(i - 1)("c9").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i9") = V(i - 1)("i9")
                    Else
                        iTmp += 1
                        V(i)("i9") = iTmp
                    End If
                End If
            Next
            '
            ' ID 10-го уровня
            '
            For i As Integer = 0 To V.Count - 1
                If Not AppForm Is Nothing Then
                    AppForm.Text = String.Format("TmpTable: ID 10-го уровня ({0} из {1})", i + 1, V.Count)
                    Application.DoEvents()
                End If
                If IsDBNull(V(i)("c10")) Then Continue For
                If i = 0 OrElse IsDBNull(V(i - 1)("i10")) Then
                    iTmp += 1
                    V(i)("i10") = iTmp
                Else
                    sTmp = V(i)("c1").ToString.ToUpper & V(i)("c2").ToString.ToUpper & V(i)("c3").ToString.ToUpper & V(i)("c4").ToString.ToUpper & _
                        V(i)("c5").ToString.ToUpper & V(i)("c6").ToString.ToUpper & V(i)("c7").ToString.ToUpper & V(i)("c8").ToString.ToUpper & V(i)("c9").ToString.ToUpper & V(i)("c10").ToString.ToUpper
                    sTmp1 = V(i - 1)("c1").ToString.ToUpper & V(i - 1)("c2").ToString.ToUpper & V(i - 1)("c3").ToString.ToUpper & V(i - 1)("c4").ToString.ToUpper & _
                        V(i - 1)("c5").ToString.ToUpper & V(i - 1)("c6").ToString.ToUpper & V(i - 1)("c7").ToString.ToUpper & V(i - 1)("c8").ToString.ToUpper & V(i - 1)("c9").ToString.ToUpper & V(i - 1)("c10").ToString.ToUpper
                    If sTmp = sTmp1 Then
                        V(i)("i10") = V(i - 1)("i10")
                    Else
                        iTmp += 1
                        V(i)("i10") = iTmp
                    End If
                End If
            Next
        End Using
        '
        ' ApuTable: Добавление строк
        '
        ApuLawTable.Rows.Clear()
        ApuTable.Rows.Clear()
        For i As Integer = 0 To TmpTable.Rows.Count - 1
            If Not AppForm Is Nothing Then
                AppForm.Text = String.Format("ApuTable: Добавление строк ({0} из {1})", i + 1, TmpTable.Rows.Count)
                Application.DoEvents()
            End If
            If Not IsDBNull(TmpTable(i)("i1")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i1")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i1"), DBNull.Value, TmpTable(i)("c1"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i2")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i2")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i2"), TmpTable(i)("i1"), TmpTable(i)("c2"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i3")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i3")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i3"), TmpTable(i)("i2"), TmpTable(i)("c3"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i4")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i4")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i4"), TmpTable(i)("i3"), TmpTable(i)("c4"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i5")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i5")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i5"), TmpTable(i)("i4"), TmpTable(i)("c5"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i6")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i6")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i6"), TmpTable(i)("i5"), TmpTable(i)("c6"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i7")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i7")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i7"), TmpTable(i)("i6"), TmpTable(i)("c7"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i8")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i8")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i8"), TmpTable(i)("i7"), TmpTable(i)("c8"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i9")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i9")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i9"), TmpTable(i)("i8"), TmpTable(i)("c9"), 0})
            End If
            If Not IsDBNull(TmpTable(i)("i10")) AndAlso ApuTable.Rows.Find(TmpTable(i)("i10")) Is Nothing Then
                ApuTable.Rows.Add(New Object() {TmpTable(i)("i10"), TmpTable(i)("i9"), TmpTable(i)("c10"), 0})
            End If
        Next
        '
        ' ApuTable: Алфавит
        '
        sTmp = Nothing
        iTmp = 0
        Using AlphTable As New ApuDataTable
            Using V As New DataView(ApuTable) With {.Sort = "caption", .RowFilter = "parentId IS NULL"}
                While V.Count > 0
                    sTmp1 = V(0)("caption").ToString(0).ToString.ToUpper
                    If Not AppForm Is Nothing Then
                        AppForm.Text = String.Format("ApuTable: Алфавит ({0})", sTmp1)
                        Application.DoEvents()
                    End If
                    If String.IsNullOrWhiteSpace(sTmp) OrElse sTmp1 <> sTmp Then
                        sTmp = sTmp1
                        iTmp += 1
                        AlphTable.Rows.Add(New Object() {iTmp, DBNull.Value, sTmp, 0})
                    End If
                    V(0)("parentId") = iTmp
                End While
            End Using
            For i As Integer = 0 To AlphTable.Rows.Count - 1
                ApuTable.Rows.Add(AlphTable.Rows(i).ItemArray)
            Next
        End Using
        '
        ' ApuTable: Сортировка строк
        '
        If Not AppForm Is Nothing Then
            AppForm.Text = "ApuTable: Сортировка строк ..."
            Application.DoEvents()
        End If
        ApuTable.UpdateSortId()
        '
        ' ApuLawTable: Добавление строк
        '
        For i As Integer = 0 To TmpTable.Rows.Count - 1
            If Not AppForm Is Nothing Then
                AppForm.Text = String.Format("ApuLawTable: Добавление строк ({0} из {1})", i + 1, TmpTable.Rows.Count)
                Application.DoEvents()
            End If
            If Not IsDBNull(TmpTable(i)("i1")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i1"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i1"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i2")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i2"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i2"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i3")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i3"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i3"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i4")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i4"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i4"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i5")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i5"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i5"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i6")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i6"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i6"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i7")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i7"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i7"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i8")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i8"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i8"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i9")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i9"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i9"), TmpTable(i)("lawId")})
            End If
            If Not IsDBNull(TmpTable(i)("i10")) AndAlso ApuLawTable.Rows.Find(New Object() {TmpTable(i)("i10"), TmpTable(i)("lawId")}) Is Nothing Then
                ApuLawTable.Rows.Add(New Object() {TmpTable(i)("i10"), TmpTable(i)("lawId")})
            End If
        Next
        If Not AppForm Is Nothing Then AppForm.Text = oldFormText
    End Sub

    ''' <summary>
    ''' Выделить связанные пункты контрольных списков для пункта АПУ
    ''' </summary>
    ''' <param name="apuId">ID пункта АПУ</param>
    Friend Sub CheckApuLaw(apuId As Integer)
        LawTable.CheckClear()
        Dim Row As DataRow = Nothing
        Using V As New DataView(ApuLawTable)
            V.RowFilter = String.Format("apuId = {0}", apuId)
            For i As Integer = 0 To V.Count - 1
                Row = LawTable.Rows.Find(V(i)("lawId"))
                If Not Row Is Nothing Then Row("isSel") = True
            Next
        End Using
    End Sub

End Class
