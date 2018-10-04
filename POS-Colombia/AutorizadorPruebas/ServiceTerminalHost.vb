Imports System.ServiceModel
Imports POSstation.Fabrica
Imports POSstation.FabricaCanastilla
Imports POSstation
Imports POSstation.AccesoDatos
Imports POSstation.AccesoDatos.Helper
Imports System.IO
Imports System.Text
Imports POSstation.Protocolos


<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single)> _
Public Class ServiceTerminalHost
    Implements IServiceTerminalHost

    Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
    Dim Categoria As String = "AnomaliaService"
    Dim oFactura As Factura
    Dim IdDocumento As Long = 0
    Dim CodigoCanastilla As String
    Dim CantidadCanastilla As Short
    Dim OReciboCombustible As ReciboDeCombustible
    Dim CodigoTanque As String = "-1"
    Dim IdTurnoCombustible As String = "-1"
    Dim IdTurno As String
    Dim Cara As String = 0



#Region "Definicion de Eventos"
    'Public Event oEventos_AperturaTurno(ByRef empleadoPrm As String, ByRef clavePrm As String, ByRef surtidoresPrm As String, ByRef LecturaTeleCorrector As String, ByRef puertoPrm As String, ByRef IsArmPos As Boolean)

    Public Event oEventos_Preset(cara As Byte, valor As String, tipo As Byte, idProducto As Short, puerto As String)
    Public Event oEventos_ImprimirSaldoTarjetaPrepago(ByRef Puerto As String, ByRef Saldo As String)
    Public Event oEventos_ImprimirMovimientosPrepago(ByRef Tarjeta As String, ByRef Puerto As String)
    Public Event oEventos_AutorizarVentaPrepago(ByRef Cara As Byte, ByRef tarjeta As String, ByRef Valor As Double, ByRef puerto As String, ByRef Kilometraje As String)
    Public Event oEventos_EnvioVentaConsumoCombustible(ByRef cara As Byte, ByRef puerto As String)
    Public Event oEventos_RegistrarPlaca(cara As Byte, placa As String, esUltimaVenta As Boolean, puerto As String)
    Public Event oEventos_GuardarKilometraje(ByRef cara As Byte, ByRef kilometraje As String, ByRef esUltimaVenta As Boolean, ByRef puerto As String)
    Public Event oEventos_Calibracion(ByRef cara As Byte, ByRef manguera As Integer, ByRef idMotivo As Short, ByRef aplicaMotivo As Boolean, ByRef puerto As String)
    Public Event oEventos_EnviarAlturasCierreDeTanques(ByRef usuario As String, ByRef clave As String, ByRef Tanques As List(Of DTOTanque), ByRef EsAjustePorAlturas As Boolean, ByRef puerto As String)
    Public Event oEventos_VentaCredito(ByRef cara As Byte, ByRef kilometraje As String, ByRef puerto As String, ByRef identificador As String, ByRef IdTipoIdentificacion As Integer, ByRef ValorPredeterminado As String)
    Public Event oEventos_ReportarPagoEfectivo(ByRef cara As Byte)
    Public Event oEventos_FidelizarVentaManual(ByRef Recibo As String, ByRef Tarjeta As String, ByRef Valor As String, ByRef Cantidad As String, ByRef Idturno As Integer, ByRef Empleado As String, ByRef puerto As String, ByRef Fecha As String)

    Public Event oEventos_EnviarDatos(ByVal cara As String, ByVal Documento As String, ByVal Puerto As String)
    Public Event oEventos_AperturaTurno(empleadoPrm As String, clavePrm As String, surtidoresPrm As String, puertoPrm As String)
    Public Event oEventos_AperturaTurnoTrabajo(IdEmpleado As String, Password As String, TipoTurno As Int16, Puerto As String)
    Public Event oEventos_CerrarTurno(IdEmpleado As String, Password As String, Puerto As String, Surtidores As String)
    Public Event oEventos_ReportarExcepcion(Mensaje As String, Imprime As Boolean, Imprime As Boolean, Vacio As String)
    Public Event oEventos_SolicitarRegistrarPlaca(Cara As String, placa As String, EsUltimaVenta As Boolean, puerto As String)
    Public Event oEventos_ReimprimirDocumentoPorNumero(Consecutivo As String, Puerto As String, Original As Boolean)
    Public Event oEventos_ReimprimirTurnoPorSurtidor(Turno As Byte, Fecha As String, Surtidor As Byte, Puerto As String)
    Public Event oEventos_ReimprimirTurnoPorEmpleado(IdEmpleado As String, Fecha As String, Puerto As String)
    Public Event oEventos_ImprimirArqueo(cedula As String, clave As String, puerto As String)
    Public Event oEventos_ImprimirResumenDiario(Fecha As String, EsMrCombustible As Boolean, puerto As String)
    Public Event oEventos_SolicitudDatosIbutton(cara As Byte, Puerto As String)
    Public Event oEventos_SolicitudDatosIbuttonImpresionArm(ByVal cara As Byte, ByRef datos As String)
    Public Event oEventos_ReImprimirCopiaFacturaProductosServicios(Prefijo As String, Consecutivo As String, Puerto As String)
    Public Event OEventos_ImprimirVentaCanastilla(ByVal recibo As String, ByVal puerto As String)
    Public Event OEventos_ImprimirFacturaCanastillaUnica(ByRef idFactura As String, ByRef puerto As String)
    Public Event oEventos_AutorizarVentaCheque(Cara As Byte, numeroAutorizacionCheque As String, tarjeta As String, TipoLectura As Byte, NroSeguridad As String, TipoIdentificacion As Short, kilometraje As String, NumAutorizacionManual As String, placa As String, EsVentaCredito As Boolean, puerto As String)
    Public Event oEventos_FidelizarUltimaVenta(Cara As Byte, NumeroTarjeta As String, IdRedFidelizacion As Short, Puerto As String, Rut As String)
    Public Event oEventos_FidelizarVenta(Cara As Byte, NumeroTarjeta As String, IdRedFidelizacion As Short, Puerto As String, Rut As String)
    Public Event oEventos_ConsultarSaldoTarjetaFidelizacion(NumeroTarjeta As String, Puerto As String, Rut As String)
    Public Event oEventos_PredeterminarPagoVentaBonoFidelizacion(Cara As Byte, Tarjeta As String, Puerto As String)
    Public Event oEventos_SolicitarModificacionVenta(ByRef recibo As Integer, ByRef FormasPago As System.Array, ByRef puerto As String)
    Public Event OEventos_RedencionBonosFidelizacion(NumeroTarjeta As String, recibo As String, Puerto As String)
    Public Event oEventos_EnviarRemarcacionCanastilla(Cod As String, cant As Double, codigo As String, Puerto As String)
    Public Event OEventos_InformarCierreConsignaciones(ByRef cedula As String, ByRef clave As String, ByRef ColConsignacion As List(Of DTOConsignacion), ByRef aplicaConsignacion As Boolean, ByRef puerto As String)
    Public Event OEventos_EnviarRemarcaciones(ByRef codTanqueBaja As String, ByRef productoBaja As Byte, ByRef cantidadRemarcar As Double, ByRef codTanqueAlta As String, ByRef productoAlta As Byte, ByRef puerto As String)
    Public Event OEventos_ImprimirDocumentoReciboCombustible(Documento As String, cantidad As Double, puerto As String)
    Public Event oEventos_AnularFacturaCanastilla(ByVal Prefijo As String, ByVal consecutivo As String, ByVal IdEmpleado As String, ByVal Password As String, ByVal Puerto As String)
    Public Event oEventos_EnviarCambioCheque(ByVal NumAutorizacion As String, ByVal tempTurno As Int32, ByVal Cara As Byte, ByVal Recibo As String, ByVal ValorCambio As Double, ByVal Valor As Double, ByVal Puerto As String)
    Public Event oEventos_ImprimirRecargaPrepago(idCupo As Integer, Puerto As String)
    Public Event oEventos_reImprimirRecargaPrepago(idCupo As Integer, Puerto As String)
    Public Event oEventos_VentaCreditoCanastilla(ByVal MCIdentificacion As MedioCredito, ByVal MCCanastilla As ColCanastilla, ByVal IdEmpleado As String, ByVal Password As String, ByVal puerto As String)
    Public Event OEventos_PagarVentaConBono(ByVal IdBono As String, ByVal Numerotarjeta As String, ByVal Venta As DTOVenta, ByVal puerto As String, ByVal usuario As String, ByVal clave As String)
    Public Event oEventos_VentaCreditoTerpel(ByRef cara As Byte, ByRef kilometraje As String, ByRef puerto As String)
    Public Event oEventos_EnviarDatosMenoCash(cara As Byte)
