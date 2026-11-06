Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления для редактирования данных работы
''' </summary>
Public Class WorkUserControl : Inherits Cprp.DxData.Work.WorkUserControl

#Region "InitializeComponent"

    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents WorkRibbonPageGroup As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents WorkAcceptBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ServiceGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ServiceGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TypeGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpertGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents ExpertRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents ContentWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ManagerGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents ManagerRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private WithEvents TypeRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents WorkQueryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkHistoryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkBackBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip7 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem7 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem7 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.WorkAcceptBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkQueryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkHistoryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkBackBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.WorkRibbonPageGroup = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ContentWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.ServiceGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ServiceGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TypeGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TypeRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ExpertGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExpertRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ManagerGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManagerRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServiceGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServiceGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManagerRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.WorkAcceptBarButtonItem, Me.WorkQueryBarButtonItem, Me.WorkHistoryBarButtonItem, Me.WorkBackBarButtonItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 4
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.Size = New System.Drawing.Size(1050, 99)
        Me.RibbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
        '
        'WorkAcceptBarButtonItem
        '
        Me.WorkAcceptBarButtonItem.Caption = "УТВЕРДИТЬ"
        Me.WorkAcceptBarButtonItem.Id = 5
        Me.WorkAcceptBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkAcceptBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkAcceptBarButtonItem.Name = "WorkAcceptBarButtonItem"
        ToolTipTitleItem1.Text = "Утвердить"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Утвердить работу"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.WorkAcceptBarButtonItem.SuperTip = SuperToolTip1
        '
        'WorkQueryBarButtonItem
        '
        Me.WorkQueryBarButtonItem.Caption = "СТОП"
        Me.WorkQueryBarButtonItem.Id = 8
        Me.WorkQueryBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkQueryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkQueryBarButtonItem.Name = "WorkQueryBarButtonItem"
        ToolTipTitleItem2.Text = "Стоп"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Остановить / возобновить выполнение работы"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.WorkQueryBarButtonItem.SuperTip = SuperToolTip2
        '
        'WorkHistoryBarButtonItem
        '
        Me.WorkHistoryBarButtonItem.Caption = "ИСТОРИЯ"
        Me.WorkHistoryBarButtonItem.Id = 1
        Me.WorkHistoryBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkHistoryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkHistoryBarButtonItem.Name = "WorkHistoryBarButtonItem"
        ToolTipTitleItem3.Text = "История"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Показать историть работы"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.WorkHistoryBarButtonItem.SuperTip = SuperToolTip3
        '
        'WorkBackBarButtonItem
        '
        Me.WorkBackBarButtonItem.Caption = "ВОЗВРАТ"
        Me.WorkBackBarButtonItem.Id = 2
        Me.WorkBackBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkBackBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkBackBarButtonItem.Name = "WorkBackBarButtonItem"
        ToolTipTitleItem4.Text = "Возврат"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Вернуть работу на доработку"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.WorkBackBarButtonItem.SuperTip = SuperToolTip4
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.WorkRibbonPageGroup})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "RibbonPage1"
        '
        'WorkRibbonPageGroup
        '
        Me.WorkRibbonPageGroup.ItemLinks.Add(Me.WorkAcceptBarButtonItem)
        Me.WorkRibbonPageGroup.ItemLinks.Add(Me.WorkBackBarButtonItem)
        Me.WorkRibbonPageGroup.ItemLinks.Add(Me.WorkQueryBarButtonItem)
        Me.WorkRibbonPageGroup.ItemLinks.Add(Me.WorkHistoryBarButtonItem, True)
        Me.WorkRibbonPageGroup.Name = "WorkRibbonPageGroup"
        Me.WorkRibbonPageGroup.ShowCaptionButton = False
        Me.WorkRibbonPageGroup.Text = "Работа"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 99)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ContentWebBrowser)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SeparatorControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.LayoutControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1050, 551)
        Me.SplitContainerControl1.SplitterPosition = 290
        Me.SplitContainerControl1.TabIndex = 8
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ContentWebBrowser
        '
        Me.ContentWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentWebBrowser.Location = New System.Drawing.Point(0, 0)
        Me.ContentWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.ContentWebBrowser.Name = "ContentWebBrowser"
        Me.ContentWebBrowser.Size = New System.Drawing.Size(1050, 245)
        Me.ContentWebBrowser.TabIndex = 8
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SeparatorControl1.Location = New System.Drawing.Point(0, 245)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(1050, 1)
        Me.SeparatorControl1.TabIndex = 7
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.CommentMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.ServiceGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(630, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1050, 290)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CommentMemoEdit
        '
        Me.CommentMemoEdit.Location = New System.Drawing.Point(755, 44)
        Me.CommentMemoEdit.MenuManager = Me.RibbonControl1
        Me.CommentMemoEdit.Name = "CommentMemoEdit"
        Me.CommentMemoEdit.Size = New System.Drawing.Size(267, 218)
        Me.CommentMemoEdit.StyleController = Me.LayoutControl1
        Me.CommentMemoEdit.TabIndex = 6
        '
        'ServiceGridControl
        '
        Me.ServiceGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ServiceGridControl.Location = New System.Drawing.Point(28, 44)
        Me.ServiceGridControl.MainView = Me.ServiceGridView
        Me.ServiceGridControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ServiceGridControl.Name = "ServiceGridControl"
        Me.ServiceGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ExpertRepositoryItemLookUpEdit, Me.ManagerRepositoryItemLookUpEdit, Me.TypeRepositoryItemLookUpEdit})
        Me.ServiceGridControl.Size = New System.Drawing.Size(676, 218)
        Me.ServiceGridControl.TabIndex = 5
        Me.ServiceGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ServiceGridView})
        '
        'ServiceGridView
        '
        Me.ServiceGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.ServiceGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ServiceGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ServiceGridView.Appearance.Row.Options.UseFont = True
        Me.ServiceGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TypeGridColumn, Me.ExpertGridColumn, Me.ManagerGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 13.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.ServiceGridView.FormatRules.Add(GridFormatRule1)
        Me.ServiceGridView.GridControl = Me.ServiceGridControl
        Me.ServiceGridView.Name = "ServiceGridView"
        Me.ServiceGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.ServiceGridView.OptionsCustomization.AllowColumnMoving = False
        Me.ServiceGridView.OptionsCustomization.AllowFilter = False
        Me.ServiceGridView.OptionsCustomization.AllowGroup = False
        Me.ServiceGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.ServiceGridView.OptionsCustomization.AllowSort = False
        Me.ServiceGridView.OptionsMenu.EnableColumnMenu = False
        Me.ServiceGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ServiceGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.ServiceGridView.OptionsView.AllowHtmlDrawHeaders = True
        Me.ServiceGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.ServiceGridView.OptionsView.ShowGroupPanel = False
        Me.ServiceGridView.RowHeight = 25
        '
        'TypeGridColumn
        '
        Me.TypeGridColumn.Caption = "Вид работы<color=red>*</color>"
        Me.TypeGridColumn.ColumnEdit = Me.TypeRepositoryItemLookUpEdit
        Me.TypeGridColumn.FieldName = "typeId"
        Me.TypeGridColumn.Name = "TypeGridColumn"
        Me.TypeGridColumn.Visible = True
        Me.TypeGridColumn.VisibleIndex = 0
        Me.TypeGridColumn.Width = 392
        '
        'TypeRepositoryItemLookUpEdit
        '
        Me.TypeRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TypeRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.TypeRepositoryItemLookUpEdit.AutoHeight = False
        ToolTipTitleItem5.Text = "Удалить"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Удалить работу"
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.TypeRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "Удалить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Удалить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, SuperToolTip5, True)})
        Me.TypeRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.TypeRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.TypeRepositoryItemLookUpEdit.Name = "TypeRepositoryItemLookUpEdit"
        Me.TypeRepositoryItemLookUpEdit.NullText = ""
        Me.TypeRepositoryItemLookUpEdit.ShowFooter = False
        Me.TypeRepositoryItemLookUpEdit.ShowHeader = False
        Me.TypeRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TypeRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'ExpertGridColumn
        '
        Me.ExpertGridColumn.Caption = "Эксперт"
        Me.ExpertGridColumn.ColumnEdit = Me.ExpertRepositoryItemLookUpEdit
        Me.ExpertGridColumn.FieldName = "expertId"
        Me.ExpertGridColumn.Name = "ExpertGridColumn"
        Me.ExpertGridColumn.OptionsColumn.FixedWidth = True
        Me.ExpertGridColumn.Visible = True
        Me.ExpertGridColumn.VisibleIndex = 1
        Me.ExpertGridColumn.Width = 140
        '
        'ExpertRepositoryItemLookUpEdit
        '
        Me.ExpertRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ExpertRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.ExpertRepositoryItemLookUpEdit.AutoHeight = False
        ToolTipTitleItem6.Text = "Очистить"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Очистить поле"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.ExpertRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, SuperToolTip6, True)})
        Me.ExpertRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.ExpertRepositoryItemLookUpEdit.DisplayMember = "nameShort"
        Me.ExpertRepositoryItemLookUpEdit.Name = "ExpertRepositoryItemLookUpEdit"
        Me.ExpertRepositoryItemLookUpEdit.NullText = ""
        Me.ExpertRepositoryItemLookUpEdit.ShowFooter = False
        Me.ExpertRepositoryItemLookUpEdit.ShowHeader = False
        Me.ExpertRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ExpertRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'ManagerGridColumn
        '
        Me.ManagerGridColumn.Caption = "Менеджер"
        Me.ManagerGridColumn.ColumnEdit = Me.ManagerRepositoryItemLookUpEdit
        Me.ManagerGridColumn.FieldName = "managerId"
        Me.ManagerGridColumn.Name = "ManagerGridColumn"
        Me.ManagerGridColumn.OptionsColumn.FixedWidth = True
        Me.ManagerGridColumn.Visible = True
        Me.ManagerGridColumn.VisibleIndex = 2
        Me.ManagerGridColumn.Width = 140
        '
        'ManagerRepositoryItemLookUpEdit
        '
        Me.ManagerRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ManagerRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.ManagerRepositoryItemLookUpEdit.AutoHeight = False
        ToolTipTitleItem7.Text = "Очистить"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Очистить поле"
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.ManagerRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, SuperToolTip7, True)})
        Me.ManagerRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.ManagerRepositoryItemLookUpEdit.DisplayMember = "nameShort"
        Me.ManagerRepositoryItemLookUpEdit.Name = "ManagerRepositoryItemLookUpEdit"
        Me.ManagerRepositoryItemLookUpEdit.NullText = ""
        Me.ManagerRepositoryItemLookUpEdit.ShowFooter = False
        Me.ManagerRepositoryItemLookUpEdit.ShowHeader = False
        Me.ManagerRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.ManagerRepositoryItemLookUpEdit.ValueMember = "id"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.SplitterItem1, Me.LayoutControlGroup1, Me.LayoutControlGroup2})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 2, 10)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1050, 290)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(712, 0)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(15, 278)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Выбор работ для исполнения заказа"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(712, 278)
        Me.LayoutControlGroup1.Text = "Выбор работ для исполнения заказа"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ServiceGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(682, 224)
        Me.LayoutControlItem1.Text = "ВЫбот видов услуг для исполнения заказа:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(727, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(303, 278)
        Me.LayoutControlGroup2.Text = "Указания исполнителям по выбранной работе"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CommentMemoEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(273, 224)
        Me.LayoutControlItem2.Text = "Указания исполнителям по выбранной услуге:"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'WorkUserControl
        '
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "WorkUserControl"
        Me.Size = New System.Drawing.Size(1050, 650)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServiceGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServiceGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManagerRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ''' <summary>
    ''' Работа
    ''' </summary>
    Public Shadows Property Work As WorkConnectionRow = Nothing


