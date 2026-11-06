<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindUserControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindUserControl))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.MainWindowsUIButtonPanel = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.MainPanelControl = New DevExpress.XtraEditors.PanelControl()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainWindowsUIButtonPanel
        '
        Me.MainWindowsUIButtonPanel.ButtonInterval = 12
        ToolTipTitleItem1.Text = "Условия поиска"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Перейти кусловиям поиска"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        ToolTipTitleItem2.Text = "Результаты поиска"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Перейти к результатам поиска"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.MainWindowsUIButtonPanel.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("УСЛОВИЯ", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip1, True, False, True, Nothing, Nothing, -1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("РЕЗУЛЬТАТЫ", CType(resources.GetObject("MainWindowsUIButtonPanel.Buttons1"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", True, -1, True, SuperToolTip2, True, False, True, Nothing, Nothing, -1, False, False)})
        Me.MainWindowsUIButtonPanel.ContentAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.MainWindowsUIButtonPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.MainWindowsUIButtonPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainWindowsUIButtonPanel.Name = "MainWindowsUIButtonPanel"
        Me.MainWindowsUIButtonPanel.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.MainWindowsUIButtonPanel.Padding = New System.Windows.Forms.Padding(0, 12, 0, 0)
        Me.MainWindowsUIButtonPanel.Size = New System.Drawing.Size(95, 400)
        Me.MainWindowsUIButtonPanel.TabIndex = 1
        Me.MainWindowsUIButtonPanel.Text = "MainWindowsUIButtonPanel"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.AutoSizeMode = True
        Me.SeparatorControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.SeparatorControl1.LineOrientation = System.Windows.Forms.Orientation.Vertical
        Me.SeparatorControl1.Location = New System.Drawing.Point(95, 0)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(0)
        Me.SeparatorControl1.Size = New System.Drawing.Size(1, 400)
        Me.SeparatorControl1.TabIndex = 2
        '
        'MainPanelControl
        '
        Me.MainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.MainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanelControl.Location = New System.Drawing.Point(96, 0)
        Me.MainPanelControl.Name = "MainPanelControl"
        Me.MainPanelControl.Size = New System.Drawing.Size(554, 400)
        Me.MainPanelControl.TabIndex = 4
        '
        'FindUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MainPanelControl)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.MainWindowsUIButtonPanel)
        Me.Name = "FindUserControl"
        Me.Size = New System.Drawing.Size(650, 400)
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainPanelControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainWindowsUIButtonPanel As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents MainPanelControl As DevExpress.XtraEditors.PanelControl

End Class
