<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SynonUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SynonUserControl))
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.AutoHeightBarCheckItem = New DevExpress.XtraBars.BarCheckItem()
        Me.FindBarEditItem = New DevExpress.XtraBars.BarEditItem()
        Me.FindRepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.SynonGridControl = New DevExpress.XtraGrid.GridControl()
        Me.SynonGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Word1GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.Word2GridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SynonGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SynonGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.AutoHeightBarCheckItem, Me.FindBarEditItem})
        Me.BarManager1.MaxItemId = 3
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.FindRepositoryItemTextEdit})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Главное меню"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.AutoHeightBarCheckItem), New DevExpress.XtraBars.LinkPersistInfo(Me.FindBarEditItem, True)})
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        Me.Bar1.Text = "Главное меню"
        '
        'AutoHeightBarCheckItem
        '
        Me.AutoHeightBarCheckItem.Caption = "Высота"
        Me.AutoHeightBarCheckItem.Glyph = CType(resources.GetObject("AutoHeightBarCheckItem.Glyph"), System.Drawing.Image)
        Me.AutoHeightBarCheckItem.Id = 1
        Me.AutoHeightBarCheckItem.Name = "AutoHeightBarCheckItem"
        ToolTipTitleItem2.Text = "Высота"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Выровнять высоту строк по содержимому"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.AutoHeightBarCheckItem.SuperTip = SuperToolTip2
        '
        'FindBarEditItem
        '
        Me.FindBarEditItem.Caption = "Поиск"
        Me.FindBarEditItem.Edit = Me.FindRepositoryItemTextEdit
        Me.FindBarEditItem.EditWidth = 220
        Me.FindBarEditItem.Glyph = CType(resources.GetObject("FindBarEditItem.Glyph"), System.Drawing.Image)
        Me.FindBarEditItem.Id = 2
        Me.FindBarEditItem.Name = "FindBarEditItem"
        Me.FindBarEditItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'FindRepositoryItemTextEdit
        '
        Me.FindRepositoryItemTextEdit.Appearance.Font = New System.Drawing.Font("Arial", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FindRepositoryItemTextEdit.Appearance.Options.UseFont = True
        Me.FindRepositoryItemTextEdit.AutoHeight = False
        Me.FindRepositoryItemTextEdit.Name = "FindRepositoryItemTextEdit"
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
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.Appearance.Font = New System.Drawing.Font("Arial", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RepositoryItemButtonEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Далее", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Назад", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, "", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "Очистить", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'SynonGridControl
        '
        Me.SynonGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SynonGridControl.Location = New System.Drawing.Point(0, 39)
        Me.SynonGridControl.MainView = Me.SynonGridView
        Me.SynonGridControl.MenuManager = Me.BarManager1
        Me.SynonGridControl.Name = "SynonGridControl"
        Me.SynonGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1})
        Me.SynonGridControl.Size = New System.Drawing.Size(1000, 661)
        Me.SynonGridControl.TabIndex = 4
        Me.SynonGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.SynonGridView})
        '
        'SynonGridView
        '
        Me.SynonGridView.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.SynonGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SynonGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SynonGridView.Appearance.Row.Options.UseFont = True
        Me.SynonGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Word1GridColumn, Me.Word2GridColumn})
        Me.SynonGridView.GridControl = Me.SynonGridControl
        Me.SynonGridView.Name = "SynonGridView"
        Me.SynonGridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.[True]
        Me.SynonGridView.OptionsDetail.EnableMasterViewMode = False
        Me.SynonGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.SynonGridView.OptionsView.ShowGroupPanel = False
        '
        'Word1GridColumn
        '
        Me.Word1GridColumn.Caption = "Основное слово (фраза)"
        Me.Word1GridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.Word1GridColumn.FieldName = "word1"
        Me.Word1GridColumn.Name = "Word1GridColumn"
        Me.Word1GridColumn.Visible = True
        Me.Word1GridColumn.VisibleIndex = 0
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'Word2GridColumn
        '
        Me.Word2GridColumn.Caption = "Синонимы"
        Me.Word2GridColumn.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.Word2GridColumn.FieldName = "word2"
        Me.Word2GridColumn.Name = "Word2GridColumn"
        Me.Word2GridColumn.Visible = True
        Me.Word2GridColumn.VisibleIndex = 1
        '
        'SynonUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SynonGridControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "SynonUserControl"
        Me.Size = New System.Drawing.Size(1000, 700)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FindRepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SynonGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SynonGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SynonGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents SynonGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AutoHeightBarCheckItem As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents Word1GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents Word2GridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FindBarEditItem As DevExpress.XtraBars.BarEditItem
    Friend WithEvents FindRepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit

End Class
