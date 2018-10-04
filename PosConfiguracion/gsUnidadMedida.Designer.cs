namespace PosConfiguracion
{
    partial class gsUnidadMedida
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grdUnidadMedida = new System.Windows.Forms.DataGridView();
            this.grdUnidadMedidaIdUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdUnidadMedidaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCodigoMenoCash = new System.Windows.Forms.TextBox();
            this.LblCodigoMenoCash = new System.Windows.Forms.Label();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnidadMedida)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.TxtCodigoMenoCash);
            this.panel9.Controls.Add(this.LblCodigoMenoCash);
            this.panel9.Controls.Add(this.btnAgregar);
            this.panel9.Controls.Add(this.txtNombre);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.grdUnidadMedida);
            this.panel9.Location = new System.Drawing.Point(18, 19);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(337, 323);
            this.panel9.TabIndex = 52;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::PosConfiguracion.Properties.Resources.Agregar1;
            this.btnAgregar.Location = new System.Drawing.Point(301, 6);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(34, 34);
            this.btnAgregar.TabIndex = 56;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Location = new System.Drawing.Point(110, 13);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 20);
            this.txtNombre.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(5, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 52;
            this.label8.Text = "Unidad Medida:";
            // 
            // grdUnidadMedida
            // 
            this.grdUnidadMedida.AllowUserToAddRows = false;
            this.grdUnidadMedida.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdUnidadMedida.BackgroundColor = System.Drawing.Color.White;
            this.grdUnidadMedida.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdUnidadMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUnidadMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdUnidadMedidaIdUnidad,
            this.grdUnidadMedidaNombre});
            this.grdUnidadMedida.Location = new System.Drawing.Point(4, 107);
            this.grdUnidadMedida.MultiSelect = false;
            this.grdUnidadMedida.Name = "grdUnidadMedida";
            this.grdUnidadMedida.ReadOnly = true;
            this.grdUnidadMedida.RowHeadersVisible = false;
            this.grdUnidadMedida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUnidadMedida.ShowCellErrors = false;
            this.grdUnidadMedida.ShowRowErrors = false;
            this.grdUnidadMedida.Size = new System.Drawing.Size(329, 210);
            this.grdUnidadMedida.TabIndex = 49;
            this.grdUnidadMedida.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdUnidadMedida_UserDeletedRow);
            this.grdUnidadMedida.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdUnidadMedida_UserDeletingRow);
            // 
            // grdUnidadMedidaIdUnidad
            // 
            this.grdUnidadMedidaIdUnidad.DataPropertyName = "IdUnidad";
            this.grdUnidadMedidaIdUnidad.HeaderText = "IdUnidad";
            this.grdUnidadMedidaIdUnidad.Name = "grdUnidadMedidaIdUnidad";
            this.grdUnidadMedidaIdUnidad.ReadOnly = true;
            this.grdUnidadMedidaIdUnidad.Visible = false;
            // 
            // grdUnidadMedidaNombre
            // 
            this.grdUnidadMedidaNombre.DataPropertyName = "Descripcion";
            this.grdUnidadMedidaNombre.FillWeight = 250F;
            this.grdUnidadMedidaNombre.HeaderText = "Unidad Medida";
            this.grdUnidadMedidaNombre.Name = "grdUnidadMedidaNombre";
            this.grdUnidadMedidaNombre.ReadOnly = true;
            this.grdUnidadMedidaNombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdUnidadMedidaNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.grdUnidadMedidaNombre.Width = 250;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Location = new System.Drawing.Point(20, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 407);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(106, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 27);
            this.label2.TabIndex = 54;
            this.label2.Text = "UNIDAD DE MEDIDA";
            // 
            // TxtCodigoMenoCash
            // 
            this.TxtCodigoMenoCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCodigoMenoCash.Location = new System.Drawing.Point(110, 55);
            this.TxtCodigoMenoCash.Name = "TxtCodigoMenoCash";
            this.TxtCodigoMenoCash.Size = new System.Drawing.Size(187, 20);
            this.TxtCodigoMenoCash.TabIndex = 58;
            // 
            // LblCodigoMenoCash
            // 
            this.LblCodigoMenoCash.AutoSize = true;
            this.LblCodigoMenoCash.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigoMenoCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.LblCodigoMenoCash.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCodigoMenoCash.Location = new System.Drawing.Point(5, 57);
            this.LblCodigoMenoCash.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.LblCodigoMenoCash.Name = "LblCodigoMenoCash";
            this.LblCodigoMenoCash.Size = new System.Drawing.Size(106, 16);
            this.LblCodigoMenoCash.TabIndex = 57;
            this.LblCodigoMenoCash.Text = "Codigo MenoCash:";
            // 
            // gsUnidadMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "gsUnidadMedida";
            this.Size = new System.Drawing.Size(413, 482);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUnidadMedida)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView grdUnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdUnidadMedidaIdUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdUnidadMedidaNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCodigoMenoCash;
        private System.Windows.Forms.Label LblCodigoMenoCash;
    }
}
