using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

using POSstation.AccesoDatos;
using gasolutions;

namespace gasolutions.UInterface
{
    public partial class frmModificarVentaCredito : Form
    {
        public frmModificarVentaCredito()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Helper helper = new Helper();

                this.ValidateDataNull(txtRecibo);
                this.ValidateDataNull(txtPlaca);

                string placa = txtPlaca.Text;
                long recibo = Convert.ToInt64(txtRecibo.Text);

                helper.PasarVentaEfectivoACredito(recibo, placa);

                MessageBox.Show(String.Format("Venta {0} Modificada Correctamente [OK]", recibo));
                this.Close();
            }
            catch (Exception ex) {  MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }


        private void ValidateDataNull(TextBox text)
        {
            if (text != null)
            {
                string value = text.Text;
                if (String.IsNullOrEmpty(value))
                {
                    text.Focus();
                    throw new Exception(String.Format("El valor del campo '{0}' no puede ser null o vacio.", text.Tag));                  
                }
            }
        }

        private void txtRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateData.ReadOnlyNumbers(sender, e);
        }
                         
    }
}
