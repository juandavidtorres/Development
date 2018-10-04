Imports System
Imports System.Threading

Module Inicio
    Sub Main()
        ' Associate our class routine with the Exception Thread and
        ' display our start up form
        Dim UnHandledErrs As New POSstation.Fabrica.UnHandledErrorHandler
        AddHandler Application.ThreadException, AddressOf UnHandledErrs.OnThreadException
        Application.Run(FrmComunicador)
        UnHandledErrs = Nothing
    End Sub
End Module
