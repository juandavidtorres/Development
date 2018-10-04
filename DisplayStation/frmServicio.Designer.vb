<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.tmrRetardo = New System.Windows.Forms.Timer(Me.components)
        Me.Controlador = New System.ServiceProcess.ServiceController()
        Me.btnReintentar = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(118, 61)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'tmrRetardo
        '
        Me.tmrRetardo.Interval = 2000
        '
        'btnReintentar
        '
        Me.btnReintentar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.btnReintentar.Enabled = False
        Me.btnReintentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReintentar.ForeColor = System.Drawing.Color.White
        Me.btnReintentar.Location = New System.Drawing.Point(27, 61)
        Me.btnReintentar.Name = "btnReintentar"
        Me.btnReintentar.Size = New System.Drawing.Size(75, 23)
        Me.btnReintentar.TabIndex = 3
        Me.btnReintentar.Text = "Reintentar"
        Me.btnReintentar.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(16, 13)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(187, 40)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Text = "Esperando el inicio del motor de datos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Sql Server 2005)..."
        '
        'frmServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(216, 94)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnReintentar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultando el servicio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents tmrRetardo As System.Windows.Forms.Timer
    Friend WithEvents Controlador As System.ServiceProcess.ServiceController
    Friend WithEvents btnReintentar As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
