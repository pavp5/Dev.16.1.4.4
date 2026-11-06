<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindForm))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.ProDescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IsControlGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CancelSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.AcceptSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.MemberCaptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.MemberGridControl = New DevExpress.XtraGrid.GridControl()
        Me.MemberGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameShortGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.FindButtonEdit = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MemberCaptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemberGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemberGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindButtonEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProDescriptionGridColumn
        '
        Me.ProDescriptionGridColumn.Caption = "proDescription"
        Me.ProDescriptionGridColumn.FieldName = "proDescription"
        Me.ProDescriptionGridColumn.Name = "ProDescriptionGridColumn"
        '
        'IsControlGridColumn
        '
        Me.IsControlGridColumn.Caption = "isControl"
        Me.IsControlGridColumn.FieldName = "isCritical"
        Me.IsControlGridColumn.Name = "IsControlGridColumn"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.FindButtonEdit)
        Me.LayoutControl1.Controls.Add(Me.CancelSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.AcceptSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.MemberCaptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.MemberGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(493, 365, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(442, 576)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CancelSimpleButton
        '
        Me.CancelSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancelSimpleButton.Appearance.Options.UseFont = True
        Me.CancelSimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelSimpleButton.Location = New System.Drawing.Point(320, 542)
        Me.CancelSimpleButton.Name = "CancelSimpleButton"
        Me.CancelSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.CancelSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.CancelSimpleButton.StyleController = Me.LayoutControl1
        Me.CancelSimpleButton.TabIndex = 7
        Me.CancelSimpleButton.Text = "ОТМЕНА"
        '
        'AcceptSimpleButton
        '
        Me.AcceptSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AcceptSimpleButton.Appearance.Options.UseFont = True
        Me.AcceptSimpleButton.Location = New System.Drawing.Point(206, 542)
        Me.AcceptSimpleButton.Name = "AcceptSimpleButton"
        Me.AcceptSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.AcceptSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.AcceptSimpleButton.StyleController = Me.LayoutControl1
        Me.AcceptSimpleButton.TabIndex = 6
        Me.AcceptSimpleButton.Text = "ВЫБРАТЬ"
        '
        'MemberCaptionMemoEdit
        '
        Me.MemberCaptionMemoEdit.Location = New System.Drawing.Point(12, 474)
        Me.MemberCaptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.MemberCaptionMemoEdit.Name = "MemberCaptionMemoEdit"
        Me.MemberCaptionMemoEdit.Properties.ReadOnly = True
        Me.MemberCaptionMemoEdit.Size = New System.Drawing.Size(418, 64)
        Me.MemberCaptionMemoEdit.StyleController = Me.LayoutControl1
        Me.MemberCaptionMemoEdit.TabIndex = 5
        '
        'MemberGridControl
        '
        Me.MemberGridControl.Location = New System.Drawing.Point(12, 44)
        Me.MemberGridControl.MainView = Me.MemberGridView
        Me.MemberGridControl.Name = "MemberGridControl"
        Me.MemberGridControl.Size = New System.Drawing.Size(418, 414)
        Me.MemberGridControl.TabIndex = 4
        Me.MemberGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MemberGridView})
        '
        'MemberGridView
        '
        Me.MemberGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MemberGridView.Appearance.Row.Options.UseFont = True
        Me.MemberGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NameShortGridColumn, Me.ProDescriptionGridColumn, Me.IsControlGridColumn})
        Me.MemberGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.ProDescriptionGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual
        FormatConditionRuleValue1.Value1 = "0"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.IsControlGridColumn
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = True
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.MemberGridView.FormatRules.Add(GridFormatRule1)
        Me.MemberGridView.FormatRules.Add(GridFormatRule2)
        Me.MemberGridView.GridControl = Me.MemberGridControl
        Me.MemberGridView.Name = "MemberGridView"
        Me.MemberGridView.OptionsBehavior.Editable = False
        Me.MemberGridView.OptionsCustomization.AllowColumnMoving = False
        Me.MemberGridView.OptionsCustomization.AllowFilter = False
        Me.MemberGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.MemberGridView.OptionsMenu.EnableColumnMenu = False
        Me.MemberGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.MemberGridView.OptionsView.ShowGroupPanel = False
        Me.MemberGridView.RowHeight = 30
        '
        'NameShortGridColumn
        '
        Me.NameShortGridColumn.Caption = "Краткое наименование"
        Me.NameShortGridColumn.FieldName = "nameShort"
        Me.NameShortGridColumn.Name = "NameShortGridColumn"
        Me.NameShortGridColumn.Visible = True
        Me.NameShortGridColumn.VisibleIndex = 0
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.SplitterItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.LayoutControlItem5})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(442, 576)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.MemberGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(422, 418)
        Me.LayoutControlItem1.Text = "Список лиц"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.MemberCaptionMemoEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 462)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(422, 68)
        Me.LayoutControlItem2.Text = "Реквизиты лица"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 450)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(422, 12)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.AcceptSimpleButton
        Me.LayoutControlItem3.Location = New System.Drawing.Point(194, 530)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.CancelSimpleButton
        Me.LayoutControlItem4.Location = New System.Drawing.Point(308, 530)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 530)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(194, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'FindButtonEdit
        '
        Me.FindButtonEdit.Location = New System.Drawing.Point(12, 12)
        Me.FindButtonEdit.Name = "FindButtonEdit"
        ToolTipTitleItem1.Text = "Поиск"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Нажмите для поиска текста"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.FindButtonEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Поиск", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("ButtonEdit1.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, SuperToolTip1, True)})
        Me.FindButtonEdit.Properties.NullValuePrompt = "Введите текст для поиска ..."
        Me.FindButtonEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.FindButtonEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.FindButtonEdit.Size = New System.Drawing.Size(418, 28)
        Me.FindButtonEdit.StyleController = Me.LayoutControl1
        Me.FindButtonEdit.TabIndex = 8
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.FindButtonEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(422, 32)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'FindForm
        '
        Me.AcceptButton = Me.AcceptSimpleButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelSimpleButton
        Me.ClientSize = New System.Drawing.Size(442, 576)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FindForm"
        Me.ShowInTaskbar = False
        Me.Text = "FindForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MemberCaptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemberGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemberGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindButtonEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MemberCaptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents MemberGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents MemberGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents CancelSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AcceptSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents NameShortGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ProDescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsControlGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FindButtonEdit As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
