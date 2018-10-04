namespace PosConfiguracion
{
    partial class ValidarUsuario
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
            this.gsInicioSesion = new Controles.gsInicioSesion();
            this.SuspendLayout();
            // 
            // gsInicioSesion
            // 
            this.gsInicioSesion.BackColor = System.Drawing.Color.White;
            this.gsInicioSesion.Location = new System.Drawing.Point(2, 0);
            this.gsInicioSesion.Name = "gsInicioSesion";
            this.gsInicioSesion.Size = new System.Drawing.Size(449, 222);
            this.gsInicioSesion.TabIndex = 0;
            this.gsInicioSesion.EventoCerrarFormulario += new Controles.gsInicioSesion.EventoCierreFormulario(this.gsInicioSesion_EventoCerrarFormulario);
            this.gsInicioSesion.EventoAutenticacionApropada += new Controles.gsInicioSesion.EventoAutenticacionExitosa(this.gsInicioSesion_EventoAutenticacionApropada);
            // 
            // ValidarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 220);
            this.ControlBox = false;
            this.Controls.Add(this.gsInicioSesion);
            this.Name = "ValidarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.gsInicioSesion gsInicioSesion;
    }
}