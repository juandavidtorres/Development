using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.Fabrica;
using POSstation.AccesoDatos;

namespace PosConfiguracion
{
    public partial class gsTarjeta : UserControl
    {
        Helper oHelper = new Helper();
        string nuevoCupo;

        public gsTarjeta()
        {
            InitializeComponent();
        }

       

        private void LimpiarFormulario()
        {
            txtCliente.Text = "";
            txtTarjeta.Text = "";
            txtcupo.Text = "0";

        }


        //public void MostrarError(string mensaje, int delay, bool eserror)
        //{
        //    try
        //    {

        //        POSstation.Notificacion.Notification Control = new POSstation.Notificacion.Notification();
        //        Control.Mensaje = mensaje;
        //        Control.EsError = eserror;
        //        Control.TimerTiempo = delay;
        //        Control.Show();
        //    }
        //    catch (Exception)
        //    {


        //    }


        //}


        private void txtTarjeta_Leave(object sender, EventArgs e)
        {

            try
            {
                if (!txtTarjeta.Text.Trim().Equals(""))
                {
                    using (IDataReader dtTarjeta = oHelper.RecuperarTarjetaPorNumero(txtTarjeta.Text.Trim()))
                    {
                        if (dtTarjeta.Read())
                        {

                            this.txtCliente.Text = Convert.ToString(dtTarjeta.GetString(dtTarjeta.GetOrdinal("Cliente")));
                            //this.txtCupo.Text = Convert.ToString(dtTarjeta.GetDecimal(dtTarjeta.GetOrdinal("Cupo")));
                            this.chkTarjetaActiva.Checked = Convert.ToBoolean(dtTarjeta.GetString(dtTarjeta.GetOrdinal("Activa")));
                        }

                        dtTarjeta.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.txtCliente.Text = "";
                //this.txtCupo.Text = "0";
                this.chkTarjetaActiva.Checked = true;
            }


        }

        private void gsTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                toolTipCrear.SetToolTip(btnCrear, "Crear Tarjeta");
                //toolTipCrear.SetToolTip(btnEditar, "Editar Tarjeta");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
               
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string Activa = "";
                lblPieTarjeta.Text = "";
                lblPieCupo.Text = "";

                if (txtTarjeta.Text.Trim().Equals(""))
                    MessageBox.Show("Por favor digite el número de la tarjeta");


                if (txtcupo.Text.Trim().Equals(""))
                    MessageBox.Show("Por favor digite el número de cupo");

                Validacion.ValidarNumeroDecimal(txtcupo.Text, "El valor del cupo");

                if (chkTarjetaActiva.Checked)
                    Activa = "True";
                else
                    Activa = "False";

             
              //oHelper.ActualizarEstadoTarjetaCupo(txtTarjeta.Text, txtCliente.Text,Activa);
                oHelper.ActualizarEstadoTarjetaCupo(txtCliente.Text, txtTarjeta.Text, Activa);
    
                MessageBox.Show("Edicion Exitosa","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                btnCrear.Enabled = false;
                txtTarjeta.Enabled = false;
                txtCliente.Enabled = false;
                txtcupo.Enabled = false;
                pctBuscar.Enabled = false;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                btnCrear.Enabled = true;
                txtTarjeta.Enabled = true;
                txtCliente.Enabled = true;
                txtcupo.Enabled = true;
                pctBuscar.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       

        private void pctBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblPieTarjeta.Text = "";
                lblPieCupo.Text = "";

                gasolutions.ClienteBuscar ventana = new gasolutions.ClienteBuscar();
                ventana.Identificacion = txtCliente.Text;
                ventana.ShowDialog();

                if (ventana.IdCliente != null)
                {
                    using (IDataReader dtCliente = oHelper.RecuperarClientePorId(ventana.IdCliente.Value))
                    {
                        if (dtCliente.Read())
                        {
                            this.txtCliente.Text = dtCliente.GetString(dtCliente.GetOrdinal("Identificacion"));
                        }

                        dtCliente.Close();
                    }
                }
                ventana.Close();
                ventana.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                string Activa = "";
                string valor = "";
                lblPieTarjeta.Text = "";
                lblPieCupo.Text = "";

                if (txtTarjeta.Text.Trim().Equals(""))
                    MessageBox.Show("Por favor digite el número de la tarjeta");


                if (txtcupo.Text.Trim().Equals(""))
                    MessageBox.Show("Por favor digite el número de cupo");

               valor= txtcupo.Text.Replace("$", "");
               valor = valor.Replace(".", "");
               Validacion.ValidarNumeroDecimal(valor, "El valor del cupo");
                if (chkTarjetaActiva.Checked)
                    Activa = "True";
                else
                    Activa = "False";

                nuevoCupo = oHelper.InsertarTarjetaCupo(txtTarjeta.Text, Double.Parse(valor), txtCliente.Text, Activa);

                string texto = String.Concat("El Saldo de la tarjeta ", txtTarjeta.Text, " es: ");
                lblPieTarjeta.Text = texto;
                lblPieCupo.Text = nuevoCupo;

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pctBuscarClientesTarjetasInactivas_Click(object sender, EventArgs e)
        {
            try
            {
                lblPieTarjeta.Text = "";
                lblPieCupo.Text = "";

                gasolutions.ClienteBuscar ventana = new gasolutions.ClienteBuscar();
                ventana.Identificacion = txtClienteTInactiva.Text;
                ventana.ShowDialog();

                if (ventana.IdCliente != null)
                {
                    using (IDataReader dtCliente = oHelper.RecuperarClientePorId(ventana.IdCliente.Value))
                    {
                        if (dtCliente.Read())
                        {
                            this.txtClienteTInactiva.Text = dtCliente.GetString(dtCliente.GetOrdinal("Identificacion"));
                        }

                        dtCliente.Close();
                    }
                }
                ventana.Close();
                ventana.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                string Activa = "";
      
                if (txtTarjetaTInactiva.Text.Trim().Equals(""))
                    MessageBox.Show("Por favor digite el número de la tarjeta");


                if (chkTarjetaActivaTI.Checked)
                    Activa = "True";
                else
                    Activa = "False";

                oHelper.ActualizarEstadoTarjetaCupo(txtClienteTInactiva.Text, txtTarjetaTInactiva.Text, Activa);
                MessageBox.Show("Edicion Exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioTI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarFormularioTI()
        {
            txtClienteTInactiva.Text = "";
            txtTarjetaTInactiva.Text = "";
        }

        private void txtTarjetaTInactiva_Leave(object sender, EventArgs e)
        {

            try
            {
                if (!txtTarjetaTInactiva.Text.Trim().Equals(""))
                {
                    using (IDataReader dtTarjeta = oHelper.RecuperarTarjetaPorNumero(txtTarjetaTInactiva.Text.Trim()))
                    {
                        if (dtTarjeta.Read())
                        {

                            this.txtClienteTInactiva.Text = Convert.ToString(dtTarjeta.GetString(dtTarjeta.GetOrdinal("Cliente")));
                            //this.txtCupo.Text = Convert.ToString(dtTarjeta.GetDecimal(dtTarjeta.GetOrdinal("Cupo")));
                            this.chkTarjetaActivaTI.Checked = Convert.ToBoolean(dtTarjeta.GetString(dtTarjeta.GetOrdinal("Activa")));
                        }

                        dtTarjeta.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.txtCliente.Text = "";
                //this.txtCupo.Text = "0";
                this.chkTarjetaActivaTI.Checked = true;
            }


        }

       

        private void txtcupo_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                lbltotal.Text = txtcupo.formatText();
            }
            catch (Exception)
            {

            }
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = oHelper.RecuperarTarjetas();
                frmSearch search = new frmSearch("Tarjetas", table, "Numero");
                search.ShowDialog();
                txtNumTarjeta.Text = (string)search.Value;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);  }
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = oHelper.RecuperarVehiculosLocales();
                frmSearch search = new frmSearch("Vehiculos", table, "Placa");
                search.ShowDialog();
                txtPlacaVehiculo.Text = (string)search.Value;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                oHelper.AsociarTarjetaAVehiculo(txtNumTarjeta.Text, txtPlacaVehiculo.Text);
                MessageBox.Show(this, "Tarjeta asociada con exito [OK]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }

        }

        private void btnBuscarTarjetas_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = oHelper.RecuperarTarjetas();
                frmSearch search = new frmSearch("Tarjetas", table, "Numero");
                search.ShowDialog();
                tbTarjeta.Text = (string)search.Value;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            try
            {         
                string valor = "";

                if (tbTarjeta.Text.Trim().Equals(""))
                    throw new System.ArgumentException("Por favor digite el número de la tarjeta");


                if (oHelper.ExisteTarjeta(tbTarjeta.Text.Trim()) == false)
                    throw new System.ArgumentException("La tarjeta no existe");


                if (tbRecarga.Text.Trim().Equals("") || tbRecarga.Text.Trim().Equals("0"))
                    throw new System.ArgumentException("Por favor digite el valor de la recarga");

                valor = tbRecarga.Text.Replace("$", "");
                valor = valor.Replace(".", "");
                Validacion.ValidarNumeroDecimal(valor, "El valor de la recarga");

                int idCupo = oHelper.InsertarCupoTarjeta(tbTarjeta.Text.ToString(), Double.Parse(valor), 0);
                oHelper.InsertarCupoPrepagoDetalle(idCupo, 4, Double.Parse(valor));

                Double Saldo = oHelper.RecuperarSaldoCupo (tbTarjeta.Text.ToString());

                MessageBox.Show("Recarga Exitosa, el nuevo saldo de la tarjeta es: $" + Saldo, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbTarjeta.Text = "";
                tbRecarga.Text = "";
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
      
       
    }
} 