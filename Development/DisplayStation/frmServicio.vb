Imports POSstation.AccesoDatos

Public Class frmServicio
    Dim EsCancelado As Boolean = False

    Private Sub frmServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Servicio As String
        Try
            Servicio = My.Settings.NombreServicio

            Try
                'Verifico que esté conectada la llave HASP
                ' POSstation.Fabrica.gasolutionsHasp.IsHasp()

                Me.Controlador.ServiceName = Servicio
                'Hago esta instruccin para saber si el nombre es correcot
                Dim a As Integer = Controlador.Status

                tmrRetardo.Enabled = True
            Catch Ex As POSstation.Fabrica.GasolutionsHaspException
                MessageBox.Show("LLAVE HASP NO ENCONTRADA" & vbNewLine & "Por favor conecte en el puerto USB la llave Gasolutions de verificación de licencia" & vbNewLine & "e intente abrir de nuevo el aplicativo", Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            Catch ex As Exception
                Throw New Exception("Problema asignando el servicio " & Servicio & ":" & ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub tmrRetardo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRetardo.Tick
        If IsRunning() Then
            tmrRetardo.Enabled = False
            EsCancelado = False
            Me.Hide()

            Dim F As New MainDisplay
            F.ShowDialog()

            Me.Close()
        ElseIf EsCancelado Then
            Me.btnReintentar.Enabled = True
            Me.btnCancelar.Enabled = False
        End If
    End Sub

    Private Function IsRunning() As Boolean
        Me.Controlador.Refresh()
        If Controlador.Status = ServiceProcess.ServiceControllerStatus.Running Then
            Return True
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        EsCancelado = True
    End Sub

    Private Sub btnReintentar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReintentar.Click
        Me.tmrRetardo.Enabled = False
        Me.btnCancelar.Enabled = True
    End Sub

   
End Class