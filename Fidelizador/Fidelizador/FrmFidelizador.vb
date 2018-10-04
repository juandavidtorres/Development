''--------------------------------------------------------- NUEVO COMUNICADOR CDC PERU ------------------------------------------------------

Imports POSstation.AccesoDatos
Imports System.Threading
Imports System.ComponentModel
Imports System.IO
Imports System.Data.SqlClient
Imports System.Timers
Imports POSstation.Fabrica

Public Class FrmFidelizador


    Private ErrorVentas As String, ValorVentas As String
    Private Recibo_ As Double
    Private EnviarVentas As Boolean, Enviando As Boolean
    Private EnviarRedencionBonos As Boolean, ErrorRedencionBonos As String, ValorRedencionBonos As String, IdConfirmacionRedencionBono As Long
    Private EnviarRedencionAnulados As Boolean, ErrorRedencionAnulados As String, ValorRedencionAnulados As String
    Private Mensaje As String
    Dim LogFallas As New EstacionException


    Private Sub frmFidelizador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim oHelper As Helper = New Helper

            Application.EnableVisualStyles()

            If My.Settings.RastrearTareas Then
                Me.Height = 329
            Else
                Me.Height = 149
            End If
            RecuperarSincronizacion()

            EnviarVentas = True
            Me.Recibo_ = OHelper.RecuperarUltimoRecibo

        Catch Ex As System.Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub

    'Private Sub oEventos_ImprimirFidelizacion(ByRef recibo As String, ByRef puerto As String, ByRef cliente As String) Handles oEventos.ImprimirFidelizacion
    '    If Not EnviarVentas Then
    '        Recibo_ = recibo
    '        EnviarVentas = True
    '    End If
    'End Sub

    'Private Sub oEventos_ImprimirRedencionBonoVentaFidelizate(ByRef recibo As String, ByRef idAutorizacion As String, ByRef puerto As String) Handles oEventos.ImprimirRedencionBonoVentaFidelizate
    '    If Not Me.EnviarRedencionBonos Then
    '        Me.EnviarRedencionBonos = True
    '    End If
    'End Sub

    'Private Sub oEventos_NotificarFallaRedencionBonoFidelizacion(ByRef recibo As String, ByRef puerto As String) Handles oEventos.NotificarFallaRedencionBonoFidelizacion
    '    If Not Me.EnviarRedencionAnulados Then
    '        Me.EnviarRedencionAnulados = True
    '    End If
    'End Sub

    'Private Sub oEventos_ImprimirVenta(ByRef Recibo As Double, ByRef cara As Byte, ByRef EsVentaRegistrada As Boolean) Handles oEventos.ImprimirVenta
    '    If Not EnviarVentas And EsVentaRegistrada Then
    '        'Dim OReader As IDataReader
    '        'Dim OHelper As New Helper
    '        'Try
    '        '    OReader = OHelper.RecuperarVentaFidelizada(Recibo, EsVentaRegistrada)
    '        '    If OReader.Read Then
    '        Recibo_ = Recibo
    '        EnviarVentas = True
    '        'End If
    '        'OReader.Close()
    '        '    Catch ex As System.Exception
    '        '    'If Not OReader.IsClosed Then

    '        '    'End If
    '        '    If My.Settings.Archivo Then
    '        '        AlmacenarEnArchivo(" oEventos_ImprimirVenta: " & ex.Message)
    '        '    End If
    '        'End Try
    '    End If
    'End Sub

    'Efectuado Cambio para nuevo CDC Peru
    Private Sub RegistrarVentas(ByVal Recibo As Double)
        Dim ReciboActual As Double
        Dim DatosRecibo As POSstation.AccesoDatos.InformacionVentaFidelizada = Nothing
        Dim oCInformacion As New Fidelizacion.Fidelizacion
        Dim oHelper As Helper = New Helper
        Dim Respuesta As String

        Try
            ReciboActual = CDbl(txtVentas.Text) + 1


            oCInformacion.Url = oHelper.RecuperarParametro("ServicioFidelizacion")

            While ReciboActual <= Recibo

                DatosRecibo = oHelper.RecuperarInformacionVentaFidelizada(CLng(ReciboActual))

                If My.Settings.RastrearTareas Then
                    EscribirMensaje("Registrando Fidelizacion: " & ReciboActual)
                    If My.Settings.Archivo Then
                        AlmacenarEnArchivo("Registrando Fidelizacion: " & ReciboActual)
                    End If
                End If
                Application.DoEvents()

                If Not DatosRecibo Is Nothing Then
                    Respuesta = oCInformacion.RegistrarVentaFidelizada(ReciboActual, CDate(DatosRecibo.Fecha).ToString("yyyyMMdd HH:mm:ss"), DatosRecibo.Cantidad, DatosRecibo.Total, DatosRecibo.Placa, DatosRecibo.IdProducto, DatosRecibo.CodEstacion, DatosRecibo.Tarjeta)

                    If Not String.IsNullOrEmpty(Respuesta) Then
                        Throw New System.Exception(Respuesta)
                    End If
                End If

                ErrorVentas = ""
                ValorVentas = ReciboActual.ToString()

                If My.Settings.RastrearTareas Then
                    EscribirMensaje("Respuesta: Procesado")
                    If My.Settings.Archivo Then
                        AlmacenarEnArchivo("Respuesta: Procesado")
                    End If
                End If

                oHelper.ActualizarSincronizacion("Fidelizacion", ReciboActual.ToString, POSstation.Fabrica.CDCS.CDCGST)
                txtVentas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoVenta))

                ReciboActual = ReciboActual + 1

                Application.DoEvents()
            End While
            EnviarVentas = False
        Catch Ex As System.Exception
            ErrorVentas = Ex.Message
            If My.Settings.RastrearTareas Then
                EscribirMensaje(Ex.Message)
                If My.Settings.Archivo Then
                    AlmacenarEnArchivo(Ex.Message)
                End If
            End If
            txtVentas.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoVenta))
            ' System.Threading.Thread.Sleep(60000)
        Finally
            oCInformacion.Dispose()

            If Not DatosRecibo Is Nothing Then
                DatosRecibo.Dispose()
            End If
            EnviarVentas = False
        End Try
    End Sub

    'Efectuado Cambio para nuevo CDC Peru
    Private Sub RegistrarConfirmacionRedencionBonos()
        Dim IdRedencionBono As Long
        Dim UltimoIdRedencionBono As Long
        Dim DatosRedencionBono As InformacionRedencionBono = Nothing
        Dim oCInformacion As New Fidelizacion.Fidelizacion
        Dim oHelper As Helper = New Helper
        Dim Respuesta As Fidelizacion.RespuestaRedencion = Nothing

        Try
            IdRedencionBono = CLng(Me.txtRedencionBonos.Text) + 1
            UltimoIdRedencionBono = oHelper.RecuperarUltimoIdRedencionBono()

            oCInformacion.Url = oHelper.RecuperarParametro("ServicioFidelizacion")


            While IdRedencionBono <= UltimoIdRedencionBono

                DatosRedencionBono = oHelper.RecuperarInformacionRedencionBono(IdRedencionBono)

                If My.Settings.RastrearTareas Then
                    EscribirMensaje("Registrando Redencion Bono: " & IdRedencionBono)
                    If My.Settings.Archivo Then
                        AlmacenarEnArchivo("Registrando Redencion Bono: " & IdRedencionBono)
                    End If
                End If
                Application.DoEvents()

                If Not DatosRedencionBono Is Nothing Then

                    Respuesta = oCInformacion.ConfirmacionRedencionBonos(DatosRedencionBono.CodEstacion, DatosRedencionBono.Tarjeta, DatosRedencionBono.Recibo, DatosRedencionBono.IdAutorizacionFidelizacion, IdRedencionBono, DatosRedencionBono.Valor)

                    If Not Respuesta Is Nothing Then
                        If Not Respuesta.Autorizado Then
                            Throw New System.Exception(Respuesta.MensajeError)
                        End If
                    Else
                        Throw New System.Exception("Falla en la Comunicacion con el Fidelizate")
                    End If


                    If My.Settings.RastrearTareas Then
                        EscribirMensaje("Respuesta Redencion Bono: Procesado")
                        If My.Settings.Archivo Then
                            AlmacenarEnArchivo("Respuesta Redencion Bono: Procesado")
                        End If
                        Application.DoEvents()
                    End If

                End If

                ErrorRedencionBonos = ""
                ValorRedencionBonos = IdRedencionBono.ToString()
                oHelper.ActualizarSincronizacion("RedencionBonos", IdRedencionBono.ToString, POSstation.Fabrica.CDCS.CDCGST)
                txtRedencionBonos.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoRedencionBonos))
                Application.DoEvents()

                IdRedencionBono = IdRedencionBono + 1
            End While
        Catch Ex As System.Exception
            ErrorRedencionBonos = Ex.Message
            If My.Settings.RastrearTareas Then
                EscribirMensaje(Ex.Message)
                If My.Settings.Archivo Then
                    AlmacenarEnArchivo(Ex.Message)
                End If
            End If
            txtRedencionBonos.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoRedencionBonos))
            ' System.Threading.Thread.Sleep(60000)
        Finally
            EnviarRedencionBonos = False
        End Try
    End Sub

    'Efectuado Cambio para nuevo CDC Peru
    Private Sub RegistrarAnulacionRedencionBonos()
        Dim IdAnulacionRedencionBono As Long
        Dim UltimoIdAnulacionRedencionBono As Long
        Dim DatosRedencionBono As InformacionRedencionBono = Nothing
        Dim oCInformacion As New Fidelizacion.Fidelizacion
        Dim oHelper As Helper = New Helper
        Dim Respuesta As Fidelizacion.RespuestaRedencion = Nothing

        Try
            IdAnulacionRedencionBono = CLng(Me.txtAnularRedencion.Text) + 1
            UltimoIdAnulacionRedencionBono = oHelper.RecuperarUltimoIdAnulacionRedencionBono()

            oCInformacion.Url = oHelper.RecuperarParametro("ServicioFidelizacion")


            While IdAnulacionRedencionBono <= UltimoIdAnulacionRedencionBono

                DatosRedencionBono = oHelper.RecuperarInformacionAnulacionRedencionBono(IdAnulacionRedencionBono)

                If My.Settings.RastrearTareas Then
                    EscribirMensaje("Registrando Anulacion Redencion Bono: " & IdAnulacionRedencionBono)
                    If My.Settings.Archivo Then
                        AlmacenarEnArchivo("Registrando Anulacion Redencion Bono: " & IdAnulacionRedencionBono)
                    End If
                End If
                Application.DoEvents()

                If Not DatosRedencionBono Is Nothing Then

                    Respuesta = oCInformacion.CancelarRedencionBonos(DatosRedencionBono.CodEstacion, DatosRedencionBono.Tarjeta, DatosRedencionBono.Recibo, DatosRedencionBono.Valor)

                    If Not Respuesta Is Nothing Then
                        If Not Respuesta.Autorizado Then
                            Throw New System.Exception(Respuesta.MensajeError)
                        End If
                    Else
                        Throw New System.Exception("Falla en la Comunicacion con el Fidelizate")
                    End If


                    If My.Settings.RastrearTareas Then
                        EscribirMensaje("Respuesta Anulacion Redencion Bono: Procesado")
                        If My.Settings.Archivo Then
                            AlmacenarEnArchivo("Respuesta Anulacion Redencion Bono: Procesado")
                        End If
                        Application.DoEvents()
                    End If

                End If

                ErrorRedencionAnulados = ""
                ValorRedencionAnulados = IdAnulacionRedencionBono.ToString()
                oHelper.ActualizarSincronizacion("RedencionAnulados", IdAnulacionRedencionBono.ToString, POSstation.Fabrica.CDCS.CDCGST)
                txtAnularRedencion.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoAnulacionRedencionBonos))
                Application.DoEvents()

                IdAnulacionRedencionBono = IdAnulacionRedencionBono + 1
            End While
        Catch Ex As System.Exception
            ErrorRedencionAnulados = Ex.Message
            If My.Settings.RastrearTareas Then
                EscribirMensaje(Ex.Message)
                If My.Settings.Archivo Then
                    AlmacenarEnArchivo(Ex.Message)
                End If
            End If
            Me.txtAnularRedencion.BeginInvoke(New MethodInvoker(AddressOf ActualizarTextoAnulacionRedencionBonos))
            ' System.Threading.Thread.Sleep(60000)
        Finally
            EnviarRedencionAnulados = False
        End Try
    End Sub

    Private Sub ActualizarTextoVenta()
        ErrorProvider.SetError(txtVentas, ErrorVentas)
        If Not String.IsNullOrEmpty(ValorVentas) Then
            txtVentas.Text = ValorVentas
        End If
    End Sub

    Private Sub ActualizarTextoRedencionBonos()
        Try
            ErrorProvider.SetError(txtRedencionBonos, ErrorRedencionBonos)
            If Not String.IsNullOrEmpty(ValorRedencionBonos) Then
                txtRedencionBonos.Text = ValorRedencionBonos
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ActualizarTextoRedencionBonos", "", "Fidelizador")
        End Try
    End Sub

    Private Sub ActualizarTextoAnulacionRedencionBonos()
        Try
            ErrorProvider.SetError(txtAnularRedencion, ErrorRedencionAnulados)
            If Not String.IsNullOrEmpty(ValorRedencionAnulados) Then
                txtAnularRedencion.Text = ValorRedencionAnulados
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ActualizarTextoAnulacionRedencionBonos", "", "Fidelizador")
        End Try
    End Sub

    Private Sub RecuperarSincronizacion()
        Try
            Dim oDatos As New Helper

            Dim dtSincro As DataTable = oDatos.RecuperarSincronizacion(POSstation.Fabrica.CDCS.CDCGST).Tables(0)

            Me.txtVentas.Text = CDbl(dtSincro.Rows(0)("Fidelizacion").ToString).ToString("N0")
            Me.txtRedencionBonos.Text = CDbl(dtSincro.Rows(0)("RedencionBonos").ToString).ToString("N0")
            Me.txtAnularRedencion.Text = CDbl(dtSincro.Rows(0)("RedencionAnulados").ToString).ToString("N0")

            'dtSincro.Dispose()
        Catch Ex As System.Exception
            LogFallas.ReportarError(Ex, "RecuperarSincronizacion", "", "Fidelizador")
            Popup.ContentText = Ex.Message
            Popup.Popup()
        End Try
    End Sub


    Private Sub EscribirMensaje(ByVal Texto As String)
        Try
            Mensaje = Texto
            txtMensajes.BeginInvoke(New MethodInvoker(AddressOf Rastrear))
        Catch
            Throw
        End Try
    End Sub

    Private Sub Rastrear()
        Try
            Dim InicioSeleccion As Int32 = txtMensajes.Text.Length
            txtMensajes.Text = txtMensajes.Text & Mensaje & vbNewLine
            txtMensajes.SelectionStart = InicioSeleccion
            txtMensajes.SelectionLength = Mensaje.Length
            Me.txtMensajes.ScrollToCaret()
        Catch
            Throw
        End Try

    End Sub

    Private Shared Sub AlmacenarEnArchivo(ByVal Mensaje As String)
        If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Depuracion") Then
            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Depuracion")
        End If

        Using sw As StreamWriter = File.AppendText(My.Application.Info.DirectoryPath & "\Depuracion\RastroFidelizacion.txt")
            sw.WriteLine(Mensaje)
            sw.Flush()
            sw.Close()
            sw.Dispose()
        End Using
    End Sub

    Private Sub Popup_Click() Handles Popup.Click
        MsgBox(Popup.ContentText)
    End Sub

    Private Sub tmrVenta_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVenta.Tick
        Dim oHelper As New Helper

        Try
            tmrVenta.Stop()

            'If Not Enviando Then
            'If EnviarVentas Then
            'Enviando = True
            'Como las demas tablas tienen menos registros, intento enviarlas primero

            Me.Recibo_ = oHelper.RecuperarUltimoRecibo
            RegistrarVentas(Recibo_)

            'If Not Me.EnviarRedencionBonos Then
            ''  EnviarRedencionBonos = True
            Me.RegistrarConfirmacionRedencionBonos()
            ' End If

            'If Not Me.EnviarRedencionAnulados Then
            ''EnviarRedencionAnulados = True
            Me.RegistrarAnulacionRedencionBonos()
            ' End If

            'Enviando = False
            'ElseIf Me.EnviarRedencionBonos Then
            'Enviando = True
            Me.RegistrarConfirmacionRedencionBonos()
            'Enviando = False
            ' ElseIf Me.EnviarRedencionAnulados Then
            'Enviando = True
            Me.RegistrarAnulacionRedencionBonos()
            'Enviando = False
            'End If
            'End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "tmrVenta_Tick", "", "Fidelizador")
            Try
                Enviando = False
                RecuperarSincronizacion()
                Application.DoEvents()

            Catch ex2 As System.Exception
                LogFallas.ReportarError(ex2, "tmrVenta_Tick", "", "Fidelizador")
            End Try
        Finally
            tmrVenta.Start()
        End Try
    End Sub

End Class





