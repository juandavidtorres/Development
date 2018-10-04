<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatosStation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatosStation))
        Me.pnlPrincipal = New System.Windows.Forms.TableLayoutPanel
        Me.label6 = New System.Windows.Forms.Label
        Me.lblCiudad = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.lblDireccion = New System.Windows.Forms.Label
        Me.lblNit = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.lblNombre = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrincipal.AutoSize = True
        Me.pnlPrincipal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.pnlPrincipal.ColumnCount = 2
        Me.pnlPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.pnlPrincipal.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlPrincipal.Controls.Add(Me.label6, 0, 9)
        Me.pnlPrincipal.Controls.Add(Me.lblCiudad, 1, 9)
        Me.pnlPrincipal.Controls.Add(Me.label5, 0, 8)
        Me.pnlPrincipal.Controls.Add(Me.label4, 0, 7)
        Me.pnlPrincipal.Controls.Add(Me.label3, 0, 6)
        Me.pnlPrincipal.Controls.Add(Me.label2, 0, 5)
        Me.pnlPrincipal.Controls.Add(Me.lblTelefono, 1, 8)
        Me.pnlPrincipal.Controls.Add(Me.lblDireccion, 1, 7)
        Me.pnlPrincipal.Controls.Add(Me.lblNit, 1, 6)
        Me.pnlPrincipal.Controls.Add(Me.label8, 0, 4)
        Me.pnlPrincipal.Controls.Add(Me.lblNombre, 1, 5)
        Me.pnlPrincipal.Controls.Add(Me.lblCodigo, 1, 4)
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 67)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.RowCount = 12
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlPrincipal.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlPrincipal.Size = New System.Drawing.Size(150, 170)
        Me.pnlPrincipal.TabIndex = 6
        '
        'label6
        '
        Me.label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label6.Location = New System.Drawing.Point(18, 135)
        Me.label6.Margin = New System.Windows.Forms.Padding(3, 3, 6, 2)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(46, 13)
        Me.label6.TabIndex = 7
        Me.label6.Text = "Ciudad"
        '
        'lblCiudad
        '
        Me.lblCiudad.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudad.Location = New System.Drawing.Point(73, 134)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(74, 13)
        Me.lblCiudad.TabIndex = 15
        Me.lblCiudad.Text = "label14"
        '
        'label5
        '
        Me.label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label5.Location = New System.Drawing.Point(7, 116)
        Me.label5.Margin = New System.Windows.Forms.Padding(3, 3, 6, 2)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(57, 13)
        Me.label5.TabIndex = 6
        Me.label5.Text = "Teléfono"
        '
        'label4
        '
        Me.label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label4.Location = New System.Drawing.Point(3, 97)
        Me.label4.Margin = New System.Windows.Forms.Padding(3, 3, 6, 2)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(61, 13)
        Me.label4.TabIndex = 5
        Me.label4.Text = "Dirección"
        '
        'label3
        '
        Me.label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label3.Location = New System.Drawing.Point(41, 79)
        Me.label3.Margin = New System.Windows.Forms.Padding(3, 3, 6, 2)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(23, 13)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Nit"
        '
        'label2
        '
        Me.label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label2.Location = New System.Drawing.Point(14, 61)
        Me.label2.Margin = New System.Windows.Forms.Padding(3, 3, 6, 2)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(50, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Nombre"
        '
        'lblTelefono
        '
        Me.lblTelefono.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(73, 115)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(74, 13)
        Me.lblTelefono.TabIndex = 14
        Me.lblTelefono.Text = "label13"
        '
        'lblDireccion
        '
        Me.lblDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.Location = New System.Drawing.Point(73, 96)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(74, 13)
        Me.lblDireccion.TabIndex = 13
        Me.lblDireccion.Text = "label12"
        '
        'lblNit
        '
        Me.lblNit.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNit.AutoSize = True
        Me.lblNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNit.Location = New System.Drawing.Point(73, 78)
        Me.lblNit.Name = "lblNit"
        Me.lblNit.Size = New System.Drawing.Size(74, 13)
        Me.lblNit.TabIndex = 12
        Me.lblNit.Text = "label11"
        '
        'label8
        '
        Me.label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.label8.Location = New System.Drawing.Point(18, 43)
        Me.label8.Margin = New System.Windows.Forms.Padding(3, 3, 6, 2)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(46, 13)
        Me.label8.TabIndex = 9
        Me.label8.Text = "Código"
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(73, 60)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(74, 13)
        Me.lblNombre.TabIndex = 11
        Me.lblNombre.Text = "K-rros"
        '
        'lblCodigo
        '
        Me.lblCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodigo.Location = New System.Drawing.Point(73, 42)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(74, 13)
        Me.lblCodigo.TabIndex = 10
        Me.lblCodigo.Text = "213"
        '
        'lblFecha
        '
        Me.lblFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFecha.Font = New System.Drawing.Font("Raavi", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFecha.Image = CType(resources.GetObject("lblFecha.Image"), System.Drawing.Image)
        Me.lblFecha.Location = New System.Drawing.Point(0, 0)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(150, 27)
        Me.lblFecha.TabIndex = 7
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 327)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 188)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'DatosStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Name = "DatosStation"
        Me.Size = New System.Drawing.Size(150, 515)
        Me.pnlPrincipal.ResumeLayout(False)
        Me.pnlPrincipal.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents pnlPrincipal As System.Windows.Forms.TableLayoutPanel
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents lblCiudad As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents lblTelefono As System.Windows.Forms.Label
    Private WithEvents lblDireccion As System.Windows.Forms.Label
    Private WithEvents lblNit As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents lblNombre As System.Windows.Forms.Label
    Private WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
