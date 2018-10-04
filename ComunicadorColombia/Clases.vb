Imports POSstation.AccesoDatos
Imports POSstation.Fabrica


Public Class MediosPagoVenta
    Inherits POSstation.Fabrica.Disposable

    Private _IdMedioPago As Integer
    Private _Total As Decimal

    Public Property IdMedioPago() As Integer
        Get
            Return _IdMedioPago
        End Get
        Set(ByVal value As Integer)
            _IdMedioPago = value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property

    Private _ListaMediosPago As New List(Of MediosPagoVenta)
    Public Property ListaMediosPago() As List(Of MediosPagoVenta)
        Get
            Return _ListaMediosPago
        End Get
        Set(ByVal value As List(Of MediosPagoVenta))
            _ListaMediosPago = value
        End Set
    End Property

    Public Sub RecuperarMediosPagoVenta(ByVal recibo As Double)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaMediosPago.Clear()

            ODatos = OHelper.RecuperarVentaFormaPago(recibo)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As MediosPagoVenta = New MediosPagoVenta
                OMediosPagoCierreTurno.IdMedioPago = CInt(ODatos.Item("IdFormaPago"))
                OMediosPagoCierreTurno.Total = CDec(ODatos.Item("Valor"))

                ListaMediosPago.Add(OMediosPagoCierreTurno)
            End While
            ODatos.Close()
            ODatos = Nothing
        Catch ex As System.Exception
            Throw ex
        Finally
            If Not ODatos Is Nothing Then
                ODatos.Close()
                ODatos = Nothing
            End If
            Formas = Nothing
        End Try
    End Sub
End Class

