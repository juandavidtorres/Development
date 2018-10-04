namespace PosConfiguracion
{
    partial class SobreTasa
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
            this.dtgSobreTasa = new System.Windows.Forms.DataGridView();
            this.ColSobreTasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IdHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tsbGuardar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSobreTasa)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgSobreTasa
            // 
            this.dtgSobreTasa.BackgroundColor = System.Drawing.Color.White;
            this.dtgSobreTasa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSobreTasa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSobreTasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSobreTasa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSobreTasa,
            this.FechaInicial,
            this.FechaFinal,
            this.Activa,
            this.Producto,
            this.IdHistorico});
            this.dtgSobreTasa.Location = new System.Drawing.Point(22, 30);
            this.dtgSobreTasa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgSobreTasa.Name = "dtgSobreTasa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgSobreTasa.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgSobreTasa.RowHeadersVisible = false;
            this.dtgSobreTasa.Size = new System.Drawing.Size(567, 300);
            this.dtgSobreTasa.TabIndex = 4;
            this.dtgSobreTasa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSobreTasa_CellDoubleClick);
            this.dtgSobreTasa.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSobreTasa_CellValidated);
            this.dtgSobreTasa.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgSobreTasa_CellValidating);
            // 
            // ColSobreTasa
            // 
            this.ColSobreTasa.DataPropertyName = "SobreTasa";
            this.ColSobreTasa.HeaderText = "Sobre Tasa";
            this.ColSobreTasa.Name = "ColSobreTasa";
            // 
            // FechaInicial
            // 
            this.FechaInicial.DataPropertyName = "FechaInicial";
            this.FechaInicial.HeaderText = "Fecha Inicial";
            this.FechaInicial.Name = "FechaInicial";
            // 
            // FechaFinal
            // 
            this.FechaFinal.DataPropertyName = "FechaFinal";
            this.FechaFinal.HeaderText = "Fecha Final";
            this.FechaFinal.Name = "FechaFinal";
            // 
            // Activa
            // 
            this.Activa.DataPropertyName = "EsActivo";
            this.Activa.HeaderText = "Activa";
            this.Activa.Name = "Activa";
            this.Activa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "IdProducto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            // 
            // IdHistorico
            // 
            this.IdHistorico.DataPropertyName = "IdHistorico";
            this.IdHistorico.HeaderText = "IdHistorico";
            this.IdHistorico.Name = "IdHistorico";
            this.IdHistorico.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(22, 334);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(41, 38);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgSobreTasa);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(22, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(610, 387);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(237, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 27);
            this.label3.TabIndex = 53;
            this.label3.Text = "SOBRE TASA";
            // 
            // tsbGuardar
            // 
            this.tsbGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbGuardar.AutoSize = false;
            this.tsbGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.tsbGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardar.Image = global::PosConfiguracion.Properties.Resources.Guardar__2_;
            this.tsbGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.tsbGuardar.Name = "tsbGuardar";
            this.tsbGuardar.Size = new System.Drawing.Size(34, 34);
            this.tsbGuardar.Text = "Guardar";
            this.tsbGuardar.ToolTipText = "Guardar";
            this.tsbGuardar.Click += new System.EventHandler(this.tsbGuardar_Click);
            // 
            // SobreTasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SobreTasa";
            this.Size = new System.Drawing.Size(654, 453);
            this.Load += new System.EventHandler(this.SobreTasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSobreTasa)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSobreTasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSobreTasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFinal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activa;
        private System.Windows.Forms.DataGridViewComboBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdHistorico;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}
