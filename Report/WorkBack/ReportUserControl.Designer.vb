<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportUserControl
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
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PieSeriesView1 As DevExpress.XtraCharts.PieSeriesView = New DevExpress.XtraCharts.PieSeriesView()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportUserControl))
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PercentChartControl = New DevExpress.XtraCharts.ChartControl()
        Me.ReportGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ReportGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ParentIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ParentDocNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ParentDocDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NewIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NewDocNumGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NewDocDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AltIdGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ClientNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ExpertNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrderDateGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ChangeSourceNameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExpertCommentGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LeaderCommentGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.FindBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FindRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.DateBeginBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.DateBeginRepositoryItemDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DateEndBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.DateEndRepositoryItemDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ReportRunBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ExportExcelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.WorkCountStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.AlterCountBarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.AlterClientCountBarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.AlterExpertCountBarStaticItem = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarHeaderItem1 = New DevExpress.XtraBars.BarHeaderItem()
        Me.ClientOrderRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PercentChartControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateBeginRepositoryItemDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateBeginRepositoryItemDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEndRepositoryItemDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEndRepositoryItemDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientOrderRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.PercentChartControl)
        Me.LayoutControl1.Controls.Add(Me.ReportGridControl)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(620, 395, 276, 386)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1300, 467)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PercentChartControl
        '
        Me.PercentChartControl.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
        Me.PercentChartControl.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.PercentChartControl.Legend.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PercentChartControl.Legend.Name = "Default Legend"
        Me.PercentChartControl.Legend.VerticalIndent = 6
        Me.PercentChartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.PercentChartControl.Location = New System.Drawing.Point(1086, 16)
        Me.PercentChartControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PercentChartControl.Name = "PercentChartControl"
        Me.PercentChartControl.PaletteName = "Metro"
        Me.PercentChartControl.SelectionMode = DevExpress.XtraCharts.ElementSelectionMode.[Single]
        Me.PercentChartControl.SeriesSelectionMode = DevExpress.XtraCharts.SeriesSelectionMode.Argument
        Series1.ArgumentDataMember = "name"
        Series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.LegendName = "Default Legend"
        Series1.LegendTextPattern = "{VP:0.00%} {A}"
        Series1.Name = "Percent"
        Series1.ValueDataMembersSerializable = "workCount"
        Series1.View = PieSeriesView1
        Me.PercentChartControl.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.PercentChartControl.Size = New System.Drawing.Size(198, 435)
        Me.PercentChartControl.TabIndex = 9
        '
        'ReportGridControl
        '
        Me.ReportGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportGridControl.Location = New System.Drawing.Point(16, 69)
        Me.ReportGridControl.MainView = Me.ReportGridView
        Me.ReportGridControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReportGridControl.Name = "ReportGridControl"
        Me.ReportGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.ReportGridControl.Size = New System.Drawing.Size(1049, 382)
        Me.ReportGridControl.TabIndex = 5
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
        Me.ReportGridView.ViewCaption = "Внесения изменений"
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
        'ParentDocDateGridColumn
        '
        Me.ParentDocDateGridColumn.Caption = "Первичное заключение дата"
        Me.ParentDocDateGridColumn.FieldName = "parentDocDate"
        Me.ParentDocDateGridColumn.Name = "ParentDocDateGridColumn"
        Me.ParentDocDateGridColumn.Visible = True
        Me.ParentDocDateGridColumn.VisibleIndex = 2
        Me.ParentDocDateGridColumn.Width = 120
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
        'AltIdGridColumn
        '
        Me.AltIdGridColumn.Caption = "Заявка"
        Me.AltIdGridColumn.FieldName = "altId"
        Me.AltIdGridColumn.Name = "AltIdGridColumn"
        Me.AltIdGridColumn.Visible = True
        Me.AltIdGridColumn.VisibleIndex = 6
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
        Me.LeaderCommentGridColumn.Width = 300
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(16, 16)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(1049, 47)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem1, Me.SplitterItem1, Me.LayoutControlItem2})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1300, 467)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1055, 53)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ReportGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1055, 388)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(1055, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(15, 441)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.PercentChartControl
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1070, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(204, 441)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'BarManager1
        '
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.FindBarEditItem, Me.ExportExcelBarButtonItem, Me.DateBeginBarEditItem, Me.DateEndBarEditItem, Me.ReportRunBarButtonItem, Me.WorkCountStaticItem, Me.AlterCountBarStaticItem, Me.AlterClientCountBarStaticItem, Me.BarHeaderItem1, Me.AlterExpertCountBarStaticItem})
        Me.BarManager1.MaxItemId = 23
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.FindRepositoryItemButtonEdit, Me.DateBeginRepositoryItemDateEdit, Me.DateEndRepositoryItemDateEdit, Me.ClientOrderRepositoryItemTextEdit})
        Me.BarManager1.StatusBar = Me.Bar2
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(93, 143)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DateBeginBarEditItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DateEndBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ReportRunBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.ExportExcelBarButtonItem, True)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'FindBarEditItem
        '
        Me.FindBarEditItem.Caption = "Поиск"
        Me.FindBarEditItem.Edit = Me.FindRepositoryItemButtonEdit
        Me.FindBarEditItem.EditWidth = 140
        Me.FindBarEditItem.Id = 0
        Me.FindBarEditItem.Name = "FindBarEditItem"
        '
        'FindRepositoryItemButtonEdit
        '
        Me.FindRepositoryItemButtonEdit.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.FindRepositoryItemButtonEdit.Appearance.Font = New System.Drawing.Font("Arial", 10.8!)
        Me.FindRepositoryItemButtonEdit.Appearance.Options.UseBackColor = True
        Me.FindRepositoryItemButtonEdit.Appearance.Options.UseFont = True
        Me.FindRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem1.Text = "Очистить"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Очистить поле поиска"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.FindRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, SuperToolTip1, True)})
        Me.FindRepositoryItemButtonEdit.Name = "FindRepositoryItemButtonEdit"
        '
        'DateBeginBarEditItem
        '
        Me.DateBeginBarEditItem.Caption = "Дата начала"
        Me.DateBeginBarEditItem.Edit = Me.DateBeginRepositoryItemDateEdit
        Me.DateBeginBarEditItem.EditWidth = 120
        Me.DateBeginBarEditItem.Id = 8
        Me.DateBeginBarEditItem.Name = "DateBeginBarEditItem"
        '
        'DateBeginRepositoryItemDateEdit
        '
        Me.DateBeginRepositoryItemDateEdit.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DateBeginRepositoryItemDateEdit.Appearance.Options.UseFont = True
        Me.DateBeginRepositoryItemDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateBeginRepositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateBeginRepositoryItemDateEdit.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.DateBeginRepositoryItemDateEdit.Name = "DateBeginRepositoryItemDateEdit"
        Me.DateBeginRepositoryItemDateEdit.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        '
        'DateEndBarEditItem
        '
        Me.DateEndBarEditItem.Caption = "Дата конца"
        Me.DateEndBarEditItem.Edit = Me.DateEndRepositoryItemDateEdit
        Me.DateEndBarEditItem.EditWidth = 120
        Me.DateEndBarEditItem.Id = 9
        Me.DateEndBarEditItem.Name = "DateEndBarEditItem"
        '
        'DateEndRepositoryItemDateEdit
        '
        Me.DateEndRepositoryItemDateEdit.Appearance.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DateEndRepositoryItemDateEdit.Appearance.Options.UseFont = True
        Me.DateEndRepositoryItemDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEndRepositoryItemDateEdit.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEndRepositoryItemDateEdit.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.DateEndRepositoryItemDateEdit.Name = "DateEndRepositoryItemDateEdit"
        Me.DateEndRepositoryItemDateEdit.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ReportRunBarButtonItem
        '
        Me.ReportRunBarButtonItem.Caption = "ОТЧЕТ"
        Me.ReportRunBarButtonItem.Glyph = CType(resources.GetObject("ReportRunBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ReportRunBarButtonItem.Id = 11
        Me.ReportRunBarButtonItem.Name = "ReportRunBarButtonItem"
        ToolTipTitleItem2.Text = "Отчет"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Сформировать отчет"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.ReportRunBarButtonItem.SuperTip = SuperToolTip2
        '
        'ExportExcelBarButtonItem
        '
        Me.ExportExcelBarButtonItem.Caption = "Экспорт"
        Me.ExportExcelBarButtonItem.Glyph = CType(resources.GetObject("ExportExcelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ExportExcelBarButtonItem.Id = 5
        Me.ExportExcelBarButtonItem.Name = "ExportExcelBarButtonItem"
        ToolTipTitleItem3.Text = "Экспорт"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Экспорт списка в Microsoft Excel"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.ExportExcelBarButtonItem.SuperTip = SuperToolTip3
        '
        'Bar2
        '
        Me.Bar2.BarItemVertIndent = 6
        Me.Bar2.BarName = "Сводные данные"
        Me.Bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.WorkCountStaticItem), New DevExpress.XtraBars.LinkPersistInfo(Me.AlterCountBarStaticItem), New DevExpress.XtraBars.LinkPersistInfo(Me.AlterClientCountBarStaticItem), New DevExpress.XtraBars.LinkPersistInfo(Me.AlterExpertCountBarStaticItem)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Сводные данные"
        '
        'WorkCountStaticItem
        '
        Me.WorkCountStaticItem.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.WorkCountStaticItem.Caption = "Выдано заключений: -"
        Me.WorkCountStaticItem.Id = 18
        Me.WorkCountStaticItem.Name = "WorkCountStaticItem"
        Me.WorkCountStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'AlterCountBarStaticItem
        '
        Me.AlterCountBarStaticItem.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.AlterCountBarStaticItem.Caption = "Внесено изменений: -"
        Me.AlterCountBarStaticItem.Id = 19
        Me.AlterCountBarStaticItem.Name = "AlterCountBarStaticItem"
        Me.AlterCountBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'AlterClientCountBarStaticItem
        '
        Me.AlterClientCountBarStaticItem.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.AlterClientCountBarStaticItem.Caption = "По вине заказчика: -"
        Me.AlterClientCountBarStaticItem.Id = 20
        Me.AlterClientCountBarStaticItem.Name = "AlterClientCountBarStaticItem"
        Me.AlterClientCountBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'AlterExpertCountBarStaticItem
        '
        Me.AlterExpertCountBarStaticItem.AllowHtmlText = DevExpress.Utils.DefaultBoolean.[True]
        Me.AlterExpertCountBarStaticItem.Caption = "По вине эксперта: - "
        Me.AlterExpertCountBarStaticItem.Id = 22
        Me.AlterExpertCountBarStaticItem.Name = "AlterExpertCountBarStaticItem"
        Me.AlterExpertCountBarStaticItem.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1300, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 467)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1300, 33)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 467)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1300, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 467)
        '
        'BarHeaderItem1
        '
        Me.BarHeaderItem1.Caption = "По вине эксперта: -"
        Me.BarHeaderItem1.Id = 21
        Me.BarHeaderItem1.Name = "BarHeaderItem1"
        '
        'ClientOrderRepositoryItemTextEdit
        '
        Me.ClientOrderRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Arial", 10.2!)
        Me.ClientOrderRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.ClientOrderRepositoryItemTextEdit.AutoHeight = False
        Me.ClientOrderRepositoryItemTextEdit.Name = "ClientOrderRepositoryItemTextEdit"
        Me.ClientOrderRepositoryItemTextEdit.NullValuePrompt = "наименование, ИНН, здоговор"
        Me.ClientOrderRepositoryItemTextEdit.NullValuePromptShowForEmptyValue = True
        Me.ClientOrderRepositoryItemTextEdit.ShowNullValuePromptWhenFocused = True
        '
        'ReportUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ReportUserControl"
        Me.Size = New System.Drawing.Size(1300, 500)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(PieSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PercentChartControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateBeginRepositoryItemDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateBeginRepositoryItemDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEndRepositoryItemDateEdit.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEndRepositoryItemDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientOrderRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FindBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents FindRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ExportExcelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DateBeginBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents DateBeginRepositoryItemDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DateEndBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents DateEndRepositoryItemDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ClientOrderRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ReportRunBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ParentIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ParentDocNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ParentDocDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NewIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NewDocNumGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NewDocDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AltIdGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ClientNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ExpertNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrderDateGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ChangeSourceNameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpertCommentGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LeaderCommentGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents WorkCountStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents AlterCountBarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents AlterClientCountBarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents AlterExpertCountBarStaticItem As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarHeaderItem1 As DevExpress.XtraBars.BarHeaderItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents PercentChartControl As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem

End Class
