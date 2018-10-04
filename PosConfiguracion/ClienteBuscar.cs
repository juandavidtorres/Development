using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions
{
    public partial class ClienteBuscar : Form
    {
        Helper oHelper = new Helper();

        Nullable<Int32> _IdCliente = null;
        public string Identificacion;

        public Nullable<Int32> IdCliente
        {
            get
            {
                return _IdCliente;
            }
        }

        public ClienteBuscar()
        {
            InitializeComponent();
        }

        private void grdClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _IdCliente = Int32.Parse(grdClientes.Rows[e.RowIndex].Cells["IdClienteGrilla"].Value.ToString());

                this.Hide();
            }
        }

        private void ClienteBuscar_Load(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.Identificacion))
                {
                    this.grdClientes.DataSource = oHelper.RecuperarClientesBuscar().Tables[0];
                }
                else
                {
                    this.grdClientes.DataSource = oHelper.RecuperarClientePorIdentificacion(this.Identificacion).Tables[0];
                }
            }
            catch (FormatException ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
    }
}
