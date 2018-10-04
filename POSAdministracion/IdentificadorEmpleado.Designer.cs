namespace gasolutions
{
    partial class IdentificadorEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.dgvIdentificador = new System.Windows.Forms.DataGridView();
            this.IdIdentificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlChip = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoIdent = new System.Windows.Forms.ComboBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.txtRom = new System.Windows.Forms.TextBox();
            this.lblRom = new System.Windows.Forms.Label();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.btnLeerChip = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.Popup = new PopupNotifier();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificador)).BeginInit();
            this.pnlChip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            this.ctrlOcxChip = new AxGrabacionTmex.AxITmex();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblIdEmpleado);
            this.panel1.Controls.Add(this.dgvIdentificador);
            this.panel1.Controls.Add(this.pnlChip);
            this.panel1.Controls.Add(this.ctrlOcxChip);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(11, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 354);
            this.panel1.TabIndex = 0;

            //
            // ctrlOcxChip
            // 
            this.ctrlOcxChip.Enabled = true;
            this.ctrlOcxChip.Location = new System.Drawing.Point(568, 122);
            this.ctrlOcxChip.Name = "ctrlOcxChip";
            //  this.ctrlOcxChip.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ctrlOcxChip.OcxState")));
            this.ctrlOcxChip.Size = new System.Drawing.Size(69, 45);
            this.ctrlOcxChip.TabIndex = 68;
            this.ctrlOcxChip.Visible = false;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(366, 14);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(18, 16);
            this.lblIdEmpleado.TabIndex = 71;
            this.lblIdEmpleado.Text = "-1";
            this.lblIdEmpleado.Visible = false;
            // 
            // dgvIdentificador
            // 
            this.dgvIdentificador.AllowUserToAddRows = false;
            this.dgvIdentificador.AllowUserToDeleteRows = false;
            this.dgvIdentificador.BackgroundColor = System.Drawing.Color.White;
            this.dgvIdentificador.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIdentificador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIdentificador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdentificador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdIdentificador,
            this.Tipo,
            this.Numero,
            this.Activo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIdentificador.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIdentificador.Location = new System.Drawing.Point(4, 125);
            this.dgvIdentificador.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvIdentificador.Name = "dgvIdentificador";
            this.dgvIdentificador.ReadOnly = true;
            this.dgvIdentificador.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvIdentificador.RowHeadersVisible = false;
            this.dgvIdentificador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdentificador.Size = new System.Drawing.Size(383, 225);
            this.dgvIdentificador.TabIndex = 70;
            this.dgvIdentificador.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIdentificador_CellDoubleClick);
            // 
            // IdIdentificador
            // 
            this.IdIdentificador.DataPropertyName = "IdIdentificador";
            this.IdIdentificador.HeaderText = "IdIdentificador";
            this.IdIdentificador.Name = "IdIdentificador";
            this.IdIdentificador.ReadOnly = true;
            this.IdIdentificador.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 130;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 180;
            // 
            // Activo
            // 
            this.Activo.DataPropertyName = "Activo";
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.ReadOnly = true;
            this.Activo.Width = 50;
            // 
            // pnlChip
            // 
            this.pnlChip.Controls.Add(this.label1);
            this.pnlChip.Controls.Add(this.cmbTipoIdent);
            this.pnlChip.Controls.Add(this.lblPuerto);
            this.pnlChip.Controls.Add(this.txtRom);
            this.pnlChip.Controls.Add(this.lblRom);
            this.pnlChip.Controls.Add(this.cmbPuerto);
            this.pnlChip.Controls.Add(this.btnLeerChip);
            this.pnlChip.Location = new System.Drawing.Point(4, 44);
            this.pnlChip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlChip.Name = "pnlChip";
            this.pnlChip.Size = new System.Drawing.Size(383, 65);
            this.pnlChip.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 73;
            this.label1.Text = "Identificacion";
            // 
            // cmbTipoIdent
            // 
            this.cmbTipoIdent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdent.FormattingEnabled = true;
            this.cmbTipoIdent.Location = new System.Drawing.Point(91, 4);
            this.cmbTipoIdent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoIdent.Name = "cmbTipoIdent";
            this.cmbTipoIdent.Size = new System.Drawing.Size(287, 24);
            this.cmbTipoIdent.TabIndex = 72;
            this.cmbTipoIdent.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIdent_SelectedIndexChanged);
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPuerto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPuerto.Location = new System.Drawing.Point(7, 37);
            this.lblPuerto.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(44, 16);
            this.lblPuerto.TabIndex = 71;
            this.lblPuerto.Text = "Puerto";
            // 
            // txtRom
            // 
            this.txtRom.BackColor = System.Drawing.Color.White;
            this.txtRom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRom.Location = new System.Drawing.Point(201, 35);
            this.txtRom.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtRom.Name = "txtRom";
            this.txtRom.Size = new System.Drawing.Size(129, 20);
            this.txtRom.TabIndex = 11;
            this.txtRom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRom
            // 
            this.lblRom.AutoSize = true;
            this.lblRom.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblRom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRom.Location = new System.Drawing.Point(147, 36);
            this.lblRom.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblRom.Name = "lblRom";
            this.lblRom.Size = new System.Drawing.Size(50, 16);
            this.lblRom.TabIndex = 68;
            this.lblRom.Text = "Número";
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(60, 33);
            this.cmbPuerto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(75, 24);
            this.cmbPuerto.TabIndex = 10;
           // this.cmbPuerto.SelectedIndexChanged += new System.EventHandler(this.cmbPuerto_SelectedIndexChanged);
            // 
            // btnLeerChip
            // 
            this.btnLeerChip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnLeerChip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerChip.Location = new System.Drawing.Point(336, 34);
            this.btnLeerChip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLeerChip.Name = "btnLeerChip";
            this.btnLeerChip.Size = new System.Drawing.Size(46, 24);
            this.btnLeerChip.TabIndex = 12;
            this.btnLeerChip.Text = "...";
            this.btnLeerChip.UseVisualStyleBackColor = false;
            this.btnLeerChip.Click += new System.EventHandler(this.btnLeerChip_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNuevo,
            this.mnuGuardar,
            this.mnuCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(4, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(121, 40);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(35, 36);
            this.mnuNuevo.Text = "Nuevo";
            this.mnuNuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // mnuGuardar
            // 
            this.mnuGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuGuardar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.mnuGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuGuardar.Name = "mnuGuardar";
            this.mnuGuardar.Size = new System.Drawing.Size(35, 36);
            this.mnuGuardar.Text = "toolStripButton1";
            this.mnuGuardar.ToolTipText = "Guardar";
            this.mnuGuardar.Click += new System.EventHandler(this.mnuGuardar_Click);
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
            // Popup
            // 
            this.Popup.BodyColor = System.Drawing.Color.SteelBlue;
            this.Popup.CloseButton = false;
            this.Popup.ContentColor = System.Drawing.Color.White;
            this.Popup.ContentFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Popup.ContentText = null;
            this.Popup.HeaderColor = System.Drawing.Color.SteelBlue;
            this.Popup.Image = null;
            this.Popup.ImagePosition = new System.Drawing.Point(12, 21);
            this.Popup.ImageSize = new System.Drawing.Size(32, 32);
            this.Popup.OptionsMenu = null;
            this.Popup.ShowDelay = 1000;
            this.Popup.ShowGrip = false;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(19, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(414, 384);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(89, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 27);
            this.label7.TabIndex = 55;
            this.label7.Text = "IDENTIFICADOR EMPLEADO";
            // 
            // IdentificadorEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IdentificadorEmpleado";
            this.Size = new System.Drawing.Size(451, 450);
            this.Load += new System.EventHandler(this.IdentificadorEmpleado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentificador)).EndInit();
            this.pnlChip.ResumeLayout(false);
            this.pnlChip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlOcxChip)).EndInit();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private AxGrabacionTmex.AxITmex ctrlOcxChip;
        private System.Windows.Forms.Panel pnlChip;
        private System.Windows.Forms.Label lblPuerto;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.TextBox txtRom;
        private System.Windows.Forms.Label lblRom;
        private System.Windows.Forms.Button btnLeerChip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoIdent;
        private System.Windows.Forms.DataGridView dgvIdentificador;
        private System.Windows.Forms.Label lblIdEmpleado;
        internal PopupNotifier Popup;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Activo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}
