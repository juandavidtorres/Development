Public Class Metodos

    Declare Sub Suic2Plain Lib "Suic2fish.dll" (ByRef crypto As Byte, ByVal longitud As Integer, ByRef plain As Byte)

    Public Sub Encriptar(ByVal entrada() As Byte, ByVal clave As String)
        Try
            Dim tmpValor1 As Integer, tmpValor2 As Integer, tmpValor3 As Integer
            Dim Inicio As Integer, L As Byte, Contador As Byte, J As Integer, I As Integer
            Dim Veces As Integer

            Veces = 2
            Inicio = 1
            For L = 1 To CByte(Veces)
                Contador = CByte(Contador + 1)
                J = Inicio
                For I = 1 To UBound(entrada)
                    If J > Len(RTrim(clave)) Then J = 1
                    tmpValor1 = Bshift(CByte(Asc(Mid(clave, J, 1))), J Mod 8) Or Bshift(CByte(Asc(Mid(clave, J, 1))), -(8 - (J Mod 8)))
                    tmpValor2 = Bshift(entrada(I), 4) Or Bshift(entrada(I), -4)
                    tmpValor3 = tmpValor1 Xor tmpValor2
                    entrada(I) = CByte(tmpValor3)

                    J = J + 1
                Next I
                If Inicio > Len(RTrim(clave)) Then Inicio = 1
            Next L
        Catch
            Throw
        End Try
    End Sub

    Public Function LimpiarCadena(ByVal cadena As String) As String
        Dim resultado As System.Text.StringBuilder = New System.Text.StringBuilder()
        Try
            For I As Integer = 0 To cadena.Length - 1
                If "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz;0123456789".IndexOf(cadena.Substring(I, 1)) >= 0 Then
                    resultado.Append(cadena.Substring(I, 1))
                Else
                    Exit For
                End If

            Next
        Catch ex As Exception
            Throw
        End Try
        Return resultado.ToString()
    End Function


    Public Function Desencriptar2Fish(ByRef origen() As Byte) As String
        Dim I As Integer

        Dim Resultado(256) As Byte
        Dim sClave As New System.Text.StringBuilder("")

        Suic2Plain(origen(1), 128, Resultado(1))

        For I = 1 To 255
            sClave.Append(Chr(Resultado(I)))
        Next I

        Return sClave.ToString()
    End Function
End Class
