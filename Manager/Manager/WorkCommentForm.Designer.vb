<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkCommentForm
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.AddCommentSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.WorkCommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.WorkCommentGridControl = New DevExpress.XtraGrid.GridControl()
        Me.WorkCommentGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CreateDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AuthorNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CommentGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.WorkCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkCommentGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkCommentGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.WorkCommentGridControl)
        Me.LayoutControl1.Controls.Add(Me.AddCommentSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.WorkCommentMemoEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(696, 366, 312, 437)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(948, 614)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'AddCommentSimpleButton
        '
        Me.AddCommentSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AddCommentSimpleButton.Appearance.Options.UseFont = True
        Me.AddCommentSimpleButton.Location = New System.Drawing.Point(817, 556)
        Me.AddCommentSimpleButton.Name = "AddCommentSimpleButton"
        Me.AddCommentSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.AddCommentSimpleButton.Size = New System.Drawing.Size(100, 27)
        Me.AddCommentSimpleButton.StyleController = Me.LayoutControl1
        Me.AddCommentSimpleButton.TabIndex = 18
        Me.AddCommentSimpleButton.Text = "Добавить"
        '
        'WorkCommentMemoEdit
        '
        Me.WorkCommentMemoEdit.Location = New System.Drawing.Point(31, 498)
        Me.WorkCommentMemoEdit.Name = "WorkCommentMemoEdit"
        Me.WorkCommentMemoEdit.Properties.NullValuePrompt = "Новый комментарий"
        Me.WorkCommentMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.WorkCommentMemoEdit.Size = New System.Drawing.Size(886, 52)
        Me.WorkCommentMemoEdit.StyleController = Me.LayoutControl1
        Me.WorkCommentMemoEdit.TabIndex = 17
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.SplitterItem1, Me.LayoutControlGroup1, Me.LayoutControlGroup2})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(948, 614)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 452)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(922, 15)
        '
        'WorkCommentGridControl
        '
        Me.WorkCommentGridControl.Location = New System.Drawing.Point(31, 55)
        Me.WorkCommentGridControl.MainView = Me.WorkCommentGridView
        Me.WorkCommentGridControl.Name = "WorkCommentGridControl"
        Me.WorkCommentGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.WorkCommentGridControl.Size = New System.Drawing.Size(886, 392)
        Me.WorkCommentGridControl.TabIndex = 16
        Me.WorkCommentGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.WorkCommentGridView})
        '
        'WorkCommentGridView
        '
        Me.WorkCommentGridView.Appearance.Preview.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.WorkCommentGridView.Appearance.Preview.ForeColor = System.Drawing.SystemColors.InfoText
        Me.WorkCommentGridView.Appearance.Preview.Options.UseFont = True
        Me.WorkCommentGridView.Appearance.Preview.Options.UseForeColor = True
        Me.WorkCommentGridView.Appearance.Row.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.WorkCommentGridView.Appearance.Row.ForeColor = System.Drawing.Color.DimGray
        Me.WorkCommentGridView.Appearance.Row.Options.UseFont = True
        Me.WorkCommentGridView.Appearance.Row.Options.UseForeColor = True
        Me.WorkCommentGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CreateDateGridColumn, Me.AuthorNameGridColumn, Me.CommentGridColumn})
        Me.WorkCommentGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.WorkCommentGridView.GridControl = Me.WorkCommentGridControl
        Me.WorkCommentGridView.Name = "WorkCommentGridView"
        Me.WorkCommentGridView.OptionsBehavior.ReadOnly = True
        Me.WorkCommentGridView.OptionsCustomization.AllowColumnMoving = False
        Me.WorkCommentGridView.OptionsCustomization.AllowFilter = False
        Me.WorkCommentGridView.OptionsCustomization.AllowGroup = False
        Me.WorkCommentGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.WorkCommentGridView.OptionsCustomization.AllowSort = False
        Me.WorkCommentGridView.OptionsMenu.EnableColumnMenu = False
        Me.WorkCommentGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.WorkCommentGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.WorkCommentGridView.OptionsView.AutoCalcPreviewLineCount = True
        Me.WorkCommentGridView.OptionsView.ShowColumnHeaders = False
        Me.WorkCommentGridView.OptionsView.ShowGroupPanel = False
        Me.WorkCommentGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.WorkCommentGridView.OptionsView.ShowIndicator = False
        Me.WorkCommentGridView.OptionsView.ShowPreview = True
        Me.WorkCommentGridView.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[True]
        Me.WorkCommentGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.WorkCommentGridView.PreviewFieldName = "comment"
        Me.WorkCommentGridView.PreviewIndent = 22
        '
        'CreateDateGridColumn
        '
        Me.CreateDateGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.CreateDateGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CreateDateGridColumn.Caption = "Дата создания"
        Me.CreateDateGridColumn.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.CreateDateGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CreateDateGridColumn.FieldName = "createDate"
        Me.CreateDateGridColumn.Name = "CreateDateGridColumn"
        Me.CreateDateGridColumn.OptionsColumn.AllowEdit = False
        Me.CreateDateGridColumn.OptionsColumn.FixedWidth = True
        Me.CreateDateGridColumn.Visible = True
        Me.CreateDateGridColumn.VisibleIndex = 0
        Me.CreateDateGridColumn.Width = 120
        '
        'AuthorNameGridColumn
        '
        Me.AuthorNameGridColumn.Caption = "Автор"
        Me.AuthorNameGridColumn.FieldName = "authorName"
        Me.AuthorNameGridColumn.Name = "AuthorNameGridColumn"
        Me.AuthorNameGridColumn.OptionsColumn.AllowEdit = False
        Me.AuthorNameGridColumn.Visible = True
        Me.AuthorNameGridColumn.VisibleIndex = 1
        Me.AuthorNameGridColumn.Width = 120
        '
        'CommentGridColumn
        '
        Me.CommentGridColumn.Caption = "Коментарий"
        Me.CommentGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.CommentGridColumn.FieldName = "comment"
        Me.CommentGridColumn.Name = "CommentGridColumn"
        Me.CommentGridColumn.Width = 541
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.WorkCommentGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(892, 398)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.WorkCommentMemoEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(892, 58)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 58)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(786, 33)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.AddCommentSimpleButton
        Me.LayoutControlItem3.Location = New System.Drawing.Point(786, 58)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(106, 33)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(106, 33)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(106, 33)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(922, 452)
        Me.LayoutControlGroup1.Text = "Комментарии"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem3})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 467)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.OptionsItemText.TextToControlDistance = 4
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(922, 121)
        Me.LayoutControlGroup2.Text = "Новый комментарий"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'WorkCommentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 614)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "WorkCommentForm"
        Me.Text = "WorkCommentForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.WorkCommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkCommentGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkCommentGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AddCommentSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents WorkCommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents WorkCommentGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents WorkCommentGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CreateDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AuthorNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CommentGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
End Class
