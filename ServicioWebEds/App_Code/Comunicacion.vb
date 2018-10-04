Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports Microsoft.VisualBasic
Imports gasolutions.Factory
Imports POSstation.AccesoDatos

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Comunicacion
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetFileCDIGas(ByVal oArchivo() As Byte, ByVal Nombre As String) As String
        Dim Respuesta As New System.Text.StringBuilder
        Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog

        LogCategorias.Clear()
        LogCategorias.Agregar("Servicio Web")
        LogPropiedades.Clear()
        LogPropiedades.Agregar("Archivo", Nombre)
        LogPropiedades.Agregar("Longitud", oArchivo.Length)
        gasolutions.Factory.LogIt.Loguear("Longitud Archivo", LogPropiedades, LogCategorias)

        Try
            Dim oHelper As New Helper, strArchivo As String

            Dim Ruta As String = oHelper.RecuperarParametro("CarpetaSincronizacion") & "\CDIGas\"
            strArchivo = Ruta & "\CDIGas\" & Nombre

            If Not Directory.Exists(Ruta & "\CDIGas\") Then
                Directory.CreateDirectory(Ruta & "\CDIGas\")
            End If

            File.WriteAllBytes(strArchivo, oArchivo)

            Try
                'Antes debo Descomprimir el archivo
                Dim oCompresion As New Compresion

                oCompresion.Descomprimir(Ruta, strArchivo, True, True)

                oHelper.CargarBackup(Ruta)

                'Ahora elimino los .txt
                EliminarArchivosEnDirectorio(Ruta, "*.txt")
            Catch ex As System.Exception
                Respuesta.AppendLine("Tipo de Excepcion: " & ex.GetType.ToString)
                Respuesta.AppendLine("Metodo: GetFile.CargarBackupCDIGas")
                Respuesta.AppendLine("Nombre: " & Nombre)
                Respuesta.AppendLine("Mensaje: " & ex.Message)
                Respuesta.AppendLine("Pila: " & ex.StackTrace)
                Return Respuesta.ToString
            End Try
        Catch ex As System.Exception
            Respuesta.AppendLine("Tipo de Excepcion: " & ex.GetType.ToString)
            Respuesta.AppendLine("Metodo: GetFile.EscribirArchivo")
            Respuesta.AppendLine("Nombre: " & Nombre)
            Respuesta.AppendLine("Mensaje: " & ex.Message)
            Respuesta.AppendLine("Pila: " & ex.StackTrace)
            Return Respuesta.ToString
        End Try
        Return Respuesta.ToString()
    End Function

    Private Sub EliminarArchivosEnDirectorio(ByVal Directorio As String, Optional ByVal Filtro As String = "")
        Dim archivos() As String
        Try
            Try
                If Filtro <> "" Then
                    archivos = Directory.GetFiles(Directorio, Filtro)
                Else
                    archivos = Directory.GetFiles(Directorio)
                End If
            Catch ex As System.Exception
                Throw New System.Exception("Problema recuperando directorio: " & Directorio & " Filtro:" & Filtro)
            End Try

            For I As Integer = 0 To archivos.Length - 1
                Try
                    File.Delete(archivos(I))
                Catch ex As System.Exception
                    Throw New System.Exception("Problema eliminando archivo: " & archivos(I))
                End Try
            Next
        Catch
            Throw
        End Try
    End Sub

    <WebMethod()> _
    Public Function RegistrarInventarioProducto(ByVal codigoProducto As String, ByVal cantidad As Decimal, ByVal codigoTipoMovimiento As String, ByVal documentoPedido As String) As RespuestaInventario
        Dim ORespuestaInventario As New RespuestaInventario

        Try
            Dim ODatos As New Helper

            ODatos.RegistrarInventarioProductoFomplus(codigoProducto, codigoTipoMovimiento, documentoPedido, cantidad)

            ORespuestaInventario.Procesado = True
        Catch ex As System.Exception
            ORespuestaInventario.MensajeError = ex.Message
            ORespuestaInventario.Procesado = False
        End Try

        Return ORespuestaInventario
    End Function
End Class
