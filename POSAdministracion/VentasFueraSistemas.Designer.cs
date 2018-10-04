namespace gasolutions.UInterface
{
    partial class VentasFueraSistemas
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
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpFechaTurnos = new System.Windows.Forms.DateTimePicker();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnImpresora = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.grdTurnos = new System.Windows.Forms.DataGridView();
            this.IdBloqueo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manguera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LecturaInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LecturaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Popup = new PopupNotifier();
            this.toolTextVentasFueraSistema = new System.Windows.Forms.ToolTip(this.components);
            this.btnsalir = new System.Windows.Forms.Button();
            this.ImpgrdTurnos = new System.Drawing.Printing.PrintDocument();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.White;
            this.pnlPrincipal.Controls.Add(this.btnConsultar);
            this.pnlPrincipal.Controls.Add(this.dtpFechaTurnos);
            this.pnlPrincipal.Controls.Add(this.lblDetalle);
            this.pnlPrincipal.Controls.Add(this.btnImpresora);
            this.pnlPrincipal.Controls.Add(this.btnExportar);
            this.pnlPrincipal.Controls.Add(this.grdTurnos);
            this.pnlPrincipal.Location = new System.Drawing.Point(12, 22);
            this.pnlPrincipal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(568, 327);
            this.pnlPrincipal.TabIndex = 50;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnConsultar.Location = new System.Drawing.Point(354, 4);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(34, 34);
            this.btnConsultar.TabIndex = 29;
            this.toolTextVentasFueraSistema.SetToolTip(this.btnConsultar, "Buscar");
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpFechaTurnos
            // 
            this.dtpFechaTurnos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTurnos.Location = new System.Drawing.Point(236, 11);
            this.dtpFechaTurnos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaTurnos.Name = "dtpFechaTurnos";
            this.dtpFechaTurnos.Size = new System.Drawing.Size(104, 20);
            this.dtpFechaTurnos.TabIndex = 28;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDetalle.Location = new System.Drawing.Point(144, 10);
            this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(90, 22);
            this.lblDetalle.TabIndex = 27;
            this.lblDetalle.Text = "CONSULTAR";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImpresora
            // 
            this.btnImpresora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnImpresora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpresora.Image = global::gasolutions.UInterface.Properties.Resources.Imprimir;
            this.btnImpresora.Location = new System.Drawing.Point(485, 288);
            this.btnImpresora.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImpresora.Name = "btnImpresora";
            this.btnImpresora.Size = new System.Drawing.Size(34, 34);
            this.btnImpresora.TabIndex = 10;
            this.toolTextVentasFueraSistema.SetToolTip(this.btnImpresora, "Exportar");
            this.btnImpresora.UseVisualStyleBackColor = false;
            this.btnImpresora.Click += new System.EventHandler(this.btnImpresora_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Image = global::gasolutions.UInterface.Properties.Resources.Export;
            this.btnExportar.Location = new System.Drawing.Point(525, 288);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(34, 34);
            this.btnExportar.TabIndex = 9;
            this.toolTextVentasFueraSistema.SetToolTip(this.btnExportar, "Exportar");
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // grdTurnos
            // 
            this.grdTurnos.AllowUserToAddRows = false;
            this.grdTurnos.AllowUserToDeleteRows = false;
            this.grdTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdTurnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdTurnos.BackgroundColor = System.Drawing.Color.White;
            this.grdTurnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdTurnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.grdTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdBloqueo,
            this.Turno,
            this.Manguera,
            this.LecturaInicial,
            this.LecturaFinal,
            this.Producto,
            this.Precio,
            this.Cantidad});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdTurnos.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdTurnos.Location = new System.Drawing.Point(8, 46);
            this.grdTurnos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdTurnos.MultiSelect = false;
            this.grdTurnos.Name = "grdTurnos";
            this.grdTurnos.RowHeadersVisible = false;
            this.grdTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTurnos.Size = new System.Drawing.Size(551, 234);
            this.grdTurnos.TabIndex = 8;
            this.grdTurnos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTurnos_CellContentDoubleClick);
            // 
            // IdBloqueo
            // 
            this.IdBloqueo.DataPropertyName = "IdBloqueo";
            this.IdBloqueo.HeaderText = "IdBloqueo";
            this.IdBloqueo.Name = "IdBloqueo";
            this.IdBloqueo.Visible = false;
            this.IdBloqueo.Width = 61;
            // 
            // Turno
            // 
            this.Turno.DataPropertyName = "Turno";
            this.Turno.HeaderText = "Turno";
            this.Turno.Name = "Turno";
            this.Turno.ReadOnly = true;
            this.Turno.Width = 62;
            // 
            // Manguera
            // 
            this.Manguera.DataPropertyName = "Manguera";
            this.Manguera.HeaderText = "Manguera";
            this.Manguera.Name = "Manguera";
            this.Manguera.ReadOnly = true;
            this.Manguera.Width = 82;
            // 
            // LecturaInicial
            // 
            this.LecturaInicial.DataPropertyName = "LecturaInicial";
            this.LecturaInicial.HeaderText = "LecturaInicial";
            this.LecturaInicial.Name = "LecturaInicial";
            this.LecturaInicial.ReadOnly = true;
            this.LecturaInicial.Width = 103;
            // 
            // LecturaFinal
            // 
            this.LecturaFinal.DataPropertyName = "LecturaFinal";
            this.LecturaFinal.HeaderText = "LecturaFinal";
            this.LecturaFinal.Name = "LecturaFinal";
            this.LecturaFinal.ReadOnly = true;
            this.LecturaFinal.Width = 96;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 79;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 65;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 78;
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
            // toolTextVentasFueraSistema
            // 
            this.toolTextVentasFueraSistema.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnsalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btnsalir.Location = new System.Drawing.Point(576, 4);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(34, 34);
            this.btnsalir.TabIndex = 30;
            this.toolTextVentasFueraSistema.SetToolTip(this.btnsalir, "Salir");
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // ImpgrdTurnos
            // 
            this.ImpgrdTurnos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.ImpgrdTurnos_PrintPage);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(19, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(591, 357);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(169, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 27);
            this.label7.TabIndex = 58;
            this.label7.Text = "VENTAS FUERA DEL SISTEMA";
            // 
            // VentasFueraSistemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VentasFueraSistemas";
            this.Size = new System.Drawing.Size(628, 456);
            this.pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.DateTimePicker dtpFechaTurnos;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnConsultar;
        internal PopupNotifier Popup;
        private System.Windows.Forms.DataGridView grdTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdBloqueo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manguera;
        private System.Windows.Forms.DataGridViewTextBoxColumn LecturaInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn LecturaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.ToolTip toolTextVentasFueraSistema;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnImpresora;
        private System.Drawing.Printing.PrintDocument ImpgrdTurnos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;

    }
}
