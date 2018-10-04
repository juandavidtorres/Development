<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetLog
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GetLog))
        Me.pnlFecha = New System.Windows.Forms.Panel
        Me.GsLoggin1 = New Controles.gsLoggin
        Me.dtpFInicial = New System.Windows.Forms.DateTimePicker
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.pnlFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFecha
        '
        Me.pnlFecha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFecha.Controls.Add(Me.btnAceptar)
        Me.pnlFecha.Controls.Add(Me.dtpFFinal)
        Me.pnlFecha.Controls.Add(Me.dtpFInicial)
        Me.pnlFecha.Location = New System.Drawing.Point(0, 539)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.Size = New System.Drawing.Size(837, 26)
        Me.pnlFecha.TabIndex = 1
        '
        'GsLoggin1
        '
        Me.GsLoggin1.AutoScroll = True
        Me.GsLoggin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GsLoggin1.Location = New System.Drawing.Point(0, 0)
        Me.GsLoggin1.Name = "GsLoggin1"
        Me.GsLoggin1.Size = New System.Drawing.Size(838, 565)
        Me.GsLoggin1.TabIndex = 0
        '
        'dtpFInicial
        '
        Me.dtpFInicial.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpFInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicial.Location = New System.Drawing.Point(2, 2)
        Me.dtpFInicial.Name = "dtpFInicial"
        Me.dtpFInicial.Size = New System.Drawing.Size(142, 20)
        Me.dtpFInicial.TabIndex = 0
        Me.dtpFInicial.Value = New Date(2008, 3, 3, 10, 28, 55, 0)
        '
        'dtpFFinal
        '
        Me.dtpFFinal.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpFFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFFinal.Location = New System.Drawing.Point(147, 2)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(142, 20)
        Me.dtpFFinal.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(292, 1)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(83, 22)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'GetLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 565)
        Me.Controls.Add(Me.pnlFecha)
        Me.Controls.Add(Me.GsLoggin1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GetLog"
        Me.Text = "Consultar Log de Aplicación"
        Me.pnlFecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GsLoggin1 As Controles.gsLoggin
    Friend WithEvents pnlFecha As System.Windows.Forms.Panel
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
