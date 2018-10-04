using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using gasolutions.UInterface;
using POSstation.Fabrica;

namespace gasolutions.UInterface
{
    public partial class FrmVehiculoVenta : Form
    {
        public FrmVehiculoVenta()
        {
            InitializeComponent();
        }

        private void btnAgregarCredito_Click(object sender, EventArgs e)
        {
            Helper odatos = new Helper();
            
            try
            {
                long recibo=0;
                if (long.TryParse(txtrecibo.Text,out recibo))
	            {
                    if (!string.IsNullOrEmpty(txtCliente.Text))
                    {
                        odatos.InsertarPlacaRecibo(recibo, txtCliente.Text);
                        MessageBox.Show("Operacion finalizada correctamente");
                    }
                    else
                        throw new System.Exception("La placa es obligatoria");
		 
	            }else
                    throw new System.Exception("El numero del recibo debe ser un numero entrero y no puede ser vacio");
              

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
