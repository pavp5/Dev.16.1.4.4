Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Вопрос"
''' </summary>
Friend Class QueryDataChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AnsMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents AskMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AskLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AnsLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryDataChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.AnsMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.AskMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.AskLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.AnsLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnsMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AskMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AskLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnsLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.LayoutControl2)
        Me.LayoutControl1.Controls.Add(Me.AnsMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.AskMemoEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 51)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Location = New System.Drawing.Point(12, 51)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.Root
        Me.LayoutControl2.Size = New System.Drawing.Size(926, 20)
        Me.LayoutControl2.TabIndex = 6
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Location = New System.Drawing.Point(0, 0)
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(926, 20)
        Me.Root.TextVisible = False
        '
        'AnsMemoEdit
        '
        Me.AnsMemoEdit.Location = New System.Drawing.Point(24, 231)
        Me.AnsMemoEdit.Name = "AnsMemoEdit"
        Me.AnsMemoEdit.Size = New System.Drawing.Size(902, 395)
        Me.AnsMemoEdit.StyleController = Me.LayoutControl1
        Me.AnsMemoEdit.TabIndex = 5
        '
        'AskMemoEdit
        '
        Me.AskMemoEdit.Location = New System.Drawing.Point(24, 132)
        Me.AskMemoEdit.MinimumSize = New System.Drawing.Size(0, 40)
        Me.AskMemoEdit.Name = "AskMemoEdit"
        Me.AskMemoEdit.Size = New System.Drawing.Size(902, 40)
        Me.AskMemoEdit.StyleController = Me.LayoutControl1
        Me.AskMemoEdit.TabIndex = 4
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LayoutControl2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 39)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(930, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'RootLayoutControlGroup
        '
        Me.RootLayoutControlGroup.AppearanceGroup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RootLayoutControlGroup.AppearanceGroup.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceItemCaption.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceItemCaption.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = True
        Me.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.RootLayoutControlGroup.GroupBordersVisible = False
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.AskLayoutControlGroup, Me.AnsLayoutControlGroup, Me.LayoutControlItem4, Me.SplitterItem1, Me.SimpleSeparator1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 39)
        Me.CaptionSimpleLabelItem.Text = "Вопрос № _"
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(122, 29)
        '
        'AskLayoutControlGroup
        '
        Me.AskLayoutControlGroup.ExpandButtonVisible = True
        Me.AskLayoutControlGroup.ExpandOnDoubleClick = True
        Me.AskLayoutControlGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.AskLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.AskLayoutControlGroup.Location = New System.Drawing.Point(0, 81)
        Me.AskLayoutControlGroup.Name = "AskLayoutControlGroup"
        Me.AskLayoutControlGroup.Size = New System.Drawing.Size(930, 95)
        Me.AskLayoutControlGroup.Spacing = New DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2)
        Me.AskLayoutControlGroup.Text = "Формулировка вопроса"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.AskMemoEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(906, 44)
        Me.LayoutControlItem1.Text = "Вопрос"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'AnsLayoutControlGroup
        '
        Me.AnsLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.AnsLayoutControlGroup.Location = New System.Drawing.Point(0, 188)
        Me.AnsLayoutControlGroup.Name = "AnsLayoutControlGroup"
        Me.AnsLayoutControlGroup.Size = New System.Drawing.Size(930, 442)
        Me.AnsLayoutControlGroup.Text = "Ответ на вопрос"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.AnsMemoEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(906, 399)
        Me.LayoutControlItem2.Text = "Ответ"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 39)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 176)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(930, 12)
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 80)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
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
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem})
        Me.BarManager1.MaxItemId = 1
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(72, 155)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'OpenListBarButtonItem
        '
        Me.OpenListBarButtonItem.Caption = "Список"
        Me.OpenListBarButtonItem.Glyph = CType(resources.GetObject("OpenListBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenListBarButtonItem.Id = 0
        Me.OpenListBarButtonItem.Name = "OpenListBarButtonItem"
        ToolTipTitleItem1.Text = "Список"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти к списку вопросов"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.OpenListBarButtonItem.SuperTip = SuperToolTip1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 650)
        Me.barDockControlBottom.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 650)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 650)
        '
        'QueryDataChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "QueryDataChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnsMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AskMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AskLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnsLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Строка таблицы объектов экспертизы
        '
        Dim Row As DataRow = P.Work.QueryTable.Rows.Find(MyClass.ObjectId)
        If Row Is Nothing Then Exit Sub
        '
        ' Элементы управления
        '
        CaptionSimpleLabelItem.Text = String.Format("Вопрос № {0}", C2.ToInt(Row("rowNum")))
        AskMemoEdit.EditValue = Row("ask")
        AnsMemoEdit.EditValue = Row("ans")
        '
        ' Доступность элементов управления на редактирование
        '
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Строка таблицы вопросов
        '
        Dim Row As DataRow = P.Work.QueryTable.Rows.Find(MyClass.ObjectId)
        If Row Is Nothing Then Exit Sub
        '
        ' Данные объекта
        '
        Row("ask") = C2.DbText(AskMemoEdit.EditValue)
        Row("ans") = C2.DbText(AnsMemoEdit.EditValue)
        '
        ' Проверка заполненности данных
        '
        Row("isCheck") = C2.IsText(Row("ask")) AndAlso C2.IsText(Row("ans"))
        P.Work.QueryTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        '
        ' Элементы управления
        '
        AskMemoEdit.Properties.ReadOnly = bLock
        AnsMemoEdit.Properties.ReadOnly = bLock
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property ObjectId As Integer = C2.EMPTY_ID


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.QueryData
        AskLayoutControlGroup.Height = 100
    End Sub


    ' Перейти к списку вопросов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.QueryList, MyClass.ObjectId)
    End Sub

End Class
