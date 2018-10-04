using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;
using gasolutions.UInterface;


namespace PosStation.gsDevoluciones
{
    public partial class gsDevolucion : ItemMenu
    {
        
        public event EventHandler EventoCerrar;
        decimal Valor;
        Helper odatos = new Helper();
        public gsDevolucion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Validaciones();
                long recibo = Convert.ToInt64(txtRecibo.Text.Trim());


                if (odatos.ExisteCara(Convert.ToInt16(txtCara.Text.Trim())))
                {               
                

                        odatos.InsertarCambioCheque(Convert.ToInt64(txtAutorizacion.Text.Trim()), Valor, odatos.RecuperarIdturnoPorRecibo(Convert.ToInt32(recibo)), recibo, Convert.ToInt16(txtCara.Text.Trim()));
                        MessageBox.Show("Operacion exitosa");
                        ServicioSauce.ImpresoraRecibo.ImprimirCambioCheque(Convert.ToInt16(txtCara.Text.Trim()), odatos.RecuperarIdturnoPorRecibo(Convert.ToInt32(recibo)), Convert.ToInt32(recibo), Convert.ToInt32(txtAutorizacion.Text), Convert.ToDecimal(Valor), new ServicioSauce.ImpresoraEstacion(recibo));



                        string NumeroAutorizacionTmp = txtAutorizacion.Text;
                        string Recibo = recibo.ToString();
                        byte Cara = Convert.ToByte(txtCara.Text);
                        double ValorTmp = Convert.ToDouble(txtvalor.Text);
                        int turno = odatos.RecuperarIdturnoPorRecibo(Convert.ToInt32(Recibo));
                        string Puerto = string.Empty;
                        //oEventos.SolicitarEnviarCambioCheque(ref NumeroAutorizacionTmp, ref turno, ref Cara, ref Recibo, ref ValorTmp, ref ValorTmp, ref Puerto);
                        Limpiar();
                }else
                    MessageBox.Show("La cara no existe");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Validaciones()
        {
           


            if (string.IsNullOrEmpty(txtRecibo.Text.Trim()))
                throw new Exception("El Numero es obligatorio");


            if (string.IsNullOrEmpty(txtAutorizacion.Text.Trim()))
                throw new Exception("La Autorizacion es obligatoria");

            if (string.IsNullOrEmpty(txtCara.Text.Trim()))
                throw new Exception("La cara es obligatoria");

            if (string.IsNullOrEmpty(txtvalor.Text.Trim()))
                throw new Exception("El valor es obligatoria");

            if (!decimal.TryParse(txtvalor.Text.Trim(), out Valor))
                throw new Exception("El valor debe ser numerico");

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (string.IsNullOrEmpty(txtRecibo.Text.Trim()))
                    throw new Exception("El recibo es obligatorio");

                txtCara.Enabled = true;
                txtRecibo.Enabled = true;
            
                txtAutorizacion.Enabled = true;
                txtvalor.Enabled = true;

                int recibo = Convert.ToInt32(txtRecibo.Text.Trim());
                dgvDevoluciones.DataSource = odatos.RecuperarDatosdeVentaPorRecibo(Convert.ToInt32(recibo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Limpiar() 
        {
             txtAutorizacion.Clear();
            txtCara.Clear();
            txtRecibo.Clear();
            txtvalor.Clear();
            dgvDevoluciones.DataSource = "";
        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
              this.RiseEvent_OnClosed(sender, e);                 
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //private void gsDevoluciones_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ////Instancia los eventos disparados por la aplicacion cliente
        //        //Type t = Type.GetTypeFromProgID("SharedEventsFuelStation.CMensaje");
        //        //oEventos = (SharedEventsFuelStation.CMensaje)Activator.CreateInstance(t);

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void txtCara_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
