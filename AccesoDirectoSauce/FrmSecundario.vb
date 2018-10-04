Public Class FrmSecundario
    Dim dragging As Boolean = False
    Dim dragCursorPoint As Point
    Dim dragFormPoint As Point
   
    Private Sub FrmSecundario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Opacity = 0.6F
            FrmMain.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            FrmMain.BackColor = Color.Magenta 'Choose any colour that does not appear in your controls
            FrmMain.TransparencyKey = FrmMain.BackColor
            FrmMain.ShowInTaskbar = False

            'You have to do this in code:
            Me.AddOwnedForm(FrmMain)
            FrmMain.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, MyBase.Layout, MyBase.Move
        Try
            FrmMain.Location = Me.PointToScreen(Point.Empty)
            FrmMain.Size = Me.ClientSize
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub FrmSecundario_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Try
            dragging = True
            dragCursorPoint = Cursor.Position
            dragFormPoint = Me.Location
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmSecundario_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Try
            If dragging Then
                Dim dif As Point = Point.Subtract(Cursor.Position, New Size(dragCursorPoint))
                Me.Location = Point.Add(dragFormPoint, New Size(dif))
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmSecundario_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        dragging = False
    End Sub

    Private Sub FrmSecundario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            FrmMain.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class