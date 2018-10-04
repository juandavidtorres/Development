

'----------------------------------------------------COMUNICADOR NUEVO CON CAMBIOS EN CIERRE DE TURNO Y DE DIA FALTA VALIDACION DE SALTOS DE TURNO ----------------------------------

Imports gasolutions.DataAccess

Public Class FormasPagoProducto
    Inherits POSstation.Fabrica.Disposable

    Private _TiposMedioPago As Integer
    Private _TotalAbonos As Decimal
    Private _TotalDescuentos As Decimal
    Private _TotalRecaudos As Decimal
    Private _TotalTransacciones As Integer
    Private _TotalVentasOtros As Decimal
    Private _TotalVentasGas As Decimal
    Private _TotalVentasCanastilla As Decimal
    Private _VolumenVendido As Decimal
    Private _IdProducto As Integer
    Private _IdFormaPago As Integer

    Public Property IdFormaPago() As Integer
        Get
            Return _IdFormaPago
        End Get
        Set(ByVal value As Integer)
            _IdFormaPago = value
        End Set
    End Property

    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Integer)
            _IdProducto = value
        End Set
    End Property

    Public Property TiposMedioPago() As Integer
        Get
            Return _TiposMedioPago
        End Get
        Set(ByVal value As Integer)
            _TiposMedioPago = value
        End Set
    End Property


    Public Property TotalAbonos() As Decimal
        Get
            Return _TotalAbonos
        End Get
        Set(ByVal value As Decimal)
            _TotalAbonos = value
        End Set
    End Property


    Public Property TotalDescuentos() As Decimal
        Get
            Return _TotalDescuentos
        End Get
        Set(ByVal value As Decimal)
            _TotalDescuentos = value
        End Set
    End Property


    Public Property TotalRecaudos() As Decimal
        Get
            Return _TotalRecaudos
        End Get
        Set(ByVal value As Decimal)
            _TotalRecaudos = value
        End Set
    End Property


    Public Property TotalVentasOtros() As Decimal
        Get
            Return _TotalVentasOtros
        End Get
        Set(ByVal value As Decimal)
            _TotalVentasOtros = value
        End Set
    End Property

    Public Property TotalTransacciones() As Integer
        Get
            Return _TotalTransacciones
        End Get
        Set(ByVal value As Integer)
            _TotalTransacciones = value
        End Set
    End Property

    Public Property TotalVentasGas() As Decimal
        Get
            Return _TotalVentasGas
        End Get
        Set(ByVal value As Decimal)
            _TotalVentasGas = value
        End Set
    End Property

    Public Property TotalVentasCanastilla() As Decimal
        Get
            Return _TotalVentasCanastilla
        End Get
        Set(ByVal value As Decimal)
            _TotalVentasCanastilla = value
        End Set
    End Property

    Public Property VolumenVendido() As Decimal
        Get
            Return _VolumenVendido
        End Get
        Set(ByVal value As Decimal)
            _VolumenVendido = value
        End Set
    End Property

    Private _ListaFormaPagoProducto As New List(Of FormasPagoProducto)
    Public Property ListaFormaPagoProducto() As List(Of FormasPagoProducto)
        Get
            Return _ListaFormaPagoProducto
        End Get
        Set(ByVal value As List(Of FormasPagoProducto))
            _ListaFormaPagoProducto = value
        End Set
    End Property

    'Public Sub RecuperarTotalesPorTurnoFormaPago(ByVal turno As Integer)
    '    Dim OHelper As New POSstation.AccesoDatos.SqlServer
    '    Dim ODatos As IDataReader = Nothing
    '    Dim Formas As DataSet

    '    Try
    '        Me.ListaFormaPagoProducto.Clear()
    '        Formas = OHelper.RecuperarFormasPago()
    '        For Each FormaPago As DataRow In Formas.Tables(0).Rows
    '            ODatos = OHelper.RecuperarTotalesPorTurnoFormaPago(turno, CInt(FormaPago.Item("IdFormaPago")))
    '            While ODatos.Read
    '                Dim OMediosPagoCierreTurno = New MediosPagoCierreTurno
    '                OMediosPagoCierreTurno.TiposMedioPago = CInt(FormaPago.Item("IdFormaPago"))
    '                OMediosPagoCierreTurno.TotalAbonos = CDec(ODatos.Item("Ingresos"))
    '                OMediosPagoCierreTurno.TotalDescuentos = CDec(ODatos.Item("Descuentos"))
    '                OMediosPagoCierreTurno.TotalRecaudos = CDec(ODatos.Item("Recaudos"))
    '                OMediosPagoCierreTurno.TotalTransacciones = CInt(ODatos.Item("Vehiculos"))
    '                OMediosPagoCierreTurno.TotalVentasGas = CDec(ODatos.Item("Combustible"))
    '                OMediosPagoCierreTurno.TotalVentasOtros = CDec(ODatos.Item("Canastilla"))
    '                OMediosPagoCierreTurno.VolumenVendido = CDec(ODatos.Item("Mts"))
    '                Lista.Add(OMediosPagoCierreTurno)
    '            End While
    '            ODatos.Close()
    '            ODatos = Nothing
    '        Next
    '    Catch ex As System.Exception
    '        Throw ex
    '    Finally
    '        If Not ODatos Is Nothing Then
    '            ODatos.Close()
    '            ODatos = Nothing
    '        End If
    '        Formas = Nothing
    '    End Try
    'End Sub

    Public Sub RecuperarTotalesPorTurnoFormaPagoProducto(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaFormaPagoProducto.Clear()

            ODatos = OHelper.RecuperarTotalesTurnoFormaPagoProducto(turno)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As FormasPagoProducto = New FormasPagoProducto
                OMediosPagoCierreTurno.IdFormaPago = CInt(ODatos.Item("IdFormaPago"))
                OMediosPagoCierreTurno.IdProducto = CInt(ODatos.Item("IdProducto"))
                OMediosPagoCierreTurno.TotalAbonos = CDec(ODatos.Item("Ingresos"))
                OMediosPagoCierreTurno.TotalDescuentos = CDec(ODatos.Item("Descuentos"))
                OMediosPagoCierreTurno.TotalRecaudos = CDec(ODatos.Item("Recaudos"))
                OMediosPagoCierreTurno.TotalTransacciones = CInt(ODatos.Item("Vehiculos"))
                OMediosPagoCierreTurno.TotalVentasGas = CDec(ODatos.Item("Combustible"))
                OMediosPagoCierreTurno.VolumenVendido = CDec(ODatos.Item("Mts"))
                Me.ListaFormaPagoProducto.Add(OMediosPagoCierreTurno)
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

    Public Sub RecuperarTotalesPorTurnoFormaPagoProductoCanastilla(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaFormaPagoProducto.Clear()

            ODatos = OHelper.RecuperarTotalesTurnoFormaPagoProductoCanastilla(turno)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As FormasPagoProducto = New FormasPagoProducto
                OMediosPagoCierreTurno.IdFormaPago = CInt(ODatos.Item("IdFormaPago"))
                OMediosPagoCierreTurno.TotalDescuentos = CDec(ODatos.Item("Descuentos"))
                OMediosPagoCierreTurno.TotalTransacciones = CInt(ODatos.Item("Transacciones"))
                OMediosPagoCierreTurno.TotalVentasCanastilla = CDec(ODatos.Item("TotalVentas"))
                Me.ListaFormaPagoProducto.Add(OMediosPagoCierreTurno)
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

    Public Sub RecuperarTotalesPorTurnoTrabajoFormaPagoProducto(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaFormaPagoProducto.Clear()

            ODatos = OHelper.RecuperarTotalesTurnoTrabajoFormaPagoProducto(turno)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As FormasPagoProducto = New FormasPagoProducto
                OMediosPagoCierreTurno.IdFormaPago = CInt(ODatos.Item("IdFormaPago"))
                OMediosPagoCierreTurno.TotalDescuentos = CDec(ODatos.Item("Descuentos"))
                OMediosPagoCierreTurno.TotalTransacciones = CInt(ODatos.Item("Transacciones"))
                OMediosPagoCierreTurno.TotalVentasCanastilla = CDec(ODatos.Item("TotalVentas"))
                Me.ListaFormaPagoProducto.Add(OMediosPagoCierreTurno)
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


Public Class MediosPagoTurno
    Inherits POSstation.Fabrica.Disposable

    Private _TiposMedioPago As Integer
    Private _Total As Decimal
    Private _EsCombustible As Boolean


    Public Property EsPagoCombustible() As Boolean
        Get
            Return _EsCombustible
        End Get
        Set(ByVal value As Boolean)
            _EsCombustible = value
        End Set
    End Property

    Public Property TiposMedioPago() As Integer
        Get
            Return _TiposMedioPago
        End Get
        Set(ByVal value As Integer)
            _TiposMedioPago = value
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

    Private _ListaMediosPago As New List(Of MediosPagoTurno)
    Public Property ListaMediosPago() As List(Of MediosPagoTurno)
        Get
            Return _ListaMediosPago
        End Get
        Set(ByVal value As List(Of MediosPagoTurno))
            _ListaMediosPago = value
        End Set
    End Property

    'Public Sub RecuperarTotalesPorTurnoFormaPago(ByVal turno As Integer)
    '    Dim OHelper As New POSstation.AccesoDatos.SqlServer
    '    Dim ODatos As IDataReader = Nothing
    '    Dim Formas As DataSet

    '    Try
    '        Me.ListaFormaPagoProducto.Clear()
    '        Formas = OHelper.RecuperarFormasPago()
    '        For Each FormaPago As DataRow In Formas.Tables(0).Rows
    '            ODatos = OHelper.RecuperarTotalesPorTurnoFormaPago(turno, CInt(FormaPago.Item("IdFormaPago")))
    '            While ODatos.Read
    '                Dim OMediosPagoCierreTurno = New MediosPagoCierreTurno
    '                OMediosPagoCierreTurno.TiposMedioPago = CInt(FormaPago.Item("IdFormaPago"))
    '                OMediosPagoCierreTurno.TotalAbonos = CDec(ODatos.Item("Ingresos"))
    '                OMediosPagoCierreTurno.TotalDescuentos = CDec(ODatos.Item("Descuentos"))
    '                OMediosPagoCierreTurno.TotalRecaudos = CDec(ODatos.Item("Recaudos"))
    '                OMediosPagoCierreTurno.TotalTransacciones = CInt(ODatos.Item("Vehiculos"))
    '                OMediosPagoCierreTurno.TotalVentasGas = CDec(ODatos.Item("Combustible"))
    '                OMediosPagoCierreTurno.TotalVentasOtros = CDec(ODatos.Item("Canastilla"))
    '                OMediosPagoCierreTurno.VolumenVendido = CDec(ODatos.Item("Mts"))
    '                Lista.Add(OMediosPagoCierreTurno)
    '            End While
    '            ODatos.Close()
    '            ODatos = Nothing
    '        Next
    '    Catch ex As System.Exception
    '        Throw ex
    '    Finally
    '        If Not ODatos Is Nothing Then
    '            ODatos.Close()
    '            ODatos = Nothing
    '        End If
    '        Formas = Nothing
    '    End Try
    'End Sub

    Public Sub RecuperarTotalesMediosPagoTurnoTerpel(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaMediosPago.Clear()

            ODatos = OHelper.RecuperarTotalesMediosPagoTurnoTerpel(turno)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As MediosPagoTurno = New MediosPagoTurno
                OMediosPagoCierreTurno.TiposMedioPago = CInt(ODatos.Item("IdMedioPago"))
                OMediosPagoCierreTurno.EsPagoCombustible = CBool(ODatos.Item("EsCombustible"))
                OMediosPagoCierreTurno.Total = CDec(ODatos.Item("Total"))

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

    Public Sub RecuperarTotalesMediosPagoTurnoTrabajoTerpel(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaMediosPago.Clear()

            ODatos = OHelper.RecuperarTotalesMediosPagoTurnoTrabajoTerpel(turno)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As MediosPagoTurno = New MediosPagoTurno
                OMediosPagoCierreTurno.TiposMedioPago = CInt(ODatos.Item("IdMedioPago"))
                OMediosPagoCierreTurno.EsPagoCombustible = CBool(ODatos.Item("EsCombustible"))
                OMediosPagoCierreTurno.Total = CDec(ODatos.Item("Total"))

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

Public Class PagoComplementario
    Inherits POSstation.Fabrica.Disposable

    Private _TotalVentaCanastilla As Decimal
    Public Property TotalVentaCanastilla() As Decimal
        Get
            Return _TotalVentaCanastilla
        End Get
        Set(ByVal value As Decimal)
            _TotalVentaCanastilla = value
        End Set
    End Property

    Private _TotalAbonos As Decimal

    Public Property TotalAbonos() As Decimal
        Get
            Return _TotalAbonos
        End Get
        Set(ByVal value As Decimal)
            _TotalAbonos = value
        End Set
    End Property

    Private _TotalPremios As Decimal

    Public Property TotalPremios() As Decimal
        Get
            Return _TotalPremios
        End Get
        Set(ByVal value As Decimal)
            _TotalPremios = value
        End Set
    End Property

    Private _TotalRecargas As Decimal

    Public Property TotalRecargas() As Decimal
        Get
            Return _TotalRecargas
        End Get
        Set(ByVal value As Decimal)
            _TotalRecargas = value
        End Set
    End Property

    Private _TotalCanastillaGrav As Decimal

    Public Property TotalCanastillaGrav() As Decimal
        Get
            Return _TotalCanastillaGrav
        End Get
        Set(ByVal value As Decimal)
            _TotalCanastillaGrav = value
        End Set
    End Property

    Private _TotalValorRealBonos As Decimal

    Public Property TotalValorRealBonos() As Decimal
        Get
            Return _TotalValorRealBonos
        End Get
        Set(ByVal value As Decimal)
            _TotalValorRealBonos = value
        End Set
    End Property


    Private _TotalCanastillaNoGrav As Decimal

    Public Property TotalCanastillaNoGrav() As Decimal
        Get
            Return _TotalCanastillaNoGrav
        End Get
        Set(ByVal value As Decimal)
            _TotalCanastillaNoGrav = value
        End Set
    End Property

    Private _ListaPagoComplementario As New List(Of PagoComplementario)
    Public Property ListaPagoComplementario() As List(Of PagoComplementario)
        Get
            Return _ListaPagoComplementario
        End Get
        Set(ByVal value As List(Of PagoComplementario))
            _ListaPagoComplementario = value
        End Set
    End Property

    Public Sub RecuperarTotalesComplementarios(ByVal turno As Integer)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader = Nothing
        Dim Formas As DataSet

        Try
            Me.ListaPagoComplementario.Clear()
            ODatos = OHelper.RecuperarTotalesComplementariosPorTurno(turno)
            While ODatos.Read
                Dim OMediosPagoCierreTurno As New PagoComplementario
                OMediosPagoCierreTurno.TotalVentaCanastilla = CInt(ODatos.Item("TotalVentaCanastilla"))
                OMediosPagoCierreTurno.TotalAbonos = CDec(ODatos.Item("TotalAbonos"))
                OMediosPagoCierreTurno.TotalPremios = CDec(ODatos.Item("TotalPremios"))
                OMediosPagoCierreTurno.TotalRecargas = CDec(ODatos.Item("TotalRecargas"))
                OMediosPagoCierreTurno.TotalCanastillaGrav = CDec(ODatos.Item("TotalCanastillaGrav"))
                OMediosPagoCierreTurno.TotalCanastillaNoGrav = CDec(ODatos.Item("TotalCanastillaNoGrav"))
                OMediosPagoCierreTurno.TotalValorRealBonos = CDec(ODatos.Item("TotalValorRealBonos"))
                Me.ListaPagoComplementario.Add(OMediosPagoCierreTurno)
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

'Public Class Manguera
'    Inherits POSstation.Fabrica.Disposable

'    Private _IdManguera As Integer
'    Public Property IdManguera() As Integer
'        Get
'            Return _IdManguera
'        End Get
'        Set(ByVal value As Integer)
'            _IdManguera = value
'        End Set
'    End Property

'    Private _IdProducto As Integer
'    Public Property IdProducto() As Integer
'        Get
'            Return _IdProducto
'        End Get
'        Set(ByVal value As Integer)
'            _IdProducto = value
'        End Set
'    End Property

'    Private _Descripcion As String
'    Public Property Descripcion() As String
'        Get
'            Return _Descripcion
'        End Get
'        Set(ByVal value As String)
'            _Descripcion = value
'        End Set
'    End Property

'    Private _Tope As Long
'    Public Property Tope() As Long
'        Get
'            Return _Tope
'        End Get
'        Set(ByVal value As Long)
'            _Tope = value
'        End Set
'    End Property

'    Private _IdSurtidor As Integer


'    Public Property IdSurtidor() As Integer
'        Get
'            Return _IdSurtidor
'        End Get
'        Set(ByVal value As Integer)
'            _IdSurtidor = value
'        End Set
'    End Property

'    private _CodIsla as Integer

'    Public Property CodIsla() As Integer
'        Get
'            Return _CodIsla
'        End Get
'        Set(ByVal value As Integer)
'            _CodIsla = value
'        End Set
'    End Property

'    Private _ListaMangueras As New List(Of Manguera)
'    Public Property ListaMangueras() As List(Of Manguera)
'        Get
'            Return _ListaMangueras
'        End Get
'        Set(ByVal value As List(Of Manguera))
'            _ListaMangueras = value
'        End Set
'    End Property

'    Public Sub RecuperarListaManguerasPorTurno(ByVal idTurno As Integer)

'        Dim OHelper As New POSstation.AccesoDatos.SqlServer
'        Dim OMangueras As IDataReader = Nothing
'        Dim OManguera As Manguera
'        Try
'            _ListaMangueras.Clear()
'            OMangueras = OHelper.RecuperarManguerasPorTurno(idTurno)

'            While OMangueras.Read
'                OManguera = New Manguera

'                OManguera.Descripcion = OMangueras.Item("Descripcion").ToString
'                OManguera.CodIsla = OMangueras.Item("IdIsla").ToString
'                OManguera.IdSurtidor = OMangueras.Item("IdSurtidor").ToString
'                OManguera.IdManguera = CInt(OMangueras.Item("IdManguera"))
'                OManguera.Tope = CLng(OMangueras.Item("Tope"))
'                OManguera.IdProducto = CInt(OMangueras.Item("IdProducto"))
'                _ListaMangueras.Add(OManguera)
'            End While
'            OMangueras.Close()
'        Catch ex As SqlClient.SqlException
'            Throw ex
'        Catch ex As System.Exception
'            Throw ex
'        Finally
'            If Not OMangueras.IsClosed Then
'                OMangueras.Close()
'                OMangueras = Nothing
'            End If
'        End Try
'    End Sub


'    Public Sub RecuperarListaMangueras()

'        Dim OHelper As New POSstation.AccesoDatos.SqlServer
'        Dim OMangueras As IDataReader = Nothing
'        Dim OManguera As Manguera
'        Try
'            _ListaMangueras.Clear()
'            OMangueras = OHelper.RecuperarMangueras()
'            While OMangueras.Read
'                OManguera = New Manguera
'                OManguera.Descripcion = OMangueras.Item("Descripcion").ToString
'                OManguera.IdManguera = CInt(OMangueras.Item("IdManguera"))
'                OManguera.Tope = CLng(OMangueras.Item("Tope"))
'                _ListaMangueras.Add(OManguera)
'            End While
'            OMangueras.Close()
'        Catch ex As SqlClient.SqlException
'            Throw ex
'        Catch ex As System.Exception
'            Throw ex
'        Finally
'            If Not OMangueras.IsClosed Then
'                OMangueras.Close()
'                OMangueras = Nothing
'            End If
'        End Try
'    End Sub

'End Class

Public Class LecturasCalibracion
    Private _Cantidad As Decimal
    Private _IdIsla As Int32
    Private _IdManguera As Int16
    Private _IdSurtidor As Int32
    Private _IdMotivoCalibracion As Int32
    Private _LecturaInicial As Decimal
    Private _LecturaFinal As Decimal
    Private _Precio As Decimal
    Private _IdProducto As Int32
    Private _Lista As New List(Of LecturasCalibracion)

    Public Property IdProducto() As Int32
        Get
            Return _IdProducto
        End Get
        Set(ByVal value As Int32)
            _IdProducto = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _Precio
        End Get
        Set(ByVal value As Decimal)
            _Precio = value
        End Set
    End Property
    Public Property LecturaFinal() As Decimal
        Get
            Return _LecturaFinal
        End Get
        Set(ByVal value As Decimal)
            _LecturaFinal = value
        End Set
    End Property
    Public Property LecturaInicial() As Decimal
        Get
            Return _LecturaInicial
        End Get
        Set(ByVal value As Decimal)
            _LecturaInicial = value
        End Set
    End Property
    Public Property IdMotivoCalibracion() As Int32
        Get
            Return _IdMotivoCalibracion
        End Get
        Set(ByVal value As Int32)
            _IdMotivoCalibracion = value
        End Set
    End Property
    Public Property Lista() As List(Of LecturasCalibracion)
        Get
            Return _Lista
        End Get
        Set(ByVal value As List(Of LecturasCalibracion))
            _Lista = value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property
    Public Property IdIsla() As Int32
        Get
            Return _IdIsla
        End Get
        Set(ByVal value As Int32)
            _IdIsla = value
        End Set
    End Property
    Public Property IdManguera() As Int16
        Get
            Return _IdManguera
        End Get
        Set(ByVal value As Int16)
            _IdManguera = value
        End Set
    End Property
    Public Property IdSurtidor() As Int32
        Get
            Return _IdSurtidor
        End Get
        Set(ByVal value As Int32)
            _IdSurtidor = value
        End Set
    End Property

    Public Function RecuperarCalibraciones(ByVal idTurno As Int32) As List(Of LecturasCalibracion)
        Dim OHelper As New POSstation.AccesoDatos.SqlServer
        Dim ODatos As IDataReader
        Dim Calibracion As LecturasCalibracion

        _Lista.Clear()
        ODatos = OHelper.RecuperarCalibracionesPorTurno(idTurno)
        While (ODatos.Read())
            Calibracion = New LecturasCalibracion
            Calibracion.Cantidad = CDec(ODatos.Item("Cantidad"))
            Calibracion.IdIsla = CInt(ODatos.Item("IdIsla"))
            Calibracion.IdManguera = CShort(ODatos.Item("IdManguera"))
            Calibracion.IdSurtidor = CInt(ODatos.Item("IdSurtidor"))
            If Not ODatos.Item("IdMotivoCalibracion") Is System.DBNull.Value Then
                Calibracion.IdMotivoCalibracion = CInt(ODatos.Item("IdMotivoCalibracion"))
            Else
                Calibracion.IdMotivoCalibracion = 0
            End If
            Calibracion.LecturaInicial = CDec(ODatos.Item("LecturaInicial"))
            Calibracion.LecturaFinal = CDec(ODatos.Item("LecturaFinal"))
            Calibracion.Precio = CDec(ODatos.Item("Precio"))
            Calibracion.IdProducto = CInt(ODatos.Item("IdProducto"))

            _Lista.Add(Calibracion)
        End While
        ODatos.Close()
        ODatos = Nothing

        Return _Lista
    End Function
End Class

'Public Class LecturasManguera
'    Inherits POSstation.Fabrica.Disposable

'    Private _LecturaFinalElectronica As Decimal
'    Private _CodIsla As String
'    Private _LecturaFinalManual As Decimal
'    Private _LecturaInicialElectronica As Decimal
'    Private _LecturaInicialManual As Decimal
'    Private _NoManguera As Integer
'    Private _NoSurtidor As Integer
'    Private _IdProducto As Integer



'    Public Property IdProducto() As Integer
'        Get
'            Return _IdProducto
'        End Get
'        Set(ByVal value As Integer)
'            _IdProducto = value
'        End Set
'    End Property

'    Public Property DiferenciaLectura() As Decimal
'        Get
'            Return _DiferenciaLectura
'        End Get
'        Set(ByVal value As Decimal)
'            _DiferenciaLectura = value
'        End Set
'    End Property
'    Public Property IdMotivo() As Integer
'        Get
'            Return _IdMotivo
'        End Get
'        Set(ByVal value As Integer)
'            _IdMotivo = value
'        End Set
'    End Property
'    Public Property LecturaFinalElectronica() As Decimal
'        Get
'            Return _LecturaFinalElectronica
'        End Get
'        Set(ByVal value As Decimal)
'            _LecturaFinalElectronica = value
'        End Set
'    End Property

'    Public Property CodIsla() As String
'        Get
'            Return _CodIsla
'        End Get
'        Set(ByVal value As String)
'            _CodIsla = value
'        End Set
'    End Property

'    Public Property LecturaFinalManual() As Decimal
'        Get
'            Return _LecturaFinalManual
'        End Get
'        Set(ByVal value As Decimal)
'            _LecturaFinalManual = value
'        End Set
'    End Property

'    Public Property LecturaInicialElectronica() As Decimal
'        Get
'            Return _LecturaInicialElectronica
'        End Get
'        Set(ByVal value As Decimal)
'            _LecturaInicialElectronica = value
'        End Set
'    End Property

'    Public Property LecturaInicialManual() As Decimal
'        Get
'            Return _LecturaInicialManual
'        End Get
'        Set(ByVal value As Decimal)
'            _LecturaInicialManual = value
'        End Set
'    End Property

'    Public Property NoManguera() As Integer
'        Get
'            Return _NoManguera
'        End Get
'        Set(ByVal value As Integer)
'            _NoManguera = value
'        End Set
'    End Property

'    Public Property NoSurtidor() As Integer
'        Get
'            Return _NoSurtidor
'        End Get
'        Set(ByVal value As Integer)
'            _NoSurtidor = value
'        End Set
'    End Property

'    Private _DiferenciaLectura As Decimal
'    Private _IdMotivo As Integer


'    Private _ListaLecturas As New List(Of LecturasManguera)
'    Public Property ListaLecturas() As List(Of LecturasManguera)
'        Get
'            Return _ListaLecturas
'        End Get
'        Set(ByVal value As List(Of LecturasManguera))
'            _ListaLecturas = value
'        End Set
'    End Property

'    Private _Lista As New List(Of LecturasManguera)


'    Public Property Lista() As List(Of LecturasManguera)
'        Get
'            Return _Lista
'        End Get
'        Set(ByVal value As List(Of LecturasManguera))
'            _Lista = value
'        End Set
'    End Property

'Public Sub RecuperarLecturasPorMangueraTurno(ByVal turno As Integer, ByVal idManguera As Integer)
'    Dim ODatos As IDataReader
'    Dim OHelper As New POSstation.AccesoDatos.SqlServer
'    Dim OLecturasMangueras As LecturasManguera
'    Try
'        _ListaLecturas.Clear()
'        ODatos = OHelper.RecuperarLecturasPorMangueraTurno(turno, idManguera)
'        While ODatos.Read
'            OLecturasMangueras = New LecturasManguera
'            If Not System.Decimal.TryParse(ODatos.Item(0), OLecturasMangueras.LecturaInicialElectronica) Then
'                Throw New InvalidCastException("La Lectura Inicial de la Manguera: " & idManguera & " no es Valida")
'            End If

'            If Not System.Decimal.TryParse(ODatos.Item(1), OLecturasMangueras.LecturaFinalElectronica) Then
'                Throw New InvalidCastException("La Lectura Final de la Manguera: " & idManguera & " no es Valida")
'            End If
'            OLecturasMangueras.LecturaInicialManual = 0
'            OLecturasMangueras.LecturaFinalManual = 0
'            _ListaLecturas.Add(OLecturasMangueras)
'        End While
'        ODatos.Close()
'        ODatos = Nothing
'    Catch ex As System.Exception
'        Throw ex
'    End Try
'End Sub


'Public Sub RecuperarMangueras(ByVal turno As Integer)
'    Dim OHelper As New POSstation.AccesoDatos.SqlServer
'    Dim LecturaFinal As Decimal
'    Dim OResultadoDatos As IDataReader
'    Dim OLecturasMangueras As LecturasManguera
'    Dim ObjMangueras As New Manguera
'    Dim ObjLecturaManguera As New LecturasManguera
'    Dim IdMotivo As Integer
'    Try

'        _Lista.Clear()
'        ObjMangueras.RecuperarListaManguerasPorTurno(turno)

'        For Each OManguera As Manguera In ObjMangueras.ListaMangueras

'            ObjLecturaManguera.RecuperarLecturasPorMangueraTurno(turno, OManguera.IdManguera)
'            For Each OLecturasManguerasTurno As LecturasManguera In ObjLecturaManguera.ListaLecturas

'                OResultadoDatos = OHelper.RecuperarSaltosLecturasPorTurno(turno, OManguera.IdManguera, False)

'                If OResultadoDatos.Read Then
'                    If (CDec(OResultadoDatos.Item("LecturaAnterior")) <> CDec(OLecturasManguerasTurno.LecturaInicialElectronica) And CInt(OResultadoDatos.Item("IdMotivo")) <> 4) Then
'                        'OLecturasMangueras = New LecturasManguera
'                        'OLecturasMangueras.NoManguera = OManguera.IdManguera
'                        'OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                        'OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                        'OLecturasMangueras.LecturaInicialElectronica = OLecturasManguerasTurno.LecturaInicialElectronica
'                        'OLecturasMangueras.LecturaFinalElectronica = OLecturasManguerasTurno.LecturaFinalElectronica
'                        'OLecturasMangueras.LecturaInicialManual = 0
'                        'OLecturasMangueras.LecturaFinalManual = 0
'                        'OLecturasMangueras.IdMotivo = 0
'                        'OLecturasMangueras.DiferenciaLectura = CDec(OResultadoDatos.Item("LecturaAnterior")) - CDec(OLecturasManguerasTurno.LecturaInicialElectronica)
'                        'Lista.Add(OLecturasMangueras)
'                        OLecturasMangueras = New LecturasManguera
'                        OLecturasMangueras.NoManguera = OManguera.IdManguera
'                        OLecturasMangueras.IdProducto = OManguera.IdProducto

'                        OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                        OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                        OLecturasMangueras.LecturaInicialElectronica = OLecturasManguerasTurno.LecturaInicialElectronica
'                        OLecturasMangueras.LecturaFinalElectronica = CDec(OResultadoDatos.Item("LecturaAnterior"))
'                        OLecturasMangueras.LecturaInicialManual = 0
'                        OLecturasMangueras.LecturaFinalManual = 0
'                        OLecturasMangueras.IdMotivo = 0
'                        OLecturasMangueras.DiferenciaLectura = CDec(OResultadoDatos.Item("LecturaAnterior")) - CDec(OLecturasManguerasTurno.LecturaInicialElectronica)
'                        Lista.Add(OLecturasMangueras)
'                    End If

'                    OLecturasMangueras = New LecturasManguera
'                    OLecturasMangueras.NoManguera = OManguera.IdManguera
'                    OLecturasMangueras.IdProducto = OManguera.IdProducto
'                    OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                    OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                    OLecturasMangueras.LecturaInicialElectronica = CDec(OResultadoDatos.Item("LecturaAnterior"))
'                    OLecturasMangueras.LecturaFinalElectronica = CDec(OResultadoDatos.Item("LecturaPosterior"))
'                    OLecturasMangueras.LecturaInicialManual = 0
'                    OLecturasMangueras.LecturaFinalManual = 0
'                    OLecturasMangueras.IdMotivo = CInt(OResultadoDatos.Item("IdMotivo"))
'                    OLecturasMangueras.DiferenciaLectura = CDbl(OResultadoDatos.Item("Cantidad"))



'                    'If CInt(OResultadoDatos.Item("IdMotivo")) = 3 Then
'                    '    OLecturasMangueras.DiferenciaLectura = OManguera.Tope - CDbl(OResultadoDatos.Item("LecturaAnterior")) + CDbl(OResultadoDatos.Item("LecturaPosterior"))
'                    'Else
'                    '    OLecturasMangueras.DiferenciaLectura = CDbl(OResultadoDatos.Item("LecturaPosterior")) - CDbl(OResultadoDatos.Item("LecturaAnterior"))
'                    'End If




'                    Lista.Add(OLecturasMangueras)
'                    LecturaFinal = CDbl(OResultadoDatos.Item("LecturaPosterior"))

'                    IdMotivo = CInt(OResultadoDatos.Item("IdMotivo"))

'                    While OResultadoDatos.Read
'                        If CDec(OResultadoDatos.Item("LecturaAnterior")) <> CDec(LecturaFinal) Then
'                            OLecturasMangueras = New LecturasManguera
'                            OLecturasMangueras.NoManguera = OManguera.IdManguera
'                            OLecturasMangueras.IdProducto = OManguera.IdProducto
'                            OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                            OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                            OLecturasMangueras.LecturaInicialElectronica = LecturaFinal
'                            OLecturasMangueras.LecturaFinalElectronica = CDec(OResultadoDatos.Item("LecturaAnterior"))
'                            OLecturasMangueras.LecturaInicialManual = 0
'                            OLecturasMangueras.LecturaFinalManual = 0
'                            OLecturasMangueras.IdMotivo = 0
'                            OLecturasMangueras.DiferenciaLectura = OLecturasMangueras.LecturaFinalElectronica - OLecturasMangueras.LecturaInicialElectronica
'                            Lista.Add(OLecturasMangueras)
'                        End If



'                        OLecturasMangueras = New LecturasManguera
'                        OLecturasMangueras.NoManguera = OManguera.IdManguera
'                        OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                        OLecturasMangueras.IdProducto = OManguera.IdProducto
'                        OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                        OLecturasMangueras.LecturaInicialElectronica = CDec(OResultadoDatos.Item("LecturaAnterior"))
'                        OLecturasMangueras.LecturaFinalElectronica = CDec(OResultadoDatos.Item("LecturaPosterior"))
'                        OLecturasMangueras.LecturaInicialManual = 0
'                        OLecturasMangueras.LecturaFinalManual = 0
'                        OLecturasMangueras.IdMotivo = CInt(OResultadoDatos.Item("IdMotivo"))
'                        OLecturasMangueras.DiferenciaLectura = CDbl(OResultadoDatos.Item("Cantidad"))


'                        'If CInt(OResultadoDatos.Item("IdMotivo")) = 3 Then
'                        '    OLecturasMangueras.DiferenciaLectura = OManguera.Tope - CDbl(OResultadoDatos.Item("LecturaAnterior")) + CDbl(OResultadoDatos.Item("LecturaPosterior"))
'                        'Else
'                        '    OLecturasMangueras.DiferenciaLectura = CDbl(OResultadoDatos.Item("LecturaPosterior")) - CDbl(OResultadoDatos.Item("LecturaAnterior"))
'                        'End If

'                        IdMotivo = CInt(OResultadoDatos.Item("IdMotivo"))

'                        Lista.Add(OLecturasMangueras)
'                        LecturaFinal = CDbl(OResultadoDatos.Item("LecturaPosterior"))
'                    End While

'                    If IdMotivo <> 7 And IdMotivo <> 6 And IdMotivo <> 5 Then
'                        If CDec(OLecturasManguerasTurno.LecturaFinalElectronica) <> LecturaFinal Then
'                            OLecturasMangueras = New LecturasManguera
'                            OLecturasMangueras.NoManguera = OManguera.IdManguera
'                            OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                            OLecturasMangueras.IdProducto = OManguera.IdProducto
'                            OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                            OLecturasMangueras.LecturaInicialElectronica = LecturaFinal
'                            OLecturasMangueras.LecturaFinalElectronica = OLecturasManguerasTurno.LecturaFinalElectronica
'                            OLecturasMangueras.LecturaInicialManual = 0
'                            OLecturasMangueras.LecturaFinalManual = 0
'                            OLecturasMangueras.IdMotivo = 0
'                            OLecturasMangueras.DiferenciaLectura = OLecturasManguerasTurno.LecturaFinalElectronica - LecturaFinal
'                            Lista.Add(OLecturasMangueras)
'                        End If
'                    End If

'                Else
'                    OLecturasMangueras = New LecturasManguera
'                    OLecturasMangueras.NoManguera = OManguera.IdManguera
'                    OLecturasMangueras.IdProducto = OManguera.IdProducto
'                    OLecturasMangueras.NoSurtidor = OManguera.IdSurtidor
'                    OLecturasMangueras.CodIsla = OManguera.CodIsla.ToString
'                    OLecturasMangueras.LecturaInicialElectronica = OLecturasManguerasTurno.LecturaInicialElectronica
'                    OLecturasMangueras.LecturaFinalElectronica = OLecturasManguerasTurno.LecturaFinalElectronica
'                    OLecturasMangueras.LecturaInicialManual = 0
'                    OLecturasMangueras.LecturaFinalManual = 0
'                    OLecturasMangueras.IdMotivo = 0
'                    OLecturasMangueras.DiferenciaLectura = OLecturasManguerasTurno.LecturaFinalElectronica - OLecturasManguerasTurno.LecturaInicialElectronica
'                    Lista.Add(OLecturasMangueras)
'                End If
'                OResultadoDatos.Close()
'                OResultadoDatos = Nothing
'            Next
'        Next
'    Catch ex As SqlClient.SqlException
'        Throw ex
'    Catch ex As System.Exception
'        Throw ex
'    End Try
'End Sub
'End Class


Public Class CierreDia
    Inherits POSstation.Fabrica.Disposable

    Public CodEstacion As String
    Public Fecha As Date
    Public GUID As String
    Public MediosPagos As New List(Of MedioPagoCierreDia)
End Class

Public Class MedioPagoCierreDia
    Inherits POSstation.Fabrica.Disposable

    Public TiposMedioPago As Integer
    Public TotalAbonos As Decimal
    Public TotalDescuentos As Decimal
    Public TotalRecaudos As Decimal
    Public TotalTransacciones As Integer
    Public TotalVentasOtros As Decimal
    Public TotalVentasGas As Decimal
    Public VolumenVendido As Decimal
End Class


'Public Class FacturaCanastilla
'    Inherits POSstation.Fabrica.Disposable

'    Private Consecutivo_ As String
'    Private _GUIDFactura As String
'    Private _Cedula As String
'    Private _Total As String
'    Private _Resolucion As String
'    Private _Fecha As DateTime
'    Private _Tarjeta As Factory.TarjetaFidelizacion
'    Private _EsVentaCombustible As Boolean
'    Private _ConDescuento As Boolean
'    Private _CodigoKit As Integer
'    Private _Recibo As Long
'    Private _IdIsla As Integer
'    Private _IdTurno As Integer
'    Private _IdTipoTurnoCDC As Integer

'    Public Property IdTipoTurnoCDC() As Integer
'        Get
'            Return _IdTipoTurnoCDC
'        End Get
'        Set(ByVal value As Integer)
'            _IdTipoTurnoCDC = value
'        End Set
'    End Property

'    Public Property IdTurno() As Integer
'        Get
'            Return _IdTurno
'        End Get
'        Set(ByVal value As Integer)
'            _IdTurno = value
'        End Set
'    End Property

'    Public Property IdIsla() As Integer
'        Get
'            Return _IdIsla
'        End Get
'        Set(ByVal value As Integer)
'            _IdIsla = value
'        End Set
'    End Property

'    Public Property Recibo() As Long
'        Get
'            Return _Recibo
'        End Get
'        Set(ByVal value As Long)
'            _Recibo = value
'        End Set
'    End Property

'    Public Property Consecutivo() As String
'        Get
'            Return Consecutivo_
'        End Get
'        Set(ByVal value As String)
'            Consecutivo_ = value
'        End Set
'    End Property
'    Public Property Fecha() As DateTime
'        Get
'            Return _Fecha
'        End Get
'        Set(ByVal value As DateTime)
'            _Fecha = value
'        End Set
'    End Property
'    Public Property GUIDFactura() As String
'        Get
'            Return _GUIDFactura
'        End Get
'        Set(ByVal value As String)
'            _GUIDFactura = value
'        End Set
'    End Property
'    Public Property Cedula() As String
'        Get
'            Return _Cedula
'        End Get
'        Set(ByVal value As String)
'            _Cedula = value
'        End Set
'    End Property
'    Public Property Total() As String
'        Get
'            Return _Total
'        End Get
'        Set(ByVal value As String)
'            _Total = value
'        End Set
'    End Property
'    Public Property Resolucion() As String
'        Get
'            Return _Resolucion
'        End Get
'        Set(ByVal value As String)
'            _Resolucion = value
'        End Set
'    End Property
'    Public Property Tarjeta() As Factory.TarjetaFidelizacion
'        Get
'            Return _Tarjeta
'        End Get
'        Set(ByVal value As Factory.TarjetaFidelizacion)
'            _Tarjeta = value
'        End Set
'    End Property
'    Public Property EsVentaCombustible() As Boolean
'        Get
'            Return _EsVentaCombustible
'        End Get
'        Set(ByVal value As Boolean)
'            _EsVentaCombustible = value
'        End Set
'    End Property
'    Public Property ConDescuento() As Boolean
'        Get
'            Return _ConDescuento
'        End Get
'        Set(ByVal value As Boolean)
'            _ConDescuento = value
'        End Set
'    End Property
'    Public Property CodigoKit() As Integer
'        Get
'            Return _CodigoKit
'        End Get
'        Set(ByVal value As Integer)
'            _CodigoKit = value
'        End Set
'    End Property
'End Class










'----------------------------------------------------COMUNICADOR VIEJO INSTALADO EN GAZEL ACTALMENTE-----------------------------------------------
'Public Class CierreTurno

'    Public CodEstacion As String
'    Public FechaInicialTurno As Date
'    Public FechaFinalTurno As Date
'    Public GUID As String
'    Public LectManguera As New List(Of LecturasManguera)
'    Public MedioPago As New List(Of MediosPagoCierreTurno)
'    Public PromedioTasaCambio As Decimal
'    Public PromedioValorUnidad As Decimal
'    Public Cedula As String
'End Class


'Public Class MediosPagoCierreTurno
'    Public TiposMedioPago As Integer
'    Public TotalAbonos As Decimal
'    Public TotalDescuentos As Decimal
'    Public TotalRecaudos As Decimal
'    Public TotalTransacciones As Integer
'    Public TotalVentasOtros As Decimal
'    Public TotalVentasGas As Decimal
'    Public VolumenVendido As Decimal
'End Class

'Public Class LecturasManguera
'    Public LecturaFinalElectronica As Decimal
'    Public CodIsla As String
'    Public LecturaFinalManual As Decimal
'    Public LecturaInicialElectronica As Decimal
'    Public LecturaInicialManual As Decimal
'    Public NoManguera As String
'    Public NoSurtidor As String
'End Class


'Public Class CierreDia
'    Public CodEstacion As String
'    Public Fecha As Date
'    Public GUID As String
'    Public MediosPagos As New List(Of MedioPagoCierreDia)
'End Class

'Public Class MedioPagoCierreDia
'    Public TiposMedioPago As Integer
'    Public TotalAbonos As Decimal
'    Public TotalDescuentos As Decimal
'    Public TotalRecaudos As Decimal
'    Public TotalTransacciones As Integer
'    Public TotalVentasOtros As Decimal
'    Public TotalVentasGas As Decimal
'    Public VolumenVendido As Decimal
'End Class


'Public Class FacturaCanastilla
'    Private Consecutivo_ As String
'    Private _GUIDFactura As String
'    Private _Cedula As String
'    Private _Total As String

'    Public Property Consecutivo() As String
'        Get
'            Return Consecutivo_
'        End Get
'        Set(ByVal value As String)
'            Consecutivo_ = value
'        End Set
'    End Property
'    Public Property GUIDFactura() As String
'        Get
'            Return _GUIDFactura
'        End Get
'        Set(ByVal value As String)
'            _GUIDFactura = value
'        End Set
'    End Property
'    Public Property Cedula() As String
'        Get
'            Return _Cedula
'        End Get
'        Set(ByVal value As String)
'            _Cedula = value
'        End Set
'    End Property
'    Public Property Total() As String
'        Get
'            Return _Total
'        End Get
'        Set(ByVal value As String)
'            _Total = value
'        End Set
'    End Property
'End Class









