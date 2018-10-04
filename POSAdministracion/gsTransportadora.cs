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
    public partial class gsTransportadora : ItemMenu
    {
        private Helper OHelper = new Helper();
        public event EventHandler oClosed;
        private Int32 IdTransportadoraA = -1;
        private Boolean IsDone = false;

        public gsTransportadora()
        {
            InitializeComponent();
        }

        public void IniciarForma()
        {
            this.Cursor = Cursors.WaitCursor;
            CargarTransportadoras();
            LimpiarFormulario();
            this.Cursor = Cursors.Default;
        }

        private void LimpiarFormulario()
        {
            IdTransportadoraA = -1;
            txtNombre.Text = "";
            txtNit.Text = "";
            lblDetalle.Text = "Datos";
            chkActiva.Checked = true;
        }

        private void mnuNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void mnuGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtNit.Text))
                {
                    if (IdTransportadoraA != -1)
                    {
                        OHelper.ActualizarTransportadora(IdTransportadoraA, txtNombre.Text, txtNit.Text, chkActiva.Checked);
                        LimpiarControles();
                    }
                    else
                    {
                        IdTransportadoraA = OHelper.ActualizarTransportadora(null, txtNombre.Text, txtNit.Text, chkActiva.Checked);
                        LimpiarControles();
                        IdTransportadoraA = -1;
          
                    }

                    lblDetalle.Text = "Datos Transportadora " + txtNombre.Text;

                    Popup.ContentText = "\t\t\tData Administrator\n\nLa transportadora fue guardada satisfactoriamente";
                    Popup.Popup();

                    this.CargarTransportadoras();
                }
                else
                {
                    Popup.ContentText = "\t\t\tData Administrator\n\nHay campos obligatorios que no han sido llenados";
                    Popup.Popup();
                }
            }
            catch (Exception ex)
            {
                LimpiarControles();          
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }


        private void LimpiarControles() 
        {
            txtNit.Clear();
            txtNombre.Clear();
        
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            this.RiseEvent_OnClosed(sender, e);
        }

        private void gsTransportadora_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CargarTransportadoras();
            IsDone = true;
            this.Cursor = Cursors.Default;
        }

        private void CargarTransportadoras()
        {
            grdTransportadoras.DataSource = OHelper.RecuperarTransportadorasDataAdmin().Tables[0];
        }

        private void grdTransportadoras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsDone && e.RowIndex != -1)
            {
                Int32 IdTransportadoraC = Int32.Parse(grdTransportadoras.Rows[e.RowIndex].Cells["IdTransportadoraGrilla"].Value.ToString());
                this.CargarDatosTransportadora(IdTransportadoraC);
            }
        }

        private void CargarDatosTransportadora(Int32 idTransportadoraC)
        {
            try
            {
                IDataReader Transportadora = OHelper.RecuperarTransportadoraPorId(idTransportadoraC);
                if (Transportadora.Read())
                {
                    LimpiarFormulario();
                    IdTransportadoraA = Transportadora.GetInt32(Transportadora.GetOrdinal("IdTransportadora"));
                    txtNombre.Text = Transportadora.GetString(Transportadora.GetOrdinal("Descripcion"));
                    txtNit.Text = Transportadora.GetString(Transportadora.GetOrdinal("Nit"));

                    if (Convert.ToBoolean(Transportadora["Activa"].ToString()))
                        chkActiva.Checked = true;
                    else
                        chkActiva.Checked = false;

                    lblDetalle.Text = "Datos Transportadora " + txtNombre.Text;
                }

                Transportadora.Close();
                Transportadora = null;
            }
            catch (Exception ex)
            {
                LimpiarFormulario();
                Popup.ContentText = ex.Message;
                Popup.Popup();
            }
        }

        private void grdTransportadoras_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Desea eliminar la transportadora que se encuentra en la posición #" + (e.Row.Index + 1) + "?", "Data Admin",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Int32 IdTransportadoraC = Int32.Parse(grdTransportadoras.Rows[e.Row.Index].Cells["IdTransportadoraGrilla"].Value.ToString());
                    OHelper.EliminarTransportadora(IdTransportadoraC);
                    if (IdTransportadoraC == IdTransportadoraA)
                    {
                        IdTransportadoraA = -1;
                    }

                    Popup.ContentText = "\t\t\tData Administrator\n\nLa transportadora fue eliminada satisfactoriamente";
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
