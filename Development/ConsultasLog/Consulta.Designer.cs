namespace ConsultasLog {
	partial class FormPrincipal {
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
			this.ddlProceso = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.horaFinal = new System.Windows.Forms.DateTimePicker();
			this.horaInicial = new System.Windows.Forms.DateTimePicker();
			this.fechaFinal = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.fechaInicial = new System.Windows.Forms.DateTimePicker();
			this.GridDatos = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonBuscar = new System.Windows.Forms.Button();
			this.panelFiltros2 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonAdicionarFiltro = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.GridDatos)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ddlProceso
			// 
			this.ddlProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlProceso.FormattingEnabled = true;
			this.ddlProceso.Location = new System.Drawing.Point(18, 104);
			this.ddlProceso.Name = "ddlProceso";
			this.ddlProceso.Size = new System.Drawing.Size(295, 21);
			this.ddlProceso.TabIndex = 5;
			this.ddlProceso.SelectedIndexChanged += new System.EventHandler(this.ddlProceso_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(144, 90);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Proceso";
			// 
			// horaFinal
			// 
			this.horaFinal.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.horaFinal.CustomFormat = "HH:mm";
			this.horaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.horaFinal.Location = new System.Drawing.Point(385, 24);
			this.horaFinal.Name = "horaFinal";
			this.horaFinal.ShowUpDown = true;
			this.horaFinal.Size = new System.Drawing.Size(97, 20);
			this.horaFinal.TabIndex = 4;
			this.horaFinal.Value = new System.DateTime(2013, 4, 4, 23, 59, 59, 0);
			// 
			// horaInicial
			// 
			this.horaInicial.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.horaInicial.CustomFormat = "HH:mm";
			this.horaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.horaInicial.Location = new System.Drawing.Point(128, 24);
			this.horaInicial.Name = "horaInicial";
			this.horaInicial.ShowUpDown = true;
			this.horaInicial.Size = new System.Drawing.Size(97, 20);
			this.horaInicial.TabIndex = 2;
			this.horaInicial.Value = new System.DateTime(2013, 4, 4, 0, 0, 0, 0);
			// 
			// fechaFinal
			// 
			this.fechaFinal.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.fechaFinal.CustomFormat = "dd/MM/yyyy";
			this.fechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.fechaFinal.Location = new System.Drawing.Point(266, 24);
			this.fechaFinal.Name = "fechaFinal";
			this.fechaFinal.Size = new System.Drawing.Size(97, 20);
			this.fechaFinal.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(418, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Hora";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(162, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Hora";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(284, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Fecha Final";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Fecha Inicial";
			// 
			// fechaInicial
			// 
			this.fechaInicial.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.fechaInicial.CustomFormat = "dd/MM/yyyy";
			this.fechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.fechaInicial.Location = new System.Drawing.Point(10, 24);
			this.fechaInicial.Name = "fechaInicial";
			this.fechaInicial.Size = new System.Drawing.Size(97, 20);
			this.fechaInicial.TabIndex = 1;
			// 
			// GridDatos
			// 
			this.GridDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.GridDatos.Location = new System.Drawing.Point(0, 265);
			this.GridDatos.Name = "GridDatos";
			this.GridDatos.Size = new System.Drawing.Size(792, 296);
			this.GridDatos.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonBuscar);
			this.groupBox1.Controls.Add(this.panelFiltros2);
			this.groupBox1.Controls.Add(this.tableLayoutPanel1);
			this.groupBox1.Controls.Add(this.buttonAdicionarFiltro);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ddlProceso);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(792, 259);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// buttonBuscar
			// 
			this.buttonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuscar.Image")));
			this.buttonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBuscar.Location = new System.Drawing.Point(380, 104);
			this.buttonBuscar.Name = "buttonBuscar";
			this.buttonBuscar.Size = new System.Drawing.Size(136, 23);
			this.buttonBuscar.TabIndex = 9;
			this.buttonBuscar.Text = "Realizar Búsqueda";
			this.buttonBuscar.UseVisualStyleBackColor = true;
			this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
			// 
			// panelFiltros2
			// 
			this.panelFiltros2.AutoScroll = true;
			this.panelFiltros2.Location = new System.Drawing.Point(18, 131);
			this.panelFiltros2.Name = "panelFiltros2";
			this.panelFiltros2.Size = new System.Drawing.Size(762, 116);
			this.panelFiltros2.TabIndex = 5;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.fechaInicial, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.horaFinal, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.horaInicial, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.fechaFinal, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 21);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(493, 63);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// buttonAdicionarFiltro
			// 
			this.buttonAdicionarFiltro.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.buttonAdicionarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAdicionarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
			this.buttonAdicionarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAdicionarFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAdicionarFiltro.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionarFiltro.Image")));
			this.buttonAdicionarFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAdicionarFiltro.Location = new System.Drawing.Point(324, 104);
			this.buttonAdicionarFiltro.Name = "buttonAdicionarFiltro";
			this.buttonAdicionarFiltro.Size = new System.Drawing.Size(30, 21);
			this.buttonAdicionarFiltro.TabIndex = 7;
			this.buttonAdicionarFiltro.UseVisualStyleBackColor = false;
			this.buttonAdicionarFiltro.Click += new System.EventHandler(this.buttonAdicionarFiltro_Click);
			// 
			// FormPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.GridDatos);
			this.Name = "FormPrincipal";
			this.Text = "Consultador Log";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FormPrincipal_Load);
			((System.ComponentModel.ISupportInitialize)(this.GridDatos)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox ddlProceso;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker horaFinal;
		private System.Windows.Forms.DateTimePicker horaInicial;
		private System.Windows.Forms.DateTimePicker fechaFinal;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker fechaInicial;
		private System.Windows.Forms.DataGridView GridDatos;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonAdicionarFiltro;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel panelFiltros2;
		private System.Windows.Forms.Button buttonBuscar;
	}
}

