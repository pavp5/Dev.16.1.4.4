<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkCalcForm
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
        Me.CalcGridControl = New DevExpress.XtraGrid.GridControl()
        Me.CalcGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.PriceGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CloseSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CalcGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalcGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.CalcGridControl)
        Me.LayoutControl1.Controls.Add(Me.CloseSimpleButton)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(393, 165, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(642, 426)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CalcGridControl
        '
        Me.CalcGridControl.Location = New System.Drawing.Point(13, 13)
        Me.CalcGridControl.MainView = Me.CalcGridView
        Me.CalcGridControl.Name = "CalcGridControl"
        Me.CalcGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.CalcGridControl.Size = New System.Drawing.Size(616, 374)
        Me.CalcGridControl.TabIndex = 5
        Me.CalcGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CalcGridView})
        '
        'CalcGridView
        '
        Me.CalcGridView.Appearance.FooterPanel.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold)
        Me.CalcGridView.Appearance.FooterPanel.Options.UseFont = True
        Me.CalcGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.CalcGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CalcGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CalcGridView.Appearance.Row.Options.UseFont = True
        Me.CalcGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IdGridColumn, Me.DescriptionGridColumn, Me.PriceGridColumn})
        Me.CalcGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.CalcGridView.GridControl = Me.CalcGridControl
        Me.CalcGridView.Name = "CalcGridView"
        Me.CalcGridView.OptionsBehavior.ReadOnly = True
        Me.CalcGridView.OptionsMenu.EnableColumnMenu = False
        Me.CalcGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CalcGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.CalcGridView.OptionsView.RowAutoHeight = True
        Me.CalcGridView.OptionsView.ShowFooter = True
        Me.CalcGridView.OptionsView.ShowGroupPanel = False
        Me.CalcGridView.RowHeight = 30
        '
        'IdGridColumn
        '
        Me.IdGridColumn.Caption = "id"
        Me.IdGridColumn.FieldName = "id"
        Me.IdGridColumn.Name = "IdGridColumn"
        '
        'DescriptionGridColumn
        '
        Me.DescriptionGridColumn.Caption = "Описание услуги"
        Me.DescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.DescriptionGridColumn.FieldName = "description"
        Me.DescriptionGridColumn.Name = "DescriptionGridColumn"
        Me.DescriptionGridColumn.Visible = True
        Me.DescriptionGridColumn.VisibleIndex = 0
        Me.DescriptionGridColumn.Width = 367
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'PriceGridColumn
        '
        Me.PriceGridColumn.Caption = "Стоимость"
        Me.PriceGridColumn.FieldName = "price"
        Me.PriceGridColumn.Name = "PriceGridColumn"
        Me.PriceGridColumn.OptionsColumn.FixedWidth = True
        Me.PriceGridColumn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "price", "{0:0.##}")})
        Me.PriceGridColumn.Visible = True
        Me.PriceGridColumn.VisibleIndex = 1
        Me.PriceGridColumn.Width = 105
        '
        'CloseSimpleButton
        '
        Me.CloseSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CloseSimpleButton.Appearance.Options.UseFont = True
        Me.CloseSimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseSimpleButton.Location = New System.Drawing.Point(519, 391)
        Me.CloseSimpleButton.Name = "CloseSimpleButton"
        Me.CloseSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.CloseSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.CloseSimpleButton.StyleController = Me.LayoutControl1
        Me.CloseSimpleButton.TabIndex = 6
        Me.CloseSimpleButton.Text = "ЗАКРЫТЬ"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.EmptySpaceItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(642, 426)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CalcGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(620, 378)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CloseSimpleButton
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(506, 378)
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
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 378)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(506, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'WorkCalcForm
        '
        Me.AcceptButton = Me.CloseSimpleButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseSimpleButton
        Me.ClientSize = New System.Drawing.Size(642, 426)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "WorkCalcForm"
        Me.ShowInTaskbar = False
        Me.Text = "WorkCalcForm"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CalcGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalcGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CalcGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CalcGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CloseSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents IdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PriceGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
