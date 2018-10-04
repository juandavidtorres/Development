namespace PosStation.gsEmpleados
{
    partial class gsEmpleado
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.chkEsActivo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
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
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.tsbIdentificador = new System.Windows.Forms.ToolStripButton();
            this.Popup = new PopupNotifier();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.pnlPrincipal.Location = new System.Drawing.Point(7, 12);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(685, 236);
            this.pnlPrincipal.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlDetalle);
            this.groupBox1.Location = new System.Drawing.Point(11, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 187);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.chkEsActivo);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtConfirmarClave);
            this.pnlDetalle.Controls.Add(this.lblClave);
            this.pnlDetalle.Controls.Add(this.txtClave);
            this.pnlDetalle.Controls.Add(this.lblCargo);
            this.pnlDetalle.Controls.Add(this.cmbCargo);
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
            this.pnlDetalle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDetalle.Location = new System.Drawing.Point(7, 15);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(656, 162);
            this.pnlDetalle.TabIndex = 4;
            // 
            // chkEsActivo
            // 
            this.chkEsActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEsActivo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEsActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkEsActivo.Location = new System.Drawing.Point(326, 129);
            this.chkEsActivo.Name = "chkEsActivo";
            this.chkEsActivo.Size = new System.Drawing.Size(159, 24);
            this.chkEsActivo.TabIndex = 62;
            this.chkEsActivo.Text = "Es Activo";
            this.chkEsActivo.UseVisualStyleBackColor = true;
            this.chkEsActivo.CheckedChanged += new System.EventHandler(this.chkEsActivo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(326, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "Confirmar Contraseña";
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.BackColor = System.Drawing.Color.White;
            this.txtConfirmarClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarClave.Location = new System.Drawing.Point(470, 50);
            this.txtConfirmarClave.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(177, 21);
            this.txtConfirmarClave.TabIndex = 4;
            this.txtConfirmarClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtConfirmarClave.UseSystemPasswordChar = true;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblClave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClave.Location = new System.Drawing.Point(16, 52);
            this.lblClave.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(66, 16);
            this.lblClave.TabIndex = 58;
            this.lblClave.Text = "Contraseña";
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(125, 49);
            this.txtClave.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(177, 21);
            this.txtClave.TabIndex = 3;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtClave.UseSystemPasswordChar = true;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCargo.Location = new System.Drawing.Point(16, 134);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(38, 16);
            this.lblCargo.TabIndex = 56;
            this.lblCargo.Text = "Cargo";
            // 
            // cmbCargo
            // 
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(125, 130);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(177, 24);
            this.cmbCargo.TabIndex = 9;
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDepartamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDepartamento.Location = new System.Drawing.Point(16, 107);
            this.lblDepartamento.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(80, 16);
            this.lblDepartamento.TabIndex = 54;
            this.lblDepartamento.Text = "Departamento";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(125, 103);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(177, 24);
            this.cmbDepartamento.TabIndex = 7;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            this.cmbDepartamento.DataSourceChanged += new System.EventHandler(this.cmbDepartamento_DataSourceChanged);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiudad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCiudad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCiudad.Location = new System.Drawing.Point(326, 107);
            this.lblCiudad.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(42, 16);
            this.lblCiudad.TabIndex = 52;
            this.lblCiudad.Text = "Ciudad";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(471, 77);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(176, 21);
            this.txtTelefono.TabIndex = 6;
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
            this.lblDetalle.Size = new System.Drawing.Size(647, 18);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDocumento.Location = new System.Drawing.Point(17, 27);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(32, 16);
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
            this.lblDireccion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDireccion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDireccion.Location = new System.Drawing.Point(16, 79);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(56, 16);
            this.lblDireccion.TabIndex = 42;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblNombreCompleto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreCompleto.Location = new System.Drawing.Point(326, 28);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(95, 16);
            this.lblNombreCompleto.TabIndex = 47;
            this.lblNombreCompleto.Text = "Nombre Completo";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(125, 76);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(177, 21);
            this.txtDireccion.TabIndex = 5;
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(470, 104);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(177, 24);
            this.cmbCiudad.TabIndex = 8;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTelefono.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTelefono.Location = new System.Drawing.Point(326, 79);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(50, 16);
            this.lblTelefono.TabIndex = 38;
            this.lblTelefono.Text = "Teléfono";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevo,
            this.mnuGuardar,
            this.mnuCerrar,
            this.tsbIdentificador});
            this.toolStrip1.Location = new System.Drawing.Point(18, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(663, 39);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.AutoSize = false;
            this.mnuNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(34, 34);
            this.mnuNuevo.Text = "Nuevo";
            this.mnuNuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // mnuGuardar
            // 
            this.mnuGuardar.AutoSize = false;
            this.mnuGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuGuardar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.mnuGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuGuardar.Name = "mnuGuardar";
            this.mnuGuardar.Size = new System.Drawing.Size(34, 34);
            this.mnuGuardar.Text = "toolStripButton1";
            this.mnuGuardar.ToolTipText = "Guardar";
            this.mnuGuardar.Click += new System.EventHandler(this.mnuGuardar_Click);
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.AutoSize = false;
            this.mnuCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(34, 34);
            this.mnuCerrar.Text = "Cerrar";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // tsbIdentificador
            // 
            this.tsbIdentificador.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbIdentificador.AutoSize = false;
            this.tsbIdentificador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.tsbIdentificador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbIdentificador.Image = global::gasolutions.UInterface.Properties.Resources.Chip;
            this.tsbIdentificador.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIdentificador.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIdentificador.Name = "tsbIdentificador";
            this.tsbIdentificador.Padding = new System.Windows.Forms.Padding(2);
            this.tsbIdentificador.Size = new System.Drawing.Size(34, 34);
            this.tsbIdentificador.Text = "Identificador Empleado";
            this.tsbIdentificador.Click += new System.EventHandler(this.tsbIdentificador_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(16, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 254);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(298, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 27);
            this.label4.TabIndex = 89;
            this.label4.Text = "EMPLEADOS";
            // 
            // gsEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Name = "gsEmpleado";
            this.Size = new System.Drawing.Size(740, 327);
            this.pnlPrincipal.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.Label lblTelefono;
        internal PopupNotifier Popup;
        private System.Windows.Forms.CheckBox chkEsActivo;
        private System.Windows.Forms.ToolStripButton tsbIdentificador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
    }
}
