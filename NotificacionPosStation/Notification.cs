using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Abhinaba.TransDlg;

namespace POSstation.Notificacion
{
	public class Notification : TransDialog
	{
        public int TimerTiempo { get; set; }
        public Image Imagen { get; set; }
        public string Mensaje { get; set; }
        public  bool EsError { get; set; }
        #region Ctor, init code and dispose
		public Notification()
            : base(true)
		{
			InitializeComponent();
		}

        public void IniciarComponentes() 
        {
          try
            {
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                this.Left = screenWidth - this.Width;
                this.Top = screenHeight - this.Height;
                this.Temporizador.Stop();
                Temporizador.Interval = TimerTiempo;
                this.Temporizador.Start();
                CajaImagen.Image = Imagen;
                lblMensajeError.Text = Mensaje;
                if (EsError)
                {
                    
                    lblMensajeError.BackColor = System.Drawing.Color.Red;
                    lblMensajeError.ForeColor = System.Drawing.Color.White;
                    this.BackColor = System.Drawing.Color.Red;
                    this.CajaImagen.Image = global::POSstation.Notificacion.Properties.Resources.Error;

                }
                else {
                    this.CajaImagen.Image = global::POSstation.Notificacion.Properties.Resources.Correcto;
                    lblMensajeError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(205)))), ((int)(((byte)(8)))));
                    lblMensajeError.ForeColor = System.Drawing.Color.White;
                    this.BackColor= System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(205)))), ((int)(((byte)(8)))));
                }
                    
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
        #endregion // Ctor and init code

        #region Event handler
        private void Notification_Load(object sender, System.EventArgs e)
        {

            IniciarComponentes();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            this.Close();
        }

       
        #endregion // Event handler
        
        #region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.CajaImagen = new System.Windows.Forms.PictureBox();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.lblMensajeError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CajaImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // CajaImagen
            // 
            this.CajaImagen.Location = new System.Drawing.Point(8, 8);
            this.CajaImagen.Name = "CajaImagen";
            this.CajaImagen.Size = new System.Drawing.Size(88, 72);
            this.CajaImagen.TabIndex = 1;
            this.CajaImagen.TabStop = false;
            // 
            // Temporizador
            // 
            this.Temporizador.Interval = 3000;
            this.Temporizador.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMensajeError
            // 
            this.lblMensajeError.BackColor = System.Drawing.Color.White;
            this.lblMensajeError.Font = new System.Drawing.Font("Trebuchet MS", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeError.ForeColor = System.Drawing.Color.Red;
            this.lblMensajeError.Location = new System.Drawing.Point(102, 9);
            this.lblMensajeError.Name = "lblMensajeError";
            this.lblMensajeError.Size = new System.Drawing.Size(280, 70);
            this.lblMensajeError.TabIndex = 2;
            this.lblMensajeError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensajeError.Click += new System.EventHandler(this.lblMensajeError_Click);
            // 
            // Notification
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 88);
            this.Controls.Add(this.lblMensajeError);
            this.Controls.Add(this.CajaImagen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Notification";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Notification_Load);
            this.MouseLeave += new System.EventHandler(this.Notification_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Notification_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.CajaImagen)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        #region Designer generated variables

        private System.Windows.Forms.PictureBox CajaImagen;
        private System.Windows.Forms.Timer Temporizador;
        private Label lblMensajeError;
        private System.ComponentModel.IContainer components;
        #endregion

        private void Notification_MouseHover(object sender, EventArgs e)
        {
            try
            {
                Temporizador.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Notification_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Temporizador.Stop();
                Temporizador.Interval = TimerTiempo;
                Temporizador.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lblMensajeError_Click(object sender, EventArgs e)
        {
            try
            {
                Temporizador.Stop();
                MessageBox.Show(Mensaje,"Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temporizador.Interval = TimerTiempo;
                Temporizador.Start();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

	}
}
