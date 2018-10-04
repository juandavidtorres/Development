<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasEstacion
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
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.dgvVenta = New System.Windows.Forms.DataGridView()
        Me.Recibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Turno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaHoraInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaHoraFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Manguera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Placa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kilometraje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnConsultarTrans = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnlPrincipal.SuspendLayout()
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPrincipal.Controls.Add(Me.dgvVenta)
        Me.pnlPrincipal.Controls.Add(Me.panel1)
        Me.pnlPrincipal.Controls.Add(Me.groupBox1)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Size = New System.Drawing.Size(917, 556)
        Me.pnlPrincipal.TabIndex = 1
        '
        'dgvVenta
        '
        Me.dgvVenta.AllowUserToAddRows = False
        Me.dgvVenta.AllowUserToDeleteRows = False
        Me.dgvVenta.BackgroundColor = System.Drawing.Color.White
        Me.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Recibo, Me.Turno, Me.FechaHoraInicio, Me.FechaHoraFin, Me.Manguera, Me.Precio, Me.Cantidad, Me.ValorVenta, Me.ValorDescuento, Me.Placa, Me.Producto, Me.Kilometraje})
        Me.dgvVenta.Location = New System.Drawing.Point(0, 32)
        Me.dgvVenta.Name = "dgvVenta"
        Me.dgvVenta.ReadOnly = True
        Me.dgvVenta.RowHeadersVisible = False
        Me.dgvVenta.Size = New System.Drawing.Size(915, 522)
        Me.dgvVenta.TabIndex = 4
        '
        'Recibo
        '
        Me.Recibo.DataPropertyName = "Recibo"
        Me.Recibo.HeaderText = "NoVenta"
        Me.Recibo.Name = "Recibo"
        Me.Recibo.ReadOnly = True
        Me.Recibo.Width = 80
        '
        'Turno
        '
        Me.Turno.DataPropertyName = "Turno"
        Me.Turno.HeaderText = "Turno"
        Me.Turno.Name = "Turno"
        Me.Turno.ReadOnly = True
        Me.Turno.Width = 50
        '
        'FechaHoraInicio
        '
        Me.FechaHoraInicio.DataPropertyName = "HoraInicio"
        Me.FechaHoraInicio.HeaderText = "Inicia"
        Me.FechaHoraInicio.Name = "FechaHoraInicio"
        Me.FechaHoraInicio.ReadOnly = True
        Me.FechaHoraInicio.Width = 80
        '
        'FechaHoraFin
        '
        Me.FechaHoraFin.DataPropertyName = "HoraFin"
        Me.FechaHoraFin.HeaderText = "Finaliza"
        Me.FechaHoraFin.Name = "FechaHoraFin"
        Me.FechaHoraFin.ReadOnly = True
        Me.FechaHoraFin.Width = 80
        '
        'Manguera
        '
        Me.Manguera.DataPropertyName = "IdManguera"
        Me.Manguera.HeaderText = "Manguera"
        Me.Manguera.Name = "Manguera"
        Me.Manguera.ReadOnly = True
        Me.Manguera.Width = 70
        '
        'Precio
        '
        Me.Precio.DataPropertyName = "Precio"
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Width = 70
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 60
        '
        'ValorVenta
        '
        Me.ValorVenta.DataPropertyName = "Valor"
        Me.ValorVenta.HeaderText = "Valor"
        Me.ValorVenta.Name = "ValorVenta"
        Me.ValorVenta.ReadOnly = True
        Me.ValorVenta.Width = 90
        '
        'ValorDescuento
        '
        Me.ValorDescuento.DataPropertyName = "Descuento"
        Me.ValorDescuento.HeaderText = "Descuento"
        Me.ValorDescuento.Name = "ValorDescuento"
        Me.ValorDescuento.ReadOnly = True
        '
        'Placa
        '
        Me.Placa.DataPropertyName = "Placa"
        Me.Placa.HeaderText = "Placa"
        Me.Placa.Name = "Placa"
        Me.Placa.ReadOnly = True
        Me.Placa.Width = 60
        '
        'Producto
        '
        Me.Producto.DataPropertyName = "Producto"
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'Kilometraje
        '
        Me.Kilometraje.DataPropertyName = "Kilometraje"
        Me.Kilometraje.HeaderText = "Kilometraje"
        Me.Kilometraje.Name = "Kilometraje"
        Me.Kilometraje.ReadOnly = True
        Me.Kilometraje.Width = 70
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.dtpFinal)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.dtpInicio)
        Me.panel1.Controls.Add(Me.btnConsultarTrans)
        Me.panel1.Controls.Add(Me.btnCerrar)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(915, 45)
        Me.panel1.TabIndex = 3
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(218, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(77, 13)
        Me.label2.TabIndex = 11
        Me.label2.Text = "Fecha Final:"
        '
        'dtpFinal
        '
        Me.dtpFinal.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFinal.Location = New System.Drawing.Point(305, 5)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(131, 20)
        Me.dtpFinal.TabIndex = 10
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(3, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(81, 13)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Fecha Inicio:"
        '
        'dtpInicio
        '
        Me.dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInicio.Location = New System.Drawing.Point(90, 5)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(119, 20)
        Me.dtpInicio.TabIndex = 8
        '
        'btnConsultarTrans
        '
        Me.btnConsultarTrans.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.btnConsultarTrans.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnConsultarTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultarTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultarTrans.ForeColor = System.Drawing.Color.White
        Me.btnConsultarTrans.Location = New System.Drawing.Point(442, -1)
        Me.btnConsultarTrans.Name = "btnConsultarTrans"
        Me.btnConsultarTrans.Size = New System.Drawing.Size(85, 26)
        Me.btnConsultarTrans.TabIndex = 7
        Me.btnConsultarTrans.Text = "Buscar"
        Me.btnConsultarTrans.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(26, Byte), Integer))
        Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Location = New System.Drawing.Point(542, -2)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(83, 27)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'groupBox1
        '
        Me.groupBox1.Location = New System.Drawing.Point(0, 232)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(626, 34)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        '
        'VentasEstacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Name = "VentasEstacion"
        Me.Size = New System.Drawing.Size(917, 556)
        Me.pnlPrincipal.ResumeLayout(False)
        CType(Me.dgvVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Private WithEvents dgvVenta As System.Windows.Forms.DataGridView
    Private WithEvents Recibo As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Turno As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents FechaHoraInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents FechaHoraFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Manguera As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ValorVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ValorDescuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Placa As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents Kilometraje As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Private WithEvents btnConsultarTrans As System.Windows.Forms.Button
    Private WithEvents btnCerrar As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox


End Class
