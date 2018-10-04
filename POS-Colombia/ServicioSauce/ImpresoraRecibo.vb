Imports POSstation.AccesoDatos
Imports System.Drawing.Printing
Imports System.IO
Imports POSstation.Fabrica
Imports POSstation.ServerServices


#Region "Recibo"
Public Class ImpresoraRecibo
    Inherits FormatoImpresora
    Private Shared LogFallas As New EstacionException

    Public Shared Sub ImpresionDatosIdentificadorDti(ByVal fechaProximoMantenimiento As String, ByVal placa As String, ByVal rom As String, ByVal impresora As ImpresoraEstacion)
        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")

                SW.WriteLine("ROM: " & rom)
                SW.WriteLine("Placa: " & placa)
                SW.WriteLine("Proximo Mantenimiento: " & fechaProximoMantenimiento)
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        End Try
    End Sub




    Public Shared Sub ImprimirPagoFrecuencia(ByVal IdRecaudo As Int64, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEstacion As InformacionEstacion
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim ORecaudo As IDataReader


            OEstacion = OHelper.RecuperarDatosEstacion()

            'Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ImprimirPagoFrecuencia" & IdRecaudo & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ImprimirPagoFrecuencia" & IdRecaudo & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ImprimirPagoFrecuencia" & IdRecaudo & ".txt")


                Parrafo = SeccionarParrafo(OEstacion.Nombre)

                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, OEstacion.Nombre))
                Next
                ORecaudo = OHelper.RecuperarRecaudoEmpresa(IdRecaudo)
                Parrafo.Clear()
                SW.WriteLine(CentrarTexto(40, OEstacion.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Telefono))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "PAGO DE FRECUENCIA"), "")
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumna(22, "Fecha sistema", "Hora sistema"))
                SW.WriteLine(DobleColumna(22, Date.Now.ToString("dd/MM/yyyy"), Date.Now.ToString("HH:mm:ss")))
                SW.WriteLine("---------------------------------------")
                If impresora.ESCopia Then
                    SW.WriteLine(CentrarTexto(40, "COPIA DE PAGO"), "")
                    SW.WriteLine("---------------------------------------")
                End If

                While ORecaudo.Read
                    If Not String.IsNullOrEmpty(ORecaudo.Item("IdRecaudoLocal").ToString) Then
                        SW.WriteLine("Consecutivo: " & ORecaudo.Item("IdRecaudoLocal").ToString)
                    End If
                    If Not String.IsNullOrEmpty(ORecaudo.Item("FechaInfoTaxi").ToString) Then
                        SW.WriteLine("Fecha Pago: " & ORecaudo.Item("FechaInfoTaxi").ToString)
                    End If
                    If Not String.IsNullOrEmpty(ORecaudo.Item("ValorPagado").ToString) Then
                        SW.WriteLine("Valor Recaudado: " & ORecaudo.Item("ValorPagado").ToString)
                    End If
                    If Not ORecaudo.Item("Movil") Is System.DBNull.Value Then
                        SW.WriteLine("Movil: " & ORecaudo.Item("Movil").ToString)
                    End If
                    If Not ORecaudo.Item("Periodos") Is System.DBNull.Value Then
                        SW.WriteLine("Periodos: " & ORecaudo.Item("Periodos").ToString)
                    End If
                    If Not ORecaudo.Item("MensajeInfoTaxi") Is System.DBNull.Value Then
                        SW.WriteLine("Descripcion: " & ORecaudo.Item("MensajeInfoTaxi").ToString)
                    End If
                    If Not ORecaudo.Item("IdPagoInfoTaxi") Is System.DBNull.Value Then
                        SW.WriteLine("Comprobante de pago: " & ORecaudo.Item("IdPagoInfoTaxi").ToString)
                    End If
                    If Not ORecaudo.Item("Placa") Is System.DBNull.Value Then
                        SW.WriteLine("Placa: " & ORecaudo.Item("Placa").ToString)
                    End If
                End While

                ORecaudo.Close()
                ORecaudo.Dispose()

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using


            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ImprimirPagoFrecuencia" & IdRecaudo & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ImprimirPagoFrecuencia" & IdRecaudo & ".txt")


        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirPagoFrecuencia", "", "ImprimirPagoFrecuencia")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirPagoFrecuencia", "", "ImprimirPagoFrecuencia")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirPagoFrecuencia", "", "ImprimirPagoFrecuencia")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirPagoFrecuencia", "", "ImprimirPagoFrecuencia")
        End Try
    End Sub

    Public Shared Sub ImprimirTopeConsignacion(ByVal recibo As Int64, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEstacion As InformacionEstacion
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)


            OEstacion = OHelper.RecuperarDatosEstacion()

            'Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\TopeConsignacion" & recibo & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\TopeConsignacion" & recibo & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\TopeConsignacion" & recibo & ".txt")


                Parrafo = SeccionarParrafo(OEstacion.Nombre)

                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, Linea))
                Next
                Parrafo.Clear()

                SW.WriteLine(CentrarTexto(40, OEstacion.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Telefono))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "MENSAJE INFORMATIVO"), "")
                SW.WriteLine("---------------------------------------")

                Parrafo = SeccionarParrafo("Empleado: " & OHelper.RecuperarEmpleadoPorReciboVenta(recibo))

                For Each Linea As String In Parrafo
                    SW.WriteLine(Linea)
                Next
                Parrafo.Clear()
                SW.WriteLine(DobleColumna(22, "Fecha:   " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Ha llegado al tope maximo para")
                SW.WriteLine("consignar, debe realizar la")
                SW.WriteLine("consignacion de sobres")



                SW.WriteLine("---------------------------------------")

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using


            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\TopeConsignacion" & recibo & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\TopeConsignacion" & recibo & ".txt")


        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTopeConsignacion", "", "ImprimirTopeConsignacion")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTopeConsignacion", "", "ImprimirTopeConsignacion")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTopeConsignacion", "", "ImprimirTopeConsignacion")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTopeConsignacion", "", "ImprimirTopeConsignacion")
            Throw
        End Try
    End Sub


    Public Shared Sub ImprimirCambioCheque(ByVal Cara As Short, ByVal Turno As Integer, ByVal Recibo As Long, ByVal NumeroAutorizacion As Long, ByVal ValorCambio As Decimal, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEncabezado As InformacionEncabezado
            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))
            Dim OResultadoDatos As IDataReader = Nothing

            OEncabezado = RecuperarEncabezado()

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\CambioCheque" & NumeroAutorizacion & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\CambioCheque" & NumeroAutorizacion & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\CambioCheque" & NumeroAutorizacion & ".txt")
                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))

                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine("---------------------------------------")

                OResultadoDatos = OHelper.RecuperarTurno(Turno)

                If OResultadoDatos.Read Then
                    SW.WriteLine("Islero: " & OResultadoDatos.Item("Nombre").ToString())
                End If
                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))

                OResultadoDatos.Close()
                OResultadoDatos = Nothing

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "CAMBIO DE CHEQUE"))
                SW.WriteLine("---------------------------------------")

                SW.WriteLine(DobleColumna(22, "Cara: " & Cara, "Surtidor: " & OHelper.RecuperarSurtidorporCara(Cara)))
                If Recibo > 0 Then
                    SW.WriteLine(DobleColumna(22, "Turno: " & CStr(Turno), "Recibo: " & CStr(Recibo)))
                Else
                    SW.WriteLine(DobleColumna(22, "Turno: " & CStr(Turno), "Recibo: "))
                End If
                SW.WriteLine("---------------------------------------")

                SW.WriteLine("Numero de Cheque: " & OHelper.RecuperarNumeroCheque(NumeroAutorizacion))
                SW.WriteLine("Numero de Autorizacion: " & CStr(NumeroAutorizacion))
                SW.WriteLine("Valor del cambio: " & ValorCambio.ToString("N2"))

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\CambioCheque" & NumeroAutorizacion & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\CambioCheque" & NumeroAutorizacion & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirCambioCheque", "ReciboCambioCheque: " & NumeroAutorizacion, "ImpresionRecibos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirCambioCheque", "ReciboCambioCheque: " & NumeroAutorizacion, "ImpresionRecibos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirCambioCheque", "ReciboCambioCheque: " & NumeroAutorizacion, "ImpresionRecibos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirCambioCheque", "ReciboCambioCheque: " & NumeroAutorizacion, "ImpresionRecibos")
            Throw ex
        End Try
    End Sub


    Public Shared Sub ImprimirErrorCreditoConsumo(ByVal impresora As ImpresoraEstacion, ByVal Placa As String, ByVal Cara As String, Optional ByVal mensaje As String = "")
        Try
            Dim Fecha As String

            '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
            Fecha = Now.ToString("HHmmss")
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\CreditoConsumo" & Fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\CreditoConsumo" & Fecha & ".txt")
            End If

            '--------------------------INICIA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\CreditoConsumo" & Fecha & ".txt")
                '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()
                Dim OHelper As New Helper
                Dim lector As IDataReader = Nothing

                lector = OHelper.RecuperarTurnoPorCara(CInt(Cara), Placa)

                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("----------------------------------------")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "CREDITO GERENCIADO"))
                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")

                If lector.Read() Then
                    SW.WriteLine(DobleColumna(22, "Turno: " & lector.Item("NumeroTurno").ToString, " Isla: " & lector.Item("Isla").ToString))
                    SW.WriteLine("Cara: " & Cara)
                    SW.WriteLine("Atendido Por: " & lector.Item("Empleado").ToString)
                    SW.WriteLine("Placa: " & Placa)
                    SW.WriteLine(" ")
                End If

                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "CLIENTE CREDITO"))
                SW.WriteLine("----------------------------------------")
                SW.WriteLine(CentrarTexto(40, "MENSAJE INFORMATIVO"), "")
                SW.WriteLine(" ")

                If String.IsNullOrEmpty(mensaje) Then
                    SW.WriteLine("En este momento no se puede realizar")
                    SW.WriteLine("El tanqueo por fallas en la comunicacion")

                    SW.WriteLine("Si desea tanquear debe pagar en efectivo")
                Else
                    SW.WriteLine("Cliente Credito Gerenciado")
                    SW.WriteLine(mensaje)
                    SW.WriteLine("Si desea tanquear debe pagar en efectivo")
                End If

                lector.Close()
                lector.Dispose()

                SW.WriteLine(" ")
                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()

                '----------------------IMPRIMO EL ARCHIVO Y POSTERIORMENTE LO ELIMINO-----------------------------------
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\CreditoConsumo" & Fecha & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\CreditoConsumo" & Fecha & ".txt")
            End Using

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Impresora: " & impresora.Nombre, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Impresora: " & impresora.Nombre, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Impresora: " & impresora.Nombre, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Impresora: " & impresora.Nombre, "ImpresionRecibos")
            Throw ex
        End Try
    End Sub

    Public Shared Sub ImprimirReciboReversion(ByVal reversion As Int32, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OReversion As IDataReader
            Dim OHelper As New Helper
            OReversion = OHelper.RecuperarReversion(reversion)

            If OReversion.Read Then
                Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
                End If
                If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboReversion" & reversion.ToString() & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboReversion" & reversion.ToString() & ".txt")
                End If

                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboReversion" & reversion.ToString() & ".txt")
                    SW.WriteLine(CentrarTexto(40, OReversion.Item("NombreEstacion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OReversion.Item("Nit").ToString()))
                    SW.WriteLine(" ")
                    SW.WriteLine(CentrarTexto(40, OReversion.Item("Direccion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OReversion.Item("Telefono").ToString()))
                    SW.WriteLine("---------------------------------------")

                    If Not String.IsNullOrEmpty(STexto) Then
                        SW.WriteLine(CentrarTexto(40, STexto))
                        SW.WriteLine("---------------------------------------")
                    End If

                    SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Parse(OReversion.Item("FechaAbono").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OReversion.Item("FechaAbono").ToString()).ToString("HH:mm")))
                    SW.WriteLine(DobleColumna(22, "Turno: " & OReversion.Item("NumeroTurno").ToString(), "Placa: " & OReversion.Item("Placa").ToString().Trim))
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, "CONSTANCIA DE REVERSION"))
                    SW.WriteLine("Recibo: " & reversion.ToString)
                    SW.WriteLine("Valor: " & OReversion.Item("valor").ToString())
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(" ")
                    SW.WriteLine("Este recibo no constituye factura")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(".")
                    SW.Close()
                End Using

                FormatoImpresora.AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboReversion" & reversion.ToString() & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboReversion" & reversion.ToString() & ".txt")
            End If
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboReversion", "ReciboReversion: " & reversion.ToString, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboReversion", "ReciboReversion: " & reversion.ToString, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboReversion", "ReciboReversion: " & reversion.ToString, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboReversion", "ReciboReversion: " & reversion.ToString, "ImpresionRecibos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirReciboTurno(ByVal turno As Int32, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OTurno As IDataReader
            Dim OHelper As New Helper
            OTurno = OHelper.RecuperarTurno(turno)

            If OTurno.Read Then
                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
                End If
                If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboTurno" & turno.ToString() & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboTurno" & turno.ToString() & ".txt")
                End If

                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboTurno" & turno.ToString() & ".txt")
                    SW.WriteLine(CentrarTexto(40, OTurno.Item("NombreEstacion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OTurno.Item("Nit").ToString()))
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, "APERTURA DE TURNO"))
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("HH:mm")))
                    SW.WriteLine("Turno: " & OTurno.Item("NumeroTurno").ToString())
                    SW.WriteLine("Empleado: " & OTurno.Item("Nombre").ToString())
                    SW.WriteLine("---------------------------------------")

                    Dim OSurtidores As IDataReader = OHelper.RecuperarSurtidoresPorTurno(CInt(OTurno.Item("IdTurno").ToString()))
                    Dim OLecturaM As IDataReader = Nothing
                    While (OSurtidores.Read)
                        SW.WriteLine(OSurtidores.Item("Descripcion").ToString & " : ")
                        OLecturaM = OHelper.RecuperarLecturasManguerasPorTurno(CInt(OTurno.Item("IdTurno").ToString()), CInt(OSurtidores.Item("IdSurtidor")))
                        While OLecturaM.Read
                            SW.WriteLine(OLecturaM.Item("Descripcion").ToString().Trim() & ": " & OLecturaM.Item("ValorInicial").ToString().Trim())
                        End While
                        SW.WriteLine("---------------------------------------")
                        OLecturaM.Close()
                        OLecturaM = Nothing
                    End While
                    OSurtidores.Close()
                    OSurtidores = Nothing

                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(".")
                    SW.Close()
                End Using

                OTurno.Close()
                OTurno = Nothing
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboTurno" & turno.ToString() & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboTurno" & turno.ToString() & ".txt")
            End If
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboTurno", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboTurno", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboTurno", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboTurno", "Turno: " & turno.ToString, "ImpresionTurnos")
        End Try
    End Sub

    Public Shared Sub ImprimirReciboAbono(ByVal pago As Int32, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OAbono As IDataReader
            Dim OHelper As New Helper
            OAbono = OHelper.RecuperarPago(pago)

            If OAbono.Read Then
                Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
                End If
                If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboAbono" & pago.ToString() & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboAbono" & pago.ToString() & ".txt")
                End If

                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboAbono" & pago.ToString() & ".txt")
                    SW.WriteLine(CentrarTexto(40, OAbono.Item("NombreEstacion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OAbono.Item("Nit").ToString()))
                    SW.WriteLine(" ")
                    SW.WriteLine(CentrarTexto(40, OAbono.Item("Direccion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OAbono.Item("Telefono").ToString()))
                    SW.WriteLine("---------------------------------------")

                    If Not String.IsNullOrEmpty(STexto) Then
                        SW.WriteLine(CentrarTexto(40, STexto))
                        SW.WriteLine("---------------------------------------")
                    End If

                    SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Parse(OAbono.Item("Fecha").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OAbono.Item("Fecha").ToString()).ToString("HH:mm")))
                    SW.WriteLine(DobleColumna(22, "Turno: " & OAbono.Item("NumeroTurno").ToString(), "Placa: " & OAbono.Item("Placa").ToString().Trim))
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, "RECIBO DE PAGO EXTRAORDINARIO"))
                    SW.WriteLine("Numero: " & pago.ToString)
                    SW.WriteLine("Valor: " & CDbl(OAbono.Item("valor")).ToString("N0"))
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine("***************************************")
                    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "Este tiquete constituye soporte de"))
                    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "cancelacion del Pago Diario"))
                    SW.WriteLine("***************************************")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(".")
                    SW.Close()
                End Using

                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboAbono" & pago.ToString() & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboAbono" & pago.ToString() & ".txt")
            End If
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboAbono", "ReciboAbono: " & pago.ToString, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboAbono", "RReciboAbono: " & pago.ToString, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboAbono", "ReciboAbono: " & pago.ToString, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboAbono", "ReciboAbono: " & pago.ToString, "ImpresionRecibos")
            Throw
        End Try
    End Sub
    Public Shared Sub ImprimirRecargaPrepago(ByVal idCupo As Int32, ByVal impresora As ImpresoraEstacion)


        Try
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim oDatos As DataTable = Nothing
            Dim Mensaje As String = String.Empty
            Dim Aplica As Boolean = False


            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\RecargaPrepago" & idCupo.ToString & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\RecargaPrepago" & idCupo.ToString & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\RecargaPrepago" & idCupo.ToString & ".txt")

                'Recupero el encabezado
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                Parrafo = SeccionarParrafo(OEncabezado.NombreEstacion)
                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, Linea))
                Next
                Parrafo.Clear()

                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine("---------------------------------------")

                If impresora.ESCopia Then
                    SW.WriteLine(CentrarTexto(40, "COPIA"))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(CentrarTexto(40, "RECARGA PREPAGO"))
                SW.WriteLine("---------------------------------------")

                oDatos = OHelper.RecuperarCupoPrepago(idCupo)
                SW.WriteLine("CONSECUTIVO: " & idCupo.ToString)
                If Not oDatos Is Nothing Then
                    SW.WriteLine(Date.Parse(oDatos.Rows(0).Item("Fecha").ToString).ToString("dd/MM/yyyy HH:mm:ss"))
                    SW.WriteLine("TARJETA: " & oDatos.Rows(0).Item("NroTarjeta").ToString)
                    SW.WriteLine("---------------------------------------")

                    'Nombre del cliente

                    For Each Registro As DataRow In oDatos.Rows

                        SW.WriteLine(DobleColumnaNumerica(Registro.Item("FormaPago").ToString & " : ", CDbl(Registro.Item("ValorFormaPago").ToString)))

                        SW.WriteLine("---------------------------------------")
                    Next
                    SW.WriteLine(" ")
                    SW.WriteLine(DobleColumnaTotal("Total Recarga: ", oDatos.Rows(0).Item("Recarga").ToString))
                    SW.WriteLine(DobleColumnaTotal("Total Disponible: ", oDatos.Rows(0).Item("CupoTotal").ToString))
                End If


                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
                SW.Dispose()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\RecargaPrepago" & idCupo.ToString & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\RecargaPrepago" & idCupo.ToString & ".txt")

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirRecargaPrepago", "ReciboRecarga: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionRecarga")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirRecargaPrepago", "ReciboRecarga: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionRecarga")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirRecargaPrepago", "ReciboRecarga: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionRecarga")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirRecargaPrepago", "Reciborecarga: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionRecarga")
            Throw ex
        End Try
    End Sub



    Public Shared Sub ImprimirRecibo(ByVal cara As Byte, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OHelper As New Helper
            Dim Recibo As Double = OHelper.RecuperarUltimoReciboCara(cara)
            Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog

            LogCategorias.Clear()
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Impresora", impresora.Nombre)
            LogPropiedades.Agregar("Fecha", Now.ToString)
            POSstation.Fabrica.LogIt.Loguear("Antes de Imprimir ImprimirRecibo", LogPropiedades, LogCategorias)

            ImprimirRecibo(Recibo, impresora)

            LogCategorias.Clear()
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Impresora", impresora.Nombre)
            LogPropiedades.Agregar("Fecha", Now.ToString)
            POSstation.Fabrica.LogIt.Loguear("Despues de Imprimir ImprimirRecibo", LogPropiedades, LogCategorias)

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboPorCara", "Cara: " & cara.ToString, "ImpresionRecibos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboPorCara", "Cara: " & cara.ToString, "ImpresionRecibos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboPorCara", "Recibo: " & cara.ToString, "ImpresionRecibos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboPorCara", "Recibo: " & cara.ToString, "ImpresionRecibos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImpresionDatosIdentificador(ByVal fechaConversion As Date, ByVal fechaProximoMantenimiento As Date, ByVal numero As Int64, ByVal placa As String, ByVal rom As String, ByVal impresora As ImpresoraEstacion)
        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")

                SW.WriteLine("ROM: " & rom)
                SW.WriteLine("Placa: " & placa)
                SW.WriteLine("Conversion: " & fechaConversion.ToString("dd-MM-yyyy"))
                SW.WriteLine("Proximo Mantenimiento: " & fechaProximoMantenimiento.ToString("dd-MM-yyyy"))
                SW.WriteLine("Numero: " & numero.ToString("N0"))
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        End Try
    End Sub

    Public Shared Sub ImpresionDatosIdentificadorGasolina(ByVal rom As String, ByVal impresora As ImpresoraEstacion)

        Try
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")

                SW.WriteLine(CentrarTexto(40, "DATOS DEL CHIP"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine("ROM: " & rom)
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\" & rom & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImpresionDatosIdentificador", "Rom: " & rom, "ImpresionGeneral")
            Throw
        End Try

    End Sub

    Public Shared Sub ImprimirReciboVentaModificada(ByVal recibo As Double, ByVal prepagos As Array, ByVal impresora As ImpresoraEstacion)
        Try

            Dim OVenta As InformacionRecibo
            Dim OHelper As New Helper

            OVenta = RecuperarVenta(recibo)

            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt")

                Dim OSlogans As IDataReader = Nothing

                OSlogans = OHelper.RecuperarSlogansPorTipo(1)
                If OSlogans.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    While OSlogans.Read
                        SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    End While
                End If
                OSlogans.Close()
                OSlogans = Nothing

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OVenta.Nit))
                SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")

                End If

                SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Fecha, "Hora: " & OVenta.Hora.Trim))
                SW.WriteLine(DobleColumna(22, "Nro. : " & OVenta.Numero, "Placa: " & OVenta.Placa.Trim))
                SW.WriteLine(DobleColumna(22, "Turno: " & OVenta.Turno, "Isla: " & OVenta.Isla.Trim))
                SW.WriteLine(DobleColumna(22, "Cara : " & OVenta.Cara, "Manguera: " & OVenta.Manguera.Trim))

                If Not String.IsNullOrEmpty(OVenta.Kilometraje) Then
                    SW.WriteLine("Kilometraje: " & OVenta.Kilometraje)
                End If


                If CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVenta")) Then
                    If Not String.IsNullOrEmpty(OVenta.AtendidoPor) Then
                        SW.WriteLine("Atendido por: " & OVenta.NombreEmpleado)
                    End If
                Else
                    If OVenta.EsCredito Then
                        SW.WriteLine("Atendido por : " & OVenta.Cedula)
                    Else
                        If Not String.IsNullOrEmpty(OVenta.CodigoVendedor) Then
                            SW.WriteLine("Responsable Isla : " & OVenta.Cedula)
                        End If
                        If Not String.IsNullOrEmpty(OVenta.AtendidoPor) Then
                            SW.WriteLine("Atendido por : " & OVenta.CodigoVendedor)
                        End If
                    End If
                End If

                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Articulo: " & OVenta.NombreArticulo)
                SW.WriteLine(DobleColumna(22, "Cantidad: " & OVenta.Cantidad & OVenta.UnidadMedida, "PVP: " & CDbl(OVenta.Precio).ToString("N0")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION FORMAS DE PAGO VENTA"))
                SW.WriteLine("***************************************")
                Dim VentasFormasPago As IDataReader = OHelper.RecuperarFormasPagoVenta(CLng(recibo))
                While VentasFormasPago.Read
                    SW.WriteLine(DobleColumnaNumerica(VentasFormasPago.Item(0).ToString & " : ", CDbl(VentasFormasPago.Item(1)).ToString("N0")))
                End While

                SW.WriteLine("***************************************")
                SW.WriteLine(DobleColumnaNumerica("Valor Venta: ", CDbl(OVenta.Valor).ToString("N0")))

                If CDbl(OVenta.Recaudo) > 0 Then
                    SW.WriteLine(DobleColumnaNumerica("Recaudo: ", CDbl(OVenta.Recaudo).ToString("N0")))
                    If CDbl(OVenta.ValorReversado) > 0 Then
                        SW.WriteLine(DobleColumnaNumerica("Valor Reversado: ", CDbl(OVenta.ValorReversado).ToString("N0")))
                    End If
                End If

                If CDbl(OVenta.Descuento) > 0 Then
                    SW.WriteLine(DobleColumnaNumerica("Descuento: ", CDbl(OVenta.Descuento).ToString("N0")))
                End If

                SW.WriteLine(DobleColumnaNumerica("Total: ", CDbl(CDbl(OVenta.Total) - CDbl(OVenta.ValorReversado)).ToString("N0")))

                SW.WriteLine("---------------------------------------")

                If CDbl(OVenta.RecaudoOpcional) > 0 Then
                    SW.WriteLine(DobleColumnaNumerica("Recaudo Opcional: ", CDbl(OVenta.RecaudoOpcional).ToString("N0")))
                    SW.WriteLine(" ")
                    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "Este tiquete NO constituye soporte de"))
                    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "cancelacion del Pago Diario"))
                    SW.WriteLine("---------------------------------------")
                End If

                If OVenta.EsLecturaChipObligatoria Then


                    If CBool(OHelper.RecuperarParametro("GanaMillones")) Then
                        Dim OGanaMillones As IDataReader = OHelper.RecuperarNumerosLoteriaPorRecibo(CLng(recibo))

                        If (OGanaMillones.Read) Then
                            SW.WriteLine("***************************************")
                            SW.WriteLine(CentrarTexto(40, "GANA MILLONES"))
                            SW.WriteLine("***************************************")
                            SW.WriteLine("Estos son los numeros con los que")
                            SW.WriteLine("participas en el sorteo de $10.000.000")
                            SW.WriteLine("el " & CDate(OGanaMillones.Item("Fecha")).ToString("dd") & " de " & CDate(OGanaMillones.Item("Fecha")).ToString("MMMM") & " del " & CDate(OGanaMillones.Item("Fecha")).ToString("yyyy") & ", con")
                            SW.WriteLine(OGanaMillones.Item("Loteria").ToString & " :")
                            SW.WriteLine(" ")
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, OGanaMillones("Numero").ToString))

                            While OGanaMillones.Read
                                SW.WriteLine(CentrarTexto(40, OGanaMillones("Numero").ToString))
                            End While
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, "Tanqueando en gazel, acumulas mas"))
                            SW.WriteLine(CentrarTexto(40, "oportunidades de ganar!"))
                            SW.WriteLine(CentrarTexto(40, "Aplican condiciones y restricciones"))
                            SW.WriteLine(" ")
                            SW.WriteLine("***************************************")
                        End If
                    End If

                    SW.WriteLine(" ")
                    'If Not impresora.ESCopia Then
                    '    SW.WriteLine("***************************************")
                    '    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "Este ticket constituye soporte de"))
                    '    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "pago de la financiacion"))
                    '    SW.WriteLine("***************************************")
                    'End If


                    SW.WriteLine(" ")


                    SW.WriteLine("Fecha Proxima revision anual ")
                    SW.WriteLine("obligatoria:" & Date.Parse(OVenta.FechaProximaRevision).ToString("dd/MM/yyyy"))
                    SW.WriteLine("Este recibo no constituye factura")
                    SW.WriteLine(" ")
                End If



                Dim OPremios As IDataReader = OHelper.RecuperarPremios(OVenta.Placa.Trim)
                If OPremios.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(OPremios.Item("Descripcion1").ToString().Trim())
                    If Not String.IsNullOrEmpty(OPremios.Item("Descripcion2").ToString().Trim()) Then
                        SW.WriteLine(OPremios.Item("Descripcion2").ToString().Trim())
                    End If
                    'CORREGIDO EL IF sTRING POR IF NOT IF'
                    If Not String.IsNullOrEmpty(OPremios.Item("Descripcion3").ToString().Trim()) Then
                        SW.WriteLine(OPremios.Item("Descripcion3").ToString().Trim())
                    End If
                    While OPremios.Read
                        SW.WriteLine(OPremios.Item("Descripcion1").ToString().Trim())
                        If Not String.IsNullOrEmpty(OPremios.Item("Descripcion2").ToString().Trim()) Then
                            SW.WriteLine(OPremios.Item("Descripcion2").ToString().Trim())
                        End If
                        'CORREGIDO EL IF sTRING POR IF NOT IF'
                        If Not String.IsNullOrEmpty(OPremios.Item("Descripcion3").ToString().Trim()) Then
                            SW.WriteLine(OPremios.Item("Descripcion3").ToString().Trim())
                        End If
                    End While
                    SW.WriteLine("---------------------------------------")
                End If
                OPremios.Close()
                OPremios = Nothing

                SW.WriteLine(" ")
                OSlogans = OHelper.RecuperarSlogansPorTipo(2)
                If OSlogans.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    While OSlogans.Read
                        SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    End While
                    SW.WriteLine("---------------------------------------")
                End If
                OSlogans.Close()
                OSlogans = Nothing


                SW.WriteLine(" ")
                Dim IdCliente As Int32 = OHelper.RecuperarIdClientePorRecibo(CLng(recibo))
                If IdCliente <> -1 Then
                    OSlogans = OHelper.RecuperarSlogansPorCliente(IdCliente)
                    If OSlogans.Read Then
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                        While OSlogans.Read
                            SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                        End While
                        SW.WriteLine("---------------------------------------")
                    End If
                    OSlogans.Close()
                    OSlogans = Nothing
                End If


                SW.WriteLine(" ")
                'If prepagos.Length > 0 Then
                '    SW.WriteLine("***************************************")
                '    SW.WriteLine(CentrarTexto(40, "SALDOS TARJETAS PREPAGOS"))
                '    SW.WriteLine(FormatoImpresora.TripleColumnaLecturas("Tarjeta", "Valor", "Saldo"))
                '    For Each prepago As String In prepagos
                '        Dim Datos() As String = prepago.Split(CChar("|"))
                '        SW.WriteLine(FormatoImpresora.TripleColumnaLecturas(Datos(0), CDbl(Datos(1)).ToString("N0"), CDbl(Datos(2)).ToString("N0")))
                '    Next
                '    SW.WriteLine("***************************************")
                'End If
                SW.WriteLine(" ")
                SW.WriteLine("ESTE RECIBO NO CONSTITUYE FACTURA")
                SW.WriteLine("DECRETO 11.89  DE 1989")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
        End Try
    End Sub

    Public Shared Sub ImprimirRecibo(ByVal recibo As Double, ByVal impresora As ImpresoraEstacion, Optional ByVal esVentaRegistrada As Boolean = True)
        Try
            Dim OVenta As InformacionRecibo
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim TotalPagar As Double = 0
            Dim LogPropiedades As New PropiedadesExtendidas, LogCategorias As New CategoriasLog
            OVenta = RecuperarVenta(recibo, esVentaRegistrada)

            'SI LA VENTA YA FUE IMPRESA SE IMPRIME LA PALABRA COPIA
            If OVenta.EsImpresa Then
                impresora.ESCopia = True
            Else
                impresora.ESCopia = False
            End If

            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt")

                Dim OSlogans As IDataReader = Nothing
                Dim oMensajeSlogan As DataTable = Nothing

                oMensajeSlogan = OHelper.RecuperarMensajeSlogan

                If Not oMensajeSlogan Is Nothing Then
                    For Each mensaje As DataRow In oMensajeSlogan.Rows
                        If CShort(mensaje.Item("Posicion").ToString) = 1 Then
                            Parrafo = SeccionarParrafoFidelizacion(mensaje.Item("Mensaje").ToString().Trim())
                            For Each Linea As String In Parrafo
                                SW.WriteLine(Linea)
                            Next
                            SW.WriteLine(" ")
                            Parrafo.Clear()
                        End If
                    Next
                End If

                OSlogans = OHelper.RecuperarSlogansPorTipo(1)
                If OSlogans.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    While OSlogans.Read
                        SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    End While
                End If
                OSlogans.Close()
                OSlogans = Nothing


                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OVenta.Nit))
                SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")

                End If

                If OVenta.EsRecuperada Then
                    SW.WriteLine(CentrarTexto(40, "VENTA RECUPERADA"))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Fecha, "Hora: " & OVenta.Hora.Trim))
                SW.WriteLine(DobleColumna(22, "Nro. : " & OVenta.Numero, "Placa: " & OVenta.Placa.Trim))
                SW.WriteLine(DobleColumna(22, "Turno: " & OVenta.Turno, "Isla: " & OVenta.Isla.Trim))
                SW.WriteLine(DobleColumna(22, "Cara : " & OVenta.Cara, "Manguera: " & OVenta.Manguera.Trim))

                If Not String.IsNullOrEmpty(OVenta.Kilometraje) Then
                    SW.WriteLine("Kilometraje: " & OVenta.Kilometraje)
                End If

                If Not String.IsNullOrEmpty(OVenta.Nivel) Then
                    SW.WriteLine("Nivel: " & OVenta.Nivel)
                End If

                If OVenta.EsCredito Then
                    If OVenta.SaldoDisponible.HasValue Then
                        If OVenta.SaldoDisponible.Value > 0 Then
                            SW.WriteLine("Saldo Credito: " & OVenta.SaldoDisponible.Value)
                            SW.WriteLine("---------------------------------------")
                            SW.WriteLine("---------------------------------------")
                        ElseIf OVenta.SaldoDisponible.Value <= 0 Then
                            SW.WriteLine("Saldo Credito: " & "0")
                            SW.WriteLine("---------------------------------------")
                            SW.WriteLine("---------------------------------------")
                        End If
                    End If
                End If

                If CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVenta")) Then
                    If Not String.IsNullOrEmpty(OVenta.NombreEmpleado) Then
                        SW.WriteLine("Atendido por: " & OVenta.NombreEmpleado)
                    End If
                    If OVenta.EsPrepago Then
                        If Not OVenta.NombreCliente Is Nothing Then
                            SW.WriteLine("Cliente : " & OVenta.NombreCliente)
                        End If
                    End If
                    If OVenta.EsCredito Then
                        SW.WriteLine("Cliente : " & OVenta.NombreCliente)
                    End If
                Else
                    If Not String.IsNullOrEmpty(OVenta.Cedula) Then
                        SW.WriteLine("Responsable Isla : " & OVenta.Cedula)
                    End If
                    If Not String.IsNullOrEmpty(OVenta.CodigoVendedor) Then
                        SW.WriteLine("Atendido por : " & OVenta.CodigoVendedor)
                    End If
                    If OVenta.EsCredito Then
                        SW.WriteLine("Cliente : " & OVenta.NombreCliente)
                    End If
                    If OVenta.EsPrepago Then
                        If Not OVenta.NombreCliente Is Nothing Then
                            SW.WriteLine("Cliente : " & OVenta.NombreCliente)
                        End If
                    End If
                End If

                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Articulo: " & OVenta.NombreArticulo)
                SW.WriteLine(DobleColumna(22, "Cantidad: " & OVenta.Cantidad & " " & OVenta.UnidadMedida, "PVP: " & CDbl(OVenta.Precio).ToString("N0")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION FORMAS DE PAGO VENTA"))
                SW.WriteLine("---------------------------------------")
                Dim VentasFormasPago As IDataReader = OHelper.RecuperarFormasPagoVenta(CLng(recibo))
                While VentasFormasPago.Read
                    SW.WriteLine(DobleColumnaNumerica(VentasFormasPago.Item(0).ToString & " : ", CDbl(VentasFormasPago.Item(1)).ToString("N0")))
                End While
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumnaNumerica("Valor Venta: ", CDbl(OVenta.Valor).ToString("N0")))

                '------- APLICAR DESCUENTOS\INCREMENTOS POR CLIENTE\VEHICULO ---------
                If CDbl(OVenta.ValorCambioPrecio) <> 0 Then

                    If OVenta.EsDescuentoCliente Then
                        If OVenta.PorcentajeClienteCredito > 0 Then
                            SW.WriteLine(DobleColumnaNumerica("Descuento(" & OVenta.PorcentajeClienteCredito.ToString() & "%):", CDbl(OVenta.ValorCambioPrecio).ToString()))
                        Else
                            SW.WriteLine(DobleColumnaNumerica("Descuento:", CDbl(OVenta.ValorCambioPrecio).ToString("N0")))
                        End If
                        TotalPagar = CDbl(OVenta.Valor) - CDbl(OVenta.ValorCambioPrecio)
                    Else
                        If OVenta.PorcentajeClienteCredito > 0 Then
                            SW.WriteLine(DobleColumnaNumerica("Incremento(" & OVenta.PorcentajeClienteCredito.ToString() & "%):", CDbl(OVenta.ValorCambioPrecio).ToString))
                        Else
                            SW.WriteLine(DobleColumnaNumerica("Incremento:", CDbl(OVenta.ValorCambioPrecio).ToString("N0")))
                        End If
                        TotalPagar = CDbl(OVenta.Valor) + CDbl(OVenta.ValorCambioPrecio)
                    End If

                    SW.WriteLine("---------------------------------------")
                Else
                    TotalPagar = CDbl(OVenta.Valor) - CDbl(OVenta.Descuento)
                End If

                '----------------------

                If CDbl(OVenta.Recaudo) > 0 Then
                    SW.WriteLine(DobleColumnaNumerica("Recaudo: ", CDbl(OVenta.Recaudo).ToString("N0")))
                    If CDbl(OVenta.ValorReversado) > 0 Then
                        SW.WriteLine(DobleColumnaNumerica("Valor Reversado: ", CDbl(OVenta.ValorReversado).ToString("N0")))
                        TotalPagar = CDbl(CDbl(OVenta.Total) - CDbl(OVenta.ValorReversado)).ToString("N0")
                    Else
                        TotalPagar = CDbl(OVenta.Valor)
                    End If
                End If

                If CDbl(OVenta.Descuento) > 0 Then
                    SW.WriteLine(DobleColumnaNumerica("Descuento: ", CDbl(OVenta.Descuento).ToString("N0")))
                End If

                SW.WriteLine(DobleColumnaNumerica("Total: ", TotalPagar.ToString("N0")))

                SW.WriteLine("---------------------------------------")


                If Not String.IsNullOrEmpty(OVenta.NroAutorizacionCheque) Then
                    SW.WriteLine("Nro Cheque: " & OVenta.NroCheque)
                    SW.WriteLine("Nro Aut. Cheque: " & OVenta.NroAutorizacionCheque)
                    SW.WriteLine("Valor Cheque: " & OVenta.ValorCheque)
                    SW.WriteLine("---------------------------------------")
                End If

                If CDbl(OVenta.RecaudoOpcional) > 0 Then
                    SW.WriteLine(DobleColumnaNumerica("Recaudo Opcional: ", CDbl(OVenta.RecaudoOpcional).ToString("N0")))
                    SW.WriteLine(" ")
                    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "Este tiquete NO constituye soporte de"))
                    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "cancelacion del Pago Diario"))
                    SW.WriteLine("---------------------------------------")
                End If
                Dim CupoPrepago As Double
                If OVenta.EsPrepago Then
                    Try
                        If Not String.IsNullOrEmpty(OVenta.Tarjeta) Then
                            Dim saldo As New RespuestaSaldo
                            saldo = POSstation.ServerServices.CDCServices.SaldoTarjeta(OVenta.Tarjeta)
                            CupoPrepago = saldo.Saldo
                            SW.WriteLine("***************************************")
                            SW.WriteLine("Saldo de Tarjeta: " & CupoPrepago)
                            SW.WriteLine("***************************************")
                        End If
                    Catch ex As System.Exception
                        LogCategorias.Clear()
                        LogPropiedades.Clear()
                        LogPropiedades.Agregar("Impresora", impresora.Nombre)
                        LogPropiedades.Agregar("Fecha", Now.ToString)
                        LogPropiedades.Agregar("Recibo", recibo.ToString)
                        POSstation.Fabrica.LogIt.Loguear("Logueo saldo prepago", LogPropiedades, LogCategorias)
                    End Try

                End If


                If OVenta.EsLecturaChipObligatoria Then

                    If CBool(OHelper.RecuperarParametro("GanaMillones")) Then
                        Dim OGanaMillones As IDataReader = OHelper.RecuperarNumerosLoteriaPorRecibo(CLng(recibo))

                        If (OGanaMillones.Read) Then
                            SW.WriteLine("***************************************")
                            SW.WriteLine(CentrarTexto(40, "GANA MILLONES"))
                            SW.WriteLine("***************************************")
                            SW.WriteLine("Estos son los numeros con los que")
                            SW.WriteLine("participas en el sorteo de $10.000.000")
                            SW.WriteLine("el " & CDate(OGanaMillones.Item("Fecha")).ToString("dd") & " de " & CDate(OGanaMillones.Item("Fecha")).ToString("MMMM") & " del " & CDate(OGanaMillones.Item("Fecha")).ToString("yyyy") & ", con")
                            SW.WriteLine(OGanaMillones.Item("Loteria").ToString & " :")
                            SW.WriteLine(" ")
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, OGanaMillones("Numero").ToString))

                            While OGanaMillones.Read
                                SW.WriteLine(CentrarTexto(40, OGanaMillones("Numero").ToString))
                            End While
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, "Tanqueando en gazel, acumulas mas"))
                            SW.WriteLine(CentrarTexto(40, "oportunidades de ganar!"))
                            SW.WriteLine(CentrarTexto(40, "Aplican condiciones y restricciones"))
                            SW.WriteLine(" ")
                            SW.WriteLine("***************************************")
                        End If
                    End If

                    SW.WriteLine(" ")


                    'If Not impresora.ESCopia Then
                    '    SW.WriteLine("***************************************")
                    '    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "Este ticket constituye soporte de"))
                    '    SW.WriteLine(FormatoImpresora.CentrarTexto(40, "pago de la financiacion"))
                    '    SW.WriteLine("***************************************")
                    'End If


                    SW.WriteLine(" ")
                    SW.WriteLine("Fecha Proxima revision anual ")
                    SW.WriteLine("obligatoria:" & (OVenta.FechaProximaRevision))
                    SW.WriteLine(" ")
                End If

                Try
                    Dim ODatosTarjeta As IDataReader = OHelper.RecuperarVentaFidelizada(CLng(recibo), esVentaRegistrada)
                    If ODatosTarjeta.Read Then
                        If Not CBool(ODatosTarjeta.Item("ManejaSaldo")) Then
                            'If ODatosTarjeta.Item("Puntos") Is DBNull.Value Then
                            '    SW.WriteLine(" ")
                            '    SW.WriteLine("***************************************")
                            '    SW.WriteLine("Tarjeta Fidelizada: " & ODatosTarjeta.Item("Tarjeta").ToString)
                            '    SW.WriteLine("***************************************")
                            'Else
                            '    SW.WriteLine(" ")
                            '    SW.WriteLine("***************************************")
                            '    SW.WriteLine("Tarjeta Fidelizada: " & ODatosTarjeta.Item("Tarjeta").ToString)
                            '    SW.WriteLine("Puntos: " & ODatosTarjeta.Item("Puntos"))
                            '    SW.WriteLine("***************************************")
                            'End If
                            SW.WriteLine("***************************************")
                            Dim ODataSet As DataSet = Nothing
                            Dim CodEstacion As String
                            Dim ORespuesta As POSstation.Fabrica.Fidelizacion
                            Dim ClienteFidelizado As String = ""
                            Dim PuntosTarjeta As Decimal = 0
                            Dim FechaActualizacionPuntos As DateTime = Now
                            Dim Mensaje As String = ""
                            Dim HayComunicacion As Boolean = False


                            ODataSet = OHelper.RecuperarCodEstacion()
                            CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
                            ODataSet = Nothing

                            'Consulto saldo de tarjeta para recuperar los datos que se deben enviar al sp RecuperarReciboFidelizacion
                            Try
                                ORespuesta = POSstation.ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(ODatosTarjeta.Item("Tarjeta").ToString)
                                If Not ORespuesta.Saldos Is Nothing Then
                                    HayComunicacion = True
                                    ClienteFidelizado = ORespuesta.Saldos.Tables(0).Rows(0).Item("Conductor").ToString()
                                    PuntosTarjeta = ORespuesta.Saldos.Tables(0).Rows(0).Item("Saldo").ToString()
                                    FechaActualizacionPuntos = ORespuesta.Saldos.Tables(0).Rows(0).Item("Fecha").ToString()
                                    ORespuesta.Saldos = Nothing

                                    SW.WriteLine("Fidelizado:")
                                    SW.WriteLine(ClienteFidelizado)
                                    SW.WriteLine("Puntos: " & PuntosTarjeta.ToString("N2"))
                                    SW.WriteLine("Fec. Act. Puntos: " & FechaActualizacionPuntos.ToString("dd/MM/yyyy hh:mm:ss"))


                                    If Not ORespuesta.MensajesCliente Is Nothing Then
                                        If ORespuesta.MensajesCliente.Tables.Count > 0 Then
                                            If ORespuesta.MensajesCliente.Tables(0).Rows.Count > 0 Then
                                                For Each row As DataRow In ORespuesta.MensajesCliente.Tables(0).Rows
                                                    Mensaje = row.Item("MensajeDia").ToString()
                                                    Parrafo = SeccionarParrafo(Mensaje)
                                                    For Each Linea As String In Parrafo
                                                        SW.WriteLine(Linea)
                                                    Next
                                                    Parrafo.Clear()
                                                Next
                                                ORespuesta.MensajesCliente = Nothing
                                            End If
                                        End If
                                    End If
                                Else
                                    HayComunicacion = False
                                End If
                            Catch ex As System.Exception
                                HayComunicacion = False
                            End Try


                            If Not HayComunicacion Then
                                SW.WriteLine("EN ESTOS MOMENTOS NO HAY COMUNICACION")
                                SW.WriteLine("CON SOY LEAL. LOS PUNTOS SE ACUMULARAN")
                                SW.WriteLine("APENAS SE RESTABLEZCA LA COMUNICACION.")
                            End If
                            SW.WriteLine("***************************************")
                        Else
                            Dim DatosConductor As IDataReader = OHelper.RecuperarConductorPorTarjeta(ODatosTarjeta.Item("Tarjeta").ToString)
                            Dim Puntos As Long = OHelper.RecuperarPuntosDisponiblesPorCampaña(-1, ODatosTarjeta.Item("Tarjeta").ToString)
                            If DatosConductor.Read Then
                                SW.WriteLine(" ")
                                SW.WriteLine("***************************************")
                                SW.WriteLine("Cliente: " & DatosConductor.Item("Nombre").ToString)
                                SW.WriteLine("Tarjeta: " & ODatosTarjeta.Item("Tarjeta").ToString)
                                SW.WriteLine("Puntos Acumulados: " & Math.Floor(CDec(OVenta.Cantidad)))
                                SW.WriteLine("TOTAL PUNTOS ACUMULADOS: " & Puntos.ToString)
                                SW.WriteLine("***************************************")
                            End If
                            DatosConductor.Close()
                        End If
                    End If
                    ODatosTarjeta.Close()
                    ODatosTarjeta = Nothing
                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
                End Try

                Dim OPremios As IDataReader = OHelper.RecuperarPremios(OVenta.Placa.Trim)
                If OPremios.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(OPremios.Item("Descripcion1").ToString().Trim())
                    If Not String.IsNullOrEmpty(OPremios.Item("Descripcion2").ToString().Trim()) Then
                        SW.WriteLine(OPremios.Item("Descripcion2").ToString().Trim())
                    End If
                    'CORREGIDO EL IF sTRING POR IF NOT IF'
                    If Not String.IsNullOrEmpty(OPremios.Item("Descripcion3").ToString().Trim()) Then
                        SW.WriteLine(OPremios.Item("Descripcion3").ToString().Trim())
                    End If
                    While OPremios.Read
                        SW.WriteLine(OPremios.Item("Descripcion1").ToString().Trim())
                        If Not String.IsNullOrEmpty(OPremios.Item("Descripcion2").ToString().Trim()) Then
                            SW.WriteLine(OPremios.Item("Descripcion2").ToString().Trim())
                        End If
                        'CORREGIDO EL IF sTRING POR IF NOT IF'
                        If Not String.IsNullOrEmpty(OPremios.Item("Descripcion3").ToString().Trim()) Then
                            SW.WriteLine(OPremios.Item("Descripcion3").ToString().Trim())
                        End If
                    End While
                    SW.WriteLine("---------------------------------------")
                End If
                OPremios.Close()
                OPremios = Nothing

                SW.WriteLine(" ")
                OSlogans = OHelper.RecuperarSlogansPorTipo(2)
                If OSlogans.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    While OSlogans.Read
                        SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                    End While
                    SW.WriteLine("---------------------------------------")
                End If
                OSlogans.Close()
                OSlogans = Nothing


                SW.WriteLine(" ")
                Dim IdCliente As Int32 = OHelper.RecuperarIdClientePorRecibo(CLng(recibo))
                If IdCliente <> -1 Then
                    OSlogans = OHelper.RecuperarSlogansPorCliente(IdCliente)
                    If OSlogans.Read Then
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                        While OSlogans.Read
                            SW.WriteLine(OSlogans.Item(0).ToString().Trim())
                        End While
                        SW.WriteLine("---------------------------------------")
                    End If
                    OSlogans.Close()
                    OSlogans = Nothing
                End If

                SW.WriteLine(" ")

                If Not oMensajeSlogan Is Nothing Then
                    For Each mensaje As DataRow In oMensajeSlogan.Rows
                        If CShort(mensaje.Item("Posicion").ToString) = 2 Then
                            Parrafo = SeccionarParrafoFidelizacion(mensaje.Item("Mensaje").ToString().Trim())
                            For Each Linea As String In Parrafo
                                SW.WriteLine(Linea)
                            Next
                            SW.WriteLine(" ")
                            Parrafo.Clear()
                        End If
                    Next
                End If

                '--------------------------------------------------------------------------------------------------------------------------
                Dim oReader As IDataReader
                oReader = OHelper.RecuperarDatosTicketGasoNet(CStr(recibo))
                If oReader.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine("Nombre Cliente GasoNet: " & oReader("NombreCliente").ToString)
                    SW.WriteLine("Mensaje Confirmacion: " & oReader("MensajeConfirmacion").ToString)
                    SW.WriteLine("---------------------------------------")
                End If
                oReader.Close()
                If CBool(OHelper.RecuperarParametro("AplicaDecretoEnRecibo")) Then
                    SW.WriteLine("ESTE RECIBO NO CONSTITUYE FACTURA")
                    SW.WriteLine("DECRETO 11.89  DE 1989")
                End If
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using
            LogCategorias.Clear()
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Impresora", impresora.Nombre)
            LogPropiedades.Agregar("Fecha", Now.ToString)
            POSstation.Fabrica.LogIt.Loguear("Antes de Imprimir", LogPropiedades, LogCategorias)

            OHelper.ActualizarVentaImpresa(recibo)
            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt", impresora.Nombre)
            OHelper.ActualizarVentaImpresa(CLng(recibo))
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Recibo" & recibo.ToString() & ".txt")

            LogCategorias.Clear()
            LogPropiedades.Clear()
            LogPropiedades.Agregar("Impresora", impresora.Nombre)
            LogPropiedades.Agregar("Fecha", Now.ToString)
            POSstation.Fabrica.LogIt.Loguear("Despues de Imprimir", LogPropiedades, LogCategorias)
            OVenta = Nothing
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirReciboRedencionBono(ByVal recibo As Double, ByVal impresora As ImpresoraEstacion, ByVal ClienteFidelizado As String, ByVal PuntosTarjeta As Decimal, ByVal FechaActualizacionPuntos As Date, Optional ByVal esVentaRegistrada As Boolean = True)
        Try
            Dim OVenta As InformacionRecibo
            Dim OHelper As New Helper
            Dim TotalPagar As Double = 0

            OVenta = RecuperarVenta(recibo, esVentaRegistrada)

            'SI LA VENTA YA FUE IMPRESA SE IMPRIME LA PALABRA COPIA
            If OVenta.EsImpresa Then
                impresora.ESCopia = True
            Else
                impresora.ESCopia = False
            End If

            Dim STexto As String = ""

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboRedencionBono" & recibo.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboRedencionBono" & recibo.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboRedencionBono" & recibo.ToString() & ".txt")

                SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OVenta.Nit))
                SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                SW.WriteLine(CentrarTexto(40, Now.ToString()))
                SW.WriteLine("---------------------------------------")

                SW.WriteLine(DobleColumna(22, "Fecha:    " & OVenta.Fecha, "Hora:" & OVenta.Hora.Trim))
                SW.WriteLine(DobleColumna(22, "Nro. :    " & OVenta.Numero, "Placa:" & OVenta.Placa.Trim))
                SW.WriteLine(DobleColumna(22, "Manguera: " & OVenta.Manguera.Trim, "Prox. Mant:" & OVenta.FechaProximaRevision))

                SW.WriteLine("---------------------------------------")


                SW.WriteLine("Articulo: " & OVenta.NombreArticulo)

                SW.WriteLine(DobleColumna(22, OVenta.UnidadMedida.ToString() & Space((9 - OVenta.UnidadMedida.ToString().Length)) & ":" & OVenta.Cantidad, "PVP: " & CDbl(OVenta.Precio).ToString("N0")))
                SW.WriteLine(DobleColumna(22, "Desc.($): " & IIf(CDbl(OVenta.Descuento) > 0, CDbl(OVenta.Descuento).ToString("N0"), "0"), ""))


                '------- APLICAR DESCUENTOS\INCREMENTOS POR CLIENTE\VEHICULO ---------
                If CDbl(OVenta.ValorCambioPrecio) <> 0 Then

                    If OVenta.EsDescuentoCliente Then
                        TotalPagar = CDbl(OVenta.Valor) - CDbl(OVenta.ValorCambioPrecio)
                    Else
                        TotalPagar = CDbl(OVenta.Valor) + CDbl(OVenta.ValorCambioPrecio)
                    End If
                Else
                    TotalPagar = CDbl(OVenta.Valor) - CDbl(OVenta.Descuento)
                End If
                '----------------------

                If CDbl(OVenta.Recaudo) > 0 Then
                    If CDbl(OVenta.ValorReversado) > 0 Then
                        TotalPagar = CDbl(CDbl(OVenta.Total) - CDbl(OVenta.ValorReversado)).ToString("N0")
                    Else
                        TotalPagar = CDbl(OVenta.Valor)
                    End If
                End If

                SW.WriteLine(DobleColumna(22, "Total($): " & TotalPagar.ToString("N0"), ""))


                SW.WriteLine(DobleColumnaNumerica("Forma Pago: ", "Valor ($)"))

                Dim VentasFormasPago As IDataReader = OHelper.RecuperarFormasPagoVenta(CLng(recibo))
                While VentasFormasPago.Read
                    SW.WriteLine(DobleColumnaNumerica(VentasFormasPago.Item(0).ToString & " : ", CDbl(VentasFormasPago.Item(1)).ToString("N0")))
                End While
                SW.WriteLine("---------------------------------------")

                SW.WriteLine("Fidelizado:")
                SW.WriteLine(ClienteFidelizado.ToString())
                SW.WriteLine(DobleColumna(22, "Puntos :  " & PuntosTarjeta.ToString("N0"), ""))
                SW.WriteLine(DobleColumnaNumerica("Fec. Act. Puntos: ", FechaActualizacionPuntos.ToString()))
                SW.WriteLine(" ")

                SW.WriteLine("Este documento es un comprobante de")
                SW.WriteLine("Fidelizacion. No constituye tiquete de")
                SW.WriteLine("venta.")

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboRedencionBono" & recibo.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboRedencionBono" & recibo.ToString() & ".txt")

            OHelper.ActualizarVentaImpresa(recibo)

            OVenta = Nothing
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionRecibos")
            Throw
        End Try
    End Sub

    Private Shared Function RecuperarVenta(ByVal recibo As Double, Optional ByVal esVentaRegistrada As Boolean = True) As InformacionRecibo
        Try
            Dim OHelper As New Helper
            Dim OInfoRecibo As New InformacionRecibo
            Dim DatosRecibo As IDataReader = OHelper.RecuperarVenta(CLng(recibo), esVentaRegistrada)

            If DatosRecibo.Read Then
                OInfoRecibo.NombreEstacion = DatosRecibo("NombreEstacion").ToString
                OInfoRecibo.Cedula = DatosRecibo("Cedula").ToString
                OInfoRecibo.Cantidad = DatosRecibo("Cantidad").ToString
                OInfoRecibo.Cara = DatosRecibo("Cara").ToString
                OInfoRecibo.Descuento = DatosRecibo("Descuento").ToString
                OInfoRecibo.Direccion = DatosRecibo("Direccion").ToString
                OInfoRecibo.Fecha = DatosRecibo("Fecha").ToString
                OInfoRecibo.FechaProximaRevision = DatosRecibo("FechaProximoMantenimiento").ToString
                OInfoRecibo.FormaPago = DatosRecibo("FormaPago").ToString
                OInfoRecibo.Hora = DatosRecibo("Hora").ToString
                OInfoRecibo.Isla = DatosRecibo("Isla").ToString
                OInfoRecibo.Manguera = DatosRecibo("Manguera").ToString
                OInfoRecibo.Nit = DatosRecibo("Nit").ToString
                OInfoRecibo.NombreArticulo = DatosRecibo("Producto").ToString
                OInfoRecibo.Placa = DatosRecibo("Placa").ToString
                OInfoRecibo.Numero = DatosRecibo("Recibo").ToString
                OInfoRecibo.Precio = DatosRecibo("Precio").ToString
                OInfoRecibo.Recaudo = DatosRecibo("AbonoCredito").ToString
                OInfoRecibo.Telefono = DatosRecibo("Telefono").ToString
                OInfoRecibo.Total = DatosRecibo("Total").ToString
                OInfoRecibo.Turno = DatosRecibo("NumeroTurno").ToString
                OInfoRecibo.Valor = DatosRecibo("valor").ToString
                OInfoRecibo.RecaudoOpcional = DatosRecibo("RecaudoOpcional").ToString
                OInfoRecibo.ValorReversado = DatosRecibo("ValorReversado").ToString
                OInfoRecibo.NombreEmpleado = DatosRecibo("Nombre").ToString
                OInfoRecibo.EsLecturaChipObligatoria = CBool(DatosRecibo("SolicitarLectura").ToString)
                OInfoRecibo.UnidadMedida = DatosRecibo("UnidadMedida").ToString
                OInfoRecibo.Ciudad = DatosRecibo("Ciudad").ToString
                OInfoRecibo.EsImpresa = DatosRecibo("EsImpresa").ToString
                OInfoRecibo.AtendidoPor = DatosRecibo("Atendido").ToString
                OInfoRecibo.EsCredito = DatosRecibo("EsCredito").ToString
                OInfoRecibo.CodigoVendedor = DatosRecibo("CodigoVendedor").ToString


                OInfoRecibo.ValorCambioPrecio = DatosRecibo("ValorCambioPrecio").ToString
                OInfoRecibo.PorcentajeClienteCredito = DatosRecibo("PorcentajeClienteCredito").ToString
                OInfoRecibo.EsDescuentoCliente = CBool(DatosRecibo("EsDescuentoCliente").ToString)



                If DatosRecibo("Kilometraje") Is System.DBNull.Value Then
                    OInfoRecibo.Kilometraje = ""
                Else
                    OInfoRecibo.Kilometraje = DatosRecibo("Kilometraje").ToString
                End If

                If DatosRecibo("Nivel") Is System.DBNull.Value Then
                    OInfoRecibo.Nivel = ""
                Else
                    OInfoRecibo.Nivel = DatosRecibo("Nivel").ToString
                End If

                OInfoRecibo.EsRecuperada = CBool(DatosRecibo("EsRecuperada").ToString())
                OInfoRecibo.NombreCliente = DatosRecibo("NombreCliente").ToString

                OInfoRecibo.NroAutorizacionCheque = DatosRecibo("NroAutorizacionCheque").ToString
                OInfoRecibo.ValorCheque = CDec(DatosRecibo("ValorCheque"))
                OInfoRecibo.NroCheque = DatosRecibo("NumeroCheque").ToString

                If Not DatosRecibo("SaldoCredito") Is System.DBNull.Value Then
                    OInfoRecibo.SaldoDisponible = CDec(DatosRecibo("SaldoCredito"))
                Else
                    OInfoRecibo.SaldoDisponible = 0
                End If

                OInfoRecibo.EsPrepago = CBool(DatosRecibo("EsPrepago").ToString())
                OInfoRecibo.SaldoTarjetaPrepago = (DatosRecibo("SaldoPrepago").ToString())
                OInfoRecibo.Tarjeta = (DatosRecibo("Tarjeta").ToString())
            End If
            DatosRecibo.Close()
            Return OInfoRecibo
        Catch
            Throw
        End Try
    End Function

    Public Shared Sub ImprimirFidelizacion(ByVal recibo As Double, ByVal impresora As ImpresoraEstacion, ByVal tarjeta As String)
        Dim OVenta As InformacionRecibo = Nothing


        Try

            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim ManejaSaldo As Boolean = False
            Dim TotalPagar As Double = 0

            OVenta = RecuperarVenta(CLng(recibo))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboFidelizacion" & recibo.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboFidelizacion" & recibo.ToString() & ".txt")
            End If


            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboFidelizacion" & recibo.ToString() & ".txt")

                Dim ODatosTarjeta As IDataReader = OHelper.RecuperarVentaFidelizada(CLng(recibo), True)

                If ODatosTarjeta.Read Then
                    ManejaSaldo = CBool(ODatosTarjeta.Item("ManejaSaldo"))
                    ODatosTarjeta.Close()
                    ODatosTarjeta = Nothing

                    If Not ManejaSaldo Then
                        Parrafo = SeccionarParrafo(OVenta.NombreEstacion)
                        For Each Linea As String In Parrafo
                            SW.WriteLine(CentrarTexto(40, Linea))
                        Next
                        Parrafo.Clear()
                        SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                        SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                        SW.WriteLine(CentrarTexto(40, Now.ToString("dd/MM/yyyy mm:hh:ss")))
                        SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))

                        SW.WriteLine("---------------------------------------")

                        SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Fecha, "Hora: " & OVenta.Hora.Trim))
                        SW.WriteLine(DobleColumna(22, "Nro. : " & OVenta.Numero, "Placa: " & OVenta.Placa.Trim))
                        SW.WriteLine(DobleColumna(22, "Manguera: " & OVenta.Manguera.Trim, "Prox. Mant: " & OVenta.FechaProximaRevision))

                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine("Articulo: " & OVenta.NombreArticulo)
                        SW.WriteLine(DobleColumna(22, "Cantidad: " & OVenta.Cantidad & " " & OVenta.UnidadMedida, "PVP: " & CDbl(OVenta.Precio).ToString("N0")))


                        '------- APLICAR DESCUENTOS\INCREMENTOS POR CLIENTE\VEHICULO ---------
                        If CDbl(OVenta.ValorCambioPrecio) <> 0 Then
                            If OVenta.EsDescuentoCliente Then
                                TotalPagar = CDbl(OVenta.Valor) - CDbl(OVenta.ValorCambioPrecio)
                            Else
                                TotalPagar = CDbl(OVenta.Valor) + CDbl(OVenta.ValorCambioPrecio)
                            End If
                        Else
                            TotalPagar = CDbl(OVenta.Valor) - CDbl(OVenta.Descuento)
                        End If


                        If CDbl(OVenta.Recaudo) > 0 Then
                            If CDbl(OVenta.ValorReversado) > 0 Then
                                TotalPagar = CDbl(CDbl(OVenta.Total) - CDbl(OVenta.ValorReversado)).ToString("N0")
                            Else
                                TotalPagar = CDbl(OVenta.Valor)
                            End If
                        End If


                        SW.WriteLine(DobleColumnaNumerica("Descuento: ", CDbl(OVenta.Descuento).ToString("N0")))
                        SW.WriteLine(DobleColumnaNumerica("Total: ", TotalPagar.ToString("N0")))


                        SW.WriteLine(DobleColumnaNumerica("Forma Pago: ", "Valor ($)"))
                        Dim VentasFormasPago As IDataReader = OHelper.RecuperarFormasPagoVenta(CLng(recibo))
                        While VentasFormasPago.Read
                            SW.WriteLine(DobleColumnaNumerica(VentasFormasPago.Item(0).ToString & " : ", CDbl(VentasFormasPago.Item(1)).ToString("N0")))
                        End While
                        SW.WriteLine("---------------------------------------")


                        Dim ODataSet As DataSet = Nothing
                        Dim CodEstacion As String
                        Dim ORespuesta As POSstation.Fabrica.Fidelizacion
                        Dim ClienteFidelizado As String = ""
                        Dim PuntosTarjeta As Decimal = 0
                        Dim FechaActualizacionPuntos As DateTime = Now
                        Dim Mensaje As String = ""
                        Dim HayComunicacion As Boolean = False


                        ODataSet = OHelper.RecuperarCodEstacion()
                        CodEstacion = ODataSet.Tables(0).Rows(0).Item("Codigo").ToString()
                        ODataSet = Nothing

                        'Consulto saldo de tarjeta para recuperar los datos que se deben enviar al sp RecuperarReciboFidelizacion
                        Try
                            ORespuesta = POSstation.ServerServices.ServicioFidelizacion.ConsultarSaldoTajetaFidelizacion(tarjeta)
                            If Not ORespuesta.Saldos Is Nothing Then
                                HayComunicacion = True
                                ClienteFidelizado = ORespuesta.Saldos.Tables(0).Rows(0).Item("Conductor").ToString()
                                PuntosTarjeta = ORespuesta.Saldos.Tables(0).Rows(0).Item("Saldo").ToString()
                                FechaActualizacionPuntos = ORespuesta.Saldos.Tables(0).Rows(0).Item("Fecha").ToString()
                                ORespuesta.Saldos = Nothing

                                SW.WriteLine("Fidelizado:")
                                SW.WriteLine(ClienteFidelizado)
                                SW.WriteLine("Puntos: " & PuntosTarjeta.ToString("N2"))
                                SW.WriteLine("Fec. Act. Puntos: " & FechaActualizacionPuntos.ToString("dd/MM/yyyy mm:hh:ss"))


                                If Not ORespuesta.MensajesCliente Is Nothing Then
                                    If ORespuesta.MensajesCliente.Tables.Count > 0 Then
                                        If ORespuesta.MensajesCliente.Tables(0).Rows.Count > 0 Then
                                            For Each row As DataRow In ORespuesta.MensajesCliente.Tables(0).Rows
                                                Mensaje = row.Item("MensajeDia").ToString()
                                                Parrafo = SeccionarParrafo(Mensaje)
                                                For Each Linea As String In Parrafo
                                                    SW.WriteLine(Linea)
                                                Next
                                                Parrafo.Clear()
                                            Next
                                            ORespuesta.MensajesCliente = Nothing
                                        End If
                                    End If
                                End If
                            Else
                                HayComunicacion = False
                            End If
                        Catch ex As System.Exception
                            HayComunicacion = False
                        End Try


                        If Not HayComunicacion Then
                            SW.WriteLine("EN ESTOS MOMENTOS NO HAY COMUNICACION")
                            SW.WriteLine("CON SOY LEAL. LOS PUNTOS SE ACUMULARAN")
                            SW.WriteLine("APENAS SE RESTABLEZCA LA COMUNICACION.")
                        End If

                        SW.WriteLine("Este documento es un comprobante de")
                        SW.WriteLine("Fidelizacion. No constituye tiquete de")
                        SW.WriteLine("venta")
                    Else
                        Dim DatosConductor As IDataReader = OHelper.RecuperarConductorPorTarjeta(tarjeta)
                        Dim Puntos As Long = OHelper.RecuperarPuntosDisponiblesPorCampaña(-1, tarjeta)
                        If DatosConductor.Read Then
                            SW.WriteLine("***************************************")
                            SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                            SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                            SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                            SW.WriteLine(CentrarTexto(40, OVenta.Fecha))
                            SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))
                            SW.WriteLine("***************************************")
                            SW.WriteLine(CentrarTexto(40, "PUNTOS ACUMULADOS"))
                            SW.WriteLine("***************************************")
                            SW.WriteLine(CentrarTexto(40, "FELICIDADES"))
                            SW.WriteLine(CentrarTexto(40, "Tanquea y Acumula Puntos"))
                            SW.WriteLine(CentrarTexto(40, "Gana Premios con Nosotros"))
                            SW.WriteLine(" ")
                            SW.WriteLine("Cliente: " & DatosConductor.Item("Nombre").ToString)
                            SW.WriteLine("Recibo: " & recibo.ToString)
                            SW.WriteLine("Tarjeta: " & tarjeta)
                            SW.WriteLine("Puntos Acumulados: " & Math.Floor(CDec(OVenta.Cantidad)))
                            SW.WriteLine("TOTAL PUNTOS ACUMULADOS: " & Puntos.ToString)
                            SW.WriteLine("***************************************")
                        End If
                        DatosConductor.Close()
                        DatosConductor.Dispose()
                    End If
                Else
                    ODatosTarjeta.Close()
                    ODatosTarjeta = Nothing
                End If

                'If ODatosTarjeta.Read Then
                '    ManejaSaldo = CBool(ODatosTarjeta.Item("ManejaSaldo"))
                '    ODatosTarjeta.Close()
                '    ODatosTarjeta = Nothing

                '    If Not ManejaSaldo Then
                '        SW.WriteLine(" ")
                '        SW.WriteLine("***************************************")
                '        'SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                '        Parrafo = SeccionarParrafo(OVenta.NombreEstacion)
                '        For Each Linea As String In Parrafo
                '            SW.WriteLine(CentrarTexto(40, Linea))
                '        Next
                '        Parrafo.Clear()

                '        SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                '        SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                '        SW.WriteLine(CentrarTexto(40, OVenta.Fecha))
                '        SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))
                '        SW.WriteLine("***************************************")
                '        SW.WriteLine(CentrarTexto(40, "FELICIDADES"))
                '        SW.WriteLine(CentrarTexto(40, "Tanquea y Acumula Puntos"))
                '        SW.WriteLine(CentrarTexto(40, "Gana Premios con Nosotros"))
                '        SW.WriteLine(" ")
                '        SW.WriteLine("Tarjeta Fidelizada: " & tarjeta)
                '        SW.WriteLine("***************************************")
                '    Else
                '        Dim DatosConductor As IDataReader = OHelper.RecuperarConductorPorTarjeta(tarjeta)
                '        Dim Puntos As Long = OHelper.RecuperarPuntosDisponiblesPorCampaña(-1, tarjeta)
                '        If DatosConductor.Read Then
                '            SW.WriteLine("***************************************")
                '            SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                '            SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                '            SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                '            SW.WriteLine(CentrarTexto(40, OVenta.Fecha))
                '            SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))
                '            SW.WriteLine("***************************************")
                '            SW.WriteLine(CentrarTexto(40, "PUNTOS ACUMULADOS"))
                '            SW.WriteLine("***************************************")
                '            SW.WriteLine(CentrarTexto(40, "FELICIDADES"))
                '            SW.WriteLine(CentrarTexto(40, "Tanquea y Acumula Puntos"))
                '            SW.WriteLine(CentrarTexto(40, "Gana Premios con Nosotros"))
                '            SW.WriteLine(" ")
                '            SW.WriteLine("Cliente: " & DatosConductor.Item("Nombre").ToString)
                '            SW.WriteLine("Recibo: " & recibo.ToString)
                '            SW.WriteLine("Tarjeta: " & tarjeta)
                '            SW.WriteLine("Puntos Acumulados: " & Math.Floor(CDec(OVenta.Cantidad)))
                '            SW.WriteLine("TOTAL PUNTOS ACUMULADOS: " & Puntos.ToString)
                '            SW.WriteLine("***************************************")
                '        End If
                '        DatosConductor.Close()
                '        DatosConductor.Dispose()
                '    End If
                'Else
                '    ODatosTarjeta.Close()
                '    ODatosTarjeta = Nothing
                'End If




                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
                SW.Dispose()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboFidelizacion" & recibo.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboFidelizacion" & recibo.ToString() & ".txt")

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
            Throw
        Finally
        End Try
    End Sub

    'Public Shared Sub ImprimirSaldoTarjetaFidelizacion(ByVal Datos As DataSet, ByVal impresora As ImpresoraEstacion, ByVal tarjeta As String)
    '    Dim OVenta As InformacionRecibo = Nothing

    '    Try

    '        Dim OHelper As New Helper
    '        Dim Parrafo As List(Of String)
    '        Dim ManejaSaldo As Boolean = False

    '        Dim Fecha As String = Now.ToString("yyyyMMddHHmmss")

    '        If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
    '            My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
    '        End If
    '        If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt") Then
    '            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt")
    '        End If


    '        Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt")


    '            'Recupero el encabezado
    '            Dim OEncabezado As InformacionEncabezado
    '            OEncabezado = RecuperarEncabezado()

    '            'SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
    '            Parrafo = SeccionarParrafo(OEncabezado.NombreEstacion)
    '            For Each Linea As String In Parrafo
    '                SW.WriteLine(CentrarTexto(40, Linea))
    '            Next
    '            Parrafo.Clear()

    '            SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
    '            SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
    '            SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
    '            SW.WriteLine(CentrarTexto(40, Now.ToString("dd/MM/yyyy HH:mm:ss")))
    '            SW.WriteLine(" ")

    '            SW.WriteLine("***************************************")
    '            SW.WriteLine(CentrarTexto(40, "FELICIDADES"))
    '            SW.WriteLine(CentrarTexto(40, "Tanquea y Acumula Puntos"))
    '            SW.WriteLine(CentrarTexto(40, "Gana Premios con Nosotros"))
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine("TARJETA FIDELIZADA: " & tarjeta)
    '            SW.WriteLine("---------------------------------------")
    '            If Datos Is Nothing Then
    '                SW.WriteLine(CentrarTexto(40, "INFORMACION DE TARJETA NO DISPONIBLE"))
    '            Else
    '                If Datos.Tables.Count > 0 Then
    '                    For Each Registro As DataRow In Datos.Tables(0).Rows
    '                        Parrafo = SeccionarParrafo(Registro.Item("Campaña").ToString)
    '                        For Each Linea As String In Parrafo
    '                            SW.WriteLine(Linea)
    '                        Next
    '                        Parrafo.Clear()
    '                        SW.WriteLine("Puntos Acumulados: " & CLng(Registro.Item("Saldo")).ToString())
    '                        SW.WriteLine("---------------------------------------")
    '                    Next
    '                Else
    '                    SW.WriteLine(CentrarTexto(40, "INFORMACION DE TARJETA NO DISPONIBLE"))
    '                End If
    '            End If

    '            SW.WriteLine("***************************************")


    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(" ")
    '            SW.WriteLine(".")
    '            SW.Close()
    '            SW.Dispose()
    '        End Using

    '        AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt", impresora.Nombre)
    '        File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt")

    '    Catch ex As Data.DataException
    '        LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
    '    Catch ex As Data.SqlClient.SqlException
    '        LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
    '    Catch ex As IO.IOException
    '        LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
    '    Catch ex As System.exception
    '        LogFallas.ReportarError(ex, "ImprimirReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
    '        Throw
    '    Finally
    '        If Not OVenta Is Nothing Then
    '            OVenta.Dispose()
    '        End If
    '    End Try
    'End Sub
    Public Shared Sub ImprimirSaldoTarjetaFidelizacion(ByVal Datos As DataSet, ByVal MensajesFidelizacion As DataSet, ByVal RespuestaFidelizacion As String, ByVal tarjeta As String, ByVal impresora As ImpresoraEstacion)
        Dim OVenta As InformacionRecibo = Nothing

        Try

            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim ManejaSaldo As Boolean = False
            Dim Mensaje As String = String.Empty
            Dim Fecha As String = Now.ToString("yyyyMMddHHmmss")
            Dim FechaVencimiento As String = String.Empty
            Dim Aplica As Boolean = False
            tarjeta = OHelper.ValidarNumeroTarjeta(tarjeta)

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt")
            End If


            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt")

                'Recupero el encabezado
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                Parrafo = SeccionarParrafo(OEncabezado.NombreEstacion)
                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, Linea))
                Next
                Parrafo.Clear()

                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine(CentrarTexto(40, Now.ToString("dd/MM/yyyy HH:mm:ss")))
                SW.WriteLine(" ")

                SW.WriteLine("***************************************")
                SW.WriteLine(CentrarTexto(40, "FELICIDADES"))
                SW.WriteLine(CentrarTexto(40, "Tanquea y Acumula Puntos"))
                SW.WriteLine(CentrarTexto(40, "Gana Premios con Nosotros"))
                SW.WriteLine(" ")
                SW.WriteLine(" ")



                SW.WriteLine("TARJETA FIDELIZADA: " & tarjeta)
                SW.WriteLine("---------------------------------------")
                If Datos Is Nothing Then
                    If String.IsNullOrEmpty(RespuestaFidelizacion) Then
                        SW.WriteLine(CentrarTexto(40, "INFORMACION DE TARJETA NO DISPONIBLE"))
                    Else
                        Parrafo = SeccionarParrafo(RespuestaFidelizacion)
                        For Each Linea As String In Parrafo
                            SW.WriteLine(CentrarTexto(40, Linea))
                        Next
                        Parrafo.Clear()
                    End If
                Else
                    If Datos.Tables.Count > 0 Then
                        'Nombre del cliente
                        SW.WriteLine(Datos.Tables(0).Rows(0).Item("Conductor").ToString.ToUpper)
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(CentrarTexto(40, "INFORMACION DE PUNTOS"))
                        SW.WriteLine("---------------------------------------")
                        For Each Registro As DataRow In Datos.Tables(0).Rows
                            Parrafo = SeccionarParrafo(Registro.Item("Campaña").ToString)
                            For Each Linea As String In Parrafo
                                SW.WriteLine(Linea)
                            Next
                            Parrafo.Clear()
                            SW.WriteLine(" ")
                            SW.WriteLine("Puntos Acumulados: " & Registro.Item("Saldo").ToString())
                            SW.WriteLine("Hasta la Fecha: " & Registro.Item("Fecha").ToString())

                            If CLng(Registro.Item("PuntosVencimiento").ToString()) > 0 Then
                                SW.WriteLine(" ")
                                SW.WriteLine("***************************************")
                                SW.WriteLine("PUNTOS PROXIMOS A VENCER: " & Registro.Item("PuntosVencimiento").ToString())
                                If Not Registro.Item("FechaVencimiento") Is System.DBNull.Value Then
                                    SW.WriteLine("FECHA VENCIMIENTO PUNTOS: " & Registro.Item("FechaVencimiento").ToString())
                                End If
                                SW.WriteLine("***************************************")
                            End If

                            SW.WriteLine("---------------------------------------")
                        Next
                    Else
                        SW.WriteLine(CentrarTexto(40, "INFORMACION DE TARJETA NO DISPONIBLE"))
                    End If
                End If


                If Not MensajesFidelizacion Is Nothing Then
                    If MensajesFidelizacion.Tables.Count > 0 Then
                        SW.WriteLine(" ")
                        SW.WriteLine(" ")

                        For Each Registro As DataRow In MensajesFidelizacion.Tables(0).Rows
                            SW.WriteLine("***************************************")
                            Parrafo = SeccionarParrafo(Registro.Item("MensajeDia").ToString())
                            For Each Linea As String In Parrafo
                                SW.WriteLine(Linea)
                            Next
                            Parrafo.Clear()
                        Next

                        SW.WriteLine("***************************************")


                    End If



                End If



                'SW.WriteLine(" ")
                'SW.WriteLine(" ")
                'SW.WriteLine(" ")
                'SW.WriteLine(" ")
                'SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
                SW.Dispose()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\SaldoFidelizacion" & tarjeta & Fecha & ".txt")

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboFidelizacion", "ReciboFidelizacion: " & ", Impresora: " & impresora.Nombre & ", Puerto: " & impresora.Puerto, "ImpresionFidelizacion")
            Throw ex
        Finally

        End Try
    End Sub

    Private Shared Function RecuperarEncabezado() As InformacionEncabezado
        Dim oHelper As New Helper
        Dim oInfo As New InformacionEncabezado

        Try
            Dim Datos As IDataReader = oHelper.RecuperarEncabezadoReporte()
            If Datos.Read Then
                oInfo.NombreEstacion = Datos("NombreEstacion").ToString
                oInfo.Direccion = Datos("Direccion").ToString
                oInfo.Nit = Datos("Nit").ToString
                oInfo.Telefono = Datos("Telefono").ToString
            End If
            Datos.Close()
            Datos.Dispose()
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "RecuperarEncabezado", "-", "ImpresionGeneral")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarEncabezado", "-", "ImpresionGeneral")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "RecuperarEncabezado", "-", "ImpresionGeneral")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "RecuperarEncabezado", "-", "ImpresionGeneral")
            Throw
        End Try
        Return oInfo
    End Function

