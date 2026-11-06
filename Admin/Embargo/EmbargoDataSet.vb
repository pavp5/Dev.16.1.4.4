''' <summary>
''' Источник данных запретов и ограничений
''' </summary>
Friend Class EmbargoDataSet : Inherits Cprp.DxData.Base.ConnectionDataSet

    ''' <summary>
    ''' Таблица запретов и ограничений
    ''' </summary>
    Friend EmbargoTable As EmbargoDataTable = Nothing

    ''' <summary>
    ''' Таблица фирм из запретов и ограничений
    ''' </summary>
    Friend MemberTable As MemberDataTable = Nothing

    ''' <summary>
    ''' Таблица товаров из запретов и ограничений
    ''' </summary>
    Friend GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Таблица связей запретов и ограничений со странами
    ''' </summary>
    Friend EmbargoCountryTable As EmbargoCountryDataTable = Nothing

    ''' <summary>
    ''' Справочник стран мира
    ''' </summary>
    Friend CountryTable As CountryDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Friend Sub New(Connection As SqlConnection)
        MyBase.New(Connection, "EmbargoData")
        EmbargoTable = New EmbargoDataTable
        MemberTable = New MemberDataTable
        GoodTable = New GoodDataTable
        EmbargoCountryTable = New EmbargoCountryDataTable
        CountryTable = New CountryDataTable
        Me.Tables.AddRange(New DataTable() {EmbargoTable, MemberTable, GoodTable, EmbargoCountryTable, CountryTable})
        Dim Relation As New DataRelation("EmbargoMemberRelation", EmbargoTable.Columns("id"), MemberTable.Columns("embargoId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("EmbargoGoodRelation", EmbargoTable.Columns("id"), GoodTable.Columns("embargoId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("EmbargoCountryRelation", EmbargoTable.Columns("id"), EmbargoCountryTable.Columns("embargoId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("CountryEmbargoRelation", CountryTable.Columns("id"), EmbargoCountryTable.Columns("countryId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
    End Sub


    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    Public Sub DataLoadBase()
        Me.Clear()
        EmbargoTable.Load(Me.ExecuteReader("SELECT id, caption, caption2, modeId, isLimited, isACT FROM tEmbargo"))
        MemberTable.Load(Me.ExecuteReader("SELECT id, embargoId, caption, description, countryId, modeId, isACT FROM tEmbargoMember"))
        GoodTable.Load(Me.ExecuteReader("SELECT id, embargoId, caption, tnved, modeId, isACT FROM tEmbargoGood"))
        CountryTable.Load(Me.ExecuteReader("SELECT id, nameShort, isACT FROM tCountry"))
        EmbargoCountryTable.Load(Me.ExecuteReader("SELECT countryId, embargoId, modeId FROM tEmbargoCountry"))
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    Public Sub DataSaveBase()
        Using A As New SqlDataAdapter("SELECT id, caption, caption2, modeId, isLimited, isACT FROM tEmbargo", Me.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(EmbargoTable)
        End Using
        Using A As New SqlDataAdapter("SELECT id, embargoId, caption, description, countryId, modeId, isACT FROM tEmbargoMember", Me.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(MemberTable)
        End Using
        Using A As New SqlDataAdapter("SELECT id, embargoId, caption, modeId, isACT FROM tEmbargoGood", Me.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(GoodTable)
        End Using
        Using A As New SqlDataAdapter("SELECT countryId, embargoId, modeId FROM tEmbargoCountry", Me.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(EmbargoCountryTable)
        End Using
    End Sub

End Class
