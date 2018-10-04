
namespace POSAdministracion
{
    partial class gsTarjeta
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlTarjeta = new System.Windows.Forms.Panel();
            this.lbltotal = new System.Windows.Forms.Label();
            this.chkTarjetaActiva = new System.Windows.Forms.CheckBox();
            this.pctBuscar = new System.Windows.Forms.PictureBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPieCupo = new System.Windows.Forms.Label();
            this.lblPieTarjeta = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.lblCupo = new System.Windows.Forms.Label();
            this.lblNrotarjeta = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnInactivar = new System.Windows.Forms.Button();
            this.chkTarjetaActivaTI = new System.Windows.Forms.CheckBox();
            this.txtClienteTInactiva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTarjetaTInactiva = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pctBuscarClientesTarjetasInactivas = new System.Windows.Forms.PictureBox();
            this.tabAsociarVehiculo = new System.Windows.Forms.TabPage();
            this.btnAsociar = new System.Windows.Forms.Button();
            this.btnVehiculos = new System.Windows.Forms.Button();
            this.btnTarjetas = new System.Windows.Forms.Button();
            this.txtPlacaVehiculo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabRecarga = new System.Windows.Forms.TabPage();
            this.btnBuscarTarjetas = new System.Windows.Forms.Button();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTarjeta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTipCrear = new System.Windows.Forms.ToolTip(this.components);
            this.label24 = new System.Windows.Forms.Label();
            this.txtcupo = new JRINCCustomControls.currencyTextBox(this.components);
            this.tbRecarga = new JRINCCustomControls.currencyTextBox(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlTarjeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBuscar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBuscarClientesTarjetasInactivas)).BeginInit();
            this.tabAsociarVehiculo.SuspendLayout();
            this.tabRecarga.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabAsociarVehiculo);
            this.tabControl1.Controls.Add(this.tabRecarga);
            this.tabControl1.Location = new System.Drawing.Point(23, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(426, 297);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlTarjeta);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(418, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Crear Tarjeta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlTarjeta
            // 
            this.pnlTarjeta.BackColor = System.Drawing.Color.White;
            this.pnlTarjeta.Controls.Add(this.lbltotal);
            this.pnlTarjeta.Controls.Add(this.txtcupo);
            this.pnlTarjeta.Controls.Add(this.chkTarjetaActiva);
            this.pnlTarjeta.Controls.Add(this.pctBuscar);
            this.pnlTarjeta.Controls.Add(this.txtCliente);
            this.pnlTarjeta.Controls.Add(this.lblCliente);
            this.pnlTarjeta.Controls.Add(this.lblPieCupo);
            this.pnlTarjeta.Controls.Add(this.lblPieTarjeta);
            this.pnlTarjeta.Controls.Add(this.btnCrear);
            this.pnlTarjeta.Controls.Add(this.txtTarjeta);
            this.pnlTarjeta.Controls.Add(this.lblCupo);
            this.pnlTarjeta.Controls.Add(this.lblNrotarjeta);
            this.pnlTarjeta.Controls.Add(this.lblTitulo);
            this.pnlTarjeta.Location = new System.Drawing.Point(6, 6);
            this.pnlTarjeta.Name = "pnlTarjeta";
            this.pnlTarjeta.Size = new System.Drawing.Size(409, 259);
            this.pnlTarjeta.TabIndex = 1;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.Red;
            this.lbltotal.Location = new System.Drawing.Point(316, 109);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(0, 18);
            this.lbltotal.TabIndex = 104;
            // 
            // chkTarjetaActiva
            // 
            this.chkTarjetaActiva.AutoSize = true;
            this.chkTarjetaActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTarjetaActiva.Checked = true;
            this.chkTarjetaActiva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTarjetaActiva.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTarjetaActiva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkTarjetaActiva.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkTarjetaActiva.Location = new System.Drawing.Point(23, 135);
            this.chkTarjetaActiva.Name = "chkTarjetaActiva";
            this.chkTarjetaActiva.Size = new System.Drawing.Size(102, 20);
            this.chkTarjetaActiva.TabIndex = 100;
            this.chkTarjetaActiva.Text = "Tarjeta Activa:";
            this.chkTarjetaActiva.UseVisualStyleBackColor = true;
            // 
            // pctBuscar
            // 
            this.pctBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.pctBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.pctBuscar.InitialImage = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.pctBuscar.Location = new System.Drawing.Point(319, 53);
            this.pctBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.pctBuscar.Name = "pctBuscar";
            this.pctBuscar.Size = new System.Drawing.Size(34, 34);
            this.pctBuscar.TabIndex = 10;
            this.pctBuscar.TabStop = false;
            this.pctBuscar.Click += new System.EventHandler(this.pctBuscar_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(132, 58);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(178, 20);
            this.txtCliente.TabIndex = 9;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCliente.Location = new System.Drawing.Point(20, 61);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 16);
            this.lblCliente.TabIndex = 8;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblPieCupo
            // 
            this.lblPieCupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPieCupo.Location = new System.Drawing.Point(10, 220);
            this.lblPieCupo.Name = "lblPieCupo";
            this.lblPieCupo.Size = new System.Drawing.Size(343, 23);
            this.lblPieCupo.TabIndex = 7;
            this.lblPieCupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPieTarjeta
            // 
            this.lblPieTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPieTarjeta.Location = new System.Drawing.Point(10, 197);
            this.lblPieTarjeta.Name = "lblPieTarjeta";
            this.lblPieTarjeta.Size = new System.Drawing.Size(343, 23);
            this.lblPieTarjeta.TabIndex = 6;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(132, 135);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(108, 24);
            this.btnCrear.TabIndex = 5;
            this.btnCrear.Text = "Crear Tarjeta";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarjeta.Location = new System.Drawing.Point(132, 83);
            this.txtTarjeta.MaxLength = 50;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(178, 20);
            this.txtTarjeta.TabIndex = 3;
            this.txtTarjeta.Leave += new System.EventHandler(this.txtTarjeta_Leave);
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCupo.Location = new System.Drawing.Point(20, 112);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(37, 16);
            this.lblCupo.TabIndex = 2;
            this.lblCupo.Text = "Cupo:";
            // 
            // lblNrotarjeta
            // 
            this.lblNrotarjeta.AutoSize = true;
            this.lblNrotarjeta.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNrotarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblNrotarjeta.Location = new System.Drawing.Point(20, 86);
            this.lblNrotarjeta.Name = "lblNrotarjeta";
            this.lblNrotarjeta.Size = new System.Drawing.Size(90, 16);
            this.lblNrotarjeta.TabIndex = 1;
            this.lblNrotarjeta.Text = "Número Tarjeta:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(348, 23);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tarjeta";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.btnInactivar);
            this.tabPage2.Controls.Add(this.chkTarjetaActivaTI);
            this.tabPage2.Controls.Add(this.txtClienteTInactiva);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtTarjetaTInactiva);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pctBuscarClientesTarjetasInactivas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(418, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inactivacion de tarjetas";
            // 
            // btnInactivar
            // 
            this.btnInactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnInactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivar.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactivar.ForeColor = System.Drawing.Color.White;
            this.btnInactivar.Location = new System.Drawing.Point(172, 160);
            this.btnInactivar.Name = "btnInactivar";
            this.btnInactivar.Size = new System.Drawing.Size(108, 24);
            this.btnInactivar.TabIndex = 102;
            this.btnInactivar.Text = "Inactivar Tarjeta";
            this.btnInactivar.UseVisualStyleBackColor = false;
            this.btnInactivar.Click += new System.EventHandler(this.btnInactivar_Click);
            // 
            // chkTarjetaActivaTI
            // 
            this.chkTarjetaActivaTI.AutoSize = true;
            this.chkTarjetaActivaTI.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTarjetaActivaTI.Checked = true;
            this.chkTarjetaActivaTI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTarjetaActivaTI.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTarjetaActivaTI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkTarjetaActivaTI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkTarjetaActivaTI.Location = new System.Drawing.Point(22, 119);
            this.chkTarjetaActivaTI.Name = "chkTarjetaActivaTI";
            this.chkTarjetaActivaTI.Size = new System.Drawing.Size(105, 20);
            this.chkTarjetaActivaTI.TabIndex = 101;
            this.chkTarjetaActivaTI.Text = "Tarjeta Activa:";
            this.chkTarjetaActivaTI.UseVisualStyleBackColor = true;
            // 
            // txtClienteTInactiva
            // 
            this.txtClienteTInactiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClienteTInactiva.Location = new System.Drawing.Point(137, 59);
            this.txtClienteTInactiva.MaxLength = 50;
            this.txtClienteTInactiva.Name = "txtClienteTInactiva";
            this.txtClienteTInactiva.Size = new System.Drawing.Size(178, 20);
            this.txtClienteTInactiva.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(22, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cliente:";
            // 
            // txtTarjetaTInactiva
            // 
            this.txtTarjetaTInactiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarjetaTInactiva.Location = new System.Drawing.Point(137, 88);
            this.txtTarjetaTInactiva.MaxLength = 50;
            this.txtTarjetaTInactiva.Name = "txtTarjetaTInactiva";
            this.txtTarjetaTInactiva.Size = new System.Drawing.Size(178, 20);
            this.txtTarjetaTInactiva.TabIndex = 13;
            this.txtTarjetaTInactiva.Leave += new System.EventHandler(this.txtTarjetaTInactiva_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(22, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Número Tarjeta:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tarjeta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctBuscarClientesTarjetasInactivas
            // 
            this.pctBuscarClientesTarjetasInactivas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.pctBuscarClientesTarjetasInactivas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctBuscarClientesTarjetasInactivas.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.pctBuscarClientesTarjetasInactivas.InitialImage = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.pctBuscarClientesTarjetasInactivas.Location = new System.Drawing.Point(324, 53);
            this.pctBuscarClientesTarjetasInactivas.Name = "pctBuscarClientesTarjetasInactivas";
            this.pctBuscarClientesTarjetasInactivas.Size = new System.Drawing.Size(34, 34);
            this.pctBuscarClientesTarjetasInactivas.TabIndex = 16;
            this.pctBuscarClientesTarjetasInactivas.TabStop = false;
            this.pctBuscarClientesTarjetasInactivas.Click += new System.EventHandler(this.pctBuscarClientesTarjetasInactivas_Click);
            // 
            // tabAsociarVehiculo
            // 
            this.tabAsociarVehiculo.BackColor = System.Drawing.Color.White;
            this.tabAsociarVehiculo.Controls.Add(this.btnAsociar);
            this.tabAsociarVehiculo.Controls.Add(this.btnVehiculos);
            this.tabAsociarVehiculo.Controls.Add(this.btnTarjetas);
            this.tabAsociarVehiculo.Controls.Add(this.txtPlacaVehiculo);
            this.tabAsociarVehiculo.Controls.Add(this.label5);
            this.tabAsociarVehiculo.Controls.Add(this.txtNumTarjeta);
            this.tabAsociarVehiculo.Controls.Add(this.label4);
            this.tabAsociarVehiculo.Location = new System.Drawing.Point(4, 22);
            this.tabAsociarVehiculo.Name = "tabAsociarVehiculo";
            this.tabAsociarVehiculo.Padding = new System.Windows.Forms.Padding(3);
            this.tabAsociarVehiculo.Size = new System.Drawing.Size(418, 271);
            this.tabAsociarVehiculo.TabIndex = 2;
            this.tabAsociarVehiculo.Text = "Asociar Vehiculo";
            // 
            // btnAsociar
            // 
            this.btnAsociar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAsociar.Font = new System.Drawing.Font("Nina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsociar.ForeColor = System.Drawing.Color.White;
            this.btnAsociar.Location = new System.Drawing.Point(208, 115);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(89, 29);
            this.btnAsociar.TabIndex = 21;
            this.btnAsociar.Text = "Asociar";
            this.btnAsociar.UseVisualStyleBackColor = false;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // btnVehiculos
            // 
            this.btnVehiculos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnVehiculos.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehiculos.ForeColor = System.Drawing.Color.White;
            this.btnVehiculos.Location = new System.Drawing.Point(298, 76);
            this.btnVehiculos.Name = "btnVehiculos";
            this.btnVehiculos.Size = new System.Drawing.Size(47, 23);
            this.btnVehiculos.TabIndex = 20;
            this.btnVehiculos.Text = ". . .";
            this.btnVehiculos.UseVisualStyleBackColor = false;
            this.btnVehiculos.Click += new System.EventHandler(this.btnVehiculos_Click);
            // 
            // btnTarjetas
            // 
            this.btnTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTarjetas.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarjetas.ForeColor = System.Drawing.Color.White;
            this.btnTarjetas.Location = new System.Drawing.Point(298, 44);
            this.btnTarjetas.Name = "btnTarjetas";
            this.btnTarjetas.Size = new System.Drawing.Size(47, 23);
            this.btnTarjetas.TabIndex = 19;
            this.btnTarjetas.Text = ". . .";
            this.btnTarjetas.UseVisualStyleBackColor = false;
            this.btnTarjetas.Click += new System.EventHandler(this.btnTarjetas_Click);
            // 
            // txtPlacaVehiculo
            // 
            this.txtPlacaVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlacaVehiculo.Location = new System.Drawing.Point(119, 78);
            this.txtPlacaVehiculo.MaxLength = 50;
            this.txtPlacaVehiculo.Name = "txtPlacaVehiculo";
            this.txtPlacaVehiculo.Size = new System.Drawing.Size(178, 20);
            this.txtPlacaVehiculo.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.Location = new System.Drawing.Point(15, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Vehiculo:";
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumTarjeta.Location = new System.Drawing.Point(119, 46);
            this.txtNumTarjeta.MaxLength = 50;
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.Size = new System.Drawing.Size(178, 20);
            this.txtNumTarjeta.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(15, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Número Tarjeta:";
            // 
            // tabRecarga
            // 
            this.tabRecarga.BackColor = System.Drawing.Color.White;
            this.tabRecarga.Controls.Add(this.btnBuscarTarjetas);
            this.tabRecarga.Controls.Add(this.btnRecargar);
            this.tabRecarga.Controls.Add(this.label7);
            this.tabRecarga.Controls.Add(this.tbTarjeta);
            this.tabRecarga.Controls.Add(this.label6);
            this.tabRecarga.Controls.Add(this.tbRecarga);
            this.tabRecarga.Location = new System.Drawing.Point(4, 22);
            this.tabRecarga.Name = "tabRecarga";
            this.tabRecarga.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecarga.Size = new System.Drawing.Size(418, 271);
            this.tabRecarga.TabIndex = 3;
            this.tabRecarga.Text = "Recargar Tarjeta";
            // 
            // btnBuscarTarjetas
            // 
            this.btnBuscarTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBuscarTarjetas.Font = new System.Drawing.Font("Cooper Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTarjetas.ForeColor = System.Drawing.Color.White;
            this.btnBuscarTarjetas.Location = new System.Drawing.Point(319, 49);
            this.btnBuscarTarjetas.Name = "btnBuscarTarjetas";
            this.btnBuscarTarjetas.Size = new System.Drawing.Size(47, 23);
            this.btnBuscarTarjetas.TabIndex = 107;
            this.btnBuscarTarjetas.Text = ". . .";
            this.btnBuscarTarjetas.UseVisualStyleBackColor = false;
            this.btnBuscarTarjetas.Click += new System.EventHandler(this.btnBuscarTarjetas_Click);
            // 
            // btnRecargar
            // 
            this.btnRecargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnRecargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecargar.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecargar.ForeColor = System.Drawing.Color.White;
            this.btnRecargar.Location = new System.Drawing.Point(135, 140);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(108, 24);
            this.btnRecargar.TabIndex = 106;
            this.btnRecargar.Text = "Recargar Tarjeta";
            this.btnRecargar.UseVisualStyleBackColor = false;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(23, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 104;
            this.label7.Text = "Valor Recarga:";
            // 
            // tbTarjeta
            // 
            this.tbTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTarjeta.Location = new System.Drawing.Point(135, 51);
            this.tbTarjeta.MaxLength = 50;
            this.tbTarjeta.Name = "tbTarjeta";
            this.tbTarjeta.Size = new System.Drawing.Size(178, 20);
            this.tbTarjeta.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label6.Location = new System.Drawing.Point(23, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Número Tarjeta:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label24.Location = new System.Drawing.Point(160, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 27);
            this.label24.TabIndex = 57;
            this.label24.Text = "TARJETAS";
            // 
            // txtcupo
            // 
            this.txtcupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcupo.DecimalPlaces = 0;
            this.txtcupo.DecimalsSeparator = ',';
            this.txtcupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcupo.Location = new System.Drawing.Point(132, 106);
            this.txtcupo.Name = "txtcupo";
            this.txtcupo.PreFix = "$";
            this.txtcupo.Size = new System.Drawing.Size(178, 24);
            this.txtcupo.TabIndex = 103;
            this.txtcupo.ThousandsSeparator = '.';
            this.txtcupo.TextChanged += new System.EventHandler(this.txtcupo_TextChanged_1);
            // 
            // tbRecarga
            // 
            this.tbRecarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRecarga.DecimalPlaces = 0;
            this.tbRecarga.DecimalsSeparator = ',';
            this.tbRecarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRecarga.Location = new System.Drawing.Point(135, 95);
            this.tbRecarga.Name = "tbRecarga";
            this.tbRecarga.PreFix = "$";
            this.tbRecarga.Size = new System.Drawing.Size(178, 24);
            this.tbRecarga.TabIndex = 105;
            this.tbRecarga.ThousandsSeparator = '.';
            // 
            // gsTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tabControl1);
            this.Name = "gsTarjeta";
            this.Size = new System.Drawing.Size(645, 389);
            this.Load += new System.EventHandler(this.gsTarjeta_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlTarjeta.ResumeLayout(false);
            this.pnlTarjeta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBuscar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBuscarClientesTarjetasInactivas)).EndInit();
            this.tabAsociarVehiculo.ResumeLayout(false);
            this.tabAsociarVehiculo.PerformLayout();
            this.tabRecarga.ResumeLayout(false);
            this.tabRecarga.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlTarjeta;
        private System.Windows.Forms.CheckBox chkTarjetaActiva;
        private System.Windows.Forms.PictureBox pctBuscar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPieCupo;
        private System.Windows.Forms.Label lblPieTarjeta;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtTarjeta;
        private JRINCCustomControls.currencyTextBox txtcupo;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblNrotarjeta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolTip toolTipCrear;
        private System.Windows.Forms.CheckBox chkTarjetaActivaTI;
        private System.Windows.Forms.PictureBox pctBuscarClientesTarjetasInactivas;
        private System.Windows.Forms.TextBox txtClienteTInactiva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTarjetaTInactiva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInactivar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage tabAsociarVehiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.TextBox txtPlacaVehiculo;
        private System.Windows.Forms.Button btnTarjetas;
        private System.Windows.Forms.Button btnVehiculos;
        private System.Windows.Forms.Button btnAsociar;
        private System.Windows.Forms.TabPage tabRecarga;
        private System.Windows.Forms.Button btnRecargar;
        private JRINCCustomControls.currencyTextBox tbRecarga;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTarjeta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBuscarTarjetas;
    }
}
