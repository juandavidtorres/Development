Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.ServiceModel
Imports System.Threading
Imports PosStation.Fabrica
Imports PosStation.AccesoDatos

Public Class VistaEstacion



    Public Shared Numero_ As Integer = 1
    Public ProductosStation As New Dictionary(Of Integer, Productos)
    Public CarasStation As New Collection()
    Public PosicionesCaras As New List(Of String)
    Public serviceHost As ServiceHost
    Public SharedEvent As ServiceSharedEvent

    Dim LogFallas As New EstacionException
    Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
    Public Sub New()
        Try
            ' Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent()
            'ConstruirCaras()
            ' OEventos = CType(CreateObject("SharedEventsFuelStation.CMensaje"), SharedEventsFuelStation.CMensaje)
            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            SharedEvent = New ServiceSharedEvent

            AddHandler SharedEvent.EventAutorizacionRequerida, AddressOf OEventos_AutorizacionRequerida
            AddHandler SharedEvent.EventCaraEnReposo, AddressOf OEventos_CaraEnReposo
            AddHandler SharedEvent.EventTurnoAbierto, AddressOf OEventos_TurnoAbierto
            AddHandler SharedEvent.EventTurnoCerrado, AddressOf OEventos_TurnoCerrado
            AddHandler SharedEvent.EventVentaAutorizada, AddressOf OEventos_VentaAutorizada
            AddHandler SharedEvent.EventVentaFinalizada, AddressOf oEventos_VentaFinalizada
            AddHandler SharedEvent.EventVentaNoAutorizada, AddressOf OEventos_VentaNoAutorizada
            AddHandler SharedEvent.EventVentaParcial, AddressOf OEventos_VentaParcial

            serviceHost = New ServiceHost(SharedEvent, New Uri("net.tcp://localhost:9000/servicemodelsamples/ServiceSharedEvent"))
            'serviceHost = New ServiceHost(SharedEvent, New Uri(My.Settings.Url))
            ' Open the ServiceHost to create listeners and start listening for messages.

            serviceHost.Open()

        Catch ex As Exception
            Try
                LogFallas.ReportarError(ex, "Sub New", "-", "DisplayStation")
            Catch

            End Try
        End Try

    End Sub


    Private Sub RecuperarProductos()
        Try
            If (Numero_ <> 1) Then
                Dim OHelper As New Helper()
                Dim ProdReader As IDataReader = OHelper.RecuperarProductos
                Dim OProducto As Productos
                While ProdReader.Read
                    OProducto = New Productos
                    OProducto.IdProducto = ProdReader.Item("IdProducto")
                    OProducto.Nombre = ProdReader.Item("Nombre")
                    OProducto.Precio = ProdReader.Item("Precio")
                    ProductosStation.Add(OProducto.IdProducto, OProducto)
                End While
                ProdReader.Close()
                ProdReader = Nothing
            End If
        Catch ex As Exception
            LogFallas.ReportarError(ex, "RecuperarProductos", "-", "DisplayStation")
        End Try
    End Sub


    Public Sub ConstruirCaras()
        Try
            Dim ProdCaras As IDataReader
            Dim OProducto As Productos = Nothing
            RecuperarProductos()

            Me.Controls.Clear()
            Dim OHelper As New Helper()

            Dim CarasData As DataSet = OHelper.RecuperarCaras()
            Dim i As Integer

            For i = 1 To CarasData.Tables(0).Rows.Count
                Dim Cara As New CaraControl

                Cara.Name = "Cara " + CarasData.Tables(0).Rows(i - 1)(0).ToString()
                Cara.Left = 4 + (i - (Math.Floor(((i - 1) / 4)) * 4) - 1) * (Cara.Width + 5)
                Cara.Top = Math.Floor(((i - 1) / 4)) * (Cara.Height + 5)

                Dim Posicion As String = Cara.Left & "|" & Cara.Top
                Me.PosicionesCaras.Add(Posicion)

                Dim OCara As New CarasProducto
                OCara.IdCara = CarasData.Tables(0).Rows(i - 1)(0).ToString()

                ProdCaras = OHelper.RecuperarProductosPorCara(CShort(i))

                While ProdCaras.Read()
                    OProducto = New Productos
                    OCara.KeyProductos.Add(CInt(ProdCaras.Item("IdProducto")))
                End While
                ProdCaras.Close()
                ProdCaras = Nothing

                'Pendient
                Me.CarasStation.Add(OCara, OCara.IdCara)

                Cara.EstadoTemporal = IIf(CBool(CarasData.Tables(0).Rows(i - 1)("Estado")), "Activa", "Inactiva")
                If (Numero_ <> 1) Then
                    Cara.EstadoTurno = OHelper.RecuperarEstadoTurno(CarasData.Tables(0).Rows(i - 1)(0).ToString())
                Else
                    Cara.EstadoTurno = "Cerrado"
                End If

                Me.Controls.Add(Cara)
            Next
            OHelper = Nothing
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ContruirCaras", "-", "DisplayStation")
        End Try
    End Sub

