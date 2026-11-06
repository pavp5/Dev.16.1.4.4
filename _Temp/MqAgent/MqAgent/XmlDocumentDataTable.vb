Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица содержимого xml-документа с сообщением
''' </summary>
Public Class XmlDocumentDataTable : Inherits DataTable

    ''' <summary>
    ''' Текущий загруженный xml-документ
    ''' </summary>
    Public Property XmlDocument As System.Xml.XmlDocument = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("name", GetType(String))       ' Наименование параметра
            .Add("value", GetType(String))      ' Значение параметра
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("name")}
        XmlDocument = New System.Xml.XmlDocument
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="tableName">Имя таблицы</param>
    Public Sub New(tableName As String)
        MyClass.New()
        Me.TableName = tableName
    End Sub


    ''' <summary>
    ''' Возвращает значение параметра
    ''' </summary>
    ''' <param name="name">Наименование парам</param>
    Default Public ReadOnly Property GetValue(name As String) As String
        Get
            If Me.Rows.Count = 0 Then Return Nothing
            If Not C2.IsText(name) Then Return Nothing
            name = C2.ToText(name).ToUpper
            Dim Row As DataRow = Me.Rows.Find(name)
            If Row Is Nothing Then Return Nothing
            Return C2.ToText(Row("value"))
        End Get
    End Property

    ''' <summary>
    ''' Загрузка данных их xml-документа
    ''' </summary>
    ''' <param name="xml">Содержимое xml-документа</param>
    Public Sub LoadXml(xml As String)
        Me.Rows.Clear()
        Dim name As String = Nothing
        Dim value As String = Nothing
        Dim Row As DataRow = Nothing
        If C2.IsText(xml) Then XmlDocument.LoadXml(xml)
        For Each N As System.Xml.XmlNode In XmlDocument.ChildNodes
            If N.Name.ToUpper <> "ENVELOPE" Then Continue For
            For Each N1 As System.Xml.XmlNode In N.ChildNodes
                name = N1.Name.ToUpper
                If name = "HEADER" Then
                    For Each N2 As System.Xml.XmlNode In N1.ChildNodes
                        name = N2.Name.ToUpper
                        value = C2.ToText(N2.InnerText)
                        Row = Me.Rows.Find(name)
                        If Row Is Nothing Then
                            Me.Rows.Add(New Object() {name, value})
                        Else
                            Row("value") = value
                        End If
                    Next
                ElseIf name = "BODY" Then
                    For Each N2 As System.Xml.XmlNode In N1.ChildNodes
                        name = N2.Name.ToUpper
                        If Not name Like "DOC*" Then Continue For
                        For Each N3 As System.Xml.XmlNode In N2.ChildNodes
                            name = N3.Name.ToUpper
                            value = C2.ToText(N3.InnerText)
                            Row = Me.Rows.Find(name)
                            If Row Is Nothing Then
                                Me.Rows.Add(New Object() {name, value})
                            Else
                                Row("value") = value
                            End If
                        Next
                        Exit For
                    Next
                End If
            Next
            Exit For
        Next
    End Sub


End Class
