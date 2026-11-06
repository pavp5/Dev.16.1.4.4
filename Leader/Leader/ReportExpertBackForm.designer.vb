<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportExpertBackForm
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportExpertBackForm))
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.DateBeginBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DateEndBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ReportRunBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExportExcelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.ReportGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ReportGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ParentIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ParentDocNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AltIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ParentDocDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ClientNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ExpertNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrderDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ChangeSourceNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExpertCommentGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LeaderCommentGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NewIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NewDocNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NewDocDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.DateBeginBarEditItem, Me.DateEndBarEditItem, Me.ReportRunBarButtonItem, Me.ExportExcelBarButtonItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(1192, 96)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'DateBeginBarEditItem
        '
        Me.DateBeginBarEditItem.Caption = "Начало периода"
        Me.DateBeginBarEditItem.Edit = Me.RepositoryItemDateEdit1
        Me.DateBeginBarEditItem.EditWidth = 100
        Me.DateBeginBarEditItem.Id = 1
        Me.DateBeginBarEditItem.Name = "DateBeginBarEditItem"
        ToolTipTitleItem1.Text = "Начало периода"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Дата начала отчетного периода"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.DateBeginBarEditItem.SuperTip = SuperToolTip1
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'DateEndBarEditItem
        '
        Me.DateEndBarEditItem.Caption = "  Конец периода"
        Me.DateEndBarEditItem.Edit = Me.RepositoryItemDateEdit2
        Me.DateEndBarEditItem.EditWidth = 100
        Me.DateEndBarEditItem.Id = 2
        Me.DateEndBarEditItem.Name = "DateEndBarEditItem"
        ToolTipTitleItem2.Text = "Конец периода"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "дата конца отчетного периода"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.DateEndBarEditItem.SuperTip = SuperToolTip2
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'ReportRunBarButtonItem
        '
        Me.ReportRunBarButtonItem.Caption = "СОЗДАТЬ"
        Me.ReportRunBarButtonItem.Id = 3
        Me.ReportRunBarButtonItem.LargeGlyph = CType(resources.GetObject("ReportRunBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ReportRunBarButtonItem.Name = "ReportRunBarButtonItem"
        ToolTipTitleItem3.Text = "Создать"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Создать отчет"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.ReportRunBarButtonItem.SuperTip = SuperToolTip3
        '
        'ExportExcelBarButtonItem
        '
        Me.ExportExcelBarButtonItem.Caption = "Microsoft Excel"
        Me.ExportExcelBarButtonItem.Id = 4
        Me.ExportExcelBarButtonItem.LargeGlyph = CType(resources.GetObject("ExportExcelBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ExportExcelBarButtonItem.Name = "ExportExcelBarButtonItem"
        ToolTipTitleItem4.Text = "Microsoft Excel"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Экспорт отчета в Microsoft Excel"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.ExportExcelBarButtonItem.SuperTip = SuperToolTip4
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
        Me.RibbonPageGroup1.ItemLinks.Add(Me.ReportRunBarButtonItem)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.ShowCaptionButton = False
        Me.RibbonPageGroup1.Text = "Отчет"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.ExportExcelBarButtonItem)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.ShowCaptionButton = False
        Me.RibbonPageGroup2.Text = "Экспорт"
        '
        'ReportGridControl
        '
        Me.ReportGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportGridControl.Location = New System.Drawing.Point(0, 96)
        Me.ReportGridControl.MainView = Me.ReportGridView
        Me.ReportGridControl.MenuManager = Me.RibbonControl1
        Me.ReportGridControl.Name = "ReportGridControl"
        Me.ReportGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.ReportGridControl.Size = New System.Drawing.Size(1192, 625)
        Me.ReportGridControl.TabIndex = 2
        Me.ReportGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportGridView})
        '
        'ReportGridView
        '
        Me.ReportGridView.Appearance.FooterPanel.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.FooterPanel.Options.UseFont = True
        Me.ReportGridView.Appearance.GroupFooter.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.GroupFooter.Options.UseFont = True
        Me.ReportGridView.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 10.18868!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.GroupRow.Options.UseFont = True
        Me.ReportGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ReportGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReportGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.Row.Options.UseFont = True
        Me.ReportGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ReportGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.ReportGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ParentIdGridColumn, Me.ParentDocNumGridColumn, Me.ParentDocDateGridColumn, Me.NewIdGridColumn, Me.NewDocNumGridColumn, Me.NewDocDateGridColumn, Me.AltIdGridColumn, Me.ClientNameGridColumn, Me.ExpertNameGridColumn, Me.OrderDateGridColumn, Me.ChangeSourceNameGridColumn, Me.ExpertCommentGridColumn, Me.LeaderCommentGridColumn})
        Me.ReportGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue1.Value1 = CType(0, Short)
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue2.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = CType(0, Short)
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.ReportGridView.FormatRules.Add(GridFormatRule1)
        Me.ReportGridView.FormatRules.Add(GridFormatRule2)
        Me.ReportGridView.GridControl = Me.ReportGridControl
        Me.ReportGridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "sourceName", Nothing, "(Кол-во={0})")})
        Me.ReportGridView.Name = "ReportGridView"
        Me.ReportGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReportGridView.OptionsView.ColumnAutoWidth = False
        Me.ReportGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ReportGridView.OptionsView.RowAutoHeight = True
        Me.ReportGridView.OptionsView.ShowFooter = True
        Me.ReportGridView.OptionsView.ShowGroupPanel = False
        Me.ReportGridView.RowHeight = 25
        Me.ReportGridView.ViewCaption = "Перечень работ"
        '
        'ParentIdGridColumn
        '
        Me.ParentIdGridColumn.Caption = "Первичная работа"
        Me.ParentIdGridColumn.FieldName = "parentId"
        Me.ParentIdGridColumn.Name = "ParentIdGridColumn"
        Me.ParentIdGridColumn.Visible = True
        Me.ParentIdGridColumn.VisibleIndex = 0
        '
        'ParentDocNumGridColumn
        '
        Me.ParentDocNumGridColumn.Caption = "Первичное заключение номер"
        Me.ParentDocNumGridColumn.FieldName = "parentDocNum"
        Me.ParentDocNumGridColumn.Name = "ParentDocNumGridColumn"
        Me.ParentDocNumGridColumn.Visible = True
        Me.ParentDocNumGridColumn.VisibleIndex = 1
        Me.ParentDocNumGridColumn.Width = 120
        '
        'AltIdGridColumn
        '
        Me.AltIdGridColumn.Caption = "Заявка"
        Me.AltIdGridColumn.FieldName = "altId"
        Me.AltIdGridColumn.Name = "AltIdGridColumn"
        Me.AltIdGridColumn.Visible = True
        Me.AltIdGridColumn.VisibleIndex = 6
        '
        'ParentDocDateGridColumn
        '
        Me.ParentDocDateGridColumn.Caption = "Первичное заключение дата"
        Me.ParentDocDateGridColumn.FieldName = "parentDocDate"
        Me.ParentDocDateGridColumn.Name = "ParentDocDateGridColumn"
        Me.ParentDocDateGridColumn.Visible = True
        Me.ParentDocDateGridColumn.VisibleIndex = 2
        Me.ParentDocDateGridColumn.Width = 120
        '
        'ClientNameGridColumn
        '
        Me.ClientNameGridColumn.Caption = "Заказчик"
        Me.ClientNameGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.ClientNameGridColumn.FieldName = "clientName"
        Me.ClientNameGridColumn.Name = "ClientNameGridColumn"
        Me.ClientNameGridColumn.Visible = True
        Me.ClientNameGridColumn.VisibleIndex = 7
        Me.ClientNameGridColumn.Width = 200
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'ExpertNameGridColumn
        '
        Me.ExpertNameGridColumn.Caption = "Эксперт"
        Me.ExpertNameGridColumn.FieldName = "expertName"
        Me.ExpertNameGridColumn.Name = "ExpertNameGridColumn"
        Me.ExpertNameGridColumn.Visible = True
        Me.ExpertNameGridColumn.VisibleIndex = 8
        Me.ExpertNameGridColumn.Width = 130
        '
        'OrderDateGridColumn
        '
        Me.OrderDateGridColumn.Caption = "Дата обращения"
        Me.OrderDateGridColumn.FieldName = "orderDate"
        Me.OrderDateGridColumn.Name = "OrderDateGridColumn"
        Me.OrderDateGridColumn.Visible = True
        Me.OrderDateGridColumn.VisibleIndex = 9
        Me.OrderDateGridColumn.Width = 80
        '
        'ChangeSourceNameGridColumn
        '
        Me.ChangeSourceNameGridColumn.Caption = "Источник изменений"
        Me.ChangeSourceNameGridColumn.FieldName = "changeSourceName"
        Me.ChangeSourceNameGridColumn.Name = "ChangeSourceNameGridColumn"
        Me.ChangeSourceNameGridColumn.Visible = True
        Me.ChangeSourceNameGridColumn.VisibleIndex = 10
        Me.ChangeSourceNameGridColumn.Width = 95
        '
        'ExpertCommentGridColumn
        '
        Me.ExpertCommentGridColumn.Caption = "Пояснения эксперта"
        Me.ExpertCommentGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.ExpertCommentGridColumn.FieldName = "expertComment"
        Me.ExpertCommentGridColumn.Name = "ExpertCommentGridColumn"
        Me.ExpertCommentGridColumn.Visible = True
        Me.ExpertCommentGridColumn.VisibleIndex = 11
        Me.ExpertCommentGridColumn.Width = 300
        '
        'LeaderCommentGridColumn
        '
        Me.LeaderCommentGridColumn.Caption = "Решение руководителя"
        Me.LeaderCommentGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.LeaderCommentGridColumn.FieldName = "leaderComment"
        Me.LeaderCommentGridColumn.Name = "LeaderCommentGridColumn"
        Me.LeaderCommentGridColumn.Visible = True
        Me.LeaderCommentGridColumn.VisibleIndex = 12
        Me.LeaderCommentGridColumn.Width = 300
        '
        'NewIdGridColumn
        '
        Me.NewIdGridColumn.Caption = "Новая работа"
        Me.NewIdGridColumn.FieldName = "newId"
        Me.NewIdGridColumn.Name = "NewIdGridColumn"
        Me.NewIdGridColumn.Visible = True
        Me.NewIdGridColumn.VisibleIndex = 3
        '
        'NewDocNumGridColumn
        '
        Me.NewDocNumGridColumn.Caption = "Новое заключение номер"
        Me.NewDocNumGridColumn.FieldName = "newDocNum"
        Me.NewDocNumGridColumn.Name = "NewDocNumGridColumn"
        Me.NewDocNumGridColumn.Visible = True
        Me.NewDocNumGridColumn.VisibleIndex = 4
        Me.NewDocNumGridColumn.Width = 120
        '
        'NewDocDateGridColumn
        '
        Me.NewDocDateGridColumn.Caption = "Новое заключение дата"
        Me.NewDocDateGridColumn.FieldName = "newDocDate"
        Me.NewDocDateGridColumn.Name = "NewDocDateGridColumn"
        Me.NewDocDateGridColumn.Visible = True
        Me.NewDocDateGridColumn.VisibleIndex = 5
        Me.NewDocDateGridColumn.Width = 120
        '
        'ReportExpertBackForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1192, 721)
        Me.Controls.Add(Me.ReportGridControl)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "ReportExpertBackForm"
        Me.Text = "ReportExpertBack"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DateBeginBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DateEndBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ReportRunBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ExportExcelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AltIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ParentIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ClientNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpertNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrderDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpertCommentGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LeaderCommentGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ChangeSourceNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ParentDocNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ParentDocDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NewIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NewDocNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NewDocDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
End Class
