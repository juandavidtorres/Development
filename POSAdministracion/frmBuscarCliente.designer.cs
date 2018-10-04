namespace PayOffice
{
    partial class frmBuscarCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.rbPlaca = new System.Windows.Forms.RadioButton();
            this.rbNit = new System.Windows.Forms.RadioButton();
            this.rbNombre = new System.Windows.Forms.RadioButton();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtPlaca);
            this.groupBox1.Controls.Add(this.txtNit);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.rbPlaca);
            this.groupBox1.Controls.Add(this.rbNit);
            this.groupBox1.Controls.Add(this.rbNombre);
            this.groupBox1.Controls.Add(this.dgvResultado);
            this.groupBox1.Location = new System.Drawing.Point(15, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 201);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Editar;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(542, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtPlaca
            // 
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Location = new System.Drawing.Point(349, 49);
            this.txtPlaca.MaxLength = 50;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(176, 20);
            this.txtPlaca.TabIndex = 0;
            // 
            // txtNit
            // 
            this.txtNit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNit.Enabled = false;
            this.txtNit.Location = new System.Drawing.Point(87, 49);
            this.txtNit.MaxLength = 50;
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(176, 20);
            this.txtNit.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(87, 21);
            this.txtNombre.MaxLength = 150;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(437, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // rbPlaca
            // 
            this.rbPlaca.BackColor = System.Drawing.Color.White;
            this.rbPlaca.Checked = true;
            this.rbPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbPlaca.Location = new System.Drawing.Point(287, 47);
            this.rbPlaca.Name = "rbPlaca";
            this.rbPlaca.Size = new System.Drawing.Size(77, 24);
            this.rbPlaca.TabIndex = 1;
            this.rbPlaca.TabStop = true;
            this.rbPlaca.Text = "Placa";
            this.rbPlaca.UseVisualStyleBackColor = false;
            this.rbPlaca.CheckedChanged += new System.EventHandler(this.rbPlaca_CheckedChanged);
            // 
            // rbNit
            // 
            this.rbNit.BackColor = System.Drawing.Color.White;
            this.rbNit.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbNit.Location = new System.Drawing.Point(12, 49);
            this.rbNit.Name = "rbNit";
            this.rbNit.Size = new System.Drawing.Size(57, 24);
            this.rbNit.TabIndex = 4;
            this.rbNit.Text = "NIT";
            this.rbNit.UseVisualStyleBackColor = false;
            this.rbNit.CheckedChanged += new System.EventHandler(this.rbNit_CheckedChanged);
            // 
            // rbNombre
            // 
            this.rbNombre.BackColor = System.Drawing.Color.White;
            this.rbNombre.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.rbNombre.Location = new System.Drawing.Point(12, 19);
            this.rbNombre.Name = "rbNombre";
            this.rbNombre.Size = new System.Drawing.Size(69, 24);
            this.rbNombre.TabIndex = 2;
            this.rbNombre.Text = "Nombre";
            this.rbNombre.UseVisualStyleBackColor = false;
            this.rbNombre.CheckedChanged += new System.EventHandler(this.rbNombre_CheckedChanged);
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AllowUserToDeleteRows = false;
            this.dgvResultado.AllowUserToOrderColumns = true;
            this.dgvResultado.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Nit,
            this.Placa});
            this.dgvResultado.Location = new System.Drawing.Point(12, 79);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.RowHeadersVisible = false;
            this.dgvResultado.Size = new System.Drawing.Size(565, 99);
            this.dgvResultado.TabIndex = 8;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "Nuip";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            // 
            // Placa
            // 
            this.Placa.DataPropertyName = "Placa";
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCerrar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Cancel__2_;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(582, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(22, 22);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(624, 259);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Cliente";
            this.Load += new System.EventHandler(this.frmBuscarCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.RadioButton rbPlaca;
        private System.Windows.Forms.RadioButton rbNit;
        private System.Windows.Forms.RadioButton rbNombre;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
    }
}