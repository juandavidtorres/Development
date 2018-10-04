using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using gasolutions.UInterface;
using Controles;
using POSstation.Fabrica;

namespace gasolutions.UInterface
{
    public partial class gsRenovarCredito : UserControl
    {
        Helper oHelper = new Helper();

        Boolean aplicoCredito = false;
        public gsRenovarCredito()
        {
            InitializeComponent();
        }

        public void IniciarFormRenovacion()
        {
            try
            {
                RecuperarCreditos("-1");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Renovar Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RecuperarCreditos(string Cliente)
        {
            dtgCreditosRenovar.AutoGenerateColumns = false;
            dtgCreditosRenovar.DataSource = oHelper.RecuperarCreditosParaRenovacion("-1").Tables[0];
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            txtNombre.Text = "";
            txtCliente.Focus();
        }

        private void BtnRenovar_Click(object sender, EventArgs e)
        {
            try
            {
                    foreach (DataGridViewRow row in dtgCreditosRenovar.Rows)
                    {
                        //MessageBox.Show(Convert.ToInt32(row.Cells[1].Value).ToString() + "-> " + Convert.ToBoolean(row.Cells[6].Value).ToString());
                        //Si el credito esta seleccionado se procede a realizar la renovación
                        if (row.Cells[6].Value != null )
                        {
                            if (!string.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                            {
                                oHelper.RenovarCredito(Convert.ToInt32(row.Cells[0].Value.ToString()));
                                aplicoCredito = true;
                            }
                        }
                    }
                    if (aplicoCredito)
                    {
                        MessageBox.Show("Operacion exitosa", "Renovar Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Renovar Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public event EventHandler oClosed;
        private void btnSalir_Click(object sender, EventArgs e)
        {
            pnlEncabezado.Enabled = true;
            this.Visible = false;
            this.oClosed(sender, e);
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable cli = oHelper.RecuperarClientePorIdentificacion(this.txtCliente.Text).Tables[0];

                if (cli.Rows.Count > 0)
                {
                    txtNombre.Text = cli.Rows[0]["Nombre"].ToString();                 
                }
                dtgCreditosRenovar.AutoGenerateColumns = false;
                dtgCreditosRenovar.DataSource = oHelper.RecuperarCreditosParaRenovacion(txtCliente.Text).Tables[0];
            }

        }


    }
}
