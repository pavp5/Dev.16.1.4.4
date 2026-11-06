Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "План работы"
''' </summary>
Friend Class PlaneChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Private components As System.ComponentModel.IContainer
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ExpertTermDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TotalWorkSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents ExpertCommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LeaderCommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents SendQueryLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl

    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SendQueryLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.ExpertCommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LeaderCommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.TotalWorkSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.ExpertTermDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SendQueryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeaderCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalWorkSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.SendQueryLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.ExpertCommentMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.LeaderCommentMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.TotalWorkSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.ExpertTermDateEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(530, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1150, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SendQueryLookUpEdit
        '
        Me.SendQueryLookUpEdit.Location = New System.Drawing.Point(268, 607)
        Me.SendQueryLookUpEdit.Name = "SendQueryLookUpEdit"
        Me.SendQueryLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SendQueryLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.SendQueryLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SendQueryLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.SendQueryLookUpEdit.Properties.DisplayMember = "name"
        Me.SendQueryLookUpEdit.Properties.DropDownRows = 2
        Me.SendQueryLookUpEdit.Properties.NullText = ""
        Me.SendQueryLookUpEdit.Properties.ShowFooter = False
        Me.SendQueryLookUpEdit.Properties.ShowHeader = False
        Me.SendQueryLookUpEdit.Properties.ValueMember = "boolValue"
        Me.SendQueryLookUpEdit.Size = New System.Drawing.Size(869, 30)
        Me.SendQueryLookUpEdit.StyleController = Me.LayoutControl1
        Me.SendQueryLookUpEdit.TabIndex = 37
        '
        'ExpertCommentMemoEdit
        '
        Me.ExpertCommentMemoEdit.Location = New System.Drawing.Point(268, 259)
        Me.ExpertCommentMemoEdit.Name = "ExpertCommentMemoEdit"
        Me.ExpertCommentMemoEdit.Properties.NullValuePrompt = "Укажите причину изменений и сформулируйте вариант решения заявки"
        Me.ExpertCommentMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.ExpertCommentMemoEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.ExpertCommentMemoEdit.Size = New System.Drawing.Size(869, 276)
        Me.ExpertCommentMemoEdit.StyleController = Me.LayoutControl1
        Me.ExpertCommentMemoEdit.TabIndex = 36
        '
        'LeaderCommentMemoEdit
        '
        Me.LeaderCommentMemoEdit.Location = New System.Drawing.Point(268, 53)
        Me.LeaderCommentMemoEdit.Name = "LeaderCommentMemoEdit"
        Me.LeaderCommentMemoEdit.Size = New System.Drawing.Size(869, 189)
        Me.LeaderCommentMemoEdit.StyleController = Me.LayoutControl1
        Me.LeaderCommentMemoEdit.TabIndex = 35
        '
        'TotalWorkSpinEdit
        '
        Me.TotalWorkSpinEdit.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.[True]
        Me.TotalWorkSpinEdit.EditValue = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotalWorkSpinEdit.Location = New System.Drawing.Point(268, 539)
        Me.TotalWorkSpinEdit.Name = "TotalWorkSpinEdit"
        Me.TotalWorkSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.TotalWorkSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TotalWorkSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TotalWorkSpinEdit.Properties.Increment = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotalWorkSpinEdit.Properties.IsFloatValue = False
        Me.TotalWorkSpinEdit.Properties.Mask.EditMask = "n0"
        Me.TotalWorkSpinEdit.Properties.MaxValue = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.TotalWorkSpinEdit.Properties.MinValue = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotalWorkSpinEdit.Size = New System.Drawing.Size(869, 30)
        Me.TotalWorkSpinEdit.StyleController = Me.LayoutControl1
        Me.TotalWorkSpinEdit.TabIndex = 34
        '
        'ExpertTermDateEdit
        '
        Me.ExpertTermDateEdit.EditValue = Nothing
        Me.ExpertTermDateEdit.Location = New System.Drawing.Point(268, 573)
        Me.ExpertTermDateEdit.Name = "ExpertTermDateEdit"
        Me.ExpertTermDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExpertTermDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExpertTermDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExpertTermDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.ExpertTermDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.ExpertTermDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ExpertTermDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.ExpertTermDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ExpertTermDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm"
        Me.ExpertTermDateEdit.Properties.TouchUIMinuteIncrement = 30
        Me.ExpertTermDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExpertTermDateEdit.Size = New System.Drawing.Size(869, 30)
        Me.ExpertTermDateEdit.StyleController = Me.LayoutControl1
        Me.ExpertTermDateEdit.TabIndex = 28
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem9, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.SplitterItem1, Me.LayoutControlItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1150, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseTextOptions = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(1128, 40)
        Me.CaptionSimpleLabelItem.Text = "План работы"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(50, 30)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AllowHtmlStringInCaption = True
        Me.LayoutControlItem9.Control = Me.ExpertTermDateEdit
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 560)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1128, 34)
        Me.LayoutControlItem9.Text = "Срок исполнения<color='red'>*</color>"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(252, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.AllowHtmlStringInCaption = True
        Me.LayoutControlItem3.Control = Me.TotalWorkSpinEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 526)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1128, 34)
        Me.LayoutControlItem3.Text = "Трудоемкость (мин)<color=red>*</color>"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(252, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.AllowHtmlStringInCaption = True
        Me.LayoutControlItem5.Control = Me.LeaderCommentMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1128, 193)
        Me.LayoutControlItem5.Text = "Резолюция руководителя<color='red'>*</color>"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(252, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AllowHtmlStringInCaption = True
        Me.LayoutControlItem6.Control = Me.ExpertCommentMemoEdit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 246)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1128, 280)
        Me.LayoutControlItem6.Text = "Пояснения эксперта<color='red'>*</color>"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(252, 16)
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 233)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(1128, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SendQueryLookUpEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 594)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1128, 34)
        Me.LayoutControlItem1.Text = "Запрос дополнительной информации"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(252, 16)
        '
        'PlaneChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "PlaneChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SendQueryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeaderCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalWorkSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Элементы управления
        '
        MyBase.IsDataLoaded = False
        CaptionSimpleLabelItem.Text = "План работы"
        With P.Work.ARow
            LeaderCommentMemoEdit.EditValue = .Item("leaderComment")
            ExpertCommentMemoEdit.EditValue = .Item("expertComment")
            TotalWorkSpinEdit.EditValue = .Item("totalWork")
            ExpertTermDateEdit.EditValue = .Item("expertTerm")
            SendQueryLookUpEdit.EditValue = .Item("isSendQuery")
        End With
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not (P.PlaneEditableForExpert OrElse P.PlaneEditableForLeader) Then Exit Sub
        '
        ' Данные объектов
        '
        With P.Work.ARow
            .Item("leaderComment") = C2.DbText(LeaderCommentMemoEdit.EditValue)
            .Item("expertComment") = C2.DbText(ExpertCommentMemoEdit.EditValue)
            .Item("totalWork") = C2.DbInt(TotalWorkSpinEdit.EditValue)
            .Item("expertTerm") = C2.DbDate(ExpertTermDateEdit.EditValue)
            .Item("isSendQuery") = CBool(SendQueryLookUpEdit.EditValue)
            .AcceptChanges()
        End With
    End Sub

    Private Sub LockUpdate()
        LeaderCommentMemoEdit.ReadOnly = True
        ExpertCommentMemoEdit.ReadOnly = Not P.PlaneEditableForExpert
        Dim bLock As Boolean = Not (P.PlaneEditableForExpert OrElse P.PlaneEditableForLeader)
        TotalWorkSpinEdit.ReadOnly = bLock
        ExpertTermDateEdit.ReadOnly = bLock
    End Sub

#End Region

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Alteration.PlaneUserControl
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Friend Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        SendQueryLookUpEdit.Properties.DataSource = New Cprp.DxData.Handbook.YesNoDataTable
        MyBase.Content = ContentEnum.Plane
    End Sub

    Private Sub LeaderCommentMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LeaderCommentMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ExpertComment_EditValueChanged(sender As Object, e As EventArgs) Handles ExpertCommentMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub TotalWorkSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TotalWorkSpinEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ExpertTermDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ExpertTermDateEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub SendQueryLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SendQueryLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class