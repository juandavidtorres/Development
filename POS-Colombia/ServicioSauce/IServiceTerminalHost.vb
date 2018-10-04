Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.ComponentModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.


<ServiceContract()> _
Public Interface IServiceTerminalHost

    <OperationContract()> _
    Function RecuperarParametro(nombre As String) As String

    <OperationContract()> _
    Sub Predeterminar(tipo As Byte, Cara As Byte, Valor As String, Puerto As String)

    <OperationContract()> _
    Function SaldoTarjetaPrepago(NoTarjeta As String, Puerto As String) As String

    <OperationContract()> _
    Sub RealizarVentaCreditoTerpel(cara As Byte, kilometraje As String, puerto As String)

    <OperationContract()> _
    Sub EnviarCaraMenoCash(cara As Byte)

    <OperationContract()> _
    Function AplicaCDCTerpel() As Boolean

    <OperationContract()> _
    Function MovimientosPrepago(NoTarjeta As String, Puerto As String) As List(Of Movimiento)

    <OperationContract()> _
    Function DetalleMovimientos(NoTarjeta As String, Puerto As String) As DetalleMovimientos

    <OperationContract()> _
    Sub PredeterminarTarjeta(cara As Byte, noTarjeta As String, valor As String, puerto As String)

    <OperationContract()> _
    Sub ConsumirCombustible(cara As Byte, puerto As String)

    <OperationContract()> _
    Sub AdicionarDato(Cara As Byte, Informacion As String, EsPlaca As Boolean, esUltimaVenta As Boolean, Puerto As String)

    <OperationContract()> _
    Sub Calibrar(Manguera As Integer, Puerto As String)

    <OperationContract()> _
    Function RecuperarManguerasPorTurno(Usuario As String, Clave As String) As List(Of DTOManguera)

    <OperationContract()> _
    Function RecuperarTanquesCierreAutomatico(Usuario As String, Clave As String) As List(Of DTOTanque)

    <OperationContract()> _
    Sub ValidarAforoTanque(Tanque As DTOTanque, Puerto As String)

    <OperationContract()> _
    Sub AjustesPorOperacionCierreTurno(Usuario As String, Clave As String, Tanques As List(Of DTOTanque), Puerto As String)

    <OperationContract()> _
    Function EsAutoLecturaChipCredito() As Boolean

    <OperationContract()> _
    Sub RealizarVentaCredito(cara As Byte, identificador As String, idTipoIdentificacion As Integer, valorPredeterminado As String, puerto As String)

    <OperationContract()> _
    Sub RealizarVentaEfectivo(cara As Byte, Puerto As String)

    <OperationContract()> _
    Sub FidelizarVentaManual(usuario As String, clave As String, recibo As String, tarjeta As String, volumen As String, valor As String, fecha As String, ByRef puerto As String)


    <OperationContract()> _
    Sub EnviarDatos(ByVal cara As String, ByVal Documento As String, ByVal Puerto As String)

    <OperationContract()> _
    Function CarasEnTurnoAbiertoPorIsla(IdIsla As Int32) As System.Collections.Generic.List(Of DTOCara)

    <OperationContract()> _
    Function CarasEnTurnoAbierto() As System.Collections.Generic.List(Of DTOCara)

    <OperationContract()> _
    Function TipoIdentificacion() As System.Collections.Generic.List(Of DTOTipoIdentificacion)

    <OperationContract()> _
    Function ValidarCredencialesAdministrador(ByVal IdEmpleado As String, ByVal Clave As String, ByVal Puerto As String) As RespuestaValidacionUsuario

    <OperationContract()> _
    Function VerificarBonoSodexo(ByVal NroConfirmacion As String, ByVal IdFormaPago As String) As RespuestaVerificarBonoSodexo

    <OperationContract()> _
    Function ValidarCredenciales(ByVal IdEmpleado As String, ByVal Clave As String, ByVal EsTurnoAbierto As Boolean, ByVal Puerto As String) As RespuestaValidacionUsuario

    <OperationContract()> _
    Sub AbrirTurno(IdEmpleado As String, Password As String, Surtidores As List(Of DTOSurtidor), ByVal Puerto As String)

    <OperationContract()> _
    Function RecuperarSurtidoresEnTurnoAbierto() As List(Of DTOSurtidor)

    <OperationContract()> _
    Function RecuperarSurtidores() As List(Of DTOSurtidor)

    <OperationContract()> _
    Function RecuperarSurtidoresSinTurnoAbierto() As List(Of DTOSurtidor)

    <OperationContract()> _
    Sub AbrirTurnoApoyo(IdEmpleado As String, Password As String, TipoTurno As Int16, Puerto As String)

    <OperationContract()> _
    Sub CerrarTurnoPorSurtidor(IdEmpleado As String, Password As String, Surtidores As List(Of DTOSurtidor), Puerto As String)

    <OperationContract()> _
    Sub CerrarTurno(IdEmpleado As String, Password As String, Puerto As String, Key As String)


    <OperationContract()> _
    Function RecuperarSurtidoresPorEmpleadoEnTurno(idEmpleado As String) As List(Of DTOSurtidor)

    <OperationContract()> _
    Sub ImprimirUltimaVenta(Cara As String, Placa As String, puerto As String)

    <OperationContract()> _
    Sub ImprimirVentaConsecutivo(consecutivo As String, Placa As String, Puerto As String)

    <OperationContract()> _
    Sub ImprimirCopiaTurno(Turno As Byte, Fecha As String, Surtidor As Byte, Puerto As String)

    <OperationContract()> _
    Sub ImprimirCopiaTurnoFrecuencia(IdEmpleado As String, Fecha As String, Puerto As String)

    <OperationContract()> _
    Sub ImprimirCopiaEmpleado(IdEmpleado As String, Fecha As String, Puerto As String)

    <OperationContract()> _
    Sub ImprimirArqueo(IdEmpleado As String, Password As String, Puerto As String)

    <OperationContract()> _
    Function SeSolicitanCredenciales() As Boolean

    <OperationContract()> _
    Sub ImprimirTotalesDia(Fecha As String, Puerto As String)

    <OperationContract()> _
    Sub ImprimirDatosIdentificador(cara As Byte, Puerto As String)

    <OperationContract()> _
    Function ListarCaras() As System.Collections.Generic.List(Of DTOCara)

    <OperationContract()> _
    Function SolicitudDatosIbuttonImpresionArm(ByVal cara As Byte) As String


    <OperationContract()> _
    Sub CopiaFacturaProducto(Prefijo As String, Consecutivo As String, Puerto As String)

    <OperationContract()> _
    Function RecuperarProductoCanastilla(Codigo As String, isla As Integer) As DTOProducto

    <OperationContract()> _
    Function MediosPagosCanastilla() As List(Of DTOMedioPago)

    <OperationContract()> _
    Function GuardarFacturaCanastilla(ByVal NumeroTarjeta As String, ByVal TipoLectura As Byte, ByVal NroSeguridad As String, ListaProductos As List(Of DTOVentaCanastilla), Puerto As String) As RespuestaDescuento

    <OperationContract()> _
    Sub GuardarFacturaEfectivo(ByVal NumeroTarjeta As String, ByVal TipoLectura As Byte, ByVal NroSeguridad As String, ByVal ListaProductos As List(Of DTOVentaCanastilla), ByVal ListaMedios As List(Of DTOMedioPago), ByVal IdEmpleado As String, ByVal Password As String, ByVal Puerto As String)

    <OperationContract()>
    Sub GuardarFacturaCanastillaCredito(ByVal Cara As Byte, ByVal NumeroTarjeta As String, ByVal TipoLectura As Byte, ByVal NumeroAutorizacionManual As String, ByVal tipoIdentificacion As String, ListaProductos As List(Of DTOVentaCanastilla), IdEmpleado As String, Password As String, Puerto As String, ByVal MediosLectura As MediosLectura)

    <OperationContract()> _
    Sub PredeterminarCheque(Cara As Byte, NumAutorizacion As String, Placa As String, NumeroTarjeta As String, TipoLectura As Byte, NroSeguridad As String, _
                          NroAutorizacionManual As String, TipoIdentificacion As Short, Kilometraje As String, Puerto As String)

    <OperationContract()> _
    Function ManejaRedFidelizacion() As Short

    <OperationContract()> _
    Sub FidelizarVenta(Cara As Byte, NumeroTarjeta As String, IdRedFidelizacion As Short, Tipo As String, TipoVenta As String, Puerto As String)

    <OperationContract()> _
    Sub ConsultaPuntosFidelizados(NumeroTarjeta As String, Tipo As String, Puerto As String)


    <OperationContract()> _
    Function ValidarRedFidelizacionBono(Puerto As String)

    <OperationContract()> _
    Sub RealizarVentaConBonoSauce(CaraT As String, Tarjeta As String, TipoTarjeta As String, Puerto As String)

    <OperationContract()> _
    Function ConsultaRecibo(Recibo As String, Cara As String, EsUltimaVenta As Boolean) As RespuestaConsultaRecibo

    <OperationContract()> _
    Sub AplicarModificacionVenta(Recibo As String, ByVal ListaMedios As List(Of DTOMedioPago), ImprimirTicketModificacion As Boolean, puerto As String)

    <OperationContract()> _
    Function MediosPagos() As List(Of DTOMedioPago)

    <OperationContract()> _
    Sub PagoConBonoSauce(Ticket As String, NumeroTarjeta As String, TipoLectura As Byte, Puerto As String)

    <OperationContract()> _
    Function ValidarConsignacionesdeSobre(Puerto As String) As Boolean

    <OperationContract()> _
    Function MensajeConsignarCierreTurno(IdEmpleado As String, Password As String, esTDC As Boolean) As RespuestaConsignacion

    <OperationContract()> _
    Sub ConsignarCierreTurno(IdEmpleado As String, Password As String, oConsignaciones As List(Of DTOConsignacion), EsTurnoTrabajo As Boolean, EsCierreTurno As Boolean, Puerto As String)

    <OperationContract()> _
    Sub RemarcacionCanastilla(codigoBaja As String, Cantidad As String, CodigodeAlta As String, Puerto As String)

    <OperationContract()> _
    Function ValidarProductosCanastilla(CodigoCanastilla As String, CantidadCanastilla As String, Puerto As String) As String

    <OperationContract()> _
    Function RecuperarProductosCanastilla(codProducto As Integer, MotivoCalibracion As Byte)


    <OperationContract()> _
    Function IniciaTanques() As System.Collections.Generic.List(Of DTOTanque)

    <OperationContract()> _
    Sub EliminarPedidoCombustible(ByVal Documento As String)

    <OperationContract()> _
    Function ValidarConfiguracionCombustible(ByVal Puerto As String) As Integer


    <OperationContract()> _
    Function ConfigurarProductos(ByVal Documento As String, ByVal Placa As String) As RespuestaReciboCombustible


    <OperationContract()> _
    Function RecuperaProductosPorCodigoTanque(ByVal TanqueRecibo As String) As RespuestaReciboCombustible

    <OperationContract()> _
    Sub ValidarDocumentoReciboCombustibleColombia(ByVal Documento As String, ByVal Placa As String)


    <OperationContract()> _
    Sub AdicionarProductoADocumento(ByVal ProductosPedido As List(Of Productos), ByVal Documento As String, ByVal Placa As String)

    <OperationContract()> _
    Function InsertarDetalleReciboCombustible(ByVal ProductosRecibo As List(Of Productos), ByVal Documento As String, ByVal Placa As String) As List(Of ValidacionTanquesEnRecibo)

    <OperationContract()> _
    Function ValidarDocumentoReciboCombustible(ByVal Documento As String, ByVal Placa As String, ByVal Puerto As String, ByVal AplicaReciboAjustePorOperacion As Boolean) As RespuestaReciboCombustible

    <OperationContract()> _
    Function Tanques() As System.Collections.Generic.List(Of DTOTanque)

    <OperationContract()> _
    Function RecuperarProductosTanque(ByVal Codtanque As String) As System.Collections.Generic.List(Of Productos)

    <OperationContract()>
    Sub RemarcacionCombustible(ByVal tanqueBaja As String, ByVal productoBaja As Int16, ByVal cantidad As Decimal, TanqueAlta As String, ByVal productoAlta As Int16, puerto As String)


    <OperationContract()>
    Sub InsertarReciboCombustible(puerto As String)

    <OperationContract()>
    Sub ValidarTarjetaRecarga(ByVal NumeroTarjeta As String, ByVal Valor As String)

    <OperationContract()>
    Sub AnularFacturaCanastilla(ByVal Prefijo As String, ByVal Consecutivo As String, ByVal IdEmpleado As String, ByVal Password As String, ByVal Puerto As String)

    <OperationContract()>
    Sub ValidarIsleroAnulacion(ByVal IdEmpleado As String, ByVal Password As String)

    <OperationContract()>
    Sub ValidarIsleroCambioCheque(ByVal IdEmpleado As String, ByVal Password As String)

    <OperationContract()>
    Function ValidarCambioCheque(ByVal NumAutorizacion As String, ByVal ValorCheque As String, ByVal Recibo As String) As Decimal

    <OperationContract()>
    Sub InsertarCambioCheque(ByVal Valor As String, ByVal ValorCambio As String, ByVal NumAutorizacion As String, ByVal Recibo As String, ByVal Puerto As String)

    <OperationContract()>
    Function HayConexion() As Boolean

    <OperationContract()> _
    Function RecuperarMediosdePagoPrepago() As List(Of DTOMedioPago)

    <OperationContract()> _
    Sub RecargarTarjeta(Usuario As String, Clave As String, Recarga As RecargaPrepago, Puerto As String)

    <OperationContract()> _
    Function ValidarRedencioBono(ByVal NumeroTarjeta As String, ByVal TipoLectura As String, ByVal EsPorCara As Boolean, ByVal cara_recibo As String, ByVal puerto As String) As RespuestaValidarRedecionBono

    <OperationContract()> _
    Function Bonos() As System.Collections.Generic.List(Of DTOBono)

    <OperationContract()> _
    Sub PagarConBono(ByVal idBono As String, ByVal Numerotarjeta As String, ByVal Venta As DTOVenta, ByVal Impresora As String, ByVal usuario As String, ByVal clave As String)

    <OperationContract()> _
    Function AplicaFidelizacionPorNumeroTarjeta() As Boolean

    <OperationContract()> _
    Sub ImprimirCopiaRecargaPrepago(ByVal Consecutivo As String, ByVal Puerto As String)

    'Ajuste de Tanques Por VeederRoot
    <OperationContract()> _
    Sub CierreTanquesVeederRoot(ByVal Puerto As String)


    <OperationContract()>
    Function RealizarPagoInfoTaxi(Usuario As String, Clave As String, ByVal Placa As String, ByVal Movil As Int32, ByVal IdConcepto As Int32, ByVal CantidadPeriodos As Int32, ByVal Valor As Decimal, Recibo As String, Isla As String) As RespuestaGeneral
    <OperationContract()> _
    Function AbrirTurnoRecaudo(Usuario As String, Clave As String) As RespuestaGeneral

    <OperationContract()> _
    Function CopiaPagoFrecuencia(IdRecaudo As String, Isla As String) As RespuestaGeneral

    <OperationContract()> _
    Function CerrarTurnoFrecuencias(Usuario As String, Clave As String, Isla As String) As RespuestaGeneral
    <OperationContract()> _
    Function AuditoriaTurnoFrecuencias(Usuario As String, Clave As String, Isla As String) As RespuestaGeneral
