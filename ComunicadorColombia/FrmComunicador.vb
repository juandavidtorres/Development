
Imports System.Threading
Imports System.ComponentModel
Imports System.IO
Imports System.Data.SqlClient
Imports POSstation.Fabrica

Public Class FrmComunicador

#Region "Declaracion de variables"

    Private ErrorVentas As String, ValorVentas As String
    Private ErrorGerenciamiento As String, ValorGerenciamiento As String
    Private ErrorLecturas As String, ValorLecturas As String
    Private Recibo_, ReciboVentas, ReciboVentaCanastilla_ As Double
    Private EnviarVentas, EnviarLecturas, EnviarGerenciamiento, Enviando As Boolean
    Private Mensaje As String
    Dim oHelper As New POSstation.AccesoDatos.SqlServer
    Dim LogFallas As New EstacionException
    Private EnviarRecaudos As Boolean
    Private ErrorRecaudos As String
    Private ValorRecaudos As String


    Public Shared LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
#End Region

#Region "Eventos"
    Private Sub frmComunicador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Application.EnableVisualStyles()
            RecuperarSincronizacion()
            Me.Recibo_ = oHelper.RecuperarUltimoRecibo
            EnviarVentas = True
        Catch Ex As System.Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub
#End Region

#Region "Envio Informacion"
    Private Sub TomaLecturasFinalesFinalizada()
        Dim TurnoActual, Turno As Int32

        Try
            Turno = oHelper.RecuperarUltimaLecturaCRM(POSstation.Fabrica.CDCS.CRM)
            TurnoActual = CInt(Me.txtLecturas.Text) + 1

            While TurnoActual <= Turno
                EnviarTurnoCRM(TurnoActual)
            End While
        Catch Ex As System.Exception
            ErrorLecturas = Ex.Message
            If My.Settings.RastrearTareas Then
                EscribirMensaje(Ex.Message)
            End If
            If My.Settings.Archivo Then
                AlmacenarEnArchivo(Ex.Message)
            End If
            txtLecturas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoLectura))
            Application.DoEvents()
        Finally
            EnviarLecturas = False
        End Try
    End Sub

    Private Sub EnviarTurnoCRM(ByRef TurnoActual As Int32)
        Dim OCInformacion As New Comunicacion.Comunicacion
        Dim InfoTurno As New Comunicacion.Turno
        Dim ObjLecturas As New LecturasManguera
        Dim Respuesta As New Comunicacion.RespuestaCDC
        Dim indice As Integer
        Dim ODatos As IDataReader = Nothing
        Dim OResultado As DataSet

        OCInformacion.Url = oHelper.RecuperarParametro("ServicioGeneral")

        Application.DoEvents()

        If My.Settings.RastrearTareas Then
            EscribirMensaje("Registrando Turno " & TurnoActual)
        End If

        If My.Settings.Archivo Then
            AlmacenarEnArchivo("Registrando Turno " & TurnoActual)
        End If

        Application.DoEvents()

        InfoTurno.IdTurno = TurnoActual

        Try
            ODatos = oHelper.RecuperarTurno(TurnoActual)
        Catch ex As System.Exception
            ODatos = Nothing
        End Try

        If Not ODatos Is Nothing Then
            If ODatos.Read Then
                InfoTurno.FechaApertura = CDate(ODatos.Item("Apertura")).ToString("dd/MM/yyyy HH:mm:ss")
                If System.DateTime.TryParse(ODatos.Item("Cierre").ToString, InfoTurno.FechaCierre) Then
                    InfoTurno.FechaCierre = InfoTurno.FechaCierre.ToString("dd/MM/yyyy HH:mm:ss")
                Else
                    Throw New InvalidCastException("Imposible convertir la Fecha de Cierre a DateTime, El Turno debe estar Cerrado")
                End If

                InfoTurno.IdEmpleado = CInt(ODatos.Item("IdEmpleado"))
                InfoTurno.CodEstacion = oHelper.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo").ToString()
            End If

            ODatos.Close()
            ODatos = Nothing

            OResultado = oHelper.RecuperarProductosPorTurno(TurnoActual)

            If OResultado.Tables(0).Rows.Count > 0 Then
                InfoTurno.Productos = New Comunicacion.Producto(OResultado.Tables(0).Rows.Count - 1) {}

                indice = 0
                For Each OProducto As DataRow In OResultado.Tables(0).Rows
                    InfoTurno.Productos(indice) = New Comunicacion.Producto()
                    InfoTurno.Productos(indice).IdProducto = OProducto.Item("IdProducto")
                    InfoTurno.Productos(indice).Precio = OProducto.Item("Precio")
                    indice = indice + 1
                Next
            End If

            ObjLecturas.RecuperarMangueras(CInt(TurnoActual))

            If ObjLecturas.Lista.Count > 0 Then
                InfoTurno.LecturasManguera = New Comunicacion.LecturaManguera(ObjLecturas.Lista.Count - 1) {}
            End If

            indice = 0
            For Each manguera As LecturasManguera In ObjLecturas.Lista
                InfoTurno.LecturasManguera(indice) = New Comunicacion.LecturaManguera
                InfoTurno.LecturasManguera(indice).LecturaInicial = manguera.LecturaInicialElectronica
                InfoTurno.LecturasManguera(indice).LecturaFinal = manguera.LecturaFinalElectronica
                InfoTurno.LecturasManguera(indice).IdManguera = manguera.NoManguera

                If My.Settings.RastrearTareas Then
                    EscribirMensaje("Manguera: " & manguera.NoManguera)
                End If
                If My.Settings.Archivo Then
                    AlmacenarEnArchivo("Manguera: " & manguera.NoManguera)
                End If
                Application.DoEvents()
                indice = indice + 1
            Next

            Respuesta = OCInformacion.RegistrarTurnoEstacion(InfoTurno)
            Application.DoEvents()
            EscribirMensaje("Respuesta CDC: " & IIf(Respuesta.EsProcesado = True, "Procesado", "Falla en CDC"))
            Application.DoEvents()

            If Not Respuesta.EsProcesado Then
                Throw New System.Exception("Falla en Procesamiento en CDC: " & Respuesta.MensajeError)
            End If

            Application.DoEvents()
        End If

        ValorLecturas = CStr(TurnoActual)
        oHelper.ActualizarSincronizacion("Lecturas", TurnoActual.ToString, POSstation.Fabrica.CDCS.CRM)
        TurnoActual = TurnoActual + 1
        ErrorLecturas = ""
        txtLecturas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoLectura))
        Application.DoEvents()
        OCInformacion = Nothing
        ObjLecturas = Nothing
        Respuesta = Nothing
        InfoTurno = Nothing
    End Sub

    Private Sub RegistrarVentas(ByVal Recibo As Double)
        Dim ReciboActual As Double
        Try
            ReciboActual = CDbl(txtVentas.Text) + 1

            While ReciboActual <= Recibo
                EnviarVenta(ReciboActual)

            End While

            EnviarVentas = False
        Catch Ex As System.Exception
            ErrorVentas = Ex.Message
            If My.Settings.RastrearTareas Then
                EscribirMensaje(Ex.Message)
            End If
            If My.Settings.Archivo Then
                AlmacenarEnArchivo(Ex.Message)
            End If
            Me.txtVentas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoVenta))
            Application.DoEvents()
        Finally
            EnviarVentas = False
        End Try
    End Sub

    Private Sub EnviarVenta(ByRef ReciboActual As Double)
        Dim oCInformacion As New Comunicacion.Comunicacion
        Dim InfoVenta As New Comunicacion.Venta
        Dim DatosRecibo As POSstation.AccesoDatos.InformacionVenta = Nothing
        Dim OMediosPago As New MediosPagoVenta
        Dim Respuesta As New Comunicacion.RespuestaCDC
        Dim indice As Int32
        oCInformacion.Url = oHelper.RecuperarParametro("ServicioGeneral")

        Application.DoEvents()

        DatosRecibo = oHelper.RecuperarInformacionVentaCRMStationChile(CLng(ReciboActual))

        If My.Settings.RastrearTareas Then
            EscribirMensaje("Registrando Venta: " & ReciboActual)
        End If
        If My.Settings.Archivo Then
            AlmacenarEnArchivo("Registrando Venta: " & ReciboActual)
        End If

        If Not DatosRecibo Is Nothing Then
            Application.DoEvents()

            InfoVenta.Recibo = DatosRecibo.Recibo
            InfoVenta.IdFormaPago = DatosRecibo.IdFormaPago
            InfoVenta.FechaHora = DatosRecibo.FechaVenta
            InfoVenta.IdTurno = DatosRecibo.IdTurno
            InfoVenta.IdManguera = DatosRecibo.Manguera
            InfoVenta.HoraFin = DatosRecibo.HoraFin
            InfoVenta.HoraInicio = DatosRecibo.HoraInicio
            InfoVenta.LecturaFinal = DatosRecibo.LecturaFinal
            InfoVenta.LecturaInicial = DatosRecibo.LecturaInicial
            InfoVenta.Precio = DatosRecibo.Precio
            InfoVenta.Iva = DatosRecibo.Iva
            InfoVenta.AbonoCredito = DatosRecibo.AbonoCredito
            InfoVenta.IdCliente = DatosRecibo.IdClienteCDC
            InfoVenta.Cantidad = DatosRecibo.Cantidad
            InfoVenta.Valor = DatosRecibo.Valor
            InfoVenta.Descuento = DatosRecibo.Descuento
            InfoVenta.Placa = DatosRecibo.Placa
            InfoVenta.IdProducto = DatosRecibo.IdProducto
            InfoVenta.CodEstacion = DatosRecibo.CodEstacion
            InfoVenta.IdUnidadMedida = DatosRecibo.IdUnidadMedida
            InfoVenta.IdHistoricoPrecio = DatosRecibo.IdHistoricoPrecio
            InfoVenta.Rom = DatosRecibo.Rom
            InfoVenta.IdCara = DatosRecibo.IdCara
            InfoVenta.IdIsla = DatosRecibo.Isla
            InfoVenta.FechaProximoMantenimiento = CDate(DatosRecibo.FechaProximoMantenimiento)
            InfoVenta.IdSurtidor = DatosRecibo.Surtidor
            InfoVenta.RUTConductor = DatosRecibo.RUTConductor
            InfoVenta.Kilometraje = DatosRecibo.Kilometraje
            InfoVenta.ComprobantePrepago = DatosRecibo.ComprobantePrepago
            OMediosPago.RecuperarMediosPagoVenta(ReciboActual)
            If OMediosPago.ListaMediosPago.Count > 0 Then
                InfoVenta.VentasFormaPago = New Comunicacion.VentaFormaPago(OMediosPago.ListaMediosPago.Count - 1) {}
            End If

            indice = 0
            For Each lpagos As MediosPagoVenta In OMediosPago.ListaMediosPago
                InfoVenta.VentasFormaPago(indice) = New Comunicacion.VentaFormaPago
                InfoVenta.VentasFormaPago(indice).IdMedioPago = lpagos.IdMedioPago
                InfoVenta.VentasFormaPago(indice).Total = lpagos.Total

                indice = indice + 1
            Next



            Respuesta = oCInformacion.RegistrarVentaEstacion(InfoVenta)

            EscribirMensaje("Respuesta CDC: " & IIf(Respuesta.EsProcesado = True, "Procesado", "Falla en CDC"))
            Application.DoEvents()

            If Not Respuesta.EsProcesado Then
                Throw New System.Exception("Falla en Procesamiento en CDC: " & Respuesta.MensajeError)
            End If

            ErrorVentas = ""
            ValorVentas = ReciboActual.ToString()
            oHelper.ActualizarSincronizacion("Ventas", ReciboActual.ToString, POSstation.Fabrica.CDCS.CRM)
            txtVentas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoVenta))

            ReciboActual = ReciboActual + 1
            Application.DoEvents()
        Else
            ValorVentas = ReciboActual.ToString()
            oHelper.ActualizarSincronizacion("Ventas", ReciboActual.ToString, POSstation.Fabrica.CDCS.CRM)
            ReciboActual = ReciboActual + 1
            txtVentas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoVenta))
        End If

        DatosRecibo = Nothing
        InfoVenta = Nothing
        oCInformacion = Nothing
    End Sub


    Private Sub RegistrarRecaudos(ByVal recibo As Double)
        'Dim ReciboActual As Double
        'Dim DatosRecibo As InformacionRecaudoChile = Nothing
        'Dim oCInformacion As New Comunicacion.Comunicacion
        'Dim oHelper As POSstation.AccesoDatos.SqlServer = New POSstation.AccesoDatos.SqlServer
        'Dim oAbonos As New Comunicacion.VentaCredito
        'Dim RespuestaCDC As New Comunicacion.RespuestaCDC

        'Try
        '    Dim Estacion As DataSet = oHelper.RecuperarEstaciones()
        '    Dim CodEstacion As String = Estacion.Tables(0).Rows(0).Item("Codigo").ToString()
        '    Estacion = Nothing

        '    ReciboActual = CDbl(txtRecaudo.Text) + 1
        '    oCInformacion.Url = oHelper.RecuperarParametro("ServicioEspecializado")

        '    While ReciboActual <= recibo
        '        If My.Settings.RastrearTareas Then
        '            EscribirMensaje("Registrando Recaudo: " & ReciboActual)
        '        End If
        '        If My.Settings.Archivo Then
        '            AlmacenarEnArchivo("Registrando Recaudo: " & ReciboActual)
        '        End If
        '        DatosRecibo = oHelper.RecuperarinformaciondeCreditoChile(ReciboActual)
        '        If Not DatosRecibo Is Nothing Then
        '            oAbonos.CodEstacion = DatosRecibo.CodEstacion
        '            oAbonos.Credito = DatosRecibo.IdCredito
        '            oAbonos.Recibo = ReciboActual
        '            oAbonos.Valor = DatosRecibo.Recaudo
        '            oAbonos.IdTipoRecaudo = DatosRecibo.IdTipoRecaudo
        '            oAbonos.ValorTipoRecaudo = DatosRecibo.ValorTipoRecaudo

        '            RespuestaCDC = oCInformacion.RegistrarVentaCredito(oAbonos)


        '            EscribirMensaje("Respuesta CDC: " & IIf(RespuestaCDC.EsProcesado = True, "Procesado", "Falla en CDC"))
        '            Application.DoEvents()
        '            If Not RespuestaCDC.EsProcesado Then
        '                Throw New System.Exception("Falla en Procesamiento en CDC: " & RespuestaCDC.MensajeError)
        '            End If
        '            ErrorRecaudos = ""
        '            ValorRecaudos = ReciboActual.ToString()
        '            oHelper.ActualizarSincronizacion("Recaudos", ReciboActual.ToString, POSstation.Fabrica.CDCS.CRM)
        '            txtRecaudo.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoRecaudos))

        '            ReciboActual = ReciboActual + 1
        '        Else
        '            ErrorRecaudos = ""
        '            ValorRecaudos = ReciboActual.ToString()
        '            oHelper.ActualizarSincronizacion("Recaudos", ReciboActual.ToString, POSstation.Fabrica.CDCS.CRM)
        '            txtRecaudo.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoRecaudos))
        '            ReciboActual = ReciboActual + 1
        '        End If

        '        Application.DoEvents()


        '    End While
        '    EnviarRecaudos = False
        'Catch Ex As System.Exception
        '    ErrorRecaudos = Ex.Message
        '    If My.Settings.RastrearTareas Then
        '        EscribirMensaje(Ex.Message)
        '    End If
        '    If My.Settings.Archivo Then
        '        AlmacenarEnArchivo(Ex.Message)
        '    End If
        '    txtRecaudo.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoRecaudos))
        '    Application.DoEvents()
        'Finally
        '    EnviarRecaudos = False
        'End Try
    End Sub



    Private Sub RegistrarGerenciamiento()
        Dim GerenciamientoActual As Long
        Dim idGerenciamiento As Long

        Try
            idGerenciamiento = oHelper.RecuperarUltimoGerenciamiento()
            GerenciamientoActual = CLng(Me.txtGerenciamiento.Text) + 1

            While GerenciamientoActual <= idGerenciamiento
                EnviarGerenciamientoCRM(GerenciamientoActual)
            End While
            EnviarGerenciamiento = False
        Catch Ex As System.Exception
            ErrorGerenciamiento = Ex.Message
            If My.Settings.RastrearTareas Then
                EscribirMensaje(Ex.Message)
            End If
            If My.Settings.Archivo Then
                AlmacenarEnArchivo(Ex.Message)
            End If
            txtGerenciamiento.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoGerenciamiento))
            Application.DoEvents()

        Finally
            EnviarGerenciamiento = False
        End Try
    End Sub

    Private Sub EnviarGerenciamientoCRM(ByRef GerenciamientoActual As Long)
        Dim oCInformacion As New Comunicacion.Comunicacion
        Dim InfoGerenciamiento As New Comunicacion.VentaGerencia
        Dim DatosGerenciamiento As POSstation.AccesoDatos.InformacionGerenciamiento = Nothing
        Dim Respuesta As New Comunicacion.RespuestaCDC

        oCInformacion.Url = oHelper.RecuperarParametro("ServicioGeneral")

        Application.DoEvents()

        DatosGerenciamiento = oHelper.RecuperarInformacionGerenciamientoPeruCRMStation(GerenciamientoActual)

        If My.Settings.RastrearTareas Then
            EscribirMensaje("Registrando Gerenciamiento: " & GerenciamientoActual)
        End If
        If My.Settings.Archivo Then
            AlmacenarEnArchivo("Registrando Gerenciamiento: " & GerenciamientoActual)
        End If
        Application.DoEvents()

        If Not DatosGerenciamiento Is Nothing Then
            Application.DoEvents()
            With InfoGerenciamiento
                .CodEstacion = DatosGerenciamiento.CodEstacion
                .IdAutorizacionCDC = DatosGerenciamiento.Autorizacion
                .ReciboEds = DatosGerenciamiento.Recibo

                If Not String.IsNullOrEmpty(DatosGerenciamiento.Kilometraje) Then
                    .Kilometraje = CInt(DatosGerenciamiento.Kilometraje)
                End If
            End With
            Respuesta = oCInformacion.ConfirmarVentaGerenciamiento(InfoGerenciamiento)

            EscribirMensaje("Respuesta CDC: " & IIf(Respuesta.EsProcesado = True, "Procesado", "Falla en CDC"))
            Application.DoEvents()

            If Not Respuesta.EsProcesado Then
                Throw New System.Exception("Falla en Procesamiento en CDC: " & Respuesta.MensajeError)
            End If
        End If

        ErrorGerenciamiento = ""
        ValorGerenciamiento = GerenciamientoActual.ToString()
        oHelper.ActualizarSincronizacion("Gerenciamiento", GerenciamientoActual.ToString, POSstation.Fabrica.CDCS.CRM)
        txtGerenciamiento.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoGerenciamiento))

        GerenciamientoActual = GerenciamientoActual + 1

        DatosGerenciamiento = Nothing
        InfoGerenciamiento = Nothing
        oCInformacion = Nothing
        Application.DoEvents()
    End Sub




