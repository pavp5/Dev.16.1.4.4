Imports C2 = Cprp.DxData.Common
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow


    ''' <summary>
    ''' Объекты экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Friend QueryTable As QueryDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Consultation.WorkConnectionRow
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(id As Object, Connection As SqlConnection)
        MyBase.New(Connection)
        '
        ' Arow
        '
        With MyBase.ARow.Columns
            ' Документ #1
            .Add("doc1Data", GetType(Byte()))               ' содержимое проекта документа (openXml)
            .Add("doc1Id", GetType(Integer))                ' порядковый номер документа в таблице базы данных
            .Add("doc1RegNum", GetType(String))             ' номер документа
            .Add("doc1RegDate", GetType(Date))              ' дата документа
            .Add("doc1SummaryId", GetType(Integer))         ' ID идентификатора выводов экспертизы по документу
            .Add("ref1Data", GetType(String))               ' содержимое справки по документу (xml)
        End With
        '
        ' Другие таблицы
        '
        QueryTable = New QueryDataTable
        '
        ' Источник данных работы
        '
        MyBase.DS.Tables.AddRange(New DataTable() {QueryTable})
        '
        ' ID
        '
        MyClass.Id = id

    End Sub

    ''' <summary>
    ''' ID работы
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Property Id As Object
        Get
            Return MyBase.Id
        End Get
        Set(value As Object)
            MyBase.Id = value
            If MyBase.IsEmpty Then Exit Property
            'MyBase.ARow("typeId") = Cprp.DxData.Work.WorkType.IsConsultation
            MyBase.DS.AcceptChanges()
        End Set
    End Property

    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub DataSave()
        Me("percentCount") = GetPercentCount()
        MyBase.DataSave()
    End Sub

    ''' <summary>
    ''' Возвращает процент выполнения работы
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetPercentCount() As Integer
        Dim percentCount As Integer = 0
        ' Учет вопросов, по которым составлены ответы
        If Me.QueryTable.Rows.Count > 0 Then
            Using V As New DataView(Me.QueryTable)
                V.RowFilter = "isCheck = True"
                ' Процент за завершенные вопросы
                percentCount += CInt(100 * V.Count / Me.QueryTable.Rows.Count)
            End Using
        End If
        Return percentCount
    End Function

End Class