End Interface


<DataContract()> _
Public Class DTOBono

    Private _IdBono As String
    <DataMember()> _
    Public Property IdBono As String
        Get
            Return _IdBono
        End Get
        Set(ByVal value As String)
            _IdBono = value
        End Set
    End Property

    Private _NombreBono As String
    <DataMember()> _
    Public Property NombreBono As String
        Get
            Return _NombreBono
        End Get
        Set(ByVal value As String)
            _NombreBono = value
        End Set
    End Property

    Private _TipoBono As String
    <DataMember()> _
    Public Property TipoBono As String
        Get
            Return _TipoBono
        End Get
        Set(ByVal value As String)
            _TipoBono = value
        End Set
    End Property

    Private _Puntos As String
    <DataMember()> _
    Public Property Puntos As String
        Get
            Return _Puntos
        End Get
        Set(ByVal value As String)
            _Puntos = value
        End Set
    End Property

    Private _Valor As String
    <DataMember()> _
    Public Property Valor As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property


End Class

<DataContract()> _
Public Class RespuestaValidarRedecionBono

    Private _Venta As DTOVenta
    <DataMember()> _
    Public Property Venta() As DTOVenta
        Get
            Return _Venta
        End Get
        Set(ByVal value As DTOVenta)
            _Venta = value
        End Set
    End Property

    Private _SaldoTarjeta As String
    <DataMember()> _
    Public Property SaldoTarjeta() As String
        Get
            Return _SaldoTarjeta
        End Get
        Set(ByVal value As String)
            _SaldoTarjeta = value
        End Set
    End Property

    Private _MensajeVenta As String
    <DataMember()> _
    Public Property MensajeVenta() As String
        Get
            Return _MensajeVenta
        End Get
        Set(ByVal value As String)
            _MensajeVenta = value
        End Set
    End Property

    Private _MensajeError As String
    <DataMember()> _
    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property

