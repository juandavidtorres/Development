Imports System.Drawing.Printing
Imports System.IO
Imports POSstation.Fabrica
Imports POSstation.AccesoDatos
Imports POSstation
Imports POSstation.ServerServices



#Region "Turno"
Public Class ImpresoraTurno
    Inherits FormatoImpresora

    Private Shared LogFallas As New EstacionException

    Public Shared Sub ImprimirTurnoApoyo(ByVal turno As Int32, ByVal impresora As ImpresoraEstacion, ByVal EsApertura As Boolean)
        Try
            Dim OTurno As IDataReader
            Dim OHelper As New Helper
            OTurno = OHelper.RecuperarTurnoApoyo(turno)

            If OTurno.Read Then
                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
                End If
                If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\AperturaTurnoTrabajo" & turno.ToString() & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\AperturaTurnoTrabajo" & turno.ToString() & ".txt")
                End If

                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\AperturaTurnoTrabajo" & turno.ToString() & ".txt")
                    SW.WriteLine(CentrarTexto(40, OTurno.Item("NombreEstacion").ToString()))
                    SW.WriteLine(CentrarTexto(40, OTurno.Item("Nit").ToString()))
                    If EsApertura Then
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(CentrarTexto(40, "APERTURA DE TURNO APOYO"))
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(DobleColumna(22, "Apertura: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("HH:mm")))
                    Else
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(CentrarTexto(40, "CIERRE DE TURNO APOYO"))
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(DobleColumna(22, "Apertura: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("HH:mm")))
                        SW.WriteLine(DobleColumna(22, "Cierre: " & Date.Parse(OTurno.Item("Cierre").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OTurno.Item("Cierre").ToString()).ToString("HH:mm")))
                    End If
                    SW.WriteLine("Empleado: " & OTurno.Item("Nombre").ToString())
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
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\AperturaTurnoTrabajo" & turno.ToString() & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\AperturaTurnoTrabajo" & turno.ToString() & ".txt")
            End If
            OTurno.Close()
            OTurno = Nothing
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirAperturaTurnoApoyo", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirAperturaTurnoApoyo", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirAperturaTurnoApoyo", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirAperturaTurnoApoyo", "Turno: " & turno.ToString, "ImpresionTurnos")
        End Try
    End Sub


    Public Shared Sub ImprimirSaldoTarjetaPrepago(ByVal SaldoTarjeta As String, ByVal impresora As ImpresoraEstacion)
        Dim Saldo As String
        Try


            Dim Fecha As String = Now.ToString("HHmmss")
            Dim Datos() As String = SaldoTarjeta.Split("|")
            Saldo = Datos(0)
            Dim Tarjeta As String = Datos(1)


            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Fecha.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Fecha.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Fecha.ToString() & ".txt")
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()


                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "SALDO TARJETA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(FormatoImpresora.DobleColumna(15, "TARJETA", Tarjeta))
                SW.WriteLine(FormatoImpresora.DobleColumna(15, "SALDO", Saldo))

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
            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Fecha.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Fecha.ToString() & ".txt")

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Saldo: " & Saldo.ToString, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Saldo: " & Saldo.ToString, "ImpresionTurnos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Saldo: " & Saldo.ToString, "ImpresionTurnos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Saldo: " & Saldo.ToString, "ImpresionTurnos")
            Throw
        End Try
    End Sub




    Public Shared Sub ImprimirMovimientosPrepago(ByVal Tarjeta As String, ByVal impresora As ImpresoraEstacion, lista As List(Of ServerServices.MovimientoTarjeta), Saldo As RespuestaSaldo)
        Try

            Dim OHelper As New Helper
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Tarjeta.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Tarjeta.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Tarjeta.ToString() & ".txt")
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()


                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine("---------------------------------------")




                SW.WriteLine(CentrarTexto(40, "DATOS DE TARJETA"))
                SW.WriteLine("NOMBRE: " & Saldo.Cliente)
                SW.WriteLine("TARJETA: " & Tarjeta)
                SW.WriteLine("SALDO: " & CDbl(Saldo.Saldo.ToString("N2")))

                SW.WriteLine("---------------------------------------")


                If lista.Count > 0 Then
                    SW.WriteLine(CentrarTexto(40, "MOVIMIENTO DE COMBUSTIBLE"))
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(DobleColumna(20, "VALOR", "FECHA"))
                    For Each item As ServerServices.MovimientoTarjeta In lista
                        SW.WriteLine(DobleColumna(20, item.Valor, item.FechaHora))
                    Next

                    SW.WriteLine("---------------------------------------")
                Else
                    SW.WriteLine(CentrarTexto(40, "MOVIMIENTO DE COMBUSTIBLE"))
                    SW.WriteLine("La tarjeta aun no tiene movimientos de venta")
                    SW.WriteLine("---------------------------------------")
                End If


                SW.WriteLine(" ")

                'If OMovimientosCanastilla.Read Then
                '    SW.WriteLine(CentrarTexto(40, "MOVIMIENTO DE CANASTILLA"))
                '    SW.WriteLine("---------------------------------------")
                '    SW.WriteLine(DobleColumna(20, "VALOR", "FECHA"))
                '    SW.WriteLine(DobleColumna(20, OMovimientosCanastilla.Item("Valor").ToString, OMovimientosCanastilla.Item("Fecha").ToString))
                '    While (OMovimientos.Read)
                '        SW.WriteLine(DobleColumna(20, OMovimientosCanastilla.Item("Valor").ToString, OMovimientosCanastilla.Item("Fecha").ToString))
                '    End While
                '    SW.WriteLine("---------------------------------------")
                'Else
                '    SW.WriteLine("NO HAY MOVIMIENTOS DE CANASTILLA PARA LA TARJETA")
                'End If


                'OMovimientosCanastilla.Close()
                'OMovimientosCanastilla.Dispose()

            

                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(".")
                SW.Close()
            End Using
            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Tarjeta.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\ImprimirMovimientosPrepago" & Tarjeta.ToString() & ".txt")

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Tarjeta: " & Tarjeta.ToString, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Tarjeta: " & Tarjeta.ToString, "ImpresionTurnos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Tarjeta: " & Tarjeta.ToString, "ImpresionTurnos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirMovimientosPrepago", "Tarjeta: " & Tarjeta.ToString, "ImpresionTurnos")
            Throw
        End Try
    End Sub


    Public Shared Sub ImprimirResumenDiario(ByVal fecha As String, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper
        Dim OResultadoDatos As IDataReader = Nothing
        Dim OResultadoDatosTemp As IDataReader = Nothing
        Dim ListaMangueras As List(Of Manguera) = Nothing
        Dim ListaLecturas As List(Of Lectura) = Nothing
        Dim ListaProductos As List(Of Producto) = Nothing
        Dim EsImpresoEncabezadoSeccion As Boolean

        Try

            '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\Resumen" & fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Resumen" & fecha & ".txt")
            End If

            '--------------------------INICA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\Resumen" & fecha & ".txt")

                '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "CONTROL DE VENTAS DIARIO"))
                SW.WriteLine(" ")

                '------------------IMPRIMO TODAS LAS LECTURAS DEL DIA POR MANGUERA Y EL TOTAL ------------------------------
                SW.WriteLine("Fecha: " & fecha.Substring(6, 2) & "/" & fecha.Substring(4, 2) & "/" & fecha.Substring(0, 4))
                SW.WriteLine("****************************************")
                SW.WriteLine(CentrarTexto(40, "LECTURAS"))
                SW.WriteLine(TripleColumnaLecturas("", "ELECTRONICA", "MANUAL"))
                SW.WriteLine("----------------------------------------")

                ListaMangueras = Manguera.RecuperarListaMangueras()

                Dim Diferencia, SumaDiferencia As Double
                For Each OManguera As Manguera In ListaMangueras
                    SW.WriteLine(OManguera.Descripcion)
                    ListaLecturas = Lectura.RecuperarLecturasManguerasFecha(fecha, OManguera.IdManguera)
                    For Each OLectura As Lectura In ListaLecturas
                        SW.WriteLine(TripleColumnaLecturas("L.F.:", OLectura.LecturaFinal.ToString("N3"), "0.00"))
                        SW.WriteLine(TripleColumnaLecturas("L.I.:", OLectura.LecturaInicial.ToString("N3"), "0.00"))
                        SW.WriteLine("----------------------------------------")
                        Diferencia = OLectura.LecturaFinal - OLectura.LecturaInicial
                        SumaDiferencia = SumaDiferencia + Diferencia
                        SW.WriteLine(TripleColumnaLecturas("Dif.Lec:", Diferencia.ToString("N3"), "0.00"))
                        SW.WriteLine("----------------------------------------")
                    Next
                Next

                SW.WriteLine("----------------------------------------")
                SW.WriteLine(TripleColumnaLecturas("Total Dif.Lec:", SumaDiferencia.ToString("N3"), "0.00"))
                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")

                EsImpresoEncabezadoSeccion = False
                OResultadoDatos = OHelper.RecuperarRecargasPrepagoPorDia(fecha)
                While (OResultadoDatos.Read())
                    If Not EsImpresoEncabezadoSeccion Then
                        SW.WriteLine("****************************************")
                        SW.WriteLine(CentrarTexto(40, "RECARGAS PREPAGO"))
                        SW.WriteLine("Estas recargas fueron hechas por")
                        SW.WriteLine("el administrador")
                        SW.WriteLine(TripleColumnaLecturas("Tarjeta", "Hora", "Valor"))
                        SW.WriteLine("----------------------------------------")
                        EsImpresoEncabezadoSeccion = True
                    End If

                    SW.WriteLine(FormatoImpresora.TripleColumnaLecturas(CStr(OResultadoDatos.Item("Tarjeta")), CDate(OResultadoDatos.Item("Hora")).ToString("HH:mm"), CDec(OResultadoDatos.Item("Valor")).ToString("N2")))
                    SW.WriteLine("----------------------------------------")
                End While
                OResultadoDatos.Close()
                OResultadoDatos = Nothing

                '-------------------------------IMPRIMO LOS TOTALES POR FECHA---------------------------------------
                SW.WriteLine("========================================")
                SW.WriteLine(CentrarTexto(40, "TOTALES"))
                SW.WriteLine("========================================")

                ListaProductos = Producto.RecuperarListaProductos()
                Dim SumaTotales As Double = 0
                Dim ODatos As IDataReader = Nothing
                For Each OProducto As Producto In ListaProductos
                    OResultadoDatosTemp = OHelper.RecuperarTotalesPorFecha(fecha, OProducto.IdProducto)
                    While OResultadoDatosTemp.Read
                        SW.WriteLine("PRODUCTO:  " & OProducto.Nombre)
                        SW.WriteLine(" ")
                        SW.WriteLine(DobleColumnaTotal("Vehiculos Atendidos", OResultadoDatosTemp.Item("Vehiculos").ToString()))
                        SW.WriteLine(DobleColumnaTotal("Total " & OProducto.UnidadMedida, OResultadoDatosTemp.Item("Cantidad").ToString()))
                        SW.WriteLine(DobleColumnaTotal("Total Combustible", OResultadoDatosTemp.Item("Valor").ToString()))
                        SW.WriteLine(DobleColumnaTotal("Total Descuentos", OResultadoDatosTemp.Item("Descuento").ToString))

                        SW.WriteLine("----------------------------------------")
                        ODatos = OHelper.RecuperarTotalesPorFechaFormaPago(fecha, OProducto.IdProducto)
                        While ODatos.Read
                            SW.WriteLine(TripleColumnaLecturas(ODatos.Item(0).ToString(), ODatos.Item(2).ToString(), ODatos.Item(1).ToString()))
                        End While
                        ODatos.Close()
                        ODatos = Nothing

                        SW.WriteLine(DobleColumnaTotal("TOTAL ", (CDbl(OResultadoDatosTemp.Item("Valor")) - CDbl(OResultadoDatosTemp.Item("Descuento"))).ToString("N2")))
                        SW.WriteLine("----------------------------------------")

                        SumaTotales = SumaTotales + CDbl(OResultadoDatosTemp.Item("Valor").ToString) - CDbl(OResultadoDatosTemp.Item("Descuento").ToString)
                    End While
                    OResultadoDatosTemp.Close()
                    OResultadoDatosTemp = Nothing
                Next

                OResultadoDatosTemp = OHelper.RecuperarTotalesComplementariosPorFecha(fecha)
                If OResultadoDatosTemp.Read() Then
                    SW.WriteLine("----------------------------------------")

                    SW.WriteLine(DobleColumnaTotal("Total Combustible", SumaTotales.ToString))
                    SW.WriteLine(DobleColumnaTotal("Total Recaudos", CDbl(OResultadoDatosTemp.Item("recaudos")).ToString("N2")))
                    SW.WriteLine(DobleColumnaTotal("Total Reversos", CDbl(OResultadoDatosTemp.Item("reversos")).ToString("N2")))
                    SW.WriteLine(DobleColumnaTotal("Total Ingresos", CDbl(OResultadoDatosTemp.Item("ingresos")).ToString("N2")))
                    SW.WriteLine(DobleColumnaTotal("Total Financiacion", (CDbl(OResultadoDatosTemp.Item("recaudos")) - CDbl(OResultadoDatosTemp.Item("reversos")) + CDbl(OResultadoDatosTemp.Item("ingresos"))).ToString))
                    SW.WriteLine(DobleColumnaTotal("Total Impuestos", OResultadoDatosTemp.Item("impuestos").ToString()))
                    SW.WriteLine(DobleColumnaTotal("Total Credito", OResultadoDatosTemp.Item("credito").ToString))
                    SW.WriteLine(DobleColumnaTotal("Total Descuentos", OResultadoDatosTemp.Item("Descuentos").ToString))
                    SW.WriteLine(DobleColumnaTotal("Total Incrementos", OResultadoDatosTemp.Item("Incrementos").ToString))
                    SW.WriteLine(DobleColumnaTotal("Total Canastilla", OResultadoDatosTemp.Item("canastilla").ToString()))

                    SumaTotales = SumaTotales + CDbl(OResultadoDatosTemp.Item("Incrementos")) - CDbl(OResultadoDatosTemp.Item("Descuentos")) + CDbl(OResultadoDatosTemp.Item("recaudos")) - CDbl(OResultadoDatosTemp.Item("reversos")) + CDbl(OResultadoDatosTemp.Item("ingresos")) + CDbl(OResultadoDatosTemp.Item("impuestos")) + CDbl(OResultadoDatosTemp.Item("canastilla"))
                End If
                OResultadoDatosTemp.Close()
                OResultadoDatosTemp = Nothing

                SW.WriteLine("========================================")
                SW.WriteLine(DobleColumnaTotal("Gran Total", SumaTotales.ToString("N2")))
                SW.WriteLine("========================================")
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

                '-------------------------------IMPRIMO EL ARCHIVO Y LO ELIMINO POSTERIORMENTE--------------------------------------
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\Resumen" & fecha & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Resumen" & fecha & ".txt")
            End Using

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirResumenDiario", "Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirResumenDiario", "Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirResumenDiario", "Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirResumenDiario", "Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Finally
            ListaMangueras = Nothing
            ListaLecturas = Nothing
            ListaProductos = Nothing
        End Try
    End Sub

    Public Shared Sub ImprimirExcepcion(ByVal texto As String, ByVal impresora As ImpresoraEstacion)

        Try
            Dim Fecha As String

            '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
            Fecha = Now.ToString("HHmmss")
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt")
            End If

            '--------------------------INICIA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt")
                Dim PorcionTexto As String

                '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(" ")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "EXCEPCION"))
                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")

                PorcionTexto = texto
                While PorcionTexto.Length > 39
                    SW.WriteLine(PorcionTexto.Substring(0, 39))
                    PorcionTexto = PorcionTexto.Substring(39)
                End While

                SW.WriteLine(PorcionTexto)
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
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt")
            End Using

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirExcepcionProcesoTurno(ByVal texto As String, ByVal cara As Short, ByVal estadoTurno As Boolean, ByVal impresora As ImpresoraEstacion)

        Try
            Dim Fecha As String

            '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
            Fecha = Now.ToString("HHmmss")
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt")
            End If

            '--------------------------INICIA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt")
                Dim PorcionTexto As String

                '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(" ")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, IIf(estadoTurno = False, "EXCEPCION EN APERTURA DE TURNO", "EXCEPCION EN CIERRE DE TURNO").ToString))
                SW.WriteLine("----------------------------------------")
                SW.WriteLine("CARA: " & cara.ToString)
                SW.WriteLine(" ")

                PorcionTexto = texto
                While PorcionTexto.Length > 39
                    SW.WriteLine(PorcionTexto.Substring(0, 39))
                    PorcionTexto = PorcionTexto.Substring(39)
                End While

                SW.WriteLine(PorcionTexto)
                SW.WriteLine(" ")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "*** INTENTE NUEVAMENTE ***"))
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
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Excepcion" & Fecha & ".txt")
            End Using

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirExcepcion", "Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirTurno(ByVal turno As Int32, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper
        Dim Idturno As String = turno.ToString
        Dim OResultadoDatos As IDataReader = Nothing
        Dim TotalCanastilla As Double
        Dim ListaProductos As List(Of Producto) = Nothing
        Dim ListaEmpleado As List(Of Empleado) = Nothing
        Dim ListaVentasTurno As List(Of VentaTurno) = Nothing
        Dim ListaFormasPago As List(Of FormaPago) = Nothing
        Dim ListaSurtidores As List(Of Surtidor) = Nothing
        Dim ListaFinancieras As List(Of Financiera) = Nothing
        Dim ListaMangueras As List(Of Manguera) = Nothing
        Dim ListaLecturas As List(Of Lectura)
        Dim EsImpresoEncabezadoSeccion As Boolean = False
        Dim Fecha As String = Now.ToString("HHmmss")
        Try

            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))
            Dim EsCierreDetallado As Boolean = CBool(OHelper.RecuperarParametro("CierreDetallado"))

            If Idturno <> "0" Then
                '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
                End If
                If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\Turno" & Idturno & Fecha & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Turno" & Idturno & Fecha & ".txt")
                End If

                '--------------------------INICIA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\Turno" & Idturno & Fecha & ".txt")



                    '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                    Dim OEncabezado As InformacionEncabezado
                    OEncabezado = RecuperarEncabezado()

                    SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                    SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                    SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                    SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                    SW.WriteLine(" ")
                    SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                    SW.WriteLine(" ")

                    '-------------------VERIFICO E IMPRIMO SI ES UNA COPIA PARA CIERRE DE TURNO O UNA CONSULTA DE CIERRE PARCIAL----------------------------------
                    If impresora.ESArqueo Then
                        SW.WriteLine(CentrarTexto(40, STexto & "ARQUEO TURNO ACTUAL"))
                    Else
                        SW.WriteLine(CentrarTexto(40, STexto & "CIERRE TURNO"))
                    End If
                    SW.WriteLine(" ")

                    '-------------------RECUPERO LOS DATOS RESPECTIVOS AL TURNO ACTUAL: NUMERO DE TURNO,FECHA DE INICIO Y CIERRE----------------------------------
                    OResultadoDatos = OHelper.RecuperarTurno(CInt(Idturno))
                    If OResultadoDatos.Read Then
                        SW.WriteLine("Turno: " & OResultadoDatos.Item("NumeroTurno").ToString())
                        SW.WriteLine("Fecha Inicio: " & CDate(OResultadoDatos.Item("Apertura")).ToString("dd/MM/yyyy HH:mm:ss"))
                        If Not OResultadoDatos.Item("Cierre") Is System.DBNull.Value Then
                            SW.WriteLine("Fecha Fin   : " & CDate(OResultadoDatos.Item("Cierre")).ToString("dd/MM/yyyy HH:mm:ss"))
                        End If
                        SW.WriteLine("Islero: " & OResultadoDatos.Item("Nombre").ToString())
                    End If
                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing

                    '-------------------RECUPERO LOS SURTIDORES PERTENECIENTES A ESTE TURNO Y RECUPERO CADA FORMA DE PAGO ----------------------------------
                    '-------------------LUEGO IMPRIMO LA DESCRIPCION DE LAS VENTAS REALIZADAS CON ESTA FORMA DE PAGO, Nro,PLACA,HORA,M3,TOTAL----------------------------------


                    ListaSurtidores = Surtidor.RecuperarListaSurtidoresPorTurno(turno)
                    ListaProductos = Producto.RecuperarListaProductos()
                    For Each OSurtidor As Surtidor In ListaSurtidores
                        SW.WriteLine("----------------------------------------")
                        SW.WriteLine("Surtidor: " & OSurtidor.Descripcion & " " & OSurtidor.DescripcionEstado)
                        SW.WriteLine("----------------------------------------")

                        ListaFormasPago = FormaPago.RecuperarListaFormasPagoTurno(turno, OSurtidor.IdSurtidor)

                        For Each FormPago As FormaPago In ListaFormasPago

                            '-------------------RECUPERO EL DETALLE DE VENTAS POR CADA FORMA DE PAGO Y LO IMPRIMO----------------------------------
                            Dim SumaCantidad, SumaTotal As Double, SumaVehiculos As Int32

                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine(FormPago.Descripcion)
                            SW.WriteLine("----------------------------------------")
                            For Each OProducto As Producto In ListaProductos
                                SumaCantidad = 0 : SumaTotal = 0 : SumaVehiculos = 0

                                ListaVentasTurno = VentaTurno.RecuperarListaVentasTurnoPorSurtidor(turno, OSurtidor.IdSurtidor, FormPago.IdFormaPago, OProducto.IdProducto)

                                If ListaVentasTurno.Count > 0 Then
                                    SW.WriteLine("PRODUCTO: " & OProducto.Nombre)
                                    SW.WriteLine(" ")
                                    If EsCierreDetallado Then
                                        SW.WriteLine(SextaColumnaCierreTurno("Nro.", "Placa", "Hora", "PD", OProducto.UnidadMedida, "Total"))
                                        SW.WriteLine("----------------------------------------")
                                    End If


                                    For Each Venta As VentaTurno In ListaVentasTurno
                                        If EsCierreDetallado Then
                                            SW.WriteLine(SextaColumnaCierreTurno(Venta.Recibo.ToString, Venta.Placa, Venta.Hora, OProducto.IdProducto.ToString, Venta.Cantidad.ToString, Venta.Total.ToString))
                                        End If

                                        SumaCantidad = SumaCantidad + Venta.Cantidad
                                        SumaTotal = SumaTotal + Venta.Total
                                        SumaVehiculos = SumaVehiculos + 1
                                    Next


                                    SW.WriteLine("========================================")
                                    SW.WriteLine("Total " & OProducto.UnidadMedida & ": " & SumaCantidad.ToString("N3"))
                                    SW.WriteLine("Total: " & SumaTotal.ToString("N2"))
                                    'SW.WriteLine("Vehiculos atendidos: " & SumaVehiculos.ToString("N0"))
                                    SW.WriteLine(" ")
                                    SW.WriteLine("----------------------------------------")
                                End If

                            Next
                        Next
                    Next


                    If EsCierreDetallado Then

                        'Dim TotalCantidad As Double = 0
                        'Dim TotalVenta As Double = 0
                        'Dim TotalVehiculo As Double = 0

                        ListaFormasPago = Empleado.RecuperarFormasPagoPorTurnoEmpleado(turno)
                        ListaProductos = Producto.RecuperarListaProductos()
                        ListaEmpleado = Empleado.RecuperarListaEmpleadosVendedores(turno)

                        If ListaEmpleado.Count > 0 Then
                            SW.WriteLine("****************************************")
                            SW.WriteLine(CentrarTexto(40, "VENTAS POR VENDEDOR"))
                        End If

                        For Each InfoEmpleado As Empleado In ListaEmpleado
                            SW.WriteLine("NOMBRE: " & InfoEmpleado.Descripcion.ToUpper)
                            SW.WriteLine("----------------------------------------")
                            '-------------------RECUPERO EL DETALLE DE VENTAS POR CADA FORMA DE PAGO Y LO IMPRIMO----------------------------------
                            Dim SumaCantidad, SumaTotal As Double, SumaVehiculos As Int32


                            For Each OProducto As Producto In ListaProductos
                                SumaCantidad = 0 : SumaTotal = 0 : SumaVehiculos = 0
                                For Each Dato As FormaPago In ListaFormasPago

                                    ListaVentasTurno = Empleado.RecuperarListaVentasTurnoEmpleadoSurtidor(turno, 0, Dato.IdFormaPago, OProducto.IdProducto, InfoEmpleado.IdEmpleado)

                                    If ListaVentasTurno.Count > 0 Then
                                        SW.WriteLine(Dato.Descripcion.ToUpper)
                                        SW.WriteLine("----------------------------------------")
                                        SW.WriteLine("PRODUCTO: " & OProducto.Nombre)
                                        SW.WriteLine(" ")
                                        If EsCierreDetallado Then
                                            SW.WriteLine(SextaColumnaCierreTurno("Nro.", "Placa", "Hora", "PD", OProducto.UnidadMedida, "Total"))
                                            SW.WriteLine("----------------------------------------")
                                        End If


                                        For Each Venta As VentaTurno In ListaVentasTurno
                                            If EsCierreDetallado Then
                                                SW.WriteLine(SextaColumnaCierreTurno(Venta.Recibo.ToString, Venta.Placa, Venta.Hora, OProducto.IdProducto.ToString, Venta.Cantidad.ToString, Venta.Total.ToString))
                                            End If

                                            SumaCantidad = SumaCantidad + Venta.Cantidad
                                            SumaTotal = SumaTotal + Venta.Total
                                            SumaVehiculos = SumaVehiculos + 1
                                        Next

                                        'TotalVehiculo = TotalVehiculo + SumaVehiculos
                                        'TotalVenta = TotalVenta + SumaTotal
                                        'TotalCantidad = TotalCantidad + SumaCantidad

                                        SW.WriteLine("========================================")
                                        SW.WriteLine("Total " & OProducto.UnidadMedida & ": " & SumaCantidad.ToString("N3"))
                                        SW.WriteLine("Total: " & SumaTotal.ToString("N2"))
                                        SW.WriteLine("Vehiculos atendidos: " & SumaVehiculos.ToString("N0"))
                                        SW.WriteLine(" ")
                                        SW.WriteLine("----------------------------------------")
                                        SumaCantidad = 0 : SumaTotal = 0 : SumaVehiculos = 0
                                    End If
                                Next
                            Next
                        Next
                    End If


                    'Dim VentasPorEmpleado As IDataReader = Nothing
                    'VentasPorEmpleado = OHelper.RecuperarVentasPorEmpleadoVendedor(CInt(Idturno))

                    'If VentasPorEmpleado.Read() Then
                    '    SW.WriteLine("****************************************")
                    '    SW.WriteLine(CentrarTexto(40, "VENTAS POR EMPLEADO"))
                    '    SW.WriteLine(TripleColumnaLecturas("Nombre", "Total", "Veh.Atendidos"))
                    '    SW.WriteLine("----------------------------------------")
                    '    SW.WriteLine(TripleColumnaLecturas(VentasPorEmpleado.Item("Nombre"), CDbl(VentasPorEmpleado.Item("Total")).ToString("N2"), VentasPorEmpleado.Item("VehiculosAtendidos")))

                    '    While VentasPorEmpleado.Read()
                    '        SW.WriteLine(TripleColumnaLecturas(VentasPorEmpleado.Item("Nombre"), CDbl(VentasPorEmpleado.Item("Total")).ToString("N2"), VentasPorEmpleado.Item("VehiculosAtendidos")))
                    '    End While
                    'End If
                    'VentasPorEmpleado.Close()
                    'VentasPorEmpleado.Dispose()


                    '--> SECCION DE IMPRESION DE CAMBIOS DE CHEQUES
                    Try
                        Dim oTable As DataTable = OHelper.RecuperarNumeroChequePorTurno(turno)
                        If oTable.Rows.Count > 0 Then
                            Dim sumaCambioCheque As Double = 0
                            SW.WriteLine("****************************************")
                            SW.WriteLine(CentrarTexto(40, "CAMBIO DE CHEQUES"))
                            SW.WriteLine("****************************************")
                            For Each oDataRow As DataRow In oTable.Rows
                                SW.WriteLine("----------------------------------------")
                                SW.WriteLine("NUMERO CHEQUE: " & oDataRow.Item("NumeroCheque").ToString())
                                SW.WriteLine("----------------------------------------")
                                Dim oCambioCheque As DataTable = OHelper.RecuperarCambiosChequePorTurno(turno, oDataRow.Item("NumeroCheque").ToString())
                                SW.WriteLine(TripleColumnaLecturas("Placa", "Fecha", "Valor"))
                                For Each oDataCambio As DataRow In oCambioCheque.Rows
                                    SW.WriteLine(TripleColumnaLecturas(oDataCambio.Item("Placa").ToString(), oDataCambio.Item("Fecha").ToString(), oDataCambio.Item("Valor").ToString()))
                                    sumaCambioCheque += CDbl(oDataCambio.Item("Valor").ToString())
                                Next
                                oCambioCheque.Clear()
                                oCambioCheque = Nothing
                            Next
                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine("TOTAL CAMBIO DE CHEQUES: " & CStr(sumaCambioCheque).ToString())
                            SW.WriteLine("----------------------------------------")
                        End If
                        oTable.Clear()
                        oTable = Nothing
                    Catch ex As System.Exception
                        LogFallas.ReportarError(ex, "RecuperarCambiosdeCheque", "Turno: " & turno.ToString, "ImpresionTurnos")
                    End Try


                    '-------------------IMPRIME LAS LECTURAS POR MANGUERA EN EL TURNO DADO----------------------------------
                    SW.WriteLine("****************************************")
                    SW.WriteLine(CentrarTexto(40, "LECTURAS"))
                    SW.WriteLine(CentrarTexto(40, STexto & "CIERRE TURNO"))
                    SW.WriteLine(TripleColumnaLecturas("", "ELECTRONICA", "MANUAL"))
                    SW.WriteLine("----------------------------------------")

                    ListaMangueras = Manguera.RecuperarListaManguerasPorTurno(turno)
                    ListaLecturas = Nothing
                    Dim Diferencia, SumaDiferencia As Double

                    For Each OManguera As Manguera In ListaMangueras
                        SW.WriteLine(OManguera.Descripcion.ToString() & " :")
                        SW.WriteLine("----------------------------------------")
                        ListaLecturas = Lectura.RecuperarLecturasManguerasTurno(turno, OManguera.IdManguera)
                        For Each OLectura As Lectura In ListaLecturas
                            SW.WriteLine(TripleColumnaLecturas("L.F.:", OLectura.LecturaFinal.ToString("N3"), "0.00"))
                            SW.WriteLine(TripleColumnaLecturas("L.I.:", OLectura.LecturaInicial.ToString("N3"), "0.00"))
                            SW.WriteLine("========================================")
                            Diferencia = OLectura.LecturaFinal - OLectura.LecturaInicial
                            SumaDiferencia = SumaDiferencia + Diferencia
                            SW.WriteLine(TripleColumnaLecturas("Dif.Lec:", Diferencia.ToString("N3"), "0.00"))
                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine(" ")
                        Next
                    Next


                    '-------------------IMPRIME LAS DIFERENCIAS ENTRE LECTURAS FINAL E INICIAL----------------------------------
                    '-------------------OBTIENE E IMPRIME EL TOTAL DE RECAUDO OBTENIDO POR TURNO----------------------------------
                    SW.WriteLine("----------------------------------------")
                    SW.WriteLine(TripleColumnaLecturas("Total Dif.Lec:", SumaDiferencia.ToString("N3"), "0.00"))
                    SW.WriteLine("----------------------------------------")
                    SW.WriteLine("****************************************")
                    SW.WriteLine(CentrarTexto(40, STexto & "CIERRE TURNO"))
                    SW.WriteLine("****************************************")
                    SW.WriteLine(" ")

                    '-------------------------------IMPRIMO LOS CALIBRACIONES POR TURNO---------------------------------------
                    EsImpresoEncabezadoSeccion = False
                    OResultadoDatos = OHelper.RecuperarCalibracionesPorTurno(turno)
                    While (OResultadoDatos.Read())
                        If Not EsImpresoEncabezadoSeccion Then
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, "CALIBRACIONES"))
                            EsImpresoEncabezadoSeccion = True
                        End If

                        SW.WriteLine("----------------------------------------")
                        'SW.WriteLine("Tanque: " & OResultadoDatos.Item("Tanque").ToString())
                        SW.WriteLine("Producto: " & OResultadoDatos.Item("Producto").ToString())
                        SW.WriteLine("Manguera: " & OResultadoDatos.Item("Manguera").ToString())
                        SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("Cantidad: " & CDbl(OResultadoDatos.Item("Cantidad")).ToString("N3"), "Fecha: " & CDate(OResultadoDatos.Item("FechaHora")).ToString("dd/MM/yyyy")))
                        SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("L.I: " & IIf(Not OResultadoDatos.Item("LecturaInicial") Is System.DBNull.Value, CDbl(OResultadoDatos.Item("LecturaInicial")).ToString("N3"), "NO DISPONIBLE").ToString(), "L.F: " & CDbl(OResultadoDatos.Item("LecturaFinal")).ToString("N3")))
                    End While
                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing

                    '-------------------IMPRIMIR MENSAJE DE ADVERTENCIA DE LECTURAS----------------------------------
                    Try
                        If CBool(OHelper.RecuperarParametro("MostrarAdvertenciaBloqueoManguera")) And OHelper.ExistenBloqueosMangueraEnTurno(Idturno) Then
                            SW.WriteLine(" ")
                            SW.WriteLine("Existen saltos de lecturas en las man-")
                            SW.WriteLine("gueras. Por favor dirigase al adminis-")
                            SW.WriteLine("trador de la Estacion, y reporte si")
                            SW.WriteLine("fue una falla tecnica o en su")
                            SW.WriteLine("defecto si hubo ventas fuera")
                            SW.WriteLine("del sistema")
                            SW.WriteLine("****************************************")
                        End If
                    Catch exe As System.Exception
                        LogFallas.ReportarError(exe, "ImprimirTurno", "Turno: " & turno.ToString & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
                    End Try

                    '-------------------IMPRIME LAS VENTAS RECUPERADAS POR FORMA DE PAGO EN EL TURNO DADO----------------------------------
                    EsImpresoEncabezadoSeccion = False
                    OResultadoDatos = OHelper.RecuperarVentasRecuperadas(turno)
                    While OResultadoDatos.Read()
                        If Not EsImpresoEncabezadoSeccion Then
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, "VENTAS RECUPERADAS"))
                            SW.WriteLine("****************************************")
                            SW.WriteLine(" ")
                            SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("Forma de Pago", "Cantidad"))
                            EsImpresoEncabezadoSeccion = True
                        End If

                        SW.WriteLine(FormatoImpresora.DobleColumnaNumerica(CStr(OResultadoDatos.Item("FormaPago")), CStr(OResultadoDatos.Item("Cantidad"))))
                    End While

                    '-------------------IMPRIME LOS FALLOS TECNICOS POR VENTAS FUERA DE SISTEMA EN EL TURNO DADO----------------------------------
                    Dim IdManguera As Short = -1
                    OResultadoDatos = OHelper.RecuperarFallosDeSistema(turno)
                    EsImpresoEncabezadoSeccion = False
                    While OResultadoDatos.Read()
                        If Not EsImpresoEncabezadoSeccion Then
                            SW.WriteLine(" ")
                            SW.WriteLine(CentrarTexto(40, "FALLAS TECNICAS"))
                            SW.WriteLine("****************************************")
                            SW.WriteLine(" ")
                            EsImpresoEncabezadoSeccion = True
                        End If

                        If IdManguera = -1 Or CShort(OResultadoDatos.Item("IdManguera")) <> IdManguera Then
                            If IdManguera <> -1 Then
                                SW.WriteLine("----------------------------------------")
                            End If
                            IdManguera = CShort(OResultadoDatos.Item("IdManguera"))

                            SW.WriteLine(CentrarTexto(40, "Manguera: " & IdManguera))
                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine(FormatoImpresora.TripleColumnaFallasTecnicas("Fecha", "L.I.", "L.F."))
                        End If

                        SW.WriteLine(FormatoImpresora.TripleColumnaFallasTecnicas(CStr(OResultadoDatos.Item("FechaHora")), CDec(OResultadoDatos.Item("LecturaAnterior")).ToString("N3"), CDec(OResultadoDatos.Item("LecturaPosterior")).ToString("N3")))
                        SW.WriteLine("Lectura Calculada: " & CDec(OResultadoDatos.Item("LecturaCalculada")).ToString("N3"))
                    End While
                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing
                    '-----------------------------------------------------

                    ''--> SECCION DE IMPRESION DE CONSIGNACION DE SOBRES
                    Try
                        Dim SumaValorSobres As Decimal = 0
                        Dim oTable As DataTable = OHelper.RecuperarConsignaciondeSobresTurno(turno, Convert.ToInt16(TipoTurnoTrabajo.Combustible))
                        If oTable.Rows.Count > 0 Then
                            SW.WriteLine("****************************************")
                            SW.WriteLine(CentrarTexto(40, "CONSIGNACION DE SOBRES"))
                            SW.WriteLine("****************************************")
                            For Each oDataRow As DataRow In oTable.Rows
                                SW.WriteLine("Numero de Sobres: " & oDataRow.Item("NumeroSobres").ToString())
                                SW.WriteLine("Valor Consignaciones: " & CDec(oDataRow.Item("ValorSobres")).ToString("N2"))
                                SW.WriteLine("Valor Variable: " & CDec(oDataRow.Item("ValorPicos")).ToString("N2"))
                                SumaValorSobres = SumaValorSobres + CDec(oDataRow.Item("ValorSobres")) + CDec(oDataRow.Item("ValorPicos"))
                            Next
                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine("Total Consignaciones: " & SumaValorSobres.ToString("N2"))
                        End If
                        oTable.Clear()
                        oTable = Nothing
                    Catch ex As System.Exception
                        LogFallas.ReportarError(ex, "RecuperarConsignaciondeSobresTurno", "Turno: " & turno.ToString, "ImpresionTurnos")
                    End Try

                    SW.WriteLine(" ")

                    ListaFinancieras = Financiera.RecuperarFinancieras()

                    If ListaFinancieras.Count > 0 Then
                        SW.WriteLine(CentrarTexto(40, "FINANCIACION"))
                        SW.WriteLine("****************************************")
                        SW.WriteLine(" ")
                        For Each Financ As Financiera In ListaFinancieras
                            ListaVentasTurno = VentaTurno.RecuperarVentasReacaudoTurno(turno, Financ.IdFinanciera)
                            If ListaVentasTurno.Count > 0 Then
                                SW.WriteLine("FINANCIERA:  " & Financ.Descripcion)
                                SW.WriteLine(" ")
                                SW.WriteLine(PentaColumna("Nro.", "Placa", "Hora", "", "Abono"))
                                SW.WriteLine("----------------------------------------")
                                For Each Ventas As VentaTurno In ListaVentasTurno
                                    SW.WriteLine(PentaColumna(Ventas.Recibo.ToString(), Ventas.Placa, Ventas.Hora, "", Ventas.AbonoCredito.ToString("N2")))
                                Next
                                SW.WriteLine(" ")
                            End If
                        Next
                    End If

                    '-------------------OBTIENE E IMPRIME EL TOTAL POR REVERSIONES EN EL TURNO----------------------------------
                    OResultadoDatos = OHelper.RecuperarReversionesPorTurno(CInt(Idturno))
                    If OResultadoDatos.Read Then
                        SW.WriteLine("****************************************")
                        SW.WriteLine(CentrarTexto(40, "REVERSIONES"))
                        SW.WriteLine(PentaColumna("Nro.", "Placa", "Hora", "", "Reverso"))
                        SW.WriteLine("----------------------------------------")
                        SW.WriteLine(PentaColumna(OResultadoDatos.Item("Recibo").ToString(), OResultadoDatos.Item("Placa").ToString(), OResultadoDatos.Item("Hora").ToString(), "", CDbl(OResultadoDatos.Item("reverso")).ToString("N2")))
                        While OResultadoDatos.Read
                            SW.WriteLine(PentaColumna(OResultadoDatos.Item("Recibo").ToString(), OResultadoDatos.Item("Placa").ToString(), OResultadoDatos.Item("Hora").ToString(), "", CDbl(OResultadoDatos.Item("reverso")).ToString("N2")))
                        End While
                    End If

                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing

                    '-------------------OBTIENE LOS PAGOS REALIZADOS POR TURNO----------------------------------
                    OResultadoDatos = OHelper.RecuperarPagosPorTurno(CInt(Idturno))

                    If OResultadoDatos.Read Then
                        SW.WriteLine("****************************************")
                        SW.WriteLine(CentrarTexto(40, "INGRESOS"))
                        SW.WriteLine(PentaColumna("Nro.", "Placa", "Hora", "", "Ingreso"))
                        SW.WriteLine("----------------------------------------")

                        SW.WriteLine(PentaColumna(OResultadoDatos.Item("IdPago").ToString(), OResultadoDatos.Item("Placa").ToString(), OResultadoDatos.Item("Hora").ToString(), "", CDbl(OResultadoDatos.Item("Valor")).ToString("N2")))
                        While OResultadoDatos.Read
                            SW.WriteLine(PentaColumna(OResultadoDatos.Item("IdPago").ToString(), OResultadoDatos.Item("Placa").ToString(), OResultadoDatos.Item("Hora").ToString(), "", CDbl(OResultadoDatos.Item("Valor")).ToString("N2")))
                        End While

                    End If

                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing

                    '-------------------OBTIENE LOS DESCUENTOS POR TURNO----------------------------------
                    OResultadoDatos = OHelper.RecuperarDescuentosPorTurno(CInt(Idturno))
                    If OResultadoDatos.Read Then
                        SW.WriteLine("****************************************")
                        SW.WriteLine(CentrarTexto(40, "DESCUENTOS"))
                        SW.WriteLine(PentaColumna("Nro.", "Placa", "Hora", "% Desc", "Descuento"))
                        SW.WriteLine("----------------------------------------")

                        SW.WriteLine(PentaColumna(OResultadoDatos.Item("Recibo").ToString(), OResultadoDatos.Item("Placa").ToString(), OResultadoDatos.Item("Hora").ToString(), OResultadoDatos.Item("Porcentaje").ToString(), CDbl(OResultadoDatos.Item("Descuento")).ToString("N2")))

                        While OResultadoDatos.Read
                            SW.WriteLine(PentaColumna(OResultadoDatos.Item("Recibo").ToString(), OResultadoDatos.Item("Placa").ToString(), OResultadoDatos.Item("Hora").ToString(), OResultadoDatos.Item("Porcentaje").ToString(), CDbl(OResultadoDatos.Item("Descuento")).ToString("N2")))
                        End While

                    End If
                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing

                    '---------------- AGREGA LA INFORMACION DE LAS VENTAS DE CANASTILLAS Y SE RECUPERA CADA FORMA DE PAGO----------------------------------
                    ListaFormasPago = FormaPago.RecuperarListaFormasPagoCanastilla(turno)
                    Dim VentasCanastilla As List(Of CanastillaTurno)
                    TotalCanastilla = 0

                    If ListaFormasPago.Count > 0 Then
                        SW.WriteLine("****************************************")
                        SW.WriteLine(CentrarTexto(40, "CANASTILLA"))
                        SW.WriteLine(" ")

                        For Each FormPago As FormaPago In ListaFormasPago

                            Dim SumaTotal As Double = 0

                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine(FormPago.Descripcion)
                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine(CuartaColumna("Nro.", "Hora", "Iva", "Total"))
                            ''SW.WriteLine(TripleColumnaLecturasCanastilla("Nro.", "Hora", "Total"))
                            SW.WriteLine("----------------------------------------")

                            SumaTotal = 0

                            VentasCanastilla = CanastillaTurno.RecuperarVentasCanastillaTurno(turno, FormPago.IdFormaPago)
                            For Each Venta As CanastillaTurno In VentasCanastilla
                                ''SW.WriteLine(TripleColumnaLecturasCanastilla(Venta.Numero, Venta.Hora, Venta.Total.ToString("N2")))
                                SW.WriteLine(CuartaColumna(Venta.Numero, Venta.Hora, (Venta.Iva.ToString()), Venta.Total.ToString("N2")))
                                SumaTotal = SumaTotal + Venta.Total
                            Next

                            SW.WriteLine("========================================")
                            SW.WriteLine("Total   : " & SumaTotal.ToString("N2"))
                            SW.WriteLine(" ")

                            TotalCanastilla = TotalCanastilla + SumaTotal
                        Next
                    End If

                    Dim lector As IDataReader = OHelper.RecuperarVentasTotalizadasPorTurno(Idturno)
                    Dim Cantidad As Decimal = 0
                    Dim Valor As Decimal = 0

                    If OHelper.RecuperarParametro("ImprimirTotalesTurnoProductoValor") Then

                        SW.WriteLine("========================================")
                        SW.WriteLine(CentrarTexto(40, "TOTALES POR PRODUCTO"))
                        SW.WriteLine("========================================")
                        SW.WriteLine((TripleColumnaLecturas("PRODUCTO", "CANTIDAD", "VALOR")))
                        While lector.Read
                            SW.WriteLine((TripleColumnaLecturas(lector.Item("Nombre").ToString(), lector.Item("Cantidad").ToString(), lector.Item("Valor").ToString())))
                            Cantidad = Cantidad + CDec(lector.Item("Cantidad"))
                            Valor = Valor + CDec(lector.Item("Valor"))
                        End While
                        SW.WriteLine("========================================")
                        SW.WriteLine("TOTAL$: " & Valor)
                        SW.WriteLine("TOTAL GALONES: " & Cantidad)

                    End If
                    lector.Close()
                    lector.Dispose()


                    lector = OHelper.RecuperarRecargasPrepagoPorTurno(Idturno)
                    Cantidad = 0
                    Valor = 0
                    SW.WriteLine("========================================")
                    SW.WriteLine(CentrarTexto(40, "RECARGAS PREPAGO"))
                    SW.WriteLine("========================================")
                    SW.WriteLine((TripleColumnaLecturas("VALOR", "HORA", "TARJETA")))
                    While lector.Read
                        SW.WriteLine((TripleColumnaLecturas(lector.Item("Valor").ToString(), lector.Item("Hora").ToString(), lector.Item("Tarjeta").ToString())))
                        Valor = Valor + CDec(lector.Item("Valor"))
                    End While
                    SW.WriteLine("========================================")
                    SW.WriteLine("TOTAL$: " & Valor)
                    lector.Close()
                    lector.Dispose()


                    ''Valido los saldo iniciales y finales del inventario canastilla por isla para el turno
                    If OHelper.RecuperarParametro("AplicaInventarioPorIsla") Then
                        Dim Oisla As IDataReader = OHelper.RecuperarIslaPorTurno(CInt(Idturno))
                        SW.WriteLine("========================================")
                        SW.WriteLine(CentrarTexto(40, "INVENT. CANASTILLA ISLA"))
                        SW.WriteLine("========================================")

                        While Oisla.Read
                            SW.WriteLine("Isla " & Oisla.Item("IdIsla"))
                            SW.WriteLine("----------------------------------------")
                            SW.WriteLine(TripleColumnaLecturas("CODIGO", "CANT_INI", "CANT_FIN"))
                            lector = OHelper.RecuperarInventarioCanastillaPorTurno(Idturno, Oisla.Item("IdIsla"))
                            While lector.Read
                                SW.WriteLine(TripleColumnaLecturas(lector.Item("Codigo").ToString(), lector.Item("CantidadInicial").ToString(), lector.Item("CantidadFinal").ToString()))
                            End While
                            lector.Close()
                            lector.Dispose()
                            SW.WriteLine("----------------------------------------")
                        End While
                        Oisla.Close()
                        Oisla.Dispose()
                    End If

                    '---------------- AGREGA LA INFORMACION DE LOS TOTALES POR TURNO----------------------------------

                    SW.WriteLine("========================================")
                    SW.WriteLine(CentrarTexto(40, "TOTALES"))
                    SW.WriteLine("========================================")

                    OResultadoDatos = OHelper.RecuperarTotalesPorTurno(CInt(Idturno))

                    While OResultadoDatos.Read
                        SW.WriteLine(DobleColumnaTotal("Vehiculos Atendidos", OResultadoDatos.Item("Ventas").ToString()))
                        SW.WriteLine(DobleColumnaTotal("Cantidad Bonos", OResultadoDatos.Item("CantBonos").ToString()))
                        SW.WriteLine(DobleColumnaTotal("Total Combustible", CDbl(OResultadoDatos.Item("Combustible")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Cantidad Vendida", CDbl(OResultadoDatos.Item("TotalGasolina")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Descuentos", CDbl(OResultadoDatos.Item("Descuentos")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Incrementos", CDbl(OResultadoDatos.Item("Incrementos")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Recaudos", CDbl(OResultadoDatos.Item("Recaudos")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Reversos", CDbl(OResultadoDatos.Item("Reversos")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Ingresos", CDbl(OResultadoDatos.Item("Ingresos")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Financiacion", (CDbl(OResultadoDatos.Item("Ingresos")) - CDbl(OResultadoDatos.Item("Reversos")) + CDbl(OResultadoDatos.Item("Recaudos"))).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Impuestos", CDbl(OResultadoDatos.Item("Impuestos")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Canastilla", CDbl(OResultadoDatos.Item("Canastilla")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Prepago", CDbl(OResultadoDatos.Item("TotalPrepago")).ToString("N2")))
                        SW.WriteLine(DobleColumnaTotal("Total Bonos", CDbl(OResultadoDatos.Item("TotalBonos")).ToString("N2")))
                        Dim total As Decimal = CDbl(OResultadoDatos.Item("Ingresos")) -
                                CDbl(OResultadoDatos.Item("Reversos")) +
                                CDbl(OResultadoDatos.Item("Recaudos")) +
                                CDbl(OResultadoDatos.Item("Combustible")) -
                                CDbl(OResultadoDatos.Item("Descuentos")) +
                                CDbl(OResultadoDatos.Item("Impuestos")) +
                                CDbl(OResultadoDatos.Item("Incrementos")) +
                                CDbl(OResultadoDatos.Item("Canastilla")) +
                                CDbl(OResultadoDatos.Item("TotalPrepago"))
                        SW.WriteLine(DobleColumnaTotal("Gran Total", total.ToString("N2")))
                    End While

                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing
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

                    '----------------------IMPRIMO EL ARCHIVO Y POSTERIORMENTE LO ELIMINO-----------------------------------
                    AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\Turno" & Idturno & Fecha & ".txt", impresora.Nombre)
                    File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\Turno" & Idturno & Fecha & ".txt")
                End Using
            End If
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTurno", "Turno: " & turno.ToString & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTurno", "Turno: " & turno.ToString & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As IO.IOException
            Throw
            LogFallas.ReportarError(ex, "ImprimirTurno", "Turno: " & turno.ToString & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTurno", "Turno: " & turno.ToString & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Finally
            ListaProductos = Nothing
            ListaVentasTurno = Nothing
            ListaFormasPago = Nothing
            ListaSurtidores = Nothing
            ListaFinancieras = Nothing
            ListaMangueras = Nothing
            ListaLecturas = Nothing
        End Try
    End Sub

    Public Shared Sub ImprimirTurno(ByVal cedula As String, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper
        Try
            'Primero recupero el idturno, segun el empleado
            Dim IdTurno As String = OHelper.RecuperarTurnoAbiertoPorEmpleado(cedula)

            ImprimirTurno(CInt(IdTurno), impresora)

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedula", "Cedula: " & cedula & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedula", "Cedula: " & cedula & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedula", "Cedula: " & cedula & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedula", "Cedula: " & cedula & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirTurno(ByVal surtidor As Byte, ByVal turno As Byte, ByVal fecha As String, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper

        Try
            'Primero recupero el idturno
            Dim Turnos As IDataReader = OHelper.RecuperarTurnoPorSurtidor(turno, surtidor, fecha)

            While Turnos.Read
                ImprimirTurno(CInt(Turnos.Item("IdTurno").ToString), impresora)
            End While
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTurnoSurtidorTurno", "Surtidor: " & surtidor & ", Turno: " & turno.ToString & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTurnoSurtidorTurno", "Surtidor: " & surtidor & ", Turno: " & turno.ToString & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTurnoSurtidorTurno", "Surtidor: " & surtidor & ", Turno: " & turno.ToString & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTurnoSurtidorTurno", "Surtidor: " & surtidor & ", Turno: " & turno.ToString & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirTurno(ByVal cedula As String, ByVal fecha As String, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper

        Try
            'Primero recupero el idturno
            Dim Turnos As IDataReader = OHelper.RecuperarTurnoPorEmpleadoFecha(cedula, fecha)

            While (Turnos.Read)
                ImprimirTurno(CInt(Turnos.Item("IdTurno").ToString), impresora)
            End While
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedulaFecha", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedulaFecha", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedulaFecha", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTurnoPorCedulaFecha", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirTurnoFrecuencia(ByVal cedula As String, ByVal fecha As String, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper

        Try
            Dim Turnos As IDataReader = OHelper.RecuperarTurnoPorEmpleadoFecha(cedula, fecha)

            While (Turnos.Read)
                impresora.ESCopia = True
                ImprimirTurnoPagoFrecuencia(CInt(Turnos.Item("IdTurno").ToString), impresora)
            End While
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTurnoFrecuencia", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTurnoFrecuencia", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTurnoFrecuencia", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTurnoFrecuencia", "Cedula: " & cedula & ", Fecha: " & fecha & ", Impresora: " & impresora.Nombre, "ImpresionTurnos")
            Throw
        End Try
    End Sub

    Public Shared Sub ImprimirMensaje(ByVal texto As String, ByVal impresora As ImpresoraEstacion)
        Try

            Dim Fecha As String

            '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
            Fecha = Now.ToString("HHmmss")

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempFacturas") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempFacturas")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempFacturas\Mensaje" & Fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Mensaje" & Fecha & ".txt")
            End If

            '--------------------------INICIA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempFacturas\Mensaje" & Fecha & ".txt")
                Dim PorcionTexto As String

                '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(" ")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "RESPUESTA"))
                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")

                PorcionTexto = texto
                While PorcionTexto.Length > 39
                    SW.WriteLine(PorcionTexto.Substring(0, 39))
                    PorcionTexto = PorcionTexto.Substring(39)
                End While

                SW.WriteLine(PorcionTexto)
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
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempFacturas\Mensaje" & Fecha & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Mensaje" & Fecha & ".txt")
            End Using

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirMensaje", "Impresora: " & impresora.Nombre, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirMensaje", "Impresora: " & impresora.Nombre, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirMensaje", "Impresora: " & impresora.Nombre, "ImpresionCanastilla")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirMensaje", "Impresora: " & impresora.Nombre, "ImpresionCanastilla")
            Throw
        End Try
    End Sub

    Private Shared Function RecuperarEncabezado() As InformacionEncabezado
        Dim OHelper As New Helper
        Dim OInfo As New InformacionEncabezado
        Try
            Dim Datos As IDataReader = OHelper.RecuperarEncabezadoReporte()
            If Datos.Read Then
                OInfo.NombreEstacion = Datos("NombreEstacion").ToString
                OInfo.Direccion = Datos("Direccion").ToString
                OInfo.Nit = Datos("Nit").ToString
                OInfo.Telefono = Datos("Telefono").ToString
            End If

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
        Return OInfo
    End Function


    Public Shared Sub ImprimirTurnoPagoFrecuencia(ByVal turno As Int32, ByVal impresora As ImpresoraEstacion, Optional EsAuditoria As Boolean = False)
        Try
            Dim OTurno As IDataReader
            Dim OHelper As New Helper
            Dim OResultadoDatos As IDataReader

            OTurno = OHelper.RecuperarTurnoPagoFrecuencias(turno)

            If OTurno.Read Then
                If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
                End If

                If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\TurnoFrecuencia" & turno.ToString() & ".txt") Then
                    File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\TurnoFrecuencia" & turno.ToString() & ".txt")
                End If

                Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\TurnoFrecuencia" & turno.ToString() & ".txt")

                    '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                    Dim OEncabezado As InformacionEncabezado
                    OEncabezado = RecuperarEncabezado()

                    SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                    SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                    SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                    SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                    SW.WriteLine(" ")
                    SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                    SW.WriteLine(" ")

                    If Not EsAuditoria Then
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(CentrarTexto(40, "CIERRE DE TURNO FRECUENCIAS"))
                        SW.WriteLine("---------------------------------------")
                    Else
                        SW.WriteLine("---------------------------------------")
                        SW.WriteLine(CentrarTexto(40, "ARQUEO DE TURNO FRECUENCIAS"))
                        SW.WriteLine("---------------------------------------")
                    End If


                    If impresora.ESCopia Then
                        SW.WriteLine(CentrarTexto(40, "COPIA"))
                        SW.WriteLine("---------------------------------------")
                    End If
                    SW.WriteLine(DobleColumna(22, "Apertura: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OTurno.Item("Apertura").ToString()).ToString("HH:mm")))
                    If System.DBNull.Value.Equals(OTurno.Item("Apertura")) Then
                        SW.WriteLine(DobleColumna(22, "Cierre: " & Date.Parse(OTurno.Item("Cierre").ToString()).ToString("dd/MM/yyyy"), "Hora: " & Date.Parse(OTurno.Item("Cierre").ToString()).ToString("HH:mm")))
                    Else
                        SW.WriteLine(DobleColumna(22, "Cierre: ", ""))
                    End If

                    SW.WriteLine("Islero: " & OTurno.Item("Nombre").ToString())
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(" ")

                    '-------------------OBTIENE LOS PAGOS REALIZADOS POR TURNO----------------------------------
                    OResultadoDatos = OHelper.RecuperarRecaudosInfoTaxiPorTurno(turno)
                    Dim total As Decimal = 0
                    If OResultadoDatos.Read Then
                        SW.WriteLine("****************************************")
                        SW.WriteLine(CentrarTexto(40, "PAGOS DE FRECUENCIAS"))
                        SW.WriteLine("****************************************")
                        SW.WriteLine(TripleColumnaLecturas("Consecutivo", "Placa", "Valor"))
                        SW.WriteLine("========================================")
                        total = total + OResultadoDatos.Item("ValorPagado")
                        SW.WriteLine(TripleColumnaLecturas(OResultadoDatos.Item("IdRecaudoLocal").ToString(), OResultadoDatos.Item("Placa").ToString().ToUpper, CDbl(OResultadoDatos.Item("ValorPagado")).ToString("N2")))
                        While OResultadoDatos.Read
                            SW.WriteLine(TripleColumnaLecturas(OResultadoDatos.Item("IdRecaudoLocal").ToString(), OResultadoDatos.Item("Placa").ToString().ToUpper, CDbl(OResultadoDatos.Item("ValorPagado")).ToString("N2")))
                            total = total + OResultadoDatos.Item("ValorPagado")
                        End While
                        SW.WriteLine("========================================")
                        SW.WriteLine("TOTAL: " & total.ToString())
                    End If

                    OResultadoDatos.Close()
                    OResultadoDatos = Nothing

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
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\TurnoFrecuencia" & turno.ToString() & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\TurnoFrecuencia" & turno.ToString() & ".txt")
            End If
            OTurno.Close()
            OTurno = Nothing
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirTurnoPagoFrecuencia", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirTurnoPagoFrecuencia", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirTurnoPagoFrecuencia", "Turno: " & turno.ToString, "ImpresionTurnos")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirTurnoPagoFrecuencia", "Turno: " & turno.ToString, "ImpresionTurnos")
        End Try
    End Sub

#Region "Impresiones de funcionalidad de inventarios"
    Public Shared Sub ImprimirStocksTurno(ByVal newId As String, ByVal impresora As ImpresoraEstacion)
        Dim OHelper As New Helper
        Dim OStocks As IDataReader = Nothing
        Dim EsImpresoEncabezadoSeccion As Boolean = False

        Try

            '---------------CREO EL DIRECTORIO SI EXISTE Y ELIMINO EL ARCHIVO SI EXISTE----------------------------
            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempTurnos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempTurnos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempTurnos\StocksTurno" & newId & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\StocksTurno" & newId & ".txt")
            End If

            '--------------------------INICA LA CONSTRUCCION DEL REPORTE----------------------------------------------------------
            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempTurnos\StocksTurno" & newId & ".txt")

                '-------------------RECUPERO E IMPRIMO EL ENCABEZADO CON LOS DATOS DE LA ESTACION----------------------------------
                Dim OEncabezado As InformacionEncabezado
                OEncabezado = RecuperarEncabezado()

                SW.WriteLine(CentrarTexto(40, OEncabezado.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Nit))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Direccion))
                SW.WriteLine(CentrarTexto(40, OEncabezado.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("Fecha Sistema: " & Now.ToString("dd/MM/yyyy hh:mmm:ss"))
                SW.WriteLine(" ")

                '-------------------IMPRIME LOS TOTALES POR TANQUE----------------------------------
                SW.WriteLine("========================================")
                SW.WriteLine(CentrarTexto(40, "CIERRE DE TANQUES EN TURNO"))
                SW.WriteLine("========================================")

                OStocks = OHelper.RecuperarStocksTurnoHorario(newId)

                EsImpresoEncabezadoSeccion = False
                While (OStocks.Read)
                    If Not EsImpresoEncabezadoSeccion Then
                        SW.WriteLine("Fecha: " & OStocks.Item("Fecha").ToString())
                        SW.WriteLine("Numero Turno: " & OStocks.Item("NumeroTurno").ToString())
                        SW.WriteLine("Hora Inicial: " & CDate(OStocks.Item("HoraInicial")).ToString("hh:mmm"))
                        SW.WriteLine("Hora Final: " & CDate(OStocks.Item("HoraFinal")).ToString("hh:mmm"))
                        If Not OStocks.Item("Empleado") Is System.DBNull.Value Then
                            SW.WriteLine("Empleado: " & OStocks.Item("Empleado").ToString())
                        End If
                        SW.WriteLine(" ")
                        SW.WriteLine(" ")
                        SW.WriteLine("----------------------------------------")
                        SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("Tanque", "Cantidad"))
                        SW.WriteLine("----------------------------------------")
                        EsImpresoEncabezadoSeccion = True
                    End If

                    SW.WriteLine(DobleColumnaNumerica(OStocks.Item("Tanque").ToString(), OStocks.Item("Stock").ToString()))
                End While

                OStocks.Close()

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

                '-------------------------------IMPRIMO EL ARCHIVO Y LO ELIMINO POSTERIORMENTE--------------------------------------
                AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempTurnos\StocksTurno" & newId & ".txt", impresora.Nombre)
                File.Delete(My.Application.Info.DirectoryPath & "\TempTurnos\StocksTurno" & newId & ".txt")
            End Using

        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirStocksTurno", "Fecha: " & newId & ", Impresora: " & impresora.Nombre, "ImpresionStocks")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirStocksTurno", "Fecha: " & newId & ", Impresora: " & impresora.Nombre, "ImpresionStocks")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirStocksTurno", "Fecha: " & newId & ", Impresora: " & impresora.Nombre, "ImpresionStocks")
        Catch ex As System.Exception
            LogFallas.ReportarError(ex, "ImprimirStocksTurno", "Fecha: " & newId & ", Impresora: " & impresora.Nombre, "ImpresionStocks")
            Throw
        End Try
    End Sub
#End Region
End Class
#End Region

