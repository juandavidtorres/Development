<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Backup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Backup))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbDataBase = New System.Windows.Forms.ComboBox
        Me.btnGenerar = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Base de Datos"
        '
        'cmbDataBase
        '
        Me.cmbDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDataBase.FormattingEnabled = True
        Me.cmbDataBase.Location = New System.Drawing.Point(95, 5)
        Me.cmbDataBase.Name = "cmbDataBase"
        Me.cmbDataBase.Size = New System.Drawing.Size(214, 21)
        Me.cmbDataBase.TabIndex = 1
        '
        'btnGenerar
        '
        Me.btnGenerar.BackgroundImage = CType(resources.GetObject("btnGenerar.BackgroundImage"), System.Drawing.Image)
        Me.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGenerar.Location = New System.Drawing.Point(266, 68)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(43, 34)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ruta"
        '
        'lblPath
        '
        Me.lblPath.BackColor = System.Drawing.Color.White
        Me.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPath.Location = New System.Drawing.Point(95, 27)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(214, 38)
        Me.lblPath.TabIndex = 4
        '
        'Backup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 102)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.cmbDataBase)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Backup"
        Me.Text = "Backup Bases de Datos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDataBase As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog

End Class
