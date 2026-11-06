<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits DevExpress.XtraBars.TabForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TabFormControl1 = New DevExpress.XtraBars.TabFormControl()
        Me.CountryBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.EXpertOrgBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.RegionBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkAcceptBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.ClientBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkPriceBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.OrderBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkCloseBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.WorkBackBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.FindGoodBarButtonItem = New DevExpress.XtraBars.BarButtonItem()
        Me.TabFormDefaultManager1 = New DevExpress.XtraBars.TabFormDefaultManager()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DefaultBarAndDockingController1 = New DevExpress.XtraBars.DefaultBarAndDockingController(Me.components)
        CType(Me.TabFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabFormDefaultManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabFormControl1
        '
        Me.TabFormControl1.AllowMoveTabsToOuterForm = False
        Me.TabFormControl1.Appearance.Page.Disabled.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Disabled.Options.UseFont = True
        Me.TabFormControl1.Appearance.Page.Hovered.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Hovered.Options.UseFont = True
        Me.TabFormControl1.Appearance.Page.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Normal.Options.UseFont = True
        Me.TabFormControl1.Appearance.Page.Pressed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabFormControl1.Appearance.Page.Pressed.Options.UseFont = True
        Me.TabFormControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.CountryBarButtonItem, Me.EXpertOrgBarButtonItem, Me.RegionBarButtonItem, Me.WorkAcceptBarButtonItem, Me.ClientBarButtonItem, Me.WorkPriceBarButtonItem, Me.OrderBarButtonItem, Me.BarButtonItem1, Me.WorkCloseBarButtonItem, Me.WorkBackBarButtonItem, Me.BarSubItem1, Me.BarSubItem2, Me.FindGoodBarButtonItem})
        Me.TabFormControl1.LinkProvider.TabLeftItemLinks.Add(Me.BarSubItem1)
        Me.TabFormControl1.LinkProvider.TabLeftItemLinks.Add(Me.BarSubItem2)
        Me.TabFormControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabFormControl1.Manager = Me.TabFormDefaultManager1
        Me.TabFormControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabFormControl1.Name = "TabFormControl1"
        Me.TabFormControl1.ShowAddPageButton = False
        Me.TabFormControl1.Size = New System.Drawing.Size(348, 68)
        Me.TabFormControl1.TabForm = Me
        Me.TabFormControl1.TabIndex = 0
        Me.TabFormControl1.TabStop = False
        '
        'CountryBarButtonItem
        '
        Me.CountryBarButtonItem.Caption = "ПОСТАВКИ ПО СТРАНАМ"
        Me.CountryBarButtonItem.Description = "Количество поставок в страны мира за период"
        Me.CountryBarButtonItem.Id = 12
        Me.CountryBarButtonItem.LargeGlyph = CType(resources.GetObject("CountryBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.CountryBarButtonItem.Name = "CountryBarButtonItem"
        '
        'EXpertOrgBarButtonItem
        '
        Me.EXpertOrgBarButtonItem.Caption = "ЭКСПЕРТНЫЕ ОРГАНИЗАЦИИ"
        Me.EXpertOrgBarButtonItem.Description = "Кличество выданных заключений на указанную дату с начала года"
        Me.EXpertOrgBarButtonItem.Id = 13
        Me.EXpertOrgBarButtonItem.LargeGlyph = CType(resources.GetObject("EXpertOrgBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.EXpertOrgBarButtonItem.Name = "EXpertOrgBarButtonItem"
        '
        'RegionBarButtonItem
        '
        Me.RegionBarButtonItem.Caption = "ЗАКАЗЫ ПО РЕГИОНАМ"
        Me.RegionBarButtonItem.Description = "Количество заказов по регионам / федеральным округам за период"
        Me.RegionBarButtonItem.Id = 14
        Me.RegionBarButtonItem.LargeGlyph = CType(resources.GetObject("RegionBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.RegionBarButtonItem.Name = "RegionBarButtonItem"
        '
        'WorkAcceptBarButtonItem
        '
        Me.WorkAcceptBarButtonItem.Caption = "НЕ ЗАКРЫТЫЕ РАБОТЫ"
        Me.WorkAcceptBarButtonItem.Description = "Выполненные работы, не выданные заказчикам услуг"
        Me.WorkAcceptBarButtonItem.Id = 15
        Me.WorkAcceptBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkAcceptBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkAcceptBarButtonItem.Name = "WorkAcceptBarButtonItem"
        '
        'ClientBarButtonItem
        '
        Me.ClientBarButtonItem.Caption = "ЗАКАЗЧИКИ / УЧАСТНИКИ ВЭД"
        Me.ClientBarButtonItem.Description = "Сведения о заказчиках услуг / участниках ВЭД"
        Me.ClientBarButtonItem.Id = 16
        Me.ClientBarButtonItem.LargeGlyph = CType(resources.GetObject("ClientBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.ClientBarButtonItem.Name = "ClientBarButtonItem"
        '
        'WorkPriceBarButtonItem
        '
        Me.WorkPriceBarButtonItem.Caption = "СРАВНИТЕЛЬНЫЕ СТОИМОСТИ"
        Me.WorkPriceBarButtonItem.Description = "Сравнительные стимости работ по объектам и товарам"
        Me.WorkPriceBarButtonItem.Glyph = CType(resources.GetObject("WorkPriceBarButtonItem.Glyph"), System.Drawing.Image)
        Me.WorkPriceBarButtonItem.Id = 17
        Me.WorkPriceBarButtonItem.Name = "WorkPriceBarButtonItem"
        '
        'OrderBarButtonItem
        '
        Me.OrderBarButtonItem.Caption = "ЗАКАЗЧИКИ ЗА ПЕРИОД"
        Me.OrderBarButtonItem.Description = "Обращения заказчиков за период"
        Me.OrderBarButtonItem.Id = 18
        Me.OrderBarButtonItem.LargeGlyph = CType(resources.GetObject("OrderBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.OrderBarButtonItem.Name = "OrderBarButtonItem"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "СТОИМОСТИ ЗА ПЕРИОД"
        Me.BarButtonItem1.Description = "Стоимости работ выполненных за период"
        Me.BarButtonItem1.Id = 19
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'WorkCloseBarButtonItem
        '
        Me.WorkCloseBarButtonItem.Caption = "РАБОТЫ ЗА ПЕРИОД"
        Me.WorkCloseBarButtonItem.Description = "Количество работ за период"
        Me.WorkCloseBarButtonItem.Id = 20
        Me.WorkCloseBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkCloseBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkCloseBarButtonItem.Name = "WorkCloseBarButtonItem"
        '
        'WorkBackBarButtonItem
        '
        Me.WorkBackBarButtonItem.Caption = "ВНЕСЕНИЯ ИЗМЕНЕНИЙ"
        Me.WorkBackBarButtonItem.Description = "Количество внесений изменений за период"
        Me.WorkBackBarButtonItem.Id = 21
        Me.WorkBackBarButtonItem.LargeGlyph = CType(resources.GetObject("WorkBackBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.WorkBackBarButtonItem.Name = "WorkBackBarButtonItem"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Отчеты"
        Me.BarSubItem1.Id = 22
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.EXpertOrgBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.RegionBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.CountryBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.WorkAcceptBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.ClientBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.WorkPriceBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.OrderBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.WorkCloseBarButtonItem), New DevExpress.XtraBars.LinkPersistInfo(Me.WorkBackBarButtonItem)})
        Me.BarSubItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "Поиск"
        Me.BarSubItem2.Id = 23
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.FindGoodBarButtonItem)})
        Me.BarSubItem2.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'FindGoodBarButtonItem
        '
        Me.FindGoodBarButtonItem.Caption = "Поиск товаров"
        Me.FindGoodBarButtonItem.Description = "Поиск товаров в базе ЭС"
        Me.FindGoodBarButtonItem.Hint = "Поиск товаров в базе ЭС"
        Me.FindGoodBarButtonItem.Id = 24
        Me.FindGoodBarButtonItem.LargeGlyph = CType(resources.GetObject("FindGoodBarButtonItem.LargeGlyph"), System.Drawing.Image)
        Me.FindGoodBarButtonItem.Name = "FindGoodBarButtonItem"
        '
        'TabFormDefaultManager1
        '
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlTop)
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlBottom)
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlLeft)
        Me.TabFormDefaultManager1.DockControls.Add(Me.barDockControlRight)
        Me.TabFormDefaultManager1.Form = Me
        Me.TabFormDefaultManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.CountryBarButtonItem, Me.EXpertOrgBarButtonItem, Me.RegionBarButtonItem, Me.WorkAcceptBarButtonItem, Me.ClientBarButtonItem, Me.WorkPriceBarButtonItem, Me.OrderBarButtonItem, Me.BarButtonItem1, Me.WorkCloseBarButtonItem, Me.WorkBackBarButtonItem, Me.BarSubItem1, Me.BarSubItem2, Me.FindGoodBarButtonItem})
        Me.TabFormDefaultManager1.MaxItemId = 25
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(348, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 368)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(348, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 368)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(348, 0)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 368)
        '
        'DefaultBarAndDockingController1
        '
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Disabled.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Pressed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.BarAppearance.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Disabled.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Hovered.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Pressed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.StatusBarAppearance.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Disabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Hovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Normal.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.DefaultBarAndDockingController1.Controller.AppearancesBar.SubMenu.AppearanceMenu.Pressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Item.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.Item.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDisabled.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemDisabled.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemHovered.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemHovered.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemPressed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DefaultBarAndDockingController1.Controller.AppearancesRibbon.ItemPressed.Options.UseFont = True
        Me.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultGlyphSize = New System.Drawing.Size(16, 16)
        Me.DefaultBarAndDockingController1.Controller.PropertiesBar.DefaultLargeGlyphSize = New System.Drawing.Size(32, 32)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 368)
        Me.Controls.Add(Me.TabFormControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.TabFormControl = Me.TabFormControl1
        Me.Text = "MainForm"
        CType(Me.TabFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabFormDefaultManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabFormControl1 As DevExpress.XtraBars.TabFormControl
    Friend WithEvents TabFormDefaultManager1 As DevExpress.XtraBars.TabFormDefaultManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents DefaultBarAndDockingController1 As DevExpress.XtraBars.DefaultBarAndDockingController
    Friend WithEvents CountryBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents EXpertOrgBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RegionBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkAcceptBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ClientBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkPriceBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents OrderBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkCloseBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents WorkBackBarButtonItem As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents FindGoodBarButtonItem As DevExpress.XtraBars.BarButtonItem
End Class