End Class


<DataContract()> _
Public Class DTOVenta

    Private _Recibo As String
    <DataMember()> _
    Public Property Recibo() As String
        Get
            Return _Recibo
        End Get
        Set(ByVal value As String)
            _Recibo = value
        End Set
    End Property

    Private _Fecha As String
    <DataMember()> _
    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Private _Precio As String
    <DataMember()> _
    Public Property Precio() As String
        Get
            Return _Precio
        End Get
        Set(ByVal value As String)
            _Precio = value
        End Set
    End Property

    Private _Cantidad As String
    <DataMember()> _
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property

    Private _Valor As String
    <DataMember()> _
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    Private _Placa As String
    <DataMember()> _
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Private _Manguera As String
    <DataMember()> _
    Public Property Manguera() As String
        Get
            Return _Manguera
        End Get
        Set(ByVal value As String)
            _Manguera = value
        End Set
    End Property

    Private _Producto As String
    <DataMember()> _
    Public Property Producto() As String
        Get
            Return _Producto
        End Get
        Set(ByVal value As String)
            _Producto = value
        End Set
    End Property

    Private _Descuento As String
    <DataMember()> _
    Public Property Descuento() As String
        Get
            Return _Descuento
        End Get
        Set(ByVal value As String)
            _Descuento = value
        End Set
    End Property

    Private _EsFidelizada As Boolean
    <DataMember()> _
    Public Property EsFidelizada() As Boolean
        Get
            Return _EsFidelizada
        End Get
        Set(ByVal value As Boolean)
            _EsFidelizada = value
        End Set
    End Property

    Private _EsFidelizadaLocal As Boolean
    <DataMember()> _
    Public Property EsFidelizadaLocal() As Boolean
        Get
            Return _EsFidelizadaLocal
        End Get
        Set(ByVal value As Boolean)
            _EsFidelizadaLocal = value
        End Set
    End Property

    Private _FechaProximoMantenimiento As String
    <DataMember()> _
    Public Property FechaProximoMantenimiento() As String
        Get
            Return _FechaProximoMantenimiento
        End Get
        Set(ByVal value As String)
            _FechaProximoMantenimiento = value
        End Set
    End Property

