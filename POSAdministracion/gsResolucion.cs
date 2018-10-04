using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace PosStation.gsResoluciones
{
    public partial class gsResolucion : UserControl
    {
        private Helper OHelper = new Helper();
        public event EventHandler oClosed;
        private Int32 IdResolucionA = -1;
        private Boolean IsDone = false;

        public gsResolucion()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.Cursor = Cursors.WaitCursor;
            CargarResoluciones();
            LimpiarFormulario();
            this.Cursor = Cursors.Default;
        }

        private void LimpiarFormulario()
        {
            IdResolucionA = -1;
            txtNroResolucion.Text = "";
            txtPrefijo.Text = "";
            txtNroInicial.Text = "";
            txtNroFinal.Text = "";
            dtFechaExpedicion.Value = DateTime.Now;
            dtFechaVencimiento.Value = DateTime.Now;
            txtNroResolucionGContribuyente.Text = "";
            dtFechaResolucionGContribuyente.Value = DateTime.Now;
            txtNroResolucionAutoretenedor.Text = "";
            dtFechaResolucionAutoretenedor.Value = DateTime.Now;
            lblDetalle.Text = "Datos";
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNroResolucion.Text) && !String.IsNullOrEmpty(txtPrefijo.Text) && !String.IsNullOrEmpty(txtNroInicial.Text)
                    && !String.IsNullOrEmpty(txtNroFinal.Text))
                {

                    if (IdResolucionA != -1)
                    {
                        OHelper.ActualizarResolucion(IdResolucionA, txtNroResolucion.Text, txtPrefijo.Text, Int32.Parse(txtNroInicial.Text), Int32.Parse(txtNroFinal.Text), dtFechaExpedicion.Value, dtFechaVencimiento.Value, string.IsNullOrEmpty(txtNroResolucionGContribuyente.Text.Trim())?null:txtNroResolucionGContribuyente.Text, dtFechaResolucionGContribuyente.Value, string.IsNullOrEmpty(txtNroResolucionAutoretenedor.Text.Trim())?null:txtNroResolucionAutoretenedor.Text.Trim(), dtFechaResolucionAutoretenedor.Value);
                    }
                    else
                    {
                        IdResolucionA = OHelper.ActualizarResolucion(null, txtNroResolucion.Text, txtPrefijo.Text, Int32.Parse(txtNroInicial.Text), Int32.Parse(txtNroFinal.Text), dtFechaExpedicion.Value, dtFechaVencimiento.Value, string.IsNullOrEmpty(txtNroResolucionGContribuyente.Text.Trim()) ? null : txtNroResolucionGContribuyente.Text, dtFechaResolucionGContribuyente.Value, string.IsNullOrEmpty(txtNroResolucionAutoretenedor.Text.Trim()) ? null : txtNroResolucionAutoretenedor.Text.Trim(), dtFechaResolucionAutoretenedor.Value);
                    }

                    lblDetalle.Text = "Datos Resolución " + txtNroResolucion.Text;

                    Popup.ContentText = "\t\t\tData Administrator\n\nLa resolución fue guardada satisfactoriamente";
                    Popup.Popup();

                    this.CargarResoluciones();
                    LimpiarFormulario();
                }
                else
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nHay campos obligatorios que no han sido llenados";
                    Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            oClosed(sender, e);
        }

        private void gsResolucion_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CargarResoluciones();
            IsDone = true;
            this.Cursor = Cursors.Default;
        }

        private void CargarResoluciones()
        {
            grdResoluciones.DataSource = OHelper.RecuperarResolucionesDataAdmin().Tables[0];
        }

        private void grdResoluciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsDone && e.RowIndex != -1)
            {
                Int32 IdResolucionC = Int32.Parse(grdResoluciones.Rows[e.RowIndex].Cells["IdConsecutivoGrilla"].Value.ToString());
                this.CargarDatosResolucion(IdResolucionC);
            }
        }

        private void CargarDatosResolucion(Int32 IdResolucionC)
        {
            try
            {
                IDataReader Resolucion = OHelper.RecuperarResolucionPorId(IdResolucionC);
                if (Resolucion.Read())
                {
                    LimpiarFormulario();
                    IdResolucionA = Resolucion.GetInt32(Resolucion.GetOrdinal("IdConsecutivo"));
                    txtNroResolucion.Text = Resolucion.GetString(Resolucion.GetOrdinal("NroResolucion"));
                    txtPrefijo.Text = Resolucion.GetString(Resolucion.GetOrdinal("Prefijo"));
                    txtNroInicial.Text = Resolucion.GetInt32(Resolucion.GetOrdinal("NroInicial")).ToString();
                    txtNroFinal.Text = Resolucion.GetInt32(Resolucion.GetOrdinal("NroFinal")).ToString();
                    dtFechaExpedicion.Value = Resolucion.GetDateTime(Resolucion.GetOrdinal("FechaExpedicion"));
                    dtFechaVencimiento.Value = Resolucion.GetDateTime(Resolucion.GetOrdinal("FechaVencimiento"));
                    txtNroResolucionGContribuyente.Text = Resolucion.GetString(Resolucion.GetOrdinal("NroResGranContribuyente"));
                    dtFechaResolucionGContribuyente.Value = Resolucion.GetDateTime(Resolucion.GetOrdinal("FechaResGranContribuyente"));
                    txtNroResolucionAutoretenedor.Text = Resolucion.GetString(Resolucion.GetOrdinal("NroResAutoretenedor"));
                    dtFechaResolucionAutoretenedor.Value = Resolucion.GetDateTime(Resolucion.GetOrdinal("FechaResAutoretenedor"));

                    lblDetalle.Text = "Datos Resolución " + txtNroResolucion.Text;
                }

                Resolucion.Close();
                Resolucion = null;
            }
            catch (Exception ex)
            {
                LimpiarFormulario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void grdResoluciones_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar la resolución que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Data Admin",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Int32 IdResolucionC = Int32.Parse(grdResoluciones.Rows[e.Row.Index].Cells["IdConsecutivoGrilla"].Value.ToString());
                    OHelper.EliminarResolucion(IdResolucionC);
                    if (IdResolucionC == IdResolucionA)
                    {
                        IdResolucionA = -1;
                    }

                    Popup.ContentText = "\t\t\tData Administrator\n\nLa resolución fue eliminada satisfactoriamente";
                    Popup.Popup();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }
    }
}
