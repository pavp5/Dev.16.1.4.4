Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления "Данные работы"
''' </summary>
Friend Class LicenseDataChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Private components As System.ComponentModel.IContainer
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LicenseDataGridControl As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents catStat As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowStatNum As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowStatDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowLicType As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catClient As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowClientName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowClientAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowLicTerm As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents catCon As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowConNum As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row1ConDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catIncoterms As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowIncoterms As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowIncotermsPlace As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catBayer As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowBayerName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowBayerAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catDev As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowDevName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowDevAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catEnd As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowEndName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents row1EndAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowDevCountry As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowByerCountry As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowTransitCountry As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEndCountry As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowGoodCaption As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowGoodTnved As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowCurrency As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowUnit As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPayment As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowUnitCount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowUsdPrice As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowGoodUsed As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catBank As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowBankName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowBankAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowBankAccount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowLicBasis As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowLaw As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowLawPos As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowCustom As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowExtraInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents catPerson As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents rowPersonName As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPersonJob As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowPersonPhone As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CountryRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LicTypeRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents IncotermsRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents CountryRepositoryItemCheckedComboBoxEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit
    Friend WithEvents CurrencyRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents PaymentRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UnitRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LawCaptionRepositoryItemLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ClientRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BayerRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents DeveloperRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents EndUserRepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem

    Private Sub InitializeComponent()
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
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LicenseDataGridControl = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.CountryRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LicTypeRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.IncotermsRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.CountryRepositoryItemCheckedComboBoxEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit()
        Me.CurrencyRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.PaymentRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UnitRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.LawCaptionRepositoryItemLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ClientRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.BayerRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.DeveloperRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.EndUserRepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.catStat = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowStatNum = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowStatDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowLicType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catClient = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowClientName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowClientAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowLicTerm = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catCon = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowConNum = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row1ConDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catIncoterms = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowIncoterms = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncotermsPlace = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catBayer = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowBayerName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBayerAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catDev = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowDevName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowDevAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catEnd = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowEndName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row1EndAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowDevCountry = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowByerCountry = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowTransitCountry = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEndCountry = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowGoodCaption = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowGoodTnved = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowCurrency = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowUnit = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPayment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowUnitCount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowUsdPrice = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowGoodUsed = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catBank = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowBankName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBankAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBankAccount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowLicBasis = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowLaw = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowLawPos = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowCustom = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowExtraInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.catPerson = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowPersonName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPersonJob = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPersonPhone = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LicenseDataGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LicTypeRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IncotermsRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CountryRepositoryItemCheckedComboBoxEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LawCaptionRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BayerRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeveloperRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EndUserRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.LicenseDataGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(730, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(950, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LicenseDataGridControl
        '
        Me.LicenseDataGridControl.Appearance.Category.Font = New System.Drawing.Font("Arial", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicenseDataGridControl.Appearance.Category.Options.UseFont = True
        Me.LicenseDataGridControl.Appearance.RecordValue.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicenseDataGridControl.Appearance.RecordValue.Options.UseFont = True
        Me.LicenseDataGridControl.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Arial", 10.18868!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicenseDataGridControl.Appearance.RowHeaderPanel.Options.UseFont = True
        Me.LicenseDataGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
        Me.LicenseDataGridControl.Location = New System.Drawing.Point(12, 52)
        Me.LicenseDataGridControl.Name = "LicenseDataGridControl"
        Me.LicenseDataGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryItemDateEdit1, Me.CountryRepositoryItemLookUpEdit, Me.LicTypeRepositoryItemLookUpEdit, Me.IncotermsRepositoryItemLookUpEdit, Me.CountryRepositoryItemCheckedComboBoxEdit, Me.CurrencyRepositoryItemLookUpEdit, Me.PaymentRepositoryItemLookUpEdit, Me.UnitRepositoryItemLookUpEdit, Me.LawCaptionRepositoryItemLookUpEdit, Me.ClientRepositoryItemButtonEdit, Me.BayerRepositoryItemButtonEdit, Me.DeveloperRepositoryItemButtonEdit, Me.EndUserRepositoryItemButtonEdit})
        Me.LicenseDataGridControl.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.catStat, Me.rowLicType, Me.catClient, Me.rowLicTerm, Me.catCon, Me.catIncoterms, Me.catBayer, Me.catDev, Me.catEnd, Me.rowDevCountry, Me.rowByerCountry, Me.rowTransitCountry, Me.rowEndCountry, Me.rowGoodCaption, Me.rowGoodTnved, Me.rowCurrency, Me.rowUnit, Me.rowPayment, Me.rowUnitCount, Me.rowUsdPrice, Me.rowGoodUsed, Me.catBank, Me.rowLicBasis, Me.rowLaw, Me.rowLawPos, Me.rowCustom, Me.rowExtraInfo, Me.catPerson})
        Me.LicenseDataGridControl.Size = New System.Drawing.Size(926, 596)
        Me.LicenseDataGridControl.TabIndex = 4
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'CountryRepositoryItemLookUpEdit
        '
        Me.CountryRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.CountryRepositoryItemLookUpEdit.AutoHeight = False
        Me.CountryRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CountryRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameShort", "nameShort")})
        Me.CountryRepositoryItemLookUpEdit.DisplayMember = "nameShort"
        Me.CountryRepositoryItemLookUpEdit.Name = "CountryRepositoryItemLookUpEdit"
        Me.CountryRepositoryItemLookUpEdit.NullText = ""
        Me.CountryRepositoryItemLookUpEdit.ShowFooter = False
        Me.CountryRepositoryItemLookUpEdit.ShowHeader = False
        Me.CountryRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CountryRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'LicTypeRepositoryItemLookUpEdit
        '
        Me.LicTypeRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicTypeRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.LicTypeRepositoryItemLookUpEdit.AutoHeight = False
        Me.LicTypeRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LicTypeRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.LicTypeRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.LicTypeRepositoryItemLookUpEdit.DropDownRows = 3
        Me.LicTypeRepositoryItemLookUpEdit.Name = "LicTypeRepositoryItemLookUpEdit"
        Me.LicTypeRepositoryItemLookUpEdit.NullText = ""
        Me.LicTypeRepositoryItemLookUpEdit.ShowFooter = False
        Me.LicTypeRepositoryItemLookUpEdit.ShowHeader = False
        Me.LicTypeRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'IncotermsRepositoryItemLookUpEdit
        '
        Me.IncotermsRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.IncotermsRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.IncotermsRepositoryItemLookUpEdit.AutoHeight = False
        Me.IncotermsRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.IncotermsRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameDescription", "nameDescription")})
        Me.IncotermsRepositoryItemLookUpEdit.DisplayMember = "nameDescription"
        Me.IncotermsRepositoryItemLookUpEdit.Name = "IncotermsRepositoryItemLookUpEdit"
        Me.IncotermsRepositoryItemLookUpEdit.NullText = ""
        Me.IncotermsRepositoryItemLookUpEdit.ShowFooter = False
        Me.IncotermsRepositoryItemLookUpEdit.ShowHeader = False
        Me.IncotermsRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'CountryRepositoryItemCheckedComboBoxEdit
        '
        Me.CountryRepositoryItemCheckedComboBoxEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CountryRepositoryItemCheckedComboBoxEdit.AppearanceDropDown.Options.UseFont = True
        Me.CountryRepositoryItemCheckedComboBoxEdit.AutoHeight = False
        Me.CountryRepositoryItemCheckedComboBoxEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CountryRepositoryItemCheckedComboBoxEdit.DisplayMember = "nameShort"
        Me.CountryRepositoryItemCheckedComboBoxEdit.Name = "CountryRepositoryItemCheckedComboBoxEdit"
        Me.CountryRepositoryItemCheckedComboBoxEdit.ValueMember = "id"
        '
        'CurrencyRepositoryItemLookUpEdit
        '
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CurrencyRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.CurrencyRepositoryItemLookUpEdit.AutoHeight = False
        Me.CurrencyRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrencyRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameCode", "nameCode")})
        Me.CurrencyRepositoryItemLookUpEdit.DisplayMember = "nameCode"
        Me.CurrencyRepositoryItemLookUpEdit.Name = "CurrencyRepositoryItemLookUpEdit"
        Me.CurrencyRepositoryItemLookUpEdit.NullText = ""
        Me.CurrencyRepositoryItemLookUpEdit.ShowFooter = False
        Me.CurrencyRepositoryItemLookUpEdit.ShowHeader = False
        Me.CurrencyRepositoryItemLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CurrencyRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'PaymentRepositoryItemLookUpEdit
        '
        Me.PaymentRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PaymentRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.PaymentRepositoryItemLookUpEdit.AutoHeight = False
        Me.PaymentRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PaymentRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.PaymentRepositoryItemLookUpEdit.DisplayMember = "name"
        Me.PaymentRepositoryItemLookUpEdit.Name = "PaymentRepositoryItemLookUpEdit"
        Me.PaymentRepositoryItemLookUpEdit.NullText = ""
        Me.PaymentRepositoryItemLookUpEdit.ShowFooter = False
        Me.PaymentRepositoryItemLookUpEdit.ShowHeader = False
        Me.PaymentRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'UnitRepositoryItemLookUpEdit
        '
        Me.UnitRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UnitRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.UnitRepositoryItemLookUpEdit.AutoHeight = False
        Me.UnitRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UnitRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("nameCode", "nameCode")})
        Me.UnitRepositoryItemLookUpEdit.DisplayMember = "nameCode"
        Me.UnitRepositoryItemLookUpEdit.Name = "UnitRepositoryItemLookUpEdit"
        Me.UnitRepositoryItemLookUpEdit.NullText = ""
        Me.UnitRepositoryItemLookUpEdit.ShowFooter = False
        Me.UnitRepositoryItemLookUpEdit.ShowHeader = False
        Me.UnitRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'LawCaptionRepositoryItemLookUpEdit
        '
        Me.LawCaptionRepositoryItemLookUpEdit.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.22642!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LawCaptionRepositoryItemLookUpEdit.AppearanceDropDown.Options.UseFont = True
        Me.LawCaptionRepositoryItemLookUpEdit.AutoHeight = False
        Me.LawCaptionRepositoryItemLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LawCaptionRepositoryItemLookUpEdit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("codeDecLetter", "codeDecLetter")})
        Me.LawCaptionRepositoryItemLookUpEdit.DisplayMember = "codeDecLetter"
        Me.LawCaptionRepositoryItemLookUpEdit.Name = "LawCaptionRepositoryItemLookUpEdit"
        Me.LawCaptionRepositoryItemLookUpEdit.NullText = ""
        Me.LawCaptionRepositoryItemLookUpEdit.ShowFooter = False
        Me.LawCaptionRepositoryItemLookUpEdit.ShowHeader = False
        Me.LawCaptionRepositoryItemLookUpEdit.ValueMember = "id"
        '
        'ClientRepositoryItemButtonEdit
        '
        Me.ClientRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem1.Text = "Заказчик"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Подставить реквизиты заказчика услуги"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.ClientRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Заказчик", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, SuperToolTip1, True)})
        Me.ClientRepositoryItemButtonEdit.Name = "ClientRepositoryItemButtonEdit"
        '
        'BayerRepositoryItemButtonEdit
        '
        Me.BayerRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem2.Text = "Поиск"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Поиск покупателя в базе данных"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.BayerRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Поиск", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, SuperToolTip2, True)})
        Me.BayerRepositoryItemButtonEdit.Name = "BayerRepositoryItemButtonEdit"
        '
        'DeveloperRepositoryItemButtonEdit
        '
        Me.DeveloperRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem3.Text = "Поиск"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Поиск разработчика в базе данных"
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.DeveloperRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Поиск", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, SuperToolTip3, True)})
        Me.DeveloperRepositoryItemButtonEdit.Name = "DeveloperRepositoryItemButtonEdit"
        '
        'EndUserRepositoryItemButtonEdit
        '
        Me.EndUserRepositoryItemButtonEdit.AutoHeight = False
        ToolTipTitleItem4.Text = "Поиск"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Поиск конечного пользователя в базе данных"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.EndUserRepositoryItemButtonEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Поиск", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, SuperToolTip4, True)})
        Me.EndUserRepositoryItemButtonEdit.Name = "EndUserRepositoryItemButtonEdit"
        '
        'catStat
        '
        Me.catStat.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowStatNum, Me.rowStatDate})
        Me.catStat.Name = "catStat"
        Me.catStat.OptionsRow.AllowSize = False
        Me.catStat.Properties.Caption = "1. ЗАЯВЛЕНИЕ О ПРЕДОСТАВЛЕНИИ ЛИЦЕНЗИИ"
        Me.catStat.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowStatNum
        '
        Me.rowStatNum.Name = "rowStatNum"
        Me.rowStatNum.OptionsRow.AllowSize = False
        Me.rowStatNum.Properties.Caption = "Номер"
        Me.rowStatNum.Properties.FieldName = "statNum"
        Me.rowStatNum.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowStatDate
        '
        Me.rowStatDate.Name = "rowStatDate"
        Me.rowStatDate.OptionsRow.AllowSize = False
        Me.rowStatDate.Properties.Caption = "Дата"
        Me.rowStatDate.Properties.FieldName = "statDate"
        Me.rowStatDate.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowLicType
        '
        Me.rowLicType.Name = "rowLicType"
        Me.rowLicType.OptionsRow.AllowSize = False
        Me.rowLicType.Properties.Caption = "2. Тип запрашиваемой лицензии"
        Me.rowLicType.Properties.FieldName = "licTypeId"
        Me.rowLicType.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowLicType.Properties.RowEdit = Me.LicTypeRepositoryItemLookUpEdit
        '
        'catClient
        '
        Me.catClient.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowClientName, Me.rowClientAddress})
        Me.catClient.Name = "catClient"
        Me.catClient.OptionsRow.AllowSize = False
        Me.catClient.Properties.Caption = "3. Заявитель"
        Me.catClient.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowClientName
        '
        Me.rowClientName.Name = "rowClientName"
        Me.rowClientName.OptionsRow.AllowSize = False
        Me.rowClientName.Properties.Caption = "Наименование"
        Me.rowClientName.Properties.FieldName = "clientName"
        Me.rowClientName.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowClientName.Properties.RowEdit = Me.ClientRepositoryItemButtonEdit
        '
        'rowClientAddress
        '
        Me.rowClientAddress.Name = "rowClientAddress"
        Me.rowClientAddress.OptionsRow.AllowSize = False
        Me.rowClientAddress.Properties.Caption = "Адрес"
        Me.rowClientAddress.Properties.FieldName = "clientAddress"
        Me.rowClientAddress.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowLicTerm
        '
        Me.rowLicTerm.Name = "rowLicTerm"
        Me.rowLicTerm.OptionsRow.AllowSize = False
        Me.rowLicTerm.Properties.Caption = "4. Заявляемый срок действия лицензии до "
        Me.rowLicTerm.Properties.FieldName = "licTerm"
        Me.rowLicTerm.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'catCon
        '
        Me.catCon.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowConNum, Me.row1ConDate})
        Me.catCon.Name = "catCon"
        Me.catCon.OptionsRow.AllowSize = False
        Me.catCon.Properties.Caption = "5. Контракт (договор)"
        Me.catCon.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowConNum
        '
        Me.rowConNum.Name = "rowConNum"
        Me.rowConNum.OptionsRow.AllowSize = False
        Me.rowConNum.Properties.Caption = "Номер"
        Me.rowConNum.Properties.FieldName = "conNum"
        Me.rowConNum.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'row1ConDate
        '
        Me.row1ConDate.Name = "row1ConDate"
        Me.row1ConDate.OptionsRow.AllowSize = False
        Me.row1ConDate.Properties.Caption = "Дата"
        Me.row1ConDate.Properties.FieldName = "conDate"
        Me.row1ConDate.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'catIncoterms
        '
        Me.catIncoterms.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncoterms, Me.rowIncotermsPlace})
        Me.catIncoterms.Name = "catIncoterms"
        Me.catIncoterms.OptionsRow.AllowSize = False
        Me.catIncoterms.Properties.Caption = "6. Условия поставки"
        Me.catIncoterms.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowIncoterms
        '
        Me.rowIncoterms.Name = "rowIncoterms"
        Me.rowIncoterms.OptionsRow.AllowSize = False
        Me.rowIncoterms.Properties.Caption = "Условие поставки"
        Me.rowIncoterms.Properties.FieldName = "incotermsId"
        Me.rowIncoterms.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowIncoterms.Properties.RowEdit = Me.IncotermsRepositoryItemLookUpEdit
        '
        'rowIncotermsPlace
        '
        Me.rowIncotermsPlace.Name = "rowIncotermsPlace"
        Me.rowIncotermsPlace.OptionsRow.AllowSize = False
        Me.rowIncotermsPlace.Properties.Caption = "Место доставки"
        Me.rowIncotermsPlace.Properties.FieldName = "incotermsPlace"
        Me.rowIncotermsPlace.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'catBayer
        '
        Me.catBayer.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowBayerName, Me.rowBayerAddress})
        Me.catBayer.Name = "catBayer"
        Me.catBayer.OptionsRow.AllowSize = False
        Me.catBayer.Properties.Caption = "7. Покупатель/продавец"
        Me.catBayer.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowBayerName
        '
        Me.rowBayerName.Name = "rowBayerName"
        Me.rowBayerName.OptionsRow.AllowSize = False
        Me.rowBayerName.Properties.Caption = "Наименование"
        Me.rowBayerName.Properties.FieldName = "bayerName"
        Me.rowBayerName.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowBayerName.Properties.RowEdit = Me.BayerRepositoryItemButtonEdit
        '
        'rowBayerAddress
        '
        Me.rowBayerAddress.Name = "rowBayerAddress"
        Me.rowBayerAddress.OptionsRow.AllowSize = False
        Me.rowBayerAddress.Properties.Caption = "Адрес"
        Me.rowBayerAddress.Properties.FieldName = "bayerAddress"
        Me.rowBayerAddress.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'catDev
        '
        Me.catDev.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowDevName, Me.rowDevAddress})
        Me.catDev.Name = "catDev"
        Me.catDev.OptionsRow.AllowSize = False
        Me.catDev.Properties.Caption = "8. Изготовитель/разработчик "
        Me.catDev.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowDevName
        '
        Me.rowDevName.Name = "rowDevName"
        Me.rowDevName.OptionsRow.AllowSize = False
        Me.rowDevName.Properties.Caption = "Наименование"
        Me.rowDevName.Properties.FieldName = "devName"
        Me.rowDevName.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowDevName.Properties.RowEdit = Me.DeveloperRepositoryItemButtonEdit
        '
        'rowDevAddress
        '
        Me.rowDevAddress.Name = "rowDevAddress"
        Me.rowDevAddress.OptionsRow.AllowSize = False
        Me.rowDevAddress.Properties.Caption = "Адрес"
        Me.rowDevAddress.Properties.FieldName = "devAddress"
        Me.rowDevAddress.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'catEnd
        '
        Me.catEnd.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowEndName, Me.row1EndAddress})
        Me.catEnd.Name = "catEnd"
        Me.catEnd.OptionsRow.AllowSize = False
        Me.catEnd.Properties.Caption = "9. Конечный пользователь"
        Me.catEnd.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowEndName
        '
        Me.rowEndName.Name = "rowEndName"
        Me.rowEndName.OptionsRow.AllowSize = False
        Me.rowEndName.Properties.Caption = "Наименование"
        Me.rowEndName.Properties.FieldName = "endName"
        Me.rowEndName.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowEndName.Properties.RowEdit = Me.EndUserRepositoryItemButtonEdit
        '
        'row1EndAddress
        '
        Me.row1EndAddress.Name = "row1EndAddress"
        Me.row1EndAddress.OptionsRow.AllowSize = False
        Me.row1EndAddress.Properties.Caption = "Адрес"
        Me.row1EndAddress.Properties.FieldName = "endAddress"
        Me.row1EndAddress.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowDevCountry
        '
        Me.rowDevCountry.Name = "rowDevCountry"
        Me.rowDevCountry.OptionsRow.AllowSize = False
        Me.rowDevCountry.Properties.Caption = "10. Страна происхождения"
        Me.rowDevCountry.Properties.FieldName = "devCountryId"
        Me.rowDevCountry.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowDevCountry.Properties.RowEdit = Me.CountryRepositoryItemLookUpEdit
        '
        'rowByerCountry
        '
        Me.rowByerCountry.Name = "rowByerCountry"
        Me.rowByerCountry.OptionsRow.AllowSize = False
        Me.rowByerCountry.Properties.Caption = "11. Страна покупателя/продавца"
        Me.rowByerCountry.Properties.FieldName = "bayerCountryId"
        Me.rowByerCountry.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowByerCountry.Properties.RowEdit = Me.CountryRepositoryItemLookUpEdit
        '
        'rowTransitCountry
        '
        Me.rowTransitCountry.Name = "rowTransitCountry"
        Me.rowTransitCountry.OptionsRow.AllowSize = False
        Me.rowTransitCountry.Properties.Caption = "12. Страна (страны) транзита"
        Me.rowTransitCountry.Properties.FieldName = "transitCountryIdString"
        Me.rowTransitCountry.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowTransitCountry.Properties.RowEdit = Me.CountryRepositoryItemCheckedComboBoxEdit
        '
        'rowEndCountry
        '
        Me.rowEndCountry.Name = "rowEndCountry"
        Me.rowEndCountry.OptionsRow.AllowSize = False
        Me.rowEndCountry.Properties.Caption = "13. Страна конечного использования"
        Me.rowEndCountry.Properties.FieldName = "endCountryId"
        Me.rowEndCountry.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowEndCountry.Properties.RowEdit = Me.CountryRepositoryItemLookUpEdit
        '
        'rowGoodCaption
        '
        Me.rowGoodCaption.Height = 50
        Me.rowGoodCaption.Name = "rowGoodCaption"
        Me.rowGoodCaption.Properties.Caption = "14. Наименование и характеристика (описание) продукции"
        Me.rowGoodCaption.Properties.FieldName = "goodCaption"
        Me.rowGoodCaption.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowGoodCaption.Properties.RowEdit = Me.RepositoryItemMemoEdit1
        '
        'rowGoodTnved
        '
        Me.rowGoodTnved.Name = "rowGoodTnved"
        Me.rowGoodTnved.OptionsRow.AllowSize = False
        Me.rowGoodTnved.Properties.Caption = "15. Код ТН ВЭД"
        Me.rowGoodTnved.Properties.FieldName = "goodTnved"
        Me.rowGoodTnved.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowCurrency
        '
        Me.rowCurrency.Name = "rowCurrency"
        Me.rowCurrency.OptionsRow.AllowSize = False
        Me.rowCurrency.Properties.Caption = "16. Валюта контракта"
        Me.rowCurrency.Properties.FieldName = "currencyId"
        Me.rowCurrency.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowCurrency.Properties.RowEdit = Me.CurrencyRepositoryItemLookUpEdit
        '
        'rowUnit
        '
        Me.rowUnit.Name = "rowUnit"
        Me.rowUnit.OptionsRow.AllowSize = False
        Me.rowUnit.Properties.Caption = "17. Единица измерения"
        Me.rowUnit.Properties.FieldName = "unitId"
        Me.rowUnit.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowUnit.Properties.RowEdit = Me.UnitRepositoryItemLookUpEdit
        '
        'rowPayment
        '
        Me.rowPayment.Name = "rowPayment"
        Me.rowPayment.OptionsRow.AllowSize = False
        Me.rowPayment.Properties.Caption = "18. Условия платежа"
        Me.rowPayment.Properties.FieldName = "paymentId"
        Me.rowPayment.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowPayment.Properties.RowEdit = Me.PaymentRepositoryItemLookUpEdit
        '
        'rowUnitCount
        '
        Me.rowUnitCount.Name = "rowUnitCount"
        Me.rowUnitCount.OptionsRow.AllowSize = False
        Me.rowUnitCount.Properties.Caption = "19. Количество"
        Me.rowUnitCount.Properties.FieldName = "unitCount"
        Me.rowUnitCount.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowUsdPrice
        '
        Me.rowUsdPrice.Appearance.Options.UseTextOptions = True
        Me.rowUsdPrice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.rowUsdPrice.Name = "rowUsdPrice"
        Me.rowUsdPrice.OptionsRow.AllowSize = False
        Me.rowUsdPrice.Properties.Caption = "20. Статистическая стоимость"
        Me.rowUsdPrice.Properties.FieldName = "usdPrice"
        Me.rowUsdPrice.Properties.Format.FormatString = "{0:n0} $"
        Me.rowUsdPrice.Properties.Format.FormatType = DevExpress.Utils.FormatType.Custom
        Me.rowUsdPrice.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowGoodUsed
        '
        Me.rowGoodUsed.Height = 50
        Me.rowGoodUsed.Name = "rowGoodUsed"
        Me.rowGoodUsed.Properties.Caption = "21. Конечное использование"
        Me.rowGoodUsed.Properties.FieldName = "goodUsed"
        Me.rowGoodUsed.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowGoodUsed.Properties.RowEdit = Me.RepositoryItemMemoEdit1
        '
        'catBank
        '
        Me.catBank.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowBankName, Me.rowBankAddress, Me.rowBankAccount})
        Me.catBank.Name = "catBank"
        Me.catBank.OptionsRow.AllowSize = False
        Me.catBank.Properties.Caption = "22. Банк заявителя"
        Me.catBank.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowBankName
        '
        Me.rowBankName.Name = "rowBankName"
        Me.rowBankName.OptionsRow.AllowSize = False
        Me.rowBankName.Properties.Caption = "Наименование"
        Me.rowBankName.Properties.FieldName = "bankName"
        Me.rowBankName.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowBankAddress
        '
        Me.rowBankAddress.Name = "rowBankAddress"
        Me.rowBankAddress.OptionsRow.AllowSize = False
        Me.rowBankAddress.Properties.Caption = "Адрес"
        Me.rowBankAddress.Properties.FieldName = "bankAddress"
        Me.rowBankAddress.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowBankAccount
        '
        Me.rowBankAccount.Name = "rowBankAccount"
        Me.rowBankAccount.OptionsRow.AllowSize = False
        Me.rowBankAccount.Properties.Caption = "Номер счета"
        Me.rowBankAccount.Properties.FieldName = "bankAccount"
        Me.rowBankAccount.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowLicBasis
        '
        Me.rowLicBasis.Height = 50
        Me.rowLicBasis.Name = "rowLicBasis"
        Me.rowLicBasis.Properties.Caption = "23. Основание для запроса лицензии"
        Me.rowLicBasis.Properties.FieldName = "licBasis"
        Me.rowLicBasis.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowLicBasis.Properties.RowEdit = Me.RepositoryItemMemoEdit1
        '
        'rowLaw
        '
        Me.rowLaw.Name = "rowLaw"
        Me.rowLaw.OptionsRow.AllowSize = False
        Me.rowLaw.Properties.Caption = "24. Код списка"
        Me.rowLaw.Properties.FieldName = "lawId"
        Me.rowLaw.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowLaw.Properties.RowEdit = Me.LawCaptionRepositoryItemLookUpEdit
        '
        'rowLawPos
        '
        Me.rowLawPos.Name = "rowLawPos"
        Me.rowLawPos.OptionsRow.AllowSize = False
        Me.rowLawPos.Properties.Caption = "25. Позиция списка"
        Me.rowLawPos.Properties.FieldName = "lawPos"
        Me.rowLawPos.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowCustom
        '
        Me.rowCustom.Name = "rowCustom"
        Me.rowCustom.OptionsRow.AllowSize = False
        Me.rowCustom.Properties.Caption = "26. Таможенный орган Российской Федерации"
        Me.rowCustom.Properties.FieldName = "customName"
        Me.rowCustom.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowExtraInfo
        '
        Me.rowExtraInfo.Height = 50
        Me.rowExtraInfo.Name = "rowExtraInfo"
        Me.rowExtraInfo.Properties.Caption = "27. Дополнительная информация"
        Me.rowExtraInfo.Properties.FieldName = "extraInfo"
        Me.rowExtraInfo.Properties.Padding = New System.Windows.Forms.Padding(0)
        Me.rowExtraInfo.Properties.RowEdit = Me.RepositoryItemMemoEdit1
        '
        'catPerson
        '
        Me.catPerson.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPersonName, Me.rowPersonJob, Me.rowPersonPhone})
        Me.catPerson.Name = "catPerson"
        Me.catPerson.OptionsRow.AllowSize = False
        Me.catPerson.Properties.Caption = "28. Уполномоченное лицо заявителя"
        Me.catPerson.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowPersonName
        '
        Me.rowPersonName.Name = "rowPersonName"
        Me.rowPersonName.OptionsRow.AllowSize = False
        Me.rowPersonName.Properties.Caption = "Ф.И.О."
        Me.rowPersonName.Properties.FieldName = "personName"
        Me.rowPersonName.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowPersonJob
        '
        Me.rowPersonJob.Name = "rowPersonJob"
        Me.rowPersonJob.OptionsRow.AllowSize = False
        Me.rowPersonJob.Properties.Caption = "Должность"
        Me.rowPersonJob.Properties.FieldName = "personJob"
        Me.rowPersonJob.Properties.Padding = New System.Windows.Forms.Padding(0)
        '
        'rowPersonPhone
        '
        Me.rowPersonPhone.Name = "rowPersonPhone"
        Me.rowPersonPhone.OptionsRow.AllowSize = False
        Me.rowPersonPhone.Properties.Caption = "Контактный телефон/факс"
        Me.rowPersonPhone.Properties.FieldName = "personPhone"
        Me.rowPersonPhone.Properties.Padding = New System.Windows.Forms.Padding(0)
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlItem1})
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
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(930, 40)
        Me.CaptionSimpleLabelItem.Text = "Данные для оформления лицензии ФСТЭК / разрешения КЭК"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LicenseDataGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(930, 600)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LicenseDataChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "LicenseDataChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LicenseDataGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LicTypeRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IncotermsRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CountryRepositoryItemCheckedComboBoxEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LawCaptionRepositoryItemLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BayerRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeveloperRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EndUserRepositoryItemButtonEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        'MyBase.IsDataLoaded = False
        ''
        '' Доступность элементов управления на редактирование 
        ''
        'Dim bLock As Boolean = Not P.WorkEditableForExpert
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        LicenseDataGridControl.CloseEditor()
        LicenseDataGridControl.UpdateFocusedRecord()
    End Sub

#End Region

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.PlaneUserControl
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Friend Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.LicenseData
        LicTypeRepositoryItemLookUpEdit.DataSource = P.Work.LicenseTypeHandbookTable
        IncotermsRepositoryItemLookUpEdit.DataSource = P.Work.IncotermsHandbookTable
        CountryRepositoryItemLookUpEdit.DataSource = P.Work.CountryHandbookTable
        CountryRepositoryItemCheckedComboBoxEdit.DataSource = P.Work.CountryHandbookTable
        CurrencyRepositoryItemLookUpEdit.DataSource = P.Work.CurrencyHandbookTable
        PaymentRepositoryItemLookUpEdit.DataSource = P.Work.PaymentHandbookTable
        UnitRepositoryItemLookUpEdit.DataSource = P.Work.UnitHandbookTable
        LawCaptionRepositoryItemLookUpEdit.DataSource = P.Work.LawCaptionHandbookTable

        LicenseDataGridControl.DataSource = P.Work.ARow

    End Sub


    Private Sub ClientRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ClientRepositoryItemButtonEdit.ButtonClick
        If Cprp.DxCommon.Messages.ShowQuestion("Подставить реквизиты заказчика услуги?") <> DialogResult.Yes Then Exit Sub
        With P.Work.ARow
            .Item("clientName") = P.Work("clientName")
            .Item("clientAddress") = P.Work("clientAddress")
        End With
        LicenseDataGridControl.RefreshDataSource()
        LicenseDataGridControl.CloseEditor()
    End Sub

    Private Sub ByerRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BayerRepositoryItemButtonEdit.ButtonClick
        LicenseDataGridControl.CloseEditor()
        Using T As DataTable = Cprp.DxData.Member.Common.Find(Member.MemberKind.IsSupplyNus, P.Work.Connection)
            If T Is Nothing OrElse T.Rows.Count = 0 Then Exit Sub
            With P.Work.ARow
                .Item("bayerName") = T(0)("nameLong")
                .Item("bayerAddress") = T(0)("addressLegalFull")
                .Item("bayerCountryId") = T(0)("addressLegalCountryId")
            End With
        End Using
        LicenseDataGridControl.RefreshDataSource()
    End Sub

    Private Sub DeveloperRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles DeveloperRepositoryItemButtonEdit.ButtonClick
        LicenseDataGridControl.CloseEditor()
        Using T As DataTable = Cprp.DxData.Member.Common.Find(Member.MemberKind.IsDeveloper, P.Work.Connection)
            If T Is Nothing OrElse T.Rows.Count = 0 Then Exit Sub
            With P.Work.ARow
                .Item("devName") = T(0)("nameLong")
                .Item("devAddress") = T(0)("addressLegalFull")
                .Item("devCountryId") = T(0)("addressLegalCountryId")
            End With
        End Using
        LicenseDataGridControl.RefreshDataSource()
    End Sub

    Private Sub EndUserRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles EndUserRepositoryItemButtonEdit.ButtonClick
        LicenseDataGridControl.CloseEditor()
        Using T As DataTable = Cprp.DxData.Member.Common.Find(Member.MemberKind.IsSupplyEnd, P.Work.Connection)
            If T Is Nothing OrElse T.Rows.Count = 0 Then Exit Sub
            With P.Work.ARow
                .Item("endName") = T(0)("nameLong")
                .Item("endAddress") = T(0)("addressLegalFull")
                .Item("endCountryId") = T(0)("addressLegalCountryId")
            End With
        End Using
        LicenseDataGridControl.RefreshDataSource()
    End Sub

End Class
