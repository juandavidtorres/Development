Imports POSstation.Notificacion
Imports System.IO

Public Class FrmMain
    Private Function NotificacionMensaje(mensaje As String, EsError As Boolean, delay As Integer) As String
        Try
            Dim frmMensaje As New Notification
            frmMensaje.Mensaje = mensaje
            frmMensaje.EsError = EsError
            frmMensaje.TimerTiempo = delay
            frmMensaje.Show()
        Catch ex As Exception

        End Try
        Return ""
    End Function
    Private Sub BtnAutorizador_Click(sender As Object, e As EventArgs) Handles BtnAutorizador.Click
        Try

            If File.Exists(My.Settings.SUIC) Then
                Process.Start(My.Settings.SUIC)

            ElseIf My.Settings.SUIC = "" Then
                Throw New Exception("La ruta de acceso a Sauce se encuentra vacia")

            ElseIf File.Exists(My.Settings.SUIC) = False Then
                Throw New Exception("Sauce no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, True, 3000)
        End Try
    End Sub

    Private Sub BtnConfigurador_Click(sender As Object, e As EventArgs) Handles BtnConfigurador.Click
        Try

            If File.Exists(My.Settings.Configurador) Then
                Process.Start(My.Settings.Configurador)

            ElseIf My.Settings.Configurador = "" Then
                Throw New Exception("La ruta de acceso al modulo de configuracion se encuentra vacia")

            ElseIf File.Exists(My.Settings.Configurador) = False Then
                Throw New Exception("El configurador no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, False, 3000)
        End Try
    End Sub

    Private Sub BtnDataAdmin_Click(sender As Object, e As EventArgs) Handles BtnDataAdmin.Click
        Try

            If File.Exists(My.Settings.Administracion) Then
                Process.Start(My.Settings.Administracion)

            ElseIf My.Settings.Administracion = "" Then
                Throw New Exception("La ruta de acceso al modulo de administracion se encuentra vacia")

            ElseIf File.Exists(My.Settings.Administracion) = False Then
                Throw New Exception("El modulo de configuracion no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, False, 3000)
        End Try
    End Sub

    Private Sub BtnSecurityStation_Click(sender As Object, e As EventArgs) Handles BtnSecurityStation.Click
        Try

            If File.Exists(My.Settings.Seguridad) Then
                Process.Start(My.Settings.Seguridad)

            ElseIf My.Settings.Seguridad = "" Then
                Throw New Exception("La ruta de acceso al modulo de seguridad se encuentra vacia")

            ElseIf File.Exists(My.Settings.Seguridad) = False Then
                Throw New Exception("El modulo de seguridad no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, True, 3000)
        End Try
    End Sub

    Private Sub BtnDisplayStation_Click(sender As Object, e As EventArgs) Handles BtnDisplayStation.Click
        Try

            If File.Exists(My.Settings.VistaEstacion) Then
                Process.Start(My.Settings.VistaEstacion)

            ElseIf My.Settings.VistaEstacion = "" Then
                Throw New Exception("La ruta de acceso al modulo de visualizacion se encuentra vacia")

            ElseIf File.Exists(My.Settings.VistaEstacion) = False Then
                Throw New Exception("El modulo de visualizacion no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, False, 3000)
        End Try
    End Sub
    Private Sub BtnConsultasLog_Click(sender As Object, e As EventArgs) Handles BtnConsultasLog.Click
        Try

            If File.Exists(My.Settings.ConsultasLog) Then
                Process.Start(My.Settings.ConsultasLog)

            ElseIf My.Settings.ConsultasLog = "" Then
                Throw New Exception("La ruta de acceso al modulo de visualizacion se encuentra vacia")

            ElseIf File.Exists(My.Settings.ConsultasLog) = False Then
                Throw New Exception("El modulo de visualizacion no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, True, 3000)
        End Try
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Try
                For Each p As Process In Process.GetProcesses

                    If p.ProcessName = "AccesoDirectoSauce" Then
                        p.Kill()
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim enEjecucion As Boolean

            enEjecucion = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1

            If (enEjecucion) Then
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            For Each p As Process In Process.GetProcesses

                If p.ProcessName = "AccesoDirectoSauce" Then
                    p.Kill()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtnCanastilla_Click(sender As Object, e As EventArgs) Handles btncanastilla.Click
        Try

            If File.Exists(My.Settings.Canastilla) Then
                Process.Start(My.Settings.Canastilla)

            ElseIf My.Settings.Canastilla = "" Then
                Throw New Exception("La ruta de acceso al modulo de productos de canastilla se encuentra vacia")

            ElseIf File.Exists(My.Settings.Canastilla) = False Then
                Throw New Exception("El modulo  de productos de canastilla no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, True, 3000)
        End Try
    End Sub

    Private Sub BtnHerramientas_Click(sender As Object, e As EventArgs) Handles BtnHerramientas.Click
        Try

            If File.Exists(My.Settings.Herramientas) Then
                Process.Start(My.Settings.Herramientas)

            ElseIf My.Settings.Herramientas = "" Then
                Throw New Exception("La ruta de acceso al modulo de Herramientas se encuentra vacia")

            ElseIf File.Exists(My.Settings.Canastilla) = False Then
                Throw New Exception("El modulo  de Herramientas no se encuentra en la ruta configurada")
            End If
        Catch ex As Exception
            NotificacionMensaje(ex.Message, True, 3000)
        End Try
    End Sub
End Class
