Imports System
Imports System.IO
Imports System.IO.StreamReader
Imports gasolutions.DataAccess
Imports System.Text
Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports POSstation.AccesoDatos


Public Class Suic

    Enum PosicionPlano As Short
        Placa = 0
        IdRom = 1
        Distribuidora = 2
        Taller = 3
        Certificadora = 4
        Convertido = 5
        UltRevision = 6
        ProxRevision = 7
        EstadoRom = 8
        CiudadTaller = 9
        Inspector = 10
    End Enum

    Shared Sub Descomprimir(ByVal directorio As String, _
                         Optional ByVal zipFic As String = "", _
                         Optional ByVal eliminar As Boolean = False, _
                         Optional ByVal renombrar As Boolean = False)
        ' descomprimir el contenido de zipFic en el directorio indicado.
        ' si zipFic no tiene la extensión .zip, se entenderá que es un directorio y
        ' se procesará el primer fichero .zip de ese directorio.
        ' si eliminar es True se eliminará ese fichero zip después de descomprimirlo.
        ' si renombrar es True se añadirá al final .descomprimido
        Try
            Try
                If Not zipFic.ToLower.EndsWith(".zip") Then
                    zipFic = Directory.GetFiles(zipFic, "*.zip")(0)
                End If
                ' si no se ha indicado el directorio, usar el actual
                If directorio = "" Then directorio = "."
                '
                Dim z As New ZipInputStream(File.OpenRead(zipFic))
                Dim theEntry As ZipEntry
                '
                Do
                    theEntry = z.GetNextEntry()
                    If Not theEntry Is Nothing Then

                        'Se trata de un directorio, me aseguro que exista
                        Dim fileName As String = directorio & "\" & Path.GetFileName(theEntry.Name)
                        '
                        ' dará error si no existe el path
                        Dim streamWriter As FileStream
                        Try
                            streamWriter = File.Create(fileName)
                        Catch ex As DirectoryNotFoundException
                            Directory.CreateDirectory(Path.GetDirectoryName(fileName))
                            streamWriter = File.Create(fileName)
                        End Try
                        '
                        Dim size As Integer
                        Dim data(32048) As Byte

                        Do
                            Try
                                size = z.Read(data, 0, data.Length)
                                If (size > 0) Then
                                    streamWriter.Write(data, 0, size)
                                Else
                                    Exit Do
                                End If
                            Catch ex As System.Exception
                                'Cuando se trata de un archivo de tamaño 0
                                Exit Do
                            End Try

                        Loop
                        streamWriter.Close()
                    Else
                        Exit Do
                    End If

                Loop
                z.Close()
            Catch ex As System.Exception
                Throw New System.Exception("Problema descomprimiendo archivo:" & ex.Message)
            End Try
            '
            ' cuando se hayan extraído los ficheros, renombrarlo
            If renombrar Then
                Try
                    File.Copy(zipFic, zipFic & Now.ToString("yyyyMMddHHmmss") & ".procesado")
                Catch ex As System.Exception
                    Throw New System.Exception("Problema renombrando archivo: " & zipFic)
                End Try
            End If
            If eliminar Then
                Try
                    File.Delete(zipFic)
                Catch ex As System.Exception
                    Throw New System.Exception("Problema eliminado archivo: " & zipFic)
                End Try
            End If
        Catch
            Throw
        End Try
    End Sub




    ''' <summary>
    ''' Permite la Importación de Información correspondiente a Datos SUIC
    ''' </summary>
    ''' <param name="sPath">Ruta ó Directorio en el cual estan alojados los archivos a procesar</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BulkSuic(ByVal sPath As String) As String
        Dim Respuesta As New StringBuilder
        Dim oPosiciones As New PosicionPlano
        Dim oHelper As New Helper()
        Dim nombreArchivo As String
        Dim sFileNameCargarTmp As String = ""
        Dim sPathCarga As String

        Try
            nombreArchivo = My.Settings.NombreArchivoSuic
            If System.IO.Directory.Exists(sPath) Then
                Dim Archivos() As String = System.IO.Directory.GetFiles(sPath)
                For Each sFileName As String In Archivos
                    Try
                        'Dim sFileNameCargar As String


                        If System.IO.Path.GetExtension(sFileName) = ".txt" And System.IO.Path.GetFileName(sFileName).Contains(nombreArchivo) Then
                            'sFileNameCargar = sPath & "\GST" & System.IO.Path.GetFileName(sFileName)
                            sPathCarga = sPath & "\GST\"
                            sFileNameCargarTmp = sPath & "\GST\" & "SuicTemp.txt"
                            'File.WriteAllText(sFileNameCargar, File.ReadAllText(sFileName), Encoding.Default)

                            Dim oFileRead As New StreamReader(sFileName)
                            'Dim sFileNameWrite As StreamWriter = File.AppendText(sFileNameCargar)

                            If Not My.Computer.FileSystem.DirectoryExists(sPathCarga) Then
                                My.Computer.FileSystem.CreateDirectory(sPathCarga)
                            End If

                            If File.Exists(sFileNameCargarTmp) Then
                                File.Delete(sFileNameCargarTmp)
                            End If
                            Using SW As StreamWriter = New StreamWriter(sFileNameCargarTmp)

                                While Not oFileRead.EndOfStream
                                    'sFileNameWrite.WriteLine(oFileRead.ReadLine)
                                    Dim oLinea() As String = oFileRead.ReadLine.Split(";")

                                    SW.WriteLine(oLinea(PosicionPlano.Placa).ToString & Chr(9) & oLinea(PosicionPlano.IdRom).ToString & Chr(9) & oLinea(PosicionPlano.Distribuidora).ToString & Chr(9) _
                                           & oLinea(PosicionPlano.Taller).ToString & Chr(9) & oLinea(PosicionPlano.Certificadora).ToString & Chr(9) & oLinea(PosicionPlano.Convertido).ToString & Chr(9) _
                                           & oLinea(PosicionPlano.UltRevision).ToString & Chr(9) & oLinea(PosicionPlano.ProxRevision).ToString & Chr(9) & oLinea(PosicionPlano.EstadoRom).ToString & Chr(9) _
                                           & oLinea(PosicionPlano.CiudadTaller).ToString & Chr(9) & oLinea(PosicionPlano.Inspector).ToString)
                                End While
                                SW.Close()

                            End Using

                            oHelper.CargarPlanoSuic(sFileNameCargarTmp, CInt(My.Settings.TimeOutSuic))

                            'System.IO.File.Delete(sFileName)
                            System.IO.File.Move(sFileNameCargarTmp, sPath & "\" & System.IO.Path.GetFileName(sFileNameCargarTmp).Replace(".txt", Now.ToString("ddMMyyyyHHmmss") & ".proc"))
                            Respuesta.AppendLine("El archivo : " & sFileNameCargarTmp & " fue procesado.")

                            File.Delete(sFileNameCargarTmp)

                            oFileRead.Close()
                            'sFileNameWrite.Close()

                            'oHelper.CargarPlanoSuic(sFileNameCargar, CInt(My.Settings.TimeOutSuic))
                            'System.IO.File.Delete(sFileName)
                            'System.IO.File.Move(sFileNameCargar, sPath & "\" & System.IO.Path.GetFileName(sFileNameCargar).Replace(".txt", Now.ToString("ddMMyyyyHHmmss") & ".proc"))
                            'Respuesta.AppendLine("El archivo : " & sFileName & " fue procesado.")
                        End If
                    Catch ex As System.Exception
                        Respuesta.AppendLine("Error procesando: " & sFileNameCargarTmp & " Error:" & ex.Message)
                    End Try
                Next
            End If
        Catch ex As Exception
            Throw
        End Try
        Return Respuesta.ToString()
    End Function
End Class
