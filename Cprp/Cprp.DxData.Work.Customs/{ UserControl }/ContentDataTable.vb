Imports C2 = Cprp.DxData.Common
''' <summary>
''' Содержание работы
''' </summary>
Friend Class ContentDataTable : Inherits DataTable

    ''' <summary>
    ''' Работа
    ''' </summary>
    Private Work As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.ContentDataTable
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <remarks></remarks>
    Public Sub New(Work As WorkConnectionRow)
        '
        ' Me
        '
        MyBase.New("ContentTable")
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID строки
            .Add("parentId", GetType(Integer))          ' ID родительской строки
            .Add("contentId", GetType(ContentEnum))     ' Идентификатор раздела
            .Add("objectId", GetType(Integer))          ' Идентификатор объекта в списке объектов раздела
            .Add("caption", GetType(String))            ' Наименование
        End With
        Me.Columns("contentId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' Work
        '
        MyClass.Work = Work
    End Sub

    ''' <summary>
    ''' Перечитать содержание работы
    ''' </summary>
    Public Sub DataReload()
        Me.Rows.Clear()
        If Work Is Nothing OrElse Work.IsEmpty Then Exit Sub
        If Work.Condition = WorkCondition.IsNew Then Exit Sub
        Dim sTmp As String = Nothing
        '
        ' ПЛАН РАБОТЫ
        '
        Me.Rows.Add(New Object() {ContentEnum.Plane, DBNull.Value, ContentEnum.Plane, C2.EMPTY_ID, "ПЛАН РАБОТЫ"})
        If Work.Condition = WorkCondition.IsPlaneWork OrElse Work.Condition = WorkCondition.IsPlaneAgree Then Exit Sub
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА
        '
        Me.Rows.Add(New Object() {ContentEnum.ContractData, DBNull.Value, ContentEnum.ContractData, C2.EMPTY_ID, "ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА"})

        Using V As New DataView(Work.MemberTable)

            If Not CBool(Work.ARow("isNotContract")) Then
                '
                ' Российские участники сделки
                '
                Me.Rows.Add(New Object() {ContentEnum.ContractRusList, ContentEnum.ContractData, _
                                          ContentEnum.ContractRusList, C2.EMPTY_ID, "РОССИЙСКИЕ УЧАСТНИКИ СДЕЛКИ"})
                V.RowFilter = "conRusNum > 0"
                V.Sort = "conRusNum"
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("nameLong"))
                    If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                    Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.ContractRusList, ContentEnum.ContractRusData, _
                                              CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("conRusNum")), sTmp)})
                Next
                '
                ' Иностранные участники сделки
                '
                Me.Rows.Add(New Object() {ContentEnum.ContractNusList, ContentEnum.ContractData, _
                                          ContentEnum.ContractNusList, C2.EMPTY_ID, "ИНОСТРАННЫЕ УЧАСТНИКИ СДЕЛКИ"})
                V.RowFilter = "conNusNum > 0"
                V.Sort = "conNusNum"
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("nameLong"))
                    If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                    Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.ContractNusList, ContentEnum.ContractNusData, _
                                              CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("conNusNum")), sTmp)})
                Next

            End If
            '
            ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ
            '
            Me.Rows.Add(New Object() {ContentEnum.SupplyData, DBNull.Value, ContentEnum.SupplyData, C2.EMPTY_ID, "ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ"})
            '
            ' Российские участники операции
            '
            Me.Rows.Add(New Object() {ContentEnum.SupplyRusList, ContentEnum.SupplyData, _
                                      ContentEnum.SupplyRusList, C2.EMPTY_ID, "РОССИЙСКИЕ УЧАСТНИКИ ОПЕРАЦИИ"})
            V.RowFilter = "supRusNum > 0"
            V.Sort = "supRusNum"
            For i As Integer = 0 To V.Count - 1
                sTmp = C2.DelPoint(V(i)("nameLong"))
                If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.SupplyRusList, ContentEnum.SupplyRusData, _
                                          CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("supRusNum")), sTmp)})
            Next
            '
            ' Иностранные покупатели (продавцы)
            '
            Me.Rows.Add(New Object() {ContentEnum.SupplyNusList, ContentEnum.SupplyData, _
                                      ContentEnum.SupplyNusList, C2.EMPTY_ID, "ИНОСТРАННЫЕ ПОКУПАТЕЛИ (ПРОДАВЦЫ)"})
            V.RowFilter = "supNusNum > 0"
            V.Sort = "supNusNum"
            For i As Integer = 0 To V.Count - 1
                sTmp = C2.DelPoint(V(i)("nameLong"))
                If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.SupplyNusList, ContentEnum.SupplyNusData, _
                                          CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("supNusNum")), sTmp)})
            Next
            '
            ' Потребители (конечные пользователи)
            '
            Me.Rows.Add(New Object() {ContentEnum.SupplyEndList, ContentEnum.SupplyData, _
                                      ContentEnum.SupplyEndList, C2.EMPTY_ID, "ПОТРЕБИТЕЛИ (КОНЕЧНЫЕ ПОЛЬЗОВАТЕЛИ)"})
            V.RowFilter = "supEndNum > 0"
            V.Sort = "supEndNum"
            For i As Integer = 0 To V.Count - 1
                sTmp = C2.DelPoint(V(i)("nameLong"))
                If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.SupplyEndList, ContentEnum.SupplyEndData, _
                                          CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("supEndNum")), sTmp)})
            Next

        End Using
        '
        ' ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)
        '
        Me.Rows.Add(New Object() {ContentEnum.GoodList, DBNull.Value, ContentEnum.GoodList, C2.EMPTY_ID, "ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)"})
        Using V As New DataView(Work.GoodTable)
            V.Sort = "rowNum"
            For i As Integer = 0 To V.Count - 1
                sTmp = C2.DelPoint(V(i)("nameCon"))
                If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.GoodList, ContentEnum.GoodData, _
                                          CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("rowNum")), sTmp)})
            Next
        End Using
        '
        ' РЕШЕНИЕ ПО АНАЛИЗУ
        '
        Me.Rows.Add(New Object() {ContentEnum.Summary, DBNull.Value, ContentEnum.Summary, C2.EMPTY_ID, "РЕШЕНИЕ ПО АНАЛИЗУ"})
        ''
        '' ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ 
        ''
        'Me.Rows.Add(New Object() {ContentEnum.ExtraInfo, DBNull.Value, ContentEnum.ExtraInfo, C2.EMPTY_ID, "ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ"})

    End Sub

End Class
