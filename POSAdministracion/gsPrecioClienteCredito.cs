using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using gasolutions.UInterface;
using Controles;

namespace gasolutions.gsPrecioClienteCredito
{
    public partial class gsPrecioClienteCredito : UserControl
    {
        #region " Variables Declaradas "



        Helper OHelper = new Helper();
        Boolean EsGridDetalleConstruido;
        Boolean EsNuevoRegistro;


        DataTable OVehiculos = new DataTable();
        DataTable OProductos = new DataTable();
        Int32 oPrecioCliente;
        bool existe = false;



        #endregion

        #region " Propiedades del Formulario "

        public Int32 PrecioCliente
        {
            get
            {
                return oPrecioCliente;
            }
            set
            {
                oPrecioCliente = value;
            }
        }

        #endregion

        public gsPrecioClienteCredito()
        {
            InitializeComponent();
        }

        public event EventHandler oClosed;

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            EsNuevoRegistro = false;
            this.Visible = false;
            this.oClosed(sender, e);
        }

        public void IniciarForma()
        {
            pnlEncabezado.Enabled = false;
            pnlDetalle.Enabled = false;
            this.mnuGuardar.Enabled = false;
            DesHacer();



        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
            this.chkEstado.Checked = true;
            this.chkAplicaEnSurtidor.Checked = true;
            mnuGuardar.Enabled = true;
            mnuFind.Enabled = false;
            mnuNew.Enabled = false;
            pnlEncabezado.Enabled = true;
            pnlDetalle.Enabled = true;
            pnlDescuento.Enabled = true;
            EsNuevoRegistro = true;
            EsGridDetalleConstruido = true;
            txtCliente.Enabled = true;
            gbDescuento.Enabled = true;
            gbPorcentaje.Enabled = true;
            chkEstado.Enabled = true;
            chkAplicaEnSurtidor.Enabled = true;
            txtValor.Enabled = true;

        }



