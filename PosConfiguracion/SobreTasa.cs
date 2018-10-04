using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
 

namespace PosConfiguracion
{
    public partial class SobreTasa : UserControl
    {
        Helper ODataAccess = new Helper();
        string FInicial;
        string FFinal;
        string SobretasaTemp;

        public SobreTasa()
        {
            InitializeComponent();
        }

        public void IniciarForma(){

            CargarDatosSobretasa();
        }

        private void CargarDatosSobretasa() 
        {
            try
            {
                
                DataGridViewComboBoxColumn ComboDispositivo = (DataGridViewComboBoxColumn)this.dtgSobreTasa.Columns["Producto"];
                
                ComboDispositivo.DisplayMember = "Nombre";
                ComboDispositivo.ValueMember = "Codigo";
                ComboDispositivo.DataSource = ODataAccess.RecuperarProductosCombustible();   
                


            }
            catch (Exception ex)
            {  
                MessageBox.Show(ex.Message);                      
            }
            
        
        }

        private void SobreTasa_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosSobretasa();
                dtgSobreTasa.DataSource = ODataAccess.RecuperarHistoricoSobreTasa();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        /// <summary>
        /// Si es 1 se esta validando valor sobretasa, si es 2 la fecha inicial y si la fecha final
        /// </summary>

        private Boolean ValidarDatosSobreTasa(String valor, String FInicialValue, String FFinalValue, int TipoValidacion)
        {
            Boolean respuesta = false;
            DateTime inicio, fin;
            try
            {
                switch (TipoValidacion)
                {
                    case(1):
                        Decimal temporal;
                        if (Decimal.TryParse(valor,out temporal))
                        {
                            if (temporal <= 0)
                                //throw new Exception("La sobretasa debe se mayor que 0");
                                respuesta = false;
                            else
                                respuesta = true;
                            
                        }else
                            //throw new Exception("La sobretasa debe ser un valor numerico");
                            respuesta = false;
                        break;
                    case(2):

                        if (DateTime.TryParse(FInicialValue, out inicio))
                        {
                            respuesta = true;
                            
                        }
                        else
                            //throw new Exception("La fecha inicial no tiene el formato correcto");
                            respuesta = false;

                        break;
                    case (3):
                        if (DateTime.TryParse(FFinalValue, out fin))
                        {                           
                                respuesta = true;
                        }else
                            respuesta = false;
                        break;
                    case (4):
                        inicio = DateTime.Parse(FInicialValue);
                        fin = DateTime.Parse(FFinalValue);

                        if (inicio > fin)
                            //throw new Exception("La fecha inicial no puede ser mayor que la final");
                            respuesta = false;
                        else
                            respuesta = true;
                        break;
                    default:
                        respuesta = false;
                        break;
                }
                return respuesta;

            }
            catch
            {
                
                throw;
            }
        
        }

