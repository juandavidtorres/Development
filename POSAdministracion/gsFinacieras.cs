using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions.UInterface
{
    public partial class gsFinacieras : ItemMenu
    {
        Helper oDatos = new Helper();
        public event EventHandler oClosed;
        int IdFinancieraTemp = -1;

        public gsFinacieras()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFinaciera.Text.Trim()))
                {
                    if (IdFinancieraTemp  == 0)
                        IdFinancieraTemp = -1;

                    oDatos.InsertarFinanciera(txtFinaciera.Text.Trim(), IdFinancieraTemp);
                    dgFinancieras.DataSource =  oDatos.RecuperarDatoEntidadBancaria(true);
                    txtFinaciera.Clear();
                    IdFinancieraTemp = -1;
                    
                }else
                    MessageBox.Show("El nombre es Obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
            catch (Exception ex)
            {
                Limpiar();                
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnguardarbanco_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtbanco.Text.Trim()))
                {

                    if (!string.IsNullOrEmpty(txtcodigo.Text.Trim()))
                    {
                        oDatos.InsertarBanco(txtbanco.Text.Trim(),txtcodigo.Text.Trim());
                        dgbanco.DataSource = oDatos.RecuperarDatoEntidadBancaria(false);
                        txtcodigo.Clear();
                        txtbanco.Clear();
                    }else
                        MessageBox.Show("El codigo es Obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                    MessageBox.Show("El nombre es Obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnlimpiarbanco_Click(object sender, EventArgs e)
        {
            txtcodigo.Clear();
            txtbanco.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
                this.RiseEvent_OnClosed(sender, e);    
        }

        private void gsFinacieras_Load(object sender, EventArgs e)
        {
            try
            {

                dgbanco.DataSource = oDatos.RecuperarDatoEntidadBancaria(false);
                dgFinancieras.DataSource = oDatos.RecuperarDatoEntidadBancaria(true);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFinaciera.Clear();
            IdFinancieraTemp = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtFinaciera.Text.Trim()))
                {
                    oDatos.EliminarFinanciera(txtFinaciera.Text.Trim());
                    dgFinancieras.DataSource = oDatos.RecuperarDatoEntidadBancaria(true);
                    Limpiar();
                    IdFinancieraTemp = -1;
                }
                else
                    MessageBox.Show("El nombre de la entidad aval es obligatorio", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Limpiar();
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Limpiar()
        {

            txtcodigo.Clear();
            txtbanco.Clear();
            txtFinaciera.Clear();
            IdFinancieraTemp = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtcodigo.Text.Trim()))
                {
                    oDatos.EliminarBanco(txtcodigo.Text.Trim());
                    dgbanco.DataSource = oDatos.RecuperarDatoEntidadBancaria(false);
                    Limpiar();
                }
                else
                    MessageBox.Show("El Codigo es obligatorio para realizar la eliminacion", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Limpiar();
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void dgbanco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtbanco.Text = dgbanco.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtcodigo.Text = dgbanco.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();

            }
            catch (Exception ex)
            {
                Limpiar();
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dgFinancieras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtFinaciera.Text = dgFinancieras.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                IdFinancieraTemp = Convert.ToInt32(dgFinancieras.Rows[e.RowIndex].Cells["IdFinanciera"].Value.ToString());

            }
            catch (Exception ex)
            {
                Limpiar();
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        
    }
}
