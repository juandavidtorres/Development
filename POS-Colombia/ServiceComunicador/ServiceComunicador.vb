Imports System.Threading
Imports System.ComponentModel
Imports System.IO


Public Class ServiceComunicador

    Public Sub test()
        ocore = New CoreServicio
    End Sub
    Private ocore As CoreServicio

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregue el código aquí para iniciar el servicio. Este método debería poner
        ' en movimiento los elementos para que el servicio pueda funcionar.

        '    '*****************************************************************************
        Try

            If (Not System.Diagnostics.EventLog.SourceExists("LogueoSauce")) Then

                System.Diagnostics.EventLog.CreateEventSource("LogueoSauce", "LogIlimited")
            End If
            EventLog1.Source = "LogueoSauce"
            EventLog1.Log = "LogIlimited"


            
            ocore = New CoreServicio


        Catch ex As System.Exception
            EventLog1.WriteEntry("Error Iniciando el servicio comunicador HO: " & ex.Message)
            Try
                ocore.Terminar()
                ocore = Nothing
            Catch ex2 As System.Exception
            End Try
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        Try
            ocore.Terminar()
            ocore = Nothing
        Catch ex As System.Exception
            EventLog1.WriteEntry("Error deteniendo el servicio comunicador HO: " & ex.Message)
        End Try

        ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.

        EventLog1.WriteEntry("Se Detuvo la ejecucion del  Comunicador CDCIG Terpel")
        

    End Sub



End Class
