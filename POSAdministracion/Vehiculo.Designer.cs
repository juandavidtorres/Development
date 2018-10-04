namespace gasolutions.UInterface
{
    partial class Vehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vehiculo));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlChip = new System.Windows.Forms.Panel();
            this.lblDatosChip = new System.Windows.Forms.Label();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.txtRom = new System.Windows.Forms.TextBox();
            this.lblRom = new System.Windows.Forms.Label();
            this.btnLeerChip = new System.Windows.Forms.Button();
         
            this.chkControlKm = new System.Windows.Forms.CheckBox();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.txtNuip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCausalBloqueo = new System.Windows.Forms.Label();
            this.cmbCausalBloqueo = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFinanciera = new System.Windows.Forms.Label();
            this.txtPorcentajeCredito = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.cmbFinanciera = new System.Windows.Forms.ComboBox();
            this.lblPorcentajeCredito = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuCredito = new System.Windows.Forms.ToolStripButton();
            this.Popup = new PopupNotifier();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlChip.SuspendLayout();
          
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox2);
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Location = new System.Drawing.Point(13, 23);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(676, 396);
            this.pnlPrincipal.TabIndex = 49;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlDetalle);
            this.groupBox2.Location = new System.Drawing.Point(11, 50);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(659, 337);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.groupBox1);
          
            this.pnlDetalle.Controls.Add(this.chkControlKm);
            this.pnlDetalle.Controls.Add(this.cmbTipoVehiculo);
            this.pnlDetalle.Controls.Add(this.txtNuip);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.lblCausalBloqueo);
            this.pnlDetalle.Controls.Add(this.cmbCausalBloqueo);
            this.pnlDetalle.Controls.Add(this.lblFormaPago);
            this.pnlDetalle.Controls.Add(this.cmbFormaPago);
            this.pnlDetalle.Controls.Add(this.lblFinanciera);
            this.pnlDetalle.Controls.Add(this.txtPorcentajeCredito);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.lblPlaca);
            this.pnlDetalle.Controls.Add(this.txtModelo);
            this.pnlDetalle.Controls.Add(this.lblTipo);
            this.pnlDetalle.Controls.Add(this.lblModelo);
            this.pnlDetalle.Controls.Add(this.cmbFinanciera);
            this.pnlDetalle.Controls.Add(this.lblPorcentajeCredito);
            this.pnlDetalle.Location = new System.Drawing.Point(6, 16);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(645, 311);
            this.pnlDetalle.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlChip);
            this.groupBox1.Location = new System.Drawing.Point(9, 171);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(318, 129);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // pnlChip
            // 
            this.pnlChip.Controls.Add(this.lblDatosChip);
            this.pnlChip.Controls.Add(this.lblPuerto);
            this.pnlChip.Controls.Add(this.cmbPuerto);
            this.pnlChip.Controls.Add(this.txtRom);
            this.pnlChip.Controls.Add(this.lblRom);
            this.pnlChip.Controls.Add(this.btnLeerChip);
            this.pnlChip.Location = new System.Drawing.Point(5, 14);
            this.pnlChip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChip.Name = "pnlChip";
            this.pnlChip.Size = new System.Drawing.Size(306, 112);
            this.pnlChip.TabIndex = 67;
            // 
            // lblDatosChip
            // 
            this.lblDatosChip.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosChip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDatosChip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatosChip.Location = new System.Drawing.Point(24, 4);
            this.lblDatosChip.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDatosChip.Name = "lblDatosChip";
            this.lblDatosChip.Size = new System.Drawing.Size(237, 22);
            this.lblDatosChip.TabIndex = 72;
            this.lblDatosChip.Text = "DATOS CHIP";
            this.lblDatosChip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPuerto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPuerto.Location = new System.Drawing.Point(4, 41);
            this.lblPuerto.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(44, 16);
            this.lblPuerto.TabIndex = 71;
            this.lblPuerto.Text = "Puerto";
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(121, 37);
            this.cmbPuerto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(177, 24);
            this.cmbPuerto.TabIndex = 10;
            // 
            // txtRom
            // 
            this.txtRom.BackColor = System.Drawing.Color.White;
            this.txtRom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRom.Location = new System.Drawing.Point(121, 74);
            this.txtRom.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtRom.Name = "txtRom";
            this.txtRom.Size = new System.Drawing.Size(140, 21);
            this.txtRom.TabIndex = 11;
            this.txtRom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRom
            // 
            this.lblRom.AutoSize = true;
            this.lblRom.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblRom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRom.Location = new System.Drawing.Point(5, 76);
            this.lblRom.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblRom.Name = "lblRom";
            this.lblRom.Size = new System.Drawing.Size(31, 16);
            this.lblRom.TabIndex = 68;
            this.lblRom.Text = "ROM";
            // 
            // btnLeerChip
            // 
            this.btnLeerChip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnLeerChip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerChip.Location = new System.Drawing.Point(267, 70);
            this.btnLeerChip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLeerChip.Name = "btnLeerChip";
            this.btnLeerChip.Size = new System.Drawing.Size(32, 24);
            this.btnLeerChip.TabIndex = 12;
            this.btnLeerChip.Text = "...";
            this.btnLeerChip.UseVisualStyleBackColor = false;
            this.btnLeerChip.Click += new System.EventHandler(this.btnLeerChip_Click);
            // 
            // ctrlOcxChip
            // 
          
            // 
            // chkControlKm
            // 
            this.chkControlKm.AutoSize = true;
            this.chkControlKm.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkControlKm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkControlKm.Location = new System.Drawing.Point(460, 164);
            this.chkControlKm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkControlKm.Name = "chkControlKm";
            this.chkControlKm.Size = new System.Drawing.Size(149, 20);
            this.chkControlKm.TabIndex = 9;
            this.chkControlKm.Text = "Control de Kilometraje";
            this.chkControlKm.UseVisualStyleBackColor = true;
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(123, 64);
            this.cmbTipoVehiculo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(177, 24);
            this.cmbTipoVehiculo.TabIndex = 3;
            // 
            // txtNuip
            // 
            this.txtNuip.BackColor = System.Drawing.Color.White;
            this.txtNuip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuip.Location = new System.Drawing.Point(461, 130);
            this.txtNuip.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtNuip.Name = "txtNuip";
            this.txtNuip.ReadOnly = true;
            this.txtNuip.Size = new System.Drawing.Size(176, 21);
            this.txtNuip.TabIndex = 8;
            this.txtNuip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNuip.DoubleClick += new System.EventHandler(this.txtNuip_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(316, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "NUIP del Cliente";
            // 
            // lblCausalBloqueo
            // 
            this.lblCausalBloqueo.AutoSize = true;
            this.lblCausalBloqueo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCausalBloqueo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCausalBloqueo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCausalBloqueo.Location = new System.Drawing.Point(6, 134);
            this.lblCausalBloqueo.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblCausalBloqueo.Name = "lblCausalBloqueo";
            this.lblCausalBloqueo.Size = new System.Drawing.Size(107, 16);
            this.lblCausalBloqueo.TabIndex = 56;
            this.lblCausalBloqueo.Text = "Causal de Bloqueo";
            // 
            // cmbCausalBloqueo
            // 
            this.cmbCausalBloqueo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCausalBloqueo.FormattingEnabled = true;
            this.cmbCausalBloqueo.Location = new System.Drawing.Point(124, 129);
            this.cmbCausalBloqueo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCausalBloqueo.Name = "cmbCausalBloqueo";
            this.cmbCausalBloqueo.Size = new System.Drawing.Size(177, 24);
            this.cmbCausalBloqueo.TabIndex = 7;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblFormaPago.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormaPago.Location = new System.Drawing.Point(6, 101);
            this.lblFormaPago.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(86, 16);
            this.lblFormaPago.TabIndex = 54;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(124, 96);
            this.cmbFormaPago.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(177, 24);
            this.cmbFormaPago.TabIndex = 5;
            // 
            // lblFinanciera
            // 
            this.lblFinanciera.AutoSize = true;
            this.lblFinanciera.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinanciera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblFinanciera.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFinanciera.Location = new System.Drawing.Point(316, 101);
            this.lblFinanciera.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblFinanciera.Name = "lblFinanciera";
            this.lblFinanciera.Size = new System.Drawing.Size(65, 16);
            this.lblFinanciera.TabIndex = 52;
            this.lblFinanciera.Text = "Financiera";
            // 
            // txtPorcentajeCredito
            // 
            this.txtPorcentajeCredito.BackColor = System.Drawing.Color.White;
            this.txtPorcentajeCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPorcentajeCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeCredito.Location = new System.Drawing.Point(461, 64);
            this.txtPorcentajeCredito.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtPorcentajeCredito.Name = "txtPorcentajeCredito";
            this.txtPorcentajeCredito.Size = new System.Drawing.Size(176, 21);
            this.txtPorcentajeCredito.TabIndex = 4;
            this.txtPorcentajeCredito.Text = "0";
            this.txtPorcentajeCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(124, 30);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(176, 21);
            this.txtPlaca.TabIndex = 1;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlaca.Leave += new System.EventHandler(this.txtPlaca_Leave);
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(641, 22);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPlaca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlaca.Location = new System.Drawing.Point(7, 36);
            this.lblPlaca.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(36, 16);
            this.lblPlaca.TabIndex = 49;
            this.lblPlaca.Text = "Placa";
            // 
            // txtModelo
            // 
            this.txtModelo.BackColor = System.Drawing.Color.White;
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(460, 31);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(177, 21);
            this.txtModelo.TabIndex = 2;
            this.txtModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipo.Location = new System.Drawing.Point(6, 66);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(32, 16);
            this.lblTipo.TabIndex = 42;
            this.lblTipo.Text = "Tipo";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblModelo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblModelo.Location = new System.Drawing.Point(316, 37);
            this.lblModelo.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(47, 16);
            this.lblModelo.TabIndex = 47;
            this.lblModelo.Text = "Modelo";
            // 
            // cmbFinanciera
            // 
            this.cmbFinanciera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinanciera.FormattingEnabled = true;
            this.cmbFinanciera.Location = new System.Drawing.Point(460, 97);
            this.cmbFinanciera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFinanciera.Name = "cmbFinanciera";
            this.cmbFinanciera.Size = new System.Drawing.Size(177, 24);
            this.cmbFinanciera.TabIndex = 6;
            // 
            // lblPorcentajeCredito
            // 
            this.lblPorcentajeCredito.AutoSize = true;
            this.lblPorcentajeCredito.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentajeCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPorcentajeCredito.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPorcentajeCredito.Location = new System.Drawing.Point(316, 66);
            this.lblPorcentajeCredito.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblPorcentajeCredito.Name = "lblPorcentajeCredito";
            this.lblPorcentajeCredito.Size = new System.Drawing.Size(111, 16);
            this.lblPorcentajeCredito.TabIndex = 38;
            this.lblPorcentajeCredito.Text = "Porcentaje Crédito";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuardar,
            this.mnuCerrar,
            this.mnuNuevo,
            this.mnuCredito});
            this.toolStrip1.Location = new System.Drawing.Point(483, 7);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(199, 40);
            this.toolStrip1.TabIndex = 13;
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
            // mnuCredito
            // 
            this.mnuCredito.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuCredito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCredito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCredito.Image = global::gasolutions.UInterface.Properties.Resources.Creditos1;
            this.mnuCredito.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCredito.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCredito.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCredito.Name = "mnuCredito";
            this.mnuCredito.Size = new System.Drawing.Size(34, 36);
            this.mnuCredito.Text = "Creditos Asociados";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlPrincipal);
            this.groupBox3.Location = new System.Drawing.Point(18, 54);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(702, 437);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(308, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 27);
            this.label7.TabIndex = 56;
            this.label7.Text = "VEHÍCULOS";
            // 
            // Vehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 508);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(183, 160);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Vehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Vehiculo_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnlChip.ResumeLayout(false);
            this.pnlChip.PerformLayout();          
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label lblFinanciera;
        private System.Windows.Forms.TextBox txtPorcentajeCredito;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.ComboBox cmbFinanciera;
        private System.Windows.Forms.Label lblPorcentajeCredito;
        private System.Windows.Forms.Label lblCausalBloqueo;
        private System.Windows.Forms.ComboBox cmbCausalBloqueo;
        private System.Windows.Forms.TextBox txtNuip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Panel pnlChip;
        private System.Windows.Forms.Label lblDatosChip;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.TextBox txtRom;
        private System.Windows.Forms.Label lblRom;
        private System.Windows.Forms.Button btnLeerChip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.CheckBox chkControlKm;
        internal PopupNotifier Popup;
       
        private System.Windows.Forms.ToolStripButton mnuCredito;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
    }
}