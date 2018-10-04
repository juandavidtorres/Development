namespace gasolutions.UInterface
{
    partial class gsConsigTransportadora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuImprimir = new System.Windows.Forms.ToolStripButton();
            this.mnuCalcular = new System.Windows.Forms.ToolStripButton();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.cmbTransportadora = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvConsignar = new System.Windows.Forms.DataGridView();
            this.IdConsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoSobres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marcar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stsPrincipal = new System.Windows.Forms.StatusStrip();
            this.tssMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssValor = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNoConsignacion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tssValor1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignar)).BeginInit();
            this.stsPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevo,
            this.mnuGuardar,
            this.mnuImprimir,
            this.mnuCalcular,
            this.mnuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(13, 15);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(195, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(35, 37);
            this.mnuNuevo.Text = "toolStripButton1";
            this.mnuNuevo.ToolTipText = "Nuevo registro";
            this.mnuNuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
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
            this.mnuGuardar.ToolTipText = "Guardar registro de Consignación";
            this.mnuGuardar.Click += new System.EventHandler(this.mnuGuardar_Click);
            // 
            // mnuImprimir
            // 
            this.mnuImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuImprimir.Image = global::gasolutions.UInterface.Properties.Resources.Imprimir;
            this.mnuImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.mnuImprimir.Name = "mnuImprimir";
            this.mnuImprimir.Size = new System.Drawing.Size(35, 36);
            this.mnuImprimir.Text = "toolStripButton1";
            this.mnuImprimir.ToolTipText = "Imprimir Consignación";
            this.mnuImprimir.Click += new System.EventHandler(this.mnuImprimir_Click);
            // 
            // mnuCalcular
            // 
            this.mnuCalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCalcular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCalcular.Image = global::gasolutions.UInterface.Properties.Resources.Calculadora;
            this.mnuCalcular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCalcular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCalcular.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCalcular.Name = "mnuCalcular";
            this.mnuCalcular.Size = new System.Drawing.Size(35, 36);
            this.mnuCalcular.Text = "toolStripButton1";
            this.mnuCalcular.ToolTipText = "Calcular Valores";
            this.mnuCalcular.Click += new System.EventHandler(this.mnuCalcular_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Margin = new System.Windows.Forms.Padding(2);
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(36, 36);
            this.mnuSalir.Text = "toolStripButton1";
            this.mnuSalir.ToolTipText = "Salir de la Opción";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // cmbTransportadora
            // 
            this.cmbTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportadora.FormattingEnabled = true;
            this.cmbTransportadora.Location = new System.Drawing.Point(273, 23);
            this.cmbTransportadora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTransportadora.Name = "cmbTransportadora";
            this.cmbTransportadora.Size = new System.Drawing.Size(282, 24);
            this.cmbTransportadora.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(593, 25);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dgvConsignar
            // 
            this.dgvConsignar.AllowUserToAddRows = false;
            this.dgvConsignar.AllowUserToDeleteRows = false;
            this.dgvConsignar.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsignar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsignar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvConsignar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsignar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdConsignacion,
            this.Fecha,
            this.Empleado,
            this.NoSobres,
            this.IdTipo,
            this.Tipo,
            this.Valor,
            this.Marcar});
            this.dgvConsignar.Location = new System.Drawing.Point(10, 63);
            this.dgvConsignar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvConsignar.Name = "dgvConsignar";
            this.dgvConsignar.ReadOnly = true;
            this.dgvConsignar.RowHeadersVisible = false;
            this.dgvConsignar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvConsignar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsignar.Size = new System.Drawing.Size(689, 542);
            this.dgvConsignar.TabIndex = 8;
            this.dgvConsignar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvConsignar_CellMouseDoubleClick);
            // 
            // IdConsignacion
            // 
            this.IdConsignacion.DataPropertyName = "IdConsignacion";
            this.IdConsignacion.HeaderText = "IdConsignacion";
            this.IdConsignacion.Name = "IdConsignacion";
            this.IdConsignacion.ReadOnly = true;
            this.IdConsignacion.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 80;
            // 
            // Empleado
            // 
            this.Empleado.DataPropertyName = "Empleado";
            this.Empleado.HeaderText = "Empleado";
            this.Empleado.Name = "Empleado";
            this.Empleado.ReadOnly = true;
            this.Empleado.Width = 200;
            // 
            // NoSobres
            // 
            this.NoSobres.DataPropertyName = "NoSobres";
            this.NoSobres.HeaderText = "NoSobres";
            this.NoSobres.Name = "NoSobres";
            this.NoSobres.ReadOnly = true;
            this.NoSobres.Width = 65;
            // 
            // IdTipo
            // 
            this.IdTipo.DataPropertyName = "IdTipo";
            this.IdTipo.HeaderText = "IdTipo";
            this.IdTipo.Name = "IdTipo";
            this.IdTipo.ReadOnly = true;
            this.IdTipo.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 130;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Marcar
            // 
            this.Marcar.HeaderText = "Consignar";
            this.Marcar.Name = "Marcar";
            this.Marcar.ReadOnly = true;
            this.Marcar.Width = 75;
            // 
            // stsPrincipal
            // 
            this.stsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMensaje,
            this.tssValor});
            this.stsPrincipal.Location = new System.Drawing.Point(0, 713);
            this.stsPrincipal.Name = "stsPrincipal";
            this.stsPrincipal.Size = new System.Drawing.Size(760, 22);
            this.stsPrincipal.TabIndex = 9;
            this.stsPrincipal.Text = "statusStrip1";
            this.stsPrincipal.Visible = false;
            // 
            // tssMensaje
            // 
            this.tssMensaje.Name = "tssMensaje";
            this.tssMensaje.Size = new System.Drawing.Size(696, 17);
            this.tssMensaje.Spring = true;
            this.tssMensaje.Text = "Consignación No. :";
            // 
            // tssValor
            // 
            this.tssValor.Name = "tssValor";
            this.tssValor.Size = new System.Drawing.Size(49, 17);
            this.tssValor.Text = "0,000.00";
            // 
            // lblNoConsignacion
            // 
            this.lblNoConsignacion.AutoSize = true;
            this.lblNoConsignacion.Location = new System.Drawing.Point(222, 27);
            this.lblNoConsignacion.Name = "lblNoConsignacion";
            this.lblNoConsignacion.Size = new System.Drawing.Size(36, 16);
            this.lblNoConsignacion.TabIndex = 10;
            this.lblNoConsignacion.Text = "label1";
            this.lblNoConsignacion.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tssValor1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.lblNoConsignacion);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.cmbTransportadora);
            this.groupBox1.Controls.Add(this.dgvConsignar);
            this.groupBox1.Location = new System.Drawing.Point(21, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 654);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // tssValor1
            // 
            this.tssValor1.AutoSize = true;
            this.tssValor1.Location = new System.Drawing.Point(647, 609);
            this.tssValor1.Name = "tssValor1";
            this.tssValor1.Size = new System.Drawing.Size(52, 16);
            this.tssValor1.TabIndex = 12;
            this.tssValor1.Text = "0,000.00";
            this.tssValor1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Consignación Nro. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(202, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 27);
            this.label2.TabIndex = 53;
            this.label2.Text = "CONSIGNACIÓN TRANSPORTADORA";
            // 
            // gsConsigTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.stsPrincipal);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsConsigTransportadora";
            this.Size = new System.Drawing.Size(743, 549);
            this.Load += new System.EventHandler(this.gsConsigTransportadora_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsignar)).EndInit();
            this.stsPrincipal.ResumeLayout(false);
            this.stsPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuImprimir;
        private System.Windows.Forms.ToolStripButton mnuCalcular;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.ComboBox cmbTransportadora;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgvConsignar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoSobres;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Marcar;
        private System.Windows.Forms.StatusStrip stsPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel tssMensaje;
        private System.Windows.Forms.ToolStripStatusLabel tssValor;
        private System.Windows.Forms.Label lblNoConsignacion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tssValor1;
        private System.Windows.Forms.Label label1;
    }
}
