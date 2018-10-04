using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

    public partial class DatosGenerales : UserControl
    {
        public DatosGenerales()
        {
            InitializeComponent();
        }

        private void Spine_Load(object sender, EventArgs e)
        {
            this.Titulo.HeaderText.Text = DateTime.Now.ToString("MMM dd,yyyy HH:mm").ToUpper();
            this.Titulo.HeaderText.Font = new Font(this.Titulo.HeaderText.Font, FontStyle.Bold);
            this.Titulo.HeaderText.Margin = new Padding(0, 0, 0, 0);
            this.Titulo.HeaderText.ForeColor = Color.FromArgb(91, 89, 91);
        }

        public string Codigo
        {
            set { this.lblCodigo.Text = value; }
        }

        public string Nombre
        {
            set { this.lblNombre.Text = value; }
        }

        public string Nit
        {
            set { this.lblNit.Text = value; }
        }

        public string Direccion
        {
            set { this.lblDireccion.Text = value; }
        }

        public string Telefono
        {
            set { this.lblTelefono.Text = value; }
        }

        public string Ciudad
        {
            set { this.lblCiudad.Text = value; }
        }

        private void lblCiudad_Click(object sender, EventArgs e)
        {

        }

     }
