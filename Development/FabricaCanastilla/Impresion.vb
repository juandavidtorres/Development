Imports System.IO
Imports POSstation.Fabrica
Imports POSstation.HelperCanastilla

Public Class ImpresoraCanastilla
    Private Shared LogFallas As New EstacionException

 
    Private Shared Function RecuperarCierreParcialTurno(ByVal codigoKiosco As String) As InformacionTurno
        Dim InfoTurno As InformacionTurno
        Dim OHelper As New Helper
        Dim Datos As DataSet = Nothing
        Try
            Datos = OHelper.RecuperarCierreParcialTurno(codigoKiosco)

            If Not Datos Is Nothing Then
                InfoTurno = New InformacionTurno
                For Each OTurno As DataRow In Datos.Tables(0).Rows
                    InfoTurno.Ciudad = OTurno.Item("Ciudad").ToString
                    InfoTurno.Direccion = OTurno.Item("Direccion").ToString
                    InfoTurno.GranTotal = CDbl(OTurno.Item("GranTotal"))
                    InfoTurno.Nit = OTurno.Item("Nit").ToString
                    InfoTurno.NombreEstacion = OTurno.Item("NombreEstacion").ToString
                    InfoTurno.NroTransacciones = CDbl(OTurno.Item("NroTransacciones"))
                    InfoTurno.Telefono = OTurno.Item("Telefono").ToString
                    InfoTurno.Kiosco = OTurno.Item("Kiosco").ToString
                    InfoTurno.Empleado = OTurno.Item("NombreEmpleado").ToString
                Next
            Else
                Throw New Exception("Falla al recuperar El cierre parcial de turno en el kiosco con codigo " & codigoKiosco)
            End If
            Return InfoTurno
        Catch ex As Exception
            LogFallas.ReportarError(ex, "RecuperarCierreParcialTurno", "Codigo: " & codigoKiosco, "ImpresionTurnosCanastilla")
            Throw
        End Try
    End Function

    Private Shared Function RecuperarCierreTurno(ByVal idTurno As Int32) As InformacionTurno
        Dim InfoTurno As InformacionTurno
        Dim OHelper As New Helper
        Dim Datos As DataSet = Nothing
        Try
            Datos = OHelper.RecuperarCierreTurno(idTurno)

            If Not Datos Is Nothing Then
                InfoTurno = New InformacionTurno
                For Each OTurno As DataRow In Datos.Tables(0).Rows
                    InfoTurno.Ciudad = OTurno.Item("Ciudad").ToString
                    InfoTurno.Direccion = OTurno.Item("Direccion").ToString
                    InfoTurno.GranTotal = CDbl(OTurno.Item("GranTotal"))
                    InfoTurno.Nit = OTurno.Item("Nit").ToString
                    InfoTurno.NombreEstacion = OTurno.Item("NombreEstacion").ToString
                    InfoTurno.NroTransacciones = CDbl(OTurno.Item("NroTransacciones"))
                    InfoTurno.Telefono = OTurno.Item("Telefono").ToString
                    InfoTurno.Kiosco = OTurno.Item("Kiosco").ToString
                    InfoTurno.FechaCierre = DateTime.Parse(OTurno.Item("FechaCierre").ToString())
                    InfoTurno.FechaApertura = DateTime.Parse(OTurno.Item("FechaApertura").ToString())
                    InfoTurno.Empleado = OTurno.Item("NombreEmpleado").ToString
                Next
            Else
                Throw New Exception("Falla al recuperar El cierre de turno " & idTurno)
            End If
            Return InfoTurno
        Catch ex As Exception
            LogFallas.ReportarError(ex, "RecuperarCierreTurno", "Id Turno: " & idTurno, "ImpresionTurnosCanastilla")
            Throw
        End Try
    End Function


End Class

Public Class ImpresoraKiosco
    Private _Nombre As String
    Private _Puerto As String
    Private _ESCopia As Boolean = False
    Private _ESArqueo As Boolean = False


    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Puerto() As String
        Get
            Return _Puerto
        End Get
        Set(ByVal value As String)
            _Puerto = value
        End Set
    End Property

    Public Property ESCopia() As Boolean
        Get
            Return _ESCopia
        End Get
        Set(ByVal value As Boolean)
            _ESCopia = value
        End Set
    End Property

    Public Property ESArqueo() As Boolean
        Get
            Return _ESArqueo
        End Get
        Set(ByVal value As Boolean)
            _ESArqueo = value
        End Set
    End Property

    Public Sub New(ByVal codigoKiosco As String)
        Dim OHelper As New HelperCanastilla.Helper
        _Nombre = OHelper.RecuperarImpresoraPorKiosco(codigoKiosco)
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal codigoKiosco As String, ByVal esCopia As Boolean, ByVal esArqueo As Boolean)
        Dim OHelper As New HelperCanastilla.Helper
        _ESCopia = esCopia
        _ESArqueo = esArqueo
        _Nombre = OHelper.RecuperarImpresoraPorKiosco(codigoKiosco)
    End Sub

    Public Sub New(ByVal codigoKiosco As String, ByVal esCopia As Boolean)
        Dim OHelper As New HelperCanastilla.Helper
        _ESCopia = esCopia
        _Nombre = OHelper.RecuperarImpresoraPorKiosco(codigoKiosco)
    End Sub

    Public Sub CrearImpresoraPorTurno(ByVal turnoPrm As Int32)
        Dim OHelper As New HelperCanastilla.Helper
        _Nombre = OHelper.RecuperarImpresoraPorTurno(turnoPrm)
    End Sub

    Public Sub CrearImpresora(ByVal turnoPrm As String, ByVal esCopia As Boolean)
        Dim OHelper As New HelperCanastilla.Helper
        _Nombre = OHelper.RecuperarImpresoraPorTurno(turnoPrm)
        _ESCopia = esCopia
    End Sub
