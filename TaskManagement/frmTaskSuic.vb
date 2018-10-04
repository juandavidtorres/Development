Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports POSstation.AccesoDatos


Public Class frmTaskSuic
    Dim oHelper As New Helper()
    Private Sub txtRutaPlanos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRutaPlanos.DoubleClick
        ExtraerRuta()
    End Sub

    Sub ExtraerRuta()
        With FolderBrowserDialog1
            .Reset()
            .ShowNewFolderButton = False
            .Description = "Ruta Archivos"
            .RootFolder = Environment.SpecialFolder.Desktop
            .ShowDialog()
            If .SelectedPath.Length > 1 Then
                txtRutaPlanos.Text = .SelectedPath
                oHelper.ActualizarParametro("RutaSuic", .SelectedPath)
            End If
        End With
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            If txtRutaPlanos.Text.Length > 0 Then
                ''Dim strArchivo As String = txtRutaPlanos.Text.Trim() & "\download.zip"
                ''Suic.Descomprimir(txtRutaPlanos.Text, strArchivo, True, True)
                tmrCargar.Stop()
                txtMensajes.AppendText(Suic.BulkSuic(txtRutaPlanos.Text))
                'Dim rutaArchivo As String = txtRutaPlanos.Text
                'Hilo.RunWorkerAsync(rutaArchivo)
                tmrCargar.Start()
            End If
        Catch ex As System.Exception
            txtMensajes.AppendText(ex.Message)
            tmrCargar.Start()
        End Try
    End Sub

    Private Sub tmrCargar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCargar.Tick
        Try
            ''Suic.Descomprimir(txtRutaPlanos.Text, "download", True, True)
            txtMensajes.AppendText(Suic.BulkSuic(txtRutaPlanos.Text))
            EstablecerHoraGeneracion()
        Catch ex As System.Exception
            txtMensajes.AppendText(ex.Message)
            'Finally
            'tmrCargar.Enabled = True
        End Try
    End Sub

    Private Sub frmTaskSuic_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            EstablecerHoraGeneracion()
            txtRutaPlanos.Text = My.Settings.RutaSuic
        Catch ex As System.Exception
        End Try
    End Sub

    Public Sub EstablecerHoraGeneracion()
        Dim FechaGeneracion As System.DateTime
        Try
            FechaGeneracion = Now
            FechaGeneracion = FechaGeneracion.AddMinutes(My.Settings.TimeLoad)
            txtMensajes.AppendText("Proxima Carga Programada " & FechaGeneracion.ToString())
            Me.tmrCargar.Enabled = False
            tmrCargar.Interval = FechaGeneracion.Subtract(Now).TotalMilliseconds
            Me.tmrCargar.Enabled = True
        Catch ex As System.Exception
            txtMensajes.AppendText(ex.Message)
        End Try
    End Sub

    Private Sub Hilo_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles Hilo.DoWork
        'Suic.BulkSuic(rutaArchivo)
    End Sub

    Private Sub Hilo_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles Hilo.ProgressChanged

    End Sub

    Private Sub Hilo_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Hilo.RunWorkerCompleted

    End Sub

    Private Sub txtRutaPlanos_TextChanged(sender As Object, e As EventArgs) Handles txtRutaPlanos.TextChanged

    End Sub
End Class
