Imports C2 = Cprp.DxData.Common
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Таблица видов услуг
    ''' </summary>
    Friend ServiceTable As ServiceDataTable = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Order.WorkConnectionRow
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(id As Object, Connection As SqlConnection)
        MyBase.New(Connection)
        '
        ' Другие таблицы
        '
        ServiceTable = New ServiceDataTable
        '
        ' Источник данных работы
        '
        MyBase.DS.Tables.AddRange(New DataTable() {ServiceTable})
        '
        ' ID
        '
        MyClass.Id = id

    End Sub


    ''' <summary>
    ''' ID работы
    ''' </summary>
    Public Overrides Property Id As Object
        Get
            Return MyBase.Id
        End Get
        Set(value As Object)
            MyBase.Id = value
            If MyBase.IsEmpty Then Exit Property
            MyBase.DS.AcceptChanges()
        End Set
    End Property


    ''' <summary>
    ''' Возвращает содержание работы в виде HTML-документа
    ''' </summary>
    Public Overrides Function GetHtmlContent() As String
        ' ID последнего динамически сформированного элемента
        Dim elId As Integer = 100

        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim Row As DataRow = Nothing

        Dim Html As String = "<!DOCTYPE HTML><html>"
        '
        ' Head, css, js
        '
        Html &= "<head>" & vbCrLf
        Html &= String.Format("<title>Содержание работы № {0}</title>", CInt(Me.Id)) & vbCrLf
        Html &= HTML_CSS_JS
        Html &= "</head>" & vbCrLf
        '
        ' Body
        '
        Html &= "<body>" & vbCrLf
        '
        ' RootNode
        '
        Html &= "<ul class='tree'>"
        '
        ' Сведения о работе
        '
        Html &= "<li style='margin-top: 0pt;'><span onclick='javascript: hs(el1);'>Сведения о работе</span>"
        Html &= "<ul id='el1'>"
        Html &= MyBase.HtmlWorkInfoTABLE
        '
        ' Сведения о работе > Перечень представленных документов
        '
        Html &= "<li style='margin-top: 6pt;'><span onclick='javascript: hs(el6);'>Перечень представленных документов</span>"
        Html &= "<ul id='el6'>"
        Html &= MyBase.HtmlInDocLI(False)
        Html &= "</ul>"
        Html &= "</li>"                             ' /Перечень представленных документов
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /Сведения о работе

        '
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function

    Public Overrides Sub ReCalc()
        Me.CalcTable.Rows.Clear()
        Me("price") = 0
    End Sub

End Class
