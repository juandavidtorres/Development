namespace PosStation.UInterface
{
    partial class PromocionHoraFeliz
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Popup = new PopupNotifier();
            this.pnlDatosPromocion = new System.Windows.Forms.Panel();
            this.grbTipoDescuento = new System.Windows.Forms.GroupBox();
            this.rdbValor = new System.Windows.Forms.RadioButton();
            this.rdbPorcentaje = new System.Windows.Forms.RadioButton();
            this.dtpHoraFinal = new System.Windows.Forms.MaskedTextBox();
            this.dtpHoraInicial = new System.Windows.Forms.MaskedTextBox();
            this.txtIdPromocion = new System.Windows.Forms.TextBox();
            this.chkEsActivo = new System.Windows.Forms.CheckBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.grdPromocionesHF = new System.Windows.Forms.DataGridView();
            this.IdGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicialGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicialGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFinalGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFinalGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorGrilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeGrilla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EstadoGrilla = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnlPromoHoraFeliz = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDatosPromocion.SuspendLayout();
            this.grbTipoDescuento.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPromocionesHF)).BeginInit();
            this.pnlPromoHoraFeliz.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.Popup.ShowDelay = 1000;
            this.Popup.ShowGrip = false;
            this.Popup.Size = new System.Drawing.Size(400, 100);
            this.Popup.TextPadding = new System.Windows.Forms.Padding(0);
            this.Popup.TitleFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.Popup.TitleText = null;
            // 
            // pnlDatosPromocion
            // 
            this.pnlDatosPromocion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosPromocion.Controls.Add(this.label9);
            this.pnlDatosPromocion.Controls.Add(this.label8);
            this.pnlDatosPromocion.Controls.Add(this.label4);
            this.pnlDatosPromocion.Controls.Add(this.grbTipoDescuento);
            this.pnlDatosPromocion.Controls.Add(this.dtpHoraFinal);
            this.pnlDatosPromocion.Controls.Add(this.dtpHoraInicial);
            this.pnlDatosPromocion.Controls.Add(this.txtIdPromocion);
            this.pnlDatosPromocion.Controls.Add(this.chkEsActivo);
            this.pnlDatosPromocion.Controls.Add(this.txtValor);
            this.pnlDatosPromocion.Controls.Add(this.dtpFechaFinal);
            this.pnlDatosPromocion.Controls.Add(this.dtpFechaInicial);
            this.pnlDatosPromocion.Controls.Add(this.label5);
            this.pnlDatosPromocion.Controls.Add(this.label3);
            this.pnlDatosPromocion.Controls.Add(this.label2);
            this.pnlDatosPromocion.Controls.Add(this.label1);
            this.pnlDatosPromocion.Location = new System.Drawing.Point(8, 72);
            this.pnlDatosPromocion.Name = "pnlDatosPromocion";
            this.pnlDatosPromocion.Size = new System.Drawing.Size(687, 235);
            this.pnlDatosPromocion.TabIndex = 91;
            // 
            // grbTipoDescuento
            // 
            this.grbTipoDescuento.Controls.Add(this.rdbValor);
            this.grbTipoDescuento.Controls.Add(this.rdbPorcentaje);
            this.grbTipoDescuento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.grbTipoDescuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.grbTipoDescuento.Location = new System.Drawing.Point(307, 119);
            this.grbTipoDescuento.Name = "grbTipoDescuento";
            this.grbTipoDescuento.Size = new System.Drawing.Size(177, 81);
            this.grbTipoDescuento.TabIndex = 106;
            this.grbTipoDescuento.TabStop = false;
            this.grbTipoDescuento.Text = "Tipo Descuento:";
            // 
            // rdbValor
            // 
            this.rdbValor.AutoSize = true;
            this.rdbValor.Location = new System.Drawing.Point(6, 50);
            this.rdbValor.Name = "rdbValor";
            this.rdbValor.Size = new System.Drawing.Size(52, 20);
            this.rdbValor.TabIndex = 1;
            this.rdbValor.Text = "Valor";
            this.rdbValor.UseVisualStyleBackColor = true;
            // 
            // rdbPorcentaje
            // 
            this.rdbPorcentaje.AutoSize = true;
            this.rdbPorcentaje.Checked = true;
            this.rdbPorcentaje.Location = new System.Drawing.Point(6, 22);
            this.rdbPorcentaje.Name = "rdbPorcentaje";
            this.rdbPorcentaje.Size = new System.Drawing.Size(82, 20);
            this.rdbPorcentaje.TabIndex = 0;
            this.rdbPorcentaje.TabStop = true;
            this.rdbPorcentaje.Text = "Porcentaje";
            this.rdbPorcentaje.UseVisualStyleBackColor = true;
            // 
            // dtpHoraFinal
            // 
            this.dtpHoraFinal.Location = new System.Drawing.Point(320, 87);
            this.dtpHoraFinal.Mask = "00:00";
            this.dtpHoraFinal.Name = "dtpHoraFinal";
            this.dtpHoraFinal.Size = new System.Drawing.Size(100, 20);
            this.dtpHoraFinal.TabIndex = 105;
            this.dtpHoraFinal.ValidatingType = typeof(System.DateTime);
            // 
            // dtpHoraInicial
            // 
            this.dtpHoraInicial.Location = new System.Drawing.Point(320, 50);
            this.dtpHoraInicial.Mask = "00:00";
            this.dtpHoraInicial.Name = "dtpHoraInicial";
            this.dtpHoraInicial.Size = new System.Drawing.Size(100, 20);
            this.dtpHoraInicial.TabIndex = 104;
            this.dtpHoraInicial.ValidatingType = typeof(System.DateTime);
            // 
            // txtIdPromocion
            // 
            this.txtIdPromocion.BackColor = System.Drawing.Color.White;
            this.txtIdPromocion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdPromocion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdPromocion.Location = new System.Drawing.Point(580, 8);
            this.txtIdPromocion.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtIdPromocion.Name = "txtIdPromocion";
            this.txtIdPromocion.Size = new System.Drawing.Size(114, 21);
            this.txtIdPromocion.TabIndex = 103;
            this.txtIdPromocion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdPromocion.Visible = false;
            // 
            // chkEsActivo
            // 
            this.chkEsActivo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.chkEsActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkEsActivo.Location = new System.Drawing.Point(513, 119);
            this.chkEsActivo.Name = "chkEsActivo";
            this.chkEsActivo.Size = new System.Drawing.Size(88, 24);
            this.chkEsActivo.TabIndex = 102;
            this.chkEsActivo.Text = "Activo";
            this.chkEsActivo.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.White;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(182, 131);
            this.txtValor.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(114, 21);
            this.txtValor.TabIndex = 100;
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(182, 87);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(114, 20);
            this.dtpFechaFinal.TabIndex = 97;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(182, 50);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(114, 20);
            this.dtpFechaInicial.TabIndex = 96;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.Location = new System.Drawing.Point(290, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 95;
            this.label5.Text = "Datos Promoción";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(60, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 94;
            this.label3.Text = "Valor Descuento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(60, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 93;
            this.label2.Text = "Fecha Final:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(60, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 92;
            this.label1.Text = "Fecha Inicial:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.grdPromocionesHF);
            this.panel1.Location = new System.Drawing.Point(8, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 220);
            this.panel1.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label6.Location = new System.Drawing.Point(250, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 18);
            this.label6.TabIndex = 96;
            this.label6.Text = "Promociones Registradas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdPromocionesHF
            // 
            this.grdPromocionesHF.AllowUserToAddRows = false;
            this.grdPromocionesHF.AllowUserToDeleteRows = false;
            this.grdPromocionesHF.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.grdPromocionesHF.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPromocionesHF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdPromocionesHF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPromocionesHF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGrilla,
            this.FechaInicialGrilla,
            this.HoraInicialGrilla,
            this.FechaFinalGrilla,
            this.HoraFinalGrilla,
            this.ValorGrilla,
            this.PorcentajeGrilla,
            this.EstadoGrilla});
            this.grdPromocionesHF.Location = new System.Drawing.Point(44, 31);
            this.grdPromocionesHF.Name = "grdPromocionesHF";
            this.grdPromocionesHF.RowHeadersVisible = false;
            this.grdPromocionesHF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdPromocionesHF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPromocionesHF.Size = new System.Drawing.Size(591, 194);
            this.grdPromocionesHF.TabIndex = 0;
            this.grdPromocionesHF.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPromocionesHF_CellDoubleClick);
            this.grdPromocionesHF.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdPromocionesHF_DataError);
            this.grdPromocionesHF.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdPromocionesHF_UserDeletedRow);
            this.grdPromocionesHF.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdPromocionesHF_UserDeletingRow);
            // 
            // IdGrilla
            // 
            this.IdGrilla.DataPropertyName = "Id";
            this.IdGrilla.HeaderText = "Id";
            this.IdGrilla.Name = "IdGrilla";
            this.IdGrilla.Width = 30;
            // 
            // FechaInicialGrilla
            // 
            this.FechaInicialGrilla.DataPropertyName = "FechaInicial";
            this.FechaInicialGrilla.HeaderText = "Fecha Inicial";
            this.FechaInicialGrilla.Name = "FechaInicialGrilla";
            this.FechaInicialGrilla.Width = 98;
            // 
            // HoraInicialGrilla
            // 
            this.HoraInicialGrilla.DataPropertyName = "HoraInicial";
            this.HoraInicialGrilla.HeaderText = "Hora Inicial";
            this.HoraInicialGrilla.Name = "HoraInicialGrilla";
            this.HoraInicialGrilla.Width = 88;
            // 
            // FechaFinalGrilla
            // 
            this.FechaFinalGrilla.DataPropertyName = "FechaFinal";
            this.FechaFinalGrilla.HeaderText = "Fecha Final";
            this.FechaFinalGrilla.Name = "FechaFinalGrilla";
            this.FechaFinalGrilla.Width = 98;
            // 
            // HoraFinalGrilla
            // 
            this.HoraFinalGrilla.DataPropertyName = "HoraFinal";
            this.HoraFinalGrilla.HeaderText = "Hora Final";
            this.HoraFinalGrilla.Name = "HoraFinalGrilla";
            this.HoraFinalGrilla.Width = 85;
            // 
            // ValorGrilla
            // 
            this.ValorGrilla.DataPropertyName = "Valor";
            this.ValorGrilla.HeaderText = "Valor";
            this.ValorGrilla.Name = "ValorGrilla";
            this.ValorGrilla.Width = 60;
            // 
            // PorcentajeGrilla
            // 
            this.PorcentajeGrilla.DataPropertyName = "Porcentaje";
            this.PorcentajeGrilla.HeaderText = "Porcentaje";
            this.PorcentajeGrilla.Name = "PorcentajeGrilla";
            this.PorcentajeGrilla.Width = 70;
            // 
            // EstadoGrilla
            // 
            this.EstadoGrilla.DataPropertyName = "Estado";
            this.EstadoGrilla.HeaderText = "Activo";
            this.EstadoGrilla.Name = "EstadoGrilla";
            this.EstadoGrilla.Width = 60;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(152, 10);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(190, 39);
            this.miniToolStrip.TabIndex = 93;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(34, 34);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(34, 34);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.ToolTipText = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = false;
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Bucar16;
            this.btnBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.ToolTipText = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.AutoSize = false;
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCerrar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(34, 34);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pnlPromoHoraFeliz
            // 
            this.pnlPromoHoraFeliz.AutoScroll = true;
            this.pnlPromoHoraFeliz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPromoHoraFeliz.Controls.Add(this.label7);
            this.pnlPromoHoraFeliz.Controls.Add(this.toolStrip1);
            this.pnlPromoHoraFeliz.Controls.Add(this.panel1);
            this.pnlPromoHoraFeliz.Controls.Add(this.pnlDatosPromocion);
            this.pnlPromoHoraFeliz.Location = new System.Drawing.Point(0, 3);
            this.pnlPromoHoraFeliz.Name = "pnlPromoHoraFeliz";
            this.pnlPromoHoraFeliz.Size = new System.Drawing.Size(719, 535);
            this.pnlPromoHoraFeliz.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(217, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(252, 27);
            this.label7.TabIndex = 96;
            this.label7.Text = "PROMOCION HORA FELIZ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.btnBuscar,
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(509, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(186, 39);
            this.toolStrip1.TabIndex = 93;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(421, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 107;
            this.label4.Text = "* ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(422, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 108;
            this.label8.Text = "* ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(60, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 16);
            this.label9.TabIndex = 109;
            this.label9.Text = "* La hora debe estar entre las 00:00 y las 23:59 ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PromocionHoraFeliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlPromoHoraFeliz);
            this.Name = "PromocionHoraFeliz";
            this.Size = new System.Drawing.Size(719, 538);
            this.pnlDatosPromocion.ResumeLayout(false);
            this.pnlDatosPromocion.PerformLayout();
            this.grbTipoDescuento.ResumeLayout(false);
            this.grbTipoDescuento.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPromocionesHF)).EndInit();
            this.pnlPromoHoraFeliz.ResumeLayout(false);
            this.pnlPromoHoraFeliz.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal PopupNotifier Popup;
        private System.Windows.Forms.Panel pnlDatosPromocion;
        private System.Windows.Forms.TextBox txtIdPromocion;
        private System.Windows.Forms.CheckBox chkEsActivo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdPromocionesHF;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.Panel pnlPromoHoraFeliz;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MaskedTextBox dtpHoraInicial;
        private System.Windows.Forms.MaskedTextBox dtpHoraFinal;
        private System.Windows.Forms.GroupBox grbTipoDescuento;
        private System.Windows.Forms.RadioButton rdbValor;
        private System.Windows.Forms.RadioButton rdbPorcentaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicialGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicialGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFinalGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFinalGrilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorGrilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PorcentajeGrilla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EstadoGrilla;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
    }
}
