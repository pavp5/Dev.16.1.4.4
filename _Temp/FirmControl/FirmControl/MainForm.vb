''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm

#Region "OrgDataTable"

    Private Class OrgDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("OrgTable")
            With Me.Columns
                .Add("description", GetType(String))
                .Add("countryName", GetType(String))
            End With
        End Sub
    End Class

#End Region

    ''' <summary>
    ''' Таблица организаций
    ''' </summary>
    Private OrgTable As OrgDataTable = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' OrgTable
        '
        OrgTable = New OrgDataTable
        '
        ' OrgGridControl, OrgGridView
        '
        OrgGridControl.DataSource = OrgTable
        OrgGridView.SortInfo.Insert(0, CountryNameGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        OrgGridView.SortInfo.Insert(1, DescriptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        CountryNameGridColumn.Group()
        OrgGridView.CollapseAllGroups()
        '
        ' DescriptionMemoEdit
        '
        DescriptionMemoEdit.DataBindings.Add("Text", OrgTable, "description")
        '
        ' DataReload
        '
        DataReload()
        '
        ' Me
        '
        Me.Icon = My.Resources.pin_red_ico
        Me.Text = "Перечень организаций"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub


    Private Sub DataReload()
        Cprp.DxCommon.WaitForm.Show(Me)
        OrgGridView.BeginDataUpdate()
        OrgTable.Rows.Clear()
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = _
                "SELECT (caption + ISNULL(', ' + description, '') + ISNULL(', источник: ' + embargoName, '')) AS description, " & _
                "tCountry.nameShort AS countryName " & _
                "FROM tMemberBlack " & _
                "LEFT JOIN tCountry ON tMemberBlack.countryId = tCountry.id"
            OrgTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = _
               "SELECT (memberCaption + ISNULL(', ' + memberDescription, '') + ISNULL(', источник: ' + embargoCaption2, '')) AS description, " & _
               "tCountry.nameShort AS countryName " & _
               "FROM vEmbargoMemberData " & _
               "LEFT JOIN tCountry ON vEmbargoMemberData.countryId = tCountry.id " & _
               "WHERE vEmbargoMemberData.isACT = 1 AND vEmbargoMemberData.countryId > 0"
            OrgTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = _
              "SELECT DISTINCT (nusCaption + ', источник: База заключений ФСТЭК') AS description, " & _
              "tCountry.nameShort AS countryName " & _
              "FROM tFInfo " & _
              "LEFT JOIN tCountry ON tFInfo.nusCountryId = tCountry.id " & _
              "WHERE NOT (nusCaption IS NULL OR nusCountryId IS NULL)"
            OrgTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = _
             "SELECT DISTINCT (endCaption + ', источник: База заключений ФСТЭК') AS description, " & _
             "tCountry.nameShort AS countryName " & _
             "FROM tFInfo " & _
             "LEFT JOIN tCountry ON tFInfo.endCountryId = tCountry.id " & _
             "WHERE NOT (endCaption IS NULL OR endCountryId IS NULL)"
            OrgTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = _
             "SELECT DISTINCT (rusCaption + ', источник: База заключений ФСТЭК') AS description, " & _
             "'РОССИЯ' AS countryName " & _
             "FROM tFInfo " & _
             "WHERE NOT rusCaption IS NULL"
            OrgTable.Load(Cmd.ExecuteReader)
        End Using

        OrgGridView.EndDataUpdate()
        OrgGridView.CollapseAllGroups()
        OrgGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()


    End Sub

    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        FindBarEditItem.EditValue = Nothing
        OrgGridView.FindFilterText = Nothing
    End Sub

    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        OrgGridView.FindFilterText = Cprp.DxData.Common.ToText(e.NewValue)
    End Sub


    Private Sub CollpseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CollpseBarButtonItem.ItemClick
        OrgGridView.CollapseAllGroups()
    End Sub

    Private Sub AutoHeightBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AutoHeightBarCheckItem.CheckedChanged
        If AutoHeightBarCheckItem.Checked Then
            DescriptionGridColumn.ColumnEdit = DescriptionRepositoryItemMemoEdit
            OrgGridView.OptionsView.RowAutoHeight = True
            DescriptionLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            SplitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            DescriptionGridColumn.ColumnEdit = Nothing
            OrgGridView.OptionsView.RowAutoHeight = False
            DescriptionLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            SplitterItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub

End Class