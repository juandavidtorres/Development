namespace gasolutions.UInterface
{
    partial class FrmVehiculoVenta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtrecibo = new System.Windows.Forms.TextBox();
            this.btnAgregarCredito = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btncancelar);
            this.groupBox1.Controls.Add(this.btnAgregarCredito);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtrecibo);
            this.groupBox1.Controls.Add(this.lblDocumento);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblDocumento
            // 
            this.lblDocumento.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.lblDocumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDocumento.Location = new System.Drawing.Point(15, 21);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(59, 18);
            this.lblDocumento.TabIndex = 52;
            this.lblDocumento.Text = "Placa:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(83, 20);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(174, 20);
            this.txtCliente.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 54;
            this.label1.Text = "Recibo:";
            // 
            // txtrecibo
            // 
            this.txtrecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtrecibo.Location = new System.Drawing.Point(83, 48);
            this.txtrecibo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtrecibo.Name = "txtrecibo";
            this.txtrecibo.Size = new System.Drawing.Size(174, 20);
            this.txtrecibo.TabIndex = 1;
            // 
            // btnAgregarCredito
            // 
            this.btnAgregarCredito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btnAgregarCredito.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregarCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCredito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCredito.Image = global::gasolutions.UInterface.Properties.Resources.Agregar1;
            this.btnAgregarCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCredito.Location = new System.Drawing.Point(83, 75);
            this.btnAgregarCredito.Name = "btnAgregarCredito";
            this.btnAgregarCredito.Size = new System.Drawing.Size(90, 35);
            this.btnAgregarCredito.TabIndex = 2;
            this.btnAgregarCredito.Text = "Guardar";
            this.btnAgregarCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCredito.UseVisualStyleBackColor = false;
            this.btnAgregarCredito.Click += new System.EventHandler(this.btnAgregarCredito_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(26)))));
            this.btncancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancelar.ForeColor = System.Drawing.Color.White;
            this.btncancelar.Image = global::gasolutions.UInterface.Properties.Resources.Cancel;
            this.btncancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancelar.Location = new System.Drawing.Point(179, 75);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(90, 35);
            this.btncancelar.TabIndex = 3;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // FrmVehiculoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 148);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmVehiculoVenta";
            this.Text = "Asignar placa a venta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtrecibo;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnAgregarCredito;
        private System.Windows.Forms.Button btncancelar;
    }
}