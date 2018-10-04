namespace PosStation.gsResoluciones
{
    partial class gsResolucion
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuNuevo = new System.Windows.Forms.ToolStripButton();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdResoluciones = new System.Windows.Forms.DataGridView();
            this.IdConsecutivoGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroResolucionGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrefijoGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroInicialGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroFinalGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaExpedicionGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVencimientoGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroResGranContribuyenteGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaResGranContribuyenteGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroResAutoretenedorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaResAutoretenedorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.dtFechaResolucionAutoretenedor = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNroResolucionAutoretenedor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtFechaResolucionGContribuyente = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNroResolucionGContribuyente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFechaExpedicion = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNroInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroFinal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroResolucion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrefijo = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.Popup = new PopupNotifier();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResoluciones)).BeginInit();
            this.pnlDetalle.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            this.toolStrip1.Location = new System.Drawing.Point(565, 20);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(121, 40);
            this.toolStrip1.TabIndex = 87;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.grdResoluciones);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(6, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 314);
            this.panel1.TabIndex = 86;
            // 
            // grdResoluciones
            // 
            this.grdResoluciones.AllowUserToAddRows = false;
            this.grdResoluciones.AllowUserToResizeRows = false;
            this.grdResoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdResoluciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdResoluciones.BackgroundColor = System.Drawing.Color.White;
            this.grdResoluciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdResoluciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdResoluciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdConsecutivoGrilla,
            this.NroResolucionGrilla,
            this.PrefijoGrilla,
            this.NroInicialGrilla,
            this.NroFinalGrilla,
            this.FechaExpedicionGrilla,
            this.FechaVencimientoGrilla,
            this.NroResGranContribuyenteGrilla,
            this.FechaResGranContribuyenteGrilla,
            this.NroResAutoretenedorGrilla,
            this.FechaResAutoretenedorGrilla});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResoluciones.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdResoluciones.Location = new System.Drawing.Point(4, 27);
            this.grdResoluciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdResoluciones.MultiSelect = false;
            this.grdResoluciones.Name = "grdResoluciones";
            this.grdResoluciones.ReadOnly = true;
            this.grdResoluciones.RowHeadersVisible = false;
            this.grdResoluciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdResoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResoluciones.Size = new System.Drawing.Size(659, 281);
            this.grdResoluciones.TabIndex = 11;
            this.grdResoluciones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResoluciones_CellDoubleClick);
            this.grdResoluciones.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdResoluciones_UserDeletingRow);
            // 
            // IdConsecutivoGrilla
            // 
            this.IdConsecutivoGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdConsecutivoGrilla.DataPropertyName = "IdConsecutivo";
            this.IdConsecutivoGrilla.HeaderText = "Id Consecutivo";
            this.IdConsecutivoGrilla.MinimumWidth = 20;
            this.IdConsecutivoGrilla.Name = "IdConsecutivoGrilla";
            this.IdConsecutivoGrilla.ReadOnly = true;
            this.IdConsecutivoGrilla.Visible = false;
            this.IdConsecutivoGrilla.Width = 20;
            // 
            // NroResolucionGrilla
            // 
            this.NroResolucionGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NroResolucionGrilla.DataPropertyName = "NroResolucion";
            this.NroResolucionGrilla.HeaderText = "# Resolución";
            this.NroResolucionGrilla.MinimumWidth = 20;
            this.NroResolucionGrilla.Name = "NroResolucionGrilla";
            this.NroResolucionGrilla.ReadOnly = true;
            // 
            // PrefijoGrilla
            // 
            this.PrefijoGrilla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrefijoGrilla.DataPropertyName = "Prefijo";
            this.PrefijoGrilla.HeaderText = "Prefijo";
            this.PrefijoGrilla.Name = "PrefijoGrilla";
            this.PrefijoGrilla.ReadOnly = true;
            // 
            // NroInicialGrilla
            // 
            this.NroInicialGrilla.DataPropertyName = "NroInicial";
            this.NroInicialGrilla.HeaderText = "Número Inicial";
            this.NroInicialGrilla.Name = "NroInicialGrilla";
            this.NroInicialGrilla.ReadOnly = true;
            this.NroInicialGrilla.Width = 104;
            // 
            // NroFinalGrilla
            // 
            this.NroFinalGrilla.DataPropertyName = "NroFinal";
            this.NroFinalGrilla.HeaderText = "Número Final";
            this.NroFinalGrilla.Name = "NroFinalGrilla";
            this.NroFinalGrilla.ReadOnly = true;
            this.NroFinalGrilla.Width = 97;
            // 
            // FechaExpedicionGrilla
            // 
            this.FechaExpedicionGrilla.DataPropertyName = "FechaExpedicion";
            this.FechaExpedicionGrilla.HeaderText = "Fecha de Expedición";
            this.FechaExpedicionGrilla.Name = "FechaExpedicionGrilla";
            this.FechaExpedicionGrilla.ReadOnly = true;
            this.FechaExpedicionGrilla.Width = 135;
            // 
            // FechaVencimientoGrilla
            // 
            this.FechaVencimientoGrilla.DataPropertyName = "FechaVencimiento";
            this.FechaVencimientoGrilla.HeaderText = "Fecha de Vencimiento";
            this.FechaVencimientoGrilla.Name = "FechaVencimientoGrilla";
            this.FechaVencimientoGrilla.ReadOnly = true;
            this.FechaVencimientoGrilla.Width = 143;
            // 
            // NroResGranContribuyenteGrilla
            // 
            this.NroResGranContribuyenteGrilla.DataPropertyName = "NroResGranContribuyente";
            this.NroResGranContribuyenteGrilla.HeaderText = "# Resolución Gran Contribuyente";
            this.NroResGranContribuyenteGrilla.Name = "NroResGranContribuyenteGrilla";
            this.NroResGranContribuyenteGrilla.ReadOnly = true;
            this.NroResGranContribuyenteGrilla.Width = 197;
            // 
            // FechaResGranContribuyenteGrilla
            // 
            this.FechaResGranContribuyenteGrilla.DataPropertyName = "FechaResGranContribuyente";
            this.FechaResGranContribuyenteGrilla.HeaderText = "Fecha Resolución Gran Contribuyente";
            this.FechaResGranContribuyenteGrilla.Name = "FechaResGranContribuyenteGrilla";
            this.FechaResGranContribuyenteGrilla.ReadOnly = true;
            this.FechaResGranContribuyenteGrilla.Width = 221;
            // 
            // NroResAutoretenedorGrilla
            // 
            this.NroResAutoretenedorGrilla.DataPropertyName = "NroResAutoretenedor";
            this.NroResAutoretenedorGrilla.HeaderText = "# Resolución Autoretenedor";
            this.NroResAutoretenedorGrilla.Name = "NroResAutoretenedorGrilla";
            this.NroResAutoretenedorGrilla.ReadOnly = true;
            this.NroResAutoretenedorGrilla.Width = 171;
            // 
            // FechaResAutoretenedorGrilla
            // 
            this.FechaResAutoretenedorGrilla.DataPropertyName = "FechaResAutoretenedor";
            this.FechaResAutoretenedorGrilla.HeaderText = "Fecha Resolución Autoretenedor";
            this.FechaResAutoretenedorGrilla.Name = "FechaResAutoretenedorGrilla";
            this.FechaResAutoretenedorGrilla.ReadOnly = true;
            this.FechaResAutoretenedorGrilla.Width = 195;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(62, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(546, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "CONSULTA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.BackColor = System.Drawing.Color.White;
            this.pnlDetalle.Controls.Add(this.dtFechaResolucionAutoretenedor);
            this.pnlDetalle.Controls.Add(this.label10);
            this.pnlDetalle.Controls.Add(this.txtNroResolucionAutoretenedor);
            this.pnlDetalle.Controls.Add(this.label11);
            this.pnlDetalle.Controls.Add(this.dtFechaResolucionGContribuyente);
            this.pnlDetalle.Controls.Add(this.label9);
            this.pnlDetalle.Controls.Add(this.txtNroResolucionGContribuyente);
            this.pnlDetalle.Controls.Add(this.label6);
            this.pnlDetalle.Controls.Add(this.dtFechaVencimiento);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Controls.Add(this.dtFechaExpedicion);
            this.pnlDetalle.Controls.Add(this.label7);
            this.pnlDetalle.Controls.Add(this.txtNroInicial);
            this.pnlDetalle.Controls.Add(this.label2);
            this.pnlDetalle.Controls.Add(this.txtNroFinal);
            this.pnlDetalle.Controls.Add(this.label4);
            this.pnlDetalle.Controls.Add(this.txtNroResolucion);
            this.pnlDetalle.Controls.Add(this.label1);
            this.pnlDetalle.Controls.Add(this.txtPrefijo);
            this.pnlDetalle.Controls.Add(this.lblNombreCompleto);
            this.pnlDetalle.Controls.Add(this.label5);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Location = new System.Drawing.Point(5, 17);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(668, 193);
            this.pnlDetalle.TabIndex = 85;
            // 
            // dtFechaResolucionAutoretenedor
            // 
            this.dtFechaResolucionAutoretenedor.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaResolucionAutoretenedor.Location = new System.Drawing.Point(461, 134);
            this.dtFechaResolucionAutoretenedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFechaResolucionAutoretenedor.Name = "dtFechaResolucionAutoretenedor";
            this.dtFechaResolucionAutoretenedor.Size = new System.Drawing.Size(176, 20);
            this.dtFechaResolucionAutoretenedor.TabIndex = 112;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(332, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 111;
            this.label10.Text = "Fecha Resolución Autoretenedor";
            // 
            // txtNroResolucionAutoretenedor
            // 
            this.txtNroResolucionAutoretenedor.BackColor = System.Drawing.Color.White;
            this.txtNroResolucionAutoretenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroResolucionAutoretenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroResolucionAutoretenedor.Location = new System.Drawing.Point(129, 134);
            this.txtNroResolucionAutoretenedor.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtNroResolucionAutoretenedor.Name = "txtNroResolucionAutoretenedor";
            this.txtNroResolucionAutoretenedor.Size = new System.Drawing.Size(176, 21);
            this.txtNroResolucionAutoretenedor.TabIndex = 109;
            this.txtNroResolucionAutoretenedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(13, 136);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 110;
            this.label11.Text = "# Resolución Autoretenedor";
            // 
            // dtFechaResolucionGContribuyente
            // 
            this.dtFechaResolucionGContribuyente.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaResolucionGContribuyente.Location = new System.Drawing.Point(461, 108);
            this.dtFechaResolucionGContribuyente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFechaResolucionGContribuyente.Name = "dtFechaResolucionGContribuyente";
            this.dtFechaResolucionGContribuyente.Size = new System.Drawing.Size(176, 20);
            this.dtFechaResolucionGContribuyente.TabIndex = 108;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(332, 111);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 107;
            this.label9.Text = "Fecha Resolución Gran Contribuyente";
            // 
            // txtNroResolucionGContribuyente
            // 
            this.txtNroResolucionGContribuyente.BackColor = System.Drawing.Color.White;
            this.txtNroResolucionGContribuyente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroResolucionGContribuyente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroResolucionGContribuyente.Location = new System.Drawing.Point(129, 108);
            this.txtNroResolucionGContribuyente.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtNroResolucionGContribuyente.Name = "txtNroResolucionGContribuyente";
            this.txtNroResolucionGContribuyente.Size = new System.Drawing.Size(176, 21);
            this.txtNroResolucionGContribuyente.TabIndex = 103;
            this.txtNroResolucionGContribuyente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(13, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 106;
            this.label6.Text = "# Resolución Gran Contribuyente";
            // 
            // dtFechaVencimiento
            // 
            this.dtFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVencimiento.Location = new System.Drawing.Point(461, 83);
            this.dtFechaVencimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFechaVencimiento.Name = "dtFechaVencimiento";
            this.dtFechaVencimiento.Size = new System.Drawing.Size(176, 20);
            this.dtFechaVencimiento.TabIndex = 102;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(332, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 101;
            this.label8.Text = "*Fecha Vencimiento";
            // 
            // dtFechaExpedicion
            // 
            this.dtFechaExpedicion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaExpedicion.Location = new System.Drawing.Point(129, 83);
            this.dtFechaExpedicion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFechaExpedicion.Name = "dtFechaExpedicion";
            this.dtFechaExpedicion.Size = new System.Drawing.Size(176, 20);
            this.dtFechaExpedicion.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(15, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 98;
            this.label7.Text = "*Fecha Expedición";
            // 
            // txtNroInicial
            // 
            this.txtNroInicial.BackColor = System.Drawing.Color.White;
            this.txtNroInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroInicial.Location = new System.Drawing.Point(129, 58);
            this.txtNroInicial.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtNroInicial.Name = "txtNroInicial";
            this.txtNroInicial.Size = new System.Drawing.Size(176, 21);
            this.txtNroInicial.TabIndex = 92;
            this.txtNroInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 95;
            this.label2.Text = "*Número Inicial";
            // 
            // txtNroFinal
            // 
            this.txtNroFinal.BackColor = System.Drawing.Color.White;
            this.txtNroFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroFinal.Location = new System.Drawing.Point(461, 58);
            this.txtNroFinal.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtNroFinal.Name = "txtNroFinal";
            this.txtNroFinal.Size = new System.Drawing.Size(176, 21);
            this.txtNroFinal.TabIndex = 93;
            this.txtNroFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(334, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 94;
            this.label4.Text = "*Número Final";
            // 
            // txtNroResolucion
            // 
            this.txtNroResolucion.BackColor = System.Drawing.Color.White;
            this.txtNroResolucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroResolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroResolucion.Location = new System.Drawing.Point(129, 34);
            this.txtNroResolucion.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtNroResolucion.Name = "txtNroResolucion";
            this.txtNroResolucion.Size = new System.Drawing.Size(176, 21);
            this.txtNroResolucion.TabIndex = 1;
            this.txtNroResolucion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 91;
            this.label1.Text = "*# Resolución";
            // 
            // txtPrefijo
            // 
            this.txtPrefijo.BackColor = System.Drawing.Color.White;
            this.txtPrefijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrefijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefijo.Location = new System.Drawing.Point(461, 34);
            this.txtPrefijo.Margin = new System.Windows.Forms.Padding(2, 4, 3, 4);
            this.txtPrefijo.Name = "txtPrefijo";
            this.txtPrefijo.Size = new System.Drawing.Size(176, 21);
            this.txtPrefijo.TabIndex = 2;
            this.txtPrefijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblNombreCompleto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreCompleto.Location = new System.Drawing.Point(334, 37);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(49, 16);
            this.lblNombreCompleto.TabIndex = 86;
            this.lblNombreCompleto.Text = "*Prefijo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(15, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 77;
            this.label5.Text = "(*) Campos obligatorios";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(4, 1);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(662, 22);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "DATOS";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox1.Controls.Add(this.pnlDetalle);
            this.groupBox1.Location = new System.Drawing.Point(15, 63);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(679, 216);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(15, 285);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(679, 347);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.toolStrip1);
            this.groupBox3.Location = new System.Drawing.Point(21, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(712, 652);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label13.Location = new System.Drawing.Point(326, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 27);
            this.label13.TabIndex = 91;
            this.label13.Text = "RESOLUCIÓN";
            // 
            // gsResolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsResolucion";
            this.Size = new System.Drawing.Size(754, 718);
            this.Load += new System.EventHandler(this.gsResolucion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResoluciones)).EndInit();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuNuevo;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdResoluciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.TextBox txtNroResolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrefijo;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtNroInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaVencimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFechaExpedicion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFechaResolucionAutoretenedor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNroResolucionAutoretenedor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtFechaResolucionGContribuyente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNroResolucionGContribuyente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConsecutivoGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroResolucionGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrefijoGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroInicialGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroFinalGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaExpedicionGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVencimientoGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroResGranContribuyenteGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaResGranContribuyenteGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroResAutoretenedorGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaResAutoretenedorGrilla;
        internal PopupNotifier Popup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
    }
}
