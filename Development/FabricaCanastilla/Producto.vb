Imports POSstation.HelperCanastilla

Public Class Producto
    Dim oHelper As New Helper

    Public Function RecuperarProducto(ByVal codigo As Int32) As InformacionProducto
        Try
            Dim oProducto As IDataReader = oHelper.RecuperarProductoPorCodigo(codigo)
            Dim Producto As New InformacionProducto
            If oProducto.Read() Then
                Producto.Codigo = oProducto.Item("Codigo")
                Producto.Descripcion = oProducto.Item("Descripcion")
                Producto.Existencias = oProducto.Item("Existencia")
                Producto.IdProducto = oProducto.Item("IdProducto")
                Producto.Precio = oProducto.Item("PrecioVenta")
                Producto.ManejaExistencias = oProducto.Item("ManejaExistencias")

                If oProducto.Item("IdTipoTarjeta") Is System.DBNull.Value Then
                    Producto.Tipo = TipoTarjeta.Ninguna
                Else
                    Producto.Tipo = CType(oProducto.Item("IdTipoTarjeta"), TipoTarjeta)
                End If

            End If
            oProducto.Close()
            Return Producto
        Catch
            Throw 'New gasolutions.Factory.GasolutionsItemExistException()
        End Try
    End Function


    Public Function RecuperarProductoTerpel(ByVal codigo As Int32) As InformacionProducto
        Try
            Dim oProducto As IDataReader = oHelper.RecuperarProductoPorCodigoTerpel(codigo)
            Dim Producto As New InformacionProducto
            If oProducto.Read() Then
                Producto.Codigo = oProducto.Item("Codigo")
                Producto.Descripcion = oProducto.Item("Descripcion")
                Producto.Existencias = oProducto.Item("Existencia")
                Producto.IdProducto = oProducto.Item("IdProducto")
                Producto.Precio = oProducto.Item("PrecioVenta")
                Producto.ManejaExistencias = oProducto.Item("ManejaExistencias")

                If oProducto.Item("IdTipoTarjeta") Is System.DBNull.Value Then
                    Producto.Tipo = TipoTarjeta.Ninguna
                Else
                    Producto.Tipo = CType(oProducto.Item("IdTipoTarjeta"), TipoTarjeta)
                End If

            End If
            oProducto.Close()
            Return Producto
        Catch
            Throw 'New gasolutions.Factory.GasolutionsItemExistException()
        End Try
    End Function

    Public Function RecuperarProductoTerpel(ByVal codigo As Int32, ByVal IdIsla As Integer) As InformacionProducto
        Try
            Dim oProducto As IDataReader = oHelper.RecuperarProductoPorCodigoTerpel(codigo, IdIsla)
            Dim Producto As New InformacionProducto
            If oProducto.Read() Then
                Producto.Codigo = oProducto.Item("Codigo")
                Producto.Descripcion = oProducto.Item("Descripcion")
                Producto.Existencias = oProducto.Item("Existencia")
                Producto.IdProducto = oProducto.Item("IdProducto")
                Producto.Precio = oProducto.Item("PrecioVenta")
                Producto.ManejaExistencias = oProducto.Item("ManejaExistencias")

                If oProducto.Item("IdTipoTarjeta") Is System.DBNull.Value Then
                    Producto.Tipo = TipoTarjeta.Ninguna
                Else
                    Producto.Tipo = CType(oProducto.Item("IdTipoTarjeta"), TipoTarjeta)
                End If

            End If
            oProducto.Close()
            Return Producto
        Catch
            Throw 'New gasolutions.Factory.GasolutionsItemExistException()
        End Try
    End Function

    Public Function RecuperarProductoConsumos(ByVal codigo As Int32) As InformacionProducto
        Try
            Dim oProducto As IDataReader = oHelper.RecuperarProductoConsumoCanastilla(codigo)
            Dim Producto As New InformacionProducto
            If oProducto.Read() Then
                Producto.Codigo = oProducto.Item("Codigo")
                Producto.Descripcion = oProducto.Item("Descripcion")
                Producto.Existencias = oProducto.Item("Existencia")
                Producto.IdProducto = oProducto.Item("IdProducto")
                Producto.Precio = oProducto.Item("PrecioVenta")
                Producto.ManejaExistencias = oProducto.Item("ManejaExistencias")
            End If
            oProducto.Close()
            Return Producto
        Catch
            Throw 'New gasolutions.Factory.GasolutionsItemExistException()
        End Try
    End Function
End Class

Public Class InformacionProducto

    Private IdProducto_ As Int32
    Private Codigo_ As Int32
    Private Descripcion_ As String
    Private Precio_ As Double
    Private Existencias_ As Int32
    Private Tipo_ As TipoTarjeta
    Private ManejaExistencias_ As Boolean

    Public Property IdProducto() As Int32
        Get
            Return IdProducto_
        End Get
        Set(ByVal value As Int32)
            IdProducto_ = value
        End Set
    End Property

    Public Property Codigo() As Int32
        Get
            Return Codigo_
        End Get
        Set(ByVal value As Int32)
            Codigo_ = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return Descripcion_
        End Get
        Set(ByVal value As String)
            Descripcion_ = value
        End Set
    End Property

    Public Property Existencias() As Int32
        Get
            Return Existencias_
        End Get
        Set(ByVal value As Int32)
            Existencias_ = value
        End Set
    End Property

    Public Property Precio() As Double
        Get
            Return Precio_
        End Get
        Set(ByVal value As Double)
            Precio_ = value
        End Set
    End Property

    Public Property Tipo() As TipoTarjeta
        Get
            Return Tipo_
        End Get
        Set(ByVal value As TipoTarjeta)
            Tipo_ = value
        End Set
    End Property

    Public Property ManejaExistencias() As Boolean
        Get
            Return ManejaExistencias_
        End Get
        Set(ByVal value As Boolean)
            ManejaExistencias_ = value
        End Set
    End Property

End Class