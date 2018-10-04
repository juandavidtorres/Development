using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace PosConfiguracion
{
    public partial class gsUnidadMedida : UserControl
    {
        Helper oHelper = new Helper();

        public gsUnidadMedida()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                RecuperarUnidadesMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarUnidadesMedida()
        {
            try
            {
                grdUnidadMedida.DataSource = oHelper.RecuperarUnidadMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(this.txtNombre.Text))
                {
                    if (!String.IsNullOrEmpty(this.TxtCodigoMenoCash.Text))
                    {
                        oHelper.InsertarUnidadMedida(txtNombre.Text, TxtCodigoMenoCash.Text);
                        this.RecuperarUnidadesMedida();
                        txtNombre.Text = "";
                        TxtCodigoMenoCash.Text = "";

                    }
                    else
                    {
                        oHelper.InsertarUnidadMedida(txtNombre.Text);
                        this.RecuperarUnidadesMedida();
                        txtNombre.Text = "";
                    }
               
                    
                }
                else
                {
                    MessageBox.Show("El nombre no puede ser vacio");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdUnidadMedida_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el registro #" + (e.Row.Index + 1) + " de las unidades de medida?", "FullStation Config Desktop®",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    oHelper.EliminarUnidadMedida(Int32.Parse(grdUnidadMedida.Rows[e.Row.Index].Cells["grdUnidadMedidaIdUnidad"].Value.ToString()));
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void grdUnidadMedida_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                grdUnidadMedida.DataSource = oHelper.RecuperarUnidadMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
