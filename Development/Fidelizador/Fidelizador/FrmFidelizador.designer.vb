<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFidelizador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFidelizador))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAnularRedencion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRedencionBonos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVentas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMensajes = New System.Windows.Forms.TextBox()
        Me.Popup = New PopupNotifier()
        Me.tmrVenta = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAnularRedencion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtRedencionBonos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtVentas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 118)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'txtAnularRedencion
        '
        Me.txtAnularRedencion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtAnularRedencion.Location = New System.Drawing.Point(125, 84)
        Me.txtAnularRedencion.Name = "txtAnularRedencion"
        Me.txtAnularRedencion.ReadOnly = True
        Me.txtAnularRedencion.Size = New System.Drawing.Size(128, 20)
        Me.txtAnularRedencion.TabIndex = 23
        Me.txtAnularRedencion.TabStop = False
        Me.txtAnularRedencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 18)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Anular Redencion"
        '
        'txtRedencionBonos
        '
        Me.txtRedencionBonos.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtRedencionBonos.Location = New System.Drawing.Point(125, 51)
        Me.txtRedencionBonos.Name = "txtRedencionBonos"
        Me.txtRedencionBonos.ReadOnly = True
        Me.txtRedencionBonos.Size = New System.Drawing.Size(128, 20)
        Me.txtRedencionBonos.TabIndex = 21
        Me.txtRedencionBonos.TabStop = False
        Me.txtRedencionBonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 18)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Redencion Bonos"
        '
        'txtVentas
        '
        Me.txtVentas.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtVentas.Location = New System.Drawing.Point(125, 19)
        Me.txtVentas.Name = "txtVentas"
        Me.txtVentas.ReadOnly = True
        Me.txtVentas.Size = New System.Drawing.Size(128, 20)
        Me.txtVentas.TabIndex = 15
        Me.txtVentas.TabStop = False
        Me.txtVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(91, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 18)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ventas Fidelizadas"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMensajes)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 126)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(286, 175)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'txtMensajes
        '
        Me.txtMensajes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtMensajes.Location = New System.Drawing.Point(6, 12)
        Me.txtMensajes.Multiline = True
        Me.txtMensajes.Name = "txtMensajes"
        Me.txtMensajes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensajes.Size = New System.Drawing.Size(272, 150)
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
        'tmrVenta
        '
        Me.tmrVenta.Enabled = True
        Me.tmrVenta.Interval = 2000
        '
        'FrmFidelizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(292, 305)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmFidelizador"
        Me.Text = "Soy Leal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVentas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMensajes As System.Windows.Forms.TextBox
    Friend WithEvents Popup As PopupNotifier
    Friend WithEvents tmrVenta As System.Windows.Forms.Timer
    Friend WithEvents txtAnularRedencion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRedencionBonos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
