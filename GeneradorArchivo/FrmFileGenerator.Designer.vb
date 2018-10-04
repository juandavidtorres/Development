<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFileGenerator
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
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.btnDatosIniciales = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlReportes = New System.Windows.Forms.Panel()
        Me.prgExportar = New System.Windows.Forms.ProgressBar()
        Me.label7 = New System.Windows.Forms.Label()
        Me.cmbReportes = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpFechaFinReporte = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIniReporte = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabRazonSocial = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.MensajeLog = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.prgReversiones = New System.Windows.Forms.ProgressBar()
        Me.prgLecturas = New System.Windows.Forms.ProgressBar()
        Me.prgPagos = New System.Windows.Forms.ProgressBar()
        Me.prgVentas = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnPromocion = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.OpenFileDialogRazonSocial = New System.Windows.Forms.OpenFileDialog()
        Me.TabPage2.SuspendLayout()
        Me.pnlReportes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabRazonSocial.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExportar
        '
        Me.btnExportar.AutoSize = True
        Me.btnExportar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportar.ForeColor = System.Drawing.Color.Black
        Me.btnExportar.Location = New System.Drawing.Point(332, 55)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(56, 23)
        Me.btnExportar.TabIndex = 44
        Me.btnExportar.TabStop = False
        Me.btnExportar.Text = "Exportar"
        Me.ToolTip.SetToolTip(Me.btnExportar, "Exporta los Datos del reporte seleccionado.")
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.AutoSize = True
        Me.btnReportes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReportes.ForeColor = System.Drawing.Color.White
        Me.btnReportes.Location = New System.Drawing.Point(95, 122)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(60, 23)
        Me.btnReportes.TabIndex = 44
        Me.btnReportes.TabStop = False
        Me.btnReportes.Text = "Reportes"
        Me.ToolTip.SetToolTip(Me.btnReportes, "Reportes Estacion")
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'btnDatosIniciales
        '
        Me.btnDatosIniciales.AutoSize = True
        Me.btnDatosIniciales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDatosIniciales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDatosIniciales.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDatosIniciales.ForeColor = System.Drawing.Color.White
        Me.btnDatosIniciales.Location = New System.Drawing.Point(3, 122)
        Me.btnDatosIniciales.Name = "btnDatosIniciales"
        Me.btnDatosIniciales.Size = New System.Drawing.Size(86, 23)
        Me.btnDatosIniciales.TabIndex = 43
        Me.btnDatosIniciales.TabStop = False
        Me.btnDatosIniciales.Text = "DatosIniciales"
        Me.ToolTip.SetToolTip(Me.btnDatosIniciales, "Recupera los datos becesarios para el arranque de la eds, desde el CDCIG")
        Me.btnDatosIniciales.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnlReportes)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(424, 257)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reportes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlReportes
        '
        Me.pnlReportes.Controls.Add(Me.prgExportar)
        Me.pnlReportes.Controls.Add(Me.btnExportar)
        Me.pnlReportes.Controls.Add(Me.label7)
        Me.pnlReportes.Controls.Add(Me.cmbReportes)
        Me.pnlReportes.Location = New System.Drawing.Point(0, 52)
        Me.pnlReportes.Name = "pnlReportes"
        Me.pnlReportes.Size = New System.Drawing.Size(418, 199)
        Me.pnlReportes.TabIndex = 45
        '
        'prgExportar
        '
        Me.prgExportar.Location = New System.Drawing.Point(109, 94)
        Me.prgExportar.Name = "prgExportar"
        Me.prgExportar.Size = New System.Drawing.Size(200, 19)
        Me.prgExportar.TabIndex = 46
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(24, 55)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(58, 13)
        Me.label7.TabIndex = 1
        Me.label7.Text = "Reportes"
        '
        'cmbReportes
        '
        Me.cmbReportes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportes.FormattingEnabled = True
        Me.cmbReportes.Items.AddRange(New Object() {"VENTA", "CANASTILLA", "PEDIDO_DE_COMBUSTIBLE", "VENTAS RP"})
        Me.cmbReportes.Location = New System.Drawing.Point(109, 55)
        Me.cmbReportes.Name = "cmbReportes"
        Me.cmbReportes.Size = New System.Drawing.Size(200, 21)
        Me.cmbReportes.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpFechaFinReporte)
        Me.Panel1.Controls.Add(Me.dtpFechaIniReporte)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(0, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(418, 43)
        Me.Panel1.TabIndex = 46
        '
        'dtpFechaFinReporte
        '
        Me.dtpFechaFinReporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinReporte.Location = New System.Drawing.Point(217, 10)
        Me.dtpFechaFinReporte.Name = "dtpFechaFinReporte"
        Me.dtpFechaFinReporte.Size = New System.Drawing.Size(94, 20)
        Me.dtpFechaFinReporte.TabIndex = 26
        '
        'dtpFechaIniReporte
        '
        Me.dtpFechaIniReporte.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIniReporte.Location = New System.Drawing.Point(74, 10)
        Me.dtpFechaIniReporte.Name = "dtpFechaIniReporte"
        Me.dtpFechaIniReporte.Size = New System.Drawing.Size(94, 20)
        Me.dtpFechaIniReporte.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(171, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Hasta:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Desde:"
        '
        'TabRazonSocial
        '
        Me.TabRazonSocial.Controls.Add(Me.TabPage2)
        Me.TabRazonSocial.Controls.Add(Me.TabPage3)
        Me.TabRazonSocial.Location = New System.Drawing.Point(0, 1)
        Me.TabRazonSocial.Name = "TabRazonSocial"
        Me.TabRazonSocial.SelectedIndex = 0
        Me.TabRazonSocial.Size = New System.Drawing.Size(432, 283)
        Me.TabRazonSocial.TabIndex = 44
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.MensajeLog)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(424, 257)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Mensajes"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'MensajeLog
        '
        Me.MensajeLog.Location = New System.Drawing.Point(3, 4)
        Me.MensajeLog.Name = "MensajeLog"
        Me.MensajeLog.Size = New System.Drawing.Size(421, 248)
        Me.MensajeLog.TabIndex = 0
        Me.MensajeLog.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.prgReversiones)
        Me.GroupBox1.Controls.Add(Me.prgLecturas)
        Me.GroupBox1.Controls.Add(Me.prgPagos)
        Me.GroupBox1.Controls.Add(Me.prgVentas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(349, 112)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        '
        'prgReversiones
        '
        Me.prgReversiones.Location = New System.Drawing.Point(144, 86)
        Me.prgReversiones.Name = "prgReversiones"
        Me.prgReversiones.Size = New System.Drawing.Size(175, 22)
        Me.prgReversiones.TabIndex = 26
        '
        'prgLecturas
        '
        Me.prgLecturas.Location = New System.Drawing.Point(144, 58)
        Me.prgLecturas.Name = "prgLecturas"
        Me.prgLecturas.Size = New System.Drawing.Size(175, 22)
        Me.prgLecturas.TabIndex = 25
        '
        'prgPagos
        '
        Me.prgPagos.Location = New System.Drawing.Point(144, 30)
        Me.prgPagos.Name = "prgPagos"
        Me.prgPagos.Size = New System.Drawing.Size(175, 22)
        Me.prgPagos.TabIndex = 24
        '
        'prgVentas
        '
        Me.prgVentas.Location = New System.Drawing.Point(144, 2)
        Me.prgVentas.Name = "prgVentas"
        Me.prgVentas.Size = New System.Drawing.Size(175, 22)
        Me.prgVentas.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(61, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 22)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Reversiones"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(82, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 22)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Lecturas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 22)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Pagos Extraordinarios"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ventas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnPromocion
        '
        Me.BtnPromocion.AutoSize = True
        Me.BtnPromocion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnPromocion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnPromocion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnPromocion.ForeColor = System.Drawing.Color.White
        Me.BtnPromocion.Location = New System.Drawing.Point(161, 122)
        Me.BtnPromocion.Name = "BtnPromocion"
        Me.BtnPromocion.Size = New System.Drawing.Size(67, 23)
        Me.BtnPromocion.TabIndex = 45
        Me.BtnPromocion.TabStop = False
        Me.BtnPromocion.Text = "Promocion"
        Me.BtnPromocion.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.AutoSize = True
        Me.btnImportar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImportar.ForeColor = System.Drawing.Color.White
        Me.btnImportar.Location = New System.Drawing.Point(295, 123)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(55, 23)
        Me.btnImportar.TabIndex = 42
        Me.btnImportar.TabStop = False
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.AutoSize = True
        Me.btnGenerar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenerar.ForeColor = System.Drawing.Color.White
        Me.btnGenerar.Location = New System.Drawing.Point(234, 123)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(55, 23)
        Me.btnGenerar.TabIndex = 41
        Me.btnGenerar.TabStop = False
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'OpenFileDialogRazonSocial
        '
        Me.OpenFileDialogRazonSocial.Multiselect = True
        '
        'FrmFileGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(451, 296)
        Me.Controls.Add(Me.TabRazonSocial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmFileGenerator"
        Me.Text = "Generador de Archivos de información"
        Me.TabPage2.ResumeLayout(False)
        Me.pnlReportes.ResumeLayout(False)
        Me.pnlReportes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabRazonSocial.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaFinReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIniReporte As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabRazonSocial As System.Windows.Forms.TabControl
    Friend WithEvents pnlReportes As System.Windows.Forms.Panel
    Friend WithEvents prgExportar As System.Windows.Forms.ProgressBar
    Private WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents cmbReportes As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents prgReversiones As System.Windows.Forms.ProgressBar
    Friend WithEvents prgLecturas As System.Windows.Forms.ProgressBar
    Friend WithEvents prgPagos As System.Windows.Forms.ProgressBar
    Friend WithEvents prgVentas As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents BtnPromocion As System.Windows.Forms.Button
    Private WithEvents btnReportes As System.Windows.Forms.Button
    Private WithEvents btnDatosIniciales As System.Windows.Forms.Button
    Private WithEvents btnImportar As System.Windows.Forms.Button
    Private WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialogRazonSocial As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents MensajeLog As System.Windows.Forms.RichTextBox

End Class
