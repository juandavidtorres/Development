namespace gasolutions.UInterface
{
    partial class FrmCreditoPorVehiculo
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
            this.gsCreditos1 = new PosSation.gsCreditos.gsCreditos();
            this.SuspendLayout();
            // 
            // gsCreditos1
            // 
            this.gsCreditos1.AutoSize = true;
            this.gsCreditos1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gsCreditos1.BackColor = System.Drawing.Color.White;
            this.gsCreditos1.Credito = 0;
            this.gsCreditos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gsCreditos1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gsCreditos1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.gsCreditos1.Location = new System.Drawing.Point(0, 0);
            this.gsCreditos1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gsCreditos1.Name = "gsCreditos1";
            this.gsCreditos1.Size = new System.Drawing.Size(740, 498);
            this.gsCreditos1.TabIndex = 0;
            // 
            // FrmCreeditoPorVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 498);
            this.Controls.Add(this.gsCreditos1);
            this.Name = "FrmCreeditoPorVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credito";
            this.Load += new System.EventHandler(this.FrmCreeditoPorVehiculo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PosSation.gsCreditos.gsCreditos gsCreditos1;
    }
}