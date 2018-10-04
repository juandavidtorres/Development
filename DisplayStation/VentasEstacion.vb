Imports PosStation.AccesoDatos
Public Class VentasEstacion

    Public Event Cerrar As EventHandler

    Private Sub btnConsultarTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultarTrans.Click
        Try
            Dim oHelper As New Helper()
            dgvVenta.DataSource = oHelper.RecuperarTransaccionesdeVentaPorFecha(dtpInicio.Value.ToString("yyyyMMdd HH:mm"), dtpFinal.Value.ToString("yyyyMMdd HH:mm"))
        Catch ex as System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Consultando")
        End Try
    End Sub

    Public Sub IniciaControl()
        Try
            Dim oHelper As New Helper()
            dtpInicio.Value = DateTime.Now
            dtpFinal.Value = DateTime.Now
            dgvVenta.DataSource = oHelper.RecuperarTransaccionesdeVentaPorFecha(dtpInicio.Value.ToString("yyyyMMdd HH:mm"), dtpFinal.Value.ToString("yyyyMMdd HH:mm"))
        Catch ex as System.Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Iniciando")
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrar(sender, e)
    End Sub
End Class