End Class


<DataContract()> _
Public Class RecargaPrepago
    Private _Tarjeta As String
    Private _Pagos As List(Of DTOMedioPago)
    Private _ValorRecarga As String


    <DataMember()> _
    Public Property Tarjeta() As String
        Get
            Return _Tarjeta
        End Get
        Set(ByVal value As String)
            _Tarjeta = value
        End Set
    End Property


    <DataMember()> _
    Public Property Pagos() As List(Of DTOMedioPago)
        Get
            Return _Pagos
        End Get
        Set(ByVal value As List(Of DTOMedioPago))
            _Pagos = value
        End Set
    End Property


    <DataMember()> _
    Public Property ValorRecarga() As String
        Get
            Return _ValorRecarga
        End Get
        Set(ByVal value As String)
            _ValorRecarga = value
        End Set
    End Property

End Class


<DataContract()> _
Public Class ValidacionTanquesEnRecibo

    Private _CodigoTanque As String

    <DataMember()> _
    Public Property CodigoTanque() As String
        Get
            Return _CodigoTanque
        End Get
        Set(ByVal value As String)
            _CodigoTanque = value
        End Set
    End Property

    Private _Mensaje As String

    <DataMember()> _
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

    Private _CapacidadTanque As String

    <DataMember()> _
    Public Property CapacidadTanque() As String
        Get
            Return _CapacidadTanque
        End Get
        Set(ByVal value As String)
            _CapacidadTanque = value
        End Set
    End Property

