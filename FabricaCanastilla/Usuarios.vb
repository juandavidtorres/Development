Imports POSstation.Fabrica
Imports POSstation.HelperCanastilla

Public Class Usuarios
    Shared oHelper As Helper = New Helper()

    Public Shared Function ValidarCredenciales(ByVal cedula As String, ByVal clave As String) As Int32
        If oHelper.ValidarCredenciales(cedula, clave) Then
            Try
                Return oHelper.RecuperarTurnoAbiertoPorEmpleado(cedula)
            Catch ex As System.Exception
                Throw New GasolutionsTurnoException(ex.Message)
            End Try
        Else
            Throw New GasolutionsLoginException("Credenciales No Validas")
        End If
    End Function
End Class
