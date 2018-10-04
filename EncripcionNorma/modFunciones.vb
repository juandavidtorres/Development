Module modFunciones
    Public Function Bshift(ByVal Num As Byte, ByVal iDesp As Integer) As Byte
        Dim sNum(0 To 7) As Byte
        Dim I As Byte

        iDesp = iDesp * (-1)

        If Num >= 128 Then
            sNum(7) = 1
            Num = CByte(Num - 128)
        Else
            sNum(7) = 0
        End If

        If Num >= 64 Then
            sNum(6) = 1
            Num = CByte(Num - 64)
        Else
            sNum(6) = 0
        End If

        If Num >= 32 Then
            sNum(5) = 1
            Num = CByte(Num - 32)
        Else
            sNum(5) = 0
        End If

        If Num >= 16 Then
            sNum(4) = 1
            Num = CByte(Num - 16)
        Else
            sNum(4) = 0
        End If

        If Num >= 8 Then
            sNum(3) = 1
            Num = CByte(Num - 8)
        Else
            sNum(3) = 0
        End If

        If Num >= 4 Then
            sNum(2) = 1
            Num = CByte(Num - 4)
        Else
            sNum(2) = 0
        End If

        If Num >= 2 Then
            sNum(1) = 1
            Num = CByte(Num - 2)
        Else
            sNum(1) = 0
        End If

        If Num >= 1 Then
            sNum(0) = 1
        Else
            sNum(0) = 0
        End If

        If iDesp > 0 Then
            While iDesp > 0
                For I = 0 To 6
                    sNum(I) = sNum(I + 1)
                Next I
                sNum(7) = 0
                iDesp = iDesp - 1
            End While
        ElseIf iDesp < 0 Then
            While iDesp < 0
                For I = 0 To 6
                    sNum(7 - I) = sNum(6 - I)
                Next I
                sNum(0) = 0
                iDesp = iDesp + 1
            End While
        End If

        For I = 0 To 7
            Bshift = CByte(Bshift + sNum(I) * (2 ^ I))
        Next I
    End Function
End Module