End Class



<DataContract()> _
Public Class Movimiento
    Private _Fecha As String
    Private _Valor As String
    Private _Tipo As String

    <DataMember()> _
    Public Property FechaHora() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    <DataMember()> _
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    <DataMember()> _
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class DetalleMovimientos
    Private _Cliente As String
    Private _Saldo As String


    <DataMember()> _
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    <DataMember()> _
    Public Property Saldo() As String
        Get
            Return _Saldo
        End Get
        Set(ByVal value As String)
            _Saldo = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class DTOManguera
    Private _IdManguera As Integer
    Private _Descripcion As String


    <DataMember()> _
    Public Property IdManguera As Integer
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Integer)
            _IdManguera = value
        End Set
    End Property

    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class Identificador
    Private _Id As String
    Private _Nombre As String

    <DataMember()> _
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    <DataMember()> _
    Public Property id() As String
        Get
            Return _Id
        End Get
        Set(ByVal value As String)
            _Id = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class DTOCara
    Private _IdCara As Integer

    <DataMember()> _
    Public Property IdCara As Integer
        Get
            Return _IdCara
        End Get
        Set(ByVal value As Integer)
            _IdCara = value
        End Set
    End Property

    Private _Descripcion As String

    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class DTOTipoIdentificacion
    Private _IdTipoIdentificacion As Integer

    <DataMember()> _
    Public Property IdTipoIdentificacion As Integer
        Get
            Return _IdTipoIdentificacion
        End Get
        Set(ByVal value As Integer)
            _IdTipoIdentificacion = value
        End Set
    End Property

    Private _Nombre As String

    <DataMember()> _
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class RespuestaValidacionUsuario
    <DataMember()> _
    Private _EsAutorizado As Boolean
    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    <DataMember()> _
    Private _Mensaje As String
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class RespuestaVerificarBonoSodexo
    <DataMember()> _
    Private _EsAutorizado As Boolean
    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    <DataMember()> _
    Private _Mensaje As String
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class DTOSurtidor
    Private _IdSurtidor As String

    Private _Descripcion As String



    <DataMember()> _
    Public Property IdSurtidor() As String
        Get
            Return _IdSurtidor
        End Get
        Set(ByVal value As String)
            _IdSurtidor = value
        End Set
    End Property

    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class DTOEmpleadoAutoservicio
    Private _IdEmpleado As String
    Private _Clave As String
    Private _IdTurno As String
    Private _SesionAbierta As Boolean
    Private _RespuestaCliente As String

    <DataMember()> _
    Public Property IdEmpleado() As String
        Get
            Return _IdEmpleado
        End Get
        Set(ByVal value As String)
            _IdEmpleado = value
        End Set
    End Property


    <DataMember()> _
    Public Property Clave() As String
        Get
            Return _Clave
        End Get
        Set(ByVal value As String)
            _Clave = value
        End Set
    End Property

    <DataMember()> _
    Public Property IdTurno() As String
        Get
            Return _IdTurno
        End Get
        Set(ByVal value As String)
            _IdTurno = value
        End Set
    End Property

    <DataMember()> _
    Public Property SesionAbierta() As Boolean
        Get
            Return _SesionAbierta
        End Get
        Set(ByVal value As Boolean)
            _SesionAbierta = value
        End Set
    End Property

    <DataMember()> _
    Public Property RespuestaCliente() As String
        Get
            Return _RespuestaCliente
        End Get
        Set(ByVal value As String)
            _RespuestaCliente = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class DTOTanque
    Private _IdTanque As String
    <DataMember()> _
    Public Property IdTanque As String
        Get
            Return _IdTanque
        End Get
        Set(ByVal value As String)
            _IdTanque = value
        End Set
    End Property

    Private _EsActivo As String
    <DataMember()> _
    Public Property EsActivo As String
        Get
            Return _EsActivo
        End Get
        Set(ByVal value As String)
            _EsActivo = value
        End Set
    End Property


    Private _Stock As String
    <DataMember()> _
    Public Property Stock As String
        Get
            Return _Stock
        End Get
        Set(ByVal value As String)
            _Stock = value
        End Set
    End Property


    Private _Descripcion As String
    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Private _CodigoTanque As String
    <DataMember()> _
    Public Property CodigoTanque() As String
        Get
            Return _CodigoTanque
        End Get
        Set(ByVal value As String)
            _CodigoTanque = value
        End Set
    End Property

    Private _CantidadAgua As String
    <DataMember()> _
    Public Property CantidadAgua() As String
        Get
            Return _CantidadAgua
        End Get
        Set(ByVal value As String)
            _CantidadAgua = value
        End Set
    End Property

    Private _Altura As String
    <DataMember()> _
    Public Property Altura() As String
        Get
            Return _Altura
        End Get
        Set(ByVal value As String)
            _Altura = value
        End Set
    End Property

    Private _DiferenciaEnInventario As String
    <DataMember()> _
    Public Property DiferenciaEnInventario() As String
        Get
            Return _DiferenciaEnInventario
        End Get
        Set(ByVal value As String)
            _DiferenciaEnInventario = value
        End Set
    End Property

    Private _ListaTanque As List(Of DTOTanque)
    Public Property ListaTanque() As List(Of DTOTanque)
        Get
            Return _ListaTanque
        End Get
        Set(ByVal value As List(Of DTOTanque))
            _ListaTanque = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class DTOProducto
    Private _Codigo As String
    <DataMember()> _
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _existencia As Integer
    <DataMember()> _
    Public Property Existencia() As Integer
        Get
            Return _existencia
        End Get
        Set(ByVal value As Integer)
            _existencia = value
        End Set
    End Property

    Private _Descripcion As String
    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Private _Valor As Decimal
    <DataMember()> _
    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(ByVal value As Decimal)
            _Valor = value
        End Set
    End Property

    Private _ManejaExistencia As Decimal
    <DataMember()> _
    Public Property ManejaExistencia() As Boolean
        Get
            Return _ManejaExistencia
        End Get
        Set(ByVal value As Boolean)
            _ManejaExistencia = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class Productos
    Private _Nombre As String
    Private _Codigo As String
    Private _Cantidad As String
    Private _EsLeyFrontera As String
    Private _Tanque As String
    Private _IdTanque As String

    <DataMember()> _
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    <DataMember()> _
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    <DataMember()> _
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property

    <DataMember()> _
    Public Property EsLeyFrontera() As String
        Get
            Return _EsLeyFrontera
        End Get
        Set(ByVal value As String)
            _EsLeyFrontera = value
        End Set
    End Property

    <DataMember()> _
    Public Property Tanque() As String
        Get
            Return _Tanque
        End Get
        Set(ByVal value As String)
            _Tanque = value
        End Set
    End Property

    <DataMember()> _
    Public Property IdTanque() As String
        Get
            Return _IdTanque
        End Get
        Set(ByVal value As String)
            _IdTanque = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class RespuestaDescuento

    <DataMember()> _
    Private _saldoVenta As String
    Public Property saldoVenta() As String
        Get
            Return _saldoVenta
        End Get
        Set(ByVal value As String)
            _saldoVenta = value
        End Set
    End Property

    <DataMember()> _
    Private _Mensaje As String
    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property
