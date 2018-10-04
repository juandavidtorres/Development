namespace gasolutions.UInterface
{
    partial class InactivarChip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Popup = new PopupNotifier();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.grdChips = new System.Windows.Forms.DataGridView();
            this.IdIdentificadorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RomGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacaGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoGrilla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.radioRom = new System.Windows.Forms.RadioButton();
            this.radioPlaca = new System.Windows.Forms.RadioButton();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtRom = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChips)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox2);
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Location = new System.Drawing.Point(6, 19);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(697, 309);
            this.pnlPrincipal.TabIndex = 51;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlDetalle);
            this.groupBox2.Location = new System.Drawing.Point(4, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 265);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.btnBuscar);
            this.pnlDetalle.Controls.Add(this.grdChips);
            this.pnlDetalle.Controls.Add(this.radioRom);
            this.pnlDetalle.Controls.Add(this.radioPlaca);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.txtRom);
            this.pnlDetalle.Location = new System.Drawing.Point(11, 15);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(673, 239);
            this.pnlDetalle.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnBuscar.Location = new System.Drawing.Point(588, 18);
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
            this.RomGrilla,
            this.PlacaGrilla,
            this.EstadoGrilla});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdChips.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdChips.Location = new System.Drawing.Point(6, 63);
            this.grdChips.MultiSelect = false;
            this.grdChips.Name = "grdChips";
            this.grdChips.RowHeadersVisible = false;
            this.grdChips.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdChips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChips.Size = new System.Drawing.Size(657, 173);
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
            // RomGrilla
            // 
            this.RomGrilla.DataPropertyName = "Rom";
            this.RomGrilla.HeaderText = "ROM";
            this.RomGrilla.MaxInputLength = 50;
            this.RomGrilla.Name = "RomGrilla";
            this.RomGrilla.ReadOnly = true;
            this.RomGrilla.Width = 57;
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
            this.EstadoGrilla.Width = 46;
            // 
            // radioRom
            // 
            this.radioRom.AutoSize = true;
            this.radioRom.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioRom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.radioRom.Location = new System.Drawing.Point(305, 31);
            this.radioRom.Name = "radioRom";
            this.radioRom.Size = new System.Drawing.Size(49, 20);
            this.radioRom.TabIndex = 3;
            this.radioRom.Text = "Rom";
            this.radioRom.UseVisualStyleBackColor = true;
            // 
            // radioPlaca
            // 
            this.radioPlaca.AutoSize = true;
            this.radioPlaca.Checked = true;
            this.radioPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.radioPlaca.Location = new System.Drawing.Point(6, 31);
            this.radioPlaca.Name = "radioPlaca";
            this.radioPlaca.Size = new System.Drawing.Size(54, 20);
            this.radioPlaca.TabIndex = 1;
            this.radioPlaca.TabStop = true;
            this.radioPlaca.Text = "Placa";
            this.radioPlaca.UseVisualStyleBackColor = true;
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(68, 31);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(219, 21);
            this.txtPlaca.TabIndex = 2;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(662, 18);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRom
            // 
            this.txtRom.BackColor = System.Drawing.Color.White;
            this.txtRom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRom.Location = new System.Drawing.Point(360, 31);
            this.txtRom.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtRom.Name = "txtRom";
            this.txtRom.Size = new System.Drawing.Size(222, 21);
            this.txtRom.TabIndex = 4;
            this.txtRom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(611, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(48, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(36, 36);
            this.mnuCerrar.Text = "Cerrar";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(20, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 338);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(293, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 27);
            this.label7.TabIndex = 55;
            this.label7.Text = "INACTIVAR CHIP";
            // 
            // InactivarChip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 407);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(183, 160);
            this.Name = "InactivarChip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.InactivarChip_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChips)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal PopupNotifier Popup;
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
        private System.Windows.Forms.TextBox txtRom;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdIdentificadorGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn RomGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacaGrilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EstadoGrilla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
    }
}