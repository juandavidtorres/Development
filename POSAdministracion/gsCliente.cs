using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using Controles;
using PosStation.gsConductores;

namespace  PosStation.gsClientes
{
    public partial class gsCliente : UserControl
    {
        Helper OHelper = new Helper();
        bool cambiarPrecio;
        gsConductor oConductor = new gsConductor();
        Boolean ConductorEnUso;
        List<Control> oArray = new List<Control>();

        public gsCliente()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.Cursor = Cursors.WaitCursor;
            txtDocumento.Tag = "";
            CargarDepartamentos();
            FormatoFormularioInicial();
            this.Cursor = Cursors.Default;
        }

        private void cmbDepartamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedIndex != -1)
            {
                CargarCiudadesPorDepartamento(Int32.Parse(cmbDepartamento.SelectedValue.ToString()));
            }
        }

        private void CargarCiudadesPorDepartamento(Int32 idDpto)
        {
            cmbCiudad.DisplayMember = "Nombre";
            cmbCiudad.ValueMember = "IdCiudad";
            cmbCiudad.DataSource = OHelper.RecuperarMunicipiosPorDepartamento(idDpto).Tables[0];
        }

        private void CargarDepartamentos()
        {
            cmbDepartamento.DisplayMember = "Nombre";
            cmbDepartamento.ValueMember = "IdDpto";
            cmbDepartamento.DataSource = OHelper.RecuperarDepartamentos().Tables[0];
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedIndex != -1)
            {
                CargarCiudadesPorDepartamento(Int32.Parse(cmbDepartamento.SelectedValue.ToString()));
            }
        }

        public void FormatoFormularioInicial()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtDocumento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtContacto.Text = "";
            mnuConductor.Enabled = false;
            HabilitarControles(true);
            txtDocumento.Focus();
            //pnlClienteCredito.Enabled = false;
            //LimpiarControlesClienteCredito();
        }

        private void LimpiarFormularioSecundario()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtNombre.Focus();
        }

        private void HabilitarControles(Boolean Valor)
        {
            this.mnuGuardar.Enabled = Valor;
        }

        private void oConductor_oClosed(object sender, EventArgs e)
        {
            ConductorEnUso = false;
            oArray.Remove(oConductor);
            ControlVisibleenPantalla();
            pnlPrincipal.Enabled = true;
        }

        private void CargarDatosCliente(String documento)
        {
            try
            {
                IDataReader Cliente;
                if (OHelper.ExisteClienteLocal(documento))
                {
                    Cliente = OHelper.RecuperarClienteLocal(documento);
                    EstablecerDatosCliente(Cliente);
                }
                else
                {
                    Cliente = OHelper.RecuperarCliente(documento);
                    EstablecerDatosCliente(Cliente);
                    Popup.ContentText = "\t\t\tData Administrator\n\nSe recuperaron los datos del cliente del CDC";
                    Popup.Popup();
                }
               
            }
            catch (Exception ex)
            {
                LimpiarFormularioSecundario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
                mnuConductor.Enabled = false;
            }
        }

        private void EstablecerDatosCliente(IDataReader Cliente)
        {
            try
            {
                if (Cliente.Read())
                {
                    txtNombre.Text = Cliente.GetString(1);
                    txtDireccion.Text = Cliente.GetString(3);
                    txtTelefono.Text = Cliente.GetString(4);
                    cmbDepartamento.SelectedValue = Cliente.GetValue(8);
                    cmbCiudad.SelectedValue = Cliente.GetValue(5);
                    txtContacto.Text = Cliente.GetString(9);
                    txtNombre.Focus();
                    mnuConductor.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Cliente.Close();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text != txtDocumento.Tag.ToString())
            {
                txtDocumento.Tag = txtDocumento.Text;
                CargarDatosCliente(txtDocumento.Text);
                //mnuConductor.Enabled = true;
           }
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FormatoFormularioInicial();
            }
            catch (ArgumentNullException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nEl argumento hizo referencia a un objeto cuyo estado es nulo";
                Popup.Popup();
            }
            catch (FormatException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nEl formato de la cadena a convertir no es válido";
                Popup.Popup();
            }
            catch (OverflowException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nLa cadena a convertir representa un número menor que MinValue o mayor que MaxValue.";
                Popup.Popup();
            }
            catch (ArgumentOutOfRangeException)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nRowIndex está fuera del intervalo válido, que va desde 0 hasta el número de filas del control menos 1.";
                Popup.Popup();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }
        


        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtNombre.Text.Trim().Length > 0 && txtDocumento.Text.Trim().Length > 0 && cmbCiudad.SelectedIndex != -1)
                {

                    //Factory.Validacion.ValidarNumeroEntero(txtDocumento.Text.Trim(), "El Nuip");

                   
                        if (OHelper.ExisteClienteLocal(txtDocumento.Text.Trim()))
                        {
                            OHelper.ActualizarCliente(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), 4, Int32.Parse(cmbCiudad.SelectedValue.ToString()), 0, 0, txtContacto.Text);
                           
                        }
                        else
                        {
                            OHelper.InsertarCliente(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), 4, Int32.Parse(cmbCiudad.SelectedValue.ToString()), 0, 0, txtContacto.Text);
                           
                        }
                        LimpiarCliente();
                        
                        Popup.ContentText = "\t\t\tData Administrator\n\nEl cliente fue guardado satisfactoriamente";
                        Popup.Popup();
                    
                }
                else
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nHay campos obligatorios que no han sido llenados";
                    Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }


        //private void chkClienteCredito_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (chkClienteCredito.Checked)
        //    {
        //        cambiarPrecio = true;
        //        pnlClienteCredito.Enabled = true;
        //        gbPorcentaje.Focus();
        //    }
        //    else
        //    {
        //        cambiarPrecio = false;
        //        pnlClienteCredito.Enabled = false;
        //        LimpiarControlesClienteCredito();
        //    }

        //}


        //private void LimpiarControlesClienteCredito()
        //{
        //    //Límpiamos los controles del panel de ClientesCredito
        //    chkClienteCredito.Checked = false;
        //    cambiarPrecio = false;
        //    rbPorcentaje.Checked = false;
        //    rbValor.Checked = false;
        //    rbDescuento.Checked = false;
        //    rbIncremento.Checked = false;
        //    txtValor.Text = "";
        //}

        private void LimpiarCliente() 
        {
            txtContacto.Clear();
            txtDireccion.Clear();
            txtDocumento.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        
        }

        public event EventHandler oClosed;

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        public event WorkerEndHandler MostrarVehiculo;

        private void mnuVehiculos_Click(object sender, EventArgs e)
        {
            try
            {
                Controles.frmAyuda oAyuda = new frmAyuda();
                oAyuda.TituloVentana = "Vehiculos Asociados";
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.Informacion = OHelper.RecuperarVehiculosporClienteLocal(txtDocumento.Text.Trim()).Tables[0];
                oAyuda.ColumnReturn = 0;
                oAyuda.ShowDialog();
                if ((string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado)) == false)
                {                   
                    //oVehiculo.Placa = oAyuda.ValorRegistroSeleccionado;
                    EventCliente Arg = new EventCliente(oAyuda.ValorRegistroSeleccionado.ToString(),true);
                    MostrarVehiculo(this, Arg);                   
                    
                }
                oAyuda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

     
        private void mnuConductor_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Enabled = false;
            oConductor.Visible = false;
            oConductor.IdentificacionCliente = Convert.ToInt64(txtDocumento.Text);
            oConductor.oClosed += new System.EventHandler(this.oConductor_oClosed);
           
            this.panelConductor.Controls.Add(oConductor);
            try
            {
                if (ConductorEnUso == false)
                {
                    oArray.Add(oConductor);
                    oConductor.IniciarForma();
                    ControlVisibleenPantalla();
                    ConductorEnUso = true;                    
                }

            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

      
        private void ControlVisibleenPantalla()
        {
            Int16 Max = Int16.Parse((oArray.Count - 1).ToString());

            for (Int16 i = 0; i <= Max; ++i)
            {
                if (Max == i)
                {
                    oArray[i].Visible = true;
                }
                else
                {
                    oArray[i].Visible = false;
                }

            }
        }

       

    }

 

   public class EventCliente : EventArgs
    {

        public readonly string iPlaca;
        public readonly Boolean iEstado;

        public EventCliente(string s, Boolean Estado)
        {
            iPlaca  = s;
            iEstado = Estado;
        }

    }

    public delegate void WorkerEndHandler(object o, EventCliente e);
}
