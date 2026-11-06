Imports Cprp.DxData.Common
Imports System.Data.SqlClient
''' <summary>
''' Таблица ТН ВЭД
''' </summary>
Public Class TnvedConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    ''' <summary>
    ''' Главная форма приложения
    ''' </summary>
    ''' <remarks>Заголовок формы используется для вывода информации в процессе обработки данных</remarks>
    Public Property MainForm As Form = Nothing


    ' Текст запроса на выборку всех данных из базы
    Private Const SELECT_COMMAND_TEXT As String = _
        "SELECT id, parentId, code, caption, description, dateB, dateE, lev, sortId FROM tTnvedTree"


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        MyBase.New(Connection, "TnvedTable")
        With Me.Columns
            .Add("id", GetType(Integer))            ' ID
            .Add("parentId", GetType(Integer))      ' ParentID
            .Add("code", GetType(String))           ' Код ТН ВЭД
            .Add("caption", GetType(String))        ' Описание кода
            .Add("description", GetType(String))    ' Полное описание кода (с описаниями вышестоящих кодов до товарных позиций)
            .Add("dateB", GetType(Date))            ' Дата начала действия кода
            .Add("dateE", GetType(Date))            ' Дата окончания действия кода
            .Add("lev", GetType(Integer))           ' Уровень в дереве кодов (0 - Разделы, 1 - Группы)
            .Add("sortId", GetType(Integer))        ' Порядковый номер для сортировки в списке кодов
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("code").MaxLength = 14
        With Me.Columns("caption")
            .AllowDBNull = False
            .MaxLength = 250
        End With
        Me.Columns("description").AllowDBNull = False
        Me.Columns("dateB").AllowDBNull = False
        With Me.Columns("dateE")
            .AllowDBNull = False
            .DefaultValue = CDate("31.12.9999")
        End With
        With Me.Columns("lev")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("sortId")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        LoadFromBase()
    End Sub


    ''' <summary>
    ''' Загрузить данные из базы данных
    ''' </summary>
    Public Sub LoadFromBase()
        Me.Rows.Clear()
        Me.Load(SELECT_COMMAND_TEXT)
        Me.AcceptChanges()
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    Public Sub SaveToBase()
        Using A As New SqlDataAdapter(SELECT_COMMAND_TEXT, MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Загрузить данные из файла Word с двумя таблицами
    ''' </summary>
    ''' <param name="filePath">Путь к файлу с данными</param>
    ''' <returns>ID первой добавленной записи</returns>
    ''' <remarks>
    ''' Загрузочный файл содержит две таблицы:
    ''' Первая таблица - одна ячейка с dateB всех загружаемых записей.
    ''' Вторая таблица - коды и описания (2 столбца), по количеству символов "- " в описании вычисляется параметр lev для записи.
    ''' </remarks>
    Public Function LoadFromWord(filePath As String) As Integer
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim T As DataTable = Me.Clone
        Dim startId As Integer = 1
        Try
            Dim dateB As Date = Nothing
            Dim Row As DataRow = Nothing
            Dim sTmp As String = Nothing
            Dim iTmp As Integer = 0
            R.LoadDocument(filePath)
            '
            ' dateB
            '
            dateB = CDate(ToText(R.Document.GetText(R.Document.Tables(0).Cell(0, 0).ContentRange)))
            '
            ' startId
            '
            Using V As New DataView(Me) With {.Sort = "id, DESC"}
                If V.Count > 0 Then startId = CInt(V(0)("id")) + 1
            End Using
            '
            ' Загрузка данных во временную таблицу
            '
            With R.Document.Tables(1)
                For i As Integer = 0 To .Rows.Count - 1
                    Row = T.NewRow
                    Row("id") = startId + i
                    Row("code") = DbText(R.Document.GetText(.Cell(i, 0).ContentRange))
                    Row("caption") = DbText(R.Document.GetText(.Cell(i, 1).ContentRange))
                    Row("description") = Row("caption")
                    Row("dateB") = dateB
                    T.Rows.Add(Row)
                Next
            End With
            '
            ' Обработка данных
            '
            With T.DefaultView
                .Sort = "id"
                '
                ' lev, caption
                '
                For i As Integer = 0 To .Count - 1
                    sTmp = ToText(.Item(i)("caption"))
                    iTmp = 3 ' товарная позиция
                    While sTmp Like "- *"
                        sTmp = sTmp.Substring(2)
                        iTmp += 1
                    End While
                    .Item(i)("caption") = sTmp
                    .Item(i)("lev") = iTmp
                Next
                '
                ' parentId
                '
                Using V As New DataView(Me) With {.Sort = "code", .RowFilter = "code > '0'"}
                    For i As Integer = 0 To .Count - 1
                        '
                        ' Определение parentId по уровням вышестоящих узлов
                        '
                        iTmp = CInt(.Item(i)("lev"))
                        For j = i - 1 To 0 Step -1
                            If CInt(.Item(j)("lev")) < iTmp Then
                                .Item(i)("parentId") = .Item(j)("id")
                                Exit For
                            End If
                        Next
                        '
                        ' Определение parentId по кодам ТН ВЭД всей таблицы ТН ВЭД для записей с пустыми parentId
                        '
                        If IsDBNull(.Item(i)("parentId")) AndAlso Not IsDBNull(.Item(i)("code")) Then
                            sTmp = ToText(.Item(i)("code"))
                            For j As Integer = V.Count - 1 To 0 Step -1
                                If CDate(V(j)("dateE")) <= dateB Then Continue For
                                If sTmp.IndexOf(ToText(V(j)("code"))) <> 0 Then Continue For
                                .Item(i)("parentId") = V(j)("id")
                                Exit For
                            Next
                        End If
                    Next
                End Using

            End With


        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
            T.Dispose()
        End Try

        Return startId
    End Function

End Class
