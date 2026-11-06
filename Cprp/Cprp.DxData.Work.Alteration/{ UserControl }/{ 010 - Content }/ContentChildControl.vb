Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Содержание"
''' </summary>
Friend Class ContentChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents ContentWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents FindBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CollapseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExpandBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents RefreshBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContentChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.RefreshBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExpandBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.CollapseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.FindBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.ContentWebBrowser = New System.Windows.Forms.WebBrowser()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ExpandBarButtonItem, Me.CollapseBarButtonItem, Me.FindBarButtonItem, Me.RefreshBarButtonItem})
        Me.BarManager1.MaxItemId = 4
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.RefreshBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.ExpandBarButtonItem, True), New DevExpress.XtraBars.LinkPersistInfo(Me.CollapseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'RefreshBarButtonItem
        '
        Me.RefreshBarButtonItem.Caption = "Перечитать"
        Me.RefreshBarButtonItem.Glyph = CType(resources.GetObject("RefreshBarButtonItem.Glyph"), System.Drawing.Image)
        Me.RefreshBarButtonItem.Id = 3
        Me.RefreshBarButtonItem.Name = "RefreshBarButtonItem"
        ToolTipTitleItem1.Text = "Перечитать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перечитать содержание работы"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.RefreshBarButtonItem.SuperTip = SuperToolTip1
        '
        'ExpandBarButtonItem
        '
        Me.ExpandBarButtonItem.Caption = "Развернуть"
        Me.ExpandBarButtonItem.Glyph = CType(resources.GetObject("ExpandBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ExpandBarButtonItem.Id = 0
        Me.ExpandBarButtonItem.Name = "ExpandBarButtonItem"
        ToolTipTitleItem2.Text = "Развернуть"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Развернуть все пункты содержания"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ExpandBarButtonItem.SuperTip = SuperToolTip2
        '
        'CollapseBarButtonItem
        '
        Me.CollapseBarButtonItem.Caption = "Свернуть"
        Me.CollapseBarButtonItem.Glyph = CType(resources.GetObject("CollapseBarButtonItem.Glyph"), System.Drawing.Image)
        Me.CollapseBarButtonItem.Id = 1
        Me.CollapseBarButtonItem.Name = "CollapseBarButtonItem"
        ToolTipTitleItem3.Text = "Свернуть"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Свернуть все пункты содержания"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.CollapseBarButtonItem.SuperTip = SuperToolTip3
        '
        'FindBarButtonItem
        '
        Me.FindBarButtonItem.Caption = "Поиск"
        Me.FindBarButtonItem.Glyph = CType(resources.GetObject("FindBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FindBarButtonItem.Id = 2
        Me.FindBarButtonItem.Name = "FindBarButtonItem"
        ToolTipTitleItem4.Text = "Поиск"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Поиск в тексте содержания"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.FindBarButtonItem.SuperTip = SuperToolTip4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(650, 47)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 450)
        Me.barDockControlBottom.Size = New System.Drawing.Size(650, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 47)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 403)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(650, 47)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 403)
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 47)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(650, 1)
        Me.SeparatorControl1.TabIndex = 4
        '
        'ContentWebBrowser
        '
        Me.ContentWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentWebBrowser.Location = New System.Drawing.Point(0, 48)
        Me.ContentWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ContentWebBrowser.Name = "ContentWebBrowser"
        Me.ContentWebBrowser.Size = New System.Drawing.Size(650, 402)
        Me.ContentWebBrowser.TabIndex = 5
        '
        'ContentChildControl
        '
        Me.Controls.Add(Me.ContentWebBrowser)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ContentChildControl"
        Me.Size = New System.Drawing.Size(650, 450)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        '
        ' СОДЕРЖАНИЕ РАБОТЫ
        '
        With P.Work
            If Not IsDBNull(.ARow("contentData")) AndAlso (.Condition = WorkCondition.IsAgree OrElse .Condition = WorkCondition.IsAccept OrElse .Condition = WorkCondition.IsSignature OrElse .Condition = WorkCondition.IsClose) Then
                ContentWebBrowser.DocumentText = .ARow("contentData").ToString
            Else
                ContentWebBrowser.DocumentText = P.Work.GetHtmlContent
            End If
        End With
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        '
        ' СОДЕРЖАНИЕ РАБОТЫ
        '
        P.Work.ARow("contentData") = ContentWebBrowser.DocumentText
        '
        ' СОХРАНЕНИЕ СОСТОЯНИЯ ВИДИМОСТИ ЭЛЕМЕНТОВ
        '
        Dim sTmp As String = Nothing
        For Each ul As HtmlElement In ContentWebBrowser.Document.GetElementsByTagName("UL")
            sTmp = ul.Id
            If Not C2.IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace("el", Nothing)
            If Not (C2.IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Continue For
            HT.HideElement(sTmp) = (ul.GetAttribute("className") = "hidden")
        Next
    End Sub

#End Region
#Region "Таблица видимости элементов"

    Private Class HideDataTable : Inherits DataTable

        ''' <summary>
        ''' New
        ''' </summary>
        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("elId", GetType(Integer))          ' ID элемента
                .Add("isHide", GetType(Boolean))        ' Объект скрыт (да / нет)
            End With
            With Me.Columns("isHide")
                .AllowDBNull = False
                .DefaultValue = False
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("elId")}
        End Sub

        ''' <summary>
        ''' Возвращает или задает состояние видимости элемента
        ''' </summary>
        ''' <param name="elId">ID объекта в списке объектов</param>
        ''' <remarks>Если сведения об объекте в таблице отсутствуют, создается новая запись и возвращается False</remarks>
        Friend Property HideElement(elId As Object) As Boolean
            Get
                Dim Row As DataRow = Me.Rows.Find(C2.ToInt(elId))
                If Row Is Nothing Then Row = Me.Rows.Add(New Object() {C2.ToInt(elId), False})
                Return CBool(Row("isHide"))
            End Get
            Set(value As Boolean)
                Dim Row As DataRow = Me.Rows.Find(C2.ToInt(elId))
                If Row Is Nothing Then
                    Me.Rows.Add(New Object() {C2.ToInt(elId), value})
                Else
                    Row("isHide") = value
                End If
            End Set
        End Property

    End Class

#End Region

    ''' <summary>
    ''' Таблица видимости элементов
    ''' </summary>
    Private HT As HideDataTable = Nothing


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.ContentUserControl
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Friend Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        MyBase.Content = ContentEnum.Content
        HT = New HideDataTable
        With My.Computer.FileSystem
            Dim sTmp As String = .GetTempFileName
            .WriteAllText(sTmp, "<HTML></HTML>", False)
            ContentWebBrowser.Navigate(sTmp)
        End With
    End Sub

    Private Sub ContentWebBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles ContentWebBrowser.DocumentCompleted
        '
        ' ИЗМЕНЕНИЕ СОСТОЯНИЯ ВИДИМОСТИ ЭЛЕМЕНТОВ
        '
        Dim sTmp As String = Nothing
        For Each ul As HtmlElement In ContentWebBrowser.Document.GetElementsByTagName("UL")
            sTmp = ul.Id
            If Not C2.IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace("el", Nothing)
            If Not (C2.IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Continue For
            If HT.HideElement(sTmp) Then ul.SetAttribute("className", "hidden")
        Next
    End Sub

    Private Sub ContentWebBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles ContentWebBrowser.Navigating
        '
        ' Адрес ресурса
        '
        Dim strUrl As String = e.Url.ToString.ToUpper
        '
        ' Первичная работа
        '
        If strUrl Like "*OPEN_WORK_*" Then
            e.Cancel = True
            If Me.ParentForm Is Nothing OrElse Not TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then Exit Sub
            Dim Arr() As String = e.Url.ToString.Split(New Char() {"_"}, StringSplitOptions.RemoveEmptyEntries)
            If Arr.Length < 3 Then Exit Sub
            Dim id As Integer = C2.ToInt(Arr(2))
            If id < 1 Then Exit Sub
            CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildOpen(id)
            Exit Sub
        End If
        '
        ' Заказчик (профиль)
        '
        If strUrl Like "*MEMBER_PROFILE_*" Then
            e.Cancel = True
            Dim Arr() As String = e.Url.ToString.Split(New Char() {"_"}, StringSplitOptions.RemoveEmptyEntries)
            If Arr.Length < 3 Then Exit Sub
            Dim inn As String = C2.ToText(Arr(2))
            If String.IsNullOrWhiteSpace(inn) Then Exit Sub
            For Each F As Form In Application.OpenForms
                If Not TypeOf F Is RusProfileForm Then Continue For
                If CType(F, RusProfileForm).Inn <> inn Then Continue For
                F.WindowState = FormWindowState.Normal
                F.Activate()
                Exit Sub
            Next
            With New RusProfileForm(inn, P.Work.Connection, P.ParentForm)
                .Show()
                .Activate()
            End With
            Exit Sub
        End If
        '
        ' Обобщенное наименование объектов экспертизы
        '
        If strUrl Like "*WORK_DESCRIPTION*" Then
            e.Cancel = True
            Dim sTmp As String = C2.ToText(InputBox("Укажите обобщенное наименование объектов экспертизы:", "Продукция", C2.ToText(P.Work("description"))))
            If C2.IsText(sTmp) Then
                P.Work("description") = sTmp
                P.Work.ExecuteNonQuery(String.Format("UPDATE tWork SET description = '{0}' WHERE id = {1}", sTmp.Replace("'", "''"), CInt(P.Work.Id)))
                'P.ContentOpen(ContentEnum.Content, C2.EMPTY_ID)
            End If
            Exit Sub
        End If
        '
        ' Документ для скачивания и локального открытия из временной папки
        '
        If strUrl Like "*&EXT=*" Then
            Dim iTmp As Integer = strUrl.IndexOf("&EXT=")
            If iTmp > 0 AndAlso (iTmp + 5) < strUrl.Length Then
                Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
                '
                ' Расширение файла
                '
                Dim sTmp As String = strUrl.Substring(iTmp + 5)
                Try
                    '
                    ' Временный файл для скачивания содержимого документа
                    '
                    With My.Computer.FileSystem
                        sTmp = String.Format("{0}\{1}.{2}", P.Work.TmpFolderPath, .GetFiles(P.Work.TmpFolderPath).Count + 1, sTmp)
                        .MoveFile(.GetTempFileName, sTmp, True)
                    End With
                    '
                    ' Скачивание содержимого документа во временный файл
                    '
                    Using W As New System.Net.WebClient
                        W.UseDefaultCredentials = True
                        W.DownloadFile(strUrl, sTmp)
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
        '
        ' Переход к элементу управления
        '
        If strUrl Like "*CN_*" Then
            e.Cancel = True
            Dim Arr() As String = e.Url.ToString.Split(New Char() {"_"}, StringSplitOptions.RemoveEmptyEntries)
            If Arr.Length < 3 Then Exit Sub
            Dim contentId As ContentEnum = CType(Arr(1), ContentEnum)
            Dim objectId As Integer = C2.ToInt(Arr(2))
            P.ContentOpen(contentId, objectId)
            Exit Sub
        End If
    End Sub

    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        ContentWebBrowser.Focus()
        SendKeys.Send("^f")
    End Sub

    Private Sub ExpandBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpandBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        For Each ol As HtmlElement In ContentWebBrowser.Document.GetElementsByTagName("OL")
            sTmp = ol.Id
            If Not C2.IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace("el", Nothing)
            If Not (C2.IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Continue For
            ol.SetAttribute("className", "none")
        Next
        For Each ul As HtmlElement In ContentWebBrowser.Document.GetElementsByTagName("UL")
            sTmp = ul.Id
            If Not C2.IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace("el", Nothing)
            If Not (C2.IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Continue For
            ul.SetAttribute("className", "none")
        Next
    End Sub

    Private Sub CollapseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CollapseBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        For Each ol As HtmlElement In ContentWebBrowser.Document.GetElementsByTagName("OL")
            sTmp = ol.Id
            If Not C2.IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace("el", Nothing)
            If Not (C2.IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Continue For
            ol.SetAttribute("className", "hidden")
        Next
        For Each ul As HtmlElement In ContentWebBrowser.Document.GetElementsByTagName("UL")
            sTmp = ul.Id
            If Not C2.IsText(sTmp) Then Continue For
            sTmp = sTmp.Replace("el", Nothing)
            If Not (C2.IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Continue For
            ul.SetAttribute("className", "hidden")
        Next
    End Sub

    ' Перечитать содержание работы
    Private Sub RefreshBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RefreshBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ContentWebBrowser.DocumentText = P.Work.GetHtmlContent
        Cprp.DxCommon.WaitForm.Close()
    End Sub

End Class
