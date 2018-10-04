Imports ComunicadorDataTrack.ComunicacionDataTrack
Imports System.Threading

Module TestService
    Dim oCore As ServicioSauce.CoreServicio

    Sub Main(ByVal args() As String)
        oCore = New ServicioSauce.CoreServicio

        Do
            Thread.Sleep(10000)
        Loop While True
    End Sub

End Module