#End Region

#Region "Funciones auxiliares"
    Private Sub ActualizarTextoVenta()
        Try
            ErrorProvider.SetError(txtVentas, ErrorVentas)
            If Not String.IsNullOrEmpty(Me.ValorVentas) Then
                txtVentas.Text = ValorVentas
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ActualizarTextoVenta", "", "Comunicador")
        End Try
    End Sub

    Private Sub ActualizarTextoLectura()
        Try
            ErrorProvider.SetError(txtLecturas, ErrorLecturas)
            If Not String.IsNullOrEmpty(Me.ValorLecturas) Then
                txtLecturas.Text = ValorLecturas
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ActualizarTextoLectura", "", "Comunicador")
        End Try
    End Sub
    Private Sub ActualizarTextoRecaudos()
        'Try
        '    ErrorProvider.SetError(txtRecaudo, ErrorRecaudos)
        '    If Not String.IsNullOrEmpty(ValorRecaudos) Then
        '        txtRecaudo.Text = ValorRecaudos
        '    End If
        'Catch ex As System.Exception
        '    LogFallas.ReportarError(ex, "ActualizarTextoRecaudos", "", "Comunicador")
        'End Try
    End Sub


    Private Sub ActualizarTextoGerenciamiento()
        Try
            ErrorProvider.SetError(txtGerenciamiento, ErrorGerenciamiento)
            If Not String.IsNullOrEmpty(Me.ValorGerenciamiento) Then
                txtGerenciamiento.Text = ValorGerenciamiento
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ActualizarTextoGerenciamiento", "", "Comunicador")
        End Try
    End Sub


    Private Sub RecuperarSincronizacion()
        Try
            Dim oDatos As New POSstation.AccesoDatos.SqlServer

            Dim dtSincro As DataTable = oDatos.RecuperarSincronizacion(POSstation.Fabrica.CDCS.CRM).Tables(0)

            Me.txtVentas.Text = CDbl(dtSincro.Rows(0).Item("Ventas").ToString).ToString("N0")
            ''Me.txtRecaudo.Text = CDbl(dtSincro.Rows(0).Item("Recaudos").ToString).ToString("N0")
            Me.txtLecturas.Text = CDbl(dtSincro.Rows(0).Item("Lecturas").ToString).ToString("N0")
            Me.txtGerenciamiento.Text = CDbl(dtSincro.Rows(0).Item("Gerenciamiento").ToString).ToString("N0")

        Catch Ex As System.Exception
            LogFallas.ReportarError(Ex, "RecuperarSincronizacion", "", "Comunicador")
            Popup.ContentText = Ex.Message
            Popup.Popup()
        End Try
    End Sub

    Private Sub EscribirMensaje(ByVal Texto As String)
        Try
            Mensaje = Texto
            txtMensajes.BeginInvoke(New MethodInvoker(AddressOf Rastrear))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "EscribirMensaje", "", "Comunicador")
        End Try
    End Sub

    Private Sub Rastrear()
        Try
            Dim InicioSeleccion As Int32 = txtMensajes.Text.Length
            txtMensajes.Text = txtMensajes.Text & Mensaje & vbNewLine
            txtMensajes.SelectionStart = InicioSeleccion
            txtMensajes.SelectionLength = Mensaje.Length
            Me.txtMensajes.ScrollToCaret()
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "Rastrear", "", "Comunicador")
        End Try
    End Sub

    Private Sub AlmacenarEnArchivo(ByVal Mensaje As String)
        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Depuracion") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Depuracion")
            End If
            Using sw As StreamWriter = File.AppendText(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt")
                sw.WriteLine(Mensaje)
                sw.Close()
            End Using
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AlmacenarEnArchivo", "", "Comunicador")
        End Try
    End Sub

    Private Sub Popup_Click() Handles Popup.Click
        MsgBox(Popup.ContentText)
    End Sub
#End Region

#Region "Orquestador"
    Private Sub tmrVenta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVenta.Tick
        Dim oHelper As New POSstation.AccesoDatos.SqlServer
        Try
            Me.Recibo_ = oHelper.RecuperarUltimoRecibo
            tmrVenta.Stop()
            RegistrarVentas(Recibo_)
            RegistrarGerenciamiento()
            TomaLecturasFinalesFinalizada()

            tmrVenta.Start()
        Catch ex As System.Exception
            tmrVenta.Start()
            LogFallas.ReportarError(ex, "AlmacenarEnArchivo", "", "Comunicador")
        End Try
    End Sub
#End Region

End Class