Public Class CaraControl
    Private _Estado As String
    Private _Placa As String
    Private _EstadoTurno As String
    Private _Volumen As String
    Private _Valor As String
    Private _Producto As String
    Private _Precio As String
    Private _EstadoCara As String
    Private _EstadoTemporal As String
    Private _IdProducto As Integer

    Private _ProdStation As New Dictionary(Of String, Productos)()


    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property

    Public Property ProdStation() As Dictionary(Of String, Productos)
        Get
            Return _ProdStation
        End Get
        Set(ByVal value As Dictionary(Of String, Productos))
            _ProdStation = value
        End Set
    End Property

    Public WriteOnly Property Estado() As String
        Set(ByVal value As String)
            Try
                _Estado = value
                lblEstado.BeginInvoke(New MethodInvoker(AddressOf ActualizarEstado))
                Application.DoEvents()
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public Property EstadoCara() As String
        Get
            Return _EstadoCara
        End Get
        Set(ByVal value As String)
            Try
                _EstadoCara = value
                lblActiva.BeginInvoke(New MethodInvoker(AddressOf ActualizarEstadoCara))
                Application.DoEvents()
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public Property EstadoTemporal() As String
        Get
            Return _EstadoTemporal
        End Get
        Set(ByVal value As String)
            Try
                _EstadoTemporal = value
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            Try
                _Placa = value
                Me.TxtPlaca.BeginInvoke(New MethodInvoker(AddressOf ActualizarPlaca))
                Application.DoEvents()
            Catch ex As Exception
                Throw
            End Try

        End Set
    End Property

    Public Property EstadoTurno() As String
        Get
            Return _EstadoTurno
        End Get
        Set(ByVal value As String)
            Try
                _EstadoTurno = value
                Application.DoEvents()
                lblEstadoTurno.BeginInvoke(New MethodInvoker(AddressOf ActualizarEstadoTurno))
                Application.DoEvents()
            Catch ex As System.InvalidOperationException
                lblEstadoTurno.Text = _EstadoTurno
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public WriteOnly Property Volumen() As String
        Set(ByVal value As String)
            Try
                _Volumen = value
                TxtVolumen.BeginInvoke(New MethodInvoker(AddressOf ActualizarVolumen))
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public WriteOnly Property Valor() As String
        Set(ByVal value As String)
            Try
                _Valor = value
                TxtValor.BeginInvoke(New MethodInvoker(AddressOf ActualizarValor))
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public WriteOnly Property Producto() As String
        'Get
        '    Return _Producto
        'End Get
        Set(ByVal value As String)
            Try
                _Producto = value
                Me.TxtProducto.BeginInvoke(New MethodInvoker(AddressOf ActualizarProducto))
                Application.DoEvents()
            Catch ex As Exception
                Throw
            End Try
        End Set
    End Property

    Public WriteOnly Property Precio() As String
        'Get
        '    Return _Precio
        'End Get
        Set(ByVal value As String)
            Try
                _Precio = value
                TxtPrecio.BeginInvoke(New MethodInvoker(AddressOf ActualizarPrecio))
                Application.DoEvents()
            Catch ex As Exception
                Throw
            End Try

        End Set
    End Property

    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub ActualizarEstado()
        lblEstado.Text = _Estado
    End Sub
    Public Sub ActualizarEstadoTurno()
        lblEstadoTurno.Text = _EstadoTurno
    End Sub

    Public Sub ActualizarVolumen()
        txtVolumen.Text = _Volumen
    End Sub

    Public Sub ActualizarValor()
        txtValor.Text = _Valor
    End Sub

    Public Sub ActualizarPlaca()
        TxtPlaca.Text = _Placa
    End Sub

    Public Sub ActualizarProducto()
        TxtProducto.Text = _Producto
    End Sub


    Public Sub ActualizarPrecio()
        Me.TxtPrecio.Text = _Precio
    End Sub

    Public Sub ActualizarEstadoCara()
        Me.lblActiva.Text = _EstadoCara
    End Sub

    Private Sub CaraControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblCara.Text = Me.Name
        Me.lblActiva.Text = EstadoTemporal
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TxtValor_Click(sender As Object, e As EventArgs) Handles TxtValor.Click

    End Sub

    Private Sub TxtVolumen_Click(sender As Object, e As EventArgs) Handles TxtVolumen.Click

    End Sub

    Private Sub lblEstadoTurno_Click(sender As Object, e As EventArgs) Handles lblEstadoTurno.Click

    End Sub
End Class