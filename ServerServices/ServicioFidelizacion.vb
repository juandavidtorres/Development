Imports POSstation.AccesoDatos
Imports POSstation.Fabrica


Public Class ServicioFidelizacion
    Public Shared LogFallas As New POSstation.Fabrica.EstacionException

    Public Shared Function PagarVentaConBono(ByVal IdBono As String, ByVal Numerotarjeta As String, ByVal Venta As DTOVenta, ByVal usuario As String, ByVal clave As String) As RespuestaPagarVentaConBono
        Dim oRespuestaPagarVentaConBono As New RespuestaPagarVentaConBono
        Dim oDataAccess As New Helper
        Dim IdRedencion As Integer = -1, valorBono As Decimal

        Try
            Dim ODataSet As DataSet = Nothing
            Dim bonoRedimido As Fidelizacion.BonosFidelizacionRedencion
            Dim listaBono As New List(Of Fidelizacion.BonosFidelizacionRedencion)
            Dim drValidar As IDataReader = oDataAccess.RecuperarBonosLocalesReader()
            Dim ORespuesta As New Fidelizacion.RespuestaBonoFidelizacion
            While drValidar.Read
                If IdBono.Equals(drValidar("IdBono").ToString()) Then
                    bonoRedimido = New Fidelizacion.BonosFidelizacionRedencion
                    bonoRedimido.IdPremio = CLng(drValidar("IdBono").ToString)
                    bonoRedimido.Cantidadredimida = 1 'Ya que solo se redime un bono    
                    valorBono = CDec(drValidar("Valor").ToString)
                    listaBono.Add(bonoRedimido)
                End If
            End While

            If listaBono.Count > 0 Then

                'IdRedencion = oDataAccess.ReservarBono(Convert.ToInt64(Venta.Recibo), CInt(IdBono))
                ORespuesta = PagarConBono(listaBono, Numerotarjeta, IdRedencion, Convert.ToInt32(Venta.Recibo), CDec(Venta.Cantidad), CDec(Venta.Valor), usuario, clave, CStr(Venta.Placa))


                If Not ORespuesta Is Nothing Then
                    If ORespuesta.Autorizado Then
                        oRespuestaPagarVentaConBono.Autorizado = ORespuesta.Autorizado
                        oRespuestaPagarVentaConBono.MensajeError = ""
                        'oDataAccess.PagarConBono(Convert.ToInt64(Venta.Recibo), Venta.Placa, CDate(Venta.Fecha), CDec(Venta.Precio), CDec(Venta.Cantidad), CDec(Venta.Valor), CInt(Venta.Manguera), Venta.Producto, CDec(Venta.Descuento), IdRedencion, Numerotarjeta, Venta.FechaProximoMantenimiento)
                        'oDataAccess.ActualizarVentaPagadaConBono(Convert.ToInt64(Venta.Recibo), IIf(valorBono > CDec(Venta.Valor), 0, (CDec(Venta.Valor) - valorBono)), IIf(valorBono > CDec(Venta.Valor), CDec(Venta.Valor), valorBono))
                        'RaiseEvent OEventos_ImprimirReciboRedencionBono(Venta.Recibo, Numerotarjeta, impresora)
                    Else
                        oRespuestaPagarVentaConBono.Autorizado = False
                        oRespuestaPagarVentaConBono.MensajeError = IIf(String.IsNullOrEmpty(ORespuesta.MensajeError), "ERROR EN EL SERVICIO DE FIDELIZACION SOY LEAL. NO SE PUEDE HACER LA REDENCION DEL BONO EN ESTOS MOMENTOS", ORespuesta.MensajeError)
                    End If
                Else
                    oRespuestaPagarVentaConBono.Autorizado = False
                    oRespuestaPagarVentaConBono.MensajeError = "No se Recibió respuesta por parte del Servicio Soy Leal, No se realizó la redención del Bono. Intentelo de Nuevo."
                End If
            End If

        Catch ex As System.Exception
            'oDataAccess.LiberarBonoEnreserva(IdRedencion)
            oRespuestaPagarVentaConBono.Autorizado = False
            oRespuestaPagarVentaConBono.MensajeError = ex.Message.ToString()
        End Try
        Return oRespuestaPagarVentaConBono
    End Function


    Public Shared Function PagarConBono(ByVal bonos As List(Of Fidelizacion.BonosFidelizacionRedencion), ByVal tarjeta As String, ByVal idredencion As Int32, ByVal recibo As Int32, ByVal cantidad As Decimal, ByVal valor As Decimal, ByVal usuario As String, ByVal clave As String, ByVal placa As String) As Fidelizacion.RespuestaBonoFidelizacion
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim CodEstacion As String
        Dim ORespuesta As New Fidelizacion.RespuestaBonoFidelizacion
        Dim oRespuestaValidacionUsuario As New Fidelizacion.RespuestaSoyLeal
        Dim ODataSet As DataSet = Nothing
        Dim ODataAccess As New Helper


        Try
            ODataSet = ODataAccess.RecuperarCodEstacion()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")
            Try
                Dim tiempoEspera As Integer = Int32.Parse(ODataAccess.Recuperarparametro("TiempoEsperaComunicacionSoyLeal"))
                'El tiempo de espera viene en segundos, se realiza la conversión a milisegundos
                OServicio.Timeout = tiempoEspera * 1000
            Catch ex As System.Exception
            End Try


            oRespuestaValidacionUsuario = OServicio.ValidarUsuarioRedencion(usuario, clave, CodEstacion)
            If Not oRespuestaValidacionUsuario Is Nothing Then
                If oRespuestaValidacionUsuario.Autorizado Then
                    ORespuesta = OServicio.BonosRedencion(bonos.ToArray(), CodEstacion, tarjeta, idredencion, recibo, cantidad, valor, placa, usuario)
                Else
                    Throw New System.Exception(oRespuestaValidacionUsuario.MensajeError.ToString())
                End If
            Else
                Throw New System.Exception("No se recibio respuesta desde SoyLeal, validando el usuario para la redención de bono. No se puede efectuar el pago con Bono en estos momentos")
            End If

        Catch ex As System.Exception
            Throw ex
        End Try
        Return ORespuesta
    End Function

    Public Shared Function ConsultarBonosDisponibles() As Fabrica.RespuestaBonoFidelizacion
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim ODataAccess As New Helper()

        Dim ODataSet As DataSet = Nothing
        Dim CodEstacion As String
        Dim ORespuestaConsultarBonosDisponibles As New Fabrica.RespuestaBonoFidelizacion
        Dim ORespuesta As New Fidelizacion.RespuestaBonoFidelizacion
        'Dim OFidelizacion As New HippoSoyLeal.Fidelizacion.RespuestaBonoFidelizacion

        Try
            ODataSet = ODataAccess.RecuperarCodEstacion()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")
            Try
                Dim tiempoEspera As Integer = Int32.Parse(ODataAccess.RecuperarParametro("TiempoEsperaComunicacionSoyLeal"))
                'El tiempo de espera viene en segundos, se realiza la conversión a milisegundos
                OServicio.Timeout = tiempoEspera * 1000
            Catch ex As System.Exception
            End Try

            Try
                ORespuesta = OServicio.ConsultarBonosDisponibles(CodEstacion)
            Catch ex As System.Exception
                Throw New System.Exception("EN ESTOS MOMENTOS NO HAY COMUNICACION CON SOY LEAL.")
            End Try


            Dim listaBonos As New List(Of BonosFidelizacion)
            If Not ORespuesta.BonoFidelizacion Is Nothing And String.IsNullOrEmpty(ORespuesta.MensajeError) Then
                Dim bono As BonosFidelizacion
                If ORespuesta.BonoFidelizacion().Length > 0 Then
                    For Each oBono As Fidelizacion.BonosFidelizacion In ORespuesta.BonoFidelizacion()
                        bono = New BonosFidelizacion
                        bono.IdPremio = oBono.IdPremio
                        bono.Nombre = oBono.Nombre
                        bono.Tipo = oBono.Tipo
                        bono.Puntos = oBono.Puntos
                        bono.Valor = oBono.Valor
                        listaBonos.Add(bono)
                    Next
                End If

            Else
                '  OFidelizacion.BonoFidelizacion = ORespuesta.BonoFidelizacion()
            End If

            ORespuestaConsultarBonosDisponibles.BonoFidelizacion = listaBonos
            ORespuestaConsultarBonosDisponibles.MensajeError = ORespuesta.MensajeError
        Catch ex As System.Exception
            Throw
        End Try
        Return ORespuestaConsultarBonosDisponibles
    End Function

    Public Shared Sub RegistrarUltimaVentaFidelizada(ByVal Recibo As Double)

        Dim DatosRecibo As AccesoDatos.InformacionVentaFidelizada = Nothing
        Dim oCInformacion As New Fidelizacion.servicio_soy_leal
        Dim oHelper As POSstation.AccesoDatos.Helper = New POSstation.AccesoDatos.Helper
        Dim Respuesta As String

        Try

            oCInformacion.Url = oHelper.RecuperarParametro("ServicioFidelizacion")
            DatosRecibo = oHelper.RecuperarInformacionVentaFidelizada(CLng(Recibo))
            If Not DatosRecibo Is Nothing Then
                Respuesta = oCInformacion.RegistrarVentaFidelizada(Recibo, CDate(DatosRecibo.Fecha).ToString("yyyyMMdd HH:mm:ss"), DatosRecibo.Cantidad, DatosRecibo.Total, DatosRecibo.Placa, DatosRecibo.IdProducto, DatosRecibo.CodEstacion, DatosRecibo.Tarjeta)

                If Not String.IsNullOrEmpty(Respuesta) Then
                    Throw New System.Exception(Respuesta)
                End If
            End If

        Catch Ex As System.Exception
            Throw Ex
        Finally
            oCInformacion.Dispose()

            If Not DatosRecibo Is Nothing Then
                DatosRecibo.Dispose()
            End If
        End Try
    End Sub

    Public Shared Function RegistrarFidelizarVentaManual(ByVal Recibo As Long, ByVal FechaHora As String, ByVal Cantidad As Decimal, ByVal Valor As Decimal, ByVal tarjeta As String) As String

        Dim DatosRecibo As POSstation.Fabrica.InformacionVentaFidelizada = Nothing
        Dim CodEstacion As String
        Dim oCInformacion As New Fidelizacion.servicio_soy_leal
        Dim oHelper As POSstation.AccesoDatos.Helper = New POSstation.AccesoDatos.Helper
        Dim Estacion As InformacionEstacion
        Dim Respuesta As String

        CodEstacion = Nothing
        Estacion = oHelper.RecuperarDatosEstacion
        CodEstacion = Estacion.Codigo
        Respuesta = ""

        Try
            oCInformacion.Url = oHelper.RecuperarParametro("ServicioFidelizacion")
            Respuesta = oCInformacion.RegistrarVentaFidelizada_Fid_Manual(Recibo, FechaHora, Cantidad, Valor, CodEstacion, tarjeta)

            If Not String.IsNullOrEmpty(Respuesta) Then
                Throw New System.Exception(Respuesta)
            End If
            Return Respuesta
        Catch Ex As System.Exception
            Throw Ex
        Finally
            oCInformacion.Dispose()

            If Not DatosRecibo Is Nothing Then
                DatosRecibo.Dispose()
            End If
        End Try
    End Function

    Public Shared Function ConsultarSaldoTajetaFidelizacion(ByVal tarjeta As String) As Fabrica.Fidelizacion
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim ODataAccess As New POSstation.AccesoDatos.Helper
        Dim ODataSet As DataSet = Nothing
        Dim CodEstacion As String
        Dim ORespuesta As New Fidelizacion.RespuestaFidelizacion
        Dim OFidelizacion As New Fabrica.Fidelizacion

        Try
            ODataSet = ODataAccess.RecuperarEstaciones()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")
            ORespuesta = OServicio.ConsultarSaldosTarjetaPorEDS(CodEstacion, tarjeta)

            If ORespuesta.Saldos Is Nothing And ORespuesta.MensajeError = "" Then
                Throw New System.Exception("La tarjeta ingresada no tiene movimientos asociados.")
            Else
                OFidelizacion.MensajeError = ORespuesta.MensajeError
                OFidelizacion.MensajesCliente = ORespuesta.MensajesCliente
                OFidelizacion.Saldos = ORespuesta.Saldos
            End If



            Return OFidelizacion
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ConsultarSaldoTajetaFidelizacionConIdentificacion(ByVal rut As String) As POSstation.Fabrica.Fidelizacion
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim ODataAccess As New POSstation.AccesoDatos.Helper
        Dim ODataSet As DataSet = Nothing
        Dim CodEstacion As String
        Dim ORespuesta As New Fidelizacion.RespuestaFidelizacion
        Dim OFidelizacion As New POSstation.Fabrica.Fidelizacion

        Try
            ODataSet = ODataAccess.RecuperarEstaciones()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")
            ORespuesta = OServicio.ConsultarSaldosTarjetaConIdentificacion(CodEstacion, rut)

            OFidelizacion.MensajeError = ORespuesta.MensajeError
            OFidelizacion.MensajesCliente = ORespuesta.MensajesCliente
            OFidelizacion.Saldos = ORespuesta.Saldos
            OFidelizacion.Tarjeta = ORespuesta.Tarjeta

            Return OFidelizacion
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Shared Function AutorizarConsumoBono(ByVal tarjeta As String, ByVal recibo As Int64, ByVal valorVenta As Decimal, ByVal cantidad As Decimal, ByVal precioVenta As Decimal) As POSstation.Fabrica.AutorizacionVentaBono
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim ODataAccess As New POSstation.AccesoDatos.Helper
        Dim ODataSet As DataSet = Nothing
        Dim CodEstacion As String
        Dim ORespuesta As New Fidelizacion.RespuestaRedencionBono
        Dim OFidelizacion As POSstation.Fabrica.AutorizacionVentaBono = Nothing

        Try
            ODataSet = ODataAccess.RecuperarEstaciones()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")

            ORespuesta = OServicio.AutorizarRedencionBonos(CodEstacion, tarjeta, recibo, valorVenta, cantidad)

            If Not ORespuesta Is Nothing Then
                OFidelizacion = New POSstation.Fabrica.AutorizacionVentaBono
                OFidelizacion.Mensaje = ORespuesta.MensajeError
                OFidelizacion.EsAutorizado = ORespuesta.Autorizado

                If ORespuesta.Valor = 0 Then
                    OFidelizacion.ValorBono = ORespuesta.Cantidad * precioVenta
                Else
                    OFidelizacion.ValorBono = ORespuesta.Valor
                End If

                OFidelizacion.Cantidad = ORespuesta.Cantidad
                OFidelizacion.NroAutorizacion = ORespuesta.IdAutorizacion
            End If

            Return OFidelizacion
        Catch ex As System.Exception
            OFidelizacion = Nothing
            LogFallas.ReportarError(ex, "AutorizarConsumoBono", "", "ServicioFidelizacion")
        End Try

        Return OFidelizacion
    End Function





    Public Shared Function AutorizarConsumoBono(ByVal tarjeta As String, ByVal recibo As Int64, ByVal valorVenta As Decimal, ByVal cantidad As Decimal, ByVal precioVenta As Decimal, ByVal IdTipoCombustible As Int32) As POSstation.Fabrica.AutorizacionVentaBono
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim ODataAccess As New POSstation.AccesoDatos.Helper
        Dim ODataSet As DataSet = Nothing
        Dim CodEstacion As String
        Dim ORespuesta As New Fidelizacion.RespuestaRedencionBono
        Dim OFidelizacion As POSstation.Fabrica.AutorizacionVentaBono = Nothing

        Try
            ODataSet = ODataAccess.RecuperarEstaciones()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")

            ORespuesta = OServicio.AutorizarRedencionBonosTipoCombustible(CodEstacion, tarjeta, recibo, valorVenta, cantidad, IdTipoCombustible)

            If Not ORespuesta Is Nothing Then
                OFidelizacion = New POSstation.Fabrica.AutorizacionVentaBono
                OFidelizacion.Mensaje = ORespuesta.MensajeError
                OFidelizacion.EsAutorizado = ORespuesta.Autorizado

                If ORespuesta.Valor = 0 Then
                    OFidelizacion.ValorBono = ORespuesta.Cantidad * precioVenta
                Else
                    OFidelizacion.ValorBono = ORespuesta.Valor
                End If

                OFidelizacion.Cantidad = ORespuesta.Cantidad
                OFidelizacion.NroAutorizacion = ORespuesta.IdAutorizacion
            End If

            Return OFidelizacion
        Catch ex As System.Exception
            OFidelizacion = Nothing
            LogFallas.ReportarError(ex, "AutorizarConsumoBono", "", "ServicioFidelizacion")
        End Try

        Return OFidelizacion
    End Function

    Public Shared Function CancelarConsumoBono(ByVal tarjeta As String, ByVal recibo As Int64, ByVal valorVenta As Decimal) As Boolean
        Dim OServicio As New Fidelizacion.servicio_soy_leal
        Dim ODataAccess As New POSstation.AccesoDatos.Helper
        Dim ODataSet As DataSet = Nothing
        Dim CodEstacion As String
        Dim ORespuesta As New Fidelizacion.RespuestaRedencion
        Dim Responde As Boolean = False

        Try
            ODataSet = ODataAccess.RecuperarEstaciones()
            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
            ODataSet = Nothing
            OServicio.Url = ODataAccess.RecuperarParametro("ServicioFidelizacion")
            ORespuesta = OServicio.CancelarRedencionBonos(CodEstacion, tarjeta, recibo.ToString, valorVenta)

            If Not String.IsNullOrEmpty(ORespuesta.MensajeError) Then
                Throw New System.Exception(ORespuesta.MensajeError)
            Else
                Responde = True
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "CancelarConsumoBono", "", "ServicioFidelizacion")
        End Try
        Return Responde
    End Function

End Class
