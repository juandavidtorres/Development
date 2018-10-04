namespace gasolutions.UInterface
{
    partial class Facturar
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.customToolStrip1 = new gasolutions.UInterface.CustomToolStrip();
            this.mnuFacturar = new System.Windows.Forms.ToolStripButton();
            this.mnuConsultar = new System.Windows.Forms.ToolStripButton();
            this.mnuDeshacer = new System.Windows.Forms.ToolStripButton();
            this.mnuVisualizar = new System.Windows.Forms.ToolStripButton();
            this.mnuImprimir = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.customToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Location = new System.Drawing.Point(14, 65);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(808, 598);
            this.pnlContenedor.TabIndex = 1;
            // 
            // customToolStrip1
            // 
            this.customToolStrip1.BackColor = System.Drawing.Color.White;
            this.customToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.customToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.customToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFacturar,
            this.mnuConsultar,
            this.mnuDeshacer,
            this.mnuVisualizar,
            this.mnuImprimir,
            this.mnuCerrar});
            this.customToolStrip1.Location = new System.Drawing.Point(587, 16);
            this.customToolStrip1.Name = "customToolStrip1";
            this.customToolStrip1.Size = new System.Drawing.Size(240, 40);
            this.customToolStrip1.TabIndex = 0;
            this.customToolStrip1.Text = "customToolStrip1";
            // 
            // mnuFacturar
            // 
            this.mnuFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuFacturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuFacturar.Image = global::gasolutions.UInterface.Properties.Resources.Calculadora;
            this.mnuFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFacturar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuFacturar.Name = "mnuFacturar";
            this.mnuFacturar.Size = new System.Drawing.Size(35, 36);
            this.mnuFacturar.Text = "Facturar";
            this.mnuFacturar.Click += new System.EventHandler(this.mnuFacturar_Click);
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
            // 
            // mnuDeshacer
            // 
            this.mnuDeshacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuDeshacer.Image = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.mnuDeshacer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeshacer.Margin = new System.Windows.Forms.Padding(2);
            this.mnuDeshacer.Name = "mnuDeshacer";
            this.mnuDeshacer.Size = new System.Drawing.Size(37, 36);
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
            this.mnuVisualizar.Click += new System.EventHandler(this.mnuVisualizar_Click);
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
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customToolStrip1);
            this.groupBox1.Controls.Add(this.pnlContenedor);
            this.groupBox1.Location = new System.Drawing.Point(20, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 677);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(380, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 27);
            this.label2.TabIndex = 53;
            this.label2.Text = "FACTURAR";
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(877, 748);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Facturar";
            this.customToolStrip1.ResumeLayout(false);
            this.customToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomToolStrip customToolStrip1;
        private System.Windows.Forms.ToolStripButton mnuFacturar;
        private System.Windows.Forms.ToolStripButton mnuConsultar;
        private System.Windows.Forms.ToolStripButton mnuDeshacer;
        private System.Windows.Forms.ToolStripButton mnuVisualizar;
        private System.Windows.Forms.ToolStripButton mnuImprimir;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;

    }
}