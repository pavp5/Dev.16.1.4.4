Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Решение по анализу"
''' </summary>
Friend Class SummaryChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Friend WithEvents SplitterItem1 As DevExpress.XtraLayout.SplitterItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RiskLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SummaryLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents PermitCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PermitLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents EmbargoCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents EmbargoLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OutputCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents OutputLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SummaryMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents FreedomCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LicenseCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents FreedomLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LicenseLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RiskMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents DecreeCheckEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DecreeLabelControl As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SummaryChildControl))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.DecreeLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.DecreeCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.RiskMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LicenseLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.FreedomLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.LicenseCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.FreedomCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.SummaryMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.OutputLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.OutputCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.EmbargoLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.EmbargoCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.PermitLabelControl = New DevExpress.XtraEditors.LabelControl()
        Me.PermitCheckEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SummaryLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DescriptionLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RiskLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplitterItem1 = New DevExpress.XtraLayout.SplitterItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.DecreeCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LicenseCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FreedomCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutputCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmbargoCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PermitCheckEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RiskLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.DecreeLabelControl)
        Me.LayoutControl1.Controls.Add(Me.DecreeCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.RiskMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.LicenseLabelControl)
        Me.LayoutControl1.Controls.Add(Me.FreedomLabelControl)
        Me.LayoutControl1.Controls.Add(Me.LicenseCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.FreedomCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.SummaryMemoEdit)
        Me.LayoutControl1.Controls.Add(Me.OutputLabelControl)
        Me.LayoutControl1.Controls.Add(Me.OutputCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.EmbargoLabelControl)
        Me.LayoutControl1.Controls.Add(Me.EmbargoCheckEdit)
        Me.LayoutControl1.Controls.Add(Me.PermitLabelControl)
        Me.LayoutControl1.Controls.Add(Me.PermitCheckEdit)
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
        'DecreeLabelControl
        '
        Me.DecreeLabelControl.AllowHtmlString = True
        Me.DecreeLabelControl.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.DecreeLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.DecreeLabelControl.Location = New System.Drawing.Point(53, 492)
        Me.DecreeLabelControl.Name = "DecreeLabelControl"
        Me.DecreeLabelControl.Size = New System.Drawing.Size(848, 52)
        Me.DecreeLabelControl.StyleController = Me.LayoutControl1
        Me.DecreeLabelControl.TabIndex = 29
        Me.DecreeLabelControl.Text = "Для решения вопроса о возможности осуществления внешнеэкономической операции <u>н" & _
    "еобходимо обратиться в Федеральную службу по техническому и экспортному контролю" & _
    "</u>."
        Me.DecreeLabelControl.Visible = False
        '
        'DecreeCheckEdit
        '
        Me.DecreeCheckEdit.AutoSizeInLayoutControl = True
        Me.DecreeCheckEdit.Location = New System.Drawing.Point(28, 492)
        Me.DecreeCheckEdit.Name = "DecreeCheckEdit"
        Me.DecreeCheckEdit.Properties.Caption = "DecreeCheckEdit"
        Me.DecreeCheckEdit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.DecreeCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DecreeCheckEdit.Properties.RadioGroupIndex = 1
        Me.DecreeCheckEdit.Size = New System.Drawing.Size(19, 19)
        Me.DecreeCheckEdit.StyleController = Me.LayoutControl1
        Me.DecreeCheckEdit.TabIndex = 28
        Me.DecreeCheckEdit.TabStop = False
        '
        'RiskMemoEdit
        '
        Me.RiskMemoEdit.Location = New System.Drawing.Point(28, 20)
        Me.RiskMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.RiskMemoEdit.Name = "RiskMemoEdit"
        Me.RiskMemoEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.RiskMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.RiskMemoEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.RiskMemoEdit.Size = New System.Drawing.Size(873, 45)
        Me.RiskMemoEdit.StyleController = Me.LayoutControl1
        Me.RiskMemoEdit.TabIndex = 27
        '
        'LicenseLabelControl
        '
        Me.LicenseLabelControl.AllowHtmlString = True
        Me.LicenseLabelControl.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LicenseLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LicenseLabelControl.Location = New System.Drawing.Point(52, 225)
        Me.LicenseLabelControl.Name = "LicenseLabelControl"
        Me.LicenseLabelControl.Size = New System.Drawing.Size(850, 52)
        Me.LicenseLabelControl.StyleController = Me.LayoutControl1
        Me.LicenseLabelControl.TabIndex = 26
        Me.LicenseLabelControl.Text = "Для осуществления внешнеэкономической операции <u>требуется лицензия Федеральной " & _
    "службы по техническому и экспортному контролю</u>."
        '
        'FreedomLabelControl
        '
        Me.FreedomLabelControl.AllowHtmlString = True
        Me.FreedomLabelControl.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FreedomLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.FreedomLabelControl.Location = New System.Drawing.Point(52, 139)
        Me.FreedomLabelControl.Name = "FreedomLabelControl"
        Me.FreedomLabelControl.Size = New System.Drawing.Size(850, 78)
        Me.FreedomLabelControl.StyleController = Me.LayoutControl1
        Me.FreedomLabelControl.TabIndex = 25
        Me.FreedomLabelControl.Text = "Для осуществления внешнеэкономической операции <u>лицензия или иное разрешение, п" & _
    "редусмотренное законодательством Российской Федерации в области экспортного конт" & _
    "роля, не требуется</u>."
        '
        'LicenseCheckEdit
        '
        Me.LicenseCheckEdit.AutoSizeInLayoutControl = True
        Me.LicenseCheckEdit.Location = New System.Drawing.Point(28, 226)
        Me.LicenseCheckEdit.Name = "LicenseCheckEdit"
        Me.LicenseCheckEdit.Properties.Caption = "LicenseCheckEdit"
        Me.LicenseCheckEdit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.LicenseCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LicenseCheckEdit.Properties.RadioGroupIndex = 1
        Me.LicenseCheckEdit.Size = New System.Drawing.Size(19, 19)
        Me.LicenseCheckEdit.StyleController = Me.LayoutControl1
        Me.LicenseCheckEdit.TabIndex = 24
        Me.LicenseCheckEdit.TabStop = False
        '
        'FreedomCheckEdit
        '
        Me.FreedomCheckEdit.AutoSizeInLayoutControl = True
        Me.FreedomCheckEdit.Location = New System.Drawing.Point(28, 140)
        Me.FreedomCheckEdit.Name = "FreedomCheckEdit"
        Me.FreedomCheckEdit.Properties.Caption = "FreedomCheckEdit"
        Me.FreedomCheckEdit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.FreedomCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.FreedomCheckEdit.Properties.RadioGroupIndex = 1
        Me.FreedomCheckEdit.Size = New System.Drawing.Size(19, 19)
        Me.FreedomCheckEdit.StyleController = Me.LayoutControl1
        Me.FreedomCheckEdit.TabIndex = 23
        Me.FreedomCheckEdit.TabStop = False
        '
        'SummaryMemoEdit
        '
        Me.SummaryMemoEdit.Location = New System.Drawing.Point(28, 604)
        Me.SummaryMemoEdit.Name = "SummaryMemoEdit"
        Me.SummaryMemoEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.SummaryMemoEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.SummaryMemoEdit.Properties.ShowNullValuePromptWhenFocused = True
        Me.SummaryMemoEdit.Size = New System.Drawing.Size(873, 28)
        Me.SummaryMemoEdit.StyleController = Me.LayoutControl1
        Me.SummaryMemoEdit.TabIndex = 22
        '
        'OutputLabelControl
        '
        Me.OutputLabelControl.AllowHtmlString = True
        Me.OutputLabelControl.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.OutputLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.OutputLabelControl.Location = New System.Drawing.Point(52, 405)
        Me.OutputLabelControl.Name = "OutputLabelControl"
        Me.OutputLabelControl.Size = New System.Drawing.Size(850, 78)
        Me.OutputLabelControl.StyleController = Me.LayoutControl1
        Me.OutputLabelControl.TabIndex = 21
        Me.OutputLabelControl.Text = resources.GetString("OutputLabelControl.Text")
        '
        'OutputCheckEdit
        '
        Me.OutputCheckEdit.AutoSizeInLayoutControl = True
        Me.OutputCheckEdit.Location = New System.Drawing.Point(28, 406)
        Me.OutputCheckEdit.Name = "OutputCheckEdit"
        Me.OutputCheckEdit.Properties.Caption = "OutputCheckEdit"
        Me.OutputCheckEdit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.OutputCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OutputCheckEdit.Properties.RadioGroupIndex = 1
        Me.OutputCheckEdit.Size = New System.Drawing.Size(19, 19)
        Me.OutputCheckEdit.StyleController = Me.LayoutControl1
        Me.OutputCheckEdit.TabIndex = 20
        Me.OutputCheckEdit.TabStop = False
        '
        'EmbargoLabelControl
        '
        Me.EmbargoLabelControl.AllowHtmlString = True
        Me.EmbargoLabelControl.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.EmbargoLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.EmbargoLabelControl.Location = New System.Drawing.Point(52, 345)
        Me.EmbargoLabelControl.Name = "EmbargoLabelControl"
        Me.EmbargoLabelControl.Size = New System.Drawing.Size(850, 52)
        Me.EmbargoLabelControl.StyleController = Me.LayoutControl1
        Me.EmbargoLabelControl.TabIndex = 18
        Me.EmbargoLabelControl.Text = "На внешнеэкономическую операцию <u>распространяется действие специальных экономич" & _
    "еских мер</u>."
        '
        'EmbargoCheckEdit
        '
        Me.EmbargoCheckEdit.AutoSizeInLayoutControl = True
        Me.EmbargoCheckEdit.Location = New System.Drawing.Point(28, 346)
        Me.EmbargoCheckEdit.Name = "EmbargoCheckEdit"
        Me.EmbargoCheckEdit.Properties.Caption = "EmbargoCheckEdit"
        Me.EmbargoCheckEdit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.EmbargoCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.EmbargoCheckEdit.Properties.RadioGroupIndex = 1
        Me.EmbargoCheckEdit.Size = New System.Drawing.Size(19, 19)
        Me.EmbargoCheckEdit.StyleController = Me.LayoutControl1
        Me.EmbargoCheckEdit.TabIndex = 17
        Me.EmbargoCheckEdit.TabStop = False
        '
        'PermitLabelControl
        '
        Me.PermitLabelControl.AllowHtmlString = True
        Me.PermitLabelControl.Appearance.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PermitLabelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.PermitLabelControl.Location = New System.Drawing.Point(52, 285)
        Me.PermitLabelControl.Name = "PermitLabelControl"
        Me.PermitLabelControl.Size = New System.Drawing.Size(850, 52)
        Me.PermitLabelControl.StyleController = Me.LayoutControl1
        Me.PermitLabelControl.TabIndex = 13
        Me.PermitLabelControl.Text = "Для осуществления внешнеэкономической операции <u>требуется разрешение Комиссии п" & _
    "о экспортному контролю Российской Федерации</u>."
        '
        'PermitCheckEdit
        '
        Me.PermitCheckEdit.AutoSizeInLayoutControl = True
        Me.PermitCheckEdit.Location = New System.Drawing.Point(28, 286)
        Me.PermitCheckEdit.Name = "PermitCheckEdit"
        Me.PermitCheckEdit.Properties.Caption = "PermitCheckEdit"
        Me.PermitCheckEdit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
        Me.PermitCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PermitCheckEdit.Properties.RadioGroupIndex = 1
        Me.PermitCheckEdit.Size = New System.Drawing.Size(19, 19)
        Me.PermitCheckEdit.StyleController = Me.LayoutControl1
        Me.PermitCheckEdit.TabIndex = 12
        Me.PermitCheckEdit.TabStop = False
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.SummaryLayoutControlGroup, Me.DescriptionLayoutControlGroup, Me.RiskLayoutControlGroup, Me.SplitterItem1})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, -72)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 0)
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(929, 722)
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
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(909, 40)
        Me.CaptionSimpleLabelItem.Text = "РЕШЕНИЕ ПО АНАЛИЗУ"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(100, 30)
        '
        'SummaryLayoutControlGroup
        '
        Me.SummaryLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.SummaryLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem2, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.SummaryLayoutControlGroup.Location = New System.Drawing.Point(0, 160)
        Me.SummaryLayoutControlGroup.Name = "SummaryLayoutControlGroup"
        Me.SummaryLayoutControlGroup.Size = New System.Drawing.Size(909, 464)
        Me.SummaryLayoutControlGroup.Text = "Решение по анализу<color='red'>*</color>"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PermitCheckEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 146)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(25, 60)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.PermitLabelControl
        Me.LayoutControlItem3.Location = New System.Drawing.Point(25, 146)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 6)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(854, 60)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.EmbargoCheckEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 206)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(25, 60)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.EmbargoLabelControl
        Me.LayoutControlItem6.Location = New System.Drawing.Point(25, 206)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 6)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(854, 60)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.OutputCheckEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 266)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(25, 86)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.OutputLabelControl
        Me.LayoutControlItem9.Location = New System.Drawing.Point(25, 266)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 6)
        Me.LayoutControlItem9.Size = New System.Drawing.Size(854, 86)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.FreedomCheckEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(25, 86)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.LicenseCheckEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 86)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(25, 60)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.FreedomLabelControl
        Me.LayoutControlItem10.Location = New System.Drawing.Point(25, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 6)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(854, 86)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.LicenseLabelControl
        Me.LayoutControlItem11.Location = New System.Drawing.Point(25, 86)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 6)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(854, 60)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.DecreeCheckEdit
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 352)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(25, 58)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.DecreeLabelControl
        Me.LayoutControlItem14.Location = New System.Drawing.Point(25, 352)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(854, 58)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'DescriptionLayoutControlGroup
        '
        Me.DescriptionLayoutControlGroup.AllowHtmlStringInCaption = True
        Me.DescriptionLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.DescriptionLayoutControlGroup.Location = New System.Drawing.Point(0, 624)
        Me.DescriptionLayoutControlGroup.Name = "DescriptionLayoutControlGroup"
        Me.DescriptionLayoutControlGroup.Size = New System.Drawing.Size(909, 88)
        Me.DescriptionLayoutControlGroup.Text = "Выводы идентификационной экспертизы<color='red'>*</color>"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SummaryMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(879, 34)
        Me.LayoutControlItem5.Text = "Выводы"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'RiskLayoutControlGroup
        '
        Me.RiskLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12})
        Me.RiskLayoutControlGroup.Location = New System.Drawing.Point(0, 40)
        Me.RiskLayoutControlGroup.Name = "RiskLayoutControlGroup"
        Me.RiskLayoutControlGroup.Size = New System.Drawing.Size(909, 105)
        Me.RiskLayoutControlGroup.Text = "Анализ выявленных рисков"
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.RiskMemoEdit
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(879, 51)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'SplitterItem1
        '
        Me.SplitterItem1.AllowHotTrack = True
        Me.SplitterItem1.Location = New System.Drawing.Point(0, 145)
        Me.SplitterItem1.Name = "SplitterItem1"
        Me.SplitterItem1.Size = New System.Drawing.Size(909, 15)
        '
        'SummaryChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "SummaryChildControl"
        Me.Size = New System.Drawing.Size(950, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.DecreeCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LicenseCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FreedomCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutputCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmbargoCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PermitCheckEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SummaryLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RiskLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitterItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "ChildUserControl"

    Friend Overrides Sub DataRead()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.IsDataLoaded = False
        '
        ' Элементы управления
        '        
        RiskMemoEdit.EditValue = P.Work.ARow("summaryRisk")
        '
        ' Идентификатор выводов экспертизы
        '
        If Not IsDBNull(P.Work.ARow("summaryId")) Then
            Select Case CType(P.Work.ARow("summaryId"), Cprp.DxData.Work.WorkSummary)
                Case DxData.Work.WorkSummary.IsFreedom : FreedomCheckEdit.Checked = True    ' вызов RefreshMe
                Case DxData.Work.WorkSummary.IsLicense : LicenseCheckEdit.Checked = True    ' - // -
                Case DxData.Work.WorkSummary.IsPermit : PermitCheckEdit.Checked = True      ' - // -
                Case DxData.Work.WorkSummary.IsEmbargo : EmbargoCheckEdit.Checked = True    ' - // -
                Case DxData.Work.WorkSummary.IsOutput : OutputCheckEdit.Checked = True      ' - // -
                Case DxData.Work.WorkSummary.IsDecree : DecreeCheckEdit.Checked = True      ' - // -
            End Select
        End If
        '
        ' Выводы экспертизы
        '
        SummaryMemoEdit.EditValue = P.Work.ARow("summaryText")
        '
        ' Доступность элементов на редактирование
        '
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not P.WorkEditableForExpert Then Exit Sub
        With P.Work.ARow
            '
            ' Данные объекта
            '
            .Item("summaryRisk") = C2.DbText(RiskMemoEdit.EditValue)
            .Item("summaryText") = C2.DbText(SummaryMemoEdit.EditValue)
            '
            ' Идентификатор выводов экспертизы
            '
            If FreedomCheckEdit.Checked Then
                .Item("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsFreedom)
            ElseIf LicenseCheckEdit.Checked Then
                .Item("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsLicense)
            ElseIf PermitCheckEdit.Checked Then
                .Item("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsPermit)
            ElseIf EmbargoCheckEdit.Checked Then
                .Item("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsEmbargo)
            ElseIf OutputCheckEdit.Checked Then
                .Item("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsOutput)
            ElseIf DecreeCheckEdit.Checked Then
                .Item("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsDecree)
            End If
            .AcceptChanges()
        End With
    End Sub

    Private Sub LockUpdate()
        '
        ' Переменные
        '
        Dim bLock As Boolean = Not P.WorkEditableForExpert                  ' Работа не доступна эксперту для редактирования
        '
        ' Элементы управления
        '
        FreedomCheckEdit.ReadOnly = bLock
        LicenseCheckEdit.ReadOnly = bLock
        PermitCheckEdit.ReadOnly = bLock
        EmbargoCheckEdit.ReadOnly = bLock
        OutputCheckEdit.ReadOnly = bLock
        DecreeCheckEdit.ReadOnly = bLock
        RiskMemoEdit.Properties.ReadOnly = bLock
        If Not SummaryMemoEdit.Properties.ReadOnly Then SummaryMemoEdit.Properties.ReadOnly = bLock
    End Sub

#End Region


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ParentControl As WorkUserControl)
        MyBase.New(ParentControl)
        InitializeComponent()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        MyBase.Content = ContentEnum.Summary
    End Sub

    ''' <summary>
    ''' Переписать содержимое элементов управления
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshMe()
        FreedomLabelControl.Text = _
            "Для осуществления внешнеэкономической операции <u>лицензия или иное разрешение, предусмотренное законодательством Российской Федерации в области экспортного контроля, не требуется</u>."
        LicenseLabelControl.Text = _
            "Для осуществления внешнеэкономической операции <u>требуется лицензия Федеральной службы по техническому и экспортному контролю</u>."
        PermitLabelControl.Text = _
            "Для осуществления внешнеэкономической операции <u>требуется разрешение Комиссии по экспортному контролю Российской Федерации</u>."
        EmbargoLabelControl.Text = _
            "На внешнеэкономическую операцию, указанную в настоящем заключении, <u>распространяется действие специальных экономических или принудительных мер</u>"
        OutputLabelControl.Text = _
            "Для осуществления внешнеэкономической операции с <u>товарами и продуктами научно-технической деятельности, включенными в контрольные списки</u>, <u>лицензия Федеральной службы  по техническому и экспортному контролю не требуется</u>."
        DecreeLabelControl.Text = _
            "Для решения вопроса о возможности осуществления внешнеэкономической операции <u>необходимо обратиться в Федеральную службу по техническому и экспортному контролю</u>."
        If FreedomCheckEdit.Checked Then
            FreedomLabelControl.Text = String.Format("<b>{0}</b>", FreedomLabelControl.Text)
            SummaryMemoEdit.Text = _
                "Для осуществления внешнеэкономической операции, указанной в настоящем заключении, лицензия или иное разрешение, предусмотренное законодательством Российской Федерации в области экспортного контроля, не требуется."
            SummaryMemoEdit.Properties.ReadOnly = True
            RiskMemoEdit.Properties.NullValuePrompt = Nothing
        ElseIf LicenseCheckEdit.Checked Then
            LicenseLabelControl.Text = String.Format("<b>{0}</b>", LicenseLabelControl.Text)
            SummaryMemoEdit.Text = _
                "Для осуществления внешнеэкономической операции, указанной в настоящем заключении, требуется лицензия Федеральной службы по техническому и экспортному контролю."
            SummaryMemoEdit.Properties.ReadOnly = True
            RiskMemoEdit.Properties.NullValuePrompt = Nothing
        ElseIf PermitCheckEdit.Checked Then
            PermitLabelControl.Text = String.Format("<b>{0}</b>", PermitLabelControl.Text)
            SummaryMemoEdit.Text = _
                "Для осуществления внешнеэкономической операции, указанной в настоящем заключении, требуется разрешение Комиссии по экспортному контролю Российской Федерации."
            SummaryMemoEdit.Properties.ReadOnly = True
            RiskMemoEdit.Properties.NullValuePrompt = "[обязательное поле]"
        ElseIf EmbargoCheckEdit.Checked Then
            EmbargoLabelControl.Text = String.Format("<b>{0}</b>", EmbargoLabelControl.Text)
            SummaryMemoEdit.Text = _
                "На внешнеэкономическую операцию, указанную в настоящем заключении, распространяется действие запрета, установленного " & _
                "[ УКАЖИТЕ НАИМЕНОВАНИЯ, НОМЕРА И ДАТЫ ДОКУМЕНТОВ, УСТАНАВЛИВАЮЩХ ДЕЙСТВИЕ СПЕЦИАЛЬНЫХ ЭКОНОМИЧЕСКИХ ИЛИ ПРИНУДИТЕЛЬНЫХ МЕР ]."
            SummaryMemoEdit.Properties.ReadOnly = False
            RiskMemoEdit.Properties.NullValuePrompt = Nothing
        ElseIf OutputCheckEdit.Checked Then
            OutputLabelControl.Text = String.Format("<b>{0}</b>", OutputLabelControl.Text)
            SummaryMemoEdit.Text = _
                "Идентифицируемые товары и идентифицируемые продукты научно-технической деятельности, указанные в настоящем заключении, соответствуют товарам и  технологиям, включенным в контрольные списки. Вместе с тем для осуществления данной внешнеэкономической операции в соответствии с " & _
                "[ УКАЖИТЕ НАИМЕНОВАНИЕ, НОМЕР И ДАТУ ДОКУМЕНТА, КОТОРЫМ ПРЕДУСМОТРЕНЫ ИЗЪЯТИЯ ИЗ РЕЖИМА ЛИЦЕНЗИРОВАНИЯ ] " & _
                "лицензия Федеральной службы  по техническому и экспортному контролю не требуется."
            SummaryMemoEdit.Properties.ReadOnly = False
            RiskMemoEdit.Properties.NullValuePrompt = Nothing
        ElseIf DecreeCheckEdit.Checked Then
            DecreeLabelControl.Text = String.Format("<b>{0}</b>", DecreeLabelControl.Text)
            SummaryMemoEdit.Text = _
                "[ УКАЖИТЕ ПРИЧИНЫ НЕОБХОДИМОСТИ ОБРАЩЕНИЯ В ФСТЭК ] " & vbCrLf & _
                "Для решения вопроса о возможности осуществления внешнеэкономической операции необходимо обратиться в Федеральную службу по техническому и экспортному контролю."
            SummaryMemoEdit.Properties.ReadOnly = False
            RiskMemoEdit.Properties.NullValuePrompt = Nothing
        Else
            SummaryMemoEdit.Text = Nothing
            SummaryMemoEdit.Properties.ReadOnly = True
        End If
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub FreedomCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles FreedomCheckEdit.CheckedChanged
        RefreshMe()
    End Sub

    Private Sub LicenseCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles LicenseCheckEdit.CheckedChanged
        RefreshMe()
    End Sub

    Private Sub PermitCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles PermitCheckEdit.CheckedChanged
        RefreshMe()
    End Sub

    Private Sub EmbargoCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles EmbargoCheckEdit.CheckedChanged
        RefreshMe()
    End Sub

    Private Sub OutputCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles OutputCheckEdit.CheckedChanged
        RefreshMe()
    End Sub

    Private Sub DecreeCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles DecreeCheckEdit.CheckedChanged
        RefreshMe()
    End Sub

    Private Sub RiskMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles RiskMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub SummaryMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles SummaryMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

End Class
