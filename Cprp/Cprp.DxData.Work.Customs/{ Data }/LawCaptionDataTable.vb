''' <summary>
''' Разделы Единого перечня в отношении которых проводилась экспертиза
''' </summary>
''' <remarks></remarks>
Friend Class LawCaptionDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("LawCaptionTable")
        Me.Columns.Add("lawId", GetType(Integer))   ' ID заголовка раздела из tLaw
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId")}
    End Sub

    ''' <summary>
    ''' Возвращает строку ID заголовков разделов, разделенных запятыми
    ''' </summary>
    ''' <remarks>Если таблица пустая, возвращает Nothing</remarks>
    Friend Function StrId() As String
        Dim sTmp As String = Nothing
        For Each Row As DataRow In Me.Rows
            sTmp = String.Format("{0}, {1}", sTmp, CInt(Row("lawId")))
        Next
        If String.IsNullOrWhiteSpace(sTmp) Then Return Nothing
        Return sTmp.Substring(2)
    End Function

End Class