End Class

Public Class InformacionEncabezado
    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String

    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property
End Class

Public Class InformacionFactura
    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String
    Private _Fecha As String
    Private _Hora As String
    Private _Numero As String
    Private _Prefijo As String
    Private _Empleado As String
    Private _Total As String
    Private _Codigo As String


    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property Hora() As String
        Get
            Return _Hora
        End Get
        Set(ByVal value As String)
            _Hora = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property Prefijo() As String
        Get
            Return _Prefijo
        End Get
        Set(ByVal value As String)
            _Prefijo = value
        End Set
    End Property

    Public Property Empleado() As String
        Get
            Return _Empleado
        End Get
        Set(ByVal value As String)
            _Empleado = value
        End Set
    End Property

    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
End Class

Public Class InformacionTurno
    Private _Empleado As String
    Private _NombreEstacion As String
    Private _Nit As String
    Private _Direccion As String
    Private _Telefono As String
    Private _Ciudad As String
    Private _FechaCierre As DateTime
    Private _HoraCierre As DateTime
    Private _FechaApertura As DateTime
    Private _NroTransacciones As Double
    Private _Ventas As Double
    Private _IGV As Double
    Private _TotalVentas As Double
    Private _GranTotal As Double
    Private _TicketsAnulados As String
    Private _TotalAnulados As Double
    Private _TicketInicial As String
    Private _PrefVentInicial As String
    Private _PrefVentFinal As String
    Private _TicketFinal As String
    Private _Kiosco As String

    Public Property Empleado() As String
        Get
            Return _Empleado
        End Get
        Set(ByVal value As String)
            _Empleado = value
        End Set
    End Property

    Public Property Kiosco() As String
        Get
            Return _Kiosco
        End Get
        Set(ByVal value As String)
            _Kiosco = value
        End Set
    End Property

    Public Property GranTotal() As Double
        Get
            Return _GranTotal
        End Get
        Set(ByVal value As Double)
            _GranTotal = value
        End Set
    End Property

    Public Property IGV() As Double
        Get
            Return _IGV
        End Get
        Set(ByVal value As Double)
            _IGV = value
        End Set
    End Property

    Public Property NroTransacciones() As Double
        Get
            Return _NroTransacciones
        End Get
        Set(ByVal value As Double)
            _NroTransacciones = value
        End Set
    End Property

    Public Property FechaApertura() As DateTime
        Get
            Return _FechaApertura
        End Get
        Set(ByVal value As DateTime)
            _FechaApertura = value
        End Set
    End Property

    Public Property FechaCierre() As DateTime
        Get
            Return _FechaCierre
        End Get
        Set(ByVal value As DateTime)
            _FechaCierre = value
        End Set
    End Property

    Public Property HoraCierre() As DateTime
        Get
            Return _HoraCierre
        End Get
        Set(ByVal value As DateTime)
            _HoraCierre = value
        End Set
    End Property

    Public Property NombreEstacion() As String
        Get
            Return _NombreEstacion
        End Get
        Set(ByVal value As String)
            _NombreEstacion = value
        End Set
    End Property

    Public Property Nit() As String
        Get
            Return _Nit
        End Get
        Set(ByVal value As String)
            _Nit = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property PrefVentFinal() As String
        Get
            Return _PrefVentFinal
        End Get
        Set(ByVal value As String)
            _PrefVentFinal = value
        End Set
    End Property

    Public Property PrefVentInicial() As String
        Get
            Return _PrefVentInicial
        End Get
        Set(ByVal value As String)
            _PrefVentInicial = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return _Ciudad
        End Get
        Set(ByVal value As String)
            _Ciudad = value
        End Set
    End Property

    Public Property TicketFinal() As String
        Get
            Return _TicketFinal
        End Get
        Set(ByVal value As String)
            _TicketFinal = value
        End Set
    End Property

    Public Property TicketInicial() As String
        Get
            Return _TicketInicial
        End Get
        Set(ByVal value As String)
            _TicketInicial = value
        End Set
    End Property

    Public Property TicketsAnulados() As String
        Get
            Return _TicketsAnulados
        End Get
        Set(ByVal value As String)
            _TicketsAnulados = value
        End Set
    End Property

    Public Property TotalAnulados() As Double
        Get
            Return _TotalAnulados
        End Get
        Set(ByVal value As Double)
            _TotalAnulados = value
        End Set
    End Property

    Public Property TotalVentas() As Double
        Get
            Return _TotalVentas
        End Get
        Set(ByVal value As Double)
            _TotalVentas = value
        End Set
    End Property

    Public Property Ventas() As Double
        Get
            Return _Ventas
        End Get
        Set(ByVal value As Double)
            _Ventas = value
        End Set
    End Property
End Class