#Region "Impresiones de funcionalidad de inventarios"
    Public Shared Sub ImprimirInformeReciboCombustible(ByVal documento As String, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEstacion As InformacionEstacion
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim ODatos, ODatosDetalle, ODatosProductos As IDataReader

            OEstacion = OHelper.RecuperarDatosEstacion()

            'Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt")


                Parrafo = SeccionarParrafo(OEstacion.Nombre)

                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, OEstacion.Nombre))
                Next

                Parrafo.Clear()
                SW.WriteLine(CentrarTexto(40, OEstacion.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("=======================================")
                SW.WriteLine(CentrarTexto(40, "INFORME RECIBO COMBUSTIBLE"))
                SW.WriteLine("=======================================")

                ODatos = OHelper.RecuperarInformacionReciboCombustible(documento)
                While ODatos.Read()
                    SW.WriteLine(FormatoImpresora.DobleColumna(22, "Fecha: " & CDate(ODatos.Item("FechaHora")).ToString("dd/MM/yyyy"), "Hora: " & CDate(ODatos.Item("FechaHora")).ToString("HH:mm")))
                    SW.WriteLine(FormatoImpresora.DobleColumna(22, "Placa: " & ODatos.Item("Placa").ToString(), "Documento: " & documento))

                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, "DETALLE"))
                    SW.WriteLine("---------------------------------------")

                    ODatosProductos = OHelper.RecuperarProductosReciboCombustible(documento)
                    While ODatosProductos.Read()
                        SW.WriteLine(CentrarTexto(40, ODatosProductos.Item("Producto").ToString()))

                        ODatosDetalle = OHelper.RecuperarInformacionDetalleReciboCombustible(documento, CInt(ODatosProductos.Item("IdProducto").ToString()))
                        While ODatosDetalle.Read()
                            SW.WriteLine("Tanque: " & ODatosDetalle.Item("Tanque").ToString())
                            SW.WriteLine("Cant. Documento: " & ODatosDetalle.Item("CantidadDocumento").ToString())
                            SW.WriteLine("Cant. Recibida: " & ODatosDetalle.Item("CantidadRecibida").ToString())
                            SW.WriteLine("Dif. en recibo: " & ODatosDetalle.Item("CantidadDiferencia").ToString())
                            SW.WriteLine("---------------------------------------")
                        End While
                        ODatosDetalle.Close()
                        ODatosDetalle = Nothing

                    End While
                    ODatosProductos.Close()
                    ODatosProductos = Nothing

                    Parrafo = SeccionarParrafo(ODatos.Item("EstadoDocumento").ToString())
                    For Each Linea As String In Parrafo
                        SW.WriteLine(Linea)
                        'SW.WriteLine(CentrarTexto(40, Linea))
                    Next
                    Parrafo.Clear()
                End While
                ODatos.Close()
                ODatos = Nothing

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
            Throw
        End Try

    End Sub

    Public Shared Sub ImprimirInformeReciboCombustible(ByVal documento As String, ByVal Cantidad As Double, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEstacion As InformacionEstacion
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim ODatos, ODatosDetalle, ODatosProductos As IDataReader

            OEstacion = OHelper.RecuperarDatosEstacion()

            'Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt")


                Parrafo = SeccionarParrafo(OEstacion.Nombre)

                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, OEstacion.Nombre))
                Next

                Parrafo.Clear()
                SW.WriteLine(CentrarTexto(40, OEstacion.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("=======================================")
                SW.WriteLine(CentrarTexto(40, "INFORME RECIBO COMBUSTIBLE"))
                SW.WriteLine("=======================================")

                ODatos = OHelper.RecuperarInformacionReciboCombustible(documento)
                While ODatos.Read()
                    SW.WriteLine(FormatoImpresora.DobleColumna(22, "Fecha: " & CDate(ODatos.Item("FechaHora")).ToString("dd/MM/yyyy"), "Hora: " & CDate(ODatos.Item("FechaHora")).ToString("HH:mm")))
                    SW.WriteLine(FormatoImpresora.DobleColumna(22, "Placa: " & ODatos.Item("Placa").ToString(), "Documento: " & documento))

                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, "DETALLE"))
                    SW.WriteLine("---------------------------------------")

                    ODatosProductos = OHelper.RecuperarProductosReciboCombustible(documento)
                    While ODatosProductos.Read()
                        SW.WriteLine(CentrarTexto(40, ODatosProductos.Item("Producto").ToString()))

                        ODatosDetalle = OHelper.RecuperarInformacionDetalleReciboCombustible(documento, CInt(ODatosProductos.Item("IdProducto").ToString()))
                        While ODatosDetalle.Read()
                            SW.WriteLine("Tanque: " & ODatosDetalle.Item("Tanque").ToString())
                            SW.WriteLine("Cant. Documento: " & ODatosDetalle.Item("CantidadDocumento").ToString())
                            SW.WriteLine("Cant. Recibida: " & ODatosDetalle.Item("CantidadRecibida").ToString())
                            'SW.WriteLine("Dif. en recibo: " & ODatosDetalle.Item("CantidadDiferencia").ToString())
                            'SW.WriteLine("---------------------------------------")
                        End While
                        ODatosDetalle.Close()
                        ODatosDetalle = Nothing

                    End While
                    SW.WriteLine("Dif. por Ventas: " & Cantidad.ToString())
                    SW.WriteLine("---------------------------------------")
                    ODatosProductos.Close()
                    ODatosProductos = Nothing

                    Parrafo = SeccionarParrafo(ODatos.Item("EstadoDocumento").ToString())
                    For Each Linea As String In Parrafo
                        SW.WriteLine(Linea)
                        'SW.WriteLine(CentrarTexto(40, Linea))
                    Next
                    Parrafo.Clear()
                End While
                ODatos.Close()
                ODatos = Nothing

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCombustible" & documento & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirInformeReciboCombustible", "Documento: " & documento, "ImprimirInformeReciboCombustible")
            Throw
        End Try

    End Sub

    Public Shared Sub ImprimirReciboTraslado(ByVal codTanque As String, ByVal cantidad As Decimal, ByVal entidadReceptora As String, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEncabezado As InformacionEncabezado
            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            OEncabezado = RecuperarEncabezado()

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt")
                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))

                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "RECIBO TRASLADO"))
                SW.WriteLine("---------------------------------------")

                SW.WriteLine("Tanque: " & codTanque)
                SW.WriteLine("Entidad: " & entidadReceptora)
                SW.WriteLine("Cantidad: " & cantidad)

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirReciboRemarcacion(ByVal codTanque As String, ByVal producto As String, ByVal cantidad As Decimal, ByVal codTanqueRemarcado As String, ByVal productoRemarcado As String, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEncabezado As InformacionEncabezado
            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            OEncabezado = RecuperarEncabezado()

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt")
                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))

                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "RECIBO REMARCACION"))
                SW.WriteLine("---------------------------------------")

                SW.WriteLine("Tanque Baja: " & codTanque)
                SW.WriteLine("Producto Baja: " & producto)
                SW.WriteLine("Cantidad: " & cantidad.ToString("N2"))
                SW.WriteLine("Tanque Alta: " & codTanqueRemarcado)
                SW.WriteLine("Producto Alta: " & productoRemarcado)

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codTanque & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codTanque, "ImpresionRecibos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirReciboRemarcacionCanastilla(ByVal codBaja As String, ByVal productoBaja As String, ByVal Cantidad As Double, ByVal codAlta As String, ByVal productoAlta As String, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEncabezado As InformacionEncabezado
            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            OEncabezado = RecuperarEncabezado()

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codBaja & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codBaja & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codBaja & ".txt")
                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))

                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "RECIBO REMARCACION"))
                SW.WriteLine("---------------------------------------")

                SW.WriteLine("Producto Baja: " & productoBaja)
                SW.WriteLine("Cod Producto Baja: " & codBaja)
                SW.WriteLine("Cantidad: " & CStr(Cantidad))
                SW.WriteLine("Producto Alta: " & productoAlta)
                SW.WriteLine("Cod Producto Alta: " & codAlta)

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codBaja & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Traslado" & codBaja & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codBaja, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codBaja, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codBaja, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTraslado", "ReciboTraslado: " & codBaja, "ImpresionRecibos")
            Throw
        End Try
    End Sub

