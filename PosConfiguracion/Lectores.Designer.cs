namespace PosConfiguracion
{
    partial class Lectores
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgConfigurarCarasDTI = new System.Windows.Forms.DataGridView();
            this.IdDispositivoCara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPuertoDTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaraDTIGrilla = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Dispositivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DispositivoDTIGrilla = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DireccionGrilla = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dtgDispositivosDTI = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.lstLectores = new System.Windows.Forms.ListBox();
            this.chkLectores = new System.Windows.Forms.CheckedListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtLector = new System.Windows.Forms.TextBox();
            this.cmbPuertoOneWire = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.IdLectorDTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoComunicacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IdTipoComunicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPuerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuertoDTI = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Puerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PuertoIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigurarCarasDTI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDispositivosDTI)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(827, 39);
            this.label3.TabIndex = 53;
            this.label3.Text = "LECTORES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtgConfigurarCarasDTI);
            this.panel1.Controls.Add(this.dtgDispositivosDTI);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 266);
            this.panel1.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(471, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asociar Cara con LSIB4";
            // 
            // dtgConfigurarCarasDTI
            // 
            this.dtgConfigurarCarasDTI.AllowUserToResizeRows = false;
            this.dtgConfigurarCarasDTI.BackgroundColor = System.Drawing.Color.White;
            this.dtgConfigurarCarasDTI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgConfigurarCarasDTI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDispositivoCara,
            this.IdPuertoDTI,
            this.Cara,
            this.CaraDTIGrilla,
            this.Dispositivo,
            this.DispositivoDTIGrilla,
            this.DireccionGrilla});
            this.dtgConfigurarCarasDTI.Location = new System.Drawing.Point(474, 47);
            this.dtgConfigurarCarasDTI.MultiSelect = false;
            this.dtgConfigurarCarasDTI.Name = "dtgConfigurarCarasDTI";
            this.dtgConfigurarCarasDTI.RowHeadersVisible = false;
            this.dtgConfigurarCarasDTI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgConfigurarCarasDTI.Size = new System.Drawing.Size(308, 203);
            this.dtgConfigurarCarasDTI.TabIndex = 2;
            this.dtgConfigurarCarasDTI.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConfigurarCarasDTI_CellEndEdit);
            this.dtgConfigurarCarasDTI.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgConfigurarCarasDTI_CellValueChanged);
            this.dtgConfigurarCarasDTI.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtgConfigurarCarasDTI_UserDeletedRow);
            this.dtgConfigurarCarasDTI.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgConfigurarCarasDTI_UserDeletingRow);
            // 
            // IdDispositivoCara
            // 
            this.IdDispositivoCara.DataPropertyName = "IdDispositivoCara";
            this.IdDispositivoCara.HeaderText = "IdDispositivoCara";
            this.IdDispositivoCara.Name = "IdDispositivoCara";
            this.IdDispositivoCara.Visible = false;
            // 
            // IdPuertoDTI
            // 
            this.IdPuertoDTI.DataPropertyName = "IdPuertoLSIB4";
            this.IdPuertoDTI.HeaderText = "IdPuertoDTI";
            this.IdPuertoDTI.Name = "IdPuertoDTI";
            this.IdPuertoDTI.Visible = false;
            // 
            // Cara
            // 
            this.Cara.DataPropertyName = "Descripcion";
            this.Cara.HeaderText = "Cara";
            this.Cara.Name = "Cara";
            this.Cara.Visible = false;
            // 
            // CaraDTIGrilla
            // 
            this.CaraDTIGrilla.DataPropertyName = "IdCara";
            this.CaraDTIGrilla.HeaderText = "Cara";
            this.CaraDTIGrilla.Name = "CaraDTIGrilla";
            this.CaraDTIGrilla.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Dispositivo
            // 
            this.Dispositivo.DataPropertyName = "Dispositivo";
            this.Dispositivo.HeaderText = "Dispositivo";
            this.Dispositivo.Name = "Dispositivo";
            this.Dispositivo.ReadOnly = true;
            this.Dispositivo.Visible = false;
            // 
            // DispositivoDTIGrilla
            // 
            this.DispositivoDTIGrilla.DataPropertyName = "IdDTI";
            this.DispositivoDTIGrilla.HeaderText = "Dispositivo LSIB4";
            this.DispositivoDTIGrilla.Name = "DispositivoDTIGrilla";
            this.DispositivoDTIGrilla.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DispositivoDTIGrilla.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DispositivoDTIGrilla.Width = 125;
            // 
            // DireccionGrilla
            // 
            this.DireccionGrilla.DataPropertyName = "Direccion";
            this.DireccionGrilla.HeaderText = "Direccion";
            this.DireccionGrilla.Name = "DireccionGrilla";
            this.DireccionGrilla.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DireccionGrilla.Width = 80;
            // 
            // dtgDispositivosDTI
            // 
            this.dtgDispositivosDTI.AllowUserToResizeRows = false;
            this.dtgDispositivosDTI.BackgroundColor = System.Drawing.Color.White;
            this.dtgDispositivosDTI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDispositivosDTI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdLectorDTI,
            this.Descripcion,
            this.TipoComunicacion,
            this.IdTipoComunicacion,
            this.IdPuerto,
            this.PuertoDTI,
            this.Puerto,
            this.PuertoIP,
            this.DirIP});
            this.dtgDispositivosDTI.Location = new System.Drawing.Point(9, 47);
            this.dtgDispositivosDTI.MultiSelect = false;
            this.dtgDispositivosDTI.Name = "dtgDispositivosDTI";
            this.dtgDispositivosDTI.RowHeadersVisible = false;
            this.dtgDispositivosDTI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDispositivosDTI.Size = new System.Drawing.Size(458, 203);
            this.dtgDispositivosDTI.TabIndex = 1;
            this.dtgDispositivosDTI.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDispositivosDTI_CellEndEdit);
            this.dtgDispositivosDTI.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDispositivosDTI_CellValueChanged);
            this.dtgDispositivosDTI.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgDispositivosDTI_DataError);
            this.dtgDispositivosDTI.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDispositivosDTI_RowEnter);
            this.dtgDispositivosDTI.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dtgDispositivosDTI_UserDeletedRow);
            this.dtgDispositivosDTI.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dtgDispositivosDTI_UserDeletingRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuracion Dispositivos LSIB4";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.btnAsignar);
            this.panel2.Controls.Add(this.lstLectores);
            this.panel2.Controls.Add(this.chkLectores);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtLector);
            this.panel2.Controls.Add(this.cmbPuertoOneWire);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Location = new System.Drawing.Point(13, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(797, 283);
            this.panel2.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(579, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 22);
            this.label4.TabIndex = 51;
            this.label4.Text = "Asignados";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEliminar.Location = new System.Drawing.Point(379, 141);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(51, 39);
            this.btnEliminar.TabIndex = 61;
            this.btnEliminar.TabStop = false;
            this.btnEliminar.Text = "<";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnAsignar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAsignar.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAsignar.Location = new System.Drawing.Point(379, 95);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(51, 39);
            this.btnAsignar.TabIndex = 60;
            this.btnAsignar.TabStop = false;
            this.btnAsignar.Text = ">";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // lstLectores
            // 
            this.lstLectores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLectores.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLectores.FormattingEnabled = true;
            this.lstLectores.ItemHeight = 18;
            this.lstLectores.Location = new System.Drawing.Point(458, 93);
            this.lstLectores.Name = "lstLectores";
            this.lstLectores.Size = new System.Drawing.Size(319, 166);
            this.lstLectores.TabIndex = 59;
            // 
            // chkLectores
            // 
            this.chkLectores.CheckOnClick = true;
            this.chkLectores.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLectores.FormattingEnabled = true;
            this.chkLectores.Location = new System.Drawing.Point(28, 95);
            this.chkLectores.Name = "chkLectores";
            this.chkLectores.Size = new System.Drawing.Size(319, 166);
            this.chkLectores.TabIndex = 58;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAgregar.Location = new System.Drawing.Point(301, 52);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(46, 33);
            this.btnAgregar.TabIndex = 57;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Text = "+";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(26, 54);
            this.label27.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 18);
            this.label27.TabIndex = 54;
            this.label27.Text = "Lector";
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(143)))), ((int)(((byte)(26)))));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(301, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 27);
            this.btnBuscar.TabIndex = 53;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = ". . .";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtLector
            // 
            this.txtLector.BackColor = System.Drawing.SystemColors.Window;
            this.txtLector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLector.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLector.Location = new System.Drawing.Point(73, 52);
            this.txtLector.Name = "txtLector";
            this.txtLector.Size = new System.Drawing.Size(225, 23);
            this.txtLector.TabIndex = 52;
            this.txtLector.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLector.Validating += new System.ComponentModel.CancelEventHandler(this.txtLector_Validating);
            // 
            // cmbPuertoOneWire
            // 
            this.cmbPuertoOneWire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuertoOneWire.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPuertoOneWire.FormattingEnabled = true;
            this.cmbPuertoOneWire.Location = new System.Drawing.Point(73, 21);
            this.cmbPuertoOneWire.Name = "cmbPuertoOneWire";
            this.cmbPuertoOneWire.Size = new System.Drawing.Size(225, 26);
            this.cmbPuertoOneWire.TabIndex = 56;
            this.cmbPuertoOneWire.SelectedValueChanged += new System.EventHandler(this.cmbPuertoOneWire_SelectedValueChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30.Location = new System.Drawing.Point(23, 22);
            this.label30.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 18);
            this.label30.TabIndex = 55;
            this.label30.Text = "1-Wire";
            // 
            // IdLectorDTI
            // 
            this.IdLectorDTI.DataPropertyName = "IdLectorDTI";
            this.IdLectorDTI.HeaderText = "IdLectorDTI";
            this.IdLectorDTI.Name = "IdLectorDTI";
            this.IdLectorDTI.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Dispositivo";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 250;
            // 
            // TipoComunicacion
            // 
            this.TipoComunicacion.DataPropertyName = "IdTipoComunicacionDisp";
            this.TipoComunicacion.HeaderText = "Comunicacion";
            this.TipoComunicacion.Name = "TipoComunicacion";
            // 
            // IdTipoComunicacion
            // 
            this.IdTipoComunicacion.DataPropertyName = "IdTipoComunicacion";
            this.IdTipoComunicacion.HeaderText = "IdTipoComunicacion";
            this.IdTipoComunicacion.Name = "IdTipoComunicacion";
            this.IdTipoComunicacion.Visible = false;
            // 
            // IdPuerto
            // 
            this.IdPuerto.DataPropertyName = "IdPuerto";
            this.IdPuerto.HeaderText = "IdPuerto";
            this.IdPuerto.Name = "IdPuerto";
            this.IdPuerto.Visible = false;
            // 
            // PuertoDTI
            // 
            this.PuertoDTI.DataPropertyName = "IdPuerto";
            this.PuertoDTI.HeaderText = "Puerto Serial";
            this.PuertoDTI.Name = "PuertoDTI";
            this.PuertoDTI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Puerto
            // 
            this.Puerto.DataPropertyName = "Puerto";
            this.Puerto.HeaderText = "Puerto";
            this.Puerto.Name = "Puerto";
            this.Puerto.Visible = false;
            // 
            // PuertoIP
            // 
            this.PuertoIP.DataPropertyName = "PuertoIP";
            this.PuertoIP.HeaderText = "Puerto IP";
            this.PuertoIP.Name = "PuertoIP";
            // 
            // DirIP
            // 
            this.DirIP.HeaderText = "Direccion IP";
            this.DirIP.Name = "DirIP";
            this.DirIP.Visible = false;
            this.DirIP.Width = 240;
            // 
            // Lectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Name = "Lectores";
            this.Size = new System.Drawing.Size(830, 669);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgConfigurarCarasDTI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDispositivosDTI)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgConfigurarCarasDTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDispositivoCara;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPuertoDTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cara;
        private System.Windows.Forms.DataGridViewComboBoxColumn CaraDTIGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dispositivo;
        private System.Windows.Forms.DataGridViewComboBoxColumn DispositivoDTIGrilla;
        private System.Windows.Forms.DataGridViewComboBoxColumn DireccionGrilla;
        private System.Windows.Forms.DataGridView dtgDispositivosDTI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ListBox lstLectores;
        private System.Windows.Forms.CheckedListBox chkLectores;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtLector;
        private System.Windows.Forms.ComboBox cmbPuertoOneWire;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLectorDTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoComunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoComunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPuerto;
        private System.Windows.Forms.DataGridViewComboBoxColumn PuertoDTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puerto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuertoIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirIP;

    }
}
