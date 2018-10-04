namespace gasolutions.UInterface
{
    partial class InsertarLecturaVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlIngresoVenta = new System.Windows.Forms.Panel();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.lblrecibo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grdTurnos = new System.Windows.Forms.DataGridView();
            this.dgvIdBloqueo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvManguera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.txtValorFormaPago = new System.Windows.Forms.TextBox();
            this.lbEtiqueta = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnFalla = new System.Windows.Forms.Button();
            this.txtLecturaFinal = new System.Windows.Forms.TextBox();
            this.txtLecturaInicial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtManguera = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtturno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.tooltipBotones = new System.Windows.Forms.ToolTip(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.Impresora = new System.Windows.Forms.PrintDialog();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlIngresoVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox2);
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Location = new System.Drawing.Point(1, 37);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(548, 513);
            this.pnlPrincipal.TabIndex = 0;
            this.pnlPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrincipal_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlIngresoVenta);
            this.groupBox2.Location = new System.Drawing.Point(14, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 302);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // pnlIngresoVenta
            // 
            this.pnlIngresoVenta.Controls.Add(this.btnimprimir);
            this.pnlIngresoVenta.Controls.Add(this.lblrecibo);
            this.pnlIngresoVenta.Controls.Add(this.btnCerrar);
            this.pnlIngresoVenta.Controls.Add(this.btnFinalizar);
            this.pnlIngresoVenta.Controls.Add(this.btnlimpiar);
            this.pnlIngresoVenta.Controls.Add(this.btnAgregar);
            this.pnlIngresoVenta.Controls.Add(this.grdTurnos);
            this.pnlIngresoVenta.Controls.Add(this.label6);
            this.pnlIngresoVenta.Controls.Add(this.cmbFormaPago);
            this.pnlIngresoVenta.Controls.Add(this.txtValorFormaPago);
            this.pnlIngresoVenta.Controls.Add(this.lbEtiqueta);
            this.pnlIngresoVenta.Location = new System.Drawing.Point(7, 14);
            this.pnlIngresoVenta.Name = "pnlIngresoVenta";
            this.pnlIngresoVenta.Size = new System.Drawing.Size(512, 281);
            this.pnlIngresoVenta.TabIndex = 6;
            // 
            // btnimprimir
            // 
            this.btnimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnimprimir.Image = global::gasolutions.UInterface.Properties.Resources.Imprimir;
            this.btnimprimir.Location = new System.Drawing.Point(83, 240);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(34, 34);
            this.btnimprimir.TabIndex = 51;
            this.tooltipBotones.SetToolTip(this.btnimprimir, "Guardar Venta");
            this.btnimprimir.UseVisualStyleBackColor = false;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // lblrecibo
            // 
            this.lblrecibo.Font = new System.Drawing.Font("Trebuchet MS", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecibo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblrecibo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblrecibo.Location = new System.Drawing.Point(123, 243);
            this.lblrecibo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblrecibo.Name = "lblrecibo";
            this.lblrecibo.Size = new System.Drawing.Size(366, 25);
            this.lblrecibo.TabIndex = 50;
            this.lblrecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(43, 240);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(34, 34);
            this.btnCerrar.TabIndex = 47;
            this.tooltipBotones.SetToolTip(this.btnCerrar, "Salida");
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnFinalizar.Location = new System.Drawing.Point(6, 240);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(34, 34);
            this.btnFinalizar.TabIndex = 49;
            this.tooltipBotones.SetToolTip(this.btnFinalizar, "Guardar Venta");
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Image = global::gasolutions.UInterface.Properties.Resources.Limpiar__3_;
            this.btnlimpiar.Location = new System.Drawing.Point(126, 35);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(34, 34);
            this.btnlimpiar.TabIndex = 43;
            this.tooltipBotones.SetToolTip(this.btnlimpiar, "Limpiar Cuadricula");
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Image = global::gasolutions.UInterface.Properties.Resources.Mas;
            this.btnAgregar.Location = new System.Drawing.Point(84, 35);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(34, 34);
            this.btnAgregar.TabIndex = 42;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grdTurnos
            // 
            this.grdTurnos.AllowUserToAddRows = false;
            this.grdTurnos.AllowUserToDeleteRows = false;
            this.grdTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTurnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdTurnos.BackgroundColor = System.Drawing.Color.White;
            this.grdTurnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdTurnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIdBloqueo,
            this.dgvTurno,
            this.dgvManguera,
            this.dgvProducto,
            this.dgvFormaPago,
            this.dgvPrecio,
            this.dgvCantidad,
            this.dgvValor});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTurnos.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdTurnos.Location = new System.Drawing.Point(6, 76);
            this.grdTurnos.MultiSelect = false;
            this.grdTurnos.Name = "grdTurnos";
            this.grdTurnos.RowHeadersVisible = false;
            this.grdTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTurnos.Size = new System.Drawing.Size(500, 158);
            this.grdTurnos.TabIndex = 41;
            // 
            // dgvIdBloqueo
            // 
            this.dgvIdBloqueo.DataPropertyName = "IdBloqueo";
            this.dgvIdBloqueo.HeaderText = "IdBloqueo";
            this.dgvIdBloqueo.Name = "dgvIdBloqueo";
            this.dgvIdBloqueo.ReadOnly = true;
            this.dgvIdBloqueo.Visible = false;
            this.dgvIdBloqueo.Width = 61;
            // 
            // dgvTurno
            // 
            this.dgvTurno.DataPropertyName = "Turno";
            this.dgvTurno.HeaderText = "Turno";
            this.dgvTurno.Name = "dgvTurno";
            this.dgvTurno.ReadOnly = true;
            this.dgvTurno.Width = 60;
            // 
            // dgvManguera
            // 
            this.dgvManguera.DataPropertyName = "Manguera";
            this.dgvManguera.HeaderText = "Manguera";
            this.dgvManguera.Name = "dgvManguera";
            this.dgvManguera.ReadOnly = true;
            this.dgvManguera.Width = 80;
            // 
            // dgvProducto
            // 
            this.dgvProducto.DataPropertyName = "Producto";
            this.dgvProducto.HeaderText = "Producto";
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.ReadOnly = true;
            this.dgvProducto.Width = 75;
            // 
            // dgvFormaPago
            // 
            this.dgvFormaPago.DataPropertyName = "FormaPago";
            this.dgvFormaPago.HeaderText = "Forma Pago";
            this.dgvFormaPago.Name = "dgvFormaPago";
            this.dgvFormaPago.Width = 89;
            // 
            // dgvPrecio
            // 
            this.dgvPrecio.DataPropertyName = "Precio";
            this.dgvPrecio.HeaderText = "Precio";
            this.dgvPrecio.Name = "dgvPrecio";
            this.dgvPrecio.ReadOnly = true;
            this.dgvPrecio.Width = 62;
            // 
            // dgvCantidad
            // 
            this.dgvCantidad.DataPropertyName = "Cantidad";
            this.dgvCantidad.HeaderText = "Cantidad";
            this.dgvCantidad.Name = "dgvCantidad";
            this.dgvCantidad.ReadOnly = true;
            this.dgvCantidad.Width = 74;
            // 
            // dgvValor
            // 
            this.dgvValor.DataPropertyName = "Valor";
            this.dgvValor.HeaderText = "Valor";
            this.dgvValor.Name = "dgvValor";
            this.dgvValor.ReadOnly = true;
            this.dgvValor.Width = 56;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(332, 142);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(161, 20);
            this.txtPlaca.TabIndex = 38;
            this.txtPlaca.Visible = false;
            // 
            // lblPlaca
            // 
            this.lblPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPlaca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlaca.Location = new System.Drawing.Point(386, 144);
            this.lblPlaca.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(44, 18);
            this.lblPlaca.TabIndex = 37;
            this.lblPlaca.Text = "Placa";
            this.lblPlaca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPlaca.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(257, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "Forma de Pago";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(356, 9);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(149, 21);
            this.cmbFormaPago.TabIndex = 35;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            // 
            // txtValorFormaPago
            // 
            this.txtValorFormaPago.Location = new System.Drawing.Point(84, 9);
            this.txtValorFormaPago.Name = "txtValorFormaPago";
            this.txtValorFormaPago.Size = new System.Drawing.Size(161, 20);
            this.txtValorFormaPago.TabIndex = 34;
            // 
            // lbEtiqueta
            // 
            this.lbEtiqueta.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEtiqueta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lbEtiqueta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbEtiqueta.Location = new System.Drawing.Point(15, 10);
            this.lbEtiqueta.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lbEtiqueta.Name = "lbEtiqueta";
            this.lbEtiqueta.Size = new System.Drawing.Size(47, 18);
            this.lbEtiqueta.TabIndex = 28;
            this.lbEtiqueta.Text = "Valor";
            this.lbEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlDetalle);
            this.groupBox1.Location = new System.Drawing.Point(14, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 197);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.txtValorTotal);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.btnGuardar);
            this.pnlDetalle.Controls.Add(this.btnFalla);
            this.pnlDetalle.Controls.Add(this.txtLecturaFinal);
            this.pnlDetalle.Controls.Add(this.txtLecturaInicial);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.lblPlaca);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtPrecio);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.txtProducto);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.txtManguera);
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.txtCantidad);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtturno);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Location = new System.Drawing.Point(10, 14);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(505, 173);
            this.pnlDetalle.TabIndex = 5;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(332, 102);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(170, 20);
            this.txtValorTotal.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(252, 103);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Total Venta";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Image = global::gasolutions.UInterface.Properties.Resources.Venta;
            this.btnGuardar.Location = new System.Drawing.Point(208, 134);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(34, 34);
            this.btnGuardar.TabIndex = 44;
            this.tooltipBotones.SetToolTip(this.btnGuardar, "Generar Venta");
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGenerarVenta_Click);
            // 
            // btnFalla
            // 
            this.btnFalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnFalla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFalla.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFalla.Image = global::gasolutions.UInterface.Properties.Resources.error;
            this.btnFalla.Location = new System.Drawing.Point(255, 134);
            this.btnFalla.Name = "btnFalla";
            this.btnFalla.Size = new System.Drawing.Size(34, 34);
            this.btnFalla.TabIndex = 44;
            this.tooltipBotones.SetToolTip(this.btnFalla, "Falla Tecnica");
            this.btnFalla.UseVisualStyleBackColor = false;
            this.btnFalla.Click += new System.EventHandler(this.btnFalla_Click);
            // 
            // txtLecturaFinal
            // 
            this.txtLecturaFinal.Location = new System.Drawing.Point(81, 102);
            this.txtLecturaFinal.Name = "txtLecturaFinal";
            this.txtLecturaFinal.Size = new System.Drawing.Size(161, 20);
            this.txtLecturaFinal.TabIndex = 39;
            // 
            // txtLecturaInicial
            // 
            this.txtLecturaInicial.Location = new System.Drawing.Point(332, 78);
            this.txtLecturaInicial.Name = "txtLecturaInicial";
            this.txtLecturaInicial.Size = new System.Drawing.Size(170, 20);
            this.txtLecturaInicial.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(12, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "L.Final";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(254, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 38;
            this.label7.Text = "L.Inicial";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(332, 54);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(170, 20);
            this.txtPrecio.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(254, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 36;
            this.label4.Text = "Precio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(332, 30);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(170, 20);
            this.txtProducto.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(254, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Producto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtManguera
            // 
            this.txtManguera.Location = new System.Drawing.Point(81, 78);
            this.txtManguera.Name = "txtManguera";
            this.txtManguera.Size = new System.Drawing.Size(161, 20);
            this.txtManguera.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Manguera";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(81, 54);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(161, 20);
            this.txtCantidad.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Galones";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtturno
            // 
            this.txtturno.Location = new System.Drawing.Point(81, 30);
            this.txtturno.Name = "txtturno";
            this.txtturno.Size = new System.Drawing.Size(161, 20);
            this.txtturno.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "Turno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(68, 3);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(355, 16);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "INFORMACIÓN DE LECTURA";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // tooltipBotones
            // 
            this.tooltipBotones.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label11.Location = new System.Drawing.Point(121, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(301, 27);
            this.label11.TabIndex = 53;
            this.label11.Text = "INSERTAR LECTURA DE VENTA";
            // 
            // Impresora
            // 
            this.Impresora.UseEXDialog = true;
            // 
            // InsertarLecturaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pnlPrincipal);
            this.Name = "InsertarLecturaVenta";
            this.Size = new System.Drawing.Size(549, 608);
            this.pnlPrincipal.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnlIngresoVenta.ResumeLayout(false);
            this.pnlIngresoVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtturno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtManguera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlIngresoVenta;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.TextBox txtValorFormaPago;
        private System.Windows.Forms.Label lbEtiqueta;
        private System.Windows.Forms.DataGridView grdTurnos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ToolTip tooltipBotones;
        private System.Windows.Forms.TextBox txtLecturaFinal;
        private System.Windows.Forms.TextBox txtLecturaInicial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Button btnFalla;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIdBloqueo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvManguera;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvValor;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblrecibo;
        private System.Windows.Forms.Button btnimprimir;
        private System.Windows.Forms.PrintDialog Impresora;
    }
}
