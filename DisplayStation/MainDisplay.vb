Imports POSstation.AccesoDatos
Imports PosStation.Fabrica
Imports System.ServiceModel



Public Class MainDisplay


    Public Indice As Integer = 1
    Dim dtgResultado As New DataGridView
    Dim LogFallas As New EstacionException
    Delegate Sub EventHandler(sender As Object, e As EventArgs)
    Public WithEvents oVentas As New VentasEstacion


    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        oVentas.Dock = DockStyle.Fill
        ' OEventos = CType(CreateObject("SharedEventsFuelStation.CMensaje"), SharedEventsFuelStation.CMensaje)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub ManejadorExcepcionesServicio(ByVal sender As Object, ByVal e As System.UnhandledExceptionEventArgs)
        Try

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ManejadorExcepcionesServicio", "", "Descuentos")
        End Try
    End Sub

    Public Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Try
                AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf ManejadorExcepcionesServicio
            Catch ex As System.Exception
                Try
                    LogFallas.ReportarError(ex, "MainForm_Load", "Error Asignando Manejador de execpciones no controladas: ", "ServicioWindows")
                Catch ex3 As System.Exception

                End Try
            End Try


            Dim OHelper As New Helper
            'RecuperarDatosBasicos(OHelper)
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(VistaEstacion1)
            VistaEstacion.Numero_ = OHelper.RecuperarCantidadCaras()
            VistaEstacion1.ConstruirCaras()
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Sub RecuperarDatosBasicos(ByVal oHelper As Helper)
    '    Try
    '        Dim OEstacion As InformacionEstacion = oHelper.RecuperarDatosEstacion

    '    Catch ex as System.Exception
    '        Throw new System.Exception
    '    End Try
    'End Sub

    Private Sub MainDisplay_CarasEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDSPosColombia1.CarasEvent
        Try
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(VistaEstacion1)
            VistaEstacion1.VerCaras()

        Catch ex As System.Exception
            Notificacion(ex.Message, 3000, True)
        End Try

    End Sub

    Public Sub Notificacion(mensaje As String, delay As Integer, eserror As Boolean)
        Try
            Dim Noti As New Notificacion.Notification
            Noti.Mensaje = mensaje
            Noti.EsError = eserror
            Noti.TimerTiempo = delay
            Noti.Show()
        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub MainDisplay_GasolinaEvents(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDSPosColombia1.GalsolinaEvent
        Try
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(VistaEstacion1)
            VistaEstacion1.VerCarasGasolina()

        Catch ex As System.Exception
            Notificacion(ex.Message, 3000, True)
        End Try

    End Sub

    Private Sub MainDisplay_GasEvents(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDSPosColombia1.GasEvent
        Try
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(VistaEstacion1)
            VistaEstacion1.VerCarasGas()

        Catch ex As System.Exception
            Notificacion(ex.Message, 3000, True)
        End Try

    End Sub


    Private Sub MainDisplay_CarasTurnoAbierto(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuDSPosColombia1.CarasTurnoAbiertoEvent
        Try
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(VistaEstacion1)
            VistaEstacion1.VerCarasTurnoAbierto()

        Catch ex As System.Exception

        End Try

    End Sub

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    '    Me.PnlContenido.Controls.Clear()
    '    Me.PnlContenido.Controls.Add(VistaEstacion1)
    '    VistaEstacion1.VerCaras()
    'End Sub

    'Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
    '    Me.PnlContenido.Controls.Clear()
    '    Me.PnlContenido.Controls.Add(VistaEstacion1)
    '    VistaEstacion1.VerCarasGas()
    'End Sub

    'Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
    '    Me.PnlContenido.Controls.Clear()
    '    Me.PnlContenido.Controls.Add(VistaEstacion1)
    '    VistaEstacion1.VerCarasGasolina()
    'End Sub

    'Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
    '    Me.PnlContenido.Controls.Clear()
    '    Me.PnlContenido.Controls.Add(VistaEstacion1)
    '    VistaEstacion1.VerCarasTurnoAbierto()
    'End Sub


    Private Sub MainDisplay_SalirEvent(sender As Object, e As EventArgs) Handles MnuDSPosColombia1.SalirEvent
        Try
            If MessageBox.Show("¿Desea cerrar la aplicación Display Station?", "DisplayStation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                Me.Close()
                Me.Dispose()
                Application.[Exit]()
            End If
        Catch generatedExceptionName As InvalidOperationException
            Notificacion(generatedExceptionName.Message, 3000, True)
        End Try
    End Sub




    Private Sub MainDisplay_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not Me.VistaEstacion1 Is Nothing Then
                If Not Me.VistaEstacion1.serviceHost Is Nothing Then
                    If Me.VistaEstacion1.serviceHost.State = ServiceModel.CommunicationState.Opened Then
                        Me.VistaEstacion1.serviceHost.Close()
                    End If
                End If
            End If
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub MnuDSPosColombia1_VentasEstacion(sender As Object, e As EventArgs) Handles MnuDSPosColombia1.VentasEstacion
        Try
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(oVentas)
            oVentas.IniciaControl()


        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub gsvVenta_Cerrar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles oVentas.Cerrar
        Me.PnlContenido.Controls.Clear()
        Me.PnlContenido.Controls.Add(VistaEstacion1)
        VistaEstacion1.VerCaras()
    End Sub

    Private Sub MnuDSPosColombia1_CarasSinTurnoAbiertoEvent(sender As Object, e As EventArgs) Handles MnuDSPosColombia1.CarasSinTurnoAbiertoEvent
        Try
            Me.PnlContenido.Controls.Clear()
            Me.PnlContenido.Controls.Add(VistaEstacion1)
            VistaEstacion1.VerCarasTurnoCerrado()

        Catch ex As System.Exception

        End Try
    End Sub
End Class
