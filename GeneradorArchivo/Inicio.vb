Imports System
Imports System.Threading

Module Inicio
    Sub Main()
        ' Associate our class routine with the Exception Thread and
        ' display our start up form
        Dim UnHandledErrs As New Fabrica.UnHandledErrorHandler
        AddHandler Application.ThreadException, AddressOf UnHandledErrs.OnThreadException
        Application.Run(FrmFileGenerator)
        UnHandledErrs = Nothing
    End Sub
End Module