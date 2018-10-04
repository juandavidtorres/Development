using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Controles;
using POSstation.AccesoDatos;
using POSstation.Fabrica;

namespace gasolutions
{
    public partial class gsPrepago : UserControl
    {

        #region "   Declaracion de Variables    "
            Helper oHelper = new Helper();
            string oTexto;
            string Nuip;
            string NoDocumento;
        #endregion

        #region "       Propiedades del Control     "
        
            public string Documento
            {
                set 
                {
                    Nuip = value;
                }
            }

        #endregion

        public gsPrepago()
        {
            InitializeComponent();
        }

        //void CerrarAyuda() {
        //    try
        //    {
              
        //        this.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public void IniciarForma()
        {
            try
            {
                txtDocumento.Clear();
                txtMonto.Clear();
                txtComentario.Clear();
                txtNuevoCupoVehiculo.Clear();
                txtPlaca.Clear();
                cmbAfectacion.SelectedItem = 0;
                dtpFecha.Value = DateTime.Now;
                lblCredito.Text ="";
                lblEmpresa.Text = "";
                lblCupo.Text = "";
                lblSaldo.Text = "";
                lblEstado.Text = "";
                lblTipoCredito.Text = "";
                lblFechaCreado.Text = "";


                Controles.frmAyuda oAyuda = new frmAyuda();
               // oAyuda.Cerrar += CerrarAyuda;
                oAyuda.Informacion = oHelper.RecuperarPrepago(Nuip);
                oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
                oAyuda.ColumnReturn = 1;
                oAyuda.ShowDialog();
                if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado) == false)
                {
                    lblCredito.Text = oAyuda.RowSelect.Cells[0].Value.ToString();
                    lblEmpresa.Text = oAyuda.RowSelect.Cells[2].Value.ToString();
                    lblCupo.Text = oAyuda.RowSelect.Cells[3].Value.ToString();
                    lblSaldo.Text = oAyuda.RowSelect.Cells[4].Value.ToString();
                    lblEstado.Text = oAyuda.RowSelect.Cells[8].Value.ToString();
                    lblTipoCredito.Text = oAyuda.RowSelect.Cells[6].Value.ToString();
                    lblFechaCreado.Text = oAyuda.RowSelect.Cells[7].Value.ToString();
                }
                oAyuda.Close();
                oAyuda.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

      

        //private void mnuFind_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        string oReturn = Controles.Inputbox.Show("Prepagos", "Digite el numero de documento del cliente", FormStartPosition.CenterParent);
        //        //txtInformacion.Clear();
        //        lstInformacion.Items.Clear();

        //        if (oReturn == "" || oReturn == "*" || oReturn == null)
        //        {
        //            oReturn = "*";
        //        }
        //           oAyuda.Informacion = oHelper.RecuperarPrepago(oReturn);
        //           oAyuda.UbicacionFormulario = FormStartPosition.CenterParent;
        //           oAyuda.ColumnReturn = 1;
        //           oAyuda.ShowDialog();
        //           if (string.IsNullOrEmpty(oAyuda.ValorRegistroSeleccionado) == false)
        //           {
        //               //for(int oCell = 0; oCell <= int.Parse((oAyuda.RowSelect.Cells.Count - 1).ToString()); oCell ++)
        //               //{
        //               //    lstInformacion.Items.Add (oAyuda.RowSelect.Cells[oCell].Value.ToString());
        //               //}
        //               ////txtInformacion.Text = oTexto;
        //               lblCredito.Text = oAyuda.RowSelect.Cells[0].Value.ToString();
        //               lblEmpresa.Text = oAyuda.RowSelect.Cells[2].Value.ToString();
        //               lblCupo.Text = oAyuda.RowSelect.Cells[3].Value.ToString();
        //               lblSaldo.Text = oAyuda.RowSelect.Cells[4].Value.ToString();
        //               lblEstado.Text = oAyuda.RowSelect.Cells[8].Value.ToString();
        //               lblTipoCredito.Text = oAyuda.RowSelect.Cells[6].Value.ToString();
        //               lblFechaCreado.Text = oAyuda.RowSelect.Cells[7].Value.ToString();

        //           }

        //           oAyuda.Dispose();
                
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        public event EventHandler oClosed;
        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean oAfectacion;
                string Origen;
                Int32 oResultado;
                Decimal CupoAsignado = 0;
                if (txtMonto.TextLength < 1 || txtMonto.Text == "0")
                    throw new Exception("Debe Ingresar un valor valido para la Cantidad($)");

                if(cmbAfectacion.Text != "")
                {

                    if (cmbAfectacion.Text  == "Recargar")
                    {
                        oAfectacion = true;
                        Origen = "Recarga Prepago";
                        NoDocumento = "0";
                        oResultado = Int32.Parse(lblSaldo.Text.ToString()) + Int32.Parse(txtMonto.Text);
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(txtDocumento.Text.Trim()))
                            throw new Exception("Debe Ingresar un No. Documento valido");

                        oAfectacion = false;
                        Origen = "Descarga Prepago";
                        NoDocumento = txtDocumento.Text;
                        if (Int32.Parse(txtMonto.Text) < Int32.Parse(lblSaldo.Text.ToString()))
                        {
                            oResultado = Int32.Parse(lblSaldo.Text.ToString()) - Int32.Parse(txtMonto.Text);
                        }
                        else
                        {
                            throw new Exception("La cantidad ingresda es mayor que el valor del saldo asignado, Por favor verifique");
                        }
                    }

                    if (!String.IsNullOrEmpty(txtNuevoCupoVehiculo.Text))
                    {
                     Validacion.ValidarNumeroDecimal(txtNuevoCupoVehiculo.Text, "El Cupo");
                        CupoAsignado = Decimal.Parse(txtNuevoCupoVehiculo.Text);
                    }

                    if (oHelper.InsertarPrepago(oAfectacion, Decimal.Parse(txtMonto.Text), dtpFecha.Value.ToString("yyyyMMdd"), txtComentario.Text, Int64.Parse(NoDocumento), Int64.Parse(lblCredito.Text.ToString()), Origen, txtPlaca.Text, CupoAsignado) == true)
                    {
                        txtDocumento.Clear();
                        txtMonto.Clear();
                        txtComentario.Clear();
                        txtNuevoCupoVehiculo.Clear();
                        txtPlaca.Clear();
                        lblSaldo.Text = oResultado.ToString();
                        MessageBox.Show("Proceso Generado Satisfactoriamente.", "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Prepagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(e.KeyValue == 8 || e.KeyValue == 46 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105))
                {
                    e.SuppressKeyPress = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
