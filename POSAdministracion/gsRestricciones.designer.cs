namespace gsRestricciones
{
    partial class gsRestricciones
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdVehiculo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuBuscar = new System.Windows.Forms.ToolStripButton();
            this.mnuSalir = new System.Windows.Forms.ToolStripButton();
            this.tabRestricciones = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtgBasica = new System.Windows.Forms.DataGridView();
            this.Tanqueos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRestriccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Galones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolumenSemanal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolumenMensual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgDia = new System.Windows.Forms.DataGridView();
            this.IdDia = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RestriccionDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRestriccionDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dtgHoras = new System.Windows.Forms.DataGridView();
            this.HoraInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RestriccionHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRestriccionHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dtgProducto = new System.Windows.Forms.DataGridView();
            this.IdProducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dtgHoraDia = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RestriccionHDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dhIdDia = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dHoraInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dHoraFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdRestriccionHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabRestricciones.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBasica)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDia)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoras)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoraDia)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.groupBox1);
            this.pnlPrincipal.Controls.Add(this.toolStrip1);
            this.pnlPrincipal.Controls.Add(this.tabRestricciones);
            this.pnlPrincipal.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.pnlPrincipal.Location = new System.Drawing.Point(15, 20);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(789, 645);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblIdVehiculo);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.lblPlaca);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(772, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "<< Datos de la Cuenta >>";
            // 
            // lblIdVehiculo
            // 
            this.lblIdVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIdVehiculo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblIdVehiculo.Location = new System.Drawing.Point(661, 25);
            this.lblIdVehiculo.Name = "lblIdVehiculo";
            this.lblIdVehiculo.Size = new System.Drawing.Size(95, 22);
            this.lblIdVehiculo.TabIndex = 5;
            this.lblIdVehiculo.Visible = false;
            // 
            // lblCliente
            // 
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCliente.Location = new System.Drawing.Point(144, 25);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(512, 22);
            this.lblCliente.TabIndex = 3;
            // 
            // lblPlaca
            // 
            this.lblPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlaca.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblPlaca.Location = new System.Drawing.Point(69, 25);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(69, 22);
            this.lblPlaca.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGuardar,
            this.mnuBuscar,
            this.mnuSalir});
            this.toolStrip1.Location = new System.Drawing.Point(640, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(121, 40);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
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
            this.mnuGuardar.Text = "toolStripButton2";
            this.mnuGuardar.ToolTipText = "Guardar Informacion";
            this.mnuGuardar.Click += new System.EventHandler(this.mnuGuardar_Click);
            // 
            // mnuBuscar
            // 
            this.mnuBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.mnuBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.mnuBuscar.Name = "mnuBuscar";
            this.mnuBuscar.Size = new System.Drawing.Size(35, 36);
            this.mnuBuscar.Text = "toolStripButton4";
            this.mnuBuscar.ToolTipText = "Buscar Informacion";
            this.mnuBuscar.Click += new System.EventHandler(this.mnuBuscar_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuSalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.mnuSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuSalir.Margin = new System.Windows.Forms.Padding(2);
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(36, 36);
            this.mnuSalir.Text = "toolStripButton3";
            this.mnuSalir.ToolTipText = "Salir de la Aplicación";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // tabRestricciones
            // 
            this.tabRestricciones.Controls.Add(this.tabPage1);
            this.tabRestricciones.Controls.Add(this.tabPage2);
            this.tabRestricciones.Controls.Add(this.tabPage3);
            this.tabRestricciones.Controls.Add(this.tabPage4);
            this.tabRestricciones.Controls.Add(this.tabPage5);
            this.tabRestricciones.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRestricciones.Location = new System.Drawing.Point(0, 129);
            this.tabRestricciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabRestricciones.Name = "tabRestricciones";
            this.tabRestricciones.SelectedIndex = 0;
            this.tabRestricciones.Size = new System.Drawing.Size(777, 503);
            this.tabRestricciones.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtgBasica);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(769, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Restriccion Básica";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtgBasica
            // 
            this.dtgBasica.BackgroundColor = System.Drawing.Color.White;
            this.dtgBasica.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgBasica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgBasica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBasica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanqueos,
            this.IdRestriccion,
            this.Galones,
            this.VolumenSemanal,
            this.VolumenMensual,
            this.Estado});
            this.dtgBasica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgBasica.Location = new System.Drawing.Point(3, 4);
            this.dtgBasica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgBasica.Name = "dtgBasica";
            this.dtgBasica.RowHeadersVisible = false;
            this.dtgBasica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgBasica.Size = new System.Drawing.Size(763, 466);
            this.dtgBasica.TabIndex = 3;
            this.dtgBasica.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgBasica_CellFormatting);
            this.dtgBasica.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgBasica_CellValidating);
            this.dtgBasica.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgBasica_DataError);
            this.dtgBasica.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgBasica_UserDeletingRow);
            // 
            // Tanqueos
            // 
            this.Tanqueos.DataPropertyName = "Tanqueos";
            this.Tanqueos.HeaderText = "NoTanqueos";
            this.Tanqueos.Name = "Tanqueos";
            // 
            // IdRestriccion
            // 
            this.IdRestriccion.DataPropertyName = "IdRestriccion";
            this.IdRestriccion.HeaderText = "IdRestriccion";
            this.IdRestriccion.Name = "IdRestriccion";
            this.IdRestriccion.Visible = false;
            // 
            // Galones
            // 
            this.Galones.DataPropertyName = "Galones";
            this.Galones.HeaderText = "Galones";
            this.Galones.Name = "Galones";
            // 
            // VolumenSemanal
            // 
            this.VolumenSemanal.DataPropertyName = "VolumenSemanal";
            this.VolumenSemanal.HeaderText = "VolumenSemanal";
            this.VolumenSemanal.Name = "VolumenSemanal";
            this.VolumenSemanal.Width = 130;
            // 
            // VolumenMensual
            // 
            this.VolumenMensual.DataPropertyName = "VolumenMensual";
            this.VolumenMensual.HeaderText = "VolumenMensual";
            this.VolumenMensual.Name = "VolumenMensual";
            this.VolumenMensual.Width = 130;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgDia);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(769, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Restriccción Día";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgDia
            // 
            this.dtgDia.BackgroundColor = System.Drawing.Color.White;
            this.dtgDia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgDia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDia,
            this.RestriccionDia,
            this.IdRestriccionDia});
            this.dtgDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDia.Location = new System.Drawing.Point(3, 4);
            this.dtgDia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgDia.Name = "dtgDia";
            this.dtgDia.RowHeadersVisible = false;
            this.dtgDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDia.Size = new System.Drawing.Size(763, 466);
            this.dtgDia.TabIndex = 1;
            this.dtgDia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDia_CellContentClick);
            this.dtgDia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgDia_DataError);
            this.dtgDia.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgDia_UserDeletingRow);
            // 
            // IdDia
            // 
            this.IdDia.DataPropertyName = "IdDia";
            this.IdDia.HeaderText = "Dia";
            this.IdDia.Name = "IdDia";
            // 
            // RestriccionDia
            // 
            this.RestriccionDia.DataPropertyName = "Restriccion";
            this.RestriccionDia.HeaderText = "RestriccionDia";
            this.RestriccionDia.Name = "RestriccionDia";
            this.RestriccionDia.Visible = false;
            // 
            // IdRestriccionDia
            // 
            this.IdRestriccionDia.DataPropertyName = "IdRestriccion";
            this.IdRestriccionDia.HeaderText = "IdRestriccionDia";
            this.IdRestriccionDia.Name = "IdRestriccionDia";
            this.IdRestriccionDia.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dtgHoras);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(769, 474);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Restricción Hora";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dtgHoras
            // 
            this.dtgHoras.BackgroundColor = System.Drawing.Color.White;
            this.dtgHoras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgHoras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgHoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHoras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoraInicial,
            this.RestriccionHora,
            this.IdRestriccionHora,
            this.HoraFinal});
            this.dtgHoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHoras.Location = new System.Drawing.Point(3, 4);
            this.dtgHoras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgHoras.Name = "dtgHoras";
            this.dtgHoras.RowHeadersVisible = false;
            this.dtgHoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHoras.Size = new System.Drawing.Size(763, 466);
            this.dtgHoras.TabIndex = 2;
            this.dtgHoras.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgHoras_CellFormatting);
            this.dtgHoras.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgHoras_DataError);
            this.dtgHoras.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgHoras_UserDeletingRow);
            // 
            // HoraInicial
            // 
            this.HoraInicial.DataPropertyName = "HoraInicial";
            this.HoraInicial.HeaderText = "HoraInicial";
            this.HoraInicial.Name = "HoraInicial";
            // 
            // RestriccionHora
            // 
            this.RestriccionHora.DataPropertyName = "Restriccion";
            this.RestriccionHora.HeaderText = "RestriccionHora";
            this.RestriccionHora.Name = "RestriccionHora";
            this.RestriccionHora.Visible = false;
            // 
            // IdRestriccionHora
            // 
            this.IdRestriccionHora.DataPropertyName = "IdRestriccion";
            this.IdRestriccionHora.HeaderText = "IdRestriccionHora";
            this.IdRestriccionHora.Name = "IdRestriccionHora";
            this.IdRestriccionHora.Visible = false;
            // 
            // HoraFinal
            // 
            this.HoraFinal.DataPropertyName = "HoraFinal";
            this.HoraFinal.HeaderText = "HoraFinal";
            this.HoraFinal.Name = "HoraFinal";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dtgProducto);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(769, 474);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Restricción Producto";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dtgProducto
            // 
            this.dtgProducto.BackgroundColor = System.Drawing.Color.White;
            this.dtgProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgProducto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdProducto});
            this.dtgProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgProducto.Location = new System.Drawing.Point(3, 4);
            this.dtgProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgProducto.Name = "dtgProducto";
            this.dtgProducto.RowHeadersVisible = false;
            this.dtgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProducto.Size = new System.Drawing.Size(763, 466);
            this.dtgProducto.TabIndex = 1;
            this.dtgProducto.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgProducto_UserDeletingRow);
            // 
            // IdProducto
            // 
            this.IdProducto.DataPropertyName = "IdProducto";
            this.IdProducto.HeaderText = "Producto";
            this.IdProducto.Name = "IdProducto";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dtgHoraDia);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage5.Size = new System.Drawing.Size(769, 474);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Restricción Día Hora";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dtgHoraDia
            // 
            this.dtgHoraDia.BackgroundColor = System.Drawing.Color.White;
            this.dtgHoraDia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgHoraDia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtgHoraDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHoraDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RestriccionHDia,
            this.dhIdDia,
            this.dHoraInicial,
            this.dHoraFinal,
            this.IdRestriccionHD,
            this.ResHora,
            this.ResDia});
            this.dtgHoraDia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHoraDia.Location = new System.Drawing.Point(3, 4);
            this.dtgHoraDia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgHoraDia.Name = "dtgHoraDia";
            this.dtgHoraDia.RowHeadersVisible = false;
            this.dtgHoraDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHoraDia.Size = new System.Drawing.Size(763, 466);
            this.dtgHoraDia.TabIndex = 2;
            this.dtgHoraDia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgHoraDia_CellFormatting);
            this.dtgHoraDia.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgHoraDia_DataError);
            this.dtgHoraDia.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgHoraDia_UserDeletingRow);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlPrincipal);
            this.groupBox2.Location = new System.Drawing.Point(20, 45);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(815, 678);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label13.Location = new System.Drawing.Point(345, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(164, 27);
            this.label13.TabIndex = 57;
            this.label13.Text = "RESTRICCIONES";
            // 
            // RestriccionHDia
            // 
            this.RestriccionHDia.DataPropertyName = "Restriccion";
            this.RestriccionHDia.HeaderText = "";
            this.RestriccionHDia.Name = "RestriccionHDia";
            this.RestriccionHDia.ReadOnly = true;
            this.RestriccionHDia.Visible = false;
            // 
            // dhIdDia
            // 
            this.dhIdDia.DataPropertyName = "IdDia";
            this.dhIdDia.HeaderText = "Dia";
            this.dhIdDia.Name = "dhIdDia";
            // 
            // dHoraInicial
            // 
            this.dHoraInicial.DataPropertyName = "HoraInicial";
            this.dHoraInicial.HeaderText = "HoraInicial";
            this.dHoraInicial.Name = "dHoraInicial";
            // 
            // dHoraFinal
            // 
            this.dHoraFinal.DataPropertyName = "HoraFinal";
            this.dHoraFinal.HeaderText = "HoraFinal";
            this.dHoraFinal.Name = "dHoraFinal";
            // 
            // IdRestriccionHD
            // 
            this.IdRestriccionHD.DataPropertyName = "IdRestriccion";
            this.IdRestriccionHD.HeaderText = "IdRestriccionHD";
            this.IdRestriccionHD.Name = "IdRestriccionHD";
            this.IdRestriccionHD.Visible = false;
            // 
            // ResHora
            // 
            this.ResHora.DataPropertyName = "IdRestriccionHora";
            this.ResHora.HeaderText = "ResHora";
            this.ResHora.Name = "ResHora";
            this.ResHora.Visible = false;
            // 
            // ResDia
            // 
            this.ResDia.DataPropertyName = "IdRestriccionDia";
            this.ResDia.HeaderText = "ResDia";
            this.ResDia.Name = "ResDia";
            this.ResDia.Visible = false;
            // 
            // gsRestricciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsRestricciones";
            this.Size = new System.Drawing.Size(857, 745);
            this.Load += new System.EventHandler(this.gsRestricciones_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabRestricciones.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBasica)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDia)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoras)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoraDia)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.TabControl tabRestricciones;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuSalir;
        private System.Windows.Forms.ToolStripButton mnuBuscar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dtgDia;
        private System.Windows.Forms.DataGridView dtgHoras;
        private System.Windows.Forms.DataGridView dtgProducto;
        private System.Windows.Forms.DataGridView dtgBasica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblIdVehiculo;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestriccionDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRestriccionDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestriccionHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRestriccionHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanqueos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRestriccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Galones;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumenSemanal;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumenMensual;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dtgHoraDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn RestriccionHDia;
        private System.Windows.Forms.DataGridViewComboBoxColumn dhIdDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHoraInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dHoraFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRestriccionHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResDia;

    }
}