#Region "Hilo_AutorizacionRequerida"

    Private Sub Hilo_AutorizacionRequerida(Datos As DatosTemporalesSauce)
        Try
            ProcesoAutorizacionRequerida(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ActualizarAutorizacionRequerida", "-", "DisplayStation")
        End Try
    End Sub

    Delegate Sub CallBackActualizarAutorizacionRequerida(Datos As DatosTemporalesSauce)

    Private Sub ProcesoAutorizacionRequerida(Datos As DatosTemporalesSauce)
        Try

            For Each Ctr As Control In Me.Controls
                If Ctr.InvokeRequired Then
                    Dim Delegado As New CallBackActualizarAutorizacionRequerida(AddressOf ProcesoAutorizacionRequerida)
                    Me.Invoke(Delegado, New Object() {Datos})
                Else
                    If Ctr.Name.Equals("Cara " & Datos.Cara.ToString) Then
                        Dim OCara As CaraControl = CType(Ctr, CaraControl)
                        If OCara.EstadoTurno.Equals("Abierto") Then
                            OCara.Estado = "Autorizando"
                            If Me.ProductosStation.ContainsKey(Datos.Producto) Then
                                OCara.Producto = Me.ProductosStation(Datos.Producto).Nombre
                                OCara.Precio = Me.ProductosStation(Datos.Producto).Precio
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoAutorizacionRequerida", "-", "DisplayStation")
        End Try
    End Sub

    ' Falta Modificar el Evento Para que devuelva el Producto de esa venta
    Private Sub OEventos_AutorizacionRequerida(ByVal cara As Byte, ByVal idProducto As Integer, ByVal idManguera As Integer, ByVal lectura As String)
        Try
            Dim DatosTmp As New DatosTemporalesSauce
            DatosTmp.Cara = cara
            DatosTmp.Producto = idProducto
            DatosTmp.Manguera = idManguera
            DatosTmp.Lectura = lectura
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_AutorizacionRequerida), DatosTmp)

        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_AutorizacionRequerida", "Display Modulo", "DisplayStation")
        End Try

    End Sub

#End Region


