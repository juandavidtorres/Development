using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions.UInterface
{
    public partial class gsKilometraje : UserControl
    {
        #region "Declaracion de Variables"
        string Nombre;
        public EventHandler oClosed;
        Helper oHelper = new Helper();
        #endregion

        public gsKilometraje()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                txtRecibo.Text = "";
                txtPlaca.Text = "";
                dtFecha.Value = DateTime.Now;
                grdVentas.DataSource = null;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "IniciarControl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                String placa = null;
                Nullable<long> recibo = null;
                long reciboAProbar;
                DataSet datos;

                if (grdVentas.IsCurrentCellInEditMode)
                {
                    grdVentas.CancelEdit();
                }

                grdVentas.DataSource = null;

                if (String.IsNullOrEmpty(txtPlaca.Text))
                {
                    placa = null;
                }
                else
                {
                    placa = txtPlaca.Text;
                }

                if (String.IsNullOrEmpty(txtRecibo.Text))
                {
                    recibo = null;
                }
                else if (!long.TryParse(txtRecibo.Text, out reciboAProbar))
                {
                    MessageBox.Show("El recibo debe ser un numero entero");
                    return;
                }
                else
                {
                    recibo = long.Parse(txtRecibo.Text);
                }

                datos = oHelper.RecuperarVentasCredito(recibo, placa, dtFecha.Value);

                if (datos.Tables.Count > 0)
                {
                    if (datos.Tables[0].Rows.Count > 0)
                    {
                        grdVentas.DataSource = datos.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("La consulta no arrojó resultados");
                        grdVentas.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("La consulta no arrojó resultados");
                    grdVentas.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdVentas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (grdVentas.IsCurrentCellInEditMode)
                {
                    if (grdVentas.Columns[e.ColumnIndex].Name == "Kilometraje")
                    {
                        if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("El kilometraje no puede ser vacío");
                            e.Cancel = true;
                        }
                        else
                        {
                            int kilometraje;
                            if (!int.TryParse(e.FormattedValue.ToString(), out kilometraje))
                            {
                                MessageBox.Show("El kilometraje debe ser un numero entero");
                                e.Cancel = true;
                            }
                            else
                            {
                                if (kilometraje <= 0)
                                {
                                    MessageBox.Show("El kilometraje debe ser un número entero mayor que cero");
                                    e.Cancel = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdVentas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdVentas.IsCurrentCellInEditMode)
                {
                    if ((!String.IsNullOrEmpty((String)grdVentas.Rows[e.RowIndex].Cells["Kilometraje"].Value.ToString())) && (!String.IsNullOrEmpty((String)grdVentas.Rows[e.RowIndex].Cells["Recibo"].Value.ToString())))
                    {
                        Int32 kilometraje = Int32.Parse(grdVentas.Rows[e.RowIndex].Cells["Kilometraje"].Value.ToString());
                        long recibo = long.Parse(grdVentas.Rows[e.RowIndex].Cells["Recibo"].Value.ToString());

                        oHelper.ModificarKilometrajeVenta(recibo, kilometraje);
                        MessageBox.Show("El kilometraje ha sido actualizado satisfactoriamente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
