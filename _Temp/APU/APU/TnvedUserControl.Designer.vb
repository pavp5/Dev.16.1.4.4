<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TnvedUserControl
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TnvedUserControl))
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.TypeIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.LawShowBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.TnvedBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.TnvedRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ReplaceBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LawGridControl = New DevExpress.XtraGrid.GridControl()
        Me.LawGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PosDescriptionGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ApuGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SortIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TnvedDescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TnvedRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.LawGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LawGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TnvedDescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TypeIdGridColumn
        '
        Me.TypeIdGridColumn.Caption = "typeId"
        Me.TypeIdGridColumn.FieldName = "typeId"
        Me.TypeIdGridColumn.Name = "TypeIdGridColumn"
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.LawShowBarButtonItem, Me.TnvedBarEditItem, Me.ReplaceBarButtonItem})
        Me.BarManager1.MaxItemId = 3
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.TnvedRepositoryItemLookUpEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.LawShowBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.TnvedBarEditItem, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ReplaceBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'LawShowBarButtonItem
        '
        Me.LawShowBarButtonItem.Caption = "Списки"
        Me.LawShowBarButtonItem.Glyph = CType(resources.GetObject("LawShowBarButtonItem.Glyph"), System.Drawing.Image)
        Me.LawShowBarButtonItem.Id = 0
        Me.LawShowBarButtonItem.Name = "LawShowBarButtonItem"
        ToolTipTitleItem3.Text = "Списки"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Показать пункт в дереве контрольных списков"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.LawShowBarButtonItem.SuperTip = SuperToolTip3
        '
        'TnvedBarEditItem
        '
        Me.TnvedBarEditItem.Caption = "Код ТНВЭД"
        Me.TnvedBarEditItem.Edit = Me.TnvedRepositoryItemLookUpEdit
        Me.TnvedBarEditItem.EditWidth = 160
        Me.TnvedBarEditItem.Id = 1
        Me.TnvedBarEditItem.Name = "TnvedBarEditItem"
        Me.TnvedBarEditItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'TnvedRepositoryItemLookUpEdit
        '
        Me.TnvedRepositoryItemLookUpEdit.Appearance.Font = New System.Drawing.Font("Arial", 10.86792!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TnvedRepositoryItemLookUpEdit.Appearance.Options.UseFont = True
        Me.TnvedRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Arial", 10.86792!)
        Me.TnvedRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.TnvedRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TnvedRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code", "code")})
        Me.TnvedRepositoryItemLookUpEdit.DisplayMember = "code"
        Me.TnvedRepositoryItemLookUpEdit.Name = "TnvedRepositoryItemLookUpEdit"
        Me.TnvedRepositoryItemLookUpEdit.NullText = ""
        Me.TnvedRepositoryItemLookUpEdit.ShowFooter = False
        Me.TnvedRepositoryItemLookUpEdit.ShowHeader = False
        Me.TnvedRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TnvedRepositoryItemLookUpEdit.ValueMember = "code"
        '
        'ReplaceBarButtonItem
        '
        Me.ReplaceBarButtonItem.Caption = "Заменить"
        Me.ReplaceBarButtonItem.Glyph = CType(resources.GetObject("ReplaceBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ReplaceBarButtonItem.Id = 2
        Me.ReplaceBarButtonItem.Name = "ReplaceBarButtonItem"
        ToolTipTitleItem4.Text = "Заменить"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Найти и заменить текст в АПУ"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.ReplaceBarButtonItem.SuperTip = SuperToolTip4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1000, 39)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 700)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1000, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 39)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 661)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1000, 39)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 661)
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LawGridControl)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.TnvedDescriptionMemoEdit)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1000, 661)
        Me.SplitContainerControl1.TabIndex = 10
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LawGridControl
        '
        Me.LawGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LawGridControl.Location = New System.Drawing.Point(0, 0)
        Me.LawGridControl.MainView = Me.LawGridView
        Me.LawGridControl.MenuManager = Me.BarManager1
        Me.LawGridControl.Name = "LawGridControl"
        Me.LawGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.LawGridControl.Size = New System.Drawing.Size(1000, 548)
        Me.LawGridControl.TabIndex = 0
        Me.LawGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.LawGridView})
        '
        'LawGridView
        '
        Me.LawGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.LawGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LawGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LawGridView.Appearance.Row.Options.UseFont = True
        Me.LawGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PosDescriptionGridColumn, Me.ApuGridColumn, Me.SortIdGridColumn, Me.TypeIdGridColumn})
        GridFormatRule3.ApplyToRow = True
        GridFormatRule3.Column = Me.TypeIdGridColumn
        GridFormatRule3.Name = "Format0"
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Gray
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = CType(2, Short)
        GridFormatRule3.Rule = FormatConditionRuleValue3
        GridFormatRule4.ApplyToRow = True
        GridFormatRule4.Column = Me.TypeIdGridColumn
        GridFormatRule4.Name = "Format1"
        FormatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        FormatConditionRuleValue4.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = CType(4, Short)
        GridFormatRule4.Rule = FormatConditionRuleValue4
        Me.LawGridView.FormatRules.Add(GridFormatRule3)
        Me.LawGridView.FormatRules.Add(GridFormatRule4)
        Me.LawGridView.GridControl = Me.LawGridControl
        Me.LawGridView.Name = "LawGridView"
        Me.LawGridView.OptionsDetail.EnableMasterViewMode = False
        Me.LawGridView.OptionsView.RowAutoHeight = True
        Me.LawGridView.OptionsView.ShowGroupPanel = False
        Me.LawGridView.OptionsView.ShowIndicator = False
        '
        'PosDescriptionGridColumn
        '
        Me.PosDescriptionGridColumn.Caption = "Описание пункта контрольного списка"
        Me.PosDescriptionGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.PosDescriptionGridColumn.FieldName = "posDescription"
        Me.PosDescriptionGridColumn.Name = "PosDescriptionGridColumn"
        Me.PosDescriptionGridColumn.OptionsColumn.AllowEdit = False
        Me.PosDescriptionGridColumn.Visible = True
        Me.PosDescriptionGridColumn.VisibleIndex = 0
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'ApuGridColumn
        '
        Me.ApuGridColumn.Caption = "Описание пункта АПУ"
        Me.ApuGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.ApuGridColumn.FieldName = "apu"
        Me.ApuGridColumn.Name = "ApuGridColumn"
        Me.ApuGridColumn.Visible = True
        Me.ApuGridColumn.VisibleIndex = 1
        '
        'SortIdGridColumn
        '
        Me.SortIdGridColumn.Caption = "sortId"
        Me.SortIdGridColumn.FieldName = "sortid"
        Me.SortIdGridColumn.Name = "SortIdGridColumn"
        '
        'TnvedDescriptionMemoEdit
        '
        Me.TnvedDescriptionMemoEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TnvedDescriptionMemoEdit.Location = New System.Drawing.Point(0, 0)
        Me.TnvedDescriptionMemoEdit.Name = "TnvedDescriptionMemoEdit"
        Me.TnvedDescriptionMemoEdit.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TnvedDescriptionMemoEdit.Properties.Appearance.Options.UseFont = True
        Me.TnvedDescriptionMemoEdit.Properties.ReadOnly = True
        Me.TnvedDescriptionMemoEdit.Size = New System.Drawing.Size(1000, 100)
        Me.TnvedDescriptionMemoEdit.TabIndex = 0
        '
        'EditTnvedUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "EditTnvedUserControl"
        Me.Size = New System.Drawing.Size(1000, 700)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TnvedRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.LawGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LawGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TnvedDescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents LawShowBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TnvedBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents TnvedRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents ReplaceBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TnvedDescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LawGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents LawGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PosDescriptionGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ApuGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SortIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TypeIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn

End Class
