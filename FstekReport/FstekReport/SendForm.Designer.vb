<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendForm
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeListFormatRule1 As DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule = New DevExpress.XtraTreeList.StyleFormatConditions.TreeListFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckFileTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.FileTreeList = New DevExpress.XtraTreeList.TreeList()
        Me.NameTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.PathTreeListColumn = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.CancelSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.AcceptSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.ToCopyEmailTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.BodyMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.SubjectTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ToEmailTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.FileLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.FileTreeList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToCopyEmailTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BodyMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubjectTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToEmailTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckFileTreeListColumn
        '
        Me.IsCheckFileTreeListColumn.Caption = "isCheck"
        Me.IsCheckFileTreeListColumn.FieldName = "isCheck"
        Me.IsCheckFileTreeListColumn.Name = "IsCheckFileTreeListColumn"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.FileTreeList)
        Me.LayoutControl1.Controls.Add(Me.CancelSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.AcceptSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.ToCopyEmailTextEdit)
        Me.LayoutControl1.Controls.Add(Me.BodyMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.SubjectTextEdit)
        Me.LayoutControl1.Controls.Add(Me.ToEmailTextEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(815, 369, 276, 383)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(691, 828)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'FileTreeList
        '
        Me.FileTreeList.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FileTreeList.Appearance.Row.Options.UseFont = True
        Me.FileTreeList.CheckBoxFieldName = "isCheck"
        Me.FileTreeList.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.NameTreeListColumn, Me.PathTreeListColumn, Me.IsCheckFileTreeListColumn})
        TreeListFormatRule1.ApplyToRow = True
        TreeListFormatRule1.Column = Me.IsCheckFileTreeListColumn
        TreeListFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        TreeListFormatRule1.Rule = FormatConditionRuleValue1
        Me.FileTreeList.FormatRules.Add(TreeListFormatRule1)
        Me.FileTreeList.KeyFieldName = "name"
        Me.FileTreeList.Location = New System.Drawing.Point(31, 567)
        Me.FileTreeList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FileTreeList.Name = "FileTreeList"
        Me.FileTreeList.OptionsBehavior.Editable = False
        Me.FileTreeList.OptionsView.ShowCheckBoxes = True
        Me.FileTreeList.OptionsView.ShowColumns = False
        Me.FileTreeList.OptionsView.ShowHorzLines = False
        Me.FileTreeList.OptionsView.ShowIndicator = False
        Me.FileTreeList.OptionsView.ShowRoot = False
        Me.FileTreeList.OptionsView.ShowVertLines = False
        Me.FileTreeList.Size = New System.Drawing.Size(629, 202)
        Me.FileTreeList.TabIndex = 13
        '
        'NameTreeListColumn
        '
        Me.NameTreeListColumn.Caption = "name"
        Me.NameTreeListColumn.FieldName = "name"
        Me.NameTreeListColumn.MinWidth = 34
        Me.NameTreeListColumn.Name = "NameTreeListColumn"
        Me.NameTreeListColumn.Visible = True
        Me.NameTreeListColumn.VisibleIndex = 0
        Me.NameTreeListColumn.Width = 93
        '
        'PathTreeListColumn
        '
        Me.PathTreeListColumn.Caption = "path"
        Me.PathTreeListColumn.FieldName = "path"
        Me.PathTreeListColumn.Name = "PathTreeListColumn"
        '
        'CancelSimpleButton
        '
        Me.CancelSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancelSimpleButton.Appearance.Options.UseFont = True
        Me.CancelSimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelSimpleButton.Location = New System.Drawing.Point(567, 790)
        Me.CancelSimpleButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CancelSimpleButton.Name = "CancelSimpleButton"
        Me.CancelSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.CancelSimpleButton.Size = New System.Drawing.Size(108, 22)
        Me.CancelSimpleButton.StyleController = Me.LayoutControl1
        Me.CancelSimpleButton.TabIndex = 12
        Me.CancelSimpleButton.Text = "ОТМЕНА"
        '
        'AcceptSimpleButton
        '
        Me.AcceptSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.830189!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AcceptSimpleButton.Appearance.Options.UseFont = True
        Me.AcceptSimpleButton.Location = New System.Drawing.Point(453, 790)
        Me.AcceptSimpleButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AcceptSimpleButton.Name = "AcceptSimpleButton"
        Me.AcceptSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.AcceptSimpleButton.Size = New System.Drawing.Size(108, 22)
        Me.AcceptSimpleButton.StyleController = Me.LayoutControl1
        Me.AcceptSimpleButton.TabIndex = 11
        Me.AcceptSimpleButton.Text = "ОТПРАВИТЬ"
        '
        'ToCopyEmailTextEdit
        '
        Me.ToCopyEmailTextEdit.Location = New System.Drawing.Point(70, 93)
        Me.ToCopyEmailTextEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ToCopyEmailTextEdit.Name = "ToCopyEmailTextEdit"
        Me.ToCopyEmailTextEdit.Size = New System.Drawing.Size(590, 32)
        Me.ToCopyEmailTextEdit.StyleController = Me.LayoutControl1
        Me.ToCopyEmailTextEdit.TabIndex = 10
        '
        'BodyMemoEdit
        '
        Me.BodyMemoEdit.Location = New System.Drawing.Point(31, 277)
        Me.BodyMemoEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BodyMemoEdit.Name = "BodyMemoEdit"
        Me.BodyMemoEdit.Size = New System.Drawing.Size(629, 215)
        Me.BodyMemoEdit.StyleController = Me.LayoutControl1
        Me.BodyMemoEdit.TabIndex = 8
        '
        'SubjectTextEdit
        '
        Me.SubjectTextEdit.Location = New System.Drawing.Point(31, 185)
        Me.SubjectTextEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SubjectTextEdit.Name = "SubjectTextEdit"
        Me.SubjectTextEdit.Size = New System.Drawing.Size(629, 32)
        Me.SubjectTextEdit.StyleController = Me.LayoutControl1
        Me.SubjectTextEdit.TabIndex = 7
        '
        'ToEmailTextEdit
        '
        Me.ToEmailTextEdit.Location = New System.Drawing.Point(70, 55)
        Me.ToEmailTextEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ToEmailTextEdit.Name = "ToEmailTextEdit"
        Me.ToEmailTextEdit.Size = New System.Drawing.Size(590, 32)
        Me.ToEmailTextEdit.StyleController = Me.LayoutControl1
        Me.ToEmailTextEdit.TabIndex = 4
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.FileLayoutControlGroup, Me.SplitterItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(691, 828)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(665, 130)
        Me.LayoutControlGroup1.Text = "Получатели (email)"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ToEmailTextEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(635, 38)
        Me.LayoutControlItem1.Text = "Кому"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(36, 18)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.ToCopyEmailTextEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.OptionsToolTip.ToolTip = "Скрытая копия"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(635, 38)
        Me.LayoutControlItem7.Text = "СК"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(36, 18)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(665, 92)
        Me.LayoutControlGroup2.Text = "Тема"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SubjectTextEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(635, 38)
        Me.LayoutControlItem4.Text = "Тема"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 222)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(665, 275)
        Me.LayoutControlGroup3.Text = "Сообщение"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.BodyMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(635, 221)
        Me.LayoutControlItem5.Text = "Сообщение"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'FileLayoutControlGroup
        '
        Me.FileLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.FileLayoutControlGroup.Location = New System.Drawing.Point(0, 512)
        Me.FileLayoutControlGroup.Name = "FileLayoutControlGroup"
        Me.FileLayoutControlGroup.Size = New System.Drawing.Size(665, 262)
        Me.FileLayoutControlGroup.Text = "Вложения"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.FileTreeList
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(635, 208)
        Me.LayoutControlItem6.Text = "Вложения"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 497)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(665, 15)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.AcceptSimpleButton
        Me.LayoutControlItem2.Location = New System.Drawing.Point(437, 774)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(114, 28)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(114, 28)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(114, 28)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CancelSimpleButton
        Me.LayoutControlItem3.Location = New System.Drawing.Point(551, 774)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(114, 28)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(114, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(114, 28)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 774)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(437, 28)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'SendForm
        '
        Me.AcceptButton = Me.AcceptSimpleButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelSimpleButton
        Me.ClientSize = New System.Drawing.Size(691, 828)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SendForm"
        Me.ShowInTaskbar = False
        Me.Text = "SendForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.FileTreeList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToCopyEmailTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BodyMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubjectTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToEmailTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BodyMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SubjectTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ToEmailTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ToCopyEmailTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents FileLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents CancelSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AcceptSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents FileTreeList As DevExpress.XtraTreeList.TreeList
    Friend WithEvents IsCheckFileTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PathTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents NameTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
