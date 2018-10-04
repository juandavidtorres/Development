Public Class Validacion
    Public Sub New()

    End Sub

    Public Shared Sub ValidarNumeroEntero(ByVal num As String, ByVal texto As String)
        Dim temp As Int32 = 0

        If Int32.TryParse(num, temp) = False Then
            Throw New Exception(texto & " debe ser un n�mero")
        Else
            If (temp < 0) Then
                Throw New Exception(texto & " debe ser un n�mero no negativo")
            End If
        End If
    End Sub

    Public Shared Sub ValidarNumeroDecimal(ByVal num As String, ByVal texto As String)
        Dim temp As Decimal = 0

        If Decimal.TryParse(num, temp) = False Then
            Throw New Exception(texto & " debe ser un n�mero")
        Else
            If (temp < 0) Then
                Throw New Exception(texto & " debe ser un n�mero no negativo")
            End If
        End If
    End Sub
End Class
