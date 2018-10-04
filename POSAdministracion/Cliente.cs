using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using gasolutions.UInterface;
using Controles;

namespace gasolutions.UInterface
{
    public partial class Cliente : Form
    {
        Helper OHelper = new Helper();

        public Cliente()
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //try
            //{
            //    //Instancia los eventos disparados por la aplicacion cliente
            //    Type t = Type.GetTypeFromProgID("sharedevents.CMensaje");
            //    oEventos = (SharedEvents.CMensaje)Activator.CreateInstance(t);
            //}
            //catch
            //{
            //    Popup.ContentText = "Problema Instanciando Shared Events";
            //    Popup.Popup();
            //}

            IniciarForma();
            this.Cursor = Cursors.Default;
        }

        private void IniciarForma()
        {
            txtDocumento.Tag = "";
            CargarDepartamentos();
        }

        private void cmbDepartamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedIndex != -1){
                CargarCiudadesPorDepartamento(Int32.Parse(cmbDepartamento.SelectedValue.ToString()));
            }
        }

        private void CargarCiudadesPorDepartamento( Int32 idDpto )
        {
            cmbCiudad.DisplayMember = "Nombre";
            cmbCiudad.ValueMember = "IdCiudad";
            cmbCiudad.DataSource = OHelper.RecuperarMunicipiosPorDepartamento( idDpto ).Tables[0];
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

        private void FormatoFormularioInicial()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtDocumento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            HabilitarControles(true);
            txtDocumento.Focus();
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
                    Cliente = OHelper.RecuperarClienteLocal(documento);
                    EstablecerDatosCliente(Cliente);
                    Popup.ContentText = "\t\t\tData Administrator\n\nSe recuperaron los datos del cliente del CDC";
                    Popup.Popup();
                }
            }
            catch (Exception ex) {
                LimpiarFormularioSecundario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
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
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally {
                Cliente.Close();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text != txtDocumento.Tag.ToString()){
                txtDocumento.Tag = txtDocumento.Text;
                CargarDatosCliente(txtDocumento.Text);
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
                    if (OHelper.ExisteClienteLocal(txtDocumento.Text.Trim()))
                    {
                        OHelper.ActualizarCliente(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), 4, Int32.Parse(cmbCiudad.SelectedValue.ToString()), 0, 0,"");
                    }
                    else
                    {
                        OHelper.InsertarCliente(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), 4, Int32.Parse(cmbCiudad.SelectedValue.ToString()), 0, 0,"");
                    }

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

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            this.Dispose();
        }

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
                if ((string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado))== false )
                {
                    gasolutions.Vehiculos oVehiculo = new gasolutions.Vehiculos();
                    oVehiculo.Placa = oAyuda.ValorRegistroSeleccionado;
                    oVehiculo.IniciarForma();
                    oVehiculo.Visible = true;                
                }
                oAyuda.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);   
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}