//gasolutions.UInterface
namespace PosStation.gsConductores
  
{
    partial class gsConductor
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.ChkActivo = new System.Windows.Forms.CheckBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtIdentificacionCliente = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.Popup = new PopupNotifier();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarConductor = new System.Windows.Forms.ToolStripButton();
            this.pnlPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Controls.Add(this.groupBox2);
            this.pnlPrincipal.Location = new System.Drawing.Point(13, 14);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(681, 219);
            this.pnlPrincipal.TabIndex = 49;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevo,
            this.btnBuscarConductor,
            this.mnuGuardar,
            this.mnuCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(518, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(191, 40);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuGuardar
            // 
            this.mnuGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuGuardar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.mnuGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuGuardar.Name = "mnuGuardar";
            this.mnuGuardar.Size = new System.Drawing.Size(35, 36);
            this.mnuGuardar.Text = "toolStripButton1";
            this.mnuGuardar.ToolTipText = "Guardar";
            this.mnuGuardar.Click += new System.EventHandler(this.mnuGuardar_Click);
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(35, 36);
            this.mnuNuevo.Text = "Nuevo";
            this.mnuNuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(36, 36);
            this.mnuCerrar.Text = "Cerrar";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlDetalle);
            this.groupBox2.Location = new System.Drawing.Point(3, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 160);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.ChkActivo);
            this.pnlDetalle.Controls.Add(this.txtDocumento);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.lblDocumento);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.lblDireccion);
            this.pnlDetalle.Controls.Add(this.lblNombreCompleto);
            this.pnlDetalle.Controls.Add(this.txtIdentificacionCliente);
            this.pnlDetalle.Controls.Add(this.lblTelefono);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 11);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(662, 139);
            this.pnlDetalle.TabIndex = 4;
            // 
            // ChkActivo
            // 
            this.ChkActivo.AutoSize = true;
            this.ChkActivo.Location = new System.Drawing.Point(137, 107);
            this.ChkActivo.Name = "ChkActivo";
            this.ChkActivo.Size = new System.Drawing.Size(80, 17);
            this.ChkActivo.TabIndex = 50;
            this.ChkActivo.Text = "checkBox1";
            this.ChkActivo.UseVisualStyleBackColor = true;
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.White;
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(137, 24);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(261, 21);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDocumento.Leave += new System.EventHandler(this.txtDocumento_Leave);
            
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(653, 18);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDocumento.Location = new System.Drawing.Point(8, 28);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(87, 16);
            this.lblDocumento.TabIndex = 49;
            this.lblDocumento.Text = "Identificación:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(137, 51);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(262, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDireccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDireccion.Location = new System.Drawing.Point(7, 82);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(128, 16);
            this.lblDireccion.TabIndex = 42;
            this.lblDireccion.Text = "Identificación Cliente:";
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblNombreCompleto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreCompleto.Location = new System.Drawing.Point(4, 55);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(108, 16);
            this.lblNombreCompleto.TabIndex = 47;
            this.lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // txtIdentificacionCliente
            // 
            this.txtIdentificacionCliente.BackColor = System.Drawing.Color.White;
            this.txtIdentificacionCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificacionCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacionCliente.Location = new System.Drawing.Point(137, 78);
            this.txtIdentificacionCliente.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtIdentificacionCliente.Name = "txtIdentificacionCliente";
            this.txtIdentificacionCliente.Size = new System.Drawing.Size(262, 21);
            this.txtIdentificacionCliente.TabIndex = 3;
            this.txtIdentificacionCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTelefono.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTelefono.Location = new System.Drawing.Point(8, 107);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(47, 16);
            this.lblTelefono.TabIndex = 38;
            this.lblTelefono.Text = "Activo:";
            // 
            // Popup
            // 
            this.Popup.BodyColor = System.Drawing.Color.SteelBlue;
            this.Popup.CloseButton = false;
            this.Popup.ContentColor = System.Drawing.Color.White;
            this.Popup.ContentFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Popup.ContentText = null;
            this.Popup.HeaderColor = System.Drawing.Color.SteelBlue;
            this.Popup.Image = null;
            this.Popup.ImagePosition = new System.Drawing.Point(12, 21);
            this.Popup.ImageSize = new System.Drawing.Size(32, 32);
            this.Popup.OptionsMenu = null;
            this.Popup.ShowDelay = 1000;
            this.Popup.ShowGrip = false;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(14, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 241);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(329, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 27);
            this.label2.TabIndex = 51;
            this.label2.Text = "CONDUCTOR";
            // 
            // btnBuscarConductor
            // 
            this.btnBuscarConductor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscarConductor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscarConductor.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnBuscarConductor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBuscarConductor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscarConductor.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarConductor.Name = "btnBuscarConductor";
            this.btnBuscarConductor.Size = new System.Drawing.Size(35, 36);
            this.btnBuscarConductor.Text = "Cerrar";
            this.btnBuscarConductor.Click += new System.EventHandler(this.btnBuscarConductor_Click);
            // 
            // gsConductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "gsConductor";
            this.Size = new System.Drawing.Size(740, 310);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtIdentificacionCliente;
        private System.Windows.Forms.Label lblTelefono;
        internal PopupNotifier Popup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkActivo;
        private System.Windows.Forms.ToolStripButton btnBuscarConductor;
    }
}