#End Region

#Region "Impresiones de funcionalidad de ventas fuera del sistema"
    Public Shared Sub ImprimirReciboManguerasBloqueadas(ByVal lstMangueras As List(Of Manguera), ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEncabezado As InformacionEncabezado
            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            OEncabezado = RecuperarEncabezado()

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ManguerasBloqueadas" & impresora.Nombre & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ManguerasBloqueadas" & impresora.Nombre & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ManguerasBloqueadas" & impresora.Nombre & ".txt")
                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))

                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "CONSULTA MANGUERAS BLOQUEADAS"))
                SW.WriteLine("---------------------------------------")

                For Each OManguera As Manguera In lstMangueras

                    SW.WriteLine(OManguera.Descripcion)

                Next

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ManguerasBloqueadas" & impresora.Nombre & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ManguerasBloqueadas" & impresora.Nombre & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirReciboManguerasBloqueadas", "ReciboManguerasBloqueadas: " & impresora.Nombre, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirReciboManguerasBloqueadas", "ReciboManguerasBloqueadas: " & impresora.Nombre, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirReciboManguerasBloqueadas", "ReciboManguerasBloqueadas: " & impresora.Nombre, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirReciboManguerasBloqueadas", "ReciboManguerasBloqueadas: " & impresora.Nombre, "ImpresionRecibos")
            Throw
        End Try
    End Sub
