Imports POSstation.Fabrica
Imports POSstation.AccesoDatos

''' <summary>
''' Facilita el manejo de informacion referente a los recibos
''' </summary>
''' <remarks></remarks>
''' 
Public Class InformacionRecibo
    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String
    Private _Fecha As String
    Private _Hora As String
    Private _Numero As String
    Private _Placa As String
    Private _Turno As String
    Private _Isla As String
    Private _Cara As String
    Private _Manguera As String
    Private _PorcentajeRecaudo As String
    Private _NombreArticulo As String
    Private _Cantidad As String
    Private _Precio As String
    Private _Valor As String
    Private _Recaudo As String
    Private _Descuento As String
    Private _Total As String
    Private _FormaPago As String
    Private _FechaProximaRevision As String
    Private _SerialImpresora As String
    Private _Documento As String
    Private _Prefijo As String
    Private _Autorizacion As String
    Private _TipoDocumento As Integer
    Private _DocOriginal As String
    Private _RecaudoOpcional As String
    Private _ValorReversado As String
    Private _NombreEmpleado As String
    Private _Kilometraje As String
    Private _EsLecturaChipObligatoria As Boolean
    Private _UnidadMedida As String
    Private _EsImpresa As Boolean
    Private _EsRecuperada As Boolean
    Private _AtendidoPor As String
    Private _EsCredito As Boolean
    Private _CodigoVendedor As String
    Private _Cedula As String
    Private _NombreCliente As String
    Private _ValorCheque As String
    Private _NroAutorizacionCheque As String
    Private _NroCheque As String
    Private _Nivel As String
    Private _SaldoDisponible As Nullable(Of Decimal)

    Public Property SaldoDisponible() As Nullable(Of Decimal)
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _SaldoDisponible = value
        End Set
    End Property

    Public Property ValorCheque() As Decimal
        Get
            Return _ValorCheque
        End Get
        Set(ByVal value As Decimal)
            _ValorCheque = value
        End Set
    End Property
    Public Property NroAutorizacionCheque() As String
        Get
            Return _NroAutorizacionCheque
        End Get
        Set(ByVal value As String)
            _NroAutorizacionCheque = value
        End Set
    End Property
    Public Property NroCheque() As String
        Get
            Return _NroCheque
        End Get
        Set(ByVal value As String)
            _NroCheque = value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal value As String)
            _Cedula = value
        End Set
    End Property

    Public Property CodigoVendedor() As String
        Get
            Return _CodigoVendedor
        End Get
        Set(ByVal value As String)
            _CodigoVendedor = value
        End Set
    End Property

    Public Property EsCredito() As Boolean
        Get
            Return _EsCredito
        End Get
        Set(ByVal value As Boolean)
            _EsCredito = value
        End Set
    End Property

    Public Property AtendidoPor() As String
        Get
            Return _AtendidoPor
        End Get
        Set(ByVal value As String)
            _AtendidoPor = value
        End Set
    End Property

    Public Property EsRecuperada() As Boolean
        Get
            Return _EsRecuperada
        End Get
        Set(ByVal value As Boolean)
            _EsRecuperada = value
        End Set
    End Property

    Public Property EsImpresa() As Boolean
        Get
            Return _EsImpresa
        End Get
        Set(ByVal value As Boolean)
            _EsImpresa = value
        End Set
    End Property

    Public Property UnidadMedida() As String
        Get
            Return _UnidadMedida
        End Get
        Set(ByVal value As String)
            _UnidadMedida = value
        End Set
    End Property

    Public Property EsLecturaChipObligatoria() As Boolean
        Get
            Return _EsLecturaChipObligatoria
        End Get
        Set(ByVal value As Boolean)
            _EsLecturaChipObligatoria = value
        End Set
    End Property

    Public Property Kilometraje() As String
        Get
            Return _Kilometraje
        End Get
        Set(ByVal value As String)
            _Kilometraje = value
        End Set
    End Property

    Public Property NombreEmpleado() As String
        Get
            Return _NombreEmpleado
        End Get
        Set(ByVal value As String)
            _NombreEmpleado = value
        End Set
    End Property

    Public Property ValorReversado() As String
        Get
            Return _ValorReversado
        End Get
        Set(ByVal value As String)
            _ValorReversado = value
        End Set
    End Property

    Public Property RecaudoOpcional() As String
        Get
            Return _RecaudoOpcional
        End Get
        Set(ByVal value As String)
            _RecaudoOpcional = value
        End Set
    End Property

    Public Property DocOriginal() As String
        Get
            Return _DocOriginal
        End Get
        Set(ByVal value As String)
            _DocOriginal = value
        End Set
    End Property

    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property Turno() As String
        Get
            Return _Turno
        End Get
        Set(ByVal value As String)
            _Turno = value
        End Set
    End Property

    Public Property Isla() As String
        Get
            Return _Isla
        End Get
        Set(ByVal value As String)
            _Isla = value
        End Set
    End Property

    Public Property Cara() As String
        Get
            Return _Cara
        End Get
        Set(ByVal value As String)
            _Cara = value
        End Set
    End Property

    Public Property Manguera() As String
        Get
            Return _Manguera
        End Get
        Set(ByVal value As String)
            _Manguera = value
        End Set
    End Property

    Public Property NombreArticulo() As String
        Get
            Return _NombreArticulo
        End Get
        Set(ByVal value As String)
            _NombreArticulo = value
        End Set
    End Property

    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property

    Public Property Precio() As String
        Get
            Return _Precio
        End Get
        Set(ByVal value As String)
            _Precio = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    Public Property PorcentajeRecaudo() As String
        Get
            Return _PorcentajeRecaudo
        End Get
        Set(ByVal value As String)
            _PorcentajeRecaudo = value
        End Set
    End Property

    Public Property Recaudo() As String
        Get
            Return _Recaudo
        End Get
        Set(ByVal value As String)
            _Recaudo = value
        End Set
    End Property

    Public Property Descuento() As String
        Get
            Return _Descuento
        End Get
        Set(ByVal value As String)
            _Descuento = value
        End Set
    End Property

    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property

    Public Property FormaPago() As String
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As String)
            _FormaPago = value
        End Set
    End Property

    Public Property FechaProximaRevision() As String
        Get
            Return _FechaProximaRevision
        End Get
        Set(ByVal value As String)
            _FechaProximaRevision = value
        End Set
    End Property


    Public Property SerialImpresora() As String
        Get
            Return _SerialImpresora
        End Get
        Set(ByVal value As String)
            _SerialImpresora = value
        End Set
    End Property

    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property

    Public Property Prefijo() As String
        Get
            Return _Prefijo
        End Get
        Set(ByVal value As String)
            _Prefijo = value
        End Set
    End Property

    Public Property Autorizacion() As String
        Get
            Return _Autorizacion
        End Get
        Set(ByVal value As String)
            _Autorizacion = value
        End Set
    End Property

    Public Property TipoDocumento() As Integer
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As Integer)
            _TipoDocumento = value
        End Set
    End Property

    Public Property Nivel() As String
        Get
            Return _Nivel
        End Get
        Set(ByVal value As String)
            _Nivel = value
        End Set
    End Property

    Property ValorCambioPrecio As String

    Property EsDescuentoCliente As Boolean

    Property PorcentajeClienteCredito As Boolean

End Class

Public Class ImpresoraEstacion

    Private _Nombre As String
    Private _Puerto As String
    Private _ESCopia As Boolean = False
    Private _ESArqueo As Boolean = False


    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Puerto() As String
        Get
            Return _Puerto
        End Get
        Set(ByVal value As String)
            _Puerto = value
        End Set
    End Property

    Public Property ESCopia() As Boolean
        Get
            Return _ESCopia
        End Get
        Set(ByVal value As Boolean)
            _ESCopia = value
        End Set
    End Property

    Public Property ESArqueo() As Boolean
        Get
            Return _ESArqueo
        End Get
        Set(ByVal value As Boolean)
            _ESArqueo = value
        End Set
    End Property

    Public Sub New(ByVal puertoPrm As String)
        Dim OHelper As New Helper
        _Puerto = puertoPrm
        _Nombre = OHelper.RecuperarImpresoraPorPuertoCapturador(puertoPrm)
    End Sub


    Public Sub New(ByVal puertoPrm As String, ByVal esCopia As Boolean, ByVal esArqueo As Boolean)
        Dim OHelper As New Helper
        _Puerto = puertoPrm
        _ESCopia = esCopia
        _ESArqueo = esArqueo
        _Nombre = OHelper.RecuperarImpresoraPorPuertoCapturador(puertoPrm)
    End Sub

    Public Sub New(ByVal puertoPrm As String, ByVal esCopia As Boolean)
        Dim OHelper As New Helper
        _Puerto = puertoPrm
        _ESCopia = esCopia
        _Nombre = OHelper.RecuperarImpresoraPorPuertoCapturador(puertoPrm)
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal reciboPrm As Int64)
        Dim OHelper As New Helper
        _Nombre = OHelper.RecuperarImpresoraPorTiquete(reciboPrm)
    End Sub

    Public Sub New(ByVal reciboPrm As Int64, ByVal esCopia As Boolean)
        Dim OHelper As New Helper
        _Nombre = OHelper.RecuperarImpresoraPorTiquete(reciboPrm)
        _ESCopia = esCopia
    End Sub


    Public Shared Function CrearImpresoraPorTurno(ByVal turnoPrm As Int32) As ImpresoraEstacion
        Dim OHelper As New Helper
        Dim Impresora As New ImpresoraEstacion
        Impresora.Nombre = OHelper.RecuperarImpresoraPorTurno(turnoPrm)
        Return Impresora
    End Function


    Public Shared Function CrearImpresora(ByVal caraPrm As Int32) As ImpresoraEstacion
        Dim OHelper As New Helper
        Dim Impresora As New ImpresoraEstacion
        Impresora.Nombre = OHelper.RecuperarImpresoraPorCara(caraPrm)
        Return Impresora
    End Function

    Public Shared Function CrearImpresora() As ImpresoraEstacion
        Dim OHelper As New Helper
        Dim Impresora As New ImpresoraEstacion
        Impresora.Nombre = OHelper.RecuperarParametro("NombreImpresora")
        Return Impresora
    End Function

    Public Shared Function CrearImpresora(ByVal puertoPrm As String, ByVal esCopia As Boolean) As ImpresoraEstacion
        Dim OHelper As New Helper
        Dim Impresora As New ImpresoraEstacion
        Impresora.Puerto = puertoPrm
        Impresora.Nombre = OHelper.RecuperarImpresoraPorPuertoCapturador(puertoPrm)
        Impresora.ESCopia = esCopia
        Return Impresora
    End Function

    Public Shared Function CrearImpresoraPorRecibo(ByVal recibo As Int64, Optional ByVal esCopia As Boolean = False, Optional ByVal esVentaRegistrada As Boolean = True) As ImpresoraEstacion
        Dim OHelper As New Helper
        Dim Impresora As New ImpresoraEstacion
        Impresora.Nombre = OHelper.RecuperarImpresoraPorTiquete(recibo, esVentaRegistrada)
        Impresora.ESCopia = esCopia
        Return Impresora
    End Function
End Class

Public Class InformacionEncabezado
    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String

    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property
End Class

Public Class InformacionFactura
    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String
    Private _Fecha As String
    Private _Hora As String
    Private _Numero As String
    Private _Prefijo As String
    Private _Empleado As String
    Private _Total As String
    Private _Codigo As String
    Private _ClasificacionCliente As String
    Private _IdentificacionCliente As String
    Private _NombreCliente As String
    Private _FechaInicio As String
    Private _FechaFin As String
    Private _ClienteCredito As String
    Private _CodigoVendedor As String
    Private _AtendidoPor As String
    Private _Cedula As String


    Public Property Cedula As String
        Get
            Return _Cedula
        End Get
        Set(ByVal value As String)
            _Cedula = value
        End Set
    End Property

    Public Property CodigoVendedor As String
        Get
            Return _CodigoVendedor
        End Get
        Set(ByVal value As String)
            _CodigoVendedor = value
        End Set
    End Property

    Public Property AtendidoPor As String
        Get
            Return _AtendidoPor
        End Get
        Set(ByVal value As String)
            _AtendidoPor = value
        End Set
    End Property

    Public Property ClienteCredito() As String
        Get
            Return _ClienteCredito
        End Get
        Set(ByVal value As String)
            _ClienteCredito = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property FechaInicio() As String
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As String)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFin() As String
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As String)
            _FechaFin = value
        End Set
    End Property

    Public Property ClasificacionCliente() As String
        Get
            Return _ClasificacionCliente
        End Get
        Set(ByVal value As String)
            _ClasificacionCliente = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property

    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property Prefijo() As String
        Get
            Return _Prefijo
        End Get
        Set(ByVal value As String)
            _Prefijo = value
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

    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
End Class

Public Class InformacionReciboCanastilla


    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String
    Private _Fecha As String
    Private _Hora As String
    Private _Recibo As Int32
    Private _Empleado As String
    Private _Total As String
    Private _Codigo As String
    Private _ClasificacionCliente As String
    Private _IdentificacionCliente As String
    Private _NombreCliente As String
    Private _FechaInicio As String
    Private _FechaFin As String
    Private _ClienteCredito As String
    Friend Cedula As String

    Public Property ClasificacionCliente() As String
        Get
            Return _ClasificacionCliente
        End Get
        Set(ByVal value As String)
            _ClasificacionCliente = value
        End Set
    End Property

    Public Property IdentificacionCliente() As String
        Get
            Return _IdentificacionCliente
        End Get
        Set(ByVal value As String)
            _IdentificacionCliente = value
        End Set
    End Property

    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property

    Public Property Recibo() As Int32
        Get
            Return _Recibo
        End Get
        Set(ByVal value As Int32)
            _Recibo = value
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

    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(ByVal value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property FechaInicio() As String
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As String)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFin() As String
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As String)
            _FechaFin = value
        End Set
    End Property


    Public Property ClienteCredito() As String
        Get
            Return _ClienteCredito
        End Get
        Set(ByVal value As String)
            _ClienteCredito = value
        End Set
    End Property

End Class

Public Class Producto
    Private _Nombre As String

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _IdProducto As Integer
    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property

    Private _UnidadMedida As String

    Public Property UnidadMedida() As String
        Get
            Return _UnidadMedida
        End Get
        Set(ByVal value As String)
            _UnidadMedida = value
        End Set
    End Property

    Public Shared Function RecuperarListaProductos() As List(Of Producto)
        Dim Lista As New List(Of Producto)
        Dim OHelper As New Helper
        Dim OProductos As IDataReader = Nothing
        Try
            OProductos = OHelper.RecuperarProductos()
            While OProductos.Read
                Dim OProducto As New Producto
                OProducto.Nombre = OProductos.Item("Nombre").ToString
                OProducto.IdProducto = CInt(OProductos.Item("IdProducto"))
                OProducto.UnidadMedida = OProductos.Item("UnidadMedida").ToString
                Lista.Add(OProducto)
            End While
            OProductos.Close()
            OProductos = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function


End Class

Public Class Surtidor

    Private _IdSurtidor As Integer
    Private _IdIsla As Integer
    Private _IdProtocolo As Integer
    Private _Descripcion As String
    Private _DescripcionEstado As String

    Public Property IdIsla() As Integer
        Get
            Return _IdIsla
        End Get
        Set(ByVal value As Integer)
            _IdIsla = value
        End Set
    End Property
    Public Property IdSurtidor() As Integer
        Get
            Return _IdSurtidor
        End Get
        Set(ByVal value As Integer)
            _IdSurtidor = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property DescripcionEstado() As String
        Get
            Return _DescripcionEstado
        End Get
        Set(ByVal value As String)
            _DescripcionEstado = value
        End Set
    End Property
    Public Property IdProtocolo() As Integer
        Get
            Return _IdProtocolo
        End Get
        Set(ByVal value As Integer)
            _IdProtocolo = value
        End Set
    End Property

    Public Shared Function RecuperarListaSurtidoresPorTurno(ByVal idTurno As Integer) As List(Of Surtidor)
        Dim Lista As New List(Of Surtidor)
        Dim OHelper As New Helper
        Dim OSurtidores As IDataReader = Nothing
        Try
            OSurtidores = OHelper.RecuperarSurtidoresPorTurno(idTurno)

            While OSurtidores.Read
                Dim OSurtidor As New Surtidor
                OSurtidor.Descripcion = OSurtidores.Item("Descripcion").ToString
                OSurtidor.IdSurtidor = CInt(OSurtidores.Item("IdSurtidor"))
                OSurtidor.DescripcionEstado = CStr(OSurtidores.Item("DescripcionEstado"))

                Lista.Add(OSurtidor)
            End While
            OSurtidores.Close()
            OSurtidores = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function


End Class

Public Class Manguera

    Private _IdManguera As Integer
    Public Property IdManguera() As Integer
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Integer)
            _IdManguera = value
        End Set
    End Property
    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Shared Function RecuperarListaManguerasPorTurno(ByVal idTurno As Integer) As List(Of Manguera)
        Dim Lista As New List(Of Manguera)
        Dim OHelper As New Helper
        Dim OMangueras As IDataReader = Nothing
        Try
            OMangueras = OHelper.RecuperarManguerasPorTurno(idTurno)

            While OMangueras.Read
                Dim OManguera As New Manguera
                OManguera.Descripcion = OMangueras.Item("Descripcion").ToString
                OManguera.IdManguera = CInt(OMangueras.Item("IdManguera"))
                Lista.Add(OManguera)
            End While
            OMangueras.Close()
            OMangueras = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarListaMangueras() As List(Of Manguera)
        Dim Lista As New List(Of Manguera)
        Dim OHelper As New Helper
        Dim OMangueras As IDataReader = Nothing
        Try
            OMangueras = OHelper.RecuperarMangueras()

            While OMangueras.Read
                Dim OManguera As New Manguera
                OManguera.Descripcion = OMangueras.Item("Descripcion").ToString
                OManguera.IdManguera = CInt(OMangueras.Item("IdManguera"))
                Lista.Add(OManguera)
            End While
            OMangueras.Close()
            OMangueras = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

End Class


Public Class Lectura

    Private _IdLectura As Integer

    Public Property IdLectura() As Integer
        Get
            Return _IdLectura
        End Get
        Set(ByVal value As Integer)
            _IdLectura = value
        End Set
    End Property

    Private _LecturaInicial As Double
    Public Property LecturaInicial() As Double
        Get
            Return _LecturaInicial
        End Get
        Set(ByVal value As Double)
            _LecturaInicial = value
        End Set
    End Property
    Private _LecturaFinal As Double
    Public Property LecturaFinal() As Double
        Get
            Return _LecturaFinal
        End Get
        Set(ByVal value As Double)
            _LecturaFinal = value
        End Set
    End Property

    Public Shared Function RecuperarLecturasManguerasTurno(ByVal idTurno As Integer, ByVal idManguera As Integer) As List(Of Lectura)
        Dim Lista As New List(Of Lectura)
        Dim OHelper As New Helper
        Dim OLecturas As IDataReader = Nothing
        Try
            OLecturas = OHelper.RecuperarLecturasPorMangueraTurno(idTurno, idManguera)
            While OLecturas.Read
                Dim OLectura As New Lectura
                OLectura.LecturaInicial = CDbl(OLecturas.Item(0))
                OLectura.LecturaFinal = CDbl(OLecturas.Item(1))
                Lista.Add(OLectura)
            End While
            OLecturas.Close()
            OLecturas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarLecturasManguerasFecha(ByVal fecha As String, ByVal idManguera As Integer) As List(Of Lectura)
        Dim Lista As New List(Of Lectura)
        Dim OHelper As New Helper
        Dim OLecturas As IDataReader = Nothing
        Try
            OLecturas = OHelper.RecuperarLecturasPorMangueraFecha(idManguera, fecha)
            While OLecturas.Read
                Dim OLectura As New Lectura
                OLectura.LecturaInicial = CDbl(OLecturas.Item(0))
                OLectura.LecturaFinal = CDbl(OLecturas.Item(1))
                Lista.Add(OLectura)
            End While
            OLecturas.Close()
            OLecturas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

End Class

Public Class CanastillaTurno

    Private _Numero As String
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Private _Hora As String
    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property

    Private _Total As Double
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property
    Private _Iva As Double
    Public Property Iva() As Double
        Get
            Return _Iva
        End Get
        Set(ByVal value As Double)
            _Iva = value
        End Set
    End Property
    Public Shared Function RecuperarVentasCanastillaTurno(ByVal idTurno As Integer, ByVal idFormaPago As Integer) As List(Of CanastillaTurno)
        Dim Lista As New List(Of CanastillaTurno)
        Dim OHelper As New Helper
        Dim OVentas As IDataReader = Nothing
        Try
            OVentas = OHelper.RecuperarVentasCanastillaPorTurno(idTurno, idFormaPago)
            While OVentas.Read
                Dim OVentaTurno As New CanastillaTurno
                OVentaTurno.Hora = OVentas.Item("Hora").ToString
                OVentaTurno.Numero = OVentas.Item("Numero").ToString
                OVentaTurno.Total = CDec(OVentas.Item("Total"))
                OVentaTurno.Iva = CDec(OVentas.Item("Iva"))
                Lista.Add(OVentaTurno)
            End While
            OVentas.Close()
            OVentas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

End Class

Public Class Financiera

    Private _IdFinanciera As Integer
    Public Property IdFinanciera() As Integer
        Get
            Return _IdFinanciera
        End Get
        Set(ByVal value As Integer)
            _IdFinanciera = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Shared Function RecuperarFinancieras() As List(Of Financiera)
        Dim Lista As New List(Of Financiera)
        Dim OHelper As New Helper
        Dim OFinancieras As IDataReader = Nothing
        Try
            OFinancieras = OHelper.RecuperarEntidadesFinancieras()
            While OFinancieras.Read
                Dim OFinanciera As New Financiera
                OFinanciera.IdFinanciera = CInt(OFinancieras.Item("IdFinanciera"))
                OFinanciera.Descripcion = OFinancieras.Item("Nombre").ToString
                Lista.Add(OFinanciera)
            End While
            OFinancieras.Close()
            OFinancieras = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function
End Class

Public Class VentaTurno

    Private _Recibo As Long
    Public Property Recibo() As Long
        Get
            Return _Recibo
        End Get
        Set(ByVal value As Long)
            _Recibo = value
        End Set
    End Property
    Private _Placa As String
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property
    Private _Hora As String
    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property
    Private _Cantidad As Double
    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property
    Private _Total As Double
    Public Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property

    Private _AbonoCredito As Double
    Public Property AbonoCredito() As Double
        Get
            Return _AbonoCredito
        End Get
        Set(ByVal value As Double)
            _AbonoCredito = value
        End Set
    End Property

    Public Shared Function RecuperarListaVentasTurnoPorSurtidor(ByVal idTurno As Integer, ByVal idSurtidor As Integer, ByVal idFormaPago As Integer, ByVal idProducto As Integer) As List(Of VentaTurno)
        Dim Lista As New List(Of VentaTurno)
        Dim OHelper As New Helper
        Dim OVentas As IDataReader = Nothing
        Try
            OVentas = OHelper.RecuperarVentasPorTurnoSurtidor(idTurno, idSurtidor, idFormaPago, idProducto)

            While OVentas.Read
                Dim OVentaTurno As New VentaTurno
                OVentaTurno.Recibo = CLng(OVentas.Item(0))
                OVentaTurno.Placa = OVentas.Item(1).ToString
                OVentaTurno.Hora = OVentas.Item(2).ToString
                OVentaTurno.Cantidad = CDbl(OVentas.Item(3))
                OVentaTurno.Total = CDbl(OVentas.Item(4))
                Lista.Add(OVentaTurno)
            End While
            OVentas.Close()
            OVentas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarVentasReacaudoTurno(ByVal idTurno As Integer, ByVal idFinanciera As Integer) As List(Of VentaTurno)
        Dim Lista As New List(Of VentaTurno)
        Dim OHelper As New Helper
        Dim OVentas As IDataReader = Nothing
        Try
            OVentas = OHelper.RecuperarRecaudosPorTurno(idTurno, idFinanciera)

            While OVentas.Read
                Dim OVentaTurno As New VentaTurno
                OVentaTurno.Recibo = CLng(OVentas.Item("Recibo"))
                OVentaTurno.Placa = OVentas.Item("Placa").ToString
                OVentaTurno.Hora = OVentas.Item("Hora").ToString
                OVentaTurno.AbonoCredito = CDbl(OVentas.Item("AbonoCredito"))
                Lista.Add(OVentaTurno)
            End While
            OVentas.Close()
            OVentas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function
End Class

Public Class Empleado
    Private _IdEmpleado As Integer
    Public Property IdEmpleado() As Integer
        Get
            Return _IdEmpleado
        End Get
        Set(ByVal value As Integer)
            _IdEmpleado = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Descripcion() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Shared Function RecuperarFormasPagoPorTurnoEmpleado(ByVal idTurno As Integer) As List(Of FormaPago)
        Dim Lista As New List(Of FormaPago)
        Dim OHelper As New Helper
        Dim OFormaPago As IDataReader = Nothing
        Try
            OFormaPago = OHelper.RecuperarFormasPagoPorTurnoEmpleado(idTurno)

            While OFormaPago.Read
                Dim OForma As New FormaPago
                OForma.IdFormaPago = CInt(OFormaPago.Item("IdFormaPago").ToString)
                OForma.Descripcion = OFormaPago.Item("Descripcion")
                Lista.Add(OForma)
            End While
            OFormaPago.Close()
            OFormaPago = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarListaEmpleadosVendedores(ByVal idTurno As Integer) As List(Of Empleado)
        Dim Lista As New List(Of Empleado)
        Dim OHelper As New Helper
        Dim OEmpleados As IDataReader = Nothing
        Try
            OEmpleados = OHelper.RecuperarEmpleadosVendoresPorTurno(idTurno)

            While OEmpleados.Read
                Dim OEmpleado As New Empleado
                OEmpleado.Descripcion = OEmpleados.Item("Nombre").ToString
                OEmpleado.IdEmpleado = CInt(OEmpleados.Item("IdEmpleadoVendedor"))
                Lista.Add(OEmpleado)
            End While
            OEmpleados.Close()
            OEmpleados = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarListaVentasTurnoEmpleadoSurtidor(ByVal idTurno As Integer, ByVal idSurtidor As Integer, ByVal idFormaPago As Integer, ByVal idProducto As Integer, ByVal IdEmpleado As Integer) As List(Of VentaTurno)
        Dim Lista As New List(Of VentaTurno)
        Dim OHelper As New Helper
        Dim OVentas As IDataReader = Nothing
        Try
            OVentas = OHelper.RecuperarVentasPorTurnoEmpleadoSurtidor(idTurno, idSurtidor, idFormaPago, idProducto, IdEmpleado)

            While OVentas.Read
                Dim OVentaTurno As New VentaTurno
                OVentaTurno.Recibo = CLng(OVentas.Item(0))
                OVentaTurno.Placa = OVentas.Item(1).ToString
                OVentaTurno.Hora = OVentas.Item(2).ToString
                OVentaTurno.Cantidad = CDbl(OVentas.Item(3))
                OVentaTurno.Total = CDbl(OVentas.Item(4))
                Lista.Add(OVentaTurno)
            End While
            OVentas.Close()
            OVentas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarListaFormasPagoTurnoEmpleado(ByVal idTurno As Integer, ByVal idSurtidor As Integer, ByVal IdEmpleado As Integer) As List(Of FormaPago)
        Dim Lista As New List(Of FormaPago)
        Dim OHelper As New Helper
        Dim OFormas As IDataReader = Nothing
        Try
            OFormas = OHelper.RecuperarFormasPagoPorTurno(idTurno, idSurtidor)

            While OFormas.Read
                Dim OFormaPago As New FormaPago
                OFormaPago.Descripcion = OFormas.Item("Descripcion").ToString
                OFormaPago.IdFormaPago = CInt(OFormas.Item("IdFormaPago"))
                Lista.Add(OFormaPago)
            End While

            OFormas.Close()
            OFormas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function
End Class

Public Class FormaPago

    Private _IdFormaPago As Integer
    Public Property IdFormaPago() As Integer
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Integer)
            _IdFormaPago = value
        End Set
    End Property
    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Shared Function RecuperarListaFormasPagoTurno(ByVal idTurno As Integer, ByVal idSurtidor As Integer) As List(Of FormaPago)
        Dim Lista As New List(Of FormaPago)
        Dim OHelper As New Helper
        Dim OFormas As IDataReader = Nothing
        Try
            OFormas = OHelper.RecuperarFormasPagoPorTurno(idTurno, idSurtidor)

            While OFormas.Read
                Dim OFormaPago As New FormaPago
                OFormaPago.Descripcion = OFormas.Item("Descripcion").ToString
                OFormaPago.IdFormaPago = CInt(OFormas.Item("IdFormaPago"))
                Lista.Add(OFormaPago)
            End While

            OFormas.Close()
            OFormas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function

    Public Shared Function RecuperarListaFormasPagoCanastilla(ByVal idTurno As Integer) As List(Of FormaPago)
        Dim Lista As New List(Of FormaPago)
        Dim OHelper As New Helper
        Dim OFormas As IDataReader = Nothing
        Try
            OFormas = OHelper.RecuperarFormasPagoCanastillaPorTurno(idTurno)

            While OFormas.Read
                Dim OFormaPago As New FormaPago
                OFormaPago.Descripcion = OFormas.Item("Descripcion").ToString
                OFormaPago.IdFormaPago = CInt(OFormas.Item("IdFormaPago"))
                Lista.Add(OFormaPago)
            End While
            OFormas.Close()
            OFormas = Nothing
        Catch ex As SqlClient.SqlException
            Throw
        Catch ex As System.Exception
            Throw
        End Try
        Return Lista
    End Function
End Class