        private void dtgSobreTasa_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{

            //    if (dtgSobreTasa.IsCurrentCellInEditMode)
            //    {
            //        //if ((dtgSobreTasa.Rows[e.RowIndex].Cells["FechaInicial"].Value != null) && (dtgSobreTasa.Rows[e.RowIndex].Cells["FechaFinal"].Value != null) && ((dtgSobreTasa.Rows[e.RowIndex].Cells["SobreTasa"].Value != null)))
            //        //{
            //        if ((dtgSobreTasa.Rows[e.RowIndex].Cells["FechaInicial"].Value != null))
            //        {
            //            FInicial = dtgSobreTasa.Rows[e.RowIndex].Cells["FechaInicial"].Value.ToString();

            //        }
            //        else
            //            FInicial = string.Empty;

            //        if ((dtgSobreTasa.Rows[e.RowIndex].Cells["FechaFinal"].Value != null))
            //        {
            //            FFinal = dtgSobreTasa.Rows[e.RowIndex].Cells["FechaFinal"].Value.ToString();

            //        }
            //        else
            //            FFinal = string.Empty;


            //        if ((dtgSobreTasa.Rows[e.RowIndex].Cells["ColSobreTasa"].Value != null))
            //        {
            //            SobretasaTemp = dtgSobreTasa.Rows[e.RowIndex].Cells["ColSobreTasa"].Value.ToString();

            //        }
            //        else
            //            SobretasaTemp = string.Empty;

            //        //}
            //        if (dtgSobreTasa.Columns[e.ColumnIndex].Name == "ColSobreTasa")
            //        {
            //            ValidarDatosSobreTasa(SobretasaTemp, FInicial, FFinal, 1);

            //        }
            //        else {
            //            MessageBox.Show("Revise el valor de la sobretasa", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
                        

                    

            //        if (dtgSobreTasa.Columns[e.ColumnIndex].Name == "FechaInicial")
            //            ValidarDatosSobreTasa(SobretasaTemp, FInicial, FFinal, 2);
            //        else
            //        {
            //            MessageBox.Show("Revise el formato de la fecha inicial", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }





            //        if (dtgSobreTasa.Columns[e.ColumnIndex].Name == "FechaFinal")
            //            ValidarDatosSobreTasa(SobretasaTemp, FInicial, FFinal, 3) ;
                        
            //        else
            //        {
            //            MessageBox.Show("Revise el formato de la fecha Final", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }

                 
            //    }

            //}
            //catch (Exception ex)
            //{
               
            //    MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

        }

       

      
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void dtgSobreTasa_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {

                if (dtgSobreTasa.IsCurrentCellInEditMode)
                {
                     if ((dtgSobreTasa.Rows[e.RowIndex].Cells["FechaInicial"].Value != null))
                    {
                        FInicial = dtgSobreTasa.Rows[e.RowIndex].Cells["FechaInicial"].Value.ToString();

                    }
                    else
                        FInicial = string.Empty;

                    if ((dtgSobreTasa.Rows[e.RowIndex].Cells["FechaFinal"].Value != null))
                    {
                        FFinal = dtgSobreTasa.Rows[e.RowIndex].Cells["FechaFinal"].Value.ToString();

                    }
                    else
                        FFinal = string.Empty;


                    if ((dtgSobreTasa.Rows[e.RowIndex].Cells["ColSobreTasa"].Value != null))
                    {
                        SobretasaTemp = dtgSobreTasa.Rows[e.RowIndex].Cells["ColSobreTasa"].Value.ToString();

                    }
                    else
                        SobretasaTemp = string.Empty;

                    //}
                    if (dtgSobreTasa.Columns[e.ColumnIndex].Name == "ColSobreTasa")
                    {
                        SobretasaTemp = e.FormattedValue.ToString();
                       if( ValidarDatosSobreTasa(SobretasaTemp, FInicial, FFinal, 1))
                           e.Cancel = false;
                       else
                       {
                           MessageBox.Show("Revise el valor de la sobretasa", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           e.Cancel = true;
                       }
                        
                    }
                    




                    if (dtgSobreTasa.Columns[e.ColumnIndex].Name == "FechaInicial")
                    {
                        FInicial = e.FormattedValue.ToString();
                        if (ValidarDatosSobreTasa(SobretasaTemp, FInicial, FFinal, 2))
                            e.Cancel = false;
                        else
                        {
                            MessageBox.Show("Revise el formato de la fecha inicial", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }


                    }



                    if (dtgSobreTasa.Columns[e.ColumnIndex].Name == "FechaFinal"){
                        FFinal = e.FormattedValue.ToString();
                        if (ValidarDatosSobreTasa(SobretasaTemp, FInicial, FFinal, 3)) 
                        e.Cancel = false;

                        else
                        {
                            MessageBox.Show("Revise el formato de la fecha Final", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            int IdHistorico;
            bool sw = false;
            bool estado = false;
            try
            {
                foreach (DataGridViewRow fila in this.dtgSobreTasa.Rows)
                {
                    if (((fila.Cells["Producto"].Value != null)) && ((fila.Cells["ColSobreTasa"].Value != null)) && ((fila.Cells["FechaInicial"].Value != null)) && ((fila.Cells["FechaFinal"].Value != null)))
                    {
                        if (((fila.Cells["ColSobreTasa"].Value != null)) && ((fila.Cells["FechaInicial"].Value != null)) && ((fila.Cells["FechaFinal"].Value != null)))
                        {
                            if ((!String.IsNullOrEmpty(fila.Cells["ColSobreTasa"].Value.ToString())) && (!String.IsNullOrEmpty(fila.Cells["FechaInicial"].Value.ToString())) && (!String.IsNullOrEmpty(fila.Cells["FechaFinal"].Value.ToString())))
                            {

                                if (Int32.TryParse(fila.Cells["IdHistorico"].Value.ToString(), out IdHistorico))
                                {
                                    ODataAccess.SincronizarSobreTasaCombustible(Convert.ToInt32(fila.Cells["IdHistorico"].Value.ToString()), Convert.ToInt32(fila.Cells["Producto"].Value.ToString()), Convert.ToDecimal(fila.Cells["ColSobreTasa"].Value.ToString()), Convert.ToDateTime(fila.Cells["FechaInicial"].Value.ToString()), Convert.ToDateTime(fila.Cells["FechaFinal"].Value.ToString()), Convert.ToBoolean(fila.Cells["Activa"].Value.ToString()));
                                    sw = true;

                                }
                                else
                                {
                                    if (String.IsNullOrEmpty(fila.Cells["Activa"].Value.ToString()))
                                    {
                                        estado = false;
                                    }
                                    else
                                        estado = true;


                                    ODataAccess.SincronizarSobreTasaCombustible(0, Convert.ToInt32(fila.Cells["Producto"].Value.ToString()), Convert.ToDecimal(fila.Cells["ColSobreTasa"].Value.ToString()), Convert.ToDateTime(fila.Cells["FechaInicial"].Value.ToString()), Convert.ToDateTime(fila.Cells["FechaFinal"].Value.ToString()),estado);
                                    sw = true;
                                }
                            }

                        }

                    }


                }

                if (sw == true)
                {
                    MessageBox.Show("Registros almacenados con exito", "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        CargarDatosSobretasa();
                        dtgSobreTasa.DataSource = ODataAccess.RecuperarHistoricoSobreTasa();


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Gasolutions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dtgSobreTasa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool sw;
            try
            {
                if (e.RowIndex != -1)
                {
                    if (Boolean.TryParse(dtgSobreTasa.Rows[e.RowIndex].Cells["Activa"].Value.ToString(),out sw))
                    {

                        if (Convert.ToBoolean(dtgSobreTasa.Rows[e.RowIndex].Cells["Activa"].Value) == true)
                        {
                            dtgSobreTasa.Rows[e.RowIndex].Cells["Activa"].Value = false;
                        }
                        else
                        {
                            dtgSobreTasa.Rows[e.RowIndex].Cells["Activa"].Value = true;
                        }
                        
                    }

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
