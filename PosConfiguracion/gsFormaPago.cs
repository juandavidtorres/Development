using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using POSstation.Fabrica;

namespace PosConfiguracion
{
    public partial class gsFormaPago : UserControl
    {
        Boolean EsGridFormaConstruido;
        Helper oHelper = new Helper();
        string usuario = "";

        public gsFormaPago()
        {
            InitializeComponent();
        }

        public void CargarDatos() 
        {
            try
            {               
                this.RecuperarFormaPago();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void grdFormaPago_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (EsGridFormaConstruido)
                {
                    if (grdFormaPago.Rows[e.RowIndex].Cells["EsActivo"].Value != null && grdFormaPago.Rows[e.RowIndex].Cells["NumeroCopiasLiquidos"].Value != null && grdFormaPago.Rows[e.RowIndex].Cells["IdFormaPago"].Value != null)
                    {
                        oHelper.ActualizarFormasPago(Int32.Parse(grdFormaPago.Rows[e.RowIndex].Cells["IdFormaPago"].Value.ToString()), Int32.Parse(grdFormaPago.Rows[e.RowIndex].Cells["NumeroCopiasLiquidos"].Value.ToString()), Int32.Parse(grdFormaPago.Rows[e.RowIndex].Cells["NumeroCopiasCanastilla"].Value.ToString()), Convert.ToBoolean(grdFormaPago.Rows[e.RowIndex].Cells["EsActivo"].Value.ToString()), grdFormaPago.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString());
                        label37.Focus();
                        RecuperarFormaPago();
                    }

                }
                else
                {
                    if (grdFormaPago.ContainsFocus == false)
                    {
                        RecuperarFormaPago();
                    }
                }
            }
            catch (FormatException ) { 
            
            }
            catch (Exception ex)
            {
                RecuperarFormaPago();
                MessageBox.Show(ex.Message);
            }
        }

        private void RecuperarFormaPago()
        {
            try
            {
                DataSet data = new DataSet();
                data = oHelper.RecuperarFormasPago();
                this.grdFormaPago.DataSource = data.Tables[0];
                EsGridFormaConstruido = true;
            }
            catch
            {
                throw;
            }
        }

        private void grdFormaPago_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdFormaPago.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void pnlFormaPago_Paint(object sender, PaintEventArgs e)
        {

        }
       
    }
}
