Namespace Base

    ''' <summary>
    ''' Базовый класс - Таблица данных
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class BaseDataTable : Inherits DataTable

        ''' <summary>
        ''' Инициализация нового экземпляра класса Cprp.DxData.Base.BaseDataTable
        ''' </summary>
        ''' <param name="tableName">Имя таблицы</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal tableName As String)
            MyBase.New(tableName)
        End Sub

        ''' <summary>
        ''' Инициализация нового экземпляра класса Cprp.DxData.Base.BaseDataTable
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' Таблица не содержит данных
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return (Me.Rows.Count = 0)
            End Get
        End Property

        Private _isLock As Boolean = False
        ''' <summary>
        ''' Данные заблокированы на изменение
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Property IsLock As Boolean
            Get
                Return _isLock
            End Get
            Set(ByVal value As Boolean)
                _isLock = value
            End Set
        End Property

    End Class

End Namespace

