namespace PosStation.Generaciones
{
    partial class Generacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.dtgCreditos = new System.Windows.Forms.DataGridView();
            this.EsFacturable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFacturacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.Popup = new PopupNotifier();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadCreditos = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadCreditos);
            this.panel1.Controls.Add(this.pnlDatos);
            this.panel1.Controls.Add(this.btnAdicionar);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnFacturar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbFacturacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFechaInicial);
            this.panel1.Location = new System.Drawing.Point(6, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 267);
            this.panel1.TabIndex = 0;
            // 
            // pnlDatos
            // 
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.dtgCreditos);
            this.pnlDatos.Location = new System.Drawing.Point(15, 55);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(605, 200);
            this.pnlDatos.TabIndex = 14;
            // 
            // dtgCreditos
            // 
            this.dtgCreditos.AllowUserToAddRows = false;
            this.dtgCreditos.AllowUserToDeleteRows = false;
            this.dtgCreditos.BackgroundColor = System.Drawing.Color.White;
            this.dtgCreditos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgCreditos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgCreditos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EsFacturable});
            this.dtgCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgCreditos.GridColor = System.Drawing.Color.White;
            this.dtgCreditos.Location = new System.Drawing.Point(0, 0);
            this.dtgCreditos.Name = "dtgCreditos";
            this.dtgCreditos.RowHeadersVisible = false;
            this.dtgCreditos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCreditos.Size = new System.Drawing.Size(603, 198);
            this.dtgCreditos.TabIndex = 0;
            // 
            // EsFacturable
            // 
            this.EsFacturable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EsFacturable.HeaderText = "";
            this.EsFacturable.Name = "EsFacturable";
            this.EsFacturable.Width = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(262, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Corte";
            // 
            // cmbFacturacion
            // 
            this.cmbFacturacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFacturacion.FormattingEnabled = true;
            this.cmbFacturacion.Location = new System.Drawing.Point(95, 15);
            this.cmbFacturacion.Name = "cmbFacturacion";
            this.cmbFacturacion.Size = new System.Drawing.Size(153, 21);
            this.cmbFacturacion.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Facturacion";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(309, 16);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(108, 20);
            this.dtpFechaInicial.TabIndex = 2;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(22, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 298);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(288, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 27);
            this.label7.TabIndex = 53;
            this.label7.Text = "GENERACIÓN";
            // 
            // btnLoadCreditos
            // 
            this.btnLoadCreditos.AutoSize = true;
            this.btnLoadCreditos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnLoadCreditos.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.btnLoadCreditos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadCreditos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoadCreditos.Location = new System.Drawing.Point(441, 9);
            this.btnLoadCreditos.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadCreditos.Name = "btnLoadCreditos";
            this.btnLoadCreditos.Size = new System.Drawing.Size(34, 34);
            this.btnLoadCreditos.TabIndex = 15;
            this.btnLoadCreditos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnLoadCreditos, "Previsualizar Creditos a Facturarse");
            this.btnLoadCreditos.UseVisualStyleBackColor = false;
            this.btnLoadCreditos.Click += new System.EventHandler(this.btnLoadCreditos_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.AutoSize = true;
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnAdicionar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Mas;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.Location = new System.Drawing.Point(513, 9);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(34, 34);
            this.btnAdicionar.TabIndex = 13;
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnAdicionar, "Adicionar nuevo cliente a la Facturacion");
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnClose.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(585, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 34);
            this.btnClose.TabIndex = 12;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnClose, "Salir de la Opcion");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.button2.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(549, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 34);
            this.button2.TabIndex = 11;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnFacturar
            // 
            this.btnFacturar.AutoSize = true;
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnFacturar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Facturar;
            this.btnFacturar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFacturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFacturar.Location = new System.Drawing.Point(477, 9);
            this.btnFacturar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(34, 34);
            this.btnFacturar.TabIndex = 10;
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnFacturar, "Generar Facturas");
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // Generacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Name = "Generacion";
            this.Size = new System.Drawing.Size(687, 373);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCreditos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFacturacion;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.DataGridView dtgCreditos;
        private System.Windows.Forms.Button btnLoadCreditos;
        internal PopupNotifier Popup;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EsFacturable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}
