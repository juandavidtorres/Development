Imports POSstation.AccesoDatos

Module modFileGenerator

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="fFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarVentas(ByVal Finicial As String, ByVal fFinal As String) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarVentasParaArchivo(Finicial, fFinal)
        Catch
            Throw
        End Try
    End Function
   

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="fFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarPagos(ByVal Finicial As String, ByVal fFinal As String) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarPagosParaArchivo(Finicial, fFinal)
        Catch
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="fFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarLecturas(ByVal Finicial As String, ByVal fFinal As String) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarLecturasParaArchivo(Finicial, fFinal)
        Catch
            Throw
        End Try
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="fFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarReversiones(ByVal Finicial As String, ByVal fFinal As String) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarReversionesParaArchivo(Finicial, fFinal)
        Catch
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="fFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarSunat(ByVal Finicial As String, ByVal fFinal As String) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarSunatParaArchivo(Finicial, fFinal)
        Catch
            Throw
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Finicial"></param>
    ''' <param name="fFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarDocumentos(ByVal Finicial As String, ByVal fFinal As String) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarDocumentosParaArchivo(Finicial, fFinal)
        Catch
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FechaInicial"></param>
    ''' <param name="FechaFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarVentasFidelizadasParaArchivo(ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarVentasFidelizadasParaArchivo(FechaInicial, FechaFinal)
        Catch
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FechaInicial"></param>
    ''' <param name="FechaFinal"></param>
    ''' <returns></returns>
    ''' <remarks>Las fechas deben pasarse en el formato yyyyMMdd</remarks>
    Public Function RecuperarVentasFidelizadasBonoParaArchivo(ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarVentasFidelizadasBonoParaArchivo(FechaInicial, FechaFinal)
        Catch
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FechaInicial"></param>
    ''' <param name="FechaFinal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarResumenVentaArchivo(ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarResumenVentaArchivo(FechaInicial, FechaFinal)
        Catch
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="FechaInicial"></param>
    ''' <param name="FechaFinal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarDetalleVentasArchivo(ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarDetalleVentasArchivo(FechaInicial, FechaFinal)
        Catch
            Throw
        End Try
    End Function
    Public Function RecuperarVentasDetalladasArchivo(ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataSet
        Try
            Dim ohelper As New Helper

            Return ohelper.RecuperarVentasDetalladasArchivo(FechaInicial, FechaFinal)
        Catch
            Throw
        End Try
    End Function
    
End Module
