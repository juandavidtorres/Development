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
    public partial class FrmBuscarTarjeta : Form
    {
        Helper oHelper = new Helper();

        int _IdCliente;
        string _Tarjeta;

        public int Cliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }


        public string TarjetaCliente
        {
            get { return _Tarjeta; }
            set { _Tarjeta = value; }
        }

        public FrmBuscarTarjeta()
        {
            InitializeComponent();
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtNuip.Text.Trim()))
                {
                    grillaTrajeta.DataSource = oHelper.RecuperarTarjetasPorNuip(txtNuip.Text.Trim());

                }
                else
                    MessageBox.Show("El Nuip es obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmBuscarTarjeta_Load(object sender, EventArgs e)
        {

        }

        private void grillaTrajeta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 1)
                {
                    if (grillaTrajeta.Rows[e.RowIndex].Cells["IdCliente"].Value != null)
                    {
                        this._IdCliente = Convert.ToInt32(grillaTrajeta.Rows[e.RowIndex].Cells["IdCliente"].Value.ToString());
                        this._Tarjeta = grillaTrajeta.Rows[e.RowIndex].Cells["Numero"].Value.ToString();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnbuscarTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                gasolutions.ClienteBuscar ventana = new gasolutions.ClienteBuscar();
                ventana.Identificacion = txtCliente.Text;
                ventana.ShowDialog();

                if (ventana.IdCliente != null)
                {
                    using (IDataReader dtCliente = oHelper.RecuperarClientePorId(ventana.IdCliente.Value))
                    {
                        if (dtCliente.Read())
                        {
                            this.txtCliente.Text = dtCliente.GetString(dtCliente.GetOrdinal("Identificacion"));
                        }

                        dtCliente.Close();
                    }
                }
                ventana.Close();
                ventana.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtTarjeta.Text.Trim()))
                {

                    if (!string.IsNullOrEmpty(txtCliente.Text.Trim()))
                    {
                        oHelper.InsertarTarjetaCupo(txtTarjeta.Text, 0, txtCliente.Text);
                        this.TarjetaCliente = txtTarjeta.Text.Trim();
                        this.Close();
                    }
                    else
                        MessageBox.Show("El NUIP es obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                    MessageBox.Show("El numero de tarjeta es obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNuip.Text.Trim()))
                    grillaTrajeta.DataSource = oHelper.RecuperarTarjetasPorNuip(txtNuip.Text.Trim());
                else
                    MessageBox.Show("Debe digistar el NUIP", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
