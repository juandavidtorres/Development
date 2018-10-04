using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions.UInterface
{
    public partial class Auxiliar : Form
    {
        Helper oHelper = new Helper();

        public Auxiliar()
        {
            InitializeComponent();
        }

        private void Auxiliar_Load(object sender, EventArgs e)
        {
            this.dtpFechaInicial.Value = DateTime.Now;
            this.dtpFechaFinal.Value = DateTime.Now;
        }

        private void btnPreFacturar_Click(object sender, EventArgs e)
        {
            Visor oVisor = new Visor();
            oVisor.EsRecibida = true;
            oVisor.dtDatos = oHelper.RecuperarMontoFacturar(dtpFechaInicial.Value.ToString("yyyyMMdd"), dtpFechaFinal.Value.ToString("yyyyMMdd"), false ).Tables[0];
            oVisor.ShowDialog();
            this.Visible = false;
            this.Close();
            this.Dispose();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Visor oVisor = new Visor();
            oVisor.EsRecibida = false;
            oVisor.dtDatos = oHelper.RecuperarMontoFacturar(dtpFechaInicial.Value.ToString("yyyyMMdd"), dtpFechaFinal.Value.ToString("yyyyMMdd"), true).Tables[0];
            oVisor.ShowDialog();
            this.Visible = false;
            this.Close();
            this.Dispose();
        }
    }
}