        private void dtgDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex + ":" + e.Exception.ToString());
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (EsNuevoRegistro)
                {
                    IDataReader Cliente;
                    Cliente = OHelper.RecuperarClienteLocal(txtCliente.Text);
                    if (Cliente.Read())
                    {
                        lblCliente.Text = Cliente.GetString(1);
                        OVehiculos = OHelper.RecuperarVehiculosPorClienteIdentificadoSinPrecio(Cliente.GetInt32(0)).Tables[0];
                        grdDetalleVehiculos.DataSource = OVehiculos;

                        OProductos = OHelper.RecuperarProductosPorPrecioClienteCreditoSinPrecio().Tables[0];
                        grdDetalleProductos.DataSource = OProductos;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Precio Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCliente.Clear();
                this.txtCliente.Focus();
            }


        }



        private void LimpiarCampos()
        {
            txtCliente.Clear();
            lblCliente.Text = "";
            chkEstado.Checked = true;
            chkAplicaEnSurtidor.Checked = true;
            OVehiculos.Rows.Clear();
            OProductos.Rows.Clear();
            grdDetalleVehiculos.DataSource = OVehiculos;
            grdDetalleProductos.DataSource = OProductos;



        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
            this.pnlEncabezado.Enabled = true;
            this.txtCliente.Enabled = true;





        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            //this.pnlBusqueda.Visible = false;
            this.toolStrip1.Enabled = true;
            this.pnlEncabezado.Enabled = false;
            this.pnlDetalle.Enabled = false;
            this.txtCliente.Clear();
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            EsGridDetalleConstruido = true;
            this.pnlDetalle.Enabled = true;
        }

        private void mnuDeshacer_Click(object sender, EventArgs e)
        {
            DesHacer();
        }

        private void DesHacer()
        {
            this.LimpiarCampos();
            this.pnlEncabezado.Enabled = false;
            this.pnlDetalle.Enabled = false;

            this.chkEstado.Enabled = false;
            this.chkAplicaEnSurtidor.Enabled = false;

            this.pnlDescuento.Enabled = false;
            this.mnuNew.Enabled = true;
            this.mnuFind.Enabled = true;
            this.mnuGuardar.Enabled = false;
            gbDescuento.Enabled = true;
            gbPorcentaje.Enabled = true;
            EsNuevoRegistro = false;
            gbDescuento.Enabled = false;
            gbPorcentaje.Enabled = false;
            chkEstado.Enabled = false;
            chkAplicaEnSurtidor.Enabled = false;
            txtValor.Enabled = false;
            txtValor.Text = "";
            rbDescuento.Checked = false;
            rbIncremento.Checked = false;
            rbPorcentaje.Checked = false;
            rbValor.Checked = false;
        }



        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarClienteCredito())
                {
                    String vehiculos = "";
                    String productos = "";
                    Int32 IdPrecioCliente = 0;
                    bool esDescuentoVehiculo = false;

                    //Verificar los vehiculos asociados de vehiculos
                    foreach (DataGridViewRow fila in grdDetalleVehiculos.Rows)
                    {
                        if (!fila.Cells["Asociado"].Value.Equals(DBNull.Value))
                        {
                            if (Convert.ToBoolean(fila.Cells["Asociado"].Value))
                            {
                                if (vehiculos == "")
                                    vehiculos = fila.Cells["IdVehiculo"].Value.ToString() + ",";
                                else
                                    vehiculos = vehiculos + fila.Cells["IdVehiculo"].Value.ToString() + ",";

                            }
                        }
                    }

                    //Verificar los vehiculos asociados de productos
                    foreach (DataGridViewRow fila in grdDetalleProductos.Rows)
                    {
                        if (!fila.Cells["dataGridViewColumnAsociado"].Value.Equals(DBNull.Value))
                        {
                            if (Convert.ToBoolean(fila.Cells["dataGridViewColumnAsociado"].Value))
                            {
                                if (productos == "")
                                    productos = fila.Cells["dataGridViewColumnIdProducto"].Value.ToString() + ",";
                                else
                                    productos = productos + fila.Cells["dataGridViewColumnIdProducto"].Value.ToString() + ",";

                            }
                        }
                    }


                    if (vehiculos != "")
                        esDescuentoVehiculo = true;



                    if (EsNuevoRegistro)
                        IdPrecioCliente = OHelper.InsertarPrecioClienteCredito(txtCliente.Text.Trim(), Convert.ToDecimal(txtValor.Text), rbPorcentaje.Checked, rbDescuento.Checked, chkEstado.Checked, esDescuentoVehiculo, chkAplicaEnSurtidor.Checked);
                    else
                        OHelper.ActualizarPrecioClienteCredito(oPrecioCliente, Convert.ToDecimal(txtValor.Text), rbPorcentaje.Checked, rbDescuento.Checked, chkEstado.Checked, esDescuentoVehiculo, chkAplicaEnSurtidor.Checked);


                    if (vehiculos != "")
                    {
                        if (EsNuevoRegistro)
                            OHelper.InsertarPrecioClienteCreditoVehiculo(IdPrecioCliente, vehiculos);
                        else
                            OHelper.InsertarPrecioClienteCreditoVehiculo(oPrecioCliente, vehiculos);
                    }


                    //guardando los productos
                    if (EsNuevoRegistro)
                        OHelper.InsertarPrecioClienteCreditoProductos(IdPrecioCliente, productos);
                    else
                        OHelper.InsertarPrecioClienteCreditoProductos(oPrecioCliente, productos);


                    DesHacer();
                    EsNuevoRegistro = false;
                    txtValor.Enabled = true;
                    Popup.ContentText = "\t\t\tData Administrator\n\nEl Precio Para el cliente fue guardado satisfactoriamente";
                    Popup.Popup();


                }
            }
            catch (Exception ex)
            {

                Popup.ContentText = ex.Message;
                Popup.Popup();
            }


        }

        private Boolean ValidarClienteCredito()
        {
            try
            {
                //Validamos que se haya checkeado si es por porcentaje o es por valor
                if (!rbPorcentaje.Checked && !rbValor.Checked)
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nDebe escoger si se va a aplicar el cambio de precio por Porcentaje o por Valor";
                    Popup.Popup();
                    gbPorcentaje.Focus();
                    return false;
                }
                else if (!rbDescuento.Checked && !rbIncremento.Checked)
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nDebe escoger si se va a aplicar un Descuento o un Incremento para este cliente";
                    Popup.Popup();
                    gbDescuento.Focus();
                    return false;
                }
                else if (txtValor.Text == "")
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nDebe colocar un valor de Descuento o Incremento valido";
                    Popup.Popup();
                    txtValor.Focus();
                    return false;
                }
                else
                {
                    //Obtenemos el valor que está en la caja de texto
                    decimal valor = Convert.ToDecimal(txtValor.Text);

                    //Evaluamos que el valor no sea 0
                    if (valor == 0 || valor < 0)
                    {
                        Popup.ContentText = "\t\t\tData Administrator\n\nEl valor de Descuento o Incremento no puede ser 0 ni menor que 0";
                        Popup.Popup();
                        txtValor.Focus();
                        return false;
                    }
                    else
                    {

                        //Evaluamos si es por porcentaje, en ese caso no debe superar el 100 por ciento
                        if (rbPorcentaje.Checked)
                        {
                            if (valor > 100)
                            {
                                Popup.ContentText = "\t\t\tData Administrator\n\nDebe colocar un valor valido";
                                Popup.Popup();
                                txtValor.Focus();
                                return false;
                            }
                            else
                                return true;
                        }

                    }

                }

                return true;
            }
            catch (Exception)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nDebe colocar datos validos";
                Popup.Popup();
                return false;
            }
        }

        private void grdDetalleVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDetalleVehiculos.Rows[e.RowIndex].Cells["Asociado"].Value == null)
                {
                    grdDetalleVehiculos.Rows[e.RowIndex].Cells["Asociado"].Value = true;
                }
                else if (!Convert.ToBoolean(grdDetalleVehiculos.Rows[e.RowIndex].Cells["Asociado"].Value))
                {
                    grdDetalleVehiculos.Rows[e.RowIndex].Cells["Asociado"].Value = true;
                }
                else if (Convert.ToBoolean(grdDetalleVehiculos.Rows[e.RowIndex].Cells["Asociado"].Value))
                {
                    grdDetalleVehiculos.Rows[e.RowIndex].Cells["Asociado"].Value = false;
                }

            }
            catch (Exception)
            {


            }




        }

        private void buscarDescuentos()
        {
            try
            {

                Controles.frmAyuda oAyuda = new frmAyuda();
                oAyuda.TituloVentana = "Precios Clientes";
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.Informacion = OHelper.RecuperarPrecioClienteCredito(this.txtCliente.Text).Tables[0];
                oAyuda.ColumnReturn = 0;
                oAyuda.ShowDialog();
                if ((string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado)) == false)
                {
                    this.RecuperaInformacion(oAyuda.ValorRegistroSeleccionado);
                    oPrecioCliente = Convert.ToInt32(oAyuda.ValorRegistroSeleccionado.ToString());
                }
                oAyuda.Dispose();
                pnlDescuento.Enabled = true;
                pnlDetalle.Enabled = true;
                txtCliente.Enabled = true;
                pnlDescuento.Enabled = true;
                gbDescuento.Enabled = true;
                gbPorcentaje.Enabled = true;
                chkEstado.Enabled = true;
                chkAplicaEnSurtidor.Enabled = true;
                txtValor.Enabled = true;
                mnuGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Precio Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (EsNuevoRegistro == false && e.KeyChar == 13)
                {
                    buscarDescuentos();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Precio Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RecuperaInformacion(string IdPrecioCliente)
        {
            try
            {

                if (string.IsNullOrEmpty(IdPrecioCliente) == false)
                {
                    DataTable OPrecios = OHelper.RecuperarPrecioClienteCredito(Convert.ToInt32(IdPrecioCliente)).Tables[0];
                    foreach (DataRow Row in OPrecios.Rows)
                    {
                        this.lblCliente.Text = Row["NombreCliente"].ToString();
                        this.chkEstado.Checked = Boolean.Parse(Row["EsActivo"].ToString());
                        this.chkAplicaEnSurtidor.Checked = Boolean.Parse(Row["AplicaEnSurtidor"].ToString());

                        if (Convert.ToBoolean(Row["AplicaPorcentaje"].ToString()))
                            rbPorcentaje.Checked = true;
                        else
                            rbValor.Checked = true;

                        if (Convert.ToBoolean(Row["EsDescuento"].ToString()))
                            rbDescuento.Checked = true;
                        else
                            rbIncremento.Checked = true;


                        txtValor.Text = Row["Valor"].ToString();


                    }
                    OVehiculos = OHelper.RecuperarVehiculosPorPrecioCliente(Convert.ToInt32(IdPrecioCliente)).Tables[0];
                    grdDetalleVehiculos.DataSource = OVehiculos;


                    OProductos = OHelper.RecuperarProductosPorPrecioClienteCredito(Convert.ToInt32(IdPrecioCliente)).Tables[0];
                    grdDetalleProductos.DataSource = OProductos;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Precio Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdDetalleProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDetalleProductos.Rows[e.RowIndex].Cells["dataGridViewColumnAsociado"].Value == null)
                {
                    grdDetalleProductos.Rows[e.RowIndex].Cells["dataGridViewColumnAsociado"].Value = true;
                }
                else if (!Convert.ToBoolean(grdDetalleProductos.Rows[e.RowIndex].Cells["dataGridViewColumnAsociado"].Value))
                {
                    grdDetalleProductos.Rows[e.RowIndex].Cells["dataGridViewColumnAsociado"].Value = true;
                }
                else if (Convert.ToBoolean(grdDetalleProductos.Rows[e.RowIndex].Cells["dataGridViewColumnAsociado"].Value))
                {
                    grdDetalleProductos.Rows[e.RowIndex].Cells["dataGridViewColumnAsociado"].Value = false;
                }
            }
            catch (Exception)
            {


            }



        }

        private void grdDetalleProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex + ":" + e.Exception.ToString());
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!existe)
                {
                    foreach (DataGridViewRow fila in grdDetalleVehiculos.Rows)
                    {
                        if (!fila.Cells["Asociado"].Value.Equals(DBNull.Value))
                        {
                            fila.Cells["Asociado"].Value = true;
                            existe = true;
                        }
                    }
                }
                else
                {


                    foreach (DataGridViewRow fila in grdDetalleVehiculos.Rows)
                    {
                        if (!fila.Cells["Asociado"].Value.Equals(DBNull.Value))
                        {
                            fila.Cells["Asociado"].Value = false;
                            existe = false;
                        }
                    }
                }

                if (existe)
                    btnSeleccionar.Text = "No seleccionar ninguno";
                else
                    btnSeleccionar.Text = "Seleccionar todos";


            }
            catch (Exception)
            {

                throw;
            }

        }






    }



}
