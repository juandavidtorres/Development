Imports Microsoft.VisualBasic

Public Class RespuestaInventario
    Private _Procesado As Boolean
    Private _MensajeError As String = String.Empty

    Public Property Procesado() As Boolean
        Get
            Return _Procesado
        End Get
        Set(ByVal value As Boolean)
            _Procesado = value
        End Set
    End Property

    Public Property MensajeError() As String
        Get
            Return _MensajeError
        End Get
        Set(ByVal value As String)
            _MensajeError = value
        End Set
    End Property

End Class
