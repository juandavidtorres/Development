Imports System.ServiceProcess
Imports POSstation.Fabrica
Imports System.Threading

Public Class ServiceController
    Private Shared LogFallas As New EstacionException
    Private Shared service As System.ServiceProcess.ServiceController = Nothing
    Private Shared LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog

    Private Shared Sub RunServiceThread(nameService As String)
        Try

            service = New System.ServiceProcess.ServiceController(nameService)
            If service.Status = ServiceControllerStatus.Running Then
                If service.CanStop Then
                    service.Stop()
                    System.Threading.Thread.Sleep(3000)
                    service.Start()
                End If
            End If
            System.Threading.Thread.Sleep(3000)
            service.Refresh()

            If service.Status = ServiceControllerStatus.Stopped Then
                service.Refresh()
                System.Threading.Thread.Sleep(3000)
                service.Start()
            End If

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RunServiceThread", Nothing, "Servicio")
        End Try
    End Sub

    Public Shared Sub RunService(nameService As String)
        Try
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf RunServiceThread), nameService)

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RunService", Nothing, "Servicio")
        End Try
    End Sub

End Class
