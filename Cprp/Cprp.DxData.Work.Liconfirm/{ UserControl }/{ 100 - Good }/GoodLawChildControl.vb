Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Продукция > Объект №_ > Проверка соответствия"
''' </summary>
Friend Class GoodLawChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents WordRepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents TnvedRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelectBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FindClearBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FindRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FindBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents OpenLicBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenDataBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents OpenListBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Private components As System.ComponentModel.IContainer
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents StandaloneBarDockControl2 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents AppendGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents AppendGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckAppendGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PosAppendGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StageAppendGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents DescriptionAppendGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescriptionMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SummaryLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GoodLawChildControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckAppendGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.OpenListBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OpenDataBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.OpenLicBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.FindBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FindRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.FindClearBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.SelectBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl2 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.TnvedRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.WordRepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.AppendGridControl = New DevExpress.XtraGrid.GridControl()
        Me.AppendGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PosAppendGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StageAppendGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.DescriptionAppendGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescriptionMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SummaryLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TnvedRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WordRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.AppendGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppendGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckAppendGridColumn
        '
        Me.IsCheckAppendGridColumn.Caption = "Выбрано"
        Me.IsCheckAppendGridColumn.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IsCheckAppendGridColumn.FieldName = "isCheck"
        Me.IsCheckAppendGridColumn.Name = "IsCheckAppendGridColumn"
        Me.IsCheckAppendGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckAppendGridColumn.Visible = True
        Me.IsCheckAppendGridColumn.VisibleIndex = 0
        Me.IsCheckAppendGridColumn.Width = 60
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.DisplayValueChecked = "Выбрано"
        Me.RepositoryItemCheckEdit1.DisplayValueUnchecked = "Не выбрано"
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl2)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.OpenListBarButtonItem, Me.OpenDataBarCheckItem, Me.OpenLicBarCheckItem, Me.FindClearBarButtonItem, Me.SelectBarButtonItem, Me.FindBarEditItem})
        Me.BarManager1.MaxItemId = 19
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.TnvedRepositoryItemTextEdit, Me.WordRepositoryItemComboBox, Me.FindRepositoryItemTextEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(74, 163)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenListBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenDataBarCheckItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.OpenLicBarCheckItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'OpenListBarButtonItem
        '
        Me.OpenListBarButtonItem.Caption = "Список"
        Me.OpenListBarButtonItem.Glyph = CType(resources.GetObject("OpenListBarButtonItem.Glyph"), System.Drawing.Image)
        Me.OpenListBarButtonItem.Id = 0
        Me.OpenListBarButtonItem.Name = "OpenListBarButtonItem"
        '
        'OpenDataBarCheckItem
        '
        Me.OpenDataBarCheckItem.Caption = "РЕГИСТРАЦИОННЫЕ ДАННЫЕ"
        Me.OpenDataBarCheckItem.Glyph = CType(resources.GetObject("OpenDataBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenDataBarCheckItem.GroupIndex = 1
        Me.OpenDataBarCheckItem.Id = 1
        Me.OpenDataBarCheckItem.Name = "OpenDataBarCheckItem"
        ToolTipTitleItem1.Text = "Регистрационные данные"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Прейти к регистрационным данным"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.OpenDataBarCheckItem.SuperTip = SuperToolTip1
        '
        'OpenLicBarCheckItem
        '
        Me.OpenLicBarCheckItem.BindableChecked = True
        Me.OpenLicBarCheckItem.Caption = "ПРОВЕРКА СООТВЕТСТВИЯ"
        Me.OpenLicBarCheckItem.Checked = True
        Me.OpenLicBarCheckItem.Glyph = CType(resources.GetObject("OpenLicBarCheckItem.Glyph"), System.Drawing.Image)
        Me.OpenLicBarCheckItem.GroupIndex = 1
        Me.OpenLicBarCheckItem.Id = 3
        Me.OpenLicBarCheckItem.Name = "OpenLicBarCheckItem"
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 52)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Контрольные списки"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar2.FloatLocation = New System.Drawing.Point(59, 219)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarEditItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindClearBarButtonItem, DevExpress.XtraBars.BarItemPaintStyle.Standard), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelectBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.StandaloneBarDockControl = Me.StandaloneBarDockControl2
        Me.Bar2.Text = "Контрольные списки"
        '
        'FindBarEditItem
        '
        Me.FindBarEditItem.Caption = "Поиск"
        Me.FindBarEditItem.Edit = Me.FindRepositoryItemTextEdit
        Me.FindBarEditItem.EditWidth = 200
        Me.FindBarEditItem.Glyph = CType(resources.GetObject("FindBarEditItem.Glyph"), System.Drawing.Image)
        Me.FindBarEditItem.Id = 18
        Me.FindBarEditItem.Name = "FindBarEditItem"
        '
        'FindRepositoryItemTextEdit
        '
        Me.FindRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.FindRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.FindRepositoryItemTextEdit.AutoHeight = False
        Me.FindRepositoryItemTextEdit.Name = "FindRepositoryItemTextEdit"
        '
        'FindClearBarButtonItem
        '
        Me.FindClearBarButtonItem.Caption = "Очистить"
        Me.FindClearBarButtonItem.Glyph = CType(resources.GetObject("FindClearBarButtonItem.Glyph"), System.Drawing.Image)
        Me.FindClearBarButtonItem.Id = 9
        Me.FindClearBarButtonItem.Name = "FindClearBarButtonItem"
        ToolTipTitleItem2.Text = "Очистить"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Очистить поле поиска"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.FindClearBarButtonItem.SuperTip = SuperToolTip2
        '
        'SelectBarButtonItem
        '
        Me.SelectBarButtonItem.Caption = "ВЫБРАТЬ"
        Me.SelectBarButtonItem.Glyph = CType(resources.GetObject("SelectBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelectBarButtonItem.Id = 11
        Me.SelectBarButtonItem.Name = "SelectBarButtonItem"
        ToolTipTitleItem3.Text = "Выбрать"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Выбрать пункт / Убрать из выборки"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.SelectBarButtonItem.SuperTip = SuperToolTip3
        '
        'StandaloneBarDockControl2
        '
        Me.StandaloneBarDockControl2.CausesValidation = False
        Me.StandaloneBarDockControl2.Location = New System.Drawing.Point(12, 94)
        Me.StandaloneBarDockControl2.Name = "StandaloneBarDockControl2"
        Me.StandaloneBarDockControl2.Size = New System.Drawing.Size(926, 37)
        Me.StandaloneBarDockControl2.Text = "StandaloneBarDockControl2"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(950, 0)
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
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 650)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 650)
        '
        'TnvedRepositoryItemTextEdit
        '
        Me.TnvedRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.TnvedRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.TnvedRepositoryItemTextEdit.AutoHeight = False
        Me.TnvedRepositoryItemTextEdit.Name = "TnvedRepositoryItemTextEdit"
        '
        'WordRepositoryItemComboBox
        '
        Me.WordRepositoryItemComboBox.Appearance.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.WordRepositoryItemComboBox.Appearance.Options.UseFont = True
        Me.WordRepositoryItemComboBox.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.WordRepositoryItemComboBox.AppearanceDropDown.Options.UseFont = True
        Me.WordRepositoryItemComboBox.AutoHeight = False
        Me.WordRepositoryItemComboBox.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WordRepositoryItemComboBox.Name = "WordRepositoryItemComboBox"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.AppendGridControl)
        Me.LayoutControl1.Controls.Add(Me.DescriptionMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl2)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(530, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'AppendGridControl
        '
        Me.AppendGridControl.Location = New System.Drawing.Point(12, 135)
        Me.AppendGridControl.MainView = Me.AppendGridView
        Me.AppendGridControl.Name = "AppendGridControl"
        Me.AppendGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit3, Me.RepositoryItemCheckEdit1})
        Me.AppendGridControl.Size = New System.Drawing.Size(926, 384)
        Me.AppendGridControl.TabIndex = 36
        Me.AppendGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AppendGridView})
        '
        'AppendGridView
        '
        Me.AppendGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.AppendGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AppendGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AppendGridView.Appearance.Row.Options.UseFont = True
        Me.AppendGridView.Appearance.Row.Options.UseTextOptions = True
        Me.AppendGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.AppendGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AppendGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.AppendGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.AppendGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.AppendGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckAppendGridColumn, Me.PosAppendGridColumn, Me.StageAppendGridColumn, Me.DescriptionAppendGridColumn})
        Me.AppendGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckAppendGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.AppendGridView.FormatRules.Add(GridFormatRule1)
        Me.AppendGridView.GridControl = Me.AppendGridControl
        Me.AppendGridView.GroupFormat = "{1}"
        Me.AppendGridView.Name = "AppendGridView"
        Me.AppendGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.AppendGridView.OptionsBehavior.Editable = False
        Me.AppendGridView.OptionsCustomization.AllowColumnMoving = False
        Me.AppendGridView.OptionsCustomization.AllowFilter = False
        Me.AppendGridView.OptionsCustomization.AllowGroup = False
        Me.AppendGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.AppendGridView.OptionsCustomization.AllowSort = False
        Me.AppendGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.AppendGridView.OptionsView.AllowHtmlDrawHeaders = True
        Me.AppendGridView.OptionsView.RowAutoHeight = True
        Me.AppendGridView.OptionsView.ShowGroupPanel = False
        Me.AppendGridView.RowHeight = 25
        '
        'PosAppendGridColumn
        '
        Me.PosAppendGridColumn.AppearanceCell.Options.UseTextOptions = True
        Me.PosAppendGridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PosAppendGridColumn.Caption = "№№<color='red'>*</color>"
        Me.PosAppendGridColumn.FieldName = "pos"
        Me.PosAppendGridColumn.Name = "PosAppendGridColumn"
        Me.PosAppendGridColumn.OptionsColumn.FixedWidth = True
        Me.PosAppendGridColumn.Visible = True
        Me.PosAppendGridColumn.VisibleIndex = 1
        Me.PosAppendGridColumn.Width = 60
        '
        'StageAppendGridColumn
        '
        Me.StageAppendGridColumn.Caption = "Номера этапов<color='red'>*</color>"
        Me.StageAppendGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.StageAppendGridColumn.FieldName = "stage"
        Me.StageAppendGridColumn.Name = "StageAppendGridColumn"
        Me.StageAppendGridColumn.Visible = True
        Me.StageAppendGridColumn.VisibleIndex = 2
        Me.StageAppendGridColumn.Width = 250
        '
        'RepositoryItemMemoEdit3
        '
        Me.RepositoryItemMemoEdit3.Name = "RepositoryItemMemoEdit3"
        '
        'DescriptionAppendGridColumn
        '
        Me.DescriptionAppendGridColumn.Caption = "Описания этапов<color='red'>*</color>"
        Me.DescriptionAppendGridColumn.ColumnEdit = Me.RepositoryItemMemoEdit3
        Me.DescriptionAppendGridColumn.FieldName = "description"
        Me.DescriptionAppendGridColumn.Name = "DescriptionAppendGridColumn"
        Me.DescriptionAppendGridColumn.Visible = True
        Me.DescriptionAppendGridColumn.VisibleIndex = 3
        Me.DescriptionAppendGridColumn.Width = 580
        '
        'DescriptionMemoEdit
        '
        Me.DescriptionMemoEdit.Location = New System.Drawing.Point(24, 566)
        Me.DescriptionMemoEdit.MenuManager = Me.BarManager1
        Me.DescriptionMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.DescriptionMemoEdit.Name = "DescriptionMemoEdit"
        Me.DescriptionMemoEdit.Size = New System.Drawing.Size(902, 70)
        Me.DescriptionMemoEdit.StyleController = Me.LayoutControl1
        Me.DescriptionMemoEdit.TabIndex = 32
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem2, Me.SimpleSeparator1, Me.LayoutControlItem3, Me.SummaryLayoutControlGroup, Me.SplitterItem1, Me.LayoutControlItem5})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseTextOptions = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 40)
        Me.CaptionSimpleLabelItem.Text = "Продукция > Объект № _"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 81)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(930, 1)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StandaloneBarDockControl2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 82)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(930, 41)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SummaryLayoutControlGroup
        '
        Me.SummaryLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.SummaryLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.SummaryLayoutControlGroup.Location = New System.Drawing.Point(0, 523)
        Me.SummaryLayoutControlGroup.Name = "SummaryLayoutControlGroup"
        Me.SummaryLayoutControlGroup.Size = New System.Drawing.Size(930, 117)
        Me.SummaryLayoutControlGroup.Text = "Технические характеристики для сравнения с выбранным пунктом<color='red'>*</color" & _
    ">"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DescriptionMemoEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(906, 74)
        Me.LayoutControlItem4.Text = "Технические характеристики"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 511)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(930, 12)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.AppendGridControl
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 123)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(930, 388)
        Me.LayoutControlItem5.Text = "Приложения к лицензии"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'GoodLawChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "GoodLawChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TnvedRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WordRepositoryItemComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.AppendGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppendGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Строка таблицы объектов экспертизы
        '
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        '
        ' Элементы управления
        '
        CaptionSimpleLabelItem.Text = String.Format("Продукция > Объект № {0} > Регистрационные данные", C2.ToInt(Row("rowNum")))
        '
        ' Технические характеристики для сравнения с выбранным пунктом
        '
        DescriptionMemoEdit.EditValue = Row("goodDescription")
        '
        ' Выбранные пункты
        '
        AppendGridView.BeginDataUpdate()
        MyView.RowFilter = String.Format("licId = {0}", C2.ToInt(P.Work.ARow("licId")))
        P.Work.LicenseAppendTable.CheckClear()
        Using V As New DataView(P.Work.GoodAppendTable)
            V.RowFilter = String.Format("goodId = {0}", MyClass.GoodId)
            For Each VRow As DataRowView In V
                Row = P.Work.LicenseAppendTable.Rows.Find(C2.ToInt(VRow("appendId")))
                If Not Row Is Nothing Then Row("isCheck") = True
            Next
        End Using
        P.Work.LicenseTable.AcceptChanges()
        AppendGridView.EndDataUpdate()
        AppendGridView.MoveFirst()
        '
        ' Доступность элементов управления на редактирование
        '
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        '
        ' Строка таблицы объектов экспертизы
        '
        Dim Row As DataRow = P.Work.GoodTable.Rows.Find(MyClass.GoodId)
        If Row Is Nothing Then Exit Sub
        '
        ' Технические характеристики для сравнения с выбранными пунктами
        '
        Row("goodDescription") = C2.DbText(DescriptionMemoEdit.EditValue)
        '
        ' Выбранные пункты
        '
        AppendGridView.CloseEditor()
        AppendGridView.UpdateCurrentRow()
        P.Work.GoodAppendTable.GoodClear(MyClass.GoodId)
        For Each VRow As DataRowView In MyView
            If CBool(VRow("isCheck")) Then
                P.Work.GoodAppendTable.Rows.Add(New Object() {MyClass.GoodId, VRow("id")})
            End If
        Next
        P.Work.GoodAppendTable.AcceptChanges()
        '
        ' Проверка заполненности данных
        '
        ErrorTable.Rows.Clear()
        Row("isCheckLic") = ErrorTable.CheckGoodLic(Row)
        P.Work.GoodTable.AcceptChanges()
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        SelectBarButtonItem.Enabled = Not bLock
        DescriptionMemoEdit.ReadOnly = bLock
    End Sub

#End Region

    ''' <summary>
    ''' ID активного объекта
    ''' </summary>
    Friend Property GoodId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Таблица ошибок для проверки данных
    ''' </summary>
    Private ErrorTable As ErrorDataTable = Nothing

    ''' <summary>
    ''' Представление приложений к выбранной лицензии
    ''' </summary>
    ''' <remarks></remarks>
    Private MyView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.GoodLaw
        MyView = New DataView(P.Work.LicenseAppendTable)
        MyView.RowFilter = "licId IS NULL"
        AppendGridControl.DataSource = MyView
        AppendGridView.SortInfo.Insert(0, PosAppendGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckAppendGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckAppendGridColumn.Group()
        ErrorTable = New ErrorDataTable(MyBase.P.Work)
    End Sub

    ' Перейти к списку объектов
    Private Sub OpenListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenListBarButtonItem.ItemClick
        P.ContentOpen(ContentEnum.GoodList, MyClass.GoodId)
    End Sub

    ' Перейти к регистрационным данным
    Private Sub OpenDataBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenDataBarCheckItem.CheckedChanged
        P.ContentOpen(ContentEnum.GoodData, MyClass.GoodId)
    End Sub

    ' Выбрать пункт / Убрать из выборки
    Private Sub SelectBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelectBarButtonItem.ItemClick
        If AppendGridView.FocusedRowHandle < 0 Then Exit Sub
        With AppendGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        AppendGridView.RefreshData()
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub AppendGridControl_DoubleClick(sender As Object, e As EventArgs) Handles AppendGridControl.DoubleClick
        If SelectBarButtonItem.Enabled Then SelectBarButtonItem.PerformClick()
    End Sub

    Private Sub AppendGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles AppendGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

    Private Sub FindRepositoryItemTextEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemTextEdit.EditValueChanging
        AppendGridView.ApplyFindFilter(e.NewValue.ToString)
    End Sub

    Private Sub FindClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindClearBarButtonItem.ItemClick
        FindBarEditItem.EditValue = Nothing
        AppendGridView.ApplyFindFilter(Nothing)
    End Sub

    Private Sub DescriptionMemoEdit_EnabledChanged(sender As Object, e As EventArgs) Handles DescriptionMemoEdit.EnabledChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
