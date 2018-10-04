Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
<ServiceContract()> _
Public Interface IServiceSharedEvent

    <OperationContract()> _
    Sub AutorizacionRequerida(ByVal cara As Byte, ByVal idProducto As Integer, ByVal idManguera As Integer, ByVal lectura As String)


    <OperationContract()> _
    Sub VentaAutorizada(ByVal cara As Byte, ByVal precio As String, ByVal valorProgramado As String, ByVal tipoProgramacion As Byte, ByVal placa As String, ByVal idMangueraProgramada As Integer, ByVal esVentaGerenciada As Boolean)


    <OperationContract()> _
    Sub TurnoAbierto(ByVal surtidores As String, ByVal puerto As String, ByVal precio As System.Array)

    <OperationContract()> _
    Sub TurnoCerrado(ByVal surtidores As String, ByVal Puerto As String)


    <OperationContract()> _
    Sub VentaNoAutorizada(ByVal cara As Byte, ByVal mensaje As String)


    <OperationContract()> _
    Sub VentaParcial(ByVal cara As Byte, ByVal valor As String, ByVal cantidad As String)


    <OperationContract()> _
    Sub VentaFinalizada(ByVal cara As Byte, ByVal valor As String, ByVal precio As String, ByVal lecturaFinal As String, ByVal cantidad As String, ByVal producto As Byte, ByVal manguera As Integer, ByVal presionLLenado As String, ByVal lecturaInicial As String)

    <OperationContract()> _
    Sub CaraEnReposo(ByVal cara As Byte, ByVal idManguera As Integer)


End Interface