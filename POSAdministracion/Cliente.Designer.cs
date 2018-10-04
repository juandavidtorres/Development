namespace gasolutions.UInterface
{
    partial class Cliente
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuVehiculos = new System.Windows.Forms.ToolStripButton();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.Popup = new PopupNotifier();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Location = new System.Drawing.Point(2, 15);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(703, 197);
            this.pnlPrincipal.TabIndex = 48;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlDetalle);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 137);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.lblDepartamento);
            this.pnlDetalle.Controls.Add(this.cmbDepartamento);
            this.pnlDetalle.Controls.Add(this.lblCiudad);
            this.pnlDetalle.Controls.Add(this.txtTelefono);
            this.pnlDetalle.Controls.Add(this.txtDocumento);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.lblDocumento);
            this.pnlDetalle.Controls.Add(this.txtNombre);
            this.pnlDetalle.Controls.Add(this.lblDireccion);
            this.pnlDetalle.Controls.Add(this.lblNombreCompleto);
            this.pnlDetalle.Controls.Add(this.txtDireccion);
            this.pnlDetalle.Controls.Add(this.cmbCiudad);
            this.pnlDetalle.Controls.Add(this.lblTelefono);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 18);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(666, 105);
            this.pnlDetalle.TabIndex = 4;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDepartamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDepartamento.Location = new System.Drawing.Point(16, 80);
            this.lblDepartamento.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(84, 16);
            this.lblDepartamento.TabIndex = 54;
            this.lblDepartamento.Text = "Departamento";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(125, 76);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(177, 21);
            this.cmbDepartamento.TabIndex = 5;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            this.cmbDepartamento.DataSourceChanged += new System.EventHandler(this.cmbDepartamento_DataSourceChanged);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCiudad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCiudad.Location = new System.Drawing.Point(326, 80);
            this.lblCiudad.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(45, 16);
            this.lblCiudad.TabIndex = 52;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(471, 50);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(176, 21);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.White;
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(125, 22);
            this.txtDocumento.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(176, 21);
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
            this.lblDetalle.Size = new System.Drawing.Size(662, 18);
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
            this.lblDocumento.Location = new System.Drawing.Point(17, 27);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(31, 16);
            this.lblDocumento.TabIndex = 49;
            this.lblDocumento.Text = "NUIP";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(470, 23);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDireccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDireccion.Location = new System.Drawing.Point(16, 52);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(61, 16);
            this.lblDireccion.TabIndex = 42;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblNombreCompleto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreCompleto.Location = new System.Drawing.Point(326, 28);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(104, 16);
            this.lblNombreCompleto.TabIndex = 47;
            this.lblNombreCompleto.Text = "Nombre Completo";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(125, 49);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(177, 21);
            this.txtDireccion.TabIndex = 3;
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(470, 77);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(177, 21);
            this.cmbCiudad.TabIndex = 6;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTelefono.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTelefono.Location = new System.Drawing.Point(326, 52);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(57, 16);
            this.lblTelefono.TabIndex = 38;
            this.lblTelefono.Text = "Teléfono";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevo,
            this.mnuVehiculos,
            this.mnuGuardar,
            this.mnuCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(502, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(170, 40);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
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
            // mnuVehiculos
            // 
            this.mnuVehiculos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuVehiculos.AutoSize = false;
            this.mnuVehiculos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuVehiculos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mnuVehiculos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuVehiculos.Image = global::gasolutions.UInterface.Properties.Resources.Vehiculo__2_;
            this.mnuVehiculos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuVehiculos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuVehiculos.Margin = new System.Windows.Forms.Padding(2);
            this.mnuVehiculos.Name = "mnuVehiculos";
            this.mnuVehiculos.Size = new System.Drawing.Size(36, 36);
            this.mnuVehiculos.Text = "Vehiculos Asociados";
            this.mnuVehiculos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mnuVehiculos.Click += new System.EventHandler(this.mnuVehiculos_Click);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlPrincipal);
            this.groupBox2.Location = new System.Drawing.Point(15, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 218);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(323, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 27);
            this.label1.TabIndex = 50;
            this.label1.Text = "CLIENTE";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 287);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(183, 160);
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        internal PopupNotifier Popup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.ToolStripButton mnuVehiculos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;

    }
}