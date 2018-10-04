using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.UInterface
{
    public partial class FrmCreditoPorVehiculo : Form
    {
        public string Dni { get; set; }
        public string IdCredito { get; set; }

        public FrmCreditoPorVehiculo()
        {
            InitializeComponent();
        }

        private void FrmCreeditoPorVehiculo_Load(object sender, EventArgs e)
        {
            try
            {
                gsCreditos1.txtCliente.Text = Dni;
                gsCreditos1.oCredito = Convert.ToInt32(IdCredito);
                gsCreditos1.IniciarForma();
                gsCreditos1.CargarCliente(Dni);
                gsCreditos1.mnuCerrar.Visible = false;
                gsCreditos1.RecuperaInformacion(IdCredito);
            }
            catch (Exception)
            {

                
            }
        }
    }
}
