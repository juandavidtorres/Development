using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public partial class TerpellDatosGenerales : UserControl
    {

        public TerpellDatosGenerales()
        {
            InitializeComponent();
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

        private void TerpellDatosGenerales_Load(object sender, EventArgs e)
        {
            this.lblFecha.Text = DateTime.Now.ToString("MMM dd,yyyy HH:mm").ToUpper();
        }
    }
}
