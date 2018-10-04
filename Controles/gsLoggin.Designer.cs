namespace Controles
{
    partial class gsLoggin
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
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.dtgResultado = new System.Windows.Forms.DataGridView();
            this.tooMain = new System.Windows.Forms.ToolStrip();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.cmbColumnas = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBusqueda = new System.Windows.Forms.ToolStripTextBox();
            this.mnuBuscar = new System.Windows.Forms.ToolStripLabel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultado)).BeginInit();
            this.tooMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Controls.Add(this.dtgResultado);
            this.pnlContenedor.Controls.Add(this.tooMain);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(837, 565);
            this.pnlContenedor.TabIndex = 0;
            // 
            // dtgResultado
            // 
            this.dtgResultado.AllowUserToAddRows = false;
            this.dtgResultado.AllowUserToDeleteRows = false;
            this.dtgResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgResultado.BackgroundColor = System.Drawing.Color.White;
            this.dtgResultado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgResultado.GridColor = System.Drawing.Color.White;
            this.dtgResultado.Location = new System.Drawing.Point(0, 25);
            this.dtgResultado.Name = "dtgResultado";
            this.dtgResultado.ReadOnly = true;
            this.dtgResultado.RowHeadersVisible = false;
            this.dtgResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgResultado.Size = new System.Drawing.Size(837, 540);
            this.dtgResultado.TabIndex = 1;
            this.dtgResultado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgResultado_CellContentClick);
            // 
            // tooMain
            // 
            this.tooMain.BackColor = System.Drawing.Color.White;
            this.tooMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tooMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir,
            this.cmbColumnas,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.txtBusqueda,
            this.mnuBuscar});
            this.tooMain.Location = new System.Drawing.Point(0, 0);
            this.tooMain.Name = "tooMain";
            this.tooMain.Size = new System.Drawing.Size(837, 25);
            this.tooMain.TabIndex = 0;
            this.tooMain.Text = "toolStrip1";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(23, 22);
            this.mnuSalir.Text = "toolStripButton1";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // cmbColumnas
            // 
            this.cmbColumnas.Name = "cmbColumnas";
            this.cmbColumnas.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(100, 25);
            // 
            // mnuBuscar
            // 
            this.mnuBuscar.Name = "mnuBuscar";
            this.mnuBuscar.Size = new System.Drawing.Size(42, 22);
            this.mnuBuscar.Text = "Buscar";
            this.mnuBuscar.ToolTipText = "Buscar Texto dentro de la Cuadricula";
            this.mnuBuscar.Click += new System.EventHandler(this.mnuBuscar_Click);
            // 
            // gsLoggin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlContenedor);
            this.Name = "gsLoggin";
            this.Size = new System.Drawing.Size(837, 565);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultado)).EndInit();
            this.tooMain.ResumeLayout(false);
            this.tooMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.ToolStrip tooMain;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.DataGridView dtgResultado;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripComboBox cmbColumnas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtBusqueda;
        private System.Windows.Forms.ToolStripLabel mnuBuscar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
