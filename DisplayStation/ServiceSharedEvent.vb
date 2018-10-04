Imports System.ServiceModel

<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single)> _
Public Class ServiceSharedEvent
    Implements IServiceSharedEvent



#Region "Definicion de Eventos"
    Public Event EventAutorizacionRequerida(ByVal cara As Byte, ByVal idProducto As Integer, ByVal idManguera As Integer, ByVal lectura As String)
    Public Event EventTurnoAbierto(ByVal surtidores As String, ByVal puerto As String, ByVal precio As System.Array)
    Public Event EventVentaAutorizada(ByVal cara As Byte, ByVal precio As String, ByVal valorProgramado As String, ByVal tipoProgramacion As Byte, ByVal placa As String, ByVal idMangueraProgramada As Integer, ByVal esVentaGerenciada As Boolean)
    Public Event EventCaraEnReposo(ByVal cara As Byte, ByVal idManguera As Integer)
    Public Event EventTurnoCerrado(ByVal surtidores As String, ByVal Puerto As String)
    Public Event EventVentaFinalizada(ByVal cara As Byte, ByVal valor As String, ByVal precio As String, ByVal lecturaFinal As String, ByVal cantidad As String, ByVal producto As Byte, ByVal manguera As Integer, ByVal presionLLenado As String, ByVal lecturaInicial As String)
    Public Event EventVentaParcial(ByVal cara As Byte, ByVal valor As String, ByVal cantidad As String)
    Public Event EventVentaNoAutorizada(ByVal cara As Byte, ByVal mensaje As String)
#End Region


    Public Sub AutorizacionRequerida(ByVal cara As Byte, ByVal idProducto As Integer, ByVal idManguera As Integer, ByVal lectura As String) Implements IServiceSharedEvent.AutorizacionRequerida
        Try
            RaiseEvent EventAutorizacionRequerida(cara, idProducto, idManguera, lectura)
        Catch ex as System.Exception

        End Try

    End Sub

    Public Sub CaraEnReposo(ByVal cara As Byte, ByVal idManguera As Integer) Implements IServiceSharedEvent.CaraEnReposo
        Try
            RaiseEvent EventCaraEnReposo(cara, idManguera)
        Catch ex as System.Exception

        End Try

    End Sub

    Public Sub TurnoAbierto(ByVal surtidores As String, ByVal puerto As String, ByVal precio As System.Array) Implements IServiceSharedEvent.TurnoAbierto
        Try
            RaiseEvent EventTurnoAbierto(surtidores, puerto, precio)
        Catch ex as System.Exception

        End Try

    End Sub

    Public Sub TurnoCerrado(ByVal surtidores As String, ByVal Puerto As String) Implements IServiceSharedEvent.TurnoCerrado
        Try
            RaiseEvent EventTurnoCerrado(surtidores, Puerto)
        Catch ex as System.Exception

        End Try

    End Sub

    Public Sub VentaAutorizada(ByVal cara As Byte, ByVal precio As String, ByVal valorProgramado As String, ByVal tipoProgramacion As Byte, ByVal placa As String, ByVal idMangueraProgramada As Integer, ByVal esVentaGerenciada As Boolean) Implements IServiceSharedEvent.VentaAutorizada
        Try
            RaiseEvent EventVentaAutorizada(cara, precio, valorProgramado, tipoProgramacion, placa, idMangueraProgramada, esVentaGerenciada)
        Catch ex as System.Exception

        End Try
    End Sub

    Public Sub VentaNoAutorizada(ByVal cara As Byte, ByVal mensaje As String) Implements IServiceSharedEvent.VentaNoAutorizada
        Try
            RaiseEvent EventVentaNoAutorizada(cara, mensaje)
        Catch ex as System.Exception

        End Try

    End Sub

    Public Sub VentaFinalizada(ByVal cara As Byte, ByVal valor As String, ByVal precio As String, ByVal lecturaFinal As String, ByVal cantidad As String, ByVal producto As Byte, ByVal manguera As Integer, ByVal presionLLenado As String, ByVal lecturaInicial As String) Implements IServiceSharedEvent.VentaFinalizada
        Try
            RaiseEvent EventVentaFinalizada(cara, valor, precio, lecturaFinal, cantidad, producto, manguera, presionLLenado, lecturaInicial)
        Catch ex as System.Exception

        End Try

    End Sub

    Public Sub VentaParcial(ByVal cara As Byte, ByVal valor As String, ByVal cantidad As String) Implements IServiceSharedEvent.VentaParcial
        Try
            RaiseEvent EventVentaParcial(cara, valor, cantidad)
        Catch ex as System.Exception

        End Try

    End Sub
End Class
