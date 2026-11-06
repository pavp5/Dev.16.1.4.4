<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultUserControl
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResultUserControl))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.IsEqualGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GoodNameGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodTnvedGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodDescrptionGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodListGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GoodPosGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SummaryGoodGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocGridControl = New DevExpress.XtraGrid.GridControl()
        Me.DocGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DocNumDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocDateDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OrgNameShortDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CountryNameDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ConNumDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ConDateDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RusCaptionDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RusInnDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NusCaptionDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EndCaptionDocGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.FindBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemFindButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ExcelBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.GoodGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemFindButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsEqualGoodGridColumn
        '
        Me.IsEqualGoodGridColumn.Caption = "isEqual"
        Me.IsEqualGoodGridColumn.FieldName = "isEqual"
        Me.IsEqualGoodGridColumn.Name = "IsEqualGoodGridColumn"
        Me.IsEqualGoodGridColumn.OptionsColumn.ShowInCustomizationForm = False
        '
        'GoodGridView
        '
        Me.GoodGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GoodGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GoodGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GoodGridView.Appearance.Row.Options.UseFont = True
        Me.GoodGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GoodNameGoodGridColumn, Me.GoodTnvedGoodGridColumn, Me.GoodDescrptionGoodGridColumn, Me.GoodListGoodGridColumn, Me.GoodPosGoodGridColumn, Me.SummaryGoodGridColumn, Me.IsEqualGoodGridColumn})
        Me.GoodGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsEqualGoodGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red
        FormatConditionRuleValue1.Appearance.Options.UseForeColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GoodGridView.FormatRules.Add(GridFormatRule1)
        Me.GoodGridView.GridControl = Me.DocGridControl
        Me.GoodGridView.Name = "GoodGridView"
        Me.GoodGridView.OptionsBehavior.Editable = False
        Me.GoodGridView.OptionsFind.AllowFindPanel = False
        Me.GoodGridView.OptionsView.ShowGroupPanel = False
        Me.GoodGridView.RowHeight = 30
        Me.GoodGridView.ViewCaption = "Объекты экспертизы"
        '
        'GoodNameGoodGridColumn
        '
        Me.GoodNameGoodGridColumn.Caption = "Коммерческое наименование"
        Me.GoodNameGoodGridColumn.FieldName = "goodName"
        Me.GoodNameGoodGridColumn.Name = "GoodNameGoodGridColumn"
        Me.GoodNameGoodGridColumn.Visible = True
        Me.GoodNameGoodGridColumn.VisibleIndex = 0
        '
        'GoodTnvedGoodGridColumn
        '
        Me.GoodTnvedGoodGridColumn.Caption = "Код ТН ВЭД"
        Me.GoodTnvedGoodGridColumn.FieldName = "goodTnved"
        Me.GoodTnvedGoodGridColumn.Name = "GoodTnvedGoodGridColumn"
        Me.GoodTnvedGoodGridColumn.Visible = True
        Me.GoodTnvedGoodGridColumn.VisibleIndex = 1
        '
        'GoodDescrptionGoodGridColumn
        '
        Me.GoodDescrptionGoodGridColumn.Caption = "Техническое описание"
        Me.GoodDescrptionGoodGridColumn.FieldName = "goodDescrption"
        Me.GoodDescrptionGoodGridColumn.Name = "GoodDescrptionGoodGridColumn"
        Me.GoodDescrptionGoodGridColumn.Visible = True
        Me.GoodDescrptionGoodGridColumn.VisibleIndex = 2
        '
        'GoodListGoodGridColumn
        '
        Me.GoodListGoodGridColumn.Caption = "Обозначения списков"
        Me.GoodListGoodGridColumn.FieldName = "goodList"
        Me.GoodListGoodGridColumn.Name = "GoodListGoodGridColumn"
        Me.GoodListGoodGridColumn.Visible = True
        Me.GoodListGoodGridColumn.VisibleIndex = 3
        '
        'GoodPosGoodGridColumn
        '
        Me.GoodPosGoodGridColumn.Caption = "Пункты списков"
        Me.GoodPosGoodGridColumn.FieldName = "goodPos"
        Me.GoodPosGoodGridColumn.Name = "GoodPosGoodGridColumn"
        Me.GoodPosGoodGridColumn.Visible = True
        Me.GoodPosGoodGridColumn.VisibleIndex = 4
        '
        'SummaryGoodGridColumn
        '
        Me.SummaryGoodGridColumn.Caption = "Дополнительная информация"
        Me.SummaryGoodGridColumn.FieldName = "summary"
        Me.SummaryGoodGridColumn.Name = "SummaryGoodGridColumn"
        Me.SummaryGoodGridColumn.Visible = True
        Me.SummaryGoodGridColumn.VisibleIndex = 5
        '
        'DocGridControl
        '
        Me.DocGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.GoodGridView
        GridLevelNode1.RelationName = "DocGoodRelation"
        Me.DocGridControl.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.DocGridControl.Location = New System.Drawing.Point(0, 37)
        Me.DocGridControl.MainView = Me.DocGridView
        Me.DocGridControl.Name = "DocGridControl"
        Me.DocGridControl.Size = New System.Drawing.Size(950, 613)
        Me.DocGridControl.TabIndex = 6
        Me.DocGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DocGridView, Me.GoodGridView})
        '
        'DocGridView
        '
        Me.DocGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.DocGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DocGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DocGridView.Appearance.Row.Options.UseFont = True
        Me.DocGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.DocNumDocGridColumn, Me.DocDateDocGridColumn, Me.OrgNameShortDocGridColumn, Me.CountryNameDocGridColumn, Me.ConNumDocGridColumn, Me.ConDateDocGridColumn, Me.RusCaptionDocGridColumn, Me.RusInnDocGridColumn, Me.NusCaptionDocGridColumn, Me.EndCaptionDocGridColumn})
        Me.DocGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Name = "Format0"
        FormatConditionRuleValue2.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Greater
        FormatConditionRuleValue2.Value1 = CType(6, Short)
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.DocGridView.FormatRules.Add(GridFormatRule2)
        Me.DocGridView.GridControl = Me.DocGridControl
        Me.DocGridView.Name = "DocGridView"
        Me.DocGridView.OptionsBehavior.Editable = False
        Me.DocGridView.OptionsFind.AllowFindPanel = False
        Me.DocGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.DocGridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.DocGridView.OptionsView.RowAutoHeight = True
        Me.DocGridView.OptionsView.ShowGroupPanel = False
        Me.DocGridView.RowHeight = 30
        '
        'DocNumDocGridColumn
        '
        Me.DocNumDocGridColumn.Caption = "Номер заключения"
        Me.DocNumDocGridColumn.FieldName = "docNum"
        Me.DocNumDocGridColumn.Name = "DocNumDocGridColumn"
        Me.DocNumDocGridColumn.Visible = True
        Me.DocNumDocGridColumn.VisibleIndex = 0
        '
        'DocDateDocGridColumn
        '
        Me.DocDateDocGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.DocDateDocGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DocDateDocGridColumn.Caption = "Дата заключения"
        Me.DocDateDocGridColumn.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.DocDateDocGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DocDateDocGridColumn.FieldName = "docDate"
        Me.DocDateDocGridColumn.Name = "DocDateDocGridColumn"
        Me.DocDateDocGridColumn.Visible = True
        Me.DocDateDocGridColumn.VisibleIndex = 1
        '
        'OrgNameShortDocGridColumn
        '
        Me.OrgNameShortDocGridColumn.Caption = "Экспертная организация"
        Me.OrgNameShortDocGridColumn.FieldName = "orgNameShort"
        Me.OrgNameShortDocGridColumn.Name = "OrgNameShortDocGridColumn"
        Me.OrgNameShortDocGridColumn.Visible = True
        Me.OrgNameShortDocGridColumn.VisibleIndex = 2
        '
        'CountryNameDocGridColumn
        '
        Me.CountryNameDocGridColumn.Caption = "Страна назначения"
        Me.CountryNameDocGridColumn.FieldName = "countryName"
        Me.CountryNameDocGridColumn.Name = "CountryNameDocGridColumn"
        Me.CountryNameDocGridColumn.Visible = True
        Me.CountryNameDocGridColumn.VisibleIndex = 3
        '
        'ConNumDocGridColumn
        '
        Me.ConNumDocGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.ConNumDocGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ConNumDocGridColumn.Caption = "Номер контракта"
        Me.ConNumDocGridColumn.FieldName = "conNum"
        Me.ConNumDocGridColumn.Name = "ConNumDocGridColumn"
        Me.ConNumDocGridColumn.Visible = True
        Me.ConNumDocGridColumn.VisibleIndex = 4
        '
        'ConDateDocGridColumn
        '
        Me.ConDateDocGridColumn.Caption = "Дата контракта"
        Me.ConDateDocGridColumn.DisplayFormat.FormatString = "dd.MM.yyyy"
        Me.ConDateDocGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ConDateDocGridColumn.FieldName = "conDate"
        Me.ConDateDocGridColumn.Name = "ConDateDocGridColumn"
        Me.ConDateDocGridColumn.Visible = True
        Me.ConDateDocGridColumn.VisibleIndex = 5
        '
        'RusCaptionDocGridColumn
        '
        Me.RusCaptionDocGridColumn.Caption = "Российский участник"
        Me.RusCaptionDocGridColumn.FieldName = "rusCaption"
        Me.RusCaptionDocGridColumn.Name = "RusCaptionDocGridColumn"
        Me.RusCaptionDocGridColumn.Visible = True
        Me.RusCaptionDocGridColumn.VisibleIndex = 6
        '
        'RusInnDocGridColumn
        '
        Me.RusInnDocGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.RusInnDocGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RusInnDocGridColumn.Caption = "ИНН россйиского участника"
        Me.RusInnDocGridColumn.FieldName = "rusInn"
        Me.RusInnDocGridColumn.Name = "RusInnDocGridColumn"
        Me.RusInnDocGridColumn.Visible = True
        Me.RusInnDocGridColumn.VisibleIndex = 7
        '
        'NusCaptionDocGridColumn
        '
        Me.NusCaptionDocGridColumn.Caption = "Иностранный участник"
        Me.NusCaptionDocGridColumn.FieldName = "nusCaption"
        Me.NusCaptionDocGridColumn.Name = "NusCaptionDocGridColumn"
        Me.NusCaptionDocGridColumn.Visible = True
        Me.NusCaptionDocGridColumn.VisibleIndex = 8
        '
        'EndCaptionDocGridColumn
        '
        Me.EndCaptionDocGridColumn.Caption = "Конечный пользователь"
        Me.EndCaptionDocGridColumn.FieldName = "endCaption"
        Me.EndCaptionDocGridColumn.Name = "EndCaptionDocGridColumn"
        Me.EndCaptionDocGridColumn.Visible = True
        Me.EndCaptionDocGridColumn.VisibleIndex = 9
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ExcelBarButtonItem, Me.FindBarEditItem})
        Me.BarManager1.MaxItemId = 7
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemFindButtonEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.ExcelBarButtonItem, True)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'FindBarEditItem
        '
        Me.FindBarEditItem.Caption = "Поиск"
        Me.FindBarEditItem.Edit = Me.RepositoryItemFindButtonEdit
        Me.FindBarEditItem.EditWidth = 250
        Me.FindBarEditItem.Glyph = CType(resources.GetObject("FindBarEditItem.Glyph"), System.Drawing.Image)
        Me.FindBarEditItem.Id = 6
        Me.FindBarEditItem.Name = "FindBarEditItem"
        Me.FindBarEditItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption
        '
        'RepositoryItemFindButtonEdit
        '
        Me.RepositoryItemFindButtonEdit.Appearance.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RepositoryItemFindButtonEdit.Appearance.Options.UseFont = True
        Me.RepositoryItemFindButtonEdit.AutoHeight = False
        Me.RepositoryItemFindButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepositoryItemFindButtonEdit.Name = "RepositoryItemFindButtonEdit"
        '
        'ExcelBarButtonItem
        '
        Me.ExcelBarButtonItem.Caption = "Экспорт"
        Me.ExcelBarButtonItem.Glyph = CType(resources.GetObject("ExcelBarButtonItem.Glyph"), System.Drawing.Image)
        Me.ExcelBarButtonItem.Id = 5
        Me.ExcelBarButtonItem.Name = "ExcelBarButtonItem"
        ToolTipTitleItem1.Text = "Экспорт"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Экспорт списка в Microsoft Excel"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.ExcelBarButtonItem.SuperTip = SuperToolTip1
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
        'ResultUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DocGridControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ResultUserControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.GoodGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemFindButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents ExcelBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FindBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemFindButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents DocGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents DocGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DocNumDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocDateDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OrgNameShortDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CountryNameDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ConNumDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ConDateDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RusCaptionDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RusInnDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NusCaptionDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EndCaptionDocGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GoodNameGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodTnvedGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodDescrptionGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodListGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GoodPosGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SummaryGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IsEqualGoodGridColumn As DevExpress.XtraGrid.Columns.GridColumn

End Class
