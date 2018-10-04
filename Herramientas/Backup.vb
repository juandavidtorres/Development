Imports POSstation.AccesoDatos

Public Class Backup
    Dim OHelper As New Helper

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim Comando As String
        Try
            Comando = "BACKUP DATABASE [" & cmbDataBase.Text & "] TO  DISK = N'" & lblPath.Text & "' WITH NOFORMAT, INIT, NAME = N'" & cmbDataBase.Text & "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
            OHelper.GenerarBackup(Comando) 'cmbDataBase.Text, lblPath.Text)
            MsgBox("Proceso Generado Satisfactoriamente.", MsgBoxStyle.Information, "Generar Backup")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Generar Backup")
        End Try

    End Sub

    Private Sub Backup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            With Me
                .WindowState = FormWindowState.Normal
                .StartPosition = FormStartPosition.CenterScreen
            End With


            For Each oCol As String In My.Settings.DataBases
                cmbDataBase.Items.Add(oCol)
            Next

            cmbDataBase.SelectedIndex = 0

            lblPath.Text = Application.StartupPath & "\" & cmbDataBase.Text & ".bak"

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Iniciar Forma")
        End Try
    End Sub

    Private Sub lblPath_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPath.DoubleClick
        Try
            With SaveFileDialog1
                .Title = "Ruta de Backup"
                .Filter = "Backup (*.bak)|*.bak"
                .ShowDialog()
                If .FileName <> "" Then
                    lblPath.Text = .FileName
                Else
                    lblPath.Text = Application.StartupPath & "\" & cmbDataBase.Text & ".bak"
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Ruta")
        End Try
    End Sub

    Private Sub cmbDataBase_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDataBase.SelectedValueChanged
        lblPath.Text = Application.StartupPath & "\" & cmbDataBase.Text & ".bak"
    End Sub
End Class
