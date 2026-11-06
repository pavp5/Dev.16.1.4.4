Imports C2 = Cprp.DxData.Common
Partial Public Class LawDataSet

    ''' <summary>
    ''' Возвращает заголовок документа по шифру строки документа
    ''' </summary>
    ''' <param name="doc">Шифр строки документа</param>
    Public Function GetLawCaptionByDoc(doc As String) As String
        doc = C2.ToText(doc)
        If Not C2.IsText(doc) OrElse doc.Length < 14 Then Return Nothing
        Using V As New DataView(LawTable)
            V.RowFilter = String.Format("typeId = {0} AND doc LIKE '{1}'", CInt(Cprp.DxData.Law.TypeEnum.IsLevel2), doc.Substring(0, 14))
            If V.Count > 0 Then Return V(0)("posDescription").ToString
            V.RowFilter = String.Format("typeId = {0} AND doc LIKE '{1}%'", CInt(Cprp.DxData.Law.TypeEnum.IsLevel2), doc.Substring(0, 9))
            If V.Count > 0 Then Return V(0)("posDescription").ToString
            V.RowFilter = String.Format("typeId = {0} AND doc LIKE '{1}%'", CInt(Cprp.DxData.Law.TypeEnum.IsLevel2), doc.Substring(0, 4))
            If V.Count > 0 Then Return V(0)("posDescription").ToString
        End Using
        Return Nothing
    End Function

    ''' <summary>
    ''' Возвращает номер раздела документа по шифру строки документа
    ''' </summary>
    ''' <param name="doc">Шифр строки документа</param>
    Public Function GetLawSectionByDoc(doc As String) As String
        doc = Trim(doc)
        If String.IsNullOrWhiteSpace(doc) OrElse doc.Length < 14 Then Return Nothing
        Select Case doc.Substring(0, 4)
            Case "1030", "1050", "1070", "1110", "1130"
                doc = doc.Substring(7, 2)
            Case "1090" ' РО
                doc = doc.Substring(12, 2)
            Case Else
                Return doc.Substring(0, 14)
        End Select
        If IsNumeric(doc) Then Return CInt(doc).ToString
        Return Nothing
    End Function

    ''' <summary>
    ''' Возвращает блок параграфов с номерами пунктов и наименованиями списков по экспортному контролю по строке ID пунктов списков
    ''' </summary>
    ''' <param name="idString">Строка ID пунктов списков, разделенных любыми нечисловыми символами</param>
    ''' <remarks></remarks>
    Public Function GetExcontParagraphById(idString As String) As String
        Dim sTmp As String = C2.ToStrNum(idString, False)
        If Not C2.IsText(sTmp) Then Return Nothing
        Using V As New DataView(Me.LawTable)
            V.RowFilter = String.Format("pos > '0' AND id IN ({0})", sTmp)
            V.Sort = Me.LawTable.DefaultView.Sort
            Dim doc1 As String, doc2 As String, section1 As String, section2 As String
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                '
                ' Начало блока параграфов, первый пункт
                '
                If i = 0 Then
                    sTmp = C2.ToText(V(i)("pos"))
                    Continue For
                End If
                doc1 = C2.ToText(V(i - 1)("doc"))
                doc2 = C2.ToText(V(i)("doc"))
                section1 = Me.GetLawSectionByDoc(doc1)
                section2 = Me.GetLawSectionByDoc(doc2)
                '
                ' Новый контрольный список
                '
                If doc1.Substring(0, 4) <> doc2.Substring(0, 4) Then
                    sTmp = String.Format("{0} Раздела {1} {2};{3}{4}", _
                                         sTmp, _
                                         section1, _
                                         Me.GetLawCaptionByDoc(doc1), _
                                         vbCrLf, _
                                         C2.ToText(V(i)("pos")))
                    Continue For
                End If
                '
                ' Тот же список, новый раздел
                '
                If section1 <> section2 Then
                    sTmp = String.Format("{0} Раздела {1}, {2}", _
                                         sTmp, _
                                         section1, _
                                         C2.ToText(V(i)("pos")))
                    Continue For
                End If
                '
                ' Тот же список, тот же раздел
                '
                sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(V(i)("pos")))
            Next
            '
            ' Последний раздел последнего списка
            '
            If V.Count > 0 Then
                doc1 = C2.ToText(V(V.Count - 1)("doc"))
                section1 = Me.GetLawSectionByDoc(doc1)
                sTmp = String.Format("{0} Раздела {1} {2}", _
                                     sTmp, _
                                     section1, _
                                     Me.GetLawCaptionByDoc(doc1))
            End If
        End Using

        If C2.IsText(sTmp) Then sTmp = sTmp.Replace("Список", "Списка").Replace("Перечень", "Перечня").Replace(".,", ",").Replace(". ", " ")

        Return sTmp

    End Function

End Class
