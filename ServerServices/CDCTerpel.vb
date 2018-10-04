Imports POSstation.AccesoDatos
Imports POSstation.Fabrica
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net

Public Class CDCTerpelComunicacion
    Public Shared LogFallas As New EstacionException
    Public Shared ListaPrepagosCanastilla As New Collection
    Public Shared LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog


    Public Shared Function AutorizarVentaTerpelCDC(ByVal PCC As String, ByVal IdProducto As String,
                                                ByVal Precio As Decimal, ByVal kilometraje As String, ByVal Rom As String) As Fabrica.RespuestaAutorizacionVentaTerpel
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New CDCTerpel.Integrator
        Dim Respuesta As New Fabrica.RespuestaAutorizacionVentaTerpel
        Dim IdProductoSatelite As String = ""

        Try
            IdProductoSatelite = OData.RecuperarCodigoProductoSatelite(IdProducto)

            LogCategorias.Clear()
            LogCategorias.Agregar("AutorizarVentaTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("PCC", PCC)
            LogPropiedades.Agregar("IdProducto", IdProducto)
            LogPropiedades.Agregar("IdProductoSatelite", IdProductoSatelite)
            LogPropiedades.Agregar("Precio", Precio)
            LogPropiedades.Agregar("kilometraje", kilometraje)
            LogPropiedades.Agregar("Rom", Rom)
            POSstation.Fabrica.LogIt.Loguear("Inicio AutorizarVentaTerpelCDC: ", LogPropiedades, LogCategorias)



            Dim strJson As String = String.Format("{{{0}PCC{0}:{0}{1}{0},{0}IP{0}:{2},{0}PDV{0}:{3},{0}KV{0}:{4},{0}IB{0}:{0}{5}{0}}}",
                                                  """", PCC, IdProductoSatelite, CInt(Precio), kilometraje, Rom)

            LogCategorias.Clear()
            LogCategorias.Agregar("AutorizarVentaTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("strJson", strJson)
            LogPropiedades.Agregar("CadenaEncriptada", EncriptarCadenaComunicacionTerpel(strJson))
            POSstation.Fabrica.LogIt.Loguear("Despues de armar cadena JSON: ", LogPropiedades, LogCategorias)


            Dim credenciales As ICredentials = New NetworkCredential(OData.RecuperarParametro("UsuarioTerpel"), OData.RecuperarParametro("ClaveTerpel"))

            Comunicador.Url = OData.RecuperarParametro("ServicioTerpel")
            Comunicador.Credentials = credenciales

            Dim RespuestaCDC As CDCTerpel.AutorizacionSuministroSLResult = Comunicador.AutorizacionSuministroSL(EncriptarCadenaComunicacionTerpel(strJson))

            If Not RespuestaCDC Is Nothing Then
                If RespuestaCDC.M = "OK" Then
                    LogCategorias.Clear()
                    LogCategorias.Agregar("AutorizarVentaTerpelCDC")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString())
                    LogPropiedades.Agregar("IA(IdAprobacion)", RespuestaCDC.IA)
                    LogPropiedades.Agregar("IFP(IdFormaPago)", RespuestaCDC.IFP)
                    LogPropiedades.Agregar("CMV(CupoMaximoVolumen)", RespuestaCDC.CMV)
                    LogPropiedades.Agregar("CMD(CupoMaximoDinero)", RespuestaCDC.CMD)
                    LogPropiedades.Agregar("SD(SaldoCliente)", RespuestaCDC.SD)
                    LogPropiedades.Agregar("NC(NombreCliente)", RespuestaCDC.NC)
                    LogPropiedades.Agregar("NI(NitCliente)", RespuestaCDC.NI)
                    LogPropiedades.Agregar("P(PlacaVehiculo)", RespuestaCDC.P)
                    LogPropiedades.Agregar("VII(ValorIvaImplicito)", RespuestaCDC.VII)
                    POSstation.Fabrica.LogIt.Loguear("Reespuesta del CDC: ", LogPropiedades, LogCategorias)

                    OData.InsertarAutorizaGerenciamiento(RespuestaCDC.IA, 1)

                    Respuesta.Procesado = True
                    Respuesta.IdAprobacion = RespuestaCDC.IA
                    Respuesta.IdFormaPago = RespuestaCDC.IFP
                    Respuesta.CupoMaximoVolumen = RespuestaCDC.CMV
                    Respuesta.CupoMaximoDinero = RespuestaCDC.CMD
                    Respuesta.SaldoCliente = RespuestaCDC.SD
                    Respuesta.NombreCliente = RespuestaCDC.NC
                    Respuesta.NitCliente = RespuestaCDC.NI
                    Respuesta.PlacaVehiculo = RespuestaCDC.P
                    Respuesta.ValorIvaImplicito = RespuestaCDC.VII
                Else
                    LogCategorias.Clear()
                    LogCategorias.Agregar("AutorizarVentaTerpelCDC")
                    LogPropiedades.Clear()
                    LogPropiedades.Agregar("Fecha", Now.ToString())
                    LogPropiedades.Agregar("Mensaje", RespuestaCDC.M)
                    POSstation.Fabrica.LogIt.Loguear("Error en el CDC: ", LogPropiedades, LogCategorias)

                    Respuesta.Procesado = False
                    Respuesta.MensajeError = RespuestaCDC.M
                End If

            Else
                LogCategorias.Clear()
                LogCategorias.Agregar("AutorizarVentaTerpelCDC")
                LogPropiedades.Clear()
                LogPropiedades.Agregar("Fecha", Now.ToString())
                POSstation.Fabrica.LogIt.Loguear("No se obtuvo respuesta del CDC: ", LogPropiedades, LogCategorias)
                Respuesta.Procesado = False
                Respuesta.MensajeError = "No se obtuvo respuesta del CDC"
            End If
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AutorizarVentaTerpelCDC", "PCC: " & PCC & ", IdProducto: " & IdProducto & ", Precio: " & Precio & ", kilometraje: " & kilometraje, "AutorizadorRemoto")
            Respuesta.Procesado = False
            Respuesta.MensajeError = ex.Message
        End Try
        Return Respuesta

    End Function


    Public Shared Sub EnviarVentaTerpelCDC(ByVal Venta As String)
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New CDCTerpel.Integrator

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("EnviarVentaTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Venta", Venta)
            POSstation.Fabrica.LogIt.Loguear("Inicio EnviarVentaTerpelCDC: ", LogPropiedades, LogCategorias)



            Dim credenciales As ICredentials = New NetworkCredential(OData.RecuperarParametro("UsuarioTerpel"), OData.RecuperarParametro("ClaveTerpel"))

            Comunicador.Url = OData.RecuperarParametro("ServicioTerpel")
            Comunicador.Credentials = credenciales

            Dim RespuestaCDC As String = Comunicador.RegistrarVentaGasSL(EncriptarCadenaComunicacionTerpel(Venta))


            LogCategorias.Clear()
            LogCategorias.Agregar("EnviarVentaTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("RespuestaCDC", RespuestaCDC)
            POSstation.Fabrica.LogIt.Loguear("Respuesta del CDC: ", LogPropiedades, LogCategorias)

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "EnviarVentaTerpelCDC", "Venta: " & Venta, "AutorizadorRemoto")
            Throw
        End Try
    End Sub


    Public Shared Sub AnularGerenciamientoTerpelCDC(ByVal Gerenciamiento As String)
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New CDCTerpel.Integrator

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("AnularGerenciamientoTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Gerenciamiento", Gerenciamiento)
            POSstation.Fabrica.LogIt.Loguear("Inicio AnularGerenciamientoTerpelCDC: ", LogPropiedades, LogCategorias)



            Dim credenciales As ICredentials = New NetworkCredential(OData.RecuperarParametro("UsuarioTerpel"), OData.RecuperarParametro("ClaveTerpel"))

            Comunicador.Url = OData.RecuperarParametro("ServicioTerpel")
            Comunicador.Credentials = credenciales

            Dim RespuestaCDC As String = Comunicador.LiberarAutorizacionesSL(EncriptarCadenaComunicacionTerpel(Gerenciamiento))






            LogCategorias.Clear()
            LogCategorias.Agregar("AnularGerenciamientoTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("RespuestaCDC", RespuestaCDC)
            POSstation.Fabrica.LogIt.Loguear("Respuesta del CDC: ", LogPropiedades, LogCategorias)

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "AnularGerenciamientoTerpelCDC", "Gerenciamiento: " & Gerenciamiento, "AutorizadorRemoto")
            Throw
        End Try
    End Sub


    Public Shared Function EnviarTurnoTerpelCDC(ByVal Turno As String) As String
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New CDCTerpel.Integrator

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("EnviarTurnoTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("Turno", Turno)
            POSstation.Fabrica.LogIt.Loguear("Inicio EnviarTurnoTerpelCDC: ", LogPropiedades, LogCategorias)



            Dim credenciales As ICredentials = New NetworkCredential(OData.RecuperarParametro("UsuarioTerpel"), OData.RecuperarParametro("ClaveTerpel"))

            Comunicador.Url = OData.RecuperarParametro("ServicioTerpel")
            Comunicador.Credentials = credenciales

            Dim RespuestaCDC As String = DesencriptarCadenaComunicacionTerpel(Comunicador.CerrarDiaSL(EncriptarCadenaComunicacionTerpel(Turno)))

            LogCategorias.Clear()
            LogCategorias.Agregar("EnviarTurnoTerpelCDC")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            LogPropiedades.Agregar("RespuestaCDC", RespuestaCDC)
            POSstation.Fabrica.LogIt.Loguear("Respuesta del CDC: ", LogPropiedades, LogCategorias)

            Return RespuestaCDC
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "EnviarTurnoTerpelCDC", "Turno: " & Turno, "AutorizadorRemoto")
            Throw
        End Try
    End Function


    Public Shared Function ObtenerFaltantes() As RespuestaFaltantesTerpel
        Dim OData As New POSstation.AccesoDatos.Helper
        Dim Comunicador As New CDCTerpel.Integrator

        Dim Respuesta As New RespuestaFaltantesTerpel

        Try
            LogCategorias.Clear()
            LogCategorias.Agregar("ObtenerFaltantes")
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Fecha", Now.ToString())
            POSstation.Fabrica.LogIt.Loguear("Inicio ObtenerFaltantes: ", LogPropiedades, LogCategorias)

            'OData.RecuperarEstacionConfigurador()

            Dim credenciales As ICredentials = New NetworkCredential(OData.RecuperarParametro("UsuarioTerpel"), OData.RecuperarParametro("ClaveTerpel"))

            Comunicador.Url = OData.RecuperarParametro("ServicioTerpel")
            Comunicador.Credentials = credenciales

            Dim RespuestaCDC As CDCTerpel.ListaConsecutivosFaltantes = Comunicador.ConsultaFaltantesSL(OData.RecuperarEstaciones().Tables(0).Rows(0).Item("Codigo").ToString)


            If Not RespuestaCDC Is Nothing Then
                If Not RespuestaCDC.consecutivos Is Nothing Then
                    If RespuestaCDC.consecutivos.Length > 0 Then
                        If Not RespuestaCDC.consecutivos(0).IA Is Nothing Then

                            LogCategorias.Clear()
                            LogCategorias.Agregar("ObtenerFaltantes")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Fecha", Now.ToString())
                            POSstation.Fabrica.LogIt.Loguear("Agregando aprobaciones a la lista: ", LogPropiedades, LogCategorias)

                            Respuesta.AprobacionesFaltantes.AddRange(RespuestaCDC.consecutivos(0).IA)

                            LogCategorias.Clear()
                            LogCategorias.Agregar("ObtenerFaltantes")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Fecha", Now.ToString())
                            POSstation.Fabrica.LogIt.Loguear("Despues de agregar aprobaciones a la lista: ", LogPropiedades, LogCategorias)
                        End If
                        If Not RespuestaCDC.consecutivos(0).IT Is Nothing Then

                            LogCategorias.Clear()
                            LogCategorias.Agregar("ObtenerFaltantes")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Fecha", Now.ToString())
                            POSstation.Fabrica.LogIt.Loguear("Agregando turnos a la lista: ", LogPropiedades, LogCategorias)

                            Respuesta.TurnosFaltantes.AddRange(RespuestaCDC.consecutivos(0).IT)

                            LogCategorias.Clear()
                            LogCategorias.Agregar("ObtenerFaltantes")
                            LogPropiedades.Clear()
                            LogPropiedades.Agregar("Fecha", Now.ToString())
                            POSstation.Fabrica.LogIt.Loguear("Despues de agregar turnos a la lista: ", LogPropiedades, LogCategorias)
                        End If
                    End If
                End If
            End If

            Return Respuesta
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ObtenerFaltantes", "", "AutorizadorRemoto")
            Throw
        End Try
    End Function

    Private Shared Function EncriptarCadenaComunicacionTerpel(Datos As String) As String
        Dim OData As New POSstation.AccesoDatos.Helper
        Try
            Dim key() As Byte = Encoding.ASCII.GetBytes(OData.RecuperarParametro("LLaveTerpel"))
            Dim iv() As Byte = Encoding.ASCII.GetBytes(OData.RecuperarParametro("VectorTerpel"))
            Dim data() As Byte = Encoding.ASCII.GetBytes(Datos)
            Dim enc() As Byte
            Dim hex As String = ""
            Dim trip As TripleDES = TripleDES.Create()


            trip.IV = iv
            trip.Key = key
            trip.Mode = CipherMode.CBC
            trip.Padding = PaddingMode.Zeros
            Dim ict As ICryptoTransform = trip.CreateEncryptor()
            enc = ict.TransformFinalBlock(data, 0, data.Length)

            hex = BitConverter.ToString(enc)
            ''Return Encoding.ASCII.GetString(enc)
            Return hex.Replace("-", "")

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "EncriptarCadenaComunicacionTerpel", "Datos: " & Datos, "AutorizadorRemoto")
            Throw New System.Exception("Error encriptando la cadena")
        End Try
    End Function

    Private Shared Function DesencriptarCadenaComunicacionTerpel(Datos As String) As String
        Dim OData As New POSstation.AccesoDatos.Helper
        Try
            Dim key() As Byte = Encoding.ASCII.GetBytes(OData.RecuperarParametro("LLaveTerpel"))
            Dim iv() As Byte = Encoding.ASCII.GetBytes(OData.RecuperarParametro("VectorTerpel"))
            Dim data() As Byte = Encoding.ASCII.GetBytes(Datos)
            Dim enc() As Byte
            Dim hex As String = ""
            Dim trip As TripleDES = TripleDES.Create()


            trip.IV = iv
            trip.Key = key
            trip.Mode = CipherMode.CBC
            trip.Padding = PaddingMode.Zeros
            Dim ict As ICryptoTransform = trip.CreateEncryptor()
            enc = ict.TransformFinalBlock(data, 0, data.Length)

            hex = BitConverter.ToString(enc)
            ''Return Encoding.ASCII.GetString(enc)
            Return hex.Replace("-", "")

        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "DesencriptarCadenaComunicacionTerpel", "Datos: " & Datos, "AutorizadorRemoto")
            Throw New System.Exception("Error deseencriptando la cadena")
        End Try
    End Function
End Class