#Region "Hilo_VentaAutorizada"
    Private Sub OEventos_VentaAutorizada(ByVal cara As Byte, ByVal precio As String, ByVal valorProgramado As String, ByVal tipoProgramacion As Byte, ByVal placa As String, ByVal idMangueraProgramada As Integer, ByVal esVentaGerenciada As Boolean)
        Try
            Dim Datos As New DatosTemporalesSauce
            Datos.Cara = cara
            Datos.Precio = precio
            Datos.Valor = valorProgramado
            Datos.Mensaje = placa
            Datos.Manguera = idMangueraProgramada
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_VentaAutorizada), Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_VentaAutorizada", "-", "DisplayStation")
        End Try
    End Sub

    Private Sub Hilo_VentaAutorizada(Datos As DatosTemporalesSauce)
        Try
            ProcesoVentaAutorizada(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_VentaAutorizada", "-", "DisplayStation")
        End Try
    End Sub

    Delegate Sub CallBackHilo_VentaAutorizada(Datos As DatosTemporalesSauce)

    Private Sub ProcesoVentaAutorizada(Datos As DatosTemporalesSauce)
        Try

            For Each Ctr As Control In Me.Controls
                If Ctr.InvokeRequired Then
                    Dim Delegado As New CallBackHilo_VentaAutorizada(AddressOf ProcesoVentaAutorizada)
                    Me.Invoke(Delegado, New Object() {Datos})
                Else
                    If Ctr.Name.Equals("Cara " & Datos.Cara.ToString) Then
                        Dim OCara As CaraControl = CType(Ctr, CaraControl)
                        OCara.Estado = "Autorizada"
                        OCara.Placa = Datos.Mensaje
                        If CDec(Datos.Precio) > 0 Then
                            OCara.Precio = Datos.Precio
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoVentaAutorizada", "-", "DisplayStation")
        End Try
    End Sub
#End Region



#Region "TurnoAbierto"
    ' Revisar este evento para que devuelva la lista de los Precios que se Actualize
    Private Sub OEventos_TurnoAbierto(ByVal surtidores As String, ByVal puerto As String, ByVal precio As System.Array)
        Try
            Dim Datos As New DatosTemporalesSauce
            Datos.Puerto = puerto
            Datos.ListaPrecio = precio
            Datos.Surtidores = surtidores
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_TurnoAbierto), Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_TurnoAbierto", "-", "DisplayStation")
        End Try
    End Sub


    Private Sub Hilo_TurnoAbierto(Datos As DatosTemporalesSauce)
        Try
            ProcesoTurnoAbierto(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_TurnoAbierto", "-", "DisplayStation")
        End Try
    End Sub

    Delegate Sub CallBackHilo_TurnoAbierto(Datos As DatosTemporalesSauce)

    Private Sub ProcesoTurnoAbierto(Datos As DatosTemporalesSauce)
        Try
            Dim ListSurtidores() As String = Datos.Surtidores.Split("|")

            For Each SurtidorActual As String In ListSurtidores
                If Not String.IsNullOrEmpty(SurtidorActual) Then
                    Dim CaraInferior As String = ((2 * CInt(SurtidorActual)) - 1).ToString()
                    Dim CaraSuperior As String = ((2 * CInt(SurtidorActual))).ToString()

                    If (Not String.IsNullOrEmpty(SurtidorActual)) Then
                        For Each Ctr As Control In Me.Controls
                            If Ctr.InvokeRequired Then
                                Dim Delegado As New CallBackHilo_TurnoAbierto(AddressOf ProcesoTurnoAbierto)
                                Me.Invoke(Delegado, New Object() {Datos})
                            Else
                                If ((Ctr.Name.Equals("Cara " & CaraInferior.ToString())) Or (Ctr.Name.Equals("Cara " & CaraSuperior.ToString()))) Then
                                    Dim OCara As CaraControl = CType(Ctr, CaraControl)
                                    OCara.EstadoTurno = "Abierto"
                                End If
                            End If
                        Next
                    End If
                End If
            Next

            For Each OProducto As String In Datos.Precio
                Dim Precios() As String = OProducto.Split("|")
                Me.ProductosStation(Precios(0)).Precio = Precios(1)
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoTurnoAbierto", "-", "DisplayStation")
        End Try
    End Sub
#End Region



#Region "TurnoCerrado"
    Public Sub OEventos_TurnoCerrado(ByVal surtidores As String, ByVal Puerto As String)
        Try
            Dim Datos As New DatosTemporalesSauce
            Datos.Puerto = Puerto
            Datos.Surtidores = surtidores
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_TurnoCerrado), Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_TurnoCerrado", "-", "DisplayStation")
        End Try
    End Sub

    Private Sub Hilo_TurnoCerrado(Datos As DatosTemporalesSauce)
        Try
            ProcesoTurnoCerrado(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_TurnoCerrado", "-", "DisplayStation")
        End Try
    End Sub
    Delegate Sub CallBackHilo_TurnoCerrado(Datos As DatosTemporalesSauce)

    Private Sub ProcesoTurnoCerrado(Datos As DatosTemporalesSauce)
        Try


            Dim ListSurtidores() As String = Datos.Surtidores.Split("|")
            For Each SurtidorActual As String In ListSurtidores
                If Not String.IsNullOrEmpty(SurtidorActual) Then
                    Dim CaraInferior As String = ((2 * CInt(SurtidorActual)) - 1).ToString()
                    Dim CaraSuperior As String = ((2 * CInt(SurtidorActual))).ToString()

                    If (Not String.IsNullOrEmpty(SurtidorActual)) Then
                        For Each Ctr As Control In Me.Controls
                            If Ctr.InvokeRequired Then
                                Dim Delegado As New CallBackHilo_TurnoCerrado(AddressOf ProcesoTurnoCerrado)
                                Me.Invoke(Delegado, New Object() {Datos})


                            Else
                                If ((Ctr.Name.Equals("Cara " & CaraInferior.ToString())) Or (Ctr.Name.Equals("Cara " & CaraSuperior.ToString()))) Then
                                    Dim OCara As CaraControl = CType(Ctr, CaraControl)
                                    OCara.EstadoTurno = "Cerrado"

                                End If
                            End If
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoTurnoCerrado", "-", "DisplayStation")
        End Try
    End Sub

#End Region

#Region "VentaNoAutorizada"
    Public Sub OEventos_VentaNoAutorizada(ByVal cara As Byte, ByVal mensaje As String)
        Try
            Dim Datos As New DatosTemporalesSauce
            Datos.Cara = cara
            Datos.Mensaje = mensaje
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_VentaParcial), Datos)

        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_VentaNoAutorizada", "-", "DisplayStation")
        End Try


    End Sub
    Delegate Sub CallBackHilo_VentaNoAutorizada(Datos As DatosTemporalesSauce)

    Private Sub Hilo_VentaNoAutorizada(Datos As DatosTemporalesSauce)
        Try
            ProcesoAutorizacionRequerida(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_VentaNoAutorizada", "-", "DisplayStation")
        End Try
    End Sub

    Private Sub ProcesoVentaNoAutorizada(Datos As DatosTemporalesSauce)
        Try
            For Each Ctrl As Control In Me.Controls
                If Ctrl.InvokeRequired Then
                    Dim Delegado As New CallBackHilo_VentaNoAutorizada(AddressOf ProcesoVentaNoAutorizada)
                    Me.Invoke(Delegado, New Object() {Datos})
                Else
                    If Ctrl.Name.Equals("Cara " & Datos.Cara.ToString) Then
                        Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                        OCara.Estado = "Denegado"
                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoVentaNoAutorizada", "-", "DisplayStation")
        End Try
    End Sub

#End Region




#Region "Venta Parcial"
    Delegate Sub CallBackHilo_VentaParcial(Datos As DatosTemporalesSauce)
    Public Sub OEventos_VentaParcial(ByVal cara As Byte, ByVal valor As String, ByVal cantidad As String)
        Try


            Dim Datos As New DatosTemporalesSauce
            Datos.Cara = cara
            Datos.Valor = valor
            Datos.Cantidad = cantidad
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_VentaParcial), Datos)

        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_VentaParcial", "-", "DisplayStation")
        End Try
    End Sub
    Private Sub ProcesoVentaParcial(Datos As DatosTemporalesSauce)
        Try


            For Each Ctr As Control In Me.Controls
                If Ctr.InvokeRequired Then
                    Dim Delegado As New CallBackHilo_VentaParcial(AddressOf ProcesoVentaParcial)
                    Me.Invoke(Delegado, New Object() {Datos})
                Else

                    If Ctr.Name.Equals("Cara " & Datos.Cara.ToString) Then
                        Dim OCara As CaraControl = CType(Ctr, CaraControl)
                        OCara.Estado = "Vendiendo"
                        OCara.Volumen = Datos.Cantidad
                        OCara.Valor = Datos.Valor
                        If String.IsNullOrEmpty(OCara.Placa) Then
                            Dim OHelper As New Helper
                            OCara.Placa = OHelper.RecuperarPlacaParcialVenta(Datos.Cara.ToString())
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoVentaAutorizada", "-", "DisplayStation")
        End Try

    End Sub
    Private Sub Hilo_VentaParcial(Datos As DatosTemporalesSauce)
        Try
            ProcesoVentaParcial(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_VentaAutorizada", "-", "DisplayStation")
        End Try
    End Sub
#End Region

#Region "Venta Finalizada"
    Private Sub oEventos_VentaFinalizada(ByVal cara As Byte, ByVal valor As String, ByVal precio As String, ByVal lecturaFinal As String, ByVal cantidad As String, ByVal producto As Byte, ByVal manguera As Integer, ByVal presionLLenado As String, ByVal lecturaInicial As String)
        Try
            Dim Datos As New DatosTemporalesSauce
            Datos.Cara = cara
            Datos.Valor = valor
            Datos.Precio = precio
            Datos.Cantidad = cantidad
            Datos.Mensaje = String.Empty
            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_VentaFinalizada), Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_CaraEnReposo", "-", "DisplayStation")
        End Try
    End Sub
    Private Sub Hilo_VentaFinalizada(Datos As DatosTemporalesSauce)
        Try
            ProcesoVentaFinalizada(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_VentaFinalizada", "-", "DisplayStation")
        End Try
    End Sub
    Delegate Sub CallBackHilo_VentaFinalizada(Datos As DatosTemporalesSauce)

    Private Sub ProcesoVentaFinalizada(Datos As DatosTemporalesSauce)
        Try
            Dim OHelper As New Helper
            For Each Ctrl As Control In Me.Controls
                If Ctrl.InvokeRequired Then
                    Dim Delegado As New CallBackHilo_VentaFinalizada(AddressOf ProcesoVentaFinalizada)
                    Me.Invoke(Delegado, New Object() {Datos})
                Else
                    If Ctrl.Name.Equals("Cara " & Datos.Cara.ToString) Then
                        Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                        OCara.Estado = "Finalizada"
                        OCara.Volumen = Datos.Cantidad
                        OCara.Valor = Datos.Valor
                        If String.IsNullOrEmpty(OCara.Placa) Then
                            Try
                                OCara.Placa = OHelper.RecuperarPlacaParcialVenta(Datos.Cara.ToString)
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoVentaFinalizada", "-", "DisplayStation")
        End Try
    End Sub
#End Region



   
#Region "Cara En Reposo"
    Public Sub OEventos_CaraEnReposo(ByVal cara As Byte, ByVal idManguera As Integer)
        Try
            Dim Datos As New DatosTemporalesSauce
            Datos.Cara = cara
            Datos.Manguera = idManguera

            Threading.ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Hilo_CaraEnReposo), Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "OEventos_CaraEnReposo", "-", "DisplayStation")
        End Try

    End Sub

    Private Sub Hilo_CaraEnReposo(Datos As DatosTemporalesSauce)
        Try
            ProcesoCaraEnReposo(Datos)
        Catch ex As Exception
            LogFallas.ReportarError(ex, "Hilo_VentaAutorizada", "-", "DisplayStation")
        End Try
    End Sub

    Delegate Sub CallBackHilo_CaraEnReposo(Datos As DatosTemporalesSauce)

    Private Sub ProcesoCaraEnReposo(Datos As DatosTemporalesSauce)
        Try

            For Each Ctr As Control In Me.Controls
                If Ctr.InvokeRequired Then
                    Dim Delegado As New CallBackHilo_CaraEnReposo(AddressOf ProcesoCaraEnReposo)
                    Me.Invoke(Delegado, New Object() {Datos})
                Else
                    If Ctr.Name.Equals("Cara " & Datos.Cara.ToString) Then
                        Dim OCara As CaraControl = CType(Ctr, CaraControl)
                        OCara.Estado = "Colgada"
                    End If
                End If
            Next
        Catch ex As Exception
            LogFallas.ReportarError(ex, "ProcesoVentaAutorizada", "-", "DisplayStation")
        End Try
    End Sub
