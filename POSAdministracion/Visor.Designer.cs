namespace gasolutions.UInterface
{
    partial class Visor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgResultados = new System.Windows.Forms.DataGridView();
            this.EsFacturable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlbGuardar = new gasolutions.UInterface.CustomToolStrip();
            this.mnuPagar = new System.Windows.Forms.ToolStripButton();
            this.mnuBuscar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).BeginInit();
            this.tlbGuardar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgResultados
            // 
            this.dtgResultados.AllowUserToAddRows = false;
            this.dtgResultados.AllowUserToDeleteRows = false;
            this.dtgResultados.AllowUserToOrderColumns = true;
            this.dtgResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgResultados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EsFacturable});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgResultados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgResultados.Location = new System.Drawing.Point(0, 0);
            this.dtgResultados.Name = "dtgResultados";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgResultados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgResultados.RowHeadersVisible = false;
            this.dtgResultados.Size = new System.Drawing.Size(803, 657);
            this.dtgResultados.TabIndex = 2;
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
            this.tlbGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlbGuardar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbGuardar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPagar,
            this.mnuBuscar});
            this.tlbGuardar.Location = new System.Drawing.Point(0, 657);
            this.tlbGuardar.Name = "tlbGuardar";
            this.tlbGuardar.Size = new System.Drawing.Size(803, 39);
            this.tlbGuardar.TabIndex = 1;
            this.tlbGuardar.Text = "customToolStrip1";
            // 
            // mnuPagar
            // 
            this.mnuPagar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuPagar.Image = global::gasolutions.UInterface.Properties.Resources.cliente_;
            this.mnuPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuPagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuPagar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPagar.Name = "mnuPagar";
            this.mnuPagar.Size = new System.Drawing.Size(36, 36);
            this.mnuPagar.Text = "Pagar";
            this.mnuPagar.Click += new System.EventHandler(this.mnuPagar_Click);
            // 
            // mnuBuscar
            // 
            this.mnuBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBuscar.Image = global::gasolutions.UInterface.Properties.Resources.view_next;
            this.mnuBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBuscar.Name = "mnuBuscar";
            this.mnuBuscar.Size = new System.Drawing.Size(36, 36);
            this.mnuBuscar.Text = "Buscar";
            this.mnuBuscar.Click += new System.EventHandler(this.mnuBuscar_Click);
            // 
            // Visor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 696);
            this.Controls.Add(this.dtgResultados);
            this.Controls.Add(this.tlbGuardar);
            this.Name = "Visor";
            this.Text = "Visor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Visor_FormClosing);
            this.Load += new System.EventHandler(this.Visor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResultados)).EndInit();
            this.tlbGuardar.ResumeLayout(false);
            this.tlbGuardar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomToolStrip tlbGuardar;
        private System.Windows.Forms.DataGridView dtgResultados;
        private System.Windows.Forms.ToolStripButton mnuPagar;
        private System.Windows.Forms.ToolStripButton mnuBuscar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsFacturable;
    }
}