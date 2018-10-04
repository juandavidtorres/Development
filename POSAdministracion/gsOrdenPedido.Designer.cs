namespace gasolutions.UInterface
{
    partial class gsOrdenPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlAdicionProducto = new System.Windows.Forms.Panel();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProductoText = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDetOrden = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtElaborado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoOrden = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tosMenus = new System.Windows.Forms.ToolStrip();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnHelpProducto = new System.Windows.Forms.Button();
            this.mnuNew = new System.Windows.Forms.ToolStripButton();
            this.mnuPrint = new System.Windows.Forms.ToolStripButton();
            this.mnuGuardar = new System.Windows.Forms.ToolStripButton();
            this.mnuDeshacer = new System.Windows.Forms.ToolStripButton();
            this.mnuCerrar = new System.Windows.Forms.ToolStripButton();
            this.pnlContenedor.SuspendLayout();
            this.pnlAdicionProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetOrden)).BeginInit();
            this.tosMenus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.pnlAdicionProducto);
            this.pnlContenedor.Controls.Add(this.label5);
            this.pnlContenedor.Controls.Add(this.dgvDetOrden);
            this.pnlContenedor.Controls.Add(this.txtComentario);
            this.pnlContenedor.Controls.Add(this.label4);
            this.pnlContenedor.Controls.Add(this.txtElaborado);
            this.pnlContenedor.Controls.Add(this.label3);
            this.pnlContenedor.Controls.Add(this.dtpFecha);
            this.pnlContenedor.Controls.Add(this.label2);
            this.pnlContenedor.Controls.Add(this.txtNoOrden);
            this.pnlContenedor.Controls.Add(this.label1);
            this.pnlContenedor.Controls.Add(this.tosMenus);
            this.pnlContenedor.Location = new System.Drawing.Point(16, 16);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(629, 650);
            this.pnlContenedor.TabIndex = 0;
            // 
            // pnlAdicionProducto
            // 
            this.pnlAdicionProducto.Controls.Add(this.btnAdicionar);
            this.pnlAdicionProducto.Controls.Add(this.txtCantidad);
            this.pnlAdicionProducto.Controls.Add(this.lblProductoText);
            this.pnlAdicionProducto.Controls.Add(this.btnHelpProducto);
            this.pnlAdicionProducto.Controls.Add(this.txtCodigo);
            this.pnlAdicionProducto.Controls.Add(this.label6);
            this.pnlAdicionProducto.Location = new System.Drawing.Point(3, 201);
            this.pnlAdicionProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlAdicionProducto.Name = "pnlAdicionProducto";
            this.pnlAdicionProducto.Size = new System.Drawing.Size(619, 33);
            this.pnlAdicionProducto.TabIndex = 27;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(515, 6);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(69, 20);
            this.txtCantidad.TabIndex = 22;
            this.txtCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCantidad_KeyDown);
            // 
            // lblProductoText
            // 
            this.lblProductoText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProductoText.Location = new System.Drawing.Point(209, 4);
            this.lblProductoText.Name = "lblProductoText";
            this.lblProductoText.Size = new System.Drawing.Size(300, 24);
            this.lblProductoText.TabIndex = 21;
            this.lblProductoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(83, 6);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(93, 20);
            this.txtCodigo.TabIndex = 19;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Producto:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(619, 28);
            this.label5.TabIndex = 26;
            this.label5.Text = "DETALLE DE LA ORDEN ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetOrden
            // 
            this.dgvDetOrden.AllowUserToAddRows = false;
            this.dgvDetOrden.AllowUserToDeleteRows = false;
            this.dgvDetOrden.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetOrden.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Producto,
            this.Cantidad});
            this.dgvDetOrden.Location = new System.Drawing.Point(3, 235);
            this.dgvDetOrden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDetOrden.Name = "dgvDetOrden";
            this.dgvDetOrden.ReadOnly = true;
            this.dgvDetOrden.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetOrden.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetOrden.RowHeadersVisible = false;
            this.dgvDetOrden.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetOrden.Size = new System.Drawing.Size(619, 409);
            this.dgvDetOrden.TabIndex = 25;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 70;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 280;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 70;
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.Color.White;
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Location = new System.Drawing.Point(87, 82);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(535, 81);
            this.txtComentario.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Comentarios:";
            // 
            // txtElaborado
            // 
            this.txtElaborado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElaborado.Location = new System.Drawing.Point(513, 55);
            this.txtElaborado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtElaborado.Name = "txtElaborado";
            this.txtElaborado.Size = new System.Drawing.Size(109, 20);
            this.txtElaborado.TabIndex = 22;
            this.txtElaborado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtElaborado_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(339, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Elaborado (No. Documento):";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(238, 55);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(95, 20);
            this.dtpFecha.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha:";
            // 
            // txtNoOrden
            // 
            this.txtNoOrden.BackColor = System.Drawing.Color.White;
            this.txtNoOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOrden.Location = new System.Drawing.Point(87, 55);
            this.txtNoOrden.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoOrden.Name = "txtNoOrden";
            this.txtNoOrden.ReadOnly = true;
            this.txtNoOrden.Size = new System.Drawing.Size(93, 20);
            this.txtNoOrden.TabIndex = 18;
            this.txtNoOrden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoOrden_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "No. Orden:";
            // 
            // tosMenus
            // 
            this.tosMenus.BackColor = System.Drawing.Color.White;
            this.tosMenus.Dock = System.Windows.Forms.DockStyle.None;
            this.tosMenus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tosMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuPrint,
            this.mnuGuardar,
            this.mnuDeshacer,
            this.mnuCerrar});
            this.tosMenus.Location = new System.Drawing.Point(421, 4);
            this.tosMenus.Name = "tosMenus";
            this.tosMenus.Size = new System.Drawing.Size(201, 40);
            this.tosMenus.TabIndex = 16;
            this.tosMenus.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlContenedor);
            this.groupBox1.Location = new System.Drawing.Point(15, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(660, 679);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(259, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 27);
            this.label7.TabIndex = 54;
            this.label7.Text = "ORDEN DE PEDIDO";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnAdicionar.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Mas;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdicionar.Location = new System.Drawing.Point(588, 4);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(26, 25);
            this.btnAdicionar.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnAdicionar, "Adicionar Producto");
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnHelpProducto
            // 
            this.btnHelpProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnHelpProducto.BackgroundImage = global::gasolutions.UInterface.Properties.Resources.Bucar16;
            this.btnHelpProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHelpProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelpProducto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelpProducto.Location = new System.Drawing.Point(178, 4);
            this.btnHelpProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHelpProducto.Name = "btnHelpProducto";
            this.btnHelpProducto.Size = new System.Drawing.Size(26, 25);
            this.btnHelpProducto.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnHelpProducto, "Consultar Producto");
            this.btnHelpProducto.UseVisualStyleBackColor = false;
            this.btnHelpProducto.Click += new System.EventHandler(this.btnHelpProducto_Click);
            // 
            // mnuNew
            // 
            this.mnuNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuNew.Image = global::gasolutions.UInterface.Properties.Resources.Nuevo__2_;
            this.mnuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuNew.Margin = new System.Windows.Forms.Padding(2);
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(35, 36);
            this.mnuNew.Text = "Nuevo";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuPrint
            // 
            this.mnuPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuPrint.Image = global::gasolutions.UInterface.Properties.Resources.Imprimir;
            this.mnuPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPrint.Margin = new System.Windows.Forms.Padding(2);
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(35, 36);
            this.mnuPrint.Text = "Buscar";
            this.mnuPrint.ToolTipText = "Imprimir";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
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
            // mnuDeshacer
            // 
            this.mnuDeshacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.mnuDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuDeshacer.Image = global::gasolutions.UInterface.Properties.Resources.Actualizar__2_;
            this.mnuDeshacer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDeshacer.Margin = new System.Windows.Forms.Padding(2);
            this.mnuDeshacer.Name = "mnuDeshacer";
            this.mnuDeshacer.Size = new System.Drawing.Size(37, 36);
            this.mnuDeshacer.Text = "toolStripButton1";
            this.mnuDeshacer.ToolTipText = "Deshacer";
            this.mnuDeshacer.Click += new System.EventHandler(this.mnuDeshacer_Click);
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
            // gsOrdenPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "gsOrdenPedido";
            this.Size = new System.Drawing.Size(688, 742);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.pnlAdicionProducto.ResumeLayout(false);
            this.pnlAdicionProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetOrden)).EndInit();
            this.tosMenus.ResumeLayout(false);
            this.tosMenus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.ToolStrip tosMenus;
        private System.Windows.Forms.ToolStripButton mnuNew;
        private System.Windows.Forms.ToolStripButton mnuPrint;
        private System.Windows.Forms.ToolStripButton mnuGuardar;
        private System.Windows.Forms.ToolStripButton mnuDeshacer;
        private System.Windows.Forms.ToolStripButton mnuCerrar;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtElaborado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoOrden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDetOrden;
        private System.Windows.Forms.Panel pnlAdicionProducto;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHelpProducto;
        private System.Windows.Forms.Label lblProductoText;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}
