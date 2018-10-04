<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductoDisplay
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
        Me.lblNombreProducto = New System.Windows.Forms.Label()
        Me.lblPrecioProducto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreProducto.Location = New System.Drawing.Point(3, 2)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(93, 19)
        Me.lblNombreProducto.TabIndex = 0
        Me.lblNombreProducto.Text = "GNV"
        Me.lblNombreProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPrecioProducto
        '
        Me.lblPrecioProducto.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioProducto.Location = New System.Drawing.Point(112, 2)
        Me.lblPrecioProducto.Name = "lblPrecioProducto"
        Me.lblPrecioProducto.Size = New System.Drawing.Size(93, 17)
        Me.lblPrecioProducto.TabIndex = 1
        Me.lblPrecioProducto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProductoDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblPrecioProducto)
        Me.Controls.Add(Me.lblNombreProducto)
        Me.Name = "ProductoDisplay"
        Me.Size = New System.Drawing.Size(205, 22)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNombreProducto As System.Windows.Forms.Label
    Friend WithEvents lblPrecioProducto As System.Windows.Forms.Label

End Class
