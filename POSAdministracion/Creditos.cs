using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using gasolutions.UInterface;

namespace gasolutions.UInterface
{
    public partial class Creditos : Form
    {
        Helper OHelper = new Helper();
        Boolean EsGridDetalleConstruido;
        Boolean EsNuevoRegistro;
        Clientes rCliente = new Clientes();
        EncabezadoCreditoConsumo eCredito = new EncabezadoCreditoConsumo();
        DataSet tbProductos = new DataSet();
        DataTable dtDetalleCredito = new DataTable();

        public Creditos()
        {
            InitializeComponent();
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            this.Dispose();
        }

        private void Creditos_Load(object sender, EventArgs e)
        {
           
           
            pnlEncabezado.Enabled = false;
            pnlDetalle.Enabled = false;
            this.txtCupo.Text = "0";
            this.pnlBusqueda.Visible = false;
            tooMensaje.SetToolTip(btnModificar, "Editar Detalle Credito");
            this.mnuGuardar.Enabled = false;


            //tbProductos.Load(OHelper.RecuperarProductos(), LoadOption.Upsert, "Productos");
            DataGridViewComboBoxColumn ComboEstado= (DataGridViewComboBoxColumn)this.dtgDetalle.Columns["Estado"];
            ComboEstado.DisplayMember = "DescripcionEstado";
            ComboEstado.ValueMember = "IdEstado";
            ComboEstado.DataSource = OHelper.RecuperarEstadosCreditos().Tables[0];

            DataGridViewComboBoxColumn ComboProducto = (DataGridViewComboBoxColumn)this.dtgDetalle.Columns["cmbProducto"];
            ComboProducto.DisplayMember = "Nombre";
            ComboProducto.ValueMember = "IdProducto";
            ComboProducto.DataSource = OHelper.RecuperarProductosDataset().Tables[0];

            
            cmbTipoCredito.ValueMember = "IdTipoCredito";
            cmbTipoCredito.DisplayMember = "Descripcion";
            cmbTipoCredito.DataSource = OHelper.RecuperarTipoCredito().Tables[0];
                        

            
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
            this.chkEstado.Checked = true;
            mnuGuardar.Enabled = true;
            mnuFind.Enabled = false;
            mnuNew.Enabled = false;
            pnlEncabezado.Enabled = true;
            pnlDetalle.Enabled = true;
            btnModificar.Enabled = false;
            EsGridDetalleConstruido = true;
            EsNuevoRegistro = true;
            EsGridDetalleConstruido = true;
            this.cmbTipoCredito.Enabled = true;
            this.chkEstado.Enabled = true;
            this.txtCupo.Enabled = true;

        }

        private void dtgDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridDetalleConstruido)
                {
                            
                    if (string.IsNullOrEmpty(dtgDetalle.Rows[e.RowIndex].Cells["IdVehiculo"].Value.ToString()))
                    {
                        // recuperar el id del vehiculo a inserta
                        dtgDetalle.Rows[e.RowIndex].Cells["IdVehiculo"].Value = +
                            OHelper.RecuperarIdVehiculo(dtgDetalle.Rows[e.RowIndex].Cells["Placa"].Value.ToString());
                        
                        dtgDetalle.Rows[e.RowIndex].Cells["IdCreditoVehiculo"].Value = 0;

                        dtgDetalle.Rows[e.RowIndex].Cells["FechaIngreso"].Value = DateTime.Now.ToString();
                        //dtgDetalle.Rows[e.RowIndex].Cells["Estado"].Value = 1;

                    }
                    else
                    {
                        //  Actualizar DataBase
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    rCliente.RecuperarCliente(this.txtCliente.Text);
                    lblCliente.Text = rCliente.Nombre.ToString();
                    eCredito.IdCliente = rCliente.IdCliente;
                }
                else
                { 
 
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCliente.Clear();
                this.txtCliente.Focus();
            }

            
        }

