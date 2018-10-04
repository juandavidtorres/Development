
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports POSstation.Fabrica
Imports POSstation.FabricaCanastilla
Imports POSstation.Inventario
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System
Imports POSstation
Imports POSstation.AccesoDatos
Imports POSstation.AccesoDatos.Helper
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports POSstation.Protocolos
Imports POSstation.ServerServices
Imports System.Timers
Imports SICOM



Public Class CoreServicio
#Region "Definicion de Variables y Objetos"
    Private WithEvents OEventos As SharedEventsFuelStation.CMensaje
    Dim CarasEstacion As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean)
    Dim RomEstacion As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim FechasEstacion As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim CreditosEstacion As New Dictionary(Of String, Fabrica.CreditoFullstation)
    Dim CreditosTerpel As New Dictionary(Of String, Fabrica.CreditoFullstation)
    Dim DatosMenoCash As New Dictionary(Of String, Fabrica.MenoCash)

    'VENTA GERENCIADA
    'Dim CreditoGerenciadoEstacion As Dictionary(Of String, CreditoEstacion) = New Dictionary(Of String, Fabrica.CreditoEstacion)
    Dim DocumentosVenta As Dictionary(Of String, Fabrica.Documento) = New Dictionary(Of String, Fabrica.Documento)

    Dim KilometrajesEstacion As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim VentaEfectivo As New System.Collections.Specialized.StringDictionary
    Dim Fidelizacion As Dictionary(Of String, Fidelizacion) = New Dictionary(Of String, Fabrica.Fidelizacion)
    'Diccionario para almacenar si se esta realizando una calibracion
    Dim Consumos As Dictionary(Of String, Fabrica.Consumo) = New Dictionary(Of String, Fabrica.Consumo)
    Dim ColVentaBono As Dictionary(Of String, Fabrica.PredeterminacionPagoVentaBono) = New Dictionary(Of String, Fabrica.PredeterminacionPagoVentaBono)
    Dim VentasCheques As Dictionary(Of String, Fabrica.Credito) = New Dictionary(Of String, Fabrica.Credito)
    Dim listaDispositivos As List(Of Object)
    Dim OProtocolo As iProtocolo
    Dim LogFallas As New EstacionException
    Dim VentasPorConductor As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim ListaSurtidores As List(Of iProtocolo)


    Dim ColPreset As Dictionary(Of String, Fabrica.Preset) = New Dictionary(Of String, Fabrica.Preset)
    Dim ColPlacas As Dictionary(Of String, String) = New Dictionary(Of String, String)
    Dim ColFormasPagoVenta As Dictionary(Of String, FormaPagoVenta) = New Dictionary(Of String, Fabrica.FormaPagoVenta)
    Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
    Dim VentaPrepago As Dictionary(Of String, CupoPrepago) = New Dictionary(Of String, CupoPrepago)

    Dim ColDispositivosLSIB4 As Dictionary(Of String, InformacionDispositivoLSIB4) = New Dictionary(Of String, InformacionDispositivoLSIB4)
    Dim LecturasLSIB4 As Dictionary(Of String, BytesLectura) = New Dictionary(Of String, BytesLectura)
    Dim DataTrack As Dictionary(Of String, DatosDataTrack) = New Dictionary(Of String, DatosDataTrack)

    'Servicio WCF
    Dim OTerminal As New ServiceTerminalHost
    Dim Servicio As ServiceHost

    'VeederRoot
    Dim ListaVeederRoots As List(Of Object)
    Dim OVeederRoot As Object

    'Manejo de Timer para el cierre de turno automatico
    Dim temporizadorTurno As System.Timers.Timer


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
            IniciarConfiguracion()
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OnStar", "InicioSauce", "InicioSauce")
        End Try
    End Sub

    Public Sub Terminar()
        ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
        Dim oHelper As Helper = New Helper()
        Try


            For Each surtidor As iProtocolo In ListaSurtidores
                surtidor.Evento_CerrarProtocolo()
            Next

            ListaSurtidores.Clear()
            oHelper.InsertarEventosServicioAutorizador("OnStop", "Servicio Autorizador Detenido")
        Catch ex As System.Exception
            oHelper.InsertarEventosServicioAutorizador("OnStop", ex.Message.ToString())
            LogFallas.ReportarError(ex, " OnStop()", "", "Sauce")
        End Try
    End Sub

#Region "Definicion de Metodos"
    Private Worker As BackgroundWorker




    'Listo Implementacion Para FullStation
    Public Sub IniciarConfiguracion()
        Dim oHelper As Helper = New Helper()
        Try

            POSstation.Fabrica.gasolutionsHasp.IsHasp()

            If ValidarPuertos() Then
                'Instancio la referencia al comunicador
                Try
                    '*****************************************************************************
                    'EventLog1.WriteEntry("Inicio la ejecucion de WCF")
                    '*****************************************************************************
                    IniciarServicioWcf()

                    '*****************************************************************************
                    'EventLog1.WriteEntry("Inicio la ejecucion de WCF")
                    '*****************************************************************************
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "Autorizador_Load", "", "Autorizador")
                    oHelper.InsertarEventosServicioAutorizador("OnStar", "Problema al instanciar el Servicio" & vbNewLine & " (" & ex.Message & ")")
                End Try


                Try
                    OEventos = CType(CreateObject("SharedEventsFuelStation.CMensaje"), SharedEventsFuelStation.CMensaje)
                Catch EXExternalException As Runtime.InteropServices.ExternalException
                    LogFallas.ReportarError(EXExternalException, "Iniciar", "IniciarSharedEvent", "Eventos")
                Catch EXEventos As System.Exception
                    LogFallas.ReportarError(EXEventos, "Iniciar", "IniciarSharedEvent", "Eventos")
                End Try


                Dim CantidadCaras As Short
                Dim Precio As Double = 0

                CantidadCaras = oHelper.RecuperarCantidadCaras()

                Dim CarasData As DataSet = oHelper.RecuperarCaras

                For Each CaraEds As DataRow In CarasData.Tables(0).Rows
                    FechasEstacion.Add(CaraEds.Item("IdCara").ToString, "")
                    RomEstacion.Add(CaraEds.Item("IdCara").ToString, "")
                    CarasEstacion.Add(CaraEds.Item("IdCara").ToString, False)
                Next

                Try
                    ListaSurtidores = New List(Of iProtocolo)
                    IniciarSurtidores()
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "OnStar", "", "InicioSauce")
                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString())
                    LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
                    LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
                    Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
                    LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
                    oHelper.InsertarEventosServicioAutorizador("OnStar", "Problema al instanciar la(s) red(es) de surtidor(es)." & vbNewLine & "Revise los nombre de las librerias y los protocolos en el configurador (" & ex.Message & ")")
                End Try

                Try
                    listaDispositivos = New List(Of Object)
                    IniciarDispositivosLSIB4()
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "OnStar", "", "InicioSauce")
                    oHelper.InsertarEventosServicioAutorizador("OnStar", "Problema al instanciar Dispositivos LSIB4 - " + ex.Message)
                End Try

                Try
                    ColDispositivosLSIB4 = New Dictionary(Of String, InformacionDispositivoLSIB4)
                    RecuperarConfiguracionCara()
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "OnStar", "", "InicioSauce")
                    oHelper.InsertarEventosServicioAutorizador("OnStar", "Problema al instanciar Dispositivos LSIB4 - " + ex.Message)
                End Try

                Try
                    ListaVeederRoots = New List(Of Object)
                    IniciarVeederRoots()
                    My.Application.Log.WriteEntry("Inicio la ejecucion de Veeder")
                Catch EXSurtidores As System.Exception
                    LogFallas.ReportarError(EXSurtidores, "Iniciar - ", "", "Eventos")
                End Try

                '--------------INICIO DE TIMER CIERRE DE TURNO AUTOMATICO -------
                Try
                    Try
                        GC.KeepAlive(temporizadorTurno)
                    Catch ex As System.Exception
                        LogFallas.ReportarError(ex, "Configurando el GC", "Mensaje Controlado de logueo", "Eventos")
                    End Try

                    If CBool(oHelper.RecuperarParametro("AplicaCierreTurnoAutomatico")) Then
                        ConfigurarCierreTurnoAutomatico()
                        My.Application.Log.WriteEntry("Inicio la ejecucion de Revision de Cierres de Turno Automatico")
                    Else
                        My.Application.Log.WriteEntry("Parametro AplicaCierreTurnoAutomatico inactivo, NO se Inicia la ejecucion de Revision de Cierres de Turno Automatico")
                    End If

                Catch Ex As System.Exception
                    LogFallas.ReportarError(Ex, "Iniciar - ", "", "Eventos")
                End Try

                '--------------- FIN TIMER CIERRE AUTOMATICO ---------------

            Else
                oHelper.InsertarEventosServicioAutorizador("OnStar", "Existen Puertos Invalidos")
                Terminar()
            End If
        Catch Ex As GasolutionsHaspException
            oEventos_ExcepcionOcurrida("LLAVE HASP NO ENCONTRADA", True, False, "")
            LogFallas.ReportarError(Ex, "OnStar", "-", "InicioSauce")
        Catch ex As System.Exception
            oHelper.InsertarEventosServicioAutorizador("OnStar", ex.Message.ToString())
            LogFallas.ReportarError(ex, "OnStar", "", "InicioSauce")
        End Try
    End Sub

#Region "Cierre de turno Automatico"
    Private Sub ConfigurarCierreTurnoAutomatico()
        Dim DifMilisegundos As Double = 1000
        Try

            DifMilisegundos = My.Settings.TimerTurno
            DifMilisegundos = (DifMilisegundos * 1000)

            If DifMilisegundos <= 0 Then
                DifMilisegundos = 5000
            End If

            '*****************************************************************************
            'LOGUEANDO LA CONFIGURACION DE HORARIOS
            LogCategorias.Clear()
            LogCategorias.Agregar("TemporizadorCierreTurno")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaSuceso", Now.ToString)
            LogPropiedades.Agregar("Intervalo", DifMilisegundos)
            LogIt.Loguear("ConfigurarCierreTurnoAutomatico", LogPropiedades, LogCategorias)

        Catch ex As ObjectDisposedException
            LimpiarTimer(1) ''Inicio el timer de Turno
            LogFallas.ReportarError(ex, "ConfigurarCierreTurnoAutomatico", "Mensaje de Seguimiento: Se libera el Temporizador de cierre de turno y se reinicia para su correcto funcionamiento", "Eventos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ConfigurarCierreTurnoAutomatico", "", "Eventos")
        Finally
            Try
                LogCategorias.Clear()
                LogCategorias.Agregar("TemporizadorCierreTurno")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Finally", Now.ToString)
                LogIt.Loguear("ConfigurarCierreTurnoAutomatico", LogPropiedades, LogCategorias)
                LimpiarTimer(1, DifMilisegundos) 'Inicio el Timer Cierre de turno

            Catch ex As ObjectDisposedException
                LimpiarTimer(1) 'Inicio el timer de Turno
                LogFallas.ReportarError(ex, "ConfigurarCierreTurnoAutomatico", "Mensaje de Seguimiento: Se libera el Temporizador y se reinicia para su correcto funcionamiento", "Eventos")
            Catch ex As System.Exception
                LimpiarTimer(1, DifMilisegundos) 'Inicio el Timer Cierre de turno
                LogFallas.ReportarError(ex, "ConfigurarCierreTurnoAutomatico", "Finally", "Eventos")
            End Try
        End Try
    End Sub

    Private Sub LimpiarTimer(Tipo As Integer, Optional Tiempo As Long = 5000)
        Try
            If Not temporizadorTurno Is Nothing Then
                temporizadorTurno.Dispose()
                temporizadorTurno = Nothing
            End If
            temporizadorTurno = New System.Timers.Timer
            temporizadorTurno.AutoReset = True

            AddHandler temporizadorTurno.Elapsed, AddressOf oTimerCierreTurno_Tick
            AddHandler temporizadorTurno.Disposed, AddressOf oTimerCierreTurno_Dispose

            temporizadorTurno.Interval = Tiempo
            temporizadorTurno.Enabled = True

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "LimpiarTimer", "", "Eventos")
        End Try
    End Sub

    Private Sub oTimerCierreTurno_Dispose(ByVal source As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub oTimerCierreTurno_Tick(ByVal source As Object, ByVal e As ElapsedEventArgs)
        Try
            Dim oHelper As New Helper
            Dim Cerrado As Boolean

            temporizadorTurno.Enabled = False
            If CBool(oHelper.RecuperarParametro("AplicaCierreTurnoAutomatico")) Then
                Cerrado = CerrarTurnosActuales()
                If Cerrado = False Then
                    Throw New System.Exception("Existen turnos con ventas en curso")
                End If
            End If

            ConfigurarCierreTurnoAutomatico()
        Catch ex As ObjectDisposedException
            LimpiarTimer(1) 'Inicio el timer de Turno
            LogFallas.ReportarError(ex, "Elapsed", "Mensaje de Seguimiento: Se libera el Temporizador de cierre autimatico de turno y se reinicia para su correcto funcionamiento", "Eventos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oTimerCierreTurno_Tick", "", "Eventos")
            Try
                LimpiarTimer(1, 3000) ''Inicio el Timer de Cierre de Turno
            Catch ex2 As System.Exception
                LogFallas.ReportarError(ex, "ConfigurarCierreTurnoAutomatico", "Finally", "Eventos")
            End Try
        End Try
    End Sub

    Private Function CerrarTurnosActuales() As Boolean
        Dim OHelper As New Helper
        Dim Turnos As IDataReader
        Dim IdTurno As Int32 = -1
        Dim Cerrado As Boolean = True
        Try
            Turnos = OHelper.RecuperarTurnosAbiertosPendientes()
            While Turnos.Read()
                Try
                    IdTurno = CInt(Turnos.Item("IdTurno"))
                    If OHelper.ValidarVentaParcialPorTurno(IdTurno) Then
                        Cerrado = False
                    Else
                        CerrarTurnosAutomaticamente(CInt(Turnos.Item("IdTurno")), "")
                    End If

                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "CerrarTurnosActuales-SolicitarCierreTurnoAutomatico", "-", "Eventos")
                    Try
                        Turnos.Close()
                        Turnos = Nothing
                    Catch ErrorTemp As System.Exception

                    End Try
                    Throw ex
                End Try
            End While
            Turnos.Close()
            Turnos = Nothing

            '*****************************************************************************
            'LOGUEANDO LA CONFIGURACION DE HORARIOS
            LogCategorias.Clear()
            LogCategorias.Agregar("TemporizadorCierreTurno")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("IdTurno", IdTurno.ToString)
            LogPropiedades.Agregar("FechaSuceso", Now.ToString)
            LogIt.Loguear("CerrarTurnosActuales", LogPropiedades, LogCategorias)
            '*****************************************************************************
            Return Cerrado

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "CerrarTurnosActuales", "-", "Eventos")
            Throw ex
        End Try
    End Function

    Private Sub CerrarTurnosAutomaticamente(idTurnoA As Integer, puerto As String)
        Dim Surtidores As String = ""
        Dim IdTurno As System.Int32 = 0
        Dim oHelper As New Helper

        Try
            oHelper.CerrarTurnoValidacion(Surtidores, IdTurno, idTurnoA)

            If Not String.IsNullOrEmpty(Surtidores) Then
                ListaProtocolos_TurnoCerrado(Surtidores, puerto)
            Else
                oEventos_TomaLecturasFinalesFinalizada(IdTurno)
            End If
        Catch EXBD As Data.DataException

            oHelper.InsertarTurnoFallidoLogueo(idTurnoA, "", "", EXBD.Message.ToString(), puerto, "CerrarTurnosAutomaticamente")

            LogFallas.ReportarError(EXBD, "OEventos_CierreTurnoAutomatico", "IdTurno: " & idTurnoA, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(EXBD.Message, puerto)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            oHelper.InsertarTurnoFallidoLogueo(idTurnoA, "", "", EXSQL.Message.ToString(), puerto, "CerrarTurnosAutomaticamente")

            LogFallas.ReportarError(EXSQL, "OEventos_CierreTurnoAutomatico", "IdTurno: " & idTurnoA, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(EXSQL.Message, puerto)
            Throw
        Catch Ex As System.Exception
            oHelper.InsertarTurnoFallidoLogueo(idTurnoA, "", "", Ex.Message.ToString(), puerto, "CerrarTurnosAutomaticamente")

            LogFallas.ReportarError(Ex, "OEventos_CierreTurnoAutomatico", "IdTurno: " & idTurnoA, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(Ex.Message, puerto)
            Throw
        Finally
        End Try
    End Sub

#End Region


    Private Sub IniciarVeederRoots()
        Try
            Dim OHelper As Helper = New Helper
            Dim VeederRoots As DataSet
            Dim Tanques As DataSet
            Dim OEnsamblado As Assembly
            Dim OTipo As Type
            Dim OTanque As Tanque
            Dim Frecuencia As String
            Dim dll As String = OHelper.RecuperarParametro("DispositivoMedicion")

            If String.IsNullOrEmpty(dll) Then
                Throw New System.Exception("Configurar la libreria de dispositivos de medicion en la opcion de tanques del configurador")
            End If

            OEnsamblado = Assembly.LoadFrom(My.Application.Info.DirectoryPath & "\" & dll)
            'Junio 22 de 2007 (Jgalviz) :Ahora el nombre de la clase se toma por reflection
            Dim asmTypes() As Type = OEnsamblado.GetTypes()
            Dim NombreLibreria As String = ""

            For Each T As Type In asmTypes
                If T.IsClass = True And Not T.Namespace Is Nothing AndAlso T.Namespace.Contains("POSstation.Protocolos") Then
                    NombreLibreria = (T.FullName.ToString)
                    Exit For
                End If
            Next
            If NombreLibreria.Length = 0 Then
                Throw New GasolutionsException("No existe una clase válida en el Namespace " & OEnsamblado.FullName)
            End If

            OTipo = OEnsamblado.GetType(NombreLibreria)

            Frecuencia = OHelper.RecuperarParametro("FrecuenciaLogueoVeederRoot").ToString()

            VeederRoots = OHelper.RecuperarDispositivosMedicionActivos()
            For Each VeederRoot As DataRow In VeederRoots.Tables(0).Rows
                Dim ListaTanques As New Dictionary(Of Int32, Tanque)
                Tanques = OHelper.RecuperarTanquesActivosPorDispositivo(CInt(VeederRoot.Item("IdDispositivo").ToString()))
                For Each Tanque As DataRow In Tanques.Tables(0).Rows
                    OTanque = New Tanque()
                    OTanque.TankNumber = CInt(Tanque.Item("Codigo"))
                    ListaTanques.Add(CInt(Tanque.Item("Codigo")), OTanque)
                Next

                OVeederRoot = Activator.CreateInstance(OTipo, CBool(VeederRoot.Item("EsTCPIP").ToString), VeederRoot.Item("IP").ToString, VeederRoot.Item("Puerto").ToString, ListaTanques, OEventos, Frecuencia)
                Me.ListaVeederRoots.Add(OVeederRoot)
            Next
            VeederRoots = Nothing
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXTargetParameterCountException As Reflection.TargetParameterCountException
            LogFallas.ReportarError(EXTargetParameterCountException, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXReflectionTypeLoadException As Reflection.ReflectionTypeLoadException
            LogFallas.ReportarError(EXReflectionTypeLoadException, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXTargetException As Reflection.TargetException
            LogFallas.ReportarError(EXTargetException, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXTargetInvocationException As Reflection.TargetInvocationException
            LogFallas.ReportarError(EXTargetInvocationException, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXTypeLoadException As TypeLoadException
            LogFallas.ReportarError(EXTypeLoadException, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXTypeUnloadedException As TypeUnloadedException
            LogFallas.ReportarError(EXTypeUnloadedException, "IniciarVeederRoots", "", "Autorizador")
            Throw
        Catch EXGeneral As System.Exception
            LogFallas.ReportarError(EXGeneral, "IniciarVeederRoots", "", "Autorizador")
            Throw
        End Try
    End Sub

    Private Sub IniciarServicioWcf()
        Try
            Dim numero As New List(Of String)
            Dim oHelper As New Helper
            numero.ToArray()

            'Dim baseAddress As Uri = New Uri(My.Settings.UrlServicio)
            Dim baseAddress As Uri = New Uri(oHelper.RecuperarParametro("UrlServicio"))

            ' Create the ServiceHost.
            Servicio = New ServiceHost(OTerminal, baseAddress)

            ' Enable metadata publishing.
            Dim smb As New ServiceMetadataBehavior()
            Dim debug As ServiceDebugBehavior

            'debug.IncludeExceptionDetailInFaults = True

            smb.HttpGetEnabled = True
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15

            debug = Servicio.Description.Behaviors.Find(Of ServiceDebugBehavior)()
            debug.IncludeExceptionDetailInFaults = True

            Servicio.Description.Behaviors.Add(smb)

            AddHandler OTerminal.oEventos_Preset, AddressOf oEventos_Preset
            AddHandler OTerminal.oEventos_ImprimirSaldoTarjetaPrepago, AddressOf OEventos_ImprimirSaldoTarjetaPrepago
            AddHandler OTerminal.oEventos_ImprimirMovimientosPrepago, AddressOf OEventos_ImprimirMovimientosPrepago
            AddHandler OTerminal.oEventos_AutorizarVentaPrepago, AddressOf OEventos_AutorizarVentaPrepago
            AddHandler OTerminal.oEventos_EnvioVentaConsumoCombustible, AddressOf OEventos_EnvioVentaConsumoCombustible
            AddHandler OTerminal.oEventos_RegistrarPlaca, AddressOf OEventos_RegistrarPlaca
            AddHandler OTerminal.oEventos_GuardarKilometraje, AddressOf oEventos_GuardarKilometraje
            AddHandler OTerminal.oEventos_Calibracion, AddressOf oEventos_Calibracion
            AddHandler OTerminal.oEventos_EnviarAlturasCierreDeTanques, AddressOf OEventos_EnviarAlturasCierreDeTanques
            AddHandler OTerminal.oEventos_VentaCredito, AddressOf oEventos_VentaCredito
            AddHandler OTerminal.oEventos_ReportarPagoEfectivo, AddressOf oEventos_ReportarPagoEfectivo
            AddHandler OTerminal.oEventos_FidelizarVentaManual, AddressOf oEventos_FidelizarVentaManual
            AddHandler OTerminal.oEventos_EnviarDatos, AddressOf oEventos_EnviarDatos
            AddHandler OTerminal.oEventos_AperturaTurno, AddressOf oEventos_AperturaTurno
            AddHandler OTerminal.oEventos_AperturaTurnoTrabajo, AddressOf OEventos_AperturaTurnoTrabajo
            AddHandler OTerminal.oEventos_CerrarTurno, AddressOf oEventos_CierreTurno
            AddHandler OTerminal.oEventos_ReportarExcepcion, AddressOf oEventos_ExcepcionOcurrida
            AddHandler OTerminal.oEventos_SolicitarRegistrarPlaca, AddressOf OEventos_RegistrarPlaca
            AddHandler OTerminal.oEventos_ReimprimirDocumentoPorNumero, AddressOf oEventos_ReimprimirReciboPorConsecutivo
            AddHandler OTerminal.oEventos_ReimprimirTurnoPorSurtidor, AddressOf oEventos_ReimprimirTurnoPorSurtidor
            AddHandler OTerminal.oEventos_ReimprimirTurnoPorEmpleado, AddressOf oEventos_ReimprimirTurnoPorEmpleado
            AddHandler OTerminal.oEventos_ReimprimirTurnoFrecuenciaPorEmpleado, AddressOf oEventos_ReimprimirTurnoFrecuenciaPorEmpleado
            AddHandler OTerminal.oEventos_ImprimirResumenDiario, AddressOf oEventos_ImprimirResumenDiario
            AddHandler OTerminal.oEventos_SolicitudDatosIbutton, AddressOf oEventos_SolicitudDatosIbutton
            AddHandler OTerminal.oEventos_ImprimirArqueo, AddressOf oEventos_ImprimirArqueo
            AddHandler OTerminal.oEventos_SolicitudDatosIbuttonImpresionArm, AddressOf oEventos_SolicitudDatosIbuttonImpresionArm
            AddHandler OTerminal.oEventos_ReImprimirCopiaFacturaProductosServicios, AddressOf OEventos_ReImprimirCopiaFacturaProductosServicios
            AddHandler OTerminal.oEventos_AutorizarVentaCheque, AddressOf OEventos_AutorizarVentaCheque
            AddHandler OTerminal.oEventos_FidelizarUltimaVenta, AddressOf oEventos_FidelizarUltimaVenta
            AddHandler OTerminal.oEventos_FidelizarVenta, AddressOf oEventos_FidelizarVenta
            AddHandler OTerminal.oEventos_ConsultarSaldoTarjetaFidelizacion, AddressOf OEventos_ConsultarSaldoTarjetaFidelizacion
            AddHandler OTerminal.oEventos_PredeterminarPagoVentaBonoFidelizacion, AddressOf OEventos_PredeterminarPagoVentaBonoFidelizacion
            AddHandler OTerminal.OEventos_ImprimirVentaCanastilla, AddressOf OEventos_ImprimirModificacionVentaCanastilla
            AddHandler OTerminal.OEventos_ImprimirFacturaCanastillaUnica, AddressOf OEventos_ImprimirFacturaCanastillaUnica
            AddHandler OTerminal.oEventos_SolicitarModificacionVenta, AddressOf oEventos_ModificarVenta
            AddHandler OTerminal.OEventos_RedencionBonosFidelizacion, AddressOf OEventos_RedencionBonosFidelizacion
            AddHandler OTerminal.oEventos_EnviarRemarcacionCanastilla, AddressOf OEventos_EnviarRemarcacionesCanastilla
            AddHandler OTerminal.OEventos_InformarCierreConsignaciones, AddressOf OEventos_InformarCierreConsignaciones
            AddHandler OTerminal.OEventos_EnviarRemarcaciones, AddressOf OEventos_EnviarRemarcaciones
            AddHandler OTerminal.OEventos_ImprimirDocumentoReciboCombustible, AddressOf OEventos_ImprimirDocumentoReciboCombustible
            AddHandler OTerminal.oEventos_AnularFacturaCanastilla, AddressOf OEventos_AnularFacturaVentaCanastillaTerpel
            AddHandler OTerminal.oEventos_EnviarCambioCheque, AddressOf OEventos_EnviarCambioCheque
            AddHandler OTerminal.oEventos_ImprimirRecargaPrepago, AddressOf OEventos_ImprimirRecargaPrepago
            AddHandler OTerminal.oEventos_reImprimirRecargaPrepago, AddressOf OEventos_ReImprimirRecargaPrepago
            AddHandler OTerminal.oEventos_VentaCreditoCanastilla, AddressOf OEventos_VentaCreditoCanastilla

            AddHandler OTerminal.OEventos_PagarVentaConBono, AddressOf OEventos_PagarVentaConBono

            AddHandler OTerminal.oEventos_VentaCreditoTerpel, AddressOf oEventos_VentaCreditoTerpel
            AddHandler OTerminal.oEventos_EnviarDatosMenoCash, AddressOf oEventos_EnviarDatosMenoCash
            AddHandler OTerminal.oEventos_EnviarAjusteDeTanquesVeederRoot, AddressOf oEventos_EnviarAjusteDeTanquesVeederRoot

            Servicio.Open()

        Catch EXCapturadores As System.Exception
            LogFallas.ReportarError(New System.Exception("Problema al iniciar el servicio."), "IniciarServicioWcf", "", "Autorizador")

        End Try

    End Sub



    ''Recupero la configuracion de las Cara
    Private Sub RecuperarConfiguracionCara()
        Try
            Dim OHelper As New Helper
            Dim Lector As IDataReader
            Lector = OHelper.RecuperarConfiguracionCara()
            Dim oDatos As InformacionDispositivoLSIB4
            Dim oCara As String

            While Lector.Read
                oDatos = New InformacionDispositivoLSIB4()
                oCara = CStr(Lector.Item("IdCara").ToString())
                oDatos.IdDti = CInt(Lector.Item("IdDti").ToString())
                oDatos.Puerto = CStr(Lector.Item("Puerto").ToString())
                oDatos.IdPuerto = CInt(Lector.Item("IdPuertoDti").ToString())
                If Not ColDispositivosLSIB4.ContainsKey(oCara) Then
                    ColDispositivosLSIB4.Add(oCara, oDatos)
                End If
            End While
            Lector.Close()
            Lector = Nothing
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "RecuperarConfiguracionCara", "", "Autorizador")
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "RecuperarConfiguracionCara", "", "Autorizador")
        Catch EXCapturadores As System.Exception
            LogFallas.ReportarError(EXCapturadores, "RecuperarConfiguracionCara", "", "Autorizador")
        End Try
    End Sub




    'Listo Implementacion Para FullStation
    Private Sub IniciarSurtidores()
        Try
            Dim OHelper As Helper = New Helper
            Dim TipoSurtidores As DataSet
            Dim Protocolo_ As IDataReader
            Dim Puerto As String
            Dim Eco As Boolean
            Dim OEnsamblado As Assembly
            Dim OTipo As Type
            Dim DataCaras As DataSet
            Dim DataGrados As DataSet


            TipoSurtidores = OHelper.RecuperarRedSurtidores

            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString)
            Fabrica.LogIt.Loguear("Antes de iniciar los protocolos", LogPropiedades, LogCategorias)

            For Each Red As DataRow In TipoSurtidores.Tables(0).Rows
                Protocolo_ = OHelper.RecuperarProtocolo(CInt(Red.Item("IdProtocolo").ToString))
                If Protocolo_.Read Then
                    Puerto = Red.Item("Puerto").ToString
                    Eco = CBool(Red.Item("Eco").ToString)

                    Dim ListaRedSurtidor As New Dictionary(Of Byte, RedSurtidor)

                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Ruta", My.Application.Info.DirectoryPath & "\" & Protocolo_.Item("PathLibreria").ToString)
                    Fabrica.LogIt.Loguear("Antes de buscar libreria del protocolo", LogPropiedades, LogCategorias)

                    OEnsamblado = Assembly.LoadFrom(My.Application.Info.DirectoryPath & "\" & Protocolo_.Item("PathLibreria").ToString)

                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Ruta", My.Application.Info.DirectoryPath & "\" & Protocolo_.Item("PathLibreria").ToString)
                    Fabrica.LogIt.Loguear("Se Cargo el ensamblado", LogPropiedades, LogCategorias)

                    'Junio 22 de 2007 (Jgalviz) :Ahora el nombre de la clase se toma por reflection
                    Dim asmTypes() As Type = OEnsamblado.GetTypes()
                    Dim NombreLibreria As String = ""

                    For Each T As Type In asmTypes
                        If T.IsClass = True And Not T.Namespace Is Nothing AndAlso T.Namespace.Contains("POSstation.Protocolos") Then
                            NombreLibreria = (T.FullName.ToString)
                            Exit For
                        End If
                    Next
                    If NombreLibreria.Length = 0 Then
                        Throw New GasolutionsException("No existe una clase válida en el Namespace " & OEnsamblado.FullName)
                    End If


                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Ruta", "Paso 0")
                    Fabrica.LogIt.Loguear("Prueba", LogPropiedades, LogCategorias)


                    OTipo = OEnsamblado.GetType(NombreLibreria)

                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Ruta", "Paso 1")
                    Fabrica.LogIt.Loguear("Prueba", LogPropiedades, LogCategorias)


                    DataCaras = OHelper.RecuperarRedCaras(CInt(Red.Item("IdRed")))
                    Dim ORed As RedSurtidor
                    Dim OGrado As Grados

                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Ruta", "Paso 2")
                    Fabrica.LogIt.Loguear("Prueba", LogPropiedades, LogCategorias)

                    For Each Cara As DataRow In DataCaras.Tables(0).Rows
                        ORed = New RedSurtidor
                        ORed.Cara = CByte(Cara.Item("CaraAsignada"))
                        ORed.CaraBD = CByte(Cara.Item("IdCara"))
                        ORed.IdSurtidor = CInt(Cara.Item("IdSurtidor"))
                        ORed.Activa = CBool(Cara.Item("Estado"))
                        ORed.EsVentaParcial = CBool(Cara.Item("VentaParcial"))
                        ORed.FactorPrecio = CInt(Cara.Item("FactorPrecio"))
                        ORed.FactorTotalizador = CInt(Cara.Item("FactorTotalizador"))
                        ORed.FactorVolumen = CInt(Cara.Item("FactorVolumen"))
                        ORed.FactorImporte = CInt(Cara.Item("FactorImporte"))
                        ORed.LecturaInicialVenta = CDec(Cara.Item("LecturaInicial"))
                        ORed.EsVentaGerenciada = False
                        ORed.MultiplicadorPrecioVenta = CDec(Cara.Item("MultiplicadorPrecioVenta"))
                        ORed.AplicaCambioPrecioCliente = CBool(Cara.Item("ManejaPrecioPorCliente"))
                        ORed.Gilbarco_Extended = CBool(IIf(String.IsNullOrEmpty(Cara.Item("ManejaCincoDigitos")), 0, (Cara.Item("ManejaCincoDigitos"))))
                        ORed.FactorPredeterminacionVolumen = CInt(Cara.Item("PredeterminacionVolumen"))
                        ORed.FactorPredeterminacionImporte = CInt(Cara.Item("PredeterminacionImporte"))

                        LogCategorias.Clear()
                        LogCategorias.Agregar("LogueoSurtidores")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Fecha", Now.ToString)
                        LogPropiedades.Agregar("Ruta", "Paso 3")
                        Fabrica.LogIt.Loguear("Prueba", LogPropiedades, LogCategorias)

                        DataGrados = OHelper.RecuperarManguerasPorCara(ORed.CaraBD)

                        For Each Grado As DataRow In DataGrados.Tables(0).Rows
                            OGrado = New Grados
                            OGrado.Autorizar = True
                            OGrado.NoGrado = CByte(Grado.Item("Grado"))
                            OGrado.IdProducto = CInt(Grado.Item("IdProducto"))
                            OGrado.MangueraBD = CInt(Grado.Item("IdManguera"))
                            OGrado.PrecioNivel1 = CDec(Grado.Item("Precio"))
                            OGrado.PrecioNivel2 = CDec(Grado.Item("PrecioAuxiliar"))
                            ORed.ListaGrados.Add(OGrado)
                        Next
                        LogCategorias.Clear()
                        LogCategorias.Agregar("LogueoSurtidores")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Fecha", Now.ToString)
                        Fabrica.LogIt.Loguear("Se agrega a la lista para enviar al protocolo", LogPropiedades, LogCategorias)

                        ListaRedSurtidor.Add(ORed.Cara, ORed)
                    Next

                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    Fabrica.LogIt.Loguear("Antes de Cargar por asembly", LogPropiedades, LogCategorias)

                    'OProtocolo = Activator.CreateInstance(OTipo, Puerto, ListaRedSurtidor, Eco, True) //20130809 11:15 AM|El Ultimo parametro "True", no es recibido en el contructor del protocolo
                    'OProtocolo = Activator.CreateInstance(OTipo, Puerto, ListaRedSurtidor, Eco)

                    'Se valida el tipo de comunicacion del protocolo 1=RS232, 2=TCP/IP, 'Por defecto se manejará RS232
                    Dim tipoComunicacion As Integer = Fabrica.tipoComunicacionProtocolo.RS232
                    Dim direccionIp As String = String.Empty
                    Dim puertoTCP As String = String.Empty
                    Dim esTCPIP As Boolean

                    If Not String.IsNullOrEmpty(Red.Item("IdTipoComunicacion").ToString()) Then
                        If Red.Item("IdTipoComunicacion").ToString() = Fabrica.tipoComunicacionProtocolo.TCPIP Then
                            tipoComunicacion = Fabrica.tipoComunicacionProtocolo.TCPIP
                            direccionIp = Red.Item("Ip").ToString()
                            puertoTCP = Red.Item("PuertoTcp").ToString()
                            esTCPIP = True
                        End If
                    End If

                    If tipoComunicacion = Fabrica.tipoComunicacionProtocolo.RS232 Then
                        OProtocolo = Activator.CreateInstance(OTipo, Puerto, ListaRedSurtidor, Eco)
                    Else
                        OProtocolo = Activator.CreateInstance(OTipo, esTCPIP, direccionIp, puertoTCP, ListaRedSurtidor, Eco)
                    End If



                    AddHandler OProtocolo.LecturaTurnoAbierto, AddressOf oEventos_LecturaTurnoAbierto
                    AddHandler OProtocolo.LecturaTurnoCerrado, AddressOf oEventos_LecturaTurnoCerrado
                    AddHandler OProtocolo.AutorizacionRequerida, AddressOf oEventos_AutorizacionRequerida
                    AddHandler OProtocolo.LecturaInicialVenta, AddressOf oEventos_LecturaInicialVenta
                    AddHandler OProtocolo.VentaFinalizada, AddressOf oEventos_VentaFinalizada
                    AddHandler OProtocolo.CancelarProcesarTurno, AddressOf oEventos_CancelarProcesarTurno
                    AddHandler OProtocolo.CaraEnReposo, AddressOf oEventos_CaraEnReposo
                    AddHandler OProtocolo.ExcepcionOcurrida, AddressOf oEventos_ExcepcionProtocolo
                    AddHandler OProtocolo.VentaInterrumpidaEnCero, AddressOf OEventos_VentaInterrumpidaEnCero
                    AddHandler OProtocolo.CambioPrecioFallido, AddressOf OEventos_CambioPrecioFallido
                    AddHandler OProtocolo.VentaParcial, AddressOf oEventos_VentaParcial
                    AddHandler OProtocolo.CambioMangueraEnVentaGerenciada, AddressOf OEventos_CambioMangueraEnVentaGerenciada
                    AddHandler OProtocolo.NotificarCambioPrecioManguera, AddressOf OEventos_NotificarCambioPrecioManguera


                    'AddHandler Protocolo_
                    Me.ListaSurtidores.Add(OProtocolo)

                    LogCategorias.Clear()
                    LogCategorias.Agregar("LogueoSurtidores")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    Fabrica.LogIt.Loguear("Despues de Cargar por asembly", LogPropiedades, LogCategorias)
                Else
                    Throw New GasolutionsException("No existe el protocolo indicado en la tabla RedSurtidor (" & Red.Item("IdProtocolo").ToString & ")")
                End If
                Protocolo_.Close()
                Protocolo_ = Nothing
            Next
            TipoSurtidores = Nothing
        Catch ex As Data.DataException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As Data.SqlClient.SqlException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As Reflection.TargetParameterCountException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As Reflection.ReflectionTypeLoadException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As Reflection.TargetException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As Reflection.TargetInvocationException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As TypeLoadException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As TypeUnloadedException
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoSurtidores")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Metodo", "Iniciar Surtidores")
            LogPropiedades.Agregar("InnerException", ex.InnerException.Message)
            Fabrica.LogIt.Loguear("Error IniciarSurtidores", LogPropiedades, LogCategorias)
            LogFallas.ReportarError(ex, "IniciarSurtidores", "", "Autorizador")
            Throw ex
        End Try
    End Sub

    Private Sub OEventos_CambioMangueraEnVentaGerenciada(cara As Byte)
        Try

            '*****************************************************************************
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_CambioMangueraEnVentaGerenciada", "Cara: " & cara, "VentaGerencia")
        End Try
    End Sub

#Region "Eventos Protocolo"
    Private Sub oEventos_LecturaTurnoAbierto(lecturas As System.Array)
        Try

            Dim OHelper As New Helper

            For Each Lectura As String In lecturas
                Dim Mangueras() As String = Lectura.Split(CChar("|"))
                Dim IdTurno As Int32 = OHelper.InsertarLecturaInicial(CInt(Mangueras(0)), CDec(Mangueras(1)))
                If IdTurno > 0 Then
                    oEventos_TomaLecturasInicialesFinalizada(IdTurno.ToString())
                End If
            Next
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_LecturaTurnoAbiertoFullStation", "-", "AperturaTurnos")
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_LecturaTurnoAbiertoFullStation", "-", "AperturaTurnos")
        Catch Ex As System.Exception
            LogFallas.ReportarError(Ex, "oEventos_LecturaTurnoAbiertoFullStation", "-", "AperturaTurnos")
        End Try
    End Sub
#End Region


    Private Shared Function ValidarPuertos() As Boolean
        Dim OHelper As New Helper
        Dim Resultado As Boolean = True
        Using ORegistros As IDataReader = OHelper.RecuperarPuertosAsignados
            While ORegistros.Read
                If Not My.Computer.Ports.SerialPortNames.Contains(ORegistros("Puerto").ToString()) Then
                    My.Application.Log.WriteEntry("Puerto Invalido: " & ORegistros("Puerto").ToString())
                    Resultado = False
                End If
            End While
        End Using

        OHelper = Nothing
        Return Resultado

    End Function

    'Listo Implementacion Para FullStation
    Private Shared Function RetornarTipoValidacion() As Helper.ETipoValidacion
        Try
            Dim OHelper As New Helper

            If CBool(OHelper.RecuperarParametro("SoloValidarPorBaseDeDatos")) Then
                If CBool(OHelper.RecuperarParametro("SoloValidarChip")) Then
                    Return Helper.ETipoValidacion.Ambas
                Else
                    Return Helper.ETipoValidacion.BaseDatos
                End If
            Else
                If CBool(OHelper.RecuperarParametro("SoloValidarChip")) Then
                    Return Helper.ETipoValidacion.Chip
                Else
                    'Si las dos son falsas usamos la validacion por bd como defecto
                    Return Helper.ETipoValidacion.BaseDatos
                End If
            End If
        Catch EXBD As Data.DataException
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            My.Application.Log.WriteException(EXSQL)
        Catch EXGeneral As System.Exception
            My.Application.Log.WriteException(EXGeneral)
        End Try
    End Function

    'Listo Implementacion Para FullStation
    Private Function BuscarPreset(ByVal cara As String) As Preset

        Try
            Dim OPreset As Preset
            If ColPreset.ContainsKey(cara) Then
                OPreset = ColPreset(cara)
                ColPreset.Remove(cara)
            Else
                OPreset = New Preset("0", Preset.Tipo.PorValor)
            End If
            Return OPreset
        Catch EXArgumentException As ArgumentException
            LogFallas.ReportarError(EXArgumentException, "BuscarPreset", "Cara: " & cara, "Eventos")
            Throw
        Catch EXGeneral As System.Exception
            LogFallas.ReportarError(EXGeneral, "BuscarPreset", "Cara: " & cara, "Eventos")
            Throw
        End Try
    End Function

    'Listo Implementacion Para FullStation
    Private Function BuscarPlaca(ByVal cara As String) As String

        Try
            Dim Placa As String = ""
            If ColPlacas.ContainsKey(cara) Then
                Placa = ColPlacas(cara)
                'ColPlacas.Remove(cara)
            End If
            Return Placa
        Catch EXArgumentException As ArgumentException
            LogFallas.ReportarError(EXArgumentException, "BuscarPlaca", "Cara: " & cara, "Eventos")
            Throw
        Catch EXGeneral As System.Exception
            LogFallas.ReportarError(EXGeneral, "BuscarPlaca", "Cara: " & cara, "Eventos")
            Throw
        End Try
    End Function

    'Listo Implementacion Para FullStation


    Private Sub LimpiarColeccionesPorCara(ByRef cara As String, Optional ByVal borrarConsumos As Boolean = True)
        Try
            RomEstacion(cara.ToString) = ""

            If LecturasLSIB4.ContainsKey(cara.ToString) Then
                LecturasLSIB4.Remove(cara.ToString)
            End If
            If VentaPrepago.ContainsKey(cara) Then
                VentaPrepago.Remove(cara)
            End If

            If borrarConsumos Then
                If Me.Consumos.ContainsKey(cara.ToString) Then
                    Consumos.Remove(cara.ToString)
                End If
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "LimpiarColeccionesPorCara", "-", "Ventas")
        End Try
    End Sub
#End Region

#Region "Multihilo"

    'Listo Implementacion Para FullStation
    Private Sub Hilo_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            ' No se accesa directamente el BackgroundWorker del formulario, sino una referencia a El
            ' proporcionada por el parametro sender.
            Dim Bw As BackgroundWorker = CType(sender, BackgroundWorker)

            ' Recupero los argumentos
            Dim Args() As String = CType(e.Argument, String())

            ' Inicia la operacion de largo consumo de tiempo
            e.Result = IniciarHilo(Bw, CByte((Args(0))), CType(Args(1), Helper.ETipoValidacion), CType(Args(2), Integer), CInt(Args(4)), CStr(Args(5)), CType(Args(3), Boolean))

            ' Si la operacion es cancelada por el usuario
            ' se establece la propiedad DoWorkEventArgs.Cancel a true.
            If Bw.CancellationPending Then
                e.Cancel = True
            End If
        Catch EXSynchronizationLockException As Threading.SynchronizationLockException
            LogFallas.ReportarError(EXSynchronizationLockException, "Hilo_DoWork", "", "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Venta no autorizada en inicio de Hilo: " & EXSynchronizationLockException.Message, ImpresoraEstacion.CrearImpresora(1))
        Catch EXThreadAbortException As Threading.ThreadAbortException
            LogFallas.ReportarError(EXThreadAbortException, "Hilo_DoWork", "", "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Venta no autorizada en inicio de Hilo: " & EXThreadAbortException.Message, ImpresoraEstacion.CrearImpresora(1))
        Catch EXThreadInterruptedException As Threading.ThreadInterruptedException
            LogFallas.ReportarError(EXThreadInterruptedException, "Hilo_DoWork", "", "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Venta no autorizada en inicio de Hilo: " & EXThreadInterruptedException.Message, ImpresoraEstacion.CrearImpresora(1))
        Catch EXGeneral As System.Exception
            LogFallas.ReportarError(EXGeneral, "Hilo_DoWork", "", "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Venta no autorizada en inicio de Hilo: " & EXGeneral.Message, ImpresoraEstacion.CrearImpresora(1))


        End Try
    End Sub


    'Listo Implementacion Para FullStation
    ' Interpreta la salida de la operacion asincrona
    Private Sub Hilo_RunWorkerCompleted(
    ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled Then
            ' El usuario canelo la operacion
            ' Debo loguear el hecho
            'Por ahora no permito esto
        ElseIf Not (e.Error Is Nothing) Then
            LogFallas.ReportarError(e.Error, "Hilo_RunWorkerCompleted", "", "Ibutton")
            My.Application.Log.WriteException(e.Error)

        Else
            ' La operación termino de forma correcta.
        End If

        'Destruyo el objeto
        Dim Bw As BackgroundWorker = CType(sender, BackgroundWorker)
        Bw.Dispose()
        Bw = Nothing
    End Sub


    Sub Anular_Despacho(cara As Byte)
        Dim Protocolo As iProtocolo

        Try
            For Each Protocolo In ListaSurtidores
                Protocolo.Evento_CancelarVenta(cara)
            Next
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "Anular_Despacho", "", "Turno")
        End Try

    End Sub


    Private Function IniciarHilo(
     ByVal bw As BackgroundWorker,
     ByVal cara As Byte, ByVal tipoAutorizacion As Helper.ETipoValidacion, ByVal idProducto As Integer, ByVal idManguera As Integer, guid As String, Optional ByVal esLecturaChipObligatoria As Boolean = True) As Integer

        Dim OHelper As New Helper
        Dim Result As Integer
        Dim Placa As String = ""
        Dim OPlaca As New InformacionVehiculo
        Dim Credito As Credito = Nothing
        Dim oDataTrack As DatosDataTrack = Nothing
        Dim EsCheque As Boolean = False
        Dim EsCreditoLocal As Boolean = False
        Dim EsCreditoGerenciado As Boolean = False
        Dim EsLecturaChipAutomaticaCredito As Boolean = CBool(OHelper.RecuperarParametro("EsLecturaChipAutomaticaCredito"))
        Dim AplicarVentaCreditoConPlaca As Boolean = CBool(OHelper.RecuperarParametro("AplicarVentaCreditoConPlaca"))
        Dim EsConductorAutorizado As Boolean = True
        Dim Documento As String = ""
        Dim esRom As Boolean
        Dim DatoVehiculo As String = ""
        Dim preciosurtidor As String = "0"


        Try

            If ColDispositivosLSIB4.ContainsKey(cara.ToString) Then

                If esLecturaChipObligatoria Then
                    OPlaca = EsperarDatosChipLectorDti(cara.ToString, esLecturaChipObligatoria)
                ElseIf Not Me.VentaEfectivo.ContainsKey(cara.ToString) Then 'Cuando es una venta de combustible liquido y es credito
                    OPlaca = EsperarDatosChipLectorDti(cara.ToString, esLecturaChipObligatoria)
                Else
                    If Not CBool(OHelper.RecuperarParametro("IdentificarVentasEfectivoConChip")) Then
                        OPlaca = EsperarDatosChipLectorDti(cara.ToString, esLecturaChipObligatoria)
                    Else
                        'IDENTIFICACION VEHICULOS CON GASOLINA
                        OPlaca = EsperarDatosChipLectorDti(cara.ToString, esLecturaChipObligatoria)
                    End If
                End If
            Else


                If Not esLecturaChipObligatoria Then
                    OPlaca = OHelper.ESAutorizado(cara, tipoAutorizacion, True)
                Else
                    OPlaca = OHelper.ESAutorizado(cara, tipoAutorizacion)

                    'Si luego de validar la solicitud, esta es correcta, lanzo el evento
                    If (OPlaca.Placa = vbNullString) Or (String.IsNullOrEmpty(OPlaca.Placa.Trim)) Then
                        Throw New System.Exception("Los datos del chip en la cara " & cara & " son invalidos")
                    End If
                End If

            End If

            LogCategorias.Clear()
            LogCategorias.Agregar("Seguir")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Rom", OPlaca.Rom)
            LogPropiedades.Agregar("Placa", OPlaca.Placa)
            LogPropiedades.Agregar("Fecha", OPlaca.Fecha)
            LogPropiedades.Agregar("FechaConversion", OPlaca.FechaConversion)
            LogPropiedades.Agregar("FechaProximoMantenimiento", OPlaca.FechaProximoMantenimiento)
            POSstation.Fabrica.LogIt.Loguear("Inciar Hilo: Antes de datatrack", LogPropiedades, LogCategorias)

            'TRAER LOS DATOS DATATRACK
            Dim AplicaDataTrack As Boolean
            Dim sUser = OHelper.RecuperarParametro("UsuarioDataTrack")
            Dim sPass = OHelper.RecuperarParametro("PasswordDataTrack")
            Dim oReader As System.Data.SqlClient.SqlDataReader

            oReader = OHelper.RecuperarVehiculoLocalPorIdentificador(OPlaca.Rom)
            If oReader.Read() Then
                AplicaDataTrack = oReader("AplicaDataTrack")
                OPlaca.Placa = oReader("Placa")
            End If
            oReader.Close()

            If AplicaDataTrack Then
                oDataTrack = ServerServices.CDCServices.RecuperarKilometrajeNivel(sUser, sPass, OPlaca.Placa)
                If oDataTrack.EsProcesado Then
                    If DataTrack.ContainsKey(cara) Then
                        DataTrack.Remove(cara)
                    End If
                    DataTrack.Add(cara, oDataTrack)
                Else
                    If DataTrack.ContainsKey(cara) Then
                        DataTrack.Remove(cara)
                    End If
                End If
            End If

            preciosurtidor = OHelper.RecuperarPrecioProductoMangueraCliente(idProducto, idManguera, OPlaca.Rom).ToString("N")

            Try
                If FechasEstacion.ContainsKey(cara) Then
                    FechasEstacion(cara) = OPlaca.Fecha
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "IniciarHilo-FechaConversion", "Cara: " & cara & " , TipoValidacion: " & tipoAutorizacion, "IniciarHilo")
            End Try



            Dim OPreset As Preset = BuscarPreset(CStr(cara))


            If OHelper.ExisteManejoCarroTanque(cara) Then
                ''Envio la predeterminacion por volumen al protocolo MR3 
                If OPreset.Valor <> 0 Then
                    Dim ValorReal As String = Me.Predeterminar(cara, OPreset.Valor, OPreset.TipoPreset, idProducto)
                    OPreset.Valor = ValorReal
                    ListaProtocolos_PredeterminarMR3(cara, OPreset.Valor, 1)
                    OPreset.Valor = "0"
                End If
            End If

            '----- Agregado para realizar la validacion de Autorizacion Por conductor ----

            Try

                ' Me.VentasPorConductor.Add(cara.ToString, "1098")

                If Convert.ToBoolean(OHelper.RecuperarParametro("AutorizarVentaPorConductor")) Then
                    If Me.VentasPorConductor.ContainsKey(cara.ToString) Then
                        Documento = VentasPorConductor.Item(cara.ToString())
                        If esLecturaChipObligatoria Then
                            DatoVehiculo = OPlaca.Placa
                            esRom = False
                        Else
                            DatoVehiculo = OPlaca.Rom
                            esRom = True
                        End If
                        EsConductorAutorizado = Convert.ToBoolean(OHelper.EsConductorAutorizado(DatoVehiculo, Convert.ToInt16(cara), Documento, esRom))
                    Else
                        Throw New System.Exception("No hay datos del conductor para su verificación. Por favor ingrese a la ARM y digite el Documento del Conductor y la Cara para poder autorizar la venta")
                    End If
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "IniciarHilo-Validadcion de Conductor", "Cara: " & cara & " , TipoValidacion: " & tipoAutorizacion, "IniciarHilo")
                Throw ex
            End Try
            '-----------------------------------------------------------------------------



            If OHelper.RecuperarParametro("AutorizarVentaLiquidoConChip") Then
                Dim existeIdentificador As Boolean = CBool(OHelper.ExisteIdentificadorLocal(OPlaca.Rom))
                If existeIdentificador = False And esLecturaChipObligatoria = False Then
                    Throw New System.Exception("Venta No Autorizada, El Rom:" + OPlaca.Rom + " No existe en la Base de Datos.")
                End If
            End If



            If Not VentasCheques.ContainsKey(cara.ToString()) Then
                EsCreditoLocal = False
                If AplicarVentaCreditoConPlaca Then
                    If ColPlacas.ContainsKey(cara.ToString()) Then
                        EsCreditoLocal = OHelper.ValidarSiVehiculoEsCredito(ColPlacas(cara.ToString()))
                    Else
                        EsCreditoLocal = OHelper.ValidarSiVehiculoEsCredito(OPlaca.Rom)
                    End If
                Else
                    If Not OHelper.EsLecturaChipObligatoria(idProducto) Then
                        EsCreditoLocal = OHelper.ValidarSiVehiculoEsCredito(OPlaca.Rom)
                    End If
                End If
            End If

            If EsCreditoLocal Then
                Dim OCredito As New CreditoFullstation
                If AplicarVentaCreditoConPlaca Then
                    If ColPlacas.ContainsKey(cara.ToString()) Then
                        OCredito.TipoIdentificacion = TipoIdentificadorVehiculo.PLACA
                        OCredito.Documento = ColPlacas(cara.ToString())
                    Else
                        OCredito.TipoIdentificacion = TipoIdentificadorVehiculo.CHIP
                        OCredito.Documento = OPlaca.Rom

                        If CreditosEstacion.ContainsKey(cara.ToString()) Then
                            OCredito.ValorPredeterminado = CreditosEstacion(cara.ToString()).ValorPredeterminado.ToString()
                        End If
                    End If
                Else
                    OCredito.TipoIdentificacion = TipoIdentificadorVehiculo.CHIP
                    OCredito.Documento = OPlaca.Rom

                    If CreditosEstacion.ContainsKey(cara.ToString()) Then
                        OCredito.ValorPredeterminado = CreditosEstacion(cara.ToString()).ValorPredeterminado.ToString()
                        OCredito.NroAutorizacionManual = CreditosEstacion(cara.ToString()).NroAutorizacionManual
                    End If
                End If

                If CreditosEstacion.ContainsKey(cara) Then
                    CreditosEstacion.Remove(cara)
                End If
                CreditosEstacion.Add(cara.ToString, OCredito)
            End If

            'Recuperando el precio que actualmente tiene la manguera con el fin de que se calcule el incremento o descuento según precio de venta recuperado *****************

            Dim odatos As New Helper
            Dim Validacion As Boolean = CBool(odatos.RecuperarParametro("AplicaCreditoConPlacaSecundaria"))
            'chip

            ''victor
            If Validacion Then
                Dim OCredito As New CreditoFullstation
                Dim dtsPlacas As New DataSet
                If CreditosEstacion.ContainsKey(cara) Then
                    OCredito = CreditosEstacion(cara)
                    If OCredito.NroAutorizacionManual <> String.Empty Then
                        dtsPlacas = odatos.RecuperarIdentificadorLocalPorIdPlaca2(CStr(OPlaca.Rom), CStr(OCredito.NroAutorizacionManual))
                        If dtsPlacas.Tables(0).Rows.Count <= 0 Then
                            Throw New System.Exception("No tiene autorizacion")
                        End If
                    End If
                End If
            End If




            '*****************************************************************************************************************************************************************
            If Me.DatosMenoCash.ContainsKey(cara.ToString()) Then
                Dim Kilometraje As Int64 = 0
                If KilometrajesEstacion.ContainsKey(cara.ToString()) Then
                    Kilometraje = Int64.Parse(KilometrajesEstacion.Item(cara.ToString()).ToString())
                End If
                AutorizarVentaMenoCash(cara.ToString(), idProducto, Kilometraje, preciosurtidor, idManguera, OPlaca.Rom, OPreset)
            Else
                If Me.CreditosEstacion.ContainsKey(cara.ToString) Then
                    If esLecturaChipObligatoria Then
                        ValidarConsumoGas(cara, OPlaca.Fecha, OPlaca.Placa, OPlaca.Rom)
                        Placa = OPlaca.Placa
                    Else
                        If AplicarVentaCreditoConPlaca Then
                            If Not ColPlacas.ContainsKey(cara.ToString()) Then
                                ValidarConsumoCombustible(cara, OPlaca.Rom)
                            End If
                        Else
                            ValidarConsumoCombustible(cara, OPlaca.Rom)
                        End If

                    End If

                    If OHelper.ValidarSiVehiculoEsCreditoGerenciado(OPlaca.Rom) Then
                        AutorizarVentaCreditoCRMStation(cara, idProducto, OPlaca.Rom, CreditosEstacion(cara.ToString()).TipoIdentificacion, OPreset, CreditosEstacion(cara.ToString()).RUTconductor, guid)

                    Else

                        'Este metodo aplicar solo en ventas credito locales
                        If AplicarVentaCreditoConPlaca Then
                            If ColPlacas.ContainsKey(cara.ToString()) Then
                                AutorizarVentaCredito(esLecturaChipObligatoria, cara, idProducto, idManguera, ColPlacas(cara.ToString()), TipoIdentificadorVehiculo.PLACA, OPreset, guid)
                            Else
                                AutorizarVentaCredito(esLecturaChipObligatoria, cara, idProducto, idManguera, OPlaca.Rom, TipoIdentificadorVehiculo.CHIP, OPreset, guid)
                            End If
                        Else
                            AutorizarVentaCredito(esLecturaChipObligatoria, cara, idProducto, idManguera, OPlaca.Rom, TipoIdentificadorVehiculo.CHIP, OPreset, guid)
                        End If

                    End If

                ElseIf VentasCheques.ContainsKey(cara.ToString()) Then
                    Dim placatemporal As String = ""
                    Credito = VentasCheques.Item(cara.ToString())
                    If Credito.EsEfectivo Then
                        If Credito.EsClienteIdentificado Then
                            If Credito.TipoIdentificacion = TipoIdentificador.CHIP Then
                                ' OPlaca = OHelper.ESAutorizado(cara, tipoAutorizacion, True)
                                placatemporal = OHelper.RecuperarPlacaVehiculoPorROM(OPlaca.Rom, True)
                                ValidarConsumoCombustible(cara, OPlaca.Rom)
                                Credito.FormaPagoContado.Valor = OHelper.RecuperarValorChequePorPlaca(placatemporal, Credito.FormaPagoContado.NumeroAutorizacion)
                                OPreset = New Preset(Credito.FormaPagoContado.Valor.ToString, Preset.Tipo.PorValor)
                                oEventos_VentaAutorizada(cara, preciosurtidor, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                            End If
                        End If
                    End If

                ElseIf CreditosTerpel.ContainsKey(cara.ToString()) Then
                    AutorizarVentaCDCTerpel(cara, preciosurtidor, OPlaca.Rom, OPreset, guid)
                Else
                    If esLecturaChipObligatoria And OHelper.RecuperarParametro("AutorizarVentaLiquidoConChip") = False Then
                        ValidarConsumoGas(cara, OPlaca.Fecha, OPlaca.Placa, OPlaca.Rom)
                        RomEstacion(cara.ToString) = OPlaca.Rom
                        FechasEstacion(cara.ToString) = OPlaca.FechaProximoMantenimiento
                        oEventos_VentaAutorizada(cara, preciosurtidor, OPreset.Valor, CByte(OPreset.TipoPreset), OPlaca.Placa, idManguera, False, guid)
                    Else
                        If CBool(OHelper.RecuperarParametro("IdentificarVentasEfectivoConChip")) Then
                            Placa = BuscarPlaca(cara.ToString)
                            RomEstacion(cara.ToString) = OPlaca.Rom
                            FechasEstacion(cara.ToString) = "01/01/1900"

                            If Not esLecturaChipObligatoria Then
                                OHelper.ValidarChipEmpleado(OPlaca.Rom, cara.ToString)
                            End If

                            oEventos_VentaAutorizada(cara, preciosurtidor, OPreset.Valor, CByte(OPreset.TipoPreset), Placa, idManguera, False, guid)

                            Me.VentaEfectivo.Remove(cara.ToString)
                        Else
                            Placa = BuscarPlaca(cara.ToString)
                            RomEstacion(cara.ToString) = OPlaca.Rom
                            FechasEstacion(cara.ToString) = "01/01/1900"

                            oEventos_VentaAutorizada(cara, preciosurtidor, OPreset.Valor, CByte(OPreset.TipoPreset), Placa, idManguera, False, guid)

                            Me.VentaEfectivo.Remove(cara.ToString)
                        End If
                    End If
                End If

            End If



            CarasEstacion(cara.ToString) = False
        Catch EXBD As Data.DataException
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False
            If Me.VentaEfectivo.ContainsKey(cara.ToString) Then
                Me.VentaEfectivo.Remove(cara.ToString)
            End If

            If Me.VentasPorConductor.ContainsKey(cara.ToString) Then
                Me.VentasPorConductor.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If
            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If
            ListaProtocolos_CancelarVenta(cara)
            LimpiarColeccionesPorCara(cara)
            OHelper.InsertarAutorizacionFallidaLogueo(cara, "", "", "", "", "", "TipoValidacion: " & tipoAutorizacion & " (" & EXBD.Message.ToString() & ")", "")

            LogFallas.ReportarError(EXBD, "IniciarHilo", "Cara: " & cara & " , TipoValidacion: " & tipoAutorizacion, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Cara: " & cara & " Venta no Autorizada " & EXBD.Message, ImpresoraEstacion.CrearImpresora(cara))
            Me.Anular_Despacho(cara)
        Catch EXSQL As Data.SqlClient.SqlException
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False

            If Me.VentaEfectivo.ContainsKey(cara.ToString) Then
                Me.VentaEfectivo.Remove(cara.ToString)
            End If

            LimpiarColeccionesPorCara(cara)
            If Me.VentasPorConductor.ContainsKey(cara.ToString) Then
                Me.VentasPorConductor.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If
            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If

            ListaProtocolos_CancelarVenta(cara)

            OHelper.InsertarAutorizacionFallidaLogueo(cara, "", "", "", "", "", "TipoValidacion: " & tipoAutorizacion & " (" & EXSQL.Message.ToString() & ")", "")

            LogFallas.ReportarError(EXSQL, "IniciarHilo", "Cara: " & cara & " , TipoValidacion: " & tipoAutorizacion, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Cara: " & cara & " Venta no Autorizada " & EXSQL.Message, ImpresoraEstacion.CrearImpresora(cara))
            Me.Anular_Despacho(cara)
        Catch EXGGas As GasolutionsException
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False
            If Me.VentaEfectivo.ContainsKey(cara.ToString) Then
                Me.VentaEfectivo.Remove(cara.ToString)
            End If
            LimpiarColeccionesPorCara(cara)
            If Me.VentasPorConductor.ContainsKey(cara.ToString) Then
                Me.VentasPorConductor.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If

            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If
            ListaProtocolos_CancelarVenta(cara)

            OHelper.InsertarAutorizacionFallidaLogueo(cara, "", "", "", "", "", "TipoValidacion: " & tipoAutorizacion & " (" & EXGGas.Message.ToString() & ")", "")

            LogFallas.ReportarError(EXGGas, "IniciarHilo", "Cara: " & cara & " , TipoValidacion: " & tipoAutorizacion, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Cara: " & cara & " , Venta no Autorizada: " & EXGGas.Message, ImpresoraEstacion.CrearImpresora(cara))
            Me.Anular_Despacho(cara)
        Catch EXGeneral As System.Exception
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False
            If Me.VentaEfectivo.ContainsKey(cara.ToString) Then
                Me.VentaEfectivo.Remove(cara.ToString)
            End If
            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If
            If Me.VentasPorConductor.ContainsKey(cara.ToString) Then
                Me.VentasPorConductor.Remove(cara.ToString)
            End If
            LimpiarColeccionesPorCara(cara)
            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If

            ListaProtocolos_CancelarVenta(cara)

            LogFallas.ReportarError(EXGeneral, "IniciarHilo", "Cara: " & cara & " , TipoValidacion: " & tipoAutorizacion, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion("Cara: " & cara & " Venta no Autorizada: " & EXGeneral.Message, ImpresoraEstacion.CrearImpresora(cara))
            Me.Anular_Despacho(cara)
        End Try

        Return Result
    End Function

    Private Function AutorizarVentaMenoCash(ByVal Cara As String, ByVal idProducto As Int32, ByVal Kilometraje As Int64, ByVal preciosurtidor As Double, ByVal idManguera As Int32, ByVal Rom As String, ByVal OPreset As Preset)



    End Function
    Private Function AutorizarVentaCDCTerpel(ByVal Cara As Int16, ByVal PrecioPreducto As Decimal, ByVal Identificacion As String, ByVal OPreset As Preset, guid As String) As Boolean
        Dim OHelper As New Helper
        Dim EsAutorizado As Boolean
        Dim RespuestaCDCTerpel As RespuestaAutorizacionVentaTerpel
        Dim kilometraje As String = ""
        Dim idProducto As Integer = 0
        Try


            LogCategorias.Clear()
            LogCategorias.Agregar("AutorizarVentaTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Cara", Cara)
            POSstation.Fabrica.LogIt.Loguear("Inicio de funcion gerenciamiento terpel: ", LogPropiedades, LogCategorias)

            LogCategorias.Clear()
            LogCategorias.Agregar("AutorizarVentaTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Cara", Cara)
            LogPropiedades.Agregar("Precio Producto", PrecioPreducto)
            LogPropiedades.Agregar("Identificacion", Identificacion)
            LogPropiedades.Agregar("Tipo Predeterminacion", IIf(OPreset.TipoPreset = Preset.Tipo.PorValor, "Valor", "Volumen"))
            LogPropiedades.Agregar("Valor Predeterminacion", OPreset.Valor)
            POSstation.Fabrica.LogIt.Loguear("Iniciar gerenciamiento terpel: ", LogPropiedades, LogCategorias)

            kilometraje = CreditosTerpel.Item(Cara.ToString()).Kilometraje
            idProducto = CInt(CreditosTerpel.Item(Cara.ToString()).IdProducto)


            RespuestaCDCTerpel = ServerServices.CDCTerpelComunicacion.AutorizarVentaTerpelCDC _
                (OHelper.RecuperarCodigoPCCSurtidorPorCara(Cara), idProducto, PrecioPreducto, kilometraje, Identificacion)

            If Not RespuestaCDCTerpel Is Nothing Then
                If RespuestaCDCTerpel.Procesado = True Then
                    Dim OCredito As New CreditoFullstation
                    OCredito.Autorizacion = RespuestaCDCTerpel.IdAprobacion
                    OCredito.FormaPago = RespuestaCDCTerpel.IdFormaPago
                    OCredito.SaldoDisponible = RespuestaCDCTerpel.SaldoCliente
                    OCredito.Placa = RespuestaCDCTerpel.PlacaVehiculo
                    OCredito.Iva = RespuestaCDCTerpel.ValorIvaImplicito
                    OCredito.Kilometraje = kilometraje
                    OCredito.IdProducto = idProducto
                    OCredito.Placa = RespuestaCDCTerpel.PlacaVehiculo
                    OCredito.EsEfectivo = False
                    RomEstacion(Cara) = Identificacion

                    If CreditosTerpel.ContainsKey(Cara) Then
                        CreditosTerpel.Remove(Cara)
                    End If
                    CreditosTerpel.Add(Cara, OCredito)

                    If OPreset.TipoPreset = Preset.Tipo.PorValor And OPreset.Valor > 0 Then
                        If OPreset.Valor > RespuestaCDCTerpel.CupoMaximoDinero Then
                            OPreset.Valor = RespuestaCDCTerpel.CupoMaximoDinero
                        End If
                    ElseIf OPreset.TipoPreset = Preset.Tipo.PorVolumen And OPreset.Valor > 0 Then
                        If OPreset.Valor > RespuestaCDCTerpel.CupoMaximoVolumen Then
                            OPreset.Valor = RespuestaCDCTerpel.CupoMaximoVolumen
                        End If
                    Else
                        OPreset.Valor = RespuestaCDCTerpel.CupoMaximoDinero
                        OPreset.TipoPreset = Preset.Tipo.PorValor
                    End If
                    oEventos_VentaAutorizada(Cara, OHelper.RecuperarPrecioPorCliente(OCredito.Placa).ToString("N"),
                                             CDec(OPreset.Valor).ToString("N2"), OPreset.TipoPreset, OCredito.Placa, -1, True, guid)
                    EsAutorizado = True
                Else
                    RomEstacion(Cara.ToString) = ""
                    If CreditosTerpel.ContainsKey(Cara.ToString) Then
                        CreditosTerpel.Remove(Cara.ToString)
                    End If

                    ImpresoraRecibo.ImprimirErrorCreditoConsumo(ImpresoraEstacion.CrearImpresora(Cara), "", Cara.ToString, RespuestaCDCTerpel.MensajeError)
                    EsAutorizado = False
                End If
            Else
                LogCategorias.Clear()
                LogCategorias.Agregar("AutorizarVentaTerpelCDC")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Fecha", Now.ToString())
                LogPropiedades.Agregar("Cara", Cara)
                LogPropiedades.Agregar("PrecioPreducto", PrecioPreducto)
                LogPropiedades.Agregar("Identificacion", Identificacion)
                LogPropiedades.Agregar("Tipo Predeterminacion", IIf(OPreset.TipoPreset = Preset.Tipo.PorValor, "Valor", "Volumen"))
                LogPropiedades.Agregar("Valor Predeterminacion", OPreset.Valor)
                POSstation.Fabrica.LogIt.Loguear("Falla de comunicación en gerenciamiento terpel: ", LogPropiedades, LogCategorias)

                RomEstacion(Cara.ToString) = ""
                If CreditosTerpel.ContainsKey(Cara.ToString) Then
                    CreditosTerpel.Remove(Cara.ToString)
                End If

                ImpresoraRecibo.ImprimirErrorCreditoConsumo(ImpresoraEstacion.CrearImpresora(Cara), "", Cara.ToString)
                EsAutorizado = False
            End If
        Catch ex As System.Exception
            EsAutorizado = False
            LogFallas.ReportarError(ex, "AutorizarVentaCDCTerpel", "Cara: " & Cara & ", PrecioPreducto: " & PrecioPreducto & ", Identificacion: " & Identificacion, "Autorizacion CDC Terpel")
            Throw
        End Try

        Return EsAutorizado
    End Function

    Public Sub AutorizarVentaCredito(ByVal esLecturaChipObligatoria As Boolean, ByVal cara As Byte, ByVal idProducto As Int32, ByVal idManguera As Int16, ByVal Identificador As String, ByVal TipoIdentificador As TipoIdentificadorVehiculo, ByRef OPreset As Preset, guid As String, Optional esAutorizado As Boolean = True)
        Dim OHelper As New Helper
        Dim Kilometraje As String = "0"
        Dim SaldoBd As String = ""
        Dim Placa As String = ""
        Dim preciosurtidor As String = "0"
        Dim PrecioProducto As Decimal = 0
        If KilometrajesEstacion.ContainsKey(cara.ToString) Then
            Kilometraje = KilometrajesEstacion(cara.ToString)
        End If

        OHelper.ValidaRestricciones(Identificador, TipoIdentificador, idProducto, Kilometraje)
        Dim DataSaldoCredito As IDataReader = OHelper.RecuperarCreditoPorIdentificador(Identificador, TipoIdentificador, idProducto, OPreset.Valor, cara)
        If DataSaldoCredito.Read Then
            Placa = DataSaldoCredito.Item("Placa").ToString
            PrecioProducto = DataSaldoCredito.Item("PrecioProducto").ToString
            If (CBool(DataSaldoCredito.Item("EsCredito").ToString)) Then
                If Not (DataSaldoCredito.Item("SaldoCredito") Is System.DBNull.Value) Then
                    OPreset.Valor = DataSaldoCredito.Item("SaldoCredito").ToString
                    SaldoBd = DataSaldoCredito.Item("SaldoCredito").ToString
                    If CBool(DataSaldoCredito.Item("TipoPreset")) Then
                        OPreset.TipoPreset = Preset.Tipo.PorVolumen
                    Else
                        OPreset.TipoPreset = Preset.Tipo.PorValor
                    End If
                End If
            End If
        End If
        DataSaldoCredito.Close()
        DataSaldoCredito = Nothing


        LogCategorias.Clear()
        LogCategorias.Agregar("Credito")
        LogPropiedades.Clear()
        LogPropiedades.Agregar("Fecha", Now.ToString())
        LogPropiedades.Agregar("Cara", cara)
        LogPropiedades.Agregar("PrecioPreducto", PrecioProducto)
        LogPropiedades.Agregar("Identificacion", Identificador)
        LogPropiedades.Agregar("Placa", Placa)
        LogPropiedades.Agregar("Tipo Predeterminacion", IIf(OPreset.TipoPreset = Preset.Tipo.PorValor, "Valor", "Volumen"))
        LogPropiedades.Agregar("Saldo Credito", SaldoBd)
        LogPropiedades.Agregar("Predeterminacion Terminal", CreditosEstacion(cara.ToString()).ValorPredeterminado)
        POSstation.Fabrica.LogIt.Loguear("Autorizar credito Sauce: antes de validar la predeterminacion ", LogPropiedades, LogCategorias)

        If OPreset.TipoPreset = Preset.Tipo.PorValor And CInt(OPreset.Valor) > 0 Then
            If CInt(OPreset.Valor) > CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado) And CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado) > 0 Then
                OPreset.Valor = CreditosEstacion(cara.ToString()).ValorPredeterminado
            End If
        ElseIf OPreset.TipoPreset = Preset.Tipo.PorVolumen And CInt(OPreset.Valor) > 0 Then
            If CInt(OPreset.Valor) * CInt(PrecioProducto) > CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado) And CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado) > 0 Then
                OPreset.Valor = CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado)
                OPreset.TipoPreset = Preset.Tipo.PorValor
            Else
                OPreset.Valor = CInt(OPreset.Valor * PrecioProducto).ToString()
                OPreset.TipoPreset = Preset.Tipo.PorValor
            End If
        Else
            OPreset.Valor = CreditosEstacion(cara.ToString()).ValorPredeterminado
            OPreset.TipoPreset = Preset.Tipo.PorValor
        End If



        If (CInt(OPreset.Valor) >= CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado)) And CInt(CreditosEstacion(cara.ToString()).ValorPredeterminado) > 0 And OPreset.TipoPreset = Preset.Tipo.PorValor Then
            OPreset.Valor = CreditosEstacion(cara.ToString()).ValorPredeterminado
            OPreset.TipoPreset = Preset.Tipo.PorValor
        End If

        LogCategorias.Clear()
        LogCategorias.Agregar("Credito")
        LogPropiedades.Clear()
        LogPropiedades.Agregar("Fecha", Now.ToString())
        LogPropiedades.Agregar("Cara", cara)
        LogPropiedades.Agregar("PrecioPreducto", PrecioProducto)
        LogPropiedades.Agregar("Identificacion", Identificador)
        LogPropiedades.Agregar("Placa", Placa)
        LogPropiedades.Agregar("Tipo Predeterminacion", IIf(OPreset.TipoPreset = Preset.Tipo.PorValor, "Valor", "Volumen"))
        LogPropiedades.Agregar("Valor Predeterminado protocolo", OPreset.Valor)
        POSstation.Fabrica.LogIt.Loguear("Autorizar credito Sauce: despues de validar la predeterminacion ", LogPropiedades, LogCategorias)

        If (OHelper.ExisteManejoCarroTanque(cara) And esAutorizado) Or Not OHelper.ExisteManejoCarroTanque(cara) Then
            preciosurtidor = OHelper.RecuperarPrecioProductoMangueraCliente(idProducto, idManguera, Identificador).ToString("N")
            oEventos_VentaAutorizada(cara, preciosurtidor, OPreset.Valor, CByte(OPreset.TipoPreset), Placa, idManguera, True, guid)
            OPreset.Valor = 0
        End If
    End Sub





    Public Sub ValidarConsumoCombustible(ByVal cara As Byte, ByVal Rom As String)
        Dim OHelper As New Helper
        Dim NoTanques As Int16 = 0
        Dim VentasEnCurso As Int16 = 0

        If Utilidades.ValidarLetrasYNumeros(Rom) Then
            ' Si no es lectura de chipobligatoria entonces es combustible liquido
            ' por ende debo obtener el número de tanques que posee el vehiculo instalado
            ' para determinar el numero de tanqueos simultaneos a permitirse
            NoTanques = OHelper.ValidarTanqueoSimultaneo(Rom)

            'VERIFICANDO QUE NO EXISTA OTRA VENTA EN CURSO CON EL ROM A AUTORIZAR
            For Each KeyCara As String In RomEstacion.Keys
                If RomEstacion.Item(KeyCara).Equals(Rom) Then
                    VentasEnCurso += 1
                    If VentasEnCurso >= NoTanques Then
                        CarasEstacion(cara.ToString) = False
                        Throw New GasolutionsException("No es posible autorizar una venta mas para el vehiculo superaria el numero de ventas en curso permitidas")
                    End If
                End If
            Next

            RomEstacion(cara.ToString) = Rom
        Else
            CarasEstacion(cara.ToString) = False
            Throw New GasolutionsException("El rom es invalido")
        End If
    End Sub

    Public Sub ValidarConsumoGas(ByVal cara As Byte, ByVal fechaProximoMantenimiento As String, ByVal placa As String, ByVal Rom As String)
        Dim OHelper As New Helper
        Dim Lector As IDataReader = Nothing
        'Si luego de validar la solicitud, esta es correcta, lanzo el evento
        If Utilidades.ValidarLetrasYNumeros(placa) And Utilidades.ValidarLetrasYNumeros(Rom) Then
            FechasEstacion(cara.ToString) = fechaProximoMantenimiento
            'VERIFICANDO QUE NO EXISTA OTRA VENTA EN CURSO CON EL ROM A AUTORIZAR
            If Not RomEstacion.ContainsValue(Rom) Then
                RomEstacion(cara.ToString) = Rom
            Else
                'For Each KeyCara As String In RomEstacion.Keys
                '    If RomEstacion.Item(KeyCara).Equals(Rom) Then
                '        'LA CARA YA HA SIDO LIBERADA PARA AUTORIZACIONES POSTERIORES
                '        CarasEstacion(cara.ToString) = False
                '        Throw New GasolutionsException("En la Cara: " & KeyCara & " existe una Venta en curso con este CHIP " & Rom)
                '    End If
                'Next
                Lector = OHelper.ExisteRomEnVentaParcial(Rom)
                Dim mensaje As New System.Text.StringBuilder

                While Lector.Read
                    mensaje.AppendLine("En la Cara: " & Lector.Item("Cara").ToString() & " existe una Venta en curso con este CHIP " & Lector.Item("Rom").ToString())
                End While
                Lector.Close()
                Lector.Dispose()
            End If
        Else
            CarasEstacion(cara.ToString) = False
            Throw New GasolutionsException("La placa o el rom son invalidos")
        End If
    End Sub
#End Region


    '------------------------------------------EVENTOS DE APERTURA Y CIERRE DE TURNOS--------------------------------------------
#Region "Eventos de Apertura y Cierre de Turnos"
    Private Sub Eventos_TurnoAbierto(Datos As DatosTemporalesSauce)
        Dim Service As ServiceSharedEventClient = Nothing
        Dim Surtidores As String, Puerto As String, Precio As System.Array
        Surtidores = ""
        Try
            Dim EnEjecucion As Boolean = False
            EnEjecucion = Process.GetProcessesByName("DisplayStation").Length > 0

            If EnEjecucion Then
                Service = New ServiceSharedEventClient
                Surtidores = Datos.Surtidores
                Puerto = Datos.Puerto
                Precio = Datos.ListaPrecio

                Service.TurnoAbierto(Surtidores, Puerto, Precio)
                If Not Service Is Nothing Then
                    If Service.State = ServiceModel.CommunicationState.Opened Then
                        Service.Close()
                    End If
                End If
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("WCF")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Surtidores", Surtidores)
            Fabrica.LogIt.Loguear("Error al Localizar el EndPoint Eventos_TurnoAbierto: " & ex.Message, LogPropiedades, LogCategorias)
        End Try
    End Sub

    Sub ListaProtocolos_TurnoAbierto(Surtidores As String, PuertoTerminal As String, Precios As System.Array)
        Dim oHelper As New Helper
        Dim Protocolo As iProtocolo
        Try
            For Each Protocolo In ListaSurtidores
                Protocolo.Evento_TurnoAbierto(Surtidores, PuertoTerminal, Precios)
            Next

            Try
                Dim EnEjecucion As Boolean = False
                EnEjecucion = Process.GetProcessesByName("DisplayStation").Length > 0

                If EnEjecucion Then
                    Dim DatosTemporalesAutorizacion As New DatosTemporalesSauce
                    DatosTemporalesAutorizacion.Surtidores = Surtidores
                    DatosTemporalesAutorizacion.Puerto = PuertoTerminal
                    DatosTemporalesAutorizacion.ListaPrecio = Precios
                    Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Eventos_TurnoAbierto), DatosTemporalesAutorizacion)
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "Eventos_TurnoAbierto COMUNICACION WCF", "", "Turno")
                Throw New System.Exception("Error comunicando con el servicio WCF - " + ex.Message)
            End Try
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "Eventos_TurnoAbierto", "", "Turno")
            Throw New System.Exception("Error listando los protocolos - " + ex.Message)
        End Try

    End Sub

    'Listo Implementacion Para FullStation (Pendiente Modificar Evento de Apertura de Turno para Recibir Lista de Precios)
    '    Private Sub oEventos_AperturaTurno(ByRef empleadoPrm As String, ByRef clavePrm As String, ByRef surtidoresPrm As String, ByRef puertoPrm As String) Handles OEventos.AperturaTurno
    Private Sub oEventos_AperturaTurno(empleadoPrm As String, clavePrm As String, surtidoresPrm As String, puertoPrm As String) 'Handles OEventos.AperturaTurno
        Dim OHelper As New Helper
        Try

            Fabrica.gasolutionsHasp.IsHasp()


            Dim DataPrecios As DataSet = OHelper.RecuperarPreciosProductos()
            Dim PrecioGas(DataPrecios.Tables(0).Rows.Count - 1) As String
            Dim indice As Integer = 0
            Dim IdTurno As Int32
            For Each Producto As DataRow In DataPrecios.Tables(0).Rows
                If Not Producto.Item("Precio") Is System.DBNull.Value Then
                    PrecioGas(indice) = Producto.Item("IdProducto").ToString & "|" & Producto.Item("Precio").ToString & "|" & Producto.Item("PrecioAuxiliar").ToString & "|" & Producto.Item("IdManguera").ToString
                Else
                    Throw New DataException("Existen productos a los cuales no se les ha especificado un precio actual")
                End If

                indice = indice + 1
            Next
            DataPrecios = Nothing

            'empleadoPrm = CInt(empleadoPrm).ToString
            IdTurno = OHelper.AbrirTurno(empleadoPrm, clavePrm, surtidoresPrm, CInt(OHelper.RecuperarParametro("DeltaTurno")))
            'OEventos.InformarTurnoAbierto(surtidoresPrm, puertoPrm, PrecioGas)

            Try
                ListaProtocolos_TurnoAbierto(surtidoresPrm, puertoPrm, PrecioGas)
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "oEventos_AperturaTurno", "Empleado: " & empleadoPrm & ", Clave: " & clavePrm & ", Surtidores: " & surtidoresPrm & ", Puerto: " & puertoPrm, "ImpresionTurnos")
                Throw
            End Try

        Catch Ex As GasolutionsHaspException
            OHelper.InsertarTurnoFallidoLogueo(empleadoPrm, clavePrm, "", "LLAVE HASP NO ENCONTRADA Por favor conecte en el puerto USB la llave de verificación de licencia", puertoPrm, "Abrir Turno Trabajo")
            LogFallas.ReportarError(New System.Exception("LLAVE HASP NO ENCONTRADA"), "AperturaTurno", "-", "ImpresionTurnos")
            oEventos_AperturaTurnoFallida("LLAVE HASP NO ENCONTRADA Por favor conecte en el puerto USB la llave de verificación de licencia", puertoPrm)
        Catch EXBD As Data.DataException
            OHelper.InsertarTurnoFallidoLogueo(empleadoPrm, clavePrm, surtidoresPrm, EXBD.Message.ToString(), puertoPrm, "Abrir Turno")
            LogFallas.ReportarError(EXBD, "oEventos_AperturaTurno", "Empleado: " & empleadoPrm & ", Clave: " & clavePrm & ", Surtidores: " & surtidoresPrm & ", Puerto: " & puertoPrm, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(EXBD.Message, puertoPrm)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            OHelper.InsertarTurnoFallidoLogueo(empleadoPrm, clavePrm, surtidoresPrm, EXSQL.Message.ToString(), puertoPrm, "Abrir Turno")
            LogFallas.ReportarError(EXSQL, "oEventos_AperturaTurno", "Empleado: " & empleadoPrm & ", Clave: " & clavePrm & ", Surtidores: " & surtidoresPrm & ", Puerto: " & puertoPrm, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(EXSQL.Message, puertoPrm)
            Throw
        Catch ex As System.Exception
            OHelper.InsertarTurnoFallidoLogueo(empleadoPrm, clavePrm, surtidoresPrm, ex.Message.ToString(), puertoPrm, "Abrir Turno")
            LogFallas.ReportarError(ex, "oEventos_AperturaTurno", "Empleado: " & empleadoPrm & ", Clave: " & clavePrm & ", Surtidores: " & surtidoresPrm & ", Puerto: " & puertoPrm, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(ex.Message, puertoPrm)
            Throw
        Finally

        End Try

    End Sub

    'Listo Implementacion Para FullStation
    Private Sub oEventos_AperturaTurnoFallida(ByRef mensaje As String, ByRef puertoPrm As String)
        ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puertoPrm))
    End Sub

    'Listo Implementacion Para FullStation
    'Private Sub oEventos_CierreTurno(ByRef empleado As String, ByRef clave As String, ByRef puerto As String, ByRef SurtidoresACerrar As String) Handles OEventos.CierreTurno
    Private Sub oEventos_CierreTurno(empleado As String, clave As String, puerto As String, SurtidoresACerrar As String)
        'Try
        '    Dim OHelper As New Helper
        '    Dim Surtidores As String = ""
        '    Dim IdTurno As Int32

        '    empleado = CInt(empleado).ToString
        '    IdTurno = OHelper.CerrarTurno(empleado, clave, Surtidores, SurtidoresACerrar)
        '    OEventos.InformarTurnoCerrado(Surtidores, puerto)
        'Catch EXBD As Data.DataException
        '    LogFallas.ReportarError(EXBD, "oEventos_CierreTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
        '    OEventos.ReportarCierreTurnoFallido(EXBD.Message, puerto)
        'Catch EXSQL As Data.SqlClient.SqlException
        '    LogFallas.ReportarError(EXSQL, "oEventos_CierreTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
        '    OEventos.ReportarCierreTurnoFallido(EXSQL.Message, puerto)
        'Catch ex As System.exception
        '    LogFallas.ReportarError(Ex, "oEventos_CierreTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
        '    OEventos.ReportarCierreTurnoFallido(Ex.Message, puerto)
        'End Try

        Dim OHelper As New Helper
        Try
            Dim Surtidores As String = ""
            empleado = CInt(empleado).ToString

            Dim IDTurno As Int32 = OHelper.EsEmpleadoTurnoApoyo(empleado, clave)

            If IDTurno = -1 Then

                IDTurno = OHelper.CerrarTurno(empleado, clave, Surtidores, SurtidoresACerrar)
                oEventos_TurnoCerrado(Surtidores, puerto)
                '   ImpresoraTurno.ImprimirTurno(IDTurno, ImpresoraEstacion.CrearImpresoraPorTurno(IDTurno))
                Try

                    If Not String.IsNullOrEmpty(SurtidoresACerrar) Then
                        ListaProtocolos_TurnoCerrado(SurtidoresACerrar, puerto)
                    Else
                        ListaProtocolos_TurnoCerrado(Surtidores, puerto)
                    End If


                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "oEventos_AperturaTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Surtidores: " & SurtidoresACerrar & ", Puerto: " & puerto, "ImpresionTurnos")
                    Throw
                End Try
            Else
                ImpresoraTurno.ImprimirTurnoApoyo(IDTurno, New ImpresoraEstacion(puerto), False)
            End If
        Catch EXBD As Data.DataException
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", "System.Exception en Cierre de Turno -" + EXBD.Message.ToString(), puerto, "ImpresionTurnos")
            LogFallas.ReportarError(EXBD, "oEventos_CierreTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
            oEventos_CierreTurnoFallido(EXBD.Message, puerto)
        Catch EXSQL As Data.SqlClient.SqlException
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", "System.Exception en Cierre de Turno -" + EXSQL.Message.ToString(), puerto, "ImpresionTurnos")
            LogFallas.ReportarError(EXSQL, "oEventos_CierreTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
            oEventos_CierreTurnoFallido(EXSQL.Message, puerto)
        Catch ex As System.Exception
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", "System.Exception en Cierre de Turno -" + ex.Message.ToString(), puerto, "ImpresionTurnos")
            LogFallas.ReportarError(ex, "oEventos_CierreTurno", "Empleado: " & empleado & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
            oEventos_CierreTurnoFallido(ex.Message, puerto)
        End Try
    End Sub

    'Listo Implementacion Para FullStation
    Private Sub oEventos_CierreTurnoFallido(ByRef mensajePrm As String, ByRef puertoPrm As String) Handles OEventos.CierreTurnoFallido
        ImpresoraTurno.ImprimirExcepcion(mensajePrm, New ImpresoraEstacion(puertoPrm))
    End Sub


    Sub ListaProtocolos_TurnoCerrado(Surtidores As String, Puerto As String)
        Try
            Dim Protocolo As iProtocolo
            For Each Protocolo In ListaSurtidores
                Protocolo.Evento_TurnoCerrado(Surtidores, Puerto)
            Next
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ListaProtocolos_TurnoCerrado", "", "Turno")
        End Try
    End Sub

#End Region

    '-------------------------------------EVENTOS DE VINCULACION Y DESVINCULACION DE SURTIDORES----------------------------------
#Region "Eventos de Vinculacion y desvinculacion de Surtidores"


    'Listo Implementacion Para FullStation
    Private Sub oEventos_VincularSurtidores(ByRef empleado As String, ByRef clave As String, ByRef surtidores As String, ByRef puerto As String) Handles OEventos.VincularSurtidores
        Try
            Dim OHelper As New Helper
            OHelper.VincularSurtidorTurno(empleado, clave, surtidores)
        Catch EXBD As Data.DataException
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

#End Region

    '----------------------------------EVENTOS DE TOMA DE LECTURAS AL ABRIR Y CERRAR TURNO--------------------------------------
#Region "Eventos de Lectura en Turnos"



    'Listo Implementacion Para FullStation
    'Listo Implementacion Para FullStation
    Private Sub oEventos_TomaLecturasInicialesFinalizada(ByRef turnoPrm As String) Handles OEventos.TomaLecturasInicialesFinalizada
        Dim oHelper As New Helper()
        Try
            ImpresoraRecibo.ImprimirReciboTurno(CInt(turnoPrm), ImpresoraEstacion.CrearImpresoraPorTurno(CInt(turnoPrm)))

            ''AbrirTurno
            If oHelper.RecuperarParametro("AplicaInventarioPorIsla") Then
                Dim Olector As IDataReader = oHelper.RecuperarIslaPorTurno(CInt(turnoPrm))
                While Olector.Read()
                    oHelper.RegistrarInventarioPorTurno(turnoPrm, Olector.Item("IdIsla"), 0)
                End While
                Olector.Close()
                Olector.Dispose()
            End If

            Try
                Dim AplicaAjusteAutomaticoEnTurno As Boolean = CBool(oHelper.RecuperarParametro("AplicaAjusteAutomaticoEnTurno"))
                If AplicaAjusteAutomaticoEnTurno Then
                    OEventos.SolicitarInformarStocksTanquesCierreTurnoServicio(0)
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "oEventos_TomaLecturasInicialesFinalizada-Veeder root", "Turno: " & turnoPrm, "ImpresionTurnos")
            End Try


        Catch EXBD As Data.DataException
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " & turnoPrm & ", (" & EXBD.Message & ")", "", "Abrir Turno")
            LogFallas.ReportarError(EXBD, "oEventos_TomaLecturasInicialesFinalizada", "Turno: " & turnoPrm, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion("Recibo de turno no impreso: " & EXBD.Message, ImpresoraEstacion.CrearImpresoraPorTurno(CInt(turnoPrm)))
        Catch EXSQL As Data.SqlClient.SqlException
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " & turnoPrm & ", (" & EXSQL.Message & ")", "", "Abrir Turno")
            LogFallas.ReportarError(EXSQL, "oEventos_TomaLecturasInicialesFinalizada", "Turno: " & turnoPrm, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion("Recibo de turno no impreso: " & EXSQL.Message, ImpresoraEstacion.CrearImpresoraPorTurno(CInt(turnoPrm)))
        Catch EXFormat As InvalidCastException
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " & turnoPrm & ", (" & EXFormat.Message & ")", "", "Abrir Turno")
            LogFallas.ReportarError(EXFormat, "oEventos_TomaLecturasInicialesFinalizada", "Turno: " & turnoPrm, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion("Recibo de turno no impreso: " & EXFormat.Message, ImpresoraEstacion.CrearImpresoraPorTurno(CInt(turnoPrm)))
        Catch ex As System.Exception
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " & turnoPrm & ", (" & ex.Message & ")", "", "Abrir Turno")
            LogFallas.ReportarError(ex, "oEventos_TomaLecturasInicialesFinalizada", "Turno: " & turnoPrm, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion("Recibo de turno no impreso: " & ex.Message, ImpresoraEstacion.CrearImpresoraPorTurno(CInt(turnoPrm)))
        End Try
    End Sub

    'Listo Implementacion Para FullStation
    Private Sub oEventos_LecturaTurnoCerrado(lecturas As System.Array)
        Dim OHelper As New Helper
        Dim IdTurno As Int32 = 0
        Try


            For Each Lectura As String In lecturas
                Dim Mangueras() As String = Lectura.Split("|")
                IdTurno = OHelper.InsertarLecturaFinal(CInt(Mangueras(0)), CDec(Mangueras(1)))
                If IdTurno > 0 Then
                    oEventos_TomaLecturasFinalesFinalizada(IdTurno.ToString())
                End If
            Next
        Catch EXBD As Data.DataException
            Dim lecturasFinales As String = String.Empty
            If lecturas.Length > 0 Then
                For Each Lectura As String In lecturas
                    Dim Mangueras() As String = Lectura.Split("|")
                    lecturasFinales = lecturasFinales & "IdManguera:" & Mangueras(0) & ", Lectura:" & Mangueras(1) & "|"
                Next
            End If
            OHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno: " & IdTurno.ToString() & ", Lecturas:" & lecturasFinales & " (" & EXBD.Message & ")", "", "Falla al Insertar Lectura Final del Turno")

            LogFallas.ReportarError(EXBD, "oEventos_LecturaTurnoCerrado", "-", "CierreTurnos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            Dim lecturasFinales As String = String.Empty
            If lecturas.Length > 0 Then
                For Each Lectura As String In lecturas
                    Dim Mangueras() As String = Lectura.Split("|")
                    lecturasFinales = lecturasFinales & "IdManguera:" & Mangueras(0) & ", Lectura:" & Mangueras(1) & "|"
                Next
            End If
            OHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno: " & IdTurno.ToString() & ", Lecturas:" & lecturasFinales & " (" & EXSQL.Message & ")", "", "Falla al Insertar Lectura Final del Turno")

            LogFallas.ReportarError(EXSQL, "oEventos_LecturaTurnoCerrado", "-", "CierreTurnos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            Dim lecturasFinales As String = String.Empty
            If lecturas.Length > 0 Then
                For Each Lectura As String In lecturas
                    Dim Mangueras() As String = Lectura.Split("|")
                    lecturasFinales = lecturasFinales & "IdManguera:" & Mangueras(0) & ", Lectura:" & Mangueras(1) & "|"
                Next
            End If
            OHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno: " & IdTurno.ToString() & ", Lecturas:" & lecturasFinales & " (" & ex.Message & ")", "", "Falla al Insertar Lectura Final del Turno")

            LogFallas.ReportarError(ex, "oEventos_LecturaTurnoCerrado", "-", "CierreTurnos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

    'Listo Implementacion Para FullStation
    Private Sub oEventos_TomaLecturasFinalesFinalizada(turnoPrm As String)
        Dim oHelper As New Helper()
        Try

            Try
                If oHelper.RecuperarParametro("AplicaInventarioPorIsla") Then
                    Dim Olector As IDataReader = oHelper.RecuperarIslaPorTurno(CInt(turnoPrm))
                    While Olector.Read()
                        oHelper.RegistrarInventarioPorTurno(turnoPrm, Olector.Item("IdIsla"), 1)
                    End While
                    Olector.Close()
                    Olector.Dispose()
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "oEventos_TomaLecturasFinalesFinalizada-AplicaInventarioPorIsla", "", "oEventos_TomaLecturasFinalesFinalizada")
            End Try


            ImpresoraTurno.ImprimirTurno(CInt(turnoPrm), ImpresoraEstacion.CrearImpresoraPorTurno(CInt(turnoPrm)))
            ''Cerrar turno


        Catch ex As Data.DataException
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " + turnoPrm + " - " + ex.Message, "", "Falla al Imprmir Turno")
            LogFallas.ReportarError(ex, "oEventos_TomaLecturasFinalesFinalizada", "", "oEventos_TomaLecturasFinalesFinalizada")
        Catch ex As Data.SqlClient.SqlException
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " + turnoPrm + " - " + ex.Message, "", "Falla al Imprmir Turno")
            LogFallas.ReportarError(ex, "oEventos_TomaLecturasFinalesFinalizada", "", "oEventos_TomaLecturasFinalesFinalizada")
        Catch ex As InvalidCastException
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " + turnoPrm + " - " + ex.Message, "", "Falla al Imprmir Turno")
            LogFallas.ReportarError(ex, "oEventos_TomaLecturasFinalesFinalizada", "", "oEventos_TomaLecturasFinalesFinalizada")
        Catch ex As System.Exception
            oHelper.InsertarTurnoFallidoLogueo("", "", "", "Id Turno= " + turnoPrm + " - " + ex.Message, "", "Falla al Imprmir Turno")
            LogFallas.ReportarError(ex, "oEventos_TomaLecturasFinalesFinalizada", "", "oEventos_TomaLecturasFinalesFinalizada")
        Finally

        End Try
    End Sub

    'Listo Implementacion Para FullStation
    Private Sub oEventos_InsercionLecturaFinalFallida(ByRef mensaje As String) Handles OEventos.InsercionLecturaFinalFallida
        'Usa la impresora por defecto en la tabla parametrizacion
        ImpresoraTurno.ImprimirExcepcion(mensaje, ImpresoraEstacion.CrearImpresora(-1))
    End Sub

    'Listo Implementacion Para FullStation
    Private Sub oEventos_InsercionLecturaInicialFallida(ByRef mensaje As String) Handles OEventos.InsercionLecturaInicialFallida
        'Usa la impresora por defecto en la tabla parametrizacion
        ImpresoraTurno.ImprimirExcepcion(mensaje, ImpresoraEstacion.CrearImpresora(-1))
    End Sub

#End Region

#Region "Licenciamiento Trial"
    Private Function EstaActivoElTrial() As Boolean
        Dim DiaInicialTrial As Date
        DiaInicialTrial = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SauceGST", "Inicio", Nothing)
        If DiaInicialTrial = Nothing Then
            DiaInicialTrial = Now
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SauceGST", "Inicio", DiaInicialTrial)
        ElseIf (Now - DiaInicialTrial).Days > 31 Then
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SauceGST", "Inicio", "01/01/2000 00:00:01 ")
            Return False
        End If
        Return True
    End Function
#End Region

    '--------------------------------------EVENTOS Y FUNCIONES RELACIONADOS CON UNA VENTA---------------------------------------
#Region "Eventos y Funciones de Venta "

    'Lista Implementacion Para FullStation (PENDIENTE HACER EL METODO PARA MANEJAR LA LECTURA DE CHIP EN LA MR PARA LO DEL CREDITO Y SU VALIDACION)
    Private Sub oEventos_AutorizacionRequerida(cara As Byte, producto As Integer, idManguera As Integer, lectura As String, guid As String)

        RomEstacion(cara.ToString) = ""
        LogCategorias.Clear()
        LogCategorias.Agregar("Ibutton")
        LogPropiedades.Clear()
        LogPropiedades.Agregar("Cara", cara.ToString())
        Fabrica.LogIt.Loguear("Solicitada Autorización (En este momento el surtidor le avisa al aplicativo)", LogPropiedades, LogCategorias)

        Dim TipoAutorizacion As Helper.ETipoValidacion = RetornarTipoValidacion()
        Dim EsLecturaChipObligatoria As Boolean = False
        'Recibo el pedido de Autorizacion        
        Dim OHelperEstacion As New Helper
        Dim oCreditoTmp As CreditoFullstation = Nothing

        Try

            POSstation.Fabrica.gasolutionsHasp.IsHasp()
            Dim EsLecturaChipAutomaticaCredito As Boolean = CBool(OHelperEstacion.RecuperarParametro("EsLecturaChipAutomaticaCredito"))
            OHelperEstacion.EliminarVentaParcialCara(Convert.ToInt16(cara))

            'Antes que nada verifico que exista un turno abierto para el surtidor
            'donde se encuentra la cara
            If producto <> -1 Then
                EsLecturaChipObligatoria = OHelperEstacion.EsLecturaChipObligatoria(producto)
            End If

            Dim Args() As String = {CStr(cara), CStr(CInt(TipoAutorizacion)), CStr(producto), CStr(EsLecturaChipObligatoria), CStr(idManguera), CStr(guid)}

            If Not CarasEstacion(cara.ToString) Then 'Si es true, la cara se esta intentando autorizar 
                If OHelperEstacion.RecuperarEstadoTurno(cara.ToString()) = "Abierto" Then

                    'Eliminando informacion temporal de creditos de consumo
                    OHelperEstacion.EliminarCupoEnReserva(cara)

                    If (CreditosEstacion.ContainsKey(cara.ToString())) Then
                        LogCategorias.Clear()
                        LogCategorias.Agregar("Credito")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                        LogPropiedades.Agregar("Mensaje", "Se solicita autorizacion de venta credito")
                        Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                        If CreditosEstacion(cara.ToString()).TipoIdentificacion = TipoIdentificadorVehiculo.CHIP Then
                            If EsLecturaChipAutomaticaCredito Then
                                If CreditosEstacion(cara.ToString()).ValorPredeterminado <> "-1" And CreditosEstacion(cara.ToString()).ValorPredeterminado <> "0" Then
                                    Dim OPreset As Preset = BuscarPreset(CStr(cara))
                                    OPreset = New Preset(CreditosEstacion(cara.ToString()).ValorPredeterminado, Preset.Tipo.PorValor)
                                    If ColPreset.ContainsKey(cara) Then
                                        ColPreset.Remove(cara)
                                    End If
                                    ColPreset.Add(cara, OPreset)
                                End If
                                Me.CreditosEstacion.Remove(cara.ToString())
                            End If
                        End If
                    End If

                    Try
                        'SE VALIDA SI HUBO VENTAS HECHAS SIN SISTEMA EN LA MANGUERA REPORTADA
                        OHelperEstacion.ValidarVentasSinSistema(CShort(idManguera), CDec(lectura))
                    Catch ex As System.Exception
                        If CBool(OHelperEstacion.RecuperarParametro("BloquearManguerasVentasFueraSistema")) Then
                            Throw ex
                        Else
                            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
                        End If
                    End Try

                    'VALIDANDO LAS EXISTENCIAS DE COMBUSTIBLE SI LA MANGUERA TIENE UN TANQUE ASOCIADO
                    If Not OHelperEstacion.TieneExistenciasProducto(CShort(idManguera)) Then
                        Try
                            'VALIDANDO SI EXISTEN MANGUERAS A LAS CUALES SE LES DEBA REALIZAR CAMBIO DE PRODUCTO Y PRECIO
                            ManagementKardex.ConsultarManguerasCambiarProducto(CShort(idManguera.ToString()))
                        Catch ex As System.Exception
                            LogFallas.ReportarError(ex, "Falla al Consultar Mangueras ", "Cara: " & cara & ", IdManguera: " & idManguera, "KardexCombustible")
                            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
                        End Try

                        Throw New System.Exception("NO HAY EXISTENCIAS PARA EL PRODUCTO. POR FAVOR CUELGUE LA MANGUERA. EL SISTEMA CAMBIARA A UN PRODUCTO COMPLEMENTARIO QUE TENGA EXISTENCIAS")
                    End If

                    If Not OHelperEstacion.RecuperarEstadoCaraManguera(cara, CShort(idManguera)) Then
                        Throw New System.Exception("La Cara " & cara & " no se encuentra ACTIVA")
                    End If

                    CarasEstacion(cara.ToString) = True

                    If Not EsLecturaChipObligatoria Then 'todo: cambiar pr un enumerado
                        If CreditosEstacion.ContainsKey(cara.ToString) Then
                            CreditosEstacion(cara.ToString()).IdProducto = producto
                            If CreditosEstacion(cara.ToString()).TipoIdentificacion = TipoIdentificadorVehiculo.CHIP Then
                                Dim OHilo As New BackgroundWorker
                                AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                OHilo.RunWorkerAsync(Args)
                            ElseIf CreditosEstacion(cara.ToString()).TipoIdentificacion = TipoIdentificadorVehiculo.TARJETA Then
                                Dim OPreset As Preset = BuscarPreset(CStr(cara))

                                If CreditosEstacion(cara.ToString()).ValorPredeterminado <> "-1" And CreditosEstacion(cara.ToString()).ValorPredeterminado <> "0" Then
                                    OPreset = New Preset(CreditosEstacion(cara.ToString()).ValorPredeterminado, Preset.Tipo.PorValor)
                                End If


                                Dim odatos As New Helper
                                Dim Validacion As Boolean = CBool(odatos.RecuperarParametro("AplicaCreditoConPlacaSecundaria"))

                                'credito.Documento '' identificador
                                'credito.NroAutorizacionManual 'placa'

                                ''victor
                                If Validacion Then
                                    Dim OCredito As New CreditoFullstation
                                    Dim dtsPlacas As New DataSet

                                    If CreditosEstacion.ContainsKey(cara) Then
                                        OCredito = CreditosEstacion(cara)
                                        If OCredito.NroAutorizacionManual <> String.Empty Then
                                            dtsPlacas = odatos.RecuperarIdentificadorLocalPorIdPlaca2(CStr(OCredito.Documento), CStr(OCredito.NroAutorizacionManual))
                                            If dtsPlacas.Tables(0).Rows.Count <= 0 Then
                                                Throw New System.Exception("No tiene autorizacion")
                                            End If
                                        End If
                                    End If
                                End If




                                If OHelperEstacion.ValidarSiVehiculoEsCreditoGerenciadoPorTarjeta(CreditosEstacion(cara.ToString()).Documento) Then
                                    AutorizarVentaCreditoCRMStation(cara, producto, CreditosEstacion(cara.ToString()).Documento, CreditosEstacion(cara.ToString()).TipoIdentificacion, OPreset, CreditosEstacion(cara.ToString()).RUTconductor, guid)

                                Else

                                    'Este metodo aplicar solo en ventas credito locales
                                    AutorizarVentaCredito(EsLecturaChipObligatoria, cara, producto, idManguera, CreditosEstacion(cara.ToString()).Documento, TipoIdentificadorVehiculo.TARJETA, OPreset, guid)

                                End If

                                'AutorizarVentaCredito(EsLecturaChipObligatoria, cara, producto, idManguera, CreditosEstacion(cara.ToString()).Documento, TipoIdentificadorVehiculo.TARJETA, OPreset)
                            End If

                        ElseIf VentasCheques.ContainsKey(cara) Then
                            If VentasCheques(cara).EsClienteIdentificado Then
                                If VentasCheques(cara).TipoIdentificacion = TipoIdentificacionCredito.CHIP Then
                                    Dim OHilo As New BackgroundWorker
                                    AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                    AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                    OHilo.RunWorkerAsync(Args)
                                Else
                                    Dim placatemporal As String = ""
                                    Dim Credito As Credito = Nothing
                                    Dim OPreset As Preset
                                    Credito = VentasCheques.Item(cara.ToString())
                                    placatemporal = OHelperEstacion.RecuperarPlacaPorTarjeta(Credito.Tarjeta.CodigoTarjeta)
                                    Credito.FormaPagoContado.Valor = OHelperEstacion.RecuperarValorChequePorPlaca(placatemporal, Credito.FormaPagoContado.NumeroAutorizacion)
                                    OPreset = New Preset(Credito.FormaPagoContado.Valor.ToString, Preset.Tipo.PorValor)

                                    oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                                End If
                            Else
                                Dim OPreset As Preset
                                Dim Credito As Credito = Nothing
                                Credito = VentasCheques(cara.ToString())
                                Dim placatemporal As String = ""
                                placatemporal = Credito.Placa
                                Credito.FormaPagoContado.Valor = OHelperEstacion.RecuperarValorChequePorPlaca(placatemporal, Credito.FormaPagoContado.NumeroAutorizacion)
                                OPreset = New Preset(Credito.FormaPagoContado.Valor.ToString, Preset.Tipo.PorValor)

                                oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                            End If
                        ElseIf VentaPrepago.ContainsKey(cara.ToString()) Then
                            Dim OPreset As Preset
                            Dim Venta As CupoPrepago = VentaPrepago(cara.ToString)
                            Dim placatemporal As String = ""
                            OPreset = New Preset(Venta.Valor, Preset.Tipo.PorValor)

                            oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                        ElseIf CreditosTerpel.ContainsKey(cara) Then
                            CreditosTerpel(cara.ToString()).IdProducto = producto
                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                            LogPropiedades.Agregar("Mensaje", "Antes de autorizar la venta Terpel")
                            Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                            Dim OHilo As New BackgroundWorker
                            AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                            AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                            OHilo.RunWorkerAsync(Args)

                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                            LogPropiedades.Agregar("Despues", "Despues de autorizar la venta Terpel")
                            Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)
                        ElseIf Me.DatosMenoCash.ContainsKey(cara.ToString()) Then
                            Dim OHilo As New BackgroundWorker
                            AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                            AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                            OHilo.RunWorkerAsync(Args)

                        Else
                            Dim Placa As String = BuscarPlaca(cara.ToString)

                            'Verificando que exista una consumo interno o una calibracion
                            If Consumos.ContainsKey(CStr(cara)) Then
                                If Consumos(CStr(cara)).TipoConsumo = TipoConsumo.Calibracion Then
                                    If idManguera <> Consumos(CStr(cara)).IdManguera Then
                                        ImpresoraTurno.ImprimirExcepcion("LA MANGUERA DESCOLGADA NO ES LA MISMA QUE SE MANDO A CALIBRAR.", ImpresoraEstacion.CrearImpresora(cara))
                                        CarasEstacion(cara.ToString) = False
                                        'SE SALE DEL EVENTO
                                        Exit Sub
                                    End If
                                End If
                            End If

                            If Not CBool(OHelperEstacion.RecuperarParametro("IdentificarVentasEfectivoConChip")) Then

                                If CBool(OHelperEstacion.RecuperarParametro("AutorizarVentaLiquidoConChip")) Then
                                    Dim OHilo As New BackgroundWorker
                                    AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                    AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                    OHilo.RunWorkerAsync(Args)
                                ElseIf EsLecturaChipAutomaticaCredito Then
                                    Dim OHilo As New BackgroundWorker
                                    AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                    AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                    OHilo.RunWorkerAsync(Args)
                                ElseIf OHelperEstacion.SolicitaChipParaVenderEnCara(cara.ToString) Then
                                    Dim OHilo As New BackgroundWorker
                                    AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                    AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                    OHilo.RunWorkerAsync(Args)
                                Else

                                    Dim OPreset As Preset = BuscarPreset(CStr(cara))
                                    FechasEstacion(cara.ToString) = "01/01/1900"
                                    RomEstacion(cara.ToString) = ""
                                    oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), Placa, idManguera, False, guid)
                                    CarasEstacion(cara.ToString) = False
                                End If

                            Else
                                Dim OHilo As New BackgroundWorker
                                AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                OHilo.RunWorkerAsync(Args)
                            End If
                        End If
                    Else
                        If CreditosEstacion.ContainsKey(cara.ToString) Then
                            CreditosEstacion(cara.ToString()).IdProducto = producto
                            If CreditosEstacion(cara.ToString()).TipoIdentificacion = TipoIdentificadorVehiculo.CHIP Then
                                Dim OHilo As New BackgroundWorker
                                AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                OHilo.RunWorkerAsync(Args)
                            ElseIf CreditosEstacion(cara.ToString()).TipoIdentificacion = TipoIdentificadorVehiculo.TARJETA Then
                                Dim OPreset As Preset = BuscarPreset(CStr(cara))

                                '--
                                If OHelperEstacion.ValidarSiVehiculoEsCreditoGerenciadoPorTarjeta(CreditosEstacion(cara.ToString()).Documento) Then
                                    AutorizarVentaCreditoCRMStation(cara, producto, CreditosEstacion(cara.ToString()).Documento, CreditosEstacion(cara.ToString()).TipoIdentificacion, OPreset, CreditosEstacion(cara.ToString()).RUTconductor, guid)

                                Else
                                    'Este metodo aplicar solo en ventas credito locales
                                    AutorizarVentaCredito(EsLecturaChipObligatoria, cara, producto, idManguera, CreditosEstacion(cara.ToString()).Documento, TipoIdentificadorVehiculo.TARJETA, OPreset, guid)

                                End If
                                'AutorizarVentaCredito(EsLecturaChipObligatoria, cara, producto, idManguera, CreditosEstacion(cara.ToString()).Documento, TipoIdentificadorVehiculo.TARJETA, OPreset)
                            End If
                        ElseIf VentaPrepago.ContainsKey(cara.ToString()) Then
                            Dim OPreset As Preset
                            Dim Venta As CupoPrepago = VentaPrepago(cara.ToString)
                            Dim placatemporal As String = ""
                            OPreset = New Preset(Venta.Valor, Preset.Tipo.PorValor)

                            oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                        ElseIf VentasCheques.ContainsKey(cara) Then
                            If VentasCheques(cara).EsClienteIdentificado Then
                                If VentasCheques(cara).TipoIdentificacion = TipoIdentificacionCredito.CHIP Then
                                    Dim OHilo As New BackgroundWorker
                                    AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                                    AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                                    OHilo.RunWorkerAsync(Args)
                                Else
                                    Dim placatemporal As String = ""
                                    Dim Credito As Credito = Nothing
                                    Dim OPreset As Preset
                                    Credito = VentasCheques.Item(cara.ToString())
                                    placatemporal = OHelperEstacion.RecuperarPlacaPorTarjeta(Credito.Tarjeta.CodigoTarjeta)
                                    Credito.FormaPagoContado.Valor = OHelperEstacion.RecuperarValorChequePorPlaca(placatemporal, Credito.FormaPagoContado.NumeroAutorizacion)
                                    OPreset = New Preset(Credito.FormaPagoContado.Valor.ToString, Preset.Tipo.PorValor)
                                    oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                                End If
                            Else
                                Dim OPreset As Preset
                                Dim Credito As Credito = Nothing
                                Credito = VentasCheques(cara.ToString())
                                Dim placatemporal As String = ""
                                placatemporal = Credito.Placa
                                Credito.FormaPagoContado.Valor = OHelperEstacion.RecuperarValorChequePorPlaca(placatemporal, Credito.FormaPagoContado.NumeroAutorizacion)
                                OPreset = New Preset(Credito.FormaPagoContado.Valor.ToString, Preset.Tipo.PorValor)

                                oEventos_VentaAutorizada(cara, 0, OPreset.Valor, CByte(OPreset.TipoPreset), placatemporal, idManguera, False, guid)
                            End If
                        ElseIf CreditosTerpel.ContainsKey(cara) Then
                            CreditosTerpel(cara.ToString()).IdProducto = producto
                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                            LogPropiedades.Agregar("Mensaje", "Antes de autorizar la venta Terpel")
                            Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                            Dim OHilo As New BackgroundWorker
                            AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                            AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                            OHilo.RunWorkerAsync(Args)

                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                            LogPropiedades.Agregar("Despues", "Despues de autorizar la venta Terpel")
                            Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)
                        Else

                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                            LogPropiedades.Agregar("Mensaje", "Antes de autorizar la venta efectivo")
                            Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)



                            Dim OHilo As New BackgroundWorker
                            AddHandler OHilo.DoWork, AddressOf Hilo_DoWork
                            AddHandler OHilo.RunWorkerCompleted, AddressOf Hilo_RunWorkerCompleted
                            OHilo.RunWorkerAsync(Args)

                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                            LogPropiedades.Agregar("Despues", "Despues de autorizar la venta efectivo")
                            Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                        End If
                    End If
                Else
                    Throw New System.Exception("La Cara " & cara & " no pertenece a un turno ABIERTO")
                End If
            End If
        Catch Ex As GasolutionsHaspException

            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False
            If CreditosEstacion.ContainsKey(cara.ToString) Then
                CreditosEstacion.Remove(cara.ToString)
            End If
            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas(cara.ToString) = False
            End If
            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara.ToString) Then
                VentasCheques.Remove(cara.ToString)
            End If


            ListaProtocolos_CancelarVenta(cara)

            oEventos_ExcepcionOcurrida("LLAVE HASP NO ENCONTRADA", True, False, "")
            ' LogFallas.ReportarError(New System.Exception("LLAVE HASP NO ENCONTRADA"), "AutorizacionRequerida", "-", "AutorizacionRequerida")
            oEventos_VentaNOautorizada(cara, "LLAVE HASP NO ENCONTRADA")
        Catch ex As System.Exception
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False
            If CreditosEstacion.ContainsKey(cara.ToString) Then
                CreditosEstacion.Remove(cara.ToString)
            End If
            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas(cara.ToString) = False
            End If
            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara.ToString) Then
                VentasCheques.Remove(cara.ToString)
            End If

            ListaProtocolos_CancelarVenta(cara)

            OHelperEstacion.InsertarAutorizacionFallidaLogueo(cara.ToString(), "", "", "", "", "", ex.Message.ToString(), "")
            LogFallas.ReportarError(ex, "oEventos_AutorizacionRequerida", "Cara: " & cara, "General")
            oEventos_VentaNOautorizada(cara, ex.Message)
        End Try
    End Sub

    Sub ListaProtocolos_PredeterminarMR3(Cara As Byte, ValorProgramado As String, TipoProgramacion As Byte)
        Try
            Dim Protocolo As iProtocolo
            Dim OHelper As New Helper
            For Each Protocolo In ListaSurtidores
                If OHelper.ExisteManejoCarroTanque(Cara) Then
                    Protocolo.Evento_Predeterminar(Cara, ValorProgramado, TipoProgramacion)
                End If
            Next
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ListaProtocolos_PredeterminarMR3", "", "Venta")
        End Try
    End Sub

    Sub ListaProtocolos_CancelarVenta(Cara As Byte)
        Try
            Dim Protocolo As iProtocolo
            For Each Protocolo In ListaSurtidores
                Protocolo.Evento_CancelarVenta(Cara)
            Next

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ListaProtocolos_PredeterminarMR3", "", "Venta")
        End Try
    End Sub

    Sub ListaProtocolos_VentaAutorizada(Cara As Byte, Precio As String, ValorProgramado As String, TipoProgramacion As Byte, Placa As String, MangueraProgramada As Int32, EsVentaGerenciada As Boolean, guid As String)
        Try
            Dim Protocolo As iProtocolo
            For Each Protocolo In ListaSurtidores

                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                LogPropiedades.Agregar("Mensaje", "Antes de autorizar la venta")
                LogPropiedades.Agregar("Guid Autorizacion", guid)
                Fabrica.LogIt.Loguear("Seguimiento", LogPropiedades, LogCategorias)

                Protocolo.Evento_VentaAutorizada(Cara, Precio, ValorProgramado, TipoProgramacion, Placa, MangueraProgramada, EsVentaGerenciada, guid, 0)

                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                LogPropiedades.Agregar("Mensaje", "Despues de autorizar la venta")
                Fabrica.LogIt.Loguear("Seguimiento", LogPropiedades, LogCategorias)
            Next

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ListaProtocolos_VentaAutorizada", "", "Venta")
        End Try
    End Sub
    'Lista Implementacion Para FullStation
    Private Sub oEventos_VentaAutorizada(cara As Byte, precio As String, valorProgramado As String, tipoProgramacion As Byte, placa As String, ByRef idMangueraProgramada As Integer, esVentaGerenciada As Boolean, guid As String)
        Dim OHelper As New Helper
        Try

            Dim IdFormaPago As Short = 0
            Dim AutorizacionCheque As String = Nothing
            Dim NroTarjeta As String = Nothing
            Dim ValorPrepago As Double = 0
            'Venta Gerenciada
            Dim AutorizacionCRM As String = Nothing
            Dim SaldoDisponible As Decimal
            Dim Iva As Decimal

            If String.IsNullOrEmpty(valorProgramado) Then
                valorProgramado = "0"
            End If

            ListaProtocolos_VentaAutorizada(cara, precio, valorProgramado, tipoProgramacion, placa, idMangueraProgramada, esVentaGerenciada, guid)

            If Me.Consumos.ContainsKey(cara.ToString()) Then 'SI LA VENTA ESTA PREDETERMINADA COMO CALIBRACION O CONSUMO INTERNO
                'SI LA VENTA ESTA PREDETERMINADA COMO CONSUMO INTERNO SE MANDA LA FORMA DE PAGO PARA ESTE
                If Consumos(cara.ToString()).TipoConsumo = TipoConsumo.ConsumoInterno Then
                    IdFormaPago = CShort(FormaPagoTerpel.CONSUMO)
                    Me.Consumos.Remove(cara.ToString)
                End If
            End If

            'VENTA GERENCIADA
            If Me.CreditosEstacion.ContainsKey(cara.ToString()) Then
                AutorizacionCRM = Me.CreditosEstacion(cara.ToString()).Autorizacion
                SaldoDisponible = Me.CreditosEstacion(cara.ToString()).SaldoDisponible
                IdFormaPago = Me.CreditosEstacion(cara.ToString()).FormaPago
                NroTarjeta = Me.CreditosEstacion(cara.ToString()).Documento
            End If

            'CHEQUES
            '----------------------------------------------
            If VentasCheques.ContainsKey(cara) Then
                IdFormaPago = CShort(Me.VentasCheques(cara.ToString).FormaPagoContado.IdFormaPago)
                AutorizacionCheque = Me.VentasCheques(cara.ToString).FormaPagoContado.NumeroAutorizacion
            End If
            '----------------------------------------------

            If VentaPrepago.ContainsKey(cara) Then
                IdFormaPago = VentaPrepago(cara).FormaPago
                NroTarjeta = VentaPrepago(cara).NroTarjeta
                ValorPrepago = VentaPrepago(cara).Valor

                If Not String.IsNullOrEmpty(VentaPrepago(cara).Placa) Then
                    placa = VentaPrepago(cara).Placa
                End If

            End If

            'VENTA TERPEL
            If Me.CreditosTerpel.ContainsKey(cara.ToString()) Then
                AutorizacionCRM = Me.CreditosTerpel(cara.ToString()).Autorizacion
                SaldoDisponible = Me.CreditosTerpel(cara.ToString()).SaldoDisponible
                IdFormaPago = Me.CreditosTerpel(cara.ToString()).FormaPago
                Iva = Me.CreditosTerpel(cara.ToString()).Iva
            End If


            'LogCategorias.Clear()
            'LogCategorias.Agregar("SeguimientoCodigoDTI")
            'LogPropiedades.Clear()
            'LogPropiedades.Agregar("Placa", placa.Trim())
            'LogPropiedades.Agregar("ROM", RomEstacion(cara))
            'LogPropiedades.Agregar("Fecha", FechasEstacion(cara))
            'Fabrica.LogIt.Loguear("Venta Autorizada", LogPropiedades, LogCategorias)


            OHelper.InsertarVentaParcialFullstation(cara, Nothing, placa.Trim(), FechasEstacion(cara), RomEstacion(cara), IdFormaPago, idMangueraProgramada, AutorizacionCheque, AutorizacionCRM, SaldoDisponible, NroTarjeta, ValorPrepago, Iva)

            'OHelper.InsertarVentaParcialFullstation(cara, Nothing, placa.Trim(), FechasEstacion(cara), RomEstacion(cara), IdFormaPago, idMangueraProgramada, AutorizacionCheque, NroTarjeta, ValorPrepago)
            'OHelper.InsertarVentaParcialFullstation(cara, Nothing, placa.Trim(), FechasEstacion(cara), RomEstacion(cara), IdFormaPago, idMangueraProgramada, AutorizacionCheque, AutorizacionCRM, SaldoDisponible, NroTarjeta, ValorPrepago)


            Try
                Dim DatosTmp As New DatosTemporalesSauce
                DatosTmp.Cara = cara
                DatosTmp.Precio = precio
                DatosTmp.Valor = valorProgramado
                DatosTmp.Placa = placa
                DatosTmp.Manguera = idMangueraProgramada
                DatosTmp.Gerenciada = esVentaGerenciada
                Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf VentaAutorizada), DatosTmp)

            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "Hilo VentaAurozida", "Cara: " & cara & ", Placa: " & placa & ", FechUltManten:  " & FechasEstacion(CStr(cara)) & ", Rom: " & RomEstacion(CStr(cara)), "Ventas")
            End Try

        Catch EXBD As Data.DataException
            OHelper.InsertarAutorizacionFallidaLogueo(cara.ToString(), idMangueraProgramada.ToString, placa, "", "", RomEstacion(cara), EXBD.Message.ToString(), "")
            LogFallas.ReportarError(EXBD, "oEventos_VentaAutorizada", "Cara: " & cara & ", Placa: " & placa & ", FechUltManten:  " & FechasEstacion(cara) & ", Rom: " & RomEstacion(cara) & "idMangueraProgramada: " & idMangueraProgramada.ToString, "Ventas")
        Catch EXSQL As Data.SqlClient.SqlException
            OHelper.InsertarAutorizacionFallidaLogueo(cara.ToString(), idMangueraProgramada.ToString, placa, "", "", RomEstacion(cara), EXSQL.Message.ToString(), "")
            LogFallas.ReportarError(EXSQL, "oEventos_VentaAutorizada", "Cara: " & cara & ", Placa: " & placa & ", FechUltManten:  " & FechasEstacion(cara) & ", Rom: " & RomEstacion(cara) & "idMangueraProgramada: " & idMangueraProgramada.ToString, "Ventas")
        Catch ex As System.Exception
            OHelper.InsertarAutorizacionFallidaLogueo(cara.ToString(), idMangueraProgramada.ToString, placa, "", "", RomEstacion(cara), ex.Message.ToString(), "")
            LogFallas.ReportarError(ex, "oEventos_VentaAutorizada", "Cara: " & cara & ", Placa: " & placa & ", FechUltManten:  " & FechasEstacion(cara) & ", Rom: " & RomEstacion(cara) & "idMangueraProgramada: " & idMangueraProgramada.ToString, "Ventas")
        End Try
    End Sub
    Private Sub VentaAutorizada(Datos As DatosTemporalesSauce)
        Dim Cara As String = ""
        Try
            Dim EnEjecucion As Boolean = False
            EnEjecucion = Process.GetProcessesByName("DisplayStation").Length > 0
            Cara = Datos.Cara

            If EnEjecucion Then
                Dim Service As ServiceSharedEventClient = Nothing
                Service = New ServiceSharedEventClient

                Service.VentaAutorizada(Datos.Cara, Datos.Precio, "0", 0, Datos.Mensaje, Datos.Manguera, Datos.Gerenciada)
                If Not Service Is Nothing Then
                    If Service.State = ServiceModel.CommunicationState.Opened Then
                        Service.Close()
                    End If
                End If
            End If

        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("WCF")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Cara", Cara.ToString())
            Fabrica.LogIt.Loguear("Error al Localizar el EndPoint: " & ex.Message, LogPropiedades, LogCategorias)
        End Try
    End Sub



    'Lista Implementacion Para FullStation
    Private Sub oEventos_LecturaInicialVenta(cara As Byte, lectura As String)
        Try
            Dim OHelper As New Helper
            OHelper.InsertarVentaParcialFullstation(cara, CDec(lectura), "", "", "", 0, 0, "", Nothing, 0)
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_LecturaInicialVenta", "Cara: " & cara & ", Lectura: " & lectura, "Ventas")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_LecturaInicialVenta", "Cara: " & cara & ", Lectura: " & lectura, "Ventas")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_LecturaInicialVenta", "Cara: " & cara & ", Lectura: " & lectura, "Ventas")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_VentaFinalizada(cara As Byte, valor As String, precio As String, lecturaFinal As String, cantidad As String, producto As Byte, manguera As Integer, presionLLenado As String, lecturaInicial As String)
        Try
            Dim OHelper As New Helper
            Dim Recibo As Double
            Dim Kilometraje As String = ""
            Dim Nivel As String = ""
            Dim Placa As String = ""
            Dim DataT As DatosDataTrack
            Dim TarjetaFidelizacion As Fidelizacion = Me.BuscarFidelizacion(cara.ToString)
            Dim EsPagoConBono As Boolean = False
            Dim oVentaBono As AutorizacionVentaBono = Nothing
            Dim RUTConductor As String = Nothing
            Dim TipoDocumento As New Documento
            Dim Reintentar As Boolean = True
            Dim placaSecundaria As String = ""

            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                Kilometraje = KilometrajesEstacion(cara.ToString)
                'KilometrajesEstacion.Remove(cara.ToString)
            End If



            If CreditosTerpel.ContainsKey(cara.ToString) Then
                TipoDocumento.FormaPago = 0
                Kilometraje = CreditosTerpel(cara.ToString).Kilometraje
                CreditosTerpel.Remove(cara.ToString)
            End If

            If DataTrack.ContainsKey(cara.ToString) Then
                DataT = DataTrack(cara.ToString)
                Kilometraje = DataT.Kilometraje
                Nivel = DataT.Nivel
                DataTrack.Remove(cara.ToString)
            End If


            If VentaPrepago.ContainsKey(cara.ToString) Then
                Kilometraje = VentaPrepago(cara.ToString).kilometraje
            End If

            If CreditosEstacion.ContainsKey(cara.ToString) Then
                TipoDocumento.Identificacion = CreditosEstacion(cara.ToString).Documento
                TipoDocumento.IdentificacionAux = CreditosEstacion(cara.ToString).DocumentoAux
                TipoDocumento.TipoIdentificacion = CreditosEstacion(cara.ToString).TipoIdentificacion
                placaSecundaria = CreditosEstacion(cara.ToString).NroAutorizacionManual

                'SI ES UNA VENTA CREDITO LOCAL DE ESTACION
                If Not CreditosEstacion(cara.ToString).EsEfectivo Then
                    TipoDocumento.FormaPago = 0
                End If

                CreditosEstacion.Remove(cara.ToString)
            End If

            'VERIFICANDO QUE EXISTAN UNA CALIBRACION
            If Consumos.ContainsKey(CStr(cara)) Then
                Dim OConsumo As Consumo = Consumos.Item(CStr(cara))
                If OConsumo.TipoConsumo = TipoConsumo.Calibracion Then
                    Dim IdCalibracion As Int32 = OHelper.InsertarCalibracion(CShort(cara), CShort(manguera), OConsumo.IdMotivoCalibracion, CDec(valor), CDec(cantidad), CInt(producto), CDec(lecturaFinal), CDec(precio))
                    ImpresoraRecibo.ImprimirReciboCalibracion(IdCalibracion, ImpresoraEstacion.CrearImpresora(cara))
                End If

                Consumos.Remove(CStr(cara))
            Else
                If ColVentaBono.ContainsKey(cara.ToString) Then
                    EsPagoConBono = True
                End If

                ' ''Recibo = OHelper.InsertarVenta(cara, CDec(lecturaFinal), CDec(precio), CDec(cantidad), CDec(valor), producto, Guid.NewGuid.ToString, manguera, Kilometraje, EsPagoConBono)
                ''Recibo = OHelper.InsertarVenta(cara, CDec(lecturaFinal), CDec(precio), CDec(cantidad), CDec(valor), producto, Guid.NewGuid.ToString, manguera, Kilometraje, TipoDocumento.Identificacion, TipoDocumento.IdentificacionAux, TipoDocumento.TipoIdentificacion, TipoDocumento.FormaPago, EsPagoConBono)

                'INSERTANDO LA VENTA EN TABLA DE VENTA
                Try
                    '*****************************************************************************
                    'LOGUEANDO LA VENTA GERENCIADA
                    LogCategorias.Clear()
                    LogCategorias.Agregar("SeguimientoVentaG")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Cara", cara.ToString)
                    Fabrica.LogIt.Loguear("ANTES DE EJECUTAR EL METODO INSERTAR VENTA EN GT", LogPropiedades, LogCategorias)
                    '*****************************************************************************

                    'victor
                    Recibo = OHelper.InsertarVenta(cara, CDec(lecturaFinal), CDec(precio), CDec(cantidad), CDec(valor), producto, Guid.NewGuid.ToString, manguera, Kilometraje, TipoDocumento.Identificacion, TipoDocumento.IdentificacionAux, TipoDocumento.TipoIdentificacion, TipoDocumento.FormaPago, Nivel, placaSecundaria, EsPagoConBono)
                    Reintentar = False


                    '*****************************************************************************
                    'LOGUEANDO LA VENTA GERENCIADA
                    LogCategorias.Clear()
                    LogCategorias.Agregar("SeguimientoVentaG")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString)
                    LogPropiedades.Agregar("Cara", cara.ToString)
                    LogPropiedades.Agregar("RECIBO", Recibo.ToString)
                    LogIt.Loguear("DESPUES DE EJECUTAR EL METODO INSERTAR VENTA EN GT", LogPropiedades, LogCategorias)
                    '*****************************************************************************

                Catch ex As SqlClient.SqlException
                    If ex.Message.Contains("Timeout") Then
                        Reintentar = True
                    End If
                End Try

                'SI NO SE PUDO INSERTAR LA VENTA EN LA TABLA VENTA POR TIMEOUT SE INSERTA EN LA TABLA IMAGENVENTA
                If Reintentar Then
                    Try
                        Recibo = OHelper.InsertarVentaReintentoSauce(cara, CDec(lecturaFinal), CDec(precio), CDec(cantidad), CDec(valor), producto, Guid.NewGuid.ToString, manguera, Kilometraje, TipoDocumento.Identificacion, TipoDocumento.IdentificacionAux, TipoDocumento.TipoIdentificacion, TipoDocumento.FormaPago, EsPagoConBono)

                    Catch ex As System.Exception
                        LogFallas.ReportarError(ex, "Falla Insertar Venta Auxiliar", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad, "ReintentosVentas")
                    End Try
                End If



                If Not TarjetaFidelizacion Is Nothing Then
                    If TarjetaFidelizacion.FidelizarVenta Then
                        Try
                            LogCategorias.Clear()
                            LogCategorias.Agregar("LogueoAutorizador")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("FechaHora", Now.ToString())
                            LogPropiedades.Agregar("Recibo", Recibo.ToString)
                            LogPropiedades.Agregar("TarjetaFidelizada", TarjetaFidelizacion.Tarjeta)
                            Fabrica.LogIt.Loguear("Fidelizando la Venta", LogPropiedades, LogCategorias)

                            OHelper.FidelizarVenta(CLng(Recibo), TarjetaFidelizacion.RedFidelizacion, TarjetaFidelizacion.Tarjeta) '// Ojo se debera adicionar el parametro EsVentaRegistrada
                            POSstation.ServerServices.ServicioFidelizacion.RegistrarUltimaVentaFidelizada(Recibo)
                        Catch ex As System.Exception
                            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(CLng(Recibo)))
                        End Try
                    End If
                End If

                If EsPagoConBono Then
                    Try
                        'Aca se implementa la modificacion de la venta con el medio de pago bono de fidelizacion
                        oVentaBono = RedimirBonosVentaGenerada(Recibo, ColVentaBono(cara.ToString).nroTarjeta)
                        ColVentaBono.Remove(cara.ToString)
                    Catch ex As System.Exception
                        ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(CLng(Recibo)))
                    End Try
                End If

                oEventos_ImprimirVenta(Recibo, cara, True)

                Try
                    Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf AjustarVentaKardex), Recibo)
                Catch ex As SqlClient.SqlException
                    LogFallas.ReportarError(ex, "AjustarVentaKardex", " Inicio Proceso asincrono de ajuste al kardex ", "General")
                End Try

                If CreditosEstacion.ContainsKey(cara.ToString()) Then
                    CreditosEstacion.Remove(cara.ToString())
                End If


                If VentaEfectivo.ContainsKey(cara.ToString) Then
                    VentaEfectivo.Remove(cara.ToString)
                End If



                If LecturasLSIB4.ContainsKey(cara.ToString) Then
                    LecturasLSIB4.Remove(cara.ToString)
                End If

                Try
                    If OHelper.ValidarTopeConsignacion(Recibo) Then
                        Dim fecha As DateTime = Convert.ToDateTime(OHelper.RecuperarParametro("UltimaFechaImpresionTope")).ToString("dd/MM/yyyy HH:mm:ss.fff")
                        If (DateDiff(DateInterval.Minute, fecha, Now) > CInt(OHelper.RecuperarParametro("IntervaloConsignacion"))) Then
                            ImpresoraRecibo.ImprimirTopeConsignacion(Recibo, New ImpresoraEstacion(CLng(Recibo)))
                            OHelper.ActualizarParametro("UltimaFechaImpresionTope", Now.ToString("dd/MM/yyyy HH:mm:ss.fff"))
                        End If
                    End If
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "Excepcion controlada-Tope consignacion ", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad, "KardexCombustible")
                End Try


                'Try
                '    'VALIDANDO SI EXISTEN MANGUERAS A LAS CUALES SE LES DEBA REALIZAR CAMBIO DE PRODUCTO Y PRECIO
                '    ManagementKardex.ConsultarManguerasCambiarProducto(CShort(manguera.ToString()))
                'Catch ex As System.Exception
                '    LogFallas.ReportarError(ex, "Falla al Consultar Mangueras ", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad, "KardexCombustible")
                '    ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
                'End Try



                'TRASLANDO LAS VENTAS DE REINTENTO A LA TABLA DE VENTA
                Try
                    OHelper.InsertarImagenesVentas()
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "Falla al Trasladar Imagen a Ventas", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad, "ReintentosVentas")
                End Try
            End If

            If My.Settings.AplicaServicioDataTrack Then
                ServiceController.RunService("ComunicadorDataTrack")
            End If


        Catch EXBD As Data.DataException
            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If
            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas.Remove(cara.ToString)
            End If

            If CreditosEstacion.ContainsKey(cara.ToString()) Then
                CreditosEstacion.Remove(cara.ToString())
            End If


            If LecturasLSIB4.ContainsKey(cara.ToString) Then
                LecturasLSIB4.Remove(cara.ToString)
            End If

            If VentaPrepago.ContainsKey(cara.ToString) Then
                VentaPrepago.Remove(cara.ToString)
            End If
            'LogFallas.ReportarError(EXBD, "oEventos_VentaFinalizada", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad & " , Producto: " & producto & " , Manguera: " & manguera, "Ventas")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If

            If LecturasLSIB4.ContainsKey(cara.ToString) Then
                LecturasLSIB4.Remove(cara.ToString)
            End If

            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas.Remove(cara.ToString)
            End If

            If CreditosEstacion.ContainsKey(cara.ToString()) Then
                CreditosEstacion.Remove(cara.ToString())
            End If

            If VentaPrepago.ContainsKey(cara.ToString) Then
                VentaPrepago.Remove(cara.ToString)
            End If
            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If


            LogFallas.ReportarError(EXSQL, "oEventos_VentaFinalizada", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad & " , Producto: " & producto & " , Manguera: " & manguera, "Ventas")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
        Catch ex As System.Exception
            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If
            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas.Remove(cara.ToString)
            End If

            If VentaPrepago.ContainsKey(cara.ToString) Then
                VentaPrepago.Remove(cara.ToString)
            End If
            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If

            If LecturasLSIB4.ContainsKey(cara.ToString) Then
                LecturasLSIB4.Remove(cara.ToString)
            End If

            LogFallas.ReportarError(ex, "oEventos_VentaFinalizada", "Cara: " & cara & ", Valor: " & valor & ", Precio: " & precio & ", LecturaFinal: " & lecturaFinal & ", Cantidad: " & cantidad & " , Producto: " & producto & " , Manguera: " & manguera, "Ventas")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        Finally

        End Try
    End Sub



    Private Sub AjustarVentaKardex(Recibo As Double)
        Dim oHelper As New Helper
        Try
            oHelper.InsertarVentaEnKardex(Recibo)

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AjustarVentaKardex", " Proceso asincrono de ajuste al kardex ", "General")
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_VentaNOautorizada(ByRef cara As Byte, ByRef mensaje As String) Handles OEventos.VentaNOautorizada
        Dim OHelper As New Helper
        'OHelper.ActualizarEstadoCaraDisplay(CInt(cara), "Denegado")
        ImpresoraTurno.ImprimirExcepcion("Cara " & cara & ": Venta no autorizada: " & mensaje, ImpresoraEstacion.CrearImpresora(cara))
    End Sub

    'Lista Implementacion Para FullStation (Pendiente el manejat Formas de Pago para Gas y Gasolina)
    Private Sub oEventos_ImprimirVenta(ByRef recibo As Double, ByRef cara As Byte, ByRef esVentaRegistrada As Boolean) Handles OEventos.ImprimirVenta
        Try
            'todo: Agregar Parametro Para impresion de recibos
            Dim OHelper As New Helper
            Dim NumeroCopias As Integer = OHelper.RecuperarCopiasPorForma(CLng(recibo))
            Dim TarjetaFidelizacion As Fidelizacion = Nothing
            Dim ImprimeCopiasKilometraje As Boolean = CBool(OHelper.RecuperarParametro("ImprimeNumerodeCopiasKilometraje"))

            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Recibo", recibo.ToString())
            Fabrica.LogIt.Loguear("Inicio oEventos_ImprimirVenta", LogPropiedades, LogCategorias)


            If Fidelizacion.ContainsKey(cara.ToString) Then
                TarjetaFidelizacion = Fidelizacion(cara.ToString)
                Fidelizacion.Remove(cara.ToString)
            End If

            If Me.KilometrajesEstacion.ContainsKey(cara.ToString) Or Me.ColPlacas.ContainsKey(cara.ToString) Then
                If Not ImprimeCopiasKilometraje Then
                    NumeroCopias = 1
                End If

            End If

            For Copia As Integer = 1 To NumeroCopias
                If Copia = 1 Then
                    ImpresoraRecibo.ImprimirRecibo(recibo, New ImpresoraEstacion(CLng(recibo)))
                Else
                    ImpresoraRecibo.ImprimirRecibo(recibo, New ImpresoraEstacion(CLng(recibo), True))
                End If

                ' If Not OHelper.EsventaImpresa(CLng(recibo)) Then
                OHelper.ActualizarVentaImpresa(CLng(recibo))
                ' End If
            Next Copia

            Try
                If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                    KilometrajesEstacion.Remove(cara.ToString)
                End If

                If CreditosEstacion.ContainsKey(cara.ToString()) Then
                    CreditosEstacion.Remove(cara.ToString())
                End If

                If VentasCheques.ContainsKey(cara) Then
                    VentasCheques.Remove(cara)
                End If

                If VentaPrepago.ContainsKey(cara.ToString) Then
                    VentaPrepago.Remove(cara.ToString)
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "ImprimirVenta", "Recibo: " & recibo, "ImpresionReciboFidelizacion")
            End Try

            'Try
            '    If CBool(OHelper.RecuperarParametro("ImprimirSaldoTarjeta")) Then
            '        If Not TarjetaFidelizacion Is Nothing Then
            '            If TarjetaFidelizacion.RedFidelizacion = 1 Then
            '                Dim ManejaSaldo As Boolean = OHelper.ManejaSaldoFidelizacion(TarjetaFidelizacion.RedFidelizacion)
            '                If Not ManejaSaldo Then
            '                    If esVentaRegistrada Then
            '                        ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(TarjetaFidelizacion.Saldos, New ImpresoraEstacion(CLng(recibo)), TarjetaFidelizacion.Tarjeta)
            '                    Else
            '                        ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(TarjetaFidelizacion.Saldos, ImpresoraEstacion.CrearImpresoraPorRecibo(CLng(recibo), False, False), TarjetaFidelizacion.Tarjeta)
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'Catch ex As System.exception
            '    LogFallas.ReportarError(ex, "ImprimirVenta", "Recibo: " & recibo, "ImpresionReciboFidelizacion")
            'End Try

            Try
                If CBool(OHelper.RecuperarParametro("ImprimirSaldoTarjeta")) Then
                    If Not TarjetaFidelizacion Is Nothing Then
                        If TarjetaFidelizacion.RedFidelizacion = 1 Or TarjetaFidelizacion.RedFidelizacion = 4 Then
                            Dim ManejaSaldo As Boolean = OHelper.ManejaSaldoFidelizacion(TarjetaFidelizacion.RedFidelizacion)
                            If Not ManejaSaldo Then
                                If CBool(OHelper.RecuperarParametro("ImpresionEncabezadoFidelizacion")) Then
                                    If esVentaRegistrada Then
                                        ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(TarjetaFidelizacion.Saldos, TarjetaFidelizacion.MensajesCliente, TarjetaFidelizacion.MensajeError, TarjetaFidelizacion.Tarjeta, New ImpresoraEstacion(CLng(recibo)))
                                    Else
                                        ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(TarjetaFidelizacion.Saldos, TarjetaFidelizacion.MensajesCliente, TarjetaFidelizacion.MensajeError, TarjetaFidelizacion.Tarjeta, ImpresoraEstacion.CrearImpresoraPorRecibo(CLng(recibo), False, False))
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "ImprimirVenta", "Recibo: " & recibo, "ImpresionReciboFidelizacion")
            End Try

        Catch EXBD As Data.DataException
            If Fidelizacion.ContainsKey(cara.ToString) Then
                Fidelizacion.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If

            If VentaPrepago.ContainsKey(cara.ToString) Then
                VentaPrepago.Remove(cara.ToString)
            End If

            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirVenta", "Recibo: " & recibo, "Ventas")
        Catch EXSQL As Data.SqlClient.SqlException
            If Fidelizacion.ContainsKey(cara.ToString) Then
                Fidelizacion.Remove(cara.ToString)
            End If
            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If

            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirVenta", "Recibo: " & recibo, "Ventas")
        Catch ex As System.Exception

            If Fidelizacion.ContainsKey(cara.ToString) Then
                Fidelizacion.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara) Then
                VentasCheques.Remove(cara)
            End If

            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            LogFallas.ReportarError(ex, "oEventos_ImprimirVenta", "Recibo: " & recibo, "Ventas")
        End Try
    End Sub

    '' AUTORIZAR VENTAS GERENCIADAS
    Private Function AutorizarVentaCreditoCRMStation(ByVal Cara As Int16, ByVal IdProducto As Int32, ByVal Identificacion As String, ByVal TipoIdentificacion As IdentificacionCredito, ByVal OPreset As Preset, ByVal RucCoductor As String, guid As String) As Boolean
        Dim OHelper As New Helper
        Dim EsAutorizado As Boolean
        Dim RespuestaCreditoConsumo As POSstation.Fabrica.RespuestaAutorizacionGerenciamiento
        Dim Placa As String

        Try
            'VERIFICANDO QUE EL VEHICULO TENGA GERENCIAMIENTO PARA CONSULTAR AL CDC
            Dim OCreditoConsumo As IDataReader = OHelper.RecuperarDatosVehiculoConGerenciamientoFullstation(Cara, IdProducto, Identificacion, TipoIdentificacion)

            If OCreditoConsumo.Read Then
                Placa = OCreditoConsumo.Item("Placa")

                RespuestaCreditoConsumo = ServerServices.CDCServices.AutorizarVentaGerenciamiento(CInt(OCreditoConsumo.Item("IdProducto")), Placa, CDec(OCreditoConsumo.Item("PrecioProducto")), "0", RucCoductor)
                If Not RespuestaCreditoConsumo Is Nothing Then
                    If RespuestaCreditoConsumo.EsAutorizado = True Then
                        Dim OCredito As CreditoFullstation
                        OCredito = CreditosEstacion.Item(Cara.ToString())
                        OCredito.Autorizacion = RespuestaCreditoConsumo.IdAutorizacion
                        OCredito.FormaPago = RespuestaCreditoConsumo.IdFormaPago
                        OCredito.SaldoDisponible = RespuestaCreditoConsumo.SaldoDisponible
                        OCredito.EsEfectivo = False

                        CreditosEstacion.Item(Cara.ToString()) = OCredito

                        If OPreset.TipoPreset = Preset.Tipo.PorValor And OPreset.Valor > 0 Then
                            If OPreset.Valor > RespuestaCreditoConsumo.ValorAutorizado Then
                                OPreset.Valor = RespuestaCreditoConsumo.ValorAutorizado
                            End If
                        ElseIf OPreset.TipoPreset = Preset.Tipo.PorVolumen And OPreset.Valor > 0 Then
                            If OPreset.Valor * CDec(OCreditoConsumo.Item("PrecioProducto")) > RespuestaCreditoConsumo.ValorAutorizado Then
                                OPreset.Valor = RespuestaCreditoConsumo.ValorAutorizado
                                OPreset.TipoPreset = Preset.Tipo.PorValor
                            Else
                                OPreset.Valor = OPreset.Valor * CDec(OCreditoConsumo.Item("PrecioProducto"))
                                OPreset.TipoPreset = Preset.Tipo.PorValor
                            End If
                        Else
                            OPreset.Valor = RespuestaCreditoConsumo.ValorAutorizado
                            OPreset.TipoPreset = Preset.Tipo.PorValor
                        End If
                        'oEventos.AutorizarVenta(Cara, OHelper.RecuperarPrecioPorCliente(Placa).ToString("N"), CDec(OPreset.Valor).ToString("N2"), OPreset.TipoPreset, Placa, -1, True)
                        oEventos_VentaAutorizada(Cara, OHelper.RecuperarPrecioPorCliente(Placa).ToString("N"), CDec(OPreset.Valor).ToString("N2"), OPreset.TipoPreset, Placa, -1, True, guid)
                        EsAutorizado = True
                    Else
                        LogCategorias.Clear()
                        LogCategorias.Agregar("Gerenciamiento")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Identificacion", Identificacion)
                        LogPropiedades.Agregar("TipoIdentificacion", TipoIdentificacion)
                        LogPropiedades.Agregar("Placa", Placa)
                        LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                        LogPropiedades.Agregar("MensajeCDC", RespuestaCreditoConsumo.MensajeError)
                        Fabrica.LogIt.Loguear("Respuesta del CDC", LogPropiedades, LogCategorias)

                        RomEstacion(Cara.ToString) = ""
                        If DocumentosVenta.ContainsKey(Cara.ToString) Then
                            DocumentosVenta.Remove(Cara.ToString)
                        End If
                        If CreditosEstacion.ContainsKey(Cara.ToString) Then
                            CreditosEstacion.Remove(Cara.ToString)
                        End If

                        ImpresoraRecibo.ImprimirErrorCreditoConsumo(ImpresoraEstacion.CrearImpresora(Cara), Placa, Cara.ToString, RespuestaCreditoConsumo.MensajeError)
                        EsAutorizado = False
                    End If
                Else
                    LogCategorias.Clear()
                    LogCategorias.Agregar("Gerenciamiento")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Identificacion", Identificacion)
                    LogPropiedades.Agregar("TipoIdentificacion", TipoIdentificacion)
                    LogPropiedades.Agregar("Placa", Placa)
                    LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                    Fabrica.LogIt.Loguear("Falla en comunicacion de CDC", LogPropiedades, LogCategorias)

                    RomEstacion(Cara.ToString) = ""
                    If DocumentosVenta.ContainsKey(Cara.ToString) Then
                        DocumentosVenta.Remove(Cara.ToString)
                    End If

                    If CreditosEstacion.ContainsKey(Cara.ToString) Then
                        CreditosEstacion.Remove(Cara.ToString)
                    End If

                    ImpresoraRecibo.ImprimirErrorCreditoConsumo(ImpresoraEstacion.CrearImpresora(Cara), Placa, Cara.ToString)
                    EsAutorizado = False
                End If
            Else
                EsAutorizado = False
            End If

            OCreditoConsumo.Close()
            OCreditoConsumo = Nothing
        Catch ex As System.Exception
            EsAutorizado = False
            LogFallas.ReportarError(ex, "AutorizarVentaCreditoCRMStation", "Cara: " & Cara & ", IdProducto: " & IdProducto & ", Identificacion: " & Identificacion & ", TipoIdentificacion: " & TipoIdentificacion, "Autorizacion CRM Station")
            Throw
        End Try

        Return EsAutorizado
    End Function

#End Region

    '---------------------------EVENTOS RELACIONADOS CON EL REGISTRO DE PAGOS EXTRAORDINARIOS-----------------------------------
#Region "Eventos de Registro de Pagos Extraordinarios"

    'Lista Implementacion Para FullStation
    'Private Sub oEventos_RegistrarPagoExtraOrdinarioPorIdentificador(ByRef empleado As String, ByRef clave As String, ByRef cara As Byte, ByRef valor As String) Handles OEventos.RegistrarPagoExtraOrdinarioPorIdentificador
    '    Try
    '        Dim OHelper As New Helper

    '        Dim OIdentificador As InformacionChip = OHelper.RecuperarInformacionIdentificador(cara)

    '        Dim Id As Int32 = OHelper.InsertarPagoExtraOrdinario(empleado, clave, OIdentificador.Placa, valor)

    '        Dim Puerto As String = OHelper.RecuperarPuertoCapturadorPorCara(cara)

    '        If String.IsNullOrEmpty(Puerto) Then
    '            OEventos.ReportarPagoExtraordinarioFinalizado(Id, OHelper.RecuperarParametro("CapturadorPorDefecto"))
    '        Else
    '            OEventos.ReportarPagoExtraordinarioFinalizado(Id, Puerto)
    '        End If

    '    Catch EXBD As Data.DataException
    '        LogFallas.ReportarError(EXBD, "oEventos_RegistrarPagoExtraOrdinarioPorIdentificador", "Empleado: " & empleado & ", Clave: " & clave & ", Cara: " & cara & ", Valor: " & valor, "Pagos")
    '        OEventos.ReportarExcepcion(EXBD.Message, True, False)
    '    Catch EXSQL As Data.SqlClient.SqlException
    '        LogFallas.ReportarError(EXSQL, "oEventos_RegistrarPagoExtraOrdinarioPorIdentificador", "Empleado: " & empleado & ", Clave: " & clave & ", Cara: " & cara & ", Valor: " & valor, "Pagos")
    '        OEventos.ReportarExcepcion(EXSQL.Message, True, False)
    '    Catch ex As System.exception
    '        LogFallas.ReportarError(Ex, "oEventos_RegistrarPagoExtraOrdinarioPorIdentificador", "Empleado: " & empleado & ", Clave: " & clave & ", Cara: " & cara & ", Valor: " & valor, "Pagos")
    '        OEventos.ReportarExcepcion(Ex.Message, True, False)
    '    End Try
    'End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_RegistrarPagoExtraOrdinarioPorVenta(ByRef empleado As String, ByRef clave As String, ByRef consecutivo As String, ByRef credito As String, ByRef idFinanciera As Integer, ByRef valor As String, ByRef puerto As String) Handles OEventos.RegistrarPagoExtraOrdinarioPorVenta
        Try
            Dim OHelper As New Helper


            Dim Id As Int32 = OHelper.InsertarPagoExtraOrdinarioPorVenta(empleado, clave, CLng(consecutivo), credito, valor, -1)

            'OEventos.ReportarPagoExtraordinarioFinalizado(Id, puerto, "0")

        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "Eventos_RegistrarPagoExtraOrdinarioPorVenta", "Empleado: " & empleado & ", Clave: " & clave & ", Consecutivo: " & consecutivo & ", Valor: " & valor & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "Eventos_RegistrarPagoExtraOrdinarioPorVenta", "Empleado: " & empleado & ", Clave: " & clave & ", Consecutivo: " & consecutivo & ", Valor: " & valor & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "Eventos_RegistrarPagoExtraOrdinarioPorVenta", "Empleado: " & empleado & ", Clave: " & clave & ", Consecutivo: " & consecutivo & ", Valor: " & valor & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_RegistroPagoExtraordinarioFinalizado(ByRef pago As Integer, ByRef puerto As String, ByRef pagoTotal As String) Handles OEventos.RegistroPagoExtraordinarioFinalizado
        ImpresoraRecibo.ImprimirReciboAbono(pago, New ImpresoraEstacion(puerto))
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_InsercionPagoExtraordinarioFallida(ByRef mensaje As String, ByRef puerto As String) Handles OEventos.InsercionPagoExtraordinarioFallida
        ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
    End Sub

#End Region

    '------------------------EVENTOS RELACIONADOS CON EL REGISTRO DE REVERSIONES DE PAGOS---------------------------------------
#Region "Eventos de Registro de Reversion de pagos"

    'Lista Implementacion Para FullStation
    Private Sub oEventos_RegistrarReversion(ByRef empleado As String, ByRef clave As String, ByRef consecutivo As String, ByRef puerto As String) Handles OEventos.RegistrarReversion
        Try
            Dim OHelper As New Helper

            OHelper.InsertarReversion(empleado, clave, CLng(consecutivo))
            'OEventos.ReportarRegistroReversionFinalizado(consecutivo, puerto)
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_RegistrarReversion", "Empleado: " & empleado & ", Clave: " & clave & ", Consecutivo: " & consecutivo & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_RegistrarReversion", "Empleado: " & empleado & ", Clave: " & clave & ", Consecutivo: " & consecutivo & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_RegistrarReversion", "Empleado: " & empleado & ", Clave: " & clave & ", Consecutivo: " & consecutivo & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_RegistroReversionFinalizado(ByRef consecutivo As String, ByRef puerto As String) Handles OEventos.RegistroReversionFinalizado
        Try
            Dim OHelper As Helper = New Helper
            Dim IdReversion As Int32 = OHelper.RecuperarIdreversion(CLng(consecutivo))
            ImpresoraRecibo.ImprimirReciboReversion(IdReversion, New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_RegistroReversionFinalizado", "Consecutivo: " & consecutivo & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_RegistroReversionFinalizado", "Consecutivo: " & consecutivo & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_RegistroReversionFinalizado", "Consecutivo: " & consecutivo & ", Puerto: " & puerto, "Pagos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_InsercionReversionFallida(ByRef mensaje As String, ByRef puerto As String) Handles OEventos.InsercionReversionFallida
        ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
    End Sub

#End Region

    '-------------------------------------------------EVENTOS DE IMPRESION------------------------------------------------------
#Region "Eventos de Impresion y Reimpresion de Recibos"

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ReimprimirReciboAbono(ByRef ConsecutivoPrm As String, ByRef puertoPrm As String) Handles OEventos.ReimprimirReciboAbono
        Try
            ImpresoraRecibo.ImprimirReciboAbono(CInt(ConsecutivoPrm), New ImpresoraEstacion(puertoPrm, True))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReimprimirReciboAbono", "Consecutivo: " & ConsecutivoPrm & ", Puerto: " & puertoPrm, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReimprimirReciboAbono", "Consecutivo: " & ConsecutivoPrm & ", Puerto: " & puertoPrm, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReimprimirReciboAbono", "Consecutivo: " & ConsecutivoPrm & ", Puerto: " & puertoPrm, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            Throw
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ReimprimirReciboPorCara(ByRef cara As Byte, ByRef puerto As String) Handles OEventos.ReimprimirReciboPorCara

        Try

            LogCategorias.Clear()
            LogPropiedades.Clear()
            LogPropiedades.Agregar("puerto", puerto)
            LogPropiedades.Agregar("Fecha", Now.ToString)
            LogPropiedades.Agregar("cara", cara)
            POSstation.Fabrica.LogIt.Loguear("Antes de Imprimir oEventos_ReimprimirReciboPorCara", LogPropiedades, LogCategorias)

            Dim imp As New ImpresoraEstacion(puerto, True)
            ImpresoraRecibo.ImprimirRecibo(cara, imp)

            LogCategorias.Clear()
            LogPropiedades.Clear()
            LogPropiedades.Agregar("puerto", puerto)
            LogPropiedades.Agregar("impresora", imp.Nombre)
            LogPropiedades.Agregar("Fecha", Now.ToString)
            LogPropiedades.Agregar("cara", cara)
            POSstation.Fabrica.LogIt.Loguear("Despues de Imprimir oEventos_ReimprimirReciboPorCara", LogPropiedades, LogCategorias)

        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReimprimirReciboPorCara", "Cara: " & cara & ", Puerto: " & puerto, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReimprimirReciboPorCara", "Cara: " & cara & ", Puerto: " & puerto, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReimprimirReciboPorCara", "Cara: " & cara & ", Puerto: " & puerto, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
            Throw
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    'Private Sub oEventos_ReimprimirReciboPorConsecutivo(ByRef consecutivo As String, ByRef puerto As String, ByRef esOriginal As Boolean) Handles OEventos.ReimprimirReciboPorConsecutivo
    Private Sub oEventos_ReimprimirReciboPorConsecutivo(consecutivo As String, puerto As String, esOriginal As Boolean)
        Try
            If Not esOriginal Then
                ImpresoraRecibo.ImprimirRecibo(CLng(consecutivo), New ImpresoraEstacion(puerto, True))
            Else
                ImpresoraRecibo.ImprimirRecibo(CLng(consecutivo), New ImpresoraEstacion(puerto, False))
            End If
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReimprimirReciboPorConsecutivo", "Consecutivo: " & consecutivo & ", Puerto: " & puerto, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            'My.Application.Log.WriteException(EXBD)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReimprimirReciboPorConsecutivo", "Consecutivo: " & consecutivo & ", Puerto: " & puerto, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            'My.Application.Log.WriteException(EXSQL)
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReimprimirReciboPorConsecutivo", "Consecutivo: " & consecutivo & ", Puerto: " & puerto, "ImpresionRecibos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            'My.Application.Log.WriteException(ex)
            Throw

        End Try
    End Sub


    'Lista Implementacion Para FullStation
    Private Sub oEventos_ImpresionReciboAbonoFallida(ByRef mensaje As String, ByRef puerto As String) Handles OEventos.ImpresionReciboAbonoFallida
        ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
    End Sub


    'Lista Implementacion Para FullStation
    Private Sub oEventos_ImpresionReciboFallida(ByRef mensaje As String, ByRef puerto As String) Handles OEventos.ImpresionReciboFallida
        ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
    End Sub

#End Region


#Region "Eventos de Impresion y ReImpresion de Turnos"


    'Lista Implementacion Para FullStation
    'Private Sub oEventos_ReimprimirTurnoPorEmpleado(ByRef cedula As String, ByRef fecha As String, ByRef puerto As String) Handles OEventos.ReimprimirTurnoPorEmpleado
    Private Sub oEventos_ReimprimirTurnoPorEmpleado(cedula As String, fecha As String, puerto As String)
        Try
            ImpresoraTurno.ImprimirTurno(CLng(cedula).ToString(), fecha, New ImpresoraEstacion(puerto, True))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReimprimirTurnoPorEmpleado", "Cedula: " & cedula & ", Puerto: " & puerto & ", Fecha: " & fecha, "ImpresionTurnos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReimprimirTurnoPorEmpleado", "Cedula: " & cedula & ", Puerto: " & puerto & ", Fecha: " & fecha, "ImpresionTurnos")
            ' OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReimprimirTurnoPorEmpleado", "Cedula: " & cedula & ", Puerto: " & puerto & ", Fecha: " & fecha, "ImpresionTurnos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
            Throw
        End Try
    End Sub

    Private Sub oEventos_ReimprimirTurnoFrecuenciaPorEmpleado(cedula As String, fecha As String, puerto As String)
        Try
            ImpresoraTurno.ImprimirTurnoFrecuencia(CLng(cedula).ToString(), fecha, New ImpresoraEstacion(puerto, True))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReimprimirTurnoFrecuenciaPorEmpleado", "Cedula: " & cedula & ", Puerto: " & puerto & ", Fecha: " & fecha, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReimprimirTurnoFrecuenciaPorEmpleado", "Cedula: " & cedula & ", Puerto: " & puerto & ", Fecha: " & fecha, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReimprimirTurnoFrecuenciaPorEmpleado", "Cedula: " & cedula & ", Puerto: " & puerto & ", Fecha: " & fecha, "ImpresionTurnos")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
            Throw
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    'Private Sub oEventos_ReimprimirTurnoPorSurtidor(ByRef numero As Byte, ByRef fecha As String, ByRef surtidor As Byte, ByRef puerto As String) Handles OEventos.ReimprimirTurnoPorSurtidor
    Private Sub oEventos_ReimprimirTurnoPorSurtidor(numero As Byte, fecha As String, surtidor As Byte, puerto As String)
        Try
            ImpresoraTurno.ImprimirTurno(surtidor, numero, fecha, New ImpresoraEstacion(puerto, True))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReimprimirTurnoPorSurtidor", "Numero: " & numero & ", Puerto: " & puerto & ", Surtidor: " & surtidor & ", Fecha: " & fecha, "ImpresionTurnos")
            My.Application.Log.WriteException(EXBD)
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReimprimirTurnoPorSurtidor", "Numero: " & numero & ", Puerto: " & puerto & ", Surtidor: " & surtidor & ", Fecha: " & fecha, "ImpresionTurnos")
            My.Application.Log.WriteException(EXSQL)
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReimprimirTurnoPorSurtidor", "Numero: " & numero & ", Puerto: " & puerto & ", Surtidor: " & surtidor & ", Fecha: " & fecha, "ImpresionTurnos")
            My.Application.Log.WriteException(ex)
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            Throw
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    'Private Sub oEventos_ImprimirArqueo(ByRef cedula As String, ByRef clave As String, ByRef puerto As String) Handles OEventos.ImprimirArqueo

    Private Sub oEventos_ImprimirArqueo(cedula As String, clave As String, puerto As String)
        Try
            Dim OHelper As New Helper
            If OHelper.ValidarCredenciales(cedula, clave) Then
                ImpresoraTurno.ImprimirTurno(cedula, New ImpresoraEstacion(puerto, False, True))
            Else
                Throw New GasolutionsException("Credenciales Invalidas")
            End If

        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirArqueo", "Cedula: " & cedula & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
            My.Application.Log.WriteException(EXBD)
            ' OEventos.ReportarExcepcion(EXBD.Message, True, False)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirArqueo", "Cedula: " & cedula & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
            My.Application.Log.WriteException(EXSQL)
            ' OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ImprimirArqueo", "Cedula: " & cedula & ", Clave: " & clave & ", Puerto: " & puerto, "ImpresionTurnos")
            My.Application.Log.WriteException(ex)
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            Throw
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ImpresionTurnoFallida(ByRef mensaje As String, ByRef puerto As String) Handles OEventos.ImpresionTurnoFallida
        ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
    End Sub

    'Lista Implementacion Para FullStation (Pendiente Revisar Sp para ver si se afecta)

    ' Private Sub oEventos_ImprimirResumenDiario(ByRef fecha As String, ByRef esMrCombustible As Boolean, ByRef puerto As String) Handles OEventos.ImprimirResumenDiario
    Private Sub oEventos_ImprimirResumenDiario(fecha As String, esMrCombustible As Boolean, puerto As String)
        Dim OHelper As New Helper
        Try

            If CDate(fecha.Substring(6, 2) & "/" & fecha.Substring(4, 2) & "/" & fecha.Substring(0, 4)) < Now.Date Then
                'ImpresoraTurno.ImprimirResumenDiario(fecha, New ImpresoraEstacion(puerto))
                If OHelper.ValidarCierreDia(fecha) Then
                    ImpresoraTurno.ImprimirResumenDiario(fecha, New ImpresoraEstacion(puerto))
                Else
                    ImpresoraTurno.ImprimirExcepcion("Error en Cierre de Dia: existen turnos  abiertos para el dia: " & fecha.Substring(6, 2) & "/" & fecha.Substring(4, 2) & "/" & fecha.Substring(0, 4), New ImpresoraEstacion(puerto))
                End If
            Else
                ImpresoraTurno.ImprimirExcepcion("Debe Realizar Cierres de Dia Menores al Actual", New ImpresoraEstacion(puerto))
            End If
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirResumenDiario", "Fecha: " & fecha & ", Puerto: " & puerto, "ImpresionTurnos")
            My.Application.Log.WriteException(EXBD)
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirResumenDiario", "Fecha: " & fecha & ", Puerto: " & puerto, "ImpresionTurnos")
            My.Application.Log.WriteException(EXSQL)
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ImprimirResumenDiario", "Fecha: " & fecha & ", Puerto: " & puerto, "ImpresionTurnos")
            My.Application.Log.WriteException(ex)
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub

#End Region


#Region "Eventos de Impresion de Facturas de Canastillas"

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ImprimirVentaCanastilla(ByRef numero As String, ByRef puerto As String, ByRef nroTarjeta As String, ByRef saldo As String) Handles OEventos.ImprimirVentaCanastilla
        Try
            ImpresoraCanastilla.ImprimirFactura(CInt(numero), New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirVentaCanastilla", "Numero: " & numero & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirVentaCanastilla", "Numero: " & numero & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ImprimirVentaCanastilla", "Numero: " & numero & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ReImprimirVentaCanastilla(ByRef numero As String, ByRef puerto As String) Handles OEventos.ReImprimirVentaCanastilla
        Try
            ImpresoraCanastilla.ImprimirFactura(CInt(numero), New ImpresoraEstacion(puerto, True))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ReImprimirVentaCanastilla", "Numero: " & numero & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXBD)
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ReImprimirVentaCanastilla", "Numero: " & numero & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(EXSQL)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ReImprimirVentaCanastilla", "Numero: " & numero & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            My.Application.Log.WriteException(ex)
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_AnularFacturaCanastilla(consecutivoPrm As String, cedulaPrm As String, clavePrm As String, ByRef puertoPrm As String) ' Handles OEventos.AnularFacturaCanastilla
        Try
            Dim OHelper As New Helper
            OHelper.AnularFactura(CInt(consecutivoPrm), cedulaPrm, clavePrm)
            ImpresoraCanastilla.ImprimirNotaCredito(CInt(consecutivoPrm), New ImpresoraEstacion(puertoPrm))
        Catch EXSQL As Data.SqlClient.SqlException
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion(puertoPrm))
            LogFallas.ReportarError(EXSQL, "oEventos_AnularFacturaCanastilla", "Consecutivo: " & consecutivoPrm & ", Cedula: " & cedulaPrm & ", Clave: " & clavePrm, "Canastilla")
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puertoPrm))
            LogFallas.ReportarError(ex, "oEventos_AnularFacturaCanastilla", "Consecutivo: " & consecutivoPrm & ", Cedula: " & cedulaPrm & ", Clave: " & clavePrm, "Canastilla")
        End Try
    End Sub


    'Private Sub OEventos_CambioCheque(ByRef numeroAutorizacion As String, ByRef idTurno As Integer, ByRef cara As Byte, ByRef recibo As String, ByRef valorCambio As Double, ByRef valorCliente As Double, ByRef puerto As String) Handles OEventos.EnviarCambioCheque
    '    Try
    '        Dim oHelper As New Helper()
    '        'Mandamos a insertar en la base de datos
    '        oHelper.InsertarCambioCheque(CLng(numeroAutorizacion), CDec(valorCliente), idTurno, CLng(recibo), CShort(cara))
    '        'Mandamos a imprimir la información
    '        ImpresoraRecibo.ImprimirCambioCheque(CShort(cara), idTurno, CLng(recibo), CLng(numeroAutorizacion), CDec(valorCliente), ImpresoraEstacion.CrearImpresora(puerto, True))
    '    Catch ex As System.exception
    '        ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
    '        LogFallas.ReportarError(ex, "OEventos_CambioCheque", "NumeroAutorizacion: " & numeroAutorizacion & ", IdTurno: " & CStr(idTurno) & ", Cara: " & CStr(cara) & ", Recibo: " & recibo & ", ValorCambio: " & CStr(valorCambio) & ", ValorCliente: " & CStr(valorCliente) & ", Puerto: " & puerto, "FacturaCanastilla")
    '    End Try
    'End Sub


#End Region

    '--------------------------------------------------EVENTOS GENERALES--------------------------------------------------------
#Region "Eventos Generales"

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ErrorComunicacion(ByRef cara As Byte) Handles OEventos.ErrorComunicacion
        ImpresoraTurno.ImprimirExcepcion("Error de comunicacion con cara: " & cara, ImpresoraEstacion.CrearImpresora(cara))
    End Sub

    'Lista Implementacion Para FullStation
    'Private Sub oEventos_ExcepcionOcurrida(ByRef mensaje As String, ByRef imprime As Boolean, ByRef terminal As Boolean, ByRef puerto As String) Handles OEventos.ExcepcionOcurrida
    Private Sub oEventos_ExcepcionOcurrida(mensaje As String, imprime As Boolean, terminal As Boolean, puerto As String)
        Dim OHelper As New Helper
        If String.IsNullOrEmpty(puerto) Then
            ImpresoraTurno.ImprimirExcepcion(mensaje, ImpresoraEstacion.CrearImpresora)
        Else
            ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
        End If

    End Sub



    Private Sub oEventos_SolicitudDatosIbutton(cara As Byte, puerto As String)
        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("Ibutton")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Cara", cara.ToString())
            Fabrica.LogIt.Loguear("Se solicita la lectura del ibutton", LogPropiedades, LogCategorias)


            Dim OHelper As New Helper
            If ColDispositivosLSIB4.ContainsKey(cara.ToString) Then
                Dim OPlaca As New InformacionVehiculo
                OPlaca = EsperarDatosChipLectorDtiImpresionTicket(cara)

                If String.IsNullOrEmpty(OPlaca.Placa) Then
                    ImpresoraRecibo.ImpresionDatosIdentificadorGasolina(OPlaca.Rom, ImpresoraEstacion.CrearImpresora(cara))
                Else
                    ImpresoraRecibo.ImpresionDatosIdentificadorDti(OPlaca.FechaProximoMantenimiento, OPlaca.Placa, OPlaca.Rom, ImpresoraEstacion.CrearImpresora(cara))

                End If
            Else
                Dim OIdentificador As InformacionChip = OHelper.RecuperarInformacionIdentificador(cara)
                ImpresoraRecibo.ImpresionDatosIdentificador(OIdentificador.FechaConversion, OIdentificador.FechaProximoMantenimiento, OIdentificador.Numero, OIdentificador.Placa, OIdentificador.Rom, ImpresoraEstacion.CrearImpresora(cara))
            End If

        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_SolicitudDatosIbutton", "Cara: " & cara & ", Puerto: " & puerto, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, ImpresoraEstacion.CrearImpresora(cara))
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_SolicitudDatosIbutton", "Cara: " & cara & ", Puerto: " & puerto, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, ImpresoraEstacion.CrearImpresora(cara))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_SolicitudDatosIbutton", "Cara: " & cara & ", Puerto: " & puerto, "Ibutton")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
        End Try
    End Sub

    Private Sub oEventos_SolicitudDatosIbuttonImpresionArm(ByVal cara As Byte, ByRef DatosChip As String)
        Try

            Dim oHelper As New Helper
            Dim PuertoLectorUsb As String = ""
            Dim Datos As New System.Text.StringBuilder
            Dim FechaConversion As String = "", FechaProximoMantenimiento As String = "", Numero As String = "", Placa As String = "", Rom As String = ""


            If ColDispositivosLSIB4.ContainsKey(cara.ToString) Then
                LogCategorias.Clear()
                LogCategorias.Agregar("Ibutton")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Cara", cara.ToString())
                Fabrica.LogIt.Loguear("Se solicita la lectura del ibutton DTI", LogPropiedades, LogCategorias)

                Dim OPlaca As New InformacionVehiculo
                OPlaca = EsperarDatosChipLectorDtiImpresionTicket(cara.ToString)
                FechaConversion = OPlaca.FechaConversion
                FechaProximoMantenimiento = OPlaca.FechaProximoMantenimiento
                Numero = OPlaca.Numero
                Placa = OPlaca.Placa
                Rom = OPlaca.Rom

                LogCategorias.Clear()
                LogCategorias.Agregar("SeguimientoCodigoDTI")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Cara", cara.ToString())
                LogPropiedades.Agregar("Rom", OPlaca.Rom)
                Fabrica.LogIt.Loguear("Ibutton Leido DTI", LogPropiedades, LogCategorias)

            Else
                LogCategorias.Clear()
                LogCategorias.Agregar("Ibutton")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Cara", cara.ToString())
                LogPropiedades.Agregar("No se Encontro un LectorLsib-4 conectado para la cara", cara.ToString())
                Fabrica.LogIt.Loguear("Lectura Chip Lsib4", LogPropiedades, LogCategorias)


                Dim OIdentificador As InformacionChip
                OIdentificador = oHelper.RecuperarInformacionIdentificador(cara)

                FechaConversion = OIdentificador.FechaConversion
                FechaProximoMantenimiento = OIdentificador.FechaProximoMantenimiento
                Numero = OIdentificador.Numero.ToString("N0")
                Placa = OIdentificador.Placa
                Rom = OIdentificador.Rom
            End If

            Datos.AppendLine("ROM: " & Rom)
            Datos.AppendLine("Placa: " & Placa)
            Datos.AppendLine("Conversion: " & FechaConversion)
            Datos.AppendLine("Proximo Mantenimiento: " & FechaProximoMantenimiento)
            Datos.AppendLine("Numero: " & Numero)

            DatosChip = Datos.ToString

        Catch Ex As System.Exception
            Throw
        End Try
    End Sub



#End Region
    '**************************************** descomentado Para probar Display Station 
    '-----------------------------------------------EVENTOS PARA ACTUALIZAR SERVICIOS WEB----------------------------------------
#Region "Eventos Para Actualizar Servicios Web"
    Private Sub oEventos_CambioPrecio(ByRef cara As Byte, ByRef valor As String) Handles OEventos.CambioPrecio
        Dim OHelper As New Helper
        Try
            OHelper.ActualizarPrecioCaraDisplay(CInt(cara), CDbl(valor))
        Catch exbd As Data.DataException
            LogFallas.ReportarError(exbd, "oEventos_CambioPrecio", "Cara: " & cara & ", Valor: " & valor, "DisplayWeb")
        Catch exsql As Data.SqlClient.SqlException
            LogFallas.ReportarError(exsql, "oEventos_CambioPrecio", "Cara: " & cara & ", Valor: " & valor, "DisplayWeb")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_CambioPrecio", "Cara: " & cara & ", Valor: " & valor, "DisplayWeb")
        End Try
    End Sub

    Private Sub oEventos_TurnoAbierto(ByRef surtidores As String, ByRef puerto As String, ByRef precioGas As String) ' Handles OEventos.TurnoAbierto
        Dim OHelper As New Helper
        Try
            OHelper.ActualizarEstadoTurnoCaraDisplay(surtidores, "Turno Abierto")
        Catch exbd As Data.DataException
            LogFallas.ReportarError(exbd, "Eventos_TurnoAbierto", "Surtidores: " & surtidores & ", Puerto: " & puerto, "DisplayWeb")
        Catch exsql As Data.SqlClient.SqlException
            LogFallas.ReportarError(exsql, "Eventos_TurnoAbierto", "Surtidores: " & surtidores & ", Puerto: " & puerto, "DisplayWeb")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "Eventos_TurnoAbierto", "Surtidores: " & surtidores & ", Puerto: " & puerto, "DisplayWeb")
        End Try
    End Sub

    Private Sub oEventos_TurnoCerrado(ByRef surtidores As String, ByRef puerto As String) Handles OEventos.TurnoCerrado
        Dim OHelper As New Helper
        Try
            OHelper.ActualizarEstadoTurnoCaraDisplay(surtidores, "Turno Cerrado")
        Catch exbd As Data.DataException
            LogFallas.ReportarError(exbd, "oEventos_TurnoCerrado", "Surtidores: " & surtidores & ", Puerto: " & puerto, "DisplayWeb")
        Catch exsql As Data.SqlClient.SqlException
            LogFallas.ReportarError(exsql, "oEventos_TurnoCerrado", "Surtidores: " & surtidores & ", Puerto: " & puerto, "DisplayWeb")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_TurnoCerrado", "Surtidores: " & surtidores & ", Puerto: " & puerto, "DisplayWeb")
        End Try

    End Sub


    ''Agregado para la implementacion del Display Station

    Private Sub VentaParcial(Datos As DatosTemporalesSauce)
        Try
            Dim Service As ServiceSharedEventClient = Nothing
            Dim cara As String = Datos.Cara
            Try
                Dim EnEjecucion As Boolean = False
                EnEjecucion = Process.GetProcessesByName("DisplayStation").Length > 0

                If EnEjecucion Then
                    Service = New ServiceSharedEventClient
                    Service.VentaParcial(Datos.Cara, Datos.Valor, Datos.Cantidad)
                    If Not Service Is Nothing Then
                        If Service.State = ServiceModel.CommunicationState.Opened Then
                            Service.Close()
                        End If
                    End If
                End If

            Catch ex As System.Exception
                LogCategorias.Clear()
                LogCategorias.Agregar("WCF")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Cara", cara)
                POSstation.Fabrica.LogIt.Loguear("Error al Localizar el EndPoint: " & ex.Message, LogPropiedades, LogCategorias)
            End Try
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "VentaParcial", " Proceso asincrono del informar al display ", "General")
        End Try
    End Sub


    ''Fin Agregado para la implementacion del Display Station


    Private Sub oEventos_VentaParcial(cara As Byte, valor As String, cantidad As String) 'Handles OEventos.VentaParcial
        Dim OHelper As New Helper
        Try
            Dim datos As New DatosTemporalesSauce
            datos.Cara = cara
            datos.Valor = valor
            datos.Cantidad = cantidad
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf VentaParcial), datos)

            Dim Placa As String = OHelper.RecuperarPlacaParcialVenta(cara.ToString)
            OHelper.ActualizarPropiedadesCaraDisplay(CInt(cara), "Vendiendo", CDbl(valor), CDbl(cantidad), Placa)
        Catch exbd As Data.DataException
            LogFallas.ReportarError(exbd, "oEventos_VentaParcial", "Cara: " & cara & ", Valor: " & valor & ", Cantidad: " & cantidad, "DisplayWeb")
        Catch exsql As Data.SqlClient.SqlException
            LogFallas.ReportarError(exsql, "oEventos_VentaParcial", "Cara: " & cara & ", Valor: " & valor & ", Cantidad: " & cantidad, "DisplayWeb")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_VentaParcial", "Cara: " & cara & ", Valor: " & valor & ", Cantidad: " & cantidad, "DisplayWeb")
        End Try
    End Sub

    Private Sub oEventos_ManipulacionTeclado(ByRef cara As Byte) Handles OEventos.ManipulacionTeclado
        Dim OHelper As New Helper
        Try
            OHelper.ActualizarEstadoCaraDisplay(CInt(cara), "Teclado")
        Catch exbd As Data.DataException
            LogFallas.ReportarError(exbd, "oEventos_ManipulacionTeclado", "Cara: " & cara, "DisplayWeb")
        Catch exsql As Data.SqlClient.SqlException
            LogFallas.ReportarError(exsql, "oEventos_ManipulacionTeclado", "Cara: " & cara, "DisplayWeb")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ManipulacionTeclado", "Cara: " & cara, "DisplayWeb")
        End Try
    End Sub

#End Region

    '*************  fffiiinnnn  descomentado Para probar Display Station ******************

    Private Function Predeterminar(cara As Byte, valor As String, ByRef tipo As Short, idProducto As Short) As String
        Dim OHelper As New Helper
        Dim precio, valorReal As Decimal

        valorReal = CDec(valor)

        If OHelper.ExisteManejoCarroTanque(cara) Then
            If CType(tipo, Preset.Tipo) = Preset.Tipo.PorValor Then
                precio = OHelper.RecuperarPrecioVigenteProducto(idProducto)
                valorReal = valorReal / precio
                valorReal = valorReal.ToString("N2")
                tipo = Preset.Tipo.PorVolumen
            End If
        End If

        Return CStr(valorReal)
    End Function


    'Lista Implementacion Para FullStation
    Private Sub oEventos_Preset(cara As Byte, valor As String, tipo As Short, idProducto As Short, puerto As String)
        Dim OHelper As New Helper
        Dim ValorReal As String

        If OHelper.ExisteCara(cara) Then
            If OHelper.ExisteManejoCarroTanque(cara) Then
                ''Envio la predeterminacion por volumen al protocolo MR3 
                If valor <> 0 Then
                    idProducto = CShort(OHelper.RecuperarProductoPorManguera(1))
                    ValorReal = Me.Predeterminar(1, valor, tipo, idProducto) ''Siempre se manda uno porque el Protocolo MR3 solo soporta una manguera, en este caso debe ser 1
                    ListaProtocolos_PredeterminarMR3(cara, ValorReal, tipo)
                End If
            Else
                If ColPreset.ContainsKey(cara) Then
                    ColPreset.Remove(cara)
                End If
                ColPreset.Add(CStr(cara), New Preset(valor, CType(tipo, Preset.Tipo)))
            End If
        Else
            OHelper.InsertarAutorizacionFallidaLogueo(cara.ToString(), "", "", "", "", "", "Error predeterminando la venta - La Cara (" & cara & ") No existe. Valor: " + valor.ToString() + ", Tipo de Predeterminacion: " + tipo.ToString(), "")

            If Not String.IsNullOrEmpty(puerto) Then
                ImpresoraTurno.ImprimirExcepcion("La Cara (" & cara & ") No existe", New ImpresoraEstacion(puerto))
            End If
        End If
    End Sub

    Private Sub oEventos_EnviarDatosMenoCash(cara As Byte)
        Try
            Dim oDatosMenoCash As New MenoCash
            If DatosMenoCash.ContainsKey(cara.ToString()) Then
                DatosMenoCash.Remove(cara.ToString)
                DatosMenoCash.Add(CStr(cara), oDatosMenoCash)
            Else
                DatosMenoCash.Add(CStr(cara), oDatosMenoCash)
            End If
        Catch ex As System.Exception

        End Try
    End Sub


    Private Sub OEventos_CambioPrecioFallido(idManguera As Integer, precio As Double)
        Try
            Dim OHelper As New Helper
            OHelper.ReportarCambioPrecioFallido(CShort(idManguera), CDec(precio))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_CambioPrecioFallido", "IdManguera: " & idManguera & " , Precio: " & precio, "CambioPrecio")
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ModificarVenta(ByRef recibo As Integer, ByRef FormasPago As System.Array, ByRef puerto As String) Handles OEventos.ModificarVenta
        Dim oHelper As New Helper
        Try
            Dim imp As New ImpresoraEstacion(puerto)
            imp.ESCopia = True
            ImpresoraRecibo.ImprimirRecibo(recibo, imp, True)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
            For Each FormaPago As DTOMedioPago In FormasPago
                oHelper.InsertarCambioFormaPagoFallida(FormaPago.Descripcion, recibo, "", ex.Message)
            Next
        End Try
    End Sub

#Region "Nuevos Eventos Solo Validos para FULLSTATION"
    'Lista Implementacion Para FullStation
    'Evento Para Enviar la Placa en las Ventas Credito desde la Mr despues de la lectura del CHIP
    'Private Sub OEventos_RegistrarPlaca(ByRef cara As Byte, ByRef placa As String, ByRef esUltimaVenta As Boolean, ByRef puerto As String) Handles OEventos.RegistrarPlaca
    Private Sub OEventos_RegistrarPlaca(cara As Byte, placa As String, esUltimaVenta As Boolean, puerto As String)
        Try
            If esUltimaVenta Then

                Dim OHelper As New Helper

                LogCategorias.Clear()
                LogPropiedades.Clear()
                LogPropiedades.Agregar("puerto", puerto)
                LogPropiedades.Agregar("Fecha", Now.ToString)
                LogPropiedades.Agregar("cara", cara)
                POSstation.Fabrica.LogIt.Loguear("Antes de Imprimir oEventos_ReimprimirReciboPorCara", LogPropiedades, LogCategorias)

                OHelper.InsertarPlacaUltimaVenta(cara, placa)
                Dim imp As New ImpresoraEstacion(puerto, False)
                ImpresoraRecibo.ImprimirRecibo(cara, imp)

                LogCategorias.Clear()
                LogPropiedades.Clear()
                LogPropiedades.Agregar("puerto", puerto)
                LogPropiedades.Agregar("impresora", imp.Nombre)
                LogPropiedades.Agregar("Fecha", Now.ToString)
                LogPropiedades.Agregar("cara", cara)
                POSstation.Fabrica.LogIt.Loguear("Despues de Imprimir OEventos_RegistrarPlaca", LogPropiedades, LogCategorias)

            Else
                If ColPlacas.ContainsKey(cara.ToString) Then
                    ColPlacas.Remove(cara)
                End If
                ColPlacas.Add(cara, placa)
            End If
        Catch ex As System.Exception
            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas.Remove(cara)
            End If
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto, True))
            Throw New System.Exception(ex.Message)
        End Try
    End Sub


    Private Sub oEventos_VentaCreditoTerpel(ByRef cara As Byte, ByRef kilometraje As String, ByRef puerto As String)
        Try
            If String.IsNullOrEmpty(kilometraje) Then
                kilometraje = "0"
            End If
            If CreditosTerpel.ContainsKey(cara.ToString()) Then
                CreditosTerpel.Remove(cara.ToString())
            End If

            If Not CreditosTerpel.ContainsKey(cara.ToString) Then
                Dim OCredito As New CreditoFullstation
                OCredito.Kilometraje = kilometraje
                OCredito.TipoIdentificacion = TipoIdentificadorVehiculo.CHIP
                CreditosTerpel.Add(cara.ToString, OCredito)
            End If


        Catch ex As System.Exception
            If Not String.IsNullOrEmpty(kilometraje) Then
                If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                    KilometrajesEstacion.Remove(cara.ToString)
                End If
            End If
            If CreditosTerpel.ContainsKey(cara.ToString) Then
                CreditosTerpel.Remove(cara.ToString)
            End If
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_VentaCredito(ByRef cara As Byte, ByRef kilometraje As String, ByRef puerto As String, ByRef identificador As String, ByRef IdTipoIdentificacion As Integer, ByRef ValorPredeterminado As String)
        Try

            Dim odatos As New Helper
            Dim Validacion As Boolean = CBool(odatos.RecuperarParametro("AplicaCreditoConPlacaSecundaria"))

            If CreditosEstacion.ContainsKey(cara.ToString()) Then
                CreditosEstacion.Remove(cara.ToString())
            End If

            If ValorPredeterminado.Equals("0") Then
                Throw New System.Exception("No se puede predeterminar una venta con valor 0")
            End If

            If ValorPredeterminado.Equals("") Then
                ValorPredeterminado = "0"
            End If

            If ColVentaBono.ContainsKey(cara.ToString()) Then
                Throw New System.Exception("No se puede predeterminar una venta credito si ya predetermino la venta por bono")
            End If

            If Not CreditosEstacion.ContainsKey(cara.ToString) Then
                Dim OCredito As New CreditoFullstation

                If Validacion Then
                    If IdTipoIdentificacion = TipoIdentificadorVehiculo.CHIP Then
                        OCredito.NroAutorizacionManual = identificador ''Placa Auxiliar enviada desde la terminal por la opcion de creditos
                        OCredito.TipoIdentificacion = CType(IdTipoIdentificacion, TipoIdentificadorVehiculo)
                        OCredito.Documento = identificador
                        OCredito.ValorPredeterminado = ValorPredeterminado
                        CreditosEstacion.Add(cara.ToString, OCredito)
                    Else
                        If identificador.Contains("-") Then
                            Dim valoresidentificacion() As String = identificador.Split("-")
                            OCredito.NroAutorizacionManual = valoresidentificacion(1) ''Placa Auxiliar enviada desde la terminal por la opcion de creditos
                            OCredito.TipoIdentificacion = CType(IdTipoIdentificacion, TipoIdentificadorVehiculo)
                            OCredito.Documento = valoresidentificacion(0) ''Tarjeta enviada desde la terminal por la opcion de creditos
                            OCredito.ValorPredeterminado = ValorPredeterminado
                            CreditosEstacion.Add(cara.ToString, OCredito)
                        Else
                            OCredito.NroAutorizacionManual = String.Empty
                            OCredito.TipoIdentificacion = CType(IdTipoIdentificacion, TipoIdentificadorVehiculo)
                            OCredito.Documento = identificador
                            OCredito.ValorPredeterminado = ValorPredeterminado
                            CreditosEstacion.Add(cara.ToString, OCredito)
                        End If

                    End If
                Else
                    OCredito.TipoIdentificacion = CType(IdTipoIdentificacion, TipoIdentificadorVehiculo)
                    OCredito.Documento = identificador
                    OCredito.ValorPredeterminado = ValorPredeterminado
                    OCredito.NroAutorizacionManual = String.Empty
                    CreditosEstacion.Add(cara.ToString, OCredito)
                End If
            End If
            If Not String.IsNullOrEmpty(kilometraje) Then

                If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                    KilometrajesEstacion.Remove(cara.ToString)
                End If
                KilometrajesEstacion.Add(cara.ToString, kilometraje)
            End If

            Dim OHelper As New Helper

            If OHelper.ExisteManejoCarroTanque(cara) Then
                Dim tipoId As TipoIdentificadorVehiculo = CType(IdTipoIdentificacion, TipoIdentificadorVehiculo)
                Dim InfoCHIP As InformacionVehiculo = Nothing
                Dim OPreset As New Preset(0, Preset.Tipo.PorVolumen)

                Dim idProducto As Integer
                Dim EsLecturaObligatoria As Boolean = False
                Dim idManguera As Integer = 1

                idProducto = OHelper.RecuperarProductoPorManguera(idManguera)

                Select Case tipoId
                    Case TipoIdentificadorVehiculo.CHIP
                        InfoCHIP = EsperarDatosChipLectorDti(cara.ToString, False)
                        identificador = InfoCHIP.Rom

                        If InfoCHIP IsNot Nothing Then
                            If Not String.IsNullOrEmpty(identificador) Then

                                LogCategorias.Clear()
                                LogCategorias.Agregar("Credito")
                                LogPropiedades.Clear()
                                LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                                LogPropiedades.Agregar("Mensaje", "Venta credito ARM-Chip")
                                Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                                AutorizarVentaCredito(EsLecturaObligatoria, cara, idProducto, idManguera, identificador, IdTipoIdentificacion, OPreset, False)
                                oEventos_Preset(cara, OPreset.Valor, OPreset.TipoPreset, idProducto, "")
                            End If
                        End If
                    Case TipoIdentificadorVehiculo.TARJETA

                        LogCategorias.Clear()
                        LogCategorias.Agregar("Credito")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                        LogPropiedades.Agregar("Mensaje", "Venta credito ARM - Tarjeta")
                        Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                        AutorizarVentaCredito(EsLecturaObligatoria, cara, idProducto, idManguera, identificador, IdTipoIdentificacion, OPreset, False)
                        oEventos_Preset(cara, OPreset.Valor, OPreset.TipoPreset, idProducto, "")
                End Select

            End If

        Catch ex As System.Exception
            If Not String.IsNullOrEmpty(kilometraje) Then
                If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                    KilometrajesEstacion.Remove(cara.ToString)
                End If
            End If
            If CreditosEstacion.ContainsKey(cara.ToString) Then
                CreditosEstacion.Remove(cara.ToString)
            End If
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_GuardarKilometraje(ByRef cara As Byte, ByRef kilometraje As String, ByRef esUltimaVenta As Boolean, ByRef puerto As String)
        Try
            Dim OHelper As New Helper

            If Not esUltimaVenta Then
                If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                    KilometrajesEstacion.Remove(cara.ToString)
                End If

                If IsNumeric(kilometraje) Then
                    KilometrajesEstacion.Add(cara.ToString, kilometraje)
                Else
                    Throw New System.Exception("El kilometraje debe ser un valor numerico (Kilometraje): " & kilometraje & " Cara: " & cara.ToString)
                End If


            Else
                If IsNumeric(kilometraje) Then
                    OHelper.InsertarKilometrajeUltimaVenta(cara, kilometraje)
                    ImpresoraRecibo.ImprimirRecibo(cara, New ImpresoraEstacion(puerto, False))
                Else
                    Throw New System.Exception("El kilometraje debe ser un valor numerico (Kilometraje): " & kilometraje & " Cara: " & cara.ToString)
                End If
            End If
        Catch ex As System.Exception
            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_ReportarPagoEfectivo(ByRef cara As Byte)
        Try

            If VentaEfectivo.ContainsKey(cara) Then
                VentaEfectivo.Remove(cara)
            End If

            Me.VentaEfectivo.Add(cara.ToString, cara.ToString)
        Catch ex As System.Exception
            If VentaEfectivo.ContainsKey(cara) Then
                Me.VentaEfectivo.Remove(cara.ToString)
            End If
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
        End Try
    End Sub

#End Region


    Private Sub oEventos_ExcepcionProtocolo(mensaje As String, imprime As Boolean, terminal As Boolean, puerto As String)
        Dim OHelper As New Helper
        Try
            If String.IsNullOrEmpty(puerto) Then
                ImpresoraTurno.ImprimirExcepcion(mensaje, ImpresoraEstacion.CrearImpresora())
            Else
                ImpresoraTurno.ImprimirExcepcion(mensaje, New ImpresoraEstacion(puerto))
            End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ExcepcionOcurrida", "", "ExcepcionGeneral")
        End Try


    End Sub

    'Lista Implementacion Para FullStation
    Private Sub oEventos_CancelarProcesarTurno(cara As Byte, mensaje As String, EstadoTurno As Boolean)
        Dim OHelper As New Helper
        Try
            OHelper.CancelarProcesoTurno(cara, EstadoTurno)
            ImpresoraTurno.ImprimirExcepcionProcesoTurno(mensaje, cara, EstadoTurno, ImpresoraEstacion.CrearImpresora(cara))
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
        End Try
    End Sub

    Private Sub OEventos_ImprimirRecargaPrepago(idCupo As Int32, puerto As String) ' Handles OEventos.ImprimirRecargaPrepago
        Try
            ImpresoraRecibo.ImprimirRecargaPrepago(idCupo, New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_ImprimirRecargaPrepago", "idCupo: " & idCupo, "OEventos_ImprimirRecargaPrepago")
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion(puerto))
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_ImprimirRecargaPrepago", "idCupo: " & idCupo, "OEventos_ImprimirRecargaPrepago")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirRecargaPrepago", "idCupo: " & idCupo, "OEventos_ImprimirRecargaPrepago")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try

    End Sub

    Private Sub OEventos_ReImprimirRecargaPrepago(idCupo As Int32, puerto As String) ' Handles OEventos.ImprimirRecargaPrepago
        Try
            Dim impresora As ImpresoraEstacion = New ImpresoraEstacion(puerto)
            impresora.ESCopia = True
            ImpresoraRecibo.ImprimirRecargaPrepago(idCupo, impresora)
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_ImprimirRecargaPrepago", "idCupo: " & idCupo, "OEventos_ImprimirRecargaPrepago")
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion(puerto))
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_ImprimirRecargaPrepago", "idCupo: " & idCupo, "OEventos_ImprimirRecargaPrepago")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirRecargaPrepago", "idCupo: " & idCupo, "OEventos_ImprimirRecargaPrepago")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try

    End Sub

    Private Sub oEventos_CaraEnReposo(cara As Byte, idManguera As Integer)
        Dim BorrarConsumos As Boolean = False
        Dim OHelper As New Helper()
        Try
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False
            FechasEstacion(cara.ToString) = ""

            'SI LA COLECCION DE CONSUMOS TIENE PREDETERMINADA UNA CALIBRACION SE VERIFICA QUE SI SE COLGO LA MANGUERA
            'A CALIBRAR SE BORRE EL REGISTRO DE LA COLECCIÓN. ADEMAS DE ESO SE BORRE SI EL PROTOCOLO NO INFORMA LA MANGUERA
            'COLGADA
            If Consumos.ContainsKey(cara.ToString()) Then
                If (Consumos(cara.ToString()).TipoConsumo = TipoConsumo.Calibracion And Consumos(cara.ToString()).IdManguera = idManguera) Or idManguera = -1 Then
                    BorrarConsumos = True
                End If

                If Consumos(cara.ToString()).TipoConsumo = TipoConsumo.ConsumoInterno Then
                    BorrarConsumos = True
                End If
            End If

            If Me.VentaEfectivo.ContainsKey(cara) Then
                Me.VentaEfectivo.Remove(cara.ToString)
            End If

            If Me.CreditosEstacion.ContainsKey(cara) Then
                Me.CreditosEstacion.Remove(cara.ToString)
                LogCategorias.Clear()
                LogCategorias.Agregar("Credito")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                LogPropiedades.Agregar("Mensaje", "Se cuelga la manguera y limpia la coleccion de credito")
                Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)
            End If

            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas.Remove(cara.ToString)
            End If

            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If

            If VentaEfectivo.ContainsKey(cara.ToString) Then
                VentaEfectivo.Remove(cara.ToString)
            End If

            If VentasPorConductor.ContainsKey(cara.ToString) Then
                VentasPorConductor.Remove(cara.ToString)
            End If



            If LecturasLSIB4.ContainsKey(cara.ToString) Then
                LecturasLSIB4.Remove(cara.ToString)
            End If

            Try
                Dim DatosTemporalesAutorizacion As New DatosTemporalesSauce
                DatosTemporalesAutorizacion = New DatosTemporalesSauce
                DatosTemporalesAutorizacion.Cara = cara
                'DatosTemporalesAutorizacion.Manguera = Manguera
                Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf CaraEnReposo), DatosTemporalesAutorizacion)

            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "oEventos_CaraEnReposo", " Proceso asincrono del informar al display : Cara: " & cara.ToString & " Manguera: ", "General")
            End Try



            OHelper.EliminarCupoEnReserva(cara)
            LimpiarColeccionesPorCara(cara.ToString(), BorrarConsumos)


        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
        End Try
    End Sub

    Private Sub CaraEnReposo(DatosAutorizacion As DatosTemporalesSauce)
        Dim BorrarConsumos As Boolean = False
        Dim OHelper As New Helper
        Dim cara As Byte
        Dim manguera As Integer


        Try

            cara = DatosAutorizacion.Cara
            manguera = DatosAutorizacion.Manguera

            Dim EnEjecucion As Boolean = False
            EnEjecucion = Process.GetProcessesByName("DisplayStation").Length > 0

            If EnEjecucion Then
                Dim Service As ServiceSharedEventClient = Nothing
                Service = New ServiceSharedEventClient
                Service.CaraEnReposo(cara, manguera)
                If Not Service Is Nothing Then
                    If Service.State = ServiceModel.CommunicationState.Opened Then
                        Service.Close()
                    End If
                End If
            End If
        Catch ex As System.Exception
            LogCategorias.Clear()
            LogCategorias.Agregar("WCF")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Cara", cara.ToString())
            POSstation.Fabrica.LogIt.Loguear("Error al Localizar el EndPoint: " & ex.Message, LogPropiedades, LogCategorias)
        End Try
    End Sub

#Region "   Fidelizacion de Clientes"


    Private Function BuscarFidelizacion(ByVal cara As String) As Fidelizacion
        Dim Tarjeta As Fidelizacion = Nothing
        Try
            If Me.Fidelizacion.ContainsKey(cara) Then
                Tarjeta = Me.Fidelizacion(cara)
                'Fidelizacion.Remove(cara)
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "BuscarFidelizacion", "Cara: " & cara, "Generales")
        End Try
        Return Tarjeta
    End Function

    '    Private Sub oEventos_FidelizarUltimaVenta(ByRef cara As Byte, ByRef cliente As String, ByRef idRedFidelizacion As Short, ByRef puerto As String, ByRef Ruc As String) Handles OEventos.FidelizarUltimaVenta
    Private Sub oEventos_FidelizarUltimaVenta(cara As Byte, cliente As String, idRedFidelizacion As Short, puerto As String, Ruc As String)
        Dim OHelper As New Helper

        Try
            Dim ORespuestaFidelizacion As Fidelizacion = Nothing
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Cara", cara.ToString())
            LogPropiedades.Agregar("Tarjeta", cliente)
            Fabrica.LogIt.Loguear("Inicio oEventos_FidelizarUltimaVenta", LogPropiedades, LogCategorias)

            ORespuestaFidelizacion = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(cliente)

            LogCategorias.Clear()
            LogCategorias.Agregar("FidelizacionGST")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Cara", cara.ToString())
            LogPropiedades.Agregar("Cliente", cliente.ToString())
            LogPropiedades.Agregar("IdRedFidelizacion", idRedFidelizacion.ToString())
            LogPropiedades.Agregar("Mensaje Error", ORespuestaFidelizacion.MensajeError)
            Fabrica.LogIt.Loguear("Consultar tarjeta antes de fidelizar (ULTIMA VENTA) la venta", LogPropiedades, LogCategorias)

            If Not String.IsNullOrEmpty(ORespuestaFidelizacion.MensajeError.Trim()) Then
                Throw New System.Exception(ORespuestaFidelizacion.MensajeError.Trim)
            End If

            Dim Recibo As Double = OHelper.RecuperarUltimoReciboCara(cara)
            'MsgBox("Recibo : " & Recibo)
            OHelper.FidelizarVenta(CLng(Recibo), idRedFidelizacion, cliente)

            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Cara", cara.ToString())
            LogPropiedades.Agregar("Recibo", Recibo.ToString())
            LogPropiedades.Agregar("Tarjeta", cliente)
            Fabrica.LogIt.Loguear("Venta Fidelizada Enviando a Imprimir", LogPropiedades, LogCategorias)

            'se envia la ultima venta fidelizada (esto cuando el fidelizador ya envio ventas que estan por encima de esta venta que se fideliza)
            POSstation.ServerServices.ServicioFidelizacion.RegistrarUltimaVentaFidelizada(Recibo)

            oEventos_ImprimirFidelizacion(Recibo.ToString, puerto, cliente)
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Cara", cara.ToString())
            LogPropiedades.Agregar("Tarjeta", cliente)
            Fabrica.LogIt.Loguear("Final oEventos_FidelizarUltimaVenta", LogPropiedades, LogCategorias)


        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
            LogFallas.ReportarError(ex, "FidelizarUltimaVenta", "cara: " & cara & " , Tarjeta: " & cliente & " , Puerto: " & puerto, "FidelizarUltimaVenta")
        End Try
    End Sub

    Private Sub EnviarFidelizacion(ByVal Recibo As Integer)
        Try

        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(Recibo))
            LogFallas.ReportarError(ex, "FidelizarUltimaVenta", "Recibo: " & Recibo, "FidelizarUltimaVenta")
        End Try
    End Sub

    Private Sub oEventos_ImprimirFidelizacion(ByRef Recibo As String, ByRef puerto As String, ByRef cliente As String) Handles OEventos.ImprimirFidelizacion
        Try
            ImpresoraRecibo.ImprimirFidelizacion(CLng(Recibo), New ImpresoraEstacion(puerto), cliente)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
            LogFallas.ReportarError(ex, "ImprimirFidelizacion", "Recibo: " & Recibo & " , Tarjeta: " & cliente & " , Puerto: " & puerto, "FidelizarUltimaVenta")
        End Try
    End Sub

    'Private Sub OEventos_ConsultarSaldoTarjetaFidelizacion(ByRef tarjeta As String, ByRef puerto As String, ByRef Ruc As String) Handles OEventos.ConsultarSaldoTarjetaFidelizacion
    Private Sub OEventos_ConsultarSaldoTarjetaFidelizacion(tarjeta As String, puerto As String, Ruc As String)
        Dim OFidelizacion As New Fidelizacion
        Dim RespuestaFidelizacion As Fidelizacion
        Dim oHelper As New Helper()

        Try

            tarjeta = oHelper.ValidarNumeroTarjeta(tarjeta)
            RespuestaFidelizacion = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(tarjeta)
            OFidelizacion.MensajesCliente = RespuestaFidelizacion.MensajesCliente
            OFidelizacion.MensajeError = RespuestaFidelizacion.MensajeError
            OFidelizacion.Saldos = RespuestaFidelizacion.Saldos

            If OFidelizacion.MensajeError = "" Then
                ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(OFidelizacion.Saldos, OFidelizacion.MensajesCliente, OFidelizacion.MensajeError, tarjeta, New ImpresoraEstacion(puerto))
            Else
                Throw New System.Exception(OFidelizacion.MensajeError)
            End If


        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ConsultarSaldoTarjetaFidelizacion", "Tarjeta: " & tarjeta & " , Puerto: " & puerto, "Fidelizacion")
            If RespuestaFidelizacion Is Nothing Then
                ImpresoraTurno.ImprimirExcepcion("Error al consultar la Tarjeta: No se pudo establecer Comunicacion con el servicio de SoyLeal. " + ex.Message, New ImpresoraEstacion(puerto))
                Throw New System.Exception(ex.Message)
            Else
                ImpresoraTurno.ImprimirExcepcion("Error al consultar la Tarjeta: " & ex.Message, New ImpresoraEstacion(puerto))
                Throw
            End If

        End Try

        'ANTES DE ACTUALIZAR CODIGO DE ESTACION A FULLSTATION
        'Dim ODatos As DataSet = Nothing
        'Dim ODatos As Fabrica.Fidelizacion
        'Try
        '    ODatos = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(tarjeta)
        'Catch ex As System.Exception
        '    ODatos = Nothing
        '    ' ImpresoraTurno.ImprimirExcepcion("Error al consultar la Tarjeta: " & ex.Message, New ImpresoraEstacion(puerto))
        '    LogFallas.ReportarError(ex, "ConsultarSaldoTarjetaFidelizacion", "Tarjeta: " & tarjeta & " , Puerto: " & puerto, "Fidelizacion")
        'End Try

        'Try
        '    'ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(ODatos, New ImpresoraEstacion(puerto), tarjeta)
        '    ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(ODatos.Saldos, New ImpresoraEstacion(puerto), tarjeta)
        'Catch ex As System.Exception
        '    LogFallas.ReportarError(ex, "ConsultarSaldoTarjetaFidelizacionImpresion", "Tarjeta: " & tarjeta & " , Puerto: " & puerto, "Fidelizacion")
        'End Try
    End Sub

    'Private Sub oEventos_FidelizarVenta(ByRef cara As Byte, ByRef cliente As String, ByRef IdRedFidelizacion As Short, ByRef puerto As String, ByRef Ruc As String) Handles OEventos.FidelizarVenta
    Private Sub oEventos_FidelizarVenta(cara As Byte, cliente As String, IdRedFidelizacion As Short, puerto As String, Ruc As String)

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("FidelizacionGST")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Cara", cara.ToString())
            LogPropiedades.Agregar("Cliente", cliente.ToString())
            LogPropiedades.Agregar("IdRedFidelizacion", IdRedFidelizacion.ToString())
            Fabrica.LogIt.Loguear("Inicio oEventos_FidelizarVenta", LogPropiedades, LogCategorias)

            'Dim OHelper As New Helper

            'If Not Fidelizacion.ContainsKey(cara.ToString) Then
            '    Dim OFidelizacion As New Fidelizacion
            '    'Dim ODatos As DataSet = Nothing
            '    Dim ODatos As Fabrica.Fidelizacion

            '    OFidelizacion.RedFidelizacion = IdRedFidelizacion
            '    OFidelizacion.Tarjeta = cliente
            '    Fidelizacion.Add(cara.ToString, OFidelizacion)

            '    Try
            '        If CBool(OHelper.RecuperarParametro("ImprimirSaldoTarjeta")) Then
            '            If IdRedFidelizacion = 1 Then
            '                Dim ManejaSaldo As Boolean = OHelper.ManejaSaldoFidelizacion(IdRedFidelizacion)
            '                If Not ManejaSaldo Then
            '                    ODatos = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(cliente)
            '                    Fidelizacion(cara.ToString).Saldos = ODatos.Saldos
            '                End If
            '            End If
            '        End If
            '    Catch ex As System.Exception
            '        LogFallas.ReportarError(ex, "oEventos_FidelizarVenta", "Tarjeta: " & cliente & " , Puerto: " & puerto, "Fidelizacion")
            '    End Try
            'End If

            Dim OHelper As New Helper

            If Not Fidelizacion.ContainsKey(cara.ToString) Then
                Dim OFidelizacion As New Fidelizacion
                Dim ODatos As DataSet = Nothing
                Dim OMensajesFidelizacion As DataSet = Nothing
                Dim ORespuestaFidelizacion As Fidelizacion = Nothing

                OFidelizacion.RedFidelizacion = IdRedFidelizacion
                OFidelizacion.Tarjeta = cliente
                Fidelizacion.Add(cara.ToString, OFidelizacion)

                Try
                    If CBool(OHelper.RecuperarParametro("ImprimirSaldoTarjeta")) Then
                        If IdRedFidelizacion = 1 Or IdRedFidelizacion = 4 Then
                            Dim ManejaSaldo As Boolean = OHelper.ManejaSaldoFidelizacion(IdRedFidelizacion)
                            If Not ManejaSaldo Then
                                Dim Respuesta As String = String.Empty
                                ORespuestaFidelizacion = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(OHelper.ValidarNumeroTarjeta(cliente))
                                Fidelizacion(cara.ToString).Saldos = ORespuestaFidelizacion.Saldos
                                Fidelizacion(cara.ToString).MensajesCliente = ORespuestaFidelizacion.MensajesCliente
                                Fidelizacion(cara.ToString).MensajeError = ORespuestaFidelizacion.MensajeError

                                LogCategorias.Clear()
                                LogCategorias.Agregar("FidelizacionGST")
                                LogPropiedades.Clear()
                                LogPropiedades.Agregar("FechaHora", Now.ToString())
                                LogPropiedades.Agregar("Cara", cara.ToString())
                                LogPropiedades.Agregar("Cliente", cliente.ToString())
                                LogPropiedades.Agregar("IdRedFidelizacion", IdRedFidelizacion.ToString())
                                LogPropiedades.Agregar("Mensaje Error", ORespuestaFidelizacion.MensajeError)
                                Fabrica.LogIt.Loguear("Consultar tarjeta antes de fidelizar la venta", LogPropiedades, LogCategorias)

                                If Not String.IsNullOrEmpty(ORespuestaFidelizacion.MensajeError.Trim()) Then
                                    If Fidelizacion.ContainsKey(cara) Then
                                        Fidelizacion.Remove(cara)
                                    End If
                                    Throw New System.Exception(ORespuestaFidelizacion.MensajeError.Trim)
                                End If


                            End If
                        End If
                    End If
                Catch ex As System.Exception
                    ' OEventos.ReportarAperturaTurnoFallida(ex.Message, puerto)
                    ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
                    LogFallas.ReportarError(ex, "oEventos_FidelizarVenta", "Tarjeta: " & cliente & " , Puerto: " & puerto, "Fidelizacion")
                End Try
            End If

            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Cara", cara.ToString())
            LogPropiedades.Agregar("Cliente", cliente.ToString())
            LogPropiedades.Agregar("IdRedFidelizacion", IdRedFidelizacion.ToString())
            Fabrica.LogIt.Loguear("Final oEventos_FidelizarVenta", LogPropiedades, LogCategorias)

        Catch ex As System.Exception
            'OEventos.ReportarAperturaTurnoFallida(ex.Message, puerto)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
            LogFallas.ReportarError(ex, "FidelizarVentaEnCurso", "cara: " & cara & " , Tarjeta: " & cliente & " , RedFidelizacion: " & IdRedFidelizacion & " , Puerto: " & puerto, "FidelizarVentaEnCurso")
            Throw
        End Try

    End Sub

    'Private Sub OEventos_PredeterminarPagoVentaBonoFidelizacion(ByRef cara As Byte, ByRef nroTarjeta As String, ByRef puerto As String) Handles OEventos.PredeterminarPagoVenta
    Private Sub OEventos_PredeterminarPagoVentaBonoFidelizacion(cara As Byte, nroTarjeta As String, puerto As String)
        Try
            ' Adicionando la Cara y el Número de Tarjeta con el cual se dispone a realizar
            ' el pago de la venta con bono.
            If ColVentaBono.ContainsKey(cara) Then
                ColVentaBono.Remove(cara)
            End If

            ColVentaBono.Add(cara, New Fabrica.PredeterminacionPagoVentaBono(nroTarjeta, puerto))
            ConsultarSaldoTarjetaFidelizacion(nroTarjeta, cara)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_PredeterminarPagoVentaBonoFidelizacion", "-", "PredeterminarPagoVentaBonoFidelizacion")
            Throw
        End Try
    End Sub

    Private Function RedimirBonosVentaGenerada(ByVal Recibo As Long, ByVal nroTarjeta As String) As AutorizacionVentaBono
        Dim OHelper As New Helper
        Dim OVentaBono As AutorizacionVentaBono = Nothing
        Dim EsVentaActualizada As Boolean
        Dim DatosVenta As IDataReader
        Dim Valor, Cantidad, Precio As Decimal

        Try
            DatosVenta = OHelper.ValidarPagoConBonoFidelizacionDirecta(CLng(Recibo))

            If DatosVenta.Read Then

                Valor = CDec(DatosVenta.Item("Valor"))
                Cantidad = CDec(DatosVenta.Item("Cantidad"))
                Precio = CDec(DatosVenta.Item("Precio"))

                DatosVenta.Close()
                DatosVenta = Nothing

                OVentaBono = ServerServices.ServicioFidelizacion.AutorizarConsumoBono(nroTarjeta, CLng(Recibo), Valor, Cantidad, Precio)

                If Not OVentaBono Is Nothing Then
                    If OVentaBono.EsAutorizado Then
                        If OVentaBono.ValorBono > 0 Then
                            OHelper.ActualizarVentaPagaBonoFidelizacion(CLng(Recibo), OVentaBono.ValorBono, nroTarjeta, OVentaBono.NroAutorizacion)
                            EsVentaActualizada = True

                            'OEventos.SolicitarImprimirRedencionBonoVentaFidelizate(Recibo, OVentaBono.NroAutorizacion, puerto)
                        Else
                            ImpresoraTurno.ImprimirExcepcion("El valor autorizado no es valido para pagar la venta.", New ImpresoraEstacion(CLng(Recibo)))
                        End If
                    Else
                        ImpresoraTurno.ImprimirExcepcion("No se autorizo el uso de bonos para la venta. " & OVentaBono.Mensaje, New ImpresoraEstacion(CLng(Recibo)))
                    End If
                Else
                    ImpresoraTurno.ImprimirExcepcion("Error en la comunicacion con el Servicio de Fidelizacion", New ImpresoraEstacion(CLng(Recibo)))
                End If
            Else
                DatosVenta.Close()
                DatosVenta = Nothing
            End If
        Catch ex As System.Exception
            If Not OVentaBono Is Nothing Then
                If OVentaBono.EsAutorizado And Not EsVentaActualizada Then
                    ServerServices.ServicioFidelizacion.CancelarConsumoBono(nroTarjeta, Recibo, Valor)
                End If
            End If
            LogFallas.ReportarError(ex, "RedimirBonosVentaGenerada", "NroTarjeta: " & nroTarjeta & " , Recibo: " & Recibo, "Ventas")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(CLng(Recibo)))
        End Try
        Return IIf(EsVentaActualizada, OVentaBono, Nothing)
    End Function

    Private Sub ConsultarSaldoTarjetaFidelizacion(ByVal tarjeta As String, ByVal Cara As String)
        Dim OFidelizacion As New Fidelizacion
        Dim RespuestaFidelizacion As Fidelizacion
        Dim oHelper As New Helper()
        Try

            If Fidelizacion.ContainsKey(Cara) Then
                Fidelizacion.Remove(Cara)
            End If

            Fidelizacion(Cara) = OFidelizacion

            RespuestaFidelizacion = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(oHelper.ValidarNumeroTarjeta(tarjeta))
            Fidelizacion(Cara).Tarjeta = tarjeta
            Fidelizacion(Cara).MensajesCliente = RespuestaFidelizacion.MensajesCliente
            Fidelizacion(Cara).MensajeError = RespuestaFidelizacion.MensajeError
            Fidelizacion(Cara).Saldos = RespuestaFidelizacion.Saldos
            Fidelizacion(Cara).RedFidelizacion = 1
            Fidelizacion(Cara).FidelizarVenta = False
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ConsultarSaldoTarjetaFidelizacion", "Tarjeta: " & tarjeta & " , cara: " & Cara, "Fidelizacion")
            Throw
        End Try
    End Sub
    'Private Sub OEventos_RedencionBonosFidelizacion(ByRef nroTarjeta As String, ByRef recibo As String, ByRef puerto As String) Handles OEventos.RedencionBonosFidelizacion
    Private Sub OEventos_RedencionBonosFidelizacion(nroTarjeta As String, recibo As String, puerto As String)
        Dim OHelper As New Helper
        Dim OVentaBono As AutorizacionVentaBono = Nothing
        Dim EsVentaActualizada As Boolean
        Dim DatosVenta As IDataReader
        Dim Valor, Cantidad, Precio As Decimal
        'Dim tipoDocumento As Int32

        Try
            DatosVenta = OHelper.ValidarPagoConBonoFidelizacion(CLng(recibo))

            If DatosVenta.Read Then

                Valor = CDec(DatosVenta.Item("Valor"))
                Cantidad = CDec(DatosVenta.Item("Cantidad"))
                Precio = CDec(DatosVenta.Item("Precio"))
                'tipoDocumento = CInt(DatosVenta.Item("TipoDocumento"))

                DatosVenta.Close()
                DatosVenta = Nothing

                'If CBool(OHelper.RecuperarParametro("DeshabilitarFacturacion")) And (tipoDocumento <> Fabrica.TipoDocumentoPeru.Boleta) Then
                '    ImpresoraTurno.ImprimirExcepcion("Este Ticket no es Anulable", New ImpresoraEstacion(puerto))
                'End If

                OVentaBono = ServerServices.ServicioFidelizacion.AutorizarConsumoBono(nroTarjeta, CLng(recibo), Valor, Cantidad, Precio)

                If Not OVentaBono Is Nothing Then
                    If OVentaBono.EsAutorizado Then
                        If OVentaBono.ValorBono > 0 Then

                            OHelper.ActualizarFormaPagoVentaBonoFidelizacion(CLng(recibo), OVentaBono.ValorBono, nroTarjeta, OVentaBono.NroAutorizacion)
                            EsVentaActualizada = True

                            ImpresoraRecibo.ImprimirRecibo(recibo, New ImpresoraEstacion(puerto), True)

                            'OEventos.SolicitarImprimirRedencionBonoVentaFidelizate(recibo, OVentaBono.NroAutorizacion, puerto)
                        Else
                            ImpresoraTurno.ImprimirExcepcion("El valor autorizado no es valido para pagar la venta.", New ImpresoraEstacion(puerto))
                        End If
                    Else
                        ImpresoraTurno.ImprimirExcepcion("No se autorizo el uso de bonos para la venta. " & OVentaBono.Mensaje, New ImpresoraEstacion(puerto))
                    End If
                Else
                    ImpresoraTurno.ImprimirExcepcion("Error en la comunicacion con el Servicio de Fidelizacion", New ImpresoraEstacion(puerto))
                End If
            Else
                DatosVenta.Close()
                DatosVenta = Nothing
            End If


        Catch ex As System.Exception
            If Not OVentaBono Is Nothing Then
                If OVentaBono.EsAutorizado And Not EsVentaActualizada Then
                    OHelper.InsertarIntentoFallidoPagoBonoFidelizacion(CLng(recibo), OVentaBono.ValorBono, nroTarjeta, OVentaBono.NroAutorizacion)
                    'OEventos.SolicitarImprimirRedencionBonoVentaFidelizate(recibo, OVentaBono.NroAutorizacion, puerto)
                End If
            End If

            LogFallas.ReportarError(ex, "OEventos_PagoVentaBonoFidelizacion", "NroTarjeta: " & nroTarjeta & " , Recibo: " & recibo, "Ventas")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub


    Private Sub OEventos_PagarVentaConBono(ByVal IdBono As String, ByVal Numerotarjeta As String, ByVal Venta As DTOVenta, ByVal puerto As String, ByVal usuario As String, ByVal clave As String)
        Dim oDataAccess As New Helper
        Dim oVenta As New Fabrica.DTOVenta
        Dim IdRedencion As Integer = -1, valorBono As Decimal

        Try
            Dim ODataSet As DataSet = Nothing
            Dim ORespuesta As New RespuestaPagarVentaConBono

            Dim drValidar As IDataReader = oDataAccess.RecuperarBonosLocalesReader()
            While drValidar.Read
                If IdBono.Equals(drValidar("IdBono").ToString()) Then
                    valorBono = CDec(drValidar("Valor").ToString)
                End If
            End While

            oVenta.Cantidad = Venta.Cantidad
            oVenta.Descuento = Venta.Descuento
            oVenta.EsFidelizada = Venta.EsFidelizada
            oVenta.EsFidelizadaLocal = Venta.EsFidelizadaLocal
            oVenta.Fecha = Venta.Fecha
            oVenta.FechaProximoMantenimiento = Venta.FechaProximoMantenimiento
            oVenta.Manguera = Venta.Manguera
            oVenta.Placa = Venta.Placa
            oVenta.Precio = Venta.Precio
            oVenta.Producto = Venta.Producto
            oVenta.Recibo = Venta.Recibo
            oVenta.Valor = Venta.Valor

            IdRedencion = oDataAccess.ReservarBono(Convert.ToInt64(oVenta.Recibo), CInt(IdBono))
            ORespuesta = ServerServices.ServicioFidelizacion.PagarVentaConBono(IdBono, Numerotarjeta, oVenta, usuario, clave)

            If Not ORespuesta Is Nothing Then
                If ORespuesta.Autorizado Then
                    oDataAccess.ActualizarFormaPagoVentaBonoFidelizacionSoyLeal(CLng(Venta.Recibo), valorBono, Numerotarjeta, "0", IdRedencion)
                    oDataAccess.LiberarBonoEnreserva(IdRedencion)
                    OEventos_ImprimirReciboRedencionBono(Venta.Recibo, Numerotarjeta, puerto)
                Else
                    ImpresoraTurno.ImprimirExcepcion(IIf(String.IsNullOrEmpty(ORespuesta.MensajeError), "ERROR EN EL SERVICIO DE FIDELIZACION SOY LEAL. NO SE PUEDE HACER LA REDENCION DEL BONO EN ESTOS MOMENTOS", ORespuesta.MensajeError), New ImpresoraEstacion(puerto))
                End If
            Else
                ImpresoraTurno.ImprimirExcepcion("No se Recibió respuesta por parte del Servicio Soy Leal, No se realizó la redención del Bono. Intentelo de Nuevo.", New ImpresoraEstacion(puerto))
            End If


        Catch ex As System.Exception
            Try
                oDataAccess.LiberarBonoEnreserva(IdRedencion)
                oDataAccess.InsertarIntentoFallidoPagoBonoFidelizacion(CLng(Venta.Recibo), valorBono, Numerotarjeta, "0")


                LogFallas.ReportarError(ex, "OEventos_PagarVentaConBono", "NroTarjeta: " & Numerotarjeta & " , Recibo: " & Venta.Recibo, "Ventas")
                ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
            Catch ex1 As System.Exception

            End Try
        End Try
    End Sub

    Private Sub OEventos_ImprimirReciboRedencionBono(ByVal Recibo As String, ByVal NroTarjeta As String, ByVal puerto As String)
        Dim OHelper As New Helper
        Try
            Dim ODataSet As DataSet = Nothing
            Dim ORespuesta As Fabrica.Fidelizacion
            Dim ClienteFidelizado As String = ""
            Dim PuntosTarjeta As Decimal = 0
            Dim FechaActualizacionPuntos As DateTime = Now
            Dim Mensaje As String = ""
            Dim HayComunicacion As Boolean = False


            'Consulto saldo de tarjeta para recuperar los datos que se deben enviar al sp RecuperarReciboFidelizacion
            Try
                ORespuesta = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(NroTarjeta)

                If Not ORespuesta.Saldos Is Nothing Then
                    HayComunicacion = True
                    ClienteFidelizado = ORespuesta.Saldos.Tables(0).Rows(0).Item("Conductor").ToString()
                    PuntosTarjeta = ORespuesta.Saldos.Tables(0).Rows(0).Item("Saldo").ToString()
                    FechaActualizacionPuntos = ORespuesta.Saldos.Tables(0).Rows(0).Item("Fecha").ToString()
                    ORespuesta.Saldos = Nothing

                    If Not ORespuesta.MensajesCliente Is Nothing Then
                        If ORespuesta.MensajesCliente.Tables.Count > 0 Then
                            If ORespuesta.MensajesCliente.Tables(0).Rows.Count > 0 Then
                                For Each row As DataRow In ORespuesta.MensajesCliente.Tables(0).Rows
                                    Mensaje = Mensaje & vbLf & row.Item("MensajeDia").ToString()
                                Next
                                Mensaje = Mensaje & vbLf
                                ORespuesta.MensajesCliente = Nothing
                            End If
                        End If
                    End If
                Else
                    HayComunicacion = False
                End If
            Catch ex As System.Exception
                HayComunicacion = False
            End Try

            If HayComunicacion Then
                ImpresoraRecibo.ImprimirReciboRedencionBono(Recibo, New ImpresoraEstacion(puerto), ClienteFidelizado, PuntosTarjeta, FechaActualizacionPuntos, True)
            Else
                ImpresoraTurno.ImprimirExcepcion("EN ESTOS MOMENTOS NO HAY COMUNICACION CON SOY LEAL. NO SE PUEDE REALIZAR LA OPERACION.", New ImpresoraEstacion(puerto))
            End If

        Catch EXBD As Data.DataException
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            Throw
        Catch Ex As System.Exception
            Throw
        End Try
    End Sub


    Private Sub oEventos_FidelizarVentaManual(ByRef Recibo As String, ByRef Tarjeta As String, ByRef Valor As String, ByRef Cantidad As String, ByRef Idturno As Integer, ByRef Empleado As String, ByRef puerto As String, ByRef Fecha As String)
        Dim OHelper As New Helper
        Dim Respuesta As String

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Recibo", Recibo.ToString())
            LogPropiedades.Agregar("Tarjeta", Tarjeta.ToString())
            LogPropiedades.Agregar("puerto", puerto.ToString())
            LogPropiedades.Agregar("Empleado", Empleado.ToString())
            Fabrica.LogIt.Loguear("Inicio oEventos_FidelizarVentaManual", LogPropiedades, LogCategorias)


            'Se envia la venta Manual a fidelizar y analizamos la respuesta de Fidelizate para proceder a guardar en la tabla 
            'InformacionFidelizacionManual, la informacion de la venta Manual Fidelizada
            Cantidad = Utilidades.ModificarFormatoDecimal(Cantidad)
            Respuesta = ServerServices.ServicioFidelizacion.RegistrarFidelizarVentaManual(Convert.ToInt64(Recibo), Fecha, CDbl(Cantidad), Convert.ToDecimal(Valor), Tarjeta)

            If String.IsNullOrEmpty(Respuesta) Or Respuesta = "" Then

                'Se guarda la informacion de la Fidelizacion Manual en la BD
                Fecha = Convert.ToString(CDate(Fecha.Substring(6, 2) & "/" & Fecha.Substring(4, 2) & "/" & Fecha.Substring(0, 4)))
                OHelper.InsertarFidelizacionManual(Convert.ToInt64(Recibo), Tarjeta, Convert.ToDecimal(Valor), CDbl(Cantidad), Idturno, Empleado, CDate(Fecha))

                '*********************************************IMPRESION DEL TICKET****************************************
                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("FechaHora", Now.ToString())
                LogPropiedades.Agregar("Recibo", Recibo.ToString())
                LogPropiedades.Agregar("Tarjeta", Tarjeta.ToString())
                LogPropiedades.Agregar("puerto", puerto.ToString())
                LogPropiedades.Agregar("Empleado", Empleado.ToString())
                Fabrica.LogIt.Loguear("Venta Manual Fidelizada Enviando a Imprimir", LogPropiedades, LogCategorias)


                Dim OFidelizacion As New Fidelizacion
                Dim RespuestaFidelizacion As Fidelizacion

                Try
                    'Tarjeta = oHelper.ValidarNumeroTarjeta(Tarjeta)
                    RespuestaFidelizacion = ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(Tarjeta)
                    OFidelizacion.MensajesCliente = RespuestaFidelizacion.MensajesCliente
                    OFidelizacion.MensajeError = RespuestaFidelizacion.MensajeError
                    OFidelizacion.Saldos = RespuestaFidelizacion.Saldos

                Catch ex As System.Exception
                    ' OEventos.ReportarExcepcion(ex.Message, True, False)
                    LogFallas.ReportarError(ex, "oEventos_FidelizarVentaManual-Impresion Ticket", "Tarjeta: " & Tarjeta & " , Puerto: " & puerto, "FidelizacionManual")

                End Try

                Try
                    ImpresoraRecibo.ImprimirSaldoTarjetaFidelizacion(OFidelizacion.Saldos, OFidelizacion.MensajesCliente, OFidelizacion.MensajeError, Tarjeta, New ImpresoraEstacion(puerto))
                Catch ex As System.Exception
                    'OEventos.ReportarExcepcion(ex.Message, True, False)
                    LogFallas.ReportarError(ex, "oEventos_FidelizarVentaManual-Impresion Ticket", "Tarjeta: " & Tarjeta & " , Puerto: " & puerto, "FidelizacionManual")
                End Try
                '---------------------------------------------------------------------------------------------------------
            Else
                ImpresoraTurno.ImprimirExcepcion(Respuesta, New ImpresoraEstacion(puerto))
                'OEventos.ReportarExcepcion(Respuesta, True, False)
            End If


            'OEventos.SolicitarImprimirFidelizacion(Recibo.ToString, puerto, cliente)
            LogCategorias.Clear()
            LogCategorias.Agregar("LogueoAutorizador")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("FechaHora", Now.ToString())
            LogPropiedades.Agregar("Recibo", Recibo.ToString())
            LogPropiedades.Agregar("Tarjeta", Tarjeta.ToString())
            LogPropiedades.Agregar("puerto", puerto.ToString())
            LogPropiedades.Agregar("Empleado", Empleado.ToString())
            Fabrica.LogIt.Loguear("Final oEventos_FidelizarVentaManual", LogPropiedades, LogCategorias)


        Catch ex As System.Exception
            ' OEventos.ReportarExcepcion(ex.Message, True, False)
            LogFallas.ReportarError(ex, "FidelizarVentaManual", "Recibo: " & Recibo & " , Tarjeta: " & Tarjeta & " , Puerto: " & puerto & " , Empleado: " & Empleado, "FidelizarVentaManual")
            Throw
        End Try
    End Sub
#End Region

#Region "Nuevos eventos movimientos de inventario"
    ' Private Sub OEventos_ImprimirDocumentoReciboCombustible(ByRef documento As String, ByRef cantidad As Double, ByRef puerto As String) Handles OEventos.ImprimirDocumentoReciboCombustible
    Private Sub OEventos_ImprimirDocumentoReciboCombustible(documento As String, cantidad As Double, puerto As String)
        Try
            ImpresoraRecibo.ImprimirInformeReciboCombustible(documento, cantidad, New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_ImprimirDocumentoReciboCombustible", "Documento: " & documento, "ImpresionReciboCombustible")
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion(puerto))
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_ImprimirDocumentoReciboCombustible", "Documento: " & documento, "ImpresionReciboCombustible")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirDocumentoReciboCombustible", "Documento: " & documento, "ImpresionReciboCombustible")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
        Try
            'VALIDANDO SI EXISTEN MANGUERAS A LAS CUALES SE LES DEBA REALIZAR CAMBIO DE PRODUCTO Y PRECIO
            ManagementKardex.ConsultarManguerasCambiarProductoReciboCombustible(documento)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirDocumentoReciboCombustible", "Documento: " & documento, "CambiarPrecioReciboCombustible")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    Private Sub OEventos_BloqueoTanques(ByRef ColTanque As SharedEventsFuelStation.ColTanques, ByRef puerto As String) Handles OEventos.BloqueoTanques
        Try
            Dim OHelper As New Helper
            For Each Tanque As SharedEventsFuelStation.Tanque In ColTanque
                OHelper.ModificarEstadoManguerasPorTanque(Tanque.CodTanque, Tanque.EsActivo)
            Next
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    Private Sub OEventos_EnviarAlturasCierreDeTanques(ByRef usuario As String, ByRef clave As String, ByRef Tanques As List(Of DTOTanque), ByRef EsAjustePorAlturas As Boolean, ByRef puerto As String)
        Dim OHelper As New Helper
        Dim IdTurno As Int32
        Try



            If Not OHelper.ValidarCredenciales(usuario, clave) Then
                Throw New System.Exception("Credenciales invalidas")
            End If

            IdTurno = OHelper.RecuperarUltimoTurnoCerrado()

            'REALIZANDO LOS AJUSTES DE OPERACION DEL TURNO POR ALTURAS MANUALES
            Dim newId As String
            Dim i As Int32
            newId = Guid.NewGuid.ToString()

            i = 0
            For Each Tanque As DTOTanque In Tanques
                EsAjustePorAlturas = Tanque.EsActivo

                If EsAjustePorAlturas Then
                    OHelper.InsertarStockTurnoHorarioTmp(newId, Tanque.CodigoTanque, IdTurno, Utilidades.ModificarFormatoDecimal(Tanque.CantidadAgua), Utilidades.ModificarFormatoDecimal(Tanque.Altura), Nothing, Nothing, CBool(IIf(i = 0, True, False)), EsAjustePorAlturas)
                Else
                    OHelper.InsertarStockTurnoHorarioTmp(newId, Tanque.CodigoTanque, IdTurno, Nothing, Nothing, Utilidades.ModificarFormatoDecimal(Tanque.Stock), Utilidades.ModificarFormatoDecimal(Tanque.CantidadAgua), CBool(IIf(i = 0, True, False)), EsAjustePorAlturas)
                End If

                i += 1
            Next


            ManagementKardex.RealizarAjustesPorOperacionTurno(newId, CInt(IdTurno.ToString()), usuario)

            OEventos_ImprimirStocksCierreTanques(newId, IdTurno.ToString, puerto)
            'ImpresoraTurno.ImprimirStocksTurno(newId, ImpresoraEstacion.CrearImpresoraPorTurno(IdTurno))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_EnviarAlturasCierreDeTanques", "-", "CierreTurnos")
            ' OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion(puerto))
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_EnviarAlturasCierreDeTanques", "-", "CierreTurnos")
            '.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception

            For Each Tanque As DTOTanque In Tanques
                OHelper.InsertarCierreTanquesFallidoLogueo(IdTurno.ToString, Tanque.Descripcion, ex.Message, usuario, "OEventos_EnviarAlturasCierreDeTanques", "")
            Next
            LogFallas.ReportarError(ex, "OEventos_EnviarAlturasCierreDeTanques", "-", "CierreTurnos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))

        End Try
    End Sub

    Private Sub OEventos_NotificarCambioPrecioManguera(Manguera As Integer)
        Try
            Dim oHelper As New Helper()
            oHelper.ActualizarCombinacionManguera(CShort(Manguera.ToString()))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_NotificarCambioPrecioManguera", " manguera: " & Manguera.ToString(), "NotificarCambioPrecioManguera")
        End Try
    End Sub

    Private Sub OEventos_EnviarInformacionTanquesCierreTurno(ByRef informacionTanques As SharedEventsFuelStation.ColTanques, ByRef IdTurno As Int32) Handles OEventos.EnviarInformacionTanquesCierreTurno
        Try
            Dim OHelper As New Helper

            'REALIZANDO LOS AJUSTES DE OPERACION POR VEEDER ROOT
            Try
                Dim newId, CodTanquePadre, CodTanqueHijo, CodTanqueABuscar As String
                Dim i As Int32
                Dim ODatos As IDataReader
                Dim ListaElim As New List(Of String)
                Dim TanqueABuscar As SharedEventsFuelStation.Tanque
                newId = Guid.NewGuid.ToString()

                'REALIZANDO AJUSTES DENTRO DE UN TURNO
                If IdTurno <> -1 Then
                    i = 0
                    For Each Tanque As SharedEventsFuelStation.Tanque In informacionTanques
                        'VERIFICANDO QUE NO SE HAYA UTILIZADO INFORMACION DEL TANQUE CUANDO ES SIFON
                        If Not ListaElim.Contains(Tanque.CodTanque) Then
                            'VERIFICANDO QUE EL TANQUE ESTE CONECTADO POR SIFON
                            If OHelper.EsTanqueConectadoPorSifon(Tanque.CodTanque) Then
                                'RECUPERANDO LOS CODIGOS DE TANQUES CONECTADOS POR SIFON
                                ODatos = OHelper.RecuperarTanquesHijoYPadreConectadosPorSifon(Tanque.CodTanque)
                                If ODatos.Read() Then
                                    CodTanquePadre = ODatos.Item("CodTanquePadre").ToString()
                                    CodTanqueHijo = ODatos.Item("CodTanqueHijo").ToString()

                                    If Not String.IsNullOrEmpty(CodTanquePadre) And Not String.IsNullOrEmpty(CodTanqueHijo) Then
                                        If Tanque.CodTanque = CodTanquePadre Then
                                            CodTanqueABuscar = CodTanqueHijo
                                        Else
                                            CodTanqueABuscar = CodTanquePadre
                                        End If

                                        'BUSCANDO LA INFORMACION DEL TANQUE PADRE O HIJO DEPENDIENDO EL CASO
                                        TanqueABuscar = Nothing
                                        For Each TanqueB As SharedEventsFuelStation.Tanque In informacionTanques
                                            If TanqueB.CodTanque = CodTanqueABuscar Then
                                                TanqueABuscar = TanqueB
                                            End If
                                        Next

                                        'SE REALIZA EL AJUSTE SOLO PARA EL TANQUE PADRE
                                        If Not TanqueABuscar Is Nothing Then
                                            ListaElim.Add(CodTanquePadre)
                                            ListaElim.Add(CodTanqueHijo)
                                            OHelper.InsertarStockTurnoHorarioTmp(newId, CodTanquePadre, IdTurno, Nothing, Nothing, CDec(Tanque.Stock) + CDec(TanqueABuscar.Stock), CDec(Tanque.VolumenAgua) + CDec(TanqueABuscar.VolumenAgua), CBool(IIf(i = 0, True, False)), False)
                                            i += 1
                                        End If
                                    End If
                                End If
                                ODatos.Close()
                                ODatos = Nothing
                            Else
                                'REALIZANDO LOS AJUSTES PARA LOS TANQUES QUE NO ESTA CONECTADOS POR SIFON
                                OHelper.InsertarStockTurnoHorarioTmp(newId, Tanque.CodTanque, IdTurno, Nothing, Nothing, CDec(Tanque.Stock), CDec(Tanque.VolumenAgua), CBool(IIf(i = 0, True, False)), False)
                                i += 1
                            End If
                        End If
                    Next

                    ManagementKardex.RealizarAjustesPorOperacionTurno(newId, CInt(IdTurno.ToString()), Nothing)

                    'OEventos.SolicitarImprimirStocksCierreTanques(newId, IdTurno.ToString, "")
                    ImpresoraTurno.ImprimirStocksTurno(newId, ImpresoraEstacion.CrearImpresoraPorTurno(IdTurno))
                Else
                    'REALIZANDO AJUSTES DENTRO PARA UN DIA
                    i = 0
                    For Each Tanque As SharedEventsFuelStation.Tanque In informacionTanques
                        'VERIFICANDO QUE NO SE HAYA UTILIZADO INFORMACION DEL TANQUE CUANDO ES SIFON
                        If Not ListaElim.Contains(Tanque.CodTanque) Then
                            'VERIFICANDO QUE EL TANQUE ESTE CONECTADO POR SIFON
                            If OHelper.EsTanqueConectadoPorSifon(Tanque.CodTanque) Then
                                'RECUPERANDO LOS CODIGOS DE TANQUES CONECTADOS POR SIFON
                                ODatos = OHelper.RecuperarTanquesHijoYPadreConectadosPorSifon(Tanque.CodTanque)
                                If ODatos.Read() Then
                                    CodTanquePadre = ODatos.Item("CodTanquePadre").ToString()
                                    CodTanqueHijo = ODatos.Item("CodTanqueHijo").ToString()

                                    If Not String.IsNullOrEmpty(CodTanquePadre) And Not String.IsNullOrEmpty(CodTanqueHijo) Then
                                        If Tanque.CodTanque = CodTanquePadre Then
                                            CodTanqueABuscar = CodTanqueHijo
                                        Else
                                            CodTanqueABuscar = CodTanquePadre
                                        End If

                                        'BUSCANDO LA INFORMACION DEL TANQUE PADRE O HIJO DEPENDIENDO EL CASO
                                        TanqueABuscar = Nothing
                                        For Each TanqueB As SharedEventsFuelStation.Tanque In informacionTanques
                                            If TanqueB.CodTanque = CodTanqueABuscar Then
                                                TanqueABuscar = TanqueB
                                            End If
                                        Next

                                        'SE REALIZA EL AJUSTE SOLO PARA EL TANQUE PADRE
                                        If Not TanqueABuscar Is Nothing Then
                                            ListaElim.Add(CodTanquePadre)
                                            ListaElim.Add(CodTanqueHijo)
                                            OHelper.InsertarStockCierreDiaTmp(newId, CodTanquePadre, Nothing, Nothing, CDec(Tanque.Stock) + CDec(TanqueABuscar.Stock), CDec(Tanque.VolumenAgua) + CDec(TanqueABuscar.VolumenAgua), CBool(IIf(i = 0, True, False)), False)
                                            i += 1
                                        End If
                                    End If
                                End If
                                ODatos.Close()
                                ODatos = Nothing
                            Else
                                'REALIZANDO LOS AJUSTES PARA LOS TANQUES QUE NO ESTA CONECTADOS POR SIFON
                                OHelper.InsertarStockCierreDiaTmp(newId, Tanque.CodTanque, Nothing, Nothing, CDec(Tanque.Stock), CDec(Tanque.VolumenAgua), CBool(IIf(i = 0, True, False)), False)
                                i += 1
                            End If
                        End If
                    Next


                    ManagementKardex.RealizarAjustesPorOperacionDia(newId, Nothing, Nothing)

                    'OEventos.SolicitarImprimirStocksCierreTanques(newId, IdTurno.ToString, "")
                    'ImpresoraTurno.ImprimirStocksTurno(newId, ImpresoraEstacion.CrearImpresoraPorTurno(IdTurno))
                End If
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "OEventos_EnviarInformacionTanquesCierreTurno", "RealizarAjustesPorOperacionTurno, IdTurno: " & IdTurno, "CierreTurnos")
            End Try
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_EnviarInformacionTanquesCierreTurno", "-", "CierreTurnos")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_EnviarInformacionTanquesCierreTurno", "-", "CierreTurnos")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_EnviarInformacionTanquesCierreTurno", "-", "CierreTurnos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub

    Private Sub OEventos_EnviarTrasladoCombustible(ByRef codTanque As String, ByRef cantidad As Double, ByRef entidadReceptora As String, ByRef puerto As String) Handles OEventos.EnviarTrasladoCombustible
        Try

            ManagementKardex.InsertarTransferenciadeCombustibles(codTanque, CDec(cantidad), entidadReceptora)
            ImpresoraRecibo.ImprimirReciboTraslado(codTanque, CDec(cantidad), entidadReceptora, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    Private Sub OEventos_EnviarRemarcaciones(ByRef codTanque As String, ByRef producto As Int16, ByRef cantidad As Double, ByRef codTanqueRemarcado As String, ByRef productoRemarcado As Int16, ByRef puerto As String) Handles OEventos.EnviarRemarcacionCombustible
        Try
            Dim OHelper As New Helper
            'Dim CodProductoBaja, CodProductoAlta As String
            'CodProductoBaja = OHelper.RecuperarCodigoProductoCombustible(producto)
            'CodProductoAlta = OHelper.RecuperarCodigoProductoCombustible(productoRemarcado)

            Dim IdProductoBaja As Int16 = Convert.ToByte(OHelper.RecuperarIdProductoCombustible(producto))
            Dim IdProductoAlta As Int16 = Convert.ToByte(OHelper.RecuperarIdProductoCombustible(productoRemarcado))

            ManagementKardex.RemarcarProductosCombustibles(codTanque, IdProductoBaja, CDec(cantidad), codTanqueRemarcado, IdProductoAlta)
            ImpresoraRecibo.ImprimirReciboRemarcacion(codTanque, producto, CDec(cantidad), codTanqueRemarcado, productoRemarcado, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    'Private Sub OEventos_EnviarRemarcacionesCanastilla(ByRef CodigoCanastilla As String, ByRef CantidadCanastilla As Double, ByRef Codigo As String, ByRef puerto As String) Handles OEventos.EnviarRemarcacionCanastilla
    Private Sub OEventos_EnviarRemarcacionesCanastilla(CodigoCanastilla As String, CantidadCanastilla As Double, Codigo As String, puerto As String)
        Try
            Dim ProductoBaja, ProductoAlta As String
            Dim OHelper As New Helper

            ProductoBaja = OHelper.RecuperarCodigoProductoCanastilla(CInt(CodigoCanastilla))
            ProductoAlta = OHelper.RecuperarCodigoProductoCanastilla(CInt(Codigo))
            If OHelper.RemarcacionCanastilla(CInt(CodigoCanastilla), CantidadCanastilla, CInt(Codigo)) Then
                'Mandamos a insertar el movimiento detalle
                'OHelper.InsertarMovimientoDetalle(2, CInt(CodigoCanastilla), CInt(CantidadCanastilla))
                'OHelper.InsertarMovimientoDetalle(1, CInt(Codigo), CInt(CantidadCanastilla))
                ImpresoraRecibo.ImprimirReciboRemarcacionCanastilla(CodigoCanastilla, ProductoBaja, CantidadCanastilla, CStr(Codigo), ProductoAlta, New ImpresoraEstacion(puerto))

            End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_EnviarRemarcacionesCanastilla", " CodigoCanastilla: " & CodigoCanastilla & ", CantidadCanastilla: " & CantidadCanastilla & ", Codigo: " & Codigo, "NotificarCambioPrecioManguera")
            ImpresoraTurno.ImprimirExcepcion("FALLA AL REALIZAR REMARCACION: " + ex.Message, New ImpresoraEstacion(puerto))
            Throw
        End Try
    End Sub


    Private Sub OEventos_ImprimirStocksCierreTanques(ByRef newID As String, ByRef idTurno As String, ByRef puerto As String) Handles OEventos.ImprimirStocksCierreTanques
        Try
            If String.IsNullOrEmpty(puerto) Then
                ImpresoraTurno.ImprimirStocksTurno(newID, ImpresoraEstacion.CrearImpresoraPorTurno(CInt(idTurno)))
            Else
                ImpresoraTurno.ImprimirStocksTurno(newID, ImpresoraEstacion.CrearImpresoraPorTurno(CInt(idTurno)))
            End If

        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_ImprimirStocksCierreTanques", "-", "CierreTurnos")
            ' OEventosReportarExcepcion(EXSQL.Message, True, False)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirStocksCierreTanques", "-", "CierreTurnos")
            '  OEventos.ReportarExcepcion(ex.Message, True, False)
        End Try
    End Sub
#End Region

#Region "Nuevos eventos ventas fuera del sistema"
    Private Sub OEventos_NotificarHabilitarMangueras(ByRef Mangueras As SharedEventsFuelStation.ColMangueras, ByRef puerto As String) Handles OEventos.NotificarHabilitarMangueras
        Try
            Dim OHelper As New Helper

            For Each Manguera As SharedEventsFuelStation.Manguera In Mangueras
                OHelper.HabilitarMangueraConVentasFueraDelSistema(CShort(Manguera.idManguera))
            Next
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_NotificarHabilitarMangueras", "", "Ventas")
        End Try
    End Sub

    Private Sub OEventos_ConsultaManguerasNoActivas(ByRef puerto As String) Handles OEventos.ConsultaManguerasNoActivas
        Try
            Dim Mangueras As New List(Of Manguera)
            Dim Manguera As New Manguera
            Dim OHelper As New Helper
            Dim OManguerasBloqueadas As IDataReader = OHelper.RecuperarManguerasBloqueadasFueraDelSistema()

            While OManguerasBloqueadas.Read()
                Manguera = New Manguera
                Manguera.IdManguera = CInt(OManguerasBloqueadas.Item("IdManguera"))
                Manguera.Descripcion = CStr(OManguerasBloqueadas.Item("Descripcion"))
                Mangueras.Add(Manguera)
            End While
            OManguerasBloqueadas.Close()

            If Mangueras.Count > 0 Then
                ImpresoraRecibo.ImprimirReciboManguerasBloqueadas(Mangueras, New ImpresoraEstacion(puerto))
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ConsultaManguerasNoActivas", "", "Ventas")
        End Try
    End Sub

    Private Sub OEventos_EnvioVentaFueraDeSistema(ByRef idManguera As Integer, ByRef cantidad As String, ByRef EsVentaCredito As Boolean, ByRef FormasPago As SharedEventsFuelStation.ColMediosPago, ByRef placa As String, ByRef kilometraje As String, ByRef puerto As String) Handles OEventos.EnvioVentaFueraDeSistema
        Try
            Dim Recibo As Double
            Dim OHelper As New Helper
            Dim OFormasPago As New Dictionary(Of Integer, Decimal)

            For Each OFormaPago As SharedEventsFuelStation.MediosPago In FormasPago
                If Not OFormasPago.ContainsKey(OFormaPago.IdMedioPago) Then
                    OFormasPago.Add(OFormaPago.IdMedioPago, CDec(OFormaPago.Valor))
                End If
            Next

            Recibo = OHelper.InsertarVentaGTRecuperada(CShort(idManguera), CDec(cantidad), OFormasPago, placa, kilometraje, Guid.NewGuid.ToString)

            'VALIDANDO SI EXISTEN MANGUERAS A LAS CUALES SE LES DEBA REALIZAR CAMBIO DE PRODUCTO Y PRECIO
            ManagementKardex.ConsultarManguerasCambiarProducto(CShort(idManguera.ToString()))

            ImpresoraRecibo.ImprimirRecibo(Recibo, New ImpresoraEstacion(CLng(Recibo)), True)

            If Not OHelper.EsventaImpresa(CLng(Recibo)) Then
                OHelper.ActualizarVentaImpresa(CLng(Recibo))
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_EnvioVentaFueraDeSistema", "manguera: " & idManguera & ", cantidad: " & cantidad & ", placa: " & placa & ", kilometraje: " & kilometraje, "Ventas")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub
#End Region

#Region "Nuevos eventos para manejo de consumos"
    'PREDETERMINA UNA CALIBRACION EN UNA MANGUERA
    Private Sub oEventos_Calibracion(ByRef cara As Byte, ByRef manguera As Integer, ByRef idMotivo As Short, ByRef aplicaMotivo As Boolean, ByRef puerto As String)
        Try
            Dim OConsumo As New Consumo()
            Dim MsjError As String

            'SI HAY UNA VENTA EN CURSO NO SE PERMITE REALIZAR LA CALIBRACION Y SE SALE DEL EVENTO
            If Not String.IsNullOrEmpty(RomEstacion(cara.ToString())) Then
                MsjError = "NO SE PUEDE REALIZAR LA CALIBRACION PORQUE EXISTE UNA VENTA EN CURSO"
                ImpresoraTurno.ImprimirExcepcion(MsjError, ImpresoraEstacion.CrearImpresora(cara))
                Throw New System.Exception(MsjError)
                Return
            End If

            If ColVentaBono.ContainsKey(cara.ToString()) Then
                MsjError = "No se puede realizar una calibracion si ya  predetermino por bono"
                ImpresoraTurno.ImprimirExcepcion(MsjError, ImpresoraEstacion.CrearImpresora(cara))
                Throw New System.Exception(MsjError)
                Return
            End If

            If Consumos.ContainsKey(cara.ToString) Then
                Consumos.Remove(cara.ToString)
            End If

            OConsumo.IdManguera = CShort(manguera)
            If aplicaMotivo Then
                OConsumo.IdMotivoCalibracion = idMotivo
            Else
                OConsumo.IdMotivoCalibracion = -1
            End If
            OConsumo.TipoConsumo = TipoConsumo.Calibracion
            Consumos.Add(cara.ToString(), OConsumo)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    Private Sub OEventos_EnvioVentaConsumoCombustible(ByRef cara As Byte, ByRef puerto As String)
        Try
            Dim OConsumo As New Consumo()
            Dim MsjError As String

            'SI HAY UNA VENTA EN CURSO NO SE PERMITE REALIZAR LA CALIBRACION Y SE SALE DEL EVENTO
            If Not String.IsNullOrEmpty(RomEstacion(cara.ToString())) Then
                MsjError = "NO SE PUEDE REALIZAR EL CONSUMO INTERNO PORQUE EXISTE UNA VENTA EN CURSO"
                ImpresoraTurno.ImprimirExcepcion(MsjError, ImpresoraEstacion.CrearImpresora(cara))
                Throw New System.Exception(MsjError)
                Return
            End If

            If ColVentaBono.ContainsKey(cara.ToString()) Then
                MsjError = "No se puede realizar una venta de consumo si ya  predetermino por bono"
                ImpresoraTurno.ImprimirExcepcion(MsjError, ImpresoraEstacion.CrearImpresora(cara))
                Throw New System.Exception(MsjError)
                Return
            End If

            If Consumos.ContainsKey(cara.ToString) Then
                Consumos.Remove(cara.ToString)
            End If

            OConsumo.TipoConsumo = TipoConsumo.ConsumoInterno
            Consumos.Add(cara.ToString(), OConsumo)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(cara))
            Throw New System.Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "Nuevos eventos para manejo de consignaciones de sobres"
    Private Sub OEventos_EnvioConsignacionSobre(ByRef idTurno As Integer, ByRef idTipoTurno As Short, ByRef tipoConsignacion As Byte, ByRef cantidad As Double, ByRef puerto As String) Handles OEventos.EnvioConsignacionSobre
        Try
            Dim OHelper As New Helper
            Dim OSobre As DataTable
            Try
                OSobre = OHelper.InsertarSobre(idTurno, idTipoTurno, CShort(tipoConsignacion), CDec(cantidad))
            Catch ex As System.Exception
                ImpresoraTurno.ImprimirExcepcion("FALLA AL INGRESAR EL SOBRE: " & ex.Message, ImpresoraEstacion.CrearImpresora(puerto, False))
                Throw ex
            End Try
            ImpresoraRecibo.ImprimirConsignacionCombustible(idTurno, OSobre, ImpresoraEstacion.CrearImpresora(puerto, False))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_EnvioConsignacionSobre", "idTurno: " & idTurno.ToString() & " tipoConsignacion: " & tipoConsignacion.ToString() & " cantidad: " & cantidad.ToString(), "Financiero")
        End Try
    End Sub

    Private Sub OEventos_InformarCierreConsignaciones(ByRef cedula As String, ByRef clave As String, ByRef ColConsignacion As List(Of DTOConsignacion), ByRef aplicaConsignacion As Boolean, ByRef puerto As String) Handles OEventos.InformarCierreConsignaciones
        Dim IdTurno As Int64
        Dim IdTipoTurno As Short
        Dim TipoConsignacion As Short, Cantidad As Decimal
        Dim OHelper As New Helper
        Dim oSobres As New Dictionary(Of Short, Decimal)
        Dim oTable As DataTable

        Try
            oTable = OHelper.RecuperarTurnoPorCredencialesTable(cedula, clave)

            IdTurno = Int64.Parse(oTable.Rows(0).Item("IdTurno").ToString())
            IdTipoTurno = CShort(oTable.Rows(0).Item("IdTipoTurno").ToString())

            If aplicaConsignacion Then
                Try
                    For Each oItems As DTOConsignacion In ColConsignacion
                        TipoConsignacion = CShort(oItems.IdTipo)
                        Cantidad = CDec(oItems.Valor)
                        oSobres.Add(TipoConsignacion, Cantidad)
                        'OSobre = OHelper.InsertarSobre(CInt(IdTurno), TipoConsignacion, Cantidad)                        
                    Next
                    OHelper.InsertarSobreLote(IdTurno, IdTipoTurno, oSobres)
                Catch ex As System.Exception
                    ImpresoraTurno.ImprimirExcepcion("FALLA AL INGRESAR LOS SOBRES: " & ex.Message, ImpresoraEstacion.CrearImpresora(puerto, False))
                    Throw ex
                End Try
                OHelper.ActualizarTurnoConsignacionSobre(IdTurno, IdTipoTurno)
            Else
                'Aca debo Actualizar el Bit del turno
                OHelper.ActualizarTurnoConsignacionSobre(IdTurno, IdTipoTurno)
            End If
            OEventos_ImprimirCierreSobresTurno(IdTurno.ToString, IdTipoTurno, puerto)
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_InformarCierreConsignaciones", "idTurno: " & IdTurno.ToString() & " tipoConsignacion: " & TipoConsignacion.ToString() & " cantidad: " & Cantidad.ToString(), "Financiero")
        End Try
    End Sub

    Private Sub OEventos_ImprimirCierreSobresTurno(ByRef idTurno As String, ByRef idTipoTurno As Short, ByRef puerto As String) Handles OEventos.ImprimirCierreSobresTurno
        Try
            ImpresoraRecibo.ImprimirCierreSobresTurno(CInt(idTurno), idTipoTurno, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirCierreSobresTurno", "idTurno: " & idTurno.ToString(), "CierreTurnos")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub
#End Region

#Region "Nuevos eventos para manejo de ventas de canastilla"
    Private Sub OEventos_ImprimirVentaCanastillaTerpel(ByRef recibo As String, ByRef puerto As String) Handles OEventos.ImprimirVentaCanastillaTerpel
        Try



            ImpresoraCanastilla.ImprimirReciboCanastilla(CInt(recibo), New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "oEventos_ImprimirVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub

    Private Sub OEventos_AnularFacturaVentaCanastillaTerpel(Prefijo As String, Consecutivo As String, Empleado As String, Clave As String, puerto As String) 'Handles OEventos.AnularFacturaVentaCanastillaTerpel
        Try
            Dim oHelper As New Helper()
            Dim _IdNotaCredito As Int64

            _IdNotaCredito = oHelper.AnularDocumento(Prefijo, CLng(Consecutivo), Empleado, Clave)

            ImpresoraCanastilla.ImprimirNotaCredito(CInt(_IdNotaCredito), ImpresoraEstacion.CrearImpresora(puerto, False), True)

        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_AnularFacturaVentaCanastillaTerpel", "Prefijo: " & Prefijo & ", Consecutivo: " & Consecutivo & ", Puerto: " & puerto, "AnularFacturaVentaCanastillaTerpel")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_AnularFacturaVentaCanastillaTerpel", "Prefijo: " & Prefijo & ", Consecutivo: " & Consecutivo & ", Puerto: " & puerto, "AnularFacturaVentaCanastillaTerpel")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_AnularFacturaVentaCanastillaTerpel", "Prefijo: " & Prefijo & ", Consecutivo: " & Consecutivo & ", Puerto: " & puerto, "AnularFacturaVentaCanastillaTerpel")
            ' OEventos.ReportarExcepcion(ex.Message, True, False)
            Throw
        End Try
    End Sub

    Private Sub OEventos_ImprimirModificacionVentaCanastillaTerpel(ByRef recibo As String, ByRef puerto As String) Handles OEventos.ImprimirModificacionVentaCanastillaTerpel
        Dim oHelper As New Helper()
        Try
            ImpresoraCanastilla.ImprimirReciboCanastilla(CInt(recibo), New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            oHelper.InsertarCambioFormaPagoFallida("", recibo, "", "Impresión modificacion recibo canastilla: " & EXBD.Message)
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirModificacionVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            ' OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            oHelper.InsertarCambioFormaPagoFallida("", recibo, "", "Impresión modificacion recibo canastilla: " & EXSQL.Message)
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirModificacionVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
        Catch ex As System.Exception
            oHelper.InsertarCambioFormaPagoFallida("", recibo, "", "Impresión modificacion recibo canastilla: " & ex.Message)
            LogFallas.ReportarError(ex, "oEventos_ImprimirModificacionVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub

    Private Sub OEventos_ImprimirModificacionVentaCanastilla(ByVal recibo As String, ByVal puerto As String)
        Dim oHelper As New Helper()
        Try
            ImpresoraCanastilla.ImprimirReciboCanastilla(CInt(recibo), New ImpresoraEstacion(puerto))
        Catch EXBD As Data.DataException
            oHelper.InsertarCambioFormaPagoFallida("", recibo, "", "Impresión modificacion recibo canastilla: " & EXBD.Message)
            LogFallas.ReportarError(EXBD, "oEventos_ImprimirModificacionVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXBD.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion())
        Catch EXSQL As Data.SqlClient.SqlException
            oHelper.InsertarCambioFormaPagoFallida("", recibo, "", "Impresión modificacion recibo canastilla: " & EXSQL.Message)
            LogFallas.ReportarError(EXSQL, "oEventos_ImprimirModificacionVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(EXSQL.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion())
        Catch ex As System.Exception
            oHelper.InsertarCambioFormaPagoFallida("", recibo, "", "Impresión modificacion recibo canastilla: " & ex.Message)
            LogFallas.ReportarError(ex, "oEventos_ImprimirModificacionVentaCanastillaTerpel", "Recibo: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
        End Try
    End Sub

    Private Sub OEventos_ImprimirCopiaVentaCanastilla(ByRef recibo As String, ByRef puerto As String) Handles OEventos.ImprimirCopiaVentaCanastilla
        Try
            Dim OHelper As New Helper
            ImpresoraCanastilla.ImprimirReciboCanastilla(OHelper.RecuperarIdVentaCanastillaPorRecibo(CInt(recibo)), ImpresoraEstacion.CrearImpresora(puerto, True))
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_ImprimirCopiaVentaCanastilla", "Recibo: " & recibo, "ImpresionReciboBypass")
            ImpresoraTurno.ImprimirExcepcion(EXBD.Message, New ImpresoraEstacion(puerto))
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_ImprimirCopiaVentaCanastilla", "Recibo: " & recibo, "ImpresionReciboBypass")
            ImpresoraTurno.ImprimirExcepcion(EXSQL.Message, New ImpresoraEstacion(puerto))
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirCopiaVentaCanastilla", "Recibo: " & recibo, "ImpresionReciboBypass")
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion(puerto))
        End Try
    End Sub

    'Private Sub OEventos_ImprimirCopiaVentaCanastilla(ByRef recibo As String, ByRef puerto As String) Handles OEventos.ImprimirCopiaVentaCanastilla
    '    Try
    '        ImpresoraCanastilla.ImprimirFactura(CInt(recibo), New ImpresoraEstacion(puerto, True))
    '    Catch EXBD As Data.DataException
    '        LogFallas.ReportarError(EXBD, "oEventos_ReImprimirVentaCanastilla", "Numero: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
    '        OEventos.ReportarExcepcion(EXBD.Message, True, False)
    '        My.Application.Log.WriteException(EXBD)
    '    Catch EXSQL As Data.SqlClient.SqlException
    '        LogFallas.ReportarError(EXSQL, "oEventos_ReImprimirVentaCanastilla", "Numero: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
    '        OEventos.ReportarExcepcion(EXSQL.Message, True, False)
    '        My.Application.Log.WriteException(EXSQL)
    '    Catch ex As System.exception
    '        LogFallas.ReportarError(Ex, "oEventos_ReImprimirVentaCanastilla", "Numero: " & recibo & ", Puerto: " & puerto, "ImpresionCanastilla")
    '        OEventos.ReportarExcepcion(Ex.Message, True, False)
    '        My.Application.Log.WriteException(Ex)
    '    End Try
    'End Sub

    'Private Sub OEventos_ReImprimirCopiaFacturaProductosServicios(ByRef prefijo As String, ByRef consecutivo As String, ByRef puerto As String) Handles OEventos.ReImprimirCopiaFacturaProductosServicios
    Private Sub OEventos_ReImprimirCopiaFacturaProductosServicios(prefijo As String, consecutivo As String, puerto As String)
        Try
            Dim oHelper As New Helper()
            Dim IdDocumento As Int64 = oHelper.RecuperarIdDocumentoPorNumeroFacturaCanastilla(prefijo, CLng(consecutivo))
            ImpresoraCanastilla.ImprimirFacturaCanastilla(IdDocumento, ImpresoraEstacion.CrearImpresora(puerto, False), True, True)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion("FALLA AL GENERAR LA COPIA DE FACTURA DE PRODUCTOS Y SERVICIOS, PREFIJO: " & prefijo & " CONSECUTIVO: " & consecutivo & ": " & ex.Message, ImpresoraEstacion.CrearImpresora(puerto, True))
            LogFallas.ReportarError(ex, "OEventos_GenerarFacturaProductosServicios", "prefijo: " & prefijo & " consecutivo: " & consecutivo, "FacturaCanastilla")
            Throw
        End Try
    End Sub

    Private Sub OEventos_ImprimirFacturaCanastillaUnica(ByRef idFactura As String, ByRef puerto As String) Handles OEventos.ImprimirFacturaCanastillaUnica
        Try
            Try
                Dim oHelper As New Helper
                Dim NumeroCopias As Integer = 0
                NumeroCopias = oHelper.RecuperarCopiasPorFormaCanastilla(idFactura)
                Dim Impresora As New ImpresoraEstacion(puerto)

                For Copia As Integer = 1 To NumeroCopias
                    If Copia <= 1 Then
                        ImpresoraCanastilla.ImprimirFacturaCanastilla(CLng(idFactura), Impresora, True, False)
                    Else
                        If Copia > 1 Then
                            ImpresoraCanastilla.ImprimirFacturaCanastilla(CLng(idFactura), Impresora, True, True)
                        End If
                    End If
                Next
            Catch ex As System.Exception
                ImpresoraTurno.ImprimirExcepcion("FALLA AL IMPRIMIR LA FACTURA: " & idFactura & " : " & ex.Message, New ImpresoraEstacion(puerto))
                Throw ex
            End Try
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "OEventos_ImprimirFacturaCanastillaUnica", "-", "FacturaCanastilla")
        End Try
    End Sub

    Private Sub OEventos_VentaCreditoCanastilla(identificacion As MedioCredito, colProductos As ColCanastilla, Cedula As String, Clave As String, isla As Integer, puerto As String) 'Handles OEventos.VentaCreditoCanastilla
        Try
            Dim oCara As Short = identificacion.Cara
            Dim oTipoIdentificacion As Short = identificacion.TipoIdentificacion
            Dim oNumeroIdentificacion As String = identificacion.NumeroIdentificacion
            Dim OHelper As New Helper
            Dim Respuesta As IDataReader
            Dim oFactura As New Factura()
            Dim oTotal As Double
            Dim Consecutivo As String
            Dim OIdentificador As InformacionChip = Nothing
            Dim ProductosAutorizados As DataSet
            Dim CantidadAutorizada As Int32
            Dim Placa As String = ""
            Dim CedulaCliente As String = ""
            Dim mExcepcion As New System.Text.StringBuilder()
            Dim EsSobreGiro As Boolean = False
            Dim IdExtraCupo As Int64 = -1
            Dim Rom As String = ""
            Dim oDisponible As DataTable
            Dim IdDocumento As Int32
            Dim Identificador As String = ""
            Dim TipoIdentificador As TipoIdentificadorVehiculo = TipoIdentificadorVehiculo.CHIP

            Dim OPlaca As New InformacionVehiculo
            OIdentificador = New InformacionChip

            If oTipoIdentificacion = Fabrica.TipoIdentificacionCredito.CHIP Then

                If ColDispositivosLSIB4.ContainsKey(oCara.ToString) Then
                    OPlaca = EsperarDatosChipLectorDtiVentaCanastilla(oCara)
                    OIdentificador.Rom = OPlaca.Rom
                Else
                    OIdentificador = OHelper.RecuperarInformacionIdentificador(CByte(oCara))
                End If

                Identificador = OIdentificador.Rom
                TipoIdentificador = TipoIdentificadorVehiculo.CHIP

                LogCategorias.Clear()
                LogCategorias.Agregar("Canastilla")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Rom", OIdentificador.Rom)
                LogPropiedades.Agregar("TipoIdentificacion", oTipoIdentificacion)
                LogPropiedades.Agregar("FechaHora", Now.ToString)
                POSstation.Fabrica.LogIt.Loguear("Lectura de chip", LogPropiedades, LogCategorias)

            ElseIf oTipoIdentificacion = Fabrica.TipoIdentificacionCredito.NIT Then
                Dim ArrayInformacion() As String = identificacion.NumeroIdentificacion.Split(":")
                OHelper.RecuperarsaldoDisponiblePorNitYPlaca(ArrayInformacion(0), ArrayInformacion(1))

                Placa = ArrayInformacion(1)
                Identificador = Placa
                TipoIdentificador = TipoIdentificadorVehiculo.PLACA

                LogCategorias.Clear()
                LogCategorias.Agregar("Canastilla")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Placa", Identificador)
                LogPropiedades.Agregar("TipoIdentificacion", oTipoIdentificacion)
                LogPropiedades.Agregar("FechaHora", Now.ToString)
                POSstation.Fabrica.LogIt.Loguear("Identificacion por placa", LogPropiedades, LogCategorias)

            ElseIf oTipoIdentificacion = Fabrica.TipoIdentificacionCredito.TARJETA Then
                Identificador = oNumeroIdentificacion
                TipoIdentificador = TipoIdentificadorVehiculo.TARJETA

                LogCategorias.Clear()
                LogCategorias.Agregar("Canastilla")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Identificador", Identificador)
                LogPropiedades.Agregar("TipoIdentificacion", oTipoIdentificacion)
                LogPropiedades.Agregar("FechaHora", Now.ToString)
                POSstation.Fabrica.LogIt.Loguear("Identificacion por tarjeta", LogPropiedades, LogCategorias)
            End If

            Respuesta = OHelper.ValidarVentaCanastilla(TipoIdentificador, Identificador)

            LogCategorias.Clear()
            LogCategorias.Agregar("Canastilla")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", "Despues de metodo ValidarVentaCanastilla ")
            LogPropiedades.Agregar("FechaHora", Now.ToString)
            POSstation.Fabrica.LogIt.Loguear("Identificacion por tarjeta", LogPropiedades, LogCategorias)


            If Respuesta.Read Then
                oFactura.Empleado = Cedula
                oFactura.IdFormaPago = CShort(Respuesta.Item("IdFormaPago"))
                Placa = Respuesta.Item("Placa").ToString()
                CedulaCliente = Respuesta.Item("CedulaCliente").ToString()
            End If
            Respuesta.Close()
            Respuesta = Nothing

            LogCategorias.Clear()
            LogCategorias.Agregar("Canastilla")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", "Datos generales")
            LogPropiedades.Agregar("oFactura.IdFormaPago", oFactura.IdFormaPago)
            LogPropiedades.Agregar("Placa", Placa)
            LogPropiedades.Agregar("FechaHora", Now.ToString)
            POSstation.Fabrica.LogIt.Loguear("Identificacion por tarjeta", LogPropiedades, LogCategorias)


            OHelper.EliminarConsumoEnReserva(Placa)


            If oFactura.IdFormaPago <> 4 Then
                Try
                    Dim Precio As Decimal
                    Dim ConsumoDisponible As Decimal

                    If OHelper.ManejaCreditoConCupo(Placa) Or (OHelper.PoseeRestriccionBasicaActiva(Placa) And Not OHelper.ManejaCreditoConCupo(Placa)) Then
                        oDisponible = OHelper.RecuperarConsumoDisponiblePorRestriccion(Placa)

                        ConsumoDisponible = CDec(oDisponible.Rows(0).Item("ConsumoDisponible").ToString())
                        EsSobreGiro = CBool(oDisponible.Rows(0).Item("EsSobreGiro").ToString())
                        IdExtraCupo = CInt(oDisponible.Rows(0).Item("IdExtraCupo").ToString())

                        'Si no hay consumo disponible no se autoriza ningun producto
                        If ConsumoDisponible > 0 Then
                            'Validando las restricciones para cada producto y autorizando las cantidades necesarias
                            'For Each Item As SharedEventsFuelStation.Canastilla In colProductos
                            For i As Int16 = 1 To colProductos.Count
                                Dim Item As Canastilla
                                Item = colProductos.Item(i)
                                ProductosAutorizados = OHelper.ValidaRestriccionesCanastilla(Placa, CInt(Item.Codigo))

                                If ProductosAutorizados.Tables(0).Rows.Count > 0 Then
                                    If Not String.IsNullOrEmpty(ProductosAutorizados.Tables(0).Rows(0).Item("Mensaje").ToString()) Then
                                        'OEventos.ReportarExcepcion(ProductosAutorizados.Tables(0).Rows(0).Item("Mensaje").ToString(), True, False)
                                        ImpresoraTurno.ImprimirExcepcion(ProductosAutorizados.Tables(0).Rows(0).Item("Mensaje").ToString(), New ImpresoraEstacion())
                                    Else
                                        Precio = CDec(ProductosAutorizados.Tables(0).Rows(0).Item("Precio").ToString())

                                        If Precio > 0 Then
                                            CantidadAutorizada = CInt(System.Math.Truncate(ConsumoDisponible / Precio))
                                            If CantidadAutorizada <> 0 Then
                                                If CantidadAutorizada > CInt(Item.Cantidad) Then
                                                    ConsumoDisponible -= CInt(Item.Cantidad) * Precio
                                                    oFactura.AgregarProductoTerpel(CInt(Item.Codigo.ToString()), CInt(Item.Cantidad), isla)
                                                Else
                                                    ConsumoDisponible -= CantidadAutorizada * Precio
                                                    oFactura.AgregarProductoTerpel(CInt(Item.Codigo.ToString()), CantidadAutorizada, isla)
                                                End If

                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Else
                        For i As Int16 = 1 To colProductos.Count
                            Dim ItemCanastilla As Canastilla
                            ItemCanastilla = colProductos.Item(i)
                            oFactura.AgregarProductoTerpel(CInt(ItemCanastilla.Codigo.ToString()), CInt(ItemCanastilla.Cantidad), isla)
                        Next


                        'For Each ItemCanastilla As Canastilla In colProductos
                        '    oFactura.AgregarProductoTerpel(CInt(ItemCanastilla.Codigo.ToString()), CInt(ItemCanastilla.Cantidad), CInt(ItemCanastilla.Isla))
                        'Next
                    End If
                Catch ex As System.Exception
                    OHelper.EliminarConsumoEnReserva(Placa)
                    ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(identificacion.Cara))
                    LogFallas.ReportarError(ex, "CANASTILLA", "Falla al Ingresar localmente la venta credito", "CANASTILLA")
                End Try
            End If

            If oFactura.Productos.Count > 0 Then
                oTotal = oFactura.RecuperarTotalventa()

                If Not oFactura.EsFacturaFinalizada Then
                    oFactura.AgregarPago(oFactura.IdFormaPago, "", oTotal, 0, "")
                    oFactura.EsFacturaFinalizada = True
                End If

                If (Convert.ToBoolean(OHelper.RecuperarParametro("GenerarFacturaCanastillaAutomatica"))) Then
                    IdDocumento = oFactura.GuardarFacturaFullStation(Cedula, Clave, CedulaCliente, TipoIdentificadorVehiculo.PLACA, Placa)
                    OEventos_ImprimirFacturaCanastillaUnica(IdDocumento, puerto)
                Else
                    Consecutivo = oFactura.GuardarVentaFullstation(Cedula, Clave, CedulaCliente, TipoIdentificadorVehiculo.PLACA, Placa).ToString
                    OEventos_ImprimirVentaCanastillaTerpel(Consecutivo, puerto)
                End If
            Else
                'OEventos.ReportarExcepcion("ERROR: Venta no autorizada no posee saldo suficiente para realizar la operacion", True, False)
                ImpresoraTurno.ImprimirExcepcion("ERROR: Venta no autorizada no posee saldo suficiente para realizar la operacion", New ImpresoraEstacion())
            End If

            OHelper.EliminarConsumoEnReserva(Placa)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(identificacion.Cara))
            LogFallas.ReportarError(ex, "OEventos_VentaCreditoCanastilla", "", "VentaCanastilla")
            Throw
        End Try
    End Sub

#End Region

    Private Sub OEventos_VentaInterrumpidaEnCero(Cara As Byte)
        Try
            Dim OHelper As New Helper()
            LimpiarColeccionesPorCara(Cara)
            OHelper.EliminarCupoEnReserva(Cara)
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(Cara.ToString()))
            LogFallas.ReportarError(ex, "OEventos_VentaInterrumpidaEnCero", "Cara: " & Cara, "VentaInterrumpidaEnCero")
        End Try
    End Sub

    '    Private Sub OEventos_AperturaTurnoTrabajo(ByRef empleado As String, ByRef clave As String, ByRef idTipoTurno As Short, ByRef puerto As String) Handles OEventos.AperturaTurnoTrabajo
    Private Sub OEventos_AperturaTurnoTrabajo(empleado As String, clave As String, idTipoTurno As Short, puerto As String) 'Handles OEventos.AperturaTurnoTrabajo
        Dim OHelper As New Helper
        Try
            POSstation.Fabrica.gasolutionsHasp.IsHasp()

            Dim IdTurno As Integer = 0
            IdTurno = OHelper.AbrirTurnoApoyo(empleado, clave)

            If IdTurno > 0 Then
                ImpresoraTurno.ImprimirTurnoApoyo(IdTurno, New ImpresoraEstacion(puerto), True)
            End If
        Catch Ex As GasolutionsHaspException
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", "LLAVE HASP NO ENCONTRADA Por favor conecte en el puerto USB la llave de verificación de licencia", puerto, "Abrir Turno Trabajo")
            LogFallas.ReportarError(New System.Exception("LLAVE HASP NO ENCONTRADA"), "AperturaTurno", "-", "ImpresionTurnos")
            oEventos_AperturaTurnoFallida("LLAVE HASP NO ENCONTRADA Por favor conecte en el puerto USB la llave de verificación de licencia", puerto)
            Throw
        Catch EXBD As Data.DataException
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", EXBD.Message.ToString(), puerto, "Abrir Turno Trabajo")
            LogFallas.ReportarError(EXBD, "oEventos_AperturaTurnoTrabajo", "Empleado: " & empleado & ", Clave: " & clave & ", Tipo Turno: " & idTipoTurno & ", Puerto: " & puerto, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(EXBD.Message, puerto)
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", EXSQL.Message.ToString(), puerto, "Abrir Turno Trabajo")
            LogFallas.ReportarError(EXSQL, "oEventos_AperturaTurnoTrabajo", "Empleado: " & empleado & ", Clave: " & clave & ", Tipo Turno: " & idTipoTurno & ", Puerto: " & puerto, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(EXSQL.Message, puerto)
            Throw
        Catch ex As System.Exception
            OHelper.InsertarTurnoFallidoLogueo(empleado, clave, "", ex.Message.ToString(), puerto, "Abrir Turno Trabajo")
            LogFallas.ReportarError(ex, "oEventos_AperturaTurnoTrabajo", "Empleado: " & empleado & ", Clave: " & clave & ", Tipo Turno: " & idTipoTurno & ", Puerto: " & puerto, "ImpresionTurnos")
            oEventos_AperturaTurnoFallida(ex.Message, puerto)
            Throw
        End Try
    End Sub


    Private Sub oEventos_EnviarDatos(Cara As String, Documento As String, puerto As String)

        Try

            If VentasPorConductor.ContainsKey(Cara) Then
                VentasPorConductor.Remove(Cara)
            End If


            If Not VentasPorConductor.ContainsKey(Cara) Then
                VentasPorConductor.Add(Cara, Documento)
            End If

        Catch ex As System.Exception
            If VentasPorConductor.ContainsKey(Cara) Then
                VentasPorConductor.Remove(Cara)
            End If
            LogFallas.ReportarError(ex, "oEventos_EnviarDatos", "Cara: " & CStr(Cara) & ", NumeroDocumento: " & Documento, "Enviar Datos")
        End Try


    End Sub

    'Private Sub OEventos_AutorizarVentaCheque(ByRef Cara As Byte, ByRef numeroAutorizacionCheque As String, ByRef tarjeta As String, ByRef TipoLectura As Byte, ByRef NroSeguridad As String, ByRef TipoIdentificacion As Short, ByRef kilometraje As String, ByRef NumAutorizacionManual As String, ByRef placa As String, ByRef EsVentaCredito As Boolean, ByRef puerto As String) Handles OEventos.AutorizarVentaCheque
    Private Sub OEventos_AutorizarVentaCheque(Cara As Byte, numeroAutorizacionCheque As String, tarjeta As String, TipoLectura As Byte, NroSeguridad As String, TipoIdentificacion As Short, kilometraje As String, NumAutorizacionManual As String, placa As String, EsVentaCredito As Boolean, puerto As String)
        Try

            Dim OFormaPago As FormaPagoVenta = Nothing
            Dim OCredito As Credito = Nothing

            If VentasCheques.ContainsKey(Cara) Then
                VentasCheques.Remove(Cara)
            End If

            If String.IsNullOrEmpty(placa) Then
                If String.IsNullOrEmpty(RomEstacion(Cara.ToString)) Then

                    Dim oTarjeta As New TarjetaFidelizacion
                    oTarjeta.CodigoTarjeta = tarjeta

                    OCredito = New Credito
                    OCredito.EsEfectivo = True
                    OCredito.EsClienteIdentificado = True
                    OCredito.FormaPagoContado = New FormaPagoVenta
                    OCredito.FormaPagoContado.IdFormaPago = Fabrica.FormaPagoTerpel.CHEQUE
                    OCredito.FormaPagoContado.NumeroAutorizacion = numeroAutorizacionCheque
                    OCredito.NroAutorizacionManual = NumAutorizacionManual
                    OCredito.Kilometraje = kilometraje
                    OCredito.Tarjeta = oTarjeta
                    OCredito.Estado = EstadoAutorizacion.LecturaCHIP
                    OCredito.TipoIdentificacion = CType(TipoIdentificacion, TipoIdentificador)
                    OCredito.HoraInicio = Now
                    Me.VentasCheques.Add(Cara.ToString, OCredito)
                End If
            Else
                OCredito = New Credito
                OCredito.EsEfectivo = True
                OCredito.EsClienteIdentificado = False
                OCredito.FormaPagoContado = New FormaPagoVenta
                OCredito.FormaPagoContado.IdFormaPago = Fabrica.FormaPagoTerpel.CHEQUE
                OCredito.FormaPagoContado.NumeroAutorizacion = numeroAutorizacionCheque
                OCredito.Estado = EstadoAutorizacion.LecturaCHIP
                OCredito.HoraInicio = Now
                OCredito.Placa = placa
                Me.VentasCheques.Add(Cara.ToString, OCredito)
            End If
        Catch ex As System.Exception
            If VentasCheques.ContainsKey(Cara) Then
                VentasCheques.Remove(Cara)
            End If
            LogFallas.ReportarError(ex, "OEventos_AutorizarVentaCheque", "NumeroAutorizacion: " & numeroAutorizacionCheque & ", Cara: " & CStr(Cara) & ", placa: " & placa & ", Puerto: " & puerto, "FacturaCanastilla")
        End Try
    End Sub

    Private Sub OEventos_AutorizarVentaPrepago(ByRef Cara As Byte, ByRef tarjeta As String, ByRef Valor As Double, ByRef puerto As String, ByRef Kilometraje As String)
        Dim OHelper As New Helper
        Dim Saldo As Double = 0
        Try
            If Not OHelper.ExisteVentaParcial(CShort(Cara.ToString)) Then
                If VentaPrepago.ContainsKey(Cara) Then
                    VentaPrepago.Remove(Cara)
                End If


                If Not VentaPrepago.ContainsKey(Cara) Then
                    Dim Consulta As New RespuestaSaldo
                    Consulta = ServerServices.CDCServices.SaldoTarjeta(tarjeta)
                    Saldo = Consulta.Saldo
                    If Saldo >= Valor Then
                        Dim oVentaPrepago As CupoPrepago = New CupoPrepago
                        oVentaPrepago.Valor = Valor
                        oVentaPrepago.NroTarjeta = tarjeta
                        oVentaPrepago.kilometraje = Kilometraje
                        oVentaPrepago.Placa = Consulta.Placa
                        VentaPrepago.Add(Cara, oVentaPrepago)
                    Else
                        ImpresoraTurno.ImprimirExcepcion("No tiene saldo suficiente para la venta, su saldo actual es : $" & Saldo.ToString(), ImpresoraEstacion.CrearImpresora(Cara))
                    End If

                End If
            End If
        Catch ex As System.Exception
            If VentaPrepago.ContainsKey(Cara) Then
                VentaPrepago.Remove(Cara)
            End If
            LogFallas.ReportarError(ex, "OEventos_AutorizarVentaPrepago", "Cara: " & CStr(Cara) & ", NumeroTarjeta: " & tarjeta & " ,Valor: " & Valor.ToString & ", Puerto: " & puerto, "FacturaCanastilla")
            Throw New System.Exception(ex.Message)
        End Try


    End Sub

    Private Sub OEventos_EnviarCambioCheque(numeroAutorizacion As String, idTurno As Integer, Cara As Byte, recibo As String, valorCambio As Double, valorCliente As Double, Puerto As String) 'Handles OEventos.EnviarCambioCheque
        Try
            ImpresoraRecibo.ImprimirCambioCheque(Cara, idTurno, recibo, numeroAutorizacion, valorCambio, New ImpresoraEstacion(Puerto))
        Catch ex As System.Exception
            ImpresoraTurno.ImprimirExcepcion(ex.Message, ImpresoraEstacion.CrearImpresora(Cara))

        End Try
    End Sub



    Private Sub OEventos_ImprimirMovimientosPrepago(ByRef Tarjeta As String, ByRef Puerto As String)
        Try
            Dim listas As List(Of ServerServices.MovimientoTarjeta) = ServerServices.CDCServices.MovimientosPrepago(Tarjeta)
            Dim saldo As New RespuestaSaldo
            saldo = ServerServices.CDCServices.SaldoTarjeta(Tarjeta)
            ImpresoraTurno.ImprimirMovimientosPrepago(Tarjeta, New ImpresoraEstacion(Puerto), listas, saldo)
        Catch ex As System.Exception
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            LogFallas.ReportarError(ex, "OEventos_ImprimirMovimientosPrepago", "Tarjeta: " & Tarjeta, "General")
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    Private Sub OEventos_ImprimirSaldoTarjetaPrepago(ByRef Puerto As String, ByRef Saldo As String)
        Try
            ImpresoraTurno.ImprimirSaldoTarjetaPrepago(Saldo, New ImpresoraEstacion(Puerto))
        Catch ex As System.Exception
            'OEventos.ReportarExcepcion(ex.Message, True, False)
            ImpresoraTurno.ImprimirExcepcion(ex.Message, New ImpresoraEstacion())
            LogFallas.ReportarError(ex, "OEventos_ImprimirSaldoTarjetaPrepago", "Saldo: " & Saldo, "General")
            Throw New System.Exception(ex.Message)
        End Try
    End Sub

    Private Sub InformarCaraSinChipDti(ByRef cara As Byte, ByRef OTerminal_AutorizarVentaChequePuertoDti As String, ByRef Puerto As String)
        Try
            If LecturasLSIB4.ContainsKey(cara.ToString) Then
                LecturasLSIB4.Remove(cara.ToString)
                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Cara", cara.ToString)
                Fabrica.LogIt.Loguear("Se desconecto el chip del lectorDTI el la cara : " & cara.ToString & " Puerto Dti: " & Puerto & "Puerto Com: " & Puerto, LogPropiedades, LogCategorias)
                If RomEstacion.ContainsKey(cara.ToString) Then
                    RomEstacion(cara.ToString) = ""
                End If

            End If
        Catch ex As System.Exception
            RomEstacion(cara.ToString) = ""
            CarasEstacion(cara.ToString) = False

            If CreditosEstacion.ContainsKey(cara.ToString) Then
                CreditosEstacion.Remove(cara.ToString)
            End If

            If ColPlacas.ContainsKey(cara.ToString) Then
                ColPlacas(cara.ToString) = False
            End If


            If KilometrajesEstacion.ContainsKey(cara.ToString) Then
                KilometrajesEstacion.Remove(cara.ToString)
            End If

            If VentasCheques.ContainsKey(cara.ToString) Then
                VentasCheques.Remove(cara.ToString)
            End If

            LogFallas.ReportarError(ex, "OEventos_InformarCaraSinChipDti", "Cara: " & cara, "General")
        End Try
    End Sub


    Public Function AutorizarVentaLSIB4(tipoValidacion As Helper.ETipoValidacion, DatosVehiculo As InformacionVehiculo, SolicitaLecturaChip As Boolean) As InformacionVehiculo
        Dim oHelper As New Helper
        Dim oDatos As New InformacionChip
        Try

            If (ApiSICOM.AplicaSICOM()) Then
                Dim datosChip As ApiResponse.DatosChip = RestApiInvoke.GetDataChip(DatosVehiculo.Rom)

                If (Not DatosVehiculo.Rom.Equals(datosChip.ROM)) Then
                    Throw New System.Exception(String.Format("La placa local '{0}' no coincide con la reportada por el servicio SICOM '{1}'", DatosVehiculo.Rom, datosChip.ROM))
                End If

                DatosVehiculo.Rom = datosChip.ROM
                DatosVehiculo.Placa = datosChip.Placa
                DatosVehiculo.FechaConversion = datosChip.FechaConversion
                DatosVehiculo.FechaProximoMantenimiento = datosChip.FechaProximoMantenimiento
                Exit Function
            End If

            Dim AutorizacionRemoting As Boolean = CBool(oHelper.RecuperarParametro("AutorizacionRemota"))
            Dim OInfoVehiculos As InformacionVehiculo
            oDatos.Rom = DatosVehiculo.Rom
            oDatos.FechaProximoMantenimiento = DatosVehiculo.FechaProximoMantenimiento
            oDatos.FechaConversion = DatosVehiculo.FechaConversion
            oDatos.Contrato = DatosVehiculo.Contrato
            oDatos.Placa = DatosVehiculo.Placa


            If tipoValidacion = ETipoValidacion.BaseDatos And SolicitaLecturaChip Then
                If oHelper.ExisteVehiculo(DatosVehiculo.Placa) Then
                    OInfoVehiculos = oHelper.ESAutorizadoBase(oDatos, SolicitaLecturaChip)

                    If OInfoVehiculos.Autorizado Then
                        Return OInfoVehiculos
                    Else
                        Throw New GasolutionsException("Error Validando vehiculo en la Base de Datos: " & OInfoVehiculos.CausaNegacion)
                    End If
                    'ElseIf (oHelper.RecuperarParametro("AutorizarVentaLiquidoConChip") = False) Then
                    '    Throw New System.Exception("El chip no corresponde a una venta para GNV.")
                Else
                    Throw New System.Exception("Error Validando vehiculo en la Base de Datos el Vehiculo no Existe")
                End If
            ElseIf tipoValidacion = ETipoValidacion.Chip Or SolicitaLecturaChip Then
                OInfoVehiculos = oHelper.ESAutorizadoChip(oDatos)
                If OInfoVehiculos.Autorizado = True Then
                    Return OInfoVehiculos
                Else
                    Throw New GasolutionsException(OInfoVehiculos.CausaNegacion)
                End If

            ElseIf tipoValidacion = ETipoValidacion.Ambas Then
                OInfoVehiculos = oHelper.ESAutorizadoChip(oDatos)
                If OInfoVehiculos.Autorizado = True Then
                    Return OInfoVehiculos
                Else
                    If oHelper.ExisteVehiculo(oDatos.Placa) Then
                        OInfoVehiculos = oHelper.ESAutorizadoBase(oDatos, SolicitaLecturaChip)
                        If OInfoVehiculos.Autorizado Then
                            Return OInfoVehiculos
                        Else
                            Throw New GasolutionsException("Error Validando vehiculo en la Base de Datos: " & OInfoVehiculos.CausaNegacion)
                        End If
                    Else
                        Throw New GasolutionsException("Error Validando vehiculo en la Base de Datos, el Vehiculo no existe")

                    End If
                End If
            End If

            Return Nothing
        Catch ex As System.Exception
            Try

                ''No se pudo establecer conexion con el servidor, o no se obtuvo respuesta.
                If (ApiSICOM.AplicaSICOM()) Then
                    If ex.Message.Contains("No se pudo establecer conexion con el servidor, o no se obtuvo respuesta") Then
                        oHelper.RecuperarEstadoVehiculo(DatosVehiculo.Rom, DatosVehiculo.Placa, SolicitaLecturaChip)
                    Else
                        Throw New System.Exception(ex.Message)
                    End If
                Else
                    Throw New System.Exception(ex.Message)
                End If

            Catch ex2 As System.Exception
                Throw
            End Try
        End Try
    End Function

    Private Function EsperarDatosChipLectorDti(ByVal ocara As String, ByVal EsLecturaObligatoria As Boolean) As InformacionVehiculo
        Dim oDatos As New Helper
        Dim intentos As Integer = CInt(oDatos.RecuperarParametro("LecturaChipReintentos"))
        Dim Delay As Int32 = CInt(oDatos.RecuperarParametro("LecturaChipDelay"))
        Dim OPlaca As InformacionVehiculo = Nothing
        Dim oHelper As New Helper
        Dim i As Integer = 1


        Try

            While i <= intentos
                If LecturasLSIB4.ContainsKey(ocara) Then
                    OPlaca = DesencriptarBytesDti(EsLecturaObligatoria, CByte(ocara), LecturasLSIB4(ocara).ArregloBytes)



                    If OPlaca Is Nothing Then
                        Throw New System.Exception("Retire y coloque nuevamente el chip en el lector")
                    Else
                        Exit While
                    End If
                Else
                    System.Threading.Thread.Sleep(CInt(Delay / 3))
                End If

                i = i + 1
            End While


            If i >= intentos And OPlaca Is Nothing Then
                Throw New System.Exception("No hay un chip conectado")
            End If

            If EsLecturaObligatoria Then

                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                LogPropiedades.Agregar("Mensaje", "Antes de Validar el chip")
                Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)

                If CBool(oHelper.RecuperarParametro("AutorizarVentaLiquidoConChip")) Then
                    Dim existeIdentificador As Boolean = CBool(oHelper.ExisteIdentificadorLocal(OPlaca.Rom))
                    If existeIdentificador = False Then
                        LogPropiedades.Agregar("Rom", OPlaca.Rom)
                        LogPropiedades.Agregar("Fecha", OPlaca.Fecha)
                        LogPropiedades.Agregar("FechaConversion", OPlaca.FechaConversion)
                        LogPropiedades.Agregar("FechaProximoMantenimiento", OPlaca.FechaProximoMantenimiento)
                        POSstation.Fabrica.LogIt.Loguear("Inciar Hilo: Venta No autorizada CHip no existe", LogPropiedades, LogCategorias)

                        Throw New System.Exception("Venta No Autorizada, El Rom:" + OPlaca.Rom + " No existe en la Base de Datos.")
                    End If
                Else
                    If Not OPlaca Is Nothing Then
                        Dim TipoAutorizacion As Helper.ETipoValidacion = RetornarTipoValidacion()
                        AutorizarVentaLSIB4(TipoAutorizacion, OPlaca, EsLecturaObligatoria)
                    End If
                End If
                LogCategorias.Clear()
                LogCategorias.Agregar("LogueoAutorizador")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Hora", Now.ToString("dd/MM/yyyy HH:mm:sss"))
                LogPropiedades.Agregar("Mensaje", "Despues de Validar el chip")
                Fabrica.LogIt.Loguear("Seguimieto", LogPropiedades, LogCategorias)
            End If

            Return OPlaca
        Catch ex As System.Exception
            If LecturasLSIB4.ContainsKey(ocara) Then
                LecturasLSIB4.Remove(ocara)
            End If
            Throw ex
        End Try
    End Function



    Private Sub IniciarDispositivosLSIB4()
        Try
            Dim OHelper As New Helper
            Dim DrDispositivos As IDataReader
            Dim Dispositivo As LSIB4Reader
            Dim DispositivoTcp As POSstation.TcpServer
            Dim idTipoComunicacion As Integer

            DrDispositivos = OHelper.RecuperarDispositivosDti


            While DrDispositivos.Read
                idTipoComunicacion = DrDispositivos.Item("IdTipoComunicacionDisp")

                If idTipoComunicacion = 1 Then
                    Dispositivo = New LSIB4Reader
                    Dispositivo.ReaderHostMain(DrDispositivos.Item("Puerto").ToString(), CInt(DrDispositivos.Item("IdLectorDti").ToString()))
                    AddHandler Dispositivo.EnviarBytesLecturaChipPorDti, AddressOf OEventos_EnviarBytesLecturaChipPorDti
                    listaDispositivos.Add(CType(Dispositivo, LSIB4Reader))
                Else
                    DispositivoTcp = New POSstation.TcpServer(CInt((DrDispositivos.Item("PuertoIp").ToString())), CInt(DrDispositivos.Item("IdLectorDti").ToString()))
                    AddHandler DispositivoTcp.EventoEnviarBytesLecturaChipPorLSIB4, AddressOf OEventos_EnviarBytesLecturaChipPorDti
                    DispositivoTcp.IniciarServidor()
                    listaDispositivos.Add(CType(DispositivoTcp, POSstation.TcpServer))
                End If
            End While

            DrDispositivos.Close()
            DrDispositivos = Nothing
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "IniciarDispositivosDti", "", "Autorizador")
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "IniciarDispositivosDti", "", "Autorizador")
        Catch EXCapturadores As System.Exception
            LogFallas.ReportarError(EXCapturadores, "IniciarDispositivosDti", "", "Autorizador")
        End Try
    End Sub



    Private Function EsperarDatosChipLectorDtiImpresionTicket(ByVal ocara As String, Optional ByVal EsLecturaObligatoria As Boolean = True) As InformacionVehiculo
        Dim oDatos As New Helper
        Dim intentos As Integer = CInt(oDatos.RecuperarParametro("LecturaChipReintentos"))
        Dim Delay As Int32 = CInt(oDatos.RecuperarParametro("LecturaChipDelay"))
        Dim OPlaca As New InformacionVehiculo
        Dim oNorma As New EncriptacionDti.EncriptacionDti
        Dim i As Integer = 0
        Dim bytes As Byte()

        Try
            While i <= intentos
                If LecturasLSIB4.ContainsKey(ocara) Then
                    bytes = LecturasLSIB4(ocara).ArregloBytes
                    'OPlaca = oNorma.ExtraerInformacionPaginasImpresiones(LecturasLSIB4(ocara).ArregloBytes)
                    OPlaca = DesencriptarBytesDti(EsLecturaObligatoria, CByte(ocara), bytes)

                    If OPlaca Is Nothing Then
                        Throw New System.Exception("Retire y coloque nuevamente el chip en el lector")
                    Else
                        Exit While
                    End If
                Else
                    System.Threading.Thread.Sleep(CInt(Delay / 3))
                End If

                i = i + 1
            End While

            If i >= intentos And OPlaca Is Nothing Then
                Throw New System.Exception("No hay un chip conectado")
            End If

            Return OPlaca
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Private Function EsperarDatosChipLectorDtiVentaCanastilla(ByVal ocara As String) As InformacionVehiculo
        Dim oDatos As New Helper
        Dim intentos As Integer = CInt(oDatos.RecuperarParametro("LecturaChipReintentos"))
        Dim Delay As Int32 = CInt(oDatos.RecuperarParametro("LecturaChipDelay"))
        Dim OPlaca As New InformacionVehiculo
        Dim oNorma As New EncriptacionDti.EncriptacionDti
        Dim i As Integer = 0
        Try
            While i <= intentos
                If LecturasLSIB4.ContainsKey(ocara) Then
                    OPlaca = DesencriptarBytesDti(False, CByte(ocara), LecturasLSIB4(ocara).ArregloBytes)
                    LecturasLSIB4.Remove(ocara)

                    If OPlaca Is Nothing Then
                        Throw New System.Exception("Retire y coloque nuevamente el chip en el lector")
                    End If

                    Exit While
                Else
                    System.Threading.Thread.Sleep(CInt(Delay / 3))
                End If

                If i >= intentos Then
                    Throw New System.Exception("No hay un chip conectado")
                End If

            End While
            Return OPlaca
        Catch ex As System.Exception
            Throw ex
        End Try
    End Function

    Public Function DesencriptarBytesDti(ByVal EsLecturaChipObligatoria As Boolean, ByVal cara As Byte, ByVal Paginas() As Byte) As InformacionVehiculo
        Dim oInformacion As New InformacionVehiculo
        Try
            Try



                Dim convercion As New System.Text.UTF8Encoding()
                Dim strSalida As String
                Dim identificador As String = ""
                Dim PuertoDti As String

                If Paginas.Length > 0 Then
                    Try



                        Dim oEncripcion As New EncriptacionDti.EncriptacionDti


                        If EsLecturaChipObligatoria Then
                            Dim ContenidoChip(127) As Byte
                            Dim j, i As Integer
                            j = 0
                            For i = 19 To Paginas.Length - 1
                                ContenidoChip(j) = Paginas(i)
                                j = j + 1
                            Next

                            Dim Temporal = New Byte(18) {}
                            Dim datos As New System.Text.UTF8Encoding()

                            i = 0
                            For i = 0 To 18
                                Temporal(i) = Paginas(i)
                            Next

                            'convierto a string los primeros 19 byets para sacar el rom y el puerto
                            strSalida = datos.GetString(Temporal)
                            If Not String.IsNullOrEmpty(strSalida) Then
                                Dim Tmp As String() = strSalida.Split(".")
                                PuertoDti = Tmp(0)
                                identificador = Tmp(1)
                            End If

                            LogCategorias.Clear()
                            LogCategorias.Agregar("SeguimientoCodigoDTI")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Mensaje", "Se saca el Rom de la cabacera del LSIB4")
                            LogPropiedades.Agregar("Rom", identificador)
                            Fabrica.LogIt.Loguear("DesencriptarDTI", LogPropiedades, LogCategorias)


                            oInformacion = oEncripcion.ExtraerInformacionPaginas(ContenidoChip, identificador, EsLecturaChipObligatoria)
                        Else
                            Dim Temporal = New Byte(18) {}
                            Dim datos As New System.Text.UTF8Encoding()

                            For i As Integer = 0 To 18
                                Temporal(i) = Paginas(i)
                            Next

                            'convierto a string los primeros 19 byets para sacar el rom y el puerto
                            strSalida = datos.GetString(Temporal)
                            If Not String.IsNullOrEmpty(strSalida) Then
                                Dim Tmp As String() = strSalida.Split(".")
                                PuertoDti = Tmp(0)
                                identificador = Tmp(1)
                            End If
                            oInformacion = oEncripcion.ExtraerInformacionPaginas(Paginas, identificador, EsLecturaChipObligatoria)
                        End If

                    Catch ex As System.Exception
                        LogCategorias.Clear()
                        LogCategorias.Agregar("SeguimientoCodigoDTI")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Mensaje", ex.Message)
                        Fabrica.LogIt.Loguear("Error recuperando ROM chip ExtraerInformacionPaginas", LogPropiedades, LogCategorias)
                        Throw ex
                    End Try

                End If

            Catch ex As System.Exception
                Throw ex
            End Try
        Catch ex As System.Exception
            Throw
        End Try
        Return oInformacion
    End Function

    Private Sub OEventos_EnviarBytesLecturaChipPorDti(Lectura As System.Array, Puerto As String, IdDispositivoDti As Integer)
        Try
            'Dim paginas(127) As Byte
            Dim paginas(146) As Byte
            Dim i As Integer
            Dim cabeceratrama(18) As Byte
            Dim trama As String
            Dim convercion As New System.Text.UTF8Encoding()
            Dim Temporal As String()
            Dim puertodti As String = ""
            Dim identificador As String
            Dim Cara As Byte = 0
            Dim oHelper As New Helper
            Dim CadenaAuxiliar As String = ""
            Dim j As Integer = 0


            If Lectura.Length >= 147 Then ''Datos de la lectura del chip

                For i = 0 To 18
                    cabeceratrama(i) = Lectura(i)
                Next


                'For i = 19 To Lectura.Length - 1
                '    paginas(j) = Lectura(i)
                '    j = j + 1
                'Next

                For i = 0 To Lectura.Length - 1
                    paginas(j) = Lectura(i)
                    j = j + 1
                Next

                'Saco la cabecera de la trama que corresponde al puerto de la dti y el rom
                trama = convercion.GetString(cabeceratrama)

                If Not String.IsNullOrEmpty(trama) Then
                    Temporal = trama.Split(".")
                    puertodti = Temporal(0)
                    identificador = Temporal(1)
                End If

                If paginas.Length >= 128 Then
                    Try

                        Cara = oHelper.RecuperarCaraPorDispositivo(IdDispositivoDti, puertodti)
                        Dim Bytes As New BytesLectura
                        Bytes.ArregloBytes = paginas


                        If LecturasLSIB4.ContainsKey(Cara.ToString) Then
                            LecturasLSIB4.Remove(Cara.ToString)
                        End If

                        LecturasLSIB4.Add(Cara.ToString, Bytes)
                    Catch ex As System.Exception

                        LogCategorias.Clear()
                        LogCategorias.Agregar("SeguimientoCodigoDTI")
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Mensaje", ex.Message)
                        Fabrica.LogIt.Loguear("Error recuperando ROM chip ExtraerInformacionPaginas", LogPropiedades, LogCategorias)
                        Throw ex
                    End Try
                End If
            Else ''Cuando se desconecta el chip


                'Aqui saco la informacion del Puerto y el donde se deconecto el chip
                For i = 0 To 4
                    cabeceratrama(i) = Lectura(i)
                Next

                Dim datos As New System.Text.UTF8Encoding()
                'convierto a string los primeros 19 byets para sacar el rom y el puerto
                CadenaAuxiliar = datos.GetString(cabeceratrama)


                LogCategorias.Clear()
                LogCategorias.Agregar("SeguimientoCodigoDTI")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Puerto Recibido", puertodti)
                Fabrica.LogIt.Loguear("Logueando la separacion de la trama cuando se desconecta el chip", LogPropiedades, LogCategorias)

                If Not String.IsNullOrEmpty(CadenaAuxiliar) Then
                    Dim cadenaTemporal As String()

                    'Hago un split para separa la trama, por ejemplo me llega I2.NC, hago el slit para sacar el puerto y la trama
                    cadenaTemporal = CadenaAuxiliar.Split(".")

                    'Almaceno el puerto

                    puertodti = cadenaTemporal(0)
                    'Aqui le informo al autorizador que se desconecto el chip de la DTI

                    Cara = oHelper.RecuperarCaraPorDispositivo(IdDispositivoDti, puertodti)
                    InformarCaraSinChipDti(Cara, puertodti, Puerto)
                Else
                    Throw New System.Exception("Falla en extraer Puerto en la trama de desconexion de chip LSIB4")
                End If


            End If

        Catch ex As System.Exception
            LogCategorias.Clear()




            LogPropiedades.Clear()
            LogPropiedades.Agregar("Mensaje", ex.Message)
            Fabrica.LogIt.Loguear("EnviarLecturasChipDti", LogPropiedades, LogCategorias)

        End Try
    End Sub

    Private Sub oEventos_EnviarAjusteDeTanquesVeederRoot(ByVal Puerto As String)
        Try
            'Solicita las alturas a la VeederRoot
            'IdTurno = 0
            OEventos.SolicitarInformarStocksTanquesCierreTurnoServicio(0)

        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "oEventos_EnviarAjusteDeTanquesVeederRoot", "Puerto: " & Puerto, "CierreTurnos")
            Throw
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "oEventos_EnviarAjusteDeTanquesVeederRoot", "Puerto: " & Puerto, "CierreTurnos")
            Throw
        Catch Ex As System.Exception
            LogFallas.ReportarError(Ex, "oEventos_EnviarAjusteDeTanquesVeederRoot", "Puerto: " & Puerto, "CierreTurnos")
            Throw
        End Try
    End Sub

    Private Sub OEventos_EnviarInformacionTanquesCierreTurnoServicio(ByRef informacionTanques As SharedEventsFuelStation.ColTanques, ByRef Idturno As Integer) Handles OEventos.EnviarInformacionTanquesCierreTurnoServicio
        Dim OHelper As New Helper
        Dim newId As String = ""
        Dim InfoTanqueEx As String = ""

        Try
            'REALIZANDO LOS AJUSTES DE OPERACION POR VEEDER ROOT
            Try
                Dim i As Int32
                Dim ListaElim As New List(Of String)
                newId = Guid.NewGuid.ToString()
                Dim SaldoTanque As Decimal = 0

                'Recupero el Ultimo Turno Cerrado
                Idturno = OHelper.RecuperarUltimoTurnoCerrado()

                If String.IsNullOrEmpty(Idturno) Then
                    Throw New System.Exception("No Existe un Turno Cerrado. No se Puede Realizar el Ajuste de Tanques Por VeederRoot.")
                End If

                'REALIZANDO AJUSTES DENTRO DE UN TURNO
                i = 0
                For Each Tanque As SharedEventsFuelStation.Tanque In informacionTanques

                    InfoTanqueEx = String.Format("Codigo:{0} - Stock:{1} - Vol. Agua:{2}", Tanque.CodTanque, Tanque.Stock, Tanque.VolumenAgua)

                    'VERIFICANDO QUE NO SE HAYA UTILIZADO INFORMACION DEL TANQUE CUANDO ES SIFON
                    If Not ListaElim.Contains(Tanque.CodTanque) Then
                        'REALIZANDO LOS AJUSTES PARA LOS TANQUES QUE NO ESTA CONECTADOS POR SIFON
                        OHelper.InsertarStockTurnoHorarioTmp(newId, Tanque.CodTanque, Idturno, Nothing, Nothing, CDec(Tanque.Stock), CDec(Tanque.VolumenAgua), CBool(IIf(i = 0, True, False)), False)
                        i += 1
                    End If
                Next

                ManagementKardex.RealizarAjustesPorOperacionTurno(newId, CInt(Idturno.ToString()), Nothing)
                'OEventos.SolicitarImprimirStocksCierreTanques(newId, Idturno.ToString, "")
                OEventos_ImprimirStocksCierreTanques(newId, Idturno.ToString(), "")

            Catch ex As System.Exception
                OEventos.ReportarExcepcion(ex.Message, True, False)
                LogFallas.ReportarError(ex, "OEventos_EnviarInformacionTanquesCierreTurnoServicio", "RealizarAjustesPorOperacionTurno, IdTurno: " & Idturno, "CierreTurnos")
            End Try
        Catch EXBD As Data.DataException
            LogFallas.ReportarError(EXBD, "OEventos_EnviarInformacionTanquesCierreTurnoServicio", "-", "CierreTurnos")
            OEventos.ReportarExcepcion(EXBD.Message, True, False)
        Catch EXSQL As Data.SqlClient.SqlException
            LogFallas.ReportarError(EXSQL, "OEventos_EnviarInformacionTanquesCierreTurnoServicio", "-", "CierreTurnos")
            OEventos.ReportarExcepcion(EXSQL.Message, True, False)
        Catch Ex As System.Exception
            LogFallas.ReportarError(Ex, "OEventos_EnviarInformacionTanquesCierreTurnoServicio", "-", "CierreTurnos")
            OEventos.ReportarExcepcion(Ex.Message, True, False)
        End Try
    End Sub



End Class

