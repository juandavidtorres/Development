using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;
using Controles;
using gasolutions.UInterface;

namespace PosStation.gsPagoFacturas
{
    public partial class gsPagoFacturas : UserControl
    {

        #region "   Declaracion de Variables    "

            public DataTable dtDatos = new DataTable();
            public Boolean EsRecibida;
            Helper oHelper = new Helper();
            Decimal ValorCancelar;
            string Documento;

        #endregion

        public gsPagoFacturas()
        {
            InitializeComponent();
        }

        public void IniciarControl()
        {
            if (dtDatos.Rows.Count >= 0 && EsRecibida == true)
            {
                dtgResultados.DataSource = dtDatos;
                this.tlbGuardar.Enabled = false;
                EsFacturable.Visible = false;
            }
            else
            {
                dtgResultados.DataSource = oHelper.RecuperarFacturasCreditoConsumo("").Tables[0];
            }
        }

        private void mnuBuscar_Click(object sender, EventArgs e)
        {
            Documento = Controles.Inputbox.Show("Documento", "Ingrese el documento del cliente.", FormStartPosition.CenterParent);
            dtgResultados.DataSource = oHelper.RecuperarFacturasCreditoConsumo(Documento).Tables[0];
        }

        private void mnuPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 oFila;
                ValorCancelar = 0;

                for (oFila = 0; oFila <= (dtgResultados.Rows.Count - 1); oFila++)
                {
                    if (dtgResultados.Rows[oFila].Cells[0].Value != null)
                    {
                        if (Boolean.Parse(dtgResultados.Rows[oFila].Cells[0].Value.ToString()) == true)
                        {
                            ValorCancelar += Decimal.Parse(dtgResultados.Rows[oFila].Cells[5].Value.ToString());
                        }
                    }
                }
                if (ValorCancelar > 0)
                {
                    if (MessageBox.Show("El Valor a Cancelar es de " + ValorCancelar.ToString("#,###.00") + " desea continuar ?", " << Pagos >>", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (oFila = 0; oFila <= (dtgResultados.Rows.Count - 1); oFila++)
                        {
                            if (dtgResultados.Rows[oFila].Cells[0].Value != null)
                            {
                                if (Boolean.Parse(dtgResultados.Rows[oFila].Cells[0].Value.ToString()) == true)
                                {
                                    oHelper.RegistrarPagoFactura(Int64.Parse(dtgResultados.Rows[oFila].Cells[1].Value.ToString()));
                                }
                            }
                        }
                        MessageBox.Show("Pago realizado satisfactoriamente.", "Pago de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtgResultados.DataSource = oHelper.RecuperarFacturasCreditoConsumo(Documento).Tables[0];

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Pago de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public event EventHandler oClosed;
        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

    }
}
