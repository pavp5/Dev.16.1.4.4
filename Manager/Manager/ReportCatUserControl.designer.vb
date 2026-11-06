<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportCatUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportCatUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule3 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue3 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule4 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue4 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule5 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue5 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule6 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue6 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.DateBeginBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DateEndBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ReportStartBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ReportExcelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.CaptionLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.ReportGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ReportGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RowNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NameDecGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NameConGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ActDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.DateBeginBarEditItem, Me.DateEndBarEditItem, Me.ReportStartBarButtonItem, Me.ReportExcelBarButtonItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(1150, 80)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'DateBeginBarEditItem
        '
        Me.DateBeginBarEditItem.Caption = "Дата начала"
        Me.DateBeginBarEditItem.Edit = Me.RepositoryItemDateEdit1
        Me.DateBeginBarEditItem.EditWidth = 100
        Me.DateBeginBarEditItem.Id = 1
        Me.DateBeginBarEditItem.Name = "DateBeginBarEditItem"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'DateEndBarEditItem
        '
        Me.DateEndBarEditItem.Caption = "  Дата конца"
        Me.DateEndBarEditItem.Edit = Me.RepositoryItemDateEdit2
        Me.DateEndBarEditItem.EditWidth = 100
        Me.DateEndBarEditItem.Id = 2
        Me.DateEndBarEditItem.Name = "DateEndBarEditItem"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'ReportStartBarButtonItem
        '
        Me.ReportStartBarButtonItem.Caption = "ОТЧЕТ"
        Me.ReportStartBarButtonItem.Id = 3
        Me.ReportStartBarButtonItem.LargeGlyph = CType(resources.GetObject("ReportStartBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportStartBarButtonItem.Name = "ReportStartBarButtonItem"
        ToolTipTitleItem1.Text = "Отчет"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Создать отчет"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.ReportStartBarButtonItem.SuperTip = SuperToolTip1
        '
        'ReportExcelBarButtonItem
        '
        Me.ReportExcelBarButtonItem.Caption = "Excel"
        Me.ReportExcelBarButtonItem.Id = 4
        Me.ReportExcelBarButtonItem.LargeGlyph = CType(resources.GetObject("ReportExcelBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportExcelBarButtonItem.Name = "ReportExcelBarButtonItem"
        ToolTipTitleItem2.Text = "Excel"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Экспорт отчета в файл Microsoft Excel"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ReportExcelBarButtonItem.SuperTip = SuperToolTip2
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.DateBeginBarEditItem)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.DateEndBarEditItem)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.ReportStartBarButtonItem)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.ShowCaptionButton = False
        Me.RibbonPageGroup1.Text = "Отчет"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.ReportExcelBarButtonItem)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        Me.RibbonPageGroup2.Text = "Экспорт"
        '
        'CaptionLabelControl
        '
        Me.CaptionLabelControl.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionLabelControl.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.CaptionLabelControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.CaptionLabelControl.Location = New System.Drawing.Point(0, 80)
        Me.CaptionLabelControl.Name = "CaptionLabelControl"
        Me.CaptionLabelControl.Padding = New System.Windows.Forms.Padding(6)
        Me.CaptionLabelControl.Size = New System.Drawing.Size(1150, 37)
        Me.CaptionLabelControl.TabIndex = 10
        Me.CaptionLabelControl.Text = "Отчет по новым товарам ""Катерпиллер"""
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 117)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(1150, 1)
        Me.SeparatorControl1.TabIndex = 11
        '
        'ReportGridControl
        '
        Me.ReportGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportGridControl.Location = New System.Drawing.Point(0, 118)
        Me.ReportGridControl.MainView = Me.ReportGridView
        Me.ReportGridControl.Name = "ReportGridControl"
        Me.ReportGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1, Me.RepositoryItemMemoEdit1})
        Me.ReportGridControl.Size = New System.Drawing.Size(1150, 432)
        Me.ReportGridControl.TabIndex = 12
        Me.ReportGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportGridView})
        '
        'ReportGridView
        '
        Me.ReportGridView.Appearance.FooterPanel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportGridView.Appearance.FooterPanel.Options.UseFont = True
        Me.ReportGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ReportGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReportGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.Row.Options.UseFont = True
        Me.ReportGridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ReportGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RowNumGridColumn, Me.NameDecGridColumn, Me.NameConGridColumn, Me.ActDateGridColumn})
        Me.ReportGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.OldLace
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = False
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue2.Expression = "[expertTerm] < AddMinutes(Now(), 30) And ([conditionName] Like '%нова%' Or [condi" & _
    "tionName] Like '%работ%') Or [orderTerm] < AddMinutes(Now(), 30)"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue3.Expression = "[expertTerm] < Now() And ([conditionName] Like '%нова%' Or [conditionName] Like '" & _
    "%работ%')"
        GridFormatRule3.Rule = FormatConditionRuleValue3
        GridFormatRule4.Name = "Format3"
        FormatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue4.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue4.Expression = "[orderTerm] < Now()"
        GridFormatRule4.Rule = FormatConditionRuleValue4
        GridFormatRule5.ApplyToRow = True
        GridFormatRule5.Name = "Format4"
        FormatConditionRuleValue5.Appearance.BackColor = System.Drawing.Color.Azure
        FormatConditionRuleValue5.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue5.Expression = "[conditionName] Like '%роек%'"
        GridFormatRule5.Rule = FormatConditionRuleValue5
        GridFormatRule6.ApplyToRow = True
        GridFormatRule6.Name = "Format5"
        FormatConditionRuleValue6.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue6.Appearance.Options.UseFont = True
        FormatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue6.Expression = "[conditionName] Like '%ечат%'"
        GridFormatRule6.Rule = FormatConditionRuleValue6
        Me.ReportGridView.FormatRules.Add(GridFormatRule1)
        Me.ReportGridView.FormatRules.Add(GridFormatRule2)
        Me.ReportGridView.FormatRules.Add(GridFormatRule3)
        Me.ReportGridView.FormatRules.Add(GridFormatRule4)
        Me.ReportGridView.FormatRules.Add(GridFormatRule5)
        Me.ReportGridView.FormatRules.Add(GridFormatRule6)
        Me.ReportGridView.GridControl = Me.ReportGridControl
        Me.ReportGridView.Name = "ReportGridView"
        Me.ReportGridView.OptionsBehavior.Editable = False
        Me.ReportGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReportGridView.OptionsView.ColumnAutoWidth = False
        Me.ReportGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ReportGridView.OptionsView.RowAutoHeight = True
        Me.ReportGridView.OptionsView.ShowFooter = True
        Me.ReportGridView.OptionsView.ShowGroupPanel = False
        Me.ReportGridView.RowHeight = 30
        '
        'RowNumGridColumn
        '
        Me.RowNumGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowNumGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowNumGridColumn.Caption = "№№"
        Me.RowNumGridColumn.FieldName = "rowNum"
        Me.RowNumGridColumn.Name = "RowNumGridColumn"
        Me.RowNumGridColumn.Visible = True
        Me.RowNumGridColumn.VisibleIndex = 0
        '
        'NameDecGridColumn
        '
        Me.NameDecGridColumn.Caption = "Номер по каталогу (артикул)"
        Me.NameDecGridColumn.FieldName = "nameDec"
        Me.NameDecGridColumn.Name = "NameDecGridColumn"
        Me.NameDecGridColumn.Visible = True
        Me.NameDecGridColumn.VisibleIndex = 1
        Me.NameDecGridColumn.Width = 140
        '
        'NameConGridColumn
        '
        Me.NameConGridColumn.Caption = "Наименование товара"
        Me.NameConGridColumn.FieldName = "nameCon"
        Me.NameConGridColumn.Name = "NameConGridColumn"
        Me.NameConGridColumn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "nameCon", "Итого: {0}")})
        Me.NameConGridColumn.Visible = True
        Me.NameConGridColumn.VisibleIndex = 2
        Me.NameConGridColumn.Width = 500
        '
        'ActDateGridColumn
        '
        Me.ActDateGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.ActDateGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ActDateGridColumn.Caption = "Дата / время добавления"
        Me.ActDateGridColumn.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.ActDateGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ActDateGridColumn.FieldName = "actDate"
        Me.ActDateGridColumn.Name = "ActDateGridColumn"
        Me.ActDateGridColumn.Visible = True
        Me.ActDateGridColumn.VisibleIndex = 3
        Me.ActDateGridColumn.Width = 140
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ShowTitle = True
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'ReportCatUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReportGridControl)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.CaptionLabelControl)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "ReportCatUserControl"
        Me.Size = New System.Drawing.Size(1150, 550)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents CaptionLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents ReportGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RowNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameDecGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NameConGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ActDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents DateBeginBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DateEndBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ReportStartBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportExcelBarButtonItem As DevExpress.XtraBars.BarButtonItem

End Class
