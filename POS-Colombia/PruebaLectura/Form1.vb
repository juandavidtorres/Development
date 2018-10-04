Imports POSstation.Fabrica
Imports POSstation.AccesoDatos
Imports POSstation
Imports System.Text
Public Class Form1
    Dim servidor As POSstation.TcpServer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OEventos_EnviarBytesLecturaChipPorDti(Lectura As System.Array, puerto As String, id As Integer)
        Try
            'Dim paginas(127) As Byte
            Dim paginas(146) As Byte
            Dim i As Integer
            Dim cabeceratrama(18) As Byte
            Dim trama As String
            Dim convercion As New System.Text.UTF8Encoding()
            Dim Temporal As String()
            Dim puertodti As String = ""
            Dim identificador As String
            Dim Cara As Byte = 0
            Dim oHelper As New Helper
            Dim CadenaAuxiliar As String = ""
            Dim j As Integer = 0


            If Lectura.Length >= 147 Then ''Datos de la lectura del chip

                For i = 0 To 18
                    cabeceratrama(i) = Lectura(i)
                Next


                'For i = 19 To Lectura.Length - 1
                '    paginas(j) = Lectura(i)
                '    j = j + 1
                'Next

                For i = 0 To Lectura.Length - 1
                    paginas(j) = Lectura(i)
                    j = j + 1
                Next

                'Saco la cabecera de la trama que corresponde al puerto de la dti y el rom
                trama = convercion.GetString(cabeceratrama)

                If Not String.IsNullOrEmpty(trama) Then
                    Temporal = trama.Split(".")
                    puertodti = Temporal(0)
                    identificador = Temporal(1)
                End If

                If paginas.Length >= 128 Then
                    Try


                        Dim Bytes As New BytesLectura
                        Bytes.ArregloBytes = paginas

                        DesencriptarBytesDti(True, 1, paginas)

                    Catch ex As System.Exception


                    End Try
                End If
            Else ''Cuando se desconecta el chip


                'Aqui saco la informacion del Puerto y el donde se deconecto el chip
                For i = 0 To 4
                    cabeceratrama(i) = Lectura(i)
                Next

                Dim datos As New System.Text.UTF8Encoding()
                'convierto a string los primeros 19 byets para sacar el rom y el puerto
                CadenaAuxiliar = datos.GetString(cabeceratrama)




                If Not String.IsNullOrEmpty(CadenaAuxiliar) Then
                    Dim cadenaTemporal As String()

                    'Hago un split para separa la trama, por ejemplo me llega I2.NC, hago el slit para sacar el puerto y la trama
                    cadenaTemporal = CadenaAuxiliar.Split(".")

                    'Almaceno el puerto

                    puertodti = cadenaTemporal(0)
                    'Aqui le informo al autorizador que se desconecto el chip de la DTI



                Else
                    Throw New System.Exception("Falla en extraer Puerto en la trama de desconexion de chip LSIB4")
                End If


            End If

        Catch ex As System.Exception

        End Try
    End Sub

    Public Function DesencriptarBytesDti(ByVal EsLecturaChipObligatoria As Boolean, ByVal cara As Byte, ByVal Paginas() As Byte) As InformacionVehiculo
        Dim oInformacion As New InformacionVehiculo
        Try
            Try



                Dim convercion As New System.Text.UTF8Encoding()
                Dim strSalida As String
                Dim identificador As String = ""
                Dim PuertoDti As String

                If Paginas.Length > 0 Then
                    Try



                        Dim oEncripcion As New EncriptacionDti.EncriptacionDti


                        If EsLecturaChipObligatoria Then
                            Dim ContenidoChip(127) As Byte
                            Dim j, i As Integer
                            j = 0
                            For i = 19 To Paginas.Length - 1
                                ContenidoChip(j) = Paginas(i)
                                j = j + 1
                            Next

                            Dim Temporal = New Byte(18) {}
                            Dim datos As New System.Text.UTF8Encoding()

                            i = 0
                            For i = 0 To 18
                                Temporal(i) = Paginas(i)
                            Next

                            'convierto a string los primeros 19 byets para sacar el rom y el puerto
                            strSalida = datos.GetString(Temporal)
                            If Not String.IsNullOrEmpty(strSalida) Then
                                Dim Tmp As String() = strSalida.Split(".")
                                PuertoDti = Tmp(0)
                                identificador = Tmp(1)
                            End If




                            oInformacion = oEncripcion.ExtraerInformacionPaginas(ContenidoChip, identificador, EsLecturaChipObligatoria)
                        Else
                            Dim Temporal = New Byte(18) {}
                            Dim datos As New System.Text.UTF8Encoding()

                            For i As Integer = 0 To 18
                                Temporal(i) = Paginas(i)
                            Next

                            'convierto a string los primeros 19 byets para sacar el rom y el puerto
                            strSalida = datos.GetString(Temporal)
                            If Not String.IsNullOrEmpty(strSalida) Then
                                Dim Tmp As String() = strSalida.Split(".")
                                PuertoDti = Tmp(0)
                                identificador = Tmp(1)
                            End If
                            oInformacion = oEncripcion.ExtraerInformacionPaginas(Paginas, identificador, EsLecturaChipObligatoria)
                        End If

                    Catch ex As System.Exception

                        Throw ex
                    End Try

                End If

            Catch ex As System.Exception
                Throw ex
            End Try
        Catch ex As System.Exception
            Throw
        End Try
        Return oInformacion
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            servidor = New TcpServer(InputBox("Puerto"), 1)
            servidor.IniciarServidor()
            AddHandler servidor.EventoEnviarBytesLecturaChipPorLSIB4, AddressOf OEventos_EnviarBytesLecturaChipPorDti
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim utilidad As New POSstation.Utilidades.Utilidades
            For Each var In utilidad.DatosLectura(Encoding.ASCII.GetBytes(InputBox("Lectura")))
                utilidad.ProcesarLectura(var.Lectura)
            Next
            OEventos_EnviarBytesLecturaChipPorDti(utilidad.oPaginasfinal, "", 0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
