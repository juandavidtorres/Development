
Public Class ResponseAutorizacionIdentificador
    Private _Autorizado As Boolean
    Private _Resultado As String

    Property Autorizado() As Boolean
        Get
            Return _Autorizado
        End Get
        Set(ByVal value As Boolean)
            _Autorizado = value
        End Set
    End Property

    Property Resultado() As String
        Get
            Return _Resultado
        End Get
        Set(ByVal value As String)
            _Resultado = value
        End Set
    End Property

End Class

Public Class RespuestaSaldo
    Private _Saldo As Double
    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Double)
            _Saldo = value
        End Set
    End Property
    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property
    Private _Placa As String
    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property
End Class


Public Class MovimientoTarjeta
    Private _Fecha As String
    Private _Valor As String
    Private _Tipo As String


    Public Property FechaHora() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property


    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property
End Class