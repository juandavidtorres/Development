Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

<ComClass(Criptografia1.ClassId, Criptografia1.InterfaceId, Criptografia1.EventsId)> _
Public Class Criptografia1

#Region "GUID de COM"
    ' Estos GUID proporcionan la identidad de COM para esta clase 
    ' y las interfaces de COM. Si las cambia, los clientes 
    ' existentes no podrán obtener acceso a la clase.
    Public Const ClassId As String = "54106198-330a-4147-963f-96242e2134e8"
    Public Const InterfaceId As String = "f623bf7c-0198-4295-a6cf-b67fd9cdb5ff"
    Public Const EventsId As String = "03a7f7cd-5cc7-462c-a9d7-c52aa1d06296"
#End Region

    ' Una clase COM que se puede crear debe tener Public Sub New() 
    ' sin parámetros, si no la clase no se 
    ' registrará en el registro COM y no se podrá crear a 
    ' través de CreateObject.


    Dim llave As RSACryptoServiceProvider
    Dim des As RijndaelManaged
    Dim cspp As CspParameters = New System.Security.Cryptography.CspParameters

    Public Sub New()
        MyBase.New()
    End Sub

    Public Function GenerarClavePublica(ByVal ValorLlave As String)
        cspp.KeyContainerName = ValorLlave        
        llave = New RSACryptoServiceProvider(1024, cspp)
        llave.PersistKeyInCsp = True
        Dim ClavePublica = llave.ToXmlString(False)
        Return ClavePublica
    End Function
    Public Function GenerarClavePrivada(ByVal ValorLlave As String)
        cspp.KeyContainerName = ValorLlave      
        llave = New RSACryptoServiceProvider(1024, cspp)
        llave.PersistKeyInCsp = True
        Dim ClavePrivada = llave.ToXmlString(True)
        Return ClavePrivada
    End Function
    Public Function GenerarLlaveSimetrica(ByVal TextoOriginal As String, ByVal CodEDS As String, ByVal NombreEDS As String, ByVal ClavePublica As String) As String
        ' Dim des As New RijndaelManaged()
        des = New RijndaelManaged()
        ' Averiguar la longitud de las claves
        Dim bits As Int32 = des.KeySize
        Dim TxtEncriptado As String
        ' Establecer la clave secreta
        ' La longitud de la cadena debe ser de al menos (bits/8) bytes
        Dim cant = bits / 16

        If ((CodEDS.Length < cant) And (NombreEDS.Length < cant)) Then

            NombreEDS += New String("F"c, cant - NombreEDS.Length)
            CodEDS += New String("F"c, cant - CodEDS.Length)
        End If
        ' Convertir la cadena en un array de bytes
        des.Key = Encoding.Default.GetBytes(NombreEDS.Substring(0, cant))
        des.IV = Encoding.Default.GetBytes(CodEDS.Substring(0, cant))
        ' Guardar las claves generadas
        Dim bIV As Byte() = des.IV
        Dim bKey As Byte() = des.Key
        Dim TextoEncriptado = Convert.ToBase64String(Encriptar(TextoOriginal, bIV, bKey))
        TxtEncriptado = EncryptString(TextoEncriptado, 1024, ClavePublica)
        Dim Vector As String
        Dim Key As String
        Vector = Convert.ToBase64String(bIV)
        Key = Convert.ToBase64String(bKey)
        TxtEncriptado = Vector & ";" & Key & ";" & TxtEncriptado
        Return TxtEncriptado
    End Function
    Public Function GenerarLlaveSimetricDesEncriptar(TextoOriginal As String, CodEDS As String, NombreEDS As String, ClavePrivada As String) As String
        des = New RijndaelManaged()
        ' Averiguar la longitud de las claves
        Dim bits As Integer = des.KeySize
        Dim TxtEncriptado As String
        ' Establecer la clave secreta
        ' La longitud de la cadena debe ser de al menos (bits/8) bytes
        Dim cant As Integer = bits \ 16

        If (CodEDS.Length < cant) AndAlso (NombreEDS.Length < cant) Then
            NombreEDS += New String("F"c, cant - NombreEDS.Length)
            CodEDS += New String("F"c, cant - CodEDS.Length)
        End If
        ' Convertir la cadena en un array de bytes
        'des.Key = Encoding.[Default].GetBytes(NombreEDS.Substring(0, cant))
        'des.IV = Encoding.[Default].GetBytes(CodEDS.Substring(0, cant))
        ' Guardar las claves generadas
        ' Dim bIV As Byte() = des.IV
        'Dim bKey As Byte() = des.Key
        Dim DatosC() As String
        Dim Dat As String = ""
        For y = 0 To 2
            DatosC = TextoOriginal.Split(";"c)                   
        Next
        Dim Vector = DatosC(0).ToString()
        Dim Key = DatosC(1).ToString()
        Dim texto = DatosC(2).ToString()
        Dim BKey As Byte() = Convert.FromBase64String(Key)
        Dim BVector As Byte() = Convert.FromBase64String(Vector)
        Dim TextoEncriptado As String = DecryptString(texto, 1024, ClavePrivada)
        Dim TxtEncript As Byte() = Convert.FromBase64String(TextoEncriptado)
        TxtEncriptado = DecryptStringFromBytes(TxtEncript, BKey, BVector)
        Return TxtEncriptado
    End Function
    Public Function Encriptar(TextoOriginal As String, Key As Byte(), IV As Byte()) As Byte()
        ' Check arguments.
        If TextoOriginal Is Nothing OrElse TextoOriginal.Length <= 0 Then
            Throw New ArgumentNullException("plainText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("IV")
        End If
        Dim encrypted As Byte()
        ' Create an RijndaelManaged object
        ' with the specified key and IV.
        Using rijAlg As New RijndaelManaged()
            rijAlg.Key = Key
            rijAlg.IV = IV
            ' Create a decrytor to perform the stream transform.
            Dim encryptor As ICryptoTransform = des.CreateEncryptor(des.Key, des.IV)
            ' Create the streams used for encryption.
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)
                        'Write all data to the stream.
                        swEncrypt.Write(TextoOriginal)
                    End Using
                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using
        ' Return the encrypted bytes from the memory stream.
        Return encrypted
    End Function

    Public Function EncryptString(inputString As String, dwKeySize As Integer, xmlString As String) As String
        ' TODO: Add Proper Exception Handlers
        Dim rsaCryptoServiceProvider As New RSACryptoServiceProvider(dwKeySize)
        rsaCryptoServiceProvider.FromXmlString(GenerarClavePublica("g2s0t07"))
        Dim keySize As Integer = dwKeySize \ 8
        Dim bytes As Byte() = Encoding.UTF32.GetBytes(inputString)
        ' The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
        ' int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
        Dim maxLength As Integer = keySize - 42
        Dim dataLength As Integer = bytes.Length
        Dim iterations As Integer = dataLength \ maxLength
        Dim stringBuilder As New StringBuilder()
        For i As Integer = 0 To iterations
            Dim tempBytes As Byte() = New Byte(If((dataLength - maxLength * i > maxLength), maxLength, dataLength - maxLength * i) - 1) {}
            Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length)
            Dim encryptedBytes As Byte() = rsaCryptoServiceProvider.Encrypt(tempBytes, True)
            ' Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
            ' If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
            ' Comment out the next line and the corresponding one in the DecryptString function.
            Array.Reverse(encryptedBytes)
            ' Why convert to base 64?
            ' Because it is the largest power-of-two base printable using only ASCII characters
            stringBuilder.Append(Convert.ToBase64String(encryptedBytes))
        Next
        Return stringBuilder.ToString()
    End Function

   

    Public Function DecryptStringFromBytes(cipherText As Byte(), Key As Byte(), IV As Byte()) As String
        ' Check arguments.
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
            Throw New ArgumentNullException("cipherText")
        End If
        If Key Is Nothing OrElse Key.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        If IV Is Nothing OrElse IV.Length <= 0 Then
            Throw New ArgumentNullException("Key")
        End If
        ' Declare the string used to hold
        ' the decrypted text.
        Dim plaintext As String = Nothing
        ' Create an RijndaelManaged object
        ' with the specified key and IV.
        Using rijAlg As New RijndaelManaged()
            rijAlg.Key = Key
            rijAlg.IV = IV
            ' Create a decrytor to perform the stream transform.
            Dim decryptor As ICryptoTransform = rijAlg.CreateDecryptor(Key, IV)
            ' Create the streams used for decryption.
            Using msDecrypt As New MemoryStream(cipherText)
                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(csDecrypt)
                        ' Read the decrypted bytes from the decrypting stream
                        ' and place them in a string.
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
        Return plaintext
    End Function

    Public Function DecryptString(inputString As String, dwKeySize As Integer, xmlString As String) As String
        ' TODO: Add Proper Exception Handlers
        Dim rsaCryptoServiceProvider As New RSACryptoServiceProvider(dwKeySize)
        rsaCryptoServiceProvider.FromXmlString(xmlString)
        Dim base64BlockSize As Integer = If(((dwKeySize \ 8) Mod 3 <> 0), (((dwKeySize \ 8) \ 3) * 4) + 4, ((dwKeySize \ 8) \ 3) * 4)
        Dim iterations As Integer = inputString.Length \ base64BlockSize
        Dim arrayList As New ArrayList()
        For i As Integer = 0 To iterations - 1
            Dim encryptedBytes As Byte() = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize))
            ' Be aware the RSACryptoServiceProvider reverses the order of encrypted bytes after encryption and before decryption.
            ' If you do not require compatibility with Microsoft Cryptographic API (CAPI) and/or other vendors.
            ' Comment out the next line and the corresponding one in the EncryptString function.
            Array.Reverse(encryptedBytes)
            arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, True))
        Next
        Return Encoding.UTF32.GetString(TryCast(arrayList.ToArray(Type.[GetType]("System.Byte")), Byte()))
    End Function

End Class


