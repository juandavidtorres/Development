namespace PosConfiguracion
{
    partial class Visualizacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlVisualizarConfiguracion = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.grdEstaciones = new System.Windows.Forms.DataGridView();
            this.IDEstacionGrillaEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoGrillaEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreGrillaEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NitGrillaEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionGrillaEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoGrillaEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCiudadGrillaEstacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TipoEstacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManejaLeyFrontera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEstacion = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.grdConfiguracion = new System.Windows.Forms.DataGridView();
            this.Isla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surtidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manguera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlVisualizarConfiguracion.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfiguracion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVisualizarConfiguracion
            // 
            this.pnlVisualizarConfiguracion.BackColor = System.Drawing.Color.White;
            this.pnlVisualizarConfiguracion.Controls.Add(this.panel16);
            this.pnlVisualizarConfiguracion.Controls.Add(this.btnEditar);
            this.pnlVisualizarConfiguracion.Controls.Add(this.grdConfiguracion);
            this.pnlVisualizarConfiguracion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlVisualizarConfiguracion.Location = new System.Drawing.Point(9, 13);
            this.pnlVisualizarConfiguracion.Name = "pnlVisualizarConfiguracion";
            this.pnlVisualizarConfiguracion.Size = new System.Drawing.Size(762, 529);
            this.pnlVisualizarConfiguracion.TabIndex = 24;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.grdEstaciones);
            this.panel16.Controls.Add(this.lblEstacion);
            this.panel16.Location = new System.Drawing.Point(4, 396);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(756, 130);
            this.panel16.TabIndex = 27;
            // 
            // grdEstaciones
            // 
            this.grdEstaciones.AllowUserToDeleteRows = false;
            this.grdEstaciones.AllowUserToResizeColumns = false;
            this.grdEstaciones.AllowUserToResizeRows = false;
            this.grdEstaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdEstaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdEstaciones.BackgroundColor = System.Drawing.Color.White;
            this.grdEstaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdEstaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEstaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEstaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDEstacionGrillaEstacion,
            this.ControlEstacion,
            this.CodigoGrillaEstacion,
            this.NombreGrillaEstacion,
            this.NitGrillaEstacion,
            this.DireccionGrillaEstacion,
            this.TelefonoGrillaEstacion,
            this.IdCiudadGrillaEstacion,
            this.TipoEstacion,
            this.ManejaLeyFrontera});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEstaciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdEstaciones.Location = new System.Drawing.Point(6, 20);
            this.grdEstaciones.MultiSelect = false;
            this.grdEstaciones.Name = "grdEstaciones";
            this.grdEstaciones.RowHeadersVisible = false;
            this.grdEstaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdEstaciones.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Transparent;
            this.grdEstaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEstaciones.Size = new System.Drawing.Size(747, 105);
            this.grdEstaciones.TabIndex = 0;
            this.grdEstaciones.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEstaciones_CellValueChanged);
            this.grdEstaciones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdEstaciones_DataError);
            // 
            // IDEstacionGrillaEstacion
            // 
            this.IDEstacionGrillaEstacion.DataPropertyName = "IdEstacion";
            this.IDEstacionGrillaEstacion.Frozen = true;
            this.IDEstacionGrillaEstacion.HeaderText = "Id";
            this.IDEstacionGrillaEstacion.Name = "IDEstacionGrillaEstacion";
            this.IDEstacionGrillaEstacion.ReadOnly = true;
            this.IDEstacionGrillaEstacion.Visible = false;
            this.IDEstacionGrillaEstacion.Width = 43;
            // 
            // ControlEstacion
            // 
            this.ControlEstacion.HeaderText = "Control";
            this.ControlEstacion.Name = "ControlEstacion";
            this.ControlEstacion.Visible = false;
            this.ControlEstacion.Width = 70;
            // 
            // CodigoGrillaEstacion
            // 
            this.CodigoGrillaEstacion.DataPropertyName = "Codigo";
            this.CodigoGrillaEstacion.HeaderText = "Código";
            this.CodigoGrillaEstacion.Name = "CodigoGrillaEstacion";
            this.CodigoGrillaEstacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CodigoGrillaEstacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CodigoGrillaEstacion.Width = 48;
            // 
            // NombreGrillaEstacion
            // 
            this.NombreGrillaEstacion.DataPropertyName = "Nombre";
            this.NombreGrillaEstacion.HeaderText = "Nombre";
            this.NombreGrillaEstacion.Name = "NombreGrillaEstacion";
            this.NombreGrillaEstacion.Width = 71;
            // 
            // NitGrillaEstacion
            // 
            this.NitGrillaEstacion.DataPropertyName = "Nit";
            this.NitGrillaEstacion.HeaderText = "Nit";
            this.NitGrillaEstacion.Name = "NitGrillaEstacion";
            this.NitGrillaEstacion.Width = 48;
            // 
            // DireccionGrillaEstacion
            // 
            this.DireccionGrillaEstacion.DataPropertyName = "Direccion";
            this.DireccionGrillaEstacion.HeaderText = "Dirección";
            this.DireccionGrillaEstacion.Name = "DireccionGrillaEstacion";
            this.DireccionGrillaEstacion.Width = 81;
            // 
            // TelefonoGrillaEstacion
            // 
            this.TelefonoGrillaEstacion.DataPropertyName = "Telefono";
            this.TelefonoGrillaEstacion.HeaderText = "Teléfono";
            this.TelefonoGrillaEstacion.Name = "TelefonoGrillaEstacion";
            this.TelefonoGrillaEstacion.Width = 74;
            // 
            // IdCiudadGrillaEstacion
            // 
            this.IdCiudadGrillaEstacion.DataPropertyName = "IdCiudad";
            this.IdCiudadGrillaEstacion.HeaderText = "Ciudad";
            this.IdCiudadGrillaEstacion.Items.AddRange(new object[] {
            "Seleccione"});
            this.IdCiudadGrillaEstacion.Name = "IdCiudadGrillaEstacion";
            this.IdCiudadGrillaEstacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IdCiudadGrillaEstacion.Width = 67;
            // 
            // TipoEstacion
            // 
            this.TipoEstacion.DataPropertyName = "IdTipoEds";
            this.TipoEstacion.HeaderText = "Tipo Estacion";
            this.TipoEstacion.Name = "TipoEstacion";
            this.TipoEstacion.Visible = false;
            // 
            // ManejaLeyFrontera
            // 
            this.ManejaLeyFrontera.DataPropertyName = "ManejaLeyFrontera";
            this.ManejaLeyFrontera.HeaderText = "Maneja Ley de Frontera";
            this.ManejaLeyFrontera.Name = "ManejaLeyFrontera";
            this.ManejaLeyFrontera.Visible = false;
            this.ManejaLeyFrontera.Width = 153;
            // 
            // lblEstacion
            // 
            this.lblEstacion.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblEstacion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEstacion.Location = new System.Drawing.Point(6, 3);
            this.lblEstacion.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.lblEstacion.Name = "lblEstacion";
            this.lblEstacion.Size = new System.Drawing.Size(739, 14);
            this.lblEstacion.TabIndex = 27;
            this.lblEstacion.Text = "ESTACIONES";
            this.lblEstacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.BackgroundImage = global::PosConfiguracion.Properties.Resources.IraVentanaConfiguracion;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditar.Location = new System.Drawing.Point(725, 10);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(33, 27);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // grdConfiguracion
            // 
            this.grdConfiguracion.AllowUserToAddRows = false;
            this.grdConfiguracion.AllowUserToDeleteRows = false;
            this.grdConfiguracion.AllowUserToResizeColumns = false;
            this.grdConfiguracion.AllowUserToResizeRows = false;
            this.grdConfiguracion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdConfiguracion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdConfiguracion.BackgroundColor = System.Drawing.Color.White;
            this.grdConfiguracion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdConfiguracion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdConfiguracion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdConfiguracion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Isla,
            this.Surtidor,
            this.Cara,
            this.Manguera});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdConfiguracion.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdConfiguracion.Location = new System.Drawing.Point(5, 47);
            this.grdConfiguracion.MultiSelect = false;
            this.grdConfiguracion.Name = "grdConfiguracion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdConfiguracion.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdConfiguracion.RowHeadersVisible = false;
            this.grdConfiguracion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdConfiguracion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdConfiguracion.Size = new System.Drawing.Size(757, 342);
            this.grdConfiguracion.TabIndex = 19;
            // 
            // Isla
            // 
            this.Isla.DataPropertyName = "Isla";
            this.Isla.Frozen = true;
            this.Isla.HeaderText = "Isla";
            this.Isla.Name = "Isla";
            this.Isla.ReadOnly = true;
            this.Isla.Width = 50;
            // 
            // Surtidor
            // 
            this.Surtidor.DataPropertyName = "Surtidor";
            this.Surtidor.HeaderText = "Surtidor";
            this.Surtidor.MaxInputLength = 255;
            this.Surtidor.Name = "Surtidor";
            this.Surtidor.ReadOnly = true;
            this.Surtidor.Width = 74;
            // 
            // Cara
            // 
            this.Cara.DataPropertyName = "Cara";
            this.Cara.HeaderText = "Cara";
            this.Cara.Name = "Cara";
            this.Cara.ReadOnly = true;
            this.Cara.Width = 57;
            // 
            // Manguera
            // 
            this.Manguera.DataPropertyName = "Manguera";
            this.Manguera.HeaderText = "Manguera";
            this.Manguera.Name = "Manguera";
            this.Manguera.ReadOnly = true;
            this.Manguera.Width = 82;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlVisualizarConfiguracion);
            this.groupBox1.Location = new System.Drawing.Point(19, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 561);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label24.Location = new System.Drawing.Point(359, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 27);
            this.label24.TabIndex = 57;
            this.label24.Text = "ESTACIÓN";
            // 
            // Visualizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox1);
            this.Name = "Visualizacion";
            this.Size = new System.Drawing.Size(821, 624);
            this.pnlVisualizarConfiguracion.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEstaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdConfiguracion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlVisualizarConfiguracion;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.DataGridView grdEstaciones;
        private System.Windows.Forms.Label lblEstacion;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView grdConfiguracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surtidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cara;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manguera;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDEstacionGrillaEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoGrillaEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreGrillaEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NitGrillaEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionGrillaEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoGrillaEstacion;
        private System.Windows.Forms.DataGridViewComboBoxColumn IdCiudadGrillaEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEstacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManejaLeyFrontera;
    }
}
