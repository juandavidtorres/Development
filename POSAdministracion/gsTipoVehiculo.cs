using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using POSstation.AccesoDatos;

namespace gasolutions.gsTipoVehiculos
{
    public partial class gsTipoVehiculo : UserControl
    {
        private Helper OHelper = new Helper();
        public event EventHandler oClosed;
        private Int32 IdTipoVehiculoA = -1;
        private Boolean IsDone = false;

        public gsTipoVehiculo()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.Cursor = Cursors.WaitCursor;
            CargarTiposVehiculo();
            LimpiarFormulario();
            IsDone = true;
            this.Cursor = Cursors.Default;
        }

        private void LimpiarFormulario()
        {
            IdTipoVehiculoA = -1;
            txtDescripcion.Text = "";
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
                if (!String.IsNullOrEmpty(txtDescripcion.Text))
                {

                    if (IdTipoVehiculoA != -1)
                    {
                        OHelper.ActualizarTipoVehiculo(IdTipoVehiculoA, txtDescripcion.Text);
                    }
                    else
                    {
                        IdTipoVehiculoA = OHelper.InsertarTipoVehiculo(txtDescripcion.Text);
                    }

                    lblDetalle.Text = "Datos Tipo Vehiculo " + txtDescripcion.Text;

                    Popup.ContentText = "\t\t\tData Administrator\n\nEl Tipo de vehiculo fue guardado satisfactoriamente";
                    Popup.Popup();

                    this.CargarTiposVehiculo();
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

        private void CargarTiposVehiculo()
        {
            grdTiposVehiculo.DataSource = OHelper.RecuperarTiposVehiculo().Tables[0];
        }

        private void grdTiposVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsDone && e.RowIndex != -1)
            {
                Int32 IdTipoVehiculoC = Int32.Parse(grdTiposVehiculo.Rows[e.RowIndex].Cells["IdTipoVehiculoGrilla"].Value.ToString());
                this.CargarDatosTipoVehiculo(IdTipoVehiculoC);
            }
        }

        private void CargarDatosTipoVehiculo(Int32 IdTipoVehiculoC)
        {
            try
            {
                IDataReader TipoVehiculo = OHelper.RecuperarTipoVehiculoPorId(IdTipoVehiculoC);
                if (TipoVehiculo.Read())
                {
                    LimpiarFormulario();
                    IdTipoVehiculoA = TipoVehiculo.GetInt32(TipoVehiculo.GetOrdinal("IdTipoVehiculo"));
                    txtDescripcion.Text = TipoVehiculo.GetString(TipoVehiculo.GetOrdinal("Descripcion"));

                    lblDetalle.Text = "Datos Tipo Vehiculo " + txtDescripcion.Text;
                }

                TipoVehiculo.Close();
                TipoVehiculo = null;
            }
            catch (Exception ex)
            {
                LimpiarFormulario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void grdTiposVehiculo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar el tipo de vehiculo que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Data Admin",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Int32 IdTipoVehiculoC = Int32.Parse(grdTiposVehiculo.Rows[e.Row.Index].Cells["IdTipoVehiculoGrilla"].Value.ToString());
                    OHelper.EliminarTipoVehiculo(IdTipoVehiculoC);
                    if (IdTipoVehiculoC == IdTipoVehiculoA)
                    {
                        IdTipoVehiculoA = -1;
                    }

                    Popup.ContentText = "\t\t\tData Administrator\n\nEl tipo de vehiculo fue eliminado satisfactoriamente";
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
