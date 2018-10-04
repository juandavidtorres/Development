Public Class Validacion

    Private Sub gsInicioSesion_EventoAutenticacionApropada(UserId As System.Guid) Handles gsInicioSesion.EventoAutenticacionApropada
        MainTools.UserId = UserId
    End Sub

    Private Sub gsInicioSesion_EventoCerrarFormulario() Handles gsInicioSesion.EventoCerrarFormulario
        Me.Close()
    End Sub
End Class