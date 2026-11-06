Namespace Base

    ''' <summary>
    ''' Базовый класс - Таблица данных на одну строку
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BaseDataRow : Inherits BaseDataTable

        ''' <summary>
        ''' Инициализация нового экземпляра класса Cprp.DxData.Base.BaseDataRow
        ''' </summary>
        ''' <param name="tableName">Имя таблицы</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal tableName As String)
            MyBase.New(tableName)
        End Sub

        ''' <summary>
        ''' Инициализация нового экземпляра класса Cprp.DxData.Base.BaseDataRow
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Возвращает или задает данные, сохраненные в первой строке в столбце, указанном по индексу
        ''' </summary>
        ''' <param name="columnIndex">Индекс столбца</param>
        ''' <remarks></remarks>
        Default Public Overloads Property Item(ByVal columnIndex As Integer) As Object
            Get
                If MyBase.IsEmpty Then Return Nothing
                If columnIndex < 0 OrElse columnIndex > (Me.Columns.Count - 1) Then Return Nothing
                Return Me.Rows(0)(columnIndex)
            End Get
            Set(ByVal value As Object)
                If MyBase.IsEmpty Then Exit Property
                If columnIndex < 0 OrElse columnIndex > (Me.Columns.Count - 1) Then Exit Property
                Me.Rows(0)(columnIndex) = value
            End Set
        End Property

        ''' <summary>
        ''' Возвращает или задает данные, сохраненные в первой строке в столбце, указанном по имени
        ''' </summary>
        ''' <param name="columnName">Имя столбца</param>
        ''' <remarks></remarks>
        Default Public Overloads Property Item(ByVal columnName As String) As Object
            Get
                Return MyClass.Item(Me.Columns.IndexOf(columnName))
            End Get
            Set(ByVal value As Object)
                MyClass.Item(Me.Columns.IndexOf(columnName)) = value
            End Set
        End Property

        ''' <summary>
        ''' Первая строка в таблице - новая
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsNew As Boolean
            Get
                If Me.Rows.Count = 0 Then Return False
                Return (Me.Rows(0).RowState = DataRowState.Added)
            End Get
        End Property

    End Class


End Namespace
