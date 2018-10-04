Imports POSstation.Controles.gsLoggin
Imports POSstation.AccesoDatos
Imports System.Configuration

Public Class GetLog
    Private oHelper As New Helper

    Private Sub GetLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                .pnlFecha.Visible = False
                .WindowState = FormWindowState.Normal
                .StartPosition = FormStartPosition.CenterScreen
            End With

            With GsLoggin1
                .Informacion = oHelper.RecuperarLog(Date.Now, Date.Now, "LogDataBase", "", "")
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "GetLog-IniciarForma")
        End Try
    End Sub

    Private Sub GsLoggin1_oRefresh(ByVal sender As Object, ByVal e As System.EventArgs) Handles GsLoggin1.oRefresh
        btnAceptar_Click(sender, e)
    End Sub

    Private Sub GsLoggin1_oSolicitaFechaFiltro(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GsLoggin1.oSolicitaFechaFiltro
        GsLoggin1.Dock = DockStyle.None
        pnlFecha.Visible = True
        dtpFInicial.Value = Date.Now : dtpFFinal.Value = Date.Now
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            With GsLoggin1
                .Informacion = oHelper.RecuperarLog(dtpFInicial.Value, dtpFFinal.Value, "LogDataBase", "", "")
            End With
            pnlFecha.Visible = False
            GsLoggin1.Dock = DockStyle.Fill
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DefinirBusqueda")
        End Try
    End Sub

    Private Sub GsLoggin1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GsLoggin1.Paint

    End Sub
End Class