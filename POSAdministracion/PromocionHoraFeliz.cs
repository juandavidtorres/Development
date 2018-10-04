using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;


namespace PosStation.UInterface
{
    public partial class PromocionHoraFeliz : UserControl
    {
        private Helper OHelper = new Helper();
        public event EventHandler EventoCerrar;
        Boolean EsPorcentaje = true;
        
        public PromocionHoraFeliz()
        {
            InitializeComponent();
        }


        public void CargarPromociones()
        {
            this.IniciarForma();
        }

        public void IniciarForma()
        {
            try
            {
                RecuperarPromociones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarPromociones()
        {
            this.grdPromocionesHF.DataSource = OHelper.RecuperarPromocionesHoraFeliz().Tables[0];

        }

        private void LimpiarFormulario()
        {
            txtIdPromocion.Text = "";
            dtpFechaInicial.ResetText();
            dtpFechaFinal.ResetText();
            dtpHoraInicial.ResetText();
            dtpHoraFinal.ResetText();
            txtValor.Text = "";
            chkEsActivo.Checked = false;
            rdbPorcentaje.Checked = true;
            RecuperarPromociones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string inicial = dtpFechaInicial.Value.ToShortDateString() + " " + dtpHoraInicial.Text;
                string final = dtpFechaFinal.Value.ToShortDateString() + " " + dtpHoraFinal.Text;
                decimal Valor;

                if (rdbPorcentaje.Checked)
                {
                    EsPorcentaje = true;
                }
                else
                    if (rdbValor.Checked)
                        EsPorcentaje = false;


                if (string.IsNullOrEmpty(txtIdPromocion.Text))
                {
                    if (dtpFechaInicial.Value.Date < DateTime.Now.Date)
                    {
                        throw new Exception("\t\t\tData Administrator\n\nLa Fecha Inicial No Puede Ser Menor a la Actual.");
                    }
                
                }                
              
                if (dtpFechaInicial.Value.Date > dtpFechaFinal.Value.Date)
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nLa Fecha Final No Puede Ser Menor a la Inicial.";
                    Popup.Popup();
                }
                else
                {
                    //if (dtpHoraFinal.Value.Date.Hour < dtpHoraInicial.Value.Date.Hour)
                    //{
                    //    Popup.ContentText = "\t\t\tData Administrator\n\nLa Hora Final No Puede Ser Menor a la Inicial.";
                    //    Popup.Popup();
                    //}


                    if (Convert.ToDateTime(final) < Convert.ToDateTime(inicial))
                    {
                        Popup.ContentText = "\t\t\tData Administrator\n\nLa Hora Final No Puede Ser Menor a la Inicial.";
                        Popup.Popup();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtValor.Text))
                        {
                            if (decimal.TryParse(txtValor.Text, out Valor))
                            {
                                if (!string.IsNullOrEmpty(txtIdPromocion.Text)) //Actualizacion
                                {
                                    OHelper.GuardarPromocionHoraFeliz(Int32.Parse(txtIdPromocion.Text), dtpFechaInicial.Value.Date,dtpFechaFinal.Value.Date, Convert.ToDateTime(dtpHoraInicial.Text), Convert.ToDateTime(dtpHoraFinal.Text), Valor,EsPorcentaje, chkEsActivo.Checked);
                                    Popup.ContentText = "\t\t\tData Administrator\n\nSe Actualizó Satisfactoriamente la Promoción";
                                    Popup.Popup();
                                }
                                else //Nueva Promocion
                                {
                                    OHelper.GuardarPromocionHoraFeliz(0, dtpFechaInicial.Value, dtpFechaFinal.Value,Convert.ToDateTime(dtpHoraInicial.Text),Convert.ToDateTime(dtpHoraFinal.Text), Valor, EsPorcentaje, chkEsActivo.Checked);
                                    Popup.ContentText = "\t\t\tData Administrator\n\nSe Guardó Satisfactoriamente la Promoción";
                                    Popup.Popup();
                                }
                                LimpiarFormulario();
                                RecuperarPromociones();

                            }
                            else
                            {
                                RecuperarPromociones();
                                Popup.ContentText = "\t\t\tData Administrator\n\nEl Valor debe ser Numérico.";
                                Popup.Popup();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.grdPromocionesHF.DataSource = OHelper.BuscarPromocionesHoraFeliz(dtpFechaInicial.Value.Date, dtpFechaFinal.Value.Date).Tables[0];
            }
            catch (Exception ex)
            {
                RecuperarPromociones();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            EventoCerrar(sender, e);
        }

        private void grdPromocionesHF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIdPromocion.Text = grdPromocionesHF.Rows[e.RowIndex].Cells["IdGrilla"].Value.ToString();
                dtpFechaInicial.Value = DateTime.Parse(grdPromocionesHF.Rows[e.RowIndex].Cells["FechaInicialGrilla"].Value.ToString());
                dtpFechaFinal.Value = DateTime.Parse(grdPromocionesHF.Rows[e.RowIndex].Cells["FechaFinalGrilla"].Value.ToString());
                dtpHoraInicial.Text = grdPromocionesHF.Rows[e.RowIndex].Cells["HoraInicialGrilla"].Value.ToString();
                dtpHoraFinal.Text =grdPromocionesHF.Rows[e.RowIndex].Cells["HoraFinalGrilla"].Value.ToString();
                txtValor.Text = grdPromocionesHF.Rows[e.RowIndex].Cells["ValorGrilla"].Value.ToString();
                EsPorcentaje = Boolean.Parse(grdPromocionesHF.Rows[e.RowIndex].Cells["PorcentajeGrilla"].Value.ToString());
                if (EsPorcentaje)
                {
                    rdbPorcentaje.Checked= true;
                }
                else
                {
                    rdbValor.Checked= true;
                }
                chkEsActivo.Checked = Boolean.Parse(grdPromocionesHF.Rows[e.RowIndex].Cells["EstadoGrilla"].Value.ToString());

            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void grdPromocionesHF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Error
        }

        private void grdPromocionesHF_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                RecuperarPromociones();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void grdPromocionesHF_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {

                if (MessageBox.Show("¿Desea eliminar la Promoción #" + (e.Row.Index + 1) + "?", "Administración",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    OHelper.EliminarPromocionHoraFeliz(Int32.Parse(grdPromocionesHF.Rows[e.Row.Index].Cells["IdGrilla"].Value.ToString()));
                }
                else
                {
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {
                RecuperarPromociones();
                e.Cancel = true;
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

            
    }
}
