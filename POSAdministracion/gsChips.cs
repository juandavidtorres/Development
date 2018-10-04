using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;


namespace PosStation.gsChips
{
    public partial class gsChip : UserControl
    {
        #region "   Declaracion de Variables" 

        Helper OHelper = new Helper();

        #endregion

        public gsChip()
        {
            InitializeComponent();
        }

        public void IniciarControl()
        {
            try
            {
                CargarTiposIdentificadoresVehiculo();
                LimpiarControl();
                object sender = new object();
                EventArgs e = new EventArgs();
                radioPlaca_CheckedChanged(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void LimpiarControl()
        {
            try
            {
                txtPlaca.Text = "";
                txtIdentificador.Text = "";
                radioPlaca.Checked = true;
                this.grdChips.DataSource = OHelper.RecuperarIdentificadoresLocalesPorPlaca("").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarTiposIdentificadoresVehiculo()
        {
            try
            {
                cmbTipoIdentificador.DisplayMember = "Nombre";
                cmbTipoIdentificador.ValueMember = "IdTipoIdentificacion";
                cmbTipoIdentificador.DataSource = OHelper.RecuperarTiposIdentificacion().Tables[0];
            }
            catch
            {
                Popup.ContentText = "\t\t\tData Administrator\n\nNo se pudieron cargar los tipos de identificacion de vehiculo";
                Popup.Popup();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable resultado;
            if (radioPlaca.Checked)
            {
                resultado = OHelper.RecuperarIdentificadoresLocalesPorPlaca(txtPlaca.Text).Tables[0];
                this.grdChips.DataSource = resultado;

                if (resultado.Rows.Count == 0)
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nNo se encontraron registros para la busqueda";
                    Popup.Popup();
                }
            }
            else if (radioRom.Checked)
            {
                resultado = OHelper.RecuperarIdentificadorLocalPorId(txtIdentificador.Text, Int32.Parse(cmbTipoIdentificador.SelectedValue.ToString())).Tables[0];
                this.grdChips.DataSource = resultado;

                if (resultado.Rows.Count == 0)
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nNo se encontraron registros para la busqueda";
                    Popup.Popup();
                }
            }
        }

        private void grdChips_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdChips.IsCurrentCellInEditMode)
                {
                    if (!String.IsNullOrEmpty((String)grdChips.Rows[e.RowIndex].Cells["PlacaGrilla"].Value.ToString()))
                    {
                        Int32 IdIdentificador;
                        String Identificador, Placa;
                        Boolean EsActivo;

                        IdIdentificador = Int32.Parse((String)grdChips.Rows[e.RowIndex].Cells["IdIdentificadorGrilla"].Value.ToString());
                        Placa = grdChips.Rows[e.RowIndex].Cells["PlacaGrilla"].Value.ToString();
                        Identificador = (String)grdChips.Rows[e.RowIndex].Cells["IdentificadorGrilla"].Value.ToString();
                        EsActivo = (Boolean)grdChips.Rows[e.RowIndex].Cells["EstadoGrilla"].Value;
                        OHelper.ActualizarIdentificadorLocal(IdIdentificador, Identificador, Placa, EsActivo);

                        Popup.ContentText = "\t\t\tData Administrator\n\nEl identificador fue actualizado satisfactoriamente";
                        Popup.Popup();
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\n" + ex.Message;
                Popup.Popup();
            }
        }

        private void grdChips_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (grdChips.IsCurrentCellInEditMode)
                {
                    if (grdChips.Columns[e.ColumnIndex].Name == "PlacaGrilla")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            Popup.ContentText = "\t\t\tData Administrator\n\nLa placa no puede ser vacía";
                            Popup.Popup();
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = "\t\t\tData Administrator\n\n" + ex.Message;
                Popup.Popup();
            }
        }

        public event EventHandler oClosed;

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            if (grdChips.IsCurrentCellInEditMode == true)
            {
                if (MessageBox.Show("La ventana actual se cerrara y los datos que se encuentran diligenciados no serán guardados. ¿Desea cerrar sin guardar datos?", "Data Administrator",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.Visible = false;
                    oClosed(sender, e);
                }
            }
            else
            {
                this.Visible = false;
                oClosed(sender ,e);
            }
            
        }

        private void mnuLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControl();
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void radioPlaca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioPlaca.Checked)
                {
                    txtPlaca.Enabled = true;
                    txtPlaca.Focus();
                    txtIdentificador.Enabled = false;
                }
                else
                {
                    txtPlaca.Enabled = false;
                    txtIdentificador.Enabled = true;
                    txtIdentificador.Focus();
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

    }
}