#End Region


    Public Sub VerCarasTurnoAbierto()
        Dim IndicePosiciones As Integer = 0
        For i As Integer = 1 To Numero_
            For Each Ctrl As Control In Me.Controls
                If Ctrl.Name.Equals("Cara " & i.ToString) Then
                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                    If OCara.EstadoTurno.Equals("Cerrado") Then
                        Ctrl.Visible = False
                    Else
                        Dim Posicion() As String = Me.PosicionesCaras.Item(IndicePosiciones).Split(CChar("|"))
                        Ctrl.Top = Posicion(1)
                        Ctrl.Left = Posicion(0)
                        Ctrl.Visible = True
                        IndicePosiciones = IndicePosiciones + 1
                        'Me.Controls.Remove(Ctrl)
                    End If
                End If
            Next
        Next
    End Sub


    Public Sub VerCarasTurnoCerrado()
        Dim IndicePosiciones As Integer = 0
        For i As Integer = 1 To Numero_
            For Each Ctrl As Control In Me.Controls
                If Ctrl.Name.Equals("Cara " & i.ToString) Then
                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                    If OCara.EstadoTurno.Equals("Abierto") Then
                        Ctrl.Visible = False
                    Else
                        Dim Posicion() As String = Me.PosicionesCaras.Item(IndicePosiciones).Split(CChar("|"))
                        Ctrl.Top = Posicion(1)
                        Ctrl.Left = Posicion(0)
                        Ctrl.Visible = True
                        IndicePosiciones = IndicePosiciones + 1
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub VerCarasGasolina()
        Dim IndicePosiciones As Integer = 0
        For i As Integer = 1 To Numero_
            For Each Ctrl As Control In Me.Controls
                If Ctrl.Name.Equals("Cara " & i.ToString) Then
                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                    Dim Face As CarasProducto = Me.CarasStation(i)
                    If Face.KeyProductos.Count <= 1 Then
                        Ctrl.Visible = False
                    Else
                        Dim Posicion() As String = Me.PosicionesCaras.Item(IndicePosiciones).Split(CChar("|"))
                        Ctrl.Top = Posicion(1)
                        Ctrl.Left = Posicion(0)
                        Ctrl.Visible = True
                        IndicePosiciones = IndicePosiciones + 1
                    End If
                End If
            Next
        Next
    End Sub


    Public Sub VerCarasGas()
        Dim IndicePosiciones As Integer = 0
        For i As Integer = 1 To Numero_
            For Each Ctrl As Control In Me.Controls
                If Ctrl.Name.Equals("Cara " & i.ToString) Then
                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                    Dim Face As CarasProducto = Me.CarasStation(i)
                    If Face.KeyProductos.Count > 1 Then
                        Ctrl.Visible = False
                    Else
                        Dim Posicion() As String = Me.PosicionesCaras.Item(IndicePosiciones).Split(CChar("|"))
                        Ctrl.Top = Posicion(1)
                        Ctrl.Left = Posicion(0)
                        Ctrl.Visible = True
                        IndicePosiciones = IndicePosiciones + 1
                    End If
                End If
            Next
        Next
    End Sub



    Public Sub VerCaras()
        Dim IndicePosiciones As Integer = 0
        For i As Integer = 1 To Numero_
            For Each Ctrl As Control In Me.Controls
                If Ctrl.Name.Equals("Cara " & i.ToString) Then
                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
                    Dim Posicion() As String = Me.PosicionesCaras.Item(IndicePosiciones).Split(CChar("|"))
                    Ctrl.Top = Posicion(1)
                    Ctrl.Left = Posicion(0)
                    Ctrl.Visible = True
                    IndicePosiciones = IndicePosiciones + 1
                End If
            Next
        Next
    End Sub


