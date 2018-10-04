namespace Controles
{
    partial class frmAyuda
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
            this.dtgInformacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformacion)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgInformacion
            // 
            this.dtgInformacion.BackgroundColor = System.Drawing.Color.White;
            this.dtgInformacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgInformacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgInformacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgInformacion.Location = new System.Drawing.Point(0, 0);
            this.dtgInformacion.Name = "dtgInformacion";
            this.dtgInformacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgInformacion.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgInformacion.RowHeadersVisible = false;
            this.dtgInformacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgInformacion.Size = new System.Drawing.Size(651, 342);
            this.dtgInformacion.TabIndex = 0;
            this.dtgInformacion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgInformacion_CellDoubleClick);
            this.dtgInformacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgInformacion_KeyDown);
            this.dtgInformacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtgInformacion_KeyPress);
            // 
            // frmAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 342);
            this.Controls.Add(this.dtgInformacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmAyuda";
            this.Text = "<< Titulo >>";
            this.Load += new System.EventHandler(this.frmAyuda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgInformacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgInformacion;
    }
}