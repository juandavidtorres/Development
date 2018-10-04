Imports POSstation.AccesoDatos
Imports POSstation.Fabrica

Public Class MainTools
    Public Shared _UserId As Nullable(Of Guid)

    Public Shared Property UserId() As Nullable(Of Guid)
        Get
            Return _UserId
        End Get
        Set(value As Nullable(Of Guid))
            _UserId = value
        End Set
    End Property

    Private Sub MainTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
                Me.Close()
            End If

            AplicarPermisosPorAcciones()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AplicarPermisosPorAcciones()
        Try
            Dim oHelper As New Helper()

            If (_UserId.HasValue) Then
                If (Not oHelper.ValidarPermisosPorAccion(_UserId.Value, CType(AccionesToolStation.RealizarBackupsBD, Int32))) Then
                    tsbBackup.Enabled = False
                End If

                If (Not oHelper.ValidarPermisosPorAccion(_UserId.Value, CType(AccionesToolStation.RevisionLogs, Int32))) Then
                    tsbLoggin.Enabled = False
                End If
            Else
                MessageBox.Show("El usuario actual no se ha podido autenticar en el sistema")
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub tsbBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbBackup.Click
        Try
            Dim oBackup As New Backup

            Me.WindowState = FormWindowState.Minimized

            With oBackup
                .ShowDialog()
                .Dispose()
            End With
            Me.WindowState = FormWindowState.Normal
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Generar Backup")
        End Try
    End Sub

    Private Sub tsbLoggin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbLoggin.Click
        Try
            Dim oLogging As New GetLog

            Me.WindowState = FormWindowState.Minimized

            With oLogging
                .ShowDialog()
                .Dispose()
            End With

            Me.WindowState = FormWindowState.Normal

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Log de Aplicación")
        End Try
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class