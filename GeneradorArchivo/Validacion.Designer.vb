<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Validacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'gsInicioSesion
        '
        Me.gsInicioSesion.BackColor = System.Drawing.Color.White
        Me.gsInicioSesion.Location = New System.Drawing.Point(0, 0)
        Me.gsInicioSesion.Name = "gsInicioSesion"
        Me.gsInicioSesion.Size = New System.Drawing.Size(450, 219)
        Me.gsInicioSesion.TabIndex = 0
        '
        'Validacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.gsInicioSesion)
        Me.Name = "Validacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autenticación Usuario"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gsInicioSesion As Controles.gsInicioSesion
End Class
