''' <summary>
''' Работа без конкретного вида работы
''' </summary>
Public Class AnyWorkConnectionRow : Inherits WorkConnectionRow


    Public Sub New(Connection As SqlConnection)
        MyBase.New(Connection)
        Me.Rows.Add(Me.NewRow)
        Me.ARow.Rows.Add(Me.ARow.NewRow)
    End Sub

    Public Sub New(id As String, Connection As SqlConnection)
        MyBase.New(Connection)
        Me.Id = id
        If MyBase.IsEmpty Then
            Me.Rows.Add(Me.NewRow)
            Me.ARow.Rows.Add(Me.ARow.NewRow)
        End If
    End Sub

    Public Overrides Function GetHtmlContent() As String
        Return Nothing
    End Function

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    Public Overrides Sub DataSave()
        If MyBase.IsEmpty Then Exit Sub
        ' признак добавленной строки
        Dim bNew As Boolean = (Me.Rows(0).RowState = DataRowState.Added)
        If IsDBNull(Me("guid")) Then Me("guid") = System.Guid.NewGuid.ToString
        '
        ' Сохранение работы в базу данных
        '
        Using A As New SqlDataAdapter(SELECT_QUERY_STRING, MyBase.Connection)
            ' Перезаписывать конкурирующие изменения
            Dim B As New SqlCommandBuilder(A) With {.ConflictOption = ConflictOption.OverwriteChanges}
            Try
1:              A.Update(Me)
            Catch ex As DBConcurrencyException When ex.Row.RowState = DataRowState.Deleted
                ex.Row.AcceptChanges()
                GoTo 1
            Catch ex1 As Exception
                Throw ex1
            End Try
        End Using
        '
        ' Обновление id для добавленной строки
        '
        If bNew Then
            Dim newId As Integer = CInt(Me.ExecuteScalar("SELECT @@IDENTITY"))
            MyBase.Load(String.Format(SELECT_QUERY_STRING.Replace("id IS NULL", "id = {0}"), newId))
        End If

    End Sub

    ''' <summary>
    ''' Сохранить данные в файл xml на файловом сервере
    ''' </summary>
    Public Sub DataSaveFile()
        Dim sTmp As String = MyBase.GetWorkFilePath(MyClass.Id)
        If Not String.IsNullOrWhiteSpace(sTmp) Then
            Me.ARow("saveDate") = Date.Now
            Me.DS.AcceptChanges()
            Me.DS.WriteXml(sTmp, XmlWriteMode.WriteSchema)
        End If
    End Sub

End Class
