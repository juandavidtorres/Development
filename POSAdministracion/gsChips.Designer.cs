namespace PosStation.gsChips
{
    partial class gsChip
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoIdentificador = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grdChips = new System.Windows.Forms.DataGridView();
            this.IdIdentificadorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentificadorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoIdentificadorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoIdentificadorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacaGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoGrilla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.radioRom = new System.Windows.Forms.RadioButton();
            this.radioPlaca = new System.Windows.Forms.RadioButton();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuLimpiar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.Popup = new PopupNotifier();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChips)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Location = new System.Drawing.Point(6, 16);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(715, 458);
            this.pnlPrincipal.TabIndex = 52;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlDetalle);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(700, 402);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.label3);
            this.pnlDetalle.Controls.Add(this.cmbTipoIdentificador);
            this.pnlDetalle.Controls.Add(this.btnBuscar);
            this.pnlDetalle.Controls.Add(this.grdChips);
            this.pnlDetalle.Controls.Add(this.radioRom);
            this.pnlDetalle.Controls.Add(this.radioPlaca);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.txtIdentificador);
            this.pnlDetalle.Location = new System.Drawing.Point(15, 17);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(673, 370);
            this.pnlDetalle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(10, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "Tipo Identificación";
            // 
            // cmbTipoIdentificador
            // 
            this.cmbTipoIdentificador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentificador.FormattingEnabled = true;
            this.cmbTipoIdentificador.Location = new System.Drawing.Point(121, 71);
            this.cmbTipoIdentificador.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoIdentificador.Name = "cmbTipoIdentificador";
            this.cmbTipoIdentificador.Size = new System.Drawing.Size(247, 24);
            this.cmbTipoIdentificador.TabIndex = 76;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnBuscar.Location = new System.Drawing.Point(595, 31);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grdChips
            // 
            this.grdChips.AllowUserToAddRows = false;
            this.grdChips.AllowUserToDeleteRows = false;
            this.grdChips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdChips.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdChips.BackgroundColor = System.Drawing.Color.White;
            this.grdChips.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdChips.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdChips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChips.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdIdentificadorGrilla,
            this.IdentificadorGrilla,
            this.TipoIdentificadorGrilla,
            this.IdTipoIdentificadorGrilla,
            this.PlacaGrilla,
            this.EstadoGrilla});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdChips.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdChips.Location = new System.Drawing.Point(6, 118);
            this.grdChips.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdChips.MultiSelect = false;
            this.grdChips.Name = "grdChips";
            this.grdChips.RowHeadersVisible = false;
            this.grdChips.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdChips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChips.Size = new System.Drawing.Size(657, 246);
            this.grdChips.TabIndex = 6;
            this.grdChips.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdChips_CellValidating);
            this.grdChips.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdChips_CellValueChanged);
            // 
            // IdIdentificadorGrilla
            // 
            this.IdIdentificadorGrilla.DataPropertyName = "IdIdentificador";
            this.IdIdentificadorGrilla.HeaderText = "IdIdentificador";
            this.IdIdentificadorGrilla.Name = "IdIdentificadorGrilla";
            this.IdIdentificadorGrilla.ReadOnly = true;
            this.IdIdentificadorGrilla.Visible = false;
            this.IdIdentificadorGrilla.Width = 80;
            // 
            // IdentificadorGrilla
            // 
            this.IdentificadorGrilla.DataPropertyName = "Identificador";
            this.IdentificadorGrilla.HeaderText = "Identificador";
            this.IdentificadorGrilla.MaxInputLength = 50;
            this.IdentificadorGrilla.Name = "IdentificadorGrilla";
            this.IdentificadorGrilla.ReadOnly = true;
            this.IdentificadorGrilla.Width = 99;
            // 
            // TipoIdentificadorGrilla
            // 
            this.TipoIdentificadorGrilla.DataPropertyName = "TipoIdentificador";
            this.TipoIdentificadorGrilla.HeaderText = "Tipo de Identificador";
            this.TipoIdentificadorGrilla.Name = "TipoIdentificadorGrilla";
            this.TipoIdentificadorGrilla.ReadOnly = true;
            this.TipoIdentificadorGrilla.Width = 126;
            // 
            // IdTipoIdentificadorGrilla
            // 
            this.IdTipoIdentificadorGrilla.DataPropertyName = "IdTipoIdentificador";
            this.IdTipoIdentificadorGrilla.HeaderText = "IdTipoIdentificador";
            this.IdTipoIdentificadorGrilla.Name = "IdTipoIdentificadorGrilla";
            this.IdTipoIdentificadorGrilla.ReadOnly = true;
            this.IdTipoIdentificadorGrilla.Visible = false;
            this.IdTipoIdentificadorGrilla.Width = 120;
            // 
            // PlacaGrilla
            // 
            this.PlacaGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PlacaGrilla.DataPropertyName = "Placa";
            this.PlacaGrilla.FillWeight = 85F;
            this.PlacaGrilla.HeaderText = "Placa";
            this.PlacaGrilla.MaxInputLength = 50;
            this.PlacaGrilla.MinimumWidth = 85;
            this.PlacaGrilla.Name = "PlacaGrilla";
            this.PlacaGrilla.Width = 85;
            // 
            // EstadoGrilla
            // 
            this.EstadoGrilla.DataPropertyName = "EsActivo";
            this.EstadoGrilla.FalseValue = "False";
            this.EstadoGrilla.HeaderText = "Estado";
            this.EstadoGrilla.Name = "EstadoGrilla";
            this.EstadoGrilla.TrueValue = "True";
            this.EstadoGrilla.Width = 48;
            // 
            // radioRom
            // 
            this.radioRom.AutoSize = true;
            this.radioRom.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.radioRom.Location = new System.Drawing.Point(283, 38);
            this.radioRom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioRom.Name = "radioRom";
            this.radioRom.Size = new System.Drawing.Size(92, 20);
            this.radioRom.TabIndex = 3;
            this.radioRom.Text = "Identificador";
            this.radioRom.UseVisualStyleBackColor = true;
            // 
            // radioPlaca
            // 
            this.radioPlaca.AutoSize = true;
            this.radioPlaca.Checked = true;
            this.radioPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.radioPlaca.Location = new System.Drawing.Point(13, 38);
            this.radioPlaca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioPlaca.Name = "radioPlaca";
            this.radioPlaca.Size = new System.Drawing.Size(52, 20);
            this.radioPlaca.TabIndex = 1;
            this.radioPlaca.TabStop = true;
            this.radioPlaca.Text = "Placa";
            this.radioPlaca.UseVisualStyleBackColor = true;
            this.radioPlaca.CheckedChanged += new System.EventHandler(this.radioPlaca_CheckedChanged);
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(75, 38);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(176, 21);
            this.txtPlaca.TabIndex = 2;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(662, 22);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.BackColor = System.Drawing.Color.White;
            this.txtIdentificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificador.Location = new System.Drawing.Point(412, 38);
            this.txtIdentificador.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(177, 21);
            this.txtIdentificador.TabIndex = 4;
            this.txtIdentificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLimpiar,
            this.mnuCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(612, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(82, 40);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuLimpiar
            // 
            this.mnuLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuLimpiar.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuLimpiar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuLimpiar.Name = "mnuLimpiar";
            this.mnuLimpiar.Size = new System.Drawing.Size(35, 36);
            this.mnuLimpiar.Text = "Limpiar";
            this.mnuLimpiar.Click += new System.EventHandler(this.mnuLimpiar_Click);
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
            this.Popup.ShowGrip = false;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlPrincipal);
            this.groupBox2.Location = new System.Drawing.Point(14, 55);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(738, 490);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(349, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 27);
            this.label4.TabIndex = 54;
            this.label4.Text = "CHIPS";
            // 
            // gsChips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsChips";
            this.Size = new System.Drawing.Size(774, 565);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChips)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView grdChips;
        private System.Windows.Forms.RadioButton radioRom;
        private System.Windows.Forms.RadioButton radioPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtIdentificador;
        internal PopupNotifier Popup;
        private System.Windows.Forms.ToolStripButton mnuLimpiar;
        private System.Windows.Forms.ComboBox cmbTipoIdentificador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdIdentificadorGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentificadorGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoIdentificadorGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoIdentificadorGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacaGrilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EstadoGrilla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
    }
}
