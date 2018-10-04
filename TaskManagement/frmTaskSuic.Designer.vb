<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTaskSuic
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTaskSuic))
        Me.tmrCargar = New System.Windows.Forms.Timer(Me.components)
        Me.txtRutaPlanos = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMensajes = New System.Windows.Forms.TextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Hilo = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'tmrCargar
        '
        Me.tmrCargar.Interval = 1000
        '
        'txtRutaPlanos
        '
        Me.txtRutaPlanos.BackColor = System.Drawing.Color.White
        Me.txtRutaPlanos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaPlanos.Location = New System.Drawing.Point(92, 3)
        Me.txtRutaPlanos.Name = "txtRutaPlanos"
        Me.txtRutaPlanos.ReadOnly = True
        Me.txtRutaPlanos.Size = New System.Drawing.Size(259, 20)
        Me.txtRutaPlanos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ruta Archivos"
        '
        'txtMensajes
        '
        Me.txtMensajes.BackColor = System.Drawing.Color.White
        Me.txtMensajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMensajes.Location = New System.Drawing.Point(6, 26)
        Me.txtMensajes.Multiline = True
        Me.txtMensajes.Name = "txtMensajes"
        Me.txtMensajes.ReadOnly = True
        Me.txtMensajes.Size = New System.Drawing.Size(345, 103)
        Me.txtMensajes.TabIndex = 2
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(278, 130)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Text = "&Procesar"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'Hilo
        '
        Me.Hilo.WorkerReportsProgress = True
        '
        'frmTaskSuic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(356, 155)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.txtMensajes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRutaPlanos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTaskSuic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar Información SUIC"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrCargar As System.Windows.Forms.Timer
    Friend WithEvents txtRutaPlanos As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMensajes As System.Windows.Forms.TextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Hilo As System.ComponentModel.BackgroundWorker
End Class
