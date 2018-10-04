namespace PosConfiguracion
{
    partial class Decimales
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
            this.dtgFactor = new System.Windows.Forms.DataGridView();
            this.Precio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Volumen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Totalizador = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PredeterminacionVolumen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PredeterminacionImporte = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgFactor
            // 
            this.dtgFactor.AllowUserToAddRows = false;
            this.dtgFactor.AllowUserToDeleteRows = false;
            this.dtgFactor.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFactor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgFactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFactor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Precio,
            this.Volumen,
            this.Valor,
            this.Totalizador,
            this.PredeterminacionVolumen,
            this.PredeterminacionImporte});
            this.dtgFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgFactor.Location = new System.Drawing.Point(0, 0);
            this.dtgFactor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgFactor.Name = "dtgFactor";
            this.dtgFactor.RowHeadersVisible = false;
            this.dtgFactor.Size = new System.Drawing.Size(732, 150);
            this.dtgFactor.TabIndex = 0;
            this.dtgFactor.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgFactor_CellValueChanged);
            this.dtgFactor.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgFactor_DataError);
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Precio.Name = "Precio";
            // 
            // Volumen
            // 
            this.Volumen.DataPropertyName = "Volumen";
            this.Volumen.HeaderText = "Volumen";
            this.Volumen.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Volumen.Name = "Volumen";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Valor.Name = "Valor";
            // 
            // Totalizador
            // 
            this.Totalizador.DataPropertyName = "Totalizador";
            this.Totalizador.HeaderText = "Totalizador";
            this.Totalizador.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.Totalizador.Name = "Totalizador";
            // 
            // PredeterminacionVolumen
            // 
            this.PredeterminacionVolumen.DataPropertyName = "PredeterminacionVolumen";
            this.PredeterminacionVolumen.HeaderText = "PredeterminacionVolumen";
            this.PredeterminacionVolumen.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.PredeterminacionVolumen.Name = "PredeterminacionVolumen";
            this.PredeterminacionVolumen.Width = 160;
            // 
            // PredeterminacionImporte
            // 
            this.PredeterminacionImporte.DataPropertyName = "PredeterminacionImporte";
            this.PredeterminacionImporte.HeaderText = "PredeterminacionImporte";
            this.PredeterminacionImporte.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.PredeterminacionImporte.Name = "PredeterminacionImporte";
            this.PredeterminacionImporte.Width = 160;
            // 
            // Decimales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 150);
            this.Controls.Add(this.dtgFactor);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Decimales";
            this.Text = "Numero de Decimales";
            this.Load += new System.EventHandler(this.Decimales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFactor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgFactor;
        private System.Windows.Forms.DataGridViewComboBoxColumn Precio;
        private System.Windows.Forms.DataGridViewComboBoxColumn Volumen;
        private System.Windows.Forms.DataGridViewComboBoxColumn Valor;
        private System.Windows.Forms.DataGridViewComboBoxColumn Totalizador;
        private System.Windows.Forms.DataGridViewComboBoxColumn PredeterminacionVolumen;
        private System.Windows.Forms.DataGridViewComboBoxColumn PredeterminacionImporte;
    }
}