<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaraControl
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaraControl))
        Me.lblCara = New System.Windows.Forms.Label()
        Me.lblEstadoTurno = New System.Windows.Forms.Label()
        Me.PnlCentroCara = New System.Windows.Forms.Panel()
        Me.TxtProducto = New System.Windows.Forms.Label()
        Me.TxtPrecio = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtPlaca = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtValor = New System.Windows.Forms.Label()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.TxtVolumen = New System.Windows.Forms.Label()
        Me.LblPrecio = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.LblPlaca = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblActiva = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.PnlCentroCara.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCara
        '
        Me.lblCara.BackColor = System.Drawing.Color.Transparent
        Me.lblCara.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCara.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCara.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCara.Location = New System.Drawing.Point(17, 237)
        Me.lblCara.Name = "lblCara"
        Me.lblCara.Size = New System.Drawing.Size(166, 21)
        Me.lblCara.TabIndex = 41
        Me.lblCara.Text = "Cara #"
        Me.lblCara.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEstadoTurno
        '
        Me.lblEstadoTurno.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEstadoTurno.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoTurno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstadoTurno.Location = New System.Drawing.Point(28, 25)
        Me.lblEstadoTurno.Name = "lblEstadoTurno"
        Me.lblEstadoTurno.Size = New System.Drawing.Size(149, 21)
        Me.lblEstadoTurno.TabIndex = 40
        Me.lblEstadoTurno.Text = "Cerrado"
        Me.lblEstadoTurno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCentroCara
        '
        Me.PnlCentroCara.BackColor = System.Drawing.Color.White
        Me.PnlCentroCara.BackgroundImage = Global.PosStation.DisplayStation.My.Resources.Resources.FondoDisplay
        Me.PnlCentroCara.Controls.Add(Me.lblEstadoTurno)
        Me.PnlCentroCara.Controls.Add(Me.TxtProducto)
        Me.PnlCentroCara.Controls.Add(Me.lblCara)
        Me.PnlCentroCara.Controls.Add(Me.TxtPrecio)
        Me.PnlCentroCara.Controls.Add(Me.Panel2)
        Me.PnlCentroCara.Controls.Add(Me.Panel1)
        Me.PnlCentroCara.Controls.Add(Me.Panel19)
        Me.PnlCentroCara.Controls.Add(Me.LblPrecio)
        Me.PnlCentroCara.Controls.Add(Me.lblProducto)
        Me.PnlCentroCara.Controls.Add(Me.LblPlaca)
        Me.PnlCentroCara.Controls.Add(Me.Label10)
        Me.PnlCentroCara.Controls.Add(Me.lblActiva)
        Me.PnlCentroCara.Controls.Add(Me.Label9)
        Me.PnlCentroCara.Controls.Add(Me.lblEstado)
        Me.PnlCentroCara.Location = New System.Drawing.Point(2, 4)
        Me.PnlCentroCara.Name = "PnlCentroCara"
        Me.PnlCentroCara.Size = New System.Drawing.Size(201, 275)
        Me.PnlCentroCara.TabIndex = 49
        '
        'TxtProducto
        '
        Me.TxtProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TxtProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtProducto.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtProducto.Location = New System.Drawing.Point(85, 155)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(101, 13)
        Me.TxtProducto.TabIndex = 57
        Me.TxtProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPrecio
        '
        Me.TxtPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TxtPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtPrecio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TxtPrecio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPrecio.Location = New System.Drawing.Point(85, 174)
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.Size = New System.Drawing.Size(101, 13)
        Me.TxtPrecio.TabIndex = 56
        Me.TxtPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.TxtPlaca)
        Me.Panel2.Location = New System.Drawing.Point(104, 116)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(70, 24)
        Me.Panel2.TabIndex = 55
        '
        'TxtPlaca
        '
        Me.TxtPlaca.BackColor = System.Drawing.Color.Transparent
        Me.TxtPlaca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtPlaca.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPlaca.Location = New System.Drawing.Point(7, 5)
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.Size = New System.Drawing.Size(57, 14)
        Me.TxtPlaca.TabIndex = 60
        Me.TxtPlaca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.TxtValor)
        Me.Panel1.Location = New System.Drawing.Point(104, 86)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(70, 24)
        Me.Panel1.TabIndex = 54
        '
        'TxtValor
        '
        Me.TxtValor.BackColor = System.Drawing.Color.Transparent
        Me.TxtValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtValor.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtValor.Location = New System.Drawing.Point(7, 5)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(57, 14)
        Me.TxtValor.TabIndex = 59
        Me.TxtValor.Text = "0.0"
        Me.TxtValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.Transparent
        Me.Panel19.BackgroundImage = CType(resources.GetObject("Panel19.BackgroundImage"), System.Drawing.Image)
        Me.Panel19.Controls.Add(Me.TxtVolumen)
        Me.Panel19.Location = New System.Drawing.Point(104, 57)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(70, 24)
        Me.Panel19.TabIndex = 51
        '
        'TxtVolumen
        '
        Me.TxtVolumen.BackColor = System.Drawing.Color.Transparent
        Me.TxtVolumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TxtVolumen.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVolumen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtVolumen.Location = New System.Drawing.Point(7, 5)
        Me.TxtVolumen.Name = "TxtVolumen"
        Me.TxtVolumen.Size = New System.Drawing.Size(57, 14)
        Me.TxtVolumen.TabIndex = 58
        Me.TxtVolumen.Text = "0.0"
        Me.TxtVolumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPrecio
        '
        Me.LblPrecio.AutoSize = True
        Me.LblPrecio.BackColor = System.Drawing.Color.Transparent
        Me.LblPrecio.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblPrecio.Location = New System.Drawing.Point(21, 172)
        Me.LblPrecio.Name = "LblPrecio"
        Me.LblPrecio.Size = New System.Drawing.Size(47, 16)
        Me.LblPrecio.TabIndex = 52
        Me.LblPrecio.Text = "Precio:"
        Me.LblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.BackColor = System.Drawing.Color.Transparent
        Me.lblProducto.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblProducto.Location = New System.Drawing.Point(21, 153)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(62, 16)
        Me.lblProducto.TabIndex = 8
        Me.lblProducto.Text = "Producto:"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPlaca
        '
        Me.LblPlaca.AutoSize = True
        Me.LblPlaca.BackColor = System.Drawing.Color.Transparent
        Me.LblPlaca.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlaca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblPlaca.Location = New System.Drawing.Point(38, 120)
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Size = New System.Drawing.Size(40, 16)
        Me.LblPlaca.TabIndex = 44
        Me.LblPlaca.Text = "Placa:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(38, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Valor:"
        '
        'lblActiva
        '
        Me.lblActiva.BackColor = System.Drawing.Color.Transparent
        Me.lblActiva.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblActiva.Location = New System.Drawing.Point(115, 204)
        Me.lblActiva.Name = "lblActiva"
        Me.lblActiva.Size = New System.Drawing.Size(72, 22)
        Me.lblActiva.TabIndex = 43
        Me.lblActiva.Text = "Activa"
        Me.lblActiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(38, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Volumen:"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEstado.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(21, 205)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(88, 21)
        Me.lblEstado.TabIndex = 38
        Me.lblEstado.Text = "Colgada"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CaraControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Controls.Add(Me.PnlCentroCara)
        Me.Name = "CaraControl"
        Me.Size = New System.Drawing.Size(203, 282)
        Me.PnlCentroCara.ResumeLayout(False)
        Me.PnlCentroCara.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCara As System.Windows.Forms.Label
    Friend WithEvents lblEstadoTurno As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents PnlCentroCara As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents LblPlaca As System.Windows.Forms.Label
    Friend WithEvents LblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblActiva As System.Windows.Forms.Label
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtPrecio As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.Label
    Friend WithEvents TxtValor As System.Windows.Forms.Label
    Friend WithEvents TxtVolumen As System.Windows.Forms.Label
    Friend WithEvents TxtPlaca As System.Windows.Forms.Label

End Class
