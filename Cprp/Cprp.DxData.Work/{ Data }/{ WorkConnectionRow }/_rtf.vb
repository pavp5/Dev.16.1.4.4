Imports DevExpress.XtraRichEdit.API.Native
Partial Public Class WorkConnectionRow

#Region "Служебные функции"

    Protected Shared Sub PutRange(ByVal R As DocumentRange, ByVal rangeText As String, Optional ByVal errorText As String = Nothing)
        With R.BeginUpdateDocument
            .Replace(R, Nothing)
            If Not String.IsNullOrWhiteSpace(rangeText) Then
                .InsertText(R.Start, rangeText)
            ElseIf Not String.IsNullOrWhiteSpace(errorText) Then
                .InsertHtmlText(R.Start, String.Format("<span style='font-weight:bold;color:#ff0000'>{0}</style>", errorText))
            End If
        End With
    End Sub

    Protected Shared Sub PutHtmlRange(ByVal R As DocumentRange, ByVal rangeHtmlText As String, Optional ByVal errorText As String = Nothing)
        With R.BeginUpdateDocument
            .Replace(R, Nothing)
            If Not String.IsNullOrWhiteSpace(rangeHtmlText) Then
                .InsertHtmlText(R.Start, rangeHtmlText)
            ElseIf Not String.IsNullOrWhiteSpace(errorText) Then
                .InsertHtmlText(R.Start, String.Format("<span style='font-weight:bold;color:#ff0000'>{0}</style>", errorText))
            End If
        End With
    End Sub

    Protected Shared Sub PutBookmark(ByVal Doc As SubDocument, ByVal bookmarkName As String, ByVal bookmarkText As String, Optional ByVal errorText As String = Nothing)
        If Doc.Bookmarks(bookmarkName) Is Nothing Then Exit Sub
        Dim bStart As Integer = Doc.Bookmarks(bookmarkName).Range.Start.ToInt
        Dim bEnd As Integer = (bookmarkText & vbNullString).Length
        If bEnd = 0 Then bEnd = (errorText & vbNullString).Length
        PutRange(Doc.Bookmarks(bookmarkName).Range, bookmarkText, errorText)
        If Doc.Bookmarks(bookmarkName) Is Nothing Then Doc.Bookmarks.Create(Doc.CreateRange(bStart, bEnd), bookmarkName)
    End Sub

#End Region

End Class
