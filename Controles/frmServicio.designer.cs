namespace gasolutions.Configurador
{
    partial class frmServicio
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
            this.components = new System.ComponentModel.Container();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.btnReintentar = new System.Windows.Forms.Button();
            this.Controlador = new System.ServiceProcess.ServiceController();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tmrRetardo = new System.Windows.Forms.Timer(this.components);
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 12);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.Size = new System.Drawing.Size(187, 40);
            this.TextBox1.TabIndex = 7;
            this.TextBox1.Text = "Esperando el inicio del motor de datos\r\n(Sql Server 2005)...";
            // 
            // btnReintentar
            // 
            this.btnReintentar.Enabled = false;
            this.btnReintentar.Location = new System.Drawing.Point(23, 58);
            this.btnReintentar.Name = "btnReintentar";
            this.btnReintentar.Size = new System.Drawing.Size(75, 23);
            this.btnReintentar.TabIndex = 6;
            this.btnReintentar.Text = "Reintentar";
            this.btnReintentar.UseVisualStyleBackColor = true;
            this.btnReintentar.Click += new System.EventHandler(this.btnReintentar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(114, 58);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tmrRetardo
            // 
            this.tmrRetardo.Interval = 2000;
            this.tmrRetardo.Tick += new System.EventHandler(this.tmrRetardo_Tick);
            // 
            // frmServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 93);
            this.ControlBox = false;
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.btnReintentar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmServicio";
            this.Text = "Consultando el servicio";
            this.Load += new System.EventHandler(this.frmServicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button btnReintentar;
        internal System.ServiceProcess.ServiceController Controlador;
        internal System.Windows.Forms.Button btnCancelar;
        internal System.Windows.Forms.Timer tmrRetardo;
        private System.ServiceProcess.ServiceController serviceController1;
    }
}