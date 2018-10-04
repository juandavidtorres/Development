namespace gasolutions
{
    partial class Vehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vehiculos));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.ChkAplicaDataTrack = new System.Windows.Forms.CheckBox();
            this.txtPropietario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlChip = new System.Windows.Forms.Panel();
            this.lblDatosChip = new System.Windows.Forms.Label();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.lblRom = new System.Windows.Forms.Label();
            this.btnLeerChip = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoIdentificador = new System.Windows.Forms.ComboBox();
            this.ctrlOcxChip = new AxGrabacionTmex.AxITmex();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroTanques = new System.Windows.Forms.TextBox();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.txtNuip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCausalBloqueo = new System.Windows.Forms.Label();
            this.cmbCausalBloqueo = new System.Windows.Forms.ComboBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Popup = new PopupNotifier();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCredito_ = new System.Windows.Forms.ToolStripButton();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuplaca = new System.Windows.Forms.ToolStripButton();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlChip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlOcxChip)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox3);
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Location = new System.Drawing.Point(10, 14);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(679, 323);
            this.pnlPrincipal.TabIndex = 50;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlDetalle);
            this.groupBox3.Location = new System.Drawing.Point(5, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 278);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.ChkAplicaDataTrack);
            this.pnlDetalle.Controls.Add(this.txtPropietario);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.groupBox1);
            this.pnlDetalle.Controls.Add(this.ctrlOcxChip);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtNroTanques);
            this.pnlDetalle.Controls.Add(this.cmbTipoVehiculo);
            this.pnlDetalle.Controls.Add(this.txtNuip);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.lblCausalBloqueo);
            this.pnlDetalle.Controls.Add(this.cmbCausalBloqueo);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.lblPlaca);
            this.pnlDetalle.Controls.Add(this.txtModelo);
            this.pnlDetalle.Controls.Add(this.lblTipo);
            this.pnlDetalle.Controls.Add(this.lblModelo);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 12);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(654, 253);
            this.pnlDetalle.TabIndex = 4;
            // 
            // ChkAplicaDataTrack
            // 
            this.ChkAplicaDataTrack.AutoSize = true;
            this.ChkAplicaDataTrack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkAplicaDataTrack.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAplicaDataTrack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.ChkAplicaDataTrack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkAplicaDataTrack.Location = new System.Drawing.Point(324, 121);
            this.ChkAplicaDataTrack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChkAplicaDataTrack.Name = "ChkAplicaDataTrack";
            this.ChkAplicaDataTrack.Size = new System.Drawing.Size(114, 20);
            this.ChkAplicaDataTrack.TabIndex = 92;
            this.ChkAplicaDataTrack.Text = "Aplica Data Track";
            this.ChkAplicaDataTrack.UseVisualStyleBackColor = true;
            // 
            // txtPropietario
            // 
            this.txtPropietario.BackColor = System.Drawing.Color.White;
            this.txtPropietario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPropietario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPropietario.Location = new System.Drawing.Point(470, 70);
            this.txtPropietario.Name = "txtPropietario";
            this.txtPropietario.ReadOnly = true;
            this.txtPropietario.Size = new System.Drawing.Size(177, 21);
            this.txtPropietario.TabIndex = 77;
            this.txtPropietario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPropietario.DoubleClick += new System.EventHandler(this.txtNuipPropietario_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(326, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 76;
            this.label4.Text = "NUIP del Propietario";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTipoIdentificador);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.groupBox1.Location = new System.Drawing.Point(6, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 153);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identificador";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnlChip);
            this.groupBox4.Location = new System.Drawing.Point(7, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 100);
            this.groupBox4.TabIndex = 77;
            this.groupBox4.TabStop = false;
            // 
            // pnlChip
            // 
            this.pnlChip.Controls.Add(this.lblDatosChip);
            this.pnlChip.Controls.Add(this.lblPuerto);
            this.pnlChip.Controls.Add(this.cmbPuerto);
            this.pnlChip.Controls.Add(this.txtIdentificador);
            this.pnlChip.Controls.Add(this.lblRom);
            this.pnlChip.Controls.Add(this.btnLeerChip);
            this.pnlChip.Location = new System.Drawing.Point(4, 11);
            this.pnlChip.Name = "pnlChip";
            this.pnlChip.Size = new System.Drawing.Size(295, 83);
            this.pnlChip.TabIndex = 72;
            // 
            // lblDatosChip
            // 
            this.lblDatosChip.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosChip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDatosChip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatosChip.Location = new System.Drawing.Point(43, 3);
            this.lblDatosChip.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDatosChip.Name = "lblDatosChip";
            this.lblDatosChip.Size = new System.Drawing.Size(207, 18);
            this.lblDatosChip.TabIndex = 72;
            this.lblDatosChip.Text = "DATOS IDENTIFICADOR";
            this.lblDatosChip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPuerto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPuerto.Location = new System.Drawing.Point(3, 33);
            this.lblPuerto.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(42, 16);
            this.lblPuerto.TabIndex = 71;
            this.lblPuerto.Text = "Puerto";
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(56, 26);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(234, 24);
            this.cmbPuerto.TabIndex = 10;
            this.cmbPuerto.SelectedIndexChanged += new System.EventHandler(this.cmbPuerto_SelectedIndexChanged);
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.BackColor = System.Drawing.Color.White;
            this.txtIdentificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificador.Location = new System.Drawing.Point(56, 54);
            this.txtIdentificador.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(194, 21);
            this.txtIdentificador.TabIndex = 11;
            this.txtIdentificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdentificador.TextChanged += new System.EventHandler(this.txtIdentificador_TextChanged);
            // 
            // lblRom
            // 
            this.lblRom.AutoSize = true;
            this.lblRom.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblRom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRom.Location = new System.Drawing.Point(4, 59);
            this.lblRom.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblRom.Name = "lblRom";
            this.lblRom.Size = new System.Drawing.Size(19, 16);
            this.lblRom.TabIndex = 68;
            this.lblRom.Text = "ID";
            // 
            // btnLeerChip
            // 
            this.btnLeerChip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnLeerChip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerChip.Location = new System.Drawing.Point(256, 53);
            this.btnLeerChip.Name = "btnLeerChip";
            this.btnLeerChip.Size = new System.Drawing.Size(32, 24);
            this.btnLeerChip.TabIndex = 12;
            this.btnLeerChip.Text = "...";
            this.btnLeerChip.UseVisualStyleBackColor = false;
            this.btnLeerChip.Click += new System.EventHandler(this.btnLeerChip_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "Tipo Identificación";
            // 
            // cmbTipoIdentificador
            // 
            this.cmbTipoIdentificador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentificador.FormattingEnabled = true;
            this.cmbTipoIdentificador.Location = new System.Drawing.Point(128, 17);
            this.cmbTipoIdentificador.Name = "cmbTipoIdentificador";
            this.cmbTipoIdentificador.Size = new System.Drawing.Size(176, 24);
            this.cmbTipoIdentificador.TabIndex = 75;
            this.cmbTipoIdentificador.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIdentificador_SelectedIndexChanged);
            // 
            // ctrlOcxChip
            // 
            this.ctrlOcxChip.Enabled = true;
            this.ctrlOcxChip.Location = new System.Drawing.Point(568, 122);
            this.ctrlOcxChip.Name = "ctrlOcxChip";
            this.ctrlOcxChip.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ctrlOcxChip.OcxState")));
            this.ctrlOcxChip.Size = new System.Drawing.Size(69, 45);
            this.ctrlOcxChip.TabIndex = 68;
            this.ctrlOcxChip.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(326, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "Nro Tanques";
            // 
            // txtNroTanques
            // 
            this.txtNroTanques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroTanques.Location = new System.Drawing.Point(470, 95);
            this.txtNroTanques.Name = "txtNroTanques";
            this.txtNroTanques.Size = new System.Drawing.Size(177, 20);
            this.txtNroTanques.TabIndex = 69;
            this.txtNroTanques.TextChanged += new System.EventHandler(this.txtNroTanques_TextChanged);
            this.txtNroTanques.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroTanques_KeyDown);
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(134, 45);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(176, 21);
            this.cmbTipoVehiculo.TabIndex = 3;
            this.cmbTipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVehiculo_SelectedIndexChanged);
            // 
            // txtNuip
            // 
            this.txtNuip.BackColor = System.Drawing.Color.White;
            this.txtNuip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuip.Location = new System.Drawing.Point(470, 45);
            this.txtNuip.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtNuip.Name = "txtNuip";
            this.txtNuip.ReadOnly = true;
            this.txtNuip.Size = new System.Drawing.Size(177, 21);
            this.txtNuip.TabIndex = 8;
            this.txtNuip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNuip.TextChanged += new System.EventHandler(this.txtNuip_TextChanged);
            this.txtNuip.DoubleClick += new System.EventHandler(this.txtNuip_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(326, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "NUIP del Cliente";
            // 
            // lblCausalBloqueo
            // 
            this.lblCausalBloqueo.AutoSize = true;
            this.lblCausalBloqueo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCausalBloqueo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCausalBloqueo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCausalBloqueo.Location = new System.Drawing.Point(16, 74);
            this.lblCausalBloqueo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblCausalBloqueo.Name = "lblCausalBloqueo";
            this.lblCausalBloqueo.Size = new System.Drawing.Size(96, 16);
            this.lblCausalBloqueo.TabIndex = 56;
            this.lblCausalBloqueo.Text = "Causal de Bloqueo";
            // 
            // cmbCausalBloqueo
            // 
            this.cmbCausalBloqueo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCausalBloqueo.FormattingEnabled = true;
            this.cmbCausalBloqueo.Location = new System.Drawing.Point(134, 70);
            this.cmbCausalBloqueo.Name = "cmbCausalBloqueo";
            this.cmbCausalBloqueo.Size = new System.Drawing.Size(176, 21);
            this.cmbCausalBloqueo.TabIndex = 7;
            this.cmbCausalBloqueo.SelectedIndexChanged += new System.EventHandler(this.cmbCausalBloqueo_SelectedIndexChanged);
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(134, 20);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(176, 21);
            this.txtPlaca.TabIndex = 1;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlaca.TextChanged += new System.EventHandler(this.txtPlaca_TextChanged);
            this.txtPlaca.Leave += new System.EventHandler(this.txtPlaca_Leave);
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(646, 18);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPlaca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlaca.Location = new System.Drawing.Point(17, 24);
            this.lblPlaca.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(34, 16);
            this.lblPlaca.TabIndex = 49;
            this.lblPlaca.Text = "Placa";
            // 
            // txtModelo
            // 
            this.txtModelo.BackColor = System.Drawing.Color.White;
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(470, 20);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(177, 21);
            this.txtModelo.TabIndex = 2;
            this.txtModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtModelo.TextChanged += new System.EventHandler(this.txtModelo_TextChanged);
            this.txtModelo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtModelo_KeyDown);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipo.Location = new System.Drawing.Point(16, 49);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(29, 16);
            this.lblTipo.TabIndex = 42;
            this.lblTipo.Text = "Tipo";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblModelo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblModelo.Location = new System.Drawing.Point(326, 24);
            this.lblModelo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 16);
            this.lblModelo.TabIndex = 47;
            this.lblModelo.Text = "Modelo";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuardar,
            this.mnuCredito_,
            this.mnuSalir,
            this.mnuNuevo,
            this.mnuplaca});
            this.toolStrip1.Location = new System.Drawing.Point(480, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(193, 40);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
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
            this.Popup.ShowGrip = false;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlPrincipal);
            this.groupBox2.Location = new System.Drawing.Point(18, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 343);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(305, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 27);
            this.label7.TabIndex = 57;
            this.label7.Text = "VEHÍCULOS";
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
            // mnuCredito_
            // 
            this.mnuCredito_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCredito_.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCredito_.Image = global::gasolutions.UInterface.Properties.Resources.Creditos;
            this.mnuCredito_.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCredito_.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCredito_.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.mnuCredito_.Name = "mnuCredito_";
            this.mnuCredito_.Size = new System.Drawing.Size(34, 36);
            this.mnuCredito_.Text = "toolStripButton1";
            this.mnuCredito_.ToolTipText = "Créditos Asociados";
            this.mnuCredito_.Click += new System.EventHandler(this.mnuCredito__Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Margin = new System.Windows.Forms.Padding(0, 2, 1, 2);
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(36, 36);
            this.mnuSalir.Text = "Cerrar";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Margin = new System.Windows.Forms.Padding(2, 2, 1, 2);
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(35, 36);
            this.mnuNuevo.Text = "Nuevo";
            this.mnuNuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // mnuplaca
            // 
            this.mnuplaca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuplaca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuplaca.Image = global::gasolutions.UInterface.Properties.Resources.Vehiculo__2_;
            this.mnuplaca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuplaca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuplaca.Margin = new System.Windows.Forms.Padding(2, 2, 1, 2);
            this.mnuplaca.Name = "mnuplaca";
            this.mnuplaca.Size = new System.Drawing.Size(37, 36);
            this.mnuplaca.Text = "Placas";
            this.mnuplaca.ToolTipText = "Placas";
            this.mnuplaca.Click += new System.EventHandler(this.mnuplaca_Click);
            // 
            // Vehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Name = "Vehiculos";
            this.Size = new System.Drawing.Size(734, 419);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.pnlChip.ResumeLayout(false);
            this.pnlChip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlOcxChip)).EndInit();
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
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.TextBox txtNuip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCausalBloqueo;
        private System.Windows.Forms.ComboBox cmbCausalBloqueo;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblModelo;
        internal PopupNotifier Popup;
        private AxGrabacionTmex.AxITmex ctrlOcxChip;
        private System.Windows.Forms.TextBox txtNroTanques;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlChip;
        private System.Windows.Forms.Label lblDatosChip;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label lblRom;
        private System.Windows.Forms.Button btnLeerChip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoIdentificador;
        private System.Windows.Forms.TextBox txtPropietario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.ToolStripButton mnuCredito_;
        private System.Windows.Forms.CheckBox ChkAplicaDataTrack;
        private System.Windows.Forms.ToolStripButton mnuplaca;
    }
}
