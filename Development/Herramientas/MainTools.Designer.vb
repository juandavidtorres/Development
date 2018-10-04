<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainTools
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainTools))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbBackup = New System.Windows.Forms.ToolStripButton()
        Me.tsbLoggin = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbBackup, Me.tsbLoggin, Me.tsbSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(402, 56)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbBackup
        '
        Me.tsbBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbBackup.Image = CType(resources.GetObject("tsbBackup.Image"), System.Drawing.Image)
        Me.tsbBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbBackup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbBackup.Name = "tsbBackup"
        Me.tsbBackup.Size = New System.Drawing.Size(53, 53)
        Me.tsbBackup.Text = "Generacion de Backup"
        '
        'tsbLoggin
        '
        Me.tsbLoggin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLoggin.Image = CType(resources.GetObject("tsbLoggin.Image"), System.Drawing.Image)
        Me.tsbLoggin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbLoggin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLoggin.Name = "tsbLoggin"
        Me.tsbLoggin.Size = New System.Drawing.Size(52, 53)
        Me.tsbLoggin.Text = "Visualizar Log de Aplicaciones"
        '
        'tsbSalir
        '
        Me.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(51, 53)
        Me.tsbSalir.Text = "Salir de la Aplicación"
        '
        'MainTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 55)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainTools"
        Me.Text = "Tools"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbBackup As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbLoggin As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
End Class
