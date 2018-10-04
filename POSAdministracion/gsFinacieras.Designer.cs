namespace gasolutions.UInterface
{
    partial class gsFinacieras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gsFinacieras));
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.gbBanco = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbanco = new System.Windows.Forms.TextBox();
            this.dgbanco = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnlimpiarbanco = new System.Windows.Forms.Button();
            this.btnguardarbanco = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gbFinacieras = new System.Windows.Forms.GroupBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtFinaciera = new System.Windows.Forms.TextBox();
            this.dgFinancieras = new System.Windows.Forms.DataGridView();
            this.IdFinanciera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelPrincipal.SuspendLayout();
            this.gbBanco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbanco)).BeginInit();
            this.gbFinacieras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFinancieras)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.gbBanco);
            this.panelPrincipal.Controls.Add(this.gbFinacieras);
            this.panelPrincipal.Location = new System.Drawing.Point(10, 20);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(713, 359);
            this.panelPrincipal.TabIndex = 0;
            // 
            // gbBanco
            // 
            this.gbBanco.Controls.Add(this.label1);
            this.gbBanco.Controls.Add(this.button1);
            this.gbBanco.Controls.Add(this.txtcodigo);
            this.gbBanco.Controls.Add(this.label2);
            this.gbBanco.Controls.Add(this.txtbanco);
            this.gbBanco.Controls.Add(this.dgbanco);
            this.gbBanco.Controls.Add(this.btnlimpiarbanco);
            this.gbBanco.Controls.Add(this.btnguardarbanco);
            this.gbBanco.Controls.Add(this.label3);
            this.gbBanco.Location = new System.Drawing.Point(364, 27);
            this.gbBanco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBanco.Name = "gbBanco";
            this.gbBanco.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbBanco.Size = new System.Drawing.Size(341, 325);
            this.gbBanco.TabIndex = 1;
            this.gbBanco.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(98, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 22);
            this.label1.TabIndex = 29;
            this.label1.Text = "BANCOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.button1.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Eliminar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(209, 112);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 34);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcodigo.Location = new System.Drawing.Point(88, 78);
            this.txtcodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(236, 20);
            this.txtcodigo.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(13, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Codigo";
            // 
            // txtbanco
            // 
            this.txtbanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbanco.Location = new System.Drawing.Point(88, 48);
            this.txtbanco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbanco.Name = "txtbanco";
            this.txtbanco.Size = new System.Drawing.Size(236, 20);
            this.txtbanco.TabIndex = 26;
            // 
            // dgbanco
            // 
            this.dgbanco.AllowUserToAddRows = false;
            this.dgbanco.AllowUserToDeleteRows = false;
            this.dgbanco.BackgroundColor = System.Drawing.Color.White;
            this.dgbanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbanco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion});
            this.dgbanco.Location = new System.Drawing.Point(13, 154);
            this.dgbanco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgbanco.Name = "dgbanco";
            this.dgbanco.RowHeadersVisible = false;
            this.dgbanco.Size = new System.Drawing.Size(311, 149);
            this.dgbanco.TabIndex = 25;
            this.dgbanco.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbanco_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // btnlimpiarbanco
            // 
            this.btnlimpiarbanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnlimpiarbanco.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnlimpiarbanco.BackgroundImage")));
            this.btnlimpiarbanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnlimpiarbanco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarbanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarbanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlimpiarbanco.Location = new System.Drawing.Point(169, 112);
            this.btnlimpiarbanco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnlimpiarbanco.Name = "btnlimpiarbanco";
            this.btnlimpiarbanco.Size = new System.Drawing.Size(34, 34);
            this.btnlimpiarbanco.TabIndex = 24;
            this.btnlimpiarbanco.UseVisualStyleBackColor = false;
            this.btnlimpiarbanco.Click += new System.EventHandler(this.btnlimpiarbanco_Click);
            // 
            // btnguardarbanco
            // 
            this.btnguardarbanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnguardarbanco.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnguardarbanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnguardarbanco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarbanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarbanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarbanco.Location = new System.Drawing.Point(129, 112);
            this.btnguardarbanco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnguardarbanco.Name = "btnguardarbanco";
            this.btnguardarbanco.Size = new System.Drawing.Size(34, 34);
            this.btnguardarbanco.TabIndex = 23;
            this.btnguardarbanco.UseVisualStyleBackColor = false;
            this.btnguardarbanco.Click += new System.EventHandler(this.btnguardarbanco_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Banco";
            // 
            // gbFinacieras
            // 
            this.gbFinacieras.Controls.Add(this.lblDetalle);
            this.gbFinacieras.Controls.Add(this.btnEliminar);
            this.gbFinacieras.Controls.Add(this.txtFinaciera);
            this.gbFinacieras.Controls.Add(this.dgFinancieras);
            this.gbFinacieras.Controls.Add(this.btnLimpiar);
            this.gbFinacieras.Controls.Add(this.btnGuardar);
            this.gbFinacieras.Controls.Add(this.label9);
            this.gbFinacieras.Location = new System.Drawing.Point(6, 27);
            this.gbFinacieras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFinacieras.Name = "gbFinacieras";
            this.gbFinacieras.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFinacieras.Size = new System.Drawing.Size(341, 325);
            this.gbFinacieras.TabIndex = 0;
            this.gbFinacieras.TabStop = false;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(93, 12);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(172, 22);
            this.lblDetalle.TabIndex = 29;
            this.lblDetalle.Text = "FINANCIERAS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnEliminar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Eliminar;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(209, 112);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 34);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtFinaciera
            // 
            this.txtFinaciera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFinaciera.Location = new System.Drawing.Point(88, 48);
            this.txtFinaciera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFinaciera.Name = "txtFinaciera";
            this.txtFinaciera.Size = new System.Drawing.Size(236, 20);
            this.txtFinaciera.TabIndex = 22;
            // 
            // dgFinancieras
            // 
            this.dgFinancieras.AllowUserToAddRows = false;
            this.dgFinancieras.AllowUserToDeleteRows = false;
            this.dgFinancieras.BackgroundColor = System.Drawing.Color.White;
            this.dgFinancieras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFinancieras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFinanciera,
            this.Nombre});
            this.dgFinancieras.Location = new System.Drawing.Point(13, 154);
            this.dgFinancieras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgFinancieras.Name = "dgFinancieras";
            this.dgFinancieras.RowHeadersVisible = false;
            this.dgFinancieras.Size = new System.Drawing.Size(311, 149);
            this.dgFinancieras.TabIndex = 21;
            this.dgFinancieras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFinancieras_CellDoubleClick);
            // 
            // IdFinanciera
            // 
            this.IdFinanciera.DataPropertyName = "IdFinanciera";
            this.IdFinanciera.HeaderText = "IdFinanciera";
            this.IdFinanciera.Name = "IdFinanciera";
            this.IdFinanciera.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(169, 112);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(34, 34);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnGuardar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(129, 112);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(34, 34);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(13, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Financiera";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(719, 17);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(34, 34);
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(19, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 385);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(300, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 27);
            this.label4.TabIndex = 89;
            this.label4.Text = "FINANCIERAS";
            // 
            // gsFinacieras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCerrar);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsFinacieras";
            this.Size = new System.Drawing.Size(774, 495);
            this.Load += new System.EventHandler(this.gsFinacieras_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.gbBanco.ResumeLayout(false);
            this.gbBanco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbanco)).EndInit();
            this.gbFinacieras.ResumeLayout(false);
            this.gbFinacieras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFinancieras)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.GroupBox gbBanco;
        private System.Windows.Forms.GroupBox gbFinacieras;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgFinancieras;
        private System.Windows.Forms.Button btnlimpiarbanco;
        private System.Windows.Forms.Button btnguardarbanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbanco;
        private System.Windows.Forms.DataGridView dgbanco;
        private System.Windows.Forms.TextBox txtFinaciera;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFinanciera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
    }
}
