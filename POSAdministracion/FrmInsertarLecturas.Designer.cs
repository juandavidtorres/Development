namespace gasolutions.UInterface
{
    partial class FrmInsertarLecturas
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
            this.ctrInsertarLecturas = new gasolutions.UInterface.InsertarLecturaVenta();
            this.SuspendLayout();
            // 
            // ctrInsertarLecturas
            // 
            this.ctrInsertarLecturas.BackColor = System.Drawing.Color.White;
            this.ctrInsertarLecturas.Cantidad = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctrInsertarLecturas.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrInsertarLecturas.IdBloqueo = 0;
            this.ctrInsertarLecturas.LecturaFinal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctrInsertarLecturas.LecturaInicial = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctrInsertarLecturas.Location = new System.Drawing.Point(-1, -1);
            this.ctrInsertarLecturas.Manguera = 0;
            this.ctrInsertarLecturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrInsertarLecturas.Name = "ctrInsertarLecturas";
            this.ctrInsertarLecturas.Precio = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctrInsertarLecturas.Producto = 0;
            this.ctrInsertarLecturas.Size = new System.Drawing.Size(553, 678);
            this.ctrInsertarLecturas.TabIndex = 0;
            this.ctrInsertarLecturas.Turno = 0;
            // 
            // FrmInsertarLecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(548, 671);
            this.ControlBox = false;
            this.Controls.Add(this.ctrInsertarLecturas);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInsertarLecturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas Fuera de Sistema";
            this.Load += new System.EventHandler(this.FrmInsertarLecturas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private InsertarLecturaVenta ctrInsertarLecturas;
    }
}