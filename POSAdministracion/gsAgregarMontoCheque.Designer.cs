namespace gasolutions.UInterface
{
    partial class gsAgregarMontoCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gsAgregarMontoCheque));
            this.panleClienteIdentificado = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.txtporcentaje = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontoMinimo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuip = new System.Windows.Forms.TextBox();
            this.lblCheque = new System.Windows.Forms.Label();
            this.toolTipClientes = new System.Windows.Forms.ToolTip(this.components);
            this.btnLimpiarClientePaso = new System.Windows.Forms.Button();
            this.btnGuardarPorClientePaso = new System.Windows.Forms.Button();
            this.cmbtipocliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelClientePaso = new System.Windows.Forms.Panel();
            this.txtMontoMaximoPaso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtporcentajeClientePaso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panleClienteIdentificado.SuspendLayout();
            this.PanelClientePaso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panleClienteIdentificado
            // 
            this.panleClienteIdentificado.Controls.Add(this.btnBuscar);
            this.panleClienteIdentificado.Controls.Add(this.btnCancelar);
            this.panleClienteIdentificado.Controls.Add(this.btnguardar);
            this.panleClienteIdentificado.Controls.Add(this.txtporcentaje);
            this.panleClienteIdentificado.Controls.Add(this.label2);
            this.panleClienteIdentificado.Controls.Add(this.txtMontoMinimo);
            this.panleClienteIdentificado.Controls.Add(this.label1);
            this.panleClienteIdentificado.Controls.Add(this.txtNuip);
            this.panleClienteIdentificado.Controls.Add(this.lblCheque);
            this.panleClienteIdentificado.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panleClienteIdentificado.Location = new System.Drawing.Point(8, 16);
            this.panleClienteIdentificado.Name = "panleClienteIdentificado";
            this.panleClienteIdentificado.Size = new System.Drawing.Size(355, 137);
            this.panleClienteIdentificado.TabIndex = 0;
            this.panleClienteIdentificado.Paint += new System.Windows.Forms.PaintEventHandler(this.panleClienteIdentificado_Paint);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnBuscar.Location = new System.Drawing.Point(309, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.TabIndex = 24;
            this.toolTipClientes.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(227, 95);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 36);
            this.btnCancelar.TabIndex = 23;
            this.toolTipClientes.SetToolTip(this.btnCancelar, "Limpiar");
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnguardar.Image = ((System.Drawing.Image)(resources.GetObject("btnguardar.Image")));
            this.btnguardar.Location = new System.Drawing.Point(182, 95);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(36, 36);
            this.btnguardar.TabIndex = 22;
            this.toolTipClientes.SetToolTip(this.btnguardar, "Guardar");
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtporcentaje
            // 
            this.txtporcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtporcentaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtporcentaje.Location = new System.Drawing.Point(134, 71);
            this.txtporcentaje.MaxLength = 50;
            this.txtporcentaje.Name = "txtporcentaje";
            this.txtporcentaje.Size = new System.Drawing.Size(205, 20);
            this.txtporcentaje.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Porcentaje Minimo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMontoMinimo
            // 
            this.txtMontoMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoMinimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoMinimo.Location = new System.Drawing.Point(134, 42);
            this.txtMontoMinimo.MaxLength = 50;
            this.txtMontoMinimo.Name = "txtMontoMinimo";
            this.txtMontoMinimo.Size = new System.Drawing.Size(205, 20);
            this.txtMontoMinimo.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 19;
            this.label1.Text = "Monto Maximo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNuip
            // 
            this.txtNuip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNuip.Location = new System.Drawing.Point(134, 11);
            this.txtNuip.MaxLength = 50;
            this.txtNuip.Name = "txtNuip";
            this.txtNuip.Size = new System.Drawing.Size(169, 20);
            this.txtNuip.TabIndex = 16;
            // 
            // lblCheque
            // 
            this.lblCheque.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblCheque.Location = new System.Drawing.Point(11, 11);
            this.lblCheque.Name = "lblCheque";
            this.lblCheque.Size = new System.Drawing.Size(47, 21);
            this.lblCheque.TabIndex = 17;
            this.lblCheque.Text = "Nuip";
            this.lblCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLimpiarClientePaso
            // 
            this.btnLimpiarClientePaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnLimpiarClientePaso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarClientePaso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarClientePaso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiarClientePaso.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarClientePaso.Image")));
            this.btnLimpiarClientePaso.Location = new System.Drawing.Point(227, 69);
            this.btnLimpiarClientePaso.Name = "btnLimpiarClientePaso";
            this.btnLimpiarClientePaso.Size = new System.Drawing.Size(36, 36);
            this.btnLimpiarClientePaso.TabIndex = 23;
            this.toolTipClientes.SetToolTip(this.btnLimpiarClientePaso, "Limpiar");
            this.btnLimpiarClientePaso.UseVisualStyleBackColor = false;
            // 
            // btnGuardarPorClientePaso
            // 
            this.btnGuardarPorClientePaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnGuardarPorClientePaso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarPorClientePaso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPorClientePaso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGuardarPorClientePaso.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarPorClientePaso.Image")));
            this.btnGuardarPorClientePaso.Location = new System.Drawing.Point(182, 68);
            this.btnGuardarPorClientePaso.Name = "btnGuardarPorClientePaso";
            this.btnGuardarPorClientePaso.Size = new System.Drawing.Size(36, 36);
            this.btnGuardarPorClientePaso.TabIndex = 22;
            this.toolTipClientes.SetToolTip(this.btnGuardarPorClientePaso, "Guardar");
            this.btnGuardarPorClientePaso.UseVisualStyleBackColor = false;
            this.btnGuardarPorClientePaso.Click += new System.EventHandler(this.btnGuardarPorClientePaso_Click);
            // 
            // cmbtipocliente
            // 
            this.cmbtipocliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtipocliente.FormattingEnabled = true;
            this.cmbtipocliente.Items.AddRange(new object[] {
            "Cliente Identificado",
            "Cliente de Paso"});
            this.cmbtipocliente.Location = new System.Drawing.Point(179, 17);
            this.cmbtipocliente.Name = "cmbtipocliente";
            this.cmbtipocliente.Size = new System.Drawing.Size(156, 21);
            this.cmbtipocliente.TabIndex = 1;
            this.cmbtipocliente.SelectedIndexChanged += new System.EventHandler(this.cmbtipocliente_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(70, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo de Cliente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelClientePaso
            // 
            this.PanelClientePaso.Controls.Add(this.txtMontoMaximoPaso);
            this.PanelClientePaso.Controls.Add(this.label5);
            this.PanelClientePaso.Controls.Add(this.btnLimpiarClientePaso);
            this.PanelClientePaso.Controls.Add(this.btnGuardarPorClientePaso);
            this.PanelClientePaso.Controls.Add(this.txtporcentajeClientePaso);
            this.PanelClientePaso.Controls.Add(this.label4);
            this.PanelClientePaso.Location = new System.Drawing.Point(8, 11);
            this.PanelClientePaso.Name = "PanelClientePaso";
            this.PanelClientePaso.Size = new System.Drawing.Size(355, 113);
            this.PanelClientePaso.TabIndex = 19;
            // 
            // txtMontoMaximoPaso
            // 
            this.txtMontoMaximoPaso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoMaximoPaso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontoMaximoPaso.Location = new System.Drawing.Point(123, 43);
            this.txtMontoMaximoPaso.MaxLength = 50;
            this.txtMontoMaximoPaso.Name = "txtMontoMaximoPaso";
            this.txtMontoMaximoPaso.Size = new System.Drawing.Size(216, 20);
            this.txtMontoMaximoPaso.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.Location = new System.Drawing.Point(10, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Monto Maximo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtporcentajeClientePaso
            // 
            this.txtporcentajeClientePaso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtporcentajeClientePaso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtporcentajeClientePaso.Location = new System.Drawing.Point(123, 17);
            this.txtporcentajeClientePaso.MaxLength = 50;
            this.txtporcentajeClientePaso.Name = "txtporcentajeClientePaso";
            this.txtporcentajeClientePaso.Size = new System.Drawing.Size(216, 20);
            this.txtporcentajeClientePaso.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(11, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Porcentaje Minimo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panleClienteIdentificado);
            this.groupBox1.Location = new System.Drawing.Point(17, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 162);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PanelClientePaso);
            this.groupBox2.Location = new System.Drawing.Point(17, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 128);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.cmbtipocliente);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(19, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 355);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label7.Location = new System.Drawing.Point(137, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 27);
            this.label7.TabIndex = 53;
            this.label7.Text = "MONTO CHEQUE";
            // 
            // gsAgregarMontoCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Name = "gsAgregarMontoCheque";
            this.Size = new System.Drawing.Size(447, 438);
            this.Load += new System.EventHandler(this.gsAgregarMontoCheque_Load);
            this.panleClienteIdentificado.ResumeLayout(false);
            this.panleClienteIdentificado.PerformLayout();
            this.PanelClientePaso.ResumeLayout(false);
            this.PanelClientePaso.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panleClienteIdentificado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolTip toolTipClientes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.TextBox txtporcentaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMontoMinimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuip;
        private System.Windows.Forms.Label lblCheque;
        private System.Windows.Forms.ComboBox cmbtipocliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PanelClientePaso;
        private System.Windows.Forms.Button btnLimpiarClientePaso;
        private System.Windows.Forms.Button btnGuardarPorClientePaso;
        private System.Windows.Forms.TextBox txtporcentajeClientePaso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMontoMaximoPaso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
    }
}
