namespace PosConfiguracion
{
    partial class gsProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.dtgProductos = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Lectura = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoTerpel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Controls.Add(this.dtgProductos);
            this.pnlPrincipal.Location = new System.Drawing.Point(11, 18);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(473, 270);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(4, 221);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(41, 38);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSalir.AutoSize = false;
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.Image = global::PosConfiguracion.Properties.Resources.Guardar__2_;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Margin = new System.Windows.Forms.Padding(2);
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(34, 34);
            this.mnuSalir.ToolTipText = "Salir de la Opción";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // dtgProductos
            // 
            this.dtgProductos.BackgroundColor = System.Drawing.Color.White;
            this.dtgProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto,
            this.Producto,
            this.CodigoContable,
            this.Unidad,
            this.Lectura,
            this.CodigoTerpel});
            this.dtgProductos.Location = new System.Drawing.Point(3, 4);
            this.dtgProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgProductos.Name = "dtgProductos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgProductos.RowHeadersVisible = false;
            this.dtgProductos.Size = new System.Drawing.Size(452, 212);
            this.dtgProductos.TabIndex = 0;
            this.dtgProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgProductos_CellValueChanged);
            this.dtgProductos.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtgProductos_UserAddedRow);
            // 
            // IdProducto
            // 
            this.IdProducto.DataPropertyName = "IdProducto";
            this.IdProducto.HeaderText = "IdProducto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.Visible = false;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Nombre";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // CodigoContable
            // 
            this.CodigoContable.DataPropertyName = "CodigoContable";
            this.CodigoContable.HeaderText = "Codigo Contable";
            this.CodigoContable.Name = "CodigoContable";
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "IdUnidadMedida";
            this.Unidad.HeaderText = "Medida";
            this.Unidad.Name = "Unidad";
            // 
            // Lectura
            // 
            this.Lectura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Lectura.DataPropertyName = "SolicitarLectura";
            this.Lectura.HeaderText = "Lectura";
            this.Lectura.Name = "Lectura";
            this.Lectura.Width = 54;
            // 
            // CodigoTerpel
            // 
            this.CodigoTerpel.DataPropertyName = "CodigoTerpel";
            this.CodigoTerpel.HeaderText = "Codigo Satelite";
            this.CodigoTerpel.Name = "CodigoTerpel";
            this.CodigoTerpel.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(16, 56);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(490, 301);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(167, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 27);
            this.label2.TabIndex = 55;
            this.label2.Text = "PRODUCTO";
            // 
            // gsProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsProducto";
            this.Size = new System.Drawing.Size(519, 370);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProductos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.DataGridView dtgProductos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoContable;
        private System.Windows.Forms.DataGridViewComboBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Lectura;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoTerpel;
    }
}
