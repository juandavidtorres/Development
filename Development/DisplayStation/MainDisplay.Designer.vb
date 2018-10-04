<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainDisplay
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
        Me.PnlContenido = New System.Windows.Forms.Panel()
        Me.VistaEstacion1 = New PosStation.DisplayStation.VistaEstacion()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tlbBottom = New gasolutions.UInterface.CustomToolStrip()
        Me.MnuDSPosColombia1 = New Controles.MnuDSPosColombia()
        Me.tlbTop = New gasolutions.UInterface.CustomToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.mnuVentasDisplay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.PnlContenido.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tlbTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlContenido
        '
        Me.PnlContenido.BackColor = System.Drawing.Color.Transparent
        Me.PnlContenido.Controls.Add(Me.VistaEstacion1)
        Me.PnlContenido.Location = New System.Drawing.Point(152, 106)
        Me.PnlContenido.Name = "PnlContenido"
        Me.PnlContenido.Size = New System.Drawing.Size(959, 550)
        Me.PnlContenido.TabIndex = 4
        '
        'VistaEstacion1
        '
        Me.VistaEstacion1.AutoScroll = True
        Me.VistaEstacion1.BackColor = System.Drawing.Color.Transparent
        Me.VistaEstacion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VistaEstacion1.Location = New System.Drawing.Point(0, 0)
        Me.VistaEstacion1.Name = "VistaEstacion1"
        Me.VistaEstacion1.Size = New System.Drawing.Size(959, 550)
        Me.VistaEstacion1.TabIndex = 2
        Me.VistaEstacion1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(152, 659)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(959, 69)
        Me.Panel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.MnuDSPosColombia1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(152, 622)
        Me.Panel2.TabIndex = 11
        '
        'tlbBottom
        '
        Me.tlbBottom.AutoSize = False
        Me.tlbBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.tlbBottom.BackgroundImage = Global.PosStation.DisplayStation.My.Resources.Resources.BarraInferior
        Me.tlbBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tlbBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlbBottom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlbBottom.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tlbBottom.Location = New System.Drawing.Point(152, 659)
        Me.tlbBottom.Name = "tlbBottom"
        Me.tlbBottom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tlbBottom.Size = New System.Drawing.Size(959, 69)
        Me.tlbBottom.TabIndex = 8
        Me.tlbBottom.Text = "CustomToolStrip1"
        '
        'MnuDSPosColombia1
        '
        Me.MnuDSPosColombia1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.MnuDSPosColombia1.Caras = True
        Me.MnuDSPosColombia1.CarasTurnoAbierto = True
        Me.MnuDSPosColombia1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MnuDSPosColombia1.Gas = True
        Me.MnuDSPosColombia1.Gasolina = True
        Me.MnuDSPosColombia1.Location = New System.Drawing.Point(0, 0)
        Me.MnuDSPosColombia1.Name = "MnuDSPosColombia1"
        Me.MnuDSPosColombia1.Size = New System.Drawing.Size(152, 622)
        Me.MnuDSPosColombia1.TabIndex = 11
        '
        'tlbTop
        '
        Me.tlbTop.AutoSize = False
        Me.tlbTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.tlbTop.BackgroundImage = Global.PosStation.DisplayStation.My.Resources.Resources.Encabezado975
        Me.tlbTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tlbTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlbTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton7, Me.ToolStripButton6, Me.ToolStripButton3, Me.ToolStripButton2, Me.mnuVentasDisplay, Me.ToolStripButton4})
        Me.tlbTop.Location = New System.Drawing.Point(0, 0)
        Me.tlbTop.Name = "tlbTop"
        Me.tlbTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tlbTop.Size = New System.Drawing.Size(1111, 106)
        Me.tlbTop.TabIndex = 6
        Me.tlbTop.Text = "CustomToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton1.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Surtidores3232
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(4)
        Me.ToolStripButton1.Size = New System.Drawing.Size(48, 103)
        Me.ToolStripButton1.Text = "Caras"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton7.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Gas
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(37, 103)
        Me.ToolStripButton7.Text = "Gas"
        Me.ToolStripButton7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton7.Visible = False
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton6.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Gasolina
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(56, 103)
        Me.ToolStripButton6.Text = "Gasolina"
        Me.ToolStripButton6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton6.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton3.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Abierto
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(55, 103)
        Me.ToolStripButton3.Text = "Abiertos"
        Me.ToolStripButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton3.Visible = False
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton2.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Cerrado
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(58, 103)
        Me.ToolStripButton2.Text = "Cerrados"
        Me.ToolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton2.Visible = False
        '
        'mnuVentasDisplay
        '
        Me.mnuVentasDisplay.ForeColor = System.Drawing.Color.White
        Me.mnuVentasDisplay.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Dinero
        Me.mnuVentasDisplay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuVentasDisplay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuVentasDisplay.Name = "mnuVentasDisplay"
        Me.mnuVentasDisplay.Size = New System.Drawing.Size(46, 103)
        Me.mnuVentasDisplay.Text = "Ventas"
        Me.mnuVentasDisplay.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.mnuVentasDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuVentasDisplay.Visible = False
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.White
        Me.ToolStripButton4.Image = Global.PosStation.DisplayStation.My.Resources.Resources.Salir
        Me.ToolStripButton4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(43, 103)
        Me.ToolStripButton4.Text = "Cerrar"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton4.Visible = False
        '
        'MainDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1111, 728)
        Me.Controls.Add(Me.tlbBottom)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tlbTop)
        Me.Controls.Add(Me.PnlContenido)
        Me.Name = "MainDisplay"
        Me.Text = "SAUCE | Display Station"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlContenido.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tlbTop.ResumeLayout(False)
        Me.tlbTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlContenido As System.Windows.Forms.Panel
    Friend WithEvents tlbTop As gasolutions.UInterface.CustomToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents VistaEstacion1 As PosStation.DisplayStation.VistaEstacion
    Friend WithEvents mnuVentasDisplay As System.Windows.Forms.ToolStripButton
    Private WithEvents tlbBottom As gasolutions.UInterface.CustomToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MnuDSPosColombia1 As Controles.MnuDSPosColombia
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
