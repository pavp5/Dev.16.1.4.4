<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegionUserControl
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView1 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
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
        Dim GridFormatRule7 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue7 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule8 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue8 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.WorkChartControl = New DevExpress.XtraCharts.ChartControl()
        Me.ReportGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ReportGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkCountGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WorkCountRepositoryItemProgressBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.WorkChartControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkCountRepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.WorkChartControl)
        Me.LayoutControl1.Controls.Add(Me.ReportGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(723, 391, 276, 386)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'WorkChartControl
        '
        XyDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = False
        XyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DevExpress.XtraCharts.DateTimeGridAlignment.Month
        XyDiagram1.AxisX.DateTimeScaleOptions.GridSpacing = 2.0R
        XyDiagram1.AxisX.DateTimeScaleOptions.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.WorkChartControl.Diagram = XyDiagram1
        Me.WorkChartControl.Legend.Name = "Default Legend"
        Me.WorkChartControl.Location = New System.Drawing.Point(2, 419)
        Me.WorkChartControl.Name = "WorkChartControl"
        Series1.ArgumentDataMember = "orderDate"
        Series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime
        Series1.Name = "Series 1"
        Series1.SummaryFunction = "COUNT()"
        Series1.View = LineSeriesView1
        Me.WorkChartControl.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.WorkChartControl.Size = New System.Drawing.Size(946, 229)
        Me.WorkChartControl.TabIndex = 1
        '
        'ReportGridControl
        '
        Me.ReportGridControl.Location = New System.Drawing.Point(2, 2)
        Me.ReportGridControl.MainView = Me.ReportGridView
        Me.ReportGridControl.Name = "ReportGridControl"
        Me.ReportGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.WorkCountRepositoryItemProgressBar})
        Me.ReportGridControl.Size = New System.Drawing.Size(946, 400)
        Me.ReportGridControl.TabIndex = 0
        Me.ReportGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportGridView})
        '
        'ReportGridView
        '
        Me.ReportGridView.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.FooterPanel.Options.UseFont = True
        Me.ReportGridView.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.ReportGridView.Appearance.GroupRow.ForeColor = System.Drawing.Color.SteelBlue
        Me.ReportGridView.Appearance.GroupRow.Options.UseFont = True
        Me.ReportGridView.Appearance.GroupRow.Options.UseForeColor = True
        Me.ReportGridView.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.HeaderPanel.Options.UseFont = True
        Me.ReportGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ReportGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReportGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.Row.Options.UseFont = True
        Me.ReportGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NameGridColumn, Me.WorkCountGridColumn})
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
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = True
        GridFormatRule2.Rule = FormatConditionRuleValue2
        GridFormatRule3.ApplyToRow = True
        GridFormatRule3.Name = "Format2"
        FormatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue3.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue3.Value1 = True
        GridFormatRule3.Rule = FormatConditionRuleValue3
        GridFormatRule4.ApplyToRow = True
        GridFormatRule4.Name = "Format3"
        FormatConditionRuleValue4.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue4.Appearance.Options.UseFont = True
        FormatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue4.Value1 = True
        GridFormatRule4.Rule = FormatConditionRuleValue4
        GridFormatRule5.ApplyToRow = True
        GridFormatRule5.Name = "Format4"
        FormatConditionRuleValue5.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue5.Appearance.Options.UseFont = True
        FormatConditionRuleValue5.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue5.Value1 = False
        GridFormatRule5.Rule = FormatConditionRuleValue5
        GridFormatRule6.ApplyToRow = True
        GridFormatRule6.Name = "Format5"
        FormatConditionRuleValue6.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue6.Appearance.Options.UseFont = True
        FormatConditionRuleValue6.Condition = DevExpress.XtraEditors.FormatCondition.Expression
        FormatConditionRuleValue6.Expression = "[isPrice] = False And [isAgree] = True"
        GridFormatRule6.Rule = FormatConditionRuleValue6
        GridFormatRule7.Name = "Format6"
        FormatConditionRuleValue7.Appearance.BackColor = System.Drawing.Color.Green
        FormatConditionRuleValue7.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleValue7.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue7.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue7.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue7.Value1 = "Заявка"
        GridFormatRule7.Rule = FormatConditionRuleValue7
        GridFormatRule8.Name = "Format7"
        FormatConditionRuleValue8.Appearance.BackColor = System.Drawing.Color.Firebrick
        FormatConditionRuleValue8.Appearance.ForeColor = System.Drawing.Color.White
        FormatConditionRuleValue8.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue8.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue8.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue8.Value1 = "Измен."
        GridFormatRule8.Rule = FormatConditionRuleValue8
        Me.ReportGridView.FormatRules.Add(GridFormatRule1)
        Me.ReportGridView.FormatRules.Add(GridFormatRule2)
        Me.ReportGridView.FormatRules.Add(GridFormatRule3)
        Me.ReportGridView.FormatRules.Add(GridFormatRule4)
        Me.ReportGridView.FormatRules.Add(GridFormatRule5)
        Me.ReportGridView.FormatRules.Add(GridFormatRule6)
        Me.ReportGridView.FormatRules.Add(GridFormatRule7)
        Me.ReportGridView.FormatRules.Add(GridFormatRule8)
        Me.ReportGridView.GridControl = Me.ReportGridControl
        Me.ReportGridView.GroupFormat = "{1} {2}"
        Me.ReportGridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, "(всего: {0})")})
        Me.ReportGridView.Name = "ReportGridView"
        Me.ReportGridView.OptionsBehavior.Editable = False
        Me.ReportGridView.OptionsCustomization.AllowGroup = False
        Me.ReportGridView.OptionsFind.AllowFindPanel = False
        Me.ReportGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReportGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ReportGridView.OptionsView.RowAutoHeight = True
        Me.ReportGridView.OptionsView.ShowFooter = True
        Me.ReportGridView.OptionsView.ShowGroupPanel = False
        Me.ReportGridView.RowHeight = 30
        '
        'NameGridColumn
        '
        Me.NameGridColumn.Caption = "Регион"
        Me.NameGridColumn.FieldName = "name"
        Me.NameGridColumn.Name = "NameGridColumn"
        Me.NameGridColumn.Visible = True
        Me.NameGridColumn.VisibleIndex = 0
        '
        'WorkCountGridColumn
        '
        Me.WorkCountGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.WorkCountGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.WorkCountGridColumn.Caption = "Количество"
        Me.WorkCountGridColumn.ColumnEdit = Me.WorkCountRepositoryItemProgressBar
        Me.WorkCountGridColumn.FieldName = "workCount"
        Me.WorkCountGridColumn.Name = "WorkCountGridColumn"
        Me.WorkCountGridColumn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "workCount", "ИТОГО = {0:0.##}")})
        Me.WorkCountGridColumn.Visible = True
        Me.WorkCountGridColumn.VisibleIndex = 1
        '
        'WorkCountRepositoryItemProgressBar
        '
        Me.WorkCountRepositoryItemProgressBar.Name = "WorkCountRepositoryItemProgressBar"
        Me.WorkCountRepositoryItemProgressBar.PercentView = False
        Me.WorkCountRepositoryItemProgressBar.ShowTitle = True
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
        Me.RootLayoutControlGroup.GroupBordersVisible = False
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.SplitterItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.ReportGridControl
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(950, 404)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.WorkChartControl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 417)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(950, 233)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 404)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(950, 13)
        '
        'RegionUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "RegionUserControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkChartControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkCountRepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents WorkChartControl As DevExpress.XtraCharts.ChartControl
    Friend WithEvents ReportGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkCountGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WorkCountRepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem

End Class