#End Region

    Sub EnviarDatos(ByVal cara As String, ByVal Documento As String, ByVal Puerto As String) Implements IServiceTerminalHost.EnviarDatos
        Dim oHelper As New Helper

        Try
            If Convert.ToBoolean(oHelper.ExisteConductor(Documento)) Then
                RaiseEvent oEventos_EnviarDatos(cara, Documento, Puerto)
            Else
                Throw New System.Exception("El conductor con Documento: " & Documento & " No existe en la Base de Datos")
            End If

        Catch ex As System.Exception
            Throw
        End Try

    End Sub

    Public Function CarasEnTurnoAbiertoPorIsla(ByVal IdIsla As Int32) As System.Collections.Generic.List(Of DTOCara) Implements IServiceTerminalHost.CarasEnTurnoAbiertoPorIsla
        Dim lista As New List(Of DTOCara)
        Dim lector As IDataReader = Nothing
        Dim oHelper As New Helper
        Try

            Dim oCara As DTOCara
            lector = oHelper.RecuperarCarasConTurnosAbiertosPorIsla(IdIsla)

            While lector.Read
                oCara = New DTOCara
                oCara.IdCara = CInt(lector("IdCara").ToString())
                oCara.Descripcion = (lector("Descripcion").ToString())
                lista.Add(oCara)
            End While
            lector.Close()
            lector.Dispose()
        Catch ex As System.Exception

            Throw
        End Try
        Return lista
    End Function

    Public Function CarasEnTurnoAbierto() As System.Collections.Generic.List(Of DTOCara) Implements IServiceTerminalHost.CarasEnTurnoAbierto
        Dim lista As New List(Of DTOCara)
        Dim lector As IDataReader = Nothing
        Dim oHelper As New Helper
        Try

            Dim oCara As DTOCara
            lector = oHelper.RecuperarCarasEnTurnoAbierto()

            While lector.Read
                oCara = New DTOCara
                oCara.IdCara = CInt(lector("IdCara").ToString())
                oCara.Descripcion = (lector("Descripcion").ToString())
                lista.Add(oCara)
            End While
            lector.Close()
            lector.Dispose()
        Catch ex As System.Exception

            Throw
        End Try
        Return lista
    End Function

    Public Function TipoIdentificacion() As System.Collections.Generic.List(Of DTOTipoIdentificacion) Implements IServiceTerminalHost.TipoIdentificacion
        Dim lista As New List(Of DTOTipoIdentificacion)
        Dim lector As IDataReader = Nothing
        Dim oHelper As New Helper
        Try

            Dim oTipoIdentificacion As DTOTipoIdentificacion
            lector = oHelper.RecuperarTipoIdentificacion()

            While lector.Read
                oTipoIdentificacion = New DTOTipoIdentificacion
                oTipoIdentificacion.IdTipoIdentificacion = CInt(lector("IdTipoIdentificacion").ToString())
                oTipoIdentificacion.Nombre = (lector("Nombre").ToString())
                lista.Add(oTipoIdentificacion)
            End While
            lector.Close()
            lector.Dispose()
        Catch ex As System.Exception
            Throw
        End Try
        Return lista
    End Function


    Public Function ConsultaRecibo(Recibo As String, Cara As String, EsUltimaVenta As Boolean) As RespuestaConsultaRecibo Implements IServiceTerminalHost.ConsultaRecibo
        Dim Respuesta As New RespuestaConsultaRecibo
        Dim oHelper As New Helper

        Try
            Respuesta.Recibo = Recibo
            If EsUltimaVenta Then
                Respuesta.Recibo = oHelper.RecuperarUltimoReciboCara(Convert.ToByte(Cara))
            End If
            Respuesta.ValorRecibo = oHelper.RecuperarValorPorRecibo(Convert.ToInt64(Respuesta.Recibo))
        Catch ex As System.Exception
            oHelper.InsertarCambioFormaPagoFallida("", Recibo, Cara, ex.Message)
            Throw
        End Try
        Return Respuesta
    End Function

    Public Sub AplicarModificacionVenta(Recibo As String, ByVal ListaMedios As List(Of DTOMedioPago), ImprimirTicketModificacion As Boolean, puerto As String) Implements IServiceTerminalHost.AplicarModificacionVenta
        Dim oHelper As New Helper
        Dim oModificarVenta As New VentaModificada()
        Try

            oModificarVenta.Recibo = Recibo
            Dim Pago As MediosPagos
            For Each oPago As DTOMedioPago In ListaMedios
                Pago = New MediosPagos
                Pago.IdFormaPago = oPago.IdMedioPago
                Pago.NroConfirmacion = oPago.NroConfirmacion
                Pago.NroTarjeta = ""
                Pago.Valor = oPago.Valor
                Pago.TipoLectura = "0"
                oModificarVenta.GuardarPagosGenerales(Pago)
            Next
            Dim ArrayPagos As System.Array = oModificarVenta.GetArrayPagos()

            oHelper.EliminarMediosPago(Recibo)
            oHelper.ModificarVenta(oModificarVenta)

            If ImprimirTicketModificacion Then
                If ArrayPagos Is Nothing Then
                    Dim Original As Boolean = True
                    RaiseEvent oEventos_ReimprimirDocumentoPorNumero(Recibo, puerto, Original)
                Else
                    RaiseEvent oEventos_SolicitarModificacionVenta(Recibo, ArrayPagos, puerto)
                End If
            End If


        Catch ex As System.Exception
            For Each FormaPago As DTOMedioPago In ListaMedios
                oHelper.InsertarCambioFormaPagoFallida(FormaPago.Descripcion, Recibo, Cara, ex.Message)
            Next
            Throw
        End Try
    End Sub

    Public Function MediosPagos() As List(Of DTOMedioPago) Implements IServiceTerminalHost.MediosPagos
        Dim oHelper As New Helper
        Dim lista As New List(Of DTOMedioPago)
        Try

            Dim Formas As DataTable = oHelper.RecuperarFomaPagoActivas()
            Dim oValor As DTOMedioPago
            For Each FormaPago As DataRow In Formas.Rows
                oValor = New DTOMedioPago
                oValor.IdMedioPago = CStr(FormaPago.Item("IdFormaPago"))
                oValor.Descripcion = (CStr(FormaPago.Item("Descripcion")))
                lista.Add(oValor)
            Next

        Catch ex As System.Exception
            Throw
        End Try
        Return lista
    End Function

    Function ValidarCredencialesAdministrador(ByVal IdEmpleado As String, ByVal Clave As String, ByVal Puerto As String) As RespuestaValidacionUsuario Implements IServiceTerminalHost.ValidarCredencialesAdministrador
        Dim oRespuesta As New RespuestaValidacionUsuario
        Try
            Dim oHelper As New Helper
            oHelper.ValidarCredencialesUsuarioAdministrador(IdEmpleado, Clave)

            oRespuesta.EsAutorizado = True
            oRespuesta.Mensaje = String.Empty

        Catch ex As System.Exception
            oRespuesta.Mensaje = ex.Message
            oRespuesta.EsAutorizado = False
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            POSstation.Fabrica.LogIt.Loguear("Excepcion en Redireccionar Impresoras", LogPropiedades, LogCategorias)
        End Try
        Return oRespuesta
    End Function


    'Function VerificarBonoSodexo(ByVal NroConfirmacion As String) As RespuestaVerificarBonoSodexo Implements IServiceTerminalHost.VerificarBonoSodexo
    '    Dim oRespuesta As New RespuestaVerificarBonoSodexo
    '    Dim oHelper As New Helper
    '    Dim oRes As Boolean
    '    Try
    '        oRes = oHelper.VerificarBonoSodexo(NroConfirmacion)
    '        oRespuesta.EsAutorizado = oRes
    '        oRespuesta.Mensaje = String.Empty

    '    Catch ex As Exception
    '        oRespuesta.Mensaje = ex.Message
    '        oRespuesta.EsAutorizado = False
    '        LogCategorias.Clear()
    '        LogCategorias.Agregar(Categoria)
    '        LogPropiedades.Clear()
    '        LogPropiedades.Agregar("VerificarBonoSodexo", ex.Message)
    '        POSstation.Fabrica.LogIt.Loguear("Excepcion en VerificarBonoSodexo", LogPropiedades, LogCategorias)
    '    End Try
    '    Return oRespuesta
    'End Function

    Function VerificarBonoSodexo(ByVal NroConfirmacion As String) As RespuestaVerificarBonoSodexo Implements IServiceTerminalHost.VerificarBonoSodexo

    End Function
    Function ValidarCredenciales(ByVal IdEmpleado As String, ByVal Clave As String, ByVal EsTurnoAbierto As Boolean, ByVal Puerto As String) As RespuestaValidacionUsuario Implements IServiceTerminalHost.ValidarCredenciales
        Dim oRespuesta As New RespuestaValidacionUsuario
        Try
            Dim oHelper As New Helper
            Dim oRes As Boolean
            If EsTurnoAbierto Then
                Try
                    oHelper.ValidarCredencialesTurnoAbierto(IdEmpleado, Clave)
                    oRes = True
                Catch ex As System.Exception
                    Throw
                End Try
            Else
                oRes = oHelper.ValidarCredenciales(IdEmpleado, Clave)
            End If

            If oRes Then
                oRespuesta.EsAutorizado = True
                oRespuesta.Mensaje = String.Empty
            Else
                oRespuesta.EsAutorizado = False
                oRespuesta.Mensaje = "Credenciales Invalidas"
            End If

        Catch ex As System.Exception
            oRespuesta.Mensaje = ex.Message
            oRespuesta.EsAutorizado = False
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            POSstation.Fabrica.LogIt.Loguear("Excepcion en Redireccionar Impresoras", LogPropiedades, LogCategorias)
        End Try
        Return oRespuesta
    End Function

    Sub AbrirTurno(IdEmpleado As String, Password As String, Surtidores As List(Of DTOSurtidor), ByVal Puerto As String) Implements IServiceTerminalHost.AbrirTurno

        Try
            Dim auxSurtidores As String = ""

            For Each Surtidor As DTOSurtidor In Surtidores
                auxSurtidores = auxSurtidores & Surtidor.IdSurtidor & "|"
            Next

            RaiseEvent oEventos_AperturaTurno(IdEmpleado, Password, auxSurtidores, Puerto)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Abrir Turno", LogPropiedades, LogCategorias)
            Throw
        End Try

    End Sub

    Public Function ValidarConsignacionesdeSobre(Puerto As String) As Boolean Implements IServiceTerminalHost.ValidarConsignacionesdeSobre
        Dim respuesta As Boolean = False
        Dim oHelper As New Helper
        Try
            respuesta = CBool(oHelper.RecuperarParametro("AplicaConsignacionesdeSobre"))
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validacion de Consignaciones de sobre", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return respuesta
    End Function

    Public Function MensajeConsignarCierreTurno(IdEmpleado As String, Password As String, esTDC As Boolean) As RespuestaConsignacion Implements IServiceTerminalHost.MensajeConsignarCierreTurno
        Dim oHelper As New Helper
        Try
            Dim oConsignacion As RespuestaConsignacion = New RespuestaConsignacion
            Dim idTipoTurno As Short = 0
            Dim turno As Integer = 0

            Dim drTurno As IDataReader

            If esTDC Then
                drTurno = oHelper.RecuperarTurnoConsignaciones(IdEmpleado, Password, False)
            Else
                drTurno = oHelper.RecuperarTurnoConsignaciones(IdEmpleado, Password, True)
            End If

            If (drTurno.Read()) Then
                idTipoTurno = Convert.ToInt16(drTurno("IdTipoTurno").ToString())
                turno = Convert.ToInt32(drTurno("IdTurno").ToString())
            End If
            drTurno.Close()


            Dim ODatos As IDataReader
            ODatos = oHelper.RecuperarSobranteFaltanteTurno(turno, idTipoTurno)

            If (ODatos.Read()) Then
                If (Convert.ToDecimal(ODatos("Valor").ToString()) > 0) Then
                    If (Convert.ToBoolean(ODatos("EsSobrante"))) Then
                        oConsignacion.EsSobrante = True
                    Else
                        oConsignacion.EsSobrante = False
                    End If
                    oConsignacion.Valor = CDbl(ODatos("Valor").ToString)
                End If
            End If
            ODatos.Close()
            ODatos = Nothing
            oConsignacion.valorFijo = oHelper.RecuperarParametro("ValorSobre")

            Return oConsignacion
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Mensajes Consignacion Cierre de Turno", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Function

    Public Sub ConsignarCierreTurno(IdEmpleado As String, Password As String, oConsignaciones As List(Of DTOConsignacion), EsTurnoTrabajo As Boolean, EsCierreTurno As Boolean, Puerto As String) Implements IServiceTerminalHost.ConsignarCierreTurno
        Try

            Dim aplica As Boolean = False

            If (oConsignaciones.Count > 0) Then
                aplica = True
            End If

            If (EsTurnoTrabajo) Then
                If (EsCierreTurno) Then
                    'RaiseEvent oEventos_ReportarCierreTurnoTrabajo(IdEmpleado, ColConsignacion, aplica, Puerto)
                Else
                    'RaiseEvent OEventos_InformarCierreConsignaciones(IdEmpleado, Password, ColConsignacion, aplica, Puerto)
                End If
            Else
                RaiseEvent OEventos_InformarCierreConsignaciones(IdEmpleado, Password, oConsignaciones, aplica, Puerto)
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Consignacion Cierre de Turno", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Function RecuperarProductosCanastilla(ByVal Codigo As String) As DTOProducto Implements IServiceTerminalHost.RecuperarProductoCanastilla
        Dim oValor As New DTOProducto
        Try
            Dim oHelper As New POSstation.HelperCanastilla.Helper
            Dim oProducto As IDataReader = Nothing

            oProducto = oHelper.RecuperarProductoPorCodigo(CInt(Codigo))
            While oProducto.Read()
                oValor.Codigo = CStr(oProducto.Item("Codigo"))
                oValor.Descripcion = CStr(oProducto.Item("Descripcion"))
                oValor.Existencia = CInt(oProducto.Item("Existencia"))
                oValor.Valor = CDec(oProducto.Item("PrecioVenta"))
                oValor.ManejaExistencia = CBool(oProducto.Item("ManejaExistencias"))
            End While
            oProducto.Close()
            oProducto.Dispose()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RecuperarProductosCanastilla", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return oValor
    End Function

    Public Function Tanques() As System.Collections.Generic.List(Of DTOTanque) Implements IServiceTerminalHost.Tanques
        Dim oDatos As New List(Of DTOTanque)
        Dim oValor As DTOTanque
        Try
            Dim oDataAccess As New Helper
            Dim drValidar As IDataReader = oDataAccess.RecuperarTanques
            While drValidar.Read
                oValor = New DTOTanque
                oValor.CodigoTanque = (drValidar("Codigo").ToString())
                oValor.Descripcion = drValidar("Descripcion").ToString()
                oDatos.Add(oValor)
            End While
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Tanques", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return oDatos
    End Function

    Public Function RecuperarProductosTanque(CodTanque As String) As System.Collections.Generic.List(Of Productos) Implements IServiceTerminalHost.RecuperarProductosTanque
        Dim lista As New List(Of Productos)
        Dim oDataAccess As New Helper
        Dim dtProductos As DataTable
        Try
            dtProductos = oDataAccess.RecuperarProductosTanque(CodTanque)
            Dim oProducto As Productos
            Dim NombreProd As String

            If dtProductos.Rows.Count > 0 Then
                For Each oRow As DataRow In dtProductos.Rows
                    oProducto = New Productos
                    oProducto.Codigo = Convert.ToString(oRow("Codigo")).Trim
                    NombreProd = Convert.ToString(oRow("Nombre")).Trim

                    If NombreProd.Length > 30 Then
                        oProducto.Nombre = NombreProd.Substring(0, 30)
                    Else
                        oProducto.Nombre = NombreProd
                    End If
                    lista.Add(oProducto)
                Next
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RecuperarProductosTanque", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return lista
    End Function


    Public Sub RemarcacionCombustible(ByVal tanqueBaja As String, ByVal productoBaja As Int16, ByVal cantidad As Decimal, TanqueAlta As String, ByVal productoAlta As Int16, puerto As String) Implements IServiceTerminalHost.RemarcacionCombustible
        Try
            Dim oHelper As New Helper
            Dim validarTanqueBaja As IDataReader, validarTanqueAlta As IDataReader
            Dim saldo As Decimal = 0


            validarTanqueBaja = oHelper.ValidarProductoEnTanque(tanqueBaja, cantidad, productoBaja)
            If validarTanqueBaja.Read Then
                If Convert.ToBoolean(validarTanqueBaja("EsValido")) Then
                    saldo = POSstation.Inventario.ManagementKardex.RecuperarSaldoTanque(tanqueBaja, productoBaja)
                    Dim saldoAnterior As Decimal = saldo
                    If saldo < cantidad Then
                        Throw New System.Exception("El saldo del tanque de baja es: " & saldo.ToString("N2") & "; La cantidad digitada debe ser menor o igual que la cantidad actual  del tanque")
                    End If

                    validarTanqueAlta = oHelper.ValidarProductoEnTanque(TanqueAlta, 0, productoAlta)
                    If validarTanqueAlta.Read Then
                        If Convert.ToBoolean(validarTanqueAlta("EsValido")) Then
                            Dim IdProductoBaja As Byte = Convert.ToByte(oHelper.RecuperarIdProductoCombustible(productoBaja))
                            Dim IdProductoAlta As Byte = Convert.ToByte(oHelper.RecuperarIdProductoCombustible(productoAlta))

                            RaiseEvent OEventos_EnviarRemarcaciones(tanqueBaja, productoBaja, cantidad, TanqueAlta, productoAlta, puerto)
                        Else
                            Throw New System.Exception(validarTanqueAlta("Mensaje").ToString())
                        End If
                    End If
                    validarTanqueAlta.Close()
                Else
                    Throw New System.Exception(validarTanqueBaja("Mensaje").ToString())
                End If
            End If
            validarTanqueBaja.Close()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RemarcacionCombustible", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Function MediosPagosCanastilla() As List(Of DTOMedioPago) Implements IServiceTerminalHost.MediosPagosCanastilla
        Dim lista As New List(Of DTOMedioPago)
        Try
            Dim oHelper As New Helper
            Dim Formas As IDataReader = oHelper.RecuperarFormaPagoCanastilla()
            Dim oValor As DTOMedioPago
            If Formas.Read Then
                oValor = New DTOMedioPago
                oValor.IdMedioPago = CStr(Formas("IdFormaPago"))
                oValor.Descripcion = (CStr(Formas("Descripcion")))
                lista.Add(oValor)
                While (Formas.Read())
                    oValor = New DTOMedioPago
                    oValor.IdMedioPago = CStr(Formas("IdFormaPago"))
                    oValor.Descripcion = (CStr(Formas("Descripcion")))
                    lista.Add(oValor)
                End While
            End If
            Formas.Close()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en MediosPagosCanastilla", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return lista
    End Function

    Public Function GuardarFacturaCanastilla(ByVal NumeroTarjeta As String, ByVal TipoLectura As Byte, ByVal NroSeguridad As String, ListaProductos As List(Of DTOVentaCanastilla), Puerto As String) As RespuestaDescuento Implements IServiceTerminalHost.GuardarFacturaCanastilla
        Dim respuesta As New RespuestaDescuento
        Try
            Dim oDataAccess As New Helper
            Dim valor As String = "", dSaldoVenta As Double
            respuesta.Mensaje = ""
            respuesta.saldoVenta = ""
            oFactura = Nothing
            oFactura = New Factura

            'GUARDANDO LOS PRODUCTOS CANASTILLA A VENDER
            For Each oProducto As DTOVentaCanastilla In ListaProductos
                oFactura.AgregarProductoTerpel(oProducto.Codigo, oProducto.Cantidad, "-1")
            Next

            If NumeroTarjeta = "0" Then
                oFactura.NoAplicaDescuentoCDC = True
            Else
                oFactura.GuardarTarjetaDescuento(NumeroTarjeta, NroSeguridad, TipoLectura)
            End If

            'CONSULTANDO EL SALDO DE LA VENTA
            'dSaldoVenta = oFactura.RecuperarTotalVentaConDescuentos()
            dSaldoVenta = oFactura.RecuperarTotalventa()
            valor = Convert.ToString(Convert.ToInt64(dSaldoVenta))
            respuesta.saldoVenta = valor

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en VentaCanastilla", LogPropiedades, LogCategorias)
            oFactura = Nothing
            respuesta.saldoVenta = ""
            respuesta.Mensaje = ex.Message
        End Try
        Return respuesta
    End Function




    ' Se modifico para 
    Public Sub GuardarFacturaCanastillaCredito(ByVal Cara As Byte, ByVal NumeroTarjeta As String, ByVal TipoLectura As Byte, ByVal NumeroAutorizacionManual As String, ByVal tipoIdentificacion As String, ListaProductos As List(Of DTOVentaCanastilla), IdEmpleado As String, Password As String, Puerto As String, ByVal MediosLectura As MediosLectura) Implements IServiceTerminalHost.GuardarFacturaCanastillaCredito
        Try


            If Not oFactura Is Nothing Then
                Dim IdVentaCanastilla As Int32 = 0
                Dim TotalFactura As Double = oFactura.RecuperarTotalventa()

                Dim MCIdentificacion As MedioCredito = New MedioCredito
                MCIdentificacion.Cara = Cara
                MCIdentificacion.NumeroIdentificacion = NumeroTarjeta
                MCIdentificacion.TipoIdentificacion = tipoIdentificacion
                MCIdentificacion.TipoLectura = TipoLectura
                MCIdentificacion.NroAutorizacionManual = Convert.ToString(NumeroAutorizacionManual)




                ' //Evaluamos el tipo de identificación
                If (Convert.ToInt16(Fabrica.TipoIdentificacionCredito.CHIP) = tipoIdentificacion) Then
                    MCIdentificacion.NumeroIdentificacion = String.Empty
                ElseIf (Convert.ToInt16(Fabrica.TipoIdentificacionCredito.TARJETA) = tipoIdentificacion) Then
                    MCIdentificacion.NumeroIdentificacion = NumeroTarjeta
                ElseIf (Convert.ToInt16(Fabrica.TipoIdentificacionCredito.NUMEROAUTORIZACION) = tipoIdentificacion) Then
                    MCIdentificacion.NumeroIdentificacion = NumeroAutorizacionManual
                ElseIf (Convert.ToInt16(Fabrica.TipoIdentificacionCredito.NIT) = tipoIdentificacion) Then
                    MCIdentificacion.NumeroIdentificacion = NumeroTarjeta + ":" + NumeroAutorizacionManual
                End If

                MCIdentificacion.TipoIdentificacion = tipoIdentificacion




                Dim MCCanastilla As ColCanastilla = New POSstation.Protocolos.ColCanastilla()

                If Not IsNothing(oFactura) Then

                    If oFactura.EsFacturaFinalizada = False Then
                        oFactura.AgregarPago(4, "", TotalFactura, 0, "")
                        oFactura.EsFacturaFinalizada = True
                    End If

                    If oFactura.NoAplicaDescuentoCDC Then
                        MCIdentificacion.Cara = Cara
                        Dim producto As FacturaDetalle = New FacturaDetalle()
                        Dim codigo As String = ""
                        Dim cantidad As Double = 0

                        If oFactura.Productos.Count > 0 Then
                            For i As Int16 = 1 To oFactura.Productos.Count
                                producto = oFactura.GuardarTerpel(i)
                                codigo = Convert.ToString(producto.CodigoProducto)
                                cantidad = producto.Cantidad
                                MCCanastilla.Add(codigo, cantidad, 0, "")
                            Next

                            'Disparamos el evento de Canastilla    
                            RaiseEvent oEventos_VentaCreditoCanastilla(MCIdentificacion, MCCanastilla, IdEmpleado, Password, Puerto)
                            'IdVentaCanastilla = VentaCanastillaEfectivo(MCIdentificacion, MCCanastilla, IdEmpleado, Password)

                        Else
                            Throw New System.Exception("Error al Generar la Factura")
                        End If

                        oFactura = Nothing
                    End If


                    'Dim oHelper As New Helper()
                    'Dim Valor As String
                    'Dim oModificarVenta As New VentaModificada()
                    'Dim dSaldoVenta As Double
                    'Dim valorSaldo As String
                    'Dim ReciboCanastilla As String

                    'If IdVentaCanastilla <> 0 Then
                    'Dim drCanastilla As IDataReader = oHelper.RecuperarUltimoReciboCanastilla(Convert.ToInt32(IdVentaCanastilla))

                    'If drCanastilla.Read() Then
                    '    ReciboCanastilla = drCanastilla("Recibo").ToString()
                    '    'oEventos.SolicitarNotificarVentaCanastillaGenerada(ref ReciboCanastilla);
                    '    dSaldoVenta = Convert.ToDouble(drCanastilla("Valor").ToString())
                    '    oModificarVenta.Recibo = Convert.ToInt64(ReciboCanastilla)
                    '    Valor = Convert.ToString(Convert.ToInt64(Math.Ceiling(dSaldoVenta))).PadLeft(7)
                    '    valorSaldo = Valor
                    'Else
                    '    Throw New System.Exception("Fallo durante el proceso de medio de pagos.")
                    'End If
                    'drCanastilla.Close()


                    'Dim Pago As MediosPagos
                    '' For Each oPago As DTOMedioPago In ListaMedios
                    'Pago = New MediosPagos
                    'Pago.IdFormaPago = oPago.IdMedioPago
                    'Pago.NroConfirmacion = oPago.NroConfirmacion
                    ''El metodo oHelper.ModificarVentaCanastilla verifica el campo Pago.NroTarjeta para guardar la formas de pago
                    ''es por ello que se envia el campo oPago.NroConfirmacion donde viene normalmente el valor del Bono o del Voucher cuando las formas de pago son BonoSodexo o Tarjeta Debito/Credito
                    'Pago.NroTarjeta = oPago.NroConfirmacion
                    'Pago.Valor = oPago.Valor
                    'Pago.TipoLectura = "0"
                    'oModificarVenta.GuardarPagosGenerales(Pago)
                    ''   Next


                    'Dim ArrayPagos As System.Array = oModificarVenta.GetArrayPagos()

                    'Dim recibo As Int32 = Convert.ToInt32(oModificarVenta.Recibo)
                    'oHelper.ModificarVentaCanastilla(oModificarVenta)


                    'If Convert.ToBoolean(oHelper.RecuperarParametro("GenerarFacturaCanastillaAutomatica")) Then
                    '    ReciboCanastilla = Convert.ToString(IdDocumento)
                    '    RaiseEvent OEventos_ImprimirFacturaCanastillaUnica(ReciboCanastilla, Puerto)
                    'Else
                    '    ReciboCanastilla = IdVentaCanastilla
                    '    RaiseEvent OEventos_ImprimirVentaCanastilla(ReciboCanastilla, Puerto)
                    'End If

                    'Else
                    '    Throw New System.Exception("Error al Generar la Factura")
                    'End If
                Else
                    Throw New System.Exception("Error al Generar la Factura")
                End If
            Else
                Throw New System.Exception("Error al Generar la Factura")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en GuardarFacturaEfectivo", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub





    Public Sub GuardarFacturaEfectivo(ByVal NumeroTarjeta As String, ByVal TipoLectura As Byte, ByVal NroSeguridad As String, ByVal ListaProductos As List(Of DTOVentaCanastilla), ByVal ListaMedios As List(Of DTOMedioPago), ByVal IdEmpleado As String, ByVal Password As String, ByVal Puerto As String) Implements IServiceTerminalHost.GuardarFacturaEfectivo
        Try

            If Not oFactura Is Nothing Then
                Dim IdVentaCanastilla As Int32 = 0
                Dim TotalFactura As Double = oFactura.RecuperarTotalventa()

                Dim MCIdentificacion As MedioCredito = New MedioCredito()
                Dim MCCanastilla As ColCanastilla = New ColCanastilla()

                If Not IsNothing(oFactura) Then

                    If oFactura.EsFacturaFinalizada = False Then
                        oFactura.AgregarPago(4, "", TotalFactura, 0, "")
                        oFactura.EsFacturaFinalizada = True
                    End If

                    If oFactura.NoAplicaDescuentoCDC Then
                        MCIdentificacion.Cara = 0 'MediosLectura.Cara
                        Dim producto As FacturaDetalle = New FacturaDetalle()
                        Dim codigo As String = ""
                        Dim cantidad As Double = 0

                        If oFactura.Productos.Count > 0 Then
                            For i As Int16 = 1 To oFactura.Productos.Count
                                producto = oFactura.GuardarTerpel(i)
                                codigo = Convert.ToString(producto.CodigoProducto)
                                cantidad = producto.Cantidad
                                MCCanastilla.Add(codigo, cantidad, 0, "")
                            Next

                            'Disparamos el evento de Canastilla                            
                            IdVentaCanastilla = VentaCanastillaEfectivo(MCIdentificacion, MCCanastilla, IdEmpleado, Password)

                        Else
                            Throw New System.Exception("Error al Generar la Factura")
                        End If

                        oFactura = Nothing
                    End If


                    Dim oHelper As New Helper()
                    Dim Valor As String
                    Dim oModificarVenta As New VentaModificada()
                    Dim dSaldoVenta As Double
                    Dim valorSaldo As String
                    Dim ReciboCanastilla As String

                    If IdVentaCanastilla <> 0 Then
                        Dim drCanastilla As IDataReader = oHelper.RecuperarUltimoReciboCanastilla(Convert.ToInt32(IdVentaCanastilla))

                        If drCanastilla.Read() Then
                            ReciboCanastilla = drCanastilla("Recibo").ToString()
                            'oEventos.SolicitarNotificarVentaCanastillaGenerada(ref ReciboCanastilla);
                            dSaldoVenta = Convert.ToDouble(drCanastilla("Valor").ToString())
                            oModificarVenta.Recibo = Convert.ToInt64(ReciboCanastilla)
                            Valor = Convert.ToString(Convert.ToInt64(Math.Ceiling(dSaldoVenta))).PadLeft(7)
                            valorSaldo = Valor
                        Else
                            Throw New System.Exception("Fallo durante el proceso de medio de pagos.")
                        End If
                        drCanastilla.Close()


                        Dim Pago As MediosPagos
                        For Each oPago As DTOMedioPago In ListaMedios
                            Pago = New MediosPagos
                            Pago.IdFormaPago = oPago.IdMedioPago
                            Pago.NroConfirmacion = oPago.NroConfirmacion
                            'El metodo oHelper.ModificarVentaCanastilla verifica el campo Pago.NroTarjeta para guardar la formas de pago
                            'es por ello que se envia el campo oPago.NroConfirmacion donde viene normalmente el valor del Bono o del Voucher cuando las formas de pago son BonoSodexo o Tarjeta Debito/Credito
                            Pago.NroTarjeta = oPago.NroConfirmacion
                            Pago.Valor = oPago.Valor
                            Pago.TipoLectura = "0"
                            oModificarVenta.GuardarPagosGenerales(Pago)
                        Next


                        Dim ArrayPagos As System.Array = oModificarVenta.GetArrayPagos()

                        Dim recibo As Int32 = Convert.ToInt32(oModificarVenta.Recibo)
                        oHelper.ModificarVentaCanastilla(oModificarVenta)


                        If Convert.ToBoolean(oHelper.RecuperarParametro("GenerarFacturaCanastillaAutomatica")) Then
                            ReciboCanastilla = Convert.ToString(IdDocumento)
                            RaiseEvent OEventos_ImprimirFacturaCanastillaUnica(ReciboCanastilla, Puerto)
                        Else
                            ReciboCanastilla = IdVentaCanastilla
                            RaiseEvent OEventos_ImprimirVentaCanastilla(ReciboCanastilla, Puerto)
                        End If

                    Else
                        Throw New System.Exception("Error al Generar la Factura")
                    End If
                Else
                    Throw New System.Exception("Error al Generar la Factura")
                End If
            Else
                Throw New System.Exception("Error al Generar la Factura")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en GuardarFacturaEfectivo", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Private Function VentaCanastillaEfectivo(ByVal identificacion As MedioCredito, ByVal colProductos As ColCanastilla, ByVal IdEmpleado As String, ByVal Password As String) As Integer
        Try
            Dim oDataAccess As New Helper
            Dim oCara As Int16 = identificacion.Cara
            Dim oTipoIdentificacion As Short = identificacion.TipoIdentificacion
            Dim oNumeroIdentificacion As String = identificacion.NumeroIdentificacion
            Dim oFacturaEfectivo As Factura = New Factura()
            Dim oTotal As Double
            Dim Consecutivo As Long
            Dim r() As Char = ("|")

            Dim Respuesta As IDataReader = oDataAccess.ValidarVentaCanastilla(oTipoIdentificacion, oNumeroIdentificacion)

            If Respuesta.Read() Then
                oFactura.Empleado = IdEmpleado
                oFactura.IdFormaPago = Convert.ToInt16(Respuesta("IdFormaPago").ToString())
                oTotal = oFactura.RecuperarTotalventa()

                If Not oFactura.EsFacturaFinalizada Then
                    oFactura.AgregarPago(oFactura.IdFormaPago, "", oTotal, 0, "")
                    oFactura.EsFacturaFinalizada = True
                End If

                If (Convert.ToBoolean(oDataAccess.RecuperarParametro("GenerarFacturaCanastillaAutomatica"))) Then
                    IdDocumento = oFactura.GuardarFacturaFullStation(IdEmpleado, Password, Respuesta("CedulaCliente").ToString(), 0, "")
                    Consecutivo = oDataAccess.RecuperarIdVentaCanastillaPorRecibo(oDataAccess.RecuperarReciboCanastillaPorDocumento(Convert.ToInt32(IdDocumento)))
                Else
                    Consecutivo = oFactura.GuardarVentaFullstation(IdEmpleado, Password, Respuesta("CedulaCliente"), 0, "", 4)
                End If
            Else
                Consecutivo = 0
            End If

            Respuesta.Close()
            Return Consecutivo

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en VentaCanastillaEfectivo", LogPropiedades, LogCategorias)
            Throw
        End Try

    End Function





    Public Function RecuperarSurtidoresEnTurnoAbierto() As System.Collections.Generic.List(Of DTOSurtidor) Implements IServiceTerminalHost.RecuperarSurtidoresEnTurnoAbierto
        Dim oDatos As New List(Of DTOSurtidor)
        Dim oValor As DTOSurtidor
        Try
            Dim oDataAccess As New Helper
            Dim drValidar As DataSet = oDataAccess.RecuperarSurtidoresEnTurnoAbierto()
            If drValidar.Tables(0).Rows.Count >= 1 Then
                For i As Integer = 0 To drValidar.Tables(0).Rows.Count - 1
                    oValor = New DTOSurtidor
                    oValor.IdSurtidor = drValidar.Tables(0).Rows(i)("IdSurtidor").ToString()
                    oValor.Descripcion = drValidar.Tables(0).Rows(i)("Descripcion").ToString()
                    oDatos.Add(oValor)
                Next
            End If
            drValidar.Dispose()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en SurtidoresSinTurnoAbierto", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return oDatos
    End Function

    Public Function HayConexion() As Boolean Implements IServiceTerminalHost.HayConexion
        Return True
    End Function

    Public Function RecuperarSurtidores() As System.Collections.Generic.List(Of DTOSurtidor) Implements IServiceTerminalHost.RecuperarSurtidores
        Dim oDatos As New List(Of DTOSurtidor)
        Dim oValor As DTOSurtidor
        Try
            Dim oDataAccess As New Helper
            Dim drValidar As DataSet = oDataAccess.RecuperarSurtidores()
            If drValidar.Tables(0).Rows.Count >= 1 Then
                For i As Integer = 0 To drValidar.Tables(0).Rows.Count - 1
                    oValor = New DTOSurtidor
                    oValor.IdSurtidor = drValidar.Tables(0).Rows(i)("IdSurtidor").ToString()
                    oValor.Descripcion = drValidar.Tables(0).Rows(i)("Descripcion").ToString()
                    oDatos.Add(oValor)
                Next
            End If
            drValidar.Dispose()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en SurtidoresSinTurnoAbierto", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return oDatos
    End Function

    Public Function RecuperarSurtidoresSinTurnoAbierto() As System.Collections.Generic.List(Of DTOSurtidor) Implements IServiceTerminalHost.RecuperarSurtidoresSinTurnoAbierto
        Dim oDatos As New List(Of DTOSurtidor)
        Dim oValor As DTOSurtidor
        Try
            Dim oDataAccess As New Helper
            Dim drValidar As DataSet = oDataAccess.RecuperarSurtidoresSinTurnoAbiertoARM()
            If drValidar.Tables(0).Rows.Count >= 1 Then
                For i As Integer = 0 To drValidar.Tables(0).Rows.Count - 1
                    oValor = New DTOSurtidor
                    oValor.IdSurtidor = drValidar.Tables(0).Rows(i)("IdSurtidor").ToString()
                    oValor.Descripcion = drValidar.Tables(0).Rows(i)("Descripcion").ToString()
                    oDatos.Add(oValor)
                Next
            End If
            drValidar.Dispose()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en SurtidoresSinTurnoAbierto", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return oDatos
    End Function

    Public Sub AbrirTurnoApoyo(IdEmpleado As String, Password As String, TipoTurno As Int16, Puerto As String) Implements IServiceTerminalHost.AbrirTurnoApoyo

        Try
            RaiseEvent oEventos_AperturaTurnoTrabajo(IdEmpleado, Password, TipoTurno, Puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Abrir Turno Trabajo", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Sub CerrarTurnoPorSurtidor(IdEmpleado As String, Password As String, Surtidores As List(Of DTOSurtidor), ByVal Puerto As String) Implements IServiceTerminalHost.CerrarTurnoPorSurtidor

        Try
            Dim oHelper As New Helper
            Dim AuxSurtidores As String = ""

            For Each Surtidor As DTOSurtidor In Surtidores
                AuxSurtidores = AuxSurtidores & Surtidor.IdSurtidor & "|"
            Next

            oHelper.ValidarCierreTurnoParcialSurtidor(IdEmpleado, Password, AuxSurtidores)

            RaiseEvent oEventos_CerrarTurno(IdEmpleado, Password, Puerto, AuxSurtidores)


        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Cerrar Turno por surtidor", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Sub CerrarTurno(idEmpleado As String, Password As String, Puerto As String, Key As String) Implements IServiceTerminalHost.CerrarTurno

        Try
            RaiseEvent oEventos_CerrarTurno(idEmpleado, Password, Puerto, Key)

        Catch ex As System.Exception
            RaiseEvent oEventos_ReportarExcepcion(ex.Message, True, True, "")
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Cerrar Turno", LogPropiedades, LogCategorias)

        End Try
    End Sub

    Public Function RecuperarSurtidoresPorEmpleadoEnTurno(idEmpleado As String) As System.Collections.Generic.List(Of DTOSurtidor) Implements IServiceTerminalHost.RecuperarSurtidoresPorEmpleadoEnTurno
        Dim oDatos As New List(Of DTOSurtidor)
        Dim oValor As DTOSurtidor
        Try
            Dim oDataAccess As New Helper
            Dim drValidar As DataSet = oDataAccess.RecuperarSurtidoresPorEmpleadoEnTurno(idEmpleado)
            If drValidar.Tables(0).Rows.Count >= 1 Then
                For i As Integer = 0 To drValidar.Tables(0).Rows.Count - 1
                    oValor = New DTOSurtidor
                    oValor.IdSurtidor = drValidar.Tables(0).Rows(i)("IdSurtidor").ToString()
                    oValor.Descripcion = drValidar.Tables(0).Rows(i)("Descripcion").ToString()
                    oDatos.Add(oValor)
                Next
            End If
            drValidar.Dispose()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en SurtidoresSinTurnoAbierto", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return oDatos
    End Function

    Public Sub ImprimirUltimaVenta(Cara As String, Placa As String, puerto As String) Implements IServiceTerminalHost.ImprimirUltimaVenta

        Try
            Dim oDataAccess As New Helper
            If (oDataAccess.ExisteCara(Convert.ToInt16(Cara))) Then
                Dim EsUltimaVenta As Boolean = True

                If (Placa = "0") Then
                    Placa = String.Empty
                End If

                RaiseEvent oEventos_SolicitarRegistrarPlaca(Cara, Placa, EsUltimaVenta, puerto)

            Else
                Throw New System.Exception("La Cara " + Cara + " No existe")
            End If

        Catch ex As System.Exception

            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Imprimir última venta", LogPropiedades, LogCategorias)

        End Try

    End Sub

    Public Sub ImprimirVentaConsecutivo(consecutivo As String, Placa As String, Puerto As String) Implements IServiceTerminalHost.ImprimirVentaConsecutivo
        Try
            Dim oHelper As New Helper
            Dim Original As Boolean = False

            If (Placa = "0") Then
                Placa = String.Empty
            End If
            oHelper.InsertarPlacaRecibo(Convert.ToInt64(consecutivo), Placa)

            RaiseEvent oEventos_ReimprimirDocumentoPorNumero(consecutivo, Puerto, Original)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ImprimirVentaConsecutivo", LogPropiedades, LogCategorias)

        End Try
        
    End Sub

    Public Sub ImprimirCopiaTurno(Turno As Byte, Fecha As String, Surtidor As Byte, Puerto As String) Implements IServiceTerminalHost.ImprimirCopiaTurno
        Try
            RaiseEvent oEventos_ReimprimirTurnoPorSurtidor(Turno, Fecha, Surtidor, Puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Imprimir Copia de Turno por Numero de turno", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Sub ImprimirCopiaEmpleado(IdEmpleado As String, Fecha As String, Puerto As String) Implements IServiceTerminalHost.ImprimirCopiaEmpleado
        Try
            RaiseEvent oEventos_ReimprimirTurnoPorEmpleado(IdEmpleado, Fecha, Puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Imprimir Copia de Turno por Codigo de Empleado", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub



    Public Sub Predeterminar(tipo As Byte, Cara As Byte, valor As String, puerto As String) Implements IServiceTerminalHost.Predeterminar

        Try
            Dim idProducto As Short = -1
            valor = Fabrica.Utilidades.ModificarFormatoDecimal(valor)
            RaiseEvent oEventos_Preset(Cara, valor, tipo, idProducto, puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en predeterminar", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Public Function SaldoTarjetaPrepago(NoTarjeta As String, Puerto As String) As String Implements IServiceTerminalHost.SaldoTarjetaPrepago
        Dim oDataAccess As New Helper
        Dim Saldo As String
        Dim Datos As String = ""

        Try
            If oDataAccess.ExisteTarjeta(NoTarjeta) Then
                Saldo = oDataAccess.RecuperarSaldoCupo(NoTarjeta).ToString
                Datos = CInt(Saldo).ToString() + "|" + NoTarjeta
                RaiseEvent oEventos_ImprimirSaldoTarjetaPrepago(Puerto, Datos)
            Else
                Throw New System.Exception("ERROR: La Tarjeta no existe!")
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en SaldoTarjetaPrepago", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return Saldo
    End Function


    Public Function DetalleMovimientos(NoTarjeta As String, Puerto As String) As DetalleMovimientos Implements IServiceTerminalHost.DetalleMovimientos
        Dim oDataAccess As New Helper
        Dim ODatosTarjeta As IDataReader = oDataAccess.RecuperarDatosTarjetaPrepago(NoTarjeta)
        Dim DMov As DetalleMovimientos = Nothing

        Try
            If ODatosTarjeta.Read Then
                DMov = New DetalleMovimientos
                DMov.Cliente = ODatosTarjeta.Item("NombreCliente").ToString
                DMov.Saldo = CDec(ODatosTarjeta.Item("Saldo"))
            End If

            ODatosTarjeta.Close()
            ODatosTarjeta.Dispose()

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en DetalleMovimientos", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return DMov
    End Function


    Public Function MovimientosPrepago(NoTarjeta As String, Puerto As String) As List(Of Movimiento) Implements IServiceTerminalHost.MovimientosPrepago
        Dim oDataAccess As New Helper
        Dim OMovimientos As IDataReader = oDataAccess.RecuperarMovimientoTarjetaPrepago(NoTarjeta)
        Dim OMovimientosCanastilla As IDataReader = oDataAccess.RecuperarMovimientoTarjetaPrepagoCanastilla(NoTarjeta)
        Dim DMovimientos As List(Of Movimiento) = Nothing
        Dim Mov As Movimiento = Nothing

        Try
            If oDataAccess.ExisteTarjeta(NoTarjeta) Then
                DMovimientos = New List(Of Movimiento)

                If OMovimientos.Read Then
                    Do
                        Mov = New Movimiento()
                        Mov.FechaHora = OMovimientos.Item("FechaHora").ToString
                        Mov.Valor = OMovimientos.Item("Valor").ToString
                        Mov.Tipo = "Combustible"
                        DMovimientos.Add(Mov)
                    Loop While (OMovimientos.Read)
                End If

                If OMovimientosCanastilla.Read Then
                    Do
                        Mov = New Movimiento()
                        Mov.FechaHora = OMovimientosCanastilla.Item("Fecha").ToString
                        Mov.Valor = OMovimientosCanastilla.Item("Valor").ToString
                        Mov.Tipo = "Canastilla"
                        DMovimientos.Add(Mov)
                    Loop While (OMovimientosCanastilla.Read)
                End If

                OMovimientos.Close()
                OMovimientos.Dispose()

                OMovimientosCanastilla.Close()
                OMovimientosCanastilla.Dispose()

                RaiseEvent oEventos_ImprimirMovimientosPrepago(NoTarjeta, Puerto)
            Else
                Throw New System.Exception("ERROR: La Tarjeta no existe!")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en MovimientosPrepago", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return DMovimientos
    End Function

    Private Sub PredeterminarTarjeta(cara As Byte, noTarjeta As String, valor As String, puerto As String) Implements IServiceTerminalHost.PredeterminarTarjeta
        Dim oDataAccess As New Helper
        Dim kilometraje As String = "0"

        Try
            If (oDataAccess.ExisteCara(CShort(cara))) Then
                RaiseEvent oEventos_AutorizarVentaPrepago(cara, noTarjeta, CDbl(valor), puerto, kilometraje)
            Else
                Throw New System.Exception("ERROR: La cara " & cara.ToString & " no existe!")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en PredeterminarTarjeta", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

    End Sub


    Private Sub ConsumirCombustible(cara As Byte, puerto As String) Implements IServiceTerminalHost.ConsumirCombustible
        Dim oDataAccess As New Helper

        Try
            Dim Respuesta As Integer = oDataAccess.ValidarCaraConsumoInterno(CShort(cara))

            If (Respuesta <> 2) Then
                RaiseEvent oEventos_EnvioVentaConsumoCombustible(cara, puerto)
            Else
                Throw New System.Exception("ERROR: La cara " & cara.ToString & " no existe o esta Inactiva. Por Favor Verifique!")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ConsumirCombustible", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

    End Sub

    Public Sub AdicionarDato(Cara As Byte, Informacion As String, esPlaca As Boolean, esUltimaVenta As Boolean, Puerto As String) Implements IServiceTerminalHost.AdicionarDato
        Dim oDataAccess As New Helper

        Try
            If (oDataAccess.ExisteCara(CShort(Cara))) Then

                If (esPlaca) Then
                    RaiseEvent oEventos_RegistrarPlaca(Cara, Informacion, esUltimaVenta, Puerto)
                Else
                    RaiseEvent oEventos_GuardarKilometraje(Cara, Informacion, esUltimaVenta, Puerto)
                End If

            Else
                Throw New System.Exception("ERROR: La cara " & Cara & " no existe!.")
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Datos Adicioanles de Venta", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Public Sub Calibrar(Manguera As Integer, Puerto As String) Implements IServiceTerminalHost.Calibrar
        Dim oDataAccess As New Helper
        Dim lector As IDataReader
        Dim idMotivo As Short = -1
        Dim EsMotivo As Boolean = False
        Dim cara As Integer

        Try
            lector = oDataAccess.ValidarDatosCalibracion(Manguera)

            If lector.Read Then

                cara = CInt(lector("IdCara"))

                If cara < 0 Then
                    Throw New System.Exception("ERROR: " + lector("Mensaje").ToString)
                Else
                    RaiseEvent oEventos_Calibracion(CByte(cara), Manguera, idMotivo, EsMotivo, Puerto)
                End If

            Else
                Throw New System.Exception("ERROR: No se pudo validar datos de calibracion.")
            End If

            lector.Close()
            lector.Dispose()
        Catch ex As GasolutionsTurnoException
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Calibracion", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Calibracion", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Public Function RecuperarManguerasPorTurno(Usuario As String, Clave As String) As List(Of DTOManguera) Implements IServiceTerminalHost.RecuperarManguerasPorTurno
        Dim oDataAccess As New Helper
        Dim lector As IDataReader = Nothing
        Dim lstMangueras As List(Of DTOManguera) = Nothing
        Dim oManguera As DTOManguera
        Dim idTurno As Integer

        Try
            lstMangueras = New List(Of DTOManguera)

            idTurno = oDataAccess.RecuperarTurnoPorCredenciales(Usuario, Clave)
            lector = oDataAccess.RecuperarManguerasPorTurno(idTurno)

            While lector.Read
                oManguera = New DTOManguera
                oManguera.IdManguera = CInt(lector("IdManguera"))
                oManguera.Descripcion = lector("Descripcion").ToString()
                lstMangueras.Add(oManguera)
            End While

            lector.Close()
            lector.Dispose()

            If lstMangueras.Count < 1 Then
                Throw New System.Exception("ERROR: No hay mangueras asociadas a un turno del empleado " & Usuario & ".")
                Return Nothing
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RecuperarManguerasPorTurno", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return lstMangueras

    End Function



    Public Function RecuperarTanquesCierreAutomatico(Usuario As String, Clave As String) As List(Of DTOTanque) Implements IServiceTerminalHost.RecuperarTanquesCierreAutomatico
        Dim oDataAccess As New Helper
        Dim lector As IDataReader = Nothing
        Dim lstTanques As List(Of DTOTanque) = Nothing
        Dim oTanque As DTOTanque

        Try
            lstTanques = New List(Of DTOTanque)
            lector = oDataAccess.RecuperarTanquesCierreAutomatico(Usuario, Clave)

            While lector.Read
                oTanque = New DTOTanque
                oTanque.CodigoTanque = lector("Codigo").ToString
                oTanque.Descripcion = lector("Descripcion").ToString
                lstTanques.Add(oTanque)
            End While

            lector.Close()
            lector.Dispose()

            If lstTanques.Count < 1 Then
                Throw New System.Exception("ERROR: No existen tanques para cierre de tanque automatico.")
                Return Nothing
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RecuperarTanquesCierreAutomatico", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return lstTanques

    End Function


    Public Sub ValidarAforoTanque(Tanque As DTOTanque, Puerto As String) Implements IServiceTerminalHost.ValidarAforoTanque
        Dim ohelper As New Helper
        Dim oDataAccess As New Helper

        Try
            oDataAccess.ValidarAforoTanque(Tanque.CodigoTanque, Utilidades.ModificarFormatoDecimal(Tanque.Altura))
        Catch ex As System.Exception
            ohelper.InsertarCierreTanquesFallidoLogueo("", Tanque.Descripcion, ex.Message, "", "", "")
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RecuperarCantidadPorAforo", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Public Sub AjustesPorOperacionCierreTurno(Usuario As String, Clave As String, Tanques As List(Of DTOTanque), Puerto As String) Implements IServiceTerminalHost.AjustesPorOperacionCierreTurno
        Dim esActivo As Boolean = True
        Dim ohelper As New Helper
        Try
            RaiseEvent oEventos_EnviarAlturasCierreDeTanques(Usuario, Clave, Tanques, esActivo, Puerto)
        Catch ex As System.Exception
            For Each tanque As DTOTanque In Tanques
                ohelper.InsertarCierreTanquesFallidoLogueo("", tanque.Descripcion, ex.Message, Usuario, "", "")
            Next
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en AjustesPorOperacionCierreTurno", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Public Function EsAutoLecturaChipCredito() As Boolean Implements IServiceTerminalHost.EsAutoLecturaChipCredito
        Dim oDataAccess As New Helper
        Dim esAuto As Boolean = True
        Try
            Try
                ''esAuto = CBool(oDataAccess.RecuperarParametro("EsLecturaChipAutomaticaCredito"))
            Catch ex As System.Exception
                Throw New System.Exception("ERROR: Verificque que el parametro 'EsLecturaChipAutomaticaCredito' exista en la base de datos.")
            End Try
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en EsAutoLecturaChipCredito", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return esAuto
    End Function


    Public Sub RealizarVentaCredito(cara As Byte, identificador As String, idTipoIdentificacion As Integer, valorPredeterminado As String, puerto As String) Implements IServiceTerminalHost.RealizarVentaCredito
        Dim oDataAccess As New Helper
        Dim kilometraje As String = "0"

        Try
            RaiseEvent oEventos_VentaCredito(cara, kilometraje, puerto, identificador, idTipoIdentificacion, valorPredeterminado)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RealizarVentaCredito", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub



    Public Function AplicaCDCTerpel() As Boolean Implements IServiceTerminalHost.AplicaCDCTerpel
        Dim oDataAccess As New Helper
        Dim aplica As Boolean = False
        Try
            Try
                aplica = CBool(oDataAccess.RecuperarParametro("AplicaCDCTerpel"))
            Catch ex As System.Exception
                Throw New System.Exception("ERROR: Verificque que el parametro 'AplicaCDCTerpel' exista en la base de datos.")
            End Try
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en AplicaCDCTerpel", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

        Return aplica
    End Function


    Public Sub RealizarVentaCreditoTerpel(cara As Byte, kilometraje As String, puerto As String) Implements IServiceTerminalHost.RealizarVentaCreditoTerpel
        Try
            RaiseEvent oEventos_VentaCreditoTerpel(cara, kilometraje, puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RealizarVentaCreditoTerpel", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    Public Sub EnviarCaraMenoCash(cara As Byte) Implements IServiceTerminalHost.EnviarCaraMenoCash
        Try
            RaiseEvent oEventos_EnviarDatosMenoCash(cara)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en EnviarCaraMenoCash", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try
    End Sub



    Public Sub RealizarVentaEfectivo(cara As Byte, Puerto As String) Implements IServiceTerminalHost.RealizarVentaEfectivo
        Dim oDataAccess As New Helper

        Try
            If (oDataAccess.ExisteCara(CShort(cara))) Then
                RaiseEvent oEventos_ReportarPagoEfectivo(cara)
            Else
                Throw New System.Exception("ERROR: La cara " & cara.ToString & " no existe!")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en RealizarVentaEfectivo", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

    End Sub


    Public Sub FidelizarVentaManual(usuario As String, clave As String, recibo As String, tarjeta As String, volumen As String, valor As String, fecha As String, ByRef puerto As String) Implements IServiceTerminalHost.FidelizarVentaManual
        Dim oDataAccess As New Helper
        Dim idTurno As Integer
        Dim t As String


        Try
            t = oDataAccess.RecuperarTurnoFidelizacionManual(usuario)

            If t = "" Then
                idTurno = -1
            Else
                idTurno = CInt(t)
            End If

            RaiseEvent oEventos_FidelizarVentaManual(recibo, tarjeta, valor, volumen, idTurno, usuario, puerto, fecha)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en FidelizarManual", LogPropiedades, LogCategorias)
            Throw New System.Exception(ex.Message)
        End Try

    End Sub

    Public Function SeSolicitanCredenciales() As Boolean Implements IServiceTerminalHost.SeSolicitanCredenciales

        Try
            Dim oHelper As New Helper
            Dim validacion As Boolean = Convert.ToBoolean(oHelper.RecuperarParametro("SolicitarCredencialesAdmin"))
            Return validacion

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validar configuracion de credenciales", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Function


    Public Sub ImprimirTotalesDia(Fecha As String, Puerto As String) Implements IServiceTerminalHost.ImprimirTotalesDia

        Try
            Dim EsMrCombustible As Boolean = True
            RaiseEvent oEventos_ImprimirResumenDiario(Fecha, EsMrCombustible, Puerto)
        Catch ex As System.Exception


            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Menaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Imprimir Totales del Día", LogPropiedades, LogCategorias)


        End Try
    End Sub

    Public Function SolicitudDatosIbuttonImpresionArm(ByVal cara As Byte) As String Implements IServiceTerminalHost.SolicitudDatosIbuttonImpresionArm
        Dim datos As String = ""
        Try
            RaiseEvent oEventos_SolicitudDatosIbuttonImpresionArm(cara, datos)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en SolicitudDatosIbuttonImpresionArm ", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return datos
    End Function

    Public Sub ImprimirDatosIdentificador(ByVal cara As Byte, ByVal Puerto As String) Implements IServiceTerminalHost.ImprimirDatosIdentificador
        Try
            RaiseEvent oEventos_SolicitudDatosIbutton(CByte(cara), Puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)

            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ImprimirDatosChip", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub


    Public Sub ImprimirArqueo(IdEmpleado As String, password As String, Puerto As String) Implements IServiceTerminalHost.ImprimirArqueo

        Try
            RaiseEvent oEventos_ImprimirArqueo(IdEmpleado, password, Puerto)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Imprimir Auditoria de Turno", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Function ListarCaras() As System.Collections.Generic.List(Of DTOCara) Implements IServiceTerminalHost.ListarCaras
        Dim lista As New List(Of DTOCara)
        Dim lector As IDataReader = Nothing
        Dim oHelper As New Helper
        Try

            Dim oCara As DTOCara
            lector = oHelper.RecuperarListaCaras

            While lector.Read
                oCara = New DTOCara
                oCara.IdCara = CInt(lector("IdCara").ToString())
                oCara.Descripcion = (lector("Descripcion").ToString())
                lista.Add(oCara)
            End While
            lector.Close()
            lector.Dispose()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ListarCaras", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return lista
    End Function

    Public Sub CopiaFacturaProducto(Prefijo As String, Consecutivo As String, Puerto As String) Implements IServiceTerminalHost.CopiaFacturaProducto

        Try
            If (Prefijo = "0") Then
                Prefijo = String.Empty
            End If

            RaiseEvent oEventos_ReImprimirCopiaFacturaProductosServicios(Prefijo, Consecutivo, Puerto)

        Catch ex As System.Exception

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Copia de Factura Producto", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub



    Public Sub PredeterminarCheque(Cara As Byte, NumAutorizacion As String, Placa As String, NumeroTarjeta As String, TipoLectura As Byte, NroSeguridad As String, _
                                  NroAutorizacionManual As String, TipoIdentificacion As Short, Kilometraje As String, Puerto As String) Implements IServiceTerminalHost.PredeterminarCheque

        Try
            Dim oDataAccess As Helper = New Helper
            Dim tipoventa As Boolean = False

            If (Placa = "0") Then
                Placa = String.Empty
            End If

            If (NroAutorizacionManual = "0") Then
                NroAutorizacionManual = String.Empty
            End If


            Dim drValidar As IDataReader = oDataAccess.ValidarNumeroAutorizacionPlaca(Convert.ToInt64(NumAutorizacion), Placa)

            If (Not oDataAccess.ExisteCara(Convert.ToInt16(Cara))) Then
                Throw New System.Exception("Cara invalida")

            ElseIf (drValidar.Read()) Then

                If (Convert.ToBoolean(drValidar.Item("EsValido"))) Then
                    'Lanzamos el evento
                    RaiseEvent oEventos_AutorizarVentaCheque(Cara, NumAutorizacion, NumeroTarjeta, TipoLectura, NroSeguridad, TipoIdentificacion, Kilometraje, NroAutorizacionManual, Placa, tipoventa, Puerto)

                Else
                    'Este mensaje nos lo devuelve el SP
                    Throw New System.Exception(drValidar.Item("Mensaje"))
                End If
            Else
                Throw New System.Exception("Datos invalidos")

                drValidar.Close()

            End If
        Catch ex As System.Exception
            RaiseEvent oEventos_ReportarExcepcion(ex.Message, True, False, Puerto)
            Throw
        End Try
    End Sub


    Public Sub ValidarTarjetaRecarga(ByVal NumeroTarjeta As String, ByVal Valor As String) Implements IServiceTerminalHost.ValidarTarjetaRecarga
        Dim Saldo As Double = 0
        Dim oHelper As New Helper()

        Try

            If (oHelper.ExisteTarjeta(NumeroTarjeta)) Then

                If (oHelper.ExisteSaldoTarjeta(NumeroTarjeta, Valor) = False) Then

                    Saldo = oHelper.RecuperarSaldoCupo(NumeroTarjeta)
                    Throw New System.Exception("El saldo actual de la tarjeta No.  " + NumeroTarjeta + " es= " + Convert.ToString(Saldo) + " . Saldo Insuficiente.")
                End If
            Else
                Throw New System.Exception("La tarjeta No existe en la Base de Datos.")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("FalloGeneral")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validar Tarjeta Local", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub


#Region "Fidelizacion"


    Public Function ManejaRedFidelizacion() As Short Implements IServiceTerminalHost.ManejaRedFidelizacion

        Try
            Dim oDataAccess As New Helper
            Return oDataAccess.ManejaRedFidelizacion().ToString()
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Fidelizar venta", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Function

    Public Sub FidelizarVenta(Cara As Byte, NumeroTarjeta As String, IdRedFidelizacion As Short, Tipo As String, TipoVenta As String, Puerto As String) Implements IServiceTerminalHost.FidelizarVenta

        Try
            Dim Rut As String = ""
            If (Tipo = "04") Then
                Rut = NumeroTarjeta
            End If

            If (TipoVenta = "Ulti") Then

                RaiseEvent oEventos_FidelizarUltimaVenta(Cara, NumeroTarjeta, IdRedFidelizacion, Puerto, Rut)
            ElseIf (TipoVenta = "Prox") Then

                RaiseEvent oEventos_FidelizarVenta(Cara, NumeroTarjeta, IdRedFidelizacion, Puerto, Rut)

            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Fidelizar venta", LogPropiedades, LogCategorias)
            Throw
        End Try

    End Sub


    Public Sub ConsultaPuntosFidelizados(NumeroTarjeta As String, Tipo As String, Puerto As String) Implements IServiceTerminalHost.ConsultaPuntosFidelizados

        Try
            Dim Rut As String = ""

            If (Tipo = "04") Then
                Rut = NumeroTarjeta
            End If

            RaiseEvent oEventos_ConsultarSaldoTarjetaFidelizacion(NumeroTarjeta, Puerto, Rut)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Consultar Puntos Fidelizacion", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Function ValidarRedFidelizacionBono(Puerto As String) Implements IServiceTerminalHost.ValidarRedFidelizacionBono
        Try
            Dim valor As Short
            Dim oHelper As New Helper()
            If (oHelper.ValidarBonoDescuentoPromocion()) Then
                valor = 1
            Else
                valor = 0
            End If

            Return valor
        Catch EX As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", EX.Message)
            Fabrica.LogIt.Loguear("Error Validando el ", LogPropiedades, LogCategorias)
            RaiseEvent oEventos_ReportarExcepcion(EX.Message, True, False, Puerto)
            Throw
        End Try

    End Function

    Private Sub RealizarVentaConBonoSauce(CaraT As String, Tarjeta As String, TipoTarjeta As String, Puerto As String) Implements IServiceTerminalHost.RealizarVentaConBonoSauce

        Try

            Dim Cara As Byte = Convert.ToByte(CaraT)

            RaiseEvent oEventos_PredeterminarPagoVentaBonoFidelizacion(Cara, Tarjeta, Puerto)

        Catch ex As System.Exception

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Error Realizando venta con Bono", LogPropiedades, LogCategorias)
            RaiseEvent oEventos_ReportarExcepcion(ex.Message, True, False, Puerto)
            Throw
        End Try


    End Sub

    Public Sub PagoConBonoSauce(Ticket As String, NumeroTarjeta As String, TipoLectura As Byte, Puerto As String) Implements IServiceTerminalHost.PagoConBonoSauce

        Try
            Dim recibo As String = Ticket
            RaiseEvent OEventos_RedencionBonosFidelizacion(NumeroTarjeta, recibo, Puerto)
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Consultar Saldo Tarjeta Fidelizacion", LogPropiedades, LogCategorias)
            RaiseEvent oEventos_ReportarExcepcion(ex.Message, True, False, Puerto)
            Throw
        End Try
    End Sub



#End Region

#Region "Redencion Bono-Petromil"
    Public Function ValidarRedencioBono(ByVal NumeroTarjeta As String, ByVal TipoLectura As String, ByVal EsUltimaVenta As Boolean, ByVal cara_recibo As String, impresora As String) As RespuestaValidarRedecionBono Implements IServiceTerminalHost.ValidarRedencioBono
        Dim respuesta As New RespuestaValidarRedecionBono
        Dim ODataAccess As New Helper()
        Dim DatosVenta As IDataReader
        Dim oVenta As New DTOVenta
        Dim Recibo As Long
        Try
            Try
                respuesta.SaldoTarjeta = ConsultarSaldoTarjeta(NumeroTarjeta, CShort(TipoLectura), False, impresora)
            Catch ex As System.Exception
                respuesta.MensajeError = ex.Message.ToString
            End Try
            If EsUltimaVenta Then
                Recibo = Convert.ToInt64(ODataAccess.RecuperarReciboPorCara(cara_recibo))
            Else
                Recibo = Convert.ToInt64(cara_recibo)
            End If

            'SE VALIDA QUE LA VENTA NO HAYA SIDO FIDELIZADA O PAGADA CON BONO
            DatosVenta = ODataAccess.ValidarPagoConBonoFidelizacionSoyLeal(CLng(Recibo))

            If DatosVenta.Read Then
                oVenta.Cantidad = DatosVenta.Item("Cantidad")
                oVenta.Fecha = DatosVenta.Item("Fecha")
                oVenta.Precio = DatosVenta.Item("Precio")
                oVenta.Recibo = DatosVenta.Item("Recibo")
                oVenta.Valor = DatosVenta.Item("Valor")
                oVenta.Placa = DatosVenta.Item("Placa")
                oVenta.Manguera = DatosVenta.Item("Manguera")
                oVenta.Producto = DatosVenta.Item("Producto")
                oVenta.Descuento = DatosVenta.Item("Descuento")
                oVenta.FechaProximoMantenimiento = DatosVenta.Item("FechaProximoMantenimiento")

                DatosVenta.Close()
                DatosVenta = Nothing
            Else
                DatosVenta.Close()
                DatosVenta = Nothing
            End If

            respuesta.Venta = oVenta

        Catch ex As System.Exception
            Throw ex
        End Try
        Return respuesta
    End Function

    public Function ConsultarSaldoTarjeta(ByVal NumTarjeta As String, ByVal TipoLectura As Int16, ByVal esImpresion As Boolean, ByVal impresora As String) As String
        Dim ohelper As New Helper
        'Dim RespuestaSaldo As DataSet = Nothing

        Dim Ticket As String = ""
        Dim Mensaje As String = ""
        Dim ODataAccess As New Helper()
        Dim ODataSet As DataSet = Nothing
        Dim ORespuesta As Fabrica.Fidelizacion
        '  Dim OFidelizacion As New 
        Try
            ORespuesta = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(NumTarjeta)

            If ORespuesta Is Nothing Or ORespuesta.MensajeError <> "" Then
                Throw New System.Exception(ORespuesta.MensajeError)
            Else
                If ORespuesta.Saldos.Tables.Count > 0 Then
                    If esImpresion Then
                        'For Each item As DataRow In ORespuesta.Saldos.Tables(0).Rows
                        '    Ticket = ohelper.RecuperarReciboConsultaDeSaldo(NumTarjeta, item.Item("Conductor").ToString(), item.Item("Saldo").ToString(), _
                        '    Convert.ToDateTime(item.Item("Fecha").ToString()), True, item.Item("PuntosVencimiento").ToString(), item.Item("FechaVencimiento").ToString())
                        '    HippoCore.ImprimirSaldoTarjetaFidelizacion(Ticket, impresora, NumTarjeta)
                        'Next
                    Else
                        For Each item As DataRow In ORespuesta.Saldos.Tables(0).Rows
                            Mensaje = "Su saldo a la fecha " + item.Item("Fecha").ToString() + " es de: " + item.Item("Saldo").ToString()
                        Next
                    End If

                End If
            End If

            Return Mensaje
        Catch ex As System.Exception
            Throw ex
        End Try

    End Function

    Public Function Bonos() As System.Collections.Generic.List(Of DTOBono) Implements IServiceTerminalHost.Bonos
        Dim oDatos As New List(Of DTOBono)
        Dim oValor As DTOBono
        Dim hayBonosDisponibles As Boolean = False
        Try

            Dim oDataAccess As New Helper
            Dim drValidar As IDataReader = oDataAccess.RecuperarBonosLocalesReader()
            While drValidar.Read
                hayBonosDisponibles = True
                oValor = New DTOBono
                oValor.IdBono = drValidar("IdBono").ToString()
                oValor.NombreBono = drValidar("Nombre").ToString()
                oValor.TipoBono = drValidar("Tipo").ToString()
                oValor.Valor = drValidar("Valor").ToString()
                oValor.Puntos = drValidar("Puntos").ToString()
                oDatos.Add(oValor)
            End While
            If Not hayBonosDisponibles Then
                Throw New System.Exception("NO EXISTEN BONOS CONFIGURADOS")
            End If

        Catch ex As System.Exception
            Throw
        End Try
        Return oDatos
    End Function

    Public Sub PagarConBono(ByVal IdBono As String, ByVal Numerotarjeta As String, ByVal Venta As DTOVenta, ByVal impresora As String, ByVal usuario As String, ByVal clave As String) Implements IServiceTerminalHost.PagarConBono
        Try
            RaiseEvent OEventos_PagarVentaConBono(IdBono, Numerotarjeta, Venta, impresora, usuario, clave)
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub

    Public Function AplicaFidelizacionPorNumeroTarjeta() As Boolean Implements IServiceTerminalHost.AplicaFidelizacionPorNumeroTarjeta
        Try
            Dim oHelper As New Helper
            Return CBool(oHelper.RecuperarParametro("AplicaPagoConBonoPorNumeroTarjeta"))
        Catch ex As System.Exception
            Throw
        End Try
    End Function
#End Region

#Region "Remarcación canastilla"


    Public Function RecuperarProductosCanastilla(codProducto As Integer, MotivoCalibracion As Byte) Implements IServiceTerminalHost.RecuperarProductosCanastilla

        Try
            Dim oDataAccess As New Helper
            Dim AceptaExistencias As Boolean

            If (MotivoCalibracion = 1) Then
                AceptaExistencias = True
            Else
                AceptaExistencias = False
            End If

            Dim drProductos As IDataReader = oDataAccess.RecuperarProductoPorCodigoCanastilla(codProducto, AceptaExistencias)

            Dim Fila As String

            If drProductos.Read Then
                Fila = Convert.ToString(drProductos.Item("Descripcion"))
            Else
                Fila = ""
            End If

            drProductos.Close()

            Return Fila
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Recuperar Productos Canastilla", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Function


    Public Function ValidarProductosCanastilla(CodigoCanastilla As String, CantidadCanastilla As String, Puerto As String) As String Implements IServiceTerminalHost.ValidarProductosCanastilla


        Try
            Dim oDataAccess As New Helper
            Dim Descripcion As String = oDataAccess.ValidarRemarcacionCanastilla(Convert.ToInt32(CodigoCanastilla), CantidadCanastilla)

            If Not String.IsNullOrEmpty(Descripcion) Then
                Return Descripcion
            Else
                Throw New System.Exception("Remarcacion Inválida, La cantidad digitada supera las existencias")
            End If


        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validar Productos Canastilla", LogPropiedades, LogCategorias)

            RaiseEvent oEventos_ReportarExcepcion(ex.Message, True, False, Puerto)
            Throw
        End Try
    End Function



    Public Sub RemarcacionCanastilla(codigoBaja As String, Cantidad As String, CodigoAlta As String, Puerto As String) Implements IServiceTerminalHost.RemarcacionCanastilla

        Try
            RaiseEvent oEventos_EnviarRemarcacionCanastilla(codigoBaja, Cantidad, CodigoAlta, Puerto)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Remarcacion Canastilla", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub
#End Region


#Region "Recibo Combustible"

    Public Function ValidarDocumentoReciboCombustible(ByVal Documento As String, ByVal Placa As String, ByVal Puerto As String, ByVal AplicaReciboAjustePorOperacion As Boolean) As RespuestaReciboCombustible Implements IServiceTerminalHost.ValidarDocumentoReciboCombustible
        Dim oHelper As New Helper
        Dim RespuestaRec As New RespuestaReciboCombustible

        Try
            'Evaluamos lo que vamos a hacer en la ARMPos, si se va a comenzar un nuevo Recibo y terminar uno viejo
            If (Not oHelper.ExisteDocumentoReciboTmp(Documento)) Then
                RespuestaRec = ConfigurarProductos(Documento, Placa)
            Else
                'FALTA IMPLEMENTAR HASTA QUE SE TERMINE LA PARTE DE NUEVO PEDIDO
                ContinuarReciboCombustible(Documento, Puerto)
            End If

            'Los tanques no se encuentran bloqueados
            If AplicaReciboAjustePorOperacion Then
                IdTurnoCombustible = oHelper.RecuperarUltimoTurnoCerrado("").ToString()
            Else
                IdTurnoCombustible = "-1"
            End If

            'Los tanques no se encuentran bloqueados
            RespuestaRec.RealizarBloqueoTanque = False

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ValidarDocumentoReciboCombustible ", LogPropiedades, LogCategorias)
            Throw
        End Try

        Return RespuestaRec
    End Function



    Public Sub ValidarDocumentoReciboCombustibleColombia(ByVal Documento As String, ByVal Placa As String) Implements IServiceTerminalHost.ValidarDocumentoReciboCombustibleColombia

        Try
            Dim oDataAccess As New Helper
            'Instanciamos la clase ReciboDeCombustible
            OReciboCombustible = New ReciboDeCombustible()

            'Evaluamos lo que vamos a hacer en la MR, si se va a comenzar un nuevo Recibo y terminar uno viejo
            If (Not oDataAccess.ExisteDocumentoReciboTmp(Documento)) Then
                ConfigurarProductos(Documento, Placa)
            Else
                ''''comentado Yury mientras valido en la arm 
                'ContinuarReciboCombustible(Documento)
            End If

            'Los tanques no se encuentran bloqueados
            OReciboCombustible.RealizarBloqueoTanque = False

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validar Documento Recibo Combustible", LogPropiedades, LogCategorias)
            Throw

        End Try
    End Sub


    Public Function ConfigurarProductos(ByVal Documento As String, ByVal Placa As String) As RespuestaReciboCombustible Implements IServiceTerminalHost.ConfigurarProductos

        Dim Respuesta As New RespuestaReciboCombustible
        Dim ListaProductos As New List(Of Productos)
        Dim oHelper As New Helper

        Try
            OReciboCombustible = oHelper.RecuperarProductosCombustiblePedido(Documento, Placa)
            Respuesta.PermiteVentaReciboComb = True

            'If Convert.ToBoolean(oHelper.RecuperarParametro("PermitirVentasReciboComb")) = True Then
            '    OReciboCombustible = oHelper.RecuperarProductosCombustiblePedido(Documento, Placa)
            '    Respuesta.PermiteVentaReciboComb = True
            'Else
            '    OReciboCombustible = oHelper.RecuperarProductosCombustiblePedido(Documento, Placa, CodigoTanque)
            '    Respuesta.PermiteVentaReciboComb = False
            'End If

            Respuesta.EsPedidoLocal = True
            Respuesta.EsLeyFrontera = OReciboCombustible.EsLeyFrontera



            ''''comentado Yury mientras valido en la arm 
            ' OReciboCombustible.IdTurno = IdTurnoCombustible

            '//Seguimos armando el paquete que va para la MR
            Dim producto As Productos
            'Seguimos armando el paquete que va para la Arm
            For Each oProducto As CantidadProductos In OReciboCombustible.lstProductos
                producto = New Productos
                producto.Codigo = oProducto.CodigoProducto
                producto.Nombre = oProducto.Nombre
                ListaProductos.Add(producto)
            Next

            Respuesta.LstProductos = ListaProductos

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Configurar Productos Recibo Combustible", LogPropiedades, LogCategorias)
            Throw

        End Try

        Return Respuesta
    End Function


    Public Function ValidarConfiguracionCombustible(ByVal Puerto As String) As Integer Implements IServiceTerminalHost.ValidarConfiguracionCombustible

        Dim Valor As Integer
        Dim oDataAccess As New Helper
        Try
            If (Convert.ToBoolean(oDataAccess.RecuperarParametro("PermitirVentasReciboComb"))) Then
                Valor = 1
            Else
                Valor = 0
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Error al Validar la configuracion de combustible, LogPropiedades, LogCategorias", LogPropiedades, LogCategorias)
            RaiseEvent oEventos_ReportarExcepcion(ex.Message, True, False, Puerto)
            Throw
        End Try
        Return Valor
    End Function

    Public Function IniciaTanques() As System.Collections.Generic.List(Of DTOTanque) Implements IServiceTerminalHost.IniciaTanques
        Dim lista As New List(Of DTOTanque)
        Dim lector As IDataReader = Nothing
        Dim oHelper As New Helper
        Try
            Dim oTanque As DTOTanque
            lector = oHelper.RecuperarTanques()

            While lector.Read
                oTanque = New DTOTanque
                oTanque.IdTanque = CInt(lector("IdTanque").ToString())
                oTanque.Descripcion = (lector("Descripcion").ToString())
                oTanque.CodigoTanque = (lector("Codigo").ToString())
                lista.Add(oTanque)
            End While
            lector.Close()
            lector.Dispose()

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en IniciaTanques", LogPropiedades, LogCategorias)
            Throw
        End Try
        Return lista
    End Function

    Public Sub EliminarPedidoCombustible(ByVal Documento As String) Implements IServiceTerminalHost.EliminarPedidoCombustible
        Try
            Dim oHelper As New Helper
            oHelper.EliminarPedidoCombustible(OReciboCombustible.Documento)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Eliminar Pedido de Combustible", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Private Sub ContinuarReciboCombustible(ByVal Documento As String, ByVal Puerto As String)
        Dim oHelper As New Helper
        Try
            OReciboCombustible = oHelper.RecuperarReciboCombustibleTmp(Documento)

            'Enviamos la Información de lo que se debe realizar en la MR,
            'Ya sea Ajuste por Operación, Si se va a Finalizar el Pedido o Ajuste por Recibo
            'Evaluamos inicialmente si se va a finalizar el pedido
            If (OReciboCombustible.Estado = Convert.ToInt32(RecuperacionReciboCombustible.Finalizar)) Then

                'StringTx = "T2|"

            ElseIf (OReciboCombustible.Estado = Convert.ToInt32(RecuperacionReciboCombustible.Terminado)) Then
                ' RaiseEvent OEventos_ImprimirDocumentoReciboCombustible(Documento, TotalCantidadPorVenta, Puerto)
                '''''' LimpiarVariables()

            Else
                'Evaluamos si es ajuste por recibo o por operación
                If (OReciboCombustible.Estado = Convert.ToInt32(RecuperacionReciboCombustible.AjusteOperacion)) Then
                    OReciboCombustible.EsAjusteOperacion = True
                Else
                    OReciboCombustible.EsAjusteOperacion = False
                    'Mandamos a revisar las mangueras para continuar desde ese momento el proceso
                    ''''*********   comentado Yury mientras valido en la arm 
                    'RevisarManguerasReciboCombustible(Nothing, OReciboCombustible.Estado, Puerto)
                End If

            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ContinuarReciboCombustible ", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Function RecuperaProductosPorCodigoTanque(ByVal TanqueRecibo As String) As RespuestaReciboCombustible Implements IServiceTerminalHost.RecuperaProductosPorCodigoTanque
        Dim Respuesta As New RespuestaReciboCombustible
        Try
            'ConfigurarProductosPorTanques(OReciboCombustible.Documento, OReciboCombustible.Placa, TanqueRecibo)
            CodigoTanque = TanqueRecibo
            Respuesta.Documento = OReciboCombustible.Documento
            Respuesta.Placa = OReciboCombustible.Placa

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validar Tanque Recibo Combustible", LogPropiedades, LogCategorias)
            Throw
        End Try

        Return Respuesta
    End Function


    Public Function InsertarDetalleReciboCombustible(ByVal ProductosRecibo As List(Of Productos), ByVal Documento As String, ByVal Placa As String) As List(Of ValidacionTanquesEnRecibo) Implements IServiceTerminalHost.InsertarDetalleReciboCombustible
        Dim oHelper As New Helper
        Dim drValidar As IDataReader = Nothing
        Dim ListaTanquesIncorrecto As New List(Of Productos)
        Dim tanqueTemporal As ValidacionTanquesEnRecibo
        Dim Respuesta As New List(Of ValidacionTanquesEnRecibo)

        Try
            For Each elemento As Productos In ProductosRecibo
                drValidar = oHelper.ValidarProductoEnTanque(elemento.Tanque, elemento.Cantidad, elemento.Codigo)

                'Verificamos si se traen datos, aunque siempre se trae al menos 1
                If drValidar.Read Then
                    If Convert.ToBoolean(drValidar("EsValido")) Then
                        OReciboCombustible.AgregarConfiguracionReciboCombustible(elemento.Tanque, elemento.Codigo, elemento.Cantidad, oHelper.RecuperarProductoCombustibleCodigo(elemento.Codigo))
                    Else
                        'Devuelvo los tanques incorrectos para que sean borrados de la lista
                        tanqueTemporal = New ValidacionTanquesEnRecibo
                        tanqueTemporal.CodigoTanque = elemento.Tanque
                        tanqueTemporal.Mensaje = drValidar("Mensaje")
                        tanqueTemporal.CapacidadTanque = drValidar("Capacidad")
                        Respuesta.Add(tanqueTemporal)
                    End If
                End If
            Next

            'Si la validacion de tanques/productos sale bien guardamos el pedido
            'If Respuesta.Count = 0 Then
            '    AdicionarProductoADocumento(ProductosRecibo, Documento, Placa)
            'End If




        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en InsertarDetalleReciboCombustible ", LogPropiedades, LogCategorias)
            Throw
        End Try

        Return Respuesta
    End Function




    Public Sub AdicionarProductoADocumento(ByVal ProductosPedido As List(Of Productos), ByVal Documento As String, ByVal Placa As String) Implements IServiceTerminalHost.AdicionarProductoADocumento
        Try
            Dim CapacidadTanque As New Dictionary(Of String, Decimal)
            Dim Sum As Decimal = 0

            Dim oHelper As New Helper
            Dim listaConfiguracionRecibo As New List(Of ConfiguracionReciboCombustible)

            For Each elemento As Productos In ProductosPedido
                'Insertamos los datos temporalmente en la BD
                oHelper.InsertarPedidoCombustibleTmp(Documento, oHelper.RecuperarIdProductoCombustible(Convert.ToInt16(elemento.Codigo)), elemento.Cantidad, CBool(elemento.EsLeyFrontera))
                Dim oConfiguracionRecibo As New ConfiguracionReciboCombustible
                oConfiguracionRecibo.Tanque = elemento.Tanque
                oConfiguracionRecibo.CodProducto = elemento.Codigo
                oConfiguracionRecibo.NombreProducto = elemento.Nombre
                oConfiguracionRecibo.Cantidad = elemento.Cantidad
                listaConfiguracionRecibo.Add(oConfiguracionRecibo)


                If Not CapacidadTanque.Keys.Contains(oConfiguracionRecibo.Tanque) Then
                    CapacidadTanque.Add(oConfiguracionRecibo.Tanque, oConfiguracionRecibo.Cantidad)
                Else
                    If CapacidadTanque.ContainsKey(oConfiguracionRecibo.Tanque) Then
                        CapacidadTanque(oConfiguracionRecibo.Tanque) = CDec(CapacidadTanque(oConfiguracionRecibo.Tanque).ToString) + oConfiguracionRecibo.Cantidad
                    End If

                End If

            Next


            If CapacidadTanque.Count > 0 Then
                For Each KeyTanque As KeyValuePair(Of String, Decimal) In CapacidadTanque
                    oHelper.ValidarCapacidadTanque(Convert.ToDecimal(KeyTanque.Value), Convert.ToInt16(KeyTanque.Key))
                Next
            End If


            'Mandamos a insertar el pedido
            oHelper.InsertarPedidoCombustible(Documento)

            If listaConfiguracionRecibo.Count > 0 Then
                OReciboCombustible.lstConfiguracionRecibo = listaConfiguracionRecibo.ToList()
            Else
                Throw New System.Exception("No se recibieron productos, por favor verifique. ")
            End If


            'Recuperamos la Información y la mandamos a la MR
            'ConfigurarProductos(OReciboCombustible.Documento, OReciboCombustible.Placa);

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar(Categoria)
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en AdicionarProductoADocumento ", LogPropiedades, LogCategorias)
            Throw
        End Try

    End Sub

    Public Sub InsertarReciboCombustible(puerto As String) Implements IServiceTerminalHost.InsertarReciboCombustible
        Try
            'Cantidad que vamos a insertar
            Dim cantidad As Decimal = 0
            'Determina si es ley de frontera o no
            Dim EsLeyFrontera As Boolean = False
            Dim SaldoAntesAjuste As Decimal = 0
            Dim SaldoDespuesAjuste As Decimal = 0
            Dim CantidadTemp As Nullable(Of Decimal) = 0
            ' Dim ExcedeParametroAjuste As Boolean = False
            Dim oHelper As New Helper

            'Recorremos la configuración que tenemos de los tanqueos
            For i As Int16 = 0 To OReciboCombustible.lstConfiguracionRecibo.Count - 1
                'Obtenemos el valor de Ley de Frontera para ese producto
                Dim valor As Decimal = oHelper.RecuperarLeyFronteraPedidoCombustible(OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo(i).CodProducto)
                SaldoAntesAjuste = oHelper.RecuperarSaldoTanque(OReciboCombustible.lstConfiguracionRecibo(i).Tanque, Convert.ToInt16(OReciboCombustible.lstConfiguracionRecibo(i).CodProducto))
                CodigoTanque = OReciboCombustible.lstConfiguracionRecibo(i).Tanque

                'Evaluamos que el valor sea igual a 0, osea, no tiene ley de frontera ese producto
                If valor = 0 Then
                    cantidad = OReciboCombustible.lstConfiguracionRecibo(i).Cantidad
                    EsLeyFrontera = False
                Else
                    'Evaluamos si la Cantidad es mayor que el valor a insertar
                    If (OReciboCombustible.lstConfiguracionRecibo(i).Cantidad > valor) Then
                        cantidad = valor
                        EsLeyFrontera = True

                        'Mandamos al kardex para que vaya a insertar el tanqueo con ley de frontera, siendo la cantidad el valor recuperado
                        POSstation.Inventario.ManagementKardex.InsertarRecibodeCombustibles(cantidad, 0, OReciboCombustible.Placa, OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo(i).Tanque, 0, OReciboCombustible.lstConfiguracionRecibo(i).CodProducto, EsLeyFrontera)


                        'Obtenemos la cantidad en base a la cantidad del producto en ese tanque y la variable valor
                        cantidad = OReciboCombustible.lstConfiguracionRecibo(i).Cantidad - valor
                        EsLeyFrontera = False
                    Else
                        'Evaluamos si la Cantidad es Menor que el valor
                        If (OReciboCombustible.lstConfiguracionRecibo(i).Cantidad < valor) Then
                            cantidad = OReciboCombustible.lstConfiguracionRecibo(i).Cantidad
                            EsLeyFrontera = True

                        Else
                            cantidad = valor
                            EsLeyFrontera = True
                        End If
                    End If
                End If

                'Obtenemos el IdProducto
                Dim idProducto As Int32 = oHelper.RecuperarIdProductoCombustible(OReciboCombustible.lstConfiguracionRecibo(i).CodProducto)
                'Mandamos al kardex para que vaya a insertar el tanqueo sin ley de frontera
                POSstation.Inventario.ManagementKardex.InsertarRecibodeCombustibles(cantidad, 0, OReciboCombustible.Placa, OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo(i).Tanque, 0, idProducto, EsLeyFrontera)

                'Para la impresión del ticket
                Dim saldo As Decimal = oHelper.RecuperarSaldoTanque(OReciboCombustible.lstConfiguracionRecibo(i).Tanque, Convert.ToInt16(OReciboCombustible.lstConfiguracionRecibo(i).CodProducto))
                POSstation.Inventario.ManagementKardex.ActualizarDistribucionCombustible(OReciboCombustible.Documento, OReciboCombustible.lstConfiguracionRecibo(i).Tanque, OReciboCombustible.lstConfiguracionRecibo(i).CodProducto, OReciboCombustible.lstConfiguracionRecibo(i).Cantidad, 0, CantidadTemp)
            Next

            'Mandamos a Actualizar ReciboCombustibleTmp
            oHelper.ActualizarReciboCombustibleTmp(OReciboCombustible, Convert.ToInt32(RecuperacionReciboCombustible.AjusteRecibo))

            'Avisamos para que desbloqueen los tanques luego que hagan el ajuste por recibo
            OReciboCombustible.RealizarBloqueoTanque = True


            RaiseEvent OEventos_ImprimirDocumentoReciboCombustible(OReciboCombustible.Documento, "0", puerto)

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Insertar Recibo Combustible", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub
#End Region


    Public Sub ValidarIsleroAnulacion(ByVal IdEmpleado As String, ByVal Password As String) Implements IServiceTerminalHost.ValidarIsleroAnulacion

        Try
            Dim idTipoTurno As Int16
            Dim IdTurno As Int32
            Dim ohelper As New Helper()
            oFactura = New Factura()
            Dim MediosLectura As New MediosLectura()
            Dim drTurno As IDataReader = ohelper.RecuperarTurnoCredencialesPorTipo(IdEmpleado, Password)
            If drTurno.Read() Then
                idTipoTurno = Convert.ToInt16(drTurno("IdTipoTurno").ToString())
                IdTurno = Convert.ToInt32(drTurno("IdTurno").ToString())
            End If

            drTurno.Close()

        Catch ex As System.Exception

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Validar Islero Consignación", LogPropiedades, LogCategorias)
            Throw
            'StringTx = "C" + ex.Message + "|";
        End Try
    End Sub


    Public Sub AnularFacturaCanastilla(ByVal Prefijo As String, ByVal Consecutivo As String, ByVal IdEmpleado As String, ByVal Password As String, ByVal Puerto As String) Implements IServiceTerminalHost.AnularFacturaCanastilla

        Try
            Dim oDataAccess As New Helper()

            If (Prefijo = "0") Then
                Prefijo = String.Empty
            End If


            If oDataAccess.ValidarFacturaTerpel(Prefijo, Convert.ToInt16(Consecutivo)) Then
                'StringTx = "Y|";
                RaiseEvent oEventos_AnularFacturaCanastilla(Prefijo, Consecutivo, IdEmpleado, Password, Puerto)
            End If


        Catch ex As System.Exception


            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Anular Factura Canastilla Terpel", LogPropiedades, LogCategorias)
            Throw
            'StringTx = "E1-" + ex.Message + "|";
        End Try

    End Sub

    Public Sub ValidarIsleroCambioCheque(ByVal IdEmpleado As String, ByVal Password As String) Implements IServiceTerminalHost.ValidarIsleroCambioCheque

        Try
            Dim oDataAccess As New Helper

            If (oDataAccess.ValidarCredenciales(IdEmpleado, Password)) Then
                IdTurno = Int32.Parse(oDataAccess.RecuperarTurnoAbiertoPorEmpleado(IdEmpleado))
            Else
                Throw New System.Exception("Credenciales Inválidas")
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en ValidarIsleroCambioCheque", LogPropiedades, LogCategorias)
            Throw

        End Try
    End Sub


    Public Function ValidarCambioCheque(ByVal NumAutorizacion As String, ByVal ValorCheque As String, ByVal Recibo As String) As Decimal Implements IServiceTerminalHost.ValidarCambioCheque

        Try
            Dim valorCambio As Decimal
            Dim oDataAccess As New Helper()


            If (Recibo <> "0") Then
                If (Not oDataAccess.ExisteRecibo(Convert.ToInt64(Recibo))) Then
                    Throw New System.Exception("No existe recibo de venta " + Convert.ToString(Recibo))
                Else
                    Cara = oDataAccess.RecuperarCaraPorReciboVenta(Convert.ToInt32(Recibo))
                    If Not String.IsNullOrEmpty(Cara) Then
                        'Valor del Cambio
                        valorCambio = Convert.ToDecimal(oDataAccess.ValidarCheque(Convert.ToInt64(NumAutorizacion), Convert.ToDecimal(ValorCheque), Convert.ToInt64(Recibo)))
                    Else
                        Throw New System.Exception("No existe una Cara con informacion del recibo: " + (Convert.ToInt32(Recibo)))
                    End If

                End If
            End If

            Return valorCambio
        Catch ex As System.Exception

            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Factura Venta Producto", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Function



    Public Sub InsertarCambioCheque(ByVal Valor As String, ByVal ValorCambio As String, ByVal NumAutorizacion As String, ByVal Recibo As String, ByVal Puerto As String) Implements IServiceTerminalHost.InsertarCambioCheque

        Try
            Dim oDataAccess As New Helper()
            Dim tempTurno As Int16 = 0

            If Not String.IsNullOrEmpty(IdTurno) Then
                tempTurno = Convert.ToInt32(IdTurno)
            End If

            '//Evaluamos si el valor digitado es menor que el valor del cambio
            'If (Valor > Convert.ToDouble(ValorCambio)) Then
            '    Throw New System.Exception("El valor digitado supera el valor del cambio.")
            'Else
            oDataAccess.InsertarCambioChequeMr(Convert.ToInt64(NumAutorizacion), Convert.ToDecimal(ValorCambio), tempTurno, Convert.ToInt64(Recibo), Convert.ToInt16(Cara))
            '//Lanzamos el evento

            RaiseEvent oEventos_EnviarCambioCheque(NumAutorizacion, tempTurno, Convert.ToByte(Cara), Recibo, Convert.ToDouble(ValorCambio), Convert.ToDouble(Valor), Puerto)
            'End If


        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoMRHost")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("Excepcion en Factura Venta Producto", LogPropiedades, LogCategorias)
            Throw
        End Try
    End Sub

    Public Function RecuperarMediosdePagoPrepago() As List(Of DTOMedioPago) Implements IServiceTerminalHost.RecuperarMediosdePagoPrepago
        Dim oMedioPago As DTOMedioPago
        Dim lstMediosPago As New List(Of DTOMedioPago)
        Dim oHelper As New Helper
        Dim lector As IDataReader

        Try
            lector = oHelper.RecuperarFormaPagoCanastillaPrepago()

            While lector.Read
                oMedioPago = New DTOMedioPago
                oMedioPago.IdMedioPago = lector("IdFormaPago")
                oMedioPago.Descripcion = lector("Descripcion")
                lstMediosPago.Add(oMedioPago)
            End While
        Catch Ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", Ex.Message)
            Fabrica.LogIt.Loguear("ERROR en [RecuperarMediosdePagoPrepago]: ", LogPropiedades, LogCategorias)
            Throw New System.Exception("ERROR en [RecuperarMediosdePagoPrepago]: " & vbNewLine & Ex.Message)
        End Try

        Return lstMediosPago
    End Function


    Public Sub RecargarTarjeta(Usuario As String, Clave As String, Recarga As RecargaPrepago, Puerto As String) Implements IServiceTerminalHost.RecargarTarjeta
        Dim oHelper As New Helper
        Dim lector As IDataReader
        Dim idTurno, idCupo As Integer

        Try
            lector = oHelper.RecuperarTurnoCredencialesPorTipo(Usuario, Clave)

            If lector.Read() Then
                idTurno = CInt(lector("IdTurno"))
                idCupo = oHelper.InsertarCupoTarjeta(Recarga.Tarjeta, CDbl(Recarga.ValorRecarga), idTurno)

                For Each Pago As DTOMedioPago In Recarga.Pagos
                    Call oHelper.InsertarCupoPrepagoDetalle(idCupo, Pago.IdMedioPago, CDbl(Pago.Valor))
                Next

                RaiseEvent oEventos_ImprimirRecargaPrepago(idCupo, Puerto)
            Else
                Throw New System.Exception("Error al validar las credenciales del islero. Verifique que exista y tenga un turno abierto.")
            End If

            lector.Close()
            lector.Dispose()
        Catch Ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("Anomalia")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", Ex.Message)
            Fabrica.LogIt.Loguear("ERROR en [RecargarTarjeta]: ", LogPropiedades, LogCategorias)
            Throw New System.Exception("ERROR en [RecargarTarjeta]: " & vbNewLine & Ex.Message)
        End Try
    End Sub



End Class

