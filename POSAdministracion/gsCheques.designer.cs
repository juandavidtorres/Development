namespace PayOffice
{
    partial class gsCheques
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCheques = new System.Windows.Forms.Panel();
            this.btnAsignarPorcentaje = new System.Windows.Forms.Button();
            this.lblNumeroAutorizacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.lblMinimo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvVehiculos = new System.Windows.Forms.DataGridView();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFaltante = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPlaca = new System.Windows.Forms.ComboBox();
            this.lblMaximo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValorTanqueo = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.txtValorSuministro = new System.Windows.Forms.TextBox();
            this.lblValorSuministro = new System.Windows.Forms.Label();
            this.txtValorCheque = new System.Windows.Forms.TextBox();
            this.lblValorCheque = new System.Windows.Forms.Label();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.lblAutorizacion = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.lblCheque = new System.Windows.Forms.Label();
            this.cmbEntidad = new System.Windows.Forms.ComboBox();
            this.lblEntidad = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.rbIdentificado = new System.Windows.Forms.RadioButton();
            this.rbPaso = new System.Windows.Forms.RadioButton();
            this.Popup = new PopupNotifier();
            this.toolTipcheque = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCheques.SuspendLayout();
            this.gbCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.gbGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCheques
            // 
            this.pnlCheques.BackColor = System.Drawing.Color.White;
            this.pnlCheques.Controls.Add(this.btnAsignarPorcentaje);
            this.pnlCheques.Controls.Add(this.lblNumeroAutorizacion);
            this.pnlCheques.Controls.Add(this.label1);
            this.pnlCheques.Controls.Add(this.btnLimpiar);
            this.pnlCheques.Controls.Add(this.btnCerrar);
            this.pnlCheques.Controls.Add(this.btnGuardar);
            this.pnlCheques.Controls.Add(this.gbCliente);
            this.pnlCheques.Controls.Add(this.gbGeneral);
            this.pnlCheques.Controls.Add(this.rbIdentificado);
            this.pnlCheques.Controls.Add(this.rbPaso);
            this.pnlCheques.Location = new System.Drawing.Point(2, 10);
            this.pnlCheques.Name = "pnlCheques";
            this.pnlCheques.Size = new System.Drawing.Size(734, 403);
            this.pnlCheques.TabIndex = 0;
            // 
            // btnAsignarPorcentaje
            // 
            this.btnAsignarPorcentaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnAsignarPorcentaje.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Cheque;
            this.btnAsignarPorcentaje.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAsignarPorcentaje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignarPorcentaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarPorcentaje.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAsignarPorcentaje.Location = new System.Drawing.Point(657, 8);
            this.btnAsignarPorcentaje.Name = "btnAsignarPorcentaje";
            this.btnAsignarPorcentaje.Size = new System.Drawing.Size(34, 34);
            this.btnAsignarPorcentaje.TabIndex = 18;
            this.toolTipcheque.SetToolTip(this.btnAsignarPorcentaje, "Asignar porcentaje a cliente");
            this.btnAsignarPorcentaje.UseVisualStyleBackColor = false;
            this.btnAsignarPorcentaje.Click += new System.EventHandler(this.btnAsignarPorcentaje_Click);
            // 
            // lblNumeroAutorizacion
            // 
            this.lblNumeroAutorizacion.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroAutorizacion.ForeColor = System.Drawing.Color.Red;
            this.lblNumeroAutorizacion.Location = new System.Drawing.Point(315, 371);
            this.lblNumeroAutorizacion.Name = "lblNumeroAutorizacion";
            this.lblNumeroAutorizacion.Size = new System.Drawing.Size(313, 23);
            this.lblNumeroAutorizacion.TabIndex = 17;
            this.lblNumeroAutorizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(25, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "CODIGO DE AUTORIZACIÓN:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnLimpiar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.Location = new System.Drawing.Point(622, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(34, 34);
            this.btnLimpiar.TabIndex = 15;
            this.toolTipcheque.SetToolTip(this.btnLimpiar, "Actualizar");
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCerrar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCerrar.Location = new System.Drawing.Point(692, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(34, 34);
            this.btnCerrar.TabIndex = 14;
            this.toolTipcheque.SetToolTip(this.btnCerrar, "Cerrar");
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnGuardar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardar.Location = new System.Drawing.Point(587, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(34, 34);
            this.btnGuardar.TabIndex = 11;
            this.toolTipcheque.SetToolTip(this.btnGuardar, "Guardar");
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.lblMinimo);
            this.gbCliente.Controls.Add(this.label5);
            this.gbCliente.Controls.Add(this.lblCambio);
            this.gbCliente.Controls.Add(this.btnAdicionar);
            this.gbCliente.Controls.Add(this.label3);
            this.gbCliente.Controls.Add(this.dgvVehiculos);
            this.gbCliente.Controls.Add(this.lblFaltante);
            this.gbCliente.Controls.Add(this.lblPorcentaje);
            this.gbCliente.Controls.Add(this.label2);
            this.gbCliente.Controls.Add(this.label9);
            this.gbCliente.Controls.Add(this.cmbPlaca);
            this.gbCliente.Controls.Add(this.lblMaximo);
            this.gbCliente.Controls.Add(this.lblPlaca);
            this.gbCliente.Controls.Add(this.label7);
            this.gbCliente.Controls.Add(this.txtValorTanqueo);
            this.gbCliente.Controls.Add(this.lblValor);
            this.gbCliente.Controls.Add(this.cmbCliente);
            this.gbCliente.Controls.Add(this.lblCliente);
            this.gbCliente.Location = new System.Drawing.Point(16, 150);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Size = new System.Drawing.Size(710, 212);
            this.gbCliente.TabIndex = 4;
            this.gbCliente.TabStop = false;
            // 
            // lblMinimo
            // 
            this.lblMinimo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimo.ForeColor = System.Drawing.Color.Red;
            this.lblMinimo.Location = new System.Drawing.Point(569, 117);
            this.lblMinimo.Name = "lblMinimo";
            this.lblMinimo.Size = new System.Drawing.Size(85, 21);
            this.lblMinimo.TabIndex = 34;
            this.lblMinimo.Text = "$ 0,00";
            this.lblMinimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.Location = new System.Drawing.Point(359, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Valor Mínimo de Consumo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCambio
            // 
            this.lblCambio.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.ForeColor = System.Drawing.Color.Red;
            this.lblCambio.Location = new System.Drawing.Point(568, 159);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(85, 21);
            this.lblCambio.TabIndex = 30;
            this.lblCambio.Text = "$ 0,00";
            this.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Check;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(647, 14);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(28, 28);
            this.btnAdicionar.TabIndex = 10;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(358, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Valor de cambio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvVehiculos
            // 
            this.dgvVehiculos.AllowUserToAddRows = false;
            this.dgvVehiculos.AllowUserToOrderColumns = true;
            this.dgvVehiculos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Placa,
            this.Valor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiculos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVehiculos.Location = new System.Drawing.Point(12, 89);
            this.dgvVehiculos.MultiSelect = false;
            this.dgvVehiculos.Name = "dgvVehiculos";
            this.dgvVehiculos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiculos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVehiculos.Size = new System.Drawing.Size(316, 109);
            this.dgvVehiculos.TabIndex = 28;
            this.dgvVehiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVehiculos_CellClick);
            this.dgvVehiculos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVehiculos_DataError);
            this.dgvVehiculos.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvVehiculos_UserDeletedRow);
            // 
            // Placa
            // 
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // lblFaltante
            // 
            this.lblFaltante.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaltante.ForeColor = System.Drawing.Color.Red;
            this.lblFaltante.Location = new System.Drawing.Point(568, 180);
            this.lblFaltante.Name = "lblFaltante";
            this.lblFaltante.Size = new System.Drawing.Size(85, 21);
            this.lblFaltante.TabIndex = 32;
            this.lblFaltante.Text = "$ 0,00";
            this.lblFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.ForeColor = System.Drawing.Color.Red;
            this.lblPorcentaje.Location = new System.Drawing.Point(568, 138);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(85, 21);
            this.lblPorcentaje.TabIndex = 27;
            this.lblPorcentaje.Text = "50%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(358, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 31;
            this.label2.Text = "Falta por Consumir:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label9.Location = new System.Drawing.Point(358, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 21);
            this.label9.TabIndex = 26;
            this.label9.Text = "Porcentaje Mínimo de Consumo:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPlaca
            // 
            this.cmbPlaca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPlaca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPlaca.FormattingEnabled = true;
            this.cmbPlaca.Location = new System.Drawing.Point(74, 51);
            this.cmbPlaca.Name = "cmbPlaca";
            this.cmbPlaca.Size = new System.Drawing.Size(221, 21);
            this.cmbPlaca.TabIndex = 8;
            // 
            // lblMaximo
            // 
            this.lblMaximo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximo.ForeColor = System.Drawing.Color.Red;
            this.lblMaximo.Location = new System.Drawing.Point(568, 96);
            this.lblMaximo.Name = "lblMaximo";
            this.lblMaximo.Size = new System.Drawing.Size(85, 21);
            this.lblMaximo.TabIndex = 25;
            this.lblMaximo.Text = "$ 0,00";
            this.lblMaximo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlaca
            // 
            this.lblPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPlaca.Location = new System.Drawing.Point(9, 50);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(97, 21);
            this.lblPlaca.TabIndex = 21;
            this.lblPlaca.Text = "Placa";
            this.lblPlaca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(358, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "Máximo Permitido:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValorTanqueo
            // 
            this.txtValorTanqueo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorTanqueo.Location = new System.Drawing.Point(404, 50);
            this.txtValorTanqueo.MaxLength = 13;
            this.txtValorTanqueo.Name = "txtValorTanqueo";
            this.txtValorTanqueo.Size = new System.Drawing.Size(232, 20);
            this.txtValorTanqueo.TabIndex = 9;
            this.txtValorTanqueo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorTanqueo_KeyPress);
            // 
            // lblValor
            // 
            this.lblValor.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblValor.Location = new System.Drawing.Point(305, 50);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(97, 21);
            this.lblValor.TabIndex = 22;
            this.lblValor.Text = "Valor Tanqueo";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(74, 18);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(562, 21);
            this.cmbCliente.TabIndex = 7;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            this.cmbCliente.Click += new System.EventHandler(this.cmbCliente_Click);
            this.cmbCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCliente_KeyPress);
            this.cmbCliente.Leave += new System.EventHandler(this.cmbCliente_Leave);
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCliente.Location = new System.Drawing.Point(9, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(97, 21);
            this.lblCliente.TabIndex = 20;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.txtValorSuministro);
            this.gbGeneral.Controls.Add(this.lblValorSuministro);
            this.gbGeneral.Controls.Add(this.txtValorCheque);
            this.gbGeneral.Controls.Add(this.lblValorCheque);
            this.gbGeneral.Controls.Add(this.txtAutorizacion);
            this.gbGeneral.Controls.Add(this.lblAutorizacion);
            this.gbGeneral.Controls.Add(this.txtCheque);
            this.gbGeneral.Controls.Add(this.lblCheque);
            this.gbGeneral.Controls.Add(this.cmbEntidad);
            this.gbGeneral.Controls.Add(this.lblEntidad);
            this.gbGeneral.Controls.Add(this.cmbBanco);
            this.gbGeneral.Controls.Add(this.lblBanco);
            this.gbGeneral.Location = new System.Drawing.Point(16, 44);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(710, 100);
            this.gbGeneral.TabIndex = 3;
            this.gbGeneral.TabStop = false;
            // 
            // txtValorSuministro
            // 
            this.txtValorSuministro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorSuministro.Location = new System.Drawing.Point(504, 70);
            this.txtValorSuministro.MaxLength = 13;
            this.txtValorSuministro.Name = "txtValorSuministro";
            this.txtValorSuministro.Size = new System.Drawing.Size(190, 20);
            this.txtValorSuministro.TabIndex = 6;
            this.txtValorSuministro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorSuministro_KeyPress);
            this.txtValorSuministro.Leave += new System.EventHandler(this.txtValorSuministro_Leave);
            // 
            // lblValorSuministro
            // 
            this.lblValorSuministro.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSuministro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblValorSuministro.Location = new System.Drawing.Point(401, 70);
            this.lblValorSuministro.Name = "lblValorSuministro";
            this.lblValorSuministro.Size = new System.Drawing.Size(103, 21);
            this.lblValorSuministro.TabIndex = 17;
            this.lblValorSuministro.Text = "Valor Consumo";
            this.lblValorSuministro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValorCheque
            // 
            this.txtValorCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorCheque.Location = new System.Drawing.Point(122, 72);
            this.txtValorCheque.MaxLength = 13;
            this.txtValorCheque.Name = "txtValorCheque";
            this.txtValorCheque.Size = new System.Drawing.Size(239, 20);
            this.txtValorCheque.TabIndex = 5;
            this.txtValorCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorCheque_KeyPress);
            this.txtValorCheque.Leave += new System.EventHandler(this.txtValorCheque_Leave);
            // 
            // lblValorCheque
            // 
            this.lblValorCheque.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblValorCheque.Location = new System.Drawing.Point(9, 72);
            this.lblValorCheque.Name = "lblValorCheque";
            this.lblValorCheque.Size = new System.Drawing.Size(103, 21);
            this.lblValorCheque.TabIndex = 16;
            this.lblValorCheque.Text = "Valor Cheque";
            this.lblValorCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutorizacion.Enabled = false;
            this.txtAutorizacion.Location = new System.Drawing.Point(504, 43);
            this.txtAutorizacion.MaxLength = 50;
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.Size = new System.Drawing.Size(190, 20);
            this.txtAutorizacion.TabIndex = 4;
            this.txtAutorizacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutorizacion_KeyPress);
            // 
            // lblAutorizacion
            // 
            this.lblAutorizacion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutorizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblAutorizacion.Location = new System.Drawing.Point(401, 43);
            this.lblAutorizacion.Name = "lblAutorizacion";
            this.lblAutorizacion.Size = new System.Drawing.Size(103, 21);
            this.lblAutorizacion.TabIndex = 19;
            this.lblAutorizacion.Text = "Nº Aut. Entidad";
            this.lblAutorizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCheque
            // 
            this.txtCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCheque.Location = new System.Drawing.Point(122, 45);
            this.txtCheque.MaxLength = 50;
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(239, 20);
            this.txtCheque.TabIndex = 3;
            this.txtCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheque_KeyPress);
            // 
            // lblCheque
            // 
            this.lblCheque.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCheque.Location = new System.Drawing.Point(9, 45);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(103, 21);
            this.lblCheque.TabIndex = 15;
            this.lblCheque.Text = "Número Cheque";
            this.lblCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEntidad
            // 
            this.cmbEntidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEntidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntidad.Enabled = false;
            this.cmbEntidad.FormattingEnabled = true;
            this.cmbEntidad.Location = new System.Drawing.Point(504, 16);
            this.cmbEntidad.MaxLength = 100;
            this.cmbEntidad.Name = "cmbEntidad";
            this.cmbEntidad.Size = new System.Drawing.Size(190, 21);
            this.cmbEntidad.TabIndex = 3;
            // 
            // lblEntidad
            // 
            this.lblEntidad.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblEntidad.Location = new System.Drawing.Point(401, 16);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(97, 21);
            this.lblEntidad.TabIndex = 18;
            this.lblEntidad.Text = "Entidad Aval";
            this.lblEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBanco
            // 
            this.cmbBanco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBanco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(122, 19);
            this.cmbBanco.MaxLength = 20;
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(239, 21);
            this.cmbBanco.TabIndex = 2;
            this.cmbBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBanco_KeyPress);
            // 
            // lblBanco
            // 
            this.lblBanco.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblBanco.Location = new System.Drawing.Point(9, 16);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(97, 21);
            this.lblBanco.TabIndex = 12;
            this.lblBanco.Text = "Banco Emisor";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbIdentificado
            // 
            this.rbIdentificado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.rbIdentificado.Checked = true;
            this.rbIdentificado.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbIdentificado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbIdentificado.Location = new System.Drawing.Point(182, 14);
            this.rbIdentificado.Name = "rbIdentificado";
            this.rbIdentificado.Size = new System.Drawing.Size(153, 24);
            this.rbIdentificado.TabIndex = 1;
            this.rbIdentificado.TabStop = true;
            this.rbIdentificado.Text = "Cliente Identificado";
            this.rbIdentificado.UseVisualStyleBackColor = false;
            // 
            // rbPaso
            // 
            this.rbPaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.rbPaso.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPaso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbPaso.Location = new System.Drawing.Point(28, 14);
            this.rbPaso.Name = "rbPaso";
            this.rbPaso.Size = new System.Drawing.Size(134, 24);
            this.rbPaso.TabIndex = 0;
            this.rbPaso.Text = "Cliente de Paso";
            this.rbPaso.UseVisualStyleBackColor = false;
            this.rbPaso.CheckedChanged += new System.EventHandler(this.rbPaso_CheckedChanged);
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
            this.groupBox1.Controls.Add(this.pnlCheques);
            this.groupBox1.Location = new System.Drawing.Point(19, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 419);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(344, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 27);
            this.label4.TabIndex = 51;
            this.label4.Text = "CHEQUES";
            // 
            // gsCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "gsCheques";
            this.Size = new System.Drawing.Size(781, 476);
            this.Load += new System.EventHandler(this.gsCheques_Load);
            this.pnlCheques.ResumeLayout(false);
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCheques;
        private System.Windows.Forms.RadioButton rbPaso;
        private System.Windows.Forms.RadioButton rbIdentificado;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.ComboBox cmbEntidad;
        private System.Windows.Forms.Label lblEntidad;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label lblCheque;
        private System.Windows.Forms.TextBox txtAutorizacion;
        private System.Windows.Forms.Label lblAutorizacion;
        private System.Windows.Forms.TextBox txtValorSuministro;
        private System.Windows.Forms.Label lblValorSuministro;
        private System.Windows.Forms.TextBox txtValorCheque;
        private System.Windows.Forms.Label lblValorCheque;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.TextBox txtValorTanqueo;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbPlaca;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.DataGridView dgvVehiculos;
        private System.Windows.Forms.Label lblFaltante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMaximo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblNumeroAutorizacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMinimo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAsignarPorcentaje;
        private System.Windows.Forms.ToolTip toolTipcheque;
        private PopupNotifier Popup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;

    }
}