End Class

'Public Class VistaEstacion
'    Public WithEvents OEventos As SharedEvents.CMensaje
'    Public Numero_ As Short = 1
'    Public ProductosStation As New Collection
'    Public CarasStation As New Collection()

'    Public WriteOnly Property NumeroCaras() As Short
'        Set(ByVal value As Short)
'            Numero_ = value
'            ConstruirCaras()
'        End Set
'    End Property

'    Public Sub New()

'        ' Llamada necesaria para el Diseñador de Windows Forms.
'        InitializeComponent()
'        'ConstruirCaras()
'        OEventos = CType(CreateObject("sharedevents.CMensaje"), SharedEvents.CMensaje)
'        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
'    End Sub


'    Private Sub RecuperarProductos()
'        Try
'            'If (Numero_ <> 1) Then
'            '    Dim OHelper As New Helper()
'            '    Dim ProdReader As IDataReader = OHelper.RecuperarProductos
'            '    Dim OProducto As Productos
'            '    While ProdReader.Read
'            '        OProducto = New Productos
'            '        OProducto.IdProducto = ProdReader.Item("IdProducto")
'            '        OProducto.Nombre = ProdReader.Item("Nombre")
'            '        'OProducto.Precio = ProdReader.Item("Precio")
'            '        OProducto.Precio = 1600
'            '        ProductosStation.Add(OProducto)
'            '    End While
'            'End If
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub


