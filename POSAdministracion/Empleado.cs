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

namespace gasolutions.UInterface
{
    public partial class Empleado : Form
    {
        Helper OHelper = new Helper();

        public Empleado()
        {
            InitializeComponent();
        }

        private void Empleado_Load(object sender, EventArgs e)
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
            CargarCargos();
        }

        private void CargarCargos()
        {
            cmbCargo.DisplayMember = "Cargo";
            cmbCargo.ValueMember = "IdCargo";
            cmbCargo.DataSource = OHelper.RecuperarCargos().Tables[0];
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

        private void FormatoFormularioInicial()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtDocumento.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            HabilitarControles(true);
            txtDocumento.Focus();
        }

        private void LimpiarFormularioSecundario()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtNombre.Focus();
        }

        private void HabilitarControles(Boolean Valor)
        {
            this.mnuGuardar.Enabled = Valor;
        }

        private void CargarDatosEmpleado(String documento)
        {
            try
            {
                IDataReader Empleado = OHelper.RecuperarEmpleado(documento);
                if (Empleado.Read())
                {
                    txtNombre.Text = Empleado.GetString(Empleado.GetOrdinal("Nombre"));
                    txtClave.Text = Empleado.GetString(Empleado.GetOrdinal("Clave"));
                    txtConfirmarClave.Text = Empleado.GetString(Empleado.GetOrdinal("Clave"));
                    txtDireccion.Text = Empleado.GetString(Empleado.GetOrdinal("Direccion"));
                    txtTelefono.Text = Empleado.GetString(Empleado.GetOrdinal("Telefono"));
                    cmbDepartamento.SelectedValue = Empleado.GetValue(Empleado.GetOrdinal("IdDpto"));
                    cmbCiudad.SelectedValue = Empleado.GetValue(Empleado.GetOrdinal("IdCiudad"));
                    cmbCargo.SelectedValue = Empleado.GetValue(Empleado.GetOrdinal("IdCargo"));
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                LimpiarFormularioSecundario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text != txtDocumento.Tag.ToString())
            {
                txtDocumento.Tag = txtDocumento.Text;
                CargarDatosEmpleado(txtDocumento.Text);
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
                if (txtNombre.Text.Trim().Length > 0 && txtDocumento.Text.Trim().Length > 0 && cmbCiudad.SelectedIndex != -1 && txtClave.Text.Length > 0 && txtConfirmarClave.Text.Length > 0 && cmbCargo.SelectedIndex != -1)
                {
                    if (txtClave.Text == txtConfirmarClave.Text)
                    {
                        String Codigo = txtDocumento.Text.Trim().Length >= 3 ? txtDocumento.Text.Trim().Substring(0, 3) : txtDocumento.Text.Trim();

                        if (OHelper.ExisteEmpleado(txtDocumento.Text.Trim()))
                        {
                            OHelper.ActualizarEmpleado(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), Codigo, txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), Int32.Parse(cmbCargo.SelectedValue.ToString()), 1, Int32.Parse(cmbCiudad.SelectedValue.ToString()), txtClave.Text);
                        }
                        else
                        {
                            OHelper.InsertarEmpleado(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), Codigo, txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), Int32.Parse(cmbCargo.SelectedValue.ToString()), 1, Int32.Parse(cmbCiudad.SelectedValue.ToString()), txtClave.Text);
                        }

                        Popup.ContentText = "\t\t\tData Administrator\n\nEl empleado fue guardado satisfactoriamente";
                        Popup.Popup();
                    }
                    else
                    {
                        Popup.ContentText = "\t\t\tData Administrator\n\nLa clave no coincide con la confirmación de la misma";
                        Popup.Popup();
                    }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}