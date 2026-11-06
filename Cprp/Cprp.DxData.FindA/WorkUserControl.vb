Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Работа"
''' </summary>
Friend Class WorkUserControl

    ' Открытое соединение с архивной базой данных
    Private _Connection As SqlConnection = Nothing

    ' Номер работы
    Private _workNum As Integer = C2.EMPTY_ID

    ' Путь к временному файлу для хранения содержания работ
    Private tmpFilePath As String = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с архивной базой данных</param>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' _Connection
        '
        _Connection = Connection
        '
        ' tmpFilePath
        '
        tmpFilePath = My.Computer.FileSystem.GetTempFileName
        '
        ' RefBarLargeButtonItem
        '
        RefBarCheckItem.Checked = True

    End Sub


#Region "WorkId"

    Private _workId As Integer = C2.EMPTY_ID
    ''' <summary>
    ''' ID работы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Property WorkId As Integer
        Get
            Return _workId
        End Get
        Set(value As Integer)
            If _workId = value Then Exit Property
            Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
            _workId = value
            '
            ' Номер работы
            '
            _workNum = C2.EMPTY_ID
            Using Cmd As New SqlCommand With {.Connection = _Connection}
                Cmd.CommandText = String.Format("SELECT workId FROM tWork WHERE id = {0}", _workId)
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then _workNum = CInt(Dr(0))
                End Using
            End Using
            '
            ' Удаление старых данных
            '
            W.DocumentText = "<html><body><p>[нет данных]</p></body></html>"
            R1.Text = "[нет данных]"
            R2.Text = "[нет данных]"
            '
            ' Загрузка новых данных
            '
            Using Cmd As New SqlCommand With {.Connection = _Connection}
                Cmd.CommandText = String.Format("SELECT refDataS FROM tWork WHERE NOT refDataS IS NULL AND id = {0}", _workId)
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then
                        With My.Computer.FileSystem
                            If Not .FileExists(tmpFilePath) Then tmpFilePath = .GetTempFileName
                            .WriteAllText(tmpFilePath, Dr(0).ToString, False)
                        End With
                        W.Navigate(tmpFilePath)
                    End If
                End Using
                Dim bTmp As Boolean = True
                Cmd.CommandText = String.Format("SELECT proData, docData FROM tOutDoc WHERE workId = {0} ORDER BY regNum", _workId)
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    While Dr.Read
                        If bTmp Then
                            If Not IsDBNull(Dr("proData")) Then R1.OpenXmlBytes = Dr("proData")
                            bTmp = False
                            Continue While
                        Else
                            If Not IsDBNull(Dr("proData")) Then R2.OpenXmlBytes = Dr("proData")
                            Exit While
                        End If
                    End While
                End Using
            End Using
            Cprp.DxCommon.WaitForm.Close()
        End Set
    End Property

#End Region

    Private Sub RefBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RefBarCheckItem.CheckedChanged
        MainNavigationFrame.SelectedPage = RefNavigationPage
    End Sub

    Private Sub Doc1BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Doc1BarCheckItem.CheckedChanged
        MainNavigationFrame.SelectedPage = Doc1NavigationPage
    End Sub

    Private Sub Doc2BarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Doc2BarCheckItem.CheckedChanged
        MainNavigationFrame.SelectedPage = Doc2NavigationPage
    End Sub

    Private Sub PrintBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintBarButtonItem.ItemClick
        If MainNavigationFrame.SelectedPage Is RefNavigationPage Then
            W.ShowPrintDialog()
        ElseIf MainNavigationFrame.SelectedPage Is Doc1NavigationPage Then
            R1.ShowPrintDialog()
        ElseIf MainNavigationFrame.SelectedPage Is Doc2NavigationPage Then
            R2.ShowPrintDialog()
        End If
    End Sub

    Private Sub SaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveBarButtonItem.ItemClick
        If MainNavigationFrame.SelectedPage Is RefNavigationPage Then
            W.ShowSaveAsDialog()
        ElseIf MainNavigationFrame.SelectedPage Is Doc1NavigationPage Then
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Сохранение данных в файл"
                Dlg.FileName = "Документ 1"
                Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
            If filePath Like "*docx" Then
                R1.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R1.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
        ElseIf MainNavigationFrame.SelectedPage Is Doc2NavigationPage Then
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Сохранение данных в файл"
                Dlg.FileName = "Документ 2"
                Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
            If filePath Like "*docx" Then
                R2.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R2.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
        End If
    End Sub

    Private Sub UploadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UploadBarButtonItem.ItemClick
        If _workId < 0 Then Exit Sub
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = String.Format("Работа № {0} (Объекты экспертизы + документы)", _workNum)
            Dlg.DefaultExt = "docx"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        '
        ' Загрузка данных в файл
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim T As DataTable = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim sTmp As String, iTmp As Integer
        Try
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            Cmd = New SqlCommand With {.Connection = _Connection}
            '
            ' Загрузка шаблона
            '
            R.OpenXmlBytes = My.Resources.gooddoctable
            R.Document.BeginUpdate()
            '
            ' Сведения об объектах экспертизы
            '
            Cmd.CommandText = String.Format("SELECT * FROM tGood WHERE workId = {0} ORDER BY nameCon", _workId)
            T = New DataTable
            T.Load(Cmd.ExecuteReader)
            T.DefaultView.Sort = "nameCon"
            With R.Document.Tables(0)
                For i As Integer = 0 To T.DefaultView.Count - 1
                    If i > 1 Then .Rows.Append()
                    R.Document.Delete(.Cell(i, 0).Range)
                    R.Document.InsertText(.Cell(i, 0).ContentRange.Start, i + 1)
                    R.Document.InsertText(.Cell(i, 1).ContentRange.Start, C2.ToText(T.DefaultView(i)("nameCon")))
                    R.Document.InsertText(.Cell(i, 2).ContentRange.Start, C2.ToText(T.DefaultView(i)("nameDec")))
                    'R.Document.InsertText(.Cell(i, 3).ContentRange.Start, C2.ToText(T.DefaultView(i)("unit")))
                    'R.Document.InsertText(.Cell(i, 4).ContentRange.Start, C2.ToText(T.DefaultView(i)("amount")))
                    iTmp = C2.ToInt(T.DefaultView(i)("categoryId"))
                    Select Case iTmp
                        Case 1, 2, 3, 4, 5, 6, 7, 8, 9
                            sTmp = iTmp.ToString
                        Case 10
                            sTmp = "0"
                        Case Else
                            sTmp = Nothing
                    End Select
                    R.Document.InsertText(.Cell(i, 5).ContentRange.Start, sTmp)
                    R.Document.InsertText(.Cell(i, 6).ContentRange.Start, C2.ToText(T.DefaultView(i)("area")))
                    R.Document.InsertText(.Cell(i, 7).ContentRange.Start, C2.ToText(T.DefaultView(i)("used")))
                    R.Document.InsertText(.Cell(i, 8).ContentRange.Start, C2.ToText(T.DefaultView(i)("description")))
                    R.Document.InsertText(.Cell(i, 9).ContentRange.Start, C2.ToText(T.DefaultView(i)("tnved")))
                    R.Document.InsertText(.Cell(i, 10).ContentRange.Start, C2.ToText(T.DefaultView(i)("studyWord")))
                Next
            End With
            T.Dispose()
            '
            ' Сведения о документах
            '            
            Cmd.CommandText = String.Format("SELECT * FROM tInDoc WHERE workId = {0} ORDER BY caption", _workId)
            T = New DataTable
            T.Load(Cmd.ExecuteReader)
            T.DefaultView.Sort = "caption"
            With R.Document.Tables(1)
                For i As Integer = 0 To T.DefaultView.Count - 1
                    If i > 1 Then .Rows.Append()
                    R.Document.Delete(.Cell(i, 0).Range)
                    R.Document.InsertText(.Cell(i, 0).ContentRange.Start, i + 1)
                    R.Document.InsertText(.Cell(i, 1).ContentRange.Start, C2.ToText(T.DefaultView(i)("caption")))
                    R.Document.InsertText(.Cell(i, 2).ContentRange.Start, C2.ToText(T.DefaultView(i)("regNum")))
                    If Not IsDBNull(T.DefaultView(i)("regDate")) Then
                        R.Document.InsertText(.Cell(i, 3).ContentRange.Start, Format(CDate(T.DefaultView(i)("regDate")), "dd.MM.yyyy"))
                    End If
                Next
            End With
            T.Dispose()
            R.Document.EndUpdate()
            '
            ' Сохранение файла
            '
            R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?") = DialogResult.Yes Then
                Using P As New Process
                    P.StartInfo.FileName = filePath
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            If Not R Is Nothing Then R.Dispose()
            If Not T Is Nothing Then T.Dispose()
            If Not Cmd Is Nothing Then Cmd.Dispose()
        End Try
    End Sub

    Private Sub W_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles W.Navigating
        Dim url As String = e.Url.ToString.ToUpper
        e.Cancel = (url Like "*WORK_DESCRIPTION*" Or url Like "*CN_*" Or url Like "*FINFO_CLIEN*" Or url Like "*SP.EXCONT*")
        '
        ' Документ для скачивания и локального открытия из временной папки
        '
        If url Like "*&EXT=*" Then
            Dim iTmp As Integer = url.IndexOf("&EXT=")
            If iTmp > 0 AndAlso (iTmp + 5) < url.Length Then
                Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
                '
                ' Расширение файла
                '
                Dim ext As String = url.Substring(iTmp + 5)
                Try
                    '
                    ' Временный файл для скачивания содержимого документа
                    '
                    Dim sTmp As String = Nothing
                    With My.Computer.FileSystem
                        sTmp = .GetTempFileName
                        .MoveFile(sTmp, sTmp & "." & ext, True)
                    End With
                    sTmp &= ("." & ext)
                    '
                    ' Скачивание содержимого документа во временный файл
                    '
                    Using W As New System.Net.WebClient
                        W.UseDefaultCredentials = True
                        W.DownloadFile(url, sTmp)
                    End Using
                    '
                    ' Открытие временного файла
                    '
                    Using P As New Process
                        P.StartInfo.FileName = sTmp
                        P.StartInfo.Verb = "Open"
                        P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                        P.Start()
                    End Using
                    e.Cancel = True
                    Exit Sub
                Catch ex As Exception
                    e.Cancel = False
                Finally
                    Cprp.DxCommon.WaitForm.Close()
                End Try
            End If
        End If
    End Sub

End Class
