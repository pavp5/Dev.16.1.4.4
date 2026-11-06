<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSummaryUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSummaryUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.DateStartBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DateEndBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ReportBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.AutoHightBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.FindTextBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FindRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ExportExcelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ReportGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ReportGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.OrgGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.CountryGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TnvedGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RowCountGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PercentCountGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.DateStartBarEditItem, Me.DateEndBarEditItem, Me.ReportBarButtonItem, Me.AutoHightBarCheckItem, Me.FindTextBarEditItem, Me.ExportExcelBarButtonItem})
        Me.BarManager1.MaxItemId = 7
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.FindRepositoryItemButtonEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DateStartBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.DateEndBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ReportBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.AutoHightBarCheckItem, True), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindTextBarEditItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.ExportExcelBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'DateStartBarEditItem
        '
        Me.DateStartBarEditItem.Caption = "Отчетный период с"
        Me.DateStartBarEditItem.Edit = Me.RepositoryItemDateEdit1
        Me.DateStartBarEditItem.EditWidth = 100
        Me.DateStartBarEditItem.Id = 0
        Me.DateStartBarEditItem.Name = "DateStartBarEditItem"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit1.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RepositoryItemDateEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        '
        'DateEndBarEditItem
        '
        Me.DateEndBarEditItem.Caption = "по"
        Me.DateEndBarEditItem.Edit = Me.RepositoryItemDateEdit2
        Me.DateEndBarEditItem.EditWidth = 100
        Me.DateEndBarEditItem.Id = 1
        Me.DateEndBarEditItem.Name = "DateEndBarEditItem"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit2.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RepositoryItemDateEdit2.Appearance.Options.UseFont = True
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        Me.RepositoryItemDateEdit2.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ReportBarButtonItem
        '
        Me.ReportBarButtonItem.Caption = "Отчет"
        Me.ReportBarButtonItem.Glyph = CType(resources.GetObject("ReportBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ReportBarButtonItem.Id = 2
        Me.ReportBarButtonItem.Name = "ReportBarButtonItem"
        ToolTipTitleItem1.Text = "Отчет"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Создать отчет"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.ReportBarButtonItem.SuperTip = SuperToolTip1
        '
        'AutoHightBarCheckItem
        '
        Me.AutoHightBarCheckItem.Caption = "Автоподбор"
        Me.AutoHightBarCheckItem.Glyph = CType(resources.GetObject("AutoHightBarCheckItem.Glyph"), System.Drawing.Image)
        Me.AutoHightBarCheckItem.Id = 4
        Me.AutoHightBarCheckItem.Name = "AutoHightBarCheckItem"
        ToolTipTitleItem2.Text = "Автоподбор"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Автоподбор высоты строк по содержимому"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.AutoHightBarCheckItem.SuperTip = SuperToolTip2
        '
        'FindTextBarEditItem
        '
        Me.FindTextBarEditItem.Caption = "Поиск"
        Me.FindTextBarEditItem.Edit = Me.FindRepositoryItemButtonEdit
        Me.FindTextBarEditItem.EditWidth = 180
        Me.FindTextBarEditItem.Id = 5
        Me.FindTextBarEditItem.Name = "FindTextBarEditItem"
        '
        'FindRepositoryItemButtonEdit
        '
        Me.FindRepositoryItemButtonEdit.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FindRepositoryItemButtonEdit.Appearance.Options.UseFont = True
        Me.FindRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem3.Text = "Очистить"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Очистить поле"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.FindRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, SuperToolTip3, True)})
        Me.FindRepositoryItemButtonEdit.Name = "FindRepositoryItemButtonEdit"
        '
        'ExportExcelBarButtonItem
        '
        Me.ExportExcelBarButtonItem.Caption = "Экспорт"
        Me.ExportExcelBarButtonItem.Glyph = CType(resources.GetObject("ExportExcelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ExportExcelBarButtonItem.Id = 6
        Me.ExportExcelBarButtonItem.Name = "ExportExcelBarButtonItem"
        ToolTipTitleItem4.Text = "Экспорт"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Экспорт списка в Microsoft Excel"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.ExportExcelBarButtonItem.SuperTip = SuperToolTip4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(950, 37)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 650)
        Me.barDockControlBottom.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 37)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 613)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 37)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 613)
        '
        'ReportGridControl
        '
        Me.ReportGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportGridControl.Location = New System.Drawing.Point(0, 37)
        Me.ReportGridControl.MainView = Me.ReportGridView
        Me.ReportGridControl.Name = "ReportGridControl"
        Me.ReportGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1, Me.RepositoryItemMemoEdit1})
        Me.ReportGridControl.Size = New System.Drawing.Size(950, 613)
        Me.ReportGridControl.TabIndex = 23
        Me.ReportGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ReportGridView})
        '
        'ReportGridView
        '
        Me.ReportGridView.Appearance.GroupFooter.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.GroupFooter.Options.UseFont = True
        Me.ReportGridView.Appearance.GroupRow.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.GroupRow.Options.UseFont = True
        Me.ReportGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ReportGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReportGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ReportGridView.Appearance.Row.Options.UseFont = True
        Me.ReportGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.OrgGridColumn, Me.CountryGridColumn, Me.TnvedGridColumn, Me.RowCountGridColumn, Me.PercentCountGridColumn})
        Me.ReportGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.ReportGridView.FormatRules.Add(GridFormatRule1)
        Me.ReportGridView.GridControl = Me.ReportGridControl
        Me.ReportGridView.GroupRowHeight = 25
        Me.ReportGridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "percentCount", Nothing, "({0:0.##} %)")})
        Me.ReportGridView.Name = "ReportGridView"
        Me.ReportGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.ReportGridView.OptionsBehavior.ReadOnly = True
        Me.ReportGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ReportGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReportGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.ReportGridView.OptionsView.ShowFooter = True
        Me.ReportGridView.PreviewFieldName = "country"
        Me.ReportGridView.RowHeight = 25
        '
        'OrgGridColumn
        '
        Me.OrgGridColumn.Caption = "Экспертная организация"
        Me.OrgGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.OrgGridColumn.FieldName = "orgNameShort"
        Me.OrgGridColumn.Name = "OrgGridColumn"
        Me.OrgGridColumn.Visible = True
        Me.OrgGridColumn.VisibleIndex = 0
        Me.OrgGridColumn.Width = 65
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'CountryGridColumn
        '
        Me.CountryGridColumn.Caption = "Страна(ы)"
        Me.CountryGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.CountryGridColumn.FieldName = "docCountry"
        Me.CountryGridColumn.Name = "CountryGridColumn"
        Me.CountryGridColumn.Visible = True
        Me.CountryGridColumn.VisibleIndex = 1
        '
        'TnvedGridColumn
        '
        Me.TnvedGridColumn.Caption = "Код(ы) ТН ВЭД"
        Me.TnvedGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.TnvedGridColumn.FieldName = "goodTnved"
        Me.TnvedGridColumn.Name = "TnvedGridColumn"
        Me.TnvedGridColumn.Visible = True
        Me.TnvedGridColumn.VisibleIndex = 2
        '
        'RowCountGridColumn
        '
        Me.RowCountGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RowCountGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RowCountGridColumn.Caption = "Количество записей"
        Me.RowCountGridColumn.FieldName = "rowCount"
        Me.RowCountGridColumn.Name = "RowCountGridColumn"
        Me.RowCountGridColumn.OptionsColumn.FixedWidth = True
        Me.RowCountGridColumn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rowCount", "{0:0.##}")})
        Me.RowCountGridColumn.Visible = True
        Me.RowCountGridColumn.VisibleIndex = 3
        Me.RowCountGridColumn.Width = 100
        '
        'PercentCountGridColumn
        '
        Me.PercentCountGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.PercentCountGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PercentCountGridColumn.Caption = "Процент записей"
        Me.PercentCountGridColumn.DisplayFormat.FormatString = "n2"
        Me.PercentCountGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PercentCountGridColumn.FieldName = "percentCount"
        Me.PercentCountGridColumn.Name = "PercentCountGridColumn"
        Me.PercentCountGridColumn.OptionsColumn.FixedWidth = True
        Me.PercentCountGridColumn.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "percentCount", "{0:0.##} %")})
        Me.PercentCountGridColumn.Visible = True
        Me.PercentCountGridColumn.VisibleIndex = 4
        Me.PercentCountGridColumn.Width = 100
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ShowTitle = True
        '
        'ReportSummaryUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ReportGridControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ReportSummaryUserControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents DateStartBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents DateEndBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ReportBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AutoHightBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents FindTextBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents FindRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ExportExcelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ReportGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ReportGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CountryGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RowCountGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PercentCountGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents OrgGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TnvedGridColumn As DevExpress.XtraGrid.Columns.GridColumn

End Class
