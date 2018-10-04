Imports POSstation.Fabrica

#Region "Impresion"
Public Class FormatoImpresora
    Public Shared Sub AsciiToPrinter(ByVal Archivo As String, ByVal Impresora As String)

        Try
            If Not My.Computer.FileSystem.FileExists(Archivo) Then
                Throw New System.Exception("No existe el archivo:" & Archivo)
                Exit Sub
            End If
            Dim streamToPrint As IO.StreamReader = New IO.StreamReader(Archivo)
            Dim pd As TextPrintDocument = New TextPrintDocument(streamToPrint)
            Try
                Try
                    pd.PrinterSettings.PrinterName = Impresora
                Catch
                End Try

                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch
            Throw
        End Try
    End Sub

    Public Shared Function SeccionarParrafo(ByVal texto As String) As List(Of String)
        Dim Lineas As List(Of String) = New List(Of String)
        Dim linea As String = texto
        Dim Posicion As Integer = 40

        While Not String.IsNullOrEmpty(texto)
            texto = texto.Trim()
            If Posicion + 1 < texto.Length Then
                linea = texto.Substring(0, Posicion)
                If Not texto.Chars(Posicion + 1).Equals(" ") Then
                    Lineas.Add(texto.Substring(0, linea.LastIndexOf(" ")))
                    texto = texto.Substring(linea.LastIndexOf(" "))

                Else
                    Lineas.Add(linea)
                    If Posicion + 1 > texto.Length Then
                        texto = ""
                    Else
                        texto = texto.Substring(Posicion + 1)
                    End If
                End If
            Else
                Lineas.Add(texto)
                texto = ""
            End If
        End While
        Return Lineas
    End Function

    Public Shared Function CentrarTexto(ByVal ancho As Int32, ByVal texto As String) As String
        If texto.Length > ancho Then
            texto = texto.Substring(0, ancho)
        End If
        Return Space((ancho - texto.Length) \ 2) & texto
    End Function

    Public Shared Function DobleColumnaTotal(ByVal texto1 As String, ByVal texto2 As String) As String
        If texto2.Length + texto1.Length > 40 Then
            texto2 = texto2.Substring(0, 40 - texto1.Length - 1)
        End If
        Return texto1 & Space(40 - texto1.Length - texto2.Length) & texto2
    End Function

    Public Shared Function DobleColumnaNumerica(ByVal texto1 As String, ByVal texto2 As String) As String
        If texto1.Length > 20 Then
            texto1 = texto1.Substring(0, 20)
        End If

        If texto2.Length > 19 Then
            texto2 = texto2.Substring(0, 19)
        End If
        Return texto1 & Space((20 - texto1.Length)) & Space((19 - texto2.Length)) & texto2
    End Function

    Public Shared Function DobleColumna(ByVal inicio As Int32, ByVal texto1 As String, ByVal texto2 As String) As String
        If texto1.Length > inicio Then
            texto1 = texto1.Substring(0, inicio)
        End If

        Return texto1 & Space((inicio - texto1.Length)) & texto2
    End Function

    Public Shared Function TripleColumnaLecturas(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String) As String

        If texto1.Length > 14 Then
            texto1 = texto1.Substring(0, 14)
        End If

        If texto2.Length > 11 Then
            texto2 = texto2.Substring(0, 11)
        End If

        If texto3.Length > 15 Then
            texto3 = texto3.Substring(0, 15)
        End If

        Return texto1 & Space(14 - texto1.Length) & Space(11 - texto2.Length) & texto2 & Space(15 - texto3.Length) & texto3
    End Function

    Public Shared Function TripleColumnaLecturasCanastilla(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String) As String

        If texto1.Length > 19 Then
            texto1 = texto1.Substring(0, 19)
        End If

        If texto2.Length > 6 Then
            texto2 = texto2.Substring(0, 6)
        End If

        If texto3.Length > 14 Then
            texto3 = texto3.Substring(0, 14)
        End If

        Return texto1 & Space(19 - texto1.Length) & Space(6 - texto2.Length) & texto2 & Space(14 - texto3.Length) & texto3
    End Function

    Public Shared Function TripleColumnaFallasTecnicas(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String) As String

        If texto1.Length > 16 Then
            texto1 = texto1.Substring(0, 16)
        End If

        If texto2.Length > 12 Then
            texto2 = texto2.Substring(0, 12)
        End If

        If texto3.Length > 12 Then
            texto3 = texto3.Substring(0, 12)
        End If

        Return texto1 & Space(16 - texto1.Length) & Space(12 - texto2.Length) & texto2 & Space(12 - texto3.Length) & texto3
    End Function

    Public Shared Function PentaColumna(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String, ByVal texto5 As String) As String
        'La ultima columna se imprime alineada a la derecha
        If texto1.Length > 9 Then
            texto1 = texto1.Substring(0, 9)
        End If

        If texto2.Length > 8 Then
            texto2 = texto2.Substring(0, 8)
        End If

        If texto3.Length > 6 Then
            texto3 = texto3.Substring(0, 6)
        End If

        If texto4.Length > 6 Then
            texto4 = texto4.Substring(0, 6)
        End If

        If texto5.Length > 10 Then
            texto5 = texto5.Substring(0, 10)
        End If

        Return texto1 & Space((9 - texto1.Length)) & texto2.Trim & Space((8 - texto2.Trim.Length)) & texto3 & Space((6 - texto3.Length)) & Space((6 - texto4.Length)) & texto4 & Space((10 - texto5.Length)) & texto5
    End Function

    Public Shared Function CuartaColumna(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String) As String
        'La ultima columna se imprime alineada a la derecha
        If texto1.Length > 12 Then
            texto1 = texto1.Substring(0, 12)
        End If

        If texto2.Length > 8 Then
            texto2 = texto2.Substring(0, 8)
        End If

        If texto3.Length > 10 Then
            texto3 = texto3.Substring(0, 9)
        End If

        If texto4.Length > 10 Then
            texto4 = texto4.Substring(0, 9)
        End If



        Return texto1 & Space((12 - texto1.Length)) & texto2.Trim & Space(((texto2.Trim.Length + 2) - texto2.Trim.Length)) & texto3 & Space((10 - texto3.Length)) & Space((10 - texto4.Length)) & texto4
    End Function



    Public Shared Function PentaColumnaCanastilla(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String, ByVal texto5 As String) As String
        'La ultima columna se imprime alineada a la derecha
        If texto1.Length > 5 Then
            texto1 = texto1.Substring(0, 5)
        End If

        If texto2.Length > 7 Then
            texto2 = texto2.Substring(0, 7)
        End If

        If texto3.Length > 9 Then
            texto3 = texto3.Substring(0, 9)
        End If

        If texto4.Length > 9 Then
            texto4 = texto4.Substring(0, 9)
        End If

        If texto5.Length > 10 Then
            texto5 = texto5.Substring(0, 10)
        End If

        Return texto1 & Space((5 - texto1.Length)) & texto2.Trim & Space((7 - texto2.Trim.Length)) & texto3 & Space((9 - texto3.Length)) & Space((9 - texto4.Length)) & texto4 & Space((10 - texto5.Length)) & texto5
    End Function

    Public Shared Function SextaColumnaDetalleFactura(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String, ByVal texto5 As String, ByVal texto6 As String) As String
        'La ultima columna se imprime alineada a la derecha
        If texto1.Length > 5 Then
            texto1 = texto1.Substring(0, 5)
        End If

        If texto2.Length > 3 Then
            texto2 = texto2.Substring(0, 3)
        End If

        If texto3.Length > 9 Then
            texto3 = texto3.Substring(0, 9)
        End If

        If texto4.Length > 6 Then
            texto4 = texto4.Substring(0, 6)
        End If

        If texto5.Length > 8 Then
            texto5 = texto5.Substring(0, 8)
        End If

        If texto6.Length > 9 Then
            texto6 = texto6.Substring(0, 9)
        End If

        Return texto1 & Space((5 - texto1.Length)) & texto2 & Space((3 - texto2.Length)) & texto3.Trim & Space((9 - texto3.Trim.Length)) & texto4 & Space((6 - texto4.Length)) & Space((8 - texto5.Length)) & texto5 & Space((9 - texto6.Length)) & texto6
    End Function

    Public Shared Function SextaColumnaCierreTurno(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String, ByVal texto5 As String, ByVal texto6 As String) As String
        'La ultima columna se imprime alineada a la derecha
        If texto1.Length > 8 Then
            texto1 = texto1.Substring(0, 8)
        End If

        If texto2.Length > 8 Then
            texto2 = texto2.Substring(0, 8)
        End If

        If texto3.Length > 6 Then
            texto3 = texto3.Substring(0, 6)
        End If

        If texto4.Length > 3 Then
            texto4 = texto4.Substring(0, 3)
        End If

        If texto5.Length > 6 Then
            texto5 = texto5.Substring(0, 6)
        End If

        If texto6.Length > 9 Then
            texto6 = texto6.Substring(0, 9)
        End If

        Return texto1 & Space((8 - texto1.Length)) & texto2 & Space((8 - texto2.Length)) & texto3.Trim & Space((6 - texto3.Trim.Length)) & texto4 & Space((3 - texto4.Length)) & Space((6 - texto5.Length)) & texto5 & Space((9 - texto6.Length)) & texto6
    End Function

    Public Shared Function PentaColumnaTotalIva(ByVal texto1 As String, ByVal texto2 As String, ByVal texto3 As String, ByVal texto4 As String) As String
        'La ultima columna se imprime alineada a la derecha
        If texto1.Length > 12 Then
            texto1 = texto1.Substring(0, 12)
        End If

        If texto2.Length > 9 Then
            texto2 = texto2.Substring(0, 9)
        End If

        If texto3.Length > 9 Then
            texto3 = texto3.Substring(0, 9)
        End If

        If texto4.Length > 10 Then
            texto4 = texto4.Substring(0, 10)
        End If

        Return texto1 & Space(12 - texto1.Length) & texto2 & Space((9 - texto2.Length)) & Space((9 - texto3.Length)) & texto3 & Space((10 - texto4.Length)) & texto4
    End Function

    Public Shared Function SeccionarParrafoFidelizacion(ByVal texto As String) As List(Of String)
        Dim Lineas As List(Of String) = New List(Of String)
        Dim linea As String = texto
        Dim Posicion As Integer = 40
        Dim PorcionTexto As String


        PorcionTexto = texto
        While PorcionTexto.Length > 39
            Lineas.Add(PorcionTexto.Substring(0, 40))
            PorcionTexto = PorcionTexto.Substring(40)
        End While
        Lineas.Add(PorcionTexto)

        Return Lineas
    End Function
End Class
#End Region