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


    public partial class gsAgregarMontoCheque : UserControl
    {
        ClienteBuscar oCLienteBuscar;
        Helper oDatos = new Helper();
        public delegate void CerrarFormulario();
        public event CerrarFormulario CerrarForm;
        
        

        
        public gsAgregarMontoCheque()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                IDataReader lector = null;

                if (oCLienteBuscar == null)
                {
                    oCLienteBuscar = new ClienteBuscar();
                }

                oCLienteBuscar.StartPosition = FormStartPosition.CenterParent;
                oCLienteBuscar.ShowDialog();


                lector = oDatos.RecuperarClientePorId(Convert.ToInt32(oCLienteBuscar.IdCliente));

                while (lector.Read()) {
                    txtNuip.Text = lector["RUC"].ToString();                
                }
                
                lector.Close();
                lector.Dispose();                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information); 
               
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarClienteCheque();
                Limpiar();
                CerrarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Limpiar() {
            txtNuip.Clear();
            txtMontoMinimo.Clear();
            txtporcentaje.Clear();

            txtporcentajeClientePaso.Clear();
            txtMontoMaximoPaso.Clear();
        }


        private void GuardarClienteCheque() 
        {

            try
            {

                Decimal oMonto, oPorcentaje;

                if (String.IsNullOrEmpty(txtNuip.Text.Trim()))
                {
                    
                    throw new Exception("El nuip es obligatorio");
                  
                }

                if (String.IsNullOrEmpty(txtMontoMinimo.Text.Trim()))
                {
                    throw new Exception("El monto es obligatorio");
              
                 }


                if (String.IsNullOrEmpty(txtporcentaje.Text.Trim()))
                {
                    throw new Exception("El porcentaje es obligatorio");                   
                }


                if (!Decimal.TryParse(txtporcentaje.Text.Trim(), out oPorcentaje))
                {

                    throw new Exception("El porcentaje debe ser  numerico");
                }


                if (!Decimal.TryParse(txtMontoMinimo.Text.Trim(), out oMonto))
                {
                    throw new Exception("El monto debe ser numerico");
                }


                oDatos.GuardarClienteCleque(txtNuip.Text.Trim(), oMonto, oPorcentaje);
                MessageBox.Show("Operacion exitosa", "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
               
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardarPorClientePaso_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal oporcentaje;

                if (String.IsNullOrEmpty(txtporcentajeClientePaso.Text.Trim()))
                {
                     throw new Exception("El porcentaje es obligatorio");
                }

                if (!Decimal.TryParse(txtporcentajeClientePaso.Text.Trim(), out oporcentaje))
                {

                    throw new Exception("El porcentaje debe ser  numerico");
                }


                if (String.IsNullOrEmpty(txtMontoMaximoPaso.Text.Trim()))
                {
                    throw new Exception("El porcentaje es obligatorio");
                }

                if (!Decimal.TryParse(txtMontoMaximoPaso.Text.Trim(), out oporcentaje))
                {

                    throw new Exception("El porcentaje debe ser  numerico");
                }

                oDatos.ActualizarParametro("PorcentajeMinimoCheque", txtporcentajeClientePaso.Text.Trim());

                oDatos.ActualizarParametro("MontoMaximoCheque", txtMontoMaximoPaso.Text.Trim());

                MessageBox.Show("Operacion Exitosa", "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CerrarForm();


            }
            catch (Exception ex)
            {

                 MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }

        private void cmbtipocliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbtipocliente.Text.Equals("Cliente Identificado"))
                {
                    panleClienteIdentificado.Enabled = true;
                    PanelClientePaso.Enabled = false;

                }
                else {

                    panleClienteIdentificado.Enabled = false;
                    PanelClientePaso.Enabled = true;
                }

            }
            catch (Exception ex)
            {               
                
                 MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            }
        }

        private void gsAgregarMontoCheque_Load(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                cmbtipocliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                
                   MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panleClienteIdentificado_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
