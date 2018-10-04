Public Class Productos
    Private _IdProducto As Integer
    Private _Precio As Decimal
    Private _Nombre As String

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property

    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property

End Class


Public Class CarasProducto
    Private _KeyProductos As New List(Of Integer)
    Private _IdCara As String


    Public Property KeyProductos() As List(Of Integer)
        Get
            Return _KeyProductos
        End Get
        Set(ByVal value As List(Of Integer))
            _KeyProductos = value
        End Set
    End Property

    Public Property IdCara() As String
        Get
            Return _IdCara
        End Get
        Set(ByVal value As String)
            _IdCara = value
        End Set
    End Property

End Class