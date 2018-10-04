Imports POSstation.Fabrica
Imports POSstation.AccesoDatos
Imports System.IO
Imports POSstation
Imports POSstation.AccesoDatos.Helper


Public Class Comunicador
    Private ErrorVentas As String, txtVentas As String, ValorVentas As String
    Private Recibo_ As Double
    Private EnviarVentas As Boolean, Enviando As Boolean
    Private Mensaje As String
    Dim LogFallas As New EstacionException

   
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Agregue el código aquí para iniciar el servicio. Este método debería poner
        ' en movimiento los elementos para que el servicio pueda funcionar.
        Try
            Dim oHelper As Helper = New Helper

            If My.Settings.Archivo Then
                AlmacenarEnArchivo("*****************************************************************************************")
                AlmacenarEnArchivo("Iniciando Servicio")
                AlmacenarEnArchivo("*****************************************************************************************")
            End If

            Me.RecuperarSincronizacion(Fabrica.CDCS.CRM)

            EnviarVentas = True
            Me.Recibo_ = oHelper.RecuperarUltimoRecibo
            Temporizador.Enabled = False
            Temporizador = Nothing

            If Temporizador Is Nothing Then
                Temporizador = New Timers.Timer()
                IniciarTimer()
            End If

        Catch Ex As Exception
            LogFallas.ReportarError(Ex, "OnStart", "", "Comunicador")
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        ' Agregue el código aquí para realizar cualquier anulación necesaria para detener el servicio.
        Try
            If Not Temporizador Is Nothing Then
                Temporizador.Enabled = False
                Temporizador.Dispose()
                Temporizador = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub AlmacenarEnArchivo(ByVal Mensaje As String)
        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Depuracion") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Depuracion")
            End If

            Using sw As StreamWriter = File.AppendText(My.Application.Info.DirectoryPath & "\Depuracion\RastroDataTrack.txt")
                sw.WriteLine(Now.ToString() & "|" & Mensaje)
                sw.Close()
            End Using
        Catch ex As Exception
            LogFallas.ReportarError(ex, "AlmacenarEnArchivo", "", "Comunicador")
        End Try

    End Sub
    Private Sub RegistrarVentas(ByVal Recibo As Double)
        Dim ReciboActual As Double
        Dim oServicio As New ComunicacionDataTrack.VideoData
        Dim respuesta As String = Nothing
        Dim oHelper As Helper = New Helper
        Dim CadenaXml As String = "<?xml version=\'1.0\' encoding=\'utf-16\'?><DatosVenta xmlns:xsi=\'http://www.w3.org/2001/XMLSchema-instance\' xmlns:xsd=\'http://www.w3.org/2001/XMLSchema\'>\n<Venta Estacion=\'\' Consecutivo=\'\' Cantidad=\'\' Placa=\'\'/>\n</DatosVenta>"
        Dim sUser = oHelper.RecuperarParametro("UsuarioDataTrack")
        Dim sPass = oHelper.RecuperarParametro("PasswordDataTrack")
        Try
            ReciboActual = CDbl(txtVentas) + 1
            oServicio.Url = oHelper.RecuperarParametro("UrlDataTrack").ToString()


            While ReciboActual <= Recibo

                If My.Settings.Archivo Then
                    AlmacenarEnArchivo("Enviando venta: " & ReciboActual)
                End If
                respuesta = Nothing
                Dim oReader As IDataReader
                oReader = oHelper.RecuperarDatosDataTrack(ReciboActual)

                If oReader.Read() Then
                    If My.Settings.Archivo Then
                        AlmacenarEnArchivo("Enviando venta: " & ReciboActual)
                    End If
                    CadenaXml = "<?xml version=""1.0"" encoding=""utf-16""?><DatosVenta xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Venta Estacion=""" + oReader("CodEstacion").ToString() + """ Consecutivo=""" + ReciboActual.ToString() + """ Cantidad=""" + oReader("Cantidad").ToString().Replace(","c, "."c) + """ Placa=""" + oReader("Placa").ToString() + """ FHEvento=""" + oReader("FHEvento").ToString() + """/></DatosVenta>"
                    respuesta = oServicio.SetVehicleSellData(sUser, sPass, CadenaXml)


                    If My.Settings.Archivo Then
                        AlmacenarEnArchivo("XML ENVIADO: " & CadenaXml)
                        AlmacenarEnArchivo("Respuesta del servicio: " & respuesta)
                    End If

                End If
                oReader.Close()
                ErrorVentas = ""
                ValorVentas = ReciboActual.ToString()
                txtVentas = ReciboActual
                oHelper.ActualizarSincronizacion("Ventas", ReciboActual.ToString, 6)
                ReciboActual = ReciboActual + 1
            End While

        Catch Ex As Exception
            LogFallas.ReportarError(Ex, "RegistrarVentas", "", "Comunicador")
            If My.Settings.Archivo Then
                AlmacenarEnArchivo("Error: " & Ex.Message)
            End If
   
        End Try
    End Sub
    Private Sub RecuperarSincronizacion(ByVal cdc As CDC)
        Try
            Dim oDatos As New Helper
            Dim dtSincro As DataSet = Nothing
            dtSincro = oDatos.RecuperarSincronizacion(cdc)
            Dim Tabla As DataTable = dtSincro.Tables(0)
            Me.txtVentas = CDbl(Tabla.Rows(0)("Ventas").ToString).ToString("N0")

            'dtSincro.Dispose()
        Catch Ex As Exception
            LogFallas.ReportarError(Ex, "RecuperarSincronizacion", "", "Comunicador")
        End Try
    End Sub

    Private Sub IniciarTimer()
        Try

            Temporizador.Enabled = False
            Temporizador.Dispose()
            Temporizador = New Timers.Timer()
            AddHandler Temporizador.Elapsed, AddressOf Temporizador_Elapsed
            Temporizador.Interval = 5000
            Temporizador.Enabled = True
          
        Catch ex As Exception
            LogFallas.ReportarError(ex, "IniciarTimer", "", "Comunicador")
        End Try
    End Sub

    Private Sub Temporizador_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles Temporizador.Elapsed
        Dim oHelper As New Helper
        Try
            Temporizador.Enabled = False
            Me.Recibo_ = oHelper.RecuperarUltimoRecibo
            RegistrarVentas(Recibo_)

        Catch ex As Exception
            LogFallas.ReportarError(ex, "Temporizador_Elapsed", "", "Comunicador")
        Finally
            IniciarTimer()
        End Try
    End Sub
End Class
