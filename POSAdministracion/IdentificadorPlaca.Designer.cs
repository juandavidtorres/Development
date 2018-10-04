namespace gasolutions.UInterface
{
    partial class IdentificadorPlaca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPlacas = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCredito_ = new System.Windows.Forms.ToolStripButton();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuplaca = new System.Windows.Forms.ToolStripButton();
            this.Popup = new PopupNotifier();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.brnsalir = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.ttpLimpiar = new System.Windows.Forms.ToolTip(this.components);
            this.ttpcerrar = new System.Windows.Forms.ToolTip(this.components);
            this.ttpBuscar = new System.Windows.Forms.ToolTip(this.components);
            this.ttpGuardar = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(136, 10);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(179, 40);
            this.miniToolStrip.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlDetalle);
            this.groupBox3.Location = new System.Drawing.Point(12, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(445, 108);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.btnConsulta);
            this.pnlDetalle.Controls.Add(this.txtPlaca);
            this.pnlDetalle.Controls.Add(this.btnInsertar);
            this.pnlDetalle.Controls.Add(this.txtIdentificador);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Controls.Add(this.lblPlaca);
            this.pnlDetalle.Controls.Add(this.lblTipo);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 12);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(427, 90);
            this.pnlDetalle.TabIndex = 4;
            this.pnlDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDetalle_Paint);
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.White;
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(134, 53);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(176, 21);
            this.txtPlaca.TabIndex = 50;
            this.txtPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.BackColor = System.Drawing.Color.White;
            this.txtIdentificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificador.Location = new System.Drawing.Point(134, 20);
            this.txtIdentificador.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(176, 21);
            this.txtIdentificador.TabIndex = 1;
            this.txtIdentificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdentificador.TextChanged += new System.EventHandler(this.txtIdentificador_TextChanged);
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(3, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(418, 18);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPlaca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPlaca.Location = new System.Drawing.Point(17, 24);
            this.lblPlaca.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(74, 16);
            this.lblPlaca.TabIndex = 49;
            this.lblPlaca.Text = "Identificador";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipo.Location = new System.Drawing.Point(16, 58);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 16);
            this.lblTipo.TabIndex = 42;
            this.lblTipo.Text = "Placa";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.btnLimpiar);
            this.pnlPrincipal.Controls.Add(this.brnsalir);
            this.pnlPrincipal.Controls.Add(this.label7);
            this.pnlPrincipal.Controls.Add(this.groupBox4);
            this.pnlPrincipal.Controls.Add(this.groupBox3);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(473, 310);
            this.pnlPrincipal.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(110, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 27);
            this.label7.TabIndex = 79;
            this.label7.Text = "IDENTIFICADOR PLACA";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvPlacas);
            this.groupBox4.Location = new System.Drawing.Point(17, 149);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(440, 142);
            this.groupBox4.TabIndex = 78;
            this.groupBox4.TabStop = false;
            // 
            // dgvPlacas
            // 
            this.dgvPlacas.AllowUserToAddRows = false;
            this.dgvPlacas.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPlacas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlacas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlacas.Location = new System.Drawing.Point(3, 16);
            this.dgvPlacas.Name = "dgvPlacas";
            this.dgvPlacas.Size = new System.Drawing.Size(434, 123);
            this.dgvPlacas.TabIndex = 0;
            this.dgvPlacas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlacas_CellContentClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuardar,
            this.mnuCredito_,
            this.mnuSalir,
            this.mnuNuevo,
            this.mnuplaca});
            this.toolStrip1.Location = new System.Drawing.Point(503, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(179, 40);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuGuardar
            // 
            this.mnuGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuGuardar.Name = "mnuGuardar";
            this.mnuGuardar.Size = new System.Drawing.Size(23, 36);
            this.mnuGuardar.Text = "toolStripButton1";
            this.mnuGuardar.ToolTipText = "Guardar";
            // 
            // mnuCredito_
            // 
            this.mnuCredito_.AutoSize = false;
            this.mnuCredito_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuCredito_.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuCredito_.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCredito_.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCredito_.Name = "mnuCredito_";
            this.mnuCredito_.Size = new System.Drawing.Size(35, 35);
            this.mnuCredito_.Text = "toolStripButton1";
            this.mnuCredito_.ToolTipText = "Créditos Asociados";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Margin = new System.Windows.Forms.Padding(2);
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(23, 36);
            this.mnuSalir.Text = "Cerrar";
            // 
            // mnuNuevo
            // 
            this.mnuNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.mnuNuevo.Name = "mnuNuevo";
            this.mnuNuevo.Size = new System.Drawing.Size(23, 36);
            this.mnuNuevo.Text = "Nuevo";
            // 
            // mnuplaca
            // 
            this.mnuplaca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuplaca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuplaca.Name = "mnuplaca";
            this.mnuplaca.Size = new System.Drawing.Size(23, 37);
            this.mnuplaca.Text = "toolStripButton1";
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
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Image = global::gasolutions.UInterface.Properties.Resources.Limpiar__3_;
            this.btnLimpiar.Location = new System.Drawing.Point(383, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(35, 33);
            this.btnLimpiar.TabIndex = 81;
            this.ttpLimpiar.SetToolTip(this.btnLimpiar, "Limpiar");
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // brnsalir
            // 
            this.brnsalir.AutoSize = true;
            this.brnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.brnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnsalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel__2_;
            this.brnsalir.Location = new System.Drawing.Point(421, 2);
            this.brnsalir.Name = "brnsalir";
            this.brnsalir.Size = new System.Drawing.Size(35, 33);
            this.brnsalir.TabIndex = 80;
            this.ttpcerrar.SetToolTip(this.brnsalir, "cerrar");
            this.brnsalir.UseVisualStyleBackColor = false;
            this.brnsalir.Click += new System.EventHandler(this.brnsalir_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.AutoSize = true;
            this.btnConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Image = global::gasolutions.UInterface.Properties.Resources.Bucar16;
            this.btnConsulta.Location = new System.Drawing.Point(326, 6);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(33, 33);
            this.btnConsulta.TabIndex = 51;
            this.ttpBuscar.SetToolTip(this.btnConsulta, "Buscar");
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnInsertar.Location = new System.Drawing.Point(326, 43);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(33, 33);
            this.btnInsertar.TabIndex = 12;
            this.ttpGuardar.SetToolTip(this.btnInsertar, "Guardar");
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // IdentificadorPlaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 310);
            this.ControlBox = false;
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IdentificadorPlaca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IdentificadorPlaca";
            this.groupBox3.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCredito_;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuplaca;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvPlacas;
        internal PopupNotifier Popup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Button brnsalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ToolTip ttpLimpiar;
        private System.Windows.Forms.ToolTip ttpBuscar;
        private System.Windows.Forms.ToolTip ttpGuardar;
        private System.Windows.Forms.ToolTip ttpcerrar;

    }
}