'    ' Falta La Parte de Asignar los productos con sus precios y nombres en la parte de abajo de la cara
'    Private Sub ConstruirCaras()
'        Try
'            RecuperarProductos()

'            Me.Controls.Clear()
'            Dim OHelper As New Helper()


'            For i As Integer = 1 To Numero_
'                Dim Cara As New CaraControl

'                Cara.Name = "Cara" + i.ToString()
'                Cara.Left = 4 + (i - (Convert.ToByte(((i - 1) / 4)) * 4) - 1) * (Cara.Width + 5)
'                Cara.Top = Convert.ToByte(((i - 1) / 4)) * (Cara.Height + 5)


'                Dim OCara As New CarasProducto
'                OCara.IdCara = i
'                ' Dim ProdCaras As IDataReader = OHelper.RecuperarProductosCara(i)
'                'Dim Key As Integer
'                Dim Indice As Byte = 1
'                'While ProdCaras.Read()
'                '    Key = New Integer
'                '    Key = CInt(ProdCaras.Item("IdProducto"))
'                '    OCara.KeyProductos.Add(Key)

'                '    If Indice = 1 Then
'                '        Cara.Producto1 = ProdCaras.Item("Nombre")
'                '        Cara.Precio1 = ProdCaras.Item("Precio")
'                '    End If

