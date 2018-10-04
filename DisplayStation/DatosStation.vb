Public Class DatosStation
    Private _Codigo As String
    Private _Nombre As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            Try
                _Codigo = value
                Me.lblCodigo.Text = value
            Catch ex as System.Exception
                Throw new System.Exception
            End Try
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            Try
                _Ciudad = value
                Me.lblCiudad.Text = value
            Catch ex as System.Exception
                Throw new System.Exception
            End Try
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
            Me.lblDireccion.Text = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
            Me.lblNit.Text = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
            Me.lblNombre.Text = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
            Me.lblTelefono.Text = value
        End Set
    End Property

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.lblFecha.Text = DateTime.Now.ToString("MMMM dd, yyyy HH:mm")
    End Sub
End Class