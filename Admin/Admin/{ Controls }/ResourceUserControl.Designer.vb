<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResourceUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResourceUserControl))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ResourceGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ResourceGridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StringGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ImageGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ImageRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.CommentGridColumn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.DataSaveBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.DataReloadBaseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.MainPopupMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ResourceGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResourceGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPopupMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.ResourceGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ResourceGridControl
        '
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.First.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.ResourceGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ResourceGridControl.Location = New System.Drawing.Point(16, 16)
        Me.ResourceGridControl.MainView = Me.ResourceGridView
        Me.ResourceGridControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ResourceGridControl.Name = "ResourceGridControl"
        Me.ResourceGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ImageRepositoryItemButtonEdit})
        Me.ResourceGridControl.Size = New System.Drawing.Size(918, 618)
        Me.ResourceGridControl.TabIndex = 7
        Me.ResourceGridControl.UseEmbeddedNavigator = True
        Me.ResourceGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ResourceGridView})
        '
        'ResourceGridView
        '
        Me.ResourceGridView.Appearance.Row.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ResourceGridView.Appearance.Row.Options.UseFont = True
        Me.ResourceGridView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NameGridColumn, Me.StringGridColumn, Me.ImageGridColumn, Me.CommentGridColumn})
        Me.ResourceGridView.GridControl = Me.ResourceGridControl
        Me.ResourceGridView.Name = "ResourceGridView"
        Me.ResourceGridView.RowHeight = 25
        '
        'NameGridColumn
        '
        Me.NameGridColumn.Caption = "Наименование"
        Me.NameGridColumn.FieldName = "name"
        Me.NameGridColumn.Name = "NameGridColumn"
        Me.NameGridColumn.Visible = True
        Me.NameGridColumn.VisibleIndex = 0
        '
        'StringGridColumn
        '
        Me.StringGridColumn.Caption = "Строковые данные"
        Me.StringGridColumn.FieldName = "strData"
        Me.StringGridColumn.Name = "StringGridColumn"
        Me.StringGridColumn.Visible = True
        Me.StringGridColumn.VisibleIndex = 1
        '
        'ImageGridColumn
        '
        Me.ImageGridColumn.Caption = "Двоичные данные"
        Me.ImageGridColumn.ColumnEdit = Me.ImageRepositoryItemButtonEdit
        Me.ImageGridColumn.FieldName = "binData"
        Me.ImageGridColumn.Name = "ImageGridColumn"
        Me.ImageGridColumn.Visible = True
        Me.ImageGridColumn.VisibleIndex = 2
        '
        'ImageRepositoryItemButtonEdit
        '
        Me.ImageRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem1.Text = "Загрузить из файла"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Загрузить данные из файла"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        ToolTipTitleItem2.Text = "Выгрузить в файл"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Выгрузить данные в файл"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        ToolTipTitleItem3.Text = "Удалить данные"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Удалить данные"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.ImageRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Загрузить из файла", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("ImageRepositoryItemButtonEdit.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, SuperToolTip1, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Выгрузить в файл", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("ImageRepositoryItemButtonEdit.Buttons1"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, SuperToolTip2, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Удалить данные", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("ImageRepositoryItemButtonEdit.Buttons2"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, SuperToolTip3, True)})
        Me.ImageRepositoryItemButtonEdit.Name = "ImageRepositoryItemButtonEdit"
        Me.ImageRepositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'CommentGridColumn
        '
        Me.CommentGridColumn.Caption = "Примечание"
        Me.CommentGridColumn.FieldName = "comment"
        Me.CommentGridColumn.Name = "CommentGridColumn"
        Me.CommentGridColumn.Visible = True
        Me.CommentGridColumn.VisibleIndex = 3
        '
        'RootLayoutControlGroup
        '
        Me.RootLayoutControlGroup.AppearanceGroup.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceGroup.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceItemCaption.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceItemCaption.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.Header.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderActive.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderDisabled.Options.UseFont = True
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.RootLayoutControlGroup.AppearanceTabPage.HeaderHotTracked.Options.UseFont = True
        Me.RootLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.RootLayoutControlGroup.GroupBordersVisible = False
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "RootLayoutControlGroup"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(950, 650)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ResourceGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(924, 624)
        Me.LayoutControlItem1.Text = "Ресурсы"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.DataSaveBaseBarButtonItem, Me.DataReloadBaseBarButtonItem})
        Me.BarManager1.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 650)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(950, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 650)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(950, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 650)
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Данные"
        Me.BarSubItem1.Description = "Загрузить, сохранить, перечитать ..."
        Me.BarSubItem1.Id = 0
        Me.BarSubItem1.LargeGlyph = CType(resources.GetObject("BarSubItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.DataSaveBaseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.DataReloadBaseBarButtonItem)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'DataSaveBaseBarButtonItem
        '
        Me.DataSaveBaseBarButtonItem.Caption = "Сохранить"
        Me.DataSaveBaseBarButtonItem.Description = "Сохранить данные в базу"
        Me.DataSaveBaseBarButtonItem.Id = 1
        Me.DataSaveBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("DataSaveBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataSaveBaseBarButtonItem.Name = "DataSaveBaseBarButtonItem"
        '
        'DataReloadBaseBarButtonItem
        '
        Me.DataReloadBaseBarButtonItem.Caption = "Перечитать"
        Me.DataReloadBaseBarButtonItem.Description = "Перечитать данные из базы"
        Me.DataReloadBaseBarButtonItem.Id = 2
        Me.DataReloadBaseBarButtonItem.LargeGlyph = CType(resources.GetObject("DataReloadBaseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.DataReloadBaseBarButtonItem.Name = "DataReloadBaseBarButtonItem"
        '
        'MainPopupMenu
        '
        Me.MainPopupMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1)})
        Me.MainPopupMenu.Manager = Me.BarManager1
        Me.MainPopupMenu.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.MainPopupMenu.Name = "MainPopupMenu"
        '
        'ResourceUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ResourceUserControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ResourceGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResourceGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPopupMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ResourceGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents ResourceGridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NameGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StringGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImageGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ImageRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents CommentGridColumn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents MainPopupMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DataSaveBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataReloadBaseBarButtonItem As DevExpress.XtraBars.BarButtonItem

End Class
