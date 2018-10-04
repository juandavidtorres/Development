namespace gasolutions.UInterface
{
    partial class gsRenovarCredito
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnRenovar = new System.Windows.Forms.Button();
            this.dtgCreditosRenovar = new System.Windows.Forms.DataGridView();
            this.IdCreditoConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUltima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaProxima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosRenovar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(167, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 27);
            this.label7.TabIndex = 56;
            this.label7.Text = "RENOVAR CUPO DE VEHÍCULOS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(9, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 474);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.btnNuevo.Location = new System.Drawing.Point(515, 10);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(40, 40);
            this.btnNuevo.TabIndex = 30;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnSalir.Location = new System.Drawing.Point(561, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(40, 40);
            this.btnSalir.TabIndex = 29;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnRenovar);
            this.groupBox3.Controls.Add(this.dtgCreditosRenovar);
            this.groupBox3.Location = new System.Drawing.Point(12, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 344);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // BtnRenovar
            // 
            this.BtnRenovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.BtnRenovar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnRenovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRenovar.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRenovar.ForeColor = System.Drawing.Color.White;
            this.BtnRenovar.Location = new System.Drawing.Point(508, 304);
            this.BtnRenovar.Name = "BtnRenovar";
            this.BtnRenovar.Size = new System.Drawing.Size(81, 34);
            this.BtnRenovar.TabIndex = 28;
            this.BtnRenovar.Text = "Renovar";
            this.BtnRenovar.UseVisualStyleBackColor = false;
            this.BtnRenovar.Click += new System.EventHandler(this.BtnRenovar_Click);
            // 
            // dtgCreditosRenovar
            // 
            this.dtgCreditosRenovar.AllowUserToAddRows = false;
            this.dtgCreditosRenovar.AllowUserToDeleteRows = false;
            this.dtgCreditosRenovar.BackgroundColor = System.Drawing.Color.White;
            this.dtgCreditosRenovar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCreditosRenovar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgCreditosRenovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCreditosRenovar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCreditoConsumo,
            this.RazonSocial,
            this.Nit,
            this.TipoCredito,
            this.FechaUltima,
            this.FechaProxima,
            this.Seleccionar});
            this.dtgCreditosRenovar.Location = new System.Drawing.Point(6, 20);
            this.dtgCreditosRenovar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgCreditosRenovar.Name = "dtgCreditosRenovar";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgCreditosRenovar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCreditosRenovar.RowHeadersVisible = false;
            this.dtgCreditosRenovar.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.dtgCreditosRenovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgCreditosRenovar.Size = new System.Drawing.Size(583, 280);
            this.dtgCreditosRenovar.TabIndex = 19;
            // 
            // IdCreditoConsumo
            // 
            this.IdCreditoConsumo.DataPropertyName = "IdCreditoConsumo";
            this.IdCreditoConsumo.Frozen = true;
            this.IdCreditoConsumo.HeaderText = "Id";
            this.IdCreditoConsumo.Name = "IdCreditoConsumo";
            this.IdCreditoConsumo.ReadOnly = true;
            this.IdCreditoConsumo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdCreditoConsumo.Visible = false;
            this.IdCreditoConsumo.Width = 20;
            // 
            // RazonSocial
            // 
            this.RazonSocial.DataPropertyName = "RazonSocial";
            this.RazonSocial.HeaderText = "Razon Social";
            this.RazonSocial.Name = "RazonSocial";
            this.RazonSocial.ReadOnly = true;
            this.RazonSocial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RazonSocial.Width = 150;
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "Nit";
            this.Nit.HeaderText = "NIT";
            this.Nit.Name = "Nit";
            this.Nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nit.Width = 90;
            // 
            // TipoCredito
            // 
            this.TipoCredito.DataPropertyName = "TipoCredito";
            this.TipoCredito.HeaderText = "Tipo Credito";
            this.TipoCredito.Name = "TipoCredito";
            this.TipoCredito.ReadOnly = true;
            this.TipoCredito.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TipoCredito.Width = 110;
            // 
            // FechaUltima
            // 
            this.FechaUltima.DataPropertyName = "FechaUltima";
            this.FechaUltima.HeaderText = "Fecha Ult. Renovacion";
            this.FechaUltima.Name = "FechaUltima";
            this.FechaUltima.ReadOnly = true;
            this.FechaUltima.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaUltima.Width = 80;
            // 
            // FechaProxima
            // 
            this.FechaProxima.DataPropertyName = "FechaProxima";
            this.FechaProxima.HeaderText = "Fecha Prox. Renovacion";
            this.FechaProxima.Name = "FechaProxima";
            this.FechaProxima.Width = 80;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Width = 70;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlEncabezado);
            this.groupBox2.Location = new System.Drawing.Point(12, 51);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(595, 66);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.txtNombre);
            this.pnlEncabezado.Controls.Add(this.lblDocumento);
            this.pnlEncabezado.Controls.Add(this.txtCliente);
            this.pnlEncabezado.Location = new System.Drawing.Point(6, 15);
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(583, 40);
            this.pnlEncabezado.TabIndex = 13;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDocumento.Location = new System.Drawing.Point(5, 11);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(46, 16);
            this.lblDocumento.TabIndex = 50;
            this.lblDocumento.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(57, 9);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(118, 20);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 552);
            this.panel1.TabIndex = 58;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(181, 9);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(375, 20);
            this.txtNombre.TabIndex = 57;
            // 
            // gsRenovarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsRenovarCredito";
            this.Size = new System.Drawing.Size(633, 552);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditosRenovar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgCreditosRenovar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button BtnRenovar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCreditoConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaUltima;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaProxima;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.TextBox txtNombre;
    }
}
