''' <summary>
''' Отчет по заказам из регионов / фед. округов
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Таблица отчета по работа за период
    ''' </summary>
    Friend WorkTable As WorkDataTable = Nothing

    ''' <summary>
    ''' Таблица отчета по регионам
    ''' </summary>
    Friend RegionTable As RegionDataTable = Nothing

    ''' <summary>
    ''' Таблица отчета по округам
    ''' </summary>
    ''' <remarks></remarks>
    Friend DistrictTable As DistrictDataTable = Nothing

    ''' <summary>
    ''' Открытое подключение к базе данных EXDBA
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Отчет по регионам
    ''' </summary>
    Private RegionControl As RegionUserControl = Nothing

    ''' <summary>
    ''' Отчет по округам
    ''' </summary>
    Private DistrictControl As DistrictUserControl = Nothing

    ''' <summary>
    ''' Справочник экспертных организаций
    ''' </summary>
    Private ExpertTable As DataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        Me.Connection = Connection
        '
        ' WorkTable, RegionTable, DistrictTable 
        '
        WorkTable = New WorkDataTable
        RegionTable = New RegionDataTable
        DistrictTable = New DistrictDataTable
        Using Cmd As SqlCommand = Me.Connection.CreateCommand
            Cmd.CommandText = "SELECT id, name + ' [' + code + ']' AS name FROM tRegion WHERE isACT = 1"
            RegionTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = "SELECT id, name + ' [' + code + ']' AS name FROM tDistrict WHERE isACT = 1"
            DistrictTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' ExpertTable
        '
        ExpertTable = New DataTable
        With ExpertTable.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        ExpertTable.PrimaryKey = New DataColumn() {ExpertTable.Columns("id")}
        Using Cmd As SqlCommand = Me.Connection.CreateCommand
            Cmd.CommandText = "SELECT id, nameShort AS name FROM tExpertOrg ORDER BY 2"
            ExpertTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' RegionControl, DistrictControl 
        '
        RegionControl = New RegionUserControl(Me) With {.Dock = DockStyle.Fill}
        DistrictControl = New DistrictUserControl(Me) With {.Dock = DockStyle.Fill}
        MainPanelControl.Controls.AddRange(New Control() {RegionControl, DistrictControl})
        MainPanelControl.Controls.SetChildIndex(RegionControl, 0)
        '
        ' TypeComboBoxEdit 
        '
        TypeComboBoxEdit.EditValue = "Регионы"
        '
        ' ExpertLookUpEdit
        '
        ExpertLookUpEdit.Properties.DataSource = ExpertTable
        ExpertLookUpEdit.EditValue = 2  ' ЦПРП
        '
        ' BeginDateEdit, EndDateEdit
        '
        BeginDateEdit.EditValue = Date.Today.AddYears(-2)
        EndDateEdit.EditValue = Date.Today
        '
        ' UnitComboBoxEdit
        '
        UnitComboBoxEdit.EditValue = "Месяц"

    End Sub


    ''' <summary>
    ''' Перечитать данные из базы
    ''' </summary>
    Private Sub DataReload()
        If ExpertLookUpEdit.EditValue Is Nothing Then Exit Sub
        If BeginDateEdit.EditValue Is Nothing Then Exit Sub
        If EndDateEdit.EditValue Is Nothing Then Exit Sub

        Dim dateB As Date = CDate(BeginDateEdit.EditValue)
        Dim dateE As Date = CDate(EndDateEdit.EditValue)
        If dateB >= dateE Then Exit Sub

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        RegionControl.BeginDataUpdate()
        DistrictControl.BeginDataUpdate()
        Try
            '
            ' Загрузка данных по работам
            '
            WorkTable.Rows.Clear()
            Dim expId As Integer = CInt(ExpertLookUpEdit.EditValue)
            Using Cmd As SqlCommand = Connection.CreateCommand
                If expId = 2 Then
                    Cmd.CommandText = String.Format("SELECT workId, orderDate, regionId, districtId FROM vOrderRegion WHERE orderDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND orderDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND NOT regionId IS NULL", dateB, dateE)
                Else
                    Cmd.CommandText = String.Format("SELECT id AS workId, docDate AS orderDate, regionId, districtId FROM vFinfo WHERE orgId = {0} AND docDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND docDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}} AND NOT regionId IS NULL", expId, dateB, dateE)
                End If
                WorkTable.Load(Cmd.ExecuteReader)
            End Using
            '
            ' Перечитывание данных по регионам и округам
            '
            Using V As New DataView(WorkTable)
                For Each Row As DataRow In RegionTable.Rows
                    V.RowFilter = String.Format("regionId = {0}", CInt(Row("id")))
                    Row("workCount") = V.Count
                Next
                For Each Row As DataRow In DistrictTable.Rows
                    V.RowFilter = String.Format("districtId = {0}", CInt(Row("id")))
                    Row("workCount") = V.Count
                Next
            End Using
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции: {0}", ex.Message))
        Finally
            RegionControl.EndDataUpdate()
            DistrictControl.EndDataUpdate()
        End Try

    End Sub


    Private Sub TypeComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeComboBoxEdit.SelectedIndexChanged
        FindButtonEdit.EditValue = Nothing
        If TypeComboBoxEdit.EditValue.ToString = "Округа" Then
            MainPanelControl.Controls.SetChildIndex(DistrictControl, 0)
        Else
            MainPanelControl.Controls.SetChildIndex(RegionControl, 0)
        End If
    End Sub

    Private Sub ExpertLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ExpertLookUpEdit.EditValueChanged
        DataReload()
    End Sub

    Private Sub BeginDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BeginDateEdit.EditValueChanged
        DataReload()
    End Sub

    Private Sub EndDateEdit_EditValueChanged(sender As Object, e As EventArgs) Handles EndDateEdit.EditValueChanged
        DataReload()
    End Sub

    Private Sub UnitComboBoxEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UnitComboBoxEdit.SelectedIndexChanged
        RegionControl.ChangeTimeUnit(UnitComboBoxEdit.EditValue.ToString)
        DistrictControl.ChangeTimeUnit(UnitComboBoxEdit.EditValue.ToString)
    End Sub

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        FindButtonEdit.EditValue = Nothing
    End Sub

    Private Sub FindButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindButtonEdit.EditValueChanging
        Dim findText As String = Nothing
        If Not e.NewValue Is Nothing Then findText = e.NewValue.ToString
        RegionControl.FindFilterText(findText)
        DistrictControl.FindFilterText(findText)
    End Sub

End Class
