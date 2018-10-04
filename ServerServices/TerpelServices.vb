Public Class AutorizationRemoteCDC

    'Public Shared Function AutorizarCreditoCorporativo(ByVal rom As String, ByVal producto As Integer, ByVal preset As Decimal) As CreditoCorporativo
    '    Dim Credito As New CreditoCorporativo
    '    Dim Servicio As New CDCTerpel.Service
    '    Dim ResponseCDC As CDCTerpel.RespuestaAutorizacion

    '    Try
    '        ResponseCDC = Servicio.EsVentaAutorizada(rom, producto, preset)
    '        Credito.Procesado = True
    '        Credito.Credito = ResponseCDC.Credito
    '        Credito.FormaPago = ResponseCDC.FormaPago
    '        Credito.EsCredito = ResponseCDC.EsCredito
    '        Credito.MsgError = ResponseCDC.MsgError
    '        Credito.Placa = ResponseCDC.Placa
    '        Credito.Saldo = ResponseCDC.Saldo
    '        Credito.TipoPreset = ResponseCDC.TipoPreset
    '        'Credito.EsCupoReservado = ResponseCDC.EsCupoReservado

    '        Return Credito
    '    Catch ex As Exception
    '        Credito.Procesado = False
    '        Credito.MsgError = ex.Message
    '        Return Credito
    '    End Try
    'End Function


End Class

Public Class CreditoCorporativo

    Private _Placa As String = ""
    Private _EsCredito As Boolean
    Private _Saldo As Decimal
    Private _TipoPreset As Boolean
    Private _MsgError As String = ""
    Private _FormaPago As Integer
    Private _Credito As Integer
    Private _Procesado As Boolean
    Private _EsCupoReservado As Boolean


    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property EsCredito() As Boolean
        Get
            Return _EsCredito
        End Get
        Set(ByVal value As Boolean)
            _EsCredito = value
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Decimal)
            _Saldo = value
        End Set
    End Property
    Public Property TipoPreset() As Boolean
        Get
            Return _TipoPreset
        End Get
        Set(ByVal value As Boolean)
            _TipoPreset = value
        End Set
    End Property
    Public Property MsgError() As String
        Get
            Return _MsgError
        End Get
        Set(ByVal value As String)
            _MsgError = value
        End Set
    End Property
    Public Property FormaPago() As Integer
        Get
            Return _FormaPago
        End Get
        Set(ByVal value As Integer)
            _FormaPago = value
        End Set
    End Property
    Public Property Credito() As Integer
        Get
            Return _Credito
        End Get
        Set(ByVal value As Integer)
            _Credito = value
        End Set
    End Property
    Public Property EsCupoReservado() As Boolean
        Get
            Return _EsCupoReservado
        End Get
        Set(ByVal value As Boolean)
            _EsCupoReservado = value
        End Set
    End Property

End Class
