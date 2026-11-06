Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout
Imports C2 = Cprp.DxData.Common
' ===========================================================
' Свойства и методы для работы с проектом итогового документа
' ===========================================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Создать проект итогового документа
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ProjectCreate()

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing       ' Документ
        Dim nullText As String = "{нет данных}"
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document

        ' ЗАГРУЗКА ШАБЛОНА ЗАКЛЮЧЕНИЯ И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона заключения
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("КОНСУЛЬТАЦИЯЗАКЛЮЧЕНИЕ", Me.Connection)

        ' Номер и дата заключения - тело документа
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today), nullText)

        ' Номер и дата заключения - колонтитул
        Dim Hd As SubDocument = R.Document.Sections(0).BeginUpdateHeader
        PutBookmark(Hd, "DocNum2", Nothing, "{Проект}")
        PutBookmark(Hd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
        R.Document.Sections(0).EndUpdateHeader(Hd)

        ' Наименование, ИНН, КПП заказачика
        sTmp = C2.ToText(Me("clientName"))
        If C2.IsText(sTmp) Then
            If C2.IsText(Me("clientInn")) Then
                sTmp = String.Format("{0}<br>ИНН {2}", sTmp, vbCrLf, C2.ToText(Me("clientInn")))
                If C2.IsText(Me("clientKpp")) Then sTmp = String.Format("{0}, КПП {1}", sTmp, C2.ToText(Me("clientKpp")))
            End If
        End If
        PutHtmlRange(R.Document.Bookmarks("ClientCaption").Range, sTmp, nullText)

        ' Адрес заказчика
        PutBookmark(R.Document, "ClientAddress", C2.ToText(Me("clientAddress")), nullText)

        ' Номер заказа
        sTmp = C2.ToText(Me("orderNum"))
        PutBookmark(R.Document, "OrderNum", sTmp, nullText)

        ' Дата заказа
        sTmp = Nothing
        If Not IsDBNull(Me("orderDate")) Then sTmp = String.Format("{0:dd.MM.yyyy}", CDate(Me("orderDate")))
        PutBookmark(R.Document, "OrderDate", sTmp, nullText)

        ' Вопросы, поставленные на разрешение эксперту
        '
        sTmp = Nothing
        Using V As New DataView(Me.QueryTable)
            V.Sort = "rowNum"
            If V.Count = 1 Then
                sTmp = C2.AddPoint(V(0)("ask"))
                If C2.IsText(sTmp) Then sTmp = String.Format("<p style='margin:0'>{0}</p>", _
                    sTmp.Replace(vbCrLf, "</p><p style='margin:0'>"))
            ElseIf V.Count > 1 Then
                For i As Integer = 0 To V.Count - 1
                    sTmp1 = C2.AddPoint(V(i)("ask"))
                    If C2.IsText(sTmp1) Then sTmp = String.Format("{0}<p style='margin:0'>{1}) {2}</p>", _
                        sTmp, C2.ToText(V(i)("rowNum")), sTmp1.Replace(vbCrLf, "</p><p style='margin:0'>"))
                Next
            End If
        End Using
        PutHtmlRange(R.Document.Bookmarks("ask").Range, sTmp, nullText)

        ' Результат консультации
        '
        sTmp = Nothing
        Using V As New DataView(Me.QueryTable)
            V.Sort = "rowNum"
            If V.Count = 1 Then
                sTmp = C2.AddPoint(V(0)("ans"))
                If C2.IsText(sTmp) Then sTmp = String.Format("<p style='margin:0'>{0}</p>", _
                    sTmp.Replace(vbCrLf, "</p><p style='margin:0'>"))
            ElseIf V.Count > 1 Then
                For i As Integer = 0 To V.Count - 1
                    sTmp1 = C2.AddPoint(V(i)("ans"))
                    If C2.IsText(sTmp1) Then sTmp = String.Format("{0}<p style='margin:0'><b><i>По вопросу № {1}:</i></b></p><p style='margin:0'>{2}</p>", _
                        sTmp, C2.ToText(V(i)("rowNum")), sTmp1.Replace(vbCrLf, "</p><p style='margin:0'>"))
                Next
            End If
        End Using
        PutHtmlRange(R.Document.Bookmarks("ans").Range, sTmp, nullText)

        ' Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")

        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА И СВЕДЕНИЙ О НЕМ В ИСТОЧНИК ДАННЫХ РАБОТЫ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Сохранение содержимого проекта документа
        '
        Me.ARow("doc1Data") = R.Document.OpenXmlBytes
        Me.ARow("doc1SummaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsFreedom)

        R.Dispose()

    End Sub

End Class
