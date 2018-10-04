Imports POSstation.AccesoDatos
Imports POSstation.Fabrica

Public Class CDCServices
    Public Shared LogFallas As New EstacionException
    Public Shared ListaPrepagosCanastilla As New Collection
    Public Shared LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog

    Public Shared Function AutorizarIdentificadorCDCCOFIDE(ByVal Identificador As String, ByVal placa As String, ByVal FechaMantenimiento As Date) As ResponseAutorizacionIdentificador
        Dim ODataAccess As New POSstation.AccesoDatos.Helper
        Dim OResponse As New ResponseAutorizacionIdentificador
        Dim Servicio As New CentroInformacion.CentroInformacion
        Dim RespuestaCDC As CentroInformacion.ResponseAutorizarIdentificador
        Try
            Servicio.Url = ODataAccess.RecuperarParametro("ServicioEspecializado")
            RespuestaCDC = Servicio.AutorizacionIdentificador(Identificador, placa, FechaMantenimiento)

            OResponse.Autorizado = RespuestaCDC.Autorizado
            OResponse.Resultado = RespuestaCDC.Respuesta
            'MsgBox(RespuestaCDC.Respuesta)
            Return OResponse
        Catch ex As System.Exception
            OResponse.Autorizado = False
            OResponse.Resultado = ex.Message
            Return OResponse
        End Try
    End Function

    Public Shared Function RecuperarDatosCreditoConversionChile(ByVal Placa As String) As Fabrica.RespuestaConsultaCopagosAbonoCDI
        Dim oInformacionVehiculo As New Fabrica.RespuestaConsultaCopagosAbonoCDI
        Try
            Dim ODataAccess As New POSstation.AccesoDatos.Helper
            Dim oData As New CDIChile.Comunicacion
            Dim oRespuestaCDC As CDIChile.RespuestaVentaCredito = Nothing

            oData.Url = ODataAccess.RecuperarParametro("ServicioEspecializado")
            oRespuestaCDC = oData.ConsultarInformacionVentaCredito(Placa)

            If oRespuestaCDC Is Nothing Then
                oInformacionVehiculo.EsProcesado = False
            Else
                If oRespuestaCDC.EsProcesado Then
                    oInformacionVehiculo.EsProcesado = True
                    oInformacionVehiculo.CopagoAcumulado = oRespuestaCDC.CopagoAcumulado
                    oInformacionVehiculo.CopagoRestante = oRespuestaCDC.CopagoRestante
                Else
                    oInformacionVehiculo.EsProcesado = False
                    oInformacionVehiculo.CopagoAcumulado = oRespuestaCDC.CopagoAcumulado
                    oInformacionVehiculo.CopagoRestante = oRespuestaCDC.CopagoRestante
                    Throw New System.Exception("Respuesta CDCChile: " & oRespuestaCDC.MensajeError)
                End If
            End If
            Return oInformacionVehiculo
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarDatosCreditoConversionChile", "Placa: " & Placa, "AutorizadorRemoto")
            Return oInformacionVehiculo
        End Try
    End Function



    Public Shared Function RecuperarDatosMetaDeConsumo(ByVal Placa As String) As POSstation.Fabrica.RespuestaMetaConsumo
        Dim oInformacionVehiculo As New POSstation.Fabrica.RespuestaMetaConsumo
        Try
            Dim ODataAccess As New POSstation.AccesoDatos.Helper

            Dim oData As New CDIChile.Comunicacion
            Dim oRespuestaCDC As CDIChile.MentaMensual = Nothing

            oData.Url = ODataAccess.RecuperarParametro("ServicioEspecializado")
            oRespuestaCDC = oData.RecuperarMetaMensual(Placa)


            If oRespuestaCDC Is Nothing Then
                oInformacionVehiculo.EsProcesado = False
            Else
                If oRespuestaCDC.EsProcesado Then
                    oInformacionVehiculo.EsProcesado = True
                    oInformacionVehiculo.MetaMensual = oRespuestaCDC.MetaMensual
                    oInformacionVehiculo.ConsumoMes = oRespuestaCDC.AcumuladoMes
                Else
                    oInformacionVehiculo.EsProcesado = False
                    Throw New System.Exception("Respuesta CDCChile Meta Consumo: " & oRespuestaCDC.MensajeError)
                End If
            End If
            Return oInformacionVehiculo
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarDatosMetaDeConsumo", "Placa: " & Placa, "AutorizadorRemoto")
            Return oInformacionVehiculo
        End Try
    End Function

    Public Shared Function AutorizarVentaCreditoManual(ByVal placa As String, ByVal Recibo As Long, ByVal IdentificacionCliente As String, ByVal ROM As String, ByVal NroGuiaDespacho As String) As RespuestaAutorizacionGerenciamiento
        Dim Comunicador As New CDIChile.Comunicacion
        Dim DatosAutorizacion As New CDIChile.AutorizacionManualCredito
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim RespuestaCDC As CDIChile.RespuestaAutorizacionGerenciamiento = Nothing
        Dim Respuesta As New RespuestaAutorizacionGerenciamiento
        Try
            Comunicador.Url = OData.RecuperarParametro("ServicioGeneral")

            DatosAutorizacion.Placa = placa
            DatosAutorizacion.CodEstacion = OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo")
            DatosAutorizacion.Recibo = Recibo
            DatosAutorizacion.IdentificacionCliente = IdentificacionCliente
            DatosAutorizacion.NroGuiaDespacho = NroGuiaDespacho
            DatosAutorizacion.ROM = ROM


            LogCategorias.Clear()
            LogCategorias.Agregar("Gerenciamiento Manual")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("placa", placa)
            LogPropiedades.Agregar("Recibo", Recibo.ToString)
            LogPropiedades.Agregar("IdentificacionCliente", IdentificacionCliente)
            LogPropiedades.Agregar("NroGuiaDespacho", NroGuiaDespacho)
            LogPropiedades.Agregar("ROM", ROM)
            POSstation.Fabrica.LogIt.Loguear("Se Envio los datos al crm: ", LogPropiedades, LogCategorias)


            RespuestaCDC = Comunicador.AutorizarVentaCreditoManual(DatosAutorizacion)

            If RespuestaCDC.EsAutorizado Then
                Respuesta.EsAutorizado = RespuestaCDC.EsAutorizado
                Respuesta.IdAutorizacion = RespuestaCDC.IdAutorizacion
                Respuesta.SaldoDisponible = RespuestaCDC.SaldoDisponible
                Respuesta.IdFormaPago = RespuestaCDC.IdFormaPago
                Respuesta.ConsumoMes = Respuesta.ConsumoMes

                LogCategorias.Clear()
                LogCategorias.Agregar("Gerenciamiento Manual")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("placa", placa)
                LogPropiedades.Agregar("Recibo", Recibo.ToString)
                POSstation.Fabrica.LogIt.Loguear("Autorizado: ", LogPropiedades, LogCategorias)

            Else
                Respuesta.MensajeError = RespuestaCDC.MensajeError
                LogCategorias.Clear()
                LogCategorias.Agregar("Gerenciamiento Manual")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("placa", placa)
                LogPropiedades.Agregar("Recibo", Recibo.ToString)
                LogPropiedades.Agregar("Mensaje", RespuestaCDC.MensajeError)
                POSstation.Fabrica.LogIt.Loguear("No Autorizado: ", LogPropiedades, LogCategorias)
            End If


        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AutorizarVentaCreditoManual", "Placa: " & placa & "Recibo: " & Recibo, "AutorizadorRemoto")
            Respuesta.EsAutorizado = False
            Respuesta.MensajeError = ex.Message
        End Try
        Return Respuesta
    End Function

    Public Shared Function MovimientosPrepago(Tarjeta As String) As List(Of MovimientoTarjeta)
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New Comunicacion.Comunicacion
        Dim ListaPrepago As New List(Of MovimientoTarjeta)
        Dim movimiento As MovimientoTarjeta
        Dim Respuesta() As Comunicacion.Movimiento

        Try
            Comunicador.Url = OData.RecuperarParametro("ServicioGeneral")
            Respuesta = Comunicador.MovimientosPrepago(Tarjeta, "")

            For Each item As Comunicacion.Movimiento In Respuesta
                movimiento = New MovimientoTarjeta
                movimiento.FechaHora = item.FechaHora
                movimiento.Valor = item.Valor
                ListaPrepago.Add(movimiento)
            Next

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "MovimientosPrepago", "Tarjeta: " & Tarjeta, "AutorizadorRemoto")
            Throw ex
        End Try
        Return ListaPrepago
    End Function


    Public Shared Function SaldoTarjeta(Tarjeta As String) As RespuestaSaldo
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New Comunicacion.Comunicacion
        Dim respuestaCM As Comunicacion.RespuestaSaldo
        Dim respuestaEST As RespuestaSaldo

        Try
            Comunicador.Url = OData.RecuperarParametro("ServicioGeneral")
            respuestaCM = Comunicador.RecuperarSaldoTarjeta(Tarjeta, "")
            respuestaEST = New RespuestaSaldo
            respuestaEST.Saldo = respuestaCM.Saldo
            respuestaEST.Placa = respuestaCM.Placa
            respuestaEST.Cliente = respuestaCM.Cliente

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "MovimientosPrepago", "Tarjeta: " & Tarjeta, "AutorizadorRemoto")
            Throw ex
        End Try
        Return respuestaEST
    End Function
    Public Shared Function AutorizarVentaGerenciamiento(ByVal idProducto As Int32, ByVal placa As String, ByVal precio As Decimal, ByVal kilometraje As String, ByVal RucCoductor As String) As Fabrica.RespuestaAutorizacionGerenciamiento
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New Comunicacion.Comunicacion
        Dim DatosAutorizacion As New Comunicacion.AutorizacionGerenciamiento
        Dim RespuestaCDC As New Comunicacion.RespuestaAutorizacionGerenciamiento
        Dim Respuesta As New Fabrica.RespuestaAutorizacionGerenciamiento

        Try
            Comunicador.Url = OData.RecuperarParametro("ServicioGeneral")

            DatosAutorizacion.Placa = placa
            DatosAutorizacion.Precio = precio
            DatosAutorizacion.IdProducto = idProducto
            DatosAutorizacion.CodEstacion = OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo")
            DatosAutorizacion.Kilometraje = kilometraje
            If Not String.IsNullOrEmpty(RucCoductor) Then
                DatosAutorizacion.RUCConductor = RucCoductor
            Else
                DatosAutorizacion.RUCConductor = ""
            End If



            LogCategorias.Clear()
            LogCategorias.Agregar("Gerenciamiento")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("placa", placa.ToString)
            LogPropiedades.Agregar("precio", precio.ToString)
            LogPropiedades.Agregar("idProducto", idProducto.ToString)
            LogPropiedades.Agregar("CodEstacion", OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo"))
            If Not String.IsNullOrEmpty(kilometraje) Then
                LogPropiedades.Agregar("kilometraje", kilometraje)
            End If

            'LogPropiedades.Agregar("RucCoductor", RucCoductor.ToString)
            POSstation.Fabrica.LogIt.Loguear("Se Envio los datos al crm: ", LogPropiedades, LogCategorias)



            RespuestaCDC = Comunicador.AutorizarVentaGerenciamiento(DatosAutorizacion)

            If RespuestaCDC.EsAutorizado Then
                Respuesta.EsAutorizado = RespuestaCDC.EsAutorizado
                Respuesta.IdAutorizacion = RespuestaCDC.IdAutorizacion
                Respuesta.SaldoDisponible = RespuestaCDC.SaldoDisponible
                Respuesta.MensajeError = RespuestaCDC.MensajeError
                Respuesta.IdFormaPago = RespuestaCDC.IdFormaPago
                Respuesta.ValorAutorizado = RespuestaCDC.ValorAutorizado
                Respuesta.ConsumoMes = 0

                LogCategorias.Clear()
                LogCategorias.Agregar("Gerenciamiento")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("placa", placa.ToString)
                LogPropiedades.Agregar("precio", precio.ToString)
                LogPropiedades.Agregar("idProducto", idProducto.ToString)
                LogPropiedades.Agregar("MensajeError", RespuestaCDC.MensajeError)
                LogPropiedades.Agregar("EsAutorizado", RespuestaCDC.EsAutorizado)
                LogPropiedades.Agregar("ValorAutorizado", RespuestaCDC.ValorAutorizado)
                POSstation.Fabrica.LogIt.Loguear("Respuesta credito consumo CRM: ", LogPropiedades, LogCategorias)

            Else
                LogCategorias.Clear()
                LogCategorias.Agregar("Gerenciamiento")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("placa", placa.ToString)
                LogPropiedades.Agregar("precio", precio.ToString)
                LogPropiedades.Agregar("idProducto", idProducto.ToString)
                LogPropiedades.Agregar("CodEstacion", OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo"))
                LogPropiedades.Agregar("MensajeError", RespuestaCDC.MensajeError)
                LogPropiedades.Agregar("EsAutorizado", RespuestaCDC.EsAutorizado)
                POSstation.Fabrica.LogIt.Loguear("Respuesta credito consumo CRM: ", LogPropiedades, LogCategorias)
                Respuesta.MensajeError = RespuestaCDC.MensajeError
            End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AutorizarVentaGerenciamiento", "Placa: " & placa & ", PrecioProducto: " & precio, "AutorizadorRemoto")
            Respuesta.EsAutorizado = False
            Respuesta.MensajeError = ex.Message
        End Try
        Return Respuesta

    End Function



    Public Shared Function AutorizarVentaGerenciamientoChile(ByVal idProducto As Int32, ByVal placa As String, ByVal precio As Decimal, ByVal kilometraje As String, ByVal RucCoductor As String, ByVal TarjetaPrepago As String, ByVal EsPrepago As Boolean) As RespuestaAutorizacionGerenciamiento
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New Comunicacion.Comunicacion
        Dim DatosAutorizacion As New Comunicacion.AutorizacionGerenciamiento
        Dim RespuestaCDC As New Comunicacion.RespuestaAutorizacionGerenciamiento
        Dim Respuesta As New RespuestaAutorizacionGerenciamiento

        Try
            Comunicador.Url = OData.RecuperarParametro("ServicioGeneral")


            LogCategorias.Clear()
            LogCategorias.Agregar("Gerenciamiento")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("placa", placa.ToString)
            LogPropiedades.Agregar("precio", precio.ToString)
            LogPropiedades.Agregar("idProducto", idProducto.ToString)
            LogPropiedades.Agregar("CodEstacion", OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo"))
            LogPropiedades.Agregar("TarjetaPrepago", TarjetaPrepago)
            LogPropiedades.Agregar("EsPrepago", EsPrepago.ToString)

            If Not String.IsNullOrEmpty(kilometraje) Then
                LogPropiedades.Agregar("kilometraje", kilometraje)
            End If



            'LogPropiedades.Agregar("RucCoductor", RucCoductor.ToString)
            POSstation.Fabrica.LogIt.Loguear("Se Envio los datos al crm: ", LogPropiedades, LogCategorias)

            DatosAutorizacion.Placa = placa
            DatosAutorizacion.Precio = precio
            DatosAutorizacion.IdProducto = idProducto
            DatosAutorizacion.CodEstacion = OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo")
            DatosAutorizacion.Kilometraje = kilometraje
            DatosAutorizacion.TarjetaPrepago = CStr(IIf(TarjetaPrepago.Equals("-1"), String.Empty, TarjetaPrepago))
            DatosAutorizacion.EsPrepago = EsPrepago

            If Not String.IsNullOrEmpty(RucCoductor) Then
                DatosAutorizacion.RUCConductor = RucCoductor
            Else
                DatosAutorizacion.RUCConductor = ""
            End If



            LogCategorias.Clear()
            LogCategorias.Agregar("Gerenciamiento")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("placa", placa.ToString)
            LogPropiedades.Agregar("precio", precio.ToString)
            LogPropiedades.Agregar("idProducto", idProducto.ToString)
            LogPropiedades.Agregar("CodEstacion", OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo"))
            If Not String.IsNullOrEmpty(kilometraje) Then
                LogPropiedades.Agregar("kilometraje", kilometraje)
            End If

            'LogPropiedades.Agregar("RucCoductor", RucCoductor.ToString)
            POSstation.Fabrica.LogIt.Loguear("Se Envio los datos al crm: ", LogPropiedades, LogCategorias)



            RespuestaCDC = Comunicador.AutorizarVentaGerenciamiento(DatosAutorizacion)

            If RespuestaCDC.EsAutorizado Then
                Respuesta.EsAutorizado = RespuestaCDC.EsAutorizado
                Respuesta.IdAutorizacion = RespuestaCDC.IdAutorizacion
                Respuesta.SaldoDisponible = RespuestaCDC.SaldoDisponible
                Respuesta.MensajeError = RespuestaCDC.MensajeError
                Respuesta.IdFormaPago = RespuestaCDC.IdFormaPago
                Respuesta.ValorAutorizado = RespuestaCDC.ValorAutorizado
                Respuesta.ConsumoMes = 0

                ''-------------------------2012-07-04 Datos adicionales para el caso de ventas credito prepago en el cdc de Chile------------------------''
                Respuesta.LecturaOdometro = RespuestaCDC.LecturaOdometro
                Respuesta.FechaContrato = RespuestaCDC.FechaContratoPrepago
                Respuesta.NumeroContratoPrepago = RespuestaCDC.NumeroContratoPrepago
                Respuesta.NumeroTarjetaPrepago = TarjetaPrepago
                Respuesta.EsPrepago = EsPrepago
                ''------------------------------------------------------------------------------------------------------------------------------''

                LogCategorias.Clear()
                LogCategorias.Agregar("Gerenciamiento")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("placa", placa.ToString)
                LogPropiedades.Agregar("precio", precio.ToString)
                LogPropiedades.Agregar("idProducto", idProducto.ToString)
                LogPropiedades.Agregar("MensajeError", RespuestaCDC.MensajeError)
                LogPropiedades.Agregar("EsAutorizado", RespuestaCDC.EsAutorizado)
                LogPropiedades.Agregar("ValorAutorizado", RespuestaCDC.ValorAutorizado)
                LogPropiedades.Agregar("NumeroContratoPrepago", RespuestaCDC.NumeroContratoPrepago)
                LogPropiedades.Agregar("Odometro", RespuestaCDC.LecturaOdometro)
                LogPropiedades.Agregar("TarjetaPrepago", TarjetaPrepago)
                LogPropiedades.Agregar("Saldo Disponible", RespuestaCDC.SaldoDisponible.ToString)
                LogPropiedades.Agregar("EsPrepago", EsPrepago.ToString)

                If RespuestaCDC.FechaContratoPrepago = Nothing Then
                    LogPropiedades.Agregar("FechaContrato", "Valor Null devuelto por CDC")
                Else
                    LogPropiedades.Agregar("FechaContrato", RespuestaCDC.FechaContratoPrepago.ToString)
                End If

                POSstation.Fabrica.LogIt.Loguear("Respuesta credito consumo CRM: ", LogPropiedades, LogCategorias)

            Else
                LogCategorias.Clear()
                LogCategorias.Agregar("Gerenciamiento")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("placa", placa.ToString)
                LogPropiedades.Agregar("precio", precio.ToString)
                LogPropiedades.Agregar("idProducto", idProducto.ToString)
                LogPropiedades.Agregar("CodEstacion", OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo"))
                LogPropiedades.Agregar("MensajeError", RespuestaCDC.MensajeError)
                LogPropiedades.Agregar("EsAutorizado", RespuestaCDC.EsAutorizado)
                POSstation.Fabrica.LogIt.Loguear("Respuesta credito consumo CRM: ", LogPropiedades, LogCategorias)
                Respuesta.MensajeError = RespuestaCDC.MensajeError
            End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AutorizarVentaGerenciamiento", "Placa: " & placa & ", PrecioProducto: " & precio, "AutorizadorRemoto")
            Respuesta.EsAutorizado = False
            Respuesta.MensajeError = ex.Message
        End Try
        Return Respuesta

    End Function



    Public Shared Function SolicitarConsultaConcepto(ByVal conConcepto As ConsultaConcepto) As RespuestaConsultaConcepto
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New ServiceInfoTaxi.Service
        Dim Respuesta As New RespuestaConsultaConcepto
        'Dim Campaña As New CDCIG.InfoCampanasCliente
        Dim InfoConConcepto As RespuestaConsultaConcepto = Nothing
        'Dim InfoCampaña As Campaña

        Try
            Comunicador.Url = conConcepto.Url

            Respuesta.dtconconcepto = Comunicador.Consulta(conConcepto.Placa, conConcepto.Movil.ToString)

            Return Respuesta
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "SolicitarConsultaConcepto", "", "ServiceInfoTaxi")
            Respuesta = Nothing
            Return Respuesta
        End Try
    End Function

    Public Shared Function AutorizarRecaudoEnEmpresa(ByVal Placa As String, ByVal Movil As Int32, ByVal IdRecaudo As Int32, ByVal IdConcepto As Int32, ByVal CantidadPeriodos As Int32, ByVal Valor As Decimal, ByVal CodEstacion As String, ByVal url As String) As RespuestaServicioRecaudoEmpresa

        Dim Servicio As New SRERecaudo.SRERecaudo
        Dim RespRecaudo As SRERecaudo.RespuestaServicioRecaudo
        Dim OHelper As New POSstation.AccesoDatos.Helper
        Dim RespuestaGST As New RespuestaServicioRecaudoEmpresa

        Try
            Servicio.Url = url
            Try
                RespRecaudo = Servicio.RegistrarRecaudo(Placa, Movil, IdRecaudo, IdConcepto, CantidadPeriodos, Valor, CodEstacion)
            Catch ex As System.Exception

                Throw ex
            End Try

            RespuestaGST.Mensaje = "No se puede obtener Respuesta del Servicio"

            If RespRecaudo Is Nothing Then
                Throw New System.Exception(RespuestaGST.Mensaje)
            Else
                RespuestaGST.EsProcesado = RespRecaudo.EsProcesado
                RespuestaGST.Mensaje = RespRecaudo.Mensaje

                If Not RespuestaGST.EsProcesado Then
                    Throw New System.Exception(RespuestaGST.Mensaje)
                End If
                RespuestaGST.Fecha = RespRecaudo.Fecha
                RespuestaGST.IdRecaudoEmpresa = RespRecaudo.IdRecaudoEmpresa
                RespuestaGST.Periodos = RespRecaudo.Periodos
                RespuestaGST.Valor = RespRecaudo.Valor
                RespuestaGST.Descripcion = RespRecaudo.Descripcion
            End If



            Return RespuestaGST
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecaudarEmpresa(ByVal IdServicio As Integer, ByVal Placa As String, ByVal Cedula As String, ByVal Valor As Decimal, ByVal Fecha As Date, ByVal IdEmpresa As Int32, ByVal CodEstacion As String, Optional ByVal Movil As Int32 = Nothing) As RespuestaRecaudoSRE
        Dim Servicio As New SRE.Recaudo
        Dim Respuesta As DataSet
        Dim RespRecaudo As New RespuestaRecaudoSRE
        Dim OHelper As New POSstation.AccesoDatos.Helper

        Try
            Servicio.Url = OHelper.RecuperarParametro("ServicioSRE")
            Respuesta = Servicio.InsertarRecaudo(IdServicio, Placa, Cedula, CodEstacion, Valor, Fecha, IdEmpresa, Movil)

            For Each Fila As DataRow In Respuesta.Tables(0).Rows
                RespRecaudo.IdEmpresa = Fila.Item("Empresa")
                RespRecaudo.mensaje = Fila.Item("Mensaje")
                RespRecaudo.nrAutorizacion = Fila.Item("Autorizacion")
            Next

            If Not String.IsNullOrEmpty(RespRecaudo.mensaje) Then
                Throw New System.Exception(RespRecaudo.mensaje)
            End If

            Return RespRecaudo
        Catch ex As System.Exception
            'RespRecaudo.mensaje = ex.Message
            Throw ex
        End Try

    End Function

    Public Shared Function RecuperarKilometrajeNivel(ByVal sUser As String, ByVal sPass As String, ByVal Placa As String) As Fabrica.DatosDataTrack
        Dim oInformacionDataTrack As New Fabrica.DatosDataTrack
        Dim Servicio As New ComunicacionDataTrack.VideoData
        Dim OHelper As New POSstation.AccesoDatos.Helper
        Dim XmlString As String = ""
        Dim xml2 As New Xml.XmlDocument
        Dim xmlSingleNode As Xml.XmlNode
        Try

            Servicio.Url = OHelper.RecuperarParametro("UrlDataTrack")
            XmlString = Servicio.GetLastVehicleData(sUser, sPass, Placa)

            LogCategorias.Clear()
            LogCategorias.Agregar("Datatrack")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Placa", Placa)
            LogPropiedades.Agregar("XML", XmlString)
            POSstation.Fabrica.LogIt.Loguear("Consulta a servicio datatrack", LogPropiedades, LogCategorias)

            xml2.LoadXml(XmlString)
            xmlSingleNode = xml2.SelectSingleNode("DatosVehiculo")
            With xmlSingleNode.Attributes
                oInformacionDataTrack.EsProcesado = True
                If xmlSingleNode.Attributes.Count > 1 Then
                    oInformacionDataTrack.Kilometraje = .GetNamedItem("Kilometraje").Value
                    oInformacionDataTrack.Nivel = .GetNamedItem("Nivel").Value
                Else
                    oInformacionDataTrack.Kilometraje = "0"
                    oInformacionDataTrack.Nivel = "0"
                End If
            End With

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarKilometrajeNivel", "XmlRecibido: " & XmlString & ", Placa: " & Placa, "RecuperarKilometrajeNivel")
            oInformacionDataTrack.EsProcesado = False
        End Try
        Return oInformacionDataTrack
    End Function

    Public Shared Sub ValidarDatosRecaudoPgnSRE(ByVal IdEmpresa As Integer, ByVal Ruc As String, ByVal Placa As String)
        Dim Servicio As New SRE.Recaudo
        Dim Respuesta As SRE.RespuestaSRE
        Dim OHelper As New POSstation.AccesoDatos.Helper
        Dim Url As String

        Try
            Url = OHelper.RecuperarParametro("ServicioSRE")
            Servicio.Url = Url
            Respuesta = Servicio.ValidarDatosRecaudo(IdEmpresa, Ruc, Placa)

            If Not Respuesta.Autorizado Then
                Throw New System.Exception(Respuesta.MensajeError)
            End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ValidarRucAbonoPgnSRE", "", "AutorizadorRemoto")
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Public Shared Function RealizarPagoInfoTaxi(ByVal Placa As String, ByVal Movil As String, ByVal IdRecaudo As Int32, ByVal IdConcepto As Int32, ByVal CantidadPeriodos As Int32, ByVal Valor As Decimal, ByVal CodEstacion As String, ByVal url As String) As RespuestaPagoInfoTaxi
        Dim Servicio As New ServiceInfoTaxi.Service
        Dim Respuesta As DataTable
        Dim RespRecaudo As New RespuestaPagoInfoTaxi
        Dim OHelper As New POSstation.AccesoDatos.Helper
        Dim Mensaje As String = ""

        Try
            Servicio.Url = url


            ''OJO preguntar el Yezid  porque de este error
            Respuesta = Servicio.Pagar(Placa, Movil, IdRecaudo, IdConcepto, CantidadPeriodos, Valor, CodEstacion)


            RespRecaudo = New RespuestaPagoInfoTaxi()
            RespRecaudo.EsProcesado = False
            RespRecaudo.Mensaje = "Respuesta invalida"

            If Not Respuesta Is Nothing Then
                For Each row As DataRow In Respuesta.Rows
                    RespRecaudo.Mensaje = row.Item("descripcion").ToString()
                    RespRecaudo.IdPago = CInt(row.Item("idReciboInfoTaxi").ToString())
                    RespRecaudo.Periodos = CInt(row.Item("periodosPagos").ToString())
                    RespRecaudo.Valor = CDec(row.Item("valorRecibo").ToString())
                    RespRecaudo.Fecha = row.Item("fechaInfoTaxi").ToString()

                    If row.Item("codigoRetorno").ToString().Equals("OK") Then
                        RespRecaudo.EsProcesado = True
                        RespRecaudo.Respuesta = row.Item("codigoRetorno").ToString()
                    Else
                        RespRecaudo.EsProcesado = False
                    End If
                Next
            Else
                Throw New System.Exception("No se pudo comunicar con InfoTaxi")
            End If

            If Not RespRecaudo.EsProcesado Then
                Throw New System.Exception(RespRecaudo.Mensaje)
            End If

            Return RespRecaudo

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RealizarPagoInfoTaxi", "", "AutorizadorRemoto")
            Throw ex
        End Try
    End Function

    Public Shared Function SolicitarConsultaConceptoTerceros(ByVal conConcepto As ConsultaConcepto) As RespuestaConsultaConceptoEmpresa()
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New SRERecaudo.SRERecaudo
        Dim RespuestaServicio() As SRERecaudo.RespuestaConsultaConceptoEmpresa
        'Dim Campaña As New CDCIG.InfoCampanasCliente
        Dim InfoConConcepto As RespuestaConsultaConcepto = Nothing
        'Dim InfoCampaña As Campaña
        Dim Respuesta() As RespuestaConsultaConceptoEmpresa = Nothing

        Try
            Comunicador.Url = conConcepto.Url
            RespuestaServicio = Comunicador.ConsultarConceptos(conConcepto.Placa, conConcepto.Movil)

            If Not RespuestaServicio Is Nothing Then
                Respuesta = New RespuestaConsultaConceptoEmpresa(RespuestaServicio.Length - 1) {}
                'ReDim Respuesta(dimesion)

                Dim index As Integer = 0
                For Each ORespuesta As SRERecaudo.RespuestaConsultaConceptoEmpresa In RespuestaServicio
                    Respuesta(index) = New RespuestaConsultaConceptoEmpresa
                    Respuesta(index).DescPeriodos = ORespuesta.DescPeriodos
                    Respuesta(index).Descripcion = ORespuesta.Descripcion
                    Respuesta(index).FechaFinal = ORespuesta.FechaFinal
                    Respuesta(index).FechaInicial = ORespuesta.FechaInicial
                    Respuesta(index).IdConcepto = ORespuesta.IdConcepto
                    Respuesta(index).IdMovil = ORespuesta.IdMovil
                    Respuesta(index).Periodo = ORespuesta.Periodo
                    Respuesta(index).Periodos = ORespuesta.Periodos
                    Respuesta(index).Saldo = ORespuesta.Saldo
                    index += 1
                Next
            End If


            Return Respuesta
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "SolicitarConsultaConceptoTerceros", "", "AutorizadorRemoto")
            Respuesta = Nothing
            Return Respuesta
        End Try
    End Function





#Region "ServiciosPGN"
    Public Shared Sub ValidarTarjetaPgn(ByVal Tarjeta As String)
        Dim servicio As New CDCPGN.ClubpgnService
        Dim DatosTarjeta As New CDCPGN.pgnTarjetaRequest
        Dim RespuestaValidacion As CDCPGN.pgnTarjetaResponse = Nothing
        Dim InfoTarjeta As New CDCPGN.TarjetaType
        Dim OHelper As New POSstation.AccesoDatos.Helper


        Try

            InfoTarjeta.codeTarjeta = Tarjeta
            DatosTarjeta.tarjeta = InfoTarjeta
            servicio.Url = OHelper.RecuperarParametro("ServicioEspecializadoPGN")


            Try
                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("FechaHora", Now.ToString())
                LogPropiedades.Agregar("Tarjeta", Tarjeta)
                POSstation.Fabrica.LogIt.Loguear("Inicio Validacion de la Tarjeta en el  CDC de PGN", LogPropiedades, LogCategorias)

                RespuestaValidacion = servicio.pgnTarjeta(DatosTarjeta)
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "ValidarTarjetaPgn", "", "AutorizadorRemoto")
                Throw New GasolutionsFidelizacionPgn("Estimado cliente, en estos momentos estamos teniendo problemas en nuestra red. Si usted se encuentra afiliado a la red PGN en cuanto se realice la transaccion se procedera a acumular su consumo. Gracias por su comprension")
            End Try


            If Not RespuestaValidacion Is Nothing Then

                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("FechaHora", Now.ToString())
                LogPropiedades.Agregar("Tarjeta", Tarjeta)
                POSstation.Fabrica.LogIt.Loguear("Finalizacion Validacion de la Tarjeta en el  CDC de PGN", LogPropiedades, LogCategorias)

                If RespuestaValidacion.respuesta.esValida.Equals("0") Then
                    Throw New System.Exception(RespuestaValidacion.respuesta.mensaje)
                End If
            Else
                'Throw New System.Exception("Informacion de tarjeta no disponible en CDC")
                Throw New GasolutionsFidelizacionPgn("Estimado cliente, en estos momentos estamos teniendo problemas en nuestra red. Si usted se encuentra afiliado a la red PGN en cuanto se realice la transaccion se procedera a acumular su consumo. Gracias por su comprension")
            End If
        Catch ex As GasolutionsFidelizacionPgn
            LogFallas.ReportarError(ex, "ValidarTarjetaPgn", "", "AutorizadorRemoto")
            Throw ex
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ValidarTarjetaPgn", "", "AutorizadorRemoto")
            Throw ex
        End Try
    End Sub


#End Region
End Class

Public Class RespuestaAutorizacionGerenciamiento

    Private _IdAutorizacion As Int64
    Public Property IdAutorizacion() As Int64
        Get
            Return _IdAutorizacion
        End Get
        Set(ByVal value As Int64)
            _IdAutorizacion = value
        End Set
    End Property

    Private _IdFormaPago As Int16
    Public Property IdFormaPago() As Int16
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Int16)
            _IdFormaPago = value
        End Set
    End Property

    Private _ValorAutorizado As Decimal
    Public Property ValorAutorizado() As Decimal
        Get
            Return _ValorAutorizado
        End Get
        Set(ByVal value As Decimal)
            _ValorAutorizado = value
        End Set
    End Property

    Private _SaldoDisponible As Decimal
    Public Property SaldoDisponible() As Decimal
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Decimal)
            _SaldoDisponible = value
        End Set
    End Property

    Private _MensajeError As String = String.Empty
    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property


    Private _EsAutorizado As Boolean
    Public Property EsAutorizado() As Boolean
        Get
            Return _EsAutorizado
        End Get
        Set(ByVal value As Boolean)
            _EsAutorizado = value
        End Set
    End Property

    Private _ConsumoMes As Double
    Public Property ConsumoMes() As Double
        Get
            Return _SaldoDisponible
        End Get
        Set(ByVal value As Double)
            _ConsumoMes = value
        End Set
    End Property
    Private _FechaContrato As Date
    Public Property FechaContrato() As Date
        Get
            Return _FechaContrato
        End Get
        Set(ByVal value As Date)
            _FechaContrato = value
        End Set
    End Property

    Private _LecturaOdometro As String
    Public Property LecturaOdometro() As String
        Get
            Return _LecturaOdometro
        End Get
        Set(ByVal value As String)
            _LecturaOdometro = value
        End Set
    End Property

    Private _NumeroContratoPrepago As String
    Public Property NumeroContratoPrepago() As String
        Get
            Return _NumeroContratoPrepago
        End Get
        Set(ByVal value As String)
            _NumeroContratoPrepago = value
        End Set
    End Property

    Private _NumeroTarjetaPrepago As String
    Public Property NumeroTarjetaPrepago() As String
        Get
            Return _NumeroTarjetaPrepago
        End Get
        Set(ByVal value As String)
            _NumeroTarjetaPrepago = value
        End Set
    End Property

    Private _EsPrepago As Boolean

    Public Property EsPrepago() As Boolean
        Get
            Return _EsPrepago
        End Get
        Set(ByVal value As Boolean)
            _EsPrepago = value
        End Set
    End Property

End Class
