<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkHistoryForm
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
        Me.CloseSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.HistoryGridControl = New DevExpress.XtraGrid.GridControl()
        Me.HistoryGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.EventDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EventNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UserNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CommentLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.HistoryGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HistoryGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.CloseSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.HistoryGridControl)
        Me.LayoutControl1.Controls.Add(Me.CommentMemoEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(343, 139, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(742, 626)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CloseSimpleButton
        '
        Me.CloseSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CloseSimpleButton.Appearance.Options.UseFont = True
        Me.CloseSimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseSimpleButton.Location = New System.Drawing.Point(620, 592)
        Me.CloseSimpleButton.Name = "CloseSimpleButton"
        Me.CloseSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.CloseSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.CloseSimpleButton.StyleController = Me.LayoutControl1
        Me.CloseSimpleButton.TabIndex = 6
        Me.CloseSimpleButton.Text = "ЗАКРЫТЬ"
        '
        'HistoryGridControl
        '
        Me.HistoryGridControl.Location = New System.Drawing.Point(12, 12)
        Me.HistoryGridControl.MainView = Me.HistoryGridView
        Me.HistoryGridControl.Name = "HistoryGridControl"
        Me.HistoryGridControl.Size = New System.Drawing.Size(718, 536)
        Me.HistoryGridControl.TabIndex = 4
        Me.HistoryGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.HistoryGridView})
        '
        'HistoryGridView
        '
        Me.HistoryGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.HistoryGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.HistoryGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HistoryGridView.Appearance.Row.Options.UseFont = True
        Me.HistoryGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.EventDateGridColumn, Me.EventNameGridColumn, Me.UserNameGridColumn})
        Me.HistoryGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.HistoryGridView.GridControl = Me.HistoryGridControl
        Me.HistoryGridView.Name = "HistoryGridView"
        Me.HistoryGridView.OptionsBehavior.Editable = False
        Me.HistoryGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.HistoryGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.HistoryGridView.OptionsView.ShowGroupPanel = False
        Me.HistoryGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.HistoryGridView.RowHeight = 30
        '
        'EventDateGridColumn
        '
        Me.EventDateGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.EventDateGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.EventDateGridColumn.Caption = "Дата / время"
        Me.EventDateGridColumn.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.EventDateGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.EventDateGridColumn.FieldName = "eventDate"
        Me.EventDateGridColumn.Name = "EventDateGridColumn"
        Me.EventDateGridColumn.OptionsColumn.FixedWidth = True
        Me.EventDateGridColumn.Visible = True
        Me.EventDateGridColumn.VisibleIndex = 0
        Me.EventDateGridColumn.Width = 140
        '
        'EventNameGridColumn
        '
        Me.EventNameGridColumn.Caption = "Описание события"
        Me.EventNameGridColumn.FieldName = "eventName"
        Me.EventNameGridColumn.Name = "EventNameGridColumn"
        Me.EventNameGridColumn.Visible = True
        Me.EventNameGridColumn.VisibleIndex = 1
        Me.EventNameGridColumn.Width = 282
        '
        'UserNameGridColumn
        '
        Me.UserNameGridColumn.Caption = "Инициатор события"
        Me.UserNameGridColumn.FieldName = "userName"
        Me.UserNameGridColumn.Name = "UserNameGridColumn"
        Me.UserNameGridColumn.OptionsColumn.FixedWidth = True
        Me.UserNameGridColumn.Visible = True
        Me.UserNameGridColumn.VisibleIndex = 2
        Me.UserNameGridColumn.Width = 140
        '
        'CommentMemoEdit
        '
        Me.CommentMemoEdit.Location = New System.Drawing.Point(12, 564)
        Me.CommentMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.CommentMemoEdit.Name = "CommentMemoEdit"
        Me.CommentMemoEdit.Properties.ReadOnly = True
        Me.CommentMemoEdit.Size = New System.Drawing.Size(694, 45)
        Me.CommentMemoEdit.StyleController = Me.LayoutControl1
        Me.CommentMemoEdit.TabIndex = 5
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.CommentLayoutControlGroup, Me.SplitterItem1, Me.LayoutControlItem3, Me.EmptySpaceItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(742, 626)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.HistoryGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(722, 540)
        Me.LayoutControlItem1.Text = "История работы"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'CommentLayoutControlGroup
        '
        Me.CommentLayoutControlGroup.ExpandButtonVisible = True
        Me.CommentLayoutControlGroup.Expanded = False
        Me.CommentLayoutControlGroup.ExpandOnDoubleClick = True
        Me.CommentLayoutControlGroup.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.CommentLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.CommentLayoutControlGroup.Location = New System.Drawing.Point(0, 552)
        Me.CommentLayoutControlGroup.Name = "CommentLayoutControlGroup"
        Me.CommentLayoutControlGroup.Size = New System.Drawing.Size(722, 28)
        Me.CommentLayoutControlGroup.Text = "Комментарий к событию"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CommentMemoEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(698, 49)
        Me.LayoutControlItem2.Text = "Комментарий"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 540)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(722, 12)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CloseSimpleButton
        Me.LayoutControlItem3.Location = New System.Drawing.Point(608, 580)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 580)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(608, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'WorkHistoryForm
        '
        Me.AcceptButton = Me.CloseSimpleButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseSimpleButton
        Me.ClientSize = New System.Drawing.Size(742, 626)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "WorkHistoryForm"
        Me.ShowInTaskbar = False
        Me.Text = "WorkHistoryForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.HistoryGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HistoryGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CloseSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents HistoryGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents HistoryGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CommentLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EventDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EventNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UserNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