#Region "Главное меню"

    ''' <summary>
    ''' Утвердить работу
    ''' </summary>
    Private Sub WorkAcceptBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkAcceptBarButtonItem.ItemClick
        Dim T As NewWorkDataTable = Nothing
        Dim Row As DataRow = Nothing
        ServiceGridView.CloseEditor()
        ServiceGridView.UpdateCurrentRow()
        Work.ServiceTable.AcceptChanges()
        '
        ' Проверка того, что работа не распределена другим сотрудником
        '
        If CType(Work.ExecuteScalar(String.Format("SELECT conditionId FROM tWork WHERE id = {0}", CInt(Work.Id))), WorkCondition) = WorkCondition.IsClose Then
            Cprp.DxCommon.Messages.ShowWarning("Заявка распределена другим сотрудником.")
            GoTo End01
        End If
        '
        ' Проверка наличия выбранных работ
        '
        If Work.ServiceTable.Rows.Count = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Работы не выбраны. Выберите работы, необходимые для исполнения заказа.")
            Exit Sub
        End If
        '
        ' Проверка наличия видов работ у выбранных работ
        '
        For Each Row In Work.ServiceTable.Rows
            If IsDBNull(Row("typeId")) Then
                Cprp.DxCommon.Messages.ShowWarning("У выбранной работы отсутствует вид работы. Укажите вид работы.")
                Exit Sub
            End If
        Next

        If Cprp.DxCommon.Messages.ShowQuestion("Утвердить перечень работ и создать по ним новые работы?") <> DialogResult.Yes Then Exit Sub
        Try
            '
            ' Создание новых работ в ЭС
            '
            T = New NewWorkDataTable(Work.Connection)
            For Each Row1 As DataRow In Work.ServiceTable.Rows
                Row = T.NewRow
                Row("pId") = Work.Id
                Row("guid") = System.Guid.NewGuid.ToString
                Row("typeId") = Row1("typeId")
                Row("expertId") = Row1("expertId")
                Row("managerId") = Row1("managerId")
                With MyBase.CurrentUser
                    If .IsLeader OrElse .IsSubleader OrElse .IsChief Then Row("leaderId") = .Id
                End With
                'Row("comment") = C2.DbText(Row1("comment"))
                Row("comment") = C2.DbText(CommentMemoEdit.EditValue)
                If IsDBNull(Row("comment")) Then Row("comment") = C2.DbText(Work("comment"))
                If Not IsDBNull(Row("expertId")) Then
                    Row("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsPlaneWork)
                    Row("expertTerm") = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 120)
                Else
                    Row("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsNew)
                    Row("expertTerm") = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 30)
                End If
                Row("orderId") = Work("orderId")
                Row("CrmOrderId") = Work("CrmOrderId")
                Row("orderNum") = Work("orderNum")
                Row("orderDate") = Work("orderDate")
                Row("orderUrl") = Work("orderUrl")
                Row("taskId") = Work("taskId")
                Row("taskUrl") = Work("taskUrl")
                Row("clientName") = Work("clientName")
                Row("clientAddress") = Work("clientAddress")
                Row("clientInn") = Work("clientInn")
                Row("clientKpp") = Work("clientKpp")
                Row("clientPhone") = Work("clientPhone")
                Row("clientFax") = Work("clientFax")
                Row("agreementNum") = Work("agreementNum")
                'Row("urgencyId") = CType(Work("urgencyId"), UrgencyType)
                Row("createDate") = Date.Now
                T.Rows.Add(Row)
                T.SaveToBase()
                Row("dbId") = Work.ExecuteScalar("SELECT @@IDENTITY FROM tWork")
            Next
            '
            ' Отправка в ЭО сообщений о новых работах, запись комментариев к работам
            '
            Using W As New WorkConnectionRow(-1, Work.Connection)
                For Each Row In T.Rows
                    W.Id = Row("dbId")
                    '
                    ' Отправка сообщения в ЭО
                    '
                    W.MessageWorkNewEo()
                    '
                    ' Комментарий заказчика к заявке
                    '
                    If C2.IsText(Work("comment")) Then W.WorkCommentTable.AddComment(Date.Now, C2.ToInt(Row("leaderId")), C2.ToText(Work("comment")), False)
                    '
                    ' Комментарий (указание) руководителя к новой работе
                    '
                    If C2.IsText(Row("comment")) Then W.WorkCommentTable.AddComment(Date.Now, C2.ToInt(Row("leaderId")), C2.ToText(Row("comment")), False)
                Next
            End Using
            '
            ' Перевод работы в состояние "Закрыта" 
            '
            MyClass.Work("conditionId") = WorkCondition.IsClose
            MyClass.Work("acceptDate") = Date.Now
            MyClass.Work("closeDate") = Date.Now
            MyClass.Work.DataSave()
            '
            ' Запись в историю работы события утверждения работы
            '
            If Not IsDBNull(MyClass.Work("expertTerm")) Then
                MyClass.Work.WriteHistory(WorkEvent.WorkAccept, Nothing, CDate(MyClass.Work("expertTerm")))
            Else
                MyClass.Work.WriteHistory(WorkEvent.WorkAccept, Nothing)
            End If
            '
            ' Отправка в ЭО сообщения о закрытии работы
            '
            Work.MessageWorkChangeEo()
            '
            ' Отправка email-сообщений исполнителям, запись в комментарии к работе
            '
            Dim Mail As New Cprp.DxData.Mail(Work.Connection)
            Dim caption As String = Nothing
            Dim body As String = Nothing
            For Each Row In T.Rows
                If Not IsDBNull(Row("managerId")) Then
                    caption = String.Format("{0} назначил Вас менеджером в работе № {1} (заказ № {2}).", MyBase.CurrentUser.NameShort, CInt(Row("dbId")), Row("orderNum").ToString)
                    body = caption
                    If Not IsDBNull(Row("comment")) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, C2.AddPoint(Row("comment")))
                    Mail.Send(MyBase.CurrentUser.Id, Row("managerId"), caption, body)
                End If
                If Not IsDBNull(Row("expertId")) Then
                    caption = String.Format("{0} назначил Вас экспертом в работе № {1}.", MyBase.CurrentUser.NameShort, CInt(Row("dbId")))
                    body = caption
                    If Not IsDBNull(Row("comment")) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, C2.AddPoint(Row("comment")))
                    Mail.Send(MyBase.CurrentUser.Id, Row("expertId"), caption, body)
                End If
            Next
            '
            ' Запись в базу сведений о руководителе заказчика
            '
            Cprp.DxData.Member.Common.PersonUpdate(Work("clientInn").ToString, Work.Connection)

        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            If Not T Is Nothing Then T.Dispose()
        End Try
        '
        ' Закрыть текущий элемент управления
        '
End01:
        If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
            CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
        End If
    End Sub

    ''' <summary>
    ''' Остановить или возобновить выполнение работы
    ''' </summary>
    Private Sub WorkQueryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkQueryBarButtonItem.ItemClick
        'If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
        '    CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).WorkQueryRun(MyClass.Work.Id)
        '    MyClass.Work.Id = MyClass.Work.Id
        '    ContentWebBrowser.DocumentText = MyClass.Work.GetHtmlContent
        'End If
        If IsDBNull(Work("isStop")) OrElse Not CBool(Work("isStop")) Then
            If Work.WorkStop() Then Work("isStop") = True
        Else
            If Work.WorkStart() Then Work("isStop") = False
        End If
    End Sub