'                '    If Indice = 1 Then
'                '        Cara.Producto2 = ProdCaras.Item("Nombre")
'                '        Cara.Precio2 = ProdCaras.Item("Precio")
'                '    End If

'                '    If Indice = 3 Then
'                '        Cara.Producto3 = ProdCaras.Item("Nombre")
'                '        Cara.Precio3 = ProdCaras.Item("Precio")
'                '    End If

'                '    Indice = Indice + 1
'                'End While
'                Cara.Producto1 = "Gasolina"
'                Cara.Precio1 = "7098"

'                If (Numero_ <> 1) Then
'                    Cara.EstadoTurno = OHelper.RecuperarEstadoTurno(i.ToString())
'                Else
'                    Cara.EstadoTurno = "Cerrado"
'                End If

'                Me.Controls.Add(Cara)
'            Next
'            OHelper = Nothing
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub


'    ' Falta Modificar el Evento Para que devuelva el Producto de esa venta
'    Private Sub OEventos_AutorizacionRequerida(ByRef cara As Byte) Handles OEventos.AutorizacionRequerida
'        For Each Ctr As Control In Me.Controls
'            If Ctr.Name.Equals("Cara" & cara.ToString) Then
'                Dim OCara As CaraControl = CType(Ctr, CaraControl)
'                If OCara.EstadoTurno.Equals("Abierto") Then
'                    OCara.Estado = "Autorizando"
'                End If
'            End If
'        Next
'    End Sub

'    Private Sub OEventos_VentaAutorizada(ByRef cara As Byte, ByRef precio As String, ByRef valorProgramado As String, ByRef tipoProgramacion As Byte, ByRef placa As String) Handles OEventos.VentaAutorizada

'        For Each Ctr As Control In Me.Controls
'            If Ctr.Name.Equals("Cara" & cara.ToString) Then
'                Dim OCara As CaraControl = CType(Ctr, CaraControl)
'                OCara.Estado = "Autorizada"
'                OCara.Placa = placa
'            End If
'        Next
'    End Sub

'    'Modificar el Evento para que devuelva la lista de precios que cambian en esa cara
'    Private Sub OEventos_CambioPrecio(ByRef cara As Byte, ByRef valor As String) Handles OEventos.CambioPrecio
'        Dim OHelper As New Helper()

'        For Each Ctr As Control In Me.Controls
'            If Ctr.Name.Equals("Cara" & cara.ToString) Then
'                Dim OCara As CaraControl = CType(Ctr, CaraControl)
'                'OCara.Precio = valor
'                ' Debe Cambiar La Lista de Productos en Esa Cara
'            End If
'        Next
'    End Sub


'    ' Revisar este evento para que devuelva la lista de los Precios que se Actualize
'    Private Sub OEventos_TurnoAbierto(ByRef surtidores As String, ByRef puerto As String, ByRef precio As String) Handles OEventos.TurnoAbierto
'        Dim ListSurtidores() As String = surtidores.Split(CChar("|"))

'        For I As Integer = 0 To I < surtidores.Length
'            Dim SurtidorActual As String = ListSurtidores(I)
'            If Not String.IsNullOrEmpty(SurtidorActual) Then
'                Dim CaraInferior As String = ((2 * Int32.Parse(SurtidorActual)) - 1).ToString()
'                Dim CaraSuperior As String = ((2 * Int32.Parse(SurtidorActual))).ToString()

'                If (Not String.IsNullOrEmpty(SurtidorActual)) Then
'                    For Each Ctr As Control In Me.Controls
'                        If ((Ctr.Name.Equals("Cara" & CaraInferior.ToString())) Or (Ctr.Name.Equals("Cara" & CaraSuperior.ToString()))) Then
'                            Dim OCara As CaraControl = CType(Ctr, CaraControl)
'                            OCara.EstadoTurno = "Abierto"
'                            'Aqui es donde vamos a mandar la lista de precios
'                        End If
'                    Next
'                End If
'            End If
'        Next
'    End Sub