End Class

Public Class RespuestaConsultaRecibo

    <DataMember()> _
    Private _Recibo As String
    Public Property Recibo() As String
        Get
            Return _Recibo
        End Get
        Set(ByVal value As String)
            _Recibo = value
        End Set
    End Property

    <DataMember()> _
    Private _ValorRecibo As Double
    Public Property ValorRecibo() As Double
        Get
            Return _ValorRecibo
        End Get
        Set(ByVal value As Double)
            _ValorRecibo = value
        End Set
    End Property
End Class


<DataContract()> _
Public Class DTOMedioPago

    Private _IdMedioPago As String
    Private _NroConfirmacion As String
    Private _NroTarjeta As String
    Private _Valor As String


    Private _Descripcion As String
    <DataMember()> _
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property


    <DataMember()> _
    Public Property IdMedioPago() As String
        Get
            Return _IdMedioPago
        End Get
        Set(ByVal value As String)
            _IdMedioPago = value
        End Set
    End Property

    <DataMember()> _
    Public Property NroConfirmacion() As String
        Get
            Return _NroConfirmacion
        End Get
        Set(ByVal value As String)
            _NroConfirmacion = value
        End Set
    End Property


    <DataMember()> _
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    <DataMember()> _
    Public Property NroConfiNroTarjetarmacion() As String
        Get
            Return _NroTarjeta
        End Get
        Set(ByVal value As String)
            _NroTarjeta = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class DTOVentaCanastilla
    Private _Codigo As String
    Private _Cantidad As String

    <DataMember()> _
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    <DataMember()> _
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class RespuestaConsignacion
    Private _EsSobrante As Boolean
    Private _Valor As String
    Private _ValorFijo As String

    <DataMember()> _
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    <DataMember()> _
    Public Property valorFijo() As String
        Get
            Return _ValorFijo
        End Get
        Set(ByVal value As String)
            _ValorFijo = value
        End Set
    End Property


    <DataMember()> _
    Public Property EsSobrante As Boolean
        Get
            Return _EsSobrante
        End Get
        Set(ByVal value As Boolean)
            _EsSobrante = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class DTOConsignacion
    Private _IdTipo As String
    Private _Valor As String

    <DataMember()> _
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

    <DataMember()> _
    Public Property IdTipo() As String
        Get
            Return _IdTipo
        End Get
        Set(ByVal value As String)
            _IdTipo = value
        End Set
    End Property

