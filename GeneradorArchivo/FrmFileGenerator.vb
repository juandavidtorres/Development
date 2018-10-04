Imports System.IO
Imports POSstation.AccesoDatos
Imports System.Configuration
Imports POSstation.Fabrica
Imports System.Globalization
Imports System.Text
Imports System

Public Class FrmFileGenerator
    Private Shared LogFallas As New EstacionException
    Public Shared _UserId As Nullable(Of Guid)


    Public Enum TypeExtension
        TXT
        CSV
    End Enum


    Public Shared Property UserId() As Nullable(Of Guid)
        Get
            Return _UserId
        End Get
        Set(value As Nullable(Of Guid))
            _UserId = value
        End Set
    End Property

    Private Sub FrmFileGenerator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim OHelper As New Helper

        Try

            Me.pnlReportes.Visible = True


        Catch Ex As Fabrica.GasolutionsHaspException
            MessageBox.Show(My.Resources.LlaveHaspNoEncontrada, Application.ExecutablePath, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Catch ex As System.Exception
            MsgBox("Error al cargar los datos: " & ex.Message)
        End Try
    End Sub


    'Public Sub GenerarArchivoVentasRP(ByVal ventas As DataTable, separador As String)
    '    Try
    '        Dim oHelper As New Helper
    '        Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
    '        Dim NombreArchivo As String = "E" & Codigo & "RP" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo) & ".ser"

    '        Dim pathBase As String = My.Application.Info.DirectoryPath & "\Archivos"
    '        Dim fullPath As String = pathBase & "\" & NombreArchivo

    '        If Not My.Computer.FileSystem.DirectoryExists(pathBase) Then
    '            My.Computer.FileSystem.CreateDirectory(pathBase)
    '        End If

    '        If File.Exists(fullPath) Then File.Delete(fullPath)

    '        If Not ventas Is Nothing Then
    '            Me.prgVentas.Maximum = ventas.Rows.Count
    '            Me.prgVentas.Minimum = 0
    '            Me.prgVentas.Value = 0

    '            Using sw As StreamWriter = New StreamWriter(fullPath, False, New UTF8Encoding())
    '                For Each row As DataRow In ventas.Rows
    '                    For Each column As DataColumn In ventas.Columns
    '                        sw.Write(row.Item(column.ColumnName).ToString & separador)
    '                    Next
    '                    Me.prgVentas.Value += 1
    '                    Application.DoEvents()
    '                Next
    '                Me.prgVentas.Value = Me.prgVentas.Maximum
    '            End Using

    '            MostrarError("Proceso Generado Satisfactoriamente.", 3000, False)
    '            Me.prgExportar.Value = 0
    '        Else
    '            MostrarError("No hay informacion para exportarse.", 3000, True)
    '        End If
    '    Catch ex As System.Exception
    '        MostrarError("ERROR: " & ex.Message, 3000, True)
    '    End Try

    'End Sub


    Public Sub GenerarArchivoVentas(ByVal ventas As DataSet)
        Try
            Dim oHelper As New Helper
            Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
            Dim NombreArchivo As String = "E" & Codigo & "PD" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo) & ".ser"

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Archivos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Archivos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo) Then
                File.Delete(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo)
            End If

            If Not ventas Is Nothing Then
                Me.prgVentas.Maximum = ventas.Tables(0).Rows.Count
                Me.prgVentas.Minimum = 0
                Me.prgVentas.Value = 0

                Dim Codificacion As New System.Text.UTF8Encoding

                Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo, False, Codificacion)
                    For I As Int32 = 0 To ventas.Tables(0).Rows.Count - 1
                        'Imprimo el encabezado
                        'sw.Write(Microsoft.VisualBasic.Right(("              " & (I + 1).ToString()), 14) & Now.ToString("dd/MM/yyyy") & "    " & Now.ToString("HH:mm:ss") & "      VENT     " & Microsoft.VisualBasic.Right("000" & Codigo, 3))
                        'Agrego cada una de las columans
                        For J As Int32 = 0 To ventas.Tables(0).Columns.Count - 1
                            'If J = 0 Then
                            '    Application.DoEvents()
                            '    sw.Write(Microsoft.VisualBasic.Right("000" & Ventas.Tables(0).Rows(I).Item(J).ToString, 3) & "*")
                            'Else
                            sw.Write(ventas.Tables(0).Rows(I).Item(J).ToString & "*")
                            'End If
                        Next J
                        sw.WriteLine("")
                        Me.prgVentas.Value = I + 1
                        Application.DoEvents()
                    Next I
                    sw.Close()
                    Me.prgVentas.Value = Me.prgVentas.Maximum
                End Using
            End If
        Catch
            Throw
        End Try

    End Sub

    Public Sub GenerarArchivoPagos(ByVal abonos As DataSet)
        Try
            Dim oHelper As New Helper
            Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
            Dim NombreArchivo As String = "A" & Codigo & "BN" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo) & ".ser"

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Archivos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Archivos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo) Then
                File.Delete(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo)
            End If

            If Not abonos Is Nothing Then
                Me.prgPagos.Maximum = abonos.Tables(0).Rows.Count
                Me.prgPagos.Minimum = 0
                Me.prgPagos.Value = 0

                Dim Codificacion As New System.Text.UTF8Encoding

                Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo, False, Codificacion)
                    For I As Int32 = 0 To abonos.Tables(0).Rows.Count - 1
                        'Imprimo el encabezado
                        sw.Write("ABON*")
                        'Agrego cada una de las columans
                        For J As Int32 = 0 To abonos.Tables(0).Columns.Count - 1
                            sw.Write(abonos.Tables(0).Rows(I).Item(J).ToString & "*")
                        Next J
                        sw.WriteLine("")
                        Me.prgPagos.Value = I + 1
                        Application.DoEvents()
                    Next I
                    sw.Close()
                    Me.prgPagos.Value = Me.prgPagos.Maximum
                End Using
            End If
        Catch
            Throw
        End Try
    End Sub

    Public Sub GenerarArchivoLecturas(ByVal lecturas As DataSet)
        Try
            Dim oHelper As New Helper
            Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
            Dim NombreArchivo As String = "L" & Codigo & "EC" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo) & ".ser"

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Archivos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Archivos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo) Then
                File.Delete(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo)
            End If

            If Not lecturas Is Nothing Then
                Me.prgLecturas.Maximum = lecturas.Tables(0).Rows.Count
                Me.prgLecturas.Minimum = 0
                Me.prgLecturas.Value = 0

                Dim Codificacion As New System.Text.UTF8Encoding

                Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo, False, Codificacion)
                    For I As Int32 = 0 To lecturas.Tables(0).Rows.Count - 1
                        'Agrego cada una de las columans
                        For J As Int32 = 0 To lecturas.Tables(0).Columns.Count - 1
                            sw.Write(lecturas.Tables(0).Rows(I).Item(J).ToString & "*")
                        Next J
                        sw.WriteLine("")
                        Me.prgLecturas.Value = I + 1
                        Application.DoEvents()
                    Next I
                    sw.Close()
                    Me.prgLecturas.Value = Me.prgLecturas.Maximum
                End Using
            End If
        Catch
            Throw
        End Try
    End Sub

    Public Sub GenerarArchivoReversiones(ByVal reversiones As DataSet)
        Try
            Dim oHelper As New Helper
            Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
            Dim NombreArchivo As String = "R" & Codigo & "EV" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo) & ".ser"

            If Not My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Archivos") Then
                My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Archivos")
            End If

            If File.Exists(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo) Then
                File.Delete(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo)
            End If

            If Not reversiones Is Nothing Then
                Me.prgReversiones.Maximum = reversiones.Tables(0).Rows.Count
                Me.prgReversiones.Minimum = 0
                Me.prgReversiones.Value = 0

                Dim Codificacion As New System.Text.UTF8Encoding

                Using sw As StreamWriter = New StreamWriter(My.Application.Info.DirectoryPath & "\Archivos\" & NombreArchivo, False, Codificacion)
                    For I As Int32 = 0 To reversiones.Tables(0).Rows.Count - 1
                        sw.Write("REVE*")
                        'Agrego cada una de las columans
                        For J As Int32 = 0 To reversiones.Tables(0).Columns.Count - 1
                            sw.Write(reversiones.Tables(0).Rows(I).Item(J).ToString & "*")
                        Next J
                        sw.WriteLine("")
                        Me.prgReversiones.Value = I + 1
                        Application.DoEvents()
                    Next I
                    sw.Close()
                    Me.prgReversiones.Value = Me.prgReversiones.Maximum
                End Using
            End If
        Catch
            Throw
        End Try
    End Sub


    'Public Sub ExportarReporte(ByVal reportTable As DataSet, ByVal reportName As String, ByVal usarSeparador As Boolean)
    '    Try
    '        Dim oHelper As New Helper
    '        Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
    '        Dim NombreArchivo As String = reportName & "_" & Codigo & "_" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo) & ".txt"
    '        Dim Separador As String = CStr(IIf(usarSeparador, oHelper.RecuperarParametro("SeparadorReporte").ToString(), My.Settings.Separador))
    '        Dim RutaReportes As String
    '        Dim cadenas As String = ""
    '        Try
    '            RutaReportes = oHelper.RecuperarParametro("RutaReportes") & "\"
    '        Catch ex As System.Exception
    '            LogFallas.ReportarError(ex, "ExportarReporte", "Reporte: " & reportName & " , UsarSeparador: " & usarSeparador, "FileGenerator")
    '            RutaReportes = My.Application.Info.DirectoryPath & "\Archivos\"
    '        End Try

    '        If Not My.Computer.FileSystem.DirectoryExists(RutaReportes) Then
    '            My.Computer.FileSystem.CreateDirectory(RutaReportes)
    '        End If

    '        If File.Exists(RutaReportes & NombreArchivo) Then
    '            File.Delete(RutaReportes & NombreArchivo)
    '        End If

    '        If Not reportTable Is Nothing Then
    '            Me.prgExportar.Maximum = reportTable.Tables(0).Rows.Count
    '            Me.prgExportar.Minimum = 0
    '            Me.prgExportar.Value = 0

    '            If reportTable.Tables(0).Rows.Count >= 1 Then
    '                Dim Codificacion As New System.Text.UTF8Encoding
    '                Using sw As StreamWriter = New StreamWriter(RutaReportes & NombreArchivo, False, Codificacion)
    '                    For I As Int32 = 0 To reportTable.Tables(0).Rows.Count - 1
    '                        For J As Int32 = 0 To reportTable.Tables(0).Columns.Count - 1
    '                            cadenas = reportTable.Tables(0).Rows(I).Item(J).ToString
    '                            cadenas = cadenas.Replace(",", ".")
    '                            sw.Write(cadenas & Separador)
    '                        Next J
    '                        sw.WriteLine("")
    '                        Me.prgExportar.Value = I + 1
    '                        Application.DoEvents()
    '                    Next I
    '                    sw.Close()
    '                    Me.prgExportar.Value = Me.prgExportar.Maximum
    '                End Using
    '                MostrarError("Proceso Generado Satisfactoriamente.", 3000, False)
    '                Me.prgExportar.Value = 0
    '            Else
    '                MostrarError("No hay informacion para exportarse.", 3000, True)
    '            End If
    '        Else
    '            MostrarError("No hay informacion para exportarse.", 3000, True)
    '        End If
    '    Catch
    '        Throw
    '    End Try
    'End Sub

    Public Sub ExportarReporteTXT(ByVal reportTable As DataSet, ByVal NombreArchivo As String, ByVal usarSeparador As Boolean)
        Try
            Dim oHelper As New Helper

            Dim Separador As String = CStr(IIf(usarSeparador, oHelper.RecuperarParametro("SeparadorComa").ToString(), ""))
            Dim RutaReportes As String

            Try
                RutaReportes = oHelper.RecuperarParametro("RutaReportes") & "\"
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "ExportarReporte", "-", "FileGenerator")
                RutaReportes = My.Application.Info.DirectoryPath & "\Archivos\"
            End Try

            If Not My.Computer.FileSystem.DirectoryExists(RutaReportes) Then
                My.Computer.FileSystem.CreateDirectory(RutaReportes)
            End If

            If File.Exists(RutaReportes & NombreArchivo) Then
                File.Delete(RutaReportes & NombreArchivo)
            End If

            If Not reportTable Is Nothing Then
                Me.prgExportar.Maximum = reportTable.Tables(0).Rows.Count
                Me.prgExportar.Minimum = 0
                Me.prgExportar.Value = 0

                If reportTable.Tables(0).Rows.Count >= 1 Then
                    Dim Codificacion As New System.Text.UTF8Encoding

                    Using sw As StreamWriter = New StreamWriter(RutaReportes & NombreArchivo, False, Codificacion)
                        For I As Int32 = 0 To reportTable.Tables(0).Rows.Count - 1
                            'Agrego cada una de las columans
                            For J As Int32 = 0 To reportTable.Tables(0).Columns.Count - 1
                                If J = reportTable.Tables(0).Columns.Count - 1 Then
                                    sw.Write(reportTable.Tables(0).Rows(I).Item(J).ToString)
                                Else
                                    sw.Write(reportTable.Tables(0).Rows(I).Item(J).ToString & Separador)
                                End If
                            Next J
                            sw.WriteLine("")
                            Me.prgExportar.Value = I + 1
                            Application.DoEvents()
                        Next I
                        sw.Close()
                        Me.prgExportar.Value = Me.prgExportar.Maximum
                    End Using
                    MostrarError("Proceso Generado Satisfactoriamente.", 3000, False)
                    Me.prgExportar.Value = 0

                Else

                    MostrarError("No hay informacion para exportarse.", 3000, True)
                End If
            Else
                MostrarError("No hay informacion para exportarse.", 3000, True)
            End If
        Catch
            Throw
        End Try
    End Sub

    Public Sub ExportarReporte(ByVal reportTable As DataSet, ByVal reportName As String, Optional ByVal usarSeparador As Boolean = True, Optional ByVal Extension As TypeExtension = TypeExtension.CSV)
        Try
            Dim oHelper As New Helper
            Dim Codigo As String = Microsoft.VisualBasic.Right("000" & oHelper.RecuperarDatosEstacion().Codigo, 3)
            Dim NombreArchivo As String = reportName & "_" & Codigo & "_" & Now.ToString("ddMMyyyy", DateTimeFormatInfo.CurrentInfo)
            Dim Separador As String = CStr(IIf(usarSeparador, oHelper.RecuperarParametro("SeparadorReporte").ToString(), ""))
            Dim RutaReportes As String

            Select Case Extension
                Case TypeExtension.TXT
                    NombreArchivo = NombreArchivo & ".txt"
                Case Else
                    NombreArchivo = NombreArchivo & ".csv"
            End Select

            Try
                RutaReportes = oHelper.RecuperarParametro("RutaReportes") & "\"
            Catch ex As System.Exception
                LogFallas.ReportarError(ex, "ExportarReporte", "Reporte: " & reportName & " , UsarSeparador: " & usarSeparador, "FileGenerator")
                RutaReportes = My.Application.Info.DirectoryPath & "\Archivos\"
            End Try

            If Not My.Computer.FileSystem.DirectoryExists(RutaReportes) Then
                My.Computer.FileSystem.CreateDirectory(RutaReportes)
            End If

            If File.Exists(RutaReportes & NombreArchivo) Then
                File.Delete(RutaReportes & NombreArchivo)
            End If

            If Not reportTable Is Nothing Then
                Me.prgExportar.Maximum = reportTable.Tables(0).Rows.Count
                Me.prgExportar.Minimum = 0
                Me.prgExportar.Value = 0

                If reportTable.Tables(0).Rows.Count >= 1 Then
                    Dim Codificacion As New System.Text.UTF8Encoding

                    Using sw As StreamWriter = New StreamWriter(RutaReportes & NombreArchivo, False, Codificacion)
                        For I As Int32 = 0 To reportTable.Tables(0).Rows.Count - 1
                            '    sw.Write("REVE*")
                            'Agrego cada una de las columans
                            For J As Int32 = 0 To reportTable.Tables(0).Columns.Count - 1
                                sw.Write(reportTable.Tables(0).Rows(I).Item(J).ToString & Separador)
                            Next J
                            sw.WriteLine("")
                            Me.prgExportar.Value = I + 1
                            Application.DoEvents()
                        Next I
                        sw.Close()
                        Me.prgExportar.Value = Me.prgExportar.Maximum
                    End Using

                    MostrarError("Proceso Generado Satisfactoriamente.", 3000, False)
                    Me.prgExportar.Value = 0
                Else

                    MostrarError("No hay informacion para exportarse.", 3000, True)
                End If
            Else

                MostrarError("No hay informacion para exportarse.", 3000, True)
            End If
        Catch
            Throw
        End Try
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If cmbReportes.SelectedIndex <> -1 Then
            Me.Cursor = Cursors.WaitCursor
            Me.cmbReportes.Enabled = False
            Dim ODataAccess As New Helper

            Dim oHelper As New Helper
            Dim Codigo As String = oHelper.RecuperarDatosEstacion().Codigo

            Select Case UCase(cmbReportes.Text)
                Case "VENTA"
                    ExportarReporte(ODataAccess.RecuperarVentasPorDia(CDate(Me.dtpFechaIniReporte.Text), CDate(Me.dtpFechaFinReporte.Text)), "VENTASCOMBUSTIBLE", True)
                Case "PEDIDO_DE_COMBUSTIBLE"
                    ExportarReporte(ODataAccess.RecuperarPedidoCombustiblePorFecha(CDate(Me.dtpFechaIniReporte.Text).ToString("yyyyMMdd", DateTimeFormatInfo.CurrentInfo), CDate(Me.dtpFechaFinReporte.Text).ToString("yyyyMMdd", DateTimeFormatInfo.CurrentInfo)), "PEDIDO_COMBUSTIBLE", True)

                Case "CANASTILLA"
                    ExportarReporte(ODataAccess.RecuperarVentasPorDiaCanastilla(CDate(Me.dtpFechaIniReporte.Text).ToString("yyyyMMdd", DateTimeFormatInfo.CurrentInfo), CDate(Me.dtpFechaFinReporte.Text).ToString("yyyyMMdd", DateTimeFormatInfo.CurrentInfo)), "CANASTILLA", True)
                Case "VENTAS RP"
                    ExportarReporte(ODataAccess.GenerarArchivoVentasRP(CDate(Me.dtpFechaIniReporte.Text).ToString("yyyyMMdd", DateTimeFormatInfo.CurrentInfo), CDate(Me.dtpFechaFinReporte.Text).ToString("yyyyMMdd", DateTimeFormatInfo.CurrentInfo)), "VENTAS RP", True)
            End Select

            Me.Cursor = Cursors.Default
            Me.cmbReportes.Enabled = True
        Else

            MostrarError("Debe seleccionar un reporte.", 3000, False)
        End If
    End Sub

    'Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    '    pnlReportes.Visible = False : pnlGenerador.Visible = True
    'End Sub



    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oHelper As New Helper
            oHelper.CargarBackup(oHelper.RecuperarParametro("RutaBackup"))
            Me.Cursor = Cursors.Default

            MostrarError("Archivos Cargados con Exito", 3000, False)
        Catch Ex As System.Exception
            MostrarError(Ex.Message, 3000, False)
        End Try
    End Sub




    Private Shared Sub EliminarArchivosEnDirectorio(ByVal Directorio As String, Optional ByVal Filtro As String = "")
        Dim archivos() As String
        Try
            Try
                If Filtro <> "" Then
                    archivos = Directory.GetFiles(Directorio, Filtro)
                Else
                    archivos = Directory.GetFiles(Directorio)
                End If
            Catch ex As System.Exception
                Throw New System.IO.IOException("Problema recuperando directorio: " & Directorio & " Filtro:" & Filtro)
            End Try

            For I As Integer = 0 To archivos.Length - 1
                Try
                    File.Delete(archivos(I))
                Catch ex As System.Exception
                    Throw New System.IO.IOException("Problema eliminando archivo: " & archivos(I))
                End Try
            Next
        Catch
            Throw
        End Try
    End Sub






    Public Sub MostrarError(texto As String, delay As Integer, eserror As Boolean)

        Try
            Dim mensaje As Notificacion.Notification = New Notificacion.Notification
            mensaje.Mensaje = texto
            mensaje.TimerTiempo = delay
            mensaje.EsError = eserror
            mensaje.Show()
        Catch ex As System.Exception

        End Try
    End Sub

    Private Function dtpFinal() As Object
        Throw New NotImplementedException
    End Function


End Class
