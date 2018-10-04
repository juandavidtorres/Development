<System.ComponentModel.RunInstaller(True)> Partial Class InstaladorServicio
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ServicioConfiguracion = New System.ServiceProcess.ServiceInstaller()
        Me.ProcesoInstaladorServicio = New System.ServiceProcess.ServiceProcessInstaller()
        '
        'ServicioConfiguracion
        '
        Me.ServicioConfiguracion.Description = "V. 2015-10-02 - Sistema 24/7 de administracion de estaciones de servicio"
        Me.ServicioConfiguracion.DisplayName = "Sauce"
        Me.ServicioConfiguracion.ServiceName = "Sauce"
        Me.ServicioConfiguracion.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProcesoInstaladorServicio
        '
        Me.ProcesoInstaladorServicio.Password = Nothing
        Me.ProcesoInstaladorServicio.Username = Nothing
        '
        'InstaladorServicio
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.ServicioConfiguracion, Me.ProcesoInstaladorServicio})

    End Sub
    Friend WithEvents ServicioConfiguracion As System.ServiceProcess.ServiceInstaller
    Friend WithEvents ProcesoInstaladorServicio As System.ServiceProcess.ServiceProcessInstaller

End Class
