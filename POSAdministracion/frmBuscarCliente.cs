using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace PayOffice
{
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Variable que nos determina si se ejecuta la consulta o no
                Boolean band = false;
                //Tipo de busqueda
                short tipoBusq = 0;
                string Dato = "";

                //Evaluamos cual es el check que está seleccionado
                if (rbNombre.Checked)
                {
                    if (txtNombre.Text == "")
                        MessageBox.Show("Debe colocar un nombre valido");
                    else
                    {
                        band = true;
                        tipoBusq = Convert.ToInt16(TipoBusqueda.Nombre);
                        Dato = txtNombre.Text;
                        txtNombre.Text = "";
                    }
                }
                else if (rbNit.Checked)
                {
                    if (txtNit.Text == "")
                        MessageBox.Show("Debe colocar un nit valido");
                    else
                    {
                        band = true;
                        tipoBusq = Convert.ToInt16(TipoBusqueda.Nit);
                        Dato = txtNit.Text;
                        txtNit.Text = "";
                    }
                }
                else
                {
                    if (txtPlaca.Text == "")
                        MessageBox.Show("Debe colocar una placa valida");
                    else
                    {
                        band = true;
                        tipoBusq = Convert.ToInt16(TipoBusqueda.Placa);
                        Dato = txtPlaca.Text;
                        txtPlaca.Text = "";
                    }
                }

                //Evaluamos si los datos están correctos
                if (band)
                {
                    //Límpiamos la grilla
                    for (int i = 0; i <= dgvResultado.Rows.Count - 1; i++)
                    {
                        dgvResultado.Rows.RemoveAt(i);
                    }

                    //Adicionamos el resultado siempre y cuando se tengan datos
                    Helper oHelper = new Helper();
                    DataSet data = new DataSet();

                    data = oHelper.RecuperarDatosClienteIdentificado(tipoBusq, Dato);

                    if (data.Tables[0].Rows.Count > 0)
                        this.dgvResultado.DataSource = data.Tables[0];
                    else
                        MessageBox.Show("La consulta no arrojó resultados: " + Dato);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNombre.Checked)
            {
                txtNombre.Enabled = true;
                txtNombre.Focus();
            }
            else
            {
                txtNombre.Text = "";
                txtNombre.Enabled = false;
            }
        }

        private void rbNit_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNit.Checked)
            {
                txtNit.Enabled = true;
                txtNit.Focus();
            }
            else
            {
                txtNit.Text = "";
                txtNit.Enabled = false;
            }
        }

        private void rbPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPlaca.Checked)
            {
                txtPlaca.Enabled = true;
                txtPlaca.Focus();
            }
            else
            {
                txtPlaca.Text = "";
                txtPlaca.Enabled = false;
            }
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {

        }

    }

    public enum TipoBusqueda : short { Nombre, Nit, Placa };

}