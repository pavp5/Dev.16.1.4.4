Public Class WorkForm 


    Public Sub New()
        InitializeComponent()
        '
        ' WorkControl
        '
        'Using Work As New Cprp.DxData.Work.Excont.WorkConnectionRow(27757, Program.DbClient.Connection)
        '    Work.Condition = Cprp.DxData.Work.WorkCondition.IsWork
        '    Work.RequestTable.Rows.Clear()
        '    Work.RequestFieldsUpdate()
        '    Work.DataSave()
        'End Using
        Me.Controls.Add(New Cprp.DxData.Work.Excont.WorkUserControl(6867, Program.DbClient.Connection, Program.DbClient, Program.AppErrorTable) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Customs.WorkUserControl(6867, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Liconfirm.WorkUserControl(6867, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Tnved.WorkUserControl(6867, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Consultation.WorkUserControl(6867, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Military.WorkUserControl(6867, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Order.WorkUserControl(91003, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.Alteration.WorkUserControl(53120, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        'Me.Controls.Add(New Cprp.DxData.Work.License.WorkUserControl(45388, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill})
        '
        ' LawControl
        '
        'Me.Controls.Add(New Cprp.DxData.Law.LawUserControl(Program.DbClient.Connection) With {.Dock = DockStyle.Fill})
        '
        ' Me
        '
        Me.Text = "Рабочее место эксперта"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


End Class