        private void txtCliente_KeyPress(object sender,KeyPressEventArgs e)
        {
            try
            {
                // si no es un registro nuevo y existe traigo los datos del credito.
                if  (EsNuevoRegistro == false && e.KeyChar == 13)
                {
                    DataSet dsNuevo = new DataSet();
                    dsNuevo = null;//OHelper.RecuperarEncabezadoCredito(this.txtCliente.Text);
                    if (dsNuevo.Tables[0].Rows.Count != 0)
                    {
                        dtgBusqueda.DataSource = dsNuevo.Tables[0];
                        this.pnlBusqueda.Visible = true;
                        this.toolStrip1.Enabled = false;
                        this.pnlEncabezado.Enabled = false;
                        this.pnlDetalle.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            DataTable oTable;
            Instancias oInstancias = new Instancias();
            Int16 oEstado;

            try
            {
                if (EsNuevoRegistro)
                {
//                    eCredito.IdCreditoConsumo = OHelper.InsertarEncabezadoCredito(eCredito.IdCliente, decimal.Parse(txtCupo.Text), int.Parse(cmbTipoCredito.SelectedValue.ToString()), eCredito.Estado);
                }
                else
                {
                    //OHelper.InsertarEncabezadoCredito(eCredito.IdCreditoConsumo, eCredito.IdCliente, decimal.Parse(txtCupo.Text), int.Parse(cmbTipoCredito.SelectedValue.ToString()), eCredito.Estado);
                }

                oTable = oInstancias.DameDataTableDeDataGridView(dtgDetalle);
                foreach (DataRow dRow in oTable.Rows)
                {
                    if (OHelper.InsertarDetalleCredito(eCredito.IdCreditoConsumo, Int32.Parse(dRow["IdVehiculo"].ToString()), Int16.Parse(dRow["IdProducto"].ToString()), Int16.Parse(dRow["IdEstado"].ToString()), Boolean.Parse("False"), Decimal.Parse(dRow["CupoAsignado"].ToString())) == false)
                    {
                        MessageBox.Show("Error Insertando Vehiculo" + dRow["Placa"].ToString(), "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                mnuGuardar.Enabled = false;
                mnuFind.Enabled = true;
                mnuNew.Enabled = true;
                pnlEncabezado.Enabled = false;
                pnlDetalle.Enabled = false;
                btnModificar.Enabled = false;
                EsGridDetalleConstruido = false;
                EsNuevoRegistro = false;
                //else
                //{ 

                //}
            }
            catch (Exception ex)
            {
                EsNuevoRegistro = false;
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarCampos()
        {
            dtDetalleCredito.Rows.Clear();
            this.dtgDetalle.DataSource = dtDetalleCredito;
            txtCliente.Clear();
            txtCupo.Clear();
            lblCliente.Text = "";
            rCliente.IdCliente = 0;
            rCliente.Nombre = "";
            eCredito.Cupo = 0;
            eCredito.Estado = false ;
            eCredito.FechaCreacion = DateTime.Now;
            eCredito.FechaExpira = DateTime.Now;
            eCredito.FechaUpdate = DateTime.Now;
            eCredito.IdCliente = 0;
            eCredito.IdCreditoConsumo = 0;
            eCredito.Producto = 0;
            eCredito.TipoCredito = 0;
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
            this.pnlEncabezado.Enabled = true;
            this.cmbTipoCredito.Enabled = false;
            this.chkEstado.Enabled = false;
            this.txtCupo.Enabled = false;
            this.btnModificar.Enabled = false;
            //this.btnCerrar.Enabled = true;
        }

        private void lblCerrar_Click(object sender, EventArgs e)
        {
            this.pnlBusqueda.Visible = false;
            this.toolStrip1.Enabled = true;
            this.pnlEncabezado.Enabled = false;
            this.pnlDetalle.Enabled = false;
            this.txtCliente.Clear();
        }

        private void dtgBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    eCredito.IdCreditoConsumo = Int64.Parse(dtgBusqueda.Rows[e.RowIndex].Cells["IdCreditoConsumo"].Value.ToString());
                    this.lblCliente.Text = dtgBusqueda.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    this.chkEstado.Checked = Boolean.Parse(dtgBusqueda.Rows[e.RowIndex].Cells["EstadoB"].Value.ToString());
                    txtCupo.Text = dtgBusqueda.Rows[e.RowIndex].Cells["Cupo"].Value.ToString();

                    this.pnlBusqueda.Visible = false;
                    this.toolStrip1.Enabled = true;
                    this.pnlEncabezado.Enabled = true;
                    this.cmbTipoCredito.Enabled = true;
                    this.chkEstado.Enabled = true;
                    this.txtCupo.Enabled = true;
                    this.btnModificar.Enabled = true;
                    this.mnuFind.Enabled = false;
                    this.mnuGuardar.Enabled = true;
                    dtDetalleCredito.Clear();
                    dtDetalleCredito = OHelper.RecuperarDetalleCreditoConsumo(eCredito.IdCreditoConsumo).Tables[0];
                    dtgDetalle.DataSource = dtDetalleCredito;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EsGridDetalleConstruido = true;
            this.pnlDetalle.Enabled = true;
        }

        private void mnuDeshacer_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
            this.pnlEncabezado.Enabled = false;
            this.cmbTipoCredito.Enabled = false;
            this.chkEstado.Enabled = false;
            this.txtCupo.Enabled = false;
            this.btnModificar.Enabled = false;
            this.mnuNew.Enabled = true;
            this.mnuFind.Enabled = true;
            this.mnuGuardar.Enabled = false;
            EsNuevoRegistro = false;
        }

        private void pnlEncabezado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlDetalle_Paint(object sender, PaintEventArgs e)
        {

        }

   }
}