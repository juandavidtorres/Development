using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using System.Collections;
using POSstation.Fabrica;



namespace PosStation.gsEmpleados
{
    public partial class gsEmpleado: UserControl
    {

        #region "      Declaracio de Variables      "

            Helper OHelper = new Helper();
            string NombreControl;
            Int32 EsActivo;
            Int32 IdEmpleado;

        #endregion

        #region "   Propiedades del Control "

        public string NameControl
        {
            get
            {
                return NombreControl;
            }
            set
            {
                NombreControl = value;
            }
        }

        #endregion

        public gsEmpleado()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.FormatoFormularioInicial();
            this.Cursor = Cursors.WaitCursor;
            txtDocumento.Tag = "";
            CargarDepartamentos();
            CargarCargos();           
            this.Cursor = Cursors.Default;
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
            chkEsActivo.Checked = false;
            HabilitarControles(true);
            txtDocumento.Focus();
            IdEmpleado = -1;
        }

        private void LimpiarFormularioSecundario()
        {
            txtDocumento.Tag = "";
            txtNombre.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            chkEsActivo.Checked = false;
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
                    IdEmpleado = Empleado.GetInt32(Empleado.GetOrdinal("IdEmpleado"));

                    if (Empleado.GetValue(Empleado.GetOrdinal("Estado")).Equals(1))
                        chkEsActivo.Checked = true;
                    else
                        chkEsActivo.Checked = false;
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
            if (txtDocumento.Tag  != null)
            {
                if (txtDocumento.Text != txtDocumento.Tag.ToString())
                {
                    txtDocumento.Tag = txtDocumento.Text;
                    CargarDatosEmpleado(txtDocumento.Text);
                }
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
                    Validacion.ValidarNumeroEntero(txtDocumento.Text, "El NUIP");
                    if (txtClave.Text == txtConfirmarClave.Text)
                    {
                        String Codigo = txtDocumento.Text.Trim().Length >= 3 ? txtDocumento.Text.Trim().Substring(0, 3) : txtDocumento.Text.Trim();

                        if (OHelper.ExisteEmpleado(txtDocumento.Text.Trim()))
                        {
                            OHelper.ActualizarEmpleado(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), Codigo, txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), Int32.Parse(cmbCargo.SelectedValue.ToString()), EsActivo, Int32.Parse(cmbCiudad.SelectedValue.ToString()), txtClave.Text);
                        }
                        else
                        {
                            OHelper.InsertarEmpleado(txtDocumento.Text.Trim(), txtNombre.Text.Trim(), Codigo, txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), Int32.Parse(cmbCargo.SelectedValue.ToString()), EsActivo, Int32.Parse(cmbCiudad.SelectedValue.ToString()), txtClave.Text);
                        }
                        FormatoFormularioInicial();
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

        public event EventHandler oClosed;

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void chkEsActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEsActivo.Checked)
                EsActivo = 1;
            else
                EsActivo = 0;
        }

         public event WorkerEndHandler VisualizarIdentificadores;
        private void tsbIdentificador_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdEmpleado >= 0)
                    VisualizarIdentificadores(sender, new EventIdentificador(Int32.Parse(IdEmpleado.ToString())));
                else
                    throw new Exception("Debe seleccionar un Empleado Valido");
            }
            catch(Exception ex)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\n" + ex.Message;
                Popup.Popup();
            }
        }

        public delegate void WorkerEndHandler(object o, EventIdentificador e);

    }

    public class EventIdentificador : EventArgs
    {
        Int32 _IdEmpleado = -1;

        public EventIdentificador( Int32 IEmpleado)
        {
            _IdEmpleado = IEmpleado;
        }

        public Int32 IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }
    }
}