End Class

<DataContract()> _
Public Class RespuestaReciboCombustible
    Private _EsPedidoLocal As Boolean

    <DataMember()> _
    Public Property EsPedidoLocal() As Boolean
        Get
            Return _EsPedidoLocal
        End Get
        Set(ByVal value As Boolean)
            _EsPedidoLocal = value
        End Set
    End Property

    Private _EsLeyFrontera As Boolean

    <DataMember()> _
    Public Property EsLeyFrontera() As Boolean
        Get
            Return _EsLeyFrontera
        End Get
        Set(ByVal value As Boolean)
            _EsLeyFrontera = value
        End Set
    End Property

    Private _EsDetenido As Boolean

    <DataMember()> _
    Public Property EsDetenido() As Boolean
        Get
            Return _EsDetenido
        End Get
        Set(ByVal value As Boolean)
            _EsDetenido = value
        End Set
    End Property

    Private _LstProductos As List(Of Productos)

    <DataMember()> _
    Public Property LstProductos() As List(Of Productos)
        Get
            Return _LstProductos
        End Get
        Set(ByVal value As List(Of Productos))
            _LstProductos = value
        End Set
    End Property

    Private _RealizarBloqueoTanque As Boolean

    <DataMember()> _
    Public Property RealizarBloqueoTanque() As Boolean
        Get
            Return _RealizarBloqueoTanque
        End Get
        Set(ByVal value As Boolean)
            _RealizarBloqueoTanque = value
        End Set
    End Property

    Private _PermiteVentaReciboComb As Boolean

    <DataMember()> _
    Public Property PermiteVentaReciboComb() As Boolean
        Get
            Return _PermiteVentaReciboComb
        End Get
        Set(ByVal value As Boolean)
            _PermiteVentaReciboComb = value
        End Set
    End Property

    Private _Documento As String

    <DataMember()> _
    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property

    Private _Placa As String

    <DataMember()> _
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property


