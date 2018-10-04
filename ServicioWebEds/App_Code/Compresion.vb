Imports Microsoft.VisualBasic
Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports System.IO

Public Class Compresion
    REM Compression Level: 0-9
    REM 0: no(Compression)
    REM 9: maximum compression
    Public Sub ComprimirDirectorio(ByVal Directorio As String, ByVal ArchivoSalida As String)
        Try
            Dim astrFileNames() As String = Directory.GetFiles(Directorio)
            Dim objCrc32 As New Crc32()
            Dim strmZipOutputStream As ZipOutputStream

            strmZipOutputStream = New ZipOutputStream(File.Create(ArchivoSalida))
            strmZipOutputStream.SetLevel(6)

            Dim strFile As String

            For Each strFile In astrFileNames
                Dim strmFile As FileStream = File.OpenRead(strFile)
                Dim abyBuffer(CInt(strmFile.Length - 1)) As Byte

                strmFile.Read(abyBuffer, 0, abyBuffer.Length)
                Dim objZipEntry As ZipEntry = New ZipEntry(strFile)

                objZipEntry.DateTime = DateTime.Now
                objZipEntry.Size = strmFile.Length
                strmFile.Close()
                objCrc32.Reset()
                objCrc32.Update(abyBuffer)
                objZipEntry.Crc = objCrc32.Value
                strmZipOutputStream.PutNextEntry(objZipEntry)
                strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)

            Next

            strmZipOutputStream.Finish()
            strmZipOutputStream.Close()
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub
    Public Sub ZipFile(ByVal strFileToZip As String, ByVal strZippedFile As String, ByVal nCompressionLevel As Integer, ByVal nBlockSize As Integer)
        Try
            If (Not System.IO.File.Exists(strFileToZip)) Then
                Throw New System.IO.FileNotFoundException("El archivo especificado " + strFileToZip + " no fue encontrado. Operación abortada.")
            End If

            Dim strmStreamToZip As System.IO.FileStream
            strmStreamToZip = New System.IO.FileStream(strFileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read)

            Dim strmZipFile As System.IO.FileStream
            strmZipFile = System.IO.File.Create(strZippedFile)

            Dim strmZipStream As ZipOutputStream
            strmZipStream = New ZipOutputStream(strmZipFile)

            Dim myZipEntry As ZipEntry
            myZipEntry = New ZipEntry("ZippedFile")
            strmZipStream.PutNextEntry(myZipEntry)
            strmZipStream.SetLevel(nCompressionLevel)

            Dim abyBuffer(nBlockSize) As Byte
            Dim nSize As System.Int32
            nSize = strmStreamToZip.Read(abyBuffer, 0, abyBuffer.Length)
            strmZipStream.Write(abyBuffer, 0, nSize)

            Try
                While (nSize < strmStreamToZip.Length)
                    Dim nSizeRead As Integer
                    nSizeRead = strmStreamToZip.Read(abyBuffer, 0, abyBuffer.Length)
                    strmZipStream.Write(abyBuffer, 0, nSizeRead)
                    nSize = nSize + nSizeRead
                End While

            Catch Ex As System.Exception
                Throw Ex

            End Try

            strmZipStream.Finish()
            strmZipStream.Close()
            strmStreamToZip.Close()
        Catch ex As System.Exception
            Throw ex
        End Try
    End Sub

    Public Sub Descomprimir(ByVal directorio As String, _
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
                        Dim data(2048) As Byte

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
End Class
