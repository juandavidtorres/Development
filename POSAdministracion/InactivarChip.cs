using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions.UInterface
{
    public partial class InactivarChip : Form
    {
        Helper OHelper = new Helper();

        public InactivarChip()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioPlaca.Checked){
                this.grdChips.DataSource = OHelper.RecuperarIdentificadoresLocalesPorPlaca(txtPlaca.Text).Tables[0];
            }
            else if (radioRom.Checked){
                this.grdChips.DataSource = OHelper.RecuperarIdentificadorLocalPorRom(txtRom.Text).Tables[0];
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
                        String Rom, Placa;
                        Boolean Estado;

                        IdIdentificador = Int32.Parse((String)grdChips.Rows[e.RowIndex].Cells["IdIdentificadorGrilla"].Value.ToString());
                        Placa = grdChips.Rows[e.RowIndex].Cells["PlacaGrilla"].Value.ToString();
                        Rom = (String)grdChips.Rows[e.RowIndex].Cells["RomGrilla"].Value.ToString();
                        Estado = (Boolean)grdChips.Rows[e.RowIndex].Cells["EstadoGrilla"].Value;
                        OHelper.ActualizarIdentificadorLocal(IdIdentificador, Rom, Placa, Estado);

                        Popup.ContentText = "\t\t\tData Administrator\n\nEl identificador fue actualizado satisfactoriamente";
                        Popup.Popup();
                    }
                }
            }
            catch (Exception ex){
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

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            if (grdChips.IsCurrentCellInEditMode == true)
            {
                if (MessageBox.Show("La ventana actual se cerrara y los datos que se encuentran diligenciados no serán guardados. ¿Desea cerrar sin guardar datos?", "Data Administrator",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.Visible = false;
                    this.Close();
                    this.Dispose();
                }
            }
            else
            {
                this.Visible = false;
                this.Close();
                this.Dispose();
            }
        }

        private void InactivarChip_Load(object sender, EventArgs e)
        {

        }
    }
}