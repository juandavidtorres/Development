namespace PosConfiguracion
{
    partial class gsFormaPago
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
            this.pnlFormaPago = new System.Windows.Forms.Panel();
            this.label37 = new System.Windows.Forms.Label();
            this.grdFormaPago = new System.Windows.Forms.DataGridView();
            this.pnlFormaPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFormaPago)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFormaPago
            // 
            this.pnlFormaPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.pnlFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormaPago.Controls.Add(this.label37);
            this.pnlFormaPago.Controls.Add(this.grdFormaPago);
            this.pnlFormaPago.Location = new System.Drawing.Point(-1, -1);
            this.pnlFormaPago.Name = "pnlFormaPago";
            this.pnlFormaPago.Size = new System.Drawing.Size(1048, 618);
            this.pnlFormaPago.TabIndex = 29;
            this.pnlFormaPago.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormaPago_Paint);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(15, 9);
            this.label37.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(588, 18);
            this.label37.TabIndex = 28;
            this.label37.Text = "Formas de Pago";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdFormaPago
            // 
            this.grdFormaPago.AllowUserToAddRows = false;
            this.grdFormaPago.AllowUserToDeleteRows = false;
            this.grdFormaPago.AllowUserToResizeColumns = false;
            this.grdFormaPago.AllowUserToResizeRows = false;
            this.grdFormaPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdFormaPago.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdFormaPago.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.grdFormaPago.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdFormaPago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFormaPago.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdFormaPago.Location = new System.Drawing.Point(15, 30);
            this.grdFormaPago.MultiSelect = false;
            this.grdFormaPago.Name = "grdFormaPago";
            this.grdFormaPago.RowHeadersVisible = false;
            this.grdFormaPago.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdFormaPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFormaPago.Size = new System.Drawing.Size(606, 469);
            this.grdFormaPago.TabIndex = 29;
            this.grdFormaPago.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFormaPago_CellValueChanged);
            this.grdFormaPago.CurrentCellDirtyStateChanged += new System.EventHandler(this.grdFormaPago_CurrentCellDirtyStateChanged);
            // 
            // gsFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pnlFormaPago);
            this.Name = "gsFormaPago";
            this.Size = new System.Drawing.Size(1044, 612);
            this.pnlFormaPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFormaPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFormaPago;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.DataGridView grdFormaPago;
    }
}
