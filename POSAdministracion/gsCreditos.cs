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
using POSstation.Fabrica;

namespace PosSation.gsCreditos
{
    public partial class gsCreditos : UserControl
    {
        #region " Variables Declaradas "

        public enum TipoConsulta
        {
            EsEncabezado = 0,
            EsDocumento = 1,
            EsFacturacion = 3
        }

        Helper OHelper = new Helper();
        Boolean EsGridDetalleConstruido;
        Boolean EsNuevoRegistro;
        Clientes rCliente = new Clientes();
        EncabezadoCreditoConsumo eCredito = new EncabezadoCreditoConsumo();
        DataSet tbProductos = new DataSet();
        DataTable dtDetalleCredito = new DataTable();
        public Int32 oCredito;
        Dictionary<int, bool> ManejosCupo = new Dictionary<int, bool>();
        Dictionary<int, Recarga> Recargas = new Dictionary<int, Recarga>();
        
        Boolean ManejaCupoVehiculo = false;

        private int? tipoCreditoSeleccionado;

        #endregion

        #region " Propiedades del Formulario "

        public Int32 Credito
        {
            get
            {
                return oCredito;
            }
            set
            {
                oCredito = value;
            }
        }

        #endregion

        public gsCreditos()
        {
            InitializeComponent();
        }

        public event EventHandler oClosed;

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            EsNuevoRegistro = false;
            pnlEncabezado.Enabled = true;
            this.Visible = false;
            this.oClosed(sender, e);
        }

