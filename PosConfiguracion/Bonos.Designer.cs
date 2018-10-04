namespace PosConfiguracion
{
    partial class Bonos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bonos));
            this.Label1 = new System.Windows.Forms.Label();
            this.grdCOnsultaBonos = new System.Windows.Forms.DataGridView();
            this.IdBono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoBono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCOnsultaBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Label1.Location = new System.Drawing.Point(144, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(197, 24);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "CONSULTA DE BONOS";
            // 
            // grdCOnsultaBonos
            // 
            this.grdCOnsultaBonos.AllowUserToDeleteRows = false;
            this.grdCOnsultaBonos.AllowUserToResizeColumns = false;
            this.grdCOnsultaBonos.AllowUserToResizeRows = false;
            this.grdCOnsultaBonos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCOnsultaBonos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCOnsultaBonos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdCOnsultaBonos.BackgroundColor = System.Drawing.Color.White;
            this.grdCOnsultaBonos.CausesValidation = false;
            this.grdCOnsultaBonos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdCOnsultaBonos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grdCOnsultaBonos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCOnsultaBonos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdCOnsultaBonos.ColumnHeadersHeight = 30;
            this.grdCOnsultaBonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdBono,
            this.Bono,
            this.TipoBono,
            this.Puntos,
            this.Valor});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCOnsultaBonos.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdCOnsultaBonos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(22)))), ((int)(((byte)(43)))));
            this.grdCOnsultaBonos.Location = new System.Drawing.Point(15, 68);
            this.grdCOnsultaBonos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCOnsultaBonos.MultiSelect = false;
            this.grdCOnsultaBonos.Name = "grdCOnsultaBonos";
            this.grdCOnsultaBonos.ReadOnly = true;
            this.grdCOnsultaBonos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdCOnsultaBonos.RowHeadersVisible = false;
            this.grdCOnsultaBonos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdCOnsultaBonos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.grdCOnsultaBonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCOnsultaBonos.Size = new System.Drawing.Size(472, 295);
            this.grdCOnsultaBonos.TabIndex = 2;
            // 
            // IdBono
            // 
            this.IdBono.DataPropertyName = "IdBono";
            this.IdBono.HeaderText = "IdBono";
            this.IdBono.Name = "IdBono";
            this.IdBono.ReadOnly = true;
            this.IdBono.Visible = false;
            // 
            // Bono
            // 
            this.Bono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Bono.DataPropertyName = "Nombre";
            this.Bono.HeaderText = "Bono";
            this.Bono.Name = "Bono";
            this.Bono.ReadOnly = true;
            this.Bono.Width = 63;
            // 
            // TipoBono
            // 
            this.TipoBono.DataPropertyName = "Tipo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.TipoBono.DefaultCellStyle = dataGridViewCellStyle8;
            this.TipoBono.HeaderText = "Tipo Bono";
            this.TipoBono.Name = "TipoBono";
            this.TipoBono.ReadOnly = true;
            // 
            // Puntos
            // 
            this.Puntos.DataPropertyName = "Puntos";
            this.Puntos.HeaderText = "Puntos";
            this.Puntos.Name = "Puntos";
            this.Puntos.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(215, 388);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(77, 68);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 424);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Bonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.grdCOnsultaBonos);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Bonos";
            this.Size = new System.Drawing.Size(530, 510);
            this.Load += new System.EventHandler(this.Bonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCOnsultaBonos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        public System.Windows.Forms.DataGridView grdCOnsultaBonos;
        internal System.Windows.Forms.DataGridViewTextBoxColumn IdBono;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Bono;
        internal System.Windows.Forms.DataGridViewTextBoxColumn TipoBono;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Puntos;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        internal System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