Public Class LecturasManguera
    Inherits POSstation.Fabrica.Disposable

    Private _LecturaFinalElectronica As Decimal
    Private _CodIsla As String
    Private _LecturaFinalManual As Decimal
    Private _LecturaInicialElectronica As Decimal
    Private _LecturaInicialManual As Decimal
    Private _NoManguera As Integer
    Private _NoSurtidor As Integer
    Private _IdProducto As Integer

    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property

    Public Property DiferenciaLectura() As Decimal
        Get
            Return _DiferenciaLectura
        End Get
        Set(ByVal value As Decimal)
            _DiferenciaLectura = value
        End Set
    End Property
    Public Property IdMotivo() As Integer
        Get
            Return _IdMotivo
        End Get
        Set(ByVal value As Integer)
            _IdMotivo = value
        End Set
    End Property
    Public Property LecturaFinalElectronica() As Decimal
        Get
            Return _LecturaFinalElectronica
        End Get
        Set(ByVal value As Decimal)
            _LecturaFinalElectronica = value
        End Set
    End Property

    Public Property CodIsla() As String
        Get
            Return _CodIsla
        End Get
        Set(ByVal value As String)
            _CodIsla = value
        End Set
    End Property

    Public Property LecturaFinalManual() As Decimal
        Get
            Return _LecturaFinalManual
        End Get
        Set(ByVal value As Decimal)
            _LecturaFinalManual = value
        End Set
    End Property

    Public Property LecturaInicialElectronica() As Decimal
        Get
            Return _LecturaInicialElectronica
        End Get
        Set(ByVal value As Decimal)
            _LecturaInicialElectronica = value
        End Set
    End Property

    Public Property LecturaInicialManual() As Decimal
        Get
            Return _LecturaInicialManual
        End Get
        Set(ByVal value As Decimal)
            _LecturaInicialManual = value
        End Set
    End Property

    Public Property NoManguera() As Integer
        Get
            Return _NoManguera
        End Get
        Set(ByVal value As Integer)
            _NoManguera = value
        End Set
    End Property

    Public Property NoSurtidor() As Integer
        Get
            Return _NoSurtidor
        End Get
        Set(ByVal value As Integer)
            _NoSurtidor = value
        End Set
    End Property

    Private _DiferenciaLectura As Decimal
    Private _IdMotivo As Integer

    Private _ListaLecturas As New List(Of LecturasManguera)
    Public Property ListaLecturas() As List(Of LecturasManguera)
        Get
            Return _ListaLecturas
        End Get
        Set(ByVal value As List(Of LecturasManguera))
            _ListaLecturas = value
        End Set
    End Property

    Private _Lista As New List(Of LecturasManguera)

    Public Property Lista() As List(Of LecturasManguera)
        Get
            Return _Lista
        End Get
        Set(ByVal value As List(Of LecturasManguera))
            _Lista = value
        End Set
    End Property

    Public Sub RecuperarLecturasPorMangueraTurno(ByVal turno As Integer, ByVal idManguera As Integer)
        Dim ODatos As IDataReader
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim OLecturasMangueras As LecturasManguera
        Try
            _ListaLecturas.Clear()
            ODatos = OHelper.RecuperarLecturasPorMangueraTurno(turno, idManguera)
            While ODatos.Read
                OLecturasMangueras = New LecturasManguera
                If Not System.Decimal.TryParse(ODatos.Item(0), OLecturasMangueras.LecturaInicialElectronica) Then
                    Throw New InvalidCastException("La Lectura Inicial de la Manguera: " & idManguera & " no es Valida")
                End If

                If Not System.Decimal.TryParse(ODatos.Item(1), OLecturasMangueras.LecturaFinalElectronica) Then
                    Throw New InvalidCastException("La Lectura Final de la Manguera: " & idManguera & " no es Valida")
                End If
                OLecturasMangueras.LecturaInicialManual = 0
                OLecturasMangueras.LecturaFinalManual = 0
                _ListaLecturas.Add(OLecturasMangueras)
            End While
            ODatos.Close()
            ODatos = Nothing
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub

    Public Sub RecuperarMangueras(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim OLecturasMangueras As LecturasManguera
        Dim ObjMangueras As New Manguera
        Dim ObjLecturaManguera As New LecturasManguera

        Try

            _Lista.Clear()
            ObjMangueras.RecuperarListaManguerasPorTurno(turno)

            For Each OManguera As Manguera In ObjMangueras.ListaMangueras

                ObjLecturaManguera.RecuperarLecturasPorMangueraTurno(turno, OManguera.IdManguera)
                For Each OLecturasManguerasTurno As LecturasManguera In ObjLecturaManguera.ListaLecturas
                    OLecturasMangueras = New LecturasManguera
                    OLecturasMangueras.NoManguera = OManguera.IdManguera
                    OLecturasMangueras.IdProducto = OManguera.IdProducto
                    OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
                    OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
                    OLecturasMangueras.LecturaInicialElectronica = OLecturasManguerasTurno.LecturaInicialElectronica
                    OLecturasMangueras.LecturaFinalElectronica = OLecturasManguerasTurno.LecturaFinalElectronica
                    OLecturasMangueras.LecturaInicialManual = 0
                    OLecturasMangueras.LecturaFinalManual = 0
                    OLecturasMangueras.IdMotivo = 0
                    OLecturasMangueras.DiferenciaLectura = OLecturasManguerasTurno.LecturaFinalElectronica - OLecturasManguerasTurno.LecturaInicialElectronica
                    Lista.Add(OLecturasMangueras)
                Next
            Next
        Catch ex As SqlClient.SqlException
            Throw ex
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub
End Class

Public Class Manguera
    Inherits POSstation.Fabrica.Disposable

    Private _IdManguera As Integer
    Public Property IdManguera() As Integer
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Integer)
            _IdManguera = value
        End Set
    End Property

    Private _IdProducto As Integer
    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Private _Tope As Long
    Public Property Tope() As Long
        Get
            Return _Tope
        End Get
        Set(ByVal value As Long)
            _Tope = value
        End Set
    End Property

    Private _IdSurtidor As Integer


    Public Property IdSurtidor() As Integer
        Get
            Return _IdSurtidor
        End Get
        Set(ByVal value As Integer)
            _IdSurtidor = value
        End Set
    End Property

    Private _CodIsla As Integer

    Public Property CodIsla() As Integer
        Get
            Return _CodIsla
        End Get
        Set(ByVal value As Integer)
            _CodIsla = value
        End Set
    End Property

    Private _ListaMangueras As New List(Of Manguera)
    Public Property ListaMangueras() As List(Of Manguera)
        Get
            Return _ListaMangueras
        End Get
        Set(ByVal value As List(Of Manguera))
            _ListaMangueras = value
        End Set
    End Property

    Public Sub RecuperarListaManguerasPorTurno(ByVal idTurno As Integer)

        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim OMangueras As IDataReader = Nothing
        Dim OManguera As Manguera
        Try
            _ListaMangueras.Clear()
            OMangueras = OHelper.RecuperarManguerasPorTurno(idTurno)

            While OMangueras.Read
                OManguera = New Manguera

                OManguera.Descripcion = OMangueras.Item("Descripcion").ToString
                OManguera.CodIsla = OMangueras.Item("IdIsla").ToString
                OManguera.IdSurtidor = OMangueras.Item("IdSurtidor").ToString
                OManguera.IdManguera = CInt(OMangueras.Item("IdManguera"))
                OManguera.Tope = CLng(OMangueras.Item("Tope"))
                OManguera.IdProducto = CInt(OMangueras.Item("IdProducto"))
                _ListaMangueras.Add(OManguera)
            End While
            OMangueras.Close()
        Catch ex As SqlClient.SqlException
            Throw ex
        Catch ex As System.Exception
            Throw ex
        Finally
            If Not OMangueras.IsClosed Then
                OMangueras.Close()
                OMangueras = Nothing
            End If
        End Try
    End Sub


    Public Sub RecuperarListaMangueras()

        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim OMangueras As IDataReader = Nothing
        Dim OManguera As Manguera
        Try
            _ListaMangueras.Clear()
            OMangueras = OHelper.RecuperarMangueras()
            While OMangueras.Read
                OManguera = New Manguera
                OManguera.Descripcion = OMangueras.Item("Descripcion").ToString
                OManguera.IdManguera = CInt(OMangueras.Item("IdManguera"))
                OManguera.Tope = CLng(OMangueras.Item("Tope"))
                _ListaMangueras.Add(OManguera)
            End While
            OMangueras.Close()
        Catch ex As SqlClient.SqlException
            Throw ex
        Catch ex As System.Exception
            Throw ex
        Finally
            If Not OMangueras.IsClosed Then
                OMangueras.Close()
                OMangueras = Nothing
            End If
        End Try
    End Sub

