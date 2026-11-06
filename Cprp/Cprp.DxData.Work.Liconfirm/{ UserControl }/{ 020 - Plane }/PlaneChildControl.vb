Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "План работы"
''' </summary>
Friend Class PlaneChildControl : Inherits ChildUserControl

#Region "InitializeComponent"

    Private components As System.ComponentModel.IContainer
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CommentLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CaptionSimpleLabelItem As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents RootLayoutControlGroup As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents CommentMemoEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TypeLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ExpertTermDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TotalWorkSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents InfCountSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents MatCountSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SendQueryLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AddWorkCountSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LangCountSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UrgencyLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ProfileLookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GoodCountSpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ComplexitySpinEdit As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FreeWorkookUpEdit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl

    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.FreeWorkookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.ComplexitySpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.GoodCountSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.ProfileLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.UrgencyLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.LangCountSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.AddWorkCountSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.SendQueryLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.ExpertTermDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.TotalWorkSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.InfCountSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.MatCountSpinEdit = New DevExpress.XtraEditors.SpinEdit()
        Me.TypeLookUpEdit = New DevExpress.XtraEditors.LookUpEdit()
        Me.CommentMemoEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.RootLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.CaptionSimpleLabelItem = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CommentLayoutControlGroup = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.FreeWorkookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComplexitySpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProfileLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UrgencyLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LangCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddWorkCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SendQueryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpertTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalWorkSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MatCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommentLayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl1.Appearance.Control.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.Control.Options.UseFont = True
        Me.LayoutControl1.Appearance.ControlDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LayoutControl1.Appearance.ControlDropDown.Options.UseFont = True
        Me.LayoutControl1.Controls.Add(Me.FreeWorkookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.ComplexitySpinEdit)
        Me.LayoutControl1.Controls.Add(Me.GoodCountSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.ProfileLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.UrgencyLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.LangCountSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.AddWorkCountSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.SendQueryLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.ExpertTermDateEdit)
        Me.LayoutControl1.Controls.Add(Me.TotalWorkSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.InfCountSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.MatCountSpinEdit)
        Me.LayoutControl1.Controls.Add(Me.TypeLookUpEdit)
        Me.LayoutControl1.Controls.Add(Me.CommentMemoEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(530, 419, 250, 350)
        Me.LayoutControl1.OptionsFocus.AllowFocusGroups = False
        Me.LayoutControl1.OptionsFocus.AllowFocusTabbedGroups = False
        Me.LayoutControl1.Root = Me.RootLayoutControlGroup
        Me.LayoutControl1.Size = New System.Drawing.Size(1150, 650)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'FreeWorkookUpEdit
        '
        Me.FreeWorkookUpEdit.Location = New System.Drawing.Point(501, 475)
        Me.FreeWorkookUpEdit.Name = "FreeWorkookUpEdit"
        Me.FreeWorkookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FreeWorkookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.FreeWorkookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FreeWorkookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.FreeWorkookUpEdit.Properties.DisplayMember = "name"
        Me.FreeWorkookUpEdit.Properties.DropDownRows = 2
        Me.FreeWorkookUpEdit.Properties.NullText = ""
        Me.FreeWorkookUpEdit.Properties.ShowFooter = False
        Me.FreeWorkookUpEdit.Properties.ShowHeader = False
        Me.FreeWorkookUpEdit.Properties.ValueMember = "boolValue"
        Me.FreeWorkookUpEdit.Size = New System.Drawing.Size(598, 32)
        Me.FreeWorkookUpEdit.StyleController = Me.LayoutControl1
        Me.FreeWorkookUpEdit.TabIndex = 38
        '
        'ComplexitySpinEdit
        '
        Me.ComplexitySpinEdit.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ComplexitySpinEdit.Location = New System.Drawing.Point(501, 437)
        Me.ComplexitySpinEdit.Name = "ComplexitySpinEdit"
        Me.ComplexitySpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ComplexitySpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ComplexitySpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComplexitySpinEdit.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.ComplexitySpinEdit.Properties.Mask.EditMask = "n1"
        Me.ComplexitySpinEdit.Properties.MaxValue = New Decimal(New Integer() {2, 0, 0, 0})
        Me.ComplexitySpinEdit.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ComplexitySpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.ComplexitySpinEdit.StyleController = Me.LayoutControl1
        Me.ComplexitySpinEdit.TabIndex = 37
        '
        'GoodCountSpinEdit
        '
        Me.GoodCountSpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.GoodCountSpinEdit.Location = New System.Drawing.Point(501, 133)
        Me.GoodCountSpinEdit.Name = "GoodCountSpinEdit"
        Me.GoodCountSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.GoodCountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GoodCountSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GoodCountSpinEdit.Properties.IsFloatValue = False
        Me.GoodCountSpinEdit.Properties.Mask.EditMask = "n0"
        Me.GoodCountSpinEdit.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.GoodCountSpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.GoodCountSpinEdit.StyleController = Me.LayoutControl1
        Me.GoodCountSpinEdit.TabIndex = 36
        '
        'ProfileLookUpEdit
        '
        Me.ProfileLookUpEdit.Location = New System.Drawing.Point(501, 605)
        Me.ProfileLookUpEdit.Name = "ProfileLookUpEdit"
        Me.ProfileLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ProfileLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.ProfileLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ProfileLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.ProfileLookUpEdit.Properties.DisplayMember = "name"
        Me.ProfileLookUpEdit.Properties.DropDownRows = 2
        Me.ProfileLookUpEdit.Properties.NullText = ""
        Me.ProfileLookUpEdit.Properties.ShowFooter = False
        Me.ProfileLookUpEdit.Properties.ShowHeader = False
        Me.ProfileLookUpEdit.Properties.ValueMember = "boolValue"
        Me.ProfileLookUpEdit.Size = New System.Drawing.Size(598, 32)
        Me.ProfileLookUpEdit.StyleController = Me.LayoutControl1
        Me.ProfileLookUpEdit.TabIndex = 35
        '
        'UrgencyLookUpEdit
        '
        Me.UrgencyLookUpEdit.Location = New System.Drawing.Point(501, 399)
        Me.UrgencyLookUpEdit.Name = "UrgencyLookUpEdit"
        Me.UrgencyLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.UrgencyLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.UrgencyLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UrgencyLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.UrgencyLookUpEdit.Properties.DisplayMember = "name"
        Me.UrgencyLookUpEdit.Properties.DropDownRows = 3
        Me.UrgencyLookUpEdit.Properties.NullText = ""
        Me.UrgencyLookUpEdit.Properties.ShowFooter = False
        Me.UrgencyLookUpEdit.Properties.ShowHeader = False
        Me.UrgencyLookUpEdit.Properties.ValueMember = "id"
        Me.UrgencyLookUpEdit.Size = New System.Drawing.Size(598, 32)
        Me.UrgencyLookUpEdit.StyleController = Me.LayoutControl1
        Me.UrgencyLookUpEdit.TabIndex = 34
        '
        'LangCountSpinEdit
        '
        Me.LangCountSpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LangCountSpinEdit.Location = New System.Drawing.Point(501, 247)
        Me.LangCountSpinEdit.Name = "LangCountSpinEdit"
        Me.LangCountSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.LangCountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LangCountSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LangCountSpinEdit.Properties.Increment = New Decimal(New Integer() {30, 0, 0, 0})
        Me.LangCountSpinEdit.Properties.IsFloatValue = False
        Me.LangCountSpinEdit.Properties.Mask.EditMask = "n0"
        Me.LangCountSpinEdit.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.LangCountSpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.LangCountSpinEdit.StyleController = Me.LayoutControl1
        Me.LangCountSpinEdit.TabIndex = 33
        '
        'AddWorkCountSpinEdit
        '
        Me.AddWorkCountSpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.AddWorkCountSpinEdit.Location = New System.Drawing.Point(501, 285)
        Me.AddWorkCountSpinEdit.Name = "AddWorkCountSpinEdit"
        Me.AddWorkCountSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.AddWorkCountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.AddWorkCountSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AddWorkCountSpinEdit.Properties.IsFloatValue = False
        Me.AddWorkCountSpinEdit.Properties.Mask.EditMask = "n0"
        Me.AddWorkCountSpinEdit.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.AddWorkCountSpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.AddWorkCountSpinEdit.StyleController = Me.LayoutControl1
        Me.AddWorkCountSpinEdit.TabIndex = 32
        '
        'SendQueryLookUpEdit
        '
        Me.SendQueryLookUpEdit.Location = New System.Drawing.Point(501, 567)
        Me.SendQueryLookUpEdit.Name = "SendQueryLookUpEdit"
        Me.SendQueryLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.SendQueryLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.SendQueryLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SendQueryLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.SendQueryLookUpEdit.Properties.DisplayMember = "name"
        Me.SendQueryLookUpEdit.Properties.DropDownRows = 2
        Me.SendQueryLookUpEdit.Properties.NullText = ""
        Me.SendQueryLookUpEdit.Properties.ShowFooter = False
        Me.SendQueryLookUpEdit.Properties.ShowHeader = False
        Me.SendQueryLookUpEdit.Properties.ValueMember = "boolValue"
        Me.SendQueryLookUpEdit.Size = New System.Drawing.Size(598, 32)
        Me.SendQueryLookUpEdit.StyleController = Me.LayoutControl1
        Me.SendQueryLookUpEdit.TabIndex = 31
        '
        'ExpertTermDateEdit
        '
        Me.ExpertTermDateEdit.EditValue = Nothing
        Me.ExpertTermDateEdit.Location = New System.Drawing.Point(501, 361)
        Me.ExpertTermDateEdit.Name = "ExpertTermDateEdit"
        Me.ExpertTermDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExpertTermDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.ExpertTermDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ExpertTermDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI
        Me.ExpertTermDateEdit.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.ExpertTermDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ExpertTermDateEdit.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm"
        Me.ExpertTermDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ExpertTermDateEdit.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm"
        Me.ExpertTermDateEdit.Properties.TouchUIMinuteIncrement = 30
        Me.ExpertTermDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.ExpertTermDateEdit.Size = New System.Drawing.Size(598, 32)
        Me.ExpertTermDateEdit.StyleController = Me.LayoutControl1
        Me.ExpertTermDateEdit.TabIndex = 28
        '
        'TotalWorkSpinEdit
        '
        Me.TotalWorkSpinEdit.EditValue = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotalWorkSpinEdit.Location = New System.Drawing.Point(501, 323)
        Me.TotalWorkSpinEdit.Name = "TotalWorkSpinEdit"
        Me.TotalWorkSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.TotalWorkSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TotalWorkSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TotalWorkSpinEdit.Properties.Increment = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotalWorkSpinEdit.Properties.IsFloatValue = False
        Me.TotalWorkSpinEdit.Properties.Mask.EditMask = "n0"
        Me.TotalWorkSpinEdit.Properties.MaxValue = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.TotalWorkSpinEdit.Properties.MinValue = New Decimal(New Integer() {30, 0, 0, 0})
        Me.TotalWorkSpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.TotalWorkSpinEdit.StyleController = Me.LayoutControl1
        Me.TotalWorkSpinEdit.TabIndex = 27
        '
        'InfCountSpinEdit
        '
        Me.InfCountSpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.InfCountSpinEdit.Location = New System.Drawing.Point(501, 209)
        Me.InfCountSpinEdit.Name = "InfCountSpinEdit"
        Me.InfCountSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.InfCountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.InfCountSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InfCountSpinEdit.Properties.IsFloatValue = False
        Me.InfCountSpinEdit.Properties.Mask.EditMask = "n0"
        Me.InfCountSpinEdit.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.InfCountSpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.InfCountSpinEdit.StyleController = Me.LayoutControl1
        Me.InfCountSpinEdit.TabIndex = 26
        '
        'MatCountSpinEdit
        '
        Me.MatCountSpinEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.MatCountSpinEdit.Location = New System.Drawing.Point(501, 171)
        Me.MatCountSpinEdit.Name = "MatCountSpinEdit"
        Me.MatCountSpinEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.MatCountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.MatCountSpinEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MatCountSpinEdit.Properties.IsFloatValue = False
        Me.MatCountSpinEdit.Properties.Mask.EditMask = "n0"
        Me.MatCountSpinEdit.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.MatCountSpinEdit.Size = New System.Drawing.Size(598, 32)
        Me.MatCountSpinEdit.StyleController = Me.LayoutControl1
        Me.MatCountSpinEdit.TabIndex = 25
        '
        'TypeLookUpEdit
        '
        Me.TypeLookUpEdit.Location = New System.Drawing.Point(501, 95)
        Me.TypeLookUpEdit.Name = "TypeLookUpEdit"
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TypeLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = True
        Me.TypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TypeLookUpEdit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")})
        Me.TypeLookUpEdit.Properties.DisplayMember = "name"
        Me.TypeLookUpEdit.Properties.NullText = ""
        Me.TypeLookUpEdit.Properties.NullValuePrompt = "[обязательное поле]"
        Me.TypeLookUpEdit.Properties.NullValuePromptShowForEmptyValue = True
        Me.TypeLookUpEdit.Properties.ShowFooter = False
        Me.TypeLookUpEdit.Properties.ShowHeader = False
        Me.TypeLookUpEdit.Properties.ValueMember = "id"
        Me.TypeLookUpEdit.Size = New System.Drawing.Size(598, 32)
        Me.TypeLookUpEdit.StyleController = Me.LayoutControl1
        Me.TypeLookUpEdit.TabIndex = 24
        '
        'CommentMemoEdit
        '
        Me.CommentMemoEdit.Location = New System.Drawing.Point(31, 697)
        Me.CommentMemoEdit.MinimumSize = New System.Drawing.Size(0, 45)
        Me.CommentMemoEdit.Name = "CommentMemoEdit"
        Me.CommentMemoEdit.Size = New System.Drawing.Size(1068, 45)
        Me.CommentMemoEdit.StyleController = Me.LayoutControl1
        Me.CommentMemoEdit.TabIndex = 11
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
        Me.RootLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.CaptionSimpleLabelItem, Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.CommentLayoutControlGroup})
        Me.RootLayoutControlGroup.Location = New System.Drawing.Point(0, 0)
        Me.RootLayoutControlGroup.Name = "Root"
        Me.RootLayoutControlGroup.Size = New System.Drawing.Size(1130, 773)
        Me.RootLayoutControlGroup.TextVisible = False
        '
        'CaptionSimpleLabelItem
        '
        Me.CaptionSimpleLabelItem.AllowHotTrack = False
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.ForeColor = System.Drawing.Color.SteelBlue
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseFont = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseForeColor = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.Options.UseTextOptions = True
        Me.CaptionSimpleLabelItem.AppearanceItemCaption.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.CaptionSimpleLabelItem.Location = New System.Drawing.Point(0, 0)
        Me.CaptionSimpleLabelItem.Name = "CaptionSimpleLabelItem"
        Me.CaptionSimpleLabelItem.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 8)
        Me.CaptionSimpleLabelItem.Size = New System.Drawing.Size(1104, 40)
        Me.CaptionSimpleLabelItem.Text = "План работы"
        Me.CaptionSimpleLabelItem.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.CaptionSimpleLabelItem.TextSize = New System.Drawing.Size(50, 30)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem7, Me.LayoutControlItem10, Me.LayoutControlItem12, Me.LayoutControlItem1, Me.LayoutControlItem11, Me.LayoutControlItem2, Me.LayoutControlItem14})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1104, 472)
        Me.LayoutControlGroup1.Text = "Характеристики работы"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.AllowHtmlStringInCaption = True
        Me.LayoutControlItem3.Control = Me.TypeLookUpEdit
        Me.LayoutControlItem3.CustomizationFormText = "Вид работы<color='red'>*</color>"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem3.Text = "Вид работы<color='red'>*</color>"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.AllowHtmlStringInCaption = True
        Me.LayoutControlItem6.Control = Me.MatCountSpinEdit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 76)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem6.Text = "Количество материальных объектов исследования<color='red'>*</color>"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.AllowHtmlStringInCaption = True
        Me.LayoutControlItem8.Control = Me.TotalWorkSpinEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 228)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem8.Text = "Общая трудоемкость (мин.)<color='red'>*</color>"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AllowHtmlStringInCaption = True
        Me.LayoutControlItem9.Control = Me.ExpertTermDateEdit
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 266)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem9.Text = "Срок исполнения<color='red'>*</color>"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.AllowHtmlStringInCaption = True
        Me.LayoutControlItem7.Control = Me.InfCountSpinEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 114)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem7.Text = "Количество информационных объектов исследования<color='red'>*</color>"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.AllowHtmlStringInCaption = True
        Me.LayoutControlItem10.Control = Me.AddWorkCountSpinEdit
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 190)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem10.Text = "Количество дополнительных стран / направлений перемещения<color=red>*</color>"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.AllowHtmlStringInCaption = True
        Me.LayoutControlItem12.Control = Me.UrgencyLookUpEdit
        Me.LayoutControlItem12.CustomizationFormText = "Срочность"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 304)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem12.Text = "Срочность<color=red>*</color>"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.AllowHtmlStringInCaption = True
        Me.LayoutControlItem1.Control = Me.GoodCountSpinEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem1.Text = "Количество товаров по спецификации<color=red>*</color>"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.AllowHtmlStringInCaption = True
        Me.LayoutControlItem11.Control = Me.LangCountSpinEdit
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 152)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem11.Text = "Количество документов на иностранном языке<color=red>*</color>"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ComplexitySpinEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 342)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem2.Text = "Коэффициент за сложность"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.FreeWorkookUpEdit
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 380)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem14.Text = "Без оплаты"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem13})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 512)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1104, 130)
        Me.LayoutControlGroup2.Text = "Мероприятия по работе"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SendQueryLookUpEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem4.Text = "Запрос дополнительной информации"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(467, 18)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.ProfileLookUpEdit
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(1074, 38)
        Me.LayoutControlItem13.Text = "Составление профилей иностранных участников"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(467, 18)
        '
        'CommentLayoutControlGroup
        '
        Me.CommentLayoutControlGroup.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.CommentLayoutControlGroup.Location = New System.Drawing.Point(0, 642)
        Me.CommentLayoutControlGroup.Name = "CommentLayoutControlGroup"
        Me.CommentLayoutControlGroup.Size = New System.Drawing.Size(1104, 105)
        Me.CommentLayoutControlGroup.Text = "Пояснения к плану работ"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CommentMemoEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1074, 51)
        Me.LayoutControlItem5.Text = "Пояснения к плану работ"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'PlaneChildControl
        '
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "PlaneChildControl"
        Me.Size = New System.Drawing.Size(1150, 650)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.FreeWorkookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComplexitySpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProfileLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UrgencyLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LangCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddWorkCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SendQueryLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertTermDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpertTermDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalWorkSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MatCountSpinEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentMemoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RootLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptionSimpleLabelItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommentLayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
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
        MyBase.IsDataLoaded = False
        CaptionSimpleLabelItem.Text = "План работы"
        With P.Work.ARow
            TypeLookUpEdit.EditValue = .Item("typeId")
            GoodCountSpinEdit.EditValue = .Item("goodCount")
            MatCountSpinEdit.EditValue = .Item("matCount")
            InfCountSpinEdit.EditValue = .Item("infCount")
            AddWorkCountSpinEdit.EditValue = .Item("addWorkCount")
            TotalWorkSpinEdit.EditValue = .Item("totalWork")
            ExpertTermDateEdit.EditValue = .Item("expertTerm")
            UrgencyLookUpEdit.EditValue = .Item("urgencyId")
            ComplexitySpinEdit.EditValue = .Item("complexity")
            FreeWorkookUpEdit.EditValue = (CInt(.Item("changeSourceId")) = 4)
            SendQueryLookUpEdit.EditValue = .Item("isSendQuery")
            ProfileLookUpEdit.EditValue = .Item("isMakeProfile")
            LangCountSpinEdit.EditValue = .Item("langCount")
            CommentMemoEdit.EditValue = .Item("planeComment")
        End With
        LockUpdate()
        MyBase.IsDataLoaded = True
    End Sub

    Friend Overrides Sub DataWrite()
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        If Not (P.PlaneEditableForExpert OrElse P.PlaneEditableForLeader) Then Exit Sub
        '
        ' Данные объектов
        '
        With P.Work.ARow
            .Item("typeId") = C2.DbInt(TypeLookUpEdit.EditValue)
            .Item("goodCount") = C2.DbInt(GoodCountSpinEdit.EditValue)
            .Item("matCount") = C2.DbInt(MatCountSpinEdit.EditValue)
            .Item("infCount") = C2.DbInt(InfCountSpinEdit.EditValue)
            .Item("addWorkCount") = C2.DbInt(AddWorkCountSpinEdit.EditValue)
            .Item("totalWork") = C2.DbInt(TotalWorkSpinEdit.EditValue)
            .Item("expertTerm") = C2.DbDate(ExpertTermDateEdit.EditValue)
            .Item("urgencyId") = C2.DbInt(UrgencyLookUpEdit.EditValue)
            .Item("isUrgency") = (CInt(.Item("urgencyId")) > 1)
            .Item("complexity") = CSng(ComplexitySpinEdit.EditValue)
            If CBool(FreeWorkookUpEdit.EditValue) Then .Item("changeSourceId") = 4
            .Item("isSendQuery") = CBool(SendQueryLookUpEdit.EditValue)
            .Item("isMakeProfile") = CBool(ProfileLookUpEdit.EditValue)
            .Item("langCount") = C2.DbInt(LangCountSpinEdit.EditValue)
            .Item("planeComment") = C2.DbText(CommentMemoEdit.EditValue)
            .AcceptChanges()
        End With
    End Sub

    Private Sub LockUpdate()
        Dim bLock As Boolean = Not (P.PlaneEditableForExpert OrElse P.PlaneEditableForLeader)
        TypeLookUpEdit.ReadOnly = bLock
        GoodCountSpinEdit.ReadOnly = bLock
        MatCountSpinEdit.ReadOnly = bLock
        InfCountSpinEdit.ReadOnly = bLock
        AddWorkCountSpinEdit.ReadOnly = bLock
        TotalWorkSpinEdit.ReadOnly = bLock
        ExpertTermDateEdit.ReadOnly = bLock
        UrgencyLookUpEdit.ReadOnly = bLock
        ComplexitySpinEdit.ReadOnly = Not P.PlaneEditableForLeader
        FreeWorkookUpEdit.ReadOnly = Not P.PlaneEditableForLeader
        SendQueryLookUpEdit.ReadOnly = bLock
        ProfileLookUpEdit.ReadOnly = bLock
        LangCountSpinEdit.ReadOnly = bLock
        CommentMemoEdit.ReadOnly = bLock

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
        MyBase.Content = ContentEnum.Plane
        TypeLookUpEdit.Properties.DataSource = P.Work.WorkTypeHandbookTable
        UrgencyLookUpEdit.Properties.DataSource = P.Work.UrgencyHandbookTable
        FreeWorkookUpEdit.Properties.DataSource = New Cprp.DxData.Handbook.YesNoDataTable
        SendQueryLookUpEdit.Properties.DataSource = New Cprp.DxData.Handbook.YesNoDataTable
        ProfileLookUpEdit.Properties.DataSource = New Cprp.DxData.Handbook.YesNoDataTable
    End Sub

    Private Sub TypeLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TypeLookUpEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub GoodCountSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles GoodCountSpinEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub MatCountSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles MatCountSpinEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub InfCountSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles InfCountSpinEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub LangCountSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles LangCountSpinEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub AddWorkCountSpinEdit_EnabledChanged(sender As Object, e As EventArgs) Handles AddWorkCountSpinEdit.EnabledChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub TotalWorkSpinEdit_EditValueChanged(sender As Object, e As EventArgs) Handles TotalWorkSpinEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub ExpertTermDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ExpertTermDateEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub CommentMemoEdit_EditValueChanged(sender As Object, e As EventArgs) Handles CommentMemoEdit.EditValueChanged
        MyBase.SetChangeDateNow()
    End Sub

    Private Sub UrgencyLookUpEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles UrgencyLookUpEdit.EditValueChanging
        MyBase.SetChangeDateNow()
    End Sub

End Class