using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.Fabrica;
using POSstation.AccesoDatos;
using gasolutions.UInterface;


namespace PayOffice
{
    public partial class gsCheques : ItemMenu
    {
        public gsCheques()
        {
            InitializeComponent();
        }

        #region Declaraciones

        
        Helper oHelper = new Helper();
        FrmClienteCheque frmCheque;
        List<string> lstPlacas = new List<string>();
        string placaEliminar = "";
        string valorEliminar = "";
        //Valor máximo de cambio de cheques
        decimal valorMax = 0;
        //Valor suministrado
        decimal valorSuministrado = 0;
        //Valor faltanta para tanquear
        decimal valorFaltante = 0;
        //Valor del cheque
        decimal valorCheque = 0;
        //Porcentaje mínimo predeterminado
        decimal porcentajeMin = 0;
        //Valor mínimo a cambiar
        decimal valorMinimo = 0;
        //Valor de cambio al cliente
        decimal valorCambio = 0;
        //Número de Autorización generado por el software
        long numAutorizacion = 0;
        //Id de los clientes
        int IdCliente = 0;
        //Id de la financiera
        int IdFinanciera = 0;

        string Nombre;

        #endregion

        #region Botones creados por el Programador


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.RiseEvent_OnClosed(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarCliente form = new frmBuscarCliente();
            form.ShowDialog();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValorTanqueo.Text == "" | txtValorTanqueo.Text == "0")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un valor de tanqueo valido";
                    Popup.Popup();
                    txtValorTanqueo.Text = "";
                    txtValorTanqueo.Focus();
                }
                else if (valorSuministrado < Convert.ToDecimal(txtValorTanqueo.Text))
                {
                    Popup.ContentText = "\t\t\t\n\nEl valor de consumo no puede ser menor que el valor del tanqueo";
                    Popup.Popup();
                    txtValorTanqueo.Focus();
                }
                else if (valorFaltante < Convert.ToDecimal(txtValorTanqueo.Text))
                {
                    Popup.ContentText = "\t\t\t\n\nEl valor del tanqueo no puede ser mayor que el valor que falta por consumir";
                    Popup.Popup();
                    txtValorTanqueo.Focus();
                }
                else if (cmbPlaca.Text == "")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe escoger una placa";
                    Popup.Popup();
                    cmbPlaca.Focus();
                }
                else
                {
                    int count = 0;

                    foreach (System.Data.DataRowView i in cmbPlaca.Items)
                    {
                        if (Convert.ToString(i.Row[0]) == cmbPlaca.Text)
                            break;
                        else
                            count += 1;
                    }

                    if (count == cmbPlaca.Items.Count && rbIdentificado.Checked)
                    {
                        Popup.ContentText = "\t\t\t\n\nDebe escoger una placa valida";
                        Popup.Popup();
                        cmbPlaca.SelectedIndex = -1;
                        cmbPlaca.Focus();
                    }
                    else if (lstPlacas.Contains(cmbPlaca.Text))
                    {
                        Popup.ContentText = "\t\t\t\n\nLa placa " + cmbPlaca.Text + " tiene un valor de tanqueo asociado";
                        Popup.Popup();
                        cmbPlaca.SelectedIndex = -1;
                        cmbPlaca.Focus();
                    }
                    else
                    {
                        //Agregamos los datos a la grilla
                        dgvVehiculos.Rows.Add(cmbPlaca.Text, txtValorTanqueo.Text);
                        //Agregamos la placa a la lista
                        lstPlacas.Add(cmbPlaca.Text);
                        //Verificamos lo del valor suministrado
                        valorFaltante = valorFaltante - Convert.ToDecimal(txtValorTanqueo.Text);
                        //Actualizamos el label del valor faltante
                        lblFaltante.Text = (valorFaltante).ToString("C");
                        //Borramos los textos mostrados en los controles
                        cmbPlaca.SelectedIndex = -1;
                        txtValorTanqueo.Text = "";
                        cmbPlaca.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Checkeamos el radio button de cliente identificado
            rbPaso.Checked = true;
            rbIdentificado.Checked = true;
        }

        //Lógica para guardar la información en la base de datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se verifica que los datos son validos
                if (ValidarDatos())
                {
                    string placas = dgvVehiculos[0, 0].Value + "|";
                    string valores = dgvVehiculos[1, 0].Value + "|";
                    string codigoBanco =  cmbBanco.SelectedValue.ToString();
                    
                    IdCliente = 0;

                    //Recorremos la grilla con las placas y los valores
                    for (int i = 1; i <= dgvVehiculos.Rows.Count - 1; i++)
                    {
                        placas = placas + dgvVehiculos[0, i].Value + "|";
                        valores = valores + dgvVehiculos[1, i].Value + "|";
                    }

                    long autorizacionEntidad = 0;

                    if (rbPaso.Checked)
                        autorizacionEntidad = Convert.ToInt64(txtAutorizacion.Text);
                    else
                        IdCliente = Int32.Parse(cmbCliente.SelectedValue.ToString());

                    //evaluamos si el código del banco es de un solo digito
                    //if (codigoBanco.Length == 1)
                    //    codigoBanco = "0" + codigoBanco;

                    if (!cmbEntidad.Enabled)
                        cmbEntidad.Text = string.Empty;

                    //Mandamos a ejecutar el SP de inserción
                    numAutorizacion = oHelper.InsertarAutorizacionCheque(IdCliente, codigoBanco, txtCheque.Text, cmbEntidad.Text, autorizacionEntidad, valorCheque, valorSuministrado, placas, valores);

                    lblNumeroAutorizacion.Text = Convert.ToString(numAutorizacion);

                    Popup.ContentText = "\t\t\t\n\nOperación Satisfactoria, su Número de Autorización es " + lblNumeroAutorizacion.Text + "";
                    Popup.Popup();

                    string autorizacion = lblNumeroAutorizacion.Text;

                    

                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        #endregion

        #region Controles de Usuario

        //Load del control de usuario
        private void gsCheques_Load(object sender, EventArgs e)
        {


            if (frmCheque == null)
            {
                frmCheque = new FrmClienteCheque();  
            }
            frmCheque.Cierre += new FrmClienteCheque.CerrarFormulario(frmCheque_Cierre);
            CargarDatosIniciales();
        }

        void frmCheque_Cierre()
        {
            frmCheque.Close();
        }

        #region COMBOBOX

        //Hacemos que el usuario solo escriba números en el combo del Banco Emisor
        private void cmbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cmbCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (rbIdentificado.Checked)
                {
                    //Verificamos si los datos son correctos
                    if (cmbCliente.Text == "")
                    {
                        Popup.ContentText = "\t\t\t\n\nDebe escoger un cliente";
                        Popup.Popup();
                        //cmbCliente.Focus();
                    }
                    else
                    {
                        int count = 0;

                        foreach (System.Data.DataRowView i in cmbCliente.Items)
                        {

                            if (Convert.ToString(i.Row[0]) == cmbCliente.Text)
                                break;
                            else
                                count += 1;

                        }

                        if (count == cmbCliente.Items.Count)
                        {
                            Popup.ContentText = "\t\t\t\n\nDebe escoger un cliente valido";
                            Popup.Popup();
                            cmbPlaca.SelectedIndex = -1;
                            //cmbCliente.Focus();
                        }
                        else
                        {
                            //Eliminamos los datos que pueda tener el combo de la placa
                            cmbPlaca.DataSource = null;
                            cmbPlaca.Items.Clear();
                            //Límpiamos la lista que guarda las placas
                            lstPlacas.Clear();

                            DataSet data = new DataSet();
                            data = oHelper.RecuperarVehiculosPorClienteIdentificado(Int32.Parse(cmbCliente.SelectedValue.ToString()));

                            if (data.Tables[0].Rows.Count > 0)
                            {
                                //Cargamos el combobox de placas
                                cmbPlaca.DisplayMember = "Placa";
                                cmbPlaca.ValueMember = "IdVehiculo";
                                cmbPlaca.DataSource = data.Tables[0];

                                DataSet clienteCheque = new DataSet();
                                IdCliente = Int32.Parse(cmbCliente.SelectedValue.ToString());
                                clienteCheque = oHelper.RecuperarClienteCheque(IdCliente);

                                if (clienteCheque.Tables[0].Rows.Count > 0)
                                {
                                    //Valor máximo y porcentaje mínimo de los cheques
                                    valorMax = Convert.ToDecimal(clienteCheque.Tables[0].Rows[0]["monto"].ToString());
                                    lblMaximo.Text = (valorMax).ToString("C");
                                    porcentajeMin = Convert.ToDecimal(clienteCheque.Tables[0].Rows[0]["PorcentajeMinimo"].ToString());
                                    lblPorcentaje.Text = Convert.ToString(porcentajeMin) + "%";
                                }

                            }
                            else
                            {
                                Popup.ContentText = "\t\t\t\n\nNo existen vehiculos asociados a ese cliente";
                                Popup.Popup();
                                //cmbCliente.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }

        }

        private void cmbCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvVehiculos.Rows.Count != 0)
            {
                e.Handled = true;
                Popup.ContentText = "\t\t\t\n\nNo puede cambiar el nombre del cliente";
                Popup.Popup();
            }
        }

        private void cmbCliente_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.Rows.Count != 0)
            {
                Popup.ContentText = "\t\t\t\n\nNo puede cambiar el nombre del cliente";
                Popup.Popup();
                dgvVehiculos.Focus();
            }
        }

        #endregion

        #region DATAGRIDVIEW

        //Guardamos en variables los valores de la celda a la cual se ha hecho click
        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0)
                {
                    Int32 filaActual = dgvVehiculos.CurrentCell.RowIndex;
                    placaEliminar = Convert.ToString(dgvVehiculos[0, filaActual].Value);
                    valorEliminar = Convert.ToString(dgvVehiculos[1, filaActual].Value);
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void dgvVehiculos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                //Eliminamos la placa de la lista
                lstPlacas.Remove(placaEliminar);
                //Actualizamos el valor del faltante
                valorFaltante = valorFaltante + Convert.ToDecimal(valorEliminar);
                //Actualizamos el label del valor faltante
                lblFaltante.Text = (valorFaltante).ToString("C");
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        #endregion

        #region RADIOBUTTON

        //Evaluamos si se checkeo el Cliente de Paso para limpiar controles y determinar su implicación en el software
        private void rbPaso_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            CargarDatosIniciales();

            //Si se ha checkeado el cliente de paso
            if (rbPaso.Checked)
                MostrarClientePaso();
            else
                MostrarClienteIdentificados();
        }

        #endregion

        #region TEXTBOX

        //Evaluamos que solo se escriban letras y números para el cheque
        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) | char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Evaluamos que solo se escriban números para el valor del cheque
        private void txtValorCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvVehiculos.Rows.Count == 0)
            {
                if (char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))
                {
                    //Evaluamos si estamos ante un cliente identificado
                    if (rbIdentificado.Checked)
                    {
                        //Evaluamos que tengamos un cliente seleccionado
                        if (IdCliente != 0)
                            e.Handled = false;
                        else
                        {
                            e.Handled = true;
                            Popup.ContentText = "\t\t\t\n\nDebe seleccionar un cliente antes de colocar el valor del cheque";
                            Popup.Popup();
                        }
                    }
                }
                else
                    e.Handled = true;
            }
            else
            {
                e.Handled = true;
                Popup.ContentText = "\t\t\t\n\nNo puede cambiar el valor del cheque";
                Popup.Popup();
            }
        }

        //Evaluamos que solo se escriban números para el número de la autorización de la entidad aval
        private void txtAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Evaluamos que solo se escriban números para el valor del suministro
        private void txtValorSuministro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (valorCheque == 0)
            {
                e.Handled = true;
                Popup.ContentText = "\t\t\t\n\nDebe colocar el valor del cheque";
                Popup.Popup();
            }
            else
            {
                if (dgvVehiculos.Rows.Count == 0)
                {
                    if (char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                    Popup.ContentText = "\t\t\t\n\nNo puede cambiar el valor del consumo";
                    Popup.Popup();
                }
            }
        }

        //Evaluamos que solo se escriban números para el valor del tanqueo
        private void txtValorTanqueo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evaluamos si se ha colocado un valor de cheque
            if (valorCheque == 0)
            {
                e.Handled = true;
                Popup.ContentText = "\t\t\t\n\nDebe colocar el valor del cheque";
                Popup.Popup();
                txtValorCheque.Focus();
            }
            else if (valorSuministrado == 0)
            {
                e.Handled = true;
                Popup.ContentText = "\t\t\t\n\nDebe colocar el valor del consumo";
                Popup.Popup();
            }
            else
            {
                if (char.IsDigit(e.KeyChar) | char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        //Evaluamos que el valor suministrado sea menor igual que el valor del cheque y mayor igual que el valor mínimo
        private void txtValorSuministro_Leave(object sender, EventArgs e)
        {
            try
            {
                if (valorCheque == 0)
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un valor de cheque";
                    Popup.Popup();
                    txtValorSuministro.Text = "";
                }
                else if (txtValorSuministro.Text == "" | txtValorSuministro.Text == "0")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un valor de Consumo";
                    Popup.Popup();
                    //txtValorSuministro.Focus();
                }
                else
                {
                    valorSuministrado = Convert.ToDecimal(txtValorSuministro.Text);

                    if (valorCheque < valorSuministrado)
                    {
                        Popup.ContentText = "\t\t\t\n\nEl valor del consumo debe ser menor que el valor del cheque";
                        Popup.Popup();
                        txtValorSuministro.Focus();
                    }
                    else if (valorSuministrado < valorMinimo)
                    {
                        Popup.ContentText = "\t\t\t\n\nEl valor del consumo debe ser mayor que " + Convert.ToString(valorMinimo);
                        Popup.Popup();
                        txtValorSuministro.Focus();
                    }
                    else
                    {
                        if (valorFaltante == 0)
                        {
                            //Calculamos el valor de cambio
                            valorCambio = valorCheque - valorSuministrado;
                            //Acutalizamos el label
                            lblCambio.Text = (valorCambio).ToString("C");
                            //Colocamos el valor suministrado como faltante
                            valorFaltante = valorSuministrado;
                            //Actualizamos el label del valor faltante
                            lblFaltante.Text = (valorFaltante).ToString("C");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        //Verificamos que el valor del cheque sea menor que el valor máximo permitido
        private void txtValorCheque_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtValorCheque.Text == "" | txtValorCheque.Text == "0")
                {
                    if (cmbCliente.Text != "")
                    {
                        Popup.ContentText = "\t\t\t\n\nDebe colocar un valor de cheque";
                        Popup.Popup();
                    }
                    txtValorSuministro.Text = "";
                    //txtValorCheque.Focus();
                }
                else
                {
                    valorCheque = Convert.ToDecimal(txtValorCheque.Text);

                    if (valorCheque > valorMax)
                    {
                        Popup.ContentText = "\t\t\t\n\nEl valor del cheque debe ser menor que el valor máximo establecido";
                        Popup.Popup();
                        valorCheque = 0;
                        txtValorCheque.Focus();
                    }
                    else if (valorSuministrado != 0)
                    {
                        //Calculamos el valor de cambio
                        valorCambio = valorCheque - valorSuministrado;
                        //Acutalizamos el label del valor del cambio
                        lblCambio.Text = (valorCambio).ToString("C");
                    }
                    valorMinimo = (valorCheque * porcentajeMin) / 100;
                    lblMinimo.Text = (valorMinimo).ToString("C");
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        #endregion

        #endregion

        #region Métodos realizados por el Programador

        public string NameControl
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        //Método para límpiar los controles
        private void LimpiarControles()
        {
            txtCheque.Text = "";
            txtAutorizacion.Text = "";
            txtValorCheque.Text = "";
            txtValorSuministro.Text = "";
            txtValorTanqueo.Text = "";
            cmbBanco.SelectedIndex = -1;
            cmbEntidad.SelectedIndex = -1;
            cmbCliente.SelectedIndex = -1;
            cmbPlaca.SelectedIndex = -1;
            cmbBanco.Text = "";
            cmbEntidad.Text = "";
            cmbCliente.Text = "";
            cmbPlaca.Text = "";
            lblCambio.Text = (0).ToString("C");
            lblFaltante.Text = (0).ToString("C");
            lblMinimo.Text = (0).ToString("C");
            lblCambio.Text = (0).ToString("C");
            dgvVehiculos.Rows.Clear();
            
            //Inicializamos nuevamente todas las variables
            lstPlacas = new List<string>();
            placaEliminar = "";
            valorEliminar = "";
            valorSuministrado = 0;
            valorFaltante = 0;
            valorCheque = 0;
            valorMinimo = 0;
            valorCambio = 0;
            numAutorizacion = 0;

            //Límpiamos el número de autorización
            lblNumeroAutorizacion.Text = "";
        }

        //Método para mostrar los clientes de paso
        private void MostrarClientePaso()
        {
            cmbCliente.Enabled = false;
            
            cmbEntidad.Enabled = true;
            txtAutorizacion.Enabled = true;
            //lblMaximo.Visible = true;
            //label7.Visible = true;
        }

        //Método para mostrar los clientes identificados
        private void MostrarClienteIdentificados()
        {
            cmbCliente.Enabled = true;
          
            cmbEntidad.Enabled = false;
            txtAutorizacion.Enabled = false;
            //lblMaximo.Visible = false;
            //label7.Visible = false;
        }

        //Método para cargar los datos iniciales
        public void CargarDatosIniciales()
        {
            try
            {
                DataSet data = new DataSet();
                data = oHelper.RecuperarCodigoBancoEmisor();

                LimpiarControles();

                if (data.Tables[0].Rows.Count > 0)
                {
                    //Cargamos los datos del banco emisor
                    cmbBanco.DisplayMember = "Descripcion";
                    cmbBanco.ValueMember = "CodigoBancoEmisor";
                    cmbBanco.DataSource = data.Tables[0];
                }

                data = oHelper.RecuperarClientesIdentificados();

                if (data.Tables[0].Rows.Count > 0)
                {
                    //Cargamos los nombres de los clientes
                    cmbCliente.DisplayMember = "Nombre";
                    cmbCliente.ValueMember = "IdCliente";
                    cmbCliente.DataSource = data.Tables[0];
                    cmbCliente.SelectedIndex = -1;
                }

                if (rbPaso.Checked)
                {
                    IDataReader drFinanciera = oHelper.RecuperarNombreEntidadAutorizadora();

                    if (drFinanciera.Read())
                    {
                        string entidad = drFinanciera["Nombre"].ToString();
                        IdFinanciera = Convert.ToInt32(drFinanciera["IdEntidad"].ToString());
                        //Cargamos los nombres de las entidades receptoras
                        if (!cmbEntidad.Items.Contains(entidad))
                            cmbEntidad.Items.Add(entidad);
                    }

                    drFinanciera.Close();

                    //Valor máximo y porcentaje mínimo de los cheques
                    valorMax = Convert.ToDecimal(oHelper.RecuperarParametro("MontoMaximoCheque"));
                    lblMaximo.Text = (valorMax).ToString("C");
                    porcentajeMin = Convert.ToDecimal(oHelper.RecuperarParametro("PorcentajeMinimoCheque"));
                    lblPorcentaje.Text = Convert.ToString(porcentajeMin) + "%";
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        //Valida que al guardar todos los datos son correctos
        public Boolean ValidarDatos()
        {
            try
            {
                if (cmbBanco.SelectedValue == null)
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un Banco Emisor";
                    Popup.Popup();
                    cmbBanco.Focus();
                    return false;
                }


                if (cmbBanco.Text == "")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar de Banco Emisor";
                    Popup.Popup();
                    cmbBanco.Focus();
                    return false;
                }
                else if (txtCheque.Text == "")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un Número de cheque";
                    Popup.Popup();
                    txtCheque.Focus();
                    return false;
                }
                else if (txtValorCheque.Text == "")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un Valor de cheque";
                    Popup.Popup();
                    txtValorCheque.Focus();
                    return false;
                }
                else if (txtValorSuministro.Text == "")
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar un Valor de consumo";
                    Popup.Popup();
                    txtValorSuministro.Focus();
                    return false;
                }
                else if (dgvVehiculos.Rows.Count == 0)
                {
                    Popup.ContentText = "\t\t\t\n\nDebe colocar al menos un vehiculo, verifique los datos";
                    Popup.Popup();
                    cmbPlaca.Focus();
                    return false;
                }
                else if (valorFaltante != 0)
                {
                    Popup.ContentText = "\t\t\t\n\nTiene valores de tanqueos incorrectos, revise su saldo de faltante por consumir";
                    Popup.Popup();
                    cmbPlaca.Focus();
                    return false;
                }
                else if (rbPaso.Checked)
                {
                    if (cmbEntidad.Text == "")
                    {
                        Popup.ContentText = "\t\t\t\n\nDebe colocar el nombre de una Entidad aval";
                        Popup.Popup();
                        cmbEntidad.Focus();
                        return false;
                    }
                    else if (txtAutorizacion.Text == "")
                    {
                        Popup.ContentText = "\t\t\t\n\nDebe colocar el número de autorización de la Entidad aval";
                        Popup.Popup();
                        cmbEntidad.Focus();
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    if (cmbCliente.Text == "")
                    {
                        Popup.ContentText = "\t\t\t\n\nDebe seleccionar el nombre de un cliente";
                        Popup.Popup();
                        cmbCliente.Focus();
                        return false;
                    }
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
                return false;
            }
        }

        #endregion

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //private void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    txtdescripcionbanco.Text = oHelper.RecuperarDescripcionBanco(cmbBanco.Text.Trim());

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Popup.ContentText = ex.Message;
        //    //    Popup.Popup();
        //    //}

        //}

        private void txtdescripcionbanco_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                           

            }
            catch (Exception ex)
            {
                
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
                        

        }

        private void dgvVehiculos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnAsignarPorcentaje_Click(object sender, EventArgs e)
        {
            try
            {
                
                frmCheque.ShowDialog();

            }
            catch (Exception ex)
            {
                
                Popup.ContentText = ex.Message;
                Popup.Popup();
                
            }
        }

    }
}
