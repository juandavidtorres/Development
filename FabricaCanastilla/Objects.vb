Imports POSstation.Fabrica
Imports POSstation.HelperCanastilla

Public Class Factura

    Private Total_ As Double
    Private IdFormaPago_ As Int16
    Private _Productos As New Collection()
    Private _Tarjetas As New Collection()
    Private _Pagos As New Collection
    Private IdFactura_ As Int64
    Private _GUIDFactura As String
    Private _Empleado As String
    Private _TarjetaDescuento As TarjetaFidelizacion = Nothing
    Private _EsAutorizadoDescuentosCDC As Boolean
    Private _Mensaje As String
    Private _NoAplicaDescuentoCDC As Boolean = True
    Private _EsFacturaFinalizada As Boolean
    Private _Resolucion As String
    Private _Fecha As DateTime
    Private _IdIsla As Integer

    Private oHelper As Helper = New Helper()
    ' Private Totales As New Dictionary(Of String, Double)
    Dim LogCategorias As New CategoriasLog, LogPropiedades As New PropiedadesExtendidas



    Public Property IdIsla() As Integer
        Get
            Return _IdIsla
        End Get
        Set(ByVal value As Integer)
            _IdIsla = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Public Property Empleado() As String
        Get
            Return _Empleado
        End Get
        Set(ByVal value As String)
            _Empleado = value
        End Set
    End Property

    Public Property EsFacturaFinalizada() As Boolean
        Get
            Return _EsFacturaFinalizada
        End Get
        Set(ByVal value As Boolean)
            _EsFacturaFinalizada = value
        End Set
    End Property

    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property NoAplicaDescuentoCDC() As Boolean
        Get
            Return _NoAplicaDescuentoCDC
        End Get
        Set(ByVal value As Boolean)
            _NoAplicaDescuentoCDC = value
        End Set
    End Property

    Public Property EsAutorizadoDescuentosCDC() As Boolean
        Get
            Return _EsAutorizadoDescuentosCDC
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizadoDescuentosCDC = value
        End Set
    End Property

    Public ReadOnly Property GUIDFactura() As String
        Get
            Return _GUIDFactura
        End Get
    End Property

    Public ReadOnly Property IdFactura() As Int64
        Get
            Return IdFactura_
        End Get
    End Property

    Public Property Pagos() As Collection
        Get
            Return _Pagos
        End Get
        Set(ByVal value As Collection)
            _Pagos = value
        End Set
    End Property

    Public Property Productos() As Collection
        Get
            Return _Productos
        End Get
        Set(ByVal value As Collection)
            _Productos = value
        End Set
    End Property

    Public Property TarjetaDescuento() As TarjetaFidelizacion
        Get
            Return _TarjetaDescuento
        End Get
        Set(ByVal value As TarjetaFidelizacion)
            _TarjetaDescuento = value
        End Set
    End Property

    Public Property Tarjetas() As Collection
        Get
            Return _Tarjetas
        End Get
        Set(ByVal value As Collection)
            _Tarjetas = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return Total_
        End Get
        Set(ByVal value As Double)
            Total_ = value
        End Set
    End Property

    Public Property Resolucion() As String
        Get
            Return _Resolucion
        End Get
        Set(ByVal value As String)
            _Resolucion = value
        End Set
    End Property

    Public Property IdFormaPago() As Int16
        Get
            Return IdFormaPago_
        End Get
        Set(ByVal value As Int16)
            IdFormaPago_ = value
        End Set
    End Property

    Public Sub New()
        IdFactura_ = 0
        _GUIDFactura = System.Guid.NewGuid.ToString
        _Fecha = Now
    End Sub

    Public Sub GuardarTarjetaDescuento(ByVal nroTarjeta As String, ByVal nroSeguridad As String, ByVal tipoLectura As Byte)
        _TarjetaDescuento = New TarjetaFidelizacion
        TarjetaDescuento.CodigoTarjeta = nroTarjeta
        TarjetaDescuento.NumeroSeguridad = nroSeguridad
        TarjetaDescuento.TipoLecturaTarjeta = tipoLectura
    End Sub

    Public Sub AgregarProducto(ByVal codigoProducto As Int32, ByVal cantidad As Integer)
        If Not Productos.Contains(codigoProducto) Then
            Try
                Dim oDetalle As New FacturaDetalle()
                Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigo(codigoProducto)
                If Reader.Read Then
                    oDetalle.AplicaDescuento = Reader("ConDescuento")
                    oDetalle.IdProducto = Reader("IdProducto")
                    oDetalle.Precio = Reader("PrecioVenta")
                End If
                Reader.Close()
                If oDetalle.AplicaDescuento Then
                    _NoAplicaDescuentoCDC = False
                End If
                oDetalle.Cantidad = cantidad
                oDetalle.CantidadAutorizada = 0
                oDetalle.Descuento = 0
                oDetalle.CodigoProducto = codigoProducto
                Productos.Add(oDetalle, codigoProducto.ToString)
            Catch
                Throw
            End Try
        Else
            'El producto ya existe debo sumarle la cantidad
            Try
                Dim oDetalle As FacturaDetalle = Productos.Item(codigoProducto.ToString)
                oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                oDetalle.CantidadAutorizada = 0
            Catch
                Throw
            End Try
            'Throw New GasolutionsItemExistException(codigoProducto)
        End If
    End Sub

    Public Sub AgregarProducto(ByVal codigoProducto As Int32, ByVal cantidad As Integer, ByVal PrecioCliente As Double, ByVal PorcentajeDescuento As Double, ByVal ValorDescuento As Decimal)
        If Not Productos.Contains(codigoProducto) Then
            Try
                Dim oDetalle As New FacturaDetalle()
                Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigo(codigoProducto)
                If Reader.Read Then
                    oDetalle.AplicaDescuento = Reader("ConDescuento")
                    oDetalle.IdProducto = Reader("IdProducto")
                    oDetalle.Precio = Reader("PrecioVenta")
                End If
                Reader.Close()
                If oDetalle.AplicaDescuento Then
                    _NoAplicaDescuentoCDC = False
                End If

                'If PrecioCliente > 0 Then
                oDetalle.Precio = PrecioCliente
                'End If

                oDetalle.Cantidad = cantidad
                oDetalle.CantidadAutorizada = 0
                oDetalle.Descuento = ValorDescuento
                oDetalle.PorcentajeDescuento = PorcentajeDescuento
                oDetalle.CodigoProducto = codigoProducto
                Productos.Add(oDetalle, codigoProducto.ToString)
            Catch
                Throw
            End Try
        Else
            'El producto ya existe debo sumarle la cantidad
            Try
                Dim oDetalle As FacturaDetalle = Productos.Item(codigoProducto.ToString)
                oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                oDetalle.CantidadAutorizada = 0
            Catch
                Throw
            End Try
            'Throw New GasolutionsItemExistException(codigoProducto)
        End If
    End Sub
    Public Sub AgregarProducto(ByVal codigoProducto As Int32, ByVal cantidad As Integer, ByVal PrecioCliente As Double, ByVal PorcentajeDescuento As Double, ByVal ValorDescuento As Decimal, ByVal idEstacion As Int16)
        If Not Productos.Contains(codigoProducto) Then
            Try
                Dim oDetalle As New FacturaDetalle()
                Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigo(codigoProducto, idEstacion)
                If Reader.Read Then
                    oDetalle.AplicaDescuento = Reader("ConDescuento")
                    oDetalle.IdProducto = Reader("IdProducto")
                    oDetalle.Precio = Reader("PrecioVenta")
                End If
                Reader.Close()
                If oDetalle.AplicaDescuento Then
                    _NoAplicaDescuentoCDC = False
                End If

                'If PrecioCliente > 0 Then
                oDetalle.Precio = PrecioCliente
                'End If

                oDetalle.Cantidad = cantidad
                oDetalle.CantidadAutorizada = 0
                oDetalle.Descuento = ValorDescuento
                oDetalle.PorcentajeDescuento = PorcentajeDescuento
                oDetalle.CodigoProducto = codigoProducto
                Productos.Add(oDetalle, codigoProducto.ToString)
            Catch
                Throw
            End Try
        Else
            'El producto ya existe debo sumarle la cantidad
            Try
                Dim oDetalle As FacturaDetalle = Productos.Item(codigoProducto.ToString)
                oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                oDetalle.CantidadAutorizada = 0
            Catch
                Throw
            End Try
            'Throw New GasolutionsItemExistException(codigoProducto)
        End If
    End Sub

    Public Sub AgregarProductoTerpel(ByVal codigoProducto As Int32, ByVal cantidad As Integer)
        If Not Productos.Contains(codigoProducto) Then
            Try
                Dim oDetalle As New FacturaDetalle()
                Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigoTerpel(codigoProducto)
                If Reader.Read Then
                    oDetalle.AplicaDescuento = Reader("ConDescuento")
                    oDetalle.IdProducto = Reader("IdProducto")
                    oDetalle.Precio = Reader("PrecioVenta")
                End If
                Reader.Close()
                If oDetalle.AplicaDescuento Then
                    _NoAplicaDescuentoCDC = False
                End If
                oDetalle.Cantidad = cantidad
                oDetalle.CantidadAutorizada = 0
                oDetalle.Descuento = 0
                oDetalle.CodigoProducto = codigoProducto
                Productos.Add(oDetalle, codigoProducto.ToString)
            Catch
                Throw
            End Try
        Else
            'El producto ya existe debo sumarle la cantidad
            Try
                Dim oDetalle As FacturaDetalle = Productos.Item(codigoProducto.ToString)
                oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                oDetalle.CantidadAutorizada = 0
            Catch
                Throw
            End Try
            'Throw New GasolutionsItemExistException(codigoProducto)
        End If
    End Sub



    Public Sub AgregarProductoTerpel(ByVal codigoProducto As Int32, ByVal cantidad As Integer, ByVal IdIsla As Integer)
        Dim Llave As String = codigoProducto.ToString & "|" & IdIsla.ToString
        If Not Productos.Contains(Llave) Then
            Try
                Dim oDetalle As New FacturaDetalle()
                Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigoTerpel(codigoProducto, IdIsla)
                If Reader.Read Then
                    oDetalle.AplicaDescuento = Reader("ConDescuento")
                    oDetalle.IdProducto = Reader("IdProducto")
                    oDetalle.Precio = Reader("PrecioVenta")
                End If
                Reader.Close()
                If oDetalle.AplicaDescuento Then
                    _NoAplicaDescuentoCDC = False
                End If
                oDetalle.Cantidad = cantidad
                oDetalle.CantidadAutorizada = 0
                oDetalle.Descuento = 0
                oDetalle.CodigoProducto = codigoProducto
                oDetalle.IdIsla = IdIsla
                ''Productos.Add(oDetalle, codigoProducto.ToString)
                Productos.Add(oDetalle, codigoProducto.ToString & "|" & oDetalle.IdIsla.ToString)
            Catch
                Throw
            End Try
        Else
            'El producto ya existe debo sumarle la cantidad
            Try
                If IdIsla = -1 Then
                    Dim oDetalle As FacturaDetalle = Productos.Item(Llave)
                    oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                    oDetalle.CantidadAutorizada = 0
                Else
                    Dim oDetalle As FacturaDetalle = Productos.Item(Llave)

                    If oDetalle.IdIsla = IdIsla And oDetalle.CodigoProducto = codigoProducto Then '' Valido que la venta se este realizando en la misma Isla 
                        oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                        oDetalle.CantidadAutorizada = 0
                    Else
                        Dim oDetalleCanastilla As New FacturaDetalle()
                        Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigoTerpel(codigoProducto, IdIsla)
                        If Reader.Read Then
                            oDetalleCanastilla.AplicaDescuento = Reader("ConDescuento")
                            oDetalleCanastilla.IdProducto = Reader("IdProducto")
                            oDetalleCanastilla.Precio = Reader("PrecioVenta")
                        End If
                        Reader.Close()
                        If oDetalle.AplicaDescuento Then
                            _NoAplicaDescuentoCDC = False
                        End If
                        oDetalleCanastilla.Cantidad = cantidad
                        oDetalleCanastilla.CantidadAutorizada = 0
                        oDetalleCanastilla.Descuento = 0
                        oDetalleCanastilla.CodigoProducto = codigoProducto
                        oDetalleCanastilla.IdIsla = IdIsla
                        Productos.Add(oDetalleCanastilla, codigoProducto.ToString & "|" & oDetalleCanastilla.IdIsla.ToString)
                    End If

                End If

            Catch
                Throw
            End Try
            'Throw New GasolutionsItemExistException(codigoProducto)
        End If
    End Sub


    Public Sub AgregarProductoTerpel(ByVal codigoProducto As Int32, ByVal cantidad As Integer, ByVal PrecioCliente As Double, ByVal PorcentajeDescuento As Double, ByVal ValorDescuento As Decimal)
        If Not Productos.Contains(codigoProducto) Then
            Try
                Dim oDetalle As New FacturaDetalle()
                Dim Reader As IDataReader = oHelper.RecuperarProductoPorCodigoTerpel(codigoProducto)
                If Reader.Read Then
                    oDetalle.AplicaDescuento = Reader("ConDescuento")
                    oDetalle.IdProducto = Reader("IdProducto")
                    oDetalle.Precio = Reader("PrecioVenta")
                End If
                Reader.Close()
                If oDetalle.AplicaDescuento Then
                    _NoAplicaDescuentoCDC = False
                End If

                'If PrecioCliente > 0 Then
                oDetalle.Precio = PrecioCliente
                'End If

                oDetalle.Cantidad = cantidad
                oDetalle.CantidadAutorizada = 0
                oDetalle.Descuento = ValorDescuento
                oDetalle.PorcentajeDescuento = PorcentajeDescuento
                oDetalle.CodigoProducto = codigoProducto
                Productos.Add(oDetalle, codigoProducto.ToString)
            Catch
                Throw
            End Try
        Else
            'El producto ya existe debo sumarle la cantidad
            Try
                Dim oDetalle As FacturaDetalle = Productos.Item(codigoProducto.ToString)
                oDetalle.Cantidad = oDetalle.Cantidad + cantidad
                oDetalle.CantidadAutorizada = 0
            Catch
                Throw
            End Try
            'Throw New GasolutionsItemExistException(codigoProducto)
        End If
    End Sub

    Public Sub AgregarTarjetaPrepago(ByVal codigoProducto As Int32, ByVal nroTarjeta As String, ByVal valorCarga As Integer, ByVal nroSeguridad As String, ByVal tipoLectura As Byte)
        Dim ODetalleTarjeta As New FacturaTarjeta()
        Try


            If tipoLectura = TipoLecturaTarjeta.CodigoBarra Then
                ODetalleTarjeta.NroCodigoBarra = nroTarjeta
                ODetalleTarjeta.NroConfirmacion = nroSeguridad
                ODetalleTarjeta.NroTarjeta = String.Empty
            Else
                ODetalleTarjeta.NroTarjeta = nroTarjeta
                ODetalleTarjeta.NroConfirmacion = nroSeguridad
                ODetalleTarjeta.NroCodigoBarra = String.Empty
            End If




            If Not Tarjetas.Contains(nroTarjeta) Then
                Try
                    ODetalleTarjeta.IdProducto = oHelper.RecuperarIdProducto(codigoProducto)
                    ODetalleTarjeta.ValorCarga = valorCarga
                    ODetalleTarjeta.Tipo = tipoLectura
                    Tarjetas.Add(ODetalleTarjeta, nroTarjeta)
                Catch
                    Throw
                End Try
            Else
                'La Tarjeta Prepago ya existe debo sumarle el Valor de la Carga
                Try
                    ODetalleTarjeta = Tarjetas.Item(nroTarjeta)
                    ODetalleTarjeta.ValorCarga = ODetalleTarjeta.ValorCarga + valorCarga
                Catch
                    Throw
                End Try
            End If
        Catch ex As System.Exception
            ' MsgBox(ex.Message)
            Throw
        End Try


    End Sub

    Public Sub AgregarPago(ByVal idFormaPago As Short, ByVal referencia As String, ByVal valor As Double, ByVal tipoLectura As Integer, ByVal nroConfirmacion As String)

        If Not Pagos.Contains(idFormaPago) Then

            Try
                Dim OPago As New FormasPagoCanastilla()
                OPago.IdFormaPago = idFormaPago
                If String.IsNullOrEmpty(referencia) Then
                    OPago.Referencia = Nothing
                Else
                    OPago.Referencia = referencia
                End If

                If String.IsNullOrEmpty(nroConfirmacion) Then
                    OPago.NroConfirmacion = Nothing
                Else
                    OPago.NroConfirmacion = nroConfirmacion
                End If

                OPago.Valor = valor

                OPago.TipoLectura = tipoLectura
                Pagos.Add(OPago, idFormaPago)
                ' Totales.Add(idFormaPago.ToString, valor)
            Catch
                Throw
            End Try
        Else
            'La Forma de Pago ya existe debo sumarle el valor
            Try
                Dim OPago As FormasPagoCanastilla = Pagos.Item(idFormaPago)
                OPago.Valor = OPago.Valor + valor
                ' Dim Suma As Double
                'Suma = Totales.Item(idFormaPago.ToString) + valor
            Catch EX As System.Exception
                'MsgBox(EX.Message)
                Throw
            End Try
            ' Throw New GasolutionsItemExistException(idFormaPago)
        End If
    End Sub

    Public Sub EliminarPago()
        Try
            'Se deben eliminar los medios de pago que se han ingresado por si se comenzó a modificar la venta
            'de canastilla y luego decidieron no modificarla
            Pagos.Clear()
        Catch ex As System.Exception
            Throw
        End Try
    End Sub

    Public Function ExisteFormaPago(ByVal idFormaPago As Short) As Boolean
        Return Pagos.Contains(idFormaPago)
    End Function

    Public Function ExistePrepago(ByVal codigo As String) As Boolean
        Return Tarjetas.Contains(codigo)
    End Function

    Public Function ExisteProducto(ByVal codigoProducto As Int32) As Boolean
        Return Productos.Contains(codigoProducto)
    End Function

    Public Function RecuperarTotalventa() As Double
        Dim Producto As FacturaDetalle
        Dim TotalVenta As Double = 0

        If Productos.Count > 0 Then
            For I As Int32 = 1 To Productos.Count
                Producto = Productos.Item(I)
                TotalVenta = TotalVenta + (Producto.Cantidad * Producto.Precio)
            Next I
        End If

        Dim OTarjeta As FacturaTarjeta

        If Tarjetas.Count > 0 Then
            For I As Int32 = 1 To Tarjetas.Count
                OTarjeta = Tarjetas.Item(I)
                TotalVenta = TotalVenta + OTarjeta.ValorCarga
            Next I
        End If

        Return TotalVenta
    End Function

    Public Function RecuperarTotalVentaConDescuentos() As Double
        Dim Producto As FacturaDetalle
        Dim TotalVenta As Double = 0

        If Productos.Count > 0 Then
            For I As Int32 = 1 To Productos.Count
                Producto = Productos.Item(I)
                TotalVenta = TotalVenta + (Producto.Cantidad * Producto.Precio) - oHelper.RecuperarDescuentoProducto(Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.Descuento, Producto.CantidadAutorizada)
            Next I
        End If

        Dim OTarjeta As FacturaTarjeta

        If Tarjetas.Count > 0 Then
            For I As Int32 = 1 To Tarjetas.Count
                OTarjeta = Tarjetas.Item(I)
                TotalVenta = TotalVenta + OTarjeta.ValorCarga
            Next I
        End If

        Return TotalVenta
    End Function

    Public Function Guardar(ByVal cedula As String, ByVal clave As String, ByVal esModificada As Boolean) As Int64
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperarventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmp(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.Descuento, Producto.CantidadAutorizada, I = 1, Producto.ValorDescuento)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                oHelper.InsertarFacturaTarjetaTmp(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmp(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmp(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("Cedula", cedula)
            LogPropiedades.Agregar("Clave", clave)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdFactura_ = oHelper.InsertarFactura(Double.Parse(Total_.ToString()), CInt(cedula).ToString(), CInt(clave).ToString(), Me.GUIDFactura, Me.GUIDFactura, esModificada, Me.Fecha)


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return oHelper.RecuperarConsecutivoFactura(IdFactura, False)
        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("Guardar(ByVal cedula As String, ByVal clave As String, ByVal esModificada As Boolean) As Int64", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Factura No Guardada: " & ex.Message)
        End Try
    End Function

    Public Function GuardarFacturaTerpel(ByVal cedula As String, ByVal clave As String, ByVal esModificada As Boolean) As Int64
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperarventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpTerpel(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.Descuento, Producto.CantidadAutorizada, I = 1, Producto.ValorDescuento)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("Cedula", cedula)
            LogPropiedades.Agregar("Clave", clave)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdFactura_ = oHelper.InsertarFacturaTerpel(Double.Parse(Total_.ToString()), CInt(cedula).ToString(), CInt(clave).ToString(), Me.GUIDFactura, Me.GUIDFactura, esModificada, Me.Fecha)


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return oHelper.RecuperarConsecutivoFactura(IdFactura, False)
        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarFacturaTerpel(ByVal cedula As String, ByVal clave As String, ByVal esModificada As Boolean) As Int64", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Factura No Guardada: " & ex.Message)
        End Try
    End Function

    Public Function GuardarTerpel(ByVal consecutivo As Int32) As FacturaDetalle
        Try
            Dim Producto As FacturaDetalle

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            Producto = Productos.Item(consecutivo)
            Return Producto

        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("Aqui esta el problema", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Factura No Guardada: " & ex.Message)
        End Try
    End Function

    Public Function ExisteResolucionValida() As Boolean
        Return oHelper.ExisteResolucionValida()
    End Function

    Public Function RecuperarResolucionActivaCanastilla() As String
        Return oHelper.RecuperarResolucionActivaCanastilla()
    End Function

    Public Function GuardarVenta(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperarventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpTerpel(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.PorcentajeDescuento, Producto.CantidadAutorizada, I = 1, Producto.Descuento)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                If Not TarjetaDescuento Is Nothing Then
                    oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
                End If
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdFactura_ = oHelper.InsertarVentaTerpel(Double.Parse(Total_.ToString()), Cedula, Clave, Me.GUIDFactura, Me.GUIDFactura, Me.Fecha, Cliente, tipoIdentificacion, identificacion, IdFormaPagoPredefinida)

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return IdFactura_ 'oHelper.RecuperarConsecutivoFactura(IdFactura, False)
        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarVenta(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Recibo No Guardado: " & ex.Message)
        End Try
    End Function

    Public Function GuardarVentaFullstation(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperarventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpFullStation(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.PorcentajeDescuento, Producto.CantidadAutorizada, I = 1, Producto.Descuento, Producto.IdIsla)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                If Not TarjetaDescuento Is Nothing Then
                    oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
                End If
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdFactura_ = oHelper.InsertarVentaTerpel(Double.Parse(Total_.ToString()), Cedula, Clave, Me.GUIDFactura, Me.GUIDFactura, Me.Fecha, Cliente, tipoIdentificacion, identificacion, IdFormaPagoPredefinida)

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return IdFactura_ 'oHelper.RecuperarConsecutivoFactura(IdFactura, False)
        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarVenta(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Recibo No Guardado: " & ex.Message)
        End Try
    End Function


    Public Function GuardarVentaFullstation(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, ByVal TipoDocumento As Integer, ByVal IdImpresora As Integer, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperarventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpFullStation(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.PorcentajeDescuento, Producto.CantidadAutorizada, I = 1, Producto.Descuento, Producto.IdIsla)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                If Not TarjetaDescuento Is Nothing Then
                    oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
                End If
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdFactura_ = oHelper.InsertarVentaTerpel(Double.Parse(Total_.ToString()), Cedula, Clave, Me.GUIDFactura, Me.GUIDFactura, Me.Fecha, Cliente, tipoIdentificacion, identificacion, TipoDocumento, IdImpresora, IdFormaPagoPredefinida)

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return IdFactura_ 'oHelper.RecuperarConsecutivoFactura(IdFactura, False)
        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarVenta(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Recibo No Guardado: " & ex.Message)
        End Try
    End Function


    'Esta funcion es la que guarda los documento en la version de fullstation peru, se envian todos los datos desde la terminal host
    'Falta implementar la logica en la base de datos para generar el documento y guardar la informacion del voucher y la franquicia 
    'Cuando se paga con medio de pago tarjeta -- Juan David 2012-12-27
    Public Function GuardarVentaFullstationPeru(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, ByVal TipoDocumento As Integer, ByVal IdImpresora As Integer, ByVal IdFormaPagoPredefinida As Int16, ByVal Franquicia As String, ByVal Voucher As String) As Int64
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperarventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpFullStation(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.PorcentajeDescuento, Producto.CantidadAutorizada, I = 1, Producto.Descuento, Producto.IdIsla)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                If Not TarjetaDescuento Is Nothing Then
                    oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
                End If
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdFactura_ = oHelper.InsertarVentaTerpel(Double.Parse(Total_.ToString()), Cedula, Clave, Me.GUIDFactura, Me.GUIDFactura, Me.Fecha, Cliente, tipoIdentificacion, identificacion, TipoDocumento, IdImpresora, IdFormaPagoPredefinida, Franquicia, Voucher)

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return IdFactura_ 'oHelper.RecuperarConsecutivoFactura(IdFactura, False)
        Catch ex As System.Exception
            'MsgBox(ex.Message)
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarVenta(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String, Optional ByVal IdFormaPagoPredefinida As Int16 = 4) As Int64", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Recibo No Guardado: " & ex.Message)
        End Try
    End Function

    Public Function GuardarFacturaTerpel(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String) As Int32
        Try
            Dim IdDocumento As Int32

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperartotalventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpTerpel(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.PorcentajeDescuento, Producto.CantidadAutorizada, I = 1, Producto.Descuento)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdDocumento = oHelper.InsertarFacturaTerpel(Double.Parse(Total_.ToString()), Cedula, Clave, Me.GUIDFactura, Me.GUIDFactura, Me.Fecha, Cliente, tipoIdentificacion, identificacion)

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return IdDocumento
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarFacturaTerpel(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String) As Int32", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Factura No Guardada: " & ex.Message)
        End Try
    End Function

    Public Function GuardarFacturaFullStation(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String) As Int32
        Try
            Dim IdDocumento As Int32

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Intenta recuperartotalventa", LogPropiedades, LogCategorias)

            Total_ = RecuperarTotalventa()

            Dim Producto As FacturaDetalle
            Dim OTarjeta As FacturaTarjeta
            Dim OPago As FormasPagoCanastilla

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogIt.Loguear("Empieza a agregar productos al temporal", LogPropiedades, LogCategorias)

            If Productos.Count > 0 Then
                For I As Int32 = 1 To Productos.Count
                    Producto = Productos.Item(I)
                    oHelper.InsertarFacturaDetalleTmpFullStation(Me.GUIDFactura, Producto.IdProducto, Producto.Cantidad, Producto.Precio, Producto.PorcentajeDescuento, Producto.CantidadAutorizada, I = 1, Producto.Descuento, Producto.IdIsla)
                Next I
            End If

            If Me.NoAplicaDescuentoCDC = False Then
                oHelper.InsertarFacturaTarjetaTmpTerpel(Me.GUIDFactura, TarjetaDescuento.CodigoTarjeta, TarjetaDescuento.NumeroSeguridad, TarjetaDescuento.TipoLecturaTarjeta, TarjetaDescuento.ClasificacionCliente, TarjetaDescuento.IdentificacionCliente)
            End If

            If Tarjetas.Count > 0 Then
                For I As Int32 = 1 To Tarjetas.Count
                    OTarjeta = Tarjetas.Item(I)
                    oHelper.InsertarFacturaDetalleTarjetaTmpTerpel(Me.GUIDFactura, OTarjeta.IdProducto, OTarjeta.ValorCarga, OTarjeta.NroCodigoBarra, OTarjeta.NroTarjeta, OTarjeta.NroConfirmacion, I = 1)
                Next I
            End If

            If Pagos.Count > 0 Then
                For I As Int32 = 1 To Pagos.Count
                    OPago = Pagos.Item(I)
                    oHelper.InsertarFacturaFormaPagoTmpTerpel(Me.GUIDFactura, OPago.IdFormaPago, OPago.Valor, OPago.Referencia, OPago.TipoLectura, OPago.NroConfirmacion, I = 1)
                Next I
            End If

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Total", Total)
            LogPropiedades.Agregar("IdFormaPago", IdFormaPago_.ToString)
            LogPropiedades.Agregar("My.Computer.Name", My.Computer.Name)
            LogIt.Loguear("Va a insertar factura", LogPropiedades, LogCategorias)

            IdDocumento = oHelper.InsertarFacturaTerpel(Double.Parse(Total_.ToString()), Cedula, Clave, Me.GUIDFactura, Me.GUIDFactura, Me.Fecha, Cliente, tipoIdentificacion, identificacion)

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdFactura", IdFactura)
            LogIt.Loguear("Recupera Consecutivo", LogPropiedades, LogCategorias)

            Return IdDocumento
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            LogIt.Loguear("GuardarFacturaTerpel(ByVal Cedula As String, ByVal Clave As String, ByVal Cliente As String, ByVal tipoIdentificacion As Integer, ByVal identificacion As String) As Int32", LogPropiedades, LogCategorias)

            Throw New GasolutionsException("Factura No Guardada: " & ex.Message)
        End Try
    End Function
End Class

Public Class FacturaDetalle
    'Private IdFactura_ As Int32
    Private IdProducto_ As Int32
    Private CodigoProducto_ As Int32
    Private Cantidad_ As Integer
    Private CantidadAutorizada_ As Integer
    Private Descuento_ As Decimal
    Private Precio_ As Double
    Private AplicaDescuento_ As Boolean
    Private PorcentajeDescuento_ As Decimal = 0
    Private _valorDescuento As Decimal = 0
    Private _IdIsla As Integer


    Public Property IdIsla() As Integer
        Get
            Return _IdIsla
        End Get
        Set(ByVal value As Integer)
            _IdIsla = value
        End Set
    End Property


    Public Property ValorDescuento() As Decimal
        Get
            Return _valorDescuento
        End Get
        Set(ByVal value As Decimal)
            _valorDescuento = value
        End Set
    End Property

    Public Property PorcentajeDescuento() As Decimal
        Get
            Return PorcentajeDescuento_
        End Get
        Set(ByVal value As Decimal)
            PorcentajeDescuento_ = value
        End Set
    End Property

    Public Property CodigoProducto() As Int32
        Get
            Return CodigoProducto_
        End Get
        Set(ByVal value As Int32)
            CodigoProducto_ = value
        End Set
    End Property


    Public Property AplicaDescuento() As Boolean
        Get
            Return AplicaDescuento_
        End Get
        Set(ByVal value As Boolean)
            AplicaDescuento_ = value
        End Set
    End Property

    Public Property Descuento() As Decimal
        Get
            Return Descuento_
        End Get
        Set(ByVal value As Decimal)
            Descuento_ = value
        End Set
    End Property

    Public Property CantidadAutorizada() As Integer
        Get
            Return CantidadAutorizada_
        End Get
        Set(ByVal value As Integer)
            CantidadAutorizada_ = value
        End Set
    End Property

    Public Property IdProducto() As Int32
        Get
            Return IdProducto_
        End Get
        Set(ByVal value As Int32)
            IdProducto_ = value
        End Set
    End Property

    Public Property Cantidad() As Int32
        Get
            Return Cantidad_
        End Get
        Set(ByVal value As Int32)
            Cantidad_ = value
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
End Class


Public Class FacturaTarjeta

    Private IdProducto_ As Int32
    Private NroCodigoBarra_ As String
    Private NroTarjeta_ As String
    Private ValorCarga_ As Int32
    Private _Tipo As Short
    Private _NroConfirmacion As String

    Public Property IdProducto() As Int32
        Get
            Return IdProducto_
        End Get
        Set(ByVal value As Int32)
            IdProducto_ = value
        End Set
    End Property

    Public Property NroConfirmacion() As String
        Get
            Return _NroConfirmacion
        End Get
        Set(ByVal value As String)
            _NroConfirmacion = value
        End Set
    End Property

    Public Property NroCodigoBarra() As String
        Get
            Return NroCodigoBarra_
        End Get
        Set(ByVal value As String)
            NroCodigoBarra_ = value
        End Set
    End Property

    Public Property NroTarjeta() As String
        Get
            Return NroTarjeta_
        End Get
        Set(ByVal value As String)
            NroTarjeta_ = value
        End Set
    End Property

    Public Property ValorCarga() As Double
        Get
            Return ValorCarga_
        End Get
        Set(ByVal value As Double)
            ValorCarga_ = value
        End Set
    End Property

    Public Property Tipo() As Short
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Short)
            _Tipo = value
        End Set
    End Property
End Class


Public Class FormasPagoCanastilla
    Private IdFormaPago_ As Short
    Private Referencia_ As String
    Private Valor_ As Double
    Private TipoLectura_ As Integer
    Private NroConfirmacion_ As String

    Public Property IdFormaPago() As Short
        Get
            Return IdFormaPago_
        End Get
        Set(ByVal value As Short)
            IdFormaPago_ = value
        End Set
    End Property

    Public Property NroConfirmacion() As String
        Get
            Return NroConfirmacion_
        End Get
        Set(ByVal value As String)
            NroConfirmacion_ = value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return Referencia_
        End Get
        Set(ByVal value As String)
            Referencia_ = value
        End Set
    End Property

    Public Property Valor() As Double
        Get
            Return Valor_
        End Get
        Set(ByVal value As Double)
            Valor_ = value
        End Set
    End Property

    Public Property TipoLectura() As Integer
        Get
            Return TipoLectura_
        End Get
        Set(ByVal value As Integer)
            TipoLectura_ = value
        End Set
    End Property

End Class

Public Class RecargaPrepagoTemp
    Private _NumeroTarjeta As String
    Private _Consecutivo As String
    Private _IdFactura As Int64
    Private _Saldo As Int64
    Private _Pagos


    Public Property NumeroTarjeta() As String
        Get
            Return _NumeroTarjeta
        End Get
        Set(ByVal value As String)
            _NumeroTarjeta = value
        End Set
    End Property

    Public Property Consecutivo() As String
        Get
            Return _Consecutivo
        End Get
        Set(ByVal value As String)
            _Consecutivo = value
        End Set
    End Property

    Public Property IdFactura() As Int64
        Get
            Return _IdFactura
        End Get
        Set(ByVal value As Int64)
            _IdFactura = value
        End Set
    End Property

    Public Property Saldo() As Int64
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Int64)
            _Saldo = value
        End Set
    End Property

    Public Property Pagos() As Collection
        Get
            Return _Pagos
        End Get
        Set(ByVal value As Collection)
            _Pagos = value
        End Set
    End Property
End Class
