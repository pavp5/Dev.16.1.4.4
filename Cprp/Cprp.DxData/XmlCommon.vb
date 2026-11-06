Imports System.Xml
Imports Cprp.DxData.Common
''' <summary>
''' Общие свойства и методы для работы с xml-документом
''' </summary>
Public Class XmlCommon


    Private Sub New()
    End Sub


    ''' <summary>
    ''' Возвращает дочерний узел родительского узла
    ''' </summary>
    ''' <param name="ParentNode">Родительский узел</param>
    ''' <param name="childName">Наименование дочернего узла</param>
    ''' <remarks>Если узел не найден, возвращает Nothing</remarks>
    Public Shared Function GetChildNode(ParentNode As XmlNode, childName As String) As XmlNode
        If ParentNode Is Nothing Then Return Nothing
        If Not IsText(childName) Then Return Nothing
        childName = childName.ToUpper
        For Each ChildNode As XmlNode In ParentNode.ChildNodes
            If ChildNode.Name.ToUpper = childName Then Return ChildNode
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Возвращает узел документа
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <param name="nodeNameString">Цепочка наименований узлов документа</param>
    ''' <remarks>Если узел не найден, возвращает Nothing</remarks>
    Public Shared Function GetDocumentNode(Doc As XmlDocument, nodeNameString As String) As XmlNode
        If Doc Is Nothing Then Return Nothing
        If Not IsText(nodeNameString) Then Return Nothing
        Dim arr() As String = nodeNameString.ToUpper.Split(New Char() {"/"}, StringSplitOptions.RemoveEmptyEntries)
        For Each N As XmlNode In Doc.ChildNodes
            If N.Name.ToUpper <> arr(0) Then Continue For
            For i As Integer = 1 To arr.GetUpperBound(0)
                N = GetChildNode(N, arr(i))
            Next
            Return N
        Next
        Return Nothing
    End Function

End Class