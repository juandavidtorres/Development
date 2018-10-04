namespace gasolutions.UInterface
{
    partial class FrmBuscarTarjeta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabOpciones = new System.Windows.Forms.TabControl();
            this.tpBuscarTarjeta = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.grillaTrajeta = new System.Windows.Forms.DataGridView();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNuip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpCrearTarjeta = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnbuscarTarjeta = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabOpciones.SuspendLayout();
            this.tpBuscarTarjeta.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTrajeta)).BeginInit();
            this.tpCrearTarjeta.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOpciones
            // 
            this.tabOpciones.Controls.Add(this.tpBuscarTarjeta);
            this.tabOpciones.Controls.Add(this.tpCrearTarjeta);
            this.tabOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOpciones.HotTrack = true;
            this.tabOpciones.Location = new System.Drawing.Point(0, 0);
            this.tabOpciones.Name = "tabOpciones";
            this.tabOpciones.SelectedIndex = 0;
            this.tabOpciones.Size = new System.Drawing.Size(402, 254);
            this.tabOpciones.TabIndex = 0;
            // 
            // tpBuscarTarjeta
            // 
            this.tpBuscarTarjeta.Controls.Add(this.panel1);
            this.tpBuscarTarjeta.Location = new System.Drawing.Point(4, 22);
            this.tpBuscarTarjeta.Name = "tpBuscarTarjeta";
            this.tpBuscarTarjeta.Padding = new System.Windows.Forms.Padding(3);
            this.tpBuscarTarjeta.Size = new System.Drawing.Size(394, 228);
            this.tpBuscarTarjeta.TabIndex = 0;
            this.tpBuscarTarjeta.Text = "Buscar Tarjeta";
            this.tpBuscarTarjeta.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.grillaTrajeta);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txtNuip);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 218);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(32, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 18);
            this.label2.TabIndex = 63;
            this.label2.Text = "TARJETA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grillaTrajeta
            // 
            this.grillaTrajeta.AllowUserToAddRows = false;
            this.grillaTrajeta.BackgroundColor = System.Drawing.Color.White;
            this.grillaTrajeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTrajeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCliente,
            this.Tarjeta});
            this.grillaTrajeta.Location = new System.Drawing.Point(3, 74);
            this.grillaTrajeta.Name = "grillaTrajeta";
            this.grillaTrajeta.RowHeadersVisible = false;
            this.grillaTrajeta.Size = new System.Drawing.Size(374, 133);
            this.grillaTrajeta.TabIndex = 62;
            this.grillaTrajeta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTrajeta_CellDoubleClick);
            // 
            // IdCliente
            // 
            this.IdCliente.DataPropertyName = "IdCliente";
            this.IdCliente.HeaderText = "IdCliente";
            this.IdCliente.Name = "IdCliente";
            // 
            // Tarjeta
            // 
            this.Tarjeta.DataPropertyName = "Numero";
            this.Tarjeta.HeaderText = "Tarjeta";
            this.Tarjeta.Name = "Tarjeta";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnBuscar.Location = new System.Drawing.Point(326, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.TabIndex = 61;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // txtNuip
            // 
            this.txtNuip.BackColor = System.Drawing.Color.White;
            this.txtNuip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNuip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuip.Location = new System.Drawing.Point(116, 39);
            this.txtNuip.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.txtNuip.Name = "txtNuip";
            this.txtNuip.Size = new System.Drawing.Size(198, 21);
            this.txtNuip.TabIndex = 59;
            this.txtNuip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "NUIP del Cliente";
            // 
            // tpCrearTarjeta
            // 
            this.tpCrearTarjeta.Controls.Add(this.groupBox1);
            this.tpCrearTarjeta.Controls.Add(this.label3);
            this.tpCrearTarjeta.Location = new System.Drawing.Point(4, 22);
            this.tpCrearTarjeta.Name = "tpCrearTarjeta";
            this.tpCrearTarjeta.Padding = new System.Windows.Forms.Padding(3);
            this.tpCrearTarjeta.Size = new System.Drawing.Size(394, 228);
            this.tpCrearTarjeta.TabIndex = 1;
            this.tpCrearTarjeta.Text = "Crear Tarjeta";
            this.tpCrearTarjeta.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(8, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 144);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnguardar);
            this.panel2.Controls.Add(this.btnbuscarTarjeta);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtCliente);
            this.panel2.Controls.Add(this.txtTarjeta);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(20, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 95);
            this.panel2.TabIndex = 66;
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnguardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Image = global::gasolutions.UInterface.Properties.Resources.Guardar__2_;
            this.btnguardar.Location = new System.Drawing.Point(270, 52);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(34, 34);
            this.btnguardar.TabIndex = 66;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnbuscarTarjeta
            // 
            this.btnbuscarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnbuscarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarTarjeta.Image = global::gasolutions.UInterface.Properties.Resources.Busqueda;
            this.btnbuscarTarjeta.Location = new System.Drawing.Point(270, 11);
            this.btnbuscarTarjeta.Name = "btnbuscarTarjeta";
            this.btnbuscarTarjeta.Size = new System.Drawing.Size(34, 34);
            this.btnbuscarTarjeta.TabIndex = 65;
            this.btnbuscarTarjeta.UseVisualStyleBackColor = false;
            this.btnbuscarTarjeta.Click += new System.EventHandler(this.btnbuscarTarjeta_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(31, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 64;
            this.label5.Text = "Tarjeta";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(86, 17);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(178, 20);
            this.txtCliente.TabIndex = 63;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarjeta.Location = new System.Drawing.Point(86, 58);
            this.txtTarjeta.MaxLength = 50;
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(178, 20);
            this.txtTarjeta.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(31, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 6, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(80, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 18);
            this.label3.TabIndex = 64;
            this.label3.Text = "TARJETA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmBuscarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 254);
            this.Controls.Add(this.tabOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuscarTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmBuscarTarjeta_Load);
            this.tabOpciones.ResumeLayout(false);
            this.tpBuscarTarjeta.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTrajeta)).EndInit();
            this.tpCrearTarjeta.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOpciones;
        private System.Windows.Forms.TabPage tpBuscarTarjeta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grillaTrajeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarjeta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNuip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpCrearTarjeta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnbuscarTarjeta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}