Public Class HandbookForm 

    Dim T As DataTable = Nothing


    Public Sub New()
        InitializeComponent()
        '
        ' Me
        '
        Me.Text = "Редактирование справочников"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub

    Private Sub DataLoadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadBarButtonItem.ItemClick
        LoadCountry()
    End Sub

    Private Sub DataSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBarButtonItem.ItemClick
        SaveCountry()
    End Sub


    Private Sub LoadCountry()
        If MsgBox("Загрузить таблицу стран?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        GridControl1.DataSource = Nothing
        If Not T Is Nothing Then T.Dispose()
        T = New DataTable
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT id, codDec, nameShort, guid FROM tCountry"
            T.Load(Cmd.ExecuteReader)
        End Using
        GridView1.Columns.Clear()
        GridControl1.DataSource = T
    End Sub

    Private Sub SaveCountry()
        If MsgBox("Сохранить данные в базу?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        GridView1.CloseEditor()
        GridView1.UpdateCurrentRow()
        Using A As New SqlDataAdapter("SELECT id, codDec, nameShort, guid FROM tCountry", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(T)
        End Using
        MsgBox("OK")
    End Sub


End Class