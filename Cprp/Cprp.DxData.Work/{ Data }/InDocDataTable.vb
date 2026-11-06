Imports C2 = Cprp.DxData.Common
''' <summary>
''' Перечень материалов и документов, использованных при выполнении работы
''' </summary>
''' <remarks></remarks>
Public Class InDocDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Работа
    ''' </summary>
    Private _Work As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.InDocDataTable
    ''' </summary>
    ''' <param name="Work">Работа</param> 
    ''' <remarks></remarks>
    Public Sub New(Work As WorkConnectionRow)
        '
        ' Me
        '
        MyBase.New("InDocTable")
        Me.Columns.Add("id", GetType(Integer))                  ' id
        Me.Columns.Add("dbId", GetType(Integer))                ' id строки в базе данных
        Me.Columns.Add("rowNum", GetType(Integer))              ' порядковый номер в работе
        Me.Columns.Add("kindId", GetType(Integer))              ' вид документа (1 - входящий, 2 - исходящий, 3 - внутренний)
        Me.Columns.Add("typeId", GetType(Integer))              ' тип документа (0 - неизвестный, 1 - заключение, 2 - план, 3 - запрос)
        Me.Columns.Add("caption", GetType(String))              ' заголовок или краткое содержание
        Me.Columns.Add("regNum", GetType(String))               ' регистрационный номер автора документа
        Me.Columns.Add("regDate", GetType(Date))                ' дата регистрации
        Me.Columns.Add("isSel", GetType(Boolean))               ' отмечен (да/нет)
        Me.Columns.Add("docType", GetType(String))              ' вид документа
        Me.Columns.Add("author", GetType(String))               ' автор документа
        ' поля из таблицы взаимодействия с ЭО
        Me.Columns.Add("eoId", GetType(Integer))                ' id документа в ЭО
        Me.Columns.Add("CrmDocumentId", GetType(String))        ' id документа в CRM
        Me.Columns.Add("orderId", GetType(Integer))             ' id заказа в ЭО
        Me.Columns.Add("CrmOrderId", GetType(String))           ' id заказа в CRM
        Me.Columns.Add("docUrl", GetType(String))               ' url документа в ЭО
        Me.Columns.Add("ext", GetType(String))                  ' вид файла документа
        Me.Columns.Add("isUsed", GetType(Boolean))              ' документ использован в текущей работе (да/нет)
        Me.Columns.Add("isChanged", GetType(Boolean))           ' документ изменен на стороне ЭС
        Me.Columns.Add("actDate", GetType(Date))
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("isSel")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isUsed")
            .AllowDBNull = False
            .DefaultValue = True
        End With
        With Me.Columns("isChanged")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.Columns("caption").MaxLength = 500
        Me.Columns("regNum").MaxLength = 250
        With Me.Columns("rowNum")
            .AllowDBNull = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' _Work
        '
        _Work = Work
    End Sub

    ''' <summary>
    ''' Представление с использованными документами
    ''' </summary>
    ''' <remarks></remarks>
    Public Function UsedView() As DataView
        Return New DataView(Me) With {.RowFilter = "isUsed = True"}
    End Function

    ''' <summary>
    ''' Добавить новую строку с предзаполненными обязательными полями
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AddNew() As DataRow
        Dim R As DataRow = Me.NewRow
        R("rowNum") = GetNewRowNum()
        R("typeId") = 0 ' неизвестный тип
        R("kindId") = 1 ' входящий документ
        Me.Rows.Add(R)
        Return R
    End Function

    ''' <summary>
    ''' Возвращает заголовок, номер и дату строки таблицы документов
    ''' </summary>
    ''' <param name="DocRow">Строка таблицы документов</param>
    Public Function GetCaptionNumDate(DocRow As DataRow) As String
        If DocRow Is Nothing OrElse DocRow.Table Is Nothing OrElse Not DocRow.Table Is Me Then Return Nothing
        Dim sTmp As String = C2.DelPoint(DocRow("caption"))
        If C2.IsText(DocRow("regNum")) Then sTmp = String.Format("{0} № {1}", sTmp, C2.ToText(DocRow("regNum")))
        If Not IsDBNull(DocRow("regDate")) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(DocRow("regDate")))
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает новый порядковый номер в списке объектов экспертизы
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewRowNum() As Integer
        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        For Each Row As DataRow In Me.Rows
            If Row.RowState = DataRowState.Deleted OrElse Row.RowState = DataRowState.Detached Then Continue For
            iTmp1 = CInt(Row("rowNum"))
            If iTmp1 > iTmp Then iTmp = iTmp1
        Next
        Return (iTmp + 1)
    End Function

    ''' <summary>
    ''' Загрузить данные из таблицы взаимодействия с ЭО
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadFromEO()
        Dim orderId As Integer = C2.ToInt(_Work("orderId"))
        Dim CrmOrderId As String = C2.ToText(_Work("CrmOrderId"))
        '
        ' Таблица документов по заказу из ЭО
        '
        Dim T As New DataTable
        If orderId > 0 Then
            T.Load(_Work.ExecuteReader(String.Format("SELECT * FROM t2Doc2 WHERE orderId = {0}", orderId)))
        Else
            T.Load(_Work.ExecuteReader(String.Format("SELECT * FROM t2Doc2 WHERE CrmOrderId = '{0}'", CrmOrderId)))
        End If

        If T.Rows.Count = 0 Then
            T.Dispose()
            Exit Sub
        End If
        '
        ' Загрузка сведений о документах в текущую таблицу
        '
        Using V As New DataView(Me)
            For Each Row As DataRow In T.Rows
                V.RowFilter = String.Format("eoId = {0} OR CrmDocumentId = '{1}'", C2.ToInt(Row("eoId")), C2.ToText(Row("CrmDocumentId")))
                If V.Count > 0 Then
                    V(0)("ext") = Row("ext")
                    Continue For
                End If
                With Me.AddNew
                    .Item("eoId") = Row("eoId")
                    .Item("CrmDocumentId") = Row("CrmDocumentId")
                    .Item("orderId") = Row("orderId")
                    .Item("CrmOrderId") = Row("CrmOrderId")
                    .Item("caption") = Row("description")
                    .Item("regNum") = Row("docNum")
                    .Item("regDate") = Row("docDate")
                    .Item("docUrl") = Row("docUrl")
                    .Item("ext") = Row("ext")
                    .Item("actDate") = Date.Now
                    .Item("isUsed") = True
                    .Item("isChanged") = False
                End With
            Next
            '
            ' Обновление полей с типом и видом документа
            '           
            Dim VRow As DataRowView = Nothing
            V.RowFilter = "typeId IS NULL OR kindId IS NULL"
            While V.Count > 0
                VRow = V(0)
                VRow("typeId") = 0  ' неизвестный тип
                VRow("kindId") = 1  ' входящий документ
            End While
        End Using
        T.Dispose()
    End Sub

    ''' <summary>
    ''' Загрузить данные в таблицу взаимодействия с ЭО
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveToEO()
        '
        ' Таблица документов по заказу из ЭО
        '
        Dim T As New DataTable
        T.Load(_Work.ExecuteReader(String.Format("SELECT * FROM t2Doc2 WHERE orderId = {0}", C2.ToInt(_Work("orderId")))))
        If T.Rows.Count = 0 Then
            T.Dispose()
            Exit Sub
        End If
        '
        ' Загрузка сведедений о документах из текущей таблицы
        '
        Using V As New DataView(Me)
            V.RowFilter = "(eoId > 0 OR CrmDocumentId > '') AND isChanged = True"
            For i As Integer = 0 To V.Count - 1
                For Each Row As DataRow In T.Rows
                    If C2.ToInt(V(i)("eoId")) <> C2.ToInt(Row("eoId")) AndAlso _
                        C2.ToText(V(i)("CrmDocumentId")) <> C2.ToText(Row("CrmDocumentId")) Then Continue For
                    Row("description") = V(i)("caption")
                    Row("docNum") = V(i)("regNum")
                    Row("docDate") = V(i)("regdate")
                    Row("isUsed") = V(i)("isUsed")
                    Row("isChanged") = True
                    _Work.MessageInputDocumentChangeEo(CInt(Row("eoId")))
                Next
            Next
        End Using
        Using A As New SqlDataAdapter("SELECT * FROM t2Doc2 WHERE eoId IS NULL", _Work.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(T)
        End Using
        T.Dispose()
        '
        ' Сброс isChanged в False по всем записям
        '
        For Each Row As DataRow In Me.Rows
            Row("isChanged") = False
        Next
    End Sub

    ''' <summary>
    ''' Поиск строки по docUrl
    ''' </summary>
    ''' <param name="docUrl">docUrl</param>
    Public Function FindByDocUrl(docUrl As String) As DataRow
        docUrl = C2.ToText(docUrl)
        If String.IsNullOrWhiteSpace(docUrl) Then Return Nothing
        docUrl = docUrl.ToUpper
        Dim sTmp As String = Nothing
        For Each Row As DataRow In Me.Rows
            sTmp = C2.ToText(Row("docUrl"))
            If String.IsNullOrWhiteSpace(sTmp) Then Continue For
            If sTmp.ToUpper = docUrl Then Return Row
        Next
        Return Nothing
    End Function


    Private Sub InDocDataTable_ColumnChanged(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanged
        Dim sTmp As String = e.Column.ColumnName.ToUpper
        If sTmp Like "CAPTION" OrElse sTmp Like "REGNUM" OrElse sTmp Like "REGDATE" Then e.Row("isChanged") = True
    End Sub

End Class
