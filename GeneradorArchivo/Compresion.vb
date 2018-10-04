Imports ICSharpCode.SharpZipLib.Checksums
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.GZip
Imports System.IO
Imports System.Globalization

Public NotInheritable Class Compresion
    Sub New()
    End Sub


    Public Sub Comprimir(ByVal fileNames() As String, _
                       ByVal zipFic As String, _
                       Optional ByVal crearAuto As Boolean = False)
        ' comprimir los ficheros del array en el zip indicado
        ' si crearAuto = True, zipfile será el directorio en el que se guardará
        ' y se generará automáticamente el nombre con la fecha y hora actual
        Dim objCrc32 As New Crc32()
        Dim strmZipOutputStream As ZipOutputStream
        '
        If zipFic = "" Then
            zipFic = "."
            crearAuto = True
        End If
        If crearAuto Then
            ' si hay que crear el nombre del fichero
            ' éste será el path indicado y la fecha actual
            zipFic &= "\ZIP" & DateTime.Now.ToString("yyMMddHHmmss") & ".zip"
        End If
        strmZipOutputStream = New ZipOutputStream(File.Create(zipFic))
        ' Compression Level: 0-9
        ' 0: no(Compression)
        ' 9: maximum compression
        strmZipOutputStream.SetLevel(6)
        '
        Dim strFile As String
        For Each strFile In fileNames
            Dim strmFile As FileStream = File.OpenRead(strFile)
            Dim abyBuffer(Convert.ToInt32(strmFile.Length - 1)) As Byte
            '
            strmFile.Read(abyBuffer, 0, abyBuffer.Length)
            '
            '------------------------------------------------------------------
            ' para guardar sin el primer path
            'Dim sFile As String = strFile
            'Dim i As Integer = sFile.IndexOf("\")
            'If i > -1 Then
            '    sFile = sFile.Substring(i + 1).TrimStart
            'End If
            '------------------------------------------------------------------
            '
            '------------------------------------------------------------------
            ' para guardar sólo el nombre del fichero
            ' esto sólo se debe hacer si no se procesan directorios
            ' que puedan contener nombres repetidos
            Dim sFile As String = Path.GetFileName(strFile)
            Dim theEntry As ZipEntry = New ZipEntry(sFile)
            '------------------------------------------------------------------
            '
            ' se guarda con el path completo
            'Dim theEntry As ZipEntry = New ZipEntry(strFile)
            '
            ' guardar la fecha y hora de la última modificación
            Dim fi As New FileInfo(strFile)
            theEntry.DateTime = fi.LastWriteTime
            'theEntry.DateTime = DateTime.Now
            '
            theEntry.Size = strmFile.Length
            strmFile.Close()
            objCrc32.Reset()
            objCrc32.Update(abyBuffer)
            theEntry.Crc = objCrc32.Value
            strmZipOutputStream.PutNextEntry(theEntry)
            strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)
        Next
        strmZipOutputStream.Finish()
        strmZipOutputStream.Close()
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
        If Not zipFic.ToLower.EndsWith(".zip") Then
            zipFic = Directory.GetFiles(zipFic, "*.zip")(0)
        End If
        ' si no se ha indicado el directorio, usar el actual
        If directorio = "" Then directorio = "."

        directorio = directorio & "\"
        '
        Dim z As New ZipInputStream(File.OpenRead(zipFic))
        Dim theEntry As ZipEntry
        '
        Do
            theEntry = z.GetNextEntry()
            If Not theEntry Is Nothing Then

                'Se trata de un directorio, me aseguro que exista
                Dim fileName As String = directorio & Path.GetFileName(theEntry.Name)
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
                        'Cuando se trata d eun archivo de tamaño 0
                        Exit Do
                    End Try

                Loop
                streamWriter.Close()
            Else
                Exit Do
            End If

        Loop
        z.Close()
        '
        ' cuando se hayan extraído los ficheros, renombrarlo
        If renombrar Then
            File.Copy(zipFic, zipFic & ".procesado")
        End If
        If eliminar Then
            File.Delete(zipFic)
        End If
    End Sub
End Class