End Class

Public Class FacturaCanastilla
    Inherits POSstation.Fabrica.Disposable

    Private Consecutivo_ As String
    Private _GUIDFactura As String
    Private _Cedula As String
    Private _Total As String
    Private _Resolucion As String
    Private _Fecha As DateTime
    Private _Tarjeta As POSstation.Fabrica.TarjetaFidelizacion
    Private _EsVentaCombustible As Boolean
    Private _ConDescuento As Boolean
    Private _CodigoKit As Integer
    Private _Recibo As Long
    Private _IdIsla As Integer
    Private _IdTurno As Integer
    Private _IdTipoTurnoCDC As Integer
    Private _Descuento As Decimal
    Private _ValorSinIva As Decimal
    Private _IdFormaPago As Short

    Public Property IdFormaPago() As Short
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Short)
            _IdFormaPago = value
        End Set
    End Property

    Public Property Descuento() As Decimal
        Get
            Return _Descuento
        End Get
        Set(ByVal value As Decimal)
            _Descuento = value
        End Set
    End Property

    Public Property IdTipoTurnoCDC() As Integer
        Get
            Return IdTipoTurnoCDC
        End Get
        Set(ByVal value As Integer)
            _IdTipoTurnoCDC = value
        End Set
    End Property

    Public Property IdTurno() As Integer
        Get
            Return IdTurno
        End Get
        Set(ByVal value As Integer)
            _IdTurno = value
        End Set
    End Property

    Public Property IdIsla() As Integer
        Get
            Return IdIsla
        End Get
        Set(ByVal value As Integer)
            _IdIsla = value
        End Set
    End Property

    Public Property Recibo() As Long
        Get
            Return _Recibo
        End Get
        Set(ByVal value As Long)
            _Recibo = value
        End Set
    End Property

    Public Property Consecutivo() As String
        Get
            Return Consecutivo_
        End Get
        Set(ByVal value As String)
            Consecutivo_ = value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property
    Public Property GUIDFactura() As String
        Get
            Return _GUIDFactura
        End Get
        Set(ByVal value As String)
            _GUIDFactura = value
        End Set
    End Property
    Public Property Cedula() As String
        Get
            Return _Cedula
        End Get
        Set(ByVal value As String)
            _Cedula = value
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
    Public Property Resolucion() As String
        Get
            Return _Resolucion
        End Get
        Set(ByVal value As String)
            _Resolucion = value
        End Set
    End Property
    Public Property Tarjeta() As POSstation.Fabrica.TarjetaFidelizacion
        Get
            Return _Tarjeta
        End Get
        Set(ByVal value As POSstation.Fabrica.TarjetaFidelizacion)
            _Tarjeta = value
        End Set
    End Property
    Public Property EsVentaCombustible() As Boolean
        Get
            Return _EsVentaCombustible
        End Get
        Set(ByVal value As Boolean)
            _EsVentaCombustible = value
        End Set
    End Property
    Public Property ConDescuento() As Boolean
        Get
            Return _ConDescuento
        End Get
        Set(ByVal value As Boolean)
            _ConDescuento = value
        End Set
    End Property
    Public Property ValorSinIva() As Decimal
        Get
            Return _ValorSinIva
        End Get
        Set(ByVal value As Decimal)
            _ValorSinIva = value
        End Set
    End Property
    Public Property CodigoKit() As Integer
        Get
            Return _CodigoKit
        End Get
        Set(ByVal value As Integer)
            _CodigoKit = value
        End Set
    End Property
End Class