End Class


<DataContract()> _
Public Class MediosLectura
    Private _Cara As Byte
    Private _NumeroTarjeta As String
    Private _TipoLectura As Byte
    Private _NroSeguridad As String
    Private _NroAutorizacionManual As String
    Private _TipoIdentificacion As Short

    <DataMember()> _
    Public Property Cara() As Byte
        Get
            Return _Cara
        End Get
        Set(ByVal value As Byte)
            _Cara = value
        End Set
    End Property

    <DataMember()> _
    Public Property NumeroTarjeta() As String
        Get
            Return _NumeroTarjeta
        End Get
        Set(ByVal value As String)
            _NumeroTarjeta = value
        End Set
    End Property

    <DataMember()> _
    Public Property TipoLectura() As Byte
        Get
            Return _TipoLectura
        End Get
        Set(ByVal value As Byte)
            _TipoLectura = value
        End Set
    End Property

    <DataMember()> _
    Public Property NroSeguridad() As String
        Get
            Return _NroSeguridad
        End Get
        Set(ByVal value As String)
            _NroSeguridad = value
        End Set
    End Property

    <DataMember()> _
    Public Property NroAutorizacionManual() As String
        Get
            Return _NroAutorizacionManual
        End Get
        Set(ByVal value As String)
            _NroAutorizacionManual = value
        End Set
    End Property

    <DataMember()> _
    Public Property TipoIdentificacion() As Short
        Get
            Return _TipoIdentificacion
        End Get
        Set(ByVal value As Short)
            _TipoIdentificacion = value
        End Set
    End Property
End Class

<DataContract()> _
Public Class RespuestaGeneral
    Private _EsAutorizado As Boolean
    <DataMember()> _
        Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    Private _Mensaje As String
    <DataMember()> _
        Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

End Class