'    Public Sub OEventos_TurnoCerrado(ByRef surtidores As String, ByRef Puerto As String) Handles OEventos.TurnoCerrado
'        Dim ListSurtidores() As String = surtidores.Split(CChar("|"))

'        For I As Integer = 0 To I < surtidores.Length
'            Dim SurtidorActual As String = ListSurtidores(I)
'            If Not String.IsNullOrEmpty(SurtidorActual) Then
'                Dim CaraInferior As String = ((2 * Int32.Parse(SurtidorActual)) - 1).ToString()
'                Dim CaraSuperior As String = ((2 * Int32.Parse(SurtidorActual))).ToString()

'                If (Not String.IsNullOrEmpty(SurtidorActual)) Then
'                    For Each Ctr As Control In Me.Controls
'                        If ((Ctr.Name.Equals("Cara" & CaraInferior.ToString())) Or (Ctr.Name.Equals("Cara" & CaraSuperior.ToString()))) Then
'                            Dim OCara As CaraControl = CType(Ctr, CaraControl)
'                            OCara.EstadoTurno = "Cerrado"
'                        End If
'                    Next
'                End If
'            End If
'        Next
'    End Sub

'    Public Sub OEventos_VentaNoAutorizada(ByRef cara As Byte, ByRef mensaje As String) Handles OEventos.VentaNOautorizada
'        For Each Ctrl As Control In Me.Controls
'            If Ctrl.Name.Equals("Cara" & cara.ToString) Then
'                Dim OCara As CaraControl = CType(Ctrl, CaraControl)
'                OCara.Estado = "Denegado"
'            End If
'        Next
'    End Sub

'    Public Sub OEventos_VentaParcial(ByRef cara As Byte, ByRef valor As String, ByRef cantidad As String) Handles OEventos.VentaParcial
'        Try
'            For Each Ctrl As Control In Me.Controls
'                If Ctrl.Name.Equals("Cara" & cara.ToString) Then
'                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
'                    OCara.Estado = "Vendiendo"
'                    OCara.Volumen = cantidad
'                    OCara.Valor = valor
'                    If String.IsNullOrEmpty(OCara.Placa) Then
'                        Dim OHelper As New Helper
'                        OCara.Placa = OHelper.RecuperarPlacaParcialVenta(cara.ToString())
'                    End If

'                End If
'            Next
'        Catch ex As Exception
'            Throw ex
'        End Try

'    End Sub

'    Public Sub OEventos_VentaFinalizada(ByRef cara As Byte, ByRef valor As String, ByRef precio As String, ByRef lecturaFinal As String, ByRef cantidad As String, ByRef producto As Byte) Handles OEventos.VentaFinalizada
'        Try
'            Dim OHelper As New Helper
'            For Each Ctrl As Control In Me.Controls
'                If Ctrl.Name.Equals("Cara" & cara.ToString) Then
'                    Dim OCara As CaraControl = CType(Ctrl, CaraControl)
'                    OCara.Estado = "Finalizada"
'                    OCara.Volumen = cantidad
'                    OCara.Valor = valor
'                    If String.IsNullOrEmpty(OCara.Placa) Then
'                        OCara.Placa = OHelper.RecuperarPlacaParcialVenta(cara.ToString)
'                    End If
'                End If
'            Next
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    Public Sub OEventos_ManipulacionTeclado(ByRef cara As Byte) Handles OEventos.ManipulacionTeclado
'        For Each Ctrl As Control In Me.Controls
'            If Ctrl.Name.Equals("Cara" & cara.ToString) Then
'                Dim OCara As CaraControl = CType(Ctrl, CaraControl)
'                OCara.Estado = "Teclado"
'            End If
'        Next
'    End Sub

'    Public Sub OEventos_CaraEnReposo(ByRef cara As Byte) Handles OEventos.CaraEnReposo
'        For Each Ctrl As Control In Me.Controls
'            If Ctrl.Name.Equals("Cara" & cara.ToString) Then
'                Dim OCara As CaraControl = CType(Ctrl, CaraControl)
'                OCara.Estado = "Colgada"
'            End If
'        Next
'    End Sub

'End Class