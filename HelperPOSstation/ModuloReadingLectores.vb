Imports POSstation.Fabrica
Module ModuloReadingLectores

    Public IsReadingLectores As New Dictionary(Of String, Red)
    Public ColasLectores As New Dictionary(Of String, Cola)

    Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog

    Public Class Red
        Public Lector As String
        Public Puerto As String
    End Class

    Public Class Cola
        Inherits Fabrica.Disposable

        Public colLecturasPendientes As Queue(Of String)
        Sub New()
            colLecturasPendientes = New Queue(Of String)
        End Sub
    End Class

    Sub New()
        Dim oResultados As New POSstation.AccesoDatos.SqlServer
        Dim oRedes As IDataReader

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("SeguimientoCodigo")
            LogPropiedades.Clear()
            Fabrica.LogIt.Loguear("Instanciando ModuloReadingLectores", LogPropiedades, LogCategorias)

            oRedes = oResultados.RecuperarRedesOneWire()
            While oRedes.Read
                Dim redes As New Red
                redes.Lector = ""
                redes.Puerto = oRedes.Item("Puerto").ToString
                IsReadingLectores.Add(oRedes.Item("IdOneWire").ToString, redes)
                ColasLectores.Add(oRedes.Item("IdOneWire").ToString, New Cola())
            End While
            oRedes.Close()
            oRedes = Nothing
        Catch ex As System.Exception
            Throw
        End Try
    End Sub
End Module