#End Region

#Region "Impresiones de funcionalidad de calibraciones"
    Public Shared Sub ImprimirReciboCalibracion(ByVal IdCalibracion As Int32, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OCalibracion As IDataReader

            Dim OHelper As New Helper
            OCalibracion = OHelper.RecuperarCalibracion(IdCalibracion)


            If OCalibracion.Read Then
                Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
                End If
                If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Calibracion" & IdCalibracion.ToString() & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Calibracion" & IdCalibracion.ToString() & ".txt")
                End If

                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Calibracion" & IdCalibracion.ToString() & ".txt")
                    SW.WriteLine(CentrarTexto(40, OCalibracion.Item("NombreEstacion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OCalibracion.Item("Nit").ToString()))

                    SW.WriteLine(CentrarTexto(40, OCalibracion.Item("Direccion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OCalibracion.Item("Telefono").ToString()))
                    SW.WriteLine("---------------------------------------")

                    If Not String.IsNullOrEmpty(STexto) Then
                        SW.WriteLine(CentrarTexto(40, STexto))
                        SW.WriteLine("---------------------------------------")
                    End If

                    SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Parse(OCalibracion.Item("Fecha").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OCalibracion.Item("Fecha").ToString()).ToString("HH:mm")))

                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, "RECIBO CALIBRACION"))
                    SW.WriteLine("---------------------------------------")

                    SW.WriteLine("Tanque: " & OCalibracion.Item("Tanque").ToString)
                    SW.WriteLine("Manguera: " & OCalibracion.Item("Manguera").ToString)
                    SW.WriteLine("Producto: " & OCalibracion.Item("Producto").ToString)
                    SW.WriteLine("Turno: " & OCalibracion.Item("Turno").ToString)
                    SW.WriteLine("Cantidad: " & OCalibracion.Item("Cantidad").ToString)
                    SW.WriteLine("Valor: " & OCalibracion.Item("Valor").ToString)

                    If Not String.IsNullOrEmpty(OCalibracion.Item("Motivo").ToString) Then
                        SW.WriteLine("Motivo: " & OCalibracion.Item("Motivo").ToString)
                    End If

                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(" ")
                    SW.WriteLine(".")
                    SW.Close()
                End Using

                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Calibracion" & IdCalibracion.ToString() & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Calibracion" & IdCalibracion.ToString() & ".txt")
            End If

            OCalibracion.Close()
            OCalibracion.Dispose()
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirCalibracion", "ReciboCalibracion: " & IdCalibracion.ToString, "ImpresionRecibos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirCalibracion", "ReciboCalibracion: " & IdCalibracion.ToString, "ImpresionRecibos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirCalibracion", "ReciboCalibracion: " & IdCalibracion.ToString, "ImpresionRecibos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirCalibracion", "ReciboCalibracion: " & IdCalibracion.ToString, "ImpresionRecibos")
            Throw
        End Try
    End Sub
#End Region

#Region "Impresiones de funcionalidad de consignacion de sobres"
    Public Shared Sub ImprimirConsignacionCombustible(ByVal Turno As Int64, ByVal oSobre As DataTable, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEstacion As InformacionEstacion
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)


            OEstacion = OHelper.RecuperarDatosEstacion()

            'Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & Turno.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & Turno.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & Turno.ToString() & ".txt")


                Parrafo = SeccionarParrafo(OEstacion.Nombre)

                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, OEstacion.Nombre))
                Next

                Parrafo.Clear()
                SW.WriteLine(CentrarTexto(40, OEstacion.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Telefono))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "CONSIGNACION DE SOBRES"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))
                SW.WriteLine("---------------------------------------")
                For Each Sobre As DataRow In oSobre.Rows
                    If Sobre.Item("Surtidores").ToString().Length > 1 Then
                        SW.WriteLine("Islero: " & Sobre.Item("NombreEmpleado").ToString())
                    Else
                        SW.WriteLine("Empleado: " & Sobre.Item("NombreEmpleado").ToString())
                    End If
                    SW.WriteLine("Fecha:  " & Sobre.Item("Fecha").ToString())
                    SW.WriteLine("Hora:   " & Sobre.Item("Hora").ToString())
                    SW.WriteLine("Sobres Acumulados: " & CDec(Sobre.Item("SobresAcumulados").ToString()).ToString("N0"))
                    If Sobre.Item("IdTipoConsignacion").ToString() = "0" Then
                        SW.WriteLine("Valor Variable: " & Sobre.Item("ValorSobre").ToString())
                    Else
                        SW.WriteLine("Sobres Consignados: " & Sobre.Item("Cantidad").ToString())
                    End If


                    If Sobre.Item("Surtidores").ToString().Length > 1 Then
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(CentrarTexto(40, "SURTIDORES ASOCIADOS"))
                        SW.WriteLine("---------------------------------------")
                        For Each oItem As String In Sobre.Item("Surtidores").ToString().Split(CChar(","))
                            SW.WriteLine(oItem)
                        Next
                    End If
                Next
                SW.WriteLine("---------------------------------------")

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using


            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & Turno.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & Turno.ToString() & ".txt")

            oSobre = Nothing
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirConsignacionCombustible", "Turno: " & Turno.ToString(), "ImprimirConsignacionCombustible")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirConsignacionCombustible", "Turno: " & Turno.ToString(), "ImprimirConsignacionCombustible")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirConsignacionCombustible", "Turno: " & Turno.ToString(), "ImprimirConsignacionCombustible")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirConsignacionCombustible", "Turno: " & Turno.ToString(), "ImprimirConsignacionCombustible")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirCierreSobresTurno(ByVal IdTurno As Int64, ByVal IdTipoTurno As Int16, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OEstacion As InformacionEstacion
            Dim OHelper As New Helper
            Dim Parrafo As List(Of String)
            Dim ODatos As IDataReader

            OEstacion = OHelper.RecuperarDatosEstacion()

            'Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & IdTurno.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & IdTurno.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & IdTurno.ToString() & ".txt")


                Parrafo = SeccionarParrafo(OEstacion.Nombre)

                For Each Linea As String In Parrafo
                    SW.WriteLine(CentrarTexto(40, OEstacion.Nombre))
                Next

                Parrafo.Clear()
                SW.WriteLine(CentrarTexto(40, OEstacion.Nit))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Telefono))
                SW.WriteLine(" ")
                Dim dtEmpleado As DataTable = OHelper.RecuperarEmpleadoPorTurno(IdTurno, IdTipoTurno)

                SW.WriteLine("---------------------------------------")
                For Each iEmpleado As DataRow In dtEmpleado.Rows
                    SW.WriteLine("Empleado:")
                    SW.WriteLine(iEmpleado.Item("Nombre").ToString())
                Next
                dtEmpleado.Clear() : dtEmpleado = Nothing
                SW.WriteLine(" ")
                SW.WriteLine("=======================================")
                SW.WriteLine(CentrarTexto(40, "CIERRE DE CONSIGNACIONES EN TURNO"))
                SW.WriteLine("=======================================")
                SW.WriteLine(DobleColumna(22, "Fecha: " & Date.Now.ToString("dd/MM/yyyy"), "Hora: " & Date.Now.ToString("HH:mm")))
                SW.WriteLine("---------------------------------------")
                '--> SECCION DE IMPRESION DE CONSIGNACION DE SOBRES
                Try
                    Dim oTable As DataTable = OHelper.RecuperarConsignaciondeSobresTurno(IdTurno, IdTipoTurno)
                    If oTable.Rows.Count > 0 Then
                        For Each oDataRow As DataRow In oTable.Rows
                            SW.WriteLine("Numero de Sobres: " & oDataRow.Item("NumeroSobres").ToString())
                            SW.WriteLine("Valor Consignaciones: " & oDataRow.Item("ValorSobres").ToString())
                            SW.WriteLine("Valor Variable: " & oDataRow.Item("ValorPicos").ToString())
                        Next
                    End If
                    oTable.Clear()
                    oTable = Nothing

                    ODatos = OHelper.RecuperarSobranteFaltanteTurno(CInt(IdTurno), IdTipoTurno)
                    If (ODatos.Read()) Then
                        If CDec(ODatos.Item("Valor").ToString()) > 0 Then
                            If CBool(ODatos.Item("EsSobrante")) Then
                                SW.WriteLine(" ")
                                SW.WriteLine("---------------------------------------")
                                SW.WriteLine("VALOR SOBRANTE: " & ODatos.Item("Valor").ToString())
                            Else
                                SW.WriteLine(" ")
                                SW.WriteLine("---------------------------------------")
                                SW.WriteLine("VALOR FALTANTE: " & ODatos.Item("Valor").ToString())
                            End If
                        End If
                    End If
                    ODatos.Close()
                    ODatos = Nothing
                    SW.WriteLine("---------------------------------------")

                Catch ex As System.Exception
                    LogFallas.ReportarError(ex, "RecuperarConsignaciondeSobresTurno", "Turno: " & IdTurno.ToString, "ImpresionTurnos")
                End Try

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using


            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & IdTurno.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\Consignacion" & IdTurno.ToString() & ".txt")

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirCierreSobresTurno", "Turno: " & IdTurno.ToString(), "ImprimirCierreSobresTurno")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirCierreSobresTurno", "Turno: " & IdTurno.ToString(), "ImprimirCierreSobresTurno")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirCierreSobresTurno", "Turno: " & IdTurno.ToString(), "ImprimirCierreSobresTurno")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirCierreSobresTurno", "Turno: " & IdTurno.ToString(), "ImprimirCierreSobresTurno")
            Throw
        End Try

    End Sub
#End Region
End Class
#End Region