        public void IniciarForma()
        {


            pnlDetalle.Enabled = false;
            this.txtCupo.Text = "0";
            this.txtPlazoPagoFactura.Text = "10";


            //tbProductos.Load(OHelper.RecuperarProductos(), LoadOption.Upsert, "Productos");
            DataGridViewComboBoxColumn ComboEstado = (DataGridViewComboBoxColumn)this.dtgDetalle.Columns["Estado"];
            ComboEstado.DisplayMember = "DescripcionEstado";
            ComboEstado.ValueMember = "IdEstado";
            ComboEstado.DataSource = OHelper.RecuperarEstadosCreditos().Tables[0];

            /*DataGridViewComboBoxColumn ComboProducto = (DataGridViewComboBoxColumn)this.dtgDetalle.Columns["cmbProducto"];
            ComboProducto.DisplayMember = "Nombre";
            ComboProducto.ValueMember = "IdProducto";
            ComboProducto.DataSource = OHelper.RecuperarProductosDataset().Tables[0];*/


            DataTable tabla_aux = OHelper.RecuperarTipoCredito().Tables[0];
            foreach (DataRow dr in tabla_aux.Rows)
            {
                ManejosCupo[int.Parse(dr["IdTipoCredito"].ToString())] = bool.Parse(dr["ManejaCupo"].ToString());
            }

            cmbTipoCredito.ValueMember = "IdTipoCredito";
            cmbTipoCredito.DisplayMember = "Descripcion";
            cmbTipoCredito.DataSource = tabla_aux;


            comboTipoFacturacion.DataSource = OHelper.RecuperarTipoFacturacion("*").Tables[0];


            DesHacer();

            if (oCredito > 0)
            {
                DataTable oEncabezado;
                oEncabezado = OHelper.RecuperarEncabezadoCredito(oCredito.ToString(), Helper.oAccion.EsEncabezado).Tables[0];
                foreach (DataRow Row in oEncabezado.Rows)
                {
                    this.txtCliente.Text = Row["nuip"].ToString();
                  
                }

                CargarCliente();

                this.RecuperaInformacion(oCredito.ToString());
               
                
            }



        }
        public void CargarCliente(string dni)
        {
            try
            {
                // si no es un registro nuevo y existe traigo los datos del credito.

                DataTable cli = OHelper.RecuperarClientePorIdentificacion(dni).Tables[0];


                if (cli.Rows.Count > 0)
                {
                    this.txtCliente.Enabled = false;
                    txtNombre.Text = cli.Rows[0]["Nombre"].ToString();
                    txtDireccion.Text = cli.Rows[0]["Direccion"].ToString();
                    txtTelefono.Text = cli.Rows[0]["Telefono"].ToString();
                    eCredito.IdCliente = int.Parse(cli.Rows[0]["IdCliente"].ToString());
                    gridCreditos.AutoGenerateColumns = false;
                    gridCreditos.DataSource = OHelper.RecuperarEncabezadoCredito(this.txtCliente.Text, Helper.oAccion.EsDocumento).Tables[0];
                    panelCreditos.Visible = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void CargarCliente()
        {
            try
            {
                // si no es un registro nuevo y existe traigo los datos del credito.

                DataTable cli = OHelper.RecuperarClientePorIdentificacion(this.txtCliente.Text).Tables[0];
         

                if (cli.Rows.Count > 0)
                {
                    this.txtCliente.Enabled = false;
                    txtNombre.Text = cli.Rows[0]["Nombre"].ToString();
                    txtDireccion.Text = cli.Rows[0]["Direccion"].ToString();
                    txtTelefono.Text = cli.Rows[0]["Telefono"].ToString();
                    eCredito.IdCliente = int.Parse(cli.Rows[0]["IdCliente"].ToString());
                    gridCreditos.AutoGenerateColumns = false;
                    gridCreditos.DataSource = OHelper.RecuperarEncabezadoCredito(this.txtCliente.Text, Helper.oAccion.EsDocumento).Tables[0];
                    panelCreditos.Visible = true;
                                      
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CargarCliente();
            }


        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEstado.Checked == true)
            {
                eCredito.Estado = true;
            }
            else
            {
                eCredito.Estado = false;
            }
        }


        private void LimpiarCampos()
        {
            dtDetalleCredito.Rows.Clear();
            this.dtgDetalle.DataSource = dtDetalleCredito;
            txtCliente.Clear();
            txtCupo.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            //lblCliente.Text = "";
            rCliente.IdCliente = 0;
            rCliente.Nombre = "";
            eCredito.Cupo = 0;
            chkEstado.Checked = true;
            //eCredito.Estado = true;
            eCredito.FechaCreacion = DateTime.Now;
            eCredito.FechaExpira = DateTime.Now;
            eCredito.FechaUpdate = DateTime.Now;
            eCredito.IdCliente = 0;
            eCredito.IdCreditoConsumo = 0;
            eCredito.Producto = 0;
            eCredito.TipoCredito = 0;
            comboTipoFacturacion.Enabled = false;
        }


        public void RecuperaInformacion(string IdCreditoConsumo)
        {
            try
            {
                string SaldoCredito = "";
                lblsaldocredito.Text = "";
                DataTable oEncabezado;
                if (string.IsNullOrEmpty(IdCreditoConsumo) == false)
                {
                    
                    eCredito.IdCreditoConsumo = Int32.Parse(IdCreditoConsumo);
                    if (Int32.Parse(IdCreditoConsumo) > 0)
                        oCredito = Int32.Parse(IdCreditoConsumo);

                    if (oCredito == 0)
                    {
                        oEncabezado = OHelper.RecuperarEncabezadoCredito(this.txtCliente.Text, Helper.oAccion.EsDocumento).Tables[0];
                    }
                    else
                    {
                        oEncabezado = OHelper.RecuperarEncabezadoCredito(IdCreditoConsumo, Helper.oAccion.EsEncabezado).Tables[0];
                    }

                    foreach (DataRow Row in oEncabezado.Rows)
                    {
                        this.txtCliente.Text = Row["nuip"].ToString();
                        //this.lblCliente.Text = Row["nombre"].ToString();
                        this.chkEstado.Checked = Boolean.Parse(Row["estado"].ToString());
                        txtCupo.Text = Row["cupo"].ToString();
                        comboTipoFacturacion.SelectedValue = Row["IdTipoFacturacion"].ToString();
                        this.cmbTipoCredito.Text = Row["TipoCredito"].ToString();
                        this.chkManejarCupoVehiculo.Checked = Boolean.Parse(Row["ManejaCupoPorVehiculo"].ToString());
                        if (Boolean.Parse(Row["ManejaCupoPorVehiculo"].ToString()))
                        {
                            lblsaldocredito.Visible = false;
                        }
                        else
                        {
                            lblsaldocredito.Visible = true;
                        }

                        this.chkUsarEnCanastilla.Checked = Boolean.Parse(Row["PermitirUsoEnCanastilla"].ToString());
                        this.txtPlazoPagoFactura.Text = Row["PlazoPagoFactura"].ToString();
                        dtgDetalle.Columns["ColumnaRecargarPrepago"].Visible = this.chkManejarCupoVehiculo.Checked;
                        dtgDetalle.Columns["CupoAsignado"].ReadOnly = !this.chkManejarCupoVehiculo.Checked;
                        SaldoCredito = Convert.ToString(OHelper.RecuperarSaldoCreditoConsumo(IdCreditoConsumo));
                        if (SaldoCredito != "-1,00")
                        {                          
                            this.lblsaldocredito.Text = "Saldo Crédito: "+ SaldoCredito;
                        }

                        this.chkAplicaRenovacion.Checked = Boolean.Parse(Row["AplicaRenovacion"].ToString());
                        txtPeriodo.Text = Row["PeriodoRenovacion"].ToString();
                      
                    }

                    comboTipoFacturacion.Enabled = false;

                    this.toolStrip1.Enabled = true;
                    this.pnlEncabezado.Enabled = true;
                    this.cmbTipoCredito.Enabled = true;
                    this.chkEstado.Enabled = true;
                    this.txtCupo.Enabled = true;
                    pnlDetalle.Enabled = true;
                    dtDetalleCredito.Clear();
                    dtDetalleCredito = OHelper.RecuperarDetalleCreditoConsumo(eCredito.IdCreditoConsumo).Tables[0];
                    //dtDetalleCredito.Rows.
                    dtgDetalle.AutoGenerateColumns = false;
                    dtgDetalle.DataSource = dtDetalleCredito;
                    EsGridDetalleConstruido = true;
                    panelCreditos.Visible = false;
                    panelEditarCredito.Visible = true;
                    txtCupo.Focus();
                    EsNuevoRegistro = false;
                    PanelRecargaCredito.Visible = false;
                    //panelEditarCredito.Top = panellCliente.Size.Height + panellCliente.Top + 10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void mnuDeshacer_Click(object sender, EventArgs e)
        {
            DesHacer();
        }

        private void DesHacer()
        {
            this.LimpiarCampos();
            panelCreditos.Visible = false;
            txtCliente.Enabled = true;
            panelEditarCredito.Visible = false;

            //this.lblTipoFacturacion.Text = "<< Ninguno >>";
            EsNuevoRegistro = false;
        }


        private void gridCreditos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RecuperaInformacion(gridCreditos.Rows[e.RowIndex].Cells["ColumnaIdCredito"].Value.ToString());
        }

        private void gridCreditos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 7)
                {
                    RecuperaInformacion(gridCreditos.Rows[e.RowIndex].Cells["ColumnaIdCredito"].Value.ToString());
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    if (Convert.ToBoolean(gridCreditos.Rows[e.RowIndex].Cells["ManejaCupoV"].Value.ToString()))
                        throw new Exception("No se pueden realizar recargas a éste crédito por que maneja cupo por vehículos.");


                    if (gridCreditos.Rows[e.RowIndex].Cells["ColumnaIdCredito"].Value.ToString() == "0")
                    {
                        throw new Exception("Este es un nuevo Detalle, no se pueden agregar recargas al credito");
                    }
                    eCredito.IdCreditoConsumo = long.Parse(gridCreditos.Rows[e.RowIndex].Cells["ColumnaIdCredito"].Value.ToString());
                    
                    this.PanelRecargaCredito.Visible = true;
                    //this.panelInfoCredito.Enabled = false;
                    this.gridCreditos.Enabled = false;
                    this.txtRCupoCredito.Text = gridCreditos.Rows[e.RowIndex].Cells["ColumnaCupo"].Value.ToString();
                    this.TxtRSaldoCredito.Text = Convert.ToString(OHelper.RecuperarSaldoCreditoConsumo(gridCreditos.Rows[e.RowIndex].Cells["ColumnaIdCredito"].Value.ToString()));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelCreditos.Visible = true;
            panelEditarCredito.Visible = false;


        }


        private void btnCancelarRecarga_Click(object sender, EventArgs e)
        {
            panelInfoCredito.Enabled = true;
            pnlDetalle.Visible = true;
            panelRecarga.Visible = false;
        }


        public static Boolean IsNumeric(string valor)
        {
            int result;
            return int.TryParse(valor, out result);
        }

        private void btnGuardarRecarga_Click(object sender, EventArgs e)
        {
            string NoDocumento = "";


            try
            {
                Boolean oAfectacion;
                string Origen;
                Int32 oResultado;
                Decimal CupoAsignado = 0;
                if (txtMonto.TextLength < 1 || txtMonto.Text == "0")
                    throw new Exception("Debe Ingresar un valor valido para la Cantidad($)");

                if (cmbAfectacion.Text != "")
                {

                    if (cmbAfectacion.Text == "Recargar")
                    {
                        oAfectacion = true;
                        Origen = "Recarga Prepago";
                        NoDocumento = "0";
                        oResultado = Int32.Parse(txtSaldoDisponible.Text.ToString()) + Int32.Parse(txtMonto.Text);
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(txtDocumento.Text.Trim()))
                        {
                            txtDocumento.Focus();
                            throw new Exception("Debe Ingresar un No. Documento valido");
                        }

                        if (!IsNumeric(txtDocumento.Text.Trim()))                        
                        {
                            txtDocumento.Focus();
                            throw new Exception("El No. Documento debe ser un valor númerico");
                        }

                        oAfectacion = false;
                        Origen = "Descarga Prepago";
                        NoDocumento = txtDocumento.Text;
                        if (Int32.Parse(txtMonto.Text) <= Int32.Parse(txtSaldoDisponible.Text.ToString()))
                        {
                            oResultado = Int32.Parse(txtSaldoDisponible.Text.ToString()) - Int32.Parse(txtMonto.Text);
                        }
                        else
                        {
                            throw new Exception("La cantidad ingresada es mayor que el valor del saldo asignado, Por favor verifique");
                        }
                    }

                    if (!String.IsNullOrEmpty(txtCupoVehiculo.Text))
                    {
                        Validacion.ValidarNumeroDecimal(txtCupoVehiculo.Text, "El Cupo");
                        CupoAsignado = Decimal.Parse(txtCupoVehiculo.Text);
                    }

                    if (CupoAsignado < oResultado)
                    {
                        throw new Exception("La cantidad ingresada más el saldo disponible es mayor que el valor del cupo asignado, Por favor verifique");
                    }

                    if (Recargas.ContainsKey(dtgDetalle.CurrentRow.Index))
                    {
                        Recargas[dtgDetalle.CurrentRow.Index] = new Recarga(oAfectacion, Decimal.Parse(txtMonto.Text), dtpFecha.Value.ToString("yyyyMMdd"), txtComentario.Text, Int64.Parse(NoDocumento), Origen, txtPlaca.Text, CupoAsignado);
                    }
                    else
                    {
                        Recargas.Add(dtgDetalle.CurrentRow.Index, new Recarga(oAfectacion, Decimal.Parse(txtMonto.Text), dtpFecha.Value.ToString("yyyyMMdd"), txtComentario.Text, Int64.Parse(NoDocumento), Origen, txtPlaca.Text, CupoAsignado));
                    }

                    Recargas[dtgDetalle.CurrentRow.Index].SaldoAnterior = decimal.Parse(txtSaldoDisponible.Text.ToString());
                    dtgDetalle.CurrentRow.Cells["SaldoDisponible"].Value = oResultado.ToString();
                    //(dtgDetalle.CurrentRow.Cells["ColumnaRecargarPrepago"] as DataGridViewLinkCell).Value = "Modificar Recarga";

                    txtDocumento.Clear();
                    txtMonto.Clear();
                    txtComentario.Clear();
                    txtCupoVehiculo.Clear();
                    txtPlaca.Clear();
                    txtSaldoDisponible.Text = "";
                    panelInfoCredito.Enabled = true;
                    pnlDetalle.Visible = true;
                    panelRecarga.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipoCreditoSeleccionado.HasValue && tipoCreditoSeleccionado.Value != cmbTipoCredito.SelectedIndex)
            {
                if (!ManejosCupo[int.Parse(cmbTipoCredito.SelectedValue.ToString())])
                {
                    if (Recargas.Count > 0)
                    {
                        if (MessageBox.Show("Esta operación borraría las recargas ingresadas previamente. Desea continuar?", "SAUCE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                        {
                            dtgDetalle.Columns["ColumnaRecargarPrepago"].Visible = false;
                            foreach (KeyValuePair<int, Recarga> item in Recargas)
                            {
                                dtgDetalle.Rows[item.Key].Cells[dtgDetalle.Columns["SaldoDisponible"].Index].Value = item.Value.SaldoAnterior;
                            }
                            Recargas.Clear();
                            tipoCreditoSeleccionado = (cmbTipoCredito.SelectedIndex == -1 ? null : (int?)cmbTipoCredito.SelectedIndex);
                        }
                        else
                        {
                            cmbTipoCredito.SelectedIndex = tipoCreditoSeleccionado.Value;
                        }

                    }
                    else
                        tipoCreditoSeleccionado = (cmbTipoCredito.SelectedIndex == -1 ? null : (int?)cmbTipoCredito.SelectedIndex);
                }
                else
                    tipoCreditoSeleccionado = (cmbTipoCredito.SelectedIndex == -1 ? null : (int?)cmbTipoCredito.SelectedIndex);
            }
            else
                tipoCreditoSeleccionado = (cmbTipoCredito.SelectedIndex == -1 ? null : (int?)cmbTipoCredito.SelectedIndex);
            chkManejarCupoVehiculo.Enabled = ManejosCupo[int.Parse(cmbTipoCredito.SelectedValue.ToString())];
            if (!ManejosCupo[int.Parse(cmbTipoCredito.SelectedValue.ToString())])
                chkManejarCupoVehiculo.Checked = false;
        }


        private void btnAgregarCredito_Click(object sender, EventArgs e)
        {
            try
            {
                this.toolStrip1.Enabled = true;
                this.pnlEncabezado.Enabled = true;
                this.cmbTipoCredito.Enabled = true;
                this.cmbTipoCredito.SelectedIndex = 0;
                this.chkEstado.Enabled = true;
                this.txtCupo.Enabled = true;
                txtCupo.Text = "";
                pnlDetalle.Enabled = true;
                comboTipoFacturacion.Enabled = true;
                dtDetalleCredito.Clear();
                dtDetalleCredito = OHelper.RecuperarDetalleCreditoConsumo(-1).Tables[0];
                dtgDetalle.AutoGenerateColumns = false;
                dtgDetalle.DataSource = dtDetalleCredito;
                dtgDetalle.Columns["ColumnaRecargarPrepago"].Visible = false;
                dtgDetalle.Columns["CupoAsignado"].ReadOnly = true;
                EsGridDetalleConstruido = true;
                panelCreditos.Visible = false;
                panelEditarCredito.Visible = true;
                EsNuevoRegistro = true;
                lblsaldocredito.Visible = false;
                lblsaldocredito.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Instancias oInstancias = new Instancias();

            decimal Cupo, CupoAsignado = 0, TotalCupoVehiculos = 0, SaldoDisponible = 0;

            try
            {
                Decimal.TryParse(txtCupo.Text, out Cupo);

                if (String.IsNullOrEmpty(comboTipoFacturacion.Text))
                {
                    throw new Exception("Debe Seleccionar un tipo de facturación valido");
                }

                if (String.IsNullOrEmpty(this.txtPlazoPagoFactura.Text))
                {
                    throw new Exception("Debe digitar un valor para el Plazo de pago de factura");
                }
                else
                {
                    int plazoPagoFactura;

                    if (!int.TryParse(this.txtPlazoPagoFactura.Text, out plazoPagoFactura))
                    {
                        throw new Exception("El Plazo de pago de factura debe ser un numero");
                    }

                    if (plazoPagoFactura <= 0 || plazoPagoFactura > 15)
                    {
                        throw new Exception("El Plazo de pago de factura debe ser estar entre 1 a 15 dias");
                    }
                }


                foreach (DataRow dRow in dtDetalleCredito.Rows)
                {
                    if (String.IsNullOrEmpty(dRow["IdEstado"].ToString()))
                    {
                        throw new Exception("Existen estados sin seleccionar");
                    }
                }

                if (chkManejarCupoVehiculo.Checked)
                {
                    if (OHelper.ManejaCupoTipoCredito(Int32.Parse(cmbTipoCredito.SelectedValue.ToString())))
                    {
                        foreach (DataRow dRow in dtDetalleCredito.Rows)
                        {
                            CupoAsignado = 0;
                            if (dRow["CupoAsignado"] != null)
                            {
                                if (!String.IsNullOrEmpty(dRow["CupoAsignado"].ToString()))
                                {
                                    if (!dRow["IdEstado"].ToString().ToString().Equals("3"))
                                        CupoAsignado = Decimal.Parse(dRow["CupoAsignado"].ToString());
                                    else
                                        CupoAsignado = 0;
                                }
                            }

                            SaldoDisponible = 0;
                            if (dRow["SaldoDisponible"] != null)
                            {
                                if (!String.IsNullOrEmpty(dRow["SaldoDisponible"].ToString()))
                                {
                                    SaldoDisponible = Decimal.Parse(dRow["SaldoDisponible"].ToString());
                                }
                            }

                            if (SaldoDisponible > CupoAsignado){
                                if (!dRow["IdEstado"].ToString().ToString().Equals("3"))
                                throw new Exception("El saldo disponible del vehículo " + dRow["Vehiculo"].ToString() + " supera a su cupo asignado.");
                            }
                            TotalCupoVehiculos += CupoAsignado;
                        }

                        if (Decimal.Parse(txtCupo.Text) < TotalCupoVehiculos)
                        {
                            MessageBox.Show("El cupo asignado a los vehiculos supera el cupo del credito", "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }


                if ((chkAplicaRenovacion.Checked) && (string.IsNullOrEmpty(txtPeriodo.Text)))
                {
                    this.txtPeriodo.Focus();
                    throw new Exception("Debe ingresar el Periodo de Renovación");
                }

                int PeriodoRenovacion = 0;
                if (chkAplicaRenovacion.Checked)
                    PeriodoRenovacion = Convert.ToInt32(txtPeriodo.Text);

                if (EsNuevoRegistro)
                {
                    eCredito.IdCreditoConsumo = OHelper.InsertarEncabezadoCredito(eCredito.IdCliente, Cupo, int.Parse(cmbTipoCredito.SelectedValue.ToString()), chkEstado.Checked, comboTipoFacturacion.Text, chkManejarCupoVehiculo.Checked, this.chkUsarEnCanastilla.Checked, false, DateTime.Now, null, Int32.Parse(txtPlazoPagoFactura.Text), this.chkAplicaRenovacion.Checked, PeriodoRenovacion);
                }
                else
                {
                    OHelper.InsertarEncabezadoCredito(eCredito.IdCreditoConsumo, eCredito.IdCliente, Cupo, int.Parse(cmbTipoCredito.SelectedValue.ToString()), chkEstado.Checked, comboTipoFacturacion.Text, chkManejarCupoVehiculo.Checked, this.chkUsarEnCanastilla.Checked, false, DateTime.Now, null, Int32.Parse(txtPlazoPagoFactura.Text), this.chkAplicaRenovacion.Checked, PeriodoRenovacion);
                }

                int i = 0;
                foreach (DataRow dRow in dtDetalleCredito.Rows)
                {
                    CupoAsignado = 0;
                    if (chkManejarCupoVehiculo.Checked)
                    {
                        if (dRow["CupoAsignado"] != null)
                        {
                            if (!String.IsNullOrEmpty(dRow["CupoAsignado"].ToString()))
                            {
                                CupoAsignado = Decimal.Parse(dRow["CupoAsignado"].ToString());
                            }
                        }
                    }

                    //Para el IdProducto se envía -1 porque actualmente no se está utilizando
                    if (OHelper.InsertarDetalleCredito(eCredito.IdCreditoConsumo, Int32.Parse(dRow["IdVehiculo"].ToString()), -1, Int16.Parse(dRow["IdEstado"].ToString()), Boolean.Parse("False"), CupoAsignado) == false)
                    {
                        MessageBox.Show("Error Insertando Vehiculo" + dRow["Placa"].ToString(), "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Recargas.ContainsKey(i))
                    {
                        try
                        {
                            if (!OHelper.InsertarPrepago(Recargas[i].Afectacion, Recargas[i].Monto, Recargas[i].FechaInsercion, Recargas[i].Concepto, Recargas[i].Documento, eCredito.IdCreditoConsumo, Recargas[i].Origen, Recargas[i].Placa, Recargas[i].CupoAsignado) == true)
                            {
                                MessageBox.Show("Error insertando recarga. " + dRow["Placa"].ToString(), "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                Recargas.Clear();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error insertando recarga. " + ex.Message, "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                        if (dRow["IdEstado"].ToString().Equals("3"))
                        {
                            if ((Convert.ToDecimal(dRow["SaldoDisponible"].ToString()) > 0) || (Convert.ToDecimal(dRow["CupoAsignado"].ToString()) > 0))
                            {
                                OHelper.DisminuirCupoVehiculoRetirado(dRow["Vehiculo"].ToString(), eCredito.IdCreditoConsumo.ToString());
                            }
                        }

                    }
                    i++;
                }

                MessageBox.Show("El credito se registró con éxito", "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);


                dtgDetalle.DataSource = false;

                pnlEncabezado.Enabled = false;
                pnlDetalle.Enabled = false;
                EsGridDetalleConstruido = false;
                EsNuevoRegistro = false;

                panelCreditos.Visible = true;
                panelEditarCredito.Visible = false;


                DataTable cli = OHelper.RecuperarClientePorIdentificacion(this.txtCliente.Text).Tables[0];

                if (cli.Rows.Count > 0)
                {
                    this.txtCliente.Enabled = false;
                    txtNombre.Text = cli.Rows[0]["Nombre"].ToString();
                    txtDireccion.Text = cli.Rows[0]["Direccion"].ToString();
                    txtTelefono.Text = cli.Rows[0]["Telefono"].ToString();
                    eCredito.IdCliente = int.Parse(cli.Rows[0]["IdCliente"].ToString());
                    gridCreditos.AutoGenerateColumns = false;
                    gridCreditos.DataSource = OHelper.RecuperarEncabezadoCredito(this.txtCliente.Text, Helper.oAccion.EsDocumento).Tables[0];
                    panelCreditos.Visible = true;
                }


                //else
                //{ 

                //}
            }
            catch (Exception ex)
            {
                //EsNuevoRegistro = false;
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void chkManejarCupoVehiculo_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkManejarCupoVehiculo.Checked)
            {
                if (Recargas.Count > 0)
                {
                    if (MessageBox.Show("Esta operación borraría las recargas ingresadas previamente. Desea borrarlas?", "SAUCE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (KeyValuePair<int, Recarga> item in Recargas)
                        {
                            dtgDetalle.Rows[item.Key].Cells[dtgDetalle.Columns["SaldoDisponible"].Index].Value = item.Value.SaldoAnterior;
                        }
                        Recargas.Clear();
                    }
                    else
                    {
                        chkManejarCupoVehiculo.Checked = true;
                    }
                }
                chkAplicaRenovacion.Checked = false;
                txtPeriodo.Text = "";
                chkAplicaRenovacion.Visible = false;
                lblPeriodo.Visible = false;
                txtPeriodo.Visible = false;
            }
            else
            {
                chkAplicaRenovacion.Visible = true;
                lblPeriodo.Visible = true;
                txtPeriodo.Visible = true;
            }

            dtgDetalle.Columns["ColumnaRecargarPrepago"].Visible = chkManejarCupoVehiculo.Checked && !EsNuevoRegistro;
            dtgDetalle.Columns["CupoAsignado"].ReadOnly = !chkManejarCupoVehiculo.Checked;

        }

        private void btnEliminarRecarga_Click(object sender, EventArgs e)
        {
            dtgDetalle.CurrentRow.Cells["SaldoDisponible"].Value = Recargas[dtgDetalle.CurrentRow.Index].SaldoAnterior;
            Recargas.Remove(dtgDetalle.CurrentRow.Index);

            txtDocumento.Clear();
            txtMonto.Clear();
            txtComentario.Clear();
            txtCupoVehiculo.Clear();
            txtPlaca.Clear();
            txtSaldoDisponible.Text = "";
            panelInfoCredito.Enabled = true;
            pnlDetalle.Visible = true;
            panelRecarga.Visible = false;
        }


        #region "Grilla Vehiculos"
        private void dtgDetalle_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            DataGridViewRow row = dtgDetalle.CurrentRow;

            if (!row.IsNewRow)
            {
                if (row.Cells["IdCreditoVehiculo"].Value.ToString() == "0" && e.ColumnIndex == row.Cells["Placa"].ColumnIndex)
                {
                    e.Cancel = true;
                    return;
                }
            }
            //row.DefaultCellStyle.BackColor = Color.FromArgb(243, 144, 26);// Color.Red;
            row.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void dtgDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            Point c = dtgDetalle.CurrentCellAddress;
            /*
                        if (c.X == dtgDetalle.Rows[c.Y].Cells["Placa"].ColumnIndex)
                        {
                            TextBox oTexbox = (e.Control as DataGridViewTextBoxEditingControl);
                            oTexbox.KeyUp += oTexbox_KeyUp;
                            oTexbox.KeyPress +=oTexbox_KeyPress2;
                            //SeleccionarPlaca(c);
                        }
                        else*/
            if (c.X == dtgDetalle.Rows[c.Y].Cells["CupoAsignado"].ColumnIndex)
            {
                TextBox oTexbox2 = (e.Control as TextBox);
                oTexbox2.KeyPress += oTexbox_KeyPress;
            }
        }


        private void SeleccionarPlaca()
        {

            Helper oHelper = new Helper();
            frmBuscarVehiculosCliente oBuscar = new frmBuscarVehiculosCliente();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Placa"));
            foreach (DataGridViewRow dr in dtgDetalle.Rows)
            {
                if (dr.Index >= 0 && !dr.IsNewRow)
                {
                    DataRow fila = dt.NewRow();
                    fila["Placa"] = dr.Cells["Placa"].Value.ToString();
                    dt.Rows.Add(fila);
                }
            }
            oBuscar.IndentificacionCliente = txtCliente.Text;
            oBuscar.Excluir = dt;
            oBuscar.ShowDialog();

            EsGridDetalleConstruido = true;


            if (oBuscar.Resultado != null)
            {
                foreach (DataRow dr_aux in oBuscar.Resultado)
                {
                    DataRow dr = dtDetalleCredito.NewRow();
                    dr["Vehiculo"] = dr_aux["Placa"];
                    dr["IdVehiculo"] = +OHelper.RecuperarIdVehiculo(dr_aux["Placa"].ToString());

                    dr["IdCreditoVehiculo"] = 0;
                    dr["CupoAsignado"] = 0;
                    dr["SaldoDisponible"] = 0;

                    dr["FechaIngreso"] = DateTime.Now;

                    dtDetalleCredito.Rows.Add(dr);
                }
            }
            oBuscar.Dispose();
        }
        void oTexbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //' obtener indice de la columna 
                //' comprobar si la celda en edición corresponde
                if (dtgDetalle.CurrentCell.ColumnIndex == dtgDetalle.CurrentRow.Cells["CupoAsignado"].ColumnIndex)
                {
                    //'Comprobamos que solo introduzca
                    //' char.IsNumber = Solo números
                    //'46 = Punto decimal. 
                    //'127 = Suprimir.
                    //'8 = Retroceso.

                    int punto = 44;
                    if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                        punto = 46;


                    if (Char.IsNumber(e.KeyChar) || e.KeyChar == punto || e.KeyChar == 127 || e.KeyChar == 8)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "vb.net", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dtgDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtgDetalle.Rows[e.RowIndex].Cells["ColumnaRecargarPrepago"].ColumnIndex)
                {

                    if (dtgDetalle.Rows[e.RowIndex].Cells["Estado"].Value.ToString() == "3")
                    {

                        MessageBox.Show("No puede recargar un vehiculo retirado, primero activelo, presione guardar e intente nuevamente");
                        return;
                    }

                    if (dtgDetalle.Rows[e.RowIndex].Cells["CupoAsignado"].Value.ToString() == "" || double.Parse(dtgDetalle.Rows[e.RowIndex].Cells["CupoAsignado"].Value.ToString()) <= 0)
                    {
                        throw new Exception("Asigne primero un cupo");
                    }

                    if (dtgDetalle.Rows[e.RowIndex].Cells["IdCreditoVehiculo"].Value.ToString() == "0")
                    {
                        throw new Exception("Este es un nuevo vehículo, no se puede agregar recargas");
                    }
                  

                  
                    pnlDetalle.Visible = false;
                    panelRecarga.Visible = true;
                   // panelInfoCredito.Enabled = false;
                    txtPlaca.Text = dtgDetalle.Rows[e.RowIndex].Cells["Placa"].Value.ToString();
                    txtSaldoDisponible.Text = dtgDetalle.Rows[e.RowIndex].Cells["SaldoDisponible"].Value.ToString() == "" ? "0" : dtgDetalle.Rows[e.RowIndex].Cells["SaldoDisponible"].Value.ToString();
                    txtCupoVehiculo.Text = dtgDetalle.Rows[e.RowIndex].Cells["CupoAsignado"].Value.ToString();
                    btnEliminarRecarga.Visible = false;
                    btnGuardarRecarga.Text = "Guardar Recarga";
                    if (Recargas.ContainsKey(e.RowIndex))
                    {
                        btnEliminarRecarga.Visible = true;
                        btnGuardarRecarga.Text = "Modificar Recarga";
                        cmbAfectacion.Text = Recargas[e.RowIndex].Afectacion ? "Recargar" : "Disminuir Saldo";
                        txtDocumento.Text = Recargas[e.RowIndex].Documento.ToString();
                        txtMonto.Text = Recargas[e.RowIndex].Monto.ToString();
                        txtSaldoDisponible.Text = Recargas[e.RowIndex].SaldoAnterior.ToString();
                        dtpFecha.Value = new DateTime(int.Parse(Recargas[e.RowIndex].FechaInsercion.Substring(0, 4)), int.Parse(Recargas[e.RowIndex].FechaInsercion.Substring(4, 2)), int.Parse(Recargas[e.RowIndex].FechaInsercion.Substring(6, 2)));
                        //cmbAfectacion.Focus();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAUCE");
            }
        }

        private void dtgDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            //MessageBox.Show(e.ColumnIndex + ":" + e.Exception.ToString());
        }


        private void btnAgregarVehiculos_Click(object sender, EventArgs e)
        {
            SeleccionarPlaca();
        }



        #endregion

        
        private void BtnRGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string Origen = "";
                Decimal Resultado =0;
                if (txtRCantidad.Text == "")
                    throw new Exception("Por Favor digite la cantidad a Recargar.");

                if (txtRDocumento.Text =="")
                    throw new Exception("Por Favor digite el Documento.");

               
                if (Convert.ToDecimal(txtRCantidad.Text) < 0)
                    throw new Exception("No se pueden Ingresar cantidades menores o iguales a 0.");


                if (CmbROperacion.Text != "")
                {

                    if (CmbROperacion.Text == "Recargar")
                    {
                        if ((Convert.ToDecimal(txtRCantidad.Text) + Convert.ToDecimal(TxtRSaldoCredito.Text)) > Convert.ToDecimal(txtRCupoCredito.Text))
                            throw new Exception("La cantidad digitada mas el saldo actual del credito supera el Cupo.");

                        Origen = "Recarga Prepago";
                        Resultado = Decimal.Parse(TxtRSaldoCredito.Text) + Decimal.Parse(txtRCantidad.Text);
                    }
                    else
                    {
                        if (( Convert.ToDecimal(TxtRSaldoCredito.Text)-Convert.ToDecimal(txtRCantidad.Text)) < 0)
                            throw new Exception("La cantidad digitada menos el saldo actual del credito es menor que 0, por favor verifique.");

                        Origen = "Descarga Prepago";
                        Resultado = Decimal.Parse(TxtRSaldoCredito.Text) - Decimal.Parse(txtRCantidad.Text);
                    }

                    OHelper.InsertarSaldoCreditoConsumo(eCredito.IdCreditoConsumo, Origen, txtRDocumento.Text, Resultado,dtpFecha.Value);
                    LimpiarCamposRecargaCredito();
                    PanelRecargaCredito.Visible = false;
                    gridCreditos.Enabled = true;
                    panelEditarCredito.Enabled = true;

                }
                else
                {
                    throw new Exception("Seleccione un tipo de Operación Recarga/Descarga");
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SAUCE");
            }
        }
        private void LimpiarCamposRecargaCredito()
        {
            txtRCantidad.Text = "";
            txtRDocumento.Text= "";
            txtRObservaciones.Text = "";
        }

        private void BtnRCancelar_Click(object sender, EventArgs e)
        {
            panelInfoCredito.Enabled = true;
            pnlDetalle.Visible = true;
            PanelRecargaCredito.Visible = false;
            gridCreditos.Enabled = true;
            LimpiarCamposRecargaCredito();
        }

        private void txtPeriodo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 110 || e.KeyValue == 8 || e.KeyValue == 9 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "SAUCE");
            }
        }

        private void menuModificarVenta_Click(object sender, EventArgs e)
        {
            frmModificarVentaCredito form = new frmModificarVentaCredito();
            form.ShowDialog();
        }

        private void btnPlacaVenta_Click(object sender, EventArgs e)
        {
            try
            {
                FrmVehiculoVenta oDatos = new FrmVehiculoVenta();
                oDatos.ShowDialog();

            }
            catch (Exception ex)
            {
                
                  MessageBox.Show(ex.Message, "Gasolutions SAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }

    #region "   Declaracion de Argumentos del Evento    "
    public delegate void WorkerEndHandler(object o, EventCredito e);


    public class EventCredito : EventArgs
    {
        public readonly string Documento;

        public EventCredito(string s)
        {
            Documento = s;
        }

    }

    #endregion

    class Recarga
    {
        bool _Afectacion;

        public bool Afectacion
        {
            get { return _Afectacion; }
            set { _Afectacion = value; }
        }
        decimal _Monto;

        public decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }



        decimal _SaldoAnterior;
        public decimal SaldoAnterior
        {
            get { return _SaldoAnterior; }
            set { _SaldoAnterior = value; }
        }

        decimal _SaldoDisponible;
        public decimal SaldoDisponible
        {
            get { return _SaldoDisponible; }
            set { _SaldoDisponible = value; }
        }


        string _FechaInsercion;

        public string FechaInsercion
        {
            get { return _FechaInsercion; }
            set { _FechaInsercion = value; }
        }
        string _Concepto;

        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
        long _Documento;

        public long Documento
        {
            get { return _Documento; }
            set { _Documento = value; }
        }

        string _Origen;

        public string Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }
        string _Placa;

        public string Placa
        {
            get { return _Placa; }
            set { _Placa = value; }
        }
        decimal _CupoAsignado;

        public decimal CupoAsignado
        {
            get { return _CupoAsignado; }
            set { _CupoAsignado = value; }
        }

        public Recarga(bool Afectacion, decimal Monto, string FechaInsercion, string Concepto, long Documento, string Origen, string Placa, decimal CupoAsignado)
        {
            this._Afectacion = Afectacion;
            this._Monto = Monto;
            this._FechaInsercion = FechaInsercion;
            this._Concepto = Concepto;
            this._Documento = Documento;
            this._Origen = Origen;
            this._Placa = Placa;
            this._CupoAsignado = CupoAsignado;
        }

      
    }
}
