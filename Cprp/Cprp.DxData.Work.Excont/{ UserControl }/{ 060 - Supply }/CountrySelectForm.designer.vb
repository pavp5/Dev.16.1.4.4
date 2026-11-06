<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CountrySelectForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CountrySelectForm))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.IsCheckGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.FindBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FindRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.SelectBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.StandaloneBarDockControl1 = New DevExpress.XtraBars.StandaloneBarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CountryGridControl = New DevExpress.XtraGrid.GridControl()
        Me.CountryGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameShortGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CancelSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.AcceptSimpleButton = New DevExpress.XtraEditors.SimpleButton()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CountryGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IsCheckGridColumn
        '
        Me.IsCheckGridColumn.Caption = "Выбрано"
        Me.IsCheckGridColumn.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.IsCheckGridColumn.FieldName = "isCheck"
        Me.IsCheckGridColumn.Name = "IsCheckGridColumn"
        Me.IsCheckGridColumn.OptionsColumn.FixedWidth = True
        Me.IsCheckGridColumn.Visible = True
        Me.IsCheckGridColumn.VisibleIndex = 0
        Me.IsCheckGridColumn.Width = 60
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
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockControls.Add(Me.StandaloneBarDockControl1)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.FindBarEditItem, Me.SelectBarButtonItem})
        Me.BarManager1.MaxItemId = 2
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.FindRepositoryItemTextEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone
        Me.Bar1.FloatLocation = New System.Drawing.Point(85, 173)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.FindBarEditItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.SelectBarButtonItem, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.StandaloneBarDockControl = Me.StandaloneBarDockControl1
        Me.Bar1.Text = "Главное меню"
        '
        'FindBarEditItem
        '
        Me.FindBarEditItem.Caption = "Поиск"
        Me.FindBarEditItem.Edit = Me.FindRepositoryItemTextEdit
        Me.FindBarEditItem.EditWidth = 100
        Me.FindBarEditItem.Id = 0
        Me.FindBarEditItem.Name = "FindBarEditItem"
        '
        'FindRepositoryItemTextEdit
        '
        Me.FindRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FindRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.FindRepositoryItemTextEdit.AutoHeight = False
        Me.FindRepositoryItemTextEdit.Name = "FindRepositoryItemTextEdit"
        '
        'SelectBarButtonItem
        '
        Me.SelectBarButtonItem.Caption = "Выбрать"
        Me.SelectBarButtonItem.Glyph = CType(resources.GetObject("SelectBarButtonItem.Glyph"), System.Drawing.Image)
        Me.SelectBarButtonItem.Id = 1
        Me.SelectBarButtonItem.Name = "SelectBarButtonItem"
        ToolTipTitleItem1.Text = "Выбрать"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Отметить страну как выбранную / снять отметку"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.SelectBarButtonItem.SuperTip = SuperToolTip1
        '
        'StandaloneBarDockControl1
        '
        Me.StandaloneBarDockControl1.CausesValidation = False
        Me.StandaloneBarDockControl1.Location = New System.Drawing.Point(12, 12)
        Me.StandaloneBarDockControl1.Name = "StandaloneBarDockControl1"
        Me.StandaloneBarDockControl1.Size = New System.Drawing.Size(420, 37)
        Me.StandaloneBarDockControl1.Text = "StandaloneBarDockControl1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(444, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 628)
        Me.barDockControlBottom.Size = New System.Drawing.Size(444, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 628)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(444, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 628)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.CountryGridControl)
        Me.LayoutControl1.Controls.Add(Me.StandaloneBarDockControl1)
        Me.LayoutControl1.Controls.Add(Me.CancelSimpleButton)
        Me.LayoutControl1.Controls.Add(Me.AcceptSimpleButton)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(494, 416, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(444, 628)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CountryGridControl
        '
        Me.CountryGridControl.Location = New System.Drawing.Point(12, 53)
        Me.CountryGridControl.MainView = Me.CountryGridView
        Me.CountryGridControl.Name = "CountryGridControl"
        Me.CountryGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.CountryGridControl.Size = New System.Drawing.Size(420, 537)
        Me.CountryGridControl.TabIndex = 22
        Me.CountryGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.CountryGridView})
        '
        'CountryGridView
        '
        Me.CountryGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.CountryGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CountryGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryGridView.Appearance.Row.Options.UseFont = True
        Me.CountryGridView.Appearance.Row.Options.UseTextOptions = True
        Me.CountryGridView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.CountryGridView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryGridView.Appearance.ViewCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CountryGridView.Appearance.ViewCaption.Options.UseFont = True
        Me.CountryGridView.Appearance.ViewCaption.Options.UseForeColor = True
        Me.CountryGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IsCheckGridColumn, Me.NameShortGridColumn})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.IsCheckGridColumn
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        FormatConditionRuleValue1.Appearance.Options.UseFont = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Value1 = True
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.CountryGridView.FormatRules.Add(GridFormatRule1)
        Me.CountryGridView.GridControl = Me.CountryGridControl
        Me.CountryGridView.GroupFormat = "{1}"
        Me.CountryGridView.Name = "CountryGridView"
        Me.CountryGridView.OptionsBehavior.AutoExpandAllGroups = True
        Me.CountryGridView.OptionsBehavior.Editable = False
        Me.CountryGridView.OptionsCustomization.AllowColumnMoving = False
        Me.CountryGridView.OptionsCustomization.AllowFilter = False
        Me.CountryGridView.OptionsCustomization.AllowGroup = False
        Me.CountryGridView.OptionsCustomization.AllowQuickHideColumns = False
        Me.CountryGridView.OptionsCustomization.AllowSort = False
        Me.CountryGridView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.CountryGridView.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.CountryGridView.OptionsView.RowAutoHeight = True
        Me.CountryGridView.OptionsView.ShowGroupPanel = False
        Me.CountryGridView.RowHeight = 25
        '
        'NameShortGridColumn
        '
        Me.NameShortGridColumn.Caption = "Краткое наименование"
        Me.NameShortGridColumn.FieldName = "nameShort"
        Me.NameShortGridColumn.Name = "NameShortGridColumn"
        Me.NameShortGridColumn.Visible = True
        Me.NameShortGridColumn.VisibleIndex = 1
        Me.NameShortGridColumn.Width = 174
        '
        'CancelSimpleButton
        '
        Me.CancelSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CancelSimpleButton.Appearance.Options.UseFont = True
        Me.CancelSimpleButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelSimpleButton.Location = New System.Drawing.Point(322, 594)
        Me.CancelSimpleButton.Name = "CancelSimpleButton"
        Me.CancelSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.CancelSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.CancelSimpleButton.StyleController = Me.LayoutControl1
        Me.CancelSimpleButton.TabIndex = 9
        Me.CancelSimpleButton.Text = "ОТМЕНА"
        '
        'AcceptSimpleButton
        '
        Me.AcceptSimpleButton.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AcceptSimpleButton.Appearance.Options.UseFont = True
        Me.AcceptSimpleButton.Location = New System.Drawing.Point(208, 594)
        Me.AcceptSimpleButton.Name = "AcceptSimpleButton"
        Me.AcceptSimpleButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.AcceptSimpleButton.Size = New System.Drawing.Size(110, 22)
        Me.AcceptSimpleButton.StyleController = Me.LayoutControl1
        Me.AcceptSimpleButton.TabIndex = 8
        Me.AcceptSimpleButton.Text = "ПРИМЕНИТЬ"
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(444, 628)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.StandaloneBarDockControl1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(424, 41)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CountryGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 41)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(424, 541)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.CancelSimpleButton
        Me.LayoutControlItem3.Location = New System.Drawing.Point(310, 582)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.AcceptSimpleButton
        Me.LayoutControlItem2.Location = New System.Drawing.Point(196, 582)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(114, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 582)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(196, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'CountrySelectForm
        '
        Me.AcceptButton = Me.AcceptSimpleButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelSimpleButton
        Me.ClientSize = New System.Drawing.Size(444, 628)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CountrySelectForm"
        Me.ShowInTaskbar = False
        Me.Text = "CountrySelectForm"
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CountryGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents FindBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents FindRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents SelectBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents StandaloneBarDockControl1 As DevExpress.XtraBars.StandaloneBarDockControl
    Friend WithEvents CancelSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AcceptSimpleButton As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CountryGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents CountryGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IsCheckGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents NameShortGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
End Class
