namespace gasolutions.UInterface
{
    partial class gsKilometraje
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.grdVentas = new System.Windows.Forms.DataGridView();
            this.Recibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilometraje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRecibo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVentas)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(600, 12);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(39, 39);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuSalir
            // 
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(36, 36);
            this.mnuSalir.Text = "toolStripButton1";
            this.mnuSalir.ToolTipText = "Salir de la Opción";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // grdVentas
            // 
            this.grdVentas.AllowUserToAddRows = false;
            this.grdVentas.AllowUserToDeleteRows = false;
            this.grdVentas.BackgroundColor = System.Drawing.Color.White;
            this.grdVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Recibo,
            this.Fecha,
            this.Placa,
            this.Valor,
            this.Kilometraje});
            this.grdVentas.Location = new System.Drawing.Point(19, 169);
            this.grdVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdVentas.Name = "grdVentas";
            this.grdVentas.RowHeadersVisible = false;
            this.grdVentas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVentas.Size = new System.Drawing.Size(581, 277);
            this.grdVentas.TabIndex = 5;
            this.grdVentas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdVentas_CellValidating);
            this.grdVentas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVentas_CellValueChanged);
            // 
            // Recibo
            // 
            this.Recibo.DataPropertyName = "Recibo";
            this.Recibo.HeaderText = "Recibo";
            this.Recibo.Name = "Recibo";
            this.Recibo.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "FechaHora";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 80;
            // 
            // Placa
            // 
            this.Placa.DataPropertyName = "Placa";
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            this.Placa.Width = 200;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 65;
            // 
            // Kilometraje
            // 
            this.Kilometraje.DataPropertyName = "Kilometraje";
            this.Kilometraje.HeaderText = "Kilometraje";
            this.Kilometraje.Name = "Kilometraje";
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.White;
            this.pnlDetalle.Controls.Add(this.btnBuscar);
            this.pnlDetalle.Controls.Add(this.dtFecha);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.txtRecibo);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.lblNumeroFactura);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Location = new System.Drawing.Point(8, 17);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(571, 105);
            this.pnlDetalle.TabIndex = 89;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnBuscar.Location = new System.Drawing.Point(254, 63);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(64, 70);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(176, 20);
            this.dtFecha.TabIndex = 3;
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(330, 30);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(222, 21);
            this.txtPlaca.TabIndex = 2;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(271, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 93;
            this.label6.Text = "Placa";
            // 
            // txtRecibo
            // 
            this.txtRecibo.BackColor = System.Drawing.Color.White;
            this.txtRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecibo.Location = new System.Drawing.Point(64, 30);
            this.txtRecibo.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtRecibo.Name = "txtRecibo";
            this.txtRecibo.Size = new System.Drawing.Size(176, 21);
            this.txtRecibo.TabIndex = 1;
            this.txtRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 91;
            this.label1.Text = "Recibo";
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroFactura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblNumeroFactura.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumeroFactura.Location = new System.Drawing.Point(9, 70);
            this.lblNumeroFactura.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(41, 16);
            this.lblNumeroFactura.TabIndex = 86;
            this.lblNumeroFactura.Text = "Fecha";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(557, 22);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlDetalle);
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(584, 138);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.grdVentas);
            this.groupBox2.Location = new System.Drawing.Point(17, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 465);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(258, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 27);
            this.label7.TabIndex = 92;
            this.label7.Text = "KILOMETRAJE";
            // 
            // gsKilometraje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsKilometraje";
            this.Size = new System.Drawing.Size(656, 583);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVentas)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.DataGridView grdVentas;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRecibo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilometraje;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
    }
}
