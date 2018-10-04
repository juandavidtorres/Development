namespace PosStation.gsPagoFacturas
{
    partial class gsPagoFacturas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dtgResultados = new System.Windows.Forms.DataGridView();
            this.EsFacturable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlbGuardar = new gasolutions.UInterface.CustomToolStrip();
            this.mnuPagar = new System.Windows.Forms.ToolStripButton();
            this.mnuBuscar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).BeginInit();
            this.tlbGuardar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.dtgResultados);
            this.pnlContenedor.Location = new System.Drawing.Point(12, 18);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(811, 606);
            this.pnlContenedor.TabIndex = 0;
            // 
            // dtgResultados
            // 
            this.dtgResultados.AllowUserToAddRows = false;
            this.dtgResultados.AllowUserToDeleteRows = false;
            this.dtgResultados.AllowUserToOrderColumns = true;
            this.dtgResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgResultados.BackgroundColor = System.Drawing.Color.White;
            this.dtgResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EsFacturable});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgResultados.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgResultados.Location = new System.Drawing.Point(6, 5);
            this.dtgResultados.Name = "dtgResultados";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResultados.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgResultados.RowHeadersVisible = false;
            this.dtgResultados.Size = new System.Drawing.Size(799, 593);
            this.dtgResultados.TabIndex = 4;
            // 
            // EsFacturable
            // 
            this.EsFacturable.HeaderText = " ";
            this.EsFacturable.Name = "EsFacturable";
            this.EsFacturable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EsFacturable.Width = 36;
            // 
            // tlbGuardar
            // 
            this.tlbGuardar.BackColor = System.Drawing.Color.Transparent;
            this.tlbGuardar.Dock = System.Windows.Forms.DockStyle.None;
            this.tlbGuardar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbGuardar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrar,
            this.mnuPagar,
            this.mnuBuscar});
            this.tlbGuardar.Location = new System.Drawing.Point(704, 640);
            this.tlbGuardar.Name = "tlbGuardar";
            this.tlbGuardar.Size = new System.Drawing.Size(121, 40);
            this.tlbGuardar.TabIndex = 2;
            this.tlbGuardar.Text = "customToolStrip1";
            // 
            // mnuPagar
            // 
            this.mnuPagar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuPagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuPagar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.mnuPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPagar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuPagar.Name = "mnuPagar";
            this.mnuPagar.Size = new System.Drawing.Size(35, 36);
            this.mnuPagar.Text = "Pagar";
            this.mnuPagar.Click += new System.EventHandler(this.mnuPagar_Click);
            // 
            // mnuBuscar
            // 
            this.mnuBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.mnuBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuBuscar.Name = "mnuBuscar";
            this.mnuBuscar.Size = new System.Drawing.Size(35, 36);
            this.mnuBuscar.Text = "Buscar";
            this.mnuBuscar.Click += new System.EventHandler(this.mnuBuscar_Click);
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(36, 36);
            this.mnuCerrar.Text = "toolStripButton1";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlContenedor);
            this.groupBox1.Controls.Add(this.tlbGuardar);
            this.groupBox1.Location = new System.Drawing.Point(21, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 694);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(350, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 27);
            this.label7.TabIndex = 55;
            this.label7.Text = "PAGO FACTURAS";
            // 
            // gsPagoFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Name = "gsPagoFacturas";
            this.Size = new System.Drawing.Size(876, 763);
            this.pnlContenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).EndInit();
            this.tlbGuardar.ResumeLayout(false);
            this.tlbGuardar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private gasolutions.UInterface.CustomToolStrip tlbGuardar;
        private System.Windows.Forms.ToolStripButton mnuPagar;
        private System.Windows.Forms.ToolStripButton mnuBuscar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.DataGridView dtgResultados;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsFacturable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}
