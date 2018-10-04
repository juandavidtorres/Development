Imports System.Drawing
Imports System.Drawing.Printing

'---------------------------------------------------------------------------
'CLASE PrintDocument PARA IMPRIMIR ARCHIVOS DE TEXTO.
'---------------------------------------------------------------------------

Public Class TextPrintDocument
    Inherits PrintDocument
    Private PrintFont As Font
    Private StreamToPrint As IO.StreamReader

    Public Sub New(ByVal streamToPrintParam As IO.StreamReader)
        MyBase.New()
        StreamToPrint = streamToPrintParam
    End Sub

    Protected Overrides Sub OnBeginPrint(ByVal e As PrintEventArgs)
        MyBase.OnBeginPrint(e)
        PrintFont = New Font("Tahoma", 8.25)
    End Sub

    Protected Overrides Sub OnPrintPage(ByVal e As PrintPageEventArgs)

        MyBase.OnPrintPage(e)
        Dim Lpp As Single = 0
        Dim Count As Integer = 0
        Dim TopMargin As Single = 1 'ev.MarginBounds.Top
        Dim YPos As Single = TopMargin
        Dim Line As String
        Lpp = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics)
        Line = StreamToPrint.ReadLine()
        While (Count < Lpp And Line <> Nothing)
            YPos = YPos + PrintFont.GetHeight(e.Graphics)
            e.Graphics.DrawString(Line, PrintFont, Brushes.Black, 0, YPos, New StringFormat())
            Count = Count + 1
            If (Count < Lpp) Then
                Line = StreamToPrint.ReadLine()
            End If
        End While
        If (Line <> Nothing) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

End Class