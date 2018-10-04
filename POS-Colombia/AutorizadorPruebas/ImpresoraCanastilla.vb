Imports POSstation.AccesoDatos
Imports System.IO
Imports POSstation.Fabrica



#Region "Canastilla"

Public Class ImpresoraCanastilla
    Inherits FormatoImpresora

    Private Shared LogFallas As New EstacionException

    Public Shared Sub ImprimirFactura(ByVal factura As Int32, ByVal impresora As ImpresoraEstacion, Optional ByVal nroTarjeta As String = "", Optional ByVal saldo As String = "")
        Try
            Dim OVenta As InformacionFactura
            Dim oImpuestos As New List(Of IImpuesto)

            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))


            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempFacturas") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempFacturas")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt")
                Dim Iva As Double = -1
                Dim SumaIvaPorTipoIva As Double = 0, SumaIva As Double = 0
                Dim SumaValorAntesDeIvaPorTipoIva As Double = 0, SumaValorAntesDeIva As Double = 0
                Dim SumaTotalValorAntesDeIva As Double = 0, SumaTotalValorIva As Double = 0
                Dim SubTotal As Double = 0
                Dim ValorAntesDeIva As Int64 = 0
                Dim ValorIva As Int64 = 0
                Dim TipoIva As String = ""
                Dim ODetalle As IDataReader
                Dim TextoIva As New System.Text.StringBuilder
                Dim MensajeEstatico As New System.Text.StringBuilder
                Dim OResultados As IDataReader = Nothing

                OVenta = RecuperarFactura(factura)

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OVenta.Nit))
                SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))
                SW.WriteLine(CentrarTexto(40, "COD " & OVenta.Codigo))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Factura de venta No: " & OVenta.Prefijo & "-" & OVenta.Numero)
                SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Fecha, "Hora: " & OVenta.Hora.Trim))

                'If Not CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVenta")) Then
                '    SW.WriteLine("Atendido Por: " & OVenta.Cedula)
                'Else
                '    SW.WriteLine("Empleado: " & OVenta.Empleado)
                'End If

                If CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVentaCanastilla")) Then
                    SW.WriteLine(OHelper.RecuperarParametro("LeyendaNombreEmpleadoenVentaCanastilla") & OVenta.Empleado)
                End If

                SW.WriteLine("Cedula: " & OVenta.Cedula)
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DETALLE FACTURA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(SextaColumnaDetalleFactura("Cod", "TI", "Producto", "Cant", "Precio", "Total"))

                ODetalle = OHelper.RecuperarFacturaDetalle(factura)
                Dim Compra As Double
                While ODetalle.Read
                    If Iva <> CDbl(ODetalle.Item("Iva")) Then
                        'El Pie de grupo se imprime si el IVA es diferente a -1
                        If Iva <> -1 Then
                            Compra = (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva)
                            oImpuestos.Add(New IImpuesto(TipoIva, Iva.ToString, Compra.ToString("N0"), SumaValorAntesDeIvaPorTipoIva.ToString("N0"), SumaIvaPorTipoIva.ToString("N0")))
                            'TextoIva.AppendLine(PentaColumna(TipoIva, Iva.ToString, Compra.ToString("N0"), SumaValorAntesDeIvaPorTipoIva.ToString("N0"), SumaIvaPorTipoIva.ToString("N0")))
                            SumaTotalValorAntesDeIva = SumaTotalValorAntesDeIva + SumaValorAntesDeIvaPorTipoIva
                            SumaTotalValorIva = SumaTotalValorIva + SumaIvaPorTipoIva
                            SumaIvaPorTipoIva = 0 : SumaValorAntesDeIvaPorTipoIva = 0
                        End If
                        Iva = CDbl(ODetalle.Item("Iva").ToString)
                    End If

                    TipoIva = ODetalle.Item("TipoIva").ToString().PadLeft(2, CChar("0"))
                    SW.WriteLine(SextaColumnaDetalleFactura(ODetalle.Item("Codigo").ToString(), TipoIva, ODetalle.Item("Producto").ToString().Trim(), CDbl(ODetalle.Item("Cantidad").ToString).ToString("N2"), CDbl(ODetalle.Item("Precio").ToString).ToString("N0"), CLng((CDbl(ODetalle.Item("Cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString))).ToString("N0")))
                    ValorAntesDeIva = CLng(CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString) / (1 + (Iva / 100)))
                    SubTotal = SubTotal + CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)
                    ValorIva = CLng((CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)) - ValorAntesDeIva)
                    SumaIvaPorTipoIva = SumaIvaPorTipoIva + ValorIva
                    SumaIva = SumaIva + ValorIva
                    SumaValorAntesDeIvaPorTipoIva = SumaValorAntesDeIvaPorTipoIva + ValorAntesDeIva
                    SumaValorAntesDeIva = SumaValorAntesDeIva + ValorAntesDeIva
                End While
                ODetalle.Close()
                ODetalle = Nothing

                'PENDIENTE EN CAMBIAR
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumnaNumerica("SUBTOTAL ", "$ " & SubTotal.ToString("N0")))
                SW.WriteLine(DobleColumnaNumerica("DESCUENTO ", "$ 0"))
                SW.WriteLine(DobleColumnaNumerica("TOTAL ", "$ " & SubTotal.ToString("N0")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DETALLE POR FORMA DE PAGO"))

                SW.WriteLine("---------------------------------------")
                'Modificadas las formas de pago por la nueva tabla de pagos

                OResultados = OHelper.RecuperarFormasPagoFactura(factura)
                While OResultados.Read
                    SW.WriteLine(DobleColumnaNumerica(OResultados.Item("Descripcion").ToString & ": ", "$ " & CDbl(OResultados.Item("Valor")).ToString("N0")))
                End While
                OResultados.Close()
                OResultados = Nothing

                'SW.WriteLine(DobleColumnaNumerica("EFECTIVO ", "$ " & SubTotal.ToString("N0")))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION TARIFAS IVA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(PentaColumnaCanastilla("Tipo", "Tarifa", "Compra", "Base", "IVA"))

                SumaTotalValorAntesDeIva = SumaTotalValorAntesDeIva + SumaValorAntesDeIvaPorTipoIva
                SumaTotalValorIva = SumaTotalValorIva + SumaIvaPorTipoIva

                oImpuestos.Add(New IImpuesto(TipoIva, Iva.ToString, (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva).ToString, SumaValorAntesDeIvaPorTipoIva.ToString, SumaIvaPorTipoIva.ToString))
                For Each oItemImpuesto As IImpuesto In oImpuestos
                    SW.WriteLine(PentaColumnaCanastilla(oItemImpuesto.Tipo, oItemImpuesto.Tarifa, oItemImpuesto.Compra, oItemImpuesto.Base, oItemImpuesto.Iva))
                Next

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(PentaColumnaTotalIva("TOTAL", (SumaTotalValorAntesDeIva + SumaTotalValorIva).ToString("N0"), SumaTotalValorAntesDeIva.ToString("N0"), SumaTotalValorIva.ToString("N0")))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")


                'OResultados = OHelper.RecuperarDatosPrestadorServicio()
                'If OResultados.Read Then
                '    MensajeEstatico.AppendLine(OResultados.Item("RazonSocial").ToString)
                '    MensajeEstatico.AppendLine("NIT: " & OResultados.Item("Nit").ToString)
                '    MensajeEstatico.AppendLine("RESOL DIAN No. " & OResultados.Item("Numero").ToString)
                '    MensajeEstatico.AppendLine("DEL " & CDate(OResultados.Item("Fecha")).ToString("dd/MM/yyyy") & " DEL " & OResultados.Item("Desde").ToString & " AL " & OResultados.Item("Hasta").ToString)
                '    MensajeEstatico.AppendLine(" ")
                '    MensajeEstatico.AppendLine("Somos retenedores de IVA. Somos grandes")
                '    MensajeEstatico.AppendLine("contribuyentes segun resolucion No.10738")
                '    MensajeEstatico.AppendLine("de Diciembre de 2000.")
                '    MensajeEstatico.AppendLine("Somos autoretenedores del impuesto a la")
                '    MensajeEstatico.AppendLine("renta segun resolucion No. 7835 de Sept.")
                '    MensajeEstatico.AppendLine("05 de 2001.")
                '    MensajeEstatico.Append(" ")
                '    SW.WriteLine(MensajeEstatico.ToString)
                '    SW.WriteLine("---------------------------------------")
                'End If
                'OResultados.Close()
                'OResultados = Nothing

                OResultados = OHelper.RecuperarMensajes()
                While OResultados.Read
                    SW.WriteLine(OResultados.Item("Mensaje").ToString)
                    SW.WriteLine("---------------------------------------")
                End While
                OResultados.Close()
                OResultados = Nothing


                If Not String.IsNullOrEmpty(nroTarjeta) Then
                    SW.WriteLine("***************************************")
                    SW.WriteLine(CentrarTexto(40, "RECARGA TARJETAS PREPAGOS"))
                    SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("Tarjeta", "Saldo"))
                    SW.WriteLine(FormatoImpresora.DobleColumnaNumerica(nroTarjeta, saldo))
                    SW.WriteLine("***************************************")
                End If

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

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        End Try
    End Sub

    Public Shared Sub ImprimirInformeDiario(ByVal fecha As String, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OInforme As IDataReader
            Dim OEstacion As InformacionEstacion

            Dim OHelper As New Helper
            ' Dim sTexto As String = CStr(IIf(EsCopia, "COPIA ", ""))

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempFacturas") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempFacturas")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & fecha & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & fecha & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & fecha & ".txt")
                Dim OInformeTemp As IDataReader

                OEstacion = OHelper.RecuperarDatosEstacion()


                SW.WriteLine("----------------------------------------")
                SW.WriteLine(CentrarTexto(40, OEstacion.Nombre))
                SW.WriteLine(CentrarTexto(40, OEstacion.Direccion))
                SW.WriteLine(CentrarTexto(40, OEstacion.Ciudad))
                'SW.WriteLine(CentrarTexto(40, "COD " & OHelper.RecuperarPrestadorServicioActual))
                SW.WriteLine(" ")
                SW.WriteLine("----------------------------------------")

                OInforme = OHelper.RecuperarDatosPrestadorServicio
                If OInforme.Read Then
                    SW.WriteLine("Razon Social:   " & OInforme.Item("RazonSocial").ToString)
                    SW.WriteLine("Nit:   " & OInforme.Item("Nit").ToString)
                End If
                OInforme.Close()
                OInforme = Nothing
                SW.WriteLine(DobleColumna(22, "Fecha: " & Now().ToString("dd/MM/yyyy"), "Hora: " & Now().ToString("HH:mm")))



                'If Not String.IsNullOrEmpty(sTexto) Then
                '    sw.WriteLine(CentrarTexto(40, sTexto))
                '    sw.WriteLine("---------------------------------------")
                'End If

                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "LECTURA DE MAQUINAS REGISTRADORAS"))
                SW.WriteLine("----------------------------------------")

                OInforme = OHelper.RecuperarRegistroPorMaquina(fecha)
                While OInforme.Read
                    SW.WriteLine("MAQUINA:    " & OInforme.Item("Maquina").ToString)
                    SW.WriteLine(" ")
                    SW.WriteLine("Factura Inicial: " & OInforme.Item("FacturaInicial").ToString)
                    SW.WriteLine("Factura Final: " & OInforme.Item("FacturaFinal").ToString)
                    SW.WriteLine(" ")
                End While
                OInforme.Close()
                OInforme = Nothing


                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION POR TERMINAL"))
                SW.WriteLine("----------------------------------------")

                OInforme = OHelper.RecuperarDiscriminacionTerminal(fecha)
                While OInforme.Read
                    SW.WriteLine("MAQUINA:    " & OInforme.Item("Maquina").ToString)
                    SW.WriteLine(" ")
                    SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("Cantidad: " & CDbl(OInforme.Item("Cantidad")).ToString("N0"), "Total: " & CDbl(OInforme.Item("Total")).ToString("N0")))
                    SW.WriteLine(" ")
                End While
                OInforme.Close()
                OInforme = Nothing

                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "TOTALES POR FORMA DE PAGO"))
                SW.WriteLine("----------------------------------------")

                OInforme = OHelper.RecuperarTotalesPorFormaPago(fecha)
                While OInforme.Read
                    SW.WriteLine(OInforme.Item("FormaPago").ToString.ToUpper & ":")
                    SW.WriteLine(" ")
                    SW.WriteLine(DobleColumnaNumerica("Cantidad: " & CDbl(OInforme.Item("Cantidad")).ToString("N0"), "Total: " & CDbl(OInforme.Item("Total")).ToString("N0")))
                    SW.WriteLine(" ")
                End While
                OInforme.Close()
                OInforme = Nothing

                SW.WriteLine("----------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION POR TIPO DE IVA"))

                OInforme = OHelper.RecuperarTipoIvaTarifa()
                While OInforme.Read
                    OInformeTemp = OHelper.RecuperarPagosPorTarifaIva(fecha, CInt(OInforme.Item("TipoIva").ToString))
                    If OInformeTemp.Read Then
                        SW.WriteLine("----------------------------------------")
                        SW.WriteLine("TIPO DE IVA:    " & OInforme.Item("Tarifa").ToString & " %")
                        SW.WriteLine("----------------------------------------")
                        SW.WriteLine(FormatoImpresora.TripleColumnaLecturas("Factura", "Valor", "Descuento"))
                        SW.WriteLine(FormatoImpresora.TripleColumnaLecturas(OInformeTemp.Item("Factura").ToString, CDbl(OInformeTemp.Item("Valor")).ToString("N2"), CDbl(OInformeTemp.Item("Descuento")).ToString("N2")))

                        While (OInformeTemp.Read)
                            SW.WriteLine(FormatoImpresora.TripleColumnaLecturas(OInformeTemp.Item("Factura").ToString, CDbl(OInformeTemp.Item("Valor")).ToString("N2"), CDbl(OInformeTemp.Item("Descuento")).ToString("N2")))
                        End While
                        SW.WriteLine(" ")
                    End If
                    OInformeTemp.Close()
                    OInformeTemp = Nothing
                End While
                OInforme.Close()
                OInforme = Nothing

                SW.WriteLine("----------------------------------------")
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

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & fecha & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & fecha & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirInformeDiario", "Fecha: " & fecha, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirInformeDiario", "Fecha: " & fecha, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirInformeDiario", "Fecha: " & fecha, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "ImprimirInformeDiario", "Fecha: " & fecha, "ImpresionCanastilla")
        End Try

    End Sub

    Public Shared Sub ImprimirNotaCredito(ByVal factura As Int32, ByVal impresora As ImpresoraEstacion, Optional ByVal EsTerpel As Boolean = False)
        Try
            Dim OVenta As IDataReader

            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))


            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempFacturas") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempFacturas")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempFacturas\FacturaNotaCredito" & factura.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\FacturaNotaCredito" & factura.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempFacturas\FacturaNotaCredito" & factura.ToString() & ".txt")
                Dim Iva As Double = -1
                Dim SumaIvaPorTipoIva As Double = 0, SumaIva As Double = 0
                Dim SumaValorAntesDeIvaPorTipoIva As Double = 0, SumaValorAntesDeIva As Double = 0
                Dim SumaTotalValorAntesDeIva As Double = 0, SumaTotalValorIva As Double = 0
                Dim SubTotal As Double = 0
                Dim ValorAntesDeIva As Int64 = 0
                Dim ValorIva As Int64 = 0
                Dim TipoIva As String = ""
                Dim ODetalle As IDataReader
                Dim TextoIva As New System.Text.StringBuilder
                Dim AnulacionFactura As String = " "

                OVenta = OHelper.RecuperarNotaCredito(factura, EsTerpel)
                If OVenta.Read Then
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine(CentrarTexto(40, OVenta.Item("NombreEstacion").ToString))
                    SW.WriteLine(CentrarTexto(40, OVenta.Item("Direccion").ToString))
                    SW.WriteLine(CentrarTexto(40, OVenta.Item("Ciudad").ToString))
                    ' SW.WriteLine(CentrarTexto(40, "COD " & IIf(String.IsNullOrEmpty(OHelper.RecuperarPrestadorServicioActual()),"",OHelper.RecuperarPrestadorServicioActual())
                    SW.WriteLine(" ")
                    SW.WriteLine("---------------------------------------")
                    SW.WriteLine("Nota Credito: " & OVenta.Item("NotaCredito").ToString)
                    SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Item("Fecha").ToString, "Hora: " & OVenta.Item("Hora").ToString.Trim))

                    If CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVentaCanastilla")) Then
                        SW.WriteLine(OHelper.RecuperarParametro("LeyendaNombreEmpleadoenVentaCanastilla") & OVenta.Item("Empleado").ToString())
                    End If

                    SW.WriteLine("Cedula: " & OVenta.Item("Cedula").ToString())
                    'SW.WriteLine("Empleado: " & OVenta.Item("Empleado").ToString)

                    SW.WriteLine("---------------------------------------")
                    AnulacionFactura = OVenta.Item("Numero").ToString
                End If
                OVenta.Close()
                OVenta = Nothing

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If


                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DETALLE FACTURA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(SextaColumnaDetalleFactura("Cod", "TI", "Producto", "Cant", "Precio", "Total"))

                ODetalle = OHelper.RecuperarFacturaDetalle(factura, EsTerpel)
                Dim Compra As Double
                While ODetalle.Read
                    If Iva <> CDbl(ODetalle.Item("Iva")) Then
                        'El Pie de grupo se imprime si el IVA es diferente a -1
                        If Iva <> -1 Then
                            Compra = (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva)
                            TextoIva.AppendLine(PentaColumna(TipoIva, Iva.ToString, Compra.ToString, SumaValorAntesDeIvaPorTipoIva.ToString, SumaIvaPorTipoIva.ToString))
                            SumaTotalValorAntesDeIva = SumaTotalValorAntesDeIva + SumaValorAntesDeIvaPorTipoIva
                            SumaTotalValorIva = SumaTotalValorIva + SumaIvaPorTipoIva
                            SumaIvaPorTipoIva = 0 : SumaValorAntesDeIvaPorTipoIva = 0
                        End If
                        Iva = CDbl(ODetalle.Item("Iva").ToString)
                    End If

                    TipoIva = ODetalle.Item("TipoIva").ToString().PadLeft(2, CChar("0"))
                    SW.WriteLine(SextaColumnaDetalleFactura(ODetalle.Item("Codigo").ToString(), TipoIva, ODetalle.Item("Producto").ToString().Trim(), CDbl(ODetalle.Item("Cantidad").ToString).ToString("N2"), CDbl(ODetalle.Item("Precio").ToString).ToString("N0"), CLng((CDbl(ODetalle.Item("Cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString))).ToString("N0")))
                    ValorAntesDeIva = CLng(CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString) / (1 + (Iva / 100)))
                    SubTotal = SubTotal + CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)
                    ValorIva = CLng((CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)) - ValorAntesDeIva)
                    SumaIvaPorTipoIva = SumaIvaPorTipoIva + ValorIva
                    SumaIva = SumaIva + ValorIva
                    SumaValorAntesDeIvaPorTipoIva = SumaValorAntesDeIvaPorTipoIva + ValorAntesDeIva
                    SumaValorAntesDeIva = SumaValorAntesDeIva + ValorAntesDeIva
                End While
                ODetalle.Close()
                ODetalle = Nothing

                'PENDIENTE EN CAMBIAR
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumnaNumerica("SUBTOTAL ", "$ " & SubTotal.ToString("N0")))
                SW.WriteLine(DobleColumnaNumerica("DESCUENTO ", "$ 0"))
                SW.WriteLine(DobleColumnaNumerica("TOTAL ", "$ " & SubTotal.ToString("N0")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION TARIFAS IVA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(PentaColumnaCanastilla("Tipo", "Tarifa", "Compra", "Base", "IVA"))

                SumaTotalValorAntesDeIva = SumaTotalValorAntesDeIva + SumaValorAntesDeIvaPorTipoIva
                SumaTotalValorIva = SumaTotalValorIva + SumaIvaPorTipoIva

                TextoIva.AppendLine(PentaColumnaCanastilla(TipoIva, Iva.ToString, (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva).ToString, SumaValorAntesDeIvaPorTipoIva.ToString, SumaIvaPorTipoIva.ToString))

                SW.Write(TextoIva.ToString())
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(PentaColumnaTotalIva("TOTAL", (SumaTotalValorAntesDeIva + SumaTotalValorIva).ToString("N0"), SumaTotalValorAntesDeIva.ToString("N0"), SumaTotalValorIva.ToString("N0")))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Anulacion Factura: " & AnulacionFactura)
                SW.WriteLine("---------------------------------------")
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

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempFacturas\FacturaNotaCredito" & factura.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\FacturaNotaCredito" & factura.ToString() & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirNotaCredito", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirNotaCredito", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirNotaCredito", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "ImprimirNotaCredito", "Factura: " & factura.ToString, "ImpresionCanastilla")
            Throw
        End Try
    End Sub

    Private Shared Function RecuperarFactura(ByVal factura As Int32, Optional ByVal EsInvLiquido As Boolean = False) As InformacionFactura
        Dim OHelper As New Helper
        Dim Resultado As New InformacionFactura
        Try
            If Not EsInvLiquido Then
                Dim OFactura As IDataReader = OHelper.RecuperarFacturaParaImpresion(factura)
                If OFactura.Read Then
                    Resultado.Ciudad = OFactura.Item("Ciudad").ToString()
                    Resultado.Direccion = OFactura.Item("Direccion").ToString()
                    Resultado.Empleado = OFactura.Item("Empleado").ToString()
                    Resultado.Fecha = OFactura.Item("Fecha").ToString()
                    Resultado.Hora = OFactura.Item("Hora").ToString()
                    Resultado.Nit = OFactura.Item("Nit").ToString()
                    Resultado.NombreEstacion = OFactura.Item("NombreEstacion").ToString()
                    Resultado.Numero = OFactura.Item("Numero").ToString()
                    Resultado.Prefijo = OFactura.Item("Prefijo").ToString()
                    Resultado.Telefono = OFactura.Item("Telefono").ToString()
                    Resultado.Total = CDbl(OFactura.Item("Total")).ToString("N0")
                    Resultado.Cedula = OFactura.Item("Cedula").ToString()
                    Resultado.Codigo = "" 'OHelper.RecuperarPrestadorServicioActual()
                End If

                OFactura.Close()
                OFactura.Dispose()
            Else
                Dim oFacCanastilla As IDataReader = OHelper.RecuperarFacturaInvLiquido(factura)

                If oFacCanastilla.Read Then
                    Resultado.Ciudad = oFacCanastilla.Item("Ciudad").ToString()
                    Resultado.Direccion = oFacCanastilla.Item("Direccion").ToString()
                    Resultado.Empleado = oFacCanastilla.Item("Empleado").ToString()
                    Resultado.Fecha = oFacCanastilla.Item("Fecha").ToString()
                    Resultado.Hora = oFacCanastilla.Item("Hora").ToString()
                    Resultado.Nit = oFacCanastilla.Item("Nit").ToString()
                    Resultado.NombreEstacion = oFacCanastilla.Item("NombreEstacion").ToString()
                    Resultado.Numero = oFacCanastilla.Item("Numero").ToString()
                    Resultado.Prefijo = oFacCanastilla.Item("Prefijo").ToString()
                    Resultado.Telefono = oFacCanastilla.Item("Telefono").ToString()
                    Resultado.Total = CDbl(oFacCanastilla.Item("Total")).ToString("N0")
                    Resultado.Codigo = "" 'OHelper.RecuperarPrestadorServicioActual()
                    Resultado.ClasificacionCliente = oFacCanastilla.Item("ClasificacionCliente").ToString()
                    Resultado.IdentificacionCliente = oFacCanastilla.Item("IdentificacionCliente").ToString()
                    Resultado.Cliente = oFacCanastilla.Item("Cliente").ToString()
                    Resultado.Cedula = oFacCanastilla.Item("Cedula").ToString()
                    Resultado.FechaInicio = oFacCanastilla.Item("FechaInicio").ToString()
                    Resultado.FechaFin = oFacCanastilla.Item("FechaFin").ToString()
                    'Resultado.AtendidoPor = oFacCanastilla.Item("Atendido").ToString
                    'Resultado.CodigoVendedor = oFacCanastilla.Item("CodigoVendedor").ToString



                    If oFacCanastilla.Item("ClienteCredito") Is System.DBNull.Value Then
                        Resultado.ClienteCredito = Nothing
                    Else
                        Resultado.ClienteCredito = oFacCanastilla.Item("ClienteCredito").ToString
                    End If
                End If

                oFacCanastilla.Close()
                oFacCanastilla.Dispose()
            End If
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "RecuperarFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "RecuperarFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "RecuperarFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
            Throw
        End Try
        Return Resultado
    End Function

#Region "Impresiones nueva funcionalidad de facturas"
    Public Shared Sub ImprimirFacturaCanastilla(ByVal factura As Int64, ByVal impresora As ImpresoraEstacion, Optional ByVal EsInvLiquido As Boolean = False, Optional ByVal EsCopia As Boolean = False)
        Try
            Dim OVenta As InformacionFactura
            Dim oImpuestos As New List(Of IImpuesto)

            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(EsCopia, "COPIA ", ""))


            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempFacturas") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempFacturas")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt")
                Dim Iva As Double = -1
                Dim SumaIvaPorTipoIva As Double = 0, SumaIva As Double = 0
                Dim SumaValorAntesDeIvaPorTipoIva As Double = 0, SumaValorAntesDeIva As Double = 0
                Dim SumaTotalValorAntesDeIva As Double = 0, SumaTotalValorIva As Double = 0
                Dim SubTotal As Double = 0, DescuentoTotal As Double = 0
                Dim ValorAntesDeIva As Int64 = 0
                Dim ValorIva As Int64 = 0
                Dim TipoIva As String = ""
                Dim ODetalle As IDataReader
                Dim TextoIva As New System.Text.StringBuilder
                Dim MensajeEstatico As New System.Text.StringBuilder
                Dim OResultados As IDataReader = Nothing
                Dim Parrafo As List(Of String)

                OVenta = RecuperarFactura(CInt(factura), True)

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OVenta.Nit))
                SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))
                SW.WriteLine(CentrarTexto(40, OVenta.Telefono))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Factura de venta No: " & OVenta.Prefijo & "-" & OVenta.Numero)

                If Not String.IsNullOrEmpty(OVenta.ClienteCredito) Then
                    OVenta.ClienteCredito = "Cliente: " & OVenta.ClienteCredito
                    Parrafo = SeccionarParrafo(OVenta.ClienteCredito)
                    For Each Linea As String In Parrafo
                        SW.WriteLine(Linea)
                    Next
                    Parrafo.Clear()
                End If

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Fecha, "Hora: " & OVenta.Hora.Trim))

                'If Not CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVenta")) Then
                '    SW.WriteLine("Atendido Por: " & OVenta.Cedula)
                'Else
                '    SW.WriteLine("Empleado: " & OVenta.Empleado)
                'End If

                If CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVentaCanastilla")) Then
                    SW.WriteLine(OHelper.RecuperarParametro("LeyendaNombreEmpleadoenVentaCanastilla") & OVenta.Empleado)
                End If

                SW.WriteLine("Cedula: " & OVenta.Cedula)
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "Nombre del Producto y/o Servicio"))
                ''    SW.WriteLine(SextaColumnaDetalleFactura("Cod", "TI", "Cant", "Precio", "% Desc.", "Total"))
                ''  SW.WriteLine("---------------------------------------")

                Dim Compra As Double
                ODetalle = OHelper.RecuperarFacturaDetalleInvLiquido(CInt(factura))
                While ODetalle.Read

                    SW.WriteLine("Producto: " & ODetalle.Item("Producto").ToString())
                    SW.WriteLine(SextaColumnaDetalleFactura("Cod", "TI", "Cant", "Precio", "% Desc.", "Total"))

                    If Iva <> CDbl(ODetalle.Item("Iva")) Then
                        'El Pie de grupo se imprime si el IVA es diferente a -1
                        If Iva <> -1 Then
                            Compra = (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva)
                            'TextoIva.App endLine(PentaColumna(TipoIva, Iva.ToString, Compra.ToString("N0"), SumaValorAntesDeIvaPorTipoIva.ToString("N0"), SumaIvaPorTipoIva.ToString("N0")))
                            oImpuestos.Add(New IImpuesto(TipoIva, Iva.ToString, Compra.ToString("N0"), SumaValorAntesDeIvaPorTipoIva.ToString("N0"), SumaIvaPorTipoIva.ToString("N0")))
                            SumaTotalValorAntesDeIva = SumaTotalValorAntesDeIva + SumaValorAntesDeIvaPorTipoIva
                            SumaTotalValorIva = SumaTotalValorIva + SumaIvaPorTipoIva
                            SumaIvaPorTipoIva = 0 : SumaValorAntesDeIvaPorTipoIva = 0
                        End If
                        Iva = CDbl(ODetalle.Item("Iva").ToString)
                    End If

                    TipoIva = ODetalle.Item("TipoIva").ToString().PadLeft(2, CChar("0"))
                    SW.WriteLine(SextaColumnaDetalleFactura(ODetalle.Item("Codigo").ToString(), TipoIva, CDbl(ODetalle.Item("Cantidad").ToString).ToString("N2"), CDbl(ODetalle.Item("Precio").ToString).ToString("N0"), CDbl(ODetalle.Item("PorcentajeDescuento")).ToString("N2"), CLng((CDbl(ODetalle.Item("Cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString))).ToString("N0")))
                    SW.WriteLine("---------------------------------------")
                    ValorAntesDeIva = CLng(CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString) / (1 + (Iva / 100)))
                    SubTotal = SubTotal + CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)
                    ValorIva = CLng((CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)) - ValorAntesDeIva)
                    SumaIvaPorTipoIva = SumaIvaPorTipoIva + ValorIva
                    SumaIva = SumaIva + ValorIva
                    SumaValorAntesDeIvaPorTipoIva = SumaValorAntesDeIvaPorTipoIva + ValorAntesDeIva
                    SumaValorAntesDeIva = SumaValorAntesDeIva + ValorAntesDeIva
                    DescuentoTotal = DescuentoTotal + CDbl(ODetalle.Item("Descuento"))
                End While
                ODetalle.Close()
                ODetalle = Nothing

                'PENDIENTE EN CAMBIAR
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumnaNumerica("SUBTOTAL ", "$ " & SubTotal.ToString("N0")))
                SW.WriteLine(DobleColumnaNumerica("DESCUENTO ", "$ " & DescuentoTotal.ToString("N0")))
                SW.WriteLine(DobleColumnaNumerica("TOTAL ", "$ " & (SubTotal - DescuentoTotal).ToString("N0")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DETALLE POR FORMA DE PAGO"))
                SW.WriteLine("---------------------------------------")
                OResultados = OHelper.RecuperarFormasPagoFacturaInvLiquido(CInt(factura))
                While OResultados.Read
                    SW.WriteLine(DobleColumnaNumerica(OResultados.Item("Descripcion").ToString & ": ", "$ " & CDbl(OResultados.Item("Valor")).ToString("N0")))
                End While
                OResultados.Close()
                OResultados = Nothing

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DISCRIMINACION TARIFAS IVA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(PentaColumnaCanastilla("Tipo", "Tarifa", "Compra", "Base", "IVA"))

                SumaTotalValorAntesDeIva = SumaTotalValorAntesDeIva + SumaValorAntesDeIvaPorTipoIva
                SumaTotalValorIva = SumaTotalValorIva + SumaIvaPorTipoIva

                'TextoIva.AppendLine(PentaColumnaCanastilla(TipoIva, Iva.ToString, (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva).ToString, SumaValorAntesDeIvaPorTipoIva.ToString, SumaIvaPorTipoIva.ToString))
                'SW.Write(TextoIva.ToString())
                oImpuestos.Add(New IImpuesto(TipoIva, Iva.ToString, (SumaValorAntesDeIvaPorTipoIva + SumaIvaPorTipoIva).ToString, SumaValorAntesDeIvaPorTipoIva.ToString, SumaIvaPorTipoIva.ToString))
                For Each oItemImpuesto As IImpuesto In oImpuestos
                    SW.WriteLine(PentaColumnaCanastilla(oItemImpuesto.Tipo, oItemImpuesto.Tarifa, oItemImpuesto.Compra, oItemImpuesto.Base, oItemImpuesto.Iva))
                Next


                SW.WriteLine("---------------------------------------")
                SW.WriteLine(PentaColumnaTotalIva("TOTAL", (SumaTotalValorAntesDeIva + SumaTotalValorIva).ToString("N0"), SumaTotalValorAntesDeIva.ToString("N0"), SumaTotalValorIva.ToString("N0")))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")

                'SW.WriteLine("Fecha Expedicion: " & OVenta.FechaInicio)
                'SW.WriteLine("Fecha Vencimiento: " & OVenta.FechaFin)

                Dim ImprimirResolucion As Boolean = True
                Try
                    ImprimirResolucion = CBool(OHelper.RecuperarParametro("ImprimirResolucionCanastilla"))
                Catch ex As System.exception
                    LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
                End Try


                Dim oEncabezado As DataTable = OHelper.RecuperarEncabezadoFacturaCanastilla(CInt(factura))

                'For Each oDataRow As DataRow In oEncabezado.Rows
                '    SW.WriteLine("Resolucion de facturacion #" & oDataRow.Item("Resolucion").ToString())
                '    SW.WriteLine("DEL " & CDate(oDataRow.Item("FechaExpedicion")).ToString("dd/MM/yyyy") & " DEL " & oDataRow.Item("ConsecutivoInicial").ToString() & " AL " & oDataRow.Item("ConsecutivoFinal").ToString())
                '    SW.WriteLine("Gran contribuyente; Res. #" & oDataRow.Item("Contribuyente").ToString())
                '    SW.WriteLine("DEL " & CDate(oDataRow.Item("FechaExpedicionContribuyente")).ToString("dd/MM/yyyy"))
                '    SW.WriteLine("Autoretenedor Res. #" & oDataRow.Item("AutoRetenedor").ToString())
                '    SW.WriteLine("DEL " & CDate(oDataRow.Item("FechaExpedicionAutoRetenedor")).ToString("dd/MM/yyyy"))
                '    SW.WriteLine(oDataRow.Item("Mensaje".ToString()))
                'Next


                For Each oDataRow As DataRow In oEncabezado.Rows
                    SW.WriteLine("Resolucion de facturacion #" & oDataRow.Item("Resolucion").ToString())
                    SW.WriteLine(" DEL " & oDataRow.Item("ConsecutivoInicial").ToString() & " AL " & oDataRow.Item("ConsecutivoFinal").ToString())
                    SW.WriteLine("Fecha Expedicion: " & OVenta.FechaInicio)
                    SW.WriteLine("Fecha Vencimiento: " & OVenta.FechaFin)

                    If ImprimirResolucion Then
                        If Not String.IsNullOrEmpty(oDataRow.Item("Contribuyente").ToString()) And Not oDataRow.Item("Contribuyente") Is System.DBNull.Value Then
                            SW.WriteLine("Gran contribuyente; Res. #" & oDataRow.Item("Contribuyente").ToString())
                            If Not String.IsNullOrEmpty(oDataRow.Item("FechaExpedicionContribuyente").ToString()) And Not oDataRow.Item("FechaExpedicionContribuyente") Is System.DBNull.Value Then
                                SW.WriteLine("DEL " & CDate(oDataRow.Item("FechaExpedicionContribuyente")).ToString("dd/MM/yyyy"))
                            End If

                            If Not String.IsNullOrEmpty(oDataRow.Item("AutoRetenedor").ToString()) And Not oDataRow.Item("AutoRetenedor") Is System.DBNull.Value Then
                                SW.WriteLine("Autoretenedor Res. #" & oDataRow.Item("AutoRetenedor").ToString())
                            End If

                            If Not String.IsNullOrEmpty(oDataRow.Item("FechaExpedicionAutoRetenedor").ToString()) And Not oDataRow.Item("FechaExpedicionAutoRetenedor") Is System.DBNull.Value Then
                                SW.WriteLine("DEL " & CDate(oDataRow.Item("FechaExpedicionAutoRetenedor")).ToString("dd/MM/yyyy"))
                            End If

                            If Not String.IsNullOrEmpty(oDataRow.Item("Mensaje").ToString()) And Not oDataRow.Item("Mensaje") Is System.DBNull.Value Then
                                SW.WriteLine(oDataRow.Item("Mensaje".ToString()))
                            End If
                        End If

                    End If
                Next


                oEncabezado.Clear()
                oEncabezado.Dispose()
                oEncabezado = Nothing


                OResultados = OHelper.RecuperarMensajes()
                While OResultados.Read
                    SW.WriteLine(OResultados.Item("Mensaje").ToString)
                    SW.WriteLine("---------------------------------------")
                End While
                OResultados.Close()
                OResultados = Nothing


                'If Not String.IsNullOrEmpty(nroTarjeta) Then
                '    SW.WriteLine("***************************************")
                '    SW.WriteLine(CentrarTexto(40, "RECARGA TARJETAS PREPAGOS"))
                '    SW.WriteLine(FormatoImpresora.DobleColumnaNumerica("Tarjeta", "Saldo"))
                '    SW.WriteLine(FormatoImpresora.DobleColumnaNumerica(nroTarjeta, saldo))
                '    SW.WriteLine("***************************************")
                'End If

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

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempFacturas\Factura" & factura.ToString() & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "ImprimirFactura", "Factura: " & factura.ToString, "ImpresionCanastilla")
        End Try

    End Sub

    Private Shared Function RecuperarReciboVenta(ByVal recibo As Int32) As InformacionReciboCanastilla
        Dim OHelper As New Helper
        Dim Resultado As New InformacionReciboCanastilla
        Try
            'TODO:Arreglar esto de ReciboCanastilla
            Dim oFacCanastilla As IDataReader = OHelper.RecuperarReciboCanastilla(recibo)

            If oFacCanastilla.Read Then
                Resultado.Ciudad = oFacCanastilla.Item("Ciudad").ToString()
                Resultado.Direccion = oFacCanastilla.Item("Direccion").ToString()
                Resultado.Empleado = oFacCanastilla.Item("Empleado").ToString()
                Resultado.Cedula = oFacCanastilla.Item("Cedula").ToString()
                Resultado.Fecha = oFacCanastilla.Item("Fecha").ToString()
                Resultado.Hora = oFacCanastilla.Item("Hora").ToString()
                Resultado.Nit = oFacCanastilla.Item("Nit").ToString()
                Resultado.NombreEstacion = oFacCanastilla.Item("NombreEstacion").ToString()
                Resultado.Recibo = CInt(oFacCanastilla.Item("Recibo").ToString())
                Resultado.Telefono = oFacCanastilla.Item("Telefono").ToString()
                Resultado.Total = CDbl(oFacCanastilla.Item("Total")).ToString("N0")
                Resultado.Codigo = oFacCanastilla.Item("CodEstacion").ToString() 'OHelper.RecuperarPrestadorServicioActual()
                Resultado.ClasificacionCliente = oFacCanastilla.Item("ClasificacionCliente").ToString()
                Resultado.IdentificacionCliente = oFacCanastilla.Item("IdentificacionCliente").ToString()
                Resultado.Cliente = oFacCanastilla.Item("Cliente").ToString()
                Resultado.FechaInicio = oFacCanastilla.Item("FechaInicio").ToString()
                Resultado.FechaFin = oFacCanastilla.Item("FechaFin").ToString()
                If oFacCanastilla.Item("ClienteCredito") Is System.DBNull.Value Then
                    Resultado.ClienteCredito = Nothing
                Else
                    Resultado.ClienteCredito = oFacCanastilla.Item("ClienteCredito").ToString
                End If
            End If
            oFacCanastilla.Close()
            oFacCanastilla.Dispose()
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "RecuperarReciboVenta", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "RecuperarReciboVenta", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "RecuperarReciboVenta", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "RecuperarReciboVenta", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
            Throw
        End Try

        Return Resultado
    End Function

    Public Shared Sub ImprimirReciboCanastilla(ByVal recibo As Int32, ByVal impresora As ImpresoraEstacion)
        Try
            Dim OVenta As InformacionReciboCanastilla
            Dim Parrafo As List(Of String)
            Dim OHelper As New Helper
            Dim STexto As String = CStr(IIf(impresora.ESCopia, "COPIA ", ""))


            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\TempRecibos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\TempRecibos")
            End If
            If File.Exists(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCanastilla" & recibo.ToString() & ".txt") Then
                File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCanastilla" & recibo.ToString() & ".txt")
            End If

            Using SW As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCanastilla" & recibo.ToString() & ".txt")
                Dim SubTotal As Double = 0, DescuentoTotal As Double = 0
                Dim ODetalle As IDataReader
                Dim OResultados As IDataReader = Nothing

                OVenta = RecuperarReciboVenta(recibo)

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, OVenta.NombreEstacion))
                SW.WriteLine(CentrarTexto(40, OVenta.Nit))
                SW.WriteLine(CentrarTexto(40, OVenta.Direccion))
                SW.WriteLine(CentrarTexto(40, OVenta.Ciudad))
                SW.WriteLine(CentrarTexto(40, "COD " & OVenta.Codigo))
                SW.WriteLine(" ")
                SW.WriteLine("---------------------------------------")
                SW.WriteLine("Nro Recibo: " & OVenta.Recibo)
                SW.WriteLine(DobleColumna(22, "Fecha: " & OVenta.Fecha, "Hora: " & OVenta.Hora.Trim))

                If Not String.IsNullOrEmpty(OVenta.ClienteCredito) Then
                    OVenta.ClienteCredito = "Cliente: " & OVenta.ClienteCredito
                    Parrafo = SeccionarParrafo(OVenta.ClienteCredito)
                    For Each Linea As String In Parrafo
                        SW.WriteLine(Linea)
                    Next
                    Parrafo.Clear()
                End If

                If CBool(OHelper.RecuperarParametro("ImprimirNombreEmpleadoenVentaCanastilla")) Then
                    SW.WriteLine(OHelper.RecuperarParametro("LeyendaNombreEmpleadoenVentaCanastilla") & OVenta.Empleado)
                End If

                SW.WriteLine("Cedula: " & OVenta.Cedula)

                'SW.WriteLine("Empleado: " & OVenta.Empleado)
                SW.WriteLine("---------------------------------------")

                If Not String.IsNullOrEmpty(STexto) Then
                    SW.WriteLine(CentrarTexto(40, STexto))
                    SW.WriteLine("---------------------------------------")
                End If

                'If Not String.IsNullOrEmpty(OVenta.ClasificacionCliente) Then

                '    SW.WriteLine("Identificacion Cliente: " & OVenta.IdentificacionCliente)
                '    SW.WriteLine("Clasificacion Cliente: " & OVenta.ClasificacionCliente)
                '    SW.WriteLine("---------------------------------------")

                'End If

                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DETALLE DE LA VENTA"))
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(CentrarTexto(40, "Nombre del Producto y/o Servicio"))

                'TODO:Arreglar esto de ReciboCanastilla
                ODetalle = OHelper.RecuperarReciboCanastillaDetalle(recibo)
                While ODetalle.Read
                    SW.WriteLine(ODetalle.Item("Producto").ToString().Trim())
                    SW.WriteLine(PentaColumnaCanastilla("Cod", "Cant", "Precio", "% Desc.", "Total"))

                    SW.WriteLine(PentaColumnaCanastilla(ODetalle.Item("Codigo").ToString(), CDbl(ODetalle.Item("Cantidad").ToString).ToString("N2"), CDbl(ODetalle.Item("Precio").ToString).ToString("N0"), CDbl(ODetalle.Item("PorcentajeDescuento")).ToString("N2"), CLng((CDbl(ODetalle.Item("Cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString))).ToString("N0")))
                    SW.WriteLine("---------------------------------------")
                    SubTotal = SubTotal + CDbl(ODetalle.Item("cantidad").ToString) * CDbl(ODetalle.Item("Precio").ToString)
                    DescuentoTotal = DescuentoTotal + CDbl(ODetalle.Item("Descuento"))
                End While
                ODetalle.Close()
                ODetalle = Nothing

                'PENDIENTE EN CAMBIAR
                SW.WriteLine("---------------------------------------")
                SW.WriteLine(DobleColumnaNumerica("SUBTOTAL ", "$ " & SubTotal.ToString("N0")))
                SW.WriteLine(DobleColumnaNumerica("DESCUENTO ", "$ " & DescuentoTotal.ToString("N0")))
                SW.WriteLine(DobleColumnaNumerica("TOTAL ", "$ " & (SubTotal - DescuentoTotal).ToString("N0")))

                SW.WriteLine("---------------------------------------")
                SW.WriteLine(" ")
                SW.WriteLine(CentrarTexto(40, "DETALLE POR FORMA DE PAGO"))

                SW.WriteLine("---------------------------------------")
                'Modificadas las formas de pago por la nueva tabla de pagos

                'TODO:Arreglar esto de ReciboCanastilla
                OResultados = OHelper.RecuperarFormasPagoReciboCanastilla(recibo)
                While OResultados.Read
                    SW.WriteLine(DobleColumnaNumerica(OResultados.Item("Descripcion").ToString & ": ", "$ " & CDbl(OResultados.Item("Valor")).ToString("N0")))
                End While
                OResultados.Close()
                OResultados = Nothing

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

            AsciiToPrinter(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCanastilla" & recibo.ToString() & ".txt", impresora.Nombre)
            File.Delete(My.Application.Info.DirectoryPath & "\TempRecibos\ReciboCanastilla" & recibo.ToString() & ".txt")
        Catch ex As Data.DataException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        Catch ex As Data.SqlClient.SqlException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        Catch ex As IO.IOException
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        Catch ex As System.exception
            LogFallas.ReportarError(ex, "ImprimirRecibo", "Recibo: " & recibo.ToString, "ImpresionCanastilla")
        End Try
    End Sub

#End Region
End Class

Public Class IImpuesto
    Private _Tipo As String
    Private _Tarifa As String
    Private _Compra As String
    Private _Base As String
    Private _Iva As String

    Public Sub New(ByVal Tipo As String, ByVal Tarifa As String, ByVal Compra As String, ByVal Base As String, ByVal Iva As String)
        _Tipo = Tipo : _Tarifa = Tarifa : _Compra = Compra : _Base = Base : _Iva = Iva
    End Sub

    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Public Property Tarifa() As String
        Get
            Return _Tarifa
        End Get
        Set(ByVal value As String)
            _Tarifa = value
        End Set
    End Property

    Public Property Compra() As String
        Get
            Return _Compra
        End Get
        Set(ByVal value As String)
            _Compra = value
        End Set
    End Property

    Public Property Base() As String
        Get
            Return _Base
        End Get
        Set(ByVal value As String)
            _Base = value
        End Set
    End Property

    Public Property Iva() As String
        Get
            Return _Iva
        End Get
        Set(ByVal value As String)
            _Iva = value
        End Set
    End Property

End Class


#End Region