namespace gasolutions.UInterface
{
    partial class gsFacturacion
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
            this.pnlVista = new System.Windows.Forms.Panel();
            this.customToolStrip1 = new gasolutions.UInterface.CustomToolStrip();
            this.mnuFacturar = new System.Windows.Forms.ToolStripButton();
            this.mnuConsultar = new System.Windows.Forms.ToolStripButton();
            this.mnuDeshacer = new System.Windows.Forms.ToolStripButton();
            this.mnuVisualizar = new System.Windows.Forms.ToolStripButton();
            this.mnuImprimir = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlContenedor.SuspendLayout();
            this.customToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.pnlVista);
            this.pnlContenedor.Controls.Add(this.customToolStrip1);
            this.pnlContenedor.Location = new System.Drawing.Point(12, 16);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(832, 599);
            this.pnlContenedor.TabIndex = 0;
            // 
            // pnlVista
            // 
            this.pnlVista.Location = new System.Drawing.Point(3, 42);
            this.pnlVista.Name = "pnlVista";
            this.pnlVista.Size = new System.Drawing.Size(824, 550);
            this.pnlVista.TabIndex = 2;
            // 
            // customToolStrip1
            // 
            this.customToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.customToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.customToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFacturar,
            this.mnuConsultar,
            this.mnuDeshacer,
            this.mnuVisualizar,
            this.mnuImprimir,
            this.mnuCerrar});
            this.customToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.customToolStrip1.Name = "customToolStrip1";
            this.customToolStrip1.Size = new System.Drawing.Size(832, 40);
            this.customToolStrip1.TabIndex = 1;
            this.customToolStrip1.Text = "customToolStrip1";
            // 
            // mnuFacturar
            // 
            this.mnuFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuFacturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuFacturar.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFacturar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuFacturar.Name = "mnuFacturar";
            this.mnuFacturar.Size = new System.Drawing.Size(35, 36);
            this.mnuFacturar.Text = "Facturar";
            // 
            // mnuConsultar
            // 
            this.mnuConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuConsultar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.mnuConsultar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuConsultar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuConsultar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuConsultar.Name = "mnuConsultar";
            this.mnuConsultar.Size = new System.Drawing.Size(35, 36);
            this.mnuConsultar.Text = "Consultar";
            this.mnuConsultar.Click += new System.EventHandler(this.mnuConsultar_Click);
            // 
            // mnuDeshacer
            // 
            this.mnuDeshacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuDeshacer.Image = global::gasolutions.UInterface.Properties.Resources.Regresar;
            this.mnuDeshacer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeshacer.Margin = new System.Windows.Forms.Padding(2);
            this.mnuDeshacer.Name = "mnuDeshacer";
            this.mnuDeshacer.Size = new System.Drawing.Size(35, 36);
            this.mnuDeshacer.Text = "Reversar Facturacion";
            // 
            // mnuVisualizar
            // 
            this.mnuVisualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuVisualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuVisualizar.Image = global::gasolutions.UInterface.Properties.Resources.Predet;
            this.mnuVisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuVisualizar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuVisualizar.Name = "mnuVisualizar";
            this.mnuVisualizar.Size = new System.Drawing.Size(35, 36);
            this.mnuVisualizar.Text = "Visualizar";
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
            this.mnuImprimir.Text = "Imprimir";
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(36, 36);
            this.mnuCerrar.Text = "Cerrar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlContenedor);
            this.groupBox1.Location = new System.Drawing.Point(21, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 629);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(372, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.TabIndex = 90;
            this.label4.Text = "FACTURACIÓN";
            // 
            // gsFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "gsFacturacion";
            this.Size = new System.Drawing.Size(895, 693);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.customToolStrip1.ResumeLayout(false);
            this.customToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private CustomToolStrip customToolStrip1;
        private System.Windows.Forms.ToolStripButton mnuFacturar;
        private System.Windows.Forms.ToolStripButton mnuConsultar;
        private System.Windows.Forms.ToolStripButton mnuDeshacer;
        private System.Windows.Forms.ToolStripButton mnuVisualizar;
        private System.Windows.Forms.ToolStripButton mnuImprimir;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnlVista;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
    }
}
