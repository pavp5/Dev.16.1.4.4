<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkForm
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CancelSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.AcceptSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.DescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.TypeLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.OrderTermDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.OrderNumTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ClientNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderNumTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.CancelSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.AcceptSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.DescriptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.TypeLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.OrderTermDateEdit)
        Me.LayoutControl1.Controls.Add(Me.OrderNumTextEdit)
        Me.LayoutControl1.Controls.Add(Me.ClientNameTextEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(793, 158, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(592, 376)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CancelSimpleButton
        '
        Me.CancelSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancelSimpleButton.Appearance.Options.UseFont = True
        Me.CancelSimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelSimpleButton.Location = New System.Drawing.Point(470, 342)
        Me.CancelSimpleButton.Name = "CancelSimpleButton"
        Me.CancelSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.CancelSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.CancelSimpleButton.StyleController = Me.LayoutControl1
        Me.CancelSimpleButton.TabIndex = 14
        Me.CancelSimpleButton.Text = "ОТМЕНА"
        '
        'AcceptSimpleButton
        '
        Me.AcceptSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AcceptSimpleButton.Appearance.Options.UseFont = True
        Me.AcceptSimpleButton.Location = New System.Drawing.Point(356, 342)
        Me.AcceptSimpleButton.Name = "AcceptSimpleButton"
        Me.AcceptSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.AcceptSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.AcceptSimpleButton.StyleController = Me.LayoutControl1
        Me.AcceptSimpleButton.TabIndex = 31
        Me.AcceptSimpleButton.Text = "СОХРАНИТЬ"
        '
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(166, 140)
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(414, 198)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 12
        '
        'TypeLookUpEdit
        '
        Me.TypeLookUpEdit.Location = New System.Drawing.Point(166, 12)
        Me.TypeLookUpEdit.Name = "TypeLookUpEdit"
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.TypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.TypeLookUpEdit.Properties.DisplayMember = "name"
        Me.TypeLookUpEdit.Properties.DropDownRows = 8
        Me.TypeLookUpEdit.Properties.NullText = ""
        Me.TypeLookUpEdit.Properties.ShowFooter = False
        Me.TypeLookUpEdit.Properties.ShowHeader = False
        Me.TypeLookUpEdit.Properties.ValueMember = "id"
        Me.TypeLookUpEdit.Size = New System.Drawing.Size(414, 28)
        Me.TypeLookUpEdit.StyleController = Me.LayoutControl1
        Me.TypeLookUpEdit.TabIndex = 30
        '
        'OrderTermDateEdit
        '
        Me.OrderTermDateEdit.EditValue = Nothing
        Me.OrderTermDateEdit.Location = New System.Drawing.Point(166, 108)
        Me.OrderTermDateEdit.Name = "OrderTermDateEdit"
        Me.OrderTermDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OrderTermDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.OrderTermDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.OrderTermDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.OrderTermDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.OrderTermDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.OrderTermDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.OrderTermDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.OrderTermDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm"
        Me.OrderTermDateEdit.Properties.TouchUIMinuteIncrement = 30
        Me.OrderTermDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.OrderTermDateEdit.Size = New System.Drawing.Size(414, 28)
        Me.OrderTermDateEdit.StyleController = Me.LayoutControl1
        Me.OrderTermDateEdit.TabIndex = 29
        '
        'OrderNumTextEdit
        '
        Me.OrderNumTextEdit.Location = New System.Drawing.Point(166, 76)
        Me.OrderNumTextEdit.Name = "OrderNumTextEdit"
        Me.OrderNumTextEdit.Properties.NullValuePrompt = "Полное наименование, как в официальных документах"
        Me.OrderNumTextEdit.Size = New System.Drawing.Size(414, 28)
        Me.OrderNumTextEdit.StyleController = Me.LayoutControl1
        Me.OrderNumTextEdit.TabIndex = 6
        '
        'ClientNameTextEdit
        '
        Me.ClientNameTextEdit.Location = New System.Drawing.Point(166, 44)
        Me.ClientNameTextEdit.Name = "ClientNameTextEdit"
        Me.ClientNameTextEdit.Properties.NullValuePrompt = "Полное наименование, как в официальных документах"
        Me.ClientNameTextEdit.Size = New System.Drawing.Size(414, 28)
        Me.ClientNameTextEdit.StyleController = Me.LayoutControl1
        Me.ClientNameTextEdit.TabIndex = 5
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem1, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(592, 376)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ClientNameTextEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem2.Text = "Заказчик*"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(151, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.OrderNumTextEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem3.Text = "Номер заказа*"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(151, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.OrderTermDateEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem4.Text = "Срок исполнения заказа*"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(151, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TypeLookUpEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(572, 32)
        Me.LayoutControlItem5.Text = "Вид услуги*"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(151, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DescriptionMemoEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 128)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(572, 202)
        Me.LayoutControlItem1.Text = "Сведения о работе"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(151, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.AcceptSimpleButton
        Me.LayoutControlItem6.Location = New System.Drawing.Point(344, 330)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.CancelSimpleButton
        Me.LayoutControlItem7.Location = New System.Drawing.Point(458, 330)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 330)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(344, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'WorkForm
        '
        Me.AcceptButton = Me.AcceptSimpleButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelSimpleButton
        Me.ClientSize = New System.Drawing.Size(592, 376)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "WorkForm"
        Me.ShowInTaskbar = False
        Me.Text = "WorkForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderNumTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents OrderNumTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ClientNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TypeLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents OrderTermDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CancelSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AcceptSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
End Class
