namespace PosConfiguracion
{
    partial class gsConfiguraLiquido
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlDispositivos = new System.Windows.Forms.Panel();
            this.dgvDispositivos = new System.Windows.Forms.DataGridView();
            this.IdDispositivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoComunicacionDisp = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EsActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdPuerto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DireccionIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuertoIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTanques = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTanque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dispositivo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTanqueProducto = new System.Windows.Forms.DataGridView();
            this.IdTanque = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelAforo = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTanqueAforo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grdAforoTanque = new System.Windows.Forms.DataGridView();
            this.grdAforoIdAforo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdAforoAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdAforoCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlDispositivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispositivos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanques)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanqueProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelAforo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAforoTanque)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(11, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 619);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlDispositivos);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 597);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            // 
            // pnlDispositivos
            // 
            this.pnlDispositivos.Controls.Add(this.dgvDispositivos);
            this.pnlDispositivos.Controls.Add(this.label10);
            this.pnlDispositivos.Location = new System.Drawing.Point(11, 175);
            this.pnlDispositivos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDispositivos.Name = "pnlDispositivos";
            this.pnlDispositivos.Size = new System.Drawing.Size(550, 132);
            this.pnlDispositivos.TabIndex = 52;
            // 
            // dgvDispositivos
            // 
            this.dgvDispositivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDispositivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDispositivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispositivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDispositivo,
            this.Nombre,
            this.IdTipoComunicacionDisp,
            this.EsActivo,
            this.IdPuerto,
            this.DireccionIP,
            this.PuertoIP});
            this.dgvDispositivos.Location = new System.Drawing.Point(3, 25);
            this.dgvDispositivos.Name = "dgvDispositivos";
            this.dgvDispositivos.RowHeadersVisible = false;
            this.dgvDispositivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDispositivos.Size = new System.Drawing.Size(544, 105);
            this.dgvDispositivos.TabIndex = 2;
            this.dgvDispositivos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispositivos_CellValueChanged);
            this.dgvDispositivos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDispositivos_DataError);
            this.dgvDispositivos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDispositivos_UserDeletingRow);
            // 
            // IdDispositivo
            // 
            this.IdDispositivo.DataPropertyName = "IdDispositivo";
            this.IdDispositivo.HeaderText = "IdDispositivo";
            this.IdDispositivo.Name = "IdDispositivo";
            this.IdDispositivo.Visible = false;
            this.IdDispositivo.Width = 10;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Dispositivo";
            this.Nombre.Name = "Nombre";
            // 
            // IdTipoComunicacionDisp
            // 
            this.IdTipoComunicacionDisp.DataPropertyName = "IdTipoComunicacionDisp";
            this.IdTipoComunicacionDisp.HeaderText = "Comunicacion";
            this.IdTipoComunicacionDisp.Name = "IdTipoComunicacionDisp";
            this.IdTipoComunicacionDisp.Width = 80;
            // 
            // EsActivo
            // 
            this.EsActivo.DataPropertyName = "EsActivo";
            this.EsActivo.HeaderText = "Activo";
            this.EsActivo.Name = "EsActivo";
            this.EsActivo.Width = 40;
            // 
            // IdPuerto
            // 
            this.IdPuerto.DataPropertyName = "IdPuerto";
            this.IdPuerto.HeaderText = "Puerto";
            this.IdPuerto.Name = "IdPuerto";
            this.IdPuerto.Width = 70;
            // 
            // DireccionIP
            // 
            this.DireccionIP.DataPropertyName = "DireccionIP";
            this.DireccionIP.HeaderText = "DireccionIP";
            this.DireccionIP.Name = "DireccionIP";
            // 
            // PuertoIP
            // 
            this.PuertoIP.DataPropertyName = "PuertoIP";
            this.PuertoIP.HeaderText = "PuertoIP";
            this.PuertoIP.Name = "PuertoIP";
            this.PuertoIP.Width = 70;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label10.Location = new System.Drawing.Point(8, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(539, 18);
            this.label10.TabIndex = 1;
            this.label10.Text = "DISPOSITIVOS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgvTanques);
            this.panel2.Location = new System.Drawing.Point(11, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 151);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(539, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "TANQUES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTanques
            // 
            this.dgvTanques.AllowUserToDeleteRows = false;
            this.dgvTanques.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTanques.BackgroundColor = System.Drawing.Color.White;
            this.dgvTanques.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTanques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTanques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Descripcion,
            this.NombreTanque,
            this.Codigo,
            this.Capacidad,
            this.Stock,
            this.Dispositivo,
            this.Estado});
            this.dgvTanques.Location = new System.Drawing.Point(8, 28);
            this.dgvTanques.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTanques.Name = "dgvTanques";
            this.dgvTanques.RowHeadersVisible = false;
            this.dgvTanques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTanques.Size = new System.Drawing.Size(539, 116);
            this.dgvTanques.TabIndex = 0;
            this.dgvTanques.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTanques_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdTanque";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdTanque";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // NombreTanque
            // 
            this.NombreTanque.DataPropertyName = "Nombre";
            this.NombreTanque.HeaderText = "Nombre";
            this.NombreTanque.Name = "NombreTanque";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 50;
            // 
            // Capacidad
            // 
            this.Capacidad.DataPropertyName = "Capacidad";
            this.Capacidad.HeaderText = "Capacidad";
            this.Capacidad.Name = "Capacidad";
            this.Capacidad.Width = 60;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Visible = false;
            this.Stock.Width = 50;
            // 
            // Dispositivo
            // 
            this.Dispositivo.DataPropertyName = "IdDispositivoMedicion";
            this.Dispositivo.HeaderText = "Dispositivo";
            this.Dispositivo.Name = "Dispositivo";
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "EsActivo";
            this.Estado.HeaderText = "Activo";
            this.Estado.Name = "Estado";
            this.Estado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Estado.Width = 50;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dgvTanqueProducto);
            this.panel3.Location = new System.Drawing.Point(11, 312);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 280);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(8, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(539, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "TANQUES - PRODUCTOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTanqueProducto
            // 
            this.dgvTanqueProducto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTanqueProducto.BackgroundColor = System.Drawing.Color.White;
            this.dgvTanqueProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTanqueProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTanqueProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTanque,
            this.IdProducto});
            this.dgvTanqueProducto.Location = new System.Drawing.Point(8, 29);
            this.dgvTanqueProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTanqueProducto.Name = "dgvTanqueProducto";
            this.dgvTanqueProducto.RowHeadersVisible = false;
            this.dgvTanqueProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTanqueProducto.Size = new System.Drawing.Size(539, 216);
            this.dgvTanqueProducto.TabIndex = 0;
            this.dgvTanqueProducto.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTanqueProducto_CellValueChanged);
            this.dgvTanqueProducto.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvTanqueProducto_UserDeletingRow);
            // 
            // IdTanque
            // 
            this.IdTanque.DataPropertyName = "IdTanque";
            this.IdTanque.FillWeight = 190F;
            this.IdTanque.HeaderText = "Tanque";
            this.IdTanque.Name = "IdTanque";
            this.IdTanque.Width = 190;
            // 
            // IdProducto
            // 
            this.IdProducto.DataPropertyName = "IdProducto";
            this.IdProducto.FillWeight = 190F;
            this.IdProducto.HeaderText = "Producto";
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.Width = 190;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelAforo);
            this.groupBox1.Location = new System.Drawing.Point(576, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 597);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // panelAforo
            // 
            this.panelAforo.Controls.Add(this.btnAgregar);
            this.panelAforo.Controls.Add(this.txtCantidad);
            this.panelAforo.Controls.Add(this.label9);
            this.panelAforo.Controls.Add(this.txtAltura);
            this.panelAforo.Controls.Add(this.label8);
            this.panelAforo.Controls.Add(this.cmbTanqueAforo);
            this.panelAforo.Controls.Add(this.label7);
            this.panelAforo.Controls.Add(this.grdAforoTanque);
            this.panelAforo.Controls.Add(this.label1);
            this.panelAforo.Location = new System.Drawing.Point(6, 13);
            this.panelAforo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAforo.Name = "panelAforo";
            this.panelAforo.Size = new System.Drawing.Size(262, 578);
            this.panelAforo.TabIndex = 51;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::PosConfiguracion.Properties.Resources.Agregar1;
            this.btnAgregar.Location = new System.Drawing.Point(209, 56);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(48, 45);
            this.btnAgregar.TabIndex = 56;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(98, 81);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(68, 20);
            this.txtCantidad.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(10, 83);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 16);
            this.label9.TabIndex = 54;
            this.label9.Text = "Cantidad (gal):";
            // 
            // txtAltura
            // 
            this.txtAltura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltura.Location = new System.Drawing.Point(98, 56);
            this.txtAltura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(68, 20);
            this.txtAltura.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(10, 58);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 52;
            this.label8.Text = "Altura (cm):";
            // 
            // cmbTanqueAforo
            // 
            this.cmbTanqueAforo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTanqueAforo.FormattingEnabled = true;
            this.cmbTanqueAforo.Location = new System.Drawing.Point(98, 28);
            this.cmbTanqueAforo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTanqueAforo.Name = "cmbTanqueAforo";
            this.cmbTanqueAforo.Size = new System.Drawing.Size(159, 24);
            this.cmbTanqueAforo.TabIndex = 51;
            this.cmbTanqueAforo.SelectedIndexChanged += new System.EventHandler(this.cmbTanqueAforo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(10, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 50;
            this.label7.Text = "Tanque";
            // 
            // grdAforoTanque
            // 
            this.grdAforoTanque.AllowUserToAddRows = false;
            this.grdAforoTanque.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdAforoTanque.BackgroundColor = System.Drawing.Color.White;
            this.grdAforoTanque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAforoTanque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAforoTanque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdAforoIdAforo,
            this.grdAforoAltura,
            this.grdAforoCantidad});
            this.grdAforoTanque.Location = new System.Drawing.Point(6, 107);
            this.grdAforoTanque.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdAforoTanque.MultiSelect = false;
            this.grdAforoTanque.Name = "grdAforoTanque";
            this.grdAforoTanque.ReadOnly = true;
            this.grdAforoTanque.RowHeadersVisible = false;
            this.grdAforoTanque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAforoTanque.ShowCellErrors = false;
            this.grdAforoTanque.ShowRowErrors = false;
            this.grdAforoTanque.Size = new System.Drawing.Size(252, 467);
            this.grdAforoTanque.TabIndex = 49;
            this.grdAforoTanque.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdAforoTanque_UserDeletedRow);
            this.grdAforoTanque.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdAforoTanque_UserDeletingRow);
            // 
            // grdAforoIdAforo
            // 
            this.grdAforoIdAforo.DataPropertyName = "IdAforo";
            this.grdAforoIdAforo.HeaderText = "IdAforo";
            this.grdAforoIdAforo.Name = "grdAforoIdAforo";
            this.grdAforoIdAforo.ReadOnly = true;
            this.grdAforoIdAforo.Visible = false;
            // 
            // grdAforoAltura
            // 
            this.grdAforoAltura.DataPropertyName = "Altura";
            this.grdAforoAltura.FillWeight = 190F;
            this.grdAforoAltura.HeaderText = "Altura (cm)";
            this.grdAforoAltura.Name = "grdAforoAltura";
            this.grdAforoAltura.ReadOnly = true;
            this.grdAforoAltura.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAforoAltura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.grdAforoAltura.Width = 112;
            // 
            // grdAforoCantidad
            // 
            this.grdAforoCantidad.DataPropertyName = "Cantidad";
            this.grdAforoCantidad.HeaderText = "Cantidad (gal)";
            this.grdAforoCantidad.Name = "grdAforoCantidad";
            this.grdAforoCantidad.ReadOnly = true;
            this.grdAforoCantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAforoCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.grdAforoCantidad.Width = 82;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 18);
            this.label1.TabIndex = 48;
            this.label1.Text = "AFORO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(873, 693);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label6.Location = new System.Drawing.Point(431, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 27);
            this.label6.TabIndex = 55;
            this.label6.Text = "LÍQUIDOS";
            // 
            // gsConfiguraLiquido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsConfiguraLiquido";
            this.Size = new System.Drawing.Size(876, 698);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnlDispositivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispositivos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanques)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTanqueProducto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelAforo.ResumeLayout(false);
            this.panelAforo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAforoTanque)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTanques;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTanqueProducto;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdTanque;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdProducto;
        private System.Windows.Forms.Panel panelAforo;
        private System.Windows.Forms.DataGridView grdAforoTanque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTanqueAforo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdAforoIdAforo;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdAforoAltura;
        private System.Windows.Forms.DataGridViewTextBoxColumn grdAforoCantidad;
        private System.Windows.Forms.Panel pnlDispositivos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreTanque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewComboBoxColumn Dispositivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridView dgvDispositivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDispositivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdTipoComunicacionDisp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsActivo;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdPuerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuertoIP;
    }
}
