Public Class InformacionEstacion
    Inherits Fabrica.Disposable

    Private CodigoE As String
    Private NombreE As String
    Private NitE As String
    Private DireccionE As String
    Private DireccionFiscalE As String
    Private TelefonoE As String
    Private CiudadE As String
    Private FechaInstalacionE As Date
    Private _ManejaLeydeFrontera As Boolean = False
    Private _TipoEstacion As Fabrica.TipoEstacion

    Public Property Codigo() As String
        Get
            Return CodigoE
        End Get
        Set(ByVal value As String)
            CodigoE = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return NombreE
        End Get
        Set(ByVal value As String)
            NombreE = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return NitE
        End Get
        Set(ByVal value As String)
            NitE = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return DireccionE
        End Get
        Set(ByVal value As String)
            DireccionE = value
        End Set
    End Property

    Public Property DireccionFiscal() As String
        Get
            Return DireccionFiscalE
        End Get
        Set(ByVal value As String)
            DireccionFiscalE = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return TelefonoE
        End Get
        Set(ByVal value As String)
            TelefonoE = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return CiudadE
        End Get
        Set(ByVal value As String)
            CiudadE = value
        End Set
    End Property

    Public Property FechaInstalacion() As Date
        Get
            Return FechaInstalacionE
        End Get
        Set(ByVal value As Date)
            FechaInstalacionE = value
        End Set
    End Property

    Public Property ManejaLeydeFrontera() As Boolean
        Get
            Return _ManejaLeydeFrontera
        End Get
        Set(ByVal value As Boolean)
            _ManejaLeydeFrontera = value
        End Set
    End Property
    Public Property TipoEstacion() As Fabrica.TipoEstacion
        Get
            Return _TipoEstacion
        End Get
        Set(ByVal value As Fabrica.TipoEstacion)
            _TipoEstacion = value
        End Set
    End Property

    Property Representante As String

End Class
