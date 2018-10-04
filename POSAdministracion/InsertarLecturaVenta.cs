using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;

namespace gasolutions.UInterface
{
    public partial class InsertarLecturaVenta : UserControl
    {
        #region Declaracion de Variables y propiedades

        public EventHandler oClosed;
        Helper ODatos = new Helper();
        private int _Turno;
        private decimal _Cantidad;
        private int _Manguera;
        private int _Producto;
        private int _IdBloqueo;
        private decimal _Precio;
        private decimal _LInicial;
        private decimal _LFinal;
        private decimal CantidaGalonesTemporal;
        private decimal ValorTotal;
        public string Recibo { get; set; }
        public int Turno
        {
            get
            {

                return _Turno;
            }

            set
            {
                _Turno = value;
            }
        }
        public decimal Cantidad
        {
            get
            {

                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }
        public decimal LecturaInicial
        {
            get
            {

                return _LInicial;
            }

            set
            {
                _LInicial = value;
            }
        }
        public decimal LecturaFinal
        {
            get
            {

                return _LFinal;
            }

            set
            {
                _LFinal = value;
            }
        }
        decimal sumValorTotalEfectivo = 0;
        public int Manguera
        {
            get
            {

                return _Manguera;
            }

            set
            {
                _Manguera = value;
            }
        }
        public int IdBloqueo
        {
            get
            {

                return _IdBloqueo;
            }

            set
            {
                _IdBloqueo = value;
            }
        }
        public int Producto
        {
            get
            {

                return _Producto;
            }

            set
            {
                _Producto = value;
            }
        }
        public decimal Precio
        {
            get
            {

                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        #endregion


        public InsertarLecturaVenta()
        {
            InitializeComponent();
            this.tooltipBotones.SetToolTip(btnAgregar, "Agregar valor por medio de pago");
            this.tooltipBotones.SetToolTip(btnlimpiar, "Limpiar Cuadricula");
            this.tooltipBotones.SetToolTip(btnFalla, "Omitir por Falla Tecnica");
            this.tooltipBotones.SetToolTip(btnGuardar, "Generar Venta");
        }


        public void CargarDatos()
        {
            try
            {
                txtCantidad.Text = this._Cantidad.ToString();
                txtturno.Text = this._Turno.ToString();
                txtPrecio.Text = this._Precio.ToString();
                txtManguera.Text = this._Manguera.ToString();
                txtProducto.Text = this._Producto.ToString();
                txtLecturaFinal.Text = this._LFinal.ToString();
                txtLecturaInicial.Text = this._LInicial.ToString();
                ValorTotal = Cantidad * Precio;
                txtValorTotal.Text = ValorTotal.ToString();
                sumValorTotalEfectivo = 0;


                txtProducto.Enabled = false;
                txtValorTotal.Enabled = false;
                txtCantidad.Enabled = false;
                txtturno.Enabled = false;
                txtPrecio.Enabled = false;
                txtManguera.Enabled = false;
                txtPlaca.Enabled = false;
                txtLecturaFinal.Enabled = false;
                txtLecturaInicial.Enabled = false;

                pnlIngresoVenta.Enabled = false;

                cmbFormaPago.DataSource = ODatos.RecuperarMediosPagosVentasFueradeSistemas();
                cmbFormaPago.DisplayMember = "Descripcion";
                cmbFormaPago.ValueMember = "IdFormaPago";
                cmbFormaPago.SelectedIndex = 1;





            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }



        }

        private void btnGenerarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                pnlIngresoVenta.Enabled = true;
                txtPlaca.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkEsCredito_CheckedChanged(object sender, EventArgs e)
        {
            //    try
            //    {
            //        if (chkEsCredito.Checked == true)
            //        {
            //            EsCredito = true;
            //            txtPlaca.Enabled = true;
            //            btnAgregar.Enabled = false;
            //            cmbFormaPago.Enabled = false;
            //            txtValorFormaPago.Enabled = false;
            //        }
            //        else
            //        {
            //            EsCredito = false;
            //            txtPlaca.Enabled = false;
            //            btnAgregar.Enabled = true;
            //            txtValorFormaPago.Enabled = true;
            //        }

            //    }
            //    catch (System.Exception ex)
            //    {

            //    }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                grdTurnos.Rows.Clear();
                sumValorTotalEfectivo = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            decimal temp;

            try
            {


                if (decimal.TryParse(txtValorFormaPago.Text, out temp))
                {
                    temp = Convert.ToDecimal(Utilidades.ModificarFormatoDecimal(txtValorFormaPago.Text));

                    if (temp > 0)
                    {
                        if (temp <= ValorTotal)
                        {

                            if ((sumValorTotalEfectivo + temp) <= ValorTotal)
                            {
                                decimal gal;
                                if (!string.IsNullOrEmpty(txtCantidad.Text.Trim()))
                                {
                                    if (Decimal.TryParse(txtCantidad.Text.Trim(), out gal))
                                    {
                                        if (gal <= Cantidad)
                                        {
                                            txtValorFormaPago.Clear();
                                            grdTurnos.Rows.Add(IdBloqueo.ToString(), Turno.ToString(), Manguera.ToString(), Producto.ToString(), cmbFormaPago.SelectedValue.ToString(), Precio.ToString(), txtCantidad.Text.Trim(), temp.ToString());
                                            sumValorTotalEfectivo += temp;
                                          
                                        }
                                        else
                                            MessageBox.Show("La Catidad de Galones supera la cantidad total", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    }
                                    else
                                        MessageBox.Show("La Catidad de Galones es numerica", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                    MessageBox.Show("La Catidad de Galones es obligatoria", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }
                            else
                                MessageBox.Show("El valor supera al total de la venta", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                            MessageBox.Show("El valor supera al total de la venta", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                        MessageBox.Show("El valor debe ser mayor que cero", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                    MessageBox.Show("El valor debe ser numerico", "Agregar Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }

            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            int FormadePago = 0;
            decimal valorMedioPago = 0;
            string placa = "";
            bool band = false;
            string Kilometraje = "0";
            CantidaGalonesTemporal = 0;
            Dictionary<int, decimal> oFormasPago = new Dictionary<int, decimal>();

            try
            {

                foreach (DataGridViewRow Fila in grdTurnos.Rows)
                {
                    FormadePago = Convert.ToInt16(Fila.Cells["dgvFormaPago"].Value.ToString());
                    valorMedioPago = Convert.ToDecimal(Fila.Cells["dgvValor"].Value.ToString());
                    CantidaGalonesTemporal += Convert.ToDecimal(Fila.Cells["dgvCantidad"].Value.ToString());
                    band = true;

                    if (FormadePago != 25)
                    {
                        if (oFormasPago.ContainsKey(FormadePago))
                        {
                            valorMedioPago += oFormasPago[FormadePago];
                            oFormasPago[FormadePago] = valorMedioPago;
                        }
                        else
                        {
                            oFormasPago.Add(FormadePago, valorMedioPago);
                        }

                    }           

                }

                if (!band)
                {
                    if (MessageBox.Show("Desea Guardar el total de la venta en efectivo ?", "Confirmación", System.Windows.Forms.MessageBoxButtons.YesNo,
System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (sumValorTotalEfectivo < ValorTotal)
                        {
                            FormadePago = 4;
                            valorMedioPago = Convert.ToDecimal(ValorTotal - sumValorTotalEfectivo);
                            oFormasPago.Add(FormadePago, valorMedioPago);
                            txtCantidad.Text = Cantidad.ToString();
                            txtCantidad.Text = Cantidad.ToString();
                            CantidaGalonesTemporal = Convert.ToDecimal(txtCantidad.Text);

                        }

                    }

                }



                decimal canttemp;
                if (decimal.TryParse(CantidaGalonesTemporal.ToString(), out canttemp))
                {
                   
                        string venta = "Se genero el recibo # ";
                        Recibo = ODatos.InsertarVentaGTRecuperadaFullStation(Convert.ToInt16(Manguera), canttemp, oFormasPago, placa, Kilometraje, Guid.NewGuid().ToString(), Turno, IdBloqueo.ToString()).ToString();
                        venta = venta + Recibo;
                        lblrecibo.Text = venta;
                        ODatos.HabilitarMangueraConVentasFueraDelSistemaFullStation(Manguera, IdBloqueo, false);
                        MessageBox.Show("Registro exitoso", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cantidad = Cantidad - canttemp;
                        txtCantidad.Text = Cantidad.ToString();
                        txtValorTotal.Text = (Cantidad * Precio).ToString();
                        ValorTotal = (Cantidad * Precio);
                        sumValorTotalEfectivo = 0;
                        Limpiar();                       
                   

                }






            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


           
        }


        private void Limpiar()
        {
            
            grdTurnos.Rows.Clear();
            txtPlaca.Clear();
            txtValorFormaPago.Clear();
        }

        private void btnFalla_Click(object sender, EventArgs e)
        {
            try
            {
                ODatos.HabilitarMangueraConVentasFueraDelSistemaFullStation(Manguera, IdBloqueo, true);
                btnimprimir.Enabled = false;
                btnGuardar.Enabled = false;
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                oClosed(sender, e);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            try
            {
               
                PrintDialog pd = new PrintDialog();
                pd.ShowDialog();
                var settings = pd.PrinterSettings;
                string name = settings.PrinterName;
                if (!string.IsNullOrEmpty(name))
                {
                    ServicioSauce.ImpresoraEstacion imp = new ServicioSauce.ImpresoraEstacion();
                    imp.Nombre = name;
                    ServicioSauce.ImpresoraRecibo.ImprimirRecibo(double.Parse(Recibo), imp, true);     
                }else
                    MessageBox.Show("Seleccione una impresora", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



    }
}