#End Region


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.WorkUserControl
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <param name="CurrentUser">Текущий пользователь системы</param> 
    Public Sub New(Work As WorkConnectionRow, CurrentUser As Cprp.DxData.User.DatabaseUser)
        '
        ' Me
        '
        MyBase.New(Work, CurrentUser)
        InitializeComponent()
        If Not MyBase.WorkDataExist Then
            Me.Enabled = False
            Exit Sub
        End If
        '
        ' Work
        '
        MyClass.Work = Work
        '
        ' ServiceGridControl, ServiceGridView
        '
        TypeRepositoryItemLookUpEdit.DataSource = New Cprp.DxData.Handbook.WorkTypeDataTable(Work.Connection)
        ExpertRepositoryItemLookUpEdit.DataSource = New Cprp.DxData.Handbook.ExpertDataTable(Work.Connection)
        ManagerRepositoryItemLookUpEdit.DataSource = New Cprp.DxData.Handbook.ManagerDataTable(Work.Connection)
        ServiceGridControl.DataSource = Work.ServiceTable
        '
        ' CommentMemoEdit
        '
        'CommentMemoEdit.DataBindings.Add("EditValue", Work.ServiceTable, "comment")
        '
        ' Перечитать состояние работы
        '
        ContentWebBrowser.DocumentText = Work.GetHtmlContent
        '
        ' Запись в историю работы события открытия карточки работы
        '
        Work.WriteHistory(Cprp.DxData.Work.WorkEvent.OpenCard, Nothing)
        '
        ' Блокировка интерфейса закрытой работы
        '
        Dim bLock As Boolean = (Work.Condition = WorkCondition.IsClose OrElse Work.Condition = WorkCondition.IsCancel)
        WorkAcceptBarButtonItem.Enabled = Not bLock
        WorkQueryBarButtonItem.Enabled = Not bLock
        ServiceGridView.OptionsBehavior.ReadOnly = bLock
        TypeRepositoryItemLookUpEdit.ReadOnly = bLock
        TypeRepositoryItemLookUpEdit.Buttons(1).Enabled = Not bLock
        ExpertRepositoryItemLookUpEdit.ReadOnly = bLock
        ExpertRepositoryItemLookUpEdit.Buttons(1).Enabled = Not bLock
        ManagerRepositoryItemLookUpEdit.ReadOnly = bLock
        ManagerRepositoryItemLookUpEdit.Buttons(1).Enabled = Not bLock
        CommentMemoEdit.ReadOnly = bLock

    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.WorkUserControl
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="CurrentUser">Текущий пользователь системы</param> 
    Public Sub New(id As Object, Connection As SqlConnection, CurrentUser As Cprp.DxData.User.DatabaseUser)
        MyClass.New(New WorkConnectionRow(id, Connection), CurrentUser)
    End Sub


    Private Sub ContentWebBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles ContentWebBrowser.Navigating
        '
        ' Адрес ресурса
        '
        Dim strUrl As String = e.Url.ToString.ToUpper
        '
        ' Заказчик (профиль)
        '
        If strUrl Like "*MEMBER_PROFILE_*" Then
            e.Cancel = True
            Dim Arr() As String = e.Url.ToString.Split(New Char() {"_"}, StringSplitOptions.RemoveEmptyEntries)
            If Arr.Length < 3 Then Exit Sub
            Dim inn As String = C2.ToText(Arr(2))
            If String.IsNullOrWhiteSpace(inn) Then Exit Sub
            For Each F As Form In Application.OpenForms
                If Not TypeOf F Is RusProfileForm Then Continue For
                If CType(F, RusProfileForm).Inn <> inn Then Continue For
                F.WindowState = FormWindowState.Normal
                F.Activate()
                Exit Sub
            Next
            With New RusProfileForm(inn, Me.Work.Connection, Me.ParentForm)
                .Show()
                .Activate()
            End With
            Exit Sub
        End If
        '
        ' Обобщенное наименование объектов экспертизы
        '
        If strUrl Like "*WORK_DESCRIPTION*" Then
            e.Cancel = True
            Dim sTmp As String = C2.ToText(InputBox("Укажите обобщенное наименование объектов экспертизы:", "Продукция", C2.ToText(Work("description"))))
            If C2.IsText(sTmp) Then
                Work("description") = sTmp
                Work.ExecuteNonQuery(String.Format("UPDATE tWork SET description = '{0}' WHERE id = {1}", sTmp.Replace("'", "''"), CInt(Work.Id)))
                ContentWebBrowser.DocumentText = Work.GetHtmlContent
            End If
            Exit Sub
        End If

        If strUrl Like "*&KKS" Then
            e.Cancel = True
            '
            ' Временный файл для скачивания содержимого документа
            '
            Dim sTmp As String = My.Computer.FileSystem.GetTempFileName
            '
            ' Скачивание содержимого документа во временный файл
            '
            Using W As New System.Net.WebClient
                W.UseDefaultCredentials = True
                W.DownloadFile(strUrl, sTmp)
            End Using
            '
            ' Открытие формы с перечнем товаров
            '
            With New Cprp.DxData.Work.KksForm(sTmp)
                .Show()
            End With
            Exit Sub
        End If
        '
        ' Документ для скачивания и локального открытия из временной папки
        '
        If strUrl Like "*&EXT=*" Then
            Dim iTmp As Integer = strUrl.IndexOf("&EXT=")
            If iTmp > 0 AndAlso (iTmp + 5) < strUrl.Length Then
                Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
                '
                ' Расширение файла
                '
                Dim sTmp As String = strUrl.Substring(iTmp + 5)
                Try
                    '
                    ' Временный файл для скачивания содержимого документа
                    '
                    With My.Computer.FileSystem
                        sTmp = String.Format("{0}\{1}.{2}", Me.Work.TmpFolderPath, .GetFiles(Me.Work.TmpFolderPath).Count + 1, sTmp)
                        .MoveFile(.GetTempFileName, sTmp, True)
                    End With
                    '
                    ' Скачивание содержимого документа во временный файл
                    '
                    Using W As New System.Net.WebClient
                        W.UseDefaultCredentials = True
                        W.DownloadFile(strUrl, sTmp)
                    End Using
                    '
                    ' Открытие временного файла
                    '
                    Using P As New Process
                        P.StartInfo.FileName = sTmp
                        P.StartInfo.Verb = "Open"
                        P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                        P.Start()
                    End Using
                    e.Cancel = True
                    Exit Sub
                Catch ex As Exception
                    e.Cancel = False
                Finally
                    Cprp.DxCommon.WaitForm.Close()
                End Try
            End If
        End If
    End Sub

    ' Удалить работу
    Private Sub TypeRepositoryItemLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TypeRepositoryItemLookUpEdit.ButtonClick
        If e.Button.Index = 1 Then
            If Work.Condition = WorkCondition.IsClose OrElse Work.Condition = WorkCondition.IsCancel Then Exit Sub
            ServiceGridView.CloseEditor()
            ServiceGridView.UpdateCurrentRow()
            If ServiceGridView.FocusedRowHandle < 0 Then Exit Sub
            ServiceGridView.DeleteRow(ServiceGridView.FocusedRowHandle)
        End If
    End Sub

    ' Очистить поле "Эксперт" у выбранной работы
    Private Sub ExpertRepositoryItemLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ExpertRepositoryItemLookUpEdit.ButtonClick
        If e.Button.Index = 1 Then
            If Work.Condition = WorkCondition.IsClose OrElse Work.Condition = WorkCondition.IsCancel Then Exit Sub
            ServiceGridView.SetRowCellValue(ServiceGridView.FocusedRowHandle, ExpertGridColumn, DBNull.Value)
        End If
    End Sub

    ' Очистить поле "Менеджер" у выбранной работы
    Private Sub ManagerRepositoryItemLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ManagerRepositoryItemLookUpEdit.ButtonClick
        If e.Button.Index = 1 Then
            If Work.Condition = WorkCondition.IsClose OrElse Work.Condition = WorkCondition.IsCancel Then Exit Sub
            ServiceGridView.SetRowCellValue(ServiceGridView.FocusedRowHandle, ManagerGridColumn, DBNull.Value)
        End If
    End Sub

    ' Показать историю работы
    Private Sub WorkHistoryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkHistoryBarButtonItem.ItemClick
        MyBase.WorkHistoryShow()
    End Sub

    ' Вернуть работу на доработку
    Private Sub WorkBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkBackBarButtonItem.ItemClick
        '
        ' Проверка того, что работа не распределена другим сотрудником
        '
        If CType(Work.ExecuteScalar(String.Format("SELECT conditionId FROM tWork WHERE id = {0}", CInt(Work.Id))), WorkCondition) = WorkCondition.IsClose Then
            Cprp.DxCommon.Messages.ShowWarning("Заявка распределена другим сотрудником.")
            GoTo End01
        End If

        Dim comment As String = Nothing
        With New WorkBackForm
            .Text = "Возврат на доработку"
            If .ShowDialog <> DialogResult.OK Then Exit Sub
            comment = C2.ToText(.CommentMemoEdit.Text)
        End With

        '
        ' Перевод работы в состояние "Аннулирована" 
        '
        MyClass.Work("conditionId") = WorkCondition.IsCancel
        MyClass.Work("comment") = comment
        MyClass.Work.DataSave()
        '
        ' Запись в историю работы события отмены работы
        '
        If Not IsDBNull(MyClass.Work("expertTerm")) Then
            MyClass.Work.WriteHistory(WorkEvent.BackCheck, comment, CDate(MyClass.Work("expertTerm")))
        Else
            MyClass.Work.WriteHistory(WorkEvent.BackCheck, comment)
        End If
        '
        ' Отправка в ЭО сообщения о возврате работы на доработку
        '
        Work.MessageWorkChangeEo()
        '
        ' Отправка email-сообщения менеджеру
        '
        If Not IsDBNull(Work("managerId")) Then
            Dim Mail As New Cprp.DxData.Mail(Work.Connection)
            Dim caption As String = Nothing
            Dim body As String = Nothing
            caption = String.Format("{0} вернул на доработку Вашу заявку на оказание услуг по заказу № {1}.", MyBase.CurrentUser.NameShort, Work("orderNum").ToString)
            body = String.Format("{0}{1}Причина возврата:{1}{2}", caption, vbCrLf, C2.AddPoint(comment))
            Mail.Send(MyBase.CurrentUser.Id, Work("managerId"), caption, body)
        End If
        '
        ' Закрыть текущий элемент управления
        '
End01:
        If Not Me.ParentForm Is Nothing AndAlso TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
            CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildClose(MyClass.Work.Id)
        End If

    End Sub

End Class
