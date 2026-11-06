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
    Public Sub ProjectCreate()

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing       ' Документ
        Dim sTmp As String = Nothing

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document

        ' ЗАГРУЗКА ШАБЛОНА ЗАПРОСА И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' +++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона документа
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ИСХОДЯЩЕЕПИСЬМО", Me.Connection)

        R.Document.BeginUpdate()

        ' Номер и дата запроса
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today))

        ' Наименование заказачика
        PutBookmark(R.Document, "ClientCaption", C2.ToText(Me("clientName")))

        ' Реквизиты руководителя (в 2-х местах)
        sTmp = C2.ToText(Me("clientInn"))
        If C2.IsText(sTmp) Then
            Dim leaderPost As String = Nothing
            Dim leaderName As String = Nothing
            Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT post, nameLong FROM tMemberPerson WHERE inn LIKE '{0}'", sTmp))
                If Dr.Read Then
                    leaderPost = C2.ToText(Dr("post"))
                    leaderName = C2.ToText(Dr("nameLong"))
                End If
                Dr.Close()
            End Using
            ' кому
            If C2.IsText(leaderPost) AndAlso C2.IsText(leaderName) Then
                sTmp = leaderName
                If sTmp Like "?* ?* ?*" Then
                    Dim arr() As String = sTmp.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                    If arr.Length > 2 Then
                        sTmp = String.Format("{0} {1}.{2}.", arr(0), arr(1).Substring(0, 1), arr(2).Substring(0, 1))
                    End If
                End If
                PutHtmlRange(R.Document.Bookmarks("LeaderPost").Range, String.Format("<span style='color:#ff0000'>{0}<br>{1}</style>", leaderPost, sTmp))
            End If
            ' уважаемый
            If C2.IsText(leaderName) Then
                sTmp = leaderName
                If sTmp Like "?* ?* ?*" Then
                    sTmp = sTmp.Substring(sTmp.IndexOf(" ") + 1)
                End If
                PutBookmark(R.Document, "LeaderName", sTmp)
            End If
        End If

        ' Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")

        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА
        ' ++++++++++++++++++++
        '
        Me.ARow("doc1Data") = R.OpenXmlBytes
        R.Dispose()

    End Sub

End Class
