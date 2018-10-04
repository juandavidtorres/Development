using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gasolutions.UInterface
{
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
        }

        private void mnuFacturar_Click(object sender, EventArgs e)
        {
            Auxiliar oAuxiliar = new Auxiliar();
            oAuxiliar.StartPosition = FormStartPosition.CenterParent;
            oAuxiliar.ShowDialog();
            oAuxiliar.Dispose();
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            this.Dispose();
        }

        private void mnuVisualizar_Click(object sender, EventArgs e)
        {
            Visor oVisor = new Visor();
            oVisor.StartPosition = FormStartPosition.CenterParent;
            oVisor.ShowDialog();
            oVisor.Dispose();
        }
    }
}