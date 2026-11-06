Imports C2 = Cprp.DxData.Common
Partial Public Class LawDataSet


    ''' <summary>
    ''' Возвращает строку ID родительских пунктов, разделенных запятыми, по ID дочернего пункта
    ''' </summary>
    ''' <param name="childId">ID дочернего пункта</param>
    ''' <param name="addCommentId">Добавлять ID примечаний к родительским пунктам</param> 
    ''' <remarks></remarks>
    Public Function GetParentIdByChildId(ByVal childId As Object, ByVal addCommentId As Boolean) As String
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = C2.ToInt(childId)
        Dim Row As DataRow = LawTable.Rows.Find(iTmp)
        If Row Is Nothing OrElse IsDBNull(Row("parentId")) OrElse C2.ToInt(Row("parentId")) = iTmp Then Return Nothing
        iTmp = CInt(Row("parentId"))
        sTmp = String.Format("{0}, {1}", iTmp, GetParentIdByChildId(iTmp, addCommentId))
        ' Добавление ID примечаний к родительскому пункту
        If addCommentId Then
            Using V As New DataView(LawTable)
                V.RowFilter = String.Format("parentId = {0} AND typeId = {1}", iTmp, CInt(TypeEnum.IsComment))
                For i As Integer = 0 To V.Count - 1
                    sTmp &= String.Format("{0}, ", CInt(V(i)("id")))
                Next
            End Using
        End If
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает строку ID дочерних пунктов, разделенных запятыми, по ID родительского пункта
    ''' </summary>
    ''' <param name="parentId">ID родительского пункта</param>
    ''' <param name="addCommentId">Добавлять ID примечаний к родительскому пункту</param> 
    ''' <remarks></remarks>
    Public Function GetChildIdByParentId(ByVal parentId As Object, ByVal addCommentId As Boolean) As String
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = C2.ToInt(parentId)
        Using V As New DataView(LawTable)
            V.RowFilter = String.Format("parentId = {0}", iTmp)
            If Not addCommentId Then V.RowFilter &= String.Format(" AND typeId <> {0}", CInt(TypeEnum.IsComment))
            If V.Count = 0 Then Return Nothing
            For i As Integer = 0 To V.Count - 1
                iTmp = CInt(V(i)("id"))
                sTmp &= String.Format("{0}, {1}", iTmp, GetChildIdByParentId(iTmp, addCommentId))
            Next
        End Using
        Return sTmp
    End Function

    ''' <summary>
    ''' Возавращает полное дерево пункта по его ID
    ''' </summary>
    ''' <param name="rowId">ID пункта</param>
    ''' <param name="addComment">Включить примечания в дерево пункта</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRowTreeById(rowId As Object, addComment As Boolean) As String
        Dim iTmp As Integer = C2.ToInt(rowId)
        If LawTable.Rows.Find(iTmp) Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Using V As New DataView(Me.LawTable)
            V.RowFilter = String.Format("id IN ({0}, {1}{2} 0)", iTmp, GetParentIdByChildId(iTmp, addComment), GetChildIdByParentId(iTmp, addComment))
            V.Sort = "doc, id"
            Dim bTmp As Boolean = False
            For i As Integer = 0 To V.Count - 1
                If Not bTmp Then bTmp = (CInt(V(i)("typeId")) = CInt(Cprp.DxData.Law.TypeEnum.IsLevel2)) ' найден заголовок документа
                If bTmp Then sTmp = String.Format("{0}{1}{2}", sTmp, vbCrLf, C2.ToText(V(i)("posDescription")))
            Next
        End Using
        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = sTmp.Substring(2)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает строку ID связанных пунктов (с дочерними пунктами), по ID основного пункта
    ''' </summary>
    ''' <param name="lawId">ID основного пункта</param>
    ''' <remarks></remarks>
    Public Function GetLinkIdByLawId(lawId As Object) As String
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = C2.ToInt(lawId)
        Using V As New DataView(LinkTable)
            V.RowFilter = String.Format("lawId = {0}", iTmp)
            If V.Count = 0 Then Return Nothing
            For i As Integer = 0 To V.Count - 1
                iTmp = CInt(V(i)("linkId"))
                sTmp &= String.Format("{0}, {1}", iTmp, GetChildIdByParentId(iTmp, True))
            Next
        End Using
        Return C2.ToStrNum(sTmp, False)
    End Function

End Class