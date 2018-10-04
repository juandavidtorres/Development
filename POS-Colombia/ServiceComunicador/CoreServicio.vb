
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports POSstation.Fabrica
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System
Imports POSstation
Imports POSstation.AccesoDatos
Imports POSstation.AccesoDatos.Helper



Public Class CoreServicio
#Region "Definicion de Variables y Objetos"
    Dim ThreadEnvioCDC As Thread
    Dim ThreadConsultaCDC As Thread
    Dim LogFallas As New EstacionException
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog

    Private txtGerenciamientoAnulado As String
    Private txtGerenciamiento As String
    Private txtTurnos As String

    Private ErrorGerenciamiento As String, ValorGerenciamiento As String, EnviarGerenciamiento As Boolean
    Private ErrorGerenciamientoAnulado As String, ValorGerenciamientoAnulado As String, EnviarGerenciamientoAnulado As Boolean
    Private ErrorTurnos, ValorTurnos As String, EnviarTurnos As Boolean

    Public Shared LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
    Dim oHelper As New Helper
    Dim StopEnvioCDC As Boolean
    Dim StopConsultasCDC As Boolean
    WithEvents TimerEnvio As System.Timers.Timer
    WithEvents TimerConsulta As System.Timers.Timer
#End Region

    Public Sub New()
        Incializar()
    End Sub

    Protected Overrides Sub Finalize()
        Terminar()
        MyBase.Finalize()
    End Sub

    Public Sub Incializar()
        Try
            TimerConsulta = New Timers.Timer
            AddHandler TimerConsulta.Elapsed, AddressOf TimerConsulta_Elapsed
            TimerConsulta.Interval = 5000
            TimerConsulta.Enabled = True


            TimerEnvio = New Timers.Timer
            AddHandler TimerConsulta.Elapsed, AddressOf TimerConsulta_Elapsed
            TimerEnvio.Interval = 5000
            TimerEnvio.Enabled = True
            IniciarConfiguracion()
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OnStar", "InicioSauce", "InicioSauce")
        End Try
    End Sub

    Public Sub Terminar()
        Try
            ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
            StopEnvioCDC = False

            If Not TimerEnvio Is Nothing Then
                TimerEnvio.Enabled = False
                TimerEnvio.Dispose()
                TimerEnvio = Nothing
            End If

            If Not TimerConsulta Is Nothing Then
                TimerConsulta.Enabled = False
                TimerConsulta.Dispose()
                TimerConsulta = Nothing
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "Terminar()", "Comunicador Terpel", "InicioSauce")
        End Try


    End Sub


    'Listo Implementacion Para FullStation
    Private Sub IniciarConfiguracion()
        EventLog1 = New System.Diagnostics.EventLog
        If (Not System.Diagnostics.EventLog.SourceExists("LogueoComunicador")) Then
            System.Diagnostics.EventLog.CreateEventSource("LogueoComunicador", "LogGasolutions")
        End If
        EventLog1.Source = "LogueoComunicador"
        EventLog1.Log = "LogGasolutions"

        EventLog1.WriteEntry("Inicio la ejecución del  Comunicador Sauce")




        Try
            AlmacenarEnArchivo("INICIA SERVICIO")
        Catch ex As System.Exception
            EventLog1.WriteEntry("Falla al Almacenar en Archivo: " & ex.Message)
            Throw ex
        End Try
        StopEnvioCDC = True
        StopConsultasCDC = True


        'ThreadEnvioCDC = New Thread(AddressOf EnviarDatosCDC)
        'ThreadEnvioCDC.Start()

        'ThreadConsultaCDC = New Thread(AddressOf ConsultarDatosCDC)
        'ThreadConsultaCDC.Start()

        EventLog1.WriteEntry("Inicio la ejecucion del  Envio")


    End Sub

    Private Sub RegistrarTurnosTerpel()
        Dim TurnoActual, Turno As Int32

        Try
            Turno = oHelper.RecuperarUltimoTurnoCerrado()
            TurnoActual = CInt(Me.txtTurnos) + 1

            While TurnoActual <= Turno
                EnviarTurnoTerpel(TurnoActual)
                TurnoActual = TurnoActual + 1
            End While
        Catch Ex As System.Exception
            ErrorTurnos = Ex.Message
            If My.Settings.Archivo Then
                AlmacenarEnArchivo(Ex.Message)
            End If

        Finally
            EnviarTurnos = False
        End Try
    End Sub

    Private Sub EnviarTurnoTerpel(ByRef TurnoActual As Int32)
        Dim InfoRespuesta As String = ""
        Dim Turno As String = ""
        Dim ODatos As String = Nothing

        If My.Settings.Archivo Then
            AlmacenarEnArchivo("Registrando Turno Terpel" & TurnoActual)
        End If

        Try
            ODatos = oHelper.RecuperarTurnoJSON(TurnoActual)
        Catch ex As System.Exception
            ODatos = Nothing
        End Try

        If Not String.IsNullOrEmpty(ODatos) Then
            InfoRespuesta = ServerServices.CDCTerpelComunicacion.EnviarTurnoTerpelCDC(ODatos)

            If My.Settings.Archivo Then
                AlmacenarEnArchivo("Respuesta  Turno Terpel" & InfoRespuesta)
            End If

            If Not String.IsNullOrEmpty(InfoRespuesta) Then
                If InfoRespuesta <> "OK" And InfoRespuesta.Contains(",") Then
                    Dim sep() As String = {","}
                    Dim ventas() As String = InfoRespuesta.Split(sep, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To ventas.Length
                        Dim resp As String = ""
                        Try
                            resp = oHelper.RecuperarIdGerenciamientoPorIdAprobacion(ventas(i))
                        Catch ex As System.Exception
                            LogFallas.ReportarError(ex, "Error recuperando el IdGerenciamiento Por IdAprobacion", "IdAprobacion: " + ventas(i), "ServiceComunicador")
                        End Try

                        If Not String.IsNullOrEmpty(resp) Then
                            Try
                                EnviarGerenciamientoTerpel(resp)
                            Catch ex As System.Exception
                                LogFallas.ReportarError(ex, "Error enviando el gerenciamiento", "IdGerenciamiento: " + resp, "ServiceComunicador")
                            End Try
                        End If
                    Next
                End If
            End If
        End If

        Me.ValorTurnos = CStr(TurnoActual)
        oHelper.ActualizarSincronizacion("TurnosTrabajo", TurnoActual.ToString, CDCS.CDCGST)
        ErrorTurnos = ""
    End Sub


#Region "Envio Informacion"

#Region "Terpel"
    Private Sub RegistrarGerenciamiento()
        Dim GerenciamientoActual As Long
        Dim idGerenciamiento As Long

        Try
            idGerenciamiento = oHelper.RecuperarUltimoGerenciamiento()
            GerenciamientoActual = CLng(Me.txtGerenciamiento) + 1

            While GerenciamientoActual <= idGerenciamiento
                EnviarGerenciamientoTerpel(GerenciamientoActual)

                ErrorGerenciamiento = ""
                ValorGerenciamiento = GerenciamientoActual.ToString()
                oHelper.ActualizarSincronizacion("Gerenciamiento", GerenciamientoActual.ToString, CDCS.CDCGST)

                GerenciamientoActual = GerenciamientoActual + 1
            End While
            EnviarGerenciamiento = False
        Catch Ex As System.Exception
            ErrorGerenciamiento = Ex.Message

            If My.Settings.Archivo Then
                AlmacenarEnArchivo(Ex.Message)
            End If

        Finally
            EnviarGerenciamiento = False
        End Try
    End Sub

    Private Sub EnviarGerenciamientoTerpel(ByVal GerenciamientoActual As Long)
        Dim DatosGerenciamiento As String = Nothing
        DatosGerenciamiento = oHelper.RecuperarVentaJSON(GerenciamientoActual)

        If My.Settings.Archivo Then
            AlmacenarEnArchivo("Registrando Gerenciamiento: " & GerenciamientoActual)
        End If

        If Not String.IsNullOrEmpty(DatosGerenciamiento) Then
            ServerServices.CDCTerpelComunicacion.EnviarVentaTerpelCDC(DatosGerenciamiento)
        End If

        DatosGerenciamiento = Nothing
    End Sub


    '--- Gerenciamiento Anulado ----
    Private Sub RegistrarGerenciamientoAnulado()
        Dim GerenciamientoAnuladoActual As Long
        Dim IdGerenciamientoAct As Long
        Dim DatosGerenciaAnulado As IDataReader
        Try
            IdGerenciamientoAct = oHelper.RecuperarUltimoGerenciamientoAnulado()
            GerenciamientoAnuladoActual = CLng(Me.txtGerenciamientoAnulado) + 1

            While GerenciamientoAnuladoActual <= IdGerenciamientoAct
                If My.Settings.Archivo Then
                    AlmacenarEnArchivo("Registrando Gerenciamiento Anulado: " & GerenciamientoAnuladoActual)
                End If

                DatosGerenciaAnulado = oHelper.RecuperarInformacionGerenciamientoAnulado(GerenciamientoAnuladoActual)

                If DatosGerenciaAnulado.Read() Then
                    Dim StrGerenciamiento As String
                    If (CInt(DatosGerenciaAnulado.Item("Estado")) = 3) Then
                        StrGerenciamiento = String.Format("{{{0}IA{0}:{0}{1}{0},{0}CODEDS{0}:{0}{2}{0}}}", """",
                                            DatosGerenciaAnulado.Item("Autorizacion"), DatosGerenciaAnulado.Item("CodEstacion"))

                        ServerServices.CDCTerpelComunicacion.AnularGerenciamientoTerpelCDC(StrGerenciamiento)
                    End If
                End If

                If Not DatosGerenciaAnulado.IsClosed Then
                    DatosGerenciaAnulado.Close()
                    DatosGerenciaAnulado.Dispose()
                End If

                ErrorGerenciamientoAnulado = ""
                ValorGerenciamientoAnulado = GerenciamientoAnuladoActual.ToString()
                oHelper.ActualizarSincronizacion("GerenciamientoAnulado", GerenciamientoAnuladoActual.ToString, CDCS.CDCGST)

                GerenciamientoAnuladoActual = GerenciamientoAnuladoActual + 1

            End While

        Catch Ex As System.Exception
            ErrorGerenciamientoAnulado = Ex.Message
            If My.Settings.Archivo Then
                AlmacenarEnArchivo(Ex.Message)
            End If
        Finally
            EnviarGerenciamientoAnulado = False
        End Try
    End Sub


#End Region

#End Region
    Private Sub ConsultarDatosCDC()
        Dim oHelper As New Helper
        Try

            Try
                Me.ConsultarFaltantesTerpel()
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "ConsultarFaltantesTerpel", "", "ServiceComunicador")
            End Try

        Catch ex As System.Exception
            EventLog1.WriteEntry("Falla en Timer Servicio: " & ex.Message)
            LogFallas.ReportarError(ex, "ConsultarDatosCDC", "", "ServiceComunicador")
        End Try
    End Sub

    Private Sub ConsultarFaltantesTerpel()

        Dim resp As RespuestaFaltantesTerpel
        Try
            resp = ServerServices.CDCTerpelComunicacion.ObtenerFaltantes()
        Catch ex As System.Exception
            resp = Nothing
        End Try

        If Not resp Is Nothing Then

            ''Envíamos las aprobaciones
            For Each idAprobacion As Integer In resp.AprobacionesFaltantes
                Dim respIdGerenciamiento As String = ""
                Try
                    respIdGerenciamiento = oHelper.RecuperarIdGerenciamientoPorIdAprobacion(idAprobacion)
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "Error recuperando el IdGerenciamiento Por IdAprobacion", "IdAprobacion: " + idAprobacion.ToString(), "ServiceComunicador")
                End Try

                If Not String.IsNullOrEmpty(respIdGerenciamiento) Then
                    Try
                        EnviarGerenciamientoTerpel(respIdGerenciamiento)
                    Catch ex As System.Exception
                        LogFallas.ReportarError(ex, "Error enviando el gerenciamiento", "IdGerenciamiento: " + respIdGerenciamiento, "ServiceComunicador")
                    End Try
                End If
            Next

            ''Envíamos los turnos
            For Each TurnoActual As Integer In resp.AprobacionesFaltantes
                Dim InfoRespuesta As String = ""
                Dim Turno As String = ""
                Dim ODatos As String = Nothing

                Try
                    ODatos = oHelper.RecuperarTurnoJSON(TurnoActual)
                Catch ex As System.Exception
                    ODatos = Nothing
                End Try

                If Not String.IsNullOrEmpty(ODatos) Then
                    InfoRespuesta = ServerServices.CDCTerpelComunicacion.EnviarTurnoTerpelCDC(ODatos)

                    If Not String.IsNullOrEmpty(InfoRespuesta) Then
                        Dim sep() As String = {","}
                        Dim ventas() As String = InfoRespuesta.Split(sep, StringSplitOptions.RemoveEmptyEntries)
                        For i As Integer = 0 To ventas.Length
                            Dim respIdGerenciamiento As String = ""
                            Try
                                respIdGerenciamiento = oHelper.RecuperarIdGerenciamientoPorIdAprobacion(ventas(i))
                            Catch ex As System.Exception
                                LogFallas.ReportarError(ex, "Error recuperando el IdGerenciamiento Por IdAprobacion", "IdAprobacion: " + ventas(i), "ServiceComunicador")
                            End Try

                            If Not String.IsNullOrEmpty(respIdGerenciamiento) Then
                                Try
                                    EnviarGerenciamientoTerpel(respIdGerenciamiento)
                                Catch ex As System.Exception
                                    LogFallas.ReportarError(ex, "Error enviando el gerenciamiento", "IdGerenciamiento: " + respIdGerenciamiento, "ServiceComunicador")
                                End Try
                            End If
                        Next
                    End If
                End If
            Next
        End If




    End Sub

    Private Sub EnviarDatosCDC()
        Dim oHelper As New Helper


        Try

            Me.RecuperarSincronizacion(Fabrica.CDCS.CDCGST)


            Try
                Me.RegistrarGerenciamiento()
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "EnviarDatosCDC", "", "ServiceComunicador")
            End Try


            Try
                RegistrarGerenciamientoAnulado()
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "EnviarDatosCDC", "", "ServiceComunicador")
            End Try

            Try
                RegistrarTurnosTerpel()
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "tmrCombustible_Tick", "", "Comunicador")
            End Try

        Catch ex As System.Exception
            EventLog1.WriteEntry("Falla en Timer Servicio: " & ex.Message)
            LogFallas.ReportarError(ex, "EnviarDatosCDC", "", "ServiceComunicador")
        End Try

    End Sub


#Region "Funciones auxiliares"

    Private Sub RecuperarSincronizacion(ByVal cdc As CDC)
        Try
            Dim oDatos As New Helper
            Dim dtSincro As DataTable
            dtSincro = oDatos.RecuperarSincronizacion(cdc).Tables(0)
            Me.txtGerenciamiento = CInt(dtSincro.Rows(0).Item("Gerenciamiento")).ToString
            Me.txtGerenciamientoAnulado = CInt(dtSincro.Rows(0).Item("GerenciamientoAnulado")).ToString
            Me.txtTurnos = CInt(dtSincro.Rows(0).Item("TurnosTrabajo").ToString).ToString("N0")
        Catch Ex As System.Exception
            LogFallas.ReportarError(Ex, "RecuperarSincronizacion", "", "ServiceComunicador")
        End Try
    End Sub


    Private Sub AlmacenarEnArchivo(ByVal Mensaje As String)
        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Depuracion") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Depuracion")
            End If
            Using sw As StreamWriter = File.AppendText(My.Application.Info.DirectoryPath & "\Depuracion\Rastro.txt")
                sw.WriteLine(DateTime.Now & "|" & Mensaje)
                sw.Close()
            End Using
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AlmacenarEnArchivo", "", "Comunicador")
        End Try
    End Sub


#End Region
    ''' <summary>
    ''' Recibe 1 para el temporizador de consulta y 0 para el temporizador de envio
    ''' </summary>
    ''' <param name="TipoTimer"></param>
    ''' <remarks></remarks>
    Private Sub IniciarTimer(TipoTimer As Integer)
        Try
            If TipoTimer = 1 Then '' timer de Consulta
                If Not TimerConsulta Is Nothing Then
                    TimerConsulta.Dispose()
                    TimerConsulta = Nothing
                End If
                TimerConsulta = New Timers.Timer
                AddHandler TimerConsulta.Elapsed, AddressOf TimerConsulta_Elapsed
                TimerConsulta.Interval = 5000
                TimerConsulta.Enabled = True

            Else
                If Not TimerEnvio Is Nothing Then
                    TimerEnvio.Dispose()
                    TimerEnvio = Nothing
                End If

                TimerEnvio = New Timers.Timer
                AddHandler TimerEnvio.Elapsed, AddressOf TimerEnvio_Elapsed
                TimerEnvio.Interval = 5000
                TimerEnvio.Enabled = True
            End If
        Catch ex As System.Exception
            Try
                EventLog1.WriteEntry("Falla en IniciarTimer: " & ex.Message)
                LogFallas.ReportarError(ex, "IniciarTimer", "", "ServiceComunicador")
            Catch

            End Try
        End Try
    End Sub



    Private Sub TimerConsulta_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TimerConsulta.Elapsed
        Try
            TimerConsulta.Enabled = False

            Dim finicial As DateTime = Date.Now.ToString("dd/MM/yyyy") & " 11:57:00 PM"
            Dim ffinal As DateTime = Date.Now.ToString("dd/MM/yyyy") & " 11:59:57 PM"
            Dim fechaactual As DateTime = Now

            If fechaactual >= finicial And fechaactual <= ffinal Then
                ConsultarDatosCDC()
            End If

        Catch ex As System.Exception
            EventLog1.WriteEntry("Falla en Timer Servicio TimerConsulta_Elapsed: " & ex.Message)
            LogFallas.ReportarError(ex, "TimerConsulta_Elapsed", "", "ServiceComunicador")
        Finally
            IniciarTimer(1)
        End Try
    End Sub

    Private Sub TimerEnvio_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TimerEnvio.Elapsed
        Try
            TimerEnvio.Enabled = False
            EnviarDatosCDC()
        Catch ex As System.Exception
            EventLog1.WriteEntry("Falla en Timer Servicio TimerConsulta_Elapsed: " & ex.Message)
            LogFallas.ReportarError(ex, "TimerConsulta_Elapsed", "", "ServiceComunicador")
        Finally
            IniciarTimer(0)
        End Try
    End Sub
End Class



