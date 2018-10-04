<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComunicador
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGerenciamiento = New System.Windows.Forms.TextBox()
        Me.txtLecturas = New System.Windows.Forms.TextBox()
        Me.txtVentas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tmrVenta = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMensajes = New System.Windows.Forms.TextBox()
        Me.Popup = New PopupNotifier()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtGerenciamiento)
        Me.GroupBox1.Controls.Add(Me.txtLecturas)
        Me.GroupBox1.Controls.Add(Me.txtVentas)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 110)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Gerenciamiento"
        '
        'txtGerenciamiento
        '
        Me.txtGerenciamiento.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtGerenciamiento.Location = New System.Drawing.Point(121, 65)
        Me.txtGerenciamiento.Name = "txtGerenciamiento"
        Me.txtGerenciamiento.ReadOnly = True
        Me.txtGerenciamiento.Size = New System.Drawing.Size(100, 20)
        Me.txtGerenciamiento.TabIndex = 18
        Me.txtGerenciamiento.TabStop = False
        Me.txtGerenciamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLecturas
        '
        Me.txtLecturas.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtLecturas.Location = New System.Drawing.Point(121, 39)
        Me.txtLecturas.Name = "txtLecturas"
        Me.txtLecturas.ReadOnly = True
        Me.txtLecturas.Size = New System.Drawing.Size(100, 20)
        Me.txtLecturas.TabIndex = 17
        Me.txtLecturas.TabStop = False
        Me.txtLecturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVentas
        '
        Me.txtVentas.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtVentas.Location = New System.Drawing.Point(121, 13)
        Me.txtVentas.Name = "txtVentas"
        Me.txtVentas.ReadOnly = True
        Me.txtVentas.Size = New System.Drawing.Size(100, 20)
        Me.txtVentas.TabIndex = 15
        Me.txtVentas.TabStop = False
        Me.txtVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Turnos"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ventas"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'tmrVenta
        '
        Me.tmrVenta.Enabled = True
        Me.tmrVenta.Interval = 3000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMensajes)
        Me.GroupBox2.Location = New System.Drawing.Point(247, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 110)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'txtMensajes
        '
        Me.txtMensajes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMensajes.Location = New System.Drawing.Point(6, 10)
        Me.txtMensajes.Multiline = True
        Me.txtMensajes.Name = "txtMensajes"
        Me.txtMensajes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensajes.Size = New System.Drawing.Size(311, 87)
        Me.txtMensajes.TabIndex = 15
        Me.txtMensajes.TabStop = False
        Me.txtMensajes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Popup
        '
        Me.Popup.BodyColor = System.Drawing.Color.DarkGreen
        Me.Popup.CloseButton = False
        Me.Popup.ContentColor = System.Drawing.Color.White
        Me.Popup.ContentFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Popup.ContentText = Nothing
        Me.Popup.HeaderColor = System.Drawing.Color.Green
        Me.Popup.Image = Nothing
        Me.Popup.ImagePosition = New System.Drawing.Point(12, 21)
        Me.Popup.ImageSize = New System.Drawing.Size(32, 32)
        Me.Popup.OptionsMenu = Nothing
        Me.Popup.Size = New System.Drawing.Size(400, 100)
        Me.Popup.TextPadding = New System.Windows.Forms.Padding(0)
        Me.Popup.TitleFont = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Popup.TitleText = Nothing
        '
        'FrmComunicador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(578, 117)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FrmComunicador"
        Me.Text = "Control de Sincronizacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLecturas As System.Windows.Forms.TextBox
    Friend WithEvents txtVentas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents tmrVenta As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMensajes As System.Windows.Forms.TextBox
    Friend WithEvents Popup As PopupNotifier
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGerenciamiento As System.Windows.Forms.TextBox

End Class
